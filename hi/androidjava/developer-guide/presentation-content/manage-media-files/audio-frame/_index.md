---
title: Android पर प्रस्तुतियों में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/androidjava/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में ऑडियो फ्रेम बनाएं और नियंत्रित करें—एंबेड, ट्रिम, लूप और PPT, PPTX, और ODP प्रस्तुतियों में प्लेबैक कॉन्फ़िगर करने के लिए Java उदाहरण।"
---
## **परिचय**

यह लेख Aspose.Slides में ऑडियो फ्रेम के साथ काम करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड में एंबेडेड ऑडियो कैसे जोड़ें, ऑडियो फ्रेम थंबनेल को कस्टमाइज़ करें, वॉल्यूम, लूपिंग, हाइडिंग, ट्रिमिंग, और फ़ेड अवधि जैसी प्लेबैक विकल्पों को कॉन्फ़िगर करें, और स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को निकालें।

## **ऑडियो फ्रेम बनाएं**
Aspose.Slides for Android via Java आपको स्लाइड में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड में ऑडियो फ्रेम के रूप में एंबेड की जाती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में एंबेड करने के लिए इच्छित ऑडियो फ़ाइल स्ट्रीम लोड करें।
4. स्लाइड में एंबेडेड ऑडियो फ्रेम (जिसमें ऑडियो फ़ाइल होती है) जोड़ें।
5. [PlayMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioPlayModePreset) और `Volume` को [IAudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IAudioFrame) ऑब्जेक्ट द्वारा उजागर किया गया सेट करें।
6. संशोधित प्रेजेंटेशन को सेव करें।

यह Java कोड दिखाता है कि स्लाइड में एंबेडेड ऑडियो फ्रेम कैसे जोड़ें:

