---
title: Python का उपयोग करके प्रेज़ेंटेशन में ऑडियो प्रबंधित करें
linktitle: ऑडियो फ़्रेम
type: docs
weight: 10
url: /hi/python-net/audio-frame/
keywords:
- ऑडियो जोड़ें
- ऑडियो एम्बेड करें
- ऑडियो फ़्रेम
- ऑडियो फ़ाइल
- ऑडियो प्रॉपर्टीज़
- ऑडियो निकालें
- ऑडियो प्राप्त करें
- ऑडियो बदलें
- प्ले विकल्प
- प्ले मोड
- स्लाइड्स में प्ले करें
- रोकने तक लूप
- शो के दौरान छुपाएँ
- चलाने के बाद रिवाइंड
- ऑडियो वॉल्यूम
- डिफ़ॉल्ट इमेज
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PPT, PPTX और ODP में ऑडियो फ़्रेम को आसानी से जोड़ें, निकालें और प्रबंधित करें। कोड उदाहरण देखें और आज ही अपनी प्रेज़ेंटेशन्स को उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides में ऑडियो फ़्रेम के साथ काम करने का तरीका समझाता है। यह दर्शाता है कि कैसे स्लाइड्स में एम्बेडेड ऑडियो जोड़ा जाए, ऑडियो फ़्रेम थंबनेल को अनुकूलित किया जाए, वॉल्यूम, लूपिंग, छुपाना, ट्रिमिंग और फ़ेड अवधि जैसी प्लेबैक विकल्पों को कॉन्फ़िगर किया जाए, तथा स्लाइड शो ट्रांज़िशन में उपयोग किए गए ऑडियो को निकाला जाए।

## **ऑडियो फ़्रेम बनाना**

Aspose.Slides for Python via .NET आपको स्लाइड्स में ऑडियो फ़ाइलें जोड़ने की अनुमति देता है। ऑडियो फ़ाइलें स्लाइड्स में ऑडियो फ़्रेम के रूप में एम्बेड की जाती हैं।

