---
title: عمليات العروض التقديمية منخفضة الكود في .NET
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/net/low-code-presentation-operations/
keywords:
- واجهة برمجة التطبيقات للعروض التقديمية منخفضة الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة شرائح القالب غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الكود ل Aspose.Slides في .NET لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر مساحة الأسماء [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) فئات مساعدة ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات سير عمل نموذج الكائن المستخدم بشكل متكرر في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض التقديمي، جمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة شفرة أقل.

تكون المساعدات منخفضة الكود أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل وتطابق سير العمل الافتراضي متطلباتك. استخدم نموذج كائن [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) الكامل عندما تحتاج إلى تحكم دقيق على الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض التقديمي.

الجدول التالي يلخص المساعدات المتاحة:

| المساعد | استخدامه لـ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى صيغة أخرى باستخدام استدعاء مباشرة من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة من نفس الصيغة. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | استخراج الأشكال من العرض التقديمي بالكامل للمعالجة أو التحليل المتكرر. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | إزالة القوالب/التخطيطات غير المستخدمة، تقليل بيانات الخطوط المدمجة وضغط الصور. |

## **تحويل عرض تقديمي**

استخدم [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) عندما تكون امتداد ملف الإخراج كافيًا لاختيار صيغة التصدير. تفتح الطريقة العرض التقديمي المصدر، تحدد الصيغة المطلوبة من مسار الإخراج، وتكتب النتيجة.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

توفر فئة [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) أيضًا طرقًا مخصصة لإخراج PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تكوين خيار تصدير غير معروض بواسطة المساعد المحدد. راجع [تحويل عرض تقديمي](/slides/ar/net/convert-presentation/) لتعرف على سير عمل وخيارات خاصة بالصيغ.

## **دمج العروض التقديمية**

استخدم [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون الصيغ للعرضين المدخلين متطابقة.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

المساعدة مناسبة عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها فرديًا. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط وجهة، الحفاظ على الأقسام صراحة، أو توحيد أحجام شرائح مختلفة. راجع [دمج العروض التقديمية](/slides/ar/net/merge-presentation/) لهذه السيناريوهات.

## **التكرار عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) ردًا لاستدعاء لكل نوع مطلوب من عناصر العرض التقديمي. إنها تتجنب حلقات التجميع المتداخلة وتكون ملائمة لفحص العرض التقديمي بالكامل أو تغييرات التنسيق.

يستخدم المثال التالي [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/)، [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) لفحص العناصر المقابلة:

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

افتراضيًا، يتضمن استعراض الأشكال والنص عبر العرض التقديمي الشرائح العادية والقالب والتخطيط. يمكن للتحميلات التي تحتوي على معامل `includeNotes` أيضًا معالجة شرائح الملاحظات. استخدم حلقات التجميع المباشرة عندما يكون ترتيب الاستعراض أو الخروج المبكر أو الترشيح قبل استدعاء الرد أو التحكم التفصيلي بين الأصل والطفل أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة من جميع الأشكال في العرض التقديمي بدلاً من رد لكل شكل. يكون ذلك مفيدًا عندما سيتم ترشيح المجموعة نفسها أو عدها أو معالجتها أكثر من مرة.

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

استخدم [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) بدلاً من ذلك عندما يمكن معالجة كل شكل فورًا ولا تحتاج إلى الاحتفاظ بالنتيجة المجموعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) إزالة العناصر البنائية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) يزيل شرائح القالب التي لم تعد مستخدمة.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

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

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن إزالة القالب الذي يصبح غير مرجعي بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسّن إلى ملف جديد إذا قد تحتاج القوالب أو التخطيطات الأصلية أو بيانات الخطوط المدمجة الكاملة لاحقًا. للمزيد من التفاصيل، راجع [قالب الشريحة](/slides/ar/net/slide-master/) و[الخط المدمج](/slides/ar/net/embedded-font/).

### **ضغط العرض التقديمي بالكامل**

يضيف Aspose.Slides for .NET 26.11 الطريقة [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). تجمع بين إزالة شرائح التخطيط/القالب غير المستخدمة، تقليص الخطوط المدمجة إلى الأحرف المستخدمة، وضغط الصور بدقة 150 DPI. استخدم العمليات الفردية أعلاه عندما تحتاج إلى التحكم في التغييرات التي تُطبق.

