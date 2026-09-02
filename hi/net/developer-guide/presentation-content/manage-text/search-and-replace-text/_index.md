---
title: PowerPoint प्रस्तुतियों में टेक्स्ट खोजें और बदलें (.NET में)
linktitle: टेक्स्ट खोजें और बदलें
type: docs
weight: 55
url: /hi/net/search-and-replace-text/
keywords:
- टेक्स्ट खोज
- टेक्स्ट हाइलाइट
- टेक्स्ट प्रतिस्थापन
- नियमित अभिव्यक्ति
- परिणाम कॉलबैक
- टेक्स्ट फ्रेम
- ऑडिट रिपोर्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में टेक्स्ट को खोजें, हाइलाइट करें और बदलें, तथा प्रत्येक मिलान को एकत्र करें।"
---
## **सारांश**

Aspose.Slides for .NET एकल टेक्स्ट फ्रेम या पूरी प्रस्तुति में टेक्स्ट को खोज, हाइलाइट और बदल सकता है। प्रत्येक ऑपरेशन प्रत्येक मिलान के बारे में परिणाम कॉलबैक के माध्यम से एप्लीकेशन को सूचित कर सकता है। इससे प्रस्तुति को अपडेट करना और मिलते टेक्स्ट, उसका संदर्भ, स्थिति, टेक्स्ट फ्रेम और स्लाइड नंबर सहित ऑडिट ट्रेल बनाना संभव हो जाता है।

इन क्षमताओं का उपयोग समीक्षा, रेडैक्शन, शब्दावली जांच, टेम्पलेट सफ़ाई और स्वचालित रिपोर्टिंग वर्कफ़्लोज़ के लिए किया जा सकता है।

नीचे पहले उदाहरणों में, हम “sample.pptx” फ़ाइल का उपयोग करते हैं, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है और उसमें निम्नलिखित टेक्स्ट है:

![नमूना टेक्स्ट](sample_text.png)

## **खोज सीमा चुनें**

एक ऑपरेशन को केवल एक टेक्स्ट फ्रेम तक सीमित करने के लिए [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) पर मेथड्स का उपयोग करें। सभी लागू टेक्स्ट को प्रोसेस करने के लिए प्रस्तुति-स्तर पर [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) पर मेथड्स का उपयोग करें।

| ऑपरेशन | एक टेक्स्ट फ्रेम | पूरा प्रस्तुति |
|---|---|---|
| शाब्दिक पाठ को हाइलाइट करें | [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlighttext/) |
| नियमित अभिव्यक्ति मेल को हाइलाइट करें | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlightregex/) |
| शाब्दिक पाठ को बदलें | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replacetext/) |
| नियमित अभिक्‍त्यात्मक मेल को बदलें | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replaceregex/) |

## **पाठ मिलान कॉन्फ़िगर करें**

शाब्दिक‑टेक्स्ट ऑपरेशनों के लिए, मिलान को नियंत्रित करने के लिए [TextSearchOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/) का उपयोग करें:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/wholewordsonly/) केवल पूर्ण शब्दों के मिलान को सीमित करता है।
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/casesensitive/) यह निर्धारित करता है कि अक्षर का केस मेल होना चाहिए या नहीं।
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/includenotes/) प्रस्तुति‑स्तर की खोज, प्रतिस्थापन और हाइलाइटिंग ऑपरेशनों में स्लाइड नोट्स को शामिल करता है।

नियमित अभिव्यक्ति ऑपरेशनों में .NET `Regex` का उपयोग किया जाता है, इसलिए केस‑संवेदनशीलता और शब्द‑सीमा जैसे नियम अभिव्यक्ति और उसके विकल्पों द्वारा निर्धारित होते हैं।

## **टेक्स्ट फ्रेम के मालिक की पहचान करें**

