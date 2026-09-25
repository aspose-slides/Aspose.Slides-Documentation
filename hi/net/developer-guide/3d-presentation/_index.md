---
title: .NET का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रुज़न
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ PowerPoint शैलियों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रुज़न, फ़िल्स और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for .NET shapes और text के लिए PowerPoint‑style 3D स्वरूपण को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रुज़न, बीवल, लाइटिंग, सामग्री, ग्रेडिएंट या पिक्चर फिल्स, और 3D टेक्स्ट जैसे 3D प्रभावों को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint shapes और टेक्स्ट पर 3D स्वरूपण प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D स्वरूपण अवधारणाएँ**

Shape पर 3D स्वरूपण लागू करने के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) गुण का उपयोग करें। यह गुण [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat) को उजागर करता है, जो उस shape के लिए 3D दृश्य को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) गुण का उपयोग करें। यह shape बॉडी के बजाय टेक्स्ट फ्रेम पर 3D स्वरूपण लागू करता है।

सबसे महत्वपूर्ण गुण हैं:

| गुण | यह क्या नियंत्रित करता है | इसे कब उपयोग करें |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) | दृश्य बिंदु, पूर्वनिर्धारित कैमरा प्रकार, घुमाव, ज़ूम और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाएँ या PowerPoint के 3D घुमाव प्रीसेट से मेल खाएं। |
| [LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/lightrig) | लाइट प्रीसेट, दिशा, और लाइट रोटेशन। | 3D सतह पर हाइलाइट्स और शैडोज़ कैसे दिखते हैं, इसे बदलें। |
| [Material](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/material) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | समान ज्यामिति को अधिक फ्लैट, सॉफ्ट, चमकदार, या धातु जैसा बनाएं। |
| [ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) | shape अपने सामने वाले फेस से कितनी दूरी तक पीछे की ओर विस्तारित होता है। | एक फ्लैट shape को स्पष्ट रूप से मोटा 3D वस्तु बनाएं। |
| [ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) | एक्सट्रूडेड किनारों का रंग। | गहराई को दर्शाएँ या किनारे के रंग को सामने के फ़िल के साथ समन्वयित करें। |
| [Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D स्वरूपण द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | shape या टेक्स्ट की गहराई को ठीक‑ठीक समायोजित करें, विशेषकर बीवेल और सामग्री सेटिंग्स के साथ। |
| [BevelTop](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/beveltop) और [BevelBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/bevelbottom) | सामने और पीछे के फ्लैट्स पर उठे या गोल किनारे। | तीखे फ्लैट चेहरे की बजाय नरम या ढाला हुआ किनारा जोड़ें। |
| [ContourColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourcolor) और [ContourWidth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D वस्तु की चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमाओं को उजागर करें। |

## **3D आकार बनाएं**

एक shape को विश्वसनीय रूप से 3D दिखाने के लिए सामान्यतः चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रुज़न को छिपा सकता है।  
- लाइट सेटिंग्स, क्योंकि लाइटिंग फेस और साइड्स को पठनीय बनाती है।  
- सामग्री सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।  
- एक्सट्रुज़न या डेप्थ सेटिंग्स, क्योंकि एक फ्लैट shape को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी फ्रंट फेस पर टेक्स्ट जोड़ता है, और 3D स्वरूपण लागू करता है। कैमरा घुमाव मान डिग्री में हैं, और एक्सट्रुज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को दो गुना डिफ़ॉल्ट आकार के PNG इमेज में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

रेंडर की गई स्लाइड इमेज दिखाती है कि आयत एक मोटी 3D ब्लॉक है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ Shape को घुमाएँ**

PowerPoint में 3D घुमाव 3‑D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y, और Z घुमाव मान उस घुमाव के अनुरूप हैं जिसे आप कैमरा API के माध्यम से सेट करते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में कैमरा तक पहुंचने के लिए [IThreeDFormat.Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) का उपयोग करें। यह उदाहरण एक आयत बनाता है, ऑर्थोग्राफ़िक फ्रंट व्यू चुनता है, और उसके X, Y, और Z घुमाव को क्रमशः 20, 30, और 40 डिग्री पर सेट करता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

जब आपको दर्शक के वस्तु को देखने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D shape ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडर करते समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रुज़न और डेप्थ जोड़ें**

एक्सट्रुज़न shape को पीछे की ओर विस्तारित करके उसे मोटा बनाता है। PowerPoint में डेप्थ नियंत्रण इस दिखने वाली मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस का रंग तय करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

थिकनेस के लिए [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) और साइड रंग के लिए [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) सेट करें। यह उदाहरण आयत को 100‑पॉइंट एक्सट्रुज़न के साथ बैंगनी साइड्स देता है और मोटाई दिखाने के लिए कैमरा घुमाता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) गुण 3D shape की गहराई सेट करता है। [ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) गुण एक्सट्रुज़न प्रभाव की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या पिक्चर फ़िल लागू करें**

3D स्वरूपण shape फ़िल से स्वतंत्र है। आप सामने के फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फ़िल लागू कर सकते हैं और अभी भी वही कैमरा, लाइट, सामग्री, और एक्सट्रुज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण फ्रंट फेस पर नीले‑से‑ऑरेंज ग्रेडिएंट लागू करता है और 150‑पॉइंट एक्सट्रुज़न पर डार्क ऑरेंज रंग देता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः शुरू और समाप्त होते हैं। कैमरा घुमाव मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आकार के PNG इमेज में रेंडर किया गया है:

```csharp
using System.Drawing;
using Aspose.Slides;

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

रेंडर आउटपुट फ्रंट फेस पर ग्रेडिएंट रखता है और एक्सट्रुज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

पिक्चर फ़िल उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे shape फ़िल में असाइन करें। यह उदाहरण कार्यशील निर्देशिका में "image.jpg" नामक फ़ाइल की मौजूदगी मानता है। यह पिक्चर को आयत भरने के लिए स्ट्रेच करता है, 150‑पॉइंट एक्सट्रुज़न लागू करता है, और कैमरा घुमाव को डिग्री में सेट करता है। यह shape को मेमोरी में कॉन्फ़िगर करता है बिना सहेजे या रेंडर किए:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

पिक्चर फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रुज़न 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **टेक्स्ट पर 3D स्वरूपण लागू करें**

Shape 3D स्वरूपण shape बॉडी को प्रभावित करता है। टेक्स्ट 3D स्वरूपण टेक्स्ट फ्रेम को प्रभावित करता है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रुज़न, सामग्री, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक टेक्स्ट बनाता है जिसमें ऑरेंज‑और‑व्हाइट ग्रिड पैटर्न है, एक अपवर्ड आर्च लागू करता है, और [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रुज़न ऊँचाई और डेप्थ पॉइंट में हैं, और लाइट घुमाव डिग्री में है। shape फ़िल और आउटलाइन छिपे हुए हैं ताकि केवल टेक्स्ट दिखाई दे। उदाहरण PNG इमेज को दो गुना डिफ़ॉल्ट स्लाइड आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

टेक्स्ट को वक्र, एक्सट्रुज़न 3D लेटरिंग के रूप में रेंडर किया गया है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **3D Shape पर टेक्स्ट को फ्लैट रखें**

टेक्स्ट को पढ़ने योग्य रखने और shape की 3D उपस्थिति को बनाए रखने के लिए [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/keeptextflat/) को [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/textframeformat/) के माध्यम से सेट करें। जब मान `true` हो, तो टेक्स्ट 3D सीन से बाहर रहता है। जब `false` हो, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग shape की 3D स्वरूपण को नहीं हटाती: उसका कैमरा, लाइटिंग, सामग्री, और एक्सट्रुज़न [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/threedformat/) के माध्यम से कॉन्फ़िगर रहता है। यह सामान्य घुमाव से भी अलग है। [IShape.Rotation](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/rotation/) स्लाइड प्लेन में shape को घुमाता है, जबकि [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/rotationangle/) टेक्स्ट के अनुकूल घुमाव को उसके बाउंडिंग बॉक्स के भीतर नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखना इन कोणों में से किसी को भी रीसेट नहीं करता।

निम्न स्व-समाहित उदाहरण एक नीला आयत टेक्स्ट के साथ बनाता है और मूल के बगल में उसे क्लोन करता है। दोनों shapes के पास समान 3D स्वरूपण है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रुज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को दो गुना डिफ़ॉल्ट आकार के PNG में रेंडर करता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

बाएँ पर टेक्स्ट 3D अभिविन्यास का अनुसरण करता है। दाएँ पर वह फ्लैट रहता है और पढ़ना आसान होता है। दोनों आयतें समान दृश्यमान एक्सट्रुज़न और 3D अभिविन्यास बनाए रखती हैं।

![Side-by-side 3D rectangles: KeepTextFlat is false on the left and true on the right](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मैट में 3D स्वरूपण को संरक्षित रखता है। जब आप स्थिर‑लेआउट फ़ॉर्मैट में रेंडर या निर्यात करते हैं, तो 3D सीन को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/net/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/net/convert-powerpoint-to-html/) में निर्यात करते हैं, या [वीडियो रूपांतरण](/slides/hi/net/convert-powerpoint-to-video/) के लिए फ्रेम बनाते हैं।

इन बातों को ध्यान में रखें:

- निर्यातित इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।  
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रुज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।  
- यदि आपको विरासत या थीम‑आधारित स्वरूपण मानों का निरीक्षण करना है, तो [effective shape properties](/slides/hi/net/shape-effective-properties/) पढ़ें।  
- कुछ आउटपुट फ़ॉर्मैट संपादन योग्य PowerPoint 3D स्वरूपण को संग्रहीत नहीं कर सकते। ऐसे फ़ॉर्मैट में दृश्य परिणाम रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियां बना सकता है?**

Aspose.Slides shapes और टेक्स्ट के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यातित इमेज, PDF, या HTML पृष्ठों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मैट समर्थन करता है, 3D स्वरूपण PowerPoint में संपादन योग्य रहता है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुतिकरण में डाला जाता है। 3D प्रभाव आम PowerPoint shape या टेक्स्ट पर लागू स्वरूपण है, जैसे घूर्णन, एक्सट्रुज़न, बीवेल, लाइटिंग, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दृश्यमान 3D shape के लिए कौन सी सेटिंग्स आवश्यक हैं?**

कम से कम एक कैमरा घुमाव और या तो एक्सट्रुज़न या डेप्थ सेट करें। व्यवहार में, स्पष्ट हाइलाइट्स और शैडोज़ के लिए लाइट रिग और सामग्री भी सेट करना उपयोगी होता है।

**क्या मैं दोनों shapes और टेक्स्ट पर 3D प्रभाव लागू कर सकता हूँ?**

हां। shape बॉडी के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) और टेक्स्ट के लिए [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) उपयोग करें।

**क्या 3D प्रभाव इमेज, PDF, HTML, या वीडियो फ़्रेम में निर्यात करते समय दिखाई देंगे?**

हां। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया गया रूप दिखाई देगा, लेकिन संपादन योग्य 3D ऑब्जेक्ट नहीं।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकते हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बीवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/net/shape-effective-properties/) में वर्णित प्रभावी स्वरूपण API का उपयोग करें।