---
title: مدیریت پیوندهای ابرمتنی ارائه در جاوااسکریپت
linktitle: مدیریت پیوندهای ابرمتنی
type: docs
weight: 20
url: /fa/nodejs-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند ابرمتنی
- ایجاد پیوند ابرمتنی
- قالب‌بندی پیوند ابرمتنی
- حذف پیوند ابرمتنی
- به‌روزرسانی پیوند ابرمتنی
- پیوند ابرمتنی متن
- پیوند ابرمتنی اسلاید
- پیوند ابرمتنی شکل
- پیوند ابرمتنی تصویر
- پیوند ابرمتنی ویدئو
- پیوند ابرمتنی قابل‌تغییر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندهای ابرمتنی در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java، با استفاده از مثال‌های JavaScript."
---
## **معرفی**

یک پیوند ابرمتنی محتوای ارائه را به یک وب‌سایت یا یک مکان درون ارائه متصل می‌کند. در PowerPoint، پیوندهای ابرمتنی معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک فریم رسانه‌ای.
* ناوبری به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Node.js via Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صداهای آنها را کنترل کنید، خصوصیاتشان را به‌روزرسانی کنید و حذف نمایید. مثال‌های زیر نحوه کار با پیوندهای ابرمتنی بر روی عناصر منفرد و نحوه دسترسی به پیوندها در سطح ارائه، اسلاید یا فریم‑متن را نشان می‌دهند.

{{% alert color="info" title="Note" %}}

شما همچنین می‌توانید ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/fa/editor) ویرایش کنید.

{{% /alert %}} 

## **افزودن پیوندهای URL**

شما می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک فریم رسانه‌ای اختصاص دهید. عنصری که به آن پیوند ابرمتنی می‌دهید، ناحیه کلیکی را تعیین می‌کند: بخشی از متن فقط آن متن انتخاب‌شده را کلیک‌پذیر می‌سازد، در حالی که یک شکل یا فریم، شیء اسلاید را کلیک‌پذیر می‌کند.

### **افزودن پیوندهای URL به متن**

برای پیوند دادن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) بخش متن پاس دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن کلیک‌پذیر می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **افزودن پیوندهای URL به اشکال و فریم‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا فریم، متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#setHyperlinkClick) آن را فراخوانی کنید. پیوند ابرمتنی به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همین رویکرد برای فریم‌های تصویر، صوت و ویدئو نیز صادق است: پیوند را به فریم اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setTooltip) را فراخوانی کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده از پیوندهای ابرمتنی برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی بروید. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) برای پیوند متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی پیوندهای ابرمتنی**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setColorSource) کلاس [Hyperlink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink) تعیین می‌کند که آیا پیوند ابرمتنی از رنگ پیوند ابرمتنی ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ سفارشی متن، مقدار [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkColorSource) را انتخاب کنید و رنگ پر کننده بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شده است؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند ابرمتنی متنی به همان اسلاید اضافه می‌کند. اولین پیوند با پر کردن متن به رنگ قرمز است، در حالی که دومین پیوند رنگ پیش‌فرض پیوند ابرمتنی را حفظ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **صدا**

یک پیوند ابرمتنی می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که در حال پخش است متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [Hyperlink.setSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setSound) صوت مرتبط با پیوند ابرمتنی را مشخص می‌کند.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) کنترل می‌کند که آیا فعال کردن پیوند ابرمتنی صدای قبلی را متوقف کند یا خیر.

#### **افزودن صدا به پیوند ابرمتنی**

مثال زیر فایل `sampleaudio.wav` را بارگذاری می‌کند و آن را به دکمه‌ای در اسلاید اول مرتبط می‌سازد. کلیک بر دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. یک شکل دوم در همان اسلاید هنگام کلیک صدای قبلی را متوقف می‌کند، بدون اینکه عملیات ناوبری انجام دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **استخراج صدا از پیوند ابرمتنی**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صداهای پیوند ابرمتنی شکل اول را از طریق متدهای [getSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getSound) و [getBinaryData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Audio#getBinaryData) به حافظه می‌خواند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **نکته‌سنجی و تنظیمات تعامل**

پس از تخصیص پیوند ابرمتنی به متن یا شکل می‌توانید متدهای زیر کلاس [Hyperlink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setTooltip) متنی را که بیننده می‌تواند به عنوان راهنمایی برای پیوند نمایش دهد تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) فریم هدف را در یک مجموعه فریم HTML والد، در صورت وجود، مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setHistory) تعیین می‌کند که آیا فعال کردن پیوند، مقصد آن را به فهرست پیوندهای مشاهده‌شده اضافه کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) کنترل می‌کند که آیا پیوند ابرمتنی هنگام کلیک برجسته شود یا خیر.

