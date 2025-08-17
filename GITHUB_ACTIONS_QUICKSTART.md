# 🚀 GitHub Actions Quick Start Guide

Get your CI/CD pipeline running in 5 minutes!

## ⚡ Quick Setup (5 minutes)

### **1. Add Slack Webhook Secret**
1. Go to your GitHub repository
2. Click `Settings` → `Secrets and variables` → `Actions`
3. Click `New repository secret`
4. **Name**: `SLACK_WEBHOOK_URL`
5. **Value**: Your Slack webhook URL
6. Click `Add secret`

### **2. Push the Workflows**
The workflows are already created! Just commit and push:
```bash
git add .github/
git commit -m "Add GitHub Actions CI/CD workflows"
git push
```

### **3. Test the Pipeline**
1. Go to `Actions` tab in your repository
2. You should see workflows running automatically
3. Check Slack for notifications! 🎉

## 🔗 Slack Webhook Setup

### **Option 1: Use Existing Webhook**
If you already have a Slack webhook, just add it as a secret.

### **Option 2: Create New Webhook**
1. **Go to**: [api.slack.com/apps](https://api.slack.com/apps)
2. **Click**: `Create New App` → `From scratch`
3. **Name**: `GitHub Actions Notifications`
4. **Workspace**: Select your workspace
5. **Click**: `Create App`
6. **Go to**: `Incoming Webhooks`
7. **Toggle**: `Activate Incoming Webhooks`
8. **Click**: `Add New Webhook to Workspace`
9. **Channel**: Select your desired channel
10. **Click**: `Allow`
11. **Copy**: The webhook URL
12. **Add**: As GitHub secret `SLACK_WEBHOOK_URL`

## 📱 What You'll Get

### **Success Notifications**
```
✅ Build successful for waada-ksa/test_backend#123
Repository: waada-ksa/test_backend
Commit: Add new feature
Author: @yourusername
Branch: master
Workflow: CI/CD Pipeline
```

### **Failure Notifications**
```
❌ Build failed for waada-ksa/test_backend#124
Repository: waada-ksa/test_backend
Commit: Fix bug
Author: @yourusername
Branch: feature/new-feature
Workflow: CI/CD Pipeline
```

## 🎯 Workflow Features

- ✅ **Automatic builds** on every push
- ✅ **Slack notifications** for success/failure
- ✅ **Docker builds** for main/master branches
- ✅ **Artifact storage** for 7 days
- ✅ **Manual triggers** when needed
- ✅ **Pull request validation**

## 🔧 Customization

### **Change Slack Channel**
Edit `.github/workflows/ci-cd.yml`:
```yaml
env:
  SLACK_CHANNEL: '#your-team-channel'
```

### **Add More Branches**
```yaml
on:
  push:
    branches: [ main, master, develop, feature/*, hotfix/* ]
```

### **Disable Slack Notifications**
Comment out the Slack notification steps in the workflow files.

## 🚨 Troubleshooting

### **Workflow Not Running**
- Check if workflows are in `.github/workflows/` directory
- Ensure files have `.yml` extension
- Check GitHub Actions tab for errors

### **Slack Notifications Not Working**
- Verify `SLACK_WEBHOOK_URL` secret is set
- Check webhook URL is correct
- Test webhook manually in Slack

### **Build Failures**
- Check workflow logs in Actions tab
- Verify .NET 9.0 compatibility
- Check for missing dependencies

## 📚 Next Steps

1. **Monitor builds** in Actions tab
2. **Customize notifications** for your team
3. **Add tests** to your solution
4. **Set up branch protection** rules
5. **Configure deployment** to staging/production

## 🆘 Need Help?

- **GitHub Actions Docs**: [docs.github.com/en/actions](https://docs.github.com/en/actions)
- **Slack API Docs**: [api.slack.com](https://api.slack.com)
- **Repository Issues**: Create an issue in your repo

---

**Your CI/CD pipeline is ready! 🎉**

Every time you push code, GitHub Actions will:
1. Build your .NET application
2. Run tests (if any)
3. Build Docker images (main/master only)
4. Send Slack notifications
5. Store build artifacts
