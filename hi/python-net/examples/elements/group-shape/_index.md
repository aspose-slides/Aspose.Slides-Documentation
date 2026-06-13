---
title: समूह आकार
type: docs
weight: 170
url: /hi/python-net/examples/elements/group-shape/
keywords:
- समूह
- समूह आकार जोड़ें
- समूह आकार तक पहुँचें
- समूह आकार हटाएँ
- समूहभेदन
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में समूह आकारों के साथ काम करें: बनाएं और समूहभेद करें, चाइल्ड आकारों को पुन:क्रमित करें, PowerPoint और OpenDocument में ट्रांसफ़ॉर्म और सीमाएँ सेट करें।"
---
आकारों के समूह बनाना, उन तक पहुँच प्राप्त करना, समूहभेदन और हटाने के उदाहरण **Aspose.Slides for Python via .NET** का उपयोग करके।

## **समूह आकार जोड़ें**

दो बुनियादी आकारों वाला एक समूह बनाएं।

```py
def add_group_shape():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # समूह आकार जोड़ें।
        group = slide.shapes.add_group_shape()
        group.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        group.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 60, 0, 50, 50)

        presentation.save("group.pptx", slides.export.SaveFormat.PPTX)
```

## **समूह आकार तक पहुँचें**

एक स्लाइड से पहला समूह आकार प्राप्त करें।

```py
def access_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहला समूह आकार तक पहुँचें।
        first_group = None
        for shape in slide.shapes:
            if isinstance(shape, slides.GroupShape):
                first_group = shape
                break
```

## **समूह आकार हटाएँ**

स्लाइड से एक समूह आकार हटाएं।

```py
def remove_group_shape():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार एक समूह आकार है।
        group = slide.shapes[0]

        # समूह आकार को हटाएँ।
        slide.shapes.remove(group)

        presentation.save("group_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **समूहभेदन**

समूह कंटेनर से आकारों को बाहर निकालें।

```py
def ungroup_shapes():
    with slides.Presentation("group.pptx") as presentation:
        slide = presentation.slides[0]

        # मान लेते हैं कि पहला आकार एक समूह आकार है।
        group = slide.shapes[0]

        # समूह से आकारों को बाहर निकालें।
        for shape in group.shapes:
            slide.shapes.add_clone(shape)

        slide.shapes.remove(group)

        presentation.save("shapes_ungrouped.pptx", slides.export.SaveFormat.PPTX)
```