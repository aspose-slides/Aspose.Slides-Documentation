---
title: إدارة عقدة SmartArt
type: docs
weight: 30
url: /python-net/manage-smartart-shape-node/
keywords: "عقدة SmartArt، عقدة الطفل SmartArt، عرض PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "عقدة ذكية وعقدة طفل في عروض PowerPoint باستخدام بايثون"
---


## **إضافة عقدة SmartArt**
قامت Aspose.Slides لـ بايثون عبر .NET بتوفير أبسط واجهة برمجية لإدارة أشكال SmartArt بطريقة سهلة. ستساعدك الشيفرة البرمجية التالية في إضافة عقدة وعقدة طفل داخل شكل SmartArt.

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) وتحميل العرض التقديمي باستخدام شكل SmartArt.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- الانتقال عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- إضافة عقدة جديدة في مجموعة عقد SmartArt وتعيين النص في TextFrame.
- الآن، إضافة عقدة طفل في عقدة SmartArt الجديدة وتعيين النص في TextFrame.
- حفظ العرض التقديمي.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:

        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Adding a new SmartArt Node
            node1 = shape.all_nodes.add_node()
            # Adding text
            node1.text_frame.text = "اختبار"

            # Adding new child node in parent node. It  will be added in the end of collection
            new_node = node1.child_nodes.add_node()

            # Adding text
            new_node.text_frame.text = "تمت إضافة عقدة جديدة"

    # Saving Presentation
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إضافة عقدة SmartArt في موضع محدد**
في الشيفرة البرمجية التالية، أوضحنا كيفية إضافة عقد الطفل المرتبطة بعقد SmartArt عند موضع معين.

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- إضافة شكل SmartArt من نوع StackedList في الشريحة التي تم الوصول إليها.
- الوصول إلى العقدة الأولى في شكل SmartArt المضاف.
- الآن، إضافة عقدة الطفل للعقدة المختارة في الموضع 2 وتعيين نصها.
- حفظ العرض التقديمي.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creating a presentation instance
with slides.Presentation() as pres:
    # Access the presentation slide
    slide = pres.slides[0]

    # Add Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Accessing the SmartArt node at index 0
    node = smart.all_nodes[0]

    # Adding new child node at position 2 in parent node
    chNode = node.child_nodes.add_node_by_position(2)

    # Add text
    chNode.text_frame.text = "تمت إضافة نص عينة"

    # Save Presentation
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```




## **الوصول إلى عقدة SmartArt**
ستساعدك الشيفرة البرمجية التالية في الوصول إلى العقد داخل شكل SmartArt. يرجى ملاحظة أنه لا يمكنك تغيير LayoutType لـ SmartArt لأنه للقراءة فقط ويتم تعيينه فقط عند إضافة شكل SmartArt.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي باستخدام شكل SmartArt.

- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.

- الانتقال عبر كل شكل داخل الشريحة الأولى.

- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.

- الانتقال عبر جميع العقد داخل شكل SmartArt.

- الوصول إلى المعلومات وعرضها مثل موضع عقدة SmartArt، المستوى والنص.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for i in range(len(shape.all_nodes)):
                # Accessing SmartArt node at index i
                node = shape.all_nodes[i]

                # Printing the SmartArt node parameters
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
  ```

  


## **الوصول إلى عقدة الطفل SmartArt**
ستساعدك الشيفرة البرمجية التالية في الوصول إلى عقد الطفل المرتبطة بالعقد الخاصة بشكل SmartArt.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي باستخدام شكل SmartArt.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- الانتقال عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- الانتقال عبر جميع العقد داخل شكل SmartArt.
- لكل عقدة SmartArt محددة، الانتقال عبر جميع عقد الطفل داخل عقدة معينة.
- الوصول إلى المعلومات وعرضها مثل موضع عقدة الطفل، المستوى والنص.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traverse through all nodes inside SmartArt
            for node0 in shape.all_nodes:
                # Traversing through the child nodes
                for j in range(len(node0.child_nodes)):
                    # Accessing the child node in SmartArt node
                    node = node0.child_nodes[j]

                    # Printing the SmartArt child node parameters
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```



## **الوصول إلى عقدة الطفل SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية الوصول إلى عقد الطفل في موضع معين المرتبطة بالعقد الخاصة بشكل SmartArt.

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- إضافة شكل SmartArt من نوع StackedList.
- الوصول إلى شكل SmartArt المضاف.
- الوصول إلى العقدة عند الفهرس 0 لشكل SmartArt الذي تم الوصول إليه.
- الآن، الوصول إلى عقدة الطفل عند الموضع 1 للعقدة SmartArt التي تم الوصول إليها باستخدام طريقة GetNodeByPosition().
- الوصول إلى المعلومات وعرضها مثل موضع عقدة الطفل، المستوى والنص.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate the presentation
with slides.Presentation() as pres:
    # Accessing the first slide
    slide = pres.slides[0]
    # Adding the SmartArt shape in first slide
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Accessing the SmartArt  node at index 0
    node = smart.all_nodes[0]
    # Accessing the child node at position 1 in parent node
    position = 1
    chNode = node.child_nodes[position] 
    # Printing the SmartArt child node parameters
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```



