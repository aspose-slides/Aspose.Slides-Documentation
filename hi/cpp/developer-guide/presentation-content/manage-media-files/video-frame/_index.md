---
title: C++ का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
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
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ना और निकालना सीखें। तेज़ गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को संलग्न करने में मदद कर सकते हैं। Aspose.Slides for C++ आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स को समायोजित करने, कैप्शन प्रबंधित करने, और एम्बेडेड वीडियो डेटा निकालने की अनुमति देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो के लिंक, जैसे YouTube वीडियो, को समर्थित करता है।

वीडियो डेटा और वीडियो फ्रेम का प्रतिनिधित्व करने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो फ्रेम बनाकर वीडियो को प्रस्तुति में एम्बेड कर सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं हो जाता क्योंकि [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) प्रस्तुति के उपयोग के दौरान इसे लॉक रखता है।

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

आप सीधे स्थानीय वीडियो पथ को [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) में पास भी कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को तब तक सुलभ रहना चाहिए जब तक प्रस्तुति सहेजी नहीं जाती।

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

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुति में ऑनलाइन वीडियो को समर्थित करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड पर एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) विधि स्वचालित प्लेबैक का अनुरोध करती है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

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

## **पूरे स्क्रीन मोड में वीडियो चलाएँ**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमॉन्स्ट्रेशन को पूरे स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए `true` स्वीकार करता है।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) खोजता है, और पूरे स्क्रीन प्लेबैक को सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौज़ूद वीडियो फ्रेम हो।

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

पूरा‑स्क्रीन प्लेबैक यह निर्धारित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) नियंत्रित करता है कि वह स्वचालित रूप से शुरू हो या क्लिक पर, और [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) नियंत्रित करता है कि वह दोहराए। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग को बरकरार रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमॉन्स्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना प्रस्तुति देने वाले को इसे फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिए `true` के साथ [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) खोजता है, और रीवाइंडिंग सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और क्लिक पर शुरू होने के लिए प्लेबैक सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौज़ूद वीडियो फ्रेम हो।

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

रीवाइंडिंग वीडियो को उसकी शुरुआत में लौटाता है बिना उसे फिर से शुरू किए। इसके विपरीत, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) को सक्षम करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तो लूपिंग निष्क्रिय रखें। [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) स्वतंत्र रूप से स्वचालित या क्लिक‑पर स्टार्टअप को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुति देने वाला नियंत्रित कर सके कि प्लेबैक कब शुरू हो। लूप सेटिंग के बाद प्लेबैक मोड सेट करें, जैसा कि उदाहरण में दिखाया गया है। रीवाइंडिंग [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) से स्वतंत्र रूप से काम करता है।

## **वीडियो फ्रेम को ट्रिम करें**

प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को छोड़ने के लिए [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) और [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) का उपयोग करें। दोनों मूल्यों का इकाई मिलीसेकंड है। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग बदलता है।

**ट्रिम सेटिंग सेट करें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को छोड़ता है। प्लेबैक योग्य भाग बनाए रखने के लिए वीडियो 3.5 सेकंड से लंबा होना चाहिए।

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

**ट्रिम सेटिंग पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ भी प्रिंट नहीं होता। पिछले उदाहरण में मान 2500 और 1000 होते हैं।

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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) विधि के माध्यम से उजागर होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और "English" लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो के साथ मेल खाने चाहिए। सहेजी गई प्रस्तुति में दोनों वीडियो और उसके कैप्शन शामिल होते हैं।

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

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) इंटरफ़ेस एक अतिरिक्त ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेमों से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

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

प्रत्येक [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF‑8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शपे स्थिति में वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शपे मौजूद हैं और शपे एक वीडियो फ्रेम है।

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

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) विधियों का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो को निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग‑अलग क्रमबद्ध बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनके पास एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल संख्या प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता अनुसार रिपोर्ट किए गए मीडिया प्रकार के साथ मिलाने के लिए इसे बदलें।

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

**एक वीडियो फ्रेम के लिए कौन‑से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) ऑब्जेक्ट की विधियों के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को संग्रहीत करती है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौज़ूद वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) को बदल सकते हैं जबकि शपे की ज्यामिति बरकरार रहती है; यह मौज़ूद लेआउट में मीडिया अपडेट करने का आम परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिये जब आप इसे डिस्क पर सहेजते हैं।