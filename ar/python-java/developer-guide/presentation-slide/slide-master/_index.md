---
title: إدارة ماسترات شرائح العرض التقديمي في Python عبر Java
linktitle: ماستر الشريحة
type: docs
weight: 70
url: /ar/python-java/slide-master/
keywords:
- ماستر الشريحة
- ماستر شريحة
- ماستر شريحة PPT
- ماسترات شرائح متعددة
- مقارنة ماسترات الشرائح
- خلفية
- عنصر نائب
- استنساخ ماستر شريحة
- نسخة ماستر شريحة
- تكرار ماستر شريحة
- ماستر شريحة غير مستخدم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة ماسترات الشرائح في Aspose.Slides لـ Python عبر Java: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة ماسترات الشرائح في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يحدد **ماستر الشريحة** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نصية، إعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل ماستر الشريحة هو الطريقة المعتادة للحفاظ على تماسك العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

تدعم Aspose.Slides for Python via Java النموذج نفسه. يمكن للعرض التقديمي أن يحتوي على شريحة ماستر واحدة أو أكثر، ويمكن لكل ماستر شريحة أن يحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى ماستر شريحة مباشرة. بل تستخدم الشريحة العادية شريحة تخطيط، وتكون تلك الشريحة التخطيطية تابعة لماستر شريحة.

التسلسل الهرمي هو:

1. **ماستر الشريحة** - يحدد التصميم والسمة المشتركة.
1. **شريحة التخطيط** - تحدد ترتيب معين للعناصر النائبة وتنسيق مستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل ماسترات الشرائح، شرائح التخطيط، والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، يتم تمثيل ماستر الشريحة بواسطة الصنف [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/). جميع ماسترات الشرائح في عرض تقديمي متاحة عبر مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters)، والتي تمثلها [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، المستوى الأكثر تحديدًا هو المهيمن. على سبيل المثال، إذا عرّف ماستر شريحة وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [تطبيق أو تغيير تخطيطات الشريحة](/slides/ar/python-java/slide-layout/).
{{% /alert %}}

## **الوصول إلى ماسترات الشرائح**

في PowerPoint، يمكنك فتح عرض ماستر الشريحة من **View** > **Slide Master**.

![أمر ماستر الشريحة في علامة تبويب العرض في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters) للوصول إلى ماسترات الشرائح:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    master_slide_count = presentation.getMasters().size()
    first_master_layout_slide_count = first_master_slide.getLayoutSlides().size()

    print(f"Master slides: {master_slide_count}")
    print(f"Layouts in the first master: {first_master_layout_slide_count}")
finally:
    presentation.dispose()
```

يمكنك أيضًا الحصول على ماستر الشريحة المستخدمة بواسطة شريحة عادية عبر تخطيطها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    layout_slide = slide.getLayoutSlide()
    master_slide = layout_slide.getMasterSlide()
    master_slide_name = master_slide.getName()

    print(master_slide_name)
finally:
    presentation.dispose()
```

## **ما يحتويه ماستر الشريحة**

ماستر الشريحة هو كائن يشبه الشريحة. يرث من [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/)، لذا يوفّر العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. تُدرج الأعضاء الخاصة بالماستر في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/).

الأعضاء الشائعة الاستخدام في ماستر الشريحة تشمل:

| العضو | الغرض |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getBackground) | يحدد خلفية الشريحة على مستوى الماستر. |
| [getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getShapes) | يخزن الأشكال الموجودة على الماستر، مثل الشعارات، إطارات الصور، والنص المشترك. |
| [getLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getLayoutSlides) | يخزن شرائح التخطيط التابعة للماستر. |
| [getThemeManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getThemeManager) | يوفر الوصول إلى واجهات برمجة سمة الماستر. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | يتحكم في الترويسات، التذييلات، التاريخ، وأرقام الشرائح للماستر وتخطيطاته الفرعية. |
| [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getDependingSlides) | يُعيد الشرائح العادية التي تعتمد على الماستر من خلال تخطيطاتها. |

## **إضافة صورة إلى ماستر الشريحة**

عند إضافة صورة إلى ماستر شريحة، تظهر في الشرائح التي تستخدم تخطيطات من ذلك الماستر. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وعناصر بصرية متكررة أخرى.

المثال التالي يضيف شعارًا إلى أول ماستر شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    logo = Images.fromFile("logo.png")
    try:
        logo_image = presentation.getImages().addImage(logo)
        master_slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 80, 80, logo_image)
    finally:
        logo.dispose()

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/python-java/picture-frame/).

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة في شرائح التخطيط. يوفر ماستر الشريحة النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يحدد كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، تتوفر أوامر العناصر النائبة في عرض ماستر الشريحة.

![أمر إدراج عنصر نائب في عرض ماستر الشريحة في PowerPoint](slide-master_5.png)

