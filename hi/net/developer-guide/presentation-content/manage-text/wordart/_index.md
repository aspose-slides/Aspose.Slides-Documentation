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
- प्रदर्शन प्रभाव
- ग्लो प्रभाव
- WordArt रूपांतरण
- 3D प्रभाव
- बाहरी शैडो प्रभाव
- आंतरिक शैडो प्रभाव
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में WordArt प्रभाव बनाएं और अनुकूलित करें। यह चरण-दर-चरण गाइड डेवलपर्स को C# में पेशेवर पाठ के साथ प्रस्तुतियों को बेहतर बनाने में मदद करता है।"
---
## **अवलोकन**

WordArt प्रभाव आपको अपने PowerPoint प्रस्तुतियों में दृश्यात्मक रूप से आकर्षक, शैलीबद्ध पाठ जोड़ने की अनुमति देते हैं। Aspose.Slides for .NET के साथ, डेवलपर्स प्रोग्रामेटिक रूप से WordArt बना, अनुकूलित और प्रबंधित कर सकते हैं, बिल्कुल Microsoft PowerPoint की तरह—बिना Office स्थापित किए। यह लेख .NET में WordArt के साथ काम करने का एक अवलोकन प्रदान करता है, जिसमें पाठ परिवर्तन, भराव शैलियों, रूपरेखाओं, छायाओं और अन्य स्वरूपण विकल्पों को लागू करने की विधियाँ शामिल हैं, जिससे आपके प्रस्तुति सामग्री अधिक अभिव्यक्तिपूर्ण और आकर्षक बनती है। WordArt आपको पाठ को एक ग्राफ़िकल वस्तु के रूप में व्यवहार करने की अनुमति देता है। यह प्रभाव या विशेष संशोधन का समूह है जो पाठ को अधिक आकर्षक या उल्लेखनीय बनाता है।

## **एक सरल WordArt टेम्पलेट बनाएं और इसे पाठ पर लागू करें**

इस अनुभाग में, हम Aspose.Slides for .NET का उपयोग करके एक सरल WordArt टेम्पलेट बनाने और इसे पाठ पर लागू करने के तरीके का पता लगाएंगे। WordArt पाठ की उपस्थिति को आकर्षक दृश्य प्रभावों और शैलियों के साथ बढ़ाने का आसान तरीका प्रदान करता है। WordArt बनाने और उपयोग करने के बुनियादी चरण सीखकर, आप इन तकनीकों को किसी भी प्रोजेक्ट में आसानी से अनुकूलित कर सकते हैं, जिससे आपकी प्रस्तुतियां अधिक जीवंत और यादगार बनेंगी।

पहले, हम निम्नलिखित C# कोड का उपयोग करके सरल पाठ बनाते हैं:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```

अब, हम प्रभाव को अधिक स्पष्ट बनाने के लिए पाठ के फ़ॉन्ट की ऊँचाई को बड़े मान पर सेट करते हैं, निम्नलिखित कोड का उपयोग करके:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

यहाँ, हम SmallGrid पैटर्न भराव को पाठ पर लागू करते हैं और नीचे दिया गया कोड उपयोग करके चौड़ाई 1 के साथ काली पाठ सीमा जोड़ते हैं:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

परिणामी पाठ:

![सरल WordArt टेम्पलेट](WordArt_template.png)

## **अन्य WordArt प्रभाव लागू करें**

बुनियादी रूपांतरणों के अतिरिक्त, Aspose.Slides for .NET आपको अपने पाठ की उपस्थिति को बेहतर बनाने के लिए विभिन्न उन्नत WordArt प्रभाव लागू करने की अनुमति देता है। इनमें रूपरेखा, भराव, छायाएँ, प्रतिबिंब और चमक प्रभाव शामिल हैं। इन सुविधाओं को मिलाकर, आप आकर्षक पाठ शैलियाँ बना सकते हैं जो आपकी प्रस्तुतियों में उल्लेखनीय दिखें। यह अनुभाग सरल, साफ़ कोड उदाहरणों का उपयोग करके प्रोग्रामेटिक रूप से इन प्रभावों को लागू करने का प्रदर्शन करता है।

### **बाहरी शैडो प्रभाव लागू करें**

बाहरी शैडो प्रभाव पाठ को उसकी रूपरेखा के पीछे एक छाया जोड़कर अलग दिखने में मदद करता है, जिससे गहराई और पृष्ठभूमि से अलगाव की भावना उत्पन्न होती है। Aspose.Slides for .NET आपको WordArt पाठ पर बाहरी शैडो को आसानी से लागू और अनुकूलित करने की सुविधा देता है। इस अनुभाग में, आप शैडो का रंग, दिशा, दूरी, ब्लर त्रिज्या आदि सेट करना सीखेंगे ताकि वांछित दृश्य प्रभाव प्राप्त हो सके।

