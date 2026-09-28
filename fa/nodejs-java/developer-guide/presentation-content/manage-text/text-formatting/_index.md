---
title: قالب‌بندی متن ارائه در جاوااسکریپت
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/nodejs-java/text-formatting/
keywords:
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله کاراکتر
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله خطوط
- ویژگی خودکار‌متناسب
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه متن در ارائه‌های PowerPoint و OpenDocument را با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی کنیم. این مقاله رنگ پس‌زمینه، شفافیت، فاصله بین کاراکترها، ویژگی‌های قلم، چرخش، فاصله‌های پاراگراف، رفتار خودکار‌متناسب، لنگر کردن متن، ایست‌گاه‌های تب و تنظیمات زبان را پوشش می‌دهد.

مگر اینکه اشاره دیگری شده باشد، مثال‌ها از [sample.pptx](sample.pptx) استفاده می‌کنند. اولین شکل در اسلاید اول آن یک جعبه متن است و اولین پاراگراف آن شامل متنی است که در زیر نشان داده شده است. هر دو اندیس اسلاید و شکل به صورت صفر‑محور هستند. مثال‌هایی که بخش‌های پررنگ را انتخاب می‌کنند از قالب‌بندی مؤثر استفاده می‌کنند، از جمله قالب‌بندی پررنگ ارث‌بری شده:

![متن نمونه](sample_text.png)

برای یافتن و برجسته‌سازی متن دقیق یا تطابق‌های عبارت منظم، به [جستجو و جایگزینی متن](/slides/fa/nodejs-java/search-and-replace-text/) مراجعه کنید.

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته‌سازی پیش‌فرض یک پاراگراف استفاده کنید، یا برای بخش‌های متن فردی از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) بهره ببرید.

مثال زیر رنگ برجستهٔ خاکستری روشن را به‌عنوان پیش‌فرض برای اولین پاراگراف تنظیم می‌کند. رنگ‌های برجستهٔ صریح در بخش‌های فردی بر این پیش‌فرض ارجحیت دارند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته را برای کل پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

مثال کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه برای **بخش‌های متن با قلم پررنگ** تنظیم شود:

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

![بخش‌های متن خاکستری](gray_text_portions.png)

## **تراز پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف درون یک قاب متن استفاده کنید. مقدار می‌تواند مرکزی، چپ‌تراز، راست‌تراز، هم‌تراز و غیره باشد.

مثال کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

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

## **تنظیم شفافیت متن**

شفافیت متن از طریق مؤلفهٔ آلفای رنگی که به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) اختصاص داده شده، کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس ۰‑۲۵۵ است، نه درصد شفافیت.

مثال کد زیر نشان می‌دهد چگونه شفافیت به **تمام پاراگراف** اعمال شود:

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

مثال کد زیر نشان می‌دهد چگونه شفافیت به **بخش‌های متن با قلم پررنگ** اعمال شود:

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

![بخش‌های متن شفاف](transparent_text_portions.png)

## **تنظیم فاصله کاراکتر برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) برای گسترش یا فشرده‌سازی فاصله بین کاراکترها در یک جعبه متن استفاده کنید. مثال‌ها ۳ پوینت فاصله اضافه می‌کنند؛ مقادیر منفی متن را فشرده می‌کنند.

کد JavaScript زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها در **تمام پاراگراف** گسترش یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصله کاراکتر را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد مثال زیر نشان می‌دهد چگونه فاصلهٔ کاراکترها در **بخش‌های متن با قلم پررنگ** گسترش یابد:

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
            // توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصله کاراکتر را گسترش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله کاراکترها در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای قلم‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود ممکن است کمی فشرده‌تر از همان متن در PowerPoint به نظر برسد. این می‌تواند به این دلیل باشد که PowerPoint ممکن است داده‌های کرنینگ را برای برخی قلم‌ها نادیده بگیرد، حتی وقتی قلم داده‌های کرنینگ معتبر دارد و کرنینگ در تنظیمات PowerPoint فعال است.

برای نزدیک‌تر شدن خروجی رندر شده به PowerPoint در چنین مواردی، می‌توانید کرنینگ را برای بخش‌های متنی که از قلم موردنظر استفاده می‌کنند غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) را بزرگ‌تر از اندازه واقعی قلم تنظیم کنید. این مثال نیاز به «presentation.pptx» دارد که در آن اولین شکل یک جعبه متن است. این مثال نام‌های قلم مؤثر، شامل قلم‌های ارث‌بری شده، را بررسی می‌کند و برای بخش‌هایی که از Roboto استفاده می‌کنند، آستانهٔ ۱۰۰ پوینت را تنظیم می‌کند. این کار کرنینگ را برای بخش‌های مطابق با اندازهٔ قلم زیر ۱۰۰ پوینت غیرفعال می‌کند:

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

