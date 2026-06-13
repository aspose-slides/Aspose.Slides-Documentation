---
title: PHP में प्रस्तुति आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/php-java/custom-shape/
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
- बिंदु हटाएं
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुतिकरण
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पथ, वक्र कोने, समुच्चय आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकार ज्यामिति को संपादित करके अनुकूलित करने का तरीका समझाता है। यह दिखाता है कि `GeometryPath` के साथ काम करके मौजूदा आकारों को संशोधित करना, बुनियादी पथ संपादन कार्य करना, बिंदु जोड़ना या हटाना, और अद्यतन ज्यामिति को फिर से आकार पर लागू करना।

यह यह भी दर्शाता है कि कस्टम और सम्मिश्र आकार कैसे बनाएं, घुमावदार कोनों वाले आकार बनाएं, निर्धारित करें कि आकार ज्यामिति बंद है या नहीं, और अतिरिक्त ज्यामिति अनुकूलन परिदृश्यों के लिए `GeometryPath` और `java.awt.Shape` के बीच रूपांतरण कैसे करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

एक वर्ग पर विचार करें। PowerPoint में, **संपादन बिंदुओं** का उपयोग करके आप

* वर्ग के कोने को अंदर या बाहर ले जा सकते हैं
* कोने या बिंदु की वक्रता निर्दिष्ट कर सकते हैं
* वर्ग में नए बिंदु जोड़ सकते हैं
* वर्ग के बिंदुओं को हेर-फेर कर सकते हैं, आदि।

मूल रूप से, आप वर्णित कार्य किसी भी आकार पर कर सकते हैं। संपादन बिंदुओं का उपयोग करके आप किसी आकार को बदल सकते हैं या मौजूदा आकार से नया आकार बना सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करना शुरू करने से पहले, आप इन बिंदुओं पर विचार करना चाह सकते हैं:

* एक आकार (या उसका पथ) बंद या खुला हो सकता है।
* जब आकार बंद होता है, तो उसमें प्रारम्भ या अंत बिंदु नहीं होता। जब आकार खुला होता है, तो उसमें एक शुरुआत और अंत होता है।
* सभी आकार कम से कम 2 एंकर बिंदुओं से मिलकर बनते हैं जो लाइनों के द्वारा जुड़े होते हैं।
* एक रेखा सीधे या वक्र हो सकती है। एंकर बिंदु रेखा की प्रकृति निर्धारित करते हैं।
* एंकर बिंदु कोने के बिंदु, सीधी बिंदु, या सहज बिंदु के रूप में होते हैं:
  * कोने का बिंदु वह बिंदु है जहाँ दो सीधी रेखाएँ कोण पर मिलती हैं।
  * सहज बिंदु वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में होते हैं और रेखा के खंड एक सहज वक्र में मिलते हैं। इस स्थिति में, सभी हैंडल एंकर बिंदु से समान दूरी पर अलग होते हैं।
  * सीधा बिंदु वह बिंदु है जहाँ दो हैंडल एक सीधी रेखा में होते हैं और उस रेखा के खंड एक सहज वक्र में मिलते हैं। इस स्थिति में, हैंडल को एंकर बिंदु से समान दूरी पर होने की आवश्यकता नहीं है।
