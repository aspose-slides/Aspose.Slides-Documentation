---
title: 手動整合 Aspose.Slides 於 SSRS 2012 SharePoint 整合模式
type: docs
weight: 100
url: /zh-hant/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 
本篇文章教導您如何在 SSRS 2012 SharePoint 整合概念中手動整合 Aspose.Slides for Reporting Services。 
{{% /alert %}} 
## **在 SharePoint 整合模式下將 Aspose.Slides 與 SSRS 2012 整合**
此處的手動安裝使用 DLL 代替 MSI 安裝程式。 

我們建議您使用 MSI 安裝程式來安裝產品，因為它會自動執行所有必要的安裝程序與組態任務。但若使用 MSI 安裝程式的自動安裝失敗，請依照以下步驟操作：

1. 將 **Aspose.Slides.ReportingServices.dll** 從 **Universal** 目錄複製到 **SharePonit RS** bin 目錄。  
   於我們的環境中，路徑為 *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. 更新 Sharepoint 的 **rssrvpolicy.config** 檔案（位於 *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* 目錄），方式與 [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/zh-hant/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) 文章中所描述的相同。 
1. 在 PowerShell 中執行此指令碼，但請將 rs_test 替換為您的 Reporting Services 應用程式名稱。 

**rs_test**

``` xml



Write-Host "Adding Aspose.Slides rendering extensions"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "Get ReportinService Application Service"

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

如需取得關於 SharePoint 的 Reporting Service Cmdlet 的更多資訊，請閱讀[此 Microsoft 文章](http://technet.microsoft.com/en-us/library/gg492249?ppud=4)。