برای متنی که زیر آستانه مطابقت دارد، این تنظیم کرنینگ را جلوگیری می‌کند و می‌تواند به هماهنگ‌سازی رندر Aspose.Slides با خروجی بصری PowerPoint برای قلم‌هایی که تحت این رفتار خاص PowerPoint قرار دارند، کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) یا بر روی بخش‌های فردی از طریق [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) تنظیم شوند.

مثال زیر قلم پیش‌فرض اولین پاراگراف را به Times New Roman 12 پوینت با قالب‌بندی پررنگ، ایتالیک و زیرخط نقطه‌ای تنظیم می‌کند. قالب‌بندی صریح در بخش‌های فردی بر این پیش‌فرض‌ها ارجحیت دارد:

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

مثال زیر Times New Roman 13 پوینت، قالب‌بندی ایتالیک و زیرخط نقطه‌ای را به بخش‌هایی که قالب‌بندی مؤثرشان پررنگ است اعمال می‌کند:

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

![ویژگی‌های قلم برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) برای تنظیم جهت متن پیش‌تعریف‌شده درون یک شکل استفاده کنید.

مثال کد زیر جهت متن در شکل را به [TextVerticalType.Vertical270](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textverticaltype/) تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

## **تنظیم چرخش سفارشی برای قاب‌های متن**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) برای تنظیم زاویهٔ چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) استفاده کنید.

کد مثال زیر قاب متن را داخل شکل ۳ درجه ساعت‌گرد می‌چرخاند:

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

Aspose.Slides توابع [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) را برای کنترل فاصلهٔ پاراگراف فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* از مقدار مثبت برای مشخص کردن فاصلهٔ خط به‌عنوان درصدی از ارتفاع خط استفاده کنید.  
* از مقدار منفی برای مشخص کردن فاصلهٔ خط به‌واحد پوینت استفاده کنید.

مثال زیر فاصلهٔ داخل اولین پاراگراف را به ۲۰۰٪ از ارتفاع خط (دوبل اسپیسینگ) تنظیم می‌کند:

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

قواعد شکست خط پاراگراف در بلوک‌های متنی باریک و ارائه‌هایی که متن لاتین و آسیای شرقی را ترکیب می‌کنند مفید هستند. روش‌های زیر متعلق به [ParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/) هستند، بنابراین برای تمام پاراگراف اعمال می‌شوند:

- [setLatinLineBreak](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) قانون‌های شکست خط لاتین را کنترل می‌کند. در متن ترکیبی، تغییر آن می‌تواند محل شکست متن و نقطه‌گذاری آسیای شرقی مجاور را نیز تغییر دهد.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) قانون‌های شکست خط آسیای شرقی را کنترل می‌کند، شامل محدودیت‌های مربوط به کاراکترهای ابتدای و انتهای خط.

این قوانین جایگزین [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-) نمی‌شوند؛ این متد بسته‌بندی خودکار را درون یک قاب متن فعال می‌کند. این قواعد طرح‌بندی را هنگام بسته‌بندی تحت تأثیر قرار می‌دهند؛ کاراکترهای شکست خط را وارد نمی‌کنند. یک شکست خط صریح یک خط جدید را درون پاراگراف صرف‌نظر از عرض موجود ایجاد می‌کند.

مثال زیر یک بلوک متنی باریک حاوی متن چینی و لاتین ایجاد می‌کند. هر دو گزینهٔ شکست خط به‌صورت صریح تنظیم شده و «line_breaking.pptx» ذخیره می‌شود. برای آزمایش هر یک از قواعد، مقدار مربوطه را تغییر دهید در حالی که تنظیمات دیگر ثابت می‌مانند. این مثال از Arial ۲۴ پوینت و SimSun با عرض قاب ۱۶۰ پوینت و حاشیه‌های افقی صفر استفاده می‌کند. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) با [TextAutofitType.None](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textautofittype/) فراخوانی می‌شود تا اندازهٔ متن و ابعاد قاب ثابت بمانند.

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

## **کنترل نقطه‌گذاری آویزان**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) اجازه می‌دهد نقطه‌گذاری مجاز از لبهٔ راست خط متن خارج شود به‌جای این‌که در خط بعدی قرار بگیرد. این تنظیم برای تمام پاراگراف اعمال می‌شود و متفاوت از تورفتگی آویز است.

مثال زیر نقطه‌گذاری آویزان را در قاب متنی با عرض ۱۰۰ پوینت فعال می‌کند و «hanging_punctuation.pptx» ذخیره می‌شود. با Arial ۲۴ پوینت و حاشیه‌های افقی صفر، نقطهٔ نهایی پس از «sentence» می‌ماند و از لبهٔ راست متن فراتر می‌رود. برای مقایسه این ویژگی را به [NullableBool.False](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/nullablebool/) تنظیم کنید: با این تنظیمات، نقطه در یک خط جداگانه قرار می‌گیرد. بسته‌بندی فعال و Autofit غیرفعال است تا عرض موجود ثابت بماند.

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

