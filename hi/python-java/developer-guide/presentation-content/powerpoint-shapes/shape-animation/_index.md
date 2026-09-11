---
title: प्रस्तुतियों में Python via Java का उपयोग करके आकार एनीमेशन लागू करें
linktitle: आकार एनीमेशन
type: docs
weight: 60
url: /hi/python-java/shape-animation/
keywords:
- आकार
- एनीमेशन
- प्रभाव
- एनिमेटेड आकार
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
- प्रस्तुतीकरण
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ आकार एनीमेशन, टाइमिंग, ध्वनियों, एनीमेशन‑के‑बाद व्यवहार, और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Python via Java स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट में लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, और वैकल्पिक गुण जैसे ध्वनि या एनीमेशन‑के‑बाद व्यवहार होते हैं।

टाइमलाइन दो प्रकार के क्रम (sequences) रखती है:

- **मुख्य क्रम** स्लाइड आगे बढ़ने पर चलता है।
- **इंटरैक्टिव क्रम** तब शुरू होता है जब उसका ट्रिगर आकार क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल, और अन्य स्लाइड ऑब्जेक्ट्स [Shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/) से व्युत्पन्न होते हैं, आप अधिकांश स्लाइड सामग्री के लिए वही [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttype/) क्लास में सूचीबद्ध हैं।

## **आकार एनीमेशन जोड़ें**

एनीमेशन जोड़ने के लिए, स्लाइड की मुख्य क्रम प्राप्त करें और लक्ष्य आकार, इफ़ेक्ट प्रकार, उपप्रकार, तथा ट्रिगर के साथ [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) कॉल करें। वह इफ़ेक्ट जो दूसरे आकार पर क्लिक करने पर शुरू होता है, उसके लिए एक इंटरैक्टिव क्रम बनाएं जिसका ट्रिगर वह अन्य आकार हो।

निम्न उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ट्रिगर नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttriggertype/#OnClick) मुख्य क्रम में क्लिक या इंटरैक्टिव क्रम में ट्रिगर आकार पर क्लिक की प्रतीक्षा करता है।
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttriggertype/#WithPrevious) पूर्ववर्ती इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effecttriggertype/#AfterPrevious) पूर्ववर्ती इफ़ेक्ट समाप्त होने के बाद शुरू होता है।

एक चित्र, चार्ट, या अन्य आकार प्रकार को एनीमेट करने के लिए, `target_shape` के बजाय उस ऑब्जेक्ट को [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) को पास करें। चार्ट‑विशिष्ट समूह विकल्पों के लिए, देखें [Animated Charts](/slides/hi/python-java/animated-charts/)।

## **आकार एनीमेशन पढ़ें**

