---
title: سفارشی‌سازی فونت‌های پاورپوینت در جاوااسکریپت
linktitle: فونت سفارشی
type: docs
weight: 20
url: /fa/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "فونت‌ها را در اسلایدهای پاورپوینت با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق جاوا سفارشی کنید تا ارائه‌های شما در هر دستگاهی واضح و سازگار باشند."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد تا فونت‌های سفارشی را در ارائه‌ها بدون نصب آن‌ها بر روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، برای یک ارائه خاص از طریق منبع‌های سطح‌سندی فونت‌ها فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگام رندر یا استخراج ارائه، برای مثال به PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین روش بررسی پوشه‌های فونتی که توسط Aspose.Slides استفاده می‌شوند و نحوه پاک‌سازی کش فونت پس از کار با فونت‌های خارجی را توضیح می‌دهد.

ثبت فونت‌های سفارشی برای رندر جدا از تعبیه فونت‌ها در فایل PPTX است. اگر فونتی باید داخل خود ارائه ذخیره شود، باید از ویژگی‌های تعبیه فونت به‌صورت صریح استفاده کنید.

{{% alert color="primary" %}} 
Aspose Slides به شما اجازه می‌دهد این فونت‌ها را با استفاده از روش [loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای جزئیات به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای جزئیات به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما اجازه می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب آن‌ها بر روی سیستم بارگذاری کنید. این کار بر خروجی‌های استخراجی—مانند PDF، تصویرها و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد تا اسناد حاصل در محیط‌های مختلف سازگار به‌نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه که حاوی فایل‌های فونت هستند را مشخص کنید.
2. روش ثابت [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) را برای بارگذاری فونت‌ها از آن پوشه‌ها فراخوانی کنید.
3. ارائه را بارگذاری و رندر/استخراج کنید.
4. برای پاک‌سازی کش فونت، [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید.

مثال کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```js
// پوشه‌هایی که حاوی فایل‌های فونت سفارشی هستند را تعریف کنید.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// فونت‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // ارائه را با استفاده از فونت‌های بارگذاری‌شده رندر/استخراج کنید (مثلاً به PDF، تصویرها یا سایر فرمت‌ها).
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از اتمام کار کش فونت را پاک کنید.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
متد [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) پوشه‌های اضافی به مسیرهای جستجوی فونت اضافه می‌کند، اما ترتیب اولیه‌سازی فونت را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت‌های سیستم‌عامل.
2. مسیرهایی که توسط [FontsLoader](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **دریافت پوشه فونت‌های سفارشی**
Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) را برای یافتن پوشه‌های فونت فراهم می‌کند. این متد پوشه‌های اضافه شده از طریق متد `LoadExternalFonts` و پوشه‌های فونت سیستم را بر می‌گرداند.

```javascript
// این خط پوشه‌هایی را که در آن‌ها فایل‌های فونت جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts و پوشه‌های فونت سیستم اضافه شده‌اند.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی استفاده‌شده با ارائه**
Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) را برای مشخص کردن فونت‌های خارجی که با ارائه استفاده خواهند شد، فراهم می‌کند.

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // کار با ارائه
    // فونت‌های CustomFont1، CustomFont2 و فونت‌های موجود در پوشه‌های assets\fonts و global\fonts و زیرپوشه‌های آن‌ها برای ارائه در دسترس هستند
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت فونت‌ها به‌صورت خارجی**

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را برای بارگذاری فونت‌های خارجی از داده‌های باینری فراهم می‌کند.

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // فونت خارجی در طول عمر ارائه بارگذاری شد
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **پرسش‌های متداول**

**آیا فونت‌های سفارشی بر خروجی به تمام فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟**

بله. فونت‌های متصل‌شده توسط رندرر در تمام فرمت‌های خروجی استفاده می‌شوند.

**آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی تعبیه می‌شوند؟**

خیر. ثبت فونت برای رندر با تعبیه آن در PPTX یکسان نیست. اگر نیاز دارید فونت داخل فایل ارائه نگه‌داری شود، باید از ویژگی‌های صریح [embedding features](/slides/fa/nodejs-java/embedded-font/) استفاده کنید.

**آیا می‌توانم رفتار fallback را زمانی که یک فونت سفارشی برخی گلیف‌ها را ندارد، کنترل کنم؟**

بله. می‌توانید [font substitution](/slides/fa/nodejs-java/font-substitution/)، [replacement rules](/slides/fa/nodejs-java/font-replacement/) و [fallback sets](/slides/fa/nodejs-java/fallback-font/) را پیکربندی کنید تا دقیقاً تعیین شود در صورت عدم وجود گلیف درخواستی کدام فونت استفاده شود.

**آیا می‌توانم فونت‌ها را در کانتینرهای Linux/Docker بدون نصب سراسری استفاده کنم؟**

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایتی بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

**در مورد لایسنس‌ها چه می‌شود—آیا می‌توانم هر فونت سفارشی را بدون محدودیت تعبیه کنم؟**

شما مسئول رعایت شرایط لایسنس فونت‌ها هستید. شرایط متفاوت است؛ برخی لایسنس‌ها تعبیه یا استفاده تجاری را ممنوع می‌سازند. همواره قبل از توزیع خروجی‌ها، قوانین استفاده (EULA) فونت را بررسی کنید.