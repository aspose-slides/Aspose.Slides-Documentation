---
title: जावास्क्रिप्ट में प्रस्तुति आकृतियों को कस्टमाइज़ करें
linktitle: कस्टम आकृति
type: docs
weight: 20
url: /hi/nodejs-java/custom-shape/
keywords:
- कस्टम आकृति
- आकृति जोड़ें
- आकृति बनाएं
- आकृति बदलें
- आकृति ज्यामिति
- ज्यामिति पाथ
- पाथ बिंदु
- सम्पादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Node.js के लिए जावास्क्रिप्ट और Aspose.Slides के साथ PowerPoint प्रस्तुतियों में आकृतियों को बनाएँ और कस्टमाइज़ करें: ज्यामिति पाथ, वक्र कोने, सम्मिलित आकृतियां।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति आकृतियों को संपादन बिंदुओं और ज्यामिति पाथों के माध्यम से आकृति ज्यामिति संपादित करके कस्टमाइज़ करने के तरीके को समझाता है। यह दिखाता है कि `GeometryPath` के साथ कार्य करके मौजूदा आकृतियों को संशोधित करना, बुनियादी पाथ संपादन संचालन करना, बिंदुओं को जोड़ना या हटाना, और अपडेट की गई ज्यामिति को वापस आकृति पर लागू करना।

यह यह भी दर्शाता है कि कैसे कस्टम और सम्मिलित आकृतियां बनाई जाएँ, वक्र कोनों वाली आकृतियों का निर्माण किया जाए, यह निर्धारित किया जाए कि आकृति की ज्यामिति बंद है या नहीं, और अतिरिक्त ज्यामिति कस्टमाइज़ेशन परिदृश्यों के लिए `GeometryPath` और `java.awt.Shape` के बीच रूपांतरण किया जाए।

## **सम्पादन बिंदुओं का उपयोग करके आकृति बदलें**

एक वर्ग को मान लीजिए। PowerPoint में, **सम्पादन बिंदुओं** का उपयोग करके आप
* वर्ग के कोने को अंदर या बाहर ले जा सकते हैं
* किसी कोने या बिंदु की वक्रता निर्दिष्ट कर सकते हैं
* वर्ग में नए बिंदु जोड़ सकते हैं
* वर्ग के बिंदुओं को हेरफेर कर सकते हैं, आदि

वास्तव में, आप इन वर्णित कार्यों को किसी भी आकृति पर कर सकते हैं। सम्पादन बिंदुओं का उपयोग करके आप एक आकृति को बदल सकते हैं या मौजूदा आकृति से नई आकृति बना सकते हैं।

## **आकृति संपादन युक्तियाँ**

![overview_image](custom_shape_0.png)

PowerPoint आकृतियों को सम्पादन बिंदुओं के माध्यम से संपादित करना शुरू करने से पहले, आप इन बिंदुओं पर विचार करना चाहेंगे:
* एक आकृति (या उसकी पाथ) बंद या खुली हो सकती है।
* जब आकृति बंद होती है, तो उसमें कोई प्रारंभ या समाप्त बिंदु नहीं होता। जब आकृति खुली होती है, तो उसके पास एक शुरुआत और अंत होता है।
* सभी आकृतियों में कम से कम 2 एंकर बिंदु होते हैं जो रेखाओं द्वारा एक-दूसरे से जुड़े होते हैं।
* एक रेखा या तो सीधी होती है या वक्र। एंकर बिंदु रेखा की प्रकृति निर्धारित करते हैं।
* एंकर बिंदु कोने के बिंदु, सीधे बिंदु, या सुगम बिंदु के रूप में मौजूद होते हैं:
  * कोना बिंदु वह बिंदु है जहाँ 2 सीधी रेखाएँ कोण पर जुड़ती हैं।
  * सुगम बिंदु वह बिंदु है जहाँ 2 हैंडल सीधी रेखा में होते हैं और रेखा के खण्ड एक सुगम वक्र में जुड़ते हैं। इस स्थिति में, सभी हैंडल एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु वह बिंदु है जहाँ 2 हैंडल सीधी रेखा में होते हैं और उस रेखा के खण्ड एक सुगम वक्र में जुड़ते हैं। इस स्थिति में, हैंडल को एंकर बिंदु से समान दूरी पर होने की आवश्यकता नहीं होती।
* एंकर बिंदुओं को स्थानांतरित या संपादित करके (जो रेखाओं के कोण को बदलता है), आप आकृति की उपस्थिति बदल सकते हैं।

