---
title: Android पर प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/androidjava/custom-shape/
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
- बिंदु हटाएं
- संपादन क्रिया
- वक्र कोना
- PowerPoint
- प्रस्तुतिकरण
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पाथ, वक्र कोने, सम्मिश्र आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पाथ के माध्यम से आकार ज्यामिति को संपादित करके कस्टमाइज़ करने का तरीका समझाता है। यह दिखाता है कि कैसे [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) और [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) के साथ काम करके मौजूदा आकारों को संशोधित किया जा सकता है, बुनियादी पाथ संपादन कार्य‑क्षेत्र को लागू किया जा सकता है, बिंदुओं को जोड़ा या हटाया जा सकता है, और अपडेटेड ज्यामिति को फिर से आकार पर लागू किया जा सकता है।

यह यह भी दर्शाता है कि कैसे कस्टम और सम्मिश्र आकार बनाएँ, वक्र कोनों के साथ आकार बनाएँ, यह निर्धारित करें कि क्या आकार की ज्यामिति बंद है, और Android बिंदु सरणियों का उपयोग करके आकार तत्वों की जाँच करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको आकार की रूपरेखा को बदलने या मौजूदा आकार को नई आकार की आधारशिला के रूप में उपयोग करने की अनुमति देते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* एक आकार (या उसका पाथ) बंद या खुला हो सकता है।
* आकार का पाथ एंकर बिंदुओं द्वारा जुड़े खंडों से बना होता है।
* एक खंड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने वाले बिंदु, सीधे बिंदु या स्मूद बिंदु के रूप में होते हैं:
  * कोने वाले बिंदु पर, सटे हुए खंड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधे बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से दूरी अलग‑अलग हो सकती है।
