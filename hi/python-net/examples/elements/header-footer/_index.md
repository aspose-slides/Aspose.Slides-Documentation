---
title: हेडरफ़ुटर
type: docs
weight: 220
url: /hi/python-net/examples/elements/header-footer/
keywords:
- हेडर फूटर
- हेडर फूटर जोड़ें
- हेडर फूटर अपडेट करें
- तारीख और समय सेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में हेडर और फूटर को नियंत्रित करें: तिथि/समय, स्लाइड नंबर और फूटर टेक्स्ट जोड़ें या संपादित करें, PPT, PPTX और ODP में प्लेसहोल्डर दिखाएँ या छिपाएँ।"
---
यह दर्शाता है कि **Aspose.Slides for Python via .NET** का उपयोग करके फ़ुटर कैसे जोड़ें और तिथि एवं समय प्लेसहोल्डर को अपडेट करें।

## **फ़ुटर जोड़ें**

स्लाइड के फ़ुटर क्षेत्र में टेक्स्ट जोड़ें और उसे दिखाई देने योग्य बनाएं।

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **तिथि और समय अपडेट करें**

स्लाइड पर तिथि और समय प्लेसहोल्डर को संशोधित करें।

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```