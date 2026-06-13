---
title: افزودن تصویر در سلول جدول
type: docs
weight: 10
url: /fa/net/add-image-in-table-cell/
---
## **VSTO**
در زیر کد افزودن تصویر در سلول جدول آورده شده است:

``` csharp

    //کلاس Prsentation را باز کنید که شامل جدول است
   string FileName = "Adding Image in Table Cell.pptx";

   string ImageFile = "AsposeLogo.jpg";

   Presentation pres = Application.Presentations.Open(FileName);

   //دریافت اولین اسلاید
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
Aspose.Slides برای .NET API ساده‌ترین روش برای ایجاد جدول‌ها را فراهم کرده است. برای افزودن تصویر به یک سلول جدول هنگام ایجاد جدول جدید، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید
- یک آرایه از ستون‌ها با عرض تعریف کنید
- یک آرایه از ردیف‌ها با ارتفاع تعریف کنید
- با استفاده از متد AddTable که توسط شیء IShapes ارائه شده است، یک جدول به اسلاید اضافه کنید
- یک شیء Bitmap برای نگهداری فایل تصویر ایجاد کنید
- تصویر Bitmap را به شیء IPPImage اضافه کنید
- قالب پر کردن سلول جدول را به عنوان تصویر تنظیم کنید
- تصویر را به اولین سلول جدول اضافه کنید
- ارائه تغییر یافته را به عنوان فایل PPTX ذخیره کنید

``` csharp

   string FileName = "Adding Image in Table Cell.pptx";

  string ImageFile = "AsposeLogo.jpg";

  Presentation MyPresentation = new Presentation(FileName);

  //دریافت اولین اسلاید

  ISlide sld = MyPresentation.Slides[0];

  //ایجاد شیء Bitmap Image برای نگهداری فایل تصویر

  using IImage image = Images.FromFile(ImageFile);

  //ایجاد شیء IPPImage با استفاده از شیء bitmap

  IPPImage imgx1 = MyPresentation.Images.AddImage(image);

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     //افزودن تصویر به اولین سلول جدول

     tbl[0, 0].FillFormat.FillType = FillType.Picture;

     tbl[0, 0].FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

     tbl[0, 0].FillFormat.PictureFillFormat.Picture.Image = imgx1;

   }

  //ذخیره PPTX بر روی دیسک

  MyPresentation.Save(FileName, Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20image%20in%20table%20cell)