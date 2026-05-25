---
title: إدارة شرائح الرئيس في بايثون
linktitle: شريحة رئيس
type: docs
weight: 80
url: /ar/python-net/slide-master/
keywords:
- شريحة رئيس
- شريحة رئيسية
- شريحة رئيسية PPT
- شرائح رئيسية متعددة
- مقارنة شرائح رئيسية
- خلفية
- عنصر نائب
- استنساخ شريحة رئيسية
- نسخ شريحة رئيسية
- تكرار شريحة رئيسية
- شريحة رئيس غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة شرائح الرئيس في Aspose.Slides للغة Python عبر .NET: الوصول، التحرير، الاستنساخ، المقارنة، وإزالة شرائح الرئيس في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يُعرّف **شريحة الرئيس** (slide master) إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكنه احتواء الأشكال الشائعة، والشعارات، والخلفيات، وأنماط النص، وإعدادات السمة، وإعدادات التذييل. في PowerPoint، يُعد تحرير شريحة الرئيس الطريقة المعتادة للحفاظ على اتساق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides للغة Python عبر .NET نفس النموذج. يمكن للعرض التقديمي أن يحتوي على شريحة رئيس واحدة أو أكثر، ويمكن لكل شريحة رئيس أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيس مباشرةً. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتلك الشريحة التخطيطية تنتمي إلى شريحة رئيس.

التسلسل الهرمي هو:

1. **شريحة الرئيس** - تُعرّف التصميم والسمة المشتركة.  
1. **شريحة التخطيط** - تُعرّف ترتيبًا محددًا للعناصر النائبة وتنسيق المستوى التخطيطي.  
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

في Aspose.Slides، تُمثَّل شريحة الرئيس بالفئة [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/). جميع شرائح الرئيس في العرض التقديمي متاحة عبر مجموعة `Presentation.masters`.

{{% alert color="info" title="الوراثة" %}}

عند تعريف الخاصية نفسها في أكثر من مستوى، يفلُح المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة الرئيس وشريحة التخطيط خلفيةً، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. لمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/python-net/slide-layout/).

{{% /alert %}}

## **الوصول إلى شرائح الرئيس**

في PowerPoint، يمكنك فتح عرض شريحة الرئيس من **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `masters` للوصول إلى شرائح الرئيس:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

يمكنك أيضًا الحصول على شريحة الرئيس التي تستخدمها شريحة عادية عبر تخطيطها:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **ما الذي تحتويه شريحة الرئيس**

شريحة الرئيس هي كائن شبيه بالشريحة. تُورث سلوك الشريحة العام من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/)، لذا تُظهر العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. تُدرج الأعضاء الخاصة بالشريحة الرئيس على صفحة واجهة برمجة التطبيقات [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/).

تشمل الأعضاء الشائعة الاستخدام في شريحة الرئيس:

