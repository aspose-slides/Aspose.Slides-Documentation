---
title: افزودن قاب‌های تصویر با انیمیشن با استفاده از VSTO و Aspose.Slides برای .NET
linktitle: قاب‌های تصویر با انیمیشن
type: docs
weight: 60
url: /fa/net/adding-picture-frame-with-animation/
keywords:
- قاب تصویر
- افزودن تصویر
- افزودن عکس
- تصویر با انیمیشن
- عکس با انیمیشن
- مهاجرت
- VSTO
- اتوماسیون Office
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از اتوماسیون Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و قاب‌های تصویر را در اسلایدهای PowerPoint (PPT، PPTX) با کد تمیز C# انیمیشن دهید."
---
{{% alert color="primary" %}} 

قاب‌های تصویر در Microsoft PowerPoint به شکل‌ها یا تصاویر اعمال می‌شوند تا تصاویر را در یک ارائه قاب‌بندی کنند. این مقاله نشان می‌دهد چگونه می‌توان یک قاب تصویر ایجاد کرد و به‌صورت برنامه‌نویسی انیمیشن برای آن اعمال کرد، ابتدا با استفاده از [VSTO 2008](/slides/fa/net/adding-picture-frame-with-animation/) و سپس با [Aspose.Slides for .NET](/slides/fa/net/adding-picture-frame-with-animation/). ابتدا نشان می‌دهیم چگونه با VSTO 2008 یک قاب و انیمیشن اعمال کنید. سپس نشان می‌دهیم چگونه همین مراحل را با Aspose.Slides for .NET انجام دهید.

{{% /alert %}} 
## **اضافه‌کردن قاب‌های تصویر با انیمیشن**
نمونه‌های کد زیر یک ارائه با یک اسلاید ایجاد می‌کنند، یک تصویر با قاب تصویر اضافه می‌کنند و انیمیشن را به آن اعمال می‌کنند.
### **مثال VSTO 2008**
با استفاده از VSTO 2008، مراحل زیر را دنبال کنید:

1. یک ارائه ایجاد کنید.
1. یک اسلاید خالی اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را به تصویر اعمال کنید.
1. ارائه را روی دیسک ذخیره کنید.

**ارائه خروجی، ایجاد شده با VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//ایجاد ارائه خالی
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add Picture Frame
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applying animation on picture frame
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Saving Presentation
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
با استفاده از Aspose.Slides for .NET، مراحل زیر را انجام دهید:

1. یک ارائه ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک تصویر به مجموعه تصاویر اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را به تصویر اعمال کنید.
1. ارائه را روی دیسک ذخیره کنید.

**ارائه خروجی، ایجاد شده با Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// یک ارائه خالی ایجاد کنید
using (Presentation pres = new Presentation())
{
    // به اولین اسلاید دسترسی پیدا کنید
    ISlide slide = pres.Slides[0];

    // یک تصویر به مجموعه تصاویر ارائه اضافه کنید
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // یک قاب تصویر اضافه کنید که ارتفاع و عرض آن با ارتفاع و عرض تصویر برابر باشد
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // دنباله اصلی انیمیشن اسلاید را دریافت کنید
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // افکت انیمیشن Fly از سمت چپ را به قاب تصویر اضافه کنید
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // ارائه را ذخیره کنید
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```