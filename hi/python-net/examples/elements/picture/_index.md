---
title: चित्र
type: docs
weight: 50
url: /hi/python-net/examples/elements/picture/
keywords:
- चित्र
- चित्र फ्रेम
- चित्र जोड़ें
- चित्र तक पहुँचें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Python में Aspose.Slides का उपयोग करके चित्रों के साथ काम करें: सम्मिलित करें, बदलें, क्रॉप करें, संपीड़ित करें, पारदर्शिता और प्रभाव समायोजित करें, आकार भरें, और PPT, PPTX और ODP के लिए निर्यात करें।"
---
इन‑मेमोरी images से चित्रों को सम्मिलित करने और पहुँचने का तरीका दिखाता है **Aspose.Slides for Python via .NET** का उपयोग करके। नीचे दिए गए उदाहरण मेमोरी में एक छवि बनाते हैं, उसे एक स्लाइड पर रखते हैं, और फिर उसे पुनः प्राप्त करते हैं।

## **चित्र जोड़ें**

यह कोड फ़ाइल से एक छवि लोड करता है और उसे पहली स्लाइड पर चित्र फ्रेम के रूप में सम्मिलित करता है।

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # फ़ाइल से एक छवि लोड करें।
        with open("image.png", "rb") as image_stream:
            # छवि को प्रस्तुति संसाधनों में जोड़ें।
            image = presentation.images.add_image(image_stream)

        # पहली स्लाइड पर छवि दिखाने के लिए एक चित्र फ्रेम सम्मिलित करें।
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम है और फिर वह पहले मिलने वाले चित्र फ्रेम तक पहुँचता है।

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # स्लाइड पर पहला चित्र फ्रेम प्राप्त करें।
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```