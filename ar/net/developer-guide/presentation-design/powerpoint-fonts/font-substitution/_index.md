---
title: "تكوين استبدال الخطوط في العروض التقديمية في .NET"
linktitle: "استبدال الخط"
type: docs
weight: 70
url: /ar/net/font-substitution/
keywords:
- "خط"
- "خط بديل"
- "استبدال الخط"
- "استبدال الخط"
- "استبدال الخط"
- "قاعدة الاستبدال"
- "قاعدة الاستبدال"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لـ .NET عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على تناسق المخرجات عبر بيئات تحتوي على خطوط مثبتة مختلفة.

إذا كان الخط متاحًا ولكن لا يحتوي على وزن غامق مخصص، راجع [معالجة الخطوط بدون وزن غامق مخصص](/slides/ar/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). يشرح هذا القسم كيفية تحويل النص المتأثر إلى صورة أثناء تصدير PDF والعواقب على تحديد النص والبحث والتحجيم.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة C# يسرد جميع استبدالات الخطوط لعرض تقديمي:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **الحصول على استبدالات الخطوط للشرائح المحددة**

استخدم نسخة طريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ذات الوسيط `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. هذا مفيد عندما تقوم بعرض أو تصدير جزء من العرض التقديمي، أو التحقق من عرض كبير بطريقة تراكمية، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط minimal لخادم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على فهارس الشرائح بترقيم يبدأ من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، فهرس مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) يبدأ من الصفر، لذا يتم الوصول إلى نفس الشريحة عبر `presentation.Slides[0]`. احرص على مراعاة هذا الفرق عند بناء المصفوفة لتفادي أخطاء الإزاحة.

استدعِ النسخة عبر الخاصية [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المختارة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية و[الخطوط المحمَّلة خارجيًا](/slides/ar/net/custom-font/). قواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) تغير المخرجات المعروضة ولكن لا تنعكس في النتيجة.

يمكن أن تتطلب نفس الاستبدالية أكثر من شريحة مختارة. قم بإزالة التكرارات عند إنشاء جرد للخطوط أو تقرير فحص مسبق. المثال التالي يبلّغ عن كل استبدال مُرجع ثم ينشئ قائمة مرتبة للتعيينات الفريدة للخطوط:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

توفر واجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) كلا النسختين. اختر واحدة وفقًا لنطاق عملية العرض:

| النسخة | متى نستخدمها |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) بدون وسائط | تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) مع `int[] slides` | تحتاج إلى استبدالات لنطاق مختار، أو فحص تراكمى، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط الأصلي غير متاح:

1. تحميل العرض التقديمي.  
2. إنشاء تعريفات للخط الأصلي والبديل.  
3. إنشاء كائن [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) باستخدام الشرط [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).  
4. إضافة القاعدة إلى مجموعة [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).  
5. إسناد المجموعة إلى خاصية [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة C# يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متاح، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متاحًا لـ Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="ملاحظة" %}}
لإجراء تغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [استبدال الخط](/slides/ar/net/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل هذه القواعد للنص العادي عندما يستطيع Aspose.Slides استبدال خط غير متاح بالخط المتاح المحدد في القاعدة.

معادلات Office Math لها متطلب إضافي. إذا استخدمت معادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى هذا الخط بالذات لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر مثل **STIX Two Math** أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يطلب **Cambria Math**.

لعرض أو تحويل مثل هذا العرض، اجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبّت الخط على نظام التشغيل أو حمّله كـ [خط خارجي](/slides/ar/net/custom-font/).

تنطبق هذه القيد على تخطيط المعادلات فقط. لا تزال قواعد الاستبدال المذكورة أعلاه سارية على نص العرض التقديمي العادي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[استبدال الخط](/slides/ar/net/font-replacement/) يغيّر خطًا إلى آخر عبر جميع أجزاء العرض التقديمي بنيةً متعمدة. يختار استبدال الخط خطًا للمخرجات المعروضة عندما يتحقق الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُطبّق قواعد الاستبدال؟**

تشارك القواعد في [تسلسل اختيار الخط](/slides/ar/net/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible` تُستخدم القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط الأصلي.

**ماذا يحدث إذا كان الخط مفقودًا ولم تُحدَّد قاعدة استبدال؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/net/custom-font/) بحيث يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخطوط حسب نظام التشغيل، لذا قد يتطلب خط متاح على جهاز ما استبدالًا على جهاز آخر.

**كيف يمكن جعل اختيار الخط متسقًا في عمليات التحويل الجماعية؟**

استخدم نفس ملفات الخط وإصداراتها على كل جهاز أو حاوية، [حمل الخطوط الخارجية المطلوبة](/slides/ar/net/custom-font/)، و[ضمن الخطوط](/slides/ar/net/embedded-font/) عندما تسمح الرخص. يمكنك أيضًا استدعاء [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.