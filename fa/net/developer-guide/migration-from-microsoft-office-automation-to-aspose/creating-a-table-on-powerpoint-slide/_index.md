---
title: ایجاد جداول با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: ایجاد جداول
type: docs
weight: 50
url: /fa/net/creating-a-table-on-powerpoint-slide/
keywords:
- ایجاد جدول
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و جداول را در اسلایدهای PowerPoint (PPT، PPTX) با C# و قالب‌بندی انعطاف‌پذیر ایجاد کنید."
---
{{% alert color="info" %}} 

جداول به طور گسترده برای نمایش داده‌ها در اسلایدهای ارائه استفاده می‌شوند. این مقاله نشان می‌دهد که چگونه به‌صورت برنامه‌نویسی یک جدول 15×15 با اندازهٔ قلم 10 را ابتدا با [VSTO 2008](/slides/fa/net/creating-a-table-on-powerpoint-slide/) و سپس با [Aspose.Slides for .NET](/slides/fa/net/creating-a-table-on-powerpoint-slide/) ایجاد کنید.

{{% /alert %}} 
## **ایجاد جداول**
#### **مثال VSTO 2008**
مراحل زیر یک جدول را به یک اسلاید Microsoft PowerPoint با استفاده از VSTO اضافه می‌کند:

1. یک ارائه ایجاد کنید.
1. یک اسلاید خالی به ارائه اضافه کنید.
1. یک جدول 15×15 به اسلاید اضافه کنید.
1. متن با اندازهٔ قلم 10 را به هر سلول جدول اضافه کنید.
1. ارائه را روی دیسک ذخیره کنید.

```c#
 //Create a presentation
//یک ارائه ایجاد کنید
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//Add a blank slide
//یک اسلاید خالی اضافه کنید
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

 //Add a 15 x 15 table
//یک جدول 15×15 اضافه کنید
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

 //Loop through all the rows
//در تمام ردیف‌ها حلقه بزنید
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //Loop through all the cells in the row
    //در تمام سلول‌های ردیف حلقه بزنید
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //Get text frame of each cell
        //قاب متن هر سلول را دریافت کنید
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //Add some text
        //متن اضافه کنید
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //Set font size of the text as 10
        //اندازه قلم متن را به 10 تنظیم کنید
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//Save the presentation to disk
//ارائه را روی دیسک ذخیره کنید
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **مثال Aspose.Slides برای .NET**
مراحل زیر یک جدول را به یک اسلاید Microsoft PowerPoint با استفاده از Aspose.Slides اضافه می‌کند:

1. یک ارائه ایجاد کنید.
1. یک جدول 15×15 به اولین اسلاید اضافه کنید.
1. متن با اندازهٔ قلم 10 را به هر سلول جدول اضافه کنید.
1. ارائه را روی دیسک بنویسید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

//Access first slide
//دسترسی به اولین اسلاید
ISlide sld = pres.Slides[0];

//Define columns with widths and rows with heights
//تعریف ستون‌ها با عرض و ردیف‌ها با ارتفاع
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//Add a table
//یک جدول اضافه کنید
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//Set border format for each cell
//تنظیم قالب حاشیه برای هر سلول
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//Get text frame of each cell
		//دریافت قاب متن هر سلول
		ITextFrame tf = cell.TextFrame;
		//Add some text
		//متن اضافه کنید
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//Set font size of 10
		//تنظیم اندازه قلم به 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//Write the presentation to the disk
pres.Save("tblSLD.ppt", SaveFormat.Ppt);
```