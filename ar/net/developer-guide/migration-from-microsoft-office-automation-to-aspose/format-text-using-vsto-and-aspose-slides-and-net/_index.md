---
title: تنسيق النص باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: تنسيق النص
type: docs
weight: 30
url: /ar/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- تنسيق النص
- الهجرة
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وتنسيق النص في عروض PowerPoint (PPT, PPTX) بدقة تحكم."
---
{{% alert color="info" %}} 

أحيانًا، تحتاج إلى تنسيق النص على الشرائح برمجيًا. توضح هذه المقالة كيفية قراءة عرض تقديمي نموذجّي يحتوي على نص في الشريحة الأولى باستخدام إما [VSTO](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/) و[Aspose.Slides for .NET](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/). يقوم الكود بتنسيق النص في صندوق النص الثالث في الشريحة ليظهر مثل النص في صندوق النص الأخير.

{{% /alert %}} 
## **تنسيق النص**
كل من طريقتي VSTO وAspose.Slides تتبع الخطوات التالية:

1. فتح عرض التقديم المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى صندوق النص الثالث.
1. تغيير تنسيق النص في صندوق النص الثالث.
1. حفظ العرض التقديمي على القرص.

تُظهر لقطات الشاشة أدناه الشريحة النموذجيّة قبل وبعد تنفيذ كود VSTO وAspose.Slides for .NET.

**العرض التقديمي الإدخالي** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **مثال كود VSTO**
يُظهر الكود أدناه كيفية إعادة تنسيق النص على شريحة باستخدام VSTO.

**النص المُعاد تنسيقه باستخدام VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//ملاحظة: PowerPoint هو مساحة أسماء تم تعريفها أعلاه بهذا الشكل
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
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**العرض التقديمي الناتج الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

 //فتح العرض التقديمي
Presentation pres = new Presentation("source.ppt");

//الوصول إلى الشريحة الأولى
ISlide slide = pres.Slides[0];

//الوصول إلى الشكل الثالث
IShape shp = slide.Shapes[2];

//تغيير خط النص إلى Verdana والارتفاع إلى 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//اجعله عريضًا
port.PortionFormat.FontBold = NullableBool.True;

//اجعله مائلًا
port.PortionFormat.FontItalic = NullableBool.True;

//تغيير لون النص
//تعيين لون الخط
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//تغيير لون خلفية الشكل
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//كتابة الإخراج إلى القرص
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```