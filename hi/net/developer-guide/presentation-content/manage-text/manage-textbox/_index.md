---
title: .NET में प्रस्तुतियों में टेक्स्ट बॉक्स प्रबंधित करें
linktitle: टेक्स्ट बॉक्स प्रबंधित करें
type: docs
weight: 20
url: /hi/net/manage-textbox/
keywords:
- टेक्स्ट बॉक्स
- टेक्स्ट फ्रेम
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
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट बॉक्स बनाएं, पहचानें, फ़ॉर्मेट करें, और अपडेट करें।"
---
## **परिचय**

Aspose.Slides for .NET में, स्लाइड टेक्स्ट आकारों से संबंधित टेक्स्ट फ्रेम में संग्रहीत किया जाता है। [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) इंटरफ़ेस सबसे सामान्य टेक्स्ट‑धारक आकार का प्रतिनिधित्व करता है और अपने टेक्स्ट को [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) प्रॉपर्टी के माध्यम से उजागर करता है।

{{% alert color="info" title="Note" %}}

हर ऑटो शेप [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) को लागू करता है, लेकिन हर शेप ऑटो शेप नहीं होता या टेक्स्ट फ्रेम का समर्थन नहीं करता। मौजूदा प्रस्तुति को प्रोसेस करते समय, टेक्स्ट तक पहुँचने से पहले जाँचें कि एक शेप `IAutoShape` को लागू करता है।

{{% /alert %}}

## **स्लाइड पर टेक्स्ट बॉक्स बनाना**

टेक्स्ट बॉक्स बनाने के लिए, स्लाइड में एक ऑटो शेप जोड़ें, उसके टेक्स्ट फ्रेम में टेक्स्ट जोड़ें, और प्रस्तुति को सहेजें। निम्न उदाहरण एक आयताकार टेक्स्ट बॉक्स बनाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

[IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) को पास किए गए निर्देशांक और माप बिंदुओं (points) में मापे जाते हैं। [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) प्रदान किए गए टेक्स्ट के साथ टेक्स्ट फ्रेम को आरम्भ करता है।

## **टेक्स्ट बॉक्स आकार के लिए जाँच करें**

[AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) प्रॉपर्टी का उपयोग करके निर्धारित करें कि क्या एक ऑटो शेप को टेक्स्ट बॉक्स के रूप में माना जाता है। यह तब उपयोगी है जब प्रस्तुति में टेक्स्ट‑धारक और केवल ग्राफिकल ऑटो शेप दोनों हों।

![एक टेक्स्ट बॉक्स और एक आकार](istextbox.png)

निम्न उदाहरण प्रस्तुति में प्रत्येक ऑटो शेप की जांच करता है:

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

एक नया जोड़ा गया ऑटो शेप तब तक टेक्स्ट बॉक्स नहीं माना जाता जब तक उसमें खाली नहीं रहित टेक्स्ट न हो। आप वह टेक्स्ट [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) या [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) के माध्यम से प्रदान कर सकते हैं। खाली स्ट्रिंग जोड़ने या असाइन करने से `IsTextBox` `false` पर रहता है:

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

## **टेक्स्ट फ्रेम का मालिक आकार खोजें**

सामान्य टेक्स्ट‑प्रोसेसिंग कोड एक [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) प्राप्त कर सकता है बिना यह जाने कि इसे कौन सा प्रस्तुति ऑब्जेक्ट रखता है। उसके मालिक [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) पर वापस जाने के लिए केवल‑पढ़ने योग्य [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) प्रॉपर्टी का उपयोग करें।

ऑटो शेप या किसी अन्य टेक्स्ट‑धारक आकार द्वारा स्वामित्व वाला टेक्स्ट फ्रेम के लिए, `ParentShape` मालिक को रखता है और [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) `null` होता है। एक्सेस करने से पहले लौटाए गए मान की जाँच करें। आकार और टेबल‑सेल दोनों मालिकों की पहचान करने के लिए, जिसमें SmartArt नोड्स से जुड़े आकार शामिल हैं, देखें [Search and Replace Text](/slides/hi/net/search-and-replace-text/)।

## **आकार के टेक्स्ट आयत प्राप्त करें**

