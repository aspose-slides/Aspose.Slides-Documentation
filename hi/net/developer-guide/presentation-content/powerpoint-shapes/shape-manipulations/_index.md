---
title: ".NET में प्रस्तुति आकार प्रबंधित करें"
linktitle: "आकार हेरफेर"
type: docs
weight: 40
url: /hi/net/shape-manipulations/
keywords:
- "PowerPoint आकार"
- "प्रस्तुति आकार"
- "स्लाइड पर आकार"
- "आकार खोजें"
- "आकार क्लोन करें"
- "आकार हटाएँ"
- "आकार छिपाएँ"
- "आकार क्रम बदलें"
- "Interop आकार ID प्राप्त करें"
- "आकार वैकल्पिक पाठ"
- "आकार समायोजन बिंदु"
- "पूर्वनिर्धारित आकार समायोजन"
- "आकार ज्यामिति"
- "आकार लेआउट स्वरूप"
- "आकार SVG रूप में"
- "आकार को SVG में"
- "आकार संरेखित करें"
- "आकार फ़्लिप करें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ प्रस्तुति आकारों की पहचान, समायोजन, क्लोन, हटाना, छिपाना, पुन: क्रमित करना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET स्लाइड पर आकारों को एक क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकारों को खोजते और संशोधित करते हैं और उनका स्टैक क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे का आकार है, जबकि अंतिम इंडेक्स सबसे आगे का आकार है।

यह लेख उसी मॉडल का पालन करता है। यह पहले यह समझाता है कि आकार को विश्वसनीय रूप से कैसे पहचानें और पूर्वनिर्धारित आकार समायोजन बिंदुओं को कैसे बदलें, फिर क्लोन, हटाना, छिपाना, और आकारों को पुनः क्रमित करना दिखाता है। अंतिम अनुभाग लेआउट‑स्तर के फ़ॉर्मेटिंग, SVG निर्यात, संरेखण, और फ़्लिप सेटिंग्स को कवर करते हैं। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल वही संचालन उपयोग कर सकते हैं जो आपके कार्यप्रवाह को आवश्यक हैं।

## **आकारों की पहचान और खोज**

- [नाम](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/name/) डिवेलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और वे अनन्य नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [वैकल्पिकपाठ](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/alternativetext/) तब उपयोगी है जब पहुँच‑योग्य विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकार की पहचान करता है। यह उपयोगकर्ताओं के लिए दिखाई देता है, स्थानीयकृत या पहुँच‑योग्यता के लिए पुनः लिखा जा सकता है, और यह अनन्य नहीं होता। अर्थपूर्ण पहुँच‑योग्यता पाठ को चुपचाप डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अनन्य है और PowerPoint interop द्वारा उपयोग किए जाने वाले आकार ID से मेल खाता है। PowerPoint के साथ एकीकरण करते समय या जब आपको आकार के जीवन‑काल के दौरान एक स्पष्ट संदर्भ चाहिए तब इसे उपयोग करें। एक क्लोन या पुनः‑निर्मित आकार एक अलग आकार है और उसका अपना ID प्राप्त करता है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/uniqueid/) गुण का प्रेजेंटेशन स्तर है, लेकिन यह ऐड‑इन के लिये अभिप्रेत है और पुनः‑सौंपा जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और यह सत्यापित करें कि अपेक्षित आकार अभी भी मौजूद है।

व्यावहारिक उदाहरण के लिये जहाँ वैकल्पिक टेक्स्ट शीर्षक और विवरण पढ़े और अपडेट किए जाते हैं, देखें [Manage Alternative Text Titles and Descriptions](/slides/hi/net/presentation-accessibility/)। वैकल्पिक टेक्स्ट का उपयोग दृश्य की अर्थ को पाठकों तक पहुँचाने के लिये करें, और इसे कोड द्वारा उपयोग किए जाने वाले आकार नामों से अलग रखें।

