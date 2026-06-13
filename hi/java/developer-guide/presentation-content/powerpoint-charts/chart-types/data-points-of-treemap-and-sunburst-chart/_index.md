---
title: Java का उपयोग करके Treemap और Sunburst चार्ट में डेटा पॉइंट्स को अनुकूलित करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- treemap चार्ट
- sunburst चार्ट
- डेटा पॉइंट
- लेबल रंग
- शाखा रंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ treemap और sunburst चार्ट में डेटा पॉइंट्स को प्रबंधित करना सीखें, जो PowerPoint फ़ॉर्मेट्स के साथ संगत हैं।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों के बीच, दो "हाइरार्किकल" प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph या Multi Level Pie Chart भी कहा जाता है). ये चार्ट पेड़ की तरह व्यवस्थित हाइरार्किकल डेटा दिखाते हैं - पत्तियों से शाखा के शीर्ष तक. पत्तियों को श्रृंखला डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक अगले नेस्टेड ग्रुपिंग स्तर को संबंधित श्रेणी द्वारा परिभाषित किया जाता है. Aspose.Slides for Java Java में Sunburst Chart और Treemap के डेटा पॉइंट्स को फ़ॉर्मेट करने की अनुमति देता है।

यहाँ एक Sunburst Chart है, जहाँ Series1 कॉलम में डेटा पत्ती नोड्स को परिभाषित करता है, जबकि अन्य कॉलम हाइरार्किकल डेटा पॉइंट्स को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

आइए प्रस्तुति में एक नया Sunburst chart जोड़ना शुरू करते हैं:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="और देखें" %}} 
- [**PowerPoint प्रस्तुति चार्ट को Java में बनाना या अपडेट करना**](/slides/hi/java/create-chart/)
{{% /alert %}}

यदि चार्ट के डेटा पॉइंट्स को फ़ॉर्मेट करने की आवश्यकता है, तो हमें निम्नलिखित का उपयोग करना चाहिए:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevel) क्लासेज 
और [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPoint#getDataPointLevels--) मेथड 
Treemap और Sunburst चार्ट के डेटा पॉइंट्स को फ़ॉर्मेट करने की पहुँच प्रदान करते हैं। 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevelsManager) 
मल्टी‑लेवल श्रेणियों तक पहुँचने के लिए उपयोग किया जाता है - यह 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevel) ऑब्जेक्ट्स के कंटेनर का प्रतिनिधित्व करता है। 
व्यवहार में यह 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartCategoryLevelsManager) के लिए एक रैपर है, जिसमें डेटा पॉइंट्स के लिए विशिष्ट प्रॉपर्टीज़ जोड़ी गई हैं। 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevel) क्लास में दो मेथड्स हैं: [**getFormat**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevel#getFormat--) और 
[**getDataLabel**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IChartDataPointLevel#getLabel--) जो संबंधित सेटिंग्स तक पहुँच प्रदान करते हैं।
## **डेटा पॉइंट वैल्यू दिखाएँ**
"Leaf 4" डेटा पॉइंट का मान दिखाएँ:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा पॉइंट लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिए सेट करें। फिर टेक्स्ट का रंग पीला सेट करें:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा पॉइंट शाखा का रंग सेट करें**
"Steam 4" शाखा का रंग बदलें:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में सेगमेंट्स का क्रम (सॉर्टिंग) बदल सकता हूँ?**

नहीं। PowerPoint सेगमेंट्स को स्वचालित रूप से (आम तौर पर घटते मानों के अनुसार, घड़ी की दिशा में) सॉर्ट करता है। Aspose.Slides इस व्यवहार को दोहराता है: आप क्रम को सीधे नहीं बदल सकते; डेटा को पूर्व‑प्रसंस्करण करके यही हासिल किया जाता है।

**प्रेजेंटेशन थीम सेगमेंट्स और लेबल्स के रंगों को कैसे प्रभावित करती है?**

जब तक आप स्पष्ट रूप से फ़िल्स/फ़ॉन्ट्स सेट नहीं करते, तब तक चार्ट के रंग प्रेजेंटेशन की [theme/palette](/slides/hi/java/presentation-theme/) को विरासत में लेते हैं। सुसंगत परिणामों के लिए, आवश्यक स्तरों पर सॉलिड फ़िल्स और टेक्स्ट फ़ॉर्मेटिंग को लॉक कर दें।

**क्या PDF/PNG में निर्यात करने पर कस्टम शाखा रंग और लेबल सेटिंग्स बनी रहेंगी?**

हां। प्रेजेंटेशन को निर्यात करते समय, चार्ट सेटिंग्स (फ़िल्स, लेबल्स) आउटपुट फॉर्मेट्स में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मेटिंग को लागू करके रेंडर करता है।

**क्या मैं चार्ट के ऊपर कस्टम ओवरले प्लेसमेंट के लिए लेबल/एलिमेंट के वास्तविक निर्देशांक गणना कर सकता हूँ?**

हां। चार्ट लेआउट के मान्य होने के बाद, तत्वों (उदाहरण के लिए, DataLabel) के लिए वास्तविक x और वास्तविक y उपलब्ध होते हैं, जो ओवरले को सटीक रूप से पोजिशन करने में मदद करते हैं।