Aspose.Slides for .NET 26.11 से शुरू करते हुए, [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) पैरेंट आकार की ज्योमेट्री द्वारा परिभाषित टेक्स्ट एरिया लौटाता है। इसके निर्देशांक और आयाम बिंदुओं (points) में होते हैं, और आकार के टॉप‑लेफ़्ट कोने के सापेक्ष होते हैं। उदाहरण के लिए, एक एलिप्स का टेक्स्ट आयत उसके बाहरी सीमाओं से छोटा होता है।

यह आयत आकार को वर्णित करती है, न कि रेंडर की गई वर्णों को। टेक्स्ट या टेक्स्ट‑फ़्रेम मार्जिन बदलने से यह कब्जा किए गए टेक्स्ट का माप नहीं बनता। रेंडर‑टेक्स्ट माप के लिए [paragraph bounds](/slides/hi/net/paragraph-bounds/) या [portion bounds](/slides/hi/net/portion-bounds/) का उपयोग करें।

[installing Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद के संस्करण से, इस उदाहरण को चलाएँ ताकि ज्योमेट्री टेक्स्ट आयत को लाल रंग में खींचा जा सके। आकार बिना घुमाए और बिना समूहित होते हैं, इसलिए उनका X/Y स्थिति जोड़ना स्लाइड पर ओवरले रखने के लिए पर्याप्त है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

उपर्युक्त 200 × 100 पॉइंट आकारों के लिए, आयत `(0, 0, 200, 100)` लौटाती है; एलिप्स लगभग `(29.289, 14.645, 141.421, 70.711)` देता है। यह मेथड कस्टम ज्योमेट्री के घोषित टेक्स्ट आयत को भी पढ़ता है। यह स्लाइड‑स्पेस रोटेशन या समूह ट्रांसफ़ॉर्म लागू नहीं करता; ओवरले की स्थिति तय करते समय इन्हें अलग से ध्यान में रखें। एक टेक्स्ट फ्रेम बिना ज्योमेट्री आकार के, जैसे टेबल‑सेल टेक्स्ट फ्रेम, `InvalidOperationException` फेंक सकता है।

## **टेक्स्ट बॉक्स में कॉलम जोड़ें**

[ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) प्रॉपर्टी टेक्स्ट फ्रेम को कॉलम में विभाजित करती है, जबकि [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) कॉलम के बीच का अंतराल बिंदुओं (points) में निर्धारित करती है। दोनों सेटिंग्स [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) से संबंधित हैं और मौजूदा टेक्स्ट बॉक्स के टेक्स्ट फ्रेम के माध्यम से बदली जा सकती हैं। टेक्स्ट उसी आकार के भीतर कॉलम के बीच पुनः प्रवाहित होता है; यह किसी अन्य आकार में नहीं जाता।

निम्न उदाहरण 10 पॉइंट कॉलम अंतराल के साथ तीन‑कॉलम टेक्स्ट बॉक्स बनाता है, प्रस्तुति को सहेजता है, और आउटपुट फ़ाइल से संग्रहीत सेटिंग्स को पुनः पढ़ता है:

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

## **व्यक्तिगत कॉलम से टेक्स्ट निकालें**

[TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) का उपयोग करके मौजूदा टेक्स्ट फ्रेम में प्रत्येक दृश्य कॉलम को सौंपा गया टेक्स्ट प्राप्त करें। यह मेथड प्रत्येक कॉलम के लिए एक स्ट्रिंग लौटाता है, कॉलम‑आधारित पढ़ने क्रम में। एक सिंगल‑कॉलम टेक्स्ट फ्रेम एक तत्व वाला एरे बनाता है, और खाली कॉलम को एक खाली स्ट्रिंग से दर्शाया जाता है। स्ट्रिंग्स में केवल साधारण टेक्स्ट होता है; पोर्शन‑स्तर फ़ॉर्मेटिंग संरक्षित नहीं रहती।

यह उपयोगी है जब आपको आवश्यकता हो:
- कॉलम‑आधारित पढ़ने क्रम को बरकरार रखते हुए टेक्स्ट निकालना।
- बहु‑कॉलम स्लाइड की सामग्री को इंडेक्स या तुलना करना।
- प्रत्येक कॉलम को अलग फ़ाइल, डेटाबेस फ़ील्ड, या अन्य गंतव्य में निर्यात करना।
- [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), फ़ॉन्ट, या टेक्स्ट‑फ़्रेम आकार बदलने के बाद टेक्स्ट कैसे पुनः वितरित होता है, इसका निरीक्षण करें।

यह मेथड वर्तमान [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) के भीतर वितरित टेक्स्ट की रिपोर्ट करता है; यह अलग-अलग आकार या टेक्स्ट बॉक्स के बीच स्वचालित रूप से टेक्स्ट प्रवाहित नहीं करता। कॉलम वितरण उपलब्ध फ़ॉन्ट्स और अन्य टेक्स्ट‑लेआउट सेटिंग्स पर निर्भर हो सकता है, इसलिए जब सुसंगत परिणाम महत्वपूर्ण हों तो आवश्यक फ़ॉन्ट उपलब्ध हों यह सुनिश्चित करें।

निम्न उदाहरण प्रस्तुति को लोड करता है, पहले मल्टी‑कॉलम ऑटो शेप को टेक्स्ट फ्रेम के साथ खोजता है, उसकी कॉन्फ़िगर की गई कॉलम संख्या पढ़ता है, और प्रत्येक कॉलम के टेक्स्ट को अलग फ़ाइल में लिखता है। जो आकार टेक्स्ट फ्रेम प्रदान नहीं करते उन्हें छोड़ दिया जाता है।

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

पूरी प्रस्तुति में टेक्स्ट अपडेट करने के लिए, स्लाइड्स और आकारों के माध्यम से इटरिटेट करें, ऑटो शेप चुनें, और फिर उनके टेक्स्ट पोर्शन को एडिट करें। पोर्शन स्तर पर काम करने से आप टेक्स्ट और कैरेक्टर फ़ॉर्मेटिंग दोनों बदल सकते हैं।

निम्न उदाहरण ऑटो‑शेप टेक्स्ट में `years` की प्रत्येक घटना को `months` से बदलता है और प्रत्येक प्रभावित पोर्शन को बोल्ड करता है:

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

यह ट्रैवर्सल केवल ऑटो शेप में टेक्स्ट अपडेट करता है। टेबल, चार्ट, SmartArt, या समूहित आकारों में संग्रहीत टेक्स्ट को अपडेट करने के लिए उन ऑब्जेक्ट्स के अपने संग्रहों को ट्रैवर्स करना आवश्यक है।

## **हाइपरलिंक के साथ टेक्स्ट बॉक्स जोड़ें**

हाइपरलिंक को किसी विशिष्ट टेक्स्ट पोर्शन के साथ जोड़ा जा सकता है, ताकि केवल वही टेक्स्ट क्लिक‑योग्य लिंक बन जाए। पोर्शन को बाहरी URL से जोड़ने के लिए [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) का उपयोग करें।

निम्न उदाहरण लिंक किया हुआ टेक्स्ट बनाता है और इसे एक प्रस्तुति में सहेजता है:

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

**एक मास्टर या लेआउट स्लाइड पर टेक्स्ट बॉक्स और टेक्स्ट प्लेसहोल्डर में क्या अंतर है?**

[प्लेसहोल्डर](/slides/hi/net/manage-placeholder/) अपनी स्थिति और फ़ॉर्मेटिंग को एक [मास्टर स्लाइड](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) या [लेआउट स्लाइड](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) से विरासत में ले सकता है। एक सामान्य टेक्स्ट बॉक्स वह स्लाइड पर एक स्वतंत्र आकार है जहाँ यह बनाया गया था और लेआउट बदलने पर प्लेसहोल्डर व्यवहार नहीं प्राप्त करता।

**मैं चार्ट, टेबल, या SmartArt में टेक्स्ट बदले बिना टेक्स्ट कैसे बदल सकूँ?**

[IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) को लागू करने वाले आकारों तक ट्रैवर्सल को सीमित करें, जैसा कि अपडेट टेक्स्ट उदाहरण में दिखाया गया है। चार्ट, टेबल, और SmartArt अपना टेक्स्ट अपने स्वयं के ऑब्जेक्ट मॉडल में रखते हैं, इसलिए वह लूप उन्हें संशोधित नहीं करता।