---
title: تبدیل PPT به PPTX در .NET
linktitle: PPT به PPTX
type: docs
weight: 20
url: /fa/net/convert-ppt-to-pptx/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- PPT به PPTX
- ذخیره PPT به صورت PPTX
- صادرات PPT به PPTX
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فایل‌های PPT قدیمی را به PPTX در .NET با Aspose.Slides تبدیل کنید. شامل مثال‌های C# برای تبدیل تک‌فایل و دسته‌ای، مدیریت خطا و نکات مربوط به دقت است."
---
## **بررسی کلی**

PPT یک قالب باینری قدیمی PowerPoint است، در حالی که PPTX قالب جدید Open XML است. Aspose.Slides برای .NET می‌تواند یک فایل PPT را بارگذاری کرده و بدون نیاز به Microsoft PowerPoint به PPTX ذخیره کند. این مقاله نشان می‌دهد چگونه یک فایل یا یک پوشه از فایل‌ها را تبدیل کنید و توضیح می‌دهد پس از تبدیل چه مواردی را باید بررسی کنید.

## **تبدیل یک فایل PPT به PPTX**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بارگذاری کنید، سپس با متد [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) و آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) فراخوانی کنید. بیان `using` ارائه را حذف کرده و منابع آن را هنگامی که محدوده به پایان می‌رسد، آزاد می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// پرزنتیشن PPT قدیمی را بارگذاری کنید.
using var presentation = new Presentation("presentation.ppt");

// پرزنتیشن را در قالب PPTX ذخیره کنید.
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

پسوند فایل به تنهایی فرمت خروجی را انتخاب نمی‌کند؛ آرگومان [SaveFormat.Pptx](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveformat/) این کار را انجام می‌دهد. اگر نیاز به نگه داشتن فایل PPT اصلی دارید، مسیرهای ورودی و خروجی را متفاوت نگه دارید.

## **تبدیل چندین فایل PPT**

مثال زیر هر فایل `.ppt` در یک پوشه را تبدیل می‌کند. هر فایل به صورت مستقل پردازش می‌شود، بنابراین یک تبدیل ناموفق باعث توقف بقیه دسته نمی‌شود.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

برای بارهای کاری تولیدی، استثناهای کامل را لاگ کنید، تعیین کنید آیا فایل خروجی موجود می‌تواند بازنویسی شود و نام فایل‌های ناموفق را در صف retry یا بازبینی بنویسید. فایل‌های خراب، فایل‌های محافظت‌شده با رمز که بدون رمز صحیح باز می‌شوند، مسیرهای غیرقابل دسترس و محتوای پشتیبانی‌نشده می‌توانند باعث شکست تبدیل شوند. برای بارگذاری فایل‌های رمزگذاری‌شده، به صفحه [Password-Protected Presentations](/slides/fa/net/password-protected-presentation/) مراجعه کنید.

## **دقت و ویژگی‌های قدیمی**

تبدیل به طور معمول اسلایدها، مسترها، طرح‌بندی‌ها, متن, اشکال, تصاویر, جداول و نمودارها را حفظ می‌کند. اما PPT و PPTX هر ویژگی را دقیقاً به همان شکل نشان نمی‌دهند. ویژگی‌های قدیمی که معادل PPTX ندارند یا توسط کتابخانه پشتیبانی نمی‌شوند، ممکن است نرمال‌سازی، حذف یا به شکل متفاوتی نمایش داده شوند.

فایل تبدیل‌شده را زمانی که شامل انیمیشن‌ها، انتقال‌ها، اشیاء OLE توکار یا پیوندی، کنترل‌های ActiveX, رسانه‌های توکار, فونت‌های نامعمول یا ماکروهای VBA باشد، بررسی کنید. یک فایل PPTX ساده فرمت فعال‌سازی ماکرو نیست، بنابراین وقتی VBA باید در دسترس بماند، از فرآیند مناسب ماکرو‑پذیر استفاده کنید. همچنین اطمینان حاصل کنید فونت‌های لازم و منابع خارجی در محیطی که ارائه تبدیل‌شده باز یا رندر می‌شود، موجود باشند.

