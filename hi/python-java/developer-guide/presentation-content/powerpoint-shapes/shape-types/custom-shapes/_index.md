---
title: Python के माध्यम से Java द्वारा प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/python-java/custom-shape/
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
- घुमावदार कोना
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, घुमावदार कोने, संयोजन आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुतिकरण आकारों को संपादन बिंदुओं और ज्यामितीय पथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने की विधि बताता है। यह दिखाता है कि कैसे आप मौजूदा आकारों को संशोधित करने, बुनियादी पथ संपादन संचालन करने, बिंदुओं को जोड़ने या हटाने, और अद्यतन ज्यामिति को आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) के साथ काम कर सकते हैं।

यह साथ ही कस्टम और संयोजन आकार बनाना, घुमावदार कोनों वाले आकार बनाना, यह निर्धारित करना कि कोई आकार ज्यामिति बंद है या नहीं, आकार तत्वों का निरीक्षण करना, और Java AWT टेक्स्ट रूपरेखाओं को ज्यामितीय पथों में परिवर्तित करना प्रदर्शित करता है।

## **संपादन बिंदुओं के द्वारा आकार बदलें**

PowerPoint में आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको आकार की रूपरेखा बदलने या मौजूदा आकार को नई आकृति के आधार के रूप में उपयोग करने की अनुमति देते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* कोई आकार (या उसका पथ) बंद या खुला दोनों हो सकता है।
* आकार का पथ एंकर बिंदुओं से जुड़ी खंडों (segments) से बनता है।
* कोई खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसके आकार को निर्धारित करते हैं।
* एंकर बिंदु कोने के बिंदु, सीधे बिंदु, या स्मूद बिंदु के रूप में होते हैं:
  * कोने के बिंदु पर, सटे हुए खंड कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधे बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से विभिन्न दूरियों पर हो सकते हैं।
* एंकर बिंदुओं को लेजाने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) वर्ग प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) ऑब्जेक्ट की ज्यामिति पथ का प्रतिनिधित्व करता है।
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) उदाहरण से [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) सेट करने हेतु आप ये मेथड उपयोग कर सकते हैं: एकल पथ वाले आकारों के लिए [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) और कई पथ वाले आकारों के लिए [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths)।
* खंड जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) के अंतर्गत स्थित मेथड का उपयोग कर सकते हैं।
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) मेथड्स के माध्यम से आप किसी ज्यामितीय पथ की उपस्थिति निर्धारित कर सकते हैं।
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) मेथड का उपयोग करके आप [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) की ज्यामिति पथ को पथ खंडों की एक श्रृंखला के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों के लिये, आप [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और खंडों को एक [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) पर पुनः चलाकर लागू कर सकते हैं।

## **सरल संपादन संचालन**

ज्यामिति पथ को संपादित करने के लिये नीचे दिए गये मेथड का उपयोग करें। ओवरलोड जो एक सूचकांक स्वीकार करते हैं, वह पथ के खंड सरणी में शून्य-आधारित स्थिति पर खंड डालते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| सीधा रेखा जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु के साथ क्यूबिक बेज़ियर वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु और एक अंत बिंदु के साथ क्वाड्रेटिक बेज़ियर वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम और डिग्री में कोण के साथ एक दीर्घवृत्तीय चाप जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारम्भ बिंदु से जोड़ कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| आकृति का प्रारम्भ बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| शून्य-आधारित सूचकांक पर खंड हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) का उपयोग करके सम्मिलित करता है और संपोधित पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू करता है। निर्देशांक आकार के सापेक्ष स्थानीय होते हैं: दोनों नए बिंदु आकार के केन्द्र में, बाएँ से 100 पॉइंट और शीर्ष से 50 पॉइंट पर स्थित हैं। खंड सूचकांक 1 और 4 उन्हें क्रमशः शीर्ष और निचली किनारी पर रखते हैं, जिससे वे किनारे अंदर की ओर खिंचते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.lineTo(100, 50, 1)
    geometry_path.lineTo(100, 50, 4)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```

![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) का उपयोग करके शून्य-आधारित सूचकांक 2 पर स्थित खंड को हटाकर दिल के आकार की रूपरेखा बदलता है। संशोधित पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) के द्वारा लागू करने से आकार की रूपरेखा अद्यतन होती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300)

    geometry_path = shape.getGeometryPaths()[0]
    geometry_path.removeAt(2)

    shape.setGeometryPath(geometry_path)
finally:
    presentation.dispose()
```
![example2_image](custom_shape_2.png)

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) का उपयोग करके पाँच-भुजाओं वाला तारा बनाता है। 100 और 50 पॉइंट के बारी‑बारी बाहरी और भीतरी त्रिज्या टिप्स और अंतरों को परिभाषित करती है; 72‑डिग्री कदम पाँच टिप्स को समान रूप से अंतर देता है। पथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया जाता है और आयताकार आकार पर [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, जिससे उसकी रूपरेखा प्रतिस्थापित हो जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

import math

points = []
outer_radius = 100
inner_radius = 50
angle_step = 72

for angle in range(-90, 270, angle_step):
    radians = math.radians(angle)
    x = outer_radius * math.cos(radians)
    y = outer_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

    radians = math.radians(angle + angle_step / 2)
    x = inner_radius * math.cos(radians)
    y = inner_radius * math.sin(radians)
    points.append((x + outer_radius, y + outer_radius))

star_path = GeometryPath()
star_path.moveTo(*points[0])
for point in points[1:]:
    star_path.lineTo(*point)
star_path.closeFigure()

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outer_radius * 2, outer_radius * 2)
    shape.setGeometryPath(star_path)
