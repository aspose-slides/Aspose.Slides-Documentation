---
title: Treemap और Sunburst चार्ट में डेटा पॉइंट्स को PHP के माध्यम से कस्टमाइज़ करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap चार्ट
- Sunburst चार्ट
- डेटा पॉइंट
- लेबल रंग
- शाखा रंग
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ Treemap और Sunburst चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint फ़ॉर्मैट्स के अनुकूल है।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों के अलावा, दो “हाइरार्किकल” प्रकार हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst ग्राफ, Sunburst डायग्राम, Radial Chart, Radial Graph या Multi Level Pie Chart भी कहा जाता है). ये चार्ट हाइरार्किकल डेटा दिखाते हैं जिसे एक ट्री के रूप में व्यवस्थित किया जाता है - पत्तियों से लेकर शाखा के शीर्ष तक. पत्तियों को श्रृंखला डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक क्रमिक नेस्टेड समूह स्तर को संबंधित श्रेणी द्वारा परिभाषित किया जाता है. Aspose.Slides for PHP via Java Sunburst चार्ट और Treemap के डेटा पॉइंट्स को फॉर्मेट करने की अनुमति देता है।

यहाँ एक Sunburst चार्ट है, जहाँ Series1 कॉलम का डेटा पत्तियों को परिभाषित करता है, जबकि अन्य कॉलम हाइरार्किकल डेटा पॉइंट्स को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

आइए एक नया Sunburst चार्ट प्रस्तुति में जोड़ना शुरू करें:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" title="देखें" %}} 
- [**PHP में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें**](/slides/hi/php-java/create-chart/)
{{% /alert %}}

यदि चार्ट के डेटा पॉइंट्स को फॉर्मेट करने की आवश्यकता है, तो हमें निम्नलिखित का उपयोग करना चाहिए:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevelsmanager/), 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/) वर्ग और [**ChartDataPoint::getDataPointLevels**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) मेथड Treemap और Sunburst चार्ट के डेटा पॉइंट्स को फॉर्मेट करने के लिए एक्सेस प्रदान करते हैं। 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevelsmanager/) का उपयोग मल्टी‑लेवल श्रेणियों तक पहुँचने के लिए किया जाता है - यह [**ChartDataPointLevel**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/) ऑब्जेक्ट्स का कंटेनर दर्शाता है। मूल रूप से यह [**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartcategorylevelsmanager/) का एक रैपर है जिसमें डेटा पॉइंट्स के लिये विशिष्ट जोड़ी गई प्रॉपर्टीज़ हैं। [**ChartDataPointLevel**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/) क्लास के दो मेथड हैं: [**getFormat**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/#getFormat) और [**getDataLabel**](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chartdatapointlevel/#getLabel) जो संबंधित सेटिंग्स तक पहुँच प्रदान करते हैं।

## **डेटा पॉइंट मान दिखाएँ**
"Leaf 4" डेटा पॉइंट का मान दिखाएँ:

```php
  $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
  $dataPoints->get_Item(3)->getDataPointLevels()->get_Item(0)->getLabel()->getDataLabelFormat()->setShowValue(true);

```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा पॉइंट लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिए सेट करें। फिर टेक्स्ट का रंग पीला सेट करें:

```php
  $branch1Label = $dataPoints->get_Item(0)->getDataPointLevels()->get_Item(0)->getLabel();
  $branch1Label->getDataLabelFormat()->setShowCategoryName(false);
  $branch1Label->getDataLabelFormat()->setShowSeriesName(true);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
  $branch1Label->getDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा पॉइंट शाखा का रंग सेट करें**
"Steam 4" शाखा का रंग बदलें:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 100, 100, 450, 400);
    $dataPoints = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints();
    $stem4branch = $dataPoints->get_Item(9)->getDataPointLevels()->get_Item(1);
    $stem4branch->getFormat()->getFill()->setFillType(FillType::Solid);
    $stem4branch->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में सेगमेंट्स का क्रम (सॉर्टिंग) बदल सकता हूँ?**

नहीं। PowerPoint सेगमेंट्स को स्वचालित रूप से सॉर्ट करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में)। Aspose.Slides इस व्यवहार को दोहराता है: आप क्रम को सीधे बदल नहीं सकते; आपको यह डेटा को पूर्व‑प्रसंस्करण करके प्राप्त करना होगा।

**प्रेजेंटेशन थीम सेगमेंट्स और लेबल्स के रंगों को कैसे प्रभावित करती है?**

चार्ट के रंग प्रस्तुति के [theme/palette](/slides/hi/php-java/presentation-theme/) को विरासत में लेते हैं जब तक आप स्पष्ट रूप से भराव/फ़ॉन्ट सेट नहीं करते। सुसंगत परिणामों के लिए, आवश्यक स्तरों पर सॉलिड भराव और टेक्स्ट फॉर्मेटिंग को लॉक रखें।

**क्या PDF/PNG में निर्यात करने पर कस्टम शाखा रंग और लेबल सेटिंग्स बरकरार रहती हैं?**

हाँ। जब प्रस्तुति को PDF/PNG में एक्सपोर्ट किया जाता है, तो चार्ट सेटिंग्स (भराव, लेबल) आउटपुट फ़ॉर्मेट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फॉर्मेटिंग को लागू करके रेंडर करता है।

**क्या मैं लेबल/एलिमेंट के वास्तविक कॉर्डिनेट्स की गणना कर सकता हूँ ताकि कस्टम ओवरले को चार्ट के ऊपर ठीक‑ठीक रखा जा सके?**

हाँ। चार्ट लेआउट वैध होने के बाद, तत्वों के लिए वास्तविक *x* और वास्तविक *y* उपलब्ध होते हैं (उदाहरण के लिये, एक [DataLabel](https://reference.aspose.com/slides/hi/php-java/aspose.slides/datalabel/)), जो ओवरले की सटीक पोजिशनिंग में मदद करता है।