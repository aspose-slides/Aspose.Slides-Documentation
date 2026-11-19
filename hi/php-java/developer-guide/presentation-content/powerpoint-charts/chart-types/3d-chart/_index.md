---
title: PHP का उपयोग करके प्रस्तुतियों में 3D चार्ट को अनुकूलित करें
linktitle: 3D चार्ट
type: docs
url: /hi/php-java/3d-chart/
keywords:
- 3D चार्ट
- घुमाव
- गहराई
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint प्रस्तुतियों में 3D चार्ट बनाएं। घुमाव, ऊँचाई अनुपात, चार्ट गहराई और श्रृंखलाओं के बीच की दूरी को PHP उदाहरणों के साथ समायोजित करें।"
---
## **सारांश**

Aspose.Slides for PHP via Java आपको 3D चार्ट के दृश्य को [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) मेथड के माध्यम से अनुकूलित करने की अनुमति देता है। यह लेख घुमाव, ऊँचाई अनुपात, गहराई, निरपेक्ष अक्ष, और श्रृंखला के बीच की दूरी को समायोजित करने, तथा प्रस्तुति को PPTX स्वरूप में सहेजने का प्रदर्शन करता है।

## **3D चार्ट की घुमाव और गहराई सेट करें**

नीचे दिया गया उदाहरण एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाता है और [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) का उपयोग करके उसकी पहली स्लाइड में एक स्टैक्ड 3D कॉलम चार्ट जोड़ता है। यह डिफ़ॉल्ट श्रृंखला और श्रेणियों को दो श्रृंखलाओं से बदल देता है, प्रत्येक में तीन मान होते हैं। वर्कशीट अनुक्रमांक `0` चार्ट की पहली डेटा वर्कशीट को पहचानता है; पंक्ति `0` में श्रृंखला नाम होते हैं, और स्तम्भ `0` में श्रेणी लेबल होते हैं।

[setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) और [setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) मेथड क्रमशः चार्ट की घुमाव को 40 और 270 डिग्री सेट करते हैं। [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) उसकी गहराई को उसकी चौड़ाई के 150 % पर सेट करता है, जबकि [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) पर्स्पेक्टिव के बजाय निरपेक्ष अक्ष सक्षम करता है। परिणामी प्रस्तुति इन 3D दृश्य सेटिंग्स के साथ चार्ट को समाहित करती है।

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

## **3D चार्ट की ऊँचाई अनुपात को समायोजित करें**

[Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) का उपयोग करके 3D चार्ट की ऊँचाई को उसकी चौड़ाई के प्रतिशत के रूप में सेट किया जाता है। यह स्लाइड पर चार्ट ऑब्जेक्ट को आकार बदलें बिना 3D दृश्य के अनुपात को बदलता है।

निम्न उदाहरण एक डिफ़ॉल्ट डेटा वाले [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) चार्ट (तीन श्रृंखला और चार श्रेणियां) बनाता है। यह 50 %, 100 % और 200 % ऊँचाई अनुपात के साथ तीन प्रस्तुतियों को सहेजता है। चार्ट की स्थिति, चौड़ाई और ऊँचाई स्थिर रहती है। डेटा, घुमाव, गहराई, श्रृंखला अंतराल, और फ़ॉर्मेटिंग सभी तीन फ़ाइलों में समान हैं; केवल ऊँचाई प्रतिशत बदलता है।

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

निम्न चित्र समान ऊँचाई सेटिंग्स को समान .NET उदाहरण में दर्शाते हैं और Microsoft PowerPoint द्वारा निर्यात किए गए हैं। कम प्रतिशत एक सपाट दृश्य बनाता है, जबकि बड़ा प्रतिशत उसी चार्ट ऑब्जेक्ट के भीतर एक ऊँचा दृश्य प्रदान करता है। PowerPoint दृश्य के अनुरूप अक्ष टिक अंतराल और लेबल प्लेसमेंट को भी समायोजित कर सकता है।

| ऊँचाई: 50% | ऊँचाई: 100% | ऊँचाई: 200% |
| --- | --- | --- |
| ![अपनी चौड़ाई के 50 प्रतिशत पर सेट की गई 3D कॉलम चार्ट](height_percent_50.png) | ![अपनी चौड़ाई के 100 प्रतिशत पर सेट की गई 3D कॉलम चार्ट](height_percent_100.png) | ![अपनी चौड़ाई के 200 प्रतिशत पर सेट की गई 3D कॉलम चार्ट](height_percent_200.png) |

ये विधियाँ चार्ट के विभिन्न पहलुओं को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | 3D दृश्य की ऊँचाई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | स्लाइड पर चार्ट ऑब्जेक्ट की ऊँचाई, पॉइंट्स में। |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | 3D दृश्य की गहराई, उसकी चौड़ाई के प्रतिशत के रूप में। |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत में। |

ऊँचाई सेटिंग 3D कॉलम और बार चार्ट, जिसमें सिलिंडर, कोन और पिरामिड रूपांतर शामिल हैं, तथा 3D लाइन, एरिया, पाई और सरफ़ेस चार्ट पर प्रभाव डालती है। ऊपर दिया गया तुलनात्मक उदाहरण सत्यापित `Column3D` प्रकार का उपयोग करता है। यह सेटिंग 2D `ClusteredColumn` चार्ट या `BubbleWith3D` चार्ट की उपस्थिति को नहीं बदलती; ये नाम [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) क्लास के सदस्य हैं। अन्य चार्ट उपस्थिति सेटिंग्स के लिए, देखें [Chart Formatting](/slides/hi/php-java/chart-formatting/)।

