---
title: Python में प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/python-net/custom-shape/
keywords:
- कस्टम आकार
- आकार जोड़ें
- आकार बनाएं
- आकार बदलें
- आकार ज्यामिति
- ज्यामिति पथ
- पथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET में PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोनों, समग्र आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पाथ के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने की प्रक्रिया समझाता है। यह दिखाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) का उपयोग करके मौजूदा आकारों को संशोधित किया जाए, मूलभूत पाथ संपादन संचालन किए जाएँ, बिंदुओं को जोड़ा या हटाया जाए, और अद्यतन ज्यामिति को फिर से आकार पर लागू किया जाए।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और संयुक्त आकार बनाएं, वक्र कोनों वाले आकार बनाएं, यह निर्धारित करें कि आकार की ज्यामिति बंद है या नहीं, और कंटूर विश्लेषण के लिए आकार तत्वों को निकालें।

## **Edit Points का उपयोग करके एक आकार बदलें**

PowerPoint में आप **Edit Points** का उपयोग करके वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की रूपरेखा बदल सकते हैं या मौजूदा आकार को नई आकृति के आधार के रूप में उपयोग कर सकते हैं।

## **आकार संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* एक आकार (या उसका पाथ) बंद या खुला हो सकता है।
* किसी आकार का पाथ एंकर बिंदुओं से जुड़े खंडों से बनता है।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल इसके आकार को निर्धारित करते हैं।
* एंकर बिंदु कोने के बिंदु, सीधी रेखा बिंदु, या स्मूथ बिंदु के रूप में होते हैं:
  * कोने के बिंदु पर, से जुड़े खंड कोण पर मिल सकते हैं।
  * स्मूथ बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधे बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।
* एंकर बिंदु को ले जाने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को Edit Points के माध्यम से संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) वस्तु की ज्यामिति पाथ को दर्शाता है।
* [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) मेथड का उपयोग करके आप [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) से [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) प्राप्त कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) सेट करने के लिए आप इन मेथड्स का उपयोग कर सकते हैं: एकल पाथ वाले आकार के लिए [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) और कई पाथ वाले आकार के लिए [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)।
* खंड जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) के तहत उपलब्ध मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) और [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) प्रॉपर्टीज़ का उपयोग करके आप ज्यामिति पाथ की उपस्थिति निर्धारित कर सकते हैं।
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) प्रॉपर्टी के माध्यम से आप [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) की ज्यामिति पाथ को खंडों की एक एरे के रूप में प्राप्त कर सकते हैं।

## **सरल संपादन संचालन**

नीचे दिए गए मेथड्स का उपयोग करके आप ज्यामिति पाथ को संशोधित कर सकते हैं। वह ओवरलोड जो इंडेक्स स्वीकार करता है, पाथ की सेगमेंट एरे में शून्य-आधारित स्थिति पर एक सेगमेंट सम्मिलित करता है।

| ऑपरेशन | विधि |
| --- | --- |
| सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| दो नियंत्रण बिंदुओं और एक अंतिम बिंदु के साथ क्यूबिक बेज़ियर वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| एक नियंत्रण बिंदु और एक अंतिम बिंदु वाले द्विघात बेज़ियर वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| निर्दिष्ट आयाम और डिग्री में कोणों के साथ अंडाकार चाप जोड़ें। | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| वर्तमान आकृति को उसके अंतिम बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| आकृति की प्रारंभ बिंदु निर्धारित करें। | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| शून्य-आधारित इंडेक्स पर किसी सेगमेंट को हटाएँ। | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) का उपयोग करके डालता है और संपादित पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) के साथ लागू करता है। निर्देशांक आकार के स्थानीय हैं: दोनों नए बिंदु आकार के केंद्र में हैं, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट की दूरी पर। सेगमेंट इंडेक्स 1 और 4 उन्हें क्रमशः शीर्ष और निचले किनारों पर रखते हैं, जिससे वे किनारे अंदर की ओर खींचे जाते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    geometry_path = shape.get_geometry_paths()[0]
    geometry_path.line_to(100, 50, 1)
    geometry_path.line_to(100, 50, 4)

    shape.set_geometry_path(geometry_path)
