---
title: चार्ट
type: docs
weight: 60
url: /hi/python-net/examples/elements/chart/
keywords:
- चार्ट
- चार्ट जोड़ें
- चार्ट तक पहुँचें
- चार्ट हटाएँ
- चार्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ चार्ट बनाएं और अनुकूलित करें: डेटा जोड़ें, सीरीज़, अक्ष और लेबल फ़ॉर्मेट करें, प्रकार बदलें, और निर्यात करें—यह PPT, PPTX और ODP के साथ काम करता है।"
---
**Aspose.Slides for Python via .NET** के साथ विभिन्न चार्ट प्रकारों को जोड़ने, पहुँचने, हटाने और अपडेट करने के उदाहरण। नीचे दिए गए स्निपेट्स बुनियादी चार्ट ऑपरेशन को प्रदर्शित करते हैं।

## **चार्ट जोड़ें**

यह मेथड पहले स्लाइड में एक साधारण एरिया चार्ट जोड़ता है।

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # पहली स्लाइड में एक साधारण कॉलम चार्ट जोड़ें।
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट तक पहुँचें**

निम्नलिखित कोड शेप कलेक्शन से एक चार्ट प्राप्त करता है।

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहला चार्ट पहुँचें।
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **चार्ट हटाएँ**

निम्नलिखित कोड एक स्लाइड से चार्ट को हटाता है।

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लें कि पहला आकार एक चार्ट है।
        chart = slide.shapes[0]

        # चार्ट हटाएँ।
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **चार्ट डेटा अपडेट करें**

आप चार्ट प्रॉपर्टीज़ जैसे शीर्षक को बदल सकते हैं।

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लें कि पहला आकार एक चार्ट है।
        chart = slide.shapes[0]

        # चार्ट शीर्षक बदलें।
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```