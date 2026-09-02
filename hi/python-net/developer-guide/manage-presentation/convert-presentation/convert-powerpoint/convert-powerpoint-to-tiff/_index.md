---
title: Python में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint को परिवर्तित करें
- OpenDocument को परिवर्तित करें
- प्रेज़ेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PowerPoint से TIFF
- OpenDocument से TIFF
- प्रेज़ेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- ODP से TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से बदलना सीखें। कोड उदाहरणों के साथ चरण-दर-चरण मार्गदर्शिका शामिल है।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी उत्कृष्ट गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर TIFF को अपनी छवियों में लेयर, रंग सटीकता, और मूल सेटिंग्स बनाए रखने के लिए चुनते हैं।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च गुणवत्ता वाली TIFF इमेजेज़ में आसानी से बदल सकते हैं, जिससे आपकी प्रस्तुतियाँ अधिकतम दृश्य स्पष्टता बनाए रखें।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

Using the [सहेजें](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/#methods) method provided by the [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

This Python code demonstrates how to convert a PowerPoint presentation to TIFF:

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल (PPT, PPTX, ODP आदि) का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें।
with slides.Presentation("presentation.pptx") as presentation:
    # प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **प्रेज़ेंटेशन को काले‑सफ़ेद TIFF में बदलें**

प्रॉपर्टी [bw_conversion_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास में आपको रंगीन स्लाइड या इमेज को काले‑सफ़ेद TIFF में बदलने के लिए उपयोग होने वाले एल्गोरिदम को निर्दिष्ट करने की अनुमति देती है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [compression_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/compression_type/) प्रॉपर्टी को `CCITT4` या `CCITT3` पर सेट किया गया हो।

{{% alert color="info" title="Note" %}}
[TiffOptions.bw_conversion_mode] एक एक्सपोर्ट‑लेवल सेटिंग है जो संपूर्ण TIFF इमेज के लिए पिक्सेल‑कनवर्ज़न एल्गोरिदम चुनती है। जब काली‑सफ़ेद डिस्प्ले मोड सक्रिय हो, तो किसी व्यक्तिगत आकार को कैसे दिखाना है, यह निर्धारित करने के लिए [Shape.black_white_mode] उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

This Python code demonstrates how to convert the colored slide to a black-and-white TIFF:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

परिणाम:

![काले‑सफ़ेद TIFF](TIFF_black_and_white.png)

## **प्रेज़ेंटेशन को कस्टम आकार के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों के साथ TIFF इमेज चाहिए, तो आप इच्छित मानों को [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) में उपलब्ध प्रॉपर्टीज़ का उपयोग करके सेट कर सकते हैं। उदाहरण के तौर पर, [image_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/image_size/) प्रॉपर्टी आपको परिणामस्वरूप इमेज का आकार निर्धारित करने की अनुमति देती है।

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Presentation क्लास को इंस्टैंटिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # संकुचन प्रकार सेट करें।
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    संकुचन प्रकार:
        Default - डिफ़ॉल्ट संकुचन योजना (LZW) निर्दिष्ट करता है।
        None - कोई संकुचन नहीं निर्दिष्ट करता है।
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

    # निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **प्रेज़ेंटेशन को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास की [pixel_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/pixel_format/) प्रॉपर्टी का उपयोग करके, आप परिणामस्वरूप TIFF इमेज के लिए अपनी इच्छित पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

```py
import aspose.slides as slides

# Presentation क्लास को इंस्टैंटिएट करें जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
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

    # निर्दिष्ट पिक्सेल फ़ॉर्मेट के साथ प्रस्तुति को TIFF के रूप में सहेजें।
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="info" %}}
Aspose की [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रस्तुति के बजाय एकल स्लाइड को TIFF में बदल सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेजेज़ में बदलने की अनुमति देता है।

**क्या प्रस्तुति को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या PowerPoint एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स स्लाइड्स को TIFF में बदलते समय संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर इमेज फ़ॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं होते; केवल स्लाइड्स के स्थिर स्नैपशॉट निर्यात किए जाते हैं।