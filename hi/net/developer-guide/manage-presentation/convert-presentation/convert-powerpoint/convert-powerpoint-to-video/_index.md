---
title: PowerPoint प्रस्तुतियों को .NET में वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/net/convert-powerpoint-to-video/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
- PowerPoint से वीडियो
- प्रस्तुति से वीडियो
- PPT से वीडियो
- PPTX से वीडियो
- PowerPoint से MP4
- प्रस्तुति से MP4
- PPT से MP4
- PPTX से MP4
- PPT को MP4 के रूप में सहेजें
- PPTX को MP4 के रूप में सहेजें
- PPT को MP4 में निर्यात करें
- PPTX को MP4 में निर्यात करें
- वीडियो रूपांतरण
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: ".NET में PowerPoint प्रस्तुतियों को वीडियो में कैसे बदलें सीखें। अपने कार्यप्रवाह को सरल बनाने के लिए नमूना C# कोड और स्वचालन तकनीकों की खोज करें।"
---
## **परिचय**

अपनी PowerPoint या OpenDocument प्रस्तुति को वीडियो में बदलकर आप प्राप्त करते हैं:

**बढ़ी हुई पहुँच:** सभी डिवाइस, प्लेटफ़ॉर्म की परवाह किए बिना, डिफ़ॉल्ट रूप से वीडियो प्लेयर से सुसज्जित होते हैं, जिससे उपयोगकर्ताओं के लिए पारंपरिक प्रस्तुति अनुप्रयोगों की तुलना में वीडियो खोलना या चलाना आसान हो जाता है।

**व्यापक पहुंच:** वीडियो आपको बड़ा दर्शकों तक पहुँचने और जानकारी को अधिक आकर्षक स्वरूप में प्रस्तुत करने में सक्षम बनाते हैं। सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग अन्य रूपों की तुलना में वीडियो सामग्री देखना और उपभोग करना तरजीह देते हैं, जिससे आपका संदेश अधिक प्रभावशाली बनता है।

{{% alert color="info" %}} 
हमारे [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hi/video) को देखें क्योंकि यह यहाँ वर्णित प्रक्रिया का एक लाइव और प्रभावी कार्यान्वयन प्रदान करता है।
{{% /alert %}} 

Aspose.Slides for .NET में, हमने प्रस्तुतियों को वीडियो में परिवर्तित करने के लिए समर्थन लागू किया है।

* Aspose.Slides for .NET का उपयोग करके निर्दिष्ट फ्रेम दर (FPS) पर प्रस्तुति स्लाइड्स से फ्रेम बनाएं।
* फिर, ffmpeg जैसे तृतीय‑पक्ष यूटिलिटी का उपयोग करके इन फ्रेमों को वीडियो में संकलित करें।

## **PowerPoint प्रस्तुति को वीडियो में बदलें**

1. अपने प्रोजेक्ट में Aspose.Slides और FFMpegCore लाइब्रेरी जोड़ने के लिए `dotnet add package` कमांड का उपयोग करें:
   * run `dotnet add package Aspose.Slides.NET --version 22.11.0`
   * run `dotnet add package FFMpegCore --version 4.8.0`
