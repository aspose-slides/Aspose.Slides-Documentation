---
title: تح manipulaciones الشكل
type: docs
weight: 40
url: /python-net/shape-manipulations/
keywords: "شكل PowerPoint، شكل على الشريحة، العثور على شكل، استنساخ شكل، إزالة شكل، إخفاء شكل، تغيير ترتيب الشكل، الحصول على معرف الشكل المشترك، نص بديل للشكل، تنسيقات تخطيط الشكل، شكل كـ SVG، محاذاة الشكل، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "معالجة أشكال PowerPoint في بايثون"
---

## **العثور على شكل في الشريحة**
هذا الموضوع سيوصف تقنية بسيطة لتسهيل مهمة المطورين في العثور على شكل معين في شريحة دون استخدام معرفه الداخلي. من المهم أن نعرف أن ملفات عروض PowerPoint لا تحتوي على أي وسيلة لتحديد الأشكال على الشريحة باستثناء معرف فريد داخلي. يبدو أنه من الصعب على المطورين العثور على شكل باستخدام معرفه الفريد الداخلي. جميع الأشكال المضافة إلى الشرائح تحتوي على نص بديل. نحن نقترح على المطورين استخدام النص البديل للعثور على شكل معين. يمكنك استخدام MS PowerPoint لتحديد النص البديل للعناصر التي تخطط لتغييرها في المستقبل.

بعد تعيين النص البديل لأي شكل مرغوب فيه، يمكنك بعد ذلك فتح هذا العرض باستخدام Aspose.Slides لـ بايثون عبر .NET والتمرير عبر جميع الأشكال المضافة إلى الشريحة. خلال كل تكرار، يمكنك التحقق من النص البديل للشكل وسيكون الشكل الذي يطابق النص البديل هو الشكل المطلوب منك. لإظهار هذه التقنية بشكل أفضل، قمنا بإنشاء طريقة، [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) التي تقوم بالتحيل لإيجاد شكل معين في الشريحة ثم تعيد ببساطة هذا الشكل.

```py
import aspose.slides as slides

# تنفيذ الطريقة للعثور على شكل في الشريحة باستخدام نصه البديل
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# إنشاء كائن من فئة Presentation التي تمثل ملف العرض
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # نص بديل الشكل الذي سيتم العثور عليه
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("اسم الشكل: " + shape.name)
```



## **استنساخ شكل**
لاستنساخ شكل إلى شريحة باستخدام Aspose.Slides لـ بايثون عبر .NET:

1. أنشئ مثالا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع لشريحة باستخدام فهرسها.
1. الوصول إلى مجموعة أشكال الشريحة المصدر.
1. أضف شريحة جديدة إلى العرض.
1. استنسخ الأشكال من مجموعة أشكال الشريحة المصدر إلى الشريحة الجديدة.
1. احفظ العرض المعدل كملف PPTX.

المثال أدناه يضيف شكل مجموعة إلى شريحة.

```py
import aspose.slides as slides

# إنشاء كائن من فئة Presentation
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# كتابة ملف PPTX إلى القرص
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إزالة شكل**
يسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بإزالة أي شكل. لإزالة الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. أنشئ مثالا من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل محدد.
1. إزالة الشكل.
1. حفظ الملف إلى القرص.

```py
import aspose.slides as slides

# إنشاء كائنPresentation
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع المستطيل
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "مستخدم محدد"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # حفظ العرض إلى القرص
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إخفاء شكل**
يسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بإخفاء أي شكل. لإخفاء الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. أنشئ مثالا من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. العثور على الشكل بنص بديل محدد.
1. إخفاء الشكل.
1. حفظ الملف إلى القرص.

