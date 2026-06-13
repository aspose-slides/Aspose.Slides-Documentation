---
title: C++ का उपयोग करके प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/cpp/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument स्लाइड में प्रोग्रामेटिक रूप से वीडियो फ़्रेम जोड़ने और निकालने का तरीका सीखें। त्वरित कैसे‑करें गाइड।"
---
## **परिचय**

प्रस्तुति में सही स्थान पर रखी गई वीडियो आपके संदेश को अधिक प्रभावशाली बना सकती है और आपके दर्शकों के साथ सहभागिता स्तर को बढ़ा सकती है।

PowerPoint आपको प्रस्तुति में स्लाइड में वीडियो जोड़ने के दो तरीके प्रदान करता है:
* स्थानीय वीडियो जोड़ें या एम्बेड करें (जो आपके मशीन पर संग्रहीत है)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube जैसी वेब स्रोत से)।

प्रस्तुति में वीडियो (video objects) जोड़ने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) इंटरफ़ेस और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाना**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप अपनी प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और प्रस्तुति में वीडियो एम्बेड करने के लिए वीडियो फ़ाइल पथ पास करें।  
1. [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए एक फ्रेम बनाया जा सके।  
1. परिवर्तित प्रस्तुति को सहेजें।  

यह C++ कोड आपको दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ा जाए:

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

वैकल्पिक रूप से, आप वीडियो को उसके फ़ाइल पथ को सीधे [AddVideoFrame()](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addvideoframe/) मेथड में पास करके जोड़ सकते हैं:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाना**

Microsoft [PowerPoint 2013 और उसके बाद के संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुतियों में YouTube वीडियो को समर्थन देते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube पर), तो आप उसे वेब लिंक के माध्यम से अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. [IVideo](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।  
1. वीडियो फ्रेम के लिए थंबनेल सेट करें।  
1. प्रस्तुति को सहेजें।  

यह C++ कोड आपको दिखाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ा जाए:

```c++
// दस्तावेज़ निर्देशिका का पथ।
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// पहली स्लाइड तक पहुंचता है
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// एक Video Frame जोड़ता है 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// वीडियो का प्ले मोड और वॉल्यूम सेट करता है
vf->set_PlayMode(VideoPlayModePreset::Auto);

// प्रस्तुति को डिस्क पर सहेजता है
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ़्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) मेथड के माध्यम से एक्सपोज़ किए जाते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. प्रस्तुति में एक वीडियो जोड़ें।  
1. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।  
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए [ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) का उपयोग करके WebVTT कैप्शन ट्रैक जोड़ें।  
1. परिवर्तित प्रस्तुति को सहेजें।  

निम्नलिखित कोड आपको दिखाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की सुविधा देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।  
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।  
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए कैप्शन ट्रैक्स पर इटररेट करें।  
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।  

निम्नलिखित कोड आपको दिखाता है कि वीडियो फ्रेम से कैप्शन कैसे निकाले जाएँ:

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

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।  
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।  
1. [get_CaptionTracks](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ivideoframe/get_captiontracks/) द्वारा लौटाए गए संग्रह से कैप्शन ट्रैक्स हटाएँ।  
1. परिवर्तित प्रस्तुति को सहेजें।  

निम्नलिखित कोड आपको दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// वीडियो फ़्रेम से सभी कैप्शन हटाता है।
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides/icaptionscollection/removeat/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की अनुमति देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
2. सभी [ISlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/) ऑब्जेक्ट्स पर इटररेट करें।  
3. सभी [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) ऑब्जेक्ट्स पर इटररेट करके एक [VideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/) खोजें।  
4. वीडियो को डिस्क पर सहेजें।  

यह C++ कोड आपको दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकाला जाए:

```c++
// दस्तावेज़ निर्देशिका का पथ।
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

**एक VideoFrame के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/set_playmode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/set_playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/cpp/aspose.slides/videoframe/set_embeddedvideo/) को बदल सकते हैं जबकि आकार की ज्योमेट्री बरकरार रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो की एक [content type](https://reference.aspose.com/slides/hi/cpp/aspose.slides/video/get_contenttype/) होती है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब इसे डिस्क पर सहेजते हैं।