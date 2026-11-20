---
title: C++ का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/cpp/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएँ
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
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने की जानकारी सीखें। त्वरित मार्गदर्शिका।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for C++ आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की अनुमति देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक का समर्थन करता है।

वीडियो डेटा और वीडियो फ्रेम का प्रतिनिधित्व करने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) इंटरफ़ेस और अन्य संबंधित प्रकार प्रदान करता है।

## **एंबेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो को अपनी प्रस्तुति में एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं हो जाता, क्योंकि [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) प्रस्तुति द्वारा उपयोग के समय इसे लॉक रखता है।

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

आप स्थानीय वीडियो पथ को सीधे [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) में पास कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को तब तक उपलब्ध रहना चाहिए जब तक प्रस्तुति सहेजी नहीं जाती।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ्रेम बनाएँ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुतियों में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक से जुड़ा हो।

यह उदाहरण पहली स्लाइड में YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) मेथड स्वचालित प्लेबैक का अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट पहुँच आवश्यक है। प्रस्तुति दर्शक को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **पूर्ण-स्क्रीन मोड में वीडियो चलाएँ**

एक प्रशिक्षण प्रस्तुति में, आप दर्शकों को विवरण दिखाने के लिए सॉफ़्टवेयर डेमो को पूर्ण-स्क्रीन मोड में चला सकते हैं। [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) `true` स्वीकार करता है ताकि प्लेबैक के दौरान यह व्यवहार सक्रिय हो।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) खोजता है, और पूर्ण-स्क्रीन प्लेबैक को सक्रिय करता है। इनपुट प्रस्तुति में पहली स्लाइड पर कम से कम एक मौजूदा वीडियो फ्रेम वाला स्लाइड होना आवश्यक है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

पूर्ण-स्क्रीन प्लेबैक नियंत्रित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) नियंत्रित करता है कि यह स्वचालित रूप से शुरू हो या क्लिक पर, और [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) नियंत्रित करता है कि यह दोहराया जाए। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset::Auto या VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग्स को संरक्षित रखता है।

## **प्लेबैक के बाद वीडियो रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमो वीडियो को उसके शुरूआत पर लौटाना इसे प्रस्तुतकर्ता के फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरूआत पर लौटाने के लिए [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) को `true` के साथ कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) खोजता है, और रीवाइंडिंग को सक्षम करता है। यह लूपिंग को अक्षम कर देता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू करने के लिए सेट करता है। इनपुट प्रस्तुति में पहली स्लाइड पर कम से कम एक मौजूदा वीडियो फ्रेम वाला स्लाइड होना चाहिए।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

रीवाइंडिंग वीडियो को फिर से शुरू किए बिना उसकी शुरुआत पर वापस ले जाता है। इसके विपरीत, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) को सक्षम करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो जाए और पुनः चलाने के लिए तैयार रहे तो लूपिंग को अक्षम रखें। [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) स्वतंत्र रूप से स्वचालित या क्लिक पर प्रारंभ को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता निर्धारित कर सके कि प्लेबैक कब शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) से स्वतंत्र रूप से काम करता है।

## **वीडियो फ्रेम को ट्रिम करें**

[IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) और [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को स्किप किया जा सकता है। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स बदलती है।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को स्किप करता है। एक 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें ताकि एक चलने योग्य भाग बना रहे।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ नहीं प्रिंट होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT प्रारूप में संग्रहीत होते हैं और [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) मेथड के माध्यम से उपलब्ध होते हैं।

### **वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और English लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

### **वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में एक्सपोज़ करता है।

### **वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप पोज़िशन पर स्थित वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ्रेम है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) मेथड का उपयोग करें।

### **वीडियो कैप्शन खोजें**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) पूरे WebVTT ट्रैक को लौटाता है, जिसमें हेडर, टाइमिंग लाइन और कैप्शन टेक्स्ट शामिल हैं। बोले गए वाक्यांश और उसका टाइमस्टैम्प खोजने के लिए, मेमोरी में क्यूज़ पढ़ें। उदाहरण के लिए, स्लाइड 2 पर एक English ट्रैक में निम्नलिखित टेक्स्ट हो सकता है:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

उदाहरण `captioned_media.pptx` खोलता है और प्रत्येक स्लाइड पर प्रत्येक टॉप-लेवल वीडियो फ्रेम के कैप्शन ट्रैक को [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) का उपयोग करके पढ़ता है। साधारण टेक्स्ट क्यू में, टाइमिंग लाइन में `-->` होता है और एक खाली लाइन क्यू को समाप्त करती है। जब कैप्शन में “café” होता है, तो उदाहरण स्लाइड नंबर, ट्रैक लेबल, मूल टाइमिंग लाइन और पूर्ण कैप्शन प्रिंट करता है। खोज केस को नजरअंदाज़ करती है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

“café” की खोज नमूना ट्रैक के लिए एक मैच देती है। खोज हेडर को स्किप करती है और आउटपुट में टाइमिंग सेटिंग को बरकरार रखती है।

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की भी अनुमति देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग-अलग, क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनमें एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल संख्या प्रिंट करता है। आउटपुट जनरिक `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता होने पर रिपोर्टेड मीडिया प्रकार से मेल खाने के लिए इसे बदलें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**किस वीडियो प्लेबैक पैरामीटर को वीडियो फ्रेम के लिए बदला जा सकता है?**

आप [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (स्वतः या क्लिक पर) और [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) ऑब्जेक्ट की विधियों के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार पर प्रभाव पड़ता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को स्टोर करती है, वीडियो डेटा नहीं, इसलिए आकार वृद्धि सामान्यतः कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) को बदल सकते हैं जबकि शेप की ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।