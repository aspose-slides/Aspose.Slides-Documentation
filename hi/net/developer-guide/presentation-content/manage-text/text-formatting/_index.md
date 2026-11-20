---
title: फ़ॉर्मेट प्रेज़ेंटेशन टेक्स्ट .NET में
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- पैराग्राफ संरेखण
- टेक्स्ट स्टाइल
- टेक्स्ट बैकग्राउंड
- टेक्स्ट ट्रांसपैरेंसी
- कैरेक्टर स्पेसिंग
- फ़ॉन्ट प्रॉपर्टीज़
- फ़ॉन्ट फ़ैमिली
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ़्रेम
- लाइन स्पेसिंग
- ऑटोफिट प्रॉपर्टी
- टेक्स्ट फ़्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में Aspose.Slides for .NET का उपयोग करके टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फॉर्मेट करने का तरीका दर्शाता है। यह बैकग्राउंड रंग, ट्रांसपैरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट प्रॉपर्टीज, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप्स और भाषा सेटिंग्स को कवर करता है।

यदि अन्यथा उल्लेख न किया गया हो, तो उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। पहले स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसकी पहली पैराग्राफ में नीचे दिखाया गया टेक्स्ट है। स्लाइड और आकार दोनों की इंडेक्स शून्य‑आधारित हैं। बोल्ड हिस्सों का चयन करने वाले उदाहरण प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में प्राप्त बोल्ड फ़ॉर्मेटिंग भी शामिल है:

![उदाहरण पाठ](sample_text.png)

वास्तविक टेक्स्ट या रेगुलर‑एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **टेक्स्ट बैकग्राउंड रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाईलाइट डिफ़ॉल्ट रूप में सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पूरे पैराग्राफ के लिए हाईलाइट रंग सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट हिस्सों** के लिए बैकग्राउंड रंग सेट करने का प्रदर्शन करता है:

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
        // टेक्स्ट हिस्से के लिए हाईलाइट रंग सेट करें।
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान को centered, left‑aligned, right‑aligned, justified आदि में से कोई भी हो सकता है।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दिखाता है:

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

## **लाइन में फ़ॉन्ट संरेखित करें**