## **إزالة عقدة SmartArt**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي باستخدام شكل SmartArt.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- الانتقال عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- التحقق مما إذا كانت SmartArt تحتوي على أكثر من 0 عقد.
- اختيار عقدة SmartArt المراد حذفها.
- الآن، إزالة العقدة المحددة باستخدام طريقة RemoveNode() *حفظ العرض التقديمي.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArtEx
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]

                # Removing the selected node
                shape.all_nodes.remove_node(node)

    # Save Presentation
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إزالة عقدة SmartArt في موضع محدد**
في هذا المثال، سنتعلم كيفية إزالة العقد داخل شكل SmartArt عند موضع معين.

- إنشاء مثيل من فئة `Presentation` وتحميل العرض التقديمي باستخدام شكل SmartArt.
- الحصول على مرجع الشريحة الأولى من خلال استخدام فهرسها.
- الانتقال عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArt إذا كان SmartArt.
- اختيار عقدة شكل SmartArt عند الفهرس 0.
- الآن، التحقق مما إذا كانت عقدة SmartArt المختارة تحتوي على أكثر من 2 عقدة طفل.
- الآن، إزالة العقدة عند الموضع 1 باستخدام طريقة RemoveNodeByPosition().
- حفظ العرض التقديمي.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Typecast shape to SmartArt
            if len(shape.all_nodes) > 0:
                # Accessing SmartArt node at index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Removing the child node at position 1
                    node.child_nodes.remove_node(1)

    # Save Presentation
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تعيين موضع مخصص لعقدة الطفل في SmartArt**
الآن تدعم Aspose.Slides لـ بايثون عبر .NET تعيين خصائص X و Y لشكل SmartArt. توضح الشيفرة البرمجية أدناه كيفية تعيين موضع SmartArtShape المخصص، الحجم والدوران، يرجى ملاحظة أن إضافة عقد جديدة تتسبب في إعادة حساب مواضع وأحجام جميع العقد.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Load the desired the presentation
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Move SmartArt shape to new position
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Change SmartArt shape's widths
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Change SmartArt shape's height
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Change SmartArt shape's rotation
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```



## **تحقق من عقدة المساعد**
في الشيفرة البرمجية التالية، سنستقصي كيفية تحديد عقد المساعد في مجموعة عقد SmartArt وتغييرها.

- إنشاء مثيل من فئة PresentationEx وتحميل العرض التقديمي باستخدام شكل SmartArt.
- الحصول على مرجع الشريحة الثانية من خلال استخدام فهرسها.
- الانتقال عبر كل شكل داخل الشريحة الأولى.
- التحقق مما إذا كان الشكل من نوع SmartArt وتحويل الشكل المحدد إلى SmartArtEx إذا كان SmartArt.
- الانتقال عبر جميع العقد داخل شكل SmartArt والتحقق مما إذا كانت عقد المساعد.
- تغيير حالة عقدة المساعد إلى عقدة عادية.
- حفظ العرض التقديمي.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Creating a presentation instance
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Traverse through every shape inside first slide
    for shape in pres.slides[0].shapes:
        # Check if shape is of SmartArt type
        if type(shape) is art.SmartArt:
            # Traversing through all nodes of SmartArt shape
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Check if node is Assitant node
                if node.is_assistant:
                    # Setting Assitant node to false and making it normal node
                    node.is_assistant = False
    # Save Presentation
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **تعيين تنسيق التعبئة للعقدة**
تتيح Aspose.Slides لـ بايثون عبر .NET إمكانية إضافة أشكال SmartArt مخصصة وتعيين تنسيقات التعبئة الخاصة بها. يشرح هذا المقال كيفية إنشاء والوصول إلى أشكال SmartArt وتعيين تنسيق التعبئة لها باستخدام Aspose.Slides لـ بايثون عبر .NET.

يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة `Presentation`.
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة شكل SmartArt عن طريق تعيين LayoutType له.
- تعيين FillFormat لعقد شكل SmartArt.
- كتابة العرض التقديمي المعدّل كملف PPTX.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Accessing the slide
    slide = presentation.slides[0]

    # Adding SmartArt shape and nodes
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "بعض النص"

    # Setting node fill color
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Saving Presentation
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```



## **إنشاء صورة مصغرة لعقدة الطفل SmartArt**
يمكن للمطورين إنشاء صورة مصغرة لعقدة الطفل من SmartArt من خلال اتباع الخطوات أدناه:

1. إنشاء مثيل من فئة `Presentation` التي تمثل ملف PPTX.
1. إضافة SmartArt.
1. الحصول على مرجع للعقدة باستخدام فهرسها.
1. الحصول على صورة مصغرة.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب فيه.

المثال أدناه ينشئ صورة مصغرة لعقدة الطفل SmartArt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instantiate Presentation class that represents the PPTX file 
with slides.Presentation() as presentation: 
    # Add SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Obtain the reference of a node by using its Index  
    node = smart.nodes[1]

    # Get thumbnail
    with node.shapes[0].get_image() as bmp:
        # save thumbnail
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```