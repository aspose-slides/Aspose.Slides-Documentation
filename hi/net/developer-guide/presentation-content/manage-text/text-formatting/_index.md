---
title: .NET में प्रस्तुति पाठ को स्वरूपित करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- अनुच्छेद संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- लाइन अंतराल
- ऑटॉफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैब्यूलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **परिचय**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित करने का तरीका दर्शाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, अनुच्छेद अंतराल, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स को शामिल करता है।

जब तक अन्यथा नहीं बताया गया हो, उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहली आकृति एक टेक्स्ट बॉक्स है, और उसका पहला अनुच्छेद नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकृति दोनों के सूचकांक शून्य‑आधारित हैं। उन उदाहरणों में जो बोल्ड भागों का चयन करते हैं, प्रभावी स्वरूपण का उपयोग किया जाता है, जिसमें विरासत में मिला हुआ बोल्ड स्वरूपण भी शामिल है:

![नमूना पाठ](sample_text.png)

टेक्स्ट खोजें और बदलें देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/).

## **पाठ पृष्ठभूमि रंग सेट करें**

किसी अनुच्छेद के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत पाठ हिस्सों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्न उदाहरण पहले अनुच्छेद के लिए हल्के ग्रे हाइलाइट को डिफ़ॉल्ट निर्धारित करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्रभावी होते हैं:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पूरे अनुच्छेद के लिए हाइलाइट रंग सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** के लिए पृष्ठभूमि रंग सेट करने का प्रदर्शन करता है:

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
        // पाठ भाग के लिए हाइलाइट रंग सेट करें।
        portion.PortionFormat.HighlightColor.Color = Color.LightGray;
    }
}

presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर अनुच्छेद संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान को केंद्रित, बाएँ‑संतुलित, दाएँ‑संतुलित, समायोजित आदि हो सकता है।

निम्न कोड उदाहरण **केंद्र** में अनुच्छेद को संरेखित करने का तरीका दिखाता है:

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

