---
title: Python का उपयोग करके प्रस्तुतियों में ऑडियो फ्रेम प्रबंधित करें
linktitle: ऑडियो फ्रेम
type: docs
weight: 10
url: /hi/python-net/audio-frame/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- थंबनेल
- ऑडियो जोड़ें
- ऑडियो गुण
- ऑडियो विकल्प
- ऑडियो निकालें
- WebVTT
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ स्लाइड में ऑडियो एम्बेड करें, ऑडियो आइकन बदलें, प्लेबैक कॉन्फ़िगर करें, WebVTT कैप्शन प्रबंधित करें, और स्लाइड ट्रांज़िशन ध्वनियों को निकालें।"
---
## **अवलोकन**

ऑडियो फ्रेम आपको स्लाइड पर ध्वनि चलाने की अनुमति देता है। Aspose.Slides for Python via .NET के साथ, आप एक ऑडियो क्लिप एम्बेड कर सकते हैं, इसे दर्शाने वाली छवि चुन सकते हैं, प्लेबैक समायोजित कर सकते हैं, और कैप्शन जोड़ सकते हैं। आप स्लाइड ट्रांज़िशन को सौंपे गए ध्वनि को भी प्राप्त कर सकते हैं।

## **ऑडियो फ्रेम बनाएं**

स्थानीय ऑडियो क्लिप को पहली स्लाइड पर एम्बेड करने के लिए [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) का उपयोग करें। पहले दो निर्देशांक फ्रेम को स्लाइड पर स्थित करते हैं, और अगले दो मान उसकी चौड़ाई और ऊँचाई निर्धारित करते हैं, सभी पॉइंट में। यह उदाहरण [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) को क्लिप को स्वचालित रूप से शुरू करने और [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) को उच्च प्रीसेट पर सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो फ्रेम थंबनेल बदलें**

डिफ़ॉल्ट रूप से, ऑडियो फ्रेम एक स्पीकर आइकन दर्शाता है। कस्टम थंबनेल दिखाने के लिए, प्रस्तुति में [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) से एक छवि जोड़ें और उसे फ्रेम की [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) प्रॉपर्टी के साथ असाइन करें। यह उदाहरण एम्बेडेड ऑडियो क्लिप के थंबनेल के रूप में एक JPEG का उपयोग करता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो प्ले विकल्प बदलें**

PowerPoint के **Audio Options** नियंत्रण यह निर्धारित करते हैं कि क्लिप कब शुरू होती है, इसकी आवाज़ कितनी तेज़ है, और स्लाइड शो के दौरान इसका व्यवहार कैसे होता है।

![ऑडियो फ़्रेम के लिए PowerPoint ऑडियो विकल्प नियंत्रण](audio_frame_0.png)

| PowerPoint नियंत्रण | Aspose.Slides गुण |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Volume preset | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Play Across Slides | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop until Stopped | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Hide During Show | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Rewind after Playing | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trim Audio start time | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trim Audio end time | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Volume slider | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम खोजता है, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) को क्लिक पर प्लेबैक शुरू करने के लिए सेट करता है, और कम आवाज़ प्रीसेट चुनता है। क्लिप स्लाइडों के बीच चलती रहती है जबकि लूप निष्क्रिय रहता है। आइकन शो के दौरान छुपा रहता है, और क्लिप प्लेबैक के बाद रीवाइंड हो जाता है।

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

3.5 सेकंड से अधिक लंबी क्लिप के लिए, यह उदाहरण पहले 1.5 सेकंड और अंतिम 2 सेकंड को छोड़ देता है। [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) क्लिप के अंत से हटाए जाने वाले अवधि को मापता है। PowerPoint में दिखाए गए अंत समय को प्राप्त करने के लिए, इस ऑफ़सेट को पूरी क्लिप अवधि से घटाएँ। ट्रिम की गई क्लिप 200 मिलीसेकंड में फेड इन होती है और 500 मिलीसेकंड में फेड आउट होती है। सभी चार प्रॉपर्टी मान मिलीसेकंड में होते हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

