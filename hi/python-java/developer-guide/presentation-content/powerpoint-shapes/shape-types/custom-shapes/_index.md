---
title: Python के माध्यम से Java में प्रस्तुति आकारों को अनुकूलित करें
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
- संपादन प्रक्रिया
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोने, सम्मिलित आकार।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि मौजूदा आकारों को संशोधित करने, बुनियादी पथ संपादन संचालन करने, बिंदुओं को जोड़ने या हटाने, और अद्यतन ज्यामिति को फिर से आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) के साथ कैसे काम किया जाए।

यह उदाहरण भी दिखाता है कि कैसे कस्टम और सम्मिलित आकार बनाएँ, कर्व्ड कोनों वाले आकार बनाएँ, यह निर्धारित करें कि कोई आकार ज्यामिति बंद है या नहीं, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट आउटलाइन को ज्यामिति पथों में परिवर्तित करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको आकार की रूपरेखा को बदलने या मौजूदा आकार को नई रूपरेखा के आधार के रूप में उपयोग करने की सुविधा देते हैं।

## **Shape Editing Tips**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय, इन अवधारणाओं को ध्यान में रखें:

* कोई आकार (या उसका पथ) बंद या खुला हो सकता है।
* किसी आकार का पथ एंकर बिंदुओं द्वारा जुड़े खंडों से बना होता है।
* एक खंड सीधा या कर्व्ड हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसके आकार को निर्धारित करते हैं।
* एंकर बिंदु कोना बिंदु, सीधा बिंदु, या स्मूद बिंदु के रूप में मौजूद होते हैं:
  * कोना बिंदु पर, साथ जुड़े खंड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से विभिन्न दूरी पर हो सकते हैं।
* एंकर बिंदुओं को स्थानांतरित करने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** क्लास [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) ऑब्जेक्ट का ज्यामिति पथ दर्शाता है।
* [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) से [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) सेट करने हेतु, एकल पथ वाले आकारों के लिए आप [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) और बहु‑पथ वाले आकारों के लिए [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) का उपयोग कर सकते हैं।
* खंड जोड़ने के लिये, आप [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) के तहत प्रदान किए गये मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath.setStroke](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath.setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) मेथड्स का प्रयोग करके आप किसी ज्यामिति पथ की उपस्थिति निर्धारित कर सकते हैं।
* [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) मेथड से आप किसी [GeometryShape](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/) का ज्यामिति पथ खंडों की array के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों तक पहुँचने के लिये, आप एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसकी [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और उन खंडों को किसी [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) पर दोहरा सकते हैं।

## **Simple Editing Operations**

निम्न मेथड्स का प्रयोग करके आप किसी ज्यामिति पथ को संपादित कर सकते हैं। ओवरलोड्स जो इंडेक्स स्वीकार करते हैं, वह शून्य‑आधारित स्थिति में एक खंड डालते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| सीधी रेखा जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु के साथ क्यूबिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु और एक अंत बिंदु के साथ क्वाड्रैटिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम और डिग्री में कोणों के साथ अण्डाकार चाप जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) |
| आकृति का प्रारंभ बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#moveTo) |
| शून्य‑आधारित इंडेक्स पर खंड हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) |

## **Add Custom Points to a Shape**

यह उदाहरण दो बिंदुओं को एक आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#lineTo) का उपयोग करके सम्मिलित करता है और संपादित पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) के साथ लागू करता है। निर्देशांक आकार के स्थानीय हैं: दोनों नए बिंदु उसके केंद्र में हैं, बाएँ किनारे से 100 पॉइंट और शीर्ष किनारे से 50 पॉइंट की दूरी पर। खंड सूचकांक 1 और 4 उन्हें क्रमशः शीर्ष और निचले किनारे पर रखता है, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

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

## **Remove Points from a Shape**

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#removeAt) का उपयोग करके शून्य‑आधारित सूचकांक 2 पर खंड हटाकर हृदय‑आकृति की रूपरेखा को बदलता है। संशोधित पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) के साथ लागू करने से आकार की रूपरेखा अपडेट होती है।

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

## **Create a Custom Shape**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) का उपयोग करके पाँच‑बिंदु वाला सितारा बनाता है। 100 और 50 पॉइंट के वैकल्पिक बाहरी और आंतरिक त्रिज्या टिप्स और अभ्यंतरों को परिभाषित करती हैं; 72‑डिग्री कदम शीर्षों को समान रूप से वितरित करता है। पथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया जाता है और एक आयताकार आकार पर [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) के साथ लागू किया जाता है, जिससे उसकी रूपरेखा प्रतिस्थापित हो जाती है।

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

## **Create a Composite Custom Shape**

यह उदाहरण शीर्ष और निचले भागों के लिये दो बंद [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) वस्तुएँ परिभाषित करता है। दोनों पथों को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से मध्य भाग में एक अंतर के साथ एकल सम्मिलित आकार बनता है।

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

