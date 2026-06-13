---
title: .NET में प्रस्तुतियों में आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/net/shape-animation/
keywords:
- आकार
- एनीमेशन
- इफ़ेक्ट
- एनिमेटेड आकार
- एनिमेटेड टेक्स्ट
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- इफ़ेक्ट जोड़ें
- इफ़ेक्ट प्राप्त करें
- इफ़ेक्ट निकालें
- इफ़ेक्ट साउंड
- एनीमेशन लागू करें
- PowerPoint
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint प्रस्तुतियों में आकार एनीमेशन बनाना और कस्टमाइज़ करना सीखें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव हैं जिन्हें टेक्स्ट, छवियों, आकारों, या [चार्ट्स](/slides/hi/net/animated-charts/) पर लागू किया जा सकता है। ये प्रस्तुतियों या उनके तत्वों को जीवंत बनाते हैं। 

## **प्रस्तुतियों में एनिमेशन का उपयोग क्यों करें?**

एनिमेशन का उपयोग करके आप 

* सूचना के प्रवाह को नियंत्रित करें  
* महत्वपूर्ण बिंदुओं पर जोर दें  
* अपने दर्शकों की रुचि या भागीदारी बढ़ाएँ  
* सामग्री को पढ़ने, समझने या प्रोसेस करने में आसान बनाएँ  
* अपने पाठकों या दर्शकों का ध्यान प्रस्तुति में महत्वपूर्ण भागों की ओर आकर्षित करें  

PowerPoint एनिमेशन और एनिमेशन इफ़ेक्ट्स के लिए कई विकल्प और टूल्स प्रदान करता है, जो **प्रवेश**, **निकास**, **जोर**, और **गति पथ** श्रेणियों में विभाजित हैं। 

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides उन क्लासेज़ और प्रकारों को प्रदान करता है जिनकी आपको एनिमेशन के साथ काम करने के लिए आवश्यकता है, जो [Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/) नेमस्पेस के अंतर्गत हैं,  
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effecttype) एन्उमरेशन के तहत **150 से अधिक एनिमेशन इफ़ेक्ट्स** प्रदान करता है। ये इफ़ेक्ट्स मूलतः वही (या समकक्ष) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।  

## **टेक्स्टबॉक्स पर एनिमेशन लागू करें**

Aspose.Slides for .NET आपको आकार में टेक्स्ट पर एनिमेशन लागू करने की अनुमति देता है। 

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास का उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें।  
4. टेक्स्ट को [IAutoShape.TextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape/properties/textframe) में जोड़ें।  
5. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
6. [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) पर एक एनिमेशन इफ़ेक्ट जोड़ें।  
7. [TextAnimation.BuildType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/textanimation/properties/buildtype) प्रॉपर्टी को [BuildType Enumeration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype) से मान सेट करें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `Fade` इफ़ेक्ट को AutoShape पर लागू किया जाता है और टेक्स्ट एनीमेशन को *By 1st Level Paragraphs* मान पर सेट किया जाता है:

