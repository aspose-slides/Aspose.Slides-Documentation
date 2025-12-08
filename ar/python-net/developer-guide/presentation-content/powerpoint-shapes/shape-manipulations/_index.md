---
title: إدارة الأشكال في العروض التقديمية باستخدام بايثون
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
- الحصول على معرف الشكل Interop
- نص بديل للشكل
- تنسيقات تخطيط الشكل
- شكل بصيغة SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل وتحسين الأشكال في Aspose.Slides for Python عبر .NET وتقديم عروض PowerPoint وOpenDocument عالية الأداء."
---

## **نظرة عامة**

يقدم هذا الدليل معالجة الأشكال في Aspose.Slides for Python عبر .NET. تعرّف على الأنماط العملية للعثور على الأشكال (بما في ذلك بواسطة النص البديل)، نسخها، حذفها أو إخفائها، إعادة ترتيبها، محاذاتها وقلبها، قراءة المعرفات وتنسيقها بناءً على التخطيط، وتصدير الأشكال الفردية إلى SVG باستخدام واجهتي برمجة التطبيقات [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) و [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

## **العثور على الأشكال في الشرائح**

يتعرف PowerPoint على الأشكال فقط عبر المعرفات الداخلية. قم بتعيين نص بديل فريد للشكل المستهدف في PowerPoint، ثم افتح العرض التقديمي باستخدام Aspose.Slides for Python، وكرر عبر أشكال الشريحة، واختر الشكل الذي يتطابق نصه البديل مع النص المعين. تُنفّذ الطريقة `find_shape` هذا النهج وتعيد الشكل المطابق.
```py
import aspose.slides as slides

# يبحث عن شكل في الشريحة بواسطة النص البديل الخاص به.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # البحث عن الشكل الذي لديه النص البديل "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **استنساخ الأشكال**

لاستنساخ الأشكال من شريحة مصدر إلى شريحة جديدة في Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) من الملف المصدر.
1. الحصول على الشريحة المصدر حسب الفهرس ومجموعتها من الأشكال.
1. استخراج تخطيط فارغ من الشريحة الرئيسية.
1. إضافة شريحة فارغة باستخدام ذلك التخطيط والحصول على أشكالها.
1. استنساخ الأشكال إلى الشريحة الهدف.
1. حفظ العرض التقديمي كملف PPTX.

الشفرة التالية توضح استنساخ الأشكال من شريحة إلى أخرى.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إزالة الأشكال**

تتيح لك Aspose.Slides إزالة أي شكل من الشريحة. على سبيل المثال، لحذف شكل من الشريحة الأولى باستخدام النص البديل الخاص به، اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل الملف.
1. الوصول إلى الشريحة الأولى من مجموعة الشرائح.
1. العثور على الشكل عبر قيمة النص البديل.
1. إزالة الشكل من مجموعة أشكال الشريحة.
1. حفظ العرض التقديمي على القرص بصيغة PPTX.
```py
import aspose.slides as slides

# يبحث عن شكل في شريحة بواسطة النص البديل الخاص به.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # ابحث عن الشكل الذي لديه النص البديل "User Defined".
    shape = find_shape(slide, "User Defined")
    # إزالة الشكل.
    slide.shapes.remove(shape)
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **إخفاء الأشكال**

تتيح لك Aspose.Slides إخفاء أي شكل على الشريحة. على سبيل المثال، لإخفاء شكل على الشريحة الأولى باستخدام النص البديل الخاص به، اتبع الخطوات التالية:

1. إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل الملف.
1. الوصول إلى الشريحة الأولى من مجموعة الشرائح.
1. العثور على الشكل عبر قيمة النص البديل.
1. إخفاء الشكل.
1. حفظ العرض التقديمي على القرص بصيغة PPTX.
```py
# يبحث عن شكل في الشريحة بواسطة النص البديل الخاص به.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # ابحث عن الشكل الذي لديه النص البديل "User Defined".
    shape = find_shape(slide, "User Defined")
    # إخفاء الشكل.
    shape.hidden = True
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **تغيير ترتيب الأشكال**

تسمح لك Aspose.Slides بإعادة ترتيب الأشكال (تغيير ترتيبها في المحور z). يحدد إعادة الترتيب أي شكل يظهر أمام أو خلف الآخر. على سبيل المثال، لإعادة ترتيب شكلين على الشريحة الأولى، اتبع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة الشكل الأول (مثلاً، مستطيل).
1. إضافة الشكل الثاني (مثلاً، مثلث).
1. إعادة ترتيب الأشكال بنقل الشكل الثاني إلى الموقع الأول في المجموعة.
1. حفظ العرض التقديمي على القرص.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # أضف شكلين إلى الشريحة.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # انقل الشكل الثاني إلى الموضع الأول.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الحصول على معرف الشكل Interop**

تتيح لك Aspose.Slides الحصول على معرف فريد للشكل على مستوى الشريحة، على عكس الخاصية `unique_id` التي تكون فريدة على مستوى العرض بأكمله. الخاصية `office_interop_shape_id` متوفرة على فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). قيمتها تتطابق مع الخاصية `Id` لكائن `Microsoft.Office.Interop.PowerPoint.Shape`. يُظهر المقتطف البرمجي التالي مثالاً على ذلك.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # احصل على المعرف الفريد للشكل داخل الشريحة.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **تعيين النص البديل للأشكال**

تسمح لك Aspose.Slides بتعيين نص بديل لأي شكل. يمكنك استخدام النص البديل لتحديد موقع الأشكال في العرض التقديمي. يمكن قراءة وكتابة خاصية النص البديل عبر Aspose.Slides وMicrosoft PowerPoint. من خلال وسم الأشكال بهذه الخاصية، يمكنك لاحقًا إزالتها أو إخفاؤها أو إعادة ترتيبها على الشريحة.

لتعيين النص البديل لشكل، اتبع الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل إلى الشريحة.
1. تعيين النص البديل.
1. حفظ العرض التقديمي على القرص.
```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation التي تمثل ملف PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # أضف شكلاً.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # تعيين النص البديل للشكل.
    shape.alternative_text = "User Defined"
    # حفظ العرض التقديمي إلى القرص.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الوصول إلى تنسيقات التخطيط للأشكال**

توفر Aspose.Slides واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط للأشكال. يوضح هذا القسم كيفية الوصول إلى تنسيقات التخطيط.
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **تحويل الأشكال إلى SVG**

تدعم Aspose.Slides تحويل الأشكال إلى SVG. تسمح لك الطريقة `write_as_svg` (وبالتحميلات المتعددة لها) على فئة [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) بحفظ محتويات الشكل كصورة SVG. يوضح المقتطف البرمجي أدناه كيفية تصدير شكل إلى ملف SVG.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # احصل على الشكل الأول في الشريحة الأولى.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **محاذاة الشكل**

باستخدام الطريقة `align_shape` في فئة [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)، يمكنك:

* محاذاة الأشكال بالنسبة لهوامش الشريحة (انظر **مثال 1**).
* محاذاة الأشكال بالنسبة لبعضها البعض (انظر **مثال 2**).

تحدد تعداد [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) خيارات المحاذاة المتاحة.

**مثال 1**

يعرض هذا الكود بايثون كيفية محاذاة الأشكال ذات الفهارس 1 و2 و4 إلى الحافة العلوية للشريحة:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**مثال 2**

يعرض هذا المثال بايثون كيفية محاذاة جميع الأشكال في مجموعة بالنسبة إلى الشكل الأدنى في تلك المجموعة:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **خصائص الانعكاس**

في Aspose.Slides، توفر فئة [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) التحكم في انعكاس الأشكال أفقيًا وعموديًا عبر خصائص `flip_h` و `flip_v`. كلا الخصائص من نوع [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/)، وتسمح بالقيم `TRUE` لتفعيل الانعكاس، `FALSE` لعدم الانعكاس، أو `NOT_DEFINED` لاستخدام السلوك الافتراضي. يمكن الوصول إلى هذه القيم من خلال [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) الشكل.

لتعديل إعدادات الانعكاس، يتم إنشاء مثيل جديد من [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) باستخدام الموقع الحالي وحجم الشكل، والقيم المطلوبة لـ `flip_h` و `flip_v`، وزاوية الدوران. يتم تعيين هذا المثيل إلى [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) الشكل وحفظ العرض التقديمي لتطبيق التحولات وتعزيزها في الملف الناتج.

لنفترض أننا نملك ملف sample.pptx يحتوي على شريحة أولى بها شكل واحد بإعدادات انعكاس افتراضية، كما هو موضح أدناه.

![الشكل المراد عكسه](shape_to_be_flipped.png)

المقتطف البرمجي التالي يستخرج خصائص الانعكاس الحالية للشكل ويقوم بقلبه أفقيًا وعموديًا.
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # استرجاع خاصية الانعكاس الأفقي للشكل.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # استرجاع خاصية الانعكاس العمودي للشكل.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # انعكاس أفقي وعمودي.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


النتيجة:

![الشكل المعكوس](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يمكنني دمج الأشكال (اتحاد/تقاطع/طرح) على شريحة كما في محرر سطح المكتب؟**

لا توجد واجهة برمجة تطبيقات مدمجة للعمليات البوليانية. يمكنك تقريب ذلك بإنشاء المخطط المطلوب يدويًا—مثلاً حساب الهندسة الناتجة عبر [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) وإنشاء شكل جديد بهذا الحد، مع إمكانية حذف الأشكال الأصلية.

**كيف يمكنني التحكم في ترتيب الطبقات (z-order) بحيث يبقى الشكل دائمًا “في القمة”?**

غيّر ترتيب الإدراج/النقل داخل مجموعة [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) للشفرة. للحصول على نتائج متوقعة، قم بتحديد ترتيب z بعد إتمام جميع التعديلات الأخرى على الشريحة.

**هل يمكنني “قفل” الشكل لمنع المستخدمين من تحريره في PowerPoint؟**

نعم. عيّن أعلام الحماية على مستوى الشكل [/slides/python-net/applying-protection-to-presentation/] (مثل قفل التحديد، الحركة، تغيير الحجم، تحرير النص). إذا لزم الأمر، طبق قيودًا مماثلة على القالب أو التخطيط. لاحظ أن هذه الحماية على مستوى واجهة المستخدم فقط، وليست ميزة أمان؛ للحصول على حماية أقوى، يمكن دمجها مع قيود على مستوى الملف مثل التوصيات للقراءة فقط أو كلمات المرور [/slides/python-net/password-protected-presentation/].