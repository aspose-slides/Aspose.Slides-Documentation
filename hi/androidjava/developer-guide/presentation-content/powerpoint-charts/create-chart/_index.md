---
title: Android पर PowerPoint प्रस्तुतियों के चार्ट बनाएं या अपडेट करें
linktitle: चार्ट बनाएं या अपडेट करें
type: docs
weight: 10
url: /hi/androidjava/create-chart/
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
- फ़नल चार्ट
- सनबर्स्ट चार्ट
- हिस्टोग्राम चार्ट
- रेडार चार्ट
- मल्टीकेटेगरी चार्ट
- PowerPoint
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट बनाएं और अनुकूलित करें। व्यावहारिक Java कोड उदाहरणों के साथ चार्ट जोड़ें, फ़ॉर्मेट करें और संपादित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके चार्ट बनाने और अनुकूलित करने के लिए एक व्यापक मार्गदर्शिका प्रदान करता है। आप सीखेंगे कि प्रोग्रामेटिक रूप से स्लाइड में चार्ट कैसे जोड़ें, उसे डेटा से भरें, और विभिन्न फ़ॉर्मेटिंग विकल्पों को लागू करके अपने विशिष्ट डिज़ाइन आवश्यकताओं से मेल कैसे करें। लेख में विस्तृत कोड उदाहरण प्रत्येक चरण को दर्शाते हैं, जैसा कि प्रेजेंटेशन और चार्ट ऑब्जेक्ट को प्रारंभ करने से लेकर सीरीज़, एक्सिस और लेजेंड को कॉन्फ़िगर करने तक। इस मार्गदर्शिका का पालन करके, आप अपने अनुप्रयोगों में गतिशील चार्ट जेनरेशन को एकीकृत करने की ठोस समझ प्राप्त करेंगे, जिससे डेटा-चालित प्रस्तुतियों को बनाना सरल हो जाएगा।

## **चार्ट बनाएं**
चार्ट लोगों को डेटा को शीघ्रता से दृश्यात्मक बनाने और अंतर्दृष्टि प्राप्त करने में मदद करते हैं, जो तालिका या स्प्रेडशीट से तुरंत स्पष्ट नहीं हो सकती।

**चार्ट क्यों बनाएं?**

चार्ट का उपयोग करके आप:

* एक ही स्लाइड में बड़ी मात्रा में डेटा को संकलित, संक्षिप्त या सारांशित कर सकते हैं
* डेटा में पैटर्न और ट्रेंड उजागर कर सकते हैं
* समय के साथ या किसी विशिष्ट माप इकाई के सापेक्ष डेटा की दिशा और गति का अनुमान लगा सकते हैं
* अपवाद, विचलन, त्रुटियां, असंगत डेटा आदि की पहचान कर सकते हैं
* जटिल डेटा को संप्रेषित या प्रस्तुत कर सकते हैं

PowerPoint में, आप Insert फ़ंक्शन के द्वारा कई प्रकार के चार्ट टेम्प्लेट बना सकते हैं। Aspose.Slides का उपयोग करके, आप नियमित चार्ट (लोकप्रिय चार्ट प्रकारों पर आधारित) और कस्टम चार्ट दोनों बना सकते हैं।

{{% alert color="info" %}} 
चार्ट बनाने की सुविधा देने के लिए, Aspose.Slides [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType) क्लास प्रदान करता है। इस क्लास के फ़ील्ड विभिन्न चार्ट प्रकारों के अनुरूप होते हैं।
{{% /alert %}} 

### **सामान्य चार्ट बनाएं**

_चरण: चार्ट बनाएं_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>चरण:</em> जावा में PowerPoint चार्ट बनाएं</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>चरण:</em> जावा में Presentation चार्ट बनाएं</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation चार्ट बनाएं</strong></a>

