---
title: إدارة عقد شكل SmartArt في العروض التقديمية باستخدام بايثون
linktitle: عقدة شكل SmartArt
type: docs
weight: 30
url: /ar/python-net/manage-smartart-shape-node/
keywords:
- عقدة SmartArt
- عقدة فرعية
- إضافة عقدة
- موضع العقدة
- الوصول إلى العقدة
- إزالة العقدة
- موضع مخصص
- عقدة مساعدة
- تنسيق التعبئة
- تصيير العقدة
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "إدارة عقد شكل SmartArt في ملفات PPT و PPTX و ODP باستخدام Aspose.Slides للبايثون عبر .NET. احصل على أمثلة شفرة واضحة ونصائح لتبسيط عروضك التقديمية."
---

## **Add SmartArt Node**
Aspose.Slides for Python via .NET has provided the simplest API to manage the SmartArt shapes in an easiest way. The following sample code will help to add node and child node inside SmartArt shape.

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- إضافة عقدة جديدة إلى مجموعة العقد NodeCollection لشكل SmartArt وتعيين النص في TextFrame.
- الآن، إضافة عقدة فرعية إلى عقدة SmartArt التي تم إضافتها حديثًا وتعيين النص في TextFrame.
- حفظ العرض التقديمي.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:

        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # إضافة عقدة SmartArt جديدة
            node1 = shape.all_nodes.add_node()
            # إضافة النص
            node1.text_frame.text = "Test"

            # إضافة عقدة فرعية جديدة في العقدة الأصلية. سيتم إضافتها في نهاية المجموعة
            new_node = node1.child_nodes.add_node()

            # إضافة النص
            new_node.text_frame.text = "New Node Added"

    # حفظ العرض التقديمي
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Add SmartArt Node at Specific Position**
In the following sample code we have explained how to add the child nodes belonging to respective nodes of SmartArt shape at particular position.

- إنشاء مثيل من فئة `Presentation` class.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من النوع StackedList إلى الشريحة المستهدفة.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، إضافة عقدة فرعية للعقدة المحددة في الموضع 2 وتعيين نصها.
- حفظ العرض التقديمي.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# إنشاء مثيل للعرض التقديمي
with slides.Presentation() as pres:
    # الوصول إلى شريحة العرض التقديمي
    slide = pres.slides[0]

    # إضافة Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # الوصول إلى عقدة SmartArt في الفهرس 0
    node = smart.all_nodes[0]

    # إضافة عقدة فرعية جديدة في الموضع 2 داخل العقدة الأصلية
    chNode = node.child_nodes.add_node_by_position(2)

    # إضافة نص
    chNode.text_frame.text = "Sample text Added"

    # حفظ العرض التقديمي
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```





## **Access SmartArt Node**
The following sample code will help to access nodes inside SmartArt shape. Please note that you cannot change the LayoutType of the SmartArt as it is read only and is set only when the SmartArt shape is added.

- إنشاء مثيل من فئة `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.

- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.

- التنقل عبر كل شكل داخل الشريحة الأولى.

- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.

- التنقل عبر جميع العقد داخل شكل SmartArt.

- الوصول إلى وعرض معلومات مثل موضع عقدة SmartArt، المستوى والنص.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التنقل عبر جميع العقد داخل SmartArt
            for i in range(len(shape.all_nodes)):
                # الوصول إلى عقدة SmartArt في الفهرس i
                node = shape.all_nodes[i]

                # طباعة معلمات عقدة SmartArt
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```


  


## **Access SmartArt Child Node**
The following sample code will help to access the child nodes belonging to respective nodes of SmartArt shape.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التنقل عبر جميع العقد داخل شكل SmartArt.
- لكل عقدة SmartArt محددة، التنقل عبر جميع العقد الفرعية داخل العقدة المحددة.
- الوصول إلى وعرض معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التنقل عبر جميع العقد داخل SmartArt
            for node0 in shape.all_nodes:
                # التنقل عبر العقد الفرعية
                for j in range(len(node0.child_nodes)):
                    # الوصول إلى العقدة الفرعية في عقدة SmartArt
                    node = node0.child_nodes[j]

                    # طباعة معلمات العقدة الفرعية في SmartArt
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))
```




