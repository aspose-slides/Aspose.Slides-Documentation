---
title: Python में प्रस्तुति आकारों के थंबनेल बनाएं
linktitle: आकार थंबनेल
type: docs
weight: 70
url: /hi/python-net/create-shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- विजुअल सीमा
- आकार सीमा
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument स्लाइड्स से उच्च-गुणवत्ता वाले आकार थंबनेल बनाएं – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जिसमें प्रत्येक पृष्ठ एक स्लाइड होता है। आप प्रस्तुति फ़ाइल को खोलकर इन स्लाइड्स को Microsoft PowerPoint में देख सकते हैं। फिर भी, डेवलपर्स को कभी‑कभी आकारों की छवियों को अलग‑अलग इमेज व्यूअर में देखने की आवश्यकता पड़ सकती है। ऐसे मामलों में, Aspose.Slides स्लाइड आकारों के लिए थंबनेल छवियां उत्पन्न कर सकता है। यह लेख इस सुविधा के उपयोग की व्याख्या करता है।

## **स्लाइड्स से आकार थंबनेल उत्पन्न करें**

जब आपको पूरे स्लाइड के बजाय किसी विशिष्ट ऑब्जेक्ट का पूर्वावलोकन चाहिए, तो आप व्यक्तिगत आकार के लिए थंबनेल रेंडर कर सकते हैं। Aspose.Slides आपको किसी भी आकार को छवि में निर्यात करने की अनुमति देता है, जिससे हल्के पूर्वावलोकन, आइकन या डाउनस्ट्रीम प्रोसेसिंग के लिए एसेट बनाना आसान हो जाता है।

किसी भी आकार से थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके ID या इंडेक्स से स्लाइड का रेफ़रेंस प्राप्त करें।
1. उस स्लाइड पर किसी आकार का रेफ़रेंस प्राप्त करें।
1. आकार की थंबनेल छवि रेंडर करें।
1. थंबनेल छवि को वांछित फ़ॉर्मेट में सहेजें।

निचे दिया गया उदाहरण आकार का थंबनेल उत्पन्न करता है。

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # डिफ़ॉल्ट स्केल के साथ एक छवि बनाएं।
    with shape.get_image() as thumbnail:
        # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **कस्टम स्केलिंग फ़ैक्टर के साथ थंबनेल उत्पन्न करें**

यह भाग दिखाता है कि Aspose.Slides में उपयोगकर्ता‑निर्धारित स्केलिंग फ़ैक्टर के साथ आकार थंबनेल कैसे उत्पन्न किए जाएँ। स्केल को नियंत्रित करके आप थंबनेल आकार को पूर्वावलोकन, निर्यात या हाई‑DPI डिस्प्ले के अनुरूप समायोजित कर सकते हैं।

किसी स्लाइड पर किसी भी आकार के लिए थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके ID या इंडेक्स से स्लाइड प्राप्त करें।
1. उस स्लाइड पर लक्षित आकार प्राप्त करें।
1. निर्दिष्ट स्केल के साथ आकार की थंबनेल छवि रेंडर करें।
1. थंबनेल छवि को वांछित फ़ॉर्मेट में सहेजें।

निचे दिया गया उदाहरण उपयोगकर्ता‑निर्धारित स्केलिंग फ़ैक्टर के साथ थंबनेल उत्पन्न करता है。

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # परिभाषित स्केल के साथ एक छवि बनाएं।
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **आकार की अपीयरेंस बाउंड्स का उपयोग करके थंबनेल उत्पन्न करें**

यह भाग दिखाता है कि कैसे आकार की अपीयरेंस बाउंड्स के भीतर थंबनेल उत्पन्न किया जाए। यह सभी आकार प्रभावों को ध्यान में रखता है। उत्पन्न थंबनेल स्लाइड बाउंड्स द्वारा सीमित होता है।

आकार की अपीयरेंस बाउंड्स के भीतर किसी भी स्लाइड आकार का थंबनेल उत्पन्न करने के लिए:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. उसके ID या इंडेक्स से स्लाइड प्राप्त करें।
1. उस स्लाइड पर लक्षित आकार प्राप्त करें।
1. निर्दिष्ट बाउंड्स के साथ आकार की थंबनेल छवि रेंडर करें।
1. थंबनेल छवि को वांछित इमेज फ़ॉर्मेट में सहेजें।

निचे दिया गया उदाहरण उपयोगकर्ता‑निर्धारित बाउंड्स के साथ थंबनेल बनाता है।

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का इंस्टैंस बनाएं।
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # अपीयरेंस-बंधित आकार छवि बनाएं।
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **आकार की वास्तविक विज़ुअल बाउंड्स प्राप्त करें**

