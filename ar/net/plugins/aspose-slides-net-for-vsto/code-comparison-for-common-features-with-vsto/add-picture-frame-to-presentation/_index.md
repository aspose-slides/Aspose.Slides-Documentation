---
title: إضافة إطار صورة إلى العرض التقديمي
type: docs
weight: 50
url: /ar/net/add-picture-frame-to-presentation/
---

## **VSTO**
فيما يلي الكود لإضافة صورة في عرض تقديمي باستخدام VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
لإضافة إطار صورة بسيط إلى الشريحة الخاصة بك، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة Presentation.
1. الحصول على مرجع الشريحة باستخدام فهرستها.
1. إنشاء كائن Image عن طريق إضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لملء الشكل.
1. حساب عرض وارتفاع الصورة.
1. إنشاء PictureFrame وفقًا للعرض والارتفاع باستخدام الطريقة AddPictureFrame التي يوفرها كائن Shapes المرتبط بالشريحة المرجعية.
1. إضافة إطار صورة (يحتوي على الصورة) إلى الشريحة.
1. كتابة العرض التقديمي المعدل كملف PPTX.

يتم تنفيذ الخطوات السابقة في المثال المعطى أدناه.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)