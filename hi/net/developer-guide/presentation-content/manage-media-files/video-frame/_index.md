---
title: ".NET में प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें"
linktitle: "वीडियो फ्रेम"
type: docs
weight: 10
url: /hi/net/video-frame/
keywords:
- "वीडियो जोड़ें"
- "वीडियो बनाएं"
- "वीडियो एम्बेड करें"
- "वीडियो निकालें"
- "वीडियो प्राप्त करें"
- "वीडियो फ्रेम"
- "वेब स्रोत"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ना और निकालना सीखें। तेज़ समाधान गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for .NET आपको स्लाइड में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक दोनों का समर्थन करता है।

वीडियो डेटा और वीडियो फ्रेम को दर्शाने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएँ**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिये एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति के पहले स्लाइड पर स्थानीय वीडियो एम्बेड करता है और परिणाम सहेजता है। फ्रेम के निर्देशांक और आकार पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं हो जाता क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) प्रस्तुति के उपयोग के दौरान इसे लॉक रखता है।

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

आप सीधे स्थानीय वीडियो पथ को [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) में भी पास कर सकते हैं। यह उदाहरण नई प्रस्तुति के पहले स्लाइड पर वीडियो एम्बेड करता है। वीडियो को प्रस्तुति सहेजे जाने तक पहुँच योग्य रहना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **वीडियो वॉल्यूम को सटीक रूप से सेट करें**

Aspose.Slides for .NET 26.11 या बाद के संस्करण में, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 0 से 100 तक का फ्लोटिंग‑पॉइंट प्रतिशत सेट करता है। जब [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) प्रीसेट बहुत मोटे होते हैं, तब इसका उपयोग करें। उदाहरण के लिए, `75.5f` 75.5 % वॉल्यूम का अनुरोध करता है।

यह उदाहरण [Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद के संस्करण और एक स्थानीय `video.mp4` की आवश्यकता रखता है। यह वीडियो एम्बेड करता है, स्पष्ट रूप से प्लेबैक प्रारंभ करता है, प्रस्तुति सहेजता है, और संग्रहीत प्रतिशत को पढ़ता है।

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

इनपुट को स्वयं सत्यापित करें; सेट्टर पर भरोसा न करें कि वह दस्तावेज़ीकृत सीमा के बाहर के मानों को अस्वीकार करेगा। 26.11 में Low, Medium और Loud प्रीसेट क्रमशः 20, 50 और 80 के समान हैं। एक प्रीसेट सेट करना पहले के प्रतिशत को प्रतिस्थापित कर सकता है, इसलिए जब आपको सटीक मान चाहिए तो प्रतिशत को अंतिम में असाइन करें। स्पष्ट म्यूट सेटिंग के लिए [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) का उपयोग करें; शून्य संख्यात्मक मान और प्रीसेट एनिुम परस्पर विनिमेय नहीं हैं।

लिंक्ड वीडियो को कॉन्फ़िगर करते समय भी [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) को स्पष्ट रूप से सेट करें, और उसका मीडिया फ़ाइल दर्शक के लिए उपलब्ध रखें। सहेजना और पुनः खोलना संग्रहीत सेटिंग को सत्यापित करता है; वास्तविक प्लेबैक और ध्वनि स्तर प्रस्तुति प्लेयर और उसकी ऑडियो सेटिंग्स पर निर्भर करता है।

## **वेब स्रोत से वीडियो वाला वीडियो फ्रेम बनाएँ**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुति में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहले स्लाइड पर एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। अन्य वीडियो उपयोग करने के लिये वीडियो पहचानकर्ता बदलें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) सेटिंग स्वचालित प्लेबैक का अनुरोध करती है। थंबनेल डाउनलोड करना और वीडियो चलाना इंटरनेट एक्सेस की आवश्यकता रखता है। प्रस्तुति दर्शक को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

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

## **वीडियो को फुल‑स्क्रीन मोड में चलाएँ**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमोंस्ट्रेशन को फुल‑स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सके। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) को `true` सेट करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहले स्लाइड पर पहले [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) को खोजता है, और फुल‑स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना चाहिए जिसमें पहले स्लाइड पर एक मौजूदा वीडियो फ्रेम हो।

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

फुल‑स्क्रीन प्लेबैक नियंत्रित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) निर्धारित करता है कि वह स्वतः शुरू हो या क्लिक पर, और [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) निर्धारित करता है कि वह दोहराए। प्रारंभ व्यवहार चुनने के लिये, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग को संरक्षित रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमोंस्ट्रेशन वीडियो को उसकी शुरुआत में वापस लाना प्रस्तुतकर्ता को फिर से चलाने के लिये तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिये [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) को `true` सेट करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहले स्लाइड पर पहले [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) को खोजता है, और रीवाइंड सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और क्लिक पर शुरू होने के लिये सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होना चाहिए जिसमें पहले स्लाइड पर एक मौजूदा वीडियो फ्रेम हो।

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