## **Access SmartArt Child Node at Specific Position**
In this example, we will learn to access the child nodes at some particular position belonging to respective nodes of SmartArt shape.

- إنشاء مثيل من فئة `Presentation` class.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt من النوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة ذات الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، الوصول إلى العقدة الفرعية في الموضع 1 لعقدة SmartArt التي تم الوصول إليها باستخدام طريقة GetNodeByPosition().
- الوصول إلى وعرض معلومات مثل موضع العقدة الفرعية، المستوى والنص.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# إنشاء مثيل للعرض التقديمي
with slides.Presentation() as pres:
    # الوصول إلى الشريحة الأولى
    slide = pres.slides[0]
    # إضافة شكل SmartArt في الشريحة الأولى
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # الوصول إلى عقدة SmartArt في الفهرس 0
    node = smart.all_nodes[0]
    # الوصول إلى العقدة الفرعية في الموضع 1 داخل العقدة الأصلية
    position = 1
    chNode = node.child_nodes[position] 
    # طباعة معلمات العقدة الفرعية في SmartArt
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))
```




## **Remove SmartArt Node**
In this example, we will learn to remove the nodes inside SmartArt shape.

- إنشاء مثيل من فئة `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التحقق مما إذا كان SmartArt يحتوي على أكثر من 0 عقد.
- اختيار عقدة SmartArt التي سيتم حذفها.
- الآن، إزالة العقدة المحددة باستخدام طريقة RemoveNode() * حفظ العرض التقديمي.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # تحويل الشكل إلى SmartArtEx
            if len(shape.all_nodes) > 0:
                # الوصول إلى عقدة SmartArt في الفهرس 0
                node = shape.all_nodes[0]

                # إزالة العقدة المحددة
                shape.all_nodes.remove_node(node)

    # حفظ العرض التقديمي
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Remove SmartArt Node at Specific Position**
In this example, we will learn to remove the nodes inside SmartArt shape at particular position.

- إنشاء مثيل من فئة `Presentation` class وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الأولى باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- اختيار عقدة شكل SmartArt في الفهرس 0.
- الآن، التحقق مما إذا كانت عقدة SmartArt المحددة تحتوي على أكثر من عقدتين فرعيتين.
- الآن، إزالة العقدة في الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- حفظ العرض التقديمي.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # تحويل الشكل إلى SmartArt
            if len(shape.all_nodes) > 0:
                # الوصول إلى عقدة SmartArt في الفهرس 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # إزالة العقدة الفرعية في الموضع 1
                    node.child_nodes.remove_node(1)

    # حفظ العرض التقديمي
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Custom Position for Child Node in SmartArt**
Now Aspose.Slides for Python via .NET support for setting SmartArtShape X and Y properties. The code snippet below shows how to set custom SmartArtShape position, size and rotation also please note that adding new nodes causes a recalculation of the positions and sizes of all nodes.
الآن يدعم Aspose.Slides for Python عبر .NET تعيين خصائص X و Y لشكل SmartArt. يوضح مقتطف التعليمات البرمجية أدناه كيفية تعيين موضع وحجم ودوران مخصص لشكل SmartArt، ويرجى ملاحظة أن إضافة عقد جديدة يؤدي إلى إعادة حساب مواضع وأحجام جميع العقد.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# تحميل العرض التقديمي المطلوب
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# نقل شكل SmartArt إلى موضع جديد
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# تغيير عرض شكل SmartArt
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# تغيير ارتفاع شكل SmartArt
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# تغيير تدوير شكل SmartArt
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```




## **Check Assistant Node**
In the following sample code we will investigate how to identify Assistant Nodes in the SmartArt nodes collection and changing them.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي مع شكل SmartArt.
- الحصول على مرجع الشريحة الثانية باستخدام الفهرس الخاص بها.
- التنقل عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- التنقل عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقدة مساعدة.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- حفظ العرض التقديمي.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# إنشاء مثيل للعرض التقديمي
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # التنقل عبر كل شكل داخل الشريحة الأولى
    for shape in pres.slides[0].shapes:
        # التحقق ما إذا كان الشكل من نوع SmartArt
        if type(shape) is art.SmartArt:
            # التنقل عبر جميع عقد شكل SmartArt
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # التحقق ما إذا كانت العقدة مساعدة
                if node.is_assistant:
                    # تعيين العقدة المساعدة إلى false وجعلها عقدة عادية
                    node.is_assistant = False
    # حفظ العرض التقديمي
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Set Node's Fill Format**
Aspose.Slides for Python via .NET makes it possible to add custom SmartArt shapes and set their fill formats. This article explains how to create and access SmartArt shapes and set their fill format using Aspose.Slides for Python via .NET.

Please follow the steps below:

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع شريحة باستخدام الفهرس الخاص بها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType الخاص به.
- تعيين FillFormat لعقد شكل SmartArt.
- كتابة العرض التقديمي المعدل كملف PPTX.
```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # الوصول إلى الشريحة
    slide = presentation.slides[0]

    # إضافة شكل SmartArt والعقد
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # تعيين لون تعبئة العقدة
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # حفظ العرض التقديمي
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Generate Thumbnail of SmartArt Child Node**
Developers can generate a thumbnail of Child node of a SmartArt by following the steps below:

