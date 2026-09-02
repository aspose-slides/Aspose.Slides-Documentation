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
description: تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لنظام Android عبر Java عند تصيير أو تحويل العروض التقديمية.
---
## **نظرة عامة**

يسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند تصيير أو تحويل عرض تقديمي. يؤثر الاستبدال على الإخراج المصور؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء التصيير. يساعد هذا في الحفاظ على تساوق الإخراج عبر أجهزة Android والبيئات التي تحتوي على خطوط مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) لتحديد الخطوط التي سيتم استبدالها عند تصيير العرض. تُرجع الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

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

استخدم نسخة طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) التي تستقبل وسيط `int[] slides` لفحص الاستبدالات المطلوبة فقط لتصيير شرائح معينة. يُفيد ذلك عندما تقوم بتصيير أو تصدير جزء من العرض، أو فحص عرض تقديمي كبير تدريجيًا، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط قليلة لتطبيق Android، أو تشخيص اختلافات التصيير دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم موصل مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) فهرسة تبدأ من الصفر، لذا تُستدعى نفس الشريحة كـ `presentation.getSlides().get_Item(0)`. احرص على مراعاة هذا الاختلاف عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعِ النسخة عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getFontsManager--) . تُرجع فقط الاستبدالات التي تم تحديدها أثناء تصيير الشرائح المختارة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد السقوط المكوَّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحملة خارجياً](/slides/ar/androidjava/custom-font/).

قد تحتاج نفس الاستبدالية إلى أكثر من شريحة مختارة. قم بإزالة التكرارات عند إنشاء جرد للخطوط أو تقرير ما قبل الطيران. المثال التالي يُبلغ عن كل استبدال مُرجع ثم يُنشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر الواجهة [IFontsManager](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/) كلا النسختين. اختر واحدة حسب نطاق عملية التصيير:

| الإصدار | متى تستخدمه |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون وسائط | عندما تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع `int[] slides` | عندما تحتاج إلى استبدالات لنطاق محدد، أو فحص تدريجي، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متاح:

1. حمّل العرض التقديمي.
2. أنشئ تعريفات الخط للخط المصدر والبديل.
3. أنشئ [FontSubstRule](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstcondition/).
4. أضف القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. قم بتصيير أو تحويل العرض التقديمي.

المثال التالي بلغة Java يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متاح، ثم يصيّر الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

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

{{% alert color="info" title="ملاحظة" %}}
لإجراء تغيير غير مشروط على الخطوط المستخدمة في جميع أنحاء عرض تقديمي، راجع [Font Replacement](/slides/ar/androidjava/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء التصيير والتحويل. تعمل للنص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد في القاعدة.

معادلات Office Math لديها مطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وتصيير تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد يستمر التصيير في الإبلاغ بأن **Cambria Math** مطلوب.

لتصيير أو تحويل مثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. حمّله كـ [خط خارجي](/slides/ar/androidjava/custom-font/) حتى يتمكن التطبيق من استخدامه أثناء التصيير والتحويل.

تنطبق هذه القيود على تخطيط المعادلات فقط. لا تزال قواعد الاستبدال المذكورة أعلاه سارية للنص العادي في العرض.

## **FAQ**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**  
[Font replacement](/slides/ar/androidjava/font-replacement/) يغيّر خطًا واحدًا بآخر في جميع أنحاء العرض بنيةً متعمدة. استبدال الخطوط يختار خطًا للإخراج المصور عندما يتحقق الشرط المكوّن، مثل عدم توفر الخط الأصلي.

**متى يتم تطبيق قواعد الاستبدال؟**  
تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/androidjava/font-selection-sequence/) أثناء التصيير والتحويل. مع `WhenInaccessible` تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**  
يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/androidjava/custom-font/) حتى يتمكن Aspose.Slides من استخدامها أثناء التصيير والتحويل.

**هل تقوم Aspose بتوزيع الخطوط مع المكتبة؟**  
لا. تتحمل مسؤولية توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين أجهزة Android؟**  
نعم. قد تختلف الخطوط النظامية المتاحة بين إصدارات Android، والأجهزة، والموردين، لذا قد يحتاج خط متاح في بيئة إلى استبدال في أخرى.

**كيف يمكنني جعل اختيار الخط ثابتًا عبر أجهزة Android؟**  
احزم ملفات الخط المطلوبة مع التطبيق، [حمّلها كخطوط خارجية](/slides/ar/androidjava/custom-font/)، و[ضمّن الخطوط](/slides/ar/androidjava/embedded-font/) عندما تسمح التراخيص. يمكنك أيضًا استدعاء [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) قبل التصدير لتحديد الاستبدالات غير المتوقعة.