_कोड चरण:_

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से उसका रेफ़रेंस प्राप्त करें।
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंदीदा चार्ट टाइप निर्दिष्ट करें। 
4. चार्ट के लिए शीर्षक जोड़ें। 
5. चार्ट डेटा वर्कशीट तक पहुँचें। 
6. सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें। 
7. नई सीरीज़ और श्रेणियाँ जोड़ें। 
8. चार्ट सीरीज़ के लिए नया डेटा जोड़ें। 
9. चार्ट सीरीज़ के लिए फ़िल रंग जोड़ें। 
10. चार्ट सीरीज़ के लिए लेबल जोड़ें। 
11. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह जावा कोड आपको सामान्य चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले प्रेजेंटेशन क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide sld = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // चार्ट डेटा वर्कशीट के लिए इंडेक्स सेट करता है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // डिफ़ॉल्ट जनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // नई सीरीज़ जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // नई श्रेणियाँ जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // पहली चार्ट सीरीज़ लेता है
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // अब सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // सीरीज़ के लिए फ़िल रंग सेट करता है
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    
    // सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // सीरीज़ के लिए फ़िल रंग सेट करता है
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // नई सीरीज़ के लिए प्रत्येक श्रेणी के कस्टम लेबल बनाता है
    // पहला लेबल श्रेणी नाम दिखाने के लिये सेट करता है
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // तीसरे लेबल के लिये मान दिखाता है
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // चार्ट के साथ प्रेजेंटेशन को सेव करता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **स्कैटर्ड चार्ट बनाएं**
स्कैटर्ड चार्ट (जिसे स्कैटर प्लॉट या X‑Y ग्राफ़ भी कहा जाता है) का अक्सर उपयोग दो चर के बीच पैटर्न या संबंध दिखाने के लिए किया जाता है।

आप स्कैटर्ड चार्ट का उपयोग तब करना चाहेंगे जब

* आपके पास युग्मित संख्यात्मक डेटा हो
* आपके पास दो ऐसे चर हों जो एक साथ अच्छी तरह मेल खाते हों
* आप यह निर्धारित करना चाहते हों कि दो चर संबंधित हैं या नहीं
* आपके पास एक स्वतंत्र चर हो जिसके कई मान आश्रित चर के लिये हों

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>चरण:</em> जावा में स्कैटर्ड चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>चरण:</em> जावा में PowerPoint स्कैटर्ड चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation स्कैटर्ड चार्ट बनाएं</strong></a>

1. ऊपर दिए गए **सामान्य चार्ट बनाएं** अनुभाग में वर्णित चरणों का पालन करें।
2. तीसरे चरण में, एक चार्ट जोड़ें और निम्नलिखित में से एक टाइप चुनें:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _स्कैटर चार्ट को दर्शाता है।_
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _वक्रों द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर्स के साथ।_
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _वक्रों द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर्स के बिना।_
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _रेखाओं द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर्स के साथ।_
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _रेखाओं द्वारा जुड़ा स्कैटर चार्ट, डेटा मार्कर्स के बिना।_

यह जावा कोड आपको विभिन्न मार्कर श्रृंखलाओं के साथ स्कैटर्ड चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले प्रेजेंटेशन क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);

    // डिफ़ॉल्ट चार्ट बनाता है
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // डिफ़ॉल्ट चार्ट डेटा वर्कशीट का इंडेक्स प्राप्त करता है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // डेमो सीरीज़ को हटाता है
    chart.getChartData().getSeries().clear();
    
    // नई सीरीज़ जोड़ता है
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // पहली चार्ट सीरीज़ लेता है
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // सीरीज़ में एक नया पॉइंट (1:3) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // एक नया पॉइंट (2:10) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // सीरीज़ प्रकार बदलता है
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // दूसरी चार्ट सीरीज़ लेता है
    series = chart.getChartData().getSeries().get_Item(1);
    
    // वहाँ एक नया पॉइंट (5:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // एक नया पॉइंट (3:1) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // एक नया पॉइंट (2:2) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // एक नया पॉइंट (5:1) जोड़ता है
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // चार्ट सीरीज़ मार्कर बदलता है
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **पाई चार्ट बनाएं**

