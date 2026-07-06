---
title: C++ में प्रस्तुतियों से पैराग्राफ बाउंड्स प्राप्त करें
linktitle: पैराग्राफ बाउंड्स
type: docs
weight: 43
url: /hi/cpp/paragraph-bounds/
keywords:
- पैराग्राफ बाउंड्स
- पैराग्राफ निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट फ्रेम
- पावरपॉइंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides के लिए C++ में पैराग्राफ बाउंड्स को पुनः प्राप्त करने और PowerPoint प्रस्तुतियों में टेक्स्ट पोजिशनिंग को अनुकूलित करने का तरीका सीखें।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पैराग्राफ़ की सीमा, आकार और निर्देशांक प्राप्त करने के तरीके को समझाता है। यह दिखाता है कि कैसे [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) का उपयोग करके [IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getrect/) द्वारा पैराग्राफ़ का आयत प्राप्त किया जा सकता है, तालिका सेल टेक्स्ट फ़्रेम के भीतर पैराग्राफ़ के निर्देशांक कैसे प्राप्त किए जाएँ, और मापन इकाइयाँ, टेक्स्ट रैपिंग का सीमा पर प्रभाव, पिक्सेल रूपांतरण, और प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **पैराग्राफ़ के आयताकार निर्देशांक प्राप्त करें**

[IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getrect/) का उपयोग करके पैराग्राफ़ का बाउंडिंग आयत प्राप्त करें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **तालिका सेल टेक्स्टफ़्रेम के भीतर पैराग्राफ़ का आकार प्राप्त करें**

तालिका सेल टेक्स्ट फ़्रेम में एक [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) का आकार और निर्देशांक प्राप्त करने के लिए, [IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/getrect/) का उपयोग करें। प्राप्त किया गया आयत तालिका सेल टेक्स्ट फ़्रेम के सापेक्ष होता है, इसलिए जब आपको स्लाइड-स्तर के निर्देशांक चाहिए हों तो तालिका की स्थिति और सेल ऑफसेट जोड़ें।

निम्न उदाहरण तालिका सेल के भीतर पैराग्राफ़ की सीमाएँ प्राप्त करता है और स्लाइड पर आयतें बनाकर उन सीमाओं को प्रदर्शित करता है:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ़ के निर्देशांक किस इकाई में मापे जाते हैं?**

इन्हें पॉइंट्स में मापा जाता है, जहाँ 1 इंच बराबर 72 पॉइंट्स होता है। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ़ की सीमाओं को प्रभावित करती है?**

हाँ। यदि [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframeformat/set_wraptext/) को [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के लिए सक्षम किया जाता है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे पैराग्राफ़ की वास्तविक सीमा बदलती है।

**क्या पैराग्राफ़ के निर्देशांक निर्यात किए गए चित्र में पिक्सेल में विश्वसनीय रूप से मैप किए जा सकते हैं?**

हाँ। पॉइंट्स को पिक्सेल में इस सूत्र से बदलें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग या निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल इनहेरिटेंस को ध्यान में रखकर मैं "प्रभावी" पैराग्राफ़ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करूँ?**

इसके लिए [effective paragraph formatting data structure](/slides/hi/cpp/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL आदि के लिए अंतिम संगठित मान लौटाता है।