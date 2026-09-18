---
title: .NET में प्रस्तुतियों में शैप एनीमेशन लागू करें
linktitle: शैप एनीमेशन
type: docs
weight: 60
url: /hi/net/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनीमेटेड आकार
- एनीमेटेड पाठ
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ शैप एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन के बाद के व्यवहार और एनीमेटेड पाठ को जोड़ने, निरीक्षण करने और अनुकूलित करने की विधि जानें।"
---
## **अवलोकन**

इफ़ेक्ट के भीतर व्यक्तिगत व्यवहारों के साथ काम करने या मोशन-पाथ सेगमेंट संपादित करने के लिए, देखें [Custom Animation](/slides/hi/net/custom-animation/)।

Aspose.Slides for .NET स्लाइड एनीमेशन को स्लाइड टाइमलाइन में प्रभाव (effects) के रूप में दर्शाता है। एक प्रभाव में लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे ध्वनि या एनीमेशन बाद का व्यवहार होते हैं।

टाइमलाइन में दो प्रकार की क्रम (sequences) होते हैं:

- **मुख्य क्रम** स्लाइड आगे बढ़ने पर चलता है।
- **इंटरैक्टिव क्रम** तब शुरू होता है जब उसका ट्रिगर आकार क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल, और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) मेथड उपयोग करते हैं। उपलब्ध प्रभावों की सूची [EffectType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttype/) एनेमरेशन में दी गई है।

## **शेप एनीमेशन जोड़ें**

एक एनीमेशन जोड़ने के लिए, स्लाइड की मुख्य क्रम प्राप्त करें और [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) को लक्ष्य आकार, प्रभाव प्रकार, उपप्रकार और ट्रिगर के साथ कॉल करें। किसी प्रभाव के लिए जो अन्य आकार के क्लिक करने पर शुरू होता है, एक इंटरैक्टिव क्रम बनाएं जिसका ट्रिगर वह अन्य आकार हो।

निम्नलिखित उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

ट्रिगर नियंत्रित करता है कि प्रभाव कब शुरू होता है:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttriggertype/) मुख्य क्रम में क्लिक के लिए या इंटरैक्टिव क्रम में ट्रिगर आकार पर क्लिक के लिए प्रतीक्षा करता है।
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttriggertype/) पूर्ववर्ती प्रभाव के साथ शुरू होता है।
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttriggertype/) पूर्ववर्ती प्रभाव के समाप्त होने पर शुरू होता है।

एक चित्र, चार्ट, या अन्य आकार प्रकार को एनीमेट करने के लिए, `targetShape` के बजाय उस ऑब्जेक्ट को [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) में पास करें। चार्ट-विशिष्ट ग्रुपिंग विकल्पों के लिए देखें [Animated Charts](/slides/hi/net/animated-charts/)।

## **शेप एनीमेशन पढ़ें**

जब आप लक्ष्य आकार जानते हैं, तब [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/geteffectsbyshape/) का उपयोग करें। प्रत्येक प्रभाव की जांच करने के लिए, मुख्य क्रम और प्रत्येक इंटरैक्टिव क्रम को क्रमबद्ध करें। क्रमबद्ध करने से यह मानने से बचा जाता है कि क्रम में इंडेक्स `0` पर कोई प्रभाव मौजूद है।

निम्नलिखित उदाहरण मुख्य-क्रम और इंटरैक्टिव प्रभावों के साथ एक आकार बनाता है, आकार को लक्षित करने वाले प्रभावों को प्राप्त करता है, और फिर स्लाइड पर प्रत्येक क्रम को क्रमबद्ध करता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

यदि आपको केवल एक आकार के लिए प्रभाव चाहिए, तो पहले आकार को नाम, प्लेसहोल्डर प्रकार, या किसी अन्य स्थिर गुण से पहचानें; फिर [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/geteffectsbyshape/) को कॉल करें। यह न मानें कि इंडेक्स `0` पर [IShapeCollection.Item](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/item/) हमेशा इच्छित ऑब्जेक्ट होता है।

## **इनहेरिटेड प्लेसहोल्डर प्रभावों के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड के संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार को इनहेरिट कर सकता है। [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getbaseplaceholder/) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `null`।

निम्नलिखित उदाहरण प्रस्तुति में, फुटर के पास सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** है।

![सामान्य स्लाइड पर फुटर एनीमेशन प्रभाव](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](master-shape-animation.png)

अगला उदाहरण प्लेसहोल्डर पदानुक्रम को स्वयं बनाता है। यह एक मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में प्रभाव जोड़ता है। उपयोग करने से पहले प्रत्येक कॉल के परिणामस्वरूप प्राप्त आकार को [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/getbaseplaceholder/) के द्वारा जाँचा जाता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** संवाद [ITiming](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/) की प्रॉपर्टीज़ के साथ मैप होता है।

![एक एनीमेशन प्रभाव के लिए PowerPoint Timing संवाद](shape-animation.png)

- **शुरू** [ITiming.TriggerType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/triggertype/) से मेल खाता है।
- **अवधि** [ITiming.Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/duration/) से मेल खाती है, सेकंड में।
- **विलंब** [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/triggerdelaytime/) से मेल खाता है, सेकंड में।
- **दोहराव** [ITiming.RepeatCount](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilnextclick/), या [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilendslide/) से मेल खाता है।
- **प्लेबैक समाप्त होने पर रीवाइंड** [ITiming.Rewind](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/rewind/) से मेल खाता है।

