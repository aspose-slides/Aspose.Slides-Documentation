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
- قاب متن
- فاصله خط
- ویژگی خودسازگاری
- لنگر قاب متن
- تب بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java. قلم‌ها، رنگ‌ها، تراز و موارد بیشتر را سفارشی کنید."
---
## **نگاهی کلی**

این مقاله نشان می‌دهد چگونه می‌توان متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی کرد. این مقاله به رنگ پس‌زمینه، شفافیت، فاصله بین حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار خود‌سازگاری، متصل‌سازی متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

مگر اینکه خلاف آن ذکر شود، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اولین اسلاید یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو شاخص اسلاید و شکل به صورت صفر‑مبنا هستند. مثال‌هایی که بخش‌های بولد را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی بولد ارث‌بری:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌ کردن متن به‌صورت دقیق یا تطبیق‌های عبارت منظم، ببینید [Search and Replace Text](/slides/fa/nodejs-java/search-and-replace-text/).

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) برای بخش‌های متن فردی استفاده نمایید.

مثال زیر، برجسته‌سازی خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجسته صریح در بخش‌های فردی بر این پیش‌فرض تقدم دارند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم رنگ برجسته برای تمام پاراگراف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متنی با قلم بولد** تنظیم شود:

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
            // تنظیم رنگ برجسته برای بخش متن.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![بخش‌های متنی خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) برای تنظیم تراز پاراگراف درون یک فریم متن استفاده کنید. مقدار می‌تواند centered، left‑aligned، right‑aligned، justified و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم ترازبندی پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تراز فونت‌ها درون یک خط**

از [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment) برای تراز عمودی بخش‌های متنی با اندازه‌های قلم مختلف درون یک خط استفاده کنید. این تنظیم برای تمام پاراگراف اعمال می‌شود و تراز را در هر یک از خطوط آن کنترل می‌کند.

مثال خودمتشکل زیر چهار جعبه متن دارای برچسب در یک اسلاید ایجاد می‌کند. هر پاراگراف همان متن را با اندازه‌های ۱۸، ۳۶ و ۵۴ پوینت دارد و تراز فونت متفاوتی دارد. از Arial استفاده می‌کند، خود‌سازگاری و بسته‌بندی را غیرفعال می‌سازد و فریم‌های متن را به اندازه‌ای بزرگ نگه می‌دارد که یک خط کافی باشد.

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

![مقایسه تراز Baseline، Top، Center و Bottom با اندازه‌های قلم ترکیبی](font_alignment.png)

تراز فونت از معیارهای متریک فونت استفاده می‌کند، بنابراین لبه‌های قابل مشاهده حروف به‌دقت یک‌دیکر هم‌سطح نیستند. مثال شامل یک حرف بزرگ و یک حرف پایین‌دست (descender) است تا تفاوت بین تراز پایه و پایین را نشان دهد. در دسترس بودن فونت و جایگزینی، حروف استفاده‌شده و تفاوت در اندازه‌های قلم بر نتیجه تأثیر می‌گذارند. ابعاد فریم، حاشیه‌ها، فاصله خطوط، بسته‌بندی و خود‌سازگاری نیز بر چیدمان تأثیر دارند؛ برای مقایسه حالت‌ها از همان فونت‌ها و تنظیمات چیدمان استفاده کنید.

