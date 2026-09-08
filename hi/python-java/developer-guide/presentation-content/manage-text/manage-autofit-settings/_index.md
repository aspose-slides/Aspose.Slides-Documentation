---
title: AutoFit के साथ Python में अपनी प्रस्तुतियों को बेहतर बनाएं
linktitle: ऑटोफ़िट सेटिंग्स
type: docs
weight: 30
url: /hi/python-java/manage-autofit-settings/
keywords:
- टेक्स्टबॉक्स
- ऑटोफ़िट
- ऑटोफ़िट न करें
- टेक्स्ट फिट करें
- टेक्स्ट को छोटा करें
- टेक्स्ट रैप करें
- आकार बदलें
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में AutoFit सेटिंग्स को कैसे प्रबंधित करें, ताकि आपके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट डिस्प्ले को अनुकूलित कर सकें और सामग्री की पठनीयता सुधार सकें।"
---
## **परिचय**

डिफ़ॉल्ट रूप से, जब आप एक टेक्स्टबॉक्स जोड़ते हैं, Microsoft PowerPoint टेक्स्टबॉक्स के लिए **Resize shape to fix text** सेटिंग का उपयोग करता है—यह स्वचालित रूप से टेक्स्टबॉक्स का आकार बदलता है ताकि उसका टेक्स्ट हमेशा उसमें फिट हो जाए। 

![पावरपॉइंट में टेक्स्टबॉक्स](textbox-in-powerpoint.png)

* जब टेक्स्टबॉक्स में टेक्स्ट लंबा या बड़ा हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को बड़ा कर देता है—उसकी ऊँचाई बढ़ाता है—ताकि अधिक टेक्स्ट समा सके। 
* जब टेक्स्टबॉक्स में टेक्स्ट छोटा या संकुचित हो जाता है, PowerPoint स्वचालित रूप से टेक्स्टबॉक्स को छोटा कर देता है—उसकी ऊँचाई घटाता है—ताकि अनावश्यक जगह हटे। 

PowerPoint में, ये 4 महत्वपूर्ण पैरामीटर या विकल्प हैं जो टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करते हैं: 

* **ऑटोफिट न करें**
* **ओवरफ़्लो पर टेक्स्ट को छोटा करें**
* **टेक्स्ट के अनुरूप आकार बदलें**
* **आकृति में टेक्स्ट को रैप करें।**

