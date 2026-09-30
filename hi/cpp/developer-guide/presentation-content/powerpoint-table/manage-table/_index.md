---
title: C++ में प्रस्तुति तालिकाएँ प्रबंधित करें
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/cpp/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- पाठ को संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मानों को पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides निम्नलिखित प्रदान करता है: [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार, जिससे आप प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाएं**

एक तालिका बनाते समय उसकी स्थिति, स्तंभ चौड़ाई और पंक्ति ऊँचाई निर्दिष्ट करें। स्लाइड में जोड़ने के बाद, आप सेल बॉर्डर को स्वरूपित कर सकते हैं, सेल्स को मिलाएँ, और टेक्स्ट डाल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. पॉइंट में स्तंभ चौड़ाई की एक एरे परिभाषित करें।
4. पॉइंट में पंक्ति ऊँचाई की एक एरे परिभाषित करें।
5. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से स्लाइड में एक [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) के माध्यम से इटररेट करके शीर्ष, नीचे, दाएँ और बाएँ बॉर्डर्स पर स्वरूपण लागू करें।
7. तालिका की पहली पंक्ति के पहले दो सेल्स को मिलाएँ।
8. मर्ज किए गए सेल को उसके [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) मेथड के माध्यम से एक्सेस करें।
9. मर्ज किए गए सेल में टेक्स्ट सेट करें।
10. परिवर्तित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण 3 स्तंभ और 5 पंक्तियों वाली तालिका (100, 50) पॉइंट पर बनाता है। यह 5 पॉइंट चौड़ाई के लाल बॉर्डर लागू करता है, पहली पंक्ति के पहले दो सेल को मिलाता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल अनुक्रमण शून्य-आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करते हैं। पहला सेल (0, 0) के रूप में अनुक्रमित होता है।

उदाहरण के लिये, 4 स्तंभ और 4 पंक्तियों वाली तालिका के सेल इस प्रकार क्रमांकित होते हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दर्शाए गए 4 × 4 तालिका को बनाता है, जिसमें स्तंभ चौड़ाई और पंक्ति ऊँचाई 70 पॉइंट है और लाल सेल बॉर्डर 5 पॉइंट चौड़ा है। निर्देशांक सेल अनुक्रमण दर्शाते हैं; यह उदाहरण सेल को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **मौजूदा तालिका तक पहुंचें**

तालिकाएँ स्लाइड के शेप कलेक्शन में संग्रहीत होती हैं। टेबल खोजने हेतु शेप्स के माध्यम से इटररेट करें, फिर उसकी सेल्स को पढ़ने या अपडेट करने के लिए [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) इंटरफ़ेस का उपयोग करें।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा वह स्लाइड प्राप्त करें जिसमें टेबल अस्तित्व में है।
3. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) ऑब्जेक्ट के माध्यम से इटररेट करें और टेबल मिलने पर रुकें। यदि स्लाइड में कई तालिकाएँ हैं, तो आवश्यक तालिका की पहचान के लिए [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) का उपयोग करें।
4. लक्षित सेल में टेक्स्ट अपडेट करें।
5. परिवर्तित प्रस्तुति को सहेजें।

नीچے दिया गया उदाहरण `UpdateExistingTable.pptx` को खोलता है और पहले स्लाइड पर पहली तालिका खोजता है। यह कॉलम 0, पंक्ति 1 के सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होना चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक कॉलम और दो पंक्तियाँ होनी चाहिए।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