```java
// एक Presentation क्लास का इंस्टेंस बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
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

## **ऑडियो फ्रेम थंबनेल बदलें**

जब आप प्रेजेंटेशन में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट इमेज के साथ फ्रेम के रूप में दिखता है (नीचे के सेक्शन में छवि देखें)। आप ऑडियो फ्रेम की प्रीव्यू इमेज बदल सकते हैं (अपनी पसंदीदा इमेज सेट करें)।

यह Java कोड दिखाता है कि ऑडियो फ्रेम की थंबनेल या प्रीव्यू इमेज कैसे बदलें:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // निर्दिष्ट स्थान और आकार के साथ स्लाइड में एक ऑडियो फ्रेम जोड़ता है।
    FileInputStream audioStream = new FileInputStream("sample2.mp3");
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.close();

    // प्रस्तुति संसाधनों में एक छवि जोड़ता है।
    IPPImage picture;
    IImage image = Images.fromFile("eagle.jpeg");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // ऑडियो फ्रेम के लिए छवि सेट करता है।
    audioFrame.getPictureFormat().getPicture().setImage(picture); // <-----

    //संशोधित प्रस्तुति को डिस्क पर सहेजता है
    presentation.save("example_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for Android via Java आपको ऑडियो की प्लेबैक या प्रॉपर्टीज़ को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूप में चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकन को छिपा भी सकते हैं।

Microsoft PowerPoint में **Audio Options** पैन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame) प्रॉपर्टीज़ से मेल खाते हैं:

- **Start** ड्रॉप-डाउन सूची [AudioFrame.PlayMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getPlayMode--) प्रॉपर्टी से मेल खाती है।
- **Volume** [AudioFrame.Volume](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getVolume--) प्रॉपर्टी से मेल खाती है।
- **Play Across Slides** [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getPlayAcrossSlides--) प्रॉपर्टी से मेल खाती है।
- **Loop until Stopped** [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getPlayLoopMode--) प्रॉपर्टी से मेल खाती है।
- **Hide During Show** [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getHideAtShowing--) प्रॉपर्टी से मेल खाती है।
- **Rewind after Playing** [AudioFrame.RewindAudio](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/AudioFrame#getRewindAudio--) प्रॉपर्टी से मेल खाती है।

PowerPoint **Editing** options जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:

- **Fade In** [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/#getFadeInDuration--) प्रॉपर्टी से मेल खाती है।
- **Fade Out** [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/#getFadeOutDuration--) प्रॉपर्टी से मेल खाती है।
- **Trim Audio Start Time** [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/#getTrimFromStart--) प्रॉपर्टी से मेल खाती है।
- **Trim Audio End Time** मान ऑडियो अवधि में से [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/#getTrimFromEnd--) प्रॉपर्टी के मान को घटाकर प्राप्त होता है।

PowerPoint **Volume नियंत्रक** ऑडियो कंट्रोल पैनल पर [AudioFrame.VolumeValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/audioframe/#getVolumeValue--) प्रॉपर्टी से मेल खाता है। यह आपको ऑडियो वॉल्यूम को प्रतिशत के रूप में बदलने देता है।

ऑडियो प्ले विकल्प को बदलने का तरीका यह है:

1. [Create](#create-audio-frame) या ऑडियो फ्रेम प्राप्त करें।
2. ऑडियो फ्रेम प्रॉपर्टीज़ के लिए जिन मानों को आप समायोजित करना चाहते हैं, उन्हें सेट करें।
3. संशोधित PowerPoint फ़ाइल को सेव करें।

यह Java कोड एक ऑपरेशन दर्शाता है जिसमें ऑडियो के विकल्प समायोजित किए जाते हैं:

```java 
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    // AudioFrame shape प्राप्त करता है
    AudioFrame audioFrame = (AudioFrame)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    // प्ले मोड को क्लिक पर चलने के लिए सेट करता है
    audioFrame.setPlayMode(AudioPlayModePreset.OnClick);

    // वॉल्यूम को कम सेट करता है
    audioFrame.setVolume(AudioVolumeMode.Low);

    // ऑडियो को स्लाइड्स के पार चलाने के लिए सेट करता है
    audioFrame.setPlayAcrossSlides(true);

    // ऑडियो के लिए लूप को अक्षम करता है
    audioFrame.setPlayLoopMode(false);

    // स्लाइड शो के दौरान AudioFrame को छुपाता है
    audioFrame.setHideAtShowing(true);

    // प्ले करने के बाद ऑडियो को शुरू से रीवाइंड करता है
    audioFrame.setRewindAudio(true);

    // PowerPoint फ़ाइल को डिस्क पर सहेजता है
    pres.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

यह Java उदाहरण दिखाता है कि एंबेडेड ऑडियो के साथ नया ऑडियो फ्रेम कैसे जोड़ें, उसे ट्रिम करें, और फ़ेड अवधि सेट करें:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    FileInputStream audioData = new FileInputStream("sampleaudio.mp3");
    IAudio audio = pres.getAudios().addAudio(audioData, LoadingStreamBehavior.KeepLocked);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio);

    // ट्रिमिंग का प्रारंभिक ऑफ़सेट 1.5 सेकंड पर सेट करता है
    // ट्रिमिंग का समाप्ति ऑफ़सेट 2 सेकंड पर सेट करता है
    // फेड-इन अवधि को 200 मिलीसेकंड पर सेट करता है
    // फेड-आउट अवधि को 500 मिलीसेकंड पर सेट करता है

    pres.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

निम्नलिखित कोड नमूना दिखाता है कि एंबेडेड ऑडियो के साथ ऑडियो फ्रेम को कैसे प्राप्त करें और उसकी वॉल्यूम को 85% पर सेट करें:

