---
title: .NET में प्रेजेंटेशनों से उन्नत टेक्स्ट निष्कर्षण
linktitle: टेक्स्ट निकालें
type: docs
weight: 90
url: /hi/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/hi/
keywords:
- टेक्स्ट निकालें
- स्लाइड से टेक्स्ट निकालें
- प्रेजेंटेशन से टेक्स्ट निकालें
- PowerPoint से टेक्स्ट निकालें
- OpenDocument से टेक्स्ट निकालें
- PPT से टेक्स्ट निकालें
- PPTX से टेक्स्ट निकालें
- ODP से टेक्स्ट निकालें
- टेक्स्ट पुनः प्राप्त करें
- स्लाइड से टेक्स्ट पुनः प्राप्त करें
- प्रेजेंटेशन से टेक्स्ट पुनः प्राप्त करें
- PowerPoint से टेक्स्ट पुनः प्राप्त करें
- OpenDocument से टेक्स्ट पुनः प्राप्त करें
- PPT से टेक्स्ट पुनः प्राप्त करें
- PPTX से टेक्स्ट पुनः प्राप्त करें
- ODP से टेक्स्ट पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रेजेंटेशन से जल्दी टेक्स्ट निकालें। समय बचाने के लिए हमारा सरल, चरण-दर-चरण मार्गदर्शक अनुसरण करें।"
---
## **अवलोकन**

प्रेजेंटेशन से टेक्स्ट निकालना स्लाइड सामग्री के साथ काम करने वाले डेवलपर्स के लिए एक सामान्य लेकिन आवश्यक कार्य है। चाहे आप Microsoft PowerPoint फाइलें PPT या PPTX प्रारूप में संभाल रहे हों, या OpenDocument प्रेजेंटेशन (ODP) हों, टेक्स्ट डेटा तक पहुंचना और उसे पुनर्प्राप्त करना विश्लेषण, स्वचालन, अनुक्रमण या सामग्री प्रवास उद्देश्यों के लिए महत्वपूर्ण हो सकता है।

यह लेख विभिन्न प्रेजेंटेशन फ़ॉर्मैट्स (PPT, PPTX और ODP) से टेक्स्ट को कुशलतापूर्वक निकालने के लिए Aspose.Slides for .NET का उपयोग करके एक व्यापक गाइड प्रदान करता है। आप सीखेंगे कि प्रेजेंटेशन तत्वों के माध्यम से व्यवस्थित रूप से कैसे इटरैट करें ताकि आवश्यक टेक्स्ट सामग्री को सटीक रूप से पुनः प्राप्त किया जा सके।

## **स्लाइड से टेक्स्ट निकालें**

