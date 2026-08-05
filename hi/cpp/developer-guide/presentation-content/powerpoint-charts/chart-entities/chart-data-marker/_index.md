---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा मार्कर प्रबंधित करें
linktitle: डेटा मार्कर
type: docs
url: /hi/cpp/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- फ़िल प्रकार
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में चार्ट डेटा मार्करों को कस्टमाइज़ करना सीखें, स्पष्ट C++ कोड उदाहरणों के साथ PPT और PPTX फ़ॉर्मैट में प्रस्तुतियों के प्रभाव को बढ़ाएँ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्करों के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि चार्ट कैसे बनाएं, एक श्रृंखला और उसके डेटा पॉइंट्स तक कैसे पहुंचें, डेटा‑पॉइंट स्तर पर मार्करों पर चित्र भराव लागू करें, मार्कर आकार समायोजित करें, और अपडेटेड प्रेजेंटेशन को सहेजें। यह यह भी नोट करता है कि मानक मार्कर आकृतियाँ `MarkerStyleType` एन्ह्यूमरेशन के माध्यम से उपलब्ध हैं और जब चार्ट को रास्टर फ़ॉर्मैट या SVG में निर्यात किया जाता है तो मार्कर का स्वरूप संरक्षित रहता है।

## **चार्ट मार्कर सेट करें**
Aspose.Slides for C++ चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करने के लिए एक सरल API प्रदान करता है। निम्नलिखित सुविधा में, प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से अलग डिफ़ॉल्ट मार्कर प्रतीक मिलेगा।

नीचे दिया गया कोड उदाहरण दिखाता है कि चार्ट सीरीज़ मार्कर को स्वचालित रूप से कैसे सेट किया जाए।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **चार्ट मार्कर विकल्प सेट करें**
मार्करों को किसी विशेष श्रृंखला के अंदर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
- डिफ़ॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- एक नया डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **सीरीज़ डेटा पॉइंट स्तर पर चार्ट मार्कर सेट करें**
अब, मार्करों को किसी विशेष श्रृंखला के अंदर चार्ट डेटा पॉइंट्स पर सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक Presentation क्लास का उदाहरण बनाएं।
- डिफ़ॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- एक नया डेटा पॉइंट जोड़ें।
- प्रेजेंटेशन को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
// पहली स्लाइड तक पहुँचें
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
// डिफ़ॉल्ट डेटा के साथ चार्ट जोड़ें
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
// चार्ट डेटा शीट का इंडेक्स सेट कर रहे हैं
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
// चार्ट डेटा वर्कशीट प्राप्त कर रहे हैं
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
// डिफ़ॉल्ट जेनरेटेड सीरीज़ और श्रेणियों को हटाएँ
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
// अब, नई सीरीज़ जोड़ रहे हैं
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// चित्र प्राप्त करें
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// प्रेजेंटेशन के इमेज संग्रह में चित्र जोड़ें
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // वहां नया पॉइंट (1:3) जोड़ें
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
// चार्ट सीरीज़ मार्कर बदल रहे हैं
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
// प्रेजेंटेशन फ़ाइल को डिस्क पर लिखें
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **डेटा पॉइंट्स पर रंग लागू करें**
आप Aspose.Slides for C++ का उपयोग करके चार्ट में डेटा पॉइंट्स पर रंग लागू कर सकते हैं। [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) और **[IChartDataPointLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/)** क्लासेज़ को डेटा पॉइंट स्तर की प्रॉपर्टीज़ तक पहुँच प्राप्त करने के लिए जोड़ा गया है। यह लेख दर्शाता है कि आप कैसे चार्ट में डेटा पॉइंट्स तक पहुँच सकते हैं और उनका रंग लागू कर सकते हैं।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**डिफ़ॉल्ट रूप से कौन सी मार्कर आकृतियाँ उपलब्ध हैं?**

मानक आकृतियों (वृत्त, वर्ग, हीरा, त्रिकोण आदि) उपलब्ध हैं; सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/markerstyletype/) एन्ह्यूमरेशन द्वारा निर्धारित की गई है। यदि आपको गैर-मानक आकृति चाहिए, तो कस्टम विज़ुअल्स को अनुकरण करने के लिए चित्र भराव वाला मार्कर उपयोग करें।

**क्या एक चार्ट को छवि या SVG में निर्यात करने पर मार्कर संरक्षित रहते हैं?**

हां। जब चार्ट को [रास्टर फ़ॉर्मैट्स](/slides/hi/cpp/convert-powerpoint-to-png/) में रेंडर किया जाता है या [SVG के रूप में शैप्स](/slides/hi/cpp/render-a-slide-as-an-svg-image/) के रूप में सहेजा जाता है, तो मार्कर अपना रूप और सेटिंग्स बनाए रखते हैं, जिसमें आकार, भराव और रूपरेखा शामिल हैं।