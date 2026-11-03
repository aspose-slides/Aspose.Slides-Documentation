---
title: إدارة عناصر النائب في العروض التقديمية بايثون
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/python-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- عنصر نائب محتوى
- نص مطالبة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية فحص وتحرير عناصر النائب النصية، والصور، والمخططات، والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للبايثون عبر جافا."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موضعًا لنوع معين من المحتوى في قالب عرض تقديمي. من الأمثلة الشائعة: العنوان، النص الأساسي، الصورة، المخطط، وعناصر النائب العامة للأغراض. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موضعه وحجمه وتنسيقه وإعدادات أخرى من شريحة تخطيط أو شريحة رئيسية.

تُظهر مكتبة Aspose.Slides معلومات العنصر النائب عبر الطريقة [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). تُعيد الطريقة كائن [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) أو `None` لشكل عادي. استخدم [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) لتحديد ما يُقصد بالعنصر النائب.

لا يزال نوع الشكل مهمًا بعد معرفة نوع العنصر النائب:

- عنصر نائب فارغ للنص أو الصورة أو المخطط أو المحتوى يُمثَّل عادةً بواسطة [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- عنصر نائب صورة ممتلئ يمكن تمثيله بواسطة [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- عنصر نائب مخطط ممتلئ يمكن تمثيله بواسطة [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- عنصر نائب محتوى يمكن أن يحتوي على عدة أنواع من المحتوى. تحقق من كلٍ من [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) ونوع الشكل في وقت التشغيل بدلاً من افتراض أن كل عنصر نائب هو [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="تحذير" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل في وقت التشغيل. احرص دائمًا على إجراء فحص للنوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو أعضاء الوسائط.
{{% /alert %}}

## **فهم وراثة العنصر النائب**

تشكل العناصر النائبة تسلسلًا هرميًا:

1. تحدد الشريحة الرئيسية الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات، عناصر نائبة على مستوى الرئيس.
2. تحدد شريحة التخطيط الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكن أن ترث من الرئيس.
3. تحتوي الشريحة العادية على العناصر النائبة لتلك الشريحة ويمكن أن ترث من التخطيط الخاص بها.

استدعِ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) للانتقال بمستوى واحد أعلى في هذا التسلسل. العنصر النائب في الشريحة عادةً ما يُعيد العنصر النائب في التخطيط؛ ويمكن للعنصر النائب في التخطيط أن يُعيد العنصر النائب في الرئيس. تُعيد الطريقة `None` عندما لا يحتوي الشكل على عنصر نائب أساسي.

المثال التالي يسرد العناصر النائبة في الشريحة الأولى ويُظهر عناصرها النائبة الأساسية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

تحرير عنصر نائب في شريحة عادية يُنشئ أو يغيّر تجاوزًا محليًا لتلك الشريحة. تحرير التخطيط أو الرئيس المرتبط يمكن أن يؤثر على جميع الشرائح التي لا يزال يُورِثُها هذا الإعداد. الشكل العادي المحلي لا يمتلك عنصر نائب أساسي ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **إزالة حالة العنصر النائب**

عند تعديل قالب، استخدم [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) لإبقاء الكائن الموجود كشكل عادي. تُعيد طريقة [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) `None`، لكن الشكل يظل في مجموعة الشرائح. وعلى النقيض، [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) يحذف الشكل من تلك المجموعة.

المثال التالي يتطلب ملف `template.pptx` يحتوي على شريحة واحدة على الأقل وعنصر نائب نصي غير فارغ في الشريحة الأولى. استخدم عنصر نائب يُرث تنسيقه من التخطيط أو الرئيس لتُظهر تأثير إزالة العلاقة. يتحقق المثال من بقاء الشكل نفسه، ثم يستدعي الطريقة مرة أخرى على الشكل الآن العادي، ويحفظ النتيجة.

{{% alert color="warning" title="تحذير" %}}
إزالة حالة العنصر النائب لا تحافظ تلقائيًا على إعدادات المظهر الموروثة. المثال أدناه يترك تلك الإعدادات بدون تغيير عمدًا، لذا قد يختلف الناتج. الشكل الذي يُوارث موضعه وحجمه بالكامل قد يحصل على إحداثيات وأبعاد صفرية بعد الاستدعاء ويصبح غير مرئي رغم بقائه في المجموعة.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # استدعاء الطريقة على شكل عادي لا يؤثر.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

للعنصر النائب المطابق، تُظهر جميع الفحوصات الثلاثة القيمة `True`. يبقى النص، لكن موضعًا، حجمًا، دورانًا، خطًا، محاذاة الفقرة، هوامش إطار النص، تثبيتًا عموديًا، تعبئةً وخطًا قد تتغير عندما تُزال علاقة العنصر النائب. على سبيل المثال، قد يعود تنسيق العنوان الموروث إلى تنسيق نص عادي. راجع [تخطيط الشريحة](/slides/ar/python-java/slide-layout/) للمزيد عن التخطيطات.

للحفاظ على المظهر المقصود، احجز الموضع، الحجم، والدوران المحسوبين قبل الاستدعاء، وانسخ قيم التنسيق الفعّال المطلوبة إلى متغيّرات منفصلة. احصل على تلك القيم عبر [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)، [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective)، [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective)، [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective)، و[LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). لا تعتمد على الاحتفاظ فقط بكائنات التنسيق الفعّال، لأن قيم تنسيق النص قد تتغيّر بعد إزالة العلاقة. طبّق القيم الملتقطة صراحةً على الشكل العادي بعد ذلك، بما في ذلك عائلة الخط، الحجم، النمط، اللون، إعدادات الفقرة، إعدادات إطار النص، التعبئة والخط المستخدم في القالب.

قد تحتاج أيضًا إلى تعيين هندسة الشكل الموروثة صراحةً عبر [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). بالنسبة لعنصر نائب نصي مستطيل، يعني ذلك تعيين [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle)؛ فاستعادة التعبئة والخط فقط قد لا تستعيد المستطيل المرئي. القوالب التي تحتوي على تأثيرات إضافية أو تنسيقات معقّدة تتطلب معالجة تلك الإعدادات أيضًا.

## **تغيير النص في العنصر النائب**

عادةً ما تدعم العناوين، العناوين المركزية، العناوين الفرعية، النص الأساسي، وعناصر النائب النصية النص. تحقّق من وجود [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

المثال التالي يُحدّث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

هذا النمط يتجنّب معالجة العناصر النائبة للصور أو المخططات أو الجداول أو الوسائط كـ[AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). كما يحدد العنصر النائب حسب الغرض بدلًا من الاعتماد على فهرس الشكل الهش.

## **تعيين نص المطالبة في التخطيط**

نص المطالبة هو التعليمات التي تُظهر في عنصر نائب فارغ أثناء التصميم، مثل *انقر لإضافة عنوان*. عيّن نص مطالبة مخصص في عنصر نائب التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. وصل إلى التخطيط عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) وتجوّل في المجموعة التي تُرجعها [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

المثال التالي يغيّر مطالبة العنوان والعنوان الفرعي في التخطيط المُستخدم من قبل الشريحة الأولى:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نص المطالبة ليس محتوى شريحة عادي. هو مخصص لعناصر نائب فارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوىً حقيقيًا، لا يُظهر النص المطالب به بعد ذلك. تغيير المطالبة لا يبدّل النص الموجود في الشرائح التي تستخدم التخطيط.

## **تحديث عنصر نائب صورة**

هناك حالتان لمعالجتهما:

- إذا كان عنصر نائب الصورة مُعبَّأ بالفعل ومُمثلًا بـ[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/)، استبدل الصورة عبر [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) و[Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة في إحداثيات العنصر النائب باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) واحذف العنصر النائب الفارغ.

المثال التالي يدعم الحالتين ويحفظ العرض التقديمي:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

الاستبدال المُنشأ لعنصر نائب فارغ هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) لا يوفر مُعيّنًا. يحتفظ بالموقع المحجوز لكنه لم يعد يرث سلوك العنصر النائب. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، حضّر العنصر النائب واملأه في PowerPoint أولاً، ثم حدّث الـ[PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

لشفافية الصورة، الاقتصاص، وتأثيرات الصورة الأخرى، راجع [إدارة إطارات الصور](/slides/ar/python-java/picture-frame/). تلك العمليات تنتمي إلى إطار الصورة أو تعبئة الصورة، لا إلى بيانات العنصر النائب.

## **العمل مع عناصر نائب المخطط والمحتوى**

يمكن تمثيل عنصر نائب مخطط مُعبَّأ بـ[Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). يحدد هذا المثال مثل هذا المخطط حسب نوع العنصر النائب ونوع الشكل في وقت التشغيل، يغيّر عنوانه، ويحفظ الملف:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عادةً ما يكون عنصر نائب المحتوى من النوع [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). في PowerPoint يعمل كمنفّذ لعدة أنواع محتوى، بما في ذلك المخططات، الجداول، المخططات البيانية، الصور، والوسائط. بعد تعبئته، افحص نوع الشكل الفعلي لتعرف ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media)، أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

لا تقوم Aspose.Slides بتحويل عنصر نائب [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) فارغ إلى [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) بمجرد تغيير [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType)؛ لا يمكن تغيير النوع عبر الواجهة البرمجية. لملء مخطط أو منطقة محتوى فارغة برمجيًا، أضف الكائن المطلوب في إحداثيات العنصر النائب ثم احذف العنصر النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم مقالات [إدارة المخططات](/slides/ar/python-java/powerpoint-charts/) عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي متكامل يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب عنوان أو صورة، يتحقق من أنواع العنصر النائب والشكل، يحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال افتراض فهرس الشكل أو المعاملة المتساوية لجميع العناصر النائبة.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما هو العنصر النائب الأساسي؟**

العنصر النائب الأساسي هو الشكل المقابل في التخطيط أو الرئيس الذي يرث منه عنصر نائب آخر. استخدم [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) لاسترجاعه. الشكل العادي المحلي يُعيد `None` لأنه ليس جزءًا من تسلسل العنصر النائب.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تحرير عنصر نائب التخطيط؟**

يمكنك تعديل التنسيق الموروث أو نص المطالبة عبر التخطيط، لكن محتوى العنوان الفعلي يُخزن في الشرائح العادية. لاستبدال نص العنوان عبر العرض التقديمي بالكامل، تجوّل الشرائح وقم بتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ، رقم الشريحة، الرأس، والتذييل؟**

استخدم مديرات الرأس والتذييل في نطاق الشريحة، التخطيط، الرئيس، الملاحظات، أو النسخة الموزعة. راجع [إدارة رأس وتذييل العرض التقديمي](/slides/ar/python-java/presentation-header-and-footer/) للأمثلة الكاملة.