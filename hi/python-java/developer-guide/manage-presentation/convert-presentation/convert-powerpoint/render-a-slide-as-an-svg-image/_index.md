---
title: Python के माध्यम से Java के उपयोग से प्रस्तुति स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड को SVG में
type: docs
weight: 50
url: /hi/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint को SVG में
- प्रस्तुति को SVG में
- स्लाइड को SVG में
- PPT को SVG में
- PPTX को SVG में
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java का उपयोग करके PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, छवियों, IDs और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित छवि प्रारूप है जो वेब प्रकाशन, स्लाइड व्यूअर, एक्सेसेबिलिटी वर्कफ़्लो, और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको यह नियंत्रित करने देता है कि टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्व कैसे लिखे जाएँ। जब निर्यात किया गया SVG संक्षिप्त, ब्राउज़रों में पूर्वानुमानित, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) का उपयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) बनाएँ, एक स्लाइड चुनें, और उसे [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) के साथ एक स्ट्रीम में लिखें। उदाहरणों के लिए मौजूदा `presentation.pptx` फ़ाइल आवश्यक है। प्रत्येक उदाहरण आवश्यकतानुसार JVM शुरू करता है और अपने आउटपुट स्ट्रीम्स को बंद करता है। निम्नलिखित उदाहरण एक प्रस्तुति की सभी स्लाइडों को अलग‑अलग SVG फ़ाइलों के रूप में निर्यात करता है।

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

फ़ाइलनाम में लूप इंडेक्स की बजाय [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) का उपयोग किया जाता है। आप [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) के साथ व्यक्तिगत आकार भी निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पृष्ठ को केवल वह आकार चाहिए हो।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) निर्धारित करता है कि फ़्रेम रोटेशन लागू किया जाए या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर करना हो, तो [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `True` सेट करें।

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

## **तीर सिरों पर लाइन‑एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में मार्कर इनसेट सेटिंग नहीं है जो यह निर्धारित करे कि एक लाइन तीर सिर के नीचे कहाँ रुकनी चाहिए। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यात की गई लाइन को छोटा करता है ताकि उसकी स्ट्रोक मार्कर के माध्यम से बाहर न निकलें। [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) को `True` के साथ कॉल करने पर स्ट्रोक को लाइन के मूल अंत बिंदु तक खींचा जाता है। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है। slide पर लाइन अपनी स्थिति और लंबाई बनाए रखती है।

उदाहरण 2 और 10 पॉइंट चौड़ी लाइनों पर त्रिकोण और हीरे के तीर सिर बनाता है। यह समान स्लाइड को दो बार निर्यात करता है, केवल क्रॉपिंग विकल्प को बदलते हुए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

तुलना 10‑पॉइंट लाइन पर त्रिकोणीय तीर सिर को दिखाती है। क्रॉपिंग सक्षम होने पर, टिप तीखी होती है। क्रॉपिंग अक्षम होने पर, स्ट्रोक मार्कर की ढलान वाली किनारों से बाहर निकलता है और एक सपाट अंत छोड़ता है।

![क्रॉपिंग सक्षम होने पर तीखी टिप और क्रॉपिंग अक्षम होने पर सपाट अंत वाला बड़ा किया गया 10‑पॉइंट त्रिकोण](line-end-cropping.png)

उदाहरण की अन्य लाइनों में, 2‑पॉइंट त्रिकोण पर बाहर निकलने वाली स्ट्रोक कम दिखाई देती है। भरे हुए हीरे दोनों चौड़ाइयों पर स्ट्रोक के अंत को ढकते हैं।

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

स्लाइड्स को SVG में निर्यात करते समय, आप यह नियंत्रित कर सकते हैं कि टेक्स्ट टेक्स्ट ही रहे या वेक्टर ग्राफिक्स में परिवर्तित हो, और बाहरी फ़ॉन्ट्स कैसे शामिल या संदर्भित किए जाएँ। निम्नलिखित विकल्प आपके निर्यातित SVG में दृश्य स्थिरता, टेक्स्ट चयन, और फ़ॉन्ट निर्भरताओं के बीच संतुलन स्थापित करने में मदद करते हैं।

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) को `True` सेट करके सभी स्लाइड टेक्स्ट को वेक्टर ग्राफिक्स के रूप में लिखें। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम ब्राउज़र में अधिक सुसंगत हो जाता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। `AddLinksToFontFiles` चुनें ताकि अलग फ़ॉन्ट फ़ाइलों का संदर्भ दिया जाए, `Embed` चुनें ताकि फ़ॉन्ट डेटा SVG में शामिल हो, या `Vectorize` चुनें ताकि केवल बाहरी फ़ॉन्ट्स वाले टेक्स्ट को ग्राफिक्स के रूप में रेंडर किया जाए। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एम्बेडेड इमेज आकार कम करें**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) का उपयोग करके एम्बेडेड चित्रों का रेजोल्यूशन कम किया जा सकता है, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) से क्रॉप किए गए स्रोत क्षेत्रों को हटाया जा सकता है, और [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) से JPEG एन्कोडिंग गुणवत्ता नियंत्रित की जा सकती है। इन सेटिंग्स से फ़ाइल आकार कम होता है, लेकिन इमेज की सटीकता या रखे गये डेटा की कीमत पर।

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

