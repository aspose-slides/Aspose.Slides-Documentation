---
title: "سفارشی‌سازی قلم‌های پاورپوینت در جاوااسکریپت"
linktitle: "قلم سفارشی"
type: docs
weight: 20
url: /fa/nodejs-java/custom-font/
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
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "قلم‌های پاورپوینت را در اسلایدهای PowerPoint با استفاده از جاوااسکریپت و Aspose.Slides برای Node.js از طریق Java سفارشی کنید تا ارائه‌های خود را در هر دستگاهی واضح و سازگار نگه دارید."
---
## **نمای کلی**

Aspose.Slides به شما امکان می‌دهد تا از فونت‌های سفارشی در ارائه‌ها بدون نصب آنها روی سیستم‌عامل استفاده کنید. می‌توانید فونت‌ها را از پوشه‌های سفارشی بارگذاری کنید، برای یک ارائه خاص از طریق منابع فونت سطح سند فونت‌ها را فراهم کنید، یا فونت‌های خارجی را مستقیماً از داده‌های باینری بارگذاری کنید.

فونت‌های بارگذاری‌شده هنگامی که یک ارائه رندر یا صادر می‌شود، مثلاً به PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده، استفاده می‌شوند. این کار به حفظ سازگاری خروجی ارائه در محیط‌های مختلف کمک می‌کند. این مقاله همچنین توضیح می‌دهد چگونه پوشه‌های فونت مورد استفاده توسط Aspose.Slides را بررسی کنید و پس از کار با فونت‌های خارجی، کش فونت‌ها را پاک کنید.

ثبت فونت‌های سفارشی برای رندر کردن جدا از جاسازی فونت‌ها در فایل PPTX است. اگر فونتی باید داخل خود ارائه ذخیره شود، از ویژگی‌های جاسازی فونت به‌صورت صریح استفاده کنید.

یک تم ارائه می‌تواند خانواده‌های فونت مختلفی را برای سیستم‌های نوشتاری فردی ارجاع دهد. این نگاشت‌ها نام‌های فونت را ذخیره می‌کنند اما فایل‌های فونت را نصب یا بارگذاری نمی‌کنند. برای مدیریت نگاشت‌ها، به [Script-Specific Theme Fonts](/slides/fa/nodejs-java/script-specific-font-mappings/) مراجعه کنید و از گزینه‌های بارگذاری زیر برای در دسترس قرار دادن فونت‌های ارجاع‌شده جهت رندر سازگار استفاده کنید.

