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
- अक्षर अंतर
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- पाठ घूर्णन
- घूर्णन कोण
- पाठ फ्रेम
- पंक्ति अंतर
- ऑटोफ़िट गुण
- पाठ फ्रेम एंकर
- पाठ टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण आदि को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को स्वरूपित करने का तरीका दर्शाता है। इसमें पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतर, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतर, ऑटोफ़िट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स शामिल हैं।

नीचे के उदाहरणों में हम "sample.pptx" नामक फ़ाइल का उपयोग करेंगे, जिसमें पहली स्लाइड पर एकल टेक्स्ट बॉक्स है, जिसमें निम्नलिखित पाठ है:

![नमूना पाठ](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए देखें [पाठ खोजें और बदलें](/slides/hi/net/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ के लिए डिफ़ॉल्ट हाइलाइट रंग सेट करने हेतु [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) का उपयोग करें, या व्यक्तिगत पाठ अंशों के लिए [IBasePortionFormat.HighlightColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/highlightcolor/) का उपयोग करें।

निम्नलिखित कोड उदाहरण **पूरे पैराग्राफ** के पृष्ठभूमि रंग को सेट करने का तरीका दिखाता है:

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

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ अंशों** के पृष्ठभूमि रंग को सेट करने का तरीका दर्शाता है:

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
            // पाठ अंश के लिए हाइलाइट रंग सेट करें।
            portion.PortionFormat.HighlightColor.Color = Color.LightGray;
        }
    }

    presentation.Save("gray_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![ग्रे टेक्स्ट पोर्शन](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ संरेखण सेट करने के लिए [IParagraphFormat.Alignment](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/alignment/) का उपयोग करें। मान केंद्रित, बाएँ-संरेखित, दाएँ-संरेखित, न्यायसंगत आदि हो सकते हैं।

निम्नलिखित कोड उदाहरण **केंद्र** में पैराग्राफ को संरेखित करने का तरीका दिखाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ की पारदर्शिता को [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) को सौंपे गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे के उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा-चैनल मान है, न कि पारदर्शिता प्रतिशत।

नीचे का कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करने का तरीका दिखाता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int alpha = 50;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // पाठ का भराव रंग पारदर्शी रंग में सेट करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);

    presentation.Save("transparent_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्नलिखित कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ अंशों** पर पारदर्शिता लागू करने का तरीका दर्शाता है:

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
            // पाठ अंश की पारदर्शिता सेट करें।
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Black);
        }
    }

    presentation.Save("transparent_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पारदर्शी टेक्स्ट पोर्शन](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतर सेट करें**

टेक्स्ट बॉक्स में अक्षरों के बीच अंतर को बढ़ाने या घटाने के लिए [IBasePortionFormat.Spacing](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/spacing/) का उपयोग करें।

निम्नलिखित C# कोड **पूरे पैराग्राफ** में अक्षर अंतर को बढ़ाने का तरीका दिखाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("sample.pptx"))
{
    var autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var paragraph = autoShape.TextFrame.Paragraphs[0];

    // ध्यान दें: अक्षर अंतर को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
    paragraph.ParagraphFormat.DefaultPortionFormat.Spacing = 3;  // अक्षर अंतर को विस्तारित करें।

    presentation.Save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![पैराग्राफ में अक्षर अंतर](character_spacing_in_paragraph.png)

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ अंशों** में अक्षर अंतर को बढ़ाने का तरीका दर्शाता है:

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
            // नोट: अक्षर अंतर को संकुचित करने के लिए नकारात्मक मानों का उपयोग करें।
            portion.PortionFormat.Spacing = 3;  // अक्षर अंतर को विस्तारित करें।
        }
    }

    presentation.Save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
}
```

परिणाम:

![टेक्स्ट पोर्शन में अक्षर अंतर](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखाए गए समान पाठ से थोड़ा अधिक कसकर लग सकता है। यह इसलिए होता है क्योंकि PowerPoint कुछ फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग में केरनिंग सक्रिय हो।

ऐसे मामलों में PowerPoint के निकटतम रेंडरिंग प्राप्त करने के लिए आप उस फ़ॉन्ट का उपयोग करने वाले पाठ अंशों के लिए केरनिंग अक्षम कर सकते हैं। [IBasePortionFormat.KerningMinimalSize](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/kerningminimalsize/) को वास्तविक फ़ॉन्ट आकार से काफी बड़े मान पर सेट करें:

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

यह सेटिंग मेल खाने वाले पाठ अंशों पर केरनिंग को लागू होने से रोकती है और PowerPoint‑विशिष्ट व्यवहार से प्रभावित फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य परिणाम के साथ संरेखित करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [IParagraphFormat.DefaultPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaultportionformat/) के माध्यम से या व्यक्तिगत अंशों पर [IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/) के माध्यम से सेट किया जा सकता है।

निम्नलिखित कोड पूरे पैराग्राफ के लिए फ़ॉन्ट और पाठ शैली सेट करता है: यह फ़ॉन्ट आकार, बोल्ड, इटैलिक, डॉटेड अंडरलाइन, और Times New Roman फ़ॉन्ट को सभी अंशों पर लागू करता है।

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

नीचे का कोड उदाहरण **बोल्ड फ़ॉन्ट वाले पाठ अंशों** पर समान गुण लागू करता है:

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
            // पाठ अंश के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट पोर्शन के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ घूर्णन सेट करें**

एक आकार के भीतर पूर्वनिर्धारित पाठ अभिविन्यास सेट करने के लिए [ITextFrameFormat.TextVerticalType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/textverticaltype/) का उपयोग करें।

निम्नलिखित कोड उदाहरण आकार में पाठ अभिविन्यास को `Vertical270` पर सेट करता है, जो पाठ को **90 डिग्री प्रतिक्लॉकवाइज़** घुमाता है:

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

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

[ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/rotationangle/) का उपयोग करके किसी [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) के लिए कस्टम घूर्णन कोण सेट करें।

नीचे का कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री क्लॉकवाइज़ घुमाता है:

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

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [IParagraphFormat.SpaceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spaceafter/), [IParagraphFormat.SpaceBefore](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacebefore/), और [IParagraphFormat.SpaceWithin](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/spacewithin/) प्रदान करता है ताकि पैराग्राफ स्पेसिंग को नियंत्रित किया जा सके। इन गुणों का उपयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान का उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान का उपयोग करें।

निम्नलिखित कोड उदाहरण पैराग्राफ के भीतर लाइन स्पेसिंग को निर्दिष्ट करने का तरीका दिखाता है:

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

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **टेक्स्ट फ्रेम के लिए ऑटोफ़िट प्रकार सेट करें**

[ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/autofittype/) निर्धारित करता है कि जब पाठ अपने कंटेनर की सीमाओं से अधिक हो जाए तो वह कैसे व्यवहार करता है। इसका उपयोग करके आप नियंत्रित कर सकते हैं कि पाठ छोटा हो, ओवरफ़्लो हो, या आकार को स्वचालित रूप से पुन: आकार दिया जाए।

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

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[ITextFrameFormat.AnchoringType](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/anchoringtype/) परिभाषित करता है कि आकार के भीतर पाठ ऊर्ध्वाधर रूप से कैसे स्थित है, जैसे शीर्ष, मध्य, या निचला।

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

एक पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [IParagraphFormat.DefaultTabSize](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/defaulttabsize/) और [IParagraphFormat.Tabs](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/tabs/) का उपयोग करें।

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

Aspose.Slides [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/languageid/) प्रदान करता है, जिससे आप किसी पाठ अंश के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जांच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्नलिखित कोड उदाहरण किसी पाठ अंश के लिए प्रूफ़िंग भाषा सेट करने का तरीका दिखाता है:

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

    // प्रूफ़िंग भाषा का Id सेट करें।
    textPortion.PortionFormat.LanguageId = "zh-CN";

    textPortion.Text = "1。";
    paragraph.Portions.Add(textPortion);

    presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
}
```

