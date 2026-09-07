---
title: चित्र
type: docs
weight: 50
url: /hi/python-java/examples/elements/picture/
keywords:
- कोड उदाहरण
- चित्र
- चित्र जोड़ें
- चित्र तक पहुँचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके मेमोरी में बनाए गए चित्रों को सम्मिलित और पहुँचाएँ, PowerPoint और OpenDocument प्रस्तुतियों के उदाहरणों के साथ।"
---
यह लेख दर्शाता है कि **Aspose.Slides for Python via Java** का उपयोग करके इन‑मेमोरी इमेजेज़ से चित्र कैसे सम्मिलित और पहुँचाया जाए। नीचे दिए गए उदाहरण एक इमेज मेमोरी में बनाते हैं, इसे स्लाइड पर रखते हैं, और फिर चित्र फ्रेम को पुनः प्राप्त करते हैं।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, और JVM चलने के बाद API को इम्पोर्ट करता है।

## **चित्र जोड़ें**

यह कोड एक छोटा बिटमैप बनाता है, इसे स्ट्रीम में परिवर्तित करता है, और पहले स्लाइड पर इसे चित्र फ्रेम के रूप में सम्मिलित करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # एक सरल इन-मेमोरी इमेज बनाएं।
    bitmap = BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB)
    graphics = bitmap.createGraphics()
    try:
        color = Color(144, 238, 144)
        graphics.setPaint(color)
        graphics.fillRect(0, 0, 100, 100)
    finally:
        graphics.dispose()

    # बिटमैप को बाइट एरे में परिवर्तित करें।
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    # इमेज को प्रस्तुतिकरण में जोड़ें।
    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)

    # पहले स्लाइड पर इमेज दिखाने वाला पिक्चर फ्रेम सम्मिलित करें।
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, bitmap.getWidth(), bitmap.getHeight(), image)

    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **चित्र तक पहुँचें**

यह उदाहरण सुनिश्चित करता है कि स्लाइड में एक चित्र फ्रेम हो और फिर उसे खोजते हुए पहला मिलने वाला फ्रेम एक्सेस करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt.image import BufferedImage
from java.io import ByteArrayInputStream, ByteArrayOutputStream
from javax.imageio import ImageIO
from asposeslides.api import PictureFrame, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    bitmap = BufferedImage(40, 40, BufferedImage.TYPE_INT_ARGB)
    bitmap_stream = ByteArrayOutputStream()
    ImageIO.write(bitmap, "png", bitmap_stream)
    png_bytes = bitmap_stream.toByteArray()

    image_stream = ByteArrayInputStream(png_bytes)
    image = presentation.getImages().addImage(image_stream)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 40, 40, image)

    picture_frame = None
    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is None:
        print("The slide contains no picture frames.")
finally:
    presentation.dispose()
```