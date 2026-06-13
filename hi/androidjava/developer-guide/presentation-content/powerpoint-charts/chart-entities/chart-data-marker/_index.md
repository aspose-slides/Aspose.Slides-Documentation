---
title: Android पर प्रस्तुतियों में चार्ट डेटा मार्कर्स को प्रबंधित करें
linktitle: डेटा मार्कर
type: docs
url: /hi/androidjava/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भरण प्रकार
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में चार्ट डेटा मार्कर्स को अनुकूलित करें, स्पष्ट जावा कोड उदाहरणों के साथ PPT और PPTX फॉर्मेट्स में प्रस्तुति प्रभाव को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर्स के साथ काम करने का तरीका बताता है। यह दिखाता है कि चार्ट कैसे बनाएं, किसी सीरीज़ और उसके डेटा पॉइंट्स तक कैसे पहुंचें, डेटा‑पॉइंट स्तर पर मार्कर पर चित्र भरण कैसे लागू करें, मार्कर का आकार समायोजित करें, और अपडेटेड प्रस्तुति को सहेजें। यह यह भी बताता है कि मानक मार्कर आकार `MarkerStyleType` enumeration के माध्यम से उपलब्ध हैं और चार्ट को रास्टर फॉर्मेट्स या SVG में निर्यात करने पर मार्कर का स्वरूप बना रहता है।

## **चार्ट मार्कर विकल्प सेट करें**
विभिन्न श्रृंखलाओं के भीतर चार्ट डेटा पॉइंट्स पर मार्कर सेट किए जा सकते हैं। चार्ट मार्कर विकल्प सेट करने के लिए, नीचे दिए गए चरणों का पालन करें:

- इंस्टैंशिएट करें [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास।
- डिफ़ॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट सीरीज़ लें।
- नया डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```java
// खाली प्रस्तुति बना रहे हैं
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट चार्ट बना रहे हैं
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त कर रहे हैं
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // डेमो सीरीज़ को हटाएँ
    chart.getChartData().getSeries().clear();
    
    // नई सीरीज़ जोड़ें
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // चित्र 1 लोड करें
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // चित्र 2 लोड करें
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // पहली चार्ट सीरीज़ लें
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // वहाँ नया पॉइंट (1:3) जोड़ें.
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
    
    // चार्ट सीरीज़ मार्कर बदल रहे हैं
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

मानक आकार उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिकोण, आदि); इस सूची को [MarkerStyleType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markerstyletype/) क्लास द्वारा परिभाषित किया गया है। यदि आपको गैर‑मानक आकार चाहिए, तो कस्टम विज़ुअल्स को अनुकरण करने के लिए चित्र भराव के साथ मार्कर का उपयोग करें।

**क्या चार्ट को इमेज या SVG में निर्यात करने पर मार्कर संरक्षित रहते हैं?**

हाँ। जब चार्ट को [raster formats](/slides/hi/androidjava/convert-powerpoint-to-png/) में रेंडर किया जाता है या [shapes as SVG](/slides/hi/androidjava/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपना स्वरूप और सेटिंग्स रखे रहते हैं, जिसमें आकार, भराव और रूपरेखा शामिल हैं।