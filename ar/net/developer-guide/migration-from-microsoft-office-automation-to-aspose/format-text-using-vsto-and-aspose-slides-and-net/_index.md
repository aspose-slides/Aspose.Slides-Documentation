---
title: تنسيق النص باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: تنسيق النص
type: docs
weight: 30
url: /ar/net/format-text-using-vsto-and-aspose-slides-and-net/
keywords:
- تنسيق النص
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وتنسيق النص في عروض PowerPoint (PPT, PPTX) بدقة التحكم."
---

{{% alert color="primary" %}} 

في بعض الأحيان، تحتاج إلى تنسيق النص على الشرائح برمجياً. يوضح هذا المقال كيفية قراءة عرض تقديمي تجريبي يحتوي على بعض النص في الشريحة الأولى باستخدام إما VSTO أو Aspose.Slides for .NET. يقوم الكود بتنسيق النص في الصندوق النصي الثالث على الشريحة ليصبح مثل النص في الصندوق النصي الأخير.

{{% /alert %}} 
## **تنسيق النص**
كل من طريقتي VSTO و Aspose.Slides تتبع الخطوات التالية:

1. فتح عرض التقديمية المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى الصندوق النصي الثالث.
1. تغيير تنسيق النص في الصندوق النصي الثالث.
1. حفظ العرض التقديمي على القرص.

تظهر لقطات الشاشة أدناه الشريحة التجريبية قبل وبعد تنفيذ كود VSTO و Aspose.Slides for .NET.

**عرض التقديمي الإدخالي** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **مثال كود VSTO**
يعرض الكود أدناه كيفية إعادة تنسيق النص على شريحة باستخدام VSTO.

**النص المعاد تنسيقه باستخدام VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)
```c#
//ملاحظة: PowerPoint هو مساحة اسم تم تعريفها أعلاه بهذا الشكل
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

//إعادة وضعه أفقيًا
shp.Left -= 70;

//كتابة المخرجات إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```





### **مثال Aspose.Slides for .NET**
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**عرض التقديمي الناتج الذي تم إنشاؤه باستخدام Aspose.Slides** 

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

//اجعل الخط عريضًا
port.PortionFormat.FontBold = NullableBool.True;

//اجعل الخط مائلاً
port.PortionFormat.FontItalic = NullableBool.True;

//تغيير لون النص
//ضبط لون الخط
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//تغيير لون خلفية الشكل
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//كتابة النتيجة إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
