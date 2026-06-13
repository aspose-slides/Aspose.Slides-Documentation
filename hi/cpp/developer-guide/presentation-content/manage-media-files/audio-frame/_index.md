---
title: C++ का उपयोग करके प्रस्तुतियों में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/cpp/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ़्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में ऑडियो फ्रेम बनाएं और नियंत्रित करें—कोड उदाहरण जो एंबेड, ट्रिम, लूप और PPT, PPTX, और ODP प्रस्तुतियों में प्लेबैक कॉन्फ़िगर करते हैं।"
---
## **परिचय**

यह लेख Aspose.Slides में ऑडियो फ्रेम्स के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड्स में एंबेडेड ऑडियो कैसे जोड़ें, ऑडियो फ्रेम थंबनेल को कैसे अनुकूलित करें, प्लेबैक विकल्प जैसे वॉल्यूम, लूपिंग, छिपाना, ट्रिमिंग और फेड अवधि को कैसे कॉन्फ़िगर करें, और स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को कैसे निकालें।

## **ऑडियो फ्रेम बनाना**

Aspose.Slides for C++ आपको स्लाइड्स में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड्स में ऑडियो फ्रेम्स के रूप में एंबेड की जाती हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एंबेड करने के लिए इच्छित ऑडियो फ़ाइल स्ट्रीम लोड करें।
4. स्लाइड में एंबेडेड ऑडियो फ्रेम (जिसमें ऑडियो फ़ाइल है) जोड़ें।
5. ऑब्जेक्ट [IAudioFrame](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.i_audio_frame) द्वारा उजागर किए गए [PlayMode](https://reference.aspose.com/slides/hi/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) और `Volume` सेट करें।
6. संशोधित प्रेजेंटेशन को सेव करें।

यह C++ कोड दिखाता है कि स्लाइड में एंबेडेड ऑडियो फ्रेम कैसे जोड़ें:

``` cpp
// एक Presentation क्लास का इंस्टैंस बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
auto pres = System::MakeObject<Presentation>();

// पहली स्लाइड प्राप्त करता है
auto sld = pres->get_Slides()->idx_get(0);

// wav ध्वनि फ़ाइल को स्ट्रीम में लोड करता है
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// ऑडियो फ्रेम जोड़ता है
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// ऑडियो का प्ले मोड और वॉल्यूम सेट करता है
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// PowerPoint फ़ाइल को डिस्क पर लिखता है
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **ऑडियो फ्रेम थंबनेल बदलें**

जब आप प्रस्तुति में एक ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक फ्रेम के रूप में मानक डिफ़ॉल्ट छवि के साथ दिखाई देता है (नीचे अनुभाग में छवि देखें)। आप ऑडियो फ्रेम का थंबनेल बदल सकते हैं (अपनी पसंदीदा छवि सेट करें)।

यह C++ कोड दिखाता है कि ऑडियो फ्रेम का थंबनेल या प्रीव्यू इमेज कैसे बदलें:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// स्लाइड में निर्दिष्ट स्थिति और आकार के साथ एक ऑडियो फ्रेम जोड़ता है.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// प्रस्तुति संसाधनों में एक चित्र जोड़ता है.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// ऑडियो फ्रेम के लिए चित्र सेट करता है.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//संशोधित प्रस्तुति को डिस्क पर सहेजता है
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for C++ आपको ऑडियो के प्लेबैक या गुणों को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो का वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूप में चलाने के लिए सेट कर सकते हैं, या यहां तक कि ऑडियो आइकन को छिपा भी सकते हैं।

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/) methods:

- **Start** ड्रॉप‑डाउन सूची [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_playmode/) मेथड से मेल खाती है
- **Volume** [AudioFrame::set_Volume](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_volume/) मेथड से मेल खाता है
- **Play Across Slides** [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_playacrossslides/) मेथड से मेल खाता है
- **Loop until Stopped** [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_playloopmode/) मेथड से मेल खाता है
- **Hide During Show** [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_hideatshowing/) मेथड से मेल खाता है
- **Rewind after Playing** [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_rewindaudio/) मेथड से मेल खाता है

PowerPoint **Editing** options that correspond to Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/) properties:

- **Fade In** [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_fadeinduration/) मेथड से मेल खाता है
- **Fade Out** [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_fadeoutduration/) मेथड से मेल खाता है
- **Trim Audio Start Time** [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_trimfromstart/) मेथड से मेल खाता है
- **Trim Audio End Time** मान ऑडियो अवधि में से [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_trimfromend/) मेथड के मान को घटाकर प्राप्त होता है

The PowerPoint **Volume कंट्रोल** ऑडियो नियंत्रण पैनल पर [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_volumevalue/) मेथड से मेल खाता है। यह आपको ऑडियो वॉल्यूम को प्रतिशत में बदलने देता है।

यहाँ बताया गया है कि आप ऑडियो प्ले विकल्प कैसे बदलते हैं:

1. [बनाएं](#creating-audio-frame) या ऑडियो फ्रेम प्राप्त करें।
2. आप जिन ऑडियो फ्रेम गुणों को समायोजित करना चाहते हैं, उनके लिए नए मान सेट करें।
3. संशोधित PowerPoint फ़ाइल को सेव करें।

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// एक shape प्राप्त करता है
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// shape को AudioFrame shape में कास्ट करता है
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// प्ले मोड को क्लिक पर चलाने के लिए सेट करता है
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// वॉल्यूम को Low पर सेट करता है
audioFrame->set_Volume(AudioVolumeMode::Low);

// ऑडियो को स्लाइड्स के बीच प्ले करने के लिए सेट करता है
audioFrame->set_PlayAcrossSlides(true);

// ऑडियो के लिए लूप को निष्क्रिय करता है
audioFrame->set_PlayLoopMode(false);

// स्लाइड शो के दौरान AudioFrame को छिपाता है
audioFrame->set_HideAtShowing(true);

// प्ले होने के बाद ऑडियो को शुरू से रीवाइंड करता है
audioFrame->set_RewindAudio(true);

// PowerPoint फ़ाइल को डिस्क पर सहेजता है
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// एक ऑडियो फ्रेम शेप प्राप्त करता है
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Sets the audio volume to 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **ऑडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iaudioframe/get_captiontracks/) मेथड के माध्यम से एक ऑडियो फ्रेम में क्लोज़्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स पर इटरिट कर सकते हैं, और आवश्यकता पड़ने पर उन्हें हटा सकते हैं।

**Add Audio Captions**

[get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iaudioframe/get_captiontracks/) मेथड का उपयोग करके एक या अधिक कैप्शन ट्रैक्स को ऑडियो फ्रेम से जोड़ें। नीचे के उदाहरण में, एक ऑडियो फ़ाइल स्लाइड में जोड़ी जाती है, और फिर एक नई कैप्शन ट्रैक `.vtt` फ़ाइल से लोड की जाती है।

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Extract Audio Captions**

आप ऑडियो फ्रेम से जुडे़ हुए कैप्शन ट्रैक्स पर इटरिट करके उन्हें `.vtt` फ़ाइलों के रूप में सेव कर सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और अनूठा पहचानकर्ता प्रदान करता है, जिसे कैप्शन निर्यात करते समय उपयोग किया जा सकता है।

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // प्रत्येक कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Remove Audio Captions**

ऑडियो फ्रेम से कैप्शन हटाने के लिए, [ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) द्वारा प्रदान किए गए मेथड्स जैसे [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/remove/), या [RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/removeat/) का उपयोग करें। नीचे का उदाहरण ऑडियो फ्रेम से सभी कैप्शन ट्रैक्स को हटाता है।

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// ऑडियो फ्रेम से सभी कैप्शन ट्रैक्स हटाएँ.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ऑडियो निकालें**
Aspose.Slides आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए ध्वनि को निकालने की अनुमति देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग किए गए ध्वनि को निकाल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation) क्लास का इंस्टेंस बनाएं और ऑडियो वाली प्रस्तुति लोड करें।
2. इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड के स्लाइडशो ट्रांज़िशन तक पहुँचें।
4. ध्वनि को बाइट डेटा के रूप में निकालें।

``` cpp
String presName = u"AudioSlide.pptx";

// एक Presentation क्लास का इंस्टैंस बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
auto pres = System::MakeObject<Presentation>(presName);

// वांछित स्लाइड तक पहुँचता है
auto slide = pres->get_Slides()->idx_get(0);

// स्लाइड के लिए स्लाइडशो ट्रांज़िशन इफेक्ट्स प्राप्त करता है
auto transition = slide->get_SlideShowTransition();

// ध्वनि को बाइट एरे में निकालता है
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड्स में पुन: उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हाँ। ऑडियो को एक बार प्रस्तुति की साझा [audio collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_audios/) में जोड़ें और अतिरिक्त ऑडियो फ्रेम बनाएं जो उस मौजूदा एसेट को संदर्भित करते हैं। इससे मीडिया डेटा की डुप्लिकेशन नहीं होती और प्रस्तुति का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बिना आकार (shape) को पुनः बनाए बदला सकता हूँ?**

हैं। लिंक्ड साउंड के लिए, नई फ़ाइल की ओर संकेत करने के लिए [link path](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_linkpathlong/) को अपडेट करें। एंबेडेड साउंड के लिए, प्रस्तुति की [audio collection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/get_audios/) से किसी अन्य ऑब्जेक्ट के साथ [embedded audio](https://reference.aspose.com/slides/hi/cpp/aspose.slides/audioframe/set_embeddedaudio/) ऑब्जेक्ट को बदलें। फ्रेम का फॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत मूल ऑडियो डेटा को बदलती है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहते हैं और एंबेडेड ऑडियो या प्रस्तुति की ऑडियो संग्रह के माध्यम से उपलब्ध होते हैं।