## **Create a Custom Shape with Curved Corners**

यह उदाहरण सीधे खंडों को [GeometryPath.arcTo](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर भीतर की ओर वक्र किनारे वाला आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में निर्धारित करता है, और -90‑डिग्री स्विप एक प्रतिचक्र दिशा में क्वार्टर अण्डाकार बनाता है। पूर्ण पथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, और प्रस्तुति को PPTX रूप में संग्रहीत किया जाता है।

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

## **Find Out If a Shape Geometry Is Closed**

निम्न हेल्पर जाँचता है कि प्रत्येक गैर‑खाली ज्यामिति पथ अंत में बंद खंड के साथ समाप्त होता है या नहीं। यह [GeometryPath.getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) को पढ़ता है और अंतिम खंड के [PathSegment.getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/python-java/aspose.slides/pathcommandtype/) से करता है। जब कोई गैर‑खाली पथ नहीं होता तो यह `False` लौटाता है। यह प्रत्येक पथ की अंतिम कमांड की जाँच करता है; यह पथ के भीतर प्रत्येक उप‑आकृति को नहीं देखता। उदाहरण में आयत के लिये `True` प्रदर्शित होता है।

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

## **Inspect Geometry Path Commands**

[contour.pptx](contour.pptx) डाउनलोड करें और इसे अनुप्रयोग की कार्यशील निर्देशिका में रखें। पहले स्लाइड पर पहला आकार एक सीधी शीर्ष किनारा, एक क्यूबिक Bézier वक्र, और एक सीधा बंद किनारा रखता है। आकार के पथों को पढ़ने के लिये आप [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) का प्रयोग करें और प्रत्येक पथ के खंडों को ड्राइंग क्रम में पढ़ने के लिये [getPathData](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#getPathData) का उपयोग करें। प्रत्येक खंड के लिये, [getPathCommand](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getPathCommand) कमांड पहचानता है और निर्धारित करता है कि [getSegmentData](https://reference.aspose.com/slides/python-java/aspose.slides/pathsegment/#getSegmentData) द्वारा लौटाए गये मानों की कैसे व्याख्या की जाए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PathCommandType, Presentation

presentation = Presentation("contour.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    for i, path in enumerate(shape.getGeometryPaths()):
        for j, segment in enumerate(path.getPathData()):
            command = segment.getPathCommand()
            data = segment.getSegmentData()
            if command in (PathCommandType.MoveTo, PathCommandType.LineTo):
                detail = f"destination=({data[0]}, {data[1]})"
            elif command == PathCommandType.CubicBezierTo:
                detail = f"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})"
            elif command == PathCommandType.Close:
                detail = "no coordinates"
            else:
                detail = f"raw={list(data)}"
            name = PathCommandType.getName(PathCommandType.class_, command)
            print(f"Path {i}, segment {j}: {name} {detail}")
finally:
    presentation.dispose()
```

आकार स्लाइड पर (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गये निर्देशांक आकार के स्थानीय हैं, जहाँ (0, 0) उसका ऊपर‑बायाँ कोना है, x दाएँ की ओर बढ़ता है, और y नीचे की ओर।

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **Extract and Inspect Shape Elements**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#createShapeElements) का उपयोग करके आप किसी मौजूदा आकार को तत्वों के रूप में देख सकते हैं, जिनमें पथ बिंदु और बिंदु प्रकार होते हैं। प्रत्येक प्राप्त तत्व को `jpype.JObject` के साथ [ShapeElement](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/) में कास्ट करके आप [getPathPoints](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/python-java/aspose.slides/shapeelement/#getPathTypes) मेथड्स के द्वारा बिंदु और प्रकार की arrays प्राप्त कर सकते हैं। यह प्रतिनिधित्व कॉन्टूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिये उपयोगी है।

उदाहरण input.pptx खोलता है, पहले स्लाइड पर पहले ज्यामिति आकार को खोजता है, और उसके पथ खंडों को प्रिंट करता है। सीधी और कर्व्ड खंडों वाले आकार वाली प्रस्तुति का उपयोग करने पर दोनों प्रकार का आउटपुट देखा जा सकता है। यह समूहों के भीतर खोज नहीं करता।

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
                point_type = types[i] & 0x07  # सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखते हुए।
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # दोनो नियंत्रण बिंदुओं और अंत बिंदु को खपत करें।

                if types[i] & 0x80:
                    print("Close subpath back to its starting point.")
                i += 1
finally:
    presentation.dispose()
```

Arrays इंडेक्स द्वारा संबंधित होते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका का वर्णन करता है। प्रकार `0` आकृति की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक एक रेखा बनाता है। एक क्यूबिक Bézier खंड पिछले अंत बिंदु से शुरू होता है और लगातार तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया अंत बिंदु। लूप इन तीन प्रविष्टियों को एक साथ लेता है और बंद होने के लिये अंतिम बिंदु जाँचता है।

बिंदु प्रकार में फ़्लैग भी होते हैं। सेगमेंट प्रकार पहचानने के लिये `0x07` से मास्क करें, और बंद उप‑पथ पहचानने के लिये `0x80` को अलग‑अलग परीक्षण करें। उदाहरण के लिये, `129` (`0x81`) का अर्थ है एक रेखा अंत बिंदु जो उप‑पथ को बंद करता है, और `131` (`0x83`) का अर्थ है एक Bézier अंत बिंदु जो बंद करता है। Java इन फ़्लैग को signed bytes में रखता है; मास्किंग मूल बिट मानों को संरक्षित रखती है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये स्थितियाँ चूक जाती हैं। अन्य फ़्लैग, जैसे dash (`0x10`) और marker (`0x20`), मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु points (1/72 इंच) में मापे जाते हैं, X दाएँ ओर बढ़ता है और Y नीचे की ओर। एक अन‑ग्रुप्ड आकार के लिये, निकाले गये निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getY) द्वारा लौटाई गई स्थिति तथा वर्तमान चौड़ाई‑ऊँचाई को सम्मिलित करते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित, `120 × 80` आकार वाला अपरिवर्तित आयत की सीमा `(100, 200)`–`(220, 280)` होगी। आकार की स्थिति को दोबारा जोड़ें नहीं। कॉन्टूर को स्थानीय फ्रेम के सापेक्ष प्राप्त करने के लिये X और Y को घटाएँ।

निकाले गये बिंदु आकार का rotation, जो [getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getRotation) से मिलता है, या क्षैतिज व लंबवत फ़्लिप को नहीं दर्शाते। प्रदर्शित कॉन्टूर को पुनः प्राप्त करने के लिये इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह के निर्देशांक मैपिंग और रूपांतरणों को भी ध्यान में रखें; यह न मानें कि निकाले गये बिंदु अंतिम स्लाइड निर्देशांक हैं या यदि उन्हें पहले ही बच्चे के फ्रेम में सम्मिलित किया गया है तो अनावश्यक अनुवाद या स्केल न जोड़ें।

**निरीक्षण बनाम संपादन।** निकाली गयी arrays केवल कॉन्टूर का वर्णन करती हैं; उन्हें बदलने से मूल आकार अद्यतन नहीं होता। यह तरीका तब उपयोगी है जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार arrays की आवश्यकता रखता है। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड्स चाहिए या उसकी ज्यामिति को संपादित करना है, तो [getGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#getGeometryPaths) का उपयोग करें। संपादित पथों को [setGeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) के द्वारा लागू करें।

## **Convert a Java AWT Shape to GeometryPath**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ जोड़ता है जो ज्यामिति में परिवर्तित किया गया है। रूपरेखा की [setFillMode](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/#setFillMode) मेथड उसके भराव को निष्क्रिय करती है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) move, line, quadratic, cubic और closing खंड प्रदान करता है, जिन्हें उदाहरण [GeometryPath](https://reference.aspose.com/slides/python-java/aspose.slides/geometrypath/) पर दोहराता है।

टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट में है। रूपरेखा को क्षैतिज रूप में 20 पॉइंट और आकार के शीर्ष किनारे से 10 पॉइंट नीचे दृश्य शीर्ष पर रख दिया गया है। टेक्स्ट पथ को भरा जाता है, जबकि मूल आयत केवल रूपरेखा रहती है। दोनों पथों को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setGeometryPaths) के साथ लागू करने से एक ही आकार बनता है जिसमें आयत और टेक्स्ट दोनों होते हैं।

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

    # आकृति का ज्यामिति पथ प्राप्त करें।
    original_path = shape.getGeometryPaths()[0]
    original_path.setFillMode(PathFillModeType.None_)

    # टेक्स्ट के साथ एक नया ग्राफ़िक्स पथ बनाएं।
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

    # टेक्स्ट पथ को मूल ज्यामिति पथ के साथ लागू करें।
    shape.setGeometryPaths([original_path, text_path])
finally:
    presentation.dispose()
```
![example5_image](custom_shape_5.png)

## **FAQ**

**ज्यामिति बदलने के बाद भराव और रूपरेखा में क्या होता है?**

शैली आकार के साथ बनी रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाती है।

**मैं अपनी कस्टम आकृति को उसकी ज्यामिति के साथ सही तरीके से कैसे घुमाूँ?**

आकृति की [setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) मेथड का उपयोग करें; ज्यामिति आकार के साथ घुमती है क्योंकि वह आकार के अपने निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदलकर परिणाम "लॉक" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/python-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/python-java/create-shape-thumbnails/) को रास्टर स्वरूप में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के काम को सरल बनाता है।