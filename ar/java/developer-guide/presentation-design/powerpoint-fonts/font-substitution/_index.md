---
title: "تهيئة استبدال الخطوط في العروض التقديمية باستخدام Java"
linktitle: "استبدال الخطوط"
type: docs
weight: 70
url: /ar/java/font-substitution/
keywords:
- "خط"
- "خط بديل"
- "استبدال الخط"
- "استبدال الخط"
- "استبدال الخط"
- "قاعدة استبدال"
- "قاعدة استبدال"
- PowerPoint
- OpenDocument
- "عرض تقديمي"
- Java
- Aspose.Slides
description: "تهيئة قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides للـ Java عند عرض أو تحويل عروض PowerPoint و OpenDocument التقديمية."
---
## **نظرة عامة**

يسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من الخط الذي لا يمكن الوصول إليه عند عرض أو تحويل عرض تقديمي. يؤثر الاستبدال على الناتج المعروض؛ لكنه لا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تعريف الخط الذي يتم استخدامه عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق الناتج عبر بيئات مختلفة تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والبديل.

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

استخدم نسخة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) المتعددة المعاملات مع معامل `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون ذلك مفيدًا عند عرض أو تصدير جزء من عرض تقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط صغرى للخادم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على مؤشرات شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم المستدعي [Presentation.getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) فهرسة تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة كـ `presentation.getSlides().get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتفادي أخطاء الإزاحة بمقدار واحد.

استدعِ النسخة عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getFontsManager--) . تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والبديل. تعكس النتيجة بيئة الخط الحالية، وقواعد التحويل المُعينة، و[الخطوط المحمّلة خارجيًا](/slides/ar/java/custom-font/). تُطبق قواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsubstrulecollection/) عند عرض العرض التقديمي، لكن النتيجة لا تُظهرها؛ تحقق من الخطوط في ملف الناتج بدلاً من ذلك.

قد يتطلب نفس الاستبدال أكثر من شريحة محددة. قم بإزالة التكرارات من النتائج عند إنشاء جرد للخطوط أو تقرير ما قبل الطيران. المثال التالي يُبلغ عن كل استبدال مُرجع ثم ينشئ قائمة مرتبة للتطابقات الفريدة للخطوط:

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

توفر الواجهة [IFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/) كلا النسختين. اختر واحدة وفقًا لنطاق عملية العرض:

| النسخة | متى تستخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) مع عدم وجود معامِلات | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع `int[] slides` | تحتاج إلى استبدالات لنطاق محدد، أو فحص تدريجي، أو تصدير جزئي. |

## **ضبط قواعد استبدال الخطوط**

لتحديد الخط الذي يجب على Aspose.Slides استخدامه عندما يكون الخط الأصلي غير متوفر:

1. حمّل العرض التقديمي.
2. أنشئ تعريفات الخط للمصدر والخط البديل.
3. أنشئ [FontSubstRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstcondition/).
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstrulecollection/).
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. اعرض أو حول العرض التقديمي.

المثال التالي بلغة Java يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

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
لإجراء تغيير غير مشروط للخطوط المستخدمة عبر العرض التقديمي بأكمله، راجع [Font Replacement](/slides/ar/java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط المعادلات الرياضية**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل مع النص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد وفق قاعدة.

معادلات Office Math لديها متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد لا يزال العرض يُشير إلى أن **Cambria Math** مطلوب.

للعرض أو تحويل مثل هذا العرض التقديمي، احرص على إتاحة **Cambria Math** لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/java/custom-font/).

ينطبق هذا القيد على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على النص العادي في العرض التقديمي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط (Font Replacement) واستبدال الخط (Font Substitution)؟**  
`[Font replacement](/slides/ar/java/font-replacement/)` يغيّر الخط عن قصد إلى خط آخر عبر كامل العرض التقديمي. بينما يختار استبدال الخط خطًا للإخراج المعروض عندما تتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**  
تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط الأصلي.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**  
يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. النتيجة تعتمد على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/java/custom-font/) لتتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل تقوم Aspose بتوزيع الخطوط مع المكتبة؟**  
لا. أنت مسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخطوط بحسب نظام التشغيل، لذا قد يتطلب خط متوفر على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخط متسقًا في عمليات التحويل الجماعية؟**  
استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/java/custom-font/)، و[ضمّن الخطوط](/slides/ar/java/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) قبل التصدير لتحديد الاستبدالات غير المتوقعة.