```java
Presentation pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ऑडियो फ्रेम शेप प्राप्त करता है
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

Aspose.Slides आपको [getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) मेथड के माध्यम से ऑडियो फ्रेम में क्लोज्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स पर इटरेट कर सकते हैं, और आवश्यकता पड़ने पर उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

[getCaptionTracks](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) मेथड का उपयोग करके एक या अधिक कैप्शन ट्रैक्स को ऑडियो फ्रेम से संलग्न करें। नीचे के उदाहरण में, एक ऑडियो फ़ाइल स्लाइड में जोड़ी गई है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया गया है।

```java
Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("audio.mp3"));
    IAudio audio = presentation.getAudios().addAudio(audioData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio);

    // WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    audioFrame.getCaptionTracks().add("New track", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ्रेम से जुड़े कैप्शन ट्रैक्स पर इटरेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और अद्वितीय पहचानकर्ता उजागर करता है, जिसका उपयोग कैप्शन निर्यात करते समय किया जा सकता है।

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            IAudioFrame audioFrame = (IAudioFrame) shape;
            for (ICaptions captionTrack : audioFrame.getCaptionTracks()) {
                // कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
                FileOutputStream fos = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                fos.write(captionTrack.getBinaryData());
                fos.close();
            }
        }
    }
} catch (IOException e){
} finally {
    presentation.dispose();
}
```

**ऑडियो कैप्शन हटाएँ**

ऑडियो फ्रेम से कैप्शन हटाने के लिए, [ICaptionsCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/) द्वारा उपलब्ध मेथड्स जैसे कि [clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#clear--), [remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-), या [removeAt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) का उपयोग करें। नीचे का उदाहरण ऑडियो फ्रेम से सभी कैप्शन ट्रैक्स को हटाता है।

```java
Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAudioFrame audioFrame = (IAudioFrame) slide.getShapes().get_Item(0);

    // ऑडियो फ्रेम से सभी कैप्शन ट्रैक हटाएँ।
    audioFrame.getCaptionTracks().clear();

    presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो निकालें**

Aspose.Slides for Android via Java आपको स्लाइड शो ट्रांज़िशन में उपयोग की गई आवाज़ निकालने की अनुमति देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग की गई आवाज़ निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं और ऑडियो वाले प्रेजेंटेशन को लोड करें।
2. संबंधित स्लाइड का रेफ़रेंस उसके इंडेक्स से प्राप्त करें।
3. स्लाइड के लिए [slideshow transitions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IBaseSlide#getSlideShowTransition--) तक पहुंचें।
4. ध्वनि को बाइट डेटा में निकालें।

यह Java कोड दिखाता है कि स्लाइड में उपयोग किए गए ऑडियो को कैसे निकालें:

```java
// एक Presentation क्लास का इंस्टेंस बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation("AudioSlide.pptx");
try {
    // वांछित स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // स्लाइड के लिए स्लाइडशो ट्रांज़िशन प्रभाव प्राप्त करता है
    ISlideShowTransition transition = slide.getSlideShowTransition();
    
    //ध्वनि को बाइट एरे में निकालता है
    byte[] audio = transition.getSound().getBinaryData();
    System.out.println("Length: " + audio.length);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड में पुन: उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हां। ऑडियो को प्रेजेंटेशन की साझा [audio collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getAudios--) में एक बार जोड़ें और अतिरिक्त ऑडियो फ्रेम बनाएं जो उस मौजूदा एसेट को रेफ़रेंस करते हैं। इससे मीडिया डेटा की दोहराव नहीं होती और प्रेजेंटेशन का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ्रेम में साउंड को बदल सकता हूँ बिना आकार को फिर से बनाये?**

हां। लिंक्ड साउंड के लिए, [link path](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) को नए फ़ाइल की ओर अपडेट करें। एंबेडेड साउंड के लिए, एंबेडेड ऑडियो ऑब्जेक्ट को प्रेजेंटेशन की [audio collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getAudios--) से दूसरे ऑडियो से बदलें। फ्रेम का फ़ॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग प्रेजेंटेशन में संग्रहीत मूल ऑडियो डेटा को बदलती है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहते हैं और एंबेडेड ऑडियो या प्रेजेंटेशन की ऑडियो कलेक्षण के माध्यम से उपलब्ध होते हैं।