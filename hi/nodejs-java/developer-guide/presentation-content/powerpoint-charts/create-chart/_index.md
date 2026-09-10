---
title: JavaScript में PowerPoint प्रस्तुति चार्ट बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/nodejs-java/create-chart/
keywords:
- चार्ट जोड़ें
- चार्ट बनाएं
- चार्ट संपादित करें
- चार्ट बदलें
- चार्ट अपडेट करें
- स्कैटर चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स एंड व्हिस्कर चार्ट
- फनल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रडार चार्ट
- मल्टीकैटेगरी चार्ट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। JavaScript में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फॉर्मैट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, डेटा के साथ उसे कैसे भरें, और अपनी विशिष्ट डिजाइन आवश्यकताओं के अनुसार विभिन्न फ़ॉर्मेटिंग विकल्प कैसे लागू करें। लेख के दौरान, विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रारंभिक प्रस्तुति और चार्ट ऑब्जेक्ट से लेकर सीरीज़, अक्ष और लेजेंड्स को कॉन्फ़िगर करने तक। इस गाइड का पालन करके, आप अपने अनुप्रयोगों में डायनेमिक चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवेन प्रस्तुतियों को बनाना सुगम हो जाता है।

## **एक चार्ट बनाएं**

चार्ट लोगों को डेटा को जल्दी से विज़ुअलाइज़ करने और उन अंतर्दृष्टियों को प्राप्त करने में मदद करते हैं जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होतीं।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक प्रस्तुति में एक ही स्लाइड पर बड़ी मात्रा में डेटा को संक्षिप्त, संकलित या सारांशित करें
* डेटा में पैटर्न और रुझानों को उजागर करें
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति का अनुमान लगाएँ
* आउट्लायर, विचलन, त्रुटियों, बेमेल डेटा आदि को पहचानें
* जटिल डेटा को संप्रेषित या प्रस्तुत करें

PowerPoint में, आप *Insert* फ़ंक्शन के माध्यम से चार्ट बना सकते हैं, जो कई प्रकार के चार्ट डिज़ाइन करने के लिए टेम्प्लेट प्रदान करता है। Aspose.Slides का उपयोग करके आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" title="ध्यान दें" %}}
चार्ट बनाने के लिए, [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) क्लास का उपयोग करें। इस क्लास के फ़ील्ड विभिन्न चार्ट प्रकारों से मेल खाते हैं।
{{% /alert %}}

### **क्लस्टरड कॉलम चार्ट बनाएं**

यह सेक्शन Aspose.Slides का उपयोग करके क्लस्टरड कॉलम चार्ट बनाने के तरीके को समझाता है। आप प्रस्तुति को शुरुआती बनाना, एक चार्ट जोड़ना और उसके तत्वों जैसे शीर्षक, डेटा, सीरीज़, श्रेणियों और स्टाइलिंग को कस्टमाइज़ करना सीखेंगे। नीचे दिए गए चरणों का पालन करके देखें कि मानक क्लस्टरड कॉलम चार्ट कैसे उत्पन्न किया जाता है:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और `ChartType.ClusteredColumn` प्रकार निर्दिष्ट करें।
4. चार्ट में एक शीर्षक जोड़ें।
5. चार्ट के डेटा वर्कशीट तक पहुंचें।
6. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
7. नई सीरीज़ और श्रेणियां जोड़ें।
8. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
9. चार्ट सीरीज़ पर एक फिल रंग लागू करें।
10. चार्ट सीरीज़ में लेबल जोड़ें।
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह C# कोड एक क्लस्टरड कॉलम चार्ट बनाने का उदाहरण दर्शाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टेंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var sld = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // चार्ट शीर्षक सेट करता है
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // पहली सीरीज़ को मान दिखाने के लिए सेट करता है
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // नई सीरीज़ जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // नई श्रेणियां जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // पहली चार्ट सीरीज़ लेता है
    var series = chart.getChartData().getSeries().get_Item(0);
    // अब सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // सीरीज़ के लिए फ़िल रंग सेट करता है
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    // सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // सीरीज़ के लिए फ़िल रंग सेट करता है
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // नई सीरीज़ के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाता है
    // पहला लेबल कैटेगरी नाम दिखाने के लिए सेट करता है
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // तीसरे लेबल के लिए मान दिखाता है
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // चार्ट के साथ प्रस्तुति को सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **स्कैटर चार्ट बनाएं**

स्कैटर चार्ट (जिन्हें स्कैटर प्लॉट या X‑Y ग्राफ भी कहा जाता है) अक्सर दो वेरिएबल्स के बीच पैटर्न या सहसंबंध दिखाने के लिए उपयोग किए जाते हैं।

स्कैटर चार्ट का उपयोग तब करें जब:

* आपके पास युग्मित संख्यात्मक डेटा है
* आपके पास दो वेरिएबल्स हैं जो एक साथ अच्छी तरह मिलते हैं
* आप निर्धारित करना चाहते हैं कि दो वेरिएबल्स संबंधित हैं या नहीं
* आपके पास एक स्वतंत्र वेरिएबल है जिसके कई मान आश्रित वेरिएबल के लिए हैं

