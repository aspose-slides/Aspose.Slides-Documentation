---
title: जावा का उपयोग करके प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ स्लाइड्स में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **समीक्षा**

ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for Java के साथ, आप एक ऑडियो क्लिप को एम्बेड कर सकते हैं, इसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन संलग्न कर सकते हैं। आप स्लाइड ट्रांज़िशन को असाइन्ड ध्वनि भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाना**

स्थानीय ऑडियो क्लिप को पहली स्लाइड पर एम्बेड करने के लिए [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) का उपयोग करें। पहले दो निर्देशांक फ्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान इसकी चौड़ाई और ऊँचाई को पॉइंट्स में सेट करते हैं। यह उदाहरण क्लिप को स्वतः शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) को कॉल करता है और तेज़ ध्वनि प्रीसेट चुनने के लिए [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) को कॉल करता है।

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
## **ऑडियो फ्रेम थंबनेल बदलना**

डिफ़ॉल्ट रूप से, ऑडियो फ्रेम एक स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-java.io.InputStream-) से एक छवि जोड़ें और फ्रेम की तस्वीर पर [setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#setImage-com.aspose.slides.IPPImage-) सेट करें। उदाहरण एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में JPEG का उपयोग करता है।

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
## **ऑडियो प्ले विकल्प बदलना**

PowerPoint के **Audio Options** नियंत्रण यह निर्धारित करते हैं कि क्लिप कब शुरू होगी, इसकी आवाज़ कितनी तेज़ होगी, और स्लाइड शो के दौरान इसका व्यवहार कैसा रहेगा।

![ऑडियो फ्रेम के लिए PowerPoint ऑडियो विकल्प नियंत्रण](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for Java method |
| --- | --- |
| शुरू | [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) |
| वॉल्यूम प्रीसेट | [setVolume](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolume-int-) |
| स्लाइड्स में प्ले करें | [setPlayAcrossSlides](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayAcrossSlides-boolean-) |
| रोकने तक लूप | [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayLoopMode-boolean-) |
| शो के दौरान छुपाएँ | [setHideAtShowing](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setHideAtShowing-boolean-) |
| चलाने के बाद रिवाइंड | [setRewindAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setRewindAudio-boolean-) |
| फ़ेड इन | [setFadeInDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeInDuration-float-) |
| फ़ेड आउट | [setFadeOutDuration](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setFadeOutDuration-float-) |
| ऑडियो शुरू समय ट्रिम करें | [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) |
| ऑडियो समाप्ति समय ट्रिम करें | [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) |
| वॉल्यूम स्लाइडर | [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) |

यह उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम खोजता है, क्लिक पर प्लेबैक शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setPlayMode-int-) को कॉल करता है, और कम वॉल्यूम प्रीसेट चुनता है। क्लिप लूप बंद रखने के साथ स्लाइड्स के बीच जारी रहती है। शो के दौरान आइकन छुपा रहता है, और प्लेबैक के बाद क्लिप रिवाइंड होती है।

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

3.5 सेकंड से अधिक लंबे क्लिप के लिए, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) क्लिप के अंत से हटाए जाने वाले समय को लेती है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए, उस ऑफ़सेट को पूर्ण क्लिप अवधि से घटाएँ। ट्रिम किया गया क्लिप 200 मिलिसेकंड में फ़ेड इन होता है और 500 मिलिसेकंड में फ़ेड आउट। सभी चार मेथड मिलिसेकंड में मान लेते हैं।

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

प्लेबैक वॉल्यूम को विशिष्ट प्रतिशत पर सेट करने के लिए, [setVolumeValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setVolumeValue-float-) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम को 85% सेट करता है।

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

प्रत्येक ऑडियो फ्रेम [getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getCaptionTracks--) के माध्यम से अपने कैप्शन ट्रैक्स तक पहुँच प्रदान करता है। संग्रह का उपयोग करके क्लिप में WebVTT कैप्शन संलग्न करें, मौजूदा ट्रैक्स निर्यात करें, या उन्हें हटाएँ।

