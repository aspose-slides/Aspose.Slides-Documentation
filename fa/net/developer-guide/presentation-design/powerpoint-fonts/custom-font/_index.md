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
description: "فونت‌های اسلایدهای PowerPoint را با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و یک‌دست بمانند."
---
## **Overview**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نصب روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منبع‌های فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده زمانی که یک ارائه رندر یا خروجی گرفته می‌شود، مثلا به PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده، مورد استفاده قرار می‌گیرند. این کار به حفظ یکنواختی خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین توضیح می‌دهد چگونه پوشه‌های فونت مورد استفاده توسط Aspose.Slides را بررسی کنید و پس از کار با فونت‌های خارجی، کش فونت‌ها را پاک کنید.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر لازم است فونتی داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides به شما امکان می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد، بنابراین اسناد حاصل در محیط‌های مختلف یک‌دست به نظر می‌رسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. با فراخوانی متد استاتیک [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) فونت‌ها را از آن پوشه‌ها بارگذاری کنید.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. با فراخوانی [FontsLoader.ClearCache](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/clearcache/) کش فونت‌ها را پاک کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// پوشه‌هایی که شامل فایل‌های فونت سفارشی هستند را تعریف کنید.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// فونت‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصویرها یا فرمت‌های دیگر).
presentation.Save("output.pdf", SaveFormat.Pdf);

// پس از اتمام کار کش فونت‌ها را پاک کنید.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت‌ها را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی اولیه می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides متد [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) را ارائه می‌دهد تا بتوانید پوشه‌های فونت را پیدا کنید. این متد پوشه‌هایی را که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد C# نشان می‌دهد چگونه از [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```c#
using Aspose.Slides;

// این خط پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شود، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد C# نشان می‌دهد چگونه از ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) استفاده کنید:

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
    // CustomFont1، CustomFont2، و فونت‌هایی که از پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها می‌آیند، برای ارائه در دسترس هستند
}
```

## **Manage Fonts Externally**
Aspose.Slides متد [LoadExternalFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) را ارائه می‌دهد تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد C# فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // فونت خارجی که در طول عمر ارائه بارگذاری می‌شود
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. فونت‌های متصل‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک فونت برای رندر کردن معادل جاسازی آن در یک PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه نگهداری شود، باید از [ویژگی‌های جاسازی](/slides/fa/net/embedded-font/) به‌صورت صریح استفاده کنید.

**آیا می‌توانم رفتار پیش‌فرض (fallback) را وقتی یک فونت سفارشی گلیف‌های خاصی را ندارد، کنترل کنم؟**

بله. می‌توانید با پیکربندی [جایگزینی فونت](/slides/fa/net/font-substitution/)، [قوانین جایگزینی](/slides/fa/net/font-replacement/) و [مجموعه‌های پیش‌فرض](/slides/fa/net/fallback-font/) دقیقاً تعیین کنید که هنگام عدم موجودیت گلیف موردنظر از کدام فونت استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

> **نکته برای Linux/Docker**: هنگام فراخوانی `FontsLoader.LoadExternalFonts`، اطمینان حاصل کنید که هر ورودی در آرایه `directories` شامل مسیر غیرخالی به یک دایرکتوری موجود باشد. اگر متغیر محیطی که برای ساخت مسیر فونت استفاده می‌شود تعریف نشده یا خالی باشد، Aspose.Slides ممکن است سعی کند مقدار خالی را به عنوان مسیر کامل تفسیر کند که منجر به `System.ArgumentException` می‌شود.

**مسئله‌ٔ مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت شرایط مجوز فونت‌ها هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همواره قبل از توزیع خروجی‌ها، قرارداد مجوز کاربری (EULA) فونت را بررسی کنید.