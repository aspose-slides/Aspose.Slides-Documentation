---
title: Android पर प्रस्तुतियों में वीडियो फ्रेम को प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने का तेज़ गाइड।"
---
## **परिचय**

एक सही तरीके से रखी गई वीडियो प्रस्तुति में आपके संदेश को अधिक प्रभावी बना सकती है और आपके दर्शकों के सहभागिता स्तर को बढ़ा सकती है।

PowerPoint दो तरीकों से प्रस्तुति में स्लाइड पर वीडियो जोड़ने की अनुमति देता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके कंप्यूटर पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (YouTube जैसी वेब स्रोत से)

आपको प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) इंटरफ़ेस और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एम्बेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो को एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. एक [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पाथ पास करके प्रस्तुति में वीडियो एम्बेड करें।
1. एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए फ़्रेम बनाया जा सके।
1. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दर्शाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```java
// Presentation क्लास का इंस्टेंशन करता है
Presentation pres = new Presentation("pres.pptx");
try {
    // वीडियो लोड करता है
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // पहली स्लाइड प्राप्त करता है और एक वीडियोफ़्रेम जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

वैकल्पिक रूप से, आप वीडियो फ़ाइल पाथ सीधे नीचे दिखाए गए मेथड में पास करके वीडियो जोड़ सकते हैं: [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-):

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) के नए संस्करण प्रस्तुतियों में ऑनलाइन वीडियो को समर्थन देते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube), तो आप उसकी वेब लिंक के माध्यम से इसे अपनी प्रस्तुति में जोड़ सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं
1. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
1. एक [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
1. वीडियो फ्रेम के लिए एक थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

यह Java कोड दर्शाता है कि वेब से वीडियो को PowerPoint स्लाइड में कैसे जोड़ें:

```java
// एक Presentation ऑब्जेक्ट को इंस्टेंशिएट करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // एक videoFrame जोड़ता है
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // थंबनेल लोड करता है
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **वीडियो फ्रेम को ट्रिम करें**

Aspose.Slides आपको वीडियो के कौन से हिस्से को चलाया जाए, यह नियंत्रित करने की सुविधा देता है। आप [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट कर सकते हैं। दोनों मान मिलीसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितना समय छोड़ा जाए, यह निर्धारित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; वे एम्बेडेड वीडियो बाइनरी डेटा को नहीं काटती या बदलती हैं।

**ट्रिम सेटिंग्स सेट करें**

एक वीडियो फ्रेम बनाकर उसकी ट्रिम सेटिंग्स सेट करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. प्रस्तुति में एक [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें।
1. एक स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) के माध्यम से ट्रिम-फ़्रॉम-स्टार्ट और ट्रिम-फ़्रॉम-एंड मान सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड उदाहरण एम्बेडेड वीडियो के पहले 2.5 सेकंड और अंतिम एक सेकंड को प्लेबैक के दौरान स्किप करता है:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स को जांचने के लिए, प्रस्तुति लोड करें, पहले स्लाइड पर मौजूद आकारों में से एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें, और [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) तथा [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--) के माध्यम से मान पढ़ें।

निम्न कोड उदाहरण पहले स्लाइड पर पहला वीडियो फ्रेम खोजता है और उसकी ट्रिम सेटिंग्स को मिलीसेकंड में रिपोर्ट करता है:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन (closed captions) प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और उन्हें [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) मेथड के माध्यम से एक्सेस किया जा सकता है।

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
1. प्रस्तुति में वीडियो जोड़ें।
1. एक स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए [ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) का उपयोग करके एक WebVTT कैप्शन ट्रैक जोड़ें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो है।
1. लक्ष्य [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए कैप्शन ट्रैक्स पर इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // WebVTT फ़ाइल में कैप्शन ट्रैक को सहेजता है।
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा और UTF-8 स्ट्रिंग के रूप में कैप्शन डेटा को एक्सपोज़ करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो है।
1. लक्ष्य [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
1. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए कलेक्शन से कैप्शन ट्रैक्स हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दर्शाता है कि सभी कैप्शन को वीडियो फ्रेम से कैसे हटाएँ:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // वीडियो फ्रेम से सभी कैप्शन हटाता है।
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#clear--) के बजाय [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की भी अनुमति देता है।

1. वह प्रस्तुति लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं जिसमें वीडियो हो।
2. सभी [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) ऑब्जेक्ट्स पर इटररेट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट्स पर इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/) मिल सके।
4. वीडियो को डिस्क पर सहेजें।

यह Java कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकाला जाए:

```java
// एक Presentation ऑब्जेक्ट को इंस्टेंशिएट करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // फ़ाइल एक्सटेंशन प्राप्त करता है
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**एक VideoFrame के लिए किन वीडियो प्लेबैक पैरामीटर को बदला जा सकता है?**

आप [playback mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (ऑटो या ऑन क्लिक) और [looping](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) को बदल सकते हैं जबकि आकार और स्थान बरकरार रख सकते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) को निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/video/#getContentType--) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, जैसे कि इसे डिस्क पर सहेजते समय।