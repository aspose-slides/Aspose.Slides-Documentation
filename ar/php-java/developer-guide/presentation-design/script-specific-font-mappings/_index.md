---
title: إدارة خطوط الثيم المحددة للسكريبت في PHP
linktitle: خطوط الثيم المحددة للسكريبت
type: docs
weight: 15
url: /ar/php-java/script-specific-font-mappings/
keywords:
- خط مخصص للسكريبت
- خريطة خط الثيم
- عرض تقديمي متعدد اللغات
- نظام كتابة
- خط سيريلية
- خط عربي
- خط ياباني
- خط جورجي
- خط ثانا
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "فحص، إضافة، استبدال، وإزالة خرائط الخطوط المحددة للسكريبت في ثيمات PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **نظرة عامة**

يمكن للثيم الخاص بالعرض التقديمي اختيار عائلات خطوط مختلفة لأنظمة كتابة مختلفة. يتيح ذلك للنص متعدد اللغات الذي لا يزال يستخدم خطوط الثيم اتباع مخطط خطوط منسق مع استخدام خطوط مناسبة للسيريلية والعربية واليابانية والجورجية وثانا وغيرها من الخطوط.

يحتوي [FontScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/) للثيم على مجموعة خطوط رئيسية تُستخدم عادةً للعناوين، ومجموعة خطوط فرعية تُستخدم عادةً لنص الجسم. بالإضافة إلى إعدادات الخطوط اللاتينية والآسيوية الشرقية، تُظهر كل من مجموعة [Fonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/) خريطة من وسوم نظام الكتابة إلى أسماء عائلات الخطوط.

تُظهر هذه المقالة كيفية فحص وتعديل تلك الخرائط في ثيم الرئيس للعرض والتحقق من بقاء التغييرات بعد عملية الحفظ وإعادة التحميل.

## **فهم وسوم النصوص**

تستخدم طرق الخط النصي وسوم نصية مكونة من أربعة أحرف وفقًا لمعيار BCP 47 لتحديد أنظمة الكتابة. تشمل القيم الشائعة:

| وسم النص | نظام الكتابة |
|---|---|
| `Cyrl` | السيريلية |
| `Arab` | العربية |
| `Hans` | الصينية المبسطة |
| `Jpan` | اليابانية |
| `Geor` | الجورجية |
| `Thaa` | ثانا |

تنتمي هذه الخرائط إلى مخطط خطوط الثيم، وليس إلى أجزاء النص الفردية. قد يعرف العرض تخطيطات مختلفة للمجموعتين الرئيسية والفرعية، وقد يحذف بعض التخطيطات لبعض النصوص.

## **الوصول إلى خرائط الخط النصي وفحصها**

