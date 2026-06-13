---
title: PowerPoint प्रस्तुतियों को Python में TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint रूपांतरित करें
- OpenDocument रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PowerPoint से TIFF
- OpenDocument से TIFF
- प्रस्तुति से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- ODP से TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF छवियों में आसानी से बदलना सीखें। चरण-दर-चरण मार्गदर्शिका जिसमें कोड उदाहरण शामिल हैं।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लोसलैस रास्टर इमेज फ़ॉर्मेट है जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF को अपनी छवियों में लेयर्स, रंग सटीकता, और मूल सेटिंग्स को बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च गुणवत्ता वाले TIFF छवियों में आसानी से बदल सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य सत्यता बनी रहती है।

## **एक प्रस्तुति को TIFF में रूपांतरित करें**

उपलब्ध कराए गए [save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/#methods) मेथड को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास द्वारा उपयोग करके, आप पूरी PowerPoint प्रस्तुति को जल्दी से TIFF में बदल सकते हैं। परिणामस्वरूप TIFF छवियाँ डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को TIFF में बदला जाए:

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("presentation.pptx") as presentation:
    # प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **एक प्रस्तुति को ब्लैक-एंड-व्हाइट TIFF में रूपांतरित करें**

[bw_conversion_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) प्रॉपर्टी, जो [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास में स्थित है, आपको रंगीन स्लाइड या इमेज को ब्लैक-एंड-व्हाइट TIFF में बदलते समय उपयोग होने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देती है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [compression_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/compression_type/) प्रॉपर्टी `CCITT4` या `CCITT3` पर सेट की गई हो।

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह Python कोड दिखाता है कि कैसे रंगीन स्लाइड को ब्लैक-एंड-व्हाइट TIFF में बदला जाए:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

परिणाम:

![ब्लैक-एंड-व्हाइट TIFF](TIFF_black_and_white.png)

## **एक प्रस्तुति को कस्टम आकार के साथ TIFF में रूपांतरित करें**

यदि आपको विशिष्ट आयामों के साथ TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [image_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/image_size/) प्रॉपर्टी आपको उत्पन्न छवि का आकार निर्धारित करने की अनुमति देती है।

यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को कस्टम आकार के साथ TIFF छवियों में बदला जाए:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Presentation फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # संपीड़न प्रकार सेट करें।
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # इमेज DPI सेट करें।
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # इमेज आकार सेट करें।
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सेव करें।
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **एक प्रस्तुति को कस्टम इमेज पिक्सेल फ़ॉर्मेट के साथ TIFF में रूपांतरित करें**

[pixel_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/pixel_format/) प्रॉपर्टी, जो [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास से ली गई है, का उपयोग करके, आप परिणामस्वरूप TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फ़ॉर्मेट निर्दिष्ट कर सकते हैं।

यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति को कस्टम पिक्सेल फ़ॉर्मेट वाली TIFF इमेज में बदला जाए:

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सेव करें।
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}
Aspose के [मुफ़्त PowerPoint से पोस्टर कन्वर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में रूपांतरित कर सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF छवियों में बदलने की अनुमति देता है।

**क्या प्रस्तुति को TIFF में रूपांतरित करते समय स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइडों को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थैतिक स्नैपशॉट निर्यात किए जाते हैं।