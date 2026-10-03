---
title: سفارشی‌سازی فونت‌های پاورپوینت در جاوا
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
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای جاوا سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار بمانند."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نیاز به نصب در سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منابع سطح‑سند فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا صادرات ارائه (مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده) استفاده می‌شوند. این کار خروجی ارائه را در محیط‌های مختلف سازگار نگه می‌دارد. این مقاله همچنین نحوه بررسی پوشه‌های فونت استفاده‌شده توسط Aspose.Slides و چگونگی پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر شدن متفاوت از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل خود ارائه ذخیره شود، باید از ویژگی‌های جاسازی فونت به طور صریح استفاده کنید.

یک تم ارائه می‌تواند برای سیستم‌های نویسی مختلف، خانواده‌های فونت متفاوتی را ارجاع دهد. این نگاشت‌ها نام فونت‌ها را ذخیره می‌کنند اما فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت این نگاشت‌ها به [Script-Specific Theme Fonts](/slides/fa/java/script-specific-font-mappings/) مراجعه کنید و برای در دسترس قرار دادن فونت‌های ارجاع‌شده برای رندر سازگار از گزینه‌های بارگذاری زیر استفاده کنید.

{{% alert color="info" title="توجه" %}}

Aspose Slides به شما اجازه می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType]((https://en.wikipedia.org/wiki/TrueType)) مراجعه کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType]((https://en.wikipedia.org/wiki/OpenType)) مراجعه کنید.

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب در سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد حاصل در محیط‌های مختلف یکسان به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را مشخص کنید.
2. متد استاتیک [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. برای پاک‌سازی کش فونت‌ها متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#clearCache--) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```java
import com.aspose.slides.*;

// پوشه‌هایی که شامل فایل‌های فونت سفارشی هستند را تعریف کنید.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// فونت‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصاویر یا فرمت‌های دیگر).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از اتمام کار کش فونت را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="توجه" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی را به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی اولیه می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) را ارائه می‌دهد تا به شما امکان پیدا کردن پوشه‌های فونت را بدهد. این متد پوشه‌هایی را که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد جاوا نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
import com.aspose.slides.*;

// این خط پوشه‌هایی را که در آن‌ها فایل‌های فونت جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های فونت سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی برای استفاده با یک ارائه**

Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده می‌شوند را مشخص کنید.

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
    // فونت‌های CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت فونت‌ها به صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را ارائه می‌دهد تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

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
        // فونت خارجی در طول زمان حیات ارائه بارگذاری شده است
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **پرسش‌های متداول**

### آیا فونت‌های سفارشی بر صادرات به تمام فرمت‌ها (PDF, PNG, SVG, HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌طور خودکار در PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندر شدن همانند جاسازی آن در یک فایل PPTX نیست. اگر نیاز به داشتن فونت داخل فایل ارائه دارید، باید از ویژگی‌های [embedding features](/slides/fa/java/embedded-font/) به‌صورت صریح استفاده کنید.

### آیا می‌توانم رفتار fallback را وقتی یک فونت سفارشی گلیف خاصی را ندارد، کنترل کنم؟

بله. با پیکربندی [font substitution](/slides/fa/java/font-substitution/)، [replacement rules](/slides/fa/java/font-replacement/) و [fallback sets](/slides/fa/java/fallback-font/) می‌توانید دقیقاً مشخص کنید که هنگام عدم وجود گلیف درخواست‌شده، کدام فونت استفاده شود.

### آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سیستمی استفاده کنم؟

جزئیًا. Aspose.Slides می‌تواند فونت‌ها را از پوشه‌های شخصی یا آرایه‌های بایت بدون نصب در سیستم استفاده کند، اما پشتیبانی فونت جاوا همچنان به حداقل یک فونت نصب‌شده در ایمیج نیاز دارد. در صورت عدم وجود، بارگذاری با خطای «Fontconfig head is null, check your fonts or fonts configuration» شکست می‌خورد. برای جزئیات بیشتر به [Deploy Fonts](/slides/fa/java/deploy-fonts/) مراجعه کنید.

### درباره لایسنس—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت قوانین لایسنس فونت‌ها هستید. شرایط متفاوت است؛ برخی لایسنس‌ها جاسازی یا استفاده تجاری را ممنوع می‌کنند. قبل از توزیع خروجی‌ها، همیشه شرایط EULA فونت را مرور کنید.