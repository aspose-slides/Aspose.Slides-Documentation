---
title: عمليات العرض منخفضة الكود في بايثون عبر جافا
linktitle: واجهة برمجة التطبيقات منخفضة الكود
type: docs
weight: 50
url: /ar/python-java/low-code-presentation-operations/
keywords:
- واجهة برمجة تطبيقات العرض منخفضة الكود
- تحويل عرض تقديمي
- دمج عروض تقديمية
- التنقل عبر الشرائح
- التنقل عبر الأشكال
- التنقل عبر النص
- جمع الأشكال
- ضغط العرض التقديمي
- إزالة القوالب غير المستخدمة
- إزالة التخطيطات غير المستخدمة
- ضغط الخطوط المضمَّنة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخدم واجهة برمجة التطبيقات منخفضة الكود لـ Aspose.Slides في بايثون عبر جافا لتحويل ودمج العروض التقديمية، والتنقل عبر المحتوى، وجمع الأشكال، وتقليل حجم العرض التقديمي."
---
## **نظرة عامة**

توفر واجهة برمجة التطبيقات [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/ar/python-java/aspose.slides/) فئات مساعد ثابتة للعمليات الشائعة على العروض التقديمية. تُغلف هذه المساعدات تدفقات نموذج الكائنات المستخدمة بشكل متكرر في طرق مركزة، بحيث يمكنك تحويل أو دمج الملفات، معالجة عناصر العرض، جمع الأشكال، وإزالة المحتوى غير المستخدم بكتابة أقل.

المساعدات منخفضة الشيفرة تكون مفيدة عندما ينطبق العملية على ملف أو عرض تقديمي كامل وتطابق سير العمل الافتراضي متطلباتك. استخدم نموذج الكائنات الكامل لـ [Aspose.Slides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/) عندما تحتاج إلى تحكم دقيق في الشرائح الفردية أو القوالب أو التخطيطات أو الأشكال أو إعدادات التصدير أو العلاقات بين عناصر العرض.

الجدول التالي يوضح المساعدات المتاحة:

| المساعد | استخدامه لـ |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/ar/python-java/aspose.slides/convert/) | تحويل عرض تقديمي إلى صيغة أخرى عبر استدعاء مباشر من ملف إلى ملف. |
| [Merger](https://reference.aspose.com/slides/ar/python-java/aspose.slides/merger/) | دمج ملفات عرض تقديمي كاملة بنفس الصيغة. |
| [ForEach](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/) | تنفيذ إجراء لكل شريحة أو شكل أو فقرة أو جزء نصي. |
| [Collect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/collect/) | استرداد الأشكال من العرض التقديمي بالكامل للمعالجة المتكررة أو التحليل. |
| [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/) | إزالة القوالب والتخطيطات غير المستخدمة وتقليل بيانات الخطوط المضمَّنة. |

## **تحويل عرض تقديمي**

استخدم [Convert.autoByExtension](https://reference.aspose.com/slides/ar/python-java/aspose.slides/convert/#autoByExtension) عندما يكون امتداد ملف الإخراج كافياً لاختيار صيغة التصدير. تقوم الطريقة بفتح العرض التقديمي المصدر، تحديد الصيغة المطلوبة من مسار الإخراج، وكتابة النتيجة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

توفر فئة [Convert](https://reference.aspose.com/slides/ar/python-java/aspose.slides/convert/) أيضاً طرقاً مخصصة لإخراج PDF وSVG وJPEG وPNG وTIFF. استخدم نموذج الكائنات الكامل عندما تحتاج إلى فحص أو تعديل العرض قبل التصدير أو تكوين خيار تصدير غير متاح عبر المساعد المحدد. راجع [Convert Presentation](/slides/ar/python-java/convert-presentation/) للحصول على سير عمل وخيارات خاصة بكل صيغة.

## **دمج العروض التقديمية**

استخدم [Merger.process](https://reference.aspose.com/slides/ar/python-java/aspose.slides/merger/#process) لدمج ملفات عرض تقديمي كاملة باستدعاء واحد. يجب أن تكون العروض المدخلة بنفس صيغة الملف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

المساعد مناسب عندما يجب إلحاق جميع الشرائح إلى نتيجة واحدة دون اختيار أو إعادة تعيين كل شريحة على حدة. استخدم نموذج الكائنات الكامل عندما تحتاج إلى دمج شرائح مختارة، تطبيق قالب أو تخطيط هدف، الحفاظ على الأقسام صراحةً، أو توحيد أحجام الشرائح المختلفة. راجع [Merge Presentations](/slides/ar/python-java/merge-presentation/) لهذه السيناريوهات.

## **التنقل عبر عناصر العرض التقديمي**

تستدعي فئة [ForEach](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/) رد نداء لكل نوع مطلوب من عناصر العرض. إنها تُجنب حلقات التجميع المتداخلة وتكون مريحة للتفحص أو تغييرات التنسيق على مستوى العرض بأكمله.

المثال التالي يستخدم [ForEach.slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#slide)، [ForEach.shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#paragraph) و[ForEach.portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#portion) لتفحص العناصر المقابلة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

بشكل افتراضي، يتضمن استعراض الأشكال والنص على مستوى العرض الشرائح العادية والقوالب والتخطيطات. يمكن للتحميلات التي تتضمن معامل `includeNotes` أيضاً معالجة شرائح الملاحظات. استخدم حلقات التجميع المباشرة عندما يكون ترتيب الاستعراض أو الخروج المبكر أو الترشيح قبل استدعاء رد النداء أو التحكم التفصيلي بين الأب والابن أمرًا مهمًا.

## **جمع الأشكال**

استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/collect/#shapes) عندما تحتاج إلى مجموعة من جميع الأشكال في عرض تقديمي بدلاً من رد نداء لكل شكل. هذا مفيد عندما سيتم تصفية المجموعة نفسها أو عدها أو معالجتها أكثر من مرة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#shape) بدلاً من ذلك عندما يمكن معالجة كل شكل فوراً ولا تحتاج إلى الاحتفاظ بالنتيجة المجمعة.

## **ضغط محتوى العرض التقديمي**

يمكن لفئة [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/) إزالة العناصر الهيكلية غير المستخدمة وتقليل بيانات الخطوط المضمَّنة:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) يزيل شرائح التخطيط التي لا تشير إليها أي شريحة عادية.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedMasterSlides) يزيل القوالب التي لم تعد مستخدمة.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#compressEmbeddedFonts) يزيل الأحرف غير المستخدمة من الخطوط المضمَّنة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

أزل التخطيطات غير المستخدمة قبل القوالب غير المستخدمة بحيث يمكن إزالة القالب الذي يصبح غير مرجع بعد تنظيف التخطيطات. احفظ العرض المُحسّن إلى ملف جديد إذا قد تحتاج القوالب أو التخطيطات الأصلية أو بيانات الخط المضمَّن الكاملة لاحقًا. لمزيد من التفاصيل، راجع [Slide Master](/slides/ar/python-java/slide-master/) و[Embedded Font](/slides/ar/python-java/embedded-font/).

## **الأسئلة المتكررة**

**متى يجب استخدام واجهة برمجة التطبيقات منخفضة الشيفرة بدلاً من نموذج الكائنات الكامل؟**

استخدم المساعدات منخفضة الشيفرة عندما تنطبق عملية قياسية على ملف أو عرض تقديمي كامل ولا تتطلب تحكمًا تفصيليًا في العناصر الفردية. استخدم نموذج الكائنات الكامل عندما تحتاج إلى اختيار شرائح محددة، التحكم في علاقات القوالب والتخطيطات، فحص الحالة الوسيطة، أو تكوين سلوك لا ي expose المساعد.

**هل يمكن لـ Merger دمج عروض تقديمية بصيغ ملفات مختلفة؟**

لا. يتطلب [Merger.process](https://reference.aspose.com/slides/ar/python-java/aspose.slides/merger/#process) أن تكون العروض المدخلة بنفس الصيغة. حوّل الملفات المدخلة إلى صيغة موحدة أولاً، على سبيل المثال باستخدام [Convert.autoByExtension](https://reference.aspose.com/slides/ar/python-java/aspose.slides/convert/#autoByExtension)، ثم دمج الملفات المحوَّلة.

**هل يعالج ForEach القوالب والتخطيطات وشرائح الملاحظات؟**

[ForEach.slide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#slide) يتنقل عبر الشرائح العادية للعرض. تشمل عمليات [ForEach.shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#shape)، [ForEach.paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#paragraph) و[ForEach.portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#portion) القوالب والتخطيطات افتراضيًا. استخدم التحميلات التي تحتوي على `includeNotes` مضبوطة على `True` لتضمين شرائح الملاحظات.

**ما الفرق بين ForEach.shape و Collect.shapes؟**

استخدم [ForEach.shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/#shape) لمعالجة كل شكل فورًا عبر رد نداء. استخدم [Collect.shapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/collect/#shapes) عندما تحتاج إلى نتيجة قابلة للتكرار يمكن الاحتفاظ بها، تصفيتها، عدّها أو تنقُّل خلالها متعددة المرات.

**هل يجعل Compress دائمًا ملف العرض أصغر؟**

ليس بالضرورة. النتيجة تعتمد على ما إذا كان العرض يحتوي على تخطيطات غير مستخدمة أو قوالب غير مستخدمة أو خطوط مضمَّنة بأحرف غير مستخدمة. إذا لم يكن أي من هذه العناصر موجودًا، قد لا تقلل عمليات [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/) حجم الملف.

**هل تُحفظ التغييرات التي تُجريها ForEach أو Compress تلقائيًا؟**

لا. تعمل هذه المساعدات على كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) المحمَّل في الذاكرة. بعد تعديل العناصر في رد نداء [ForEach](https://reference.aspose.com/slides/ar/python-java/aspose.slides/foreach/) أو تشغيل [Compress](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/)، استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة النتيجة.

## **مقالات ذات صلة**

- [Convert Presentation](/slides/ar/python-java/convert-presentation/)
- [Merge Presentations](/slides/ar/python-java/merge-presentation/)
- [Slide Master](/slides/ar/python-java/slide-master/)
- [Manage Text Box](/slides/ar/python-java/manage-textbox/)
- [Embedded Font](/slides/ar/python-java/embedded-font/)