finally:
    presentation.dispose()
```
![example3_image](custom_shape_3.png)

## **संयोजन कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपर और नीचे के एक‑तिहाई हिस्से के लिये दो बंद [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) वस्तुएँ परिभाषित करता है। दोनों पथों को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से मध्य तिहाई में अंतर के साथ एक एकल संयोजन आकार बनता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)

    top_path = GeometryPath()
    top_path.moveTo(0, 0)
    top_path.lineTo(shape.getWidth(), 0)
    top_path.lineTo(shape.getWidth(), shape.getHeight() / 3)
    top_path.lineTo(0, shape.getHeight() / 3)
    top_path.closeFigure()

    bottom_path = GeometryPath()
    bottom_path.moveTo(0, shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2)
    bottom_path.lineTo(shape.getWidth(), shape.getHeight())
    bottom_path.lineTo(0, shape.getHeight())
    bottom_path.closeFigure()

    shape.setGeometryPaths([top_path, bottom_path])
finally:
    presentation.dispose()
```
![example4_image](custom_shape_4.png)

## **घुमावदार कोनों वाले कस्टम आकार बनाएँ**

यह उदाहरण सीधे खंडों को [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर अंदर की ओर घुमावदार कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में निर्धारित करता है, और -90‑डिग्री स्वूप एक घड़ी की दिशा में विपरीत क्वार्टर एलिप्स बनाता है। पूर्ण पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, और प्रस्तुति को PPTX स्वरूप में सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, SaveFormat

shape_x = 20
shape_y = 20
shape_width = 300
shape_height = 200

left_top_size = 50
right_top_size = 20
right_bottom_size = 40
left_bottom_size = 10

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Custom, shape_x, shape_y, shape_width, shape_height)

    geometry_path = GeometryPath()
    geometry_path.moveTo(left_top_size, 0)
    geometry_path.lineTo(shape_width - right_top_size, 0)
    geometry_path.arcTo(right_top_size, right_top_size, 180, -90)
    geometry_path.lineTo(shape_width, shape_height - right_bottom_size)
    geometry_path.arcTo(right_bottom_size, right_bottom_size, -90, -90)
    geometry_path.lineTo(left_bottom_size, shape_height)
    geometry_path.arcTo(left_bottom_size, left_bottom_size, 0, -90)
    geometry_path.lineTo(0, left_top_size)
    geometry_path.arcTo(left_top_size, left_top_size, 90, -90)
    geometry_path.closeFigure()
    
    shape.setGeometryPath(geometry_path)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **जाँचें कि क्या आकार ज्यामिति बंद है**

