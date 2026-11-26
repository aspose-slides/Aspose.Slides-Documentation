---
title: PHP में प्रस्तुतिकरण आकारों को अनुकूलित करें
linktitle: कस्टम आकार
type: docs
weight: 20
url: /hi/php-java/custom-shape/
keywords: 
- कस्टम आकार
- आकार जोड़ें
- आकार बनाएँ
- आकार बदलें
- आकार ज्यामिति
- ज्यामिति पथ
- पथ बिंदु
- संपादन बिंदु
- बिंदु जोड़ें
- बिंदु हटाएँ
- संपादन संचालन
- घुमावदार कोना
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Java के माध्यम से PHP के लिए Aspose.Slides के साथ PowerPoint प्रस्तुतियों में आकार बनाएँ और अनुकूलित करें: ज्यामिति पथ, घुमावदार कोने, संयुक्त आकार।"
---
## **अवलोकन**

यह लेख Aspose.Slides में प्रस्तुतिकरण आकारों को संपादन बिंदुओं और ज्यामिति पथों के माध्यम से आकार ज्यामिति को संपादित करके कस्टमाइज़ करने का तरीका समझाता है। यह दर्शाता है कि मौज़दा आकारों को संशोधित करने, मूलभूत पथ संपादन संचालन करने, बिंदु जोड़ने या हटाने, और अद्यतन ज्यामिति को फिर से आकार पर लागू करने के लिए [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) के साथ कैसे काम किया जाए। यह भी प्रदर्शित करता है कि कस्टम और मिश्रित आकार कैसे बनाएँ, घुमावदार किनारों वाले आकार बनाएँ, यह निर्धारित करें कि आकार ज्यामिति बंद है या नहीं, आकार तत्वों का निरीक्षण करें, और Java AWT टेक्स्ट आउटलाइन को ज्यामिति पथों में परिवर्तित करें।

## **संपादन बिंदुओं का उपयोग करके आकार बदलें**

PowerPoint में, आप **संपादन बिंदुओं** का उपयोग करके एक वर्ग को बदल सकते हैं:

* कोने को अंदर या बाहर ले जाएँ।
* किसी बिंदु पर घुमाव को समायोजित करें।
* नए बिंदु जोड़ें।

संपादन बिंदु आपको आकार की रूपरेखा को संशोधित करने या मौज़दा आकार को एक नए आकार के आधार के रूप में उपयोग करने की अनुमति देते हैं।

## **आकार संपादन सुझाव**

![overview_image](custom_shape_0.png)

PowerPoint आकारों को संपादित करते समय इन अवधारणाओं को याद रखें:

* एक आकार (या उसका पथ) बंद या खुला हो सकता है।
* एक आकार की पथ एंकर बिंदुओं से बनी होती है जो सेगमेंट द्वारा जुड़े होते हैं।
* एक सेगमेंट सीधा या घुमावदार हो सकता है। एंकर बिंदु और नियंत्रण हैंडल उसका आकार निर्धारित करते हैं।
* एंकर बिंदु कोने बिंदु, सीधा बिंदु, या स्मूद बिंदु के रूप में होते हैं:
  * कोने बिंदु पर, जुड़े सेगमेंट एक कोण पर मिलते हैं।
  * स्मूद बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं और एंकर बिंदु से समान दूरी पर होते हैं।
  * सीधा बिंदु पर, दो नियंत्रण हैंडल संरेखित होते हैं लेकिन एंकर बिंदु से उनकी दूरी अलग‑अलग हो सकती है।
* एंकर बिंदुओं को ले जाना या उनके हैंडल को समायोजित करना आकार की रूपरेखा बदलता है।

PowerPoint आकारों को संपादन बिंदुओं के माध्यम से संपादित करने के लिए **Aspose.Slides** [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) क्लास प्रदान करता है।

