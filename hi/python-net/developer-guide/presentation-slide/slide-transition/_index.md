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
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और मॉर्फ़ व अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के दिखाई देने के तरीके को नियंत्रित करते हैं। Aspose.Slides for Python via .NET के साथ आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट से संबंधित विकल्पों को समायोजित कर सकते हैं। यह लेख Python उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि निर्धारित करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास के साथ प्रस्तुति लोड करें और स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी तक पहुँचें। इसकी [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) एनोमरेशन के किसी मान पर सेट करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

## **व्हील ट्रांज़िशन**

[WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) की [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) प्रॉपर्टी यह नियंत्रित करती है कि लक्ष्य स्लाइड को प्रकाशित करने के लिए कितने रेडियल सेक्टर उपयोग किए जाएँ। स्लाइड की ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) से WHEEL पर सेट करें, फिर [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) को [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड युग्म बनाता है: एक काली स्लाइड जिसके बाद एक सोने के आयत वाली स्लाइड आती है। लक्ष्य स्लाइड्स में स्पोक काउंट क्रमशः 1 और 8 है, समान [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) और स्पष्ट [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) 8 000 मिलिसेकंड के साथ ताकि अंतर आसानी से देखा जा सके।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। PowerPoint प्लेबैक में, सत्यापित स्पोक काउंट 1 स्लाइड को एक घड़ी की दिशा में स्वीप से दिखाता है; सत्यापित काउंट 8 इसे साथ‑साथ आठ रेडियल सेक्टर से प्रदर्शित करता है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर केवल प्रकट होने वाले सेक्टरों की संख्या है।

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाएगा। निम्न प्रॉपर्टीज़ इस व्यवहार को नियंत्रित करती हैं:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) स्वचालित आगे बढ़ने को सक्षम करता है।
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) स्वचालित आगे बढ़ने से पहले विलंब को मिलिसेकंड में निर्धारित करता है।

क्लिक और टाइम‑आधारित दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतज़ार कर सके। केवल टाइमर का उपयोग करने के लिए, [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) को `False` सेट करें। विलंब निर्धारित करता है कि स्लाइड शो कब आगे बढ़ेगा; यह विज़ुअल ट्रांज़िशन इफ़ेक्ट की अवधि को सेट नहीं करता।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स देता है और क्रमशः 3, 5 और 7 सेकंड बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

टाइम‑आधारित आगे बढ़ना सक्षम है या नहीं, यह जांचने के लिए [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) पढ़ें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइड्स के लिए स्वचालित आगे बढ़ना निष्क्रिय करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलिसेकंड में निर्धारित करने के लिए [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करें। स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) के माध्यम से उजागर करती है:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की अवधि को स्वयं, मिलिसेकंड में सेट करता है। |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले विलंब को मिलिसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) को सक्षम करें। |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी (SLOW, MEDIUM, FAST) चुनता है। यह तभी प्रयुक्त होता है जब स्पष्ट अवधि निर्दिष्ट नहीं होती। |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह नहीं तय करता कि स्लाइड कितनी देर तक दृश्य में रहे। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, Aspose.Slides ट्रांज़िशन प्रकार और [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) मान के आधार पर प्रभाव अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750‑ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **सभी स्लाइड्स पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` को लोड करता है, [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 ms की अवधि देता है। यह स्वचालित रूप से 5 000 ms के बाद आगे बढ़ना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # प्रभाव की अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ना कॉन्फ़िगर करें।
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **व्यक्तिगत स्लाइड्स के लिए विभिन्न अवधियों को सेट करें**

विभिन्न स्लाइड्स विभिन्न अवधि वाले इफ़ेक्ट उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड पर छोटे ट्रांज़िशन और अनुभाग परिचय पर लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड के लिए 500 ms और दूसरे स्लाइड के लिए 1 200 ms सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जब आप [animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/python-net/export-to-html5/), या [video](/slides/hi/python-net/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 ms का फेड उपयोग करें, और प्रत्येक स्लाइड के नेरेशन या सामग्री के लिए पर्याप्त समय देने हेतु आगे बढ़ने का विलंब अलग‑अलग सेट करें।

GIF और वीडियो के लिए, फ्रेम‑रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 ms 30 fps पर 18 फ़्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुनी गई निर्यात प्रारूप द्वारा समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन सुनिश्चित करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन संशोधित करने से पहले [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) पढ़ें ताकि यह पता चले कि क्या कोई स्पष्ट मान संग्रहीत है। `-1` मान का अर्थ है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नकारात्मक मान मिलिसेकंड में संग्रहीत अवधि दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) के आधार पर वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स को पहले जांचें।

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

## **मॉर्फ़ ट्रांज़िशन**

मॉर्फ़ ट्रांज़िशन क्रमागत स्लाइड्स पर ऑब्जेक्ट्स के बीच बदलावों को एनिमेट करता है। एक सरल मॉर्फ़ इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन में किसी ऑब्जेक्ट को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर मॉर्फ़ ट्रांज़िशन लागू करें। इससे संबंधित ऑब्जेक्ट्स मूल और संशोधित अवस्था के बीच एनीमेट होते हैं।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति एवं आकार बदलता है। फिर दूसरी स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) से Morph चुनता है। सहेजी गई फ़ाइल को मॉर्फ़ को सपोर्ट करने वाले प्रस्तुति व्यूअर में खोलें ताकि स्लाइड शो के दौरान प्रभाव देखें।

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

## **मॉर्फ़ ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) एनोमरेशन यह नियंत्रित करता है कि मॉर्फ़ सामग्री को कैसे मिलान और एनिमेट करता है:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को पूरी ऑब्जेक्ट के रूप में मानता है।
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) संभव हो तो शब्दों को मिलाकर टेक्स्ट को एनिमेट करता है।
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) संभव हो तो अक्षरों को मिलाकर टेक्स्ट को एनिमेट करता है।

ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को Morph पर सेट करें, फिर उसके [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) को एक्सेस करें। यह मान आपको [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) ऑब्जेक्ट देता है, जिसका [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) प्रॉपर्टी मिलान मोड चयन करता है।

यह उदाहरण पिछले भाग में बनाई गई प्रस्तुति को खोलता है और दूसरी स्लाइड को शब्द‑आधारित मॉर्फ़ एनिमेशन के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प चयनित ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर उसके [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) से उचित ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) के माध्यम से [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलिसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) (SLOW, MEDIUM, FAST) पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। एम्बेडेड ऑडियो को [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) में असाइन करें, [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) को [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) एनोमरेशन से START_SOUND पर सेट करें, और [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप करता रहेगा।

**सभी स्लाइड्स पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेज़ेंटेशन की [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) संग्रह पर लूप करें और प्रत्येक स्लाइड की ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को समान मान पर सेट करें। उसी लूप में सभी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि व्यवहार सभी स्लाइड्स में समान रहे।

**मैं कैसे जांचूं कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) से [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) एनोमरेशन से मान लौटाता है; NONE का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।