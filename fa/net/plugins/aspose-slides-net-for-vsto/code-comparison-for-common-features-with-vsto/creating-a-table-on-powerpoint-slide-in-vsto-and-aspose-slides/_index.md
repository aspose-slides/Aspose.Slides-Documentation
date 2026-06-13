---
title: ایجاد جدول در اسلاید PowerPoint با VSTO و Aspose.Slides
type: docs
weight: 90
url: /fa/net/creating-a-table-on-powerpoint-slide-in-vsto-and-aspose-slides/
---
مراحل زیر یک جدول را به یک اسلاید Microsoft PowerPoint با استفاده از VSTO اضافه می‌کنند:

- یک ارائه ایجاد کنید.
- یک اسلاید خالی به ارائه اضافه می‌شود.
- یک جدول 15 × 15 به اسلاید اضافه کنید.
- متن را با اندازه قلم 10 به هر سلول جدول اضافه کنید.
- ارائه را روی دیسک ذخیره کنید.

## **VSTO**
``` csharp

 //ایجاد یک ارائه

PowerPoint.Presentation pres = Globals.ThisAddIn.Application

			  .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//اضافه کردن یک اسلاید خالی

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//اضافه کردن یک جدول 15 x 15

PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);

PowerPoint.Table tbl = shp.Table;

int i = -1;

int j = -1;

//حلقه در تمام ردیف‌ها

foreach (PowerPoint.Row row in tbl.Rows)

{

	i = i + 1;

	j = -1;

	//حلقه در تمام سلول‌های ردیف

	foreach (PowerPoint.Cell cell in row.Cells)

	{

		j = j + 1;

		//دریافت قاب متن هر سلول

		PowerPoint.TextFrame tf = cell.Shape.TextFrame;

		//اضافه کردن متن

		tf.TextRange.Text = "T" + i.ToString() + j.ToString();

		//تنظیم اندازه قلم متن به 10

		tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;

	}

}

//ذخیره ارائه روی دیسک

pres.SaveAs("tblVSTO.ppt",

	  PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

	  Microsoft.Office.Core.MsoTriState.msoFalse);

``` 

مراحل زیر یک جدول را به یک اسلاید Microsoft PowerPoint با استفاده از Aspose.Slides اضافه می‌کنند:

- یک ارائه ایجاد کنید.
- یک جدول 15 × 15 به اولین اسلاید اضافه کنید.
- متن را با اندازه قلم 10 به هر سلول جدول اضافه کنید.
- ارائه را روی دیسک بنویسید.

## **Aspose.Slides**
``` csharp

 //ایجاد یک ارائه
Presentation pres = new Presentation();

//دسترسی به اولین اسلاید
Slide sld = pres.GetSlideByPosition(1);

//اضافه کردن یک جدول
Aspose.Slides.Table tbl = sld.Shapes.AddTable(50, 50, pres.SlideSize.Width - 100, pres.SlideSize.Height - 100, 15, 15);

//حلقه در تمام ردیف‌ها
for (int i = 0; i < tbl.RowsNumber; i++)
	//حلقه در تمام سلول‌ها
	for (int j = 0; j < tbl.ColumnsNumber; j++)
	{
		//دریافت قاب متن هر سلول
		TextFrame tf = tbl.GetCell(j, i).TextFrame;
		//اضافه کردن متن
		tf.Text = "T" + i.ToString() + j.ToString();
		//تنظیم اندازه قلم به 10
		tf.Paragraphs[0].Portions[0].FontHeight = 10;
		tf.Paragraphs[0].HasBullet = false;
	}

//نوشتن ارائه روی دیسک
pres.Write("tblSLD.ppt");
``` 
## **دانلود کد نمونه**
- [گیت‌هاب](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Creating.a.Table.on.PowerPoint.Slide.Aspose.Slides.zip)
- [سورس‌فرج](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide%20%28Aspose.Slides%29.zip/download)
- [بیت‌باكت](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Creating%20a%20Table%20on%20PowerPoint%20Slide/)