प्लेबैक आवाज़ को विशिष्ट प्रतिशत पर सेट करने के लिए, [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहला ऑडियो फ्रेम 85% पर सेट करता है।

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो कैप्शन प्रबंधन करें**

प्रत्येक ऑडियो फ्रेम में एक [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) संग्रह होता है। आप इसका उपयोग क्लिप पर WebVTT कैप्शन जोड़ने, मौजूदा ट्रैकों को निर्यात करने, या उन्हें हटाने के लिए कर सकते हैं।

### **ऑडियो कैप्शन जोड़ें**

उदाहरण पहली स्लाइड पर एक ऑडियो क्लिप एम्बेड करता है और [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) का उपयोग करके स्थानीय WebVTT ट्रैक संलग्न करता है। पहला तर्क ट्रैक लेबल प्रदान करता है, और दूसरा तर्क टाइम्ड कैप्शन वाली फ़ाइल को पहचानता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **ऑडियो कैप्शन निकालें**

यह उदाहरण पहली स्लाइड पर एक ऑडियो फ्रेम से जुड़े प्रत्येक कैप्शन ट्रैक को निर्यात करता है। यह ट्रैक के [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) को एक WebVTT फ़ाइल में लिखता है और उसका [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) को फ़ाइल नाम के रूप में उपयोग करता है ताकि प्रत्येक ट्रैक का आउटपुट अलग रहे।

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **ऑडियो कैप्शन हटाएं**

व्यक्तिगत ट्रैक को हटाने के लिए [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) या [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) का उपयोग करें। यह उदाहरण पहली स्लाइड पर पहले ऑडियो फ्रेम से सभी कैप्शन हटाने के लिए [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) का उपयोग करता है, जबकि क्लिप को बरकरार रखता है।

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **ऑडियो कैप्शन में लाइन खोजें**

पहली स्लाइड पर ऑडियो कैप्शन में किसी लाइन को खोजने के लिए, प्रत्येक ट्रैक के [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) को मेमोरी में पढ़ें। साधारण‑टेक्स्ट WebVTT क्यू में टाइमिंग लाइन में `-->` होता है, उसके बाद कैप्शन लाइनों आती हैं, और एक खाली लाइन क्यू को समाप्त करती है। यह उदाहरण ट्रैक लेबल और प्रत्येक ऐसी कैप्शन लाइन को प्रिंट करता है जिसमें “café” शब्द शामिल है।

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **ऑडियो निकालें**

एक स्लाइड ट्रांज़िशन का अपना ध्वनि हो सकता है। इसे प्राप्त करने के लिए, ट्रांज़िशन की [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) प्रॉपर्टी पढ़ें। उदाहरण ध्वनि के [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) तक पहुँचता है और उसके आकार को बाइट्स में प्रिंट करता है। यदि पहली स्लाइड में कोई ट्रांज़िशन ध्वनि नहीं है, तो यह एक संदेश प्रिंट करता है।

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**क्या मैं एक ही ऑडियो क्लिप को कई स्लाइडों में दोहराए बिना उपयोग कर सकता हूँ?**

हां। क्लिप को एक बार प्रस्तुति के [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) में जोड़ें और प्रत्येक स्लाइड के लिए समान ऑडियो ऑब्जेक्ट को [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) में पास करें।

**क्या मैं मौजूदा ऑडियो फ्रेम में ध्वनि को बदल सकता हूँ?**

हां। लिंक्ड ध्वनि के लिए, [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) को प्रतिस्थापन फ़ाइल की ओर इशारा करने के लिए अपडेट करें। एम्बेडेड ध्वनि के लिए, प्रस्तुति के ऑडियो संग्रह से किसी अन्य क्लिप को [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) में असाइन करें। दोनों विधियां मौजूदा फ्रेम को संरक्षित रखती हैं।

**क्या ट्रिमिंग प्रस्तुति में संग्रहीत ऑडियो डेटा को बदल देती है?**

नहीं। [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) और [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) प्लेबैक सीमा निर्धारित करते हैं। आप अभी भी [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) से पूरी क्लिप को प्राप्त कर सकते हैं।