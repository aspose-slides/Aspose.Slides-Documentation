---
title: Python में कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/python-net/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- मोशन पाथ
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint प्रस्तुतियों में कस्टम एनीमेशन व्यवहार और संपादन योग्य मोशन पाथ को बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **अवलोकन**

कस्टम एनीमेशन व्यवहार आपको एनीमेशन प्रभाव के भीतर व्यक्तिगत संचालन को नियंत्रित करने की अनुमति देते हैं, जैसे कि रंग बदलना, आकार को घुमाना, या संपादनीय मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि व्यवहारों को कैसे बनाया और संयोजित किया जाए, उनके टाइमिंग को कैसे कॉन्फ़िगर किया जाए, मौजूदा एनीमेशन की जांच और संशोधन कैसे किया जाए, और यह सत्यापित किया जाए कि उनकी गुणधर्म प्रस्तुति को सहेजने और फिर खोलने पर भी बने रहें।

पूर्वनिर्धारित प्रभावों और क्लिक ट्रिगर्स के लिए, देखें [Shape Animation](/slides/hi/python-net/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एक एनीमेशन इस प्रकार व्यवस्थित किया गया है **Timeline → Sequence → Effect → Behaviors**:

- स्लाइड का [timeline](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/timeline/) उसका मुख्य अनुक्रम और इंटरैक्टिव अनुक्रम रखता है।
- एक [Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) प्रभावों को रखता है, संभावित रूप से विभिन्न आकारों को लक्ष्य बनाते हुए।
- एक [Effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/) लक्ष्य आकार, प्रीसेट, सबटाइप, और प्रभाव टाइमिंग को पहचानता है।
- [Effect.behaviors](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/behaviors/) वह ऑपरेशन्स रखता है जो प्रभाव को लागू करता है: रंग बदलना, स्थानांतरित करना, घुमाना, गुण सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

[Sequence.add_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/add_effect/) को कॉल करके एक प्रभाव बनाएं और उसकी [behaviors](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/behaviors/) संग्रह तक पहुँचें। एक प्रीसेट इस संग्रह को स्वतः भर सकता है। प्रीसेट का विस्तार करते समय उसके ऑपरेशन्स को रखें, या उन्हें जानबूझकर बदलते समय [clear](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/clear/) का उपयोग करें।

[BehaviorFactory](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/) नीचे दिखाए गए आठ व्यवहार प्रकार बनाता है। मोशन को [Build a Motion Path](#build-a-motion-path) में कवर किया गया है। प्रत्येक निर्माण उदाहरण एक पूर्ण प्रोग्राम है; बाद के संपादन उदाहरण बताते हैं कि वे किस आउटपुट फ़ाइल का उपयोग करते हैं।

### **घूर्णन**

[create_rotation_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) का उपयोग करके घूर्णन बनाएं। [by](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect/by/) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [from_address](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect/from_address/) और [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect/to/) अंतबिंदुओं को निर्दिष्ट करते हैं।

उदाहरण एक Spin प्रभाव से शुरू होता है, उसके प्रीसेट ऑपरेशन्स को एक घूर्णन व्यवहार से बदलता है, और उस ऑपरेशन को दो‑सेकंड की अवधि देता है। 90 डिग्री का सापेक्ष कोण आकार की प्रारंभिक अभिविन्यास से एक चौथाई मोड़ को दर्शाता है, इसलिए स्पष्ट प्रारंभिक कोण की आवश्यकता नहीं होती।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` में एक आकार और एक घूर्णन व्यवहार है। संग्रह, टाइमिंग, और घूर्णन‑संपादन उदाहरण नीचे इस फ़ाइल का उपयोग करते हैं।

### **मापन**

[create_scale_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) को X/Y प्रतिशत के साथ उपयोग करें: [from_address](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/from_address/) और [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/to/) प्रारंभिक और अंतिम आकार का वर्णन करते हैं, जबकि [by](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/scaleeffect/by/) सापेक्ष परिवर्तन को दर्शाता है। यहाँ 100 मूल आकार का मतलब है।

उदाहरण दोनों आयामों को 100 % से 125 % तक दो सेकंड में बढ़ाता है। समान क्षैतिज और वर्टिकल प्रतिशत का उपयोग आकार के अनुपात को बनाए रखता है; अलग‑अलग प्रतिशत एक आयाम को दूसरे से अधिक खींचेंगे।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **रंग**

[create_color_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) का उपयोग करके भराव को नीले से नारंगी में बदलें। [from_address](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/from_address/) और [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/to/) रंग हैं; [by](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/coloreffect/by/) रंग ऑफ़सेट है। [Behavior.properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/properties/) एनिमेट किए जा रहे गुण को पहचानता है।

आकार का ठोस भराव नीला आरम्भ किया गया है, जो एनीमेशन के प्रारंभिक रंग से मेल खाता है। भराव‑रंग गुण चुनने से व्यवहार को बताता है कि आकार के किस भाग को बदलना है; केवल रंग अंतबिंदु उस गुण की पहचान नहीं करते। सहेजा गया प्रभाव दो‑सेकंड में नारंगी में परिवर्तन को दर्शाता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **फ़िल्टर**

[create_filter_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) का उपयोग करके एक वाइप चुनें। [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/subtype/), और [reveal](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/filtereffect/reveal/) क्रमशः फ़िल्टर, दिशा, और आकार को प्रकट या छुपाने को निर्दिष्ट करते हैं।

यह उदाहरण दो‑सेकंड की वाइप को स्थापित करता है जो दायें‑दिशा सबटाइप का उपयोग करके आकार को प्रकट करता है। फ़िल्टर सेटिंग्स प्रभाव के भीतर व्यवहार का हिस्सा हैं, इसलिए वे प्रीसेट के मूल ऑपरेशन्स को हटाने के बाद कॉन्फ़िगर की जाती हैं।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **गुण**

[create_property_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) का उपयोग करके अपारदर्शिता को एनिमेट करें। [from_address](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/to/), और [by](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/by/) स्ट्रिंग्स हैं जिन्हें [value_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/value_type/) और [calc_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/propertyeffect/calc_mode/) द्वारा व्याख्यित किया जाता है। सभी तीन को बिना चयन के सेट करने के बजाय अंतबिंदु या सापेक्ष ऑफ़सेट चुनें।

यहाँ चयनित गुण अपारदर्शिता है, और संख्यात्मक स्ट्रिंग्स 25 % अपारदर्शिता से पूरी अपारदर्शिता तक परिवर्तन को दर्शाती हैं। रैखिक अंतरफ़लक उन मानों के बीच क्रमिक परिवर्तन का वर्णन करता है। इस उदाहरण को किसी अन्य गुण पर लागू करने पर उपयुक्त value_type और अंतबिंदु मान चुनें।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **सेट**

[create_set_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) का उपयोग करके [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/seteffect/to/) के माध्यम से दृश्यता असाइन करें। सेट व्यवहार अंतबिंदुओं के बीच अंतरफ़लक नहीं करता।

उदाहरण दृश्यता गुण चुनता है और व्यवहार चलने पर स्ट्रिंग `visible` असाइन करता है। इस न्यूनतम प्रस्तुति में आयत पहले से ही दृश्यमान है, इसलिए असाइनमेंट स्वयं में स्पष्ट दृश्य परिवर्तन नहीं लाता। यह ऑपरेशन बड़े प्रभाव का हिस्सा बनाकर उपयोगी है जो यह भी नियंत्रित करता है कि कब आकार छुपे या दिखाई दे।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **कमांड**

[create_command_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) का उपयोग करें और [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/command_string/), और [shape_target](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/commandeffect/shape_target/) को कॉन्फ़िगर करें। कार्यशील निर्देशिका में `sample.wav` नाम की WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [add_audio_frame_embedded](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) से एम्बेड करता है और ऑडियो फ्रेम पर प्ले कमांड जोड़ता है।

ऑडियो फ्रेम प्रभाव का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; कमांड स्ट्रिंग स्वयं यह नहीं दर्शाती कि कौन सा मीडिया ऑब्जेक्ट नियंत्रित किया जाना चाहिए। प्रभाव को स्लाइडशो के दौरान क्लिक पर शुरू करने के लिए कॉन्फ़िगर किया गया है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

सहेजने से कमांड `command.pptx` में संग्रहित होता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिए ऐसा स्लाइडशो प्लेयर चाहिए जो कमांड और उसके मीडिया लक्ष्य को समर्थन करता हो।

## **व्यवहार संग्रह का प्रबंधन**

[BehaviorCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/) में [add](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/remove/), और [remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/remove_at/) समर्थित हैं। यह उदाहरण `rotation.pptx` खोलता है, स्केलिंग जोड़ता है, उसे घूर्णन से पहले रखता है, और घूर्णन को हटाता है। हटाने और उसी ऑब्जेक्ट को पुनः सम्मिलित करने से उसकी संग्रहित स्थिति बदलती है बिना प्रतिलिपि बनाए।

संपादनों की क्रमबद्धता संग्रह को rotation–scale से scale–rotation तक, फिर केवल scale तक बदलती है। सूचकांक वर्तमान संग्रह को दर्शाते हैं, इसलिए हटाने में क्रमबद्ध करने के बाद घूर्णन का नया सूचकांक उपयोग होता है। अंतिम गणना दर्शाती है कि कौन सा व्यवहार सहेजा जाएगा।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग बची है। संग्रह क्रम स्वयं व्यवहारों को क्रमवार चलाने का आदेश नहीं देता। सभी ऑपरेशन्स को बदलते समय ही संग्रह को साफ़ करें।

## **व्यवहार टाइमिंग कॉन्फ़िगर करें**

[Behavior.timing](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/timing/) में [Timing](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/) उजागर होता है, जो [Effect.timing](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/timing/) से स्वतंत्र है। इफ़ेक्ट टाइमिंग सम्मिलित इफ़ेक्ट को शेड्यूल करता है; व्यवहार टाइमिंग उसके भीतर की ऑपरेशन को वर्णित करता है।

### **अवधि, विलंब, दोहराव और त्वरण सेट करें**

`rotation.pptx` खोलें और सेकंड में [duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/duration/) तथा [trigger_delay_time](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/trigger_delay_time/) सेट करें, फिर [repeat_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_count/) कॉन्फ़िगर करें। [accelerate](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/accelerate/) और [decelerate](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/decelerate/) अवधि के अंश हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वही है जो घूर्णन उदाहरण में बनाई गई थी, जहाँ पहला व्यवहार घूर्णन के रूप में ज्ञात है। यह उदाहरण केवल उसी व्यवहार की टाइमिंग बदलता है; उसका 90‑डिग्री कोण अपरिवर्तित रहता है। कोण और टाइमिंग को अलग रखना गति को पुनर्निर्माण किए बिना समायोजित करना आसान बनाता है।

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

व्यवहार दो‑सेकंड की अवधि, आधा‑सेकंड विलंब, और 3 दोहराव का उपयोग करता है। उसकी अवधि के पहले और अंतिम 20 % अनुक्रम में क्रमशः त्वरण और मंदन के लिए उपयोग होते हैं।

अन्य दोहराव नीतियों में [repeat_duration](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), और [repeat_until_next_click](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/repeat_until_next_click/) शामिल हैं; सभी को एक साथ सक्षम करने के बजाय एक नीति चुनें। [auto_reverse](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/timing/auto_reverse/) आगे के पारित होने के बाद एनीमेशन को उल्टा चलाता है। त्वरण और मंदन निरंतर परिवर्तन पर लागू होते हैं, न कि विविक्त असाइनमेंट या कमांड पर।

## **मोशन पाथ बनाएं**

[create_motion_effect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) का उपयोग करके मोशन बनाएं। इसकी [from_address](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/to/), और [by](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/by/) प्रतिशत‑आधारित निर्देशांक या ऑफ़सेट का वर्णन करते हैं। संपादन‑योग्य मार्ग के लिए एक [MotionPath](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpath/) बनाएं और उसे [MotionEffect.path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/path/) को असाइन करें। [MotionPath](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpath/) पाथ कमांड्स को संग्रहीत करता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncommandpathtype/) ऑपरेशन चुनता है:

| Command | Points | Meaning |
| --- | --- | --- |
| MOVE_TO | One | प्रारंभिक स्थिति निर्धारित करें। |
| LINE_TO | One | सीधी रेखा खंड के अंत तक ले जाएँ। |
| CURVE_TO | Three | दो नियंत्रण बिंदुओं और एक अंतबिंदु द्वारा परिभाषित क्यूबिक कर्व का अनुसरण करें। |
| CLOSE_LOOP | None | प्रारंभिक स्थिति पर लौटें। |
| END | None | पाथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpathpointstype/) बिंदु‑संपादन विशेषताओं का वर्णन करता है, जैसे कोना या स्मूद बिंदु। यह कमांड प्रकार को प्रतिस्थापित नहीं करता। नीचे के कर्व उदाहरण के लिए कर्व बिंदु प्रकार और सीधी रेखा खंडों के लिए कोना बिंदु प्रकार का उपयोग करें।

पाथ निर्देशांक स्लाइड आयामों के सापेक्ष सामान्यीकृत होते हैं: X विस्थापन 0.25 स्लाइड की चौड़ाई का एक चौथाई दर्शाता है, न कि 0.25 बिंदु। सकारात्मक Y नीचे की दिशा में चलता है। निरपेक्ष कमांड पाथ निर्देशांक प्रणाली में स्थितियों को निर्दिष्ट करते हैं; सापेक्ष कमांड वर्तमान स्थिति से ऑफ़सेट निर्दिष्ट करते हैं। यह [origin](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/origin/) से अलग है, जो पाथ के संदर्भ फ्रेम का चयन करता है, और [path_edit_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioneffect/path_edit_mode/) से आकार के स्थानांतरित होने पर पाथ की गति नियंत्रित होती है।

### **सीधी पाथ बनाएं**

एक मोशन व्यवहार बनाएं जिसमें प्रारंभिक बिंदु, एक सीधा खंड, और एक अंत कमांड हो। [MotionPath.add](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpath/add/) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और सापेक्ष‑निर्देशांक फ़्लैग लेता है।

प्रारंभिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड की चौड़ाई का एक चौथाई क्षैतिज विस्थापन प्राप्त करता है। अंत कमांड में कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, मोशन व्यवहार को प्रभाव में जोड़ने से वह रेक्टेंगल से जुड़ जाता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` में तीन पाथ कमांड के साथ एक मोशन व्यवहार है। नीचे के फ़ाइल‑संपादन उदाहरण इसी संरचना का उपयोग करेंगे।

### **निरपेक्ष और सापेक्ष निर्देशांक की तुलना करें**

ये दो पाथ ऑब्जेक्ट एक ही मार्ग का वर्णन करते हैं। निरपेक्ष कमांड (0.3, 0.1) पर समाप्त होता है; सापेक्ष कमांड (0.1, 0.1) को वर्तमान स्थिति (0.2, 0) में जोड़कर अंतप्राप्ति देता है।

दोनों पाथ समान प्रारंभिक स्थिति से शुरू होते हैं। सापेक्ष रेखा में X और Y ऑफ़सेट को वर्तमान स्थिति में जोड़कर अंत बिंदु प्राप्त करें; निरपेक्ष रेखा में अंत बिंदु सीधे पढ़ें। फ़्लैग को बिना निर्देशांक परिवर्तित किए बदलने से अलग मार्ग बन जाएगा।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

किसी भी पाथ को मोशन व्यवहार को असाइन करके प्रस्तुति में उपयोग करें। अंतिम बूलियन तर्क उस कमांड के लिए सापेक्ष निर्देशांक चुनता है।

### **रेखा को कर्व से बदलें**

`motion.pptx` खोलें और उसकी रेखा कमांड को क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु दें, फिर अंत बिंदु।

प्रारंभिक स्थिति पूर्ववर्ती कमांड से आती है। पहले दो बिंदु कर्व का आकार देते हैं, जबकि तीसरा उसका अंत बिंदु है; वे क्रमागत गंतव्य नहीं हैं। कमांड प्रकार, बिंदु‑संपादन प्रकार, और बिंदु सरणी को एक साथ अपडेट करने से खंड नई ज्यामिति के साथ संगत रहता है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

`curve.pptx` में पाथ अभी भी तीन कमांड रखता है; उसकी मध्य कमांड अब कर्व को परिभाषित करती है।

## **सहेजे गए पाथ का निरीक्षण और संपादन करें**

प्रत्येक [MotionCmdPath](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncmdpath/) में [points](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncmdpath/points_type/), और [is_relative](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motioncmdpath/is_relative/) उजागर होते हैं। नीचे के उदाहरण `motion.pptx` में ज्ञात तीन‑कमांड पाथ का उपयोग करते हैं। मनमाना इनपुट के लिए प्रभाव को ढूँढ़ें और संपादन से पहले कमांड प्रकार और बिंदु गिनती की जाँच करें।

### **कमांड और निर्देशांक पढ़ें**

पाथ को बिना बदले पढ़ें। अंत और बंद‑लूप कमांड को बिंदुओं की आवश्यकता नहीं होती, इसलिए `None` बिंदु सरणी की अनुमति दें।

आउटपुट प्रत्येक कमांड को उसके सापेक्ष‑निर्देशांक फ्लैग के साथ जोड़ता है, फिर उसके बिंदु सूचीबद्ध करता है। यह आपको बिंदु को ऑफ़सेट या अंतबिंदु के रूप में पहचानने में मदद करता है, उसके बाद पाथ को संशोधित किया जा सकता है। कर्व में तीन बिंदु होते हैं, जबकि इस फ़ाइल में सीधी रेखा में केवल एक बिंदु होता है।

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

सूची में एक प्रारंभिक बिंदु, (0.25, 0) पर समाप्त निरपेक्ष रेखा, और अंत कमांड दिखाए गए हैं।

### **अंत बिंदु बदलें**

`motion.pptx` खोलें और रेखा के बिंदु सरणी को बदलकर उसका अंत बिंदु स्थानांतरित करें।

इनपुट फ़ाइल में, सूचकांक 0 प्रारंभिक कमांड है और सूचकांक 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसका गंतव्य बदल जाता है, लेकिन कमांड प्रकार, टाइमिंग, या संग्रह में उसकी स्थिति नहीं बदलती। चूँकि कमांड निरपेक्ष निर्देशांक उपयोग करता है, नया जोड़ा गया जोड़ा एक स्थिति को निर्दिष्ट करता है, न कि अतिरिक्त ऑफ़सेट को।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

`motion-endpoint.pptx` में रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट को बदलें**

[insert](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpath/insert/) और [remove_at](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/motionpath/remove_at/) का उपयोग करके `motion.pptx` में रेखा को बदलें। सम्मिलन पुरानी रेखा को सूचकांक 2 पर ले जाता है।

यह कमांड ऑब्जेक्ट को बदलने का प्रदर्शन करता है, न कि उसके मौजूदा निर्देशांक को संपादित करने का। सम्मिलन के बाद, संग्रह अस्थायी रूप से प्रारंभिक कमांड, नई रेखा, पुरानी रेखा, और अंत कमांड रखता है। सूचकांक 2 को हटाने से पुरानी रेखा हट जाती है और नई मार्ग जगह पर रहती है।

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और अंत कमांड अंतिम में रहता है।

## **मौजूदा व्यवहार को संशोधित और सत्यापित करें**

जब व्यवहार का सूचकांक अज्ञात हो, प्रकार के आधार पर चयन करें। यह उदाहरण `rotation.pptx` खोलता है, उसका [RotationEffect](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/rotationeffect/) ढूँढ़ता है, कोण बदलता है, और पुनः खोलने के बाद सहेजे गए मान की जाँच करता है।

प्रकार जाँच लूप को उन व्यवहारों को छोड़ने देती है जो घूर्णन नहीं हैं। दूसरी लोड सहेजी गई फ़ाइल को अलग प्रस्तुति ऑब्जेक्ट में पढ़ती है, इसलिए तुलना स्मृति में अभी रखे मान के बजाय स्थायित्व डेटा की जाँच करती है। यह उदाहरण अभी भी मानता है कि ज्ञात प्रभाव मुख्य अनुक्रम में पहला है; प्रकार के आधार पर व्यवहार का चयन मनमानी प्रस्तुति में सही प्रभाव नहीं ढूँढ़ता।

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

आउटपुट `Rotation preserved: True` है। समान प्रकार‑जाँच पैटर्न को अन्य व्यवहारों पर लागू करें। पूर्ण संरक्षण जाँच के लिए लक्ष्य आकार, प्रभाव, व्यवहार प्रकार और क्रम, टाइमिंग, तथा पाथ कमांड की तुलना करें। फ्लोटिंग‑पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अज्ञात एनीमेशन लेआउट वाले प्रस्तुति के लिए, मुख्य और इंटरैक्टिव अनुक्रमों के पार traversal के लिए देखें [Read Shape Animations](/slides/hi/python-net/shape-animation/#read-shape-animations)।

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

[BehaviorCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behaviorcollection/) में क्रम प्रभाव के ऑपरेशन्स का संग्रहित क्रम है। यह एक प्लेलिस्ट नहीं है जहाँ प्रत्येक व्यवहार स्वतः पूर्ववर्ती का इंतज़ार करता हो। टाइमिंग और सम्मिलित प्रभाव शेड्यूलिंग तय करते हैं। व्यवहार ओवरलैप कर सकते हैं, और समान गुण पर ऑपरेशन्स [additive](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/additive/) और [accumulate](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/behavior/accumulate/) के माध्यम से परस्पर क्रिया कर सकते हैं। केवल संग्रह क्रम को बदलकर “move, then rotate” शेड्यूल न करें; जैसा कि [Shape Animation](/slides/hi/python-net/shape-animation/) में बताया गया है, स्पष्ट टाइमिंग या अलग‑अलग प्रभाव उपयोग करें।

प्रभाव का [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/type/) और [subtype](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effect/subtype/) उसके प्रीसेट का वर्णन करते हैं। वे संपादित व्यवहार वृक्ष का पूर्ण वर्णन नहीं हैं। व्यवहारों को अनुकूलित करने से पहले प्रीसेट और सबटाइप चुनें: प्रीसेट बदलने से संग्रह पुनः निर्मित हो सकता है और आपके कस्टम ऑपरेशन्स हट सकते हैं। उदाहरण के लिए, कस्टमाइज्ड Spin प्रभाव को Fade में बदलने से उसका घूर्णन व्यवहार सेट और फ़िल्टर व्यवहारों से बदल सकता है। प्रीसेट या सबटाइप बदलने के बाद संग्रह को फिर से जांचें। प्रीसेट व्यवहारों को साफ़ करने से वह दृश्यता या आरम्भिक ऑपरेशन्स भी हट सकते हैं जो प्रीसेट को आवश्यक होते हैं। उदाहरण स्पष्ट रूप से दृश्यमान आकारों का उपयोग करते हैं और व्यवहारों को बदलते हैं; वे प्रत्येक प्रीसेट की पूरी कार्यान्वयन को पुनर्निर्मित नहीं करते।

## **फ़ॉर्मेट संगतता**

संरक्षित व्यवहार वृक्ष हर व्यूअर या निर्यात रेनडरर में समान प्लेबैक की गारंटी नहीं देता। सहेजे गए डेटा और रेंडरित आउटपुट को अलग‑अलग जांचें।

| Format or output | What to verify |
| --- | --- |
| PPTX | इन उदाहरणों के लिए प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। इसे पुनः खोलें ताकि संपादन योग्य व्यवहार वृक्ष की पुष्टि हो, फिर इच्छित PowerPoint संस्करण में प्लेबैक जांचें। |
| PPT | लेगेसी बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। अलग‑अलग सहेज‑और‑पुनः‑खोल चक्र और प्लेबैक का परीक्षण करें; सफल PPTX आउटपुट से सभी कस्टम संयोजन के समर्थन का अनुमान न लगाएँ। |
| PDF, PNG, JPEG, और अन्य स्थैतिक स्लाइड छवियाँ | स्थैतिक स्लाइड प्रतिनिधित्व रखती हैं, न कि चलाने योग्य व्यवहार टाइमलाइन या अंतिम एनीमेशन फ़्रेम। |
| [HTML5](/slides/hi/python-net/export-to-html5/) | निर्यात विकल्पों में shape animation सक्षम होने पर समर्थित एनीमेशन चल सकती हैं। ब्राउज़र में कस्टम संयोजनों का परीक्षण करें। |
| [Animated GIF](/slides/hi/python-net/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ़्रेम संग्रहीत करता है, न कि संपादन योग्य व्यवहार या क्लिक‑ट्रिगर इंटरैक्शन। वास्तविक रेंडर किया गया मोशन जांचें। |
| [Video](/slides/hi/python-net/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम रेंडर करता है और उन्हें वीडियो के रूप में एन्कोड करता है। समर्थन रेनडरर के [supported animations and effects](/slides/hi/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) तक सीमित है; कमांड और इंटरैक्टिव इवेंट संपादन योग्य टाइमलाइन नहीं बनते। |

## **FAQ**

**मेरे प्रभाव में व्यवहार क्यों मौजूद हैं जबकि मैंने कुछ नहीं जोड़ा?**

एक पूर्वनिर्धारित प्रभाव बनाते समय उसके मूल ऑपरेशन्स बन सकते हैं। उन्हें विस्तारित करने या व्यवहारों को बदलने का निर्णय लेने से पहले जांचें।

**क्या व्यवहार को शुरू में ले जाने से वह पहले चलता है?**

ज़रूरी नहीं। संग्रह क्रम टाइमिंग का विकल्प नहीं है। विलंब, अवधि, और समान गुण पर ऑपरेशन्स के बीच अंतःक्रियाओं की जाँच करें।

**एक अंत कमांड के पास बिंदु क्यों नहीं होते?**

यह पाथ के अंत को दर्शाता है और किसी निर्देशांक की आवश्यकता नहीं होती। फ़ाइल से पाथ पढ़ते समय `None` बिंदु सरणी की जाँच करें।

**क्या सफल राउंड‑ट्रिप प्लेबैक की पुष्टि के लिए पर्याप्त है?**

नहीं। पुनः खोलना उन गुणों की संरक्षण पुष्टि करता है जिन्हें आप जाँचते हैं। दृश्य व्यवहार की पुष्टि के लिए स्लाइडशो प्लेयर या एनीमेटेड निर्यात को अलग‑अलग परीक्षण करना आवश्यक है।