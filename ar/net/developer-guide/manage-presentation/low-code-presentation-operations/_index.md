---
title: عمليات العرض منخفضة الشيفرة في .NET
linktitle: واجهة برمجة التطبيقات منخفضة الشيفرة
type: docs
weight: 50
url: /ar/net/low-code-presentation-operations/
keywords:
- واجهة برمجة التطبيقات للعرض منخفضة الشيفرة
- تحويل العرض
- دمج العروض
- التكرار عبر الشرائح
- التكرار عبر الأشكال
- التكرار عبر النص
- جمع الأشكال
- ضغط العرض
- إزالة قوالب الشرائح غير المستخدمة
- إزالة تخطيطات الشرائح غير المستخدمة
- ضغط الخطوط المضمَّنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الشيفرة لـ Aspose.Slides في .NET لتحويل ودمج العروض، التكرار عبر المحتوى، جمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر الفضاء الاسمي [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تقوم هذه المساعدات بلف تدفقات العمل المتكررة في نموذج الكائن في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم بكمية أقل من الكود.

تكون المساعدات منخفضة الشيفرة مفيدة عندما تنطبق العملية على ملف أو عرض تقديمي كامل وتطابق سير العمل الافتراضي متطلباتك. استخدم نموذج كائن [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/net/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

الجدول التالي يلخص المساعدات المتاحة:

| المساعد | ما يُستخدم من أجله |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة من نفس التنسيق. |
| [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) | تشغيل إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/) | استرجاع الأشكال من العرض بالكامل للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمَّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.AutoByExtension](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/autobyextension/) عندما يكون امتداد ملف الإخراج كافياً لتحديد تنسيق التصدير. تقوم الطريقة بفتح العرض المصدر، وتحديد التنسيق المطلوب من مسار الإخراج، وكتابة النتيجة.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

تقدم فئة [Convert](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/) أيضاً طرقاً مخصصة لإخراج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير معروض بواسطة المساعد المختار. راجع [تحويل العرض](/slides/ar/net/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.Process](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة بمستدعي واحد. يجب أن تكون الصيغ المتدخلة هي نفسها.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما ينبغي إلحاق جميع الشرائح إلى نتيجة واحدة دون الحاجة إلى اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح محددة، أو تطبيق قالب أو تخطيط وجهة، أو الحفاظ على الأقسام بشكل صريح، أو توفيق أحجام الشرائح المختلفة. راجع [دمج العروض](/slides/ar/net/merge-presentation/) لتلك السيناريوهات.

## **التكرار عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) ردًا خلفيًا لكل نوع مطلوب من عناصر العرض. إنها تتجنب الحلقات المتداخلة للمجموعات وتكون مريحة للتفتيش أو تعديل الصيغ على مستوى العرض كله.

المثال التالي يستخدم [ForEach.Slide](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/portion/) لتفحص العناصر المقابلة:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

بشكل افتراضي، يشمل التجول عبر الأشكال والنصوص على مستوى العرض الشرائح العادية، وقوالب الشرائح، وتخطيطاتها. يمكن للتحميلات التي تتضمن معلمة `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات جمع مباشرة عندما يكون ترتيب التجول أو الخروج المبكر أو الترشيح قبل استدعاء الرد الخلفي أو التحكم التفصيلي في علاقة الأب بالابن مهمًا.

## **جمع الأشكال**

استخدم [Collect.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من رد خلفي لكل شكل. هذا مفيد عندما سيتم ترشيح المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

استخدم [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمَّنة:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) يزيل تخطيطات الشرائح التي لا تشير إليها أي شريحة عادية.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) يزيل قوالب الشرائح التي لم تعد مستخدمة.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/compressembeddedfonts/) يزيل الحروف غير المستخدمة من الخطوط المضمَّنة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن أيضًا إزالة القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيطات. احفظ العرض المحسّن إلى ملف جديد إذا كنت قد تحتاج إلى القوالب أو التخطيطات الأصلية أو بيانات الخط المضمَّنة بالكامل لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/slides/ar/net/slide-master/) و[Embedded Font](/slides/ar/net/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب علي استخدام واجهة برمجة التطبيقات low-code بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا مفصلاً في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى تحديد شرائح معينة، أو التحكم في علاقات القالب والتخطيط، أو فحص الحالة المتوسطة، أو تكوين سلوك لا يكشفه المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.Process](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/process/) أن تكون العروض المدخلة بنفس الصيغة. قم بتحويل الملفات المدخلة إلى صيغة مشتركة أولاً، على سبيل المثال باستخدام [Convert.AutoByExtension](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/autobyextension/)، ثم دمج الملفات المحولة.

**هل يعالج ForEach القوالب وتخطيطات الشرائح وشريحة الملاحظات؟**

[ForEach.Slide](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/slide/) يتكرر عبر الشرائح العادية للعرض. تشمل عمليات [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/portion/) الشرائح العادية، والقوالب، والتخطيطات بشكل افتراضي. استخدم التحميلات التي تحتوي على `includeNotes` مضبوطة على `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.Shape و Collect.Shapes؟**

استخدم [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/) لمعالجة كل شكل فورًا من خلال رد خلفي. استخدم [Collect.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى نتيجة قابلة للتعداد يمكن الاحتفاظ بها، وترشيحها، أو عدّها، أو المرور عليها عدة مرات.

**هل يجعل Compress حجم ملف العرض أصغر دائمًا؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة أو قوالب غير مستخدمة أو خطوط مضمَّنة بحروف غير مستخدمة. إذا لم تتوفر أي من هذه العناصر، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) حجم الملف.

**هل يتم حفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تعديل العناصر في رد خلفي لـ [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/)، استدعِ [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل العرض](/slides/ar/net/convert-presentation/)
- [دمج العروض](/slides/ar/net/merge-presentation/)
- [Slide Master](/slides/ar/net/slide-master/)
- [Manage Text Box](/slides/ar/net/manage-textbox/)
- [Embedded Font](/slides/ar/net/embedded-font/)