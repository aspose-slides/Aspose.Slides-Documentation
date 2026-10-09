---
title: Android पर प्रेज़ेंटेशन में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/androidjava/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनर्प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ़्रेम जोड़ना और निकालना सीखें। तेज़ चरण-दर-चरण गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को आकर्षित करने में मदद कर सकते हैं। Aspose.Slides for Android via Java आपको स्लाइड्स में वीडियो फ़्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक का समर्थन करता है।

वीडियो डेटा और वीडियो फ़्रेम को दर्शाने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ़्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रेज़ेंटेशन में वीडियो एम्बेड करने के लिए एक वीडियो फ़्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रेज़ेंटेशन की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम को सहेजता है। फ़्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम तब तक खुला रहता है जब तक सहेजना समाप्त नहीं हो जाता, क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) प्रेज़ेंटेशन द्वारा उपयोग किए जाने पर इसे लॉक रखता है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आप स्थानीय वीडियो पथ को सीधे [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) में पास कर सकते हैं। यह उदाहरण नई प्रेज़ेंटेशन की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को तब तक सुलभ रहना चाहिए जब तक प्रेज़ेंटेशन सहेजा न जाए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ़्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रेज़ेंटेशन में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ़्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड पर एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो का उपयोग करने के लिए वीडियो पहचानकर्ता को बदलें। [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) मेथड स्वचालित प्लेबैक का अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रेज़ेंटेशन व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन करना चाहिए।

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वीडियो को फ़ुल-स्क्रीन मोड में चलाएँ**

एक प्रशिक्षण प्रेज़ेंटेशन में, आप दर्शकों को विवरण देखने के लिए फ़ुल-स्क्रीन मोड में सॉफ़्टवेयर डेमॉन्स्ट्रेशन चला सकते हैं। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए `true` के साथ [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) को कॉल करें।

यह उदाहरण प्रेज़ेंटेशन खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) खोजता है, और फ़ुल-स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रेज़ेंटेशन में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़ुल-स्क्रीन प्लेबैक निर्धारित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) यह नियंत्रित करता है कि यह स्वचालित रूप से या क्लिक पर शुरू होता है, और [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) यह नियंत्रित करता है कि यह दोहराया जाए या नहीं। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा शुरू और लूप सेटिंग्स को बनाए रखता है।

## **प्लेबैक के बाद वीडियो को रिवाइंड करें**

एक प्रशिक्षण प्रेज़ेंटेशन में, डेमॉन्स्ट्रेशन वीडियो को उसकी शुरुआत पर लौटाना इसे प्रस्तोता के फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिए `true` के साथ [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) को कॉल करें।

यह उदाहरण प्रेज़ेंटेशन खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) खोजता है, और रिवाइंड सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू होने के लिए सेट करता है। इनपुट प्रेज़ेंटेशन में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

रिवाइंडिंग वीडियो को उसकी शुरुआत में लौटाता है बिना उसे दोबारा शुरू किए। इसके विपरीत, `true` के साथ [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को कॉल करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और फिर से चलाने के लिए तैयार रहे, तो लूपिंग को निष्क्रिय रखें। [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) स्वतंत्र रूप से स्वचालित या क्लिक पर आरंभ को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तोता तय कर सके कि प्लेबैक कब शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रिवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) से स्वतंत्र रूप से काम करता है।

## **वीडियो फ़्रेम को ट्रिम करें**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के भाग को छोड़ सकते हैं। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स बदलता है।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम सेकंड को छोड़ देता है। एक प्लेएबल सेगमेंट बचाने के लिए 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ़्रेम के ट्रिम मान को मिलीसेकंड में प्रिंट करता है। प्रेज़ेंटेशन में कम से कम एक स्लाइड होना चाहिए। यदि उस स्लाइड में कोई वीडियो फ़्रेम नहीं है, तो कुछ नहीं प्रिंट होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रेज़ेंटेशन में वीडियो फ़्रेम के लिए बंद कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ़्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और 'English' लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैंप वीडियो से मिलते होने चाहिए। सहेजे गए प्रेज़ेंटेशन में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) इंटरफ़ेस एक ओवरलोड भी प्रदान करता है जो आपको स्ट्रीम से कैप्शन जोड़ने की अनुमति देता है।

**वीडियो फ़्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ़्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्या आउटपुट फ़ाइलों को अलग रखती है। कंसोल निकाले गए ट्रैकों की संख्या रिपोर्ट करता है। प्रेज़ेंटेशन में कम से कम एक स्लाइड होना चाहिए।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट प्रदान करता है।

**वीडियो फ़्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप पॉज़िशन में वीडियो फ़्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ़्रेम है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) के बजाय [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रेज़ेंटेशन में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो को अलग-अलग क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक किए गए वीडियो को छोड दिया जाता है क्योंकि उनके पास एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल गिनती प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता पर रिपोर्ट किए गए मीडिया प्रकार से मेल खाने के लिए इसे बदलें।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक वीडियो फ़्रेम के लिए किन वीडियो प्लेबैक पैरामीटरों को बदला जा सकता है?**

आप [प्लेबैक मोड](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (स्वचालित या क्लिक पर) और [लूपिंग](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) ऑब्जेक्ट की मेथड्स के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल का आकार प्रभावित होता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रेज़ेंटेशन का आकार फ़ाइल आकार के अनुसार बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रेज़ेंटेशन लिंक और प्रीव्यू इमेज को संग्रहीत करता है न कि वीडियो डेटा को, इसलिए आकार वृद्धि आम तौर पर छोटी होती है।

**क्या मैं मौजूदा वीडियो फ़्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूं?**

हां। आप फ्रेम के भीतर [वीडियो सामग्री](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) को बदल सकते हैं जबकि शेप की ज्यामिति को संरक्षित रखते हैं; यह मौजूदा लेआउट में मीडिया अपडेट करने का एक सामान्य परिदृश्य है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एक एम्बेडेड वीडियो का एक [कंटेंट टाइप](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।