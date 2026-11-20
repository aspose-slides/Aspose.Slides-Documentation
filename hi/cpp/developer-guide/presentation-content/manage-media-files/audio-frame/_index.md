---
title: प्रस्तुतियों में C++ का उपयोग करके ऑडियो फ्रेम प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/cpp/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- C++
- Aspose.Slides
description: "स्लाइड्स में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और Aspose.Slides for C++ के साथ स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **सारांश**

एक ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की सुविधा देता है। Aspose.Slides for C++ के साथ आप एक ऑडियो क्लिप को एम्बेड कर सकते हैं, उसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन संलग्न कर सकते हैं। आप स्लाइड ट्रांज़िशन को असाइन किए गए ध्वनि को भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

स्थानीय ऑडियो क्लिप को पहली स्लाइड पर एम्बेड करने के लिये [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) का उपयोग करें। पहले दो निर्देशांक फ्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान इसकी चौड़ाई और ऊँचाई को पॉइंट्स में सेट करते हैं। यह उदाहरण क्लिप को स्वतः शुरू करने के लिये [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) को कॉल करता है और तेज़ प्रीसैट चुनने के लिये [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) को कॉल करता है।

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

presentation->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **ऑडियो फ्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप से, एक ऑडियो फ्रेम स्पीकर आइकन दर्शाता है। कस्टम थंबनेल दिखाने के लिये, प्रस्तुति में [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) से एक छवि जोड़ें और उसे फ्रेम की तस्वीर के रूप में [set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) से सेट करें। यह उदाहरण एम्बेडेड ऑडियो क्लिप के लिये थंबनेल के रूप में एक JPEG का उपयोग करता है।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageStream = File::OpenRead(u"eagle.jpeg");
auto thumbnail = presentation->get_Images()->AddImage(imageStream);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"example_out.pptx", SaveFormat::Pptx);
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint के **Audio Options** नियंत्रण निर्धारित करते हैं कि क्लिप कब शुरू होती है, आवाज़ कितनी तेज़ है, और स्लाइड शो के दौरान इसका व्यवहार कैसे रहता है।

![PowerPoint ऑडियो विकल्प नियंत्रण एक ऑडियो फ्रेम के लिये](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for C++ विधि |
| --- | --- |
| शुरूआत | [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) |
| वॉल्यूम प्रीसैट | [set_Volume](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volume/) |
| स्लाइड्स में चलाएँ | [set_PlayAcrossSlides](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playacrossslides/) |
| रोकने तक लूप | [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playloopmode/) |
| शो के दौरान छिपाएँ | [set_HideAtShowing](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_hideatshowing/) |
| प्ले होने के बाद रीवाइंड | [set_RewindAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_rewindaudio/) |
| फ़ेड इन | [set_FadeInDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeinduration/) |
| फ़ेड आउट | [set_FadeOutDuration](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_fadeoutduration/) |
| ऑडियो प्रारम्भ समय ट्रिम | [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) |
| ऑडियो अंत समय ट्रिम | [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) |
| वॉल्यूम स्लाइडर | [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) |

यह उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम ढूँढ़ता है, क्लिक पर प्लेबैक शुरू करने के लिये [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_playmode/) को कॉल करता है, और कम वॉल्यूम प्रीसैट चुनता है। क्लिप लूप निष्क्रिय रहने पर स्लाइड्स के बीच चलता रहता है। आइकन शो के दौरान छिपा रहता है, और प्लेबैक के बाद क्लिप रीवाइंड हो जाता है।

```cpp
#include <DOM/AudioPlayModePreset.h>
#include <DOM/AudioVolumeMode.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);
    audioFrame->set_Volume(AudioVolumeMode::Low);
    audioFrame->set_PlayAcrossSlides(true);
    audioFrame->set_PlayLoopMode(false);
    audioFrame->set_HideAtShowing(true);
    audioFrame->set_RewindAudio(true);

    presentation->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

3.5 सेकंड से अधिक लंबी क्लिप के लिये, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) को दिया गया तर्क क्लिप के अंत से हटाए जाने वाले अवधि को दर्शाता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिये इस ऑफ़सेट को पूरी क्लिप अवधि से घटाएँ। ट्रिम्ड क्लिप 200 मिलीसेकंड में फ़ेड इन होती है और 500 मिलीसेकंड में फ़ेड आउट। सभी चार सेटर्स मान को मिलीसेकंड में लेते हैं।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame->set_TrimFromStart(1500);
audioFrame->set_TrimFromEnd(2000);
audioFrame->set_FadeInDuration(200);
audioFrame->set_FadeOutDuration(500);

presentation->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
```

प्लेबैक वॉल्यूम को एक विशिष्ट प्रतिशत पर सेट करने के लिये, [set_VolumeValue](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_volumevalue/) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम को 85 % पर सेट करता है।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->set_VolumeValue(85);

    presentation->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ्रेम अपनी कैप्शन कलेक्शन को [get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_captiontracks/) के माध्यम से उजागर करता है। इसका उपयोग क्लिप पर WebVTT कैप्शन संलग्न करने, मौजूदा ट्रैक्स निर्यात करने, या उन्हें हटाने के लिये किया जा सकता है।

### **ऑडियो कैप्शन जोड़ें**

यह उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक संलग्न करने के लिये [ICaptionsCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/add/) का उपयोग करता है। पहला तर्क ट्रैक लेबल देता है, और दूसरा फ़ाइल पहचानता है जिसमें समयबद्ध कैप्शन होते हैं।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = File::OpenRead(u"audio.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर एक ऑडियो फ्रेम से जुड़ी प्रत्येक कैप्शन ट्रैक को एक्सपोर्ट करता है। यह [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_binarydata/) द्वारा लौटाए गए बाइट्स को एक WebVTT फ़ाइल में लिखता है और [get_CaptionId](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_captionid/) द्वारा लौटाए गए मान को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto fileName = track->get_CaptionId().ToString() + u".vtt";
        File::WriteAllBytes(fileName, track->get_BinaryData());
    }
}
```

### **ऑडियो कैप्शन हटाएँ**

एक व्यक्तिगत ट्रैक को हटाने के लिये [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/removeat/) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन हटाने के लिये [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/clear/) का उपयोग करता है, जबकि क्लिप को संरक्षित रखता है।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IAudioFrame> audioFrame;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    audioFrame = AsCast<IAudioFrame>(shape);
    if (audioFrame)
        break;
}

if (audioFrame)
{
    audioFrame->get_CaptionTracks()->Clear();

    presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The first slide has no audio frame.");
}
```

