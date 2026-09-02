---
title: PHP में PowerPoint प्रस्तुतियों को XML में बदलें
linktitle: PowerPoint से XML
type: docs
weight: 145
url: /hi/php-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint को XML में बदलें
- प्रस्तुति को XML में बदलें
- PPT को XML में
- PPTX को XML में
- ODP को XML में
- PowerPoint XML प्रस्तुति
- SaveFormat.Xml
- प्रस्तुति को XML के रूप में सहेजें
- प्रस्तुति को XML में निर्यात करें
- XML स्ट्रीम
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PHP में PowerPoint और OpenDocument प्रस्तुतियों को PowerPoint XML फाइलों या स्ट्रीम में बदला जा सकता है।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java PowerPoint प्रस्तुतियों को PowerPoint XML Presentation फॉर्मेट में परिवर्तित कर सकता है। XML आउटपुट तब उपयोगी होता है जब आपको प्रस्तुति की संरचना का टेक्स्ट‑आधारित प्रतिनिधित्व चाहिए, निर्माण किए गए दस्तावेज़ों का समस्या निवारण करना हो, स्वचालित परीक्षणों में आउटपुट की तुलना करनी हो, या ऐसे वर्कफ़्लो के साथ एकीकृत करना हो जो XML को प्रस्तुति पैकेज की जगह उपयोग करता है।

[Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) एन्‍युमरेशन से `Xml` मान के साथ उपयोग करें। आप परिणाम को सीधे फ़ाइल में या स्ट्रीम में लिख सकते हैं।

{{% alert color="info" title="ध्यान दें" %}}
`SaveFormat::Xml` एक PowerPoint XML Presentation बनाता है। यह PPTX पैकेज के भीतर संग्रहीत व्यक्तिगत Office Open XML भागों को नहीं निकालता। यदि आपको सटीक PPTX पैकेज भागों की आवश्यकता है, जैसे `ppt/presentation.xml` या व्यक्तिगत स्लाइड XML फ़ाइलें, तो PPTX पैकेज को स्वयं जाँचें।
{{% /alert %}}

## **एक प्रस्तुति को XML फ़ाइल में बदलें**

[Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास से स्रोत प्रस्तुति लोड करें, फिर आउटपुट पाथ और `SaveFormat::Xml` को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) में पास करें। स्रोत कोई भी लोड‑सपोर्टेड प्रस्तुति फ़ॉर्मेट हो सकता है, जैसे PPT, PPTX, या ODP।

निम्न उदाहरण PPTX प्रस्तुति को XML फ़ाइल में बदलता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **XML आउटपुट को स्ट्रीम में लिखें**

जब XML को मेमोरी में रखना हो या किसी अन्य घटक—जैसे वेब सर्विस, स्टोरेज प्रोवाइडर, या XML प्रोसेसिंग पाइपलाइन—को पास करना हो, तो [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) के स्ट्रीम ओवरलोड का उपयोग करें। नीचे दिया गया उदाहरण परिणाम को एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) में लिखता है और उत्पन्न XML को बाइट ऐरे के रूप में प्राप्त करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // $xmlBytes को वर्कफ़्लो में अगली घटक को पास करें।
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

`ByteArrayOutputStream` सभी उत्पन्न डेटा को मेमोरी में रखता है, इसलिए `toByteArray` को कॉल करने से पहले कोई पोज़िशन रीसेट आवश्यक नहीं है।

## **XML की तुलना प्रस्तुति और एक्सपोर्ट फ़ॉर्मेट्स से करें**

परिणाम के उपयोग के आधार पर आउटपुट फ़ॉर्मेट चुनें:

| फ़ॉर्मेट | आउटपुट | आम उपयोग |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | एक PowerPoint XML Presentation | संरचना की जाँच, समस्या निवारण, उत्पन्न आउटपुट की तुलना, और XML‑आधारित एकीकरण |
| PPT (`.ppt`) | एक लेगेसी बाइनरी प्रस्तुति फ़ाइल | पुराने PowerPoint वर्कफ़्लो के साथ संगतता |
| PPTX (`.pptx`) | कई भागों वाला Office Open XML पैकेज | सामान्य PowerPoint संपादन और प्रस्तुति आदान‑प्रदान |
| PDF या TIFF | फिक्स्ड‑लेआउट पेज या मल्टी‑पेज इमेज | दर्शना, प्रिंटिंग, और अभिलेखन |
| PNG, JPEG या SVG | व्यक्तिगत स्लाइड का रेंडर किया गया प्रतिनिधित्व | थंबनेल, प्रीव्यू, और इमेज एसेट्स |
| HTML या HTML5 | वेब‑उन्मुख प्रस्तुति आउटपुट | ब्राउज़र में देखना और वेब प्रकाशन |

PPT और PPTX के विपरीत, XML आउटपुट मुख्यतः निरीक्षण और डेटा‑उन्मुख वर्कफ़्लो के लिए है। PDF, TIFF, HTML और स्लाइड इमेज फ़ॉर्मेट्स के विपरीत, यह स्लाइड को पेज या दृश्यमान एसेट के रूप में रेंडर नहीं करता, बल्कि प्रस्तुति डेटा को दर्शाता है। [समर्थित फ़ाइल फ़ॉर्मेट्स](/slides/hi/php-java/supported-file-formats/) तालिका में PowerPoint XML Presentation केवल सहेजने के लिए उपलब्ध फ़ॉर्मेट के रूप में सूचीबद्ध है, इसलिए जब वर्कफ़्लो को निर्यात फ़ाइल को फिर से Aspose.Slides में लोड करके संपादन जारी रखना आवश्यक हो, तो इसका उपयोग न करें।

## **FAQ**

**क्या `SaveFormat::Xml` PPTX फ़ाइल को सहेजने के समान है?**

नहीं। PPTX कई Office Open XML भागों वाला पैकेज है, जबकि `SaveFormat::Xml` एक PowerPoint XML Presentation फ़ाइल बनाता है।

**क्या मैं XML आउटपुट को डिस्क पर फ़ाइल बनाए बिना सहेज सकता हूँ?**

हां। लिखने योग्य स्ट्रीम को [Presentation::save](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) में पास करें। उदाहरण के लिए, मेमोरी‑प्रोसेसिंग के लिए एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) का उपयोग करें।

**क्या Aspose.Slides निर्यात किए गए XML फ़ाइल को फिर से लोड कर सकता है?**

नहीं। PowerPoint XML Presentation वर्तमान में केवल सहेजने के लिए समर्थित है, लोड करने के लिए नहीं। राउंड‑ट्रिप संपादन के लिए PPTX या अन्य समर्थित प्रस्तुति फ़ॉर्मेट उपयोग करें।

**क्या XML रूपांतरण प्रत्येक स्लाइड को पेज या इमेज के रूप में रेंडर करता है?**

नहीं। XML रूपांतरण संरचित प्रस्तुति डेटा लिखता है। पेज‑उन्मुख आउटपुट के लिए PDF या TIFF उपयोग करें, और व्यक्तिगत स्लाइड इमेज के लिए PNG, JPEG, और SVG उपयोग करें।