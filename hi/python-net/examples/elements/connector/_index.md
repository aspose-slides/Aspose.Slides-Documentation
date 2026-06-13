---
title: कनेक्टर
type: docs
weight: 190
url: /hi/python-net/examples/elements/connector/
keywords:
- कनेक्टर
- कनेक्टर जोड़ें
- कनेक्टर तक पहुँचें
- कनेक्टर हटाएँ
- आकृतियों को पुन: कनेक्ट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ कनेक्टर बनाएं और नियंत्रित करें: जोड़ें, मार्ग निर्धारित करें, पुनः मार्ग निर्धारित करें, कनेक्शन बिंदु, तीर और शैलियों को सेट करके PPT, PPTX और ODP में आकृतियों को लिंक करें।"
---
यह दर्शाता है कि कैसे आकृतियों को कनेक्टरों के साथ जोड़ें और उनके लक्ष्यों को बदलें **Aspose.Slides for Python via .NET** का उपयोग करके।

## **एक कनेक्टर जोड़ें**

स्लाइड पर दो बिंदुओं के बीच एक कनेक्टर आकार सम्मिलित करें।

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # एक बेंटा कनेक्टर आकार जोड़ें।
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **एक कनेक्टर तक पहुँचें**

स्लाइड में जोड़ा गया पहला कनेक्टर आकार पुनः प्राप्त करें।

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहले कनेक्टर तक पहुँचें।
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **एक कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर हटाएँ।

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार एक कनेक्टर है।
        connector = slide.shapes[0]

        # कनेक्टर को हटाएँ।
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **आकृतियों को पुन: कनेक्ट करें**

शुरू और अंत लक्ष्यों को असाइन करके दो आकृतियों से एक कनेक्टर संलग्न करें।

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # पहला आयत आकार जोड़ें।
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # दूसरा आयत आकार जोड़ें।
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # बेंटा कनेक्टर आकार जोड़ें।
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # कनेक्टर की शुरुआत को पहले आकार से जोड़ें।
        connector.start_shape_connected_to = shape1
        # कनेक्टर के अंत को दूसरे आकार से जोड़ें।
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```