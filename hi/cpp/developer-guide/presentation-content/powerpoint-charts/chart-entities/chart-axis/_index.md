---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट अक्ष को अनुकूलित करें
linktitle: चार्ट अक्ष
type: docs
url: /hi/cpp/chart-axis/
keywords:
- चार्ट अक्ष
- ऊर्ध्वाधर अक्ष
- क्षैतिज अक्ष
- अक्ष को अनुकूलित करें
- अक्ष को हेरफ़ेर करें
- अक्ष को प्रबंधित करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि प्रारूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्ष को अनुकूलित करने हेतु Aspose.Slides for C++ का उपयोग कैसे करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट अक्ष को अनुकूलित करने के तरीकों को समझाता है। यह वास्तविक अक्ष मान प्राप्त करना, अक्ष के बीच डेटा बदलना, लाइन चार्ट के लिए लंबवत या क्षैतिज अक्ष को छुपाना, श्रेणी अक्ष का प्रकार बदलना, श्रेणी अक्ष मानों के लिए तिथि प्रारूप सेट करना, अक्ष शीर्षक को घुमाना, अक्ष की स्थिति निर्धारित करना, और मान अक्ष पर इकाई लेबल प्रदर्शित करना दिखाता है।

## **ऊर्ध्वाधर अक्ष पर अधिकतम मान प्राप्त करें**
Aspose.Slides for C++ आपको ऊर्ध्वाधर अक्ष पर न्यूनतम और अधिकतम मान प्राप्त करने की अनुमति देता है। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
1. अक्ष पर वास्तविक अधिकतम मान प्राप्त करें।
1. अक्ष पर वास्तविक न्यूनतम मान प्राप्त करें।
1. अक्ष की वास्तविक प्रमुख इकाई प्राप्त करें।
1. अक्ष की वास्तविक गौण इकाई प्राप्त करें।
1. अक्ष का वास्तविक प्रमुख इकाई स्केल प्राप्त करें।
1. अक्ष का वास्तविक गौण इकाई स्केल प्राप्त करें।

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// प्रस्तुति को सहेजता है
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **अक्षों के बीच डेटा बदलें**
Aspose.Slides आपको तेज़ी से अक्षों के बीच डेटा बदलने की अनुमति देता है—ऊर्ध्वाधर अक्ष (y-अक्ष) पर प्रदर्शित डेटा क्षैतिज अक्ष (x-अक्ष) पर चला जाता है और इसके विपरीत।

यह C++ कोड आपको चार्ट में अक्षों के बीच डेटा स्वाप कार्य करने का तरीका दिखाता है:

``` cpp
// खाली प्रस्तुति बनाता है
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// पंक्तियों और स्तंभों को बदलता है
chart->get_ChartData()->SwitchRowColumn();

// प्रस्तुति को सहेजता है
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को अक्षम करें**
यह C++ कोड आपको लाइन चार्ट के लिए ऊर्ध्वाधर अक्ष को छुपाने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को अक्षम करें**
यह कोड आपको लाइन चार्ट के लिए क्षैतिज अक्ष को छुपाने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **श्रेणी अक्ष बदलें**
**set_CategoryAxisType()** मेथड का उपयोग करके आप अपनी पसंदीदा श्रेणी अक्ष प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह C++ कोड इस ऑपरेशन को प्रदर्शित करता है:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **श्रेणी अक्ष मानों के लिए तिथि प्रारूप सेट करें**
Aspose.Slides for C++ आपको श्रेणी अक्ष मान के लिए तिथि प्रारूप सेट करने की अनुमति देता है। यह ऑपरेशन इस C++ कोड में प्रदर्शित किया गया है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**
Aspose.Slides for C++ आपको चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करने की अनुमति देता है। यह C++ कोड इस ऑपरेशन को दर्शाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **श्रेणी या मान अक्ष पर अक्ष की स्थिति सेट करें**
Aspose.Slides for C++ आपको श्रेणी या मान अक्ष में अक्ष की स्थिति सेट करने की अनुमति देता है। यह C++ कोड दिखाता है कि इस कार्य को कैसे किया जाए:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **चार्ट मान अक्ष पर प्रदर्शित इकाई लेबल सक्षम करें**
Aspose.Slides for C++ आपको एक चार्ट को इस प्रकार कॉन्फ़िगर करने की अनुमति देता है कि वह अपने मान अक्ष पर इकाई लेबल दिखाए। यह C++ कोड इस ऑपरेशन को दर्शाता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**एक अक्ष दूसरे अक्ष को कहाँ पार करता है (अक्ष क्रॉसिंग) का मान कैसे सेट करें?**

अक्ष [crossing setting](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/axis/set_crosstype/) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या एक विशिष्ट संख्यात्मक मान पर क्रॉस करना चुन सकते हैं। यह X-अक्ष को ऊपर या नीचे शिफ्ट करने या बेसलाइन को उजागर करने के लिए उपयोगी है।

**अक्ष के सापेक्ष टिक लेबल को कैसे स्थित करें (साथ में, बाहर, अंदर)?**

टिक लेबल की स्थिति को [label position](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/axis/set_majortickmark/) को "cross", "outside", या "inside" पर सेट करें। यह पढ़ने की सुविधा को प्रभावित करता है और विशेष रूप से छोटे चार्टों पर जगह बचाने में मदद करता है।