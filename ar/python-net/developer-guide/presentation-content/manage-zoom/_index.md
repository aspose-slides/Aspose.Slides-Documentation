---
title: إدارة التكبيرات في العروض التقديمية باستخدام بايثون
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
- بايثون
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لبايثون عبر .NET — الانتقال بين الأقسام، إضافة صور مصغرة وانتقالات عبر عروض PPT و PPTX و ODP."
---

## **نظرة عامة**
Zoom في PowerPoint تسمح لك بالقفز إلى ومن الشرائح المحددة، الأقسام، والأجزاء من العرض التقديمي. عندما تقوم بتقديم العرض، قد تكون هذه القدرة على التنقل السريع عبر المحتوى مفيدة جدًا. 

![نظرة عامة](overview.png)

* لتلخيص عرض تقديمي كامل في شريحة واحدة، استخدم [ملخص التكبير](#Summary-Zoom).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**

تكبير الشريحة يمكن أن يجعل عرضك التقديمي أكثر ديناميكية، مما يتيح لك التنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض. تكبيرات الشرائح رائعة للعروض القصيرة التي لا تحتوي على العديد من الأقسام، لكن يمكنكstill استخدامها في سيناريوهات عرض مختلفة.

تكبيرات الشرائح تساعدك على حفر معلومات متعددة بينما تشعر أنك على لوحة قماش واحدة. 

![slidezoomsel](slidezoomsel.png)

للكائنات تكبير الشريحة، توفر Aspose.Slides التعداد [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/)، الفئة [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/)، وبعض الطرق في الفئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شرائح جديدة تريد الارتباط إليها. 
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا النموذج كيفية إنشاء إطار تكبير في شريحة:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #إنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #إنشاء صندوق نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #إنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #إنشاء صندوق نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #إضافة كائنات ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #حفظ العرض التقديمي
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء إطارات التكبير بصور مخصصة**
مع Aspose.Slides for Python via .NET، يمكنك إنشاء إطار تكبير بصورة غير صورة معاينة الشريحة بهذه الطريقة: 
1. إنشاء مثال من الفئة `Presentation`.
2. إنشاء شريحة جديدة تريد الارتباط إليها. 
3. إضافة نص تعريف وخلفية إلى الشريحة التي تم إنشاؤها.
4. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لملء الإطار.
5. إضافة إطارات تكبير (تحتوي على المرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية إنشاء إطار تكبير بصورة مختلفة:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #إنشاء خلفية للشريحة الثانية
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #إنشاء صندوق نص للشريحة الثالثة
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #إنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #إضافة كائن ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    #حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **تنسيق إطارات التكبير**
في الأقسام السابقة (أعلاه)، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، عليك تعديل تنسيق الإطارات. هناك عدة إعدادات تنسيق يمكنك تطبيقها على إطار تكبير. 

يمكنك التحكم في تنسيق إطار التكبير في شريحة بهذه الطريقة:

1. إنشاء مثال من الفئة `Presentation`.
2. إنشاء شرائح جديدة للارتباط بها.
3. إضافة نص تعريف وخلفية إلى الشرائح التي تم إنشاؤها.
4. إضافة إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن Presentation الذي سيُستخدم لملء الإطار.
6. ضبط صورة مخصصة لإطار التكبير الأول.
7. تغيير تنسيق الخط لإطار التكبير الثاني.
8. إزالة الخلفية من صورة إطار التكبير الثاني.
5. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون مثالًا على كيفية تغيير تنسيق إطار التكبير: 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #إضافة شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #إنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #إنشاء صندوق نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #إنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #إنشاء صندوق نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #إضافة كائنات ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #إنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    #تعيين صورة مخصصة لكائن zoomFrame1
    zoomFrame1.image = image

    #تعيين تنسيق إطار التكبير لكائن zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    #عدم إظهار الخلفية لكائن zoomFrame2
    zoomFrame2.show_background = False

    #حفظ العرض التقديمي
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **تكبير القسم**

تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبيرات الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط أجزاء معينة من عرضك. 

![seczoomsel](seczoomsel.png)

للكائنات تكبير القسم، توفر Aspose.Slides الفئة [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) وبعض الطرق تحت الفئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شريحة جديدة. 
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية إنشاء إطار تكبير على شريحة:
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

باستخدام Aspose.Slides for Python، يمكنك إنشاء إطار تكبير قسم بصورة معاينة شريحة مختلفة بهذه الطريقة: 

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. إضافة إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية إنشاء إطار تكبير بصورة مختلفة:
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

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير قسم أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على إطار تكبير القسم. 

يمكنك التحكم في تنسيق إطار تكبير القسم على شريحة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شريحة جديدة.
3. إضافة خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. إنشاء قسم جديد ترغب في ربط إطار التكبير به. 
5. إضافة إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. تغيير حجم وموقع كائن تكبير القسم الذي تم إنشاؤه.
7. إنشاء كائن [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) بإضافة صورة إلى مجموعة Images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
8. ضبط صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. ضبط القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
10. إزالة الخلفية من صورة كائن إطار تكبير القسم.
11. تغيير تنسيق الخط لكائن الإطار التكبير الثاني.
12. تغيير مدة الانتقال.
13. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية تغيير تنسيق إطار تكبير القسم:
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


## **ملخص التكبير**

ملخص التكبير يشبه الصفحة الرئيسية حيث يتم عرض جميع أجزاء عرضك التقديمي مرة واحدة. عندما تقوم بتقديم العرض، يمكنك استخدام التكبير للانتقال من مكان إلى آخر في عرضك بأي ترتيب تفضله. يمكنك الإبداع، التقدم إلى الأمام، أو إعادة زيارة أجزاء عرض الشرائح دون مقاطعة تدفق العرض.

![summaryzoom](summaryzoom.png)

للكائنات ملخص التكبير، توفر Aspose.Slides الفئات [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/)، و[SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) وبعض الطرق تحت الفئة [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/).

### **إنشاء ملخص التكبير**

يمكنك إضافة إطار ملخص تكبير إلى شريحة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية إنشاء إطار ملخص تكبير على شريحة:
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # إنشاء مصفوفة الشرائح
    for slideNumber in range(5):
        #إضافة شرائح جديدة إلى العرض التقديمي
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # إنشاء خلفية للشريحة
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # إنشاء صندوق نص للشريحة
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # إنشاء كائنات تكبير لجميع الشرائح في الشريحة الأولى
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # تعيين خاصية ReturnToParent للعودة إلى الشريحة الأولى
        zoomFrame.return_to_parent = True

    # حفظ العرض التقديمي
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **إضافة وإزالة قسم ملخص التكبير**

جميع الأقسام في إطار ملخص التكبير يتم تمثيلها بواسطة كائنات [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/)، المخزنة في كائن [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/). يمكنك إضافة أو إزالة كائن قسم ملخص التكبير من خلال الفئة [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. إضافة شريحة جديدة وقسم إلى العرض.
5. إضافة القسم الذي تم إنشاؤه إلى إطار ملخص التكبير.
6. إزالة القسم الأول من إطار ملخص التكبير.
7. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية إضافة وإزالة أقسام في إطار ملخص التكبير:
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

    # إضافة قسم إلى Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # إزالة قسم من Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **تنسيق أقسام ملخص التكبير**

لإنشاء كائنات أقسام ملخص التكبير أكثر تعقيدًا، عليك تعديل تنسيق إطار بسيط. هناك عدة خيارات تنسيق يمكنك تطبيقها على كائن قسم ملخص التكبير. 

يمكنك التحكم في تنسيق كائن قسم ملخص التكبير في إطار ملخص التكبير بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. إنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. إضافة إطار ملخص التكبير إلى الشريحة الأولى.
4. الحصول على كائن قسم ملخص التكبير الأول من `SummaryZoomSectionCollection`.
5. إنشاء كائن `PPImage` بإضافة صورة إلى مجموعة images المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) الذي سيُستخدم لملء الإطار.
6. ضبط صورة مخصصة لكائن إطار قسم التكبير الذي تم إنشاؤه.
7. ضبط القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*. 
8. تغيير تنسيق الخط لكائن الإطار التكبير الثاني.
9. تغيير مدة الانتقال.
10. كتابة العرض المعدل كملف PPTX.

يعرض لك هذا الكود بايثون كيفية تغيير تنسيق كائن قسم ملخص التكبير:
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

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**

نعم. يحتوي إطار [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) أو [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) على سلوك `return_to_parent` الذي، عند تمكينه، يعيد المشاهدين إلى الشريحة الأصلية بعد زيارة المحتوى المستهدف.

**هل يمكنني ضبط "السرعة" أو مدة انتقال التكبير؟**

نعم. يدعم Zoom ضبط `transition_duration` حتى تتمكن من التحكم في مدة حركة القفز.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها عرض تقديمي؟**

ليس هناك حد صريح موثق في API. الحدود العملية تعتمد على تعقيد العرض الإجمالي وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، ولكن يجب مراعاة حجم الملف ووقت الترحيل.