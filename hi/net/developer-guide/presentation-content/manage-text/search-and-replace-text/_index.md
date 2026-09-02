---
title: PowerPoint प्रस्तुतियों में .NET के साथ टेक्स्ट खोजें और बदलें
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/net/search-and-replace-text/
keywords:
- टेक्स्ट खोजें
- टेक्स्ट हाइलाइट करें
- टेक्स्ट बदलें
- रेगुलर एक्सप्रेशन
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में टेक्स्ट खोजें, हाइलाइट करें और बदलें, साथ ही Aspose.Slides for .NET के साथ प्रत्येक मिलान एकत्रित करें।"
---
## **परिचय**

Aspose.Slides for .NET एक व्यक्तिगत टेक्स्ट फ्रेम या पूरी प्रस्तुति में टेक्स्ट खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन परिणाम कॉलबैक के माध्यम से प्रत्येक मिलान के बारे में एप्लिकेशन को सूचित भी कर सकता है। इससे प्रस्तुति को अपडेट करने के साथ‑साथ मिले‑जुले टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम और स्लाइड संख्या सहित एक ऑडिट ट्रेल बनाना संभव हो जाता है।

ये क्षमताएँ समीक्षाओं, रेडैक्शन, शब्दावली जाँच, टेम्पलेट सफाई और स्वचालित रिपोर्टिंग कार्यप्रवाहों में उपयोगी होती हैं।

निम्न पहले उदाहरणों में, हम “sample.pptx” नाम की फ़ाइल का उपयोग करते हैं, जिसमें पहले स्लाइड पर एकल टेक्स्ट बॉक्स है और उसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

## **खोज सीमा चुनें**

[ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) पर मेथड्स का उपयोग करके ऑपरेशन को एक टेक्स्ट फ्रेम तक सीमित किया जा सकता है। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) पर मेथड्स का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट को प्रोसेस किया जा सकता है।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरी प्रस्तुति |
|---|---|---|
| लिटरल टेक्स्ट को हाइलाइट करें | [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlighttext/) |
| रेग्युलर‑एकस्प्रेशन मिलानों को हाइलाइट करें | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlightregex/) |
| लिटरल टेक्स्ट को बदलें | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replacetext/) |
| रेग्युलर‑एकस्प्रेशन मिलानों को बदलें | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replaceregex/) |

## **टेक्स्ट मिलान को कॉन्फ़िगर करें**

लिटरल‑टेक्स्ट ऑपरेशन्स के लिए, मिलान को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/wholewordsonly/) मिलानों को पूर्ण शब्दों तक सीमित करता है।
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/casesensitive/) यह निर्धारित करता है कि अक्षर‑केस मेल खाना चाहिए या नहीं।
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/includenotes/) प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशन्स में स्लाइड नोट्स को शामिल करता है।

रेग्युलर‑एकस्प्रेशन ऑपरेशन्स .NET `Regex` का उपयोग करते हैं, इसलिए केस‑संवेदनशीलता और शब्द सीमाएँ जैसी मिलान नियम अभिव्यक्ति और उसके विकल्पों द्वारा परिभाषित होते हैं।

## **कॉलबैक के साथ मिलान जानकारी एकत्र करें**

प्रत्येक मिलान के लिए सूचनाएँ प्राप्त करने हेतु [IFindResultCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/) लागू करें। इसका [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/foundresult/) मेथड संबंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मिला‑हुआ टेक्स्ट और मिलान स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड संख्या प्राप्त नहीं करता। नीचे दिया गया कार्यान्वयन इसे पैरेंट स्लाइड से निकालता है और स्लाइड नोट्स में मिलने वाले टेक्स्ट को भी संभालता है। एक nullable स्लाइड संख्या समान परिणाम मॉडल को अन्य स्लाइड प्रकारों के साथ जुड़े टेक्स्ट को दर्शाने की अनुमति देती है।

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

प्रतिस्थापन ऑपरेशन्स के लिए, `FoundText` मूल मिला‑हुआ टेक्स्ट रखता है, इसलिए कॉलबैक ठीक‑ठीक रिकॉर्ड कर सकता है कि कौन‑से शब्द बदले गये।

## **टेक्स्ट को हाइलाइट करें**

एक टेक्स्ट फ्रेम में लिटरल‑टेक्स्ट मिलानों को हाइलाइट करने के लिए [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/) मेथड का उपयोग करें। खोज को नियंत्रित करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/) पास करें और मिलान विवरण एकत्र करने के लिए कॉलबैक प्रदान करें।

नीचे का कोड उदाहरण सभी **"try"** अक्षरों की घटनाओं को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें अपने मिलानों को उसी कॉलबैक को रिपोर्ट करती हैं।

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Get the first shape from the first slide.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Highlight every occurrence of "try" in the text frame.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Highlight only the complete word "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

परिणाम:

![हाइलाइटेड टेक्स्ट](highlighted_text.png)

