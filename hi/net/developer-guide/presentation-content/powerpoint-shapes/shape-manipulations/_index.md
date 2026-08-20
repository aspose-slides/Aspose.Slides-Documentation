---
title: .NET में प्रस्तुति आकृतियों का प्रबंधन
linktitle: आकृति हेरफ़ेर
type: docs
weight: 40
url: /hi/net/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएँ
- आकृति छिपाएँ
- आकृति क्रम बदलें
- Interop आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति लेआउट फ़ॉर्मेट
- आकृति को SVG के रूप में
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुति आकृतियों को पहचानना, क्लोन करना, हटाना, छिपाना, क्रम बदलना, निर्यात करना, संरेखित करना और फ़्लिप करना सीखें।"
---
## **परिचय**

Aspose.Slides for .NET स्लाइड पर आकृतियों को क्रमबद्ध [IShapeCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/) के रूप में दर्शाता है। यह संग्रह आकृतियों को खोजने और संशोधित करने की जगह है तथा उनकी स्टैकिंग क्रम का स्रोत भी है: इंडेक्स `0` सबसे पीछे वाली आकृति है, जबकि अंतिम इंडेक्स सबसे आगे वाली आकृति है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि आकृति की विश्वसनीय पहचान कैसे की जाए, फिर दिखाता है कि कैसे आकृति को क्लोन, हटाया, छुपाया और पुनः क्रमित किया जाए। अंतिम भाग लेआउट‑स्तर फ़ॉर्मेटिंग, SVG निर्यात, संरेखण और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल अपने कार्य‑प्रवाह की आवश्यकता वाले संचालन का उपयोग कर सकते हैं।

## **आकृतियों की पहचान और खोज**

कलेक्शन इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थायी पहचानकर्ता नहीं होते। आकृति को जोड़ने, हटाने या पुनः क्रमित करने से उसका इंडेक्स बदल सकता है। प्रस्तुति के निर्माण और रख‑रखाव के तरीके के अनुसार पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/name/) डेवलपर‑नियंत्रित टेम्पलेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से निरीक्षण किया जा सकता है। नाम संपादित किए जा सकते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो एक नामकरण सम्मेलन स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/alternativetext/) तब उपयोगी है जब कोई एक्सेसिबिलिटी विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या एक्सेसिबिलिटी के लिए पुनर्लेखित किया जा सकता है, और अनिवार्य रूप से अद्वितीय नहीं होता। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को बिना संकेत के डेटाबेस कुंजी के रूप में पुनः उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/officeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले Shape ID से मेल खाता है। PowerPoint के साथ एकीकरण या किसी आकृति के जीवन‑काल के दौरान अस्पष्ट संदर्भ की आवश्यकता होने पर इसका उपयोग करें। क्लोन या पुनः‑निर्मित आकृति अलग होती है और उसकी अपनी ID प्राप्त करती है।

संबंधित [UniqueId](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/uniqueid/) प्रॉपर्टी का प्रस्तुति‑स्तर पर उपयोग होता है, लेकिन यह ऐड‑इन के लिए अभिप्रेत है और पुनः‑असाइन किया जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं माना जाना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है तो मैपिंग को एप्लिकेशन डेटा में रखें और सुनिश्चित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण `Name` के द्वारा ऑर्डिनल तुलना करके खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID रिपोर्ट करता है। जब टेम्पलेट में अपेक्षित आकृति नहीं होती, तो कोड उस परिणाम को रिपोर्ट करता है न कि गलत ऑब्जेक्ट के साथ जारी रहता है।

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

जब कोई ऑपरेशन विशिष्ट आकृति प्रकार के लिए हो, तो टाइप‑स्पेसिफिक मेम्बर्स का उपयोग करने से पहले इंटरफ़ेस जांचें। यह उदाहरण केवल तभी टेक्स्ट और AlternativeText अपडेट करता है जब नामित ऑब्जेक्ट एक [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/) हो।

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

## **आकृति संग्रह को संशोधित करें**

ऐड, क्लोन, रिमूव और रीऑर्डर मेथड्स संग्रह पर तुरंत कार्य करते हैं। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले दर्ज किए गए इंडेक्स पर निर्भरता जारी न रखें।

