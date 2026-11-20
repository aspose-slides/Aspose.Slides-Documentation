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
- अक्ष को हेरफेर करें
- अक्ष का प्रबंधन करें
- अक्ष गुण
- अधिकतम मान
- न्यूनतम मान
- अक्ष रेखा
- तिथि स्वरूप
- अक्ष शीर्षक
- अक्ष स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके रिपोर्ट और विज़ुअलाइज़ेशन के लिए PowerPoint प्रस्तुतियों में चार्ट अक्ष को कैसे अनुकूलित करें, जानें।"
---
## **सारांश**

यह लेख Aspose.Slides for C++ के साथ चार्ट अक्षों को अनुकूलित करने के तरीके को समझाता है। इसमें गणना किए गए अक्ष मान, चार्ट पंक्तियों एवं स्तंभों को स्विच करना, अक्ष की दृश्यता, श्रेणी लेबल और टिक‑मार्क अंतराल, तिथि श्रेणियाँ और स्वरूपण, शीर्षक का घूर्णन, अक्ष का स्थान, प्रदर्शित इकाइयाँ, और लॉगरिदमिक स्केलिंग शामिल हैं।

## **चार्ट में लंबवत अक्ष पर अधिकतम मान प्राप्त करें**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएं और डिफ़ॉल्ट डेटा के साथ एक एरिया चार्ट जोड़ें। गणना किए गए अक्ष मान पढ़ने से पहले [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) कॉल करें ताकि चार्ट लेआउट अद्यतित रहे।

[get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) और [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) को अक्ष की सीमा प्राप्त करने के लिए पढ़ें, तथा [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) और [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) को टिक अंतराल के लिए पढ़ें। [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) और [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) समय‑इकाई स्केल प्रदान करते हैं, जो तिथि अक्षों के लिए प्रासंगिक हैं। उदाहरण इन मानों को स्थानीय चर में संग्रहीत करता है और चार्ट को सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **अक्षों के बीच डेटा स्वैप करें**

[SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) का उपयोग करके चार्ट डेटा में श्रृंखला और श्रेणियों की भूमिकाएँ बदलें। प्रत्येक पूर्व श्रेणी एक श्रृंखला बन जाती है, और प्रत्येक पूर्व श्रृंखला एक श्रेणी बन जाती है। यह डेटा समूहबद्ध करने के तरीके को बदलता है; यह क्षैतिज और लंबवत अक्षों को नहीं बदलता। उदाहरण [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) का उपयोग करके डिफ़ॉल्ट डेटा को `Sheet1!A1:D5` से बाँधता है, जिसमें हेडर पंक्ति और श्रेणी स्तम्भ शामिल हैं, फिर पंक्तियों और स्तंभों को स्विच करता है। यह चार श्रृंखला और तीन श्रेणियों वाले चार्ट को सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **अक्ष की प्लॉटिंग क्रम को उलटें**

[set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) का उपयोग करके एक श्रेणी या मान अक्ष को उलटा करें। उदाहरण के तौर पर, एक क्षैतिज बार चार्ट कार्य चरणों को शीर्ष से नीचे उसी क्रम में दिखा सकता है जैसा कि कार्यपत्र में है: योजना, विकास, परीक्षण। अक्ष को उलटने से प्लॉटिंग दिशा बदलती है; यह कार्यपत्र डेटा को क्रमबद्ध या पुनः व्यवस्थित नहीं करता। तुलना में, [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) श्रृंखला और श्रेणियों की भूमिकाओं को बदलता है।

निम्न उदाहरण तीन चरणों और एक श्रृंखला के साथ एक क्षैतिज बार चार्ट बनाता है। यह प्रस्तुति को तीन स्लाइड के साथ सहेजता है: सामान्य क्रम, उल्टे श्रेणी, और उल्टे मान। प्रत्येक प्रति समान डेटासेट का उपयोग करती है, और प्रत्येक प्रति में केवल एक अक्ष उलटा होता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// Slide 2: पहले श्रेणी को शीर्ष पर दिखाएँ।
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// क्षैतिज मान अक्ष को नीचे रखें।
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: केवल क्षैतिज संख्यात्मक स्केल को उलटें।
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

