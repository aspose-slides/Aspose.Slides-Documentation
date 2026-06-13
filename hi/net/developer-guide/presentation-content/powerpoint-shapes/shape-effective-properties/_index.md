---
title: .NET में प्रस्तुतियों से आकार की प्रभावी प्रॉपर्टीज़ प्राप्त करें
linktitle: प्रभावी प्रॉपर्टीज़
type: docs
weight: 50
url: /hi/net/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बिवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "जानेँ कि .NET के लिए Aspose.Slides कैसे सटीक PowerPoint रेंडरिंग के लिए प्रभावी आकार प्रॉपर्टीज़ की गणना और लागू करता है."
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** प्रॉपर्टीज़ के अंतर को समझाता है। स्थानीय मान उन मानों को कहा जाता है जो सीधे किसी विशिष्ट फ़ॉर्मेटिंग स्तर पर सेट किए जाते हैं, जैसे:

1. स्लाइड पर Portion प्रॉपर्टीज़।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शAPE टेक्स्ट स्टाइल्स, जब Portion के टेक्स्ट फ्रेम शAPE में यह मौजूद हो।
1. प्रेजेंटेशन में ग्लोबल टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम "जैसे रेंडर किया गया" फ़ॉर्मेटिंग चाहिए, तो वह इनहेरिटेंस चेन को रिजॉल्व करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय फ़ॉर्मेट ऑब्जेक्ट पर `GetEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहले स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसके पास एक टेक्स्ट फ्रेम और कम से कम एक Portion है।

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}

प्रभावी फ़ॉर्मेटिंग डेटा उन वर्तमान गणना किए गए फ़ॉर्मेटिंग को दर्शाता है जो इनहेरिटेंस लागू होने के बाद प्राप्त होते हैं। वर्तमान इम्प्लीमेंटेशन में, कुछ प्रभावी डेटा ऑब्जेक्ट्स, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/iportionformateffectivedata/), आंतरिक रूप से कैश हो सकते हैं। पैरेंट या इनहेरिटेड फ़ॉर्मेटिंग बदलने के बाद `GetEffective` को पुनः कॉल करने से कैश्ड डेटा रिफ्रेश हो जाता है, और पहले प्राप्त ऑब्जेक्ट अब पहले की स्थिति को दर्शा नहीं सकता। यदि आपको प्रभावी मानों को बाद में पुनः उपयोग के लिए संरक्षित रखना है, तो आवश्यक प्रॉपर्टीज़ जैसे फ़ॉन्ट हाईट, फ़िल कलर, फ़ॉन्ट स्टाइल, या अलाइनमेंट को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।

{{% /alert %}}

## **कैमरा के प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको कैमरा की प्रभावी प्रॉपर्टीज़ प्राप्त करने की सुविधा देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icameraeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी कैमरा प्रॉपर्टीज़ होती हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icameraeffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि कैमरा की प्रभावी प्रॉपर्टीज़ कैसे प्राप्त की जा सकती हैं। यह मानता है कि पहले स्लाइड पर पहला शAPE 3D फ़ॉर्मेटिंग रखता है।

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **लाइट रिग की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको लाइट रिग की प्रभावी प्रॉपर्टीज़ प्राप्त करने की सुविधा देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrigeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें प्रभावी लाइट रिग प्रॉपर्टीज़ होती हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ilightrigeffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग की प्रभावी प्रॉपर्टीज़ कैसे प्राप्त की जा सकती हैं। यह मानता है कि पहले स्लाइड पर पहला शAPE 3D फ़ॉर्मेटिंग रखता है।

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **शAPE बिवेल की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको शAPE बिवेल की प्रभावी प्रॉपर्टीज़ प्राप्त करने की सुविधा देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapebeveleffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट को दर्शाता है जिसमें शAPE के लिए प्रभावी फेस-रिलिफ़ प्रॉपर्टीज़ होती हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapebeveleffectivedata/) इंस्टेंस [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि शAPE के टॉप बिवेल की प्रभावी प्रॉपर्टीज़ कैसे प्राप्त की जा सकती हैं। यह मानता है कि पहले स्लाइड पर पहला शAPE 3D फ़ॉर्मेटिंग रखता है।

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **टेक्स्ट फ्रेम की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम की प्रभावी प्रॉपर्टीज़ प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformateffectivedata/) इंटरफ़ेस में प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग प्रॉपर्टीज़ होती हैं।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग प्रॉपर्टीज़ कैसे प्राप्त की जाएँ। यह मानता है कि पहले स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसके पास एक टेक्स्ट फ्रेम है।

```csharp
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

## **टेक्स्ट स्टाइल की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल की प्रभावी प्रॉपर्टीज़ प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/itextstyleeffectivedata/) इंटरफ़ेस में प्रभावी टेक्स्ट स्टाइल प्रॉपर्टीज़ होती हैं।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल प्रॉपर्टीज़ कैसे प्राप्त की जाएँ। यह मानता है कि पहले स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) है जिसके पास एक टेक्स्ट फ्रेम है।

