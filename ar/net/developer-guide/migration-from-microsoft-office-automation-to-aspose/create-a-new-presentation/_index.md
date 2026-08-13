---
title: إنشاء عروض تقديمية جديدة باستخدام VSTO و Aspose.Slides لـ .NET
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
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وإنشاء عروض PowerPoint (PPT، PPTX) جديدة باستخدام C# بكود نظيف وموثوق."
---
{{% alert color="info" %}} 

تم تطوير VSTO للسماح للمطورين بإنشاء تطبيقات يمكن تشغيلها داخل Microsoft Office. VSTO يعتمد على COM ولكنه مُغلف داخل كائن .NET حتى يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET وكذلك إلى بيئة تشغيل CLR الخاصة بـ Microsoft Office. على الرغم من أنه يمكن استخدامه لإنشاء إضافات Microsoft Office إلا أنه شبه مستحيل استخدامه كمكوّن على جانب الخادم. كما أن لديه مشاكل نشر خطيرة.

Aspose.Slides for .NET هو مكوّن يمكن استخدامه لمعالجة عروض تقديمية Microsoft PowerPoint، تماماً مثل VSTO، لكنه يتمتع بالعديد من المزايا:

- يحتوي Aspose.Slides على شفرة مُدارة فقط ولا يتطلب تثبيت بيئة تشغيل Microsoft Office.
- يمكن استخدامه كمكوّن جانب العميل أو كمكوّن جانب الخادم.
- النشر سهل لأن Aspose.Slides يتم تضمينه في DLL واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان على الشيفرة يوضحان كيف يمكن استخدام VSTO و Aspose.Slides for .NET لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/ar/net/create-a-new-presentation/); [المثال الثاني](/slides/ar/net/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
 //ملاحظة: PowerPoint هو مساحة أسماء تم تعريفها أعلاه كما يلي
 //using PowerPoint = Microsoft.Office.Interop.PowerPoint;

 //إنشاء عرض تقديمي
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

 //الحصول على تخطيط شريحة العنوان
 PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

 //إضافة شريحة عنوان.
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
using Aspose.Slides;
using Aspose.Slides.Export;

//إنشاء عرض تقديمي
Presentation pres = new Presentation();

//إضافة شريحة العنوان
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//تعيين نص العنوان
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//تعيين نص العنوان الفرعي
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//كتابة المخرجات إلى القرص
pres.Save("outAsposeSlides.pptx", SaveFormat.Ppt);
```