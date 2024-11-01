---
title: 引言和环境设置
type: docs
weight: 10
url: /zh/reportingservices/introduction-and-environment-setup/
---

{{% alert color="primary" %}} 

过去曾有人询问关于 Aspose.Slides for Reporting Services 与 SharePoint 的集成。在本文中，我们将重点关注 SharePoint 2010。假设您已经拥有一个设置好的 SharePoint Farm 环境。我们将在本文中遵循的示例将是一个完整的 SharePoint Cloud，但在 SharePoint Foundation Server 上的步骤会类似。在我们开始之前，让我们先看看一些您在操作时可以参考的关键文档： 

- [Reporting Services 和 SharePoint 技术集成概述](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [为 SharePoint 2010 集成配置 Reporting Services](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **环境设置**
我们将要进行的设置包含 **4 台服务器**。其中包括 **域控制器**、**SQL Server**、**SharePoint 服务器**和一个用于 **Reporting Services** 的服务器。您可以选择将 SharePoint 和 Reporting Services 安装在同一台服务器上。