1. [Create Clustered Column Charts](#create-clustered-column-charts) में वर्णित चरणों का पालन करें।
2. तीसरे चरण के लिए, एक चार्ट जोड़ें और अपने चार्ट प्रकार को निम्नलिखित में से एक चुनें:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _एक स्कैटर चार्ट दर्शाता है।_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _वक्रों द्वारा जुड़े स्कैटर चार्ट को डेटा मार्कर के साथ दर्शाता है।_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _वक्रों द्वारा जुड़े स्कैटर चार्ट को डेटा मार्कर के बिना दर्शाता है।_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _सीधियों द्वारा जुड़े स्कैटर चार्ट को डेटा मार्कर के साथ दर्शाता है।_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _सीधियों द्वारा जुड़े स्कैटर चार्ट को डेटा मार्कर के बिना दर्शाता है।_

यह JavaScript कोड प्रत्येक सीरीज़ के लिए विभिन्न मार्कर के साथ स्कैटर चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टेंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट चार्ट बनाता है
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // डेमो सीरीज़ हटाता है
    chart.getChartData().getSeries().clear();
    // नई सीरीज़ जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // पहली चार्ट सीरीज़ लेता है
    var series = chart.getChartData().getSeries().get_Item(0);
    // सीरीज़ में नया बिंदु (1:3) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // नया बिंदु (2:10) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // सीरीज़ प्रकार बदलता है
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    // उस में नया बिंदु (5:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // नया बिंदु (3:1) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // नया बिंदु (2:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // नया बिंदु (5:1) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में वर्गीय लेबल के साथ संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में कई भाग या लेबल हों, तो बार चार्ट का उपयोग करने पर विचार करें।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Pie](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Pie) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. पाई चार्ट के सेक्टरों के लिए कस्टम रंग लागू करके नई पॉइंट्स जोड़ें।
9. सीरीज़ के लिए लेबल सेट करें।
10. सीरीज़ लेबल के लिए लीडर लाइन्स सक्षम करें।
11. पाई चार्ट सेक्टरों के लिए घूर्णन कोण सेट करें।
12. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड पाई चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास को इंस्टेंसिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    var slides = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // पहली सीरीज़ को मान दिखाने के लिए सेट करता है
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // नई श्रेणियां जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // नई सीरीज़ जोड़ता है
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // नई संस्करण में काम नहीं कर रहा है
    // नए पॉइंट जोड़ रहा है और सेक्टर रंग सेट कर रहा है
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // सेक्टर बॉर्डर सेट करता है
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // सेक्टर बॉर्डर सेट करता है
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // सेक्टर बॉर्डर सेट करता है
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // नई सीरीज़ की प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // चार्ट के लिए लीडर लाइन्स दिखाता है
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // पाई चार्ट सेक्टरों के लिए रोटेशन एंगल सेट करता है
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // चार्ट के साथ प्रस्तुति को सहेजता है
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिन्हें लाइन ग्राफ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मानों में परिवर्तन दिखाना चाहते हैं। एक लाइन चार्ट का उपयोग करके आप बड़ी मात्रा में डेटा की तुलना, समय के साथ परिवर्तन और रुझान ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को हाइलाइट कर सकते हैं, आदि।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Line](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Line) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/)) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड लाइन चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधे सतत रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश रेखाओं से जोड़ना चाहते हैं, तो आप अपनी इच्छित डैश शैली इस प्रकार निर्दिष्ट कर सकते हैं:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा वर्गों के सापेक्ष आकार दिखाना तथा प्रत्येक वर्ग में बड़े योगदानकर्ताओं पर जल्दी ध्यान आकर्षित करना चाहते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Treemap](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Treemap) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड ट्री मैप चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // शाखा 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // शाखा 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **स्टॉक चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#OpenHighLowClose) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. हाई‑लो लाइन्स फॉर्मेट निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड स्टॉक चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));
    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));
    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));
    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));
    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#BoxAndWhisker) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड बॉक्स एंड व्हिस्कर चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **फनल चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Funnel](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Funnel) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड फनल चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **सनबर्स्ट चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Sunburst](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Sunburst) प्रकार निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड सनबर्स्ट चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // शाखा 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");
    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));
    // शाखा 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");
    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");
    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **हिस्टोग्राम चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.Histogram](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Histogram) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड हिस्टोग्राम चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **रडार चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपने इच्छित चार्ट प्रकार ([ChartType.Radar](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#Radar) इस उदाहरण में) को निर्दिष्ट करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड रडार चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **मल्टी‑कैटेगरी चार्ट बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ClusteredColumn) प्रकार निर्दिष्ट करें।
4. चार्ट डेटा वर्कबुक [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया चार्ट डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड मल्टी‑कैटेगरी चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));
    // सीरीज़ जोड़ना
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // चार्ट के साथ प्रस्तुति सहेजें
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **मैप चार्ट बनाएं**

मैप चार्ट भौगोलिक डेटा को विज़ुअलाइज़ करते हैं और क्षेत्रों के बीच मानों की तुलना करने में मदद करते हैं।

यह JavaScript कोड मैप चार्ट बनाने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **कम्बीनेशन चार्ट बनाएं**

कम्बीनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेटों के बीच अंतर को हाइलाइट, तुलना या जांचने की अनुमति देता है, जिससे उनके बीच के संबंधों की पहचान करना आसान हो जाता है।

![The combination chart](combination_chart.png)

निम्नलिखित JavaScript कोड ऊपर दिखाए गए kombiनेशन चार्ट को PowerPoint प्रस्तुति में बनाने का उदाहरण दिखाता है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // चार्ट शीर्षक सेट करें।
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // चार्ट लेजेंड सेट करें।
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ।
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // नई श्रेणियां जोड़ें।
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // पहली सीरीज़ जोड़ें।
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // क्षैतिज अक्ष सेट करें।
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // ऊर्ध्वाधर अक्ष सेट करें।
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // ऊर्ध्वाधर प्रमुख ग्रिडलाइन का रंग सेट करें।
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.getInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // द्वितीयक क्षैतिज अक्ष सेट करें।
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // द्वितीयक ऊर्ध्वाधर अक्ष सेट करें।
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **चार्ट अपडेट करें**

1. उस प्रस्तुति का एक इंस्टेंस बनाएं जिसमें वह चार्ट हो जिसे आप अपडेट करना चाहते हैं, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करें।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. सभी आकारों (shapes) को पार करें ताकि इच्छित चार्ट मिल सके।
4. चार्ट के डेटा वर्कशीट तक पहुंचें।
5. सीरीज़ वैल्यू बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।
6. एक नई सीरीज़ जोड़ें और उसके डेटा को भरें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड चार्ट को अपडेट करने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // पहली स्लाइड मार्कर तक पहुँचें
    var sld = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ चार्ट प्राप्त करें
    var chart = sld.getShapes().get_Item(0);
    // चार्ट डेटा शीट का इंडेक्स सेट कर रहे हैं
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
    var fact = chart.getChartData().getChartDataWorkbook();
    // चार्ट श्रेणी नाम बदल रहे हैं
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // पहली चार्ट सीरीज़ लें
    var series = chart.getChartData().getSeries().get_Item(0);
    // अब सीरीज़ डेटा अपडेट कर रहे हैं
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // सीरीज़ नाम संशोधित कर रहे हैं
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // दूसरी चार्ट सीरीज़ लें
    series = chart.getChartData().getSeries().get_Item(1);
    // अब सीरीज़ डेटा अपडेट कर रहे हैं
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // सीरीज़ नाम संशोधित कर रहे हैं
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // अब, नई सीरीज़ जोड़ रहे हैं
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // तीसरी चार्ट सीरीज़ लें
    series = chart.getChartData().getSeries().get_Item(2);
    // अब सीरीज़ डेटा भर रहे हैं
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // चार्ट के साथ प्रस्तुति सहेजें
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **एक चार्ट के लिए डेटा रेंज सेट करें**

एक चार्ट के लिए डेटा रेंज सेट करने के लिए यह कदम उठाएँ:

1. उस प्रस्तुति का एक इंस्टेंस बनाएं जिसमें वह चार्ट हो, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उपयोग करें।
2. उसके इंडेक्स का उपयोग करके स्लाइड का एक रेफ़रेंस प्राप्त करें।
3. सभी आकारों को पार करें ताकि इच्छित चार्ट मिल सके।
4. चार्ट डेटा तक पहुंचें और रेंज सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड चार्ट के लिए डेटा रेंज सेट करने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करें**

जब आप चार्ट में डिफ़ॉल्ट मार्कर उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से एक अलग मार्कर प्रतीक मिलता है।

यह JavaScript कोड चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करने का उदाहरण दिखाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // दूसरी चार्ट सीरीज़ लें
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // अब सीरीज़ डेटा भर रहे हैं
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides किस प्रकार के चार्ट समर्थन करता है?**

Aspose.Slides विभिन्न प्रकार के [chart types](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) का समर्थन करता है, जिनमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रडार और कई अन्य शामिल हैं। यह लचीलापन आपको डेटा विज़ुअलाइज़ेशन की आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की सुविधा देता है।

**मैं किसी स्लाइड में नया चार्ट कैसे जोड़ूं?**

एक नया चार्ट जोड़ने के लिए, आप सबसे पहले [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने के मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट किया जाता है। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत कर देती है।

**मैं चार्ट में प्रदर्शित डेटा को कैसे अपडेट कर सकता हूं?**

आप चार्ट का डेटा अपडेट करने के लिए उसके डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/)) तक पहुंचते हैं, डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करते हैं, और फिर अपना कस्टम डेटा जोड़ते हैं। यह आपको प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा दर्शाने के लिए रिफ्रेश करने की अनुमति देता है।

**क्या चार्ट की उपस्थिति को कस्टमाइज़ करना संभव है?**

हाँ, Aspose.Slides विस्तृत कस्टमाइज़ेशन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य [formatting elements](/slides/hi/nodejs-java/chart-entities/) को बदलकर चार्ट की उपस्थिति को अपनी विशिष्ट डिजाइन आवश्यकताओं के अनुसार ढाल सकते हैं।