---
title: Java में प्रस्तुति आकारों को अनुकूलित करें
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
- घुमावदार कोना
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यॉमेट्री पाथ, घुमावदार कोने, सम्मिश्र आकार।"
---
## **परिचय**

यह लेख Aspose.Slides में शैप ज्यॉमेट्री को संपादित बिंदुओं और ज्यॉमेट्री पाथ के माध्यम से संशोधित करके प्रस्तुति आकारों को अनुकूलित करने के तरीके को समझाता है। यह दिखाता है कि कैसे मौजूदा आकारों को बदलने, बुनियादी पाथ संपादन कार्यों को करने, बिंदुओं को जोड़ने या हटाने, और अद्यतन ज्यॉमेट्री को फिर से आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) का उपयोग किया जाता है।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और समग्र आकार बनाएँ, घुमावदार कोनों वाले आकार बनाएँ, यह निर्धारित करें कि कोई आकार ज्यॉमेट्री बंद है या नहीं, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट रूपरेखाओं को ज्यॉमेट्री पाथ में बदलें।

## **संपादित बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में आप **Edit Points** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप आकार की रूपरेखा बदल सकते हैं या मौजूदा आकार को नई आकार की आधारशिला के रूप में उपयोग कर सकते हैं।

## **आकार संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को ध्यान में रखें:

* कोई आकार (या उसकी पाथ) बंद या खुला हो सकता है।
* किसी आकार की पाथ एंकर बिंदुओं और उनके बीच के सेगमेंट्स से बनी होती है।
* एक सेगमेंट सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने बिंदु, सीधा बिंदु या स्मूद बिंदु के रूप में होते हैं:
  * कोने बिंदु पर, सन्निकट सेगमेंट कोण पर मिलते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल समान दिशा में होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल समान दिशा में होते हैं लेकिन एंकर बिंदु से विभिन्न दूरी पर हो सकते हैं।
* एंकर बिंदुओं को ले जाना या उनके हैंडल्स को समायोजित करना आकार की रूपरेखा बदलता है।

PowerPoint आकारों को संपादित बिंदुओं के माध्यम से बदलने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) उदाहरण [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) ऑब्जेक्ट की ज्यॉमेट्री पाथ को दर्शाता है।
* [IGeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/) instance से [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) प्राप्त करने के लिए आप [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) सेट करने हेतु आप इन मेथड्स का प्रयोग कर सकते हैं: एकल पाथ वाले आकारों के लिये [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) और बहु‑पाथ वाले आकारों के लिये [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)।
* सेगमेंट जोड़ने के लिये आप [IGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/) के अंतर्गत उपलब्ध मेथड्स का उपयोग कर सकते हैं।
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setStroke-boolean-) और [IGeometryPath.setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) मेथड्स से आप ज्यॉमेट्री पाथ का स्वरूप निर्धारित कर सकते हैं।
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) मेथड से आप [GeometryShape](https://reference.aspose.com/slides/java/com.aspose.slides/geometryshape/) की ज्यॉमेट्री पाथ को सेगमेंट्स की एरेक्‍स के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यॉमेट्री अनुकूलन विकल्पों के लिये आप [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और उन सेगमेंट्स को एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) पर पुनः चलाते हैं।

## **सरल संपादन ऑपरेशन**

ज्यॉमेट्री पाथ को संपादित करने के लिये निम्न मेथड्स का उपयोग करें। वे ओवरलोड जो इंडेक्स स्वीकार करते हैं, पाथ के सेगमेंट एरे में शून्य‑आधारित स्थिती पर एक सेगमेंट डालते हैं।

| ऑपरेशन | मेथड |
| --- | --- |
| सीधी रेखा जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| दो नियंत्रण बिंदुओं और अंत बिंदु के साथ क्यूबिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| एक नियंत्रण बिंदु और अंत बिंदु के साथ क्वाड्रेटिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| निर्दिष्ट माप और डिग्री में एक अंडाकार चाप जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| वर्तमान आकृति को उसके अंत बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) |
| आकृति का प्रारंभ बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| शून्य‑आधारित इंडेक्स पर एक सेगमेंट हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#lineTo-float-float-) का उपयोग करके दर्ज करता है और संशोधित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू करता है। निर्देशांक आकार के सापेक्ष स्थानीय हैं: दोनों नए बिंदु केंद्र में स्थित हैं, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट दूर। सेगमेंट इंडेक्स 1 और 4 उन्हें क्रमशः ऊपरी और निचली किनारों पर रखते हैं, जिससे ये किनारे अंदर की ओर खिंचते हैं।

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

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#removeAt-int-) के साथ शून्य‑आधारित इंडेक्स 2 पर सेगमेंट को हटाकर एक हार्ट‑आकार की रूपरेखा बदलता है। संशोधित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू करने से आकार की रूपरेखा अपडेट होती है।

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

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) का उपयोग करके पाँच‑भुजिया तारा बनाता है। बाहरी व आंतरिक त्रिज्याएँ क्रमशः 100 और 50 पॉइंट के वैकल्पिक बैकल्पिक होते हैं; 72‑डिग्री कदम पाँच टिप्स को समान रूप से विभाजित करता है। पाथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#closeFigure--) से बंद किया जाता है और [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) द्वारा आयताकार आकार पर लागू किया जाता है, जिससे उसकी रूपरेखा बदल जाती है।

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

