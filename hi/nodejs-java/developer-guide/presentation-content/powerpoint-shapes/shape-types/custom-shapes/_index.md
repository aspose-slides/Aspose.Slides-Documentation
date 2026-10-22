---
title: जावास्क्रिप्ट में प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/nodejs-java/custom-shape/
keywords:
- कस्टम आकार
- आकार जोड़ें
- आकार बनाएं
- आकार बदलें
- आकार जियोमेट्री
- जियोमेट्री पाथ
- पाथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन ऑपरेशन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: जियोमेट्री पाथ, वक्र कोने, सम्मिलित आकार।"
---
## **परिचय**

यह लेख यह समझाता है कि Aspose.Slides में शैप जियोमेट्री को संपादन बिंदुओं और जियोमेट्री पाथ्स के माध्यम से संपादित करके प्रस्तुति आकारों को कैसे अनुकूलित किया जाए। यह दिखाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) का उपयोग करके मौजूदा आकारों को संशोधित किया जा सकता है, बुनियादी पाथ संपादन कार्य किए जा सकते हैं, बिंदुओं को जोड़ा या हटाया जा सकता है, और अद्यतन जियोमेट्री को फिर से एक आकार पर लागू किया जा सकता है।

यह यह भी दर्शाता है कि कैसे कस्टम और सम्मिलित आकार बनाए जाएँ, वक्र कोनों वाले आकार बनाएँ, यह निर्धारित किया जाए कि क्या एक आकार जियोमेट्री बंद है, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट रूपरेखाओं को जियोमेट्री पाथ्स में परिवर्तित करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में आप **संपादन बिंदुओं** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप एक आकार की रूपरेखा को बदल सकते हैं या किसी मौजूदा आकार को नए आकार के आधार के रूप में उपयोग कर सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय निम्नलिखित अवधारणाओं को ध्यान में रखें:

* एक आकार (या उसका पाथ) बंद या खुला दोनों हो सकता है।
* एक आकार का पाथ एंकर बिंदुओं और खंडों (segments) से बना होता है।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैण्डल इसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने वाले बिंदु, सीधा बिंदु, या स्मूद बिंदु हो सकते हैं:
  * कोने वाले बिंदु पर, आसन्न खंड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैण्डल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैण्डल संरेखित होते हैं लेकिन एंकर बिंदु से विभिन्न दूरी पर हो सकते हैं।
* एंकर बिंदुओं को ले जाकर या उनके हैंडल को समायोजित करके आप आकार की रूपरेखा बदलते हैं।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) इंस्टेंस [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) ऑब्जेक्ट की जियोमेट्री पाथ को दर्शाता है।
* [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग करके आप [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) प्राप्त कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) सेट करने के लिए आप ये मेथड उपयोग कर सकते हैं: एकल पाथ वाले आकारों के लिए [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) और बहु‑पाथ वाले आकारों के लिए [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)।
* खंड जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) के तहत उपलब्ध मेथड उपयोग कर सकते हैं।
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) मेथड का उपयोग करके आप जियोमेट्री पाथ की उपस्थिति सेट कर सकते हैं।
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) मेथड का उपयोग करके आप [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) की जियोमेट्री पाथ को पाथ खंडों की एरे के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त shape जियोमेट्री कस्टमाइज़ेशन विकल्पों तक पहुँचने के लिए आप एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और खंडों को एक [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) पर पुनः चलाकर लागू कर सकते हैं।

## **सरल संपादन ऑपरेशन**

जियोमेट्री पाथ को संपादित करने के लिए नीचे दिए गए मेथड का उपयोग करें। ओवरलोड जो एक इंडेक्स स्वीकार करते हैं, वह पाथ के खंड एरे में शून्य‑आधारित स्थिति पर खंड को सम्मिलित करते हैं।

