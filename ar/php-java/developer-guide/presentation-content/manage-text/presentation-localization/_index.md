---
title: أتمتة تعريب العروض التقديمية في PHP
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/php-java/presentation-localization/
keywords:
- تغيير اللغة
- تدقيق إملائي
- كتم تدقيق الإملائي
- لغة التدقيق
- معرف اللغة
- نص متعدد اللغات
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعيين لغات التدقيق لنصوص عروض PowerPoint وOpenDocument في PHP باستخدام Aspose.Slides، بما في ذلك الإعدادات الافتراضية والفقرات متعددة اللغات."
---
## **نظرة عامة**

تتيح لك Aspose.Slides للـ PHP عبر Java تكوين بيانات التعريف الخاصة بالتدقيق اللغوي لأجزاء النص الفردية. استخدم [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId) لتحديد لغة التدقيق، و[BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setSpellCheck) للسماح أو كتم فحص الإملاء، و[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setProofDisabled) للتحكم في الحالة العامة لعدم التدقيق. نظرًا لأن هذه الإعدادات تُطبق على مستوى الجزء، يمكن لفقرة واحدة أن تحتوي على لغات متعددة وقواعد تدقيق مختلفة.

تشرح هذه المقالة كيفية تعيين لغة لنص محدد، وتحديد اللغة الافتراضية للنص الجديد باستخدام [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage)، وإنشاء فقرات متعددة اللغات، والاختيار بين `SpellCheck` و`ProofDisabled`، والحفاظ على الإعدادات المقصودة عند استخدام [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). تُخزن هذه الخصائص بيانات التعريف لتطبيقات العروض التقديمية؛ فهي لا تترجم النص، ولا تجري تدقيق إملائي قائم على القاموس، ولا تُعيد الكلمات التي بها أخطاء إملائية.

## **تعيين لغة التدقيق للنص**

