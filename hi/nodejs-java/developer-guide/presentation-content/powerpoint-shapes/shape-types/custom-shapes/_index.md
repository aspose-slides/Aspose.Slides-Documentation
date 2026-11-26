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
- आकार ज्यामिति
- ज्यामिति पाथ
- पाथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन संचालन
- घुमावदार कोना
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पाथ, घुमावदार कोने, सम्मिलित आकार."
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादित बिंदुओं और ज्यामितीय पाथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने की विधि को समझाता है। यह दिखाता है कि कैसे मौजूदा आकारों को संशोधित करने, बुनियादी पाथ संपादन संचालन करने, बिंदुओं को जोड़ने या हटाने, और अद्यतन ज्यामिति को पुनः आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) का उपयोग किया जाता है।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और संयोजन आकार बनाएँ, किनारे घुमावदार वाले आकार बनाएँ, किसी आकार की ज्यामिति बंद है या नहीं निर्धारित करें, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट आउटलाइन को ज्यामिति पाथ में परिवर्तित करें।

## **संपादन बिंदुओं के द्वारा आकार बदलें**

PowerPoint में आप **Edit Points** का उपयोग करके वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको आकार की रूपरेखा बदलने या मौजूदा आकार को नई आकार की आधार बनाने की सुविधा देते हैं।

## **आकार संपादन युक्तियाँ**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को ध्यान में रखें:

* कोई आकार (या उसका पाथ) बंद या खुला हो सकता है।
* आकार का पाथ एंकर बिंदुओं द्वारा जुड़े खंडों से बना होता है।
* एक खंड सीधा या घुमावदार हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोना बिंदु, सीधा बिंदु या स्मूद बिंदु के रूप में मौजूद होते हैं:
  * कोना बिंदु पर, सटे खंड कोण बनाते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।
* एंकर बिंदुओं को ले जाना या उनके हैंडल को समायोजित करना आकार की रूपरेखा बदलता है।

PowerPoint आकारों को संपादन बिंदुओं के द्वारा संपादित करने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) ऑब्जेक्ट की ज्यामिति पाथ का प्रतिनिधित्व करता है।
* किसी [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) उदाहरण से [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) सेट करने हेतु आप इन मेथड्स का प्रयोग कर सकते हैं: एकल पाथ वाले आकारों के लिए [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) और बहु पाथ वाले आकारों के लिए [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths)।
* खंड जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) के अंतर्गत मौजूद मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath.setStroke](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath.setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) मेथड्स द्वारा आप पाथ की उपस्थिति निर्धारित कर सकते हैं।
* [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) मेथड से आप एक [GeometryShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खंडों की श्रृंखला के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों के लिए आप एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और खंडों को पुनः [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) पर लागू कर सकते हैं।

## **सरल संपादन संचालन**

निम्न मेथड्स का उपयोग करके आप एक ज्यामिति पाथ को संपादित कर सकते हैं। वह ओवरलोड जो इंडेक्स स्वीकार करता है, पाथ के खंड ऐरे में शून्य‑आधारित स्थिति पर खंड डालता है।

| संचालन | मेथड |
| --- | --- |
| सीधी रेखा जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु वाला क्यूबिक बेज़ीयर वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु और एक अंत बिंदु वाला क्वाड्रेटिक बेज़ीयर वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम और डिग्री में दी गई एलिप्टिकल आर्क जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारम्भ बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) |
| आकृति का प्रारम्भ बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#moveTo) |
| शून्य‑आधारित इंडेक्स पर खंड हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#lineTo) द्वारा सम्मिलित करता है और संपादित पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू करता है। निर्देशांक आकार के सापेक्ष स्थानीय हैं: दोनों नए बिंदु उसके केंद्र में, बाएँ किनारे से 100 पॉइंट और ऊपर से 50 पॉइंट पर स्थित हैं। खंड अनुक्रम 1 और 4 उन्हें क्रमशः ऊपर और नीचे किनारे पर रखता है, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

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

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#removeAt) द्वारा शून्य‑आधारित इंडेक्स 2 पर खंड हटाकर हृदय‑आकृति की रूपरेखा बदलता है। संशोधित पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) से लागू करने पर आकार की रूपरेखा अपडेट हो जाती है।

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

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) का उपयोग करके पाँच‑बिंदु वाला तारा बनाता है। बाहरी और आंतरिक त्रिज्या क्रमशः 100 और 50 पॉइंट के वैकल्पिक मान टिप और कटाव निर्धारित करते हैं; 72‑डिग्री चरण पाँच टिपों को समान रूप से वितरित करता है। पाथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया जाता है और आयताकार आकार पर [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) से लागू किया जाता है, जिससे उसकी रूपरेखा प्रतिस्थापित हो जाती है।

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

## **संयुक्त कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपर और नीचे के तिहाई हिस्सों के लिये दो बंद [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) ऑब्जेक्ट परिभाषित करता है। दोनों पाथ को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से मध्य तिहाई में अंतर के साथ एकल संयुक्त आकार बन जाता है।

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

