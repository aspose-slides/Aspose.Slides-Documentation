---
title: ادغام دستی Aspose.Slides در حالت یکپارچه‌سازی SharePoint با SSRS 2012
type: docs
weight: 100
url: /fa/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

این مقاله به شما می‌آموزد که چگونه Aspose.Slides for Reporting Services را به صورت دستی در مفهوم یکپارچه‌سازی SharePoint با SSRS 2012 ادغام کنید. 

{{% /alert %}} 
## **یکپارچه‌سازی Aspose.Slides با SSRS 2012 در حالت یکپارچه‌سازی SharePoint**
نصب دستی در اینجا به‌جای MSI installer از DLL استفاده می‌کند. 

ما توصیه می‌کنیم محصول را با MSI installer نصب کنید زیرا تمام فرآیندهای نصب لازم و وظایف پیکربندی را به‌صورت خودکار انجام می‌دهد. با این حال، اگر نصب خودکار با MSI installer شکست خورد، باید مراحلی که در زیر آمده است را دنبال کنید:

1. فایل **Aspose.Slides.ReportingServices.dll** را از پوشه **Universal** به پوشه **SharePonit RS** در مسیر bin کپی کنید. در مثال ما مسیر زیر است: *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. فایل **rssrvpolicy.config** مربوط به Sharepoint را (از مسیر *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) به همان روشی که در مقاله [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/fa/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) توضیح داده شده به‌روزرسانی کنید.
1. این اسکریپت را در PowerShell اجرا کنید، اما rs_test را با نام برنامه Reporting Services خود جایگزین کنید. 

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

برای اطلاعات بیشتر در مورد cmdletهای Reporting Service برای SharePoint، مقاله [this Microsoft article](http://technet.microsoft.com/en-us/library/gg492249?ppud=4) را مطالعه کنید.