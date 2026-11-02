---
title: مدیریت پیوندهای ارائه در JavaScript
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
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java، با استفاده از مثال‌های JavaScript."
---
## **معرفی**

یک پیوند (hyperlink) محتویات ارائه را به یک وب‌سایت یا مکانی داخل ارائه متصل می‌کند. در PowerPoint، پیوندها معمولاً دو هدف را دنبال می‌کنند:

* باز کردن یک وب‌سایت از متن، یک شکل، یا یک قاب رسانه‌ای.  
* رفتن به اسلاید دیگری، برای مثال، از فهرست مطالب.

Aspose.Slides for Node.js via Java به شما اجازه می‌دهد این پیوندها را اضافه کنید، ظاهر و صداهای آن‌ها را کنترل کنید، خواصشان را به‌روز کنید و آن‌ها را حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با پیوندها روی عناصر منفرد کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا قاب متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید همچنین ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}} 

## **افزودن پیوندهای URL**

شما می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که پیوند به آن اختصاص می‌یابد، ناحیه قابل کلیک را تعیین می‌کند: یک بخش متن لینک متن انتخاب‌شده را می‌کند، در حالی که یک شکل یا قاب لینک شیء اسلاید را می‌کند.

برای ارائه‌هایی که حاوی پیوندهای نسبی هستند، به [مدیریت پایه پیوندهای فراخوانی](/slides/fa/nodejs-java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایه در سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای پیوند دادن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) بخش متن پاس دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن کلیک‌پذیر می‌شود.

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

### **افزودن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک شدن کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) آن را فراخوانی کنید. پیوند به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همین روش برای قاب‌های تصویر، صدا و ویدئو نیز اعمال می‌شود: پیوند را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) را فراخوانی کنید.

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

## **استفاده از پیوندها برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) برای پیوند دادن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) از کلاس [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) تعیین می‌کند که آیا پیوند از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متن را به همان اسلاید اضافه می‌کند. اولین پیوند از پر رنگ قرمز استفاده می‌کند، در حالی که دومین پیوند رنگ پیش‌فرض پیوند را حفظ می‌کند.

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

یک پیوند می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که از قبل در حال پخش است را متوقف کند. برای پیکربندی این رفتارها از متدهای زیر استفاده کنید:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) صوتی را که به پیوند مرتبط است مشخص می‌کند.  
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) کنترل می‌کند که آیا فعال‌سازی پیوند صدا را متوقف می‌کند یا نه.

#### **افزودن صدای پیوند**

مثال زیر فایل `sampleaudio.wav` را بارگیری می‌کند و آن را به یک دکمه در اسلاید اول اختصاص می‌دهد. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. یک شکل دوم در همان اسلاید هنگام کلیک صدا را متوقف می‌کند بدون اینکه عمل ناوبری انجام دهد.

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

مثال زیر ارائه ایجاد شده در بالا را باز می‌کند و صداهای پیوند اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) و [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData) به حافظه می‌خواند.

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

### **راهنما (Tooltip) و تنظیمات تعامل**

بعد از اختصاص پیوند به متن یا یک شکل می‌توانید متدهای زیر از کلاس [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) متنی را که بیننده می‌تواند به عنوان راهنمایی برای پیوند نمایش دهد تنظیم می‌کند.  
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) فریم هدف را داخل یک مجموعه‌فریم HTML والد، در صورت لزوم، مشخص می‌کند.  
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) کنترل می‌کند که آیا فعال‌سازی پیوند مقصد آن را به فهرست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.  
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) تعیین می‌کند که آیا پیوند هنگام کلیک برجسته شود یا نه.

## **حذف پیوندها از ارائه‌ها**

برای جمع‌آوری محفظه‌های پیوند، شامل پیوندهای بخش متن، قبل از تغییر آن‌ها از متد [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل موشوور نیست.

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

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) هر دو نوع فعال‌سازی را در حوزه انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، به بخش [گزارش، تمیزسازی و تأیید پیوندها](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت فهرست کامل پیوندها**

قبل از توزیع یک ارائه، اقدامات تعاملی و وب‌لینک‌های آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) محفظه‌های پیوند را برمی‌گرداند نه یک لیست صاف از رشته‌های URL. هر دو متد [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) را بر روی هر محفظه بررسی کنید. این متدها مستقل‌اند: همان محفظه می‌تواند هر دو عمل را در اختیار داشته باشد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر محفظه نیاز داشته باشد.

اسکن فقط پیوندهای سطح شکل می‌تواند پیوندهای الصاق‌شده به بخش‌های متن را از دست بدهد. به جای آن حوزه مناسب را پرس‌وجو کنید و محفظه‌های بازگردانده‌شده را نگه دارید تا بعدها بتوانید اقدامات آن‌ها را به‌روز یا حذف کنید.

