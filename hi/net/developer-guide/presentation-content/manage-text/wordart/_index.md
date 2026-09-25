---
title: .NET में WordArt प्रभाव बनाएं और लागू करें
linktitle: WordArt
type: docs
weight: 110
url: /hi/net/wordart/
keywords:
- WordArt
- WordArt बनाएं
- WordArt टेम्पलेट
- WordArt प्रभाव
- शैडो प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- WordArt ट्रांसफ़ॉर्मेशन
- 3D प्रभाव
- बाहरी शैडो प्रभाव
- आंतरिक शैडो प्रभाव
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण गाइड डेवलपर्स को C# में पेशेवर टेक्स्ट के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **समीक्षा**

WordArt प्रभाव आपको टेक्स्ट को फ़िल, आउटलाइन, शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D फ़ॉर्मैटिंग के साथ स्टाइल करने देते हैं। यह लेख PowerPoint प्रस्तुतियों में Aspose.Slides for .NET का उपयोग करके, बिना Microsoft Office स्थापित किए, इन प्रभावों को बनाने और अनुकूलित करने के तरीके को समझाता है।

## **एक सरल WordArt टेम्पलेट बनाएं और इसे टेक्स्ट पर लागू करें**

निम्नलिखित उदाहरण टेक्स्ट, फ़ॉन्ट, पैटर्न फ़िल और आउटलाइन सेट करके एक सरल WordArt शैली बनाते हैं।

प्रत्येक उदाहरण एक नई प्रस्तुति बनाता है और उसकी पहली स्लाइड में एक आयत जोड़ता है; कोई इनपुट फ़ाइल आवश्यक नहीं है। पहला उदाहरण टेक्स्ट को "Aspose.Slides" पर सेट करता है। आकार की स्थिति और आयाम पॉइंट में मापे जाते हैं:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

फ़ॉर्मैटिंग को अधिक स्पष्ट करने के लिए फ़ॉन्ट को Arial Black, 36 पॉइंट पर सेट करें:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

