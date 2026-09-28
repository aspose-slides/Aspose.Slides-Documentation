---
title: .NET में प्रस्तुति टेक्स्ट स्वरूपित करें
linktitle: टेक्स्ट स्वरूपण
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- पैराग्राफ संरेखण
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- पंक्ति अंतराल
- ऑटोफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फ़ॉर्मेट करें। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। स्लाइड और आकार दोनों सूचकांक शून्य‑आधारित हैं। बॉल्ड भागों को चुनने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बॉल्ड फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण टेक्स्ट](sample_text.png)

लिटरल टेक्स्ट या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाइलाइट डिफ़ॉल्ट बनाता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

एक टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ‑संरेखित, दाएँ‑संरेखित, न्यायसंगत आदि हो सकते हैं।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पैराग्राफ की संरेखण को केंद्र में सेट करें।
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पारदर्शिता को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 के पैमाने पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// टेक्स्ट के लिए अर्धपारदर्शी काला भराव सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू की जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // टेक्स्ट भाग की पारदर्शिता सेट करें।
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

एक टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें। नीचे के उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करेंगे।

निम्न C# कोड **पूरे पैराग्राफ** में अक्षर अंतराल को विस्तारित करने का प्रदर्शन करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतराल विस्तारित करें।

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल को विस्तारित करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
        portion.PortionFormat.Spacing = 3;  // अक्षर अंतराल विस्तारित करें।
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए टेक्स्ट से थोड़ा अधिक कसकर दिखाई दे सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को नजरअंदाज़ कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडरिंग को PowerPoint के करीब लाने के लिए आप उन टेक्स्ट भागों के लिए केरनिंग अक्षम कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। इसे करने हेतु [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" (पहले स्लाइड की पहली आकार एक टेक्स्ट बॉक्स) की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, की जाँच करता है और Roboto उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेसहोल्ड सेट करता है। यह मिलते‑जुलते भागों के लिए 100 पॉइंट से नीचे फ़ॉन्ट आकार होने पर केरनिंग को निष्क्रिय कर देता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var targetFont = "Roboto";

foreach (var paragraph in autoShape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var textFormat = portion.PortionFormat.GetEffective();
        
        var usesTargetFont = textFormat.LatinFont?.FontName == targetFont || 
            textFormat.EastAsianFont?.FontName == targetFont || 
            textFormat.ComplexScriptFont?.FontName == targetFont;

        if (usesTargetFont)
        {
            portion.PortionFormat.KerningMinimalSize = 100;
        }
    }
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

थ्रेसहोल्ड से नीचे के मेल खाते टेक्स्ट के लिए यह सेटिंग केरनिंग को रोकती है और फ़ॉन्ट‑विशिष्ट PowerPoint व्यवहार के कारण Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट से मेल खाने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) द्वारा या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/) द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ का डिफ़ॉल्ट फ़ॉन्ट 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

