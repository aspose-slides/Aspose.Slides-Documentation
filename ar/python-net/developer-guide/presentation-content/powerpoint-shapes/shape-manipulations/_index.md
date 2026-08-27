---
title: إدارة أشكال العرض التقديمي في بايثون
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/python-net/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- العثور على شكل
- استنساخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل interop
- النص البديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المحدد مسبقًا
- هندسة الشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- انعكاس الشكل
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي وتعديلها واستنساخها وإزالتها وإخفائها وإعادة ترتيبها وتصديرها ومحاذاتها وعكسها باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

Aspose.Slides for Python via .NET تمثّل الأشكال في الشريحة كـ [ShapeCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/) مرتّبة. هذه المجموعة هي المكان الذي تجد فيه الأشكال وتُعدّلها ومصدر ترتيب طبقاتها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

تتبع هذه المقالة هذا النموذج. أولاً يشرح كيف تحدد الشكل بثقة وتُعدّل نقاط ضبط الشكل المحددة مسبقًا، ثم يوضح كيفية استنساخ، حذف، إخفاء، وإعادة ترتيب الأشكال. الأقسام الأخيرة تغطي تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، بحيث يمكنك استخدام العمليات التي يحتاجها سير عملك فقط.

## **تحديد وإيجاد الأشكال**

فهارس المجموعة مفيدة أثناء معالجة ملف معروف، لكنّها ليست معرفات ثابتة. إضافة أو حذف أو إعادة ترتيب شكل قد يغيّر فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Shape.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/name/) مفيد للقوالب التي يتحكم بها المطور ويسهل فحصه في لوحة الاختيار في PowerPoint. يمكن تعديل الأسماء ولا يُضمن تفردها، لذا ضع قاعدة تسمية إذا كان الكود يعتمد عليها.
- [Shape.alternative_text](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/alternative_text/) مفيد عندما تكون وصفية إمكانية الوصول أو وسمًا يضيفه المؤلف لتحديد الشكل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد صياغته لتوافق إمكانية الوصول، ولا يُضمن تفرده. لا تُعيد استخدام نص إمكانية الوصول ذي المعنى كمفتاح قاعدة بيانات.
- [Shape.office_interop_shape_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/office_interop_shape_id/) هو معرف قراءة فقط فريد داخل الشريحة ويتوافق مع معرف الشكل المستخدم في PowerPoint interop. استخدمه عند الدمج مع PowerPoint أو عندما تحتاج إلى مرجع واضح طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه هو شكل مختلف ويحصل على معرف خاص به.

خصائص [Shape.unique_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/unique_id/) ذات نطاق عرض تقديمي، لكنها موجهة للإضافات ويمكن إعادة تعيينها. لا تُعاملها كمفتاح خارجي دائم. إذا كانت الهوية طويلة الأمد ضرورية، احتفظ بالتخطيط في بيانات التطبيق وتأكد من أن الشكل المتوقع ما يزال موجودًا.

المثال التالي يبحث عن `name` بالمقارنة الدقيقة ويُبلغ عن معرف interop ذو نطاق الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يبلغ الكود عن تلك النتيجة بدلاً من المتابعة مع كائن خاطئ.

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

عند كون العملية خاصة بنوع شكل معين، افحص النوع قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يحدّث النص والنص البديل فقط إذا كان الكائن المسمي هو [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/).

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

## **تحديد وتعديل ضبط الشكل المحدد مسبقًا**

