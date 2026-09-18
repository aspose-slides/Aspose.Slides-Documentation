---
title: Python के साथ प्रस्तुतियों में शैप एनीमेशन लागू करें
linktitle: शैप एनीमेशन
type: docs
weight: 60
url: /hi/python-net/shape-animation/
keywords:
- शैप
- एनीमेशन
- इफ़ेक्ट
- एनिमेटेड शैप
- एनिमेटेड टेक्स्ट
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- इफ़ेक्ट जोड़ें
- इफ़ेक्ट प्राप्त करें
- इफ़ेक्ट निकालें
- इफ़ेक्ट साउंड
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ शैप एनीमेशन, टाइमिंग, साउंड, एफ़्टर‑एनीमेशन व्यवहार, और एनीमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **समग्र अवलोकन**

एक प्रभाव के भीतर व्यक्तिगत व्यवहारों के साथ काम करने या मोशन‑पाथ खंडों को संपादित करने के लिए, देखें [कस्टम एनीमेशन](/slides/hi/python-net/custom-animation/)।

Aspose.Slides for Python via .NET स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में प्रस्तुत करता है। एक इफ़ेक्ट में लक्ष्य शैप, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे साउंड या एफ़्टर‑एनीमेशन व्यवहार होते हैं।

टाइमलाइन दो प्रकार की सीक्वेंसेज़ रखती है:

- **मुख्य सीक्वेंस** स्लाइड आगे बढ़ने पर चलता है।
- **इंटरैक्टिव सीक्वेंस** तब शुरू होता है जब उसका ट्रिगर शैप क्लिक किया जाता है।

क्यूँकि टेक्स्ट बॉक्स, चित्र, चार्ट, तालिकाएँ और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड कंटेंट के लिये वही [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) एन्न्यूमरेशन में सूचीबद्ध हैं।

## **शेप एनीमेशन जोड़ें**

एनीमेशन जोड़ने के लिये, स्लाइड की मुख्य सीक्वेंस प्राप्त करें और लक्ष्य शैप, इफ़ेक्ट प्रकार, उपप्रकार और ट्रिगर के साथ [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) को कॉल करें। ऐसे इफ़ेक्ट के लिये जो किसी अन्य शैप के क्लिक होने पर शुरू होता है, एक इंटरैक्टिव सीक्वेंस बनाएं जिसका ट्रिगर वही अन्य शैप हो।

निम्न उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

ट्रिगर यह नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) मुख्य सीक्वेंस में क्लिक की प्रतीक्षा करता है, या इंटरैक्टिव सीक्वेंस में ट्रिगर शैप पर क्लिक का इंतज़ार करता है।
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) पिछले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) जब पिछला इफ़ेक्ट समाप्त हो जाता है, तब शुरू होता है।

चित्र, चार्ट, या किसी अन्य शैप प्रकार को एनीमेट करने के लिये, `target_shape` के बजाय उस ऑब्जेक्ट को [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) को पास करें। चार्ट‑विशिष्ट समूह विकल्पों के लिये, देखें [Animated Charts](/slides/hi/python-net/animated-charts/)।

## **शेप एनीमेशन पढ़ें**

जब आपको लक्ष्य शैप पता हो, तब [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) का प्रयोग करें। प्रत्येक इफ़ेक्ट की जाँच करने के लिये, मुख्य सीक्वेंस और प्रत्येक इंटरैक्टिव सीक्वेंस के माध्यम से इटरेट करें। इटरेशन यह सुनिश्चित करता है कि आप यह मान कर न चलें कि किसी सीक्वेंस में इंडेक्स `0` पर हमेशा कोई इफ़ेक्ट मौजूद है।

निम्न उदाहरण एक शैप बनाता है जिसमें मुख्य‑सीक्वेंस और इंटरैक्टिव इफ़ेक्ट्स होते हैं, शैप को लक्ष्य बनाने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर प्रत्येक सीक्वेंस के माध्यम से इटरेट करता है।

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

यदि आपको केवल एक शैप के लिये इफ़ेक्ट चाहिए, तो पहले शैप को नाम, प्लेसहोल्डर प्रकार, या किसी अन्य स्थिर गुण से पहचानें; फिर [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) को कॉल करें। यह न मानें कि इंडेक्स `0` पर शैप हमेशा इच्छित ऑब्जेक्ट होता है।

## **इनहेरिटेड प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

एक सामान्य स्लाइड पर प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार को विरासत में ले सकता है। [Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) वह पैरेंट प्लेसहोल्डर लौटाता है, या यदि कोई पैरेंट मौजूद नहीं है तो `None`।

निम्न उदाहरण प्रस्तुति में, फुटर के पास **Random Bars** सामान्य स्लाइड पर, **Split** लेआउट स्लाइड पर, और **Fly In** मास्टर स्लाइड पर होते हैं।

![सामान्य स्लाइड पर फुटर एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](master-shape-animation.png)

अगला उदाहरण स्वयं प्लेसहोल्डर पदानुक्रम को बनाता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) को कॉल करने से पहले जांची जाती है कि लौटाया गया शैप उपयोग योग्य है या नहीं।

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** डायलॉग [Timing](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/) की प्रॉपर्टीज़ से मेल खाता है।

![एनीमेशन इफ़ेक्ट के लिये PowerPoint टाइमिंग डायलॉग](shape-animation.png)

