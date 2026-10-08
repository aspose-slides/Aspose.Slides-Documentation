---
title: تكوين استبدال الخطوط في العروض التقديمية على Android
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "قم بتكوين قواعد استبدال الخطوط وتفقد الخطوط المستبدلة في Aspose.Slides for Android عبر Java عند عرض أو تحويل العروض التقديمية."
---
## **نظرة عامة**

تسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك على الحفاظ على تناسق المخرجات عبر أجهزة Android والبيئات ذات الخطوط المتاحة المختلفة.

إذا كان الخط متاحًا ولكنه لا يحتوي على نوع عريض مخصص، راجع [معالجة الخطوط بدون خط عريض مخصص](/slides/ar/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح هذا القسم كيفية تحويل النص المتأثر إلى نقطية أثناء تصدير PDF والعواقب على تحديد النص، والبحث، وتغيير الحجم.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُرجع الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة Java يسرد جميع استبدالات الخطوط لعرض تقديمي:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم التحميل الزائد لـ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع وسيط `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. هذا مفيد عند عرض أو تصدير جزء من العرض، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط صغرى لتطبيق Android، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

يحتوي مصفوفة `slides` على فهارس الشرائح بدءًا من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم ما يحصل عليه من [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) فهارس صفرية، لذا يتم الوصول إلى نفس الشريحة عبر `presentation.getSlides().get_Item(0)`. احرص على أخذ هذا الاختلاف في الاعتبار عند بناء المصفوفة لتجنب أخطاء الإزاحة بمقدار واحد.

استدعِ التحميل الزائد عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--) . تُرجع الطريقة الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة فقط. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد fallback المكوَّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/)، و[الخطوط التي تم تحميلها خارجيًا](/slides/ar/androidjava/custom-font/).

يمكن أن يتطلب نفس الاستبدال أكثر من شريحة محددة. احذف التكرارات عند إنشاء جرد للخطوط أو تقرير الفحص المسبق. المثال التالي يُظهر كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة لتعيينات الخطوط الفريدة:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

توفر واجهة [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/) كلا التحميلين الزائدين. اختر أحدهما وفقًا لنطاق عملية العرض:

| التحميل الزائد | استخدمه عندما |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون وسيطات | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع `int[] slides` | تحتاج إلى استبدالات لنطاق مختار، أو فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متاح:

1. حمِّل العرض التقديمي.  
2. أنشئ تعريفات للخط المصدر والبديل.  
3. أنشئ كائنًا من النوع [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
6. اعرض أو حوّل العرض التقديمي.

المثال التالي بلغة Java يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متاح، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [استبدال الخط](/slides/ar/androidjava/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير قابل للوصول بخط متاح محدد بالقاعدة.

المعادلات الرياضية في Office Math لديها متطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى ذلك الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد يستمر العرض في الإبلاغ عن ضرورة وجود **Cambria Math**.

للعرض أو التحويل لمثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. حمّله كـ [خط خارجي](/slides/ar/androidjava/custom-font/) حتى يتمكن التطبيق من استخدامه أثناء العرض والتحويل.

تنطبق هذه القيود على تخطيط المعادلات فقط. لا تزال قواعد الاستبدال الموصوفة أعلاه سارية على النص العادي في العرض التقديمي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[استبدال الخط](/slides/ar/androidjava/font-replacement/) يغيّر خطًا بآخر عبر كامل العرض التقديمي بشكل متعمد. استبدال الخط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**

تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/androidjava/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مكوَّنة؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/androidjava/custom-font/) بحيث يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين أجهزة Android؟**

نعم. قد تختلف الخطوط النظامية المتاحة بين إصدارات Android، والأجهزة، والمصنعين، لذا قد يتطلب خط متاح في بيئة ما استبدالًا في بيئة أخرى.

**كيف يمكن جعل اختيار الخط متسقًا عبر أجهزة Android؟**

احزم ملفات الخط المطلوبة نفسها مع التطبيق، [حمّلها كخطوط خارجية](/slides/ar/androidjava/custom-font/)، و[ضمن الخطوط](/slides/ar/androidjava/embedded-font/) عندما تسمح الرخصة. يمكنك أيضًا استدعاء [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) قبل التصدير لتحديد الاستبدالات غير المتوقعة.