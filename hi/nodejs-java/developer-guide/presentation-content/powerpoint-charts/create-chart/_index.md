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
- स्कैटर्ड चार्ट
- पाई चार्ट
- लाइन चार्ट
- ट्री मैप चार्ट
- स्टॉक चार्ट
- बॉक्स एंड व्हिस्कर चार्ट
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकेटेगरी चार्ट
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। JavaScript में व्यावहारिक कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, डेटा से भरें, और अपने विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार विभिन्न फ़ॉर्मेटिंग विकल्प लागू करें। पूरे लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, प्रस्तुति और चार्ट ऑब्जेक्ट को इनिशियलाइज़ करने से लेकर सीरीज़, अक्ष और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके आप अपने अनुप्रयोगों में डायनेमिक चार्ट जनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा‑ड्रिवन प्रस्तुतियों का निर्माण सरल हो जाता है।

## **चार्ट बनाएं**
चार्ट लोगों को डेटा को शीघ्रता से विज़ुअलाइज़ करने और ऐसे अंतर्दृष्टि प्राप्त करने में मदद करते हैं, जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं होते।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप

* एक ही स्लाइड में बड़ी मात्रा के डेटा को संक्षिप्त, समेकित या सारांशित कर सकते हैं
* डेटा में पैटर्न और ट्रेंड प्रकट कर सकते हैं
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गतिकी का अनुमान लगा सकते हैं
* बाहरी मान, अपवर्जन, विचलन, त्रुटियां, असंगत डेटा आदि की पहचान कर सकते हैं
* जटिल डेटा को प्रभावी रूप से संप्रेषित या प्रस्तुत कर सकते हैं

PowerPoint में आप Insert फ़ंक्शन के माध्यम से विभिन्न प्रकार के चार्ट टेम्पलेट का उपयोग करके चार्ट बना सकते हैं। Aspose.Slides के साथ आप सामान्य चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="primary" %}} 

चार्ट बनाने के लिए Aspose.Slides [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType) क्लास प्रदान करता है। इस क्लास के फ़ील्ड विभिन्न चार्ट प्रकारों से संबंधित होते हैं।

{{% /alert %}} 

### **सामान्य चार्ट बनाना**

_चरण: चार्ट बनाएं_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>चरण:</em> JavaScript में PowerPoint चार्ट बनाएं</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>चरण:</em> JavaScript में प्रस्तुति चार्ट बनाएं</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>चरण:</em> JavaScript में PowerPoint प्रस्तुति चार्ट बनाएं</strong></a>

_कोड चरण:_

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंद का चार्ट प्रकार निर्दिष्ट करें। 
4. चार्ट के लिए शीर्षक जोड़ें। 
5. चार्ट डेटा वर्कशीट तक पहुंचें। 
6. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें। 
7. नई सीरीज़ और श्रेणियां जोड़ें। 
8. चार्ट सीरीज़ के लिए नया डेटा जोड़ें। 
9. चार्ट सीरीज़ के लिए भराव रंग जोड़ें। 
10. चार्ट सीरीज़ के लिए लेबल जोड़ें। 
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दिखाता है कि सामान्य चार्ट कैसे बनाएं:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति क्लास इंस्टैंशिएट करता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुंचता है
    var sld = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // चार्ट का शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // पहली सीरीज़ को मान दिखाने के लिए सेट करता है
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // डिफ़ॉल्ट उत्पन्न सीरीज़ और श्रेणियों को हटाता है
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
    // अब सीरीज़ डेटा को भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // सीरीज़ के लिए भराव रंग सेट करता है
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    // सीरीज़ डेटा को भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // सीरीज़ के लिए भराव रंग सेट करता है
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // नई सीरीज़ के प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
    // पहले लेबल को श्रेणी नाम दिखाने के लिए सेट करता है
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

### **स्कैटर्ड चार्ट बनाना**
स्कैटर्ड चार्ट (जिसे स्कैटर प्लॉट या x‑y ग्राफ़ भी कहा जाता है) अक्सर दो चर के बीच पैटर्न या सहसंबंध जांचने के लिए उपयोग किए जाते हैं।

आप स्कैटर्ड चार्ट का उपयोग तब करना चाहेंगे जब

