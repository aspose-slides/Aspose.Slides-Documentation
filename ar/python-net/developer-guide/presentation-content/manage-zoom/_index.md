---
title: إدارة التكبير في العروض التقديمية باستخدام Python
linktitle: تكبير
type: docs
weight: 60
url: /ar/python-net/manage-zoom/
keywords:
- تكبير
- إطار التكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لبايثون عبر .NET — الانتقال بين الأقسام، إضافة الصور المصغرة والانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
تسمح لك ميزة التكبير في PowerPoint بالتنقل إلى ومن شرائح أو أقسام أو أجزاء محددة من العرض التقديمي. عند تقديم العرض، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا.

![نظرة عامة](overview.png)

* لتلخيص عرض تقديمي كامل على شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**

يمكن لتكبير الشريحة جعل عرضك التقديمي أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض. تكبير الشرائح مفيد للعروض القصيرة التي لا تحتوي على أقسام كثيرة، لكن لا يزال بإمكانك استخدامه في سيناريوهات عرض مختلفة.

يساعدك تكبير الشرائح على الغوص في قطع متعددة من المعلومات بينما تشعر أنك على لوحة واحدة.

![تكبير الشريحة المختارة](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides تعداد [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/)، واجهة [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/)، وبعض الأساليب في واجهة [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة للربط بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. حفظ العرض المعدل كملف PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # إنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # إنشاء مربع نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # إنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # إنشاء مربع نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #إضافة كائنات ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # حفظ العرض التقديمي
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء إطارات تكبير بصور مخصصة**
باستخدام Aspose.Slides لـ Python عبر .NET، يمكنك إنشاء إطار تكبير بصورة غير صورة معاينة الشريحة بهذه الطريقة:

1. إنشاء كائن من الفئة `Presentation` .
2. إنشاء شريحة جديدة للربط بها.
3. إضافة نص تعريف وخلفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation والذي سيُستخدم لملء الإطار.
5. إضافة إطارات تكبير (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. حفظ العرض المعدل كملف PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # إنشاء خلفية للشريحة الثانية
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # إنشاء مربع نص للشريحة الثالثة
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # إنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #إضافة كائن ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق إطارات التكبير**
في الأقسام السابقة (أعلاه)، شرحنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطارات. هناك عدة إعدادات تنسيق يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير في شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة `Presentation` .
2. إنشاء شرائح جديدة للربط بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation والذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار التكبير الأول.
7. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
8. إزالة الخلفية من صورة كائن إطار التكبير الثاني.
9. حفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # إنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # إنشاء مربع نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # إنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # إنشاء مربع نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame objects
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # إنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # تعيين صورة مخصصة لكائن zoomFrame1
    zoomFrame1.image = image

    # تعيين تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.show_background = False

    # حفظ العرض التقديمي
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **تكبير القسم**

تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها بشدة. أو يمكنك استخدامها لتسليط الضوء على كيفية ربط أجزاء معينة من عرضك.

![تكبير القسم المختار](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides واجهة [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط به إطار التكبير.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. حفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 1", slide)

    # إضافة كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء إطارات تكبير القسم بصور مخصصة**

باستخدام Aspose.Slides لـ Python، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط به إطار التكبير.
5. إنشاء كائن `IPPImage` بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. إضافة إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. حفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 1", slide)

    #إنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # إضافة كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    #حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد للربط به إطار التكبير.
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير الحجم والموضع لكائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن `IPPImage` بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. تفعيل القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. حفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 1", slide)

    # إضافة كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # تنسيق كائن SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **تكبير الملخص**

تكبير الملخص يشبه صفحة هبوط حيث يتم عرض جميع أجزاء عرضك التقديمي مرة واحدة. عند تقديمك، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تريد. يمكنك الإبداع، القفز إلى الأمام، أو إعادة زيارة أجزاء عرض الشرائح دون مقاطعة تدفق العرض.

![تكبير الملخص](summaryzoom.png)

بالنسبة لكائنات تكبير الملخص، توفر Aspose.Slides واجهات [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/)، [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)، و[ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) وبعض الأساليب تحت واجهة [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **إنشاء تكبير الملخص**

يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. حفظ العرض المعدل كملف PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # إنشاء مصفوفة الشرائح
    for slideNumber in range(5):
        # إضافة شرائح جديدة إلى العرض التقديمي
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # إنشاء خلفية للشريحة
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # إنشاء مربع نص للشريحة
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # إنشاء كائنات تكبير لجميع الشرائح في الشريحة الأولى
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ضبط خاصية ReturnToParent للعودة إلى الشريحة الأولى
        zoomFrame.return_to_parent = True

    # حفظ العرض التقديمي
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة وإزالة قسم تكبير الملخص**

جميع الأقسام في إطار تكبير الملخص ممثلة بكائنات [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) المخزنة في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). يمكنك إضافة أو إزالة كائن قسم تكبير الملخص عبر واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. إضافة شريحة وقسم جديدين إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. إزالة القسم الأول من إطار تكبير الملخص.
7. حفظ العرض المعدل كملف PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 1", slide)

    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 2", slide)

    # إضافة كائن SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    section3 = pres.sections.add_section("Section 3", slide)

    # إضافة قسم إلى تكبير الملخص
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # إزالة قسم من تكبير الملخص
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق أقسام تكبير الملخص**

لإنشاء كائنات أقسام تكبير الملخص أكثر تعقيدًا، عليك تعديل تنسيق الإطار البسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم تكبير الملخص.

يمكنك التحكم في تنسيق كائن قسم تكبير الملخص داخل إطار تكبير الملخص بهذه الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار تكبير الملخص إلى الشريحة الأولى.
4. الحصول على كائن قسم تكبير الملخص الأول من `ISummaryZoomSectionCollection` .
5. إنشاء كائن `IPPImage` بإضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. تعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
7. تفعيل القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. تغيير تنسيق الخط لكائن إطار التكبير الثاني.
9. تغيير مدة الانتقال.
10. حفظ العرض المعدل كملف PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 1", slide)

    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # إضافة قسم جديد إلى العرض التقديمي
    pres.sections.add_section("Section 2", slide)

    # إضافة كائن SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # الحصول على أول كائن SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # تنسيق كائن SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **التعليمات المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة 'الأصلية' بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) على سلوك `return_to_parent` الذي، عند تمكينه، يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى الهدف.

**هل يمكنني تعديل 'السرعة' أو مدة انتقال التكبير؟**

نعم. يدعم Zoom ضبط `transition_duration` بحيث يمكنك التحكم في مدة حركة القفز.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض التقديمي؟**

لا يوجد حد صريح موثق في واجهة برمجة التطبيقات. تعتمد الحدود العملية على تعقيد العرض الإجمالي وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، لكن يجب مراعاة حجم الملف وزمن التجسيد.