2. ffmpeg को [यहां](https://ffmpeg.org/download.html) से डाउनलोड करें।
3. FFMpegCore को डाउनलोड किए गए ffmpeg का पाथ निर्दिष्ट करना आवश्यक है (उदाहरण के लिए, "C:\tools\ffmpeg" पर निकाला गया):  
```cs
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });
```
4. PowerPoint-से-वीडियो रूपांतरण कोड चलाएँ।

यह C# कोड दर्शाता है कि कैसे एक प्रस्तुति (जिसमें एक शेप और दो एनीमेशन इफ़ेक्ट हैं) को वीडियो में परिवर्तित किया जाए:

```c#
using System.Collections.Generic;
using Aspose.Slides;
using FFMpegCore; // पहले हमने C:\tools\ffmpeg से निकाले गए FFmpeg बाइनरी का उपयोग करेगा।
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // एक स्माइली आकार जोड़ें और फिर उसे एनीमेट करें।
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };
        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // फ़्रेमों को webm वीडियो में परिवर्तित करें।
    FFMpeg.JoinImageSequence("smile.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **वीडियो प्रभाव**

Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुति को वीडियो में बदलते समय आप आउटपुट की दृश्य गुणवत्ता को बढ़ाने के लिए विभिन्न वीडियो प्रभाव लागू कर सकते हैं। ये प्रभाव आपको अंतिम वीडियो में स्लाइड्स की उपस्थिति को स्मूथ ट्रांज़िशन, एनीमेशन और अन्य दृश्य तत्व जोड़कर नियंत्रित करने की सुविधा देते हैं। इस अनुभाग में उपलब्ध वीडियो प्रभाव विकल्पों की व्याख्या की गई है और उन्हें लागू करने का तरीका दिखाया गया है।

{{% alert color="info" %}} 
देखें:
- [Enhancing PowerPoint Presentations with Animations in C#](https://docs.aspose.com/slides/hi/net/powerpoint-animation/)
- [Shape Animation](https://docs.aspose.com/slides/hi/net/shape-animation/)
- [Apply Shape Effects in PowerPoint Using C#](https://docs.aspose.com/slides/hi/net/shape-effect/)
{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं — और वीडियो के लिए भी यही काम करते हैं। चलिए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SlideShow;

using (Presentation presentation = new Presentation())
{
    // एक स्माइली आकार जोड़ें और उसे एनीमेट करें (ऊपर कोड देखें).

    // एक नई स्लाइड जोड़ें और एक एनीमेटेड ट्रांज़िशन जोड़ें.
    ISlide newSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
    newSlide.Background.Type = BackgroundType.OwnBackground;
    newSlide.Background.FillFormat.FillType = FillType.Solid;
    newSlide.Background.FillFormat.SolidFillColor.Color = Color.Indigo;
    newSlide.SlideShowTransition.Type = TransitionType.Push;
}
```

Aspose.Slides टेक्स्ट एनीमेशन भी समर्थन करता है। इस उदाहरण में, हम वस्तुओं पर पैराग्राफ़ को एनीमेट करते हैं ताकि वे एक के बाद एक दिखाई दें, प्रत्येक के बीच एक‑सेकंड की देरी के साथ:

```c#
using System.Collections.Generic;
using Aspose.Slides.Export;
using Aspose.Slides;
using FFMpegCore;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // पाठ और एनीमेशन जोड़ें.
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.Portions.Add(new Portion("Aspose Slides for .NET"));
    Paragraph para2 = new Paragraph();
    para2.Portions.Add(new Portion("Convert a PowerPoint presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.Portions.Add(new Portion("paragraph by paragraph"));
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    autoShape.TextFrame.Paragraphs.Add(new Paragraph());

    IEffect effect1 = slide.Timeline.MainSequence.AddEffect(
        para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect2 = slide.Timeline.MainSequence.AddEffect(
        para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect3 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    IEffect effect4 = slide.Timeline.MainSequence.AddEffect(
        para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.Timing.TriggerDelayTime = 1f;
    effect2.Timing.TriggerDelayTime = 1f;
    effect3.Timing.TriggerDelayTime = 1f;
    effect4.Timing.TriggerDelayTime = 1f;

    const int Fps = 33;
    List<string> frames = new List<string>();

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, Fps))
    {
        player.FrameTick += (sender, args) =>
        {
            string frame = $"frame_{(sender.FrameIndex):D4}.png";
            args.GetFrame().Save(frame);
            frames.Add(frame);
        };

        animationsGenerator.Run(presentation.Slides);
    }

    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"c:\tools\ffmpeg\bin" });

    // फ़्रेमों को webm वीडियो में परिवर्तित करें.
    FFMpeg.JoinImageSequence("text_animation.webm", Fps, frames.Select(frame => ImageInfo.FromPath(frame)).ToArray());
}
```

## **वीडियो रूपांतरण क्लासेस**

PowerPoint‑से‑वीडियो रूपांतरण कार्यों को सक्षम करने के लिए, Aspose.Slides for .NET निम्नलिखित क्लासेस प्रदान करता है: [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/net/aspose.slides.export/presentationanimationsgenerator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/net/aspose.slides.export/presentationplayer/)।

`PresentationAnimationsGenerator` आपको वीडियो (जो बाद में बनाया जाएगा) के लिए फ्रेम आकार और FPS (फ़्रेम प्रति सेकंड) मान अपने कंस्ट्रक्टर के माध्यम से सेट करने देता है। यदि आप एक प्रस्तुति का इंस्टेंस पास करते हैं, तो उसकी `Presentation.SlideSize` उपयोग की जाएगी और यह उन एनीमेशनों को उत्पन्न करता है जिन्हें [PresentationPlayer](https://reference.aspose.com/slides/hi/net/aspose.slides.export/presentationplayer/) उपयोग करता है।

जब एनीमेशन उत्पन्न होते हैं, तो प्रत्येक क्रमिक एनीमेशन के लिए `NewAnimation` इवेंट ट्रिगर होता है, जिसमें एक [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipresentationanimationplayer/) पैरामीटर होता है। यह क्लास व्यक्तिगत एनीमेशन के प्लेयर को दर्शाती है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipresentationanimationplayer/) के साथ काम करने के लिए आप [Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipresentationanimationplayer/duration/) प्रॉपर्टी (जो एनीमेशन की कुल अवधि देती है) और [SetTimePosition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipresentationanimationplayer/settimeposition/) मेथड का उपयोग करते हैं। प्रत्येक एनीमेशन पोजिशन *0 से अवधि* की सीमा में सेट किया जाता है, और `GetFrame` मेथड तब उस समय बिंदु पर एनीमेशन की स्थिति को दर्शाने वाला Bitmap लौटाता है।

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // एक स्माइली आकार जोड़ें और उसे एनीमेट करें.
    IAutoShape smile = slide.Shapes.AddAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);

    IEffect effectIn = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);

    IEffect effectOut = slide.Timeline.MainSequence.AddEffect(
        smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);

    effectIn.Timing.Duration = 2f;
    effectOut.PresetClassType = EffectPresetClassType.Exit;

    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    {
        animationsGenerator.NewAnimation += animationPlayer =>
        {
            Console.WriteLine($"Total animation duration: {animationPlayer.Duration}");

            animationPlayer.SetTimePosition(0);        // प्रारम्भिक एनीमेशन स्थिति.
            IImage image = animationPlayer.GetFrame(); // प्रारम्भिक एनीमेशन स्थिति छवि.

            animationPlayer.SetTimePosition(animationPlayer.Duration); // एनीमेशन की अंतिम स्थिति.
            IImage lastImage = animationPlayer.GetFrame();             // एनीमेशन का अंतिम फ्रेम.
            lastImage.Save("last.png");
        };
    }
}
```

सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/net/aspose.slides.export/presentationplayer/) क्लास उपयोग की जाती है। यह क्लास अपने कंस्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/net/aspose.slides.export/presentationanimationsgenerator/) इंस्टेंस और एक FPS मान लेती है, और फिर सभी एनीमेशन को चलाने के लिए `FrameTick` इवेंट को कॉल करती है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("animated.pptx"))
{
    using (var animationsGenerator = new PresentationAnimationsGenerator(presentation))
    using (var player = new PresentationPlayer(animationsGenerator, 33))
    {
        player.FrameTick += (sender, args) =>
        {
            args.GetFrame().Save($"frame_{sender.FrameIndex}.png");
        };
        animationsGenerator.Run(presentation.Slides);
    }
}
```