```csharp
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

## **प्रभावी फ़ॉन्ट हाईट मान प्राप्त करें**

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट हाईट प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि Portion की प्रभावी फ़ॉन्ट हाईट स्थानीय फ़ॉन्ट हाईट मानों को विभिन्न प्रेजेंटेशन संरचना स्तरों पर सेट करने के बाद कैसे बदलती है।

```csharp
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

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/ifillformateffectivedata/) इंटरफ़ेस में प्रभावी फ़िल फ़ॉर्मेटिंग प्रॉपर्टीज़ होती हैं। सेल फ़ॉर्मेटिंग की प्रायोरिटी रो फ़ॉर्मेटिंग से अधिक होती है, रो फ़ॉर्मेटिंग की प्रायोरिटी कॉलम फ़ॉर्मेटिंग से अधिक होती है, और कॉलम फ़ॉर्मेटिंग की प्रायोरिटी पूरे टेबल फ़ॉर्मेटिंग से अधिक होती है।

परिणामस्वरूप, टेबल सेल को ड्रॉ करने के लिए [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/net/aspose.slides/icellformateffectivedata/) प्रॉपर्टीज़ का उपयोग किया जाता है। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग कैसे प्राप्त की जाए। यह मानता है कि पहले स्लाइड पर पहला शAPE एक [ITable](https://reference.aspose.com/slides/hi/net/aspose.slides/itable/) है।

```csharp
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

**क्या `GetEffective` एक स्नैपशॉट लौटाता है?**

 हमेशा नहीं। प्रभावी डेटा इनहेरिटेंस लागू होने के बाद गणना किए गए फ़ॉर्मेटिंग को दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट्स आंतरिक रूप से कैश हो सकते हैं। एक बाद का `GetEffective` कॉल फ़ॉर्मेटिंग को फिर से गणना कर सकता है और कैश्ड डेटा रिफ्रेश कर सकता है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट नहीं माना जाना चाहिए।

**मुझे प्रभावी प्रॉपर्टीज़ फिर से कब पढ़नी चाहिए?**

स्थानीय फ़ॉर्मेटिंग, पैरेंट स्टाइल्स, लेआउट फ़ॉर्मेटिंग, मास्टर फ़ॉर्मेटिंग, या प्रेजेंटेशन-स्तर के डिफॉल्ट्स को बदलने के बाद `GetEffective` को फिर से कॉल करें। अगली कॉल फ़ॉर्मेटिंग पदानुक्रम को पुनः मूल्यांकित करेगी और वर्तमान प्रभावी परिणाम लौटाएगी।

**क्या लेआउट/मास्टर स्लाइड को बदलने/हटाने से उन प्रभावी प्रॉपर्टीज़ पर असर पड़ता है जो पहले ही प्राप्त हो चुकी हैं?**

 हाँ, लेकिन परिवर्तन अगली `GetEffective` कॉल पर प्रतिबिंबित होगा। यदि पैरेंट फ़ॉर्मेटिंग स्रोत को बदल दिया जाता है या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। एक बार `GetEffective` फिर से कॉल करने पर Aspose.Slides फ़ॉर्मेटिंग ट्री को पुनः मूल्यांकित करता है और resulting फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मानों को संशोधित कर सकता हूँ?**

 नहीं। प्रभावी डेटा ऑब्जेक्ट्स गणना किए गए मानों को उजागर करते हैं। स्थानीय फ़ॉर्मेटिंग ऑब्जेक्ट्स में परिवर्तन करें, और फिर प्रभावी मानों को पुनः प्राप्त करें।

**यदि शAPE स्तर पर, न लेआउट/मास्टर में, न ग्लोबल सेटिंग्स में प्रॉपर्टी सेट नहीं है तो क्या होता है?**

 प्रभावी मान डिफ़ॉल्ट मेकेनिज़्म द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफॉल्ट शामिल हैं। वह हल किया गया मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

**एक प्रभावी फ़ॉन्ट मान से क्या मैं पता लगा सकता हूँ कि किस स्तर ने आकार या फ़ॉन्ट प्रदान किया?**

 सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत जानने के लिए Portion, पैराग्राफ, टेक्स्ट फ्रेम, और लेआउट, मास्टर, प्रेजेंटेशन स्तर पर टेक्स्ट स्टाइल में स्थानीय मान देखें कि पहला स्पष्ट परिभाषा कहाँ है।

**कभी-कभी प्रभावी मान स्थानीय मानों के समान क्यों दिखते हैं?**

 क्योंकि स्थानीय मान अंततः अंतिम बन जाता है (ऊँचे स्तर की इनहेरिटेंस की आवश्यकता नहीं रही)। ऐसे मामलों में प्रभावी मान स्थानीय मान के समान होता है।

**मुझे प्रभावी प्रॉपर्टीज़ कब उपयोग करनी चाहिए, और कब केवल स्थानीय प्रॉपर्टीज़ के साथ काम करना चाहिए?**

जब आपको सभी इनहेरिटेंस लागू होने के बाद "जैसे रेंडर किया गया" परिणाम चाहिए, तो प्रभावी डेटा उपयोग करें, जैसे रंग, इंडेंट, या आकार को संरेखित करने के लिए। यदि आपको ये मान बाद में फ़ॉर्मेटिंग परिवर्तन के बावजूद संरक्षित रखना हैं, तो आवश्यक प्रॉपर्टीज़ को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर फ़ॉर्मेटिंग बदलनी है, तो स्थानीय प्रॉपर्टीज़ संशोधित करें और फिर आवश्यक होने पर प्रभावी डेटा को फिर से पढ़ें ताकि परिणाम सत्यापित हो सके।