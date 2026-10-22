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
- ज्यामिति पाथ
- पाथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएं
- संपादन संचालन
- वक्र कोना
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides के साथ PowerPoint प्रस्तुतियों में आकार बनाएं और अनुकूलित करें: ज्यामिति पाथ, वक्र कोने, संयुक्त आकार।"
---
## **समीक्षा**

यह लेख समझाता है कि Aspose.Slides में प्रस्तुति आकारों को संपादन बिंदुओं और ज्यामिति पाथों के माध्यम से आकार ज्यामिति को संपादित करके कैसे अनुकूलित किया जाए। यह दिखाता है कि मौजूदा आकारों को संशोधित करने, बुनियादी पाथ संपादन संचालन करने, बिंदु जोड़ने या हटाने, और अद्यतन ज्यामिति को फिर से आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) के साथ कैसे काम किया जाए।

यह यह भी प्रदर्शित करता है कि कैसे कस्टम और संयुक्त आकार बनाएँ, वक्र कोनों वाले आकार बनायें, यह निर्धारित करें कि कोई आकार ज्यामिति बंद है या नहीं, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट आउटलाइन को ज्यामिति पाथों में परिवर्तित करें।

## **संपादन बिंदुओं के द्वारा आकार बदलें**

PowerPoint में, आप **संपादन बिंदुओं** का उपयोग करके एक वर्ग को संशोधित कर सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर वक्रता को समायोजित करें।
* नए बिंदु जोड़ें।

बिंदुओं को संपादित करने से आप किसी आकार की रूपरेखा को बदल सकते हैं या मौजूदा आकार को नई आकार की आधारशिला के रूप में उपयोग कर सकते हैं।

## **आकार संपादन टिप्स**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय निम्नलिखित अवधारणाओं को ध्यान में रखें:

* कोई आकार (या उसका पाथ) बंद या खुला दोनों हो सकता है।
* आकार का पाथ एंकर बिंदुओं से बना होता है जो खण्डों द्वारा जुड़े होते हैं।
* एक खण्ड सीधा या वक्र हो सकता है। एंकर बिंदु और नियंत्रण हैंडल इसकी आकृति निर्धारित करते हैं।
* एंकर बिंदु कोने बिंदु, सीधा बिंदु, या स्मूद बिंदु के रूप में होते हैं:
  * कोने बिंदु पर, आसन्न खण्ड एक कोण पर मिल सकते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से अलग-अलग दूरी पर हो सकते हैं।
* एंकर बिंदुओं को ले जाना या उनके हैंडल समायोजित करने से आकार की रूपरेखा बदलती है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए, **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) वस्तु की ज्यामिति पाथ को दर्शाता है।
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) से [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) विधि का उपयोग कर सकते हैं।
* किसी आकार के लिए [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) सेट करने हेतु आप ये विधियाँ प्रयोग कर सकते हैं: एकल पाथ वाले आकारों के लिये [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) और बहु‑पाथ वाले आकारों के लिये [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)।
* खण्ड जोड़ने के लिये आप [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) के अंतर्गत उपलब्ध विधियों का उपयोग कर सकते हैं।
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) विधियों के द्वारा आप किसी ज्यामिति पाथ की उपस्थिति सेट कर सकते हैं।
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) विधि से आप किसी [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) की ज्यामिति पाथ को पाथ खण्डों की सरणी के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों तक पहुँचने के लिये आप एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और उन खण्डों को एक [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) पर पुनः चल सकते हैं।

## **सरल संपादन संचालन**

नीचे दी गई विधियों का उपयोग करके एक ज्यामिति पाथ को संपादित करें। ओवरलोड जो इंडेक्स स्वीकार करते हैं, वह पाथ की खण्ड सरणी में शून्य‑आधारित स्थिति पर एक खण्ड डालते हैं।