उसके बाद उत्पन्न फ्रेमों को संकलित करके एक वीडियो बनाया जा सकता है। देखें [Convert a PowerPoint Presentation to Video](/slides/hi/net/convert-powerpoint-to-video/#convert-a-powerpoint-presentation-to-video) अनुभाग।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

PowerPoint प्रस्तुति को वीडियो में बदलते समय यह समझना महत्वपूर्ण है कि किन एनीमेशन और इफ़ेक्ट्स का आउटपुट में समर्थन है। Aspose.Slides फ़ेड, फ़्लाई‑इन, ज़ूम, स्पिन जैसे सामान्य प्रवेश, निकास और ज़ोर इफ़ेक्ट्स की विस्तृत श्रृंखला का समर्थन करता है। हालांकि, कुछ उन्नत या कस्टम एनीमेशन पूरी तरह से संरक्षित नहीं हो सकते या अंतिम वीडियो में अलग दिख सकते हैं। यह अनुभाग समर्थित एनीमेशन और इफ़ेक्ट्स का सार प्रस्तुत करता है।

**प्रवेश**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**ज़ोर**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**निकास**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**मूवमेंट पाथ**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **समर्थित स्लाइड ट्रांज़िशन इफ़ेक्ट्स**

स्लाइड ट्रांज़िशन इफ़ेक्ट्स वीडियो में स्लाइडों के बीच स्मूथ और दृश्य रूप से आकर्षक बदलाव बनाने में महत्वपूर्ण भूमिका निभाते हैं। Aspose.Slides for .NET कई सामान्य ट्रांज़िशन इफ़ेक्ट्स को समर्थन देता है ताकि आपके मूल प्रस्तुति की प्रवाह और शैली बनी रहे। यह अनुभाग रूपांतरण प्रक्रिया के दौरान समर्थित ट्रांज़िशन इफ़ेक्ट्स को उजागर करता है।

**सूक्ष्म**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**रोमांचक**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**डायनेमिक कंटेंट**:

| ऐनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को परिवर्तित किया जा सकता है?

हाँ, Aspose.Slides for .NET पासवर्ड‑सुरक्षित प्रस्तुतियों के साथ काम करने की अनुमति देता है। ऐसे फ़ाइलों को प्रोसेस करने के दौरान आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

### क्या Aspose.Slides for .NET क्लाउड समाधान में उपयोग का समर्थन करता है?

हाँ, Aspose.Slides for .NET को क्लाउड अनुप्रयोगों और सेवाओं में एकीकृत किया जा सकता है। लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे फ़ाइलों की बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी सुनिश्चित होती है।

### रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई सीमा है क्या?

Aspose.Slides for .NET व्यावहारिक रूप से किसी भी आकार की प्रस्तुति को संभाल सकता है। लेकिन बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और अक्सर प्रदर्शन सुधारने के लिए प्रस्तुति को अनुकूलित करने की सलाह दी जाती है।