---
title: دمج يدوي لـ Aspose.Slides في SSRS 2012 وضع تكامل SharePoint
type: docs
weight: 100
url: /reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/
---

{{% alert color="primary" %}} 

تعلّمك هذه المقالة كيفية دمج Aspose.Slides لخدمات التقارير يدويًا في مفهوم تكامل SharePoint في SSRS 2012. 

{{% /alert %}} 
## **دمج Aspose.Slides مع SSRS 2012 في وضع تكامل SharePoint**
تستخدم عملية التثبيت اليدوية هنا DLL بدلاً من مثبت MSI.

نوصيك بتثبيت المنتج باستخدام مثبت MSI لأنه يؤدي جميع عمليات التثبيت والتهيئة اللازمة تلقائيًا. ومع ذلك، إذا فشلت عملية التثبيت التلقائية باستخدام مثبت MSI، فهذه هي الخطوات التي يجب عليك اتباعها:

1. انسخ **Aspose.Slides.ReportingServices.dll** من الدليل **Universal** إلى دليل bin الخاص بـ **SharePonit RS**.
   في حالتنا، هو *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting\bin* 
1. قم بتحديث ملف **rssrvpolicy.config** الخاص بـ Sharepoint (من *C:\Program Files\Common Files\Microsoft Shared\Web Server Extensions\14\WebServices\Reporting* بنفس الطريقة الموضحة في [تثبيت Aspose.Slides لخدمات التقارير يدويًا](https://docs.aspose.com/slides/reportingservices/manual-integration-of-aspose-slides-in-ssrs-2012-sharepoint-integration-mode/) مقالة.
1. قم بتشغيل هذا السكربت في PowerShell لكن استبدل rs_test باسم تطبيق خدمات التقارير الخاص بك.

**rs_test**

``` xml



Write-Host "إضافة ملحقات عرض Aspose.Slides"

Add-PSSnapIn Microsoft.SharePoint.PowerShell



Write-Host "الحصول على خدمة تطبيق ReportingService"

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

لمزيد من المعلومات حول cmdlets خدمات التقارير لـ SharePoint، اقرأ [هذه المقالة من Microsoft](http://technet.microsoft.com/en-us/library/gg492249?ppud=4).