निम्नलिखित C# कोड स्निपेट ऊपर बनाई गई पाठ पर शैडो प्रभाव लागू करता है।

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

परिणामी पाठ:

![बाहरी शैडो प्रभाव](outer_shadow_effect.png)

{{% alert color="info" %}} 
- जब OuterShadow और PresetShadow को साथ में उपयोग किया जाता है, तो केवल OuterShadow प्रभाव लागू होता है।
- यदि OuterShadow और InnerShadow को एक साथ उपयोग किया जाता है, तो परिणामस्वरूप प्रभाव PowerPoint संस्करण पर निर्भर करता है। उदाहरण के लिए, PowerPoint 2013 में प्रभाव दोगुना हो जाता है, जबकि PowerPoint 2007 में केवल OuterShadow प्रभाव लागू होता है।
{{% /alert %}}

### **प्रतिबिंब प्रभाव लागू करें**

इस अनुभाग में, हम Aspose.Slides for .NET का उपयोग करके अपनी स्लाइड्स में प्रतिबिंब प्रभाव लागू करने का पता लगाएंगे। प्रतिबिंब प्रभाव आपके पाठ या आकृतियों को स्टाइलिश और आधुनिक लुक दे सकते हैं, जिससे मुख्य तत्व उभरे और आपकी प्रस्तुति में गहराई जुड़ती है। इन प्रभावों को लागू करने और अनुकूलित करने की प्रक्रिया को समझकर, आप उन्हें अपनी डिज़ाइन आवश्यकताओं और ब्रांडिंग अनुरूप आसानी से अनुकूलित कर सकते हैं।

इस C# कोड उदाहरण का उपयोग करके पाठ में प्रतिबिंब प्रभाव जोड़ें:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
}
```

परिणामी पाठ:

![प्रतिबिंब प्रभाव](reflection_effect.png)

### **ग्लो प्रभाव लागू करें**

इस अनुभाग में, हम Aspose.Slides for .NET का उपयोग करके पाठ पर चमक (ग्लो) प्रभाव लागू करने का पता लगाएंगे। ग्लो प्रभाव आपके पाठ को एक चमकदार रूपरेखा के साथ उभार सकता है, जिससे आपकी स्लाइड्स की दृश्य आकर्षण बढ़ती है। रंग और तीव्रता जैसी सेटिंग्स को समायोजित करके, आप ग्लो को अपने डिज़ाइन और ब्रांडिंग आवश्यकताओं के अनुसार आसानी से अनुकूलित कर सकते हैं, जिससे प्रस्तुति में प्रमुख बिंदु दर्शकों का ध्यान आकर्षित करें।

निम्नलिखित कोड का उपयोग करके पाठ पर ग्लो प्रभाव लागू करें:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

परिणामी पाठ:

![ग्लो प्रभाव](glow_effect.png)

### **WordArt परिवर्तन लागू करें**

इस अनुभाग में, हम Aspose.Slides for .NET के साथ WordArt में रूपांतरणों (transformations) का उपयोग कैसे करें, यह पता लगाएंगे। रूपांतरण आपको पाठ को मोड़ने, खींचने या विकृत करने की अनुमति देते हैं, जिससे अनोखे और दृश्यात्मक रूप से प्रभावशाली परिणाम मिलते हैं। इन तकनीकों में निपुण होकर, आप पाठ के आकार और शैलियों को अपने ब्रांड या रचनात्मक दृष्टि के अनुसार आसानी से अनुकूलित कर सकते हैं, जिससे एक शानदार और परिष्कृत प्रस्तुति बनती है।

निम्नलिखित कोड का उपयोग करके `Transform` प्रॉपर्टी (जो पूरे टेक्स्ट ब्लॉक पर लागू होती है) सेट करें:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

परिणामी पाठ:

![WordArt परिवर्तन](transform_effect.png)

{{% alert color="info" %}} 
Aspose.Slides for .NET पूर्वनिर्धारित [transformation types](https://reference.aspose.com/slides/hi/net/aspose.slides/textshapetype/) का एक सेट प्रदान करता है।
{{% /alert %}} 

### **Shapes और Text पर 3D प्रभाव लागू करें**

वास्तविक, आंख पकड़ने वाले दृश्य बनाना आपकी प्रस्तुतियों के प्रभाव को काफी बढ़ा सकता है। इस अनुभाग में, हम Aspose.Slides for .NET का उपयोग करके आकृतियों पर त्रि-आयामी (3D) प्रभाव कैसे लागू करें, यह देखेंगे। गहराई, कोण और प्रकाश जैसे पैरामीटर को समायोजित करके, आप प्रभावशाली 3D रूपांतरण बना सकते हैं जो दर्शकों का तुरंत ध्यान आकर्षित करता है। चाहे आप सूक्ष्म हाइलाइट्स चाहते हों या नाटकीय भ्रम, ये सुविधाएँ आपके डिज़ाइन को उन्नत करने और विचारों को अधिक आकर्षक तरीके से प्रसारित करने के लचीले तरीके प्रदान करती हैं।

निम्नलिखित नमूना कोड का उपयोग करके आकृति पर 3D प्रभाव सेट करें:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
}
```

