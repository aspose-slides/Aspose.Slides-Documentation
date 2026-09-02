---
title: تكوين استبدال الخطوط في العروض التقديمية باستخدام Java
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/java/font-substitution/
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
- Java
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides للـ Java عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تسمح استبدال الخطوط (Font substitution) لـ Aspose.Slides باستخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تعريف الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص الاستبدالات التي ستجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق المخرجات عبر بيئات ذات خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

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

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) ذات المعامل `int[] slides` لتفحص الاستبدالات المطلوبة فقط لعرض شرائح محددة. يكون هذا مفيدًا عند عرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط قليلة لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير المرتبطة.

مصفوفة `slides` تحتوي على فهارس شرائح تبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، يستخدم المبدل [Presentation.getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--) فهارس تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة عبر `presentation.getSlides().get_Item(0)`. احتفظ بهذا الاختلاف في الاعتبار عند بناء المصفوفة لتجنب أخطاء الإزاحة بمقدار واحد.

استدعِ التعريف المتعدد عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getFontsManager--) . تُعيد الطريقة فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد السقوط المُكوَّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحمَّلة خارجيًا](/slides/ar/java/custom-font/).

قد يتطلب نفس الاستبدال أكثر من شريحة مختارة. احذف التكرارات عند إنشاء جرد للخطوط أو تقرير ما قبل الطيران. المثال التالي يُبلغ عن كل استبدال تم إرجاعه ثم ينشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر واجهة [IFontsManager](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/) كل من التعريفات المتعددة. اختر واحدة وفقًا لنطاق عملية العرض:

| النسخة | متى تستخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون معلمات | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع `int[] slides` | تحتاج إلى استبدالات لنطاق محدد، فحص متزايد، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متاح:

1. تحميل العرض التقديمي.
2. إنشاء تعريفات الخط للخط الأصلي والبديل.
3. إنشاء [FontSubstRule](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstrule/) مع شرط [WhenInaccessible](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstcondition/).
4. إضافة القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsubstrulecollection/).
5. تعيين المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).
6. عرض أو تحويل العرض التقديمي.

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

{{% alert color="info" title="ملاحظة" %}}
لإجراء تغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [Font Replacement](/slides/ar/java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل هذه القواعد للنص العادي عندما يمكن لـ Aspose.Slides استبدال خط غير قابل للوصول بخط متاح محدد في القاعدة.

معادلات Office Math لديها متطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالذات لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يبلّغ أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض التقديمي، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله ك[خط خارجي](/slides/ar/java/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على النص العادي في العرض التقديمي.

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط (Font Replacement) واستبدال الخطوط (Font Substitution)؟**

[Font replacement](/slides/ar/java/font-replacement/) يغيّر خطًا بآخر بشكل متعمد في جميع أنحاء العرض التقديمي. استبدال الخطوط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المُكوَّن، مثل عدم توفر الخط الأصلي.

**متى تُطبَّق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. يعتمد النتيجة على الخطوط المتوفرة في بيئة التنفيذ.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/java/custom-font/) حتى يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكن جعل اختيار الخط متسقًا في التحويلات الدفعية؟**

استخدم نفس ملفات الخط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/java/custom-font/)، و[دمج الخطوط](/slides/ar/java/embedded-font/) عندما تسمح الرخص. يمكنك أيضًا استدعاء [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) قبل التصدير لتحديد الاستبدالات غير المتوقعة.