जनरिक टेक्स्ट‑प्रोसेसिंग वर्कफ़्लोज़ अक्सर एक [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त करते हैं जबकि वे खोज, प्रतिस्थापन, वैधता या एक्सपोर्ट कर रहे होते हैं। टेक्स्ट फ्रेम के स्वामी प्रस्तुति ऑब्जेक्ट को निर्धारित करने के लिए [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) और [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) का उपयोग करें।

अपेक्षित मान मालिक पर निर्भर करते हैं:

| टेक्स्ट फ्रेम मालिक | `ParentShape` | `ParentCell` |
|---|---|---|
| एक AutoShape या कोई अन्य टेक्स्ट‑समावेशी शेप | मालिकाना [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) | `null` |
| एक टेबल सेल | `null` | मालिकाना [ICell](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/) |

दोनों प्रॉपर्टी केवल‑पढ़ने योग्य नेविगेशन प्रॉपर्टी हैं। इन्हें पढ़ने से टेक्स्ट फ्रेम नहीं बँधता और न ही उसका मालिक बदलता है। जनरिक कोड को दोनों मानों के लिये `null` जाँच करनी चाहिए और यह संभवना संभालनी चाहिए कि दोनों में से कोई भी मालिक उपलब्ध न हो।

निम्न उदाहरण में [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/getalltextframes/) का उपयोग करके एक प्रस्तुति में टेक्स्ट फ्रेमों पर इटरेट किया गया है। शेप्स के लिये, यह शेप का नाम, शेप प्रकार और सम्मिलित स्लाइड को रिपोर्ट करता है। टेबल सेल्स के लिये, यह शून्य‑आधारित कॉलम व पंक्ति निर्देशांक और सम्मिलित स्लाइड को रिपोर्ट करता है।

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

SmartArt सामग्री के लिये, [ISmartArtNode.Shapes](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartartnode/shapes/) में शेप्स पर इटरेट करें और प्रत्येक [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides.smartart/ismartartshape/textframe/) तक पहुँचें। टेक्स्ट फ्रेम को उसके सम्बंधित शेप से [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) द्वारा ट्रेस किया जा सकता है, जबकि [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) `null` रहता है। इसलिए, उदाहरण में शेप शाखा SmartArt नोड्स से टेक्स्ट भी संभालती है।

## **कॉलबैक के साथ मैच जानकारी इकट्ठा करें**

हर मिलान के लिये सूचना प्राप्त करने हेतु [IFindResultCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/) को लागू करें। इसका [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/foundresult/) मेथड सम्बंधित टेक्स्ट फ्रेम, स्रोत टेक्स्ट, मिलित टेक्स्ट और मिलान स्थिति प्रदान करता है।

कॉलबैक सीधे स्लाइड नंबर प्राप्त नहीं करता। नीचे दिया गया कार्यान्वयन इसे पैरेंट स्लाइड से निकालता है और स्लाइड नोट्स में पाए गए टेक्स्ट को भी संभालता है। Nullable स्लाइड नंबर समान परिणाम मॉडल को अन्य स्लाइड प्रकारों से जुड़े टेक्स्ट को भी प्रतिनिधित्व करने की अनुमति देता है।

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

प्रतिस्थापन ऑपरेशनों के लिये, `FoundText` मूल मिलित टेक्स्ट रखता है, इसलिए कॉलबैक ठीक‑ठीक रिकॉर्ड कर सकता है कि कौन‑से शब्द प्रतिस्थापित किए गये।

## **टेक्स्ट को हाइलाइट करें**

शाब्दिक‑टेक्स्ट मिलानों को एक टेक्स्ट फ्रेम में हाइलाइट करने हेतु [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/) मेथड का उपयोग करें। खोज को नियंत्रित करने और मैच विवरण इकट्ठा करने हेतु [TextSearchOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/) को पास करें और एक कॉलबैक प्रदान करें।

नीचे दिया गया कोड उदाहरण **"try"** अक्षरों की सभी उपस्थितियों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है। दोनों खोजें समान कॉलबैक को अपना मिलान रिपोर्ट करती हैं।

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// पहले स्लाइड से पहला शेप प्राप्त करें।
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// टेक्स्ट फ्रेम में "try" की प्रत्येक उपस्थिति को हाइलाइट करें।
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// केवल पूर्ण शब्द "to" को हाइलाइट करें।
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

परिणाम:

![हाइलाइट किया गया टेक्स्ट](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके टेक्स्ट को हाइलाइट करें**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/) मेथड नियमित अभिव्यक्ति द्वारा मिलने वाले टेक्स्ट मिलानों को हाइलाइट करता है।

निम्न कोड सभी सात या अधिक अक्षर वाले शब्दों को हाइलाइट करता है और प्रत्येक मिलान को इकट्ठा करता है:

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

![नियमित अभिव्यक्ति के साथ हाइलाइट किया गया टेक्स्ट](highlighted_text_using_regex.png)

## **पूरी प्रस्तुति में टेक्स्ट को हाइलाइट करें**

[Presentation.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlighttext/) और [Presentation.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/highlightregex/) का उपयोग करके प्रस्तुति में सभी लागू टेक्स्ट फ्रेमों को खोजें। नीचे दिया गया उदाहरण एक शाब्दिक शब्द और सभी ई‑मेल पतों को हाइलाइट करता है जबकि दो खोजों के लिये अलग‑अलग परिणाम संग्रह रखता है।

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

## **एक टेक्स्ट फ्रेम में टेक्स्ट बदलें**

शाब्दिक टेक्स्ट के लिये [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) और पैटर्न‑आधारित प्रतिस्थापन के लिये [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) का उपयोग करें। ये मेथड मौजूदा टेक्स्ट फ्रेम में मिलित टेक्स्ट को अपडेट करते हैं, जिससे आसपास के भाग का फ़ॉर्मेट बना रहता है और पूरे टेक्स्ट फ्रेम को साधारण स्ट्रिंग से पुनः निर्मित नहीं किया जाता।

नीचे का उदाहरण एक वर्तनी रूपांतर को मानकीकृत करता है और फिर संस्करण लेबल बदलता है। वही कॉलबैक दोनों ऑपरेशनों द्वारा मिले मूल शब्दों को रिकॉर्ड करता है।

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

यदि कोई मिलान विभिन्न फ़ॉर्मेट वाले हिस्सों को कवर करता है, तो आउटपुट को जाँचें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन टेक्स्ट पर कौन‑सा फ़ॉर्मेट लागू होना चाहिए।

## **पूरी प्रस्तुति में टेक्स्ट बदलें**

[Presentation.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replacetext/) और [Presentation.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/replaceregex/) का उपयोग करके समान ऑपरेशनों को पूरी प्रस्तुति पर लागू करें। यह टेम्पलेट सफ़ाई, शब्दावली अपडेट और रेडैक्शन के लिये उपयोगी है।

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

## **रिपोर्टिंग के लिये मैच समूह बनाएं**

क्योंकि प्रत्येक परिणाम में उसका स्लाइड नंबर और टेक्स्ट फ्रेम संग्रहीत होता है, एप्लिकेशन ऑडिट, रिपोर्टिंग या समीक्षा वर्कफ़्लो के लिये मैच को समूहित कर सकते हैं। नीचे का उदाहरण पहले स्लाइड द्वारा और फिर टेक्स्ट फ्रेम द्वारा संग्रहित परिणामों को समूहित करता है:

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

शेप के टेक्स्ट फ्रेम को प्राप्त करें और उस टेक्स्ट फ्रेम पर [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) या [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) को कॉल करें। प्रस्तुति‑स्तर के मेथड सभी लागू टेक्स्ट फ्रेमों को प्रोसेस करते हैं।

**मैं पूर्ण शब्दों को सही अक्षर‑केस के साथ कैसे मिलाऊँ?**

[TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/wholewordsonly/) और [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/casesensitive/) को `true` सेट करें और विकल्पों को शाब्दिक‑टेक्स्ट हाइलाइट या प्रतिस्थापन मेथड को पास करें। नियमित अभिव्यक्तियों के लिये, शब्द‑सीमा और केस‑संवेदनशीलता को .NET `Regex` में स्वयं परिभाषित करें।

**क्या खोज और प्रतिस्थापन स्लाइड नोट्स में टेक्स्ट को शामिल कर सकते हैं?**

हां। प्रस्तुति‑स्तर के शाब्दिक‑टेक्स्ट ऑपरेशन का उपयोग करते समय [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/includenotes/) को `true` सेट करें। ऊपर दिखाया गया कॉलबैक कार्यान्वयन नोट्स स्लाइड में मिलान को उसके पैरेंट स्लाइड नंबर में मैप करता है।

**मैं रिपोर्ट को दूसरी बार प्रस्तुति स्कैन किए बिना कैसे बनाऊँ?**

हाइलाइटिंग या प्रतिस्थापन ऑपरेशन को एक [IFindResultCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/ifindresultcallback/) कार्यान्वयन पास करें। कॉलबैक ऑपरेशन के दौरान प्रत्येक मिलान प्राप्त करता है, इसलिए एप्लिकेशन स्रोत टेक्स्ट, मिलित टेक्स्ट, स्थिति, टेक्स्ट फ्रेम और निकाले गये स्लाइड नंबर को बाद में समूहित या एक्सपोर्ट करने के लिये संचित कर सकता है।

**क्या टेक्स्ट बदलने से उसका फॉर्मेट बना रहता है?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replacetext/) और [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/replaceregex/) मौजूदा टेक्स्ट फ्रेम में मिलित टेक्स्ट को संशोधित करते हैं और आसपास के भाग के फ़ॉर्मेट को बरकरार रखते हैं। यदि कोई मिलान विभिन्न फ़ॉर्मेट वाले भागों को कवर करता है, तो परिणाम की जाँच करें ताकि यह सुनिश्चित हो सके कि प्रतिस्थापन वांछित शैली का उपयोग करता है।