परिणामी आकृति:

![आकार 3D प्रभाव](shape_3D_effect.png)

निम्नलिखित नमूना कोड का उपयोग करके पाठ पर 3D प्रभाव सेट करें:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
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
}
```

परिणामी पाठ:

![टेक्स्ट 3D प्रभाव](text_3D_effect.png)

{{% alert color="info" %}} 
पाठ या उसकी आकृतियों पर 3D प्रभावों का अनुप्रयोग—और इन प्रभावों के बीच परस्पर क्रिया—विशिष्ट नियमों द्वारा नियंत्रित होती है। एक ऐसी स्थिति पर विचार करें जिसमें दोनों, टेक्स्ट और उसे सम्मिलित करने वाली आकृति, शामिल हों। एक 3D प्रभाव वस्तु के 3D प्रतिनिधित्व और उस दृश्य को शामिल करता है जिस पर वह रखा गया है।

- यदि दोनों shape और text के लिए scene सेट किया गया है, तो shape का scene प्राथमिकता लेता है और text का scene अनदेखा किया जाता है।
- यदि shape का अपना scene नहीं है लेकिन उसका 3D representation है, तो text का scene उपयोग किया जाता है।
- यदि shape में कोई 3D प्रभाव नहीं है, तो उसे फ्लैट माना जाता है, और 3D प्रभाव केवल text पर लागू किया जाता है।

इन व्यवहारों का संबंध [ThreeDFormat.LightRig](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/lightrig/) और [ThreeDFormat.Camera](https://reference.aspose.com/slides/hi/net/aspose.slides/threedformat/camera/) गुणों से है।
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं WordArt प्रभाव विभिन्न फ़ॉन्ट या लिपियों (जैसे अरबी, चीनी) के साथ उपयोग कर सकता हूँ?

हाँ, Aspose.Slides for .NET यूनिकोड का समर्थन करता है और सभी प्रमुख फ़ॉन्ट और लिपियों के साथ काम करता है। WordArt प्रभाव जैसे शैडो, भराव और रूपरेखा भाषा की परवाह किए बिना लागू की जा सकती हैं, हालांकि फ़ॉन्ट की उपलब्धता और रेंडरिंग सिस्टम फ़ॉन्ट पर निर्भर हो सकती है।

### क्या मैं स्लाइड मास्टर तत्वों पर WordArt प्रभाव लागू कर सकता हूँ?

हाँ, आप मास्टर स्लाइड पर स्थित आकृतियों, जिसमें शीर्षक प्लेसहोल्डर, फुटर या पृष्ठभूमि पाठ शामिल हैं, पर WordArt प्रभाव लागू कर सकते हैं। मास्टर लेआउट में किए गए परिवर्तन सभी संबद्ध स्लाइडों में परिलक्षित होते हैं।

### क्या WordArt प्रभाव प्रस्तुति फ़ाइल के आकार को प्रभावित करते हैं?

थोड़ा। शैडो, ग्लो और ग्रेडिएंट भराव जैसे WordArt प्रभाव फ़ॉर्मेटिंग मेटाडेटा जोड़ते हैं, जिससे फ़ाइल आकार में हल्की वृद्धि हो सकती है, लेकिन अंतर आमतौर पर नगण्य रहता है।

### क्या मैं प्रस्तुति को सहेजे बिना WordArt प्रभावों का परिणाम पूर्वावलोकन कर सकता हूँ?

हाँ, आप [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) या [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) इंटरफ़ेस की `GetImage` विधि का उपयोग करके WordArt वाले स्लाइड को PNG, JPEG आदि छवियों के रूप में रेंडर कर सकते हैं। इससे आप पूरी प्रस्तुति को सहेजे या निर्यात किए बिना इमेज या स्क्रीन पर परिणाम का पूर्वावलोकन कर सकते हैं।