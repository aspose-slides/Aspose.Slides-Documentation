---
title: .NET में कस्टम एनीमेशन बिहेवियर्स बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/net/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- गति पथ
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में कस्टम एनीमेशन बिहेवियर्स और संपादन योग्य गति पथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनीमेशन बिहेवियर्स आपको एनीमेशन इफ़ेक्ट के भीतर व्यक्तिगत ऑपरेशन्स को नियंत्रित करने की अनुमति देते हैं, जैसे रंग बदलना, आकार को घुमाना, या संपादन योग्य मोशन पाथ का अनुसरण करना। यह गाइड दर्शाता है कि कैसे बिहेवियर्स बनाएं और संयोजित करें, उनका टाइमिंग कॉन्फ़िगर करें, मौजूदा एनीमेशन को निरीक्षण और संशोधित करें, और यह सत्यापित करें कि उनके गुण प्रस्तुति को सहेजने और पुनः खोलने पर भी बनाए रहें।

पूर्वनिर्धारित प्रभावों और क्लिक ट्रिगर के लिए देखें [शेप एनीमेशन](/slides/hi/net/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एक एनीमेशन को **Timeline → Sequence → Effect → Behaviors** के रूप में व्यवस्थित किया जाता है:

- स्लाइड का [Timeline](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/timeline/) इसमें मुख्य क्रम और इंटरैक्टिव क्रम होते हैं।
- एक [ISequence](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/) प्रभावों को रखता है, जो संभावित रूप से विभिन्न आकारों को लक्ष्य बनाते हैं।
- एक [IEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/) लक्ष्य आकार, प्रीसेट, सबटाइप, और इफ़ेक्ट टाइमिंग को पहचानता है।
- [IEffect.Behaviors](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/behaviors/) उन ऑपरेशनों को रखता है जो प्रभाव को लागू करते हैं: रंग बदलना, गति, घूमना, प्रॉपर्टी सेट करना, आदि।

## **व्यक्तिगत बिहेवियर्स बनाएं**

[ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) को कॉल करके एक इफ़ेक्ट बनाएं और उसके [Behaviors](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/behaviors/) संग्रह तक पहुँचें। एक प्रीसेट इस संग्रह को स्वतः भर सकता है। प्रीसेट का विस्तार करते समय उसके ऑपरेशन्स को रख‑रखाव करें, या जानबूझकर बदलते समय [Clear](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/clear/) का उपयोग करें।

[IBehaviorFactory](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/) नीचे दिखाए गए आठ बिहेवियर प्रकार बनाता है। मोशन को [Build a Motion Path](#build-a-motion-path) में कवर किया गया है। प्रत्येक निर्माण उदाहरण एक संपूर्ण प्रोग्राम है; बाद के संपादन उदाहरण दर्शाते हैं कि कौन‑सा आउटपुट फ़ाइल उपयोग होती है।

### **घुमाव (Rotation)**

एक घुमाव बनाने के लिए [CreateRotationEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) का उपयोग करें। [By](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/irotationeffect/by/) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [From](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/irotationeffect/from/) और [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/irotationeffect/to/) अंत बिंदु निर्धारित करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू होता है, उसके प्रीसेट ऑपरेशन्स को एक घुमाव बिहेवियर से बदलता है, और उस ऑपरेशन को दो‑सेकंड का अवधि देता है। 90‑डिग्री का सापेक्ष कोण आकार की प्रारंभिक अभिविन्यास से एक चौथाई घुमाव दर्शाता है, इसलिए स्पष्ट प्रारंभिक कोण की आवश्यकता नहीं है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` में एक आकार और एक घुमाव बिहेवियर है। नीचे की संग्रह, टाइमिंग, और घुमाव‑संपादन उदाहरण इस फ़ाइल का उपयोग करते हैं।

### **स्केल (Scale)**

[X/Y प्रतिशत] के साथ [CreateScaleEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) का उपयोग करें: [From](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/iscaleeffect/from/) और [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/iscaleeffect/to/) प्रारंभ और अंत आकार का वर्णन करते हैं, जबकि [By](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/iscaleeffect/by/) सापेक्ष परिवर्तन को दर्शाता है। यहाँ, 100 मूल आकार को दर्शाता है।

उदाहरण दोनों आयामों को 100 % से 125 % तक दो सेकंड में बढ़ाता है। समान क्षैतिज और लंबवत प्रतिशत रखने से आकार के अनुपात बरकरार रहते हैं; अलग‑अलग प्रतिशत रखे जाने पर एक आयाम अधिक खिंचा रहेगा।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **रंग (Color)**

[CreateColorEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) का उपयोग करके भराव को नीले से नारंगी में बदलें। [From](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icoloreffect/from/) और [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icoloreffect/to/) रंग हैं; [By](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icoloreffect/by/) रंग ऑफ़सेट है। [IBehavior.Properties](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehavior/properties/) वह गुण पहचानता है जिसे एनीमेट किया जा रहा है।

आकार की ठोस भराव को नीला प्रारंभिक रंग सेट किया गया है, जो एनीमेशन के प्रारंभिक रंग से मेल खाता है। भराव‑रंग गुण चुनने से बिहेवियर को पता चलता है कि आकार के किस भाग को बदलना है; केवल रंग के अंत बिंदु यह निर्धारित नहीं करते। सहेजा गया इफ़ेक्ट दो‑सेकंड में नारंगी में बदलाव का वर्णन करता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **फ़िल्टर (Filter)**

[CreateFilterEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) का उपयोग करके एक वाइप चुनें। [Type](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ifiltereffect/subtype/), और [Reveal](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ifiltereffect/reveal/) क्रमशः फ़िल्टर, दिशा, और आकार को प्रकट या छिपाने को निर्धारित करते हैं।

यह उदाहरण दो‑सेकंड की वाइप को राइट‑डायरेक्शन सबटाइप के साथ कॉन्फ़िगर करता है जो आकार को प्रकट करता है। फ़िल्टर सेटिंग्स प्रभाव के भीतर बिहेवियर से संबंधित हैं, इसलिए प्रीसेट की मूल ऑपरेशन्स हटाने के बाद उन्हें कॉन्फ़िगर किया जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **प्रॉपर्टी (Property)**

[CreatePropertyEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) का उपयोग करके अपारदर्शिता (opacity) को एनीमेट करें। [From](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ipropertyeffect/to/), और [By](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ipropertyeffect/by/) स्ट्रिंग्स हैं जो [ValueType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ipropertyeffect/valuetype/) और [CalcMode](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ipropertyeffect/calcmode/) द्वारा व्याख्यायित होती हैं। सभी तीन को एक साथ सेट करने के बजाय अंत बिंदु या सापेक्ष ऑफ़सेट चुनें।

इस उदाहरण में चयनित गुण अपारदर्शिता है, और संख्यात्मक स्ट्रिंग्स 25 % अपारदर्शिता से पूर्ण अपारदर्शिता तक परिवर्तन दर्शाती हैं। रैखिक अंतरवलन (Linear interpolation) इन मानों के बीच धीरे‑धीरे परिवर्तन का वर्णन करता है। इस उदाहरण को किसी अन्य गुण पर लागू करते समय उस गुण के अनुसार उपयुक्त मान प्रकार और अंत बिंदु मान चुनें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **सेट (Set)**

[CreateSetEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) का उपयोग करके [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/iseteffect/to/) के माध्यम से दृश्यमानता (visibility) असाइन करें। सेट बिहेवियर अंत बिंदुओं के बीच अंतरवलन नहीं करता।

यह उदाहरण दृश्यमानता गुण चुनता है और बिहेवियर के चलने पर स्ट्रिंग `visible` असाइन करता है। न्यूनतम प्रस्तुति में आयत पहले से ही दृश्यमान है, इसलिए यह असाइनमेंट स्वयं में स्पष्ट दृश्य परिवर्तन नहीं ला सकता। यह ऑपरेशन बड़े इफ़ेक्ट का भाग बनकर उपयोगी होता है जो यह भी नियंत्रित करता है कि आकार कब छिपे या दिखाई दे।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **कमांड (Command)**

[CreateCommandEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) का उपयोग करके [Type](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icommandeffect/commandstring/), और [ShapeTarget](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/icommandeffect/shapetarget/) सेट करें। कार्य निर्देशिका में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [AddAudioFrameEmbedded](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addaudioframeembedded/) के साथ एम्बेड करता है और ऑडियो फ़्रेम को प्ले कमांड जोड़ता है।

ऑडियो फ़्रेम इफ़ेक्ट का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; केवल कमांड स्ट्रिंग यह नहीं बताती कि कौन‑सा मीडिया ऑब्जेक्ट नियंत्रित किया जाना है। इफ़ेक्ट को स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

सेव करने से कमांड `command.pptx` में सहेजा जाता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिए ऐसा स्लाइडशो प्लेयर चाहिए जो कमांड और उसके मीडिया लक्ष्य को सपोर्ट करता हो।

## **बिहेवियर संग्रह का प्रबंधन**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/) में [Add](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/remove/), और [RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/removeat/) उपलब्ध हैं। यह उदाहरण `rotation.pptx` खोलता है, स्केलिंग जोड़ता है, उसे घुमाव से पहले ले जाता है, और घुमाव को हटाता है। एक ही ऑब्जेक्ट को हटाने और पुनः सम्मिलित करने से उसकी संग्रहीत स्थिति बदलती है, बिना कोई प्रति बनाए।

संपादन क्रम संग्रह को rotation–scale से scale–rotation में, फिर केवल scale में बदलता है। इंडेक्स वर्तमान संग्रह को दर्शाते हैं, इसलिए पुनः क्रमबद्ध होने के बाद घुमाव के नए इंडेक्स का उपयोग हटाने में किया जाता है। अंतिम गणना यह पुष्टि करती है कि कौन‑सा बिहेवियर सहेजा जाएगा।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग बची है। केवल क्रम स्वयं बिहेवियर्स को क्रम‑बद्ध नहीं करता। सभी ऑपरेशन्स को बदलने पर ही संग्रह को साफ़ करें।

## **बिहेवियर टाइमिंग कॉन्फ़िगर करना**

[IBehavior.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehavior/timing/) [ITiming](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/) को उजागर करता है, जो [IEffect.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/timing/) से स्वतंत्र है। इफ़ेक्ट टाइमिंग enclosing effect को शेड्यूल करता है; बिहेवियर टाइमिंग उसके भीतर की ऑपरेशन को वर्णन करता है।

### **अवधि, विलंब, पुनरावृत्ति और त्वरण सेट करना**

`rotation.pptx` खोलें और सेकंड में [Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/duration/) तथा [TriggerDelayTime](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/triggerdelaytime/) सेट करें, फिर [RepeatCount](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatcount/) कॉन्फ़िगर करें। [Accelerate](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/accelerate/) और [Decelerate](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/decelerate/) अवधि के अंश होते हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जिसे घुमाव उदाहरण में बनाया गया था, जहाँ पहला बिहेवियर घुमाव है। यह उदाहरण केवल उस बिहेवियर की टाइमिंग बदलता है; उसका 90‑डिग्री का कोण अपरिवर्तित रहता है। कोण और टाइमिंग को अलग‑अलग रखना गति को पुनः‑निर्माण किए बिना समायोजित करना आसान बनाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

बिहेवियर दो‑सेकंड की अवधि, आधा‑सेकंड की देरी, और 3 की पुनरावृत्ति गिनती का उपयोग करता है। उसकी अवधि का प्रथम और अंतिम 20 % त्वरण और मंदी के लिए प्रयोग होता है।

अन्य पुनरावृत्ति नीतियों में [RepeatDuration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilendslide/), और [RepeatUntilNextClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilnextclick/) शामिल हैं; सभी को एकसाथ सक्षम करने के बजाय एक नीति चुनें। [AutoReverse](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/autoreverse/) फॉरवर्ड पास के बाद एनीमेशन को उल्टा चलाता है। त्वरण और मंदी सतत परिवर्तनों पर लागू होते हैं, न कि डिस्क्रीट असाइनमेंट या कमांड पर।

## **मोटियन पाथ बनाएं**

[CreateMotionEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) का उपयोग करके मोशन बनाएं। इसके [From](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/to/), और [By](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/by/) प्रतिशत‑आधारित निर्देशांक या ऑफ़सेट दर्शाते हैं। संपादन योग्य मार्ग के लिए एक [MotionPath](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/motionpath/) बनाएं और उसे [IMotionEffect.Path](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/path/) को असाइन करें। [IMotionPath](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotionpath/) पाथ कमांड्स को संग्रहीत करता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/motioncommandpathtype/) ऑपरेशन चुनता है:

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | One | प्रारंभिक स्थिति सेट करें। |
| LineTo | One | सीधी रेखा के अंत बिंदु तक ले जाएँ। |
| CurveTo | Three | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित क्यूबिक वक्र का अनुसरण करें। |
| CloseLoop | None | प्रारंभिक स्थिति पर लौटें। |
| End | None | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/motionpathpointstype/) बिंदु‑संपादन विशेषताओं का वर्णन करता है, जैसे कोना या स्मूथ बिंदु। यह कमांड प्रकार को नहीं बदलता। नीचे के वक्र उदाहरण में एक कर्व बिंदु प्रकार और सीधी रेखा के लिए कोना बिंदु प्रकार उपयोग करें।

पाथ निर्देशांक स्लाइड आयामों के सापेक्ष नॉर्मलाइज़ होते हैं: X विस्थापन 0.25 स्लाइड की चौड़ाई के एक‑चौथाई का प्रतिनिधित्व करता है, न कि 0.25 पॉइंट्स। Y सकारात्मक नीचे की ओर बढ़ता है। Absolute कमांड पाथ निर्देशांक प्रणाली में स्थितियों को निर्दिष्ट करते हैं; Relative कमांड वर्तमान स्थिति से ऑफ़सेट निर्दिष्ट करते हैं। यह [Origin](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/origin/) और [PathEditMode](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioneffect/patheditmode/) से अलग है, जो क्रमशः पाथ की रेफरेंस फ्रेम और आकार के स्थानांतरित होने पर पाथ के व्यवहार को नियंत्रित करता है।

### **सीधी पाथ बनाना**

एक मोशन बिहेवियर बनाएं जिसमें प्रारंभिक बिंदु, एक सीधा खंड, और अंत कमांड हो। [IMotionPath.Add](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotionpath/add/) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और सापेक्ष‑निर्देशांक फ़्लैग लेता है।

प्रारंभिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड चौड़ाई के एक‑चौथाई की क्षैतिज विस्थापन प्राप्त करता है। अंत कमांड में कोई बिंदु नहीं होते। पाथ असाइन होने के बाद, मोशन बिहेवियर को इफ़ेक्ट में जोड़ने से वह आयत से जुड़ जाता है।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` में तीन पाथ कमांड वाले एक मोशन बिहेवियर होते हैं। नीचे के फ़ाइल‑संपादन उदाहरण इस ज्ञात संरचना का उपयोग करते हैं।

### **Absolute और Relative निर्देशांक की तुलना**

ये दो पाथ ऑब्जेक्ट समान मार्ग दर्शाते हैं। Absolute कमांड (0.3, 0.1) पर समाप्त होता है; Relative कमांड वर्तमान स्थिति में (0.1, 0.1) जोड़कर (0.2, 0) बनाता है।

दोनों पाथ समान प्रारंभिक स्थिति से शुरू होते हैं। Relative रेखा के लिए वर्तमान स्थिति में X और Y ऑफ़सेट जोड़ें ताकि अंत बिंदु प्राप्त हो; Absolute रेखा के लिए सीधे अंत बिंदु पढ़ें। फ़्लैग बदलने से बिना निर्देशांक परिवर्तित किए अलग मार्ग बन जाएगा।

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

किसी भी पाथ को मोशन बिहेवियर में असाइन करके प्रस्तुति में उपयोग करें। अंतिम बूलियन पैरामीटर उस कमांड के लिए Relative निर्देशांक चुनता है।

### **रेखा को वक्र से बदलना**

`motion.pptx` खोलें और उसकी रेखा कमांड को क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु, फिर अंत बिंदु प्रदान करें।

प्रारंभिक स्थिति पिछले कमांड द्वारा निर्धारित होती है। पहले दो बिंदु कर्व को आकार देते हैं, तीसरा उसका गंतव्य है; ये क्रमागत तीन गंतव्य नहीं होते। कमांड प्रकार, बिंदु‑संपादन प्रकार, और बिंदु ऐरे को साथ‑साथ अपडेट करने से खंड नई ज्यामिति के साथ सुसंगत रहता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

`curve.pptx` में पाथ अभी भी तीन कमांड रखता है; उसका मध्य कमांड अब कर्व को परिभाषित करता है।

## **सहेजा गया पाथ निरीक्षण और संपादन**

प्रत्येक [IMotionCmdPath](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioncmdpath/) में [Points](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioncmdpath/pointstype/), और [IsRelative](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotioncmdpath/isrelative/) उपलब्ध हैं। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन‑कमांड पाथ का उपयोग करते हैं। अनिश्चित इनपुट के लिए, प्रभाव खोजें, और संपादन से पहले कमांड प्रकार और बिंदु गणना जाँचें।

### **कमांड और निर्देशांक पढ़ना**

पाथ को बदले बिना पढ़ें। End और CloseLoop कमांड को बिंदुओं की आवश्यकता नहीं होती, इसलिए null बिंदु ऐरे की अनुमति दें।

आउटपुट प्रत्येक कमांड को उसके Relative‑coordinate फ़्लैग के साथ जोड़ता है, फिर उसके बिंदुओं की सूची देता है। यह आपको बिंदु को ऑफ़सेट या अंत बिंदु के रूप में पहचानने में मदद करता है, इससे पहले कि आप पाथ बदलें। कर्व तीन बिंदु सूचीबद्ध करेगा, जबकि इस फ़ाइल की सीधी रेखा केवल एक बिंदु दिखाती है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

सूची में एक प्रारंभिक बिंदु, (0.25, 0) पर समाप्त होने वाली absolute रेखा, और एक End कमांड शामिल है।

### **अंत बिंदु बदलना**

`motion.pptx` खोलें और रेखा के बिंदु ऐरे को बदलकर उसके अंत बिंदु को स्थानांतरित करें।

इनपुट फ़ाइल में इंडेक्स 0 प्रारंभिक कमांड है और इंडेक्स 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसका गंतव्य बदलेगा, जबकि कमांड प्रकार, टाइमिंग या संग्रह में उसकी स्थिति नहीं बदलेगी। चूँकि कमांड absolute निर्देशांक उपयोग करता है, नया युग्म एक स्थिति निर्दिष्ट करता है, न कि जोड़ी गई ऑफ़सेट।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

`motion-endpoint.pptx` में रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलना**

[Insert](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotionpath/insert/) और [RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/imotionpath/removeat/) का उपयोग करके `motion.pptx` में रेखा को बदलें। Insert करने से पुरानी रेखा इंडेक्स 2 पर चली जाती है।

यह कमांड ऑब्जेक्ट को बदलने को दर्शाता है न कि उसके मौजूदा निर्देशांक को संपादित करने को। insertion के बाद संग्रह अस्थायी रूप से प्रारंभिक कमांड, नई रेखा, पुरानी रेखा, और End कमांड रखता है। इंडेक्स 2 को हटाने से पुरानी रेखा हट जाती है और नई मार्ग स्थान पर रहती है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और End कमांड अंत में रहता है।

## **मौजूदा बिहेवियर का संशोधन और सत्यापन**

जब बिहेवियर का इंडेक्स अज्ञात हो, तो प्रकार द्वारा चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [IRotationEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/irotationeffect/) खोजता है, कोण बदलता है, और पुनः‑खोलने के बाद सहेजी गई मान की जाँच करता है।

प्रकार जाँच लूप को उन बिहेवियर्स को छोड़ने देती है जो घुमाव नहीं हैं। दूसरे लोड में फ़ाइल को अलग प्रस्तुति ऑब्जेक्ट में पढ़ा जाता है, इसलिए तुलना सहेजे गए डेटा की जाँच करती है, न कि मेमोरी में अभी मौजूद मान की। यह उदाहरण अभी भी मानता है कि ज्ञात इफ़ेक्ट मुख्य क्रम में पहला है; प्रकार द्वारा बिहेवियर चुनना किसी भी प्रस्तुति में सही इफ़ेक्ट नहीं ढूँढ़ता।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

आउटपुट `Rotation preserved: True` है। समान प्रकार‑जाँच पैटर्न को अन्य बिहेवियर्स पर लागू करें। पूर्ण संरक्षण जाँच के लिए लक्ष्य आकार, इफ़ेक्ट, बिहेवियर प्रकार और क्रम, टाइमिंग, और पाथ कमांड्स की तुलना करें। फ़्लोटिंग‑पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अज्ञात एनीमेशन लेआउट वाली प्रस्तुति के लिए, मुख्य और इंटरैक्टिव क्रमों के पार घूमने हेतु [Read Shape Animations](/slides/hi/net/shape-animation/#read-shape-animations) देखें।

## **बिहेवियर क्रम, प्रीसेट, और प्लेबैक**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehaviorcollection/) में क्रम इफ़ेक्ट की ऑपरेशनों का संग्रहीत क्रम है। यह एक प्ले‑लिस्ट नहीं है जिसमें हर बिहेवियर स्वचालित रूप से पिछले का इंतज़ार करता है। शेड्यूलिंग टाइमिंग और enclosing इफ़ेक्ट द्वारा निर्धारित होती है। बिहेवियर्स ओवरलैप हो सकते हैं, और समान गुण पर ऑपरेशन्स [Additive](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehavior/additive/) और [Accumulate](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ibehavior/accumulate/) के माध्यम से इंटरैक्ट कर सकते हैं। केवल संग्रह पुनः‑क्रमबद्ध करके “move, then rotate” शेड्यूल न करें; जैसा कि [Shape Animation](/slides/hi/net/shape-animation/) में बताया गया है, स्पष्ट टाइमिंग या अलग‑अलग इफ़ेक्ट का उपयोग करें।

इफ़ेक्ट का [Type](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/type/) और [Subtype](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/subtype/) उसके प्रीसेट को वर्णित करते हैं। वे संपादित बिहेवियर ट्री का संपूर्ण विवरण नहीं देते। बिहेवियर्स को कस्टमाइज़ करने से पहले प्रीसेट और सबटाइप चुनें: प्रीसेट बदलने से संग्रह पुनः‑निर्मित हो सकता है और आपके कस्टम ऑपरेशन्स हट सकते हैं। उदाहरण के लिए, कस्टम Spin इफ़ेक्ट को Fade में बदलने से घुमाव बिहेवियर सेट और फ़िल्टर बिहेवियर्स से बदल सकता है। प्रीसेट या सबटाइप बदलने के बाद संग्रह को फिर‑से निरीक्षण करें। प्रीसेट बिहेवियर्स को साफ़ करने से दृश्यता या प्रारंभिक ऑपरेशन्स भी हट सकते हैं, जो प्रीसेट के लिए आवश्यक हो सकते हैं। उदाहरण स्पष्ट रूप से दृश्यमान आकारों का उपयोग करते हैं और बिहेवियर्स को बदलते हैं; वे हर प्रीसेट की पूरी कार्यान्वयन को पुनः‑निर्मित नहीं करते।

## **फ़ॉर्मेट संगतता**

संरक्षित बिहेवियर ट्री सभी व्यूअर्स या एक्सपोर्ट रेंडरर्स में समान प्लेबैक की गारंटी नहीं देता। सहेजे गए डेटा और रेंडर आउटपुट को अलग‑अलग जाँचें।

| फ़ॉर्मेट या आउटपुट | क्या सत्यापित करें |
| --- | --- |
| PPTX | इन उदाहरणों के लिए प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। पुनः‑खोलकर एडीटेबल बिहेवियर ट्री की जाँच करें, फिर इच्छित PowerPoint संस्करण में प्लेबैक जांचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। अलग‑अलग सहेजा‑और‑पुनः‑खोल चक्र और प्लेबैक परीक्षण करें; सफल PPTX आउटपुट से सभी कस्टम संयोजनों के समर्थन का निष्कर्ष न निकालें। |
| PDF, PNG, JPEG, और अन्य स्थैतिक स्लाइड छवियां | स्थिर स्लाइड प्रतिनिधित्व होते हैं, न कि चलने योग्य बिहेवियर टाइमलाइन या निश्चित एनीमेशन फ्रेम। |
| [HTML5](/slides/hi/net/export-to-html5/) | यदि एक्सपोर्ट विकल्पों में शैप एनीमेशन सक्षम हो तो समर्थित एनीमेशन चल सकते हैं। ब्राउज़र में कस्टम संयोजनों का परीक्षण करें। |
| [Animated GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ्रेम स्टोर करता है, न कि एडिटेबल बिहेवियर्स या क्लिक‑ट्रिगर इंटरैक्शन। वास्तविक गति देखें। |
| [Video](/slides/hi/net/convert-powerpoint-to-video/) | एनीमेशन फ्रेम रेंडर करता है और उन्हें वीडियो के रूप में एन्कोड करता है। समर्थन सीमित है रेंडरर के [supported animations and effects](/slides/hi/net/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड और इंटरैक्टिव इवेंट्स एडीटेबल टाइमलाइन नहीं बनते। |

## **अक्सर पूछे जाने वाले प्रश्न (FAQ)**

**मेरे इफ़ेक्ट में बिहेवियर्स क्यों हैं जबकि मैंने कुछ नहीं जोड़ा?**  
प्रीडिफ़ाइंड इफ़ेक्ट बनाते समय उसके अंतर्निहित ऑपरेशन्स निर्मित हो सकते हैं। उन्हें विस्तारित करने या बदलने से पहले निरीक्षण करें।

**बिहेवियर को शुरुआत में ले जाने से क्या वह पहले चलेगा?**  
ज़रूरी नहीं। संग्रह क्रम टाइमिंग का विकल्प नहीं है। देरी, अवधि, और समान गुण पर ऑपरेशन्स के इंटरैक्शन जाँचें।

**End कमांड के पास बिंदु नहीं होते क्यों?**  
यह पाथ के समाप्ति को दर्शाता है और किसी निर्देशांक की आवश्यकता नहीं होती। फ़ाइल‑पढ़ते समय null बिंदु ऐरे की जाँच करें।

**क्या सफल राउंड‑ट्रिप प्लेबैक की पुष्टि करता है?**  
नहीं। पुनः‑खोलना केवल आपने जाँचें गए गुणों के संरक्षण की पुष्टि करता है। दृश्य व्यवहार को पुष्टि करने के लिए स्लाइडशो प्लेयर या एनीमेटेड एक्सपोर्ट को अलग‑अलग परीक्षण करें।