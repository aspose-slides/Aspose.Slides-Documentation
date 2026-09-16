---
title: PHP में प्रस्तुति हाइपरलिंक्स प्रबंधित करें
linktitle: हाइपरलिंक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/php-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP के लिए Java के माध्यम से Aspose.Slides का उपयोग करके, PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं, PHP उदाहरणों के साथ।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* टेक्स्ट, आकार या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for PHP via Java आपको ये लिंक जोड़ने, उनके स्वरूप और ध्वनि को नियंत्रित करने, उनकी प्रॉपर्टी अपडेट करने और उन्हें हटाने की अनुमति देता है। नीचे के उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे कार्य करें और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुंचें। ये मानते हैं कि PHP/Java Bridge और Aspose.Slides PHP wrapper को इनिशियलाइज़ किया गया है। PHP रेफ़रेंस पेज लिंक के बिना API सदस्य अंतर्निहित Java API की ओर संकेत करते हैं।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [free online Aspose PowerPoint editor](https://products.aspose.app/slides/hi/editor) से भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ्रेम को एक वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

### **टेक्स्ट में URL हाइपरलिंक जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/sethyperlinkclick/) मेथड में एक [हाइपरलिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/) पास करें। केवल वही टेक्स्ट भाग क्लिक करने योग्य बन जाता है।

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

आकार या फ्रेम को क्लिक करने योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/sethyperlinkclick/) मेथड को कॉल करें। हाइपरलिंक स्वयं ऑब्जेक्ट से जुड़ा होता है, न कि उसके भीतर के टेक्स्ट भाग से।

इसी दृष्टिकोण को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जा सकता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर [setTooltip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/settooltip/) कॉल करें।

नीचे दिया उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **हाइपरलिंक्स का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक्स पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर ले जाते हैं। नीचे दिया उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहले स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **हाइपरलिंक का स्वरूपण करें**

### **रंग**

[हाइपरलिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/) की [setColorSource](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/setcolorsource/) मेथड यह निर्धारित करती है कि हाइपरलिंक प्रस्तुति के डिफ़ॉल्ट हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग के स्वरूपण को। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkcolorsource/) चुनें और भाग के फ़िल रंग को सेट करें। यह सुविधा PowerPoint 2019 में प्रस्तुत की गई; पुरानी संस्करण इस सेटिंग को लागू नहीं करते।

नीचे दिया उदाहरण समान स्लाइड पर दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट फ़िल का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग रखता है।

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न मेथड का उपयोग करें:

- [Hyperlink::setSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/setsound/) हाइपरलिंक से जुड़ी ऑडियो निर्दिष्ट करता है।
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/setstopsoundonclick/) निर्धारित करता है कि हाइपरलिंक सक्रिय होते ही पूर्व ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

नीचा उदाहरण `sampleaudio.wav` लोड करता है और पहली स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि बजती है और अगली स्लाइड पर नेविगेट होता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पूर्व ध्वनि को रोकता है, बिना नेविगेशन किए।

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **हाइपरलिंक ध्वनि निकालें**

नीचा उदाहरण ऊपर बनाए गए प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/getsound/) और [getBinaryData](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audio/getbinarydata/) के माध्यम से मेमोरी में पढ़ता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्न [हाइपरलिंक](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/) मेथड को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/settooltip/) दर्शक को लिंक के संकेत के रूप में दिखाने के लिए टेक्स्ट सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/settargetframe/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/sethistory/) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखी गई हाइपरलिंक सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/sethighlightclick/) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

परिवर्तन करने से पहले हाइपरलिंक कंटेनरों को एकत्र करने के लिए [getAnyHyperlinks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) का उपयोग करें, जिसमें टेक्स्ट‑भाग लिंक भी शामिल हैं। नीचे दिया उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए केवल [removeHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई को हटाने से उसकी माउस‑ओवर समकक्ष नहीं हटती।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

बिना शर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक ही कॉल में हटाता है। चयनात्मक सफ़ाई और मास्टर, लेआउट और नोट्स को शामिल करने के लिए [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) देखें।

## **हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव क्रियाएँ तथा वेब लिंक का इन्वेंट्री बनाएँ। [getAnyHyperlinks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग्स की सपाट सूची। प्रत्येक कंटेनर पर [getHyperlinkClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) दोनों निरीक्षण करें। वे स्वतंत्र हैं: वही कंटेनर दोनों क्रियाएँ प्रदर्शित कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रत्येक कंटेनर के लिए दो पंक्तियाँ हो सकती हैं।

केवल आकार‑स्तर के हाइपरलिंक को स्कैन करने से टेक्स्ट‑भाग में जुड़े लिंक छूट सकते हैं। उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को रखें ताकि बाद में आप उनके क्रियाओं को अपडेट या हटाएँ।

### **प्रेजेंटेशन, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/) क्लास [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) और [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/gethyperlinkqueries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी समर्थन करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) या तो दोनों या किसी एक क्रिया वाले कंटेनर लौटाता है।

नीचा उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक और एक मैक्रो क्रिया शामिल हैं। ये क्रियाएँ निष्पादित नहीं होतीं। वही तीन क्वेरी हर स्कोप पर काम करती हैं; गणना कंटेनरों को दर्शाती है, क्रिया की कुल संख्या नहीं। टेक्स्ट‑फ़्रेम स्कोप में enclosing आकार के स्वयं के लिंक शामिल नहीं होते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन मिश्रित कंटेनर रिपोर्ट करते हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक वर्ग में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

क्रिया को समझने से पहले [Hyperlink::getActionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/getactiontype/) का उपयोग करके क्रिया प्रकार प्राप्त करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkactiontype/) के मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइड‑शो नेविगेशन, स्लाइड‑शो संदर्भ में हल होते हैं। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग जांचें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन नहीं, या अज्ञात क्रिया जिसके लिए समीक्षा आवश्यक है। |

