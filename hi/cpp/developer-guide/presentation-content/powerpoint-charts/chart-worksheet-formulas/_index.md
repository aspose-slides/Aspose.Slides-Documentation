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
- तार्किक स्थिरांक
- संख्यात्मक स्थिरांक
- स्ट्रिंग स्थिरांक
- त्रुटि स्थिरांक
- अंकगणितीय ऑपरेटर
- तुलना ऑपरेटर
- A1 शैली
- R1C1 शैली
- पूर्वनिर्धारित फ़ंक्शन
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ चार्ट वर्कशीट्स में Excel-शैली के फॉर्मूले लागू करें, मानों की पुनः गणना करें, और परिणामों को PowerPoint चार्ट्स में उपयोग करें।"
---
## **अवलोकन**

PowerPoint चार्ट आमतौर पर अपने स्रोत डेटा को एक एम्बेडेड वर्कशीट में संग्रहीत करते हैं। Aspose.Slides for C++ में, आप चार्ट डेटा वर्कबुक के माध्यम से उस वर्कशीट तक पहुँच सकते हैं, इनपुट मान लिख सकते हैं, कोशिकाओं को फॉर्मूले असाइन कर सकते हैं, समर्थित फॉर्मूले की गणना कर सकते हैं, और गणना की गई कोशिकाओं को चार्ट डेटा के रूप में उपयोग कर सकते हैं।

यह लेख पूर्ण फॉर्मूला वर्कफ़्लो समझाता है: एक चार्ट बनाना, उसकी वर्कशीट भरना, A1‑स्टाइल या R1C1‑स्टाइल फॉर्मूले असाइन करना, उन्हें पुनः गणना करना, गणना किए गए मान पढ़ना, उन कोशिकाओं को चार्ट सीरीज़ से जोड़ना, और प्रस्तुति को सहेजना। इसमें समर्थित फॉर्मूला सिंटैक्स, बिल्ट‑इन फ़ंक्शन उपसमुच्चय, कैश किए हुए मान, असमर्थित फॉर्मूले, और स्प्रेडशीट‑विशिष्ट त्रुटियों का विवरण भी दिया गया है।

## **चार्ट वर्कशीट्स और फॉर्मूले**

एक चार्ट वर्कशीट में उन श्रेणियों, सीरीज़ नामों और मानों को संग्रहित किया जाता है जो चार्ट द्वारा उपयोग किए जाते हैं। PowerPoint में, आप चार्ट डेटा एडिटर खोलकर वर्कशीट की जाँच कर सकते हैं:

![PowerPoint चार्ट जिसमें उसका एम्बेडेड वर्कशीट खुला हुआ है, श्रेणी और सीरीज़ डेटा दिखा रहा है](chart-worksheet-formulas_1.png)

