---
title: .NET में प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/net/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ़्रेम
- टेक्स्ट जोड़ें
- टेक्स्ट अपडेट करें
- टेक्स्ट बॉक्स बनाएं
- टेक्स्ट बॉक्स जांचें
- टेक्स्ट कॉलम जोड़ें
- हाइपरलिंक जोड़ें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचानें, स्वरूपित करें और अपडेट करें।"
---
## **परिचय**

Aspose.Slides for .NET में, स्लाइड का टेक्स्ट शैप्स से संबंधित टेक्स्ट फ़्रेम में संग्रहीत होता है। [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) इंटरफ़ेस सबसे सामान्य टेक्स्ट‑धारी शैप को दर्शाता है और अपने टेक्स्ट को [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/textframe/) प्रॉपर्टी के माध्यम से उजागर करता है।

{{% alert color="info" title="नोट" %}}
हर ऑटो शैप [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) को लागू करता है, लेकिन हर शैप ऑटो शैप नहीं होता या टेक्स्ट फ़्रेम को सपोर्ट नहीं करता। मौजूदा प्रस्तुति को प्रोसेस करते समय, शैप के `IAutoShape` को लागू किया है या नहीं, यह जांचें, फिर उसके टेक्स्ट तक पहुंचें।
{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो शैप जोड़ें, उसके टेक्स्ट फ़्रेम में टेक्स्ट जोड़ें, और प्रस्तुति सहेजें। निम्न उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addautoshape/) को भेजे गए निर्देशांक और आयाम पॉइंट्स में मापे जाते हैं। [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/addtextframe/) प्रदान किए गए टेक्स्ट से टेक्स्ट फ़्रेम को प्रारंभ करता है।

## **टेक्स्ट बॉक्स शैप की जाँच करना**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/istextbox/) प्रॉपर्टी का उपयोग करके निर्धारित करें कि ऑटो शैप को टेक्स्ट बॉक्स माना जाता है या नहीं। यह तब उपयोगी होता है जब प्रस्तुति में टेक्स्ट‑धारी और केवल ग्राफ़िकल ऑटो शैप दोनों होते हैं।

![एक टेक्स्ट बॉक्स और एक शैप](istextbox.png)

निम्न उदाहरण प्रस्तुति में प्रत्येक ऑटो शैप का निरीक्षण करता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

एक नया जोड़ा गया ऑटो शैप तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें खाली नहीं न हो ऐसा टेक्स्ट न हो। आप वह टेक्स्ट [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/addtextframe/) या [ITextFrame.Text](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/text/) के माध्यम से दे सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने से `IsTextBox` `false` रहता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

पहले दो कॉल्स `True` प्रिंट करते हैं; अंतिम दो `False` प्रिंट करते हैं।

## **टेक्स्ट फ़्रेम के मालिक शैप को ढूँढ़ें**

जनरिक टेक्स्ट‑प्रोसेसिंग कोड एक [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) प्राप्त कर सकता है बिना यह जाने कि इसे कौन सा प्रस्तुति ऑब्जेक्ट रखता है। इसके मालिक [IShape] को वापस नेविगेट करने के लिए रीड‑ऑनली [ITextFrame.ParentShape](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentshape/) प्रॉपर्टी का उपयोग करें।

यदि टेक्स्ट फ़्रेम ऑटो शैप या किसी अन्य टेक्स्ट‑धारी शैप का मालिक है, तो `ParentShape` में मालिक होता है और [ITextFrame.ParentCell](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/parentcell/) `null` होता है। इसे एक्सेस करने से पहला लौटाए गए मान की जाँच करें। शैप और टेबल‑सेल मालिकों दोनों को पहचानने के लिए, जिसमें SmartArt नोड्स से जुड़े शैप शामिल हैं, देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/columncount/) प्रॉपर्टी टेक्स्ट फ़्रेम को कॉलमों में विभाजित करती है, जबकि [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/columnspacing/) पॉइंट्स में कॉलमों के बीच का गैप सेट करती है। दोनों सेटिंग्स [ITextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/) की हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ़्रेम के माध्यम से बदली जा सकती हैं। टेक्स्ट उसी शैप के भीतर कॉलमों के बीच पुनः प्रवाहित होता है; यह किसी अन्य शैप में नहीं जाता।