जब आपको लक्ष्य आकार पता हो, तो [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#getEffectsByShape) का उपयोग करें। प्रत्येक इफ़ेक्ट का निरीक्षण करने के लिए, मुख्य क्रम और प्रत्येक इंटरैक्टिव क्रम को सूचीबद्ध करें। सूची‑बद्ध करने से यह मानने से बचा जा सकता है कि क्रम में इंडेक्स `0` पर हमेशा कोई इफ़ेक्ट होता है।

निम्न उदाहरण एक आकार बनाता है जिसमें मुख्य‑क्रम और इंटरैक्टिव इफ़ेक्ट्स होते हैं, फिर आकार को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है, और अंत में स्लाइड के सभी क्रमों को सूची‑बद्ध करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

यदि आपको केवल एक ही आकार के लिए इफ़ेक्ट्स चाहिए, तो पहले आकार को नाम, प्लेसहोल्डर प्रकार, या किसी अन्य स्थिर गुण से पहचानें; फिर [Sequence.getEffectsByShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#getEffectsByShape) को कॉल करें। यह न मानें कि [ShapeCollection.get_Item](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#get_Item) इंडेक्स `0` पर हमेशा वांछित वस्तु होती है।

## **इनहेरिटेड प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार इनहेरिट कर सकता है। [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getBasePlaceholder) वह पेरेंट प्लेसहोल्डर लौटाता है, या कोई पेरेंट न होने पर `None`।

निम्न उदाहरण प्रस्तुति में, फुटर में सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** है।

![सामान्य स्लाइड पर फुटर एनीमेशन प्रभाव](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन प्रभाव](master-shape-animation.png)

अगला उदाहरण नई प्रस्तुति से प्लेसहोल्डर पदानुक्रम का उपयोग करता है। यह एक मास्टर प्लेसहोल्डर, एक लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक बार [Shape.getBasePlaceholder](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getBasePlaceholder) को कॉल करने से पहले परिणाम की जाँच की जाती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** संवाद [Timing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/) की प्रॉपर्टीज़ से मैप करता है।

![एनीमेशन इफ़ेक्ट के लिए PowerPoint Timing संवाद](shape-animation.png)

- **Start** को [Timing.getTriggerType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getTriggerType) से मैप किया जाता है।
- **Duration** को [Timing.getDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getDuration) से मैप किया जाता है, सेकंड में।
- **Delay** को [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getTriggerDelayTime) से मैप किया जाता है, सेकंड में।
- **Repeat** को [Timing.getRepeatCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatUntilNextClick), या [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) से मैप किया जाता है।
- **Rewind when done playing** को [Timing.getRewind](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRewind) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, टाइमिंग को [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से बदलता है, और परिणाम सहेजता है। लौटाए गए [Effect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/) संदर्भ को रखना अनावश्यक कलेक्शन इंडेक्स से बचाता है।

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

एक ही रिपीट मोड का जान‑बूझकर उपयोग करें। रिपीट काउंट को “until” फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित करने वाले परिणाम मिल सकते हैं। रिपीट मोड बदलते समय, पहले [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#setRepeatUntilNextClick) और [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) सेट करें, फिर [Timing.setRepeatCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#setRepeatCount) को कॉल करें, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड बदल सकता है।

## **एनीमेशन ध्वनियों को जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एंबेडेड ऑडियो को [Effect.getSound](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getSound) के माध्यम से संदर्भित कर सकता है। [Effect.setStopPreviousSound](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#setStopPreviousSound) इफ़ेक्ट को पहले शुरू हुए ध्वनि को रोकने के लिए बताता है।

### **इफ़ेक्ट में ध्वनि जोड़ें**

निम्न उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए ध्वनि के रूप में फ़ाइल एंबेड करता है, और दूसरी इफ़ेक्ट को ध्वनि को रोकने के लिये कॉन्फ़िगर करता है। यह [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए क्रम‑इंडेक्स की आवश्यकता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **एंबेडेड इफ़ेक्ट ध्वनियों को निकालेँ**

निम्न उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव क्रम दोनों को स्कैन करता है और प्रत्येक एंबेडेड इफ़ेक्ट ध्वनि को `extracted-animation-sounds` निर्देशिका में लिखता है। एक्सटेंशन ऑडियो MIME टाइप द्वारा निर्धारित किया जाता है, जिसे आप [Audio.getContentType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audio/#getContentType) से प्राप्त कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
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
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

बड़ी ऑडियो वस्तुओं के लिए, [Audio.getStream](https://reference.aspose.com/slides/hi/python-java/aspose.slides/audio/#getStream) का उपयोग करें और पूरी वस्तु को बाइट एरे में लोड करने के बजाय स्ट्रीम को फ़ाइल में कॉपी करें।

## **एनीमेशन‑के‑बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद आकार पर क्या हो।

![After animation सेटिंग्स दिखाते हुए PowerPoint Effect Options संवाद](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/afteranimationtype/) क्लास आकार को अपरिवर्तित रखने, उसका रंग बदलने, एनीमेशन के बाद छिपाने, या अगले क्लिक पर छिपाने का समर्थन करता है। जब प्रकार [AfterAnimationType.Color](https://reference.aspose.com/slides/hi/python-java/aspose.slides/afteranimationtype/#Color) होता है, तो साथ में [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getAfterAnimationColor) भी सेट करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसकी एनीमेशन‑के‑बाद व्यवहार सेट करता है, और परिणाम सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/hi/python-java/aspose.slides/afteranimationtype/#Color) से प्रकार बदलने पर एनीमेशन‑के‑बाद रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन के दो संबंधित नियंत्रण हैं:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textanimation/#getBuildType) निर्धारित करता है कि पैराग्राफ साथ‑साथ दिखें या पैराग्राफ‑स्तर पर।
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getAnimateTextType) निर्धारित करता है कि टेक्स्ट एक साथ, शब्द‑दर‑शब्द, या अक्षर‑दर‑अक्षर दिखाई दे। [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getDelayBetweenTextParts) शब्दों या अक्षरों के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत है; नकारात्मक मान सेकंड में देरी है।

निम्न स्वतंत्र उदाहरण एक टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType.AsOneObject](https://reference.aspose.com/slides/hi/python-java/aspose.slides/buildtype/#AsOneObject) पैराग्राफ‑दर‑पैराग्राफ निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पैराग्राफ‑दर‑पैराग्राफ बनाने के लिए, [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/hi/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (या कोई अन्य पैराग्राफ स्तर) सेट करें। एकल पैराग्राफ को उसके स्वयं के इफ़ेक्ट के साथ लक्षित करने के लिए, वह [Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) ओवरलोड उपयोग करें जो एक [Paragraph](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/) को स्वीकार करता है। पैराग्राफ‑स्तर के उदाहरणों के लिए देखें [Animated Text](/slides/hi/python-java/animated-text/)।

## **निर्यात और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल सुरक्षित रहता है, परन्तु अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थिर इमेज एनीमेशन नहीं चलाते। यदि आउटपुट में गति दिखानी है तो [HTML5 export](/slides/hi/python-java/export-to-html5/), एनीमेटेड GIF, या [video conversion](/slides/hi/python-java/convert-powerpoint-to-video/) उपयोग करें।
- HTML5 के लिए, [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateShapes) सक्षम करें और आवश्यक होने पर [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/html5options/#setAnimateTransitions) भी।
- वीडियो रेंडरिंग कई सामान्य एंट्रेंस, इम्पेसिस, एग्ज़िट, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, परन्तु सभी PowerPoint इफ़ेक्ट्स समर्थित नहीं हैं। वर्तमान [supported animations and effects](/slides/hi/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और महत्वपूर्ण प्रस्तुतियों को अपने लक्षित Aspose.Slides संस्करण के साथ परीक्षण करें।
- कस्टम इफ़ेक्ट्स और अन्य फ़ॉर्मेट से आयातित इफ़ेक्ट्स फ़ाइल में सुरक्षित हो सकते हैं, परन्तु PowerPoint, HTML5, या वीडियो में रेंडरिंग अलग हो सकती है। प्रभाव नाम पर ही भरोसा न करें; निर्यातित परिणाम का सत्यापन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक एनीमेशन PowerPoint में दिखता है लेकिन PDF में नहीं दिखता, क्यों?**

PDF स्थैतिक फ़ॉर्मेट है, इसलिए एनीमेशन और स्लाइड ट्रांज़िशन नहीं चलते। गति को संरक्षित करने के लिये HTML5, एनीमेटेड GIF, या वीडियो में निर्यात करें।

**एक इफ़ेक्ट वीडियो में अलग तरह से चलता क्यों है?**

वीडियो निर्यात एनीमेशन को रेंडर करता है, मूल PowerPoint व्यवहार नहीं स्टोर करता। कुछ उन्नत इफ़ेक्ट्स असहायक या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या आकार को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। आकार का z‑order ओवरलैप को नियंत्रित करता है, जबकि क्रम‑क्रम और ट्रिगर एनीमेशन प्लेबैक को नियंत्रित करते हैं। यदि प्लेबैक क्रम बदलना है तो टाइमलाइन को संशोधित करें।