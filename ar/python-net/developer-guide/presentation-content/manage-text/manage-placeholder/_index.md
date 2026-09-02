---
title: "إدارة مكوّنات نائب العرض التقديمي في بايثون"
linktitle: "إدارة المكوّنات النائبة"
type: docs
weight: 10
url: /ar/python-net/manage-placeholder/
keywords:
- مكوّن نائب
- مكوّن نائب نص
- مكوّن نائب صورة
- مكوّن نائب مخطط
- مكوّن نائب محتوى
- نص إرشادي
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية فحص وتعديل مكوّنات نائب النص، الصورة، المخطط، ومكوّنات نائب المحتوى وفهم وراثة المكوّنات النائبة مع Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

المكوّن النائب هو شكل يحتفظ بموقع لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة العناوين، النص الأساسي، الصورة، المخطط، ومكوّنات المحتوى العامة. على عكس الشكل العادي، يمكن للمكوّن النائب أن يرث موقعه وحجمه والتنسيق وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

Aspose.Slides يكشف معلومات المكوّن النائب عبر الخاصية [Shape.placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/placeholder/). تُعيد الخاصية كائن [Placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholder/) أو `None` للشكل العادي. استخدم [Placeholder.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholder/type/) لتحديد ما يُقصد بالمكوّن النائب.

فئة الشكل لا تزال مهمة بعد معرفة نوع المكوّن النائب:

- مكوّن نائب نص، صورة، مخطط أو محتوى فارغ يُمثَّل عادةً بـ [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).
- مكوّن نائب صورة مملوء يمكن تمثيله بـ [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/).
- مكوّن نائب مخطط مملوء يمكن تمثيله بـ [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/).
- مكوّن نائب محتوى يمكن أن يحتوي على عدة أنواع من المحتوى. تحقق من كل من [Placeholder.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholder/type/) وفئة الشكل في وقت التشغيل بدلاً من الافتراض أن كل المكوّنات النائبة هي [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholder/type/) يصف دور المكوّن النائب؛ لكنه لا يضمن فئة الشكل في وقت التشغيل. يجب دائماً إجراء فحص نوع قبل الوصول إلى خصائص النص أو الصورة أو المخطط أو الجدول أو الوسائط.
{{% /alert %}}

## **فهم توريث المكوّن النائب**

المكوّنات النائبة تشكل هرمًا:

1. الشريحة الرئيسية تُعرِّف الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات مكوّنات نائب على مستوى الماستر.
2. شريحة التخطيط تُحدد الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكن أن ترث من الماستر.
3. الشريحة العادية تحتوي على المكوّنات النائبة لتلك الشريحة ويمكن أن ترث من تخطيطها.

استدعِ [Shape.get_base_placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_base_placeholder/) للانتقال بمستوى واحد أعلى في هذا الهرم. عادةً ما تُعيد شريحة النائب مكوّن نائب التخطيط؛ ومكوّن نائب التخطيط يمكن أن يُعيد مكوّن نائب الماستر. تُعيد الطريقة `None` عندما لا يكون للشكل مكوّن نائب أساسي.

المثال التالي يسرد المكوّنات النائبة في الشريحة الأولى ويبلغ عن مكوّناتها النائبة الأساسية:

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

تحرير مكوّن نائب على شريحة عادية يُنشئ أو يُغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الماستر المتعلق يمكن أن يؤثر على جميع الشرائح التي ما زالت ترث ذلك الإعداد. الشكل العادي المحلي لا يمتلك مكوّن نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في مكوّن نائب**

مكوّنات نائب العنوان، العنوان‑المركز، العنوان الثانوي، النص الأساسي، والنص عادةً ما تدعم النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) قبل استخدام خاصية [text_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/text_frame/).

هذا المثال يحدث أول مكوّن نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب معاملة مكوّنات نائب الصورة أو المخطط أو الجدول أو الوسائط ككائنات [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/). كما يحدد المكوّن النائب حسب الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **تعيين نص إرشادي على تخطيط**

نص الإرشاد هو التعليمات المعروضة في مكوّن نائب فارغ أثناء التصميم، مثل *Click to add title*. عين نص إرشادي مخصص على مكوّن نائب التخطيط بدلًا من محاولة الوصول إليه عبر مجموعة الأشكال في شريحة عادية. يمكن الوصول إلى التخطيط عبر [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/) وت iterating على [LayoutSlide.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/shapes/).

