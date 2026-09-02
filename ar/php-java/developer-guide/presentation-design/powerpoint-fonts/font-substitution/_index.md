---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام PHP
linktitle: استبدال الخطوط
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
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لـ PHP عبر Java عند عرض أو تحويل عروض PowerPoint و OpenDocument."
---
## **نظرة عامة**

استبدال الخطوط يسمح لـ Aspose.Slides باستخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغير الخط المعين لمحتوى العرض التقديمي.

يمكنك تعريف الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق المخرجات عبر بيئات مختلفة تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getsubstitutions/) لتحديد الخطوط التي ستُستبدل عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة PHP يسرد جميع استبدالات الخطوط لعرض تقديمي:

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

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم التحميل الزائد للطريقة [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getsubstitutions/) مع معلمة `int[] slides` لتفحص فقط الاستبدالات المطلوبة لعرض شرائح معينة. يكون ذلك مفيدًا عند عرض أو تصدير جزء من عرض تقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط قليلة الحجم لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير المتعلقة.

مصفوفة `slides` تحتوي على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم المستدعي [Presentation::getSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getSlides) فهرسة تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة عبر `$presentation->getSlides()->get_Item(0)`. احتفظ بهذا الاختلاف في الاعتبار عند بناء المصفوفة لتجنب أخطاء الفهرسة.

استدعِ التحميل الزائد عبر طريقة [Presentation::getFontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getFontsManager). تُعيد الطريقة فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد الاحتياطي المُكوَّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط المحملة خارجيًا](/slides/ar/php-java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة محددة. قم بإزالة التكرارات من النتائج عند إنشاء جرد للخطوط أو تقرير فحص مسبق. المثال التالي يُظهر كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة للترجمات الفريدة للخطوط:

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

توفر فئة [FontsManager](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/) كلا التحميلين الزائدين. اختر أحدهما وفقًا لنطاق عملية العرض:

| التحميل الزائد | متى يُستخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getsubstitutions/) بدون معلمات | تحتاج استبدالات للعرض التقديمي بأكمله. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getsubstitutions/) مع `int[] slides` | تحتاج استبدالات لنطاق محدد، فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخطوط**

لتحديد الخط الذي يجب على Aspose.Slides استخدامه عندما يكون الخط المصدر غير متوفر:

1. حمِّل العرض التقديمي.
2. أنشئ تعريفات الخط للخط المصدر والبديل.
3. أنشئ [FontSubstRule](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstcondition/).
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsubstrulecollection/).
5. عيّن المجموعة باستخدام طريقة [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. اعرض أو حوِّل العرض التقديمي.

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

{{% alert color="info" title="ملاحظة" %}}
لتغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [Font Replacement](/slides/ar/php-java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل للنص العادي عندما يمكن لـ Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد بواسطة قاعدة.

للمعادلات في Office Math متطلبات إضافية. إذا استخدمت المعادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**, استبدال **Cambria Math** لهذا الغرض، وقد يظل العرض يُشير إلى أن **Cambria Math** مطلوب.

للعرض أو تحويل مثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله ك[خط خارجي](/slides/ar/php-java/custom-font/).

هذا القيد يقتصر على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على نص العرض التقديمي العادي.

## **الأسئلة المتداولة**

**ما الفرق بين استبدال الخط واستبداله؟**  
[Font replacement](/slides/ar/php-java/font-replacement/) يغيّر خطًا إلى آخر عبر العرض التقديمي بأكمله بشكل متعمد. يستبدال الخط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**  
تشارك القواعد في [font selection sequence](/slides/ar/php-java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**  
يقوم Aspose.Slides باختيار أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة وقت التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [load external fonts](/slides/ar/php-java/custom-font/) حتى يستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخط موحدًا في التحويلات الجماعية؟**  
استخدم نفس ملفات الخطوط والإصدارات على كل جهاز أو حاوية، [load required external fonts](/slides/ar/php-java/custom-font/)، و[embed fonts](/slides/ar/php-java/embedded-font/) عندما تسمح الرخصة. يمكنك أيضًا استدعاء [FontsManager::getSubstitutions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/fontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.