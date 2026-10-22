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
- ज्यामिति पाथ
- पाथ बिंदु
- बिंदु संपादित करें
- बिंदु जोड़ें
- बिंदु हटाएं
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पाथ, वक्र कोने, संयुक्त आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पाथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि कैसे मौजूदा आकारों को संशोधित करने, बुनियादी पाथ संपादन संचालन करने, बिंदुओं को जोड़ने या हटाने, और अद्यतन ज्यामिति को फिर से एक आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) का उपयोग किया जाता है। यह यह भी दर्शाता है कि कैसे कस्टम और कॉम्पोज़िट आकार बनाएं, वक्र किनारों वाले आकार तैयार करें, यह निर्धारित करें कि आकार की ज्यामिति बंद है या नहीं, और कंटूर विश्लेषण के लिए आकार तत्वों को निकालें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* एक कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर घुमाव को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की परिधि को संशोधित कर सकते हैं या मौजूदा आकार को नई के आधार के रूप में उपयोग कर सकते हैं।

## **आकार संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय, इन अवधारणाओं को ध्यान में रखें:

* एक आकार (या उसका पाथ) या तो बंद या खुला हो सकता है।
* आकार का पाथ एंकर बिंदुओं से बना होता है जो खंडों द्वारा जुड़े होते हैं।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल इसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने के बिंदु, सीधे बिंदु, या स्मूद बिंदु के रूप में होते हैं:
  * कोने के बिंदु पर, सन्निहित खंड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधे बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।
* एंकर बिंदुओं को स्थानांतरित करने या उनके हैंडल को समायोजित करने से आकार की परिधि बदलती है।

संपादन बिंदुओं के माध्यम से PowerPoint आकारों को संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) इंस्टेंस [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) ऑब्जेक्ट के एक ज्यामिति पाथ को दर्शाता है।
* [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) प्राप्त करने के लिए, आप [GeometryShape.get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) मेथड का उपयोग कर सकते हैं।
* आकार के लिए [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) सेट करने हेतु, आप इन मेथड्स का उपयोग कर सकते हैं: एकल पाथ वाले आकारों के लिए [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/), और कई पाथ वाले आकारों के लिए [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/)।
* खंड जोड़ने के लिए, आप [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) के अंतर्गत मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath.stroke](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/stroke/) और [GeometryPath.fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/fill_mode/) प्रॉपर्टीज़ का उपयोग करके, आप एक ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।
* [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) प्रॉपर्टी का उपयोग करके, आप एक [GeometryShape](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खंडों की एरे के रूप में प्राप्त कर सकते हैं।

## **सरल संपादन संचालन**

ज्यामिति पाथ को संपादित करने के लिए निम्नलिखित मेथड्स का उपयोग करें। इंडेक्स स्वीकार करने वाले ओवरलोड्स पाथ के खंड एरे में शून्य-आधारित स्थिति पर एक खंड सम्मिलित करते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| एक सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु वाले क्यूबिक बीज़ियर कर्व को जोड़ें या सम्मिलित करें। | [GeometryPath.cubic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/cubic_bezier_to/) |
| एक नियंत्रण बिंदु और एक अंत बिंदु वाले क्वाड्रेटिक बीज़ियर कर्व को जोड़ें या सम्मिलित करें। | [GeometryPath.quadratic_bezier_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/quadratic_bezier_to/) |
| निर्दिष्ट आकार और डिग्री में कोणों के साथ एक दीर्घवृत्तीय आर्क जोड़ें। | [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) |
| वर्तमान आकृति को उसके अंत बिंदु को शुरुआती बिंदु से जोड़कर बंद करें। | [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) |
| एक आकृति का प्रारंभ बिंदु सेट करें। | [GeometryPath.move_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/move_to/) |
| शून्य-आधारित इंडेक्स पर एक खंड हटाएँ। | [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) |

## **एक आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण [GeometryPath.line_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/line_to/) का उपयोग करके एक आयताकार आकार में दो बिंदु सम्मिलित करता है और संशोधित पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) से लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु उसकी केंद्र में हैं, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट पर। खंड सूचकांक 1 और 4 उन्हें शीर्ष और निचले किनारों पर रखते हैं, जिससे वे किनारे अंदर की ओर खींचे जाते हैं।

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

## **एक आकार से बिंदु हटाएँ**

यह उदाहरण शून्य-आधारित सूचकांक 2 पर [GeometryPath.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/remove_at/) के साथ एक हार्ट-आकार की रूपरेखा को बदलता है। संशोधित पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) से लागू करने से आकार की रूपरेखा अपडेट होती है।

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

