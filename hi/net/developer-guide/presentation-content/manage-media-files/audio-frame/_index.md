---
title: .NET में प्रस्तुतियों में ऑडियो फ़्रेम प्रबंधित करें
linktitle: ऑडियो फ़्रेम
type: docs
weight: 10
url: /hi/net/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ़्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में ऑडियो फ़्रेम बनाएं और नियंत्रित करें—एंबेड, ट्रिम, लूप और PPT, PPTX, तथा ODP प्रस्तुतियों में प्ले-बैक कॉन्फ़िगर करने के C# उदाहरण।"
---
## **अवलोकन**

यह लेख Aspose.Slides में ऑडियो फ़्रेम के साथ काम करने के तरीके को समझाता है। यह स्लाइड में एम्बेडेड ऑडियो जोड़ना, ऑडियो फ़्रेम थंबनेल को कस्टमाइज़ करना, वॉल्यूम, लूपिंग, छिपाना, ट्रिमिंग और फ़ेड अवधि जैसी प्ले‑बैक विकल्पों को कॉन्फ़िगर करना, और स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को निकालना दिखाता है।

## **ऑडियो फ़्रेम बनाएं**

Aspose.Slides for .NET आपको स्लाइड में ऑडियो फ़ाइलें जोड़ने की अनुमति देती है। ऑडियो फ़ाइलें स्लाइड में ऑडियो फ़्रेम के रूप में एम्बेड की जाती हैं।