पाई चार्ट डेटा में भाग‑से‑सम्पूर्ण संबंध दिखाने के लिए सबसे उपयुक्त होते हैं, विशेषकर जब डेटा में श्रेणीबद्ध लेबल के साथ संख्यात्मक मान हों। यदि आपके डेटा में बहुत सारी श्रेणियाँ या लेबल हों, तो आप बार चार्ट का उपयोग करने पर विचार कर सकते हैं।

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>चरण:</em> जावा में पाई चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>चरण:</em> जावा में PowerPoint पाई चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation पाई चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार (इस मामले में, [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).Pie) चुनकर एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियां जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. पाई चार्ट के सेक्टर के लिए कस्टम रंग जोड़ते हुए नए पॉइंट्स जोड़ें।
9. सीरीज़ के लिए लेबल सेट करें।
10. सीरीज़ लेबल के लिए लीडर लाइन्स सेट करें।
11. पाई चार्ट स्लाइड्स के लिए रोटेशन एंगल सेट करें।
12. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको पाई चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले प्रेजेंटेशन क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचता है
    ISlide slides = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // चार्ट शीर्षक सेट करता है
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // चार्ट डेटा शीट के लिए इंडेक्स सेट करता है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त करता है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // डिफ़ॉल्ट जनरेटेड सीरीज़ और श्रेणियों को हटाता है
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // नई श्रेणियाँ जोड़ता है
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // नई सीरीज़ जोड़ता है
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //सीरीज़ डेटा भरता है
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // नई संस्करण में काम नहीं कर रहा है
    // नए पॉइंट जोड़ रहा है और सेक्टर रंग सेट कर रहा है
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // सेक्टर बॉर्डर सेट करता है
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // सेक्टर बॉर्डर सेट करता है
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // सेक्टर बॉर्डर सेट करता है
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // नई सीरीज़ के प्रत्येक श्रेणी के लिए कस्टम लेबल बनाता है
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // चार्ट के लिए लीडर लाइन्स दिखाता है
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // पाई चार्ट सेक्टर के लिये रोटेशन एंगल सेट करता है
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // चार्ट के साथ प्रेजेंटेशन को सेव करता है
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **लाइन चार्ट बनाएं**

लाइन चार्ट (जिसे लाइन ग्राफ़ भी कहा जाता है) उन स्थितियों में सबसे उपयुक्त होते हैं जहाँ आप समय के साथ मानों में परिवर्तन दिखाना चाहते हैं। लाइन चार्ट का उपयोग करके आप कई डेटा सेट की तुलना, समय के साथ रुझान ट्रैक, डेटा सीरीज़ में असामान्यताओं को उजागर आदि कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. स्लाइड के इंडेक्स के द्वारा उसका रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार (`ChartType.Line`) चुनकर एक चार्ट जोड़ें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको लाइन चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

डिफ़ॉल्ट रूप से, लाइन चार्ट में बिंदु सीधे सतत रेखाओं से जुड़े होते हैं। यदि आप बिंदुओं को डैश वाली रेखा से जोड़ना चाहते हैं, तो आप अपनी पसंदीदा डैश टाइप इस प्रकार निर्दिष्ट कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **ट्री मैप चार्ट बनाएं**

ट्री मैप चार्ट बिक्री डेटा के लिए सबसे उपयुक्त होते हैं जब आप डेटा श्रेणियों के सापेक्ष आकार दिखाना चाहते हैं और साथ ही प्रत्येक श्रेणी में बड़े योगदानकर्ता आइटम्स को जल्दी से उजागर करना चाहते हैं।

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>चरण:</em> जावा में ट्री मैप चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>चरण:</em> जावा में PowerPoint ट्री मैप चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation ट्री मैप चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा और इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).TreeMap) के साथ एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको ट्री मैप चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //शाखा 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //शाखा 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **स्टॉक चार्ट बनाएं**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>चरण:</em> जावा में स्टॉक चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>चरण:</em> जावा में PowerPoint स्टॉकチャート बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation स्टॉक चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).OpenHighLowClose) चुनकर एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. HiLowLines फ़ॉर्मेट निर्दिष्ट करें।
9. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

स्टॉक चार्ट बनाने के लिए उपयोग किया गया नमूना जावा कोड:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **बॉक्स एंड व्हिस्कर चार्ट बनाएं**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>चरण:</em> जावा में बॉक्स एंड व्हिस्कर चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>चरण:</em> जावा में PowerPoint बॉक्स एंड व्हिस्कर चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation बॉक्स एंड व्हिस्कर चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा और इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).BoxAndWhisker) के साथ एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको बॉक्स एंड व्हिस्कर चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
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

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **फ़नल चार्ट बनाएं**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>चरण:</em> जावा में फ़नल चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>चरण:</em> जावा में PowerPoint फ़नल चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation फ़नल चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).Funnel) चुनकर एक चार्ट जोड़ें।
4. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

