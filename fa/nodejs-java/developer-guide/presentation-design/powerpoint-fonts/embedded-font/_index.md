---
title: جاسازی قلم‌ها در ارائه‌ها با JavaScript
linktitle: جاسازی قلم
type: docs
weight: 40
url: /fa/nodejs-java/embedded-font/
keywords:
- افزودن قلم
- جاسازی قلم
- جاسازی قلم
- دریافت قلم جاسازی‌شده
- افزودن قلم جاسازی‌شده
- حذف قلم جاسازی‌شده
- فشرده‌سازی قلم جاسازی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قلم‌های TrueType را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java جاسازی کنید تا رندر دقیق در تمام پلتفرم‌ها تضمین شود."
---
## **مقدمه**

**Embedded fonts in PowerPoint** برای زمانی که می‌خواهید ارائه شما در هر سیستم یا دستگاهی به‑درستی نمایش داده شود، مفید هستند. اگر به‌دلیل خلاقیت در کار از یک قلم شخص ثالث یا غیراستاندارد استفاده کرده‌اید، دلایل بیشتری برای جاسازی قلم دارید. در غیر این صورت (بدون قلم‌های جاسازی‌شده)، متن‌ها یا اعداد در اسلایدها، چیدمان، استایل و غیره ممکن است تغییر کنند یا به شکل مستطیل‌های گیج‌کننده درآیند.

کلاس‌های [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager)، [FontData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontdata/) و [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) شامل بیشتر ویژگی‌ها و متدهای مورد نیاز برای کار با قلم‌های جاسازی‌شده در ارائه‌های PowerPoint هستند.

## **دریافت یا حذف قلم‌های جاسازی‌شده از ارائه**

Aspose.Slides متد [getEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (که توسط کلاس [FontsManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FontsManager) در دسترس است) را ارائه می‌دهد تا بتوانید قلم‌های جاسازی‌شده در یک ارائه را دریافت (یا شناسایی) کنید. برای حذف قلم‌ها، متد [removeEmbeddedFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) (همین کلاس) استفاده می‌شود.

این کد JavaScript نشان می‌دهد چگونه قلم‌های جاسازی‌شده را از یک ارائه دریافت و حذف کنید:

```javascript
// یک شی Presentation ایجاد می‌کند که فایل ارائه را نشان می‌دهد
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // یک اسلاید حاوی فریم متنی که از "FunSized" جاسازی شده استفاده می‌کند را رندر می‌کند
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // تصویر را در فرمت JPEG بر روی دیسک ذخیره می‌کند
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // تمام قلم‌های جاسازی‌شده را دریافت می‌کند
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // قلم "Calibri" را پیدا می‌کند
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // قلم "Calibri" را حذف می‌کند
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // ارائه را رندر می‌کند؛ قلم "Calibri" با قلم موجودی جایگزین می‌شود
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // تصویر را در فرمت JPEG بر روی دیسک ذخیره می‌کند
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // ارائه را بدون قلم جاسازی‌شده "Calibri" بر روی دیسک ذخیره می‌کند
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن قلم‌های جاسازی‌شده به ارائه**

با استفاده از enum [EmbedFontCharacters](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/embedfontcharacters/) و دو overload متد [addEmbeddedFont](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-)، می‌توانید قانون (جاسازی) مورد نظر خود را برای افزودن قلم‌ها به یک ارائه انتخاب کنید. این کد JavaScript نشان می‌دهد چگونه قلم‌ها را به‌صورت جاسازی‌شده به یک ارائه اضافه کنید:

```javascript
// ارائه را بارگذاری می‌کند
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **فشرده‌سازی قلم‌های جاسازی‌شده**

برای این که بتوانید قلم‌های جاسازی‌شده در یک ارائه را فشرده کنید و حجم فایل را کاهش دهید، Aspose.Slides متد [compressEmbeddedFonts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) (که توسط کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) در دسترس است) را ارائه می‌دهد.

این کد JavaScript نشان می‌دهد چگونه قلم‌های PowerPoint جاسازی‌شده را فشرده کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**چگونه می‌توانم بفهمم که یک قلم خاص در ارائه با وجود جاسازی همچنان در هنگام رندر جایگزین می‌شود؟**

اطلاعات جایگزینی را در [substitution information](/slides/fa/nodejs-java/font-substitution/) در مدیر قلم‌ها و قوانین [fallback/substitution rules](/slides/fa/nodejs-java/fallback-font/) بررسی کنید: اگر قلم در دسترس نباشد یا محدود شود، یک قلم جایگزین استفاده خواهد شد.

**آیا جاسازی قلم‌های «سیستمی» مانند Arial/Calibri ارزش دارد؟**

معمولاً خیر—آنها تقریباً همیشه در دسترس هستند. اما برای قابلیت حمل کامل در محیط‌های «باریک» (Docker، یک سرور لینوکس بدون قلم‌های پیش‌نصب‌شده)، جاسازی قلم‌های سیستمی می‌تواند خطر تعویض‌های ناخواسته را از بین ببرد.