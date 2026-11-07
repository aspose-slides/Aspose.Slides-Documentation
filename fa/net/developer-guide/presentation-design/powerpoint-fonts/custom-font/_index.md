---
title: سفارشی‌سازی فونت‌های PowerPoint در .NET
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/net/custom-font/
keywords:
- فونت
- فونت سفارشی
- فونت خارجی
- بارگذاری فونت
- مدیریت فونت‌ها
- پوشه فونت
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فونت‌های اسلایدهای PowerPoint را با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و یکدست باقی بمانند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب در سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت سطوح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا استخراج یک ارائه، برای مثال به PDF، تصاویر و سایر قالب‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ یکسانی خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین توضیح می‌دهد چگونه پوشه‌های فونت مورد استفاده توسط Aspose.Slides را بررسی کنید و پس از کار با فونت‌های خارجی، حافظهٔ کش فونت را پاک کنید.

ثبت فونت‌های سفارشی برای رندر شدن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر نیاز باشد فونت داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

یک قالب ارائه می‌تواند به خانواده‌های فونت مختلف برای سیستم‌های نوشتاری جداگانه ارجاع دهد. این نگاشت‌ها نام‌های فونت را ذخیره می‌کنند اما فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها، به [فونت‌های قالب مخصوص اسکریپت](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید و برای رندر همسان، از گزینه‌های بارگذاری زیر استفاده کنید تا فونت‌های ارجاع‌شده در دسترس باشند.

{{% alert color="info" title="Note" %}}
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب در سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر قالب‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد تولیدشده در محیط‌های مختلف یکسان به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که حاوی فایل‌های فونت هستند را مشخص کنید.
2. متد استاتیک [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) را فراخوانی کنید تا فونت‌ها را از آن پوشه‌ها بارگذاری کنید.
3. ارائه را بارگذاری کرده و رندر/صادرات کنید.
4. متد [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید تا کش فونت پاک شود.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Define folders that contain custom font files.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Load custom fonts from the specified folders.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Clear the font cache after the work is finished.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد. فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) بارگذاری می‌شوند.
{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) را فراهم می‌کند تا به شما امکان یافتن پوشه‌های فونت را بدهد. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد C# نشان می‌دهد چگونه از [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```c#
using Aspose.Slides;

// این خط پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **مشخص کردن فونت‌های سفارشی استفاده‌شده در یک ارائه**

Aspose.Slides ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد C# نشان می‌دهد چگونه از ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) استفاده کنید:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // کار با ارائه
    // CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts & global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) را فراهم می‌کند تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد C# نشان می‌دهد فرآیند بارگذاری فونت از آرایه بایت:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // فونت خارجی در طول عمر ارائه بارگذاری می‌شود
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

برای اینکه یک فونت ثبت‌شدهٔ مطابق در زمان استخراج در اولویت باشد بدون حذف فونت جاسازی‌شده، به [ترجیح فونت‌های ثبت‌شده نسبت به فونت‌های جاسازی‌شده](/slides/fa/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (‏.NET 26.11 یا بالاتر) مراجعه کنید.

## **FAQ**

**آیا فونت‌های سفارشی بر خروجی به تمام قالب‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. فونت‌های متصل توسط رندرر در تمام قالب‌های صادراتی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک فونت برای رندر شدن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه ذخیره شود، باید از [ویژگی‌های جاسازی](/slides/fa/net/embedded-font/) صریحاً استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را زمانی که یک فونت سفارشی برخی گلیف‌ها را ندارند، کنترل کنم؟**

بله. می‌توانید [جایگزینی فونت](/slides/fa/net/font-substitution/)، [قوانین جایگزینی](/slides/fa/net/font-replacement/) و [مجموعه‌های جایگزین](/slides/fa/net/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید هنگام عدم وجود گلیف درخواست‌شده از کدام فونت استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سیستم‌wide استفاده کنم؟**

بله. به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به پوشه‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

> **توجه برای Linux/Docker**: هنگام فراخوانی `FontsLoader.LoadExternalFonts`، اطمینان حاصل کنید که هر ورودی در آرایهٔ `directories` شامل مسیر غیرخالی به یک دایرکتوری موجود باشد. اگر متغیر محیطی استفاده‌شده برای ساخت مسیر فونت تعریف نشده یا خالی باشد، Aspose.Slides ممکن است سعی کند مقدار خالی را به‌عنوان مسیر کامل تفسیر کند که منجر به `System.ArgumentException` می‌شود.

**مسئلهٔ مجوز—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت مجوزهای فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همیشه قبل از توزیع خروجی‌ها، توافق‌نامهٔ کاربری نهایی (EULA) فونت را بررسی کنید.