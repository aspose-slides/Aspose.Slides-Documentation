---
title: قالب‌بندی متن ارائه در JavaScript
linktitle: قالب‌بندی متن
type: docs
weight: 50
url: /fa/nodejs-java/text-formatting/
keywords:
- برجسته کردن متن
- عبارات منظم
- تراز پاراگراف
- سبک متن
- پس‌زمینه متن
- شفافیت متن
- فاصله حروف
- ویژگی‌های قلم
- خانواده قلم
- چرخش متن
- زاویه چرخش
- فریم متن
- فاصله خطوط
- ویژگی Autofit
- لنگر فریم متن
- تب‌بندی متن
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی و سبک می‌دهید. قلم‌ها، رنگ‌ها، تراز و موارد دیگر را سفارشی کنید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه می‌توانید متن را در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای Node.js از طریق Java قالب‌بندی کنید. موضوعاتی مانند برجسته‌سازی، رنگ پس‌زمینه، شفافیت، فاصله‌گذاری حروف، ویژگی‌های قلم، چرخش، فاصله پاراگراف، رفتار Autofit، لنگر متن، ایست‌گاه‌های تب و تنظیمات زبان پوشش داده می‌شود.

در مثال‌های زیر از فایلی به نام **"sample.pptx"** استفاده خواهیم کرد که یک جعبه متن در اسلاید اول دارد و شامل متن زیر است:

![متن نمونه](sample_text.png)

## **برجسته‌سازی متن**

از متد [TextFrame.highlightText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) هنگام نیاز به برجسته‌سازی متنی که با یک الگوی نمونه خاص در یک فریم متن مطابقت دارد، استفاده کنید. این متد یک رنگ برجسته به بخش‌های متن مطابقت یافته اعمال می‌کند و می‌تواند همراه با [TextSearchOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textsearchoptions/) برای کنترل نحوه جستجو، برای مثال برای مطابقت فقط با کلمات کامل، به کار رود.

مثال کد زیر تمام رخدادهای کاراکترهای **"try"** را برجسته می‌کند و سپس فقط کلمه کامل **"to"** را برجسته می‌سازد.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // کلمه "try" را در شکل برجسته کنید.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // کلمه "to" را در شکل برجسته کنید.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن برجسته شده](highlighted_text.png)

## **برجسته‌سازی متن با استفاده از عبارات منظم**

متد [TextFrame.highlightRegex](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) متون مطابقت یافته توسط یک عبارت منظم را برجسته می‌کند. در Node.js از طریق Java، این API در [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) در دسترس است.

کد زیر تمام کلماتی را که **هفت کاراکتر یا بیشتر** دارند برجسته می‌کند:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // تمام کلماتی که دارای هفت یا بیشتر کاراکتر هستند را برجسته کنید.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متن برجسته شده با استفاده از عبارت منظم](highlighted_text_using_regex.png)

## **تنظیم رنگ پس‌زمینه متن**

از [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) برای تنظیم رنگ پیش‌فرض برجسته‌سازی یک پاراگراف، یا از [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) برای بخش‌های متنی جداگانه استفاده کنید.

کد زیر رنگ پس‌زمینه **تمام پاراگراف** را تنظیم می‌کند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // رنگ برجسته‌سازی را برای تمام پاراگراف تنظیم کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف خاکستری](gray_paragraph.png)

کد زیر رنگ پس‌زمینه **بخش‌های متنی با قلم بولد** را تنظیم می‌کند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // رنگ برجسته‌سازی را برای بخش متن تنظیم کنید.
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

## **تراز کردن پاراگراف‌های متن**

از [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) برای تنظیم تراز پاراگراف داخل یک فریم متن استفاده کنید. مقدار می‌تواند وسط‌چین، چپ‌چین، راست‌چین، توجیه‌شده و غیره باشد.

کد زیر پاراگراف را **به مرکز** تراز می‌کند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **تنظیم شفافیت برای متن**

شفافیت متن از طریق مؤلفه آلفای رنگی که به [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getFillFormat--) اختصاص داده می‌شود، کنترل می‌گردد. در مثال‌های زیر، `alpha = 50` یک مقدار آلفا در مقیاس 0‑255 است، نه درصد شفافیت.

