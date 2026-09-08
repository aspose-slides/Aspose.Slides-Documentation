---
title: जावा के माध्यम से पायथन में स्लाइड शो प्रबंधित करें
linktitle: स्लाइड शो
type: docs
weight: 90
url: /hi/python-java/manage-slide-show/
keywords:
- शो प्रकार
- वक्ता द्वारा प्रस्तुत
- व्यक्ति द्वारा ब्राउज़्ड
- कियोस्क पर ब्राउज़्ड
- शो विकल्प
- लगातार लूप
- भाषण के बिना शो
- एनिमेशन के बिना शो
- पेन रंग
- स्लाइड दिखाएँ
- कस्टम शो
- स्लाइड आगे बढ़ाएँ
- मैन्युअली
- टाइमिंग का उपयोग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में स्लाइड शो को कैसे प्रबंधित करें, जानें। PPT, PPTX और ODP फ़ॉर्मैट्स में स्लाइड परिवर्तन, टाइमिंग और अधिक को आसानी से नियंत्रित करें।"
---
## **परिचय**

Microsoft PowerPoint के **Set Up Show** विकल्प आपको शो प्रकार चुनने, लूपिंग सक्षम करने, स्लाइडें चयनित करने और स्लाइड प्रगति को नियंत्रित करने देते हैं। Aspose.Slides for Python via Java के साथ, आप इन विकल्पों को प्रोग्रामmatically कॉन्फ़िगर कर सकते हैं और उन्हें प्रस्तुति फ़ाइल में सहेज सकते हैं।

The [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideShowSettings) method returns a [SlideShowSettings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/) object that controls these options. The examples below require Aspose.Slides for Python via Java and a compatible Java runtime. Each example starts the JVM if needed and releases the presentation when finished.

## **शो प्रकार चुनें**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setSlideShowType) स्लाइड शो के प्रकार को परिभाषित करता है, जो निम्नलिखित कक्षाओं में से किसी एक का उदाहरण हो सकता है: [PresentedBySpeaker](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/hi/python-java/aspose.slides/browsedbyindividual/), या [BrowsedAtKiosk](https://reference.aspose.com/slides/hi/python-java/aspose.slides/browsedatkiosk/). इस विधि का उपयोग करके आप प्रस्तुति को विभिन्न उपयोग परिदृश्यों के लिए अनुकूलित कर सकते हैं, जैसे स्वचलित कियोस्क या मैनुअल प्रस्तुतियाँ।

The code example below creates a new presentation and sets the show type to "Browsed by an individual" without displaying the scrollbar.

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

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setLoop) निर्धारित करता है कि स्लाइड शो को मैन्युअल रूप से बंद करने तक लूप में दोहराया जाना चाहिए या नहीं। यह निरंतर चलने वाले स्वचालित प्रस्तुतियों के लिए उपयोगी है। [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowNarration) निर्धारित करता है कि स्लाइड शो के दौरान वॉइस नैरेशन चलना चाहिए या नहीं। यह उन स्वचालित प्रस्तुतियों के लिए उपयोगी है जिनमें दर्शकों के लिए वॉइस गाइडेंस है। [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowAnimation) निर्धारित करता है कि स्लाइड वस्तुओं में जोड़ी गई एनिमेशन को चलना चाहिए या नहीं। यह प्रस्तुति के पूर्ण दृश्य प्रभाव को प्रदान करने में उपयोगी है।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और स्लाइड शो को लूप में चलाता है।

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

## **दिखाने के लिए स्लाइडें चुनें**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setSlides) विधि आपको प्रस्तुति के दौरान दिखाने के लिए स्लाइडों की एक श्रृंखला चुनने की अनुमति देती है। यह तब उपयोगी है जब आपको पूरी प्रस्तुति के बजाय केवल उसका कुछ हिस्सा दिखाना हो। निम्नलिखित कोड उदाहरण नौ स्लाइडों वाली एक प्रस्तुति बनाता है और स्लाइड 2 से 9 तक चुनता है। श्रृंखला एक‑आधारित स्लाइड नंबरों का उपयोग करती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # नौ स्लाइड बनाएं ताकि चयनित सीमा मौजूद हो।
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

## **स्लाइड प्रगति नियंत्रित करें**

[SlideSlideSettings.setUseTimings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setUseTimings) विधि आपको प्रत्येक स्लाइड के लिए पूर्व निर्धारित टाइमिंग्स के उपयोग को सक्षम या अक्षम करने की अनुमति देती है। यह पूर्वनिर्धारित प्रदर्शन अवधि के साथ स्वचालित रूप से स्लाइडें दिखाने के लिए उपयोगी है। नीचे का कोड उदाहरण एक नई प्रस्तुति बनाता है और टाइमिंग्स के उपयोग को अक्षम करता है।

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

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) विधि निर्धारित करती है कि जब मल्टीमीडिया सामग्री (उदा., वीडियो या ऑडियो) चलायी जाए तो स्लाइड शो के दौरान मीडिया नियंत्रण (जैसे प्ले, पॉज़, और स्टॉप) प्रदर्शित किए जाने चाहिए या नहीं। यह तब उपयोगी है जब आप प्रस्तुति के दौरान प्रस्तुतकर्ता को मीडिया प्लेबैक पर नियंत्रण देना चाहते हैं।

निम्नलिखित कोड उदाहरण एक नई प्रस्तुति बनाता है और मीडिया नियंत्रणों को प्रदर्शित करने के लिए सक्षम करता है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति को इस तरह सहेज सकता हूँ कि यह सीधे स्लाइड शो मोड में खुल जाए?**

हां। फ़ाइल को PPSX या PPSM के रूप में सहेजें; ये स्वरूप PowerPoint में खोले जाने पर सीधे स्लाइड शो में लॉन्च होते हैं। Aspose.Slides में, संबंधित सहेजने के स्वरूप को [during export](/slides/hi/python-java/save-presentation/) चुनें।

**क्या मैं व्यक्तिगत स्लाइडों को शो से बाहर रख सकता हूँ बिना उन्हें फ़ाइल से हटाए?**

हां। एक स्लाइड को [hidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#setHidden) के रूप में चिन्हित करें। छिपी हुई स्लाइडें प्रस्तुति में बनी रहती हैं लेकिन स्लाइड शो के दौरान प्रदर्शित नहीं होतीं।

**क्या Aspose.Slides स्लाइड शो चला सकता है या स्क्रीन पर लाइव प्रस्तुति को नियंत्रित कर सकता है?**

नहीं। Aspose.Slides प्रस्तुति फ़ाइलों को संपादित, विश्लेषण और परिवर्तित करता है; वास्तविक प्लेबैक PowerPoint जैसे व्यूअर एप्लिकेशन द्वारा संभाला जाता है।