* एंकर बिंदुओं को स्थानांतरित या संपादित करके (जो रेखाओं के कोण को बदलता है), आप आकार की दिखावट बदल सकते हैं।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [**GeometryPath**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) उदाहरण [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/) वस्तु का ज्यामिति पथ दर्शाता है।
* `GeometryShape` उदाहरण से `GeometryPath` प्राप्त करने के लिए, आप [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग कर सकते हैं।
* किसी आकार के लिए `GeometryPath` सेट करने हेतु, आप इन मेथड्स का उपयोग कर सकते हैं: *भूतिया आकार* के लिए [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#setGeometryPath) और *समुच्चय आकार* के लिए [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#setGeometryPaths)।
* सेगमेंट जोड़ने के लिए, आप [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/) के तहत मेथड्स का उपयोग कर सकते हैं।
* इन मेथड्स [GeometryPath::setStroke](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/setstroke/) और [GeometryPath::setFillMode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/setfillmode/) का उपयोग करके आप किसी ज्यामिति पथ की रूपरेखा निर्धारित कर सकते हैं।
* इन मेथड [GeometryPath::getPathData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/getpathdata/) का उपयोग करके आप `GeometryShape` की ज्यामिति पथ को पथ खंडों की सरणी के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों तक पहुंचने के लिए, आप [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) में परिवर्तित कर सकते हैं।
* इन मेथड्स [geometryPathToGraphicsPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeutil/geometrypathtographicspath/) और [graphicsPathToGeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeutil/graphicspathtogeometrypath/) ( [ShapeUtil](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ShapeUtil) क्लास से) का उपयोग करके आप [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometrypath/) को [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) में आगे‑पीछे रूपांतरित कर सकते हैं।

## **सरल संपादन संचालन**

यह PHP कोड आपको दर्शाता है कि कैसे

**एक रेखा जोड़ें** पथ के अंत में

```php

```
**एक रेखा जोड़ें** पथ पर निर्दिष्ट स्थिति में:

```php

```
**एक क्यूबिक बीज़ियर वक्र जोड़ें** पथ के अंत में:

```php

```
**एक क्यूबिक बीज़ियर वक्र जोड़ें** पथ पर निर्दिष्ट स्थिति में:

```php

```
**एक क्वाड्रेटिक बीज़ियर वक्र जोड़ें** पथ के अंत में:

```php

```
**एक क्वाड्रेटिक बीज़ियर वक्र जोड़ें** पथ पर निर्दिष्ट स्थिति में:

```php

```
**एक दी गई चाप जोड़ें** पथ में:

```php

```
**वर्तमान आकृति बंद करें** पथ की:

```php

```
**अगले बिंदु के लिए स्थिति सेट करें**:

```php

```
**एक दिए गए अनुक्रम में पथ खंड हटाएं**:

```php

```

## **आकार में कस्टम बिंदु जोड़ें**

1. [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं और [ShapeType::Rectangle] प्रकार सेट करें।
2. आकार से [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण प्राप्त करें।
3. पथ पर दो शीर्ष बिंदुओं के बीच एक नया बिंदु जोड़ें।
4. पथ पर दो निचले बिंदुओं के बीच एक नया बिंदु जोड़ें।
5. पथ को आकार पर लागू करें।

यह PHP कोड आपको दिखाता है कि कैसे आकार में कस्टम बिंदु जोड़ें:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);
    $shape->setGeometryPath($geometryPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

1. [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं और [ShapeType::Heart] प्रकार सेट करें।
2. आकार से [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण प्राप्त करें।
3. पथ का खंड हटाएं।
4. पथ को आकार पर लागू करें।

यह PHP कोड आपको दिखाता है कि कैसे आकार से बिंदु हटाएँ:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);
    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);
    $shape->setGeometryPath($path);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example2_image](custom_shape_2.png)

##  **कस्टम आकार बनाएं**

1. आकार के बिंदुओं की गणना करें।
2. [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास का एक उदाहरण बनाएं।
3. बिंदुओं के साथ पथ को भरें।
4. [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं।
5. पथ को आकार पर लागू करें।

यह Java कोड आपको दिखाता है कि कैसे कस्टम आकार बनाएं:

```php
  $points = new Java("java.util.ArrayList");
  $R = 100;
  $r = 50;
  $step = 72;
  for($angle = -90; $angle < 270; $angle += $step) {
    $radians = $angle * java("java.lang.Math")->PI / 180.0;
    $x = $R * java("java.lang.Math")->cos($radians);
    $y = $R * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
    $radians = java("java.lang.Math")->PI * $angle . $step / 2 / 180.0;
    $x = $r * java("java.lang.Math")->cos($radians);
    $y = $r * java("java.lang.Math")->sin($radians);
    $points->add(new Point2DFloat($x + $R, $y + $R));
  }
  $starPath = new GeometryPath();
  $starPath->moveTo($points->get(0));
  for($i = 1; $i < java_values($points->size()) ; $i++) {
    $starPath->lineTo($points->get($i));
  }
  $starPath->closeFigure();
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $R * 2, $R * 2);
    $shape->setGeometryPath($starPath);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example3_image](custom_shape_3.png)


## **समुच्चय कस्टम आकार बनाएं**

1. [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं।
2. [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास का पहला उदाहरण बनाएं।
3. [GeometryPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryPath) क्लास का दूसरा उदाहरण बनाएं।
4. पथों को आकार पर लागू करें।

यह PHP कोड आपको समुच्चय कस्टम आकार बनाने दिखाता है:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $geometryPath0 = new GeometryPath();
    $geometryPath0->moveTo(0, 0);
    $geometryPath0->lineTo($shape->getWidth(), 0);
    $geometryPath0->lineTo($shape->getWidth(), $shape->getHeight() / 3);
    $geometryPath0->lineTo(0, $shape->getHeight() / 3);
    $geometryPath0->closeFigure();
    $geometryPath1 = new GeometryPath();
    $geometryPath1->moveTo(0, $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight() / 3 * 2);
    $geometryPath1->lineTo($shape->getWidth(), $shape->getHeight());
    $geometryPath1->lineTo(0, $shape->getHeight());
    $geometryPath1->closeFigure();
    $shape->setGeometryPaths(array($geometryPath0, $geometryPath1 ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों के साथ कस्टम आकार बनाएं**

यह PHP कोड आपको दिखाता है कि कैसे वक्र कोनों (भीतर की ओर) के साथ कस्टम आकार बनाएं;

```php
  $shapeX = 20.0;
  $shapeY = 20.0;
  $shapeWidth = 300.0;
  $shapeHeight = 200.0;
  $leftTopSize = 50.0;
  $rightTopSize = 20.0;
  $rightBottomSize = 40.0;
  $leftBottomSize = 10.0;
  $pres = new Presentation();
  try {
    $childShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);
    $geometryPath = new GeometryPath();
    $point1 = new Point2DFloat($leftTopSize, 0);
    $point2 = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $point3 = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $point4 = new Point2DFloat($leftBottomSize, $shapeHeight);
    $point5 = new Point2DFloat(0, $leftTopSize);
    $geometryPath->moveTo($point1);
    $geometryPath->lineTo($point2);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($point3);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($point4);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($point5);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();
    $childShape->setGeometryPath($geometryPath);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **जांचें कि क्या आकार ज्यामिति बंद है**

एक बंद आकार वह है जहाँ सभी पक्ष जुड़े होते हैं, जिससे कोई अंतराल के बिना एकल सीमा बनती है। ऐसा आकार साधारण ज्यामितीय रूप या जटिल कस्टम रूपरेखा हो सकता है। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे जांचें कि आकार की ज्यामिति बंद है या नहीं:

```php
function isGeometryClosed($geometryShape)
{
    $isClosed = null;

    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $dataLength = count(java_values($geometryPath->getPathData()));
        if ($dataLength === 0) {
            continue;
        }

        $lastSegment = java_values($geometryPath->getPathData())[$dataLength - 1];
        $isClosed = $lastSegment->getPathCommand() === PathCommandType::Close;

        if ($isClosed === false) {
            return false;
        }
    }

    return $isClosed === true;
}
```

## **GeometryPath को java.awt.Shape में बदलें**

1. [GeometryShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/GeometryShape) क्लास का एक उदाहरण बनाएं।
2. [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/php-java/awt/Shape.html) क्लास का एक उदाहरण बनाएं।
3. [ShapeUtil](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ShapeUtil) का उपयोग करके [java.awt.Shape] उदाहरण को [GeometryPath] उदाहरण में परिवर्तित करें।
4. पथों को आकार पर लागू करें।

यह PHP कोड—ऊपर बताए गए चरणों का कार्यान्वयन—**GeometryPath** से **GraphicsPath** रूपांतरण प्रक्रिया दिखाता है:

```php
  $pres = new Presentation();
  try {
    # नया आकार बनाएं
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    # आकार का ज्यामिति पथ प्राप्त करें
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);
    # पाठ के साथ नया ग्राफ़िक्स पथ बनाएं
    $graphicsPath;
    $font = new Font("Arial", Font->PLAIN, 40);
    $text = "Text in shape";
    $img = new BufferedImage(100, 100, BufferedImage->TYPE_INT_ARGB);
    $g2 = $img->createGraphics();
    try {
      $glyphVector = $font->createGlyphVector($g2->getFontRenderContext(), $text);
      $graphicsPath = $glyphVector->getOutline(20.0, -$glyphVector->getVisualBounds()->getY() + 10);
    } finally {
      $g2->dispose();
    }
    # ग्राफ़िक्स पथ को ज्यामिति पथ में परिवर्तित करें
    $textPath = ShapeUtil->graphicsPathToGeometryPath($graphicsPath);
    $textPath->setFillMode(PathFillModeType::Normal);
    # आकार पर नया ज्यामिति पथ और मूल ज्यामिति पथ का संयोजन सेट करें
    $shape->setGeometryPaths(array($originalPath, $textPath ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**जब ज्यामिति बदलने के बाद भराव और बाहरी रूपरेखा क्या होगा?**

स्टाइल आकार के साथ ही रहता है; केवल रूपरेखा बदलती है। भराव और सीमांकन स्वचालित रूप से नई ज्यामिति पर लागू हो जाते हैं।

**मैं कैसे कस्टम आकार को उसकी ज्यामिति के साथ सही ढंग से घुमा सकता हूँ?**

आकार की [setRotation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setrotation/) मेथड का उपयोग करें; क्योंकि ज्यामिति आकार के अपने निर्देशांक प्रणाली से बंधी होती है, इसलिए वह आकार के साथ घुमती है।

**क्या मैं कस्टम आकार को एक छवि में बदल सकता हूँ ताकि परिणाम को "लॉक इन" किया जा सके?**

हाँ। आवश्यक [slide](/slides/hi/php-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/php-java/create-shape-thumbnails/) को रास्टर स्वरूप में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के कार्य को सरल बनाता है।