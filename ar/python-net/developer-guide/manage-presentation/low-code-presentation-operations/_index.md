---
title: عمليات العرض التقديمي منخفضة الكود في بايثون
linktitle: API منخفض الكود
type: docs
weight: 50
url: /ar/python-net/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العرض التقديمي منخفض الكود
- تحويل العرض التقديمي
- دمج العروض التقديمية
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة شرائح القالب الرئيسي غير المستخدمة
- إزالة شرائح التخطيط غير المستخدمة
- ضغط الخطوط المدمجة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخدم واجهة Aspose.Slides منخفضة الكود في بايثون لتحويل ودمج العروض التقديمية، جمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر وحدة [aspose.slides.lowcode](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/) فئات مساعدية للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات سير عمل نموذج الكائنات المستخدم بشكل متكرر في طرق مركّزة، مما يتيح لك تحويل أو دمج الملفات، جمع الأشكال، وإزالة المحتوى غير المستخدم بكمية أقل من الشيفرة.

تكون المساعدات منخفضة الكود أكثر فائدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل ويتطابق سير العمل الافتراضي مع متطلباتك. استخدم نموذج كائنات [Aspose.Slides الكامل](https://reference.aspose.com/slides/ar/python-net/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية، القوالب الرئيسية، التخطيطات، الأشكال، إعدادات التصدير، أو العلاقات بين عناصر العرض التقديمي.

الجدول التالي يلخّص المساعدات المتاحة:

| المساعد | يستخدم لـ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/) | تحويل عرض تقديمي إلى صيغة أخرى باستخدام استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/) | دمج ملفات عروض تقديمية كاملة ذات نفس الصيغة. |
| [Collect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/) | استخراج الأشكال من العرض التقديمي كاملًا للمعالجة أو التحليل المتكرر. |
| [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المدمجة. |

## **تحويل عرض تقديمي**

استخدم [Convert.auto_by_extension](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/auto_by_extension/) عندما يكون امتداد ملف الإخراج كافيًا لتحديد صيغة التصدير. تقوم الطريقة بفتح العرض التقديمي المصدر، وتحديد الصيغة المطلوبة من مسار الإخراج، وكتابة النتيجة.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/) أيضًا طرقًا مخصصة للإخراج بصيغة PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائن الكامل عندما تحتاج إلى فحص أو تعديل العرض التقديمي قبل التصدير أو تهيئة خيار تصدير غير متاح عبر المساعدة المختارة. راجع [Convert Presentation](/slides/ar/python-net/convert-presentation/) للحصول على سير عمل وخيارات محددة لكل صيغة.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/process/) لدمج ملفات عروض تقديمية كاملة باستدعاء واحد. يجب أن تكون العروض التقديمية المدخلة بنفس صيغة الملف.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

المساعدة مناسبة عندما يجب إلحاق جميع الشرائح بنتيجة واحدة دون اختيارها أو إعادة تعيينها بشكل فردي. استخدم نموذج الكائن الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب رئيس أو تخطيط وجهة، الحفاظ على الأقسام صراحة، أو التوفيق بين أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/python-net/merge-presentation/) لهذه السيناريوهات.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/shapes/) عندما تحتاج إلى مجموعة جميع الأشكال في عرض تقديمي. هذا مفيد عندما سيتم تصفية المجموعة نفسها أو عدّها أو معالجتها أكثر من مرة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

استخدم حلقات جمع مباشرة عندما يكون ترتيب الاستعراض، الخروج المبكر، التصفية قبل المعالجة، أو التحكم التفصيلي في العلاقة بين الأصل والفرع مهمًا.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المدمجة:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) يزيل شرائح القالب الرئيسي التي لم تعد مستخدمة.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) يزيل الأحرف غير المستخدمة من الخطوط المدمجة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

قم بإزالة التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن إزالة القالب الذي يصبح غير مُشار إليه بعد تنظيف التخطيطات. احفظ العرض التقديمي المُحسّن في ملف جديد إذا كنت قد تحتاج إلى القوالب أو التخطيطات الأصلية أو بيانات الخط المدمج الكاملة لاحقًا. للمزيد من التفاصيل، راجع [Slide Master](/slides/ar/python-net/slide-master/) و[Embedded Font](/slides/ar/python-net/embedded-font/).

## **الأسئلة المتكررة**

**متى ينبغي علي استخدام API منخفض الكود بدلاً من نموذج الكائن الكامل؟**

استخدم المساعدات منخفضة الكود عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائن الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القالب الرئيسي والتخطيط، فحص الحالة المتوسطة، أو تهيئة سلوك لا تكشف عنه المساعدة.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/merger/process/) أن تكون العروض التقديمية المدخلة بنفس الصيغة. حوّل الملفات المدخلة إلى صيغة مشتركة أولاً، على سبيل المثال باستخدام [Convert.auto_by_extension](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/convert/auto_by_extension/)، ثم دمج الملفات المحوّلة.

**ماذا يتضمن Collect.shapes؟**

[Collect.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/collect/shapes/) يستخرج الأشكال من العرض التقديمي بحيث يمكن الاحتفاظ بها، تصفيتها، عدّها، أو استعراضها عدة مرات. استخدم حلقات جمع مباشرة عندما تحتاج إلى تحكم دقيق في أنواع الشرائح أو الكائنات المتداخلة التي يتم زيارتها.

**هل Compress يقلل دائمًا حجم ملف العرض التقديمي؟**

ليس بالضرورة. تعتمد النتيجة على ما إذا كان العرض التقديمي يحتوي على تخطيطات غير مستخدمة، قوالب رئيسية غير مستخدمة، أو خطوط مدمجة بها أحرف غير مستخدمة. إذا لم يتوفر أي من هذه العناصر، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) حجم الملف.

**هل تُحفظ التغييرات التي يجريها Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تشغيل [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/save/) لكتابة النتيجة.

## **مقالات ذات صلة**

- [تحويل العرض التقديمي](/slides/ar/python-net/convert-presentation/)
- [دمج العروض التقديمية](/slides/ar/python-net/merge-presentation/)
- [قالب الشريحة](/slides/ar/python-net/slide-master/)
- [إدارة مربع النص](/slides/ar/python-net/manage-textbox/)
- [خط مدمج](/slides/ar/python-net/embedded-font/)