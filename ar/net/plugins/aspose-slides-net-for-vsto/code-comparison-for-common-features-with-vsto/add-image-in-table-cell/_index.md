---
title: إضافة صورة في خلية جدول
type: docs
weight: 10
url: /ar/net/add-image-in-table-cell/
---

## **VSTO**
فيما يلي الشيفرة لإضافة صورة في خلية جدول:

``` csharp

    //Open Prsentation class that contains the table

   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
قدمت Aspose.Slides لـ .NET أبسط واجهة برمجة تطبيقات لإنشاء الجداول بأبسط طريقة. لإضافة صورة في خلية جدول أثناء إنشاء جدول جديد، يرجى اتباع الخطوات التالية:

- إنشاء كائن من فئة Presentation
- الحصول على مرجع الشريحة باستخدام الفهرس الخاص بها
- تعريف مصفوفة الأعمدة مع العرض
- تعريف مصفوفة الصفوف مع الارتفاع
- إضافة جدول إلى الشريحة باستخدام طريقة AddTable التي توفرها كائن IShapes
- إنشاء كائن Bitmap لاحتواء ملف الصورة
- إضافة صورة Bitmap إلى كائن IPPImage
- تعيين تنسيق التعبئة لخلية الجدول كصورة
- إضافة الصورة إلى الخلية الأولى من الجدول
- حفظ العرض المعدل كملف PPTX

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

  ISlide sld = MyPresentation.Slides[0];

  //Creating a Bitmap Image object to hold the image file

  using IImage image = Images.FromFile(ImageFile);

  //Create an IPPImage object using the bitmap object

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //Add image to first table cell

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //Save PPTX to Disk

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)