---
title: "C++ का उपयोग कर प्रस्तुतियों में तालिका कोशिकाओं को प्रबंधित करें"
linktitle: "कोशिकाओं को प्रबंधित करें"
type: docs
weight: 30
url: /hi/cpp/manage-cells/
keywords:
  - "तालिका कोशिका"
  - "कोशिकाओं को मिलाएँ"
  - "सीमा हटाएँ"
  - "कोशिका विभाजित करें"
  - "कोशिका में चित्र"
  - "पृष्ठभूमि रंग"
  - "PowerPoint"
  - "प्रस्तुति"
  - "C++"
  - "Aspose.Slides"
description: "C++ में PowerPoint तालिका कोशिकाओं को प्रबंधित करें: मर्ज्ड कोशिकाओं की पहचान करें, सीमाओं को हटाएँ, कोशिकाओं को विभाजित करें, और Aspose.Slides for C++ के साथ पृष्ठभूमि रंग और चित्र सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें, कोशिका की सीमाओं को हटाएँ, मर्ज या विभाजन के बाद कोशिका क्रमांक के साथ काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के अंदर एक चित्र जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका फ़ॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांक का उपयोग करके तालिका कोशिकाओं तक क्रम `(column, row)` में पहुँचता है।

## **मर्ज की गई तालिका कोशिका की पहचान करें**

उदाहरण मौजूदा प्रस्तुति को खोलता है और पहले स्लाइड पर प्रथम आकार को एक तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर यह सभी पंक्तियों और स्तंभों के माध्यम से इटरेट करता है और मर्ज की गई क्षेत्रों में कोशिकाओं की पहचान करने के लिए [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) का उपयोग करता है। प्रत्येक मिलान के लिए, यह कोशिका निर्देशांक `row;column` क्रम में प्रिंट करता है, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/), और क्षेत्र के प्रारम्भिक निर्देशांक, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) तथा [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/)।

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

## **तालिका कोशिका सीमाएँ हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) बनाएँ और अपने पहले स्लाइड पर [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) का प्रयोग करके एक तालिका जोड़ें। स्तंभ चौड़ाई, पंक्ति ऊँचाई, और तालिका की स्थिति बिंदुओं (points) में निर्दिष्ट की जाती है। उदाहरण सभी चार कोशिका सीमाओं को [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाते हैं।

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

## **तालिका कोशिकाओं को मर्ज करें**

एक आयताकार सीमा की तालिका कोशिकाओं को एक कोशिका में मिलाने के लिए [MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) का उपयोग करें। सीमा के शीर्ष-बाएँ और निचले-दाएँ कोने की कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि क्या मर्ज निर्दिष्ट सीमा के बाहर की कोशिकाओं को शामिल कर सकता है; `false` मर्ज को उस सीमा के भीतर रखता है।

उदाहरण 70-पॉइंट स्तंभों और पंक्तियों के साथ 4x4 तालिका बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय कोशिकाओं को मर्ज करता है। परिणामी कोशिका दो स्तंभ और दो पंक्तियों को कवर करती है, जबकि तालिका की मूल ग्रिड चार स्तंभ और चार पंक्तियों को बरकरार रखती है। मर्ज की गई कोशिका की सामग्री या फ़ॉर्मेटिंग तक पहुँचने के लिए, इस उदाहरण में उसकी शीर्ष-बाएँ स्थिति का उपयोग करें: `table->idx_get(1, 1)`। मर्ज रेंज में अन्य स्थितियां तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए सीमा के बाहर की कोशिकाओं के सूचकांक परिवर्तित नहीं होते।

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

पहले उदाहरण में कोशिकाओं को मर्ज करने से तालिका की ग्रिड संरक्षित रहती है। किसी कोशिका को विभाजित करने से नया ग्रिड स्तंभ बन सकता है और उसकी दाईं ओर की कोशिकाओं के स्तंभ सूचकांक बदल सकते हैं। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70-पॉइंट स्तंभों और पंक्तियों के साथ 4x4 तालिका बनाता है और कोशिका `(1, 1)` पर [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) को कॉल करता है। कोशिका की 70-पॉइंट चौड़ाई का आधा भाग दो समान-चौड़ाई वाली कोशिकाओं के निर्माण के लिए पास किया जाता है।