أنشئ أو حمّل [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/)، وادخل إلى جزء النص المطلوب عبر [Portion::getPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getPortionFormat)، ثم عيّن معرف اللغة الخاص به. المثال التالي ينشئ شكلاً، يعيّن اللغة الإنجليزية البريطانية كلغة تدقيق، ويحفظ النتيجة باستخدام [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين اللغة الافتراضية للنص الجديد**

استخدم [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) لتحديد لغة التدقيق التي تُعيّنها Aspose.Slides للنص المُنشأ حديثًا. يفيد هذا الإعداد عندما يستخدم معظم أو كل النص الجديد في العرض التقديمي نفس اللغة. لا يُغيّر هذا الإعداد بيانات التعريف اللغوية للنص الذي يمتلك بالفعل لغة محددة صراحةً.

المثال التالي ينشئ عرضًا تقديميًا يكون فيه النص الجديد مُطبقًا قواعد التدقيق الألماني:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **استخدام لغات متعددة في فقرة واحدة**

[Paragraph](https://reference.aspose.com/slides/ar/php-java/aspose.slides/paragraph/) يحتوي على مجموعة من أجزاء النص. أنشئ [Portion](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/) منفصلة لكل لغة، وعَيّن خاصية `LanguageId` لكل منها بشكل مستقل.

هذا المثال يُنشئ فقرة واحدة تحتوي على أجزاء بالإنجليزية والفرنسية:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تمكين أو كتم فحص الإملاء لأجزاء معينة**

[PortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portionformat/) يرث الخصائص النصية العامة التي يعرفها [BasePortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/). ادخل إلى تنسيق الجزء عبر [Portion::getPortionFormat](https://reference.aspose.com/slides/ar/php-java/aspose.slides/portion/#getPortionFormat) واستخدم [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setSpellCheck) للتحكم فيما إذا كان تطبيق العرض قد يتحقق من الإملاء لهذا الجزء. القيمة الافتراضية هي `false`: `true` يسمح بفحص الإملاء، بينما `false` يكتمه.

ينطبق الإعداد على أجزاء النص الفردية. وبالتالي يمكن لأجزاء مختلفة في نفس الفقرة أن تستخدم قيمًا مختلفة. كل من [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId) و`setSpellCheck` لهما أغراض مكملة: `setLanguageId` يحدد لغة التدقيق، بينما `setSpellCheck` يحدد ما إذا كان يُسمح بفحص الإملاء للجزء.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setProofDisabled) يتحكم أيضًا في التدقيق، لكنه يمثل حالة "عدم التدقيق" العامة كـ [NullableBool](https://reference.aspose.com/slides/ar/php-java/aspose.slides/nullablebool/). استخدم `setSpellCheck` عندما تحتاج إلى مفتاح منطقي مباشر لتفعيل أو إيقاف فحص الإملاء. واستخدم `setProofDisabled` عندما تحتاج إلى الحفاظ على أو التحكم صراحةً في البيانات الوصفية لعدم التدقيق في العرض، بما في ذلك حالتـه `NotDefined`. إذا عطيت القيمتين، حافظ على التناسق بينهما؛ لا تجمع بين `setSpellCheck(true)` و`setProofDisabled(NullableBool::True)`.

هذه الخصائص تُكوّن بيانات التعريف الخاصة بالتدقيق المستخدمة من قبل PowerPoint وتطبيقات العروض التقديمية الأخرى. لا يستخدم Aspose.Slides هذه الخصائص لتشغيل فحص إملائي قائم على القاموس أو لإرجاع قائمة بالكلمات الخاطئة.

المثال الكامل التالي ينشئ عرض تقديميًا مدخلًا، يُحمّله، يعيّن إعدادات فحص إملائي ولغات تدقيق مختلفة لجزئين في نفس الفقرة، يحفظ النتيجة، يُعيد فتحها، ويتحقق من القيم المخزّنة:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) يجمع الأجزاء المتجاورة التي لها نفس التنسيق. الاختلاف في `SpellCheck` بمفرده لا يبقي هذه الأجزاء منفصلة؛ بعد دمجها، يحتفظ الجزء الناتج بقيمة `SpellCheck` للجزء الأول. إذا احتاجت الأجزاء إلى إعدادات فحص إملائي مختلفة، استدعِ `joinPortionsWithSameFormatting` قبل تعيين تلك الإعدادات، أو افحص حدود الأجزاء الناتجة وأعد تطبيق الإعدادات لاحقًا. تظل الأجزاء التي لها قيم `LanguageId` مختلفة منفصلة لأن تنسيق لغة التدقيق يختلف.

## **الأسئلة المتكررة**

**هل يترجم معرف اللغة النص؟**

لا. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId) يخزّن بيانات التعريف الخاصة بالتدقيق للإملاء والقواعد؛ ولا يُغيّر محتوى النص. ترجم النص بصورة منفصلة، ثم عيّن معرف اللغة المناسب لكل جزء مُترجم.

**هل تتحكم لغة التدقيق في الخطوط أو الفاصل أو لف النص؟**

لا. معرف اللغة مخصّص للتدقيق. يعتمد عرض النص وتنسيقه أساسًا على [الخطوط](/slides/ar/php-java/powerpoint-fonts/) المتوفرة، ونظام الكتابة، وإعدادات إطار النص. للحصول على عرض موثوق، قدّم الخطوط المطلوبة، واضبط [استبدال الخطوط](/slides/ar/php-java/font-substitution/)، أو [دمج الخطوط](/slides/ar/php-java/embedded-font/) في العرض.

**هل يمكن لفقرة واحدة استخدام عدة لغات تدقيق؟**

نعم. عيّن كل لغة إلى جزء منفصل، كما هو موضح في مثال الفقرة متعددة اللغات.

**هل يجب استخدام `setDefaultTextLanguage` أم `setLanguageId`؟**

استخدم [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) عندما تريد تحديد لغة افتراضية للنص المُنشأ حديثًا. واستخدم [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseportionformat/#setLanguageId) عندما تحتاج جزءًا محددًا إلى لغة تدقيق صريحة أو عندما تحتوي الفقرة على لغات متعددة.