एक [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) के फ्रेम प्रॉपर्टी—`Shape.x`, `Shape.y`, `Shape.width`, और `Shape.height`—प्रस्तुति मॉडल में संग्रहीत आयत को दर्शाते हैं। वास्तविक रूप से रेंडर की गई सामग्री इस फ्रेम से बाहर तक विस्तारित हो सकती है या अलग अक्ष‑संकल्पित आयत में स्थित हो सकती है। रोटेशन, आउटलाइन, एरोहेड्स, टेक्स्ट लेआउट और ओवरफ़्लो, जेनरेटेड SmartArt जियोमेट्री, और अन्य रेंडरिंग प्रभाव सभी कब्ज़ा किए गए क्षेत्र को बदल सकते हैं।

[Shape.get_visual_bounds](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_visual_bounds/) का उपयोग करके बिना इमेज बनाए उस कब्ज़ा किए गए क्षेत्र की गणना करें। यह मेथड स्लाइड कोऑर्डिनेट्स में फ्लोटिंग‑पॉइंट आयत लौटाता है। लौटाई गई आयत स्लाइड तक क्लिप नहीं की गई है, इसलिए जब सामग्री स्लाइड मूल बिंदु से बाहर विस्तारित होती है तो इसके कोऑर्डिनेट नकारात्मक हो सकते हैं।

निचे दिया गया उदाहरण फ्रेम और विज़ुअल बाउंड्स को प्राप्त करके तुलना करता है：

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

उसी आयत का उपयोग निकटवर्ती आकारों को इसके `left`, `right`, `top` या `bottom` किनारे पर संरेखित करने, जेनरेटेड लेआउट में पर्याप्त जगह आरक्षित करने, या अनुमत क्षेत्र के बाहर की सामग्री का पता लगाने के लिए किया जा सकता है। विज़ुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, एरो, चित्र, घुमा हुए आकार और ग्रुप आकारों के लिए उपयोगी हैं, जहाँ संग्रहीत फ्रेम पूरी रेंडर्ड परिणाम को दर्शा नहीं सकता।

जब आपको लेआउट या वैधता के लिए कोऑर्डिनेट चाहिए और बिटमैप की आवश्यकता नहीं है तो [Shape.get_visual_bounds](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_visual_bounds/) का उपयोग करें। जब आपको आकार को रेंडर करना हो तो [Shape.get_image](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_image/) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapethumbnailbounds/) के साथ, `ShapeThumbnailBounds.SHAPE` आकार बाउंड्स, जिसमें आउटलाइन सेटिंग्स शामिल हैं, से इमेज का आकार तय करता है, जबकि `ShapeThumbnailBounds.APPEARANCE` आकार की अपीयरेंस से आकार तय करता है और परिणाम को स्लाइड बाउंड्स तक सीमित करता है। इसके विपरीत, `Shape.get_visual_bounds` केवल गणना की गई आयत लौटाता है और इसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल को सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imageformat/), और अन्य। आकारों को [वेक्टर SVG के रूप में निर्यात भी किया जा सकता है](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) SVG के रूप में आकार की सामग्री सहेजकर।

**थंबनेल रेंडर करते समय SHAPE और APPEARANCE बाउंड्स में क्या अंतर है?**

`SHAPE` आकार की जियोमेट्री का उपयोग करता है; `APPEARANCE` [visual effects](/slides/hi/python-net/shape-effect/) (छाया, चमक, आदि) को ध्यान में रखता है।

**यदि कोई आकार छिपा हुआ चिह्नित किया गया हो तो क्या होगा? क्या यह अभी भी थंबनेल के रूप में रेंडर होगा?**

छिपा हुआ आकार मॉडल का भाग बना रहता है और रेंडर किया जा सकता है; छिपा फ़्लैग स्लाइडशो डिस्प्ले को प्रभावित करता है लेकिन आकार की इमेज उत्पन्न करने से नहीं रोकता।

**क्या ग्रुप आकार, चार्ट, SmartArt और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**

हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) के रूप में दर्शाया गया है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/) शामिल हैं) थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल किए गए फ़ॉन्ट्स टेक्स्ट आकार थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हाँ। अनचाहे फ़ॉन्ट फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचने के लिए आपको [आवश्यक फ़ॉन्ट्स प्रदान करने](/slides/hi/python-net/custom-font/) (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करने](/slides/hi/python-net/font-substitution/)) चाहिए।