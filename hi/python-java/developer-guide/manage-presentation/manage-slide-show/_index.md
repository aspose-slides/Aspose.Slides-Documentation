---
title: Python के द्वारा Java में स्लाइड शो प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/python-java/manage-slide-show/
keywords:
  - शो प्रकार
  - स्पीकर द्वारा प्रस्तुत
  - व्यक्ति द्वारा ब्राउज़ किया गया
  - कियोस्क पर ब्राउज़ किया गया
  - शो विकल्प
  - लगातार लूप
  - नैरेशन के बिना शो
  - एनिमेशन के बिना शो
  - पेन रंग
  - स्लाइड दिखाएँ
  - कस्टम शो
  - स्लाइड आगे बढ़ाएँ
  - हाथ से
  - टाइमिंग का उपयोग
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Python via Java में स्लाइड शो को कैसे प्रबंधित करें सीखें। PPT, PPTX और ODP प्रारूपों में स्लाइड ट्रांज़िशन, टाइमिंग आदि को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint के **Set Up Show** विकल्प आपको शो प्रकार चुनने, लूपिंग सक्षम करने, स्लाइड्स चुनने, और स्लाइड्स के आगे बढ़ने को नियंत्रित करने देते हैं। Aspose.Slides for Python via Java के साथ, आप इन विकल्पों को प्रोग्रामेटिक रूप से कॉन्फ़िगर कर सकते हैं और उन्हें एक प्रस्तुति फ़ाइल में सहेज सकते हैं।

यह [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideShowSettings) मेथड एक [SlideShowSettings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/) ऑब्जेक्ट लौटाता है जो इन विकल्पों को नियंत्रित करता है। नीचे दिए गए उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम आवश्यक है। प्रत्येक उदाहरण आवश्यक होने पर JVM आरंभ करता है और समाप्त होने पर प्रस्तुति को रिलीज़ करता है।

## **शो प्रकार चुनें**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setSlideShowType) स्लाइड शो के प्रकार को परिभाषित करता है, जो निम्नलिखित क्लासों में से एक का इंस्टेंस हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/python-java/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/python-java/aspose.slides/browsedatkiosk/). इस मेथड का उपयोग करके आप विभिन्न उपयोग परिदृश्यों जैसे स्वचालित कियोस्क या मैन्युअल प्रस्तुतियों के लिए प्रस्तुति को अनुकूलित कर सकते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और शो प्रकार को "Browsed by an individual" पर सेट करता है, बिना स्क्रॉलबार प्रदर्शित किए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **शो विकल्प सक्षम करें**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setLoop) निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से रोके जाने तक लूप में दोहराया जाना चाहिए या नहीं। यह निरंतर चलने वाली स्वचालित प्रस्तुतियों के लिए उपयोगी है। [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowNarration) निर्धारित करता है कि स्लाइड शो के दौरान वॉयस नैरेशन चलाए जाने चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिसमें दर्शकों के लिए आवाज़ मार्गदर्शन शामिल है। [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowAnimation) निर्धारित करता है कि स्लाइड ऑब्जेक्ट्स में जोड़े गए एनीमेशन चलाए जाने चाहिए या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने में मदद करता है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **दिखाने के लिए स्लाइड्स चुनें**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setSlides) मेथड आपको प्रस्तुति के दौरान दिखाए जाने वाली स्लाइड्स की रेंज चुनने की अनुमति देता है। यह तब उपयोगी है जब आपको पूरी प्रस्तुति के बजाय केवल कुछ भाग दिखाना हो। निम्नलिखित कोड उदाहरण नौ स्लाइड्स वाली एक प्रस्तुति बनाता है और स्लाइड 2 से 9 तक चुनता है। रेंज एक-आधारित स्लाइड नंबरों का उपयोग करती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # नौ स्लाइड्स बनाएँ ताकि चयनित रेंज मौजूद रहे।
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्लाइड अग्रसरण नियंत्रित करें**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setUseTimings) मेथड आपको प्रत्येक स्लाइड के लिए पूर्वनिर्धारित टाइमिंग्स के उपयोग को सक्षम या अक्षम करने की अनुमति देता है। यह पूर्वनिर्धारित प्रदर्शन अवधि वाले स्लाइड्स को स्वचालित रूप से दिखाने के लिए उपयोगी है। नीचे दिया गया कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग्स के उपयोग को अक्षम करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **मीडिया नियंत्रण दिखाएँ**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) मेथड निर्धारित करता है कि मल्टिमीडिया कंटेंट (जैसे वीडियो या ऑडियो) चलाने के दौरान स्लाइड शो में मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) दिखाए जाएँ या नहीं। यह तब उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रणों को दिखाने के लिए सक्षम करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**क्या मैं प्रस्तुति को इस तरह सहेज सकता हूँ कि वह सीधे स्लाइड शो मोड में खुले?**

हाँ। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये फ़ॉर्मेट PowerPoint में खोलने पर सीधे स्लाइड शो मोड में लॉन्च होते हैं। Aspose.Slides में, संबंधित सहेजने का फ़ॉर्मेट चुनें [during export](/slides/hi/python-java/save-presentation/).

**क्या मैं फ़ाइल से स्लाइड को हटाए बिना व्यक्तिगत स्लाइड्स को शो से बाहर रख सकता हूँ?**

हाँ। एक स्लाइड को [hidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setHidden) के रूप में चिह्नित करें। छिपी हुई स्लाइड्स प्रस्तुति में रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**क्या Aspose.Slides स्क्रीन पर स्लाइड शो चला सकता है या लाइव प्रस्तुति को नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषित और परिवर्तित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।