### **आकृति को क्लोन करें**

[AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addclone/) एक स्वतंत्र कॉपी बनाता है और उसे लक्ष्य संग्रह में जोड़ता है। [InsertClone](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/insertclone/) भी कॉपी बनाता है लेकिन इसे निर्दिष्ट Z‑ऑर्डर इंडेक्स पर रखता है। वह ओवरलोड जो कोऑर्डिनेट्स स्वीकार करता है क्लोन को उसका आकार बदले बिना ले जाता है; चौड़ाई और ऊँचाई वाले ओवरलोड इसे रिसाइज़ भी कर सकते हैं।

निम्न उदाहरण एक गंतव्य स्लाइड बनाता है, लेबल वाले आयत को आगे क्लोन करता है, और एक दूसरा क्लोन पीछे डालता है। दोनों क्लोन में किए गए बदलाव स्रोत आकृति को नहीं बदलते।

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

क्लोनिंग आकृति की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका Name और AlternativeText भी शामिल है, को कॉपी करता है। जब इन मूल्यों को अद्वितीय होना आवश्यक हो तो क्लोन को नई तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन नए संग्रह आइटम के रूप में नई आकृति पहचान के साथ रहता है।

### **आकृतियों को हटाएँ**

[Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/remove/) किसी विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटाता है। इंडेक्स्ड इटरशन के दौरान कई मिलानों को हटाते समय अंत से शुरू करके ट्रैवर्स करें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण निर्धारित नाम वाली प्रत्येक आकृति को हटाता है। यह `slide.Shapes[i]` पढ़ता है, न कि किसी स्थायी संग्रह आइटम को, और यह आकृति को अनावश्यक रूप से कास्ट नहीं करता।

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

हटाने के बाद आकृति संख्या और बाद की आकृतियों के इंडेक्स बदल जाते हैं। अपरिवर्तित आकृतियों के रेफ़रेंस सहेजे गए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। साथ ही कनेक्टर्स, एनीमेशन्स और अन्य प्रस्तुति सुविधाओं को ध्यान में रखें जो हटाए गए ऑब्जेक्ट को संदर्भित कर सकते हैं; एक दृश्य आकृति को हटाने से स्लाइड की उपस्थिति से अधिक चीज़ें बदल सकती हैं।

### **आकृति को छुपाएँ**

[Hidden](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/hidden/) को `true` सेट करने से आकृति संग्रह में रहती है लेकिन सामान्य स्लाइड शो में दिखाई नहीं देती। इसका इंडेक्स, फ़ॉर्मेटिंग और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए वैकल्पिक तत्वों के लिए जो बाद में पुनः दिखाए जा सकते हैं, छुपाना उपयुक्त है।

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

छुपाना हटाना या सुरक्षा नहीं है। ऑब्जेक्ट को अभी भी खोजा जा सकता है और उपयोगकर्ता या कोड द्वारा अनहाइड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑ऑर्डर बदलें**

ओवरलैप करने वाली आकृतियाँ संग्रह क्रम में पेंट होती हैं। [Reorder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/reorder/) मौजूदा आकृति को लक्षित इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; `Count - 1` आगे है।

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

आयत सबसे पहले बनाई जाती है और शुरू में दीर्घवृत्त के पीछे रहती है। इसे अंतिम इंडेक्स पर ले जाने से वह सामने आ जाती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद Z‑ऑर्डर को फ़ाइनल करें, क्योंकि ये ऑपरेशन नई संग्रह आइटम जोड़ते या इनसर्ट करते हैं और वांछित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों का निरीक्षण करें**

नॉर्मल स्लाइड्स, लेआउट स्लाइड्स और मास्टर स्लाइड्स के अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति वही ऑब्जेक्ट नहीं होती जो सामान्य स्लाइड पर समान स्थिति में होती है। लेआउट द्वारा प्रदान किए गए फ़ॉर्मेटिंग को समझने या बदलने की आवश्यकता होने पर लेआउट आकृतियों का निरीक्षण करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/fillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/lineformat/) को पढ़ता है, यह मानते हुए कि हर आकृति `AutoShape` नहीं है।

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

