---
title: تنسيق نص العرض التقديمي في JavaScript
linktitle: تنسيق النص
type: docs
weight: 50
url: /ar/nodejs-java/text-formatting/
keywords:
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
- خاصية الملاءمة التلقائية
- تثبيت إطار النص
- جدولة النص
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تنسيق وتنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java. قم بتخصيص الخطوط، الألوان، المحاذاة، وأكثر."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق النص في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for Node.js عبر Java. يغطي ذلك ألوان الخلفية، الشفافية، تباعد الأحرف، خصائص الخط، الدوران، تباعد الفقرات، سلوك الملاءمة التلقائية، تثبيت النص، علامات التبويب، وإعدادات اللغة.

ما لم يذكر خلاف ذلك، تستخدم الأمثلة [sample.pptx](sample.pptx). الشكل الأول في الشريحة الأولى هو مربع نص، والفقرة الأولى فيه تحتوي على النص الموضح أدناه. كل من فهارس الشرائح والأشكال تبدأ من الصفر. تُظهر الأمثلة التي تختار أجزاءً غليظة تنسيقًا فعالًا، بما في ذلك تنسيق الغليظة الموروث:

![نص تجريبي](sample_text.png)

للعثور على النص الحرفي أو مطابقة تعبير عادي وتحديده، راجع [البحث واستبدال النص](/slides/ar/nodejs-java/search-and-replace-text/).

## **تعيين لون خلفية النص**

استخدم [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) لتعيين لون التظليل الافتراضي لفقرة، أو استخدم [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) لأجزاء النص الفردية.

المثال التالي يحدد تظليل رمادي فاتح كافتراضية للفقرة الأولى. الألوان الصريحة لأجزاء النص الفردية تتفوق على هذا الافتراضي:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين لون التظليل للفقرة بالكامل.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الرمادية](gray_paragraph.png)

يوضح مثال الشيفرة أدناه كيفية تعيين لون الخلفية لـ **أجزاء النص ذات الخط الغليظ**:

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
            // تعيين لون التظليل لجزء النص.
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

استخدم [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) لتعيين محاذاة الفقرة داخل إطار النص. يمكن أن تكون القيمة مركزية، محاذية إلى اليسار، محاذية إلى اليمين، مبررة، وهكذا.

الكود التالي يوضح كيفية محاذاة الفقرة إلى **الوسط**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // تعيين محاذاة الفقرة إلى الوسط.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة المحاذاة وسطًا](aligned_paragraph.png)

## **تعيين شفافية النص**

يتم التحكم في شفافية النص عبر المكوّن ألفا للون المخصص إلى [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). في الأمثلة أدناه، `alpha = 50` هو قيمة قناة ألفا ARGB على مقياس 0–255، وليس نسبة شفافية.

الكود التالي يوضح كيفية تطبيق شفافية على **الفقرة بالكامل**:

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

    // تعيين لون تعبئة النص إلى لون شفاف.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![الفقرة الشفافة](transparent_paragraph.png)

المثال التالي يوضح كيفية تطبيق شفافية على **أجزاء النص ذات الخط الغليظ**:

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

استخدم [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) لتوسيع أو تضييق التباعد بين الأحرف في مربع نص. يضيف الأمثلة 3 نقاط من التباعد؛ القيم السالبة تضيق النص.

الكود JavaScript التالي يوضح كيفية توسيع تباعد الأحرف في **الفقرة بالكامل**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // توسيع تباعد الأحرف.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

النتيجة:

![تباعد الأحرف في الفقرة](character_spacing_in_paragraph.png)

المثال التالي يوضح كيفية توسيع تباعد الأحرف في **أجزاء النص ذات الخط الغليظ**:

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
            // ملاحظة: استخدم قيمًا سالبة لضغط تباعد الأحرف.
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

### **تعطيل التآلف للخطوط المحددة**

في بعض الحالات، قد يبدو النص الذي تُظهره Aspose.Slides ضيقًا قليلاً مقارنةً بالنص نفسه في PowerPoint. يمكن أن يحدث ذلك لأن PowerPoint قد يتجاهل بيانات التآلف لبعض الخطوط، حتى لو كان الخط يحتوي على معلومات تآلف صالحة وتم تمكين التآلف في إعدادات PowerPoint.

لجعل النتيجة أقرب إلى PowerPoint في مثل هذه الحالات، يمكنك تعطيل التآلف لأجزاء النص التي تستخدم الخط المتأثر. عيّن [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) إلى قيمة أكبر من حجم الخط الفعلي. يتطلب هذا المثال ملف “presentation.pptx” يحتوي على مربع نص كأول شكل في الشريحة الأولى. يتحقق من أسماء الخطوط الفعالة، بما فيها الخطوط الموروثة، ويحدد عتبة 100 نقطة للأجزاء التي تستخدم Roboto. هذا يعطل التآلف للأجزاء المطابقة التي يقل حجم الخط عنها عن 100 نقطة:

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

