---
title: Python via Java में प्रस्तुति आकृतियों के थंबनेल बनाएं
linktitle: आकृति थंबनेल
type: docs
weight: 70
url: /hi/python-java/create-shape-thumbnails/
keywords:
- आकृति थंबनेल
- आकृति छवि
- आकृति रेंडर
- आकृति रेंडरिंग
- विजुअल सीमाएँ
- आकृति सीमाएँ
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PowerPoint स्लाइड्स से उच्च गुणवत्ता वाले आकृति थंबनेल जनरेट करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Python via Java का उपयोग प्रस्तुतिकरण फ़ाइलें बनाने के लिए किया जा सकता है जहाँ प्रत्येक पृष्ठ एक स्लाइड के अनुरूप होता है। स्लाइड्स को Microsoft PowerPoint से खोलकर देखा जा सकता है। हालांकि, कभी‑कभी डेवलपर्स को आकृतियों की छवियों को अलग से छवि दर्शक में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides for Python via Java उन्हें स्लाइड आकृति के थंबनेल छवियाँ उत्पन्न करने में मदद करता है।

यह लेख विभिन्न तरीकों से आकृति थंबनेल उत्पन्न करने की प्रक्रिया बताता है:

- एक स्लाइड के भीतर आकृति थंबनेल उत्पन्न करना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड आकृति का थंबनेल उत्पन्न करना।
- आकृति के प्रदर्शन की सीमा के भीतर थंबनेल उत्पन्न करना।

## **स्लाइड से आकृति थंबनेल उत्पन्न करें**
Aspose.Slides for Python via Java का उपयोग करके किसी भी स्लाइड से आकृति थंबनेल उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड पर किसी आकृति का [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) डिफ़ॉल्ट स्केल पर प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के छवि स्वरूप में सहेजें।

यह नमूना कोड दिखाता है कि स्लाइड से आकृति थंबनेल कैसे उत्पन्न किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# एक Presentation क्लास का इंस्टेंस बनाएं जो प्रस्तुति फ़ाइल को दर्शाता है।
presentation = Presentation("Thumbnail.pptx")
try:
    # पूरा-स्केल छवि बनाएं।
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें।
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ थंबनेल उत्पन्न करें**
Aspose.Slides for Python via Java का उपयोग करके स्लाइड की आकृति थंबनेल उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड पर किसी आकृति का [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) उपयोगकर्ता‑परिभाषित आयामों के साथ प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के छवि स्वरूप में सहेजें।

यह नमूना कोड दिखाता है कि परिभाषित स्केलिंग फ़ैक्टर के आधार पर आकृति थंबनेल कैसे उत्पन्न किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं।
presentation = Presentation("Thumbnail.pptx")
try:
    # दोनों दिशाओं में 2 के फ़ैक्टर से स्केल की गई छवि बनाएं।
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # PNG फ़ॉर्मेट में छवि को डिस्क पर सहेजें।
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **सीमा‑आधारित आकृति प्रदर्शन थंबनेल बनाएं**
यह विधि डेवलपर्स को आकृति के प्रदर्शन की सीमा के भीतर थंबनेल उत्पन्न करने की अनुमति देती है, जिसमें सभी आकृति प्रभावों को ध्यान में रखा जाता है। उत्पन्न किया गया थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित रहता है। किसी स्लाइड आकृति का थंबनेल उसकी प्रस्तुति सीमा के भीतर उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स से स्लाइड का संदर्भ प्राप्त करें।
1. संदर्भित स्लाइड पर आकृति की प्रस्तुति सीमा का उपयोग करके थंबनेल छवि प्राप्त करें।
1. थंबनेल छवि को अपनी पसंद के छवि स्वरूप में सहेजें।

ऊपर दिए गए चरणों के आधार पर यह नमूना कोड है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं।
presentation = Presentation("Thumbnail.pptx")
try:
    # पूर्ण-स्केल छवि बनाएं।
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # PNG फ़ॉर्मेट में छवि को डिस्क पर सहेजें।
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **आकृति की वास्तविक दृश्य सीमा प्राप्त करें**

[Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) की फ्रेम गुण—उसके [getX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getWidth) और [getHeight](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getHeight) मेथड—प्रस्तुति मॉडल में संग्रहीत आयत का वर्णन करते हैं। वास्तविक रूप से रेंडर किया गया कंटेंट इस फ्रेम से बाहर भी जा सकता है या एक अलग अक्ष‑सुधारित आयत ले सकता है। घूर्णन, रूपरेखा, तीर सिरे, टेक्स्ट लेआउट व ओवरफ़्लो, जनरेटेड SmartArt ज्योमेट्री, और अन्य रेंडरिंग प्रभाव सभी कब्ज़ा किए गए क्षेत्र को बदल सकते हैं।

[Shape.getVisualBounds](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getVisualBounds) का उपयोग करके आप बिना चित्र बनाए उस कब्ज़ा किए गए क्षेत्र की गणना कर सकते हैं। यह मेथड स्लाइड निर्देशांक में एक [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) लौटाता है। लौटाई गई आयत स्लाइड तक क्लिप नहीं की गई है, इसलिए जब कंटेंट स्लाइड मूल बिंदु से बाहर जाता है तो इसके निर्देशांक नकारात्मक हो सकते हैं।

निम्न उदाहरण फ्रेम और दृश्य सीमाओं को प्राप्त करके तुलना करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

उसी [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) का उपयोग निकटवर्ती आकृतियों को बाएँ, दाएँ, ऊपर या नीचे किनारे से संरेखित करने, जेनरेटेड लेआउट में पर्याप्त जगह आरक्षित करने, या अनुमत क्षेत्र से बाहर के कंटेंट का पता लगाने में किया जा सकता है। दृश्य सीमाएँ विशेष रूप से SmartArt, टेक्स्ट बॉक्स, तीर, चित्र, घुमाई गई आकृतियों, और समूह आकृतियों के लिए उपयोगी होती हैं, जहाँ संग्रहीत फ्रेम पूरी रेंडर हुई परिणाम को नहीं दर्शाता।

लेआउट या वैधता के लिए आपको निर्देशांक चाहिए और bitmap नहीं चाहिए तो [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getVisualBounds) का उपयोग करें। जब आपको आकृति को रेंडर करना हो तो [Shape.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapethumbnailbounds/) के साथ, [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapethumbnailbounds/#Shape) आकृति की सीमाओं से, रूपरेखा सेटिंग्स सहित, छवि आकार देता है, जबकि [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapethumbnailbounds/#Appearance) आकृति की प्रस्तुति से आकार देता है और परिणाम को स्लाइड की सीमाओं तक सीमित करता है। इसके विपरीत, [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getVisualBounds) केवल गणना की गई आयत लौटाता है और उसे स्लाइड तक क्लिप नहीं करता।

## **FAQ**

**आकृति थंबनेल सहेजते समय कौन‑से छवि स्वरूप उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/python-java/aspose.slides/imageformat/), और अन्य। आकृतियों को [वेектор SVG के रूप में निर्यात किया जा सकता है](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#writeAsSvgToBytes) जब आप आकृति की सामग्री को SVG के रूप में सहेजते हैं।

**थंबनेल रेंडर करते समय Shape और Appearance सीमाओं में क्या अंतर है?**

`Shape` आकृति की ज्योमेट्री का उपयोग करता है; `Appearance` [visual effects](/slides/hi/python-java/shape-effect/) (छाया, चमक आदि) को ध्यान में रखता है।

**यदि कोई आकृति छुपी हुई के रूप में चिह्नित है तो क्या यह अभी भी थंबनेल के रूप में रेंडर होगी?**

छुपी हुई आकृति मॉडल का हिस्सा बनी रहती है और रेंडर की जा सकती है; छुपा फ़्लैग स्लाइड‑शो प्रदर्शन को प्रभावित करता है लेकिन आकृति की छवि उत्पन्न करने को नहीं रोकता।

**क्या समूह आकृतियाँ, चार्ट, SmartArt, और अन्य जटिल वस्तुएँ समर्थित हैं?**

हां। कोई भी वस्तु जो [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) के रूप में प्रतिनिधित्व करती है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) शामिल हैं) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑स्थापित फ़ॉन्ट थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हां। आपको [आवश्यक फ़ॉन्ट प्रदान करने चाहिए](/slides/hi/python-java/custom-font/) (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करें](/slides/hi/python-java/font-substitution/)) ताकि अनपेक्षित फ़ॉलबैक और टेक्स्ट रिफ्लो से बचा जा सके।