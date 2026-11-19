---
title: مدیریت پیوندهای ارائه در جاوااسکریپت
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/nodejs-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- به‌روزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدئو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java، با استفاده از مثال‌های جاوااسکریپت."
---
## **مقدمه**

یک پیوند (hyperlink) محتویات ارائه را به یک وب‌سایت یا موقعیتی داخل ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از طریق متن، یک شکل یا یک قاب رسانه‌ای.
* حرکت به اسلاید دیگر، مثلاً از فهرست مطالب.

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آنها را کنترل کنید، ویژگی‌هایشان را به‌روزرسانی کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با پیوندهای جداگانه روی عناصر کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا قاب‑متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}}

## **اضافه کردن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که پیوند به آن اختصاص می‌یابد، منطقهٔ قابل کلیک را تعیین می‌کند: بخشی از متن فقط متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب کل شیء اسلاید را لینک می‌کند.

برای ارائه‌های حاوی پیوندهای نسبی، به [Manage the Hyperlink Base](/slides/fa/nodejs-java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایهٔ سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **اضافه کردن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) بخش متن پاس دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

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

### **اضافه کردن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

متد [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) را روی مستطیل فراخوانی کنید تا کل ناحیهٔ آن قابل کلیک شود. از [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) برای نمایش یک نکته به خواننده هنگام ورود ماوس بر روی مستطیل استفاده کنید. هر دو متد برای قاب‌های تصویر، صدا و ویدئو نیز اعمال می‌شوند.

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

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی بروند. مثال زیر از [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) برای لینک کردن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندها**

می‌توانید رنگ متن لینک‌شده را تغییر دهید، هنگام فعال‌سازی یک پیوند صدا را پخش یا متوقف کنید و نکتهٔ راهنمایی (tooltip) را که هنگام رفتن ماوس ظاهر می‌شود تنظیم کنید.

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) از [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) تعیین می‌کند آیا پیوند از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) را انتخاب کنید و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) پیوند اول را به رنگ پر شدن قرمز بخش متن تنظیم می‌کند. پیوند دوم رنگ پیوندهای ارائه را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که قبلاً در حال پخش است را متوقف کند. از متدهای زیر برای تنظیم این رفتارها استفاده کنید:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) صدا را به پیوند اختصاص می‌دهد.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) تعیین می‌کند آیا فعال کردن پیوند صدای قبلی را متوقف می‌کند یا نه.

#### **اضافه کردن صدای پیوند**

دکمهٔ اسلاید اول از [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) برای پخش صدا از `sampleaudio.wav` هنگام کلیک کاربر استفاده می‌کند. در اسلاید دوم، دکمهٔ دیگری از [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) برای متوقف کردن پخش و نگه داشتن کاربر در همان اسلاید بهره می‌برد.

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

#### **استخراج صدای پیوند**

مثال زیر ارائهٔ ساخته‌شده در بالا را باز می‌کند و صدای پیوند اولین شکل را از طریق [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) و [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) در حافظه می‌خواند.

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

### **نکتهٔ راهنمایی و تنظیمات تعامل**

پس از اختصاص پیوند به متن یا یک شکل می‌توانید متدهای زیر از [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) متنی را که بیننده می‌تواند به‌عنوان راهنمایی برای پیوند نمایش دهد تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) قاب هدف را درون یک فریم‌ست HTML والد مشخص می‌کند، اگر قابل اعمال باشد.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) کنترل می‌کند آیا فعال‌سازی پیوند، مقصد آن را به فهرست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) تعیین می‌کند آیا پیوند هنگام کلیک برجسته شود یا خیر.

## **حذف پیوندها از ارائه‌ها**

از [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) برای جمع‌آوری کانتینرهای پیوند، شامل پیوندهای بخش‑متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف هم‌زمان عمل ماوس‑اور نیست.

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

برای حذف بدون شرط، [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) هر دو نوع فعال‌سازی را در دامنهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لِی آوت‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی پیوندها پیش از جایگزینی متن SmartArt**

