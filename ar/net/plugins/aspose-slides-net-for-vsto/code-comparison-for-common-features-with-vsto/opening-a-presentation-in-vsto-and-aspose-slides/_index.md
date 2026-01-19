---
title: فتح عرض تقديمي في VSTO و Aspose.Slides
type: docs
weight: 120
url: /ar/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
فيما يلي مقتطف الكود لفتح العرض التقديمي:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
توفر Aspose.Slides for .NET الفئة **Presentation** التي تُستخدم لفتح عرض تقديمي موجود. تقدم بعض المُنشئات المُحمَّلة ويمكننا الاستفادة من أحد المُنشئات المناسبة للفئة **Presentation** لإنشاء كائنها استنادًا إلى عرض تقديمي موجود. في المثال الموضح أدناه، قمنا بتمرير اسم ملف العرض التقديمي (الذي سيتم فتحه) إلى مُنشئ فئة Presentation. بعد فتح الملف، نحصل على العدد الإجمالي للشرائح الموجودة في العرض التقديمي لطباعته على الشاشة.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **تنزيل الكود التشغيلي**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تنزيل مثال الكود**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)