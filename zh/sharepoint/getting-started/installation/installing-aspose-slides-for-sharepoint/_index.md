---
title: 安装 Aspose.Slides for SharePoint
type: docs
weight: 10
url: /zh/sharepoint/installing-aspose-slides-for-sharepoint/
description: "在 SharePoint 场上安装 Aspose.Slides for SharePoint：选择适用于您 SharePoint 版本的安装程序，运行系统检查，并部署和激活解决方案。"
---
## **包内容**

Aspose.Slides for SharePoint 从[download page](https://releases.aspose.com/slides/zh/sharepoint/) 下载为 ZIP 存档。该存档包含一个 SharePoint 解决方案包 (WSP) 和每个受支持的 SharePoint 版本对应的一个安装程序：

| SharePoint 版本 | 安装程序 | 解决方案包 |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

每个安装程序旁边都有一个配置文件（例如 *Setup2019.exe.config*），该文件指明它要安装的解决方案包。*License* 文件夹中包含指向最终用户许可协议和第三方许可声明的链接。

Aspose.Slides for SharePoint 以 SharePoint 解决方案的形式打包，SharePoint 会将其部署到整个服务器场。然后可以在每个站点集合上激活或停用其功能。

## **安装过程**

在安装之前，安装程序会运行系统检查。它会验证：

- 服务器上已安装 SharePoint。
- 当前用户具有安装和部署 SharePoint 解决方案的权限。
- 已启动 SharePoint 管理服务。
- 已启动 SharePoint 计时服务。
- 配置文件中指定的解决方案包存在。

需要管理服务和计时服务，因为某些安装操作以计时作业的形式运行，将解决方案传播到场中的所有服务器。

### **运行安装**

要安装 Aspose.Slides for SharePoint：

1. 将 ZIP 存档解压到 SharePoint 场中某台服务器的本地磁盘。
2. 运行与您的 SharePoint 版本相匹配的安装程序（见上表），并按照屏幕上的说明操作。安装程序会：

   1. 运行系统检查。如果任何检查失败，安装将不会继续。

      **运行系统检查**

      ![安装程序的系统检查屏幕](installing-aspose-slides-for-sharepoint_1.png)

   2. 显示最终用户许可协议。必须接受才能继续。

      **许可协议**

      ![安装程序的许可协议屏幕](installing-aspose-slides-for-sharepoint_2.png)

   3. 显示部署目标。选择要激活功能的 Web 应用程序和站点集合。

      **选择部署目标**

      ![安装程序的站点集合部署目标屏幕](installing-aspose-slides-for-sharepoint_3.png)

   4. 将解决方案部署到场。

      **安装进度**

      ![安装程序的安装进度屏幕](installing-aspose-slides-for-sharepoint_4.png)

   5. 在选定的站点集合上激活 Aspose.Slides for SharePoint。
   6. 列出已部署并激活解决方案的 Web 应用程序和站点集合。

      **安装成功**

      ![安装程序的安装完成屏幕](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="注意" %}}
截图取自 SharePoint 2007。后续版本的安装程序会显示相同的界面。
{{% /alert %}}

如果已安装相同版本的 Aspose.Slides for SharePoint，安装程序会提供修复或卸载选项；如果已安装其他版本，则会提供升级或卸载选项。

安装完成后，在所选站点集合的文档库文件菜单中会出现 **Convert via Aspose.Slides** 项（在 SharePoint 2007 中为 **Convert with Aspose.Slides**）。要转换第一个演示文稿，请参阅[将 Microsoft PowerPoint 文档转换为其他格式](/slides/zh/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/)。解决方案对场的添加方式请参阅[部署与激活](/slides/zh/sharepoint/deployment-and-activation/)。

## **FAQ**

**我应该运行哪个安装程序？**

运行名称与您的 SharePoint 版本匹配的那个。例如，在 SharePoint Server 2016 场中运行 *Setup2016.exe*。每个安装程序仅安装其对应的解决方案包。

**需要单独下载授权版吗？**

不需要。相同的包在评估模式下可用，直到您安装授权解决方案；请参阅[安装 Aspose.Slides for SharePoint 授权](/slides/zh/sharepoint/installing-aspose-slides-for-sharepoint-license/)。

**如何卸载产品？**

再次运行相同的安装程序并选择 **Remove**；请参阅[卸载 Aspose.Slides for SharePoint](/slides/zh/sharepoint/uninstalling-aspose-slides-for-sharepoint/)。