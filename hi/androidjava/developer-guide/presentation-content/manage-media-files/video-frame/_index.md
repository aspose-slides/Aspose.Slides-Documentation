---
title: Android पर प्रस्तुतियों में वीडियो फ्रेम प्रबंधित करें
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
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument स्लाइड्स में वीडियो फ्रेम को प्रोग्रामेटिक रूप से जोड़ना और निकालना सीखें। त्वरित मार्गदर्शिका।"
---
## **परिचय**

एक अच्छी तरह से रखी गई वीडियो प्रस्तुति में आपके संदेश को अधिक प्रभावी बना सकती है और आपके दर्शकों के साथ सहभागिता स्तर बढ़ा सकती है।

PowerPoint आपको प्रस्तुति में एक स्लाइड में वीडियो जोड़ने के दो तरीके प्रदान करता है:

* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके मशीन पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (YouTube जैसे वेब स्रोत से)।

एक प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides निम्नलिखित इंटरफ़ेस प्रदान करता है: [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार।

## **एंबेडेड वीडियो फ्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप वीडियो को अपनी प्रस्तुति में एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. उसकी सूचकांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. एक [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ को पास करके वीडियो को प्रस्तुति में एम्बेड करें।
4. वीडियो के लिए फ्रेम बनाने हेतु एक [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
5. संशोधित प्रस्तुति को सहेजें।

यह Java कोड दर्शाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```java
// Presentation क्लास का उदाहरण बनाता है
Presentation pres = new Presentation("pres.pptx");
try {
    // वीडियो लोड करता है
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // पहली स्लाइड प्राप्त करता है और एक वीडियो फ़्रेम जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

वैकल्पिक रूप से, आप वीडियो को सीधे उसकी फ़ाइल पथ को पास करके [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) मेथड को कॉल करके जोड़ सकते हैं:

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

Microsoft [PowerPoint 2013 और बाद के संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) समर्थन करता है यूट्यूब वीडियो को प्रस्तुतियों में। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है (जैसे YouTube पर), तो आप इसे अपनी प्रस्तुति में उसके वेब लिंक के माध्यम से जोड़ सकते हैं।

1. [Presentation ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. उसकी सूचकांक के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
3. एक [IVideo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideo/) ऑब्जेक्ट जोड़ें और वीडियो के लिंक को पास करें।
4. वीडियो फ्रेम के लिए थंबनेल सेट करें।
5. प्रस्तुति को सहेजें।

यह Java कोड दर्शाता है कि वेब से वीडियो कैसे जोड़ें और PowerPoint प्रस्तुति में एक स्लाइड में डालें:

```java
// एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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
    // एक वीडियो फ़्रेम जोड़ता है
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

## **वीडियो कैप्शन प्रबंधन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT प्रारूप में संग्रहीत होते हैं और [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. प्रस्तुति में एक वीडियो जोड़ें।
3. एक स्लाइड में [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट जोड़ें।
4. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए [ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) का उपयोग करके WebVTT कैप्शन ट्रैक जोड़ें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // एक नई कैप्शन ट्रैक को WebVTT फ़ाइल से जोड़ता है।
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ्रेम से कैप्शन निकालें**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।
2. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट खोजें।
3. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए कैप्शन ट्रैक्स पर इटरैट करें।
4. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
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

प्रत्येक [ICaptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन डेटा को UTF-8 स्ट्रिंग के रूप में प्रदर्शित करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वीडियो वाली प्रस्तुति को लोड करें।
2. लक्षित [IVideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/) ऑब्जेक्ट प्राप्त करें।
3. [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) द्वारा लौटाए गए संग्रह से कैप्शन ट्रैक्स हटाएँ।
4. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित कोड दर्शाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // वीडियो फ़्रेम से सभी कैप्शन हटाता है।
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#clear--) के बजाय [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।

1. वीडियो वाली प्रस्तुति को लोड करने हेतु [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. सभी [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) ऑब्जेक्ट्स पर इटरैट करें।
3. सभी [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) ऑब्जेक्ट्स पर इटरैट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/) मिले।
4. वीडियो को डिस्क पर सहेजें।

यह Java कोड दर्शाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```java
// एक Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
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

## **अक्सर पूछे जाने वाले प्रश्न**

**वीडियो फ्रेम के लिए कौन से प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है क्या?**

हाँ। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, जिससे प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ता है। जब आप एक ऑनलाइन वीडियो जोड़ते हैं, तो एक लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) को बदल सकते हैं जबकि आकार-रूप की ज्यामिति को बरकरार रख सकते हैं; यह मौजूदा लेआउट में मीडिया को अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/video/#getContentType--) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के तौर पर इसे डिस्क पर सहेजते समय।