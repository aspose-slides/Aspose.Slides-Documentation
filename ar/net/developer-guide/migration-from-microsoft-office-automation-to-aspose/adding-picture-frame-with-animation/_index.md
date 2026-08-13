---
title: إضافة إطارات الصور مع الحركة باستخدام VSTO و Aspose.Slides لـ .NET
linktitle: إطارات الصور مع الحركة
type: docs
weight: 60
url: /ar/net/adding-picture-frame-with-animation/
keywords:
- إطار صورة
- إضافة صورة
- إضافة صورة
- صورة مع حركة
- صورة مع حركة
- ترحيل
- VSTO
- أتمتة Office
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "الترحيل من أتمتة Microsoft Office إلى Aspose.Slides لـ .NET وتحريك إطارات الصور في شرائح PowerPoint (PPT, PPTX) باستخدام كود C# نظيف."
---
{{% alert color="info" %}} 

تُطبق إطارات الصور على الأشكال أو الصور في Microsoft PowerPoint لتحديد صور في العرض التقديمي. توضح هذه المقالة كيفية إنشاء إطار صورة وتطبيق حركة عليه برمجيًا باستخدام أولاً [VSTO 2008](/slides/ar/net/adding-picture-frame-with-animation/) ثم [Aspose.Slides for .NET](/slides/ar/net/adding-picture-frame-with-animation/). أولاً، نُظهر لك كيفية تطبيق إطار وحركة باستخدام VSTO 2008. ثم نُظهر لك كيفية تنفيذ نفس الخطوات باستخدام Aspose.Slides for .NET.

{{% /alert %}} 
## **إضافة إطارات الصور مع الحركة**
تنشئ عينات الشيفرة أدناه عرضًا تقديميًا يحتوي على شريحة، وتضيف صورةً بإطار صورة وتطبق عليها حركة.

### **مثال VSTO 2008**
باستخدام VSTO 2008، اتبع الخطوات التالية:

1. إنشاء عرض تقديمي.
2. إضافة شريحة فارغة.
3. إضافة شكل صورة إلى الشريحة.
4. تطبيق حركة على الصورة.
5. كتابة العرض التقديمي إلى القرص.

**العرض التقديمي الناتج، تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//إنشاء عرض تقديمي فارغ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//إضافة شريحة فارغة
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//إضافة إطار صورة
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//تطبيق حركة على إطار الصورة
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//حفظ العرض التقديمي
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
باستخدام Aspose.Slides for .NET، نفّذ الخطوات التالية:

1. إنشاء عرض تقديمي.
2. الوصول إلى الشريحة الأولى.
3. إضافة صورة إلى مجموعة الصور.
4. إضافة شكل صورة إلى الشريحة.
5. تطبيق حركة على الصورة.
6. كتابة العرض التقديمي إلى القرص.

**العرض التقديمي الناتج، تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// إنشاء عرض تقديمي فارغ
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // إضافة صورة إلى مجموعة الصور في العرض التقديمي
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // إضافة إطار صورة ارتفاعه وعرضه يطابقان ارتفاع وعرض الصورة
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // الحصول على تسلسل الحركة الرئيسي للشفقة
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // إضافة تأثير التحليق من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ العرض التقديمي
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```