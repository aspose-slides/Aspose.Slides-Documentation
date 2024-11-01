---
title: 手动集成 Aspose.Slides 在 SSRS 2012 SharePoint 集成模式
type: docs
weight: 100
url: /zh/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

本文教你如何在 SSRS 2012 SharePoint 集成概念中手动集成 Aspose.Slides for Reporting Services。 

{{% /alert %}} 
## **在 SharePoint 集成模式下将 Aspose.Slides 与 SSRS 2012 集成**
这里的手动安装使用 DLL 替代 MSI 安装程序。 

我们建议您使用 MSI 安装程序安装产品，因为它会自动执行所有必要的安装过程和配置任务。不过，如果使用 MSI 安装程序的自动安装失败，您必须遵循以下步骤：

1. 从 **Universal** 目录复制 **Aspose.Slides.ReportingServices.dll** 到 **SharePont RS** bin 目录。
   在我们的例子中，它是 *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. 更新 Sharepoint 的 **rssrvpolicy.config** 文件（从 *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* 目录）的方法与在 [Aspose.Slides for Reporting Services 手动安装](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) 文章中描述的一样。
1. 在 PowerShell 中运行这个脚本，但将 rs_test 替换为您的 Reporting Services 应用程序名称。 

**rs_test**

``` xml



Write-Host "添加 Aspose.Slides 渲染扩展"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "获取 Reporting Service 应用程序服务"

$app = get-sprsserviceapplication



if ($app) {

                $app | ForEach-Object {



                $aspps = Get-SPRSExtension -Identity $_ -Name "ASPPS" -ExtensionType "Render"

                $aspptx = Get-SPRSExtension -Identity $_ -Name "ASPPTX" -ExtensionType "Render"

                $asppsx = Get-SPRSExtension -Identity $_ -Name "ASPPSX" -ExtensionType "Render"

                $asppt = Get-SPRSExtension -Identity $_ -Name "ASPPT" -ExtensionType "Render"



                if (-not $aspps ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPS" -TypeName "Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices" }

                if (-not $aspptx) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPTX" -TypeName "Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppsx ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPSX" -TypeName "Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"}

                if (-not $asppt ) { New-SPRSExtension -ExtensionType "Render"  -Identity $_ -Name "ASPPT" -TypeName "Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"}

                }

}



```

有关 SharePoint 的 Reporting Service cmdlet 的更多信息，请阅读 [这篇 Microsoft 文章](http://technet.microsoft.com/en-us/library/gg492249?ppud=4)。