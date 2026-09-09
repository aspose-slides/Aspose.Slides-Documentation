---
title: Python के ज़रिए Java में प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/python-java/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जांच
- वर्तनी जांच को निष्क्रिय करें
- प्रूफ़िंग भाषा
- भाषा पहचानकर्ता
- बहुभाषी पाठ
- PowerPoint
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के ज़रिए Java में PowerPoint और OpenDocument प्रस्तुति पाठ के लिए प्रूफ़िंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुभाषी पैराग्राफ़ शामिल हैं।"
---
## **सारांश**

Aspose.Slides for Python via Java आपको व्यक्तिगत पाठ भागों के लिए प्रूफ़िंग मेटाडाटा कॉन्फ़िगर करने देता है। प्रूफ़िंग भाषा पहचानने के लिए [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) का उपयोग करें, वर्तनी जांच को सक्षम या निष्क्रिय करने के लिए [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) का उपयोग करें, और व्यापक “कोई प्रूफ़ नहीं” स्थिति को नियंत्रित करने के लिए [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setProofDisabled) का उपयोग करें। क्योंकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफ़िंग नियम हो सकते हैं।

यह लेख बताता है कि विशिष्ट पाठ को भाषा कैसे असाइन करें, नई पाठ के लिए डिफ़ॉल्ट भाषा को [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) के साथ सेट करें, बहुभाषी पैराग्राफ बनाएं, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) और [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setProofDisabled) के बीच चयन करें, और [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) का उपयोग करते समय इच्छित सेटिंग्स को संरक्षित रखें। ये प्रॉपर्टी प्रेजेंटेशन एप्लिकेशन के लिए मेटाडाटा संग्रहीत करती हैं; ये टेक्स्ट का अनुवाद नहीं करतीं, शब्दकोश-आधारित वर्तनी जांच नहीं चलातीं, और त्रुटिपूर्ण शब्दों की सूची नहीं लौटातीं।

## **पाठ के लिए प्रूफ़िंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक पाठ भाग को [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) के माध्यम से एक्सेस करें, और उसका भाषा पहचानकर्ता असाइन करें। निम्न उदाहरण एक आकार बनाता है, ब्रिटिश अंग्रेज़ी को प्रूफ़िंग भाषा के रूप में सेट करता है, और परिणाम को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) के साथ सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **नए पाठ के लिए डिफ़ॉल्ट भाषा सेट करें**

नयी निर्मित पाठ को Aspose.Slides द्वारा असाइन की जाने वाली प्रूफ़िंग भाषा को निर्दिष्ट करने के लिए [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें। यह सेटिंग तब उपयोगी है जब अधिकांश या सभी नया पाठ एक ही भाषा में हो। यह पहले से स्पष्ट भाषा वाले पाठ के भाषा मेटाडाटा को नहीं बदलता।

निम्न उदाहरण एक प्रेजेंटेशन बनाता है जिसमें नया पाठ जर्मन प्रूफ़िंग नियमों का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक पैराग्राफ में कई भाषाओं का उपयोग करें**

एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) में पाठ भागों का संग्रह होता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/) बनाएं और उसका [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) स्वतंत्र रूप से सेट करें।

यह उदाहरण अंग्रेज़ी और फ्रेंच भागों के साथ एक पैराग्राफ बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **व्यक्तिगत भागों के लिए वर्तनी जांच सक्षम या निष्क्रिय करें**

[PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) उस सामान्य पाठ गुणों को विरासत में लेता है जो [BasePortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/) द्वारा परिभाषित हैं। एक भाग के फ़ॉर्मेट को [Portion.getPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portion/#getPortionFormat) के माध्यम से एक्सेस करें और [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) का उपयोग करके नियंत्रित करें कि क्या प्रेजेंटेशन एप्लिकेशन उस भाग के लिए वर्तनी जांच कर सकता है। डिफ़ॉल्ट मान `False` है: `True` वर्तनी जांच को अनुमति देता है, जबकि `False` उसे निष्क्रिय करता है।

यह सेटिंग व्यक्तिगत पाठ भागों पर लागू होती है। उसी पैराग्राफ में विभिन्न भाग इसलिए अलग मानों का उपयोग कर सकते हैं। [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) और [setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) पूरक उद्देश्यों की सेवा करते हैं: [setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) प्रूफ़िंग भाषा को पहचानता है, जबकि [setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) निर्धारित करता है कि भाग के लिए वर्तनी जांच की अनुमति है या नहीं।

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setProofDisabled) भी प्रूफ़िंग को नियंत्रित करता है, लेकिन यह व्यापक “प्रूफ़ न करें” स्थिति को एक [NullableBool](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको विशेष रूप से वर्तनी जांच के लिए एक सीधा Boolean स्विच चाहिए हो तो [setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) का उपयोग करें। जब आपको प्रेजेंटेशन के “कोई प्रूफ़ नहीं” मेटाडाटा को संरक्षित या स्पष्ट रूप से नियंत्रित करने की आवश्यकता हो, जिसमें उसका [NullableBool.NotDefined](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#NotDefined) स्थिति शामिल है, तब [setProofDisabled](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setProofDisabled) का उपयोग करें। यदि आप दोनों प्रॉपर्टी सेट करते हैं, तो उनके मान संगत रखें; [setSpellCheck] को `True` पर सेट करने को [setProofDisabled] को [NullableBool.True](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/#True) स्थिति पर सेट करने के साथ मिश्रित न करें।

ये प्रॉपर्टी PowerPoint और अन्य प्रेजेंटेशन एप्लिकेशन द्वारा उपयोग किए जाने वाले प्रूफ़िंग मेटाडाटा को कॉन्फ़िगर करती हैं। Aspose.Slides इन्हें शब्दकोश-आधारित वर्तनी जांच चलाने या गलत शब्दों की सूची लौटाने के लिए उपयोग नहीं करता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) समान फ़ॉर्मेटिंग वाले सन्निहित भागों को मिलाता है। केवल [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpellCheck) में अंतर होना इन भागों को अलग रखने में पर्याप्त नहीं है; एक बार मिल जाने के बाद, परिणामी भाग पहली भाग की [BasePortionFormat.setSpellCheck] मान को रखता है। यदि भागों को अलग-अलग वर्तनी जांच सेटिंग्स चाहिए, तो उन सेटिंग्स को असाइन करने से पहले [joinPortionsWithSameFormatting] को कॉल करें, या परिणामी भाग की सीमा को निरीक्षण करके बाद में सेटिंग्स को पुनः लागू करें। विभिन्न [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) मान वाले भाग अलग रहेंगे क्योंकि उनका प्रूफ़िंग-भाषा फ़ॉर्मेटिंग अलग है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा आईडी टेक्स्ट का अनुवाद करती है?**

नहीं। [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) वर्तनी और व्याकरण के लिए प्रूफ़िंग मेटाडाटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवाद करें, फिर प्रत्येक अनुवादित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफ़िंग भाषा फॉन्ट, हाइफ़नेशन या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफ़िंग के लिए है। टेक्स्ट का रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/python-java/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट प्रदान करें, [font substitution](/slides/hi/python-java/font-substitution/) कॉन्फ़िगर करें, या प्रेजेंटेशन में [embed fonts](/slides/hi/python-java/embedded-font/) शामिल करें।

**क्या एक पैराग्राफ कई प्रूफ़िंग भाषाओं का उपयोग कर सकता है?**

हां। प्रत्येक भाषा को एक अलग भाग में असाइन करें, जैसा कि बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**क्या मुझे [setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) या [setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) का उपयोग करना चाहिए?**

जब आप नई निर्मित टेक्स्ट के लिए डिफ़ॉल्ट चाहते हैं, तो [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें। जब कोई विशिष्ट भाग स्पष्ट प्रूफ़िंग भाषा की आवश्यकता रखता है या पैराग्राफ में कई भाषाएँ होती हैं, तो [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) का उपयोग करें।