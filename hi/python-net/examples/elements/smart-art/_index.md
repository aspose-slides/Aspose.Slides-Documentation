---
title: "स्मार्टआर्ट"
type: docs
weight: 140
url: /hi/python-net/examples/elements/smart-art/
keywords:
- "स्मार्टआर्ट"
- "स्मार्टआर्ट जोड़ें"
- "स्मार्टआर्ट एक्सेस करें"
- "स्मार्टआर्ट हटाएँ"
- "स्मार्टआर्ट लेआउट"
- "कोड उदाहरण"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides के साथ Python में SmartArt बनाएं और संपादित करें: नोड जोड़ें, लेआउट और शैली बदलें, सटीकता के साथ शेप्स में बदलें, और PPT, PPTX और ODP के लिए निर्यात करें।"
---
यह दिखाता है कि **Aspose.Slides for Python via .NET** का उपयोग करके SmartArt ग्राफ़िक्स को कैसे जोड़ें, उनका एक्सेस करें, उन्हें हटाएँ, और लेआउट बदलें।

## **Add SmartArt**

इनबिल्ट लेआउट्स में से एक का उपयोग करके SmartArt ग्राफ़िक डालें।

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Access SmartArt**

स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें।

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # पहले SmartArt आकार तक पहुंचें।
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Remove SmartArt**

स्लाइड से SmartArt आकार हटाएँ।

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार एक SmartArt ऑब्जेक्ट है।
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Change SmartArt Layout**

मौजूदा SmartArt ग्राफ़िक के लेआउट प्रकार को अपडेट करें।

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार एक SmartArt ऑब्जेक्ट है।
        smart_art = slide.shapes[0]

        # SmartArt लेआउट बदलें।
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```