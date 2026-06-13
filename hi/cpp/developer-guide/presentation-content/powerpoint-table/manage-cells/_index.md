---
title: "C++ का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन"
linktitle: "कोशिकाओं का प्रबंधन"
type: docs
weight: 30
url: /hi/cpp/manage-cells/
keywords:
- "तालिका कोशिका"
- "कोशिकाओं का मर्ज"
- "सीमा हटाना"
- "कोशिका विभाजन"
- "कोशिका में छवि"
- "पृष्ठभूमि रंग"
- "PowerPoint"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint में तालिका कोशिकाओं का आसान प्रबंधन। स्लाइड स्वचालन को सहज बनाने के लिए कोशिकाओं तक पहुँच, संशोधन और शैलीकरण को शीघ्रता से महारत हासिल करें।"
---
## **समीक्षा**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख मर्ज की गई तालिका कोशिकाओं की पहचान, कोशिका सीमाओं को हटाना, मर्ज या विभाजन के बाद कोशिका क्रमांकन, कोशिका की पृष्ठभूमि रंग बदलना, और तालिका कोशिका के भीतर छवि जोड़ना समझाता है। उदाहरण दिखाते हैं कि कैसे प्रस्तुति बनाई या खोली जाए, स्लाइड से तालिका प्राप्त की जाए, कोशिका गुणों के माध्यम से कोशिका फ़ॉर्मेटिंग अपडेट की जाए, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजा जाए।

## **मर्ज्ड सेल की पहचान**
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।  
2. पहली स्लाइड से तालिका प्राप्त करें।  
3. तालिका की पंक्तियों और स्तंभों के माध्यम से इटरिटेट करके मर्ज्ड सेल खोजें।  
4. जब मर्ज्ड सेल मिले तो संदेश प्रिंट करें।  

यह C++ कोड दर्शाता है कि प्रस्तुति में मर्ज्ड तालिका कोशिकाओं की पहचान कैसे की जाती है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"SomePresentationWithTable.pptx");
auto table = System::AsCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// मानते हुए कि स्लाइड#0.शेप#0 एक तालिका है
for (int32_t i = 0; i < table->get_Rows()->get_Count(); i++)
{
    for (int32_t j = 0; j < table->get_Columns()->get_Count(); j++)
    {
        auto currentCell = table->get_Rows()->idx_get(i)->idx_get(j);
        if (currentCell->get_IsMergedCell())
        {
            Console::WriteLine(String::Format(u"Cell {0};{1} is a part of merged cell with RowSpan={2} and ColSpan={3} starting from Cell {4};{5}.", 
                i, j, currentCell->get_RowSpan(), currentCell->get_ColSpan(), currentCell->get_FirstRowIndex(), currentCell->get_FirstColumnIndex()));
        }
    }
}
```

## **तालिका सेल सीमाओं को हटाना**
1. [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।  
2. सूचकांक के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।  
4. ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।  
5. `AddTable` मेथड के द्वारा स्लाइड में तालिका जोड़ें।  
6. प्रत्येक सेल के शीर्ष, नीचे, दाएँ और बाएँ सीमाओं को साफ करने के लिए इटरिटेट करें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।  

यह C++ कोड दिखाता है कि तालिका कोशिकाओं की सीमाएँ कैसे हटाई जाती हैं:

``` cpp
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
auto pres = MakeObject<Presentation>();
// पहली स्लाइड तक पहुँचता है
auto sld = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
auto dblCols = MakeArray<double>({ 50, 50, 50, 50 });
auto dblRows = MakeArray<double>({ 50, 30, 30, 30, 30 });

// स्लाइड में तालिका आकार जोड़ता है
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
for (const auto& row : System::IterateOver(tbl->get_Rows()))
{
    for (const auto& cell : System::IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }
}

// PPTX फ़ाइल को डिस्क पर लिखता है
pres->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **मर्ज्ड कोशिकाओं में क्रमांकन**
यदि हम 2 जोड़े कोशिकाओं (1, 1) × (2, 1) और (1, 2) × (2, 2) को मर्ज करते हैं, तो परिणामी तालिका क्रमांकित होगी। यह C# कोड प्रक्रिया को दर्शाता है:

