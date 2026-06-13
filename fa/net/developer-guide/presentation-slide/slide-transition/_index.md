---
title: مدیریت انتقال اسلایدها در ارائه‌ها در .NET
linktitle: انتقال اسلاید
type: docs
weight: 90
url: /fa/net/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال اسلاید پیشرفته
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید انتقال اسلایدها را در Aspose.Slides برای .NET سفارشی کنید، با راهنمای گام‌به‌گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه انتقال اسلایدها را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کنید. نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال را مانند پیشروی با کلیک یا پس از زمان معین تنظیم کنید، پیشروی خودکار را بررسی و غیرفعال کنید، از انتقال Morph و انواع آن استفاده کنید و گزینه‌های اثر انتقال را تنظیم کنید. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگیری یا ایجاد کنید، تنظیمات انتقال اسلایدهای منتخب را تغییر دهید و نتیجه را به عنوان فایل PPTX ذخیره کنید. این مقاله همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال یک انتقال یکسان به چندین اسلاید و بررسی انتقال فعلی تنظیم شده بر روی یک اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای درک بهتر، استفاده از Aspose.Slides برای .NET برای مدیریت انتقال‌های ساده اسلاید را نشان دادیم. توسعه‌دهندگان می‌توانند نه تنها اثرات انتقال مختلف را بر اسلایدها اعمال کنند، بلکه رفتار این اثرات را نیز سفارشی کنند. برای ایجاد یک اثر انتقال اسلاید ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بسازید.
2. یک نوع انتقال اسلاید (Slide Transition Type) را از میان اثرات انتقال ارائه‌شده توسط Aspose.Slides برای .NET از طریق enum TransitionType بر اسلاید اعمال کنید.
3. فایل ارائه اصلاح‌شده را بنویسید.

```c#
 // ایجاد نمونه از کلاس Presentation برای بارگذاری فایل ارائه منبع
 using (Presentation presentation = new Presentation("AccessSlides.pptx"))
 {
     // اعمال انتقال نوع دایره‌ای بر روی اسلاید 1
     presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

     // اعمال انتقال نوع شانه‌ای بر روی اسلاید 2
     presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

     // ذخیرهٔ ارائه روی دیسک
     presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

## **افزودن انتقال اسلاید پیشرفته**
در بخش قبل فقط یک اثر انتقال ساده بر اسلاید اعمال شد. اکنون برای بهتر و کنترل‌شده‌تر کردن آن اثر ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) بسازید.
2. یک نوع انتقال اسلاید را از میان اثرات انتقال ارائه‌شده توسط Aspose.Slides برای .NET بر اسلاید اعمال کنید.
3. می‌توانید انتقال را به «پیشروی با کلیک»، «پس از زمان مشخص» یا هر دو تنظیم کنید.
4. اگر انتقال اسلاید بر روی «پیشروی با کلیک» فعال باشد، انتقال تنها زمانی پیش می‌رود که کاربر کلیک کند. علاوه بر این، اگر ویژگی Advance After Time تنظیم شده باشد، انتقال به‌صورت خودکار پس از گذشت زمان مشخص پیش می‌رود.
5. ارائه اصلاح‌شده را به عنوان فایل ارائه ذخیره کنید.

```c#
 // ایجاد نمونه از کلاس Presentation که نشان‌دهنده یک فایل ارائه است
 using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
 {
 
     // اعمال انتقال نوع دایره‌ای بر روی اسلاید 1
     pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
 
 
     // تنظیم زمان انتقال به ۳ ثانیه
     pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;
 
     // اعمال انتقال نوع شانه‌ای بر روی اسلاید 2
     pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;
 
 
     // تنظیم زمان انتقال به ۵ ثانیه
     pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;
 
     // اعمال انتقال نوع زوم بر روی اسلاید 3
     pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;
 
 
     // تنظیم زمان انتقال به ۷ ثانیه
     pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
     pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;
 
     // ذخیرهٔ ارائه روی دیسک
     pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
 }
