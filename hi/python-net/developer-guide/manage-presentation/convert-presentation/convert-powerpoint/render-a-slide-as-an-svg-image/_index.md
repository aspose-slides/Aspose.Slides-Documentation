---
title: Python में SVG छवियों के रूप में प्रस्तुति स्लाइड्स रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेज़ेंटेशन से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- PowerPoint
- प्रेज़ेंटेशन
- Python
- Aspose.Slides
description: "Python में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट और छवियों को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मैट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, अभिगम्यता कार्यप्रवाह, और स्वचालित पोस्ट-प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides प्रत्येक स्लाइड को अलग SVG फ़ाइल में निर्यात करता है और आपको पाठ, फ़ॉन्ट, चित्र, और SVG तत्वों के लेखन को नियंत्रित करने की अनुमति देता है।

जब निर्यात किया गया SVG संक्षिप्त, विभिन्न ब्राउज़र में पूर्वानुमानित, या इंटरैक्टिव उपयोग के लिए तैयार होना चाहिए, तब [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) का उपयोग करें।

## **एक स्लाइड को SVG के रूप में निर्यात करें**

एक [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) बनाकर, स्लाइड चुनें, और इसे स्ट्रीम में लिखें। नीचे दिया गया उदाहरण प्रस्तुति की प्रत्येक स्लाइड को अलग SVG फ़ाइल के रूप में निर्यात करता है।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

फ़ाइलनाम [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) का उपयोग करता है, लूप इंडेक्स के बजाय। आप [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) का उपयोग करके व्यक्तिगत आकार को भी निर्यात कर सकते हैं जब स्लाइड व्यूअर या वेब पेज को केवल वही आकार चाहिए।

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) निर्धारित करता है कि फ़्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर किया जाना हो, तो [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) को `True` सेट करें।

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

जब स्लाइड्स को SVG में निर्यात किया जाता है, तो आप नियंत्रित कर सकते हैं कि पाठ पाठ के रूप में रहे या वेक्टर ग्राफ़िक्स में परिवर्तित हो, और बाहरी फ़ॉन्ट कैसे शामिल या संदर्भित किए जाएँ। निम्न विकल्प निर्यात किए गए SVG में दृश्य स्थिरता, पाठ चयन, और फ़ॉन्ट निर्भरताओं को संतुलित करने में मदद करते हैं।

### **सभी पाठ को वेक्टराइज़ करें**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) को `True` सेट करें ताकि सभी स्लाइड पाठ को वेक्टर ग्राफ़िक्स के रूप में लिखा जा सके। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम विभिन्न ब्राउज़र में अधिक सुसंगत हो जाता है, लेकिन पाठ अब SVG पाठ के रूप में चयन योग्य या खोज योग्य नहीं रहेगा।

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **बाहरी फ़ॉन्ट कैसे संभाले जाएँ चुनें**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) बाहरी रूप से लोड किए गए फ़ॉन्ट के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) मान का उपयोग करता है। अलग फ़ॉन्ट फ़ाइलों को संदर्भित करने के लिए `ADD_LINKS_TO_FONT_FILES` चुनें, SVG में फ़ॉन्ट डेटा शामिल करने के लिए `EMBED` चुनें, या बाहरी फ़ॉन्ट उपयोग करने वाले पाठ को ग्राफ़िक्स में बदलने के लिए `VECTORIZE` चुनें। फ़ॉन्ट को एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की जाँच करें।

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

## **एंबेडेड इमेज आकार को कम करें**

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) का उपयोग एंबेडेड चित्रों की रिज़ॉल्यूशन घटाने के लिए करें, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) का उपयोग क्रॉप किए गए स्रोत क्षेत्रों को छोड़ने के लिए करें, और [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) का उपयोग JPEG एन्कोडिंग गुणवत्ता पर नियंत्रण रखने के लिए करें। ये सेटिंग्स फ़ाइल आकार को घटाती हैं लेकिन इमेज की सत्यता या रखे गए इमेज डेटा की कीमत पर।

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

## **मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को नियंत्रित करें**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) SVG निर्यात के दौरान मेटाफाइल को रास्टराइज़ करने के लिए निचली रिज़ॉल्यूशन सीमा निर्धारित करता है। जब EMF या WMF इमेज रास्टराइज़ की जाती है, तब विवरण और फ़ाइल आकार को संतुलित करने के लिए इसका उपयोग करें। यह SVG के लिए एक वैश्विक DPI निर्धारित नहीं करता और न ही स्लाइड के प्रत्येक ऑब्जेक्ट को रास्टर इमेज बनने के लिए मजबूर करता है।

[metafile-rasterization.pptx](metafile-rasterization.pptx) डाउनलोड करें, जिसमें निकट दूरी वाली तिरछी रेखाओं वाला EMF इमेज है। नीचे दिया गया उदाहरण [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/) के माध्यम से इसकी पहली स्लाइड को तीन रास्टराइज़ेशन रिज़ॉल्यूशन पर निर्यात करता है। सभी अन्य निर्यात सेटिंग्स समान रहती हैं जिससे परिणामों की तुलना की जा सके।

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

| मेटाफाइल रास्टराइज़ेशन DPI | एंबेडेड PNG आयाम | SVG फ़ाइल आकार (बाइट्स) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

नीचे की तुलना एंबेडेड रास्टर के समान क्षेत्र को समान बढ़े हुए प्रदर्शनी आकार पर दिखाती है। तिरछी रेखाएँ 72 DPI पर स्पष्ट पिक्सेलेशन और उच्च रिज़ॉल्यूशन पर स्मूथ किनारे दिखाती हैं, जबकि SVG फ़ाइल का आकार बढ़ता है। मान बढ़ाने से आवश्यक नहीं कि हर विवरण में सुधार हो या प्रत्येक निर्यात किए गए इमेज में परिवर्तन आए।

![72, 150, और 300 DPI पर बड़ा तिरछी-रेखा विवरण](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) इमेज रिज़ॉल्यूशन कमी को नियंत्रित करता है और मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन बदलने के प्रभाव को छिपा सकता है। [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) JPEG एन्कोडिंग गुणवत्ता को नियंत्रित करता है, मेटाफाइल रास्टराइज़ेशन रिज़ॉल्यूशन को नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) का उपयोग [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) के बजाय करूँ?**

[SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) का उपयोग तब करें जब सभी पाठ फ़ॉन्ट से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) का उपयोग तब करें जब केवल बाहरी फ़ॉन्ट उपयोग करने वाले पाठ को ग्राफ़िक्स में बदलना हो।

**SVG को छोटा बनाने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एंबेडेड चित्रों को संपीड़ित करके, क्रॉप किए गए इमेज क्षेत्रों को हटाकर, और लक्ष्य वातावरण द्वारा फ़ॉन्ट फ़ाइलों को सर्व किया जा सके तो लिंक्ड फ़ॉन्ट फ़ाइलें चुनकर शुरू करें। परिणाम का परीक्षण करें क्योंकि कम इमेज रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड पाठ प्रत्येक विभिन्न गुणवत्ता और आकार समझौते रखते हैं।