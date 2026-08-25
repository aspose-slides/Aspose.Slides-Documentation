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
description: "فونت‌های اسلایدهای PowerPoint را با Aspose.Slides برای .NET سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه، برای مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این امر به حفظ یک‌دست بودن خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین نحوه بررسی پوشه‌های فونت مورد استفاده Aspose.Slides و نحوه پاک کردن کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر مستقل از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های فونت متفاوتی را برای سیستم‌های نوشتاری جداگانه ارجاع دهد. این نگاشت‌ها نام فونت را ذخیره می‌کنند اما فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها به [فونت‌های تم مخصوص اسکریپت](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید و برای فراهم کردن فونت‌های ارجاع‌شده برای رندر سازگار از گزینه‌های بارگذاری زیر استفاده کنید.

{{% alert color="info" title="Note" %}}

Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). ببینید [TrueType](https://en.wikipedia.org/wiki/TrueType).
* فونت‌های OpenType (.otf). ببینید [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد تولیدی در محیط‌های مختلف یک‌دست به‌نظر برسند. فونت‌ها از پوشه‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد ایستای [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) را برای بارگذاری فونت‌ها از آن پوشه‌ها فراخوانی کنید.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. برای پاک کردن کش فونت، متد [FontsLoader.ClearCache](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید.

نمونه کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

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

متد [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد. فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم عامل.
1. مسیرهای بارگذاری‌شده از طریق [FontsLoader](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**
Aspose.Slides متد [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌هایی را که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد C# نشان می‌دهد چگونه از [GetFontFolders](https://reference.aspose.com/slides/fa/net/aspose.slides/fontsloader/getfontfolders/) استفاده کنید:

```c#
using Aspose.Slides;

// این خط پوشه‌هایی را که برای فایل‌های فونت بررسی می‌شوند، نمایش می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در یک ارائه**
Aspose.Slides ویژگی [DocumentLevelFontSources](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/documentlevelfontsources/) را برای مشخص کردن فونت‌های خارجی که با ارائه استفاده می‌شوند، فراهم می‌کند.

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
    // فونت‌های CustomFont1، CustomFont2، و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
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
        // فونت خارجی در طول زمان ارائه بارگذاری شده است
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **سؤال‌های متداول**

**آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. فونت‌های متصل‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک فونت برای رندر همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت در داخل فایل ارائه ذخیره شود، باید از ویژگی‌های [جاسازی صریح](/slides/fa/net/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار جایگزینی را وقتی یک فونت سفارشی برخی گلیف‌ها را ندارند کنترل کنم؟**

بله. با پیکربندی [جایگزینی فونت](/slides/fa/net/font-substitution/)، [قوانین جایگزینی](/slides/fa/net/font-replacement/) و [مجموعه‌های fallback](/slides/fa/net/fallback-font/) می‌توانید دقیقاً تعیین کنید که هنگام عدم وجود گلیف درخواست‌شده، از کدام فونت استفاده شود.

**آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب سیستمی فونت‌ها از آن‌ها استفاده کنم؟**

بله. به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه بایت بارگذاری کنید. این کار هرگونه وابستگی به پوشه‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

> **تذکر برای Linux/Docker**: هنگام فراخوانی `FontsLoader.LoadExternalFonts`، اطمینان حاصل کنید که هر ورودی در آرایه `directories` مسیر غیرخالی به یک پوشه موجود را شامل شود. اگر متغیر محیطی استفاده‌شده برای ساخت مسیر فونت تعریف نشده یا خالی باشد، Aspose.Slides ممکن است مقدار خالی را به‌عنوان مسیر کامل تفسیر کند و منجر به `System.ArgumentException` شود.

**در مورد مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه پیش از توزیع خروجی‌ها، EULA فونت را مرور کنید.