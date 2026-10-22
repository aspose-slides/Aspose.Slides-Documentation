---
title: जावा में प्रस्तुति आकारों को कस्टमाइज़ करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/java/custom-shape/
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
- संपादन ऑपरेशन
- मोड़ वाला कोना
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और कस्टमाइज़ करें: ज्यामिति पाथ, मोड़ वाले कोने, सम्मिलित आकार।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुतिकरण आकारों को संपादन बिंदुओं और ज्यामिति पाथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने की विधि समझाता है। यह दिखाता है कि [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) के साथ कैसे काम करें ताकि मौजूदा आकारों को संशोधित किया जा सके, बुनियादी पाथ संपादन संचालन किए जा सकें, बिंदु जोड़े या हटाए जा सकें, और अपडेटेड ज्यामिति को फिर से आकार पर लागू किया जा सके।  
यह भी दिखाता है कि कैसे कस्टम और सम्मिलित आकार बनाएँ, मुड़ी हुई किनारों वाले आकार बनाएँ, यह निर्धारित करें कि आकार ज्यामिति बंद है या नहीं, आकार तत्वों का निरीक्षण करें, और Java AWT पाठ रूपरेखाओं को ज्यामिति पाथों में परिवर्तित करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* एक कोने को अंदर या बाहर ले जाएँ।
* एक बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की रूपरेखा को संशोधित कर सकते हैं या मौजूदा आकार को नए आकार के आधार के रूप में उपयोग कर सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय, इन अवधारणाओं को ध्यान में रखें:

* एक आकार (या उसका पाथ) या तो बंद या खुला हो सकता है।
* एक आकार का पाथ एंकर पॉइंट्स से बना होता है जो सेगमेंट्स द्वारा जुड़े होते हैं।
* एक सेगमेंट सीधा या वक्र हो सकता है। एंकर पॉइंट्स और नियंत्रण हैंडल उसके आकार को निर्धारित करते हैं।
* एंकर पॉइंट्स को कोना बिंदु, सीधे बिंदु, या स्मूद बिंदु के रूप में मौजूद होते हैं:
  * कोना बिंदु पर, जुड़े सेगमेंट एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर पॉइंट से समान दूरी पर होते हैं।
  * स्ट्रेट बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर पॉइंट से दूरी अलग हो सकती है।
* एंकर पॉइंट्स को हिलाने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

Edit Points के माध्यम से PowerPoint के आकारों को संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) इंस्टेंस [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) ऑब्जेक्ट का ज्यामिति पाथ दर्शाता है।
* एक [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) प्राप्त करने के लिए, आप [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) मेथड का उपयोग कर सकते हैं।
* एक आकार के लिए [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) सेट करने हेतु, आप इन मेथड्स का उपयोग कर सकते हैं: सिंगल पाथ वाले आकारों के लिए [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) और मल्टिपल पाथ वाले आकारों के लिए [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)।
* सेगमेंट जोड़ने के लिए, आप [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) के तहत उपलब्ध मेथड्स का उपयोग कर सकते हैं।
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) और [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) मेथड्स का उपयोग करके आप एक ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) मेथड का उपयोग करके आप [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) का ज्यामिति पाथ एक पाथ सेगमेंट्स की एरे के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों तक पहुंचने के लिए, आप [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और सेगमेंट्स को एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) पर पुनः चल सकते हैं।

## **सरल संपादन कार्य**

ज्यामिति पाथ को संपादित करने के लिए निम्नलिखित मेथड्स का उपयोग करें। इंडेक्स स्वीकार करने वाले ओवरलोड्स पाथ की सेगमेंट एरे में शून्य-आधारित स्थिति पर एक सेगमेंट डालते हैं।

