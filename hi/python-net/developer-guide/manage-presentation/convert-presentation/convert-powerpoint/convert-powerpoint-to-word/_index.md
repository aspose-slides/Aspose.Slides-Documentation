---
title: Python में PowerPoint प्रस्तुतियों को Word दस्तावेज़ में परिवर्तित करें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint से DOCX
- OpenDocument से DOCX
- प्रस्तुति से DOCX
- स्लाइड से DOCX
- PPT से DOCX
- PPTX से DOCX
- ODP से DOCX
- PowerPoint से DOC
- OpenDocument से DOC
- प्रस्तुति से DOC
- स्लाइड से DOC
- PPT से DOC
- PPTX से DOC
- ODP से DOC
- PowerPoint से Word
- OpenDocument से Word
- प्रस्तुति से Word
- स्लाइड से Word
- PPT से Word
- PPTX से Word
- ODP से Word
- PowerPoint को परिवर्तित करें
- OpenDocument को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- ODP को परिवर्तित करें
- Python
- Aspose.Slides
description: "जाने कैसे आसानी से Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित किया जा सकता है। हमारा चरण-दर-चरण मार्गदर्शक नमूना Python कोड के साथ उन डेवलपर्स के लिए समाधान प्रदान करता है जो अपने दस्तावेज़ कार्यप्रवाह को सुव्यवस्थित करना चाहते हैं।"
---
## **अवलोकन**

यह लेख डेवलपर्स को Aspose.Slides for Python via .NET और Aspose.Words for Python via .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने के लिए एक समाधान प्रदान करता है। चरण-दर-चरण मार्गदर्शिका आपको रूपांतरण प्रक्रिया के हर चरण से गुजराती है।

## **प्रस्तुति को Word दस्तावेज़ में परिवर्तित करें**

PowerPoint या OpenDocument प्रस्तुति को Word दस्तावेज़ में परिवर्तित करने के लिए नीचे दिए गए निर्देशों का पालन करें:

1. इंस्टैंसिएट करें [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास और एक प्रस्तुति फ़ाइल लोड करें।
2. इंस्टैंसिएट करें [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) और [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) क्लासेज़ ताकि एक Word दस्तावेज़ उत्पन्न हो सके।
3. Word दस्तावेज़ के पृष्ठ आकार को प्रस्तुति के समान सेट करने के लिए [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) प्रॉपर्टी का उपयोग करें।
4. Word दस्तावेज़ में मार्जिन सेट करने के लिए [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) प्रॉपर्टी का उपयोग करें।
5. सभी प्रस्तुति स्लाइड्स को [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) प्रॉपर्टी का उपयोग करके पार करें।
    - `get_image` मेथड का उपयोग करके [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) क्लास से एक स्लाइड छवि बनाएं और उसे मेमोरी स्ट्रीम में सहेजें।
    - `insert_image` मेथड का उपयोग करके [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) क्लास से स्लाइड छवि को Word दस्तावेज़ में जोड़ें।
6. Word दस्तावेज़ को एक फ़ाइल में सहेजें।

मान लीजिए हमारे पास एक प्रस्तुति "sample.pptx" है जो इस प्रकार दिखती है:

![PowerPoint प्रस्तुति](PowerPoint.png)

निम्नलिखित Python कोड उदाहरण दिखाता है कि PowerPoint प्रस्तुति को Word दस्तावेज़ में कैसे परिवर्तित करें:

```py
import aspose.slides as slides
import aspose.words as words

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("sample.pptx") as presentation:

    # Document और DocumentBuilder ऑब्जेक्ट बनाएं।
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Word दस्तावेज़ में पृष्ठ आकार सेट करें।
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Word दस्तावेज़ में मार्जिन सेट करें।
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # सभी प्रस्तुति स्लाइड्स को पार करें।
    for slide in presentation.slides:

        # स्लाइड छवि उत्पन्न करें और इसे मेमोरी स्ट्रीम में सहेजें।
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # स्लाइड छवि को Word दस्तावेज़ में जोड़ें।
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Word दस्तावेज़ को फ़ाइल में सहेजें।
    document.save("output.docx")
```

परिणाम:

![Word दस्तावेज़](Word.png)

{{% alert color="primary" %}} 
PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने से क्या लाभ मिल सकता है, यह देखने के लिए हमारे [**ऑनलाइन PPT से Word कनवर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को आज़माएँ। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने के लिए कौन से घटक स्थापित करने की आवश्यकता है?**

आपको केवल अपने Python प्रोजेक्ट में [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) और [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) पैकेज जोड़ने की आवश्यकता है। दोनों पैकेज स्वतन्त्र API के रूप में कार्य करते हैं, और Microsoft Office स्थापित करने की कोई आवश्यकता नहीं है।

**क्या सभी PowerPoint और OpenDocument प्रस्तुति फ़ॉर्मेट समर्थित हैं?**

Aspose.Slides for Python .NET [सभी प्रस्तुति फ़ॉर्मेट का समर्थन करता है](/slides/hi/python-net/supported-file-formats/), जिसमें PPT, PPTX, ODP, और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। इससे सुनिश्चित होता है कि आप विभिन्न संस्करणों के Microsoft PowerPoint में बनाई गई प्रस्तुतियों पर काम कर सकते हैं।