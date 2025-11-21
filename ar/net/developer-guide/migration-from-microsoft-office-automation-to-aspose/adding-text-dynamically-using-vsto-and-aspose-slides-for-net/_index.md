---
title: إضافة نص ديناميكياً باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إضافة نص ديناميكياً
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
description: "شاهد كيفية الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإضافة نص ديناميكي إلى عروض PowerPoint (PPT, PPTX) باستخدام C#."
---

{{% alert color="primary" %}} 

مهمة شائعة يقوم بها المطوّرون هي إضافة نص إلى الشرائح بشكل ديناميكي. توضح هذه المقالة أمثلة على الشيفرة لإضافة النص ديناميكياً باستخدام [VSTO](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) و[Aspose.Slides for .NET](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **إضافة نص ديناميكياً**
تتبع كلتا الطريقتين الخطوات التالية:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة مربع نص.
1. تعيين بعض النصوص.
1. كتابة العرض التقديمي.
## **مثال على شفرة VSTO**
القطعات البرمجية أدناه تنتج عرضًا تقديميًا يحتوي على شريحة بسيطة وسلسلة نصية عليها.

**العرض التقديمي كما تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)
```c#
//ملحوظة: PowerPoint هو مساحة أسماء تم تعريفها أعلاه بهذه الطريقة
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//إنشاء عرض تقديمي
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




## **مثال على Aspose.Slides لـ .NET**
القطعات البرمجية أدناه تستخدم Aspose.Slides لإنشاء عرض تقديمي يحتوي على شريحة بسيطة وسلسلة نصية عليها.

**العرض التقديمي كما تم إنشاؤه باستخدام Aspose.Slides لـ .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)
```c#
//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//الشريحة الفارغة يتم إضافتها بشكل افتراضي عند الإنشاء
//العرض من المشيد الافتراضي
//لذلك، لا نحتاج إلى إضافة أي شريحة فارغة
ISlide sld = pres.Slides[1];

//إضافة مربع نص
//لإضافته، سنضيف أولاً مستطيلاً
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//إخفاء الخط الخاص به
shp.LineFormat.Style = LineStyle.NotDefined;

//ثم إضافة إطار نص داخلها
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//تعيين نص
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//كتابة المخرجات إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```
