---
title: ".NET में प्रस्तुतियों में आकार एनीमेशन लागू करें"
linktitle: "आकार एनीमेशन"
type: docs
weight: 60
url: /hi/net/shape-animation/
keywords:
- "आकार"
- "एनीमेशन"
- "प्रभाव"
- "एनिमेटेड आकार"
- "एनिमेटेड टेक्स्ट"
- "एनीमेशन जोड़ें"
- "एनीमेशन प्राप्त करें"
- "एनीमेशन निकालें"
- "प्रभाव जोड़ें"
- "प्रभाव प्राप्त करें"
- "प्रभाव निकालें"
- "प्रभाव ध्वनि"
- "एनीमेशन लागू करें"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन कैसे बनाएं और अनुकूलित करें, जानें। उल्लेखनीय बनें!"
---
## **परिचय**

एनिमेशन वह दृश्य प्रभाव हैं जिन्हें पाठ, चित्र, आकार, या [चार्ट](/slides/hi/net/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनके घटकों में जीवन डालते हैं।

## **प्रस्तुतियों में एनीमेशन का उपयोग क्यों करें?**

* सूचना के प्रवाह को नियंत्रित करना  
* महत्वपूर्ण बिंदुओं पर जोर देना  
* अपने दर्शकों में रुचि या भागीदारी बढ़ाना  
* सामग्री को पढ़ने, समझने या प्रोसेस करने में आसान बनाना  
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण भागों की ओर आकर्षित करना  

PowerPoint एनीमेशन और एनीमेशन इफ़ेक्ट्स के लिए कई विकल्प और उपकरण प्रदान करता है, जो **entrance**, **exit**, **emphasis**, और **motion paths** श्रेणियों में होते हैं।

## **Aspose.Slides में एनीमेशन**

* Aspose.Slides उन क्लासों और प्रकारों को प्रदान करता है जिनकी आपको एनीमेशन के साथ काम करने के लिए आवश्यकता होती है, जो [Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/) नेमस्पेस में स्थित हैं,  
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttype) एन्नुमरेशन के तहत **150 से अधिक एनीमेशन इफ़ेक्ट्स** प्रदान करता है। ये इफ़ेक्ट्स मूल रूप से वही (या समकक्ष) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनीमेशन लागू करें**

Aspose.Slides for .NET आपको किसी आकार के टेक्स्ट पर एनीमेशन लागू करने की अनुमति देता है।  

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें।  
4. टेक्स्ट को [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/textframe) में जोड़ें।  
5. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
6. एक एनीमेशन इफ़ेक्ट [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) में जोड़ें।  
7. वांछित मान से [TextAnimation.BuildType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/textanimation/properties/buildtype) प्रॉपर्टी को सेट करें, जो [BuildType Enumeration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype) से लिया गया है।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `Fade` इफ़ेक्ट AutoShape पर लागू करें और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // टेक्स्ट के साथ नया AutoShape जोड़ता है
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // तीन पैराग्राफ जोड़ता है ताकि पैराग्राफ-वार निर्माण के पास आगे बढ़ने के लिए कुछ हो।
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = sld.Timeline.MainSequence;

    // आकार पर Fade एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // आकार के टेक्स्ट को प्रथम स्तर के पैराग्राफों द्वारा एनीमेट करता है
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX फ़ाइल को डिस्क पर सहेजें
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

टेक्स्ट पर एनीमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph) पर भी एनीमेशन लागू कर सकते हैं। देखें [**एनिमेटेड टेक्स्ट**](/slides/hi/net/animated-text/)।

{{% /alert %}} 