लेआउट को संपादित करने से कई स्लाइड्स प्रभावित हो सकती हैं जो उसका उपयोग करती हैं। लेआउट आकृति को बदलने से पहले यह निर्धारित करें कि सामान्य स्लाइड ऑब्जेक्ट को इनहेरिट करती है या स्थानीय रूप से ओवरराइड करती है, और उस लेआउट का उपयोग करने वाली प्रत्येक स्लाइड का परीक्षण करें।

## **एक आकृति को SVG में निर्यात करें**

[WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/writeassvg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकृति होती है, न कि पूरे स्लाइड बैकग्राउंड या पड़ोसी आकृतियाँ।

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

रेंडरिंग के दौरान प्रस्तुति खुली रखें। आउटपुट आकृति के फ़ॉर्मेटिंग और फ़ॉन्ट व छवि जैसे संसाधनों पर निर्भर करता है। यदि पूरी रचना चाहिए तो स्लाइड को निर्यात करें, न कि व्यक्तिगत आकृति को। कॉलर को स्ट्रीम का मालिकाना अधिकार होता है और उसे डिस्पोज़ करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/alignshapes/) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेक्स को संरेखित करते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/net/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` सेट करने से स्लाइड किनारे उपयोग होते हैं; `false` सेट करने से चयनित आकृतियों को आपस में सापेक्ष रूप से संरेखित किया जाता है।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे पर संरेखित करता है। लौटाए गए आकृति रेफ़रेंसेज़ को तुरंत उनके वर्तमान इंडेक्स में बदल दिया जाता है, फिर संरेखण किया जाता है।

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

संरेखण स्थिति बदलता है, न कि Z‑ऑर्डर। सापेक्ष संरेखण सामान्यतः न्यूनतम दो आकृतियों की आवश्यकता रखता है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिये पर्याप्त आकृतियों की आवश्यकता होती है ताकि स्पेसिंग निर्धारित की जा सके। मेथड को कॉल करने से पहले संग्रह में परिवर्तन के कारण इंडेक्स पुनः‑गणना करें।

## **एक आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/shapeframe/) क्लास पोज़िशन, आकार, क्षैतिज और ऊर्ध्वाधर फ़्लिप सेटिंग्स, तथा रोटेशन को संग्रहीत करता है। इसके `FlipH` और `FlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` उसे अक्षम करता है, और `NotDefined` अननिर्धारित/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक नॉन‑फ़्लिप्ड आकृति शामिल करता है।

![फ़्लिप करने से पहले की आकृति](shape_to_be_flipped.png)

यह उदाहरण प्रत्येक अन्य फ्रेम मान को बरकरार रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/frame/) असाइन करने से पूरी फ्रेम बदल जाती है।

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

सहेजी गई आकृति क्षैतिज और ऊर्ध्विक रूप से प्रतिबिंबित होती है जबकि उसकी स्थिति, आकार और रोटेशन अपरिवर्तित रहता है।

![फ़्लिप करने के बाद की आकृति](flipped_shape.png)

## **FAQ**

**क्या मुझे आकृति पहचान के लिये कलेक्शन इंडेक्स का उपयोग करना चाहिए?**

केवल छोटे‑समय के प्रोसेसिंग के लिये जब संग्रह परिवर्तन नहीं करेगा, तब ही उपयोग करें। निर्मित टेम्पलेट्स के लिये मान्य `Name` या `AlternativeText` परम्परा को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिये `OfficeInteropShapeId` का उपयोग करें।

**क्या आकृति को छिपाने से वह Z‑ऑर्डर से हट जाती है?**

नहीं। छिपी हुई आकृति समान इंडेक्स पर संग्रह में बनी रहती है। इसे खोजा, पुनः‑क्रमित, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन की गई आकृति दूसरे आकृति के सामने क्यों दिखाई दे रही थी?**

`AddClone` क्लोन को संग्रह के अंत में जोड़ता है, जो Z‑ऑर्डर का सामने वाला भाग है। शुरुआती इंडेक्स चुनने के लिये `InsertClone` का प्रयोग करें या सभी आकृतियों को जोड़ने के बाद `Reorder` करें।