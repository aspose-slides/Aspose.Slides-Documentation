---
title: C++ का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/cpp/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति पाठ स्वरूपण
- स्तंभ पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन व डेटा अद्यतन को तेज़ बनाएं।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/cpp/aspose.slides/table/) वर्ग, [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) इंटरफ़ेस और कई अन्य प्रकार प्रदान करता है।

## **पहली पंक्ति को हेडर के रूप में सेट करें**

1. Presentation वर्ग का एक उदाहरण बनाएं और प्रस्तुति लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. ITable ऑब्जेक्ट बनाएं और इसे null पर सेट करें।  
4. सभी IShape ऑब्जेक्ट्स पर इटरेट करके संबंधित तालिका खोजें।  
5. तालिका की पहली पंक्ति को उसका हेडर सेट करें।  

यह C++ कोड दिखाता है कि तालिका की पहली पंक्ति को हेडर के रूप में कैसे सेट करें:

```c++
// Presentation क्लास का इंस्टेंस बनाता है 
auto pres = System::MakeObject<Presentation>(u"table.pptx");

// पहली स्लाइड तक पहुँचता है
auto sld = pres->get_Slides()->idx_get(0);

// null TableEx को इनिशियलाइज़ करता है
SharedPtr<ITable> tbl;

// शेप्स के माध्यम से इटरिट करता है और तालिका का रेफ़रेंस सेट करता है
for (const auto& shp : sld->get_Shapes())
{
    if (ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// तालिका की पहली पंक्ति को उसका हेडर सेट करता है 
tbl->set_FirstRow(true);
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

1. Presentation वर्ग का एक उदाहरण बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `columnWidth` का एक array परिभाषित करें।  
4. `rowHeight` का एक array परिभाषित करें।  
5. स्लाइड में [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट को [AddTable()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addtable/) मेथड से जोड़ें।  
6. तालिका की पंक्ति को क्लोन करें।  
7. तालिका के स्तंभ को क्लोन करें।  
8. संशोधित प्रस्तुति को सहेजें।  

यह C++ कोड दिखाता है कि PowerPoint तालिका की पंक्ति या स्तंभ को कैसे क्लोन करें:

```c++
 // दस्तावेज़ डायरेक्टरी का पथ।
const String outPath = u"../out/CloningInTable_out.pptx";

// Presentation क्लास का इंस्टेंस बनाता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// स्लाइड में एक टेबल शेप जोड़ता है
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// प्रत्येक सेल के लिए बॉर्डर फॉर्मेट सेट करता है
for (int x = 0; x < table->get_Rows()->get_Count(); x++)
{
	SharedPtr<IRow> row = table->get_Rows()->idx_get(x);
	for (int y = 0; y < row->get_Count(); y++)
	{
		SharedPtr<ICell> cell = row->idx_get(y);

		cell->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderTop()->set_Width(5);

		cell->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderBottom()->set_Width(5);

		cell->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderLeft()->set_Width(5);

		cell->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
		cell->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
		cell->get_BorderRight()->set_Width(5);

	}

}

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"00");
table->idx_get(0, 1)->get_TextFrame()->set_Text(u"01");
table->idx_get(0, 2)->get_TextFrame()->set_Text(u"02");
table->idx_get(0, 3)->get_TextFrame()->set_Text(u"03");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"11");
table->idx_get(2, 1)->get_TextFrame()->set_Text(u"21");

// AddClone तालिका के अंत में एक पंक्ति जोड़ता है
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

// InsertClone तालिका में एक विशिष्ट स्थिति पर पंक्ति जोड़ता है
table->get_Rows()->InsertClone(2, table->get_Rows()->idx_get(0), false);

// AddClone तालिका के अंत में एक स्तंभ जोड़ता है
table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);

// InsertClone तालिका में एक विशिष्ट स्थिति पर स्तंभ जोड़ता है
table->get_Columns()->InsertClone(2, table->get_Columns()->idx_get(0), false);


// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

