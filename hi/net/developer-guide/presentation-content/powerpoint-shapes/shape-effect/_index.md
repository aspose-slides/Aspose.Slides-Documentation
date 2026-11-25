---
title: .NET में प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/net/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारा प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन ये [भरण](/slides/hi/net/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फ़ैल सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint आकृतियों पर लागू किए जा सकने वाले छह इफ़ेक्ट्स प्रदान करता है। आप किसी आकार पर एक या एक से अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint में **Preset** के तहत विकल्प होते हैं। प्रीसेट विकल्प मूलतः एक ज्ञात सुंदर संयोजन होते हैं। इस तरह, एक प्रीसेट चुनने पर आपको उपयुक्त संयोजन खोजने के लिए विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides वर्ग [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) के तहत प्रॉपर्टीज़ और मेथड्स प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया इफ़ेक्ट लागू करें**

Aspose.Slides for .NET आकारों के लिए बाहरी और आंतरिक छायाएँ समर्थित करता है। आप उनकी रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुरूप अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक बाहरी छाया का प्रयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि से अलग उजागर किया जा सकता है। छाया आकार की किनारों से बाहर तक फैलती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठा हुआ है। रंग, दिशा, दूरी और ब्लर त्रिज्या को टेम्पलेट की प्रकाश व्यवस्था और शैली के अनुरूप समायोजित करें।

यह C# कोड दिखाता है कि कैसे [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) को आयत पर लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![छाया इफ़ेक्ट](shadow_effect.png)

### **आंतरिक छाया लागू करें**

एक टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को गहराई देने के लिये आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तार करती है और उसे उठे हुए दिखाती है, जबकि आंतरिक छाया किनारे के अंदर की ओर छाया देती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) को कॉन्फ़िगर करें। बड़ी मानों से किनारे मुलायम होते हैं।

यह C# उदाहरण हल्के नीले रंग का कार्ड बनाता है जिसमें गहरा ग्रे आंतरिक छाया है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिये, आकार की इफ़ेक्ट फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) को कॉल करें और [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) को किसी नामित [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) पर सेट करें। शैली बदलने के लिये, समान आकार पर प्रीसेट को बदलें। छाया को हटाने के लिये, [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) को कॉल करें जबकि भरण और रूपरेखा बरकरार रहती है।

यह उदाहरण प्रत्येक चरण पर आयत की एक प्रतिलिपि रखता है। दोनों छायाएँ 10 पॉइंट द्वारा ऑफ़सेट की गई हैं। 225° की दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° की दिशा दूसरी को नीचे और दाएँ।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में परावर्तन इफ़ेक्ट लागू करने के लिये, आप आकारों पर दर्पण जैसा प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह इफ़ेक्ट आपकी प्रस्तुतियों को अधिक परिष्कृत और आकर्षक दिखाता है। सरल कोड के साथ इसे लागू करना आसान है, जिससे कई तत्वों पर सुसंगत डिज़ाइन तेज़ी से लागू किया जा सकता है।

यह C# कोड दिखाता है कि कैसे [परावर्तन इफ़ेक्ट](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) को आकार पर लागू किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![परावर्तन इफ़ेक्ट](reflection_effect.png)

## **ग्लो इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में आकार पर ग्लो इफ़ेक्ट लागू करने के लिये, आप आकार के आसपास एक मुलायम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टीज़ को समायोजित कर सकते हैं। यह इफ़ेक्ट आकार को प्रमुख बनाता है और आपके प्रस्तुतीकरण में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड्स का समग्र लुक सुधरता है।

यह C# कोड दिखाता है कि कैसे [ग्लो इफ़ेक्ट](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) को आकार पर लागू किया जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![ग्लो इफ़ेक्ट](glow_effect.png)

## **सॉफ़्ट एजेज़ इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में सॉफ़्ट एजेज़ इफ़ेक्ट लागू करने के लिये, आप आकार के किनारों के चारों तरफ एक सहज, धुंधला संक्रमण बना सकते हैं। यह इफ़ेक्ट अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो कोमल और हल्के लुक की आवश्यकता वाले डिज़ाइनों के लिये उपयुक्त है। आप विभिन्न आकारों में वांछित प्रभाव पाने के लिये त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह C# कोड दिखाता है कि कैसे [सॉफ़्ट एजेज़](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) को आकार पर लागू किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![सॉफ्ट एजेज़ इफ़ेक्ट](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

आकार ब्लर का उपयोग करके आप आकार की फाइल और रूपरेखा को नरम बना सकते हैं जबकि आकार को संशोधित योग्य रख सकते हैं। आकार की इफ़ेक्ट फ़ॉर्मेट पर [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। त्रिज्या पॉइंट (1/72 इंच) में मापी जाती है: गैर‑ऋणात्मक मान उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करते हैं। शून्य त्रिज्या से उपस्थिति अपरिवर्तित रहती है।

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) सेटिंग प्रभाव की दृश्य सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंटेड सीमाओं तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर, ब्लर इन सीमाओं से परे विस्तार कर सकता है। इनमें से कोई भी सेटिंग आकार की स्थिति या आयामों को नहीं बदलती।

नीचे की तुलना में पूरे समय समान फाइल, रूपरेखा और आकार उपयोग किए गए हैं। ऊपर की पंक्ति में `grow = false` है; नीचे की पंक्ति में `grow = true` है।

![ब्लर त्रिज्या 5 और 15 पॉइंट के साथ मूल आयत, ग्रो अक्षम और सक्षम](shape_blur_comparison.png)

यह C# उदाहरण नारंगी आयत बनाता है जिसमें गहरा नीला रूपरेखा है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करके 15‑पॉइंट ब्लर लागू करता है। यह दोनों ब्लर अवस्थाओं को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) को कॉल करके बिना ब्लर के आकार को सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

आकार ब्लर फाइल और रूपरेखा दोनों को साथ‑साथ प्रभावित करता है। सॉफ़्ट एजेज़ इफ़ेक्ट आकार के किनारों को धुंधला करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण इफ़ेक्ट्स छवि सामग्री पर लागू होते हैं; यह उदाहरण सीधे आकार की इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है बिना आकार को छवि में परिवर्तित किए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर छाया, परावर्तन, ग्लो आदि विभिन्न इफ़ेक्ट्स को संयोजित करके अधिक गतिकीपूर्ण रूप दिखा सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न प्रकार के आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिनमें ऑटोशेप, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरी समूह पर लागू होगा।