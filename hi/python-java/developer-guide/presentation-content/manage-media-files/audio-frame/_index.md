---
title: Python का उपयोग करके प्रस्तुतियों में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/python-java/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java में ऑडियो फ्रेम बनाएं और नियंत्रित करें—एम्बेड करने, ट्रिम करने, लूप करने और PPT, PPTX और ODP प्रस्तुतियों में प्लेबैक को कॉन्फ़िगर करने के कोड उदाहरण।"
---
## **समीक्षा**

यह लेख Aspose.Slides में ऑडियो फ्रेम के साथ काम करने के तरीकों को समझाता है। यह स्लाइड में एम्बेडेड ऑडियो जोड़ना, ऑडियो फ्रेम थंबनेल को अनुकूलित करना, आवाज़, लूपिंग, छुपाना, ट्रिमिंग और फ़ेड अवधि जैसी प्लेबैक विकल्पों को कॉन्फ़िगर करना, और स्लाइडशो ट्रांज़िशन में प्रयुक्त ऑडियो को निकालना दिखाता है।

## **ऑडियो फ्रेम बनाएं**

Aspose.Slides for Python via Java आपको स्लाइड में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड में ऑडियो फ्रेम के रूप में एम्बेड की जाती हैं। 

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का एक इंस्टेंस बनाएं।
2. अपने सूचकांक से स्लाइड का संदर्भ प्राप्त करें।
3. वह ऑडियो फ़ाइल पढ़ें जिसे आप स्लाइड में एम्बेड करना चाहते हैं।
4. एम्बेडेड ऑडियो फ्रेम (जिसमें ऑडियो फ़ाइल होती है) को स्लाइड में जोड़ें।
5. [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) ऑब्जेक्ट द्वारा उपलब्ध [setPlayMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayMode) और [setVolume](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolume) का उपयोग करें।
6. संशोधित प्रस्तुति को सहेजें।

यह Python कोड आपको दिखाता है कि स्लाइड में एम्बेडेड ऑडियो फ्रेम कैसे जोड़ें:

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

जब आप प्रस्तुति में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक फ्रेम के रूप में मानक डिफ़ॉल्ट छवि के साथ दिखाई देता है (नीचे दिए सेक्शन में चित्र देखें)। आप ऑडियो फ्रेम की प्रीव्यू छवि को अपनी पसंद की छवि से बदल सकते हैं।

यह Python कोड आपको दिखाता है कि ऑडियो फ्रेम का थंबनेल या प्रीव्यू छवि कैसे बदलें:

```python
from pathlib import Path

import jpime
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

Aspose.Slides for Python via Java आपको ऑडियो प्लेबैक या गुणों को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की आवाज़ समायोजित कर सकते हैं, ऑडियो को लूप पर सेट कर सकते हैं, या यहाँ तक कि ऑडियो आइकन को छिपा भी सकते हैं।

माइक्रोसॉफ्ट PowerPoint में **Audio Options** पेन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) गुणों के अनुरूप हैं:

- **Start** ड्रॉप-डाउन सूची [setPlayMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayMode) मेथड से मेल खाती है
- **Volume** [setVolume](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolume) मेथड से मेल खाता है
- **Play Across Slides** [setPlayAcrossSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) मेथड से मेल खाता है
- **Loop until Stopped** [setPlayLoopMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setPlayLoopMode) मेथड से मेल खाता है
- **Hide During Show** [setHideAtShowing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setHideAtShowing) मेथड से मेल खाता है
- **Rewind after Playing** [setRewindAudio](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setRewindAudio) मेथड से मेल खाता है

PowerPoint **Editing** विकल्प जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/) गुणों के अनुरूप हैं:

- **Fade In** [setFadeInDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setFadeInDuration) मेथड से मेल खाता है
- **Fade Out** [setFadeOutDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setFadeOutDuration) मेथड से मेल खाता है
- **Trim Audio Start Time** [setTrimFromStart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setTrimFromStart) मेथड से मेल खाता है
- **Trim Audio End Time** का मान ऑडियो अवधि में से [setTrimFromEnd](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setTrimFromEnd) मेथड द्वारा सेट किए गए मान को घटाकर बराबर होता है

PowerPoint **Volume control** ऑडियो कंट्रोल पैनल पर [setVolumeValue](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setVolumeValue) मेथड के अनुरूप है। यह आपको ऑडियो वॉल्यूम को प्रतिशत के रूप में बदलने की अनुमति देता है।

यहाँ बताया गया है कि आप Audio Play विकल्प कैसे बदल सकते हैं:

1. [Create](#create-audio-frames) या ऑडियो फ्रेम प्राप्त करें।
2. उन ऑडियो फ्रेम गुणों के लिए नए मान सेट करें जिन्हें आप समायोजित करना चाहते हैं।
3. संशोधित PowerPoint फ़ाइल को सहेजें।

यह Python कोड एक ऐसी क्रिया को प्रदर्शित करता है जिसमें ऑडियो विकल्प समायोजित किए गए हैं:

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
        # क्लिक पर कम वॉल्यूम पर चलाएं, स्लाइड्स के बीच, बिना लूप किए।
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # स्लाइड शो के दौरान फ्रेम को छिपाएँ और प्ले करने के बाद रिवाइंड करें।
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)
        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not an audio frame.")
finally:
    presentation.dispose()
```

