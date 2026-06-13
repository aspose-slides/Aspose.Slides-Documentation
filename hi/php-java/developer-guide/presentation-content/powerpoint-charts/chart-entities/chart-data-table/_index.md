---
title: पीएचपी का उपयोग करके प्रस्तुतियों में चार्ट डेटा टेबल को अनुकूलित करें
linktitle: डेटा टेबल
type: docs
url: /hi/php-java/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा टेबल
- फ़ॉन्ट गुण
- पावरपॉइंट
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PPT और PPTX के लिए Aspose.Slides for PHP via Java के साथ चार्ट डेटा टेबल को अनुकूलित करके प्रस्तुतियों में दक्षता और आकर्षण बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा टेबल के साथ काम करने का तरीका समझाता है। यह दर्शाता है कि चार्ट के लिए डेटा टेबल कैसे प्रदर्शित करें और फ़ॉन्ट गुण जैसे बोल्ड स्टाइल और फ़ॉन्ट की ऊँचाई सेट करके उसके पाठ फ़ॉर्मेट को कैसे अनुकूलित करें। उदाहरण में प्रेजेंटेशन लोड करना, चार्ट जोड़ना, चार्ट डेटा टेबल को सक्षम करना, फ़ॉन्ट सेटिंग्स लागू करना, और अपडेटेड प्रेजेंटेशन सहेजना दिखाया गया है।

यह चार्ट डेटा टेबल में लेजेंड कुंजियों को दिखाने, निर्यात के दौरान डेटा टेबल को संरक्षित रखने, मौजूदा प्रेजेंटेशन या टेम्पलेट से लोड किए गए चार्ट के साथ काम करने, और उन चार्ट्स की पहचान करने के बारे में सामान्य प्रश्नों के संक्षिप्त उत्तर भी शामिल करता है जहाँ डेटा टेबल सक्षम है।

## **चार्ट डेटा टेबल के लिए फ़ॉन्ट गुण सेट करें**
Aspose.Slides for PHP via Java श्रृंखला रंग में श्रेणियों के रंग को बदलने के लिए समर्थन प्रदान करता है।  

1. एक [Presentation]​(https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास ऑब्जेक्ट का इंस्टैंस बनाएं।  
1. स्लाइड पर चार्ट जोड़ें।  
1. चार्ट टेबल सेट करें।  
1. फ़ॉन्ट की ऊँचाई सेट करें।  
1. संशोधित प्रेजेंटेशन सहेजें।  

नीचे उदाहरण दिया गया है।  

```php
  # खाली प्रस्तुति बनाना
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट के डेटा टेबल में मानों के बगल में छोटे लेजेंड कुंजियाँ दिखा सकता हूँ?**

हाँ। डेटा टेबल [लेजेंड कुंजियाँ]​(https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setshowlegendkey/) को समर्थन करता है, और आप उन्हें चालू या बंद कर सकते हैं।

**क्या प्रेजेंटेशन को PDF, HTML या छवियों में निर्यात करने पर डेटा टेबल संरक्षित रहेगा?**

हाँ। Aspose.Slides चार्ट को स्लाइड का हिस्सा के रूप में रेंडर करता है, इसलिए निर्यातित [PDF]​(/slides/hi/php-java/convert-powerpoint-to-pdf/)/[HTML]​(/slides/hi/php-java/convert-powerpoint-to-html/)/[छवि]​(/slides/hi/php-java/convert-powerpoint-to-png/) में डेटा टेबल वाला चार्ट शामिल होता है।

**क्या टेम्पलेट फ़ाइल से आए चार्ट्स के लिए डेटा टेबल सपोर्टेड हैं?**

हाँ। किसी भी चार्ट के लिए जो मौजूदा प्रेजेंटेशन या टेम्पलेट से लोड किया गया हो, आप चार्ट की प्रॉपर्टीज़ का उपयोग करके यह जांच और बदल सकते हैं कि डेटा टेबल [दिखाई देती है]​(https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/hasdatatable/) या नहीं।

**मैं फ़ाइल में किन चार्ट्स में डेटा टेबल सक्षम है, इसे जल्दी से कैसे खोज सकता हूँ?**

प्रत्येक चार्ट की वह प्रॉपर्टी देखें जो दर्शाती है कि डेटा टेबल [दिखाई देती है]​(https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/hasdatatable/) या नहीं, और स्लाइड्स को क्रमवार जांचें ताकि उन चार्ट्स की पहचान की जा सके जहाँ यह सक्षम है।