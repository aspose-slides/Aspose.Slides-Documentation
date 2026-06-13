---
title: Python का उपयोग करके प्रस्तुतियों में SmartArt ग्राफिक्स प्रबंधित करें
linktitle: SmartArt ग्राफिक्स
type: docs
weight: 20
url: /hi/python-net/manage-smartart-shape/
keywords:
- SmartArt ऑब्जेक्ट
- SmartArt ग्राफिक
- SmartArt शैली
- SmartArt रंग
- SmartArt बनाएं
- SmartArt जोड़ें
- SmartArt संपादित करें
- SmartArt बदलें
- SmartArt तक पहुंचें
- SmartArt लेआउट प्रकार
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET के माध्यम से Python में PowerPoint SmartArt निर्माण, संपादन और शैली को स्वचालित करें, जिसमें संक्षिप्त कोड उदाहरण और प्रदर्शन-केंद्रित मार्गदर्शन शामिल है।"
---
## **अवलोकन**

Aspose.Slides आपको प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों में SmartArt ग्राफ़िक्स बनाने और प्रबंधित करने की अनुमति देता है। यह लेख बताता है कि कैसे एक SmartArt आकार को स्लाइड में जोड़ा जाए, मौजूदा SmartArt आकारों तक पहुंचें, विशिष्ट लेआउट प्रकार द्वारा SmartArt खोजें, और SmartArt शैली या रंग शैली बदल कर उसके दृश्य रूप को अपडेट करें।

उदाहरण दिखाते हैं कि प्रस्तुति स्लाइड के आकार संग्रह के माध्यम से SmartArt आकारों के साथ कैसे काम किया जाए, यह जांचें कि कोई आकार SmartArt है या नहीं, और फिर उसकी गुणों को संशोधित या निरीक्षण करें।

## **SmartArt आकार बनाएं**

Aspose.Slides for Python via .NET आपको शून्य से स्लाइड में कस्टम SmartArt आकार जोड़ने की अनुमति देता है। API इसे आसान बनाता है। एक स्लाइड में SmartArt आकार जोड़ने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा लक्षित स्लाइड प्राप्त करें।
3. एक SmartArt आकार जोड़ें, उसके लेआउट प्रकार का उल्लेख करते हुए।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Presentation वर्ग का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # प्रस्तुति स्लाइड तक पहुंचें।
    slide = presentation.slides[0]
    # SmartArt आकार जोड़ें।
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्लाइड पर SmartArt आकारों तक पहुंच**

निम्नलिखित कोड दिखाता है कि स्लाइड पर SmartArt आकारों तक कैसे पहुंचा जाए। यह नमूना स्लाइड पर प्रत्येक आकार पर इटररेट करता है और जांचता है कि क्या वह एक [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) ऑब्जेक्ट है।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("SmartArt.pptx") as presentation:
    # पहली स्लाइड पर प्रत्येक आकार के माध्यम से इटररेट करें।
    for shape in presentation.slides[0].shapes:
        # जांचें कि आकार SmartArt आकार है या नहीं।
        if isinstance(shape, smartart.SmartArt):
            # आकार का नाम प्रिंट करें।
            print("Shape name:", shape.name)
