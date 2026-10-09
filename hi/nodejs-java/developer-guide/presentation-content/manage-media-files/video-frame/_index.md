---
title: Node.js का उपयोग करके प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/nodejs-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ़्रेम जोड़ने और निकालने के बारे में जानें। तेज़ मार्गदर्शिका।"
---
## **परिचय**

वीडियो विचारों को समझाने और दर्शकों को जोड़ने में मदद कर सकते हैं। Aspose.Slides for Node.js via Java आपको स्लाइड्स में वीडियो फ़्रेम जोड़ने, प्लेबैक सेटिंग्स समायोजित करने, कैप्शन प्रबंधित करने और एम्बेडेड वीडियो डेटा निकालने की सुविधा देता है।

PowerPoint स्थानीय वीडियो और ऑनलाइन वीडियो, जैसे YouTube वीडियो, के लिंक को सपोर्ट करता है।

To represent video data and video frames, Aspose.Slides provides the [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) class, [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) class, and other relevant types.

## **एक एम्बेडेड वीडियो फ़्रेम बनाएं**

यदि वह वीडियो फ़ाइल जिसे आप अपनी स्लाइड में जोड़ना चाहते हैं स्थानीय रूप से संग्रहीत है, तो आप एक वीडियो फ़्रेम बना सकते हैं ताकि वीडियो को अपनी प्रस्तुति में एम्बेड किया जा सके।

यह उदाहरण मौजूदा प्रस्तुति की पहली स्लाइड पर एक स्थानीय वीडियो एम्बेड करता है और परिणाम को सहेजता है। फ़्रेम के निर्देशांक और आयाम पॉइंट्स में होते हैं। स्ट्रीम सहेजे जाने तक खुला रहता है क्योंकि [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) इसे लॉक रखता है जब तक प्रस्तुति इसे उपयोग करती है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

आप स्थानीय वीडियो पाथ को सीधे [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/) में पास भी कर सकते हैं। यह उदाहरण नई प्रस्तुति की पहली स्लाइड पर वीडियो एम्बेड करता है। वीडियो को तब तक सुलभ रहना चाहिए जब तक प्रस्तुति सहेजी नहीं जाती।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **वेब स्रोत से वीडियो के साथ एक वीडियो फ़्रेम बनाएं**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) प्रस्तुति में ऑनलाइन वीडियो को सपोर्ट करता है। आप एक वीडियो फ़्रेम बना सकते हैं जो ऑनलाइन वीडियो, जैसे YouTube वीडियो, से जुड़ा हो।

यह उदाहरण पहली स्लाइड में एक YouTube वीडियो लिंक और थंबनेल जोड़ता है। अन्य वीडियो उपयोग करने के लिए वीडियो पहचानकर्ता बदलें। [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) मेथड स्वचालित प्लेबैक के लिए अनुरोध करता है। थंबनेल डाउनलोड करने और वीडियो चलाने के लिए इंटरनेट एक्सेस आवश्यक है। प्रस्तुति दर्शक को भी ऑनलाइन वीडियो प्लेबैक को सपोर्ट करना चाहिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **पूरा स्क्रीन मोड में वीडियो चलाएं**

एक प्रशिक्षण प्रस्तुति में, आप सॉफ़्टवेयर डेमोंस्ट्रेशन को पूरा स्क्रीन मोड में चला सकते हैं ताकि दर्शकों को विवरण दिखे। प्लेबैक के दौरान इस व्यवहार को सक्षम करने के लिए [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) को `true` के साथ कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) खोजता है, और पूरा स्क्रीन प्लेबैक सक्षम करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पूरा स्क्रीन प्लेबैक यह नियंत्रित करता है कि वीडियो कैसे प्रदर्शित हो। स्वतंत्र रूप से, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) यह निर्धारित करता है कि यह स्वतः शुरू हो या क्लिक पर, और [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) यह निर्धारित करता है कि यह दोहराए। शुरूआत व्यवहार चुनने के लिए, प्लेबैक मोड को [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) पर सेट करें। उदाहरण मौजूदा शुरू और लूप सेटिंग्स को बरकरार रखता है।

## **प्लेबैक के बाद वीडियो को रीवाइंड करें**

एक प्रशिक्षण प्रस्तुति में, डेमोंस्ट्रेशन वीडियो को उसकी शुरुआत में लौटाना इसे प्रस्तुतकर्ता द्वारा फिर से चलाने के लिए तैयार करता है। प्लेबैक समाप्त होने के बाद वीडियो को शुरुआत में लौटाने के लिए [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) को `true` के साथ कॉल करें।

यह उदाहरण एक प्रस्तुति खोलता है, पहली स्लाइड पर पहला [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) खोजता है, और रीवाइंडिंग सक्षम करता है। यह लूपिंग को निष्क्रिय करता है ताकि प्लेबैक समाप्त हो सके और प्लेबैक को क्लिक पर शुरू करने के लिए सेट करता है। इनपुट प्रस्तुति में कम से कम एक स्लाइड में पहली स्लाइड पर मौजूदा वीडियो फ़्रेम होना चाहिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