अक्ष को उलटने से लम्बवत अक्ष को भी प्लॉट के विपरीत पक्ष पर ले जाया जा सकता है। [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) निर्धारित करता है कि कॉन्फ़िगर किए जा रहे अक्ष को दूसरा अक्ष कहाँ काटता है। स्लाइड 2 में, उल्टे श्रेणी अक्ष पर इसे `Maximum` सेट करने से क्षैतिज मान अक्ष नीचे रहता है। किसी विशिष्ट कटाव बिंदु के लिए, [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) का प्रयोग करें। दिशा बदलते समय कटाव सेटिंग की जाँच करें, विशेष रूप से यदि चार्ट में पहले से ही कोई कस्टम कटाव बिंदु मौजूद है। सामान्य प्लॉटिंग दिशा पुनर्स्थापित करने के लिए `set_IsPlotOrderReversed` को `false` के साथ कॉल करें; कटाव सेटिंग अलग रहती है।

| सामान्य क्रम (स्लाइड 1) | उल्टे श्रेणी (स्लाइड 2) | उल्टे मान (स्लाइड 3) |
| --- | --- | --- |
| ![सामान्य श्रेणी और मान अक्ष क्रम वाला क्षैतिज बार चार्ट](axis-order-normal.png) | ![शीर्ष से नीचे श्रेणियों को दिखाने वाला क्षैतिज बार चार्ट](axis-order-categories-reversed.png) | ![उलटा मान अक्ष और दाएँ शून्य वाला क्षैतिज बार चार्ट](axis-order-values-reversed.png) |
| श्रेणियाँ नीचे से ऊपर जाती हैं; मान बाएँ से दाएँ बढ़ते हैं। | योजना, विकास, और परीक्षण शीर्ष से नीचे चलते हैं। मान और कार्यपत्र क्रम अपरिवर्तित रहता है। | श्रेणियों का क्रम सामान्य रहता है; मान दाएँ से बाएँ बढ़ते हैं। श्रेणी अक्ष दाएँ शून्य पर काटता है। |

## **लाइन चार्ट के लिए लंबवत अक्ष को निष्क्रिय करें**

`false` के साथ लंबवत अक्ष पर [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) का प्रयोग करके उसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और लंबवत अक्ष छिपा कर सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **लाइन चार्ट के लिए क्षैतिज अक्ष को निष्क्रिय करें**

`false` के साथ क्षैतिज अक्ष पर [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) का प्रयोग करके उसे छुपाएँ। उदाहरण डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है और क्षैतिज अक्ष छिपा कर सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **चार्ट ग्रिडलाइन दिखाएँ या छिपाएँ**

