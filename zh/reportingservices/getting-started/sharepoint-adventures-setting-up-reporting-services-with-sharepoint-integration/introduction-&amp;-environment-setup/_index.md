---
title: 介绍与环境设置
type: docs
weight: 10
url: /reportingservices/introduction-&amp;-environment-setup/
---

{{% alert color="primary" %}} 

过去曾有人询问有关 Aspose.Slides 与 SharePoint 集成的 Reporting Services。在本文中，我们将重点关注 SharePoint 2010。假设您已经设置了 SharePoint Farm 环境。我们将在本文中遵循的示例将是一个完整的 SharePoint 云，但对于 SharePoint Foundation Server 步骤将类似。在我们开始之前，让我们先看一些您在执行此操作时可以参考的关键文档： 

- [Reporting Services 与 SharePoint 技术集成概述](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [配置 Reporting Services 以进行 SharePoint 2010 集成](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **环境设置**
我们将设置的环境由 **4 台服务器** 组成。包括 **域控制器**、**SQL 服务器**、**SharePoint 服务器**和一台用于 **Reporting Services** 的服务器。您可以选择将 SharePoint 和 Reporting Services 安装在同一台机器上。