1.  [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2.  उसके इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3.  वह ऑडियो फ़ाइल स्ट्रीम लोड करें जिसे आप स्लाइड में एम्बेड करना चाहते हैं।
4.  एम्बेडेड ऑडियो फ़्रेम (जो ऑडियो फ़ाइल को शामिल करता है) को स्लाइड में जोड़ें।
5.  [IAudioFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/) ऑब्जेक्ट द्वारा उजागर [PlayMode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioplaymodepreset) और `Volume` सेट करें।
6.  संशोधित प्रेज़ेंटेशन को सहेजें।

यह Python कोड दिखाता है कि कैसे स्लाइड में एम्बेडेड ऑडियो फ़्रेम जोड़ा जाए:

```python
import aspose.slides as slides

# InstantiateS एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाएं
with slides.Presentation() as pres:
    # पहली स्लाइड प्राप्त करता है
    sld = pres.slides[0]

    # स्ट्रीम के लिए wav ध्वनि फ़ाइल लोड करता है
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # ऑडियो फ़्रेम जोड़ता है
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # ऑडियो का प्ले मोड और वॉल्यूम सेट करता है
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPoint फ़ाइल को डिस्क पर लिखता है
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो फ़्रेम थंबनेल बदलना**

जब आप प्रेज़ेंटेशन में ऑडियो फ़ाइल जोड़ते हैं, तो ऑडियो एक मानक डिफ़ॉल्ट इमेज के साथ फ़्रेम के रूप में दिखता है (नीचे के सेक्शन में चित्र देखें)। आप ऑडियो फ़्रेम का थंबनेल (अपनी पसंद की इमेज) बदल सकते हैं।

यह Python कोड दिखाता है कि कैसे ऑडियो फ़्रेम का थंबनेल या प्रीव्यू इमेज बदला जाए:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # स्लाइड में निर्दिष्ट स्थिति और आकार के साथ एक ऑडियो फ़्रेम जोड़ता है।
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # प्रेजेंटेशन संसाधनों में एक छवि जोड़ता है।
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # ऑडियो फ़्रेम के लिए छवि सेट करता है।
        audioFrame.picture_format.picture.image = audioImage
        
        #संशोधित प्रेजेंटेशन को डिस्क पर सहेजता है
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो प्ले विकल्प बदलना**

Aspose.Slides for Python via .NET आपको ऑडियो की प्लेबैक या प्रॉपर्टीज़ को नियंत्रित करने वाले विकल्प बदलने की अनुमति देता है। उदाहरण के लिए, आप ऑडियो की वॉल्यूम समायोजित कर सकते हैं, ऑडियो को लूप में चलाने के लिए सेट कर सकते हैं, या ऑडियो आइकन को छिपा सकते हैं।

Microsoft PowerPoint में **Audio Options** पेन:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options** जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:

- **Start** ड्रॉप-डाउन सूची [AudioFrame.play_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/play_mode/) प्रॉपर्टी से मेल खाती है
- **Volume** [AudioFrame.volume](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/volume/) प्रॉपर्टी से मेल खाती है
- **Play Across Slides** [AudioFrame.play_across_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/play_across_slides/) प्रॉपर्टी से मेल खाती है
- **Loop until Stopped** [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/play_loop_mode/) प्रॉपर्टी से मेल खाती है
- **Hide During Show** [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/hide_at_showing/) प्रॉपर्टी से मेल खाती है
- **Rewind after Playing** [AudioFrame.rewind_audio](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/rewind_audio/) प्रॉपर्टी से मेल खाती है

PowerPoint **Editing** विकल्प जो Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/) प्रॉपर्टीज़ से मेल खाते हैं:

- **Fade In** [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/fade_in_duration/) प्रॉपर्टी से मेल खाता है
- **Fade Out** [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/fade_out_duration/) प्रॉपर्टी से मेल खाता है
- **Trim Audio Start Time** [AudioFrame.trim_from_start](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/trim_from_start/) प्रॉपर्टी से मेल खाता है
- **Trim Audio End Time** का मान ऑडियो अवधि में से [AudioFrame.trim_from_end](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/trim_from_end/) प्रॉपर्टी के मान को घटाकर होता है

ऑडियो कंट्रोल पैनल में PowerPoint **Volume controll** [AudioFrame.volume_value](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/volume_value/) प्रॉपर्टी से मेल खाता है। यह आपको ऑडियो वॉल्यूम को प्रतिशत में बदलने की सुविधा देता है।

यहाँ बताया गया है कि आप Audio Play विकल्प कैसे बदलते हैं:

1.  [Create](#create-audio-frame) या Audio Frame प्राप्त करें।
2.  उन Audio Frame प्रॉपर्टीज़ के नए मान सेट करें जिन्हें आप समायोजित करना चाहते हैं।
3.  संशोधित PowerPoint फ़ाइल सहेजें।

यह Python कोड दर्शाता है कि कैसे ऑडियो के विकल्प समायोजित किए जाते हैं:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame आकार प्राप्त करता है
    audioFrame = pres.slides[0].shapes[0]

    # क्लिक पर चलाने के लिए प्ले मोड सेट करता है
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # ध्वनि मात्रा को कम सेट करता है
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # ऑडियो को सभी स्लाइड्स पर चलाने के लिए सेट करता है
    audioFrame.play_across_slides = True

    # ऑडियो के लूप को निष्क्रिय करता है
    audioFrame.play_loop_mode = False

    # स्लाइड शो के दौरान AudioFrame को छुपाता है
    audioFrame.hide_at_showing = True

    # चलाने के बाद ऑडियो को शुरू से रीवाइंड करता है
    audioFrame.rewind_audio = True

    # PowerPoint फ़ाइल को डिस्क पर सहेजता है
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

यह Python उदाहरण दिखाता है कि कैसे एम्बेडेड ऑडियो के साथ नया ऑडियो फ़्रेम जोड़ा जाए, उसे ट्रिम किया जाए, और फ़ेड अवधि सेट की जाए:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # ट्रिमिंग की शुरुआती ऑफ़सेट को 1.5 सेकंड पर सेट करता है
    # ट्रिमिंग के अंत की ऑफ़सेट को 2 सेकंड पर सेट करता है
    # फ़ेड-इन अवधि को 200 मिलीसेकंड पर सेट करता है
    # फ़ेड-आउट अवधि को 500 मिलीसेकंड पर सेट करता है

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

निम्न कोड नमूना दिखाता है कि कैसे एम्बेडेड ऑडियो वाले ऑडियो फ़्रेम को प्राप्त कर उसकी वॉल्यूम को 85 % पर सेट किया जाए:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # ऑडियो फ़्रेम आकार प्राप्त करता है
    audio_frame = pres.slides[0].shapes[0]

    # ऑडियो वॉल्यूम को 85% पर सेट करता है
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो कैप्शन प्रबंधित करना**

Aspose.Slides आपको [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/caption_tracks/) प्रॉपर्टी के माध्यम से ऑडियो फ़्रेम में बंद कैप्शन जोड़ने की सुविधा देता है। यह प्रॉपर्टी एक [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) लौटाती है, जिससे आप WebVTT कैप्शन ट्रैक्स जोड़ सकते हैं, मौजूदा ट्रैक्स के माध्यम से इटरिट कर सकते हैं, और आवश्यकतानुसार उन्हें हटा सकते हैं।

**ऑडियो कैप्शन जोड़ना**

ऑडियो फ़्रेम से एक या अधिक कैप्शन ट्रैक संलग्न करने के लिए [caption_tracks](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/caption_tracks/) प्रॉपर्टी का उपयोग करें। नीचे के उदाहरण में एक ऑडियो फ़ाइल स्लाइड में जोड़ी जाती है, और फिर एक नया कैप्शन ट्रैक `.vtt` फ़ाइल से लोड किया जाता है।

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # WebVTT फ़ाइल से नया कैप्शन ट्रैक जोड़ें।
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**ऑडियो कैप्शन निकालना**

आप ऑडियो फ़्रेम से जुड़े कैप्शन ट्रैक्स के माध्यम से इटरिट कर उन्हें `.vtt` फ़ाइलों के रूप में सहेज सकते हैं। प्रत्येक कैप्शन ट्रैक अपना बाइनरी डेटा और यूनिक पहचानकर्ता प्रदान करता है, जिसे निर्यात करते समय उपयोग किया जा सकता है।

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # कैप्शन ट्रैक को .vtt फ़ाइल के रूप में सहेजें।
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**ऑडियो कैप्शन हटाना**

ऑडियो फ़्रेम से कैप्शन हटाने के लिए आप [CaptionsCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/) द्वारा प्रदान किए गए मेथड्स, जैसे [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove/), या [remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides/captionscollection/remove_at/) का उपयोग कर सकते हैं। नीचे का उदाहरण ऑडियो फ़्रेम से सभी कैप्शन ट्रैक्स हटाता है।

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # type: slides.AudioFrame

    # ऑडियो फ़्रेम से सभी कैप्शन ट्रैक्स हटाएं।
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो निकालना**
Aspose.Slides for Python via .NET आपको स्लाइड शो ट्रांज़िशन में उपयोग किए गए ध्वनि को निकालने की सुविधा देता है। उदाहरण के लिए, आप किसी विशिष्ट स्लाइड में उपयोग की गई ध्वनि निकाल सकते हैं।

1.  [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं और वह प्रेज़ेंटेशन लोड करें जिसमें ऑडियो मौजूद है।
2.  उसके इंडेक्स द्वारा संबंधित स्लाइड का रेफ़रेंस प्राप्त करें।
3.  स्लाइड के लिए स्लाइडशो ट्रांज़िशन तक पहुँचें।
4.  ध्वनि को बाइट डेटा के रूप में निकालें।

यह Python कोड दिखाता है कि कैसे स्लाइड में उपयोग किए गए ऑडियो को निकाला जाए:

```python
import aspose.slides as slides

#AudioSlide.pptx प्रेज़ेंटेशन खोलने के लिए (टिप्पणीित)
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # इच्छित स्लाइड तक पहुंचता है
    slide = pres.slides[0]  

    # स्लाइड के स्लाइडशो ट्रांज़िशन प्रभाव प्राप्त करता है
    transition = slide.slide_show_transition

    #ध्वनि को बाइट एरे में निकालता है
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**क्या मैं एक ही ऑडियो एसेट को कई स्लाइड्स में पुन: उपयोग कर सकता हूँ बिना फ़ाइल आकार बढ़ाए?**

हाँ। ऑडियो को केवल एक बार प्रेज़ेंटेशन के साझा [audio collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/audios/) में जोड़ें और अतिरिक्त ऑडियो फ़्रेम बनाएं जो उस मौजूदा एसेट को संदर्भित करते हों। इससे मीडिया डेटा की डुप्लिकेशन नहीं होती और प्रेज़ेंटेशन का आकार नियंत्रित रहता है।

**क्या मैं मौजूदा ऑडियो फ़्रेम में ध्वनि को बदल सकता हूँ बिना आकार पुन: बनाये?**

हाँ। लिंक्ड ध्वनि के लिए, नए फ़ाइल की ओर संकेत करने हेतु [link path](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audioframe/link_path_long/) अपडेट करें। एम्बेडेड ध्वनि के लिए, प्रेज़ेंटेशन की [audio collection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/audios/) से किसी अन्य एम्बेडेड ऑडियो ऑब्जेक्ट को बदल दें। फ़्रेम की फ़ॉर्मेटिंग और अधिकांश प्लेबैक सेटिंग्स अपरिवर्तित रहती हैं।

**क्या ट्रिमिंग से प्रेज़ेंटेशन में संग्रहीत मूल ऑडियो डेटा बदलता है?**

नहीं। ट्रिमिंग केवल प्लेबैक सीमाओं को समायोजित करती है। मूल ऑडियो बाइट्स अविचलित रहते हैं और एम्बेडेड ऑडियो या प्रेज़ेंटेशन की ऑडियो कलेक्शन के माध्यम से उपलब्ध होते हैं।