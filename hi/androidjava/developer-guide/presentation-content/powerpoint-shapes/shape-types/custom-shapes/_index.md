---
title: Android पर प्रस्तुति आकृतियों को अनुकूलित करें
linktitle: कस्टम आकृति
type: docs
weight: 20
url: /hi/androidjava/custom-shape/
keywords: 
- कस्टम आकृति
- आकृति जोड़ें
- आकृति बनाएँ
- आकृति बदलें
- आकृति ज्यामिति
- ज्यामिति पथ
- पथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन कार्य
- वक्र कोना
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Java के माध्यम से Android के लिए Aspose.Slides के साथ PowerPoint प्रस्तुतियों में आकृतियों को बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोने, संयुक्त आकृतियां।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकृतियों को संपादन बिंदुओं और ज्यामिति पाथ के माध्यम से आकृति ज्यामिति को संपादित करके अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि `GeometryPath` और `IGeometryPath` के साथ काम करके मौजूदा आकृतियों को संशोधित कैसे किया जाए, बुनियादी पाथ संपादन संचालन कैसे किए जाएँ, बिंदुओं को जोड़ें या हटाएँ, और अद्यतन ज्यामिति को वापस आकृति पर लागू करें।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और संयुक्त आकृतियाँ बनाई जाएँ, वक्र कोनों वाली आकृतियाँ निर्मित की जाएँ, यह निर्धारित किया जाए कि कोई आकृति ज्यामिति बंद है या नहीं, और अतिरिक्त ज्यामिति अनुकूलन परिदृश्यों के लिये `GeometryPath` और `java.awt.Shape` के बीच रूपांतरण किया जाए।

## **एडिट पॉइंट्स का उपयोग करके आकृति बदलना**

एक वर्ग (square) की कल्पना करें। PowerPoint में, **edit points** का उपयोग करके आप

* वर्ग के कोने को अंदर या बाहर ले जा सकते हैं
* किसी कोने या बिंदु की वक्रता निर्धारित कर सकते हैं
* वर्ग में नए बिंदु जोड़ सकते हैं
* वर्ग पर बिंदुओं को हेरफेर कर सकते हैं, आदि।

अंततः, आप किसी भी आकृति पर वर्णित कार्य कर सकते हैं। edit points का उपयोग करके आप एक आकृति को बदल सकते हैं या मौजूदा आकृति से नई आकृति बना सकते हैं।

## **आकृति संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकृतियों को edit points के माध्यम से संपादित करना शुरू करने से पहले, आप इन बिंदुओं पर विचार करना चाहेंगे:

* एक आकृति (या उसका पाथ) बंद या खुला हो सकता है।
* जब एक आकृति बंद होती है, तो उसमें प्रारम्भ या समाप्ति बिंदु नहीं होता। जब आकृति खुली होती है, तो उसके पास शुरुआत और अंत होता है।
* सभी आकृतियों में कम से कम 2 एंकर पॉइंट होते हैं जो एक-दूसरे से रेखाओं द्वारा जुड़े होते हैं।
* एक रेखा या तो सीधी या वक्र होती है। एंकर पॉइंट रेखा की प्रकृति निर्धारित करते हैं।
* एंकर पॉइंट कोने के बिंदु, सीधी बिंदु, या स्मूथ बिंदु के रूप में होते हैं:
  * कोना बिंदु वह बिंदु है जहाँ दो सीधी रेखाएँ कोण पर जुड़ती हैं।
  * स्मूथ बिंदु वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में मौजूद होते हैं और रेखा के खंड स्मूथ वक्र में जुड़ते हैं। इस स्थिति में, सभी हैंडल एंकर पॉइंट से समान दूरी पर होते हैं।
  * सीधा बिंदु वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में मौजूद होते हैं और उस रेखा के खंड स्मूथ वक्र में जुड़ते हैं। इस स्थिति में, हैंडल को एंकर पॉइंट से समान दूरी पर होने की आवश्यकता नहीं होती।
* एंकर पॉइंट को ले जाकर या संपादित करके (जिससे रेखाओं का कोण बदलता है), आप आकृति के रूप को बदल सकते हैं।

