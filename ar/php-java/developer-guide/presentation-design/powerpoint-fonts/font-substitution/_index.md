---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام PHP
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/php-java/font-substitution/
keywords:
- خط
- خط بديل
- استبدال الخط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides للـ PHP عبر Java عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يتيح استبدال الخطوط ل Aspose.Slides استخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على الإخراج المعروض؛ لكنه لا يغير الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق الإخراج عبر بيئات تختلف في الخطوط المثبتة.

إذا كان الخط متوفرًا لكن لا يملك قالبًا عريضًا مخصصًا، راجع [معالجة الخطوط بدون قالب عريض مخصص](/slides/ar/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يوضح ذلك القسم كيفية تحويل النص المتأثر إلى صورة أثناء تصدير PDF والعواقب على اختيار النص والبحث والتكبير.

## **الحصول على استبدالات الخط**

استخدم طريقة [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والخط المستبدل.

المثال التالي بلغة PHP يعرض جميع استبدالات الخطوط لعرض تقديمي:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **الحصول على استبدالات الخط للشرائح المحددة**

استخدم نسخة طريقة [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) التي تستقبل معامل `int[] slides` لفحص الاستبدالات المطلوبة فقط لتصوير شرائح معينة. يكون هذا مفيدًا عندما تقوم بعرض أو تصدير جزء من عرض تقديمي، أو فحص عرض تقديمي كبير على دفعات، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط مصغرة لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

يحتوي مصفوفة `slides` على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم المستدعي [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) فهارس تبدأ من الصفر، لذا يمكن الوصول إلى نفس الشريحة كـ `$presentation->getSlides()->get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الفهرسة.

استدعِ النسخة عبر طريقة [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والخط المستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد الاحتياط المكوّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط المحملة خارجيًا](/slides/ar/php-java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة محددة. قم بإزالة التكرارات من النتائج عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. يعرض المثال التالي كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة لتعيينات الخطوط الفريدة:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

توفر فئة [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) كلا النسختين. اختر واحدة وفقًا لنطاق عملية العرض:

| النسخة | متى تستخدمه |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) مع عدم وجود معاملات | تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) مع `int[] slides` | تحتاج إلى استبدالات لنطاق محدد، أو فحص تدريجي، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متوفر:

1. حمّل العرض التقديمي.  
2. أنشئ تعريفات للخط المصدر والبديل.  
3. أنشئ [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) باستخدام الشرط [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة باستخدام طريقة [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. اعرض أو حوّل العرض التقديمي.

المثال التالي بلغة PHP يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متوفرًا لـ Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة عبر كامل العرض التقديمي، راجع [استبدال الخط](/slides/ar/php-java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوف هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يتمكن Aspose.Slides من استبدال خط غير متاح بالخط المتاح المحدد بواسطة قاعدة.

تحتاج معادلات Office Math إلى شرط إضافي. إذا استخدمت معادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد لا يزال العرض يشير إلى أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض التقديمي، احرص على توفر **Cambria Math** لـ Aspose.Slides. ثبّته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/php-java/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على نص العرض التقديمي العادي.

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**  
يقوم [استبدال الخط](/slides/ar/php-java/font-replacement/) بتغيير مقصود لخط واحد إلى آخر عبر كامل العرض التقديمي. أما استبدال الخطوف فيختار خطًا للإخراج المعروض عندما يتحقق الشرط المكوّن، مثل عدم توفر الخط الأصلي.

**متى يتم تطبيق قواعد الاستبدال؟**  
تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/php-java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يتمكن Aspose.Slides من الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مكوّنة؟**  
يقوم Aspose.Slides باختيار أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التنفيذ.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/php-java/custom-font/) لكي يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخطوط حسب نظام التشغيل، لذا قد يتطلب خط متوفر على جهاز واحد استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخط متسقًا في عمليات التحويل الجماعية؟**  
استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/php-java/custom-font/)، و[ضمّن الخطوط](/slides/ar/php-java/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.