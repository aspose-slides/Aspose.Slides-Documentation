---
title: إنشاء عرض تقديمي جديد
type: docs
weight: 10
url: /net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

تم تطوير VSTO لتمكين المطورين من بناء تطبيقات يمكن أن تعمل داخل Microsoft Office. VSTO يعتمد على COM لكنه مغلف داخل كائن .NET حتى يمكن استخدامه في تطبيقات .NET. يحتاج VSTO إلى دعم إطار عمل .NET بالإضافة إلى وقت تشغيل CLR الخاص بـ Microsoft Office. على الرغم من أنه يمكن استخدامه لصنع ملحقات Microsoft Office، إلا أنه يكاد يكون من المستحيل استخدامه كمكون على جانب الخادم. كما أن لديه مشاكل جدية في نشر التطبيقات.

Aspose.Slides for .NET هو مكون يمكن استخدامه للتلاعب بعروض Microsoft PowerPoint التقديمية، تمامًا مثل VSTO، لكنه يتمتع بعدة مزايا:

- Aspose.Slides يحتوي على كود مُدار فقط ولا يتطلب تثبيت وقت تشغيل Microsoft Office.
- يمكن استخدامه كمكون على جانب العميل أو كمكون على جانب الخادم.
- النشر سهل نظرًا لأن Aspose.Slides موجود في DLL واحد.

{{% /alert %}} 
## **إنشاء عرض تقديمي**
فيما يلي مثالان على الكود يوضحان كيفية استخدام VSTO وAspose.Slides for .NET لتحقيق نفس الهدف. المثال الأول هو [VSTO](/slides/net/create-a-new-presentation/); [المثال الثاني](/slides/net/create-a-new-presentation/) يستخدم Aspose.Slides.
### **مثال VSTO**
**مخرجات VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//ملاحظة: PowerPoint هو مساحة الأسماء التي تم تعريفها أعلاه مثل هذا
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
slide.Shapes.Title.TextFrame.TextRange.Text = "عنوان الشريحة";

//تعيين نص العنوان الفرعي
slide.Shapes[2].TextFrame.TextRange.Text = "العنوان الفرعي للشريحة";

//كتابة المخرجات إلى القرص
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
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "عنوان الشريحة";

//تعيين نص العنوان الفرعي
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "العنوان الفرعي للشريحة";

//كتابة المخرجات إلى القرص
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```