| ऑपरशन | मेथड |
| --- | --- |
| एक सीधी लाइन जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| दो नियंत्रण बिंदुओं और एक एंडपॉइंट के साथ क्यूबिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| एक नियंत्रण बिंदु और एक एंडपॉइंट के साथ क्वाड्रैटिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| निर्दिष्ट आयामों और डिग्री में कोणों के साथ एक एलिप्टिकल आर्क जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| वर्तमान आकृति को उसके एंडपॉइंट को शुरुआती बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| एक आकृति का शुरुआती बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| शून्य-आधारित इंडेक्स पर एक सेगमेंट हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) का उपयोग करके एक आयताकार आकार में दो बिंदु सम्मिलित करता है और संपादित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) के साथ लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु उसके केंद्र में हैं, बाएँ से 100 पॉइंट और शीर्ष से 50 पॉइंट दूर। सेगमेंट इंडेक्स 1 और 4 उन्हें शीर्ष और निचली किनारों पर रखते हैं, जिससे वही किनारे अंदर की ओर खींचे जाते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    IGeometryPath geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);

    shape.setGeometryPath(geometryPath);
} finally {
    presentation.dispose();
}
```
![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) का उपयोग करके शून्य-आधारित इंडेक्स 2 पर सेगमेंट हटाकर हार्ट-आकार की रूपरेखा बदलता है। संशोधित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) के साथ लागू करने से आकार की रूपरेखा अपडेट होती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);

    shape.setGeometryPath(path);
} finally {
    presentation.dispose();
}
```
![example2_image](custom_shape_2.png)

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) का उपयोग करके पांच-कोणीय स्टार बनाता है। 100 और 50 पॉइंट के वैकल्पिक बाहरी और आंतरिक त्रिज्याएँ टिप्स और इनडेंटेशन को परिभाषित करती हैं; 72‑डिग्री का कदम पाँच टिप्स को समान रूप से वितरित करता है। पाथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) से बंद किया जाता है और एक आयताकार आकार पर [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) के साथ लागू करके उसकी रूपरेखा प्रतिस्थापित की जाती है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;
import java.util.ArrayList;
import java.util.List;

List<Point2D.Float> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    Point2D.Float point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new Point2D.Float((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
    shape.setGeometryPath(starPath);
} finally {
    presentation.dispose();
}
```
![example3_image](custom_shape_3.png)

## **संयुक्त कस्टम आकार बनाएँ**

यह उदाहरण आकार के शीर्ष और निचले एक‑तिहाई के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ऑब्जेक्ट परिभाषित करता है। दोनों पाथ को [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) के साथ लागू करने से मध्य तिहाई में एक गैप के साथ एकल संयुक्त आकार बनता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath topPath = new GeometryPath();
    topPath.moveTo(0, 0);
    topPath.lineTo(shape.getWidth(), 0);
    topPath.lineTo(shape.getWidth(), shape.getHeight() / 3);
    topPath.lineTo(0, shape.getHeight() / 3);
    topPath.closeFigure();

    GeometryPath bottomPath = new GeometryPath();
    bottomPath.moveTo(0, shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    bottomPath.lineTo(shape.getWidth(), shape.getHeight());
    bottomPath.lineTo(0, shape.getHeight());
    bottomPath.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { topPath, bottomPath });
} finally {
    presentation.dispose();
}
```
![example4_image](custom_shape_4.png)

## **मोड़ वाले कोनों के साथ कस्टम आकार बनाएँ**

यह उदाहरण सीधी सेगमेंट को [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) के साथ मिलाकर अंदर की ओर घुंघराले कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई पॉइंट में निर्धारित करता है, और -90‑डिग्री की स्वेप एक प्रतिक्लॉकवाइज़ क्वार्टर एलिप्स बनाती है। पूर्ण पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) के साथ लागू किया जाता है, और प्रस्तुति को PPTX फ़ॉर्मेट में सहेजा जाता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    Point2D.Float topLeft = new Point2D.Float(leftTopSize, 0);
    Point2D.Float topRight = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float rightBottom = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float bottomLeft = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float leftTop = new Point2D.Float(0, leftTopSize);

    GeometryPath geometryPath = new GeometryPath();
    geometryPath.moveTo(topLeft);
    geometryPath.lineTo(topRight);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(rightBottom);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(bottomLeft);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(leftTop);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();

    shape.setGeometryPath(geometryPath);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **जाँचें कि क्या आकार की ज्यामिति बंद है**

निम्न सहायक जांचता है कि क्या प्रत्येक गैर‑खाली ज्यामिति पाथ एक बंद सेगमेंट से समाप्त होता है। यह [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) पढ़ता है और अंतिम सेगमेंट के [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) को [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) से तुलना करता है। जब कोई गैर‑खाली पाथ नहीं होते हैं तो यह false लौटाता है। यह प्रत्येक पाथ की अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक सबफ़िगर को निरीक्षण नहीं करता। उदाहरण में आयत के लिए `true` प्रिंट किया जाता है।

```java
import com.aspose.slides.*;

class GeometryInspector {
    boolean isGeometryClosed(IGeometryShape geometryShape) {
        boolean hasNonemptyPath = false;

        for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
            IPathSegment[] segments = geometryPath.getPathData();
            if (segments.length == 0) {
                continue;
            }

            hasNonemptyPath = true;
            IPathSegment lastSegment = segments[segments.length - 1];
            if (lastSegment.getPathCommand() != PathCommandType.Close) {
                return false;
            }
        }

        return hasNonemptyPath;
    }
}

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryInspector inspector = new GeometryInspector();
    boolean closed = inspector.isGeometryClosed(shape);
    System.out.println(closed);
} finally {
    presentation.dispose();
}
```