रीवाइंड करने से वीडियो शुरुआत में लौटता है बिना पुनः शुरू किए। विपरीत रूप से, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को सक्षम करने से प्लेबैक स्वतः दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और फिर से चलाने के लिये तैयार रहे, तब लूपिंग को निष्क्रिय रखें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) स्वतंत्र रूप से स्वतः या क्लिक पर स्टार्टअप नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता प्लेबैक शुरू करने का समय नियंत्रित कर सके। लूप सेटिंग के बाद प्लेबैक मोड सेट करें, जैसा कि उदाहरण में दिखाया गया है। रीवाइंडिंग स्वतंत्र रूप से [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) से काम करता है।

## **वीडियो फ्रेम को ट्रिम करें**

प्लेबैक के दौरान वीडियो की शुरुआत या अंत के भाग को छोड़ने के लिये [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) और [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) का उपयोग करें। दोनों मान मिलीसेंकड़ में होते हैं। ट्रिमिंग प्लेबैक सेटिंग को बदलता है बिना एम्बेडेड वीडियो डेटा को संशोधित किए।

**ट्रिम सेटिंग सेट करें**

यह उदाहरण स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड तथा अंतिम एक सेकंड को छोड़ता है। एक प्लेयबल सेगमेंट बचाने के लिये वीडियो को 3.5 सेकंड से अधिक लंबा रखें।

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

**ट्रिम सेटिंग पढ़ें**

यह उदाहरण पहले स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेंकड़ में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ नहीं प्रिंट होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) प्रॉपर्टी द्वारा उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण स्थानीय वीडियो एम्बेड करता है और "English" लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मिलना चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) इंटरफ़ेस भी एक ओवरलोड प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहले स्लाइड पर सभी वीडियो फ्रेम से कैप्शन ट्रैक्स को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैक्स की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए।

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

प्रत्येक [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF‑8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट को उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहले स्लाइड पर पहले शेप पोज़िशन पर स्थित वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं तथा शेप एक वीडियो फ्रेम है।

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

स्लाइड पर वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग‑अलग, क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनके पास एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल गणना प्रिंट करता है। आउटपुट सामान्यतः `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकतानुसार रिपोर्टेड मीडिया प्रकार से मिलाने के लिये इसे बदलें।

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

**कौन से वीडियो प्लेबैक पैरामीटर को वीडियो फ्रेम के लिये बदला जा सकता है?**

आप [प्लेबैक मोड](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (ऑटॉ या ऑन‑क्लिक) और [लूपिंग](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हाँ। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और पूर्वावलोकन इमेज को संग्रहीत करती है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम रहती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [वीडियो कंटेंट](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) को बदल सकते हैं जबकि शेप की ज्यामिति समान रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एम्बेडेड वीडियो का एक [कंटेंट टाइप](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिये उसे डिस्क पर सहेजते समय।