| ऑपरेशन | विधि |
| --- | --- |
| सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु के साथ क्यूबिक Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु और एक अंत बिंदु के साथ क्वाड्रेटिक Bézier वक्र जोड़ें या सम्मिलित करें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम और डिग्री में कोणों के साथ दीर्घवृतीय चाप जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| वर्तमान फ़िगर को उसके अंत बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| फ़िगर का प्रारंभ बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| शून्य‑आधारित इंडेक्स पर खंड हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदु एक आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) का उपयोग करके सम्मिलित करता है और संपादित पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू करता है। समन्वय आकार के सापेक्ष स्थानीय होते हैं: दोनों नए बिंदु आकार के केंद्र में हैं, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट पर। खंड इंडेक्स 1 और 4 उन्हें क्रमशः शीर्ष और निचले किनारों पर रखते हैं, जिससे वे किनारे अंदर की ओर खींचे जाते हैं।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```

![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) के साथ शून्य‑आधारित इंडेक्स 2 पर खंड हटाकर हार्ट‑शेप रूपरेखा को बदलता है। संशोधित पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू करने से आकार की रूपरेखा अपडेट हो जाती है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Heart, 100, 100, 300, 300);

    const path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **कस्टम आकार बनाना**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) का उपयोग करके पाँच‑कोणीय स्टार बनाता है। बाहरी और आंतरिक त्रिज्या क्रमशः 100 और 50 पॉइंट के वैकल्पिक मान टिप्स और इंडेंटेशन को परिभाषित करते हैं; 72‑डिग्री का चरण पाँच टिप्स को समान रूप से वितरित करता है। पाथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया जाता है और [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) से एक आयताकार आकार पर लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const points = [];
const outerRadius = 100;
const innerRadius = 50;
const angleStep = 72;

for (let angle = -90; angle < 270; angle += angleStep) {
    let radians = angle * Math.PI / 180;
    points.push({ x: outerRadius * Math.cos(radians) + outerRadius, y: outerRadius * Math.sin(radians) + outerRadius });
    radians = (angle + angleStep / 2) * Math.PI / 180;
    points.push({ x: innerRadius * Math.cos(radians) + outerRadius, y: innerRadius * Math.sin(radians) + outerRadius });
}

const starPath = new slides.GeometryPath();
starPath.moveTo(java.newFloat(points[0].x), java.newFloat(points[0].y));
for (let i = 1; i < points.length; i++) {
    starPath.lineTo(java.newFloat(points[i].x), java.newFloat(points[i].y));
}
starPath.closeFigure();

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **संयुक्त कस्टम आकार बनाना**

यह उदाहरण एक आकार के ऊपर और नीचे के तिहाई भागों के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ऑब्जेक्ट परिभाषित करता है। दोनों पाथ को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) के साथ लागू करने से मध्य तिहाई में एक अंतर के साथ एक एकल सम्मिलित आकार बनता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const topPath = new slides.GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3));
    topPath.lineTo(0, java.newFloat(shape.getHeight() / 3));
    topPath.closeFigure();

    const bottomPath = new slides.GeometryPath();
    bottomPath.moveTo(0, java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), java.newFloat(shape.getHeight() / 3 * 2));
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    const paths = java.newArray("com.aspose.slides.GeometryPath", [topPath, bottomPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों वाले कस्टम आकार बनाना**

यह उदाहरण सीधी खंडों को [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर अंतर्मुख‑वक्र कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में सेट करता है, और -90‑डिग्री का स्वीप एक प्रतिक्लॉकवाइज क्वार्टर एलीप्स बनाता है। पूर्ण पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, और प्रस्तुति को PPTX प्रारूप में सहेजा जाता है।

```javascript
const slides = require("aspose.slides.via.java");

const shapeX = 20;
const shapeY = 20;
const shapeWidth = 300;
const shapeHeight = 200;

const leftTopSize = 50;
const rightTopSize = 20;
const rightBottomSize = 40;
const leftBottomSize = 10;

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    const geometryPath = new slides.GeometryPath();
    geometryPath.moveTo(leftTopSize, 0);
    geometryPath.lineTo(shapeWidth - rightTopSize, 0);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(shapeWidth, shapeHeight - rightBottomSize);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(leftBottomSize, shapeHeight);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(0, leftTopSize);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **जाँचें कि क्या आकार जियोमेट्री बंद है**

निम्नलिखित हेल्पर यह जाँचता है कि क्या प्रत्येक गैर‑खाली जियोमेट्री पाथ एक बंद खंड के साथ समाप्त होती है। यह [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) पढ़ता है और अंतिम खंड के [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) से करता है। जब कोई गैर‑खाली पाथ नहीं होती तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑फ़िगर की जाँच नहीं करता। उदाहरण में यह आयत के लिए `true` प्रिंट करता है।

