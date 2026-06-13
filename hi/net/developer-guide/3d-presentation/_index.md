---
title: ".NET का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं"
linktitle: "3D प्रस्तुति"
type: docs
weight: 232
url: /hi/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घुमाव
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ PowerPoint के आकार और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव और 3D पाठ को कॉन्फ़िगर करें।"
---
## **परिचय**

Aspose.Slides for .NET आकारों और पाठ के लिए PowerPoint-शैली 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख 3D प्रभावों जैसे घुमाव, एक्सट्रूज़न, बिवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भरण, और 3D पाठ को कवर करता है।

{{% alert color="primary" %}}
यह लेख PowerPoint आकारों और पाठ पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित करने या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

किसी आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) प्रॉपर्टी का उपयोग करें। यह प्रॉपर्टी [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat) को उजागर करती है, जो उस आकार के 3D दृश्य को नियंत्रित करती है।

पाठ के लिये, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) प्रॉपर्टी का उपयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण प्रॉपर्टी हैं:

| प्रॉपर्टी | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) | दृष्टिकोण, प्रीसेट कैमरा प्रकार, घुमाव, ज़ूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाएँ या PowerPoint 3D घुमाव प्रीसेट के साथ मेल करें। |
| [LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/lightrig) | लाइट प्रीसेट, दिशा, और लाइट घुमाव। | 3D सतह पर हाइलाइट और छाया कैसे दिखती हैं, इसे बदलें। |
| [Material](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/material) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | उसी ज्योमेट्री को अधिक सपाट, नरम, चमकीला या धातु जैसा दिखाएँ। |
| [ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) | आकार अपनी सामने की सतह से पीछे कितनी दूर तक विस्तारित होता है। | एक सपाट आकार को स्पष्ट रूप से मोटे 3D वस्तु में बदलें। |
| [ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) | एक्सट्रूड किए गए पक्षों का रंग। | गहराई को दृश्यमान बनाएं या साइड के रंग को सामने की भराव के साथ समन्वयित करें। |
| [Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या पाठ के लिए गहराई को सटीक रूप से समायोजित करें, विशेषकर बिवेल और सामग्री सेटिंग्स के साथ। |
| [BevelTop](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/beveltop) और [BevelBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/bevelbottom) | सामने और पीछे की सतहों पर उठे हुए या गोल किनारे। | तीखे सपाट सतह के बजाय एक नरम या ढाला हुआ किनारा जोड़ें। |
| [ContourColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourcolor) और [ContourWidth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करें। |

## **3D आकार बनाना**

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और पक्षों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि एक सपाट आकार को मोटाई चाहिए।

निम्नलिखित उदाहरण एक आयत बनाता है, उसके सामने की सतह पर पाठ जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

रेंडर किया गया स्लाइड छवि आयत को एक मोटा 3D ब्लॉक के रूप में दिखाता है:

![सामने की सतह पर सफेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घुमाव 3-D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घुमाव मान कैमरा API के माध्यम से सेट किए गए घुमाव से मिलते हैं।

![X, Y, और Z घुमाव मान हाइलाइट किए हुए PowerPoint 3-D Rotation पैन](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घुमाव को [IThreeDFormat.Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) के माध्यम से सेट करें:

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

व्यूअर द्वारा वस्तु को देखने के तरीके को बदलने के लिये कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकार को मोटा बनाता है क्योंकि यह सामने की सतह के पीछे विस्तारित होता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस का रंग सेट करता है।

![PowerPoint गहराई नियंत्रण जो एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई प्रॉपर्टी से मैप किए गए हैं](img_02_02.png)

मोटाई के लिये [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) सेट करें और साइड रंग के लिये [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) सेट करें:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

जब आपको सीधे PowerPoint की गहराई मान के साथ काम करना हो या गहराई को बिवेल, सामग्री, और टेक्स्ट प्रभावों के साथ मिलाना हो, तो [IThreeDFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) का उपयोग करें। कई आकार परिदृश्यों में, `ExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्यमान एक्सट्रूज़न को दर्शाता है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भरण का उपयोग करें**

3D फ़ॉर्मेटिंग आकार भराव से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी समान कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण आकार पर ग्रेडिएंट भराव लागू करता है और साइडों पर गहरा एक्सट्रूज़न रंग देता है:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

रेंडर किया गया आउटपुट सामने की सतह पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले-से-नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव का उपयोग करने के लिये, प्रस्तुति में चित्र जोड़ें और इसे आकार भराव में असाइन करें:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

![सामने की सतह पर फोटो भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **पाठ पर 3D फ़ॉर्मेटिंग लागू करें**

आकार 3D फ़ॉर्मेटिंग आकार के बॉडी को प्रभावित करता है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करता है। यह WordArt-सम समान प्रभावों के लिये उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, प्रकाश और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्नलिखित उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```csharp
const float imageScale = 2;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

टेक्स्ट को वक्र, एक्सट्रूज़न किए हुए 3D अक्षर रूप में रेंडर किया जाता है:

![वक्र WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरा एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। फ़िक्स्ड‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात करते समय, 3D दृश्य को रास्टर या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/net/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/net/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो रूपांतरण](/slides/hi/net/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यात की गई छवियां और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकते।
- अंतिम दिखावट कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों का निरीक्षण करना है, तो [आकार प्रभावी गुण](/slides/hi/net/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides आकारों और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई छवियों, PDFs, या HTML पृष्ठों को इंटरैक्टिव 3D दृश्यों में नहीं बदलता जिसे दर्शक घुमा सके। PPTX में, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है जहाँ फ़ॉर्मेट इसका समर्थन करता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जो प्रस्तुति में सम्मिलित की जाती है। 3D प्रभाव एक सामान्य PowerPoint आकार या पाठ पर लागू किया गया फ़ॉर्मेटिंग है, जैसे घुमाव, एक्सट्रूज़न, बिवेल, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**दृश्यमान 3D आकार के लिए कौन सी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घुमाव और एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाइलाइट और छाया हों।

**क्या मैं आकारों और पाठ दोनों पर 3D प्रभाव लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिये [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) का उपयोग करें और पाठ के लिये [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) का उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ्रेम्स में निर्यात करने पर दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए गए फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यात किया गया आउटपुट रेंडर किया गया दृश्य रखता है, न कि संपादन योग्य 3D वस्तु।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिये [Shape Effective Properties](/slides/hi/net/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।