```

## **निर्दिष्ट लेआउट प्रकार के साथ SmartArt आकारों तक पहुंच**

निम्न उदाहरण दिखाता है कि कैसे निर्दिष्ट लेआउट प्रकार वाले SmartArt आकार तक पहुंचा जाए। ध्यान रखें कि आप SmartArt के लेआउट प्रकार को नहीं बदल सकते—यह केवल‑पढ़ने योग्य है और आकार बनते समय सेट हो जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाकर उस प्रस्तुति को लोड करें जिसमें SmartArt आकार हो।
2. इंडेक्स द्वारा पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार पर इटररेट करें।
4. जांचें कि क्या वह आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) ऑब्जेक्ट है।
5. यदि SmartArt आकार का लेआउट प्रकार आपके आवश्यक प्रकार से मेल खाता है, तो आवश्यक कार्य करें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # पहली स्लाइड पर प्रत्येक आकार के माध्यम से इटररेट करें।
    for shape in presentation.slides[0].shapes:
        # जांचें कि आकार SmartArt आकार है या नहीं।
        if isinstance(shape, smartart.SmartArt):
            # SmartArt लेआउट प्रकार जांचें।
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **SmartArt आकार शैली बदलें**

निम्न उदाहरण दिखाता है कि SmartArt आकारों को कैसे खोजें और उनकी शैली कैसे बदलें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाकर उस फ़ाइल को लोड करें जिसमें SmartArt आकार(ों) हों।
2. इंडेक्स द्वारा पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार पर इटररेट करें।
4. निर्दिष्ट शैली वाले SmartArt आकार को खोजें।
5. नए शैली को SmartArt आकार को असाइन करें।
6. प्रस्तुति को सहेजें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # पहली स्लाइड पर प्रत्येक आकार के माध्यम से इटररेट करें।
    for shape in presentation.slides[0].shapes:
        # जांचें कि आकार SmartArt आकार है या नहीं।
        if isinstance(shape, smartart.SmartArt):
            # SmartArt शैली जांचें।
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # SmartArt शैली बदलें।
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt आकारों की रंग शैली बदलें**

यह उदाहरण दिखाता है कि SmartArt आकार की रंग शैली कैसे बदलें। नमूना कोड निर्दिष्ट रंग शैली वाले SmartArt आकार को ढूंढ़ता है और उसे अपडेट करता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाकर उस प्रस्तुति को लोड करें जिसमें SmartArt आकार(ों) हों।
2. इंडेक्स द्वारा पहली स्लाइड का संदर्भ प्राप्त करें।
3. पहली स्लाइड पर प्रत्येक आकार पर इटररेट करें।
4. जांचें कि क्या वह आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) ऑब्जेक्ट है।
5. निर्दिष्ट रंग शैली वाले SmartArt आकार को लोकेट करें।
6. उस SmartArt आकार के लिए नई रंग शैली सेट करें।
7. प्रस्तुति को सहेजें।

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # पहली स्लाइड पर प्रत्येक आकार के माध्यम से इटररेट करें।
    for shape in presentation.slides[0].shapes:
        # जांचें कि आकार SmartArt आकार है या नहीं।
        if isinstance(shape, smartart.SmartArt):
            # रंग प्रकार जांचें।
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # रंग प्रकार बदलें।
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # प्रस्तुति सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I animate SmartArt as a single object?**  
हां। SmartArt एक आकार है, इसलिए आप [standard animations](/slides/hi/python-net/powerpoint-animation/) को एनीमेशन API के माध्यम से (प्रवेश, निकास, जोर, मोशन पाथ) अन्य आकारों की तरह लागू कर सकते हैं।

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**  
Alternative Text (AltText) सेट करें और उसका उपयोग करके उस मान द्वारा आकार को खोजें—यह लक्ष्य आकार को ढूंढ़ने का अनुशंसित तरीका है।

**Can I group SmartArt with other shapes?**  
हां। आप SmartArt को अन्य आकारों (चित्र, तालिकाएँ आदि) के साथ समूहित कर सकते हैं और फिर [manipulate the group](/slides/hi/python-net/group/) कर सकते हैं।

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**  
आकार का थंबनेल/छवि निर्यात करें; लाइब्रेरी [render individual shapes](/slides/hi/python-net/create-shape-thumbnails/) को रास्टर फ़ाइलों (PNG/JPG/TIFF) में बना सकती है।

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**  
हां। रेंडरिंग इंजन [PDF export](/slides/hi/python-net/convert-powerpoint-to-pdf/) के लिए उच्च सटीकता लक्षित करता है, जिसमें गुणवत्ता और संगतता विकल्पों की विविधता होती है।