Aspose.Slides में, वर्कशीट को [IChartDataWorkbook](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/) इंटरफ़ेस के माध्यम से उजागर किया गया है। A1‑स्टाइल फॉर्मूले के लिए [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) और R1C1‑स्टाइल फॉर्मूले के लिए [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) का उपयोग करें। इनपुट कोशिकाओं या फॉर्मूलों को बदलने के बाद, समर्थित फॉर्मूले को पुनः गणना करने और संबंधित कोशिका मानों को अपडेट करने के लिए [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

एक गणना की गई कोशिका अपना परिणाम अभी भी [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) के माध्यम से प्रकट करती है। यह तब महत्वपूर्ण होता है जब आपको कोड में फॉर्मूला परिणाम की जाँच करनी हो या कोशिका को चार्ट डेटा पॉइंट के रूप में उपयोग करना हो।

## **एक चार्ट बनाएं और वर्कशीट फॉर्मूले गणना करें**

निम्न उदाहरण एक एंड‑टू‑एंड वर्कफ़्लो दर्शाता है। यह एक क्लस्टर्ड कॉलम चार्ट बनाता है, सैंपल डेटा साफ़ करता है, त्रैमासिक राजस्व और खर्च मान लिखता है, फॉर्मूले के साथ लाभ की गणना करता है, परिणाम पढ़ता है, गणना की गई कोशिकाओं को चार्ट मानों के रूप में उपयोग करता है, और प्रस्तुति को सहेजता है।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
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

चार्ट डेटा पॉइंट `D2:D4` को संदर्भित करते हैं, इसलिए चार्ट गणना किए गए लाभ मानों का उपयोग करता है। इस वर्कफ़्लो में कोई अलग चार्ट‑रिफ्रेश कॉल नहीं है: पहले वर्कबुक को पुनः गणना करें, फिर गणना किए गए कोशिकाओं की ओर इशारा करने वाले चार्ट डेटा का उपयोग या सहेजें।

## **A1‑स्टाइल फॉर्मूले का उपयोग करें**

A1 नोटेशन कॉलम को अक्षरों से और पंक्तियों को संख्याओं से पहचानता है। A1‑स्टाइल अभिव्यक्तियों को [IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) द्वारा असाइन करें।

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

सामान्य A1 रेफ़रेंस रूप इस प्रकार हैं:

| रेफ़रेंस | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `A2` | `$A$2` | `A$2`, `$A2` |
| पंक्ति | `2:2` | `$2:$2` | — |
| स्तम्भ | `A:A` | `$A:$A` | — |
| रेंज | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

रिलेटिव रेफ़रेंस स्प्रेडशीट एप्लिकेशन द्वारा फॉर्मूला को स्थानांतरित या कॉपी करने पर बदल सकते हैं। एब्सोल्यूट रेफ़रेंस दोनों निर्देशांक को स्थिर रखते हैं, जबकि मिश्रित रेफ़रेंस केवल पंक्ति या कॉलम को स्थिर करता है।

## **R1C1‑स्टाइल फॉर्मूले का उपयोग करें**

R1C1 नोटेशन पंक्तियों और कॉलमों दोनों को संख्यात्मक रूप से पहचानता है। रिलेटिव रेफ़रेंस वर्ग कोष्ठकों में ऑफ़सेट का उपयोग करते हैं। यह सिंटैक्स [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) द्वारा असाइन करें।

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

सामान्य R1C1 रेफ़रेंस रूप इस प्रकार हैं:

| रेफ़रेंस | रिलेटिव | एब्सोल्यूट | मिश्रित |
|---|---|---|---|
| सेल | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| पंक्ति | `R[2]` | `R2` | — |
| स्तम्भ | `C[3]` | `C3` | — |
| रेंज | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

उदाहरण के लिए, सेल `D2` में, `RC[-2]` का अर्थ है उसी पंक्ति में दो कॉलम बाएँ स्थित सेल (`B2`)।

## **फॉर्मूला स्थिरांक और ऑपरेटर**

बिल्ट‑इन फॉर्मूला मूल्यांकनकर्ता तार्किक मान, संख्यात्मक लिटरल, स्ट्रिंग, स्प्रेडशीट त्रुटि मान, अंकगणितीय ऑपरेटर और तुलना ऑपरेटर को समर्थन देता है।

### **स्थिरांक और लिटरेल्स**

| प्रकार | उदाहरण | नोट |
|---|---|---|
| लॉजिकल | `TRUE`, `FALSE` | सीधे लॉजिकल अभिव्यक्तियों जैसे `A2=TRUE` में उपयोग किया जा सकता है। |
| संख्यात्मक | `1`, `0.5`, `.3`, `1E-2` | सामान्य और वैज्ञानिक नोटेशन दोनों समर्थित हैं। |
| स्ट्रिंग | `"abc"`, `"2/3/2020 12:00"` | स्ट्रिंग लिटरल्स को फॉर्मूले के भीतर दोहरे उद्धरण में रखा जाता है। |
| त्रुटि परिणाम | `#DIV/0!`, `#N/A`, `#REF!` | वैध फॉर्मूला सामान्य परिणाम के बजाय स्प्रेडशीट त्रुटि मान भी दे सकता है। |

यह उदाहरण कई स्थिरांक प्रकारों का उपयोग करता है:

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

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // फ़ॉल्स
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
```

### **अंकगणितीय ऑपरेटर**

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `+` | जोड़ या यूनरी प्लस | `2+3` |
| `-` | घटाव या नेगेशन | `2-3`, `-3` |
| `*` | गुणा | `2*3` |
| `/` | भाग | `2/3` |
| `%` | प्रतिशत | `30%` |
| `^` | घातांक | `2^3` |

मूल्यांकन क्रम स्पष्ट करने के लिए कोष्ठकों का प्रयोग करें, जैसे `(A2+B2)*C2`।

### **तुलना ऑपरेटर**

तुलना अभिव्यक्तियां लॉजिकल मान लौटाती हैं।

| ऑपरेटर | अर्थ | उदाहरण |
|---|---|---|
| `=` | बराबर | `A2=3` |
| `<>` | बराबर नहीं | `A2<>3` |
| `>` | बड़ा | `A2>3` |
| `>=` | बड़ा या बराबर | `A2>=3` |
| `<` | छोटा | `A2<3` |
| `<=` | छोटा या बराबर | `A2<=3` |

## **समर्थित पूर्वनिर्धारित फ़ंक्शन**

Aspose.Slides में चार्ट वर्कशीट्स के लिए एक बिल्ट‑इन फॉर्मूला मूल्यांकनकर्ता शामिल है, लेकिन यह पूर्ण Excel गणना इंजन नहीं है। दस्तावेज़ीकृत फ़ंक्शन सेट नीचे दिए गए फ़ंक्शनों तक सीमित है। यह मानें नहीं कि कोई भी Excel फ़ंक्शन [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) द्वारा पुनः गणना किया जा सकेगा।

| फ़ंक्शन | उद्देश्य या समर्थित रूप | उदाहरण |
|---|---|---|
| `ABS` | निरपेक्ष मान | `ABS(A2)` |
| `AVERAGE` | अंकगणितीय माध्य | `AVERAGE(B2:B5)` |
| `CEILING` | संख्या को ऊपर की ओर निकटतम गुणज तक गोल करना | `CEILING(A2,5)` |
| `CHOOSE` | सूचकांक के आधार पर मान चुनना | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | टेक्स्ट मानों को जोड़ना | `CONCAT(A2,B2)` |
| `CONCATENATE` | टेक्स्ट मानों को जोड़ना | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 तिथि प्रणाली का उपयोग करके तिथि बनाना | `DATE(2026,8,19)` |
| `DAYS` | दो तिथियों के बीच दिनों की संख्या लौटाना | `DAYS(B2,A2)` |
| `FIND` | एक टेक्स्ट मान को दूसरे में ढूँढना | `FIND("-",A2)` |
| `FINDB` | बाइट‑ओरिएंटेड टेक्स्ट खोज | `FINDB("a",A2)` |
| `IF` | शर्तीय परिणाम | `IF(A2>0,A2,0)` |
| `INDEX` | रेफ़रेंस रूप | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | वेक्टर रूप | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | वेक्टर रूप | `MATCH(A2,B2:B5,0)` |
| `MAX` | अधिकतम मान | `MAX(B2:B5)` |
| `SUM` | मानों का योग | `SUM(B2:B5)` |
| `VLOOKUP` | वर्गीय लुकअप | `VLOOKUP(A2,B2:D10,3,FALSE)` |

तालिका में दिखाए गए प्रतिबंध महत्वपूर्ण हैं: `INDEX` को रेफ़रेंस रूप में दस्तावेज़ित किया गया है, जबकि `LOOKUP` और `MATCH` को उनके वेक्टर रूप में। `DATE` 1900 तिथि प्रणाली का उपयोग करता है। यहाँ सूचीबद्ध न होने वाले फ़ंक्शन Aspose.Slides के फॉर्मूला मूल्यांकनकर्ता द्वारा असमर्थित माने जाएंगे, जब तक कि वे अलग से दस्तावेज़ित न हों।

## **पुनः गणना और कैश किए हुए मान**

स्प्रेडशीट फ़ाइलें सामान्यतः फॉर्मूला और उसके अंतिम गणना किए हुए मान दोनों को संग्रहीत करती हैं। Aspose.Slides इसलिए प्रस्तुति लोड होने पर और संबंधित चार्ट डेटा में परिवर्तन न किए गए हों तो [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) से कैश किया हुआ मान पढ़ सकता है।

इनपुट कोशिकाओं या फॉर्मूलों को बदलने के बाद, पुराने कैश किए हुए परिणाम पर भरोसा न करें। गणना किए हुए मान पढ़ने या उन पर निर्भर चार्ट डेटा को सहेजने से पहले [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें।

समर्थित उपसमुच्चय के बाहर के फॉर्मूले के लिए, Aspose.Slides फॉर्मूला को पार्स नहीं कर पाता या उसकी निर्भरताओं को स्थापित नहीं कर पाता। यदि वर्कबुक संशोधित की गई है, तो पहले का कैश किया हुआ मान अब विश्वसनीय नहीं रहता। ऐसे स्थिति में, असमर्थित डेटा वाली कोशिका का मान पढ़ने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) उठ सकता है।

यदि आपका चार्ट ऐसे Excel फ़ंक्शन पर निर्भर है जिन्हें Aspose.Slides मूल्यांकन नहीं करता, तो उन फ़ंक्शनों को किसी ऐसे स्प्रेडशीट इंजन से गणना करें जो उनका समर्थन करता हो और परिणाम वापस चार्ट वर्कबुक में लिखें। असमर्थित फॉर्मूलों को अनुमानित मानों से प्रतिस्थापित न करें।

## **फॉर्मूला त्रुटियों को संभालें**

दो प्रकार की समस्याएँ अलग‑अलग पहचानने योग्य हैं।

एक फॉर्मूला वैध हो सकता है लेकिन स्प्रेडशीट त्रुटि परिणाम दे सकता है, जैसे `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!`, या `#VALUE!`। इस स्थिति में, त्रुटि टोकन एक कोशिका परिणाम है और इसे [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) के माध्यम से लौटाया जा सकता है।

एक फॉर्मूला पार्सिंग, रेफ़रेंस, निर्भरता, या समर्थित‑डेटा स्तर पर भी विफल हो सकता है। Aspose.Slides इन मामलों के लिए स्प्रेडशीट‑विशिष्ट अपवाद प्रदान करता है: [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), और [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/)।

जब फॉर्मूले टेम्प्लेट या उपयोगकर्ता इनपुट से आते हैं, तो पुनः गणना और मान पहुँच के आसपास इन अपवादों को संभालें:

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
    // अमान्य फ़ॉर्मूले को संभालें।
}
catch (CellInvalidReferenceException&)
{
    // अमान्य सेल रेफ़रेंस को संभालें।
}
catch (CellCircularReferenceException&)
{
    // परिचक्र रेफ़रेंस को संभालें।
}
catch (CellUnsupportedDataException&)
{
    // असमर्थित स्प्रेडशीट डेटा को संभालें।
}
```

## **व्यावहारिक सीमाएँ**

चार्ट वर्कशीट्स में फॉर्मूला समर्थन एक सीमित उपसमुच्चय के लिए डिज़ाइन किया गया है, न कि पूर्ण Excel संगतता के लिए। रिपोर्टिंग वर्कफ़्लो डिज़ाइन करते समय इन प्रतिबंधों को ध्यान में रखें:

- Aspose.Slides को फॉर्मूला पुनः गणना करने के लिए केवल दस्तावेज़ित स्थिरांक, ऑपरेटर, रेफ़रेंस और फ़ंक्शन उपयोग करें।
- उन कोशिकाओं को बदलने के बाद पुनः गणना करें जिन पर फॉर्मूला परिणाम निर्भर करते हैं।
- लोड की गई प्रस्तुति से प्राप्त कैश किए हुए मान स्नैपशॉट हैं, संपादन के बाद पुनः गणना के विकल्प नहीं।
- मौजूदा टेम्प्लेट से फॉर्मूले का परीक्षण करें, विशेषकर जब वे दस्तावेज़ित सूची से बाहर के फ़ंक्शन उपयोग करते हों।
- पूर्ण स्प्रेडशीट गणना इंजन की आवश्यकता वाले फॉर्मूले को बाहरी रूप से गणना करें और फिर चार्ट वर्कबुक को अपडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**`set_Formula` और `set_R1C1Formula` में क्या अंतर है?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_formula/) A1‑स्टाइल अभिव्यक्ति जैसे `B2-C2` को संग्रहित करता है। [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) R1C1‑स्टाइल अभिव्यक्ति जैसे `RC[-2]-RC[-1]` को संग्रहित करता है। उस नोटेशन का उपयोग करें जो आपके फॉर्मूला उत्पन्न करने या कॉपी करने के तरीके से बेहतर मेल खाता हो।

**गणना के बाद मुझे स्वयं कोशिका पढ़नी चाहिए या उसका मान?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) एक `IChartDataCell` लौटाता है। गणना के बाद, उस कोशिका के [IChartDataCell::get_Value](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdatacell/get_value/) मान को पढ़ें।

**`CalculateFormulas` कब कॉल करना चाहिए?**

इनपुट मान या फॉर्मूले बदलने के बाद और गणना किए गए परिणामों पर निर्भर होने से पहले [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) को कॉल करें। यह बिल्ट‑इन मूल्यांकनकर्ता द्वारा समर्थित फॉर्मूले के मान अपडेट करता है।

**क्या Aspose.Slides हर Excel फ़ंक्शन का समर्थन करता है?**

नहीं। बिल्ट‑इन मूल्यांकनकर्ता फ़ंक्शनों का एक दस्तावेज़ित उपसमुच्चय समर्थन करता है। इस उपसमुच्चय से बाहर के फ़ंक्शन को सही ढंग से पुनः गणना करने का अनुमान न लगाएँ। यदि पूर्ण Excel फ़ॉर्मूला संगतता चाहिए, तो उचित स्प्रेडशीट इंजन से गणना करें और अंतिम मान चार्ट वर्कबुक में लिखें।

**यदि लोड की गई प्रस्तुति में एक असमर्थित फॉर्मूला हो तो क्या होगा?**

यदि चार्ट डेटा नहीं बदला है, तो वर्कबुक में पहले से गणना किया गया कैश्ड मान रह सकता है। संबंधित डेटा बदलने के बाद वह कैश्ड मान मान्य नहीं रह सकता। असमर्थित फॉर्मूला वाली कोशिका तक पहुँचने से [CellUnsupportedDataException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) उत्पन्न हो सकता है।

**क्या फॉर्मूला त्रुटि मान C++ अपवादों के समान हैं?**

नहीं। `#DIV/0!` जैसे परिणाम वैध गणना द्वारा निर्मित स्प्रेडशीट मान होते हैं। [CellInvalidFormulaException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) या [CellCircularReferenceException](https://reference.aspose.com/slides/hi/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) जैसे अपवाद दर्शाते हैं कि फॉर्मूला सामान्य रूप से प्रोसेस नहीं हो सका।

