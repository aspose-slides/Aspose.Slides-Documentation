---
title: ".NET में प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें"
linktitle: "वीडियो फ़्रेम"
type: docs
weight: 10
url: /hi/net/video-frame/
keywords:
- "वीडियो जोड़ें"
- "वीडियो बनाएं"
- "वीडियो एम्बेड करें"
- "वीडियो निकालें"
- "वीडियो पुनः प्राप्त करें"
- "वीडियो फ़्रेम"
- "वेब स्रोत"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ़्रेम जोड़ने और निकालने की तेज़ How‑To गाइड सीखें।"
---
## **परिचय**

एक अच्छी तरह से रखी गई वीडियो प्रस्तुति में आपके संदेश को अधिक आकर्षक बना सकती है और आपके दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकती है।

PowerPoint आपको प्रस्तुति में एक स्लाइड पर वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (जो आपके कंप्यूटर पर संग्रहीत है)
* ऑनलाइन वीडियो जोड़ें (जैसे YouTube जैसे वेब स्रोत से)।

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने की सुविधा देने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ़्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ़्रेम बना सकते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. एक [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति के साथ एम्बेड करें।
1. एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए फ़्रेम बनाया जा सके।  
1. संशोधित प्रस्तुति को सहेजें।

यह C# कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```c#
// Presentation क्लास का एक उदाहरण बनाता है
using (Presentation pres = new Presentation("pres.pptx"))
{
    // वीडियो लोड करता है
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // पहली स्लाइड प्राप्त करता है और वीडियोफ़्रेम जोड़ता है
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // प्रस्तुति को डिस्क पर सहेजता है
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
वैकल्पिक रूप से, आप वीडियो को सीधे उसके फ़ाइल पथ को [AddVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addvideoframe/) मेथड में पास करके जोड़ सकते हैं:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ़्रेम बनाएं**
Microsoft [PowerPoint 2013 और नवीनतम संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रस्तुतियों में YouTube वीडियो का समर्थन करते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (उदाहरण के लिए YouTube पर), तो आप इसे उसके वेब लिंक के माध्यम से अपनी प्रस्तुति में जोड़ सकते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक उदाहरण बनाएं
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
1. एक [IVideo](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो के लिंक को पास करें।
1. वीडियो फ़्रेम के लिए थंबनेल सेट करें। 
1. प्रस्तुति को सहेजें। 

यह C# कोड दर्शाता है कि वेब से वीडियो को PowerPoint प्रस्तुति में स्लाइड पर कैसे जोड़ें:

```c#
public static void Run()
{
    // एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

## **वीडियो कैप्शन प्रबंधन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ़्रेम के बंद कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) प्रॉपर्टी के माध्यम से उपलब्ध होते हैं।

**वीडियो फ़्रेम में कैप्शन जोड़ें**

वीडियो फ़्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. वेबVTT कैप्शन ट्रैक जोड़ने के लिए [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) कलेक्शन का प्रयोग करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दर्शाता है कि वीडियो फ़्रेम में कैप्शन कैसे जोड़ें:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // WebVTT फ़ाइल से एक नई कैप्शन ट्रैक जोड़ता है।
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने देता है।

**वीडियो फ़्रेम से कैप्शन निकालें**

वीडियो फ़्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
1. [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) कलेक्शन के माध्यम से इटरेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दर्शाता है कि वीडियो फ़्रेम से कैप्शन कैसे निकालें:

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

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/net/aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रदान करता है।

**वीडियो फ़्रेम से कैप्शन हटाएँ**

वीडियो फ़्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति लोड करें।
1. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionTracks](https://reference.aspose.com/slides/hi/net/aspose.slides/ivideoframe/captiontracks/) कलेक्शन से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दर्शाता है कि वीडियो फ़्रेम से सभी कैप्शन कैसे हटाएँ:

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

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/clear/) के बजाय [Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/remove/) या [RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides/captionscollection/removeat/) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**
स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेड किए गए वीडियो निकालने की सुविधा देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं। 
2. सभी [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) ऑब्जेक्ट्स के माध्यम से इटरेट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/net/aspose.slides/ishape) ऑब्जेक्ट्स के माध्यम से इटरेट करके एक [VideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe) खोजें। 
4. वीडियो को डिस्क पर सहेजें।

यह C# कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```c#
// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
Presentation presentation = new Presentation("Video.pptx");

// स्लाइड्स के माध्यम से इटरेट करता है
foreach (ISlide slide in presentation.Slides)
{
    // शेप्स के माध्यम से इटरेट करता है
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // जब वीडियो वाले VideoFrame को पाया जाता है तो वीडियो को डिस्क पर सहेजता है
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

**वीडियो फ़्रेम के लिए किन वीडियो प्लेबैक पैरामीटरों को बदला जा सकता है?**

आप [playback mode](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/playmode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/playloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/net/aspose.slides/videoframe/embeddedvideo/) को बदल सकते हैं जबकि आकार-रूप को बनाए रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो के पास एक [content type](https://reference.aspose.com/slides/hi/net/aspose.slides/video/contenttype/) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब आप उसे डिस्क पर सहेजते हैं।