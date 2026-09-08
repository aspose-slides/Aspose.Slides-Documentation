---
title: "Python के माध्यम से Java में प्रस्तुति इंक ऑब्जेक्ट्स प्रबंधित करें"
linktitle: "इंक प्रबंधित करें"
type: docs
weight: 95
url: /hi/python-java/manage-ink/
keywords:
- "इंक"
- "इंक ऑब्जेक्ट"
- "इंक ट्रेस"
- "इंक प्रबंधित करें"
- "इंक बनाएं"
- "चित्रण"
- "इंक निर्यात"
- "इंक रेंडरिंग"
- "इंक छुपाएँ"
- InkOptions
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PDF, HTML, SVG, TIFF और इमेज निर्यात के दौरान PowerPoint इंक ऑब्जेक्ट्स का प्रबंधन, ट्रेस और ब्रश गुणों को संपादित करना, और इंक की उपस्थिति को नियंत्रित करना।"
---
## **परिचय**

PowerPoint एक इंक सुविधा प्रदान करता है जो आपको मुक्त‑रूप स्ट्रोक ड्रॉ करने की अनुमति देती है। इंक का उपयोग अन्य वस्तुओं को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड पर विशिष्ट आइटमों की ओर ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक प्रकार प्रदान करता है। उदाहरण के लिए, [Ink](https://reference.aspose.com/slides/hi/python-java/aspose.slides/ink/) क्लास स्लाइड पर एक इंक ऑब्जेक्ट का प्रतिनिधित्व करती है।

## **सामान्य ऑब्जेक्ट्स और इंक ऑब्जेक्ट्स के बीच अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शेप ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं। सबसे सरल रूप में, शेप एक कंटेनर है जो ऑब्जेक्ट के क्षेत्र (उसका फ्रेम) को आकार, रूप और पृष्ठभूमि जैसी गुणों के साथ परिभाषित करता है। अधिक जानकारी के लिए देखें [Shape Layout Format](/slides/hi/python-java/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint एक इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी गुणों को उसकी आकार को छोड़कर नजरअंदाज करता है। कंटेनर क्षेत्र का आकार मानक [Shape.getWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getWidth) और [Shape.getHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getHeight) मेथड्स द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेस**

इंक ट्रेस एक बुनियादी तत्व है जिसका उपयोग पेन की ट्रैजेक्टरी को रिकॉर्ड करने के लिए किया जाता है जब उपयोगकर्ता डिजिटल इंक लिखता है। एक ट्रेस कनेक्टेड पॉइंट्स की श्रृंखला संग्रहीत करता है।

एन्कोडिंग का सबसे सरल रूप प्रत्येक सैंपल पॉइंट के X और Y निर्देशांक निर्दिष्ट करता है। जब सभी कनेक्टेड पॉइंट्स रेंडर होते हैं, तो वे इस प्रकार की छवि बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्राइंग के लिए ब्रश गुण**

ब्रश का उपयोग इंक ट्रेस के पॉइंट्स को जोड़ने वाली लाइनों को ड्रॉ करने के लिए किया जाता है। ब्रश का अपना रंग और आकार होता है, जिसे [InkBrush.getColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/inkbrush/#getColor) और [InkBrush.getSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/inkbrush/#getSize) मेथड्स द्वारा दर्शाया जाता है।

### **इंक ब्रश रंग सेट करें**

यह Python कोड दिखाता है कि इंक ब्रश का रंग कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **इंक ब्रश आकार सेट करें**

यह Python कोड दिखाता है कि इंक ब्रश का आकार कैसे सेट किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश का आकार नहीं दिखाता (संबंधित डेटा सेक्शन ग्रे आउट होता है)। जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint उसके आकार को इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टीकरण के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मानता है कि लाइन की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट के दृश्यमान क्षेत्र का निर्धारण करने के लिए उसके ट्रेसेस के ब्रश आकार को ध्यान में रखा जाना चाहिए। यहाँ लक्ष्य ऑब्जेक्ट (हाथ‑लिखित टेक्स्ट ट्रेस) को कंटेनर (फ्रेम) के आकार में स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है, और इसके विपरीत।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint पाठ ऑब्जेक्ट्स के लिए समान व्यवहार करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **निर्यात और रेंडरिंग के दौरान इंक की उपस्थिति नियंत्रित करना**

Aspose.Slides [InkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/inkoptions/) क्लास प्रदान करता है जिससे आप निर्यात या रेंडर आउटपुट में इंक ऑब्जेक्ट्स की उपस्थिति को नियंत्रित कर सकते हैं। आप उसकी प्रॉपर्टीज़ का उपयोग इंक को पूरी तरह छुपाने या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या बदलने के लिए कर सकते हैं।

इंक विकल्प कई आउटपुट प्रकारों के निर्यात या रेंडरिंग विकल्पों के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प प्रॉपर्टी |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/#getInkOptions) |

निम्नलिखित [InkOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/inkoptions/) मेथड्स वही दो सेटिंग्स उजागर करते हैं:

- [getHideInk] निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हैं या नहीं। इसका डिफ़ॉल्ट मान `False` है।
- [getInterpretMaskOpAsOpacity] निर्धारित करता है कि रेंडरिंग के समय इंक ब्रश के लिए मास्क ऑपरेशन को अपारदर्शिता के रूप में व्याख्यायित किया जाए या नहीं। इसका डिफ़ॉल्ट मान `True` है; `False` पास करके ROP ऑपरेशन उपयोग करने के लिए [setInterpretMaskOpAsOpacity] को कॉल करें।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स को छुपाएँ**

डिफ़ॉल्ट रूप से, निर्यात के दौरान इंक ऑब्जेक्ट्स दिखाई देते रहते हैं। हैंडराइटन एनोटेशन या अन्य इंक सामग्री के बिना एक साफ़ आउटपुट बनाने के लिए, [InkOptions.setHideInk] को `True` के साथ कॉल करें।

निम्नलिखित Python उदाहरण सभी इंक ऑब्जेक्ट्स को छुपाते हुए प्रस्तुतीकरण को PDF में निर्यात करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **स्लाइड को इमेज के रूप में रेंडर करने पर इंक ऑब्जेक्ट्स को छुपाएँ**

स्लाइड्स को बिटमैप इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छुपाने के लिए, [RenderingOptions.getInkOptions] को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) को पास करें।

निम्नलिखित Python उदाहरण पहला स्लाइड PNG इमेज के रूप में रेंडर करता है जिसमें इंक ऑब्जेक्ट्स नहीं होते:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **इंक मास्क रेंडरिंग नियंत्रित करें**

[InkOptions.getInterpretMaskOpAsOpacity] सेटिंग नियंत्रित करती है कि इंक ब्रश रेंडर करते समय मास्क ऑपरेशन को कैसे व्याख्यायित किया जाए। डिफ़ॉल्ट मान `True` है, जो अपारदर्शिता का उपयोग करता है। ROP ऑपरेशन उपयोग करने के लिए, [InkOptions.setInterpretMaskOpAsOpacity] को `False` के साथ कॉल करें।

निम्नलिखित Python उदाहरण एक स्लाइड को SVG में निर्यात करता है और इंक मास्क ऑपरेशन्स के लिए ROP‑आधारित रेंडरिंग का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

इसी सेटिंग को [TiffOptions.getInkOptions] के माध्यम से भी लागू किया जा सकता है जब प्रस्तुतीकरण को निर्यात या स्लाइड को TIFF में रेंडर किया जाता है।

### **इंक को छुपाना या बरकरार रखना चुनें**

जब आपको वितरण के लिए एनोटेटेड प्रस्तुतीकरण का एक साफ़ संस्करण चाहिए जहाँ समीक्षा चिन्ह न हों, तो निर्यात के दौरान [InkOptions.setHideInk] को `True` के साथ कॉल करें।

जब इंक एनोटेशन इच्छित सामग्री का भाग हैं, जैसे समीक्षा टिप्पणी, हाथ‑लिखित नोट्स, हाइलाइट्स, या ड्रॉइंग्स जो निर्यात परिणाम में दिखाई देने चाहिए, तो [InkOptions.getHideInk] को उसके डिफ़ॉल्ट मान `False` पर रखें। यह अनुप्रयोगों को स्रोत इंक ऑब्जेक्ट्स को बदले बिना समान प्रस्तुतीकरण से अलग-अलग समीक्षा और अंतिम आउटपुट उत्पन्न करने की सुविधा देता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हां। [Ink.getTraces] से ट्रेस प्राप्त करें, फिर उसके [InkTrace.getBrush] को बदलें। ब्रश का रंग बदलने के लिए [InkBrush.setColor] और आकार बदलने के लिए [InkBrush.setSize] को कॉल करें।

**क्या इंक को छुपाने से स्रोत प्रस्तुतीकरण बदलता है?**

नहीं। [InkOptions.setHideInk] को कॉल करने से केवल रेंडर या निर्यात परिणाम प्रभावित होता है; यह स्रोत प्रस्तुतीकरण में इंक ऑब्जेक्ट्स को नहीं हटाता या बदलता।

**कौन से निर्यात फ़ॉर्मेट इंक विकल्पों का समर्थन करते हैं?**

आप ऊपर दिखाए गए संबंधित निर्यात या रेंडरिंग विकल्पों के माध्यम से PDF, HTML, SVG, TIFF और बिटमैप स्लाइड इमेज के लिए इंक विकल्पों को कॉन्फ़़िगर कर सकते हैं।

**और पढ़ें**

* सामान्य रूप में शेप्स के बारे में पढ़ने के लिए देखें [PowerPoint Shapes](/slides/hi/python-java/powerpoint-shapes/) सेक्शन।
* प्रभावी मानों के बारे में अधिक जानकारी के लिए देखें [Shape Effective Properties](/slides/hi/python-java/shape-effective-properties/#get-effective-font-height-value)।
* PDF निर्यात के विवरण के लिए देखें [Convert PPT and PPTX to PDF](/slides/hi/python-java/convert-powerpoint-to-pdf/)।
* HTML निर्यात के विवरण के लिए देखें [Convert PowerPoint Presentations to HTML](/slides/hi/python-java/convert-powerpoint-to-html/)।
* SVG निर्यात के विवरण के लिए देखें [Render Presentation Slides as SVG Images](/slides/hi/python-java/render-a-slide-as-an-svg-image/)।
* TIFF निर्यात के विवरण के लिए देखें [Convert PowerPoint Presentations to TIFF](/slides/hi/python-java/convert-powerpoint-to-tiff/)।
* स्लाइड‑से‑इमेज रेंडरिंग के विवरण के लिए देखें [Convert Presentation Slides to Images](/slides/hi/python-java/convert-slide/).