للنص المطابق تحت العتبة، يمنع هذا الإعداد التآلف ويمكن أن يساعد في مواءمة عرض Aspose.Slides مع مخرجات PowerPoint البصرية للخطوط المتأثرة بهذا السلوك الخاص بـ PowerPoint.

## **إدارة خصائص خط النص**

يمكن تعيين خصائص الخط على مستوى الفقرة عبر [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) أو على أجزاء فردية عبر [PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/).

المثال التالي يحدد الخط الافتراضي للفقرة الأولى كخط Times New Roman بحجم 12 نقطة مع تنسيق غليظ، مائل، وتسطير منقط. التنسيق الصريح على الأجزاء الفردية يتفوق على هذه القيم الافتراضية:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
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

المثال التالي يطبق خط Times New Roman بحجم 13 نقطة، تنسيق مائل، وتسطير منقط على الأجزاء التي يكون تنسيقها الفعال غليظًا:

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

استخدم [TextFrameFormat.setTextVerticalType](httpshttps://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) لتعيين توجيه نص مسبق داخل شكل.

الكود التالي يحدد توجيه النص داخل الشكل إلى [TextVerticalType.Vertical270](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textverticaltype/)، مما يدير النص **90 درجة عكس اتجاه عقارب الساعة**:

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

النتيجة:

![دوران النص](text_rotation.png)

## **تعيين دوران مخصص لإطارات النص**

استخدم [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) لتعيين زاوية دوران مخصصة لـ [TextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframe/).

الكود أدناه يدور إطار النص بمقدار 3 درجات مع اتجاه عقارب الساعة داخل الشكل:

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

النتيجة:

![دوران نص مخصص](custom_text_rotation.png)

## **تعيين تباعد السطر للفقرات**

توفر Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-)، [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-)، و[ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) للتحكم في تباعد الفقرة. تُستعمل هذه الخصائص كما يلي:

* استخدم قيمة موجبة لتحديد تباعد السطر كنسبة مئوية من ارتفاع السطر.
* استخدم قيمة سالبة لتحديد تباعد السطر بالنقاط.

المثال التالي يحدد التباعد داخل الفقرة الأولى إلى 200٪ من ارتفاع السطر (تباعد مزدوج):

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

النتيجة:

![تباعد السطر داخل الفقرة](line_spacing.png)

## **التحكم في كسرة السطر**

قواعد كسر سطر الفقرة مفيدة في كتل النص الضيقة والعروض التي تُدمج النص اللاتيني والنصوص الشرقية الآسيوية. الطرق التالية تنتمي إلى [ParagraphFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/)، لذا فهي تُطبق على الفقرة بأكملها:

- [setLatinLineBreak](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak-byte-) يتحكم في قواعد كسر سطر اللاتيني. في النص المختلط، قد يغيّر ذلك موضع كسر النص الآسيوي المجاور وعلامات الترقيم.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak-byte-) يتحكم في قواعد كسر سطر الشرق الأصيل، بما فيها القيود على الأحرف في بداية ونهاية السطر.

هذه القواعد لا تحل محل [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setWrapText-byte-)، الذي يُمكّن الالتفاف التلقائي داخل إطار النص. فهي تُؤثر على التخطيط عند حدوث الالتفاف؛ لا تُدرج أحرف كسر سطر. يكسر السطر الصريح سطرًا جديدًا داخل الفقرة مستقلًا عن العرض المتاح.

المثال المستقل التالي يُنشئ كتلة نص ضيقة تحتوي على نص صيني ولاتيني. يُحدد كلا خيارَي كسر السطر صراحةً ويحفظ الملف “line_breaking.pptx”. لتجربة أي قاعدة، غيّر القيمة المقابلة مع إبقاء الإعدادات الأخرى ثابتة. يستخدم المثال خط Arial بحجم 24 نقطة وSimSun مع عرض إطار 160 نقطة وهوامش أفقية صفرية للإطار النصي. يُستدعى [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) مع [TextAutofitType.None](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textautofittype/) للحفاظ على حجم النص وإطار الشكل ثابتين.

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

## **التحكم في علامات الترقيم المتدلية**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation-byte-) يسمح للعلامات الترقيمية المؤهلة بالتمدد خارج الحافة اليمنى لسطر النص بدلاً من الانتقال إلى السطر التالي. يُطبق على الفقرة بأكملها ويختلف عن الإزاحة المتدلية.

المثال المستقل التالي يفعل علامات الترقيم المتدلية في إطار نص عرضه 100 نقطة ويحفظ الملف “hanging_punctuation.pptx”. مع خط Arial بحجم 24 نقطة وهوامش أفقية صفرية، يبقى الفاصلة النهائية بعد كلمة “sentence” وتتمد خارج حافة النص اليمنى. عيّن الخاصية إلى [NullableBool.False](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/nullablebool/) للمقارنة: مع هذه الإعدادات، تحتل الفاصلة سطرًا منفصلًا. تم تمكين الالتفاف وتعطيل الملاءمة التلقائية للحفاظ على عرض المتاح ثابتًا.

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