```

![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण हृदय आकार की रूपरेखा को [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) के साथ शून्य-आधारित इंडेक्स 2 पर सेगमेंट हटाकर बदलता है। संशोधित पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) के साथ लागू करने से आकार की रूपरेखा अपडेट हो जाती है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.HEART, 100, 100, 300, 300)

    path = shape.get_geometry_paths()[0]
    path.remove_at(2)

    shape.set_geometry_path(path)
```
![example2_image](custom_shape_2.png)

## **कस्टम आकार बनाना**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) का उपयोग करके पाँच-कोने वाला सितारा बनाता है। बाहरी और आंतरिक त्रिज्याएँ क्रमशः 100 और 50 पॉइंट के वैकल्पिक क्रम में टिप और अंतर्वर्ती बनाते हैं; 72‑डिग्री चरण से पाँच टिपें समान रूप से वितरित होती हैं। पाथ को [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) से बंद किया जाता है और आयताकार आकार पर [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) द्वारा लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

```python
import aspose.slides as slides
import aspose.pydrawing as draw
import math

points = []

outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = angle * (math.pi / 180)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

    radians = math.pi * (angle + angle_step / 2) / 180.0
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append(slides.PointF(x + outer_radius, y + outer_radius))

star_path = slides.GeometryPath()
star_path.move_to(points[0])

for i in range(1, len(points)):
    star_path.line_to(points[i])

star_path.close_figure()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.set_geometry_path(star_path)
```
![example3_image](custom_shape_3.png)

## **संयुक्त कस्टम आकार बनाना**

यह उदाहरण आकार के ऊपर और नीचे के एक‑तिहाई हिस्सों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ऑब्जेक्ट परिभाषित करता है। दोनों पाथ को [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) के साथ लागू करने से मध्य‑तिहाई में एक अंतर के साथ एकल संयुक्त आकार बनता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)

    top_path = slides.GeometryPath()
    top_path.move_to(0, 0)
    top_path.line_to(shape.width, 0)
    top_path.line_to(shape.width, shape.height / 3)
    top_path.line_to(0, shape.height / 3)
    top_path.close_figure()

    bottom_path = slides.GeometryPath()
    bottom_path.move_to(0, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height / 3 * 2)
    bottom_path.line_to(shape.width, shape.height)
    bottom_path.line_to(0, shape.height)
    bottom_path.close_figure()

    shape.set_geometry_paths([top_path, bottom_path])
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों वाले कस्टम आकार बनाना**

यह उदाहरण सीधे खंडों को [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) के साथ मिलाकर अंदर‑की‑वक्र कोनों वाले आकार का निर्माण करता है। प्रत्येक कोने का आकार बिंदुओं में चाप की चौड़ाई और ऊँचाई सेट करता है, और -90‑डिग्री स्वेप एक प्रतिक्लॉकवाइज़ क्वार्टर एलिप्स बनाता है। पूर्ण पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) के साथ लागू किया जाता है, और प्रस्तुति को PPTX फॉर्मेट में सहेजा जाता है।

