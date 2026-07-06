---
title: ".NET में प्रस्तुतियों से टेक्स्ट भाग की सीमाएँ प्राप्त करें"
linktitle: "भाग सीमाएँ"
type: docs
weight: 47
url: /hi/net/portion-bounds/
keywords:
- "टेक्स्ट भाग सीमाएँ"
- "टेक्स्ट भाग"
- "टेक्स्ट हिस्सा"
- "टेक्स्ट निर्देशांक"
- "टेक्स्ट स्थिति"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट भाग की सीमाएँ कैसे प्राप्त करें, जानें।"
---
## **परिचय**

एक टेक्स्ट भाग पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट अंश को दर्शाता है और आपको उस अंश के साथ आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, portions का उपयोग तब किया जा सकता है जब आपको टेक्स्ट अंश की सीमाएँ प्राप्त करनी हों, पैराग्राफ के केवल भाग पर फ़ॉर्मेटिंग लागू करनी हो, या टेक्स्ट व्यवहार को अधिक विस्तृत स्तर पर नियंत्रित करना हो।

यह लेख दर्शाता है कि कैसे [IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getrect/) का उपयोग करके एक भाग का बाउंडिंग आयत प्राप्त किया जाए। यह यह भी दिखाता है कि कैसे [IPortion.GetCoordinates](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getcoordinates/) का उपयोग करके एक भाग की शुरुआत के निर्देशांक प्राप्त किए जा सकते हैं। इसके अतिरिक्त, यह सामान्य भाग‑संबंधी परिदृश्यों को उजागर करता है, जैसे एकल टेक्स्ट अंश पर हाइपरलिंक लागू करना, यह समझना कि फ़ॉर्मेटिंग भाग, पैराग्राफ, टेक्स्ट फ्रेम और थीम इनहेरिटेंस के माध्यम से कैसे हल होती है, और उन मामलों को संभालना जहाँ निर्दिष्ट फ़ॉन्ट उपलब्ध नहीं है।

## **टेक्स्ट भाग की सीमा प्राप्त करें**

[IPortion.GetRect](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getrect/) का उपयोग करके टेक्स्ट भाग का बाउंडिंग आयत प्राप्त करें:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **टेक्स्ट भाग के निर्देशांक प्राप्त करें**

[IPortion.GetCoordinates](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/getcoordinates/) का उपयोग करके टेक्स्ट भाग की शुरुआत के निर्देशांक प्राप्त करें:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**क्या मैं किसी एकल पैराग्राफ के भीतर केवल टेक्स्ट के किसी भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप [assign a hyperlink](/slides/hi/net/manage-hyperlinks/) को व्यक्तिगत भाग पर निर्धारित कर सकते हैं; केवल वही अंश क्लिक योग्य होगा, पूरी पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक भाग क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

Portion‑स्तर की प्रॉपर्टीज़ का सबसे अधिक प्रायोरिटी होता है। यदि कोई प्रॉपर्टी [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) पर सेट नहीं है, तो Aspose.Slides इसे [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) से लेता है। यदि वह भी सेट नहीं है, तो Aspose.Slides [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) या [theme](https://reference.aspose.com/slides/hi/net/aspose.slides.theme/theme/) शैली का उपयोग करता है।

**यदि भाग के लिए निर्दिष्ट फ़ॉन्ट लक्षित मशीन या सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[Font substitution rules](/slides/hi/net/font-selection-sequence/) लागू होते हैं। टेक्स्ट रीफ़्लो हो सकता है: मेट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं भाग‑विशिष्ट टेक्स्ट फ़िल ट्रांसपेरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, [IPortion](https://reference.aspose.com/slides/hi/net/aspose.slides/iportion/) स्तर पर टेक्स्ट का रंग, फ़िल और ट्रांसपेरेंसी पड़ोसियों से अलग हो सकते हैं।