ثبت [Aspose.Slides for .NET](/slides/ar/net/installation/) الإصدار 26.11 أو أحدث وقدّم `input.pptx`. احفظ إلى ملف منفصل: قد تحتاج إلى التخطيطات المحذوفة، أحرف الخطوط، أو بكسلات الصورة المقصوصة لاحقًا للتحرير.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **ضغط الصور بدقة مختارة**

استخدم [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) لمعالجة الصور المؤهلة دون إزالة التخطيطات أو تقليص الخطوط. يوضح هذا المثال 96 DPI؛ اختر قيمة أخرى من [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) حسب احتياجاتك.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

يستخدم كلا المساعدين النطاق التالي لمعالجة الصور:

| المحتوى | المعالجة |
| --- | --- |
| الصور النقطية وملء صور الأشكال على الشرائح العادية والقالب والتخطيط، بما في ذلك الأشكال المجمعة | مؤهلة للضغط. |
| الصور الموجودة بالفعل بالدقة المطلوبة أو أقل | غير مكبرة. يمكن إزالة المناطق المقصوصة. |
| مناطق الصورة المقصوصة | البكسلات المخفية تُزال بشكل دائم وتُعاد تعيين إزاحات القص. |
| خلفيات الشرائح وملء خلايا الجدول | لا يتم معالجتها بواسطة هذه المساعدات. |
| الرسوم البيانية/SmartArt الداخلية، GIF والصيغ المتجهة مثل SVG, EMF و WMF | خارج نطاق ضغط الصور الموثق. |

في الإصدار 26.11، تُجنب الخاصية [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) تقليل الدقة للصور غير المقصوصة، لكن **لا تحافظ على بكسلات القص**. لا يزال بإمكان صورة مقصوصة أن تُعاد كتابةً مع إزالة المناطق المخفية. لا تعرض أي من المساعدين خيار الحفاظ على القص. للتحكم الفردي، راجع مثال [ضغط الصورة حسب كل صورة](/slides/ar/net/examples/optimization-batch/compression/).

قارن مظهر وحجم الملف الناتج قبل استبدال الأصلي. التوفير يعتمد على صور المصدر، حجم العرض، والمحتوى غير المستخدم؛ الضغط لا يضمن حجمًا أصغر. راجع [الخطوط المدمجة](/slides/ar/net/embedded-font/) لتفهم تبعات تقليص الخطوط.

## **الأسئلة الشائعة**

**متى يجب استخدام واجهة برمجة التطبيقات منخفضة الكود بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الكود عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب والتخطيط، فحص الحالة المتوسطة، أو تكوين سلوك لا تعرضه المساعدة.

**هل يمكن لـ Merger دمج العروض التقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) أن تكون العروض التقديمية المدخلة بنفس الصيغة. حوّل الملفات المدخلة إلى صيغة مشتركة أولًا، على سبيل المثال باستخدام [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/)، ثم دمج الملفات المحوَّلة.

**هل يعالج ForEach القوالب، التخطيطات، وشرائح الملاحظات؟**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) يتنقل عبر شرائح العرض التقديمي العادية. تشمل عمليات [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/)، [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/)، و[ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) الشرائح العادية والقالب والتخطيط افتراضيًا. استخدم التحميلات ذات المعامل `includeNotes` مع القيمة `true` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.Shape و Collect.Shapes؟**

استخدم [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) لمعالجة كل شكل فورًا عبر رد استدعاء. استخدم [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى نتيجة قابلة للتعداد يمكن الاحتفاظ بها، ترشيحها، عدها أو استعراضها متعددًا.

**هل يجعل Compress دائمًا ملف العرض التقديمي أصغر؟**

ليس بالضرورة. يعتمد التوفير على التخطيطات/القوالب غير المستخدمة، الخطوط المدمجة التي تحتوي على أحرف غير مستخدمة، والصور التي تستفيد من الضغط. قد تُبقي المساعدات [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) الحجم كما هو أو حتى تزداد لبعض المدخلات. قارن بين الحجم والجودة المعروضة، واحفظ النسخة الأصلية.

**هل تُحفظ التغييرات التي تُجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تعديل العناصر في رد استدعاء [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)، استدعِ [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل عرض تقديمي](/slides/ar/net/convert-presentation/)
- [دمج العروض التقديمية](/slides/ar/net/merge-presentation/)
- [قالب الشريحة](/slides/ar/net/slide-master/)
- [إدارة مربع النص](/slides/ar/net/manage-textbox/)
- [الخط المدمج](/slides/ar/net/embedded-font/)