Aspose.Slides for .NET [Aspose.Slides.Util](https://reference.aspose.com/slides/hi/net/aspose.slides.util/) नेमस्पेस प्रदान करता है, जिसमें [SlideUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/) क्लास शामिल है। यह क्लास प्रेजेंटेशन या स्लाइड से सभी टेक्स्ट निकालने के लिए कई ओवरलोडेड स्टैटिक मेथड्स प्रदान करती है। प्रेजेंटेशन में किसी स्लाइड से टेक्स्ट निकालने के लिए, आप [GetAllTextBoxes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextboxes/) मेथड का उपयोग करेंगे। यह मेथड पैरामीटर के रूप में [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) प्रकार का ऑब्जेक्ट स्वीकार करता है। चलने पर, यह मेथड पूरी स्लाइड को टेक्स्ट के लिए स्कैन करता है और [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाता है, जिसमें किसी भी टेक्स्ट फ़ॉर्मेटिंग को संरक्षित किया जाता है।

निम्न कोड स्निपेट प्रेजेंटेशन की पहली स्लाइड से सभी टेक्स्ट निकालता है:

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

## **प्रेजेंटेशन से टेक्स्ट निकालें**

पूरे प्रेजेंटेशन से टेक्स्ट स्कैन करने के लिए, आप [SlideUtil](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/) क्लास द्वारा एक्सपोज़ किए गए [GetAllTextFrames](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextframes/) स्टैटिक मेथड का उपयोग कर सकते हैं। यह दो पैरामीटर स्वीकार करता है:

1. सबसे पहले, एक [IPresentation](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/) ऑब्जेक्ट जो PowerPoint या OpenDocument प्रेजेंटेशन का प्रतिनिधित्व करता है, जिससे टेक्स्ट निकाला जाएगा।
2. दूसरा, एक `Boolean` मान जो यह दर्शाता है कि प्रेजेंटेशन से टेक्स्ट स्कैन करते समय मास्टर स्लाइड्स को शामिल किया जाना चाहिए या नहीं।

यह मेथड [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्रकार के ऑब्जेक्ट्स की एक एरे वापस करता है, जिसमें टेक्स्ट फ़ॉर्मेटिंग जानकारी शामिल होती है। नीचे दिया गया कोड प्रेजेंटेशन, सहित मास्टर स्लाइड्स, से टेक्स्ट और फ़ॉर्मेटिंग विवरण स्कैन करता है:

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

## **श्रेणीबद्ध और तेज़ टेक्स्ट निष्कर्षण**

[PresentationFactory](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/) क्लास भी प्रेजेंटेशनों से सभी टेक्स्ट निकालने के लिए मेथड्स प्रदान करती है:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hi/net/aspose.slides/textextractionarrangingmode/) एनीम आर्ग्यूमेंट टेक्स्ट निष्कर्षण परिणाम को व्यवस्थित करने के मोड को दर्शाता है और इसे निम्नलिखित मानों में सेट किया जा सकता है:
- `Unarranged` - स्लाइड पर उसकी स्थिति की परवाह किए बिना कच्चा टेक्स्ट।
- `Arranged` - टेक्स्ट उसी क्रम में व्यवस्थित होता है जैसा कि स्लाइड पर है।

जब गति महत्वपूर्ण हो तो अनएरेन्ड मोड का उपयोग किया जा सकता है; यह एरेन्ड मोड की तुलना में तेज़ है।

[IPresentationText](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationtext/) प्रेजेंटेशन से निकाले गए कच्चे टेक्स्ट का प्रतिनिधित्व करती है। इसकी `SlidesText` प्रॉपर्टी [ISlideText](https://reference.aspose.com/slides/hi/net/aspose.slides/islidetext/) प्रकार के ऑब्जेक्ट्स की एक एरे लौटाती है। प्रत्येक ऑब्जेक्ट संबंधित स्लाइड पर टेक्स्ट का प्रतिनिधित्व करता है। [ISlideText](https://reference.aspose.com/slides/hi/net/aspose.slides/islidetext/) प्रकार के ऑब्जेक्ट में निम्नलिखित प्रॉपर्टीज़ हैं:

- `Text` - स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `MasterText` - इस स्लाइड से जुड़ी मास्टर स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `LayoutText` - इस स्लाइड से जुड़ी लेआउट स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `NotesText` - नोट्स स्लाइड के शैप्स के भीतर का टेक्स्ट।
- `CommentsText` - इस स्लाइड से जुड़े टिप्पणी में मौजूद टेक्स्ट।

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

**Aspose.Slides बड़े प्रेजेंटेशनों को टेक्स्ट निष्कर्षण के दौरान कितनी तेज़ी से प्रोसेस करता है?**

Aspose.Slides उच्च प्रदर्शन के लिए अनुकूलित है और यहाँ तक कि [बड़े प्रेजेंटेशन](/slides/hi/net/open-presentation/) को भी प्रोसेस कर सकता है, जिससे यह रीयल‑टाइम या बल्क प्रोसेसिंग परिदृश्यों के लिए उपयुक्त बनता है।

**क्या Aspose.Slides प्रेजेंटेशनों के भीतर तालिकाओं और चार्ट्स से टेक्स्ट निकाल सकता है?**

हां। Aspose.Slides कई स्लाइड तत्वों, जिसमें तालिकाएँ और चार्ट‑संबंधित ऑब्जेक्ट्स शामिल हैं, से टेक्स्ट निकाल सकता है, जिससे आप सामान्य प्रेजेंटेशन संरचनाओं में टेक्स्ट सामग्री तक पहुंच और उसका विश्लेषण कर सकते हैं।

**क्या प्रेजेंटेशन से टेक्स्ट निकालने के लिए मुझे विशेष Aspose.Slides लाइसेंस चाहिए?**

आप Aspose.Slides के फ्री ट्रायल संस्करण का उपयोग करके टेक्स्ट निकाल सकते हैं, हालांकि इसमें [कुछ सीमाएँ](/slides/hi/net/licensing/) हैं, जैसे कि केवल सीमित संख्या में स्लाइड्स को प्रोसेस करना। अनलिमिटेड उपयोग और बड़े प्रेजेंटेशन को संभालने के लिए पूर्ण लाइसेंस खरीदना अनुशंसित है।