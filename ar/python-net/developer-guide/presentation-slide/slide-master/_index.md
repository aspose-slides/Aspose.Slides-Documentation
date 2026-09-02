---
title: إدارة شرائح الماستر في العرض التقديمي باستخدام Python
linktitle: الشريحة الرئيسية
type: docs
weight: 80
url: /ar/python-net/slide-master/
keywords:
- شريحة رئيسية
- شريحة ماستر
- شريحة ماستر PPT
- عدة شرائح ماستر
- مقارنة شرائح ماستر
- الخلفية
- العنصر النائب
- استنساخ شريحة ماستر
- نسخ شريحة ماستر
- تكرار شريحة ماستر
- شريحة ماستر غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة شرائح الماستر في Aspose.Slides لبايثون عبر .NET: الوصول، التعديل، الاستنساخ، المقارنة، وإزالة شرائح الماستر في عروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

يعرّف **الشريحة الرئيسية** إعدادات التصميم المشتركة لمجموعة من الشرائح. يمكن أن تحتوي على أشكال مشتركة، شعارات، خلفيات، أنماط نص، إعدادات سمة، وإعدادات تذييل. في PowerPoint، تعديل الشريحة الرئيسية هو الطريقة المعتادة للحفاظ على تناسق العرض التقديمي دون تكرار نفس التنسيق في كل شريحة.

يدعم Aspose.Slides للغة Python عبر .NET نفس النموذج. يمكن للعروض التقديمية أن تحتوي على شريحة رئيسية واحدة أو أكثر، ويمكن لكل شريحة رئيسية أن تحتوي على عدة شرائح تخطيط. عادةً لا تشير الشرائح العادية إلى شريحة رئيسية مباشرة. بدلاً من ذلك، تستخدم الشريحة العادية شريحة تخطيط، وتكون تلك الشريحة التخطيطية تابعة لشريحة رئيسية.

التسلسل الهرمي هو:

1. **الشريحة الرئيسية** - تحدد التصميم والسمة المشتركة.
1. **شريحة التخطيط** - تحدد ترتيبًا محددًا للعنصر النائب وتنسيق على مستوى التخطيط.
1. **الشريحة العادية** - تحتوي على محتوى العرض الفعلي وتستخدم شريحة تخطيط واحدة.

![تسلسل شريحة رئيسية، شرائح تخطيط، وشريحة عادية](slide-master_2.jpg)

