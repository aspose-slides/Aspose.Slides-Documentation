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
- فاصله بین حروف
- ویژگی‌های فونت
- خانواده فونت
- چرخش متن
- زاویه چرخش
- قاب متن
- فاصله بین خطوط
- ویژگی autofit
- لنگر قاب متن
- تب‌گذاری متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "قالب‌بندی و استایل‌دهی به متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java. سفارشی‌سازی فونت‌ها، رنگ‌ها، تراز و موارد دیگر."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی کنید. این مقاله به رنگ‌های پس‌زمینه، شفافیت، فاصله‌گذاری بین حروف، ویژگی‌های فونت، چرخش، فاصله‌گذاری پاراگراف، رفتار autofit، لنگرگذاری متن، توقف‌های تب و تنظیمات زبان می‌پردازد.

در مثال‌های زیر، فایلی به نام "sample.pptx" استفاده می‌شود که یک جعبه متن واحد در اسلاید اول دارد و شامل متن زیر است:

![متن نمونه](sample_text.png)

برای یافتن و برجسته کردن متن دقیق یا مطابقت‌های عبارات منظم، ببینید [جستجو و جایگزینی متن](/slides/fa/nodejs-java/search-and-replace-text/).

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ برجسته پیش‌فرض یک پاراگراف استفاده کنید، یا از [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) برای بخش‌های متن جداگانه.

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **کل پاراگراف** تنظیم کنید:

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

کد زیر نشان می‌دهد چگونه رنگ پس‌زمینه را برای **بخش‌های متن با فونت ضخیم** تنظیم کنید:

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

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند centered، left-aligned، right-aligned، justified و غیره باشد.

کد زیر نشان می‌دهد چگونه پاراگراف را به **مرکز** تراز کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تنظیم تراز پاراگراف به مرکز.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف تراز شده](aligned_paragraph.png)

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگ اختصاص داده شده به [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) کنترل می‌شود. در مثال‌های زیر، `alpha = 50` یک مقدار کانال آلفای ARGB در مقیاس 0–255 است، نه درصد شفافیت.

کد زیر نشان می‌دهد چگونه شفافیت را برای **کل پاراگراف** اعمال کنید:

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

کد زیر نشان می‌دهد چگونه شفافیت را برای **بخش‌های متن با فونت ضخیم** اعمال کنید:

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

## **تنظیم فاصله بین حروف برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) برای گسترش یا فشرده‌سازی فاصله بین حروف در یک جعبه متن استفاده کنید.

کد JavaScript زیر نشان می‌دهد چگونه فاصله بین حروف را در **کل پاراگراف** گسترش دهید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // افزایش فاصله بین حروف.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله حروف در پاراگراف](character_spacing_in_paragraph.png)

کد زیر نشان می‌دهد چگونه فاصله بین حروف را در **بخش‌های متن با فونت ضخیم** گسترش دهید:

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
            // توجه: برای فشرده‌سازی فاصله بین حروف از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // افزایش فاصله بین حروف.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله حروف در بخش‌های متن](character_spacing_in_text_portions.png)

### **غیرفعال کردن Kerning برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، کمی فشرده‌تر از همان متن در PowerPoint ظاهر می‌شود. این می‌تواند به این دلیل باشد که PowerPoint داده‌های kerning را برای برخی فونت‌ها نادیده می‌گیرد، حتی اگر فونت حاوی اطلاعات kerning معتبر باشد و kerning در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر شده به PowerPoint، می‌توانید kerning را برای بخش‌های متنی که از فونت مورد نظر استفاده می‌کنند، غیرفعال کنید. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) را به مقداری بسیار بزرگ‌تر از اندازه واقعی فونت تنظیم کنید:

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
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این تنظیم از اعمال kerning بر بخش‌های متنی منطبق جلوگیری می‌کند و می‌تواند به هم‌راستایی رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌های تحت تأثیر این رفتار خاص PowerPoint کمک کند.

## **مدیریت ویژگی‌های فونت متن**

ویژگی‌های فونت می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر فونت و سبک متن را برای **کل پاراگراف** تنظیم می‌کند: اندازه فونت، ضخامت، کج، زیرخط نقطه‌دار و فونت Times New Roman را برای تمام بخش‌ها اعمال می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // ویژگی‌های قلم برای پاراگراف تنظیم شود.
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

