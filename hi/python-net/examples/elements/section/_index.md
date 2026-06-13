---
title: सेक्शन
type: docs
weight: 90
url: /hi/python-net/examples/elements/section/
keywords:
- सेक्शन
- स्लाइड सेक्शन
- सेक्शन जोड़ें
- सेक्शन तक पहुँचें
- सेक्शन हटाएँ
- सेक्शन का नाम बदलें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में स्लाइड सेक्शन का प्रबंधन करें: आसानी से बनाएं, नाम बदलें, पुनः क्रमित करें, सेक्शन के बीच स्लाइड स्थानांतरित करें, और PPT, PPTX और ODP के लिए दृश्यता नियंत्रित करें।"
---
प्रेजेंटेशन सेक्शनज़ को प्रोग्रामेटिकली प्रबंधित करने के उदाहरण—जोड़ें, पहुँचें, हटाएँ, और उनका नाम बदलें, **Aspose.Slides for Python via .NET** का उपयोग करके।

## **सेक्शन जोड़ें**

एक विशिष्ट स्लाइड से शुरू होने वाला सेक्शन बनाएं।

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # एक नया सेक्शन जोड़ें और उस स्लाइड को निर्दिष्ट करें जो सेक्शन की शुरुआत को दर्शाती है।
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **सेक्शन तक पहुँचें**

प्रेजेंटेशन से एक सेक्शन प्राप्त करें।

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # इंडेक्स द्वारा एक सेक्शन तक पहुँचें।
        section = presentation.sections[0]
```

## **सेक्शन हटाएँ**

पहले जोड़े गए सेक्शन को हटाएँ।

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # सेक्शन हटाएँ।
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **सेक्शन का नाम बदलें**

मौजूदा सेक्शन का नाम बदलें।

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # सेक्शन का नाम बदलें।
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```