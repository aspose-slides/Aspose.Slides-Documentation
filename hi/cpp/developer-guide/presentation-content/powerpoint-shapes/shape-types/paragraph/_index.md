---
title: C++ प्रस्तुतियों में पैराग्राफ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/cpp/paragraph/
keywords:
- पैराग्राफ सीमाएँ
- टेक्स्ट पोर्शन सीमाएँ
- पैराग्राफ निर्देशांक
- पोर्शन निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट पोर्शन आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में पैराग्राफ और टेक्स्ट‑पोर्शन सीमाएँ कैसे प्राप्त करें, ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की पोजिशनिंग को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पैराग्राफ और टेक्स्ट पोर्शन की सीमाओं, आकार और निर्देशांक प्राप्त करने का तरीका समझाता है। यह `GetRect()` का उपयोग करके `TextFrame` में पैराग्राफ का आयत प्राप्त करने, टेबल सेल टेक्स्ट फ़्रेम के भीतर पैराग्राफ और पोर्शन के निर्देशांक प्राप्त करने, तथा माप इकाइयों, टेक्स्ट रैपिंग का सीमा पर प्रभाव, पिक्सेल परिवर्तन, और प्रभावी पैराग्राफ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ और पोर्शन के निर्देशांक प्राप्त करें**
Aspose.Slides for C++ का उपयोग करके डेवलपर्स अब TextFrame के पैराग्राफ संग्रह के भीतर Paragraph के आयताकार निर्देशांक प्राप्त कर सकते हैं। यह आपको एक पैराग्राफ के पोर्शन संग्रह के भीतर पोर्शन के निर्देशांक भी प्राप्त करने की सुविधा देता है। इस विषय में, हम एक उदाहरण की मदद से यह दिखाएंगे कि कैसे पैराग्राफ के आयताकार निर्देशांक के साथ-साथ पैराग्राफ के भीतर पोर्शन की स्थिति प्राप्त की जा सकती है।

## **पैराग्राफ के आयताकार निर्देशांक प्राप्त करें**
नया मेथड **GetRect()** जोड़ा गया है। यह पैराग्राफ की सीमा आयत प्राप्त करने की अनुमति देता है।

``` cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला एक Presentation वस्तु बनाएं
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **टेबल सेल TextFrame के भीतर पैराग्राफ और पोर्शन का आकार प्राप्त करें**
टेबल सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.portion) या [Paragraph](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.paragraph) का आकार और निर्देशांक प्राप्त करने के लिए, आप [IPortion::GetRect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) और [IParagraph::GetRect](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) मेथड का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ और टेक्स्ट पोर्शन के लिए वापस किए गए निर्देशांक किस इकाइयों में मापे जाते हैं?**  
पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स होता है। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमाओं को प्रभावित करती है?**  
हाँ। यदि [wrapping](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframeformat/set_wraptext/) को [TextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textframe/) में सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई में फिट होने के लिए टूटता है, जिससे पैराग्राफ की वास्तविक सीमाएँ बदलती हैं।

**क्या पैराग्राफ के निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**  
हाँ। पॉइंट्स को पिक्सेल में इस प्रकार बदलें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "effective" पैराग्राफ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**  
[effective paragraph formatting data structure](/slides/hi/cpp/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL आदि के लिए अंतिम समेकित मान लौटाता है।