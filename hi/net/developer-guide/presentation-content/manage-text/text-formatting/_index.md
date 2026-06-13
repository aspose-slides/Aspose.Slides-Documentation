---
title: .NET में प्रस्तुति पाठ को फ़ॉर्मेट करें
linktitle: पाठ स्वरूपण
type: docs
weight: 50
url: /hi/net/text-formatting/
keywords:
- हाइलाइट टेक्स्ट
- नियमित अभिव्यक्ति
- पैराग्राफ संरेखित करें
- पाठ शैली
- पाठ पृष्ठभूमि
- पाठ पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घुमाव
- घुमाव कोण
- पाठ फ्रेम
- पंक्ति अंतराल
- ऑटोफिट गुण
- पाठ फ्रेम एंकर
- पाठ टैब्युलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **समीक्षा**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित करने का तरीका दिखाता है। इसमें हाइलाइटिंग, पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, अनुच्छेद अंतराल, ऑटोफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप और भाषा सेटिंग शामिल हैं।

नीचे दिए गए उदाहरणों में, हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल पाठ बॉक्स है जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

## **पाठ को हाइलाइट करें**

जब आपको टेक्स्ट फ्रेम में किसी विशिष्ट नमूने से मेल खाने वाले पाठ को हाइलाइट करने की आवश्यकता हो तो आप [ITextFrame.HighlightText](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlighttext/) मेथड का उपयोग करें। यह मेथड मिलते हुए पाठ अंशों पर हाइलाइट रंग लागू करता है और इसे [TextSearchOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/textsearchoptions/) के साथ उपयोग करके खोज के तरीके को नियंत्रित किया जा सकता है, उदाहरण के लिए केवल पूर्ण शब्दों से मेल करने के लिए।

नीचे दिया गया कोड उदाहरण अक्षरों **"try"** की सभी उपस्थितियों को हाइलाइट करता है और फिर केवल पूर्ण शब्द **"to"** को हाइलाइट करता है।

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    // पहली स्लाइड से पहला आकार प्राप्त करें।
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    // आकार में शब्द "try" को हाइलाइट करें।
    shape.TextFrame.HighlightText("try", Color.LightBlue);

    var searchOptions = new TextSearchOptions()
    {
        WholeWordsOnly = true
    };

    // आकार में शब्द "to" को हाइलाइट करें।
    shape.TextFrame.HighlightText("to", Color.Violet, searchOptions, null);

    presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![हाइलाइट किया गया पाठ](highlighted_text.png)

## **नियमित अभिव्यक्तियों का उपयोग करके पाठ को हाइलाइट करें**

[ITextFrame.HighlightRegex](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/highlightregex/) मेथड नियमित अभिव्यक्ति द्वारा पाए गए पाठ मिलानों को हाइलाइट करता है। .NET में यह API [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) पर उपलब्ध है।

नीचे दिया गया कोड उदाहरण उन सभी शब्दों को हाइलाइट करता है जिनमें **सात या अधिक अक्षर** हैं:

```cs
using (var presentation = new Presentation(folderPath + "sample.pptx"))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];

    var regex = new Regex(@"\b[^\s]{7,}\b");

    // सात या अधिक अक्षरों वाले सभी शब्दों को हाइलाइट करें।
    shape.TextFrame.HighlightRegex(regex, Color.Yellow, null);

    presentation.Save(folderPath + "highlighted_text_using_regex.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![नियमित अभिव्यक्ति का उपयोग करके हाइलाइट किया गया पाठ](highlighted_text_using_regex.png)

## **पाठ की पृष्ठभूमि रंग सेट करें**

पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [IPortionFormat.HighlightColor](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/highlightcolor/) का उपयोग करें।

निम्नलिखित कोड उदाहरण **संपूर्ण पैराग्राफ** के पृष्ठभूमि रंग को सेट करने का तरीका दर्शाता है:

```cs
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

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** के पृष्ठभूमि रंग को सेट करने का प्रदर्शन करता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

परिणाम:

![ग्रे पाठ भाग](gray_text_portions.png)

## **पाठ अनुच्छेदों को संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ संरेखित, दाएँ संरेखित, दोनों ओर समान आदि हो सकता है।

