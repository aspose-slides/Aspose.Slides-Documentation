---
title: C++ में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/cpp/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint स्लाइड्स में Aspose.Slides for C++ के साथ तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सहज बनाने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में तालिका जानकारी को प्रदर्शित और प्रस्तुत करने का एक प्रभावी तरीका है। कोशिकाओं की ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सीधी और समझने में आसान होती है।

Aspose.Slides [टेबल](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/) क्लास, [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) इंटरफ़ेस, [सेल](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cell/) क्लास, [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) इंटरफ़ेस, और अन्य प्रकार प्रदान करता है जो आपको सभी प्रकार की प्रस्तुतियों में तालिकाएँ बनाने, अपडेट करने और प्रबंधित करने की अनुमति देते हैं। 

## **शुरू से तालिका बनाना**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. `columnWidth` की एक एरे परिभाषित करें।  
4. `rowHeight` की एक एरे परिभाषित करें।  
5. स्लाइड में [AddTable()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addtable/) मेथड के द्वारा एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।  
6. प्रत्येक [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) को इटररेट करके शीर्ष, नीचे, दाएँ और बाएँ बॉर्डर पर फ़ॉर्मेटिंग लागू करें।  
7. तालिका की पहली पंक्ति की पहले दो कोशिकाओं को मर्ज करें।  
8. एक [ICell](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icell/) के [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. संशोधित प्रस्तुति को सहेजें।  

```c++
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
auto sld = pres->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// स्लाइड में एक टेबल शेप जोड़ता है
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// प्रत्येक कोशिका के लिए बॉर्डर फ़ॉर्मेट सेट करता है
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
// पंक्ति 1 की कोशिकाएँ 1 और 2 को मर्ज करता है
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// मर्ज की गई कोशिका में कुछ टेक्स्ट जोड़ता है
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में कोशिकाओं की क्रमांकन सीधी और शून्य-आधारित होती है। तालिका की पहली कोशिका को 0,0 (स्तंभ 0, पंक्ति 0) के रूप में इंडेक्स किया गया है।  

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह C++ कोड दिखाता है कि तालिका में कोशिकाओं के क्रमांकन को कैसे निर्दिष्ट किया जाता है:

```c++
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>();

// पहली स्लाइड तक पहुंचता है
auto sld = pres->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// स्लाइड में एक टेबल शेप जोड़ता है
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// प्रत्येक कोशिका के लिए बॉर्डर फ़ॉर्मेट सेट करता है
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

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. तालिका वाली स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट बनाएं और उसे null सेट करें।  
4. सभी [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) ऑब्जेक्ट्स को इटररेट करें जब तक तालिका नहीं मिलती।  

   यदि आपको संदेह है कि स्लाइड में केवल एक तालिका है, तो आप सभी शैप्स को जाँच सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप उसे [Table](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आप आवश्यक तालिका को उसके [set_AlternativeText()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_alternativetext/) के माध्यम से खोजना बेहतर होगा।  

5. तालिका के साथ काम करने के लिए [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में हमने तालिका में एक नई पंक्ति जोड़ी।  
6. संशोधित प्रस्तुति को सहेजें।  

```c++
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// पहली स्लाइड तक पहुंचता है
auto sld = pres->get_Slides()->idx_get(0);

// null तालिका को प्रारंभ करता है
System::SharedPtr<ITable> tbl;

// शैप्स के माध्यम से इटरate करता है और मिली तालिका का संदर्भ सेट करता है
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// दूसरी पंक्ति के पहले स्तंभ के लिए टेक्स्ट सेट करता है
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// संशोधित प्रस्तुति को डिस्क पर सहेजता है
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **तालिका में टेक्स्ट संरेखित करना**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड में एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) ऑब्जेक्ट तक पहुंचें।  
5. [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) तक पहुंचें।  
6. टेक्स्ट को लंबवत रूप से संरेखित करें।  
7. संशोधित प्रस्तुति को सहेजें।  

```c++
// Presentation क्लास का एक इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करता है
auto slide = presentation->get_Slides()->idx_get(0);

// कॉलम की चौड़ाइयों और पंक्तियों की ऊँचाइयों को परिभाषित करता है
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// स्लाइड में टेबल शेप जोड़ता है
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// टेक्स्ट फ्रेम तक पहुंचता है
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// टेक्स्ट को लंबवत रूप से संरेखित करता है
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// प्रेजेंटेशन को डिस्क पर सहेजता है
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।  
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।  
3. स्लाइड से एक [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट तक पहुंचें।  
4. टेक्स्ट के लिए [set_FontHeight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_fontheight/) सेट करें।  
5. [set_Alignment()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginright/) सेट करें।  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_textverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

```c++
// Presentation क्लास का एक इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// मान लीजिए कि पहली स्लाइड पर पहला शेप एक टेबल है
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// टेबल की कोशिकाओं के फ़ॉन्ट की ऊँचाई सेट करता है
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// एक ही कॉल में टेबल की कोशिकाओं के टेक्स्ट संरेखण और दाएँ मार्जिन सेट करता है
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// टेबल की कोशिकाओं के टेक्स्ट वर्टिकल प्रकार सेट करता है
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह C++ कोड दर्शाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त किए जाते हैं:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **तालिका का पक्ष अनुपात लॉक करें**

ज्यामितीय आकार का पक्ष अनुपात विभिन्न आयामों में उसके आकार का अनुपात होता है। Aspose.Slides ने `AspectRatioLocked()` प्रॉपर्टी प्रदान की है जिससे आप तालिकाओं और अन्य आकृतियों के लिए पक्ष अनुपात सेटिंग को लॉक कर सकते हैं।  

यह C++ कोड दिखाता है कि तालिका के लिए पक्ष अनुपात कैसे लॉक किया जाता है:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**  

हाँ। तालिका एक [set_RightToLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/set_righttoleft/) मेथड प्रदान करती है, और पैराग्राफ के पास [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/hi/cpp/aspose.slides/paragraphformat/set_righttoleft/) होता है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को हिलाने या आकार बदलने से कैसे रोक सकता हूँ?**  

[shape locks](/slides/hi/cpp/applying-protection-to-presentation/) का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को निष्क्रिय करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या किसी कोशिका के अंदर पृष्ठभूमि के रूप में छवि डालना समर्थित है?**  

हाँ। आप एक कोशिका के लिए [picture fill](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चयनित मोड (स्ट्रेच या टाइल) के अनुसार कोशिका के क्षेत्र को कवर कर लेगी।