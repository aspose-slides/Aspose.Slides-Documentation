---
title: إدارة شرائح الماستر في العروض التقديمية باستخدام Python عبر Java
linktitle: شريحة الماستر
type: docs
weight: 70
url: /ar/python-java/slide-master/
keywords:
- شريحة رئيسية
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح الماستر
- خلفية
- عنصر نائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إدارة شرائح الماستر في Aspose.Slides for Python via Java: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة شرائح الماستر في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تُعرِّف **شريحة رئيسية** الإعدادات المشتركة للتصميم لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، وشعارات، وخلفيات، وأنماط نص، وإعدادات موضوع، وإعدادات تذييل. في PowerPoint، يُعد تحرير الشريحة الرئيسية الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق على كل شريحة.

يدعم Aspose.Slides for Python via Java نفس النموذج. يمكن أن يحتوي عرض تقديمي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تابعة لشريحة رئيسية.

التسلسل الهرمي هو:

1. **Slide master** - يحدد التصميم المشترك والموضوع.  
1. **Layout slide** - يحدد ترتيبا محددا للعناصر النائبة وتنسيق مستوى التخطيط.  
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة تخطيط واحدة.

![تسلسل الشرائح الرئيسية وشرائح التخطيط والشرائح العادية](slide-master_2.jpg)

في Aspose.Slides، تُمثَّل الشريحة الرئيسية بالفئة [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/). جميع الشرائح الرئيسية في عرض تقديمي متاحة من خلال مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters)، والتي تُمثَّل بـ [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها في أكثر من مستوى، يُفضَّل المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المعتمدة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/python-java/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح وضع الشريحة الرئيسية من **View** > **Slide Master**.

![أمر Slide Master في علامة تبويب View في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters) للوصول إلى الشرائح الرئيسية:

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

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة من قبل شريحة عادية عبر تخطيطها:

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

## **ما تحتويه الشريحة الرئيسية**

الشريحة الرئيسية عبارة عن كائن شبيه بالشريحة. إنها ترث من [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/)، لذا فهي تعرض العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. تُدرج الأعضاء الخاصة بالشرائح الرئيسية في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/).

من بين الأعضاء الأكثر شيوعًا للشرائح الرئيسية:

