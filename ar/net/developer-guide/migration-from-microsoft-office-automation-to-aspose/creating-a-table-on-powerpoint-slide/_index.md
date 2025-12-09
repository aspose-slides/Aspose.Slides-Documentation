---
title: إنشاء جداول باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إنشاء جداول
type: docs
weight: 50
url: /ar/net/creating-a-table-on-powerpoint-slide/
keywords:
- إنشاء جدول
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "انتقل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وأنشئ جداول في شرائح PowerPoint (PPT, PPTX) باستخدام C# مع تنسيق مرن."
---

{{% alert color="primary" %}} 

تُستخدم الجداول على نطاق واسع لعرض البيانات في شرائح العروض التقديمية. تُظهر هذه المقالة كيفية إنشاء جدول بحجم 15 × 15 بحجم خط 10 بصورة برمجية باستخدام أولاً [VSTO 2008](/slides/ar/net/creating-a-table-on-powerpoint-slide/) ثم [Aspose.Slides for .NET](/slides/ar/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء الجداول**
#### **مثال VSTO 2008**
الخطوات التالية تُضيف جدولاً إلى شريحة Microsoft PowerPoint باستخدام VSTO:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة جدول بحجم 15 × 15 إلى الشريحة.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. حفظ العرض التقديمي إلى القرص.
```c#
//إنشاء عرض تقديمي
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//إضافة شريحة فارغة
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add a 15 x 15 table
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//التكرار عبر جميع الصفوف
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //التكرار عبر جميع الخلايا في الصف
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //الحصول على إطار النص لكل خلية
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //إضافة بعض النص
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //تعيين حجم الخط للنص إلى 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//حفظ العرض التقديمي إلى القرص
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
الخطوات التالية تُضيف جدولاً إلى شريحة Microsoft PowerPoint باستخدام Aspose.Slides:

1. إنشاء عرض تقديمي.
1. إضافة جدول بحجم 15 × 15 إلى الشريحة الأولى.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. كتابة العرض التقديمي إلى القرص.
```c#
Presentation pres = new Presentation();

//Access first slide
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
foreach (IRow row in tbl.Rows)
{
    foreach (ICell cell in row)
    {

        //Get text frame of each cell
        ITextFrame tf = cell.TextFrame;
        //Add some text
        tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
        //Set font size of 10
        tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
        tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
    }
}

//Write the presentation to the disk
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
