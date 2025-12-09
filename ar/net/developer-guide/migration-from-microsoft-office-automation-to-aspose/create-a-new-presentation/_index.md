---
title: إنشاء عروض تقديمية جديدة باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /ar/net/create-a-new-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- الترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإنشاء عروض PowerPoint (PPT, PPTX) جديدة في C# باستخدام كود نظيف وموثوق."
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من بناء تطبيقات يمكن تشغيلها داخل Microsoft Office. VSTO يعتمد على COM لكنه مُغلف داخل كائن .NET بحيث يمكن استخدامه في تطبيقات .NET. VSTO يحتاج إلى دعم إطار عمل .NET وكذلك إلى بيئة تشغيل CLR الخاصة بـ Microsoft Office. على الرغم من أنه يمكن استخدامه لإنشاء إضافات Microsoft Office، إلا أنه من الصعب تقريبًا استخدامه كمكوّن جانب الخادم. كما يواجه مشكلات جدية في النشر.

Aspose.Slides for .NET هو مكوّن يمكن استخدامه لمعالجة عروض Microsoft PowerPoint، تمامًا مثل VSTO، ولكنه يمتلك عدة مزايا:

- يحتوي Aspose.Slides على شفرة مُدارة فقط ولا يتطلب تثبيت بيئة تشغيل Microsoft Office.
- يمكن استخدامه كمكوّن جانب العميل أو كمكوّن جانب الخادم.
- النشر سهل لأن Aspose.Slides موجود في ملف DLL واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
أدناه مثالان للشفرة يوضحان كيفية استخدام VSTO وAspose.Slides for .NET لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/ar/net/create-a-new-presentation/); [المثال الثاني](/slides/ar/net/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//ملاحظة: PowerPoint هي مساحة أسماء تم تعريفها أعلاه كما يلي
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//إنشاء عرض تقديمي
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//تعيين نص العنوان
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//تعيين نص العنوان الفرعي
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//كتابة الناتج إلى القرص
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **مثال Aspose.Slides for .NET**
**المخرجات من Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//إضافة شريحة العنوان
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//تعيين نص العنوان
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//تعيين نص العنوان الفرعي
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//كتابة الناتج إلى القرص
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
