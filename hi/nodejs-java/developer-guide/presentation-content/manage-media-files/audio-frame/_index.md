---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ़्रेम
type: docs
weight: 10
url: /hi/nodejs-java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js में ऑडियो फ्रेम बनाएँ और नियंत्रित करें—एम्बेड, ट्रिम, लूप और PPT, PPTX, तथा ODP प्रस्तुतियों में प्लेबैक कॉन्फ़िगर करने के उदाहरण।"
---
## **परिचय**

यह लेख Aspose.Slides में ऑडियो फ़्रेम के साथ काम करने के तरीकों को समझाता है। यह दिखाता है कि स्लाइड्स में एम्बेडेड ऑडियो कैसे जोड़ें, ऑडियो फ़्रेम थंबनेल को वैयक्तिकृत करें, वॉल्यूम, लूपिंग, छुपाना, ट्रिमिंग और फ़ेड अवधि जैसे प्लेबैक विकल्पों को कॉन्फ़िगर करें, और स्लाइडशो ट्रांज़िशन में उपयोग किए गए ऑडियो को निकालें।

## **ऑडियो फ़्रेम बनाना**

Aspose.Slides for Node.js via Java आपको स्लाइड्स में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड्स में ऑडियो फ़्रेम के रूप में एम्बेड की जाती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ।
2. स्लाइड के इंडेक्स के माध्यम से उसका संदर्भ प्राप्त करें।
3. वह ऑडियो फ़ाइल स्ट्रीम लोड करें जिसे आप स्लाइड में एम्बेड करना चाहते हैं।
4. एम्बेडेड ऑडियो फ़्रेम (जिसमें ऑडियो फ़ाइल होती है) को स्लाइड में जोड़ें।
5. [AudioFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AudioFrame) ऑब्जेक्ट द्वारा प्रदान किए गए [PlayMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AudioPlayModePreset) और `Volume` सेट करें।
6. संशोधित प्रेजेंटेशन को सहेजें।

यह JavaScript कोड दिखाता है कि स्लाइड में एम्बेडेड ऑडियो फ़्रेम कैसे जोड़ें:

```javascript
// एक Presentation क्लास का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
const pres = new aspose.slides.Presentation();
try {
    // पहला स्लाइड प्राप्त करता है
    const sld = pres.getSlides().get_Item(0);
    // wav साउंड फ़ाइल को स्ट्रीम में लोड करता है
    const fstr = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.wav"));
    // ऑडियो फ़्रेम जोड़ता है
    const audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    // ऑडियो का प्ले मोड और वॉल्यूम सेट करता है
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.Auto);
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Loud);
    // PowerPoint फ़ाइल को डिस्क पर लिखता है
    pres.save("AudioFrameEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ऑडियो फ़्रेम थंबनेल बदलना**

जब आप प्रेजेंटेशन में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट इमेज वाले फ्रेम के रूप में दिखाई देता है (नीचे दी गई छवि देखें)। आप ऑडियो फ़्रेम की प्रीव्यू इमेज (अपनी पसंदीदा इमेज) सेट कर सकते हैं।

यह JavaScript कोड दिखाता है कि ऑडियो फ़्रेम का थंबनेल या प्रीव्यू इमेज कैसे बदलें:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    // निर्दिष्ट स्थिति और आकार के साथ स्लाइड में एक ऑडियो फ्रेम जोड़ता है।
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample2.mp3");
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();
    // प्रस्तुति संसाधनों में एक छवि जोड़ता है।
    let picture;
    const image = aspose.slides.Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // ऑडियो फ्रेम के लिए छवि सेट करता है।
    audioFrame.getPictureFormat().getPicture().setImage(picture);// <-----
    // संशोधित प्रस्तुति को डिस्क पर संग्रहीत करता है।
    presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **ऑडियो प्ले विकल्प बदलना**

Aspose.Slides for Node.js via Java आपको ऑडियो की प्लेबैक या गुणों को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूपेड प्ले कर सकते हैं, या ऑडियो आइकन को छुपा सकते हैं।

Microsoft PowerPoint में **Audio Options** पैनल:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:
- **Start** ड्रॉप‑डाउन सूची [AudioFrame.setPlayMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setPlayMode) मेथड से मेल खाती है
- **Volume** [AudioFrame.setVolume](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setVolume) मेथड से मेल खाता है
- **Play Across Slides** [AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setPlayAcrossSlides) मेथड से मेल खाता है
- **Loop until Stopped** [AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setPlayLoopMode) मेथड से मेल खाता है
- **Hide During Show** [AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setHideAtShowing) मेथड से मेल खाता है
- **Rewind after Playing** [AudioFrame.setRewindAudio](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setRewindAudio) मेथड से मेल खाता है

PowerPoint **Editing** विकल्प जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:
- **Fade In** [AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setFadeInDuration) मेथड से मेल खाता है
- **Fade Out** [AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setFadeOutDuration) मेथड से मेल खाता है
- **Trim Audio Start Time** [AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setTrimFromStart) मेथड से मेल खाता है
- **Trim Audio End Time** का मान ऑडियो अवधि में से [AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setTrimFromEnd) मेथड के मान को घटाकर प्राप्त होता है

PowerPoint पर ऑडियो कंट्रोल पैनल में **Volume control** [AudioFrame.setVolumeValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#setVolumeValue) मेथड से संबंधित है। यह आपको प्रतिशत के रूप में ऑडियो वॉल्यूम बदलने की अनुमति देता है।

ऑडियो प्ले विकल्प बदलने के चरण:

1. [Сreate](#create-audio-frame) या Audio Frame प्राप्त करें।
2. उन Audio Frame प्रॉपर्टीज़ के नए मान सेट करें जिन्हें आप समायोजित करना चाहते हैं।
3. संशोधित PowerPoint फ़ाइल सहेजें।

यह JavaScript कोड दिखाता है कि ऑडियो के विकल्प कैसे समायोजित किए जाते हैं:

```javascript
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame आकार प्राप्त करता है
    const audioFrame = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // प्ले मोड को क्लिक पर चलाने के लिए सेट करता है
    audioFrame.setPlayMode(aspose.slides.AudioPlayModePreset.OnClick);
    // वॉल्यूम को कम सेट करता है
    audioFrame.setVolume(aspose.slides.AudioVolumeMode.Low);
    // ऑडियो को सभी स्लाइड्स पर चलने के लिए सेट करता है
    audioFrame.setPlayAcrossSlides(true);
    // ऑडियो के लिए लूप को अक्षम करता है
    audioFrame.setPlayLoopMode(false);
    // स्लाइड शो के दौरान AudioFrame को छुपाता है
    audioFrame.setHideAtShowing(true);
    // बजाने के बाद ऑडियो को शुरू में रीवाइंड करता है
    audioFrame.setRewindAudio(true);
    // PowerPoint फ़ाइल को डिस्क पर सहेजता है
    pres.save("AudioFrameEmbed_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

यह JavaScript उदाहरण दिखाता है कि एम्बेडेड ऑडियो के साथ नया ऑडियो फ़्रेम कैसे जोड़ें, उसे ट्रिम करें, और फ़ेड अवधि सेट करें:

```js
const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    
    const audioData = java.newArray("byte", Array.from(fs.readFileSync("sampleaudio.mp3")));
    const audio = pres.getAudios().addAudio(audioData);
    const audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ट्रिमिंग शुरूआती ऑफसेट को 1.5 सेकंड पर सेट करता है
    audioFrame.setTrimFromStart(1500);
    // ट्रिमिंग अंत ऑफसेट को 2 सेकंड पर सेट करता है
    audioFrame.setTrimFromEnd(2000);

    // फेड-इन अवधि को 200 मिलिसेकंड पर सेट करता है
    audioFrame.setFadeInDuration(200);
    // फेड-आउट अवधि को 500 मिलिसेकंड पर सेट करता है
    audioFrame.setFadeOutDuration(500);

    pres.save("AudioFrameTrimFade_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

निम्नलिखित कोड सैंपल दिखाता है कि एम्बेडेड ऑडियो वाले ऑडियो फ़्रेम को प्राप्त करें और उसकी वॉल्यूम 85% सेट करें:

```js
const pres = new aspose.slides.Presentation("AudioFrameEmbed_out.pptx");
try {
    const slide = pres.getSlides().get_Item(0);

    // एक ऑडियो फ्रेम आकार प्राप्त करता है
    const audioFrame = slide.getShapes().get_Item(0);

    // ऑडियो वॉल्यूम को 85% पर सेट करता है
    audioFrame.setVolumeValue(85.0);

    pres.save("AudioFrameValue_out.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करना**

Aspose.Slides आपको [getCaptionTracks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) मेथड के माध्यम से ऑडियो फ़्रेम में क्लोज़्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक जोड़ सकते हैं, मौजूदा ट्रैक पर इटररेट कर सकते हैं, और आवश्यकता पड़ने पर उन्हें हटाया जा سکتا है।

**ऑडियो कैप्शन जोड़ें**

ऑडियो फ़्रेम से एक या अधिक कैप्शन ट्रैक जोड़ने के लिए [getCaptionTracks](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/#getCaptionTracks) मेथड का उपयोग करें। निम्न उदाहरण में, पहले एक ऑडियो फ़ाइल स्लाइड में जोड़ी जाती है, फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया जाता है।

```js
let presentation = new aspose.slides.Presentation();
try {
    let audioStream = java.newInstanceSync("java.io.FileInputStream", "audio.mp3");
    let audio = presentation.getAudios().addAudio(audioStream);
    audioStream.close();

    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // एक नया कैप्शन ट्रैक WebVTT फ़ाइल से जोड़ें।
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ़्रेम से जुड़े कैप्शन ट्रैक पर इटररेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और विशिष्ट पहचानकर्ता उजागर करता है, जिसे निर्यात के दौरान उपयोग किया जा सकता है।

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AudioFrame")) {
            let audioFrame = shape;
            let trackCount = audioFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = audioFrame.getCaptionTracks().get_Item(trackIndex);
                // कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
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

**ऑडियो कैप्शन हटाएँ**

ऑडियो फ़्रेम से कैप्शन हटाने के लिए आप [CaptionsCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/) द्वारा प्रदान की गई विधियों जैसे कि [clear](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/captionscollection/#removeAt) का उपयोग कर सकते हैं। नीचे दिया उदाहरण सभी कैप्शन ट्रैक को ऑडियो फ़्रेम से हटाता है।

```js
let presentation = new aspose.slides.Presentation("audio_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let audioFrame = slide.getShapes().get_Item(0); // प्रकार: aspose.slides.AudioFrame

    // ऑडियो फ़्रेम से सभी कैप्शन ट्रैक हटाएँ।
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो निकालना**

Aspose.Slides for Node.js via Java आपको स्लाइड शो ट्रांज़िशन में इस्तेमाल होने वाली ध्वनि को निकालने की अनुमति देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग हुई ध्वनि को निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएँ और ऑडियो वाली प्रेजेंटेशन लोड करें।
2. स्लाइड के इंडेक्स के माध्यम से उसका संदर्भ प्राप्त करें।
3. स्लाइड के लिए [slideshow transitions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/BaseSlide#getSlideShowTransition--) तक पहुँचें।
4. ध्वनि को बाइट डेटा के रूप में निकालें।

यह JavaScript कोड दिखाता है कि स्लाइड में उपयोग हुई ऑडियो को कैसे निकालें:

```javascript
// एक Presentation क्लास का इंस्टेंस बनाता है जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
const pres = new aspose.slides.Presentation("AudioSlide.pptx");
try {
    // वांछित स्लाइड तक पहुँचता है
    const slide = pres.getSlides().get_Item(0);
    // स्लाइड के लिए स्लाइडशो ट्रांज़िशन इफेक्ट प्राप्त करता है
    const transition = slide.getSlideShowTransition();
    // ध्वनि को बाइट ऐरे में निकालता है
    const audio = transition.getSound().getBinaryData();
    console.log("Length: " + audio.length);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड्स में पुन: उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हाँ। ऑडियो को प्रेजेंटेशन के साझा [audio collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getaudios/) में एक बार जोड़ें और अतिरिक्त ऑडियो फ़्रेम बनाएँ जो उस मौजूदा एसेट को रेफ़र करते हैं। इससे मीडिया डेटा की डुप्लिकेशन नहीं होती और प्रेजेंटेशन का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ़्रेम में ध्वनि को बदल सकता हूँ बिना शेप को फिर से बनाए?**

हाँ। लिंक्ड ध्वनि के लिए, नई फ़ाइल की ओर इशारा करने हेतु [link path](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/setlinkpathlong/) अपडेट करें। एम्बेडेड ध्वनि के लिए, प्रेजेंटेशन के [audio collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getaudios/) से किसी अन्य ऑडियो को [embedded audio](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/setembeddedaudio/) ऑब्जेक्ट के साथ बदलें। फ़्रेम का फ़ॉर्मैटिंग और अधिकांश प्लेबैक सेटिंग्स समान रहती हैं।

**क्या ट्रिमिंग से प्रेजेंटेशन में संग्रहीत मूल ऑडियो डेटा बदलता है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहती हैं और एम्बेडेड ऑडियो या प्रेजेंटेशन के ऑडियो संग्रह के माध्यम से उपलब्ध रहती हैं।