هنگامی که یک پاراگراف در گرهٔ SmartArt موجود را جایگزین می‌کنید، پاک‌سازی بخش‑متن‌های آن می‌تواند پیوند قدیمی را باقی بگذارد. پاراگراف را از طریق [SmartArtNode.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getTextFrame) دریافت کنید. پیش از پاک‌سازی بخش‌ها، بر روی قاب متن گرهٔ شکل نمایش‌دهنده پاراگراف، [getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) را فراخوانی کنید، سپس بر روی شیء برگشتی [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) را اجرا کنید. این کار تمام پیوندهای آن قاب، شامل پیوندهای موجود در پاراگراف‌های دیگر را حذف می‌کند.

مثال فرض می‌کند شکل سوم در اسلاید اول فایل `SmartArtHyperlink.pptx` یک گرافیک SmartArt است. این مثال پاراگراف اول گرهٔ چهارم را جایگزین می‌کند. در این ارائه، شکل اول گره همان پاراگراف را نمایش می‌دهد.

پس از اضافه کردن هر دو بخش، مثال قالب‌بندی مؤثر آن‌ها را با [getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#getEffective) می‌خواند. در آن قالب‌بندی، `getHyperlinkClick` پیوند جدید را برای بخش اول و `null` را برای بخش دوم برمی‌گرداند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("SmartArtHyperlink.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const smartArt = slide.getShapes().get_Item(2);
    const node = smartArt.getAllNodes().get_Item(3);
    const paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    const link = new aspose.slides.Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    const text = new aspose.slides.Portion(" (updated)");
    paragraph.getPortions().add(text);

    console.log(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    console.log(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **ساخت موجودی کامل پیوندها**

پیش از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) کانتینرهای پیوند را برمی‌گرداند، نه یک لیست صاف از رشته‌های URL. هر دو [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) را برای هر کانتینر بررسی کنید. آن‌ها مستقل هستند: همان کانتینر می‌تواند هر دو عمل را داشته باشد، بنابراین یک گزارش کامل ممکن است حداکثر دو ردیف برای هر کانتینر داشته باشد.

اسکن کردن فقط پیوندهای سطح شکل می‌تواند لینک‌های متصل به بخش‑متن‌ها را از دست بدهد. به جای آن دامنهٔ مناسب را پرس‌وجو کنید و کانتینرهای بازگردانده‌شده را نگه دارید تا بعدها بتوانید اعمال آن‌ها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی دامنه‌های ارائه، اسلاید و قاب‑متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) از طریق [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) و [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) در دسترس است. هر دامنه همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) کانتینرهای دارای عمل کلیک را برمی‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) کانتینرهای دارای عمل ماوس‑اور را برمی‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) کانتینرهایی که هر یک یا هر دو عمل را دارند، برمی‌گرداند.

این مثال عمل کلیک و ماوس‑اور را به یک شکل و متن آن و یک عمل ماکرو به یک دکمهٔ جداگانه اختصاص می‌دهد. تعداد کانتینرهای برگردانده‌شده توسط [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) با تعداد هر نوع فعال‌سازی مقایسه می‌شود. پرس‌وجوی قاب‑متن فقط لینک‌های داخل متن را می‌شمارد. اعمال خود شکل در پرس‌وجوهای اسلاید و ارائه نیز ظاهر می‌شوند.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر ماوس‑اور و سه کانتینر با هر یک از این اعمال را گزارش می‌دهند. پرس‌وجوی قاب‑متن یک کانتینر در هر دسته گزارش می‌کند.

### **دسته‌بندی اعمال و مقصدها**

از [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) برای تفسیر عمل پیش از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) بیش از مرور وب را شامل می‌شوند:

| مقادیر | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری پیش‌ساختهٔ نمایش اسلاید، در زمینهٔ نمایش. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائه دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری یا عمل ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) و مقاصد داخلی خاص را از [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنی نیست که کانتینر هیچ عملی ندارد. مقدار برگشتی توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) را هنگام متفاوت بودن از URL نرمال‌شده حفظ کنید و در صورت موجود بودن نکتهٔ راهنمایی برگشتی توسط [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) را نیز شامل شوید.

### **گزارش، پاک‌سازی و تأیید پیوندها**

