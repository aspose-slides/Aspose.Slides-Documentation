---
title: تكوين استبدال الخطوط في العروض التقديمية في .NET
linktitle: استبدال الخط
type: docs
weight: 70
url: /ar/net/font-substitution/
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
- .NET
- C#
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وفحص الخطوط المستبدلة في Aspose.Slides لـ .NET أثناء عرض أو تحويل عروض PowerPoint وOpenDocument التقديمية."
---
## **نظرة عامة**

تسمح استبدال الخطوط لـ Aspose.Slides باستخدام خط متاح بدلاً من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المعروضة؛ ولا يغيّر الخط المعين لمحتوى العرض التقديمي.

يمكنك تحديد الخط الذي سيتم استخدامه عندما يكون خط معين غير متوفر، ويمكنك فحص الاستبدالات التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على اتساق المخرجات عبر بيئات تحتوي على خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/) لتحديد الخطوط التي سيتم استبدالها عند عرض العرض التقديمي. تُعيد الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والمستبدل.

المثال التالي بلغة C# يدرج جميع استبدالات الخطوط لعروض تقديمي:

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

استخدم نسخة الطريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/) التي تقبل معامل `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. هذا مفيد عندما تقوم بعرض أو تصدير جزء من العرض التقديمي، أو فحص عرض تقديمي كبير بشكل تدريجي، أو تحديد الشرائح التي تعتمد على خطوط غير متوفرة، أو إعداد حزمة خطوط قليلة لملقم أو حاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

مصفوفة `slides` تحتوي على فهارس الشرائح بدءًا من الواحد: `1` يحدد الشريحة الأولى. بالمقابل، فهرس مجموعة [Presentation.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/slides/ar/) هو صفرية الأساس، لذلك يتم الوصول إلى نفس الشريحة عبر `presentation.Slides[0]`. احرص على مراعاة هذا الفرق عند بناء المصفوفة لتجنب أخطاء الفهرسة.

استدعِ النسخة عبر الخاصية [Presentation.FontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/fontsmanager/). تُعيد فقط الاستبدالات التي تم تحديدها أثناء عرض الشرائح المحددة. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والمستبدل. تعكس النتيجة بيئة الخط الحالية، وقواعد الرجوع التلقائي المكوّنة، وقواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsubstrulecollection/)، و[الخطوط المحملة خارجيًا](/slides/ar/net/custom-font/).

يمكن أن يتطلب نفس الاستبدال أكثر من شريحة محددة. قم بإزالة الازدواجية من النتائج عند إنشاء جرد للخطوط أو تقرير الفحص المسبق. المثال التالي يوضح كل استبدال تم إرجاعه ثم يُنشئ قائمة مرتبة من تعيينات الخطوط الفريدة:

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

توفر الواجهة [IFontsManager](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/) كلا النسختين. اختر واحدة حسب نطاق عملية العرض:

| النسخة | متى تُستخدم |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/) بدون معلمات | عندما تحتاج إلى استبدالات للعرض التقديمي بأكمله. |
| [GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/) مع `int[] slides` | عندما تحتاج إلى استبدالات لنطاق محدد أو فحص تدريجي أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب على Aspose.Slides استخدامه عندما يكون الخط المصدر غير متوفر:

1. حمّل العرض التقديمي.  
2. أنشئ تعريفات الخط للمصدر والخط المستبدل.  
3. أنشئ قاعدة [FontSubstRule](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsubstcondition/).  
4. أضف القاعدة إلى مجموعة [FontSubstRuleCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsubstrulecollection/).  
5. عيّن المجموعة إلى الخاصية [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/ar/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. اعرض أو حوّل العرض التقديمي.

المثال التالي بلغة C# يستبدل الخط `Arial` بالخط `SomeRareFont` عندما يكون `SomeRareFont` غير متوفر، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط المستبدل متاحًا لـ Aspose.Slides.

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

{{% alert color="info" title="Note" %}}
لإجراء تغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض التقديمي، راجع [استبدال الخط](/slides/ar/net/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل للنص العادي عندما يمكن لـ Aspose.Slides استبدال خط غير قابل للوصول بالخط المتاح المحدد في القاعدة.

معادلات Office Math لها متطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد تحتاج Aspose.Slides إلى هذا الخط بالضبط لحساب وعرض تخطيط المعادلة. لا يمكن لقاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، أن تحل محل **Cambria Math** لهذا الغرض، وقد يظل العرض يُظهر أن **Cambria Math** مطلوب.

لعرض أو تحويل مثل هذا العرض التقديمي، اجعل **Cambria Math** متوفرًا لـ Aspose.Slides. قم بتثبيته في نظام التشغيل أو حمّله كـ [external font](/slides/ar/net/custom-font/).

هذا القيد ينطبق على تخطيط المعادلات. لا تزال قواعد الاستبدال المذكورة أعلاه تنطبق على نص العرض التقديمي العادي.

## **الأسئلة الشائعة**

**ما الفرق بين استبدال الخط (Font Replacement) واستبدال الخط (Font Substitution)؟**

[Font replacement](/slides/ar/net/font-replacement/) يغيّر الخط عمدًا من أحده إلى آخر في جميع أنحاء العرض التقديمي. بينما يختار استبدال الخط (font substitution) خطًا للمخرجات المعروضة عندما يتحقق الشرط المكوّن، مثل عدم توفر الخط الأصلي.

**متى تُطبق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/net/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستخدم القاعدة فقط عندما لا يتمكن Aspose.Slides من الوصول إلى الخط المصدر.

**ماذا يحدث عندما يكون الخط مفقودًا ولا توجد قاعدة استبدال مُكوَّنة؟**

يقوم Aspose.Slides باختيار أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/net/custom-font/) حتى يتمكن Aspose.Slides من استخدامها أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط بحسب نظام التشغيل، لذلك قد يكون الخط المتاح على جهاز واحد يحتاج إلى استبدال على جهاز آخر.

**كيف يمكنني جعل اختيار الخطوط ثابتًا في التحويلات الدفعية؟**

استخدم نفس ملفات الخط وإصداراته على كل جهاز أو حاوية، [تحميل الخطوط الخارجية المطلوبة](/slides/ar/net/custom-font/)، و[دمج الخطوط](/slides/ar/net/embedded-font/) عندما تسمح الترخيص بذلك. يمكنك أيضًا استدعاء [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ar/net/aspose.slides/ifontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.