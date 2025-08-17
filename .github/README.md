# GitHub Actions Setup Guide

This directory contains GitHub Actions workflows for CI/CD automation with **separated concerns**.

## 📋 Available Workflows

### 1. **build.yml** - Build and Test Only
- **Triggers**: Push to any branch, Pull Requests, Manual dispatch
- **Features**: 
  - Build and test .NET application
  - Publish application
  - Upload build artifacts
  - **No Slack notifications** (focused on building)
  - Triggers notification workflow on completion

### 2. **notify.yml** - Slack Notifications Only
- **Triggers**: 
  - Manual dispatch (with custom inputs)
  - Automatically triggered by build workflow completion
- **Features**: 
  - Send Slack notifications for build status
  - Configurable notification messages
  - Handles success, failure, and unknown statuses

### 3. **docker-build.yml** - Docker Build Only
- **Triggers**: 
  - Manual dispatch
  - Automatically triggered by build workflow completion (main/master only)
- **Features**: 
  - Build Docker images
  - Send Slack notifications for Docker build status
  - Only runs on main/master branches

### 4. **ci-cd.yml** - Legacy Full Pipeline (Optional)
- **Note**: This is the original combined workflow
- **Use**: Only if you prefer the combined approach

## 🔄 Workflow Flow

```
Push Code → Build Workflow → Notification Workflow
                ↓
            Docker Build (main/master only)
```

## 🔧 Setup Requirements

### **Required Secrets**
Add these secrets in your GitHub repository settings:

1. **Go to**: `Settings` → `Secrets and variables` → `Actions`
2. **Add secret**: `SLACK_WEBHOOK_URL`
   - Value: Your Slack webhook URL
   - Format: `https://hooks.slack.com/services/YOUR/WEBHOOK/URL`

### **Slack Webhook Setup**
1. **Create a Slack App** in your workspace
2. **Enable Incoming Webhooks**
3. **Create a webhook** for your desired channel
4. **Copy the webhook URL** and add it as a secret

## 🚀 How It Works

### **Build Process (build.yml)**
1. **Checkout** code from repository
2. **Setup** .NET 9.0 environment
3. **Restore** NuGet dependencies
4. **Build** solution in Release mode
5. **Test** (if tests exist)
6. **Publish** application
7. **Upload** artifacts
8. **Trigger** notification workflow

### **Notification Process (notify.yml)**
1. **Receive** build status from build workflow
2. **Format** notification message
3. **Send** to Slack with appropriate emoji and details

### **Docker Build Process (docker-build.yml)**
1. **Setup** Docker Buildx
2. **Build** Docker image
3. **Notify** Slack of Docker build status

## 📱 Slack Notifications

### **Success Messages**
- ✅ **Build successful** - Sent by notification workflow
- 🐳 **Docker build successful** - Sent by Docker workflow

### **Failure Messages**
- ❌ **Build failed** - Sent by notification workflow
- 🐳 **Docker build failed** - Sent by Docker workflow

### **Unknown Status**
- ❓ **Build status unknown** - Handles edge cases

## 🔄 Workflow Triggers

- **Push**: Automatically runs build workflow
- **Pull Request**: Runs build workflow for validation
- **Manual**: Can trigger any workflow manually
- **Workflow Run**: Notifications triggered by build completion

## 🛠️ Customization

### **Change Slack Channel**
Update the `SLACK_CHANNEL` environment variable in workflow files:
```yaml
env:
  SLACK_CHANNEL: '#your-channel-name'
```

### **Add More Branches**
Modify the `branches` array in workflow triggers:
```yaml
on:
  push:
    branches: [ main, master, develop, feature/*, hotfix/* ]
```

### **Modify Notification Messages**
Edit the `text` field in notification steps:
```yaml
text: "🚀 Your custom message here"
```

## 📊 Monitoring

- **View runs**: Go to `Actions` tab in your repository
- **Check logs**: Click on any workflow run to see detailed logs
- **Debug issues**: Use workflow logs to troubleshoot problems
- **Workflow dependencies**: See how workflows trigger each other

## 🔒 Security Notes

- **Webhook URLs** are stored as encrypted secrets
- **No sensitive data** is exposed in workflow logs
- **Branch protection** can be enabled for additional security
- **Workflow permissions** are properly scoped

## 🎯 Benefits of Separation

- **Faster builds** - No waiting for Slack API calls
- **Better debugging** - Isolated workflow concerns
- **Flexible notifications** - Can trigger independently
- **Easier maintenance** - Update notifications without affecting builds
- **Parallel execution** - Multiple workflows can run simultaneously
