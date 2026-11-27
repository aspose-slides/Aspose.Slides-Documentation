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

PowerPoint में प्रभावों को किसी आकार को उभारा बनाने के लिए उपयोग किया जा सकता है, लेकिन वे [भरण](/slides/hi/net/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकार पर विश्वसनीय परावर्तन, आकार की चमक आदि बना सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इसलिए, PowerPoint में **Preset** के अंतर्गत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों के निर्धारित अच्छे दिखने वाले संयोजन होते हैं। इस प्रकार, किसी Preset को चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides में [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टी और मेथड उपलब्ध हैं जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने देते हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for .NET आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपने प्रस्तुतिकरण के डिजाइन से मेल खाने के लिए अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

बाहरी छाया का उपयोग करके आप किसी कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध उभारा बना सकते हैं। छाया आकार के किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव मिलता है कि आकार स्लाइड से उठाया गया है। इस रंग, दिशा, दूरी और ब्लर त्रिज्या को अपने टेम्पलेट की रोशनी और शैली से मेल खाने के लिए समायोजित करें।

यह C# कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) लागू किया जाए:

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

#### **जब आकार घुमता है तो छाया दिशा को नियंत्रित करें**

डिफ़ॉल्ट रूप से, [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) `true` होता है, इसलिए छाया आकार के साथ घूमती है। विभिन्न घुमाव वाले आकारों को समान दिशा से प्रकाशित दिखाने के लिये, इस प्रॉपर्टी को `false` सेट करें और उनकी छायाओं को समान [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/) दें।

उदाहरण दो तीर बनाता है जिनकी ग्रे छाया दाईं ओर (`Direction = 0`) स्थित है। फिर यह स्लाइड को डुप्लिकेट करता है और दोनों तीरों को 90° घड़ी की दिशा में घुमाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

दूसरी स्लाइड पर, बायां तीर अपनी छाया नीचे की ओर डालता है, जबकि दायां तीर अभी भी अपनी छाया दाईं ओर रखता है। दोनों छायाओं की कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![PowerPoint rendering before and after a 90° rotation. Both shadows start on the right. After rotation, the shadow moves below the left arrow and stays to the right of the right arrow.](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को दोहराते हैं, तो आंतरिक छाया का उपयोग करके कार्ड या पैनल को एक अंतर्निहित दिखावट दे सकते हैं। बाहरी छाया आकार के बाहर विस्तारित होकर उसे उठाया हुआ बनाती है, जबकि आंतरिक छाया किनारों के भीतर शेडिंग करती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/) को कॉन्फ़िगर करें। बड़ी मानों से नरम किनारे प्राप्त होते हैं।

यह C# उदाहरण एक हल्के नीले कार्ड पर गहरा ग्रे आंतरिक छाया बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

आंतरिक छाया हटाने के लिये, आकार के effect format पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

### **Preset छाया लागू करें, बदलें और हटाएँ**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) को कॉल करें और [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) को किसी नामित [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) पर सेट करें। शैली बदलने के लिये, वही आकार पर प्रीसेट बदलें। छाया को हटाने और fill व outline को बरकरार रखने के लिये [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) को कॉल करें।

यह उदाहरण प्रत्येक चरण पर आयत की एक प्रति रखता है। दोनों छायाएँ 10 पॉइंट द्वारा ऑफ़सेट की गई हैं। 225° की दिशा पहली छाया को आयत के ऊपर और बाईं ओर रखती है, और 45° दिशा दूसरी छाया को नीचे और दाईं ओर रखती है।

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

| मूल | पहला Preset | दूसरा Preset | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for .NET में परावर्तन प्रभाव लागू करने के लिये आप आकारों पर एक दर्पण‑समान परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकारों को अधिक परिष्कृत दिखावट देता है। यह सरल कोड के साथ सहजता से लागू किया जा सकता है, जिससे कई तत्वों पर निरंतर डिज़ाइन के लिये तेज़ी से लागू किया जा सके।

यह C# कोड दिखाता है कि कैसे एक आकार पर [paravartan effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) लागू किया जाए:

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

Aspose.Slides for .NET में किसी आकार पर चमक प्रभाव लागू करने के लिये आप आकार के आसपास एक नरम, उज्ज्वल आभा जोड़ सकते हैं, रंग और आकार जैसी प्रॉपर्टी को समायोजित कर सकते हैं। यह प्रभाव आकारों को उभारा बनाता है और आपके प्रस्तुतिकरण में आकर्षक दृश्य तत्व जोड़ता है। यह न्यूनतम कोड के साथ आसान कार्यान्वयन प्रदान करता है, जिससे आपके स्लाइडों की कुल दिखावट सुधरती है।

यह C# कोड दिखाता है कि कैसे एक आकार पर [glow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) लागू किया जाए:

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

Aspose.Slides for .NET में नरम किनारे प्रभाव लागू करने के लिये आप आकार के किनारों के चारों ओर एक सुगम, धुंधले संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत दिखावट जोड़ता है, जो उन डिज़ाइनों के लिये उपयुक्त है जिन्हें हल्का, नरम रूप चाहिए। आप radius जैसे पैरामीटर को आसानी से समायोजित कर विभिन्न आकारों में इच्छित प्रभाव प्राप्त कर सकते हैं।

यह C# कोड दिखाता है कि कैसे एक आकार पर [soft edges](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) लागू किया जाए:

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

आकार ब्लर का उपयोग करके आकार की fill और outline को मुलायम किया जा सकता है जबकि आकार को संपादन योग्य रखा जाता है। shape के effect format पर [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। radius पॉइंट में मापा जाता है (1/72 इंच): एक गैर‑नकारात्मक मान उपयोग करें, बड़ी मान बड़ी ब्लर देता है। radius शून्य रखने पर स्वरूप अपरिवर्तित रहता है।

[Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` होने पर, ब्लर मूल चित्रित सीमा तक ही सीमित रहता है, जिसमें outline भी शामिल है। `true` होने पर, ब्लर इन सीमाओं से बाहर तक विस्तारित हो सकता है। इन सेटिंग्स में से कोई भी आकार की स्थिति या माप को बदलती नहीं है।

नीचे दिया गया तुलना समान fill, outline और आकार माप का उपयोग करती है। ऊपर की पंक्तियों में `grow = false` है; नीचे की पंक्तियों में `grow = true` है।

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

यह C# उदाहरण एक नारंगी आयत को डार्क ब्लू outline के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) को कॉल करके 15‑पॉइंट ब्लर पर अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) को कॉल करके बिना ब्लर के आकार को सहेजता है।

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

आकार ब्लर fill और outline दोनों को समान रूप से प्रभावित करता है। नरम किनारे प्रभाव आकार के किनारों को फीका करता है, जबकि छाया ब्लर केवल छाया को मुलायम करता है। छवि परिवर्तन प्रभाव छवि सामग्री पर काम करते हैं; यह उदाहरण shape के effect format पर सीधे ब्लर लागू करता है बिना shape को छवि में परिवर्तित किए।

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभाव, जैसे छाया, परावर्तन, और चमक, को मिलाकर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लगा सकते हैं, जिसमें autoshapes, charts, tables, pictures, SmartArt objects, OLE objects आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लगा सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लगा सकते हैं। प्रभाव पूरी समूह पर लागू होगा।