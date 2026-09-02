---
title: ".NET में प्रस्तुति आकृतियों को प्रबंधित करें"
linktitle: "आकृति हेरफ़ेर"
type: docs
weight: 40
url: /hi/net/shape-manipulations/
keywords:
- "PowerPoint आकृति"
- "प्रस्तुति आकृति"
- "स्लाइड पर आकृति"
- "आकृति खोजें"
- "आकृति क्लोन करें"
- "आकृति हटाएँ"
- "आकृति छिपाएँ"
- "आकृति क्रम बदलें"
- "इंटरऑप आकृति ID प्राप्त करें"
- "आकृति वैकल्पिक टेक्स्ट"
- "आकृति समायोजन बिंदु"
- "प्रीसेट आकृति समायोजन"
- "आकृति ज्यामिति"
- "आकृति लेआउट फ़ॉर्मेट"
- "आकृति SVG रूप में"
- "आकृति को SVG में"
- "आकृति संरेखित करें"
- "आकृति फ़्लिप करें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ प्रस्तुति आकृतियों की पहचान, समायोजन, क्लोन, हटाना, छिपाना, पुनः क्रमबद्ध करना, निर्यात, संरेखण और फ़्लिप करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोजते और संशोधित करते हैं और उनका स्टैकिंग क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति है।

यह लेख उसी मॉडल का पालन करता है। यह पहले यह समझाता है कि एक आकृति को विश्वसनीय रूप से कैसे पहचाना जाए और प्रीसेट आकृति समायोजन बिंदुओं को कैसे बदलें, फिर दिखाता है कि कैसे आकृतियों को क्लोन, हटाना, छिपाना और क्रमबद्ध करना है। अंतिम भाग लेआउट‑स्तरीय फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल उन कार्यों का उपयोग कर सकते हैं जो आपके कार्य‑प्रवाह की आवश्यकता है।

## **आकृतियों की पहचान और खोज**

संग्रह इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। आकृति को जोड़ने, हटाने या क्रम बदलने से उसका इंडेक्स बदल सकता है। प्रस्तुतिकरण के निर्माण और रखरखाव के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/name/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नामों को संपादित किया जा सकता है और वे अनन्य नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/alternativetext/) तब उपयोगी है जब कोई एक्सेसिबिलिटी विवरण या लेखक‑द्वारा प्रदान किया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या एक्सेसिबिलिटी के लिए पुनः लिखा जा सकता है, और यह अनन्य नहीं होता। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को चुपचाप डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अनन्य है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले आकृति ID से मेल खाता है। PowerPoint के साथ एकीकरण करते समय या जब आप आकृति के जीवनकाल के दौरान एक स्पष्ट संदर्भ चाहते हैं, इसे उपयोग करें। क्लोन या पुनः‑निर्मित आकृति अलग होती है और अपना स्वयं का ID प्राप्त करती है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/uniqueid/) गुण का प्रस्तुतिकरण स्कोप होता है, लेकिन यह एड‑इन्स के लिए है और पुनः‑निर्धारित किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो मैपिंग को एप्लिकेशन डेटा में रखें और सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण `Name` के साथ ऑर्डिनल तुलना करके खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID को रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं मिलती, तो कोड गलत ऑब्जेक्ट के साथ आगे बढ़ने के बजाय वह परिणाम रिपोर्ट करता है।

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

जब कोई ऑपरेशन एक विशिष्ट आकृति प्रकार के लिए हो, तो टाइप‑स्पेसिफिक सदस्य उपयोग करने से पहले इंटरफ़ेस की जाँच करें। यह उदाहरण टेक्स्ट और वैकल्पिक टेक्स्ट केवल तभी अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) हो।

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

## **प्रीसेट आकृति समायोजन की पहचान और संशोधन**

प्रीसेट ज्यामिति आकृतियों में समायोजन बिंदु हो सकते हैं जो कोने का आकार, तीर अनुपात या चाप कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें केवल‑पढ़ने योग्य [IGeometryShape.Adjustments](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/adjustments/) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकृति द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/net/aspose.slides/iadjustvalue/) में बदलने योग्य मान होता है।

केवल स्थिर संग्रह इंडेक्स पर भरोसा न करें। समायोजनों को क्रमबद्ध करके पढ़ें और केवल‑पढ़ने योग्य [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/type/) गुण को देखें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन किस चीज़ को नियंत्रित करता है। केवल‑पढ़ने योग्य [Name](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/name/) गुण अतिरिक्त पहचान जानकारी देता है और विशेष रूप से उपयोगी है जब किसी प्रीसेट में समान अर्थ वाला एक से अधिक समायोजन हो।

समायोजन के अर्थ से मेल खाने वाले मान गुण का प्रयोग करें:

