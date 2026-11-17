---
title: C++ का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं को प्रबंधित करें
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/cpp/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं का मर्ज
- बॉर्डर हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ के साथ PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज की गई कोशिकाओं की पहचान, बॉर्डर हटाना, कोशिकाओं का विभाजन, और Aspose.Slides for C++ के साथ पृष्ठभूमि रंग और छवियों का सेट करना।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुंचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि मर्ज किए गए तालिका कोशिकाओं की पहचान कैसे करें, कोशिका बॉर्डर्स को कैसे हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांकन के साथ कैसे कार्य करें, कोशिका की पृष्ठभूमि रंग को कैसे बदलें, और तालिका कोशिका के भीतर छवि कैसे जोड़ें। उदाहरण दर्शाते हैं कि प्रस्तुति कैसे बनाएं या खोलें, स्लाइड से तालिका कैसे प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण कैसे अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में कैसे सहेजें।

Aspose.Slides तालिका कोशिकाओं तक पहुंचने के लिए शून्य-आधारित सूचकांक का उपयोग करता है, क्रम `(column, row)` में।

## **एक मर्ज की गई तालिका कोशिका की पहचान करें**

उदाहरण एक मौजूदा प्रस्तुति को खोलता है और पहली स्लाइड पर पहली आकृति को तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकृति मौजूद हैं और आकृति एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों पर पुनरावृति करता है और मर्ज किए गए क्षेत्रों में कोशिकाओं की पहचान करने के लिए [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) का उपयोग करता है। प्रत्येक मिलान के लिए, यह कोशिका समन्वय को `row;column` क्रम में प्रिंट करता है, तथा [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), और क्षेत्र के प्रारंभिक समन्वय, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) और [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) को भी।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **तालिका कोशिका बॉर्डर हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएं और अपनी पहली स्लाइड में [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) का उपयोग करके एक तालिका जोड़ें। स्तंभ चौड़ाइयाँ, पंक्ति ऊँचाइयाँ, और तालिका की स्थिति पॉइंट्स में निर्दिष्ट की जाती हैं। उदाहरण सभी चार कोशिका बॉर्डर को [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाते हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **विकर्ण कोशिका बॉर्डर जोड़ें**

[ get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) का उपयोग करके शीर्ष-बाएँ कोने से नीचे-दाएँ कोने तक एक रेखा खींचें, और [get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) का उपयोग करके नीचे-बाएँ कोने से शीर्ष-दाएँ कोने तक एक रेखा खींचें। एक विकर्ण कोने हेडर को संकेत कर सकता है; दोनों विकर्ण मिलकर X बनाते हैं जिससे कोशिका अनुपयुक्त चिन्हित होती है।

प्रत्येक विकर्ण एक [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/) है। उसके भराई तक पहुँचने के लिए [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) का उपयोग करें, फिर [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) को [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) के साथ कॉल करें और [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) के माध्यम से एक रंग चुनें। रेखा की चौड़ाई को पॉइंट्स में [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) से सेट करें।

उदाहरण एक पंक्ति में तीन कोशिकाएँ बनाता है: एक लाल नीचे की ओर विकर्ण, एक नीला ऊपर की ओर विकर्ण, और दोनों विकर्ण। यह शीर्ष, नीचे, बाएँ और दाएँ कोशिका बॉर्डर को अपरिवर्तित रखता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

एक विकर्ण एक स्वरूपण गुण है, कोशिका विभाजन नहीं। प्रत्येक कोशिका में एकल टेक्स्ट फ्रेम रहता है जिसे [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) के माध्यम से पहुँच किया जाता है; विकर्ण के दोनों तरफ के क्षेत्र को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजी गई तालिका, Microsoft PowerPoint में प्रदर्शित:

![तीन तालिका कोशिकाएँ जो शीर्ष-बायें से नीचे-दायें एक लाल विकर्ण, नीचे-बायें से शीर्ष-दायें एक नीला विकर्ण, और दोनों विकर्ण X बनाते हुए दिखाती हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे की ओर विकर्ण (लाल, 3 pt), ऊपर की ओर विकर्ण (नीला, 5 pt), और दोनों विकर्ण।*

## **तालिका कोशिकाओं को मिलाएँ**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) का उपयोग करके तालिका कोशिकाओं की आयताकार सीमा को एक कोशिका में संयोजित करें। सीमा के शीर्ष-बाएँ और नीचे-दाएँ कोनों पर स्थित कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क निर्धारित करता है कि मर्ज निर्दिष्ट सीमा से बाहर की कोशिकाओं को शामिल कर सकता है या नहीं; `false` मर्ज को उसी सीमा के भीतर रखता है।

उदाहरण 70-पॉइंट स्तंभों और पंक्तियों वाली 4‑बाय‑4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मर्ज करता है। परिणामी कोशिका दो स्तंभों और दो पंक्तियों को कवर करती है, जबकि तालिका की मूल ग्रिड चार स्तंभ और चार पंक्तियों को बरकरार रखती है। इस उदाहरण में मर्ज की गई कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए उसके शीर्ष‑बाएँ स्थिति का उपयोग करें: `table->idx_get(1, 1)`। मर्ज रेंज के बाहर की स्थितियाँ ग्रिड का हिस्सा बने रहती हैं, इसलिए रेंज के बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका की ग्रिड बरकरार रहती है। किसी कोशिका को विभाजित करने से नया ग्रिड कॉलम जोड़ सकता है और उसके दाएँ स्थित कोशिकाओं के कॉलम सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑पॉइंट स्तंभों और पंक्तियों वाली 4‑बाय‑4 तालिका बनाता है और कोशिका `(1, 1)` पर [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) को कॉल करता है। कोशिका की 70‑पॉइंट चौड़ाई का आधा भाग दो समान‑चौड़ाई वाली कोशिकाएँ बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो हिस्सों तक `table->idx_get(1, 1)` और `table->idx_get(2, 1)` से पहुँच सकते हैं। तालिका ग्रिड अब पाँच कॉलम रखता है: मूल रूप से कॉलम 2 और 3 में थीं कोशिकाएँ क्रमशः कॉलम 3 और 4 में स्थानांतरित हो गई हैं। पंक्ति सूचकांक समान रहता है। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन कॉलम सूचकांकों का उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```

[![एक अनमर्ज किया गया 70‑पॉइंट कोशिका दो 35‑पॉइंट कोशिकाओं में विभाजित होती है, जिसके कारण पाँचवाँ ग्रिड कॉलम जुड़ता है और दाईं ओर के सूचकांक शिफ्ट होते हैं।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन (1, 1) कोशिका को प्रभावित करता है, शून्य‑आधारित (column, row) संकेतकों का उपयोग करते हुए। अन्य पंक्तियों में कोशिका दोनों नए कॉलम स्थितियों को कवर करती रहती है।*

### **पंक्ति या कॉलम स्पैन द्वारा मर्ज की गई कोशिकाओं को विभित करें**

डेटा भरने के लिए मर्ज टेम्प्लेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजन के लिए [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) या कॉलम सीमा के साथ विभाजन के लिए [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) का उपयोग करें।

`index` तर्क ऊपर के भाग की पंक्तियों या बाएँ भाग के कॉलमों की गिनती करता है; यह मर्ज रेंज के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)।
- कॉलम विभाजन: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)।

उदाहरण अपेक्षा करता है कि प्रस्तुति की पहली स्लाइड पर पहला आकार एक तालिका हो, जहाँ `(1, 2)` और `(1, 3)` ऊर्ध्वाधर रूप से मर्ज हैं। निचली स्थिति से शुरू करते हुए, यह मूल स्थान खोजने के लिए [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) और [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) का उपयोग करता है और दोनों स्पैन की जाँच करता है। `SplitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो‑कॉलम मर्ज के लिए, `SplitByColSpan(1)` का उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // स्प्लिट करने के बाद तालिका से प्राप्त होने वाली कोशिकाओं को प्राप्त करें.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामस्वरूप कोशिकाओं को उनके समन्वय द्वारा पुनः प्राप्त करें; यहाँ दोनों की स्पैन 1 है और [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False` प्रिंट करता है। एक विभाजन के बाद भी बड़े क्षेत्रों के कुछ हिस्से मर्ज रह सकते हैं।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली होती है लेकिन भराई, बॉर्डर और मार्जिन जैसे सेल स्वरूपण को विरासत में प्राप्त करती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक टेक्स्ट स्वरूपण स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग‑अलग "Product A" और "Product B" कोशिकाएँ होती हैं, जिनमें टेम्प्लेट का सेल स्वरूपण बरकरार रहता है। विवरण के लिए देखें [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)।

### **विशिष्ट ऊँचाई पर कोशिका को विभाजित करें**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) ऊपरी भाग की ऊँचाई पॉइंट्स में लेता है। [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) ऊपरी भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। दाएँ कॉलम में 40‑पॉइंट कोशिका को केंद्रित करने के लिए, कोशिका की वास्तविक ऊँचाई से 40 घटाएँ और शेष स्थान को ऊपर और नीचे बराबर बाँटें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

पहला विभाजन एक ग्रिड पंक्ति जोड़ता है, जिससे नीचे की 90 पॉइंट्स `(1, 1)` पर रहती है। दूसरा विभाजन उस कोशिका को लक्षित करता है और उसके नीचेอีก एक पंक्ति जोड़ता है। दाएँ कॉलम में अब `(1, 0)` 50 पॉइंट्स (`margin`) पर, `(1, 1)` 40 पॉइंट्स पर, और `(1, 2)` 50 पॉइंट्स (`margin`) पर हैं। बायाँ कोशिका अपनी मूल 140‑पॉइंट ऊँचाई पर सभी तीन पंक्तियों को कवर करता है।

![बायाँ कोशिका पूरी तालिका की ऊँचाई को कवर करता है, और उसके बगल में मध्य में तीन कोशिकाएँ हैं।](split-by-height.png)

## **तालिका कोशिका पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट स्तंभों और 50‑पॉइंट पंक्तियों वाली एक तालिका बनाता है। यह [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) का उपयोग करके एक ठोस भराई चुनता है और [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) के माध्यम से भराई रंग तक पहुँचता है तथा इसे लाल सेट करता है, ताकि `(2, 3)` कोशिका (तीसरा स्तंभ, चौथी पंक्ति) का रंग लाल हो।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **तालिका कोशिका के भीतर एक छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्यशील निर्देशिका में रखें। यह छवि को [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) से लोड करता है और इसे प्रस्तुति की छवि संग्रह में [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) से जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` (तालिका की पहली कोशिका) के पिक्चर फ़िल में असाइन करता है।

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) छवि को कोशिका में भरने के लिये विस्तारित करता है, जिससे उसका अनुपात बदल सकता है। स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ पॉइंट्स में हैं। लोड की गई छवि को प्रस्तुति में जोड़ने के बाद समाप्त कर दिया जाता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **FAQ**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [ऊपर](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[नीचे](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[बाएँ](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[दाएँ](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) बॉर्डर के अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है।

**सेल की पृष्ठभूमि में चित्र सेट करने के बाद यदि मैं कॉलम/पंक्ति आकार बदलूँ तो छवि क्या करती है?**

व्यवहार चयनित [भरण मोड](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। विस्तार (stretch) करने पर छवि नई सेल के अनुसार समायोजित हो जाती है; टाइलिंग (tile) करने पर टाइलें पुनः गणना की जाती हैं।

**क्या मैं कोशिका की पूरी सामग्री पर हाइपरलिंक लगा सकता हूँ?**

[हाइपरलिंक](/slides/hi/cpp/manage-hyperlinks/) टेक्स्ट (portion) स्तर पर कोशिका के टेक्स्ट फ्रेम के भीतर या पूरी तालिका/आकृति स्तर पर सेट किया जाता है। व्यवहार में आप लिंक को भाग या पूरी कोशिका के टेक्स्ट पर लागू करते हैं।

**क्या मैं एक ही कोशिका में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक कोशिका का टेक्स्ट फ्रेम स्वतंत्र स्वरूपित [खंड](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (runs) का समर्थन करता है—फ़ॉन्ट फ़ैमिली, शैली, आकार और रंग।