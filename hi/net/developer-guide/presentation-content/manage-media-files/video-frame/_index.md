---
title: .NET में प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/net/video-frame/
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
- प्रेज़ेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। तेज़ कैसे‑करें गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for .NET आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की अनुमति देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक को सपोर्ट करता है।

वीडियो डेटा और वीडियो फ्रेम का प्रतिनिधित्व करने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) इंटरफेस, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) इंटरफेस और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप अपने प्रेज़ेंटेशन में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रेज़ेंटेशन की पहले स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम को सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम खुला रहता है जब तक सहेजना पूरा नहीं हो जाता, क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) प्रेज़ेंटेशन द्वारा उपयोग के दौरान इसे लॉक रखता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

आप स्थानीय वीडियो पथ को सीधे [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) को भी पास कर सकते हैं। यह उदाहरण नई प्रेज़ेंटेशन की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को तब तक उपलब्ध रहना चाहिए जब तक प्रेज़ेंटेशन सहेजा नहीं जाता।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रेज़ेंटेशन में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहले स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) सेटिंग स्वचालित प्लेबैक का अनुरोध करती है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रेज़ेंटेशन व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **पूर्ण-स्क्रीन मोड में वीडियो चलाएँ**

एक प्रशिक्षण प्रेज़ेंटेशन में, आप सॉफ़्टवेयर डेमॉन्स्ट्रेशन को पूर्ण-स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) को `true` सेट करें।

यह उदाहरण एक प्रेज़ेंटेशन खोलता है, पहले स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) खोजता है, और पूर्ण-स्क्रीन प्लेबैक को सक्षम करता है। इनपुट प्रेज़ेंटेशन में कम से कम एक स्लाइड पर पहले स्लाइड में एक मौजूदा वीडियो फ्रेम होना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

पूर्ण-स्क्रीन प्लेबैक निर्धारित करता है कि वीडियो कैसे प्रदर्शित किया जाता है। स्वतंत्र रूप से, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) नियंत्रित करता है कि यह स्वचालित रूप से शुरू हो या क्लिक पर, और [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) नियंत्रित करता है कि यह दोहराए या नहीं। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग्स को बनाए रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रेज़ेंटेशन में, डेमॉन्स्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना प्रस्तुतकर्ता को फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को उसकी शुरुआत में लौटाने के लिए [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) को `true` सेट करें।

यह उदाहरण एक प्रेज़ेंटेशन खोलता है, पहले स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) खोजता है, और रीवाइंडिंग को सक्षम करता है। यह लूपिंग को अक्षम करता है ताकि प्लेबैक समाप्त हो सके और क्लिक पर शुरू होने के लिए सेट करता है। इनपुट प्रेज़ेंटेशन में कम से कम एक स्लाइड पर पहले स्लाइड में एक मौजूदा वीडियो फ्रेम होना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

रीवाइंडिंग वीडियो को उसकी शुरुआत में लौटाता है बिना उसे फिर से शुरू किए। इसके विपरीत, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को सक्षम करने से प्लेबैक स्वत: दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तब लूप को अक्षम रखें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) स्वतंत्र रूप से स्वचालित या क्लिक पर शुरूआत को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता तय कर सके कब प्लेबैक शुरू हो। लूप सेटिंग के बाद प्लेबैक मोड सेट करें, जैसा कि उदाहरण में दिखाया गया है। रीवाइंडिंग [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) से स्वतंत्र रूप से कार्य करता है।

## **एक वीडियो फ्रेम को ट्रिम करें**

प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को छोड़ने के लिए [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) और [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) का उपयोग करें। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स को बदलती है।

**Trim सेटिंग्स सेट करें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और आखिरी सेकंड को छोड़ता है। एक ऐसी वीडियो उपयोग करें जिसकी अवधि 3.5 सेकंड से अधिक हो ताकि एक प्लेयेबल सेगमेंट बचा रहे।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Trim सेटिंग्स पढ़ें**

यह उदाहरण पहले स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रेज़ेंटेशन में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ प्रिंट नहीं होगा। पिछले उदाहरण ने 2500 और 1000 मान उत्पन्न किए।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रेज़ेंटेशन में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन वेबVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) प्रॉपर्टी के माध्यम से उपलब्ध कराए जाते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और English लेबल वाला एक WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मेल खाने चाहिए। सहेजे गए प्रेज़ेंटेशन में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) इंटरफेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमांकित फ़ाइलें आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक की संख्या रिपोर्ट करता है। प्रेज़ेंटेशन में कम से कम एक स्लाइड होनी चाहिए।

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट को उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएं**

यह उदाहरण पहली स्लाइड पर पहले शेड के स्थित वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेड मौजूद हैं और शेड एक वीडियो फ्रेम है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रेज़ेंटेशन में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग-अलग क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनमें एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल संख्या प्रिंट करता है। आउटपुट में सामान्य `.bin` एक्सटेंशन का उपयोग होता है; आवश्यकता पड़ने पर इसे रिपोर्ट किए गए मीडिया टाइप के अनुसार बदलें।

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**एक वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रेज़ेंटेशन का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो का लिंक और थंबनेल जोड़ते हैं, तो प्रेज़ेंटेशन लिंक और प्रीव्यू इमेज को संग्रहीत करता है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) को बदल सकते हैं जबकि शेड की ज्यामिति वही रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब आप उसे डिस्क पर सहेजते हैं।