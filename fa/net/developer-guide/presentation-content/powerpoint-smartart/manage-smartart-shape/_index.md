---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با .NET
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/net/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح‌بندی SmartArt
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اتوماتیک‌سازی ایجاد، ویرایش و استایل‌سازی SmartArt در PowerPoint با .NET با استفاده از Aspose.Slides، شامل مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **مروری کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را به صورت برنامه‌نویسی در ارائه‌های PowerPoint ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به اسلاید اضافه کنید، به اشکال SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس نوع Layout خاصی پیدا کنید و ظاهر بصری آن را با تغییر Style یا Color Style تغییر دهید.

نمونه‌ها نشان می‌دهند چگونه از طریق مجموعه اشکال اسلاید ارائه با اشکال SmartArt کار کنید، بررسی کنید آیا یک شکل SmartArt است و سپس خواص آن را تغییر یا بررسی کنید.

## **ایجاد یک شکل SmartArt**
Aspose.Slides برای .NET اکنون امکان افزودن اشکال SmartArt سفارشی به اسلایدهای خود را از ابتدا فراهم می‌کند. Aspose.Slides برای .NET ساده‌ترین API را برای ایجاد اشکال SmartArt به راحتی ارائه داده است. برای ایجاد یک شکل SmartArt در یک اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع اسلاید را دریافت کنید.
- یک شکل SmartArt را با تنظیم LayoutType اضافه کنید.
- ارائه اصلاح‌شده را به صورت فایل PPTX ذخیره کنید.

```c#
// نمونه سازی ارائه
using (Presentation pres = new Presentation())
{

    // دسترسی به اسلاید ارائه
    ISlide slide = pres.Slides[0];

    // افزودن شکل Smart Art
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // ذخیره ارائه
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **دسترسی به یک شکل SmartArt در اسلاید**
کد زیر برای دسترسی به اشکال SmartArt اضافه‌شده در اسلاید ارائه استفاده می‌شود. در نمونه کد، هر شکل داخل اسلاید پیمایش می‌شود و بررسی می‌شود که آیا یک شکل SmartArt است یا خیر. اگر شکل از نوع SmartArt باشد، به نمونه SmartArt تبدیل می‌شود.

```c#
// بارگذاری ارائه مورد نظر
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // پیمایش تمام اشکال داخل اولین اسلاید
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape is ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```



## **دسترسی به یک شکل SmartArt با نوع Layout خاص**
نمونه کد زیر به شما کمک می‌کند تا به شکل SmartArt با LayoutType مشخص دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توان LayoutType را تغییر داد زیرا فقط در زمان افزودن شکل SmartArt قابل تنظیم است.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
- هر شکل داخل اولین اسلاید را پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخابی را به SmartArt تبدیل کنید.
- شکل SmartArt با LayoutType مورد نظر را بررسی کنید و عملیات مورد نیاز پس از آن را انجام دهید.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // پیمایش تمام اشکال داخل اولین اسلاید
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape is ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // بررسی Layout SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```



## **تغییر Style یک شکل SmartArt**
نمونه کد زیر به شما کمک می‌کند تا به شکل SmartArt با Style خاص دسترسی پیدا کنید.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
- هر شکل داخل اولین اسلاید را پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخابی را به SmartArt تبدیل کنید.
- شکل SmartArt با Style مورد نظر را پیدا کنید.
- Style جدید را برای شکل SmartArt تنظیم کنید.
- ارائه را ذخیره کنید.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // پیمایش تمام اشکال داخل اولین اسلاید
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape is ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // بررسی سبک SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // تغییر سبک SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // ذخیره ارائه
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```



## **تغییر Color Style یک شکل SmartArt**
در این مثال، نحوه تغییر رنگ برای هر شکل SmartArt را می‌آموزیم. در کد نمونه زیر به شکل SmartArt با Color Style خاص دسترسی پیدا می‌کنیم و سبک آن را تغییر می‌دهیم.

- یک نمونه از کلاس `Presentation` ایجاد کنید و ارائه‌ای که شامل شکل SmartArt است را بارگذاری کنید.
- با استفاده از Index، مرجع اولین اسلاید را دریافت کنید.
- هر شکل داخل اولین اسلاید را پیمایش کنید.
- بررسی کنید آیا شکل از نوع SmartArt است و در صورت بودن، شکل انتخابی را به SmartArt تبدیل کنید.
- شکل SmartArt با Color Style مورد نظر را پیدا کنید.
- Color Style جدید را برای شکل SmartArt تنظیم کنید.
- ارائه را ذخیره کنید.

```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // پیمایش تمام اشکال داخل اولین اسلاید
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape is ISmartArt)
        {
            // تبدیل نوع شکل به SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // بررسی نوع رنگ SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // تغییر نوع رنگ SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // ذخیره ارائه
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```

## **سؤالات متداول**

**آیا می‌توانم SmartArt را به عنوان یک شیء واحد انیمیشن کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید از طریق API انیمیشن‌ها [انیمیشن‌های استاندارد](/slides/fa/net/powerpoint-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) همانند سایر اشکال اعمال کنید.

**اگر شناسه داخلی SmartArt را ندانم، چگونه می‌توانم SmartArt خاصی را در اسلاید پیدا کنم؟**

متن جایگزین (AltText) را تنظیم کنید و با استفاده از آن مقدار جستجو کنید—این روش پیشنهادی برای یافتن شکل هدف است.

**آیا می‌توانم SmartArt را با سایر اشکال گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با اشکال دیگر (تصاویر، جدول‌ها و غیره) گروه‌بندی کنید و سپس [گروه را دستکاری](/slides/fa/net/group/) کنید.

**چگونه می‌توانم تصویر یک SmartArt خاص را به‌دست آورم (مثلاً برای پیش‌نمایش یا گزارش)؟**

یک تصویر/تصویر کوچک از شکل استخراج کنید؛ کتابخانه می‌تواند [اشکال منفرد](/slides/fa/net/create-shape-thumbnails/) را به فایل‌های رستری (PNG/JPG/TIFF) رندر کند.

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندرینگ برای [صادرات PDF](/slides/fa/net/convert-powerpoint-to-pdf/) با کیفیت بالا هدف‌گذاری شده است و گزینه‌های مختلفی برای کیفیت و سازگاری ارائه می‌دهد.