---
title: إدارة شرائح ماستر في العروض التقديمية باستخدام Python
linktitle: شريحة ماستر
type: docs
weight: 80
url: /ar/python-net/slide-master/
keywords:
- شريحة ماستر
- شريحة ماستر
- شريحة ماستر PPT
- شرائح ماستر متعددة
- مقارنة شرائح ماستر
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
- Aspose.Slides
description: "إدارة شرائح ماستر في Aspose.Slides لـ Python عبر .NET: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة شرائح ماستر في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يحدد **slide master** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن يحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نصية، إعدادات السمة، وإعدادات التذييل. في PowerPoint، تعديل slide master هو الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides لـ Python عبر .NET نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة master واحدة أو أكثر، ويمكن لكل شريحة master أن تحتوي على عدة شريحة layout. عادةً لا تشير الشرائح العادية إلى شريحة master مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة layout، وتلك الشريحة layout تنتمي إلى شريحة master.

التسلسل هو:

1. **Slide master** - يحدد التصميم المشترك والسمة.
1. **Layout slide** - يحدد ترتيبًا محددًا للعناصر النائبة وتنسيق المستوى التخطيطي.
1. **Normal slide** - يحتوي على محتوى العرض الفعلي ويستخدم شريحة layout واحدة.

![تسلسل شريحة master وشريحة layout والشريحة العادية](slide-master_2.jpg)

