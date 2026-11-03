---
title: إدارة العناصر النائبة في العروض التقديمية باستخدام Python
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/python-net/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية فحص وتحرير عناصر النائب النصية، والصورية، والمخططة، ومحتوى، وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للغة Python عبر .NET."
---
## **نظرة عامة**

العنصر النائب هو شكل يحتجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. الأمثلة الشائعة هي العنوان، النص الأساسي، الصورة، المخطط، والعناصر النائبة العامة للمحتوى. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة التخطيط أو الشريحة الرئيسية.

Aspose.Slides تُظهر معلومات العنصر النائب من خلال خاصية [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). تُعيد الخاصية كائنًا من نوع [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) أو `None` لشكل عادي. استخدم [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) لتحديد ما يُقصد أن يحتويه العنصر النائب.

لا يزال فئة الشكل مهمة بعد معرفة نوع العنصر النائب:

- عادةً ما يُمثَّل العنصر النائب الفارغ للنص أو الصورة أو المخطط أو المحتوى بواسطة [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- يمكن تمثيل العنصر النائب المملوء للصورة بواسطة [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- يمكن تمثيل العنصر النائب المملوء للمخطط بواسطة [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- يمكن للعنصر النائب للمحتوى أن يحتوي على عدة أنواع من المحتوى. تحقق من كل من [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) وفئة الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) يصف دور العنصر النائب؛ لكنه لا يضمن فئة الشكل في وقت التشغيل. استخدم دائمًا فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

العناصر النائبة تُشكِّل هرمية:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات العناصر النائبة على مستوى الرئيسي.
2. تحدد شريحة التخطيط الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكنها أن ترث من الرئيسي.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكنها أن ترث من تخطيطها.

استدعِ [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) للانتقال مستوى واحد أعلى في هذه الهرمية. عادةً ما تُعيد العنصر النائب للشريحة عنصره النائب في التخطيط؛ ويمكن لعنصر النائب في التخطيط أن يُعيد عنصره النائب الرئيسي. تُعيد الطريقة `None` عندما لا يكون للشكل عنصر نائب أساسي.

المثال التالي يُسرد العناصر النائبة في الشريحة الأولى ويُبلغ عن عناصرها النائبة الأساسية:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

تحرير عنصر نائب في شريحة عادية ينشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيسي المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. لا يمتلك الشكل العادي المحلي عنصرًا نائبًا أساسيًا ولا يبدأ في الوراثة لمجرد أنه يش Occupy نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) للحفاظ على كائن موجود كشكل عادي. تصبح خاصية [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) الخاصة به `None`، لكن الشكل يبقى في مجموعة الشرائح. بالمقابل، يحذف [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) الشكل من تلك المجموعة.

المثال التالي يتطلب ملف `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نص غير فارغ في الشريحة الأولى. استخدم عنصرًا نائبًا مع تنسيق موروث من تخطيطه أو رئيسه لتلاحظ تأثير إزالة تلك العلاقة. يتحقق المثال من بقاء الشكل نفسه، يستدعي الطريقة مرة أخرى على الشكل الآن العادي، ويحفظ النتيجة.

{{% alert color="warning" title="Warning" %}}
إزالة حالة العنصر النائب لا يحافظ تلقائيًا على إعدادات المظهر الموروثة. المثال أدناه يترك هذه الإعدادات دون تغيير عمدًا، لذا قد يبدو المخرج مختلفًا. يمكن أن يصبح الشكل الذي يتم وراثة موضعه وحجمه بالكامل صفرًا في الإحداثيات والأبعاد بعد الاستدعاء ويصبح غير مرئي رغم بقاءه في المجموعة.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # استدعاء الطريقة على شكل عادي لا يؤثر.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

بالنسبة إلى عنصر نائب مطابق، تُطبع جميع الفحوصات الثلاثة `True`. يبقى النص، لكن موضع الحجم والدوران والخط ومحاذاة الفقرة وهوامش إطار النص والتثبيت العمودي والتعبئة وإعدادات الخط قد تتغير عندما تُزال علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق النص العادي. انظر [Slide Layout](/slides/ar/python-net/slide-layout/) لمزيد من المعلومات حول التخطيطات.

لحفظ المظهر المقصود، التقط الموضع والحجم والدوران المحسوبين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيرات منفصلة. استرجع تلك القيم عبر [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), و[LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). لا تعتمد على الاحتفاظ فقط بكائنات التنسيق الفعّال، لأن قيم تنسيق النص الخاصة بها قد تتغير بعد إزالة العلاقة. طبّق القيم الملتقطة صراحةً على الشكل العادي لاحقًا، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة، والخط المستخدم في القالب الخاص بك.

قد تحتاج هندسة الشكل الموروثة أيضًا إلى تعيين صريح عبر [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). بالنسبة لعنصر نائب نص مستطيل، يعني ذلك تعيين [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); قد لا يعيد استعادة التعبئة والخط فقط الشكل المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيقات أكثر تعقيدًا تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في عنصر نائب**

عادةً ما تدعم عناصر النائب للعنوان، العنوان المركزي، العنوان الفرعي, النص الأساسي, وعناصر النائب النصية النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) قبل استخدام خاصية [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

هذا المثال يحدّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

هذا النمط يتجنب معالجة عناصر النائب للصورة أو المخطط أو الجدول أو الوسائط ككائنات [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). كما يحدد العنصر النائب وفقًا للغرض بدلاً من الاعتماد على فهرس شكل هش.

## **تعيين نص التلميح في التخطيط**

نص التلميح هو التعليمات التي تظهر أثناء التصميم في عنصر نائب فارغ، مثل *انقر لإضافة عنوان*. عيّن نص تلميح مخصص على عنصر النائب في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. يمكن الوصول إلى التخطيط عبر [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) وتكرار عبر [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

المثال التالي يغيّر تلميحات العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

نص التلميح ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يزود المستخدم أو البرنامج محتوىً حقيقيًا، لا يُظهر التلميح بعد ذلك. تغيير التلميح لا يستبدل أيضًا النص الموجود على الشرائح التي تستخدم هذا التخطيط.

## **تحديث عنصر نائب صورة**

هناك حالتان للتعامل معهما:

- إذا كان عنصر النائب للصورة مملوءًا بالفعل ومُمثَّلًا بـ [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), استبدل الصورة عبر [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) و[Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- إذا كان لا يزال عنصر نائب فارغًا, أضف إطار صورة عند إحداثيات العنصر النائب باستخدام [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) وأزل العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

الاستبدال الذي يُنشأ لعناصر النائب الفارغة هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا, لأن خاصية [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) للقراءة فقط. يحتفظ بالموضع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، فاحضر واملا العنصر النائب في PowerPoint أولاً, ثم حدّث [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

للشفافية الصورة، القص, وغيرها من التأثيرات الخاصة بالصورة, راجع [Manage Picture Frames](/slides/ar/python-net/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة, لا إلى بيانات العنصر النائب.

## **العمل مع مخططات وعناصر نائب المحتوى**

يمكن تمثيل عنصر نائب مخطط مملوء بواسطة [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). يجد هذا المثال مثل هذا المخطط عبر كل من نوع العنصر النائب وفئة التنفيذ, يغيّر عنوانه, ويحفظ الملف:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

عادةً ما يكون للعنصر النائب العام للمحتوى قيمة [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع من المحتوى, بما في ذلك المخططات والجدول والرسوم البيانية والصور والوسائط. بعد ملئه, افحص فئة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), أو [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

لا تقوم Aspose.Slides بتحويل عنصر نائب [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) فارغ إلى [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) فقط عن طريق تغيير [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/); النوع للقراءة فقط. لملء مخطط فارغ أو منطقة محتوى برمجيًا, أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر النائب في التخطيط. استخدم [chart management articles](/slides/ar/python-net/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات دفتر العمل.

## **مثال كامل: تحديث محتوى النص أو الصورة**

المثال الكامل التالي يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة, يتحقق من نوعي العنصر النائب والشكل, يحدّث المحتوى المناسب, ويحفظ الناتج. يتجنب المثال عمدًا افتراض فهرس شكل أو معاملة كل عنصر نائب كفئة شكل واحدة:

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العناصر النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيسي الذي يَرث منه عنصر نائب آخر. استخدم [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) لاسترجاعه. يعيد الشكل العادي المحلي `None` لأنه ليس جزءًا من هرمية العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص التلميح عبر التخطيط, لكن محتوى العنوان الحالي يُخزن في الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض التقديمي كله, كرر عبر الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف يمكنني إدارة عناصر النائب للتاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديري الرأس والتذييل في نطاق الشريحة أو التخطيط أو الرئيسي أو الملاحظات أو النشرات المناسب. راجع [Manage Presentation Header and Footer](/slides/ar/python-net/presentation-header-and-footer/) للحصول على أمثلة كاملة.