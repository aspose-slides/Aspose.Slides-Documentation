---
title: ".NET में प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें"
linktitle: "वीडियो फ्रेम"
type: docs
weight: 10
url: /hi/net/video-frame/
keywords:
- "वीडियो जोड़ें"
- "वीडियो बनाएँ"
- "वीडियो एंबेड करें"
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
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में वीडियो फ्रेम को प्रोग्रामेटिकली जोड़ने और निकालने के लिए तेज़ कैसे‑करें गाइड सीखें।"
---
## **परिचय**

वीडियो विचारों को स्पष्ट करने और दर्शकों को संलग्न करने में मदद कर सकते हैं। Aspose.Slides for .NET आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स को समायोजित करने, कैप्शन प्रबंधित करने, और एंबेडेड वीडियो डेटा निकालने की अनुमति देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक को समर्थन देता है।

वीडियो डेटा और वीडियो फ्रेम को दर्शाने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एंबेडेड वीडियो फ्रेम बनाएं**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो को एंबेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एंबेड करता है और परिणाम को सहेजता है। फ्रेम के निर्देशांक और आयाम पॉइंट में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं होता क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) प्रस्तुति के उपयोग के दौरान इसे लॉक रखता है।

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

आप एक स्थानीय वीडियो पथ को सीधे [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) को भी पास कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एंबेड करता है। प्रस्तुति को सहेजने तक वीडियो सुलभ रहना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **वीडियो वॉल्यूम को सटीक रूप से सेट करें**

Aspose.Slides for .NET 26.11 या बाद के संस्करण में, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) 0 से 100 तक की फ्लोटिंग‑पॉइंट प्रतिशत सेट करता है। जब [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) प्रीसेट बहुत मोटे होते हैं तो इसका उपयोग करें। उदाहरण के लिए, `75.5f` 75.5 % वॉल्यूम का अनुरोध करता है।

यह उदाहरण [Aspose.Slides for .NET](/slides/hi/net/installation/) 26.11 या बाद के संस्करण और एक स्थानीय `video.mp4` की आवश्यकता रखता है। यह वीडियो एंबेड करता है, स्पष्ट रूप से प्लेबैक को इनिशियलाइज़ करता है, प्रस्तुति को सहेजता है, और संग्रहीत प्रतिशत को फिर से पढ़ता है।

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

इनपुट को स्वयं वैध करें; सीमा के बाहर के मानों को अस्वीकार करने के लिए सेट्टर पर भरोसा न करें। Low, Medium और Loud प्रीसेट क्रमशः 26.11 में 20, 50 और 80 के बराबर हैं। प्रीसेट सेट करने से पहले का प्रतिशत बदल सकता है, इसलिए जब आपको सटीक मान चाहिए तो प्रतिशत को अंत में असाइन करें। स्पष्ट म्यूट सेटिंग के लिए [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) का उपयोग करें; शून्य संख्यात्मक मान और प्रीसेट enum एक ही स्थिति नहीं हैं।

लिंक्ड वीडियो को कॉन्फ़िगर करते समय भी [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) को स्पष्ट रूप से सेट करें, और उसकी मीडिया फ़ाइल को दर्शक के लिए उपलब्ध रखें। सहेजने और फिर खोलने से संग्रहीत सेटिंग सत्यापित होती है; वास्तविक प्लेबैक और आवाज़ प्रस्तुति प्लेयर और उसके ऑडियो सेटिंग पर निर्भर करती है।

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुति में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड पर एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। अन्य वीडियो उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) सेटिंग स्वचालित प्लेबैक का अनुरोध करती है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट पहुंच आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन होना चाहिए।

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

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमॉonstration को फुल‑स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) को `true` सेट करें।

यह उदाहरण प्रस्तुति खोलता है, पहली स्लाइड पर पहली [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) खोजता है, और फुल‑स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में पहली स्लाइड पर कम से कम एक मौजूदा वीडियो फ्रेम होना आवश्यक है।

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

फुल‑स्क्रीन प्लेबैक नियंत्रित करता है कि वीडियो कैसे प्रदर्शित हो। स्वतंत्र रूप से, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) तय करता है कि यह स्वचालित रूप से या क्लिक पर शुरू हो, और [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) नियंत्रित करता है कि यह दोहराया जाए या नहीं। शुरूआती व्यवहार चुनने के लिए प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा शुरूआती और लूप सेटिंग को बरकरार रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमॉonstration वीडियो को उसकी शुरुआत में लौटाना प्रस्तुतकर्ता को फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को उसकी शुरुआत में लौटाने के लिए [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) को `true` सेट करें।