इस विभाजन के बाद, दोनों हिस्सों तक `table->idx_get(1, 1)` और `table->idx_get(2, 1)` के रूप में पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तंभ रखती है: मूल रूप से स्तंभ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तंभ 3 और 4 में चली जाती हैं। पंक्ति सूचकांक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अद्यतन स्तंभ सूचकांकों का उपयोग करें।

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

### **पंक्ति या स्तंभ स्पैन द्वारा मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज किए गए टेम्पलेट कोशिकाओं को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ विभाजन के लिए [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) और स्तंभ सीमा के साथ विभाजन के लिए [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) का उपयोग करें।

`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तंभों की गिनती करता है; यह मर्ज किए गए क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/)।
- स्तंभ विभाजन: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/)।

उदाहरण मानता है कि प्रस्तुति में पहले स्लाइड पर प्रथम आकार के रूप में एक तालिका है, जिसमें `(1, 2)` और `(1, 3)` को लंबवत रूप से मर्ज किया गया है। निचली स्थिति से शुरू करते हुए, यह मूल को खोजने के लिए [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) और [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) का उपयोग करता है और दोनों स्पैन को जाँचता है। `SplitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो-स्तंभ मर्ज के लिए, इसके बजाय `SplitByColSpan(1)` का उपयोग करें।

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

    // विभाजन के बाद तालिका से प्राप्त हुई कोशिकाओं को प्राप्त करें।
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

तालिका ग्रिड और आसपास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामी कोशिकाओं को उनके निर्देशांक द्वारा प्राप्त करें; यहाँ, दोनों का स्पैन 1 है और [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False` प्रिंट करता है। एक विभाजन के बाद भी बड़े क्षेत्रों का कुछ हिस्सा मर्ज्ड रह सकता है।

मौलिक पाठ और उसका फ़ॉर्मेटिंग ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली है लेकिन भराव, सीमाएँ और मार्जिन जैसी कोशिका फ़ॉर्मेटिंग को विरासत में लेती है। विभाजन के बाद कोशिकाओं में डेटा भरें और आवश्यक पाठ फ़ॉर्मेटिंग को स्पष्ट रूप से सेट करें।

सहेजी गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं जिनमें टेम्पलेट की कोशिका फ़ॉर्मेटिंग बरकरार रहती है। विवरण के लिए देखें [सेल API रेफ़रेंस](https://reference.aspose.com/slides/cpp/aspose.slides/cell/)।

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150-पॉइंट स्तंभों और 50-पॉइंट पंक्तियों वाली तालिका बनाता है। यह [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) का प्रयोग करके ठोस भराव चुनता है और [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) का उपयोग करके भराव रंग तक पहुँचता है और इसे सेल `(2, 3)` के लिए लाल सेट करता है, जो तीसरे स्तंभ और चौथी पंक्ति में स्थित है।

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

## **तालिका कोशिका के अंदर एक चित्र जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट चित्र को कार्य निर्देशिका में रखें। यह चित्र को [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) का उपयोग करके लोड करता है और उसे प्रस्तुति के इमेज कलेक्शन में [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) से जोड़ता है। फिर यह चित्र को कोशिका `(0, 0)` के पिक्चर फ़िल में असाइन करता है, जो तालिका की पहली कोशिका है।

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) चित्र को सेल में भरने के लिए फैलाता है, जिससे उसका अनुपात बदल सकता है। स्तंभ चौड़ाई और पंक्ति ऊँचाई बिंदुओं (points) में हैं। लोड किया गया चित्र प्रस्तुति में जोड़ने के बाद नष्ट कर दिया जाता है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) सीमाओं के अलग-अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग‑अलग हो सकती है।

**यदि मैं कोशिका की पृष्ठभूमि के रूप में चित्र सेट करने के बाद स्तंभ/पंक्ति का आकार बदलूँ तो चित्र के साथ क्या होता है?**

व्यवहार [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) पर निर्भर करता है (stretch/tile)। स्ट्रेचिंग के साथ, चित्र नए सेल के अनुसार समायोजित हो जाता है; टाइलिंग के साथ, टाइलें पुनः गणना की जाती हैं।

**क्या मैं एक कोशिका की सभी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/cpp/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/आकार स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी भाग या पूरी कोशिका के टेक्स्ट को असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (रन) स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट परिवार, शैली, आकार और रंग—का समर्थन करते हैं।