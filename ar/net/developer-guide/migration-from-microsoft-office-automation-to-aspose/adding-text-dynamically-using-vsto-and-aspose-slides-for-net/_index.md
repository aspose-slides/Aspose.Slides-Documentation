---
title: إضافة نص ديناميكياً باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إضافة نص ديناميكياً
type: docs
weight: 20
url: /ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
keywords:
- إضافة نص
- الترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإضافة نص ديناميكي إلى عروض PowerPoint (PPT، PPTX) باستخدام C#."
---
{{% alert color="info" %}} 

مهمة شائعة يقوم المطورون بتنفيذها هي إضافة النص إلى الشرائح بشكل ديناميكي. يوضح هذا المقال أمثلة شفرة لإضافة النص ديناميكياً باستخدام [VSTO](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) و[Aspose.Slides for .NET](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **إضافة النص ديناميكياً**
Both methods follow these steps:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة مربع نص.
1. تعيين بعض النص.
1. كتابة العرض التقديمي.
## **مثال كود VSTO**
The code snippets below results in a presentation with a plain slide and a string of text on it.

**العرض التقديمي كما تم إنشاؤه في VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//ملاحظة: PowerPoint هو مساحة أسماء تم تعريفها أعلاه كما يلي
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//إنشاء عرض تقديمي
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//الحصول على تخطيط الشريحة الفارغة
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

//كتابة الناتج إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);

```



## **مثال Aspose.Slides for .NET**
The code snippets below use Aspose.Slides to create a presentation with a plain slide and a string of text on it.

**العرض التقديمي كما تم إنشاؤه باستخدام Aspose.Slides for .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//يتم إضافة شريحة فارغة افتراضياً عند إنشاء
//العرض التقديمي باستخدام المُنشئ الافتراضي
//لذا، لا نحتاج لإضافة أي شريحة فارغة
ISlide sld = pres.Slides[1];

//إضافة مربع نص
//لإضافته، سنضيف أولاً مستطيلًا
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//إخفاء حدّه
shp.LineFormat.Style = LineStyle.NotDefined;

//ثم نضيف إطار نص داخلها
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//تعيين نص
tf.Text = "Text added dynamically";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//كتابة الناتج إلى القرص
pres.Save("outAspose.ppt", SaveFormat.Ppt);
```