PowerPoint आकृतियों को edit points के माध्यम से संपादित करने के लिए, **Aspose.Slides** [**GeometryPath**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास और [**IGeometryPath**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryPath) इंटरफ़ेस प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) इंस्टेंस [IGeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryShape) ऑब्जेक्ट का ज्यामिति पाथ दर्शाता है।
* `IGeometryShape` इंस्टेंस से `GeometryPath` प्राप्त करने के लिए, आप [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) मेथड का उपयोग कर सकते हैं।
* एक आकृति के लिए `GeometryPath` सेट करने हेतु, आप इन मेथड का उपयोग कर सकते हैं: *solid shapes* के लिये [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) और *composite shapes* के लिये [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)।
* सेगमेंट जोड़ने के लिए, आप [IGeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryPath) के अंतर्गत मेथड का उपयोग कर सकते हैं।
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) और [IGeometryPath.setFillMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-) मेथड का उपयोग करके, आप एक ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IGeometryPath#getPathData--) मेथड का उपयोग करके, आप `GeometryShape` का ज्यामिति पाथ पाथ सेगमेंट की एरे के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकृति ज्यामिति अनुकूलन विकल्पों तक पहुँचने के लिये, आप [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में परिवर्तित कर सकते हैं।
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) और [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) मेथड (जो [ShapeUtil](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeUtil) क्लास से हैं) का उपयोग करके, आप [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में और वापस रूपांतरण कर सकते हैं।

## **सरल संपादन संचालन**

यह Java कोड आपको दिखाता है कैसे

**एक रेखा जोड़ें** पाथ के अंत में

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**एक रेखा जोड़ें** एक निर्दिष्ट स्थान पर पाथ में:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**एक क्यूबिक बीज़ियर कर्व जोड़ें** पाथ के अंत में:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**एक क्यूबिक बीज़ियर कर्व जोड़ें** पाथ में निर्दिष्ट स्थान पर:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**एक द्विघात बीज़ियर कर्व जोड़ें** पाथ के अंत में:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**एक द्विघात बीज़ियर कर्व जोड़ें** पाथ में निर्दिष्ट स्थान पर:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**एक दिया गया आर्क जोड़ें** पाथ में:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**पाथ की वर्तमान आकृति बंद करें**:

``` java
public void closeFigure();
```
**अगले बिंदु के लिये स्थिति सेट करें**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**दिए गये इंडेक्स पर पाथ सेगमेंट हटाएँ**:

``` java
public void removeAt(int index);
```

## **आकृति में कस्टम बिंदु जोड़ें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryShape) क्लास की इंस्टेंस बनाएँ और [ShapeType.Rectangle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeType) प्रकार सेट करें।
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास की एक इंस्टेंस प्राप्त करें।
3. पाथ पर दो शीर्ष बिंदुओं के बीच एक नया बिंदु जोड़ें।
4. पाथ पर दो निचले बिंदुओं के बीच एक नया बिंदु जोड़ें।
5. पाथ को आकृति पर लागू करें।

यह Java कोड आपको दिखाता है कि कैसे आकृति में कस्टम बिंदु जोड़ें:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![example1_image](custom_shape_1.png)

## **आकृति से बिंदु हटाएँ**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryShape) क्लास की इंस्टेंस बनाएँ और [ShapeType.Heart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeType) प्रकार सेट करें।
2. आकृति से [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास की एक इंस्टेंस प्राप्त करें।
3. पाथ के लिए सेगमेंट हटाएँ।
4. पाथ को आकृति पर लागू करें।

यह Java कोड आपको दिखाता है कि कैसे आकृति से बिंदु हटाएँ:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![example2_image](custom_shape_2.png)

## **कस्टम आकृति बनाएं**

1. आकृति के बिंदुओं की गणना करें।
2. एक [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास की इंस्टेंस बनाएँ।
3. पाथ को बिंदुओं से भरें।
4. एक [GeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryShape) क्लास की इंस्टेंस बनाएँ।
5. पाथ को आकृति पर लागू करें।

यह Java दिखाता है कि कैसे कस्टम आकृति बनाएं:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![example3_image](custom_shape_3.png)

## **संयुक्त कस्टम आकृति बनाएं**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryShape) क्लास की इंस्टेंस बनाएँ।
2. [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास की पहली इंस्टेंस बनाएँ।
3. [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) क्लास की दूसरी इंस्टेंस बनाएँ.
4. पाथ को आकृति पर लागू करें।

यह Java कोड आपको संयुक्त कस्टम आकृति बनाने के लिये दिखाता है:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों वाली कस्टम आकृति बनाएं**

यह Java कोड आपको दिखाता है कैसे वक्र कोनों (भीतर की ओर) वाली कस्टम आकृति बनाएं;

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **पता लगाएँ कि क्या आकृति ज्यामिति बंद है**

एक बंद आकृति को इस प्रकार परिभाषित किया जाता है कि उसकी सभी पक्ष जुड़े हों, जिससे कोई अंतराल के बिना एक एकल सीमा बनती है। ऐसी आकृति सरल ज्यामितीय रूप या जटिल कस्टम रूपरेखा हो सकती है। निम्नलिखित कोड उदाहरण दिखाता है कि कैसे जांचें कि आकृति ज्यामिति बंद है या नहीं:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **GeometryPath को java.awt.Shape में बदलें**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryShape) क्लास की इंस्टेंस बनाएँ।
2. एक [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) क्लास की इंस्टेंस बनाएँ।
3. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) इंस्टेंस को [GeometryPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/GeometryPath) इंस्टेंस में [ShapeUtil](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ShapeUtil) का उपयोग करके परिवर्तित करें।
4. पाथ को आकृति पर लागू करें।

यह Java कोड—ऊपर दिए गए चरणों का कार्यान्वयन—**GeometryPath** से **GraphicsPath** रूपांतरण प्रक्रिया को दर्शाता है:

``` java
Presentation pres = new Presentation();
try {
    // नई आकृति बनाएं
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // आकृति का ज्यामिति पथ प्राप्त करें
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // पाठ के साथ नया ग्राफ़िक्स पथ बनाएं
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // ग्राफ़िक्स पथ को ज्यामिति पथ में परिवर्तित करें
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // आकृति में नया ज्यामिति पथ और मूल ज्यामिति पथ का संयोजन सेट करें
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति को बदलने के बाद भराव और रूपरेखा के साथ क्या होगा?**

शैली आकृति के साथ बनी रहेगी; केवल कंटीला बदलता है। भराव और रूपरेखा स्वतः नई ज्यामिति पर लागू हो जाते हैं।

**एक कस्टम आकृति को उसकी ज्यामिति के साथ सही ढंग से कैसे घुमाऊँ?**

आकृति की [setRotation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#setRotation-float-) मेथड का उपयोग करें; ज्यामिति आकृति के साथ घुमती है क्योंकि वह आकृति के अपने निर्देशांक प्रणाली से जुड़ी होती है।

**क्या मैं कस्टम आकृति को छवि में बदल सकता हूँ ताकि परिणाम को "लॉक" किया जा सके?**

हां। आवश्यक [slide](/slides/hi/androidjava/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/androidjava/create-shape-thumbnails/) को रास्टर फॉर्मेट में निर्यात करें; इससे भारी ज्यामितियों के साथ आगे का काम सरल हो जाता है।