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
- قاعدة استبدال
- قاعدة استبدال
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تكوين قواعد استبدال الخطوط وتفقد الخطوط المستبدلة في Aspose.Slides لـ .NET عند عرض أو تحويل عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

استبدال الخط يسمح لـ Aspose.Slides باستخدام خط متاح بدلًا من خط لا يمكن الوصول إليه عند عرض أو تحويل العرض التقديمي. يؤثر الاستبدال على المخرجات المُعرضة؛ ولا يغيّر الخط المعين لمحتوى العرض.

يمكنك تحديد الخط الذي سيُستخدم عندما يكون خط معين غير متاح، ويمكنك فحص عمليات الاستبدال التي سيجريها Aspose.Slides أثناء العرض. يساعد ذلك في الحفاظ على تناسق المخرجات عبر بيئات مختلفة لديها خطوط مثبتة مختلفة.

## **الحصول على استبدالات الخطوط**

استخدم طريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) لتحديد الخطوط التي ستُستبدل عندما يُعرض العرض التقديمي. تُرجع الطريقة كائنات [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) التي تحدد أسماء الخط الأصلي والبديل.

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

استخدم طريقة [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) ذات الوسيط `int[] slides` لفحص الاستبدالات المطلوبة فقط لعرض شرائح معينة. يكون هذا مفيدًا عند عرض أو تصدير جزء من العرض، أو فحص عرض تقديمي كبير بصورة تدريجية، أو تحديد الشرائح التي تعتمد على خطوط غير متاحة، أو إعداد حزمة خطوط صغيرة للخادم أو الحاوية، أو تشخيص اختلافات العرض دون معالجة الشرائح غير ذات الصلة.

المصفوفة `slides` تحتوي على فهارس شرائح تبدأ من الواحد: `1` يُشير إلى الشريحة الأولى. بالمقابل، فهرس مجموعة [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) يبدأ من الصفر، لذا تُصبح نفس الشريحة `presentation.Slides[0]`. احرص على مراعاة هذا الفرق عند بناء المصفوفة لتجنب أخطاء الإزاحة.

استدعِ النسخة المتعددة الوسائط عبر الخاصية [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). تُرجع الاستبدالات المحددة أثناء عرض الشرائح المختارة فقط. كل نتيجة هي كائن [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) يحتوي على أسماء الخط الأصلي والبديل. تُعكس النتيجة بيئة الخط الحالية و[الخطوط المحملة خارجيًا](/slides/ar/net/custom-font/). قواعد الاستبدال المخزنة في [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) تُغيّر المخرجات المعروضة لكنها لا تظهر في النتيجة.

قد يتطلب نفس الاستبدال أكثر من شريحة مختارة. قم بإزالة التكرار عند إنشاء جرد الخطوط أو تقرير الفحص المسبق. المثال التالي يُبلّغ عن كل استبدال مُرجع ثم يُنشئ قائمة مرتبة بخرائط الخطوط الفريدة:

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

توفر الواجهة [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) كلا النسختين. اختر واحدة حسب نطاق عملية العرض:

| Overload | Use it when |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) مع عدم وجود وسائط | تحتاج إلى استبدالات للعرض التقديمي بالكامل. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) مع `int[] slides` | تحتاج إلى استبدالات لنطاق مختار، فحص تدريجي، أو تصدير جزئي. |

## **تحديد قواعد استبدال الخطوط**

لتحديد الخط الذي يجب أن يستخدمه Aspose.Slides عندما يكون الخط المصدر غير متاح:

1. تحميل العرض التقديمي.  
2. إنشاء تعريفات للخط المصدر والبديل.  
3. إنشاء [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) مع الشرط [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/).  
4. إضافة القاعدة إلى [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).  
5. تعيين المجموعة إلى خاصية [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).  
6. عرض أو تحويل العرض التقديمي.

