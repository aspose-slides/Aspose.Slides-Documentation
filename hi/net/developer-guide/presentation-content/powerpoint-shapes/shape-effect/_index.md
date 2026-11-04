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
- चमक प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को उभारने के लिए किया जा सकता है, वे [भरण](/slides/hi/net/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर प्रभावी परावर्तन बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जो आकारों पर लागू किए जा सकते हैं। आप किसी आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण, PowerPoint में **Preset** के तहत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक इफ़ेक्ट्स के एक ज्ञात आकर्षक संयोजन होते हैं। इस प्रकार, एक Preset चुनने से आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा ताकि आप एक अच्छा संयोजन पा सकें।

Aspose.Slides provides properties and methods under the [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) class that allow you to apply the same effects to shapes in PowerPoint presentations.

## **एक छाया प्रभाव लागू करें**

Aspose.Slides for .NET आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और धुंध की त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के खिलाफ कार्ड या पैनल को उभारने के लिए एक बाहरी छाया का उपयोग करें। छाया आकार की किनारों से परे विस्तार करती है, जिससे यह प्रतीत होता है कि आकार स्लाइड से उठाया गया है। अपने टेम्पलेट की प्रकाश और शैली से मिलाने के लिए इसके रंग, दिशा, दूरी और धुंध की त्रिज्या को समायोजित करें।

यह C# कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) को एक आयत पर लागू किया जाए:

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

![छाया प्रभाव](shadow_effect.png)

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को पुनः उत्पन्न किया जाता है, तो कार्ड या पैनल को एक गहराई वाला रूप देने के लिए आंतरिक छाया का उपयोग करें। एक बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उठे हुए जैसा दिखाती है, जबकि आंतरिक छाया इसके किनारों के भीतर छाया डालती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) को कॉन्फ़िगर करें। बड़ी मान अधिक मुलायम किनारे बनाते हैं।

यह C# उदाहरण हल्के नीले रंग का एक कार्ड बनाता है जिसमें गहरा धूसर आंतरिक छाया होती है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

![हल्का नीला आयत आंतरिक छाया के साथ](inner_shadow_effect.png)

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

## **परावर्तन प्रभाव लागू करें**

परावर्तन प्रभाव प्रस्तुतियों के सौंदर्य को बढ़ाता है, जिससे आकारों को अधिक परिष्कृत और प्रोफेशनल लुक मिलता है। आप दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित करके दर्पण जैसी परावर्तन जोड़ सकते हैं। यह कोड सरल है और कई तत्वों पर समान रूप से लागू किया जा सकता है।

यह C# कोड दिखाता है कि कैसे [परावर्तन प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) को एक आकार पर लागू किया जाए:

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

![परावर्तन प्रभाव](reflection_effect.png)

## **चमक प्रभाव लागू करें**

आप अपनी प्रस्तुति में आकारों को उज्ज्वल, चमकीला आवरण जोड़कर उन्हें अधिक आकर्षक बना सकते हैं। रंग और आकार जैसी विशेषताओं को समायोजित करके चमक प्रभाव को आसानी से लागू किया जा सकता है।

यह C# कोड दिखाता है कि कैसे [चमक प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) को एक आकार पर लागू किया जाए:

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

![चमक प्रभाव](glow_effect.png)

## **नरम किनारे प्रभाव लागू करें**

नरम किनारे प्रभाव आकार की किनारों के आसपास एक स्मूद, ब्लर संक्रमण बनाता है, जिससे डिज़ाइन अधिक सूक्ष्म और परिष्कृत दिखता है। आप विभिन्न आकारों में एकसमान लुक पाने के लिए त्रिज्या जैसे पैरामीटर समायोजित कर सकते हैं।

यह C# कोड दिखाता है कि कैसे [नरम किनारे](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) को एक आकार पर लागू किया जाए:

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

![नरम किनारे प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आकार की भराई और रूपरेखा को नरम किया जा सकता है, जबकि आकार संपादन योग्य रहता है। आकार के इफ़ेक्ट फ़ॉर्मेट पर [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। त्रिज्या पॉइंट्स (1/72 इंच) में मापी जाती है: गैर‑नकारात्मक मान उपयोग करें, बड़ी मान अधिक तेज़ ब्लर बनाते हैं। शून्य त्रिज्या प्रभाव को अपरिवर्तित रखती है।

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) सेटिंग प्रभाव के दृश्यमान सीमाओं को नियंत्रित करती है। `false` होने पर ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर ब्लर इन सीमाओं से बाहर तक विस्तारित हो सकता है। दोनों सेटिंग्स आकार की स्थिति या आयामों को नहीं बदलतीं।

नीचे दिया गया तुलना समान भराई, रूपरेखा और आकार आयामों के साथ किया गया है। शीर्ष पंक्ति `grow = false` का उपयोग करती है; निचली पंक्ति `grow = true` का उपयोग करती है।

![मूल आयत की तुलना 5 और 15 पॉइंट ब्लर त्रिज्या के साथ, जिसमें grow निष्क्रिय और सक्रिय है](shape_blur_comparison.png)

यह C# उदाहरण एक नारंग आयत बनाता है जिसमें गहरा नीला रूपरेखा है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करके 15‑पॉइंट ब्लर पर अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) को कॉल करके बिना ब्लर के आकार को सहेजता है।

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

आकार ब्लर भराई और रूपरेखा दोनों को प्रभावित करता है। नरम किनारे प्रभाव आकार के किनारों को फीका करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन इफ़ेक्ट्स इमेज सामग्री पर कार्य करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **FAQ**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न इफ़ेक्ट्स, जैसे छाया, परावर्तन और चमक, को मिला कर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरी समूह पर लागू होगा।