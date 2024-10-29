---
title: تنسيق النص باستخدام VSTO وAspose.Slides و.NET
type: docs
weight: 30
url: /ar/net/format-text-using-vsto-and-aspose-slides-and-net/
---

{{% alert color="primary" %}} 

في بعض الأحيان، تحتاج إلى تنسيق النص على الشرائح برمجيًا. يوضح هذا المقال كيفية قراءة عرض تقديمي نموذجي يحتوي على نص في الشريحة الأولى باستخدام [VSTO](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/) و[Aspose.Slides for .NET](/slides/ar/net/format-text-using-vsto-and-aspose-slides-and-net/). يقوم الكود بتنسيق النص في مربع النص الثالث على الشريحة ليبدو مثل النص في مربع النص الأخير.

{{% /alert %}} 
## **تنسيق النص**
تتضمن الطرق المستخدمة في VSTO وAspose.Slides الخطوات التالية:

1. فتح العرض التقديمي المصدر.
1. الوصول إلى الشريحة الأولى.
1. الوصول إلى مربع النص الثالث.
1. تغيير تنسيق النص في مربع النص الثالث.
1. حفظ العرض التقديمي على القرص.

تظهر لقطات الشاشة أدناه الشريحة النموذجية قبل وبعد تنفيذ كود VSTO وAspose.Slides for .NET.

**العرض التقديمي المدخل** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_1.png)
### **مثال على كود VSTO**
يوضح الكود أدناه كيفية إعادة تنسيق النص على الشريحة باستخدام VSTO.

**النص المعاد تنسيقه مع VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_2.png)



```c#
//ملاحظة: PowerPoint هو مساحة اسم محددة أعلاه بهذه الطريقة
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

//تغيير خط نصه إلى Verdana وارتفاعه إلى 32
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Font.Name = "Verdana";
txtRange.Font.Size = 32;

//جعل النص عريضًا
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoCTrue;

//جعل النص مائلًا
txtRange.Font.Italic = Microsoft.Office.Core.MsoTriState.msoCTrue;

//تغيير لون النص
txtRange.Font.Color.RGB = 0x00CC3333;

//تغيير لون خلفية الشكل
shp.Fill.ForeColor.RGB = 0x00FFCCCC;

//إعادة تو positioning أفقيًا
shp.Left -= 70;

//كتابة الإخراج إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




### **مثال على Aspose.Slides for .NET**
لتنسيق النص باستخدام Aspose.Slides، أضف الخط قبل تنسيق النص.

**العرض التقديمي الناتج الذي تم إنشاؤه مع Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-and-net_3.png)



```c#
 //فتح العرض التقديمي
Presentation pres = new Presentation("c:\\source.ppt");

//الوصول إلى الشريحة الأولى
ISlide slide = pres.Slides[0];

//الوصول إلى الشكل الثالث
IShape shp = slide.Shapes[2];

//تغيير خط نصه إلى Verdana وارتفاعه إلى 32
ITextFrame tf = ((IAutoShape)shp).TextFrame;
IParagraph para = tf.Paragraphs[0];
IPortion port = para.Portions[0];
port.PortionFormat.LatinFont = new FontData("Verdana");

port.PortionFormat.FontHeight = 32;

//جعل النص عريضًا
port.PortionFormat.FontBold = NullableBool.True;

//جعل النص مائلًا
port.PortionFormat.FontItalic = NullableBool.True;

//تغيير لون النص
//تعيين لون الخط
port.PortionFormat.FillFormat.FillType = FillType.Solid;
port.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(0x33, 0x33, 0xCC);

//تغيير لون خلفية الشكل
shp.FillFormat.FillType = FillType.Solid;
shp.FillFormat.SolidFillColor.Color = Color.FromArgb(0xCC, 0xCC, 0xFF);

//كتابة الإخراج إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```