## **समग्र कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपर और नीचे के एक‑तिहाई हिस्से के लिये दो बंद [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) ऑब्जेक्ट निर्धारित करता है। दोनों पाथ को [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) से लागू करने से मध्य‑तिहाई में एक अंतर वाला एकल समग्र आकार बनता है।

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

## **घुमावदार कोनों वाला कस्टम आकार बनाएँ**

यह उदाहरण सीधे सेगमेंट को [GeometryPath.arcTo](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) के साथ मिलाकर अंदर की ओर घुमावदार कोनों वाला आकार बनाता है। प्रत्येक कोने का आकार बिंदुओं में चाप की चौड़ाई और ऊँचाई निर्धारित करता है, और -90‑डिग्री स्वीप एक उल्टी दिशा में चतुर्थांश अंडाकार बनाता है। पूर्ण पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू किया जाता है, और प्रस्तुति को PPTX प्रारूप में सहेजा जाता है।

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

## **पता लगाएँ कि आकार ज्यॉमेट्री बंद है या नहीं**

निम्न हेल्पर सभी गैर‑खाली ज्यॉमेट्री पाथ की जाँच करता है कि क्या वे बंद सेगमेंट पर समाप्त होते हैं। यह [IGeometryPath.getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) को पढ़ता है और अंतिम सेगमेंट के [IPathSegment.getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/java/com.aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑खाली पाथ नहीं है तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑आकृति की जाँच नहीं करता। उदाहरण में आयत के लिये `true` प्रिंट किया जाता है।

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

## **ज्यॉमेट्री पाथ कमांड का निरीक्षण करें**

[contour.pptx](contour.pptx) को डाउनलोड करें और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। पहले स्लाइड की पहली आकृति में एक सीधी शीर्ष किनारा, एक क्यूबिक Bézier वक्र, और एक सीधा बंद किनारा है। आकार की पाथ पढ़ने के लिये [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) का उपयोग करें और प्रत्येक पाथ के सेगमेंट को पढ़ने के लिये [getPathData](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#getPathData--) का। प्रत्येक सेगमेंट के लिये, [getPathCommand](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getPathCommand--) कमांड को पहचानता है और यह निर्धारित करता है कि [getSegmentData](https://reference.aspose.com/slides/java/com.aspose.slides/ipathsegment/#getSegmentData--) द्वारा लौटाए गए मानों को कैसे व्याख्यायित किया जाए।

```java
import com.aspose.slides.*;
import java.util.Arrays;

Presentation presentation = new Presentation("contour.pptx");
try {
    IGeometryShape shape = (IGeometryShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IGeometryPath[] paths = shape.getGeometryPaths();

    for (int i = 0; i < paths.length; i++) {
        IPathSegment[] segments = paths[i].getPathData();
        for (int j = 0; j < segments.length; j++) {
            byte command = segments[j].getPathCommand();
            float[] data = segments[j].getSegmentData();
            String detail;
            switch (command) {
                case PathCommandType.MoveTo:
                case PathCommandType.LineTo:
                    detail = String.format("destination=(%s, %s)", data[0], data[1]);
                    break;
                case PathCommandType.CubicBezierTo:
                    detail = String.format("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", data[0], data[1], data[2], data[3], data[4], data[5]);
                    break;
                case PathCommandType.Close:
                    detail = "no coordinates";
                    break;
                default:
                    detail = "raw=" + Arrays.toString(data);
            }
            String name = PathCommandType.getName(PathCommandType.class, command);
            System.out.printf("Path %d, segment %d: %s %s%n", i, j, name, detail);
        }
    }
} finally {
    presentation.dispose();
}
```

आकार स्लाइड पर (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गये निर्देशांक आकार के सापेक्ष स्थानीय होते हैं, जहाँ (0, 0) उसका ऊपरी‑बायाँ कोना है, x दाएँ बढ़ता है और y नीचे की ओर।

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्वों को निकालें और निरीक्षण करें**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#createShapeElements--) का उपयोग करके आप मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गये [IShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/) में कास्ट करके [getPathPoints](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathPoints--) और [getPathTypes](https://reference.aspose.com/slides/java/com.aspose.slides/shapeelement/#getPathTypes--) मेथड्स से बिंदु और प्रकार एरे प्राप्त करें। यह प्रतिनिधित्व कॉन्टूर विश्लेषण या कस्टम ड्रॉइंग टूल्स को ज्यॉमेट्री पास करने के लिये उपयोगी है।

उदाहरण input.pptx खोलता है, पहले स्लाइड पर पहला ज्यॉमेट्री आकार खोजता है, और उसके पाथ सेगमेंट प्रिंट करता है। सीधी और घुमावदार दोनों सेगमेंट वाले आकार वाली प्रस्तुति का उपयोग करें। यह समूहों के भीतर खोज नहीं करता।

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
                int pointType = types[i] & 0x07; // सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखते हुए.
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

एरे इंडेक्स के अनुसार मेल खाते हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` आकृति की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक एक रेखा बनाता है। एक क्यूबिक Bézier सेगमेंट पिछले अंत बिंदु से शुरू होता है और क्रमिक रूप से तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में लेता है और समापन के लिये अंत बिंदु की जाँच करता है।

बिंदु प्रकारों में फ़्लैग भी होते हैं। `0x07` के साथ मास्क करके सेगमेंट प्रकार पहचाना जाता है, और `0x80` को अलग से जाँच कर बंद उप‑पाथ का पता चलता है। उदाहरण के लिये, `129` (`0x81`) का अर्थ है एक रेखा अंत बिंदु जो उप‑पथ को बंद करता है, और `131` (`0x83`) का अर्थ है एक Bézier अंत बिंदु जो बंद करता है। जावा इन फ़्लैग को साइन्ड बाइट्स में संग्रहीत करता है; मास्किंग से वांछित बिट मान बरकरार रहते हैं। केवल `1` या `3` से तुलना करने से ये केस चूक सकते हैं। अन्य फ़्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) बेस सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट में मापे जाते हैं (1/72 इंच), X दाएँ और Y नीचे की ओर बढ़ता है। अन‑ग्रुप्ड आकार के लिये, निकाले गये निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getX--) और [getY](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getY--) द्वारा लौटाए गये स्थान को सम्मिलित करते हैं और उसकी वर्तमान चौड़ाई‑ऊँचाई को प्रतिबिंबित करते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित, `120 × 80` आकार वाला अन‑रोटेटेड आयत का कॉन्टूर बाउंड `(100, 200)`–`(220, 280)` है। आकार की स्थिति को फिर से न जोड़ें। X और Y को घटाकर अन‑रोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गये बिंदु [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getRotation--) द्वारा लौटाए गये घूर्णन या क्षैतिज‑ऊर्ध्वाधर फ़्लिप पर लागू नहीं होते। प्रदर्शित कॉन्टूर को पुनः उत्पन्न करने के लिये उन रूपांतरणों को आकार के केन्द्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह निर्देशांक मानचित्रण और रूपांतरणों को भी ध्यान में रखें; यह न मानें कि निकाले गये बिंदु अंतिम स्लाइड निर्देशांक हैं या अनावश्यक रूप से दो बार अनुवाद/स्केल लागू हो रहा है।

**निरीक्षण बनाम संपादन।** निकाले गये एरे केवल कॉन्टूर बताते हैं; उन्हें बदलने से मूल आकार नहीं बदलता। यह दृष्टिकोण तब उपयोगी है जब आपका विश्लेषण या ड्रॉइंग कोड बिंदु/प्रकार एरे की आवश्यकता रखता है। आकार के स्थानीय समन्वय प्रणाली में ज्यॉमेट्री कमांड चाहिए तो [getGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#getGeometryPaths--) का प्रयोग करें या उसकी ज्यॉमेट्री को संपादित करना चाहते हैं। संपादित पाथ को [setGeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) या [setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) के द्वारा लागू करें।

## **Java AWT Shape को GeometryPath में बदलें**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ मिलाता है जिसे ज्यॉमेट्री में बदला गया है। रूपरेखा की [setFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/igeometrypath/#setFillMode-byte-) मेथड उसका भराव निष्क्रिय करती है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। इसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मोव, लाइन, क्वाड्रेटिक, क्यूबिक और क्लोजिंग सेगमेंट प्रदान करता है, जिन्हें उदाहरण एक [GeometryPath](https://reference.aspose.com/slides/java/com.aspose.slides/geometrypath/) पर पुनः चलाता है।

टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट में है। रूपरेखा को क्षैतिज रूप से 20 पॉइंट और दृश्य शीर्ष को आकार के शीर्ष किनारे से 10 पॉइंट नीचे स्थित किया गया है। टेक्स्ट पाथ भर दिया जाता है, जबकि मूल आयत केवल रूपरेखा बनी रहती है। दोनों पाथ को [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) से लागू करने से आयत और टेक्स्ट को सम्मिलित करता एकल आकार बनता है।

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
    // नया आकार बनाएँ
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // आकार की ज्यॉमेट्री पाथ प्राप्त करें
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // टेक्स्ट के साथ नया ग्राफ़िक्स पाथ बनाएँ
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

    // ग्राफ़िक्स पाथ को ज्यॉमेट्री पाथ में बदलें
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

    // आकार में नई ज्यॉमेट्री पाथ और मूल ज्यॉमेट्री पाथ के संयोजन को सेट करें
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    presentation.dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यॉमेट्री बदलने के बाद भराव और रूपरेखा क्या होगा?**

स्टाइल आकार के साथ बना रहता है; केवल रूपरेखा बदलती है। भराव और रूपरेखा स्वचालित रूप से नई ज्यॉमेट्री पर लागू हो जाती हैं।

**ज्यामितीय रूप से कस्टम आकार को उसकी ज्यॉमेट्री के साथ सही ढंग से कैसे घुमाएँ?**

आकार की [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setRotation-float-) मेथड का उपयोग करें; क्योंकि ज्यॉमेट्री आकार के अपने समन्वय प्रणाली से जुड़ी होती है, यह आकार के साथ घुम जाती है।

**क्या मैं कस्टम आकार को छवि में बदल कर परिणाम "लॉक" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/java/convert-powerpoint-to-png/) या [shape](/slides/hi/java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यॉमेट्री के साथ आगे के कार्य को सरल बनाता है।