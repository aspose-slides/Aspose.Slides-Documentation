---
title: عمليات عرض منخفضة الشيفرة في .NET
linktitle: واجهة برمجة التطبيقات منخفضة الشيفرة
type: docs
weight: 50
url: /ar/net/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العرض منخفضة الشيفرة
- تحويل العرض
- دمج العروض التقديمية
- التكرار على الشرائح
- التكرار على الأشكال
- التكرار على النص
- جمع الأشكال
- ضغط العرض
- إزالة القوالب الرئيسية غير المستخدمة
- إزالة تخطيطات الشرائح غير المستخدمة
- ضغط الخطوط المضمنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدم واجهة Aspose.Slides منخفضة الشيفرة في .NET لتحويل ودمج العروض التقديمية، والتكرار عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض."
---
## **نظرة عامة**

توفر مساحة الأسماء [Aspose.Slides.LowCode](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات سير عمل نموذج الكائنات المتكرر في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، ومعالجة عناصر العرض، وجمع الأشكال، وإزالة المحتوى غير المستخدم بأقل كمية من الشيفرة.

تكون المساعدات قليلة الشيفرة أكثر فائدة عندما ينطبق العملاق على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج كائنات [Aspose.Slides](https://reference.aspose.com/slides/ar/net/aspose.slides/) الكامل عندما تحتاج إلى تحكم دقيق على الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

الجدول التالي يلخّص المساعدات المتاحة:

| المساعد | الاستخدام |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى صيغة أخرى باستدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة من نفس الصيغة. |
| [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/) | استرجاع الأشكال من العرض التقديمي بأكمله للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.AutoByExtension](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/autobyextension/) عندما يكون امتداد ملف الإخراج كافيًا لتحديد صيغة التصدير. تفتح الطريقة العرض المصدر، تحدد الصيغة المطلوبة من مسار الإخراج، وتكتب النتيجة.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

توفر الفئة [Convert](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/) أيضًا طرقًا مخصصة لإخراج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير مُعرض بواسطة المساعد المحدد. راجع [Convert Presentation](/net/convert-presentation/) للحصول على سير عمل وخيارات خاصة بالصيغة.

## **دمج عروض تقديمية**

استخدم [Merger.Process](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون العروض المدخلة ذات نفس صيغة الملف.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون تحديدها أو إعادة تعيينها فرديًا. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح محددة، أو تطبيق قالب أو تخطيط هدف، أو حفظ الأقسام صراحة، أو التوفيق بين أحجام شرائح مختلفة. راجع [Merge Presentations](/net/merge-presentation/) لهذه السيناريوهات.

## **التكرار عبر عناصر العرض**

تستدعي الفئة [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) دالة رد نداء لكل نوع مطلوب من عناصر العرض. يتجنّب ذلك حلقات الجمع المتداخلة وهو ملائم لتفتيش أو تغييرات تنسيق على مستوى العرض كله.

المثال التالي يستخدم [ForEach.Slide](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/portion/) لتفتيش العناصر المقابلة:

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

بشكل افتراضي، يشمل استعراض الأشكال والنص على مستوى العرض الشرائح العادية والقوالب والتخطيطات. يمكن للتحميلات التي تحتوي على معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات الجمع المباشرة عندما تكون порядок الاستعراض أو الخروج المبكر أو التصفية قبل استدعاء رد النداء أو التحكم التفصيلي في العلاقة بين الأبواب والأبناء أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

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

استخدم [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/) بدلاً من ذلك عندما يمكن التعامل مع كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجمّعة.

## **ضغط محتوى العرض**

يمكن للفئة [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمّنة:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) يزيل القوالب التي لم تعد مستخدمة.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/compressembeddedfonts/) يزيل الأحرف غير المستخدمة من الخطوط المضمّنة.

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

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن أيضًا حذف القالب الذي يصبح غير مرجع بعد تنظيف التخطيطات. احفظ العرض المحسّن في ملف جديد إذا قد تحتاج القوالب أو التخطيطات الأصلية أو بيانات الخط المضمّن كاملة لاحقًا. لمزيد من التفاصيل، انظر [Slide Master](/net/slide-master/) و[Embedded Font](/net/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب استخدام API قليلة الشيفرة بدلاً من نموذج الكائنات الكامل؟**

استخدم المساعدات قليلة الشيفرة عندما ينطبق إجراء قياسي على ملف أو عرض كامل ولا يتطلب تحكمًا مفصلاً في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب والتخطيط، فحص الحالة المتوسطة، أو تكوين سلوك لا يExposeه المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.Process](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/merger/process/) أن تكون العروض المدخلة بنفس الصيغة. قم بتحويل الملفات المدخلة إلى صيغة مشتركة أولًا، مثلاً باستخدام [Convert.AutoByExtension](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/convert/autobyextension/)، ثم دمج الملفات المحوّلة.

**هل يقوم ForEach بمعالجة شرائح القالب والتخطيط والملاحظات؟**

[ForEach.Slide](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/slide/) يكرّر عبر الشرائح العادية في العرض. تشمل عمليات [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/portion/) بشكل افتراضي الشرائح العادية والقوالب والتخطيطات. استخدم تحميلاتهم مع `includeNotes` مضبوطة على `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.Shape و Collect.Shapes؟**

استخدم [ForEach.Shape](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/shape/) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect.Shapes](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، تصفيتها، عدّها، أو استعراضها عدة مرات.

**هل يجعل Compress الملف أصغر دائمًا؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة أو قوالب غير مستخدمة أو خطوط مضمنة بأحرف غير مستخدمة. إذا لم يتوفر أي من هذه العناصر، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/) حجم الملف.

**هل يتم حفظ التغييرات التي يجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) المحمل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/net/aspose.slides.lowcode/compress/)، استدعِ [Presentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)