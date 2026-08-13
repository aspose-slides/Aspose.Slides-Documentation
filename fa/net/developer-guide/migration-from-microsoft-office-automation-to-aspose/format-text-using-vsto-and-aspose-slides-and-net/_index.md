---
title: قالب‌بندی متن با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: قالب‌بندی متن
type: docs
weight: 30
url: /fa/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- قالب‌بندی متن
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و متن را در ارائه‌های PowerPoint (PPT، PPTX) با کنترل دقیق قالب‌بندی کنید."
---
{{% alert color="info" %}} 

گاهی اوقات، لازم است متن اسلایدها را به‌صورت برنامه‌نویسی قالب‌بندی کنید. این مقاله نشان می‌دهد که چگونه یک ارائه نمونه حاوی متنی در اسلاید اول را با استفاده از [VSTO](/slides/fa/net/format-text-using-vsto-and-aspose-slides-and-net/) و [Aspose.Slides for .NET](/slides/fa/net/format-text-using-vsto-and-aspose-slides-and-net/) بخوانید. کد متن در جعبه متن سوم اسلاید را طوری قالب‌بندی می‌کند که شبیه متن در جعبه متن آخر شود.

{{% /alert %}} 
## **قالب‌بندی متن**
هر دو روش VSTO و Aspose.Slides مراحل زیر را انجام می‌دهند:

1. ارائه منبع را باز کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. به جعبه متن سوم دسترسی پیدا کنید.
1. قالب‌بندی متن در جعبه متن سوم را تغییر دهید.
1. ارائه را روی دیسک ذخیره کنید.

تصاویر زیر اسلاید نمونه را قبل و بعد از اجرای کد VSTO و Aspose.Slides for .NET نشان می‌دهند.

**ارائه ورودی** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **مثال کد VSTO**
کد زیر نشان می‌دهد که چگونه متن در یک اسلاید را با استفاده از VSTO دوباره قالب‌بندی کنید.

**متنی که با VSTO قالب‌بندی شده است** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
 //نکته: PowerPoint یک فضای نام است که در بالا به این شکل تعریف شده است
 //using PowerPoint = Microsoft.Office.Interop.PowerPoint;
 PowerPoint.Presentation pres = null;

 //Open the presentation
 pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
 	Microsoft.Office.Core.MsoTriState.msoFalse,
 	Microsoft.Office.Core.MsoTriState.msoFalse,
 	Microsoft.Office.Core.MsoTriState.msoTrue);

 //Access the first slide
 PowerPoint.Slide slide = pres.Slides[1];

 //Access the third shape
 PowerPoint.Shape shp = slide.Shapes[3];

 //Change its text's font to Verdana and height to 32
 PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
 txtRange.Font.Name = "Verdana";
 txtRange.Font.Size = 32;

 //Bolden it
 txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

 //Italicize it
 txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

 //Change text color
 txtRange.Font.Color.RGB = 0x00CC3333;

 //Change shape background color
 shp.Fill.ForeColor.RGB = 0x00FFCCCC;

 //Reposition it horizontally
 shp.Left -= 70;

 //Write the output to disk
 pres.SaveAs("c:\\outVSTO.ppt",
 	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
 	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **مثال Aspose.Slides for .NET**
برای قالب‌بندی متن با Aspose.Slides، قبل از قالب‌بندی متن، فونت را اضافه کنید.

**ارائه خروجی ایجاد شده با Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //باز کردن ارائه
Presentation pres = new Presentation("source.ppt");

//دسترسی به اسلاید اول
ISlide slide = pres.Slides[0];

//دسترسی به شکل سوم
IShape shp = slide.Shapes[2];

//فونت متن را به Verdana و ارتفاع را به 32 تغییر دهید
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//متن را بولد کنید
port.PortionFormat.FontBold = NullableBool.True;

//متن را ایتالیک کنید
port.PortionFormat.FontItalic = NullableBool.True;

//تغییر رنگ متن
//تنظیم رنگ فونت
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//تغییر رنگ پس‌زمینه شکل
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//نوشتن خروجی بر روی دیسک
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```