| समायोजन प्रकार | उद्देश्य | बदलने वाला मान |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [RawValue](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | तीर की पूंछ की मोटाई | `RawValue` |
| `ArrowheadLength` | तीर के सिर की लंबाई | `RawValue` |
| `ArrowheadWidth` | तीर के सिर की चौड़ाई | `RawValue` |
| `StartAngle` | पाई या आर्क का प्रारंभिक कोण | [AngleValue](https://reference.aspose.com/slides/hi/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | पाई या आर्क का अंतिम कोण | `AngleValue` |

`Type` और `Name` को असाइन नहीं किया जा सकता। `RawValue` प्रीसेट की मूल ज्यामितीय इकाइयों में एक पढ़ने‑लिखने योग्य पूर्णांक है, जबकि `AngleValue` डिग्री में एक पढ़ने‑लिखने योग्य कोण है। समायोजन की संख्या, क्रम, अर्थ और वैध रेंज प्रीसेट के [ShapeType](https://reference.aspose.com/slides/hi/net/aspose.slides/igeometryshape/shapetype/) पर निर्भर करती है। एक प्रीसेट के लिए मान्य मान दूसरे के लिए अवैध या अलग प्रभाव वाला हो सकता है।

जब `Type` `ShapeAdjustmentType.Custom` हो, तो API मानक अर्थ नहीं पहचानती। `Name`, प्रीसेट प्रकार और मौजूदा मान की जाँच करें, और केवल तभी समायोजन को बदलें जब अपेक्षित अर्थ और रेंज ज्ञात हो। मान्य प्रकारों के लिए भी, यदि समान प्रकार एक से अधिक बार आता है तो मान चुनने से पहले इसे जाँचें। [Connector](/slides/hi/net/connector/) लेख में कनेक्टर बेंड समायोजन की यह स्थिति दर्शायी गई है।

निम्न सम्पूर्ण उदाहरण तीन प्रीसेट आकृतियों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह प्रत्येक समायोजन को क्रमबद्ध करता है, उसका `Name` और `Type` रिपोर्ट करता है, आकार‑संबंधी मान `RawValue` से बदलता है, कोण `AngleValue` से बदलता है, और परिणाम सहेजता है। बाएँ कॉलम में डिफ़ॉल्ट ज्यामिति रहती है; दाएँ कॉलम में समायोजित गोल आकृति, चार‑तरफ़ा तीर और पाई दिखती है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// डिफ़ॉल्ट और समायोजित आकृति कॉलम के लिए हेडर जोड़ता है।
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

समान्य प्रकार को बदलने से पहले जांचना कोड को उसके उद्देश्य के बारे में स्पष्ट बनाता है और यह मानने से बचाता है कि विभिन्न प्रीसेट आकृतियों में समान इंडेक्स का अर्थ समान है।

## **आकृति संग्रह में परिवर्तन**

जोड़ना, क्लोन करना, हटाना और पुनः‑क्रमबद्ध करना सीधे संग्रह पर कार्य करता है। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले कैप्चर किए गए इंडेक्स पर निर्भर नहीं रहना चाहिए।

### **आकृति को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र कॉपी बनाता है और उसे लक्षित संग्रह के अंत में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/insertclone/) भी कॉपी बनाता है लेकिन उसे निर्दिष्ट ज़‑ऑर्डर इंडेक्स पर रखता है। वह ओवरलोड जो निर्देशांक स्वीकार करता है, क्लोन का आकार नहीं बदलता; चौड़ाई और ऊँचाई वाले ओवरलोड इसे रिसाइज़ भी कर सकते हैं।

उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबल वाले आयत को आगे क्लोन करता है, और दूसरा क्लोन पीछे जोड़ता है। किसी भी क्लोन में परिवर्तन स्रोत आकृति को प्रभावित नहीं करता।

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

क्लोन आकृति की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, को कॉपी करता है। जब इन मानों को अनन्य होना आवश्यक हो तो क्लोन को नए तार्किक पहचानकर्ता असाइन करें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, परन्तु क्लोन नई संग्रह आइटम के रूप में नई आकृति पहचान रखता है।

### **आकृतियाँ हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/remove/) विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटाता है। इंडेक्स‑आधारित इटरेशन के दौरान कई मेलों को हटाते समय अंत से शुरू करके ट्रैवर्स करें ताकि शेष प्रत्येक इंडेक्स मान्य बना रहे।

यह उदाहरण निर्धारित नाम वाली प्रत्येक आकृति को हटाता है। यह `slide.Shapes[i]` पढ़ता है, न कि स्थिर संग्रह आइटम, और आकृति को अनावश्यक रूप से कास्ट नहीं करता।

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

हटाने के बाद, आकृति गिनती और बाद की आकृतियों के इंडेक्स बदलते हैं। अनछुए आकृतियों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन और अन्य प्रस्तुति विशेषताओं को भी विचार करें जो हटाए गए ऑब्जेक्ट का संदर्भ दे सकते हैं; दृश्य आकृति को हटाना स्लाइड की उपस्थिति से अधिक बदल सकता है।

### **आकृति को छिपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/hidden/) को `true` सेट करने से आकृति संग्रह में रहती है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देती। उसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए छिपाना वैकल्पिक तत्वों के लिए उपयुक्त है जिन्हें बाद में पुनः दिखाया जा सकता है।

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

छिपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी खोजा जा सकता है और उपयोगकर्ता या कोड द्वारा अनहाइड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑ऑर्डर बदलें**

ओवरलैपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [Reorder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/reorder/) मौजूदा आकृति को लक्ष्य इंडेक्स पर बिना क्लोन किए ले जाता है। इंडेक्स `0` पीछे है; `Count - 1` आगे है।

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

पहले आयत बनाता है और शुरू में अंडाकार के पीछे रहता है। इसे अंतिम इंडेक्स पर ले जाने से वह आगे आ जाता है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद Z‑ऑर्डर को अंतिम रूप दें, क्योंकि ये ऑपरेशन नई संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण**

सामान्य स्लाइड, लेआउट स्लाइड और मास्टर स्लाइड की अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति सामान्य स्लाइड पर समान रूप से स्थित आकृति के समान ऑब्जेक्ट नहीं होती। लेआउट आकृतियों की जाँच करें जब आपको लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझना या बदलना हो।

निम्न उदाहरण प्रत्येक लेआउट आकृति का [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/fillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/lineformat/) पढ़ता है, बिना यह मान्य हुए कि हर आकृति `AutoShape` है।

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

लेआउट को संपादित करने से उन कई स्लाइडों पर प्रभाव पड़ सकता है जो इसे उपयोग करती हैं। लेआउट आकृति बदलने से पहले यह निर्धारित करें कि सामान्य स्लाइड ऑब्जेक्ट को विरासत में मिला है या उसमें स्थानीय ओवरराइड है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/writeassvg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल वह आकृति होती है, पूरे स्लाइड पृष्ठभूमि या समीपस्थ आकृतियों को नहीं।

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

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकृति के फ़ॉर्मेटिंग तथा फ़ॉन्ट और छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना की आवश्यकता है, तो व्यक्तिगत आकृति के बजाय स्लाइड निर्यात करें। कॉलर को स्ट्रीम का स्वामित्व होता है और उसे डिस्पोज़ करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/alignshapes/) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेक्स को संरेखित करता है। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapesalignmenttype/) किनारा, मध्य रेखा या वितरण मोड को निर्दिष्ट करता है। `alignToSlide` को `true` करने से स्लाइड किनारों के सापेक्ष संरेखण होता है; `false` करने पर चयनित आकृतियों के आपस में सापेक्ष संरेखण होता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकृति रेफ़रेंसेज़ को संरेखण से ठीक पहले उनके वर्तमान इंडेक्स में बदल दिया जाता है।

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

संरेखण स्थान बदलता है, Z‑ऑर्डर नहीं। सापेक्ष संरेखण के लिए सामान्यतः कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिए स्पेसिंग निर्धारित करने हेतु पर्याप्त आकृतियों की जरूरत होती है। मेथड कॉल करने से पहले संग्रह को संशोधित किया हो तो इंडेक्स को पुनः‑गणना करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeframe/) वर्ग स्थिति, आकार, क्षैतिज और ऊर्ध्वाधर फ़्लिप सेटिंग्स तथा घुमाव संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्रिय करता है, `False` निष्क्रिय करता है, और `NotDefined` अननिर्दिष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति रखता है।

