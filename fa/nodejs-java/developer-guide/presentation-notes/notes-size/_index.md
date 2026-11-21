---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در JavaScript
linktitle: اندازه صفحه یادداشت‌ها
type: docs
weight: 10
url: /fa/nodejs-java/notes-size/
keywords:
- اندازه صفحه یادداشت‌ها
- جهت یادداشت‌ها
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه جزوه
- PowerPoint
- ارائه
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "ابعاد صفحه یادداشت‌ها را در Aspose.Slides for Node.js از طریق Java بخوانید و تغییر دهید، جهت را تغییر دهید، اندازه‌های ذخیره‌شده را تأیید کنید و یادداشت‌ها یا جزوه‌ها را به PDF و تصاویر صادر کنید."
---
## **نمای کلی**

از [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getnotessize/) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [NotesSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notessize/) برمی‌گرداند که متد [setSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notessize/setsize/) آن ابعاد صفحه را تعیین می‌کند. اگرچه نمی‌توان شیء تنظیمات را جایگزین کرد، اما می‌توانید ابعاد جدید را از طریق این متد اختصاص دهید.

عرض و ارتفاع بر حسب **نقطه** (point) مشخص می‌شوند، به‌طوری‌که ۷۲ نقطه برابر یک اینچ است. برای مثال، ۹۰۰ × ۶۰۰ نقطه معادل ۱۲٫۵ × ۸⅓ اینچ می‌باشد. این تنظیمات برای کل ارائه اعمال می‌شود، نه برای یادداشت‌های اسلاید منفرد.

| Setting | Purpose |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getnotessize/) | کنترل ابعاد صفحه یادداشت‌ها و ابعاد صفحه‌ای که برای خروجی جزوه استفاده می‌شود. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getslidesize/) | کنترل ابعاد اسلایدهای معمولی ارائه از طریق [SlideSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidesize/). |

تغییر هر یک از این تنظیمات به‌طور خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها همچنین اسلایدهای معمولی را چرخان نمی‌کند. برای تغییر اندازه اسلایدهای معمولی به [Slide Size](/slides/fa/nodejs-java/slide-size/) مراجعه کنید.

مثال‌های زیر از فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های خروجی، از ارائه‌ای که حداقل یک اسلاید با یادداشت‌های سخنران دارد استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت مقایسه کنید: صفحه‌ای که عرض‌اش بیشتر است افقی (landscape)؛ صفحه‌ای که ارتفاع‌اش بیشتر است عمودی (portrait)؛ و ابعاد مساوی صفحه‌ای مربع توصیف می‌کند. این مثال ابعاد واقعی را به‌صورت نقطه چاپ می‌کند، بدون فرض اندازهٔ استاندارد کاغذ.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **تغییر به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو طرف، از جمله اندازهٔ سفارشی کاغذ را حفظ می‌کند. شرط زیر از تغییر صفحه‌ای که قبلاً افقی است به عمودی جلوگیری می‌کند و صفحهٔ مربعی را دست‌نخورده می‌گذارد.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حالت عمودی نیز همان انتساب را زمانی که `size.getWidth() > size.getHeight()` اجرا کنید. مگر اینکه بخواهید اندازهٔ کاغذ را نیز تغییر دهید، از ابعاد A4 یا Letter استفاده نکنید.

## **تنظیم و تأیید یک اندازهٔ سفارشی برای صفحه یادداشت‌ها**

هر دو بعد را به‌طور همزمان اختصاص دهید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/save/) ارائه را ذخیره کنید. این مثال یک صفحهٔ افقی ۹۰۰ × ۶۰۰ نقطه‌ای را تنظیم می‌کند، به‌صورت PPTX ذخیره می‌کند و سپس فایل ذخیره‌شده را دوباره باز می‌کند تا مقادیر ذخیره‌ شده را بررسی کند. مقایسه با تحمل ۰٫۰۱ نقطه برای مقادیر اعشاری انجام می‌شود؛ این تضمین دقت برای هر قالب فایلی نیست.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

نتیجهٔ مورد انتظار `900 x 600 points` و `Size preserved: true` است. بررسی ارائهٔ تازه بازشده به‌جای تنظیمات در‑حافظه، صحت فایل ذخیره‌شده را تأیید می‌کند.

## **صدور یادداشت‌ها و جزوه‌ها**

ابعاد صفحه محدودهٔ موجود برای طرح‌بندی یادداشت‌ها یا جزوه‌ها را تعریف می‌کند. این تنظیمات به‌تنهایی آن طرح‌ها را فعال نمی‌سازند؛ گزینه‌های خروجی نیز باید پیکربندی شوند. خروجی اسلایدهای معمولی همچنان از ابعاد اسلایدها استفاده می‌کند.