जावा कोड आपको फ़नल चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **सनबर्स्ट चार्ट बनाएं**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>चरण:</em> जावा में सनबर्स्ट चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>चरण:</em> जावा में PowerPoint सनबर्स्ट चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation सनबर्स्ट चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा और इच्छित प्रकार (इस मामले में, [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).sunburst) के साथ एक चार्ट जोड़ें।
4. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको सनबर्स्ट चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //शाखा 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //शाखा 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **हिस्टोग्राम चार्ट बनाएं**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>चरण:</em> जावा में हिस्टोग्राम चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>चरण:</em> जावा में PowerPoint हिस्टोग्राम चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation हिस्टोग्राम चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट डेटा और इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).Histogram) के साथ एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको हिस्टोग्राम चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **रेडार चार्ट बनाएं**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>चरण:</em> जावा में रेडार चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>चरण:</em> जावा में PowerPoint रेडार चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation रेडार चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें। 
3. कुछ डेटा के साथ एक चार्ट जोड़ें और अपनी पसंदीदा चार्ट टाइप (`ChartType.Radar`) निर्दिष्ट करें।
4. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको रेडार चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **मल्टी‑केटेगरी चार्ट बनाएं**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>चरण:</em> जावा में मल्टी‑केटेगरी चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>चरण:</em> जावा में PowerPoint मल्टी‑केटेगरी चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation मल्टी‑केटेगरी चार्ट बनाएं</strong></a>

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें। 
3. डिफ़ॉल्ट डेटा के साथ इच्छित प्रकार ([ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ChartType).ClusteredColumn) चुनकर एक चार्ट जोड़ें।
4. चार्ट डेटा [IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IChartDataWorkbook) तक पहुँचें।
5. डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करें।
6. नई सीरीज़ और श्रेणियाँ जोड़ें।
7. चार्ट सीरीज़ के लिए नया डेटा जोड़ें।
8. संशोधित प्रेजेंटेशन को PPTX फ़ाइल में लिखें।

यह जावा कोड आपको मल्टिकैटेगरी चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // चार्ट के साथ प्रेजेंटेशन को सहेजें
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **मैप चार्ट बनाएं**

मैप चार्ट वह विज़ुअलाइज़ेशन है जो डेटा के साथ किसी क्षेत्र को दर्शाता है। मैप चार्ट भौगोलिक क्षेत्रों के बीच डेटा या मानों की तुलना करने के लिए सबसे उपयुक्त होते हैं।

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>चरण:</em> जावा में मैप चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>चरण:</em> जावा में PowerPoint मैप चार्ट बनाएं</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation मैप चार्ट बनाएं</strong></a>

यह जावा कोड आपको मैप चार्ट बनाने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **कम्बिनेशन चार्ट बनाएं**

कम्बिनेशन चार्ट (या कॉम्बो चार्ट) एक ही ग्राफ़ में दो या अधिक चार्ट प्रकारों को मिलाता है। यह चार्ट आपको कई डेटा सेटों के बीच अंतर को उजागर, तुलना या जांचने की सुविधा देता है, जिससे उनके बीच के संबंधों की पहचान आसान हो जाती है।

![संयोजन चार्ट](combination_chart.png)

निम्नलिखित जावा कोड ऊपर दिखाए गए संयोजन चार्ट को PowerPoint प्रेजेंटेशन में बनाने का तरीका दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // चार्ट शीर्षक सेट करें।
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // चार्ट लेजेंड सेट करें।
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // डिफ़ॉल्ट जनरेटेड सीरीज़ और श्रेणियों को हटाएँ।
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // नई श्रेणियां जोड़ें।
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // पहली सीरीज़ जोड़ें।
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // क्षैतिज एक्सिस सेट करें।
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // लंबवत एक्सिस सेट करें।
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // लंबवत मुख्य ग्रिडलाइन का रंग सेट करें।
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // द्वितीयक क्षैतिज एक्सिस सेट करें।
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // द्वितीयक लंबवत एक्सिस सेट करें।
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **चार्ट अपडेट करें**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>चरण:</em> जावा में PowerPoint चार्ट अपडेट करें</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>चरण:</em> जावा में Presentation चार्ट अपडेट करें</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>चरण:</em> जावा में PowerPoint Presentation चार्ट अपडेट करें</strong></a>