```c#
// एक प्रस्तुति क्लास का उदाहरण बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // टेक्स्ट के साथ नया AutoShape जोड़ता है
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = sld.Timeline.MainSequence;

    // आकार में Fade एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // आकार के टेक्स्ट को प्रथम स्तर के पैराग्राफ द्वारा एनीमेट करता है
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

टेक्स्ट पर एनिमेशन लागू करने के अतिरिक्त, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/net/aspose.slides/iparagraph) पर भी एनिमेशन लागू कर सकते हैं। देखें [**एनिमेटेड टेक्स्ट**](/slides/hi/net/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनिमेशन लागू करें**

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास का उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe) को स्लाइड पर जोड़ें या प्राप्त करें।  
5. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
6. [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe) पर एक एनिमेशन इफ़ेक्ट जोड़ें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `Fly` इफ़ेक्ट को एक पिक्चर फ़्रेम पर लागू किया जाता है:

```c#
// एक प्रस्तुति क्लास का उदाहरण बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation pres = new Presentation())
{
    // प्रस्तुति इमेज संग्रह में जोड़ने के लिए चित्र लोड करता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में पिक्चर फ़्रेम जोड़ता है
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // स्लाइड की मुख्य क्रम प्राप्त करता है।
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // पिक्चर फ़्रेम में बाएँ से उड़ान एनीमेशन इफ़ेक्ट जोड़ता है
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **आकार पर एनिमेशन लागू करें**

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास का उदाहरण बनाएँ।  
2. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें।  
4. एक `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/iautoshape) जोड़ें (जब इस वस्तु पर क्लिक किया जाता है, तो एनिमेशन चलाया जाता है)।  
5. Bevel आकार पर इफ़ेक्ट्स की एक श्रृंखला बनाएं।  
6. एक कस्टम `UserPath` बनाएँ।  
7. `UserPath` पर ले जाने के लिए कमांड जोड़ें।  
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दर्शाता है कि कैसे `PathFootball` (पाथ फुटबॉल) इफ़ेक्ट को एक आकार पर लागू किया जाता है:

```c#
// एक Presentation क्लास का उदाहरण बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // मौजूदा आकार के लिए प्रारंभ से PathFootball इफ़ेक्ट बनाता है।
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है।
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // किसी प्रकार का “बटन” बनाता है।
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // बटन के लिये इफ़ेक्ट्स की एक क्रम बनाता है।
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // एक कस्टम उपयोगकर्ता पथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने के बाद ही चलेगा।
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // चूंकि बनाया गया पथ खाली है इसलिए चलने के लिए कमांड जोड़ता है।
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

## **आकार पर लागू किए गए एनिमेशन इफ़ेक्ट्स प्राप्त करें**

निम्न उदाहरण दर्शाते हैं कि कैसे आप [ISequence](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/isequence/) इंटरफ़ेस की `GetEffectsByShape` मेथड का उपयोग करके किसी आकार पर लागू सभी एनिमेशन इफ़ेक्ट्स प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर आकार पर लागू एनिमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने सीखा था कि PowerPoint प्रस्तुतियों में आकारों पर एनिमेशन इफ़ेक्ट्स कैसे जोड़ें। निम्न नमूना कोड दर्शाता है कि कैसे `AnimExample_out.pptx` प्रस्तुति में पहली सामान्य स्लाइड के पहले आकार पर लागू इफ़ेक्ट्स प्राप्त किए जाएँ।

```c#
using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // स्लाइड की मुख्य एनीमेशन क्रम प्राप्त करता है।
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // पहली स्लाइड पर पहला आकार प्राप्त करता है।
    IShape shape = firstSlide.Shapes[0];

    // आकार पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**उदाहरण 2: सभी एनिमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें प्लेसहोल्डर से विरासत में मिला हुआ भी शामिल है**

यदि एक सामान्य स्लाइड पर कोई आकार ऐसे प्लेसहोल्डर रखता है जो लेआउट स्लाइड और/या मास्टर स्लाइड पर हैं, और इन प्लेसहोल्डर पर एनिमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान आकार के सभी इफ़ेक्ट्स चलाए जाएंगे, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास एक PowerPoint प्रस्तुति फ़ाइल `sample.pptx` है, जिसमें एक स्लाइड केवल एक फुटर आकार रखती है, जिसकी टेक्स्ट "Made with Aspose.Slides" है और उस आकार पर **Random Bars** इफ़ेक्ट लागू किया गया है।

![स्लाइड आकार एनिमेशन इफ़ेक्ट](slide-shape-animation.png)

मान लीजिए कि **Split** इफ़ेक्ट लेआउट स्लाइड पर फुटर प्लेसहोल्डर पर लागू किया गया है।

![लेआउट आकार एनिमेशन इफ़ेक्ट](layout-shape-animation.png)

अंत में, **Fly In** इफ़ेक्ट मास्टर स्लाइड पर फुटर प्लेसहोल्डर पर लागू किया गया है।

![मास्टर आकार एनिमेशन इफ़ेक्ट](master-shape-animation.png)

निम्न नमूना कोड दर्शाता है कि कैसे आप [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape/) इंटरफ़ेस की `GetBasePlaceholder` मेथड का उपयोग करके आकार प्लेसहोल्डर तक पहुंचें और फुटर आकार पर लागू एनिमेशन इफ़ेक्ट्स प्राप्त करें, जिसमें लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // सामान्य स्लाइड पर आकार के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}
```
```cs
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

## **एनिमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for .NET आपको एक एनिमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पेन और विस्तारित मेन्यू है:

![उदाहरण1_छवि](shape-animation.png)

इनमें PowerPoint टाइमिंग और [Effect.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/properties/timing) प्रॉपर्टीज़ के बीच सम्बंध हैं:
- PowerPoint टाइमिंग **Start** ड्रॉप-डाउन सूची [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/triggertype) प्रॉपर्टी के साथ मेल खाती है। 
- PowerPoint टाइमिंग **Duration** [Effect.Timing.Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/duration) प्रॉपर्टी से मेल खाती है। एनिमेशन की अवधि (सेकंड में) वह कुल समय है जो एनिमेशन को एक चक्र पूरा करने में लेता है। 
- PowerPoint टाइमिंग **Delay** [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/properties/triggerdelaytime) प्रॉपर्टी से मेल खाती है। 
- PowerPoint टाइमिंग **Repeat** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है: 
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatcount) प्रॉपर्टी जो इफ़ेक्ट के *संख्या* वर्णन करती है;  
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilendslide) फ्लैग जो यह निर्दिष्ट करता है कि इफ़ेक्ट स्लाइड के अंत तक दोहराया जाए;  
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/repeatuntilnextclick) फ्लैग जो यह निर्दिष्ट करता है कि इफ़ेक्ट अगले क्लिक तक दोहराया जाए।  
- PowerPoint टाइमिंग **Rewind when done playing** चेकबॉक्स [Effect.Timing.Rewind](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itiming/rewind/) प्रॉपर्टी से मेल खाता है। 

इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनिमेशन इफ़ेक्ट प्राप्त करें।  
2. आवश्यक [Effect.Timing](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/properties/timing) प्रॉपर्टीज़ के नए मान सेट करें।  
3. संशोधित PPTX फ़ाइल को सहेजें।  

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // स्लाइड की मुख्य क्रम प्राप्त करता है.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है.
    IEffect effect = sequence[0];

    // इफ़ेक्ट का TriggerType बदलकर क्लिक पर शुरू होने के लिए करता है
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // इफ़ेक्ट की अवधि बदलता है
    effect.Timing.Duration = 3f;

    // इफ़ेक्ट का TriggerDelayTime बदलता है
    effect.Timing.TriggerDelayTime = 0.5f;

    // यदि इफ़ेक्ट का Repeat मान "none" है
    if (effect.Timing.RepeatCount == 1f)
    {
        // इफ़ेक्ट के Repeat को "Until Next Click" में बदलता है
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // इफ़ेक्ट के Repeat को "Until End of Slide" में बदलता है
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // इफ़ेक्ट का Rewind चालू करता है
        effect.Timing.Rewind = true;
    
    // PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **एनिमेशन इफ़ेक्ट साउंड**

Aspose.Slides इन प्रॉपर्टीज़ को प्रदान करता है जिससे आप एनिमेशन इफ़ेक्ट्स में साउंड के साथ काम कर सकते हैं: 
- [IEffect.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/sound/)  
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/stopprevioussound/) 

### **एनिमेशन इफ़ेक्ट साउंड जोड़ें**

यह C# कोड दर्शाता है कि कैसे एक एनिमेशन इफ़ेक्ट साउंड जोड़ें और अगले इफ़ेक्ट शुरू होने पर उसे रोकें:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// प्रस्तुति ऑडियो संग्रह में ऑडियो जोड़ता है
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// स्लाइड की मुख्य क्रम प्राप्त करता है।
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
	IEffect firstEffect = sequence[0];

	// इफ़ेक्ट को "नो साउंड" के लिए जाँचता है
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// पहले इफ़ेक्ट के लिए साउंड जोड़ता है
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

### **एनिमेशन इफ़ेक्ट साउंड निकालें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।  
2. स्लाइड का संदर्भ इंडेक्स के माध्यम से प्राप्त करें।  
3. इफ़ेक्ट्स की मुख्य श्रृंखला प्राप्त करें।  
4. प्रत्येक एनिमेशन इफ़ेक्ट में एम्बेडेड [Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/effect/sound/) निकालें।  

यह C# कोड दर्शाता है कि कैसे एक एनिमेशन इफ़ेक्ट में एम्बेडेड साउंड को निकाला जाए:

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // स्लाइड की मुख्य क्रम प्राप्त करता है.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // इफ़ेक्ट साउंड को बाइट ऐरे में निकालता है
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **एनिमेशन के बाद**

Aspose.Slides for .NET आपको एक एनिमेशन इफ़ेक्ट के After animation प्रॉपर्टी को बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन इफ़ेक्ट पेन और विस्तारित मेन्यू है:

![उदाहरण1_छवि](shape-after-animation.png)

PowerPoint इफ़ेक्ट **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है: 

- [IEffect.AfterAnimationType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/afteranimationtype/) प्रॉपर्टी जो After animation प्रकार को वर्णित करती है :
  * PowerPoint **More Colors** का चयन [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है;  
  * PowerPoint **Don't Dim** विकल्प [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है (डिफ़ॉल्ट after animation प्रकार);  
  * PowerPoint **Hide After Animation** विकल्प [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है;  
  * PowerPoint **Hide on Next Mouse Click** विकल्प [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाता है;  
- [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/afteranimationcolor/) प्रॉपर्टी जो after animation का कलर फ़ॉर्मेट निर्धारित करती है। यह प्रॉपर्टी [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/afteranimationtype/) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को किसी अन्य में बदलते हैं, तो after animation कलर साफ़ हो जाएगा।  

यह C# कोड दर्शाता है कि कैसे after animation इफ़ेक्ट को बदलें:

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // after animation प्रकार को Color पर बदलता है
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // after animation डिम रंग सेट करता है
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // PPTX फ़ाइल को डिस्क पर लिखता है
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **टेक्स्ट एनीमेट करें**

Aspose.Slides इन प्रॉपर्टीज़ को प्रदान करता है जिससे आप किसी एनिमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम कर सकें:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/animatetexttype/) जो इफ़ेक्ट के animate text प्रकार को वर्णित करता है। आकार का टेक्स्ट एनीमेट किया जा सकता है:
  - सभी एक साथ ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
  - शब्द दर शब्द ([AnimateTextType.ByWord](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
  - अक्षर दर अक्षर ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/animatetexttype/) प्रकार)  
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/ieffect/delaybetweentextparts/) एनिमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी सेट करता है। एक सकारात्मक मान इफ़ेक्ट की अवधि का प्रतिशत दर्शाता है। एक नकारात्मक मान सेकंड में देरी दर्शाता है।  

इफ़ेक्ट Animate text प्रॉपर्टीज़ को बदलने का तरीका यह है:

1. [Apply](#apply-animation-to-shape) या एनिमेशन इफ़ेक्ट प्राप्त करें।  
2. [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/itextanimation/buildtype/) प्रॉपर्टी को [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/net/aspose.slides.animation/buildtype/) मान पर सेट करें ताकि *By Paragraphs* एनीमेशन मोड बंद हो जाए।  
3. [IEffect.AnimateTextType] और [IEffect.DelayBetweenTextParts] प्रॉपर्टीज़ के नए मान सेट करें।  
4. संशोधित PPTX फ़ाइल को सहेजें।  

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है.
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

**मैं कैसे सुनिश्चित करूँ कि वेब पर प्रस्तुति प्रकाशित करने पर एनिमेशन बना रहे?**

[Export to HTML5](/slides/hi/net/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animateshapes/) और [transition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/animatetransitions/) एनिमेशन के लिए ज़िम्मेदार हैं। साधारण HTML स्लाइड एनिमेशन नहीं चलाता, जबकि HTML5 करता है।

**आकारों के z-order (लेयर क्रम) को बदलने से एनिमेशन पर कैसे प्रभाव पड़ता है?**

एनिमेशन और ड्राइंग क्रम स्वतंत्र होते हैं: एक इफ़ेक्ट दिखने/गायब होने के समय और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/zorderposition/) यह तय करता है कि क्या क्या कवर करता है। दृश्यमान परिणाम उनका संयोजन निर्धारित करता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides के इफ़ेक्ट-और-आकार मॉडल भी वही तर्क अपनाता है।)

**क्या कुछ इफ़ेक्ट्स को वीडियो में बदलते समय सीमाएँ हैं?**

सामान्यतः, [animations are supported](/slides/hi/net/convert-powerpoint-to-video/), लेकिन दुर्लभ मामलों या विशेष इफ़ेक्ट्स में अलग रेंडरिंग हो सकती है। यह सलाह दी जाती है कि आप उपयोग किए गए इफ़ेक्ट्स और लाइब्रेरी संस्करण के साथ परीक्षण करें।