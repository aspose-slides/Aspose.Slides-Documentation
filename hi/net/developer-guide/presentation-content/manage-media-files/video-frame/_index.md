---
title: .NET में प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/net/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एंबेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड में प्रोग्रामेटिक रूप से वीडियो फ़्रेम जोड़ने और निकालने को सीखें। तेज़ गाइड।"
---
## **परिचय**

एक अच्छी तरह से रखी गई वीडियो प्रस्तुति में आपके संदेश को अधिक प्रभावी बना सकती है और आपके दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकती है।

PowerPoint आपको प्रस्तुति में एक स्लाइड में वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एंबेड करें (आपके मशीन पर संग्रहीत)
* वेब स्रोत जैसे YouTube से ऑनलाइन वीडियो जोड़ें।

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एंबेडेड वीडियो फ़्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो को प्रस्तुति में एंबेड करने के लिए एक वीडियो फ़्रेम बना सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)क्लास की इंस्टेंस बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
1. एक [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति में एंबेड करें। 
1. वीडियो के लिए फ़्रेम बनाने हेतु एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।  
1. परिवर्तित प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```c#
// Presentation वर्ग का इंस्टेंस बनाता है
using (Presentation pres = new Presentation("pres.pptx"))
{
    // वीडियो लोड करता है
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // पहली स्लाइड प्राप्त करता है और एक वीडियोफ़्रेम जोड़ता है
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // प्रस्तुति को डिस्क पर सहेजता है
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
वैकल्पिक रूप से, आप वीडियो फ़ाइल पथ को सीधे [AddVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addvideoframe/) मेथड में पास करके वीडियो जोड़ सकते हैं:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ़्रेम बनाएं**
नए संस्करणों के Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) में प्रस्तुतियों में ऑनलाइन वीडियो का समर्थन किया जाता है। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (उदाहरण के लिए YouTube पर), तो आप उसे वेब लिंक के माध्यम से अपनी प्रस्तुति में जोड़ सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)क्लास की इंस्टेंस बनाएं
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
1. एक [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ़्रेम के लिए थंबनेल सेट करें। 
1. प्रस्तुति को सहेजें। 

यह C# कोड दिखाता है कि वेब से वीडियो को PowerPoint प्रस्तुति की स्लाइड में कैसे जोड़ें:

```c#
public static void Run()
{
    // प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट इंस्टैंसिएट करता है
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // एक VideoFrame जोड़ता है
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // थंबनेल लोड करता है
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **वीडियो फ़्रेम को ट्रिम करें**

Aspose.Slides आपको वीडियो के चलने वाले भाग को नियंत्रित करने की अनुमति देता है, जिसमें आप [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromstart/) और [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromend/) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट कर सकते हैं। दोनों मान मिलिसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितनी देर छोड़ी जाए, यह परिभाषित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; वे एंबेडेड वीडियो बाइनरी डेटा को काटती या संशोधित नहीं करतीं।

**ट्रिम सेटिंग्स सेट करें**

एक वीडियो फ़्रेम बनाने और उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. प्रस्तुति में एक [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें।
1. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromstart/) और [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromend/) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट करें।
1. परिवर्तित प्रस्तुति को सहेजें।

निम्न कोड उदाहरण एंबेडेड वीडियो के प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम सेकंड को छोड़ देता है:

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स देखने के लिए, एक प्रस्तुति लोड करें, पहली स्लाइड पर शेप्स में से एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें, और [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromstart/) तथा [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/trimfromend/) के माध्यम से मान पढ़ें।

निम्न कोड उदाहरण पहली स्लाइड पर पहला वीडियो फ़्रेम खोजता है और उसके ट्रिम सेटिंग्स को मिलिसेकंड में रिपोर्ट करता है:

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ़्रेम के लिए बंद कैप्शन (Closed Captions) प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT प्रारूप में संग्रहीत होते हैं और उन्हें [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) प्रॉपर्टी के माध्यम से एक्सपोज़ किया जाता है।

**वीडियो फ़्रेम में कैप्शन जोड़ें**

एक वीडियो फ़्रेम में कैप्शन जोड़ने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की इंस्टेंस बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. WebVTT कैप्शन ट्रैक जोड़ने के लिए [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) संग्रह का उपयोग करें।
1. परिवर्तित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ़्रेम में कैप्शन कैसे जोड़ें:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/) इंटरफ़ेस भी एक ओवरलोड प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ़्रेम से कैप्शन निकालें**

एक वीडियो फ़्रेम से कैप्शन निकालने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो मौजूद है।
1. लक्ष्य [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
1. [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) संग्रह पर इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दिखाता है कि वीडियो फ़्रेम से कैप्शन कैसे निकालें:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में उजागर करता है।

**वीडियो फ़्रेम से कैप्शन हटाएं**

एक वीडियो फ़्रेम से कैप्शन हटाने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो है।
1. लक्ष्य [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) संग्रह से कैप्शन ट्रैक हटाएँ।
1. परिवर्तित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि सभी कैप्शन को वीडियो फ़्रेम से कैसे हटाएँ:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // वीडियो फ़्रेम से सभी कैप्शन हटाता है।
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/removeat/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**
वीडियो को स्लाइड में जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एंबेडेड वीडियो को निकालने की अनुमति भी देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की इंस्टेंस बनाकर उस प्रस्तुति को लोड करें जिसमें वीडियो है। 
2. सभी [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) ऑब्जेक्ट्स के माध्यम से इटररेट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) ऑब्जेक्ट्स के माध्यम से इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe) मिल सके। 
4. वीडियो को डिस्क पर सहेजें।

यह C# कोड दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```c#
 // प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट इंस्टैंसिएट करता है 
 Presentation presentation = new Presentation("Video.pptx");

 // स्लाइड्स के माध्यम से इटररेट करता है
 foreach (ISlide slide in presentation.Slides)
 {
     // शैलियों के माध्यम से इटररेट करता है
     foreach (IShape shape in presentation.Slides[0].Shapes)
     {
         // जब वीडियो वाले VideoFrame का पता चल जाए तो वीडियो को डिस्क पर सहेजता है
         if (shape is VideoFrame)
         {
             IVideoFrame vf = shape as IVideoFrame;
             String type = vf.EmbeddedVideo.ContentType;
             int ss = type.LastIndexOf('/');
             type = type.Remove(0, type.LastIndexOf('/') + 1);
             Byte[] buffer = vf.EmbeddedVideo.BinaryData;
             using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
             {                                                     
                 stream.Write(buffer, 0, buffer.Length);
             }
         }
     }
 }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक VideoFrame के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/playmode/) (स्वचालित या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप एक स्थानीय वीडियो एंबेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एंबेड किया जाता है, इसलिए आकार वृद्धि छोटी होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ़्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/embeddedvideo/) को बदल सकते हैं जबकि शेप की ज्यामिति बरकरार रहती है; यह मौजूदा लेआउट में मीडिया को अपडेट करने का सामान्य परिदृश्य है।

**क्या एंबेडेड वीडियो के कंटेंट टाइप (MIME) का पता लगाया जा सकता है?**

हां। एंबेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/net/aspose.slides/video/contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए इसे डिस्क पर सहेजते समय।