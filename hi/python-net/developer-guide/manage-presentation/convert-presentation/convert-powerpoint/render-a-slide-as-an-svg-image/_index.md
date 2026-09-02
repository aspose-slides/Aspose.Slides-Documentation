---
title: पायथन में प्रेजेंटेशन स्लाइड्स को SVG इमेजेज़ के रूप में निर्यात करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेजेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "पायथन में PowerPoint स्लाइड्स को SVG इमेजेज़ के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट और इमेजेज़ को नियंत्रित करें।"
---
## **परिचय**

SVG एक स्केलेबल XML‑आधारित इमेज फॉर्मेट है जो वेब पब्लिशिंग, स्लाइड व्यूअर, एक्सेसिबिलिटी वर्कफ़्लो और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको यह नियंत्रण देता है कि टेक्स्ट, फॉन्ट, चित्र और SVG तत्व कैसे लिखे जाएँ।

जब निर्यात किया गया SVG संक्षिप्त, विभिन्न ब्राउज़र में पूर्वानुमेय या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तो [SVGOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/) का उपयोग करें।

## **स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएँ, एक स्लाइड चुनें, और उसे स्ट्रीम में लिखें। निम्न उदाहरण प्रस्तुति की प्रत्येक स्लाइड को एक अलग SVG फ़ाइल के रूप में निर्यात करता है।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

फ़ाइलनाम में लूप इंडेक्स के बजाय [Slide.slide_number](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_number/) का उपयोग किया गया है। आप एक व्यक्तिगत आकार को भी [Shape.write_as_svg](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) से निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए हो।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/use_frame_size/) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को सम्मिलित करता है, और [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) यह निर्धारित करता है कि फ़्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को लिगेचर के बिना रेंडर किया जाना हो, तो [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) को `True` पर सेट करें।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **पाठ और फ़ॉन्ट को नियंत्रित करें**

### **सभी पाठ को वेक्टराइज़ करें**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/vectorize_text/) को `True` पर सेट करने से सभी स्लाइड पाठ को वेक्टर ग्राफ़िक्स के रूप में लिखा जाता है। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम विभिन्न ब्राउज़र में अधिक सुसंगत रहता है, लेकिन टेक्स्ट अब SVG पाठ के रूप में चयनित या खोजयोग्य नहीं रहता।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **बाहरी फ़ॉन्ट को कैसे संभालें चुनें**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgexternalfontshandling/) मान प्रयोग करता है। `ADD_LINKS_TO_FONT_FILES` चुनें ताकि अलग फ़ॉन्ट फ़ाइलों का संदर्भ दिया जा सके, `EMBED` चुनें ताकि फ़ॉन्ट डेटा SVG में शामिल हो, या `VECTORIZE` चुनें ताकि बाहरी फ़ॉन्ट वाले पाठ को केवल ग्राफ़िक्स के रूप में रेंडर किया जाए। फ़ॉन्ट एम्बेड करने से पहले लाइसेंसिंग की पुष्टि करें।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **एम्बेडेड इमेज आकार को घटाएँ**

एम्बेडेड चित्रों का रिज़ॉल्यूशन घटाने के लिए [SVGOptions.pictures_compression](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/pictures_compression/) का उपयोग करें, क्रॉप किए गए स्रोत क्षेत्रों को हटाने के लिए [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) और JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करने के लिए [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/jpeg_quality/) का उपयोग करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं, पर इमेज की फिडेलिटी या रखे गए इमेज डेटा की कीमत पर।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कब मुझे [SVGOptions.vectorize_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/vectorize_text/) का उपयोग [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgexternalfontshandling/) की बजाय करना चाहिए?**

जब सभी पाठ को फ़ॉन्ट से स्वतंत्र होना चाहिए, तब [SVGOptions.vectorize_text](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgoptions/vectorize_text/) का उपयोग करें। जब केवल वही पाठ जो बाहरी फ़ॉन्ट का उपयोग करता है, उसे ग्राफ़िक्स में बदलना हो, तब [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/svgexternalfontshandling/) का उपयोग करें।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

पहले एम्बेडेड चित्रों को संकुचित करें, क्रॉप किए गए चित्र क्षेत्रों को हटाएँ, और लक्षित वातावरण में फ़ॉन्ट फ़ाइलों को सर्व करने की क्षमता होने पर लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम रिज़ॉल्यूशन वाला चित्र, कम JPEG गुणवत्ता, और वेक्टराइज़्ड पाठ प्रत्येक का गुणवत्ता‑आकार पर अलग‑अलग प्रभाव होता है।