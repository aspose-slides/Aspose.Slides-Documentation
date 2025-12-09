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
description: "الهجرة من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وتنسيق النص في عروض PowerPoint (PPT, PPTX) بدقة تحكم."
---

{{% alert color="primary" %}} 

في بعض الأحيان، تحتاج إلى تنسيق النص على الشرائح برمجيًا. يوضح هذه المقالة كيفية قراءة عرض تقديمي تجريبي يحتوي على بعض النص في الشريحة الأولى باستخدام إما [VSTO](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/) و[Aspose.Slides for .NET](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/). يقوم الكود بتنسيق النص في مربع النص الثالث على الشريحة ليظهر مثل النص في مربع النص الأخير.

{{% /alert %}} 
## **تنسيق النص**
تتبع كل من طرق VSTO وAspose.Slides الخطوات التالية:

1. افتح العرض التقديمي المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى مربع النص الثالث.
1. غيّر تنسيق النص في مربع النص الثالث.
1. احفظ العرض التقديمي إلى القرص.

تُظهر لقطات الشاشة أدناه الشريحة النموذجية قبل وبعد تنفيذ كود VSTO وAspose.Slides for .NET.

**العرض التقديمي الإدخالي** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **مثال على كود VSTO**
يعرض الكود أدناه كيفية إعادة تنسيق النص على شريحة باستخدام VSTO.

**النص المُعاد تنسيقه باستخدام VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//ملاحظة: PowerPoint هو مساحة اسم تم تعريفها أعلاه كما يلي
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;
PowerPoint.Presentation pres = null;

//فتح العرض التقديمي
pres = Globals.ThisAddIn.Application.Presentations.Open("c:\\source.ppt",
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoFalse,
	Microsoft.Office.Core.MsoTriState.msoTrue);

//الوصول إلى الشريحة الأولى
PowerPoint.Slide slide = pres.Slides[1];

//الوصول إلى الشكل الثالث
PowerPoint.Shape shp = slide.Shapes[3];

//تغيير خط النص إلى Verdana والارتفاع إلى 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//تطبيق الخط العريض
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//تطبيق الخط المائل
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//تغيير لون النص
txtRange.Font.Color.RGB = 0x00CC3333;

//تغيير لون خلفية الشكل
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//إعادة وضعه أفقياً
shp.Left -= 70;

//كتابة الناتج إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **مثال على Aspose.Slides for .NET**
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**عرض التقديمي الناتج المُنشأ باستخدام Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)
```c#
 //فتح العرض التقديمي
Presentation pres = new Presentation("c:\\source.ppt");

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

//تطبيق الخط العريض
port.PortionFormat.FontBold = NullableBool.True;

//تطبيق الخط المائل
port.PortionFormat.FontItalic = NullableBool.True;

//تغيير لون النص
//تعيين لون الخط
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//تغيير لون خلفية الشكل
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//كتابة الناتج إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
