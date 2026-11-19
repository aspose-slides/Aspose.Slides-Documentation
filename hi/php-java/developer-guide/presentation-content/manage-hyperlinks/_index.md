---
title: PHP में प्रस्तुति हाइपरलिंक्स का प्रबंधन
linktitle: हाइपरलिंक्स का प्रबंधन
type: docs
weight: 20
url: /hi/php-java/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक को फॉर्मेट करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- शेप हाइपरलिंक
- इमेज हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके, PHP उदाहरणों के साथ, PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, फॉर्मेट करें, अपडेट करें और हटाएं।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति की सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* टेक्स्ट, आकार, या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for PHP via Java आपको इन लिंक को जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनके गुणों को अपडेट करने और हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड, या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक्स तक कैसे पहुंचा जाए। वे मानते हैं कि PHP/Java Bridge और Aspose.Slides PHP रैपर आरंभीकृत है। PHP रेफ़रेंस पेज लिंक के बिना API सदस्य आधारभूत Java API की ओर इशारा करते हैं।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक्स जोड़ें**

आप टेक्स्ट, आकार, या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। हाइपरलिंक को जिस तत्व पर असाइन किया जाता है, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक्स वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस को प्रबंधित करें](/slides/hi/php-java/presentation-properties/#manage-the-hyperlink-base) देखें ताकि आप दस्तावेज़-स्तर बेस को पढ़, बदल या साफ कर सकें।

### **URL हाइपरलिंक्स को टेक्स्ट में जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) विधि में एक [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) पास करें। केवल वह टेक्स्ट भाग क्लिक करने योग्य बनता है।

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

### **आकारों और मीडिया फ्रेम्स में URL हाइपरलिंक्स जोड़ें**

आयत (rectangle) पर [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) को कॉल करके उसकी पूरी क्षेत्र को क्लिक करने योग्य बनाएं। जब पाठक आयत पर होवर करते हैं तो गंतव्य के बारे में संकेत देने के लिए [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) का उपयोग करें। दोनों विधियां चित्र, ऑडियो और वीडियो फ्रेम्स पर भी लागू होती हैं।

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

## **हाइपरलिंक्स का उपयोग करके सामग्री तालिका बनाना**

आंतरिक हाइपरलिंक्स पाठकों को सामग्री तालिका से एक विशिष्ट स्लाइड पर जा सकते हैं। नीचे दिया गया उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहली स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

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

## **हाइपरलिंक्स को फ़ॉर्मेट करें**

आप लिंक किए गए टेक्स्ट का रंग बदल सकते हैं, लिंक सक्रिय होने पर ध्वनि चला या रोक सकते हैं, और होवर करने पर दिखाई देने वाला टूलटिप सेट कर सकते हैं।

### **रंग**

[setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) विधि [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) यह निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करता है या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लगाने के लिए, [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) चुनें और भाग के फ़िल कलर को सेट करें। यह फीचर PowerPoint 2019 में पेश किया गया था; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

इस उदाहरण में, [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) पहला लिंक टेक्स्ट भाग के लाल फ़िल को उपयोग करता है। दूसरा लिंक प्रस्तुति के हाइپرलिंक रंग को रखता है।

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

एक हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्नलिखित विधियों का उपयोग करें:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) यह नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि रुक जाए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

पहली स्लाइड पर बटन [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) का उपयोग करके जब पाठक आगे बढ़ने के लिए क्लिक करता है तो `sampleaudio.wav` से ऑडियो चलाता है। दूसरी स्लाइड पर, एक अलग बटन [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) का उपयोग करके प्लेबैक रोकता है और पाठक को उसी स्लाइड पर रखता है।

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) और [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) के माध्यम से मेमोरी में पढ़ता है।

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

### **टूलटिप और इंटरऐक्शन सेटिंग्स**

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप नीचे दिए गए [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) विधियों को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) वह टेक्स्ट सेट करता है जिसे दर्शक लिंक के लिए संकेत के रूप में दिखा सकता है।
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम को निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) यह नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखे गए हाइपरलिंक्स की सूची में जोड़ा जाए या नहीं।
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) यह नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुतियों से हाइपरलिंक्स हटाएँ**

[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) का उपयोग करके हाइपरलिंक कंटेनर, जिसमें टेक्स्ट-भाग लिंक्स भी शामिल हैं, को बदलने से पहले इकट्ठा करें। नीचे दिया गया उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक एक्शन हटाने से उसका माउस-ओवर समकक्ष नहीं हटता।

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

बिना शर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) एक कॉल में चुने गए स्कोप में दोनों सक्रियता प्रकार हटाता है। चयनात्मक सफाई और मास्टर, लेआउट और नोट्स के कवरेज के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

### **SmartArt टेक्स्ट बदलने से पहले हाइपरलिंक्स साफ़ करें**

