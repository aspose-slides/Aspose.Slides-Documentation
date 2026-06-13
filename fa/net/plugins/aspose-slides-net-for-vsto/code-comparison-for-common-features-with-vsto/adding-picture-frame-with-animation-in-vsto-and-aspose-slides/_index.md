---
title: افزودن قاب تصویر با انیمیشن در VSTO و Aspose.Slides
type: docs
weight: 20
url: /fa/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
نمونه‌های کد زیر یک ارائه با یک اسلاید ایجاد می‌کنند، یک تصویر با یک قاب عکس اضافه می‌کنند و انیمیشن به آن اعمال می‌شود.
## **VSTO**
با استفاده از VSTO، مراحل زیر را انجام دهید:

1. یک ارائه ایجاد کنید.
1. یک اسلاید خالی اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را به تصویر اعمال کنید.
1. ارائه را بر روی دیسک بنویسید.

``` csharp

 //ایجاد ارائه خالی
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//افزودن اسلاید خالی
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//افزودن قاب تصویر
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//اعمال انیمیشن بر روی قاب تصویر
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//ذخیره‌سازی ارائه
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
با استفاده از Aspose.Slides برای .NET، مراحل زیر را انجام دهید:

1. یک ارائه ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک تصویر به مجموعهٔ تصویرها اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را به تصویر اعمال کنید.
1. ارائه را بر روی دیسک بنویسید.

``` csharp

 //ایجاد ارائه خالی
Presentation pres = new Presentation();

 //دسترسی به اسلاید اول
Slide slide = pres.GetSlideByPosition(1);

 //افزودن شی تصویر به مجموعهٔ تصاویر ارائه
Picture pic = new Picture(pres, "pic.jpeg");

//پس از افزودن شی تصویر، به تصویر یک شناسهٔ یکتا اختصاص داده می‌شود
int picId = pres.Pictures.Add(pic);

 //افزودن قاب تصویر
Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

 //اعمال انیمیشن بر روی قاب تصویر
PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

 //ذخیره‌سازی ارائه
pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)