```python
import aspose.slides as slides
import aspose.pydrawing as draw

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.CUSTOM, shape_x, shape_y, shape_width, shape_height)

    top_left = slides.PointF(left_top_size, 0)
    top_right = slides.PointF(shape_width - right_top_size, 0)
    right_bottom = slides.PointF(shape_width, shape_height - right_bottom_size)
    bottom_left = slides.PointF(left_bottom_size, shape_height)
    left_top = slides.PointF(0, left_top_size)

    geometry_path = slides.GeometryPath()
    geometry_path.move_to(top_left)
    geometry_path.line_to(top_right)
    geometry_path.arc_to(right_top_size, right_top_size, 180, -90)
    geometry_path.line_to(right_bottom)
    geometry_path.arc_to(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.line_to(bottom_left)
    geometry_path.arc_to(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.line_to(left_top)
    geometry_path.arc_to(left_top_size, left_top_size, 90, -90)
    geometry_path.close_figure()

    shape.set_geometry_path(geometry_path)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **जाँचें कि क्या आकार की ज्यामिति बंद है**

निम्न सहायक फ़ंक्शन यह जांचता है कि क्या प्रत्येक गैर‑खाली ज्यामिति पाथ का अंतिम सेगमेंट बंद करने वाला है। यह [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) को पढ़ता है और अंतिम सेगमेंट के [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) की तुलना [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑खाली पाथ नहीं है तो यह false वापस करता है। यह प्रत्येक पाथ की अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑आकृति का निरीक्षण नहीं करता। उदाहरण एक आयत के लिए `True` प्रिंट करता है।

```python
import aspose.slides as slides


def is_geometry_closed(geometry_shape):
    has_nonempty_path = False

    for geometry_path in geometry_shape.get_geometry_paths():
        segments = geometry_path.path_data
        if len(segments) == 0:
            continue

        has_nonempty_path = True
        last_segment = segments[len(segments) - 1]
        if last_segment.path_command != slides.PathCommandType.CLOSE:
            return False

    return has_nonempty_path


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    print(is_geometry_closed(shape))
```

## **ज्यामिति पाथ कमांड का निरीक्षण करें**

[contour.pptx](contour.pptx) को डाउनलोड करके इसे अपने कार्य निर्देशिका में रखें। प्रथम स्लाइड की पहली आकृति में एक सीधी ऊपर किनारा, एक क्यूबिक बेज़ियर वक्र और एक सीधा बंद किनारा है। इसकी पाथ पढ़ने के लिए आप [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) का उपयोग कर सकते हैं। प्रत्येक पाथ के लिए, [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) खंडों को उनके ड्राइंग क्रम में सूचीबद्ध करता है। प्रत्येक खंड का [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) यह निर्धारित करता है कि उसके [PathSegment.segment_data](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/segment_data/) को कैसे व्याख्यायित किया जाए।

```python
import aspose.slides as slides

with slides.Presentation("contour.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    for i, path in enumerate(shape.get_geometry_paths()):
        for j, segment in enumerate(path.path_data):
            command = segment.path_command
            data = segment.segment_data
            if command in (slides.PathCommandType.MOVE_TO, slides.PathCommandType.LINE_TO):
                detail = f"destination={tuple(data)}"
            elif command == slides.PathCommandType.CUBIC_BEZIER_TO:
                detail = f"control1={tuple(data[:2])} control2={tuple(data[2:4])} end={tuple(data[4:])}"
            elif command == slides.PathCommandType.CLOSE:
                detail = "no coordinates"
            else:
                detail = f"raw={data}"
            print(f"Path {i}, segment {j}: {command.name} {detail}")
```

आकृति स्लाइड पर (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गये निर्देशांक आकार के स्थानीय हैं। उसका ऊपरी‑बाएँ कोना (0, 0) है, x दाएँ बढ़ता है और y नीचे की ओर।

```text
Path 0, segment 0: MOVE_TO destination=(0, 0)
Path 0, segment 1: LINE_TO destination=(80, 0)
Path 0, segment 2: CUBIC_BEZIER_TO control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: CLOSE no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्वों को निकालें और निरीक्षण करें**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) का उपयोग करके आप मौजूदा आकार को तत्वों के रूप में निरीक्षण कर सकते हैं, जिसमें पाथ बिंदु और बिंदु प्रकार होते हैं। प्रत्येक लौटाए गये [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) में उसके [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) और [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) एरे उपलब्ध होते हैं। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति प्रदान करने के लिए उपयोगी है।

