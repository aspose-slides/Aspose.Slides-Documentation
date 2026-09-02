---
title: C++ का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/cpp/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। त्वरित उपयोग मार्गदर्शिका।"
---
## **परिचय**

एक अच्छी तरह से स्थित वीडियो प्रस्तुति में आपके संदेश को अधिक आकर्षक बना सकता है और आपके दर्शकों की सहभागिता स्तर को बढ़ा सकता है।

PowerPoint आपको प्रस्तुति में स्लाइड पर वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपकी मशीन पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (YouTube जैसे वेब स्रोत से)

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने की अनुमति देने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य प्रासंगिक प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप अपनी प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं।
1. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
1. एक [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ को पास करके प्रस्तुति के साथ वीडियो एम्बेड करें।
1. एक [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए एक फ्रेम बनाया जा सके।  
1. संशोधित प्रस्तुति को सहेजें।

यह C++ कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

वैकल्पिक रूप से, आप वीडियो फ़ाइल पथ को सीधे [AddVideoFrame()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addvideoframe/) मेथड को पास करके वीडियो जोड़ सकते हैं:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft PowerPoint के नए संस्करण ऑनलाइन वीडियो को प्रस्तुतियों में समर्थन देते हैं। यदि वह वीडियो जिसे आप उपयोग करना चाहते हैं ऑनलाइन उपलब्ध है (उदाहरण के लिए YouTube पर), तो आप उसके वेब लिंक के माध्यम से इसे अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं
1. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
1. एक [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो के लिंक को पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें। 
1. प्रस्तुति को सहेजें। 

यह C++ कोड दिखाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```c++
// डॉक्यूमेंट्स डायरेक्टरी का पथ।
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुंचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// एक Video Frame जोड़ता है 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// वीडियो का प्ले मोड और वॉल्यूम सेट करता है
vf->set_PlayMode(VideoPlayModePreset::Auto);

//प्रस्तुति को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **वीडियो फ्रेम को ट्रिम करें**

Aspose.Slides आपको [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/set_trimfromstart/) और [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/set_trimfromend/) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट करके यह निर्धारित करने की अनुमति देता है कि वीडियो का कौन सा भाग चलाया जाएगा। दोनों मान मिलीसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से स्किप किए जाने वाले समय को निर्धारित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; ये एम्बेडेड वीडियो के बाइनरी डेटा को काटती या संशोधित नहीं करतीं।

**ट्रिम सेटिंग्स सेट करें**

एक वीडियो फ्रेम बनाकर उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं।
1. प्रस्तुति में एक [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें।
1. एक स्लाइड पर एक [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/set_trimfromstart/) और [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/set_trimfromend/) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड उदाहरण प्लेबैक के दौरान एम्बेडेड वीडियो के पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ देता है:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स का निरीक्षण करने के लिए, एक प्रस्तुति लोड करें, पहली स्लाइड पर आकृतियों में से एक [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें, और मानों को [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_trimfromstart/) और [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_trimfromend/) के माध्यम से पढ़ें।

निम्न कोड उदाहरण पहली स्लाइड पर पहला वीडियो फ्रेम खोजता है और उसके ट्रिम सेटिंग्स को मिलीसेकंड में रिपोर्ट करता है:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **वीडियो कैप्शन प्रबंधन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) मेथड के माध्यम से एक्सपोज़ किए जाते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. एक स्लाइड पर एक [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए [ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) का उपयोग करके एक WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जिससे आप स्ट्रिम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालें**

कैप्शन निकालने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो है।
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए कैप्शन ट्रैकों पर इटरेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन डेटा को UTF-8 स्ट्रिंग के रूप में एक्सपोज़ करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

कैप्शन हटाने के लिए:

1. उस प्रस्तुति को लोड करें जिसमें वीडियो है।
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए संग्रह से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// वीडियो फ्रेम से सभी कैप्शन हटाता है।
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/removeat/) मेथड का प्रयोग करें।

## **स्लाइड से वीडियो निकालें**

वीडियो को स्लाइड में जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो को निकालने की भी अनुमति देता है।

1. वीडियो वाली प्रस्तुति को लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास की एक instance बनाएं। 
2. सभी [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) ऑब्जेक्ट्स पर इटरेट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) ऑब्जेक्ट्स पर इटरेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/) मिले। 
4. वीडियो को डिस्क पर सहेजें।

यह C++ कोड दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```c++
// डॉक्यूमेंट्स डायरेक्टरी का पथ।
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक VideoFrame के लिए कौन-से वीडियो प्लेबैक पैरामीटर बदल सकते हैं?**

आप प्लेबैक मोड (ऑटो या क्लिक पर) और लूपिंग को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है?**

हाँ। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/set_embeddedvideo/) को बदल सकते हैं जबकि शैल की ज्यामिति को बरकरार रख सकते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने के लिए सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) को निर्धारित किया जा सकता है?**

हाँ। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/video/get_contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।