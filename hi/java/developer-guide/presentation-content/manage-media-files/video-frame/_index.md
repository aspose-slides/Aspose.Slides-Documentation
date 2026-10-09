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
- वीडियो प्राप्त करें
- वीडियो फ्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ने और निकालने के बारे में सीखें। तेज़ कैसे-करें गाइड।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जुड़ाव प्रदान करने में मदद कर सकते हैं। Aspose.Slides for Java आपको स्लाइड्स में वीडियो फ्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक का समर्थन करता है।

वीडियो डेटा और वीडियो फ्रेम को दर्शाने के लिए, Aspose.Slides [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) इंटरफ़ेस, [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) इंटरफ़ेस, और अन्य संबंधित प्रकार प्रदान करता है।

## **एक एंबेडेड वीडियो फ्रेम बनाना**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एंबेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एंबेड करता है और परिणाम को सहेजता है। फ़्रेम के निर्देशांक और आयाम पॉइंट्स में हैं। स्ट्रीम सहेजने के पूर्ण होने तक खुला रहता है क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) प्रस्तुति द्वारा उपयोग किए जाने पर इसे लॉक रखता है।

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

आप स्थानीय वीडियो पथ को सीधे [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) को पास भी कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एंबेड करता है। वीडियो को तब तक सुलभ रहना चाहिए जब तक प्रस्तुति सहेजी नहीं जाती।

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

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ्रेम बनाना**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुतियों में ऑनलाइन वीडियो का समर्थन करता है। आप एक वीडियो फ्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से लिंक करता है।

यह उदाहरण पहली स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। किसी अन्य वीडियो के उपयोग के लिये वीडियो पहचानकर्ता को बदलें। [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) मेथड स्वचालित प्लेबैक का अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिये इंटरनेट कनेक्शन आवश्यक है। प्रस्तुति व्यूअर को भी ऑनलाइन वीडियो प्लेबैक का समर्थन होना चाहिए।

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

## **पूर्ण-स्क्रीन मोड में वीडियो चलाएँ**

एक ट्रेनिंग प्रस्तुति में, आप सॉफ्टवेयर डेमॉन्स्ट्रेशन को पूर्ण-स्क्रीन मोड में चला सकते हैं ताकि दर्शक विवरण देख सकें। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए `true` के साथ [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) खोजता है, और पूर्ण-स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौजूदा वीडियो फ्रेम हो।

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

पूर्ण-स्क्रीन प्लेबैक निर्धारित करता है कि वीडियो कैसे प्रदर्शित होता है। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) नियंत्रित करता है कि यह स्वचालित रूप से शुरू हो या क्लिक पर, और [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) नियंत्रित करता है कि यह दोहराए या नहीं। प्रारंभ व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा प्रारंभ और लूप सेटिंग को बरकरार रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक ट्रेनिंग प्रस्तुति में, डेमॉन्स्ट्रेशन वीडियो को उसकी शुरुआत पर लौटाना इसे फिर से चलाने के लिये तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरू में लौटाने के लिए `true` के साथ [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) को कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) खोजता है, और रीवाइंडिंग सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू होने के लिये सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए जिसमें पहली स्लाइड पर मौजूदा वीडियो फ्रेम हो।

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

रीवाइंडिंग वीडियो को उसकी शुरुआत पर लौटा देता है बिना उसे फिर से शुरू किए। इसके विपरीत, `true` के साथ [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को कॉल करने से प्लेबैक स्वचालित रूप से दोहराया जाता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः चलाने के लिए तैयार रहे, तो लूपिंग को निष्क्रिय रखें। [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) स्वतंत्र रूप से स्वचालित या क्लिक पर शुरूआत को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता नियंत्रण कर सके कि प्लेबैक कब शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) से स्वतंत्र रूप से कार्य करता है।

## **वीडियो फ्रेम को ट्रिम करें**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) और [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) का उपयोग करके आप प्लेबैक के दौरान वीडियो की शुरुआत या अंत का हिस्सा छोड़ सकते हैं। दोनों मान मिलीसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स को बदलती है।

**ट्रिम सेटिंग्स निर्धारित करें**

यह उदाहरण एक स्थानीय वीडियो एंबेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम सेकंड को छोड़ देता है। एक 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें ताकि एक चलाने योग्य हिस्सी बचा रहे।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ्रेम के ट्रिम मानों को मिलीसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ्रेम नहीं है, तो कुछ नहीं प्रिंट होता। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

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

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) मेथड के माध्यम से उपलब्ध होते हैं।

**वीडियो फ्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एंबेड करता है और English लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैम्प वीडियो के साथ मेल खाने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) इंटरफ़ेस भी एक ओवरलोड प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्याएँ आउटपुट फ़ाइलों को अलग रखती हैं। कंसोल निकाले गए ट्रैकों की संख्या दर्शाता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

प्रत्येक [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर प्रथम आकार स्थिति में मौजूद वीडियो फ्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार वीडियो फ्रेम है।

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

यदि आपको केवल एक ही कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--) की बजाय [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालें**

स्लाइड पर वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एंबेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एंबेडेड वीडियो को अलग-अलग, क्रमांकित बाइनरी फ़ाइलों में निकालता है। लिंक्ड वीडियो को छोड़ दिया जाता है क्योंकि उनमें एंबेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो का MIME प्रकार और कुल संख्या प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता पड़ने पर इसे रिपोर्ट किए गए मीडिया प्रकार से मेल खाने के लिए बदलें।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**एक वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) ऑब्जेक्ट की मेथड्स के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है?**

हाँ। जब आप एक स्थानीय वीडियो एंबेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और एक थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज को संग्रहीत करती है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हाँ। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) को बदल सकते हैं जबकि आकार की ज्यामिति को बरकरार रखते हैं; यह मौज़ूदा लेआउट में मीडिया को अपडेट करने का सामान्य परिदृश्य है।

**क्या एंबेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हाँ। एंबेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) होता है जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए जब इसे डिस्क पर सहेजा जाता है।