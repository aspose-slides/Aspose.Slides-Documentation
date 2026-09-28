---
title: 在 SharePoint 上安装 Aspose.Slides 许可证
type: docs
weight: 10
url: /zh/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "在 SharePoint 场中安装 Aspose.Slides for SharePoint 许可证：将许可证解决方案添加到解决方案存储，部署它，并检查转换后的文件不再带有评估水印。"
---
{{% alert color="info" title="Note" %}}

一旦您对评估版满意，您可以[购买许可证](https://purchase.aspose.com/pricing/slides/sharepoint/)。购买前，请确保您已了解并同意许可证订阅条款。订单付款后，许可证将通过电子邮件发送给您。

许可证是一个包含常规 SharePoint 解决方案包的 ZIP 压缩文件。压缩包包含：

- Aspose.Slides.SharePoint.License.wsp – SharePoint 解决方案包文件。许可证以 SharePoint 解决方案的形式打包，以便在服务器场之间轻松部署和回收。
- readme.txt – 许可证安装说明。

{{% /alert %}}

## **部署许可证**

许可证安装通过服务器控制台使用 **stsadm.exe** 完成。

{{% alert color="info" title="Note" %}}

以下章节省略了路径，以保持简洁。

{{% /alert %}}

执行以下步骤以部署 Aspose.Slides for SharePoint 许可证：

1. 运行 stsadm 将解决方案添加到 SharePoint 解决方案存储：

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. 将解决方案部署到场中的所有服务器：

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. 执行管理计时器作业以立即完成部署：

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

`addsolution` 操作在 `-filename` 中接受解决方案文件的路径；`deploysolution` 操作在 `-name` 中接受已在解决方案存储中存在的解决方案名称。

{{% alert color="info" title="Note" %}}

如果 SharePoint 管理服务未运行，在执行部署步骤时会出现警告。**stsadm.exe** 依赖该服务以及 SharePoint 计时器服务在服务器场之间复制解决方案数据。如果这些服务在您的服务器场未运行，可能需要在每台服务器上单独部署许可证。

{{% /alert %}}

{{% alert color="info" title="Note" %}}

在 SharePoint 2010 及更高版本中，SharePoint Management Shell cmdlet `Add-SPSolution`、`Install-SPSolution` 和 `Start-SPAdminJob` 分别对应 `addsolution`、`deploysolution` 和 `execadmsvcjobs` 操作。请参阅[Stsadm 与 Microsoft PowerShell 在 SharePoint Server 中的映射](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping)。

{{% /alert %}}

## **测试许可证**

要测试许可证是否已正确安装，可将任意演示文稿转换为新格式。如果转换后的文件中没有评估水印，则说明许可证已生效。