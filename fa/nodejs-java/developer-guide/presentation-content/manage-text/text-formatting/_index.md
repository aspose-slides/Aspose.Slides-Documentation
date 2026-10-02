---
title: قالب‌بندی متن ارائه در JavaScript
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/nodejs-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله بین حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- فریم متن
- فاصله خطوط
- ویژگی autofit
- لنگر فریم متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java. سفارشی‌سازی قلم‌ها، رنگ‌ها، تراز و موارد دیگر."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی کرد. موارد شامل رنگ‌های پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار autofit، لنگر متن، مکان‌های تب و تنظیمات زبان می‌باشد.

مگر آنکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. ایندکس اسلاید و شکل به صورت صفر‑مبنا هستند. مثال‌هایی که بخشی را به صورت Bold انتخاب می‌کنند، از قالب‌بندی مؤثر استفاده می‌نمایند، از جمله قالب‌بندی Bold ارث‌برده شده:

![متن نمونه](sample_text.png)

برای پیدا کردن و برجسته‌سازی متن دقیق یا‌قابلات ‎regular‑expression‎، مراجعه کنید به [جستجو و جایگزینی متن](/slides/fa/nodejs-java/search-and-replace-text/).

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) برای قسمت‌های متنی جداگانه.

مثال زیر رنگ برجستهٔ خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح در قسمت‌های جداگانه بر این پیش‌فرض اولویت دارند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته را برای تمام پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینهٔ **بخش‌های متنی با قلم Bold** تنظیم شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // رنگ برجسته را برای بخش متن تنظیم کنید.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![قسمت‌های متن خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف داخل یک قاب متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

مثال زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تراز پاراگراف را به مرکز تنظیم کنید.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز قلم‌ها درون یک خط**

از [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment-int-) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم متفاوت در یک خط استفاده کنید. این تنظیم بر روی تمام پاراگراف اعمال می‌شود و تراز داخل هر خط را کنترل می‌کند.

مثال زیر چهار جعبه متن دارای برچسب در یک اسلاید می‌سازد. هر پاراگراف متنی همانند 18، 36 و 54 نقطه دارد و تراز قلم متفاوتی دارد. از Arial استفاده می‌کند، Autofit و Wrap را غیرفعال می‌کند و قاب‌های متن را به‌ اندازه کافی بزرگ می‌کند تا فقط یک خط جا بگیرد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم متفاوت](font_alignment.png)

تراز قلم از متریک‌های قلم استفاده می‌کند، بنابراین لبه‌های قابل مشاهدهٔ حروف لزوماً دقیقاً هم‌سطح نمی‌شوند. این مثال شامل یک حرف بزرگ و یک descender است تا تفاوت بین تراز baseline و bottom بهتر نشان داده شود. در دسترس بودن قلم و جایگزینی، کاراکترهای استفاده شده و تفاوت اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد قاب، حاشیه‌ها، فاصله خطوط، Wrap و Autofit نیز بر چیدمان اثر دارند؛ برای مقایسهٔ حالت‌ها همان قلم‌ها و تنظیمات چیدمان را به‌کار ببرید.

این تنظیم متفاوت از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) است که تراز افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) که موقعیت عمودی بلوک متن را درون شکل تنظیم می‌کند. قالب‌بندی ابرنویس و زیرنویس از طریق [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement-float-) قسمت‌های جداگانه را نسبت به baseline جابه‌جا می‌کند، نه تنظیم تراز قلم برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفهٔ آلفا رنگی که به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) اختصاص داده می‌شود، کنترل می‌گردد. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس 0‑255 است، نه درصد شفافیت.

کد زیر نمایش می‌دهد چگونه شفافیت را بر **تمام پاراگراف** اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // رنگ پر کردن متن را به رنگ شفاف تنظیم کنید.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر نشان می‌دهد چگونه شفافیت را بر **قسمت‌های متنی با قلم Bold** اعمال کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // شفافیت بخش متن را تنظیم کنید.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![قسمت‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین حروف برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) برای افزایش یا کاهش فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها 3 پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌سازند.

