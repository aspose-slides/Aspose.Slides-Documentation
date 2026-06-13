---
title: .NET में प्रेजेंटेशन से उन्नत पाठ निष्कर्षण
linktitle: पाठ निकालें
type: docs
weight: 90
url: /hi/net/extract-text-from-presentation/
keywords:
- पाठ निकालें
- स्लाइड से पाठ निकालें
- प्रेजेंटेशन से पाठ निकालें
- PowerPoint से पाठ निकालें
- OpenDocument से पाठ निकालें
- PPT से पाठ निकालें
- PPTX से पाठ निकालें
- ODP से पाठ निकालें
- पाठ पुनः प्राप्त करें
- स्लाइड से पाठ पुनः प्राप्त करें
- प्रेजेंटेशन से पाठ पुनः प्राप्त करें
- PowerPoint से पाठ पुनः प्राप्त करें
- OpenDocument से पाठ पुनः प्राप्त करें
- PPT से पाठ पुनः प्राप्त करें
- PPTX से पाठ पुनः प्राप्त करें
- ODP से पाठ पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशनों से जल्दी पाठ निकालें। समय बचाने के लिए हमारे सरल, चरण-दर-चरण गाइड का पालन करें।"
---
## **समीक्षा**

प्रेजेंटेशन से पाठ निकालना एक सामान्य लेकिन आवश्यक कार्य है उन डेवलपर्स के लिए जो स्लाइड सामग्री के साथ काम करते हैं। चाहे आप Microsoft PowerPoint फ़ाइलों को PPT या PPTX फ़ॉर्मेट में संभाल रहे हों, या OpenDocument प्रेजेंटेशन्स (ODP) के साथ काम कर रहें हों, टेक्स्ट डेटा तक पहुँच और उसे प्राप्त करना विश्लेषण, स्वचालन, अनुक्रमण या सामग्री माइग्रेशन के उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फ़ॉर्मेट—PPT, PPTX और ODP—से प्रभावी ढंग से पाठ निकालने के लिए एक व्यापक गाइड प्रदान करता है, जिसमें Aspose.Slides for .NET का उपयोग किया गया है। आप सीखेंगे कि प्रेजेंटेशन तत्वों के माध्यम से व्यवस्थित रूप से कैसे इटररेट करें और आवश्यक पाठ सामग्री को सटीक रूप से प्राप्त करें।

## **स्लाइड से पाठ निकालें**

Aspose.Slides for .NET [Aspose.Slides.Util](https://reference.aspose.com/slides/hi/net/aspose.slides.util/) नेमस्पेस प्रदान करता है, जिसमें [SlideUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/) क्लास शामिल है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी पाठ निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड प्रदान करती है। प्रेजेंटेशन की एक स्लाइड से पाठ निकालने के लिए, [GetAllTextBoxes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextboxes/) मेथड का उपयोग करें। इस मेथड को पैरामीटर के रूप में [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) प्रकार का ऑब्जेक्ट दिया जाता है। निष्पादित होने पर, यह मेथड पूरी स्लाइड में पाठ को स्कैन करता है और [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें सभी पाठ फ़ॉर्मेटिंग बरकरार रहती है।

निम्न कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी पाठ को निकालता है:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **प्रेजेंटेशन से पाठ निकालें**

पूरे प्रेजेंटेशन से पाठ को स्कैन करने के लिए, [SlideUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/) क्लास द्वारा प्रदान किया गया [GetAllTextFrames](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextframes/) स्टैटिक मेथड उपयोग करें। यह दो पैरामीटर लेता है:

1. पहला, एक [IPresentation](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/) ऑब्जेक्ट जो उस PowerPoint या OpenDocument प्रेजेंटेशन का प्रतिनिधित्व करता है जिससे पाठ निकाला जाएगा।
1. दूसरा, एक `Boolean` मान जो यह दर्शाता है कि प्रेजेंटेशन से पाठ स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें पाठ फ़ॉर्मेटिंग जानकारी भी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन, साथ ही मास्टर स्लाइड्स, से पाठ और फ़ॉर्मेटिंग विवरण स्कैन करता है।

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **वर्गीकृत और तेज़ पाठ निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशन्स से सभी पाठ निकालने के लिए मेथड्स प्रदान करती है:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/net/aspose.slides/textextractionarrangingmode/) एनीम आर्ग्यूमेंट पाठ निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्न मानों में सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा पाठ।
- `Arranged` - पाठ उसी क्रम में व्यवस्थित होता है जैसा स्लाइड पर दर्शाया गया है।

जब गति महत्वपूर्ण हो, तो अनऑर्गनाइज़्ड मोड का उपयोग किया जा सकता है; यह ऑर्डर्ड मोड से तेज़ है।

[IPresentationText](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationtext/) प्रेजेंटेशन से निकाले गए कच्चे पाठ का प्रतिनिधित्व करता है। इसकी `SlidesText` प्रॉपर्टी [ISlideText](https://reference.aspose.com/slides/hi/net/aspose.slides/islidetext/) प्रकार के ऑब्जेक्ट्स की एरे लौटाती है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर मौजूद पाठ को दर्शाता है। [ISlideText](https://reference.aspose.com/slides/hi/net/aspose.slides/islidetext/) प्रकार के ऑब्जेक्ट में निम्न प्रॉपर्टीज़ होती हैं:

- `Text` - स्लाइड के शैप्स के भीतर का पाठ।
- `MasterText` - इस स्लाइड से जुड़े मास्टर स्लाइड के शैप्स के भीतर का पाठ।
- `LayoutText` - इस स्लाइड से जुड़े लेआउट स्लाइड के शैप्स के भीतर का पाठ।
- `NotesText` - नोट्स स्लाइड के शैप्स के भीतर का पाठ।
- `CommentsText` - इस स्लाइड से जुड़े टिप्पणी में मौजूद पाठ।

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**Aspose.Slides बड़े प्रेजेंटेशन को पाठ निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यह [बड़े प्रेजेंटेशन](/slides/hi/net/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशन के भीतर तालिकाओं और चार्ट्स से भी पाठ निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड तत्वों, जिसमें तालिकाएँ और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं, से पाठ निकाल सकता है, ताकि आप सामान्य प्रेजेंटेशन संरचनाओं में पाठ्य सामग्री तक पहुँच और विश्लेषण कर सकें।

**क्या प्रेजेंटेशन से पाठ निकालने के लिए मुझे Aspose.Slides का विशेष लाइसेंस चाहिए?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके पाठ निकाल सकते हैं, हालांकि इसमें [कुछ प्रतिबंध](/slides/hi/net/licensing/) होंगे, जैसे सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेजेंटेशन को संभालने के लिए पूर्ण लाइसेंस खरीदना अनुशंसित है।