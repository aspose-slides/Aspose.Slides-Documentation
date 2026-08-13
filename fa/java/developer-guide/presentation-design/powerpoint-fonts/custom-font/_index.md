---
title: سفارشی‌سازی فونت‌های PowerPoint در Java
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/java/custom-font/
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
- Java
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای PowerPoint با Aspose.Slides برای Java سفارشی کنید تا ارائه‌های خود را در هر دستگاهی واضح و یکدست نگه دارید."
---
## **بررسی کلی**

Aspose.Slides به شما اجازه می‌دهد تا از فونت‌های سفارشی در ارائه‌ها بدون نصب آن‌ها بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه، برای مثال به PDF، تصویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین توضیح می‌دهد چگونه پوشه‌های فونت مورد استفاده توسط Aspose.Slides را بررسی کرده و پس از کار با فونت‌های خارجی، حافظه‌کش فونت را پاک کنید.

ثبت فونت‌های سفارشی برای رندر شدن، جدا از جاسازی فونت‌ها در فایل PPTX است. اگر لازم است فونت داخل خود ارائه ذخیره شود، باید به‌صورت صریح از ویژگی‌های جاسازی فونت استفاده کنید.

{{% alert color="info" %}} 

Aspose Slides به شما اجازه می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* فونت‌های OpenType (.otf). به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این امر بر خروجی‌های صادراتی—مانند PDF، تصویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد نهایی در محیط‌های مختلف یک‌دست به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.  
2. متد استاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادر کنید.  
4. متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader#clearCache--) را برای پاک‌سازی کش فونت فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```java
import com.aspose.slides.*;

// پوشه‌هایی که شامل فایل‌های فونت سفارشی هستند را تعریف کنید.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/خروجی بگیرید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها).
presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از اتمام کار، کش فونت را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

متد [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب مقداردهی اولیه فونت‌ها را تغییر نمی‌دهد.  
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌هایی را که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد جاوا نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
import com.aspose.slides.*;

// این خط پوشه‌هایی را که فایل‌های فونت در آن جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در یک ارائه**
Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را برای مشخص کردن فونت‌های خارجی که با ارائه استفاده می‌شوند، فراهم می‌کند.

این کد جاوا نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // کار با ارائه
    // CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آنها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت فونت‌ها به صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

این کد جاوا فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // فونت خارجی در طول مدت ارائه بارگذاری می‌شود
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **سوالات متداول**

### آیا فونت‌های سفارشی بر خروجی به همه فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت فونت برای رندر شدن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه ذخیره شود، باید به‌صورت صریح از [ویژگی‌های جاسازی](/slides/fa/java/embedded-font/) استفاده کنید.

### آیا می‌توانم رفتار fallback را هنگام عدم وجود گلیف‌های خاص در یک فونت سفارشی کنترل کنم؟

بله. می‌توانید [جایگزینی فونت](/slides/fa/java/font-substitution/)، [قواعد جایگزینی](/slides/fa/java/font-replacement/) و [مجموعه‌های fallback](/slides/fa/java/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین کنید هنگام نبود گلیف درخواست‌شده، از چه فونتی استفاده شود.

### آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب فونت‌ها در سطح سیستم از آنها استفاده کنم؟

بله. کافی است به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار وابستگی به دایرکتوری‌های فونت سیستم در ایمیج کانتینر را حذف می‌کند.

### درباره مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همواره پیش از توزیع خروجی‌ها، شرایط استفاده (EULA) فونت را بررسی کنید.