کد JavaScript زیر نشان می‌دهد چگونه فاصلهٔ حروف در **تمام پاراگراف** گسترش یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصلهٔ بین حروف، از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصلهٔ حروف را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصلهٔ حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصلهٔ حروف در **قسمت‌های متنی با قلم Bold** گسترش یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشرده‌سازی فاصلهٔ بین حروف، از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصلهٔ حروف را گسترش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصلهٔ حروف در قسمت‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به‌نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی قلم‌ها نادیده می‌گیرد، حتی اگر قلم kerning معتبر داشته باشد و در تنظیمات PowerPoint روشن باشد.

برای نزدیک‌تر شدن خروجی رندر به PowerPoint، می‌توانید kerning را برای قسمت‌های متنی که از قلم تحت‌تأثیر استفاده می‌کنند، غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) را بزرگ‌تر از اندازهٔ واقعی قلم تنظیم کنید. این مثال به «presentation.pptx» با جعبه متنی به عنوان اولین شکل در اولین اسلاید نیاز دارد. نام‌های قلم مؤثر (از جمله قلم‌های ارث‌برده) را بررسی می‌کند و آستانهٔ 100 پوینت برای قسمت‌هایی که از Roboto استفاده می‌کنند، تنظیم می‌نماید. این کار kerning را برای قسمت‌های مطابق با اندازهٔ قلم زیر 100 پوینت غیرفعال می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای متون مطابقت دهنده زیر آستانه، این تنظیم kerning را جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌های تحت‌تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) یا بر روی قسمت‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به 12 پوینت Times New Roman با Bold، Italic و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح روی قسمت‌های جداگانه بر این پیش‌فرض‌ها اولویت دارد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // ویژگی‌های قلم را برای پاراگراف تنظیم کنید.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای پاراگراف](font_properties_for_paragraph.png)

مثال زیر 13 پوینت Times New Roman، قالب Italic و زیرخط نقطه‌ای را بر قسمت‌هایی که قالب مؤثرشان Bold است، اعمال می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // ویژگی‌های قلم را برای بخش متن تنظیم کنید.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![ویژگی‌های قلم برای قسمت‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) برای تنظیم جهت متن از پیش تعریف‌شده درون یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه خلاف ساعت‌گرد** می‌چرخاند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) برای تنظیم زاویهٔ چرخش دلخواه یک [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را داخل شکل 3 درجه ساعت‌گرد می‌چرخاند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصلهٔ خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) را برای کنترل فواصل پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* مقدار مثبت برای تعیین فاصلهٔ خط به‌عنوان درصدی از ارتفاع خط.
* مقدار منفی برای تعیین فاصلهٔ خط به پوینت.

مثال زیر فاصلهٔ داخلی اولین پاراگراف را به 200٪ ارتفاع خط (فاصلهٔ دوبل) تنظیم می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصلهٔ خطوط درون پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قوانین شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق آسیایی را ترکیب می‌کنند مفید است. متدهای زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) هستند، بنابراین بر کل پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) قوانین شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن شرق آسیایی و نشانه‌گذاری‌های مجاور را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) قوانین شکست خط شرق آسیایی را کنترل می‌کند، از جمله محدودیت‌های کاراکترها در ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) که Wrap خودکار را درون فریم متن فعال می‌کند، نیستند؛ آنها بر چیدمان هنگام Wrap تأثیر می‌گذارند، اما کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید درون پاراگراف ایجاد می‌کند بدون در نظر گرفتن عرض موجود.

