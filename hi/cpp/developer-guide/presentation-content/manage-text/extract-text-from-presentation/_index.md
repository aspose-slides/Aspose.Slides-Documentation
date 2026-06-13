---
title: C++ में प्रस्तुतियों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/cpp/extract-text-from-presentation/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट प्राप्त करें
- स्लाइड से टेक्स्ट प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट प्राप्त करें
- PowerPoint से टेक्स्ट प्राप्त करें
- OpenDocument से टेक्स्ट प्राप्त करें
- PPT से टेक्स्ट प्राप्त करें
- PPTX से टेक्स्ट प्राप्त करें
- ODP से टेक्स्ट प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से तेज़ी से टेक्स्ट निकालें। समय बचाने के लिए हमारी सरल, चरण‑दर‑चरण गाइड का पालन करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना एक सामान्य लेकिन आवश्यक कार्य है उन डेवलपर्स के लिए जो स्लाइड सामग्री के साथ काम करते हैं। चाहे आप Microsoft PowerPoint फ़ाइलों को PPT या PPTX फ़ॉर्मेट में संभाल रहे हों, या OpenDocument प्रेजेंटेशन (ODP) के साथ, टेक्स्ट डेटा तक पहुँच और उसे प्राप्त करना विश्लेषण, ऑटोमेशन, इंडेक्सिंग या कंटेंट माइग्रेशन उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फ़ॉर्मेट्स, जैसे PPT, PPTX, और ODP, से टेक्स्ट को प्रभावी तरीके से निकालने की व्यापक गाइड प्रदान करता है, Aspose.Slides for C++ का उपयोग करके। आप सीखेंगे कि कैसे प्रेजेंटेशन के तत्वों के माध्यम से प्रणालीबद्ध रूप से इटररेट करके आवश्यक टेक्स्ट कंटेंट को सटीक रूप से प्राप्त किया जाए।

## **स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for C++ [Aspose.Slides.Util](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/) नेमस्पेस प्रदान करता है, जिसमें [SlideUtil](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/) क्लास शामिल है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टेटिक मेथड्स को एक्सपोज़ करती है। प्रेजेंटेशन में किसी स्लाइड से टेक्स्ट निकालने के लिए, [GetAllTextBoxes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextboxes/) मेथड का उपयोग करें। यह मेथड प्रकार [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) के एक ऑब्जेक्ट को पैरामीटर के रूप में स्वीकार करता है। निष्पादित होने पर, मेथड पूरे स्लाइड को टेक्स्ट के लिए स्कैन करता है और प्रकार [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें कोई भी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निम्न कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट निकालता है:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **प्रेजेंटेशन से टेक्स्ट निकालें**

पूरे प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/) क्लास द्वारा एक्सपोज़ किया गया [GetAllTextFrames](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextframes/) स्टेटिक मेथड उपयोग करें। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [IPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन का प्रतिनिधित्व करता है जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `Boolean` मान जो दर्शाता है कि प्रेजेंटेशन से टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड प्रकार [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) के ऑब्जेक्ट्स की एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन और मास्टर स्लाइड्स दोनों से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **वर्गीकृत और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशन से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करता है:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textextractionarrangingmode/) एन्डम आर्ग्यूमेंट टेक्स्ट निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में से सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट उसी क्रम में व्यवस्थित है जैसा कि स्लाइड पर है।

जब गति महत्वपूर्ण हो तो अनऐरेन्ज्ड मोड का उपयोग किया जा सकता है; यह एरेन्ज्ड मोड से तेज़ है।

[IPresentationText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट का प्रतिनिधित्व करता है। इसका `get_SlidesText()` मेथड प्रकार [ISlideText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidetext/) के ऑब्जेक्ट्स की एरे लौटाता है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर टेक्स्ट का प्रतिनिधित्व करता है। प्रकार [ISlideText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidetext/) के ऑब्जेक्ट में निम्न मेथड्स होते हैं:

- `get_Text()` - स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_MasterText()` - इस स्लाइड से संबंधित मास्टर स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_LayoutText()` - इस स्लाइड से संबंधित लेआउट स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_NotesText()` - इस स्लाइड से संबंधित नोट्स स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_CommentsText()` - इस स्लाइड से जुड़े कमेंट्स के भीतर का टेक्स्ट।

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बड़े प्रेजेंटेशन को टेक्स्ट निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए ऑप्टिमाइज़्ड है और यहाँ तक कि [बड़े प्रेजेंटेशन](/slides/hi/cpp/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशन के भीतर तालिकाओं और चार्ट्स से टेक्स्ट निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड एलिमेंट्स, जिसमें टेबल्स और चार्ट‑संबंधी ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, जिससे आप सामान्य प्रेजेंटेशन संरचनाओं में टेक्स्ट सामग्री तक पहुँच और विश्लेषण कर सकते हैं।

**क्या प्रेजेंटेशन से टेक्स्ट निकालने के लिए मुझे Aspose.Slides लाइसेंस की आवश्यकता है?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/cpp/licensing/) होंगी, जैसे सीमित संख्या में स्लाइड्स को प्रोसेस करना। पूर्ण लाइसेंस खरीदना अनलिमिटेड उपयोग और बड़े प्रेजेंटेशन को संभालने के लिए अनुशंसित है।