रीवाइंडिंग वीडियो को उसकी शुरुआत में ले जाता है बिना उसे फिर से शुरू किए। इसके विपरीत, [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) को `true` के साथ कॉल करने से प्लेबैक स्वचालित रूप से दोहराता है। जब आप चाहते हैं कि वीडियो समाप्त हो और पुनः प्ले करने के लिए तैयार रहे, तो लूपिंग को निष्क्रिय रखें। [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) स्वतंत्र रूप से स्वचालित या क्लिक पर स्टार्टअप को नियंत्रित करता है; यह उदाहरण [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) का उपयोग करता है ताकि प्रस्तुतकर्ता तय कर सके कब प्लेबैक शुरू हो। जैसा कि उदाहरण में दिखाया गया है, लूप सेटिंग के बाद प्लेबैक मोड सेट करें। रीवाइंडिंग [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) से स्वतंत्र रूप से कार्य करता है।

## **वीडियो फ़्रेम को ट्रिम करें**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) का उपयोग करके प्लेबैक के दौरान वीडियो की शुरुआत या अंत के हिस्से को स्किप किया जा सकता है। दोनों मान मिलिसेकंड में होते हैं। ट्रिमिंग एम्बेडेड वीडियो डेटा को बदले बिना प्लेबैक सेटिंग्स बदलता है।

**ट्रिम सेटिंग्स सेट करें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और प्लेबैक के दौरान पहले 2.5 सेकंड और अंतिम एक सेकंड को स्किप करता है। एक 3.5 सेकंड से अधिक लंबा वीडियो उपयोग करें ताकि एक चलाने योग्य भाग बचा रहे।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

यह उदाहरण पहली स्लाइड पर पहले वीडियो फ़्रेम के ट्रिम मान को मिलिसेकंड में प्रिंट करता है। प्रस्तुति में कम से कम एक स्लाइड होनी चाहिए। यदि उस स्लाइड में कोई वीडियो फ़्रेम नहीं है, तो कुछ भी प्रिंट नहीं होगा। पूर्ववर्ती उदाहरण 2500 और 1000 मान उत्पन्न करता है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ़्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने की अनुमति देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से एक्सपोज़ किए जाते हैं।

**वीडियो फ़्रेम में कैप्शन जोड़ें**

यह उदाहरण एक स्थानीय वीडियो एम्बेड करता है और English लेबल वाला WebVTT कैप्शन ट्रैक जोड़ता है। कैप्शन टाइमस्टैंप वीडियो के अनुसार होने चाहिए। सहेजी गई प्रस्तुति में वीडियो और उसके कैप्शन दोनों शामिल होते हैं।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) क्लास [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) मेथड भी प्रदान करता है जो स्ट्रीम से कैप्शन जोड़ने के लिए है।

**वीडियो फ़्रेम से कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर वीडियो फ़्रेम से सभी कैप्शन ट्रैक को अलग-अलग WebVTT फ़ाइलों के रूप में सहेजता है। क्रमिक संख्या आउटपुट फ़ाइलों को अलग रखती है। कंसोल निकाले गए ट्रैकों की संख्या रिपोर्ट करता है। प्रस्तुति में कम से कम एक स्लाइड होना चाहिए।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

प्रत्येक [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में एक्सपोज़ करता है।

**वीडियो फ़्रेम से कैप्शन हटाएँ**

यह उदाहरण पहली स्लाइड पर पहले शेप पोज़ीशन पर वीडियो फ़्रेम से सभी कैप्शन हटाता है और परिणाम सहेजता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक वीडियो फ़्रेम है।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें बजाय [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) के।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो निकालने की सुविधा देता है।

यह उदाहरण प्रत्येक स्लाइड से एम्बेडेड वीडियो निकालकर अलग-अलग क्रमांकित बाइनरी फ़ाइलों में सहेजता है। लिंक्ड वीडियो को स्किप किया जाता है क्योंकि उनमें एम्बेडेड डेटा नहीं होता। कंसोल प्रत्येक वीडियो के MIME प्रकार और कुल गिनती प्रिंट करता है। आउटपुट सामान्य `.bin` एक्सटेंशन का उपयोग करता है; आवश्यकता पड़ने पर इसे रिपोर्टेड मीडिया टाइप से मिलाने के लिए बदलें।

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**एक वीडियो फ़्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट के मेथड्स के माध्यम से उपलब्ध हैं।

**क्या वीडियो जोड़ने से PPTX फ़ाइल आकार प्रभावित होता है?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल आकार के अनुपात में बढ़ जाता है। जब आप ऑनलाइन वीडियो को लिंक करते हैं और थंबनेल जोड़ते हैं, तो प्रस्तुति लिंक और प्रीव्यू इमेज संग्रहीत करती है, न कि वीडियो डेटा, इसलिए आकार वृद्धि आमतौर पर कम होती है।

**क्या मैं मौजूदा वीडियो फ़्रेम में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ़्रेम के भीतर [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) को बदल सकते हैं जबकि शेप की ज्योमेट्री को बना रखा जाता है; यह मौजूदा लेआउट में मीडिया अपडेट करने की एक सामान्य स्थिति है।

**क्या एम्बेडेड वीडियो का कंटेंट टाइप (MIME) निर्धारित किया जा सकता है?**

हां। एक एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए जब आप इसे डिस्क पर सहेजते हैं।