---
title: حذف ردیف یا ستون در جدول در VSTO و Aspose.Slides
type: docs
weight: 130
url: /fa/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---
## **VSTO**
در زیر کدی برای حذف ردیف‌ها یا ستون‌ها از جدول با استفاده از VSTO Presentation آورده شده است:

```csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //دریافت اولین اسلاید

   Slide sld = pres.Slides[1];

   foreach (Shape shp in sld.Shapes)

   {

      if (shp.HasTable == Microsoft.Office.Core.MsoTriState.msoTrue)

      {

          shp.Table.Rows[1].Delete();

      }

   }

``` 
## **Aspose.Slides**
Aspose.Slides برای .NET ساده‌ترین API را برای ایجاد جدول‌ها به ساده‌ترین روش ارائه داده است. برای ایجاد جدول در یک اسلاید و انجام برخی عملیات پایه روی جدول، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس Presentation ایجاد کنید
- مرجع یک اسلاید را با استفاده از Index آن دریافت کنید
- آرایه‌ای از ستون‌ها با عرض تعریف کنید
- آرایه‌ای از ردیف‌ها با ارتفاع تعریف کنید
- یک جدول به اسلاید اضافه کنید با استفاده از متد AddTable که توسط شیء IShapes ارائه می‌شود
- حذف ردیف جدول
- حذف ستون جدول
- ارائه اصلاح شده را به عنوان فایل PPTX ذخیره کنید

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //دریافت اولین اسلاید

  ISlide sld = MyPresentation.Slides[0];

  foreach (IShape shp in sld.Shapes)

  if (shp is ITable)

  {

     ITable tbl = (ITable)shp;

     tbl.Rows.RemoveAt(0, false);

  }

  MyPresentation.Save(FileName,Export.SaveFormat.Pptx);


``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)