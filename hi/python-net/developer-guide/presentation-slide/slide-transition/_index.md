---
title: "प्रेजेंटेशन में Python का उपयोग करके स्लाइड ट्रांज़िशन प्रबंधित करें"
linktitle: "स्लाइड ट्रांज़िशन"
type: docs
weight: 90
url: /hi/python-net/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ स्लाइड ट्रांज़िशन लागू करें, स्वतः स्लाइड अग्रसरण को कॉन्फ़िगर करें, और मोर्फ़ व अन्य ट्रांज़िशन इफ़ेक्ट को कस्टमाइज़ करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन नियंत्रित करते हैं कि स्लाइड शो के दौरान स्लाइड्स कैसे प्रदर्शित होती हैं। Aspose.Slides for Python via .NET के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट के विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख Python उदाहरणों का उपयोग करके ट्रांज़िशन लागू करने, सटीक ट्रांज़िशन अवधि निर्धारित करने, स्लाइड टाइमिंग प्रबंधित करने और दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाने को दर्शाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें और स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी तक पहुंचें। इसकी [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitiontype/) enumeration के मानों में से एक पर सेट करें, फिर प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितने समय तक रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। नीचे दी गई प्रॉपर्टीज़ इस व्यवहार को नियंत्रित करती हैं:

- [advance_on_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।
- [advance_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) स्वतः आगे बढ़ने को सक्षम करता है।
- [advance_after_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) स्वतः आगे बढ़ने से पहले की देरी को मिलिसेकंड में निर्दिष्ट करता है।

क्लिक और टाइमर दोनों को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार करे। केवल टाइमर का उपयोग करने के लिए, [advance_on_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) को `False` सेट करें। देरी यह निर्धारित करती है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि निर्धारित नहीं करती।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वतः आगे बढ़ने को सक्षम करता है। माउस क्लिक से भी इन स्लाइड्स को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

समयबद्ध अग्रसरण सक्षम है या नहीं, यह जानने के लिए आप [advance_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) पढ़ें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट देता है, और दो सेकंड से अधिक देरी वाले स्लाइड्स के लिए स्वतः अग्रसरण को अक्षम करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई को मिलिसेकंड में निर्दिष्ट करने के लिए [duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करें। स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/) के माध्यम से उजागर करती है:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि को मिलिसेकंड में सेट करता है। |
| [advance_after_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले की देरी को मिलिसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [advance_after](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) को सक्षम करें। |
| [speed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | एक पूर्वनिर्धारित गति श्रेणी को [TransitionSpeed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionspeed/) से चुनता है: SLOW, MEDIUM, या FAST। जब सटीक अवधि निर्दिष्ट नहीं की जाती है तो इसका उपयोग होता है। |

[duration] केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह नहीं तय करता कि स्लाइड कितनी देर तक दिखाई दे। स्वचालित अग्रसरण देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती है, तो Aspose.Slides ट्रांज़िशन प्रकार और [speed] मान से इफ़ेक्ट की अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, हर स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलिसेकंड की अवधि देता है। यह अलग से 5,000 मिलिसेकंड के बाद स्वचालित अग्रसरण को सक्षम करता है और माउस क्लिक द्वारा अग्रसरण को अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित अग्रसरण को कॉन्फ़िगर करें।
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **व्यक्तिगत स्लाइड्स के लिए विभिन्न अवधि सेट करें**

विभिन्न स्लाइड्स विभिन्न इफ़ेक्ट अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए एक संक्षिप्त ट्रांज़िशन और सेक्शन परिचय के लिए एक लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड के लिए 500 मिलिसेकंड और दूसरे स्लाइड के लिए 1,200 मिलिसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप [animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/python-net/export-to-html5/), या [video](/slides/hi/python-net/convert-powerpoint-to-video/) तयार कर रहे हों, निर्यात से पहले सटीक ट्रांज़िशन अवधि निर्धारित करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलिसेकंड फ़ेड उपयोग करें, और प्रत्येक स्लाइड की अग्रसरण देरी को अलग से सेट करें ताकि उसकी आवाज़ या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि से मिलाएँ: 600 मिलिसेकंड 30 FPS पर 18 फ्रेम के बराबर है। HTML5 में निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात स्वरूप के समर्थित इफ़ेक्ट और टाइमिंग विकल्पों की जाँच करें और समन्वय सुनिश्चित करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) पढ़ें ताकि यह पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` मान का मतलब है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नकारात्मक मान मिलिसेकंड में संग्रहीत अवधि दर्शाता है। यह अनुसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [speed] के आधार पर वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि आरंभ हो सकती है, इसलिए पहले मूल सेटिंग्स को देखें।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन क्रमबद्ध स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर वस्तु का स्थान या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और परिवर्तित स्थितियों के बीच एनीमेट करने देता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionmorphtype/) enumeration यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [BY_OBJECT](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक पूरे वस्तु के रूप में लेता है।
- [BY_WORD](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionmorphtype/) संभव होने पर शब्दों को मिलाकर टेक्स्ट को एनीमेट करता है।
- [BY_CHAR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionmorphtype/) संभव होने पर अक्षरों को मिलाकर टेक्स्ट को एनीमेट करता है।

ट्रांज़िशन को Morph सेट करने के लिए पहले उसके [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) को Morph निर्धारित करें, फिर उसके [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/value/) तक पहुंचें। यह मान फिर [MorphTransition](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/morphtransition/) ऑब्जेक्ट प्रदान करता है, जिसके [morph_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/morphtransition/morph_type/) प्रॉपर्टी से मिलान मोड चुनें।

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प चयनित ट्रांज़िशन [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर उसके [value](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/value/) से उपयुक्त ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्नलिखित उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [from_black](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) को [OptionalBlackTransition](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/optionalblacktransition/) के माध्यम से सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलिसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/duration/) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionspeed/) श्रेणी—SLOW, MEDIUM, या FAST—पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [speed](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित अग्रसरण देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। एम्बेडेड ऑडियो को [sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound/) में असाइन करें, [sound_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) को [TransitionSoundMode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitionsoundmode/) से `START_SOUND` सेट करें, और [sound_loop](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) को सक्षम करें। ऑडियो तब तक लूप करता रहेगा जब तक स्लाइड शो में अगली ध्वनि घटना नहीं आती।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) कलेक्शन पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) को समान मान सेट करें। उसी लूप में टाइमिंग और इफ़ेक्ट विकल्पों को सेट करें ताकि सभी स्लाइड्स में व्यवहार सुसंगत रहे।

**मैं कैसे जाँच सकता हूँ कि वर्तमान में स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/slide_show_transition/) से [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/slideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.slideshow/transitiontype/) enumeration से एक मान लौटाता है; `NONE` का मतलब है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।