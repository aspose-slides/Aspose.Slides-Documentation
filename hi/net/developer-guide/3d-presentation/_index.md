---
title: .NET का उपयोग करके प्रस्तुतियों में 3D इफ़ेक्ट बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/net/3d-presentation/
keywords:
- 3D पॉवरपॉइंट
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- पावरपॉइंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides के साथ PowerPoint आकृतियों और पाठ के लिए 3D इफ़ेक्ट लागू करें और रेंडर करें। कैमरा, लाइटिंग, मैटेरियल, एक्सट्रूज़न, फ़िल और 3D पाठ को कॉन्फ़िगर करें।"
---
## **परिचय**

Aspose.Slides for .NET आकृतियों और पाठ के लिए PowerPoint‑शैली 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बीवल, लाइटिंग, मैटेरियल, ग्रेडिएंट या पिक्चर फ़िल, तथा 3D पाठ जैसे 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" %}}
यह लेख PowerPoint आकृति और पाठ पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

आकृति पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) प्रॉपर्टी का उपयोग करें। यह प्रॉपर्टी [IThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat) को उजागर करती है, जो उस आकृति के लिए 3D सीन को नियंत्रित करती है।

पाठ के लिए, [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) प्रॉपर्टी का उपयोग करें। यह आकार के शरीर के बजाय टेक्स्ट फ़्रेम पर 3D फ़ॉर्मेटिंग लागू करती है।

सबसे महत्वपूर्ण प्रॉपर्टी हैं:

