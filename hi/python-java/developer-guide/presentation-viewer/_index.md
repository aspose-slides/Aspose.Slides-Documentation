---
title: Java के माध्यम से Python में एक प्रेज़ेंटेशन व्यूअर बनाएं
linktitle: प्रेज़ेंटेशन व्यूअर
type: docs
weight: 50
url: /hi/python-java/presentation-viewer/
keywords:
- प्रेज़ेंटेशन देखें
- प्रेज़ेंटेशन व्यूअर
- प्रेज़ेंटेशन व्यूअर बनाएं
- PPT देखें
- PPTX देखें
- ODP देखें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java के माध्यम से Python में एक कस्टम प्रेज़ेंटेशन व्यूअर बनाएं। Microsoft PowerPoint के बिना आसानी से PowerPoint और OpenDocument फ़ाइलें दिखाएं।"
---
## **परिचय**

Aspose.Slides for Python via Java का उपयोग स्लाइडों वाले प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जाता है। इन स्लाइडों को उदाहरण के तौर पर Microsoft PowerPoint में प्रेजेंटेशन खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को स्लाइडों को अपने पसंदीदा इमेज व्यूअर में इमेज के रूप में देखना पड़ता है या अपना स्वयं का प्रेजेंटेशन व्यूअर बनाना पड़ता है। ऐसे मामलों में, Aspose.Slides आपको व्यक्तिगत स्लाइड को इमेज के रूप में निर्यात करने की सुविधा देता है। यह लेख बताता है कि यह कैसे किया जाता है।

## **स्लाइड से SVG इमेज उत्पन्न करें**

Aspose.Slides के साथ प्रेजेंटेशन स्लाइड से SVG इमेज उत्पन्न करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक इंस्टेंस बनाएँ [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की।  
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।  
3. एक बाइट स्ट्रीम खोलें।  
4. स्लाइड को SVG इमेज के रूप में स्ट्रीम में सहेजें और फ़ाइल में लिखें।  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **कस्टम शेप ID के साथ SVG उत्पन्न करें**

Aspose.Slides का उपयोग कस्टम शेप ID वाले स्लाइड से एक [SVG](https://docs.fileformat.com/page-description-language/svg/) उत्पन्न करने के लिए किया जा सकता है। ऐसा करने के लिए, [SvgShape.setId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgshape/#setId) मेथड को [SvgShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgshape/) से उपयोग करें। `CustomSvgShapeFormattingController` का उपयोग शेप ID सेट करने के लिए किया जा सकता है।  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **स्लाइड थंबनेल इमेज बनाएं**

Aspose.Slides आपको स्लाइडों के थंबनेल इमेज जनरेट करने में मदद करता है। Aspose.Slides का उपयोग करके स्लाइड का थंबनेल उत्पन्न करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक इंस्टेंस बनाएँ [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की।  
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।  
3. निर्धारित स्केल पर रेफ़रेंस्ड स्लाइड की थंबनेल इमेज प्राप्त करें।  
4. थंबनेल इमेज को किसी भी इच्छित इमेज फॉर्मेट में सहेजें।  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **यूज़र-डिफ़ाइंड डायमेंशन के साथ स्लाइड थंबनेल बनाएं**

यूज़र-डिफ़ाइंड डायमेंशन के साथ स्लाइड थंबनेल इमेज बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक इंस्टेंस बनाएँ [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की।  
2. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।  
3. परिभाषित डायमेंशन के साथ रेफ़रेंस्ड स्लाइड की थंबनेल इमेज प्राप्त करें।  
4. थंबनेल इमेज को किसी भी इच्छित इमेज फॉर्मेट में सहेजें।  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **स्पीकर नोट्स के साथ स्लाइड थंबनेल बनाएं**

Aspose.Slides का उपयोग करके स्पीकर नोट्स के साथ स्लाइड का थंबनेल उत्पन्न करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक इंस्टेंस बनाएँ [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/) क्लास की।  
2. स्पीकर नोट्स की पोज़ीशन सेट करने के लिए [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) मेथड का उपयोग करें।  
3. एक इंस्टेंस बनाएँ [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की।  
4. इंडेक्स द्वारा स्लाइड रेफ़रेंस प्राप्त करें।  
5. रेंडरिंग विकल्पों के साथ रेफ़रेंस्ड स्लाइड की थंबनेल इमेज प्राप्त करें।  
6. थंबनेल इमेज को किसी भी इच्छित इमेज फॉर्मेट में सहेजें।  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **लाइव उदाहरण**

आप मुफ्त एप्लिकेशन [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hi/viewer/) को आज़मा सकते हैं ताकि देख सकें कि आप Aspose.Slides API के साथ क्या बना सकते हैं:

![ऑनलाइन पॉवरपॉइंट व्यूअर](online-PowerPoint-viewer.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं वेब एप्लिकेशन में प्रेजेंटेशन व्यूअर एम्बेड कर सकता/सकती हूँ?**  
हां। आप सर्वर साइड पर Aspose.Slides का उपयोग करके स्लाइडों को इमेज या HTML के रूप में रेंडर कर सकते हैं और उन्हें ब्राउज़र में प्रदर्शित कर सकते हैं। नेविगेशन और ज़ूम फीचर्स को JavaScript के साथ इंटरेक्टिव अनुभव के लिए लागू किया जा सकता है।

**कस्टम व्यूअर के अंदर स्लाइड्स दिखाने का सबसे अच्छा तरीका क्या है?**  
सिफारिश किया जाने वाला तरीका यह है कि हर स्लाइड को इमेज (जैसे PNG या SVG) के रूप में रेंडर किया जाए या Aspose.Slides का उपयोग करके इसे HTML में परिवर्तित किया जाए, फिर आउटपुट को डेस्कटॉप के लिए पिक्चर बॉक्स या वेब के लिए HTML कंटेनर में दिखाया जाए।

**मैं कई स्लाइडों वाले बड़े प्रेजेंटेशन को कैसे हैंडल करूँ?**  
बड़े प्रेजेंटेशन के लिए, स्लाइडों को लेज़ी-लोडिंग या ऑन-डिमांड रेंडरिंग पर विचार करें। इसका अर्थ है कि स्लाइड का कंटेंट केवल तब जेनरेट किया जाए जब उपयोगकर्ता उसे नेविगेट करे, जिससे मेमोरी और लोड टाइम कम हो जाता है।