کد زیر شفافیت **تمام پاراگراف** را اعمال می‌کند:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // رنگ پر متن را به رنگ شفاف تنظیم کنید.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![پاراگراف شفاف](transparent_paragraph.png)

کد زیر شفافیت **بخش‌های متنی با قلم بولد** را اعمال می‌کند:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **تنظیم فاصله‌گذاری کاراکترها برای متن**

از [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) برای افزایش یا کاهش فاصله بین کاراکترها در یک جعبه متن استفاده کنید.

کد JavaScript زیر فاصله‌گذاری کاراکترها را در **تمام پاراگراف** گسترش می‌دهد:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // فاصله کاراکترها را گسترش دهید.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری کاراکترها در پاراگراف](character_spacing_in_paragraph.png)

کد زیر فاصله‌گذاری کاراکترها را در **بخش‌های متنی با قلم بولد** گسترش می‌دهد:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // توجه: برای فشرده‌کردن فاصله کاراکتر از مقادیر منفی استفاده کنید.
            portion.getPortionFormat().setSpacing(3); // فاصله کاراکترها را گسترش دهید.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری کاراکترها در بخش‌های متنی](character_spacing_in_text_portions.png)

### **غیرفعال کردن کرنینگ برای فونت‌های خاص**

در برخی موارد، متنی که توسط Aspose.Slides رندر می‌شود، کمی فشرده‌تر از متن مشابه در PowerPoint به نظر می‌رسد. این می‌تواند به این دلیل باشد که PowerPoint داده‌های کرنینگ را برای برخی فونت‌ها نادیده می‌گیرد، حتی اگر فونت دارای اطلاعات کرنینگ معتبر باشد و کرنینگ در تنظیمات PowerPoint فعال باشد.

برای نزدیک‌تر کردن خروجی رندر به PowerPoint، می‌توانید کرنینگ را برای بخش‌های متنی که از فونت تحت تأثیر هستند غیرفعال کنید. مقدار [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) را به مقداری به‌طور قابل توجهی بزرگ‌تر از اندازه واقعی فونت تنظیم کنید:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

این تنظیم از اعمال کرنینگ به بخش‌های متنی منطبق جلوگیری می‌کند و می‌تواند به هم‌راستا شدن رندر Aspose.Slides با خروجی بصری PowerPoint برای فونت‌های تحت تأثیر این رفتار خاص کمک کند.

## **مدیریت ویژگی‌های قلم متن**

ویژگی‌های قلم می‌توانند در سطح پاراگراف از طریق [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) یا در بخش‌های جداگانه از طریق [PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) تنظیم شوند.

کد زیر قلم و سبک متن را برای **تمام پاراگراف** تنظیم می‌کند: اندازه قلم، بولد، ایتالیک، خط تحت نقطه‌ای و قلم Times New Roman را برای تمام بخش‌های پاراگراف اعمال می‌نماید.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

کد زیر ویژگی‌های مشابه را برای **بخش‌های متنی با قلم بولد** اعمال می‌کند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

![ویژگی‌های قلم برای بخش‌های متنی](font_properties_for_text_portions.png)

## **تنظیم چرخش متن**

از [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) برای تنظیم جهت از پیش تعریف‌شده متن در یک شکل استفاده کنید.

کد زیر جهت متن در شکل را به `Vertical270` تنظیم می‌کند که متن را **۹۰ درجه در جهت خلاف ساعت** می‌چرخاند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش متن](text_rotation.png)

## **تنظیم چرخش سفارشی برای فریم‌های متنی**

از [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) برای تنظیم زاویه چرخش سفارشی یک [TextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframe/) استفاده کنید.

کد زیر فریم متن را به میزان ۳ درجه در جهت ساعت درون شکل می‌چرخاند:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![چرخش سفارشی متن](custom_text_rotation.png)

## **تنظیم فاصله‌گذاری خطوط پاراگراف‌ها**

Aspose.Slides متدهای [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) و [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) را برای کنترل فاصله‌گذاری پاراگراف فراهم می‌کند. این ویژگی‌ها به‌صورت زیر استفاده می‌شوند:

* برای تعیین فاصله‌گذاری به‌عنوان درصدی از ارتفاع خط، مقدار مثبت استفاده کنید.
* برای تعیین فاصله‌گذاری به‌عنوان نقطه، مقدار منفی استفاده کنید.

کد زیر نشان می‌دهد چگونه فاصله‌گذاری خطوط را داخل پاراگراف مشخص کنید:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![فاصله‌گذاری خطوط داخل پاراگراف](line_spacing.png)

## **تنظیم نوع Autofit برای فریم‌های متنی**

متد [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) تعیین می‌کند که متن وقتی از مرزهای محفظه‌اش فراتر می‌رود چگونه رفتار کند. از آن برای کنترل اینکه آیا متن کوچک می‌شود، سرریز می‌شود یا به‌صورت خودکار اندازه شکل را تغییر می‌دهد، استفاده کنید.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم لنگر فریم‌های متنی**

متد [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) تعیین می‌کند که متن به‌صورت عمودی داخل یک شکل چگونه موقعیت یابد، برای مثال در بالا، وسط یا پایین.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تب‌بندی متن**

از [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و [ParagraphFormat.getTabs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraphformat/#getTabs--) برای پیکربندی ایست‌گاه‌های تب در یک پاراگراف استفاده کنید.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Aspose.Slides متد [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) را فراهم می‌کند که به شما اجازه می‌دهد زبان تصحیح املایی برای یک بخش متنی را تنظیم کنید. زبان تصحیح املایی تعیین می‌کند در PowerPoint برای املاء و گرامر چه زبانی استفاده شود.

کد زیر نشان می‌دهد چگونه زبان تصحیح املایی برای یک بخش متنی تنظیم شود:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // شناسه زبان تصحیح املایی را تنظیم کنید.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعریف زبان پیش‌فرض متنی که در هنگام بارگذاری یا ایجاد یک ارائه تولید می‌شود، استفاده کنید.

```javascript
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

برای اعمال قالب‌بندی پیش‌فرض متن در سطح ارائه، از [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--) استفاده کنید.

کد زیر نشان می‌دهد چگونه یک قلم بولد با اندازه ۱۴ پوینت به‌صورت پیش‌فرض برای تمام متن‌های اسلایدها در یک ارائه جدید تنظیم شود.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // دریافت فرمت پاراگراف سطح بالا.
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

## **استخراج متن با اثر تمام حروف بزرگ (All‑Caps)**

در PowerPoint، اعمال اثر **All Caps** بر قلم باعث می‌شود متن روی اسلاید به صورت حروف بزرگ نمایش داده شود حتی اگر به‌صورت حروف کوچک تایپ شده باشد. هنگام دریافت چنین بخشی از متن با Aspose.Slides، کتابخانه متن دقیقاً همان‌گونه که وارد شده است برمی‌گرداند. برای هم‌خوانی با متن نمایش داده‌شده، [TextCapType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textcaptype/) را بررسی کنید و هنگامی که مقدار `All` باشد، رشته برگردانده‌شده را به حروف بزرگ تبدیل کنید.

فرض کنید جعبه متنی زیر در اسلاید اول فایل **sample2.pptx** موجود است.

![اثر All Caps](all_caps_effect.png)

کد زیر نشان می‌دهد چگونه متنی که اثر **All Caps** روی آن اعمال شده است را استخراج کنید:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**چگونه متن داخل جدول در یک اسلاید را ویرایش کنیم؟**

برای ویرایش متن داخل جدول در یک اسلاید، از [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) استفاده کنید. سلول‌ها را پیمایش کنید و هر سلول را از طریق [Cell.getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/cell/#getTextFrame--) و قالب‌بندی پاراگراف‌ها از طریق [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--) به‌روزرسانی کنید.

**چگونه رنگ گرادیان را به متن در یک اسلاید PowerPoint اعمال کنیم؟**

برای اعمال رنگ گرادیان به متن، از [PortionFormat.getFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/#getFillFormat--) استفاده کنید. مقدار [FillFormat.setFillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) را به [FillType.Gradient](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) تنظیم کنید و ایست‌گاه‌های گرادیان، جهت و شفافیت را پیکربندی کنید.