किसी अक्ष द्वारा प्रदर्शित ग्रिडलाइन को पता करने के लिए [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) और [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) का उपयोग करें। दोनों गुण केवल‑पढ़ने योग्य हैं। छोटे ग्रिडलाइन दिखाने के लिए [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) का उपयोग करके रेखा भराव को ठोस, दृश्यमान रंग पर सेट करें। उन्हें छिपाने के लिए भराव को [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करें। प्रमुख ग्रिडलाइन को उसी तरह बदलने के लिए [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) का उपयोग करें। ग्रिडलाइन भराव बदलने से अक्ष की दृश्यता और टिक‑मार्क संरक्षित रहते हैं।

इस क्लस्टर्ड कॉलम चार्ट के लंबवत अक्ष में प्रारंभ में केवल प्रमुख ग्रिडलाइन दिखती थीं। उदाहरण छोटे ग्रिडलाइन को नारंगी रंग में दिखाता है, फिर उन्हें फिर से छिपाकर प्रस्तुति सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| छोटे ग्रिडलाइन सक्षम | छोटे ग्रिडलाइन छिपे हुए |
| --- | --- |
| ![लंबवत अक्ष पर प्रमुख ग्रिडलाइन के बीच नारंगी छोटे ग्रिडलाइन](minor-gridlines-enabled.png) | ![केवल प्रमुख ग्रिडलाइन दिखाने वाला वही कॉलम चार्ट](minor-gridlines-hidden.png) |

## **श्रेणी अक्ष बदलें**

[set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) का उपयोग करके तिथि या पाठ श्रेणी अक्ष चुनें। यह उदाहरण `ExistingChart.pptx` की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक चार्ट है और श्रेणी कोशिकाएँ संख्यात्मक Excel तिथि मान रखती हैं। यह क्षैतिज अक्ष को तिथि अक्ष में बदलता है। [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) को `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) को `1`, और [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) को महीनों पर सेट करने से प्रमुख टिक एक‑माह अंतराल पर पड़ते हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

### **डेटा से श्रेणी अक्ष प्रकार निर्धारित करें**

श्रेणियों को भरने के बाद [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) को कॉल करें, फिर चयन का निरीक्षण करने के लिए [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) को कॉल करें। यह उपयोगी है जब समान चार्ट को या तो पाठ लेबल या संख्यात्मक तिथि मान प्राप्त होते हैं। यह विधि कॉल किये जाने पर प्रकार निर्धारित करती है; यह किसी स्थायी मोड को सक्रिय नहीं करती जो बाद के डेटा परिवर्तन पर पुनः‑मूल्यांकन करे। श्रेणियों को बदला जाने के बाद इसे फिर से कॉल करें।

निम्न उदाहरण पाठ श्रेणियों वाले चार्ट को बनाता है और `Text` प्रिंट करता है। फिर श्रेणी कोशिका मानों को तिथियों से बदलता है और विधि को पुनः कॉल करता है, जो `Date` प्रिंट करता है। तिथियाँ संख्यात्मक OLE Automation मान के रूप में संग्रहीत होती हैं, जो [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/) द्वारा लौटाई जाती हैं, न कि तिथि स्ट्रिंग से। [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) यह नियंत्रित करता है कि ये मान कैसे प्रदर्शित हों; यह पाठ को संख्यात्मक तिथि में नहीं बदलता। श्रेणी कोशिकाओं के बारे में अधिक जानकारी के लिए देखें [Chart Workbook](/slides/hi/cpp/chart-workbook/)।

इनपुट में यदि केवल पाठ श्रेणियाँ या संख्यात्मक तिथियाँ हों तो स्वचालित निर्धारण का उपयोग करें, जैसा कि इस उदाहरण में दिखाया गया है। सामान्य संख्यात्मक लेबल, मिश्रित श्रेणियाँ, या खाली डेटा के लिए इच्छित अर्थ के अनुरूप स्पष्ट रूप से [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) को कॉल करके सेट करें। केवल संख्यात्मक मान यह स्थापित नहीं करते कि श्रेणियाँ तिथियाँ दर्शा रही हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // पाठ

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // तारीख

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **श्रेणी अक्ष लेबल अंतराल को नियंत्रित करें**

जब चार्ट में कई श्रेणियाँ हों, तो श्रेणी या डेटा बिंदुओं को हटाए बिना दृश्य अक्ष लेबल की संख्या घटाएँ। [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) को `false` सेट करें, फिर वांछित श्रेणी अंतराल के साथ [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) का उपयोग करें। सामान्य क्रम में पाठ श्रेणियों के लिए गिनती पहली श्रेणी से शुरू होती है:

| अंतराल | उदाहरण में प्रदर्शित लेबल |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

`3` का अंतराल हर तीसरा लेबल दिखाता है, दो लेबल छिपे रहते हैं। यह संबंधित स्तम्भों को नहीं हटाता। स्वचालित अंतराल उपलब्ध स्थान के आधार पर चयन करता है; यह आवश्यक नहीं कि हर लेबल दिखे।

टिक‑मार्क के लिए अलग नियंत्रण होते हैं। [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) को `false` सेट करें और [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) के साथ उनका अंतराल निर्धारित करें। उदाहरण के तौर पर, `1` प्रत्येक श्रेणी अंतराल पर टिक‑मार्क रखता है जबकि लेबल केवल प्रत्येक तीसरी श्रेणी पर दिखते हैं। एक दृश्य शैली के साथ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) का उपयोग करके परिणाम देखें। किसी भी स्वचालित‑अंतराल गुण को फिर से `true` पर सेट करने से चार्ट को वह अंतराल पुनः चुनने की अनुमति मिलती है।

निम्न स्व-समायोज्य उदाहरण 24 श्रेणियों और एक श्रृंखला बनाता है, फिर `CategoryAxisIntervals.pptx` में तीन स्लाइड सहेजता है: स्वचालित अंतराल, स्वतंत्र टिक्स के साथ मैनुअल लेबल अंतराल, और पुनर्स्थापित स्वचालित अंतराल। दोनों प्रतियों में मूल चार्ट डेटा बना रहता है। इनपुट प्रस्तुति की आवश्यकता नहीं है। क्षैतिज लेबल पाठ घनत्व अंतर को स्पष्ट रूप से दिखाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// स्लाइड 2: हर तीसरा लेबल दिखाएँ, लेकिन प्रत्येक श्रेणी के लिए एक टिक‑मार्क रखें।
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// स्लाइड 3: चार्ट को फिर से दोनों अंतराल चुनने दें।
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**स्वचालित अंतराल (स्लाइड 1):** इस रेंडरिंग में प्रत्येक दूसरी श्रेणी लेबल दिखाई देता है और दो पंक्तियों में विभाजित होता है। स्वचालित परिणाम चार्ट आकार, फ़ॉन्ट और रेंडरर पर निर्भर करता है।

![सभी 24 स्तम्भ दृश्यमान के साथ स्वचालित श्रेणी लेबल अंतराल](category-axis-automatic.png)

**मैनुअल अंतराल (स्लाइड 2):** प्रत्येक तीसरा लेबल एक पंक्ति में दिखता है, जबकि टिक‑मार्क प्रत्येक श्रेणी अंतराल पर रहते हैं। सभी 24 स्तम्भ, जिनमें बिना लेबल वाले स्तम्भ भी शामिल हैं, समान मानों के साथ दृश्य रहते हैं। स्लाइड 3 ऊपर दिखाए गए स्वचालित रूप को पुनर्स्थापित करता है।

![सभी 24 स्तम्भ दृश्यमान के साथ तीन के मैनुअल श्रेणी लेबल अंतराल](category-axis-manual.png)

### **सही अक्ष और अंतराल चुनें**

पाठ श्रेणी अक्ष के लिए यह श्रेणी‑गणना अंतराल उपयोग करें, जैसे कॉलम, लाइन, एरिया या बार चार्ट का श्रेणी अक्ष। कॉलम चार्ट में यह क्षैतिज अक्ष होता है। क्षैतिज बार चार्ट में श्रेणी अक्ष लंबवत होता है, इसलिए इन सेटिंग्स को [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) पर लागू करें। टिक‑मार्क अंतराल उन चार्ट्स में श्रृंखला अक्ष पर भी लागू होता है जिनमें वह मौजूद होता है।

श्रेणी लेबल अंतराल का उपयोग मान अक्ष के संख्यात्मक स्केल को निर्धारित करने के लिए न करें। मान अक्ष पर, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) मानों के अंतर को निर्दिष्ट करता है: उदाहरण के तौर पर, `10` का प्रमुख इकाई 0, 10, 20 आदि पर टिक उत्पन्न करता है जब अक्ष शून्य से शुरू होता है। `3` का श्रेणी लेबल अंतराल केवल श्रेणी स्थितियों को गिनता है, उनके डेटा मानों की परवाह किए बिना। स्कैटर और बबल चार्ट मान अक्षों का उपयोग करते हैं, न कि पाठ श्रेणी अक्ष का। तिथि अक्ष के लिए, [Change a Category Axis](#change-a-category-axis) में वर्णित समय‑आधारित प्रमुख इकाइयाँ और स्केल का उपयोग करें।

## **श्रेणी अक्ष मानों के लिए तिथि स्वरूप सेट करें**

उदाहरण डिफ़ॉल्ट चार्ट डेटा को चार वार्षिक मानों से बदलता है। तिथियों को पहले कार्यपत्र (सूचक `0`) में OLE Automation क्रमांक के रूप में संग्रहीत किया जाता है। तिथि अक्ष चुनने के लिए [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) का उपयोग करें, स्रोत‑संलग्न स्वरूपण को निष्क्रिय करने के लिए [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) का उपयोग करें, और `yyyy` को [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) के साथ असाइन करें ताकि श्रेणी लेबल चार्ट सेल स्वरूपण से स्वतंत्र रूप से चार-अंकीय वर्ष दिखाएँ।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **चार्ट अक्ष शीर्षक के लिए घूर्णन कोण सेट करें**

[set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) के साथ लंबवत‑अक्ष शीर्षक सक्रिय करें, शीर्षक पाठ प्रदान करें, और [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) का प्रयोग करके शीर्षक को घुमाएँ। कोण को डिग्री में मापा जाता है; यह उदाहरण कॉलम चार्ट को उसके मान‑अक्ष शीर्षक को 90 डिग्री घुमाकर सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **श्रेणी या मान अक्ष पर अक्ष स्थान निर्धारित करें**

[set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) का उपयोग करके निर्धारित करें कि मान अक्ष श्रेणी अक्ष को श्रेणियों के बीच या श्रेणी टिक‑मार्क पर काटता है। यह गुण केवल श्रेणी अक्षों पर लागू होता है। उदाहरण इसे कॉलम चार्ट के क्षैतिज श्रेणी अक्ष पर `true` सेट करता है और परिणाम सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **चार्ट मान‑अक्ष पर प्रदर्शित इकाई सेट करें**

[set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) का उपयोग करके मान अक्ष पर लेबल को स्केल करें बिना मूल डेटा बदले। जब [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) को `Millions` पर सेट किया जाता है, तो 60 000 000 को 60 के रूप में दिखाया जाता है। उदाहरण एक कॉलम चार्ट बनाता है और उसके लंबवत अक्ष पर मिलियन प्रदर्शित इकाई लागू करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **लॉगरिदमिक मान‑अक्ष को कॉन्फ़िगर करें**

लॉगरिदमिक मान‑अक्ष तब उपयोगी होता है जब सकारात्मक मान कई क्रम घटकों में फैले हों। उदाहरण के तौर पर, एक सेवा पाँच अवधि में 10, 100, 1 000, 10 000 और 100 000 अनुरोध प्राप्त कर सकती है। रैखिक स्केल पर छोटे मान शून्य के निकट बहुत करीब होते हैं। लॉगरिदमिक स्केल उनके सापेक्ष वृद्धि को तुलना योग्य बनाता है: समान दूरी समान अनुपात दर्शाती है, न कि समान अंतर।

मान अक्ष पर `true` के साथ [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) कॉल करें और बेस चुनने के लिए [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) का उपयोग करें। यह मौजूदा मानों के प्रदर्शित रूप को बदलता है; यह डेटा नहीं बदलता या लॉगरिदमिक ट्रेंड‑लाइन नहीं जोड़ता। ट्रेंड‑लाइन डेटा में फिटेड संबंध का प्रतिनिधित्व करती है और अलग सुविधा है।

### **मान अक्ष और बेस चुनें**

लाइन या कॉलम चार्ट के लिए मान अक्ष [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) है। क्षैतिज बार चार्ट के लिए यह [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) है। स्कैटर और बबल चार्ट में दो मान अक्ष होते हैं, इसलिए X मानों के लिए क्षैतिज अक्ष, Y मानों के लिए लंबवत अक्ष, या दोनों चुनें। लॉगरिदमिक स्केलिंग को श्रेणी अक्ष पर लागू न करें।

डिफ़ॉल्ट लॉगरिदमिक बेस `10` है। PPTX चार्ट के लिए, `2` से `1000` तक का बेस, सहित, उपयोग किया जा सकता है; `2.5` जैसी भिन्नात्मक बेस भी समर्थित हैं। बेस `10` के साथ 10, 100, 1 000, 10 000 क्रमिक शक्ति समान अंतराल पर होती हैं।

### **रैखिक और लॉगरिदमिक स्केल की तुलना करें**

निम्न स्व‑समायोज्य उदाहरण पहली स्लाइड पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट बनाता है, फिर उस स्लाइड को क्लोन करके दूसरी पर बेस‑10 लॉगरिदमिक मान‑अक्ष सक्षम करता है। दोनों स्लाइड समान डेटा रखती हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// पहली स्लाइड को रैखिक रखें और केवल प्रतिलिपि के मान-अक्ष स्केल को बदलें।
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**रैखिक स्केल (स्लाइड 1):** समान ऊँचाई अंतराल अनुरोध गणनाओं में समान अंतर का प्रतिनिधित्व करता है। बड़ा मान चार्ट को हावी कर देता है, जिससे छोटे मान देखना कठिन हो जाता है।

![रैखिक मान‑अक्ष पर पाँच अनुरोध गणनाओं के साथ लाइन चार्ट](value-axis-linear.png)

**लॉगरिदमिक स्केल (स्लाइड 2):** समान ऊँचाई अंतराल समान अनुपात दर्शाते हैं। प्रत्येक अवधि में पिछले अवधि से दस गुना अधिक अनुरोध होते हैं, इसलिए बिंदु बेस‑10 स्केल पर सीधा ऊपर की ओर रेखा बनाते हैं। अक्ष लेबल अभी भी मूल अनुरोध गणनाएँ दिखाते हैं।

![बेस‑10 लॉगरिदमिक मान‑अक्ष पर वही पाँच अनुरोध गणनाएँ](value-axis-logarithmic.png)

### **शून्य और नकारात्मक मानों को संभालें**

लॉगरिदमिक स्केल केवल सख़्त‑सकारात्मक मान दिखा सकता है। इसे सक्रिय करने से पहले डेटा जाँचें। यदि शून्य या नकारात्मक मान अर्थपूर्ण हैं, तो रैखिक स्केल रखें या उन्हें अलग से दिखाएँ। यदि विश्लेषण के लिये उन मानों को बाहर करना उपयुक्त है, तो बाहर करने का कारण बताएं। उन्हें छोटा सकारात्मक मान से चुपचाप बदलना डेटा का अर्थ बदल देता है। लॉगरिदमिक अक्ष के लिए मैन्युअल रूप से सेट किया गया न्यूनतम या अधिकतम भी सकारात्मक होना चाहिए।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं एक अक्ष को दूसरे अक्ष के पार कहाँ काटता है (अक्ष पार) को कैसे सेट करूँ?**

[set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) का उपयोग करके कटाव व्यवहार चुनें। संख्यात्मक कटाव मान निर्दिष्ट करने के लिए [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) उपयोग करें। ये सेटिंग्स आपको अक्ष कटाव को उपयुक्त आधार रेखा पर ले जाने की अनुमति देती हैं।

**मैं टिक‑लेबल को अक्ष के सापेक्ष कैसे स्थित करूँ?**

[TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) में से `Low`, `High`, `NextTo` या `None` मान के साथ [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) का प्रयोग करें। टिक‑मार्क स्वयं को नियंत्रित करने के लिए, [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) या [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) का उपयोग करें; ये लेबल स्थितिकरण से अलग हैं।