---
title: إضافة إطار صورة مع الرسوم المتحركة في VSTO و Aspose.Slides
type: docs
weight: 20
url: /ar/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

تقوم عينات الشيفرة أدناه بإنشاء عرض تقديمي مع شريحة، إضافة صورة مع إطار صورة وتطبيق الرسوم المتحركة عليها.
## **VSTO**
باستخدام VSTO ، اتبع الخطوات التالية:

1. إنشاء عرض تقديمي.
1. إضافة شريحة فارغة.
1. إضافة شكل صورة إلى الشريحة.
1. تطبيق الرسوم المتحركة على الصورة.
1. كتابة العرض التقديمي على القرص.

``` csharp

 //إنشاء عرض تقديمي فارغ

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//إضافة شريحة فارغة

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//إضافة إطار صورة

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//تطبيق الرسوم المتحركة على إطار الصورة

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//حفظ العرض التقديمي

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
باستخدام Aspose.Slides لـ .NET ، قم بالخطوات التالية:

1. إنشاء عرض تقديمي.
1. الوصول إلى الشريحة الأولى.
1. إضافة صورة إلى مجموعة الصور.
1. إضافة شكل صورة إلى الشريحة.
1. تطبيق الرسوم المتحركة على الصورة.
1. كتابة العرض التقديمي على القرص.

``` csharp

 //إنشاء عرض تقديمي فارغ

Presentation pres = new Presentation();

//الوصول إلى الشريحة الأولى

Slide slide = pres.GetSlideByPosition(1);

//إضافة كائن الصورة إلى مجموعة الصور الخاصة بالعرض التقديمي

Picture pic = new Picture(pres, "pic.jpeg");

//بعد إضافة كائن الصورة، يتم منح الصورة معرف صورة فريد

int picId = pres.Pictures.Add(pic);

//إضافة إطار صورة

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//تطبيق الرسوم المتحركة على إطار الصورة

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//حفظ العرض التقديمي

pres.Write("AsposeAnim.ppt");

``` 
## **تنزيل كود العينة**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)