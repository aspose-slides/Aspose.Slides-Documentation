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
- خودکارسازی آفیس
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از خودکارسازی Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و جداول را در اسلایدهای PowerPoint (PPT، PPTX) با C# و قالب‌بندی قابل انعطاف ایجاد کنید."
---
{{% alert color="primary" %}} 

جداول به‌طور گسترده برای نمایش داده‌ها در اسلایدهای ارائه استفاده می‌شوند. این مقاله نشان می‌دهد چگونه به‌صورت برنامه‌نویسی یک جدول 15×15 با اندازه قلم 10 را ابتدا با استفاده از [VSTO 2008](/slides/fa/net/creating-a-table-on-powerpoint-slide/) و سپس با [Aspose.Slides for .NET](/slides/fa/net/creating-a-table-on-powerpoint-slide/) ایجاد کنید.

{{% /alert %}} 
## **ایجاد جداول**
#### **مثال VSTO 2008**
مراحل زیر یک جدول به اسلاید Microsoft PowerPoint با استفاده از VSTO اضافه می‌کند:

1. یک ارائه ایجاد کنید.
2. یک اسلاید خالی به ارائه اضافه می‌شود.
3. یک جدول 15×15 به اسلاید اضافه کنید.
4. متن را به هر سلول جدول با اندازه قلم 10 اضافه کنید.
5. ارائه را بر روی دیسک ذخیره کنید.

```c#
//یک ارائه ایجاد کنید
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
              .Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);
//یک اسلاید خالی اضافه کنید
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//یک جدول 15×15 اضافه کنید
PowerPoint.Shape shp = sld.Shapes.AddTable(15, 15, 10, 10, pres.PageSetup.SlideWidth - 20, 300);
PowerPoint.Table tbl = shp.Table;
int i = -1;
int j = -1;

//از تمام ردیف‌ها عبور کنید
foreach (PowerPoint.Row row in tbl.Rows)
{
    i = i + 1;
    j = -1;

    //از تمام سلول‌های ردیف عبور کنید
    foreach (PowerPoint.Cell cell in row.Cells)
    {
        j = j + 1;
        //قاب متن هر سلول را دریافت کنید
        PowerPoint.TextFrame tf = cell.Shape.TextFrame;
        //متنی اضافه کنید
        tf.TextRange.Text = "T" + i.ToString() + j.ToString();
        //اندازه قلم متن را 10 تنظیم کنید
        tf.TextRange.Paragraphs(0, tf.TextRange.Text.Length).Font.Size = 10;
    }
}

//ارائه را بر روی دیسک ذخیره کنید
pres.SaveAs("d:\\tblVSTO.ppt",
      PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
      Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **مثال Aspose.Slides for .NET**
مراحل زیر یک جدول به اسلاید Microsoft PowerPoint با استفاده از Aspose.Slides اضافه می‌کند:

1. یک ارائه ایجاد کنید.
2. یک جدول 15×15 به اولین اسلاید اضافه کنید.
3. متن را به هر سلول جدول با اندازه قلم 10 اضافه کنید.
4. ارائه را بر روی دیسک ذخیره کنید.

```c#
Presentation pres = new Presentation();

//دسترسی به اولین اسلاید
ISlide sld = pres.Slides[0];

//تعریف ستون‌ها با عرض‌ها و ردیف‌ها با ارتفاع‌ها
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

//یک جدول اضافه کنید
Aspose.Slides.ITable tbl = sld.Shapes.AddTable(50, 50, dblCols, dblRows);

//تنظیم قالب حاشیه برای هر سلول
foreach (IRow row in tbl.Rows)
{
	foreach (ICell cell in row)
	{

		//دریافت قاب متن هر سلول
		ITextFrame tf = cell.TextFrame;
		//متنی اضافه کنید
		tf.Text = "T" + cell.FirstRowIndex.ToString() + cell.FirstColumnIndex.ToString();
		//تنظیم اندازه قلم به 10
		tf.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 10;
		tf.Paragraphs[0].ParagraphFormat.Bullet.Type = BulletType.None;
	}
}

//نوشتن ارائه به دیسک
pres.Save("C:\\data\\tblSLD.ppt", SaveFormat.Ppt);
```