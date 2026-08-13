---
title: .NET में प्रस्तुतियों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/net/shape-effective-properties/
keywords:
  - आकार गुण
  - कैमरा गुण
  - लाइट रिग
  - बिवेल आकार
  - टेक्स्ट फ्रेम
  - टेक्स्ट शैली
  - फ़ॉन्ट ऊँचाई
  - फ़िल फ़ॉर्मैट
  - PowerPoint
  - प्रेज़ेंटेशन
  - .NET
  - C#
  - Aspose.Slides
description: Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में स्थानीय, विरासत में मिले और प्रभावी आकार फॉर्मेटिंग को कैसे अलग किया जाए, सीखें।
---
## **स्थानीय, विरासत में मिले और प्रभावी गुणों को समझें**

PowerPoint फॉर्मेटिंग कई स्रोतों से आ सकती है। किसी ऑब्जेक्ट पर सीधे संग्रहीत मान **local value** कहलाता है। यदि वह मान सेट नहीं है, तो PowerPoint पैरेंट फॉर्मेटिंग स्रोतों को देखता है, जैसे पैराग्राफ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रेजेंटेशन‑लेवल डिफ़ॉल्ट्स। ये मान **inherited values** कहलाते हैं। पूरी पदानुक्रम सुलझ जाने के बाद जो मान शेष रहता है वह **effective value** है—ऑब्जेक्ट को रेंडर करने के लिए उपयोग किया जाने वाला मान।

उदाहरण के लिए, किसी टेक्स्ट भाग में अपना फ़ॉन्ट ऊँचाई परिभाषित नहीं हो सकती। उसका स्थानीय [FontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseportionformat/fontheight/) `float.NaN` रहता है, जिसका अर्थ है "यहाँ सेट नहीं किया गया है।" भाग अपने पैराग्राफ, प्रेजेंटेशन के डिफ़ॉल्ट टेक्स्ट स्टाइल, या अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। भाग के फॉर्मेट पर [GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/geteffective/) कॉल करने से अंतिम निर्धारित ऊँचाई मिलती है।

दो प्रकार के फॉर्मेट डेटा को अलग‑अलग उद्देश्यों के लिए उपयोग करें:

- जब आपको यह नियंत्रित करना हो कि मान कहाँ परिभाषित है, तो किसी स्थानीय फॉर्मेट ऑब्जेक्ट को पढ़ें या बदलें, जैसे [IPortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/)।
- जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए, तो किसी प्रभावी डेटा ऑब्जेक्ट को पढ़ें, जैसे [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformateffectivedata/)। प्रभावी डेटा केवल‑पढ़ने के लिए होता है।

## **स्थानीय, विरासत में मिले और प्रभावी मानों की तुलना**

निम्न पूर्ण उदाहरण एक आकार बनाता है और प्रेजेंटेशन, पैराग्राफ और भाग स्तर पर फ़ॉन्ट ऊँचाई लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों तथा समान टेक्स्ट भाग के लिए परिणामी प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// दो अलग-अलग स्तरों पर विरासत में मिले मान निर्धारित करें।
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// भाग पर स्थानीय मान दोनों विरासत में मिले मानों को ओवरराइड करता है।
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// विरासत में मिले मान को बदलने से मौजूदा स्थानीय मान ओवरराइड नहीं होता।
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// स्थानीय मान को साफ़ करें। अब भाग फिर से पैराग्राफ से विरासत में लेता है।
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// पैराग्राफ मान को साफ़ करें। अब प्रेज़ेंटेशन डिफ़ॉल्ट परिणाम प्रदान करता है।
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // पिछले परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

इस उदाहरण में प्राथमिकता भाग की स्थानीय फॉर्मेटिंग, फिर पैराग्राफ फॉर्मेटिंग, फिर प्रेजेंटेशन डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स के विरासत चेन अलग हो सकते हैं, लेकिन सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/geteffective/) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फॉर्मेटिंग कई ऑब्जेक्ट्स में विभाजित होती है:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/geteffective/) मार्जिन, एंकरिंग, ऑटोफ़िट और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/hi/net/aspose.slides/itextstyle/geteffective/) प्रत्येक टेक्स्ट स्टाइल स्तर के लिए पैराग्राफ फॉर्मेटिंग को हल करता है।
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraphformat/geteffective/) संरेखण, इंडेंटेशन और बुलेट्स जैसे पैराग्राफ गुणों को हल करता है।
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformat/geteffective/) फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड और इटैलिक जैसे कैरेक्टर गुणों को हल करता है।