निम्न उदाहरण `Name` द्वारा क्रमिक तुलना के साथ खोज करता है और स्लाइड‑स्कोप्ड interop ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकार नहीं मिलता, तो कोड उस परिणाम को रिपोर्ट करता है न कि गलत ऑब्जेक्ट के साथ जारी रहता।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

जब कोई ऑपरेशन आकार प्रकार के लिये विशिष्ट हो, तो प्रकार‑विशिष्ट सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण तभी टेक्स्ट और वैकल्पिक टेक्स्ट अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) हो।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **पूर्वनिर्धारित आकार समायोजन की पहचान और संशोधन**

पूर्वनिर्धारित ज्यामिति आकार ऐसे समायोजन बिंदु उजागर कर सकते हैं जो कोने का आकार, तीर अनुपात, या आर्क कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape.Adjustments](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/adjustments/) संग्रह के माध्यम से एक्सेस करें। यह संग्रह स्वयं आकार द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/net/aspose.slides/iadjustvalue/) में एक मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह इंडेक्स पर भरोसा न करें। समायोजनों के माध्यम से इटेरेट करें और केवल‑पढ़ने योग्य [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/type/) गुण को जांचें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। केवल‑पढ़ने योग्य [Name](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/name/) गुण अतिरिक्त पहचान जानकारी प्रदान करता है और उन स्थितियों में विशेष रूप से उपयोगी है जहाँ एक पूर्वनिर्धारित में समान अर्थ वाला एक से अधिक समायोजन हो।

