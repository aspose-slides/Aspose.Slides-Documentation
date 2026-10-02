---
title: .NET में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटॉफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट करने का तरीका दिखाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा नहीं कहा गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकार दोनों के सूचकांक शून्य-आधारित हैं। जो उदाहरण मोटा (bold) भाग चुनते हैं, वे प्रभावी फ़ॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला मोटा फ़ॉर्मेटिंग भी शामिल है:

![नमूना पाठ](sample_text.png)

पाठ खोजें और बदलें को देखने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत पाठ हिस्सों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाईलाइट डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाईलाइट रंग इस डिफॉल्ट पर प्राथमिकता लेते हैं:

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

नीचे दिया गया कोड उदाहरण दर्शाता है कि **मोटे फ़ॉन्ट वाले पाठ हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट करें:

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
        // टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें.
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे पाठ हिस्से](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करके टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट किया जा सकता है। मान को केन्द्रित, बाएँ संरेखित, दाएँ संरेखित, औसत आदि में सेट किया जा सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पैराग्राफ का संरेखण केंद्र में सेट करें.
paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

[IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) का उपयोग करके एक लाइन के भीतर विभिन्न फ़ॉन्ट आकारों वाले पाठ हिस्सों को लंबवत संरेखित किया जा सकता है। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण को नियंत्रित करती है।

निम्नलिखित स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में समान पाठ 18, 36 और 54 पॉइंट पर होता है, प्रत्येक के साथ अलग फ़ॉन्ट संरेखण। यह Arial का उपयोग करता है, ऑटॉफ़िट और रैपिंग को अक्षम करता है, और टेक्स्ट फ्रेम को एकल पंक्ति के लिए पर्याप्त बड़ा रखता है।

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

![मिश्रित फ़ॉन्ट आकारों के साथ बेसलाइन, टॉप, सेंटर और बॉटम फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स का उपयोग करता है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे आवश्यक रूप से सटीक रूप से संरेखित नहीं होते। उदाहरण में एक अपरकेस अक्षर और एक डीसेंडर दोनों शामिल हैं ताकि बेसलाइन और बॉटम संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकारों का अंतर परिणाम को प्रभावित करता है। फ्रेम आयाम, मार्जिन, लाइन अंतराल, रैपिंग और ऑटॉफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) से अलग है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करता है, और [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) से भी, जो आकार के भीतर पाठ ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) द्वारा ऊपर या नीचे की लिपि फ़ॉर्मेटिंग व्यक्तिगत हिस्सों को बेसलाइन के सापेक्ष स्थानांतरित करती है, बजाय पैराग्राफ की पंक्तियों के लिए फ़ॉन्ट संरेखण सेट करने के।

## **पाठ की पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू करें:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पाठ के लिए अर्धपारदर्शी काली भराव सेट करें.
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **मोटे फ़ॉन्ट वाले पाठ हिस्सों** पर पारदर्शिता कैसे लागू की जाए:

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
        // पाठ भाग की पारदर्शिता सेट करें.
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी पाठ हिस्से](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

[IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करके टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाया या घटाया जा सकता है। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करते हैं।

निम्नलिखित C# कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल को कैसे बढ़ाया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतराल बढ़ाएँ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **मोटे फ़ॉन्ट वाले पाठ हिस्सों** में अक्षर अंतराल को कैसे बढ़ाया जाए:

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
        // नोट: अक्षर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें.
        portion.PortionFormat.Spacing = 3;  // अक्षर स्पेसिंग बढ़ाएँ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पाठ हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक सघन दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ हिस्सों के लिए केरनिंग अक्षम कर सकते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट्स शामिल हैं, और Roboto का उपयोग करने वाले हिस्सों के लिए 100 पॉइंट की सीमा सेट करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मेल खाने वाले हिस्सों के लिए केरनिंग अक्षम करता है:

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

सीमा के नीचे के मेल खाने वाले पाठ के लिए, यह सेटिंग केरनिंग को रोकती है और इस PowerPoint-विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) के द्वारा सेट किए जा सकते हैं।

निम्नलिखित उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12 पॉइंट Times New Roman, मोटा, इटैलिक और डॉटेड अंडरलाइन फ़ॉर्मेटिंग के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फ़ॉर्मेटिंग इन डिफ़ॉल्ट सेटिंग्स पर प्राथमिकता लेती है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें.
var portionFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
portionFormat.FontHeight = 12;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontItalic = NullableBool.True;
portionFormat.FontUnderline = TextUnderlineType.Dotted;
portionFormat.LatinFont = new FontData("Times New Roman");

presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्नलिखित उदाहरण 13 पॉइंट Times New Roman, इटैलिक फ़ॉर्मेटिंग, और डॉटेड अंडरलाइन को उन हिस्सों पर लागू करता है जिनकी प्रभावी फ़ॉर्मेटिंग मोटी है:

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
        // पाठ भाग के लिए फ़ॉन्ट गुण सेट करें.
        portion.PortionFormat.FontHeight = 13;
        portion.PortionFormat.FontItalic = NullableBool.True;
        portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
        portion.PortionFormat.LatinFont = new FontData("Times New Roman");
    }
}

presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पाठ हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घूर्णन सेट करें**

[ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करके आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट किया जा सकता है।

निम्नलिखित कोड उदाहरण आकार में पाठ अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री प्रतिक्लॉकवायर** घुमा देता है:

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

![पाठ घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके एक [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट किया जा सकता है।

कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

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

![कस्टम पाठ घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए एक सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए एक नकारात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200% (डबल स्पेसिंग) पर सेट करता है:

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

पैराग्राफ लाइन-ब्रेकिंग नियम संकरे टेक्स्ट ब्लॉक और लैटिन तथा ईस्ट एशियन पाठ मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्नलिखित गुण [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) लैटिन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित पाठ में, इसे बदलने से पास के ईस्ट एशियन पाठ और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ईस्ट एशियन लाइन-ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें पंक्ति की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। रैपिंग होने पर वे लेआउट को प्रभावित करते हैं; वे लाइन-ब्रेक अक्षर नहीं डालते। एक स्पष्ट लाइन ब्रेक उपलब्ध चौड़ाई से स्वतंत्र रूप से पैराग्राफ में नई पंक्ति बनाता है।

निम्नलिखित स्वतंत्र उदाहरण एक संकरे टेक्स्ट ब्लॉक को बनाता है जिसमें चीनी और लैटिन पाठ शामिल है। यह दोनों लाइन-ब्रेकिंग गुणों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। किसी भी नियम के साथ प्रयोग करने के लिए, उस गुण का मान बदलें जबकि अन्य सेटिंग्स को स्थिर रखें। उदाहरण 24 पॉइंट Arial और SimSun का उपयोग 160 पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ करता है। [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि पाठ आकार और फ्रेम आयाम स्थिर रहें।

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) योग्य विराम चिह्न को अगली पंक्ति पर कब्ज़ा करने के बजाय टेक्स्ट लाइन के दायें किनारे से बाहर विस्तारित करने की अनुमति देता है। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्नलिखित स्वतंत्र उदाहरण 100 पॉइंट चौड़ी टेक्स्ट फ्रेम में हैंगिंग पंक्‍चुएशन सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24 पॉइंट Arial और शून्य क्षैतिज टेक्स्ट-फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दायें टेक्स्ट किनारे से बाहर विस्तारित होता है। तुलना के लिए इस गुण को [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु एक अलग पंक्ति में हो जाता है। रैपिंग सक्षम है और ऑटॉफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं किया जा सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफ़िट सेटिंग्स बदलने से दृश्यमान अंतर समाप्त हो सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफ़िट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि कंटेनर की सीमाओं से टेक्स्ट जब बाहर निकले तो उसका व्यवहार कैसे हो। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि पाठ संकुचित हो, ओवरफ़्लो हो, या आकार को स्वचालित रूप से री‑साइज़ किया जाए। निम्नलिखित उदाहरण आकार को उसके टेक्स्ट के अनुसार री‑साइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और देखना कि पाठ या आकार की चौड़ाई परिणाम को कैसे बदलती है, इसके लिए देखें [Count Rendered Lines](/slides/hi/net/manage-paragraph/). केवल लाइनों की संख्या यह संकेत नहीं देती कि पाठ अपने कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) यह निर्धारित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित हो, उदाहरण के लिए, शीर्ष, मध्य, या नीचे। निम्नलिखित उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

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

[IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करके पैराग्राफ में टैब स्टॉप कॉन्फ़िगर किया जा सकता है। निम्नलिखित उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब अक्षर वाले पाठ को प्रभावित करती हैं।

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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जो आपको एक पाठ हिस्से के लिए प्रूफिंग भाषा सेट करने की अनुमति देता है। प्रूफिंग भाषा PowerPoint में वर्तन और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित उदाहरण में "presentation.pptx" की आवश्यकता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और सरलित चीनी प्रूफिंग भाषा (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

// प्रूफ़िंग भाषा को सरलित चीनी पर सेट करें.
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करके प्रस्तुति लोड या बनाते समय निर्मित पाठ के लिए डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्नलिखित उदाहरण US English को डिफ़ॉल्ट पाठ भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ हिस्से के लिए `en-US` प्रिंट करता है।

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// टेक्स्ट के साथ नया आयताकार आकार जोड़ें.
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// पहले हिस्से की भाषा जाँचें.
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेज़ेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए, [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्नलिखित उदाहरण नई प्रस्तुति में टॉप‑लेवल पैराग्राफ़ के लिए डिफ़ॉल्ट 14 पॉइंट मोटा फ़ॉन्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// ऊपर स्तर पैराग्राफ स्वरूप प्राप्त करें.
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All-Caps प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में, **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़ी अक्षरों (uppercase) में दिखता है चाहे वह मूल रूप से छोटे अक्षरों (lowercase) में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे पाठ हिस्से को पुनः प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी प्रकार लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाई गई स्ट्रिंग को uppercase में बदलें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। उसके पहले पैराग्राफ के पहले हिस्से में "Hello, Aspose!" है जिसमें All Caps प्रभाव लागू है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

कोड उदाहरण नीचे दिखाता है कि **All Caps** प्रभाव लागू करके टेक्स्ट को कैसे निकालें:

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

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर तालिका में टेक्स्ट को संशोधित करने के लिए, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेटिंग को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से बदलें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट कलर कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट कलर लागू करने के लिए, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।