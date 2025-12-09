---
title: إضافة نص بشكل ديناميكي باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إضافة نص بشكل ديناميكي
type: docs
weight: 20
url: /ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- إضافة نص
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "شاهد كيفية الانتقال من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإضافة نص ديناميكي إلى عروض PowerPoint (PPT, PPTX) باستخدام C#."
---

{{% alert color="primary" %}} 

مهمة شائعة يقوم المطورون بتنفيذها هي إضافة نص إلى الشرائح بشكل ديناميكي. تُظهر هذه المقالة أمثلة على الشيفرة لإضافة النص بشكل ديناميكي باستخدام [VSTO](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) و [Aspose.Slides for .NET](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **إضافة نص بشكل ديناميكي**
يتبع الطريقتان الخطوات التالية:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة صندوق نص.
1. تعيين بعض النص.
1. كتابة العرض التقديمي.
## **مثال كود VSTO**
تؤدي مقتطفات الشيفرة أدناه إلى إنشاء عرض تقديمي يحتوي على شريحة بسيطة وسلسلة نصية عليها.

**العرض التقديمي كما تم إنشاؤه في VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//ملاحظة: PowerPoint هي مساحة أسماء تم تعريفها أعلاه بهذه الطريقة
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//إنشاء عرض تقديمي
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//الحصول على تخطيط الشريحة الفارغ
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[7];

//إضافة شريحة فارغة
PowerPoint.Slide sld = pres.Slides.AddSlide(1, layout);

//إضافة نص
PowerPoint.Shape shp = sld.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 100, 400, 100);

//تعيين نص
PowerPoint.TextRange txtRange = shp.TextFrame.TextRange;
txtRange.Text = "Text added dynamically";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//كتابة الإخراج إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```




## **مثال Aspose.Slides for .NET**
تستخدم مقتطفات الشيفرة أدناه Aspose.Slides لإنشاء عرض تقديمي يحتوي على شريحة بسيطة وسلسلة نصية عليها.

**العرض التقديمي كما تم إنشاؤه باستخدام Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//Blank slide is added by default, when you create
//presentation from default constructor
//So, we don't need to add any blank slide
ISlide sld = pres.Slides[1];

//إضافة مربع نص
//لإضافته، سنضيف أولاً مستطيلًا
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//إخفاء حدّه
shp.LineFormat.Style = LineStyle.NotDefined;

//ثم إضافة إطار نص داخلها
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//تعيين نص
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//كتابة الإخراج إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
