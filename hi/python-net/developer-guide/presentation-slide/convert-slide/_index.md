---
title: PowerPoint स्लाइड्स को Python में इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/python-net/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड को इमेज में बदलें
- स्लाइड को इमेज के रूप में निर्यात करें
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से इमेज
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET का उपयोग करके PowerPoint और OpenDocument स्लाइड्स को विभिन्न फॉर्मैट्स में बदलना सीखें। PPTX और ODP स्लाइड्स को BMP, PNG, JPEG, TIFF और अधिक में आसानी से निर्यात करें, उच्च गुणवत्ता वाले परिणामों के साथ।"
---
## **परिचय**

Aspose.Slides for Python via .NET आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फॉर्मैट्स जैसे BMP, PNG, JPG (JPEG), GIF आदि में बदलने में सक्षम बनाता है।

स्लाइड को इमेज में बदलने के लिए, निम्नलिखित कदम उठाएँ:

1. वांछित रूपांतरण सेटिंग्स निर्धारित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, उपयोग करके:
    - [TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास, या
    - [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/) क्लास।
2. स्लाइड इमेज बनाने के लिए, [Slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/) क्लास की `get_image` मेथड को कॉल करें।

In Aspose.Slides for Python via .NET, [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) एक क्लास है जो आपको पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की अनुमति देती है। आप इस क्लास के इंस्टेंस का उपयोग करके इमेज को विभिन्न फॉर्मैट्स (BMP, JPG, PNG, आदि) में सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदल कर इमेज को JPEG या किसी अन्य पसंदीदा फॉर्मैट में सहेज सकते हैं।

यह Python कोड दर्शाता है कि कैसे प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में बदलें और फिर इमेज को PNG फॉर्मैट में सहेजें:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति में पहली स्लाइड को बिटमैप में बदलें।
    with presentation.slides[0].get_image() as image:
        # इमेज को PNG फॉर्मैट में सहेजें।
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में बदलें**

आपको निश्चित आकार की इमेज चाहिए हो सकती है। [get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) के ओवरलोड का उपयोग करके, आप स्लाइड को निर्दिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ इमेज में बदल सकते हैं।

यह नमूना कोड दर्शाता है कि इसे कैसे करना है:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    with presentation.slides[0].get_image(image_size) as image:
        # इमेज को JPEG फॉर्मैट में सहेजें।
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **नोट्स और टिप्पणी के साथ स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो क्लासेस—[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) और [RenderingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/renderingoptions/)— प्रदान करता है जो प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करती हैं। दोनों क्लासेस में `slides_layout_options` प्रॉपर्टी है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देती है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी इमेज में नोट्स और कमेंट्स की अपनी इच्छित स्थिति निर्दिष्ट कर सकते हैं।

यह Python कोड दर्शाता है कि नोट्स और कमेंट्स वाले स्लाइड को कैसे बदलें:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # नोट्स की स्थिति निर्धारित करें।
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # टिप्पणी की स्थिति निर्धारित करें।
    notes_comments_options.comments_area_width = 500                                       # टिप्पणी क्षेत्र की चौड़ाई निर्धारित करें।
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # टिप्पणी क्षेत्र के लिए रंग निर्धारित करें।

    # रेंडरिंग विकल्प बनाएं।
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # प्रस्तुति की पहली स्लाइड को इमेज में बदलें।
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # इमेज को GIF फॉर्मैट में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-से-इमेज रूपांतरण प्रक्रिया में, [notes_position](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) प्रॉपर्टी को `BOTTOM_FULL` पर सेट नहीं किया जा सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF Options का उपयोग करके स्लाइड्स को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/tiffoptions/) क्लास आपको आकार, रेज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर्स निर्दिष्ट करके परिणामी TIFF इमेज पर अधिक नियंत्रण देती है।

यह Python कोड एक रूपांतरण प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग 300 DPI रेज़ॉल्यूशन और 2160 × 2800 आकार की ब्लैक‑एंड‑व्हाइट इमेज आउटपुट करने के लिए किया जाता है:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("sample.pptx") as presentation:
    # प्रस्तुति से पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # इमेज का आकार निर्धारित करें।
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # पिक्सेल फॉर्मैट निर्धारित करें (काला और सफेद)।
    options.dpi_x = 300                                                        # क्षैतिज रेज़ॉल्यूशन निर्धारित करें।
    options.dpi_y = 300                                                        # ऊर्ध्वाधर रेज़ॉल्यूशन निर्धारित करें।

    # निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
    with slide.get_image(options) as image:
        # इमेज को TIFF फॉर्मैट में सहेजें।
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति कई इमेजों की श्रृंखला में बदल जाती है।

यह नमूना कोड दर्शाता है कि Python में प्रस्तुति की सभी स्लाइड्स को इमेज में कैसे बदलें:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # प्रस्तुति को स्लाइड दर स्लाइड इमेज में रेंडर करें।
    for i, slide in enumerate(presentation.slides):
        # छिपी स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
        if slide.hidden:
            continue

        # स्लाइड को इमेज में बदलें।
        with slide.get_image(scale_x, scale_y) as image:
            # इमेज को JPEG फॉर्मैट में सहेजें।
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="warning" %}} 
प्रस्तुति स्लाइड्स को इमेज में बदलते समय रंगीन इमोजी को सही ढंग से रेंडर करने के लिए, प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट को उस सिस्टम पर स्थापित और उपलब्ध होना चाहिए जहाँ रूपांतरण हो रहा है। उदाहरण के लिए, यदि प्रस्तुति **Segoe UI Emoji** फ़ॉन्ट का उपयोग करती है और यह फ़ॉन्ट नहीं है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स के रेंडरिंग को सपोर्ट करता है?**

नहीं, `get_image` मेथड केवल स्लाइड की एक स्थैतिक इमेज सहेजता है, जिसमें एनीमेशन नहीं होते।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि उन्हें प्रोसेसिंग लूप में शामिल किया गया हो।

**क्या इमेज को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय शैडो, ट्रांसपेरेंसी और अन्य ग्राफिक इफ़ेक्ट्स के रेंडरिंग का समर्थन करता है।