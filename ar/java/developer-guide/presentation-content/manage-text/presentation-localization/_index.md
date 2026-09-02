---
title: أتمتة توطين العروض التقديمية في جافا
linktitle: توطين العروض التقديمية
type: docs
weight: 100
url: /ar/java/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- كبح تدقيق إملائي
- لغة التدقيق
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعيين لغات التدقيق لنصوص عروض PowerPoint وOpenDocument في جافا باستخدام Aspose.Slides، بما في ذلك القيم الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

تتيح لك Aspose.Slides for Java تكوين بيانات التعريف للتدقيق للجزئيات النصية الفردية. استخدم [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) لتحديد لغة التدقيق، و[IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) للسماح أو كبح فحص الإملاء، و[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) للتحكم في حالة عدم التدقيق الأوسع. نظرًا لأن هذه الإعدادات تُطبق على مستوى الجزئية، يمكن لفقرة واحدة أن تحتوي على لغات متعددة وقواعد تدقيق مختلفة.

تشرح هذه المقالة كيفية تعيين لغة لنص محدد، وتعيين اللغة الافتراضية للنص الجديد باستخدام [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)، وبناء فقرات متعددة اللغات، واختيار بين `SpellCheck` و`ProofDisabled`، والحفاظ على الإعدادات المطلوبة عند استخدام [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). تقوم هذه الخصائص بتخزين بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تُجري تدقيق إملائي معتمد على القاموس، ولا تُرجع الكلمات غير الصحيحة إملائيًا.

## **تعيين لغة التدقيق للنص**

أنشئ أو قم بتحميل [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، ثم افتح الجزئية النصية المطلوبة عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getPortionFormat--)، وعين معرف لغتها. المثال التالي ينشئ شكلًا، ويعيّن الإنجليزية البريطانية كلغة تدقيق، ويحفظ النتيجة باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد لغة التدقيق التي يقوم Aspose.Slides بتعيينها للنص المُنشأ حديثًا. يكون هذا الإعداد مفيدًا عندما يستخدم معظم أو كل النص الجديد في العرض التقديمي نفس اللغة. ولا يغيّر بيانات التعريف اللغوية للنص الذي لديه لغة صريحة مسبقًا.

المثال التالي ينشئ عرضًا تقديميًا يكون نصه الجديد يستخدم قواعد التدقيق الألمانية:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استخدام لغات متعددة في فقرة واحدة**

[IParagraph](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iparagraph/) يحتوي على مجموعة من الجزئيات النصية. أنشئ [Portion](https://reference.aspose.com/slides/ar/java/com.aspose.slides/portion/) منفصلة لكل لغة وقم بتعيين `LanguageId` لها بشكل مستقل.

هذا المثال ينشئ فقرة واحدة تحتوي على جزئيات إنجليزية وفرنسية:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تمكين أو كبح فحص الإملاء للجزئيات الفردية**

[IPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportionformat/) يرث خصائص النص العامة المعرفة في [IBasePortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/). يمكن الوصول إلى تنسيق الجزئية عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iportion/#getPortionFormat--) واستخدام [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) للتحكم فيما إذا كان تطبيق العرض التقديمي قد يتحقق من الإملاء لتلك الجزئية. القيمة الافتراضية هي `false`: `true` يسمح بفحص الإملاء، بينما `false` يكبحه.

يُطبق هذا الإعداد على الجزئيات النصية الفردية. وبالتالي يمكن للجزئيات المختلفة في نفس الفقرة استخدام قيم مختلفة. كل من [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) و`setSpellCheck` يخدمان أغراضًا مكملة: `setLanguageId` يحدد لغة التدقيق، بينما `setSpellCheck` يقرر ما إذا كان يُسمح بفحص الإملاء للجزئية.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) يتحكم أيضًا في التدقيق، لكنه يمثل حالة "عدم التدقيق" الأوسع كـ [NullableBool](https://reference.aspose.com/slides/ar/java/com.aspose.slides/nullablebool/). استخدم `setSpellCheck` عندما تحتاج إلى مفتاح Boolean مباشر خاص بفحص الإملاء. استخدم `setProofDisabled` عندما تحتاج إلى الحفاظ على بيانات التعريف الخاصة بعدم التدقيق في العرض التقديمي أو التحكم فيها صراحةً، بما في ذلك حالتها `NotDefined`. إذا قمت بتعيين الخاصيتين، حافظ على توافق القيم؛ لا تجمع بين `setSpellCheck(true)` و`setProofDisabled(NullableBool.True)`.

هذه الخصائص تُعدّ بيانات التعريف الخاصة بالتدقيق التي يستخدمها PowerPoint وتطبيقات العروض التقديمية الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لتشغيل تدقيق إملائي معتمد على القاموس أو لإرجاع قائمة بالكلمات الخاطئة إملائيًا.

المثال الكامل التالي ينشئ عرضًا تقديميًا إدخالًا، يقوم بتحميله، يعين إعدادات فحص إملائي مختلفة ولغات تدقيق لجزئيتين في نفس الفقرة، يحفظ النتيجة، يعيد فتحه، ويتحقق من القيم المخزنة:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) يجمع الجزئيات المتجاورة التي لها نفس التنسيق. الفرق في `SpellCheck` فقط لا يبقي هذه الجزئيات منفصلة؛ بعد دمجها، تحتفظ الجزئية الناتجة بقيمة `SpellCheck` للجزئية الأولى. إذا كانت الجزئيات تحتاج إلى إعدادات فحص إملائي مختلفة، استدعِ `joinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو افحص حدود الجزئية الناتجة وأعد تطبيق الإعدادات لاحقًا. تظل الجزئيات ذات قيم `LanguageId` المختلفة منفصلة لأن تنسيق لغة التدقيق يختلف.

## **الأسئلة الشائعة**

**هل معرف اللغة يترجم النص؟**

لا. يقوم [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) بتخزين بيانات التعريف الخاصة بالتدقيق للإملاء والقواعد؛ ولا يغيّر محتوى النص. ترجم النص بشكل منفصل، ثم عيّن معرف اللغة المناسب لكل جزئية مترجمة.

**هل لغة التدقيق تتحكم في الخطوط أو الفواصل أو التفاف السطر؟**

لا. معرف اللغة مخصص للتدقيق فقط. يعتمد عرض النص وتخطيطه أساسًا على الخطوط المتاحة [fonts](/slides/ar/java/powerpoint-fonts/)، ونظام الكتابة، وإعدادات إطار النص. لضمان عرض موثوق، قدم الخطوط المطلوبة، واضبط [font substitution](/slides/ar/java/font-substitution/)، أو [embed fonts](/slides/ar/java/embedded-font/) في العرض التقديمي.

**هل يمكن لفقرة واحدة أن تستخدم عدة لغات تدقيق؟**

نعم. عيّن كل لغة إلى جزئية منفصلة، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب أن أستخدم `setDefaultTextLanguage` أم `setLanguageId`؟**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) عندما تريد قيمة افتراضية للنص المُنشأ حديثًا. استخدم [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) عندما تحتاج جزئية معينة إلى لغة تدقيق صريحة أو عندما تحتوي الفقرة على لغات متعددة.