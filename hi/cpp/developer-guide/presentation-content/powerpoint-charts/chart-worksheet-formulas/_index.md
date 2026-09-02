---
title: C++ का उपयोग करके प्रस्तुतियों में चार्ट वर्कशीट फॉर्मूले लागू करें
linktitle: वर्कशीट फॉर्मूले
type: docs
weight: 70
url: /hi/cpp/chart-worksheet-formulas/
keywords:
- चार्ट स्प्रेडशीट
- चार्ट वर्कशीट
- चार्ट फॉर्मूला
- वर्कशीट फॉर्मूला
- स्प्रेडशीट फॉर्मूला
- चार्ट डेटा वर्कबुक
- फॉर्मूला गणना
- पसंदीदा संस्कृति
- संस्कृति-विशिष्ट फॉर्मूला
- DBCS
- लॉजिकल स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलनात्मक ऑपरेटर
- A1 शैली
- R1C1 शैली
- प्रीडिफाइंड फ़ंक्शन
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ चार्ट वर्कशीट में Excel‑शैली के फॉर्मूले लागू करें, मानों की पुनर्गणना करें, और परिणामों को PowerPoint चार्ट में उपयोग करें।"
---
## **सारांश**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एम्बेडेड वर्कशीट में स्टोर करते हैं। Aspose.Slides for C++ में आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुंच सकते हैं, इनपुट मान लिख सकते हैं, सेल को फॉर्मूले असाइन कर सकते हैं, समर्थित फॉर्मूलों की गणना कर सकते हैं, और गणना किए गए सेल को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख संपूर्ण फॉर्मूला वर्कफ़्लो को समझाता है: चार्ट बनाना, उसकी वर्कशीट को भरना, A1-स्टाइल या R1C1-स्टाइल फॉर्मूले असाइन करना, उन्हें पुनर्गणना करना, गणना किए गए मान पढ़ना, उन सेल को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति सहेजना। इसमें समर्थित फॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश्ड मान, असमर्थित फॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का वर्णन भी किया गया है।

## **चार्ट वर्कशीट और फॉर्मूले**

