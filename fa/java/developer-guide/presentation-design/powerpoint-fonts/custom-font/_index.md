---
title: سفارشی‌سازی قلم‌های PowerPoint در Java
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/java/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگذاری قلم
- مدیریت قلم‌ها
- پوشه قلم
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قلم‌ها را در اسلایدهای PowerPoint با Aspose.Slides برای Java سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و یکسان باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا قلم‌های سفارشی را در ارائه‌ها بدون نصب آن‌ها بر روی سیستم‌عامل استفاده کنید. می‌توانید قلم‌ها را از پوشه‌های دلخواه بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منبع قلم سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه استفاده می‌شوند، به‌عنوان مثال به PDF، تصویر و سایر قالب‌های پشتیبانی‌شده. این کار به حفظ یکپارچگی خروجی ارائه در محیط‌های مختلف کمک می‌کند. مقاله همچنین نحوهٔ بررسی پوشه‌های قلم مورد استفاده توسط Aspose.Slides و روش پاک‌سازی کش قلم پس از کار با قلم‌های خارجی را شرح می‌دهد.

ثبت قلم‌های سفارشی برای رندر، جدا از جاسازی قلم‌ها در فایل PPTX است. اگر نیاز باشد قلم در داخل خود ارائه ذخیره شود، باید از ویژگی‌های جاسازی قلم به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های قلم متفاوتی را برای سیستم‌های نوشتاری مختلف ارجاع دهد. این نگاشت‌ها نام قلم‌ها را ذخیره می‌کنند اما قلم‌ها را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها به [قلم‌های تم ویژه اسکریپت](/slides/fa/java/script-specific-font-mappings/) مراجعه کنید و برای فراهم شدن رندر یکسان از گزینه‌های بارگذاری زیر استفاده کنید.

{{% alert color="info" title="نکته" %}}

Aspose Slides به شما اجازه می‌دهد این قلم‌ها را با استفاده از روش [loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* قلم‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد قلم‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این کار بر خروجی‌های صادرشده—مانند PDF، تصاویر و سایر قالب‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد نهایی در محیط‌های مختلف یکسان به‌نظر برسند. قلم‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که حاوی فایل‌های قلم هستند را مشخص کنید.  
2. متد استاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادر کنید.  
4. برای پاک‌سازی کش قلم‌ها، متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader#clearCache--) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری قلم را نشان می‌دهد:

```java
import com.aspose.slides.*;

// پوشه‌هایی که حاوی فایل‌های قلم سفارشی هستند را تعریف کنید.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ارائه را با قلم‌های بارگذاری‌شده رندر/خروجی بگیرید (مثلاً به PDF، تصویر یا سایر قالب‌ها).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از اتمام کار کش قلم‌ها را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="نکته" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافه به مسیرهای جستجوی قلم می‌افزاید، اما ترتیب اولیه‌سازی قلم‌ها را تغییر نمی‌دهد.  
قلم‌ها به ترتیب زیر اولیه‌سازی می‌شوند:

1. مسیر قلم پیش‌فرض سیستم‌عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) را فراهم می‌کند تا بتوانید پوشه‌های قلم را پیدا کنید. این متد پوشه‌هایی را که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های قلم سیستم را برمی‌گرداند.

این کد Java نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
import com.aspose.slides.*;

// این خط پوشه‌هایی را که فایل‌های قلم در آن جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن قلم‌های سفارشی استفاده‌شده با یک ارائه**
Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید قلم‌های خارجی که با ارائه استفاده می‌شوند را تعیین کنید.

این کد Java نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

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
    // قلم‌های CustomFont1، CustomFont2 و قلم‌های موجود در پوشه‌های assets\fonts & global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت قلم‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را فراهم می‌کند تا بتوانید قلم‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد Java فرایند بارگذاری قلم از آرایه بایت را نشان می‌دهد:

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
        // قلم خارجی در طول زمان حیات ارائه بارگذاری می‌شود
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **سوالات متداول**

### آیا قلم‌های سفارشی بر خروجی به تمام قالب‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. قلم‌های متصل توسط رندرر در تمام قالب‌های خروجی استفاده می‌شوند.

### آیا قلم‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت قلم برای رندر شدن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه ذخیره شود، باید از ویژگی‌های [جاسازی صریح](/slides/fa/java/embedded-font/) استفاده کنید.

### آیا می‌توانم رفتار بازگردانی (fallback) را وقتی یک قلم سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟

بله. با پیکربندی [جایگزینی قلم](/slides/fa/java/font-substitution/)، [قوانین جایگزینی](/slides/fa/java/font-replacement/) و [مجموعه‌های بازگردانی](/slides/fa/java/fallback-font/) می‌توانید دقیقاً تعیین کنید که چه قلمی زمانی که گلیف درخواستی موجود نیست، استفاده شود.

### آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب قلم‌ها در سطح سیستم از آن‌ها استفاده کنم؟

بله. می‌توانید به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه بایت بارگذاری کنید. این کار هر وابستگی به پوشه‌های قلم سیستم در تصویر کانتینر را حذف می‌کند.

### درباره مجوزها—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت مجوزهای قلم هستید. شرایط می‌تواند متفاوت باشد؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه قبل از توزیع خروجی‌ها، شرایط استفاده (EULA) قلم را بررسی کنید.