ليس كل علامة ترقيم يمكنها التعليق. تعتمد النتيجة المرئية على توفر الخط والتخطيط: تغيير الخط أو العرض المتاح أو الهوامش أو إعدادات الملاءمة قد يزيل الفرق المرئي.

## **تعيين نوع الملاءمة التلقائية لإطارات النص**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) يحدد كيفية تصرف النص عندما يتجاوز حدود الحاوية الخاصة به. استخدمه للتحكم فيما إذا كان النص يتقلص، يفيض، أو يُعيد تحجيم الشكل تلقائيًا. المثال التالي يُ configures الشكل لإعادة التحجيم ليتناسب مع نصه ويحفظ النتيجة إلى “autofit_type.pptx”.

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

لعد الأسطر بعد الالتفاف التلقائي ورؤية كيف يغيّر عرض النص أو الشكل النتيجة، راجع [Count Rendered Lines](/slides/ar/nodejs-java/manage-paragraph/). عدد الأسطر وحده لا يدل على ما إذا كان النص يفيض عن حاويته.

## **تعيين تثبيت إطارات النص**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) يعرّف كيف يُوضع النص عموديًا داخل الشكل، مثلاً في الأعلى، الوسط، أو الأسفل. المثال التالي يثبت النص في أسفل الشكل الأول ويحفظ النتيجة إلى “text_anchor.pptx”.

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

## **تعيين جدولة النص**

استخدم [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) و[ParagraphFormat.getTabs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraphformat/#getTabs--) لتكوين علامات التبويب في فقرة. المثال التالي يحدد الفاصل الافتراضي للتاب إلى 100 نقطة ويضيف علامة تبويب محاذية إلى اليسار عند 30 نقطة. تؤثر هذه الإعدادات على النص الذي يحتوي على أحرف تبويب.

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

النتيجة:

![علامات التبويب في الفقرة](paragraph_tabs.png)

## **تعيين لغة التدقيق**

توفر Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)، والتي تسمح لك بتعيين لغة التدقيق لجزء النص. تحدد لغة التدقيق اللغة المستخدمة لتدقيق الإملاء والنحو في PowerPoint.

المثال التالي يتطلب “presentation.pptx” مع مربع نص كأول شكل في الشريحة الأولى وعلى الأقل فقرة واحدة. يستبدل محتويات الفقرة الأولى بـ “1。”، يعين SimSun كخط لها، ويحدد لغة التدقيق الصينية المبسطة (`zh-CN`). يحفظ النتيجة إلى “proofing_language.pptx”:

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

    // تعيين معرّف لغة التدقيق.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين اللغة الافتراضية**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد اللغة الافتراضية للنص الذي يُنشأ أثناء تحميل أو إنشاء عرض تقديمي. المثال التالي يُنشئ عرضًا تقديميًا بالإنجليزية الأمريكية كلغة نص افتراضية، يضيف مربع نص، ويطبع `en-US` للجزء النصي الأول.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

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

لتطبيق تنسيق نص افتراضي على مستوى العرض التقديمي، استخدم [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

المثال التالي يحدد خطًا غليظًا بحجم 14 نقطة كافتراضية للفقرات المستوى العلوي في عرض تقديمي جديد ويحفظه إلى “default_text_style.pptx”. يمكن للنص أن يرث هذه القيم الافتراضية ما لم يتجاوزها تنسيق أكثر تحديدًا.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // الحصول على تنسيق الفقرة المستوى الأعلى.
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

## **استخراج النص مع تأثير الحروف الكبيرة كلها**

في PowerPoint، يُظهر تطبيق تأثير الخط **All Caps** النص بأحرف كبيرة على الشريحة حتى لو كُتب أصلاً بأحرف صغيرة. عندما تسترجع مثل هذا الجزء النصي باستخدام Aspose.Slides، تُعيد المكتبة النص كما كُتب أصلاً. لمطابقة النص المعروض، افحص [TextCapType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textcaptype/) وحوّل السلسلة المسترجعة إلى أحرف كبيرة عندما تكون القيمة `All`.

هذا المثال يتطلب “sample2.pptx” مع مربع نص كأول شكل في الشريحة الأولى. يحتوي الجزء الأول من الفقرة الأولى على “Hello, Aspose!” مع تطبيق تأثير All Caps، كما هو موضح أدناه.

![تأثير الحروف الكبيرة كلها](all_caps_effect.png)

الكود أدناه يوضح كيفية استخراج النص مع تطبيق تأثير **All Caps**:

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

الإخراج:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **الأسئلة المتكررة**

**كيف يمكن تعديل النص في جدول على شريحة؟**

لتعديل النص في جدول على شريحة، استخدم [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/). استعرض الخلايا وقم بتحديث كل خلية عبر [Cell.getTextFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/cell/#getTextFrame--) وتنسيق الفقرة عبر [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**كيف يمكن تطبيق لون تدرج على النص في شريحة PowerPoint؟**

لتطبيق لون تدرج على النص، استخدم [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). عيّن [FillFormat.setFillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) إلى [FillType.Gradient](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) وخصص نقاط التدرج، الاتجاه، والشفافية.