## **एक कस्टम आकार बनाएं**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) का उपयोग करके एक पाँच‑बिंदु सितारा बनाता है। 100 और 50 पॉइंट के वैकल्पिक बाहरी और आंतरिक त्रिज्या टिप्स और अंदरूनी हिस्सों को परिभाषित करती हैं; 72‑डिग्री का स्टेप पाँच टिप्स को समान रूप से स्थान देता है। पाथ को [GeometryPath.close_figure](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/close_figure/) से बंद किया जाता है और [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) का उपयोग करके एक आयताकार आकार पर लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

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

## **एक संयुक्त कस्टम आकार बनाएं**

यह उदाहरण आकार के ऊपर और नीचे के तिहाई भागों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/) ऑब्जेक्ट निर्धारित करता है। दोनों पाथ को [GeometryShape.set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) से लागू करने से मध्य तिहाई के पार एक गैप के साथ एकल संयुक्त आकार बनता है।

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

## **वक्र किनारों वाला कस्टम आकार बनाएं**

यह उदाहरण सीधे खंडों को [GeometryPath.arc_to](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/arc_to/) के साथ मिलाकर एक ऐसी आकार बनाता है जिसमें अंदर की ओर वक्र किनारे हों। प्रत्येक किनारे का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में निर्धारित करता है, और -90‑डिग्री स्वेप एक वैकल्पिक दिशा में चौथाई दीर्घवृत्त बनाता है। पूर्ण पाथ को [GeometryShape.set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) से लागू किया जाता है, और प्रस्तुति को PPTX प्रारूप में सहेजा जाता है।

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

## **जांचें कि क्या आकार की ज्यामिति बंद है**