این مثال ارائهٔ مورد نظر مثال قبلی را باز می‌کند و برای هر عمل یک رکورد JSON می‌نویسد. از [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) برای جمع‌آوری کانتینرها در اسلایدهای عادی، مسترها، لِی‌آوت‌ها و یادداشت‌ها (از جمله مسترهای یادداشت و توزیع) استفاده می‌کند. برای شمارش هر کانتینر یک بار از برابری مرجع استفاده می‌کند، سیاست توضیح داده‌شده در زیر را اعمال می‌کند و سپس ارائهٔ ذخیره‌شده را برای بررسی هر دو عمل کلیک و ماوس‑اور دوباره باز می‌کند.

رکورد گزارش شامل شماره اسلاید (یک‌پایه) و [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) در صورت موجود بودن است. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، لِی‌آوت‌ها و یادداشت‌ها شاخص اسلاید عادی ندارند و با دامنهٔ خود شناسایی می‌شوند. کانتینرهای شکل و قالب‌بندی بخش‑متن به‌طور جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. هر کانتینر یک شناسهٔ محلی گزارش دریافت می‌کند تا دو عمل آن بتوانند مرتبط شوند. انواع عمل به‌عنوان ثابت‌های عددی تعریف‌شده در شمارش‌گر HyperlinkActionType ذخیره می‌شود.

این سیاست برنامه‌ای به‌صراحت فقط URLهای HTTPS مطلق و مقاصد داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوتی دربارهٔ ایمنی Aspose.Slides. تنها HTTPS به تنهایی اطمینان ایجاد نمی‌کند: فهرست سفید میزبان‌ها و بررسی‌های دیگر برای برنامه‌تان اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال‌کردن لینک‌ها یا اجرای اعمال حسابرسی می‌کند.

برای بازسازی، [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) شیء کانتینر از [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) پشتیبانی می‌کند. در اینجا، پیوندهای کلیک خارجی ممنوعه با یک صفحه لندینگ ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌ها و اعمال ماوس‑اور ممنوعه به‌صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، `replaceExternalClicks` را به `false` تنظیم کنید. قبل از استقرار، صفحه جایگزین تحت مالکیت برنامه خود را انتخاب کنید.

پرچم خروجی گزارش از سیاست مرور محافظه‌کارانه PDF استفاده می‌کند: اعمال ماوس‑اور و هر چیزی غیر از یک لینک خارجی یا پرش اسلاید خاص به‌عنوان احتمالی غیرقابل پشتیبانی پرچم‌گذاری می‌شود. این تنها نکته‌ای برای مرور است، نه آزمون قابلیت یا تضمینی برای بقا در خروجی غیرپرچم‌دار. خروجی‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و مشاهده‌کننده. [تصاویر](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) رستر نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ برای این خروجی‌ها همه اعمال هنگام حسابرسی پرچم‌گذاری شوند.

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

با ورودی ایجاد‌شده در بالا، گزارش شامل پنج ردیف عمل است. لینک ماوس‑اور فایل و کلیک ماکرو حذف شده‌اند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوعه چاپ می‌کند. ورودی حاوی یک URL کلیک خارجی ممنوعه نیز شاخهٔ جایگزینی را آزمایش می‌کند. یک کانتینر با کلیک مجاز و ماوس‑اور ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) متفاوت است که بدون در نظر گرفتن سیاست، هر دو نوع عمل را در دامنهٔ انتخاب‌شده حذف می‌کند. تأیید در اینجا فقط اعمال پیوند را بررسی می‌کند؛ پروژه‌های VBA نهفته، اشیاء OLE یا دیگر محتویات فعال را حذف نمی‌کند و فایل PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید خاص هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوند را به عناصر مستر اسلاید پیوست کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لِی‌آوت از پیوندها پشتیبانی می‌کنند. این پیوندها هنگام نمایش اسلاید برای اسلایدهایی که از مستر یا لِی‌آوت مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام صادرات به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

صادرات‌های پشتیبانی‌شدهٔ PDF و HTML ممکن است پیوندها را حفظ کنند؛ تصاویر رستر و ویدئو نمی‌توانند. به ملاحظات خروجی در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.