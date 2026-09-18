---
title: Python के माध्यम से Java में कस्टम एनीमेशन बिहेवियर्स बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/python-java/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन बिहेवियर
- मोशन पाथ
- PowerPoint
- प्रेजेंटेशन
- Python
- Java
- Aspose.Slides
description: "PowerPoint प्रेज़ेंटेशन में Aspose.Slides for Python via Java का उपयोग करके कस्टम एनीमेशन बिहेवियर्स और संपादन योग्य मोशन पाथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनीमेशन बिहेवियर्स आपको एनीमेशन इफ़ेक्ट के भीतर व्यक्तिगत ऑपरेशन्स को नियंत्रित करने की सुविधा देते हैं, जैसे रंग बदलना, आकार को घुमाना, या संपादन योग्य मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि कैसे बिहेवियर्स बनाएँ और संयोजित करें, उनका टाइमिंग कॉन्फ़िगर करें, मौजूदा एनीमेशन्स का निरीक्षण और संशोधन करें, और यह सत्यापित करें कि उनके गुण सहेजने और प्रेज़ेंटेशन को फिर से खोलने पर भी बना रहें।

परिभाषित इफ़ेक्ट्स और क्लिक ट्रिगर्स के लिए देखें [शेप एनीमेशन](/slides/hi/python-java/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एनीमेशन का क्रम **Timeline → Sequence → Effect → Behaviors** है:

- [getTimeline](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getTimeline) मेथड स्लाइड टाइमलाइन लौटाता है, जिसमें मुख्य सीक्वेंस और इंटरैक्टिव सीक्वेंस होते हैं।
- एक [Sequence](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/) में इफ़ेक्ट्स होते हैं, जो विभिन्न शैप्स को लक्ष्य बना सकते हैं।
- एक [Effect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/) लक्ष्य शैप, प्रीसेट, सबटाइप और इफ़ेक्ट टाइमिंग को पहचानता है।
- [Effect.getBehaviors](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getBehaviors) द्वारा लौटाई गई कलेक्शन उन ऑपरेशन्स को समाहित करती है जो इफ़ेक्ट को लागू करती हैं: रंग बदलना, मूव करना, घुमाना, प्रॉपर्टी सेट करना, आदि।

## **व्यक्तिगत बिहेवियर्स बनाएं**

[Sequence.addEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sequence/#addEffect) को कॉल करके इफ़ेक्ट बनाएं और [getBehaviors](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getBehaviors) कलेक्शन तक पहुँचें। प्रीसेट इस कलेक्शन को स्वचालित रूप से भर सकता है। प्रीसेट का विस्तार करते समय उसके ऑपरेशन्स रखें, या जानबूझकर उन्हें बदलते समय [clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/#clear) का उपयोग करें।

[BehaviorFactory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/) नीचे दर्शाए गए आठ बिहेवियर प्रकार बनाता है। मोशन को [बिल्ड ए मोशन पाथ](#build-a-motion-path) में कवर किया गया है। प्रत्येक स्निपेट अपनी इम्पोर्ट्स को शामिल करता है और आवश्यकता होने पर JVM को शुरू करता है। जहाँ API को आवश्यकता होती है, Java पॉइंट ऑब्जेक्ट्स और एरेज़ JPype के माध्यम से बनाए जाते हैं। बाद के एडिटिंग उदाहरण बताते हैं कि कौन सी आउटपुट फ़ाइल उपयोग की गई है।

### **घूर्णन**

[createRotationEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createRotationEffect) का उपयोग करके घूर्णन इफ़ेक्ट बनाएं। [getBy](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotationeffect/#getBy) डिग्री में रिलेटिव एंगल निर्धारित करता है; [getFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotationeffect/#getFrom) और [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotationeffect/#getTo) एंडपॉइंट्स को निर्दिष्ट करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू करता है, उसके प्रीसेट ऑपरेशन्स को एक घूर्णन बिहेवियर से बदलता है, और उस ऑपरेशन को दो‑सेकंड की अवधि देता है। 90 डिग्री का रिलेटिव एंगल शैप की प्रारंभिक ओरिएंटेशन से चौथाई घुमाव दर्शाता है, इसलिए स्पष्ट प्रारंभिक एंगल की आवश्यकता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` में एक शैप और एक घूर्णन बिहेवियर है। नीचे दी गई कलेक्शन, टाइमिंग, और घूर्णन‑एडिटिंग उदाहरण इस फ़ाइल का उपयोग करते हैं।

### **स्केल**

[X/Y प्रतिशत] के साथ [createScaleEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createScaleEffect) का उपयोग करें: [getFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/scaleeffect/#getFrom) और [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/scaleeffect/#getTo) प्रारंभिक और अंतिम आकार का वर्णन करते हैं, जबकि [getBy](https://reference.aspose.com/slides/hi/python-java/aspose.slides/scaleeffect/#getBy) रिलेटिव परिवर्तन बताता है। यहाँ, 100 का अर्थ मूल आकार है।

उदाहरण दोनों आयामों को 100 % से 125 % तक दो सेकंड में बढ़ाता है। समान क्षैतिज और लंबवत प्रतिशत रखने से शैप के अनुपात बरकरार रहते हैं; अलग-अलग प्रतिशत एक आयाम को अधिक स्टेच करेंगे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **रंग**

[createColorEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createColorEffect) का उपयोग करके फ़िल को नीले से नारंगी में बदलें। [getFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/coloreffect/#getFrom) और [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/coloreffect/#getTo) रंग हैं; [getBy](https://reference.aspose.com/slides/hi/python-java/aspose.slides/coloreffect/#getBy) रंग का ऑफ़सेट है। [Behavior.getProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behavior/#getProperties) एनिमेट किए जा रहे एट्रिब्यूट को पहचानता है।

शैप का सॉलिड फ़िल नीला है, जो एनीमेशन की प्रारंभिक रंग से मेल खाता है। फ़िल‑कलर एट्रिब्यूट चुनने से बिहेवियर को पता चलता है कि शैप के किस भाग को बदलना है; केवल रंग एंडपॉइंट्स इस एट्रिब्यूट को नहीं दर्शाते। सहेजा गया इफ़ेक्ट दो‑सेकंड की ट्रांज़िशन को नारंगी में दर्शाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **फ़िल्टर**

[createFilterEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createFilterEffect) का उपयोग करके एक वाइप चुनें। [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filtereffect/#getSubtype), और [getReveal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filtereffect/#getReveal) क्रमशः फ़िल्टर, दिशा, और शैप को दिखाना या छिपाना निर्धारित करते हैं।

यह उदाहरण दो‑सेकंड की वाइप को कॉन्फ़िगर करता है जो दाएँ‑दिशा सबटाइप का उपयोग करके शैप को प्रकट करती है। फ़िल्टर सेटिंग्स इफ़ेक्ट के भीतर बिहेवियर से संबंधित हैं, इसलिए प्रीसेट की मूल ऑपरेशन्स हटाने के बाद इन्हें कॉन्फ़िगर किया जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **प्रॉपर्टी**

[createPropertyEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) का उपयोग करके अपारदर्शिता (opacity) को एनीमेट करें। [getFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/#getTo), और [getBy](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/#getBy) स्ट्रिंग्स हैं जिन्हें [getValueType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/#getValueType) और [getCalcMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/propertyeffect/#getCalcMode) द्वारा व्याख्यायित किया जाता है। सभी तीन को एक साथ सेट करने के बजाय एंडपॉइंट्स या रिलेटिव ऑफ़सेट चुनें।

यहाँ चयनित एट्रिब्यूट opacity है, और संख्यात्मक स्ट्रिंग्स 25 % opacity से पूर्ण opacity तक परिवर्तन दर्शाती हैं। रैखिक इंटरपोलेशन इन मानों के बीच क्रमिक परिवर्तन का वर्णन करता है। इसे किसी अन्य एट्रिब्यूट पर लागू करते समय उपयुक्त वैल्यू टाइप और एंडपॉइंट वैल्यू चुनें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **सेट**

[createSetEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createSetEffect) का उपयोग करके [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/seteffect/#getTo) द्वारा दृश्यता (visibility) सेट करें। सेट बिहेवियर एंडपॉइंट्स के बीच इंटरपोलेशन नहीं करता।

उदाहरण दृश्यता एट्रिब्यूट चुनता है और बिहेवियर चलने पर स्ट्रिंग `visible` असाइन करता है। इस न्यूनतम प्रेज़ेंटेशन में आयत पहले से ही दृश्य है, इसलिए असाइनमेंट अकेले स्पष्ट दृश्य परिवर्तन नहीं दिखा सकता। यह ऑपरेशन बड़े इफ़ेक्ट का हिस्सा बनाकर उपयोगी होता है जो शैप को छिपाने या दिखाने का समय भी नियंत्रित करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **कमांड**

[createCommandEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createCommandEffect) का उपयोग करके [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commandeffect/#getCommandString), और [getShapeTarget](https://reference.aspose.com/slides/hi/python-java/aspose.slides/commandeffect/#getShapeTarget) कॉन्फ़िगर करें। कार्य निर्देशिका में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [addAudioFrameEmbedded](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) के साथ एम्बेड करता है और ऑडियो फ्रेम पर प्ले कमांड जोड़ता है।

ऑडियो फ्रेम इफ़ेक्ट का टार्गेट और कमांड का टार्गेट दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; कमांड स्ट्रिंग अकेले यह निर्धारित नहीं करती कि कौनसे मीडिया ऑब्जेक्ट को नियंत्रित करना है। इफ़ेक्ट स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सेव करने पर कमांड `command.pptx` में संग्रहीत होती है; यह रिकॉर्डिंग नहीं चलाती। प्लेबैक को ऐसे स्लाइडशो प्लेयर की आवश्यकता है जो कमांड और उसके मीडिया टार्गेट को सपोर्ट करता हो।

## **बिहेवियर कलेक्शन का प्रबंधन**

[BehaviorCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/) [add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/#remove), और [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/#removeAt) को सपोर्ट करता है। यह उदाहरण `rotation.pptx` को खोलता है, स्केलिंग जोड़ता है, उसे घूर्णन से पहले रखता है, और घूर्णन को हटाता है। समान ऑब्जेक्ट को हटाकर फिर पुनःइन्सर्ट करने से उसकी स्टोर्ड पोज़िशन बदलती है, बिना कॉपी बनाए।

संपादन की श्रृंखला कलेक्शन को rotation–scale → scale–rotation → केवल scale में बदलती है। इंडेक्स वर्तमान कलेक्शन को दर्शाते हैं, इसलिए रीऑर्डरिंग के बाद घूर्णन का नया इंडेक्स हटाया जाता है। अंतिम एनेमरेशन यह पुष्टि करता है कि कौनसा बिहेवियर सहेजा जाएगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग शेष रहती है। कलेक्शन का क्रम स्वयं बिहेवियर्स को क्रमिक रूप से चलाने की गारंटी नहीं देता। सभी ऑपरेशन्स को बदलते समय ही कलेक्शन को क्लियर करें।

## **बिहेवियर टाइमिंग कॉन्फ़िगर करना**

[Behavior.getTiming](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behavior/#getTiming) [Timing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/) को उजागर करता है, जो [Effect.getTiming](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getTiming) से स्वतंत्र है। इफ़ेक्ट टाइमिंग बाहरी इफ़ेक्ट को शेड्यूल करती है; बिहेवियर टाइमिंग उसके अंदर के ऑपरेशन को वर्णित करती है।

### **अवधि, देरी, पुनरावृत्ति और एक्सेलेरेशन सेट करना**

`rotation.pptx` खोलें और अवधि ([getDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getDuration)) तथा ट्रिगर देरी ([getTriggerDelayTime](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getTriggerDelayTime)) सेकण्ड में सेट करें, फिर [setRepeatCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#setRepeatCount) से रिपीट काउंट कॉन्फ़िगर करें। [getAccelerate](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getAccelerate) और [getDecelerate](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getDecelerate) अवधि के अंश होते हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जो घूर्णन उदाहरण में बनाई गई थी, जहाँ पहला बिहेवियर घूर्णन है। यह उदाहरण केवल उस बिहेवियर की टाइमिंग बदलता है; उसका 90‑डिग्री एंगल अपरिवर्तित रहता है। एंगल और टाइमिंग को अलग‑अलग रखने से गति को पुनः‑निर्माण किए बिना समायोजित करना आसान होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

बिहेवियर दो‑सेकंड की अवधि, आधे‑सेकंड की देरी, और 3 की रिपीट काउंट उपयोग करता है। उसकी अवधि के पहले और आख़िरी 20 % क्रमशः एक्सेलेरेशन और डीसेलेरेशन के लिए प्रयोग होते हैं।

अन्य रिपीट नीतियों में [getRepeatDuration](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatUntilEndSlide), और [getRepeatUntilNextClick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getRepeatUntilNextClick) शामिल हैं; सभी को एक साथ सक्षम करने के बजाय एक नीति चुनें। [getAutoReverse](https://reference.aspose.com/slides/hi/python-java/aspose.slides/timing/#getAutoReverse) फॉरवर्ड पास के बाद एनीमेशन को पीछे की ओर चलाता है। एक्सेलेरेशन और डीसेलेरेशन निरंतर परिवर्तन पर लागू होते हैं, डिस्क्रीट असाइनमेंट या कमांड पर नहीं।

## **मोशन पाथ बनाना**

[createMotionEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorfactory/#createMotionEffect) का उपयोग करके मोशन बनाएं। इसके [getFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#getTo), और [getBy](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#getBy) प्रतिशत‑आधारित कोऑर्डिनेट्स या ऑफ़सेट्स का वर्णन करते हैं। संपादन योग्य मार्ग के लिए, एक [MotionPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpath/) बनाएं और उसे [MotionEffect.setPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#setPath) के साथ असाइन करें। [MotionPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpath/) पाथ कमांड्स को संग्रहीत करता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncommandpathtype/) ऑपरेशन चुनता है:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | One | शुरुआती स्थिति सेट करें। |
| LineTo | One | सीधी रेखा के साथ उसके एंडपॉइंट तक जाएँ। |
| CurveTo | Three | दो नियंत्रण बिंदुओं और एक एंडपॉइंट द्वारा परिभाषित क्यूबिक कर्व फ़ॉलो करें। |
| CloseLoop | None | शुरुआती स्थिति पर लौटें। |
| End | None | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpathpointstype/) बिंदु‑एडिटिंग विशेषताओं जैसे कॉर्नर या स्मूथ पॉइंट्स को दर्शाता है। यह कमांड टाइप को प्रतिस्थापित नहीं करता। नीचे की कर्व उदाहरण में कर्व पॉइंट टाइप, और सीधी रेखा सेगमेंट में कॉर्नर पॉइंट टाइप उपयोग करें।

पाथ कोऑर्डिनेट्स स्लाइड आयामों के सापेक्ष सामान्यीकृत होते हैं: X में 0.25 का विस्थापन स्लाइड की चौड़ाई का एक चौथाई दर्शाता है, 0.25 पॉइंट नहीं। सकारात्मक Y नीचे की ओर चलता है। एब्सोल्यूट कमांड पाथ कोऑर्डिनेट सिस्टम में स्थितियों को बताता है; रिलेटिव कमांड वर्तमान स्थिति से ऑफ़सेट बताता है। यह [getOrigin](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#getOrigin) से अलग है जो पाथ के रेफ़रेंस फ्रेम को चुनता है, और [getPathEditMode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioneffect/#getPathEditMode) जो शैप के मूव होने पर पाथ के मूव होने को नियंत्रित करता है।

### **सीधी पाथ बनाना**

एक मोशन बिहेवियर बनाएं जिसमें एक शुरुआती बिंदु, एक सीधा सेगमेंट, और एक एंड कमांड हो। [MotionPath.add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpath/#add) कमांड टाइप, उसके बिंदु, बिंदु टाइप, और रिलेटिव‑कोऑर्डिनेट फ़्लैग लेता है।

शुरुआती कमांड (0, 0) सेट करता है, और लाइन (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड चौड़ाई का एक चौथा क्षैतिज विस्थापन बनाता है। एंड कमांड के कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, मोशन बिहेवियर को इफ़ेक्ट में जोड़ने से वह रेक्टैंगल से जुड़ जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` में तीन पाथ कमांड वाले एक मोशन बिहेवियर है। नीचे के फ़ाइल‑एडिटिंग उदाहरण इस ज्ञात संरचना का उपयोग करते हैं।

### **एब्सोल्यूट और रिलेटिव कोऑर्डिनेट्स की तुलना**

ये दो पाथ ऑब्जेक्ट्स समान मार्ग को दर्शाते हैं। एब्सोल्यूट कमांड (0.3, 0.1) पर समाप्त होता है; रिलेटिव कमांड वर्तमान स्थिति में (0.1, 0.1) जोड़कर (0.2, 0) बनाता है।

दोनों पाथ एक ही प्रारंभिक बिंदु से शुरू होते हैं। रिलेटिव लाइन के लिए, वर्तमान स्थिति में X और Y ऑफ़सेट जोड़कर एंडपॉइंट प्राप्त करें; एब्सोल्यूट लाइन के लिए, सीधे एंडपॉइंट पढ़ें। फ़्लैग को बदले बिना कोऑर्डिनेट्स को न बदलें तो मार्ग अलग होगा।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

किसी भी पाथ को मोशन बिहेवियर को असाइन करें और प्रेज़ेंटेशन में उपयोग करें। अंतिम Boolean आर्ग्यूमेंट उस कमांड के लिए रिलेटिव कोऑर्डिनेट्स चुनता है।

### **लाइन को कर्व से बदलना**

`motion.pptx` खोलें और उसकी लाइन कमांड को एक क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु दें, फिर एंडपॉइंट।

शुरुआती स्थिति पहले की कमांड से आती है। पहले दो बिंदु कर्व को आकार देते हैं, तीसरा उसका गंतव्य है; ये क्रमिक गंतव्य नहीं हैं। कमांड टाइप, पॉइंट‑एडिटिंग टाइप, और पॉइंट एरे को साथ‑साथ अपडेट करने से सेगमेंट नई ज्यामिति के साथ सुसंगत रहता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`curve.pptx` की पाथ में अभी भी तीन कमांड हैं; उसका मध्य कमांड अब कर्व परिभाषित करता है।

## **सहेजे गए पाथ का निरीक्षण और संपादन**

प्रत्येक [MotionCmdPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncmdpath/) [getPoints](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncmdpath/#getPointsType), और [isRelative](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motioncmdpath/#isRelative) को उजागर करता है। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन‑कमांड पाथ का उपयोग करते हैं। मनचाहा इनपुट होने पर, प्रभाव को ढूँढें और इंडेक्स द्वारा संपादन से पहले कमांड टाइप्स और बिंदु संख्या की जाँच करें।

### **कमांड्स और कोऑर्डिनेट्स पढ़ना**

पाथ को बिना बदले पढ़ें। एंड और क्लोज‑लूप कमांड्स को बिंदुओं की आवश्यकता नहीं होती, इसलिए null बिंदु एरे की अनुमति रखें।

आउटपुट प्रत्येक संख्यात्मक कमांड टाइप को उसके रिलेटिव‑कोऑर्डिनेट फ़्लैग के साथ जोड़ता है, फिर बिंदुओं की सूची देता है। यह आपको बिंदु को ऑफ़सेट या एंडपॉइंट के रूप में पहचानने में मदद करता है, इससे पहले कि आप पाथ बदलें। कर्व तीन बिंदु दिखाएगा, जबकि इस फ़ाइल की सीधी लाइन केवल एक दिखाएगी।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

सूची में एक शुरुआती बिंदु, (0.25, 0) पर समाप्त एब्सोल्यूट लाइन, और एक एंड कमांड है।

### **एक एंडपॉइंट बदलना**

`motion.pptx` खोलें और लाइन के पॉइंट एरे को बदलकर उसके एंडपॉइंट को स्थानांतरित करें।

इनपुट फ़ाइल में, इंडेक्स 0 शुरुआती कमांड है और इंडेक्स 1 लाइन है। लाइन के एकल बिंदु को बदलने से उसका गंतव्य बदलेगा, लेकिन कमांड टाइप, टाइमिंग, या कलेक्शन में उसकी स्थिति नहीं बदलेगी। चूँकि कमांड एब्सोल्यूट कोऑर्डिनेट्स का उपयोग करता है, नया जोड़ा गया जोड़ा एक पोज़िशन निर्दिष्ट करता है, न कि अतिरिक्त ऑफ़सेट।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion-endpoint.pptx` की लाइन (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलना**

[insert](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpath/#insert) और [removeAt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/motionpath/#removeAt) का उपयोग करके `motion.pptx` में लाइन को बदलें। इन्सर्ट करने से पुरानी लाइन इंडेक्स 2 पर शिफ्ट हो जाएगी।

यह कमांड ऑब्जेक्ट को बदलने को दर्शाता है, न कि उसके मौजूदा कोऑर्डिनेट्स को संपादित करने को। इन्सर्शन के बाद कलेक्शन अस्थायी रूप से शुरुआती कमांड, नई लाइन, पुरानी लाइन, और एंड कमांड रखता है। इंडेक्स 2 को हटाने से पुरानी लाइन गायब हो जाती है और नई रूट जगह पर रहती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई लाइन (0.2, 0) पर समाप्त होती है और एंड कमांड आख़िरी है।

## **मौजूदा बिहेवियर को संशोधित और सत्यापित करना**

जब बिहेवियर का इंडेक्स अज्ञात हो, तो प्रकार द्वारा चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [RotationEffect](https://reference.aspose.com/slides/hi/python-java/aspose.slides/rotationeffect/) ढूँढता है, एंगल बदलता है, और पुनः खोलने के बाद सहेजे गये मान की जाँच करता है।

प्रकार जाँच लूप को उन बिहेवियर्स को स्किप करने देती है जो घूर्णन नहीं हैं। दूसरा लोड फ़ाइल को अलग प्रेज़ेंटेशन ऑब्जेक्ट में पढ़ता है, इसलिए तुलना सहेजे गये डेटा की होती है, न कि मेमोरी में अभी भी मौजूद मान की। यह उदाहरण अभी भी मानता है कि ज्ञात इफ़ेक्ट मुख्य सीक्वेंस में पहला है; प्रकार द्वारा चयन मनमाने प्रेज़ेंटेशन में सही इफ़ेक्ट नहीं खोज सकता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

आउटपुट `Rotation preserved: True` है। समान प्रकार‑जाँच पैटर्न को अन्य बिहेवियर्स पर लागू करें। पूर्ण संरक्षण जाँच के लिए लक्ष्य शैप, इफ़ेक्ट, बिहेवियर प्रकार और क्रम, टाइमिंग, तथा पाथ कमांड्स की तुलना करें। फ्लोटिंग‑पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अनजान एनीमेशन लेआउट वाले प्रेज़ेंटेशन के लिए, देखें [Read Shape Animations](/slides/hi/python-java/shape-animation/#read-shape-animations)।

## **बिहेवियर क्रम, प्रीसेट्स, और प्लेबैक**

[BehaviorCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behaviorcollection/) में क्रम प्रभाव के ऑपरेशन्स का संग्रहित क्रम है। यह हर बिहेवियर के स्वचालित रूप से पिछले का इंतज़ार करने वाले प्लेलिस्ट नहीं है। टाइमिंग और enclosing इफ़ेक्ट शेड्युलिंग तय करते हैं। बिहेवियर्स ओवरलैप हो सकते हैं, और समान प्रॉपर्टी पर ऑपरेशन्स [getAdditive](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behavior/#getAdditive) और [getAccumulate](https://reference.aspose.com/slides/hi/python-java/aspose.slides/behavior/#getAccumulate) के माध्यम से आपस में इंटरैक्ट कर सकते हैं। केवल कलेक्शन रीऑर्डरिंग से “move, then rotate” शेड्यूल न करें; जैसा कि [Shape Animation](/slides/hi/python-java/shape-animation/) में बताया गया है, स्पष्ट टाइमिंग या अलग‑अलग इफ़ेक्ट्स का उपयोग करें।

इफ़ेक्ट का [getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getType) और [getSubtype](https://reference.aspose.com/slides/hi/python-java/aspose.slides/effect/#getSubtype) उसका प्रीसेट वर्णित करते हैं। ये संपादित बिहेवियर ट्री का पूर्ण विवरण नहीं हैं। बिहेवियर्स को कस्टमाइज़ करने से पहले प्रीसेट और सबटाइप चुनें: प्रीसेट बदलने से कलेक्शन पुनर्निर्मित हो सकता है और आपके कस्टम ऑपरेशन्स हट सकते हैं। उदाहरण के लिए, कस्टमाइज़्ड Spin इफ़ेक्ट को Fade में बदलने से उसके घूर्णन बिहेवियर को सेट और फ़िल्टर बिहेवियर्स से बदल दिया जा सकता है। प्रीसेट या सबटाइप बदलने के बाद कलेक्शन को फिर से जांचें। प्रीसेट बिहेवियर्स को क्लियर करने से वह विजिबिलिटी या इनिशियलाइज़ेशन ऑपरेशन भी हट सकता है जो प्रीसेट को आवश्यक हैं। उदाहरण स्पष्ट रूप से विज़िबल शैप्स का उपयोग करके बिहेवियर्स को बदलते हैं; वे हर प्रीसेट की पूरी इम्प्लीमेंटेशन को पुनः‑निर्मित नहीं करते।

## **फ़ॉर्मेट संगतता**

संरक्षित बिहेवियर ट्री हर व्यूअर या एक्सपोर्ट रेंडरर में समान प्लेबैक की गारंटी नहीं देता। सहेजे गये डेटा और रेंडर किया गया आउटपुट अलग‑अलग जाँचें।

| फ़ॉर्मेट या आउटपुट | क्या जाँचें |
| --- | --- |
| PPTX | इन उदाहरणों के लिए प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। पुनः खोलें, एडिटेबल बिहेवियर ट्री की पुष्टि करें, फिर इच्छित PowerPoint संस्करण में प्लेबैक जाँचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से भिन्न हो सकता है। अलग‑सेव‑और‑पुनः‑ओपन साइकिल और प्लेबैक टेस्ट करें; PPTX आउटपुट की सफलता से सभी कस्टम संयोजनों का समर्थन मानें नहीं। |
| PDF, PNG, JPEG, और अन्य स्थैतिक स्लाइड इमेज | स्थैतिक स्लाइड प्रतिनिधित्व रखता है, न कि प्ले‑एबल बिहेवियर टाइमलाइन या अंतिम एनीमेशन फ्रेम की गारंटी। |
| [HTML5](/slides/hi/python-java/export-to-html5/) | यदि एक्सपोर्ट विकल्पों में शैप एनीमेशन सक्षम हो तो सपोर्टेड एनीमेशन चल सकता है। ब्राउज़र में कस्टम संयोजनों को टेस्ट करें। |
| [Animated GIF](/slides/hi/python-java/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ्रेम्स को संग्रहीत करता है, एडिटेबल बिहेवियर्स या क्लिक‑ट्रिगर्ड इंटरैक्शन नहीं। वास्तविक रेंडर किया गया मोशन जाँचें। |
| [Video](/slides/hi/python-java/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम्स को रेंडर करके वीडियो में एन्कोड करता है। समर्थन सीमित है रेंडरर के [supported animations and effects](/slides/hi/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड्स और इंटरैक्टिव इवेंट्स एडिटेबल टाइमलाइन नहीं बनते। |

## **अक्सर पूछे जाने वाले प्रश्न**

**मेरे इफ़ेक्ट में बिहेवियर्स क्यों मौजूद हैं जब मैंने अभी कुछ नहीं जोड़ा?**

प्रीडिफाइंड इफ़ेक्ट बनाते समय उसके अन्तर्निहित ऑपरेशन्स बन सकते हैं। विस्तार या प्रतिस्थापन से पहले उन्हें निरीक्षण करें।

**बिहेवियर को शुरुआत में ले जाने से क्या वह पहले चलेगा?**

ज़रूरी नहीं। कलेक्शन क्रम टाइमिंग का विकल्प नहीं है। देरी, अवधि, और समान प्रॉपर्टी पर ऑपरेशन्स के बीच इंटरैक्शन की जाँच करें।

**एंड कमांड के कोई बिंदु क्यों नहीं होते?**

यह पाथ के अंत को दर्शाता है और इसके लिए कोऑर्डिनेट्स की आवश्यकता नहीं होती। फ़ाइल से पढ़े गए पाथ का निरीक्षण करते समय null बिंदु एरे की जाँच करें।

**क्या सफल राउंड‑ट्रिप प्लेबैक की पुष्टि के लिए पर्याप्त है?**

नहीं। पुनः‑ओपन केवल उन प्रॉपर्टीज़ की संरक्षकता की पुष्टि करता है जिन्हें आपने जाँचा। स्लाइडशो प्लेयर या एनीमेटेड एक्सपोर्ट को अलग‑से टेस्ट करके दृश्य व्यवहार की पुष्टि करें।