## **حذف پیوندهای ابرمتنی از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) برای جمع‌آوری محفظه‌های پیوند ابرمتنی، شامل پیوندهای بخش متنی، پیش از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط متد [removeHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل موس‑اور نیست.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، چیدمان‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت فهرست کامل پیوندهای ابرمتنی**

پیش از توزیع یک ارائه، تعاملات آن و لینک‌های وب آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) محفظه‌های پیوند ابرمتنی را باز می‌گرداند، نه لیست مسطحی از رشته‌های URL. برای هر محفظه هم متدهای [getHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) را بررسی کنید. این دو مستقل‌اند: همان محفظه می‌تواند هر دو عمل را در اختیار داشته باشد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر محفظه داشته باشد.

فقط بررسی پیوندهای سطح شکل ممکن است پیوندهای متصل به بخش‌های متنی را از دست بدهد. به جای آن، محدودهٔ مناسب را پرس‌وجو کنید و محفظه‌های بازگردانده‌شده را نگه دارید تا پس از آن بتوانید عمل‌ها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی دامنه‌های ارائه، اسلاید و فریم‑متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries) از طریق متدهای [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) و [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) در دسترس است. هر دامنه همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) محفظه‌های دارای عمل کلیک را برمی‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) محفظه‌های دارای عمل موس‑اور را برمی‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) محفظه‌های دارای هر یک یا هر دو عمل را برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک موس‑اور فایل، ناوبری اسلاید داخلی، یک لینک موس‑اور متنی و یک عمل ماکرو است. این مثال هیچ‌یک از این عمل‌ها را اجرا نمی‌کند. همان سه پرس‌وجو در هر دامنه‌ای کار می‌کنند؛ شمارش‌ها نشان‌دهندهٔ تعداد محفظه‌ها است، نه مجموع عمل‌ها. دامنه فریم‑متن لینک‌های خود شکل محاطی را در بر نمی‌گیرد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه محفظهٔ کلیک، دو محفظهٔ موس‑اور و سه محفظهٔ دارای هر یک از عمل‌ها را گزارش می‌دهند. پرس‌وجوی فریم‑متن در هر دسته یک محفظه را گزارش می‌کند.

### **دسته‌بندی عمل‌ها و مقصدها**

از متد [Hyperlink.getActionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getActionType) برای تفسیر عمل قبل از بررسی مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkActionType) بیش از ناوبری وب را پوشش می‌دهند:

