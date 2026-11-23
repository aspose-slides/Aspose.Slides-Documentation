---
title: .NET में प्रस्तुति टेक्स्ट फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- पैराग्राफ संरेखित करना
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफिट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे फॉर्मैट किया जाता है। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

यदि अन्यथा उल्लेख न किया गया हो, तो उदाहरण [sample.pptx](sample.pptx) का उपयोग करते हैं। पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाया गया पाठ रखता है। स्लाइड और आकार दोनों के सूचकांक शून्य-आधारित होते हैं। वे उदाहरण जो बोल्ड भागों को चुनते हैं प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिला बोल्ड फॉर्मेटिंग शामिल है:

![उदाहरण पाठ](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मेल खोजने और उजागर करने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाईलाइट रंग सेट करने के लिए [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत टेक्स्ट भागों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के लिए डिफ़ॉल्ट रूप में हल्का ग्रे हाईलाइट सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाईलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेते हैं:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।

presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दर्शाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

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

## **पाठ पैराग्राफ संरेखित करें**

टेक्स्ट फ़्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान को मध्य, बाएँ-समाहित, दाएँ-समाहित, जस्टिफाइड आदि हो सकता है।

निम्नलिखित कोड उदाहरण दिखाता है कि पैराग्राफ को **केन्द्र** में कैसे संरेखित किया जाए:

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

## **लाइन के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकारों वाले टेक्स्ट भागों को लाइन के भीतर लंबवत संरेखित करने के लिए [IParagraphFormat.FontAlignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/fontalignment/) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ पर लागू होती है और प्रत्येक पंक्ति में संरेखण को नियंत्रित करती है।

निम्नलिखित स्वतंत्र उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ में 18, 36, और 54 पॉइंट का समान पाठ होता है, विभिन्न फ़ॉन्ट संरेखण के साथ। यह Arial का उपयोग करता है, ऑटॉफिट और रैपिंग को अक्षम करता है, और टेक्स्ट फ़्रेम को एकल लाइन के लिए पर्याप्त बड़ा रखता है।

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

![बेसलाइन, शीर्ष, केंद्र, और नीचे फ़ॉन्ट संरेखण की तुलना](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक्स पर आधारित होता है, इसलिए व्यक्तिगत अक्षरों के दृश्यमान किनारे सटीक रूप से नहीं मिल सकते। उदाहरण में एक बड़े अक्षर और एक डिसेंडर शामिल है ताकि बेसलाइन और नीचे संरेखण के बीच अंतर दिखाया जा सके। फ़ॉन्ट उपलब्धता और प्रतिस्थापन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकारों में अंतर परिणाम को प्रभावित करते हैं। फ़्रेम आयाम, मार्जिन, लाइन स्पेसिंग, रैपिंग, और ऑटॉफिट भी लेआउट को प्रभावित करते हैं; तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण नियंत्रित करता है, और [ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) से, जो टेक्स्ट ब्लॉक को आकार के भीतर लंबवत स्थित करता है। [IBasePortionFormat.Escapement](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/escapement/) के माध्यम से सुपरस्क्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत भागों को बेसलाइन के सापेक्ष शिफ्ट करती है, न कि पैराग्राफ की लाइनों के लिए फ़ॉन्ट संरेखण सेट करती है।

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर पारदर्शिता कैसे लागू की जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var alpha = 50;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// पाठ के लिए अर्धपारदर्शी काला भराव सेट करें।
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता कैसे लागू की जाए:

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

## **पाठ के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को बढ़ाने या घटाने के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें। उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को घटाते हैं।

नीचे दिया गया C# कोड दिखाता है कि **पूरे पैराग्राफ** में अक्षर अंतराल कैसे बढ़ाया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

// नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतराल को बढ़ाएँ।

presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल कैसे बढ़ाया जाए:

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
        // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
        portion.PortionFormat.Spacing = 3;  // अक्षर अंतराल को बढ़ाएँ।
    }
}

presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक कसाव वाला दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसी परिस्थितियों में रेंडर किया गया आउटपुट PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग को अक्षम कर सकते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से बड़े मान पर सेट करें। यह उदाहरण "presentation.pptx" के साथ एक टेक्स्ट बॉक्स की आवश्यकता रखता है, जो पहली स्लाइड पर पहला आकार है। यह प्रभावी फ़ॉन्ट नामों की जाँच करता है, जिसमें विरासत में मिले फ़ॉन्ट शामिल हैं, और Roboto का उपयोग करने वाले भागों के लिए 100‑पॉइंट थ्रेशहोल्ड सेट करता है। यह 100 पॉइंट से कम फ़ॉन्ट आकार वाले मेल खाते भागों के लिए केरनिंग को अक्षम करता है:

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

थ्रेशहोल्ड से नीचे के मेल खाते पाठ के लिए, यह सेटिंग केरनिंग को रोकती है और Aspose.Slides रेंडरिंग को उन फ़ॉन्ट्स के लिए PowerPoint के दृश्य आउटपुट के साथ संरेखित करने में मदद कर सकती है जो इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित होते हैं।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्नलिखित उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman सेट करता है, जिसमें बोल्ड, इटालिक, और डॉटेड अंडरलाइन फॉर्मेटिंग है। व्यक्तिगत भागों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स पर प्राथमिकता लेती है:

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

निम्नलिखित उदाहरण 13‑पॉइंट Times New Roman, इटालिक फॉर्मेटिंग, और डॉटेड अंडरलाइन को उन भागों पर लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

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

## **पाठ ऊँचाई सामान्यीकरण नियंत्रित करें**

टेम्प्लेट टाइपोग्राफी को दोहराते समय या अक्षर ऊँचाई में अंतर का अध्ययन करने के लिए [IBasePortionFormat.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/normaliseheight/) का उपयोग करें। PowerPoint में, सामान्यीकरण को सक्षम करने से व्यक्तिगत अक्षरों को लंबवत खींचा या संकुचित किया जाता है ताकि वे टेक्स्ट भाग के भीतर समान दृश्यमान ऊँचाई प्राप्त कर सकें। यह विभिन्न फ़ॉन्ट्स के बीच समान पाठ ऊँचाई की गारंटी नहीं देता।

गुण को [NullableBool.True या False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करें ताकि स्पष्ट रूप से सामान्यीकरण सक्षम या अक्षम हो। `NullableBool.NotDefined` स्थानीय सेटिंग को अनसेट छोड़ देता है ताकि भाग पैराग्राफ के [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) से अपना मान विरासत में ले। इसका अर्थ `False` नहीं है। [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) और [IBasePortionFormatEffectiveData.NormaliseHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformateffectivedata/normaliseheight/) का उपयोग करके हल किए गए Boolean मान को प्राप्त करें।

निम्नलिखित स्वतंत्र उदाहरण **Arial** स्थापित होने की आवश्यकता रखता है। यह दो टेक्स्ट ब्लॉक बनाता है जिसमें समान बड़े अक्षर, छोटे अक्षर, डिसेंडर, और उच्चारण वाले अक्षर 54 पॉइंट पर होते हैं। दोनों पैराग्राफ डिफ़ॉल्ट रूप से सामान्यीकरण सक्षम रखते हैं। शीर्ष भाग स्पष्ट रूप से इसे अक्षम करता है; नीचे का भाग इसे विरासत में लेता है। फ्रेम आकार, मार्जिन, और पैराग्राफ अंतराल समान हैं, रैपिंग और ऑटॉफिट अक्षम हैं ताकि तुलना निरंतर रहे। उदाहरण `False: False` और `NotDefined: True` प्रिंट करता है, फिर "text_height_normalization.pptx" सहेजता है।

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

नीचे की तुलना सहेजे गए प्रस्तुति से निर्यात की गई थी। ऊपर की पंक्ति में सामान्यीकरण अक्षम है (`False`); नीचे की पंक्ति ने सक्षम सेटिंग को विरासत में लिया है (`NotDefined` → `True`)। इस रूप को पुनः प्राप्त करने के लिए Arial स्थापित रखें।

![Arial 54‑पॉइंट पाठ जिसमें ऊपर सामान्यीकरण अक्षम और नीचे विरासत में सामान्यीकरण सक्षम](text_height_normalization.png)

सामान्यीकरण अक्षर की ऊँचाई को बदलता है बिना असाइन किए गए [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) मान को बदले, जो फ़ॉन्ट आकार को पॉइंट में निर्दिष्ट करता है। पैराग्राफ का [SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) लाइन स्पेसिंग नियंत्रित करता है, जबकि टेक्स्ट‑फ़्रेम का [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) नियंत्रित करता है कि टेक्स्ट या उसका कंटेनर आकार कैसे फिट करने के लिए समायोजित हो। ये सेटिंग्स अलग उद्देश्यों की सेवा करती हैं और कुल लेआउट को स्वतंत्र रूप से प्रभावित कर सकती हैं। पैराग्राफ फॉर्मेटिंग और विरासत के अधिक विवरण के लिए देखें [Manage Paragraph](/slides/hi/net/manage-paragraph/)।

## **स्ट्राइकथ्रू लागू करें और हटाएं**

टेक्स्ट भाग पर [IBasePortionFormat.StrikethroughType](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/strikethroughtype/) का उपयोग करके सुधार, रद्द शर्तें, या पिछले मूल्यों को मूल पाठ को हटाए बिना दिखाया जा सकता है। टेक्स्ट पर एक या दो रेखाएँ लगाने के लिए इसे [TextStrikethroughType.Single या Double](https://reference.aspose.com/slides/net/aspose.slides/textstrikethroughtype/) पर सेट करें।

स्ट्राइकथ्रू हटाने के लिए `TextStrikethroughType.None` असाइन करें। इससे प्रभाव स्पष्ट रूप से अक्षम हो जाता है, भले ही आस‑पास का फॉर्मेटिंग स्ट्राइकथ्रू निर्दिष्ट करे। इसके विपरीत, `TextStrikethroughType.NotDefined` स्थानीय सेटिंग को अनपरिभाषित छोड़ देता है, जिससे भाग को पैराग्राफ से जैसे विरासत में फ़ॉर्मेटिंग मिल सके। यह यह गारंटी नहीं देता कि स्ट्राइकथ्रू हट गया है। परिणामस्वरूप फॉर्मेटिंग, जिसमें विरासत मान शामिल हैं, पढ़ने के लिए [IPortionFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) का उपयोग करें।

निम्नलिखित स्वतंत्र उदाहरण तीन मूल्य तुलना बनाता है। प्रत्येक पैराग्राफ में लेबल, पूर्व मूल्य, और वर्तमान मूल्य के लिए अलग-अलग भाग होते हैं, जिससे केवल पूर्व मूल्य प्रभावित होता है। पहली पंक्ति स्ट्राइकथ्रू लागू करती है और फिर हटाती है; अन्य पंक्तियों में एकल और दोहरी स्ट्राइकथ्रू रहता है। इस गुण को बदलने से पाठ और उसके अन्य फॉर्मेटिंग, जिसमें बोल्ड पूर्व मूल्य शामिल है, सुरक्षित रहता है।

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

// स्ट्राइकथ्रू लागू करें, फिर पहले पिछले मूल्य से इसे स्पष्ट रूप से हटाएँ।
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[0].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.None;

paragraphs[1].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Single;
paragraphs[2].Portions[1].PortionFormat.StrikethroughType = TextStrikethroughType.Double;

presentation.Save("strikethrough.pptx", SaveFormat.Pptx);
```

परिणाम, ऊपर से नीचे: कोई स्ट्राइकथ्रू नहीं, एकल स्ट्राइकथ्रू, दोहरी स्ट्राइकथ्रू।

![पिछले मूल्य बिना स्ट्राइकथ्रू, एकल स्ट्राइकथ्रू, दोहरी स्ट्राइकथ्रू](strikethrough.png)

## **टेक्स्ट घूर्णन सेट करें**

एक आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्नलिखित कोड उदाहरण आकार में टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लॉकवाइज़** घुमाता है:

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

## **ऊर्ध्वाधर टेक्स्ट में अंकों को एक साथ दिखाएं**

ऊर्ध्वाधर जापानी लेबल में दो‑अंकीय संख्या को साथ रखने के लिए, दोनों अंकों को एक टेक्स्ट भाग में रखें और उस भाग पर [IBasePortionFormat.Kumimoji](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/kumimoji/) सेट करें। उदाहरण दोनों लेबल के लिए [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/net/aspose.slides/textverticaltype/) और 40‑पॉइंट MS Gothic का उपयोग करता है। केवल संख्यात्मक भाग को सौंपे गए [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) का मान अलग है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

AddLabel(slide, 120, NullableBool.True);
AddLabel(slide, 360, NullableBool.False);

presentation.Save("vertical_date.pptx", SaveFormat.Pptx);

static void AddLabel(ISlide slide, float x, NullableBool kumimoji)
{
    var label = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
    label.FillFormat.FillType = FillType.NoFill;
    label.LineFormat.FillFormat.FillType = FillType.NoFill;

    var frame = label.AddTextFrame("");
    frame.TextFrameFormat.TextVerticalType = TextVerticalType.EastAsianVertical;

    var paragraph = frame.Paragraphs[0];
    var format = paragraph.ParagraphFormat.DefaultPortionFormat;
    var font = new FontData("MS Gothic");
    format.LatinFont = font;
    format.EastAsianFont = font;
    format.FontHeight = 40;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

    var digits = new Portion("12");
    digits.PortionFormat.Kumimoji = kumimoji;
    
    paragraph.Portions.Clear();
    paragraph.Portions.Add(new Portion("令和"));
    paragraph.Portions.Add(digits);
    paragraph.Portions.Add(new Portion("年"));
}
```

PowerPoint में, बायां लेबल (`True`) अंक को सीधे और 和 और 年 के बीच एक साथ दिखाता है। दायां लेबल (`False`) में अंक 90 डिग्री क्लॉकवाइज़ घुमाए जाते हैं। आसपास के जापानी अक्षर दोनों लेबल में सीधे ही रहते हैं।

![ऊर्ध्वाधर तिथि लेबल तुलना जिसमें बाएं में सीधी अंक और दाएं में घुंमे हुए अंक](vertical_date.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करने के लिए [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करें।

नीचे दिया गया कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

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

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है ताकि पैराग्राफ अंतराल नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* पॉज़िटिव मान का उपयोग करके लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करें।
* नैगेटिव मान का उपयोग करके लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करें।

निम्नलिखित उदाहरण पहले पैराग्राफ के भीतर अंतराल को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

संकीर्ण टेक्स्ट ब्लॉकों और लैटिन तथा ईस्ट एशियन टेक्स्ट के मिश्रण वाले प्रस्तुतियों में पैराग्राफ लाइन‑ब्रेकिंग नियम उपयोगी होते हैं। निम्नलिखित गुण [IParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/) के अंतर्गत आते हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [LatinLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/latinlinebreak/) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से निकटवर्ती ईस्ट एशियन टेक्स्ट और विराम चिह्नों की रैपिंग भी बदल सकती है।
- [EastAsianLineBreak](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/eastasianlinebreak/) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें एक लाइन की शुरुआत और अंत में अक्षरों पर प्रतिबंध शामिल हैं।

ये नियम [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ़्रेम के भीतर स्वचालित रैपिंग को सक्षम करता है। रैपिंग होने पर वे लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक अक्षर नहीं डालते। स्पष्ट लाइन ब्रेक पैराग्राफ के भीतर उपलब्ध चौड़ाई से स्वतंत्र रूप से नई पंक्ति बनाता है।

निम्नलिखित स्वतंत्र उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट होता है। यह दोनों लाइन‑ब्रेकिंग गुणों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। प्रत्येक नियम का प्रयोग करने के लिए, उस गुण के मान को बदलें जबकि अन्य सेटिंग्स को समान रखें। यह उदाहरण 24‑पॉइंट Arial और SimSun का उपयोग करता है, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ। [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) को [TextAutofitType.None](https://reference.aspose.com/slides/net/aspose.slides/textautofittype/) पर सेट किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

## **हैंगिंग पंचुएशन नियंत्रित करें**

[IParagraphFormat.HangingPunctuation](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/hangingpunctuation/) योग्य पंचुएशन को टेक्स्ट लाइन के दाएँ किनारे से आगे बढ़ाता है बजाय अगले लाइन में ले जाने के। यह पूरे पैराग्राफ पर लागू होता है और हैंगिंग इंडेंट से अलग है।

निम्नलिखित स्वतंत्र उदाहरण 100‑पॉइंट चौड़े टेक्स्ट फ़्रेम में हैंगिंग पंचुएशन को सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम पूर्णविराम "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से आगे बढ़ जाता है। गुण को [NullableBool.False](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) पर सेट करके तुलना करें: इन सेटिंग्स के साथ, पूर्णविराम अलग लाइन में स्थित होता है। रैपिंग सक्षम है और ऑटॉफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर पंचुएशन मार्क हैंग नहीं हो सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) इस तुलना पर भी लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन, या ऑटॉफिट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि जब टेक्स्ट कंटेनर की सीमाओं से बाहर हो तो वह कैसे व्यवहार करता है। इसका उपयोग यह नियंत्रित करने के लिए किया जाता है कि टेक्स्ट आकार घटे, ओवरफ़्लो हो, या आकार को स्वचालित रूप से रिसाइज़ करे। निम्नलिखित उदाहरण आकार को उसके टेक्स्ट के अनुसार रिसाइज़ करने के लिए कॉन्फ़िगर करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var autoShape = (IAutoShape)slide.Shapes[0];
autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
```

स्वचालित रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या आकार की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/net/manage-paragraph/). लाइनों की गिनती अकेले यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/anchoringtype/) परिभाषित करता है कि टेक्स्ट आकार के भीतर लंबवत कैसे स्थित हो, जैसे शीर्ष, मध्य, या नीचे। निम्नलिखित उदाहरण टेक्स्ट को पहले आकार के नीचे के हिस्से में एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

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

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें। निम्नलिखित उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट सेट करता है और 30 पॉइंट पर बाएँ‑समाहित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जो आपको एक टेक्स्ट भाग के लिए प्रूफिंग भाषा सेट करने देता है। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित उदाहरण को "presentation.pptx" चाहिए, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स हो और कम से कम एक पैराग्राफ हो। यह पहला पैराग्राफ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और Simplified Chinese प्रूफिंग भाषा (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजता है:

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

// प्रूफिंग भाषा को सरल चीनी पर सेट करें।
textPortion.PortionFormat.LanguageId = "zh-CN";

textPortion.Text = "1。";
paragraph.Portions.Add(textPortion);

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

### **भाषा मेटाडाटा कॉपी करें**

टेम्प्लेट से बहु‑भाषी टेक्स्ट कॉपी करते समय, [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) और [IBasePortionFormat.AlternativeLanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/alternativelanguageid/) दोनों को संरक्षित रखें। निम्नलिखित स्वतंत्र उदाहरण स्रोत भाग को US English को उसकी भाषा और French को वैकल्पिक भाषा के साथ बनाता है और टेक्स्ट तथा पहचानकर्ताओं को नई प्रस्तुति के भाग में कॉपी करता है।

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
    // यदि स्रोत में कोई वैकल्पिक भाषा नहीं है, तो null गंतव्य मान को साफ़ कर देता है।
destination.PortionFormat.AlternativeLanguageId = source.PortionFormat.AlternativeLanguageId;
paragraph.Portions.Add(destination);

presentation.Save("copied_language_metadata.pptx", SaveFormat.Pptx);
```

वैकल्पिक भाषा के बिना स्रोत आज़माने के लिए, "fr-FR" असाइनमेंट को हटाएँ। वैकल्पिक पहचानकर्ता तब `null` रहेगा, और वही कॉपी स्टेटमेंट उसकी अनुपस्थिति को बनाए रखेगा बिना डिफ़ॉल्ट मान डाले, भले ही गंतव्य में पहले वैकल्पिक भाषा असाइन की गई हो।

इन पहचानकर्ताओं को भाषा मेटाडाटा के रूप में संग्रहित किया जाता है। उन्हें संरक्षित करने से यह निर्धारित नहीं होता कि PowerPoint वर्तनी या व्याकरण जांच के लिए किस शब्दकोश का चयन करता है।

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करके प्रस्तुतीकरण लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा परिभाषित करें। निम्नलिखित उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के साथ एक प्रस्तुतीकरण बनाता है, टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

```cs
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];

// नया आयताकार आकार टेक्स्ट के साथ जोड़ें।
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
shape.TextFrame.Text = "Sample text";

// पहले भाग की भाषा जाँचें।
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine(portion.PortionFormat.LanguageId);
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुतीकरण स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए, [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्नलिखित उदाहरण नई प्रस्तुतीकरण में शीर्ष‑स्तर पैराग्राफ के लिए डिफ़ॉल्ट रूप में 14‑पॉइंट बोल्ड फ़ॉन्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फॉर्मेटिंग उन्हें अभिलेखित न कर दे।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
// शीर्ष स्तर पैराग्राफ फॉर्मेट प्राप्त करें।
var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

if (paragraphFormat != null)
{
    paragraphFormat.DefaultPortionFormat.FontHeight = 14;
    paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
}

presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में, **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर टेक्स्ट बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग निकालते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी तरह वापस करती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/net/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो वापस स्ट्रिंग को बड़े अक्षरों में परिवर्तित करें।

यह उदाहरण "sample2.pptx" की आवश्यकता रखता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। इसके पहले पैराग्राफ के पहले भाग में "Hello, Aspose!" है, जिस पर All Caps इफ़ेक्ट लागू है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू किए हुए टेक्स्ट को कैसे निकालें:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर एक टेबल में टेक्स्ट को कैसे संशोधित करूँ?**

स्लाइड पर टेबल में टेक्स्ट को संशोधित करने के लिए, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) का उपयोग करें। सेल्स के माध्यम से इटररेट करें और प्रत्येक सेल को [ICell.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) के माध्यम से अपडेट करें तथा पैराग्राफ फॉर्मेटिंग को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए, [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।

संबंधित फीचर: [स्लाइड में टेक्स्ट फॉर्मेट करें](/slides/hi/features/text-formatting/).