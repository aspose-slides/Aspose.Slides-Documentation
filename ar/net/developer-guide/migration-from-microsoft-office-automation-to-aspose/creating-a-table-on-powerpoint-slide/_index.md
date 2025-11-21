---
title: إنشاء جداول باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إنشاء جداول
type: docs
weight: 50
url: /ar/net/creating-a-table-on-powerpoint-slide/
keywords:
- إنشاء جدول
- الترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإنشاء جداول في شرائح PowerPoint (PPT, PPTX) باستخدام C# مع تنسيق مرن."
---

{{% alert color="primary" %}} 

تُستخدم الجداول بشكل واسع لعرض البيانات على شرائح العروض التقديمية. توضح هذه المقالة كيفية إنشاء جدول بحجم 15 × 15 بخط بحجم 10 برمجياً باستخدام [VSTO 2008](/slides/ar/net/creating-a-table-on-powerpoint-slide/) أولاً، ثم [Aspose.Slides for .NET](/slides/ar/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء الجداول**
#### **مثال VSTO 2008**
الخطوات التالية تضيف جدولاً إلى شريحة Microsoft PowerPoint باستخدام VSTO:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة جدول بحجم 15 × 15 إلى الشريحة.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. حفظ العرض التقديمي على القرص.
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
        //ضبط حجم خط النص إلى 10
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//حفظ العرض التقديمي على القرص
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **مثال Aspose.Slides for .NET**
الخطوات التالية تضيف جدولاً إلى شريحة Microsoft PowerPoint باستخدام Aspose.Slides:

1. إنشاء عرض تقديمي.
1. إضافة جدول بحجم 15 × 15 إلى الشريحة الأولى.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. كتابة العرض التقديمي على القرص.
```c#
Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

//تحديد الأعمدة بعروضها والصفوف بارتفاعاتها
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//إضافة جدول
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//تعيين تنسيق الحدود لكل خلية
foreach (IRow row in tbl.Rows)
{
		foreach (ICell cell in row)
		{

				//الحصول على إطار النص لكل خلية
				ITextFrame tf = cell.TextFrame;
				//إضافة بعض النص
				tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
				//ضبط حجم الخط إلى 10
				tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
				tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
		}
}

//حفظ العرض التقديمي على القرص
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```
