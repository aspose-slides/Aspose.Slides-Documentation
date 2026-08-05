---
title: "C++ में प्रेज़ेंटेशनों से उन्नत टेक्स्ट निष्कर्षण"
linktitle: "टेक्स्ट निकालें"
type: docs
weight: 90
url: /hi/cpp/extract-text-from-presentation/
aliases:
  - /cpp/प्रेज़ेंटेशन-से-टेक्स्ट-निकालना/
keywords:
  - "टेक्स्ट निकालें"
  - "स्लाइड से टेक्स्ट निकालें"
  - "प्रेज़ेंटेशन से टेक्स्ट निकालें"
  - "PowerPoint से टेक्स्ट निकालें"
  - "OpenDocument से टेक्स्ट निकालें"
  - "PPT से टेक्स्ट निकालें"
  - "PPTX से टेक्स्ट निकालें"
  - "ODP से टेक्स्ट निकालें"
  - "टेक्स्ट पुनः प्राप्त करें"
  - "स्लाइड से टेक्स्ट पुनः प्राप्त करें"
  - "प्रेज़ेंटेशन से टेक्स्ट पुनः प्राप्त करें"
  - "PowerPoint से टेक्स्ट पुनः प्राप्त करें"
  - "OpenDocument से टेक्स्ट पुनः प्राप्त करें"
  - "PPT से टेक्स्ट पुनः प्राप्त करें"
  - "PPTX से टेक्स्ट पुनः प्राप्त करें"
  - "ODP से टेक्स्ट पुनः प्राप्त करें"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रेज़ेंटेशन"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument प्रेज़ेंटेशनों से शीघ्रता से टेक्स्ट निकालें। समय बचाने के लिए हमारे सरल, चरण-दर-चरण गाइड का पालन करें।"
---
## **अवलोकन**

प्रेज़ेंटेशन से टेक्स्ट निकालना स्लाइड सामग्री के साथ काम करने वाले डेवलपर्स के लिए एक सामान्य लेकिन आवश्यक कार्य है। चाहे आप Microsoft PowerPoint फ़ाइलों (PPT या PPTX फ़ॉर्मेट) के साथ काम कर रहे हों, या OpenDocument प्रेज़ेंटेशन (ODP) के साथ, टेक्स्ट डेटा तक पहुँच और उसे प्राप्त करना विश्लेषण, स्वचालन, अनुक्रमण या सामग्री माइग्रेशन उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेज़ेंटेशन फ़ॉर्मेट (PPT, PPTX और ODP) से टेक्स्ट को प्रभावी ढंग से निकालने के लिए एक व्यापक गाइड प्रदान करता है, जिसमें Aspose.Slides for C++ का उपयोग किया गया है। आप सीखेंगे कि प्रेज़ेंटेशन तत्वों के माध्यम से व्यवस्थित रूप से कैसे इटरेट करें ताकि आपको आवश्यक टेक्स्ट सामग्री सटीक रूप से प्राप्त हो सके।

## **स्लाइड से टेक्स्ट निकालना**

Aspose.Slides for C++ प्रदान करता है [Aspose.Slides.Util](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/) नेमस्पेस, जिसमें [SlideUtil](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/) क्लास शामिल है। यह क्लास प्रेज़ेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड्स प्रदान करती है। प्रेज़ेंटेशन की किसी स्लाइड से टेक्स्ट निकालने के लिए, आप [GetAllTextBoxes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextboxes/) मेथड का उपयोग कर सकते हैं। यह मेथड पैरामीटर के रूप में [IBaseSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/) टाइप का एक ऑब्जेक्ट स्वीकार करता है। जब यह निष्पादित होता है, तो यह पूरी स्लाइड को टेक्स्ट के लिए स्कैन करता है और [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) टाइप के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें सभी टेक्स्ट फ़ॉर्मेटिंग संरक्षित रहती है।

निम्न कोड स्निपेट प्रेज़ेंटेशन की पहली स्लाइड से सभी टेक्स्ट को निकालता है:

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

## **प्रेज़ेंटेशन से टेक्स्ट निकालना**

पूरे प्रेज़ेंटेशन से टेक्स्ट स्कैन करने के लिए, आप [SlideUtil](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/) क्लास द्वारा प्रदत्त [GetAllTextFrames](https://reference.aspose.com/slides/hi/cpp/aspose.slides.util/slideutil/getalltextframes/) स्टैटिक मेथड का उपयोग कर सकते हैं। यह दो पैरामीटर स्वीकार करता है:

1. पहला, एक [IPresentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेज़ेंटेशन को दर्शाता है, जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `Boolean` मान जो यह दर्शाता है कि टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [ITextFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/itextframe/) टाइप के ऑब्जेक्ट्स की एरे लौटाता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी शामिल होती है। नीचे दिया गया कोड प्रेज़ेंटेशन, जिसमें मास्टर स्लाइड्स भी शामिल हैं, से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है:

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

## **श्रेणीकृत और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentationfactory/) क्लास भी प्रेज़ेंटेशन से सभी टेक्स्ट निकालने के मेथड्स प्रदान करता है:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/textextractionarrangingmode/) एनेम आर्ग्यूमेंट टेक्स्ट निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट उसी क्रम में व्यवस्थित है जैसा स्लाइड पर है।

जब गति महत्वपूर्ण होती है तो अनऐरेन्ज्ड मोड का उपयोग किया जा सकता है; यह ऐरेन्ज्ड मोड की तुलना में तेज़ है।

[IPresentationText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ipresentationtext/) प्रेज़ेंटेशन से निकाले गए कच्चे टेक्स्ट का प्रतिनिधित्व करता है। इसका `get_SlidesText()` मेथड [ISlideText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidetext/) टाइप के ऑब्जेक्ट्स की एरे लौटाता है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर मौजूद टेक्स्ट का प्रतिनिधित्व करता है। [ISlideText](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islidetext/) टाइप के ऑब्जेक्ट में निम्न मेथड्स होते हैं:

- `get_Text()` - स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_MasterText()` - इस स्लाइड से जुड़े मास्टर स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_LayoutText()` - इस स्लाइड से जुड़े लेआउट स्लाइड के शेप्स के भीतर का टेक्स्ट।
- `get_NotesText()` - इस स्लाइड से जुड़े नोट्स स्लाइड के शेप्स के भीतर का टेक्स्ट।
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

**Aspose.Slides बड़े प्रेज़ेंटेशन को टेक्स्ट निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए ऑप्टिमाइज़्ड है और यहाँ तक कि [बड़े प्रेज़ेंटेशन](/slides/hi/cpp/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बुल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेज़ेंटेशन के भीतर तालिकाओं और चार्ट्स से भी टेक्स्ट निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड तत्वों, जिसमें तालिकाएँ और चार्ट‑से संबंधित ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, ताकि आप सामान्य प्रेज़ेंटेशन संरचनाओं में मौजूद टेक्स्ट सामग्री तक पहुँच सकें और उसका विश्लेषण कर सकें।

**क्या प्रेज़ेंटेशन से टेक्स्ट निकालने के लिए मुझे Aspose.Slides का कोई विशेष लाइसेंस चाहिए?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/cpp/licensing/) होंगी, जैसे कि केवल सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेज़ेंटेशन को हैंडल करने के लिए पूर्ण लाइसेंस खरीदना अनुशंसित है।