---
title: Python के माध्यम से Java के द्वारा प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड को SVG में
type: docs
weight: 50
url: /hi/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG में
- प्रेजेंटेशन को SVG में
- स्लाइड को SVG में
- PPT को SVG में
- PPTX को SVG में
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java के द्वारा PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, छवियों, IDs और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर, एक्सेसेबिलिटी वर्कफ़्लो, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए अच्छा काम करता है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में एक्सपोर्ट करता है और आपको नियंत्रण देता है कि टेक्स्ट, फ़ॉन्ट, चित्र, और SVG तत्व कैसे लिखे जाएँ। जब एक्सपोर्ट किया गया SVG कॉम्पेक्ट, ब्राउज़र में पूर्वानुमेय, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए तो [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में एक्सपोर्ट करें**

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएं, एक स्लाइड चुनें, और उसे [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) के साथ स्ट्रीम में लिखें। उदाहरणों को एक मौजूदा `presentation.pptx` फ़ाइल की आवश्यकता होती है। प्रत्येक उदाहरण आवश्यक होने पर JVM शुरू करता है और आउटपुट स्ट्रीम को बंद करता है। निम्न उदाहरण एक प्रेज़ेंटेशन की प्रत्येक स्लाइड को अलग SVG फ़ाइल के रूप में एक्सपोर्ट करता है।

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

फ़ाइलनाम [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) का उपयोग करता है न कि लूप इंडेक्स का। आप [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) का उपयोग करके एक व्यक्तिगत शेप भी एक्सपोर्ट कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वह शेप चाहिए हो।

## **SVG आउटपुट कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग क्षेत्र में टेक्स्ट फ्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर किया जाना हो तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `True` सेट करें।

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

## **टेक्स्ट और फ़ोंट को नियंत्रित करें**

जब स्लाइड्स को SVG में एक्सपोर्ट किया जाता है, तो आप नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट रूप में रहे या वेक्टर ग्राफ़िक्स में परिवर्तित हो, और बाहरी फ़ोंट कैसे शामिल या संदर्भित किए जाएँ। निम्न विकल्प आपको एक्सपोर्ट किए गए SVG में दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) को `True` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और विज़ुअल परिणाम ब्राउज़रों में अधिक सुसंगत रहता है, परन्तु टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

### **बाहरी फ़ोंट को कैसे हैंडल किया जाए चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। अलग-अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `AddLinksToFontFiles` चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए `Embed` चुनें, या बाहरी फ़ॉन्ट का उपयोग करने वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर करने के लिए `Vectorize` चुनें। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एम्बेडेड इमेज आकार घटाएँ**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) का उपयोग करके एम्बेडेड चित्रों का रिज़ॉल्यूशन घटाएँ, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) से क्रॉप किए गए स्रोत क्षेत्रों को छोड़ें, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) से JPEG एन्कोडिंग क्वालिटी नियंत्रित करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज की फिडेलिटी या रखे गए इमेज डेटा की कीमत पर।

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

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) SVG एक्सपोर्ट के दौरान मेटाफाइल को रास्टराइज़ करने के लिए निचली रिज़ॉल्यूशन सीमा सेट करता है। जब EMF या WMF इमेज को रास्टराइज़ किया जाता है तो विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए इसका उपयोग करें। यह SVG के लिए एक ग्लोबल DPI निर्धारित नहीं करता और न ही स्लाइड के प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनने के लिए बाध्य करता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकटवर्ती विकर्ण रेखाओं वाला EMF इमेज है। निम्न उदाहरण उसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन पर [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) के माध्यम से एक्सपोर्ट करता है। सभी अन्य एक्सपोर्ट सेटिंग्स समान रहती हैं ताकि परिणामों की तुलना की जा सके।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

आउटपुट में, EMF प्रत्येक SVG में एक एम्बेडेड PNG में बदल गया। निम्न माप प्रदान किए गए प्रेज़ेंटेशन के लिए हैं; यह DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं है।

| मेटाफाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे का तुलना एम्बेडेड रास्टर के समान क्षेत्र को समान बढ़ी हुई डिस्प्ले साइज पर दिखाती है। विकर्ण रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन और उच्च रिज़ॉल्यूशन पर स्मूथ एजेज़ दिखाती हैं, जबकि SVG फ़ाइल बढ़ती है। मान बढ़ाने से जरूरी नहीं कि हर विवरण में सुधार हो या प्रत्येक एक्सपोर्ट की गई इमेज बदले।

![72, 150, और 300 DPI पर बढ़ी हुई विकर्ण-रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) इमेज रिज़ॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छुपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) JPEG एन्कोडिंग क्वालिटी को नियंत्रित करता है, न कि मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को।

## **Shapes और टेक्स्ट के लिए स्थिर IDs असाइन करें**

`jpype.JProxy` के माध्यम से पंजीकृत Python फ़ॉर्मेटिंग कंट्रोलर का उपयोग करके शैप्स को [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) मान और टेक्स्ट `tspan` एलिमेंट्स को [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) मान असाइन करें। प्रॉक्सी को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) से असाइन करें।

निम्न कंट्रोलर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग करता है, जो शैप के जीवनकाल में स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक दोहराने योग्य काउंटर। यह उत्पन्न IDs को बिना बदली प्रेज़ेंटेशन के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

## **SVG इवेंट हैंडलर्स जोड़ें**

Python फ़ॉर्मेटिंग कंट्रोलर में, [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) को एक [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) मान के साथ कॉल करके एक्सपोर्ट किए गए शैप में JavaScript इवेंट हैंडलर जोड़ें। कंट्रोलर को `jpype.JProxy` के माध्यम से रजिस्टर करें और उसे [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) के साथ असाइन करें। परिणाम को होस्ट करने वाले पेज या SVG डॉक्यूमेंट में JavaScript फ़ंक्शन परिभाषित करें।

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

होस्ट पेज हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। IDs और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर्स, एक्सेसेबिलिटी सुधार, और अन्य इंटरैक्टिव SVG वर्कफ़्लोज़ सक्षम होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**कब मुझे [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) के बजाय करना चाहिए?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र होना आवश्यक हो। [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) का उपयोग तब करें जब केवल वे टेक्स्ट जो बाहरी फ़ॉन्ट उपयोग करते हैं, ग्राफ़िक्स में परिवर्तित किए जाने चाहिए।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को कॉम्प्रेस करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और यदि लक्ष्य वातावरण उन्हें सर्व कर सकता है तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG क्वालिटी, और वेक्टराइज़्ड टेक्स्ट प्रत्येक का अलग गुणवत्ता और आकार का ट्रेड‑ऑफ़ होता है।

**क्या मैं एक्सपोर्ट किए गए SVG एलिमेंट्स को एक्सपोर्ट के बाद संशोधित कर सकता हूँ?**

हाँ। एक फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG एलिमेंट्स को चुनें।