1. إنشاء مثيل من فئة `Presentation` التي تمثل ملف PPTX.
1. إضافة SmartArt.
1. الحصول على مرجع عقدة باستخدام الفهرس الخاص بها
1. الحصول على صورة المصغرة.
1. حفظ صورة المصغرة بأي تنسيق صورة مطلوب.

The example below generating a thumbnail of SmartArt child node
المثال أدناه يولّد صورة مصغرة لعقدة فرعية في SmartArt
```py
import aspose.slides as slides
import aspose.slides.smartart as art

# إنشاء كائن من فئة Presentation يمثل ملف PPTX
with slides.Presentation() as presentation: 
    # إضافة SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # الحصول على مرجع العقدة باستخدام الفهرس الخاص بها  
    node = smart.nodes[1]

    # الحصول على صورة مصغرة
    with node.shapes[0].get_image() as bmp:
        # حفظ الصورة المصغرة
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```


## **FAQ**

**Is SmartArt animation supported?**  
نعم. يتم التعامل مع SmartArt كشكل عادي، لذا يمكنك [apply standard animations](/slides/ar/python-net/shape-animation/) (entrance, exit, emphasis, motion paths) وتعديل التوقيت. يمكنك أيضًا تحريك الأشكال داخل عقد SmartArt عند الحاجة.

**How can I reliably locate a specific SmartArt on a slide if its internal ID is unknown?**  
قم بالتعيين والبحث عبر [alternative text](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/alternative_text/). يتيح تعيين AltText مميز على SmartArt العثور عليه برمجيًا دون الاعتماد على المعرفات الداخلية.

**Will the SmartArt appearance be preserved when converting the presentation to PDF?**  
نعم. يقوم Aspose.Slides بتصدير SmartArt بدقة بصرية عالية أثناء [PDF export](/slides/ar/python-net/convert-powerpoint-to-pdf/)، مع الحفاظ على التخطيط والألوان والتأثيرات.

**Can I extract an image of the entire SmartArt (for previews or reports)?**  
نعم. يمكنك تصيير شكل SmartArt إلى [raster formats](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/get_image/) أو إلى [SVG](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/write_as_svg/) للحصول على خروج متجهي قابل للتوسيع، مما يجعله مناسبًا للصور المصغرة أو التقارير أو الاستخدام على الويب.