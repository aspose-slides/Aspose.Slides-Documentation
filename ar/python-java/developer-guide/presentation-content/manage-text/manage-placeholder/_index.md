---
title: إدارة العناصر النائبة في العروض التقديمية باستخدام Python
linktitle: إدارة العناصر النائبة
type: docs
weight: 10
url: /ar/python-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب للنص
- عنصر نائب للصورة
- عنصر نائب للمخطط
- عنصر نائب للمحتوى
- نص المطالبة
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعرّف على كيفية فحص وتحرير العناصر النائبة للنص، الصورة، المخطط، والمحتوى وفهم وراثة العناصر النائبة باستخدام Aspose.Slides للـ Python عبر Java."
---
## **نظرة عامة**

العنصر النائب هو شكل يحجز موقعًا لنوع معين من المحتوى في نموذج عرض تقديمي. من الأمثلة الشائعة العناوين، النص الرئيسي، الصورة، المخطط، والعناصر النائبة للمحتوى العام. على عكس الشكل العادي، يمكن للعنصر النائب أن يرث موقعه وحجمه وتنسيقه وإعدادات أخرى من شريحة التخطيط أو الشريحة الرئيسة.

Aspose.Slides يُظهر معلومات العنصر النائب عبر طريقة [Shape.getPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getPlaceholder). تُعيد الطريقة كائنًا من نوع [Placeholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/) أو `None` لشكل عادي. استخدم [Placeholder.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/#getType) لتحديد ما يُقصد للعنصر النائب أن يحتويه.

لا يزال نوع الشكل مهمًا بعد معرفة نوع العنصر النائب:

- يُمثل عنصر نائب فارغ للنص أو الصورة أو المخطط أو المحتوى عادةً بواسطة [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).
- يمكن تمثيل عنصر نائب الصورة المملوء بـ [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/).
- يمكن تمثيل عنصر نائب المخطط المملوء بـ [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/).
- يمكن لعناصر النائب للمحتوى أن تحتوي عدة أنواع من المحتوى. تحقق من كل من [Placeholder.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/#getType) ونوع الشكل وقت التنفيذ بدلاً من افتراض أن كل عنصر نائب هو [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/#getType) يصف دور العنصر النائب؛ لكنه لا يضمن نوع الشكل وقت التنفيذ. دائمًا استخدم فحص النوع قبل الوصول إلى النص أو الصورة أو المخطط أو الجدول أو الأعضاء الخاصة بالوسائط.
{{% /alert %}}

## **فهم توريث العنصر النائب**

العناصر النائبة تشكل تسلسلًا هرميًا:

1. الشريحة الرئيسة (master slide) تُعرّف الأنماط القابلة لإعادة الاستخدام، وفي بعض الحالات العناصر النائبة على مستوى الرئيس.
2. شريحة التخطيط (layout slide) تُعرّف الترتيب المستخدم من قبل شريحة أو أكثر عادية ويمكن أن ترث من الرئيس.
3. الشريحة العادية تحتوي على العناصر النائبة لتلك الشريحة ويمكن أن ترث من التخطيط الخاص بها.

استدعِ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) للانتقال مستوى واحد أعلى في هذا التسلسل. عادةً ما تُعيد العنصر النائب للشريحة العنصر النائب لتخطيطها؛ ويمكن لعنصر نائب التخطيط أن يُعيد العنصر النائب للرئيس. تُعيد الطريقة `None` عندما لا يملك الشكل عنصرًا نائبًا أساسيًا.

المثال التالي يُدرج العناصر النائبة في الشريحة الأولى ويُبلغ عن عناصرها النائبة الأساسية:

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

تعديل عنصر نائب في شريحة عادية يخلق أو يغيّر تجاوزًا محليًا لتلك الشريحة. تعديل التخطيط أو الرئيس المرتبط يمكن أن يؤثر على جميع الشرائح التي لا تزال ترث هذا الإعداد. الشكل العادي المحلي لا يملك عنصرًا نائبًا أساسيًا ولا يبدأ بالوراثة لمجرد أنه يشغل نفس الإحداثيات.

## **تغيير النص في العنصر النائب**

العناوين، العنوان المركزي، العنوان الفرعي، النص الرئيسي، والعناصر النائبة للنص عادةً ما تدعم النص. تحقق من وجود [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) قبل استخدام طريقة [getTextFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/#getTextFrame).

هذا المثال يحدث أول عنصر نائب للعنوان في الشريحة الأولى ويحفظ النتيجة:

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

هذا النمط يتجنب التعامل مع الصور أو المخططات أو الجداول أو وسائط الإعلام كـ [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/). كما يحدد العنصر النائب بناءً على الغرض بدلاً من الاعتماد على فهرس الشكل الهش.

## **ضبط نص المطالبة على التخطيط**

نص المُطالبة هو التعليمات التي تُعرض في عنصر نائب فارغ أثناء التصميم، مثل *Click to add title*. اضبط نص مُطالبة مخصص على عنصر النائب في التخطيط بدلاً من محاولة الوصول إليه عبر مجموعة أشكال الشريحة العادية. للوصول إلى التخطيط استخدم [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getLayoutSlide) وتكرَّر على المجموعة التي تُعيدها [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getShapes).

المثال التالي يغيّر نصوص العنوان والعنوان الفرعي في التخطيط المستخدم من قبل الشريحة الأولى:

```python
import jpime
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

نص المُطالبة ليس محتوى شريحة عادي. إنه مخصص للعناصر النائبة الفارغة في تطبيقات التحرير مثل PowerPoint. بمجرد أن يضيف المستخدم أو البرنامج محتوىً حقيقيًا، لا يعود نص المُطالبة معروضًا. كذلك تعديل نص المُطالبة لا يستبدل النص الموجود على الشرائح التي تستخدم هذا التخطيط.

## **تحديث العنصر النائب للصورة**

هناك حالتان يجب معالجتهما:

- إذا كان عنصر نائب الصورة مُملوءًا بالفعل ومُمثَّلًا بـ [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/)، استبدل الصورة عبر [PictureFillFormat.getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture) و[Picture.setImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#setImage).
- إذا كان لا يزال عنصرًا نائبًا فارغًا، أضف إطار صورة في إحداثيات العنصر النائب باستخدام [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame) وأزل العنصر النائب الفارغ.

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

الاستبدال المُنشأ لعناصر نائب فارغة هو إطار صورة محلي، وليس عنصرًا نائبًا جديدًا، لأن [Shape.getPlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getPlaceholder) لا يوفر طريقة ضبط. يظل يحتفظ بالموقع المحجوز لكنه لا يرث سلوك العنصر النائب بعد الآن. إذا كان الحفاظ على علاقة العنصر النائب أمرًا أساسيًا، حضّر وامِلء العنصر النائب في PowerPoint أولًا، ثم حدّث [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) الناتج باستخدام Aspose.Slides.

للتعامل مع شفافية الصورة، القص، وغيرها من التأثيرات الخاصة بالصور، راجع [Manage Picture Frames](/slides/ar/python-java/picture-frame/). هذه العمليات تنتمي إلى إطار الصورة أو ملء الصورة، وليس إلى بيانات العنصر النائب.

## **العمل مع العناصر النائبة للرسوم البيانية والمحتوى**

عنصر نائب المخطط المملوء يمكن تمثيله بـ [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/). هذا المثال يجد مثل هذا المخطط بحسب نوع العنصر النائب ونوع الشكل وقت التنفيذ، يغيّر عنوانه، ويحفظ الملف:

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

عادةً ما يكون للعنصر النائب العام للمحتوى النوع [PlaceholderType.Object](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Object). في PowerPoint يعمل كمنطلق لعدة أنواع من المحتوى، بما في ذلك المخططات والجداول والرسوم التخطيطية والصور والوسائط. بعد ملئه، تحقق من نوع الشكل الفعلي لمعرفة ما يحتويه. يمكن للتخطيطات المتخصصة أيضًا أن تُظهر [PlaceholderType.Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Media)، أو [PlaceholderType.Diagram](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides لا يحول عنصر نائب فارغ من نوع [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) إلى [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/) بمجرد تغيير [Placeholder.getType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/placeholder/#getType)؛ لا يمكن تغيير النوع عبر الواجهة البرمجية. لملء مخطط فارغ أو مساحة محتوى برمجيًا، أضف الكائن المطلوب عند إحداثيات العنصر النائب ثم أزل العنصر النائب الفارغ. المثال التالي يفعل ذلك لمخطط:

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

المخطط المضاف هو مخطط محلي عادي. يشغل مساحة العنصر النائب لكنه لا يرث من عنصر نائب التخطيط. استخدم المقالات المتخصصة في إدارة المخططات [/slides/ar/python-java/powerpoint-charts/] عندما تحتاج إلى استبدال الفئات أو السلاسل أو بيانات المصنف.

## **مثال كامل: تحديث النص أو محتوى الصورة**

المثال التالي من البداية إلى النهاية يفتح قالبًا، يبحث في الشريحة الأولى عن عنصر نائب للعنوان أو الصورة، يفحص نوع العنصر النائب والنوع الفعلي للشكل، يُحدّث المحتوى المناسب، ويحفظ النتيجة. يتجنب المثال الافتراض بأن فهرس الشكل ثابت أو التعامل مع كل عنصر نائب كنوع واحد:

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

العنصر النائب الأساسي هو الشكل المقابل على التخطيط أو الرئيس الذي يرث منه عنصر نائب آخر. استخدم [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getBasePlaceholder) لاسترجاعه. الشكل المحلي العادي يُعيد `None` لأنه ليس جزءًا من تسلسل العناصر النائبة.

**هل يمكنني تغيير جميع عناوين الشرائح عن طريق تعديل عنصر نائب في التخطيط؟**

يمكنك تغيير التنسيق الموروث أو نص المُطالبة عبر التخطيط، لكن محتوى العناوين الموجود يُخزن على الشرائح العادية. لاستبدال نص العنوان الفعلي عبر العرض بالكامل، يجب تكرار الشرائح وتحديث كل عنصر نائب للعنوان.

**كيف أدير عناصر نائب التاريخ، رقم الشريحة، الرأس، وتذييل الصفحة؟**

استخدم مديري الرأس والتذييل في النطاق المناسب (شريحة، تخطيط، رئيس، ملاحظات أو نسخة مطبوعة). راجع [Manage Presentation Header and Footer](/slides/ar/python-java/presentation-header-and-footer/) للحصول على أمثلة كاملة.