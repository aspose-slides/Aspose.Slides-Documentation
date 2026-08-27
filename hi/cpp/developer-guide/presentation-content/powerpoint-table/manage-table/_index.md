---
title: C++ में प्रस्तुति तालिकाओं को प्रबंधित करें
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/cpp/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint स्लाइड में तालिकाओं को बनाएं और संपादित करें। अपने तालिका कार्य प्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में तालिका जानकारी को प्रदर्शित और चित्रित करने का एक प्रभावी तरीका है। पंक्तियों और स्तंभों में व्यवस्थित कोशिकाओं की ग्रिड में जानकारी सरल और आसानी से समझने योग्य होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) इंटरफ़ेस, [Cell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है ताकि आप विभिन्न प्रस्तुतियों में तालिकाओं को बना, अद्यतन और प्रबंधित कर सकें। 

## **शुरू से तालिका बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. उसके सूचकांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `columnWidth` की एक एरे निर्धारित करें।  
4. `rowHeight` की एक एरे निर्धारित करें।  
5. स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट को [AddTable()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addtable/) मेथड के माध्यम से जोड़ें।  
6. प्रत्येक [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) को पारित करके ऊपरी, निचले, दाएँ और बाएँ किनारों पर स्वरूपण लागू करें।  
7. तालिका की पहली पंक्ति के पहले दो कोशिकाओं को मिलाएँ।  
8. किसी [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/)'s [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) में कुछ पाठ जोड़ें।  
10. संशोधित प्रस्तुति को सहेजें।

यह C++ 코ड आपको दिखाता है कि प्रस्तुति में तालिका कैसे बनाएं:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुंचता है
auto sld = pres->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को निर्धारित करता है
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// स्लाइड में एक तालिका आकार जोड़ता है
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
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
// पंक्ति 1 की सेल 1 और 2 को मिलाता है
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// मिलाए गए सेल में कुछ टेक्स्ट जोड़ता है
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **मानक तालिका में क्रमांकन**

मानक तालिका में कोशिकाओं का क्रमांकन सरल और शून्य-आधारित होता है। तालिका की पहली कोशिका को 0,0 (स्तंभ 0, पंक्ति 0) के रूप में अनुक्रमित किया जाता है। 

उदाहरण के लिए, 4 स्तम्भ और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह C++ 코ड आपको दिखाता है कि तालिका में कोशिकाओं के क्रमांकन को कैसे निर्दिष्ट करें:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// एक Presentation क्लास का उदाहरण बनाता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
auto pres = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुंचता है
auto sld = pres->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// स्लाइड में एक तालिका आकार जोड़ता है
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
for (const auto& row : tbl->get_Rows())
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

// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **मौजूदा तालिका तक पहुंचें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  

2. उसके सूचकांक के माध्यम से तालिका वाली स्लाइड का संदर्भ प्राप्त करें।  

3. एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट बनाएं और उसे null सेट करें।  

4. सभी [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) ऑब्जेक्ट्स को पारित करें जब तक तालिका न मिल जाए।  

   यदि आपको संदेह है कि आप जिस स्लाइड को संभाल रहे हैं उसमें एक ही तालिका है, तो आप बस उसकी सभी आकृतियों की जाँच कर सकते हैं। जब कोई आकार तालिका के रूप में पहचाना जाता है, तो आप उसे [Table](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/) ऑब्जेक्ट के रूप में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको उसकी [set_AlternativeText()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_alternativetext/) के माध्यम से आवश्यकता वाली तालिका को खोज लेना बेहतर रहेगा।  

5. तालिका के साथ काम करने के लिए [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में हमने तालिका में एक नई पंक्ति जोड़ी है।  

6. संशोधित प्रस्तुति को सहेजें।  

यह C++ 코ड आपको दिखाता है कि मौजूदा तालिका तक कैसे पहुंचें और उसके साथ काम करें:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// पहली स्लाइड तक पहुंचता है
auto sld = pres->get_Slides()->idx_get(0);

// शून्य Table को प्रारंभ करता है
System::SharedPtr<ITable> tbl;

// आकारों के माध्यम से इटरनेट करता है और मिली टेबल का संदर्भ सेट करता है
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// दूसरी पंक्ति के पहले कॉलम का टेक्स्ट सेट करता है
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// संशोधित प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **ऐसे सेल को खोजें जिसका टेक्स्ट फ्रेम मालिक है**

जब सामान्य टेक्स्ट प्रोसेसिंग कोड को तालिका से कोई [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) मिलता है, तो उस मालिक [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) को प्राप्त करने के लिए [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) का उपयोग करें। तालिका‑सेल टेक्स्ट फ्रेम के लिए, यह मेथड मालिक को लौटाता है और [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` लौटाता है, जबकि स्वयं तालिका एक शैप है।  

सेल के निर्देशांक पढ़ने‑के‑लिए‑केवल [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/get_firstcolumnindex/) और [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/get_firstrowindex/) मेथड उपलब्ध हैं। [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/get_parentcell/) केवल पढ़ने‑के‑लिए नेविगेशन भी प्रदान करता है: यह मालिक लौटाता है लेकिन स्वामित्व नहीं बदलता। हमेशा उपयोग करने से पहले लौटाए गए सेल के लिए `nullptr` की जाँच करें।  

पूरी उदाहरण के लिए जो तालिका‑सेल और शैप मालिकों की पहचान करता है, जिसमें SmartArt नोड्स से जुड़े शैप भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/cpp/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. उसके सूचकांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) ऑब्जेक्ट तक पहुंचें।  
5. उस [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के भीतर के [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) तक पहुंचें।  
6. टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C++ 코ड आपको दिखाता है कि तालिका में टेक्स्ट को कैसे संरेखित करें:

```c++
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
#include <DOM/ISlideCollection.h>
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

// Presentation क्लास का एक उदाहरण बनाता है
auto presentation = System::MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// स्लाइड में तालिका आकार जोड़ता है
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// टेक्स्ट फ्रेम तक पहुंचता है
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// टेक्स्ट फ्रेम के लिए Paragraph ऑब्जेक्ट बनाता है
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraph के लिए Portion ऑब्जेक्ट बनाता है
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करता है
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// प्रस्तुति को डिस्क पर सहेजता है
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **तालिका स्तर पर टेक्स्ट स्वरूपण सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. उसके सूचकांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट तक पहुंचें।  
4. टेक्स्ट के लिए [set_FontHeight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_fontheight/) सेट करें।  
5. [set_Alignment()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginright/) सेट करें।  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_textverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C++ 코ड आपको दिखाता है कि तालिका में टेक्स्ट पर अपनी वांछित स्वरूपण विकल्प कैसे लागू करें:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
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

// Presentation क्लास का एक उदाहरण बनाता है
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// मान लें कि पहली स्लाइड पर पहला आकार एक तालिका है
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// तालिका कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// एक कॉल में तालिका कोशिकाओं का टेक्स्ट संरेखण और दायाँ मार्जिन सेट करता है
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// तालिका कोशिकाओं का टेक्स्ट ऊर्ध्वाधर प्रकार सेट करता है
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका की शैली गुण प्राप्त करने की सुविधा देता है ताकि आप इन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह C++ 코ड आपको दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **तालिका का पहलू अनुपात लॉक करें**

ज्यामितीय आकार का पहलू अनुपात विभिन्न आयामों में इसके आकार का अनुपात होता है। Aspose.Slides ने `AspectRatioLocked()` प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य आकारों के लिए पहलू अनुपात सेटिंग को लॉक कर सकते हैं।  

यह C++ 코ड आपको दिखाता है कि तालिका के लिए पहलू अनुपात कैसे लॉक करें:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दायें‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका एक [set_RightToLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/set_righttoleft/) मेथड प्रदान करती है, और पैराग्राफ के पास [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraphformat/set_righttoleft/) है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।  

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

[shape locks](/slides/hi/cpp/applying-protection-to-presentation/) का उपयोग करके स्थानांतरण, आकार बदलना, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।  

**क्या सेल के अंदर पृष्ठभूमि के रूप में छवि डालना समर्थित है?**

हां। आप सेल के लिए एक [picture fill](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (खींचना या टाइल) के अनुसार सेल क्षेत्र को कवर कर लेगी।