```c++
const String outPath = u"../out/MergeCells_out.pptx";

// वांछित प्रस्तुति को लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// स्लाइड में तालिका आकार जोड़ता है
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
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
// कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

फिर हम (1, 1) और (1, 2) को मर्ज करके कोशिकाओं को आगे मर्ज करते हैं। परिणामस्वरूप मध्य में एक बड़ा मर्ज्ड सेल वाली तालिका बनती है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/MergeCells_out.pptx";

// वांछित प्रस्तुति को लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// स्लाइड में तालिका आकार जोड़ता है
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
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

// कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);


// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **विभाजित सेल में क्रमांकन**
पिछले उदाहरणों में, जब तालिका कोशिकाएँ मर्ज हुईं, तो अन्य कोशिकाओं में क्रमांकन या संख्या प्रणाली नहीं बदली।  

इस बार हम एक सामान्य तालिका (बिना मर्ज्ड सेल की) लेते हैं और फिर सेल (1,1) को विभाजित करके एक विशेष तालिका बनाते हैं। आप इस तालिका के क्रमांकन पर ध्यान देना चाहेंगे, जो अजीब लग सकता है। लेकिन यही Microsoft PowerPoint तालिका कोशिकाओं को क्रमांकित करता है और Aspose.Slides भी यही करता है।  

यह C++ कोड उस प्रक्रिया को दर्शाता है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/CellSplit_out.pptx";

// वांछित प्रस्तुति को लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 70);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 70);

// स्लाइड में तालिका आकार जोड़ता है
SharedPtr<ITable> table = islide->get_Shapes()->AddTable(100, 50, dblCols, dblRows);


// प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
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

// कोशिकाओं (1, 1) x (2, 1) को मर्ज करता है
table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 1), false);

// कोशिकाओं (1, 2) x (2, 2) को मर्ज करता है
table->MergeCells(table->idx_get(1, 2), table->idx_get(2, 2), false);

// सेल (1, 1) को विभाजित करता है। 
table->idx_get(1, 1)->SplitByWidth(table->idx_get(2, 1)->get_Width() / 2);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **तालिका सेल पृष्ठभूमि रंग बदलना**

यह C++ कोड दिखाता है कि तालिका सेल का पृष्ठभूमि रंग कैसे बदला जाता है:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);
        
auto dblCols = System::MakeArray<double>({150, 150, 150, 150});
auto dblRows = System::MakeArray<double>({50, 50, 50, 50, 50});
        
// नई तालिका बनाएँ
auto table = slide->get_Shapes()->AddTable(50.0f, 50.0f, dblCols, dblRows);
        
// एक कोशिका के लिए पृष्ठभूमि रंग सेट करें
System::SharedPtr<ICell> cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());
        
presentation->Save(u"cell_background_color.pptx", Aspose::Slides::Export::SaveFormat::Pptx);

```

## **तालिका सेल के भीतर छवि जोड़ना**
1. `Presentation` क्लास का एक इंस्टेंस बनाएं।  
2. सूचकांक के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. चौड़ाई के साथ स्तंभों की एक एरे परिभाषित करें।  
4. ऊँचाई के साथ पंक्तियों की एक एरे परिभाषित करें।  
5. `AddTable` मेथड के द्वारा स्लाइड में तालिका जोड़ें।  
6. छवि फ़ाइल को रखने के लिए एक `Bitmap` ऑब्जेक्ट बनाएं।  
7. बिटमैप छवि को `IPPImage` ऑब्जेक्ट में जोड़ें।  
8. तालिका सेल के लिए `FillFormat` को `Picture` पर सेट करें।  
9. छवि को तालिका की पहली सेल में जोड़ें।  
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।  

यह C# कोड दिखाता है कि तालिका बनाते समय तालिका सेल के भीतर छवि कैसे रखी जाती है:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/Image_In_TableCell_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// वांछित प्रस्तुति को लोड करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुँचता है
SharedPtr<ISlide> islide = pres->get_Slides()->idx_get(0);

// स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
System::ArrayPtr<double> dblCols = System::MakeObject<System::Array<double>>(4, 150);
System::ArrayPtr<double> dblRows = System::MakeObject<System::Array<double>>(4, 100);
System::ArrayPtr<double> total_for_Cat = System::MakeObject<System::Array<double>>(5, 0);

// स्लाइड में तालिका आकार जोड़ता है
auto tbl = islide->get_Shapes()->AddTable(50, 50, dblCols, dblRows);

// चित्र प्राप्त करता है
auto img = Images::FromFile(ImagePath);

// प्रस्तुति की छवियों संग्रह में एक छवि जोड़ता है
SharedPtr<IPPImage> imgx = pres->get_Images()->AddImage(img);

// छवि को पहली तालिका कोशिका में जोड़ता है
tbl->idx_get(0, 0)->get_FillFormat()->set_FillType(FillType::Picture);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
tbl->idx_get(0, 0)->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// PPTX फ़ाइल को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**क्या मैं एक ही सेल के विभिन्न किनारों के लिए अलग-अलग रेखा मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/hi/cpp/aspose.slides/cellformat/get_borderright/) सीमाओं के अलग‑अलग गुण हैं, इसलिए प्रत्येक किनारे की मोटाई और शैली भिन्न हो सकती है। यह लेख में दर्शाए गए प्रति‑किनारा सीमा नियंत्रण से तर्कसंगत रूप से जुड़ा है।

**यदि मैं सेल की पृष्ठभूमि के रूप में चित्र सेट करने के बाद स्तंभ/पंक्ति का आकार बदलूँ तो चित्र पर क्या प्रभाव पड़ेगा?**

व्यवहार [fill mode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच होने पर चित्र नई सेल के अनुसार समायोजित हो जाता है; टाइल होने पर टाइलें पुनः‑गणना की जाती हैं। लेख में सेल में चित्र प्रदर्शित मोड के बारे में उल्लेख है।

**क्या मैं सेल की पूरी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/cpp/manage-hyperlinks/) को सेल के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी तालिका/शेप स्तर पर सेट किया जाता है। व्यवहार में आप लिंक को किसी भाग या सेल के सभी टेक्स्ट को असाइन कर सकते हैं।

**क्या मैं एक ही सेल में विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। सेल के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/portion/) (रनों) को स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट फ़ैमिली, शैली, आकार, और रंग—के साथ समर्थन मिलता है।