### **ऑडियो कैप्शन में पंक्ति खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में कोई पंक्ति खोजने के लिये, प्रत्येक ट्रैक पर [get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) को कॉल करके उसकी WebVTT टेक्स्ट मेमोरी में पढ़ें। एक साधारण टेक्स्ट WebVTT क्यू में, टाइमिंग पंक्तियों में `-->` होता है, उसके बाद कैप्शन पंक्तियाँ आती हैं, और एक खाली पंक्ति क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन पंति को प्रिंट करता है जिसमें “café” शब्द है।

```cpp
#include <DOM/IAudioFrame.h>
#include <DOM/ICaptions.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    auto audioFrame = AsCast<IAudioFrame>(shape);
    if (!audioFrame)
        continue;

    for (auto&& track : IterateOver(audioFrame->get_CaptionTracks()))
    {
        auto reader = MakeObject<StringReader>(track->get_DataAsString());
        auto inCue = false;
        for (auto line = reader->ReadLine(); !line.IsNull(); line = reader->ReadLine())
        {
            if (line.get_Length() == 0)
                inCue = false;
            else if (line.Contains(u"-->"))
                inCue = true;
            else if (inCue && line.IndexOf(u"caf\u00e9", StringComparison::OrdinalIgnoreCase) >= 0)
                Console::WriteLine(track->get_Label() + u": " + line);
        }
    }
}
```

## **ऑडियो निकालें**

एक स्लाइड ट्रांज़िशन का अपना ध्वनि हो सकता है। इसे प्राप्त करने के लिये, ट्रांज़िशन पर [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_sound/) को कॉल करें। यह उदाहरण [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) के साथ ऑडियो बाइट्स प्राप्त करता है और बाइट्स की संख्या प्रिंट करता है। यदि पहली स्लाइड में ट्रांज़िशन ध्वनि नहीं है, तो यह एक संदेश प्रिंट करता है।

```cpp
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"AudioSlide.pptx");
auto slide = presentation->get_Slide(0);

auto sound = slide->get_SlideShowTransition()->get_Sound();
if (sound)
{
    auto audioData = sound->get_BinaryData();
    Console::WriteLine(u"Transition sound: {0} bytes.", audioData->get_Length());
}
else
{
    Console::WriteLine(u"The first slide has no transition sound.");
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई स्लाइड्स में एक ही ऑडियो क्लिप को दोहराए बिना उपयोग कर सकता हूँ?**

हां। क्लिप को एक बार प्रस्तुति के [audio collection](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_audios/) में जोड़ें और प्रत्येक स्लाइड के लिये समान ऑडियो ऑब्जेक्ट को [AddAudioFrameEmbedded](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) को पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि बदल सकता हूँ?**

हां। लिंक्ड ध्वनि के लिये, प्रतिस्थापन फ़ाइल के पथ के साथ [set_LinkPathLong](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_linkpathlong/) को कॉल करें। एम्बेडेड ध्वनि के लिये, प्रस्तुति के ऑडियो कलेक्शन से दूसरा क्लिप [set_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_embeddedaudio/) को पास करें। दोनों तरीकों से मौजूदा फ्रेम बना रहता है।

**क्या ट्रिमिंग से प्रस्तुति में संग्रहित ऑडियो डेटा बदलता है?**

नहीं। [set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromstart/) और [set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/set_trimfromend/) प्लेबैक सीमाएँ सेट करते हैं। आप अभी भी [get_EmbeddedAudio](https://reference.aspose.com/slides/cpp/aspose.slides/iaudioframe/get_embeddedaudio/) से पूरी क्लिप प्राप्त कर सकते हैं।