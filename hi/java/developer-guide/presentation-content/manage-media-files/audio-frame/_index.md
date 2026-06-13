---
title: जावा का उपयोग करके प्रेज़ेंटेशन में ऑडियो प्रबंधन
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ़्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में ऑडियो फ़्रेम बनाएँ और नियंत्रित करें—कोड उदाहरण जो एम्बेड, ट्रिम, लूप और PPT, PPTX, तथा ODP प्रेज़ेंटेशन में प्लेबैक कॉन्फ़िगर करने के लिए हैं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में ऑडियो फ़्रेम के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में एम्बेडेड ऑडियो कैसे जोड़ें, ऑडियो फ़्रेम थंबनेल को कैसे अनुकूलित करें, वॉल्यूम, लूपिंग, छुपाने, ट्रिमिंग और फेड अवधि जैसे प्लेबैक विकल्प कैसे सेट करें, और स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को कैसे निकालें।

## **ऑडियो फ़्रेम बनाएं**

Aspose.Slides for Java आपको स्लाइड में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड में ऑडियो फ़्रेम के रूप में एम्बेड की जाती हैं।

1. एक `[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation)` क्लास का इंस्टेंस बनाएं।
2. उसके इंडेक्स के जरिए स्लाइड का रेफ़रेंस प्राप्त करें।
3. जिस ऑडियो फ़ाइल को एम्बेड करना है, उसका स्ट्रीम लोड करें।
4. एम्बेडेड ऑडियो फ़्रेम (जिसमें ऑडियो फ़ाइल है) को स्लाइड में जोड़ें।
5. `[PlayMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AudioPlayModePreset)` और `Volume` को `[IAudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAudioFrame)` ऑब्जेक्ट द्वारा एक्सपोज़ किया गया सेट करें।
6. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड आपको दिखाता है कि स्लाइड में एम्बेडेड ऑडियो फ़्रेम कैसे जोड़ें:

```java
// एक Presentation क्लास का इंस्टेंस बनाता है जो प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation();
try {
    // पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);

    // wav साउंड फ़ाइल को स्ट्रीम में लोड करता है
    FileInputStream fstr = new FileInputStream(new File("audio.wav"));

    // ऑडियो फ्रेम जोड़ता है
    IAudioFrame audioFrame = sld.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, fstr);
    fstr.close();
    
    // ऑडियो का प्ले मोड और वॉल्यूम सेट करता है
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    // PowerPoint फ़ाइल को डिस्क पर लिखता है
    pres.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **ऑडियो फ़्रेम थंबनेल बदलें**

जब आप प्रेज़ेंटेशन में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट चित्र वाले फ़्रेम के रूप में दिखता है (नीचे की छवि देखें)। आप ऑडियो फ़्रेम की प्रीव्यू इमेज (अपनी पसंदीदा इमेज सेट) को बदल सकते हैं।

यह Java कोड दिखाता है कि ऑडियो फ़्रेम का थंबनेल या प्रीव्यू इमेज कैसे बदलें:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // निर्दिष्ट स्थिति और आकार के साथ स्लाइड में एक ऑडियो फ़्रेम जोड़ता है।
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // प्रेज़ेंटेशन संसाधनों में एक छवि जोड़ता है।
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ऑडियो फ़्रेम के लिए छवि सेट करता है।
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //संशोधित प्रेज़ेंटेशन को डिस्क पर सेव करता है
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for Java आपको ऑडियो के प्लेबैक या प्रॉपर्टी को नियंत्रित करने वाले विकल्प बदलने की सुविधा देता है। उदाहरण के लिए, आप ऑडियो की आवाज़ समायोजित कर सकते हैं, ऑडियो को लूप में चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकन को छुपा सकते हैं।

Microsoft PowerPoint में **Audio Options** पैन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AudioFrame) प्रॉपर्टीज़ से मेल खाती हैं:

- **Start** ड्रॉप‑डाउन सूची `[AudioFrame.setPlayMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setPlayMode-int-)` मेथड से मेल खाती है
- **Volume** `[AudioFrame.setVolume](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setVolume-int-)` मेथड से मेल खाती है
- **Play Across Slides** `[AudioFrame.setPlayAcrossSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setPlayAcrossSlides-boolean-)` मेथड से मेल खाती है
- **Loop until Stopped** `[AudioFrame.setPlayLoopMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setPlayLoopMode-boolean-)` मेथड से मेल खाती है
- **Hide During Show** `[AudioFrame.setHideAtShowing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setHideAtShowing-boolean-)` मेथड से मेल खाती है
- **Rewind after Playing** `[AudioFrame.setRewindAudio](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setRewindAudio-boolean-)` मेथड से मेल खाती है

PowerPoint **Editing** विकल्प जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AudioFrame) प्रॉपर्टीज़ से मेल खाते हैं:

- **Fade In** `[AudioFrame.setFadeInDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setFadeInDuration-float-)` मेथड से मेल खाता है
- **Fade Out** `[AudioFrame.setFadeOutDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setFadeOutDuration-float-)` मेथड से मेल खाता है
- **Trim Audio Start Time** `[AudioFrame.setTrimFromStart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setTrimFromStart-float-)` मेथड से मेल खाता है
- **Trim Audio End Time** का मान ऑडियो की अवधि माइनस `[AudioFrame.setTrimFromEnd](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setTrimFromEnd-float-)` मेथड के मान के बराबर है

PowerPoint **Volume control** ऑडियो कंट्रोल पैनल पर `[AudioFrame.setVolumeValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/audioframe/#setVolumeValue-float-)` मेथड से मेल खाता है। यह आपको ऑडियो की आवाज़ को प्रतिशत के रूप में बदलने देता है।

ऑडियो प्ले विकल्प बदलने के चरण:

1. [Create](#create-audio-frame) या ऑडियो फ़्रेम प्राप्त करें।
2. उन ऑडियो फ़्रेम प्रॉपर्टीज़ के नए मान सेट करें जिन्हें आप बदलना चाहते हैं।
3. संशोधित PowerPoint फ़ाइल को सेव करें।

यह Java कोड दिखाता है कि ऑडियो के विकल्प कैसे समायोजित करें:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // ऑडियोफ़्रेम आकार प्राप्त करता है
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // प्ले मोड को क्लिक पर चलने के लिए सेट करता है
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // वॉल्यूम को लो सेट करता है
    audioFrame.setVolume(AudioVolumeMode.Low);

    // ऑडियो को स्लाइड्स के Across में चलाने के लिए सेट करता है
    audioFrame.setPlayAcrossSlides(true);

    // ऑडियो के लिए लूप को निष्क्रिय करता है
    audioFrame.setPlayLoopMode(false);

    // स्लाइड शो के दौरान ऑडियोफ़्रेम को छुपाता है
    audioFrame.setHideAtShowing(true);

    // प्ले करने के बाद ऑडियो को शुरू में रीवाइंड करता है
    audioFrame.setRewindAudio(true);

    // PowerPoint फ़ाइल को डिस्क पर सेव करता है
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह Java उदाहरण दिखाता है कि एम्बेडेड ऑडियो के साथ नया ऑडियो फ़्रेम कैसे जोड़ें, उसे ट्रिम करें, और फ़ेड अवधि सेट करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.mp3"));
    IAudio audio = pres.getAudios().addAudio(audioData);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ट्रिमिंग की प्रारंभिक ऑफ़सेट को 1.5 सेकंड पर सेट करता है
    // ट्रिमिंग की अंतिम ऑफ़सेट को 2 सेकंड पर सेट करता है

    // फ़ेड‑इन अवधि को 200 मिलिसेकंड पर सेट करता है
    // फ़ेड‑आउट अवधि को 500 मिलिसेकंड पर सेट करता है

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

निम्न कोड सैंपल दिखाता है कि एम्बेडेड ऑडियो वाले ऑडियो फ़्रेम को कैसे प्राप्त करें और उसकी आवाज़ 85% पर सेट करें:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ऑडियो फ़्रेम आकार प्राप्त करता है
    IAudioFrame audioFrame = (IAudioFrame)slide.getShapes().get_Item(0);

    // ऑडियो वॉल्यूम को 85% पर सेट करता है
    audioFrame.setVolumeValue(85f);

    pres.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
finally {
    pres.dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको `[getCaptionTracks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/#getCaptionTracks--)` मेथड के माध्यम से ऑडियो फ़्रेम में क्लोज़्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक `[ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/)` लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स को इटरेट कर सकते हैं, और आवश्यकता पड़ने पर उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

`[getCaptionTracks](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/#getCaptionTracks--)` मेथड का उपयोग करके एक या अधिक कैप्शन ट्रैक्स को ऑडियो फ़्रेम से जोड़ें। नीचे के उदाहरण में एक ऑडियो फ़ाइल स्लाइड में जोड़ी गई है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया गया है।

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ़्रेम से जुड़े कैप्शन ट्रैक्स को इटरेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सेव कर सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और यूनिक आइडेंटिफ़ायर एक्सपोज़ करता है, जिसे कैप्शन एक्सपोर्ट करते समय उपयोग किया जा सकता है।

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame ) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सेव करें।
                Path filePath = Paths.get(captionTrack.getCaptionId() + ".vtt");
                Files.write(filePath, captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

**ऑडियो कैप्शन हटाएं**

ऑडियो फ़्रेम से कैप्शन हटाने के लिए `[ICaptionsCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/)` द्वारा प्रदान किए गए मेथड जैसे `[clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#clear--)`, `[remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-)` या `[removeAt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icaptionscollection/#removeAt-int-)` का उपयोग करें। नीचे का उदाहरण ऑडियो फ़्रेम से सभी कैप्शन ट्रैक्स को हटाता है।

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // ऑडियो फ़्रेम से सभी कैप्शन ट्रैक हटाएं।
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो निकालें**

Aspose.Slides for Java आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए साउंड को निकालने की सुविधा देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग किए गए साउंड को निकाल सकते हैं।

1. `[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation)` क्लास का एक इंस्टेंस बनाएं और ऑडियो वाली प्रेज़ेंटेशन लोड करें।
2. उसके इंडेक्स के द्वारा संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड के लिए `[slideshow transitions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IBaseSlide#getSlideShowTransition--)` तक पहुँचें।
4. साउंड को बाइट डेटा के रूप में निकालें।

यह Java कोड दिखाता है कि स्लाइड में उपयोग किए गए ऑडियो को कैसे निकालें:

```java
// एक Presentation क्लास का इंस्टेंस बनाता है जो प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // इच्छित स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // स्लाइड के स्लाइडशो ट्रांज़िशन इफ़ेक्ट्स प्राप्त करता है
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //ध्वनि को बाइट ऐरे में निकालता है
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं कई स्लाइड्स में एक ही ऑडियो एसेट को पुनः उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हां। ऑडियो को प्रेज़ेंटेशन की साझा `[audio collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getAudios--)` में एक बार जोड़ें और अतिरिक्त ऑडियो फ़्रेम बनाएं जो उस मौजूदा एसेट को रेफ़रेंस करते हों। इससे मीडिया डेटा की दोहराव नहीं होता और प्रेज़ेंटेशन का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ़्रेम में साउंड को पुनः बनाये बिना बदल सकता हूँ?**

हां। लिंक्ड साउंड के लिए, `[link path](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-)` को नए फ़ाइल की ओर अपडेट करें। एम्बेडेड साउंड के लिए, `[embedded audio](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-)` ऑब्जेक्ट को प्रेज़ेंटेशन की `[audio collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getAudios--)` से किसी अन्य ऑडियो से बदलें। फ़्रेम की फ़ॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग से प्रेज़ेंटेशन में संग्रहीत मूल ऑडियो डेटा बदलता है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करता है। मूल ऑडियो बाइट्स अपरिवर्तित रहते हैं और एम्बेडेड ऑडियो या प्रेज़ेंटेशन की ऑडियो कलेक्शन के माध्यम से उपलब्ध होते हैं।