---
title: 安装前提条件
type: docs
weight: 20
url: /reportingservices/installation-prerequisites/
---

{{% alert color="primary" %}} 

在我们继续安装之前，需要满足以下前提条件。 

{{% /alert %}} 
## **SharePoint 的报告服务插件**
**SharePoint 的报告服务插件**是使集成功能正常工作的关键组件之一。该插件必须安装在您 SharePoint 农场中的任何 **Web 前端 (WFE)** 和中央管理服务器上。SQL 2008 R2 和 SharePoint 2010 的一项新变化是，2008 R2 插件现在是安装 SharePoint 的前提条件。这意味着在安装 SharePoint 时会自动安装 RS 插件。已在以下图中显示并突出显示。这样可以避免我们在安装插件时遇到的许多与 SP 2007 和 RS 2008 相关的问题。 

![todo:image_alt_text](installation-prerequisites_1.png)


**图 1**: SharePoint 的报告服务插件 
## **SharePoint 身份验证**
在深入探讨 RS 集成部分之前，有一件重要的事情需要注意，那就是如何在 SharePoint 农场中设置您的 **站点**。更具体地说，是如何为该站点配置身份验证；无论是 **经典** 还是 **声称** 。这个选择在开始时非常重要。我认为一旦完成，就无法更改此选项。如果可以更改，也不会是一个简单的过程。 

{{% alert color="primary" %}} 

报告服务 2008 R2 不是声称感知的 

{{% /alert %}} 

即使您选择您的 SharePoint 站点使用 **声称**，报告服务本身也不是声称感知的。这会影响报告服务的身份验证工作方式。那么，从报告服务的角度来看，区别是什么呢？归结起来就是您是否想要将用户凭据转发到数据源。 

***经典***   - 可以使用 Kerberos 并将用户的凭据转发到您的后端数据源（需要使用 Kerberos）。 

***声称*** ** - 使用声称令牌而不是 Windows 令牌。在这种情况下，RS 将始终使用受信任的身份验证，并且将仅访问 SPUser 令牌。您需要在数据源中存储您的凭据。 

目前，我们只想关注 RS 的设置。此时，在 SharePoint 盒子上已安装 SharePoint，并在 **80 端口** 上设置为 **经典身份验证站点**。此外，在 RS 服务器上，我刚刚 **安装了报告服务**，就这些。