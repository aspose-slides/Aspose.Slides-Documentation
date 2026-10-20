---
title: تغيير حجم الأشكال في شرائح العرض التقديمي باستخدام بايثون
type: docs
weight: 130
url: /ar/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/تغيير-حجم-الأشكال-في-الشريحة/
  - /ar/python-net/re-sizing-shapes-on-slide/
keywords:
- تغيير حجم الشكل
- تعديل حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "قم بتغيير حجم الأشكال بسهولة في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET - أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تعديل حجم الأشكال وإعادة موضعها لتناسب الأبعاد الجديدة. توضح هذه المقالة كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح والماستر والتخطيطات.

## **تغيير حجم الأشكال**

لحفظ الموضع النسبي لكل شكل وحجمه، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبّق النسبة المقابلة للارتفاع على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرضًا تقديميًا لا تحتوي شرائحه على جداول، يغيّر حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) مع [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) بحيث يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدة؛ مواضع الأشكال وأبعادها تُقاس بالنقاط. يمكن أن تُشوّه النسب المختلفة للعرض والارتفاع الأشكال، ولا يؤدي تغيير أبعاد الشكل إلى تحجيم حجم الخطوط.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # احسب عوامل التحجيم الأفقية والعمودية المستقلة.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: قم بتحجيم عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد يبقى ارتفاع الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال على الماستر والتخطيطات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي بعد تعديل حجمه. يساعده في التعامل مع كل [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) عن طريق تحجيم [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) و[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). ثم يحجّم موضع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # أبعاد الجدول يتم التحكم بها عبر عرض الأعمدة وارتفاع الصفوف.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # احسب عوامل التحجيم الأفقية والعمودية المستقلة.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # غير حجم الأشكال المعرفة على الماستر والتخطيطات وكذلك الشرائح الفردية.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقتطع بعد تعديل حجم الشريحة؟**  
إذا غيرت حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواضعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضاً.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**  
المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تحقق من تخطيط النتيجة، خاصة النصوص والجداول، لأن هذه الأمثلة لا تحجّم أحجام الخطوط وقد تقيد محتويات الجدول ارتفاعات الصفوف.

**كيف يمكن تعديل حجم الجداول عند تعديل حجم الشريحة؟**  
قم بتحجيم عرض الأعمدة بنسبة عرض الشريحة الجديدة، وارتفاع الصفوف الأدنى بنسبة ارتفاع الشريحة، ثم حجّم موضع الجدول كما هو موضح في المثال الثاني.

**هل يعمل هذا التحجيم على شرائح الماستر وشرائح التخطيط؟**  
نعم. يت iterates المثال الثاني عبر [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) وكل [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) ويطبق نفس منطق تعديل الحجم على أشكالهما.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع تعديل الحجم؟**  
نعم. اضبط [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، حتى تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد أقصى لحجم الشريحة التي يمكنني تعيينه؟**  
يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). تعتمد الأبعاد المدعومة أيضاً على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع الأشكال ذات النسبة الثابتة من التشوه؟**  
استخدم نفس عامل التحجيم للعرض والارتفاع. لتناسب التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكل من الأبعاد والمواضع. يحافظ ذلك على النسب لكنه قد يترك مساحة غير مستخدمة على أحد الحواف.