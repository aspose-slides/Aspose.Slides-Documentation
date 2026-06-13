---
title: Python के साथ प्रस्तुतियों में शैप एनीमेशन लागू करना
linktitle: शैप एनीमेशन
type: docs
weight: 60
url: /hi/python-net/shape-animation/
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
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में शैप एनीमेशन बनाने और अनुकूलित करने के तरीके जानें। अलग दिखें!"
---
## **परिचय**

एनिमेशन दृश्य प्रभाव होते हैं जिन्हें टेक्स्ट, इमेज, शेप, या [चार्ट](/slides/hi/python-net/animated-charts/) पर लागू किया जा सकता है। वे प्रस्तुतियों या उनके घटकों को जीवन देते हैं।

## **प्रस्तुतियों में एनिमेशन का उपयोग क्यों करें?**

एनिमेशन का उपयोग करके आप

* जानकारी के प्रवाह को नियंत्रित करना
* महत्वपूर्ण बिंदुओं पर ज़ोर देना
* दर्शकों की रुचि या सहभागिता बढ़ाना
* सामग्री को पढ़ना, समझना या प्रक्रिया करना आसान बनाना
* आपके पाठकों या दर्शकों का ध्यान प्रस्तुति के महत्वपूर्ण भागों की ओर आकर्षित करना

PowerPoint एनिमेशन और एनिमेशन इफ़ेक्ट्स के लिए कई विकल्प और टूल प्रदान करता है, जो **entrance**, **exit**, **emphasis**, और **motion paths** श्रेणियों में होते हैं।

## **Aspose.Slides में एनिमेशन**

* Aspose.Slides वह क्लास और टाइप्स प्रदान करता है जिनकी आपको एनिमेशन के साथ काम करने के लिए आवश्यकता है, जो [Aspose.Slides.Animation](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/) namespace के अंतर्गत है,
* Aspose.Slides [EffectType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/effecttype/) enumeration के तहत **150** से अधिक एनिमेशन इफ़ेक्ट्स प्रदान करता है। ये इफ़ेक्ट्स मूलतः वही (या बराबर) इफ़ेक्ट्स हैं जो PowerPoint में उपयोग होते हैं।

## **टेक्स्टबॉक्स पर एनिमेशन लागू करना**

Aspose.Slides for Python via .NET आपको किसी शेप में टेक्स्ट पर एनिमेशन लागू करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iautoshape/) जोड़ें। 
4. `IAutoShape.TextFrame` में टेक्स्ट जोड़ें।
5. इफ़ेक्ट्स की मुख्य सीक्वेंस प्राप्त करें।
6. [IAutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iautoshape/) पर एनिमेशन इफ़ेक्ट जोड़ें। 
7. `TextAnimation.BuildType` प्रॉपर्टी को `BuildType` एन्यूमेरेशन के मान पर सेट करें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि `Fade` इफ़ेक्ट को AutoShape पर कैसे लागू करें और टेक्स्ट एनिमेशन को *By 1st Level Paragraphs* मान पर सेट करें:

```python
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # टेक्ट्स्ट के साथ नया AutoShape जोड़ता है
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    sequence = sld.timeline.main_sequence

    # शेप पर Fade एनीमेशन इफ़ेक्ट जोड़ता है
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # शेप के टेक्स्ट को प्रथम स्तर के पैराग्राफ़ द्वारा एनिमेट करता है
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

टेक्स्ट पर एनिमेशन लागू करने के अलावा, आप एकल [Paragraph](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iparagraph/) पर भी एनिमेशन लागू कर सकते हैं। देखें [**Animated Text**](/slides/hi/python-net/animated-text/).

{{% /alert %}} 

## **PictureFrame पर एनिमेशन लागू करना**

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. स्लाइड पर एक [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) जोड़ें या प्राप्त करें। 
4. इफ़ेक्ट्स की मुख्य सीक्वेंस प्राप्त करें।
5. [PictureFrame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pictureframe/) पर एनिमेशन इफ़ेक्ट जोड़ें।
6. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि `Fly` इफ़ेक्ट को पिक्चर फ्रेम पर कैसे लागू करें:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
with slides.Presentation() as pres:
    # प्रेज़ेंटेशन की इमेज कलेक्शन में जोड़ने के लिए इमेज लोड करता है
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # स्लाइड में पिक्चर फ्रेम जोड़ता है
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    sequence = pres.slides[0].timeline.main_sequence

    # पिक्चर फ्रेम पर बाएँ से फ़्लाई एनीमेशन इफ़ेक्ट जोड़ता है
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Shape पर एनिमेशन लागू करना**

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें।
3. एक `rectangle` [IAutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iautoshape/) जोड़ें। 
4. एक `Bevel` [IAutoShape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iautoshape/) जोड़ें (जब इस ऑब्जेक्ट पर क्लिक किया जाता है, तो एनिमेशन चलाया जाता है)।
5. Bevel शेप पर इफ़ेक्ट्स की सीक्वेंस बनाएं।
6. एक कस्टम `UserPath` बनाएं।
7. `UserPath` पर मूव करने के कमांड जोड़ें।
8. प्रस्तुति को डिस्क पर PPTX फ़ाइल के रूप में लिखें।

यह Python कोड दिखाता है कि `PathFootball` (path football) इफ़ेक्ट को शेप पर कैसे लागू करें:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है।
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # मौजूदा आकार के लिए स्क्रैच से PathFootball इफ़ेक्ट बनाता है।
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # PathFootBall एनीमेशन इफ़ेक्ट जोड़ता है।
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # कुछ प्रकार का "बटन" बनाता है।
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # बटन के लिए इफ़ेक्ट्स की क्रम बनाता है।
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # एक कस्टम उपयोगकर्ता पथ बनाता है। हमारा ऑब्जेक्ट केवल बटन क्लिक होने पर ही 이동 किया जाएगा।
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # क्योंकि बनाया गया पथ खाली है, इसलिए गति के कमांड जोड़ता है।
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTX फ़ाइल को डिस्क पर लिखता है।
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Shape पर लागू एनिमेशन इफ़ेक्ट्स प्राप्त करें**

नीचे दिए गए उदाहरण दिखाते हैं कि आप [Sequence](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/sequence/) क्लास की `get_effects_by_shape` मेथड का उपयोग करके शेप पर लागू सभी एनिमेशन इफ़ेक्ट्स कैसे प्राप्त कर सकते हैं।

**उदाहरण 1: सामान्य स्लाइड पर शेप पर लागू एनिमेशन इफ़ेक्ट्स प्राप्त करें**

पहले, आपने PowerPoint प्रस्तुतियों में शैप्स पर एनिमेशन इफ़ेक्ट्स जोड़ना सीखा था। नीचे दिया गया कोड आपको `AnimExample_out.pptx` प्रस्तुति की पहली सामान्य स्लाइड पर पहली शेप पर लागू इफ़ेक्ट्स प्राप्त करने में मदद करता है।

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # स्लाइड की मुख्य एनीमेशन क्रम प्राप्त करता है।
    sequence = first_slide.timeline.main_sequence

    # पहली स्लाइड पर पहला आकार प्राप्त करता है।
    shape = first_slide.shapes[0]

    # आकार पर लागू एनीमेशन इफ़ेक्ट्स प्राप्त करता है।
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**उदाहरण 2: प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स सहित सभी एनिमेशन इफ़ेक्ट्स प्राप्त करें**

यदि किसी सामान्य स्लाइड पर शैप के प्लेसहोल्डर लेआउट स्लाइड और/या मास्टर स्लाइड पर हैं, और इन प्लेसहोल्डर पर एनिमेशन इफ़ेक्ट्स जोड़े गए हैं, तो स्लाइड शो के दौरान शैप के सभी इफ़ेक्ट्स चलेंगे, जिसमें प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स भी शामिल हैं।

मान लीजिए हमारे पास `sample.pptx` नाम का एक PowerPoint फ़ाइल है जिसमें केवल फ़ूटर शैप में टेक्स्ट "Made with Aspose.Slides" है और **Random Bars** इफ़ेक्ट शैप पर लागू है।

![स्लाइड शैप एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

अब मान लें कि **Split** इफ़ेक्ट लेआउट स्लाइड पर फ़ूटर प्लेसहोल्डर पर लागू है।

![लेआउट शैप एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

और अंत में, **Fly In** इफ़ेक्ट मास्टर स्लाइड पर फ़ूटर प्लेसहोल्डर पर लागू है।

![मास्टर शैप एनीमेशन इफ़ेक्ट](master-shape-animation.png)

निचे दिया गया कोड दर्शाता है कि आप [Shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/) क्लास की `get_base_placeholder` मेथड का उपयोग करके शैप प्लेसहोल्डर तक पहुंच सकते हैं और फ़ूटर शैप पर लागू एनिमेशन इफ़ेक्ट्स, साथ ही लेआउट और मास्टर स्लाइड पर स्थित प्लेसहोल्डर से विरासत में मिले इफ़ेक्ट्स प्राप्त कर सकते हैं।

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # साधारण स्लाइड पर आकार के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # लेआउट स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # मास्टर स्लाइड पर प्लेसहोल्डर के एनीमेशन इफ़ेक्ट्स प्राप्त करें।
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

आउटपुट:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **एनिमेशन इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलें**

Aspose.Slides for Python via .NET आपको एनिमेशन इफ़ेक्ट की टाइमिंग प्रॉपर्टीज़ बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एनीमेशन टाइमिंग पैन है:

![example1_image](shape-animation.png)

PowerPoint टाइमिंग और `Effect.Timing` प्रॉपर्टीज़ के बीच उनके संबंध इस प्रकार हैं:

- PowerPoint टाइमिंग **Start** ड्रॉप-डाउन सूची `Effect.Timing.TriggerType` प्रॉपर्टी से मेल खाती है। 
- PowerPoint टाइमिंग **Duration** `Effect.Timing.Duration` प्रॉपर्टी से मेल खाती है। एक एनिमेशन (सेकंड में) की अवधि वह कुल समय है जो एनिमेशन को एक चक्र पूरा करने में लेता है। 
- PowerPoint टाइमिंग **Delay** `Effect.Timing.TriggerDelayTime` प्रॉपर्टी से मेल खाती है। 

इफ़ेक्ट टाइमिंग प्रॉपर्टीज़ बदलने का तरीका:

1. [Shape पर एनिमेशन लागू करें](`#apply-animation-to-shape`) या इफ़ेक्ट प्राप्त करें।
2. आवश्यक `Effect.Timing` प्रॉपर्टीज़ के नए मान सेट करें। 
3. संशोधित PPTX फ़ाइल सहेजें।