एक [SmallGrid](https://reference.aspose.com/slides/hi/net/aspose.slides/patternstyle/) पैटर्न को गहरे नारंगी अग्रभूमि और सफेद पृष्ठभूमि के साथ लागू करें, फिर 1 पॉइंट चौड़ाई के साथ काले टेक्स्ट की आउटलाइन जोड़ें:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

परिणामी टेक्स्ट:

![सरल WordArt टेम्पलेट](WordArt_template.png)

## **अन्य WordArt प्रभाव लागू करें**

निम्नलिखित उदाहरण दिखाते हैं कि टेक्स्ट पर शैडो, रिफ्लेक्शन, ग्लो, ट्रांसफ़ॉर्मेशन और 3D प्रभाव कैसे लागू किए जाएँ।

### **बाहरी शैडो प्रभाव लागू करें**

एक बाहरी शैडो टेक्स्ट के पीछे शैडो रखकर गहराई जोड़ता है। आप इसका रंग, दिशा, दूरी, ब्लर त्रिज्या, स्केल और स्क्यू को कस्टमाइज़ कर सकते हैं।

यह उदाहरण [EnableOuterShadowEffect](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/enableoutershadoweffect/) को कॉल करता है और 4 पॉइंट ब्लर त्रिज्या, 230-डिग्री दिशा और 30 पॉइंट दूरी वाले काले शैडो को सेट करता है। स्केल मान 100 शैडो का आकार बनाए रखता है, जबकि हॉरिज़ॉन्टल स्क्यू इसे 20 डिग्री झुकाता है। अल्फा ट्रांसफ़ॉर्म इसकी अपारदर्शिता को 32% पर सेट करता है:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

परिणामी टेक्स्ट:

![बाहरी शैडो प्रभाव](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- जब बाहरी और प्रीसेट शैडो एक साथ उपयोग किए जाते हैं, तो केवल बाहरी शैडो लागू होता है।
- यदि बाहरी और आंतरिक शैडो एक साथ उपयोग किए जाएँ, तो परिणामस्वरूप प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दो गुना हो जाता है, जबकि PowerPoint 2007 में केवल बाहरी शैडो लागू होता है।
{{% /alert %}}

### **रिफ्लेक्शन प्रभाव लागू करें**

एक रिफ्लेक्शन टेक्स्ट की प्रतिबिंबित प्रति बनाता है। इसकी स्थिति, स्केल, ब्लर और अपारदर्शिता को समायोजित करके आप इसकी उपस्थिति नियंत्रित कर सकते हैं।

यह उदाहरण [EnableReflectionEffect](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/enablereflectioneffect/) को कॉल करता है और रिफ्लेक्शन को ऊर्ध्वाधर रूप से -100% स्केल के साथ उलटता है। यह 0.5 पॉइंट ब्लर त्रिज्या और 4.72 पॉइंट दूरी का उपयोग करता है। रिफ्लेक्शन के साथ 0% से 60% स्थितियों के बीच अपारदर्शिता 60% से 0.9% तक घटती है:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5;
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;
```

परिणामी टेक्स्ट:

![रिफ्लेक्शन प्रभाव](reflection_effect.png)

### **ग्लो प्रभाव लागू करें**

एक ग्लो टेक्स्ट के चारों ओर एक नरम रंगीन आउटलाइन जोड़ता है। प्रभाव को नियंत्रित करने के लिए इसका रंग, अपारदर्शिता और त्रिज्या को समायोजित करें।

यह उदाहरण [EnableGlowEffect](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/enablegloweffect/) को कॉल करता है और 54% अपारदर्शिता तथा 7 पॉइंट त्रिज्या वाले लाल ग्लो को लागू करता है:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

परिणामी टेक्स्ट:

![ग्लो प्रभाव](glow_effect.png)

### **WordArt ट्रांसफ़ॉर्मेशन लागू करें**

WordArt ट्रांसफ़ॉर्मेशन टेक्स्ट के ब्लॉक को मोड़ते, खींचते या विकृत करते हैं।

संपूर्ण टेक्स्ट फ्रेम को ऊपर की ओर घुमाने के लिए [Transform](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/transform/) को [ArchUpPour](https://reference.aspose.com/slides/hi/net/aspose.slides/textshapetype/) पर सेट करें:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

परिणामी टेक्स्ट:

![WordArt ट्रांसफ़ॉर्मेशन](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET पूर्वनिर्धारित [ट्रांसफ़ॉर्मेशन प्रकारों](https://reference.aspose.com/slides/hi/net/aspose.slides/textshapetype/) का एक सेट प्रदान करता है।
{{% /alert %}}

### **आकार और टेक्स्ट पर 3D प्रभाव लागू करें**

आप एक आकार या उसके टेक्स्ट पर 3D प्रभाव लागू कर सकते हैं। बिवेल, एक्सट्रूज़न, लाइटिंग और कैमरा सेटिंग्स परिणाम स्वरूप उपस्थिति को नियंत्रित करती हैं।

निम्नलिखित उदाहरण [ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/) का उपयोग करके आयत में गोलाकार बिवेल, नारंगी एक्सट्रूज़न और गहरे लाल कंटूर को जोड़ता है। बिवेल आयाम, एक्सट्रूज़न ऊँचाई, कंटूर चौड़ाई और गहराई पॉइंट में मापी जाती हैं। एक प्लास्टिक सामग्री, Z अक्ष के चारों ओर 40 डिग्री घुमाई गई संतुलित लाइटिंग, और एक पर्स्पेक्टिव कैमरा इसकी उपस्थिति को परिभाषित करते हैं:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
autoShape.TextFrame.Text = "Aspose.Slides";

autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

परिणामी आकार:

![आकार 3D प्रभाव](shape_3D_effect.png)

यह उदाहरण [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/textframeformat/threedformat/) के माध्यम से टेक्स्ट पर समान 3D फ़ॉर्मैटिंग लागू करता है। छोटे बिवेल अक्षर किनारों को आकार देते हैं, जबकि एक्सट्रूज़न और लाइटिंग टेक्स्ट को गहराई प्रदान करती है:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";

textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

परिणामी टेक्स्ट:

![टेक्स्ट 3D प्रभाव](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
टेक्स्ट या उनके आकार पर 3D प्रभावों का उपयोग — और इन प्रभावों के बीच की अंतःक्रिया — विशिष्ट नियमों द्वारा नियंत्रित होती है। एक दृश्य पर विचार करें जिसमें टेक्स्ट और उसे समाहित करने वाला आकार दोनों शामिल हों। एक 3D प्रभाव वस्तु के 3D प्रतिनिधित्व और उस दृश्य को शामिल करता है जिसमें वह रखा गया है।

- यदि आकार और टेक्स्ट दोनों के लिए एक दृश्य सेट किया गया है, तो आकार का दृश्य प्राथमिकता लेता है और टेक्स्ट का दृश्य अनदेखा हो जाता है।
- यदि आकार के पास अपना स्वयं का दृश्य नहीं है लेकिन उसका 3D प्रतिनिधित्व है, तो टेक्स्ट का दृश्य उपयोग किया जाता है।
- यदि आकार के पास बिल्कुल भी 3D प्रभाव नहीं है, तो उसे सपाट माना जाता है, और 3D प्रभाव केवल टेक्स्ट पर लागू होता है।

इन व्यवहारों का संबंध [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/lightrig/) और [ThreeDFormat.Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/camera/) गुणों से है।
{{% /alert %}}

टेक्स्ट को सपाट और पठनीय रखने के साथ-साथ उसके आकार की 3D फ़ॉर्मैटिंग को बनाए रखने के लिए, दोनों सेटिंग्स की तुलना और एक पूर्ण C# उदाहरण के लिए देखें: [Keep Text Flat on a 3D Shape](/slides/hi/net/3d-presentation/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं विभिन्न फ़ॉन्ट या स्क्रिप्ट (जैसे अरबी, चीनी) के साथ WordArt प्रभाव उपयोग कर सकता हूँ?**

हाँ, Aspose.Slides for .NET यूनिकोड का समर्थन करता है और सभी प्रमुख फ़ॉन्ट और स्क्रिप्ट के साथ काम करता है। WordArt प्रभाव जैसे शैडो, फ़िल और आउटलाइन भाषा की परवाह किए बिना लागू किए जा सकते हैं, हालांकि फ़ॉन्ट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकती है।

**क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?**

हाँ, आप मास्टर स्लाइड पर मौजूद आकारों पर WordArt प्रभाव लागू कर सकते हैं, जिसमें शीर्षक प्लेसहोल्डर, फुटर या पृष्ठभूमि टेक्स्ट शामिल हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबंधित स्लाइडों में प्रतिबिंबित होंगे।

**क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?**

थोड़ा। शैडो, ग्लो और ग्रेडिएंट फ़िल जैसे WordArt प्रभाव अतिरिक्त फ़ॉर्मैटिंग मेटाडेटा के कारण फ़ाइल आकार को थोड़ा बढ़ा सकते हैं, लेकिन अंतर आमतौर पर नगण्य होता है।

**क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभावों के परिणाम का पूर्वावलोकन कर सकता हूँ?**

हाँ, आप [ISlide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) का उपयोग करके WordArt वाले स्लाइड को छवियों (जैसे PNG, JPEG) में रेंडर कर सकते हैं, या [IShape.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getimage/) के द्वारा व्यक्तिगत आकारों को रेंडर कर सकते हैं। इससे आप सहेजने या पूरी प्रस्तुति को एक्सपोर्ट करने से पहले मेमोरी या स्क्रीन पर परिणाम का पूर्वावलोकन कर सकते हैं।