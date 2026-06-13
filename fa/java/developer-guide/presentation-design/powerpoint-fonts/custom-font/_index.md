---
title: "سفارشی‌سازی فونت‌های پاورپوینت در جاوا"
linktitle: "فونت سفارشی"
type: docs
weight: 20
url: /fa/java/custom-font/
keywords:
- "فونت"
- "فونت سفارشی"
- "فونت خارجی"
- "بارگذاری فونت"
- "مدیریت فونت‌ها"
- "پوشه فونت"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "با Aspose.Slides برای جاوا، فونت‌های اسلایدهای PowerPoint را سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باشند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد فونت‌های سفارشی را در ارائه‌ها بدون نصب آنها بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، فونت‌ها را برای یک ارائه خاص از طریق منبع‌های سطح سند ارائه دهید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری شده هنگام رندر یا خروجی گرفتن از یک ارائه، برای مثال به PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های فونت استفاده‌شده توسط Aspose.Slides و چگونگی پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر یک فونت باید در داخل ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.

* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.

{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های استفاده‌شده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی—مانند PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد تولید شده در محیط‌های مختلف یکسان به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های فونت را تعیین کنید.  
2. متد static [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را برای بارگذاری فونت‌ها از این پوشه‌ها صدا بزنید.  
3. ارائه را بارگذاری و رندر/صادرات کنید.  
4. برای پاک‌سازی کش فونت، متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FontsLoader#clearCache--) را صدا بزنید.

مثال کد زیر فرایند بارگذاری فونت را نشان می‌دهد:

```java
// پوشه‌هایی که حاوی فایل‌های فونت سفارشی هستند را تعریف کنید.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// فونت‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/صادرات کنید (مثلاً به PDF، تصویرها یا فرمت‌های دیگر).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از پایان کار کش فونت را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب مقداردهی اولیه فونت‌ها را تغییر نمی‌دهد.  
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.  
1. مسیرهای بارگذاری‌شده از طریق [FontsLoader](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **دریافت پوشه‌های فونت سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد جاوا نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
// این خط پوشه‌هایی که فایل‌های فونت در آن‌ها جستجو می‌شوند را خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts افزوده شده‌اند و پوشه‌های فونت سیستم.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در یک ارائه**

Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده می‌شوند را مشخص کنید. 

این کد جاوا نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // کار با ارائه
    // CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت فونت‌ها به صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

این کد جاوا فرایند بارگذاری فونت از آرایه بایتی را نشان می‌دهد:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // فونت خارجی در طول عمر ارائه بارگذاری شده است
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **پرسش‌های متداول**

**آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**  
بله. فونت‌های متصل‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در فایل PPTX نهایی جاسازی می‌شوند؟**  
خیر. ثبت یک فونت برای رندر کردن همانند جاسازی آن در PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه باشد، باید از ویژگی‌های [جاسازی](/slides/fa/java/embedded-font/) به‌صورت صریح استفاده کنید.

**آیا می‌توانم رفتار fallback را زمانی که یک فونت سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟**  
بله. می‌توانید با پیکربندی [جایگزینی فونت](/slides/fa/java/font-substitution/)، [قواعد جایگزینی](/slides/fa/java/font-replacement/) و [ست‌های fallback](/slides/fa/java/fallback-font/) دقیقاً مشخص کنید که وقتی گلیف مورد نظر موجود نیست، کدام فونت استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**  
بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایتی بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد پرمجوز بودن چطور—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟**  
شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همواره پیش از توزیع خروجی‌ها، شرایط استفاده (EULA) فونت را بررسی کنید.