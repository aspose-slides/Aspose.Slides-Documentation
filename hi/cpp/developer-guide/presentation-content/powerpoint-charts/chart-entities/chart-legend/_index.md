---
title: C++ का उपयोग कर प्रस्तुतियों में चार्ट लिजेंड को अनुकूलित करें
linktitle: चार्ट लिजेंड
type: docs
url: /hi/cpp/chart-legend/
keywords:
- चार्ट लिजेंड
- लिजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ चार्ट लिजेंड को अनुकूलित करके PowerPoint प्रस्तुतियों को विशेष लिजेंड स्वरूपण के साथ अनुकूलित करें।"
---
## **अवलोकन**

Aspose.Slides for C++ PowerPoint प्रस्तुतियों में चार्ट लिजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख दिखाता है कि लिजेंड को कैसे स्थित और आकार दिया जाए, पूरे लिजेंड के लिए फ़ॉन्ट आकार कैसे सेट किया जाए, व्यक्तिगत लिजेंड एंट्री को कैसे स्वरूपित किया जाए, और चयनित एंट्रीज़ को कैसे छुपाया या पुनर्स्थापित किया जाए।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लिजेंड के लिए स्थान आरक्षित करना, मल्टीलाइन लेबल दिखाना, और प्रस्तुति थीम से स्वरूपण को विरासत में लेना शामिल है।

## **लिजेंड स्थिति निर्धारण**

लेजेंड के [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/), और [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) मेथड्स का उपयोग करके उसके स्थान और आकार को चार्ट के आयामों के भाग के रूप में निर्दिष्ट करें।

यह उदाहरण एक प्रस्तुति बनाता है और पहली स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। इच्छित लिजेंड ऑफसेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से भाग देकर उन्हें सापेक्ष मानों में बदलता है: लिजेंड चार्ट के बाएँ‑ऊपरी कोने से 50 पॉइंट के ऑफ़सेट पर है और इसका आकार 100 बाय 100 पॉइंट है।

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// लेजेण्ड की स्थिति और आकार को चार्ट के सापेक्ष व्यक्त करें।

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **लिजेंड का फ़ॉन्ट आकार निर्धारित करना**

लेजेंड के [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) का उपयोग करके उसके टेक्स्ट फ़ॉर्मैट तक पहुँचें और [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) का उपयोग करके फ़ॉन्ट आकार पॉइंट्स में सेट करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लिजेंड टेक्स्ट को 20 पॉइंट सेट करता है। यह ऊर्ध्वाधर अक्ष के लिए स्वचालित सीमा को भी निष्क्रिय करता है और उसकी रेंज को -5 से 10 तक सेट करता है।

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **व्यक्तिगत लिजेंड एंट्री का फ़ॉन्ट आकार निर्धारित करना**

लेजेंड के [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) मेथड द्वारा लौटाए गए संग्रह का उपयोग करके किसी विशिष्ट एंट्री के फ़ॉर्मैटिंग तक पहुँचें। एंट्री सूचकांक शून्य-आधारित होते हैं, इसलिए सूचकांक `1` दूसरी एंट्री को दर्शाता है।

यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा में कम से कम दो सीरीज़ शामिल हैं। यह दूसरी लिजेंड एंट्री को बोल्ड, इटैलिक और 20‑पॉइंट नीले टेक्स्ट के साथ स्वरूपित करता है।

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **व्यक्तिगत लिजेंड एंट्री को छुपाना**

किसी सहायक सीरीज़ को लिजेंड से बाहर रखने के लिए जबकि उसका डेटा दिखता रहे, [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) को `true` के साथ [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/) के माध्यम से कॉल करें। यह केवल चयनित लिजेंड एंट्री को छुपाता है; यह सीरीज़ या उसके डेटा पॉइंट्स को नहीं हटाता। इसके विपरीत, [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) को `false` के साथ कॉल करने से पूरी लिजेंड छुप जाती है।

नीचे दिया गया उदाहरण डिफ़ॉल्ट डेटा के साथ कई सीरीज़ वाला एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी सीरीज़ की लिजेंड एंट्री (सूचकांक `1`) को छुपाता है और प्रस्तुति सहेजता है। फिर `set_Hide` को `false` के साथ कॉल करके एंट्री को पुनर्स्थापित करता है और दूसरी प्रतिलिपि सहेजता है। दोनों फाइलों में कॉलम दृश्यमान रहते हैं।

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// समान एंट्री को चार्ट डेटा को बदले बिना पुनर्स्थापित करें।
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

नीचे का तुलना वही चार्ट दिखाती है जिसमें सभी एंट्रीज़ दृश्यमान हैं और जिसमें दूसरी एंट्री छुपी हुई है। दूसरी सीरीज़ के कॉलम अप्रभावित रहते हैं।

![सभी लिजेंड एंट्रीज़ दृश्यमान और श्रृंखला 2 लिजेंड से छुपी हुई चार्ट की तुलना; सभी कॉलम दृश्यमान रहते हैं।](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में लिजेंड एंट्रीज़ सीरीज़ की पहचान करती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा पॉइंट्स (स्लाइस) की पहचान करती हैं, इसलिए चयनित स्लाइस पर [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) का उपयोग करें। API इस डेटा‑पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ित करता है। यह मानें नहीं कि यह डोनट चार्ट्स पर लागू होता है, जो इस सूची में शामिल नहीं हैं।

## **FAQ**

**क्या मैं चार्ट को लिजेंड के लिए स्थान आवंटित कर सकता हूँ बजाय उसके ऊपर ओवरले किए?**  
हाँ। [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) को `false` के साथ कॉल करके लिजेंड के लिए स्थान आरक्षित करें, बजाय इसे प्लॉट एरिया पर ओवरले करने के।

**क्या मैं मल्टीलाइन लिजेंड लेबल बना सकता हूँ?**  
हाँ। जब उपलब्ध चौड़ाई अपर्याप्त हो तो लंबे लेबल रैप हो सकते हैं। आप श्रृंखला नामों में नई पंक्ति वर्ण (\n) का उपयोग करके लाइन ब्रेक भी अनुरोध कर सकते हैं।

**मैं लिजेंड को प्रस्तुति थीम के रंग योजना के साथ कैसे मिलान करूँ?**  
लिजेंड के रंग, फ़िल और फ़ॉन्ट को अनसेट रखें ताकि वह थीम फ़ॉर्मैटिंग को विरासत में ले सके। स्पष्ट फ़ॉर्मैटिंग संबंधित थीम सेटिंग्स को ओवरराइड करती है।