این تنظیم متفاوت از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment) است که تراز افقی پاراگراف را کنترل می‌کند و از [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) که بلوک متن را عمودی درون شکل موقعیت می‌دهد. قالب‌بندی فوق‌نویس و زیربنویس از طریق [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) باعث جابجایی بخش‌های فردی نسبت به خط پایه می‌شود نه تنظیم تراز فونت برای خطوط پاراگراف.

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص‌یافته به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` مقدار آلفای ARGB در مقیاس ۰‑۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چطور شفافیت را به **تمام پاراگراف** اعمال کنید:

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

مثال کد بعدی نشان می‌دهد چطور شفافیت را به **بخش‌های متنی با قلم بولد** اعمال کنید:

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

![بخش‌های متنی شفاف](transparent_text_portions.png)

## **تنظیم فاصله بین حروف برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کند.

کد JavaScript زیر نشان می‌دهد چطور فاصله بین حروف را در **تمام پاراگراف** گسترش دهید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصله بین حروف از مقدارهای منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // گسترش فاصله بین حروف.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

مثال کد زیر نشان می‌دهد چطور فاصله بین حروف را در **بخش‌های متنی با قلم بولد** گسترش دهید:

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
            // توجه: برای فشرده‌سازی فاصله بین حروف از مقدارهای منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // گسترش فاصله بین حروف.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله حروف در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال‌سازی کرنینگ برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی تنگ‌تر از متن مشابه در PowerPoint به‌نظر برسد. این ممکن است به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای فونت‌های خاص نادیده می‌گیرد، حتی اگر فونت دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت مؤثر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) را بزرگ‌تر از اندازه واقعی فونت تنظیم کنید. این مثال نیاز به «presentation.pptx» دارد که در اولین اسلاید یک جعبه متن به عنوان اولین شکل دارد. این مثال نام‌های قلم مؤثر، شامل قلم‌های ارث‌بری، را بررسی می‌کند و برای بخش‌هایی که از Roboto استفاده می‌کنند آستانه ۱۰۰ پوینت را تنظیم می‌کند. این کار کرنینگ را برای بخش‌های مطابق با اندازه قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متنی که زیر آستانه است، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) یا در بخش‌های فردی از طریق [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به ۱۲ پوینت Times New Roman با قالب بولد، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح در بخش‌های فردی بر این پیش‌فرض‌ها تقدم دارد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // تنظیم ویژگی‌های قلم برای پاراگراف.
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

مثال زیر ۱۳ پوینت Times New Roman، قالب ایتالیک و زیرخط نقطه‌ای را به بخش‌هایی که قالب مؤثرشان بولد است اعمال می‌کند:

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

            // تنظیم ویژگی‌های قلم برای بخش متن.
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

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **کنترل نرمال‌سازی ارتفاع متن**

از [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight) هنگام بازتولید تایپوگرافی قالب یا بررسی تفاوت‌های ارتفاع حروف استفاده کنید. در PowerPoint، فعال‌سازی نرمال‌سازی حروف را به صورت عمودی کشیده یا فشرده می‌کند تا ارتفاع قابل مشاهده یکسانی داشته باشند. این کار تضمین‌کننده‌ی برابری ارتفاع متن بین فونت‌های مختلف نیست.

خاصیت را به [NullableBool.True یا False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) تنظیم کنید تا صراحتاً نرمال‌سازی را فعال یا غیرفعال کنید. `NullableBool.NotDefined` تنظیم محلی را نادیده می‌گیرد تا بخش مقدار را از پاراگراف، مثلاً از [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)، به ارث ببرد. این به معنای `False` نیست. از [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) و [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) برای دریافت مقدار بولی حل‌شده استفاده کنید.

مثال خودمتشکل زیر نیاز به نصب **Arial** دارد. دو بلوک متن حاوی حروف بزرگ، حروف کوچک، حروف پایین‌دست و حروف accented را با اندازه ۵۴ پوینت ایجاد می‌کند. هر دو پاراگراف به‌صورت پیش‌فرض نرمال‌سازی را فعال می‌کنند. بخش بالایی صراحتاً آن را غیرفعال می‌کند؛ بخش پایین‌تری ارث می‌برد. اندازه فریم‌ها، حاشیه‌ها و فاصله پاراگراف یکسان هستند و بسته‌بندی و خود‌سازگاری برای حفظ مقایسه غیرفعال‌اند. مثال `False: false` و `NotDefined: true` را چاپ می‌کند و سپس «text_height_normalization.pptx» را ذخیره می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقایسه زیر از ارائه ذخیره‌شده استخراج شده است. ردیف بالا نرمال‌سازی غیرفعال (`False`) دارد؛ ردیف پایین‌تری مقدار ارث‌بری فعال (`NotDefined` → `True`) را دارد. برای بازتولید این ظاهر، Arial را نصب داشته باشید.

![متن ۵۴ پوینت Arial با نرمال‌سازی غیرفعال در بالا و نرمال‌سازی ارث‌بری فعال در زیر](text_height_normalization.png)

نرمال‌سازی ارتفاع حروف را بدون تغییر مقدار [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight) (که اندازه قلم را به پوینت مشخص می‌کند) تغییر می‌دهد. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) فاصله خطوط را کنترل می‌کند، در حالی که [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) نحوه تنظیم متن یا محفظه آن را برای جا نشستن کنترل می‌کند. این تنظیمات اهداف متفاوتی دارند و می‌توانند به‌طور مستقل بر چیدمان کلی تأثیر بگذارند. برای اطلاعات بیشتر درباره قالب‌بندی پاراگراف و ارث‌بری، مراجعه کنید به [Manage Paragraph](/slides/fa/nodejs-java/manage-paragraph/).

## **اعمال و حذف Strikethrough**

از [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) روی یک بخش متن استفاده کنید تا اصلاحات، عبارات لغو‌شده یا قیمت‌های قبلی را بدون حذف متن اصلی نشان دهید. برای یک یا دو خط خط‌خطی، آن را به [TextStrikethroughType.Single یا Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) تنظیم کنید.

برای حذف Strikethrough، از [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None) استفاده کنید. این صراحتاً اثر را غیرفعال می‌کند، حتی اگر قالب‌بندی اطراف Strikethrough را مشخص کرده باشد. در مقابل، [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) تنظیم محلی را تعریف‌نشده می‌گذارد تا بخش بتواند قالب‌بندی را از پاراگراف ارث ببرد. این تضمین نمی‌کند Strikethrough حذف شود. برای خواندن قالب‌بندی نهایی، شامل مقادیر ارث‌بری، از [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) استفاده کنید.

مثال خودمتشکل زیر سه مقایسه قیمت ایجاد می‌کند. هر پاراگراف بخش‌های جداگانه‌ای برای برچسب، قیمت قبلی و قیمت فعلی دارد، به‌طوری‌که فقط قیمت قبلی تحت تأثیر قرار می‌گیرد. ردیف اول Strikethrough را اعمال و سپس حذف می‌کند؛ ردیف‌های دیگر Strikethrough تک‌خطی و دوخطی را حفظ می‌کنند. تغییر این تنظیم متنی و سایر قالب‌بندی‌های آن، از جمله بولد بودن قیمت قبلی، را حفظ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // خط‌خورده را اعمال کنید، سپس به‌صورت صریح آن را از اولین قیمت قبلی حذف کنید.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه، از بالا به پایین: بدون Strikethrough، Strikethrough تک‌خطی و Strikethrough دوخطی.

![قیمت‌های قبلی بدون Strikethrough، با Strikethrough تک‌خطی و با Strikethrough دوخطی](strikethrough.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType) برای تنظیم جهت پیش‌تعریف‌شده متن درون یک شکل استفاده کنید.

مثال کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

## **نمایش رقم‌ها به صورت افقی در متن عمودی**

برای نگه داشتن یک عدد دو رقمی در یک برچسب عمودی ژاپنی، هر دو رقم را در یک بخش متن قرار دهید و بر روی قالب‌بندی آن بخش از [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKumimoji) استفاده کنید. مثال از [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/#EastAsianVertical) و ۴۰ پوینت MS Gothic برای هر دو برچسب استفاده می‌کند. تنها مقدار [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) که به بخش عددی پاس داده می‌شود متفاوت است.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const font = new aspose.slides.FontData("MS Gothic");
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const settings = [aspose.slides.NullableBool.True, aspose.slides.NullableBool.False];
    let x = 120;

    for (const kumimoji of settings) {
        const label = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        label.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.EastAsianVertical));

        const paragraph = frame.getParagraphs().get_Item(0);
        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const digits = new aspose.slides.Portion("12");
        digits.getPortionFormat().setKumimoji(java.newByte(kumimoji));

        const portions = paragraph.getPortions();
        portions.clear();
        portions.add(new aspose.slides.Portion("令和"));
        portions.add(digits);
        portions.add(new aspose.slides.Portion("年"));
        x += 240;
    }
    presentation.save("vertical_date.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در PowerPoint، برچسب چپ (`True`) ارقام را به‌صورت عمودی و کنار هم بین 和 و 年 نشان می‌دهد. برچسب راست (`False`) جفت ارقام را ۹۰ درجه ساعت‌گرد می‌چرخاند. حروف ژاپنی اطراف در هر دو برچسب به‌صورت عمودی باقی می‌مانند.

![مقایسه برچسب‌های تاریخ عمودی PowerPoint با ارقام عمودی در چپ و ارقام چرخیده در راست](vertical_date.png)

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) استفاده کنید.

مثال کد زیر فریم متنی را درون شکل ۳ درجه ساعت‌گرد می‌چرخاند:

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

## **تنظیم فاصله خطوط پاراگراف‌ها**

Aspose.Slides ارائه می‌دهد [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) برای کنترل فاصله پاراگراف. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* برای مشخص کردن فاصله خط به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای مشخص کردن فاصله خط به‌واحد پوینت، مقدار منفی استفاده کنید.

مثال زیر فاصله درون اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (فاصله دوتایی) تنظیم می‌کند:

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

![فاصله خطوط درون پاراگراف](line_spacing.png)

## **کنترل شکست خط**

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و شرق‌آسیایی را ترکیب می‌کنند مفید هستند. روش‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/) هستند، بنابراین بر تمام پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) قواعد شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند مکان بسته شدن متن و نقطه‌گذاری شرق‌آسیایی مجاور را نیز تغییر دهد.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) قواعد شکست خط شرق‌آسیایی را کنترل می‌کند، شامل محدودیت‌ها برای حروف در آغاز و انتهای خط.

این قواعد جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText) نمی‌شوند که بسته‌بندی خودکار را درون یک فریم متن فعال می‌کند. این قواعد بر چیدمان هنگام بسته‌بندی تأثیر می‌گذارند؛ آن‌ها کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف مستقل از عرض موجود ایجاد می‌کند.

مثال خودمتشکل زیر یک بلوک متنی باریک حاوی متن چینی و لاتین ایجاد می‌کند. هر دو گزینه شکست خط به‌صورت صریح تنظیم می‌شوند و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر قاعده، مقدار مربوطه را تغییر دهید و تنظیم دیگر را ثابت نگه دارید. مثال از ۲۴ پوینت Arial و SimSun با عرض فریم ۱۶۰ پوینت و صفر حاشیه افقی فریم متن استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) با [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/) صدا می‌شود تا اندازه متن و ابعاد فریم ثابت بمانند.

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) اجازه می‌دهد نقطه‌گذاری قابل‌اعطای به‌جای اشغال خط بعدی، از لبه راست خط متن بیرون بگذرد. این ویژگی بر کل پاراگراف اعمال می‌شود و متفاوت از تورفتگی معلق است.

مثال خودمتشکل زیر نقطه‌گذاری معلق را در یک فریم متن ۱۰۰ پوینت عرضی فعال می‌کند و «hanging_punctuation.pptx» را ذخیره می‌کند. با ۲۴ پوینت Arial و صفر حاشیه افقی فریم متن، نقطه نهایی بعد از «sentence» می‌ماند و از لبه راست متن فراتر می‌رود. برای مقایسه، خاصیت را به [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) تنظیم کنید: در این حالت، نقطه در خط جداگانه‌ای قرار می‌گیرد. بسته‌بندی فعال و خود‌سازگاری غیرفعال است تا عرض در دسترس ثابت بماند.

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

هر علامت نقطه‌گذاری نمی‌تواند معلق باشد. شرایط فونت و چیدمان توصیف‌شده در بالا ([کنترل شکست خط](#control-line-breaking)) نیز بر این مقایسه اعمال می‌شود: تغییر فونت، عرض در دسترس، حاشیه‌ها یا تنظیمات خود‌سازگاری می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع خود‌سازگاری برای فریم‌های متنی**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) تعیین می‌کند که متن هنگام تجاوز از مرزهای محفظه‌اش چگونه رفتار کند. از آن برای کنترل این‌که آیا متن کوچک می‌شود، افزون می‌شود یا شکل به‌صورت خودکار اندازه می‌شود استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن آن اندازه شود و نتیجه در «autofit_type.pptx» ذخیره می‌شود:

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ تغییرات عرض متن یا شکل، ببینید [Count Rendered Lines](/slides/fa/nodejs-java/manage-paragraph/). شمارش خطوط به تنهایی نشان نمی‌دهد آیا متن از محفظه‌اش عبور کرده است یا نه.

## **تنظیم لنگر فریم‌های متنی**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) تعیین می‌کند که متن به‌صورت عمودی داخل یک شکل چگونه موقعیت‌گیری شود؛ به‌عنوان مثال در بالا، میانه یا پایین. مثال زیر متن را به‌لنگر پایین اولین شکل می‌چسباند و نتیجه را در «text_anchor.pptx» ذخیره می‌کند:

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

## **تنظیم تب‌بندی متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصله تب پیش‌فرض را به ۱۰۰ پوینت تنظیم می‌کند و یک توقف تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب است، تأثیر می‌گذارد.

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

## **تنظیم زبان بررسی املایی**

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) را فراهم می‌کند که به شما امکان می‌دهد زبان بررسی املایی یک بخش متن را تنظیم کنید. زبان بررسی املایی، زبانی را که برای بررسی املایی و دستوری در PowerPoint استفاده می‌شود، تعیین می‌کند.

مثال زیر نیاز به «presentation.pptx» دارد که در اولین اسلاید یک جعبه متن به‌عنوان اولین شکل دارد و حداقل یک پاراگراف دارد. این مثال محتوای اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم آن تنظیم می‌کند و زبان بررسی Simplified Chinese (`zh-CN`) را اختصاص می‌دهد. سپس نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    // تنظیم شناسهٔ زبان بررسی املایی.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **کپی متادیتای زبان**

هنگام کپی متن چندزبانه از یک قالب، هم [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId) و هم [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) را حفظ کنید. مثال خودمتشکل زیر یک بخش منبع با زبان US English و زبان جایگزین French ایجاد می‌کند و متن و شناسه‌ها را به یک بخش در ارائه جدید کپی می‌نماید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // اگر منبع زبان جایگزین نداشته باشد، null مقدار مقصد را پاک می‌کند.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای آزمایش منبع بدون زبان جایگزین، اختصاص `"fr-FR"` را حذف کنید. شناسهٔ جایگزین سپس `null` خواهد بود و همان عبارت کپی عدم وجود آن را بدون افزودن مقدار پیش‌فرض حفظ می‌کند، حتی اگر مقصد قبلاً زبان جایگزین داشته باشد.

این شناسه‌ها متادیتای زبان را ذخیره می‌کنند. حفظ آن‌ها تعیین نمی‌کند که کدام فرهنگ‌لغت PowerPoint برای بررسی املایی یا دستوری انتخاب می‌کند.

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد ارائه ایجاد می‌شود، استفاده کنید. مثال زیر ارائه‌ای با US English به‌عنوان زبان پیش‌فرض متن ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن `en-US` چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // یک شکل مستطیلی جدید با متن اضافه کنید.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // زبان اولین بخش متن را بررسی کنید.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متنی پیش‌فرض**

برای اعمال قالب‌بندی متنی پیش‌فرض در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle) استفاده کنید.

مثال زیر یک قلم بولد ۱۴ پوینتی را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالا در یک ارائهٔ جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌کند. متن می‌تواند این پیش‌فرض‌ها را به ارث ببرد مگر این‌که قالب‌بندی خاص‌تری آن‌ها را بازنویسی کند.

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

در PowerPoint، اعمال اثر **All Caps** بر قلم باعث می‌شود متن حتی اگر به‌صورت حروف کوچک تایپ شده باشد، به‌صورت حروف بزرگ در اسلاید نمایش داده شود. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متنی را برمی‌گرداند که وارد شده است. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) را بررسی کرده و رشتهٔ بازگشتی را به حروف بزرگ تبدیل کنید وقتی مقدار `All` باشد.

این مثال نیاز به «sample2.pptx» دارد که در اولین اسلاید یک جعبه متن به‌عنوان اولین شکل دارد. اولین پاراگراف آن بخش اول شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده است.

![اثر All Caps](all_caps_effect.png)

مثال کد زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

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

## **FAQ**

**چگونه متن را در یک جدول داخل اسلاید اصلاح کنم؟**

برای اصلاح متن در یک جدول داخل اسلاید، از [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کرده و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) و قالب‌بندی پاراگراف از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat) به‌روز کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) را به [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) تنظیم کرده و نقاط توقف گرادیان، جهت و شفافیت را پیکربندی کنید.