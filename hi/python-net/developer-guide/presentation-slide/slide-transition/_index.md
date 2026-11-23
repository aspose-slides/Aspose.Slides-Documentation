---
title: Python का उपयोग करके प्रेजेंटेशन में स्लाइड ट्रांज़िशन प्रबंधित करें
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
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ाने को कॉन्फ़िगर करें, और Morph व अन्य ट्रांज़िशन इफ़ेक्ट्स को अनुकूलित करें।"
---
## **परिचय**

Slide transitions नियंत्रित करते हैं कि स्लाइड शो के दौरान स्लाइड्स कैसे प्रदर्शित होती हैं। Aspose.Slides for Python via .NET के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट के विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख Python उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग को प्रबंधित करता है, और दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, प्रेजेंटेशन को [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) क्लास से लोड करें और स्लाइड के [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी तक पहुँचें। उसके [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) एन्यूमरेशन के मान में से एक सेट करें, फिर प्रेजेंटेशन सहेजें।

निम्न उदाहरण पहला स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

[spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) प्रॉपर्टी, [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) की, गंतव्य स्लाइड को प्रकट करने वाले रेडियल सेक्टरों की संख्या को नियंत्रित करती है। स्लाइड का ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) से WHEEL पर सेट करें, फिर [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) को [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड और उसके बाद एक सोने के आयत वाले स्लाइड। गंतव्य स्लाइड्स 1 और 8 के स्पोक काउंट का उपयोग करती हैं, समान [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) और 8,000 मिलीसेकंड की स्पष्ट [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) के साथ, ताकि अंतर स्पष्ट दिखे।

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

आउटपुट प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से 2, फिर स्लाइड 3 से 4 तक आगे बढ़ाएँ। PowerPoint प्लेबैक में, सत्यापित स्पोक काउंट 1 एक घड़ी की दिशा में एक स्विप से स्लाइड को प्रकट करता है; सत्यापित काउंट 8 आठ रेडियल सेक्टरों से एक साथ प्रकट करता है। गंतव्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर प्रकट सेक्टरों की संख्या में है।

## **रेवील ट्रांज़िशन के साथ ब्लैक के माध्यम से फेड**

गंतव्य स्लाइड के ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को Reveal पर सेट करें, फिर परिणामी [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) ऑब्जेक्ट पर [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) सेट करें। उदाहरण एक टील स्रोत स्लाइड और एक कोरल गंतव्य स्लाइड बनाता है, फिर जोड़ी को क्लोन करता है। दोनों जोड़े दो-सेकंड Reveal ट्रांज़िशन का उपयोग करते हैं। केवल दूसरा जोड़ा ब्लैक के माध्यम से फेड करता है।

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

`reveal-transitions.pptx` को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से 2 तक आगे बढ़ाएँ ताकि टील सीधे कोरल में फ़ेड हो। फिर स्लाइड 3 से 4 तक आगे बढ़ाएँ। स्क्रीन कुछ क्षण के लिए काले के निकट रंग में डिम हो जाता है, फिर कोरल स्लाइड प्रकट होती है। दोनों स्लाइड अपनी मूल पृष्ठभूमि रंग बरकरार रखती हैं।

नीचे की पंक्तियों में आधे‑सेकंड अंतराल पर PowerPoint के फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति की मध्य फ्रेम की तुलना करके सेटिंग के प्रभाव को देखें।

![through_black अक्षम (ऊपर) और सक्षम (नीचे) के साथ PowerPoint प्लेबैक। केवल नीचे की पंक्ति लगभग काले रंग के माध्यम से गुजरती है।](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप निर्धारित कर सकते हैं कि एक स्लाइड स्क्रीन पर कितनी देर तक रहती है और क्या माउस क्लिक से स्लाइड शो आगे बढ़ता है। निम्न प्रॉपर्टी इस व्यवहार को नियंत्रित करती हैं:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) दर्शक को माउस क्लिक से आगे बढ़ने की अनुमति देती है।
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) स्वचालित आगे बढ़ने को सक्रिय करती है।
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) स्वचालित आगे बढ़ने से पहले देरी को मिलीसेकंड में निर्दिष्ट करती है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़े या टाइमर का इंतजार करे। केवल टाइमर उपयोग करने के लिए, [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) को `False` सेट करें। देरी निर्धारित करती है कि स्लाइड शो कब आगे बढ़ता है; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि को सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5, और 7 सेकंड बाद स्वचालित आगे बढ़ने को सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