**क्या फॉर्मूला कोशिका बदलने पर चार्ट स्वतः अपडेट होता है?**

एक चार्ट सीरीज़ वर्कबुक कोशिकाओं को संदर्भित कर सकती है। पहले वर्कबुक को पुनः गणना करें, फिर प्रस्तुति को सहेजें या रेंडर करें। यदि चार्ट डेटा पॉइंट गणना की गई कोशिकाओं की ओर इशारा करता है, तो चार्ट उन अपडेटेड मानों का उपयोग करेगा; इस वर्कफ़्लो के लिए कोई अलग चार्ट‑रिफ्रेश मेथड आवश्यक नहीं है।

**क्या चार्ट बाहरी Excel वर्कबुक का उपयोग कर सकते हैं?**

हां, चार्ट डेटा को चार्ट डेटा API के माध्यम से बाहरी वर्कबुक के उपयोग के लिए कॉन्फ़िगर किया जा सकता है। हालांकि, इस लेख में वर्णित फॉर्मूला गणना वर्कफ़्लो केवल चार्ट डेटा वर्कबुक और Aspose.Slides द्वारा मूल्यांकित फॉर्मूला उपसमुच्चय से संबंधित है। यह मानें कि [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) बाहरी XLSX फ़ाइल में मनमाने फॉर्मूलों की पूरी पुनः गणना प्रदान करता है।

