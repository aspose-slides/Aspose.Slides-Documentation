---
title: إدارة التكبير
type: docs
weight: 60
url: /ar/python-net/manage-zoom/
keywords: "تكبير، إطار التكبير، إضافة تكبير، تنسيق إطار التكبير، تكبير ملخص، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة تكبير أو إطارات تكبير لعرض PowerPoint في بايثون"
---

## **نظرة عامة**
تسمح لك التكبيرات في PowerPoint بالانتقال إلى من slides معينة، أقسام، وأجزاء من عرض تقديمي. عندما تقدم، قد تكون هذه القدرة على التنقل بسرعة عبر المحتوى مفيدة جدًا.

![overview](overview.png)

* لتلخيص عرض تقديمي كامل في شريحة واحدة، استخدم [تكبير الملخص](#Summary-Zoom).
* لإظهار الشرائح المحددة فقط، استخدم [تكبير الشريحة](#Slide-Zoom).
* لإظهار قسم واحد فقط، استخدم [تكبير القسم](#Section-Zoom).

## **تكبير الشريحة**

يمكن أن يجعل تكبير الشريحة عرضك أكثر ديناميكية، مما يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق عرضك التقديمي. تعد التكبيرات رائعة للعروض التقديمية القصيرة التي لا تحتوي على العديد من الأقسام، ولكن يمكنك استخدامها أيضًا في سيناريوهات تقديم مختلفة.

تساعدك تكبيرات الشريحة على الغوص في عدة معلومات بينما تشعر أنك على قماش واحد.

![slidezoomsel](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) التعداد، [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) الواجهة، وبعض الطرق في [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) الواجهة.

### **إنشاء إطارات التكبير**
يمكنك إضافة إطار تكبير على شريحة بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شرائح جديدة ترغب في الارتباط بها.
3. أضف نص تعريف وخلفية للشرائح التي تم إنشاؤها.
4. أضف إطارات تكبير (تحتوي على مراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النموذجي يوضح لك كيفية إنشاء إطار تكبير في شريحة:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # قم بإنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # قم بإنشاء صندوق نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "الشريحة الثانية"

    # قم بإنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # قم بإنشاء صندوق نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "الشريحة الثالثة"

    # أضف كائنات ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # حفظ العرض التقديمي
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **إنشاء إطارات التكبير باستخدام صور مخصصة**
مع Aspose.Slides لبايثون عبر .NET، يمكنك إنشاء إطار تكبير بصورة غير صورة معاينة الشريحة بهذه الطريقة:
1. قم بإنشاء مثيل من فئة `Presentation`.
2. قم بإنشاء شريحة جديدة ترغب في الارتباط بها.
3. أضف نص تعريف وخلفية للشريحة التي تم إنشاؤها.
4. قم بإنشاء [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) كائن عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الإطار.
5. أضف إطارات تكبير (تحتوي على مرجع إلى الشريحة التي تم إنشاؤها) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية إنشاء إطار تكبير بصورة مختلفة:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # قم بإنشاء خلفية للشريحة الثانية
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # قم بإنشاء صندوق نص للشريحة الثالثة
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "الشريحة الثانية"

    # قم بإنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # أضف كائن ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق إطارات التكبير**
في الأقسام السابقة (أعلاه)، أظهرنا لك كيفية إنشاء إطارات تكبير بسيطة. لإنشاء إطارات تكبير أكثر تعقيدًا، تحتاج إلى تعديل تنسيق الإطارات. هناك العديد من إعدادات التنسيق التي يمكنك تطبيقها على إطار التكبير.

يمكنك التحكم في تنسيق إطار التكبير في شريحة بهذه الطريقة:

1. قم بإنشاء مثيل من فئة `Presentation`.
2. قم بإنشاء شرائح جديدة للارتباط بها.
3. أضف نص تعريف وخلفية للشرائح التي تم إنشاؤها.
4. أضف إطارات تكبير (تحتوي على المراجع إلى الشرائح التي تم إنشاؤها) إلى الشريحة الأولى.
5. قم بإنشاء [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) كائن عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن العرض التقديمي الذي سيتم استخدامه لملء الإطار.
6. قم بتعيين صورة مخصصة لكائن إطار التكبير الأول.
7. قم بتغيير تنسيق الخط للكائن الثاني لإطار التكبير.
8. قم بإزالة الخلفية من صورة الكائن الثاني لإطار التكبير.
5. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية تغيير تنسيق إطار التكبير:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شرائح جديدة إلى العرض التقديمي
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # قم بإنشاء خلفية للشريحة الثانية
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # قم بإنشاء صندوق نص للشريحة الثانية
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "الشريحة الثانية"

    # قم بإنشاء خلفية للشريحة الثالثة
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # قم بإنشاء صندوق نص للشريحة الثالثة
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "الشريحة الثالثة"

    # أضف كائنات ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # قم بإنشاء صورة جديدة لكائن التكبير
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

تكبير القسم هو رابط إلى قسم في عرضك التقديمي. يمكنك استخدام تكبير الأقسام للعودة إلى الأقسام التي تريد التأكيد عليها حقًا. أو يمكنك استخدامها لتسليط الضوء على كيفية ارتباط بعض أجزاء عرضك التقديمي.

![seczoomsel](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) الواجهة وبعض الطرق تحت [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) الواجهة.

### **إنشاء إطارات تكبير القسم**

يمكنك إضافة إطار تكبير قسم إلى شريحة بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. قم بإنشاء قسم جديد ترغب في الارتباط بإطار التكبير.
5. أضف إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية إنشاء إطار تكبير على شريحة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 1", slide)

    # أضف كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # احفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **إنشاء إطارات تكبير القسم باستخدام صور مخصصة**

باستخدام Aspose.Slides لبايثون، يمكنك إنشاء إطار تكبير قسم بصورة مختلفة عن صورة معاينة الشريحة بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. قم بإنشاء قسم جديد ترغب في الارتباط بإطار التكبير.
5. قم بإنشاء كائن `IPPImage` عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والتي سيتم استخدامها لملء الإطار.
6. أضف إطار تكبير قسم (يحتوي على مرجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
7. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية إنشاء إطار تكبير بصورة مختلفة:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 1", slide)

    # قم بإنشاء صورة جديدة لكائن التكبير
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # أضف كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # احفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق إطارات تكبير القسم**

لإنشاء إطارات تكبير القسم الأكثر تعقيدًا، تحتاج إلى تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على إطار تكبير القسم.

يمكنك التحكم في تنسيق إطار تكبير القسم في شريحة بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شريحة جديدة.
3. أضف خلفية تعريف إلى الشريحة التي تم إنشاؤها.
4. قم بإنشاء قسم جديد ترغب في الارتباط بإطار التكبير.
5. أضف إطار تكبير قسم (يحتوي على مراجع إلى القسم الذي تم إنشاؤه) إلى الشريحة الأولى.
6. غير الحجم والموضع لكائن تكبير القسم الذي تم إنشاؤه.
7. قم بإنشاء كائن `IPPImage` عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والتي سيتم استخدامها لملء الإطار.
8. قم بتعيين صورة مخصصة لكائن إطار تكبير القسم الذي تم إنشاؤه.
9. قم بتعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
10. قم بإزالة الخلفية من صورة إطار تكبير القسم.
11. قم بتغيير تنسيق الخط لكائن إطار التكبير الثاني.
12. قم بتغيير مدة الانتقال.
13. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية تغيير تنسيق إطار تكبير القسم:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 1", slide)

    # إضافة كائن SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # التنسيق لإطار SectionZoomFrame
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

تكبير الملخص يشبه صفحة الهبوط حيث يتم عرض جميع أجزاء عرضك التقديمي دفعة واحدة. عندما تقدم، يمكنك استخدام التكبير للانتقال من مكان في عرضك التقديمي إلى آخر بأي ترتيب تريده. يمكنك أن تكون مبتكرًا، وتتخطى، أو تعيد زيارة أجزاء من عرض الشرائح الخاص بك دون مقاطعة تدفق عرضك التقديمي.

![overview_image](summaryzoom.png)

بالنسبة لكائنات تكبير الملخص، توفر Aspose.Slides [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/) و [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) و [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) الواجهات وبعض الطرق في [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) الواجهة.

### **إنشاء تكبير ملخص**

يمكنك إضافة إطار تكبير ملخص إلى شريحة بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تكبير ملخص إلى الشريحة الأولى.
4. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية إنشاء إطار تكبير ملخص على شريحة:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أنشئ مصفوفة من الشرائح
    for slideNumber in range(5):
        # أضف شرائح جديدة إلى العرض التقديمي
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # قم بإنشاء خلفية للشريحة
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # قم بإنشاء صندوق نص للشريحة
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "شريحة - {num}".format(num = (slideNumber + 2))

    # قم بإنشاء كائنات تكبير لجميع الشرائح في الشريحة الأولى
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # تعيين خاصية ReturnToParent للعودة إلى الشريحة الأولى
        zoomFrame.return_to_parent = True

    # حفظ العرض التقديمي
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة وإزالة قسم تكبير الملخص**

تُRepresent جميع الأقسام في إطار تكبير الملخص بواسطة كائنات [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/)، التي يتم تخزينها في كائن [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). يمكنك إضافة أو إزالة كائن قسم تكبير الملخص من خلال واجهة [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تكبير ملخص إلى الشريحة الأولى.
4. أضف شريحة جديدة وقسمًا إلى العرض التقديمي.
5. أضف القسم الذي تم إنشاؤه إلى إطار تكبير الملخص.
6. أزل القسم الأول من إطار تكبير الملخص.
7. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية إضافة وإزالة الأقسام في إطار تكبير الملخص:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 1", slide)

    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 2", slide)

    # أضف كائن SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    section3 = pres.sections.add_section("القسم 3", slide)

    # أضف قسم إلى تكبير الملخص
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # ازالة القسم من تكبير الملخص
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # حفظ العرض التقديمي
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **تنسيق أقسام تكبير الملخص**

لإنشاء كائنات أقسام تكبير ملخص أكثر تعقيدًا، تحتاج إلى تعديل تنسيق إطار بسيط. هناك العديد من خيارات التنسيق التي يمكنك تطبيقها على كائن قسم تكبير الملخص.

يمكنك التحكم في التنسيق لكائن قسم تكبير الملخص في إطار تكبير الملخص بهذه الطريقة:

1. قم بإنشاء مثيل من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2. قم بإنشاء شرائح جديدة مع خلفية تعريف وأقسام جديدة للشرائح التي تم إنشاؤها.
3. أضف إطار تكبير ملخص إلى الشريحة الأولى.
4. احصل على كائن قسم تكبير الملخص الأول من `ISummaryZoomSectionCollection`.
5. قم بإنشاء كائن `IPPImage` عن طريق إضافة صورة إلى مجموعة الصور المرتبطة بكائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والتي سيتم استخدامها لملء الإطار.
6. قم بتعيين صورة مخصصة لكائن قسم تكبير الملخص الذي تم إنشاؤه.
7. قم بتعيين القدرة على *العودة إلى الشريحة الأصلية من القسم المرتبط*.
8. قم بتغيير تنسيق الخط لكائن إطار التكبير الثاني.
9. قم بتغيير مدة الانتقال.
10. اكتب العرض التقديمي المعدل كملف PPTX.

هذا الرمز النمطي يوضح لك كيفية تغيير التنسيق لكائن قسم تكبير الملخص:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 1", slide)

    # أضف شريحة جديدة إلى العرض التقديمي
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # أضف قسم جديد إلى العرض التقديمي
    pres.sections.add_section("القسم 2", slide)

    # أضف كائن SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # الحصول على كائن First SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # التنسيق لكائن SummaryZoomSection
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