यह Python उदाहरण दिखाता है कि एम्बेडेड ऑडियो के साथ नया ऑडियो फ्रेम कैसे जोड़ें, उसे ट्रिम करें, और फ़ेड अवधि कैसे सेट करें:

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

    # शुरू से 1.5 सेकंड और अंत से 2 सेकंड ट्रिम करें।
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # फ़ेड-इन को 200 मि.से. और फ़ेड-आउट को 500 मि.से. सेट करें।
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)
    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

नीचे दिया गया कोड नमूना दिखाता है कि एम्बेडेड ऑडियो वाले ऑडियो फ्रेम को कैसे प्राप्त करें और उसकी आवाज़ को 85% पर कैसे सेट करें:

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

Aspose.Slides आपको [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#getCaptionTracks) मेथड के माध्यम से ऑडियो फ्रेम में क्लोज्ड कैप्शन जोड़ने की अनुमति देता है। यह मेथड एक [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) लौटाता है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स पर इटरेट कर सकते हैं, और आवश्यकतानुसार उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ें**

ऑडियो फ्रेम में एक या अधिक कैप्शन ट्रैक्स संलग्न करने के लिए [getCaptionTracks](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#getCaptionTracks) मेथड का उपयोग करें। निम्न उदाहरण में, एक ऑडियो फ़ाइल को स्लाइड में जोड़ा जाता है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया जाता है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

आप ऑडियो फ्रेम से जुड़े कैप्शन ट्रैक्स पर इटरेट कर सकते हैं और उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और अद्वितीय पहचानकर्ता प्रदान करता है, जिसका उपयोग कैप्शन निर्यात करते समय किया जा सकता है।

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

ऑडियो फ्रेम से कैप्शन हटाने के लिए, [CaptionsCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/) द्वारा प्रदान किए गए मेथड जैसे [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। निम्न उदाहरण एक ऑडियो फ्रेम से सभी कैप्शन ट्रैक्स हटाता है।

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

Aspose.Slides for Python via Java आपको स्लाइडशो ट्रांज़िशन में उपयोग किए गए साउंड को निकालने की अनुमति देता है। उदाहरण के तौर पर, आप किसी विशिष्ट स्लाइड में उपयोग किए गए साउंड को निकाल सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का एक इंस्टेंस बनाएं और ऑडियो वाली प्रस्तुति लोड करें।
2. अपने सूचकांक से संबंधित स्लाइड का संदर्भ प्राप्त करें।
3. स्लाइड के लिए [slideshow transitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getSlideShowTransition) तक पहुंचें।
4. साउंड को बाइट डेटा के रूप में निकालें।

यह Python कोड आपको दिखाता है कि स्लाइड में उपयोग किए गए ऑडियो को कैसे निकालें:

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

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड्स में उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हैं। ऑडियो को प्रस्तुति के साझा [audio collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAudios) में एक बार जोड़ें और अतिरिक्त ऑडियो फ्रेम बनाएं जो उस मौजूदा एसेट को संदर्भित करते हैं। यह मीडिया डेटा को डुप्लिकेट होने से बचाता है और प्रस्तुति का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ्रेम में साउंड को फिर से बना बिना बदल सकता हूँ?**

हैं। लिंक्ड साउंड के लिए, नई फ़ाइल की ओर संकेत करने के लिए [link path](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setLinkPathLong) को अपडेट करें। एम्बेडेड साउंड के लिए, प्रस्तुति के [audio collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getAudios) से किसी अन्य [embedded audio](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audioframe/#setEmbeddedAudio) ऑब्जेक्ट से बदलें। फ्रेम का फॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स वही रहती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत मूल ऑडियो डेटा को बदलती है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अपरिवर्तित रहती हैं और एम्बेडेड ऑडियो या प्रस्तुति के audio collection के माध्यम से उपलब्ध रहती हैं।