المثال التالي بلغة C# يستبدل `Arial` بـ `SomeRareFont` عندما يكون `SomeRareFont` غير متاح، ثم يعرض الشريحة الأولى للتحقق من النتيجة. يجب أن يكون الخط البديل متوفرًا لـ Aspose.Slides.

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
لك تغيير غير مشروط للخطوط المستخدمة في جميع أنحاء العرض، راجع [Font Replacement](/slides/ar/net/font-replacement/).
{{% /alert %}}

## **القيود على خطوط معادلات الرياضيات**

قواعد استبدال الخطوط هي جزء من عملية اختيار الخط القياسية المستخدمة أثناء العرض والتحويل. تعمل للنص العادي عندما يمكن لـ Aspose.Slides استبدال خط غير قابل للوصول بخط متاح محدد بقاعدة.

معادلات Office Math لديها متطلب إضافي. إذا استخدمت المعادلة **Cambria Math**، قد يحتاج Aspose.Slides إلى ذلك الخط بالضبط لحساب وعرض تخطيط المعادلة. قاعدة تستبدل بخط رياضي آخر، مثل **STIX Two Math**، لا يمكنها استبدال **Cambria Math** لهذا الغرض، وقد يظل العرض يبلّغ أن **Cambria Math** مطلوب.

للعرض أو التحويل لمثل هذا العرض، قم بجعل **Cambria Math** متاحًا لـ Aspose.Slides. ثبّته في نظام التشغيل أو حمّله ك[خط خارجي](/slides/ar/net/custom-font/).

هذا القيد يطبق على تخطيط المعادلات. قواعد الاستبدال الموضحة أعلاه لا تزال تنطبق على نص العرض العادي.

## **الأسئلة المتكررة**

**ما الفرق بين استبدال الخط واستبدال الخطوط؟**

[Font replacement](/slides/ar/net/font-replacement/) يغيّر خطًا بآخر عمدًا في جميع أنحاء العرض. استبدال الخط يختار خطًا للمخرجات المعروضة عندما يتم استيفاء الشرط المحدد، مثل عدم توفر الخط الأصلي.

**متى تُطبّق قواعد الاستبدال؟**

تشارك القواعد في [سلسلة اختيار الخط](/slides/ar/net/font-selection-sequence/) أثناء العرض والتحويل. مع `WhenInaccessible`، تُستعمل القاعدة فقط عندما لا يستطيع Aspose.Slides الوصول إلى الخط المصدر.

**ماذا يحدث إذا كان الخط مفقودًا ولا توجد قاعدة استبدال مكوّنة؟**

يختار Aspose.Slides أقرب خط متاح وفقًا لعملية اختيار الخط الخاصة به. تعتمد النتيجة على الخطوط المتوفرة في بيئة وقت التشغيل.

**هل يمكنني تحميل خطوط خارجية لتجنّب الاستبدال؟**

نعم. يمكنك [تحميل خطوط خارجية](/slides/ar/net/custom-font/) حتى يستخدمها Aspose.Slides أثناء العرض والتحويل.

**هل توزع Aspose الخطوط مع المكتبة؟**

لا. أنت المسؤول عن توفير الخطوط والامتثال لتراخيصها.

**هل يمكن أن تختلف نتائج الاستبدال بين Windows وLinux وmacOS؟**

نعم. تختلف الخطوط المثبتة ومواقع البحث عن الخط حسب نظام التشغيل، لذا قد يحتاج خط متوفر على جهاز إلى استبدال على جهاز آخر.

**كيف يمكن جعل اختيار الخط متسقًا في عمليات التحويل الدفعية؟**

استخدم نفس ملفات الخطوط والإصدارات على كل جهاز أو حاوية، [حمّل الخطوط الخارجية المطلوبة](/slides/ar/net/custom-font/)، و[ضمن الخطوط](/slides/ar/net/embedded-font/) عندما تسمح الرخص. يمكنك أيضًا استدعاء [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) قبل التصدير لتحديد الاستبدالات غير المتوقعة.