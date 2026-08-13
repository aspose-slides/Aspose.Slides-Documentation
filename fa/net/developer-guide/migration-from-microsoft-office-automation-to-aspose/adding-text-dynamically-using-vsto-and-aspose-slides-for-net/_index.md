---
title: افزودن متن به‌صورت پویا با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: افزودن متن به‌صورت پویا
type: docs
weight: 20
url: /fa/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- افزودن متن
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "نحوه مهاجرت از اتوماسیون Microsoft Office به Aspose.Slides برای .NET و افزودن متن پویا به ارائه‌های PowerPoint (PPT، PPTX) را در C# ببینید."
---
{{% alert color="info" %}} 
یک کار رایج که توسعه‌دهندگان برای انجام آن تلاش می‌کنند، افزودن متن به اسلایدها به‌صورت پویا است. این مقاله مثال‌های کد برای افزودن متن به‌صورت پویا با استفاده از [VSTO](/slides/fa/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) و [Aspose.Slides for .NET](/slides/fa/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) نشان می‌دهد.
{{% /alert %}} 
## **افزودن متن به‌صورت پویا**
هر دو روش مراحل زیر را دنبال می‌کنند:

1. یک ارائه ایجاد کنید.
1. یک اسلاید خالی اضافه کنید.
1. یک جعبه متن اضافه کنید.
1. متنی تنظیم کنید.
1. ارائه را بنویسید.
## **مثال کد VSTO**
کدهای زیر یک ارائه با یک اسلاید ساده و یک رشته متن روی آن تولید می‌کنند.

**ارائه‌ای که در VSTO ایجاد شده است** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//نکته: PowerPoint یک namespace است که در بالا به این شکل تعریف شده است
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Create a presentation
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the blank slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//Add a text
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//Set a text
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **مثال Aspose.Slides برای .NET**
کدهای زیر از Aspose.Slides برای ایجاد یک ارائه با یک اسلاید ساده و یک رشته متن استفاده می‌کنند.

**ارائه‌ای که با استفاده از Aspose.Slides برای .NET ایجاد شده است** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//ایجاد یک ارائه
Presentation pres = new Presentation();

//اسلاید خالی به‌صورت پیش‌فرض اضافه می‌شود، وقتی شما ایجاد می‌کنید
//ارائه از سازنده پیش‌فرض
//بنابراین، نیازی به اضافه کردن اسلاید خالی نداریم
ISlide sld = pres.Slides[1];

//افزودن یک جعبه متن
//برای افزودن آن، ابتدا یک مستطیل اضافه می‌کنیم
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//پنهان کردن خط آن
shp.LineFormat.Style = LineStyle.NotDefined;

//سپس یک فریم متن داخل آن اضافه می‌کنیم
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//تنظیم متن
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//Write the output to disk
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```