```

علاوه بر این، با استفاده از ویژگی [AdvanceAfter](https://reference.aspose.com/slides/fa/net/aspose.slides/islideshowtransition/advanceafter/) می‌توانید بررسی کنید که آیا انتقال اسلاید برای حرکت به اسلاید بعدی پیکربندی شده است یا تنظیم آن غیرفعال است.

این کد C# عملیات را نشان می‌دهد:

```c#
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل ارائه است
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // دریافت انتقال اسلاید
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // بررسی اینکه آیا تنظیم پیشروی پس از زمان فعال است
        if (slideTransition.AdvanceAfter)
        {
            // چاپ مقدار پیشروی پس از زمان
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // غیرفعال کردن انتقال پس از زمان مشخص اگر مقدار AdvanceAfterTime بیش از ۲ ثانیه باشد
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **انتقال Morph**
Aspose.Slides برای .NET اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/imorphtransition) پشتیبانی می‌کند. این انتقال جدیدی است که در PowerPoint 2019 معرفی شده است. انتقال Morph به شما امکان می‌دهد حرکت صاف از یک اسلاید به اسلاید بعدی را انیمیت کنید. این مقاله مفهوم را توضیح می‌دهد و نحوه استفاده از انتقال Morph را نشان می‌دهد. برای استفاده مؤثر از انتقال Morph، به دو اسلاید که حداقل یک شیء مشترک دارند، نیاز دارید. ساده‌ترین روش این است که اسلاید را کپی کنید و سپس شیء را در اسلاید دوم به مکان دیگری منتقل کنید.

قطعه کد زیر نشان می‌دهد چگونه یک کپی از اسلاید حاوی متن به ارائه اضافه کنید و انتقال [morph type](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) را به اسلاید دوم اختصاص دهید.

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **انواع انتقال Morph**
enum جدید [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionmorphtype) اضافه شده است. این enum انواع مختلف انتقال اسلاید Morph را نمایندگی می‌کند.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph بر اساس اشکال به‌عنوان اشیاء غیرقابل تقسیم انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به‌صورت کلمات (در صورت امکان) انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به‌صورت حرف (در صورت امکان) انجام می‌شود.

قطعه کد زیر نشان می‌دهد چگونه انتقال Morph را به اسلاید اختصاص داده و نوع Morph را تغییر دهید:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **تنظیم اثرات انتقال**
Aspose.Slides برای .NET از تنظیم اثرات انتقال مانند از سیاه، از چپ، از راست و غیره پشتیبانی می‌کند. برای تنظیم اثر انتقال، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- مرجع اسلاید را به‌دست آورید.
- اثر انتقال را تنظیم کنید.
- ارائه را به عنوان یک فایل [PPTX](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر، ما اثرات انتقال را تنظیم کرده‌ایم.

```c#
// ایجاد یک نمونه از کلاس Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");

// تنظیم اثر
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// نوشتن ارائه بر روی دیسک
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **سؤالات متداول**

**آیا می‌توانم سرعت پخش یک انتقال اسلاید را کنترل کنم؟**

بله. سرعت انتقال را با استفاده از تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/transitionspeed/) (مثلاً slow/medium/fast) تنظیم کنید.

**آیا می‌توانم صوتی را به یک انتقال پیوست کنم و آن را به‌صورت حلقه‌ای اجرا کنم؟**

بله. می‌توانید صدا را برای انتقال درج کنید و رفتار آن را از طریق تنظیماتی مانند SoundMode و SoundLoop (مثلاً [Sound](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/sound/)، [SoundMode](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/soundmode/)، [SoundLoop](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/soundloop/)) و متادیتاهایی مانند [SoundIsBuiltIn](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) و [SoundName](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/soundname/) کنترل کنید.

**سریع‌ترین راه برای اعمال یک انتقال یکسان بر تمام اسلایدها چیست؟**

نوع انتقال دلخواه را در تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع بر تمام اسلایدها نتیجهٔ یکنواختی می‌دهد.

**چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟**

تنظیمات [transition](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide/slideshowtransition/) اسلاید را بررسی کنید و مقدار [type](https://reference.aspose.com/slides/fa/net/aspose.slides.slideshow/slideshowtransition/type/) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد کدام اثر اعمال شده است.