### **صدور یادداشت‌ها به PDF و PNG**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notescommentslayoutingoptions/) را به [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) اختصاص دهید تا یادداشت‌ها در PDF گنجانده شوند. این مثال همچنین اولین اسلاید با یادداشت‌ها را به PNG رندر می‌کند با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/renderingoptions/).

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌گیرند بریده می‌شوند. PDF از صفحات ۹۰۰ × ۶۰۰ نقطه‌ای استفاده می‌کند. با مقیاس تصویر ۱ × ۱ که در زیر استفاده شده، PNG نیز ۹۰۰ × ۶۰۰ پیکسل است. نقاط هندسهٔ صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی رستر هستند که ابعادشان به مقیاس رندر نیز وابسته است.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

برای صدور PDF با یادداشت‌های طولانی، حالت [BottomFull](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/notespositions/) در صورت نیاز صفحات بیشتری اضافه می‌کند. از این حالت برای فراخوانی تصویر تک‑اسلاید بالا استفاده نکنید، زیرا آن پشتیبانی نمی‌شود. پس از تغییر اندازه، خروجی را برای بررسی قطع شدن یادداشت‌ها و مکان اشیاء موجود در notes‑master بررسی کنید؛ تغییر ابعاد صفحه به‌تنهایی تضمین نمی‌کند که تمام محتوا جا بگیرد. برای جزئیات بیشتر درباره صدور یادداشت‌ها به PDF به [Convert PowerPoint to PDF with Notes](/slides/fa/nodejs-java/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **صدور جزوه‌ها به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handoutlayoutingoptions/) برای چندین تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر یک صفحهٔ ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند و از [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/handouttype/) برای قرار دادن حداکثر چهار اسلاید در صفحه استفاده می‌کند. تنظیم پیش‌فرض افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن به‌دست می‌آید.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

تغییر اندازه صفحه، ناحیهٔ موجود برای شبکهٔ جزوه را بدون تغییر ابعاد اسلایدهای منبع تغییر می‌دهد. برای تصاویر جزوه، از [Presentation.getImages](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/getimages/) همراه با طرح‌بندی جزوه استفاده کنید، نه متد تصویر اسلاید منفرد. در Aspose.Slides، رندر جزوهٔ سطح ارائه از ابعاد صفحهٔ یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید منفرد صفحهٔ جزوه را تولید نمی‌کند. برای گزینه‌های طرح‌بندی به [Handout Mode](/slides/fa/nodejs-java/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازهٔ صفحه در مرورگرها، خروجی و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ خروجی و اندازهٔ کاغذ چاپی را جداگانه نگه دارید:

- **مرورگرهای ارائه:** یک مرورگر می‌تواند یادداشت‌ها را با قوانین طرح‌بندی خود نمایش یا چاپ کند. اگر برنامهٔ دیگری فایل را ذخیره کند، آن را باز کنید و دوباره ابعاد را بررسی کنید؛ تبدیل‌فرمت آن برنامه ممکن است آن‌ها را نرمال‌سازی کند.
- **قالب‌های خروجی:** مثال‌های PDF یادداشت‌ها و جزوه‌های بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر رستر از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. صدور اسلایدهای معمولی از اندازهٔ صفحهٔ یادداشت‌ها استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات «متناسب با صفحه» می‌توانند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهند. برای یک اندازهٔ کاغذ خاص، تنظیمات چاپگر را مطابقت دهید و پیش‌نمایش چاپ را بررسی کنید.

## **سوالات متداول**

**آیا می‌توانم اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحهٔ یادداشت‌ها یک تنظیم سطح ارائه است. اسلایدهای جداگانه می‌توانند محتوای یادداشت متفاوتی داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید ارائه نمی‌دهد.

**چرا تغییر جهت یادداشت‌ها اسلایدهای من را تغییر نداد؟**

صفحات یادداشت و اسلایدهای معمولی ابعاد مستقلی دارند. برای تغییر اندازهٔ خود اسلایدها از تنظیمات اندازهٔ اسلاید معمولی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ‌شده من اندازهٔ متفاوتی دارد؟**

ابتدا ارائهٔ ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌ها را مقایسه کنید. اگر آن‌ها تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامهٔ دیگری تنظیمات صفحه را تغییر داده است یا نه. اگر نه، طرح‌بندی خروجی، مقیاس تصویر، تنظیمات مرورگر و انتخاب کاغذ چاپگر را بررسی کنید.