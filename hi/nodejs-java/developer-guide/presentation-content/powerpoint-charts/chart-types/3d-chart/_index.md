---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/nodejs-java/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में 3‑D चार्ट बनाना और कस्टमाइज़ करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **सारांश**

यह लेख बताता है कि Aspose.Slides में `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents`, और `RightAngleAxes` को कॉन्फ़िगर करके 3D चार्ट को कैसे कस्टमाइज़ किया जाए। यह प्रेज़ेंटेशन बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D व्यू सेटिंग्स लागू करने, और संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया को दिखाता है।

## **3D चार्ट की RotationX, RotationY और DepthPercents प्रॉपर्टीज़ सेट करना**

Aspose.Slides for Node.js via Java इन प्रॉपर्टीज़ को सेट करने के लिए एक सरल API प्रदान करता है। यह लेख आपको **X, Y Rotation, DepthPercents** आदि विभिन्न प्रॉपर्टीज़ सेट करने में मदद करेगा। नमूना कोड उपरोक्त उल्लेखित प्रॉपर्टीज़ को लागू करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
1. पहले स्लाइड तक पहुँचें।  
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।  
1. Rotation3D प्रॉपर्टीज़ सेट करें।  
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल में लिखें।

```javascript
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड तक पहुँचें
    var slide = pres.getSlides().get_Item(0);
    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // चार्ट डेटा शीट का इंडेक्स सेट करना
    var defaultWorksheetIndex = 0;
    // चार्ट डेटा वर्कशीट प्राप्त करना
    var fact = chart.getChartData().getChartDataWorkbook();
    // सीरीज़ जोड़ें
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // श्रेणियाँ जोड़ें
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Rotation3D गुण सेट करें
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // दूसरी चार्ट सीरीज़ लें
    var series = chart.getChartData().getSeries().get_Item(1);
    // अब सीरीज़ डेटा भर रहे हैं
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // OverLap मान सेट करें
    series.getParentSeriesGroup().setOverlap(100);
    // प्रेज़ेंटेशन को डिस्क पर लिखें
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट्स को समर्थन देता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) enumeration के माध्यम से उपलब्ध हैं। सटीक और अद्यतन सूची के लिए, अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/charttype/) के सदस्य देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर छवि प्राप्त कर सकता हूँ?**

हाँ। आप [chart API](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage) के माध्यम से चार्ट को छवि में निर्यात कर सकते हैं या [render the entire slide](/slides/hi/nodejs-java/convert-powerpoint-to-png/) को PNG या JPEG जैसे फ़ॉर्मेट में रेंडर कर सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल-परफेक्ट प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेजों में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट को बनाना और रेंडर करना कितना प्रभावी है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D इफेक्ट्स को न्यूनतम रखें, दीवारों और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रति सीरीज़ डेटा पॉइंट्स की संख्या सीमित करें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं से मेल खाने के लिए उपयुक्त आकार (रिज़ॉल्यूशन और डाइमेंशन) में आउटपुट रेंडर करें।