## **आकार तत्वों को निकालें और निरीक्षण करें**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) का उपयोग करके आप एक मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गए [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) में कास्ट करके आप [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) और [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) मेथड्स के माध्यम से बिंदु और प्रकार एरे प्राप्त कर सकते हैं। यह प्रतिनिधित्व रूपरेखा विश्लेषण या कस्टम ड्रॉइंग टूल्स को ज्यामिति पास करने के लिए उपयोगी है।

उदाहरण में input.pptx को खोलकर, पहले स्लाइड पर सीधे पहला ज्यामिति आकार पाया जाता है और उसके पाथ सेगमेंट प्रिंट किए जाते हैं। दोनों प्रकार के आउटपुट देखने के लिए सीधी और घुंघराली सेगमेंट वाले आकार वाली प्रस्तुति का उपयोग करें। यह समूहों के भीतर खोज नहीं करता।

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IGeometryShape shape = null;
    for (IShape candidate : slide.getShapes()) {
        if (candidate instanceof IGeometryShape) {
            shape = (IGeometryShape) candidate;
            break;
        }
    }

    if (shape == null) {
        System.out.println("No geometry shape found on the first slide.");
    } else {
        for (IShapeElement element : shape.createShapeElements()) {
            ShapeElement shapeElement = (ShapeElement) element;
            Point2D.Float[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // सेगमेंट प्रकार को रखें, फ़्लैग को छोड़कर।
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // Consume both control points and the endpoint.
                        break;
                }

                if ((types[i] & 0x80) != 0) {
                    System.out.println("Close subpath back to its starting point.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

एरे इंडेक्स के अनुसार मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` एक आकृति शुरू करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक लाइन बनाता है। एक क्यूबिक Bézier सेगमेंट पिछले एंडपॉइंट से शुरू होता है और लगातार तीन प्रकार‑`3` एंट्रीज़ का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया एंडपॉइंट। लूप इन तीन एंट्रीज़ को एक साथ उपभोग करता है और एंडपॉइंट को बंद होने के लिए जाँचता है।

बिंदु प्रकार में फ्लैग भी होते हैं। सेगमेंट प्रकार पहचानने के लिए `0x07` से मास्क करें, और बंद सबपाथ का पता लगाने के लिए `0x80` को अलग से टेस्ट करें। उदाहरण के लिए, `129` (`0x81`) एक लाइन एंडपॉइंट है जो सबपाथ को बंद करता है, और `131` (`0x83`) एक Bézier एंडपॉइंट है जो एक को बंद करता है। Java इन फ्लैग्स को साइनड बाइट्स में संग्रहीत करता है; मास्किंग इरादे वाले बिट मानों को रखती है। केवल `1` या `3` से कच्चे मान की तुलना करने से ये केस छूट जाते हैं। अन्य फ्लैग, जैसे डैश (`0x10`) और मार्कर (`0x20`), मूल सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट्स (1/72 इंच) में मापे जाते हैं, जहाँ X दाईं ओर बढ़ता है और Y नीचे की ओर। एक अनग्रुप्ड आकार के लिए, निकाले गए निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) और [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) द्वारा लौटाई गई स्थिति को शामिल करते हैं और उसकी वर्तमान चौड़ाई तथा ऊँचाई को दर्शाते हैं। उदाहरण के लिए, `(100, 200)` पर स्थित, आकार `120 × 80` वाला बिना घुमाव वाला आयत का कंटूर बाउंड `(100, 200)`–`(220, 280)` है। आकार की स्थिति को दोबारा नहीं जोड़ें। उसके X और Y को घटाकर अनरोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गए बिंदु आकार की रोटेशन, जिसे [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) द्वारा लौटाया जाता है, या क्षैतिज व ऊर्ध्वक़ सम फ्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः उत्पन्न करने के लिए इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। समूहबद्ध आकारों के लिए, समूह निर्देशांक मैपिंग और रूपांतरणों को भी ध्यान में रखें; यह न मानें कि निकाले गए बिंदु अंतिम रेंडर किए हुए स्लाइड निर्देशांक हैं या यदि यह पहले से ही बच्चे के फ्रेम में प्रतिबिंबित है तो अनुवाद या स्केल को दो बार लागू न करें।

**निरीक्षण बनाम संपादन।** निकाले गए एरे कंटूर का वर्णन करते हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। जब आपका विश्लेषण या ड्रॉइंग कोड बिंदु/प्रकार एरे की आवश्यकता रखता है, तब इस दृष्टिकोण को चुनें। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड्स चाहिए या उसकी ज्यामिति संपादित करनी है, तो [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) का उपयोग करें। संपादित पाथ को [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) या [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) के माध्यम से लागू करें।

## **Java AWT Shape को GeometryPath में परिवर्तित करें**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ मिलाकर जो ज्यामिति में परिवर्तित किया गया है, को संयोजित करता है। रूपरेखा की [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) मेथड उसका फ़िल को निष्क्रिय करती है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) टेक्स्ट रूपरेखा को एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में बनाता है। उसकी [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मोव, लाइन, क्वाड्रैटिक, क्यूबिक और क्लोज़िंग सेगमेंट प्रदान करती है, जिन्हें उदाहरण में एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) पर पुनः चलाया जाता है।

टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट का उपयोग करता है। रूपरेखा को 20 पॉइंट क्षैतिज रूप से ऑफसेट किया गया है और उसका दृश्य शीर्ष आकार के शीर्ष किनारे से 10 पॉइंट नीचे रखा गया है। टेक्स्ट पाथ को फ़िल किया जाता है, जबकि मूल आयत केवल रूपरेखा बनी रहती है। दोनों पाथ को [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) के साथ लागू करने से एक ही आकार बनता है जिसमें आयत और टेक्स्ट दोनों शामिल होते हैं।

```java
import com.aspose.slides.*;
import java.awt.Font;
import java.awt.Graphics2D;
import java.awt.Shape;
import java.awt.font.GlyphVector;
import java.awt.font.FontRenderContext;
import java.awt.geom.Rectangle2D;
import java.awt.geom.PathIterator;
import java.awt.image.BufferedImage;

Presentation presentation = new Presentation();
try {
    // नया आकार बनाएं
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // आकार का ज्यामिति पाथ प्राप्त करें
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // पाठ के साथ नया ग्राफ़िक्स पाथ बनाएं
    Shape graphicsPath;
    Font font = new Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage image = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D graphics = image.createGraphics();

    try
    {
        FontRenderContext fontContext = graphics.getFontRenderContext();
        GlyphVector glyphVector = font.createGlyphVector(fontContext, text);
        Rectangle2D textBounds = glyphVector.getVisualBounds();
        float baseline = (float) -textBounds.getY() + 10;
        graphicsPath = glyphVector.getOutline(20f, baseline);
    }
    finally {
        graphics.dispose();
    }

    // ग्राफ़िक्स पाथ को ज्यामिति पाथ में परिवर्तित करें
    IGeometryPath textPath = new GeometryPath();
    PathIterator pathIterator = graphicsPath.getPathIterator(null);
    float[] points = new float[6];

    while (!pathIterator.isDone())
    {
        int segmentType = pathIterator.currentSegment(points);
        switch (segmentType)
        {
            case PathIterator.SEG_MOVETO:
                textPath.moveTo(points[0], points[1]);
                break;
            case PathIterator.SEG_LINETO:
                textPath.lineTo(points[0], points[1]);
                break;
            case PathIterator.SEG_QUADTO:
                textPath.quadraticBezierTo(points[0], points[1], points[2], points[3]);
                break;
            case PathIterator.SEG_CUBICTO:
                textPath.cubicBezierTo(points[0], points[1], points[2], points[3], points[4], points[5]);
                break;
            case PathIterator.SEG_CLOSE:
                textPath.closeFigure();
                break;
        }
        pathIterator.next();
    }

    textPath.setFillMode(PathFillModeType.Normal);

    // आकार में नए ज्यामिति पाथ और मूल ज्यामिति पाथ के संयोजन को सेट करें
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति बदलने के बाद फ़िल और रूपरेखा क्या होगा?**

स्टाइल आकार के साथ बना रहता है; केवल कंटूर बदलता है। फ़िल और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाते हैं।

**मैं कस्टम आकार को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमा सकता हूँ?**

आकार की [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) मेथड का उपयोग करें; क्योंकि यह आकार के अपने निर्देशांक प्रणाली से बंधी है, ज्यामिति भी आकार के साथ घुमती है।

**क्या मैं कस्टम आकार को एक छवि में परिवर्तित करके परिणाम को "लॉक" कर सकता हूँ?**

हाँ। आवश्यक [स्लाइड](/slides/hi/java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [आकार](/slides/hi/java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के कार्य को सरल बनाता है।