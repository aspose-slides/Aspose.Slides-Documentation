---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में ऑडियो फ़्रेम प्रबंधित करें
linktitle: ऑडियो फ़्रेम
type: docs
weight: 10
url: /hi/nodejs-java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ़्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **सारांश**

एक ऑडियो फ़्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for Node.js via Java के साथ, आप एक स्थानीय ऑडियो क्लिप को एम्बेड कर सकते हैं, इसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन संलग्न कर सकते हैं। आप स्लाइड ट्रांज़िशन को असाइन किए गए ध्वनि को भी प्राप्त कर सकते हैं।

## **ऑडियो फ़्रेम बनाएं**

स्थानीय ऑडियो क्लिप को पहली स्लाइड पर एम्बेड करने के लिए [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) का उपयोग करें। पहले दो निर्देशांक फ़्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान इसकी चौड़ाई और ऊँचाई को पॉइंट्स में सेट करते हैं। यह उदाहरण क्लिप को स्वचालित रूप से शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) को कॉल करता है और तेज़ प्रीसेट चुनने के लिए [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) को कॉल करता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
        audioFrame.setPlayMode(slides.AudioPlayModePreset.Auto);
        audioFrame.setVolume(slides.AudioVolumeMode.Loud);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameEmbed_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो फ़्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप से, एक ऑडियो फ़्रेम स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) का उपयोग करके एक छवि जोड़ें और इसे फ़्रेम की चित्र पर [setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) से सेट करें। इस उदाहरण में एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में `eagle.jpeg` का उपयोग किया गया है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
        const imageStream = java.newInstanceSync("java.io.FileInputStream", "eagle.jpeg");
        try {
            const thumbnail = presentation.getImages().addImage(imageStream);
            audioFrame.getPictureFormat().getPicture().setImage(thumbnail);
        } finally {
            imageStream.close();
        }
    } finally {
        audioStream.close();
    }
    presentation.save("example_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint की **Audio Options** नियंत्रण यह निर्धारित करते हैं कि क्लिप कब शुरू होती है, उसकी ध्वनि कितनी तेज़ है, और स्लाइड शो के दौरान इसका व्यवहार कैसे है।

![ऑडियो फ़्रेम के लिए PowerPoint Audio Options नियंत्रण](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for Node.js via Java विधि |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolume) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setRewindAudio) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) |

