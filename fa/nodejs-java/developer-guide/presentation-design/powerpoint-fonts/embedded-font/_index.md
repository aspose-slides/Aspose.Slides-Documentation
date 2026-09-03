---
title: توکار کردن قلم‌ها در ارائه‌ها با JavaScript
linktitle: قلم‌های توکار
type: docs
weight: 40
url: /fa/nodejs-java/embedded-font/
keywords:
- افزودن قلم
- توکار کردن قلم
- توکار کردن قلم
- دریافت قلم توکار
- افزودن قلم توکار
- حذف قلم توکار
- فشرده‌سازی قلم توکار
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "قلم‌های توکار را در PowerPoint با Aspose.Slides برای Node.js از طریق Java مدیریت کنید. قلم‌ها را اضافه، بازیابی، حذف و فشرده‌سازی کنید تا ظاهر متن حفظ شود و حجم فایل کاهش یابد."
---
## **معرفی**

قلم‌های توکار داده‌های قلم را داخل یک ارائه PowerPoint ذخیره می‌کنند. هنگامی که یک نمایشگر از قلم‌های توکار پشتیبانی می‌کند، می‌تواند متن را با استفاده از آن قلم‌ها نمایش دهد حتی اگر بر روی سیستم هدف نصب نشده باشند. این به حفظ شکست خطوط، فاصله‌های متن و چینش اسلایدها کمک می‌کند.

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد تا قلم‌های توکار را با استفاده از کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/) که توسط [Presentation.getFontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getfontsmanager/) باز می‌گردد، بازیابی، اضافه و حذف کنید. همچنین می‌توانید با حذف کاراکترهایی که ارائه از آن‌ها استفاده نمی‌کند، حجم داده‌های قلم توکار را کاهش دهید.

مثال‌های زیر با فایل‌های PPTX کار می‌کنند. پیش از توکار کردن یک قلم، مطمئن شوید که داده‌های قلم برای Aspose.Slides در دسترس است و مجوز آن اجازه توکار کردن را می‌دهد.

## **دریافت و حذف قلم‌های توکار**

از [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) برای فهرست کردن قلم‌های ذخیره‌شده در یک ارائه استفاده کنید. برای حذف یک قلم، یک قلم از آن فهرست را به [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/) پاس دهید و سپس ارائه را ذخیره کنید.

مثال زیر قلم‌های توکار موجود در `EmbeddedFonts.pptx` را فهرست می‌کند و اگر Calibri موجود باشد آن را حذف مینماید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

حذف یک قلم توکار، داده‌های ذخیره‌شده آن قلم را حذف می‌کند؛ اما قلم اختصاص داده شده به متن را تغییر نمی‌دهد. اگر قلم بر روی سیستم هدف نصب شده باشد، متن می‌تواند همچنان از آن استفاده کند. در غیر این صورت، رندر ممکن است به [font substitution](/slides/fa/nodejs-java/font-substitution/) نیاز داشته باشد که می‌تواند بر چینش اثر بگذارد.

## **بازرسی داده‌های قلم و مجوزهای توکار کردن**

از کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/) برای بازرسی قلم‌ها پیش از توکار کردن آن‌ها استفاده کنید. با فراخوانی [FontsManager.getFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) قلم‌های مورد استفاده در ارائه را بازیابی می‌کنید. برای هر قلم، یک شیء [FontData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontdata/) و مقدار مورد نیاز [FontStyleType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontstyletype/) را به [FontsManager.getFontBytes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#getFontBytes) پاس می‌دهید. این متد داده‌های باینری آن سبک قلم را برمی‌گرداند یا هنگام عدم موجودیت قلم یا سبک درخواست‌شده `null` می‌دهد. نتایج `null` را به [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) پاس ندهید، زیرا این متد یک آرایه بایت می‌طلبد. در Node.js، قبل از پاس دادن به `getFontEmbeddingLevel`، آرایه جاوااسکریپت بازگردانده‌شده را با `java.newArray` به آرایه بایت جاوا تبدیل کنید.

[EmbeddingLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/embeddinglevel/) محدودیت‌های توکار کردن ذخیره‌شده در قلم را به صورت مجموعه‌ای از پرچم‌ها گزارش می‌دهد:

- `Installable` اجازه توکار کردن و نصب دائمی بر روی سیستم دیگر را می‌دهد، مشروط بر مجوز قلم.
- `Restricted` توکار کردن را ممنوع می‌کند مگر اینکه اجازه از صاحب قانونی قلم دریافت شود، زمانی که این پرچم تنها پرچم مجوز استفاده باشد.
- `PreviewPrint` اجازه استفاده موقت برای مشاهده و چاپ را می‌دهد؛ سند حاوی قلم باید فقط‌خواندنی باشد.
- `Editable` اجازه استفاده موقت را می‌دهد و امکان ویرایش و ذخیره سند را فراهم می‌کند.
- `NoSubsetting` یک محدودیت اضافی است که توکار کردن تنها زیرمجموعه‌ای از گیلیف‌ها را ممنوع می‌کند. وقتی این پرچم فعال باشد، تمام کاراکترها باید توکار شوند.
- `BitmapOnly` یک محدودیت اضافی است که فقط توکار کردن ضربه‌های بیت‌مپ را اجازه می‌دهد، نه داده‌های خطوط. اگر قلم هیچ بیت‌مپ نداشته باشد، نمی‌تواند توکار شود.

چهار مقدار اول مجوز استفاده را توصیف می‌کنند، در حالی که `NoSubsetting` و `BitmapOnly` می‌توانند با آن‌ها ترکیب شوند. برای بررسی این اصلاح‌کننده‌ها از عملیات بیتی استفاده کنید. چون مقدار `Installable` صفر است، بیت‌های مجوز استفاده را ماسک کنید و نتیجه را با `Installable` مقایسه کنید به‌جای اینکه آن را به‌عنوان پرچم بررسی کنید. قلم‌های جاری باید حداکثر یک بیت مجوز استفاده تنظیم کنند. برای سازگاری با قلم‌های قدیمی که بیش از یک بیت تنظیم کرده‌اند، ابزار زیر کم‌ترین مجوز محدودکننده را انتخاب می‌کند: ابتدا `Editable`، سپس `PreviewPrint` و در نهایت `Restricted`.

مثال زیر داده‌های عادی، بولد، ایتالیک و بولد-ایتالیک موجود برای هر قلمی که توسط `getFonts` بازگردانده می‌شود را بررسی می‌کند. سبک‌های غیرقابل دسترس، قلم‌های محدود، قلم‌های فقط بیت‌مپ، قلم‌هایی که فقط برای پیش‌نمایش و چاپ محدود شده‌اند (چون خروجی ویرایش‌پذیر می‌ماند) و قلم‌های از پیش توکار شده را نادیده می‌گیرد. اگر هر سبک موجودی دارای `NoSubsetting` باشد، تمام کاراکترهای آن خانواده قلم توکار می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این بازرسی محدودیت‌های رمزگذاری‌شده در هر فایل قلم را گزارش می‌دهد. این کار مجوزی اعطا نمی‌کند، اثبات نمی‌کند که قلم را به‌صورت قانونی به‌دست آورده‌اید و جایگزین بررسی توافق‌نامهٔ مجوز قلم قبل از توزیع نسخهٔ توکار شده نمی‌شود.

## **اضافه کردن قلم‌های توکار**

از [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) برای توکار کردن یک قلم استفاده کنید. این overloadها می‌توانند یا یک شیء [FontData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontdata/) یا یک آرایه بایت حاوی داده‌های قلم را بپذیرند. [EmbedFontCharacters](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/embedfontcharacters/) کنترل می‌کند چه کاراکترهایی گنجانده شوند:

- `All` تمام کاراکترهای قلم را توکار می‌کند. این گزینه را زمانی استفاده کنید که دریافت‌کنندگان نیاز به ویرایش ارائه و وارد کردن متن جدید داشته باشند.
- `OnlyUsed` فقط کاراکترهای استفاده‌شده در ارائه را توکار می‌کند تا حجم فایل کاهش یابد. این گزینه را برای ارائهٔ نهایی که عمدتاً برای مشاهده است، انتخاب کنید.

مثال زیر از [FontsManager.getFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getfonts/) برای بازیابی قلم‌های استفاده‌شده در `Fonts.pptx` استفاده می‌کند و آن‌هایی که هنوز توکار نشده‌اند را توکار می‌نماید. قلم‌های برای اضافه شدن باید بر روی ماشین اجرا کننده کد موجود باشند. قلم‌های توکار موجود مجموعه کاراکترهای فعلی خود را حفظ می‌کنند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فشرده‌سازی قلم‌های توکار**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/compressembeddedfonts/) داده‌های قلم توکار را با حذف کاراکترهای استفاده‌نشده کاهش می‌دهد. این متد بر روی قلم‌هایی که از پیش توکار شده‌اند عمل می‌کند، بنابراین میزان کاهش حجم به مقدار داده‌های قلم استفاده‌نشده در ارائه بستگی دارد.

مثال زیر قلم‌های موجود در `EmbeddedFonts.pptx` را فشرده می‌کند و نتیجه را به‌عنوان یک فایل جداگانه ذخیره می‌نماید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر دریافت‌کنندگان ممکن است بعداً به افزودن متن نیاز داشته باشند، فایل اصلی را نگه دارید. کاراکترهایی که در طول فشرده‌سازی حذف شده‌اند دیگر از قلم توکار در دسترس نیستند، حتی اگر در ابتدا همه کاراکترها را توکار کرده باشید.

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا یک قلم توکار در هنگام رندر هنوز جایگزین می‌شود یا نه؟**

در محیطی که ارائه را رندر می‌کنید، [FontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) را فراخوانی کنید تا ببینید Aspose.Slides چه قلم‌هایی را جایگزین خواهد کرد. همچنین تنظیمات [font substitution](/slides/fa/nodejs-java/font-substitution/) و قوانین [font fallback](/slides/fa/nodejs-java/fallback-font/) را بررسی کنید. فالبک کاراکترهای گمشده را مدیریت می‌کند، بنابراین توکار کردن یک قلم کاراکترهایی را که قلم خود آن‌ها را شامل نمی‌شود، حل نمی‌کند.

**آیا باید قلم‌های رایج مانند Arial و Calibri را توکار کنم؟**

تصمیم‌گیری را بر پایهٔ محیط هدف انجام دهید. اگر قلم‌های مورد نیاز بر روی هر دستگاهی که ارائه را باز یا رندر می‌کند موجود باشند، توکار کردن آن‌ها ممکن است اندازه فایل را بلا‌مورد افزایش دهد. اگر دریافت‌کنندگان یا سرورها ممکن است این قلم‌ها را نداشته باشند، توکار کردن آن‌ها می‌تواند به حفظ ظاهر مورد نظر کمک کند، مشروط بر این که مجوزهای آن‌ها اجازهٔ این کار را بدهد.