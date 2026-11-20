---
title: Python का उपयोग करके प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
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
description: "Aspose.Slides for Python via Java के साथ स्लाइड्स में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **अवलोकन**

एक ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for Python via Java के साथ, आप एक ऑडियो क्लिप एम्बेड कर सकते हैं, इसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन जोड़ सकते हैं। आप स्लाइड ट्रांज़िशन को सौंपे गए ध्वनि को भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

`audio.wav` से बाइट्स को प्रस्तुति के ऑडियो संग्रह में जोड़ें, फिर पहले स्लाइड पर स्थानीय ऑडियो क्लिप एम्बेड करने के लिए [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) का उपयोग करें। पहले दो निर्देशांक फ्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान उसकी चौड़ाई और ऊँचाई सेट करते हैं, सभी पॉइंट्स में। यह उदाहरण [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) को कॉल करता है ताकि क्लिप स्वचालित रूप से शुरू हो और [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) को कॉल करता है ताकि तेज़ प्रीसेट चुना जा सके।

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

डिफ़ॉल्ट रूप से, एक ऑडियो फ्रेम एक स्पीकर आइकन दिखाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) का उपयोग करके एक छवि जोड़ें और फ्रेम की तस्वीर पर [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) के साथ सेट करें। उदाहरण में एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में JPEG का उपयोग किया गया है।

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

    audio_data = Path("audio.wav").read_bytes()
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

PowerPoint के **Audio Options** नियंत्रण निर्धारित करते हैं कि क्लिप कब शुरू होती है, इसकी आवाज़ कितनी तेज़ है, और स्लाइड शो के दौरान यह कैसे व्यवहार करती है।

![ऑडियो फ्रेम के लिए PowerPoint ऑडियो विकल्प नियंत्रण](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides for Python via Java विधि |
| --- | --- |
| शुरू | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| वॉल्यूम प्रीसेट | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| स्लाइड्स के बीच प्ले | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| रुकने तक लूप | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| शो के दौरान छुपाएं | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| प्लेयिंग के बाद रीवाइंड | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| फ़ेड इन | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| फ़ेड आउट | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| ऑडियो प्रारम्भ समय काटें | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| ऑडियो अंत समय काटें | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| वॉल्यूम स्लाइडर | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

उदाहरण पहले स्लाइड पर पहला ऑडियो फ्रेम ढूँढता है, क्लिक पर प्लेबैक शुरू करने के लिए [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) को कॉल करता है, और लो वॉल्यूम प्रीसेट चुनता है। क्लिप स्लाइड्स के बीच चलता रहता है जबकि लूपिंग निष्क्रिय है। आइकन शो के दौरान छुपा रहता है, और प्लेबैक के बाद क्लिप रीवाइंड हो जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # क्लिक पर प्ले करें, कम वॉल्यूम पर, स्लाइड्स के बीच, बिना लूपिंग के।
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # स्लाइड शो के दौरान फ्रेम को छुपाएँ और प्ले होने के बाद रीवाइंड करें।
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

3.5 सेकंड से अधिक लंबी क्लिप के लिए, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) क्लिप के अंत से हटाने की अवधि लेता है। PowerPoint में दिखाया गया अंत समय प्राप्त करने के लिए, उस ऑफ़सेट को पूर्ण क्लिप अवधि से घटाएँ। ट्रिम की गई क्लिप 200 मिलीसेकंड में फ़ेड इन होती है और 500 मिलीसेकंड में फ़ेड आउट। सभी चार विधियों के मान मिलीसेकंड में दिए जाते हैं।

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # शुरू से 1.5 सेकंड और अंत से 2 सेकंड ट्रिम करें।
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # फ़ेड‑इन को 200 ms और फ़ेड‑आउट को 500 ms सेट करें।
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

प्लेबैक वॉल्यूम को निश्चित प्रतिशत पर सेट करने के लिए, [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) का उपयोग करें। यह उदाहरण पहले स्लाइड पर पहला ऑडियो फ्रेम 85 % पर सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **ऑडियो कैप्शन प्रबंधित करें**

प्रत्येक ऑडियो फ्रेम [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) द्वारा उसके कैप्शन ट्रैक तक पहुँच प्रदान करता है। संग्रह का उपयोग करके क्लिप में WebVTT कैप्शन संलग्न कर सकते हैं, मौजूदा ट्रैक निर्यात कर सकते हैं, या उन्हें हटा सकते हैं।

### **ऑडियो कैप्शन जोड़ें**

उदाहरण पहले स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और स्थानीय WebVTT ट्रैक संलग्न करने के लिए [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) का उपयोग करता है। पहला तर्क ट्रैक लेबल देता है, और दूसरा फ़ाइल पहचानता है जिसमें समयबद्ध कैप्शन होते हैं।

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

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # WebVTT फ़ाइल से नया कैप्शन ट्रैक जोड़ें।
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहले स्लाइड पर ऑडियो फ्रेम से संलग्न प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) द्वारा लौटाए गए बाइट्स को एक WebVTT फ़ाइल में लिखता है और [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) द्वारा लौटाए गए पहचानकर्ता को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का अलग आउटपुट हो।

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
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

### **ऑडियो कैप्शन हटाएं**

व्यक्तिगत ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) या [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) का उपयोग करें। उदाहरण सभी कैप्शन को हटाने के लिए पहले स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन को हटाने हेतु [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) का उपयोग करता है, जबकि क्लिप संरक्षित रहती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **ऑडियो कैप्शन में पंक्ति खोजें**

पहले स्लाइड पर ऑडियो कैप्शन में पंक्ति खोजने के लिए, मेमोरी में [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) द्वारा लौटाए गए टेक्स्ट को खोजें। साधारण टेक्स्ट WebVTT क्यू में, टाइमिंग पंक्ति में `-->` होता है, उसके बाद कैप्शन पंक्तियाँ आती हैं, और एक खाली पंक्ति क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और “café” शब्द वाली प्रत्येक कैप्शन पंक्ति को प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **ऑडियो निकालें**

एक स्लाइड ट्रांज़िशन की अपनी ध्वनि हो सकती है। इसे प्राप्त करने के लिए स्लाइड ट्रांज़िशन पर [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) को कॉल करें। उदाहरण [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) द्वारा लौटाए गए बाइट्स तक पहुँचता है और बाइट्स की संख्या प्रिंट करता है। यदि प्रथम स्लाइड में कोई ट्रांज़िशन ध्वनि नहीं है, तो यह संदेश प्रिंट करता है।

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
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइड में डुप्लिकेट किए बिना पुन: उपयोग कर सकता हूँ?**

हाँ। क्लिप को एक बार प्रस्तुति के [ऑडियो संग्रह](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) में जोड़ें और प्रत्येक स्लाइड के लिए वही ऑडियो ऑब्जेक्ट [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) को पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बदल सकता हूँ?**

हाँ। लिंक्ड ध्वनि के लिए, प्रतिस्थापन फ़ाइल की ओर इंगित करने हेतु [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) का उपयोग करें। एम्बेडेड ध्वनि के लिए, प्रस्तुति के ऑडियो संग्रह से किसी अन्य क्लिप को चुनने हेतु [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) का उपयोग करें। दोनों तरीके मौजूदा फ्रेम को संरक्षित रखते हैं।

**क्या ट्रिमिंग से प्रस्तुति में संग्रहित ऑडियो डेटा बदलता है?**

नहीं। [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) और [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) प्लेबैक सीमाएँ निर्धारित करते हैं। आप अभी भी [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) से पूर्ण क्लिप प्राप्त कर सकते हैं।