المثال التالي يغيّر نصوص الإرشاد للعنوان والعنوان الثانوي على التخطيط المستخدم في الشريحة الأولى:

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

نص الإرشاد ليس محتوى شريحة عادي. إنه مخصص للمكوّنات النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوى حقيقي، لا يُظهر النص الإرشادي بعد ذلك. تغيير الإرشاد لا يستبدل النص الموجود على الشرائح التي تستخدم التخطيط.

## **تحديث مكوّن نائب صورة**

هناك حالتان للتعامل معهما:

- إذا كان مكوّن نائب الصورة مملوءًا بالفعل ومُمثلًا بـ [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/)، استبدل الصورة عبر [PictureFillFormat.picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/picture/) و[Picture.image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/image/).
- إذا كان لا يزال مكوّنًا نائبًا فارغًا، أضف إطار صورة عند إحداثيات المكوّن النائب باستخدام [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/) وأزل المكوّن الفارغ.

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

البديل الذي يُنشأ لمكوّن نائب فارغ هو إطار صورة محلي، وليس مكوّنًا نائبًا جديدًا، لأن [Shape.placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/placeholder/) للقراءة فقط. يحتفظ بالموقع المحجوز لكنه لم يعد يرث سلوك المكوّن النائب. إذا كانت علاقة المكوّن النائب ضرورية، قم بإعداد وتعبئة المكوّن النائب في PowerPoint أولاً، ثم حدث [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

للشفافية في الصورة، الاقتصاص، وتأثيرات الصورة الأخرى، راجع [Manage Picture Frames](/slides/ar/python-net/picture-frame/). هذه العمليات تخص إطار الصورة أو تعبئة الصورة، لا بيانات المكوّن النائب.

## **العمل مع مكوّنات نائب المخطط والمحتوى**

مكوّن نائب مخطط مملوء يمكن تمثيله بـ [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/). هذا المثال يجد مثل هذا المخطط عبر كل من نوع المكوّن النائب وفئة الشكل في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

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

مكوّن نائب محتوى عام عادةً ما يكون له [PlaceholderType.OBJECT](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/). في PowerPoint يعمل كمنطلق لعدة أنواع من المحتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد تعبئته، تحقق من فئة الشكل الفعلية لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تكشف عن [PlaceholderType.CHART](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/)، [PlaceholderType.TABLE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/), أو [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholdertype/).

Aspose.Slides لا يحول مكوّن نائب [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) فارغ إلى [Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/) بمجرد تغيير [Placeholder.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/placeholder/type/); النوع للقراءة فقط. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب عند إحداثيات المكوّن النائب ثم أزل المكوّن الفارغ. المثال التالي يفعل ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة المكوّن النائب لكنه لا يرث من مكوّن نائب التخطيط. استخدم مقالات إدارة المخططات المخصصة [/slides/ar/python-net/powerpoint-charts/] عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث نص أو محتوى صورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن مكوّن نائب للعنوان أو الصورة، يتحقق من نوع المكوّن النائب والشكل، يحدّث المحتوى المناسب، ويحفظ الناتج. يتجنب المثال الافتراض القسري لفهرس الشكل أو معاملة كل مكوّن نائب كفئة شكل واحدة:

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

## **الأسئلة الشائعة**

**ما هو المكوّن النائب الأساسي؟**

المكوّن النائب الأساسي هو الشكل المقابل على التخطيط أو الماستر الذي يرث منه مكوّن نائب آخر. استخدم [Shape.get_base_placeholder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/get_base_placeholder/) لاسترجاعه. الشكل المحلي العادي يُعيد `None` لأنه ليس جزءًا من هرم المكوّنات النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح من خلال تحرير مكوّن نائب التخطيط؟**

يمكنك تغيير التنسيق الوراثي أو نص الإرشاد عبر التخطيط، لكن محتوى العناوين الحالي مخزن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض التقديمي بالكامل، قم بتكرار الشرائح وتحديث كل مكوّن نائب للعنوان.

**كيف أدير مكوّنات نائب التاريخ ورقم الشريحة والرأس وتذييل الصفحة؟**

استخدم مديري الرأس والتذييل في النطاق المناسب (شريحة، تخطيط، ماستر، ملاحظات أو كتيب). راجع [Manage Presentation Header and Footer](/slides/ar/python-net/presentation-header-and-footer/) للحصول على أمثلة كاملة.