استخدم [Presentation::getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasterTheme) للوصول إلى ثيم مستوى العرض. توفر الطرق [MasterTheme::getFontScheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/mastertheme/#getFontScheme)، [FontScheme::getMajor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/#getMajor) و[FontScheme::getMinor](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontscheme/#getMinor) إمكانية الوصول إلى مجموعتي [Fonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/) .

استدعِ [Fonts::getScriptFontMap](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#getScriptFontMap) لاسترداد جميع الخرائط من مجموعة معينة. للبحث عن نظام كتابة معين، استدعِ [Fonts::getScriptFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#getScriptFont) مع وسم النص الخاص به. تُعيد `Fonts::getScriptFont` القيمة `null` عندما لا تُعرّف تلك المجموعة الخريطة المطلوبة.

## **تعديل الخرائط والتحقق من استمرارها**

استخدم [Fonts::setScriptFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#setScriptFont) لإنشاء خريطة أو استبدال عائلة الخط الحالية. استخدم [Fonts::removeScriptFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#removeScriptFont) لإزالة خريطة.

المثال التالي الشامل يقرأ جميع الخرائط الرئيسية والفرعية الحالية، يبحث عن الخط الياباني الرئيسي، يغيّر الخط السيريلية الرئيسي، يزيل خريطة ثانا الفرعية، يحفظ العرض، ثم يعيده ليتحقق من كلا التغييرين. لجعل خطوة الإزالة مستقلة عن الثيم الأصلي، ينشئ المثال خريطة ثانا فقط عندما لا تكون معرفة مسبقًا.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

تستخدم عملية التحقق نفس سلوك `null` كبحث عادي: بعد حفظ الإزالة، تُعيد `Fonts::getScriptFont("Thaa")` القيمة `null` للمجموعة الفرعية.

## **تمييز خرائط الثيم عن إعدادات الخطوط الأخرى**

تشارك خرائط الثيم الخاصة بالسكربت في اختيار الخط، لكنها تحل مشكلة مختلفة عن تنسيق النص المباشر، والاستبدال، والاحتياطي:

| الآلية | الغرض | تأثير تغيير خريطة الثيم |
|---|---|---|
| خريطة خط الثيم الخاصة بالسكريبت | تختار خط ثيم رئيسي أو فرعي لنظام كتابة معين. | يمكن للنص الذي لا يزال يستخدم خط الثيم المقابل أن يتحول إلى عائلة الخط الجديدة. |
| الخط المعيّن صراحةً لجزء من النص | يثبت عائلة الخط المطلوبة لهذا الجزء بدلاً من الاعتماد على الثيم. | قد يبقى الجزء دون تغيير لأن تنسيقه المباشر يتجاوز اختيار الثيم. |
| استبدال الخط | يستبدل الخط المطلوب عندما يكون غير متوفر أو عندما يُطبّق قاعدة استبدال. | يحدث بعد طلب الخط؛ لا يُعيد تعريف خريطة سكربت الثيم. |
| الخط الاحتياطي | يوفّر الرموز غير المتوفرة في الخط المحدد، غالبًا لنطاقات يونيكود محددة. | يملأ النقص في الرموز؛ لا يغيّر خريطة الثيم المخزنة. |

لمزيد من المعلومات حول الآليتين الأخيرتين، راجع [Font Substitution](/slides/ar/php-java/font-substitution/) و[Fallback Fonts](/slides/ar/php-java/fallback-font/).

تغيير خريطة في [Presentation::getMasterTheme](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getMasterTheme) يؤثر فقط على المحتوى الذي لا يزال تنسيقه الفعلي يعتمد على ذلك الثيم. يمكن للنص أن يرث تعديل الثيم من رئيس، تخطيط، أو شريحة، أو أن يستخدم خطًا معينًا صراحة. افحص تلك المستويات عندما لا يتطابق الناتج المرئي مع خريطة مستوى العرض.

## **إتاحة الخطوط المخرطة والتحقق من النتيجة**

تخزن خريطة السكربت اسم عائلة الخط؛ لا تقوم بتثبيت أو تحميل ملف الخط المقابل. لضمان العرض والتصدير المتسق، يجب تثبيت كل خط مخرط في البيئة أو توفيره إلى Aspose.Slides من خلال مصدر مخصص مثل [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsloader/#loadExternalFonts) أو [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). راجع [Custom Fonts](/slides/ar/php-java/custom-font/) للاطلاع على خيارات التحميل المتاحة.

يؤكّد التحقق من الخريطة المحفوظة أن تعريف الثيم تم الحفاظ عليه فقط. لا يثبت أن الخط متوفر، أو يحتوي على جميع الرموز المطلوبة، أو ينتج التخطيط المقصود. قدّم نصًا تمثيليًا لكل نظام كتابة مطلوب إلى صورة أو PDF وفحص الناتج. يكتشف ذلك الخطوط المفقودة، وتغطية الرموز غير المكتملة، وسلوك الاحتياطي، وتغيّر التخطيط قبل توزيع العرض. راجع [Convert PowerPoint Presentations](/slides/ar/php-java/convert-powerpoint/) للحصول على أمثلة العرض والتصدير.

## **التعليمات المتكررة**

**ماذا تُعيد `Fonts::getScriptFont` عندما لا تكون هناك خريطة للنص؟**

[Fonts::getScriptFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#getScriptFont) تُعيد `null` عندما لا تكون خريطة السكربت المطلوبة معرفة في تلك المجموعة الرئيسية أو الفرعية.

**هل يضيف `Fonts::setScriptFont` خريطة ثانية عندما يكون السكربت موجودًا بالفعل؟**

لا. [Fonts::setScriptFont](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fonts/#setScriptFont) ينشئ الخريطة عندما تكون مفقودة ويستبدل عائلة الخط المخرطة عندما يكون وسم السكربت موجودًا بالفعل.

**لماذا لم يغيّر تعديل خريطة الثيم بعض النصوص؟**

قد يكون النص قد عُيّن له خط صراحةً، أو يرث ثيمًا مختلفًا عبر تعديل، أو يتأثر بالاستبدال أو الاحتياطي أثناء العرض. تتحكم خريطة السكربت على مستوى العرض فقط في النص الذي لا يزال تنسيقه الفعلي يشير إلى مجموعة خطوط الثيم تلك.

**هل حفظ العرض وإعادة فتحه كافٍ للتحقق من الناتج متعدد اللغات؟**

لا. إعادة الفتح تُتحقق فقط من بقاء بيانات الثيم. يجب أيضًا عرض نص تمثيلي من كل نظام كتابة مطلوب للتأكد من توفر الخطوط المخرطة واحتوائها على الرموز الضرورية.