---
title: जावा में प्रेजेंटेशन शैप्स को कस्टमाइज़ करें
linktitle: कस्टम शैप
type: docs
weight: 20
url: /hi/java/custom-shape/
keywords:
- कस्टम शैप
- शैप जोड़ें
- शैप बनाएं
- शैप बदलें
- शैप ज्योमेट्री
- ज्योमेट्री पाथ
- पाथ पॉइंट्स
- एडिट पॉइंट्स
- पॉइंट जोड़ें
- पॉइंट हटाएं
- संपादन ऑपरेशन
- मुरछा कोना
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रेजेंटेशनों में शैप्स बनाएं और कस्टमाइज़ करें: ज्योमेट्री पाथ्स, मुरछे कोने, कॉम्पोजिट शैप्स।"
---
## **सामान्य विवरण**

यह लेख बताता है कि Aspose.Slides में शैप ज्योमेट्री को एडिट पॉइंट्स और ज्योमेट्री पाथ्स के माध्यम से संपादित करके प्रस्तुतियों के आकार को कैसे कस्टमाइज़ किया जा सकता है। यह दर्शाता है कि `GeometryPath` और `IGeometryPath` के साथ काम करके मौजूदा शैप्स को संशोधित कैसे करें, बुनियादी पाथ संपादन ऑपरेशन करें, पॉइंट्स जोड़ें या हटाएँ, और अपडेटेड ज्योमेट्री को शैप पर पुनः लागू करें।

यह यह भी दिखाता है कि कैसे कस्टम और कॉम्पोजिट शैप्स बनाएँ, मुड़े हुए कोनों वाले शैप्स बनाएँ, यह निर्धारित करें कि शैप की ज्योमेट्री बंद है या नहीं, और अतिरिक्त ज्योमेट्री कस्टमाइजेशन परिदृश्यों के लिए `GeometryPath` और `java.awt.Shape` के बीच रूपांतरण कैसे किया जाए।

## **एडिट पॉइंट्स का उपयोग करके शैप बदलें**

एक वर्ग (square) पर विचार करें। PowerPoint में **एडिट पॉइंट्स** का उपयोग करके आप

* वर्ग के कोने को अंदर या बाहर ले जा सकते हैं
* किसी कोने या पॉइंट की वक्रता निर्दिष्ट कर सकते हैं
* वर्ग में नए पॉइंट्स जोड़ सकते हैं
* वर्ग पर मौजूद पॉइंट्स को संशोधित कर सकते हैं, आदि।

मूलतः, आप इन कार्यों को किसी भी शैप पर कर सकते हैं। एडिट पॉइंट्स का उपयोग करके आप एक शैप को बदल सकते हैं या मौजूदा शैप से नया शैप बना सकते हैं।

## **शैप संपादन टिप्स**

![समीक्षा_छवि](custom_shape_0.png)

PowerPoint शैप्स को एडिट पॉइंट्स के माध्यम से संपादित करने से पहले, शैप्स के बारे में निम्नलिखित बिंदुओं पर विचार करना उपयोगी होगा:

* शैप (या उसका पाथ) बंद या खुला दोनों हो सकता है।
* जब शैप बंद होता है, तो उसके पास कोई प्रारम्भ या अंत बिंदु नहीं होता। जब शैप खुला होता है, तो उसके पास शुरुआत और अंत बिंदु होते हैं।  
* सभी शैप्स में कम से कम 2 एंकर पॉइंट्स होते हैं जो रेखाओं द्वारा आपस में जुड़े होते हैं।
* रेखा सीधी या घुमावदार हो सकती है। एंकर पॉइंट्स रेखा की प्रकृति निर्धारित करते हैं।  
* एंकर पॉइंट्स कोरनेर पॉइंट, स्ट्रेट पॉइंट या स्मूद पॉइंट के रूप में मौजूद होते हैं:
  * कोरनेर पॉइंट वह बिंदु है जहाँ दो सीधी रेखाएँ कोण पर मिलती हैं।  
  * स्मूद पॉइंट वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में होते हैं और रेखा के खंड एक स्मूद कर्व में मिलते हैं। इस स्थिति में सभी हैंडल एंकर पॉइंट से समान दूरी पर होते हैं।  
  * स्ट्रेट पॉइंट वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में होते हैं और रेखा के खंड एक स्मूद कर्व में नहीं मिलते। इस स्थिति में हैंडल को एंकर पॉइंट से समान दूरी पर होने की आवश्यकता नहीं होती।  
