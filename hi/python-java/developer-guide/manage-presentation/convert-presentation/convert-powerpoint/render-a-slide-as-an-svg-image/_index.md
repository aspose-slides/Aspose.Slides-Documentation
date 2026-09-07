---
title: Python के माध्यम से Java द्वारा प्रेजेंटेशन स्लाइड्स को SVG इमेज में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेजेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरएक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java द्वारा PowerPoint स्लाइड्स को SVG इमेज में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, ID और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर, अभिगम्य प्रवाह, और स्वचालित पोस्ट-प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको यह नियंत्रित करने देता है कि टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्व कैसे लिखे जाएँ।

Use [SVGOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **एक स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/), select a slide, and write it to a stream with [Slide.writeAsSvg](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/). The examples require an existing `presentation.pptx` file. Each example starts the JVM if needed and closes its output streams. The following example exports every slide in a presentation as a separate SVG file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

The filename uses [Slide.getSlideNumber](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getSlideNumber) rather than the loop index. You can also export an individual shape with [Shape.writeAsSvg](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) when a slide viewer or web page needs only that shape.

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम्स के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ्रेम रोटेशन लागू किया जाए या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर करना हो तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `True` सेट करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setVectorizeText) को `True` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम विभिन्न ब्राउज़रों में अधिक सुसंगत बन जाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **बाहरी फ़ॉन्ट्स को कैसे संभालें चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles` चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए `Embed` चुनें, या केवल उन टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें जो बाहरी फ़ॉन्ट्स का उपयोग करते हैं। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की पुष्टि करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **एंबेडेड इमेज का आकार घटाएँ**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setPicturesCompression) का उपयोग करके एंबेडेड चित्रों का रिज़ॉल्यूशन घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) का उपयोग करके क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setJpegQuality) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज फ़िडेलिटी या रखे गए इमेज डेटा की कीमत पर।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **आकृतियों और टेक्स्ट को स्थिर ID असाइन करें**

`jpype.JProxy` के माध्यम से पंजीकृत एक Python फ़ॉर्मेटिंग कंट्रोलर का उपयोग करके आकृतियों को [SvgShape.setId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgshape/#setId) मान और टेक्स्ट के `tspan` तत्वों को [SvgTSpan.setId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgtspan/#setId) मान असाइन करें। प्रॉक्सी को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setShapeFormattingController) के साथ असाइन करें।

निम्नलिखित कंट्रोलर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग करता है, जो आकार के जीवनकाल के दौरान स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावृत्त काउंटर। इससे उत्पन्न ID बिना बदलाव के प्रस्तुति की पोस्ट-प्रोसेसिंग के लिए उपयुक्त बनते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **SVG इवेंट हैंडलर जोड़ें**

Python फ़ॉर्मेटिंग कंट्रोलर में, एक्सपोर्टेड आकार में जावास्क्रिप्ट इवेंट हैंडलर जोड़ने के लिए [SvgShape.setEventHandler](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgshape/#setEventHandler) को एक [SvgEvent](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को `jpype.JProxy` के माध्यम से रजिस्टर करें और इसे [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setShapeFormattingController) के साथ असाइन करें। परिणाम को होस्ट करने वाले पृष्ठ या SVG दस्तावेज़ में जावास्क्रिप्ट फ़ंक्शन परिभाषित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

होस्ट पेज हैंडलर द्वारा संदर्भित जावास्क्रिप्ट फ़ंक्शन को परिभाषित कर सकता है। ID और इवेंट हैंडलर को असाइन करने से स्लाइड व्यूअर, अभिगम्य सुधार और अन्य इंटरैक्टिव SVG कार्यप्रवाह सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) के बजाय करूँ?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना चाहिए। जब केवल वह टेक्स्ट जिसे बाहरी फ़ॉन्ट्स का उपयोग किया गया हो, ग्राफ़िक्स में बदलना हो, तब [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) का उपयोग करें।

**एक SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एंबेडेड चित्रों को कॉम्प्रेस करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण उन्हें सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक की अलग गुणवत्ता और आकार के ट्रेड‑ऑफ़ होते हैं।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से ID असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों का चयन करें।