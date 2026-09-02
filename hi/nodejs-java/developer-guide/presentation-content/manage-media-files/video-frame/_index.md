---
title: प्रेज़ेंटेशन में जावास्क्रिप्ट का उपयोग करके वीडियो फ्रेम प्रबंधित करें
linktitle: वीडियो फ्रेम
type: docs
weight: 10
url: /hi/nodejs-java/video-frame/
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
- प्रेज़ेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके जावा के माध्यम से PowerPoint और OpenDocument स्लाइड्स में प्रोग्रामेटिक रूप से वीडियो फ्रेम जोड़ना और निकालना सीखें। तेज़ कैसे‑करें मार्गदर्शिका।"
---
## **परिचय**

प्रस्तुति में एक उचित रूप से रखा गया वीडियो आपके संदेश को अधिक आकर्षक बना सकता है और दर्शकों के साथ जुड़ाव स्तर को बढ़ा सकता है।

PowerPoint आपको प्रस्तुति में स्लाइड पर वीडियो दो तरीकों से जोड़ने की अनुमति देता है:
* स्थानीय वीडियो जोड़ें या एम्बेड करें (आपके मशीन पर संग्रहीत)
* ऑनलाइन वीडियो जोड़ें (YouTube जैसे वेब स्रोत से)।

प्रस्तुति में वीडियो (video objects) जोड़ने के लिए, Aspose.Slides नीचे दिए गए [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) क्लास और अन्य संबंधित प्रकार प्रदान करता है।

## **एम्बेडेड वीडियो फ्रेम बनाएँ**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप अपनी प्रस्तुति में वीडियो को एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं।
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ पास करके वीडियो को प्रस्तुति में एम्बेड करें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए फ्रेम बनाया जा सके।
1. संशोधित प्रस्तुति को सहेजें।

```javascript
// Presentation क्लास का इंस्टैंस बनाता है
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // वीडियो लोड करता है
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // पहली स्लाइड प्राप्त करता है और एक वीडियोफ़्रेम जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // प्रेज़ेंटेशन को डिस्क पर सहेजता है
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

वैकल्पिक रूप से, आप वीडियो को उसका फ़ाइल पथ सीधे [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) मेथड में पास करके जोड़ सकते हैं:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाएँ**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) YouTube वीडियो को प्रस्तुतियों में समर्थन देता है। यदि आप उपयोग करने वाला वीडियो ऑनलाइन (उदाहरण के लिए YouTube) उपलब्ध है, तो आप इसे अपने प्रस्तुति में उसके वेब लिंक के माध्यम से जोड़ सकते हैं।

1. एक [Presentation ](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो के लिंक को पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

```javascript
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाता है
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **वीडियो फ्रेम को ट्रिम करना**

Aspose.Slides आपको [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/settrimfromstart/) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/settrimfromend/) के माध्यम से trim-from-start और trim-from-end मान सेट करके यह नियंत्रित करने की अनुमति देता है कि वीडियो का कौन सा भाग चलाया जाए। दोनों मान मिलिसेकंड में निर्दिष्ट किए जाते हैं और क्रमशः वीडियो की शुरुआत और अंत से कितना समय छोड़ना है, यह परिभाषित करते हैं। ये सेटिंग्स प्रस्तुति में वीडियो प्लेबैक सेटिंग्स को बदलती हैं; यह एम्बेडेड वीडियो बायनरी डेटा को काटती या संशोधित नहीं करतीं।

**ट्रिम सेटिंग्स निर्धारित करें**

एक वीडियो फ्रेम बनाकर उसकी ट्रिम सेटिंग्स निर्धारित करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं।
1. प्रस्तुति में एक [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें।
1. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/settrimfromstart/) और [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/settrimfromend/) के माध्यम से trim-from-start और trim-from-end मान सेट करें।
1. संशोधित प्रस्तुति को सहेजें।

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**ट्रिम सेटिंग्स पढ़ें**

मौजूदा ट्रिम सेटिंग्स को जांचने के लिए, प्रस्तुति लोड करें, पहले स्लाइड पर मौजूद शैप्स में से एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें, और [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) तथा [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/gettrimfromend/) के माध्यम से मान पढ़ें।

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **वीडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए बंद कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT प्रारूप में संग्रहीत होते हैं और उन्हें [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से एक्सपोज़ किया जाता है।

**वीडियो फ्रेम में कैप्शन जोड़ें**

एक वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टैंस बनाएं।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. एक WebVTT कैप्शन ट्रैक जोड़ने के लिए [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन का उपयोग करें।
1. संशोधित प्रस्तुति को सहेजें।

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ता है।
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) क्लास अतिरिक्त रूप से [addFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#addFromStream) मेथड प्रदान करता है जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालें**

एक वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो शामिल है।
1. लक्षित [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन पर इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // कैप्शन ट्रैक को WebVTT फ़ाइल में सहेजता है।
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा और कैप्शन टेक्स्ट को UTF-8 स्ट्रिंग के रूप में उजागर करता है।

**वीडियो फ्रेम से कैप्शन हटाएँ**

एक वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो शामिल है।
1. लक्षित [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // प्रकार: com.aspose.slides.VideoFrame

    // वीडियो फ़्रेम से सभी कैप्शन हटाता है।
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल किसी एक कैप्शन ट्रैक को हटाना है, तो आप [clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#clear) की बजाय [remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग कर सकते हैं।

## **स्लाइड से वीडियो निकालें**

स्लाइड में वीडियो जोड़ने के अतिरिक्त, Aspose.Slides आपको प्रस्तुतियों में एम्बेडेड वीडियो को निकालने की सुविधा भी देता है।

1. वीडियो वाली प्रस्तुति को लोड करने के लिए एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टैंस बनाएं।
2. सभी [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) ऑब्जेक्ट्स पर इटररेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करें ताकि एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) मिल सके।
4. वीडियो को डिस्क पर सहेजें।

```javascript
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाता है
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // फ़ाइल एक्सटेंशन प्राप्त करता है
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**वीडियो फ्रेम के लिए कौन से वीडियो प्लेबैक पैरामीटर बदले जा सकते हैं?**

आप [playback mode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setplaymode/) (ऑटो या ऑन क्लिक) और [looping](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setplayloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**वीडियो जोड़ने से PPTX फ़ाइल आकार पर असर पड़ता है क्या?**

हां। जब आप एक स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में शामिल हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। ऑनलाइन वीडियो जोड़ने पर केवल लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि छोटी रहती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) को बदल सकते हैं जबकि शैल की ज्योमेट्री को बरकरार रख सकते हैं; यह मौजूदा लेआउट में मीडिया को अपडेट करने की सामान्य स्थिति है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) का पता लगाया जा सकता है?**

हां। एक एम्बेडेड वीडियो का [content type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/getcontenttype/) होता है जिसे आप पढ़ सकते हैं और उपयोग कर सकते हैं, उदाहरण के लिए डिस्क पर सहेजते समय।