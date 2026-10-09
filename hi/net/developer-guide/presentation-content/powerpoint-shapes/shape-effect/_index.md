---
title: ".NET में प्रस्तुतियों में आकार प्रभाव लागू करें"
linktitle: "आकार प्रभाव"
type: docs
weight: 30
url: /hi/net/shape-effect/
keywords:
- "आकार प्रभाव"
- "छाया प्रभाव"
- "परावर्तन प्रभाव"
- "ग्लो प्रभाव"
- "नरम किनारे प्रभाव"
- "इफ़ेक्ट फ़ॉर्मेट"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [भराव](/slides/hi/net/shape-formatting/#gradient-fill) या रूपरेखा से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय परावर्तन बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकृति प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकार पर लगा सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण PowerPoint में **Preset** के तहत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों के ज्ञात सुंदर संयोजन होते हैं। इस तरह, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों का परीक्षण या संयोजन करते हुए समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में समान प्रभावों को आकारों पर लागू करने की अनुमति देता है।

## **छाया प्रभाव लागू करें**

Aspose.Slides for .NET आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और धुंध के त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड बैकग्राउंड के खिलाफ कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकार के किनारों से बाहर तक विस्तारित होती है, जिससे यह प्रतीत होता है कि आकार स्लाइड से उठाया गया है। इसके रंग, दिशा, दूरी और धुंध के त्रिज्या को अपने टेम्प्लेट की लाइटिंग और शैली के अनुसार समायोजित करें।

यह C# कोड दिखाता है कि कैसे [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) को एक आयत पर लागू किया जाता है:

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

जब किसी टेम्प्लेट के दृश्य शैली को पुन: बनाते हैं, तो कार्ड या पैनल को एक धँसा हुआ रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उठाया हुआ दिखाती है, जबकि आंतरिक छाया उसके किनारों के अंदर हिस्से को शेड करती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) को कॉन्फ़िगर करें। बड़े मान नरम किनारे उत्पन्न करते हैं।

यह C# उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for .NET में परावर्तन प्रभाव लागू करने के लिए आप आकारों में दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक पॉलिश्ड और परिष्कृत रूप देता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर निरंतर डिज़ाइन के लिए तेज़ी से लागू किया जा सकता है।

यह C# कोड दिखाता है कि कैसे [परावर्तन प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) को किसी आकार पर लागू किया जाता है:

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

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for .NET में किसी आकार पर ग्लो प्रभाव लागू करने के लिए आप आकारों के चारों ओर नरम, चमकदार आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टी को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाने में मदद करता है और आपकी प्रस्तुति में आकर्षक, ध्यान खींचने वाला दृश्य तत्व जोड़ता है। यह न्यूनतम कोड के साथ आसानी से लागू किया जा सकता है, जिससे आपकी स्लाइडों की समग्र रूपरचना सुधरती है।

यह C# कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) को किसी आकार पर लागू किया जाता है:

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

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ्ट एज प्रभाव लागू करें**

Aspose.Slides for .NET में सॉफ्ट एज प्रभाव लागू करने के लिए आप आकार के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए उपयुक्त है जिन्हें कोमल, मुलायम दिखावट चाहिए। आप आसानी से त्रिज्या जैसे पैरामीटर को समायोजित करके विभिन्न आकारों में वांछित प्रभाव प्राप्त कर सकते हैं।

यह C# कोड दिखाता है कि कैसे [सॉफ्ट एज](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) को किसी आकार पर लागू किया जाता है:

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

![सॉफ्ट एज प्रभाव](soft_edges_effect.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकृति पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप छाया, परावर्तन और ग्लो जैसे विभिन्न प्रभावों को एक ही आकृति पर संयोजित कर सकते हैं ताकि अधिक गतिशील स्वरूप प्राप्त हो सके।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोषेप, चार्ट, तालिका, चित्र, SmartArt वस्तुएँ, OLE वस्तुएँ और अधिक शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।