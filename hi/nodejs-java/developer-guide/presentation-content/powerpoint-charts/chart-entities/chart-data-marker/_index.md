---
title: JavaScript का उपयोग करके प्रेजेंटेशन में चार्ट डेटा मार्कर प्रबंधित करें
linktitle: डेटा मार्कर
type: docs
url: /hi/nodejs-java/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भराव प्रकार
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में चार्ट डेटा मार्कर को कस्टमाइज़ करना सीखें, स्पष्ट कोड उदाहरणों के साथ PPT और PPTX फ़ॉर्मेट्स में प्रेजेंटेशन प्रभाव को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि चार्ट कैसे बनाएं, किसी सीरीज़ और उसके डेटा पॉइंट्स तक कैसे पहुँचें, डेटा‑पॉइंट स्तर पर मार्कर पर चित्र भराव कैसे लागू करें, मार्कर का आकार कैसे समायोजित करें, और अपडेटेड प्रेजेंटेशन को कैसे सहेजें। यह यह भी बताता है कि मानक मार्कर रूप `MarkerStyleType` एन्ह्यूमरेशन के माध्यम से उपलब्ध हैं और जब चार्ट को रास्टर फ़ॉर्मेट या SVG में निर्यात किया जाता है तो मार्कर का स्वरूप बना रहता है।

## **चार्ट मार्कर विकल्प सेट करें**

विशिष्ट सीरीज़ के अंदर चार्ट डेटा पॉइंट्स पर मार्कर सेट किए जा सकते हैं। चार्ट मार्कर विकल्प सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएँ।
- डिफ़ॉल्ट चार्ट बनाएँ।
- चित्र सेट करें।
- पहली चार्ट सीरीज़ का चयन करें।
- नया डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```javascript
// खाली प्रस्तुति बनाना
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट चार्ट बनाना
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // डिफ़ॉल्ट चार्ट डेटा वर्कशीट इंडेक्स प्राप्त करना
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करना
    var fact = chart.getChartData().getChartDataWorkbook();
    // डेमो सीरीज़ हटाएँ
    chart.getChartData().getSeries().clear();
    // नई सीरीज़ जोड़ें
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // चित्र 1 लोड करें
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // चित्र 2 लोड करें
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // पहली चार्ट सीरीज़ लें
    var series = chart.getChartData().getSeries().get_Item(0);
    // वहाँ नया बिंदु (1:3) जोड़ें।
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // चार्ट सीरीज़ मार्कर बदलें
    series.getMarker().setSize(15);
    // चार्ट के साथ प्रस्तुति सहेजें
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**डिफ़ॉल्ट रूप से कौन से मार्कर आकार उपलब्ध हैं?**

मानक आकार उपलब्ध हैं (सर्कल, स्क्वायर, डायमंड, त्रिकोण आदि); सूची `MarkerStyleType` एन्ह्यूमरेशन द्वारा परिभाषित है। यदि आपको गैर‑मानक आकार चाहिए, तो कस्टम विज़ुअल को अनुकरण करने के लिए चित्र भराव के साथ मार्कर का उपयोग करें।

**क्या चार्ट को चित्र या SVG में निर्यात करने पर मार्कर बना रहता है?**

हां। जब चार्ट को [raster formats](/slides/hi/nodejs-java/convert-powerpoint-to-png/) में रेंडर किया जाता है या [shapes as SVG](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपनी उपस्थिति और सेटिंग्स, जिसमें आकार, भराव और आउटलाइन शामिल हैं, को बरकरार रखते हैं।