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
- पाठ हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- चित्र हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक्स जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं, PHP उदाहरणों का उपयोग करते हुए।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक्स आम तौर पर दो उद्देश्यों को पूरा करते हैं:

* पाठ, आकार या मीडिया फ्रेम से एक वेबसाइट खोलें।
* दूसरी स्लाइड पर नेविगेट करें, उदाहरण के लिए, सामग्री तालिका से।

Aspose.Slides for PHP via Java आपको ये लिंक जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनकी प्रॉपर्टीज़ को अपडेट करने और हटाने की अनुमति देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक्स के साथ कैसे काम करें और प्रस्तुति, स्लाइड या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक्स तक कैसे पहुँचें। यह मानते हैं कि PHP/Java Bridge और Aspose.Slides PHP wrapper प्रारम्भ किया गया है। PHP संदर्भ पेज से बिना लिंक वाले API सदस्य मूल Java API से लिंक करते हैं।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [नि:शुल्क ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक्स जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ़्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ़्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक्स वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस को प्रबंधित करें](/slides/hi/php-java/presentation-properties/#manage-the-hyperlink-base) देखें ताकि दस्तावेज़-स्तर बेस को पढ़ा, बदला या साफ किया जा सके।

### **टेक्स्ट में URL हाइपरलिंक्स जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) मेथड को एक [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) पास करें। केवल वह टेक्स्ट भाग क्लिक करने योग्य बनता है।

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

### **आकार और मीडिया फ़्रेम में URL हाइपरलिंक्स जोड़ें**

एक आकार या फ्रेम को क्लिक करने योग्य बनाने के लिए, उसकी [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/) मेथड को कॉल करें। हाइपरलिंक ऑब्जेक्ट खुद से जुड़ा होता है, न कि उसके भीतर के टेक्स्ट भाग से।

इसी विधि को चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू किया जाता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यकता होने पर [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) को कॉल करें।

निम्न उदाहरण एक आयत को क्लिक करने योग्य बनाता है:

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

आंतरिक हाइपरलिंक्स पाठकों को सामग्री तालिका से किसी विशेष स्लाइड पर पहुंचने देते हैं। निम्न उदाहरण [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके प्रथम स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

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

## **हाइपरलिंक्स को स्वरूपित करें**

### **रंग**

[Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) की [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) मेथड निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग की फ़ॉर्मेटिंग का। कस्टम टेक्स्ट रंग लगाने के लिए, [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की भराव रंग सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण एक ही स्लाइड पर दो टेक्स्ट हाइपरलिंक्स जोड़ता है। पहला लाल टेक्स्ट भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग को बनाए रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न मेथड्स का उपयोग करें:

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) हाइपरलिंक से जुड़े ऑडियो को निर्दिष्ट करता है।
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) क्लिक करने पर पहले की ध्वनि को रोकता है या नहीं, नियंत्रित करता है।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` को लोड करता है और पहले स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि चलती है और अगले स्लाइड पर नेविगेट किया जाता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पिछली ध्वनि को रोकता है, बिना नेविगेशन कार्रवाई किए।

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

निम्न उदाहरण उपर्युक्त बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को मेमोरी में [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) और [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) के माध्यम से पढ़ता है।

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

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्नलिखित [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) मेथड्स को कॉल कर सकते हैं:

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) लिंक के लिए दर्शकों को संकेत स्वरूप में दिखाने वाला टेक्स्ट सेट करता है।
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) जब लागू हो, तो पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ़्रेम निर्दिष्ट करता है।
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) सक्रिय लिंक को देखे गए हाइपरलिंक्स की सूची में जोड़ता है या नहीं, नियंत्रित करता है।
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) क्लिक करने पर हाइपरलिंक को हाईलाइट किया जाए या नहीं, नियंत्रित करता है।

## **प्रस्तुतीकरण से हाइपरलिंक्स हटाएं**

[getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) का उपयोग करके हाइपरलिंक कंटेनर, जिसमें टेक्स्ट-भाग लिंक शामिल हैं, एकत्र करें, इससे पहले कि आप उन्हें बदलें। निम्न उदाहरण पहले स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) या [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई हटाने से उसकी माउस-ओवर समकक्ष नहीं हटती।

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

अशर्त हटाने के लिए, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) चयनित स्कोप में एक ही कॉल में दोनों सक्रियता प्रकार हटा देता है। चयनित सफाई और मास्टर, लेआउट, तथा नोट्स को कवर करने के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **हाइपरलिंक सूची बनाएं**

प्रस्तुति वितरित करने से पहले, उसके इंटरैक्टिव कार्यों और वेब लिंक की सूची बनाएं। [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट्स लौटाता है, न कि URL स्ट्रिंग की सपाट सूची। प्रत्येक कंटेनर पर दोनों [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) और [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) की जांच करें। वे स्वतंत्र हैं: एक ही कंटेनर दोनों कार्यों को उजागर कर सकता है, इसलिए पूर्ण रिपोर्ट में प्रति कंटेनर दो पंक्तियों तक की आवश्यकता हो सकती है।

सिर्फ आकार-स्तर हाइपरलिंक्स स्कैन करने से टेक्स्ट भाग से जुड़े लिंक छूट सकते हैं। इसके बजाय उपयुक्त स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को बनाए रखें ताकि बाद में आप उनके कार्यों को अपडेट या हटाना कर सकें।

### **प्रेजेंटेशन, स्लाइड, और टेक्स्ट-फ़्रेम स्कॉप्स को क्वेरी करें**

[HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) क्लास निम्न के माध्यम से उपलब्ध है: [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), और [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). प्रत्येक स्कोप समान क्वेरीज को सपोर्ट करता है:

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) क्लिक कार्रवाई वाले कंटेनर लौटाता है।
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) माउस-ओवर कार्रवाई वाले कंटेनर लौटाता है।
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) एक या दोनों कार्रवाइयों वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस-ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस-ओवर लिंक, और एक मैक्रो कार्रवाई शामिल है। यह इन कार्यों में से कोई भी निष्पादित नहीं करता। वही तीन क्वेरीज हर स्कोप पर काम करती हैं; गिनती कंटेनरों को दर्शाती है, कार्यों की कुल संख्या नहीं। टेक्स्ट-फ़्रेम स्कोप enclosing आकार के स्वयं के लिंक को बाहर रखता है।

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

इस उदाहरण के लिए, प्रेजेंटेशन और स्लाइड क्वेरीज प्रत्येक तीन क्लिक कंटेनर, दो माउस-ओवर कंटेनर, और एक्शन वाले तीन कंटेनर रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाएँ और गंतव्य वर्गीकृत करें**

[Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) का उपयोग करके एक कार्रवाई को उसके गंतव्य को समझने से पहले व्याख्यायित करें। [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसका स्कीम जांचें। |
| `JumpSpecificSlide` | एक विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो चलाएं। |
| `StartProgram` | एक प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अपरिचित कार्रवाई जिसके लिए समीक्षा आवश्यक है। |

[getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) से बाहरी गंतव्य पढ़ें और [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/) से विशिष्ट आंतरिक गंतव्य। आंतरिक कार्रवाइयों और बिल्ट‑इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई कार्रवाई नहीं है। जब [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) मान सामान्यीकृत URL से अलग हो तो उसे संरक्षित रखें, और जब उपलब्ध हो तो [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) द्वारा लौटाया गया टूलटिप शामिल करें।

### **हाइपरलिंक्स की रिपोर्ट, सैनिटाइज़ और वेरिफ़ाई करें**

निम्न PHP उदाहरण एक मौजूदा प्रस्तुति को पढ़ता है (ऊपर बनाई गई फ़ाइल का उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोनों सक्रियता प्रकारों को फिर से जांचने के लिए उसे पुनः खोलता है। यह बदलने से पहले कंटेनरों को इकट्ठा करता है और उसी कंटेनर को दो बार प्रोसेस न करने के लिए रेफ़रेंस इक्वैलिटी का उपयोग करता है। प्रेजेंटेशन क्वेरीज सामान्य स्लाइड्स को कवर करती हैं; पैकेज-व्यापी इन्वेंट्री के लिए, यह मास्टर, लेआउट, नोट्स, तथा नोट्स और हैंडआउट मास्टर्स को भी स्पष्ट रूप से क्वेरी करता है जब उपलब्ध हों।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) को रिकॉर्ड करती है। [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) समर्थित कंटेनरों के लिये स्वामी स्लाइड प्रदान करता है। मास्टर, लेआउट, तथा नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑भाग फ़ॉर्मेटिंग कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपना रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID मिलती है ताकि उसकी दो कार्रवाइयों को सम्बद्ध किया जा सके। रिपोर्ट कार्य प्रकारों को PHP एनेमरेटेड द्वारा निर्धारित पूर्णांक स्थिरांक के रूप में संग्रहीत करती है।

यह जानबूझकर सीमित एप्लिकेशन नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्य, अन्य स्लाइडशो कार्य, अज्ञात कार्य, और अन्य URL स्कीम को अस्वीकार करता है। ये अस्वीकृतियां नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS विश्‍वास स्थापित नहीं करता: अपने एप्लिकेशन के लिए होस्ट अलाउलिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत बाहरी URL दोनों जांचे जाते हैं। उदाहरण लिंक का अनुसरण या कार्रवाई चलाए बिना मेटाडेटा ऑडिट करता है।

सुधार के लिए, कंटेनर का [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/), और [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) को सपोर्ट करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्य स्वतंत्र रूप से हटाए जाते हैं। सभी नीति उल्लंघनों को हटाने के लिए `$replaceExternalClicks` को `false` सेट करें। तैनाती से पहले एक एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्य और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित के रूप में फ़्लैग किया जाता है। यह एक समीक्षा संकेत है, क्षमता परीक्षण या यह गारंटी नहीं है कि अनफ़्लैग्ड लिंक निर्यात में रहेंगे। समर्थित [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं, कार्य, निर्यात विकल्प और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/php-java/convert-powerpoint-to-png/) और [video](/slides/hi/php-java/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक्स को संरक्षित नहीं कर सकते; उन आउटपुट के ऑडिट करते समय प्रत्येक कार्य को फ़्लैग करें।

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

उपरोक्त इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित कार्य प्रदर्शित करता है। प्रतिबंधित बाहरी क्लिक URL वाले इनपुट से प्रतिस्थापन शाखा भी चलती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपना क्लिक कार्य रखता है।

यह चयनात्मक सफाई [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकार हटाता है। यहाँ सत्यापन केवल हाइपरलिंक कार्यों की जांच करता है; यह एम्बेडेड VBA प्रोजेक्ट्स, OLE ऑब्जेक्ट्स या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यात किए गए PDF या HTML फ़ाइल को वैधता देता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी सेक्शन या उसके पहले स्लाइड से कैसे लिंक कर सकता हूँ?**

PowerPoint में सेक्शन्स स्लाइड्स को समूहित करते हैं, लेकिन एक आंतरिक हाइपरलिंक एक व्यक्तिगत स्लाइड को टार्गेट करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि यह सभी स्लाइड्स पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक्स का समर्थन करते हैं। इन तत्वों पर मौजूद लिंक उन स्लाइड शो में उपलब्ध होते हैं जहाँ संबंधित मास्टर या लेआउट का उपयोग किया गया हो।

**क्या हाइपरलिंक्स PDF, HTML, इमेजेज, या वीडियो में एक्सपोर्ट करने पर संरक्षित रहेंगे?**

समर्थित PDF और HTML निर्यात हाइपरलिंक्स को संरक्षित कर सकते हैं; रास्टर इमेजेज और वीडियो नहीं कर सकते। निर्यात संबंधी विचार देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) में।