निम्नलिखित कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दिखाता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पैराग्राफ की संरेखण को केंद्र में सेट करें।
    paragraph.ParagraphFormat.Alignment = TextAlignment.Center;

    presentation.Save("aligned_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![सजाया गया पैराग्राफ](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IPortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/fillformat/) को सौंपे गए रंग के अल्फा घटक द्वारा नियंत्रित किया जाता है। नीचे के उदाहरणों में, `alpha = 50` 0–255 स्केल पर ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे दिया गया कोड उदाहरण **संपूर्ण पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पाठ का भरने वाला रंग पारदर्शी रंग पर सेट करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

```cs
int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
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
}
```

परिणाम:

![पारदर्शी पाठ भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें।

निम्नलिखित C# कोड **संपूर्ण पैराग्राफ** में अक्षर अंतराल को विस्तारित करने का तरीका दर्शाता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतराल बढ़ाएँ.

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** में अक्षर अंतराल को विस्तारित करने का तरीका दिखाता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.PortionFormat.Spacing = 3;  // अक्षर अंतराल बढ़ाएँ।
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पाठ भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग को अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले समान पाठ से थोड़ा अधिक कसकर दिख सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप प्रभावित फ़ॉन्ट का उपयोग करने वाले पाठ भागों के लिए केरनिंग को अक्षम कर सकते हैं। [IPortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से काफी बड़ा मान सेट करें:

```cs
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

यह सेटिंग मेल खाने वाले पाठ भागों पर केरनिंग को लागू होने से रोकती है और फ़ॉन्ट्स के लिए PowerPoint‑विशिष्ट व्यवहार को संतुलित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत भागों पर [IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/) द्वारा सेट किया जा सकता है।

निम्नलिखित कोड पैराग्राफ के पूरे हिस्से के लिए फ़ॉन्ट और पाठ शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को सभी भागों पर लागू करता है।

```cs
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

![पैराग्राफ के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ भागों** पर समान गुण लागू करता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    foreach (var portion in paragraph.Portions)
    {
        if (portion.PortionFormat.GetEffective().FontBold)
        {
            // पाठ भाग के लिए फ़ॉन्ट गुण सेट करें।
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

![पाठ भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ के घुमाव को सेट करें**

आकार के भीतर पूर्वपरिभाषित पाठ अभिविन्यास सेट करने के लिए [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्नलिखित कोड उदाहरण आकार में पाठ अभिविन्यास को `Vertical270` पर सेट करता है, जिससे पाठ **90 डिग्री घड़ी की विपरीत दिशा में** घुमता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.TextVerticalType = TextVerticalType.Vertical270;

    presentation.Save("text_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पाठ घुमाव](text_rotation.png)

## **पाठ फ्रेम के लिए कस्टम घुमाव सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के लिए कस्टम घुमाव कोण सेट किया जा सकता है।

नीचे दिया गया कोड उदाहरण आकार के भीतर पाठ फ्रेम को 3 डिग्री घड़ी की दिशा में घुमाता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.RotationAngle = 3;

    presentation.Save("custom_text_rotation.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![कस्टम पाठ घुमाव](custom_text_rotation.png)

## **पैराग्राफ की पंक्ति अंतराल सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है ताकि पैराग्राफ अंतराल को नियंत्रित किया जा सके। ये गुण निम्न प्रकार उपयोग किए जाते हैं:

* सकारात्मक मान का उपयोग करके पंक्ति अंतराल को पंक्ति की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करें।
* नकारात्मक मान का उपयोग करके पंक्ति अंतराल को पॉइंट में निर्दिष्ट करें।

निम्नलिखित कोड उदाहरण पैराग्राफ के भीतर पंक्ति अंतराल निर्दिष्ट करने का तरीका दिखाता है:

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    paragraph.ParagraphFormat.SpaceWithin = 200;

    presentation.Save("line_spacing.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ में पंक्ति अंतराल](line_spacing.png)

## **पाठ फ्रेम के लिए ऑटोफिट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/autofittype/) यह निर्धारित करता है कि जब पाठ कंटेनर की सीमाओं से बाहर निकलता है तो उसकी कैसी व्यवहार होगी। इसका उपयोग यह नियंत्रित करने के लिए करें कि पाठ छोटा हो, ओवरफ़्लो हो, या आकार स्वतः बदल दिया जाए।

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("autofit_type.pptx", SaveFormat.Pptx);
}
```

## **पाठ फ्रेम के एंकर को सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/anchoringtype/) यह निर्धारित करता है कि पाठ आकार के भीतर उर्ध्वाधर रूप से कहाँ स्थित होगा, जैसे शीर्ष, मध्य या नीचे।

```cs
using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];

    autoShape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Bottom;

    presentation.Save("text_anchor.pptx", SaveFormat.Pptx);
}
```

## **पाठ टैब्युलेशन सेट करें**

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें।

```cs
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

![पैराग्राफ टैब](paragraph_tabs.png)

## **प्रूफिंग भाषा सेट करें**

Aspose.Slides [IPortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/languageid/) प्रदान करता है, जिससे आप किसी पाठ भाग के लिए प्रूफिंग भाषा सेट कर सकते हैं। प्रूफिंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाती है।

निम्नलिखित कोड उदाहरण पाठ भाग के लिए प्रूफिंग भाषा सेट करने का तरीका दिखाता है:

```cs
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

    // प्रूफिंग भाषा का Id सेट करें.
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

लोड विकल्पों के दौरान या प्रस्तुति बनाते समय निर्मित पाठ के लिए डिफ़ॉल्ट भाषा परिभाषित करने हेतु [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करें।

```cs
var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // पाठ के साथ नया आयताकार आकार जोड़ें।
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // पहले भाग की भाषा जाँचें।
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **डिफ़ॉल्ट पाठ शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट पाठ स्वरूपण लागू करने के लिए [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति में सभी स्लाइड्स के लिए 14 pt आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करने का तरीका दिखाता है।

```cs
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

## **ऑल-कैप्स प्रभाव के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट प्रभाव लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ भाग प्राप्त करते हैं, तो लाइब्रेरी पाठ को बिल्कुल उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/net/aspose.slides/textcaptype/) को जांचें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में परिवर्तित करें।

मान लीजिए हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल-कैप्स प्रभाव](all_caps_effect.png)

नीचे दिया गया कोड उदाहरण **All Caps** प्रभाव लागू किए हुए पाठ को निकालने का तरीका दर्शाता है:

```cs
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

**स्लाइड पर तालिका में पाठ कैसे संशोधित करें?**

स्लाइड पर तालिका में पाठ को संशोधित करने के लिए, [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/textframe/) तथा पैराग्राफ फ़ॉर्मेट को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IPortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।