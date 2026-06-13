---
title: JavaScript का उपयोग करके प्रस्तुतियों में वीडियो फ़्रेम प्रबंधित करें
linktitle: वीडियो फ़्रेम
type: docs
weight: 10
url: /hi/nodejs-java/video-frame/
keywords:
- वीडियो जोड़ें
- वीडियो बनाएं
- वीडियो एम्बेड करें
- वीडियो निकालें
- वीडियो पुनः प्राप्त करें
- वीडियो फ़्रेम
- वेब स्रोत
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके, Java के माध्यम से PowerPoint और OpenDocument स्लाइड्स में वीडियो फ़्रेम को प्रोग्रामेटिक रूप से जोड़ना और निकालना सीखें। तेज़ हाउ-टू गाइड।"
---
## **परिचय**

एक प्रस्तुतिकरण में सही जगह पर रखा गया वीडियो आपका संदेश अधिक प्रभावी बना सकता है और दर्शकों की सहभागिता स्तर को बढ़ा सकता है।

PowerPoint दो तरीकों से स्लाइड में वीडियो जोड़ने की सुविधा देता है:

* स्थानीय वीडियो (आपकी मशीन पर संग्रहीत) जोड़ें या एम्बेड करें
* ऑनलाइन वीडियो (जैसे YouTube) जोड़ें

आपकी प्रस्तुति में वीडियो (वीडियो ऑब्जेक्ट) जोड़ने के लिए, Aspose.Slides निम्नलिखित क्लासेस प्रदान करता है: [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) क्लास, [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) क्लास, तथा अन्य संबंधित प्रकार।

## **एम्बेडेड वीडियो फ्रेम बनाना**

यदि आप जिस वीडियो फ़ाइल को अपनी स्लाइड में जोड़ना चाहते हैं वह स्थानीय रूप से संग्रहीत है, तो आप प्रस्तुति में वीडियो एम्बेड करने के लिए एक वीडियो फ्रेम बना सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनायें।
1. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो फ़ाइल पथ को पास करके वीडियो को प्रस्तुति में एम्बेड करें।
1. एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें ताकि वीडियो के लिए एक फ्रेम बनाया जा सके।
1. संशोधित प्रस्तुति को सहेजें।

यह JavaScript कोड दिखाता है कि स्थानीय रूप से संग्रहीत वीडियो को प्रस्तुति में कैसे जोड़ें:

