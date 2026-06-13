---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा मार्करों का प्रबंधन
linktitle: डेटा मार्कर
type: docs
url: /hi/cpp/chart-data-marker/
keywords:
- चार्ट
- डेटा पॉइंट
- मार्कर
- मार्कर विकल्प
- मार्कर आकार
- भरण प्रकार
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में चार्ट डेटा मार्करों को कस्टमाइज़ करने का तरीका सीखें, जिससे PPT और PPTX फ़ॉर्मैट्स में प्रस्तुति प्रभाव बढ़े, स्पष्ट C++ कोड उदाहरणों के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट डेटा मार्करों के साथ कैसे काम किया जाए, समझाता है। यह दिखाता है कि चार्ट कैसे बनाया जाए, किसी श्रृंखला और उसके डेटा पॉइंट्स तक कैसे पहुंचा जाए, डेटा‑पॉइंट स्तर पर मार्करों पर चित्र भराव कैसे लागू किया जाए, मार्कर का आकार कैसे समायोजित किया जाए, और अपडेटेड प्रस्तुति कैसे सहेजी जाए। यह यह भी नोट करता है कि मानक मार्कर आकृतियाँ `MarkerStyleType` एन्यूमरेशन के माध्यम से उपलब्ध हैं और चार्ट को रास्टर फॉर्मैट या SVG में निर्यात करते समय मार्कर का रूप बना रहता है।

## **चार्ट मार्कर सेट करें**
Aspose.Slides for C++ चार्ट सीरीज़ मार्कर को स्वचालित रूप से सेट करने के लिए एक सरल API प्रदान करता है। नीचे दिए गए फीचर में, प्रत्येक चार्ट सीरीज़ को स्वचालित रूप से अलग डिफॉल्ट मार्कर प्रतीक मिलेगा।

नीचे दिया गया कोड उदाहरण दिखाता है कि चार्ट सीरीज़ मार्कर को स्वचालित रूप से कैसे सेट किया जाए।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **चार्ट मार्कर विकल्प सेट करें**
विशिष्ट श्रृंखला के भीतर चार्ट डेटा पॉइंट्स पर मार्करों को सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Instantiate [प्रस्तुति](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) class.
- डिफॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- एक नया डेटा पॉइंट जोड़ें।
- प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **सीरीज़ डेटा पॉइंट स्तर पर चार्ट मार्कर सेट करें**
अब, विशिष्ट श्रृंखला के भीतर चार्ट डेटा पॉइंट्स पर मार्करों को सेट किया जा सकता है। चार्ट मार्कर विकल्प सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Instantiate Presentation class.
- डिफॉल्ट चार्ट बनाना।
- चित्र सेट करें।
- पहली चार्ट श्रृंखला लें।
- एक नया डेटा पॉइंट जोड़ें।
- प्रस्तुति को डिस्क पर लिखें।

नीचे दिए गए उदाहरण में, हमने डेटा पॉइंट स्तर पर चार्ट मार्कर विकल्प सेट किए हैं।

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Access first slide
// Add chart with default data
// Setting the index of chart data sheet
// Getting the chart data worksheet
// Delete default generated series and categories
// Now, Adding a new series
// Get the picture
// Add image to presentation's images collection
// Add new point (1:3) there.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **डेटा पॉइंट्स पर रंग लागू करें**
आप Aspose.Slides for C++ का उपयोग करके चार्ट में डेटा पॉइंट्स पर रंग लागू कर सकते हैं। [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) और **[IChartDataPointLevel](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatapointlevel/)** क्लासें डेटा पॉइंट स्तरों की प्रॉपर्टीज़ तक पहुंच प्रदान करने के लिए जोड़ी गई हैं। यह लेख दर्शाता है कि आप चार्ट के डेटा पॉइंट्स तक कैसे पहुंच सकते हैं और उन पर रंग कैसे लागू कर सकते हैं।

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सी मार्कर आकृतियाँ डिफ़ॉल्ट रूप से उपलब्ध हैं?**

मानक आकृतियाँ उपलब्ध हैं (वृत्त, वर्ग, हीरा, त्रिकोण आदि); यह सूची [MarkerStyleType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/markerstyletype/) एन्ह्यूमेरेशन द्वारा परिभाषित है। यदि आपको कोई गैर‑मानक आकृति चाहिए, तो कस्टम विज़ुअल्स का अनुकरण करने के लिए चित्र भराव वाले मार्कर का उपयोग करें।

**क्या चार्ट को छवि या SVG में निर्यात करते समय मार्कर संरक्षित रहते हैं?**

हाँ। जब चार्ट को [रास्टर फॉर्मैट्स](/slides/hi/cpp/convert-powerpoint-to-png/) में रेंडर किया जाता है या [SVG के रूप में शैप्स](/slides/hi/cpp/render-a-slide-as-an-svg-image/) को सहेजा जाता है, तो मार्कर अपना रूप और सेटिंग्स बनाए रखते हैं, जिसमें आकार, भराव और आउटलाइन शामिल हैं।