यह Python कोड इस प्रक्रिया को दर्शाता है:

```python
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
with slides.Presentation("AnimExample_out.pptx") as pres:
    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    sequence = pres.slides[0].timeline.main_sequence

    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है।
    effect = sequence[0]

    # इफ़ेक्ट का TriggerType क्लिक पर शुरू होने के लिए बदलता है
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # इफ़ेक्ट की अवधि बदलता है
    effect.timing.duration = 3

    # इफ़ेक्ट का TriggerDelayTime बदलता है
    effect.timing.trigger_delay_time = 0.5

    # PPTX फ़ाइल को डिस्क पर सहेजता है
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **एनिमेशन इफ़ेक्ट साउंड**

Aspose.Slides आपको एनिमेशन इफ़ेक्ट्स में साउंड के साथ काम करने के लिए निम्नलिखित प्रॉपर्टीज़ प्रदान करता है:

- `sound`
- `stop_previous_sound`

### **एनिमेशन इफ़ेक्ट साउंड जोड़ें**

यह Python कोड दिखाता है कि आप एनिमेशन इफ़ेक्ट साउंड कैसे जोड़ सकते हैं और अगले इफ़ेक्ट के शुरू होते ही उसे रोक सकते हैं:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # प्रस्तुति की ऑडियो कलेक्शन में ऑडियो जोड़ता है
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    sequence = first_slide.timeline.main_sequence

    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    first_effect = sequence[0]

    # इफ़ेक्ट में “No Sound” के लिए जांच करता है
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # पहले इफ़ेक्ट के लिए ध्वनि जोड़ता है
        first_effect.sound = effect_sound

    # स्लाइड की पहली इंटरैक्टिव क्रम प्राप्त करता है।
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # इफ़ेक्ट “Stop previous sound” फ़्लैग सेट करता है
    interactive_sequence[0].stop_previous_sound = True

    # PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **एनिमेशन इफ़ेक्ट साउंड निकालें**

1. [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
3. इफ़ेक्ट्स की मुख्य सीक्वेंस प्राप्त करें। 
4. प्रत्येक एनिमेशन इफ़ेक्ट में एम्बेडेड `sound` निकालें। 

यह Python कोड दिखाता है कि आप एनिमेशन इफ़ेक्ट में एम्बेडेड साउंड कैसे निकाल सकते हैं:

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है।
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # स्लाइड की मुख्य क्रम प्राप्त करता है।
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # इफ़ेक्ट ध्वनि को बाइट एरे में निकालता है
        audio = effect.sound.binary_data
```

## **एनिमेशन के बाद**

Aspose.Slides for .NET आपको एनिमेशन इफ़ेक्ट की After animation प्रॉपर्टी बदलने की अनुमति देता है।

यह Microsoft PowerPoint में एफ़्टर एनीमेशन पैन और विस्तारित मेनू है:

![example1_image](shape-after-animation.png)

PowerPoint इफ़ेक्ट **After animation** ड्रॉप-डाउन सूची इन प्रॉपर्टीज़ से मेल खाती है:

