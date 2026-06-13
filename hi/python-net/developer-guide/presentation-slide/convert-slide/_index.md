---
title: PowerPoint स्लाइड्स को Python में छवियों में बदलें
linktitle: स्लाइड से छवि
type: docs
weight: 41
url: /hi/python-net/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड को छवि में बदलें
- स्लाइड को छवि के रूप में निर्यात करें
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड से छवि
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स को विभिन्न प्रारूपों में बदलना सीखें। PPTX और ODP स्लाइड्स को BMP, PNG, JPEG, TIFF इत्यादि में उच्च-गुणवत्ता के परिणामों के साथ आसानी से निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न चित्र प्रारूपों जैसे BMP, PNG, JPG (JPEG), GIF और अन्य में बदलने में सक्षम बनाता है।

स्लाइड को छवि में बदलने के लिए, निम्नलिखित चरणों का पालन करें:

1. वांछित परिवर्तन सेटिंग्स को निर्धारित करें और उन स्लाइड्स का चयन करें जिन्हें आप निर्यात करना चाहते हैं, इसके लिए उपयोग करें:
    - [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास, या
    - [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/) क्लास।
2. स्लाइड छवि उत्पन्न करने के लिए [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) क्लास की `get_image` विधि को कॉल करें।

Aspose.Slides for Python via .NET में, [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) एक क्लास है जो पिक्सेल डेटा द्वारा परिभाषित छवियों के साथ काम करने की अनुमति देती है। आप इस क्लास की एक इंस्टेंस का उपयोग करके BMP, JPG, PNG आदि जैसे विभिन्न प्रारूपों में छवियों को सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में छवियों को सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर फिर छवि को JPEG या किसी अन्य इच्छित प्रारूप में सहेज सकते हैं।

यह Python कोड प्रदर्शित करता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG प्रारूप में छवि को कैसे सहेजें:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति में पहली स्लाइड को बिटमैप में बदलें.
    with presentation.slides[0].get_image() as image:
        # छवि को PNG प्रारूप में सहेजें.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **कस्टम आकार के साथ स्लाइड्स को छवियों में बदलें**

आपको किसी निश्चित आकार की छवि चाहिए हो सकती है। [get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) की एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) वाले चित्र में बदल सकते हैं। 

यह नमूना कोड दर्शाता है कि यह कैसे किया जाता है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    with presentation.slides[0].get_image(image_size) as image:
        # छवि को JPEG प्रारूप में सहेजें।
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **नोट्स और कमेंट्स वाले स्लाइड्स को छवियों में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो क्लासें—[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) और [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/)— प्रदान करती है जो प्रस्तुति स्लाइड्स को छवियों में रेंडर करने को नियंत्रित करने देती हैं। दोनों क्लासों में `slides_layout_options` प्रॉपर्टी मौजूद है, जो स्लाइड को छवि में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देती है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी छवि में नोट्स और कमेंट्स की पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह Python कोड दर्शाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे बदला जाए:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # नोट्स की स्थिति निर्धारित करें।
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # टिप्पणियों की स्थिति निर्धारित करें।
    notes_comments_options.comments_area_width = 500                                       # टिप्पणियों क्षेत्र की चौड़ाई निर्धारित करें।
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # टिप्पणियों क्षेत्र का रंग निर्धारित करें।

    # रेंडरिंग विकल्प बनाएं।
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # प्रस्तुति की पहली स्लाइड को छवि में बदलें।
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # छवि को GIF प्रारूप में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड‑से‑छवि रूपांतरण प्रक्रिया में, [notes_position](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) प्रॉपर्टी को `BOTTOM_FULL` पर सेट नहीं किया जा सकता (नोट्स की स्थिति निर्धारित करने के लिए) क्योंकि नोट का पाठ बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट छवि आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास आपको आकार, रिज़ॉल्यूशन, रंग पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके परिणामी TIFF छवि पर अधिक नियंत्रण प्रदान करती है।

यह Python कोड एक रूपांतरण प्रक्रिया दर्शाता है जिसमें TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की काली‑सफ़ेद छवि उत्पन्न की जाती है:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("sample.pptx") as presentation:
    # प्रस्तुति से पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # आउटपुट TIFF छवि की सेटिंग्स कॉन्फ़िगर करें।
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # छवि का आकार निर्धारित करें।
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # पिक्सेल फ़ॉर्मेट निर्धारित करें (काले और सफेद)।
    options.dpi_x = 300                                                        # क्षैतिज रिज़ॉल्यूशन निर्धारित करें।
    options.dpi_y = 300                                                        # लंबवत रिज़ॉल्यूशन निर्धारित करें।

    # निर्दिष्ट विकल्पों के साथ स्लाइड को छवि में बदलें।
    with slide.get_image(options) as image:
        # छवि को TIFF प्रारूप में सहेजें।
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **सभी स्लाइड्स को छवियों में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को छवियों में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को छवियों की श्रृंखला में बदला जा सकता है।

यह नमूना कोड दर्शाता है कि Python में प्रस्तुति की सभी स्लाइड्स को छवियों में कैसे बदला जाए:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति को स्लाइड दर स्लाइड छवियों में रेंडर करें।
    for i, slide in enumerate(presentation.slides):
        # छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
        if slide.hidden:
            continue

        # स्लाइड को छवि में बदलें।
        with slide.get_image(scale_x, scale_y) as image:
            # छवि को JPEG प्रारूप में सहेजें।
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन्स के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `get_image` मेथड केवल स्लाइड की स्थिर छवि को सहेजता है, जिसमें एनीमेशन नहीं होते।

**क्या छिपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हाँ, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह ही प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या छवियों को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हाँ, Aspose.Slides स्लाइड्स को छवियों के रूप में सहेजते समय शैडो, ट्रांसपेरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।