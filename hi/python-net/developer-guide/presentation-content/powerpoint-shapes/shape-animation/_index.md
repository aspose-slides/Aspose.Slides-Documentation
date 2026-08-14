---
title: Python के साथ प्रस्तुतियों में आकृति एनीमेशन लागू करें
linktitle: आकृति एनीमेशन
type: docs
weight: 60
url: /hi/python-net/shape-animation/
keywords:
- आकृति
- एनीमेशन
- प्रभाव
- एनिमेटेड आकृति
- एनिमेटेड पाठ
- एनीमेशन जोड़ें
- एनीमेशन प्राप्त करें
- एनीमेशन निकालें
- प्रभाव जोड़ें
- प्रभाव प्राप्त करें
- प्रभाव निकालें
- प्रभाव ध्वनि
- एनीमेशन लागू करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ आकृति एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन के बाद के व्यवहार और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और कस्टमाइज़ करना सीखें।"
---
## **Overview**

Aspose.Slides for Python via .NET स्लाइड एनिमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट का लक्ष्य शप, एनिमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक प्रॉपर्टीज़ जैसे साउंड या एफ़्टर‑एनिमेशन व्यवहार होते हैं।

टाइमलाइन में दो प्रकार की सीक्वेंसेज़ होती हैं:

- **मुख्य सीक्वेंस** स्लाइड के आगे बढ़ने पर चलता है।
- **इंटरऐक्टिव सीक्वेंस** तब शुरू होता है जब उसका ट्रिगर शप क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishape/) को इम्प्लीमेंट करते हैं, आप अधिकांश स्लाइड कंटेंट के लिए एक ही [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) मेथड का उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) एन्यूमरेशन में सूचीबद्ध हैं।

## **Add Shape Animations**

एक एनिमेशन जोड़ने के लिए, स्लाइड के मुख्य सीक्वेंस को प्राप्त करें और लक्ष्य शप, इफ़ेक्ट टाइप, उपप्रकार, और ट्रिगर के साथ [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) कॉल करें। किसी इफ़ेक्ट को तब शुरू करने के लिए जब कोई अन्य शप क्लिक किया जाए, एक इंटरऐक्टिव सीक्वेंस बनाएँ जिसका ट्रिगर वह अन्य शप हो।

निम्नलिखित उदाहरण दोनों प्रकार की एनिमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

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

ट्रिगर निर्धारित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) मुख्य सीक्वेंस में क्लिक या इंटरऐक्टिव सीक्वेंस में ट्रिगर शप पर क्लिक का इंतजार करता है।
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) पूर्ववर्ती इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttriggertype/) जब पूर्ववर्ती इफ़ेक्ट समाप्त हो जाता है तब शुरू होता है।

एक चित्र, चार्ट, या किसी अन्य शप टाइप को एनिमेट करने के लिए, `target_shape` के बजाय उस ऑब्जेक्ट को [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) को पास करें। चार्ट‑विशिष्ट ग्रुपिंग विकल्पों के लिए, देखें [Animated Charts](/slides/hi/python-net/animated-charts/)।

## **Read Shape Animations**

जब आपको लक्ष्य शप पता हो, तब [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) का उपयोग करें। हर इफ़ेक्ट को निरीक्षण करने के लिए, मुख्य सीक्वेंस और प्रत्येक इंटरऐक्टिव सीक्वेंस पर इटरनेट करें। इटरशन यह मानते हुए नहीं चलता कि किसी सीक्वेंस में इंडेक्स `0` पर इफ़ेक्ट मौजूद है।

निम्नलिखित उदाहरण एक शप बनाता है जिसमें मुख्य‑सीक्वेंस और इंटरऐक्टिव इफ़ेक्ट्स होते हैं, शप को लक्ष्य करने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर प्रत्येक सीक्वेंस को इटरनेट करता है।

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