## **मेटाफाइल रास्टराइज़ेशन रेजोल्यूशन को नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) SVG निर्यात के दौरान मेटाफाइलों को रास्टराइज़ करने के लिए न्यूनतम रेजोल्यूशन सीमा सेट करता है। जब EMF या WMF इमेज को रास्टराइज़ किया जाता है, तो विवरण और फ़ाइल आकार के बीच संतुलन बनाने के लिए इसका उपयोग करें। यह SVG के लिए वैश्विक DPI परिभाषित नहीं करता और स्लाइड के हर ऑब्जेक्ट को रास्टर इमेज बनाने के लिए बाध्य नहीं करता।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकटस्थ कट पर स्थित डाइनेगॉनल लाइनों वाला एक EMF इमेज है। निम्नलिखित उदाहरण [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) के माध्यम से उसकी पहली स्लाइड को तीन रास्टराइज़ेशन रेजोल्यूशन पर निर्यात करता है। सभी अन्य निर्यात सेटिंग्स समान रखी गई हैं ताकि परिणामों की तुलना की जा सके।

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

आउटपुट में, EMF प्रत्येक SVG में एक एम्बेडेड PNG में बदल गया। नीचे दिए गए माप प्रदान की गई प्रस्तुति के लिए हैं; ये DPI को पिक्सेल आयाम में बदलने का सामान्य सूत्र नहीं हैं।

| मेटाफाइल रास्टराइज़ेशन DPI | एम्बेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे दर्शाया गया तुलना एम्बेडेड रास्टर के समान क्षेत्र को समान बड़े डिस्प्ले आकार पर दिखाती है। डाइनेगॉनल लाइनों में 72 DPI पर स्पष्ट पिक्सेलेशन और उच्च रेजोल्यूशन पर स्मूथ एज दिखते हैं, जबकि SVG फ़ाइल का आकार बढ़ता है। मान बढ़ाने से आवश्यक नहीं कि हर विवरण बेहतर हो या प्रत्येक निर्यातित इमेज बदल जाए।

![72, 150 और 300 DPI पर बड़ा किया गया डाइनेगॉनल‑लाइन विवरण](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) इमेज रेजोल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रेजोल्यूशन परिवर्तन के प्रभाव को छिपा सकता है। [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, मेटाफाइल रास्टराइज़ेशन रेजोल्यूशन को नहीं।

## **शेप्स और टेक्स्ट को स्थिर ID असाइन करें**

`jpype.JProxy` के माध्यम से पंजीकृत एक Python फ़ॉर्मेटिंग कंट्रोलर का उपयोग करके शैप्स को [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) मान और टेक्स्ट `tspan` तत्वों को [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) मान असाइन करें। प्रॉक्सी को [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) के साथ असाइन करें।

नीचे दिया गया कंट्रोलर [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId) का उपयोग करता है, जो शैप के जीवनकाल में स्थिर रहता है, और उसके टेक्स्ट स्पैन्स के लिए एक पुनरावृत्त काउंटर। यह जनरेट किए गए ID को अपरिवर्तित प्रस्तुति के पोस्ट‑प्रोसेसिंग के लिए उपयुक्त बनाता है।

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

एक Python फ़ॉर्मेटिंग कंट्रोलर में, निर्यातित शैप में JavaScript इवेंट हैंडलर जोड़ने के लिए [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) को एक [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) मान के साथ कॉल करें। कंट्रोलर को `jpype.JProxy` के माध्यम से पंजीकृत करें और उसे [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController) के साथ असाइन करें। परिणाम को होस्ट करने वाले पेज या SVG दस्तावेज़ में JavaScript फ़ंक्शन को परिभाषित करें।

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

होस्ट पेज हैंडलर द्वारा संदर्भित JavaScript फ़ंक्शन को परिभाषित कर सकता है। ID और इवेंट हैंडलर्स को असाइन करने से स्लाइड व्यूअर, एक्सेसेबिलिटी सुधार और अन्य इंटरेक्टिव SVG वर्कफ़्लो सक्षम होते हैं।

## **FAQ**

**जब मुझे [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) को [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) के बजाय उपयोग करना चाहिए?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट से स्वतंत्र रहना चाहिए। [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) का उपयोग तब करें जब केवल वह टेक्स्ट जो बाहरी फ़ॉन्ट्स प्रयोग करता है, ग्राफिक्स में परिवर्तित होना चाहिए।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए इमेज क्षेत्रों को हटाएँ, और जब लक्ष्य वातावरण उन्हें सर्व कर सके तो लिंक्ड फ़ॉन्ट फ़ाइलों को चुनें। परिणाम का परीक्षण करें क्योंकि कम इमेज रेजोल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट के अलग‑अलग गुणवत्ता और आकार के संतुलन होते हैं।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हां। फ़ॉर्मेटिंग कंट्रोलर के माध्यम से ID असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।