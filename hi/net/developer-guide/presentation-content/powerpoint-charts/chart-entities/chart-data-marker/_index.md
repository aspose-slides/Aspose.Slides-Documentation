---
title: .NET में प्रस्तुतियों में चार्ट डेटा मार्कर्स का प्रबंधन
linktitle: डेटा मार्कर
type: docs
url: /hi/net/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भराव प्रकार
- PowerPoint
- प्रस्तुतीकरण
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides के लिए .NET में चार्ट डेटा मार्कर्स को अनुकूलित करने के तरीके सीखें, स्पष्ट C# कोड उदाहरणों के साथ PPT और PPTX फ़ॉर्मेट में प्रस्तुतियों के प्रभाव को बढ़ाते हुए।"
---
## **सारांश**

यह लेख Aspose.Slides में चार्ट डेटा मार्कर्स के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि चार्ट कैसे बनें, किसी श्रृंखला और उसके डेटा पॉइंट्स तक कैसे पहुँचें, डेटा‑पॉइंट स्तर पर मार्कर्स पर चित्र भराव कैसे लागू करें, मार्कर का आकार कैसे समायोजित करें, और अपडेटेड प्रेजेंटेशन को सहेजें। यह यह भी नोट करता है कि मानक मार्कर आकार `MarkerStyleType` एनोमरेशन के माध्यम से उपलब्ध हैं और जब चार्ट को रास्टर फ़ॉर्मैट या SVG में निर्यात किया जाता है तो मार्कर का रूप संरक्षित रहता है।

## **चार्ट मार्कर विकल्प सेट करें**
मार्कर्स को विशेष श्रृंखला के भीतर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का उदाहरण बनाएं।
- डिफ़ॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- नए डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```c#
// Presentation क्लास का एक उदाहरण बनाएं
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Delete demo series
chart.ChartData.Series.Clear();

// Add new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Set the picture
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Set the picture
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Add new point (1:3) there.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Changing the chart series marker
series.Marker.Size = 15;

// Write presentation to disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**डिफ़ॉल्ट रूप में कौन से मार्कर आकार उपलब्ध हैं?**

मानक आकार उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिकोण, आदि); यह सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/net/aspose.slides.charts/markerstyletype/) एनोमरेशन द्वारा परिभाषित है। यदि आपको गैर‑मानक आकार चाहिए, तो कस्टम विज़ुअल को अनुकरण करने के लिए चित्र भराव वाला मार्कर उपयोग करें।

**क्या चार्ट को इमेज या SVG में निर्यात करते समय मार्कर्स संरक्षित रहते हैं?**

हाँ। जब चार्ट को [raster formats](/slides/hi/net/convert-powerpoint-to-png/) में रेंडर किया जाता है या [shapes as SVG](/slides/hi/net/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर्स अपना रूप और सेटिंग्स बनाए रखते हैं, जिसमें आकार, भराव, और रूपरेखा शामिल है।