![फ़्लिप करने से पहले की आकृति](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/frame/) असाइन करने से पूरा फ्रेम बदल जाता है।

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

सहेजी गई आकृति क्षैतिज और ऊर्ध्वाधर दोनों दिशा में मिरर की गई है जबकि उसकी स्थिति, आकार और घुमाव समान रहते हैं।

![फ़्लिप करने के बाद की आकृति](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकृति पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल अल्पकालिक प्रोसेसिंग के लिए जब संग्रह ऑपरेशन से पहले नहीं बदलेगा। टेम्पलेट्स के लिए मान्य `Name` या `AlternativeText` नियम को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `OfficeInteropShapeId` उपयोग करें।

**क्या आकृति को छिपाने से वह Z‑ऑर्डर से हट जाता है?**

नहीं। छिपी हुई आकृति वही इंडेक्स पर संग्रह में बनी रहती है। इसे पाया, पुनः‑क्रमबद्ध, संपादित या फिर से दिखाया जा सकता है।

**क्लोन की गई आकृति ने अन्य आकृति के सामने क्यों दिखाई?**

`AddClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑ऑर्डर का सामने वाला भाग है। प्रारंभिक इंडेक्स चुनने के लिए `InsertClone` उपयोग करें या सभी आकृतियों को जोड़ने के बाद `Reorder` करें।

**क्या मैं प्रीसेट आकृति समायोजन की पहचान के लिए स्थिर इंडेक्स उपयोग कर सकता हूँ?**

केवल तब जब आप निश्चित प्रीसेट और संग्रह लेआउट को मान्य कर चुके हों। `IGeometryShape.Adjustments` को क्रमबद्ध करके `IAdjustValue.Type` की जाँच करें; जब समान अर्थ वाला प्रकार कई बार मौजूद हो तो अतिरिक्त जानकारी के रूप में `IAdjustValue.Name` का उपयोग करें।