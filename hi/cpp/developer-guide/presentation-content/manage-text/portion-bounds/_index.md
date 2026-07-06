---
title: C++ में प्रस्तुतियों से टेक्स्ट पोर्शन सीमाएँ प्राप्त करें
linktitle: पोर्शन सीमाएँ
type: docs
weight: 47
url: /hi/cpp/portion-bounds/
keywords:
- टेक्स्ट पोर्शन सीमाएँ
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट पोर्शन सीमाएँ कैसे प्राप्त करें, जानिए।"
---
## **परिचय**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर टेक्स्ट के एक विशिष्ट भाग का प्रतिनिधित्व करता है और आपको उस भाग के साथ आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जा सकता है जब आपको टेक्स्ट भाग की सीमाओं को प्राप्त करना हो, केवल पैराग्राफ के एक हिस्से पर फॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

यह लेख दिखाता है कि कैसे [IPortion::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getrect/) का उपयोग करके पोर्शन का बाउंडिंग आयत प्राप्त किया जाए। यह यह भी दर्शाता है कि कैसे [IPortion::GetCoordinates](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getcoordinates/) का उपयोग करके पोर्शन की शुरुआत के निर्देशांक प्राप्त किए जाएँ। अतिरिक्त रूप से, यह आम पोर्शन-सम्बन्धी परिदृश्यों को उजागर करता है, जैसे कि एकल टेक्स्ट भाग पर हाइपरलिंक लागू करना, समझना कि फॉर्मेटिंग पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से कैसे हल होती है, और जब निर्दिष्ट फ़ॉन्ट अनुपलब्ध हो तो कैसे संभालें।

## **एक टेक्स्ट पोर्शन की सीमाएँ प्राप्त करें**

एक टेक्स्ट पोर्शन का बाउंडिंग आयत प्राप्त करने के लिए [IPortion::GetRect](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getrect/) का उपयोग करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto rectangle = portion->GetRect();
        auto rectangleX = rectangle.get_X();
        auto rectangleY = rectangle.get_Y();
        auto rectangleWidth = rectangle.get_Width();
        auto rectangleHeight = rectangle.get_Height();

        Console::WriteLine(u"X = {0}; Y = {1}; Width = {2}; Height = {3}", rectangleX, rectangleY, rectangleWidth, rectangleHeight);
    }
}

presentation->Dispose();
```

## **एक टेक्स्ट पोर्शन के निर्देशांक प्राप्त करें**

एक टेक्स्ट पोर्शन की शुरुआत के निर्देशांक प्राप्त करने के लिए [IPortion::GetCoordinates](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/getcoordinates/) का उपयोग करें:

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraphs = shape->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    auto portions = paragraph->get_Portions();
    for (const auto& portion : portions)
    {
        auto point = portion->GetCoordinates();
        auto pointX = point.get_X();
        auto pointY = point.get_Y();

        Console::WriteLine(u"X = {0}; Y = {1}", pointX, pointY);
    }
}

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर केवल टेक्स्ट के भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप [एक हाइपरलिंक असाइन कर सकते हैं](/slides/hi/cpp/manage-hyperlinks/) एक व्यक्तिगत पोर्शन को; केवल वही भाग क्लिक करने योग्य होगा, न कि पूरा पैराग्राफ।

**स्टाइल इनहेरिटेंस कैसे काम करती है: पोर्शन क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

पोर्शन-स्तर की प्रॉपर्टीज़ का सबसे उच्च प्रेसेडेंस होता है। यदि कोई प्रॉपर्टी [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) पर सेट नहीं है, तो Aspose.Slides इसे [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) से लेती है। यदि वहाँ भी सेट नहीं है, तो Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) या [theme](https://reference.aspose.com/slides/hi/cpp/aspose.slides.theme/theme/) स्टाइल का उपयोग करता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर अनुपलब्ध हो तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/cpp/font-selection-sequence/) लागू होते हैं। टेक्स्ट का पुनः प्रवाह हो सकता है: मेट्रिक्स, हाइफ़नेशन, और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपैरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, टेक्स्ट रंग, फ़िल और ट्रांसपैरेंसी को [IPortion](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iportion/) स्तर पर पड़ोसी भागों से अलग रखा जा सकता है।