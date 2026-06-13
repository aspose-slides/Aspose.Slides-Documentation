---
title: C++ का उपयोग करके प्रस्तुतीकरण में चार्ट एक्सिस को अनुकूलित करें
linktitle: चार्ट एक्सिस
type: docs
url: /hi/cpp/chart-axis/
keywords:
- चार्ट एक्सिस
- ऊर्ध्वाधर एक्सिस
- क्षैतिज एक्सिस
- एक्सिस को अनुकूलित करें
- एक्सिस को नियंत्रित करें
- एक्सिस प्रबंधन
- एक्सिस गुण
- अधिकतम मान
- न्यूनतम मान
- एक्सिस लाइन
- तिथि प्रारूप
- एक्सिस शीर्षक
- एक्सिस स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट एक्सिस को अनुकूलित करने हेतु Aspose.Slides for C++ का उपयोग कैसे करें, जानें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में चार्ट एक्सिस को अनुकूलित करने के तरीकों को समझाता है। यह वास्तविक एक्सिस मान प्राप्त करना, एक्सिस के बीच डेटा बदलना, लाइन चार्ट के लिए ऊर्ध्वाधर या क्षैतिज एक्सिस छुपाना, श्रेणी एक्सिस प्रकार बदलना, श्रेणी एक्सिस मानों के लिए तिथि प्रारूप निर्धारित करना, एक्सिस शीर्षक को घुमाना, एक्सिस की स्थिति सेट करना, और मान एक्सिस पर यूनिट लेबल दिखाना दर्शाता है।

## **ऊर्ध्वाधर एक्सिस पर अधिकतम मान प्राप्त करें**
Aspose.Slides for C++ आपको ऊर्ध्वाधर एक्सिस पर न्यूनतम और अधिकतम मान प्राप्त करने की सुविधा देता है। इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक उदाहरण बनाएं।
2. पहली स्लाइड तक पहुंचें।
3. डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ें।
4. एक्सिस पर वास्तविक अधिकतम मान प्राप्त करें।
5. एक्सिस पर वास्तविक न्यूनतम मान प्राप्त करें।
6. एक्सिस की वास्तविक प्रमुख इकाई प्राप्त करें।
7. एक्सिस की वास्तविक लघु इकाई प्राप्त करें।
8. एक्सिस के वास्तविक प्रमुख इकाई स्केल प्राप्त करें।
9. एक्सिस के वास्तविक लघु इकाई स्केल प्राप्त करें।

यह नमूना कोड—उपरोक्त चरणों का कार्यान्वयन—आपको C++ में आवश्यक मान प्राप्त करने का तरीका दिखाता है:

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

// प्रस्तुति को सहेजें
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **एक्सिस के बीच डेटा बदलें**
Aspose.Slides आपको जल्दी से एक्सिस के बीच डेटा बदलने की अनुमति देता है—ऊर्ध्वाधर एक्सिस (y‑axis) पर प्रदर्शित डेटा क्षैतिज एक्सिस (x‑axis) पर चला जाता है और इसके विपरीत।

यह C++ कोड आपको चार्ट में एक्सिस के बीच डेटा स्वैप करने का तरीका दिखाता है:

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

## **लाइन चार्ट्स के लिए ऊर्ध्वाधर एक्सिस अक्षम करें**

यह C++ कोड आपको लाइन चार्ट के लिए ऊर्ध्वाधर एक्सिस को छुपाने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **लाइन चार्ट्स के लिए क्षैतिज एक्सिस अक्षम करें**

यह कोड आपको लाइन चार्ट के लिए क्षैतिज एक्सिस को छुपाने का तरीका दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **एक श्रेणी एक्सिस बदलें**

**set_CategoryAxisType()** मेथड का उपयोग करके आप अपनी वांछित श्रेणी एक्सिस प्रकार (**date** या **text**) निर्दिष्ट कर सकते हैं। यह C++ कोड इस कार्य को प्रदर्शित करता है:

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

## **श्रेणी एक्सिस मानों के लिए तिथि प्रारूप निर्धारित करें**
Aspose.Slides for C++ आपको श्रेणी एक्सिस मान के लिए तिथि प्रारूप सेट करने की अनुमति देता है। यह C++ कोड इस ऑपरेशन को दर्शाता है:

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

## **एक्सिस शीर्षक के लिए घूर्णन कोण सेट करें**
Aspose.Slides for C++ आपको चार्ट एक्सिस शीर्षक के लिए घूर्णन कोण सेट करने देता है। यह C++ कोड इस ऑपरेशन को दर्शाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **श्रेणी या मान एक्सिस पर एक्सिस की स्थिति निर्धारित करें**
Aspose.Slides for C++ आपको श्रेणी या मान एक्सिस पर एक्सिस की स्थिति सेट करने देता है। यह C++ कोड कार्य को कैसे पूरा करें दिखाता है:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **चार्ट मान एक्सिस पर डिस्प्ले यूनिट लेबल सक्षम करें**
Aspose.Slides for C++ आपको चार्ट को ऐसे कॉन्फ़िगर करने देता है कि वह अपने मान एक्सिस पर यूनिट लेबल दिखाए। यह C++ कोड इस ऑपरेशन को दर्शाता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**एक्सिस के एक दूसरे को कहाँ काटना है (axis crossing) का मान कैसे सेट करूँ?**

Axes एक [crossing setting](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/axis/set_crosstype/) प्रदान करते हैं: आप शून्य पर, अधिकतम श्रेणी/मान पर, या किसी विशिष्ट संख्यात्मक मान पर क्रॉस करना चुन सकते हैं। यह X‑axis को ऊपर या नीचे शिफ्ट करने या बेसलाइन को ज़ोर देने में उपयोगी है।

**टिक लेबल को एक्सिस के सापेक्ष (साथ में, बाहर, अंदर) कैसे स्थित करूँ?**

[label position](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/axis/set_majortickmark/) को "cross", "outside", या "inside" पर सेट करें। यह पठनीयता को प्रभावित करता है और विशेष रूप से छोटे चार्ट्स में जगह बचाने में मदद करता है।