निम्न हेलपर यह सत्यापित करता है कि प्रत्येक गैर‑खाली ज्यामिति पथ बंद करने वाले खंड पर समाप्त होता है या नहीं। यह [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) को पढ़ता है और अंतिम खंड के [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) को [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) से तुलना करता है। जब कोई गैर‑खाली पथ नहीं होता तो यह `False` लौटाता है। यह प्रत्येक पथ की अंतिम कमांड की जाँच करता है; यह पथ के भीतर प्रत्येक उप‑आकृति को नहीं देखता। उदाहरण आयत के लिये `True` प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, PathCommandType

def is_geometry_closed(geometry_shape):
    has_nonempty_path = False
    for geometry_path in geometry_shape.getGeometryPaths():
        path_data = geometry_path.getPathData()
        if len(path_data) == 0:
            continue
        last_segment = path_data[-1]
        has_nonempty_path = True
        if last_segment.getPathCommand() != PathCommandType.Close:
            return False
    return has_nonempty_path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    closed = is_geometry_closed(shape)
    print(closed)
finally:
    presentation.dispose()
```

## **आकार तत्वों को निकालें और निरीक्षण करें**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) का उपयोग करके आप किसी मौजूदा आकार को तत्वों के रूप में देख सकते हैं जिनमें पथ बिंदु और बिंदु प्रकार होते हैं। प्रत्येक लौटाए गये तत्व को `jpype.JObject` के साथ [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) में कास्ट करके आप [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) मेथड द्वारा बिंदु व प्रकार सरणियों को प्राप्त कर सकते हैं। यह प्रतिनिधित्व रूपरेखा विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिये उपयोगी है।

उदाहरण input.pptx खोलता है, प्रथम स्लाइड पर सीधे प्रथम ज्यामिति आकार को खोजता है, और उसके पथ खंडों को प्रिंट करता है। दोनों सीधा और घुमावदार खंडों वाले आकार वाली प्रस्तुति उपयोग करें ताकि दोनों प्रकार के आउटपुट देखे जा सकें। यह समूहों के भीतर खोज नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, GeometryShape, ShapeElement

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape = None
    for candidate in slide.getShapes():
        if isinstance(candidate, GeometryShape):
            shape = candidate
            break

    if shape is None:
        print("No geometry shape found on the first slide.")
    else:
        for element in shape.createShapeElements():
            shape_element = jpype.JObject(element, ShapeElement)
            points = shape_element.getPathPoints()
            types = shape_element.getPathTypes()
            print("Shape element:")

            i = 0
            while i < len(points):
                point_type = types[i] & 0x07  # सेगमेंट प्रकार रखें, फ़्लैग को हटाते हुए।
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # Consume both control points and the endpoint.

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

सरणियों का अनुक्रम इस प्रकार है: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` आकृति की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा खींचता है। एक क्यूबिक बेज़ियर खंड पिछले अंत बिंदु से शुरू होता है और लगातार तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में खपत करता है और बंद होने की जाँच के लिये अंत बिंदु देखता है।

बिंदु प्रकारों में ध्वज भी होते हैं। सेगमेंट प्रकार की पहचान के लिये `0x07` से मास्क करें, और बंद उप‑पथ की पहचान के लिये `0x80` को अलग से परीक्षण करें। उदाहरणतः, `129` (`0x81`) का अर्थ एक रेखा अंत बिंदु है जो उप‑पथ को बंद करता है, और `131` (`0x83`) का अर्थ एक बेज़ियर अंत बिंदु है जो उप‑पथ को बंद करता है। जावा इन ध्वजों को साइन किए हुए बाइट्स में संग्रहीत करता है; मास्किंग मूल बिट मानों को संरक्षित करती है। केवल `1` या `3` से कच्चे मान की तुलना करने से ये मामलों को चूक सकते हैं। अन्य ध्वज, जैसे डैश (`0x10`) और मार्कर (`0x20`), मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदुओं को पॉइंट (1/72 इंच) में मापा जाता है, जहाँ X दाएँ और Y नीचे की ओर बढ़ता है। अनग्रुप्ड आकार के लिये निकाले गये निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) द्वारा लौटाए गये स्थान को सम्मिलित कर लेते हैं और उसकी वर्तमान चौड़ाई व ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित और `120 × 80` आकार का अनरोटेटेड आयत `(100, 200)–(220, 280)` के रूपरेखा सीमाओं को रखता है। आकार की स्थिति को फिर से न जोड़ें। उसके X और Y घटाकर अनरोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गये बिंदु आकार के घूर्णन, जो [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) द्वारा लौटाया जाता है, या क्षैतिज व लंबवत फ़्लिप को लागू नहीं करते। प्रदर्शित रूपरेखा को पुनः बनाने के लिये इन रूपांतरणों को आकार के केन्द्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह निर्देशांक मानचित्रण और रूपांतरणों को भी ध्यान में रखें; यह मान न लें कि निकाले गये बिंदु अंतिम स्लाइड रेंडर निर्देशांक हैं या अनावश्यक रूप से अनुवाद या स्केल दो बार लागू हो रहा है।

