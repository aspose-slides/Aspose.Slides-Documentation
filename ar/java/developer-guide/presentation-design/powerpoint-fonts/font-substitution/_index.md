---
title: تهيئة استبدال الخطوط في العروض التقديمية باستخدام جافا
linktitle: استبدال الخطوط
type: docs
weight: 70
url: /ar/java/font-substitution/
keywords:
- الخط
- استبدال الخط
- استبدال الخطوط
- استبدال الخط
- استبدال الخط
- قاعدة الاستبدال
- قاعدة الاستبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تهيئة قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides for Java عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

استبدال الخطوط يسمح لـ Aspose.Slides باستخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص الاستبدالات التي ستجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على تناسق المخرجات عبر بيئات ذات خطوط مثبتة مختلفة.

إذا كان الخط متاحًا ولكن لا يحتوي على نوع غامق مخصص، راجع [معالجة الخطوط بدون نوع غامق مخصص](/slides/ar/java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح ذلك القسم كيفية تحويل النص المتأثر إلى صورة أثناء تصدير PDF وتبعات ذلك على اختيار النص، والبحث، وتغيير الحجم.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) التي تُعرّف أسماء الخط الأصلي والبديل.

المثال التالي بلغة Java يسرد جميع استبدالات الخطوط لعَرْض تقديمي:

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

استخدم طريقة [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع وسيط `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. هذا مفيد عندما تقوم بعرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير تدريجيًا، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط صغرى للخادم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على فهارس الشرائح بنظام ترقيم يبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، فإن وصول مجموعة الشرائح عبر [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) يستخدم فهارس تبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة عبر `presentation.getSlides().get_Item(0)`. احتفظ بهذا الاختلاف في الاعتبار عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعِ النسخة عبر طريقة [Presentation.getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getFontsManager--) . تُعيد الطريقة فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والبديل. تعكس النتيجة بيئة الخط الحالية، وقواعد السقوط الاحتياطية المكوّنة، و[الخطوط المحمّلة خارجيًا](/slides/ar/java/custom-font/). تُطبق قواعد الاستبدال المخزّنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsubstrulecollection/) عند عرض العرض التقديمي، لكن النتيجة لا تُدرجها؛ تحقق من الخطوط في ملف الإخراج بدلاً من ذلك.

يمكن أن تتطلب نفس الاستبدالية أكثر من شريحة مختارة. قم بإزالة التكرارات عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يبلّغ كل استبدال معاد وإ ثم يُنشئ قائمة مرتّبة لتعيينات الخطوط الفريدة:

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

واجهة [IFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/) توفر كلا النسختين. اختر واحدة وفقًا لنطاق عملية العرض:

| النسخة | متى يُستخدم |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) بدون وسائط | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) مع `int[] slides` | تحتاج إلى استبدالات لنطاق مختار، فحص تدريجي، أو تصدير جزئي. |

## **تعيين قواعد استبدال الخطوط**

1. قم بتحميل العرض التقديمي.  
2. أنشئ تعريفات الخط للمصدر والبديل.  
3. أنشئ كائنًا من نوع [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى مجموعة [FontSubstRuleCollection](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة باستخدام طريقة [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-).  
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
لإجراء تغيير غير مشروط على الخطوط المستخدمة في كامل العرض التقديمي، راجع [استبدال الخط](/slides/ar/java/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل هذه القواعد للنص العادي عندما تتمكن Aspose.Slides من استبدال خط غير قابل للوصول بخط متاح محدد بالقاعدة.

معادلات Office Math تتطلب شيئًا إضافيًا. إذا استخدمت معادلة الخط **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد لا يزال العرض يُظهر أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض التقديمي، احرص على توفر **Cambria Math** لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو احمله كـ [خط خارجي](/slides/ar/java/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على النص العادي في العرض التقديمي.

## **الأسئلة المتداولة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**  
[استبدال الخط](/slides/ar/java/font-replacement/) يغيّر خطًا واحدًا إلى آخر في جميع أنحاء العرض التقديمي عن قصد. استبدال الخطوط يختار خطًا للمخرجات المعروضة عندما يتحقق الشرط المحدد، مثل عندما يكون الخط الأصلي غير متاح.

**متى يتم تطبيق قواعد الاستبدال؟**  
تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/java/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible` تُستخدم القاعدة فقط عندما لا تستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوّنة؟**  
تختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة بها. النتيجة تعتمد على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**  
نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/java/custom-font/) لكي تتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**  
لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows و Linux و macOS؟**  
نعم. الخطوط المثبتة ومواقع البحث عن الخطوط تختلف حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز واحد استبدالًا على جهاز آخر.

**كيف يمكنني جعل اختيار الخطوط متسقًا في التحويلات الدفعية؟**  
استخدم نفس ملفات الخطوط وإصداراتها على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/java/custom-font/)، و[ضمّن الخطوط](/slides/ar/java/embedded-font/) عندما تسمح الرخصة. يمكنك أيضًا استدعاء [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) قبل التصدير لتحديد الاستبدالات غير المتوقعة.