* एक [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) उदाहरण [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) वस्तु का ज्यामिति पथ दर्शाता है।
* [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) इंस्टेंस से [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) प्राप्त करने के लिए आप [GeometryShape::getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) मेथड का उपयोग कर सकते हैं।
* एक आकार के लिए [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) सेट करने हेतु आप ये मेथड उपयोग कर सकते हैं: एकल पथ वाले आकारों के लिए [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) और अनेक पथ वाले आकारों के लिए [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths)।
* सेगमेंट जोड़ने के लिए आप [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) के तहत उपलब्ध मेथड्स का उपयोग कर सकते हैं।
* [GeometryPath::setStroke](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setStroke) और [GeometryPath::setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) मेथड्स के माध्यम से आप एक ज्यामिति पथ की उपस्थिति सेट कर सकते हैं।
* [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) मेथड के द्वारा आप एक [GeometryShape](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/) का ज्यामिति पथ पाथ सेगमेंट्स की एरे के रूप में प्राप्त कर सकते हैं।
* अतिरिक्त आकार ज्यामिति अनुकूलन विकल्पों तक पहुँचने के लिए आप एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) को उसके [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) के माध्यम से पढ़ सकते हैं और उन सेगमेंट्स को एक [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) पर पुनः चलाकर लागू कर सकते हैं।

## **सरल संपादन संचालन**

निम्नलिखित मेथड्स का उपयोग करके आप एक ज्यामिति पथ को संपादित कर सकते हैं। ऐसे ओवरलोड जो इंडेक्स स्वीकार करते हैं, पाथ के सेगमेंट एरे में उस शून्य‑आधारित स्थिति पर एक सेगमेंट डालते हैं।