**निरीक्षण बनाम संपादन।** निकाले गये सरणियाँ रूपरेखा का वर्णन करती हैं; उनका परिवर्तन मूल आकार को अद्यतन नहीं करता। यह तरीका तब उपयोग करें जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार सरणियों की आवश्यकता रखता हो। आकृति के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या ज्यामिति संपादित करनी हो तो [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) उपयोग करें। संपादित पथों को [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करें।

## **Java AWT Shape को GeometryPath में परिवर्तित करें**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ मिलाकर ज्यामिति बनाता है। रूपरेखा का [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) मेथड उसकी भराव को निष्क्रिय करता है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मूव, लाइन, क्वाड्रेटिक, क्यूबिक और बंद करने वाले खंड प्रदान करता है, जिन्हें उदाहरण एक [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) पर पुनः चलाता है।

टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट में है। रूपरेखा को横‑दिशा में 20 पॉइंट और आकार के शीर्ष किनारे से 10 पॉइंट नीचे स्थित किया गया है। टेक्स्ट पथ को भरा गया है, जबकि मूल आयत केवल रूपरेखा बनी रहती है। दोनों पथों को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से एकल आकार बनता है जिसमें आयत और टेक्स्ट दोनों सम्मिलित होते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, GeometryPath, PathFillModeType

from java.awt import Font
from java.awt.geom import PathIterator
from java.awt.image import BufferedImage

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100)

    # आकार का ज्यामिति पथ प्राप्त करें।
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # टेक्स्ट के साथ नया ग्राफ़िक्स पथ बनाएं।
    font = Font("Arial", Font.PLAIN, 40)
    text = "Text in shape"
    image = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = image.createGraphics()
    try:
        font_context = graphics.getFontRenderContext()
        glyph_vector = font.createGlyphVector(font_context, text)
        text_bounds = glyph_vector.getVisualBounds()
        baseline = -text_bounds.getY() + 10
        graphics_path = glyph_vector.getOutline(20.0, baseline)
    finally:
        graphics.dispose()

    # ग्राफ़िक्स पथ को ज्यामिति पथ में परिवर्तित करें।
    text_path = GeometryPath()
    path_iterator = graphics_path.getPathIterator(None)
    points = jpype.JArray(jpype.JFloat)(6)
    while not path_iterator.isDone():
        segment_type = path_iterator.currentSegment(points)
        if segment_type == PathIterator.SEG_MOVETO:
            text_path.moveTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_LINETO:
            text_path.lineTo(points[0], points[1])
        elif segment_type == PathIterator.SEG_QUADTO:
            text_path.quadraticBezierTo(points[0], points[1], points[2], points[3])
        elif segment_type == PathIterator.SEG_CUBICTO:
            text_path.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5])
        elif segment_type == PathIterator.SEG_CLOSE:
            text_path.closeFigure()
        path_iterator.next()
    text_path.setFillMode(PathFillModeType.Normal)

    # मूल ज्यामिति पथ के साथ टेक्स्ट पथ लागू करें।
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ज्यामिति बदलने के बाद भराव और रूपरेखा क्या होते हैं?**

स्टाइल आकार के साथ रहता है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू होते हैं।

**मैं अपने कस्टम आकार को उसकी ज्यामिति के साथ सही तरह से कैसे घुमाूँ?**

आकार की [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) मेथड का उपयोग करें; ज्यामिति आकार के साथ घुड़ती है क्योंकि वह आकार के अपने निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक इमेज में बदल कर परिणाम को "लॉक" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/python-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/python-java/create-shape-thumbnails/) को रास्टर स्वरूप में निर्यात करें; यह जटिल ज्यामिति के साथ आगे के कार्य को सरल बनाता है।