विचित्र फ़ॉन्ट आकारों वाले टेक्स्ट हिस्सों को लाइन में वर्टिकली संरेखित करने के लिए [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक लाइन के भीतर संरेखण को नियंत्रित करती है।

निम्न स्वनिहित उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36 और 54 पॉइंट का समान टेक्स्ट होता है, अलग‑अलग फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटोफिट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक लाइन के लिए पर्याप्त बड़ा रखता है।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var alignments = new[] { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
var fontSizes = new[] { 18f, 36f, 54f };

for (var i = 0; i < alignments.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;

    var label = textFrame.Paragraphs[0];
    label.Text = alignments[i].ToString();
    label.ParagraphFormat.Alignment = TextAlignment.Left;
    label.ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
    label.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    label.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.FontAlignment = alignments[i];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Arial");
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

    foreach (var fontSize in fontSizes)
    {
        var portion = new Portion("Ag ");
        portion.PortionFormat.FontHeight = fontSize;
        paragraph.Portions.Add(portion);
    }

    textFrame.Paragraphs.Add(paragraph);
}

presentation.Save("font_alignment.pptx", SaveFormat.Pptx);
```

परिणाम:

![Baseline, Top, Center, और Bottom फ़ॉन्ट संरेखण की तुलना (मिक्स्ड फ़ॉन्ट आकार)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर निर्भर करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे बिल्कुल मिल नहीं सकते। उदाहरण में एक अपरकेस अक्षर और एक डेसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के अंतर को दिखाया जा सके। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, उपयोग किए गए अक्षर और फ़ॉन्ट आकार में अंतर परिणाम को प्रभावित करते हैं। फ्रेम आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफिट भी लेआउट को प्रभावित करते हैं; तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) से भी अलग है, जो आकार के भीतर टेक्स्ट ब्लॉक को वर्टिकली स्थित करता है। [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) के माध्यम से सुपर‑स्क्रिप्ट और सब‑स्क्रिप्ट फ़ॉर्मेटिंग व्यक्तिगत हिस्सों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि पैराग्राफ के लाइनों के लिए फ़ॉन्ट संरेखण सेट करता है।

## **टेक्स्ट के लिए ट्रांसपैरेंसी सेट करें**

ट्रांसपैरेंसी को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि ट्रांसपैरेंसी प्रतिशत।

निम्न कोड उदाहरण **पूरे पैराग्राफ** पर ट्रांसपैरेंसी लागू करने का तरीका दिखाता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// टेक्स्ट के लिये अर्धपारदर्शी काली भराव सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![ट्रांसपैरेंट पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले टेक्स्ट हिस्सों पर ट्रांसपैरेंसी लागू करने का तरीका दिखाता है:

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
        // टेक्स्ट हिस्से की पारदर्शिता सेट करें।
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![ट्रांसपैरेंट टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तृत या सघन करने के लिये [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) का प्रयोग करें। नीचे के उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को सघन करता है।

निम्न C# कोड **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग बढ़ाने का तरीका दर्शाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// नोट: कैरेक्टर स्पेसिंग को सघन करने के लिये नकारात्मक मानों का प्रयोग करें।
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // कैरेक्टर स्पेसिंग बढ़ाएँ।

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट** वाले टेक्स्ट हिस्सों में कैरेक्टर स्पेसिंग बढ़ाने का तरीका दर्शाता है:

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
        // नोट: कैरेक्टर स्पेसिंग को सघन करने के लिये नकारात्मक मानों का प्रयोग करें।
        portion.PortionFormat.Spacing = 3;  // कैरेक्टर स्पेसिंग बढ़ाएँ।
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट हिस्सों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिये केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखने वाले टेक्स्ट से थोड़ा टाइट लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिये केरनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसी स्थितियों में रेंडर आउटपुट को PowerPoint के निकट लाने के लिये आप उन टेक्स्ट हिस्सों के लिये केरनिंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का प्रयोग करते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण पहले स्लाइड के पहले आकार में टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता रखता है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) की जाँच करता है और Roboto उपयोग करने वाले हिस्सों के लिये 100‑पॉइंट की थ्रेशहोल्ड सेट करता है। इससे 100 पॉइंट से कम आकार वाले मिलते‑जुलते हिस्सों की केरनिंग निष्क्रिय हो जाती है:

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

थ्रेशहोल्ड से नीचे के मिलते टेक्स्ट के लिये यह सेटिंग केरनिंग को रोकती है और उस PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिये Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ प्रबंधित करें**

फ़ॉन्ट प्रॉपर्टीज़ को पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पैराग्राफ के लिए फ़ॉन्ट प्रॉपर्टी सेट करें।
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_paragraph.png)

निम्न उदाहरण उन हिस्सों पर 13‑पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग बोल्ड है:

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
        // टेक्स्ट हिस्से के लिए फ़ॉन्ट प्रॉपर्टी सेट करें।
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट हिस्सों के फ़ॉन्ट प्रॉपर्टीज़](font_properties_for_text_portions.png)

## **टेक्स्ट हाइट नॉर्मलाइज़ेशन नियंत्रित करें**

[आईबेसपोर्टियनफ़ॉर्मेट.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) का उपयोग टेम्पलेट टाइपोग्राफी दोहराते समय या कैरेक्टर हाइट में अंतर की जाँच करने के लिये किया जाता है। PowerPoint में नॉर्मलाइज़ेशन सक्षम करने से व्यक्तिगत अक्षरों को वर्टिकली खींचा या संकुचित किया जाता है ताकि वे टेक्स्ट हिस्से के भीतर समान दृश्य हाइट प्राप्त कर सकें। यह विभिन्न फ़ॉन्ट्स के बीच समान टेक्स्ट हाइट की गारंटी नहीं देता।

प्रॉपर्टी को [NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करके नॉर्मलाइज़ेशन को स्पष्ट रूप से सक्षम या निष्क्रिय किया जा सकता है। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट रखता है जिससे हिस्सा पैराग्राफ की [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) से मूल्य विरासत में लेता है। इसका अर्थ `False` नहीं है। रिजॉल्व्ड Boolean मान प्राप्त करने के लिये [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) और [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) का उपयोग करें।

निम्न स्वनिहित उदाहरण **Arial** स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉक्स बनाता है जिनमें वही अपरकेस अक्षर, लोअरकेस अक्षर, डेसेंडर और प्रत्यययुक्त अक्षर 54 पॉइंट पर होते हैं। दोनों पैराग्राफ़ डिफ़ॉल्ट रूप से नॉर्मलाइज़ेशन सक्षम रखते हैं। ऊपर वाला हिस्सा स्पष्ट रूप से इसे निष्क्रिय करता है; नीचे वाला इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और पैराग्राफ स्पेसिंग समान हैं, रैपिंग और ऑटोफिट निष्क्रिय हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var settings = new[] { NullableBool.False, NullableBool.NotDefined };

for (var i = 0; i < settings.Length; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
    shape.FillFormat.FillType = FillType.NoFill;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;

    var textFrame = shape.TextFrame;
    textFrame.Text = "Hxgjpq ÅÉ 0123";
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;
    textFrame.TextFrameFormat.WrapText = NullableBool.False;
    textFrame.TextFrameFormat.AnchoringType = TextAnchorType.Top;
    textFrame.TextFrameFormat.MarginTop = 0;
    textFrame.TextFrameFormat.MarginLeft = 0;

    var paragraph = textFrame.Paragraphs[0];
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceBefore = 0;
    paragraph.ParagraphFormat.SpaceAfter = 0;
    paragraph.ParagraphFormat.SpaceWithin = 100;
    paragraph.ParagraphFormat.DefaultPortionFormat.NormaliseHeight = NullableBool.True;

    var portion = paragraph.Portions[0];
    portion.PortionFormat.LatinFont = new FontData("Arial");
    portion.PortionFormat.FontHeight = 54;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.NormaliseHeight = settings[i];

    Console.WriteLine($"{settings[i]}: {portion.PortionFormat.GetEffective().NormaliseHeight}");
}

presentation.Save("text_height_normalization.pptx", SaveFormat.Pptx);
```

नीचे की तुलना सहेजे गए प्रेज़ेंटेशन से एक्सपोर्ट की गई है। ऊपर की पंक्ति नॉर्मलाइज़ेशन निष्क्रिय (`False`) दर्शाती है; नीचे की पंक्ति विरासत में मिले सक्षम सेटिंग (`NotDefined` → `True`) को दिखाती है। इस रूप को पुनः उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट जिसमें ऊपर नॉर्मलाइज़ेशन निष्क्रिय और नीचे विरासत में नॉर्मलाइज़ेशन सक्षम है](text_height_normalization.png)

नॉर्मलाइज़ेशन फ़ॉन्ट हाइट को बदले बिना असाइन किए गए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) मान को बदले बिना अक्‌षर की हाइट बदलता है। पैराग्राफ [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) टेक्स्ट या उसके कंटेनर को फिट करने के लिये आकार बदलता है। ये सेटिंग्स भिन्न उद्देश्यों की सेवा करती हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फ़ॉर्मेटिंग और इनहेरिटेंस के बारे में अधिक जानकारी के लिये देखें [Manage Paragraph](/slides/hi/net/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू और हटाएँ**

टेक्स्ट हिस्से पर [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) का उपयोग करके संशोधन, रद्द किए गए शब्द या पूर्व कीमतों को मूल टेक्स्ट हटाए बिना दिखाया जा सकता है। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) पर सेट करके एक या दो रेखाएँ टेक्स्ट के ऊपर ड्रॉ की जा सकती हैं।