## **श्रृंखलाओं के बीच अंतराल समायोजित करें**

[ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) का उपयोग करके 3D चार्ट के गहराई अक्ष पर डेटा श्रृंखलाओं के बीच की दूरी को मार्कर चौड़ाई के प्रतिशत में नियंत्रित किया जाता है। **0 से 500** (समावेशी) मान उपयोग करें: `0` अंतराल को हटाता है, जबकि बड़े मान स्पेसिंग बढ़ाते हैं। स्थिर चार्ट गहराई के साथ, अंतराल बढ़ाने से मार्कर गहराई अक्ष पर पतले हो जाते हैं।

समूह तक पहुंचें [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) के माध्यम से। सेटिंग उस समूह की प्रत्येक श्रृंखला पर लागू होती है, न कि केवल वह श्रृंखला जिस पर इसे एक्सेस किया गया हो। [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) गहराई अंतराल को लौटाता है और मूल समूह की सेटिंग को दर्शाता है।

यह सेटिंग 3D कॉलम और बार चार्ट, जिसमें उनके सिलिंडर, कोन और पिरामिड रूपांतर, तथा 3D लाइन और एरिया चार्ट शामिल हैं, पर प्रभाव डालती है। उपस्थिति इस पर निर्भर करती है कि श्रृंखलाएँ गहराई में व्यवस्थित हैं, क्लस्टर की गई हैं या स्टैक्ड हैं। अलग-अलग श्रृंखलाओं के बीच अंतराल की स्पष्ट तुलना के लिए, [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) क्लास से `ChartType::Column3D` का उपयोग करें।

ये विधियाँ विभिन्न पहलुओं को नियंत्रित करती हैं:

| विधि | प्रभाव |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | गहराई अक्ष के साथ श्रृंखलाओं के बीच की दूरी, मार्कर चौड़ाई के प्रतिशत में। |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | पड़ोसी बार या कॉलम क्लस्टर के बीच की दूरी, बार या कॉलम चौड़ाई के प्रतिशत में। |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | चार्ट की कुल गहराई, चार्ट चौड़ाई के प्रतिशत में। |

निम्न स्वतंत्र उदाहरण डिफ़ॉल्ट चार्ट डेटा (तीन श्रृंखला और चार श्रेणियां) का उपयोग करता है। यह दो प्रस्तुतियों को सहेजता है जिनमें डेटा, घुमाव, अंतराल चौड़ाई और चार्ट गहराई समान हैं; केवल गहराई अंतराल परिवर्तनशील है।

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

निम्न चित्र समान गहराई अंतराल सेटिंग्स को समान .NET उदाहरण में दर्शाते हैं और Microsoft PowerPoint द्वारा निर्यात किए गए हैं।

| गहराई अंतराल: 0% | गहराई अंतराल: 500% |
| --- | --- |
| ![गहराई अक्ष के साथ श्रृंखलाओं के बीच कोई अंतराल नहीं वाली 3D कॉलम चार्ट](gap_depth_0.png) | ![गहराई अक्ष के साथ श्रृंखलाओं के बीच 500 % अंतराल वाली 3D कॉलम चार्ट](gap_depth_500.png) |

## **3D श्रृंखला प्रकार और बार आकार बदलें**

क्लस्टर्ड सिलिंडर चार्ट में पहली श्रृंखला का बार आकार सिलिंडर से शुरू होता है। उदाहरण [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) और [ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) द्वारा लौटाए गए पूर्णांक मानों को प्रत्येक परिवर्तन से पहले और बाद में प्रिंट करता है। तालिका संबंधित स्थिरांक नाम देती है।

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

| पहली श्रृंखला को बदलें | श्रृंखला प्रकार | बार आकार |
| --- | --- | --- |
| चार्ट बनाएं | `ClusteredCylinder` | `Cylinder` |
| श्रृंखला प्रकार को `ClusteredCone` सेट करें | `ClusteredCone` | `Cone` |
| बार आकार को `Box` सेट करें | `ClusteredColumn3D` | `Box` |

`Box` आकार सेट करने से श्रृंखला प्रकार भी `ClusteredColumn3D` हो जाता है। यदि आपका कोड श्रृंखला प्रकार पर निर्भर करता है, तो आकार बदलने के बाद [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) को कॉल करें। असाइनमेंट से पहले कैश किया गया मान अभी भी `ClusteredCone` शाखा का चयन करेगा।

![बाएँ से दाएँ पहला श्रृंखला सिलिंडर, कोन और आयताकार कॉलम दिखाता PowerPoint तुलना](series-shapes.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D रूपांतरों का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D और 100 % Stacked Column 3D शामिल हैं, साथ ही [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध संबंधित 3D प्रकार। सटीक और नवीनतम सूची के लिए, अपने स्थापित संस्करण के API रेफरेंस में [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) का उपयोग करके चार्ट को छवि में निर्यात कर सकते हैं या [संपूर्ण स्लाइड को निर्यात करें](/slides/hi/php-java/convert-powerpoint-to-png/) ताकि PNG या JPEG जैसे स्वरूप मिलें। यह तब उपयोगी होता है जब आपको रास्टर प्रीव्यू चाहिए या चार्ट को दस्तावेज़, डैशबोर्ड या वेब पेज में एम्बेड करना है, बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाने और रेंडर करने का प्रदर्शन कैसा है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणाम के लिए 3D प्रभावों को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों में भारी बनावट से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा बिंदुओं की संख्या सीमित रखें, और आउटपुट (रिज़ॉल्यूशन और आयाम) को लक्षित डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उपयुक्त आकार में रेंडर करें।