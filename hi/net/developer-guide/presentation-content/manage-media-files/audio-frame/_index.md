---
title: ".NET में प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें"
linktitle: "ऑडियो फ्रेम"
type: docs
weight: 10
url: /hi/net/audio-frame/
keywords:
- "ऑडियो"
- "ऑडियो फ्रेम"
- "थंबनेल"
- "ऑडियो जोड़ें"
- "ऑडियो गुण"
- "ऑडियो विकल्प"
- "ऑडियो निकालें"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ स्लाइड्स में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **सारांश**

एक ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for .NET के साथ, आप एक ऑडियो क्लिप एम्बेड कर सकते हैं, उसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक को समायोजित कर सकते हैं, और कैप्शन संलग्न कर सकते हैं। आप स्लाइड ट्रांज़िशन को सौंपे गए ध्वनि को भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

पहली स्लाइड पर एक स्थानीय ऑडियो क्लिप एम्बेड करने के लिए [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) का उपयोग करें। पहले दो निर्देशांक फ्रेम की स्लाइड पर स्थिति निर्धारित करते हैं, और अगले दो मान इसकी चौड़ाई और ऊँचाई को पॉइंट्स में सेट करते हैं। यह उदाहरण [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) को क्लिप को स्वचालित रूप से शुरू करने के लिए और [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) को उच्च प्रीसेट पर सेट करता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **ऑडियो फ्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप में, एक ऑडियो फ्रेम स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) का उपयोग करके एक छवि जोड़ें और उसे फ्रेम की [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) प्रॉपर्टी को असाइन करें। इस उदाहरण में एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में JPEG का उपयोग किया गया है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint के **Audio Options** नियंत्रण निर्धारित करते हैं कि क्लिप कब शुरू होगी, उसकी ध्वनि कितनी तेज़ होगी, और स्लाइड शो के दौरान इसका व्यवहार कैसा रहेगा।

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides property |
| --- | --- |
| सुरु | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| वॉल्यूम प्रीसेट | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| स्लाइड्स में प्ले | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| रुकने तक लूप | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| शो के दौरान छुपाएँ | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| प्ले के बाद रीवाइंड | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| फ़ेड इन | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| फ़ेड आउट | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| ऑडियो शुरू समय ट्रिम | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| ऑडियो अंत समय ट्रिम | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| वॉल्यूम स्लाइडर | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

उदाहरण पहले स्लाइड पर पहला ऑडियो फ्रेम खोजता है, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) को क्लिक पर प्लेबैक शुरू करने के लिए सेट करता है, और कम वॉल्यूम प्रीसेट चुनता है। क्लिप स्लाइड्स के बीच चलती रहती है जबकि लूप बंद रहता है। आइकन शो के दौरान छुपा रहता है, और प्लेबैक के बाद क्लिप रीवाइंड होती है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

3.5 सेकंड से लंबी क्लिप के लिए यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) क्लिप के अंत से हटाए जाने वाले समय को मापता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए इस ऑफ़सेट को पूरी क्लिप अवधि से घटाएँ। ट्रिम की गई क्लिप 200 मिलीसेकंड में फ़ेड इन और 500 मिलीसेकंड में फ़ेड आउट होती है। सभी चार प्रॉपर्टी मान मिलीसेकंड में लेते हैं।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

प्लेबैक वॉल्यूम को विशिष्ट प्रतिशत पर सेट करने के लिए [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) का उपयोग करें। यह उदाहरण पहले स्लाइड पर पहले ऑडियो फ्रेम को 85% पर सेट करता है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ्रेम में एक [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/) संग्रह होता है। इसका उपयोग क्लिप में WebVTT कैप्शन जोड़ने, मौजूदा ट्रैक्स निर्यात करने या उन्हें हटाने के लिए किया जा सकता है।

### **ऑडियो कैप्शन जोड़ें**

उदाहरण पहले स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) का उपयोग करके एक स्थानीय WebVTT ट्रैक संलग्न करता है। पहला तर्क ट्रैक लेबल प्रदान करता है, और दूसरा फ़ाइल पहचानता है जिसमें टाइम्ड कैप्शन होते हैं।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहले स्लाइड पर एक ऑडियो फ्रेम से जुड़े प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह ट्रैक की [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) को एक WebVTT फ़ाइल में लिखता है और उसकी [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **ऑडियो कैप्शन हटाएँ**

एक व्यक्तिगत ट्रैक को हटाने के लिए [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) का उपयोग करें। यह उदाहरण पहले स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन हटाने के लिए [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) का उपयोग करता है, जबकि क्लिप बरकरार रहती है।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **ऑडियो कैप्शन में पंक्ति खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में कोई पंक्ति खोजने के लिए, प्रत्येक ट्रैक की [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) को मेमोरी में पढ़ें। साधारण टेक्स्ट WebVTT क्यू में, टाइमिंग पंक्ति में `-->` होता है, उसके बाद कैप्शन लाइन्स आती हैं, और एक खाली पंक्ति क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन लाइन को प्रिंट करता है जिसमें “café” शब्द शामिल है।

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **ऑडियो निकालें**

एक स्लाइड ट्रांज़िशन की अपनी ध्वनि हो सकती है। इसे प्राप्त करने के लिए, ट्रांज़िशन की [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) प्रॉपर्टी पढ़ें। उदाहरण ध्वनि की [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) तक पहुँचता है और उसके आकार को बाइट्स में प्रिंट करता है। यदि पहले स्लाइड में कोई ट्रांज़िशन ध्वनि नहीं है, तो यह एक संदेश प्रिंट करता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड्स में बिना डुप्लिकेट किए पुन: उपयोग कर सकता हूँ?**

हाँ। क्लिप को प्रस्तुति की [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) में एक बार जोड़ें और प्रत्येक स्लाइड के लिए वही ऑडियो ऑब्जेक्ट [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) को पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बदल सकता हूँ?**

हाँ। लिंक्ड ध्वनि के लिए, [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) को नई फ़ाइल की ओर इंगित करने के लिए अपडेट करें। एम्बेडेड ध्वनि के लिए, प्रस्तुति की ऑडियो संग्रह से किसी अन्य क्लिप को [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) को असाइन करें। दोनों तरीकों से मौजूदा फ्रेम बना रहता है।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत ऑडियो डेटा को बदलती है?**

नहीं। [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) और [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) प्लेबैक सीमाएँ निर्धारित करते हैं। आप अभी भी [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/) से पूरी क्लिप पुनः प्राप्त कर सकते हैं।