बाहरी गंतव्यों के लिए [getExternalUrl](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/getexternalurl/) और विशिष्ट आंतरिक गंतव्यों के लिए [getTargetSlide](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/gettargetslide/) पढ़ें। आंतरिक क्रियाओं और बिल्ट‑इन कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं कि कंटेनर में कोई क्रिया नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) का मान सामान्यीकृत URL से अलग हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlink/gettooltip/) द्वारा लौटाया गया टूलटिप शामिल करें।

### **हाइपरलिंक रिपोर्ट, सैनिटाइज़ और वेरिफ़ाइ करें**

नीचा PHP उदाहरण मौजूदा प्रस्तुति को पढ़ता है (ऊपर बनाई गई फ़ाइल), `hyperlink-audit.json` लिखता है, नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोनो सक्रियता प्रकारों को फिर से जांचने के लिए इसे पुनः खोलता है। यह परिवर्तन से पहले कंटेनरों को एकत्र करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस इ़क्वैलिटी उपयोग करता है। प्रस्तुति क्वेरी सामान्य स्लाइड को कवर करती हैं; पैकेज‑व्यापी इन्वेंट्री के लिए यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स तथा नोट्स और हैंडआउट मास्टर को भी क्वेरी करती है।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और उपलब्ध होने पर [getSlideId](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getSlideId--) रिकॉर्ड करती है। [ISlideComponent::getSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनरों के स्वामित्व स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचान किया जाता है। आकार कंटेनर और टेक्स्ट‑portion फ़ॉर्मेटिंग कंटेनर को अलग‑अलग लेबल किया जाता है; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो क्रियाओं को आपस में जोड़ा जा सके। रिपोर्ट में क्रिया प्रकार PHP ए़न्यूमरेशन द्वारा परिभाषित पूर्णांक स्थिरांक के रूप में संग्रहीत होते हैं।

यह सख्त एप्लिकेशन नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड लक्ष्यों की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल क्रियाएँ, अन्य स्लाइड‑शो क्रियाएँ, अज्ञात क्रियाएँ और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृति नीति निर्णय हैं, Aspose.Slides सुरक्षा सत्यापन नहीं। HTTPS अकेले भरोसेमंद नहीं है: अपने एप्लिकेशन में होस्ट अलाउलिस्ट और अन्य जांच जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL की जाँच की जाती है। उदाहरण लिंक को फॉलो किए बिना या क्रियाएँ चलाए बिना मेटा‑डेटा ऑडिट करता है।

रिमिडिएशन के लिए कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) समर्थन करता है। यहाँ प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदल दिया गया है; अन्य प्रतिबंधित क्लिक और माउस‑ओवर क्रियाएँ स्वतंत्र रूप से हटाई जाती हैं। सभी नीति उल्लंघनों को हटाने के लिए `$replaceExternalClicks` को `false` सेट करें। तैनाती से पहले एप्लिकेशन‑स्वामित्व पेज तय करें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति अपनाता है: माउस‑ओवर क्रियाओं और किसी भी बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा चीज़ों को संभावित असमर्थित के रूप में चिह्नित करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी नहीं कि अन‑फ़्लैग्ड लिंक एक्सपोर्ट में टिके रहेंगे। समर्थित [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) निर्यात हाइपरलिंक को बरकरार रख सकते हैं, क्रिया, निर्यात विकल्प और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/php-java/convert-powerpoint-to-png/) और [video](/slides/hi/php-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट के लिए ऑडिट करते समय प्रत्येक क्रिया को चिह्नित करें।

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

ऊपर निर्मित इनपुट के साथ, रिपोर्ट में पाँच क्रिया पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित क्रियाएँ प्रदर्शित करता है। एक प्रतिबंधित बाहरी क्लिक URL वाला इनपुट बदलने वाले शाखा को भी चलाता है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपनी क्लिक क्रिया रखता है।

यह चयनात्मक सफ़ाई [removeAllHyperlinks](https://reference.aspose.com/slides/hi/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकार हटा देता है। यहाँ सत्यापन केवल हाइपरलिंक क्रियाओं को जांचता है; यह एंबेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही निर्यातित PDF या HTML फ़ाइल को सत्यापित करता है।

## **FAQ**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को टार्गेट करता है। सेक्शन के लिए नेविगेशन बनाने हेतु उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड के तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि वह सभी स्लाइड पर काम करे?**

हां। मास्टर स्लाइड और लेआउट के तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक स्लाइड‑शो के दौरान उन स्लाइडों पर उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या हाइपरलिंक PDF, HTML, इमेज या वीडियो निर्यात में बरकरार रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को बरकरार रख सकते हैं; रास्टर इमेज और वीडियो नहीं रख सकते। विस्तृत निर्यात विचारों के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).