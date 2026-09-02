---
title: PHP में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/php-java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और स्मार्ट कंटेंट ऑडिट के लिए।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसका दस्तावेज़ मेटाडेटा पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक इन्वेंटरी बनानी हो, या गुणों की जाँच करनी हो इससे पहले कि आप तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्का निरीक्षण दर्शाता है [PresentationFactory] और [PresentationInfo] के माध्यम से, साथ ही लक्षित अपडेट्स [DocumentProperties] के माध्यम से।

## **प्रस्तुति फ़ॉर्मेट जांचें**

फ़ाइल को निरीक्षण करने के लिए बिना एक [Presentation] इंस्टेंस बनाए [PresentationFactory::getPresentationInfo] का उपयोग करें। [PresentationInfo::getLoadFormat] मेथड पता लगाए गए फ़ॉर्मेट की रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

foreach ($fileNames as $fileName) {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($fileName);
    $loadFormat = java_values($presentationInfo->getLoadFormat());
    $formatName = "Other (" . $loadFormat . ")";

    if ($loadFormat === LoadFormat::Pptx) {
        $formatName = "PPTX";
    } elseif ($loadFormat === LoadFormat::Ppt) {
        $formatName = "PPT";
    } elseif ($loadFormat === LoadFormat::Odp) {
        $formatName = "ODP";
    }

    echo $fileName . ": " . $formatName . PHP_EOL;
}
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो आपको जांच, इंडेक्सिंग, या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory::getPresentationInfo] का उपयोग करके एक [PresentationInfo] ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo::readDocumentProperties] को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह तरीका एक [Presentation] इंस्टेंस नहीं बनाता और आपको संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की ज़रूरत नहीं पड़ती।

[DocumentProperties] द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित इन्वेंटरी मान प्रदान करते हैं:

| मेथड | इन्वेंटरी मान |
| --- | --- |
| [getSlides] | स्लाइडों की कुल संख्या। |
| [getHiddenSlides] | छिपी स्लाइडों की संख्या। |
| [getNotes] | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs] | जब उपलब्ध हो तो पैरेग्राफ़ की कुल संख्या। |
| [getWords] | शब्दों की कुल संख्या। |
| [getMultimediaClips] | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना एक [Presentation] ऑब्जेक्ट बनाए पढ़ता है और एक कॉम्पैक्ट इन्वेंटरी प्रदर्शित करता है। यह साथ ही [DocumentProperties::getHeadingPairs] को [DocumentProperties::getTitlesOfParts] के साथ जोड़ता है ताकि फ़ॉन्ट, थीम, और स्लाइड शीर्षक जैसी सामग्री समूह प्रदर्शित हो सकें।

```php
use aspose\slides\LoadFormat;
use aspose\slides\PresentationFactory;

$filePath = "sample.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);
$documentProperties = $presentationInfo->readDocumentProperties();

$loadFormat = java_values($presentationInfo->getLoadFormat());
$formatName = "Other (" . $loadFormat . ")";

if ($loadFormat === LoadFormat::Pptx) {
    $formatName = "PPTX";
} elseif ($loadFormat === LoadFormat::Ppt) {
    $formatName = "PPT";
} elseif ($loadFormat === LoadFormat::Odp) {
    $formatName = "ODP";
}

echo "File: " . basename($filePath) . PHP_EOL;
echo "Format: " . $formatName . PHP_EOL;
echo "Title: " . java_values($documentProperties->getTitle()) . PHP_EOL;
echo "Author: " . java_values($documentProperties->getAuthor()) . PHP_EOL;
echo "Statistics:" . PHP_EOL;
echo "  Slides: " . java_values($documentProperties->getSlides()) . PHP_EOL;
echo "  Hidden slides: " . java_values($documentProperties->getHiddenSlides()) . PHP_EOL;
echo "  Slides with notes: " . java_values($documentProperties->getNotes()) . PHP_EOL;
echo "  Paragraphs: " . java_values($documentProperties->getParagraphs()) . PHP_EOL;
echo "  Words: " . java_values($documentProperties->getWords()) . PHP_EOL;
echo "  Multimedia clips: " . java_values($documentProperties->getMultimediaClips()) . PHP_EOL;

$headingPairs = $documentProperties->getHeadingPairs();
$titlesOfParts = $documentProperties->getTitlesOfParts();

if (java_is_null($headingPairs) || java_is_null($titlesOfParts)) {
    echo "Content groups: not available" . PHP_EOL;
} else {
    $headingPairs = java_values($headingPairs);
    $titlesOfParts = java_values($titlesOfParts);
    $partIndex = 0;

    if (count($headingPairs) === 0 || count($titlesOfParts) === 0) {
        echo "Content groups: not available" . PHP_EOL;
    } else {
        echo "Content groups:" . PHP_EOL;

        foreach ($headingPairs as $headingPair) {
            $partCount = java_values($headingPair->getCount());
            echo "  " . java_values($headingPair->getName()) . " (" . $partCount . ")" . PHP_EOL;

            for ($partOffset = 0; $partOffset < $partCount && $partIndex < count($titlesOfParts); $partOffset++) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }

        if ($partIndex < count($titlesOfParts)) {
            echo "  Other parts:" . PHP_EOL;

            while ($partIndex < count($titlesOfParts)) {
                echo "    - " . $titlesOfParts[$partIndex] . PHP_EOL;
                $partIndex++;
            }
        }
    }
}
```