एक चार्ट वर्कशीट में चार्ट द्वारा उपयोग की जाने वाली श्रेणियां, सीरीज़ नाम और मान होते हैं। PowerPoint में आप चार्ट डेटा एडिटर खोलकर वर्कशीट को देख सकते हैं:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/) इंटरफ़ेस के माध्यम से उजागर किया जाता है। A1‑स्टाइल फॉर्मूले के लिए [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) और R1C1‑स्टाइल फॉर्मूले के लिए [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) का उपयोग करें। इनपुट सेल या फॉर्मूले बदलने के बाद, समर्थित फॉर्मूलों को पुनर्गणना करने और संबंधित सेल मान को अपडेट करने के लिए [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

एक गणना किया गया सेल अभी भी अपने परिणाम को [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) के माध्यम से उजागर करता है। यह तब महत्वपूर्ण होता है जब आपको कोड में फॉर्मूला परिणाम की जांच करनी हो या सेल को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **चार्ट बनाना और वर्कशीट फॉर्मूलों की गणना करना**

निम्नलिखित उदाहरण एक एंड‑टू‑एंड वर्कफ़्लो को दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, नमूना डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फॉर्मूलों के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना किए गए सेल को चार्ट मान के रूप में उपयोग करता है, और प्रस्तुति सहेजता है।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IDataLabelCollection.h>
#include <DOM/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों को उपयोग करता है। इस वर्कफ़्लो में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनर्गणना करें, फिर गणना किए गए सेल को उपयोग या सहेजें।

## **A1‑स्टाइल फॉर्मूले का उपयोग**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) के माध्यम से असाइन करें।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

सामान्य A1 रेफ़रेंस रूप हैं:

| रेफ़रेंस | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| कॉलम | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफ़रेंसेज़ को फॉर्मूला को स्थानांतरित या कॉपी करने पर बदला जा सकता है। एब्सोल्यूट रेफ़रेंसेज़ दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित रेफ़रेंस केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1‑स्टाइल फॉर्मूले का उपयोग**

R1C1 नोटेशन पंक्तियों और कॉलम दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफ़रेंसेज़ वर्ग कोष्ठकों में ऑफसेट का उपयोग करती हैं। इस सिंटैक्स को [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) के माध्यम से असाइन करें।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

सामान्य R1C1 रेफ़रेंस रूप हैं:

| रेफ़रेंस | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| कॉलम | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का मतलब है उसी पंक्ति में दो कॉलम बाईं ओर स्थित सेल (`B2`)।

## **फॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फॉर्मूला इवैल्युएटर लॉजिकल मान, न्यूमेरिक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को समर्थन देता है।

### **स्थिरांक और लिटरल**

| प्रकार | उदाहरण | नोट्स |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | `A2=TRUE` जैसी लॉजिकल अभिव्यक्तियों में सीधे उपयोग किया जा सकता है। |
| न्यूमेरिक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरल को फॉर्मूला के भीतर डबल कोट्स में रखा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | वैध फॉर्मूला का परिणाम सामान्य मान की बजाय स्प्रेडशीट त्रुटि मान भी हो सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का प्रयोग करता है:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // गलत
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या युनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घात | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठक का उपयोग करें, उदाहरण के लिए `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियों का परिणाम लॉजिकल मान होता है।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित प्री‑डिफाइन्ड फ़ंक्शन**

Aspose.Slides चार्ट वर्कशीट के लिए एक बिल्ट‑इन फॉर्मूला इवैल्युएटर शामिल करता है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। डॉक्यूमेंटेड फ़ंक्शन सेट नीचे दिखाए गए फ़ंक्शन तक सीमित है। यह मान न लें कि कोई भी Excel फ़ंक्शन `[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)` द्वारा पुनर्गणना किया जा सकता है।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | परिमाण मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय औसत | `AVERAGE(B2:B5)` |
| `CEILING` | ऊपर की ओर निकटतम बहुगुणक पर राउंड | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक के आधार पर मान चुनें | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मान जोड़ें | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मान जोड़ें | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग कर तिथि बनाएं | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिन गिनें | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट को दूसरे में खोजें | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्टिकल लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

तालिका में दर्शाए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को रेफ़रेंस रूप में दस्तावेज़ किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध नहीं किए गए फ़ंक्शन Aspose.Slides के फॉर्मूला इवैल्युएटर द्वारा असमर्थित माने जाएंगे, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पैसंदगी संस्कृति के साथ फॉर्मूले की गणना करना**

कुछ चार्ट वर्कबुक फ़ंक्शन टेक्स्ट को संस्कृति‑विशिष्ट नियमों के अनुसार व्याख्या करते हैं। यह विशेष रूप से उन फ़ंक्शनों के लिए महत्वपूर्ण है जो द्वि‑बाइट कैरेक्टर सेट (DBCS) भाषाओं के लिए बनाए गए हैं। ऐसे फॉर्मूले को सही तरीके से गणना करने के लिए, `[LoadOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/)` बनाएं, `[ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/)` को `[LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)` के माध्यम से कॉन्फ़िगर करें, और फिर प्रस्तुति को लोड करें।

निम्न उदाहरण जापानी संस्कृति का चयन करता है, कॉन्फ़िगर किए गए लोड विकल्पों के साथ एक प्रस्तुति खोलता है, और प्रत्येक चार्ट वर्कबुक के लिए `[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)` को कॉल करता है:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

प्रीफ़रड कल्चर प्रस्तुति लोडिंग कॉन्फ़िगरेशन का भाग है, इसलिए इसे `[Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/)` इंस्टेंस बनाने से पहले निर्दिष्ट करें। वर्कबुक फॉर्मूलों द्वारा अपेक्षित संस्कृति का उपयोग करें; उदाहरण के लिए, जापानी DBCS गणना नियमों के लिए `ja-JP` का उपयोग करें।

## **पुनर्गणना और कैश्ड मान**

स्प्रेडशीट फ़ाइलें आमतौर पर फॉर्मूला और उसकी अंतिम गणना किए गए मान दोनों को स्टोर करती हैं। Aspose.Slides इस कारण `[IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/)` से एक कैश्ड मान पढ़ सकता है जब प्रस्तुति लोड की गई हो और संबंधित चार्ट डेटा में कोई परिवर्तन न हुआ हो।

इनपुट सेल या फॉर्मूला बदलने के बाद, पुराने कैश्ड परिणाम पर निर्भर न रहें। गणना किए गए मान पढ़ने या उन पर निर्भर चार्ट डेटा सहेजने से पहले `[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)` को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फॉर्मूले के लिए, Aspose.Slides फॉर्मूला को पार्स करने या उसकी निर्भरताओं को स्थापित करने में असमर्थ हो सकता है। यदि वर्कबुक संशोधित हुई है, तो पहले का कैश्ड मान अब विश्वसनीय नहीं रहता। ऐसी स्थिति में, असमर्थित डेटा वाले सेल के मान को पढ़ने से `[CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)` उत्पन्न हो सकता है।

यदि आपके चार्ट को ऐसे Excel फ़ंक्शन की आवश्यकता है जिन्हें Aspose.Slides मूल्यांकित नहीं करता, तो उन फॉर्मूलों को किसी ऐसे स्प्रेडशीट इंजन के साथ गणना करें जो उनका समर्थन करता हो और परिणामित मानों को चार्ट वर्कबुक में वापस लिखें। असमर्थित फॉर्मूलों को अनुमानित मानों से प्रतिस्थापित न करें।

## **फ़ॉर्मूला त्रुटियों को संभालना**

दो प्रकार की समस्याओं में अंतर करना आवश्यक है।

* एक फॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!` दे सकता है। इस स्थिति में त्रुटि टोकन एक सेल परिणाम है और इसे `[IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/)` के माध्यम से प्राप्त किया जा सकता है।

* एक फॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: `[CellInvalidFormulaException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)`, `[CellInvalidReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/)`, `[CellCircularReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)`, और `[CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)`।

जब फॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आए हों, तो पुनर्गणना और मान पहुंच के आसपास इन अपवादों को संभालें:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // अमान्य फॉर्मूला को संभालें।
}
catch (CellInvalidReferenceException&)
{
    // अमान्य सेल रेफ़रेंस को संभालें।
}
catch (CellCircularReferenceException&)
{
    // परिपत्र रेफ़रेंस को संभालें।
}
catch (CellUnsupportedDataException&)
{
    // असमर्थित स्प्रेडशीट डेटा को संभालें।
}
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट में फॉर्मूला समर्थन एक निर्धारित उपसमुच्चय के लिए है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग वर्कफ़्लो डिज़ाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- केवल डॉक्यूमेंटेड स्थिरांक, ऑपरेटर, रेफ़रेंस और फ़ंक्शन का उपयोग करें जब आप चाहते हैं कि Aspose.Slides फॉर्मूलों को पुनर्गणना करे।
- उन सेल को बदलने के बाद पुनर्गणना करें जिन पर फॉर्मूला परिणाम निर्भर होते हैं।
- लोड की गई प्रस्तुतियों से प्राप्त कैश्ड मानों को स्नैपशॉट मानें, न कि संपादन के बाद पुनर्गणना के विकल्प के रूप में।
- मौजूदा टेम्प्लेट से फॉर्मूलों का परीक्षण करें और उनके गणना हुए मानों पर भरोसा करने से पहले सत्यापित करें, विशेषकर जब वे डॉक्यूमेंटेड सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- उन फॉर्मूलों के लिए जो पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता रखते हैं, उन्हें बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को परिणामित मानों से अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`set_Formula` और `set_R1C1Formula` में क्या अंतर है?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` संग्रहीत करता है। [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` संग्रहीत करता है। वह नोटेशन उपयोग करें जो आपके फॉर्मूला उत्पन्न या कॉपी करने के तरीके से सबसे अधिक मेल खाता हो।