| प्रॉपर्टी | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) | दृश्य बिंदु, प्रीसैट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाने या PowerPoint 3D घूर्णन प्रीसैट से मेल करने के लिए। |
| [LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/lightrig) | लाइट प्रीसैट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाईलाइट और शेडो के स्वरूप को बदलने के लिए। |
| [Material](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/material) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या धातु। | समान ज्यामिति को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा दिखाने के लिए। |
| [ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) | आकृति अपने अग्रमुख से कितनी दूर पीछे तक फैली है। | एक सपाट आकृति को दृश्यमान मोटी 3D वस्तु में बदलने के लिए। |
| [ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्यमान बनाने या साइड रंग को अग्र भाग की फ़िल के साथ समन्वयित करने के लिए। |
| [Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग की जाने वाली अतिरिक्त 3D गहराई। | आकृतियों या पाठ के लिए गहराई को सूक्ष्म रूप से समायोजित करने के लिए, विशेषकर बीवल और मैटेरियल सेटिंग्स के साथ। |
| [BevelTop](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/beveltop) और [BevelBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/bevelbottom) | अग्र और पृष्ठ भागों पर उठे या गोल किनारे। | तीखा सपाट किनारा होने के बजाय नरम या ढला हुआ किनारा जोड़ने के लिए। |
| [ContourColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourcolor) और [ContourWidth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D वस्तु के चारों ओर का रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को उजागर करने के लिए। |

## **3D आकृति बनाएँ**

एक आकृति को विश्वसनीय 3D दिखाने के लिए आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और पक्षों को पढ़ने योग्य बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह प्रकाश के रेंडरिंग को प्रभावित करती है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकृति को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसकी अग्र सतह पर पाठ जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

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

रेंडर की गई स्लाइड छवि आयत को एक मोटी 3D ब्लॉक के रूप में दिखाती है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ आकृति को घुमाएँ**

PowerPoint में, 3‑D घूर्णन को 3‑D Rotation पैन से सेट किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में कैमरा प्रकार और घूर्णन को [IThreeDFormat.Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/camera) के माध्यम से सेट करें:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

वह कैमरा उपयोग करें जब आपको दर्शक द्वारा वस्तु को देखने के तरीके को बदलना हो। यह स्लाइड पर 2D आकृति ज्यामिति को नहीं बदलता, बल्कि PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकृति को पीछे की ओर बढ़ाकर उसे मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण साइड फेस के रंग को निर्धारित करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

मोटाई के लिए [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusionheight) और साइड के रंग के लिए [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/extrusioncolor) सेट करें:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

जब आपको सीधे PowerPoint की गहराई मान के साथ काम करना हो या गहराई को बीवल, मैटेरियल और टेक्स्ट इफ़ेक्ट्स के साथ संयोजित करना हो, तो [IThreeDFormat.Depth](https://reference.aspose.com/slides/hi/net/aspose.slides/ithreedformat/properties/depth) का प्रयोग करें। कई आकृति परिदृश्यों में, `ExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह दृश्यमान एक्सट्रूज़न को सीधे व्यक्त करता है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फ़िल लागू करें**

3D फ़ॉर्मेटिंग आकृति फ़िल से स्वतंत्र है। आप अग्र भाग पर ठोस रंग, ग्रेडिएंट, पैटर्न, या पिक्चर फ़िल लागू कर सकते हैं और उसी कैमरा, लाइट, मैटेरियल, और एक्सट्रूज़न सेटिंग्स को बरकरार रख सकते हैं।

यह उदाहरण आकृति पर ग्रेडिएंट फ़िल और साइड पर गहरा एक्सट्रूज़न रंग लागू करता है:

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

रेंडर किया गया आउटपुट अग्र भाग पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

पिक्चर फ़िल का उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे आकृति फ़िल में असाइन करें:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **पाठ पर 3D फ़ॉर्मेटिंग लागू करें**

आकृति की 3D फ़ॉर्मेटिंग आकृति के शरीर को प्रभावित करती है। पाठ की 3D फ़ॉर्मेटिंग टेक्स्ट फ़्रेम को प्रभावित करती है। यह WordArt‑समान इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न फ़िल के साथ पाठ बनाता है, WordArt रूपांतरण लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

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

पाठ को वक्र, एक्सट्रूज़न 3D लेटरिंग के रूप में रेंडर किया जाता है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या 2D परिणाम के रूप में आउटपुट में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/net/convert-powerpoint-to-png/), [PDF](/slides/hi/net/convert-powerpoint-to-pdf/), [HTML](/slides/hi/net/convert-powerpoint-to-html/), या [video conversion](/slides/hi/net/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को याद रखें:

- निर्यातित छवियों और PDFs इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम उपस्थिति कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत में मिले या थीम‑आधारित फ़ॉर्मेटिंग मानों की जांच करनी है, तो [effective shape properties](/slides/hi/net/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट में, दृश्य परिणाम को रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में संचित किया जाता है।

## **FAQ**

### क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतिकरण बना सकता है?

Aspose.Slides आकृतियों और पाठ के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs, या HTML पेजों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है जहाँ फ़ॉर्मेट इसका समर्थन करता है।

### 3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?

3D मॉडल वह अलग‑थलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट वह फ़ॉर्मेटिंग है जो सामान्य PowerPoint आकृति या पाठ पर लागू की जाती है, जैसे घूर्णन, एक्सट्रूज़न, बीवल, लाइटिंग, और मैटेरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

### दृश्य 3D आकृति के लिए कौन‑से सेटिंग्स आवश्यक हैं?

कम से कम कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और मैटेरियल भी सेट करें ताकि रेंडर किए गए फेस में स्पष्ट हाइलाइट और शेडो हों।

### क्या मैं दोनों आकृति और पाठ पर 3D इफ़ेक्ट लागू कर सकता हूँ?

हाँ। आकृति शरीर के लिए [IShape.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/properties/threedformat) और पाठ के लिए [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframeformat/properties/threedformat) उपयोग करें।

### क्या 3D इफ़ेक्ट्स छवियों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखेंगे?

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए प्रयुक्त फ्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ स्वरूप होता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

### क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?

हाँ। अंतिम कैमरा, लाइट रिग, बीवल, और संबंधित 3D मानों को पढ़ने के लिए [Shape Effective Properties](/slides/hi/net/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।