**क्या मैं ऐसे फॉर्मूले उपयोग कर सकता हूँ जो दूसरे वर्कशीट या वर्कबुक को संदर्भित करें?**

Excel‑स्टाइल रेफ़रेंस चार्ट वर्कबुक में मौजूद हो सकते हैं, लेकिन फॉर्मूला मूल्यांकन समर्थित पार्सर और फ़ंक्शन सेट द्वारा सीमित है। यदि क्रॉस‑शीट या बाहरी रेफ़रेंस आवश्यक हो, तो अपने लक्ष्य Aspose.Slides संस्करण के साथ सटीक फॉर्मूले की पुष्टि करें। व्यापक Excel रेफ़रेंस संगतता की आवश्यकता वाले वर्कफ़्लो के लिए, वर्कबुक को बाहरी रूप से गणना करें और हल किए गए मानों को चार्ट डेटा में लिखें।

**क्या फॉर्मूला स्ट्रिंग्स को `=` से शुरू करना चाहिए?**

Aspose.Slides API उदाहरण `B2-C2` या `SUM(B2:B5)` जैसी अभिव्यक्तियों को बिना अग्रणी `=` के असाइन करते हैं। इस रूप का उपयोग करने से जनरेट किए गए फॉर्मूले API उदाहरणों के साथ सुसंगत रहते हैं।