---
title: ".NET में प्रस्तुतियों से शैप के प्रभावी गुण प्राप्त करें"
linktitle: "प्रभावी गुण"
type: docs
weight: 50
url: /hi/net/shape-effective-properties/
keywords:
- "आकार गुण"
- "कैमरा गुण"
- "लाइट रिग"
- "बिवेल शैप"
- "टेक्स्ट फ्रेम"
- "टेक्स्ट स्टाइल"
- "फ़ॉन्ट ऊँचाई"
- "फ़िल फ़ॉर्मेट"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "जानें कि Aspose.Slides for .NET कैसे सटीक PowerPoint रेंडरिंग के लिए प्रभावी शैप गुणों की गणना और उनका उपयोग करता है।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर को समझाता है। स्थानीय मान वे मान होते हैं जो किसी विशिष्ट फ़ॉर्मेटिंग स्तर पर सीधे सेट किए जाते हैं, जैसे:

1. स्लाइड पर पोर्शन गुण।
2. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शैप टेक्स्ट स्टाइल, जब पोर्शन के टेक्स्ट फ्रेम शैप में एक हो।
3. प्रेजेंटेशन में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मानों को किसी भी स्तर पर परिभाषित या छोड़ा जा सकता है। जब Aspose.Slides को अंतिम "जैसे रेंडर किया गया" फ़ॉर्मेटिंग चाहिए, तो यह उत्तराधिकार श्रृंखला को हल करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय फ़ॉर्मेट ऑब्जेक्ट पर `GetEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसमें एक टेक्स्ट फ्रेम और कम से कम एक पोर्शन है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
प्रभावी फ़ॉर्मेटिंग डेटा उत्तराधिकार लागू होने के बाद वर्तमान गणना किए गए फ़ॉर्मेटिंग को दर्शाता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformateffectivedata/), आंतरिक रूप से कैश किए जा सकते हैं। पैरेंट या विरासत में मिलने वाले फ़ॉर्मेटिंग को बदलने के बाद `GetEffective` को पुनः कॉल करने से कैश डेटा रिफ्रेश हो सकता है, और पहले प्राप्त किए गए ऑब्जेक्ट अब पूर्व स्थिति को दर्शा नहीं सकते। यदि आपको भविष्य में पुनः उपयोग के लिए प्रभावी मान संरक्षित रखने की आवश्यकता है, तो आवश्यक गुणों, जैसे फ़ॉन्ट ऊँचाई, भराव रंग, फ़ॉन्ट शैली, या संरेखण, को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरा के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icameraeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी कैमरा गुण होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icameraeffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि कैमरा के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप में 3D फ़ॉर्मेटिंग है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **लाइट रिग के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrigeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी लाइट रिग गुण होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrigeffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप में 3D फ़ॉर्मेटिंग है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **बिवेल शैप के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको शैप बिवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapebeveleffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें शैप के लिए प्रभावी फेस‑रिलीफ़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapebeveleffectivedata/) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि शैप के शीर्ष बिवेल के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप में 3D फ़ॉर्मेटिंग है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformateffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग गुणों को समाहित करता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसमें एक टेक्स्ट फ्रेम है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/itextstyleeffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट स्टाइल गुणों को समाहित करता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसमें एक टेक्स्ट फ्रेम है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **फ़ॉन्ट ऊँचाई का प्रभावी मान प्राप्त करें**

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रेजेंटेशन संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट होने के बाद पोर्शन की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **टेबल के लिए प्रभावी फ़िल फ़ॉर्मेट प्राप्त करें**

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/) इंटरफ़ेस प्रभावी फ़िल फ़ॉर्मेटिंग गुणों को समाहित करता है। सेल फ़ॉर्मेटिंग की प्राथमिकता रो फ़ॉर्मेटिंग से अधिक होती है, रो फ़ॉर्मेटिंग की प्राथमिकता कॉलम फ़ॉर्मेटिंग से अधिक होती है, और कॉलम फ़ॉर्मेटिंग की प्राथमिकता पूरे‑टेबल फ़ॉर्मेटिंग से अधिक होती है।

परिणामस्वरूप, टेबल सेल को ड्रॉ करने के लिए [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icellformateffectivedata/) गुणों का उपयोग किया जाता है। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहली शैप एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) है।

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या `GetEffective` एक स्नैपशॉट लौटाता है?

हमे हमेशा नहीं। प्रभावी डेटा उत्तराधिकार लागू होने के बाद गणना किए गए फ़ॉर्मेटिंग को दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। बाद में `GetEffective` कॉल फ़ॉर्मेटिंग को पुनः गणना कर सकता है और कैश्ड डेटा को रिफ्रेश कर सकता है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

### मुझे प्रभावी गुणों को फिर से कब पढ़ना चाहिए?

स्थानीय फ़ॉर्मेटिंग, पैरेंट स्टाइल, लेआउट फ़ॉर्मेटिंग, मास्टर फ़ॉर्मेटिंग या प्रेजेंटेशन‑स्तर के डिफ़ॉल्ट बदलने के बाद `GetEffective` को फिर से कॉल करें। अगली कॉल फ़ॉर्मेटिंग पदानुक्रम को पुनः मूल्यांकित करती है और वर्तमान प्रभावी परिणाम लौटाती है।

### क्या लेआउट/मास्टर स्लाइड को बदलने या हटाने से पहले प्राप्त प्रभावी गुण प्रभावित होते हैं?

हाँ, लेकिन परिवर्तन अगली `GetEffective` कॉल पर परिलक्षित होता है। यदि पैरेंट फ़ॉर्मेटिंग स्रोत को बदलया या हटाया गया, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। जब `GetEffective` फिर से कॉल किया जाता है, तो Aspose.Slides फ़ॉर्मेटिंग ट्री को पुनः मूल्यांकित करता है और फ़ॉन्ट, रंग, आकार आदि के मान बदल सकते हैं।

### क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मान संशोधित कर सकता हूँ?

नहीं। प्रभावी डेटा ऑब्जेक्ट्स गणना किए गए मानों को उजागर करते हैं। स्थानीय फ़ॉर्मेटिंग ऑब्जेक्ट्स में बदलाव करें, फिर प्रभावी मानों को दोबारा प्राप्त करें।

### यदि किसी प्रॉपर्टी को शैप स्तर पर, न लेआउट/मास्टर में, न ही ग्लोबल सेटिंग्स में सेट नहीं किया गया है तो क्या होता है?

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल होते हैं। यह निर्धारित मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

### प्रभावी फ़ॉन्ट मान से क्या मैं बता सकता हूँ कि कौन‑से स्तर ने आकार या फ़ॉन्ट प्रदान किया?

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और लेआउट, मास्टर तथा प्रेजेंटेशन स्तर पर स्थानीय मानों की जाँच करें कि पहली स्पष्ट परिभाषा कहां है।

### क्यों प्रभावी मान कभी‑कभी स्थानीय मानों के समान दिखते हैं?

क्योंकि स्थानीय मान अंततः अंतिम बन गया (उच्च‑स्तर का उत्तराधिकार आवश्यक नहीं रहा)। ऐसे मामलों में प्रभावी मान स्थानीय मान के बराबर होता है।

### मुझे प्रभावी गुणों का उपयोग कब करना चाहिए, और कब केवल स्थानीय गुणों के साथ काम करना चाहिए?

जब आपको सभी उत्तराधिकार लागू होने के बाद "जैसे रेंडर किया गया" परिणाम चाहिए, जैसे रंग, इंडेंट या आकार संरेखित करना, तो प्रभावी डेटा का उपयोग करें। यदि आपको बाद में फ़ॉर्मेटिंग बदलने के बावजूद उन मानों को संरक्षित रखना है, तो आवश्यक गुणों को अपनी खुद की वस्तु में कॉपी करें। यदि आप किसी विशिष्ट स्तर पर फ़ॉर्मेटिंग बदलना चाहते हैं, तो स्थानीय गुणों को संशोधित करें और फिर आवश्यक होने पर प्रभावी डेटा को फिर से पढ़कर परिणाम सत्यापित करें।