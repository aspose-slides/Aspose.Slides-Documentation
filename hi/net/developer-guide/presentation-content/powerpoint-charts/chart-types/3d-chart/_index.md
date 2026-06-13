---
title: ".NET में प्रस्तुतियों में 3D चार्ट को कस्टमाइज़ करें"
linktitle: "3D चार्ट"
type: docs
url: /hi/net/3d-chart/
keywords:
- "3D चार्ट"
- "रोटेशन"
- "गहराई"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET में 3‑D चार्ट बनाना और अनुकूलित करना सीखें, PPT और PPTX फ़ाइलों के समर्थन के साथ—आज ही अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में 3D चार्ट को `Rotation3D` सेटिंग्स जैसे `RotationX`, `RotationY`, `DepthPercents`, और `RightAngleAxes` को कॉन्फ़िगर करके कस्टमाइज़ करने का तरीका समझाता है। यह प्रस्तुति बनाने, डिफ़ॉल्ट डेटा के साथ 3D चार्ट जोड़ने, आवश्यक 3D दृश्य सेटिंग्स लागू करने, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजने की प्रक्रिया को चरण‑बद्ध तरीके से दर्शाता है।

## **3D चार्ट के RotationX, RotationY और DepthPercents प्रॉपर्टी सेट करना**

Aspose.Slides for .NET इन प्रॉपर्टीज़ को सेट करने के लिए एक सरल API प्रदान करता है। नीचे दिया गया लेख आपको X, Y रोटेशन, **DepthPercents** आदि जैसी विभिन्न प्रॉपर्टीज़ सेट करने में मदद करेगा। उदाहरण कोड उपरोक्त उल्लेखित प्रॉपर्टीज़ को सेट करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. पहली स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें।
4. Rotation3D प्रॉपर्टीज़ सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल में लिखें।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation();
           
// पहली स्लाइड तक पहुंचें
ISlide slide = presentation.Slides[0];

// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// चार्ट डेटा शीट का इंडेक्स सेट करना
int defaultWorksheetIndex = 0;

// चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// श्रृंखला (सीरीज़) जोड़ें
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// श्रेणियां जोड़ें
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// Rotation3D प्रॉपर्टी सेट करें
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// दूसरी चार्ट सीरीज़ लें
IChartSeries series = chart.ChartData.Series[1];

// अब सीरीज़ डेटा भर रहे हैं
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// Overlap मान सेट करें
series.ParentSeriesGroup.Overlap = 100;         

// प्रस्तुति को डिस्क पर सहेजें
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides में कौन से चार्ट प्रकार 3D मोड का समर्थन करते हैं?**

Aspose.Slides कॉलम चार्ट के 3D वेरिएंट्स का समर्थन करता है, जिसमें Column 3D, Clustered Column 3D, Stacked Column 3D, और 100% Stacked Column 3D शामिल हैं, साथ ही संबंधित 3D प्रकार जो [ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) एनेमरेशन के माध्यम से एक्सपोज़ किए गए हैं। नवीनतम और सटीक सूची के लिए, अपने इंस्टॉल किए गए संस्करण की API रेफ़रेंस में [ChartType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/charttype/) के सदस्यों को देखें।

**क्या मैं रिपोर्ट या वेब के लिए 3D चार्ट की रास्टर इमेज प्राप्त कर सकता हूँ?**

हाँ। आप [chart API](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/) के माध्यम से चार्ट को इमेज में एक्सपोर्ट कर सकते हैं या [render the entire slide](/slides/hi/net/convert-powerpoint-to-png/) का उपयोग करके पूरे स्लाइड को PNG या JPEG जैसे फ़ॉर्मैट में रेंडर कर सकते हैं। यह तब उपयोगी होता है जब आपको पिक्सेल‑परफेक्ट प्रीव्यू चाहिए या आप चार्ट को दस्तावेज़ों, डैशबोर्ड, या वेब पेजों में एम्बेड करना चाहते हैं बिना PowerPoint की आवश्यकता के।

**बड़े 3D चार्ट बनाना और रेंडर करना कितना प्रदर्शनकारी है?**

प्रदर्शन डेटा की मात्रा और दृश्य जटिलता पर निर्भर करता है। सर्वोत्तम परिणामों के लिए, 3D इफ़ेक्ट्स को न्यूनतम रखें, दीवारों और प्लॉट क्षेत्रों पर भारी टेक्सचर से बचें, संभव हो तो प्रत्येक श्रृंखला में डेटा पॉइंट्स की संख्या सीमित रखें, और लक्ष्य डिस्प्ले या प्रिंट आवश्यकताओं के अनुरूप सही रिज़ॉल्यूशन और आयामों के साथ आउटपुट रेंडर करें।