समायोजन के अर्थ से मेल खाने वाले मान गुण का उपयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने का मान |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [RawValue](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | तीर पूंछ की मोटाई | `RawValue` |
| `ArrowheadLength` | तीर सिर की लंबाई | `RawValue` |
| `ArrowheadWidth` | तीर सिर की चौड़ाई | `RawValue` |
| `StartAngle` | पाई या चाप का प्रारंभिक कोण | [AngleValue](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | पाई या चाप का अंतिम कोण | `AngleValue` |

`Type` और `Name` को असाइन नहीं किया जा सकता। `RawValue` पूर्वनिर्धारित की मूल ज्यामिति इकाइयों में पढ़ने/लिखने योग्य पूर्णांक है, जबकि `AngleValue` डिग्री में पढ़ने/लिखने योग्य कोण है। समायोजनों की संख्या, क्रम, अर्थ, और वैध सीमा पूर्वनिर्धारित [ShapeType](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/shapetype/) पर निर्भर करती है। एक पूर्वनिर्धारित में मान्य मान दूसरे में अमान्य या अलग प्रभाव डाल सकता है।

जब `Type` `ShapeAdjustmentType.Custom` हो, तो API मानक अर्थ नहीं पहचानती। `Name`, पूर्वनिर्धारित प्रकार, और मौजूदा मान की जाँच करें, और तब तक समायोजन न बदलें जब तक अपेक्षित अर्थ और सीमा ज्ञात न हो। पहचान योग्य प्रकारों के लिये भी, मान चुनने से पहले जाँचें कि वही प्रकार दो बार से अधिक उपस्थित है या नहीं। [Connector](/slides/hi/net/connector/) लेख में कनेक्टर बेंड समायोजन के साथ यह स्थिति दिखाई गई है।

निम्न पूर्ण उदाहरण तीन पूर्वनिर्धारित आकारों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन के माध्यम से इटेरेट करता है, उसके `Name` और `Type` को रिपोर्ट करता है, आकार‑संबंधी मानों को `RawValue` से बदलता है, कोणों को `AngleValue` से बदलता है, और परिणाम को सहेजता है। बाएँ कॉलम में डिफ़ॉल्ट ज्यामिति रहती है; दाएँ कॉलम में समायोजित गोल आयत, चार‑तरफ़ा तीर, और पाई दिखाया गया है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// डिफ़ॉल्ट और समायोजित आकार कॉलमों के लिए हेडर जोड़ता है।
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

समायोजन के अर्थ के आधार पर मान बदलने से कोड की मंशा स्पष्ट रहती है और यह अनुमान लगाने से बचाता है कि विभिन्न पूर्वनिर्धारित आकारों में एक समान संग्रह इंडेक्स का अर्थ समान है।

## **आकार संग्रह को संशोधित करें**

जोड़ना, क्लोन करना, हटाना, और पुनः‑क्रमित करने वाले मेथड्स संग्रह पर तुरंत कार्य करते हैं। यदि कोई ऑपरेशन आकारों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर भरोसा न रखें।

### **एक आकार को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/insertclone/) भी एक प्रतिलिपि बनाता है लेकिन उसे निर्दिष्ट z‑order इंडेक्स पर रखता है। जो ओवरलोड निर्देशांक स्वीकार करते हैं वे आकार का आकार बदले बिना क्लोन को स्थानांतरित करते हैं; चौड़ाई व ऊँचाई वाले ओवरलोड इसे पुनः‑आकारित भी कर सकते हैं।

उदाहरण एक गंतव्य स्लाइड बनाता है, लेबलयुक्त आयत को सामने क्लोन करता है, और दूसरा क्लोन पीछे सम्मिलित करता है। दोनों क्लोन में किए गए परिवर्तन मूल आकार को प्रभावित नहीं करते।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

क्लोनिंग आकार की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक पाठ शामिल हैं, को कॉपी करता है। जब इन मानों को अनन्य होना आवश्यक हो, तो क्लोन को नए तार्किक पहचानकर्ता असाइन करें। जटिल आकारों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभालते हैं, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसके पास नई आकार पहचान होती है।

### **आकार हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/remove/) एक विशिष्ट आकार ऑब्जेक्ट को उसके संग्रह से हटा देता है। कई मिलानों को इंडेक्स‑आधारित इटेरेशन के दौरान हटाते समय, अंत से शुरू करके चलें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण निर्दिष्ट नाम वाले प्रत्येक आकार को हटाता है। यह `slide.Shapes[i]` पढ़ता है, न कि स्थिर संग्रह आइटम, और आकार को अनावश्यक रूप से कास्ट नहीं करता।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

हटाने के बाद आकार गिनती और बाद के आकारों के इंडेक्स बदल जाते हैं। अप्रभावित आकारों के संदर्भ सहेजे हुए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन, और अन्य प्रस्तुति विशेषताओं को भी ध्यान में रखें जो हटाए गए ऑब्जेक्ट का संदर्भ रख सकते हैं; दृश्यात्मक रूप से केवल आकार हटाने से स्लाइड की उपस्थिति से अधिक बदल सकता है।

### **एक आकार को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/hidden/) को `true` सेट करने से आकार संग्रह में बना रहता है लेकिन सामान्य स्लाइड‑शो में प्रकट नहीं होता। उसका इंडेक्स, फ़ॉर्मेटिंग, और सामग्री कोड के लिये उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिये छिपाना उपयुक्त है जिन्हें बाद में पुनः सक्रिय किया जा सकता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

छिपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अनहिड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑क्रम बदलें**

ओवरलैपिंग आकार संग्रह क्रम में पेंट होते हैं। [Reorder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/reorder/) मौजूदा आकार को लक्ष्य इंडेक्स पर बिना क्लोन किए ले जाता है। इंडेक्स `0` पीछे है; `Count - 1` आगे है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

आयत पहले बनाया जाता है और प्रारम्भ में अंडाकार के पीछे रहता है। इसे अंतिम इंडेक्स पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकारों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये क्रियाएँ नई संग्रह आइटम जोड़ती या सम्मिलित करती हैं और इच्छित स्टैक को बदल सकती हैं।

## **लेआउट स्लाइड्स पर आकारों की जाँच**

सामान्य स्लाइड, लेआउट स्लाइड, और मास्टर स्लाइड के पास अलग‑अलग आकार संग्रह होते हैं। लेआउट संग्रह में एक आकार सामान्य स्लाइड पर समान स्थिति वाले आकार से अलग ऑब्जेक्ट होता है। जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझने या बदलने की आवश्यकता हो, तो लेआउट आकारों की जाँच करें।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

लेआउट को संपादित करने से उस पर आधारित कई स्लाइड प्रभावित हो सकते हैं। लेआउट आकार बदलने से पहले निश्चित करें कि कोई सामान्य स्लाइड उस ऑब्जेक्ट को विरासत में लेता है या स्थानीय ओवरराइड रखता है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकार को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/writeassvg/) एक आकार की रेंडर्ड सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकार होता है, पूरे स्लाइड बैकग्राउंड या पड़ोसी आकार नहीं।

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

रेंडर करते समय प्रस्तुति खुली रखें। आउटपुट आकार के फ़ॉर्मेटिंग और फ़ॉन्ट व इमेज जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए, तो व्यक्तिगत आकार की बजाय स्लाइड को निर्यात करें। कॉलर स्ट्रीम का मालिक होता है और उसे डिस्पोज़ करना पड़ता है।

## **आकारों को संरेखित करें**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/alignshapes/) ओवरलोड सभी आकार या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा, या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने से स्लाइड किनारों का उपयोग होता है; `false` करने पर चयनित आकार आपस में संरेखित होते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

संरेखण स्थितियों को बदलता है, z‑order नहीं। सापेक्ष संरेखण के लिये सामान्यतः कम से कम दो आकार आवश्यक होते हैं, जबकि क्षैतिज या लंबवत वितरण के लिये पर्याप्त आकार चाहिए ताकि दूरी निर्धारित की जा सके। विधि कॉल करने से पहले यदि आप संग्रह को संशोधित करते हैं तो इंडेक्स पुनः‑गणना करें।

## **आकार को पलटें**

[ShapeFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeframe/) वर्ग स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग, तथा घूर्णन संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप सक्षम करता है, `False` निष्क्रिय करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक बिना फ़्लिप किए आकार को शामिल करता है।

![फ़्लिप करने से पहले आकार](shape_to_be_flipped.png)

उदाहरण प्रत्येक अन्य फ्रेम मान को बरकरार रखता है और केवल दो फ़्लिप सेटिंग को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/frame/) असाइन करने से पूरा फ्रेम बदल जाता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