```javascript
const slides = require("aspose.slides.via.java");

function isGeometryClosed(geometryShape) {
    let hasNonemptyPath = false;
    for (const geometryPath of geometryShape.getGeometryPaths()) {
        const segments = geometryPath.getPathData();
        if (segments.length === 0) {
            continue;
        }
        hasNonemptyPath = true;
        const lastSegment = segments[segments.length - 1];
        if (lastSegment.getPathCommand() !== slides.PathCommandType.Close) {
            return false;
        }
    }
    return hasNonemptyPath;
}

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 200, 100);

    const closed = isGeometryClosed(shape);
    console.log(closed);
} finally {
    presentation.dispose();
}
```

## **आकार तत्वों को निकालें और निरीक्षण करें**

एक मौजूदा आकार को तत्वों के रूप में निरीक्षण करने के लिए आप [GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) का उपयोग कर सकते हैं, जहाँ प्रत्येक तत्व में पाथ बिंदु और बिंदु प्रकार होते हैं। प्रत्येक लौटाए गये [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) को [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) मेथड के माध्यम से बिंदु और प्रकार एरे प्राप्त होते हैं। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्रॉइंग टूल्स को जियोमेट्री पास करने के लिए उपयोगी है।

उदाहरण input.pptx को खोलता है, पहले स्लाइड पर पहले जियोमेट्री शैप को ढूँढता है, और उसके पाथ खंडों को प्रिंट करता है। ऐसी प्रस्तुति का उपयोग करें जिसमें आकार में सीधी और वक्र दोनों खंड हों ताकि दोनों प्रकार का आउटपुट देखा जा सके। यह समूहों के भीतर नहीं खोजता।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let shape = null;
    for (let index = 0; index < slide.getShapes().size(); index++) {
        const candidate = slide.getShapes().get_Item(index);
        if (java.instanceOf(candidate, "com.aspose.slides.GeometryShape")) {
            shape = candidate;
            break;
        }
    }

    if (shape == null) {
        console.log("No geometry shape found on the first slide.");
    } else {
        for (const shapeElement of shape.createShapeElements()) {
            const points = shapeElement.getPathPoints();
            const types = shapeElement.getPathTypes();
            console.log("Shape element:");

            for (let i = 0; i < points.length; i++) {
                const pointType = types[i] & 0x07; // Keep the segment type, excluding flags.
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    console.log("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

एरे इंडेक्स के अनुसार मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका वर्णित करता है। प्रकार `0` एक फ़िगर की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक लाइन खींचता है। एक क्यूबिक Bézier खंड पिछले अंत बिंदु से शुरू होता है और तीन क्रमिक प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में उपभोग करता है और बंद होने के लिए अंत बिंदु की जाँच करता है।

बिंदु प्रकारों में फ़्लैग भी होते हैं। `0x07` के साथ मास्क करके खंड प्रकार पहचाना जाता है, और `0x80` को अलग से परीक्षण करके बंद सब‑पाथ पाया जाता है। उदाहरण के लिये, `129` (`0x81`) का अर्थ है एक लाइन अंत बिंदु जो सब‑पाथ को बंद करता है, और `131` (`0x83`) का अर्थ है एक Bézier अंत बिंदु जो बंद करता है। Java इन फ़्लैग को साइन‑ड बाइट में संग्रहीत करता है; मास्किंग मूल बिट मानों को बरकरार रखती है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये मामलों छूट जाएंगे। अन्य फ़्लैग, जैसे डैश (`0x10`) और मार्कर (`0x20`), बेस खंड प्रकार को नहीं बदलते।

**समन्वय और रूपांतरण।** बिंदु पॉइंट में मापे जाते हैं (1/72 इंच), जहाँ X दाएँ बढ़ता है और Y नीचे की ओर। अन‑ग्रुप्ड आकार के लिए निकाले गए समन्वय पहले से ही [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) द्वारा लौटाए गये स्थिति को शामिल करते हैं और उसकी वर्तमान चौड़ाई व ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित, `120 × 80` आकार वाला अन‑रोटे़टेड आयत का कंटूर बाउंड `(100, 200)`–`(220, 280)` है। आकार की स्थिति को फिर से जोड़ने की आवश्यकता नहीं। उसके X और Y को घटाकर वह बिंदु प्राप्त करें जो अन‑रोटे़टेड फ्रेम के सापेक्ष हों।

निकाले गए बिंदु [getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation) द्वारा लौटाए गये घुमाव या क्षैतिज/लंबवत फ्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः उत्पन्न करने के लिए इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिए, समूह समन्वय मैपिंग और रूपांतरणों को भी ध्यान में रखें; यह मान न बनें कि निकाले गए बिंदु अंतिम रेंडर किए गये स्लाइड समन्वय हैं या यदि वह पहले ही बच्चे के फ्रेम में परिलक्षित है तो अनावश्यक रूप से अनुवाद या स्केल दोहराएँ नहीं।

**जाँच बनाम संपादन।** निकाले गये एरे केवल कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। जब आपके विश्लेषण या ड्रॉइंग कोड को बिंदु/प्रकार एरे की आवश्यकता हो तो इस विधि को चुनें। जब आपको आकार की स्थानीय समन्वय प्रणाली में जियोमेट्री कमांड चाहिए या जियोमेट्री को संपादित करना हो तो [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) उपयोग करें। संपादित पाथ को [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करें।

## **Java AWT Shape को GeometryPath में परिवर्तित करें**

यह उदाहरण एक आयताकार रूपरेखा को टेक्स्ट के साथ मिलाता है जिसे जियोमेट्री में परिवर्तित किया गया है। रूपरेखा का [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) मेथड उसकी भराई को निष्क्रिय करता है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मूव, लाइन, क्वाड्रेटिक, क्यूबिक, और क्लोज़िंग खंड प्रदान करता है, जिन्हें उदाहरण एक [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) पर पुनः चलाता है।

Java ब्रीज संबंधित Java पैरामीटर के लिये स्पष्ट फ़्लोट और बाइट मान उपयोग करता है। इटेरेटर निर्देशांक को एक Java फ़्लोट एरे में लिखता है; रिफ्लेक्शन उसके अपडेटेड मानों को वापस JavaScript में पढ़ता है। टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट में है। रूपरेखा को क्षैतिज रूप से 20 पॉइंट शिफ्ट किया गया है और दृश्य शीर्ष से 10 पॉइंट नीचे shape की शीर्ष किनारे पर स्थित किया गया है। टेक्स्ट पाथ को भरा गया है, जबकि मूल आयत रूपरेखा बनी रहती है। दोनों पाथ को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) के साथ लागू करने से एकल आकार बनता है जिसमें आयत और टेक्स्ट दोनों शामिल होते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 300, 100);
    
    const originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(java.newByte(slides.PathFillModeType.None));

    const font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    const image = java.newInstanceSync("java.awt.image.BufferedImage", 100, 100, java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
    const graphics = image.createGraphics();
    let graphicsPath;
    try {
        const fontContext = graphics.getFontRenderContext();
        const glyphVector = font.createGlyphVector(fontContext, "Text in shape");
        const textBounds = glyphVector.getVisualBounds();
        const baseline = java.newFloat(-textBounds.getY() + 10);
        graphicsPath = glyphVector.getOutline(java.newFloat(20), baseline);
    } finally {
        graphics.dispose();
    }

    const textPath = new slides.GeometryPath();
    const pathIterator = graphicsPath.getPathIterator(null);
    const coordinates = java.newArray("float", [0, 0, 0, 0, 0, 0]);

    while (!pathIterator.isDone()) {
        const segmentType = pathIterator.currentSegment(coordinates);
        const points = [];
        for (let i = 0; i < 6; i++) {
            const coordinate = java.callStaticMethodSync("java.lang.reflect.Array", "getFloat", coordinates, i);
            points.push(java.newFloat(coordinate));
        }
        switch (segmentType) {
            case 0: // स्थानांतरित करें।
                textPath.moveTo(points[0], points[1]);
                break;
            case 1: // रेखा तक।
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // क्वाड्रेटिक बीज़ियर वक्र।
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // क्यूबिक बीज़ियर वक्र।
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // फ़िगर बंद करें।
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }
    textPath.setFillMode(java.newByte(slides.PathFillModeType.Normal));
    const paths = java.newArray("com.aspose.slides.GeometryPath", [originalPath, textPath]);
    shape.setGeometryPaths(paths);
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**जियोमेट्री को बदलने के बाद भराव और रूपरेखा क्या होगी?**

स्टाइल आकार के साथ बना रहता है; केवल कंटूर बदलती है। भराव और रूपरेखा स्वचालित रूप से नई जियोमेट्री पर लागू हो जाती हैं।

**कस्टम आकार को उसकी जियोमेट्री के साथ सही तरीके से कैसे घुमाएँ?**

आकार की [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) मेथड का उपयोग करें; जियोमेट्री आकार के साथ घुमती है क्योंकि यह आकार के अपने समन्वय प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को एक इमेज में परिवर्तित कर "लॉक इन" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/nodejs-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/nodejs-java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; इससे जटिल जियोमेट्री के साथ आगे के काम को सरल बनाया जा सकता है।