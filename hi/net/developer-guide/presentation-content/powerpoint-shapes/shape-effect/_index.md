---
title: .NET में प्रस्तुतियों में आकार इफ़ेक्ट्स लागू करें
linktitle: आकार इफ़ेक्ट
type: docs
weight: 30
url: /hi/net/shape-effect
keywords:
- आकार इफ़ेक्ट
- छाया इफ़ेक्ट
- प्रतिबिंब इफ़ेक्ट
- चमक इफ़ेक्ट
- नरम किनारे इफ़ेक्ट
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके उन्नत आकार इफ़ेक्ट्स के साथ अपनी PPT और PPTX फाइलों को बदलें-सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग करके आप किसी आकार को प्रमुख बना सकते हैं, लेकिन ये [भरण](/slides/hi/net/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके आप किसी आकार पर वास्तविक प्रतिबिंब बना सकते हैं, आकार की चमक (glow) को फैला सकते हैं, आदि।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

PowerPoint छह इफ़ेक्ट्स प्रदान करता है जिन्हें आकार पर लागू किया जा सकता है। आप एक या अधिक इफ़ेक्ट्स को किसी आकार पर लागू कर सकते हैं।

कुछ इफ़ेक्ट्स के संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण PowerPoint **Preset** के तहत विकल्प प्रदान करता है। Preset विकल्प मूल रूप से दो या अधिक इफ़ेक्ट्स के एक ज्ञात सुन्दर संयोजन होते हैं। इस प्रकार, प्रीसेट चुनने से आपको अलग-अलग इफ़ेक्ट्स को आज़माने या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/) क्लास के तहत गुण और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर वही इफ़ेक्ट्स लागू करने की अनुमति देता है।

## **छाया (Shadow) इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में किसी आकार पर छाया इफ़ेक्ट लागू करने के लिए आप रंग, ब्लर त्रिज्या, और दिशा जैसी पैरामीटर आसानी से समायोजित कर सकते हैं। इससे आपके आकार अधिक गतिशील और पेशेवर दिखते हैं, गहराई और फोकस जोड़ते हैं। सरल कोड स्निपेट्स का उपयोग करके आप इन इफ़ेक्ट्स को कई आकारों पर लागू कर सकते हैं, जिससे आपकी प्रस्तुतियों की समग्र दृश्य अपील बढ़ती है।

यह C# कोड दिखाता है कि कैसे [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/outershadoweffect/) को एक आयत पर लागू किया जाए:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![Shadow effect](shadow_effect.png)

## **प्रतिबिंब (Reflection) इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में प्रतिबिंब इफ़ेक्ट लागू करने के लिए आप आकारों पर दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता, और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह इफ़ेक्ट आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक परिष्कृत और आकर्षक बनाता है। सरल कोड के साथ इसे लागू करना आसान है, जिससे आप कई तत्वों पर तेज़ी से समान डिज़ाइन लागू कर सकते हैं।

यह C# कोड दिखाता है कि कैसे [प्रतिबिंब इफ़ेक्ट](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/reflectioneffect/) को एक आकार पर लागू किया जाए:

```c#
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

![Reflection effect](reflection_effect.png)

## **चमक (Glow) इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में किसी आकार पर चमक इफ़ेक्ट लागू करने के लिए आप आकार के आसपास एक नरम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित कर सकते हैं। यह इफ़ेक्ट आकारों को प्रमुख बनाता है और आपके प्रस्तुतियों में आकर्षक दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपकी स्लाइड्स की कुल मिलाकर उपस्थिति बेहतर होती है।

यह C# कोड दिखाता है कि कैसे [चमक इफ़ेक्ट](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/gloweffect/) को एक आकार पर लागू किया जाए:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);

shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![Glow effect](glow_effect.png)

## **नरम किनारे (Soft Edges) इफ़ेक्ट लागू करें**

Aspose.Slides for .NET में नरम किनारे इफ़ेक्ट लागू करने के लिए आप आकार के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह इफ़ेक्ट अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें कोमल, नरम उपस्थिति चाहिए। आप त्रिज्या जैसी पैरामीटर को आसानी से समायोजित करके विभिन्न आकारों पर वांछित प्रभाव प्राप्त कर सकते हैं।

यह C# कोड दिखाता है कि कैसे [नरम किनारे](https://reference.aspose.com/slides/hi/net/aspose.slides/effectformat/softedgeeffect/) को एक आकार पर लागू किया जाए:

```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![Soft edges effect](soft_edges_effect.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप विभिन्न इफ़ेक्ट्स जैसे छाया, प्रतिबिंब और चमक को एक ही आकार पर संयोजित करके अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरी समूह पर लागू होगा।