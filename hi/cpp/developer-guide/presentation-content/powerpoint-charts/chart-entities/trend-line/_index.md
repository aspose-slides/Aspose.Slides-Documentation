---
title: C++ में प्रस्तुतिकरण चार्ट में ट्रेंड लाइनों को जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/cpp/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- घातीय ट्रेंड लाइन
- रैखिक ट्रेंड लाइन
- लघुगणकीय ट्रेंड लाइन
- चल औसत ट्रेंड लाइन
- बहुपद ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint चार्ट में शीघ्रता से ट्रेंड लाइनों को जोड़ें और अनुकूलित करें — आपके दर्शकों को आकर्षित करने के लिए एक व्यावहारिक गाइड।"
---
## **Overview**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइनों को जोड़ने के बारे में समझाता है। यह चार्ट बनाने, चार्ट श्रृंखला में ट्रेंड लाइनों को जोड़ने, और कई ट्रेंड लाइन प्रकारों जैसे घातीय, रैखिक, लघुगणकीय, चल औसत, बहुपद, और पावर के साथ काम करने को दर्शाता है।

यह भी बताता है कि कैसे एक लाइन शेप डालकर चार्ट में कस्टम लाइन जोड़ी जा सकती है, और फॉरवर्ड और बैकवर्ड ट्रेंड लाइन प्रोजेक्शन मानों तथा क्या ट्रेंड लाइनों को PDF या SVG में निर्यात करने या चार्ट को छवियों के रूप में रेंडर करने के दौरान संरक्षित रखा जाता है, के बारे में एक छोटा FAQ शामिल है।

## **Add a Trend Line**

चार्ट श्रृंखला में ट्रेंड लाइन जोड़ने के लिए [ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) का उपयोग करें, और उसका प्रकार [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) के साथ चुनें। यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक तीन श्रृंखलाओं में दो ट्रेंड लाइनों को जोड़ता है।

घातीय ट्रेंड लाइन अपने समीकरण और R‑स्क्वेयर मान को [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) और [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) के माध्यम से छिपाती है, जबकि रैखिक ट्रेंड लाइन लाल होती है। लघुगणकीय ट्रेंड लाइन कस्टम लेबल के लिए [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) का उपयोग करती है। चल औसत तीन डेटा बिंदुओं का औसत निकालने के लिए [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) का उपयोग करता है और कस्टम नाम के लिए [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) का उपयोग करता है।

बहुपद ट्रेंड लाइन अपने क्रम को तीन पर सेट करने के लिए [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) का उपयोग करती है और [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/) के माध्यम से एक श्रेणी आगे बढ़ाती है। पावर ट्रेंड लाइन एक श्रेणी पीछे की ओर बढ़ाने के लिए [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/) का उपयोग करती है।

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Set a Trend Line Intercept**

ट्रेंड लाइन का Y मान X = 0 पर निश्चित करने के लिए [ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) का उपयोग करें। यह सेटिंग रैखिक, घातीय और बहुपद ट्रेंड लाइनों के लिए समर्थित है।

उदाहरण के लिए, एक उत्पादन लागत मॉडल को ज्ञात निश्चित लागत 100 से शुरू होना पड़ सकता है, भले ही शून्य‑नहीं उत्पादन मात्रा पर माप अलग आधार रेखा सुझाते हों। रैखिक ट्रेंड लाइन के लिए, इंटरसेप्ट को निश्चित करने से समीकरण `y = ax + b` पर `b = 100` बाध्य हो जाता है; इस प्रतिबंध के तहत ढाल डेटा के अनुसार फिट की जाती है। यह केवल पहले से फिट की गई लाइन को स्थानांतरित नहीं करता। एक्सिस क्रॉसिंग सेटिंग्स निर्धारित करती हैं कि चार्ट एक्सिस कहाँ मिलते हैं, न कि फिट की गई ट्रेंड लाइन के गुणांक।

निम्नलिखित उदाहरण 1 से 4 तक के उत्पादन मात्रा और 170, 200, 230, तथा 260 की लागत के साथ एक स्कैटर (XY) चार्ट बनाता है। यह चार्ट को डिफ़ॉल्ट स्वतः इंटरसेप्ट के साथ सहेजता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सहेजता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में ही भिन्न हैं। ट्रेंड लाइन अपना समीकरण दर्शाती है और X = 0 तक पीछे की ओर विस्तारित होती है।

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

स्वचालित गणना के साथ, ये डेटा `y = 30x + 140` उत्पन्न करते हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` प्राप्त होता है: शून्य पर फिट किया गया मान ज्ञात आधार रेखा से मेल खाता है, जबकि लाइन अब हर डेटा बिंदु से नहीं गुजरती।

| स्वचालित इंटरसेप्ट | 100 का निश्चित इंटरसेप्ट |
| --- | --- |
| ![रैखिक ट्रेंड लाइन जिसमें 140 का स्वचालित गणना किया गया इंटरसेप्ट है](intercept-automatic.png) | ![रैखिक ट्रेंड लाइन जिसमें 100 का निश्चित इंटरसेप्ट है](intercept-fixed.png) |

दोनों छवियों में वही डेटा और एक्सिस स्केल उपयोग किए गए हैं। ट्रेंड लाइनों को उनका इंटरसेप्ट दिखाने के लिए X = 0 तक पीछे की ओर विस्तारित किया गया है।

डिफ़ॉल्ट रूप से, इस प्रॉपर्टी में `std::numeric_limits<double>::quiet_NaN()` होता है, जो शून्य की बजाय अनिर्दिष्ट इंटरसेप्ट को दर्शाता है। फिर इंटरसेप्ट डेटा से स्वचालित रूप से गणना किया जाता है।

## **Add a Custom Line**

कस्टम लाइन एक आकार है जो चार्ट के ऊपर खींचा जाता है, न कि श्रृंखला डेटा से गिनी गई ट्रेंड लाइन। यह उदाहरण [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) का उपयोग करके चार्ट के ऊपर स्लाइड में एक क्षैतिज रेखा जोड़ता है। रेखा की स्थिति स्लाइड निर्देशांक में बिंदुओं में निर्धारित की गई है, इसलिए यह चार्ट के बाएँ किनारे से शुरू होती है और चार्ट के मध्य में स्थित होती है। इसकी चौड़ाई चार्ट की चौड़ाई के बराबर होती है। [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) द्वारा लौटाए गए रेखा स्वरूप से रेखा को ठोस लाल रंग मिलता है।

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **FAQ**

**ट्रेंड लाइन के लिए 'फॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

वे ट्रेंड लाइन की आगे/पीछे प्रोजेक्ट की गई लंबाइयाँ हैं: स्कैटर (XY) चार्ट्स के लिए — अक्ष इकाइयों में; गैर‑स्कैटर चार्ट्स के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मानों की अनुमति है।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को छवि के रूप में रेंडर करने पर ट्रेंड लाइन संरक्षित रहती है?**

हाँ। Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/cpp/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/cpp/render-a-slide-as-an-svg-image/) में परिवर्तित करता है और चार्ट को छवियों में रेंडर करता है; ट्रेंड लाइनों को, चार्ट के भाग के रूप में, इन ऑपरेशनों के दौरान संरक्षित रखा जाता है। एक मेथड भी उपलब्ध है जो स्वयं चार्ट की छवि को [चार्ट की छवि निर्यात करें](/slides/hi/cpp/shape-thumbnails/) निर्यात करता है।