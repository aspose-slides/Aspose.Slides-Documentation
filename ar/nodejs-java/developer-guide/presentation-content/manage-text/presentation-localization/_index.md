---
title: أتمتة تعريب العروض التقديمية في JavaScript
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/nodejs-java/presentation-localization/
keywords:
- تغيير اللغة
- فحص الإملاء
- قمع فحص الإملاء
- لغة الإثبات
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعيين لغات الإثبات لنص عرض PowerPoint وOpenDocument في JavaScript باستخدام Aspose.Slides، بما في ذلك القيم الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

Aspose.Slides for Node.js via Java يتيح لك تكوين بيانات إثبات التهجئة لأجزاء النص الفردية. استخدم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) لتحديد لغة الإثبات، [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) للسماح أو قمع فحص الإملاء، و[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) للتحكم في الحالة العامة لعدم الإثبات. نظرًا لأن هذه الإعدادات تُطبق على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على لغات متعددة وقواعد إثبات مختلفة.

تشرح هذه المقالة كيفية تعيين لغة لنص محدد، وتعيين اللغة الافتراضية للنص الجديد باستخدام [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)، وإنشاء فقرات متعددة اللغات، واختيار بين `SpellCheck` و`ProofDisabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). هذه الخصائص تخزن بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تُجرِّ إملاءً يعتمد على القاموس، ولا تُعيد كلمات مكتوبة خطأ.

## **تعيين لغة الإثبات للنص**

قم بإنشاء أو تحميل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، وامُر إلى جزء النص المطلوب عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getPortionFormat--)، ثم عيّن معرف لغته. المثال التالي ينشئ شكلاً، يحدد الإنجليزية البريطانية كلغة إثبات، ويحفظ النتيجة باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد لغة الإثبات التي يعيّنها Aspose.Slides للنص الذي يتم إنشاؤه حديثًا. هذا الإعداد مفيد عندما يستخدم معظم أو كل النص الجديد في عرض تقديمي نفس اللغة. لا يغيّر بيانات التعريف الخاصة بلغة النص الذي لديه بالفعل لغة صريحة.

المثال التالي ينشئ عرضًا تقديميًا يكون للنص الجديد فيه قواعد إملائية ألمانية:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخدام لغات متعددة في فقرة واحدة**

تحتوي [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/) على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/) منفصل لكل لغة وعيّن `LanguageId` الخاص به بشكل مستقل.

هذا المثال ينشئ فقرة واحدة تحتوي على أجزاء بالإنجليزية والفرنسية:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تمكين أو قمع فحص الإملاء لأجزاء النص الفردية**

[PortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portionformat/) يرث خصائص النص العامة المعرفة بواسطة [BasePortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/). احصل على تنسيق الجزء عبر [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/portion/#getPortionFormat--) واستخدم [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) للتحكم فيما إذا كان تطبيق العرض التقديمي قد يتحقق من الإملاء لهذا الجزء. القيمة الافتراضية هي `false`: `true` يسمح بفحص الإملاء، بينما `false` يقمعه.

ينطبق هذا الإعداد على أجزاء النص الفردية. لذلك يمكن لأجزاء مختلفة في نفس الفقرة أن تستخدم قيمًا مختلفة. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) و`setSpellCheck` يخدمان أغراضًا مكملة: `setLanguageId` يحدد لغة الإثبات، بينما `setSpellCheck` يحدد ما إذا كان يسمح بفحص الإملاء للجزء.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) يتحكم أيضًا في الإثبات، لكنه يُمثل حالة “عدم الإثبات” العامة كـ [NullableBool](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/nullablebool/). استخدم `setSpellCheck` عندما تحتاج إلى مفتاح بولياني مباشر خاصة بفحص الإملاء. استخدم `setProofDisabled` عندما تحتاج إلى الحفاظ على أو التحكم صراحةً ببيانات عدم الإثبات للعرض، بما فيها حالة `NotDefined`. إذا عيّنت كلا الخاصيتين، احرص على أن تكون قيمهما متسقة؛ لا تجمع `setSpellCheck(true)` مع `setProofDisabled(NullableBool.True)`.

هذه الخصائص تُكوّن بيانات إثبات تُستخدم بواسطة PowerPoint وتطبيقات العروض الأخرى. Aspose.Slides لا يستخدمها لتشغيل فحص إملائي قائم على القاموس أو لإرجاع قائمة بالكلمات المكتوبة خطأ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. اختلاف `SpellCheck` وحده لا يبقي هذه الأجزاء منفصلة؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة `SpellCheck` للجزء الأول. إذا احتاجت الأجزاء إلى إعدادات فحص إملائي مختلفة، استدعِ `joinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو فحص حدود الأجزاء الناتجة وإعادة تطبيق الإعدادات بعد ذلك. تظل الأجزاء ذات قيم `LanguageId` مختلفة منفصلة لأن تنسيق لغة الإثبات يختلف.

## **الأسئلة المتكررة**

**هل معرف اللغة يترجم النص؟**

لا. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) يخزن بيانات إثبات للإملاء والنحو؛ لا يغيّر محتوى النص. ترجم النص منفصلًا، ثم عيّن معرف اللغة المناسب لكل جزء مترجم.

**هل لغة الإثبات تتحكم في الخطوط أو القواطع أو التفاف السطر؟**

لا. معرف اللغة مخصص للإثبات. يعتمد عرض النص وتنسيقه أساسًا على [الخطوط](/slides/ar/nodejs-java/powerpoint-fonts/)، ونظام الكتابة، وإعدادات إطار النص. لضمان عرض موثوق، قدّم الخطوط المطلوبة، و[استبدال الخطوط](/slides/ar/nodejs-java/font-substitution/)، أو [تضمين الخطوط](/slides/ar/nodejs-java/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة استخدام عدة لغات إثبات؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب أن أستخدم `setDefaultTextLanguage` أم `setLanguageId`؟**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) عندما تريد قيمة افتراضية للنص المُنشأ حديثًا. استخدم [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) عندما يحتاج جزء معين إلى لغة إثبات صريحة أو عندما تحتوي الفقرة على لغات متعددة.