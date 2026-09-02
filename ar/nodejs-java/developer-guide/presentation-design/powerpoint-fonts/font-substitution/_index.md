---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام JavaScript
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/nodejs-java/font-substitution/
keywords:
- الخط
- استبدال الخط
- استبدال الخطوط
- استبدال الخط
- استبدال الخطوط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لـ Node.js عبر Java عند عرض أو تحويل عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

يسمح استبدال الخطوط في Aspose.Slides باستخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على الناتج المعروض؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص الاستبدالات التي ستجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على تناسق الناتج عبر بيئات مختلفة تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة JavaScript يسرد جميع استبدالات الخطوط لعرض تقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم النسخة المت overload من طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) مع مصفوفة من فهارس الشرائح لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون ذلك مفيدًا عند عرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير بصورة تدريجية، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط قليلة الحجم لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

تتوقع النسخة المت overload مصفوفة بدائية Java من نوع `int[]`. أنشئها باستخدام `java.newArray("int", [...])`؛ فإن مصفوفة JavaScript عادية تُحوَّل إلى `Integer[]` ولا تتطابق مع هذه النسخة.

تحتوي المصفوفة على فهارس شرائح تبدأ من واحد: `1` يحدد الشريحة الأولى. وعلى العكس، يستخدم موصل مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) فهارس بدءًا من الصفر، لذا يتم الوصول إلى نفس الشريحة كـ `presentation.getSlides().get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الإزاحة بمقدار واحد.

استدعِ النسخة المت overload عبر [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getfontsmanager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد fallback المكوَّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط التي تم تحميلها خارجيًا](/slides/ar/nodejs-java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة محددة. قم بإزالة التكرار من النتائج عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يُبلغ عن كل استبدال مُرجع ثم ينشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

توفر فئة [FontsManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/) كلا النسختين المت overload. اختر واحدة حسب نطاق عملية العرض.

| Overload | متى تُستخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | تحتاج استبدالات لكامل العرض التقديمي. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | تحتاج استبدالات لنطاق مختار، فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط الأصلي غير متاح:

1. حمّل العرض التقديمي.  
2. أنشئ تعريفات الخط للخط الأصلي والبديل.  
3. أنشئ كائن [FontSubstRule](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. اعرض أو حوّل العرض التقديمي.

المثال التالي بلغة JavaScript يستبدل الخط `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متاح، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة عبر العرض التقديمي بأكمله، راجع [Font Replacement](/slides/ar/nodejs-java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يتمكن Aspose.Slides من استبدال خط غير متاح بالخط المتاح المحدد بالقاعدة.

معادلات Office Math لها متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد لا يزال العرض يوضح أن **Cambria Math** مطلوب.

للعرض أو التحويل لهذا العرض التقديمي، تأكد من إتاحة **Cambria Math** لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [external font](/slides/ar/nodejs-java/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. القواعد الاستبدالية الموصوفة أعلاه لا تزال تنطبق على نص العرض التقديمي العادي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[Font replacement](/slides/ar/nodejs-java/font-replacement/) يغيّر خطًا إلى آخر عمدًا عبر كامل العرض التقديمي. استبدال الخطوط يختار خطًا للناتج المعروض عندما يتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/nodejs-java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible` تُستخدم القاعدة فقط عندما لا يتمكن Aspose.Slides من الوصول إلى الخط الأصلي.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**

يقوم Aspose.Slides باختيار أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتاحة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [load external fonts](/slides/ar/nodejs-java/custom-font/) حتى يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل قد تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخطوط حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخط متسقًا في عمليات التحويل الجماعي؟**

استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [load required external fonts](/slides/ar/nodejs-java/custom-font/)، و[embed fonts](/slides/ar/nodejs-java/embedded-font/) عندما تسمح الترخيص. يمكنك أيضًا استدعاء [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.