टाइम्ड आगे बढ़ना सक्षम है या नहीं, इसे जांचने के लिए [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) पढ़ें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर को रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाली स्लाइड्स के लिए स्वचालित आगे बढ़ने को बंद कर देता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करके आप ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई को मिलीसेकंड में निर्दिष्ट कर सकते हैं। स्लाइड की [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) प्रॉपर्टी इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/) के माध्यम से एक्सपोज़ करती है:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि को मिलीसेकंड में सेट करता है। |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले की देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) को सक्षम करें। |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी (SLOW, MEDIUM या FAST) का चयन करता है। यह तब उपयोग होता है जब स्पष्ट अवधि निर्दिष्ट नहीं की गई होती। |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई देती है। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) मान से प्रभाव की अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750 ms Fade ट्रांज़िशन देता है और 5 000 ms पर स्वचालित आगे बढ़ना अलग से सक्षम करता है। ट्रांज़िशन अवधि प्रभाव को नियंत्रित करती है; आगे बढ़ना जब स्लाइड छोड़ी जाएगी, इसे नियंत्रित करता है। ये बार योजनाबद्ध सेटिंग्स हैं, मापी गई संयुक्त टाइमलाइन नहीं।*
<!-- visual-explanation:slide-transition:end -->

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` को लोड करता है, [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 ms की अवधि देता है। यह 5 000 ms पर स्वचालित आगे बढ़ना अलग से सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # प्रभाव अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें।
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइड्स अलग-अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए एक छोटा ट्रांज़िशन और सेक्शन परिचय के लिए एक लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड के लिए 500 ms और दूसरी के लिए 1 200 ms सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जब आप एक [animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/python-net/export-to-html5/), या [video](/slides/hi/python-net/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि वांछित गति के साथ मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 ms का फेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसका वार्णन या सामग्री का समय मिल सके।

GIF और वीडियो के लिए, फ़्रेम रेट को इफ़ेक्ट अवधि से समन्वयित करें: 600 ms 30 fps पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन सक्षम करें। चुनी हुई निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट और टाइमिंग विकल्पों को जाँचें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) पढ़ें ताकि यह पता चल सके कि क्या कोई स्पष्ट मान संग्रहीत है। `-1` का मान मतलब कोई स्पष्ट अवधि सेट नहीं है; एक गैर‑नकारात्मक मान संग्रहीत अवधि को मिलीसेकंड में दर्शाता है। यह अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करके वह अवधि तय करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि इनिशियलाइज़ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

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

## **मोर्फ़ ट्रांज़िशन**

Morph ट्रांज़िशन निरंतर स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक साधा Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। यह मूल और संशोधित अवस्थाओं के बीच संबंधित वस्तुओं को एनीमेट करने के लिए ट्रांज़िशन प्रदान करता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर वह दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) सूची से Morph चुनता है। सहेजी गई फ़ाइल को ऐसे प्रेजेंटेशन व्यूअर में खोलें जो Morph को सपोर्ट करता हो ताकि स्लाइड शो के दौरान प्रभाव देखें।

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

## **मोर्फ़ ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) एन्यूमरेशन यह निर्धारित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक पूरे वस्तु के रूप में लेता है।
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो, शब्दों को मिलाकर टेक्स्ट को एनीमेट करता है।
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो, अक्षरों को मिलाकर टेक्स्ट को एनीमेट करता है।

[TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को Morph पर सेट करें, फिर उसके [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) तक पहुँचें। यह मान फिर [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) ऑब्जेक्ट प्रदान करता है, जिसका [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) प्रॉपर्टी मिलान मोड चुनता है।

यह उदाहरण पिछले सेक्शन में बनाई गई प्रेजेंटेशन को खोलता है और दूसरे स्लाइड को शब्द‑आधारित Morph एनीमेशन उपयोग करने के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प चयनित ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर उसके [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) से उपयुक्त ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` के पहले स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) के माध्यम से [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए, तो [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) श्रेणी—SLOW, MEDIUM, या FAST—पर्याप्त हो और कोई स्पष्ट अवधि सेट न की गई हो, तो [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। एम्बेडेड ऑडियो को [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) पर असाइन करें, [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) को [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) से START_SOUND पर सेट करें, और [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) को सक्षम करें। ऑडियो अगली साउंड इवेंट तक लूप करता रहेगा।

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) को समान मान पर सेट करें। समान लूप में सभी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि व्यवहार सभी स्लाइड्स में सुसंगत रहे।

**मैं कैसे जांच सकता हूँ कि वर्तमान में किसी स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) से [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) एन्यूमरेशन का मान लौटाता है; NONE का मतलब है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।