जब आप मौजूदा SmartArt नोड में पैराग्राफ बदलते हैं, तो उसके टेक्स्ट भागों को साफ़ करने से पुराना हाइपरलिंक सक्रिय रह सकता है। पैराग्राफ को [SmartArtNode::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/gettextframe/) के माध्यम से प्राप्त करें। उसके भागों को साफ़ करने से पहले, नोड आकार के टेक्स्ट फ्रेम पर [getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) को कॉल करें जो पैराग्राफ दिखाता है, फिर लौटाए गए ऑब्जेक्ट पर [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) को कॉल करें। यह फ्रेम में सभी हाइपरलिंक हटाता है, जिसमें उसके अन्य पैराग्राफ में लिंक शामिल हैं।

उदाहरण मानता है कि `SmartArtHyperlink.pptx` की पहली स्लाइड पर तीसरा आकार एक SmartArt ग्राफिक है। यह चौथे नोड के पहले पैराग्राफ को बदलता है। इस प्रस्तुति में, नोड का पहला आकार वह पैराग्राफ दिखाता है।

दोनों भाग जोड़ने के बाद, उदाहरण [getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/geteffective/) के साथ उनका प्रभावी फ़ॉर्मेट पढ़ता है। उस फ़ॉर्मेट पर, [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) पहला भाग के लिए नया हाइपरलिंक और दूसरे के लिए `null` लौटाता है।

```php
use aspose\slides\Hyperlink;
use aspose\slides\Portion;
use aspose\slides\Presentation;

$presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $smartArt = $slide->getShapes()->get_Item(2);
    $node = $smartArt->getAllNodes()->get_Item(3);
    $paragraph = $node->getTextFrame()->getParagraphs()->get_Item(0);

    $node->getShapes()->get_Item(0)->getTextFrame()->getHyperlinkQueries()->removeAllHyperlinks();
    $paragraph->getPortions()->clear();

    $link = new Portion("New reference");
    $link->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://example.com/new"));
    $paragraph->getPortions()->add($link);
    $text = new Portion(" (updated)");
    $paragraph->getPortions()->add($text);

    echo java_values($link->getPortionFormat()->getEffective()->getHyperlinkClick()->getExternalUrl()), PHP_EOL; // https://example.com/new
    var_dump(java_is_null($text->getPortionFormat()->getEffective()->getHyperlinkClick())); // bool(true): दूसरा भाग में कोई हाइपरलिंक नहीं है।
} finally {
    $presentation->dispose();
}
```

## **हाइपरलिंक इन्वेंटरी बनाएं**

प्रेजेंटेशन वितरित करने से पहले, उसके इंटरैक्टिव कार्यों और वेब लिंक का इन्वेंटरी बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की साधी सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) की जांच करें। वे स्वतंत्र हैं: एक ही कंटेनर दोनों एक्शन दिखा सकता है, इसलिए पूर्ण रिपोर्ट के लिए प्रत्येक कंटेनर पर दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल आकार-स्तर के हाइपरलिंक्स को स्कैन करने से टेक्स्ट भागों से जुड़े लिंक छूट सकते हैं। इसके बजाय उपयुक्त स्कोप को क्वेरी करें, और लौटाए गए कंटेनर को रखें ताकि बाद में आप उनके एक्शन को अपडेट या हटाने के लिए उपयोग कर सकें।

### **प्रेजेंटेशन, स्लाइड, और टेक्स्ट-फ़्रेम स्कोप्स को क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) क्लास [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) और [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरीज़ का समर्थन करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) क्लिक एक्शन वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) माउस-ओवर एक्शन वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) एक या दोनों एक्शन वाले कंटेनर लौटाता है।

यह उदाहरण आकार और उसके टेक्स्ट को क्लिक और माउस-ओवर एक्शन असाइन करता है, और एक अलग बटन को मैक्रो एक्शन देता है। यह [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) द्वारा लौटाए गए कंटेनर की संख्या को प्रत्येक सक्रियता प्रकार की गणना से तुलना करता है। टेक्स्ट-फ़्रेम क्वेरी केवल टेक्स्ट में लिंक गिनती है। संलग्नित आकार की अपनी एक्शन स्लाइड और प्रेजेंटेशन क्वेरीज में दिखाई देती हैं।

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

इस उदाहरण के लिए, प्रेजेंटेशन और स्लाइड क्वेरीज प्रत्येक तीन क्लिक कंटेनर, दो माउस-ओवर कंटेनर, और तीन कंटेनर जिनमें कोई भी एक्शन है, रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **एक्शन और डेस्टिनेशन्स को वर्गीकृत करें**

[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) का उपयोग करके एक्शन को उसके डेस्टिनेशन को समझने से पहले व्याख्यायित करें। [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसकी स्कीम की जांच करें। |
| `JumpSpecificSlide` | किसी विशेष स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट-इन स्लाइड शो नेविगेशन, स्लाइड शो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URLs से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन एक्शन नहीं, या अपरिचित एक्शन जिसे समीक्षा की आवश्यकता है। |

[getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) से बाहरी डेस्टिनेशन पढ़ें और विशिष्ट आंतरिक डेस्टिनेशन के लिए [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) का उपयोग करें। आंतरिक एक्शन और बिल्ट-इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का मतलब यह नहीं कि कंटेनर में कोई एक्शन नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) द्वारा लौटाया गया मान सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) द्वारा लौटाया गया टूलटिप शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सफ़ाई, और सत्यापन**