उदाहरण एक प्रस्तुति खोलता है, प्रथम स्लाइड पर सीधे प्रथम ज्यामिति आकार को खोजता है, और उसके पाथ सेगमेंट प्रिंट करता है। दोनों सीधे और वक्र खंडों वाले आकार वाली प्रस्तुति का उपयोग करके आप दोनों प्रकार के आउटपुट देख सकते हैं। यह समूहों के भीतर खोज नहीं करता।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    shape = next((item for item in slide.shapes if isinstance(item, slides.GeometryShape)), None)

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.create_shape_elements():
            points = element.path_points
            types = element.path_types
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखते हुए।
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # दोनों नियंत्रण बिंदुओं और अंतिम बिंदु को उपभोग करें।

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

एरे इंडेक्स द्वारा मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` एक आकृति की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा खींचता है। क्यूबिक बेज़ियर खंड पिछले अंतिम बिंदु से शुरू होता है और तीन क्रमिक प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंतिम बिंदु। लूप इन तीन प्रविष्टियों को साथ में उपभोग करता है और बंद होने के लिये अंतिम बिंदु की जाँच करता है।

बिंदु प्रकारों में फ़्लैग भी होते हैं। सेगमेंट प्रकार पहचानने के लिये `0x07` मास्क का उपयोग करें, और बंद उप‑पाथ का पता लगाने के लिये `0x80` को अलग से परीक्षण करें। उदाहरण के लिये, `129` (`0x81`) एक रेखा अंतिम बिंदु दर्शाता है जो उप‑पाथ को बंद करता है, और `131` (`0x83`) एक बेज़ियर अंतिम बिंदु दर्शाता है जो उसे बंद करता है। केवल `1` या `3` से तुलना करने से ये मामलों को मिस किया जा सकता है। अन्य फ़्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) मूल सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट्स (1/72 इंच) में मापे जाते हैं, X दाएँ और Y नीचे की ओर बढ़ता है। अवर्गीकृत आकार के लिये निकाले गये निर्देशांक पहले से ही उसके [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) और [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) स्थिति को सम्मिलित करते हैं और उसकी वर्तमान चौड़ाई और ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित और `120 × 80` आकार वाला बिना घुमाए आयत `(100, 200)–(220, 280)` कंटूर सीमा रखता है। आकार की स्थिति को दोबारा जोड़ें नहीं। X और Y को घटाकर स्थानीय निर्देशांक प्राप्त करें।

निकाले गये बिंदु आकार की [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) या क्षैतिज‑और‑लंबवत फ़्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः उत्पन्न करने के लिये उन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह निर्देशांक मैपिंग और रूपांतरणों को भी ध्यान में रखें; यह मानें नहीं कि निकाले गये बिंदु अंतिम रेंडर किए गये स्लाइड निर्देशांक हैं या अनजाने में अनुवाद/स्केल को दो बार लागू करें।

**निरीक्षण बनाम संपादन।** निकाले गये एरे कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार एरे की आवश्यकता रखता है तो इस दृष्टिकोण का चयन करें। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या उसकी ज्यामिति संपादित करनी हो तो [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) का उपयोग करें। संपादन किए गये पाथ को [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) या [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) के माध्यम से लागू करें।

## **FAQ**

**ज्यामिति को बदलने के बाद भराव और रूपरेखा क्या होती है?**

शैली आकार के साथ रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू होते हैं।

**ज्यामिति के साथ एक कस्टम आकार को सही ढंग से कैसे घुमा सकते हैं?**

आकार की [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) प्रॉपर्टी का उपयोग करें; ज्यामिति आकार के साथ घुमती है क्योंकि वह आकार की ही निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदल कर “लॉक” कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/python-net/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/python-net/create-shape-thumbnails/) को रास्टर फॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के कार्य को सरल बनाता है।