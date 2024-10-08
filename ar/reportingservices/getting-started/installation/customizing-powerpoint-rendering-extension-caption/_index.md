---
title: تخصيص عنوان ملحق عرض PowerPoint
type: docs
weight: 60
url: /ar/reportingservices/customizing-powerpoint-rendering-extension-caption/
---

{{% alert color="primary" %}} 

توضح هذه المقالة كيفية تخصيص خيارات عرض Aspose.Slides لخدمات التقارير.

{{% /alert %}} 
## **مثال**
عند تثبيت Aspose.Slides لخدمات التقارير، يتم إضافة 4 خيارات تصدير إضافية في القائمة المنسدلة لخيارات التصدير:

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_1.png)
## **كيفية تعديل نصوص العناوين**
يمكن تغيير العناوين الافتراضية لهذه الملحقات عن طريق تجاوز الأسماء الافتراضية. توضح هذه الخطوات كيفية تغيير العنوان من “ **PPT – PowerPoint** **Presentation via** **Aspose.Slides** ” إلى “ **PowerPoint 97 – 2003 format(PPT)** ”. 

**الخطوة 1:** ابحث عن ملف **rsreportserver.config** الذي يكون عادة في هذا الدليل: 

**OS Root Drive\Program Files\Microsoft SQL Server\MSRS10.MSSQLSERVER\Reporting Services\ReportServer** 

**الخطوة 2:** ابحث عن هذه الأسطر في ملف rsreportserver.config: 

``` xml

 <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

``` 

**الخطوة 3:** استبدل معلمة الملحق بهذا: 

**<Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices">**

``` xml

         <OverrideNames>

          <Name Language="en-US">PowerPoint 97 - 2003 Format(PPT)</Name>

        </OverrideNames>

</Extension>

``` 

ستظهر الآن خيارات التصدير بهذا الشكل: 

![todo:image_alt_text](customizing-powerpoint-rendering-extension-caption_2.png)