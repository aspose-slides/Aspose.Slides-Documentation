---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/python-net/examples/elements/hyperlink/
keywords:
- हाइपरलिंक
- हाइपरलिंक जोड़ें
- हाइपरलिंक तक पहुँचें
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में हाइपरलिंक जोड़ें, संपादित करें और हटाएँ: लिंक टेक्स्ट, आकार, स्लाइड, URL और ईमेल; PPT, PPTX और ODP के लिए लक्ष्यों और क्रियाओं को सेट करें।"
---
शेप्स पर हाइपरलिंक जोड़ना, पहुँचना, हटाना और अपडेट करना **Aspose.Slides for Python via .NET** का उपयोग करके दर्शाता है।

## **हाइपरलिंक जोड़ें**
एक आयताकार आकार बनाएं जिसमें एक हाइपरलिंक बाहरी वेबसाइट की ओर इशारा करता हो।

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक तक पहुँचें**
एक आकार के पाठ भाग से हाइपरलिंक जानकारी पढ़ें।

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **हाइपरलिंक हटाएँ**
एक आकार के पाठ से हाइपरलिंक साफ़ करें।

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **हाइपरलिंक अपडेट करें**
मौजूदा हाइपरलिंक का लक्ष्य बदलें। `HyperlinkManager` का उपयोग करके वह पाठ संशोधित करें जिसमें पहले से हाइपरलिंक मौजूद है, जो यह दर्शाता है कि PowerPoint हाइपरलिंक को सुरक्षित रूप से कैसे अपडेट करता है।

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # मौजूदा टेक्स्ट में हाइपरलिंक को बदलना के माध्यम से किया जाना चाहिए
        # HyperlinkManager का उपयोग करना चाहिए, न कि प्रॉपर्टी को सीधे सेट करना।
        # यह दर्शाता है कि PowerPoint हाइपरलिंक को सुरक्षित रूप से कैसे अपडेट करता है।
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```