## **PictureFrame पर एनीमेशन लागू करें**

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe) जोड़ें या प्राप्त करें।  
5. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
6. एक एनीमेशन इफ़ेक्ट [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe) में जोड़ें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `Fly` इफ़ेक्ट एक चित्र फ्रेम पर लागू करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
using (Presentation pres = new Presentation())
{
    // प्रस्तुति की इमेज कलेक्शन में जोड़ने के लिए इमेज लोड करता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में चित्र फ्रेम जोड़ता है
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // चित्र फ्रेम में बाएँ से Fly एनीमेशन प्रभाव जोड़ता है
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Shape पर एनीमेशन लागू करें**

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें।  
4. एक `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनीमेशन चलता है)।  
5. Bevel आकार पर इफ़ेक्ट्स की एक क्रम बनाएं।  
6. एक कस्टम `UserPath` बनाएं।  
7. `UserPath` पर ले जाने के कमांड जोड़ें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `PathFootball` (पाथ फुटबॉल) इफ़ेक्ट एक आकार पर लागू करें:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है।
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // मौजूदा आकार के लिए शुरुआत से PathFootball इफ़ेक्ट बनाता है।
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है।
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // किसी प्रकार का "button" बनाता है।
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // बटन के लिए इफ़ेक्ट्स की एक क्रम बनाता है।
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // एक कस्टम उपयोगकर्ता पथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक करने के बाद ही हिला जाएगा।
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // चूंकि बनाया गया पथ खाली है, इसलिए हिलाने के कमांड जोड़ता है।
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Shape पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

निम्न उदाहरण दिखाते हैं कि कैसे आप [ISequence](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/) इंटरफ़ेस के `GetEffectsByShape` मेथड का उपयोग करके किसी आकार पर लागू सभी एनीमेशन इफ़ेक्ट्स प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर आकार पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में आकारों पर एनीमेशन इफ़ेक्ट्स जोड़ना सीखा था। निम्न नमूना कोड दिखाता है कि कैसे `AnimExample_out.pptx` प्रस्तुति में पहली सामान्य स्लाइड के पहले आकार पर लागू इफ़ेक्ट्स प्राप्त किए जाएँ।

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // स्लाइड की मुख्य एनीमेशन क्रम प्राप्त करता है।
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // पहले स्लाइड पर पहला आकार प्राप्त करता है।
    IShape shape = firstSlide.Shapes[0];

    // आकार पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**उदाहरण 2: सभी एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं**

यदि कोई आकार सामान्य स्लाइड में प्लेसहोल्डर रखता है जो लेआउट स्लाइड या मास्टर स्लाइड पर स्थित है, और इन प्लेसहोल्डरों पर एनीमेशन इफ़ेक्ट्स जोड़े गये हैं, तो स्लाइड शो के दौरान आकार के सभी इफ़ेक्ट्स चलेंगे, जिसमें इन प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास `sample.pptx` नामक एक PowerPoint प्रस्तुति है, जिसमें केवल एक फुटर आकार है जिसमें टेक्स्ट "Made with Aspose.Slides" है और **Random Bars** इफ़ेक्ट उस आकार पर लागू है।

![Slide shape animation effect](slide-shape-animation.png)

मान लीजिए **Split** इफ़ेक्ट लेआउट स्लाइड पर फुटर प्लेसहोल्डर पर लागू है।

![Layout shape animation effect](layout-shape-animation.png)

और अंत में, **Fly In** इफ़ेक्ट मास्टर स्लाइड पर फुटर प्लेसहोल्डर पर लागू है।

![Master shape animation effect](master-shape-animation.png)

निम्न नमूना कोड दिखाता है कि कैसे आप [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस के `GetBasePlaceholder` मेथड का उपयोग करके आकार के प्लेसहोल्डर तक पहुंचें और फुटर आकार पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डरों से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // सामान्य स्लाइड पर आकार के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **एनीमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for .NET आपको एनीमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पेन और विस्तारित मेनू है:

![example1_image](shape-animation.png)

ये PowerPoint Timing और [Effect.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/properties/timing) प्रॉपर्टीज़ के बीच संबंध हैं:
- PowerPoint Timing **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/triggertype) प्रॉपर्टी से मेल खाती है।  
- PowerPoint Timing **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/duration) प्रॉपर्टी से मेल खाती है। एनीमेशन की अवधि (सेकंड में) वह कुल समय है जो एनीमेशन को एक चक्र पूरा करने में लेता है।  
- PowerPoint Timing **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/triggerdelaytime) प्रॉपर्टी से मेल खाती है।  
- PowerPoint Timing **Repeat** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:  
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatcount) प्रॉपर्टी जो इफ़ेक्ट दोहराए जाने की *संख्या* को दर्शाती है;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilendslide) फ़्लैग जो निर्दिष्ट करता है कि इफ़ेक्ट स्लाइड के अंत तक दोहराया जाए;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilnextclick) फ़्लैग जो निर्दिष्ट करता है कि इफ़ेक्ट अगले क्लिक तक दोहराया जाए।  
- PowerPoint Timing **Rewind when done playing** चेकबॉक्स [Effect.Timing.Rewind](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/rewind/) प्रॉपर्टी से मेल खाता है।  

यहाँ आप Effect Timing प्रॉपर्टीज़ कैसे बदलते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।  
2. आवश्यक [Effect.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/properties/timing) प्रॉपर्टीज़ के नए मान सेट करें।  
3. संशोधित PPTX फ़ाइल को सहेजें।  

यह C# कोड ऑपरेशन दिखाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है।
    IEffect effect = sequence[0];

    // इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू होने के लिए सेट करता है
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // इफ़ेक्ट की अवधि बदलता है
    effect.Timing.Duration = 3f;

    // इफ़ेक्ट का TriggerDelayTime बदलता है
    effect.Timing.TriggerDelayTime = 0.5f;

    // यदि इफ़ेक्ट का Repeat मान "none" है
    if (effect.Timing.RepeatCount == 1f)
    {
        // इफ़ेक्ट का Repeat "अगली क्लिक तक" में बदलता है
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // इफ़ेक्ट का Repeat "स्लाइड के अंत तक" में बदलता है
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // इफ़ेक्ट का Rewind चालू करता है
        effect.Timing.Rewind = true;
    
    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **एनीमेशन इफ़ेक्ट साउंड**

Aspose.Slides आपको एनीमेशन इफ़ेक्ट्स में साउंड के साथ काम करने के लिए ये प्रॉपर्टीज़ प्रदान करता है:  
- [IEffect.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/stopprevioussound/)  

### **एनीमेशन इफ़ेक्ट साउंड जोड़ें**

यह C# कोड दर्शाता है कि कैसे एनीमेशन इफ़ेक्ट साउंड जोड़ें और अगले इफ़ेक्ट के शुरू होने पर उसे रोकें:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// स्लाइड की मुख्य क्रम प्राप्त करता है।
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
	IEffect firstEffect = sequence[0];

	// इफ़ेक्ट के लिए "No Sound" की जाँच करता है
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
		firstEffect.Sound = effectSound;
	}

	// स्लाइड की पहली इंटरैक्टिव क्रम प्राप्त करता है।
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// इफ़ेक्ट "Stop previous sound" फ़्लैग सेट करता है
	interactiveSequence[0].StopPreviousSound = true;

	// PPTX फ़ाइल को डिस्क पर लिखता है
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **एनीमेशन इफ़ेक्ट साउंड निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. इफ़ेक्ट्स की मुख्य क्रम प्राप्त करें।  
4. प्रत्येक एनीमेशन इफ़ेक्ट में एंबेडेड [Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/sound/) निकालें।  

यह C# कोड दिखाता है कि कैसे एनीमेशन इफ़ेक्ट में एंबेडेड साउंड निकाला जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // इफ़ेक्ट की ध्वनि को बाइट एरे में निकालता है।
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **एनीमेशन के बाद**

Aspose.Slides for .NET आपको एनीमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पेन और विस्तारित मेनू है:

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/afteranimationtype/) प्रॉपर्टी जो After animation प्रकार को वर्णित करती है:  
  * PowerPoint **More Colors** [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाती है;  
  * PowerPoint **Don't Dim** आइटम [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है (डिफ़ॉल्ट after animation प्रकार);  
  * PowerPoint **Hide After Animation** आइटम [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है;  
  * PowerPoint **Hide on Next Mouse Click** आइटम [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है;  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/afteranimationcolor/) प्रॉपर्टी जो After animation रंग फ़ॉर्मेट को परिभाषित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को अन्य में बदलते हैं, तो after animation रंग साफ़ हो जाएगा।

यह C# कोड दिखाता है कि कैसे after animation इफ़ेक्ट बदला जाए:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // after animation प्रकार को Color में बदलता है
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // after animation डिम रंग सेट करता है
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides आपको एनीमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए ये प्रॉपर्टीज़ प्रदान करता है:  

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/animatetexttype/) जो इफ़ेक्ट के animate text प्रकार को वर्णित करती है। आकार का टेक्स्ट एनीमेट किया जा सकता है:  
  - All at once ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
  - By word ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
  - By letter ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) जो एनीमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी को दर्शाता है।  

यहाँ आप Effect Animate text प्रॉपर्टीज़ कैसे बदल सकते हैं:

1. [Apply](#apply-animation-to-shape) या एनीमेशन इफ़ेक्ट प्राप्त करें।  
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itextanimation/buildtype/) प्रॉपर्टी को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype/) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।  
3. नई मानों के साथ [IEffect.AnimateTextType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/animatetexttype/) और [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) प्रॉपर्टीज़ सेट करें।  
4. संशोधित PPTX फ़ाइल को सहेजें।  

यह C# कोड ऑपरेशन दिखाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// इफ़ेक्ट के Text animation प्रकार को "As One Object" में बदलता है
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// इफ़ेक्ट के Animate text प्रकार को "By word" में बदलता है
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
	firstEffect.DelayBetweenTextParts = 20f;

	// PPTX फ़ाइल को डिस्क पर लिखता है
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### वेब पर प्रेजेंटेशन प्रकाशित करते समय एनीमेशन को संरक्षित रखने के लिए मैं क्या कर सकता हूँ?

[Export to HTML5](/slides/hi/net/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animateshapes/) और [transition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animatetransitions/) एनीमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनीमेशन नहीं चलाता, जबकि HTML5 करता है।

### आकारों के z-order (लेयर क्रम) को बदलने से एनीमेशन पर क्या प्रभाव पड़ता है?

एनीमेशन और ड्रॉइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट आने/जाने के समय और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/zorderposition/) तय करता है कि क्या क्या को ढँकेगा। दृश्य परिणाम उनका संयोजन तय करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के इफ़ेक्ट-और-शेप मॉडल में भी यही तर्क लागू होता है।)

### कुछ विशेष इफ़ेक्ट्स के लिए एनीमेशन को वीडियो में बदलते समय क्या सीमाएँ हैं?

आम तौर पर, [animations are supported](/slides/hi/net/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशिष्ट इफ़ेक्ट्स का रेंडरिंग अलग हो सकता है। यह सलाह दी जाती है कि आप जिन इफ़ेक्ट्स का उपयोग करते हैं और जिस लाइब्रेरी संस्करण का, उसके साथ परीक्षण करें।