---
title: سفارشی‌سازی قلم‌های پاورپوینت در اندروید
linktitle: قلم سفارشی
type: docs
weight: 20
url: /fa/androidjava/custom-font/
keywords:
- قلم
- قلم سفارشی
- قلم خارجی
- بارگذاری قلم
- مدیریت قلم‌ها
- پوشه قلم
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "قلم‌ها را در اسلایدهای پاورپوینت با Aspose.Slides برای اندروید از طریق جاوا سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باقی بمانند."
---
## **بررسی کلی**

Aspose.Slides به شما امکان می‌دهد تا از قلم‌های سفارشی در ارائه‌ها استفاده کنید بدون اینکه آن‌ها را بر روی سیستم‌عامل نصب کنید. می‌توانید قلم‌ها را از پوشه‌های سفارشی بارگذاری کنید، قلم‌ها را برای یک ارائه خاص از طریق منبع‌های قلم در سطح سند فراهم کنید، یا قلم‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

قلم‌های بارگذاری‌شده هنگام رندر یا خروجی گرفتن از ارائه، به‌عنوان مثال به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به‌طور یکنواخت خروجی ارائه را در محیط‌های مختلف حفظ می‌کند. این مقاله همچنین نحوه بررسی پوشه‌های قلم مورد استفاده توسط Aspose.Slides و چگونگی پاک‌سازی کش قلم پس از کار با قلم‌های خارجی را شرح می‌دهد.

ثبت قلم‌های سفارشی برای رندر شدن مستقل از جاسازی قلم‌ها در فایل PPTX است. اگر نیازی به ذخیره‌سازی قلم داخل خود ارائه باشد، باید از ویژگی‌های جاسازی قلم به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 

Aspose Slides به شما امکان می‌دهد این قلم‌ها را با استفاده از متد [loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* قلم‌های TrueType (.ttf) و مجموعه‌های TrueType (.ttc). ببینید [TrueType](https://en.wikipedia.org/wiki/TrueType).

* قلم‌های OpenType (.otf). ببینید [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **بارگذاری قلم‌های سفارشی**

Aspose.Slides به شما اجازه می‌دهد قلم‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این موضوع بر خروجی‌های صادراتی — مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده — تأثیر می‌گذارد تا اسناد نهایی در محیط‌های مختلف یک‌دست به‌نظر برسند. قلم‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه حاوی فایل‌های قلم را مشخص کنید.  
2. متد ایستا [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) را فراخوانی کنید تا قلم‌ها از آن پوشه‌ها بارگذاری شوند.  
3. ارائه را بارگذاری و رندر/صادر کنید.  
4. برای پاک‌سازی کش قلم، متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FontsLoader#clearCache--) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری قلم را نشان می‌دهد:

```java
// پوشه‌هایی که حاوی فایل‌های قلم سفارشی هستند را تعریف کنید.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// قلم‌های سفارشی را از پوشه‌های مشخص شده بارگذاری کنید.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // ارائه را با استفاده از قلم‌های بارگذاری‌شده رندر/صادر کنید (به‌عنوان مثال به PDF، تصاویر یا سایر فرمت‌ها).
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از پایان کار کش قلم را پاک کنید.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) پوشه‌های اضافی را به مسیرهای جستجوی قلم اضافه می‌کند، اما ترتیب اولیه‌سازی قلم را تغییر نمی‌دهد.  
قلم‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر قلم پیش‌فرض سیستم‌عامل.  
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/) بارگذاری شده‌اند.

{{%/alert %}}

## **دریافت پوشه‌های قلم سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) را برای یافتن پوشه‌های قلم ارائه می‌دهد. این متد پوشه‌های اضافه‌شده توسط متد `LoadExternalFonts` و پوشه‌های قلم سیستم را برمی‌گرداند.

کد Java زیر نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```java
// این خط پوشه‌هایی را که فایل‌های قلم جستجو می‌شوند نمایش می‌دهد.
// اینها پوشه‌هایی هستند که از طریق متد LoadExternalFonts و پوشه‌های قلم سیستم اضافه شده‌اند.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **مشخص کردن قلم‌های سفارشی مورد استفاده با یک ارائه**
Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) را برای تعیین قلم‌های خارجی که با ارائه استفاده خواهند شد، فراهم می‌کند.

کد Java زیر نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) استفاده کنید:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // کار با ارائه
    // CustomFont1، CustomFont2 و قلم‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت قلم‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را برای بارگذاری قلم‌های خارجی از داده‌های باینری ارائه می‌دهد.

کد Java زیر فرآیند بارگذاری قلم از آرایه بایت را نشان می‌دهد:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // قلم خارجی در طول عمر ارائه بارگذاری شده است
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **سوالات متداول**

**آیا قلم‌های سفارشی بر صادرات به تمام فرمت‌ها (PDF, PNG, SVG, HTML) تأثیر می‌گذارند؟**

بله. قلم‌های متصل توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا قلم‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟**

خیر. ثبت یک قلم برای رندر شدن برابر با جاسازی آن در PPTX نیست. اگر نیاز دارید قلم داخل فایل ارائه ذخیره شود، باید از ویژگی‌های [جاسازی صریح](/slides/fa/androidjava/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار fallback را زمانی که یک قلم سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟**

بله. می‌توانید [جایگزینی قلم](/slides/fa/androidjava/font-substitution/)، [قوانین جایگزینی](/slides/fa/androidjava/font-replacement/) و [مجموعه‌های fallback](/slides/fa/androidjava/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید هنگام عدم وجود گلیف درخواست‌شده از کدام قلم استفاده شود.

**آیا می‌توانم در محیط‌های Linux/Docker بدون نصب قلم‌ها در سطح سیستم از آن‌ها استفاده کنم؟**

بله. می‌توانید به پوشه‌های قلم خود اشاره کنید یا قلم‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های قلم سیستمی در تصویر کانتینر را حذف می‌کند.

**در مورد مجوزها—آیا می‌توانم هر قلم سفارشی را بدون محدودیت جاسازی کنم؟**

شما مسئول رعایت قوانین مجوز قلم هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را ممنوع می‌کنند. همیشه قبل از توزیع خروجی‌ها، قرارداد مجوز (EULA) قلم را بررسی کنید.