```py
import aspose.slides as slides

# إنشاء كائن Presentation الذي يمثل PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع المستطيل
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "مستخدم محدد"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # حفظ العرض إلى القرص
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تغيير ترتيب الأشكال**
يسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بإعادة ترتيب الأشكال. إعادة ترتيب الشكل تحدد أي شكل هو في المقدمة أو أي شكل في الخلف. لإعادة ترتيب الشكل من أي شريحة، يرجى اتباع الخطوات أدناه:

1. أنشئ مثالا من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة شكل.
1. إضافة بعض النص في إطار نص الشكل.
1. إضافة شكل آخر بنفس الإحداثيات.
1. إعادة ترتيب الأشكال.
1. حفظ الملف إلى القرص.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="نص العلامة المائية نص العلامة المائية نص العلامة المائية"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **الحصول على معرف الشكل المشترك**
يسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بالحصول على مُعرف شكل فريد في نطاق الشريحة على عكس خاصية UniqueId، التي تسمح بالحصول على مُعرف فريد في نطاق العرض. تمت إضافة خاصية OfficeInteropShapeId إلى واجهات IShape وفئة Shape على التوالي. القيمة المعادة بواسطة خاصية OfficeInteropShapeId تتوافق مع قيمة معرف كائن Microsoft.Office.Interop.PowerPoint.Shape. أدناه هو نموذج كود مقدم.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # الحصول على معرف شكل فريد في نطاق الشريحة
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **تعيين نص بديل للشكل**
يسمح Aspose.Slides لـ بايثون عبر .NET للمطورين بتعيين AlternateText لأي شكل. 
يمكن تمييز الأشكال في العرض باستخدام النص البديل أو خاصية اسم الشكل. 
يمكن قراءة خاصية AlternativeText أو تعيينها باستخدام Aspose.Slides وأيضا Microsoft PowerPoint. 
باستخدام هذه الخاصية، يمكنك وسم شكل ويمكنك إجراء عمليات مختلفة مثل إزالة شكل، 
إخفاء شكل أو إعادة ترتيب الأشكال على شريحة.
لتعيين النص البديل لشكل، يرجى اتباع الخطوات أدناه:

1. أنشئ مثالا من فئة `Presentation`.
1. الوصول إلى الشريحة الأولى.
1. إضافة أي شكل إلى الشريحة.
1. القيام ببعض الأعمال مع الشكل المضاف حديثا.
1. اجتياز الأشكال للعثور على شكل.
1. تعيين النص البديل.
1. حفظ الملف إلى القرص.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# إنشاء كائن Presentation الذي يمثل PPTX
with slides.Presentation() as pres:
    # الحصول على الشريحة الأولى
    sld = pres.slides[0]

    # إضافة شكل تلقائي من نوع المستطيل
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "مستخدم محدد"

    # حفظ العرض إلى القرص
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **الوصول إلى تنسيقات التخطيط للشكل**
 يوفر Aspose.Slides لـ بايثون عبر .NET واجهة برمجة تطبيقات بسيطة للوصول إلى تنسيقات التخطيط لشكل. توضح هذه المقالة كيف يمكنك الوصول إلى تنسيقات التخطيط.

الكود النموذجي أدناه.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **عرض شكل كـ SVG**
الآن يدعم Aspose.Slides لـ بايثون عبر .NET عرض شكل كـ SVG. تمت إضافة طريقة WriteAsSvg (وoverload الخاص بها) إلى فئة Shape وواجهة IShape. تتيح هذه الطريقة حفظ محتوى الشكل كملف SVG. يظهر مقطع الكود أدناه كيفية تصدير شكل من الشريحة إلى ملف SVG.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## محاذاة الشكل

من خلال طريقة [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) المزدوجة، يمكنك 

* محاذاة الأشكال بالنسبة لهامش الشريحة. انظر المثال 1. 
* محاذاة الأشكال بالنسبة لبعضها البعض. انظر المثال 2. 

تعرف مجموعة [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) خيارات المحاذاة المتاحة.

### المثال 1

يظهر لك هذا الكود Python كيفية محاذاة الأشكال ذات الفهارس 1 و2 و4 على الحدود العلوية للشريحة:
الكود أدناه يقوم بمحاذاة الأشكال ذات الفهارس 1 و2 و4 على الحافة العليا للشريحة. 

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### المثال 2

يظهر لك هذا الكود Python كيفية محاذاة مجموعة كاملة من الأشكال بالنسبة للشكل السفلي في المجموعة:

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```