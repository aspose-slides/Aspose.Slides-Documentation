---
title: إضافة نص ديناميكي باستخدام VSTO و Aspose.Slides لـ .NET
type: docs
weight: 20
url: /ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/
---

{{% alert color="primary" %}} 

المهمة الشائعة التي يسعى المطورون لتحقيقها هي إضافة نص إلى الشرائح ديناميكيًا. توضح هذه المقالة أمثلة على الشيفرات لإضافة نص بشكل ديناميكي باستخدام [VSTO](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/) و [Aspose.Slides لـ .NET](/slides/ar/net/adding-text-dynamically-using-vsto-and-aspose-slides-for-net/).

{{% /alert %}} 
## **إضافة نص ديناميكي**
تتبع كلا الطريقتين الخطوات التالية:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة صندوق نص.
1. تعيين بعض النصوص.
1. كتابة العرض التقديمي.
## **مثال على كود VSTO**
تؤدي مقتطفات الكود أدناه إلى إنشاء عرض تقديمي مع شريحة بسيطة ونص مكتوب عليها.

**العرض التقديمي كما تم إنشاؤه في VSTO** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_1.png)

```c#
//ملاحظة: PowerPoint هو مساحة اسم تم تعريفها أعلاه على النحو التالي
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
txtRange.Text = "تم إضافة النص ديناميكيًا";
txtRange.Font.Name = "Arial";
txtRange.Font.Bold = Microsoft.Office.Core.MsoTriState.msoTrue;
txtRange.Font.Size = 32;

//كتابة المخرجات إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



## **مثال على Aspose.Slides لـ .NET**
تستخدم مقتطفات الكود أدناه Aspose.Slides لإنشاء عرض تقديمي مع شريحة بسيطة ونص مكتوب عليها.

**العرض التقديمي كما تم إنشاؤه باستخدام Aspose.Slides لـ .NET** 

![todo:image_alt_text](adding-text-dynamically-using-vsto-and-aspose-slides-for-net_2.png)

```c#
//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//يتم إضافة شريحة فارغة بشكل افتراضي عند إنشاء
//عرض تقديمي من الباني الافتراضي
//لذا، لا نحتاج لإضافة أي شريحة فارغة
ISlide sld = pres.Slides[1];

//إضافة صندوق نص
//للقيام بذلك، سنقوم أولاً بإضافة مستطيل
IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 1200, 800, 3200, 370);

//إخفاء خطه
shp.LineFormat.Style = LineStyle.NotDefined;

//ثم إضافة إطار نص داخله
ITextFrame tf = ((IAutoShape)shp).TextFrame;

//تعيين نص
tf.Text = "تم إضافة النص ديناميكيًا";
IPortion port = tf.Paragraphs[0].Portions[0];

port.PortionFormat.FontBold = NullableBool.True;
port.PortionFormat.FontHeight = 32;

//كتابة المخرجات إلى القرص
pres.Save("c:\\outAspose.ppt", SaveFormat.Ppt);
```