यह उदाहरण प्रस्तुति खोलता है, पहली स्लाइड पर पहली [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) खोजता है, और रीवाइंडिंग सक्षम करता है। यह लूपिंग को अक्षम करता है ताकि प्लेबैक समाप्त हो सके और क्लिक पर शुरू होने के लिए प्लेबैक सेट करता है। इनपुट प्रस्तुति में पहली स्लाइड पर कम से कम एक मौजूदा वीडियो फ्रेम होना आवश्यक है।

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

रीवाइंडिंग वीडियो को उसकी शुरुआत में लौटाता है बिना इसे फिर से शुरू किए। इसके विपरीत, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को सक्षम करने से प्लेबैक स्वतः दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तो लूपिंग को अक्षम रखें। [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) स्वतंत्र रूप से स्वचालित या क्लिक‑पर स्टार्ट को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता तय कर सके कि प्लेबैक कब शुरू हो। लूप सेटिंग के बाद प्लेबैक मोड सेट करें, जैसा कि उदाहरण में दिखाया गया है। रीवाइंडिंग [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) से स्वतंत्र रूप से कार्य करता है।

## **वीडियो फ्रेम को ट्रिम करें**

प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को छोड़ने के लिए [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) और [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) का उपयोग करें। दोनों मान मिलिसेकंड में होते हैं। ट्रिमिंग प्लेबैक सेटिंग्स को बदलता है बिना एंबेडेड वीडियो डेटा को संशोधित किए।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण स्थानीय वीडियो एंबेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड तथा अंतिम एक सेकंड को छोड़ता है। प्लेबैक योग्य भाग बचा रहे, इसके लिए वीडियो को 3.5 सेकंड से अधिक लंबा रखें।

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

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलिसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ भी प्रिंट नहीं होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

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

Aspose.Slides आपको PowerPoint प्रस्तुति में वीडियो फ्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) प्रॉपर्टी के माध्यम से उपलब्ध होते हैं।

### **वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण स्थानीय वीडियो एंबेड करता है और "English" लेबल वाले WebVTT कैप्शन ट्रैक को जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो से मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

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

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) इंटरफ़ेस भी एक ओवरलोड प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने देता है।

### **एक वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमांकित फ़ाइल नाम आउटपुट को अलग रखता है। कंसोल निकाले गए ट्रैकों की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होना आवश्यक है।

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

प्रत्येक [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF‑8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट उजागर करता है।

### **एक वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप पोजीशन में वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम को सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और वह शेप एक वीडियो फ्रेम है।

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

### **वीडियो कैप्शन खोजें**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) पूरे WebVTT ट्रैक को लौटाता है, जिसमें हेडर, टाइमिंग लाइन और कैप्शन टेक्स्ट शामिल होता है। बोले गए वाक्यांश और उसका टाइमस्टैम्प खोजने के लिए मेमोरी में क्यूज़ पढ़ें। उदाहरण के लिए, स्लाइड 2 पर एक अंग्रेजी ट्रैक में निम्नलिखित टेक्स्ट हो सकता है:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

उदाहरण प्रत्येक स्लाइड पर जाता है और उसकी शीर्ष‑स्तर वीडियो फ्रेम की [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) के माध्यम से ट्रैक पढ़ता है। एक साधारण‑टेक्स्ट क्यू में टाइमिंग लाइन में `-->` होता है और एक खाली लाइन क्यू को समाप्त करती है। जब कैप्शन टेक्स्ट में “café” शब्द आता है, तो उदाहरण स्लाइड नंबर, ट्रैक लेबल, मूल टाइमिंग लाइन, और पूर्ण कैप्शन प्रिंट करता है।

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

“café” की खोज नमूना ट्रैक के लिए एक मेल देती है। हेडर और टाइमिंग सेटिंग क्यू टेक्स्ट के बाहर रहती हैं।

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुति में एंबेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एंबेडेड वीडियो को अलग‑अलग क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनमें एंबेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो के MIME प्रकार और कुल संख्या प्रिंट करता है। आउटपुट में सामान्य `.bin` एक्सटेंशन उपयोग किया जाता है; आवश्यकता पड़ने पर रिपोर्ट किए गए मीडिया प्रकार से मेल खाने के लिए इसे बदलें।

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

आप [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टी द्वारा उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार बढ़ता है?**

हां। जब आप स्थानीय वीडियो एंबेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो लिंक और थंबनेल जोड़ते हैं, तो प्रस्तुति वीडियो डेटा की बजाय लिंक और प्रीव्यू इमेज संग्रहीत करती है, इसलिए आकार वृद्धि आम तौर पर कम रहती है।

**क्या मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकते हैं?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) को बदल सकते हैं जबकि शेप की ज्यामिति बरकरार रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एंबेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एंबेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए डिस्क पर सहेजते समय।