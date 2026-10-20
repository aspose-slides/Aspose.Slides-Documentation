---
title: إعادة تحجيم الأشكال على شرائح العرض التقديمي في بايثون عبر جافا
type: docs
weight: 110
url: /ar/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /ar/python-java/re-sizing-shapes-on-slide/
keywords:
- إعادة تحجيم الشكل
- تغيير حجم الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "يمكنك بسهولة إعادة تحجيم الأشكال في شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر جافا — أتمتة تعديل تخطيط الشرائح وزيادة الإنتاجية."
---
## **نظرة عامة**

عند تغيير حجم شريحة العرض التقديمي، قد تحتاج أيضًا إلى تغيير حجم الأشكال وإعادة تموضعها لتناسب الأبعاد الجديدة. يوضح هذا المقال كيفية تكبير الأشكال يدويًا وكيفية التعامل مع الجداول في الشرائح والماستر والتخطيطات.

## **تغيير حجم الأشكال**

للحفاظ على الموضع النسبي وحجم كل شكل، اضرب إحداثياته الأفقية وعرضه في نسبة عرض الشريحة الجديد إلى العرض الأصلي. طبق نسبة الارتفاع المقابلة على إحداثياته العمودية وارتفاعه.

المثال الأول يحمل عرض تقديمي لا تحتوي شرائحه على جداول، يغير حجم الشريحة إلى A4، ويحفظ النتيجة. يستخدم [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) مع [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) بحيث يتحكم الحلقة اللاحقة في التكبير. النسب بدون وحدة؛ يتم قياس مواضع الأشكال وأبعادها بالنقاط. يمكن للنسب المختلفة للعرض والارتفاع أن تشوه الأشكال، وتغيير أبعاد الشكل لا يُكَبّر أحجام الخطوط.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # احسب عوامل القياس الأفقية والعمودية المستقلة.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
تتطلب الجداول معالجة منفصلة: يتم تكبير عرض أعمدتها وارتفاع صفوفها بدلاً من تعيين العرض والارتفاع الكلي للجدول. قد يبقى ارتفاع الصفوف أكبر من المطلوب إذا كان محتوى الخلية يحتاج إلى مساحة أكبر.
{{% /alert %}}

يدعم المثال الثاني الجداول ويعالج الأشكال في الماستر والتخطيطات وكذلك الشرائح الفردية قبل حفظ العرض التقديمي المُعاد تحجيمه. يساعده أداة فرعية تتعامل مع كل [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) عن طريق تكبير عرض الأعمدة باستخدام [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) وارتفاع الصف الأدنى باستخدام [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight). ثم يُكبّر موضع الجدول دون تكبير أبعاده الكلية بصورة منفصلة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # أبعاد الجدول يتم التحكم فيها عبر عرض الأعمدة وارتفاع الصفوف.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # احسب عوامل القياس الأفقية والعمودية المستقلة.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # أعد تحجيم الأشكال المعرفة على الماسترات والتخطيطات وكذلك على الشرائح الفردية.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**لماذا تشوه الأشكال أو تُقَصّ بعد إعادة تحجيم الشريحة؟**  
إذا قمت بتغيير حجم الشريحة دون تكبير الأشكال، فإنها تحتفظ بمواقعها وأبعادها الأصلية وقد تمتد خارج حدود الشريحة. يمكن أن يؤدي تكبير العرض والارتفاع بنسب مختلفة إلى تشويه الأشكال أيضًا.

**هل يعمل الكود المقدم مع جميع أنواع الأشكال؟**  
المثال الأول يغيّر حدود الشكل مباشرةً ويُقصد به الشرائح التي لا تحتوي على جداول. المثال الثاني يتعامل مع الجداول بشكل منفصل. تأكد من فحص التخطيط الناتج، خصوصًا النصوص والجداول، لأن هذه الأمثلة لا تُكبّر أحجام الخطوط ويمكن لمحتوى الجدول أن يحد من ارتفاع الصفوف.

**كيف أقوم بتغيير حجم الجداول عند إعادة تحجيم الشريحة؟**  
قم بتكبير عرض الأعمدة بنسبة عرض الشريحة الجديدة، وارتفاع الصف الأدنى بنسبة ارتفاع الشريحة، ثم قم بتكبير موضع الجدول، كما هو موضح في المثال الثاني.

**هل سيعمل هذا التحجيم على الشرائح الماستر وشرائح التخطيط؟**  
نعم. المثال الثاني يتنقل عبر [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) وعلى كل ماستر [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) ويطبق نفس منطق التحجيم على أشكالهم.

**هل يمكنني تغيير اتجاه الشريحة (رأسية/أفقية) مع التحجيم؟**  
نعم. استدعِ [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) بعد تغيير حجم الشريحة وقبل قراءة الأبعاد المستهدفة، بحيث تعكس عوامل التحجيم الاتجاه النهائي.

**هل هناك حد لحجم الشريحة الذي يمكنني تعيينه؟**  
يمكنك تحديد أبعاد شريحة مخصصة باستخدام [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize). تعتمد الأبعاد المدعومة أيضًا على تنسيق العرض التقديمي والتطبيق المستخدم لفتح الملف.

**كيف يمكنني منع تشويه الأشكال ذات نسبة العرض إلى الارتفاع ثابتة؟**  
استخدم نفس عامل التحجيم للعرض والارتفاع. لتلائم التخطيط الأصلي ضمن أبعاد الشريحة الجديدة، استخدم أصغر نسبة بين عرض وارتفاع الشريحة لكلا البعدين والمواضع. يحافظ ذلك على النسب ولكن قد يترك مساحة غير مستخدمة على أحد الجوانب.