{{% alert color="info" title="Note" %}}
Aspose Slides به شما امکان می‌دهد این فونت‌ها را با استفاده از روش [loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید:

* فونت‌های TrueType (.ttf) و TrueType Collection (.ttc). برای اطلاعات بیشتر به [TrueType](https://en.wikipedia.org/wiki/TrueType) مراجعه کنید.
* فونت‌های OpenType (.otf). برای اطلاعات بیشتر به [OpenType](https://en.wikipedia.org/wiki/OpenType) مراجعه کنید.
{{% /alert %}}

## **بارگذاری فونت‌های سفارشی**

Aspose.Slides به شما امکان می‌دهد فونت‌های مورد استفاده در یک ارائه را بدون نصب بر روی سیستم بارگذاری کنید. این کار بر خروجی صادراتی—مانند PDF، تصاویر و سایر فرمت‌های پشتیبانی‌شده—تأثیر می‌گذارد به‌طوری که اسناد حاصل در محیط‌های مختلف یکدست به نظر برسند. فونت‌ها از دایرکتوری‌های سفارشی بارگذاری می‌شوند.

1. یک یا چند پوشه شامل فایل‌های فونت را مشخص کنید.
2. متد ایستا [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) را فراخوانی کنید تا فونت‌ها از آن پوشه‌ها بارگذاری شوند.
3. ارائه را بارگذاری و رندر/صادرات کنید.
4. متد [FontsLoader.clearCache](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/clearcache/) را فراخوانی کنید تا کش فونت‌ها پاک شود.

نمونه کد زیر فرآیند بارگذاری فونت را نشان می‌دهد:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// پوشه‌هایی که شامل فایل‌های قلم سفارشی هستند را تعریف کنید.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// قلم‌های سفارشی را از پوشه‌های مشخص‌شده بارگذاری کنید.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // ارائه را رندر/صادرات کنید (مثلاً به PDF، تصاویر یا سایر فرمت‌ها) با استفاده از قلم‌های بارگذاری‌شده.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // پس از اتمام کار کش قلم‌ها را پاک کنید.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) مسیرهای جستجوی فونت را با پوشه‌های اضافی گسترش می‌دهد، اما ترتیب اولیه‌سازی فونت‌ها را تغییر نمی‌دهد.
فونت‌ها به ترتیب زیر مقداردهی می‌شوند:

1. مسیر پیش‌فرض فونت سیستم‌عامل.
1. مسیرهایی که از طریق [FontsLoader](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/) بارگذاری شده‌اند.
{{%/alert %}}

## **به‌دست آوردن پوشه فونت‌های سفارشی**

Aspose.Slides متد [getFontFolders](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) را فراهم می‌کند تا به شما امکان یافتن پوشه‌های فونت را بدهد. این متد پوشه‌هایی که از طریق متد `LoadExternalFonts` اضافه شده‌اند و پوشه‌های فونت سیستم را برمی‌گرداند.

این کد JavaScript نشان می‌دهد چگونه از [getFontFolders](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// این خط پوشه‌هایی را که در آن‌ها فایل‌های قلم جستجو می‌شوند، خروجی می‌دهد.
// این‌ها پوشه‌هایی هستند که از طریق متد LoadExternalFonts اضافه شده‌اند و پوشه‌های قلم سیستم.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **مشخص کردن فونت‌های سفارشی مورد استفاده در ارائه**

Aspose.Slides ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) را فراهم می‌کند تا بتوانید فونت‌های خارجی که با ارائه استفاده خواهند شد را مشخص کنید.

این کد JavaScript نشان می‌دهد چگونه از ویژگی [setDocumentLevelFontSources](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

Aspose.Slides متد [loadExternalFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) را فراهم می‌کند تا بتوانید فونت‌های خارجی را از داده‌های باینری بارگذاری کنید.

این کد JavaScript فرآیند بارگذاری فونت از آرایه بایت را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // قلم خارجی در طول حیات ارائه بارگذاری می‌شود
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **پرسش‌های متداول**

### آیا فونت‌های سفارشی بر صادرات به همه فرمت‌ها (PDF، PNG، SVG، HTML) تأثیر می‌گذارند؟

بله. فونت‌های متصل شده توسط رندرر در تمام فرمت‌های صادراتی استفاده می‌شوند.

### آیا فونت‌های سفارشی به‌صورت خودکار در PPTX نهایی جاسازی می‌شوند؟

خیر. ثبت یک فونت برای رندر کردن معادل جاسازی آن در یک PPTX نیست. اگر نیاز دارید فونت داخل فایل ارائه باشد، باید از [ویژگی‌های جاسازی](/slides/fa/nodejs-java/embedded-font/) صریح استفاده کنید.

### آیا می‌توانم رفتار جایگزینی را وقتی یک فونت سفارشی گلیف‌های خاصی را ندارد کنترل کنم؟

بله. می‌توانید [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/)، [قواعد جایگزینی](/slides/fa/nodejs-java/font-replacement/) و [مجموعه‌های fallback](/slides/fa/nodejs-java/fallback-font/) را پیکربندی کنید تا دقیقاً مشخص کنید در صورت عدم وجود گلیف مورد درخواست، از چه فونتی استفاده شود.

### آیا می‌توانم در کانتینرهای Linux/Docker بدون نصب سراسری فونت‌ها از آنها استفاده کنم؟

بله. می‌توانید به پوشه‌های فونت خود اشاره کنید یا فونت‌ها را از آرایه‌های بایت بارگذاری کنید. این کار هرگونه وابستگی به دایرکتوری‌های فونت سیستم در تصویر کانتینر را حذف می‌کند.

### دربارهٔ مجوزها—آیا می‌توانم هر فونت سفارشی را بدون محدودیت جاسازی کنم؟

شما مسئول رعایت قوانین مجوز فونت هستید. شرایط متفاوت است؛ برخی مجوزها جاسازی یا استفاده تجاری را منع می‌کنند. همیشه پیش از توزیع خروجی‌ها، موافقت‌نامهٔ کاربری (EULA) فونت را بررسی کنید.