- `after_animation_type` प्रॉपर्टी जो After animation प्रकार को वर्णित करती है :
  * PowerPoint **More Colors** [COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाती है;
  * PowerPoint **Don't Dim** आइटम [DO_NOT_DIM](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाती है (डिफ़ॉल्ट After animation प्रकार);
  * PowerPoint **Hide After Animation** आइटम [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाती है;
  * PowerPoint **Hide on Next Mouse Click** आइटम [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) प्रकार से मेल खाती है;
- `after_animation_color` प्रॉपर्टी जो After animation कलर फ़ॉर्मेट को परिभाषित करती है। यह प्रॉपर्टी [COLOR](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/afteranimationtype/) प्रकार के साथ मिलकर काम करती है। यदि आप प्रकार को बदलते हैं, तो After animation कलर साफ़ हो जाएगा।

यह Python कोड दिखाता है कि आप After animation इफ़ेक्ट कैसे बदल सकते हैं:

```python
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    first_effect = first_slide.timeline.main_sequence[0]

    # after animation प्रकार को Color में बदलता है
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # after animation डिम रंग सेट करता है
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **टेक्स्ट को एनिमेट करें**

Aspose.Slides आपको एनिमेशन इफ़ेक्ट के *Animate text* ब्लॉक के साथ काम करने के लिए निम्नलिखित प्रॉपर्टीज़ प्रदान करता है:

- `animate_text_type` जो इफ़ेक्ट के एनिमेट टेक्स्ट प्रकार को वर्णित करता है। शैप टेक्स्ट को इस प्रकार एनिमेट किया जा सकता है:
  - सभी एक साथ ([ALL_AT_ONCE](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animatetexttype/) प्रकार)
  - शब्द-दर-शब्द ([BY_WORD](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animatetexttype/) प्रकार)
  - अक्षर-दर-अक्षर ([BY_LETTER](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/animatetexttype/) प्रकार)
- `delay_between_text_parts` एनिमेटेड टेक्स्ट भागों (शब्द या अक्षर) के बीच देरी निर्धारित करता है। सकारात्मक मान इफ़ेक्ट की अवधि का प्रतिशत दर्शाता है। नकारात्मक मान सेकंड में देरी दर्शाता है।

Effect Animate text प्रॉपर्टीज़ को इस प्रकार बदला जा सकता है:

1. [Shape पर एनिमेशन लागू करें](`#apply-animation-to-shape`) या इफ़ेक्ट प्राप्त करें।
2. `build_type` प्रॉपर्टी को [AS_ONE_OBJECT](https://reference.aspose.com/slides/hi/python-net/aspose.slides.animation/buildtype/) मान पर सेट करें ताकि *By Paragraphs* एनिमेशन मोड बंद हो जाए।
3. `animate_text_type` और `delay_between_text_parts` प्रॉपर्टीज़ के नए मान सेट करें।
4. संशोधित PPTX फ़ाइल सहेजें।

यह Python कोड इस प्रक्रिया को दर्शाता है:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # मुख्य क्रम का पहला इफ़ेक्ट प्राप्त करता है
    first_effect = first_slide.timeline.main_sequence[0]

    # इफ़ेक्ट के टेक्स्ट एनीमेशन प्रकार को "As One Object" में बदलता है
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # इफ़ेक्ट के Animate text प्रकार को "By word" में बदलता है
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # शब्दों के बीच देरी को इफ़ेक्ट अवधि के 20% पर सेट करता है
    first_effect.delay_between_text_parts = 20

    # PPTX फ़ाइल को डिस्क पर लिखता है
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं वेब पर प्रस्तुति प्रकाशित करते समय एनिमेशन को कैसे संरक्षित रख सकता हूँ?**

[Export to HTML5](/slides/hi/python-net/export-to-html5/) और उन [options](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/) को सक्षम करें जो [shape](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_shapes/) और [transition](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/html5options/animate_transitions/) एनिमेशन के लिए जिम्मेदार हैं। साधारण HTML स्लाइड एनिमेशन नहीं चलाता, जबकि HTML5 करती है।

**शैप्स की z-ऑर्डर (लेयर ऑर्डर) बदलने से एनिमेशन पर क्या प्रभाव पड़ता है?**

एनिमेशन और ड्राइंग ऑर्डर स्वतंत्र होते हैं: इफ़ेक्ट प्रकट/गायब होने के टाइमिंग और प्रकार को नियंत्रित करता है, जबकि [z-order](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/z_order_position/) निर्धारित करता है कि क्या क्या कवर करता है। दृश्य परिणाम उनका संयोजन होता है। (यह सामान्य PowerPoint व्यवहार है; Aspose.Slides का इफ़ेक्ट-एंड-शेप मॉडल भी यही लॉजिक अपनाता है।)

**क्या कुछ इफ़ेक्ट्स को वीडियो में बदलते समय सीमाएँ हैं?**

सामान्यतः, [एनिमेशन समर्थित हैं](/slides/hi/python-net/convert-powerpoint-to-video/), लेकिन कुछ दुर्लभ मामलों या विशिष्ट इफ़ेक्ट्स का रेंडर अलग हो सकता है। उपयोग किए जा रहे इफ़ेक्ट्स और लाइब्रेरी के संस्करण के साथ परीक्षण करना सलाहनीय है।