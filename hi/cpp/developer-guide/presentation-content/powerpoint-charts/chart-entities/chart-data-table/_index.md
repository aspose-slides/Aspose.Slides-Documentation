---
title: "C++ का उपयोग करके प्रस्तुतियों में चार्ट डेटा तालिकाओं को अनुकूलित करें"
linktitle: "डेटा तालिका"
type: docs
url: /hi/cpp/chart-data-table/
keywords:
- चार्ट डेटा
- डेटा तालिका
- फ़ॉन्ट गुण
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट डेटा तालिका के फ़ॉन्ट, सीमाएँ और लिजेंड कुंजियों को अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides for C++ आपको चार्ट की डेटा तालिका प्रदर्शित करने और उसके टेक्स्ट फ़ॉर्मेटिंग, सीमाओं और लिजेंड कुंजियों को कस्टमाइज़ करने की सुविधा देता है। यह लेख बताता है कि तालिका को कैसे सक्षम करें, उसके टेक्स्ट को कैसे फ़ॉर्मेट करें, प्रत्येक प्रकार की सीमा को कैसे नियंत्रित करें, और लिजेंड कुंजियों को दिखाएँ या छुपाएँ। उदाहरण निर्धारित चार्ट को PPTX फ़ाइलों में सहेजते हैं।

## **फ़ॉन्ट गुण सेट करें**

एक चार्ट की डेटा तालिका दिखाने के लिए `true` को [IChart::set_HasDataTable](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/set_hasdatatable/) पर पास करें। तालिका तक पहुँचने और उसके टेक्स्ट फ़ॉर्मेटिंग को कॉन्फ़िगर करने के लिए [IChart::get_ChartDataTable](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_chartdatatable/) का उपयोग करें।

1. Presentation क्लास का उपयोग करके प्रस्तुति लोड करें।
1. पहली स्लाइड में एक क्लस्टर्ड कॉलम चार्ट जोड़ें।
1. चार्ट की डेटा तालिका को सक्षम करें।
1. [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_fontbold/) के साथ बोल्ड टेक्स्ट सक्षम करें और 20‑पॉइंट टेक्स्ट के लिए `20` को [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseportionformat/set_fontheight/) पर पास करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण को कार्य निर्देशिका में कम से कम एक स्लाइड वाली `test.pptx` फ़ाइल चाहिए। यह (50, 50) स्थिति पर डिफ़ॉल्ट डेटा के साथ एक चार्ट जोड़ता है, जिसकी चौड़ाई 600 पॉइंट और ऊँचाई 400 पॉइंट है। सहेजी गई `output.pptx` में चार्ट की डेटा तालिका सक्षम है और निर्दिष्ट फ़ॉन्ट सेटिंग्स लागू हैं।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **डेटा तालिका सीमाओं को अनुकूलित करें**

टेबल को [IChart::set_HasDataTable](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/set_hasdatatable/) से सक्षम करें और इसे [IChart::get_ChartDataTable](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/get_chartdatatable/) के माध्यम से एक्सेस करें। आप तीन प्रकार की सीमाओं को स्वतंत्र रूप से नियंत्रित कर सकते हैं:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) क्षैतिज सेल सीमाओं को नियंत्रित करता है।
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) लंबवत सेल सीमाओं को नियंत्रित करता है।
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) टेबल की बाहरी सीमा को नियंत्रित करता है।

`true` को प्रत्येक setter को पास करके उसकी सीमा दिखाएँ या `false` पास करके उसे छुपाएँ। निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है, क्षैतिज सीमाओं और बाहरी सीमा को दिखाता है, और लंबवत सीमाओं को छुपाता है। इसके लिए कोई इनपुट फ़ाइल आवश्यक नहीं है। चार्ट की स्थिति और आकार पॉइंट में निर्दिष्ट हैं।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

नीचे दिया गया तुलना सभी चार मामलों में समान चार्ट डेटा और लिजेंड कुंजी सेटिंग का उपयोग करता है। सभी सीमाओं को सक्षम करके शुरू करने पर, प्रत्येक शेष वैरिएंट केवल एक सीमा सेटिंग को निष्क्रिय करता है। निचले‑बाएँ वैरिएंट उदाहरण में उपयोग की गई सीमा सेटिंग्स से मेल खाता है।