| العضو | الغرض |
| --- | --- |
| [getBackground](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getBackground) | يحدد خلفية الشريحة على مستوى الشريحة الرئيسية. |
| [getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#getShapes) | يخزن الأشكال الموضوعة على الشريحة الرئيسية، مثل الشعارات وإطارات الصور والنص المشترك. |
| [getLayoutSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getLayoutSlides) | يخزن شرائح التخطيط التابعة للشرخة الرئيسية. |
| [getThemeManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getThemeManager) | يوفر وصولًا إلى واجهات برمجة تطبيقات موضوع الشريحة الرئيسية. |
| [getHeaderFooterManager](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getHeaderFooterManager) | يتحكم في الرؤوس، التذييلات، التواريخ، وأرقام الشرائح للشرخة الرئيسية وتخطيطاتها الفرعية. |
| [getDependingSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getDependingSlides) | يُرجع الشرائح العادية التي تعتمد على الشرخة الرئيسية عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من تلك الشريحة. هذا مفيد للشعارات، العلامات المائية، الأشرطة الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

## **التحكم في رؤية الرسوميات في الشريحة الرئيسية**

استخدم [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#setShowMasterShapes) لإخفاء الرسوميات الموروثة من الشريحة الرئيسية، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الشريحة الرئيسية. مرّر `False` إلى [Slide.setShowMasterShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#setShowMasterShapes) على الشريحة التي يجب أن تُغفل تلك الرسوميات واتركه `True` على الشرائح التي يجب أن تعرضها.

المثال التالي المستقل يخلق شريطًا أزرقًا زخرفيًا على شريحة رئيسية وشريحتين تستخدمان نفس التخطيط الفارغ. الشريط مرئي على الشريحة الأولى ومخفي على الثانية. لا يلزم عرض تقديمي أو صورة كمدخل.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType, SlideLayoutType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = master_slide.getLayoutSlides().getByType(SlideLayoutType.Blank)
    layout_slide.setShowMasterShapes(True)

    slide_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    band = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slide_height)
    band_color = Color(70, 130, 180)
    band.getFillFormat().setFillType(FillType.Solid)
    band.getFillFormat().getSolidFillColor().setColor(band_color)
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    visible_slide = presentation.getSlides().get_Item(0)
    visible_slide.setLayoutSlide(layout_slide)
    visible_slide.getShapes().clear()

    hidden_slide = presentation.getSlides().addEmptySlide(layout_slide)

    visible_slide.setShowMasterShapes(True)
    hidden_slide.setShowMasterShapes(False)

    presentation.save("master-graphics.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

يستخدم المثال تخطيط **Blank** المرفق مع عرض تقديمي جديد ويزيل العناصر النائبة الخاصة بالشرائح الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية شريحتها الرئيسية عبر [Slide.getLayoutSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getLayoutSlide) و[LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#getMasterSlide). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. تمرير `False` إلى [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/layoutslide/#setShowMasterShapes) يخفِي الرسوميات الرئيسية للشرائح التي تستخدم ذلك التخطيط المشترك، حتى وإن كان إعدادها الخاص `True`. لإخفاء الرسوميات على شريحة واحدة فقط، غيِّر خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كتحكم في الرؤية على الشريحة الرئيسية نفسها. على الشريحة الرئيسية، [getShowMasterShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#getShowMasterShapes) يُرجِع دائمًا `False`، وتمرير `True` إلى [setShowMasterShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslide/#setShowMasterShapes) يرفع استثناءً. طبِّق الإعداد على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسوميات عن الخلفية**

| العملية | الأثر |
| --- | --- |
| إخفاء الرسوميات الرئيسية | يتحكم في رؤية الأشكال الموروثة من الشريحة الرئيسية دون حذفها أو تغيير الأشكال الخاصة بالشريحة. |
| تغيير ملء خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. الرسوميات الرئيسية هي أشكال منفصلة ويمكن أن تظل مرئية فوق تلك الخلفية. انظر [Presentation Background](/slides/ar/python-java/presentation-background/). |
| حذف شكل من الشريحة الرئيسية | يزيل الشكل المصدر المشترك، وبالتالي لا يصبح متاحًا لأي شريحة تستخدم تلك الشريحة الرئيسية. |

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والموضوع المشترك الذي ترثه تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، أوامر العناصر النائبة متاحة في وضع شريحة رئيسية.

![أمر Insert Placeholder في وضع شريحة رئيسية في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التابعة للشرخة الرئيسية:

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على الشريحة الرئيسية. المثال التالي يجد العنصر النائب للعنوان ويطبّق تعبئة تدرج خطي:

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

![العنصر النائب للعنوان المُنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/python-java/manage-placeholder/) و[Text Formatting](/slides/ar/python-java/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

تُورّث خلفية الشريحة الرئيسية إلى التخطيطات والشرائح التي لا تُعيد تعريفها. المثال التالي يحدد لون خلفية ثابت للشرخة الرئيسية الأولى:

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

لمواضيع ذات صلة، راجع [Presentation Background](/slides/ar/python-java/presentation-background/) و[Presentation Theme](/slides/ar/python-java/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم [MasterSlideCollection.addClone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#addClone) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الشريحة المنسوخة في التخطيطات والشرائح بالعرض الهدف.

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

إذا كنت بحاجة لاستنساخ الشرائح العادية مع شريطها الرئيسي، راجع [Clone Slides](/slides/ar/python-java/clone-slides/).

## **إضافة شرائح رئيسية متعددة**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة علامات تجارية مختلفة أو بنية صفحات أو إعدادات موضوع مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الشريحة الرئيسية الافتراضية، يعطي النسخة المستنسخة خلفية مختلفة، ينشئ تخطيطًا تحت تلك الشريحة المستنسخة، ويضيف شريحة جديدة تعتمد على ذلك التخطيط:

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

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام طريقة [equals](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/#equals) الموروثة من [BaseSlide](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseslide/). تقوم المقارنة بفحص الهيكل والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة، مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية، مثل التاريخ الحالي.

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

## **تعيين عرض شريحة رئيسية كعرض افتراضي**

استخدم طريقة [setLastView](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/#setLastView) على [ViewProperties](https://reference.aspose.com/slides/ar/python-java/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولًا. المثال التالي يفتح العرض التقديمي في وضع شريحة رئيسية:

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

لمزيد من إعدادات العرض، راجع [Save Presentation](/slides/ar/python-java/save-presentation/).

## **إزالة الشرائح الرئيسية غير المستخدمة**

أحيانًا يحتوي العرض التقديمي على شرائح رئيسية لم تعد تُستَخدم من قبل أي شرائح عادية. يمكن أن يقلل إزالة الشرائح غير المستخدمة من حجم الملف ويسهل صيانة القالب.

استخدم [removeUnused](https://reference.aspose.com/slides/ar/python-java/aspose.slides/masterslidecollection/#removeUnused) لإزالة الشرائح الرئيسية غير المستخدمة من مجموعة [Presentation.getMasters](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getMasters):

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

## **FAQ**

**ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟**

تحدد الشريحة الرئيسية إعدادات التصميم المشتركة مثل الموضوع، الخلفية، الأشكال المشتركة، وأنماط النص. تنتمي شريحة التخطيط إلى شريحة رئيسية وتحدد ترتيبًا محددًا للعناصر النائبة. تستخدم الشريحة العادية شريحة تخطيط، لذا فإنها ترث من كل من التخطيط والشريحة الرئيسية.

**هل يمكن أن يحتوي عرض تقديمي على عدة شرائح رئيسية؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم عدة شرائح رئيسية عندما تحتاج الأقسام المختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى الشريحة الرئيسية أم إلى شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر النائب المحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة رئيسية لا تزال قيد الاستخدام؟**

لا. لا يمكن حذف شريحة رئيسية لديها شرائح معتمدة بأمان مباشرة. انقل تلك الشرائح أولاً إلى تخطيطات تحت شريحة رئيسية أخرى، أو استخدم طريقة تنظيف الشرائح الرئيسية غير المستخدمة التي تزيل فقط الشرائح غير المستعملة.