---
title: "أتمتة توطين العرض التقديمي على Android"
linktitle: "توطين العرض التقديمي"
type: docs
weight: 100
url: /ar/androidjava/presentation-localization/
keywords:
- "تغيير اللغة"
- "تدقيق إملائي"
- "كبح التدقيق الإملائي"
- "لغة التدقيق"
- "معرف اللغة"
- "نص متعدد اللغات"
- "PowerPoint"
- "العرض التقديمي"
- "Android"
- "Java"
- "Aspose.Slides"
description: "تعيين لغات التدقيق لنصوص عروض PowerPoint وOpenDocument على Android باستخدام Aspose.Slides for Android via Java، بما في ذلك القيم الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

يسمح Aspose.Slides for Android عبر Java بتكوين بيانات التعريف الخاصة بالتدقيق اللغوي لأجزاء النص الفردية. استخدم [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) لتحديد لغة التدقيق، واستخدم [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) للسماح أو كبح فحص الإملاء، واستخدم [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) للتحكم في حالة "عدم التدقيق" الأوسع. نظرًا لأن هذه الإعدادات تُطبق على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على عدة لغات وقواعد تدقيق مختلفة.

يشرح هذا المقال كيفية تعيين لغة لنص محدد، وتعيين اللغة الافتراضية للنص الجديد باستخدام [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-)، وبناء فقرات متعددة اللغات، والاختيار بين `SpellCheck` و `ProofDisabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). تُخزن هذه الخصائص بيانات التعريف الخاصة بتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تُجري تدقيق إملائي قائم على القاموس، ولا تُعيد الكلمات التي بها أخطاء إملائية.

## **تعيين لغة التدقيق للنص**

قم بإنشاء أو تحميل [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/)، ثم احصل على الجزء النصي المطلوب عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getPortionFormat--)، وعين معرف لغته. المثال التالي ينشئ شكلًا، ويضبط اللغة البريطانية الإنجليزية كلغة تدقيق، ويحفظ النتيجة باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) لتحديد لغة التدقيق التي يضيفها Aspose.Slides إلى النص المُنشأ حديثًا. يكون هذا الإعداد مفيدًا عندما يستخدم معظم أو كل النص الجديد في العرض التقديمي نفس اللغة. ولا يغيّر بيانات التعريف اللغوية للنص الذي لديه لغة صريحة مُحددة مسبقًا.

المثال التالي ينشئ عرضًا تقديميًا يكون فيه النص الجديد وفقًا لقواعد التدقيق الألمانية:

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

يحتوي [IParagraph](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iparagraph/) على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/portion/) منفصل لكل لغة واضبط `LanguageId` الخاص به بشكل مستقل.

هذا المثال يُنشئ فقرة واحدة تحتوي على أجزاء إنجليزية وفرنسية:

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

## **تمكين أو كبح تدقيق الإملاء للأجزاء الفردية**

تورّث [IPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportionformat/) خصائص النص العامة المعرفة في [IBasePortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/). احصل على تنسيق الجزء عبر [IPortion.getPortionFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iportion/#getPortionFormat--) واستخدم [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) للتحكم فيما إذا كان تطبيق العرض التقديمي قد يتحقق من الإملاء لهذا الجزء. القيمة الافتراضية هي `false`: `true` يسمح بتدقيق الإملاء، بينما `false` يكبحه.

ينطبق الإعداد على أجزاء النص الفردية. وبالتالي يمكن لأجزاء مختلفة في نفس الفقرة استخدام قيم مختلفة. يُستخدم كل من [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) و `setSpellCheck` لأغراض تكاملية: يحدد `setLanguageId` لغة التدقيق، بينما يحدد `setSpellCheck` ما إذا كان يُسمح بفحص الإملاء للجزء.

كما يتحكم [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) في التدقيق، لكنه يمثل حالة "عدم التدقيق" الأوسع كقيمة [NullableBool](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/nullablebool/). استخدم `setSpellCheck` عندما تحتاج إلى مفتاح منطقي مباشر لتدقيق الإملاء فقط. استخدم `setProofDisabled` عندما تريد الحفاظ على بيانات التعريف الخاصة بـ "عدم التدقيق" للعرض أو التحكم فيها صراحةً، بما في ذلك حالتها `NotDefined`. إذا قمت بتعيين الخاصيتين، احرص على أن تكون قيمتهما متسقة؛ لا تدمج `setSpellCheck(true)` مع `setProofDisabled(NullableBool.True)`.

تُستخدم هذه الخصائص لتكوين بيانات التعريف الخاصة بالتدقيق التي تستفيد منها PowerPoint وتطبيقات العروض التقديمية الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لإجراء تدقيق إملائي قائم على القاموس أو لإرجاع قائمة بالكلمات الخاطئة.

المثال الكامل التالي ينشئ عرضًا تقديميًا إدخاليًا، يحملّه، يعيّن إعدادات تدقيق إملائي ولغات تدقيق مختلفة لجزئين في نفس الفقرة، يحفظ النتيجة، يعيد فتحه، ويتحقق من القيم المخزنة:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. اختلاف `SpellCheck` وحده لا يكفي لإبقاء هذه الأجزاء منفصلة؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة `SpellCheck` للجزء الأول. إذا احتاجت الأجزاء إلى إعدادات تدقيق إملائي مختلفة، استدعِ `joinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو افحص حدود الجزء الناتج وأعد تطبيق الإعدادات لاحقًا. تبقى الأجزاء التي لها قيم `LanguageId` مختلفة منفصلة لأن تنسيق لغة التدقيق يختلف بينها.

## **الأسئلة المتداولة**

**هل يُترجم معرف اللغة النص؟**

لا. يخزن [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) بيانات التعريف الخاصة بالتدقيق الإملائي والنحوي؛ ولا يغيّر محتوى النص. ترجم النص منفصلًا، ثم اضبط معرف اللغة المناسب لكل جزء من الأجزاء المترجمة.

**هل تتحكم لغة التدقيق في الخطوط أو تقطيع الكلمات أو تغليف السطور؟**

لا. يُستخدم معرف اللغة للتدقيق فقط. يعتمد عرض النص وتنسيقه أساسًا على [الخطوط](/slides/ar/androidjava/powerpoint-fonts/) المتاحة، نظام الكتابة، وإعدادات إطار النص. لضمان عرض موثوق، زوّد الخطوط المطلوبة، واضبط [استبدال الخطوط](/slides/ar/androidjava/font-substitution/)، أو [ضمّن الخطوط](/slides/ar/androidjava/embedded-font/) في العرض التقديمي.

**هل يمكن لفقرة واحدة أن تستخدم عدة لغات تدقيق؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل ينبغي أن أستخدم `setDefaultTextLanguage` أم `setLanguageId`؟**

استخدم [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) عندما تريد قيمة افتراضية للنص المُنشأ حديثًا. استخدم [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) عندما يحتاج جزء معين إلى لغة تدقيق صريحة أو عندما تحتوي الفقرة على لغات متعددة.