لإضافة عناصر نائب جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التابعة للماستر:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    blank_layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout_slide is None:
        blank_layout_slide = master_slide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank")

    blank_layout_slide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80)

    presentation.getSlides().addEmptySlide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على ماستر شريحة. المثال التالي يجد عنصر العنوان النائب ويطبق تعبئة تدرج خطية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, GradientShape, PlaceholderType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    title_placeholder = None

    for shape in master_slide.getShapes():
        if isinstance(shape, AutoShape):
            if shape.getPlaceholder() is not None and shape.getPlaceholder().getType() == PlaceholderType.Title:
                title_placeholder = shape
                break

    if title_placeholder is not None:
        red_gradient_color = Color(255, 0, 0)
        purple_gradient_color = Color(128, 0, 128)

        title_placeholder.getFillFormat().setFillType(FillType.Gradient)
        title_placeholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(0.0), red_gradient_color)
        title_placeholder.getFillFormat().getGradientFormat().getGradientStops().add(jpype.JFloat(1.0), purple_gradient_color)

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![العنوان النائب المنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [ضبط نص الإشارة في العنصر النائب](/slides/ar/python-java/manage-placeholder/) و[تنسيق النص](/slides/ar/python-java/text-formatting/).

## **تغيير خلفية ماستر الشريحة**

خلفية الماستر تُورّث إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يحدد لون خلفية صلب لأول ماستر شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    master_background_color = Color.GREEN

    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(master_background_color)

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

للمواضيع ذات الصلة، راجع [خلفية العرض التقديمي](/slides/ar/python-java/presentation-background/) و[سمة العرض التقديمي](/slides/ar/python-java/presentation-theme/).

## **استنساخ ماستر شريحة إلى عرض تقديمي آخر**

استخدم [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone) لنسخ ماستر شريحة إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الماستر المنسوخ في التخطيطات والشرائح في العرض الهدف.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source_presentation = Presentation("source.pptx")
destination_presentation = Presentation("destination.pptx")
try:
    source_master_slide = source_presentation.getMasters().get_Item(0)
    cloned_master_slide = destination_presentation.getMasters().addClone(source_master_slide)

    destination_presentation.save("destination-with-master.pptx", SaveFormat.Pptx)
finally:
    source_presentation.dispose()
    destination_presentation.dispose()
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع ماسترها، راجع [Clone Slides](/slides/ar/python-java/clone-slides/).

## **إضافة ماسترات شرائح متعددة**

يمكن للعرض التقديمي أن يحتوي على عدة ماسترات شرائح. هذا مفيد عندما تتطلب الأقسام المختلفة هوية بصرية، بنية صفحة، أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة ماسترات الشرائح](slide-master_9.jpg)

المثال التالي يستنسخ الماستر الافتراضي، يمنح النسخة المستنسخة خلفية مختلفة، ينشئ تخطيطًا تحت هذا الماستر المستنسخ، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("presentation.pptx")
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    section_master_slide = presentation.getMasters().addClone(default_master_slide)
    section_master_background_color = Color.LIGHT_GRAY

    section_master_slide.getBackground().setType(BackgroundType.OwnBackground)
    section_master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    section_master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(section_master_background_color)

    source_blank_layout = default_master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    if source_blank_layout is None:
        source_blank_layout = default_master_slide.getLayoutSlides().get_Item(0)

    section_blank_layout = section_master_slide.getLayoutSlides().addClone(source_blank_layout)

    presentation.getSlides().addEmptySlide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مقارنة ماسترات الشرائح**

يمكن مقارنة ماسترات الشرائح باستخدام طريقة [equals](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#equals) الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/). تتحقق المقارنة من البنية والمحتوى الثابت، مثل الأشكال، النص، التنسيق، الرسوم المتحركة، وإعدادات الشريحة الأخرى. لا تقارن المعرفات الفريدة مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

first_presentation = Presentation("first.pptx")
second_presentation = Presentation("second.pptx")
try:
    first_presentation_master_count = first_presentation.getMasters().size()
    second_presentation_master_count = second_presentation.getMasters().size()

    for first_master_index in range(first_presentation_master_count):
        for second_master_index in range(second_presentation_master_count):
            first_master_slide = first_presentation.getMasters().get_Item(first_master_index)
            second_master_slide = second_presentation.getMasters().get_Item(second_master_index)
            are_master_slides_equal = first_master_slide.equals(second_master_slide)

            if are_master_slides_equal:
                print(f"first.pptx master #{first_master_index} equals second.pptx master #{second_master_index}")
finally:
    first_presentation.dispose()
    second_presentation.dispose()
```

لمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/python-java/compare-slides/).

## **تعيين عرض ماستر الشريحة كعرض افتراضي**

استخدم طريقة [setLastView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setLastView) على [ViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض ماستر الشريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation("presentation.pptx")
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لإعدادات العرض الإضافية، راجع [Save Presentation](/slides/ar/python-java/save-presentation/).

## **إزالة ماسترات الشرائح غير المستخدمة**

أحيانًا تحتوي العروض التقديمية على ماسترات شرائح لم تعد تُستخدم من قبل أي شريحة عادية. إزالة الماسترات غير المستخدمة يمكن أن يقلل من حجم الملف ويسهل صيانة القالب.

استخدم [removeUnused](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#removeUnused) لإزالة الماسترات غير المستخدمة من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getMasters().removeUnused(True)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يمكنك أيضًا استخدام طريقة الكود المنخفض [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/compress/#removeUnusedMasterSlides):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما الفرق بين ماستر الشريحة وشريحة التخطيط؟**

يُعرّف ماستر الشريحة إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى ماستر شريحة وتحدد ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، لذا ترث من كل من التخطيط والماستر.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة ماسترات شرائح؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة ماسترات شرائح. استخدم ماسترات متعددة عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو هوية علامة تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى ماستر الشريحة أم إلى شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على ماستر الشريحة، ثم ضع عناصر النائب الخاصة بالمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف ماستر شريحة لا يزال مستخدمًا؟**

لا. لا يمكن حذف ماستر شريحة له شرائح معتمدة بأمان. يجب أولاً نقل تلك الشرائح إلى تخطيطات تحت ماستر آخر، أو استخدام طريقة تنظيف الماسترات غير المستخدمة التي تزيل فقط الماسترات التي لا يُستعمل فيها.