यह स्वतंत्र उदाहरण एक प्रभाव जोड़ता है, उसका टाइमिंग [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से बदलता है, और परिणाम को सहेजता है। लौटाए गए [IEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/) रेफ़रेंस को रखने से अनावश्यक कलेक्शन इंडेक्स से बचा जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

एक दोहराव मोड का जानबूझकर उपयोग करें। दोहराव गणना को "until" फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित परिणाम हो सकते हैं। दोहराव मोड बदलते समय, पहले [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilnextclick/) और [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilendslide/) सेट करें, फिर [ITiming.RepeatCount](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatcount/) सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय दोहराव मोड बदल जाता है।

## **एनीमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन प्रभाव एम्बेडेड ऑडियो को [IEffect.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/sound/) के माध्यम से संदर्भित कर सकता है। [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/stopprevioussound/) एक प्रभाव को बताता है कि वह पहले के प्रभाव द्वारा शुरू किए गए ऑडियो को रोक दे।

### **एक प्रभाव में साउंड जोड़ें**

निम्नलिखित उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो प्रभाव बनाता है, पहले प्रभाव के लिए साउंड के रूप में फ़ाइल एम्बेड करता है, और दूसरे प्रभाव को साउंड रोकने के लिए कॉन्फ़िगर करता है। यह [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए क्रम इंडेक्स की आवश्यकता नहीं है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **एम्बेडेड प्रभाव साउंड निकालें**

निम्नलिखित उदाहरण `presentation-with-animation-sounds.pptx` नामक स्थानीय प्रस्तुति की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों क्रमों को स्कैन करता है और प्रत्येक एम्बेडेड प्रभाव साउंड को `extracted-animation-sounds` डायरेक्ट्री में लिखता है। एक्सटेंशन [IAudio.ContentType](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudio/contenttype/) द्वारा प्रकट किए गए ऑडियो MIME प्रकार से चुना जाता है।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

बड़े ऑडियो ऑब्जेक्ट्स के लिए, [IAudio.GetStream](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudio/getstream/) का उपयोग करें और पूरे ऑब्जेक्ट को बाइट एरे में लोड करने के बजाय स्ट्रीम को फ़ाइल में कॉपी करें।

## **एनीमेशन के बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि प्रभाव समाप्त होने के बाद आकार के साथ क्या होता है।

![PowerPoint Effect Options संवाद जो After animation सेटिंग्स दिखा रहा है](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) एनेमरेशन वह आकार को अपरिवर्तित रहने, उसका रंग बदलने, एनीमेशन के बाद छिपाने, या अगली क्लिक पर छिपाने को समर्थन देता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) है, तो साथ ही [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/afteranimationcolor/) सेट करें।

यह स्वतंत्र उदाहरण एक प्रभाव बनाता है, लौटाए गए प्रभाव ऑब्जेक्ट के माध्यम से उसके एनीमेशन के बाद व्यवहार को सेट करता है, और परिणाम को सहेजता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) से प्रकार बदलने पर एनीमेशन के बाद के रंग सेटिंग साफ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित नियंत्रण होते हैं:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itextanimation/buildtype/) नियंत्रित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/animatetexttype/) नियंत्रित करता है कि टेक्स्ट एक बार में, शब्द द्वारा, या अक्षर द्वारा दिखे। [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) शब्दों या अक्षरों के बीच विलंब सेट करता है। सकारात्मक मान प्रभाव की अवधि का प्रतिशत होता है; नकारात्मक मान सेकंड में विलंब होता है।

निम्नलिखित स्वतंत्र उदाहरण टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype/) पैराग्राफ-बार-बार निर्माण को अक्षम करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

पैराग्राफ द्वारा टेक्स्ट बॉक्स बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype/) (या कोई अन्य पैराग्राफ स्तर) सेट करें। एक ही पैराग्राफ को उसके स्वयं के प्रभाव के साथ लक्षित करने के लिए, उस [ISequence.AddEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/addeffect/) ओवरलोड का उपयोग करें जो एक [IParagraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph/) स्वीकार करता है। पैराग्राफ-स्तर के उदाहरणों के लिए देखें [Animated Text](/slides/hi/net/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियां एनीमेशन नहीं चलातीं। जब आउटपुट में मोशन दिखाना आवश्यक हो तो [HTML5 export](/slides/hi/net/export-to-html5/), एनिमेटेड GIF, या [video conversion](/slides/hi/net/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिए, [Html5Options.AnimateShapes](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animateshapes/) को सक्षम करें और आवश्यकता होने पर [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animatetransitions/) को सक्षम करें।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास, और मोशन-पाथ प्रभावों को समर्थन देता है, लेकिन हर PowerPoint प्रभाव समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/net/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्षित Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम प्रभाव और अन्य प्रस्तुति फ़ॉर्मैट से आयातित प्रभाव फ़ाइल में संरक्षित रह सकते हैं लेकिन PowerPoint, HTML5, या वीडियो में अलग तरीके से रेंडर हो सकते हैं। प्रभाव नाम पर केवल भरोसा करने के बजाय निर्यातित परिणाम की पुष्टि करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**ऐसे क्यों होता है कि एनीमेशन PowerPoint में दिखता है लेकिन PDF में नहीं दिखता?**

PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। जब मोशन को बनाए रखना आवश्यक हो तो HTML5, एनिमेटेड GIF, या वीडियो में निर्यात करें।

**एक प्रभाव वीडियो में अलग क्यों चलता है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है न कि मूल PowerPoint व्यवहार को संग्रहित करता है। कुछ उन्नत प्रभाव असमर्थित या अनुमानित होते हैं। समर्थित-प्रभाव तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z-order ओवरलैप नियंत्रित करता है, जबकि क्रम (sequence) क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि आपको अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।