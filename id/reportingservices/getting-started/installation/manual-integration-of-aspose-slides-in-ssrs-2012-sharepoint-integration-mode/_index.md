---
title: Integrasi manual Aspose.Slides dalam Mode Integrasi SharePoint SSRS 2012
type: docs
weight: 100
url: /id/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 

Artikel ini mengajarkan Anda cara mengintegrasikan Aspose.Slides untuk Reporting Services secara manual dalam konsep integrasi SharePoint SSRS 2012. 

{{% /alert %}} 
## **Mengintegrasikan Aspose.Slides dengan SSRS 2012 dalam Mode Integrasi SharePoint**
Instalasi manual di sini menggunakan DLL sebagai pengganti installer MSI. 

Kami menyarankan Anda menginstal produk menggunakan installer MSI karena secara otomatis melakukan semua proses instalasi yang diperlukan dan tugas konfigurasi. Namun, jika instalasi otomatis dengan installer MSI gagal, berikut langkah-langkah yang harus Anda ikuti:

1. Salin **Aspose.Slides.ReportingServices.dll** dari direktori **Universal** ke direktori bin **SharePonit RS**. Dalam kasus kami, lokasinya *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. Perbarui file **rssrvpolicy.config** Sharepoint (dari direktori *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) dengan cara yang sama seperti yang dijelaskan pada artikel [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/id/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/). 
1. Jalankan skrip ini di PowerShell tetapi ganti rs_test dengan nama aplikasi Reporting Services Anda. 

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

Untuk informasi lebih lanjut tentang cmdlet Reporting Service untuk SharePoint, baca [artikel Microsoft ini](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).