برای اسناد مهم، PPTX تولیدشده را برنامه‌نویسی مجدداً باز کنید و تعداد اسلایدهای کلیدی و محتوا را بررسی کنید، سپس ظاهر و رفتار اسلایدشو را در مشاهده‌گر مقصد مقایسه کنید. موفقیت فراخوانی [IPresentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/ipresentation/save/) را به‌عنوان اثبات این‌که هر ویژگی قدیمی نمایه دقیق در PPTX دارد در نظر نگیرید.

## **زمان استفاده از PPTX**

از PPTX استفاده کنید وقتی ارائه در نسخه‌های فعلی PowerPoint ویرایش می‌شود، با سیستم‌هایی که با بسته‌های Open XML کار می‌کنند به‌اشتراک گذاشته می‌شود، یا در قالبی ذخیره می‌شود که نسبت به PPT باینری قدیمی برای بازبینی و بازیابی آسان‌تر است. تا زمانی که ارائه تبدیل‌شده از آزمون‌های دقت شما عبور کرده باشد، نسخه اصلی PPT را به‌عنوان نسخه آرشیوی یا بازگشتی نگه دارید.

اگر به جای آن به PDF، HTML, تصاویر, XPS یا نوع خروجی دیگری نیاز دارید، راهنمایی‌های مربوط به قالب را در صفحه [Convert Presentations to Multiple Formats](/slides/fa/net/convert-presentation/) استفاده کنید و فرض نکنید همه هدف‌ها ویژگی‌های قابل ویرایش PowerPoint را حفظ می‌کنند.

## **مبدل آنلاین**

برای یک فایل گاه‌به‌گاه یا مقایسه سریع، می‌توانید از [مبدل آنلاین PPT به PPTX](https://products.aspose.app/slides/fa/conversion/ppt-to-pptx) استفاده کنید. برای تبدیل‌های مکرر، پردازش دسته‌ای یا مدیریت خطا در سطح برنامه، از API .NET استفاده کنید.

## **مقاله‌های مرتبط**

- [PPT در مقابل PPTX](/slides/fa/net/ppt-vs-pptx/)
- [Save Presentations in .NET](/slides/fa/net/save-presentation/)
- [Supported File Formats](/slides/fa/net/supported-file-formats/)
- [Open Presentations in .NET](/slides/fa/net/open-presentation/)

## **سؤالات متداول**

**آیا می‌توانم PPT را به PPTX تبدیل کنم بدون نصب Microsoft PowerPoint؟**

بله. Aspose.Slides برای .NET فایل‌های ارائه را بارگذاری و ذخیره می‌کند بدون اینکه به Microsoft PowerPoint نیاز داشته باشد.

**آیا تبدیل PPT به PPTX تمام محتوا را به‌طور دقیق حفظ می‌کند؟**

محتوای رایج ارائه را حفظ می‌کند، اما دقت کامل برای هر ویژگی قدیمی یا پشتیبانی‌نشده تضمین نمی‌شود. فایل تولیدشده را زمانی که شامل ماکروها, اشیاء OLE یا ActiveX, رسانه‌ها, انیمیشن‌های تخصصی یا فونت‌های نامعمول است، مرور کنید.

**آیا می‌توانم یک فایل PPT محافظت‌شده با رمز را تبدیل کنم؟**

بله، اگر هنگام بارگذاری فایل رمز صحیح را فراهم کنید. رمز ناقص یا نادرست باعث شکست عملیات بارگذاری می‌شود.

**آیا پس از تبدیل باید فایل PPT را حذف کنم؟**

اصل را تا زمانی که PPTX را در مشاهده‌گرها و گردش کاری مورد نیاز خود بررسی کرده‌اید، نگه دارید. این کار یک نسخه پشتیبان برای بازگردانی در صورت متفاوت شدن تبدیل ویژگی‌های قدیمی فراهم می‌کند.