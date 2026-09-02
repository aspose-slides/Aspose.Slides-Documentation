---
title: जावा का उपयोग करके प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/java/video-frame/
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
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। तेज़ कैसे‑करें गाइड।"
---
## **परिचय**

प्रेजेंटेशन में सही जगह पर रखा गया वीडियो आपके संदेश को अधिक प्रभावशाली बना सकता है और आपके दर्शकों के साथ सहभागिता स्तर को बढ़ा सकता है।

PowerPoint दो तरीकों से प्रेजेंटेशन की एक स्लाइड में वीडियो जोड़ने की अनुमति देता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके मशीन पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (YouTube जैसे वेब स्रोत से)।

प्रेजेंटेशन में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **संलग्न वीडियो फ्रेम बनाएं**

यदि आप अपनी स्लाइड में जोड़ने वाला वीडियो फ़ाइल स्थानीय रूप से संग्रहीत है, तो आप अपने प्रेजेंटेशन में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. एक [IVideo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पाथ पास करके प्रेजेंटेशन में वीडियो एम्बेड करें।
4. एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए एक फ्रेम बनाया जा सके।  
5. परिवर्तित प्रेजेंटेशन को सहेजें।

यह Java कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रेजेंटेशन में कैसे जोड़ें:

```java
// Presentation क्लास का इंस्टैंस बनाता है
Presentation pres = new Presentation("pres.pptx");
try {
    // वीडियो लोड करता है
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // पहली स्लाइड प्राप्त करता है और वीडियोफ़्रेम जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // प्रेजेंटेशन को डिस्क पर सहेजता है
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

वैकल्पिक रूप से, आप वीडियो को सीधे उसका फ़ाइल पाथ पास करके [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) मेथड से जोड़ सकते हैं:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **वेब स्रोतों से वीडियो के साथ वीडियो फ्रेम बनाएं**

Microsoft [PowerPoint 2013 और नवीनतम संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) प्रेजेंटेशन में YouTube वीडियो का समर्थन करते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube), तो आप इसे अपनी प्रेजेंटेशन में वेब लिंक के माध्यम से जोड़ सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें। 
3. एक [IVideo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो का लिंक पास करें।
4. वीडियो फ्रेम के लिए थंबनेल सेट करें। 
5. प्रेजेंटेशन को सहेजें। 

यह Java कोड दिखाता है कि वेब से वीडियो को PowerPoint प्रेजेंटेशन की स्लाइड में कैसे जोड़ें:

```java
// एक Presentation ऑब्जेक्ट का इंस्टैंस बनाता है जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है 
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

Aspose.Slides आपको वीडियो के किस भाग को चलाया जाए यह नियंत्रण करने की अनुमति देता है, इसके लिए trim-from-start और trim-from-end मानों को [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) के माध्यम से सेट किया जाता है। दोनों मान मिलीसेकंड में निर्दिष्ट होते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितनी समय पहले छोड़ना है, यह परिभाषित करते हैं। ये सेटिंग्स प्रेजेंटेशन में वीडियो प्लेबैक सेटिंग्स बदलती हैं; वे एम्बेडेड वीडियो बाइनरी डेटा को नहीं काटती या संशोधित नहीं करतीं।

**ट्रिम सेटिंग्स निर्धारित करें**

एक वीडियो फ्रेम बनाने और उसकी ट्रिम सेटिंग्स निर्धारित करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. प्रेजेंटेशन में एक [IVideo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें।
3. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
4. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) के माध्यम से trim-from-start और trim-from-end मान सेट करें।
5. परिवर्तित प्रेजेंटेशन को सहेजें।

निम्न कोड उदाहरण एम्बेडेड वीडियो के पहले 2.5 सेकंड और अंतिम सेकंड को प्लेबैक के दौरान स्किप करता है:

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

मौज़ूदा ट्रिम सेटिंग्स की जांच करने के लिए, एक प्रेजेंटेशन लोड करें, पहले स्लाइड पर शैप्स में से एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें, और मानों को [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#getTrimFromStart--) और [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#getTrimFromEnd--) के माध्यम से पढ़ें।

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

Aspose.Slides PowerPoint प्रेजेंटेशनों में वीडियो फ्रेम के लिए बंद कैप्शन को प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

एक वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. प्रेजेंटेशन में एक वीडियो जोड़ें।
3. स्लाइड में एक [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
4. [getCaptionTracks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाई गई [ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/) का उपयोग करके WebVTT कैप्शन ट्रैक जोड़ें।
5. परिवर्तित प्रेजेंटेशन को सहेजें।

निम्न कोड आपको दिखाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
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

[ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/) इंटरफ़ेस में एक ओवरलोड भी उपलब्ध है जो स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाला प्रेजेंटेशन लोड करें।
2. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
3. [ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/) में कैप्शन ट्रैक्स पर इटरेट करें।
4. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड आपको दिखाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में प्रदर्शित करता है।

**वीडियो फ्रेम से कैप्शन हटाएं**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाला प्रेजेंटेशन लोड करें।
2. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
3. [ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/) से कैप्शन ट्रैक्स हटाएं।
4. परिवर्तित प्रेजेंटेशन को सहेजें।

निम्न कोड आपको दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएं:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // वीडियो फ्रेम से सभी कैप्शन हटाता है।
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#clear--) के बजाय [remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#removeAt-int-) मेथड का उपयोग करें।

## **स्लाइड्स से वीडियो निकालें**

स्लाइड्स में वीडियो जोड़ने के साथ-साथ, Aspose.Slides आपको प्रेजेंटेशनों में एम्बेडेड वीडियो निकालने की भी सुविधा देता है।

1. वीडियो वाला प्रेजेंटेशन लोड करने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं। 
2. सभी [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) ऑब्जेक्ट्स पर इटरेट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) ऑब्जेक्ट्स पर इटरेट करके एक [VideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoframe/) खोजें। 
4. वीडियो को डिस्क पर सहेजें।

यह Java कोड आपको दिखाता है कि प्रेजेंटेशन स्लाइड पर वीडियो कैसे निकालें:

```java
// एक Presentation ऑब्जेक्ट का इंस्टैंस बनाता है जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है 
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

                //फ़ाइल एक्सटेंशन प्राप्त करता है
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

## **अक्सर पूछे जाने वाले प्रश्न**

**VideoFrame के लिए कौन-से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoframe/#setPlayMode-int-) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है?**

हाँ। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, जिससे प्रेजेंटेशन का आकार फ़ाइल के आकार के अनुपात में बढ़ जाता है। जब आप ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) को बदल सकते हैं जबकि शेप की ज्योमेट्री बरकरार रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने का आम परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/video/#getContentType--) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।