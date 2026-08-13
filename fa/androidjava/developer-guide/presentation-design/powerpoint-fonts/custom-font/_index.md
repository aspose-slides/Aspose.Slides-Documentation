---
title: سفارشی‌سازی فونت‌های پاورپوینت در Android
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای PowerPoint با Aspose.Slides برای Android از طریق Java سفارشی کنید تا ارائه‌های خود را در هر دستگاهی واضح و یکدست نگه دارید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها استفاده کنید بدون آن‌که آن‌ها را بر روی سیستم عامل نصب کنید. شما می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده زمانی که یک ارائه رندر یا صادر می‌شود، مورد استفاده قرار می‌گیرند، به عنوان مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده. این کمک می‌کند تا خروجی ارائه در محیط‌های مختلف یکدست باشد. این مقاله همچنین چگونگی بررسی پوشه‌های فونت مورد استفاده توسط Aspose.Slides و نحوه پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر نیاز باشد فونت در داخل ارائه ذخیره شود، از قابلیت‌های جاسازی فونت به‌صورت صریح استفاده کنید.

{{% alert color="info" %}} 

Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این مورد بر خروجی صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد، به طوری که اسناد نهایی در محیط‌های مختلف یکسان به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که شامل فایل‌های فونت هستند را مشخص کنید.  
2. متد ایستاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادرات کنید.  
4. متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsLoader#clearCache--) را فراخوانی کنید تا کش فونت پاک‌سازی شود.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```java
import com.aspose.slides.*;

// پوشه‌هایی که شامل فایل‌های فونت سفارشی هستند را تعریف کنید.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// فونت‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    //    ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    //        پس از اتمام کار کش فونت را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.  
فونت‌ها به ترتیب زیر اولیه‌سازی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) را فراهم می‌کند تا به شما امکان یافتن پوشه‌های فونت را بدهد. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد Java نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
import com.aspose.slides.*;

// این خط پوشه‌هایی را که در آن‌ها فایل‌های فونت جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص‌کردن فونت‌های سفارشی مورد استفاده در یک ارائه**

Aspose.Slides خاصیت [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد Java نشان می‌دهد چگونه از خاصیت [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

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
    // فونت‌های CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را فراهم می‌کند تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد Java فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

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
        // فونت خارجی در طول زمان ارائه بارگذاری شده است
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **سوالات متداول**

### آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در یک PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه ذخیره شود، باید از [قابلیت‌های جاسازی](/slides/fa/androidjava/embedded-font/) به‌صورت صریح استفاده کنید.

### آیا می‌توانم رفتار فالبک را وقتی یک فونت سفارشی گلیف‌های خاصی ندارد کنترل کنم؟

بله. با پیکربندی [جایگزینی فونت](/slides/fa/androidjava/font-substitution/)، [قواعد جایگزینی](/slides/fa/androidjava/font-replacement/) و [مجموعه‌های فالبک](/slides/fa/androidjava/fallback-font/) می‌توانید دقیقاً تعیین کنید هنگام عدم وجود گلیف درخواست‌شده کدام فونت استفاده شود.

### آیا می‌توانم از فونت‌ها در کانتینرهای لینوکس/دوکر بدون نصب سراسری استفاده کنم؟

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هر گونه وابستگی به دایرکتوری‌های سیستم‌عامل در تصویر کانتینر را حذف می‌کند.

### درباره مجوزها چه می‌توان گفت—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه قبل از توزیع خروجی‌ها، شرایط استفاده (EULA) فونت را مرور کنید.