| مقدار | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | پیوند ابرمتنی خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide` | `JumpPreviousSlide` | `JumpNextSlide` | `JumpLastSlide` | `JumpLastViewedSlide` | ناوبری داخلی پیش‌فرض اسلایدشو، که در زمینهٔ اسلایدشو حل می‌شود. |
| `JumpEndShow` | `StartCustomSlideShow` | پایان نمایش جاری یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile` | `OpenPresentation` | باز کردن فایل یا ارائهٔ دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction` | `Unknown` | بدون عمل ناوبری یا عمل ناشناخته که نیاز به بررسی دارد. |

مقصدهای خارجی را از طریق [getExternalUrl](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) و مقاصد داخلی خاص را از طریق [getTargetSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) بخوانید. اعمال داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ وجود URL خالی به این معنا نیست که محفظهٔ مورد نظر عمل ندارند. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) را هنگامی که با URL نرمال‌شده متفاوت باشد، حفظ کنید و نکته‌سنجی بازگشت داده‌شده توسط [getTooltip](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#getTooltip) را در صورت موجود بودن شامل کنید.

### **گزارش، پاک‌سازی و تأیید پیوندهای ابرمتنی**

مثال JavaScript زیر یک ارائه موجود (فایلی که در بالا ساخته شد) را می‌خواند، `hyperlink-audit.json` می‌نویسد، یک سیاست را اعمال می‌کند، `hyperlink-sanitized.pptx` ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر، محفظه‌ها جمع‌آوری می‌شوند و با استفاده از برابری ارجاعی از پردازش دوبار یک محفظه جلوگیری می‌شود. پرس‌وجوهای ارائه اسلایدهای معمولی را پوشش می‌دهند؛ برای فهرست‌سازی سراسری بسته، به صراحت مسترها، چیدمان‌ها، یادداشت‌ها و مسترهای یادداشت و برگهٔ توزیع زمانی که حضور دارند نیز پرس‌وجو می‌شوند.

گزارش، اندیس اسلاید یک‌پایه و [getSlideId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide#getSlideId) را (در صورت موجود بودن) ذخیره می‌کند. متد [getSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getSlide) اسلاید مالک را برای محفظه‌های پشتیبانی‌شده فراهم می‌آورد. مسترها، چیدمان‌ها و یادداشت‌ها اندیس اسلاید عادی ندارند و با دامنهٔ خود شناسایی می‌شوند. محفظه‌های شکل و محفظه‌های قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ دیگر انواع محفظه نام کلاس زمان اجرا خود را حفظ می‌کنند. هر محفظه یک شناسهٔ گزارش‑محلی دریافت می‌کند تا دو عمل آن بتوانند مرتبط شوند. گزارش انواع عمل را به‌عنوان ثابت‌های عددی تعریف‌شده در شمارندهٔ HyperlinkActionType ذخیره می‌کند.

این سیاست کاربردی به‌طور عمدی فقط URLهای مطلق HTTPS و هدف‌های داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایل، سایر عمل‌های اسلایدشو، عمل‌های ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاسی هستند، نه حکم نهایی امنیتی Aspose.Slides. فقط HTTPS کافی نیست؛ برای برنامهٔ خود لیست سفید میزبان‌ها و بررسی‌های دیگر اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال فقط فراداده‌ها را بدون دنبال‌کردن لینک یا اجرای عمل‌ها حسابرسی می‌کند.

برای اصلاح، شیء [getHyperlinkManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getHyperlinkManager) شکل از متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحهٔ فرود ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌ها و عمل‌های موس‑اور ممنوع به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. پیش از استقرار، یک صفحهٔ جایگزین متعلق به برنامه خود انتخاب کنید.

پرچم‌گذاری خروجی گزارش از یک سیاست مرور PDF محتاطانه استفاده می‌کند: عمل‌های موس‑اور و هر چیزی به‌جز یک لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالی غیرقابل‌پشتیبانی علامت‌گذاری می‌کند. این یک نکتهٔ مرور است، نه آزمون قابلیت یا ضمانتی که لینک‌های بدون پرچم برای خروجی حفظ شوند. صادرات‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) ممکن است پیوندهای ابرمتنی را حفظ کنند، بسته به عمل، گزینه‌های صادرات و بیننده. [تصاویر](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ برای این خروجی‌ها هر عمل را هنگام حسابرسی پرچم بزنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

با ورودی که در بالا ایجاد شد، گزارش شامل پنج ردیف عمل است. لینک موس‑اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را آزمون می‌کند. یک محفظه با کلیک مجاز و موس‑اور ممنوع، عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [removeAllHyperlinks](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) که هر دو نوع فعال‌سازی را در تمام دامنهٔ انتخاب‌شده بدون توجه به سیاست حذف می‌کند، متفاوت است. تأیید در اینجا فقط عمل‌های پیوند ابرمتنی را بررسی می‌کند؛ پروژه‌های VBA نهفته، اشیاء OLE یا دیگر محتوای فعال را حذف نمی‌کند و اعتبارسنجی فایل‌های PDF یا HTML خروجی را انجام نمی‌دهد.

## **سؤال‌های متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن پیوند دهم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند ابرمتنی داخلی فقط به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش پیوند دهید.

**آیا می‌توانم پیوند ابرمتنی را به عناصر اسلاید مستر الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و چیدمان از پیوندهای ابرمتنی پشتیبانی می‌کنند. این پیوندها در هنگام نمایش اسلاید در اسلایدهایی که از مستر یا چیدمان مربوطه استفاده می‌کنند در دسترس هستند.

**آیا پیوندهای ابرمتنی هنگام صادرات به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

صادرات‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندهای ابرمتنی را حفظ کنند؛ تصاویر رستر و ویدئو این قابلیت را ندارند. برای جزئیات به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.