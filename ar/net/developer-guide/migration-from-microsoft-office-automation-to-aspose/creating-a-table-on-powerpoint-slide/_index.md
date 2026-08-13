---
title: إنشاء جداول باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إنشاء جداول
type: docs
weight: 50
url: /ar/net/creating-a-table-on-powerpoint-slide/
keywords:
- إنشاء جدول
- الهجرة
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الهجرة من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإنشاء جداول في شرائح PowerPoint (PPT, PPTX) باستخدام C# مع تنسيق مرن."
---
{{% alert color="info" %}} 

تُستخدم الجداول على نطاق واسع لعرض البيانات في شرائح العرض التقديمي. توضح هذه المقالة كيفية إنشاء جدول 15 × 15 بحجم خط 10 برمجيًا باستخدام أولاً [VSTO 2008](/slides/ar/net/creating-a-table-on-powerpoint-slide/) ثم [Aspose.Slides for .NET](/slides/ar/net/creating-a-table-on-powerpoint-slide/).

{{% /alert %}} 
## **إنشاء الجداول**
#### **مثال VSTO 2008**
الخطوات التالية تضيف جدولًا إلى شريحة Microsoft PowerPoint باستخدام VSTO:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة إلى العرض التقديمي.
1. إضافة جدول 15 × 15 إلى الشريحة.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. حفظ العرض التقديمي على القرص.

```c#
 //Create a presentation
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application
               .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
 //Add a blank slide
 PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

 //Add a 15 x 15 table
 PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
 PowerPoint.Table tbl = shp.Table;
 int i = -1;
 int j = -1;

 //Loop through all the rows
 foreach (PowerPoint.Row row in tbl.Rows)
 {
     i = i + 1;
     j = -1;

     //Loop through all the cells in the row
     foreach (PowerPoint.Cell cell in row.Cells)
     {
         j = j + 1;
         //Get text frame of each cell
         PowerPoint.TextFrame tf = cell.Shape.TextFrame;
         //Add some text
         tf.TextRange.Text = "T" + i.ToString() + j.ToString();
         //Set font size of the text as 10
         tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
     }
 }

 //Save the presentation to disk
 pres.SaveAs("d:\\tblVSTO.ppt",
       PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
       Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **مثال Aspose.Slides لـ .NET**
الخطوات التالية تضيف جدولًا إلى شريحة Microsoft PowerPoint باستخدام Aspose.Slides:

1. إنشاء عرض تقديمي.
1. إضافة جدول 15 × 15 إلى الشريحة الأولى.
1. إضافة نص إلى كل خلية في الجدول بحجم خط 10.
1. كتابة العرض التقديمي على القرص.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى
ISlide sld = pres.Slides[0];

//تحديد الأعمدة بالعروض والصفوف بالارتفاعات
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//إضافة جدول
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//تحديد تنسيق الحدود لكل خلية
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//الحصول على إطار النص لكل خلية
		ITextFrame tf = cell.TextFrame;
		//إضافة نص
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//تحديد حجم الخط إلى 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//كتابة العرض التقديمي إلى القرص
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```