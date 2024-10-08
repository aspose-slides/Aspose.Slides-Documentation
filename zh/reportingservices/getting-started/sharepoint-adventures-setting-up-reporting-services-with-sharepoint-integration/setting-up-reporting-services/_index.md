---
title: 设置报告服务
type: docs
weight: 30
url: /reportingservices/setting-up-reporting-services/
---

{{% alert color="primary" %}} 

我们在 RS 服务器的第一站是报告服务配置管理器。 

{{% /alert %}} 
## **服务账户**
请确保了解您用于报告服务的服务账户。如果我们遇到问题，可能与您使用的服务账户有关。默认情况下是网络服务。每当我部署新版本时，我总是使用域账户，因为那是我可能会遇到问题的地方。在我服务器的这个配置中，我使用了一个名为 **RSService** 的域账户。 
## **Web 服务 URL**
我们需要配置 Web 服务 URL。这是 **ReportServer** 虚拟目录 (vdir)，它托管报告服务使用的 Web 服务，并且 SharePoint 将与之通信。除非您想自定义 vdir 的属性（即 SSL、端口、主机头等），否则您只需点击应用即可。 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**图 3**：设置 Web 服务 URL 

完成后，您应该会看到以下图形。 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**图 4**：成功设置 Web 服务 URL 
## **数据库**
我们需要创建报告服务目录数据库。这可以放在任何 SQL 2008 或 SQL 2008 R2 数据库引擎上。SQL11 也可以正常工作，但它仍处于测试版。此操作默认将创建两个数据库，**ReportServer** 和 **ReportServerTempDB**。 
此步骤的另一个重要方面是确保您选择 SharePoint 集成作为数据库类型。一旦做出此选择，就无法更改。请参见图 5、6 和 7 供参考。

![todo:image_alt_text](setting-up-reporting-services_4.png)

**图 5**：创建报告服务器数据库 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**图 6**：设置数据库服务器和身份验证类型 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**图 7**：设置数据库名称和模式 

对于凭据，这就是报告服务器将如何与 SQL 服务器通信。您选择的任何账户将在目录数据库以及通过 RSExecRole 的一些系统数据库中获得某些权限。MSDB 是其中一个用于订阅使用的数据库，因为我们使用 SQL Agent。 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**图 8**：设置报告服务器数据库凭据 

完成后，应该看起来像以下图形。 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**图 9**：完成报告服务器数据库设置的进度 
## **报告管理器 URL**
我们可以跳过报告管理器 URL，因为在 SharePoint 集成模式下不使用它。SharePoint 是我们的前端。报告管理器无法工作。 
## **加密密钥**
备份您的加密密钥，并确保您知道它们的存放位置。如果您遇到需要迁移数据库或恢复数据库的情况，您将需要这些密钥。 

![todo:image_alt_text](setting-up-reporting-services_9.png)

这就是报告服务配置管理器的全部内容。如果您在 Web 服务 URL 选项卡上浏览到该 URL，它应该显示类似于以下图形的内容。 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**图 12**：安装后的报告服务器访问 

发生了什么？SharePoint 安装在我的 WFE 上，我完成了报告服务的设置。在这个例子中，报告服务和 SharePoint 在不同的机器上。如果它们在同一台机器上，您就不会看到这个错误。我们从技术上讲需要在 RS 盒子上安装 SharePoint。这意味着 IIS 也将被启用。