![ऑटोफ़िट विकल्प पावरपॉइंट](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java समान विकल्प प्रदान करता है—[TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास के कुछ प्रॉपर्टीज़—जो प्रस्तुतियों में टेक्स्टबॉक्स के ऑटोफ़िट व्यवहार को नियंत्रित करने की अनुमति देती हैं। 

## **आकार को टेक्स्ट के अनुरूप बदलें**

यदि आप चाहते हैं कि बॉक्स के भीतर टेक्स्ट हमेशा बॉक्स में फिट हो, तो आपको **Resize shape to fix text** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#Shape) के साथ प्रयोग करें।

![हमेशा फिट सेटिंग पावरपॉइंट](alwaysfit-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्ट हमेशा अपने बॉक्स में फिट हो:

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

यदि टेक्स्ट लंबा या बड़ा हो जाता है, तो टेक्स्टबॉक्स स्वचालित रूप से रिसाइज़ (ऊँचाई बढ़ाते हुए) हो जाता है ताकि सभी टेक्स्ट उसमें फिट हो सके। यदि टेक्स्ट छोटा हो जाता है, तो इसका उल्टा होता है। 

## **ऑटोफिट न करें**

यदि आप चाहते हैं कि टेक्स्टबॉक्स या आकार अपने आयामों को बरकरार रखे चाहे उसमें टेक्स्ट में कितने भी परिवर्तन हों, तो आपको **Do not Autofit** विकल्प का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [None](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#None) के साथ प्रयोग करें। 

![ऑटोफ़िट न करें सेटिंग पावरपॉइंट](donotautofit-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्टबॉक्स हमेशा अपने आयामों को बरकरार रखे:

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
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

जब टेक्स्ट अपने बॉक्स के लिए बहुत लंबा हो जाता है, तो वह बाहर निकल जाता है। 

## **ओवरफ़्लो पर टेक्स्ट को छोटा करें**

यदि टेक्स्ट अपने बॉक्स के लिए बहुत लंबा हो जाए, तो **Shrink text on overflow** विकल्प के माध्यम से आप निर्दिष्ट कर सकते हैं कि टेक्स्ट का आकार और स्पेसिंग घटाई जाए ताकि वह बॉक्स में फिट हो सके। इस सेटिंग को निर्दिष्ट करने के लिए, [setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [Normal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/#Normal) के साथ प्रयोग करें। 

![ओवरफ़्लो पर टेक्स्ट को छोटा करने की सेटिंग पावरपॉइंट](shrinktextonoverflow-setting-powerpoint.png)

यह Python कोड दिखाता है कि कैसे यह निर्दिष्ट किया जाए कि टेक्स्ट ओवरफ़्लो पर छोटा किया जाए:

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
जब **Shrink text on overflow** विकल्प का उपयोग किया जाता है, तो यह सेटिंग केवल तब लागू होती है जब टेक्स्ट अपने बॉक्स के लिए बहुत लंबा हो जाता है। 
{{% /alert %}}

## **रैप टेक्स्ट**

यदि आप चाहते हैं कि किसी आकार के भीतर टेक्स्ट, जब आकार की सीमा (केवल चौड़ाई) से आगे बढ़ जाए, तो वह आकार के भीतर ही रैप हो, तो आपको **Wrap text in shape** पैरामीटर का उपयोग करना होगा। इस सेटिंग को निर्दिष्ट करने के लिए, आपको [setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) मेथड (जो [TextFrameFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/) क्लास से है) को [NullableBool.True](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#True) के साथ प्रयोग करना होगा। 

यह Python कोड दिखाता है कि PowerPoint प्रस्तुति में Wrap Text सेटिंग का उपयोग कैसे किया जाए:

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
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
यदि आप किसी आकार के लिए [setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) मेथड को [NullableBool.False](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#False) के साथ उपयोग करते हैं, तो जब आकार के भीतर का टेक्स्ट आकार की चौड़ाई से लंबा हो जाता है, तो टेक्स्ट एक ही पंक्ति में आकार की सीमा से बाहर विस्तारित हो जाता है। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**टेक्स्ट फ्रेम के आंतरिक मार्जिन ऑटोफ़िट को प्रभावित करते हैं?**

हाँ। पैडिंग (आंतरिक मार्जिन) टेक्स्ट के लिए उपयोगी क्षेत्र को घटा देती है, इसलिए ऑटोफ़िट जल्दी सक्रिय हो जाता है—फ़ॉन्ट को छोटा करता है या आकार को जल्द रिसाइज़ करता है। ऑटोफ़िट को ट्यून करने से पहले मार्जिन जाँचें और समायोजित करें।

**ऑटोफ़िट मैन्युअल और सॉफ्ट लाइन ब्रेक्स के साथ कैसे इंटरैक्ट करता है?**

फ़ोर्स्ड ब्रेक समान रहते हैं, और ऑटोफ़िट उनके आसपास फ़ॉन्ट आकार और स्पेसिंग को अनुकूलित करता है। अनावश्यक ब्रेक्स हटाने से अक्सर ऑटोफ़िट को टेक्स्ट को बहुत अधिक छोटा करने की आवश्यकता कम हो जाती है।

**थीम फ़ॉन्ट बदलने या फ़ॉन्ट सब्स्टिट्यूशन ट्रिगर करने से ऑटोफ़िट परिणाम प्रभावित होते हैं?**

हाँ। अलग ग्लिफ़ मेट्रिक्स वाले फ़ॉन्ट में बदलने से टेक्स्ट की चौड़ाई/ऊँचाई बदलती है, जो अंतिम फ़ॉन्ट आकार और लाइन रैपिंग को प्रभावित कर सकती है। किसी भी फ़ॉन्ट परिवर्तन या सब्स्टिट्यूशन के बाद स्लाइड्स को फिर से जांचें।