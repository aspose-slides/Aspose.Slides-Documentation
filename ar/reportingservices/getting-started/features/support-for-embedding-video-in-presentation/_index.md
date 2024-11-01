---
title: دعم تضمين الفيديو في العروض التقديمية
type: docs
weight: 80
url: /ar/reportingservices/support-for-embedding-video-in-presentation/
---

{{% alert color="primary" %}} 

لا تحتوي خدمات تقارير Microsoft SQL Server على قدرات مدمجة لتصدير التقارير مع فيديو مضمّن إلى عروض PowerPoint التقديمية. يدعم Aspose.Slides لخدمات التقارير من الإصدار 4.10 وما بعده تضمين الفيديو داخل العرض التقديمي.

{{% /alert %}} 

لتضمين الفيديو في الشرائح، يرجى إضافة مربع نص إلى التقرير يحتوي على النص: 

``` xml

 <asposeObject type="video" url="file://c:\MyVideos\intro.wmv" playMode="Auto" vlume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```


يعمل ذلك مع إصدار SQL Server 2008 وما بعده. هذه الميزة مدعومة فقط لتصدير PPTX.