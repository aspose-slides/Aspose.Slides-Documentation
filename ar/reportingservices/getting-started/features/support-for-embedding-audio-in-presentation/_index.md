---
title: دعم تضمين الصوت في العروض التقديمية
type: docs
weight: 90
url: /ar/reportingservices/support-for-embedding-audio-in-presentation/
---

{{% alert color="primary" %}} 

لا تحتوي خدمات تقارير Microsoft SQL Server على قدرات مدمجة لتصدير التقارير مع الصوت المضمن إلى عروض PowerPoint التقديمية. تدعم Aspose.Slides for Reporting Services 4.10 والإصدارات الأحدث تضمين الصوت داخل العرض التقديمي المصدر.

{{% /alert %}} 

لتضمين الصوت في الشرائح، يُرجى وضع مربع نص في التقرير يحتوي على النص: 

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


تعمل هذه الميزة مع إصدار SQL Server 2008 وما فوق. تدعم هذه الميزة فقط تصدير PPTX.