---
title: 报告服务 SharePoint 配置
type: docs
weight: 50
url: /reportingservices/reporting-services-sharepoint-configuration/
---

{{% alert color="primary" %}} 

现在 SharePoint 已在 RS 服务器上安装并配置，RS 通过报告服务配置管理器完成设置，我们可以开始在中央管理中进行配置。RS 2008 R2 极大简化了这个过程。我们以前需要进行三步才能使其正常工作。现在我们只需要一步。

我们要前往中央管理员网站，然后进入常规应用程序设置。在底部我们将看到报告服务。

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**图 17**: SharePoint 配置 

{{% alert color="primary" %}} 

点击 “ **报告服务集成** ”。

{{% /alert %}} 
## **Web 服务 URL**
我们将提供在报告服务配置管理器中找到的报告服务器的 URL。 
## **身份验证模式**
我们还将选择一种身份验证模式。以下 MSDN 链接详细介绍了这些模式。 
[SharePoint 集成模式下报告服务的安全概述](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

简而言之，如果您的站点使用 **声称身份验证**，那么无论您在这里选择什么，您都将始终使用受信任的身份验证。如果您希望传递 Windows 凭据，则需要选择 Windows 身份验证。对于受信任的身份验证，我们将传递 SPUser 令牌，而不是依赖 Windows 凭据。 

如果您已将经典模式站点配置为 NTLM，并且 RS 已为 NTLM 设置，则还希望使用受信任的身份验证。要使用 Windows 身份验证并将其传递给数据源，则需要 Kerberos。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**图 18**: 设置报告服务集成凭据
## **激活功能**
这为您提供了在所有网站集合上激活报告服务的选项，或者您可以选择要在哪些网站上激活它。这实际上意味着哪些站点将能够使用报告服务。 
完成后，您应看到以下图形。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**图 19**: 报告服务与 SharePoint 环境的成功集成 

回到图 14 中给出的报告服务器 URL，我们应该看到类似以下图形的内容。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**图 20**: 报告服务与 SharePoint 环境的成功验证 

{{% alert color="primary" %}} 

如果您的 SharePoint 站点配置为 SSL，则不会出现在该列表中。这是一个已知问题，并不意味着存在问题。您的报告应该仍然可以正常工作。 

{{% /alert %}} 

现在，我们已经准备好在 SharePoint 2010 中使用报告服务。与之前的版本一样，我们在“网站集合功能”中有一个功能（在我们配置报告服务集成时激活）。安装还添加了 3 种内容类型，以供我们添加到站点。在图 21 中，我们可以看到在文档库中添加的 2 种内容类型，以使用它们创建自定义报告，如图 21 所示。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**图 21**: 报告生成器 

“ **报告生成器**”是一个 ActiveX，我们需要在服务器上下载，如图 22 所示。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**图 22**: 下载和安装报告生成器 

下载完成后运行 **“报告生成器”**。现在，我们已经准备好设计我们的第一个报告，如图 23 所示。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**图 23**: 报告生成器新报告生成向导 

在创建报告后，我们可以将其保存在为在 SharePoint 2010 中放置报告而创建的文档库中。 

另一个内容类型必须用于创建共享连接作为数据源，并将其保存在 SharePoint 中的文档库中。我们可以创建一个文档库，添加该内容类型，然后我们可以获得可用的连接，以更改报告的数据源。 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**图 24**: 成功导出报告到报告服务器 