---
title: "PHP का उपयोग करके प्रस्तुतियों में चार्ट डेटा तालिकाओं को अनुकूलित करें"
linktitle: "डेटा तालिका"
type: docs
url: /hi/php-java/chart-data-table/
keywords:
- "चार्ट डेटा"
- "डेटा तालिका"
- "फ़ॉन्ट गुण"
- "PowerPoint"
- "प्रस्तुति"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा तालिका के फ़ॉन्ट, बॉर्डर और लीजेंड कुंजियों को अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides for PHP via Java आपको चार्ट की डेटा तालिका प्रदर्शित करने और उसके टेक्स्ट फ़ॉर्मेटिंग, बॉर्डर और लीजेंड कुंजियों को अनुकूलित करने की अनुमति देता है। यह लेख बताता है कि तालिका को कैसे सक्षम करें, उसके टेक्स्ट को कैसे फ़ॉर्मेट करें, प्रत्येक प्रकार के बॉर्डर को कैसे नियंत्रित करें, और लीजेंड कुंजियों को कैसे दिखाएँ या छिपाएँ। उदाहरण कॉन्फ़िगर किए गए चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

चार्ट की डेटा तालिका प्रदर्शित करने के लिए, [setDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setdatatable/) को `true` पास करें। तालिका तक पहुंचने और उसके टेक्स्ट फ़ॉर्मेटिंग को कॉन्फ़़िगर करने के लिए [getChartDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/getchartdatatable/) का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
1. पहली स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा तालिका सक्षम करें।
1. [setFontBold](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontBold) से बोल्ड टेक्स्ट सक्षम करें और 20‑पॉइंट टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight) को `20` पास करें।
1. संशोधित प्रस्तुति सहेजें।

निम्नलिखित उदाहरण को कार्य निर्देशिका में कम से कम एक स्लाइड वाली `test.pptx` फ़ाइल की आवश्यकता होती है। यह (50, 50) स्थिति पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजी गई `output.pptx` में चार्ट के साथ उसकी डेटा तालिका सक्षम और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू होती हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **डेटा तालिका बॉर्डर अनुकूलित करें**

टेबल को [Chart::setDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setdatatable/) से सक्षम करें और इसे [Chart::getChartDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/getchartdatatable/) के माध्यम से एक्सेस करें। आप तीन प्रकार के बॉर्डर को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [setBorderHorizontal](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setborderhorizontal/) क्षैतिज सेल बॉर्डर को नियंत्रित करता है।
- [setBorderVertical](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setbordervertical/) लंबवत सेल बॉर्डर को नियंत्रित करता है।
- [setBorderOutline](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setborderoutline/) तालिका की बाहरी सीमा को नियंत्रित करता है।

प्रत्येक मेथड को `true` पास करने पर उसके बॉर्डर प्रदर्शित होते हैं, या `false` पास करने पर छिपे होते हैं। निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज बॉर्डर और बाहरी बॉर्डर दिखाता है, और लंबवत बॉर्डर को छिपाता है। इसे कोई इनपुट फ़ाइल नहीं चाहिए। चार्ट की स्थिति और आकार पॉइंट में निर्दिष्ट हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

नीचे दिया गया तुलना सभी चार मामलों में समान चार्ट डेटा और लीजेंड कुंजी सेटिंग का उपयोग करता है। सभी बॉर्डर सक्षम होने से शुरू करके, प्रत्येक शेष वेरिएंट केवल एक बॉर्डर सेटिंग को अक्षम करता है। निचला-बायां वेरिएंट उदाहरण में बॉर्डर सेटिंग के समान है।

![सभी बॉर्डर सक्षम, कोई क्षैतिज बॉर्डर नहीं, कोई लंबवत बॉर्डर नहीं, और कोई बाहरी बॉर्डर नहीं के साथ चार्ट डेटा टेबल](data-table-borders.png)

## **लीजेंड कुंजियों को दिखाएँ या छिपाएँ**

लीजेंड कुंजियाँ डेटा तालिका में सीरीज़ नामों के बगल में छोटे रंगीन मार्कर होते हैं। वे पाठकों को प्रत्येक तालिका पंक्ति को चार्ट सीरीज़ से मिलान करने में मदद करती हैं। इन मार्करों को दिखाने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setshowlegendkey/) को `true` पास करें या उन्हें छिपाने के लिए `false` पास करें।

चार्ट की अलग लीजेंड को [Chart::setLegend](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setlegend/) द्वारा नियंत्रित किया जाता है। ये सेटिंग्स स्वतंत्र हैं: अलग लीजेंड को छिपाने से डेटा तालिका के भीतर की कुंजियाँ नहीं छिपतीं, और तालिका की कुंजियों को छिपाने से अलग लीजेंड नहीं छिपती।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा तालिका को सक्षम करता है, और अलग लीजेंड को छिपाते हुए उसमें लीजेंड कुंजियों को दिखाता है। सभी तालिका बॉर्डर स्पष्ट रूप से सक्षम हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। केवल तालिका की कुंजियों को छिपाने के लिए, [setShowLegendKey](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setshowlegendkey/) को `false` पास करें।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

नीचे दी गई तुलना एक ही तालिका को लीजेंड कुंजियों के सक्षम और अक्षम रूप में दिखाती है। सभी बॉर्डर सक्रिय रहते हैं, और अलग चार्ट लीजेंड दोनों मामलों में छिपा रहता है।

![बाएँ ओर लीजेंड कुंजियों के साथ दिखाए गए और दाएँ ओर छिपाए गए चार्ट डेटा टेबल](data-table-legend-keys.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट की डेटा तालिका में लीजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। लीजेंड कुंजियों को प्रदर्शित करने के लिए [setShowLegendKey](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datatable/setshowlegendkey/) को `true` पास करें या उन्हें छिपाने के लिए `false` पास करें।

**क्या प्रस्तुति को PDF, HTML या इमेजेज में निर्यात करते समय डेटा तालिका संरक्षित रहेगी?**

हाँ। Aspose.Slides चार्ट और उसकी प्रदर्शित डेटा तालिका को स्लाइड का हिस्सा बनाकर निर्यात करते समय [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/php-java/convert-powerpoint-to-html/) या [images](/slides/hi/php-java/convert-powerpoint-to-png/) में रेंडर करता है।

**क्या मैं टेम्पलेट से लोड किए गए चार्ट की डेटा तालिकाओं के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रस्तुति या टेम्पलेट से लोड किए गए चार्ट के लिए, उसकी डेटा तालिका के प्रदर्शित होने की जाँच या परिवर्तन करने हेतु [hasDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/hasdatatable/) और [setDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/setdatatable/) का उपयोग करें।

**मैं उन चार्ट्स को कैसे खोजूँ जिनकी डेटा तालिका सक्षम है?**

प्रत्येक स्लाइड पर आकारों (shapes) की सूची बनाते हुए, चार्ट को पहचानें, और उनकी [hasDataTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/hasdatatable/) मेथड को कॉल करें। `true` मान दर्शाता है कि डेटा तालिका सक्षम है।