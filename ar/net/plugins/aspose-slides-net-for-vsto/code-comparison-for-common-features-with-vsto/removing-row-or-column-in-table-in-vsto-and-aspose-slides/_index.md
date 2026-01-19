---
title: إزالة صف أو عمود في جدول باستخدام VSTO و Aspose.Slides
type: docs
weight: 130
url: /ar/net/removing-row-or-column-in-table-in-vsto-and-aspose-slides/
---

## **VSTO**
فيما يلي الكود لإزالة الصفوف أو الأعمدة من جدول باستخدام VSTO Presentation:

``` csharp

    string FileName = "Removing Row Or Column in Table.pptx";

   Presentation pres = Application.Presentations.Open(FileName);

   //Get the first slide

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
قدمت Aspose.Slides لـ .NET أبسط واجهة برمجة تطبيقات لإنشاء الجداول بأبسط طريقة. لإنشاء جدول في شريحة وإجراء بعض العمليات الأساسية على الجدول، يرجى اتباع الخطوات أدناه:

- إنشاء مثال من فئة Presentation
- الحصول على مرجع الشريحة باستخدام مؤشرها
- تحديد مصفوفة الأعمدة مع العرض
- تحديد مصفوفة الصفوف مع الارتفاع
- إضافة جدول إلى الشريحة باستخدام طريقة AddTable المعروضة بواسطة كائن IShapes
- إزالة صف من الجدول
- إزالة عمود من الجدول
- حفظ العرض المعدل كملف PPTX

``` csharp

   string FileName = "Removing Row Or Column in Table.pptx";

  Presentation MyPresentation = new Presentation(FileName);

  //Get First Slide

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
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Removing%20Row%20Or%20Column%20in%20Table)