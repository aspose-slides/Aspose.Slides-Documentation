---
title: PHP में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/php-java/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अद्यतन करें
- PPTX का परीक्षण
- PPT का परीक्षण
- ODP का परीक्षण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और स्मार्ट कंटेंट ऑडिट के लिए।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति के प्रारूप की पहचान कर सकता है और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फाइलों को वर्गीकृत करनी हो, इन्वेंट्री बनानी हो, या सामग्री को लोड और प्रोसेस करने से पहले गुणों की जाँच करनी हो।

यह लेख हल्की जाँच को [PresentationFactory](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) के माध्यम से, तथा लक्षित अपडेट को [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) के माध्यम से प्रदर्शित करता है।

## **प्रेजेंटेशन फ़ॉर्मेट की जाँच करें**

यदि आपके पास पहले से लोड की हुई प्रस्तुति है, तो लोड करने के बाद पहचान और लेगेसी PPT, PPS, तथा POT स्ट्रीम्स की सीमाओं के लिए देखें [Determine the Original Presentation Format](/slides/hi/php-java/detect-presentation-source-format/)।

फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना निरीक्षण करने के लिए उपयोग करें [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/)। [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#getLoadFormat) मेथड खोजे गए फ़ॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **हल्की प्रस्तुति इन्वेंट्री बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंट्री की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। इस विधि से [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस नहीं बनता और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं पड़ती।

[DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) द्वारा प्रदान किए गए विस्तारित गुण निम्नलिखित इन्वेंट्री मान देते हैं:

| मेथड | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getSlides) | स्लाइडों की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getHiddenSlides) | छिपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getParagraphs) | उपलब्ध होने पर पैराग्राफों की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getWords) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक संक्षिप्त इन्वेंट्री प्रिंट करता है। यह [DocumentProperties::getHeadingPairs](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getHeadingPairs) को [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ मिलाकर फ़ॉन्ट, थीम और स्लाइड शीर्षकों जैसी सामग्री समूहों को भी प्रदर्शित करता है।

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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/php-java/aspose.slides/headingpair/) समूह का नाम और उस समूह में आइटमों की संख्या प्रदान करता है। [DocumentProperties::getTitlesOfParts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getTitlesOfParts) एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पेयर द्वारा निर्दिष्ट क्रमागत शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपलब्ध गुण डिफ़ॉल्ट मानों से दर्शाए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाला अनुप्रयोग अपने दस्तावेज़ गुणों को अपडेट नहीं करता।

- **PPTX:** यह फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गणनाओं के साथ विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग‑पेयर और भाग‑शीर्षक। उपलब्धता इस बात पर निर्भर करती है कि कौन‑से गुण दस्तावेज़ निर्माता ने लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या निर्माता द्वारा रीफ़्रेश नहीं किया गया है, तो Aspose.Slides उसके संग्रहीत या डिफ़ॉल्ट मान को लौटाता है, न कि स्लाइडों से गणना किए गए मूल्य को।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ और शब्द गणना, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण के अनुरूप नहीं होते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडेटा अनुपलब्ध हो सकते हैं, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या खाली एरे को यह साबित करने के लिए प्रयोग न करें कि संबंधित सामग्री अनुपस्थित है।

भारी‑वजन मेटाडेटा दृष्टिकोण का उपयोग इन्वेंट्री और प्रारम्भिक जाँचों के लिए करें। जब परिणाम को मेमोरी में हुए परिवर्तन को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तो प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रेजेंटेशन गुण अपडेट करें**

[PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए गुणों को भी [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना बदला जा सकता है। परिवर्तन लागू करने के लिए उपयोग करें [PresentationInfo::updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#updateDocumentProperties), और फिर बंधित प्रस्तुति को लिखें [PresentationInfo::writeBindedPresentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#writeBindedPresentation) से।

निम्न छवि मूल दस्तावेज़ गुणों को दर्शाती है।

![Original document properties of the PowerPoint presentation](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजा गया समय बदलता है और परिणाम नई फ़ाइल में लिखता है:

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

निम्न छवि अपडेट किए गए दस्तावेज़ गुणों को दिखाती है।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँचों और सुरक्षा सेटिंग्स के लिए देखें:

- [Password-Protect Presentations](/slides/hi/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/php-java/write-protected-presentation/)

## **FAQ**

**फ़ॉन्ट एंबेडेड हैं या नहीं और कौन‑से हैं, कैसे जाँचें?**

प्रेजेंटेशन लोड करें और उपयोग करें [Presentation::getFontsManager](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getFontsManager)। एंबेडेड फ़ॉन्ट प्राप्त करने के लिए कॉल करें [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) और प्रेजेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट प्राप्त करने के लिए कॉल करें [FontsManager::getFonts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/#getFonts)। दोनों परिणामों की तुलना करके उन फ़ॉन्ट को खोजें जो रेंडरिंग के लिए आवश्यक हैं पर एंबेडेड नहीं हैं।

**फ़ाइल में छिपी स्लाइडें हैं और संख्या कितनी है, इसे जल्दी से कैसे पता करें?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो पढ़ें [DocumentProperties::getHiddenSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#getHiddenSlides) को [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationfactory/) और [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/#readDocumentProperties) के माध्यम से। यह हल्की इन्वेंट्री के लिए उपयुक्त है। यदि प्रस्तुति स्मृति में संशोधित हुई है, तो संग्रहीत मेटाडेटा गायब या पुराना हो सकता है, या आपको लाइव मानों की पुष्टि करनी हो, तो इटररेट करें [Presentation::getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlides) और प्रत्येक स्लाइड की [Slide::getHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/#getHidden) मेथड का निरीक्षण करें।

**कस्टम स्लाइड आकार और अभिविन्यास का उपयोग किया गया है और क्या वह डिफ़ॉल्ट से अलग है, कैसे पता करें?**

हाँ। प्रेजेंटेशन लोड करें और कॉल करें [Presentation::getSlideSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlideSize)। वर्तमान सेटिंग्स की अपेक्षित प्रीसेट और आयामों से तुलना करने के लिए उपयोग करें [SlideSize::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/#getType), [SlideSize::getSize](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/#getSize) और [SlideSize::getOrientation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidesize/#getOrientation)।

**क्या चार्ट बाहरी डेटा स्रोतों को संदर्भित करते हैं, यह जल्दी से कैसे देखें?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) को खोजें और कॉल करें [ChartData::getDataSourceType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#getDataSourceType)। यदि यह बाहरी वर्कबुक है, तो कॉल करें [ChartData::getExternalWorkbookPath](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/#getExternalWorkbookPath)। डेटा स्रोत प्रकार और पाथ एक बाहरी संदर्भ पहचानते हैं, पर लक्ष्य उपलब्धता की पुष्टि के लिए एक अलग संसाधन जाँच की आवश्यकता होगी।

**'भारी' स्लाइडों का आकलन कैसे करें जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं होता। ट्रैवर्स करें [Presentation::getSlides](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/#getSlides) और प्रत्येक स्लाइड की [BaseSlide::getShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseslide/#getShapes) कलेक्शन। आकार‑गणना, बड़े इमेज, इफ़ेक्ट, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और प्रतिनिधि रेंडर या एक्सपोर्ट मापें इससे पहले कि स्लाइड को निश्चित प्रदर्शन बाधा मानें।