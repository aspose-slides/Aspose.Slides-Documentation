---
title: ट्रेमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को JavaScript का उपयोग करके अनुकूलित करें
linktitle: ट्रेमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स
type: docs
url: /hi/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- ट्रेमैप चार्ट
- सनबर्स्ट चार्ट
- डेटा पॉइंट
- लेबल रंग
- ब्रांच रंग
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js via Java का उपयोग करके ट्रेमैप और सनबर्स्ट चार्ट में डेटा पॉइंट्स को कैसे प्रबंधित करें, PowerPoint फ़ॉर्मैट्स के साथ संगत।"
---
## **परिचय**

PowerPoint चार्ट के अन्य प्रकारों में, दो "पदानुक्रमिक" प्रकार होते हैं - **Treemap** और **Sunburst** चार्ट (जिसे Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph या Multi Level Pie Chart भी कहा जाता है)। ये चार्ट एक पेड़ के रूप में व्यवस्थित पदानुक्रमिक डेटा को प्रदर्शित करते हैं - पत्तियों से शाखा के शीर्ष तक। पत्तियों को श्रृंखला डेटा बिंदुओं द्वारा परिभाषित किया जाता है, और प्रत्येक क्रमिक नेस्टेड समूह स्तर को संबंधित वर्ग द्वारा परिभाषित किया जाता है। Aspose.Slides for Node.js via Java जावास्क्रिप्ट में Sunburst Chart और Treemap के डेटा बिंदुओं को स्वरूपित करने की अनुमति देता है।

यहाँ एक Sunburst चार्ट है, जहाँ Series1 कॉलम में डेटा पत्ती नोड्स को परिभाषित करता है, जबकि अन्य कॉलम पदानुक्रमित डेटा बिंदुओं को परिभाषित करते हैं:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

आइए प्रस्तुति में एक नया Sunburst चार्ट जोड़ना शुरू करते हैं:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="और देखें" %}} 
- [**JavaScript में PowerPoint प्रस्तुति चार्ट बनाएँ या अपडेट करें**](/slides/hi/nodejs-java/create-chart/)
{{% /alert %}}

यदि चार्ट के डेटा बिंदुओं को स्वरूपित करने की आवश्यकता हो, तो हमें निम्नलिखित का उपयोग करना चाहिए:
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevel) क्लासेस 
और [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) मेथड 
Treemap और Sunburst चार्ट के डेटा बिंदुओं को स्वरूपित करने के लिए पहुंच प्रदान करते हैं। 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevelsManager) 
बहु‑स्तरीय वर्गों तक पहुंचने के लिए उपयोग किया जाता है - यह 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevel) ऑब्जेक्ट्स का कंटेनर दर्शाता है। 
बुनियादी रूप से यह 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartCategoryLevelsManager) के लिए एक रैपर है जिसमें डेटा बिंदुओं के लिए विशिष्ट गुण जोड़े गए हैं। 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevel) क्लास के दो मेथड हैं: 
[**getFormat**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) और 
[**getDataLabel**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) जो संबंधित सेटिंग्स तक पहुंच प्रदान करते हैं।

## **डेटा बिंदु मान दिखाएँ**
"Leaf 4" डेटा बिंदु का मान दिखाएँ:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **डेटा बिंदु लेबल और रंग सेट करें**
"Branch 1" डेटा लेबल को श्रेणी नाम के बजाय श्रृंखला नाम ("Series1") दिखाने के लिए सेट करें। फिर टेक्स्ट रंग को पीले में सेट करें:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **डेटा बिंदु ब्रांच रंग सेट करें**
"Steam 4" ब्रांच का रंग बदलें:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Sunburst/Treemap में सेगमेंट्स का क्रम (सॉर्टिंग) बदल सकता हूँ?**  
नहीं। PowerPoint स्वचालित रूप से सेगमेंट्स को सॉर्ट करता है (आमतौर पर घटते मानों के अनुसार, घड़ी की दिशा में)। Aspose.Slides इस व्यवहार की नकल करता है: आप क्रम को सीधे नहीं बदल सकते; आपको डेटा को पूर्व‑प्रसंस्करण करके यह हासिल करना होगा।

**प्रेज़ेंटेशन थीम सेगमेंट्स और लेबल्स के रंगों को कैसे प्रभावित करती है?**  
जब तक आप स्पष्ट रूप से फिल/फ़ॉन्ट सेट नहीं करते, चार्ट के रंग प्रेज़ेंटेशन की [थीम/पैलेट](/slides/hi/nodejs-java/presentation-theme/) को वंशानुगत रूप से प्राप्त करते हैं। सुसंगत परिणामों के लिए, आवश्यक स्तरों पर ठोस फिल और टेक्स्ट फ़ॉर्मेटिंग को लॉक कर दें।

**क्या PDF/PNG में निर्यात करने से कस्टम ब्रांच रंग और लेबल सेटिंग्स सुरक्षित रहेंगी?**  
हां। प्रेज़ेंटेशन को निर्यात करते समय, चार्ट सेटिंग्स (फ़िल्स, लेबल्स) आउटपुट फ़ॉर्मैट में संरक्षित रहती हैं क्योंकि Aspose.Slides चार्ट के फ़ॉर्मैटिंग के साथ रेंडर करता है।

**क्या मैं चार्ट के ऊपर कस्टम ओवरले प्लेसमेंट के लिए लेबल/तत्व के वास्तविक निर्देशांक गणना कर सकता हूँ?**  
हां। चार्ट लेआउट की वैधता के बाद, तत्वों (जैसे, एक [DataLabel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/datalabel/)) के लिए वास्तविक X और वास्तविक Y उपलब्ध होते हैं, जो ओवरले की सटीक स्थिति निर्धारित करने में मदद करता है।