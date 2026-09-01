---
title: Python के साथ प्रस्तुति स्थानीयकरण को स्वचालित करें
linktitle: प्रस्तुति स्थानीयकरण
type: docs
weight: 100
url: /hi/python-net/presentation-localization/
keywords:
- भाषा बदलें
- वर्तनी जाँच
- वर्तनी जाँच को रोकें
- प्रूफिंग भाषा
- भाषा आईडी
- बहुभाषी टेक्स्ट
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python में Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुति टेक्स्ट के लिए प्रूफिंग भाषाएँ सेट करें, जिसमें डिफ़ॉल्ट और बहुभाषी पैराग्राफ शामिल हैं।"
---
## **समीक्षा**

Aspose.Slides for Python via .NET आपको व्यक्तिगत टेक्स्ट भागों के लिए प्रूफिंग मेटाडाटा कॉन्फ़िगर करने की अनुमति देता है। प्रूफिंग भाषा की पहचान करने के लिए [BasePortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) का उपयोग करें, वर्तनी जांच को सक्षम या निष्क्रिय करने के लिए [BasePortionFormat.spell_check](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spell_check/) का उपयोग करें, और व्यापक “no-proof” स्थिति को नियंत्रित करने के लिए [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/proof_disabled/) को नियंत्रित करें। क्योंकि ये सेटिंग्स भाग स्तर पर लागू होती हैं, एक पैराग्राफ में कई भाषाएँ और विभिन्न प्रूफिंग नियम हो सकते हैं।

यह लेख बताता है कि विशिष्ट टेक्स्ट को भाषा कैसे असाइन करें, नई टेक्स्ट के लिए डिफ़ॉल्ट भाषा कैसे सेट करें, बहुभाषी पैराग्राफ कैसे बनाएं, `spell_check` और `proof_disabled` में से कौन सा उपयोग करें, और [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) का उपयोग करते समय इच्छित सेटिंग्स को कैसे संरक्षित रखें। ये गुण प्रस्तुति अनुप्रयोगों के लिए मेटाडाटा संग्रहीत करते हैं; वे टेक्स्ट का अनुवाद नहीं करते, शब्दकोश-आधारित वर्तनी जांच नहीं करते, या गलत शब्दों को नहीं लौटाते।

## **टेक्स्ट के लिए प्रूफिंग भाषा सेट करें**

एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) बनाएं या लोड करें, आवश्यक टेक्स्ट भाग तक पहुंचने के लिए [Portion.portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/portion_format/) का उपयोग करें, और उसकी भाषा पहचानकर्ता असाइन करें। नीचे दिया गया उदाहरण एक शैप बनाता है, ब्रिटिश इंग्लिश को प्रूफिंग भाषा सेट करता है, और परिणाम को [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/save/) के साथ सहेजता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **नई टेक्स्ट के लिए डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करके वह प्रूफिंग भाषा बताएं जो Aspose.Slides नई बनाई गई टेक्स्ट को असाइन करता है। यह सेटिंग तब उपयोगी होती है जब प्रस्तुति में अधिकांश या सभी नई टेक्स्ट एक ही भाषा का उपयोग करती है। यह पहले से स्पष्ट भाषा वाले टेक्स्ट की भाषा मेटाडाटा को नहीं बदलती।

निम्न उदाहरण एक प्रस्तुति बनाता है जिसमें नई टेक्स्ट जर्मन प्रूफिंग नियमों का उपयोग करती है:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **एक पैराग्राफ में कई भाषाएँ उपयोग करें**

एक [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/paragraph/) में टेक्स्ट भागों का संग्रह होता है। प्रत्येक भाषा के लिए एक अलग [Portion](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/) बनाएं और उसका `language_id` स्वतंत्र रूप से सेट करें।

यह उदाहरण अंग्रेजी और फ्रेंच भागों के साथ एक पैराग्राफ बनाता है:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **व्यक्तिगत भागों के लिए वर्तनी जाँच सक्षम या निष्क्रिय करें**

[PortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portionformat/) [BasePortionFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/) द्वारा परिभाषित सामान्य टेक्स्ट गुणों को विरासत में लेता है। एक भाग के फॉर्मेट तक पहुंचने के लिए [Portion.portion_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/portion/portion_format/) का उपयोग करें और [BasePortionFormat.spell_check](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/spell_check/) को सेट करके निर्धारित करें कि प्रस्तुति अनुप्रयोग उस भाग के लिए वर्तनी जाँच कर सकता है या नहीं। डिफ़ॉल्ट मान `False` है: `True` वर्तनी जाँच को सक्षम करता है, जबकि `False` इसे निष्क्रिय करता है।

