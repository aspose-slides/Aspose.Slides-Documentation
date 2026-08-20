---
title: إدارة أشكال العرض التقديمي في بايثون
linktitle: تعديل الأشكال
type: docs
weight: 40
url: /ar/python-net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ الشكل
- حذف الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل عبر interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- انعكاس الشكل
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية تحديد، استنساخ، حذف، إخفاء، إعادة ترتيب، تصدير، محاذاة، وعكس أشكال العرض التقديمي باستخدام Aspose.Slides for Python عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET يمثل الأشكال على الشريحة كـ [ShapeCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/) مرتبة. تُعد المجموعة كلًا من المكان الذي تجد فيه وتُعدل فيه الأشكال ومصدر ترتيبها الطبقي: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد الشكل بشكل موثوق، ثم يُظهر كيفية استنساخ، حذف، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العمليات المطلوبة فقط في سير عملك.

## **تحديد وإيجاد الأشكال**

تُعد فهارس المجموعة ملائمة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. قد يؤدي إضافة، حذف، أو إعادة ترتيب شكل إلى تغيير فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Shape.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/name/) مفيد للقوالب التي يتحكم فيها المطورون ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تحرير الأسماء ولا يُضمن أن تكون فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [Shape.alternative_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/alternative_text/) مفيد عندما يحدد وصف الوصول أو العلامة التي يضيفها المؤلف الشكل بالفعل. هو مرئي للمستخدمين، قد يُمحَّل أو يُعاد كتابته لاحتياجات الوصول، ولا يضمن أن يكون فريدًا. لا تُعيد استخدام نص وصول ذو معنى كمفتاح قاعدة بيانات بصمت.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/office_interop_shape_id/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم من قِبل PowerPoint interop. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع غير قابل للغموض طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشائه يُعد شكلًا مختلفًا ويحصل على معرف خاص به.

الخاصية المرتبطة [Shape.unique_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/unique_id/) لها نطاق عرض تقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي اعتبارها مفتاحًا خارجيًا دائمًا. إذا كان التعرف طويل الأمد ضروريًا، احتفظ بالتخطيط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن `name` بمقارنة مطابقة ويبلغ عن معرف interop المقيد بالعرض. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن ذلك بدلًا من الاستمرار مع كائن غير صحيح.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    target_shape = None
    for shape in slide.shapes:
        if shape.name == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print("Found {}; interop ID: {}".format(target_shape.name, target_shape.office_interop_shape_id))
```

عند كون العملية محددة لنوع شكل معين، تحقق من النوع قبل استخدام الأعضاء الخاصة بالنوع. يحدّث هذا المثال النص والنص البديل فقط إذا كان الكائن المُسمى هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    candidate = None
    for shape in slide.shapes:
        if shape.name == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, slides.AutoShape):
        candidate.text_frame.text = "Approved"
        candidate.alternative_text = "Approval status: approved"
        presentation.save("identified-shape.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
```

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، الاستنساخ، الحذف، وإعادة الترتيب على المجموعة مباشرة. إذا غيّرت عملية ما عدد الأشكال أو ترتيبها، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_clone/) ينشئ نسخة مستقلة ويضيفها إلى مجموعة الوجهة. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/insert_clone/) ينشئ نسخة أيضًا لكنه يضعها في فهرس z-order محدد. التحميل الزائد الذي يقبل إحداثيات يحرّك النسخة دون تغيير حجمها؛ التحميل الزائد مع العرض والارتفاع يمكنه تعديل الحجم أيضًا.

المثال ينشئ شريحة هدف، يستنسخ مستطيلًا مسمى إلى الأمام، ويدرج نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدّل الشكل الأصلي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    source_slide = presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 180, 60)
    source_shape.name = "SourceLabel"
    source_shape.text_frame.text = "Source"

    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    destination_slide = presentation.slides.add_empty_slide(blank_layout)

    front_clone_shape = destination_slide.shapes.add_clone(source_shape, 80, 80)
    front_clone_shape.name = "FrontClone"
    if isinstance(front_clone_shape, slides.AutoShape):
        front_clone_shape.text_frame.text = "Front clone"
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.shapes.insert_clone(0, source_shape, 80, 180)
    back_clone_shape.name = "BackClone"
    if isinstance(back_clone_shape, slides.AutoShape):
        back_clone_shape.text_frame.text = "Back clone"
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بهوية شكل جديدة.

### **حذف الأشكال**

[ShapeCollection.remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند حذف تطابقات متعددة خلال تكرار فهرس، اعبر من النهاية حتى يظل كل فهرس متبقي صالحًا.

هذا المثال يحذف كل شكل يحمل اسمًا معينًا. يقرأ `slide.shapes[index]` وليس عنصر مجموعة ثابت، ولا يحول الشكل بشكل غير ضروري.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    keep_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 140, 60)
    keep_shape.name = "Keep"

    first_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 220, 40, 80, 80)
    first_temporary_shape.name = "Temporary"

    second_temporary_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 340, 40, 100, 80)
    second_temporary_shape.name = "Temporary"

    for index in range(len(slide.shapes) - 1, -1, -1):
        shape = slide.shapes[index]
        if shape.name == "Temporary":
            slide.shapes.remove(shape)

    presentation.save("removed-shapes.pptx", slides.export.SaveFormat.PPTX)