**गणना के बाद क्या मुझे सेल स्वयं पढ़ना चाहिए या उसका मान?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) एक `IChartDataCell` लौटाता है। पुनर्गणना के बाद गणना किया गया परिणाम प्राप्त करने के लिए उस सेल के [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) मान को पढ़ें।

**`CalculateFormulas` को कब कॉल करना चाहिए?**

इनपुट मान या फॉर्मूला बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले `[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)` को कॉल करें। यह बिल्ट‑इन इवैल्युएटर द्वारा समर्थित फॉर्मूलों के मानों को अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन इवैल्युएटर डॉक्यूमेंटेड फ़ंक्शनों के एक उपसमुच्चय का समर्थन करता है। उस उपसमुच्चय से बाहर के फ़ंक्शनों को पुनर्गणना करने का अनुमान न लगाएँ। यदि पूर्ण Excel फॉर्मूला संगतता आवश्यक है, तो एक उपयुक्त स्प्रेडशीट इंजन के साथ गणना करें और अंतिम मानों को चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में असमर्थित फॉर्मूला हो तो क्या होगा?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक अभी भी पहले गणना किए गए कैश्ड मान रख सकता है। संबंधित डेटा बदलने के बाद वह कैश्ड मान संभवतः अवैध हो जाता है। ऐसी सेल का मान पढ़ना जिसका फॉर्मूला नहीं संभाला जा सकता, `[CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)` उत्पन्न कर सकता है।

