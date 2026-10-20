---
title: تحجيم الأشكال في شرائح العرض التقديمي باستخدام بايثون
type: docs
weight: 130
url: /ar/python-net/resizing-shapes-on-slide/
aliases:
  - /ar/python-net/re-sizing-shapes-on-slide/
keywords:
  - تحجيم الشكل
  - تغيير حجم الشكل
  - PowerPoint
  - OpenDocument
  - عرض تقديمي
  - Python
  - Aspose.Slides
description: "قم بسهولة بتحجيم الأشكال في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للغة Python عبر .NET—قم بأتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة وضعها لتتناسب مع الأبعاد الجديدة. توضح هذه المقالة كيفية تحجيم الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح، والرئيسيات، والتصميمات.

## **تغيير حجم الأشكال**

يحمّل المثال الأول عرضًا تقديميًا لا تحتوي شرائحه على جداول، ويغيّر حجم الشريحة إلى A4، ثم يحفظ النتيجة. يستخدم [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) مع [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) حتى يتحكم الحلقة اللاحقة في التحجيم. النسب لا تحمل وحدة؛ يتم قياس مواضع الأشكال وأبعادها بالنقاط. يمكن أن تشوه النسب المختلفة للعرض والارتفاع الأشكال، ولا يؤدي تغيير أبعاد الشكل إلى تحجيم أحجام الخط.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # احسب عوامل التحجيم الأفقي والعمودي المستقلة.
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
تتطلب الجداول معالجة منفصلة: قم بتحجيم عرض الأعمدة وارتفاع الصفوف بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد تظل ارتفاعات الصفوف أكبر من المطلوبة إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الرئيسيات والتصميمات بالإضافة إلى الشرائح الفردية قبل حفظ العرض التقديمي بعد تغيير الحجم. يتعامل المساعد الخاص به مع كل [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) من خلال تحجيم [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) و[Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/). ثم يحجّم موقع الجدول دون تحجيم أبعاده الكلية بشكل منفصل.

```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # أبعاد الجدول يتم التحكم فيها بواسطة عرض الأعمدة وارتفاع الصفوف.
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
    # احسب عوامل التحجيم الأفقي والعمودي المستقلة.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # قم بتحجيم الأشكال المعرفة على الرئيسيات والتصميمات وكذلك الشرائح الفردية.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**لماذا تتشوه الأشكال أو تُقطع بعد تغيير حجم الشريحة؟**

إذا غيرت حجم الشريحة دون تحجيم الأشكال، فإنها تحتفظ بمواضعها وأبعادها الأصلية وقد تمتد خارج الشريحة. يمكن أن يؤدي تحجيم العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**

يُغيّر المثال الأول حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. يتعامل المثال الثاني مع الجداول بشكل منفصل. تحقق من التخطيط الناتج، خاصة النص والجداول، لأن هذه الأمثلة لا تحجّم أحجام الخط ويمكن لمحتوى الجدول أن يقيّد ارتفاعات الصفوف.

**كيف يمكنني تغيير حجم الجداول عند تغيير حجم الشريحة؟**

قم بتحجيم عرض الأعمدة بنسبة العرض وارتفاع الصفوف الدنيا بنسبة الارتفاع، ثم احجّم موقع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على الشرائح الرئيسة وشرائح التصميم؟**

نعم. يتنقل المثال الثاني عبر [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) وكل [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) لكل رئيسية ويطبق نفس منطق تغيير الحجم على أشكالها.

**هل يمكنني تغيير اتجاه الشريحة (عمودي/أفقي) مع التحجيم؟**

نعم. اضبط [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) بعد تغيير حجم الشريحة وقبل قراءة أبعاد الهدف، حتى تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تحديده؟**

يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/). كما أن الأبعاد المدعومة تعتمد على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشويه الأشكال ذات نسبة العرض إلى الارتفاع الثابتة؟**

استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي داخل أبعاد الشريحة الجديدة، استخدم الأصغر بين نسب العرض والارتفاع لكل من الأبعاد والمواضع. يحافظ ذلك على النسب لكن قد يترك مساحة غير مستعملة على أحد الجانبين.