1. Create an instance of the [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
2. स्लाइड का संदर्भ उसके इंडेक्स से प्राप्त करें।
3. वह ऑडियो फ़ाइल स्ट्रीम लोड करें जिसे आप स्लाइड में एम्बेड करना चाहते हैं।
4. एम्बेडेड ऑडियो फ़्रेम (जिसमें ऑडियो फ़ाइल है) को स्लाइड में जोड़ें।
5. Set [PlayMode](https://reference.aspose.com/slides/hi/net/aspose.slides/audioplaymodepreset) and `Volume` exposed by the [IAudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe) object.
6. संशोधित प्रस्तुति को सहेजें।

This C# code shows you how to add an embedded audio frame to a slide:

```c#
// प्रस्तुति फ़ाइल को दर्शाने वाली प्रस्तुति क्लास का नया उदाहरण बनाता है
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.Slides[0];
    
    // wav आवाज़ फ़ाइल को स्ट्रीम में लोड करता है
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // ऑडियो फ़्रेम जोड़ता है
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // ऑडियो के प्ले मोड और वॉल्यूम को सेट करता है
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // PowerPoint फ़ाइल को डिस्क पर लिखता है
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **ऑडियो फ़्रेम थंबनेल बदलें**

जब आप प्रस्तुति में एक ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट छवि वाले फ़्रेम के रूप में दिखता है (नीचे दिए गए चित्र को देखें)। आप ऑडियो फ़्रेम का थंबनेल (अपनी पसंदीदा छवि) बदल सकते हैं।

This C# code shows you how to change an audio frame's thumbnail or preview image:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // स्लाइड पर निर्दिष्ट स्थिति और आकार के साथ एक ऑडियो फ़्रेम जोड़ता है।
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // प्रस्तुति संसाधनों में एक छवि जोड़ता है।
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // ऑडियो फ़्रेम के लिए छवि सेट करता है।
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	//संशोधित प्रस्तुति को डिस्क पर सहेजता है
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for .NET आपको ऑडियो की प्ले‑बैक या गुणों को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूप में चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकॉन को छिपा सकते हैं।

Microsoft PowerPoint में **ऑडियो विकल्प** पैनल:

![example1_image](audio_frame_0.png)

PowerPoint **ऑडियो विकल्प** जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe) प्रॉपर्टी से मिलते हैं:

- **Start** ड्रॉप‑डाउन मेनू [AudioFrame.PlayMode](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/playmode) प्रॉपर्टी से मेल खाता है
- **Volume** [AudioFrame.Volume](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/volume) प्रॉपर्टी से मेल खाता है
- **Play Across Slides** [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/playacrossslides) प्रॉपर्टी से मेल खाता है
- **Loop until Stopped** [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/playloopmode) प्रॉपर्टी से मेल खाता है
- **Hide During Show** [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/hideatshowing) प्रॉपर्टी से मेल खाता है
- **Rewind after Playing** [AudioFrame.RewindAudio](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/properties/rewindaudio) प्रॉपर्टी से मेल खाता है

PowerPoint **एडिटिंग** विकल्प जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe) प्रॉपर्टी से सम्बंधित हैं:

- **Fade In** [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/fadeinduration/) प्रॉपर्टी से मेल खाता है
- **Fade Out** [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/fadeoutduration/) प्रॉपर्टी से मेल खाता है
- **Trim Audio Start Time** [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/trimfromstart/) प्रॉपर्टी से मेल खाता है
- **Trim Audio End Time** का मान ऑडियो अवधि में से [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/trimfromend/) प्रॉपर्टी के मान को घटाकर प्राप्त होता है

PowerPoint **वॉल्यूम नियंत्रण** ऑडियो कंट्रोल पैनल पर [AudioFrame.VolumeValue](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/volumevalue/) प्रॉपर्टी से संबंधित है। यह आपको प्रतिशत के रूप में ऑडियो वॉल्यूम बदलने की अनुमति देता है।

यहाँ आप ऑडियो प्ले विकल्प कैसे बदलते हैं:

1. [Create](#create-audio-frame) या प्राप्त करें Audio Frame।
2. उन Audio Frame प्रॉपर्टी के नए मान सेट करें जिन्हें आप संशोधित करना चाहते हैं।
3. संशोधित PowerPoint फ़ाइल को सहेजें।

This C# code demonstrates an operation in which an audio's options are adjusted:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // AudioFrame आकार प्राप्त करता है
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // प्ले मोड को क्लिक पर चलाने के लिए सेट करता है
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // वॉल्यूम को कम सेट करता है
    audioFrame.Volume = AudioVolumeMode.Low;

    // ऑडियो को स्लाइड्स के बीच चलाने के लिए सेट करता है
    audioFrame.PlayAcrossSlides = true;

    // ऑडियो के लिए लूप को अक्षम करता है
    audioFrame.PlayLoopMode = false;

    // स्लाइड शो के दौरान AudioFrame को छिपाता है
    audioFrame.HideAtShowing = true;

    // चलाने के बाद ऑडियो को प्रारंभ पर रीवाइंड करता है
    audioFrame.RewindAudio = true;

    // PowerPoint फ़ाइल को डिस्क पर सहेजता है
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

This C# example shows how to add a new audio frame with embedded audio, trim it, and set the fade durations:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ट्रिमिंग प्रारंभ ऑफ़सेट को 1.5 सेकंड पर सेट करता है
    audioFrame.TrimFromStart = 1500f;
    // ट्रिमिंग समाप्ति ऑफ़सेट को 2 सेकंड पर सेट करता है
    audioFrame.TrimFromEnd = 2000f;

    // फ़ेस-इन अवधि को 200 मिलीसेकंड पर सेट करता है
    audioFrame.FadeInDuration = 200f;
    // फ़ेस-आउट अवधि को 500 मिलीसेकंड पर सेट करता है
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

The following code sample shows how to retrieve an audio frame with embedded audio and set its volume to 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // ऑडियो फ़्रेम आकार प्राप्त करता है
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // ऑडियो वॉल्यूम को 85% पर सेट करता है
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/captiontracks/) प्रॉपर्टी के माध्यम से एक ऑडियो फ़्रेम में बंद कैप्शन जोड़ने की अनुमति देती है। यह प्रॉपर्टी एक [ICaptionsCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/) लौटाती है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स पर इटरेट कर सकते हैं, और आवश्यकता होने पर उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

[CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudioframe/captiontracks/) प्रॉपर्टी का उपयोग करके एक या अधिक कैप्शन ट्रैक्स को ऑडियो फ़्रेम से जोड़ें। नीचे दिए गए उदाहरण में, एक ऑडियो फ़ाइल स्लाइड में जोड़ी गई है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया गया है।

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ़्रेम से जुड़े कैप्शन ट्रैक्स पर इटरेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बायनरी डेटा और अद्वितीय पहचानकर्ता उजागर करता है, जिसे एक्सपोर्ट करते समय उपयोग किया जा सकता है।

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**ऑडियो कैप्शन हटाएं**

ऑडियो फ़्रेम से कैप्शन हटाने के लिए, [ICaptionsCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/) द्वारा प्रदान किए गए मेथड्स, जैसे [Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/remove/), या [RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/removeat/) का उपयोग करें। नीचे दिया गया उदाहरण ऑडियो फ़्रेम से सभी कैप्शन ट्रैक हटाता है।

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // ऑडियो फ़्रेम से सभी कैप्शन ट्रैक हटाएँ।
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **ऑडियो निकालें**
Aspose.Slides for .NET आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए ध्वनि को निकालने की अनुमति देती है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग हुई ध्वनि निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं और वह प्रस्तुति लोड करें जिसमें ऑडियो है।
2. स्लाइड के इंडेक्स के माध्यम से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड के लिए स्लाइड शो ट्रांज़िशन तक पहुँचें।
4. ध्वनि को बाइट डेटा के रूप में निकालें।

This C# code shows you how to extract the audio used in a slide:

```c#
string presName = "AudioSlide.pptx";

// एक प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का नया उदाहरण बनाता है
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड में बिना फ़ाइल आकार बढ़ाए पुन: उपयोग कर सकता हूँ?**

हां। ऑडियो को एक बार प्रस्तुति के साझा [audio collection](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/audios/) में जोड़ें और अतिरिक्त ऑडियो फ़्रेम बनाएं जो उस मौजूदा एसेट को रेफ़र करते हों। यह मीडिया डेटा की दोहराव को रोकता है और प्रस्तुति का आकार नियंत्रित रखता है।

**क्या मैं मौजूदा ऑडियो फ़्रेम में ध्वनि को बिना शेन को फिर से बनाए बदला सकता हूं?**

हां। लिंक्ड ध्वनि के लिए, [link path](https://reference.aspose.com/slides/hi/net/aspose.slides/audioframe/linkpathlong/) को नई फ़ाइल की ओर अपडेट करें। एम्बेडेड ध्वनि के लिए, प्रस्तुति की [audio collection](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/audios/) से किसी अन्य एम्बेडेड ऑडियो ऑब्जेक्ट से बदलें। फ़्रेम का फॉर्मेट और अधिकांश प्ले‑बैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत मूल ऑडियो डेटा को बदलती है?**

नहीं। ट्रिमिंग केवल प्ले‑बैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहेंगे और एम्बेडेड ऑडियो या प्रस्तुति की ऑडियो कलेक्शन के माध्यम से पहुंच योग्य होंगी।