यह सेटिंग व्यक्तिगत टेक्स्ट भागों पर लागू होती है। समान पैराग्राफ में विभिन्न भाग इसलिए अलग-अलग मान रख सकते हैं। [BasePortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) और `spell_check` परस्पर पूरक कार्य करते हैं: `language_id` प्रूफिंग भाषा की पहचान करता है, जबकि `spell_check` निर्धारित करता है कि उस भाग के लिए वर्तनी जाँच की अनुमति है या नहीं।

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/proof_disabled/) भी प्रूफिंग को नियंत्रित करता है, लेकिन यह व्यापक “do not proof” स्थिति को एक [NullableBool](https://reference.aspose.com/slides/hi/python-net/aspose.slides/nullablebool/) के रूप में दर्शाता है। जब आपको केवल वर्तनी जाँच के लिए एक बूलियन स्विच चाहिए, तो `spell_check` का उपयोग करें। जब आपको प्रस्तुति की “no-proof” मेटाडाटा को बनाए रखना या स्पष्ट रूप से नियंत्रित करना हो, जिसमें उसका `NOT_DEFINED` स्थिति भी शामिल है, तो `proof_disabled` का उपयोग करें। यदि आप दोनों गुण सेट करते हैं, तो उनके मानों को संगत रखें; `spell_check = True` को `proof_disabled = slides.NullableBool.TRUE` के साथ मिलाएँ नहीं।

ये गुण PowerPoint तथा अन्य प्रस्तुति अनुप्रयोगों द्वारा उपयोग किए जाने वाले प्रूफिंग मेटाडाटा को कॉन्फ़िगर करते हैं। Aspose.Slides इन्हें शब्दकोश-आधारित वर्तनी जाँच चलाने या गलत शब्दों की सूची लौटाने के लिए उपयोग नहीं करता।

निम्न पूर्ण उदाहरण एक इनपुट प्रस्तुति बनाता है, उसे लोड करता है, एक ही पैराग्राफ में दो भागों के लिए विभिन्न spell‑check सेटिंग्स और प्रूफिंग भाषाएँ असाइन करता है, परिणाम को सहेजता है, उसे पुनः खोलता है, और संग्रहीत मानों को सत्यापित करता है:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) समान फॉर्मेटिंग वाले क्रमागत भागों को मिलाता है। केवल `spell_check` में अंतर होने से ऐसे भाग अलग नहीं रहते; एक बार मिल जाने के बाद परिणामस्वरूप भाग पहली भाग का `spell_check` मान रखता है। यदि भागों को विभिन्न spell‑check सेटिंग्स की आवश्यकता है, तो उन सेटिंग्स को असाइन करने से पहले `join_portions_with_same_formatting` को कॉल करें, या परिणामी भाग की सीमाओं की जांच करके बाद में सेटिंग्स पुनः लागू करें। विभिन्न `language_id` मान वाले भाग अलग रहते हैं क्योंकि उनके प्रूफिंग‑भाषा फॉर्मेटिंग अलग होते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या भाषा ID टेक्स्ट का अनुवाद करता है?**

नहीं। [BasePortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) वर्तनी और व्याकरण के लिए प्रूफिंग मेटाडाटा संग्रहीत करता है; यह टेक्स्ट सामग्री को नहीं बदलता। टेक्स्ट को अलग से अनुवाद करें, और फिर प्रत्येक अनूदित भाग के लिए उपयुक्त भाषा पहचानकर्ता सेट करें।

**क्या प्रूफिंग भाषा फ़ॉन्ट, हाइफ़नेशन या लाइन रैपिंग को नियंत्रित करती है?**

नहीं। भाषा पहचानकर्ता केवल प्रूफिंग के लिए है। टेक्स्ट रेंडरिंग और लेआउट मुख्यतः उपलब्ध [fonts](/slides/hi/python-net/powerpoint-fonts/), लेखन प्रणाली, और टेक्स्ट‑फ़्रेम सेटिंग्स पर निर्भर करता है। विश्वसनीय रेंडरिंग के लिए आवश्यक फ़ॉन्ट प्रदान करें, [font substitution](/slides/hi/python-net/font-substitution/) कॉन्फ़िगर करें, या प्रस्तुति में [embed fonts](/slides/hi/python-net/embedded-font/) करें।

**क्या एक पैराग्राफ कई प्रूफिंग भाषाओं का उपयोग कर सकता है?**

हां। प्रत्येक भाषा को एक अलग भाग में असाइन करें, जैसा कि बहुभाषी पैराग्राफ उदाहरण में दिखाया गया है।

**मुझे `default_text_language` या `language_id` में से कौन सा उपयोग करना चाहिए?**

जब आप नई बनाई गई टेक्स्ट के लिए डिफ़ॉल्ट चाहते हैं, तो [LoadOptions.default_text_language](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadoptions/default_text_language/) का उपयोग करें। जब किसी विशिष्ट भाग को स्पष्ट प्रूफिंग भाषा चाहिए या जब पैराग्राफ में कई भाषाएँ हों, तो [BasePortionFormat.language_id](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseportionformat/language_id/) का उपयोग करें।