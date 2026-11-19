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
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के साथ Aspose.Slides का उपयोग करके PowerPoint आकृतियों और पाठ में 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव और 3D पाठ को कॉन्फ़िगर करें।"
---
## **अवलोकन**

Aspose.Slides for .NET आकृतियों और पाठ के लिए PowerPoint-श शैली की 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख 3D प्रभावों जैसे घूर्णन, एक्सट्रूजन, बिवेल्स, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकृतियों और पाठ पर 3D फॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides इन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकृति पर 3D फॉर्मेटिंग लागू करने के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) गुण का उपयोग करें। यह गुण [IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat) को उजागर करता है, जो उस आकृति के लिए 3D दृश्‍य को नियंत्रित करता है।

पाठ के लिए, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) गुण का उपयोग करें। यह आकृति बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण गुण हैं:

| Property | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | दृष्टिकोण, पूर्वनिर्धारित कैमरा प्रकार, घूर्णन, जूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मेल करें। |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और छाया की उपस्थिति बदलें। |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | समान ज्यामिति को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा बनाएं। |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | आकार अपनी सामने की सतह से पीछे कितनी दूरी तक विस्तारित होता है। | एक सपाट आकार को दृश्यमान मोटी 3D वस्तु में बदलें। |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्यमान बनाएं या साइड रंग को सामने के भराव के साथ समन्वयित करें। |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D फॉर्मेटिंग द्वारा उपयोग की जाने अतिरिक्त 3D गहराई। | आकृतियों या पाठ के लिए गहराई को फाइन-ट्यून करें, विशेषकर बिवेल और सामग्री सेटिंग्स के साथ। |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) और [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | सामने और पीछे की सतहों पर उठे हुए या गोल किनारे। | तीक्ष्ण सपाट सतह के बजाय सौम्य या मोले हुए किनारे जोड़ें। |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) और [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा पर ज़ोर दें। |

## **3D आकृति बनाएं**

एक आकृति आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता रखती है ताकि वह विश्वसनीय रूप से 3D दिखे:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूजन को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों को पठनीय बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूजन या गहराई सेटिंग्स, क्योंकि एक सपाट आकृति को मोटाई की जरूरत होती है।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने की सतह पर पाठ जोड़ता है, और 3D फॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूजन ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को PNG छवि में दो गुना डिफ़ॉल्ट आकार में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

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

रेंडर की गई स्लाइड छवि आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![सामने के चेहरे पर सफेद 3D पाठ के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकृति को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API द्वारा सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D घूर्णन पैन जिसमें X, Y, और Z घूर्णन मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा को [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) के माध्यम से एक्सेस करें। यह उदाहरण एक आयत बनाता है, एक ऑर्थोग्राफ़िक फ्रंट व्यू चुनता है, और उसके X, Y, Z घूर्णन को क्रमशः 20, 30, और 40 डिग्री पर सेट करता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

जब आपको दर्शक द्वारा वस्तु को देखने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D आकृति ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

### **टेम्पलेट आकृति से कैमरा अभिविन्यास कॉपी करें**

एक टेम्पलेट में आकृति से मेल खाने के लिए, उसके [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) प्रीसेट को कॉपी करें और उसके कोणों को [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) से पढ़ें। यह उदाहरण `template.pptx` को खोलता है, पहले स्लाइड पर पहली आकृति से कैमरा पढ़ता है, और इसे दूसरी आकृति पर लागू करता है। दोनों आकृतियों में पहले से 3D लाइटिंग है, और दूसरी आकृति में स्पष्ट कैमरा घूर्णन निर्दिष्ट नहीं है।

कोण डिग्री में होते हैं। इंडेक्स `0` अक्षांश, इंडेक्स `1` देशांतर, और इंडेक्स `2` परिक्रमा दर्शाता है। इन्हें इस क्रम में [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) को दें। यदि स्रोत `null` लौटाता है, तो इसका अर्थ है कोई स्पष्ट घूर्णन नहीं, इसलिए दूसरी आकृति के कोण अनसेट रहें। `(0, 0, 0)` का स्पष्ट घूर्णन तीन शून्य लौटाता है और इसे कॉपी किया जाना चाहिए।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

जब आप `camera-copy.pptx` को पुनः खोलते हैं, तो दोनों आकृतियों का कैमरा प्रीसेट और घूर्णन समान रहता है। PowerPoint में, दाएँ तीर का कैमरा अभिविन्यास बाएँ आयत से कॉपी किए गए कैमरा अभिविन्यास से मेल खाता है। दोनों आकृतियों में समान लाइटिंग और एक्सट्रूजन गहराई है।

![बाएँ से आयत और दाएँ तीर में मिलते‑जुलते कैमरा अभिविन्यास के साथ 3D आयत और तीर, ऊपर और दाएँ से दिखाया गया](camera-orientation.png)

## **एक्सट्रूजन और गहराई जोड़ें**

एक्सट्रूजन एक आकृति को सामने की सतह के पीछे विस्तारित करके मोटा दिखाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड फ़ेसेज़ के रंग को निर्धारित करता है।

![PowerPoint गहराई नियंत्रण को एक्सट्रूजन रंग और एक्सट्रूजन ऊँचाई गुणों से मैप किया गया](img_02_02.png)

थिकनेस के लिए [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) और साइड रंग के लिए [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) सेट करें। यह उदाहरण आयत को 100‑पॉइंट एक्सट्रूजन के साथ बैंगनी साइड्स देता है और कैमरा को घुमाकर उसकी मोटाई दिखाता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) गुण 3D आकृति की गहराई निर्धारित करता है। [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) गुण एक्सट्रूजन प्रभाव की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फॉर्मेटिंग आकृति भराव से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और साथ ही समान कैमरा, लाइट, सामग्री, और एक्सट्रूजन सेटिंग्स रख सकते हैं।

यह उदाहरण सामने की सतह पर नीले‑से‑ऑरेंज ग्रेडिएंट और 150‑पॉइंट एक्सट्रूजन पर गहरा ऑरेंज रंग लागू करता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः शुरू और समाप्त होते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को PNG छवि में दो गुना डिफ़ॉल्ट आकार में रेंडर किया जाता है:

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

रेंडर किया गया आउटपुट सामने की सतह पर ग्रेडिएंट रखता है और एक्सट्रूजन को अलग से रेंडर करता है:

![नीले‑से‑संतरी ग्रेडिएंट भराव और संतरी एक्सट्रूजन के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकृति भराव को सौंपें। यह उदाहरण कार्यशील निर्देशिका में "image.jpg" नामक मौजूदा फ़ाइल की आवश्यकता रखता है। यह चित्र को आयत में भरने के लिए स्ट्रेच करता है, 150‑पॉइंट एक्सट्रूजन लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

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

चित्र सामने की सतह पर रेंडर होता है, जबकि एक्सट्रूजन 3D साइड सतह के रूप में रेंडर होता है:

![सामने की सतह पर फोटो भराव और संतरी एक्सट्रूजन के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **पाठ पर 3D फॉर्मेटिंग लागू करें**

आकृति 3D फॉर्मेटिंग आकृति बॉडी को प्रभावित करती है। पाठ 3D फॉर्मेटिंग पाठ फ़्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूजन, सामग्री, प्रकाश और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण एक पाठ बनाता है जिसमें संतरी‑और‑सफेद ग्रिड पैटर्न है, एक ऊपर की ओर चाप लागू करता है, और [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूजन ऊँचाई और गहराई पॉइंट में हैं, और लाइट घूर्णन डिग्री में है। आकृति भराव और रूपरेखा छिपी हुई है ताकि केवल पाठ दिखे। उदाहरण PNG छवि को डिफ़ॉल्ट स्लाइड आकार से दो गुना में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

पाठ को वक्र, एक्सट्रूडेड 3D लेटरिंग के रूप में रेंडर किया गया है:

![वक्र WordArt ट्रांसफ़ॉर्म, संतरी पैटर्न भराव, और गहरा एक्सट्रूजन के साथ रेंडर किया गया 3D पाठ](img_02_05.png)

## **3D आकृति पर पाठ को सपाट रखें**

पाठ को पढ़ने योग्य रखने के लिए जबकि आकृति की 3D उपस्थिति बनी रहे, [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) को [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) के माध्यम से सेट करें। जब मान `true` होता है, तो पाठ 3D दृश्‍य से बाहर रहता है। जब `false` होता है, तो पाठ दृश्‍य में भाग लेता है और उसकी 3D अभिविन्यास का पालन करता है।

यह सेटिंग आकृति की 3D फॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, सामग्री, और एक्सट्रूजन अभी भी [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) के माध्यम से कॉन्फ़िगर है। यह सामान्य घूर्णन से भी अलग है। [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) स्लाइड प्लेन में आकृति को घुमाता है, जबकि [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) बाउंडिंग बॉक्स के भीतर पाठ के कस्टम घूर्णन को नियंत्रित करता है। पाठ को 3D दृश्‍य से बाहर रखने से इन कोणों में से कोई भी रीसेट नहीं होता।

निम्न स्व-निहित उदाहरण एक नीला आयत पाठ के साथ बनाता है और उसे मूल आकृति के बगल में क्लोन करता है। दोनों आकृतियों में समान 3D फॉर्मेटिंग है; केवल पाठ सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूजन ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को PNG में दो गुना डिफ़ॉल्ट आकार में रेंडर करता है:

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

बाएँ में, पाठ 3D अभिविन्यास का पालन करता है। दाएँ में, वह सपाट रहता है और पढ़ने में आसान होता है। दोनों आयतें समान दृश्य एक्सट्रूजन और 3D अभिविन्यास बनाए रखती हैं।

![साइड‑बाय‑साइड 3D आयतें: बाएँ KeepTextFlat `false` है और दाएँ `true`](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फॉर्मेटिंग को बनाए रखता है। जब स्थायी‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D दृश्‍य को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/net/convert-powerpoint-to-png/), [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [HTML](/slides/hi/net/convert-powerpoint-to-html/), या [video conversion](/slides/hi/net/convert-powerpoint-to-video/) के लिए फ़्रेम उत्पन्न करते हैं।

ध्यान रखें:

- निर्यात की गई छवियां और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक द्वारा वस्तु को घुमाया नहीं जा सकता।
- अंतिम रूप ने कैमरा, लाइट रिग, सामग्री, एक्सट्रूजन, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित फॉर्मेटिंग मानों को जांचना है, तो [effective shape properties](/slides/hi/net/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फॉर्मेटिंग संग्रहीत नहीं कर सकते। इन फ़ॉर्मेट में दृश्य परिणाम रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides आकृतियों और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई छवियों, PDF या HTML पृष्ठों को इंटरैक्टिव 3D दृश्‍य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फॉर्मेटिंग PowerPoint में संपादन योग्य बनी रहती है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव एक सामान्य PowerPoint आकृति या पाठ पर लागू फॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूजन, बिवेल, प्रकाश, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**एक दृश्य 3D आकृति के लिए किन सेटिंग्स की आवश्यकता है?**

न्यूनतम, एक कैमरा घूर्णन और या तो एक्सट्रूजन या गहराई सेट करें। व्यवहार में, एक लाइट रिग और सामग्री भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं 3D प्रभाव दोनों आकृतियों और पाठ पर लागू कर सकता हूँ?**

हां। आकृति बॉडी के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) और पाठ के लिए [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) का उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखाई देंगे?**

हां। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ़्रेम उत्पन्न करते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ दृश्य होता है, संपादन योग्य 3D वस्तु नहीं।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हां। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/net/shape-effective-properties/) में वर्णित प्रभावी फॉर्मेटिंग API का उपयोग करें।