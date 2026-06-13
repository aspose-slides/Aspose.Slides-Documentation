---
title: Python में प्रस्तुति शैलियों के थंबनेल बनाना
linktitle: Shape थंबनेल
type: docs
weight: 70
url: /hi/python-net/create-shape-thumbnails/
keywords:
- shape थंबनेल
- shape इमेज
- shape रेंडर
- shape रेंडरिंग
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument स्लाइड्स से उच्च-गुणवत्ता वाले shape थंबनेल बनाएं – प्रस्तुतियों के थंबनेल को आसानी से बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via .NET का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जिसमें प्रत्येक पृष्ठ एक स्लाइड होता है। आप प्रस्तुति फ़ाइल खोलकर इन स्लाइड्स को Microsoft PowerPoint में देख सकते हैं। हालांकि, डेवलपर्स को कभी‑कभी आकारों (shapes) की छवियों को अलग से एक इमेज व्यूअर में देखना पड़ सकता है। ऐसे मामलों में, Aspose.Slides स्लाइड आकारों के लिए थंबनेल छवियां बना सकता है। यह लेख इस सुविधा के उपयोग को समझाता है।

## **स्लाइड्स से Shape थंबनेल उत्पन्न करना**

जब आपको पूरे स्लाइड के बजाय किसी विशिष्ट ऑब्जेक्ट का पूर्वावलोकन चाहिए, तो आप व्यक्तिगत Shape के लिए थंबनेल रेंडर कर सकते हैं। Aspose.Slides आपको किसी भी Shape को इमेज के रूप में निर्यात करने की सुविधा देता है, जिससे हल्के‑फुल्के पूर्वावलोकन, आइकन या डाउनस्ट्रीम प्रोसेसिंग के लिए एसेट बनाना आसान हो जाता है।

किसी भी Shape से थंबनेल उत्पन्न करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी ID या इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. उस स्लाइड पर किसी Shape का संदर्भ प्राप्त करें।
1. Shape का थंबनेल इमेज रेंडर करें।
1. इच्छित फ़ॉर्मेट में थंबनेल इमेज सहेजें।

नीचे दिया गया उदाहरण Shape थंबनेल बनाता है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएँ।
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # डिफ़ॉल्ट स्केल के साथ एक इमेज बनाएँ।
    with shape.get_image() as thumbnail:
        # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **कस्टम स्केलिंग फ़ैक्टर के साथ थंबनेल उत्पन्न करना**

यह अनुभाग दिखाता है कि Aspose.Slides में उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ Shape थंबनेल कैसे उत्पन्न करें। स्केल को नियंत्रित करके आप थंबनेल आकार को पूर्वावलोकन, निर्यात या हाई‑DPI डिस्प्ले के अनुसार अनुकूलित कर सकते हैं।

किसी स्लाइड पर किसी भी Shape के लिए थंबनेल उत्पन्न करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी ID या इंडेक्स द्वारा स्लाइड प्राप्त करें।
1. उस स्लाइड पर लक्ष्य Shape प्राप्त करें।
1. निर्दिष्ट स्केल के साथ Shape का थंबनेल इमेज रेंडर करें।
1. इच्छित फ़ॉर्मेट में थंबनेल इमेज सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ थंबनेल बनाता है।

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएँ।
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # परिभाषित स्केल के साथ एक इमेज बनाएँ।
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Shape की Appearance बाउंड्स का उपयोग करके थंबनेल उत्पन्न करना**

यह अनुभाग दिखाता है कि Shape की Appearance बाउंड्स के भीतर थंबनेल कैसे उत्पन्न करें। यह सभी Shape प्रभावों को ध्यान में रखता है। उत्पन्न थंबनेल स्लाइड बाउंड्स द्वारा सीमित रहता है।

किसी भी स्लाइड Shape का थंबनेल उसके Appearance बाउंड्स के भीतर उत्पन्न करने के लिए:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उदाहरण बनाएँ।
1. उसकी ID या इंडेक्स द्वारा स्लाइड प्राप्त करें।
1. उस स्लाइड पर लक्ष्य Shape प्राप्त करें।
1. निर्दिष्ट बाउंड्स के साथ Shape का थंबनेल इमेज रेंडर करें।
1. इच्छित इमेज फ़ॉर्मेट में थंबनेल इमेज सहेजें।

नीचे दिया गया उदाहरण उपयोगकर्ता‑परिभाषित बाउंड्स के साथ थंबनेल बनाता है।

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएँ.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # appearance-बाउंड्स shape इमेज बनाएँ.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Shape थंबनेल सहेजते समय कौन से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/python-net/aspose.slides/imageformat/), और अन्य। Shapes को भी [exported as vector SVG](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/write_as_svg/) द्वारा SVG के रूप में सहेजा जा सकता है।

**थंबनेल रेंडर करते समय SHAPE और APPEARANCE बाउंड्स में क्या अंतर है?**

`SHAPE` shape की ज्यामिति का उपयोग करता है; `APPEARANCE` [visual effects](/slides/hi/python-net/shape-effect/) (छायाएं, चमक आदि) को ध्यान में रखता है।

**यदि किसी Shape को hidden के रूप में चिह्नित किया गया हो तो क्या होता है? क्या यह अभी भी थंबनेल के रूप में रेंडर होगा?**

एक hidden Shape मॉडल का भाग बना रहता है और रेंडर किया जा सकता है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन Shape की इमेज उत्पन्न होने से नहीं रोकता।

**क्या group shapes, charts, SmartArt, और अन्य जटिल ऑब्जेक्ट सपोर्टेड हैं?**

हां। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/python-net/aspose.slides.smartart/smartart/)) के रूप में प्रतिनिधित्व किया गया है, उसे थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम में इंस्टॉल किए गए फ़ॉन्ट्स टेक्स्ट Shape के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हां। आपको अनावश्यक फ़ॉन्ट फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचने के लिए [required fonts](/slides/hi/python-net/custom-font/) प्रदान करने चाहिए (या [configure font substitutions](/slides/hi/python-net/font-substitution/) करना चाहिए)।