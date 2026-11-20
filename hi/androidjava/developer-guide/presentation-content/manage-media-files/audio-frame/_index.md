---
title: Android पर प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
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
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **अवलोकन**

एक ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for Android via Java के साथ, आप एक ऑडियो क्लिप एम्बेड कर सकते हैं, उसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन जोड़ सकते हैं। आप स्लाइड ट्रांज़िशन से जुड़ी ध्वनि भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

पहली स्लाइड पर स्थानीय ऑडियो क्लिप एम्बेड करने के लिए [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) का उपयोग करें। पहले दो कोऑर्डिनेट्स फ्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान उसकी चौड़ाई और ऊँचाई को पॉइंट्स में सेट करते हैं। यह उदाहरण क्लिप को स्वचालित रूप से शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) को कॉल करता है और आवाज़ के प्रीसेट को चुनने के लिए [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) को कॉल करता है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audioStream);
    audioFrame.setPlayMode(AudioPlayModePreset.Auto);
    audioFrame.setVolume(AudioVolumeMode.Loud);

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो फ्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप से, ऑडियो फ्रेम एक स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) से एक छवि जोड़ें और उसे फ्रेम की तस्वीर पर [setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) के साथ सेट करें। यह उदाहरण एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में JPEG का उपयोग करता है।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav");
     FileInputStream imageStream = new FileInputStream("eagle.jpeg")) {
    IPPImage thumbnail = presentation.getImages().addImage(imageStream);

    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioFrame.getPictureFormat().getPicture().setImage(thumbnail);

    presentation.save("example_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint के **ऑडियो विकल्प** नियंत्रण निर्धारित करते हैं कि क्लिप कब शुरू होती है, उसकी आवाज़ कितनी तेज़ है, और स्लाइड शो के दौरान इसका व्यवहार कैसा रहेगा।

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for Android via Java विधि |
| --- | --- |
| Start | [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| Volume preset | [setVolume](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolume-int-) |
| Play Across Slides | [setPlayAcrossSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| Loop until Stopped | [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| Hide During Show | [setHideAtShowing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| Rewind after Playing | [setRewindAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| Fade In | [setFadeInDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| Fade Out | [setFadeOutDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| Trim Audio start time | [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| Trim Audio end time | [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| Volume slider | [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

यह उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम ढूँढ़ता है, क्लिक पर प्लेबैक शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setPlayMode-int-) को कॉल करता है, और कम वॉल्यूम प्रीसेट चुनता है। क्लिप स्लाइड्स के बीच चलती रहती है जबकि लूपिंग निष्क्रिय है। आइकन शो के दौरान छिपा रहता है, और प्लेबैक के बाद क्लिप रीवाइंड हो जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setPlayMode(AudioPlayModePreset.OnClick);
        audioFrame.setVolume(AudioVolumeMode.Low);
        audioFrame.setPlayAcrossSlides(true);
        audioFrame.setPlayLoopMode(false);
        audioFrame.setHideAtShowing(true);
        audioFrame.setRewindAudio(true);
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

3.5 सेकंड से अधिक लंबी क्लिप के लिए, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को स्किप करता है। [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) क्लिप के अंत से हटाए जाने वाले अवधि को लेता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए, उस ऑफ़सेट को पूर्ण क्लिप अवधि से घटाएँ। ट्रिम्ड क्लिप 200 मिलीसेकंड में फ़ेड इन होती है और 500 मिलीसेकंड में फ़ेड आउट होती है। सभी चार मेथड्स मिलिसेकंड में मान लेते हैं।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audioStream);
    audioFrame.setTrimFromStart(1500f);
    audioFrame.setTrimFromEnd(2000f);
    audioFrame.setFadeInDuration(200f);
    audioFrame.setFadeOutDuration(500f);

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

प्लेबैक वॉल्यूम को विशिष्ट प्रतिशत पर सेट करने के लिए, [setVolumeValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setVolumeValue-float-) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम को 85% सेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.setVolumeValue(85f);
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ्रेम अपने कैप्शन ट्रैक्स तक पहुँच प्रदान करता है, जिसे आप [getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getCaptionTracks--) के माध्यम से प्राप्त कर सकते हैं। कलेक्शन का उपयोग करके आप क्लिप में WebVTT कैप्शन जोड़ सकते हैं, मौजूदा ट्रैक्स एक्सपोर्ट कर सकते हैं, या उन्हें हटा सकते हैं।

### **ऑडियो कैप्शन जोड़ें**

यह उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक को संलग्न करने के लिए [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) का उपयोग करता है। पहला तर्क ट्रैक लेबल प्रदान करता है, और दूसरा फ़ाइल का परिचय देता है जिसमें समय‑संकुचित कैप्शन होते हैं।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

try (FileInputStream audioStream = new FileInputStream("audio.wav")) {
    IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audioStream);
    audioFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर ऑडियो फ्रेम से संलग्न प्रत्येक कैप्शन ट्रैक को एक्सपोर्ट करता है। यह [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getBinaryData--) द्वारा लौटाए गए बाइट्स को WebVTT फ़ाइल में लिखता है और [getCaptionId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getCaptionId--) द्वारा लौटाए गए पहचानकर्ता को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            try (FileOutputStream output = new FileOutputStream(track.getCaptionId() + ".vtt")) {
                output.write(track.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन हटाएँ**

व्यक्तिगत ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन हटाने के लिए [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/#clear--) का उपयोग करता है, जबकि क्लिप को बरकरार रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudioFrame audioFrame = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAudioFrame) {
            audioFrame = (IAudioFrame) shape;
            break;
        }
    }

    if (audioFrame != null) {
        audioFrame.getCaptionTracks().clear();
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The first slide has no audio frame.");
    }
} finally {
    presentation.dispose();
}
```

### **ऑडियो कैप्शन में एक लाइन खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में एक लाइन खोजने के लिए, मेमोरी में [getDataAsString](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/#getDataAsString--) द्वारा लौटाए गए टेक्स्ट को सर्च करें। साधारण‑टेक्स्ट WebVTT क्यू में टाइमिंग लाइन में `-->` होता है, उसके बाद कैप्शन लाइन्स आती हैं, और एक खाली लाइन क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन लाइन को प्रिंट करता है जिसमें “café” शब्द मौजूद है।

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            boolean inCue = false;
            String captions = track.getDataAsString();
            for (String line : captions.split("\\r\\n|\\r|\\n")) {
                if (line.isEmpty()) {
                    inCue = false;
                } else if (line.contains("-->")) {
                    inCue = true;
                } else if (inCue && line.toLowerCase(Locale.ROOT).contains("café")) {
                    System.out.println(track.getLabel() + ": " + line);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ऑडियो निकालें**

स्लाइड ट्रांज़िशन का अपना ध्वनि हो सकता है। इसे प्राप्त करने के लिए स्लाइड ट्रांज़िशन पर [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSound--) कॉल करें। यह उदाहरण [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) द्वारा लौटाए गए बाइट्स को पढ़ता है और बाइट्स की संख्या प्रिंट करता है। यदि पहली स्लाइड में कोई ट्रांज़िशन साउंड नहीं है, तो यह एक संदेश प्रिंट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AudioSlide.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAudio sound = slide.getSlideShowTransition().getSound();
    if (sound != null) {
        byte[] audioData = sound.getBinaryData();
        System.out.println("Transition sound: " + audioData.length + " bytes.");
    } else {
        System.out.println("The first slide has no transition sound.");
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड्स में दोहराए बिना पुन: उपयोग कर सकता हूँ?**

हां। क्लिप को प्रस्तुति के [audio collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getAudios--) में एक बार जोड़ें और प्रत्येक स्लाइड के लिए वही ऑडियो ऑब्जेक्ट [addAudioFrameEmbedded](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) को पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि बदल सकता हूँ?**

हां। लिंक्ड साउंड के लिए, प्रतिस्थापन फ़ाइल की ओर इंगित करने के लिए [setLinkPathLong](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) का प्रयोग करें। एम्बेडेड साउंड के लिए, प्रस्तुति के ऑडियो कलेक्शन से किसी अन्य क्लिप को चुनने के लिए [setEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) का उपयोग करें। दोनों तरीके मौजूदा फ्रेम को बरकरार रखते हैं।

**क्या ट्रिमिंग से प्रस्तुति में संग्रहीत ऑडियो डेटा बदलता है?**

नहीं। [setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) और [setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) प्लेबैक सीमाओं को सेट करते हैं। आप अभी भी [getEmbeddedAudio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) से पूरी क्लिप प्राप्त कर सकते हैं।

---
title: Android पर प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
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
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---