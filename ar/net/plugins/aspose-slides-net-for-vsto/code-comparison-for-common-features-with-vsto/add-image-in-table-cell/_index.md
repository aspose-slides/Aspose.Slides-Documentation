---
title: إضافة صورة في خلية الجدول
type: docs
weight: 10
url: /net/add-image-in-table-cell/
---

## **VSTO**
فيما يلي الكود لإضافة صورة في خلية الجدول:

``` csharp

    //فتح فئة العرض التقديمي التي تحتوي على الجدول

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //الحصول على الشريحة الأولى

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          Cell cell= shp.Table.Rows[1].Cells[1];

          cell.Shape.Fill.UserPicture(ImageFile);

      }

   }


``` 
## **Aspose.Slides**
قدمت Aspose.Slides لـ .NET أبسط واجهة برمجة التطبيقات لإنشاء الجداول بطريقة سهلة. لإضافة صورة في خلية الجدول أثناء إنشاء جدول جديد، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة العرض التقديمي
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
- تعريف مصفوفة من الأعمدة مع العرض
- تعريف مصفوفة من الصفوف مع الارتفاع
- إضافة جدول إلى الشريحة باستخدام طريقة AddTable المقدمة من كائن IShapes
- إنشاء كائن Bitmap للاحتفاظ بملف الصورة
- إضافة صورة Bitmap إلى كائن IPPImage
- تعيين تنسيق الملء لخلية الجدول كصورة
- إضافة الصورة إلى الخلية الأولى من الجدول
- حفظ العرض التقديمي المعدل كملف PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //الحصول على الشريحة الأولى

  ISlide sld = MyPresentation.Slides[0];

  //إنشاء كائن صورة Bitmap للاحتفاظ بملف الصورة

  using IImage image = Images.FromFile(ImageFile);

  //إنشاء كائن IPPImage باستخدام كائن bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //إضافة الصورة إلى أول خلية في الجدول

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //حفظ PPTX على القرص

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **تحميل الكود القابل للتشغيل**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **تحميل نموذج الكود**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding image in table cell/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)