निम्न सहायता जांचती है कि क्या प्रत्येक गैर‑खाली ज्यामिति पाथ एक बंद खंड के साथ समाप्त होती है। यह [GeometryPath.path_data](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/path_data/) को पढ़ती है और अंतिम खंड के [PathSegment.path_command](https://reference.aspose.com/slides/python-net/aspose.slides/pathsegment/path_command/) की तुलना [PathCommandType.CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides/pathcommandtype/) से करती है। जब कोई गैर‑खाली पाथ नहीं होते तो यह false लौटाती है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करती है; यह पाथ के भीतर प्रत्येक सबफ़िगर का निरीक्षण नहीं करती। उदाहरण एक आयत के लिए `True` प्रिंट करता है।

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

## **आकार तत्वों को निकालें और निरीक्षण करें**

[GeometryShape.create_shape_elements](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/create_shape_elements/) का उपयोग करके एक मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण करें। प्रत्येक लौटाए गए [ShapeElement](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/) अपने [path_points](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_points/) और [path_types](https://reference.aspose.com/slides/python-net/aspose.slides/shapeelement/path_types/) एरे को उजागर करता है। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्राइंग टूल्स को ज्यामिति पास करने के लिए उपयोगी है।

उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर सीधे पहला ज्यामिति आकार ढूँढता है, और उसके पाथ खंडों को प्रिंट करता है। सीधे और वक्र खंडों वाले आकार वाली प्रस्तुति का उपयोग करके दोनों प्रकार के आउटपुट देखें। यह समूहों के भीतर खोज नहीं करता।

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
                point_type = types[i] & 0x07  # सेगमेंट प्रकार रखें, फ़्लैग को छोड़ते हुए।
                if point_type == 0:
                    print(f"Start figure at {points[i]}")
                elif point_type == 1:
                    print(f"Line to {points[i]}")
                elif point_type == 3:
                    print(f"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}")
                    i += 2  # दोनों नियंत्रण बिंदुओं और अंत बिंदु को उपभोग करें।

                if (types[i] & 0x80) != 0:
                    print("Close subpath back to its starting point.")
                i += 1
```

एरे इंडेक्स के अनुसार मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका को वर्णित करता है। प्रकार `0` एक आकृति शुरू करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा खींचता है। एक क्यूबिक बीज़ियर खंड पिछले अंत बिंदु से शुरू होता है और तीन क्रमिक प्रकार-`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में उपभोग करता है और बंद होने के लिए अंत बिंदु की जाँच करता है।

बिंदु प्रकारों में फ़्लैग भी होते हैं। खंड प्रकार पहचानने के लिए `0x07` से मास्क करें, और बंद सबपाथ का पता लगाने के लिए `0x80` को अलग से परीक्षण करें। उदाहरण के लिए, `129` (`0x81`) एक रेखा अंत बिंदु दर्शाता है जो सबपाथ को बंद करता है, और `131` (`0x83`) एक बीज़ियर अंत बिंदु दर्शाता है जो एक को बंद करता है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये मामलों छूट जाएंगे। अन्य फ़्लैग, जैसे डैश (`0x10`) और मार्कर (`0x20`), मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण.** बिंदुओं को पॉइंट में मापा जाता है (1/72 इंच), जहाँ X दाएँ की ओर बढ़ता है और Y नीचे की ओर। एक अनग्रुप्ड आकार के लिए, निकाले गए निर्देशांक पहले से ही उसके [x](https://reference.aspose.com/slides/python-net/aspose.slides/shape/x/) और [y](https://reference.aspose.com/slides/python-net/aspose.slides/shape/y/) स्थितियों को शामिल करते हैं और उसकी वर्तमान चौड़ाई और ऊँचाई को दर्शाते हैं। उदाहरण के लिए, `(100, 200)` पर स्थित, `120 × 80` आकार का बिना घुमाव वाला आयत कंटूर सीमा `(100, 200)`–`(220, 280)` रखता है। आकार की स्थिति को दोबारा न जोड़ें। उसके X और Y को घटाकर अनरोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गए बिंदुओं पर आकार की [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) या क्षैतिज/अनुदैर्ध्य फ्लिप नहीं लगते। प्रदर्शित कंटूर को पुन: निर्मित करने के लिए, इन रूपांतरणों को आकार के केंद्र के आसपास लागू करें। समूहित आकारों के लिए, समूह निर्देशांक मानचित्रण और रूपांतरणों को भी ध्यान में रखें; यह न मानें कि निकाले गए बिंदु अंतिम रेंडर किए स्लाइड निर्देशांक हैं या यदि यह पहले से ही चाइल्ड फ्रेम में परिलक्षित है तो अनुवाद या स्केल दो बार लागू न करें।

**निरीक्षण बनाम संपादन.** निकाले गए एरे कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। इस विधि को तब चुनें जब आपके विश्लेषण या ड्राइंग कोड को बिंदु/प्रकार एरे की आवश्यकता हो। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या उसकी ज्यामिति संपादित करनी हो तो [get_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/get_geometry_paths/) का उपयोग करें। संशोधित पाथ को [set_geometry_path](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_path/) या [set_geometry_paths](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/set_geometry_paths/) के माध्यम से लागू करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति को बदलने के बाद भराव और रूपरेखा के साथ क्या होगा?**

स्टाइल आकार के साथ ही रहता है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वतः नई ज्यामिति पर लागू हो जाते हैं।

**मैं कस्टम आकार को उसकी ज्यामिति के साथ सही तरीके से कैसे घुमा सकता हूँ?**

आकार की [rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) प्रॉपर्टी का उपयोग करें; ज्यामिति आकार के साथ घूमती है क्योंकि यह आकार के अपने निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदल सकता हूँ ताकि परिणाम 'लॉक' हो जाए?**

हाँ। आवश्यक [slide](/slides/hi/python-net/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/python-net/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के काम को सरल बनाता है।