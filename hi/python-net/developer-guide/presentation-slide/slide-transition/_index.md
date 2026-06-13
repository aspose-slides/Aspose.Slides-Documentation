---
title: Python का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 90
url: /hi/python-net/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से स्लाइड ट्रांज़िशन को कस्टमाइज़ करने के बारे में जानें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन के साथ।"
---
## **सारांश**

Aspose.Slides for Python स्लाइड ट्रांज़िशन पर पूर्ण नियंत्रण प्रदान करता है, ट्रांज़िशन प्रकार चुनने से लेकर टाइमिंग और ट्रिगर को कॉन्फ़िगर करने तक, जो स्वचालित प्रस्तुति कार्यप्रवाह का हिस्सा हैं। आप स्लाइड को क्लिक पर या निर्धारित विलंब के बाद आगे बढ़ाने के लिए सेट कर सकते हैं और काली स्क्रीन से कट या दिशात्मक प्रवेश जैसे प्रभावों से दृश्य व्यवहार को परिष्कृत कर सकते हैं। लाइब्रेरी PowerPoint 2019 में प्रस्तुत किए गए Morph ट्रांज़िशन को भी सपोर्ट करती है, जिसमें ऑब्जेक्ट, शब्द या अक्षर द्वारा मोर्फ़ मोड शामिल हैं, जो स्लाइड के बीच सुगम और सुसंगत गति बनाते हैं।

## **स्लाइड ट्रांज़िशन जोड़ें**

इसको आसान समझाने के लिए, यह उदाहरण दिखाता है कि Aspose.Slides for Python का उपयोग करके सरल स्लाइड ट्रांज़िशन कैसे प्रबंधित करें। डेवलपर्स विभिन्न स्लाइड ट्रांज़िशन इफ़ेक्ट्स को स्लाइड पर लागू कर सकते हैं और उनके व्यवहार को कस्टमाइज़ कर सकते हैं। एक सरल स्लाइड ट्रांज़िशन बनाने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
1. [TransitionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitiontype/) enum से किसी प्रभाव को चुनकर स्लाइड ट्रांज़िशन लागू करें।
1. संशोधित प्रस्तुति फ़ाइल को सहेजें।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाकर प्रस्तुति फ़ाइल लोड करें।
with slides.Presentation("sample.pptx") as presentation:
    # स्लाइड 1 पर सर्किल ट्रांज़िशन लागू करें।
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # स्लाइड 2 पर कॉम्ब ट्रांज़िशन लागू करें।
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

इस अनुभाग में, हमने एक स्लाइड पर सरल ट्रांज़िशन प्रभाव लागू किया। इस प्रभाव को और अधिक नियंत्रित और परिष्कृत बनाने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
1. [TransitionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitiontype/) enum से किसी प्रभाव को चुनकर स्लाइड ट्रांज़िशन लागू करें।
1. ट्रांज़िशन को Advance On Click, किसी निश्चित समय अवधि के बाद, या दोनों के रूप में कॉन्फ़िगर करें।
1. संशोधित प्रस्तुति फ़ाइल को सहेजें।

यदि **Advance On Click** सक्षम है, तो स्लाइड केवल उपयोगकर्ता के क्लिक करने पर आगे बढ़ती है। यदि **Advance After Time** प्रॉपर्टी सेट है, तो स्लाइड निर्दिष्ट अंतराल के बाद स्वचालित रूप से आगे बढ़ती है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल खोलने के लिए Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # स्लाइड 1 पर सर्किल ट्रांज़िशन लागू करें।
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # क्लिक पर अग्रसर को सक्षम करें और 3 सेकंड का स्वचालित अग्रसर सेट करें।
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # स्लाइड 2 पर कॉम्ब ट्रांज़िशन लागू करें।
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # क्लिक पर अग्रसर को सक्षम करें और 5 सेकंड का स्वचालित अग्रसर सेट करें।
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # स्लाइड 3 पर ज़ूम ट्रांज़िशन लागू करें।
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # क्लिक पर अग्रसर को सक्षम करें और 7 सेकंड का स्वचालित अग्रसर सेट करें।
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph ट्रांज़िशन**

Aspose.Slides for Python [Morph transition](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/morphtransition/) को सपोर्ट करता है, जो एक स्लाइड से अगले स्लाइड तक की सुगम गति को एनीमेट करता है। यह अनुभाग बताता है कि Morph ट्रांज़िशन का उपयोग कैसे करें। प्रभावी रूप से उपयोग करने के लिए, आपको दो स्लाइड चाहिए जिनमें कम से कम एक ऑब्जेक्ट सामान्य हो। सबसे आसान तरीका है एक स्लाइड की प्रतिलिपि बनाना और फिर दूसरे स्लाइड में ऑब्जेक्ट को अलग स्थान पर ले जाना।

निम्न कोड स्निपेट दिखाता है कि टेक्स्ट वाली स्लाइड को कैसे क्लोन करें और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # पहले स्लाइड को क्लोन करें ताकि समान आकारों के साथ दूसरा स्लाइड बनाया जा सके, जिससे Morph निरंतरता बनी रहे।
    slide1 = presentation.slides.add_clone(slide0)

    # दूसरे स्लाइड पर वही आयत चुनें और उसकी स्थिति व आकार बदलें।
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # दूसरे स्लाइड पर Morph ट्रांज़िशन सक्षम करें ताकि आकार परिवर्तन सुचारू रूप से एनिमेट हों।
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionmorphtype/) enum Morph स्लाइड ट्रांज़िशन के विभिन्न प्रकारों को दर्शाता है।

निम्न कोड स्निपेट दिखाता है कि एक स्लाइड पर Morph ट्रांज़िशन कैसे लागू करें और morph प्रकार को कैसे बदलें:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

Aspose.Slides for Python आपको **From Black**, **From Left**, **From Right** आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने देता है। ट्रांज़िशन इफ़ेक्ट कॉन्फ़िगर करने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग की एक इंस्टेंस बनाएं।
1. स्लाइड का रेफ़रेंस प्राप्त करें।
1. वांछित ट्रांज़िशन इफ़ेक्ट सेट करें।
1. प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में सहेजें।

निचे दिए उदाहरण में, हमने कई ट्रांज़िशन इफ़ेक्ट सेट किए हैं।

```py
import aspose.slides as slides

# Presentation क्लास का उदाहरण बनाकर प्रस्तुति फ़ाइल खोलें।
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Cut ट्रांज़िशन लागू करें और From Black को सक्षम करें।
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड नियंत्रित कर सकता हूँ?**  
हाँ। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) को [TransitionSpeed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionspeed/) सेटिंग का उपयोग करके सेट करें (जैसे, slow/medium/fast)।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**  
हाँ। आप ट्रांज़िशन के लिए साउंड एम्बेड कर सकते हैं और साउंड मोड, लूपिंग आदि सेटिंग्स जैसे [sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) तथा मेटाडेटा जैसे [sound_is_built_in](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) और [sound_name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/) का उपयोग करके व्यवहार नियंत्रित कर सकते हैं।

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**  
प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग में वांछित ट्रांज़िशन प्रकार को कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड पर अलग से संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर एक ही प्रकार लागू करने से एकसमान परिणाम मिलता है।

**मैं कैसे जांच सकता हूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**  
स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_show_transition/) को देखें और उसके [transition type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) को पढ़ें; वह मान बताएगा कि कौन सा इफ़ेक्ट लागू किया गया है।