في Aspose.Slides، يتم تمثيل slide master بواسطة الفئة [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) . جميع شريحة master في عرض تقديمي متاحة عبر مجموعة `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
عندما يتم تعريف الخاصية نفسها على أكثر من مستوى، يفوز المستوى الأكثر تحديدًا. على سبيل المثال، إذا كانت شريحة master وشريحة layout كلاهما يحددان خلفية، فإن الشرائح القائمة على ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح layout، راجع [تطبيق أو تغيير تخطيطات الشرائح](/slides/ar/python-net/slide-layout/).
{{% /alert %}}

## **الوصول إلى Slide Masters**

في PowerPoint، يمكنك فتح عرض Slide Master من **View** > **Slide Master**.

![أمر Slide Master في علامة تبويب View في PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `masters` للوصول إلى شرائح master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

يمكنك أيضًا الحصول على شريحة master المستخدمة من قبل شريحة عادية عبر التخطيط الخاص بها:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **ما يحتويه Slide Master**

شريحة master هي كائن شبيه بالشريحة. إنها ترث سلوك الشريحة الشائع من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/) ، لذا تُظهر العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح layout. يتم سرد الأعضاء الخاصة بـ master في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) .

الأعضاء الشائعة الاستخدام في شريحة master تشمل:

| العضو | الغرض |
| --- | --- |
| `background` | يضبط خلفية الشريحة على مستوى master. |
| `shapes` | يخزن الأشكال الموضوعة على master، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `layout_slides` | يخزن شرائح layout التي تنتمي إلى master. |
| `theme_manager` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة master. |
| `header_footer_manager` | يتحكم في الرؤوس، التذييلات، التواريخ، وأرقام الشرائح للـ master وتخطيطاته الفرعية. |
| `get_depending_slides` | يعيد الشرائح العادية التي تعتمد على master عبر تخطيطاتها. |

## **إضافة صورة إلى Slide Master**

عند إضافة صورة إلى شريحة master، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الـ master. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، والعناصر البصرية المتكررة الأخرى.

المثال التالي يضيف شعارًا إلى شريحة master الأولى:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

لمزيد من المعلومات حول إطارات الصورة، راجع [إطار الصورة](/slides/ar/python-net/picture-frame/).

## **التحكم في رؤية رسومات الـ Master**

استخدم [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/show_master_shapes/) لإخفاء رسومات الـ master الموروثة، مثل الشعارات أو الأشكال الزخرفية، دون حذفها من الـ master. اضبط [Slide.show_master_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/show_master_shapes/) إلى `False` على الشريحة التي يجب أن تحذف تلك الرسومات واتركه `True` على الشرائح التي يجب أن تعرضها.

المثال المستقل التالي ينشئ شريطًا أزرق زخرفيًا على master وشريحتين تستخدمان نفس التخطيط الفارغ. يكون الشريط مرئيًا على الشريحة الأولى ومخفيًا على الثانية. لا يلزم عرض تقديمي أو صورة إدخال.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

يستخدم المثال تخطيط **Blank** المرفق مع عرض تقديمي جديد ويزيل العناصر النائبة الخاصة بالشريحة الأولية.

### **اختر نطاق الإعداد**

تستخدم الشريحة العادية الـ master الخاص بها عبر [Slide.layout_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/layout_slide/) و [LayoutSlide.master_slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/master_slide/). ضبط الخاصية على شريحة فردية يؤثر فقط على تلك الشريحة. ضبط [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/layoutslide/show_master_shapes/) إلى `False` يخفي رسومات الـ master للشرائح التي تستخدم ذلك التخطيط المشترك، حتى إذا كان إعدادها الخاص هو `True`. لإخفاء الرسومات على شريحة واحدة فقط، غير خاصية الشريحة واترك التخطيط المشترك دون تغيير.

الإعداد غير مدعوم كتحكم في الرؤية على شريحة الـ master نفسها. على الـ master دائمًا يُعيد `False`، وتعيين `True` يثير استثناءً. قم بتطبيقه على شريحة عادية أو تخطيط بدلاً من ذلك.

### **تمييز الرسومات عن الخلفية**

| العملية | التأثير |
| --- | --- |
| إخفاء رسومات الـ master | يتحكم في رؤية الأشكال الموروثة من الـ master دون حذفها أو تغيير أشكال الشريحة نفسها. |
| تغيير تعبئة خلفية الشريحة | يغيّر لون الخلفية أو التدرج أو الصورة. رسومات الـ master هي أشكال منفصلة ويمكن أن تظل مرئية فوق تلك الخلفية. انظر [خلفية العرض](/slides/ar/python-net/presentation-background/). |
| حذف شكل من الـ master | يحذف الشكل المشترك من الـ master، وبالتالي لا يصبح متاحًا لأي شريحة تستخدم ذلك الـ master. |

## **العمل مع العناصر النائبة**

عادةً ما يتم تعريف العناصر النائبة على شرائح layout. توفر شريحة master النمط والسمة المشتركة التي ترثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، تتوفر أوامر العناصر النائبة في عرض Slide Master.

![أمر Insert Placeholder في عرض Slide Master في PowerPoint](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة layout التي تنتمي إلى الـ master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة master. المثال التالي يبحث عن عنصر نائبة العنوان ويطبق تعبئة تدرج خطية:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![عنصر نائبة العنوان المُنسق الموروث من الشرائح العادية](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [تعيين نص التوجيه في العنصر النائب](/slides/ar/python-net/manage-placeholder/) و [تنسيق النص](/slides/ar/python-net/text-formatting/).

## **تغيير خلفية Slide Master**

يتم وراثة خلفية الـ master من قبل التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يضبط لون خلفية صلب للشريحة master الأولى:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

لمواضيع ذات صلة، راجع [خلفية العرض](/slides/ar/python-net/presentation-background/) و [سمة العرض](/slides/ar/python-net/presentation-theme/).

## **استنساخ Slide Master إلى عرض تقديمي آخر**

استخدم طريقة `add_clone` على الفئة [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) لنسخ شريحة master إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الـ master المنسوخ بواسطة التخطيطات والشرائح في عرض الوجهة.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الـ master الخاص بها، راجع [استنساخ الشرائح](/slides/ar/python-net/clone-slides/).

## **إضافة عدة Slide Masters**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح master. هذا مفيد عندما تتطلب أقسام مختلفة علامات تجارية مختلفة أو هيكل صفحة أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة شرائح master](slide-master_9.jpg)

المثال التالي يستنسخ الـ master الافتراضي، يمنح النسخة خلفية مختلفة، يحصل على تخطيط فارغ تحت ذلك الـ master المستنسخ، ويضيف شريحة جديدة بناءً على ذلك التخطيط:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **مقارنة Slide Masters**

يمكن مقارنة شرائح master باستخدام طريقة `equals` الموروثة من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/) . يتحقق المقارنة من البنية والمحتوى الثابت، مثل الأشكال والنصوص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا يتم مقارنة المعرفات الفريدة، مثل معرفات الشرائح، أو القيم الديناميكية للعناصر النائبة، مثل التاريخ الحالي.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

لمزيد من المعلومات، راجع [مقارنة شرائح العرض](/slides/ar/python-net/compare-slides/).

## **تعيين عرض Slide Master كعرض افتراضي**

استخدم خاصية `last_view` على عرض التقديم [ViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولاً. المثال التالي يفتح العرض التقديمي في عرض Slide Master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

لإعدادات عرض إضافية، راجع [حفظ العرض](/slides/ar/python-net/save-presentation/).

## **إزالة شرائح Master غير المستخدمة**

أحيانًا يحتوي العروض التقديمية على شرائح master لم تعد مستخدمة من قبل أي شريحة عادية. إزالة الـ master غير المستخدمة يمكن أن يقلل من حجم الملف ويسهل صيانة القالب.

استخدم `remove_unused` لإزالة الـ master غير المستخدمة من مجموعة `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضًا استخدام طريقة `remove_unused_master_slides` منخفضة الكود من الفئة [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/):

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة الشائعة**

**ما الفرق بين slide master و layout slide؟**

يحدد slide master إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. تنتمي شريحة layout إلى شريحة master وتحدد ترتيبًا محددًا للعناصر النائبة. تستخدم الشريحة العادية شريحة layout، وبالتالي ترث من كل من التخطيط والـ master.

**هل يمكن لعرض تقديمي واحد أن يحتوي على عدة slide masters؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة slide masters. استخدم عدة masters عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو علامات تجارية مختلفة.

**هل يجب أن أضيف عناصر نائبة إلى شريحة master أم إلى شريحة layout؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح layout. ضع العناصر البصرية المشتركة والتنسيق المشترك على شريحة master، ثم ضع عناصر المحتوى النائبة على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكنني حذف شريحة master لا تزال قيد الاستخدام؟**

لا. لا يمكن حذف شريحة master التي لديها شرائح تابعية بأمان مباشرةً. أولًا انقل تلك الشرائح إلى تخطيطات تحت master آخر، أو استخدم طريقة تنظيف للـ master غير المستخدمة التي تزيل فقط الـ masters التي لا تُستَخدم.