स्ट्राइकथ्रू हटाने के लिये `TextStrikethroughType.None` असाइन करें। यह प्रभाव को स्पष्ट रूप से निष्क्रिय करता है, भले ही आसपास का फ़ॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, `TextStrikethroughType.NotDefined` स्थानीय सेटिंग को अनडिफ़ाइन्ड छोड़ देता है, जिससे हिस्सा पैराग्राफ आदि से फ़ॉर्मेटिंग विरासत में लेता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामस्वरूप फ़ॉर्मेटिंग (विरासत में मिली मान सहित) पढ़ने के लिये [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) का उपयोग करें।

निम्न स्वनिहित उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व कीमत और वर्तमान कीमत के लिये अलग‑अलग हिस्से होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में क्रमशः सिंगल और डबल स्ट्राइकथ्रू रहता है। इस प्रॉपर्टी को बदलने से टेक्स्ट और उसकी अन्य फ़ॉर्मेटिंग, जिसमें बोल्ड पूर्व कीमत भी शामिल है, बरकरार रहती है।

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

var labels = new[] { "None: ", "Single: ", "Double: " };

foreach (var label in labels)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Alignment = TextAlignment.Left;
    paragraph.ParagraphFormat.SpaceAfter = 20;

    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    format.FontHeight = 28;
    format.LatinFont = new FontData("Arial");
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    paragraph.Portions.Add(new Portion(label));

    var previousPrice = new Portion("$100");
    previousPrice.PortionFormat.FontBold = NullableBool.True;
    paragraph.Portions.Add(previousPrice);
    paragraph.Portions.Add(new Portion(" → $80"));
    
    shape.TextFrame.Paragraphs.Add(paragraph);
}