1. Presentation वर्ग का एक उदाहरण बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. `columnWidth` का एक array परिभाषित करें।  
4. `rowHeight` का एक array परिभाषित करें।  
5. स्लाइड में [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट को [AddTable()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addtable/) मेथड से जोड़ें।  
6. तालिका की पंक्ति को हटाएँ।  
7. तालिका के स्तंभ को हटाएँ।  
8. संशोधित प्रस्तुति को सहेजें।  

यह C++ कोड दिखाता है कि तालिका से पंक्ति या स्तंभ कैसे हटाएँ:

```c++
// दस्तावेज़ डायरेक्टरी का पथ।
const String outPath = u"../out/RemovingRowColumn_out.pptx";

// Presentation क्लास का इंस्टेंस बनाता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// स्लाइड में एक टेबल आकार जोड़ता है
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);


// सेल्स (1, 1) x (2, 1) को मिलाता है
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// सेल्स (1, 2) x (2, 2) को मिलाता है
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// प्रेजेंटेशन को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **तालिका पंक्ति स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. Presentation वर्ग का एक उदाहरण बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट तक पहुँचें।  
4. पहली पंक्ति की कोशिकाओं के लिए [set_FontHeight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_fontheight/) सेट करें।  
5. पहली पंक्ति की कोशिकाओं के लिए [set_Alignment()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginright/) सेट करें।  
6. दूसरी पंक्ति की कोशिकाओं के लिए [set_TextVerticalType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_textverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C++ कोड इस ऑपरेशन को दर्शाता है:

```c++
// Presentation क्लास का इंस्टेंस बनाता है
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// मान लेते हैं कि पहली स्लाइड पर पहला शेप एक टेबल है
// पहली पंक्ति की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

// पहली पंक्ति की कोशिकाओं के टेक्स्ट संरेखण और दाएँ मार्जिन को सेट करता है
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

// दूसरी पंक्ति की कोशिकाओं के टेक्स्ट वर्टिकल प्रकार को सेट करता है
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

// प्रेजेण्टेशन को डिस्क पर सहेजता है
presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **तालिका स्तंभ स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. Presentation वर्ग का एक उदाहरण बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. स्लाइड से संबंधित [ITable](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itable/) ऑब्जेक्ट तक पहुँचें।  
4. पहली स्तंभ की कोशिकाओं के लिए [set_FontHeight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/baseportionformat/set_fontheight/) सेट करें।  
5. पहली स्तंभ की कोशिकाओं के लिए [set_Alignment()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_alignment/) और [set_MarginRight()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraphformat/set_marginright/) सेट करें।  
6. दूसरी स्तंभ की कोशिकाओं के लिए [set_TextVerticalType()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_textverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह C++ कोड इस ऑपरेशन को दर्शाता है:

```c++
// Presentation क्लास का इंस्टेंस बनाता है
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);

auto someTable = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
// मान लेते हैं कि पहली स्लाइड पर पहला शेप एक टेबल है

// पहली कॉलम की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

// एक कॉल में पहली कॉलम की कोशिकाओं के टेक्स्ट संरेखण और दाएँ मार्जिन को सेट करता है
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

// दूसरी कॉलम की कोशिकाओं के टेक्स्ट वर्टिकल प्रकार को सेट करता है
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

pres->Save(u"result.pptx", SaveFormat::Pptx);
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी अन्य तालिका या अन्य स्थान पर उपयोग कर सकें। यह C++ कोड दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/शैलियों को लागू कर सकता हूँ?**

हाँ। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में लेती है, और आप फिर भी उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को क्रमबद्ध कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित क्रमबद्धता या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में क्रमबद्ध करें, फिर उस क्रम के अनुसार तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख कर विशिष्ट कोशिकाओं पर कस्टम रंग रख सकता हूँ?**

हाँ। बैंडेड स्तंभ को सक्षम करें, फिर विशिष्ट कोशिकाओं को स्थानीय फॉर्मेटिंग से ओवरराइड करें; कोशिका‑स्तर की फॉर्मेटिंग तालिका शैली पर प्राथमिकता लेती है।