```javascript
// Presentation क्लास का इंस्टेंस बनाता है
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // वीडियो लोड करता है
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // पहली स्लाइड प्राप्त करता है और वीडियोफ़्रेम जोड़ता है
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // प्रस्तुति को डिस्क पर सहेजता है
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

वैकल्पिक रूप से, आप सीधे फ़ाइल पथ को नीचे दिए गए मेथड में पास करके भी वीडियो जोड़ सकते हैं: [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-):

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

## **वेब स्रोत से वीडियो के साथ वीडियो फ्रेम बनाना**

Microsoft [PowerPoint 2013 और नए संस्करण](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ऑनलाइन वीडियो, जैसे YouTube, को समर्थन देते हैं। यदि आप जिस वीडियो का उपयोग करना चाहते हैं वह ऑनलाइन उपलब्ध है, तो आप उसकी वेब लिंक के माध्यम से उसे अपनी प्रस्तुति में जोड़ सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनायें।
1. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
1. एक [Video](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/) ऑब्जेक्ट जोड़ें और वीडियो लिंक पास करें।
1. वीडियो फ्रेम के लिए थंबनेल सेट करें।
1. प्रस्तुति को सहेजें।

यह JavaScript कोड दिखाता है कि वेब से वीडियो को PowerPoint स्लाइड में कैसे जोड़ें:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

## **वीडियो कैप्शन प्रबंधन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में वीडियो फ्रेम के लिए क्लोज़्ड कैप्शन प्रबंधित करने की सुविधा देता है। कैप्शन WebVTT फ़ॉर्मेट में संग्रहीत होते हैं और इन्हें [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) मेथड के माध्यम से एक्सेस किया जा सकता है।

**वीडियो फ्रेम में कैप्शन जोड़ना**

वीडियो फ्रेम में कैप्शन जोड़ने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनायें।
1. प्रस्तुति में एक वीडियो जोड़ें।
1. स्लाइड में एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट जोड़ें।
1. एक WebVTT कैप्शन ट्रैक जोड़ने के लिए [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन का उपयोग करें।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम में कैप्शन कैसे जोड़ें:

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

[CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) क्लास additionally [addFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#addFromStream) मेथड प्रदान करती है, जिससे आप स्ट्रीम से कैप्शन जोड़ सकते हैं।

**वीडियो फ्रेम से कैप्शन निकालना**

वीडियो फ्रेम से कैप्शन निकालने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो सम्मिलित है।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट खोजें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन पर इटररेट करें।
1. प्रत्येक कैप्शन ट्रैक को `.vtt` फ़ाइल में सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से कैप्शन कैसे निकालें:

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

प्रत्येक [Captions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captions/) ऑब्जेक्ट कैप्शन पहचानकर्ता, लेबल, बाइनरी डेटा, और UTF-8 स्ट्रिंग के रूप में कैप्शन टेक्स्ट को एक्सपोज़ करता है।

**वीडियो फ्रेम से कैप्शन हटाना**

वीडियो फ्रेम से कैप्शन हटाने के लिए:

1. वह प्रस्तुति लोड करें जिसमें वीडियो सम्मिलित है।
1. लक्ष्य [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट प्राप्त करें।
1. [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) कलेक्शन से कैप्शन ट्रैक हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

निम्न कोड दिखाता है कि वीडियो फ्रेम से सभी कैप्शन कैसे हटाएँ:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // प्रकार: com.aspose.slides.VideoFrame

    // वीडियो फ्रेम से सभी कैप्शन हटाता है।
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि आपको केवल एक कैप्शन ट्रैक हटाना है, तो [clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#clear) की बजाय [remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#removeAt) मेथड का उपयोग करें।

## **स्लाइड से वीडियो निकालना**

वीडियो को स्लाइड में जोड़ने के अलावा, Aspose.Slides आपको प्रस्तुतियों में एम्बेड किए गए वीडियो निकालने की सुविधा भी देता है।

1. वीडियो वाली प्रस्तुति लोड करने के लिए एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का इंस्टेंस बनायें।
2. सभी [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) ऑब्जेक्ट्स पर इटररेट करें।
3. सभी [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करके [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) खोजें।
4. वीडियो को डिस्क पर सहेजें।

यह JavaScript कोड दिखाता है कि प्रस्तुति स्लाइड से वीडियो कैसे निकालें:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

## **FAQ**

**कौन से वीडियो प्लेबैक पैरामीटर को VideoFrame के लिए बदला जा सकता है?**

आप [playback mode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setplaymode/) (ऑटो या क्लिक पर) और [looping](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setplayloopmode/) को नियंत्रित कर सकते हैं। ये विकल्प [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) ऑब्जेक्ट की प्रॉपर्टीज़ के माध्यम से उपलब्ध हैं।

**वीडियो जोड़ने से PPTX फ़ाइल का आकार बढ़ता है क्या?**

हां। जब आप स्थानीय वीडियो एम्बेड करते हैं, तो बाइनरी डेटा दस्तावेज़ में सम्मिलित हो जाता है, इसलिए प्रस्तुति का आकार फ़ाइल के आकार के अनुपात में बढ़ता है। ऑनलाइन वीडियो जोड़ने पर केवल लिंक और थंबनेल एम्बेड होते हैं, इसलिए आकार वृद्धि कम होती है।

**क्या मैं मौजूदा VideoFrame में वीडियो को उसकी स्थिति और आकार बदले बिना बदल सकता हूँ?**

हां। आप फ्रेम के भीतर [video content](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) को स्वैप कर सकते हैं, जबकि आकार और ज्योमेट्री बरकरार रहती है; यह मौजूदा लेआउट में मीडिया अपडेट करने के सामान्य परिदृश्य में उपयोगी है।

**क्या एम्बेडेड वीडियो के कंटेंट टाइप (MIME) को निर्धारित किया जा सकता है?**

हां। एम्बेडेड वीडियो का एक [content type](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/video/getcontenttype/) होता है, जिसे आप पढ़ और उपयोग कर सकते हैं, उदाहरण के लिए डिस्क पर सहेजते समय।