الأشكال الهندسية المحددة مسبقًا قد تكشف عن نقاط ضبط تتحكم في ميزات مثل حجم الزوايا، نسب السهم، أو زوايا القوس. يمكن الوصول إليها عبر مجموعة القراءة فقط [GeometryShape.adjustments](https://reference.aspose.com/slides/ar/python-net/aspose.slides/geometryshape/adjustments/). المجموعة نفسها تُقدّمها الشكل، لكن كل [AdjustValue](https://reference.aspose.com/slides/ar/python-net/aspose.slides/adjustvalue/) يحتوي على قيمة يمكن تغيّرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحص خاصية القراءة فقط [AdjustValue.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/adjustvalue/type/)، التي تصف قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapeadjustmenttype/) ما يتحكم به الضبط. خاصية القراءة فقط [AdjustValue.name](https://reference.aspose.com/slides/ar/python-net/aspose.slides/adjustvalue/name/) توفر معلومات تعريف إضافية وتكون مفيدة خاصةً عندما يحتوي الشكل المحدد على أكثر من ضبط من نفس النوع الدلالي.

استخدم خاصية القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة التي تُغيّر |
|---|---|---|
| `CORNER_SIZE` | حجم الزوايا المستديرة | [raw_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides/adjustvalue/raw_value/) |
| `ARROW_TAIL_THICKNESS` | سمك ذيل السهم | `raw_value` |
| `ARROWHEAD_LENGTH` | طول رأس السهم | `raw_value` |
| `ARROWHEAD_WIDTH` | عرض رأس السهم | `raw_value` |
| `START_ANGLE` | زاوية البدء لفطيرة أو قوس | [angle_value](https://reference.aspose.com/slides/ar/python-net/aspose.slides/adjustvalue/angle_value/) |
| `END_ANGLE` | زاوية النهاية لفطيرة أو قوس | `angle_value` |

لا يمكن تعيين `type` و `name`. `raw_value` هو عدد صحيح قابل للقراءة والكتابة بوحدات الهندسة الأصلية للشكل، بينما `angle_value` هو زاوية قابلة للقراءة والكتابة بالدرجات. عدد، ترتيب، معنى، والنطاق الصالح للضبط يعتمد على [GeometryShape.shape_type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/geometryshape/shape_type/). قد تكون القيمة صالحة لتخطيط واحد وغير صالحة أو ذات تأثير مختلف لتخطيط آخر.

عندما يكون `type` هو `ShapeAdjustmentType.CUSTOM`، لا يتعرف API على معنى دلالي قياسي. افحص `name`، نوع التخطيط، والقيمة الحالية، واترك الضبط دون تغيير إلا إذا كان المعنى والنطاق معروفين. حتى للأنواع المعروفة، تحقّق ما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. مقالة [Connector](/slides/ar/python-net/connector/) توضح هذا الوضع مع ضبط انحناءات الموصل.

المثال الكامل التالي ينشئ إصدارات افتراضية ومعدّلة لثلاثة أشكال محددة مسبقًا. يمرّ عبر كل ضبط، يُبلغ عن `name` و `type`، يغيّر القيم المتعلقة بالحجم عبر `raw_value`، ويغيّر الزوايا عبر `angle_value`، ثم يحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المعدّل، السهم رباعي الاتجاهات، والفطيرة.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة عناوين للأعمدة الافتراضية والعمود المعدل للأشكال.
    default_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 20, 250, 30)
    default_column_label.text_frame.text = "Default preset geometry"
    adjusted_column_label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 390, 20, 250, 30)
    adjusted_column_label.text_frame.text = "Modified adjustment values"

    slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 430, 70, 160, 70)
    modified_rounded_rectangle.name = "ModifiedRoundedRectangle"

    slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 80, 180, 160, 110)
    modified_arrow = slide.shapes.add_auto_shape(slides.ShapeType.QUAD_ARROW, 430, 180, 160, 110)
    modified_arrow.name = "ModifiedQuadArrow"

    slide.shapes.add_auto_shape(slides.ShapeType.PIE, 95, 330, 130, 130)
    modified_pie = slide.shapes.add_auto_shape(slides.ShapeType.PIE, 445, 330, 130, 130)
    modified_pie.name = "ModifiedPie"

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment in shape.adjustments:
            print("{} / {}: {}".format(shape.name, adjustment.name, adjustment.type.name))

            if adjustment.type == slides.ShapeAdjustmentType.CORNER_SIZE:
                adjustment.raw_value = 5000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROW_TAIL_THICKNESS:
                adjustment.raw_value = 25000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_LENGTH:
                adjustment.raw_value = 30000
            elif adjustment.type == slides.ShapeAdjustmentType.ARROWHEAD_WIDTH:
                adjustment.raw_value = 40000
            elif adjustment.type == slides.ShapeAdjustmentType.START_ANGLE:
                adjustment.angle_value = 30
            elif adjustment.type == slides.ShapeAdjustmentType.END_ANGLE:
                adjustment.angle_value = 300
            elif adjustment.type == slides.ShapeAdjustmentType.CUSTOM:
                print("Custom adjustment '{}' was not changed.".format(adjustment.name))

    presentation.save("preset-shape-adjustments.pptx", slides.export.SaveFormat.PPTX)
