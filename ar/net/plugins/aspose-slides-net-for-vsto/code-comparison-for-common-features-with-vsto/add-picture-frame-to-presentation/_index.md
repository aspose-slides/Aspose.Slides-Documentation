---
title: إضافة إطار صورة إلى العرض التقديمي
type: docs
weight: 50
url: /net/add-picture-frame-to-presentation/
---

## **VSTO**
فيما يلي الكود لإضافة صورة في عرض VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
لإضافة إطار صورة بسيط إلى الشريحة الخاصة بك، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة Presentation.
1. الحصول على مرجع لشريحة باستخدام فهرسها.
1. إنشاء كائن صورة عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الشكل.
1. حساب عرض وارتفاع الصورة.
1. إنشاء PictureFrame وفقًا لعرض وارتفاع الصورة باستخدام طريقة AddPictureFrame المعروضة بواسطة كائن الأشكال المرتبط بالشريحة المرجعية.
1. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
1. كتابة العرض التقديمي المعدل كملف PPTX.

يتم تنفيذ الخطوات أعلاه في المثال المعطى أدناه.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //إنشاء مثيل لفئة Prseetation التي تمثل PPTX

  Presentation pres = new Presentation();

  //الحصول على الشريحة الأولى

  ISlide sld = pres.Slides[0];

  //إنشاء مثيل لفئة ImageEx

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //إضافة إطار صورة بارتفاع وعرض مكافئين للصورة

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **تحميل الكود القابل للتنفيذ**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تحميل نموذج الكود**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)