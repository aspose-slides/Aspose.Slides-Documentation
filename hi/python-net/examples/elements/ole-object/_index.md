---
title: ओलेऑब्जेक्ट
type: docs
weight: 210
url: /hi/python-net/examples/elements/ole-object/
keywords:
- OLE ऑब्जेक्ट
- OLE ऑब्जेक्ट जोड़ें
- OLE ऑब्जेक्ट तक पहुँचें
- OLE ऑब्जेक्ट हटाएँ
- OLE ऑब्जेक्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके OLE ऑब्जेक्ट्स के साथ काम करें: एंबेडेड फ़ाइलें डालें या अपडेट करें, आइकन या लिंक सेट करें, सामग्री निकालें, PPT, PPTX और ODP के लिए व्यवहार नियंत्रित करें।"
---
एक फ़ाइल को OLE ऑब्जेक्ट के रूप में एम्बेड करने और उसके डेटा को अपडेट करने को **Aspose.Slides for Python via .NET** का उपयोग करके दर्शाता है।

## **OLE ऑब्जेक्ट जोड़ें**

प्रेज़ेंटेशन में एक PDF फ़ाइल एम्बेड करें।

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # PDF डेटा एम्बेड करने के लिए लोड करें।
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # स्लाइड में OLE ऑब्जेक्ट फ़्रेम जोड़ें।
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट तक पहुँचें**

एक स्लाइड पर पहला OLE ऑब्जेक्ट फ्रेम प्राप्त करें।

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहला OLE ऑब्जेक्ट फ़्रेम प्राप्त करें।
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **OLE ऑब्जेक्ट हटाएँ**

स्लाइड से एम्बेडेड OLE ऑब्जेक्ट को हटाएँ।

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला शेप एक OleObjectFrame ऑब्जेक्ट है।
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **OLE ऑब्जेक्ट डेटा अपडेट करें**

एक मौजूदा OLE ऑब्जेक्ट में एम्बेडेड डेटा को बदलें।

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला शेप एक OleObjectFrame ऑब्जेक्ट है।
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # नई एम्बेडेड डेटा के साथ OLE ऑब्जेक्ट अपडेट करें।
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```