### **ऑडियो कैप्शन जोड़ें**

उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक संलग्न करने के लिए [add](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#add-java.lang.String-java.lang.String-) का उपयोग करता है। पहला तर्क ट्रैक लेबल देता है, और दूसरा टाइमेड कैप्शन वाली फ़ाइल को पहचानता है।

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

यह उदाहरण पहली स्लाइड पर एक ऑडियो फ्रेम से जुड़े प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getBinaryData--) द्वारा लौटाए गए बाइट्स को एक WebVTT फ़ाइल में लिखता है और [getCaptionId](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getCaptionId--) द्वारा लौटाए गए पहचानकर्ता को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("audio_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAudioFrame)) {
            continue;
        }
        IAudioFrame audioFrame = (IAudioFrame) shape;
        for (ICaptions track : audioFrame.getCaptionTracks()) {
            Path output = Paths.get(track.getCaptionId() + ".vtt");
            Files.write(output, track.getBinaryData());
        }
    }
} finally {
    presentation.dispose();
}
```
### **ऑडियो कैप्शन हटाएँ**

एक व्यक्तिगत ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) या [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#removeAt-int-) का उपयोग करें। उदाहरण सभी कैप्शन को पहले स्लाइड के पहले ऑडियो फ्रेम से क्लिप को संरक्षित रखते हुए हटाने के लिए [clear](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/#clear--) का उपयोग करता है।

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
### **ऑडियो कैप्शन में एक पंक्ति खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में एक पंक्ति खोजने के लिए, मेमोरी में [getDataAsString](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/#getDataAsString--) द्वारा लौटाए गए टेक्स्ट को खोजें। साधारण टेक्स्ट WebVTT क्यू में, टाइमिंग लाइन में `-->` होता है, उसके बाद कैप्शन लाइन्स आती हैं, और एक खाली लाइन क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक कैप्शन लाइन को जो “café” शामिल करती है, प्रिंट करता है।

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
            for (String line : captions.split("\\R")) {
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

एक स्लाइड ट्रांज़िशन की अपनी ध्वनि हो सकती है। उसे प्राप्त करने के लिए, स्लाइड ट्रांज़िशन पर [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSound--) को कॉल करें। उदाहरण [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) द्वारा लौटाए गए बाइट्स तक पहुँचता है और बाइट्स की संख्या प्रिंट करता है। यदि पहली स्लाइड में ट्रांज़िशन साउंड नहीं है, तो यह एक संदेश प्रिंट करता है।

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

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड्स में बिना डुप्लिकेट किए पुन: उपयोग कर सकता हूँ?**

हां। क्लिप को प्रस्तुति की [audio collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getAudios--) में एक बार जोड़ें और प्रत्येक स्लाइड के लिए वही ऑडियो ऑब्जेक्ट [addAudioFrameEmbedded](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-com.aspose.slides.IAudio-) को पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि बदल सकता हूँ?**

हां। लिंक्ड साउंड के लिए, प्रतिस्थापन फ़ाइल को इंगित करने के लिए [setLinkPathLong](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setLinkPathLong-java.lang.String-) का उपयोग करें। एम्बेडेड साउंड के लिए, प्रस्तुति की ऑडियो संग्रह से अन्य क्लिप को चुनने हेतु [setEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setEmbeddedAudio-com.aspose.slides.IAudio-) का उपयोग करें। दोनों तरीके मौजूदा फ्रेम को संरक्षित रखते हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत ऑडियो डेटा को बदल देती है?**

नहीं। [setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromStart-float-) और [setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#setTrimFromEnd-float-) प्लेबैक सीमाएँ निर्धारित करते हैं। आप अभी भी [getEmbeddedAudio](https://reference.aspose.com/slides/java/com.aspose.slides/iaudioframe/#getEmbeddedAudio--) से पूरी क्लिप प्राप्त कर सकते हैं।