![ویژگی‌های فونت برای پاراگراف](font_properties_for_paragraph.png)

کد زیر ویژگی‌های مشابه را برای **بخش‌های متن با فونت ضخیم** اعمال می‌کند:

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

![ویژگی‌های فونت برای بخش‌های متن](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) برای تنظیم جهت پیش‌تعریف‌شده متن داخل یک شکل استفاده کنید.

کد زیر جهت متن داخل شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه ضد ساعت‌گرد** می‌چرخاند:

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

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش سفارشی برای یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را ۳ درجه ساعت‌گرد در داخل شکل می‌چرخاند:

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

## **تنظیم فاصله‌گذاری بین خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) را برای کنترل فاصله‌گذاری پاراگراف فراهم می‌کند. این ویژگی‌ها به شکل زیر استفاده می‌شوند:

* برای تعیین فاصله خط به صورت درصدی از ارتفاع خط، از مقدار مثبت استفاده کنید.
* برای تعیین فاصله خط به نقطه، از مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله خط را درون پاراگراف مشخص کنید:

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

![فاصله خط درون پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متن**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) نحوه رفتار متن را وقتی که از مرزهای محفظه‌اش فراتر می‌رود، تعیین می‌کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، سرریز می‌شود یا به‌طور خودکار شکل را تغییر اندازه می‌دهد، استفاده کنید.

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

برای شمارش خطوط پس از بسته‌بندی خودکار و مشاهدهٔ نحوهٔ تغییر عرض متن یا شکل، به [Count Rendered Lines](/slides/fa/nodejs-java/manage-paragraph/) مراجعه کنید. تنها تعداد خطوط نشان‌دهندهٔ سرریز شدن متن نیست.

## **تنظیم لنگر فریم‌های متن**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) نحوهٔ موقعیت عمودی متن داخل یک شکل را تعریف می‌کند، برای مثال در بالا، وسط یا پایین.

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

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getTabs--) برای پیکربندی توقف‌های تب در یک پاراگراف استفاده کنید.

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

## **تنظیم زبان تصحیح‌کننده**

Aspose.Slides متد [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما امکان می‌دهد زبان تصحیح‌کننده را برای یک بخش متن تنظیم کنید. زبان تصحیح‌کننده تعیین می‌کند کدام زبان برای بررسی املایی و گرامری در PowerPoint استفاده شود.

کد زیر نشان می‌دهد چگونه زبان تصحیح‌کننده را برای یک بخش متن تنظیم کنید:

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

    // شناسه زبان تصحیح‌کننده را تنظیم کنید.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که هنگام بارگذاری یا ایجاد یک ارائه ساخته می‌شود، استفاده کنید.

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

    // زبان اولین بخش را بررسی کنید.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تنظیم سبک متن پیش‌فرض**

برای اعمال فرمت‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک فونت ضخیم با اندازه ۱۴ pt به عنوان پیش‌فرض برای تمام متن‌ها در اسلایدها در یک ارائهٔ جدید تنظیم شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // دریافت فرمت پاراگراف سطح بالایی.
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

در PowerPoint، اعمال اثر **All Caps** باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر در ابتدا با حروف کوچک وارد شده باشد. هنگام بازیابی چنین بخشی از متن با Aspose.Slides، کتابخانه متن را دقیقاً همان‌طور که وارد شده است برمی‌گرداند. برای تطبیق با متن نمایش‌داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textcaptype/) را بررسی کنید و هنگام مقدار `All` رشتهٔ بازگردانده‌شده را به حروف بزرگ تبدیل کنید.

فرض کنیم جعبه متن زیر را در اسلاید اول فایل sample2.pptx داریم.

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

## **سوالات متداول**

**چگونه متن را در یک جدول روی اسلاید اصلاح کنیم؟**

برای اصلاح متن در یک جدول روی اسلاید، از [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) استفاده کنید. از طریق سلول‌ها پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/#getTextFrame--) و قالب‌بندی پاراگراف را از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را به متن در اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--) استفاده کنید. [FillFormat.setFillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) تنظیم کنید و توقف‌های گرادیان، جهت و شفافیت را پیکربندی کنید.