उदाहरण पहली स्लाइड पर पहला ऑडियो फ़्रेम खोजता है, क्लिक पर प्लेबैक शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setPlayMode) को कॉल करता है, और कम वॉल्यूम प्रीसेट चुनता है। क्लिप स्लाइड्स के बीच चलती रहती है जबकि लूपिंग अक्षम है। आइकन शो के दौरान छिपा रहता है, और प्लेबैक के बाद क्लिप रिवाइंड हो जाती है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setPlayMode(slides.AudioPlayModePreset.OnClick);
        audioFrame.setVolume(slides.AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

3.5 सेकंड से लंबी क्लिप के लिए, यह उदाहरण पहली 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) क्लिप के अंत से हटाने की अवधि लेता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए उस ऑफ़सेट को पूरे क्लिप की अवधि से घटाएँ। ट्रिम्ड क्लिप 200 मिलीसेकंड में फेड इन होती है और 500 मिलीसेकंड में फेड आउट होती है। चारों विधियाँ मिलीसेकंड में मान लेती हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
        audioFrame.setTrimFromStart(1500);
        audioFrame.setTrimFromEnd(2000);
        audioFrame.setFadeInDuration(200);
        audioFrame.setFadeOutDuration(500);
    } finally {
        audioStream.close();
    }
    presentation.save("AudioFrameTrimFade_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्लेबैक वॉल्यूम को विशिष्ट प्रतिशत पर सेट करने के लिए [setVolumeValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setVolumeValue) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ़्रेम को 85% पर सेट करता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.setVolumeValue(85);
        presentation.save("AudioFrameValue_out.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ़्रेम [getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) के माध्यम से अपने कैप्शन ट्रैक तक पहुँच प्रदान करता है। संग्रह का उपयोग करके आप क्लिप को WebVTT कैप्शन संलग्न कर सकते हैं, मौजूदा ट्रैक निर्यात कर सकते हैं, या उन्हें हटा सकते हैं।

### **ऑडियो कैप्शन जोड़ें**

उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक संलग्न करने के लिए [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#add) का उपयोग करता है। पहला तर्क ट्रैक लेबल देता है, और दूसरा फ़ाइल को पहचानता है जिसमें समय‑संकेतित कैप्शन होते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
        audioFrame.getCaptionTracks().add("English", "track.vtt");
    } finally {
        audioStream.close();
    }
    presentation.save("audio_with_captions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर ऑडियो फ़्रेम से जुड़े प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getBinaryData) द्वारा लौटाए गए बाइट्स को एक WebVTT फ़ाइल में लिखता है और [getCaptionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getCaptionId) द्वारा लौटाए गए पहचानकर्ता को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("node:fs");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            const fileName = track.getCaptionId() + ".vtt";
            const bytes = track.getBinaryData();
            const data = Buffer.from(bytes);
            fs.writeFileSync(fileName, data);
        }
    }
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन हटाएँ**

व्यक्तिगत ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ़्रेम से सभी कैप्शन को हटाने के लिए [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) का उपयोग करता है, जबकि क्लिप को बरकरार रखता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    let audioFrame = null;
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            audioFrame = shape;
            break;
        }
    }

    if (audioFrame) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन में पंक्ति खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में पंक्ति खोजने के लिए, मेमोरी में [getDataAsString](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/#getDataAsString) द्वारा लौटाए गए टेक्स्ट को खोजें। एक साधारण‑पाठ WebVTT क्यू में, टाइमिंग पंक्ति में `-->` होता है, उसके बाद कैप्शन पंक्तियाँ आती हैं, और एक खाली पंक्ति क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन पंक्ति को प्रिंट करता है जिसमें “café” शब्द होता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("audio_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapes = slide.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            continue;
        }
        const tracks = shape.getCaptionTracks();
        for (let k = 0; k < tracks.getCount(); k++) {
            const track = tracks.get_Item(k);
            let inCue = false;
            const captions = track.getDataAsString();
            for (const line of captions.split(/\r\n|\n|\r/)) {
                if (line === "") {
                    inCue = false;
                } else if (line.includes("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase().includes("café")) {
                    console.log(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ऑडियो निकालें**

एक स्लाइड ट्रांज़िशन की अपनी ध्वनि हो सकती है। इसे प्राप्त करने के लिए स्लाइड ट्रांज़िशन पर [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSound) को कॉल करें। उदाहरण [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audio/#getBinaryData) द्वारा लौटाए गए बाइट्स तक पहुँचता है और बाइट्स की संख्या प्रिंट करता है। यदि पहली स्लाइड में कोई ट्रांज़िशन साउंड नहीं है, तो यह एक संदेश प्रिंट करता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AudioSlide.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const sound = slide.getSlideShowTransition().getSound();
    if (sound) {
        const audioData = sound.getBinaryData();
        console.log("Transition sound: " + audioData.length + " bytes.");
    } else {
        console.log("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड्स में दोहराए बिना पुनः उपयोग कर सकता हूँ?**

हाँ। क्लिप को प्रस्तुति के [ऑडियो संग्रह](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getAudios) में एक बार जोड़ें और प्रत्येक स्लाइड के लिए उसी ऑडियो ऑब्जेक्ट को [addAudioFrameEmbedded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) को पास करें।

**क्या मैं मौजूदा ऑडियो फ़्रेम में ध्वनि को बदल सकता हूँ?**

हाँ। लिंक्ड साउंड के लिए, प्रतिस्थापन फ़ाइल की ओर संकेत करने के लिए [setLinkPathLong](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setLinkPathLong) का उपयोग करें। एम्बेडेड साउंड के लिए, प्रस्तुति के ऑडियो संग्रह से कोई अन्य क्लिप चुनें और इसे [setEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setEmbeddedAudio) के साथ सेट करें। दोनों तरीकों से मौजूदा फ़्रेम बरकरार रहता है।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत ऑडियो डेटा को बदलती है?**

नहीं। [setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) और [setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) प्लेबैक सीमाएँ सेट करते हैं। आप अभी भी पूर्ण क्लिप को [getEmbeddedAudio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/audioframe/#getEmbeddedAudio) से प्राप्त कर सकते हैं।