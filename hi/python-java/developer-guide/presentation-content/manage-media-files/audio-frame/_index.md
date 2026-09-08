---
title: "Python का उपयोग करके प्रस्तुतियों में ऑडियो प्रबंधित करें"
linktitle: "ऑडियो फ्रेम"
type: docs
weight: 10
url: /hi/python-java/audio-frame/
keywords:
- "ऑडियो"
- "ऑडियो फ्रेम"
- "थंबनेल"
- "ऑडियो जोड़ें"
- "ऑडियो गुण"
- "ऑडियो विकल्प"
- "ऑडियो निकालें"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java में ऑडियो फ्रेम बनाएं और नियंत्रित करें - कोड उदाहरण जो एम्बेड, ट्रिम, लूप, और PPT, PPTX, तथा ODP प्रस्तुतियों में प्लेबैक कॉन्फ़िगर करने के लिए हैं।"
---
## **परिचय**

यह लेख Aspose.Slides में ऑडियो फ्रेम्स के साथ काम करने का तरीका बताता है। यह दिखाता है कि स्लाइड्स में एम्बेडेड ऑडियो कैसे जोड़ें, ऑडियो फ्रेम थंबनेल को कैसे अनुकूलित करें, वॉल्यूम, लूपिंग, छुपाने, ट्रिमिंग और फेड अवधि जैसी प्लेबैक विकल्प कैसे कॉन्फ़िगर करें, तथा स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को कैसे निकालें।

## **ऑडियो फ्रेम्स बनाएं**

Aspose.Slides for Python via Java आपको स्लाइड्स में ऑडियो फ़ाइलें जोड़ने की सुविधा देता है। ऑडियो फ़ाइलें स्लाइड्स में ऑडियो फ्रेम के रूप में एम्बेड की जाती हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टैंस बनाएं।
2. उसकी इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. वह ऑडियो फ़ाइल पढ़ें जिसे आप स्लाइड में एम्बेड करना चाहते हैं।
4. एम्बेडेड ऑडियो फ्रेम (जिसमें ऑडियो फ़ाइल है) को स्लाइड में जोड़ें।
5. [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) ऑब्जेक्ट द्वारा प्रदान किए गए [setPlayMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayMode) और [setVolume](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolume) को सेट करें।
6. संशोधित प्रस्तुति सहेजें।

यह Python कोड दिखाता है कि स्लाइड में एम्बेडेड ऑडियो फ्रेम कैसे जोड़ें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)
    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑडियो फ्रेम थंबनेल बदलें**

जब आप प्रस्तुति में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट छवि वाले फ्रेम के रूप में दिखता है (नीचे उस छवि को देखें)। आप ऑडियो फ्रेम की प्रीव्यू इमेज (अपने पसंदीदा चित्र) सेट करके बदल सकते हैं।

यह Python कोड दिखाता है कि ऑडियो फ्रेम का थंबनेल या प्रीव्यू इमेज कैसे बदलें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sample2.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)
    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑडियो प्ले विकल्प बदलें**

Aspose.Slides for Python via Java आपको ऑडियो की प्लेबैक या गुणों को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो के वॉल्यूम को समायोजित कर सकते हैं, ऑडियो को लूपेड चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकन को छिपा सकते हैं।

Microsoft PowerPoint में **Audio Options** पेन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:

- **Start** ड्रॉप‑डाउन सूची [setPlayMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayMode) मेथड से मेल खाती है
- **Volume** [setVolume](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolume) मेथड से मेल खाती है
- **Play Across Slides** [setPlayAcrossSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) मेथड से मेल खाती है
- **Loop until Stopped** [setPlayLoopMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayLoopMode) मेथड से मेल खाती है
- **Hide During Show** [setHideAtShowing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setHideAtShowing) मेथड से मेल खाती है
- **Rewind after Playing** [setRewindAudio](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setRewindAudio) मेथड से मेल खाती है