```

بعد الحذف، يتغير عدد الأشكال وفهارس الأشكال اللاحقة. تظل المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في الاعتبار الموصلات، الرسوم المتحركة، وغير ذلك من ميزات العرض التي قد تشير إلى الكائن المحذوف؛ حذف شكل مرئي قد يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

تعيين [Shape.hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/hidden/) إلى `True` يبقي الشكل في المجموعة لكن يمنعه من الظهور في العرض العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا يُعد الإخفاء مناسبًا للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    visible_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 160, 60)
    visible_shape.name = "VisibleLabel"

    optional_shape = slide.shapes.add_auto_shape(slides.ShapeType.MOON, 240, 40, 100, 100)
    optional_shape.name = "OptionalDecoration"

    for shape in slide.shapes:
        if shape.name == "OptionalDecoration":
            shape.hidden = True

    presentation.save("hidden-shape.pptx", slides.export.SaveFormat.PPTX)
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهار его مرة أخرى من قبل المستخدم أو الكود، ويظل جزءًا من ملف العرض.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم وفقًا لترتيب المجموعة. [ShapeCollection.reorder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `len(slide.shapes) - 1` هو الأمام.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    blue_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 220, 120)
    blue_rectangle.name = "BlueRectangle"
    blue_rectangle.fill_format.fill_type = slides.FillType.SOLID
    blue_rectangle.fill_format.solid_fill_color.color = draw.Color.steel_blue

    orange_ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 180, 140, 220, 120)
    orange_ellipse.name = "OrangeEllipse"
    orange_ellipse.fill_format.fill_type = slides.FillType.SOLID
    orange_ellipse.fill_format.solid_fill_color.color = draw.Color.orange

    slide.shapes.reorder(len(slide.shapes) - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", slides.export.SaveFormat.PPTX)
```

يُنشأ المستطيل أولًا ويقع في البداية خلف القطعة البيضاوية. نقله إلى الفهرس النهائي يضعه في الأمام. أكمل ترتيب Z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن هذه العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تغير المكدس المقصود.

## **فحص الأشكال في شرائح التخطيط**

لشرائح عادية، وشرائح تخطيط، وشرائح رئيسية مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل المماثل في الشريحة العادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق مقدم من التخطيط.

المثال التالي يقرأ كل شكل تخطيط عبر خاصية [Shape.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/fill_format/) و[Shape.line_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/line_format/) دون افتراض أن كل شكل هو `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

تحرير تخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/write_as_svg/) يكتب محتوى شكل واحد مُصوَّر إلى تدفق. النتيجة تحتوي على الشكل فقط، وليس خلفية الشريحة بالكامل أو الأشكال المجاورة.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.shapes[0]
        with open("shape.svg", "wb") as svg_stream:
            shape.write_as_svg(svg_stream)
```

احتفظ بالعرض مفتوحًا أثناء التصيير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى التكوين الكامل، صدّر الشريحة بدلاً من الشكل الفردي. المتصل يمتلك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/align_shapes/) تُحدث إما جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapesalignmenttype/) يحدد الحافة، الخط المركزي، أو وضع التوزيع. اضبط `align_to_slide` إلى `True` لاستخدام حواف الشريحة؛ اضبطه إلى `False` لمحاذاة الأشكال المختارة بالنسبة إلى بعضها البعض.

هذا المثال يُحاذي ثلاث أشكال إلى الحافة العليا للشريحة. تُحل فهارسهم الحالية مباشرةً قبل المحاذاة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 60, 80, 120, 50)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 240, 160, 120, 50)
    third_shape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 420, 240, 120, 50)
    first_shape.name = "FirstAlignedShape"
    second_shape.name = "SecondAlignedShape"
    third_shape.name = "ThirdAlignedShape"

    shape_indexes = [
        slide.shapes.index_of(first_shape),
        slide.shapes.index_of(second_shape),
        slide.shapes.index_of(third_shape)
    ]

    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", slides.export.SaveFormat.PPTX)
```

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادة ما تحتاج إلى شكلين على الأقل، بينما التوزيع الأفقي أو الرأسي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفجوات. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapeframe/) تخزن الموضع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `flip_h` و `flip_v` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/python-net/aspose.slides/nullablebool/): `TRUE` يُفعّل الانعكاس، `FALSE` يُعطّله، و `NOT_DEFINED` يحافظ على الحالة غير المحددة أو الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![الشكل قبل الانعكاس](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل فقط إعدادات الانعكاس الاثنين. هذا مهم لأن تعيين [Shape.frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/frame/) جديد يستبدل الإطار بالكامل.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    frame = shape.frame

    print("Horizontal flip before change:", frame.flip_h)
    print("Vertical flip before change:", frame.flip_v)

    shape.frame = slides.ShapeFrame(
        frame.x, frame.y, frame.width, frame.height,
        slides.NullableBool.TRUE, slides.NullableBool.TRUE, frame.rotation)

    presentation.save("flipped-shape.pptx", slides.export.SaveFormat.PPTX)
```

الشكل المحفوظ مُنعكس أفقيًا وعموديًا مع الحفاظ على موضعه وحجمه ودورانه.

![الشكل بعد الانعكاس](flipped_shape.png)

## **الأسئلة الشائعة**

**هل ينبغي علي استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغير المجموعة قبل استخدام الفهرس. يفضَّل الاعتماد على `name` أو `alternative_text` مع اتفاقية مُتحقق منها للقوالب التي يكتبها المؤلف، أو `office_interop_shape_id` لأعمال interop المقيدة بالشرائح.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة بنفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`add_clone` يضيف النسخة إلى نهاية المجموعة، وهي أمام ترتيب Z. استخدم `insert_clone` لتحديد الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.