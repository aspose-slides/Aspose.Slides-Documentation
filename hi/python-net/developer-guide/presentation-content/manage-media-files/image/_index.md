---
title: "PowerPoint में Python के साथ छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/python-net/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python द्वारा .NET के माध्यम से PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइल, इंटरनेट या अन्य स्रोतों से चित्र स्लाइड्स पर सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको कई तरीकों से स्लाइड्स पर छवियां जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="primary" %}}
Aspose मुफ्त रूपांतरक प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से शीघ्रता से प्रस्तुतियां बनाने देते हैं।
{{% /alert %}}

{{% alert title="Info" color="info" %}}
यदि आप छवि को एक फ्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप आकार बदलने या प्रभाव लागू करने जैसी मानक स्वरूपण विकल्पों का उपयोग करने की योजना बना रहे हैं—तो देखें [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/hi/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
आप छवि और प्रस्तुति I/O ऑपरेशनों का उपयोग करके छवियों को स्वरूपों के बीच परिवर्तित कर सकते हैं। इन पृष्ठों को देखें: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/python-net/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-png/); परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-svg/); और परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF आदि लोकप्रिय स्वरूपों में छवियों के साथ काम करने का समर्थन करता है।

## **स्थानी रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर से एक या अधिक छवियों को प्रस्तुति की स्लाइड में जोड़ सकते हैं। निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप उसे सीधे वेब से सम्मिलित कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि URL से छवि को स्लाइड में कैसे जोड़ें:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # कच्चे छवि बाइट्स डाउनलोड करें।
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड मास्टर में छवियों को जोड़ें**

स्लाइड मास्टर शीर्ष-स्तर की स्लाइड है जो सभी नीचे की स्लाइड्स के लिए जानकारी—थीम, लेआउट आदि—को संग्रहित और नियंत्रित करता है। जब आप स्लाइड मास्टर में एक छवि जोड़ते हैं, तो वह छवि उस मास्टर का उपयोग करने वाली प्रत्येक स्लाइड पर दिखाई देती है।

निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड पृष्ठभूमि के रूप में छवियां जोड़ें**

आप एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/python-net/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) वर्ग का उपयोग करके जोड़ा जा सकता है। परिणामस्वरूप SVG छवि को फिर प्रस्तुति की इमेज कलेक्शन में जोड़ा जा सकता है और एक चित्र फ्रेम बनाने के लिए उपयोग किया जा सकता है।

निम्नलिखित Python उदाहरण एक स्व-समाहित SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, शैलियां और अन्य संसाधन सीधे SVG सामग्री में स्थित होते हैं।

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG को आकारों के सेट में परिवर्तित करें**

Aspose.Slides SVG को आकारों के एक सेट में इस प्रकार परिवर्तित करता है जो PowerPoint के SVG हैंडलिंग के समान है।

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) वर्ग में [add_group_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_group_shape/) विधि के एक ओवरलोड द्वारा प्रदान की जाती है जो प्रथम तर्क के रूप में एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) लेती है।

निम्नलिखित नमूना कोड दिखाता है कि SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित किया जाए।

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG फ़ाइल की सामग्री पढ़ें।
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # एक SvgImage ऑब्जेक्ट बनाएं।
        svg_image = slides.SvgImage(svg_content)

        # स्लाइड का आकार प्राप्त करें।
        slide_size = presentation.slide_size.size

        # SVG छवि को आकारों के समूह में परिवर्तित करें और इसे स्लाइड के आकार के अनुसार स्केल करें।
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # प्रस्तुति को PPTX प्रारूप में सहेजें।
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड्स में EMF के रूप में छवियां जोड़ें**

Aspose.Slides for Python आपको Enhanced Metafile (EMF) छवियों को प्रस्तुतियों में सम्मिलित करने की अनुमति देता है।

निम्नलिखित Python उदाहरण इसे प्रदर्शित करता है:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **छवि संग्रह में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों को बदलने की अनुमति देता है, जिसमें स्लाइड आकारों द्वारा उपयोग की गई छवियां भी शामिल हैं। यह अनुभाग संग्रह में छवियों को अपडेट करने के कई तरीकों को रेखांकित करता है। API सहज विधियां प्रदान करता है ताकि आप किसी छवि को कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) इंस्टेंस, या संग्रह में पहले से मौजूद दूसरी छवि से बदल सकें।

इन चरणों का पालन करें:

1. छवियों वाले प्रस्तुति को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का उपयोग करके लोड करें।
2. फ़ाइल से नई छवि को बाइट ऐरे में लोड करें।
3. बाइट ऐरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. वैकल्पिक रूप से, छवि को एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. या लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Presentation क्लास को इंस्टैंसिएट करें जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
with slides.Presentation("sample.pptx") as presentation:

    # पहला तरीका।
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # दूसरा तरीका।
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # तीसरा तरीका।
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरक के साथ, आप आसानी से पाठ को एनिमेट कर सकते हैं और पाठ से GIF बना सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इन्सर्ट करने के बाद मूल छवि रिज़ॉल्यूशन अपरिवर्तित रहता है?**

हाँ। मूल पिक्सेल सुरक्षित रखे जाते हैं, लेकिन अंतिम दिखावट इस बात पर निर्भर करती है कि स्लाइड पर [picture](/slides/hi/python-net/picture-frame/) कैसे स्केल किया गया है और सहेजते समय किस भी संपीड़न लागू किया गया है।

**दसियों स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति के इमेज कलेक्शन में इसे बदलें—अपडेट्स उन सभी तत्वों तक पहुँचेंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकारों में परिवर्तित किया जा सकता है?**

हाँ। आप SVG को आकारों के समूह में परिवर्तित कर सकते हैं, जिससे व्यक्तिगत भाग मानक आकार प्रॉपर्टीज़ के साथ संपादन योग्य हो जाते हैं।

**मैं कैसे एक ही समय में कई स्लाइड्स की पृष्ठभूमि के रूप में चित्र सेट कर सकता हूँ?**

[इमेज को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/python-net/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में ले लेंगी।

**कई चित्रों के कारण प्रस्तुति बहुत बड़ी होने से कैसे बचूँ?**

डुप्लिकेट के बजाय एक ही इमेज संसाधन का पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो दोहराए गए ग्राफिक्स को मास्टर पर रखें।