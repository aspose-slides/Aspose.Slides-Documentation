---
title: वीडियो
type: docs
weight: 80
url: /hi/python-net/examples/elements/video/
keywords:
- वीडियो
- वीडियो फ्रेम
- वीडियो जोड़ें
- वीडियो तक पहुँचें
- वीडियो हटाएँ
- वीडियो प्लेबैक
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में वीडियो के साथ काम करें: सम्मिलित करें, बदलें, ट्रिम करें, पोस्टर फ्रेम और प्लेबैक विकल्प सेट करें, और PPT, PPTX और ODP के लिए प्रस्तुतियों को एक्सपोर्ट करें।"
---
विवरण देता है कि कैसे वीडियो फ्रेम को एम्बेड करें और प्लेबैक विकल्प सेट करें **Aspose.Slides for Python via .NET** का उपयोग करके।

## **वीडियो फ्रेम जोड़ें**

स्लाइड पर एक खाली वीडियो फ्रेम डालें।

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # एक वीडियो फ्रेम जोड़ें.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **वीडियो फ्रेम तक पहुँचें**

स्लाइट में जोड़े गए पहले वीडियो फ्रेम को प्राप्त करें।

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहला वीडियो फ्रेम तक पहुँचें.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **वीडियो फ्रेम हटाएँ**

स्लाइड से एक वीडियो फ्रेम हटाएँ।

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला शेप एक वीडियो फ्रेम है.
        video_frame = slide.shapes[0]

        # वीडियो फ्रेम हटाएँ.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **वीडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला शेप एक वीडियो फ्रेम है.
        video_frame = slide.shapes[0]

        # वीडियो को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```