* एंकर बिंदुओं को ले जाने या उनके हैंडल को समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिये **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) क्लास और [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) इंस्टेंस [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) ऑब्जेक्ट की ज्यामिति पाथ को दर्शाता है।
* [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) मेथड का उपयोग करके आप [IGeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) प्राप्त कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) सेट करने हेतु आप ये मेथड उपयोग कर सकते हैं: एकल पाथ वाले आकार के लिये [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) और बहु‑पाथ वाले आकार के लिये [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---)।
* खंड जोड़ने हेतु आप [IGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/) के तहत उपलब्ध मेथड उपयोग कर सकते हैं।
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setStroke-boolean-) और [IGeometryPath.setFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#setFillMode-byte-) मेथड से आप किसी ज्यामिति पाथ की उपस्थिति निर्धारित कर सकते हैं।
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) मेथड का उपयोग करके आप किसी [GeometryShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खंडों की सरणी के रूप में प्राप्त कर सकते हैं।

## **सरल संपादन क्रियाएँ**

नीचे दिए गये मेथड्स का उपयोग करके आप ज्यामिति पाथ को संपादित कर सकते हैं। वे ओवरलोड जो इंडेक्स स्वीकार करते हैं, पाथ के खंड सरणी में शून्य‑आधारित स्थान पर खंड डालते हैं।

| ऑपरेशन | विधि |
| --- | --- |
| एक सीधी रेखा जोड़ें या डालें। | [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु के साथ क्यूबिक Bézier वक्र जोड़ें या डालें। | [GeometryPath.cubicBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#cubicBezierTo-float-float-float-float-float-float-) |
| एक नियंत्रण बिंदु और एक अंत बिंदु के साथ द्विघात Bézier वक्र जोड़ें या डालें। | [GeometryPath.quadraticBezierTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#quadraticBezierTo-float-float-float-float-) |
| निर्दिष्ट आयामों और डिग्री में कोणों के साथ एक एलिप्सीय आर्क जोड़ें। | [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) |
| वर्तमान चित्र को उसके अंत बिंदु को शुरुआती बिंदु से जोड़कर बंद करें। | [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) |
| चित्र की शुरुआती बिंदु सेट करें। | [GeometryPath.moveTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#moveTo-float-float-) |
| शून्य‑आधारित इंडेक्स पर खंड हटाएँ। | [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को आयताकार आकार में [GeometryPath.lineTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#lineTo-float-float-) का उपयोग करके सम्मिलित करता है और संपादित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु इसके मध्य में, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट पर स्थित हैं। खंड इंडेक्स 1 और 4 उन्हें क्रमशः ऊपर और नीचे किनारों पर रखते हैं, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

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

यह उदाहरण [GeometryPath.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#removeAt-int-) का उपयोग करके शून्य‑आधारित इंडेक्स 2 पर खंड हटाकर दिल‑आकार की रूपरेखा को बदलता है। संशोधित पाथ को [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू करने से आकार की रूपरेखा अद्यतन हो जाती है।

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

## **कस्टम आकार बनाएं**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) का उपयोग करके पाँच‑बिंदु वाला तारा बनाता है। बाहरी और आंतरिक त्रिज्याएँ क्रमशः 100 और 50 पॉइंट बतौर वैकल्पिक होते हैं; 72‑डिग्री कदम से पाँच टिप्स समान रूप से व्यवस्थित होते हैं। पाथ को [GeometryPath.closeFigure](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#closeFigure--) से बंद किया जाता है और आयताकार आकार पर [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू करके उसकी रूपरेखा को प्रतिस्थापित किया जाता है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;
import java.util.ArrayList;
import java.util.List;

List<PointF> points = new ArrayList<>();

float outerRadius = 100f;
float innerRadius = 50f;
int angleStep = 72;

for (int angle = -90; angle < 270; angle += angleStep)
{
    double radians = angle * (Math.PI / 180f);
    double x = outerRadius * Math.cos(radians);
    double y = outerRadius * Math.sin(radians);
    PointF point = new PointF((float)x + outerRadius, (float)y + outerRadius);
    points.add(point);

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.cos(radians);
    y = innerRadius * Math.sin(radians);
    point = new PointF((float)x + outerRadius, (float)y + outerRadius);
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

## **संघटक कस्टम आकार बनाएं**

यह उदाहरण दो बंद [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/) वस्तुओं को परिभाषित करता है, जो आकार के ऊपर और नीचे के तीन‑तेह भागों के लिये हैं। दोनों पाथ को [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) से लागू करने पर मध्य भाग में खालिआँ अंतर के साथ एक सम्मिलित आकार बनता है।

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

## **वक्र कोनों के साथ कस्टम आकार बनाएं**

यह उदाहरण सीधे खंडों को [GeometryPath.arcTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/#arcTo-float-float-float-float-) के साथ संयोजित करके अंदर‑की‑वक्र कोनों वाले आकार बनाता है। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट्स में निर्धारित करता है, और -90‑डिग्री स्वेप एक प्रतिगामी चतुर्थांश अण्डाकार बनाता है। पूरा पाथ [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) से लागू किया जाता है, और प्रस्तुति को PPTX स्वरूप में सहेजा जाता है।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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

    PointF topLeft = new PointF(leftTopSize, 0);
    PointF topRight = new PointF(shapeWidth - rightTopSize, 0);
    PointF rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    PointF bottomLeft = new PointF(leftBottomSize, shapeHeight);
    PointF leftTop = new PointF(0, leftTopSize);

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

## **जाँचें कि आकार की ज्यामिति बंद है या नहीं**

निम्न सहायक प्रत्येक गैर‑खाली ज्यामिति पाथ के अंत में बंद खंड है या नहीं, इसकी जाँच करता है। यह [IGeometryPath.getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) को पढ़ता है और अंतिम खंड के [IPathSegment.getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) की तुलना [PathCommandType.Close](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑खाली पाथ नहीं है तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑चित्र का निरीक्षण नहीं करता। उदाहरण में आयत के लिये `true` प्रदर्शित होता है।

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

## **ज्योमेट्री पाथ कमांड की जाँच करें**

[contour.pptx](contour.pptx) डाउनलोड करें और डिवाइस पर फ़ाइल का पाथ बदलें। पहली स्लाइड पर पहला आकार एक सीधा शीर्ष किनारा, एक क्यूबिक Bézier वक्र, और एक सीधा समापन किनारा रखता है। आकार के पाथ पढ़ने के लिये [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) और प्रत्येक पाथ के खंड क्रम में पढ़ने के लिये [getPathData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometrypath/#getPathData--) का उपयोग करें। प्रत्येक खंड के लिये, [getPathCommand](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getPathCommand--) कमांड को पहचानता है और [getSegmentData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipathsegment/#getSegmentData--) द्वारा लौटाए गये मानों की व्याख्या निर्धारित करता है।

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

आकार स्लाइड पर (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गये निर्देशांक आकार के स्थानीय होते हैं, जहाँ (0, 0) उसका ऊपरी‑बायाँ कोना होता है, X दाएँ की ओर बढ़ता है और Y नीचे की ओर। समापन खंड अतिरिक्त निर्देशांक के बिना प्रारम्भिक बिंदु पर वापस आता है।

```text
Path 0, segment 0: MoveTo destination=(0.0, 0.0)
Path 0, segment 1: LineTo destination=(80.0, 0.0)
Path 0, segment 2: CubicBezierTo control1=(70.0, 15.0) control2=(30.0, 45.0) end=(0.0, 60.0)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्वों को निकालें और जाँचें**

[IGeometryShape.createShapeElements](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#createShapeElements--) का उपयोग करके आप मौजूदा आकार को उन तत्वों के रूप में जाँच सकते हैं जिनमें पाथ बिंदु और बिंदु प्रकार होते हैं। प्रत्येक लौटाए गये [IShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapeelement/) को [ShapeElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/) में कास्ट करके आप [getPathPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathPoints--) और [getPathTypes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeelement/#getPathTypes--) मेथड से क्रमशः बिंदु और प्रकार सरणियाँ प्राप्त कर सकते हैं। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्रॉइंग टूल्स को ज्यामिति पास करने में उपयोगी है।

उदाहरण input.pptx खोलता है, प्रथम स्लाइड पर पहले ज्यामिति आकार को खोजता है, और उसके पाथ खंडों को प्रिंट करता है। दोनों सीधी और वक्र खंड वाले आकार वाली प्रस्तुति का प्रयोग करें ताकि दोनों प्रकार के आउटपुट देख सकें। यह समूह के भीतर खोज नहीं करता।

```java
import com.aspose.slides.*;
import android.graphics.PointF;

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
            PointF[] points = shapeElement.getPathPoints();
            byte[] types = shapeElement.getPathTypes();
            System.out.println("Shape element:");

            for (int i = 0; i < points.length; i++) {
                int pointType = types[i] & 0x07; // सेगमेंट प्रकार को रखें, फ़्लैग को बाहर रखते हुए.
                switch (pointType) {
                    case 0:
                        System.out.println("Start figure at " + points[i]);
                        break;
                    case 1:
                        System.out.println("Line to " + points[i]);
                        break;
                    case 3:
                        System.out.println("Cubic Bezier: controls " + points[i] + ", " + points[i + 1] + "; end " + points[i + 2]);
                        i += 2; // दोनों नियंत्रण बिंदु और अंत बिंदु को उपयोग करें.
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

सरणियाँ इंडेक्स द्वारा संबंधित होती हैं: `points[i]` एक बिंदु है और `types[i]` उसकी भूमिका बताता है। प्रकार `0` एक चित्र की शुरुआत दर्शाता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक एक रेखा बनाता है। एक क्यूबिक Bézier खंड पिछले अंत बिंदु से शुरू होता है और तीन क्रमिक प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और नया अंत बिंदु। लूप इन तीन प्रविष्टियों को एक साथ लेता है और बंद होने के लिये अंत बिंदु की जाँच करता है।

बिंदु प्रकार में फ़्लैग भी होते हैं। `0x07` के साथ मास्क करके खंड प्रकार पहचाना जाता है, और `0x80` को अलग से जाँच कर बंद उप‑पाथ का पता लगाया जाता है। उदाहरण के लिये, `129` (`0x81`) एक रेखा अंत बिंदु है जो उप‑पाथ को बंद करता है, और `131` (`0x83`) एक Bézier अंत बिंदु है जो बंद करता है। जावा इन फ़्लैग को साइन किए हुए बाइट में संग्रहित करता है; मास्किंग वास्तविक बिट मानों को बरकरार रखता है। केवल `1` या `3` से तुलना करने से ये मामलों छूट जाते हैं। अन्य फ़्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) मूल खंड प्रकार को नहीं बदलते।

**निर्देशांक और रूपान्तरण।** बिंदु पॉइंट्स (1/72 इंच) में मापे जाते हैं, जहाँ X दाएँ बढ़ता है और Y नीचे। एक गैर‑समूहित आकार के लिये, निकाले गये निर्देशांक पहले ही [getX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getX--) और [getY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getY--) द्वारा लौटाए गये स्थिति को सम्मिलित कर चुके होते हैं और उसकी वर्तमान चौड़ाई‑ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित और `120 × 80` आकार का अन-रोटेटेड आयत कंटूर बाउंड्स `(100, 200)`‑`(220, 280)` रखता है। आकार की स्थिति को दोबार नहीं जोड़ें। बिंदुओं को उसके X और Y से घटाकर अन‑रोटेटेड फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गये बिंदु आकार के घूर्णन, जिसे [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getRotation--) द्वारा प्राप्त किया जा सकता है, या क्षैतिज‑ऊर्ध्वाधर फ़्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः प्राप्त करने के लिये इन रूपान्तरणों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह के निर्देशांक मानचित्रण और रूपान्तरणों को भी ध्यान में रखें; यह मान न करें कि निकाले गये बिंदु अंतिम रेंडर स्लाइड निर्देशांक हैं या अनजाने में अनुवाद/स्केल दोबार लागू हो रहा है।

**जाँच बनाम संपादन।** निकाले गये सरणियाँ केवल कंटूर का वर्णन करती हैं; इन्हें बदलने से मूल आकार अद्यतन नहीं होता। जब आपका विश्लेषण या ड्रॉइंग कोड बिंदु/प्रकार सरणियों की आवश्यकता रखता हो तो इस विधि का चयन करें। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए या ज्यामिति संपादित करनी हो तो [getGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#getGeometryPaths--) का उपयोग करें। संपादित पाथ को [setGeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPath-com.aspose.slides.IGeometryPath-) या [setGeometryPaths](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setGeometryPaths-com.aspose.slides.IGeometryPath---) से लागू करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**भौगोलिक आकृति बदलने के बाद फ़िल और आउटलाइन में क्या परिवर्तन होगा?**  
शैलियाँ आकार के साथ रहती हैं; केवल कंटूर बदलता है। फ़िल और आउटलाइन स्वतः नई ज्यामिति पर लागू हो जाते हैं।

**मैं कस्टम आकार को उसकी ज्यामिति के साथ सही तरीके से कैसे घुमा सकता हूँ?**  
आकार की [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setRotation-float-) मेथड का उपयोग करें; क्योंकि ज्यामिति आकार के अपने निर्देशांक प्रणाली से बंधी होती है, यह आकार के साथ घुम जाएगी।

**क्या मैं कस्टम आकार को चित्र में परिवर्तित कर परिणाम को “लॉक‑इन” कर सकता हूँ?**  
हां। आवश्यक [slide](/slides/hi/androidjava/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/androidjava/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; इससे जटिल ज्यामितियों के साथ आगे का काम सरल हो जाता है।