```

التحقق من النوع الدلالي قبل تغيير القيمة يجعل الكود واضحًا بشأن نيته ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال محددة مختلفة.

## **تعديل مجموعة الأشكال**

طرق الإضافة، الاستنساخ، الحذف، وإعادة الترتيب تعمل على المجموعة مباشرة. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تستمر بالاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[ShapeCollection.add_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_clone/) ينشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة الهدف. [ShapeCollection.insert_clone](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/insert_clone/) أيضاً ينشئ نسخة لكنه يضعها في فهرس z-order محدد. التحميل الزائد الذي يقبل إحداثيات ينقل النسخة دون تغيير حجمها؛ التحميل الزائد مع العرض والارتفاع يمكنه تعديل حجمه أيضًا.

المثال ينشئ شريحة هدف، يستنسخ مستطيلًا معنًا إلى الأمام، ويُدرج نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدّل الشكل المصدر.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد التي تستخدمها الأشكال المعقّدة يُديرها العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة بهوية شكل جديدة.

### **حذف أشكال**

[ShapeCollection.remove](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/remove/) يحذف كائن شكل معين من مجموعته. عند حذف تطابقات متعددة أثناء تكرار مفهرس، تجول من النهاية بحيث يظل كل فهرس متبقي صالحًا.

هذا المثال يحذف كل شكل يحمل اسمًا معينًا. يقرأ `slide.shapes[index]`، ليس عنصر مجموعة ثابت، ولا يفرض تحويل الشكل بصورة غير ضرورية.

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

بعد الحذف، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. المراجع إلى الأشكال غير المتأثرة تظل أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المحذوف؛ حذف شكل مرئي قد يغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Shape.hidden](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/hidden/) إلى `True` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يبقى فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهاره مرة أخرى من قبل مستخدم أو كود، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير Z-Order**

الأشكال المتقاطعة تُرسم بترتيب المجموعة. [ShapeCollection.reorder](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `len(slide.shapes) - 1` هو الأمام.

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

المستطيل يُنشأ أولاً ويقع في البداية خلف القطعة البيضاوية. نقله إلى الفهرس النهائي يجعله في الأمام. استكمل ترتيب z بعد إضافة أو استنساخ جميع الأشكال المرتبطة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة وقد تُغيّر المكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، والشرائح الرئيسة لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس هو نفسه الشكل المماثل في شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق يُقَدَّم من قبل تخطيط.

المثال التالي يقرأ كل [Shape.fill_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/fill_format/) و[Shape.line_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/line_format/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        for shape in layout_slide.shapes:
            fill_type = shape.fill_format.fill_type
            line_width = shape.line_format.width
            print("{} / {}: fill={}, line width={}".format(layout_slide.name, shape.name, fill_type, line_width))
```

تحرير تخطيط قد يؤثر على شرائح متعددة تستخدمه. قبل تغيير شكل تخطيط، حدد ما إذا كانت شريحة عادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[Shape.write_as_svg](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/write_as_svg/) يكتب محتوى شكل واحد مُرَسَّم إلى تدفق. النتيجة تحتوي على الشكل فقط، وليس الخلفية الكاملة للشريحة أو الأشكال المجاورة.

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

ابقِ العرض التقديمي مفتوحًا أثناء التصيير. يعتمد الإخراج على تنسيق الشكل وعلى الموارد مثل الخطوط والصور. إذا كنت تحتاج إلى التكوين الكامل، صدّر الشريحة بدلًا من شكل فردي. المتصل يملك التدفق ويجب أن يغلقه.

## **محاذاة الأشكال**

[SlideUtil.align_shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/align_shapes/) لديها تحميلات تتماشى إما مع جميع الأشكال أو مع فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapesalignmenttype/) يحدد الحافة، الخط المركزي، أو وضع التوزيع. اضبط `align_to_slide` إلى `True` لاستخدام حواف الشريحة؛ اضبطه إلى `False` لمطابقة الأشكال المختارة على بعضها البعض.

هذا المثال يطابق ثلاثة أشكال إلى الحافة العليا للشريحة. تُحَلُّ الفهارس الحالية فورًا قبل المحاذاة.

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

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تحتاج على الأقل إلى شكلين، في حين أن التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدلت المجموعة قبل استدعاء الطريقة.

## **انعكاس شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides.shapeframe/) تخزّن الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `flip_h` و `flip_v` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/python-net/aspose.slides/nullablebool/): `TRUE` يُفعِّل الانعكاس، `FALSE` يُعطّله، و `NOT_DEFINED` يحافظ على الحالة غير المحددة أو الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل واحد غير مقلوب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحتفظ بكل قيمة إطار أخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Shape.frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/frame/) جديد يُستبدل الإطار الكامل.

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

الشكل المحفوظ مقلوبًا أفقيًا وعموديًا مع الحفاظ على موقعه، حجمه، ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة الشائعة**

**هل يجب علي استخدام فهرس المجموعة كمُعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لا تتغيّر المجموعة قبل استخدام الفهرس. يفضَّل الاعتماد على `name` أو `alternative_text` بعد التحقق في القوالب المصمَّمة، أو `office_interop_shape_id` لأعمال interop ذات نطاق شريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر شكل مستنسخ أمام شكل آخر؟**

`add_clone` يضيف النسخة إلى نهاية المجموعة، وهي الأمام في ترتيب Z. استخدم `insert_clone` لاختيار الفهرس الأولي أو `reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل محدد مسبقًا؟**

فقط بعد التحقق من التخطيط المحدد وتخطيط المجموعة. يفضَّل التكرار عبر `GeometryShape.adjustments` والتحقق من `AdjustValue.type`؛ استخدم `AdjustValue.name` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.