| ऑपरेशन | विधि |
| --- | --- |
| सीधी रेखा जोड़ें या सम्मिलित करें। | [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) |
| दो नियंत्रण बिंदुओं और एक अंत बिंदु वाले क्यूबिक बीज़ियर वक्र को जोड़ें या सम्मिलित करें। | [GeometryPath::cubicBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#cubicBezierTo) |
| एक नियंत्रण बिंदु और एक अंत बिंदु वाले क्वाड्रेटिक बीज़ियर वक्र को जोड़ें या सम्मिलित करें। | [GeometryPath::quadraticBezierTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#quadraticBezierTo) |
| निर्दिष्ट आयाम और डिग्री में कोणों के साथ दीर्घवृत्तीय चाप जोड़ें। | [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) |
| अंत बिंदु को प्रारम्भ बिंदु से जोड़ कर वर्तमान आकृति को बंद करें। | [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) |
| आकृति का प्रारम्भ बिंदु सेट करें। | [GeometryPath::moveTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#moveTo) |
| शून्य‑आधारित अनुक्रमणिका पर सेगमेंट हटाएँ। | [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) |

## **आकार में कस्टम बिंदु जोड़ें**

यह उदाहरण दो बिंदुओं को एक आयताकार आकार में [GeometryPath::lineTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#lineTo) का उपयोग करके डालता है और संपादित पथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू करता है। निर्देशांक आकार के स्थानीय होते हैं: दोनों नए बिंदु उसके केंद्र में, बाएँ से 100 पॉइंट और ऊपर से 50 पॉइंट पर स्थित हैं। सेगमेंट इंडेक्स 1 और 4 उन्हें क्रमशः ऊपरी और निचली किनारों पर रखता है, जिससे वह किनारे अंदर की ओर खिंचते हैं।

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

यह उदाहरण एक हृदय‑आकार की रूपरेखा को [GeometryPath::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#removeAt) द्वारा शून्य‑आधारित इंडेक्स 2 पर सेगमेंट हटाकर बदलता है। संशोधित पथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू करने से आकार की कंटूर अपडेट हो जाता है।

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

यह उदाहरण [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) का उपयोग करके एक पाँच‑बिंदु वाला तारा बनाता है। 100 और 50 पॉइंट के वैकल्पिक बाहरी तथा आंतरिक त्रिज्याएँ टिप्स और अंतरों को निर्धारित करती हैं; 72‑डिग्री का कदम पाँच टिप्स को समान रूप से वितरित करता है। पथ को [GeometryPath::closeFigure](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#closeFigure) द्वारा बंद किया गया और एक आयताकार आकार पर [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू करके उसकी रूपरेखा को प्रतिस्थापित किया गया।

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

## **समग्र कस्टम आकार बनाएँ**

यह उदाहरण एक आकार के ऊपरी और निचले तिहाई के लिए दो बंद [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) वस्तुएँ परिभाषित करता है। दोनों पथों को [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) से लागू करने से मध्य तिहाई में अंतर वाला एकल संयोजन आकार बनता है।

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

## **घुमावदार कोनों के साथ कस्टम आकार बनाएँ**

यह उदाहरण सीधी सेगमेंट को [GeometryPath::arcTo](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#arcTo) के साथ मिलाकर एक ऐसा आकार बनाता है जिसमें कोने अंदर की ओर घुमावदार होते हैं। प्रत्येक कोने का आकार आर्क की चौड़ाई और ऊँचाई को पॉइंट में निर्धारित करता है, और -90‑डिग्री स्वेप एक घड़ी की दिशा के विपरीत चौथाई दीर्घवृत्त बनाता है। पूर्ण पथ को [GeometryShape::setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) से लागू किया गया और प्रस्तुति को PPTX प्रारूप में सहेजा गया।

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

## **जाँचें कि आकार ज्यामिति बंद है या नहीं**

निम्न सहायक प्रत्येक गैर‑खाली ज्यामिति पथ के अंत में एक बंद सेगमेंट है या नहीं, यह जाँचता है। यह [GeometryPath::getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) पढ़ता है और अंतिम सेगमेंट के [PathSegment::getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) की तुलना [PathCommandType::Close](https://reference.aspose.com/slides/php-java/aspose.slides/pathcommandtype/) से करता है। यदि कोई गैर‑खाली पथ नहीं है तो यह false लौटाता है। यह प्रत्येक पथ के अंतिम कमांड की जाँच करता है; यह पथ के भीतर प्रत्येक उप‑आकृति को निरीक्षण नहीं करता। उदाहरण आयत के लिए `true` प्रिंट करता है।

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

## **ज्यामिति पथ आदेशों का निरीक्षण करें**

[contour.pptx](contour.pptx) डाउनलोड करें और उसे एप्लिकेशन की कार्य निर्देशिका में रखें। पहली स्लाइड पर पहला आकार एक सीधी शीर्ष किनारा, एक क्यूबिक बीज़ियर वक्र, और एक सीधा बंद किनारा रखता है। आकार के पथ पढ़ने के लिए [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) और प्रत्येक पथ के सेगमेंट्स को ड्राइंग क्रम में पढ़ने के लिए [getPathData](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#getPathData) का उपयोग करें। प्रत्येक सेगमेंट के लिए, [getPathCommand](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getPathCommand) कमांड को पहचानता है और [getSegmentData](https://reference.aspose.com/slides/php-java/aspose.slides/pathsegment/#getSegmentData) द्वारा लौटाए गए मानों की व्याख्या तय करता है।

```php
use aspose\slides\PathCommandType;
use aspose\slides\Presentation;

$presentation = new Presentation("contour.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    foreach ($shape->getGeometryPaths() as $pathIndex => $path) {
        foreach ($path->getPathData() as $segmentIndex => $segment) {
            $command = java_values($segment->getPathCommand());
            $data = java_values($segment->getSegmentData());
            switch ($command) {
                case PathCommandType::MoveTo:
                case PathCommandType::LineTo:
                    $name = $command === PathCommandType::MoveTo ? "MoveTo" : "LineTo";
                    $detail = sprintf("destination=(%s, %s)", ...$data);
                    break;
                case PathCommandType::CubicBezierTo:
                    $name = "CubicBezierTo";
                    $detail = sprintf("control1=(%s, %s) control2=(%s, %s) end=(%s, %s)", ...$data);
                    break;
                case PathCommandType::Close:
                    $name = "Close";
                    $detail = "no coordinates";
                    break;
                default:
                    $name = "Command " . $command;
                    $detail = "raw=" . json_encode($data);
            }
            printf("Path %d, segment %d: %s %s\n", $pathIndex, $segmentIndex, $name, $detail);
        }
    }
} finally {
    $presentation->dispose();
}
```

आकार स्लाइड पर (200, 100) पॉइंट पर स्थित है। रिपोर्ट किए गए निर्देशांक आकार के स्थानीय होते हैं, जहाँ (0, 0) ऊपरी‑बाएँ कोना है, x दाईं ओर बढ़ता है, और y नीचे की ओर बढ़ता है। बंद सेगमेंट अतिरिक्त निर्देशांक के बिना शुरूआती बिंदु पर लौटता है।

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![PowerPoint shape with a straight top edge, a curved edge from the upper right to the lower left, and a straight left edge](contour.png)

## **आकार तत्व निकालें और निरीक्षण करें**

[GeometryShape::createShapeElements](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#createShapeElements) का उपयोग करके आप एक मौजूद आकार को पथ बिंदुओं और बिंदु प्रकारों वाले तत्वों के रूप में निरीक्षण कर सकते हैं। प्रत्येक लौटाए गये [ShapeElement](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/) को [getPathPoints](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathPoints) और [getPathTypes](https://reference.aspose.com/slides/php-java/aspose.slides/shapeelement/#getPathTypes) मेथड्स के माध्यम से बिंदु और प्रकार एरे प्राप्त करने हेतु उपयोग किया जाता है। यह प्रतिनिधित्व कंटूर विश्लेषण या कस्टम ड्रॉइंग टूल्स को ज्यामिति पास करने के लिए उपयोगी है।

उदाहरण input.pptx खोलता है, पहली स्लाइड पर सीधे पहले ज्यामिति आकार को खोजता है, और उसके पथ सेगमेंट्स को प्रिंट करता है। दोनों सीधी और घुमावदार सेगमेंट वाले आकार वाली प्रस्तुति का उपयोग करें ताकि दोनों प्रकार के आउटपुट देख सकें। यह ग्रुप के भीतर खोज नहीं करता।

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
                $pointType = $types[$i] & 0x07; // सेगमेंट प्रकार रखें, फ्लैग को बाहर रखते हुए.
                switch ($pointType) {
                    case 0:
                        echo "Start figure at " . $points[$i] . PHP_EOL;
                        break;
                    case 1:
                        echo "Line to " . $points[$i] . PHP_EOL;
                        break;
                    case 3:
                        echo "Cubic Bezier: controls " . $points[$i] . ", " . $points[$i + 1] . "; end " . $points[$i + 2] . PHP_EOL;
                        $i += 2; // दोनों नियंत्रण बिंदुओं और अंत बिंदु को उपभोग करें.
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

एरे इंडेक्स द्वारा मेल खाते हैं: `$points[$i]` एक बिंदु है और `$types[$i]` उसकी भूमिका का वर्णन करता है। प्रकार `0` एक आकृति शुरू करता है, और प्रकार `1` पिछले बिंदु से वर्तमान बिंदु तक एक रेखा खींचता है। क्यूबिक बीज़ियर सेगमेंट पिछले अंत बिंदु से शुरू होता है और लगातार तीन प्रकार‑`3` प्रविष्टियों का उपयोग करता है: दो नियंत्रण बिंदु और उसके बाद नया अंत बिंदु। लूप इन तीन प्रविष्टियों को साथ में प्रयोग करता है और बंद होने के लिए अंत बिंदु की जाँच करता है।

बिंदु प्रकारों में फ्लैग भी होते हैं। सेगमेंट प्रकार की पहचान के लिये `0x07` से मास्क करें और बंद उप‑पथ का पता लगाने हेतु `0x80` को अलग‑अलग परीक्षण करें। उदाहरण के लिए, `129` (`0x81`) का मतलब एक रेखा अंत बिंदु है जो उप‑पथ को बंद करता है, तथा `131` (`0x83`) का मतलब एक बीज़ियर अंत बिंदु है जो उसे बंद करता है। PHP/Java Bridge बाइट एरे को बाइनरी स्ट्रिंग के रूप में लौटाता है; इसे `"C*"` के साथ अनपैक करने से अनसाइन्ड बाइट मान प्राप्त होते हैं। मास्किंग इरादे वाले बिट मानों को संरक्षित रखती है। केवल `1` या `3` से कच्चे मान की तुलना करने से ये मामलों का पता नहीं चल पाएगा। अन्य फ्लैग जैसे डैश (`0x10`) और मार्कर (`0x20`) बेस सेगमेंट प्रकार को नहीं बदलते।

**निर्देशांक और रूपांतरण।** बिंदु पॉइंट (1/72 इंच) में मापे जाते हैं, X दाईं ओर और Y नीचे की ओर बढ़ता है। एक अन‑ग्रुप्ड आकार के लिये, निकाले गये निर्देशांक पहले से ही [getX](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getX) और [getY](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getY) द्वारा लौटाई गई स्थिति को शामिल करते हैं और उसकी वर्तमान चौड़ाई‑ऊँचाई को दर्शाते हैं। उदाहरण के लिये, `(100, 200)` पर बिना घुमाए आयत जिसका आकार `120 × 80` है, उसकी कंटूर सीमाएँ `(100, 200)`–`(220, 280)` होंगी। आकार की स्थिति को दोबारा न जोड़ें। उसके X और Y को घटाकर अन‑घुमाए फ्रेम के सापेक्ष निर्देशांक प्राप्त करें।

निकाले गये बिंदु आकार के घुमाव, जो [getRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getRotation) द्वारा लौटाया जाता है, या क्षैतिज व वैर्टिकल फ्लिप को लागू नहीं करते। प्रदर्शित कंटूर को पुनः बनाने हेतु इन रूपांतरणों को आकार के केंद्र के चारों ओर लागू करें। ग्रुपेड आकारों के लिये, समूह निर्देशांक मानचित्रण और रूपांतरणों का भी ध्यान रखें; यह मान कर न चलें कि निकाले गये बिंदु अंतिम रेंडर की गई स्लाइड निर्देशांक हैं या यदि यह पहले ही चाइल्ड फ्रेम में परिलक्षित है तो अनुवाद या स्केल दो बार लागू न करें।

**निरीक्षण बनाम संपादन।** निकाली गयी एरे कंटूर का वर्णन करती हैं; उन्हें बदलने से मूल आकार अपडेट नहीं होता। इस दृष्टिकोण को तब चुनें जब आपका विश्लेषण या ड्रॉइंग कोड बिंदु/प्रकार एरे की आवश्यकता रखता हो। जब आपको आकार के स्थानीय निर्देशांक प्रणाली में ज्यामिति कमांड चाहिए हों या उसकी ज्यामिति को संपादित करना हो, तो [getGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#getGeometryPaths) का उपयोग करें। संपादित पथों को [setGeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPath) या [setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) के माध्यम से लागू करें।

## **जावा AWT Shape को GeometryPath में बदलें**

यह उदाहरण एक आयताकार रूपरेखा को टेक्स्ट के साथ मिलाकर उसे ज्यामिति में परिवर्तित करता है। रूपरेखा की [setFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/#setFillMode) मेथड उसकी भराव को अक्षम करती है। एक [GlyphVector](https://docs.oracle.com/javase/8/docs/api/java/awt/font/GlyphVector.html) एक [java.awt.Shape](https://docs.oracle.com/javase/8/docs/api/java/awt/Shape.html) में टेक्स्ट रूपरेखा बनाता है। उसका [PathIterator](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/PathIterator.html) मूव, लाइन, क्वाड्रेटिक, क्यूबिक और क्लोज़िंग सेगमेंट सप्लाई करता है, जिसे उदाहरण [GeometryPath](https://reference.aspose.com/slides/php-java/aspose.slides/geometrypath/) पर पुनः चलाता है।

उदाहरण एक Java फ़्लोट एरे का उपयोग करता है ताकि PHP/Java Bridge द्वारा इटरटर द्वारा लिखे गए निर्देशांक बरकरार रहें। टेक्स्ट 40‑पॉइंट Arial फ़ॉन्ट का उपयोग करता है। रूपरेखा को क्षैतिज रूप से 20 पॉइंट ऑफ़सेट किया गया है और दृश्य शीर्ष को आकार के शीर्ष किनारे से 10 पॉइंट नीचे स्थित किया गया है। टेक्स्ट पथ भरा हुआ है, जबकि मूल आयत रूपरेखा के रूप में बनी रहती है। दोनों पथों को [GeometryShape::setGeometryPaths](https://reference.aspose.com/slides/php-java/aspose.slides/geometryshape/#setGeometryPaths) से लागू करने से एक ही आकार बनता है जिसमें आयत और टेक्स्ट दोनों होते हैं।

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

**ज्यामिति को बदलने के बाद फ़िल और रूपरेखा के साथ क्या होगा?**

स्टाइल आकार के साथ बना रहता है; केवल कंटूर बदलता है। फ़िल और रूपरेखा स्वचालित रूप से नई ज्यामिति पर लागू हो जाती है।

**मैं कस्टम आकार को उसकी ज्यामिति के साथ सही तरीके से कैसे घुमा सकता हूँ?**

आकार की [setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) मेथड का उपयोग करें; ज्यामिति आकार के साथ घूमेंगी क्योंकि वह आकार के अपने निर्देशांक प्रणाली से जुड़ी होती है।

**क्या मैं कस्टम आकार को एक छवि में बदल सकता हूँ ताकि परिणाम को “लॉक इन” किया जा सके?**

हाँ। आवश्यक [slide](/slides/hi/php-java/convert-powerpoint-to-png/) क्षेत्र या स्वयं [shape](/slides/hi/php-java/create-shape-thumbnails/) को रास्टर फ़ॉर्मेट में निर्यात करें; यह जटिल ज्यामितियों के साथ आगे के काम को सरल बनाता है।