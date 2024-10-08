---
title: 安装 Aspose.Slides for SharePoint 许可证
type: docs
weight: 10
url: /zh/sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

一旦您对评估结果感到满意，您可以 [购买许可证](https://purchase.aspose.com/buy)。在购买之前，请确保您理解并同意许可证订阅条款。订单付款后，许可证将通过电子邮件发送给您。

许可证是一个 ZIP 压缩包，包含一个常规的 SharePoint 解决方案包。该压缩包包含：

- Aspose.Slides.SharePoint.License.wsp – SharePoint 解决方案包文件。许可证被打包为 SharePoint 解决方案，以便于在服务器农场中进行部署和撤回。
- readme.txt – 许可证安装说明。

{{% /alert %}} 
## **部署许可证**
许可证安装是在服务器控制台通过 **stsadm.exe** 进行的。

{{% alert color="primary" %}} 

以下部分省略了路径以便于清晰展示。

{{% /alert %}} 

按照以下步骤部署 Aspose.Slides for SharePoint 许可证：

1. 运行 stsadm 将解决方案添加到 SharePoint 解决方案库：

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. 将解决方案部署到农场中的所有服务器：

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. 执行管理定时任务以立即完成部署：

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

如果 Windows SharePoint Services Administration 服务未运行，您在运行部署步骤时会收到警告。**stsadm.exe** 依赖此服务和 Windows SharePoint Timer Service 来在农场中复制解决方案数据。如果这些服务在您的服务器农场中未运行，您可能需要在每台服务器上部署许可证。

{{% /alert %}} 
## **测试许可证**
要测试许可证是否正确安装，请将任何文档转换为新格式。如果文档中没有评估水印，则表示许可证已成功激活。