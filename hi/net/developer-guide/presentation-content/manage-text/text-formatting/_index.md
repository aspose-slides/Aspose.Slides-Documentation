---
title: ".NET में प्रस्तुति टेक्स्ट को फ़ॉर्मेट करें"
linktitle: "टेक्स्ट फ़ॉर्मेटिंग"
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- पैराग्राफ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट ट्रांसपरेंसी
- कैरेक्टर स्पेसिंग
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट रोटेशन
- रोटेशन एंगल
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटोफ़िट गुण
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफॉल्ट भाषा
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और स्टाइल करें। फ़ॉन्ट, रंग, संरेखण और अधिक को कस्टमाइज़ करें।"
---
## **परिचय**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट करने का तरीका दर्शाता है। इसमें पृष्ठभूमि रंग, ट्रांसपरेंसी, कैरेक्टर स्पेसिंग, फ़ॉन्ट गुण, रोटेशन, पैराग्राफ स्पेसिंग, ऑटोफ़िट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप और भाषा सेटिंग्स शामिल हैं।

नीचे दिए गए उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एक एकल टेक्स्ट बॉक्स है जिसमें निम्नलिखित टेक्स्ट है:

![नमूना पाठ](sample_text.png)

लिटरल टेक्स्ट या रेगुलर‑एक्सप्रेशन मैच को खोजने और हाइलाइट करने के लिए देखें[पाठ खोजें और बदलें](/slides/hi/net/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** के लिए पृष्ठभूमि रंग कैसे सेट किया जाता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.HighlightColor.Color = Color.LightGray;

    presentation.Save("gray_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
                // टेक्स्ट हिस्से के लिए हाइलाइट रंग सेट करें।
                portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ‑साइड, दाएँ‑साइड, जैस्टिफ़ाइड आदि हो सकता है।

निम्न कोड उदाहरण दिखाता है कि पैराग्राफ को **केंद्र** में कैसे संरेखित किया जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पैराग्राफ का संरेखण केंद्रित सेट करें।
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **टेक्स्ट के लिए ट्रांसपरेंसी सेट करें**

ट्रांसपरेंसी को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) को असाइन किए गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ** पर ट्रांसपरेंसी कैसे लागू की जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // टेक्स्ट का भराव रंग पारदर्शी रंग पर सेट करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![ट्रांसपेरेंट पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर ट्रांसपरेंसी कैसे लागू की जाए:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

परिणाम:

![ट्रांसपेरेंट टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए कैरेक्टर स्पेसिंग सेट करें**

पैराग्राफ बॉक्स में अक्षरों के बीच स्पेसिंग वृद्धि या कमी के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें।

निम्न C# कोड दिखाता है कि **पूरे पैराग्राफ** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ध्यान दें: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // कैरेक्टर स्पेसिंग बढ़ाएँ।

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ में कैरेक्टर स्पेसिंग](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** में कैरेक्टर स्पेसिंग कैसे विस्तारित की जाए:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // नोट: कैरेक्टर स्पेसिंग को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.PortionFormat.Spacing = 3;  // कैरेक्टर स्पेसिंग बढ़ाएँ।
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टेक्स्ट हिस्सों में कैरेक्टर स्पेसिंग](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए कर्निंग निष्क्रिय करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में दिखाए गए समान टेक्स्ट से थोड़ा कसकर दिख सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए कर्निंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध कर्निंग जानकारी हो और PowerPoint सेटिंग्स में कर्निंग सक्षम हो।

ऐसे मामलों में रेंडरिंग को PowerPoint के करीब लाने के लिए आप प्रभावित फ़ॉन्ट का उपयोग करने वाले टेक्स्ट हिस्सों के लिए कर्निंग को निष्क्रिय कर सकते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var targetFont = "Roboto";

    foreach (var paragraph in autoShape.TextFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            if ((portion.PortionFormat.LatinFont != null &&
                 portion.PortionFormat.LatinFont.FontName == targetFont) ||
                (portion.PortionFormat.EastAsianFont != null &&
                 portion.PortionFormat.EastAsianFont.FontName == targetFont) ||
                (portion.PortionFormat.ComplexScriptFont != null &&
                 portion.PortionFormat.ComplexScriptFont.FontName == targetFont))
            {
                portion.PortionFormat.KerningMinimalSize = 100;
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

यह सेटिंग मिलते‑जुलते टेक्स्ट हिस्सों में कर्निंग लागू होने से रोकती है और ऐसे फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के विज़ुअल आउटपुट के साथ संरेखित करने में मदद करती है।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत हिस्सों पर [IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/) के माध्यम से सेट किए जा सकते हैं।

निम्न कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और टेक्स्ट शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, तथा Times New Roman फ़ॉन्ट को सभी हिस्सों में लागू करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 12;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontItalic = NullableBool.True;
    paragraph.ParagraphFormat.DefaultPortionFormat.FontUnderline = TextUnderlineType.Dotted;
    paragraph.ParagraphFormat.DefaultPortionFormat.LatinFont = new FontData("Times New Roman");

    presentation.Save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न कोड उदाहरण समान गुण **बोल्ड फ़ॉन्ट वाले टेक्स्ट हिस्सों** पर लागू करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें।
            portion.PortionFormat.FontHeight = 13;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontUnderline = TextUnderlineType.Dotted;
            portion.PortionFormat.LatinFont = new FontData("Times New Roman");
        }
    }

    presentation.Save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टेक्स्ट हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट रोटेशन सेट करें**

शेप के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को `Vertical270` पर सेट करता है, जिससे टेक्स्ट **90 डिग्री प्रतिक्लॉकवाइस** घुमता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टेक्स्ट रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम्स के लिए कस्टम रोटेशन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के लिए कस्टम रोटेशन एंगल सेट करें।

निम्न कोड उदाहरण शैप के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइस घुमाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है जिससे पैराग्राफ स्पेसिंग नियंत्रित होती है। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट्स में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्न कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग निर्दिष्ट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ में लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम्स के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमाओं को पार कर जाता है तो टेक्स्ट कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो हो, या शैप स्वतः री‑साइज़ हो।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

ऑटोमैटिक रैपिंग के बाद लाइनों की गिनती करने और यह देखने के लिए कि टेक्स्ट या शैप की चौड़ाई बदलने पर परिणाम कैसे होता है, देखें[रेंडर की गई लाइनों की गिनती](/slides/hi/net/manage-paragraph/)। केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर को ओवरफ़्लो कर रहा है या नहीं।

## **टेक्स्ट फ्रेम्स की एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/anchoringtype/) निर्धारित करता है कि शैप के भीतर टेक्स्ट लंबवत रूप से शीर्ष, मध्य या नीचे किस स्थान पर स्थित है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.DefaultTabSize = 100;
    paragraph.ParagraphFormat.Tabs.Add(30, TabAlignment.Left);

    presentation.Save("paragraph_tabs.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जिससे आप टेक्स्ट हिस्से की प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में स्पेलिंग और ग्रामर जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न कोड उदाहरण टेक्स्ट हिस्से के लिए प्रूफ़िंग भाषा सेट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("presentation.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    var font = new FontData("SimSun");

    var textPortion = new Portion();
    textPortion.PortionFormat.ComplexScriptFont = font;
    textPortion.PortionFormat.EastAsianFont = font;
    textPortion.PortionFormat.LatinFont = font;

    // प्रूफ़िंग भाषा की Id सेट करें.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **डिफॉल्ट भाषा सेट करें**

लोड या नई प्रस्तुति बनाते समय निर्मित टेक्स्ट की डिफॉल्ट भाषा को परिभाषित करने के लिए [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करें।

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // एक नया आयताकार आकार टेक्स्ट के साथ जोड़ें.
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // पहला हिस्से की भाषा जांचें.
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **डिफॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/defaulttextstyle/) का प्रयोग करें।

निम्न कोड उदाहरण नई प्रस्तुति की सभी स्लाइड्स में सभी टेक्स्ट के लिए 14 pt आकार का डिफॉल्ट बोल्ड फ़ॉन्ट सेट करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें.
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **ऑल‑कैप्स प्रभाव के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखाई देता है, भले ही मूल रूप से वह छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट हिस्सा प्राप्त करते हैं, तो लाइब्रेरी वही टेक्स्ट लौटाती है जो दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/net/aspose.slides/textcaptype/) की जाँच करें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अप्परकेस में बदलें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल‑कैप्स प्रभाव](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** प्रभाव लागू किए हुए टेक्स्ट को कैसे निकालें:

```cs
using Aspose.Slides;

using (var presentation = new Presentation("sample2.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textPortion = autoShape.TextFrame.Paragraphs[0].Portions[0];

    Console.WriteLine($"Original text: {textPortion.Text}");

    var textFormat = textPortion.PortionFormat.GetEffective();
    if (textFormat.TextCapType == TextCapType.All)
    {
        var text = textPortion.Text.ToUpper();
        Console.WriteLine($"All-Caps effect: {text}");
    }
}
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड पर तालिका में टेक्स्ट को कैसे संशोधित करें?**

स्लाइड पर तालिका में टेक्स्ट संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) का उपयोग करें। सेल्स पर इटररेट करें और प्रत्येक सेल को [ICell.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/textframe/) के माध्यम से अपडेट करें तथा पैराग्राफ फ़ॉर्मेट को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में टेक्स्ट पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप्स, दिशा और ट्रांसपरेंसी को कॉन्फ़िगर करें।