مثال زیر یک بلوک متنی باریک شامل چینی و لاتین می‌سازد. هر دو گزینهٔ شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت بمانند. این مثال از Arial 24 پوینت و SimSun با عرض فریم 160 پوینت و حاشیهٔ افقی صفر استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) با [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد فریم ثابت بمانند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل نقطه‌گذاری معلق**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) به علامت‌های نگارشی واجد شرایط اجازه می‌دهد تا فراتر از لبهٔ راست خط متن امتداد یابند به‌جای اینکه در خط بعدی جای بگیرند. این ویژگی برای کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال زیر نقطه‌گذاری معلق را در فریم متنی با عرض 100 پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌نماید. با Arial 24 پوینت و حاشیهٔ افقی صفر، نقطهٔ نهایی پس از «sentence» باقی می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه مقدار را به [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) تغییر دهید: در این حالت نقطه در خط جداگانه‌ای قرار می‌گیرد. Wrap فعال و Autofit غیرفعال است تا عرض موجود ثابت بماند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همهٔ علامت‌های نگارشی نمی‌توانند معلق شوند. شرایط قلم و چیدمان شرح‌داده‌شده در بخش [کنترل شکست خط](#control-line-breaking) نیز در این مقایسه اعمال می‌شوند: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات Autofit می‌تواند تفاوت قابل رؤیت را از بین ببرد.

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) نحوهٔ رفتار متن را وقتی از محدودهٔ محفظهٔ خود فراتر می‌رود، تعیین می‌کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، سرریز می‌شود یا به‌صورت خودکار شکل را تغییر اندازه می‌دهد، استفاده کنید. مثال زیر شکل را طوری پیکربندی می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه را در «autofit_type.pptx» ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای شمارش خطوط پس از Wrap خودکار و مشاهدهٔ تغییرات عرض متن یا شکل، مراجعه کنید به [Count Rendered Lines](/slides/fa/nodejs-java/manage-paragraph/). خود شمارش خطوط فقط نشان‌دهندهٔ اینکه آیا متن از محفظه‌اش سرریز می‌شود نیست.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) نحوهٔ موقعیت‌گذاری عمودی متن درون یک شکل را تعریف می‌کند، برای مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌دهد و نتیجه را در «text_anchor.pptx» ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تب‌های متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs--) برای پیکربندی مکان‌های تب در یک پاراگراف استفاده کنید. مثال زیر اندازهٔ پیش‌فرض تب را به 100 پوینت تنظیم می‌کند و یک تب چپ‌تراز در 30 پوینت اضافه می‌کند. این تنظیمات بر متونی که شامل کاراکتر تب هستند اثر می‌گذارد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![تب‌های پاراگراف](paragraph_tabs.png)

## **تنظیم زبان تصحیح املایی**

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) را ارائه می‌دهد که به شما امکان می‌دهد زبان تصحیح املایی یک بخش متن را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند کدام زبان برای بررسی املایی و دستور زبانی در PowerPoint استفاده شود.

مثال زیر به «presentation.pptx» با جعبه متنی به‌عنوان اولین شکل در اولین اسلاید و حداقل یک پاراگراف نیاز دارد. محتویات اولین پاراگراف را به «1。» تغییر می‌دهد، SimSun را به عنوان قلم آن تنظیم می‌کند و زبان تصحیح Simplified Chinese (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // شناسه زبان تصحیح املایی را تنظیم کنید.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید. مثال زیر ارائه‌ای با زبان پیش‌فرض US English ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن «en‑US» را چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // یک شکل مستطیل جدید با متن اضافه کنید.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // زبان اولین بخش متن را بررسی کنید.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی متن پیش‌فرض در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر یک قلم 14 پوینتی Bold را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را ارث‌برداری کند مگر این که قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // دریافت قالب پاراگراف سطح بالایی.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخراج متن با اثر All‑Caps**

در PowerPoint، اعمال اثر فونت **All Caps** باعث می‌شود متن بر روی اسلاید به صورت حروف بزرگ نشان داده شود حتی اگر به‌صورت حروف کوچک وارد شده باشد. وقتی چنین بخشی را با Aspose.Slides دریافت می‌کنید، کتابخانه متن را دقیقاً همان‌طور که وارد شده برمی‌گرداند. برای هم‌خوانی با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار `All`، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال به «sample2.pptx» با جعبه متنی به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. اولین پاراگراف اولین بخش آن شامل «Hello, Aspose!» با اثر All Caps اعمال‌شده است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

خروجی:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **پرسش‌های متداول**

**چگونه متن در جدول یک اسلاید را ویرایش کنم؟**

برای ویرایش متن در جدول یک اسلاید، از [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) استفاده کنید. بر روی سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) به‌روزرسانی کنید و قالب‌بندی پاراگراف را از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) تنظیم کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم کنید و نقاط گرادیان، جهت و شفافیت را پیکربندی کنید.