| العضو | الغرض |
| --- | --- |
| `background` | يحدّد خلفية الشريحة على مستوى الرئيس. |
| `shapes` | يخزن الأشكال الموضوعة على الرئيس، مثل الشعارات، وإطارات الصور، والنص المشترك. |
| `layout_slides` | يخزن شرائح التخطيط التي تنتمي إلى الرئيس. |
| `theme_manager` | يوفّر الوصول إلى واجهات برمجة تطبيقات سمة الرئيس. |
| `header_footer_manager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للرئيس وتخطيطاته الفرعية. |
| `get_depending_slides` | يُرجع الشرائح العادية التي تعتمد على الرئيس من خلال تخطيطاتها. |

## **إضافة صورة إلى شريحة الرئيس**

عند إضافة صورة إلى شريحة الرئيس، تظهر على الشرائح التي تستخدم تخطيطات من ذلك الرئيس. وهذا مفيد للشعارات، وعلامات المائية، والشعارات الزخرفية، وغيرها من العناصر البصرية المتكررة.

المثال التالي يضيف شعارًا إلى أول شريحة رئيس:

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

لمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/python-net/picture-frame/).

## **العمل مع العناصر النائبة**

عادةً ما تُعرّف العناصر النائبة في شرائح التخطيط. تُوفر شريحة الرئيس النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يقرر كل تخطيط أي العناصر النائبة متاحة وأين تُوضع.

في PowerPoint، تتوفر أوامر العنصر النائب في عرض شريحة الرئيس.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

لإضافة عناصر نائبة جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التي تنتمي إلى الرئيس:

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

يمكنك أيضًا تنسيق أشكال العناصر النائبة الموجودة بالفعل على شريحة الرئيس. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرج خطية:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

لمزيد من خيارات تنسيق العناصر النائبة والنص، راجع [Set Prompt Text in Placeholder](/python-net/manage-placeholder/) و[Text Formatting](/python-net/text-formatting/).

## **تغيير خلفية شريحة الرئيس**

تُورّث خلفية الرئيس من قبل التخطيطات والشرائح التي لا تُعيد تعريفها. المثال التالي يحدد لون خلفية صلب لأول شريحة رئيس:

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

للمواضيع ذات الصلة، راجع [Presentation Background](/python-net/presentation-background/) و[Presentation Theme](/python-net/presentation-theme/).

## **استنساخ شريحة الرئيس إلى عرض تقديمي آخر**

استخدم طريقة `add_clone` على الفئة [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) لنسخ شريحة رئيس إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الرئيس المنسوخ بواسطة التخطيطات والشرائح في العرض الهدف.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع الرئيس الخاص بها، راجع [Clone Slides](/python-net/clone-slides/).

## **إضافة عدة شرائح رئيس**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيس. هذا مفيد عندما تتطلب الأقسام المختلفة هوية بصرية أو هيكل صفحة أو إعدادات سمة مختلفة.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

المثال التالي يستنسخ الرئيس الافتراضي، يمنح النسخة المستنسخة خلفية مختلفة، يحصل على تخطيط فارغ تحت ذلك الرئيس المستنسخ، ثم يضيف شريحة جديدة بناءً على ذلك التخطيط:

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

## **مقارنة شرائح الرئيس**

يمكن مقارنة شرائح الرئيس باستخدام طريقة `equals` الموروثة من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/). تتحقق المقارنة من البنية والمحتوى الثابت، مثل الأشكال والنص والتنسيق والرسوم المتحركة وإعدادات الشريحة الأخرى. لا تُقارن المعرفات الفريدة مثل معرفات الشرائح، ولا قيم العناصر النائبة الديناميكية مثل التاريخ الحالي.

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

لمزيد من المعلومات، راجع [Compare Presentation Slides](/python-net/compare-slides/).

## **تعيين عرض شريحة الرئيس كعرض افتراضي**

استخدم خاصية `last_view` على كائن العرض [ViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتحه PowerPoint أولًا. المثال التالي يفتح العرض في عرض شريحة الرئيس:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

لمزيد من إعدادات العرض، راجع [Save Presentation](/python-net/save-presentation/).

## **إزالة شرائح الرئيس غير المستخدمة**

في بعض الأحيان تحتوي العروض التقديمية على شرائح رئيس لم تعد مستخدمة من قبل أي شريحة عادية. يمكن أن يقلل حذف الرؤساء غير المستعملة من حجم الملف ويبسط صيانة القالب.

استخدم `remove_unused` لإزالة الرؤساء غير المستعملة من مجموعة `masters`:

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

## **الأسئلة المتداولة**

**ما الفرق بين شريحة الرئيس وشريحة التخطيط؟**

تُعرّف شريحة الرئيس إعدادات التصميم المشتركة مثل السمة، والخلفية، والأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة الرئيس وتُحدد ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة التخطيط، وبالتالي ترث من كل من التخطيط والرئيس.

**هل يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيس؟**

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيس. استخدم عدة رؤساء عندما تحتاج الأقسام المختلفة إلى أنظمة بصرية أو هوية علامة تجارية مختلفة.

**هل يجب إضافة العناصر النائبة إلى شريحة الرئيس أم إلى شريحة التخطيط؟**

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على شريحة الرئيس، ثم ضع عناصر المحتوى النائبة على التخطيطات التي ستستخدمها الشرائح العادية.

**هل يمكن حذف شريحة رئيس لا تزال مستخدمة؟**

لا. لا يمكن حذف شريحة رئيس لها شرائح معتمدة بأمان مباشرةً. لنقل تلك الشرائح إلى تخطيطات تحت رئيس آخر، أو استخدم طريقة تنظيف الرؤساء غير المستخدمة التي تحذف فقط الرؤساء غير المستعملة.