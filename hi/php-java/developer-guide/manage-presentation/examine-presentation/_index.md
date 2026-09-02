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
- गुण अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट के लिए।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides में प्रस्तुति जानकारी को कैसे निरीक्षण किया जाए। यह समझाता है कि पूरी फ़ाइल लोड किए बिना प्रस्तुति का वर्तमान स्वरूप कैसे निर्धारित किया जाए, इसके दस्तावेज़ गुण पढ़े जाएँ, और आवश्यकता पड़ने पर उन गुणों को अपडेट किया जाए।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) APIs पर आधारित हैं और प्रस्तुति मेटाडेटा के साथ काम करने के सामान्य कार्यों को प्रदर्शित करते हैं।

## **प्रस्तुति स्वरूप जांचें**

प्रस्तुति पर काम करने से पहले, आप यह जानना चाहते होंगे कि वर्तमान में प्रस्तुति किस स्वरूप (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसकी स्वरूप जांच सकते हैं। इस PHP कोड को देखें:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **प्रस्तुति गुण प्राप्त करें**

यह PHP कोड दिखाता है कि प्रस्तुति गुण (प्रस्तुति की जानकारी) कैसे प्राप्त करें:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

आप [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#DocumentProperties--) क्लास के अंतर्गत गुण देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में बदलाव करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दिखाए गए दस्तावेज़ गुणों वाली एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण दर्शाता है कि कुछ प्रस्तुति गुण कैसे संपादित किए जाएँ:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

दस्तावेज़ गुण बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसके सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, आप इन लिंक को उपयोगी पा सकते हैं:

- [Password-Protect Presentations](/slides/hi/php-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/php-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन से हैं?**

प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) देखें, फिर उन प्रविष्टियों की तुलना [fonts actually used across content](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getfonts/) के सेट से करें ताकि यह पहचाना जा सके कि रेंडरिंग के लिए कौन से फ़ॉन्ट महत्त्वपूर्ण हैं।

**मैं जल्दी से कैसे पता कर सकता हूँ कि फ़ाइल में छिपी स्लाइड्स हैं और कितनी?**

[slide collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) में iterate करें और प्रत्येक स्लाइड के [visibility flag](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/gethidden/) की जाँच करें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग हो रहे हैं, और क्या वे डिफॉल्ट से भिन्न हैं?**

हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getslidesize/) और अभिविन्यास की मानक प्रीसेट्स से तुलना करें; यह प्रिंटिंग और एक्सपोर्ट के व्यवहार की भविष्यवाणी में मदद करता है।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित कर रहे हैं, इसे देखने का कोई तेज़ तरीका है?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) की जाँच करें, और नोट करें कि डेटा आंतरिक है या लिंक-आधारित, जिसमें टूटे हुए लिंक भी शामिल हैं।

**मैं 'हेवी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए ऑब्जेक्ट काउंट गिनें और बड़े इमेज, ट्रांसपैरेंसी, शैडो, एनीमेशन और मल्टीमीडिया देखें; संभावित प्रदर्शन इश्यू को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।