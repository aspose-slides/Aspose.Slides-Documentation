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
- خودکارسازی آفیس
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از خودکارسازی Microsoft Office به Aspose.Slides برای .NET مهاجرت کنید و قاب‌های تصویر را در اسلایدهای PowerPoint (PPT، PPTX) با کد تمیز C# انیمیت کنید."
---
{{% alert color="info" %}} 
قالب‌های تصویر در Microsoft PowerPoint بر روی اشکال یا تصاویر اعمال می‌شوند تا تصاویر را در یک ارائه قاب‌بندی کنند. این مقاله نشان می‌دهد چگونه یک قالب تصویر ایجاد کنید و به صورت برنامه‌نویسی انیمیشن بر روی آن اعمال کنید، ابتدا با استفاده از [VSTO 2008](/slides/fa/net/adding-picture-frame-with-animation/) و سپس با [Aspose.Slides for .NET](/slides/fa/net/adding-picture-frame-with-animation/). ابتدا نشان می‌دهیم چگونه با VSTO 2008 یک قاب و انیمیشن اعمال کنید. سپس نشان می‌دهیم چگونه همان مراحل را با Aspose.Slides for .NET انجام دهید.
{{% /alert %}} 
## **افزودن قالب‌های تصویر با انیمیشن**
نمونه‌های کد زیر یک ارائه با اسلایدی ایجاد می‌کنند، تصویری را با یک قالب تصویر اضافه می‌کنند و انیمیشن به آن اعمال می‌شود.
### **مثال VSTO 2008**
با استفاده از VSTO 2008، مراحل زیر را انجام دهید:

1. یک ارائه ایجاد کنید.
1. یک اسلاید خالی اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را بر روی تصویر اعمال کنید.
1. ارائه را در دیسک ذخیره کنید.

**ارائه خروجی، ایجاد شده با VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
 //ایجاد ارائه خالی
 PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

 //افزودن اسلاید خالی
 PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

 //افزودن قاب تصویر
 PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
 Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

 //اعمال انیمیشن بر روی قاب تصویر
 PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

 //ذخیره‌سازی ارائه
 pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
 Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **مثال Aspose.Slides for .NET**
با استفاده از Aspose.Slides for .NET، مراحل زیر را انجام دهید:

1. یک ارائه ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. یک تصویر به مجموعه picture collection اضافه کنید.
1. یک شکل تصویر به اسلاید اضافه کنید.
1. انیمیشن را بر روی تصویر اعمال کنید.
1. ارائه را در دیسک ذخیره کنید.

**ارائه خروجی، ایجاد شده با Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// ایجاد یک ارائه خالی
using (Presentation pres = new Presentation())
{
    // دسترسی به اولین اسلاید
    ISlide slide = pres.Slides[0];

    // افزودن یک تصویر به مجموعه تصاویر ارائه
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // افزودن یک قاب تصویر که ارتفاع و عرض آن با ارتفاع و عرض تصویر مطابقت دارد
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // دریافت توالی انیمیشن اصلی اسلاید
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // افزودن اثر انیمیشن پرواز از سمت چپ به قاب تصویر
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // ذخیره کردن ارائه
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```