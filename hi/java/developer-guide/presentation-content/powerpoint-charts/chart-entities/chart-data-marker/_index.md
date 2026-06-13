---
title: जावा का उपयोग करके प्रस्तुतियों में चार्ट डेटा मार्कर प्रबंधित करें
linktitle: डेटा मार्कर
type: docs
url: /hi/java/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भराव प्रकार
- पावरपॉइंट
- प्रस्तुति
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में चार्ट डेटा मार्कर को अनुकूलित करना सीखें, स्पष्ट जावा कोड उदाहरणों के साथ PPT और PPTX फ़ॉर्मैट्स में प्रस्तुति प्रभाव को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि कैसे चार्ट बनाएं, एक श्रृंखला और उसकी डेटा पॉइंट्स तक पहुँचें, डेटा‑पॉइंट स्तर पर मार्कर पर चित्र भराव लागू करें, मार्कर का आकार समायोजित करें, और अपडेट किया गया प्रस्तुतीकरण सहेजें। यह भी उल्लेख करता है कि मानक मार्कर आकार `MarkerStyleType` एनीमरेशन के माध्यम से उपलब्ध हैं और मार्कर की उपस्थिति रैस्टर फ़ॉर्मेट या SVG में चार्ट निर्यात करने पर संरक्षित रहती है।

## **चार्ट मार्कर विकल्प सेट करें**
मार्कर को विशिष्ट श्रृंखला के भीतर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास को इंस्टैंशिएट करें।
- डिफ़ॉल्ट चार्ट बनाएँ।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- नया डेटा पॉइंट जोड़ें।
- प्रस्तुतीकरण को डिस्क पर लिखें।

नीचे दिए गये उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```java
// खाली प्रस्तुति बना रहा है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुँचें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट चार्ट बना रहा है
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // डिफ़ॉल्ट चार्ट डेटा वर्कशीट अनुक्रमांक प्राप्त कर रहा है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // डेमो श्रृंखला हटाएँ
    chart.getChartData().getSeries().clear();
    
    // नई श्रृंखला जोड़ें
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // चित्र 1 लोड करें
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // चित्र 2 लोड करें
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // पहली चार्ट श्रृंखला लें
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // वहाँ नया बिंदु (1:3) जोड़ें।
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // चार्ट श्रृंखला मार्कर बदल रहा है
    series.getMarker().setSize(15);
    
    // चार्ट के साथ प्रस्तुति सहेजें
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**डिफ़ॉल्ट रूप से कौन से मार्कर आकार उपलब्ध हैं?**

मानक आकार उपलब्ध हैं (वृत्त, वर्ग, अलंकार, त्रिभुज आदि); यह सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markerstyletype/) क्लास द्वारा परिभाषित है। यदि आपको कोई गैर‑मानक आकार चाहिए, तो कस्टम दृश्य को अनुकरण करने के लिए चित्र भराव वाले मार्कर का उपयोग करें।

**क्या चार्ट को छवि या SVG में निर्यात करने पर मार्कर संरक्षित रहते हैं?**

हां। जब चार्ट को [रैस्टर प्रारूप](/slides/hi/java/convert-powerpoint-to-png/) में रेंडर किया जाता है या [आकार को SVG](/slides/hi/java/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपनी उपस्थिति और सेटिंग्स, जिसमें आकार, भराव और आउटलाइन शामिल हैं, को बनाए रखते हैं।