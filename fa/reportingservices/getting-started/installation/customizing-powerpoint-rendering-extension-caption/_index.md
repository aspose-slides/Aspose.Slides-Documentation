---
title: سفارشی‌سازی زیرنویس افزونه رندرینگ پاورپوینت
type: docs
weight: 60
url: /fa/reportingservices/customizing-powerpoint-rendering-extension-caption/
---
{{% alert color="primary" %}} 
این مقاله نشان می‌دهد چگونه گزینه‌های رندرینگ زیرنویس‌های Aspose.Slides for Reporting Services را سفارشی کنید. 
{{% /alert %}} 
## **مثال**
هنگام نصب Aspose.Slides for Reporting Services، ۴ گزینهٔ صادراتی اضافی به منوی کشویی گزینه‌های صادرات اضافه می‌شود:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **نحوهٔ تغییر متن زیرنویس‌ها**
می‌توان زیرنویس‌های پیش‌فرض این افزونه‌ها را با بازنویسی نام‌های پیش‌فرض تغییر داد. این مراحل نشان می‌دهند چگونه زیرنویس را از « **PPT – PowerPoint** **Presentation via** **Aspose.Slides** » به « **PowerPoint 97 – 2003 format(PPT)** » تغییر دهند. 

**مرحله 1:** فایل **rsreportserver.config** را که معمولاً در این مسیر قرار دارد، پیدا کنید: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**مرحله** **2:** این خطوط را در فایل rsreportserver.config پیدا کنید: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>



```

**مرحله** **3:** پارامتر افزونه را با این مقدار جایگزین کنید: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>



```

گزینه‌های صادرات اکنون به این شکل نمایش داده می‌شوند: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)