هر نقطه‌گذاری نمی‌تواند آویزان شود. نتیجهٔ قابل مشاهده بستگی به در دسترس بودن قلم و طرح‌بندی دارد: تغییر قلم، عرض موجود، حاشیه‌ها یا تنظیمات Autofit می‌تواند تفاوت قابل مشاهده را حذف کند.

## **تنظیم نوع Autofit برای قاب‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) تعیین می‌کند متن چگونه رفتار کند وقتی از مرزهای محفظهٔ خود فراتر می‌رود. از آن برای کنترل اینکه متن کوچک شود، overflow کند یا به‌صورت خودکار شکل را تغییر اندازه دهد استفاده کنید. مثال زیر شکل را طوری تنظیم می‌کند که برای متن خود اندازه‌اش را تغییر دهد و نتیجه در «autofit_type.pptx» ذخیره می‌شود:

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/nodejs-java/manage-paragraph/) مراجعه کنید. تنها شمارش خطوط نشان‌دهندهٔ overflow متن نیست.

## **تنظیم لنگر برای قاب‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) تعیین می‌کند متن به‌صورت عمودی داخل یک شکل در کجا قرار گیرد؛ به عنوان مثال در بالا، وسط یا پایین. مثال زیر متن را به پایین اولین شکل لنگر می‌کند و نتیجه در «text_anchor.pptx» ذخیره می‌شود:

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

## **تنظیم تب‌گذاری متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getTabs--) برای پیکربندی ایست‌گاه‌های تب در یک پاراگراف استفاده کنید. مثال زیر فاصلهٔ پیش‌فرض تب را به ۱۰۰ پوینت تنظیم کرده و یک ایست‌گاه تب چپ‌تراز در ۳۰ پوینت اضافه می‌کند. این تنظیمات بر متنی که شامل کاراکترهای تب باشد تأثیر می‌گذارد:

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

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که اجازه می‌دهد زبان تصحیح املایی برای یک بخش متن تنظیم شود. این زبان تعیین‌کنندهٔ زبانی است که برای بررسی املایی و دستوری در PowerPoint استفاده می‌شود.

مثال زیر نیاز به «presentation.pptx» دارد که اولین شکل آن یک جعبه متن است و حداقل یک پاراگراف دارد. این مثال محتویات اولین پاراگراف را با «1。」» جایگزین می‌کند، SimSun را به‌عنوان قلم تنظیم می‌کند و زبان تصحیح املایی چینی ساده (`zh-CN`) را اختصاص می‌دهد. نتیجه در «proofing_language.pptx» ذخیره می‌شود:

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

    // شناسه‌ی زبان تصحیح املایی را تنظیم کنید.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود استفاده کنید. مثال زیر یک ارائه با زبان پیش‌فرض متن انگلیسی (ایالات متحده) ایجاد می‌کند، یک جعبه متن اضافه می‌کند و برای اولین بخش متن «en-US» چاپ می‌کند:

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

    // زبان بخش اول را بررسی کنید.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) استفاده کنید.

مثال زیر قلم پررنگ ۱۴ پوینت را به‌عنوان پیش‌فرض برای پاراگراف‌های سطح بالای یک ارائه جدید تنظیم می‌کند و آن را در «default_text_style.pptx» ذخیره می‌نماید. متن می‌تواند این پیش‌فرض‌ها را ارث ببرد مگر این‌که قالب‌بندی خاص‌تری آن‌ها را مغایرت دهد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // دریافت قالب پاراگراف سطح بالا.
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

## **استخراج متن با اثر تمام حروف بزرگ**

در PowerPoint، اعمال اثر **All Caps** بر قلم باعث می‌شود متن بر روی اسلاید به حروف بزرگ نمایش داده شود حتی اگر ابتدا با حروف کوچک وارد شده باشد. وقتی چنین بخشی از متن را با Aspose.Slides بازیابی می‌کنید، کتابخانه دقیقاً همان متن وارد شده را برمی‌گرداند. برای تطبیق با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textcaptype/) را بررسی کنید و وقتی مقدار `All` باشد، رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

این مثال نیاز به «sample2.pptx» دارد که اولین شکل آن یک جعبه متن است. اولین پاراگراف آن شامل «Hello, Aspose!» با اثر All Caps است، همان‌طور که در زیر نشان داده شده:

![اثر تمام حروف بزرگ](all_caps_effect.png)

کد مثال زیر نشان می‌دهد چگونه متن را با اثر **All Caps** استخراج کنید:

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

## **سوالات متداول**

**چگونه می‌توانم متن داخل یک جدول را در یک اسلاید تغییر دهم؟**

برای تغییر متن داخل جدول در یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/#getTextFrame--) و قالب‌بندی پاراگراف‌ها از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) به‌روز کنید.

**چگونه می‌توانم به متن در یک اسلاید PowerPoint رنگ گرادیان اعمال کنم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.