### **پرسش حوزه‌های ارائه، اسلاید و قاب متن**

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) از طریق متدهای [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries)، [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) و [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries) در دسترس است. هر حوزه همان پرسش‌ها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) محفظه‌های دارای عمل کلیک را برمی‌گرداند.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) محفظه‌های دارای عمل موشوور را برمی‌گرداند.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) محفظه‌های دارای هر یک یا هر دو عمل را برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` می‌سازد که شامل یک لینک کلیک خارجی، یک لینک موشوور فایل، ناوبری اسلاید داخلی، یک لینک موشوور متن و یک عمل ماکرو است. هیچ‌یک از این اعمال اجرا نمی‌شوند. همان سه پرسش در هر حوزه کار می‌کنند؛ شمارش‌ها تعداد محفظه‌ها را نشان می‌دهند نه مجموع اعمال. حوزه قاب متن لینک‌های مربوط به شکل محاط‌کننده را مستثنی می‌کند.

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

برای این مثال، پرسش‌های ارائه و اسلاید هرکدام سه محفظه کلیک، دو محفظه موشوور و سه محفظه دارای هر یک از اعمال را گزارش می‌کنند. پرسش قاب متن یک محفظه در هر دسته گزارش می‌دهد.

### **دسته‌بندی اقدامات و مقصدها**

با استفاده از متد [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) می‌توانید پیش از تفسیر مقصد، نوع اقدام را تشخیص دهید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) بیش از ناوبری وب را پوشش می‌دهند:

| مقادیر | معنی برای حسابرسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی پیش‌فرض اسلایدشو، بسته به زمینه اجرا. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش فعلی یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | راه‌اندازی برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائه دیگر؛ جدا از URL‌های وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون اقدام ناوبری یا اقدام ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق متد [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) و مقصدهای داخلی خاص را از طریق متد [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide) بخوانید. اقدامات داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنی نیست که محفظه هیچ اقدامی ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) را زمانی که با URL نرمال‌شده متفاوت است، حفظ کنید و راهنمایی بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) را در صورت موجود بودن شامل کنید.

### **گزارش، تمیزسازی و تأیید پیوندها**

مثال JavaScript زیر یک ارائه موجود (از فایلی که در بالا ساخته شد) می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و سپس دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر، محفظه‌ها جمع‌آوری می‌شوند و برای جلوگیری از پردازش دوبار یک‌محفظه از برابری مرجع استفاده می‌شود. پرسش‌های ارائه اسلایدهای عادی را پوشش می‌دهند؛ برای فهرست‌گیری در سرتاسر بسته، به‌طور صریح مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و جزوه را نیز پرس‌وجو می‌کند.

گزارش یک شاخص اسلاید مبتنی بر یک‑پایه و [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) (در صورت موجود بودن) ثبت می‌کند. متد [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) اسلاید مالک را برای محفظه‌های پشتیبانی‌شده فراهم می‌کند. مسترها، لایه‌ها و یادداشت‌ها شاخص اسلاید عادی ندارند و با حوزه خود شناسایی می‌شوند. محفظه‌های شکل و محفظه‌های قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع محفظه نام نوع زمان اجرا خود را حفظ می‌کنند. هر محفظه یک شناسه محلی گزارش دریافت می‌کند تا دو اقدام آن بتوانند هم‑پوشانی داشته باشند. گزارش نوع اقدامات را به‌عنوان ثابت‌های عددی تعریف‌شده در شمارنده HyperlinkActionType ذخیره می‌کند.

این سیاست محدود‌کننده صراحتاً تنها URL‌های HTTPS مطلق و اهداف داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اقدام‌های فایلی، سایر اقدامات اسلایدشو، اقدامات ناشناخته و سایر طرح‌های URL را رد می‌کند. این ردها تصمیمات سیاستی‌اند، نه قضاوتی درباره ایمنی Aspose.Slides. تنها HTTPS اعتماد را تضمین نمی‌کند: لیست‌های سفید میزبان و سایر بررسی‌ها را برای برنامه خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال فقط متادیتا را بدون پیگیری لینک‌ها یا اجرای اقدامات حسابرسی می‌کند.

برای اصلاح، کلاس محفظه [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) از متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick)، [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی منع‌شده با یک صفحه لندینگ ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و موشوورهای منع‌شده دیگر به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. قبل از استقرار، یک صفحه جایگزین تحت مالکیت برنامه‌تان انتخاب کنید.

پرچم خروجی گزارش از سیاست محافظه‌کارانه بررسی PDF استفاده می‌کند: اقدامات موشوور و هر چیزی غیر از لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالی غیرقابل پشتیبانی پرچم می‌زند. این یک نکته بررسی است، نه آزمون توانایی یا تضمینی مبنی بر اینکه لینک‌های بدون پرچم در خروجی بقا خواهند یافت. خروجی‌های [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) ممکن است پیوندها را حفظ کنند، بسته به نوع عمل، گزینه‌های خروجی و مرورگر. تصاویر [رستر](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها هر عمل را پرچم کنید.

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

با ورودی ساخته‌شده در بالا، گزارش شامل پنج ردیف اقدام است. لینک موشوور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر اقدام ممنوع را چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخه جایگزینی را اجرا می‌کند. محفظه‌ای با کلیک مجاز و موشوور ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با متد [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) که هر دو نوع فعال‌سازی را بدون در نظر گرفتن سیاست در تمام حوزه انتخاب‌شده حذف می‌کند، متفاوت است. تأیید در اینجا فقط اقدامات پیوند را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و یک فایل PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوند را به عناصر مستر اسلاید وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لایه‌ها از پیوندها پشتیبانی می‌کنند. این پیوندها در حین نمایش اسلاید بر روی اسلایدهایی که از مستر یا لایه مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستر و ویدئو نمی‌توانند پیوندهای تعاملی را حفظ کنند. برای جزئیات بیشتر به بخش [گزارش، تمیزسازی و تأیید پیوندها](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.