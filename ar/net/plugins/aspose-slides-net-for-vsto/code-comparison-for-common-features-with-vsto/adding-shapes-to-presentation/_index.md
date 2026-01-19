---
title: إضافة أشكال إلى العرض التقديمي
type: docs
weight: 30
url: /ar/net/adding-shapes-to-presentation/
---

## **VSTO**
فيما يلي مقتطف الشيفرة لإضافة شكل خط:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
لإضافة خط بسيط إلى شريحة محددة في العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع الشريحة باستخدام فهرستها
- إضافة AutoShape من نوع خط باستخدام الطريقة AddAutoShape المتوفرة في كائن Shapes
- كتابة العرض التقديمي المعدل كملف PPTX

في المثال الموضح أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **تنزيل الكود القائم**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)