## **घुमावदार कोनों वाले कस्टम आकार बनाएँ**

यह उदाहरण सीधी खंडों को [GeometryPath.arcTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर आती‑अंदर‑मुड़ी कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार बिंदु में आर्क की चौड़ाई और ऊँचाई निर्धारित करता है, और -90‑डिग्री स्वेप एक विपरीत‑घड़ी की चतुर्थांश दीर्घवृत्त बनाता है। पूर्ण पाथ को [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, और प्रस्तुति PPTX प्रारूप में सहेजी जाती है।

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

## **जांचें कि क्या आकार की ज्यामिति बंद है**

निम्न सहायक प्रत्येक गैर‑खाली ज्यामिति पाथ के अंत में समाप्ति‑खंड है या नहीं जांचता है। यह [GeometryPath.getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) पढ़ता है और अंतिम खंड के [PathSegment.getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) को [PathCommandType.Close](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathcommandtype/) से तुलना करता है। जब कोई गैर‑खाली पाथ नहीं होता तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड को जांचता है; पाथ के भीतर प्रत्येक उप‑आकृति की जाँच नहीं करता। उदाहरण एक आयत के लिये `true` प्रिंट करता है।

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

## **ज्यामिति पाथ कमांड का निरीक्षण करें**

[contour.pptx](contour.pptx) डाउनलोड करें और उसे एप्लिकेशन की कार्यनिर्देशिका में रखें। पहली स्लाइड का पहला आकार शीर्ष पर सीधी रेखा, एक क्यूबिक बेज़ीयर वक्र, तथा नीचे की ओर बंद रेखा रखता है। आकार के पाथ पढ़ने के लिये [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) और प्रत्येक पाथ के खंड क्रम में पढ़ने के लिये [getPathData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#getPathData) का प्रयोग करें। प्रत्येक खंड के लिये, [getPathCommand](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getPathCommand) कमांड की पहचान करता है और निर्धारित करता है कि [getSegmentData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pathsegment/#getSegmentData) द्वारा लौटाए गये मानों को कैसे व्याख्या करनी है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("contour.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paths = shape.getGeometryPaths();
    for (const [i, path] of paths.entries()) {
        const segments = path.getPathData();
        for (const [j, segment] of segments.entries()) {
            const command = segment.getPathCommand();
            const data = segment.getSegmentData();
            let detail;
            switch (command) {
                case slides.PathCommandType.MoveTo:
                case slides.PathCommandType.LineTo:
                    const name = command === slides.PathCommandType.MoveTo ? "MoveTo" : "LineTo";
                    detail = `${name} destination=(${data[0]}, ${data[1]})`;
                    break;
                case slides.PathCommandType.CubicBezierTo:
                    detail = `CubicBezierTo control1=(${data[0]}, ${data[1]}) control2=(${data[2]}, ${data[3]}) end=(${data[4]}, ${data[5]})`;
                    break;
                case slides.PathCommandType.Close:
                    detail = "Close no coordinates";
                    break;
                default:
                    detail = `command=${command} raw=[${data.join(", ")}]`;
            }
            console.log(`Path ${i}, segment ${j}: ${detail}`);
        }
    }
} finally {
    presentation.dispose();
}
```

यह आकार स्लाइड पर (200, 100) पॉइंट पर स्थित है। बताए गये निर्देशांक आकार के स्थानीय हैं, जहाँ (0, 0) उसके ऊपरी‑बाएँ कोने पर है, x दाएँ बढ़ता है और y नीचे की ओर।

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्वों को निकालें और निरीक्षण करें**

[GeometryShape.createShapeElements](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#createShapeElements) का उपयोग करके आप मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गये [ShapeElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/) को [getPathPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeelement/#getPathTypes) मेथड्स द्वारा बिंदु और प्रकार की श्रृंखला प्राप्त होती है। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्रॉइंग टूल्स को ज्यामिति पास करने में उपयोगी है।

उदाहरण `input.pptx` खोलता है, पहली स्लाइड पर सीधे पहला ज्यामिति आकार खोजता है, और उसके पाथ खंडों को प्रिंट करता है। दोनों प्रकार के आउटपुट देखने के लिये ऐसी प्रस्तुति उपयोग करें जिसमें आकार में सीधी और घुमावदार दोनों खंड हों। यह समूहों के भीतर खोज नहीं करता।

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
                const pointType = types[i] & 0x07; // खंड प्रकार रखें, फ्लैग को बाहर रखते हुए।
                switch (pointType) {
                    case 0:
                        console.log("Start figure at " + points[i]);
                        break;
                    case 1:
                        console.log("Line to " + points[i]);
                        break;
                    case 3:
                        console.log("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // दोनों नियंत्रण बिंदुओं और अंत बिंदु का उपभोग करें।
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

ऐरे इंडेक्स द्वारा संबंधित होते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका को दर्शाता है। प्रकार `0` आकृति की शुरुआत सूचित करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा बनाता है। क्यूबिक बेज़ीयर खंड पूर्व के अंत बिंदु से शुरू होता है और क्रमशः तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंत बिंदु। लूप इन तीन प्रविष्टियों को एकसाथ उपयोग करता है और अंत बिंदु को बंद होने के लिये जाँचता है।

बिंदु प्रकारों में फ्लैग भी होते हैं। सेगमेंट प्रकार पहचानने के लिये `0x07` से मास्क करें, और बंद उप‑पाथ खोजने के लिये `0x80` को अलग से जाँचें। उदाहरण स्वरूप, `129` (`0x81`) का अर्थ है वह रेखा अंत बिंदु जो उप‑पाथ बंद करता है, और `131` (`0x83`) का अर्थ है बंद करने वाला बेज़ीयर अंत बिंदु। Java इन फ्लैग को साइनड बाइट में संग्रहीत करता है; मास्किंग आवश्यक बिट मान को संरक्षित रखती है। केवल `1` या `3` से तुलना करने पर ये मामलों को खो दिया जाएगा। अन्य फ्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट (1/72 इंच) में मापे जाते हैं, X दाएँ और Y नीचे की ओर बढ़ता है। एक अनग्रुप्ड आकार के लिये, निकाले गये निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getY) द्वारा लौटाए गये स्थान को सम्मिलित करते हैं और उसकी वर्तमान चौड़ाई‑ऊँचाई को प्रतिबिंबित करते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित बिना घुमाव वाला आयत `120 × 80` आकार का कंटूर `(100, 200)`–`(220, 280)` देता है। आकार के स्थान को दोबारा जोड़ें नहीं। समन्वय प्राप्त करने के लिये उसके X और Y को घटाएँ।

निकाले गये बिंदु आकार की घुमाव ([getRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getRotation)) या क्षैतिज‑ऊर्ध्वाधर फ़्लिप को शामिल नहीं करते। प्रदर्शित कंटूर को पुनः उत्पन्न करने के लिये इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह निर्देशांक मैपिंग और रूपांतरण को भी ध्यान में रखें; यह मानें कि निकाले गये बिंदु अंतिम स्लाइड निर्देशांक नहीं हैं और यदि यह पहले ही बच्चे के फ्रेम में परिलक्षित है तो अनावश्यक अनुवाद या स्केल न लागू करें।

**निरीक्षण बनाम संपादन।** निकाले गये ऐरे कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल आकार अद्यतन नहीं होता। इस दृष्टिकोण को तब चुनें जब आपका विश्लेषण या ड्रॉइंग कोड बिंदु/प्रकार ऐरे की आवश्यकता रखता है। आकार के स्थानीय समन्वय प्रणाली में ज्यामिति कमांड चाहिए हों या उसे संपादित करना चाहते हों तो [getGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#getGeometryPaths) का उपयोग करें। संपादित पाथ को [setGeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) के द्वारा लागू करें।

## **Java AWT Shape को GeometryPath में परिवर्तित करें**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ मिलाकर ज्यामिति बनाता है। रूपरेखा का [setFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/#setFillMode) मेथड उसका भराव बंद कर देता है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मूव, लाइन, क्वाड्रेटिक, क्यूबिक और बंद खंड प्रदान करता है, जिन्हें उदाहरण [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/) पर पुनः चलाता है।

Java ब्रिज संबंधित Java पैरामीटरों के लिये स्पष्ट float तथा byte मानों का उपयोग करता है। इटररेटर कॉर्डिनेट को Java float ऐरे में लिखता है; रिफ्लेक्शन अपडेटेड मानों को JavaScript में पुनः पढ़ता है। टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट का उपयोग करता है। रूपरेखा क्षैतिज रूप से 20 पॉइंट स्थानांतरित है और दृश्य शीर्ष को आकार के शीर्ष किनारे से 10 पॉइंट नीचे स्थित करती है। टेक्स्ट पाथ भर दिया जाता है, जबकि मूल आयत केवल रूपरेखा बनी रहती है। दोनों पाथ को [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से एकल आकार बनता है जिसमें आयत और टेक्स्ट दोनों सम्मिलित होते हैं।

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
            case 1: // रेखा बनाएं।
                textPath.lineTo(points[0], points[1]);
                break;
            case 2: // क्वाड्रेटिक बेज़ीयर कर्व।
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case 3: // क्यूबिक बेज़ीयर कर्व।
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case 4: // आकृति बंद करें।
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

**ज्यामिति बदलने के बाद भराव और रूपरेखा क्या होती है?**

शैली आकार के साथ बनी रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाते हैं।

**कस्टम आकार को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमाएँ?**

आकार की [setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) मेथड का उपयोग करें; ज्यामिति आकार के साथ घुमती है क्योंकि वह आकार के अपने समन्वय प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकार को छवि में परिवर्तित करके “लॉक” कर सकता हूँ?**

हां। आवश्यक [slide](/slides/hi/nodejs-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/nodejs-java/create-shape-thumbnails/) को रास्टर फॉर्मेट में निर्यात करें; इससे जटिल ज्यामितियों के साथ आगे का काम सरल हो जाता है।