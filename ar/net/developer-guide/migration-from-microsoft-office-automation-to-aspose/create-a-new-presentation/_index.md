---
title: إنشاء عروض تقديمية جديدة باستخدام VSTO و Aspose.Slides للـ .NET
linktitle: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /ar/net/create-a-new-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "ترحيل من أتمتة Microsoft Office إلى Aspose.Slides للـ .NET وإنشاء عروض PowerPoint (PPT، PPTX) جديدة بلغة C# باستخدام كود نظيف وموثوق."
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من بناء التطبيقات التي يمكن تشغيلها داخل Microsoft Office. VSTO يعتمد على COM ولكنه مُغلف داخل كائن .NET حتى يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET بالإضافة إلى وقت تشغيل CLR الخاص بـ Microsoft Office. وعلى الرغم من أنه يمكن استخدامه لإنشاء إضافات Microsoft Office، إلا أنه من شبه المستحيل استخدامه كمكوّن جانب الخادم. كما أن له مشاكل نشر جادة.

Aspose.Slides for .NET هو مكوّن يمكن استخدامه لمعالجة عروض PowerPoint من Microsoft، تمامًا كما هو الحال مع VSTO، لكنه يتميز بعدة مزايا:

- يحتوي Aspose.Slides على شفرة مُدارة فقط ولا يتطلب تثبيت وقت تشغيل Microsoft Office.
- يمكن استخدامه كمكوّن جانب العميل أو كمكوّن جانب الخادم.
- النشر سهل لأن Aspose.Slides موجود في ملف DLL واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان للشفرة يوضحان كيف يمكن استخدام VSTO وAspose.Slides for .NET لتحقيق الهدف نفسه. المثال الأول هو [VSTO](/slides/ar/net/create-a-new-presentation/); [المثال الثاني](/slides/ar/net/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//ملاحظة: PowerPoint هو مساحة اسم تم تعريفها أعلاه هكذا
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