यदि आपको केवल एक शप के इफ़ेक्ट्स चाहिए, तो पहले शप को नाम, प्लेसहोल्डर टाइप, या किसी स्थिर प्रॉपर्टी से पहचानें; फिर [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) को कॉल करें। यह मानना न रखें कि इंडेक्स `0` पर शप हमेशा इच्छित ऑब्जेक्ट होगा।

## **Work with Inherited Placeholder Effects**

एक सामान्य स्लाइड पर प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनिमेशन व्यवहार विरासत में ले सकता है। [Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `None`।

निम्न प्रस्तुति में, फुटर पर सामान्य स्लाइड में **Random Bars**, लेआउट स्लाइड में **Split**, और मास्टर स्लाइड में **Fly In** हैं।

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

अगला उदाहरण स्वयं प्लेसहोल्डर पदानुक्रम बनाता है। यह एक मास्टर प्लेसहोल्डर, एक लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [Shape.get_base_placeholder](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/get_base_placeholder/) को कॉल करने के बाद वापसी शप की जाँच की जाती है।

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

## **Change Animation Timing**

PowerPoint **Timing** डायलॉग [Timing](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/) प्रॉपर्टीज़ से मेल खाता है।

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** को [Timing.trigger_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/trigger_type/) से मैप किया जाता है।
- **Duration** को [Timing.duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/duration/) से मैप किया जाता है, सेकंड में।
- **Delay** को [Timing.trigger_delay_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/trigger_delay_time/) से मैप किया जाता है, सेकंड में।
- **Repeat** को [Timing.repeat_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_next_click/), या [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) से मैप किया जाता है।
- **Rewind when done playing** को [Timing.rewind](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/rewind/) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, उसे [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से टाइमिंग बदलता है, और परिणाम को सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/) रेफ़रेंस को रखकर अनावश्यक कलेक्शन इंडेक्स से बचा जाता है।

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

एक ही रिपीट मोड को जानबूझकर उपयोग करें। रिपीट काउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाला परिणाम मिल सकता है। रिपीट मोड बदलते समय पहले [Timing.repeat_until_next_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_next_click/) और [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) सेट करें, फिर [Timing.repeat_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_count/) सेट करें, क्योंकि किसी फ़्लैग को सेट करने से सक्रिय रिपीट मोड भी बदल जाता है।

## **Add and Extract Animation Sounds**

एक एनिमेशन इफ़ेक्ट [Effect.sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/sound/) के माध्यम से एंबेडेड ऑडियो को संदर्भित कर सकता है। [Effect.stop_previous_sound](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/stop_previous_sound/) किसी इफ़ेक्ट को पहले के इफ़ेक्ट द्वारा शुरू किए गए ऑडियो को रोकने के लिये कहता है।

### **Add a Sound to an Effect**

निम्नलिखित उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट्स बनाता है, पहली इफ़ेक्ट के लिए उस फ़ाइल को साउंड के रूप में एंबेड करता है, और दूसरी इफ़ेक्ट को साउंड को रोकने के लिए कॉन्फ़िगर करता है। यह [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए सीक्वेंस इंडेक्स की आवश्यकता नहीं होती।

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

### **Extract Embedded Effect Sounds**

निम्नलिखित उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरऐक्टिव दोनों सीक्वेंसेज़ को स्कैन करता है और प्रत्येक एंबेडेड इफ़ेक्ट साउंड को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME टाइप से चुना जाता है जो [Audio.content_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audio/content_type/) द्वारा उजागर किया गया है।

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

बड़ी ऑडियो ऑब्जेक्ट्स के लिए, [Audio.get_stream](https://reference.aspose.com/slides/hi/python-net/aspose.slides/audio/get_stream/) का उपयोग करके स्ट्रीम को फाइल में कॉपी करें, बजाय कि पूरे ऑब्जेक्ट को बाइट ऐरे में लोड करने के।

## **Set After-Animation Behavior**

**After animation** विकल्प निर्धारित करता है कि इफ़ेक्ट समाप्त होने के बाद शप के साथ क्या होना चाहिए।

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) एन्यूमरेशन शप को अनछुआ रहने, उसका रंग बदलने, एनीमेशन के बाद छुपाने, या अगली क्लिक पर छुपाने का समर्थन करता है। जब टाइप [AfterAnimationType.COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) हो, तो [Effect.after_animation_color](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/after_animation_color/) भी सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, उसके बाद‑एनीमेशन व्यवहार को लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से सेट करता है, और परिणाम को सहेजता है।

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

[AfterAnimationType.COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) से टाइप बदलने पर एफ़्टर‑एनीमेशन रंग सेटिंग साफ़ हो जाती है।

## **Animate Text**

टेक्स्ट एनीमेशन दो संबंधित नियंत्रण रखता है:

- [TextAnimation.build_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/textanimation/build_type/) निर्धारित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ स्तर पर।
- [Effect.animate_text_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/animate_text_type/) निर्धारित करता है कि टेक्स्ट एक बार, शब्द‑वार, या अक्षर‑वार दिखाई दे। [Effect.delay_between_text_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/delay_between_text_parts/) शब्दों या अक्षरों के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत है; नकारात्मक मान सेकंड में देरी है।

निम्न स्वतंत्र उदाहरण एक टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/buildtype/) पैराग्राफ‑बाय‑पैराग्राफ बिल्डिंग को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

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

पैराग्राफ‑बाय‑पैराग्राफ बॉक्स बनाने के लिए, [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/buildtype/) (या कोई अन्य पैराग्राफ लेवल) सेट करें। किसी एक पैराग्राफ को उसके स्वयं के इफ़ेक्ट के साथ लक्ष्य करने के लिए, उस [Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) ओवरलोड का उपयोग करें जो [IParagraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑लेवल उदाहरणों के लिए देखें [Animated Text](/slides/hi/python-net/animated-text/)।

## **Export and Compatibility Notes**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल बरकरार रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियां एनीमेशन नहीं चलातीं। जब मोशन दिखाना आवश्यक हो तो [HTML5 export](/slides/hi/python-net/export-to-html5/), एनिमेटेड GIF, या [video conversion](/slides/hi/python-net/convert-powerpoint-to-video/) का उपयोग करें।
- HTML5 के लिए, [Html5Options.animate_shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_shapes/) सक्षम करें और आवश्यकतानुसार [Html5Options.animate_transitions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_transitions/) भी।
- वीडियो रेंडरिंग कई सामान्य एंट्रेंस, इम्प्रेशन, एग्ज़िट, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करती है, लेकिन सभी PowerPoint इफ़ेक्ट्स समर्थित नहीं होते। वर्तमान [supported animations and effects](/slides/hi/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्षित Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुति का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य प्रस्तुति फ़ॉर्मैट से आयात किए गए इफ़ेक्ट्स फाइल में संरक्षित रह सकते हैं, लेकिन PowerPoint, HTML5, या वीडियो में अलग ढंग से रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा न करें; निर्यात परिणाम को सत्यापित करें।

## **FAQ**

**PowerPoint में एनीमेशन दिखता है लेकिन PDF में क्यों नहीं दिखता?**

PDF एक स्थिर फ़ॉर्मैट है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। जब मोशन बनाए रखना हो तो HTML5, एनिमेटेड GIF, या वीडियो में एक्सपोर्ट करें।

**वीडियो में इफ़ेक्ट अलग तरह से क्यों चलता है?**

वीडियो एक्सपोर्ट एनीमेशन को रेंडर करता है, न कि मूल PowerPoint व्यवहार को संग्रहीत करता है। कुछ उन्नत इफ़ेक्ट्स असमर्थित या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या शप को आगे या पीछे ले जाने से उसका एनीमेशन क्रम बदलता है?**

नहीं। शप z‑order ओवरलैप को नियंत्रित करता है, जबकि सीक्वेंस क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।