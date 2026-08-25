---
title: سفارشی‌سازی فونت‌های PowerPoint در اندروید
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
- اندروید
- جاوا
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای PowerPoint با Aspose.Slides برای Android از طریق Java سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و یکپارچه باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع فونت در سطح سند ارائه دهید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه، برای مثال به PDF، تصویرها و سایر قالب‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین نحوه بازرسی پوشه‌های فونت مورد استفاده توسط Aspose.Slides و چگونگی پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندرینگ جدا از جاسازی فونت‌ها در فایل PPTX است. اگر لازم باشد فونت داخل خود ارائه ذخیره شود، باید از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های فونت متفاوتی را برای سیستم‌های نوشتاری مختلف ارجاع دهد. این نگاشت‌ها نام فونت‌ها را ذخیره می‌کنند ولی فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها به [Script-Specific Theme Fonts](/slides/fa/androidjava/script-specific-font-mappings/) مراجعه کنید و از گزینه‌های بارگذاری زیر برای در دسترس قرار دادن فونت‌های ارجاع‌شده جهت رندرینگ سازگار استفاده کنید.

{{% alert color="info" title="Note" %}}
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای جزئیات به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای جزئیات به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی مانند PDF، تصویرها و سایر قالب‌های پشتیبانی‌شده تاثیر دارد تا اسناد نهایی در محیط‌های مختلف یکدست به‌نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد استاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. برای پاک‌سازی کش فونت‌ها، متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsLoader#clearCache--) را فراخوانی کنید.

نمونه کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```java
import com.aspose.slides.*;

// پوشه‌هایی که حاوی فایل‌های فونت سفارشی هستند را تعریف کنید.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// فونت‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ارائه را رندر/صادرات کنید (مثلاً به PDF، تصویرها یا قالب‌های دیگر) با استفاده از فونت‌های بارگذاری‌شده.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از پایان کار کش فونت را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی اولیه می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) را فراهم می‌کند تا بتوانید پوشه‌های فونت را پیدا کنید. این متد پوشه‌های اضافه‌شده از طریق متد `LoadExternalFonts` و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد Java نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
import com.aspose.slides.*;

// این خط پوشه‌هایی را که فایل‌های فونت جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در یک ارائه**

Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید فونت‌های خارجی را که با ارائه استفاده می‌شوند، مشخص کنید.

این کد Java نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

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
    // فونت‌های CustomFont1، CustomFont2، و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را فراهم می‌کند تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد Java فرآیند بارگذاری فونت از آرایه بایت را نمایش می‌دهد:

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
        //      فونت خارجی در طول زمان زندگی ارائه بارگذاری می‌شود
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **سوالات متداول**

### آیا فونت‌های سفارشی بر خروجی به تمام قالب‌ها (PDF، PNG، SVG، HTML) تاثیر می‌گذارند؟

بله. فونت‌های متصل شده توسط رندرر در تمام قالب‌های خروجی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندرینگ برابر با جاسازی آن در فایل PPTX نیست. در صورتی که نیاز باشد فونت داخل فایل ارائه نگهداری شود، باید از ویژگی‌های **جاسازی صریح** استفاده کنید.

### آیا می‌توانم رفتار پیش‌فرض هنگام نبود گلیف‌های خاص در یک فونت سفارشی را کنترل کنم؟

بله. می‌توانید با پیکربندی [font substitution](/slides/fa/androidjava/font-substitution/)، [replacement rules](/slides/fa/androidjava/font-replacement/) و [fallback sets](/slides/fa/androidjava/fallback-font/) دقیقاً تعیین کنید که هنگام نبود گلیف موردنظر، از کدام فونت استفاده شود.

### آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

### در مورد مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت شرایط مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. پیش از توزیع خروجی‌ها همیشه شرایط **EULA** فونت را بررسی کنید.