في Aspose.Slides، تُمثَّل الشريحة الرئيسية بالفئة [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) . جميع الشرائح الرئيسية في عرض تقديمي متاحة عبر مجموعة `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
عند تعريف الخاصية نفسها على أكثر من مستوى، ينتصر المستوى الأكثر تحديدًا. على سبيل المثال، إذا عرّفت شريحة رئيسية وشريحة تخطيط خلفية، فإن الشرائح المستندة إلى ذلك التخطيط تستخدم خلفية التخطيط. للمزيد من المعلومات حول شرائح التخطيط، راجع [Apply or Change Slide Layouts](/slides/ar/python-net/slide-layout/).
{{% /alert %}}

## **الوصول إلى الشرائح الرئيسية**

في PowerPoint، يمكنك فتح عرض الشريحة الرئيسية من **View** > **Slide Master**.

![أمر Slide Master في علامة تبويب View ببرنامج PowerPoint](slide-master_3.jpg)

في Aspose.Slides، استخدم مجموعة `masters` للوصول إلى الشرائح الرئيسية:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

يمكنك أيضًا الحصول على الشريحة الرئيسية المستخدمة من قِبل شريحة عادية عبر تخطيطها:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **ما يحتويه الشريحة الرئيسية**

الشريحة الرئيسية هي كائن شبيه بالشريحة. إنها ترث سلوك الشريحة الشائع من الفئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/) ، لذا فهي تعرض العديد من خصائص الشريحة نفسها المستخدمة في الشرائح العادية وشرائح التخطيط. تُدرج الأعضاء الخاصة بالشريحة الرئيسية في صفحة API الخاصة بـ [MasterSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslide/) .

الأعضاء الشائعة في الشريحة الرئيسية تشمل:

| العضو | الغرض |
| --- | --- |
| `background` | يحدد خلفية الشريحة على مستوى الشريحة الرئيسية. |
| `shapes` | يخزن الأشكال الموضوعة على الشريحة الرئيسية، مثل الشعارات، إطارات الصور، والنص المشترك. |
| `layout_slides` | يخزن شرائح التخطيط التي تنتمي إلى الشريحة الرئيسية. |
| `theme_manager` | يوفر الوصول إلى واجهات برمجة تطبيقات سمة الشريحة الرئيسية. |
| `header_footer_manager` | يتحكم في رؤوس وتذييلات وتواريخ وأرقام الشرائح للشريحة الرئيسية وتخطيطاتها الفرعية. |
| `get_depending_slides` | يُرجع الشرائح العادية التي تعتمد على الشريحة الرئيسية عبر تخطيطاتها. |

## **إضافة صورة إلى الشريحة الرئيسية**

عند إضافة صورة إلى شريحة رئيسية، تظهر على الشرائح التي تستخدم تخطيطات من تلك الشريحة. هذا مفيد للشعارات، العلامات المائية، الشرائط الزخرفية، وعناصر بصرية أخرى متكررة.

المثال التالي يضيف شعارًا إلى الشريحة الرئيسية الأولى:

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

للمزيد من المعلومات حول إطارات الصور، راجع [Picture Frame](/slides/ar/python-net/picture-frame/).

## **العمل مع العنصر النائب**

عادةً ما تُعرّف العناصر النائبة على شرائح التخطيط. توفر الشريحة الرئيسية النمط والسمة المشتركة التي يرثها تلك التخطيطات، بينما يحدد كل تخطيط أي العناصر النائبة متاحة وأين توضع.

في PowerPoint، أوامر العنصر النائب متوفرة في عرض الشريحة الرئيسية.

![أمر Insert Placeholder في عرض Slide Master ببرنامج PowerPoint](slide-master_5.png)

لإضافة عناصر نائب جديدة باستخدام Aspose.Slides، اعمل مع شريحة التخطيط التابعة للشريحة الرئيسية:

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

يمكنك أيضًا تنسيق أشكال العنصر النائب الموجودة بالفعل على شريحة رئيسية. المثال التالي يجد العنصر النائب للعنوان ويطبق تعبئة تدرج لوني خطي:

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

![العنوان المنسق الموروث من الشرائح العادية](slide-master_8.png)

للمزيد من خيارات تنسيق العنصر النائب والنص، راجع [Set Prompt Text in Placeholder](/slides/ar/python-net/manage-placeholder/) و[Text Formatting](/slides/ar/python-net/text-formatting/).

## **تغيير خلفية الشريحة الرئيسية**

تُورّث خلفية الشريحة الرئيسية إلى التخطيطات والشرائح التي لا تتجاوزها. المثال التالي يضبط لون خلفية ثابت للشريحة الرئيسية الأولى:

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

للمواضيع ذات الصلة، راجع [Presentation Background](/slides/ar/python-net/presentation-background/) و[Presentation Theme](/slides/ar/python-net/presentation-theme/).

## **استنساخ شريحة رئيسية إلى عرض تقديمي آخر**

استخدم الطريقة `add_clone` على فئة [MasterSlideCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/masterslidecollection/) لنسخ شريحة رئيسية إلى عرض تقديمي آخر. يمكن بعد ذلك استخدام الشريحة المستنسخة من قبل التخطيطات والشرائح في العرض الوجهة.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

إذا كنت بحاجة إلى استنساخ الشرائح العادية مع شريحتها الرئيسية، راجع [Clone Slides](/slides/ar/python-net/clone-slides/).

## **إضافة عدة شرائح رئيسية**

يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. هذا مفيد عندما تتطلب الأقسام المختلفة هوية بصرية، هيكل صفحة، أو إعدادات سمة مختلفة.

![أوامر PowerPoint لإدراج وإدارة الشرائح الرئيسية](slide-master_9.jpg)

المثال التالي يستنسخ الشريحة الرئيسية الافتراضية، يمنح النسخة المستنسخة خلفية مختلفة، يحصل على تخطيط فارغ تحت تلك الشريحة المستنسخة، ويضيف شريحة جديدة بناءً على ذلك التخطيط:

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

## **مقارنة الشرائح الرئيسية**

يمكن مقارنة الشرائح الرئيسية باستخدام الطريقة `equals` الموروثة من فئة [BaseSlide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseslide/) . تتحقق المقارنة من البنية والمحتوى الثابت، مثل الأشكال، النص، التنسيق، الحركات، وإعدادات الشرائح الأخرى. لا تقارن المعرفات الفريدة، مثل معرفات الشرائح، أو قيم العناصر النائبة الديناميكية، مثل التاريخ الحالي.

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

للمزيد من المعلومات، راجع [Compare Presentation Slides](/slides/ar/python-net/compare-slides/).

## **تعيين عرض الشريحة الرئيسية كعرض افتراضي**

استخدم الخاصية `last_view` على ميزات العرض [ViewProperties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/viewproperties/) للتحكم في العرض الذي يفتح PowerPoint أولًا. المثال التالي يفتح العرض في وضع الشريحة الرئيسية:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

لإعدادات العرض الإضافية، راجع [Save Presentation](/slides/ar/python-net/save-presentation/).

## **إزالة الشرائح الرئيسية غير المستخدمة**

في بعض الأحيان يحتوي العرض على شرائح رئيسية لم تعد تُستَخدم من قبل أي شريحة عادية. إزالة الشرائح غير المستخدمة يمكن أن يقلل من حجم الملف ويسهل صيانة القالب.

استخدم `remove_unused` لإزالة الشرائح الرئيسية غير المستخدمة من مجموعة `masters`:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

يمكنك أيضًا استخدام الطريقة منخفضة الشيفرة `remove_unused_master_slides` من فئة [Compress](https://reference.aspose.com/slides/ar/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **الأسئلة المتكررة**

### ما الفرق بين الشريحة الرئيسية وشريحة التخطيط؟

تُعرّف الشريحة الرئيسية إعدادات التصميم المشتركة مثل السمة، الخلفية، الأشكال المشتركة، وأنماط النص. شريحة التخطيط تنتمي إلى شريحة رئيسية وتحدد ترتيبًا محددًا للعناصر النائبة. الشريحة العادية تستخدم شريحة تخطيط، وبالتالي ترث من كل من التخطيط والشريحة الرئيسية.

### هل يمكن أن يحتوي عرض تقديمي على عدة شرائح رئيسية؟

نعم. يمكن للعرض التقديمي أن يحتوي على عدة شرائح رئيسية. استخدم عدة شرائح رئيسية عندما تحتاج أقسام مختلفة إلى أنظمة بصرية أو هوية علامة تجارية مختلفة.

### هل يجب إضافة العناصر النائبة إلى الشريحة الرئيسية أم إلى شريحة التخطيط؟

في معظم الحالات، أضف العناصر النائبة إلى شرائح التخطيط. ضع العناصر البصرية المشتركة والتنسيق المشترك على الشريحة الرئيسية، ثم ضع عناصر النائب الخاصة بالمحتوى على التخطيطات التي ستستخدمها الشرائح العادية.

### هل يمكنني حذف شريحة رئيسية ما زالت قيد الاستخدام؟

لا. لا يمكن حذف شريحة رئيسية لديها شرائح تعتمد عليها بأمان مباشرة. يجب أولاً نقل تلك الشرائح إلى تخطيطات تحت شريحة رئيسية أخرى، أو استخدام طريقة تنظيف الشرائح الرئيسية غير المستخدمة التي تزيل فقط الشرائح التي لا تُستَخدم.