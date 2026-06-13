---
title: PHP का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके स्पष्ट कोड नमूनों के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और स्वचालन को तेज़ करता है।"
---
## **परिचय**

SmartArt एक PowerPoint आरेख है जो नोड्स, नोड आकारों, और एक लेआउट से बनाया जाता है। Aspose.Slides for PHP via Java के साथ, आप SmartArt बना सकते हैं, इसके नोड्स से टेक्स्ट पढ़ सकते हैं, इसका लेआउट बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और चित्र ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```
## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक शैप्स हो सकते हैं। दृश्यमान टेक्स्ट पढ़ने के लिए, [SmartArt::getAllNodes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/#getAllNodes) के माध्यम से इटररेट करें, फिर [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartshape/#getTextFrame) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) को पढ़ें।

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़े होते हैं। निम्न उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान होता है, इसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है।

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **जांचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/ishidden/) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट में उन्हें दृश्यमान आरेख तत्व के रूप में न दिखाने पर भी छिपे नोड्स संरचना में मौजूद रह सकते हैं।

निम्न उदाहरण एक नोड को SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और नोड की छिपी स्थिति की जाँच करता है।

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **ऑर्गनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

ऑर्गनाइज़ेशन चार्ट लेआउट का उपयोग करने वाले SmartArt आरेखों के लिए, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) और [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) यह निर्धारित करते हैं कि पैरेंट नोड के नीचे चाइल्ड नोड्स कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/organizationchartlayouttype/) के अनुसार चाइल्ड नोड्स को बाएँ, दाएँ, या दोनों तरफ लटका सकते हैं।

निम्न उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है।

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
## **चित्र ऑर्गनाइज़ेशन चार्ट बनाएं**

चित्र ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो छवि प्लेसहोल्डर वाले पदानुक्रमिक आरेखों के लिए बनाया गया है। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें।

---
title: PHP का उपयोग करके PowerPoint प्रस्तुतियों में SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधन
type: docs
weight: 10
url: /hi/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके स्पष्ट कोड नमूनों के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें, जो स्लाइड डिज़ाइन और स्वचालन को तेज़ करता है।"
---
## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हां। [SmartArt::setReversed](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/setreversed/) मेथड चयनित SmartArt लेआउट द्वारा रिवर्सल समर्थन होने पर आरेख की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ या इसके विपरीत बदल देता है।

**मैं फ़ॉर्मेटिंग को बनाए रखते हुए SmartArt को उसी स्लाइड पर या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप [ShapeCollection::addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addclone/) के साथ [SmartArt shape](/slides/hi/php-java/shape-manipulations/) को क्लोन कर सकते हैं या SmartArt वाले पूरे स्लाइड को [clone the whole slide](/slides/hi/php-java/clone-slides/) कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग बरकरार रहती है।

**मैं प्रीव्यू या वेब एक्सपोर्ट के लिए SmartArt को रास्टर इमेज में कैसे रेंडर करूँ?**

स्लाइड को [/slides/hi/php-java/convert-powerpoint-to-png/](/slides/hi/php-java/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में रेंडर करें। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हैं तो मैं विशेष SmartArt ऑब्जेक्ट कैसे ढूँढूँ?**

SmartArt shape पर एक विशिष्ट [Shape::getAlternativeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getalternativetext/) या [Shape::getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getname/) मान सेट करें, उस मान को [BaseSlide::getShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getShapes) में खोजें, और फिर जाँचें कि मिलती‑जुलती shape एक [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) है या नहीं।