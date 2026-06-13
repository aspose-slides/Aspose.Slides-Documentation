---
title: Android पर प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें
linktitle: 3D चार्ट
type: docs
url: /hi/androidjava/3d-chart/
keywords:
- 3D चार्ट
- रोटेशन
- गहराई
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में 3-D चार्ट बनाना और कस्टमाइज़ करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents`, और `RightAngleAxes` को कॉन्फ़िगर करके 3D चार्ट को कस्टमाइज़ करने का तरीका समझाता है। यह प्रस्तुति बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D व्यू सेटिंग्स लागू करने, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया दर्शाता है।

## **3D चार्ट के RotationX, RotationY और DepthPercents गुण सेट करें**
Aspose.Slides for Android via Java इन गुणों को सेट करने के लिए एक सरल API प्रदान करता है। इसका निम्नलिखित लेख आपको विभिन्न गुणों जैसे **X,Y Rotation, DepthPercents** आदि सेट करने में मदद करेगा। नमूना कोड उपरोक्त कहे गए गुणों को सेट करने को दर्शाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
1. पहली स्लाइड तक पहुँचें।
1. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
1. Rotation3D गुण सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```java
Presentation pres = new Presentation();
try {
    // पहली स्लाइड तक पहुंचें
    ISlide slide = pres.getSlides().get_Item(0);
    
    // डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // चार्ट डेटा शीट का इंडेक्स सेट कर रहा है
    int defaultWorksheetIndex = 0;
    
    // चार्ट डेटा वर्कशीट प्राप्त कर रहा है
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // सीरीज़ जोड़ें
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // श्रेणियाँ जोड़ें
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D गुण सेट करें
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // दूसरी चार्ट सीरीज़ लें
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // अब सीरीज़ डेटा भर रहे हैं
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ओवरलैप मान सेट करें
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // प्रेज़ेंटेशन को डिस्क पर लिखें
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन से चार्ट प्रकार Aspose.Slides में 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D संस्करणों का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) क्लास के माध्यम से उपलब्ध कराए गए हैं। सटीक और अद्यतन सूची के लिए, अपने स्थापित संस्करण के API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/charttype/) सदस्यों की जाँच करें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हाँ। आप चार्ट को इमेज में एक्सपोर्ट करने के लिए [chart API](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) या पूरी स्लाइड को [render the entire slide](/slides/hi/androidjava/convert-powerpoint-to-png/) करके PNG या JPEG जैसे फ़ॉर्मेट में ले सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल‑परफेक्ट प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड या वेब पेज़ में PowerPoint की आवश्यकता के बिना एम्बेड करना चाहते हैं।

**बड़े 3D चार्ट बनाने और रेंडर करने की प्रदर्शन क्षमता कैसी है?**

प्रदर्शन डेटा की मात्रा और विज़ुअल जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए 3D इफ़ेक्ट को न्यूनतम रखें, वॉल और प्लॉट एरिया पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक सीरीज़ में डेटा पॉइंट्स की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुसार उपयुक्त रिज़ॉल्यूशन और आयाम के साथ आउटपुट रेंडर करें।