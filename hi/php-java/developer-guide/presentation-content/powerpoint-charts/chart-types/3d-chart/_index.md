---
title: PHP का उपयोग करके प्रस्तुतियों में 3D चार्ट कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/php-java/3d-chart/
keywords:
- 3D चार्ट
- घूर्णन
- गहराई
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। PHP उदाहरणों के साथ घूर्णन, ऊँचाई अनुपात, चार्ट गहराई और श्रृंखलाओं के बीच की दूरी समायोजित करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java आपको 3D चार्ट का दृश्य [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) मेथड के माध्यम से अनुकूलित करने देता है। यह लेख दिखाता है कि कैसे घूर्णन, ऊँचाई अनुपात, गहराई, समकोण अक्ष, और श्रृंखलाओं के बीच की दूरी को समायोजित किया जाए, फिर प्रस्तुति को PPTX प्रारूप में सहेजा जाए।

## **एक 3D चार्ट का घूर्णन और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाता है और पहले स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ने के लिए [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) का उपयोग करता है। यह डिफ़ॉल्ट श्रृंखलाओं और श्रेणियों को दो श्रृंखलाओं से बदल देता है, जिनमें प्रत्येक में तीन मान होते हैं। वर्कशीट सूचकांक `0` चार्ट की पहली डेटा वर्कशीट को दर्शाता है; पंक्ति `0` में श्रृंखला के नाम होते हैं, और कॉलम `0` में श्रेणी लेबल होते हैं।

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) और [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) मेथड क्रमशः चार्ट का घूर्णन 40 और 270 डिग्री सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) इसकी गहराई को उसकी चौड़ाई के 150% पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) परिप्रेक्ष्य के बजाय समकोण अक्ष सक्षम करता है। परिणामी प्रस्तुति इन 3D दृश्य सेटिंग्स के साथ भरपूर चार्ट शामिल करती है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **3D चार्ट सतह पर तस्वीर भराव लागू करें**

आप 3D चार्ट की [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/), और [floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) को स्वतंत्र रूप से भर सकते हैं। सतह के [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) को `Picture` सेट करें और एक छवि असाइन करें। सतह के दोनों [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) और [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) को `Stretch` सेट करके छवि की एक प्रति को पूरी सतह पर फिट करें।

PHP स्क्रिप्ट के बगल में [arrow.png](arrow.png) सहेजें। उदाहरण चार्ट को घुमाता है और ऊर्ध्वाधर अक्ष पर अधिकतम मान बढ़ाता है जिससे स्तंभों के बीच फर्श दिखाई दे। फिर यह स्लाइड को दो बार क्लोन करता है और प्रत्येक स्लाइड पर अलग सतह पर तीर लागू करता है। सभी तीन चार्ट समान डेटा, दृश्य कोण, और पृष्ठभूमि बनाए रखते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Microsoft PowerPoint तीन स्लाइड इस प्रकार दिखाता है।

| साइड वॉल | बैक वॉल | फ़्लोर |
| --- | --- | --- |
| ![चार्ट की साइड वॉल में इशारा करता तीर](side-wall.png) | ![बैक वॉल के पार दाईं ओर इशारा करता तीर](back-wall.png) | ![स्तंभों के बीच फ़्लोर पर दाईं ओर इशारा करता तीर](floor.png) |

## **3D चार्ट की ऊँचाई अनुपात समायोजित करें**

3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट करने के लिए [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) का उपयोग करें। इससे स्लाइड पर चार्ट ऑब्जेक्ट का आकार बदले बिना 3D दृश्य के अनुपात बदलते हैं।

निम्न उदाहरण एक [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) चार्ट डिफ़ॉल्ट डेटा के साथ बनाता है: तीन श्रृंखलाएँ और चार श्रेणियाँ। यह 50%, 100% और 200% ऊँचाई अनुपात के साथ तीन प्रस्तुतियाँ सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घूर्णन, गहराई, श्रृंखला की दूरी, और फ़ॉर्मेटिंग सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

निम्न छवियाँ समान ऊँचाई सेटिंग को समकक्ष .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं। छोटा प्रतिशत एक अधिक समतल दृश्य देता है, जबकि बड़ा प्रतिशत समान चार्ट ऑब्जेक्ट में अधिक ऊँचा दृश्य बनाता है। PowerPoint दृश्य के अनुरूप अक्ष टिक अंतराल और लेबल की स्थिति को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 50% पर सेट है](height_percent_50.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 100% पर सेट है](height_percent_100.png) | ![3D कॉलम चार्ट जिसकी ऊँचाई उसकी चौड़ाई के 200% पर सेट है](height_percent_200.png) |

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D दृश्य की ऊँचाई को उसकी चौड़ाई के प्रतिशत में। |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D दृश्य की गहराई को उसकी चौड़ाई के प्रतिशत में। |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | मार्कर की चौड़ाई के प्रतिशत में गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें सिलेंडर, कोन, और पिरामिड वेरिएंट शामिल हैं, साथ ही 3D लाइन, एरिया, पाई और सरफेस चार्ट। ऊपर की तुलना में सत्यापित `Column3D` प्रकार का उपयोग किया गया है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) वर्ग के सदस्य हैं। अन्य चार्ट उपस्थिति सेटिंग्स के लिए, देखें [Chart Formatting](/slides/hi/php-java/chart-formatting/)।