अगले उदाहरण के लिए `text-formatting.pptx` में कम से कम एक स्लाइड और एक [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) होना चाहिए जिसमें खाली न होने वाला टेक्स्ट फ़्रेम हो। AutoShape आकार संग्रह में किसी भी स्थान पर हो सकता है; कोड एक उपयुक्त ऑब्जेक्ट की तलाश करता है और उपयोग से पहले उसे सत्यापित करता है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **प्रभावी 3D गुण प्राप्त करें**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/geteffective/) एक [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके [Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/beveltop/) और [BevelBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) गुण संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को साथ‑से‑साथ पढ़ने से आकार की अंतिम 3D उपस्थिति को समझना आसान हो जाता है।

इस उदाहरण के लिए `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक आकार होना चाहिए। यदि आप डिफ़ॉल्ट मानों से अलग परिणाम चाहते हैं, तो उस आकार पर 3D कैमरा, लाइटिंग या बिवेल सेटिंग्स लागू करें।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **प्रभावी तालिका फॉर्मेटिंग प्राप्त करें**

तालिका फॉर्मेटिंग तालिका स्टाइल और पूरी तालिका, कॉलम, रो या व्यक्तिगत सेल पर लागू फॉर्मेट्स दोनों से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स के बीच टकराव में प्राथमिकता सेल, रो, कॉलम, और फिर पूरी तालिका की होती है। किसी सेल का प्रभावी फॉर्मेट वह अंतिम फॉर्मेट है जिसका उपयोग उस सेल को ड्रॉ करने में किया जाता है।

इस उदाहरण के लिए `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक तालिका होना चाहिए। तालिका में कम से कम एक रो और एक कॉलम होना आवश्यक है। कोड एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) की तलाश करता है, यह मानते हुए कि `Shapes[0]` तालिका है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

यदि आपको केवल फ़िल प्रकार ही नहीं, बल्कि रंग चाहिए, तो पहले प्रभावी [FillType](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/filltype/) की जाँच करें, फिर उस प्रकार पर लागू प्रॉपर्टी पढ़ें—उदाहरण के लिए सॉलिड फ़िल के लिए [SolidFillColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/solidfillcolor/)।

## **परिवर्तन के बाद प्रभावी डेटा को पुनः पढ़ें**

प्रभावी डेटा उस समय हल किए गए फॉर्मेटिंग पदानुक्रम का वर्णन करता है। किसी भी बदल का बाद `GetEffective` फिर से कॉल करें जो उस पदानुक्रम में भाग ले सकता है, जिसमें शामिल हैं:

- ऑब्जेक्ट का स्थानीय फॉर्मेट;
- पैराग्राफ या टेक्स्ट‑फ़्रेम डिफ़ॉल्ट्स;
- तालिका स्टाइल, तालिका, कॉलम, रो या सेल फॉर्मेट;
- लेआउट या मास्टर स्लाइड फॉर्मेट;
- थीम डेटा या प्रेजेंटेशन‑लेवल डिफ़ॉल्ट्स;
- स्लाइड को असाइन किया गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides आंतरिक रूप से कुछ प्रभावी डेटा को कैश कर सकता है, और बाद में `GetEffective` कॉल उस डेटा को रीफ़्रेश कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो आवश्यक स्केलर मान—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेखण या बिवेल चौड़ाई—को अपने स्वयं के वेरिएबल्स में कॉपी करके रखें, फिर परिवर्तन करें।

किसी मान को बदलने के लिए उपयुक्त स्थानीय फॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर `GetEffective` कॉल करके परिणाम सत्यापित करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने के लिए होते हैं।

## **FAQ**

**मैं कैसे पता करूँ कि कौन सा स्तर प्रभावी मान प्रदान कर रहा है?**  
प्रभावी डेटा केवल अंतिम मान रखता है, स्रोत नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स की जाँच करें। टेक्स्ट के लिए इसमें भाग, पैराग्राफ, टेक्स्ट‑फ़्रेम, लेआउट, मास्टर, थीम और प्रेजेंटेशन डिफ़ॉल्ट्स शामिल हो सकते हैं। `float.NaN` या `null` जैसे अनपरिभाषित मान दर्शाते हैं कि खोज जारी है।

**यदि कोई स्तर कोई प्रॉपर्टी परिभाषित नहीं करता तो क्या होता है?**  
Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाया जाता है, भले ही कोई स्थानीय ऑब्जेक्ट स्पष्ट रूप से उसे परिभाषित न करे।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**  
स्थानीय मान ने विरासत गणना जीत ली है। यह तब अपेक्षित है जब प्रॉपर्टी ऑब्जेक्ट पर स्पष्ट रूप से सेट हो और कोई अधिक विशिष्ट नियम उसे ओवरराइड न करे।

**कब मुझे स्थानीय डेटा के बजाय प्रभावी डेटा उपयोग करना चाहिए?**  
स्थानीय डेटा का उपयोग तब करें जब आपको किसी विशिष्ट फॉर्मेटिंग स्तर की जांच या संपादन करना हो। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम और लागू स्टाइल्स के बाद का अंतिम रूप चाहिए। समान वर्कफ़्लो में दोनों को दिखाने वाला [complete comparison example](#compare-local-inherited-and-effective-values) इस बात को दर्शाता है।