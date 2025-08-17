# GitHub Actions Setup Guide

This directory contains GitHub Actions workflows for CI/CD automation.

## 📋 Available Workflows

### 1. **ci-cd.yml** - Full CI/CD Pipeline
- **Triggers**: Push to main/master/develop, Pull Requests, Manual dispatch
- **Features**: 
  - Build and test .NET application
  - Docker image building
  - Slack notifications for build status
  - Artifact uploads

### 2. **build.yml** - Simple Build Workflow
- **Triggers**: Push to any branch, Pull Requests, Manual dispatch
- **Features**: 
  - Quick .NET build verification
  - No Slack notifications (for faster execution)

### 3. **slack-notification.yml** - Reusable Slack Notifications
- **Usage**: Called by other workflows
- **Features**: 
  - Configurable Slack notifications
  - Reusable across multiple workflows

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

### **Build Process**
1. **Checkout** code from repository
2. **Setup** .NET 9.0 environment
3. **Restore** NuGet dependencies
4. **Build** solution in Release mode
5. **Test** (if tests exist)
6. **Publish** application
7. **Upload** artifacts
8. **Notify** Slack of results

### **Docker Build** (Main/Master branches only)
1. **Setup** Docker Buildx
2. **Build** Docker image
3. **Notify** Slack of Docker build status

## 📱 Slack Notifications

### **Success Messages**
- ✅ Build successful
- 🐳 Docker build successful
- Includes commit info, author, and build details

### **Failure Messages**
- ❌ Build failed
- 🐳 Docker build failed
- Mentions the user who triggered the build

## 🔄 Workflow Triggers

- **Push**: Automatically runs on code pushes
- **Pull Request**: Runs on PR creation/updates
- **Manual**: Can be triggered manually via GitHub UI
- **Scheduled**: Can be extended with cron schedules

## 🛠️ Customization

### **Change Slack Channel**
Update the `SLACK_CHANNEL` environment variable in workflows:
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

### **Extend with Tests**
Add test execution after the build step:
```yaml
- name: Run tests
  run: dotnet test backend.sln --no-build --verbosity normal
```

## 📊 Monitoring

- **View runs**: Go to `Actions` tab in your repository
- **Check logs**: Click on any workflow run to see detailed logs
- **Debug issues**: Use workflow logs to troubleshoot build problems

## 🔒 Security Notes

- **Webhook URLs** are stored as encrypted secrets
- **No sensitive data** is exposed in workflow logs
- **Branch protection** can be enabled for additional security