निम्न उदाहरण 10 पॉइंट्स के अंतराल के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रस्तुति सहेजता है, और आउटपुट फ़ाइल से संग्रहीत सेटिंग्स को पढ़ता है:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **विभक्त कॉलमों से टेक्स्ट निकालें**

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/splittextbycolumns/) का उपयोग करके मौजूदा टेक्स्ट फ़्रेम में प्रत्येक दृश्य कॉलम को नियत टेक्स्ट प्राप्त करें। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित पढ़ने के क्रम में। एकसिंगल‑कॉलम टेक्स्ट फ़्रेम एक तत्व वाला एरे बनाता है, और खाली कॉलम को खाली स्ट्रिंग से दर्शाया जाता है। स्ट्रिंग्स में केवल साधारण टेक्स्ट होता है; भाग‑स्तर की फ़ॉर्मैटिंग संरक्षित नहीं रहती।

यह तब उपयोगी होता है जब आपको:

- कॉलम‑आधारित पढ़ने के क्रम को बनाए रखते हुए टेक्स्ट निकालना।
- बहु‑कॉलम स्लाइड्स की सामग्री को इंडेक्स या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड, या अन्य गंतव्य में निर्यात करना।
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/columnspacing/), फ़ॉन्ट, या टेक्स्ट‑फ़्रेम आकार को बदलने के बाद टेक्स्ट के पुनः वितरण की जांच करना।

यह मेथड वर्तमान [ITextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/) में वितरित टेक्स्ट को रिपोर्ट करता है; यह अलग-अलग शैप या टेक्स्ट बॉक्स के बीच स्वचालित रूप से टेक्स्ट प्रवाहित नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्ट्स और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर हो सकता है, इसलिए जब स्थिर परिणाम महत्वपूर्ण हों तो आवश्यक फ़ॉन्ट्स उपलब्ध हों यह सुनिश्चित करें।

निम्न उदाहरण एक प्रस्तुति लोड करता है, टेक्स्ट फ़्रेम वाले प्रथम मल्टी‑कॉलम ऑटो शैप को खोजता है, उसकी कॉन्फ़िगर की गई कॉलम संख्या पढ़ता है, और प्रत्येक कॉलम के टेक्स्ट को अलग फ़ाइल में लिखता है। जो शैप टेक्स्ट फ़्रेम प्रदान नहीं करते उन्हें छोड़ दिया जाता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **टेक्स्ट अपडेट करें**

प्रस्तुति में पूरे टेक्स्ट को अपडेट करने के लिए, स्लाइड्स और शैप्स को क्रम में पार करें, ऑटो शैप्स चुनें, और फिर उनके टेक्स्ट भागों को संपादित करें। भाग‑स्तर पर काम करने से आप टेक्स्ट और अक्षर फ़ॉर्मैटिंग दोनों बदल सकते हैं।

निम्न उदाहरण ऑटो‑शैप टेक्स्ट में प्रत्येक `years` को `months` से बदलता है और प्रभावित प्रत्येक भाग को बोल्ड बनाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

यह ट्रैवर्सल केवल ऑटो शैप्स में टेक्स्ट अपडेट करता है। टेबल, चार्ट, SmartArt, या ग्रुप्ड शैप्स में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन ऑब्जेक्ट्स की अपनी कलेक्शन को पार करना आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

एक हाइपरलिंक को विशिष्ट टेक्स्ट भाग को असाइन किया जा सकता है, इसलिए केवल वही टेक्स्ट क्लिक योग्य लिंक बनता है। भाग को बाहरी URL से जोड़ने के लिए [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) का उपयोग करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

[placeholder](/slides/hi/net/manage-placeholder/) अपने स्थान और फ़ॉर्मैटिंग को [master slide](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslide/) या [layout slide](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/) से विरासत में ले सकता है। एक सामान्य टेक्स्ट बॉक्स वह शैप है जो जिस स्लाइड पर बनाया गया है, वह स्वतंत्र रहता है और लेआउट बदलने पर प्लेसहोल्डर व्यवहार नहीं अपनाता।

**मैं चार्ट, टेबल, या SmartArt में टेक्स्ट बदले बिना टेक्स्ट कैसे बदल सकता हूँ?**

ट्रैवर्सल को केवल उन शैप्स तक सीमित रखें जो [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) को लागू करते हैं, जैसा कि Update Text उदाहरण में दिखाया गया है। चार्ट, टेबल, और SmartArt अपना टेक्स्ट अपने वस्तु मॉडल में संग्रहीत करते हैं, इसलिए वह लूप उन्हें नहीं बदलता।