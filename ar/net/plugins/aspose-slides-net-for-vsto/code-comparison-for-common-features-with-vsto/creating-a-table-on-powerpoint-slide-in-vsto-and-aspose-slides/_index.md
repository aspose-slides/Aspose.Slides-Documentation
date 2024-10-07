---
title: إنشاء جدول على شريحة PowerPoint في VSTO و Aspose.Slides
type: docs
weight: 90
url: /net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---

تضيف الخطوات التالية جدولاً إلى شريحة Microsoft PowerPoint باستخدام VSTO:

- إنشاء عرض تقديمي.
- إضافة شريحة فارغة إلى العرض التقديمي.
- إضافة جدول 15 × 15 إلى الشريحة.
- إضافة نص إلى كل خلية في الجدول بحجم خط 10.
- حفظ العرض التقديمي على القرص.
## **VSTO**
``` csharp

 //إنشاء عرض تقديمي

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//إضافة شريحة فارغة

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//إضافة جدول 15 × 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//تكرار عبر جميع الصفوف

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//تكرار عبر جميع الخلايا في الصف

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//الحصول على إطار النص لكل خلية

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//إضافة بعض النصوص

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//تعيين حجم الخط للنص إلى 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//حفظ العرض التقديمي على القرص

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

تضيف الخطوات التالية جدولاً إلى شريحة Microsoft PowerPoint باستخدام Aspose.Slides:

- إنشاء عرض تقديمي.
- إضافة جدول 15 × 15 إلى الشريحة الأولى.
- إضافة نص إلى كل خلية في الجدول بحجم خط 10.
- كتابة العرض التقديمي على القرص.
## **Aspose.Slides**
``` csharp

 //إنشاء عرض تقديمي

Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى

Slide sld = pres.GetSlideByPosition(1);

//إضافة جدول

Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//تكرار عبر الصفوف

for (int i = 0; i < tbl.RowsNumber; i++)

	//تكرار عبر الخلايا

	for (int j = 0; j < tbl.ColumnsNumber; j++)

	{

		//الحصول على إطار النص لكل خلية

		TextFrame tf = tbl.GetCell(j, i).TextFrame;

		//إضافة بعض النصوص

		tf.Text = "T" + i.ToString() + j.ToString();

		//تعيين حجم الخط إلى 10

		tf.Paragraphs[0].Portions[0].FontHeight = 10;

		tf.Paragraphs[0].HasBullet = false;

	}

//كتابة العرض التقديمي على القرص

pres.Write("tblSLD.ppt");

``` 
## **تنزيل نموذج التعليمات البرمجية**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772951)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Creating%20a%20Table%20on%20PowerPoint%20Slide%20\(Aspose.Slides\).zip)