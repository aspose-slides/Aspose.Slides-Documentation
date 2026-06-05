---
title: تنسيق نص العرض التقديمي في JavaScript
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/nodejs-java/text-formatting/
keywords:
- تمييز النص
- تعبير نمطي
- محاذاة الفقرة
- نمط النص
- خلفية النص
- شفافية النص
- تباعد الأحرف
- خصائص الخط
- عائلة الخط
- دوران النص
- زاوية الدوران
- إطار النص
- تباعد الأسطر
- خاصية الملاءمة الذاتية
- تثبيت إطار النص
- تبويب النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تنسيق وأسلوب النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. تخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

يوضح هذا المقال كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. يغطي التمييز، ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة الذاتية، تثبيت النص، مسافات التبويب، وإعدادات اللغة.

في الأمثلة أدناه، سنستخدم ملفًا باسم **"sample.pptx"** يحتوي على صندوق نص واحد في الشريحة الأولى بالنص التالي:

![نص العينة](sample_text.png)

## **تمييز النص**

استخدم طريقة [TextFrame.highlightText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) عندما تحتاج إلى تمييز النص الذي يطابق عينة معينة داخل إطار النص. تُطبق الطريقة لون تمييز على أجزاء النص المطابقة ويمكن استخدامها مع [TextSearchOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textsearchoptions/) للتحكم في طريقة البحث، على سبيل المثال للتماشي مع الكلمات كاملة فقط.

الكود التالي يميز جميع تكرارات الأحرف **"try"** ثم يميز الكلمة الكاملة **"to"** فقط.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // تمييز الكلمة "try" في الشكل.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // تمييز الكلمة "to" في الشكل.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![النص المظلل](highlighted_text.png)

## **تمييز النص باستخدام التعبيرات النمطية**

طريقة [TextFrame.highlightRegex](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) تميز النصوص التي يتم العثور عليها عبر تعبير نمطي. في Node.js عبر Java، يتم إتاحة هذه الواجهة على [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).

الكود التالي يميز جميع الكلمات التي تحتوي على **سبعة أحرف أو أكثر**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // تمييز جميع الكلمات التي تحتوي على سبعة أحرف أو أكثر.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![النص المظلل باستخدام التعبير النمطي](highlighted_text_using_regex.png)

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) لتعيين لون التمييز الافتراضي للفقرة، أو استخدم [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) لأجزاء النص الفردية.

الكود التالي يُظهر كيفية تعيين لون الخلفية للـ **فقرة كاملة**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون التمييز للفقرة بأكملها.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

الكود التالي يوضح كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط العريض**:

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
            // تعيين لون التمييز لجزء النص.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![أجزاء النص الرمادية](gray_text_portions.png)

## **محاذاة فقرات النص**

استخدم [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) لضبط محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزة، محاذاة إلى اليسار، محاذاة إلى اليمين، مبررة، وغيرها.

الكود التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين محاذاة الفقرة إلى الوسط.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة المحاذاة إلى الوسط](aligned_paragraph.png)

## **تعيين الشفافية للنص**

تُتحكم شفافية النص من خلال المكوّن alfa للون المعين إلى [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة alfa بنظام ARGB على مقياس 0‑255، وليس نسبة شفافية.

الكود التالي يوضح كيفية تطبيق الشفافية على **الفقرة كاملة**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // تعيين لون ملء النص إلى لون شفاف.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

الكود التالي يوضح كيفية تطبيق الشفافية على **أجزاء النص ذات الخط العريض**:

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

            // تعيين شفافية جزء النص.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![أجزاء النص الشفافة](transparent_text_portions.png)

## **تعيين تباعد الأحرف للنص**

استخدم [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) لتكبير أو تصغير التباعد بين الأحرف في صندوق النص.

الكود التالي يُظهر كيفية تكبير تباعد الأحرف في **الفقرة كاملة**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

الكود التالي يوضح كيفية تكبير تباعد الأحرف في **أجزاء النص ذات الخط العريض**:

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
            // ملاحظة: استخدم القيم السلبية لضغط تباعد الأحرف.
            portion.getPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في أجزاء النص](character_spacing_in_text_portions.png)

### **تعطيل التقارب (Kerning) للخطوط المحددة**

في بعض الحالات قد يظهر النص المُنشأ بواسطة Aspose.Slides أكثر ضيقًا قليلًا مقارنة بالنص المعروض في PowerPoint. يُمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات الـ kerning لبعض الخطوط، حتى عندما يحتوي الخط على معلومات kerning صالحة ويتم تمكينها في إعدادات PowerPoint.

