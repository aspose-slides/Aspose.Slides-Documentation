---
title: ऑडियो
type: docs
weight: 70
url: /hi/python-net/examples/elements/audio/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- ऑडियो जोड़ें
- ऑडियो तक पहुँचें
- ऑडियो हटाएँ
- ऑडियो प्लेबैक
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके ऑडियो के साथ काम करें: ध्वनियों को जोड़ें, बदलें, निकालें और ट्रिम करें, PowerPoint और OpenDocument में स्लाइड और आकार के लिए वॉल्यूम और प्लेबैक सेट करें।"
---
यह दर्शाता है कि **Aspose.Slides for Python via .NET** के साथ ऑडियो फ्रेम कैसे एम्बेड करें और प्लेबैक को नियंत्रित करें। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दिखाते हैं।

## **ऑडियो फ्रेम जोड़ें**

नीचे दिया गया कोड उदाहरण प्रस्तुति स्लाइड पर एक ऑडियो फ्रेम जोड़ता है।

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो फ्रेम तक पहुँचें**

यह कोड स्लाइड से पहला ऑडियो फ्रेम प्राप्त करता है।

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **ऑडियो फ्रेम हटाएँ**

पहले जोड़े गए ऑडियो फ्रेम को हटाएँ।

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार AudioFrame है।
        audio_frame = slide.shapes[0]

        # ऑडियो फ्रेम को हटाएं।
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड दिखाई देने पर ऑडियो फ्रेम को स्वचालित रूप से चलने के लिए कॉन्फ़िगर करें।

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार AudioFrame है।
        audio_frame = slide.shapes[0]

        # स्लाइड दिखाई देने पर स्वचालित रूप से चलाएं।
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```