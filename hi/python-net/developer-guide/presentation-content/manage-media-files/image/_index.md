---
title: Python के साथ PowerPoint में छवि प्रबंधन का अनुकूलन
linktitle: छवियों का प्रबंधन
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
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सहज बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और रोचक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइल, इंटरनेट या अन्य स्रोतों से तस्वीरें स्लाइड पर सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides आपको कई तरीकों से स्लाइड में छवियां जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="primary" %}}
Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से जल्दी प्रस्तुतियां बनाने में मदद करते हैं।
{{% /alert %}}

{{% alert title="Info" color="info" %}}
यदि आप छवि को फ्रेम ऑब्जेक्ट के रूप में जोड़ना चाहते हैं—विशेषकर जब आप आकार बदलने या प्रभाव लागू करने जैसे मानक स्वरूपण विकल्पों का उपयोग करने की योजना बनाते हैं—देखें [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/hi/python-net/picture-frame/)।
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
आप छवियों को विभिन्न स्वरूपों के बीच बदलने के लिए छवि और प्रस्तुति I/O ऑपरेशन्स का उपयोग कर सकते हैं। इन पृष्ठों को देखें: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/python-net/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/python-net/conversion/jpg-to-png/); परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/python-net/conversion/png-to-svg/); और परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/python-net/conversion/svg-to-png/)।
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF आदि जैसे लोकप्रिय स्वरूपों में छवियों के साथ काम करने का समर्थन करता है।

## **स्लाइड में स्थानीय रूप से संग्रहीत छवियां जोड़ें**

आप अपने कंप्यूटर से एक या अधिक छवियां प्रस्तुति में किसी स्लाइड में जोड़ सकते हैं। निम्नलिखित Python उदाहरण दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **वेब से छवियां स्लाइड में जोड़ें**

यदि आप जिस छवि को स्लाइड में जोड़ना चाहते हैं वह आपके कंप्यूटर पर उपलब्ध नहीं है, तो आप उसे सीधे वेब से सम्मिलित कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि URL से छवि को स्लाइड में कैसे जोड़ें:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड मास्टर में छवियां जोड़ें**

स्लाइड मास्टर शीर्ष‑स्तरीय स्लाइड है जो सभी नीचे की स्लाइड्स के लिए थीम, लेआउट आदि की जानकारी संग्रहीत और नियंत्रित करता है। जब आप एक छवि को स्लाइड मास्टर में जोड़ते हैं, तो वह छवि उस मास्टर को उपयोग करने वाली हर स्लाइड पर दिखाई देती है।

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

## **छवि को स्लाइड पृष्ठभूमि के रूप में सेट करें**

आप एक विशिष्ट स्लाइड या कई स्लाइडों की पृष्ठभूमि के रूप में छवि का उपयोग करना चाह सकते हैं। विस्तृत जानकारी के लिए देखें [Set an Image as the Background for a Slide](https://docs.aspose.com/slides/hi/python-net/presentation-background/#set-image-as-background-for-slide)।

## **प्रस्तुतियों में SVG जोड़ें**

आप किसी भी छवि को प्रस्तुति में सम्मिलित कर सकते हैं, इसके लिए [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास की [add_picture_frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_picture_frame/) विधि का उपयोग करें।

SVG से एक छवि ऑब्जेक्ट बनाने के लिए, इन चरणों का पालन करें:

1. एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) बनाकर उसे प्रस्तुति की इमेज कलेक्शन में जोड़ें।
2. [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) से एक [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) ऑब्जेक्ट बनाएं।
3. [PPImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ppimage/) का उपयोग करके एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) ऑब्जेक्ट बनाएं।

निम्नलिखित Python नमूना दिखाता है कि इन चरणों के साथ प्रस्तुति में SVG छवि कैसे जोड़ें:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # SVG फ़ाइल की सामग्री पढ़ें।
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # एक SvgImage ऑब्जेक्ट बनाएं।
        svg_image = slides.SvgImage(svg_content)

        # एक PPImage ऑब्जेक्ट बनाएं।
        pp_image = presentation.images.add_image(svg_image)

        # एक नया PictureFrame बनाएं।
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # प्रस्तुति को PPTX स्वरूप में सहेजें।
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG को आकारों के सेट में परिवर्तित करें**

Aspose.Slides SVG को ऐसे आकारों के सेट में परिवर्तित करता है जो PowerPoint के SVG हैंडलिंग के समान है।

![PowerPoint पॉपअप मेनू](img_01_01.png)

यह कार्यक्षमता [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) क्लास की [add_group_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_group_shape/) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो पहला आर्ग्यूमेंट के रूप में एक [SvgImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/svgimage/) लेता है।

नीचे दिया गया नमूना कोड दिखाता है कि SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित करें।

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG फ़ाइल सामग्री पढ़ें।
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # एक SvgImage ऑब्जेक्ट बनाएं।
        svg_image = slides.SvgImage(svg_content)

        # स्लाइड आकार प्राप्त करें।
        slide_size = presentation.slide_size.size

        # SVG छवि को आकारों के समूह में परिवर्तित करें और स्लाइड आकार के अनुसार स्केल करें।
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # प्रस्तुति को PPTX स्वरूप में सहेजें।
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड में EMF के रूप में छवियां जोड़ें**

Aspose.Slides for Python आपको प्रस्तुति में Enhanced Metafile (EMF) छवियां सम्मिलित करने की अनुमति देता है।

निम्नलिखित Python उदाहरण इसमें आपकी मदद करता है:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **छवि संग्रह में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों को बदलने देता है, जिसमें स्लाइड शेप्स द्वारा उपयोग की गई छवियां भी शामिल हैं। यह अनुभाग संग्रह में छवियों को अपडेट करने के कई तरीकों को बताता है। API सरल मेथड्स प्रदान करता है जिससे आप किसी छवि को कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) इंस्टेंस, या संग्रह में पहले से मौजूद दूसरी छवि से बदल सकते हैं।

इन चरणों का पालन करें:

1. प्रस्तुतिकरण को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उपयोग करके लोड करें जिसमें छवियां मौजूद हैं।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. वैकल्पिक रूप से, छवि को एक [IImage](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. या लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Presentation क्लास को इंस्टैंटिएट करें जो एक प्रस्तुति फ़ाइल को दर्शाता है।
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
Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर के साथ आप आसानी से पाठ को एनीमेट कर सकते हैं और पाठ से GIF बना सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मूल छवि रिज़ॉल्यूशन सम्मिलन के बाद बना रहता है?**

हां। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप इस बात पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/python-net/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कौन सा संपीड़न लागू किया गया है।

**एक ही लोगो को साथ में दर्जन भर स्लाइड पर बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति के इमेज कलेक्शन में बदलें—अपडेट उन सभी तत्वों तक पहुंचेगा जो उस संसाधन का उपयोग कर रहे हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकारों में बदला जा सकता है?**

हां। आप SVG को आकारों के एक समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं एक ही समय में कई स्लाइडों की पृष्ठभूमि के रूप में छवि कैसे सेट कर सकता हूं?**

[Assign the image as the background](/slides/hi/python-net/presentation-background/) को मास्टर स्लाइड या संबंधित लेआउट पर सेट करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइडें पृष्ठभूमि को विरासत में प्राप्त करेंगी।

**बहुत सारी छवियों के कारण प्रस्तुति का आकार "बैलूनिंग" से कैसे बचाएं?**

डुप्लिकेट्स की बजाय एक ही छवि संसाधन का पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो दोहराए जाने वाले ग्राफिक्स को मास्टर पर रखें।