1. वह [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जो उस प्रेजेंटेशन का प्रतिनिधित्व करता है जिसमें आप अपडेट करना चाहते हैं।
2. स्लाइड के इंडेक्स का उपयोग करके उसका रेफ़रेंस प्राप्त करें।
3. सभी शेप्स के माध्यम से क्रमवार खोज करें ताकि इच्छित चार्ट मिल सके।
4. चार्ट डेटा वर्कशीट तक पहुँचें।
5. सीरीज़ मान बदलकर चार्ट डेटा सीरीज़ को संशोधित करें।
6. नई सीरीज़ जोड़ें और उसका डेटा भरें।
7. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

यह जावा कोड आपको चार्ट अपडेट करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

// उस प्रेजेंटेशन को खोलता है जिसमें अपडेट करने के लिये चार्ट है
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // पहली स्लाइड तक पहुँचें
    ISlide sld = pres.getSlides().get_Item(0);

    // स्लाइड से चार्ट प्राप्त करें
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // चार्ट डेटा शीट का इंडेक्स सेट कर रहा है
    int defaultWorksheetIndex = 0;

    // चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // चार्ट श्रेणी नाम बदल रहा है
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // पहली चार्ट सीरीज़ लें
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // अब सीरीज़ डेटा अपडेट कर रहे हैं
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// सीरीज़ नाम बदल रहा है
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // दूसरी चार्ट सीरीज़ लें
    series = chart.getChartData().getSeries().get_Item(1);

    // अब सीरीज़ डेटा अपडेट कर रहे हैं
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// सीरीज़ नाम बदल रहा है
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

    chart.setType(ChartType.ClusteredCylinder);

    // चार्ट के साथ प्रेजेंटेशन सहेजें
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट के लिए डेटा रेंज सेट करें**

चार्ट की डेटा रेंज सेट करने के लिए ये कदम अपनाएँ:

1. वह [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जो उस प्रेजेंटेशन का प्रतिनिधित्व करता है जिसमें चार्ट है।
2. स्लाइड के इंडेक्स से उसका रेफ़रेंस प्राप्त करें।
3. सभी शेप्स के माध्यम से क्रमवार खोज करके इच्छित चार्ट पाएँ।
4. चार्ट डेटा तक पहुँचें और रेंज सेट करें।
5. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में सेव करें।

यह जावा कोड आपको चार्ट की डेटा रेंज सेट करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

// उस प्रेजेंटेशन को खोलता है जिसमें चार्ट है
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करें**
जब आप चार्ट में डिफ़ॉल्ट मार्कर का उपयोग करते हैं, तो प्रत्येक चार्ट सीरीज़ को स्वतः अलग‑अलग डिफ़ॉल्ट मार्कर सिंबल मिल जाता है।

यह जावा कोड आपको चार्ट सीरीज़ मार्कर स्वचालित रूप से सेट करने का तरीका दिखाता है:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

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
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // अब सीरीज़ डेटा भर रहे हैं
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### Aspose.Slides कौन-कौन से चार्ट प्रकार समर्थन करता है?

Aspose.Slides व्यापक [चार्ट प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) का समर्थन करता है, जिसमें बार, लाइन, पाई, एरिया, स्कैटर, हिस्टोग्राम, रेडार और कई अन्य शामिल हैं। यह लचीलापन आपको अपने डेटा विज़ुअलाइज़ेशन आवश्यकताओं के अनुसार सबसे उपयुक्त चार्ट प्रकार चुनने की अनुमति देता है।

### स्लाइड में नया चार्ट कैसे जोड़ें?

एक चार्ट जोड़ने के लिए, पहले आप [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाते हैं, इच्छित स्लाइड को उसके इंडेक्स से प्राप्त करते हैं, और फिर चार्ट जोड़ने वाली मेथड को कॉल करके चार्ट टाइप और प्रारंभिक डेटा निर्दिष्ट करते हैं। यह प्रक्रिया चार्ट को सीधे आपके प्रेजेंटेशन में एकीकृत करती है।

### चार्ट में दिखाए गए डेटा को कैसे अपडेट करें?

आप चार्ट के डेटा वर्कबुक ([IChartDataWorkbook](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdataworkbook/)) तक पहुँचकर, सभी डिफ़ॉल्ट सीरीज़ और श्रेणियों को साफ़ करके, और फिर अपना कस्टम डेटा जोड़कर चार्ट का डेटा अपडेट कर सकते हैं। इससे चार्ट नवीनतम डेटा को प्रतिबिंबित करने के लिये रिफ्रेश हो जाता है।

### क्या चार्ट की उपस्थिति को अनुकूलित करना संभव है?

हाँ, Aspose.Slides व्यापक अनुकूलन विकल्प प्रदान करता है। आप रंग, फ़ॉन्ट, लेबल, लेजेंड और अन्य [फ़ॉर्मेटिंग तत्व](/slides/hi/androidjava/chart-entities/) को संशोधित करके चार्ट की उपस्थिति को अपनी विशिष्ट डिज़ाइन आवश्यकताओं के अनुसार ढाल सकते हैं।