सहेजा गया आकार क्षैतिज और लंबवत दोनों दिशा में प्रतिबिंबित है जबकि उसकी स्थिति, आकार, और घूर्णन अपरिवर्तित रहता है।

![फ़्लिप करने के बाद आकार](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकार पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिये उपयोग करें जब तक संग्रह उस इंडेक्स के उपयोग से पहले नहीं बदलता। निर्मित टेम्पलेट्स के लिये वैध `Name` या `AlternativeText` नियम अपनाएँ, या स्लाइड‑स्कोप्ड interop कार्य के लिये `OfficeInteropShapeId` उपयोग करें।

**क्या छिपे हुए आकार को हटाने से वह z‑order से बाहर हो जाता है?**

नहीं। छिपा आकार उसी इंडेक्स पर संग्रह में बना रहता है। इसे फिर से पाया, पुनः‑क्रमित, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन किया हुआ आकार दूसरे आकार के सामने क्यों प्रकट हुआ?**

`AddClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का सामने वाला भाग होता है। प्रारम्भिक इंडेक्स चुनने के लिये `InsertClone` उपयोग करें या सभी आकार जोड़ने के बाद `Reorder` करें।

**क्या मैं पूर्वनिर्धारित आकार समायोजन की पहचान के लिये स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तब जब आप निश्चित हों कि पूर्वनिर्धारित और संग्रह लेआउट बिल्कुल वैसा ही है। `IGeometryShape.Adjustments` के माध्यम से इटेरेट करना और `IAdjustValue.Type` जांचना पसंद करें; जब एक ही अर्थ वाला प्रकार कई बार आता है तो अतिरिक्त जानकारी हेतु `IAdjustValue.Name` का उपयोग करें।