किसी मौजूदा तालिका में पंक्ति का आकार बदलने और यह समझने के लिए कि उसका वास्तविक ऊँचाई अनुरोधित न्यूनतम से अधिक क्यों हो सकती है, देखें [पंक्ति ऊँचाई नियंत्रण](/slides/hi/cpp/manage-rows-and-columns/#control-row-height)।

## **टेक्स्ट फ्रेम का स्वामी सेल खोजें**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से एक [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) प्राप्त होता है, तो स्वामी [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) का उपयोग करें। तालिका-सेल टेक्स्ट फ्रेम के लिए, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) स्वामी लौटाता है और [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` लौटाता है, भले ही तालिका स्वयं एक शेप हो।

सेल निर्देशांक पढ़ने‑के‑लिए केवल [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) और [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) मेथड्स के माध्यम से उपलब्ध हैं। [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) भी पढ़ने‑के‑लिए नेविगेशन प्रदान करता है: यह स्वामी लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाए गये सेल को `nullptr` के लिए जांचें।

एक पूर्ण उदाहरण जिसके द्वारा टेबल‑सेल और शेप मालिकों की पहचान की जाती है, जिसमें SmartArt नोड्स से जुड़े शेप्स भी शामिल हैं, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/cpp/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

आप व्यक्तिगत तालिका कोशिकाओं के वर्टिकल एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस अनुभाग का उदाहरण पहले सेल में टेक्स्ट को केंद्रित करता है और उसे 270 डिग्री घुमाता है।

1. एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) ऑब्जेक्ट एक्सेस करें।
5. पहले [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) को एक्सेस करें और उसका टेक्स्ट व रंग सेट करें।
6. [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) और [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) का उपयोग करके सेल की वर्टिकल एंकरिंग और टेक्स्ट दिशा सेट करें।
7. परिवर्तित प्रस्तुति को सहेजें।

यह उदाहरण 120 पॉइंट स्तंभ चौड़ाई और 100 पॉइंट पंक्ति ऊँचाई वाली 4 × 4 तालिका बनाता है। यह सेल (0, 0) में टेक्स्ट को स्वरूपित करता है, पहली पंक्ति के शेष कोशिकाओं में मान जोड़ता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **तालिका स्तर पर टेक्स्ट स्वरूपण सेट करें**

[SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) का उपयोग करके तालिका के सभी सेल्स पर टेक्स्ट स्वरूपण लागू करें। इसके ओवरलोड हिस्से, पैराग्राफ, और टेक्स्ट फ्रेम स्वरूपण ले सकते हैं, जिससे आप व्यक्तिगत सेल्स के माध्यम से इटररेट किए बिना इन गुणों को सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) ऑब्जेक्ट एक्सेस करें।
4. टेक्स्ट के फ़ॉन्ट आकार को सेट करने के लिए [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) का उपयोग करें।
5. पैराग्राफ संरेखण और दायाँ मार्जिन सेट करने के लिये [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) का उपयोग करें।
6. [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) का उपयोग करके टेक्स्ट दिशा सेट करें।
7. परिवर्तित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `table.pptx` को खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह फ़ॉन्ट आकार 25 पॉइंट सेट करता है, पैराग्राफ को दाएँ संरेखित करता है और दायाँ मार्जिन 20 पॉइंट रखता है, तथा टेक्स्ट को वर्टिकल बनाता है। स्वरूपित प्रस्तुति `result.pptx` के रूप में सहेजी जाती है।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) का उपयोग करके तालिका की प्रीसेट शैली पढ़ें और उसे असाइन करने के लिये [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) का उपयोग करें। यह उदाहरण एक तालिका पर [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट नाम प्रिंट करता है, और उसी प्रीसेट को दूसरी तालिका को असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **तालिका का अनुपात लॉक करें**

तालिका का अस्पेक्ट रेशियो उसकी चौड़ाई और ऊँचाई का अनुपात है। [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) का उपयोग करके इस अनुपात को तालिका के लिए लॉक करें।

नीचे दिया गया उदाहरण `pres.pptx` को खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह वर्तमान लॉक स्थिति प्रिंट करता है, अस्पेक्ट रेशियो लॉक सक्षम करता है, अपडेटेड स्थिति (`True`) प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिये राइट‑टू‑लेफ़्ट (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) है। दोनों का उपयोग करके कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित की जाती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

टेबल को स्थानांतरित, आकार बदलने, चयन आदि को निष्क्रिय करने के लिये [shape locks](/slides/hi/cpp/applying-protection-to-presentation/) का उपयोग करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या एक सेल के अंदर छवि को बैकग्राउंड के रूप में डालना समर्थित है?**

हां। आप एक सेल के लिये [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) सेट कर सकते हैं; चयनित मोड (स्ट्रैच या टाइल) के अनुसार छवि सेल क्षेत्र को कवर कर देगी।