प्रत्येक [HeadingPair] एक समूह नाम और उस समूह में आइटमों की संख्या प्रदान करता है। [DocumentProperties::getTitlesOfParts] एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पैर द्वारा निर्दिष्ट कॉन्क्रिट टाइटल्स की संख्या का उपयोग करें।

### **संग्रहीत मेटाडेटा और फ़ॉर्मेट प्रतिबंध**

[PresentationInfo::readDocumentProperties] द्वारा लौटाए गए इन्वेंटरी गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनः‑गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपस्थित गुणों को डिफ़ॉल्ट मानों से दर्शाया जाता है, और संग्रहित मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाले एप्लिकेशन ने दस्तावेज़ गुणों को अपडेट नहीं किया हो।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैरेग्राफ़, शब्द, और मल्टीमीडिया गिनती के लिए विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग‑पेयर्स और भाग‑टाइटल्स भी। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या निर्माता द्वारा रिफ़्रेश नहीं किया गया, तो Aspose.Slides इसका संग्रहित या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइडों से गणना करके।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पेज, पैरेग्राफ़, और शब्द गिनती प्रदान करता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर्स, और भाग‑टाइटल मेटाडेटा उपलब्ध नहीं हो सकते, और इन्वेंटरी गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या खाली एरे को यह प्रमाण न समझें कि संबंधित सामग्री अनुपलब्ध है।

इन्वेंटरी और प्रारंभिक जाँचों के लिए हल्की मेटाडेटा विधि का उपयोग करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तब प्रस्तुति लोड करके उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रस्तुति गुणों को अपडेट करें**

[PresentationInfo::readDocumentProperties] द्वारा लौटाए गए गुणों को एक [Presentation] इंस्टेंस बनाए बिना भी बदला जा सकता है। परिवर्तन को लागू करने के लिए [PresentationInfo::updateDocumentProperties] का प्रयोग करें, और फिर बंधित प्रस्तुति को लिखने के लिए [PresentationInfo::writeBindedPresentation] का उपयोग करें।

नीचे की छवि मूल दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजे समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```php
use aspose\slides\PresentationFactory;

$sourceFile = "sample.pptx";
$outputFile = "sample_with_updated_properties.pptx";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($sourceFile);
$documentProperties = $presentationInfo->readDocumentProperties();

$documentProperties->setTitle("Quarterly sales report");
$documentProperties->setLastSavedTime(new Java("java.util.Date"));

$presentationInfo->updateDocumentProperties($documentProperties);
$outputStream = new Java("java.io.FileOutputStream", $outputFile);
try {
    $presentationInfo->writeBindedPresentation($outputStream);
} finally {
    $outputStream->close();
}
```

नीचे की छवि अपडेटेड दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और संरक्षण सेटिंग्स के लिए नीचे दिए गए लेख देखें:

- [प्रेजेंटेशन को पासवर्ड से सुरक्षित करें](/slides/hi/php-java/password-protected-presentation/)
- [प्रेजेंटेशन को लिखने से सुरक्षित करें](/slides/hi/php-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन से एम्बेडेड हैं?**

प्रेजेंटेशन लोड करें और [Presentation::getFontsManager] का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager::getEmbeddedFonts] कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [FontsManager::getFonts] कॉल करें। दोनों परिणामों की तुलना करें ताकि उन फ़ॉन्ट्स की पहचान हो सके जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता कर सकता हूँ कि फ़ाइल में छिपी स्लाइडें हैं और कितनी?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory::getPresentationInfo] और [PresentationInfo::readDocumentProperties] के माध्यम से [DocumentProperties::getHiddenSlides] पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है, या वास्तविक मानों की पुष्टि करनी हो, तो [Presentation::getSlides] के साथ इटररेट करें और प्रत्येक स्लाइड के [Slide::getHidden] मेथड को निरीक्षण करें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड साइज़ और ओरिएंटेशन प्रयोग में हैं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हां। प्रस्तुति लोड करें और [Presentation::getSlideSize] को कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [SlideSize::getType], [SlideSize::getSize], और [SlideSize::getOrientation] का उपयोग करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों का त्वरित पता लगाना संभव है?**

हां। प्रत्येक [Chart] को locate करें और [ChartData::getDataSourceType] को कॉल करें। बाहरी वर्कबुक के लिए, [ChartData::getExternalWorkbookPath] को कॉल करें। डेटा स्रोत प्रकार और पाथ बाहरी संदर्भ दर्शाते हैं, लेकिन लक्ष्य उपलब्धता की पुष्टि के लिए अलग संसाधन जांच आवश्यक है।

**मैं 'भारी' स्लाइड्स को कैसे आँक सकता हूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation::getSlides] और प्रत्येक स्लाइड के [BaseSlide::getShapes] कलेक्शन को ट्रैवर्स करें। आकार‑गिनती, बड़े इमेज, इफ़ेक्ट्स, एनिमेशन, या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और प्रतिनिधि रेंडर या एक्सपोर्ट मापें इससे पहले कि किसी स्लाइड को निश्चित प्रदर्शन बाधा मानें।