- **Start** को [Timing.trigger_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/trigger_type/) से मैप किया जाता है।
- **Duration** को [Timing.duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/duration/) से मैप किया जाता है, सेकंड में।
- **Delay** को [Timing.trigger_delay_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/trigger_delay_time/) से मैप किया जाता है, सेकंड में।
- **Repeat** को [Timing.repeat_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_next_click/) या [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) से मैप किया जाता है।
- **Rewind when done playing** को [Timing.rewind](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/rewind/) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसे [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से टाइमिंग बदलता है, और परिणाम सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/) रेफ़रेंसेज़ को रखकर अनावश्यक कलेक्शन इंडेक्स से बचा जा सकता है।

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

एक रिपीट मोड को इरादे से उपयोग करें। रिपीट काउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाले परिणाम हो सकते हैं। जब रिपीट मोड बदलें, तो पहले [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_next_click/) और [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) सेट करें, और फिर [Timing.repeat_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_count/) सेट करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड भी बदल जाता है।

## **एनीमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो को [Effect.sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/sound/) के माध्यम से संदर्भित कर सकता है। [Effect.stop_previous_sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/stop_previous_sound/) इफ़ेक्ट को पहले के इफ़ेक्ट द्वारा शुरू किए गए ऑडियो को रोकने का निर्देश देता है।

### **इफ़ेक्ट में साउंड जोड़ें**

निम्न उदाहरण स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिये उस फ़ाइल को साउंड के रूप में एम्बेड करता है, और दूसरी इफ़ेक्ट को साउंड को रोकने के लिये कॉन्फ़िगर करता है। यह [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए कोई सीक्वेंस इंडेक्स आवश्यक नहीं है।

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **एम्बेडेड इफ़ेक्ट साउंड निकालें**

निम्न उदाहरण स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों सीक्वेंस को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट साउंड को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन audio MIME type द्वारा प्रदान किए गए [Audio.content_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audio/content_type/) से चुना जाता है।

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"

    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

बड़े ऑडियो ऑब्जेक्ट्स के लिये, [Audio.get_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audio/get_stream/) का उपयोग करें और पूरे ऑब्जेक्ट को बाइट एरे में लोड करने की बजाय स्ट्रीम को फ़ाइल में कॉपी करें।

## **एफ़्टर‑एनीमेशन व्यवहार सेट करें**

**After animation** विकल्प यह नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद शैप पर क्या हो।

![After एनीमेशन सेटिंग्स दिखाते हुए PowerPoint इफ़ेक्ट ऑप्शन्स डायलॉग](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) एन्न्यूमरेशन शैप को अपरिवर्तित रहने, उसका रंग बदलने, एनीमेशन के बाद छिपाने, या अगले क्लिक पर छिपाने की अनुमति देता है। जब प्रकार [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) होता है, तो साथ ही [Effect.after_animation_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/after_animation_color/) सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसके एफ़्टर‑एनीमेशन व्यवहार को सेट करता है, और परिणाम सहेजता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

[AfterAnimationType.COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) से प्रकार बदलने पर एफ़्टर‑एनीमेशन रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन के दो संबंधित नियंत्रण हैं:

- [TextAnimation.build_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/textanimation/build_type/) यह निर्धारित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [Effect.animate_text_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/animate_text_type/) यह निर्धारित करता है कि टेक्स्ट एक बार में, शब्द‑दर‑शब्द या अक्षर‑दर‑अक्षर दिखे। [Effect.delay_between_text_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/delay_between_text_parts/) शब्दों या अक्षरों के बीच की देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत होता है; नकारात्मक मान सेकंड में देरी दर्शाता है।

निम्न स्वतंत्र उदाहरण टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/buildtype/) पैराग्राफ‑बाय‑पैराग्राफ बिल्डिंग को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

पैराग्राफ‑बाय‑पैराग्राफ बॉक्स बनाने के लिये, [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/buildtype/) (या कोई अन्य पैराग्राफ स्तर) सेट करें। किसी एक पैराग्राफ को उसका अपना इफ़ेक्ट देने के लिये, वह ओवरलोड उपयोग करें जो एक [IParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिये देखें [Animated Text](/slides/hi/python-net/animated-text/)।

## **एक्सपोर्ट और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल बरकरार रहता है, पर अंतिम प्लेबैक प्रस्तुति दर्शक द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियाँ एनीमेशन नहीं चलातीं। जब गति दिखानी आवश्यक हो तो [HTML5 export](/slides/hi/python-net/export-to-html5/), एनीमेटेड GIF, या [video conversion](/slides/hi/python-net/convert-powerpoint-to-video/) उपयोग करें।
- HTML5 के लिये, [Html5Options.animate_shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_shapes/) सक्रिय करें और आवश्यकता अनुसार [Html5Options.animate_transitions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_transitions/) भी सेट करें।
- वीडियो रेंडरिंग कई सामान्य प्रवेश, ज़ोर, निकास, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, पर प्रत्येक PowerPoint इफ़ेक्ट समर्थित नहीं है। वर्तमान [supported animations and effects](/slides/hi/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और लक्ष्य Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुति स्वरूपों से आयातित इफ़ेक्ट्स फ़ाइल में संरक्षित रह सकते हैं, पर PowerPoint, HTML5, या वीडियो में अलग‑अलग रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा करने के बजाय निर्यात परिणाम को सत्यापित करें।

## **FAQ**

**PowerPoint में एनीमेशन दिखता है लेकिन PDF में क्यों नहीं दिखता?**

PDF स्थिर प्रारूप है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। जब गति बरकरार रखनी हो तो HTML5, एनीमेटेड GIF, या वीडियो में निर्यात करें।

**वीडियो में इफ़ेक्ट अलग‑अलग क्यों चलता है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार को नहीं रखता। कुछ उन्नत इफ़ेक्ट्स असहाय या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या शैप को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। शैप का Z‑ऑर्डर ओवरलैप को नियंत्रित करता है, जबकि सीक्वेंस क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।