![संरेखित अनुच्छेद](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट को संरेखित करें**

पंक्ति में विभिन्न फ़ॉन्ट आकारों वाले पाठ भागों को लंबवत रूप से संरेखित करने के लिए [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) का उपयोग करें। यह सेटिंग पूरे अनुच्छेद पर लागू होती है और प्रत्येक पंक्ति के भीतर संरेखण नियंत्रित करती है।

निम्न स्वतंत्र उदाहरण एक स्लाइड पर चार लेबलेड टेक्स्ट बॉक्स बनाता है। प्रत्येक अनुच्छेद में 18, 36 और 54 पॉइंट पर एक ही पाठ होता है, प्रत्येक के फ़ॉन्ट संरेखण अलग होते हैं। यह Arial का उपयोग करता है, ऑटोफ़िट और रैपिंग को अक्षम करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

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

![मिश्रित फ़ॉन्ट आकारों के साथ बेसलाइन, शीर्ष, मध्य और निचले फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे आवश्यक रूप से बिल्कुल संगत नहीं होते। उदाहरण में एक बड़े अक्षर और एक नीचे उतरने वाला अक्षर शामिल है जिससे बेसलाइन और नीचे संरेखण का अंतर स्पष्ट हो। फ़ॉन्ट उपलब्धता, प्रतिस्थापन, प्रयुक्त अक्षर और फ़ॉन्ट आकारों का अंतर परिणाम को प्रभावित करता है। फ्रेम आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटोफ़िट भी लेआउट को प्रभावित करते हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) से अलग है, जो क्षैतिज अनुच्छेद संरेखण को नियंत्रित करता है, और [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) से भी, जो आकृति के भीतर पाठ ब्लॉक को लंबवत स्थित करता है। [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट स्वरूपण व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करता है, न कि अनुच्छेद लाइनों के लिए फ़ॉन्ट संरेखण निर्धारित करता है।

## **पाठ की पारदर्शिता सेट करें**

पारदर्शिता को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे दिए गए उदाहरणों में, `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **पूरे अनुच्छेद** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पाठ के लिए अर्द्धपारदर्शी काला भराव सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी अनुच्छेद](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

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
        // पाठ भाग की पारदर्शिता सेट करें।
        portion.PortionFormat.FillFormat.FillType = FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
    }
}

presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या घटाने के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें। उदाहरण 3 पॉइंट का अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करते हैं।

निम्न C# कोड **पूरे अनुच्छेद** में अक्षर अंतराल को विस्तारित करने का तरीका दर्शाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// ध्यान दें: अक्षर अंतराल को संपीड़ित करने के लिए नकारात्मक मानों का उपयोग करें।
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतराल बढ़ाएँ.

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![अनुच्छेद में अक्षर अंतराल](character_spacing_in_paragraph.png)

कोड उदाहरण नीचे **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर अंतराल को विस्तारित करने का तरीका दर्शाता है:

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
        // ध्यान दें: अक्षर अंतराल को संपीड़ित करने के लिए नकारात्मक मानों का उपयोग करें.
        portion.PortionFormat.Spacing = 3;  // अक्षर अंतराल बढ़ाएँ.
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्टों के लिए करनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए पाठ से थोड़ा अधिक टाइट दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्टों के लिए करनिंग डेटा को अनदेखा करता है, भले ही फ़ॉन्ट में वैध करनिंग जानकारी हो और PowerPoint सेटिंग्स में करनिंग सक्षम हो।

ऐसे मामलों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिये, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए करनिंग अक्षम कर सकते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। इस उदाहरण में पहली स्लाइड की पहली आकृति में एक टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता है। यह प्रभावी फ़ॉन्ट नामों, विरासत में मिले फ़ॉन्टों सहित, को जांचता है और रोबोटो उपयोग करने वाले भागों के लिये 100‑पॉइंट थ्रेसहोल्ड सेट करता है। यह 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मेल खाते भागों के लिए करनिंग अक्षम करता है:

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

थ्रेसहोल्ड से नीचे के मेल खाते टेक्स्ट के लिये, यह सेटिंग करनिंग को रोकती है और Aspose.Slides रेंडरिंग को PowerPoint की दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है, जब यह PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्टों के लिये लागू होता है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को अनुच्छेद स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्न उदाहरण पहले अनुच्छेद के डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर अधिकता रखता है:

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

![अनुच्छेद के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक स्वरूपण और डॉटेड अंडरलाइन लागू करता है, जिनकी प्रभावी स्वरूपण बोल्ड है:

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

![पाठ भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ की ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्पलेट टाइपोग्राफी को दोहराते समय या अक्षर ऊँचाई में अंतर की जाँच करते समय [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से प्रत्येक अक्षर को लंबवत रूप से खींचा या संकुचित किया जाता है ताकि वह टेक्स्ट भाग के भीतर समान दृश्य ऊँचाई प्राप्त कर सके। यह विभिन्न फ़ॉन्टों में समान टेक्स्ट ऊँचाई की गारंटी नहीं देता।

[NullableBool.True or False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) को असाइन करके स्पष्ट रूप से सामान्यीकरण सक्षम या अक्षम किया जाता है। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट रखता है ताकि भाग पैराग्राफ के [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) से विरासत में मिले मान को ग्रहण करे। इसका अर्थ `False` नहीं है। हल किया गया बूलियन मान प्राप्त करने के लिये [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) और [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) पढ़ें।

निम्न स्वतंत्र उदाहरण **Arial** स्थापित होने पर कार्य करता है। यह दो टेक्स्ट ब्लॉकों को बनाता है जिनमें एक ही बड़े अक्षर, छोटे अक्षर, नीचे उतरने वाले अक्षर और उच्चारण चिह्न 54‑पॉइंट पर होते हैं। दोनों अनुच्छेद डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम करते हैं। शीर्ष भाग स्पष्ट रूप से इसे अक्षम करता है; नीचे वाला भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन और अनुच्छेद अंतराल समान हैं, रैपिंग और ऑटोफ़िट अक्षम हैं ताकि तुलना सुसंगत रहे। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" को सहेजता है।

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

नीचे की तुलना सहेजे गए प्रेज़ेंटेशन से निकाली गई है। शीर्ष पंक्ति में सामान्यीकरण अक्षम (`False`) है; नीचे वाली पंक्ति में यह विरासत में मिला (`NotDefined` → `True`) है। इस अभिव्यक्ति को पुन: उत्पन्न करने के लिये Arial स्थापित रखें।

![Arial 54‑पॉइंट टेक्स्ट, ऊपर सामान्यीकरण अक्षम और नीचे विरासत में मिला सामान्यीकरण सक्षम](text_height_normalization.png)

NormaliseHeight अक्षर की ऊँचाई को बदले बिना असाइन किए गए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) मान को बदले नहीं, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। अनुच्छेद [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) लाइन स्पेसिंग को नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) यह तय करता है कि टेक्स्ट या उसका कंटेनर फिट होने के लिये कैसे समायोजित हो। ये सेटिंग्स अलग‑अलग उद्देश्यों के लिये हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। अनुच्छेद स्वरूपण और विरासत के बारे में अधिक जानकारी के लिये देखें [परिच्छेद प्रबंधन](/slides/hi/net/manage-paragraph/).

## **स्ट्राइकथ्रू लागू करें और हटाएँ**

पाठ भाग पर स्ट्राइकथ्रू लागू करने के लिये [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) का उपयोग करें, जिससे आप सुधार, रद्द किए गए शब्द या पूर्व कीमतें बिना मूल पाठ को हटाए दिखा सकते हैं। इसे [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) पर सेट करके एक या दो रेखाएँ प्राप्त की जा सकती हैं।

स्ट्राइकथ्रू हटाने के लिये `TextStrikethroughType.None` असाइन करें। यह स्थानीय रूप से प्रभाव को स्पष्ट रूप से अक्षम करता है, भले ही आसपास का स्वरूपण स्ट्राइकथ्रू निर्दिष्ट करता हो। इसके विपरीत, `TextStrikethroughType.NotDefined` स्थानीय सेटिंग को अननिर्धारित रखता है, जिससे भाग पैराग्राफ आदि से विरासत में स्वरूपण ले सकता है। यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामी स्वरूपण, जिसमें विरासत में मिले मान भी शामिल हैं, पढ़ने के लिये [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) का उपयोग करें।

निम्न स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक अनुच्छेद में लेबल, पूर्व कीमत और वर्तमान कीमत के लिये अलग‑अलग भाग होते हैं, इसलिए केवल पूर्व कीमत प्रभावित होती है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियाँ क्रमशः एकल और डबल स्ट्राइकथ्रू बरकरार रखती हैं। इस गुण को बदलने से पाठ और उसका अन्य स्वरूपण, जैसे बोल्ड पूर्व कीमत, सुरक्षित रहता है।

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

// स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ.
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, और डबल स्ट्राइकथ्रू।

![पिछले मूल्यों बिना स्ट्राइकथ्रू के, एकल स्ट्राइकथ्रू के साथ, और डबल स्ट्राइकथ्रू के साथ](strikethrough.png)

## **पाठ का घूर्णन सेट करें**

शेप के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करने के लिये [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्न कोड उदाहरण शैप के भीतर पाठ अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) पर सेट करता है, जो पाठ को **90 डिग्री एंटिक्लॉकवाइज़** घुमाता है:

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

## **टेक्स्ट फ़्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) के लिये कस्टम घूर्णन एंगल सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण शैप के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमा देता है:

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

## **अनुच्छेदों की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है ताकि अनुच्छेद स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन की ऊँचाई के प्रतिशत के रूप में लाइन स्पेसिंग निर्दिष्ट करने हेतु सकारात्मक मान का उपयोग करें।
* पॉइंट में लाइन स्पेसिंग निर्दिष्ट करने हेतु नकारात्मक मान का उपयोग करें।

निम्न उदाहरण पहली अनुच्छेद के भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![अनुच्छेद के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

संकीर्ण टेक्स्ट ब्लॉकों और लैटिन व ईस्ट एशियन पाठ मिश्रित प्रस्तुतियों में अनुच्छेद लाइन‑ब्रेकिंग नियम उपयोगी होते हैं। ये गुण [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) से संबंधित हैं, इसलिए वे पूरे अनुच्छेद पर लागू होते हैं:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित पाठ में इसे बदलने से ईस्ट एशियन पाठ और विराम चिह्नों के रैपिंग स्थान भी बदल सकते हैं।
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में पात्रों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को बदलते नहीं हैं, जो टेक्स्ट फ्रेम के भीतर स्वचालित रैपिंग सक्षम करता है। वे रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक वर्ण नहीं डालते। एक स्पष्ट लाइन ब्रेक उपलब्ध चौड़ाई की परवाह किए बिना अनुच्छेद के भीतर नई पंक्ति उत्पन्न करता है।

निम्न स्वतंत्र उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन पाठ मिश्रित है। यह दोनों लाइन‑ब्रेकिंग गुणों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" को सहेजता है। नियम में से किसी एक को प्रयोग करने के लिये, दूसरे सेटिंग को अपरिवर्तित रखते हुए उस गुण का मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun को 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ उपयोग करता है। [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) पात्रों को टेक्स्ट लाइन के दाएँ किनारे से बाहर तक फैला सकती है, बजाय अगली पंक्ति में स्थान लेने के। यह पूरे अनुच्छेद पर लागू होता है और हेंगिंग इंडेंट से अलग है।

निम्न स्वतंत्र उदाहरण 100‑पॉइंट‑व्यापी टेक्स्ट फ़्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" को सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक फैला होता है। तुलना हेतु गुण को [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु एक अलग पंक्ति पर occupies करता है। रैपिंग सक्षम है और ऑटोफ़िट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम चिह्न हैंग नहीं कर सकता। उपर्युक्त [लाइन‑ब्रेकिंग](#control-line-breaking) अनुभाग में वर्णित फ़ॉन्ट और लेआउट शर्तें भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटोफ़िट सेटिंग बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ़्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमाओं से बाहर हो तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप निर्धारित कर सकते हैं कि टेक्स्ट छोटा हो, बहिर्वाहित हो, या आकार बदलकर आकृति को स्वतः फिट करे। निम्न उदाहरण शैप को उसके टेक्स्ट को फिट करने हेतु आकार बदलने के लिये कॉन्फ़िगर करता है और परिणाम को "autofit_type.pptx" में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

स्वचालित रैपिंग के बाद पंक्तियों की गिनती करने और यह देखने के लिये कि टेक्स्ट या शैप की चौड़ाई परिणाम को कैसे बदलती है, देखें [रेंडर की गई पंक्तियों की गिनती](/slides/hi/net/manage-paragraph/). पंक्तियों की संख्या अकेले यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ़्रेम की एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) निर्धारित करता है कि टेक्स्ट को आकृति के भीतर लंबवत कैसे स्थित किया जाता है, उदाहरण के लिये शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहली आकृति के नीचे एंकर करता है और परिणाम को "text_anchor.pptx" में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
```

## **टेक्स्ट टैब्यूलेशन सेट करें**

एक अनुच्छेद में टैब स्‍टॉप कॉन्फ़िगर करने के लिये [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्‍टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

![अनुच्छेद टैब](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जिससे आप किसी पाठ भाग की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिये उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण "presentation.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड की पहली आकृति में एक टेक्स्ट बॉक्स है और कम से कम एक अनुच्छेद है। यह पहले अनुच्छेद की सामग्री को "1。" में बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रमाणन भाषा के रूप में सरल चीनी (`zh-CN`) असाइन करता है। परिणाम को "proofing_language.pptx" में सहेजता है:

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

// प्रूफ़िंग भाषा को सरल चीनी पर सेट करें।
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करके प्रस्तुति लोड या निर्माण के दौरान निर्मित पाठ की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले पाठ भाग के लिये `en-US` प्रिंट करता है।

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// पाठ के साथ एक नया आयताकार आकार जोड़ें।
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// पहले भाग की भाषा जांचें।
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रेज़ेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिये [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में शीर्ष‑स्तरीय अनुच्छेदों के लिये 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// शीर्ष स्तर के पैराग्राफ स्वरूप प्राप्त करें।
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **All-Caps प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से पाठ स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसे पाठ भाग को प्राप्त करते हैं, लाइब्रेरी मूल दर्ज किया गया पाठ ही लौटाती है। प्रदर्शित पाठ से मेल खाने के लिये, [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को बड़े अक्षरों में बदल दें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड की पहली आकृति में एक टेक्स्ट बॉक्स है। उसके पहले अनुच्छेद के पहले भाग में All Caps प्रभाव लागू करके "Hello, Aspose!" जैसा पाठ होता है, जैसा कि नीचे दिखाया गया है।

![All Caps प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण **All Caps** प्रभाव लागू होने के साथ टेक्स्ट निकालने का तरीका दर्शाता है:

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

तालिका में टेक्स्ट संशोधित करने के लिये [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) का उपयोग करें। कोशिकाओं पर इटरेट करें और प्रत्येक कोशिका को [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) तथा अनुच्छेद स्वरूपण को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

ग्रेडिएंट रंग लागू करने के लिये [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा और पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फीचर: [स्लाइड्स में टेक्स्ट फ़ॉर्मेट करें](/slides/hi/features/text-formatting/).