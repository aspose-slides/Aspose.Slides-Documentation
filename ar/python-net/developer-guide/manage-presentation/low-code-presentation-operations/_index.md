---
title: عمليات العرض التقديمي منخفضة الكود في Python
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/python-net/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العرض التقديمي منخفضة الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة الشرائح القالب غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم واجهة برمجة تطبيقات Aspose.Slides منخفضة الكود في Python لتحويل ودمج العروض التقديمية، جمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

يقدم وحدة [aspose.slides.lowcode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/) فئات مساعدية للعمليات الشائعة على العروض التقديمية. تقوم هذه المساعدات بلف سير عمل نموذج الكائنات المستخدم بشكل متكرر في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، جمع الأشكال، وإزالة المحتوى غير المستخدم بكمية أقل من الشيفرة.

تكون المساعدات منخفضة الكود أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج كائنات [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/python-net/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، القوالب، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض التقديمي.

الجدول التالي يلخص المساعدات المتوفرة:

| المساعد | استخدامه في |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى تنسيق آخر باستدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة بنفس التنسيق. |
| [Collect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/) | استرجاع الأشكال من العرض التقديمي بالكامل للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمَّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.auto_by_extension](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/auto_by_extension/) عندما تكون ملحقات ملف الإخراج كافية لاختيار تنسيق التصدير. تُفتح الطريقة العرض التقديمي المصدر، تحدد التنسيق المطلوب من مسار الإخراج، وتكتب النتيجة.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/) أيضًا طرقًا مخصصة للإخراج بصيغ PDF و SVG و JPEG و PNG و TIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تكوين خيار تصدير غير متاح في المساعد المحدد. راجع [Convert Presentation](/python-net/convert-presentation/) لسير العمل والخيارات الخاصة بكل تنسيق.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون العروض التقديمية المدخلة بنفس تنسيق الملف.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون تحديدها أو إعادة تعيينها فرديًا. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط هدف، حفظ الأقسام صراحة، أو توفيق أحجام شرائح مختلفة. راجع [Merge Presentations](/python-net/merge-presentation/) لتلك السيناريوهات.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة جميع الأشكال في عرض تقديمي. يكون ذلك مفيدًا عندما سيتم تصفية المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

استخدم حلقات التجميع المباشر عندما يكون ترتيب التجوال أو الخروج المبكر أو التصفية قبل المعالجة أو التحكم التفصيلي بين الأبناء مهمًا.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمَّنة:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) يزيل شرائح التخطيط التي لا تُشير إليها أي شريحة عادية.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) يزيل القوالب التي لم تعد مستخدمة.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) يزيل الأحرف غير المستخدمة من الخطوط المضمَّنة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة حتى يمكن إزالة القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسَّن في ملف جديد إذا قد تحتاج القوالب أو التخطيطات الأصلية أو بيانات الخط المضمَّن الكاملة لاحقًا. لمزيد من التفاصيل، انظر [Slide Master](/python-net/slide-master/) و [Embedded Font](/python-net/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب استخدام واجهة برمجة التطبيقات منخفضة الكود بدلاً من نموذج الكائنات الكامل؟**

استخدم المساعدات منخفضة الكود عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القوالب والتخطيطات، فحص الحالة الوسيطة، أو تكوين سلوك لا expose المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بتنسيقات ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/process/) أن تكون العروض التقديمية المدخلة بنفس التنسيق. حوِّل الملفات المدخلة إلى تنسيق مشترك أولًا، على سبيل المثال باستخدام [Convert.auto_by_extension](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/auto_by_extension/)، ثم دمج الملفات المحوَّلة.

**ماذا يتضمن [Collect.shapes]؟**

[Collect.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/shapes/) يسترجع الأشكال من العرض التقديمي بحيث يمكن الاحتفاظ بها، تصفيتها، عدّها، أو تجوالها عدة مرات. استخدم حلقات التجميع المباشر عندما تحتاج إلى تحكم دقيق في أنواع الشرائح أو الكائنات المتداخلة التي يتم زيارتها.

**هل يجعل Compress حجم ملف العرض التقديمي أصغر دائمًا؟**

ليس بالضرورة. يعتمد النتيجة على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة، قوالب غير مستخدمة، أو خطوط مضمنة ذات أحرف غير مستخدمة. إذا لم يكن أي من هذه العناصر موجودًا، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تشغيل [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/python-net/convert-presentation/)
- [Merge Presentations](/python-net/merge-presentation/)
- [Slide Master](/python-net/slide-master/)
- [Manage Text Box](/python-net/manage-textbox/)
- [Embedded Font](/python-net/embedded-font/)