PowerPoint **Editing** विकल्प जो Aspose.Slides के [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:

- **Fade In** [setFadeInDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setFadeInDuration) मेथड से मेल खाती है
- **Fade Out** [setFadeOutDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setFadeOutDuration) मेथड से मेल खाती है
- **Trim Audio Start Time** [setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setTrimFromStart) मेथड से मेल खाती है
- **Trim Audio End Time** का मान ऑडियो अवधि में से [setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setTrimFromEnd) मेथड के मान को घटाकर प्राप्त होता है

ऑडियो कंट्रोल पैनल पर PowerPoint **Volume control** [setVolumeValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolumeValue) मेथड से संबंधित है। यह आपको प्रतिशत के रूप में ऑडियो वॉल्यूम बदलने की सुविधा देता है।

ऑडियो प्ले विकल्प बदलने के चरण:

1. [Create](#create-audio-frames) या ऑडियो फ्रेम प्राप्त करें।
2. उन ऑडियो फ्रेम प्रॉपर्टीज़ के लिए नए मान सेट करें जिन्हें आप बदलना चाहते हैं।
3. संशोधित PowerPoint फ़ाइल सहेजें।

यह Python कोड दर्शाता है कि ऑडियो के विकल्प कैसे समायोजित किए जाएँ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    audio_frame = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        # क्लिक पर चलाएँ, कम वॉल्यूम पर, स्लाइड्स पर फैलाकर, बिना लूपिंग के।
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # स्लाइड शो के दौरान फ्रेम को छुपाएँ और चलाने के बाद रिवाइंड करें।
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

यह Python उदाहरण दिखाता है कि एम्बेडेड ऑडियो के साथ नया ऑडियो फ्रेम कैसे जोड़ें, उसे ट्रिम करें, और फेड अवधि सेट करें:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = Path("sampleaudio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # शुरुआत से 1.5 सेकंड और अंत से 2 सेकंड ट्रिम करें।
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # फ़ेड-इन को 200 ms और फ़ेड-आउट को 500 ms पर सेट करें।
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

निम्नलिखित कोड सैंपल दिखाता है कि एम्बेडेड ऑडियो के साथ ऑडियो फ्रेम को प्राप्त करें और उसका वॉल्यूम 85% पर सेट करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **ऑडियो कैप्शन प्रबंधित करें**

Aspose.Slides आपको [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#getCaptionTracks) मेथड के माध्यम से एक ऑडियो फ्रेम में क्लोज़्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स पर इटररेट कर सकते हैं, तथा आवश्यकता पड़ने पर उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

ऑडियो फ्रेम में एक या अधिक कैप्शन ट्रैक संलग्न करने के लिए [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#getCaptionTracks) मेथड का उपयोग करें। नीचे दिए गए उदाहरण में, एक ऑडियो फ़ाइल स्लाइड में जोड़े जाने के बाद, एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया जाता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # WebVTT फ़ाइल से एक नया कैप्शन ट्रैक जोड़ें।
    audio_frame.getCaptionTracks().add("New track", "track.vtt")
    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**ऑडियो कैप्शन निकालें**

आप ऑडियो फ्रेम से जुड़े कैप्शन ट्रैक्स पर इटररेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और अद्वितीय पहचानकर्ता प्रदान करता है, जिसका उपयोग एक्सपोर्ट करते समय किया जा सकता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

**ऑडियो कैप्शन हटाएँ**

ऑडियो फ्रेम से कैप्शन हटाने के लिए [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) द्वारा प्रदान किए गए मेथड जैसे [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। नीचे का उदाहरण ऑडियो फ्रेम से सभी कैप्शन ट्रैक्स हटाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    audio_frame = slide.getShapes().get_Item(0)
    if isinstance(audio_frame, AudioFrame):
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

## **ऑडियो निकालें**

Aspose.Slides for Python via Java आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए ध्वनि को निकालने की सुविधा देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग किए गए ध्वनि को निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टैंस बनाकर वह प्रस्तुति लोड करें जिसमें ऑडियो है।
2. उसकी इंडेक्स के माध्यम से संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड के लिए [slideshow transitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideShowTransition) तक पहुँचें।
4. ध्वनि को बाइट डेटा के रूप में निकालें।

यह Python कोड दिखाता है कि स्लाइड में उपयोग किए गए ऑडियो को कैसे निकालें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print("Length:", len(audio_data))
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड्स में पुन: उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हां। ऑडियो को एक बार प्रस्तुति के साझा [audio collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAudios) में जोड़ें और अतिरिक्त ऑडियो फ्रेम बनाएं जो उस मौजूदा एसेट का रेफ़रेंस लें। इससे मीडिया डेटा की डुप्लिकेशन नहीं होती और प्रस्तुति का आकार नियंत्रण में रहता है।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बदल सकता हूँ बिना शेप को पुनः निर्मित किए?**

हां। लिंक्ड साउंड के लिए, नया फ़ाइल पाथ दर्शाने हेतु [link path](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setLinkPathLong) अपडेट करें। एम्बेडेड साउंड के लिए, प्रस्तुति के [audio collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAudios) से अन्य एम्बेडेड ऑडियो ऑब्जेक्ट के साथ बदलें। फ्रेम का फ़ॉर्मेट और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत मूल ऑडियो डेटा को बदल देती है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहती हैं और एम्बेडेड ऑडियो या प्रस्तुति के ऑडियो कलेक्शन के माध्यम से पहुंच योग्य रहती हैं।