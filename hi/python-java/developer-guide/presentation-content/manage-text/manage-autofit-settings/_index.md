---
title: ऑटोफ़िट के साथ Python में अपनी प्रस्तुतियों को उन्नत बनाएं
linktitle: ऑटोफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/python-java/manage-autofit-settings/
keywords:
- टेक्स्ट बॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट छोटा करें
- टेक्स्ट रैप करें
- आकृति का आकार बदलें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में ऑटोफ़िट सेटिंग्स को प्रबंधित करना सीखें ताकि आप अपने PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट प्रदर्शन को अनुकूलित कर सकें और सामग्री की पठनीयता में सुधार कर सकें।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्ट बॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्ट बॉक्स के लिए **Resize shape to fit text** सेटिंग का उपयोग करता है—यह टेक्स्ट बॉक्स को स्वचालित रूप से री-साइज़ कर देता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो।

![PowerPoint में टेक्स्ट बॉक्स](textbox-in-powerpoint.png)

* जब टेक्स्ट बॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, तो PowerPoint स्वचालित रूप से टेक्स्ट बॉक्स को बड़ा कर देता है—ऊँचाई बढ़ाता है—ताकि वह अधिक टेक्स्ट रख सके।
* जब टेक्स्ट बॉक्स में टेक्स्ट छोटा या कम हो जाता है, तो PowerPoint स्वचालित रूप से टेक्स्ट बॉक्स को छोटा कर देता है—ऊँचाई घटाता है—अतिरिक्त स्थान हटाने के लिए।

PowerPoint में, ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो एक टेक्स्ट बॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं:

* **ऑटोफ़िट न करें**
* **अधिकतम होने पर टेक्स्ट छोटा करें**
* **आकृति का आकार टेक्स्ट के अनुसार बदलें**
* **आकृति में टेक्स्ट रैप करें।**

![ऑटोफ़िट विकल्प PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास के अंतर्गत कुछ प्रॉपर्टीज़—जो आपको प्रस्तुतियों में टेक्स्ट बॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देती हैं।

## **आकृति का आकार टेक्स्ट के अनुसार बदलें**

यदि आप चाहते हैं कि बॉक्स में टेक्स्ट हमेशा बॉक्स में फिट हो, टेक्स्ट में बदलाव करने के बाद, तो आपको **Resize shape to fit text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#Shape) के साथ उपयोग करें।

![alwaysfit सेटिंग PowerPoint](alwaysfit-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्ट को हमेशा अपने बॉक्स में फिट होना चाहिए एक PowerPoint प्रस्तुति में:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्ट बॉक्स स्वचालित रूप से री-साइज़ हो जाएगा (ऊँचाई बढ़ेगी) ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसका उलटा होगा।

## **ऑटोफ़िट न करें**

यदि आप चाहते हैं कि कोई टेक्स्ट बॉक्स या आकृति उसके आयामों को बनाए रखे, भले ही उसमें मौजूद टेक्स्ट में परिवर्तन हों, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [None](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#None) के साथ उपयोग करें।

![donotautofit सेटिंग PowerPoint](donotautofit-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि एक टेक्स्ट बॉक्स को हमेशा अपने आयामों को बनाए रखना चाहिए एक PowerPoint प्रस्तुति में:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो यह बाहर निकल जाता है।

## **अधिकतम होने पर टेक्स्ट छोटा करें**

यदि टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है, तो आप **Shrink text on overflow** विकल्प का उपयोग कर सकते हैं ताकि टेक्स्ट का आकार और स्पेसिंग घटाया जा सके और वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [Normal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#Normal) के साथ उपयोग करें।

![shrinktextonoverflow सेटिंग PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाये कि टेक्स्ट को overflow पर छोटा किया जाना चाहिए एक PowerPoint प्रस्तुति में:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
जब **Shrink text on overflow** विकल्प उपयोग किया जाता है, यह सेटिंग केवल तब लागू होती है जब टेक्स्ट बॉक्स के लिए बहुत लंबा हो जाता है।
{{% /alert %}}

## **आकृति में टेक्स्ट रैप करें**

यदि आप चाहते हैं कि आकृति में टेक्स्ट आकृति की सीमाओं (केवल चौड़ाई) से बाहर जाने पर उसके भीतर रैप हो, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [NullableBool.True_](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#True) के साथ उपयोग करना होगा।

यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति में Wrap Text सेटिंग का उपयोग किया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
यदि आप किसी आकृति के लिए [setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) मेथड को [NullableBool.False](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#False) के साथ उपयोग करते हैं, तो जब आकृति के भीतर टेक्स्ट उसकी चौड़ाई से अधिक हो जाता है, तो टेक्स्ट एक ही लाइन में आकृति की सीमाओं से बाहर निकल जाता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या टेक्स्ट फ्रेम के आंतरिक मार्जिन AutoFit को प्रभावित करते हैं?**

हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के उपयोग योग्य क्षेत्र को कम कर देता है, इसलिए AutoFit जल्दी सक्रिय हो जाता है—फ़ॉन्ट को छोटा करने या आकृति को पहले री-साइज़ करने के लिए। AutoFit को ट्यून करने से पहले मार्जिन की जाँच करें और उन्हें समायोजित करें।

**AutoFit मैनुअल और सॉफ्ट लाइन ब्रेक के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक अपनी जगह रहते हैं, और AutoFit उनके आसपास फ़ॉन्ट आकार और स्पेसिंग को अनुकूलित करता है। अनावश्यक ब्रेक हटाने से अक्सर यह कम हो जाता है कि AutoFit को टेक्स्ट को कितनी तेज़ी से छोटा करना पड़ता है।

**थीम फ़ॉन्ट बदलने या फ़ॉन्ट प्रतिस्थापन को ट्रिगर करने से AutoFit परिणाम प्रभावित होते हैं?**

हाँ। अलग ग्लीफ़ मेट्रिक्स वाले फ़ॉन्ट को प्रतिस्थापित करने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जो अंतिम फ़ॉन्ट आकार और लाइन रैपिंग को बदल सकता है। किसी भी फ़ॉन्ट परिवर्तन या प्रतिस्थापन के बाद, स्लाइड्स को पुनः जांचें।