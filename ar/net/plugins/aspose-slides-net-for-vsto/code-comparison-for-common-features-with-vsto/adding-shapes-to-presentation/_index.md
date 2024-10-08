---
title: إضافة أشكال إلى العرض التقديمي
type: docs
weight: 30
url: /ar/net/adding-shapes-to-presentation/
---

## **VSTO**
فيما يلي شفرة لإضافة شكل خط:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
لإضافة خط بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة Presentation
- الحصول على مرجع لشريحة باستخدام الفهرس الخاص بها
- إضافة AutoShape من نوع خط باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes
- كتابة العرض التقديمي المعدل كملف PPTX

في المثال المعطى أدناه، قمنا بإضافة خط إلى الشريحة الأولى من العرض التقديمي.

``` csharp

   //Instantiate Presentation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **تحميل الكود العامل**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تحميل عينة الكود**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)