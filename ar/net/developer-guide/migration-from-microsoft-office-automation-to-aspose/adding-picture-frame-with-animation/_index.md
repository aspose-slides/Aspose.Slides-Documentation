---
title: إضافة إطار صورة مع الرسوم المتحركة
type: docs
weight: 60
url: /ar/net/adding-picture-frame-with-animation/
---

{{% alert color="primary" %}} 

تُطبق إطارات الصور على الأشكال أو الصور في Microsoft PowerPoint لإطار الصور في العرض التقديمي. توضح هذه المقالة كيفية إنشاء إطار صورة وتطبيق الرسوم المتحركة عليه برمجيًا باستخدام أولاً [VSTO 2008](/slides/ar/net/adding-picture-frame-with-animation/) ثم [Aspose.Slides for .NET](/slides/ar/net/adding-picture-frame-with-animation/). أولاً، سنوضح لك كيفية تطبيق إطار ورسوم متحركة باستخدام VSTO 2008. ثم نوضح لك كيفية تنفيذ نفس الخطوات باستخدام Aspose.Slides for .NET.

{{% /alert %}} 
## **إضافة إطارات صورة مع الرسوم المتحركة**
تقوم عينات الكود أدناه بإنشاء عرض تقديمي مع شريحة، وإضافة صورة مع إطار صورة وتطبيق الرسوم المتحركة عليها.
### **مثال VSTO 2008**
باستخدام VSTO 2008، اتبع الخطوات التالية:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة شكل صورة إلى الشريحة.
1. تطبيق الرسوم المتحركة على الصورة.
1. كتابة العرض التقديمي إلى القرص.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
// إنشاء عرض تقديمي فارغ
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

// إضافة شريحة فارغة
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

// إضافة إطار صورة
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

// تطبيق الرسوم المتحركة على إطار الصورة
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

// حفظ العرض التقديمي
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
باستخدام Aspose.Slides for .NET، قم بتنفيذ الخطوات التالية:

1. إنشاء عرض تقديمي.
1. الوصول إلى الشريحة الأولى.
1. إضافة صورة إلى مجموعة الصور.
1. إضافة شكل صورة إلى الشريحة.
1. تطبيق الرسوم المتحركة على الصورة.
1. كتابة العرض التقديمي إلى القرص.

**العرض التقديمي الناتج، الذي تم إنشاؤه باستخدام Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// إنشاء عرض تقديمي فارغ
using (Presentation pres = new Presentation())
{
    // الوصول إلى الشريحة الأولى
    ISlide slide = pres.Slides[0];

    // إضافة صورة إلى مجموعة الصور الخاصة بالعرض التقديمي
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // إضافة إطار صورة يتناسب ارتفاعه وعرضه مع ارتفاع الصورة وعرضها
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // الحصول على تسلسل الرسوم المتحركة الرئيسي للشريحة
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // إضافة تأثير الرسوم المتحركة Fly من اليسار إلى إطار الصورة
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // حفظ العرض التقديمي
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```