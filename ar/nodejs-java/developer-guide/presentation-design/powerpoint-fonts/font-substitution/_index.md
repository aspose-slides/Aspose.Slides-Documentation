---
title: تهيئة استبدال الخط في العروض التقديمية باستخدام جافاسكريبت
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/nodejs-java/font-substitution/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تهيئة قواعد استبدال الخط وفحص الخطوط المستبدلة في Aspose.Slides لـ Node.js عبر Java أثناء عرض أو تحويل عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

استبدال الخط يسمح لـ Aspose.Slides باستخدام خط متاح بدلًا من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على الناتج المعروض؛ لكنه لا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي يُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك على الحفاظ على اتساق الناتج عبر بيئات تحتوي على خطوط مثبتة مختلفة.

إذا كان الخط متاحًا لكن لا يحتوي على قالب غامق مخصص، انظر [معالجة الخطوط بدون قالب غامق مخصص](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح ذلك القسم كيفية تحويل النص المتأثر إلى نقط أثناء تصدير PDF والنتائج على اختيار النص والبحث والتكبير.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُرجع الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

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

استخدم نسخة [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) التي تستقبل مصفوفة من فهارس الشرائح لتفحص فقط الاستبدالات المطلوبة لعرض شرائح معينة. يكون ذلك مفيدًا عند عرض أو تصدير جزء من عرض تقديمي، أو فحص عرض كبير تدريجيًا، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط قليلة للملقّم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

تتوقع النسخة معطى من نوع Java primitive `int[]`. أنشئه باستخدام `java.newArray("int", [...])`; مصفوفة JavaScript عادية تُحوَّل إلى `Integer[]` ولا تطابق هذه النسخة.

تحتوي المصفوفة على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم محدد مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) فهارس تبدأ من الصفر، لذا تُستَدعى نفس الشريحة بـ `presentation.getSlides().get_Item(0)`. يجب مراعاة هذا الفرق عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعِ النسخة عبر [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد النسخ الاحتياطي المُكوَّنة، وقواعد الاستبدال المخزنة في [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/nodejs-java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة محددة. احذف التكرارات عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يورد كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر الفئة [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) كلا النسختين. اختر واحدة حسب نطاق عملية العرض:

| الطريقة | متى تُستَخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | تحتاج استبدالات لكامل العرض التقديمي. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) with a Java `int[]` of slide indexes | تحتاج استبدالات لنطاق محدد أو فحص تدريجي أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب على Aspose.Slides استخدامه عندما يكون الخط المصدر غير متوفر:
1. حمّل العرض التقديمي.
2. أنشئ تعريفات الخط للخط المصدر والبديل.
3. أنشئ كائن [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة JavaScript يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متوفرًا لـ Aspose.Slides.

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
لإجراء تغيير غير مشروط على الخطوط المستخدمة في جميع أجزاء العرض التقديمي، انظر [استبدال الخطوط](/slides/ar/nodejs-java/font-replacement/).
{{% /alert %}}

## **قيود خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد بواسطة القاعدة.

للمعادلات في Office Math متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بدقة لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد لا يزال العرض يُظهر أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبِّته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/nodejs-java/custom-font/).

يطبق هذا القيد على تخطيط المعادلات. ما زالت قواعد الاستبدال المذكورة أعلاه تنطبق على النص العادي في العرض.

## **الأسئلة المتكررة**

**ما هو الفرق بين استبدال الخط واستبدال الخط (font substitution)؟**

[استبدال الخط](/slides/ar/nodejs-java/font-replacement/) يغيّر عمداً خطًا بآخر في جميع أنحاء العرض التقديمي. استبدال الخط يختار خطًا للناتج المعروض عندما تتحقق الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُستَخدم قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/nodejs-java/font-selection-sequence/) أثناء العرض والتحويل. عند استخدام `WhenInaccessible`، تُستَخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/nodejs-java/custom-font/) بحيث يستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose خطوطًا مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والالتزام بتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط بحسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخط ثابتًا في التحويلات الجماعية؟**

استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/nodejs-java/custom-font/)، و[دمج الخطوط](/slides/ar/nodejs-java/embedded-font/) عندما تسمح الرخصة. يمكنك أيضًا استدعاء [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.