## **श्रृंखलाओं के बीच अंतराल समायोजित करें**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) का उपयोग करके 3D चार्ट की गहराई अक्ष के साथ डेटा श्रृंखलाओं के बीच की दूरी को नियंत्रित किया जाता है, जो मार्कर चौड़ाई के प्रतिशत में व्यक्त होती है। **0 से 500** तक के मान उपयोग करें, शामिल: `0` अंतराल हटाता है, जबकि बड़े मान दूरी बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, अंतराल बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

समूह को [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से एक्सेस करें। यह सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, केवल उस श्रृंखला पर नहीं जो इसका उपयोग करती है। [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) गहराई अंतर को लौटाता है और पैरेंट समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट को प्रभावित करती है, जिसमें उनके सिलेंडर, कोन, और पिरामिड वेरिएंट शामिल हैं, साथ ही 3D लाइन और एरिया चार्ट। उपस्थिति इस बात पर निर्भर करती है कि श्रृंखलाएँ गहराई में, क्लस्टर्ड, या स्टैक्ड हों। अलग-अलग श्रृंखलाओं के बीच अंतराल की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) वर्ग से `ChartType::Column3D` का उपयोग करें।

ये मेथड चार्ट के विभिन्न पहलुओं को नियंत्रित करते हैं:

| मेथड | प्रभाव |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत में। |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | सजाते या कॉलम क्लस्टर्स के बीच की दूरी, बार या कॉलम की चौड़ाई के प्रतिशत में। |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | पूरा चार्ट गहराई, चार्ट की चौड़ाई के प्रतिशत में। |

निम्न स्व-समावेशी उदाहरण डिफ़ॉल्ट चार्ट डेटा का उपयोग करता है, जिसमें तीन श्रृंखलाएँ और चार श्रेणियाँ होती हैं। यह दो प्रस्तुतियाँ समान डेटा, घूर्णन, अंतराल चौड़ाई, और चार्ट गहराई के साथ सहेजता है; केवल अंतराल गहराई बदलती है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

निम्न छवियाँ समान अंतराल गहराई सेटिंग को समकक्ष .NET उदाहरण में दर्शाती हैं और Microsoft PowerPoint का उपयोग करके निर्यात की गई हैं।

| अंतराल गहराई: 0% | अंतराल गहराई: 500% |
| --- | --- |
| ![गहराई अक्ष पर श्रृंखलाओं के बीच कोई अंतराल नहीं वाला 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई अक्ष पर श्रृंखलाओं के बीच 500 प्रतिशत अंतराल वाला 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

क्लस्टर्ड सिलेंडर चार्ट में, पहली श्रृंखला एक सिलेंड्रिकल बार आकार से शुरू होती है। उदाहरण प्रत्येक परिवर्तन से पहले और बाद में [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) और [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) द्वारा लौटाए गए पूर्णांक मान को प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| पहली श्रृंखला में बदलाव | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाएँ | `ClusteredCylinder` | `Cylinder` |
| श्रृंखला प्रकार को `ClusteredCone` सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` में बदल जाता है। यदि आपका कोड श्रृंखला प्रकार पर आधारित है, तो आकार बदलने के बाद [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) को कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा को चुन लेगा।

![PowerPoint तुलना जो पहली श्रृंखला को बाएँ से दायें सिलेंडर, कोन और आयताकार कॉलम के रूप में दिखाती है](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) वर्ग द्वारा प्रकट संबंधित 3D प्रकार। सटीक और नवीनतम सूची के लिए, अपने स्थापित संस्करण के API संदर्भ में [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) के साथ चार्ट को छवि में निर्यात कर सकते हैं या पूरी स्लाइड को [render the entire slide](/slides/hi/php-java/convert-powerpoint-to-png/) द्वारा PNG या JPEG जैसे फ़ॉर्मेट में निर्यात कर सकते हैं। यह तब उपयोगी है जब आपको रास्टर प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेज में PowerPoint की आवश्यकता के बिना एम्बेड करना चाहते हैं।

**बड़े 3D चार्ट बनाने और रेंडर करने में प्रदर्शन कैसा है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वश्रेष्ठ परिणामों के लिए, 3D प्रभाव कम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला के डेटा पॉइंट की संख्या सीमित करें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उपयुक्त आकार (रिज़ॉल्यूशन और आयाम) में आउटपुट रेंडर करें।