foreach (var portion in paragraph.Portions)
{
    if (portion.PortionFormat.GetEffective().FontBold)
    {
        // टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

एक आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्न कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिकूल दिशाबद्ध** घुमा देता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
```

परिणाम:

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की पंक्ति अंतराल सेट करें**

Aspose.Slides निम्न गुण प्रदान करता है: [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacewithin/) पैराग्राफ अंतराल नियंत्रित करने के लिए। इनका उपयोग इस प्रकार किया जाता है:

* पंक्ति अंतराल को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* पंक्ति अंतराल को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के भीतर अंतराल को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.SpaceWithin = 200;

presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ में पंक्ति अंतराल](line_spacing.png)

## **लाइन ब्रेकिन्ग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिन्ग नियम संकुचित टेक्स्ट ब्लॉक्स और लैटिन व ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे के गुण [IParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [LatinLineBreak](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/latinlinebreak/) लैटिन लाइन‑ब्रेकिन्ग नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पास के ईस्ट एशियन टेक्स्ट और विराम चिह्नों की रैपिंग भी बदल सकती है।
- [EastAsianLineBreak](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिन्ग नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत व अंत में अक्षरों की प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वतः रैपिंग सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। एक स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नई पंक्ति बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

निम्न स्वनिर्धारित उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट दोनों हों। यह दोनों लाइन‑ब्रेकिन्ग गुण स्पष्ट रूप से सेट करता है और "line_breaking.pptx" को सहेजता है। किसी एक नियम को आज़माने हेतु, दूसरे को जैसा है वैसा रखें और उस गुण का मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/autofittype/) को [TextAutofitType.None](https://reference.aspose.com/slides/hi/net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार व फ्रेम आयाम स्थिर रहें।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "中文排版测试，PowerPoint 中文演示。";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.EastAsianFont = new FontData("SimSun");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.LatinLineBreak = NullableBool.False;
format.EastAsianLineBreak = NullableBool.True;

presentation.Save("line_breaking.pptx", SaveFormat.Pptx);
```

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/hangingpunctuation/) योग्य विराम चिह्न को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक विस्तारित करने की अनुमति देता है, बजाय अगली पंक्ति में लगने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्न स्वनिर्धारित उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" को सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ किनारे से बाहर तक जाता है। तुलना के लिए गुण को [NullableBool.False](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) पर सेट करें: इस स्थिति में बिंदु अलग पंक्ति में दिखाई देगा। रैपिंग सक्षम है और ऑटोफिट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
shape.FillFormat.FillType = FillType.NoFill;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
textFrame.TextFrameFormat.MarginLeft = 0;
textFrame.TextFrameFormat.MarginRight = 0;

var paragraph = textFrame.Paragraphs[0];
paragraph.Text = "Simple text, next sentence.";

var format = paragraph.ParagraphFormat;
format.Alignment = TextAlignment.Left;
format.DefaultPortionFormat.FontHeight = 24;
format.DefaultPortionFormat.LatinFont = new FontData("Arial");
format.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
format.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
format.HangingPunctuation = NullableBool.True;

presentation.Save("hanging_punctuation.pptx", SaveFormat.Pptx);
```

सभी विराम चिह्न हैंग नहीं कर सकते। ऊपर वर्णित [फ़ॉन्ट व लेआउट शर्तें](`#conditions-and-limitations`) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफिट सेटिंग बदलने से दृश्य अंतर समाप्त हो सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटोफिट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमा से बाहर हो जाए तो वह कैसे व्यवहार करे। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट घटे, अतिप्रवाह हो या आकार स्वतः बदले। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार पुनः आकार देने के लिए कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

स्वचालित रैपिंग के बाद पंक्तियों की संख्या गिनने और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई बदलने से परिणाम कैसे प्रभावित होता है, देखें [Rendered Lines गिनें](/slides/hi/net/manage-paragraph/)। पंक्तियों की संख्या केवल यह दर्शाती है कि टेक्स्ट कंटेनर से बाहर गया या नहीं।

## **टेक्स्ट फ्रेम के एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/anchoringtype/) परिभाषित करता है कि टेक्स्ट को आकार के भीतर ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, उदाहरण के लिये शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहली आकार के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **टेक्स्ट टैबुलेशन सेट करें**

एक पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संज्ञा टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultTabSize = 100;
paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जिससे आप टेक्स्ट भाग की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी व व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण को "presentation.pptx" (पहली स्लाइड के पहले आकार में टेक्स्ट बॉक्स) की आवश्यकता है और कम से कम एक पैराग्राफ होना चाहिए। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा को Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var font = new FontData("SimSun");

var textPortion = new Portion();
textPortion.PortionFormat.ComplexScriptFont = font;
textPortion.PortionFormat.EastAsianFont = font;
textPortion.PortionFormat.LatinFont = font;

// प्रूफ़िंग भाषा को सरलित चीनी सेट करें।
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करके वह डिफ़ॉल्ट भाषा परिभाषित करें जो प्रस्तुति लोड या बनाते समय निर्मित टेक्स्ट पर लागू होगी। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करके एक प्रस्तुति बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है:

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// टेक्स्ट के साथ एक नया आयताकार आकार जोड़ें।
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// पहले भाग की भाषा जाँचें।
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तर के पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट बनाता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर टेक्स्ट बड़े अक्षरों में दिखता है, भले ही मूल रूप से लोअरकेस में टाइप किया गया हो। Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करने पर लाइब्रेरी मूल रूप में दर्ज किया गया टेक्स्ट लौटाती है। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/net/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" (पहली स्लाइड पर पहला आकार टेक्स्ट बॉक्स) की आवश्यकता रखता है। उसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है जिस पर All Caps इफ़ेक्ट लागू किया गया है, जैसा कि नीचे दिखाया गया है।

![ऑल‑कैप्स इफ़ेक्ट](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को कैसे निकालें:

```cs
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample2.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

Console.WriteLine($"Original text: {textPortion.Text}");

var textFormat = textPortion.PortionFormat.GetEffective();
if (textFormat.TextCapType == TextCapType.All)
{
    var text = textPortion.Text.ToUpper();
    Console.WriteLine($"All-Caps effect: {text}");
}
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करूँ?**

तालिका में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) का उपयोग करें। कोशिकाओं पर इटररेट करें और प्रत्येक को [ICell.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/textframe/) तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) द्वारा अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा एवं पारदर्शिता को कॉन्फ़िगर करें।