* आपके पास युग्मबद्ध संख्यात्मक डेटा हो
* आपके पास दो चर हों जो एक साथ अच्छी तरह फिट होते हों
* आप यह निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं
* आपके पास एक स्वतंत्र चर हो जिसकी कई मान dependent चर के लिए हों

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>चरण:</em> JavaScript में Scattered Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Scattered Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Scattered Chart बनाएं</strong></a>

1. उपरोक्त [Creating Normal Charts](#creating-normal-charts) में उल्लेखित चरणों का पालन करें
2. तीसरे चरण में, एक चार्ट जोड़ें और चार्ट प्रकार को नीचे दिए गए विकल्पों में से एक चुनें
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _Scatter Chart प्रतिनिधित्व करता है।_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _曲线 के साथ जुड़े Scatter Chart, डेटा मार्कर सहित।_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _曲线 के साथ जुड़े Scatter Chart, डेटा मार्कर के बिना।_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _सीधे रेखा के साथ जुड़े Scatter Chart, डेटा मार्कर सहित।_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _सीधे रेखा के साथ जुड़े Scatter Chart, डेटा मार्कर के बिना।_

यह JavaScript कोड दिखाता है कि विभिन्न मार्कर सीरीज़ के साथ स्कैटर्ड चार्ट कैसे बनाएं:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति क्लास बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुंचता है
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
    // सीरीज़ में नया पॉइंट (1:3) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // नया पॉइंट (2:10) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // सीरीज़ प्रकार बदलता है
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    // वहाँ नया पॉइंट (5:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // नया पॉइंट (3:1) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // नया पॉइंट (2:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // नया पॉइंट (5:1) जोड़ता है
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

### **पाई चार्ट बनाना**

पाई चार्ट डेटा में भाग‑से‑पूरे संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल और संख्यात्मक मान हों। हालांकि, यदि आपके डेटा में बहुत अधिक भाग या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>चरण:</em> JavaScript में Pie Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Pie Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Pie Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें (इस मामले में, [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).Pie)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. चार्ट के सेक्टरों के लिए नई पॉइंट्स जोड़ें और कस्टम रंग लागू करें।
9. सीरीज़ के लिए लेबल सेट करें।
10. सीरीज़ लेबल के लिए लीडर लाइन्स सेट करें।
11. पाई चार्ट स्लाइड के लिए घुमाव कोण सेट करें।
12. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि पाई चार्ट कैसे बनाएं:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाला प्रस्तुति क्लास बनाता है
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइड तक पहुंचता है
    var slides = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // पहली सीरीज़ को मान दिखाने के लिए सेट करता है
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    var fact = chart.getChartData().getChartDataWorkbook();
    // डिफ़ॉल्ट उत्पन्न सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // नई श्रेणियां जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // नई सीरीज़ जोड़ता है
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // सीरीज़ डेटा को भरता है
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // नए संस्करण में काम नहीं कर रहा है
    // नया पॉइंट जोड़ रहा है और सेक्टर रंग सेट कर रहा है
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // सेक्टर बॉर्डर सेट करता है
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // सेक्टर बॉर्डर सेट करता है
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // सेक्टर बॉर्डर सेट करता है
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // नई सीरीज़ के प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
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
    // पाई चार्ट सेक्टरों के लिए घुमाव कोण सेट करता है
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // चार्ट के साथ प्रस्तुति को सहेजता है
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **लाइन चार्ट बनाना**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मान में परिवर्तन दर्शाना चाहते हैं। लाइन चार्ट के माध्यम से आप एक साथ कई डेटा तुलना कर सकते हैं, समय के साथ परिवर्तन और ट्रेंड ट्रैक कर सकते हैं, डेटा सीरीज़ में विसंगतियों को हाइलाइट कर सकते हैं, आदि।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
1. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें (इस मामले में, `ChartType.Line`)।
1. चार्ट डेटा IChartDataWorkbook तक पहुंचें।
1. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
1. नई सीरीज़ और श्रेणियां जोड़ें।
1. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि लाइन चार्ट कैसे बनाएं:

```javascript
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

डिफ़ॉल्ट रूप से, लाइन चार्ट के पॉइंट्स सीधे सतत रेखाओं द्वारा जुड़े होते हैं। यदि आप चाहते हैं कि पॉइंट्स डैश द्वारा जुड़े हों, तो आप अपने पसंदीदा डैश प्रकार को इस प्रकार निर्दिष्ट कर सकते हैं:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **ट्री मैप चार्ट बनाना**

ट्री मैप चार्ट बिक्री डेटा में उपयोगी होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और साथ ही प्रत्येक श्रेणी में बड़े योगदानकों पर जल्दी से ध्यान आकर्षित करना चाहते हैं।

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>चरण:</em> JavaScript में Tree Map Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Tree Map Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Tree Map Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें (इस मामले में, [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).TreeMap)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि ट्री मैप चार्ट कैसे बनाएं:

```javascript
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

### **स्टॉक चार्ट बनाना**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>चरण:</em> JavaScript में Stock Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Stock Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Stock Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें ([ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).OpenHighLowClose)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. HiLowLines फ़ॉर्मेट निर्दिष्ट करें।
9. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

स्टॉक चार्ट बनाने के लिए उपयोग किया गया नमूना JavaScript कोड:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

### **बॉक्स एंड व्हिस्कर चार्ट बनाना**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>चरण:</em> JavaScript में Box and Whisker Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Box and Whisker Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Box and Whisker Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें ([ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).BoxAndWhisker)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि बॉक्स एंड व्हिस्कर चार्ट कैसे बनाएं:

```javascript
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

### **फ़नल चार्ट बनाना**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>चरण:</em> JavaScript में Funnel Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Funnel Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Funnel Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें ([ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).Funnel)।
4. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि फ़नल चार्ट कैसे बनाएं:

```javascript
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

### **सनबर्स्ट चार्ट बनाना**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>चरण:</em> JavaScript में Sunburst Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Sunburst Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Sunburst Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें (इस मामले में, [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).sunburst)।
4. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि सनबर्स्ट चार्ट कैसे बनाएं:

```javascript
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

### **हिस्टोग्राम चार्ट बनाना**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>चरण:</em> JavaScript में Histogram Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Histogram Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Histogram Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांछित प्रकार चुनें ([ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).Histogram)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि हिस्टोग्राम चार्ट कैसे बनाएं:

```javascript
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

### **रेडार चार्ट बनाना**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>चरण:</em> JavaScript में Radar Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Radar Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Radar Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें। 
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंद का चार्ट प्रकार निर्दिष्ट करें (`ChartType.Radar` इस मामले में)।
4. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि रेडार चार्ट कैसे बनाएं:

```javascript
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

### **मल्टी‑केटेगरी चार्ट बनाना**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>चरण:</em> JavaScript में Multi Category Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Multi Category Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Multi Category Chart बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें। 
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें और वांत्रित प्रकार चुनें ([ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartType).ClusteredColumn)।
4. चार्ट डेटा [ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ChartDataWorkbook) तक पहुंचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

यह JavaScript कोड दिखाता है कि मल्टी‑केटेगरी चार्ट कैसे बनाएं:

```javascript
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
    // सीरीज़ जोड़ रहा है
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

### **मैप चार्ट बनाना**

मैप चार्ट डेटा वाला क्षेत्र प्रदर्शित करने का एक विज़ुअलाइज़ेशन होता है। मैप चार्ट जिओग्राफ़िकल क्षेत्रों में डेटा या मानों की तुलना करने के लिए सबसे उपयुक्त होते हैं।

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>चरण:</em> JavaScript में Map Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Map Chart बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Map Chart बनाएं</strong></a>

यह JavaScript कोड दिखाता है कि मैप चार्ट कैसे बनाएं:

```javascript
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

### **कॉंबिनेशन चार्ट बनाना**

कॉंबिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको दो या अधिक डेटा सेटों के बीच अंतर को उजागर, तुलना या जांचने की अनुमति देता है, जिससे आप उनके बीच के संबंधों को पहचान सकते हैं।

![The combination chart](combination_chart.png)

निम्नलिखित JavaScript कोड दिखाता है कि ऊपर दिखाए गए कॉंबिनेशन चार्ट को PowerPoint प्रस्तुतियों में कैसे बनाएं:

```js
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

    // चार्ट शीर्षक सेट करें.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // चार्ट लेजेंड सेट करें.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // डिफ़ॉल्ट उत्पन्न सीरीज़ और श्रेणियों को हटाएँ.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // नई श्रेणियाँ जोड़ें.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // पहली सीरीज़ जोड़ें.
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
    // क्षैतिज अक्ष सेट करें.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // लंबवत अक्ष सेट करें.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // लंबवत मुख्य ग्रिडलाइन का रंग सेट करें.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // द्वितीयक क्षैतिज अक्ष सेट करें.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // द्वितीयक लंबवत अक्ष सेट करें.
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

## **चार्ट अपडेट करना**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Chart अपडेट करें</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>चरण:</em> JavaScript में Presentation Chart अपडेट करें</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>चरण:</em> JavaScript में PowerPoint Presentation Chart अपडेट करें</strong></a>

1. उस प्रस्तुति को दर्शाने वाले [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं जिसमें वह चार्ट हो जिसे आप अपडेट करना चाहते हैं।
2. उसके इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. सभी शेप्स को पार करके वांछित चार्ट खोजें।
4. चार्ट डेटा वर्कशीट तक पहुंचें।
5. चार्ट डेटा सीरीज़ को मान बदलकर संशोधित करें।
6. नई सीरीज़ जोड़ें और उसमें डेटा भरें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह JavaScript कोड दिखाता है कि चार्ट कैसे अपडेट करें:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // पहले स्लाइडमार्कर तक पहुंचें
    var sld = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ चार्ट प्राप्त करें
    var chart = sld.getShapes().get_Item(0);
    // चार्ट डेटा शीट का इंडेक्स सेट करना
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    var fact = chart.getChartData().getChartDataWorkbook();
    // चार्ट श्रेणी नाम बदलना
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // पहली चार्ट सीरीज़ लेता है
    var series = chart.getChartData().getSeries().get_Item(0);
    // अब सीरीज़ डेटा अपडेट कर रहा है
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// सीरीज़ नाम संशोधित कर रहे हैं
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    // अब सीरीज़ डेटा अपडेट कर रहा है
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// सीरीज़ नाम संशोधित कर रहे हैं
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // अब, नई सीरीज़ जोड़ रहा है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // तीसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(2);
    // अब सीरीज़ डेटा भर रहा है
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

## **चार्ट के लिए डेटा रेंज सेट करना**

चार्ट के लिए डेटा रेंज सेट करने के लिए यह करें:

1. उस प्रस्तुति को दर्शाने वाले [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं जिसमें चार्ट हो।
2. स्लाइड को उसके इंडेक्स द्वारा संदर्भित करें।
3. सभी शेप्स को पार करके वांछित चार्ट खोजें।
4. चार्ट डेटा तक पहुंचें और रेंज सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह JavaScript कोड दिखाता है कि चार्ट के लिए डेटा रेंज कैसे सेट करें:

```javascript
var pres = new aspose.slides.Presentation();
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

## **चार्ट में डिफ़ॉल्ट मार्कर उपयोग करना**
जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से अलग‑अलग डिफ़ॉल्ट मार्कर प्रतीक प्राप्त होते हैं।

यह JavaScript कोड दिखाता है कि चार्ट सीरीज़ मार्कर को स्वचालित रूप से कैसे सेट करें:

```javascript
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
    // दूसरी चार्ट सीरीज़ लेता है
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // अब सीरीज़ डेटा भर रहा है
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

## **अधिकतर पूछे जाने वाले प्रश्न**

**Aspose.Slides कौन‑से चार्ट प्रकारों का समर्थन करता है?**

Aspose.Slides व्यापक चार्ट प्रकारों को समर्थन देता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको अपने डेटा विज़ुअलाइज़ेशन आवश्यकताओं के लिए सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

**मैं स्लाइड में नया चार्ट कैसे जोड़ूं?**

चार्ट जोड़ने के लिए पहले आप [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने की मेथड को कॉल करते हैं, जिसमें चार्ट प्रकार और प्रारंभिक डेटा निर्दिष्ट किया जाता है। यह प्रक्रिया चार्ट को सीधे आपकी प्रस्तुति में एकीकृत करती है।

**मैं चार्ट में प्रदर्शित डेटा कैसे अपडेट कर सकता हूँ?**

आप चार्ट के डेटा वर्कबुक ([ChartDataWorkbook](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdataworkbook/)) तक पहुंचकर, किसी भी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और फिर अपना कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। इस तरह आप प्रोग्रामेटिक रूप से चार्ट को नवीनतम डेटा के अनुसार रीफ़्रेश कर सकते हैं।

**क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?**

हाँ, Aspose.Slides विस्तृत अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य फ़ॉर्मेटिंग तत्वों को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।