var paragraphs = shape.TextFrame.Paragraphs;

// स्ट्राइकथ्रू लागू करें, फिर पहले पूर्व कीमत से इसे स्पष्ट रूप से हटाएँ।
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![पूर्व कीमतें बिना स्ट्राइकथ्रू, सिंगल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू के साथ](strikethrough.png)

## **टेक्स्ट रोटेशन सेट करें**

[ ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करके आकार के भीतर एक पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट किया जा सकता है।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) पर सेट करता है, जिससे टेक्स्ट **90 डिग्री प्रतिकूल दिशामें** घुमता है:

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

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिये कस्टम रोटेशन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) के लिये कस्टम रोटेशन एंगल सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है जो पैराग्राफ स्पेसिंग को नियंत्रित करते हैं। इन प्रॉपर्टीज़ का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की उँचाई का प्रतिशत निर्दिष्ट करने के लिये सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिये नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहली पैराग्राफ की स्पेसिंग को लाइन उँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकरी टेक्स्ट ब्लॉक्स और लैटिन एवं ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे की प्रॉपर्टीज़ [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरी पैराग्राफ पर लागू होती हैं:

* [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्नों के रैप होने के स्थान भी बदल सकते हैं।
* [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे रैपिंग के घटित होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर डालते नहीं हैं। स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नई लाइन को उपलब्ध चौड़ाई से स्वतंत्र रूप से प्रवर्तित करता है।

निम्न स्वनिहित उदाहरण एक संकरी टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट मिश्रित हैं। यह दोनों लाइन‑ब्रेकिंग प्रॉपर्टीज़ को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। प्रत्येक नियम को प्रयोग करने के लिये, दूसरे सेटिंग को जैसा का तैसा रखते हुए उस प्रॉपर्टी का मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग 160‑पॉइंट फ्रेम चौड़ाई और शून्य हॉरिज़ॉन्टल टेक्स्ट‑फ़्रेम मार्जिन के साथ करता है। [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पॉन्क्चुएशन नियंत्रित करें**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) पात्रों को टेक्स्ट लाइन के दाएँ किनारे से बाहर पहुँचने की अनुमति देता है, बजाय अगले लाइन में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से भिन्न है।

निम्न स्वनिहित उदाहरण 100‑पॉइंट‑वाइड टेक्स्ट फ्रेम में हैंगिंग पॉन्क्चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य हॉरिज़ॉन्टल मार्जिन के साथ अंतिम अवधि "sentence" के बाद रहती है और दाएँ टेक्स्ट किनारे से बाहर निकलती है। तुलना के लिये प्रॉपर्टी को [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ अवधि अलग लाइन पर आती है। रैपिंग सक्षम है और ऑटोफिट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

प्रत्येक पॉन्क्चुएशन चिन्ह नहीं हैंग कर सकते। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफिट सेटिंग बदलने से दिखने वाला अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिये ऑटोफिट टाइप सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमाओं से अधिक होने पर वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिये करें कि टेक्स्ट छोटा हो, ओवरफ़्लो हो या आकार स्वतः री‑साइज़ हो। नीचे दिया गया उदाहरण आकार को उसके टेक्स्ट को फिट करने के लिये री‑साइज़ करने के लिये कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और आकार की चौड़ाई में परिवर्तन देखे के लिये देखें [Count Rendered Lines](/slides/hi/net/manage-paragraph/)। लाइनों की गिनती अकेले यह नहीं बताती कि टेक्स्ट कंटेनर से बाहर ओवरफ़्लो हो रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) आकार के भीतर टेक्स्ट को वर्टिकली कहाँ स्थित किया जाता है, जैसे शीर्ष, मध्य या नीचे, को परिभाषित करता है। नीचे दिया गया उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें। नीचे दिया गया उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर एक बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जिससे आप टेक्स्ट हिस्से की प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिये उपयोग की जाने वाली भाषा निर्धारित करती है।

नीचे दिया गया उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रमाण भाषा को Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

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

// प्रूफिंग भाषा को सरलित चीनी पर सेट करें।
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **भाषा मेटाडाटा कॉपी करें**

एक टेम्प्लेट से बहुभाषी टेक्स्ट कॉपी करते समय, दोनों [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) और [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) को संरक्षित रखें। नीचे दिया गया स्वनिहित उदाहरण स्रोत हिस्से को US English को अपनी भाषा और French को वैकल्पिक भाषा के साथ बनाता है और टेक्स्ट व पहचानकर्ताओं को नए प्रेज़ेंटेशन के एक हिस्से में कॉपी करता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new Portion("Hello! Bonjour!");
source.PortionFormat.LanguageId = "en-US";
source.PortionFormat.AlternativeLanguageId = "fr-FR";

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var destination = new Portion();
destination.Text = source.Text;
destination.PortionFormat.LanguageId = source.PortionFormat.LanguageId;
// यदि स्रोत में वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ करता है।
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

वैकल्पिक भाषा के बिना स्रोत को आज़माने के लिये, `"fr-FR"` असाइनमेंट को छोड़ दें। तब वैकल्पिक पहचानकर्ता `null` रहेगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को डिफ़ॉल्ट मान जोड़े बिना संरक्षित रखेगा, चाहे गंतव्य में पहले वैकल्पिक भाषा असाइन की गई हो।

ये पहचानकर्ता भाषा मेटाडाटा संग्रहित करते हैं। उन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint किस शब्दकोश का चयन वर्तनी या व्याकरण जाँच के लिये करता है।

## **डिफ़ॉल्ट भाषा सेट करें**

प्रेज़ेंटेशन लोड या बनाने के दौरान निर्मित टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करने के लिये [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करें। नीचे दिया गया उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ एक प्रेज़ेंटेशन बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट हिस्से के लिये `en-US` प्रिंट करता है।

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// टेक्स्ट के साथ नया आयताकार आकार जोड़ें।
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// पहले हिस्से की भाषा जांचें।
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेज़ेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

नीचे दिया गया उदाहरण नई प्रेज़ेंटेशन में शीर्ष‑स्तर पैराग्राफ़ के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

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

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप में छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसा टेक्स्ट हिस्सा प्राप्त करने पर लाइब्रेरी टेक्स्ट को बिल्कुल वही रूप में लौटाती है जैसा इनपुट किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) जाँचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहले स्लाइड पर पहला आकार टेक्स्ट बॉक्स है। पहली पैराग्राफ के पहले हिस्से में "Hello, Aspose!" है जिस पर All Caps इफ़ेक्ट लागू है, जैसा नीचे दिखाया गया है।

![All Caps इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को निकालने का तरीका दर्शाता है:

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

## **FAQ**

**मैं स्लाइड पर टेबल के टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर टेबल के टेक्स्ट को संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) का उपयोग करें। सेल्स के माध्यम से इटरनेट करें और प्रत्येक सेल को [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट के लिये ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशाएँ और ट्रांसपैरेंसी को कॉन्फ़िगर करें।

संबंधित फीचर: [Format text within slides](/slides/hi/features/text-formatting/)。