यह उदाहरण पिछले उदाहरण की प्रस्तुति खोलता है और प्रत्येक एक्शन के लिए एक JSON रिकॉर्ड लिखता है। यह [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) का उपयोग करके सामान्य स्लाइड्स, मास्टर्स, लेआउट्स और नोट्स, सहित नोट्स और हैंडआउट मास्टर्स, पर कंटेनर इकट्ठा करता है। यह रेफ़रेंस समानता का उपयोग करके प्रत्येक कंटेनर को एक बार गिनता है, नीचे वर्णित नीति लागू करता है, और सहेजी गई प्रस्तुति को दोबारा खोलकर दोनों क्लिक और माउस-ओवर एक्शन की जाँच करता है।

रिपोर्ट में एक-आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) रिकॉर्ड किया जाता है। [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनरों के लिए स्वामी स्लाइड प्रदान करता है। मास्टर्स, लेआउट्स और नोट्स का कोई सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनरों और टेक्स्ट-भाग फ़ॉर्मेटिंग कंटेनरों को अलग से लेबल किया जाता है; अन्य कंटेनर प्रकार अपने रनटाइम टाइप नाम को बनाए रखते हैं। प्रत्येक कंटेनर को रिपोर्ट-स्थानीय ID मिलती है ताकि उसके दो एक्शन को संबंधित किया जा सके। रिपोर्ट में एक्शन टाइप्स को PHP एनेमरेशन द्वारा परिभाषित पूर्णांक कॉन्स्टैंट्स के रूप में संग्रहीत किया जाता है।

यह जानबूझकर प्रतिबंधित एप्लिकेशन नीति केवल पूर्ण HTTPS URLs और वैध आंतरिक स्लाइड टारगेट्स की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल एक्शन, अन्य स्लाइडशो एक्शन, अज्ञात एक्शन, और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृतियां नीति निर्णय हैं, न कि Aspose.Slides सुरक्षा निर्णय। केवल HTTPS भरोसा स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट एलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URLs की जाँच की जाती है। उदाहरण लिंक को फॉलो किए बिना या एक्शन चलाए बिना मेटाडाटा का ऑडिट करता है।

समाधान के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) को समर्थन देता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदला जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस-ओवर एक्शन को स्वतंत्र रूप से हटाया जाता है। सभी नीति उल्लंघनों को हटाने के लिए `$replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एक एप्लिकेशन-स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट के एक्सपोर्ट फ़्लैग में एक रूढ़िवादी PDF समीक्षा नीति का उपयोग किया गया है: माउस-ओवर एक्शन और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित के रूप में फ़्लैग किया जाता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक निर्यात में बना रहेंगे। समर्थित [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) निर्यात एक्शन, निर्यात विकल्प और दर्शक पर निर्भर करते हुए हाइपरलिंक्स को संरक्षित कर सकते हैं। रास्टर [images](/slides/hi/php-java/convert-powerpoint-to-png/) और [video](/slides/hi/php-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक्स को संरक्षित नहीं कर सकते; उन आउटपुट्स के लिए ऑडिट करते समय प्रत्येक एक्शन को फ़्लैग करें।

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

ऊपर बनाया गया इनपुट के साथ, रिपोर्ट में पाँच एक्शन पंक्तियां होती हैं। फ़ाइल माउस-ओवर लिंक और मैक्रो क्लिक हटाए गए, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित एक्शन प्रदर्शित करता है। एक प्रतिबंधित बाहरी क्लिक URL वाले इनपुट ने भी प्रतिस्थापन शाखा को सक्रिय किया। एक कंटेनर जिसमें अनुमति दिया गया क्लिक और प्रतिबंधित माउस-ओवर है, अपना क्लिक एक्शन रखता है।

यह चयनात्मक सफाई [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चुने हुए स्कोप में दोनों सक्रियता प्रकार हटाता है। यहाँ सत्यापन केवल हाइपरलिंक एक्शन की जांच करता है; यह एम्बेडेड VBA प्रोजेक्ट्स, OLE ऑब्जेक्ट्स, या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही किसी निर्यात किए गए PDF या HTML फ़ाइल को सत्यापित करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड्स को समूहित करते हैं, लेकिन एक आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन में नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?**

हां। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक्स का समर्थन करते हैं। इन तत्वों पर लिंक उन स्लाइड्स में स्लाइड शो के दौरान उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करती हैं।

**क्या PDF, HTML, छवियों या वीडियो में निर्यात करने पर हाइपरलिंक्स बने रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं; रास्टर छवियों और वीडियो नहीं कर सकते। निर्यात संबंधी विचारों के लिए देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).