لجعل الإخراج المُنشأ أقرب إلى ما يولده PowerPoint في هذه الحالات، يمكنك تعطيل الـ kerning لأجزاء النص التي تستخدم الخط المتأثر. اضبط [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) إلى قيمة أكبر بكثير من حجم الخط الفعلي:

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

هذا الإعداد يمنع تطبيق الـ kerning على أجزاء النص المطابقة ويمكن أن يساعد في مطابقة مظهر Aspose.Slides مع مظهر PowerPoint للخطوط المتأثرة بهذا السلوك المحدد لبرنامج PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) أو على أجزاء منفردة عبر [PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/).

الكود التالي يعيّن الخط ونمط النص للفقرة بأكملها: يطبق حجم الخط، العريض، المائل، خط سفلي منقط، وخط Times New Roman على جميع الأجزاء في الفقرة.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // تعيين خصائص الخط للفقرة.
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

النتيجة:

![خصائص الخط للفقرة](font_properties_for_paragraph.png)

الكود التالي يطبق خصائص مشابهة على **أجزاء النص ذات الخط العريض**:

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

            // تعيين خصائص الخط لجزء النص.
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

النتيجة:

![خصائص الخط لأجزاء النص](font_properties_for_text_portions.png)

## **تعيين دوران النص**

استخدم [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) لتعيين اتجاه نص مسبقًا داخل الشكل.

الكود التالي يعيّن اتجاه النص في الشكل إلى `Vertical270`، مما يدور النص **90 درجة عكس عقارب الساعة**:

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

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).

الكود التالي يدور إطار النص بمقدار 3 درجات باتجاه عقارب الساعة داخل الشكل:

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

النتيجة:

![دوران النص المخصص](custom_text_rotation.png)

## **تعيين تباعد الأسطر للفقرات**

توفر Aspose.Slides الطرق [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)، و[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرات. تُستعمل هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد الأسطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد الأسطر بالنقاط.

الكود التالي يوضح كيفية تحديد تباعد الأسطر داخل الفقرة:

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

النتيجة:

![تباعد الأسطر داخل الفقرة](line_spacing.png)

## **تعيين نوع الملاءمة الذاتية لإطارات النص**

تحدد الطريقة [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) كيفية تصرف النص عندما يتجاوز حدود حاويته. استخدمها للتحكم فيما إذا كان النص سيصغر، سيتخطى، أو سيعيد تحجيم الشكل تلقائيًا.

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

## **تعيين تثبيت إطارات النص**

تحدد الطريقة [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) كيفية وضع النص عموديًا داخل الشكل، مثلًا في الأعلى، الوسط، أو الأسفل.

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

## **تعيين تبويب النص**

استخدم [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و[ParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getTabs--) لتكوين مسافات التبويب في الفقرة.

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

النتيجة:

![تبويبات الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides الطريقة [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) التي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة في فحص الإملاء والقواعد في PowerPoint.

الكود التالي يوضح كيفية تعيين لغة التدقيق لجزء النص:

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

    // تعيين معرف لغة التدقيق.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // إضافة شكل مستطيل جديد مع نص.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // التحقق من لغة الجزء الأول.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **تعيين نمط النص الافتراضي**

لتطبيق تنسيق نص افتراضي على مستوى العرض، استخدم [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

الكود التالي يوضح كيفية تعيين خط عريض بحجم 14 نقطة كخط افتراضي لكل النصوص عبر الشرائح في عرض تقديمي جديد.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // الحصول على تنسيق الفقرة في المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة كليًا (All‑Caps)**

في PowerPoint، تطبيق تأثير **All Caps** يجعل النص يظهر بأحرف كبيرة على الشريحة حتى لو تم كتابته أصلاً بأحرف صغيرة. عند استرجاع مثل هذا الجزء من النص باستخدام Aspose.Slides، تُعيد المكتبة النص كما تم إدخاله. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textcaptype/) وحول السلسلة المرجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

لنفترض أن لدينا صندوق النص التالي في الشريحة الأولى من ملف **sample2.pptx**.

![تأثير All Caps](all_caps_effect.png)

الكود التالي يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة الشائعة**

**كيف يمكن تعديل النص داخل جدول في شريحة؟**

لتعديل النص داخل جدول في شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/). قم بالتكرار عبر الخلايا وحدث كل خلية عبر [Cell.getTextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/#getTextFrame--) وتنسيق الفقرات عبر [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**كيف يمكن تطبيق تدرج لوني على النص في شريحة PowerPoint؟**

لتطبيق تدرج لوني على النص، استخدم [PortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/#getFillFormat--). عيّن [FillFormat.setFillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) وقم بتكوين نقاط التدرج، الاتجاه، والشفافية.