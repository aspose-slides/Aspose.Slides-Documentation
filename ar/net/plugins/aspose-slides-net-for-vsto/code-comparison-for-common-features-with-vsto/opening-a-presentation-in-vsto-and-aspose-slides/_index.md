---
title: فتح عرض تقديمي في VSTO و Aspose.Slides
type: docs
weight: 120
url: /net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
فيما يلي مقتطف الشيفرة لفتح العرض التقديمي:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
يوفر Aspose.Slides لـ .NET فئة **Presentation** التي تُستخدم لفتح عرض تقديمي موجود. إنها تقدم بعض البانيات المُحمَّلة، ويمكننا الاستفادة من أحد البانيات المناسبة لفئة **Presentation** لإنشاء كائنها بناءً على عرض تقديمي موجود. في المثال المعطى أدناه، قمنا بتمرير اسم ملف العرض التقديمي (الذي سيتم فتحه) إلى باني فئة Presentation. بعد فتح الملف، نحصل على العدد الإجمالي للشرائح الموجودة في العرض التقديمي لطبعها على الشاشة.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **تنزيل الشيفرة القابلة للتشغيل**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تنزيل الشيفرة النموذجية**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)