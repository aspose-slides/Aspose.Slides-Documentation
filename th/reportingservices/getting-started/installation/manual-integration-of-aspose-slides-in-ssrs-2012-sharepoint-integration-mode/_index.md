---
title: การผสานรวมด้วยตนเองของ Aspose.Slides ในโหมดการรวมกับ SharePoint บน SSRS 2012
type: docs
weight: 100
url: /th/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---
{{% alert color="primary" %}} 
บทความนี้สอนวิธีการรวม Aspose.Slides สำหรับ Reporting Services ด้วยตนเองในแนวคิดการรวม SSRS 2012 กับ SharePoint. 
{{% /alert %}} 
## **การรวม Aspose.Slides กับ SSRS 2012 ในโหมดการรวมกับ SharePoint**
การติดตั้งแบบแมนนวลที่นี่ใช้ไฟล์ DLL แทนตัวติดตั้ง MSI. 

เราขอแนะนำให้คุณติดตั้งผลิตภัณฑ์โดยใช้ตัวติดตั้ง MSI เนื่องจากมันทำกระบวนการติดตั้งและการตั้งค่าที่จำเป็นทั้งหมดโดยอัตโนมัติ. อย่างไรก็ตาม หากการติดตั้งอัตโนมัติด้วยตัวติดตั้ง MSI ล้มเหลว นี่คือขั้นตอนที่คุณต้องทำตาม:

1. คัดลอก **Aspose.Slides.ReportingServices.dll** จากไดเรกทอรี **Universal** ไปยังไดเรกทอรี bin ของ **SharePonit RS**.  
   ในกรณีของเรา ตำแหน่งคือ *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. อัปเดตไฟล์ **rssrvpolicy.config** ของ Sharepoint (จากไดเรกทอรี *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting*) ตามวิธีเดียวกันที่อธิบายไว้ในบทความ [Aspose.Slides for Reporting Services manual installation](https://docs.aspose.com/slides/th/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) 
1. รันสคริปต์นี้ใน Powershell แต่เปลี่ยน rs_test เป็นชื่อแอป Reporting Services ของคุณ. 

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

สำหรับข้อมูลเพิ่มเติมเกี่ยวกับ cmdlet ของ Reporting Service สำหรับ SharePoint ให้ดู [บทความของ Microsoft นี้](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).