## **रेग्युलर एक्सप्रेशन के साथ टेक्स्ट को हाइलाइट करें**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/) मेथड रेग्युलर एक्सप्रेशन द्वारा पाए गये टेक्स्ट मिलानों को एक टेक्स्ट फ्रेम में हाइलाइट करता है।

निम्न कोड सभी सात या अधिक अक्षर वाले शब्दों को हाइलाइट करता है और प्रत्येक मिलान को एकत्र करता है:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

परिणाम:

![रेग्युलर एक्सप्रेशन का उपयोग करके हाइलाइटेड टेक्स्ट](highlighted_text_using_regex.png)

## **प्रीज़ेंटेशन भर में टेक्स्ट को हाइलाइट करें**

[Presentation.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlighttext/) और [Presentation.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlightregex/) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेम को खोजें। नीचे का उदाहरण एक लिटरल शब्द और सभी ई‑मेल पतों को हाइलाइट करता है, जबकि दो खोजों के लिए अलग‑अलग परिणाम संग्रह रखता है।

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **टेक्स्ट फ्रेम में टेक्स्ट को बदलें**

लिटरल टेक्स्ट के लिए [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) और पैटर्न‑आधारित प्रतिस्थापन के लिए [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम के भीतर मिले‑हुए टेक्स्ट को अपडेट करते हैं, जिससे आस‑पास के फ़ॉर्मेटिंग को फिर से बनाना नहीं पड़ता।

निम्न उदाहरण एक वर्तनी रूप को मानकीकृत करता है और फिर संस्करण लेबल बदलता है। वही कॉलबैक दोनों ऑपरेशन्स द्वारा मिले‑हुए मूल शब्दों को रिकॉर्ड करता है।

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को स्पैन करता है, तो आउटपुट की जाँच करके तय करें कि प्रतिस्थापन टेक्स्ट पर कौन‑सी फ़ॉर्मेटिंग लागू होनी चाहिए।

## **प्रीज़ेंटेशन भर में टेक्स्ट को बदलें**

[Presentation.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replacetext/) और [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replaceregex/) का उपयोग करके समान ऑपरेशन्स पूरे प्रेज़ेंटेशन पर लागू करें। यह टेम्पलेट सफाई, शब्दावली अपडेट और रेडैक्शन के लिए उपयोगी है।

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **रिपोर्टिंग के लिए मिलानों को समूहित करें**

चूँकि प्रत्येक परिणाम अपनी स्लाइड संख्या और टेक्स्ट फ्रेम संग्रहीत करता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा कार्यप्रवाहों के लिये मिलानों को समूहित कर सकते हैं। नीचे का उदाहरण पहले स्लाइड के अनुसार और फिर टेक्स्ट फ्रेम के अनुसार एकत्रित परिणामों को समूहित करता है:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी प्रस्तुति के बजाय केवल एक टेक्स्ट बॉक्स को कैसे खोजूँ?**

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/), या [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) कॉल करें। प्रस्तुति‑स्तर के मेथड्स सभी लागू टेक्स्ट फ्रेम को प्रोसेस करते हैं।

**मैं पूर्ण शब्दों को सही कैपिटलाइज़ेशन के साथ कैसे मिलाऊँ?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/wholewordsonly/) और [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/casesensitive/) को `true` सेट करें, और विकल्पों को लिटरल‑टेक्स्ट हाइलाइटिंग या रिप्लेसमेंट मेथड में पास करें। रेग्युलर एक्सप्रेशन्स के लिए, शब्द सीमाएँ और केस‑संवेदनशीलता को .NET `Regex` में परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स में टेक्स्ट को शामिल कर सकते हैं?**

हाँ। प्रस्तुति‑स्तर के लिटरल‑टेक्स्ट ऑपरेशन के दौरान [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/includenotes/) को `true` सेट करें। ऊपर दिखाया गया कॉलबैक कार्यान्वयन नोट्स स्लाइड में मिलान को उसके पैरेंट स्लाइड संख्या से मैप करता है।

**मैं बिना प्रस्तुति को दोबारा स्कैन किए रिपोर्ट कैसे बनाऊँ?**

हाइलाइटिंग या प्रतिस्थापन ऑपरेशन में एक [IFindResultCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/) कार्यान्वयन पास करें। कॉलबैक ऑपरेशन चलने के दौरान प्रत्येक मिलान प्राप्त करता है, जिससे एप्लिकेशन स्रोत टेक्स्ट, मिला‑हुआ टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और निकाली गई स्लाइड संख्या को बाद में समूहित या निर्यात करने के लिए सहेज सकता है।

**क्या टेक्स्ट को बदलने से उसका फ़ॉर्मेटिंग बरकरार रहता है?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) और [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) मौजूदा टेक्स्ट फ्रेम के भीतर मिले‑हुए टेक्स्ट को संशोधित करते हैं और आस‑पास के भागों के फ़ॉर्मेटिंग को बरकरार रखते हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेटिंग वाले भागों को कवर करता है, तो परिणाम की जाँच करके सुनिश्चित करें कि प्रतिस्थापन इच्छित शैली का उपयोग करता है।