| प्रक्रिया | विधि |
| --- | --- |
| सीधी रेखा जोड़ें या Insert करें। | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं एवं एक अंत बिंदु वाला क्यूबिक बेज़ियर वक्र जोड़ें या Insert करें। | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु एवं अंत बिंदु वाला क्वाड्रेटिक बेज़ियर वक्र जोड़ें या Insert करें। | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम एवं डिग्री में कोणों के साथ दीर्घवृत्तीय धुंध जोड़ें। | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| वर्तमान आकृति को उसके अंतिम बिंदु को प्रारंभ बिंदु से जोड़कर बंद करें। | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| आकृति का प्रारंभ बिंदु सेट करें। | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| शून्य‑आधारित सूचकांक पर किसी खण्ड को हटाएँ। | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को एक आयताकार आकार में [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) का उपयोग करके सम्मिलित करता है और संपादित पाथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) के द्वारा लागू करता है। निर्देशांक स्थानीय होते हैं: दोनों नए बिंदु आकार के केंद्र में, बाएँ से 100 प्वाइंट और ऊपर से 50 प्वाइंट पर स्थित हैं। खण्ड सूचकांक 1 और 4 उन्हें क्रमशः ऊपर और नीचे किनारों पर रखते हैं, जिससे ये किनारे अंदर की ओर खींचे जाते हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $geometryPath = $shape->getGeometryPaths()[0];
    $geometryPath->lineTo(100, 50, 1);
    $geometryPath->lineTo(100, 50, 4);

    $shape->setGeometryPath($geometryPath);
} finally {
    $presentation->dispose();
}
```

![example1_image](custom_shape_1.png)

## **आकार से बिंदु हटाएँ**

यह उदाहरण [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) के द्वारा शून्य‑आधारित सूचकांक 2 पर खण्ड को हटाकर हृदय‑आकार की रूपरेखा बदलता है। संशोधित पाथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू करने से आकार की रूपरेखा अपडेट होती है।

```php
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Heart, 100, 100, 300, 300);

    $path = $shape->getGeometryPaths()[0];
    $path->removeAt(2);

    $shape->setGeometryPath($path);
} finally {
    $presentation->dispose();
}
```
![example2_image](custom_shape_2.png)

## **कस्टम आकार बनाएँ**

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) का उपयोग करके पाँच‑बिंदु वाला तारा बनाता है। बाहरी और आंतरिक त्रिज्याएँ क्रमशः 100 और 50 प्वाइंट के बारी-बारी से परिभाषित की गई हैं; 72‑डिग्री कदम से पाँच टिप्स समान रूप से वितरित होते हैं। पाथ को [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया जाता है और एक आयताकार आकार में [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू किया जाता है, जिससे उसकी रूपरेखा प्रतिस्थापित हो जाती है।

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$points = [];
$outerRadius = 100;
$innerRadius = 50;
$angleStep = 72;
for ($angle = -90; $angle < 270; $angle += $angleStep) {
    $radians = deg2rad($angle);
    $points[] = [$outerRadius * cos($radians) + $outerRadius, $outerRadius * sin($radians) + $outerRadius];
    $radians = deg2rad($angle + $angleStep / 2);
    $points[] = [$innerRadius * cos($radians) + $outerRadius, $innerRadius * sin($radians) + $outerRadius];
}

$starPath = new GeometryPath();
$starPath->moveTo($points[0][0], $points[0][1]);
for ($i = 1; $i < count($points); $i++) {
    $starPath->lineTo($points[$i][0], $points[$i][1]);
}
$starPath->closeFigure();

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, $outerRadius * 2, $outerRadius * 2);
    $shape->setGeometryPath($starPath);
} finally {
    $presentation->dispose();
}
```
![example3_image](custom_shape_3.png)

## **संयुक्त कस्टम आकार बनाएँ**

