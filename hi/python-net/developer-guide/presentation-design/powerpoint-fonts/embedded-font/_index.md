---
title: Python के साथ प्रस्तुतियों में फ़ॉन्ट एम्बेड करें
linktitle: फ़ॉन्ट एम्बेडिंग
type: docs
weight: 40
url: /hi/python-net/embedded-font/
keywords:
- फ़ॉन्ट जोड़ें
- फ़ॉन्ट एम्बेड करें
- फ़ॉन्ट एम्बेडिंग
- एम्बेडेड फ़ॉन्ट प्राप्त करें
- एम्बेडेड फ़ॉन्ट जोड़ें
- एम्बेडेड फ़ॉन्ट हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में TrueType फ़ॉन्ट एम्बेड करें, जिससे सभी प्लेटफ़ॉर्म पर सटीक रेंडरिंग सुनिश्चित हो।"
---
## **परिचय**

PowerPoint में फ़ॉन्ट एम्बेड करने से यह सुनिश्चित होता है कि आपका प्रस्तुतीकरण विभिन्न सिस्टम पर अपनी इच्छित रूपरेखा को बनाए रखे। चाहे रचनात्मकता के लिए अनोखे फ़ॉन्ट उपयोग किए जाएँ या सामान्य फ़ॉन्ट, फ़ॉन्ट एम्बेड करने से पाठ और लेआउट में बाधा नहीं आती।

यदि आपने अपने कार्य में रचनात्मक होने के कारण थर्ड‑पार्टी या गैर‑मानक फ़ॉन्ट का उपयोग किया है, तो आपको फ़ॉन्ट एम्बेड करने के और भी कारण मिलते हैं। अन्यथा (बिना एम्बेडेड फ़ॉन्ट के), आपके स्लाइड्स पर पाठ या संख्याएँ, लेआउट, स्टाइलिंग आदि बदल सकते हैं या भ्रमित करने वाले आयताकार में बदल सकते हैं।

एम्बेडेड फ़ॉन्ट को प्रबंधित करने के लिए आप [FontsManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontdata/), और [Compress](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/) क्लासों का उपयोग कर सकते हैं।

## **एम्बेडेड फ़ॉन्ट प्राप्त करें और हटाएँ**

एक प्रस्तुतीकरण से एम्बेडेड फ़ॉन्ट को आसानी से प्राप्त या हटाने के लिए आप [get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) और [remove_embedded_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/remove_embedded_font/) मेथड्स का उपयोग कर सकते हैं।

यह Python कोड दर्शाता है कि प्रस्तुतीकरण से एम्बेडेड फ़ॉन्ट को कैसे प्राप्त और हटाया जा सकता है:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# प्रस्तुतीकरण फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास को इंस्टैंशिएट करें।
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # एम्बेडेड 'FunSized' फ़ॉन्ट का उपयोग करने वाले टेक्स्ट फ्रेम वाले स्लाइड को रेंडर करें।
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # सभी एम्बेडेड फ़ॉन्ट प्राप्त करें।
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # 'Calibri' फ़ॉन्ट खोजें।
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # 'Calibri' फ़ॉन्ट हटाएँ।
    fonts_manager.remove_embedded_font(font_data)

    # स्लाइड को रेंडर करें; 'Calibri' फ़ॉन्ट को एक मौजूदा फ़ॉन्ट से प्रतिस्थापित किया जाएगा।
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # एम्बेडेड 'Calibri' फ़ॉन्ट के बिना प्रस्तुतीकरण को डिस्क पर सहेजें।
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **एम्बेडेड फ़ॉन्ट जोड़ें**

[EmbedFontCharacters](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/embedfontcharacters/) enum और [add_embedded_font](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/add_embedded_font/) मेथड के दो ओवरलोड्स का उपयोग करके, आप प्रस्तुतीकरण में फ़ॉन्ट एम्बेड करने के लिए अपनी पसंदीदा (एम्बेडिंग) नियम चुन सकते हैं। यह Python कोड दर्शाता है कि प्रस्तुतीकरण में फ़ॉन्ट को कैसे एम्बेड और जोड़ें:

```python
import aspose.slides as slides

# एक प्रस्तुतीकरण लोड करें।
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # प्रस्तुतीकरण को डिस्क पर सहेजें।
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **एम्बेडेड फ़ॉन्ट संपीड़ित करें**

[compress_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) का उपयोग करके एम्बेडेड फ़ॉन्ट को संपीड़ित करके फ़ाइल आकार को अनुकूलित करें। संपीड़न के लिए उदाहरण कोड:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे पता कर सकता हूँ कि एम्बेडिंग के बावजूद प्रस्तुतीकरण में कोई विशेष फ़ॉन्ट रेंडरिंग के समय अभी भी प्रतिस्थापित किया जाएगा?**

फ़ॉन्ट मैनेज़र में [सबस्टीट्यूशन जानकारी](/slides/hi/python-net/font-substitution/) और [फ़ॉलबैक/सबस्टीट्यूशन नियम](/slides/hi/python-net/fallback-font/) देखें: यदि फ़ॉन्ट उपलब्ध नहीं है या प्रतिबंधित है, तो एक फ़ॉलबैक उपयोग किया जाएगा।

**क्या Arial/Calibri जैसे “सिस्टम” फ़ॉन्ट को एम्बेड करना सार्थक है?**

आमतौर पर नहीं—ये लगभग हमेशा उपलब्ध होते हैं। लेकिन “पतले” वातावरण (Docker, पूर्व‑इंस्टॉल किए बिना फ़ॉन्ट वाले Linux सर्वर) में पूर्ण पोर्टेबिलिटी के लिए सिस्टम फ़ॉन्ट को एम्बेड करने से अनपेक्षित प्रतिस्थापन का जोखिम समाप्त हो सकता है।