![सभी सीमाओं को सक्षम किए हुए चार्ट डेटा तालिकाएँ, बिना क्षैतिज सीमाओं के, बिना लंबवत सीमाओं के, और बिना बाहरी सीमा के](data-table-borders.png)

## **लिजेंड कुंजियों को दिखाएँ या छुपाएँ**

लिजेंड कुंजियाँ डेटा तालिका में श्रृंखला के नामों के बगल में छोटे रंगीन मार्कर होते हैं। वे पाठकों को प्रत्येक तालिका पंक्ति को चार्ट श्रृंखला से मिलाने में मदद करती हैं। इन मार्करों को दिखाने के लिए [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) को `true` पास करें या उन्हें छुपाने के लिए `false` पास करें।

चार्ट की अलग लिजेंड को [IChart::set_HasLegend](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/ichart/set_haslegend/) द्वारा नियंत्रित किया जाता है। ये सेटिंग्स स्वतंत्र हैं: अलग लिजेंड को छिपाने से डेटा तालिका के भीतर की कुंजियाँ नहीं छिपतीं, और तालिका की कुंजियों को छिपाने से अलग लिजेंड नहीं छिपता।

निम्नलिखित उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है, उसकी डेटा तालिका को सक्षम करता है, और अलग लिजेंड को छुपाते हुए तालिका के भीतर लिजेंड कुंजियों को दिखाता है। सभी तालिका सीमाएँ स्पष्ट रूप से सक्षम हैं। कोई इनपुट प्रस्तुति आवश्यक नहीं है। केवल तालिका की कुंजियों को छुपाने के लिए, [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) को `false` पास करें।

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

नीचे दिया गया तुलना बाएँ पक्ष पर दिखाए गए और दाएँ पक्ष पर छुपाए गए लिजेंड कुंजियों वाली चार्ट डेटा तालिकाएँ दर्शाता है। सभी सीमाएँ सक्षम रहती हैं, और अलग चार्ट लिजेंड दोनों मामलों में छुपा रहता है।

![बाएँ पक्ष पर दिखाए गए और दाएँ पक्ष पर छुपाए गए लिजेंड कुंजियों वाली चार्ट डेटा तालिकाएँ](data-table-legend-keys.png)

## **FAQ**

**क्या मैं चार्ट की डेटा तालिका में लिजेंड कुंजियों को दिखा सकता हूँ?**

हाँ। लिजेंड कुंजी दिखाने के लिए [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/hi/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) को `true` पास करें या उन्हें छुपाने के लिए `false` पास करें।

**क्या प्रस्तुति को PDF, HTML, या इमेजेज़ में एक्सपोर्ट करने पर डेटा तालिका संरक्षित रहेगी?**

हाँ। Aspose.Slides जब प्रस्तुति को PDF, HTML, या इमेजेज़ में एक्सपोर्ट करता है तो चार्ट और प्रदर्शित डेटा तालिका को स्लाइड का हिस्सा बनाकर रेंडर करता है।

**क्या मैं टेम्प्लेट से लोड किए गए चार्ट की डेटा तालिकाओं के साथ काम कर सकता हूँ?**

हाँ। मौजूदा प्रस्तुति या टेम्प्लेट से लोड किए गए चार्ट के लिए, `IChart::get_HasDataTable` का उपयोग करके जांचें कि उसकी डेटा तालिका प्रदर्शित है या नहीं, और `IChart::set_HasDataTable` से उसकी दृश्यता बदलें।

**मैं कैसे पता कर सकूँ कि किन चार्ट्स में डेटा तालिका सक्षम है?**

प्रत्येक स्लाइड की शैप्स पर इटररेट करें, चार्ट्स की पहचान करें, और उनके `IChart::get_HasDataTable` परिणाम को जांचें। `true` मान दर्शाता है कि डेटा तालिका सक्षम है।