* एंकर पॉइंट्स को स्थानांतरित या संपादित करके (जिससे रेखाओं का कोण बदलता है) आप शैप की रूपरेखा बदल सकते हैं।

PowerPoint शैप्स को एडिट पॉइंट्स के माध्यम से संपादित करने के लिए **Aspose.Slides** निम्नलिखित क्लास और इंटरफ़ेस प्रदान करता है: [**GeometryPath**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) और [**IGeometryPath**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryPath)।

* एक [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) इंस्टेंस `IGeometryShape` ऑब्जेक्ट का ज्योमेट्री पाथ दर्शाता है।  
* `IGeometryShape` इंस्टेंस से `GeometryPath` प्राप्त करने के लिए आप [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryShape#getGeometryPaths--) मेथड का उपयोग कर सकते हैं।  
* शैप के लिए `GeometryPath` सेट करने हेतु आप निम्न मेथड का प्रयोग कर सकते हैं: सॉलिड शैप्स के लिए [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) और कॉम्पोजिट शैप्स के लिए [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-)।  
* खंड जोड़ने के लिए आप [IGeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryPath) के अंतर्गत उपलब्ध मेथड्स का उपयोग कर सकते हैं।  
* [IGeometryPath.setStroke](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryPath#setStroke-boolean-) और [IGeometryPath.setFillMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryPath#setFillMode-byte-) मेथड्स के द्वारा आप ज्योमेट्री पाथ की दिखावट तय कर सकते हैं।  
* [IGeometryPath.getPathData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IGeometryPath#getPathData--) मेथड से आप `GeometryShape` का ज्योमेट्री पाथ पाथ खंडों के ऐरे के रूप में प्राप्त कर सकते हैं।  
* अतिरिक्त शैप ज्योमेट्री कस्टमाइज़ेशन विकल्पों तक पहुँचने हेतु आप [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में परिवर्तित कर सकते हैं।  
* [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) और [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) मेथड्स (जो [ShapeUtil](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeUtil) क्लास में हैं) का प्रयोग करके आप [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) में और वापस परिवर्तित कर सकते हैं।  

## **सरल संपादन ऑपरेशन्स**

यह Java कोड दर्शाता है कि आप कैसे

**पाथ के अंत में एक रेखा जोड़ें**

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**पाथ में निर्दिष्ट स्थान पर एक रेखा जोड़ें**

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**पाथ के अंत में एक क्यूबिक बीज़र कर्व जोड़ें**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**पाथ में निर्दिष्ट स्थान पर एक क्यूबिक बीज़र कर्व जोड़ें**

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**पाथ के अंत में एक क्वाड्रेटिक बीज़र कर्व जोड़ें**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**पाथ में निर्दिष्ट स्थान पर क्वाड्रेटिक बीज़र कर्व जोड़ें**

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**पाथ में एक निर्दिष्ट आर्क जोड़ें**

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**पाथ के वर्तमान फ़िगर को बंद करें**

``` java
public void closeFigure();
```
**अगले पॉइंट की स्थिति सेट करें**

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**निर्दिष्ट इंडेक्स पर पाथ खंड हटाएँ**

``` java
public void removeAt(int index);
```

## **शैप में कस्टम पॉइंट्स जोड़ें**
1. [GeometryShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryShape) क्लास की एक इंस्टेंस बनाएँ और [ShapeType.Rectangle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeType) प्रकार सेट करें।  
2. शैप से [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) क्लास की एक इंस्टेंस प्राप्त करें।  
3. पाथ में दो शीर्ष (top) पॉइंट्स के बीच नया पॉइंट जोड़ें।  
4. पाथ में दो निचले (bottom) पॉइंट्स के बीच नया पॉइंट जोड़ें।  
5. पाथ को शैप पर लागू करें।  

यह Java कोड दर्शाता है कि आप शैप में कस्टम पॉइंट्स कैसे जोड़ सकते हैं:

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

## **शैप से पॉइंट्स हटाएँ**

1. [GeometryShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryShape) क्लास की एक इंस्टेंस बनाएँ और [ShapeType.Heart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeType) प्रकार सेट करें।  
2. शैप से [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) क्लास की एक इंस्टेंस प्राप्त करें।  
3. पाथ के खंड को हटाएँ।  
4. पाथ को शैप पर लागू करें।  

यह Java कोड दर्शाता है कि आप शैप से पॉइंट्स कैसे हटाएँ:

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

## **कस्टम शैप बनाएँ**

1. शैप के पॉइंट्स की गणना करें।  
2. एक [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) इंस्टेंस बनाएँ।  
3. पाथ को पॉइंट्स से भरें।  
4. एक [GeometryShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryShape) इंस्टेंस बनाएँ।  
5. पाथ को शैप पर लागू करें।  

यह Java कोड दर्शाता है कि आप कस्टम शैप कैसे बनाते हैं:

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


## **कॉम्पोजिट कस्टम शैप बनाएँ**

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryShape) इंस्टेंस बनाएँ।  
2. पहला [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) इंस्टेंस बनाएँ।  
3. दूसरा [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) इंस्टेंस बनाएँ।  
4. शैप पर पाथ्स लागू करें।  

यह Java कोड दर्शाता है कि आप कॉम्पोजिट कस्टम शैप कैसे बनाते हैं:

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

## **मुरछे कोनों (Curved Corners) के साथ कस्टम शैप बनाएँ**

यह Java कोड दर्शाता है कि आप मुरछे कोनों (आंतरिक) वाले कस्टम शैप कैसे बनाते हैं;

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

## **जाँचें कि शैप की ज्योमेट्री बंद है या नहीं**

बंद शैप वह है जहाँ सभी किनारे आपस में जुड़ते हैं और बिना किसी अंतराल के एकल सीमा बनाते हैं। ऐसी शैप साधारण ज्यामितीय आकृति या जटिल कस्टम रूपरेखा हो सकती है। नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे जाँचें कि शैप की ज्योमेट्री बंद है या नहीं:

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

## **GeometryPath को java.awt.Shape में परिवर्तित करें** 

1. एक [GeometryShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryShape) इंस्टेंस बनाएँ।  
2. एक [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) इंस्टेंस बनाएँ।  
3. [ShapeUtil](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ShapeUtil) का उपयोग करके [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) इंस्टेंस को [GeometryPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/GeometryPath) इंस्टेंस में परिवर्तित करें।  
4. पाथ्स को शैप पर लागू करें।  

ऊपर वर्णित चरणों का एक कार्यान्वयन दर्शाने वाला यह Java कोड **GeometryPath** को **GraphicsPath** में रूपांतरण प्रक्रिया को प्रस्तुत करता है:

``` java
Presentation pres = new Presentation();
try {
    // नया शैप बनाएं
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // शैप का ज्योमेट्री पाथ प्राप्त करें
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // टेक्स्ट के साथ नया ग्राफ़िक पाथ बनाएं
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

    // ग्राफ़िक पाथ को ज्योमेट्री पाथ में बदलें
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // शैप के लिए नया ज्योमेट्री पाथ और मूल ज्योमेट्री पाथ का संयोजन सेट करें
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न (FAQ)**

**ज्यॉमेट्री बदलने के बाद भराव (fill) और रूपरेखा (outline) पर क्या असर पड़ेगा?**

स्टाइल शैप के साथ बना रहता है; केवल किनारा बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्योमेट्री पर लागू हो जाते हैं।

**मैं कस्टम शैप को उसकी ज्योमेट्री के साथ सही ढंग से कैसे घुमा सकता हूँ?**

शैप की [setRotation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#setRotation-float-) मेथड का उपयोग करें; ज्योमेट्री शैप के साथ घुमेगी क्योंकि वह शैप के अपने निर्देशांक प्रणाली से बंधी होती है।

**क्या मैं कस्टम शैप को एक इमेज में बदलकर परिणाम को “लॉक” कर सकता हूँ?**

हां। आवश्यक [slide](/slides/hi/java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में एक्सपोर्ट करें; यह भारी ज्योमेट्री के साथ आगे के कार्य को सरल बनाता है।