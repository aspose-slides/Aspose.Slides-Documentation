---
title: PowerPoint प्रस्तुतियों में PHP द्वारा SmartArt प्रबंधन करें
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके PowerPoint SmartArt को Aspose.Slides for PHP via Java के साथ बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ करता है।"
---
## **अवलोकन**

SmartArt एक PowerPoint आरेख है जो नोड्स, नोड आकारों और एक लेआउट से बनाया गया है। Aspose.Slides for PHP via Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे नोड्स की जाँच कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। नोड आकारों से टेक्स्ट पढ़ने के लिए, [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/) के माध्यम से इटररेट करें, फिर [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) को पढ़ें।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट निर्धारित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है। [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) को पास किया गया स्थान और आकार पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) का उपयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट द्वारा उन्हें दृश्यमान आरेख तत्वों के रूप में न दिखाने पर भी छिपे नोड्स संरचना में मौजूद रह सकते हैं।

नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करने वाले SmartArt ऑब्जेक्ट में एक नोड जोड़ता है और जोड़े गए नोड की छिपी स्थिति की जाँच करता है। यदि नोड छिपा है तो यह एक संदेश प्रिंट करता है और आरेख को सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

उन SmartArt आरेखों के लिए जो संगठन चार्ट लेआउट का उपयोग करते हैं, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) और [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) यह निर्धारित करते हैं कि बच्चा नोड्स को मूल नोड के नीचे कैसे व्यवस्थित किया जाए। उदाहरण के लिए, चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) के आधार पर आप बच्चा नोड्स को बाएँ, दाएँ या दोनों किनारों से लटकाने के रूप में सेट कर सकते हैं।

नीचे दिया गया उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लिए लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित सूचकांक `0` पहले टॉप-लेवल नोड को चुनता है; उसके बच्चा नोड्स चयनित व्यवस्था का उपयोग करते हैं। संशोधित प्रस्तुति को फिर सहेजा जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **चित्र संगठन चार्ट बनाएं**

चित्र संगठन चार्ट एक SmartArt लेआउट है जिसे उन पदानुक्रम आरेखों के लिए डिज़ाइन किया गया है जिसमें छवि प्लेसहोल्डर शामिल होते हैं। स्लाइड पर SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण छवि प्लेसहोल्डर वाले आरेख को सेव करता है; यह प्लेसहोल्डर को छवियों से भरता नहीं है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **लेगेसी आरेखों को आकार समूहों में परिवर्तित करें**

मौजूदा प्रस्तुति को आधुनिक बनाने पर आपको PowerPoint 97–2003 में मूल रूप से बनाई गई संगठन चार्ट को अपडेट करने की आवश्यकता हो सकती है। Aspose.Slides इन लेगेसी आरेखों को [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) के रूप में दर्शाता है। आरेख को आकार समूह में बदलने के लिए [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) का उपयोग करें ताकि आप व्यक्तिगत दृश्य तत्वों को संपादित कर सकें। विवरण के लिए [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) देखें।

परिवर्तन मूल आरेख को हटाए बिना आकार संग्रह में एक नया समूह जोड़ता है। सफल परिवर्तन के बाद, दोहरावदार सामग्री से बचने के लिए मूल को [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) से हटाएँ। रूपांतरण से पहले लेगेसी आरेखों को सूची में एकत्रित करें ताकि आकार जोड़ने और हटाने से इटरेशन बाधित न हो।

नीचे दिया गया उदाहरण एक प्रस्तुति को खोलता है, प्रत्येक स्लाइड की खोज करता है, आरेखों को आकार समूहों में बदलता है, और अद्यतन प्रस्तुति को PPTX के रूप में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
सहेजी गई प्रस्तुति में परिवर्तित लेगेसी आरेखों के स्थान पर संपादन योग्य आकार समूह होते हैं, और साथ में मूल आरेख नहीं रहता। प्रत्येक समूह के भीतर व्यक्तिगत तत्वों जैसे टेक्स्ट, भराव या स्थिति को संपादित करने के लिए PPTX को PowerPoint में खोलें।

## **FAQ**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हां। [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) मेथड चयनित SmartArt लेआउट द्वारा रिवर्सल का समर्थन करते समय आरेख की दिशा को बाएं-से-दाएं से दाएं-से-बाएं या वापस बदल देता है।

**मैं फ़ॉर्मेटिंग को बरकरार रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप [clone the SmartArt shape](/slides/hi/php-java/shape-manipulations/) को [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) के साथ या [clone the whole slide](/slides/hi/php-java/clone-slides/) को SmartArt वाली स्लाइड के साथ क्लोन कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग बरकरार रहती है।

**मैं पूर्वावलोकन या वेब निर्यात के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

[Render the slide](/slides/hi/php-java/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा के रूप में रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हों तो मैं किसी विशिष्ट SmartArt ऑब्जेक्ट को कैसे खोजूँ?**

[Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) या [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) का उपयोग करके SmartArt आकार को एक विशिष्ट वैकल्पिक टेक्स्ट या नाम असाइन करें, फिर उस मान को [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) में खोजें, और यह सत्यापित करें कि मिलते-जुलते आकार एक [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) है।