## **डिफ़ॉल्ट भाषा सेट करें**

प्रस्तुति लोड या बनाते समय बनाए गए पाठ के लिए डिफ़ॉल्ट भाषा निर्धारित करने हेतु [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/defaulttextlanguage/) का उपयोग करें।

```cs
using Aspose.Slides;

var loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";

using (var presentation = new Presentation(loadOptions))
{
    var slide = presentation.Slides[0];

    // टेक्स्ट के साथ नया आयताकार आकार जोड़ें।
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.TextFrame.Text = "Sample text";

    // पहले अंश की भाषा जाँचें।
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    Console.WriteLine(portion.PortionFormat.LanguageId);
}
```

## **डिफ़ॉल्ट टेक्स्ट शैली सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फॉर्मेटिंग लागू करने के लिए [IPresentation.DefaultTextStyle](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/defaulttextstyle/) का उपयोग करें।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति में सभी स्लाइड्स के लिए 14 pt आकार के साथ डिफ़ॉल्ट बोल्ड फ़ॉन्ट सेट करने का तरीका दर्शाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    // शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    var paragraphFormat = presentation.DefaultTextStyle.GetLevel(0);

    if (paragraphFormat != null)
    {
        paragraphFormat.DefaultPortionFormat.FontHeight = 14;
        paragraphFormat.DefaultPortionFormat.FontBold = NullableBool.True;
    }

    presentation.Save("default_text_style.pptx", SaveFormat.Pptx);
}
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ पाठ निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर पाठ बड़े अक्षरों में दिखाई देता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा पाठ अंश प्राप्त करते हैं, तो लाइब्रेरी वही पाठ लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित पाठ से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/net/aspose.slides/textcaptype/) जाँचें और मान `All` होने पर लौटाए गए स्ट्रिंग को बड़े अक्षरों में परिवर्तित करें।

मान लें कि हमारे पास sample2.pptx फ़ाइल की पहली स्लाइड पर निम्नलिखित टेक्स्ट बॉक्स है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे का कोड उदाहरण **All Caps** इफ़ेक्ट लागू किए हुए पाठ को निकालने का तरीका दर्शाता है:

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

## **FAQ**

**स्लाइड पर तालिका में पाठ को कैसे संशोधित करें?**

स्लाइड पर तालिका में पाठ को संशोधित करने के लिए [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) का उपयोग करें। कोशिकाओं के माध्यम से इटररेट करें और प्रत्येक कोशिका को [ICell.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/icell/textframe/) तथा पैराग्राफ फॉर्मेटिंग को [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/paragraphformat/) के माध्यम से अपडेट करें।

**PowerPoint स्लाइड में पाठ पर ग्रेडिएंट रंग कैसे लागू करें?**

ग्रेडिएंट रंग लागू करने के लिए [IBasePortionFormat.FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fillformat/) का उपयोग करें। [IFillFormat.FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformat/filltype/) को [FillType.Gradient](https://reference.aspose.com/slides/hi/net/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, और पारदर्शिता को कॉन्फ़िगर करें।