PowerPoint आकृतियों को सम्पादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [**GeometryPath**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) उदाहरण [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) ऑब्जेक्ट की ज्यामिति पाथ का प्रतिनिधित्व करता है।
* `GeometryPath` को `GeometryShape` उदाहरण से प्राप्त करने के लिए आप [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--) मेथड का उपयोग कर सकते हैं।
* एक आकृति के लिए `GeometryPath` सेट करने के लिए आप ये मेथड उपयोग कर सकते हैं: ठोस आकृतियों के लिए [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) और सम्मिलित आकृतियों के लिए [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-)।
* सेगमेंट जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) के अंतर्गत मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath.setStroke](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) और [GeometryPath.setFillMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-) मेथड्स का उपयोग करके आप ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।
* [GeometryPath.getPathData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath#getPathData--) मेथड का उपयोग करके आप `GeometryShape` की ज्यामिति पाथ को पाथ सेगमेंट्स की एरे के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकृति ज्यामिति कस्टमाइज़ेशन विकल्पों तक पहुंचने के लिए आप [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में रूपांतरण कर सकते हैं।
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) और [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) मेथड्स ( [ShapeUtil](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeUtil) क्लास से) का उपयोग करके आप [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में और वापस रूपांतरित कर सकते हैं।

## **सरल संपादन संचालन**

यह JavaScript कोड आपको दिखाता है कि कैसे
**लाइन जोड़ें** पाथ के अंत में
```javascript
lineTo(point);
lineTo(x, y);
```
**लाइन जोड़ें** पाथ पर निर्दिष्ट स्थान पर:
```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**क्यूबिक Bezier वक्र जोड़ें** पाथ के अंत में:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**क्यूबिक Bezier वक्र जोड़ें** पाथ पर निर्दिष्ट स्थान पर:
```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**क्वाड्रेटिक Bezier वक्र जोड़ें** पाथ के अंत में:
```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**क्वाड्रेटिक Bezier वक्र जोड़ें** पाथ पर निर्दिष्ट स्थान पर:
```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**दिए गए आर्क को जोड़ें** पाथ में:
```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**पाथ की वर्तमान आकृति बंद करें**:
```javascript
closeFigure();
```
**अगले बिंदु की स्थिति सेट करें**:
```javascript
moveTo(point);
moveTo(x, y);
```
**दिए गए इंडेक्स पर पाथ सेगमेंट हटाएँ**:
```javascript
removeAt(index);
```

## **आकृति में कस्टम बिंदु जोड़ें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) क्लास का उदाहरण बनाएं और [ShapeType.Rectangle](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeType) प्रकार सेट करें।
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण प्राप्त करें।
3. पाथ के दो शीर्ष बिंदुओं के बीच एक नया बिंदु जोड़ें।
4. पाथ के दो निचले बिंदुओं के बीच एक नया बिंदु जोड़ें।
5. पाथ को आकृति पर लागू करें।

यह JavaScript कोड आपको दिखाता है कि कैसे एक आकृति में कस्टम बिंदु जोड़े जाएँ:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **आकृति से बिंदु हटाएँ**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) क्लास का उदाहरण बनाएं और [ShapeType.Heart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeType) प्रकार सेट करें।
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण प्राप्त करें।
3. पाथ के लिए सेगमेंट हटाएँ।
4. पाथ को आकृति पर लागू करें।

यह JavaScript कोड आपको दिखाता है कि कैसे एक आकृति से बिंदु हटाए जाएँ:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **कस्टम आकृति बनाएँ**

1. आकृति के बिंदुओं की गणना करें।
2. [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण बनाएं।
3. बिंदुओं से पाथ भरें।
4. [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं।
5. पाथ को आकृति पर लागू करें।

यह JavaScript आपको दिखाता है कि कैसे एक कस्टम आकृति बनाई जाए:
```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)

## **समुच्चय कस्टम आकृति बनाएँ**

  1. [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं।
  2. [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास का पहला उदाहरण बनाएं।
  3. [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) क्लास का दूसरा उदाहरण बनाएं।
  4. पाथ को आकृति पर लागू करें।

यह JavaScript कोड आपको दिखाता है कि कैसे एक समुच्चय कस्टम आकृति बनाई जाए:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों के साथ कस्टम आकृति बनाएँ**

यह JavaScript कोड आपको दिखाता है कि कैसे वक्र कोनों (अंदर की ओर) के साथ कस्टम आकृति बनाई जाए;
```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **जाँचें कि क्या आकृति की ज्यामिति बंद है**

एक बंद आकृति वह होती है जहाँ इसकी सभी पक्ष आपस में जुड़े होते हैं, जिससे कोई गैप नहीं रहता और एक एकल सीमा बनती है। ऐसी आकृति सरल ज्यामितीय रूप हो सकती है या जटिल कस्टम रूपरेखा। निम्नलिखित कोड उदाहरण दिखाता है कि कैसे जांचें कि आकृति की ज्यामिति बंद है या नहीं:
```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **GeometryPath को java.awt.Shape में रूपांतरित करें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryShape) क्लास का उदाहरण बनाएं।
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) क्लास का एक उदाहरण बनाएं।
3. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) उदाहरण को [GeometryPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/GeometryPath) उदाहरण में [ShapeUtil](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ShapeUtil) का उपयोग करके रूपांतरित करें।
4. पाथ को आकृति पर लागू करें।

यह JavaScript कोड—ऊपर बताए गए चरणों का कार्यान्वयन—**GeometryPath** से **GraphicsPath** रूपांतरण प्रक्रिया को दर्शाता है:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // नई आकृति बनाएं
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // आकृति का ज्यामिति पाथ प्राप्त करें
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // टेक्स्ट के साथ नई ग्राफ़िक्स पाथ बनाएं
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // ग्राफ़िक्स पाथ को ज्यामिति पाथ में बदलें
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // नई ज्यामिति पाथ और मूल ज्यामिति पाथ के संयोजन को आकृति पर सेट करें
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति बदलने के बाद भराव और रूपरेखा के साथ क्या होगा?**

शैली आकृति के साथ रहती है; केवल रूपरेखा बदलती है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाते हैं।

**मैं कस्टम आकृति को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमा सकता हूँ?**

आकृति के [setRotation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/setrotation/) मेथड का उपयोग करें; ज्यामिति आकृति के साथ घुमती है क्योंकि यह आकृति के अपने समन्वय प्रणाली से बंधी होती है।

**क्या मैं कस्टम आकृति को एक छवि में रूपांतरित करके परिणाम को "लॉक" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/nodejs-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/nodejs-java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह भारी ज्यामितियों के साथ आगे के काम को सरल बनाता है।