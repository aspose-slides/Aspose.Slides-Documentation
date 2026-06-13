---
title: PHP में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/php-java/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अद्यतन करें
- PPTX का निरीक्षण करें
- PPT का निरीक्षण करें
- ODP का निरीक्षण करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडाटा का अन्वेषण करें, ताकि तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट प्राप्त हो सकें।"
---
## **परिचय**

यह लेख Aspose.Slides में प्रस्तुति जानकारी की जांच कैसे की जाए, दिखाता है। यह बिना पूरी फ़ाइल लोड किए प्रस्तुति के वर्तमान प्रारूप का निर्धारण करने, उसकी दस्तावेज़ गुणों को पढ़ने, और आवश्यकता पड़ने पर उन गुणों को अपडेट करने की व्याख्या करता है।

उदाहरण [PresentationInfo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentationinfo/) और [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/) API पर आधारित हैं और प्रस्तुति मैटाडेटा के साथ काम करने के सामान्य संचालन दिखाते हैं।

## **प्रस्तुति प्रारूप की जाँच करें**

किसी प्रस्तुति पर काम करने से पहले, आप यह जानना चाह सकते हैं कि वर्तमान में प्रस्तुति किस प्रारूप (PPT, PPTX, ODP, आदि) में है।

आप प्रस्तुति को लोड किए बिना उसकी प्रारूप की जाँच कर सकते हैं। इस PHP कोड को देखें:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// पीपीटीएक्स

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// पीपीटी

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ओडीपी


```

## **प्रस्तुति गुण प्राप्त करें**

यह PHP कोड आपको बताता है कि प्रस्तुति गुण (प्रस्तुति संबंधी जानकारी) कैसे प्राप्त करें:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

आप [DocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/documentproperties/#DocumentProperties--) वर्ग के अंतर्गत गुण देखना चाह सकते हैं।

## **प्रस्तुति गुण अपडेट करें**

Aspose.Slides [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) मेथड प्रदान करता है जो आपको प्रस्तुति गुणों में परिवर्तन करने की अनुमति देता है।

मान लीजिए हमारे पास नीचे दर्शाए गए दस्तावेज़ गुणों वाला एक PowerPoint प्रस्तुति है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

यह कोड उदाहरण आपको दिखाता है कि कुछ प्रस्तुति गुणों को कैसे संपादित किया जाए:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

दस्तावेज़ गुणों को बदलने के परिणाम नीचे दिखाए गए हैं।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

प्रस्तुति और उसकी सुरक्षा विशेषताओं के बारे में अधिक जानकारी प्राप्त करने के लिए, आपको ये लिंक उपयोगी लग सकते हैं:

- [जाँचें कि क्या प्रस्तुति एन्क्रिप्टेड है](https://docs.aspose.com/slides/hi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [जाँचें कि क्या प्रस्तुति राइट-प्रोटेक्टेड (केवल-पढ़ने योग्य) है](https://docs.aspose.com/slides/hi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [जाँचें कि क्या प्रस्तुति को लोड करने से पहले पासवर्ड से संरक्षित है](https://docs.aspose.com/slides/hi/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [प्रस्तुति को संरक्षित करने के लिए उपयोग किए गए पासवर्ड की पुष्टि करना](https://docs.aspose.com/slides/hi/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन से हैं?**

प्रस्तुति स्तर पर [embedded-font information](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getembeddedfonts/) को देखें, फिर उन प्रविष्टियों की तुलना [fonts actually used across content](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fontsmanager/getfonts/) सेट से करें ताकि यह पता चल सके कि कौन से फ़ॉन्ट रेंडरिंग के लिए महत्वपूर्ण हैं।

**मैं जल्दी कैसे पता लगा सकता हूँ कि फ़ाइल में छिपी स्लाइड्स हैं और कितनी?**

[slide collection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slidecollection/) के माध्यम से iterate करें और प्रत्येक स्लाइड की [visibility flag](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slide/gethidden/) को जाँचें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग किया गया है, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। वर्तमान [slide size](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/getslidesize/) और अभिविन्यास की तुलना मानक प्रीसेट्स से करें; यह प्रिंटिंग और निर्यात के व्यवहार का अनुमान लगाने में मदद करता है।

**क्या चार्ट बाहरी डेटा स्रोतों का संदर्भ देते हैं, यह देखने का कोई तेज़ तरीका है?**

हाँ। सभी [charts](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) को ट्रैवर्स करें, उनके [data source](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdata/getdatasourcetype/) की जाँच करें, और देखें कि डेटा आंतरिक है या लिंक-आधारित, जिसमें किसी भी टूटे हुए लिंक शामिल हैं।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

प्रत्येक स्लाइड के लिए, ऑब्जेक्ट काउंट को गिनें और बड़ी छवियों, ट्रांसपरेंसी, शैडोज़, एनीमेशन, और मल्टीमीडिया की खोज करें; संभावित प्रदर्शन हॉटस्पॉट को चिन्हित करने के लिए एक मोटा जटिलता स्कोर असाइन करें।