**क्या फॉर्मूला त्रुटि मान C++ अपवादों के समान हैं?**

नहीं। `#DIV/0!` जैसी त्रुटि एक वैध गणना द्वारा उत्पन्न स्प्रेडशीट मान है। `[CellInvalidFormulaException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/)` या `[CellCircularReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/)` जैसे अपवाद इंगित करते हैं कि फॉर्मूला को सामान्य रूप से प्रोसेस नहीं किया जा सकता।

**क्या फॉर्मूला सेल बदलने पर चार्ट स्वचालित रूप से अपडेट होता है?**

एक चार्ट सीरीज़ वर्कबुक सेल को संदर्भित कर सकती है। पहले वर्कबुक को पुनर्गणना करें, फिर प्रस्तुति सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना किए गए सेल को संदर्भित करते हैं, तो चार्ट उन अपडेटेड मानों का उपयोग करेगा; इस वर्कफ़्लो के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक के साथ कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फॉर्मूला गणना वर्कफ़्लो केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फॉर्मूला उपसमुच्चय को लेता है। यह न मानें कि `[IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/)` बाहरी XLSX फ़ाइल में मनमाने फॉर्मूलों की पूर्ण पुनर्गणना प्रदान करता है।

**क्या मैं ऐसे फॉर्मूले उपयोग कर सकता हूँ जो किसी अन्य वर्कशीट या वर्कबुक को संदर्भित करते हों?**

Excel‑स्टाइल रेफ़रेंसेज़ चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक है, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ उस फॉर्मूले को सत्यापित करें। विस्तृत Excel रेफ़रेंस संगतता की आवश्यकता वाले वर्कफ़्लो के लिए, वर्कबुक को बाहरी रूप से गणना करें और समाधानित मानों को चार्ट डेटा में लिखें।

**क्या फॉर्मूला स्ट्रिंग की शुरुआत `=` से होनी चाहिए?**

Aspose.Slides API उदाहरण अभिव्यक्तियों जैसे `B2-C2` या `SUM(B2:B5)` को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से उत्पन्न फॉर्मूले दस्तावेज़ित API उदाहरणों के साथ संगत रहते हैं।