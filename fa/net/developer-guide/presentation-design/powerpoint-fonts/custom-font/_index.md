---
title: سفارشی‌سازی فونت‌های پاورپوینت در .NET
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
- پوشهٔ فونت
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و هماهنگ باقی بمانند."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگیری کنید، برای یک ارائه خاص از منابع فونت در سطح سند استفاده کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری نمایید.

فونت‌های بارگیری‌شده زمانی که ارائه رندر یا استخراج می‌شود، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ خروجی یکسان ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین نحوه‌ی بررسی پوشه‌های فونت استفاده‌شده توسط Aspose.Slides و نحوه‌ی پاک‌کردن حافظهٔ کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندرکردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل ارائه ذخیره شود، باید از امکانات جاسازی فونت به‌طور صریح استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما اجازه می‌دهد این فونت‌ها را با استفاده از متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). مشاهده کنید [TrueType](https://en.wikipedia.org/wiki/TrueType).

* فونت‌های OpenType (.otf). مشاهده کنید [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی استخراج مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده تأثیر می‌گذارد، به‌طوری‌که اسناد نهایی در محیط‌های مختلف یکسان به‌نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشهٔ حاوی فایل‌های فونت را مشخص کنید.
2. متد ثابت [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) را برای بارگذاری فونت‌ها از آن پوشه‌ها فراخوانی کنید.
3. ارائه را بارگذاری و رندر/استخراج کنید.
4. با فراخوانی [FontsLoader.ClearCache](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/clearcache/) حافظهٔ کش فونت را پاک کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```cs
// پوشه‌هایی که حاوی فایل‌های فونت سفارشی هستند را تعریف کنید.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// فونت‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/استخراج کنید (مثلاً به PDF، تصاویر یا فرمت‌های دیگر).
presentation.Save("output.pdf", SaveFormat.Pdf);

// پس از اتمام کار، حافظهٔ کش فونت را پاک کنید.
FontsLoader.ClearCache();
```

{{% alert color="info" title="نکته" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**
Aspose.Slides متد [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) را فراهم می‌کند تا بتوانید پوشه‌های فونت را پیدا کنید. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های سیستم را برمی‌گرداند.

این کد C# نشان می‌دهد چگونه از [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```c#
// این خط پوشه‌هایی که برای فایل‌های فونت بررسی می‌شوند را خروجی می‌دهد.
// اینها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **مشخص‌کردن فونت‌های سفارشی مورد استفاده در یک ارائه**
Aspose.Slides ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) را برای مشخص‌کردن فونت‌های خارجی که با ارائه استفاده خواهند شد، فراهم می‌کند.

این کد C# نشان می‌دهد چگونه از ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) استفاده کنید:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // کار با ارائه
    // CustomFont1، CustomFont2، و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آنها برای ارائه در دسترس هستند
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [LoadExternalFont](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) را فراهم می‌کند تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد C# فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```c#
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

## **سوالات متداول**

**آیا فونت‌های سفارشی بر خروجی تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. فونت‌های متصل توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه باشد، باید از ویژگی‌های [جاسازی صریح](/slides/fa/net/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را وقتی یک فونت سفارشی گلیف‌های خاصی ندارند، کنترل کنم؟**

بله. می‌توانید [جایگزینی فونت](/slides/fa/net/font-substitution/)، [قواعد جایگزینی](/slides/fa/net/font-replacement/) و [مجموعه‌های fallback](/slides/fa/net/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید هنگام عدم وجود گلیف درخواست‌شده چه فونتی استفاده شود.

**آیا می‌توانم فونت‌ها را در محیط‌های Linux/Docker بدون نصب سراسری استفاده کنم؟**

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه بایت بارگذاری کنید. این کار وابستگی به دایرکتوری‌های سیستم فونت در تصویر کانتینر را حذف می‌کند.

**مورد مجوزها چگونه است—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همیشه قبل از توزیع خروجی‌ها، شرایط EULA فونت را بررسی کنید.