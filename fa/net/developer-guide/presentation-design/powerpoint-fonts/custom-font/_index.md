---
title: سفارشی‌سازی قلم‌های پاورپوینت در .NET
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/net/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگذاری قلم
- مدیریت قلم‌ها
- پوشه قلم
- پاورپوینت
- سند باز
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قلم‌های پاورپوینت را در اسلایدهای PowerPoint با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار بمانند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیم از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا صادرات ارائه مورد استفاده قرار می‌گیرند، برای مثال به PDF، تصویر و سایر فرمت‌های پشتیبانی‌شده. این کار به یکنواخت ماندن خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های فونت مورد استفاده توسط Aspose.Slides و نحوه پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر کردن، جدا از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌طور صریح استفاده کنید.

{{% alert color="info" %}} 
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). مشاهده [TrueType](https://en.wikipedia.org/wiki/TrueType).

* فونت‌های OpenType (.otf). مشاهده [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی صادرات—مانند PDF، تصویر و سایر فرمت‌های پشتیبانی‌شده—تاثیر می‌گذارد، به‌طوری‌که اسناد تولیدشده در محیط‌های مختلف یکدست به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.  
2. متد استاتیک [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادر کنید.  
4. برای پاک‌سازی کش فونت، متد [FontsLoader.ClearCache](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/clearcache/) را صدا بزنید.

نمونه کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// پوشه‌هایی که حاوی فایل‌های قلم سفارشی هستند را تعریف کنید.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// ارائه را با استفاده از قلم‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصویر یا فرمت‌های دیگر).
presentation.Save("output.pdf", SaveFormat.Pdf);

// پس از پایان کار، کش قلم‌ها را پاک کنید.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت‌ها را تغییر نمی‌دهد.  
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد C# نشان می‌دهد چگونه از [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```c#
using Aspose.Slides;

// این خط پوشه‌هایی را که برای فایل‌های قلم بررسی می‌شوند، خروجی می‌دهد.
// اینها پوشه‌هایی هستند که از طریق متد LoadExternalFonts و پوشه‌های قلم سیستم اضافه شده‌اند.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **مشخص کردن فونت‌های سفارشی استفاده‌شده در یک ارائه**

Aspose.Slides خصوصیت [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) را برای مشخص کردن فونت‌های خارجی که در ارائه استفاده می‌شوند فراهم می‌کند.

این کد C# نشان می‌دهد چگونه از خصوصیت [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) استفاده کنید:

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
    // CustomFont1، CustomFont2 و قلم‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آنها برای ارائه در دسترس هستند
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [LoadExternalFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

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
        // قلم خارجی در طول زمان ارائه بارگذاری می‌شود
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **سوالات متداول**

**آیا فونت‌های سفارشی بر خروجی به تمام قالب‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**  
بله. فونت‌های متصل توسط رندرکننده در تمام قالب‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**  
خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه ذخیره شود، باید از ویژگی‌های [جاسازی صریح](/slides/fa/net/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار fallback را وقتی یک فونت سفارشی برخی علامت‌ها را ندارد، کنترل کنم؟**  
بله. می‌توانید [جایگزینی فونت](/slides/fa/net/font-substitution/)، [قوانین جایگزینی](/slides/fa/net/font-replacement/) و [مجموعه‌های fallback](/slides/fa/net/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید چه فونتی در صورت نبود گلیف درخواست‌شده استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**  
بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه بایت‌ها بارگذاری کنید. این کار هر گونه وابستگی به پوشه‌های فونت سیستمی در تصویر کانتینر را حذف می‌کند.

> **Note for Linux/Docker**: هنگام فراخوانی `FontsLoader.LoadExternalFonts`، اطمینان حاصل کنید که هر ورودی در آرایه `directories` حاوی مسیر غیرخالی به یک پوشه موجود باشد. اگر متغیر محیطی استفاده‌شده برای ساخت مسیر فونت تعریف نشده یا خالی باشد، Aspose.Slides ممکن است مقدار خالی را به‌عنوان مسیر کامل تفسیر کند و منجر به `System.ArgumentException` شود.

**در مورد مجوزها چه‌طور—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**  
شما مسئول مطابقت با مجوزهای فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه قبل از توزیع خروجی‌ها، شرایط استفاده (EULA) فونت را بررسی کنید.