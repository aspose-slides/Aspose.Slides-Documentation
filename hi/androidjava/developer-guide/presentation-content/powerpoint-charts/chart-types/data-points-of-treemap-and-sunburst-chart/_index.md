---
title: Android पर Treemap और Sunburst चार्ट में डेटा पॉइंट्स को कस्टमाइज़ करें
linktitle: Treemap और Sunburst चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ट्रीमैप चार्ट
- सनबर्स्ट चार्ट
- डेटा पॉइंट
- लेबल रंग
- ब्रांच रंग
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ ट्रीमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को प्रबंधित करने के तरीके सीखें, जो PowerPoint फ़ॉर्मैट के साथ संगत है।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों में, दो “हाइरार्किकल” प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph या Multi Level Pie Chart के रूप में भी जाना जाता है). ये चार्ट पेड़ के रूप में व्यवस्थित हाइरार्किकल डेटा को प्रदर्शित करते हैं - पत्तियों से लेकर शाखा के शीर्ष तक. पत्तियों को श्रृंखला डेटा पॉइंट्स द्वारा परिभाषित किया जाता है, और प्रत्येक अगले नेस्टेड समूह स्तर को संबंधित श्रेणी द्वारा परिभाषित किया जाता है. Aspose.Slides for Android via Java जावा में Sunburst Chart और Treemap के डेटा पॉइंट्स को फॉर्मेट करने की अनुमति देता है.

यहाँ एक Sunburst Chart है, जहाँ Series1 कॉलम का डेटा पत्ती नोड्स को परिभाषित करता है, जबकि अन्य कॉलम हाइरार्किकल डेटा पॉइंट्स को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

चलिए प्रस्तुति में नया Sunburst चार्ट जोड़ना शुरू करते हैं:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="संबंधित देखें" %}} 
- [**Android पर PowerPoint प्रेजेंटेशन चार्ट बनाना या अपडेट करना**](/slides/hi/androidjava/create-chart/)
{{% /alert %}}

यदि चार्ट के डेटा पॉइंट्स को फॉर्मेट करने की आवश्यकता है, तो हमें निम्नलिखित का उपयोग करना चाहिए:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevel) क्लासेस 
और [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) मेथड 
Treemap और Sunburst चार्ट के डेटा पॉइंट्स को फॉर्मेट करने की पहुँच प्रदान करता है। 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevelsManager) मल्टी‑लेवल श्रेणियों तक पहुँचने के लिए उपयोग किया जाता है - यह [**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevel) ऑब्जेक्ट्स का कंटेनर प्रतिनिधित्व करता है. असल में यह [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartCategoryLevelsManager) का रैपर है, जिसमें डेटा पॉइंट्स के लिए विशिष्ट रूप से जोड़ी गई प्रॉपर्टीज़ हैं. 
[**IChartDataPointLevel**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevel) क्लास में दो मेथड हैं: [**getFormat**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) और [**getDataLabel**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) जो संबंधित सेटिंग्स तक पहुँच प्रदान करते हैं.

## **डेटा पॉइंट मान दिखाएँ**
“Leaf 4” डेटा पॉइंट का मान दिखाएँ:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा पॉइंट लेबल और रंग सेट करें**
“Branch 1” डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम (“Series1”) दिखाने के लिए सेट करें. फिर टेक्स्ट रंग को पीला सेट करें:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा पॉइंट शाखा रंग सेट करें**
“Steam 4” शाखा का रंग बदलें:

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

नहीं। PowerPoint स्वचालित रूप से सेगमेंट्स को सॉर्ट करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में). Aspose.Slides इस व्यवहार को दोहराता है: आप क्रम को सीधे नहीं बदल सकते; आपको डेटा पूर्व‑प्रसंस्करण द्वारा यह प्राप्त करना होगा.

**प्रेजेंटेशन थीम सेगमेंट्स और लेबल्स के रंगों को कैसे प्रभावित करती है?**

यदि आप स्पष्ट रूप से फ़िल्स/फ़ॉन्ट सेट नहीं करते हैं तो चार्ट के रंग प्रस्तुति के [थीम/पैलेट](/slides/hi/androidjava/presentation-theme/) को विरासत में प्राप्त करते हैं। सुसंगत परिणामों के लिए, आवश्यक स्तरों पर ठोस फ़िल्स और टेक्स्ट फ़ॉर्मेटिंग को लॉक कर दें.

**क्या PDF/PNG में एक्सपोर्ट करने से कस्टम शाखा रंग और लेबल सेटिंग्स संरक्षित रहेंगी?**

हां। जब प्रस्तुति को एक्सपोर्ट किया जाता है, तो चार्ट सेटिंग्स (फ़िल्स, लेबल) आउटपुट फ़ॉर्मेट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मेटिंग के साथ रेंडर करता है.

**क्या मैं लेबल/एलिमेंट के वास्तविक निर्देशांक निकाल सकता हूँ ताकि चार्ट के ऊपर कस्टम ओवरले प्लेसमेंट किया जा सके?**

हां। चार्ट लेआउट वैलिडेट होने के बाद, तत्वों (उदाहरण के लिए, एक [DataLabel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/datalabel/)) के लिए वास्तविक *x* और वास्तविक *y* उपलब्ध होते हैं, जिससे ओवरले की सटीक स्थिति निर्धारित करने में मदद मिलती है।