यह उदाहरण आकार के ऊपर और नीचे के तिहाई हिस्सों के लिये दो बंद [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) वस्तुएँ परिभाषित करता है। दोनों पाथ को [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से मध्य तिहाई में अंतर के साथ एकल संयुक्त आकार बनता है।

```php
use aspose\slides\GeometryPath;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);

    $topPath = new GeometryPath();
    $topPath->moveTo(0, 0);
    $topPath->lineTo(java_values($shape->getWidth()), 0);
    $topPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3);
    $topPath->lineTo(0, java_values($shape->getHeight()) / 3);
    $topPath->closeFigure();

    $bottomPath = new GeometryPath();
    $bottomPath->moveTo(0, java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()) / 3 * 2);
    $bottomPath->lineTo(java_values($shape->getWidth()), java_values($shape->getHeight()));
    $bottomPath->lineTo(0, java_values($shape->getHeight()));
    $bottomPath->closeFigure();

    $shape->setGeometryPaths([$topPath, $bottomPath]);
} finally {
    $presentation->dispose();
}
```
![example4_image](custom_shape_4.png)

## **वक्र कोनों वाले कस्टम आकार बनाएँ**

यह उदाहरण सीधी खण्डों को [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर अंदर की ओर वक्र कोनों वाला आकार बनाता है। प्रत्येक कोना आकार आर्क की चौड़ाई और ऊँचाई को प्वाइंट में निर्धारित करता है, और -90‑डिग्री स्वेप एक नियामक दिशा में एक चौथाई दीर्घवृत्त बनाता है। पूर्ण पाथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) द्वारा लागू किया जाता है, और प्रस्तुति PPTX प्रारूप में सहेजी जाती है।

```php
use aspose\slides\GeometryPath;
use aspose\slides\Point2DFloat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$shapeX = 20;
$shapeY = 20;
$shapeWidth = 300;
$shapeHeight = 200;

$leftTopSize = 50;
$rightTopSize = 20;
$rightBottomSize = 40;
$leftBottomSize = 10;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Custom, $shapeX, $shapeY, $shapeWidth, $shapeHeight);

    $topLeft = new Point2DFloat($leftTopSize, 0);
    $topRight = new Point2DFloat($shapeWidth - $rightTopSize, 0);
    $rightBottom = new Point2DFloat($shapeWidth, $shapeHeight - $rightBottomSize);
    $bottomLeft = new Point2DFloat($leftBottomSize, $shapeHeight);
    $leftTop = new Point2DFloat(0, $leftTopSize);

    $geometryPath = new GeometryPath();
    $geometryPath->moveTo($topLeft);
    $geometryPath->lineTo($topRight);
    $geometryPath->arcTo($rightTopSize, $rightTopSize, 180, -90);
    $geometryPath->lineTo($rightBottom);
    $geometryPath->arcTo($rightBottomSize, $rightBottomSize, -90, -90);
    $geometryPath->lineTo($bottomLeft);
    $geometryPath->arcTo($leftBottomSize, $leftBottomSize, 0, -90);
    $geometryPath->lineTo($leftTop);
    $geometryPath->arcTo($leftTopSize, $leftTopSize, 90, -90);
    $geometryPath->closeFigure();

    $shape->setGeometryPath($geometryPath);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **जाँचें कि क्या आकार ज्यामिति बंद है**

निम्नलिखित सहायक फ़ंक्शन यह जांचता है कि प्रत्येक गैर‑खाली ज्यामिति पाथ अंत में बंद खण्ड के साथ समाप्त होती है या नहीं। यह [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) पढ़ता है और अंतिम खण्ड के [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) को [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) से तुलना करता है। जब कोई गैर‑खाली पाथ नहीं होता तो यह false लौटाता है। यह प्रत्येक पाथ के अंतिम कमांड की जाँच करता है; यह पाथ के भीतर प्रत्येक उप‑चित्र का निरीक्षण नहीं करता। उदाहरण में आयत के लिये `true` प्रदर्शित होता है।

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

function isGeometryClosed($geometryShape)
{
    $hasNonemptyPath = false;
    foreach ($geometryShape->getGeometryPaths() as $geometryPath) {
        $segments = java_values($geometryPath->getPathData());
        if (count($segments) === 0) {
            continue;
        }
        $hasNonemptyPath = true;
        $lastSegment = $segments[count($segments) - 1];
        if (java_values($lastSegment->getPathCommand()) !== PathCommandType::Close) {
            return false;
        }
    }
    return $hasNonemptyPath;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $closed = isGeometryClosed($shape);
    echo ($closed ? "true" : "false") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **आकार तत्वों को निकालें और निरीक्षण करें**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) का प्रयोग करके आप किसी मौजूदा आकार को पाथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक प्राप्त [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) का उपयोग करके आप [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) विधियों के माध्यम से बिंदु और प्रकार सरणियों को प्राप्त कर सकते हैं। यह प्रतिनिधित्व आकार की रूपरेखा विश्लेषण या कस्टम ड्राइंग टूल्स के लिये ज्यामिति पास करने में उपयोगी है।

उदाहरण `input.pptx` खोलता है, पहले स्लाइड पर सीधे पहला ज्यामिति आकार खोजता है, और उसके पाथ खण्डों को प्रदर्शित करता है। दोनों, सीधी और वक्र खण्डों वाले आकार वाली प्रस्तुति का उपयोग करके आप दोनों प्रकार के आउटपुट देख सकते हैं। यह समूहों के भीतर खोज नहीं करता।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = null;
    $shapes = $slide->getShapes();
    for ($shapeIndex = 0; $shapeIndex < java_values($shapes->size()); $shapeIndex++) {
        $candidate = $shapes->get_Item($shapeIndex);
        if (java_instanceof($candidate, java("com.aspose.slides.GeometryShape"))) {
            $shape = $candidate;
            break;
        }
    }

    if ($shape === null) {
        echo "No geometry shape found on the first slide." . PHP_EOL;
    } else {
        foreach ($shape->createShapeElements() as $element) {
            $points = java_values($element->getPathPoints());
            $types = array_values(unpack("C*", java_values($element->getPathTypes())));
            echo "Shape element:" . PHP_EOL;
            for ($i = 0; $i < count($points); $i++) {
                $pointType = $types[$i] & 0x07; // सेगमेंट प्रकार रखें, फ़्लैग को बाहर रखते हुए।
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // दोनों नियंत्रण बिंदु और अंत बिंदु को उपभोग करें।
                        break;
                }
                if (($types[$i] & 0x80) !== 0) {
                    echo "Close subpath back to its starting point." . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

सरणियाँ इंडेक्स द्वारा मेल खाती हैं: `$points[$i]` एक बिंदु है और `$types[$i]` उसकी भूमिका वर्णित करता है। प्रकार `0` एक आकृति शुरू करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक रेखा बनाता है। एक क्यूबिक बेज़ियर खण्ड पिछले अंतिम बिंदु से शुरू होता है और क्रमिक रूप से तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और फिर नया अंतिम बिंदु। लूप इन तीन प्रविष्टियों को एक साथ ग्रहण करता है और बंद होने के लिये अंतिम बिंदु की जाँच करता है।

बिंदु प्रकारों में फ्लैग भी होते हैं। खण्ड प्रकार पहचानने के लिये `0x07` के साथ मास्क करें, और बंद उप‑पाथ का पता लगाने के लिये `0x80` को अलग से परीक्षण करें। उदाहरण के लिये, `129` (`0x81`) का अर्थ है वह रेखा अंतिम बिंदु जो उप‑पाथ को बंद करता है, और `131` (`0x83`) का अर्थ है वह बेज़ियर अंतिम बिंदु जो बंद करता है। PHP/Java Bridge बाइट सरणी को बाइनरी स्ट्रिंग के रूप में लौटाता है; "C*" के साथ अनपैक करने से अनसाइनड बाइट मान मिलते हैं। मास्किंग मूल बिट मानों को संरक्षित रखती है। केवल `1` या `3` के साथ कच्चे मान की तुलना करने से ये केस छूट जाएंगे। अन्य फ्लैग, जैसे डैश (`0x10`) और मार्कर (`0x20`), मूल खण्ड प्रकार को नहीं बदलते।

**निर्देशांक और परिवर्तन।** बिंदु प्वाइंट (1/72 इंच) में मापे जाते हैं, X दाएँ ओर बढ़ता है और Y नीचे की ओर। एक अन‑ग्रुप्ड आकार के लिये, निकाले गए निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) द्वारा लौटाए गए स्थिति को शामिल करते हैं और उसकी वर्तमान चौड़ाई व ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर स्थित और `120 × 80` आकार वाला नहीं‑घुमाया गया आयत का कंटूर बॉन्ड `(100, 200)`‑`(220, 280)` है। आकार की स्थिति को दोबारा जोड़ें नहीं। X और Y घटा कर निर्देशांक को उसके अन‑घुमाए फ़्रेम के सापेक्ष प्राप्त करें।

निकाले गए बिंदुओं पर [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) द्वारा लौटाए गए घुमाव या क्षैतिज‑ऊर्ध्वाधर फ़्लिप लागू नहीं होते। प्रदर्शित कंटूर को पुनः प्राप्त करने के लिये इन परिवर्तनियों को आकार के केंद्र के चारों ओर लागू करें। समूहित आकारों के लिये, समूह निर्देशांक मानचित्रण और परिवर्तनियों को भी ध्यान में रखें; यह मानें नहीं कि निकाले गए बिंदु अंतिम रेंडर हुए स्लाइड निर्देशांक हैं या अनजाने में अनुवाद/स्केल दो बार लागू हो रहा है।

**निरीक्षण बनाम संपादन।** निकाली गई सरणियाँ कंटूर को वर्णित करती हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। जब आपका विश्लेषण या ड्राइंग कोड बिंदु/प्रकार सरणियों की आवश्यकता रखता है तब इस दृष्टिकोण को चुनें। आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए हों तो [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) का उपयोग करें या उसकी ज्यामिति को संपादित करना चाहते हों तो [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) के माध्यम से संपादित पाथ लागू करें।

## **Java AWT Shape को GeometryPath में बदलें**

यह उदाहरण आयताकार रूपरेखा को टेक्स्ट के साथ मिलाता है जिसे ज्यामिति में परिवर्तित किया गया है। रूपरेखा की [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) विधि उसका भराव निष्क्रिय करती है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मूव, लाइन, क्वाड्रेटिक, क्यूबिक और क्लोज़िंग खण्ड प्रदान करता है, जिन्हें उदाहरण [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) पर पुनः चलाता है।

उदाहरण एक Java फ़्लोट सरणी का उपयोग करता है ताकि PHP/Java Bridge इटरटर द्वारा लिखे गए निर्देशांक को बरकरार रखा जा सके। टेक्स्ट 40‑प्वाइंट Arial फ़ॉन्ट में है। रूपरेखा को क्षैतिज रूप से 20 प्वाइंट आगे और दृश्य शीर्ष को आकार के शीर्ष किनारे से 10 प्वाइंट नीचे स्थित किया गया है। टेक्स्ट पाथ भरा हुआ है, जबकि मूल आयत केवल एक रूपरेखा है। दोनों पाथ को [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) द्वारा लागू करने से एक ही आकार बनता है जिसमें आयत और टेक्स्ट दोनों सम्मिलित होते हैं।

```php
use aspose\slides\GeometryPath;
use aspose\slides\PathFillModeType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 100);
    
    $originalPath = $shape->getGeometryPaths()[0];
    $originalPath->setFillMode(PathFillModeType::None);

    $fontClass = java("java.awt.Font");
    $imageClass = java("java.awt.image.BufferedImage");
    $font = new Java("java.awt.Font", "Arial", $fontClass->PLAIN, 40);
    $image = new Java("java.awt.image.BufferedImage", 100, 100, $imageClass->TYPE_INT_ARGB);
    $graphics = $image->createGraphics();
    try {
        $fontContext = $graphics->getFontRenderContext();
        $glyphVector = $font->createGlyphVector($fontContext, "Text in shape");
        $textBounds = $glyphVector->getVisualBounds();
        $baseline = -java_values($textBounds->getY()) + 10;
        $graphicsPath = $glyphVector->getOutline(20.0, $baseline);
    } finally {
        $graphics->dispose();
    }

    $textPath = new GeometryPath();
    $pathIterator = $graphicsPath->getPathIterator(null);
    $iteratorClass = java("java.awt.geom.PathIterator");
    $arrayClass = java("java.lang.reflect.Array");
    $floatClass = java("java.lang.Float");
    $coordinates = $arrayClass->newInstance($floatClass->TYPE, 6);

    while (!java_values($pathIterator->isDone())) {
        $segmentType = java_values($pathIterator->currentSegment($coordinates));
        $points = java_values($coordinates);
        switch ($segmentType) {
            case java_values($iteratorClass->SEG_MOVETO):
                $textPath->moveTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_LINETO):
                $textPath->lineTo($points[0], $points[1]);
                break;
            case java_values($iteratorClass->SEG_QUADTO):
                $textPath->quadraticBezierTo($points[0], $points[1], $points[2], $points[3]);
                break;
            case java_values($iteratorClass->SEG_CUBICTO):
                $textPath->cubicBezierTo($points[0], $points[1], $points[2], $points[3], $points[4], $points[5]);
                break;
            case java_values($iteratorClass->SEG_CLOSE):
                $textPath->closeFigure();
                break;
        }
        $pathIterator->next();
    }
    $textPath->setFillMode(PathFillModeType::Normal);
    $shape->setGeometryPaths([$originalPath, $textPath]);
} finally {
    $presentation->dispose();
}
```
![example5_image](custom_shape_5.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**ज्यामिति प्रतिस्थापित करने के बाद भराव और रूपरेखा क्या होंगी?**

शैली आकार के साथ रहती है; केवल कंटूर बदलता है। भराव और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाती हैं।

**कस्टम आकार को उसकी ज्यामिति के साथ सही रूप से कैसे घुमाएँ?**

आकार की [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) विधि का उपयोग करें; ज्यामिति आकार के साथ घुमती है क्योंकि यह आकार के अपने निर्देशांक प्रणाली से जुड़ी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदलकर परिणाम को \"लॉक\" कर सकता हूँ?**

हाँ। आवश्यक [slide](/slides/hi/php-java/convert-powerpoint-to-png/) क्षेत्र या [shape](/slides/hi/php-java/create-shape-thumbnails/) को रास्टर स्वरूप में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के काम को सरल बनाता है।