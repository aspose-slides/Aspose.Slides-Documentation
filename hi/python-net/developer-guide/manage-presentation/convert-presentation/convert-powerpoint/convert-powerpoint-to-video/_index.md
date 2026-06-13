---
title: Python में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/python-net/convert-powerpoint-to-video/
keywords:
- PowerPoint से वीडियो
- PowerPoint को वीडियो में बदलें
- प्रस्तुति को वीडियो में
- प्रस्तुति को वीडियो में बदलें
- PPT से वीडियो
- PPT को वीडियो में बदलें
- PPTX से वीडियो
- PPTX को वीडियो में बदलें
- ODP से वीडियो
- ODP को वीडियो में बदलें
- PowerPoint से MP4
- PowerPoint को MP4 में बदलें
- प्रस्तुति को MP4 में
- प्रस्तुति को MP4 में बदलें
- PPT से MP4
- PPT को MP4 में बदलें
- PPTX से MP4
- PPTX को MP4 में बदलें
- PowerPoint से वीडियो रूपांतरण
- प्रस्तुति से वीडियो रूपांतरण
- PPT से वीडियो रूपांतरण
- PPTX से वीडियो रूपांतरण
- ODP से वीडियो रूपांतरण
- Python वीडियो रूपांतरण
- PowerPoint
- Python
- Aspose.Slides
description: "Python का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को वीडियो में बदलना सीखें। वर्कफ़्लो को सुगम बनाने के लिए नमूना कोड और ऑटोमेशन तकनीकों की खोज करें।"
---
## **परिचय**

PowerPoint या OpenDocument प्रस्तुति को वीडियो में बदलकर, आप प्राप्त करते हैं:

**बढ़ी हुई पहुँच:** सभी उपकरण, प्लेटफ़ॉर्म की परवाह किए बिना, डिफ़ॉल्ट रूप से वीडियो प्लेयर से सुसज्जित होते हैं, जिससे उपयोगकर्ताओं के लिए पारंपरिक प्रस्तुति अनुप्रयोगों की तुलना में वीडियो खोलना या चलाना आसान हो जाता है।

**विस्तृत पहुँच:** वीडियो आपको बड़े दर्शक वर्ग तक पहुँचने और जानकारी को अधिक आकर्षक प्रारूप में प्रस्तुत करने में सक्षम बनाते हैं। सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग अन्य रूपों की तुलना में वीडियो सामग्री को देखना और उपभोग करना पसंद करते हैं, जिससे आपका संदेश अधिक प्रभावशाली बनता है।

{{% alert color="primary" %}} 
हमारे [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hi/video) को देखें क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव और प्रभावी कार्यान्वयन प्रदान करता है।
{{% /alert %}} 

[Aspose.Slides for Python 24.4](https://releases.aspose.com/slides/hi/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/) में, हमने प्रस्तुतीकरण को वीडियो में बदलने के लिए समर्थन लागू किया।

* Aspose.Slides for Python का उपयोग करके निर्दिष्ट फ्रेम रेट (FPS) पर प्रस्तुति स्लाइड्स से फ्रेम उत्पन्न करें।
* फिर, ffmpeg जैसे तृतीय‑पक्षीय यूटिलिटी का उपयोग करके इन फ्रेम्स को एक वीडियो में संकलित करें।

## **PowerPoint प्रस्तुति को वीडियो में बदलें**

1. अपने प्रोजेक्ट में Aspose.Slides for Python जोड़ने के लिए pip install कमांड का उपयोग करें: `pip install aspose-slides==24.4.0`
2. ffmpeg को [here](https://ffmpeg.org/download.html) से डाउनलोड करें या पैकेज मैनेजर के माध्यम से इंस्टॉल करें।
3. सुनिश्चित करें कि ffmpeg `PATH` में है। अन्यथा, बाइनरी के पूर्ण पथ का उपयोग करके ffmpeg लॉन्च करें (उदाहरण के लिए, Windows पर `C:\ffmpeg\ffmpeg.exe` या Linux पर `/opt/ffmpeg/ffmpeg`)।
4. PowerPoint‑to‑video रूपांतरण कोड चलाएँ।

यह Python कोड दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक आकृति और दो एनीमेशन इफ़ेक्ट हैं) को वीडियो में बदला जाता है:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    smile_shape = slide.shapes.add_auto_shape(slides.ShapeType.SMILEY_FACE, 110, 20, 500, 500)

    effect_in = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.TOP_LEFT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_out = slide.timeline.main_sequence.add_effect(
        smile_shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.BOTTOM_RIGHT,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect_in.timing.duration = 2
    effect_out.preset_class_type = slides.animation.EffectPresetClassType.EXIT

    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p",
                "smile.webm"]
    subprocess.call(cmd_line)
```

## **वीडियो प्रभाव**

Aspose.Slides for Python का उपयोग करके PowerPoint प्रस्तुति को वीडियो में बदलते समय, आप आउटपुट की दृश्य गुणवत्ता को बढ़ाने के लिए विभिन्न वीडियो प्रभाव लागू कर सकते हैं। ये प्रभाव आपको अंतिम वीडियो में स्लाइड्स की उपस्थिति को स्मूथ ट्रांज़िशन, एनीमेशन और अन्य दृश्य तत्व जोड़कर नियंत्रित करने की अनुमति देते हैं। यह अनुभाग उपलब्ध वीडियो प्रभाव विकल्पों को दर्शाता है और उन्हें कैसे लागू किया जाए दिखाता है।

{{% alert color="primary" %}} 
देखें [PowerPoint Animation](https://docs.aspose.com/slides/hi/python-net/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/python-net/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/python-net/shape-effect/)।
{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं — और वीडियो के लिए भी यही बात लागू होती है। चलिए पिछली प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```python
import aspose.pydrawing as drawing

# एक स्माइल आकृति जोड़ें और उसे एनीमेट करें।
# ...

# एक नई स्लाइड जोड़ें और एक एनीमेटेड ट्रांज़िशन जोड़ें।
new_slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
new_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
new_slide.background.fill_format.fill_type = slides.FillType.SOLID
new_slide.background.fill_format.solid_fill_color.color = drawing.Color.indigo
new_slide.slide_show_transition.type = slides.TransitionType.PUSH
```

Aspose.Slides for Python टेक्स्ट एनीमेशन का भी समर्थन करता है। इस उदाहरण में, हम ऑब्जेक्ट्स पर पैराग्राफ़ को एनीमेट करते हैं ताकि वे एक‑के‑बाद‑एक दिखाई दें, उनके बीच एक‑सेकंड का अंतराल हो:

```python
import aspose.slides as slides
import subprocess

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # टेक्स्ट और एनीमेशन जोड़ें।
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 120, 300, 300)
    para1 = slides.Paragraph()
    para1.portions.add(slides.Portion("Aspose.Slides for Python"))
    para2 = slides.Paragraph()
    para2.portions.add(slides.Portion("Convert a PowerPoint presentation with text to video"))

    para3 = slides.Paragraph()
    para3.portions.add(slides.Portion("paragraph by paragraph"))
    auto_shape.text_frame.paragraphs.add(para1)
    auto_shape.text_frame.paragraphs.add(para2)
    auto_shape.text_frame.paragraphs.add(para3)
    auto_shape.text_frame.paragraphs.add(slides.Paragraph())

    effect = slide.timeline.main_sequence.add_effect(
        para1,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect2 = slide.timeline.main_sequence.add_effect(
        para2,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect3 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect4 = slide.timeline.main_sequence.add_effect(
        para3,
        slides.animation.EffectType.APPEAR,
        slides.animation.EffectSubtype.NONE,
        slides.animation.EffectTriggerType.AFTER_PREVIOUS)

    effect.timing.trigger_delay_time = 1
    effect2.timing.trigger_delay_time = 1
    effect3.timing.trigger_delay_time = 1
    effect4.timing.trigger_delay_time = 1

    # फ्रेम को वीडियो में बदलें।
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame = "frame_{:04d}.png".format(frame_args.frames_generator.frame_index)
            frame_args.get_frame().save(frame)

    cmd_line = ["ffmpeg", "-r", str(fps), "-i", "frame_%04d.png", "-y", "-s", "720x540", "-pix_fmt", "yuv420p", "text_animation.webm"]
    subprocess.call(cmd_line)
```

## **वीडियो परिवर्तन वर्ग**

PowerPoint को वीडियो में बदलने के कार्यों को सक्षम करने के लिए, Aspose.Slides for Python [PresentationEnumerableFramesGenerator](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/presentationenumerableframesgenerator/) प्रदान करता है।

`PresentationEnumerableFramesGenerator` आपको उसके कंस्ट्रक्टर के माध्यम से वीडियो (जो बाद में बनाया जाएगा) के लिए फ्रेम आकार और FPS (फ़्रेम प्रति सेकंड) मान सेट करने की अनुमति देता है। यदि आप किसी प्रस्तुति का इंस्टेंस पास करते हैं, तो उसकी `Presentation.SlideSize` उपयोग की जाएगी।

सभी एनीमेशन को एक साथ चलाने के लिए, `PresentationEnumerableFramesGenerator.enumerate_frames` मेथड का उपयोग करें। यह मेथड स्लाइड्स का एक संग्रह लेता है और क्रमिक रूप से [EnumerableFrameArgs](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/enumerableframeargs/) लौटाता है। फिर, प्रत्येक वीडियो फ्रेम प्राप्त करने के लिए `EnumerableFrameArgs.get_frame()` का उपयोग करें।

```python
import aspose.slides as slides

with slides.Presentation("animated.pptx") as presentation:
    fps = 33
    with slides.export.PresentationEnumerableFramesGenerator(presentation, fps) as frames_stream:
        for frame_args in frames_stream.enumerate_frames(presentation.slides):
            frame_args.get_frame().save(f"frame_{frame_args.frames_generator.frame_index:04d}.png")
```

फिर उत्पन्न फ्रेम्स को एक वीडियो में संकलित किया जा सकता है। अधिक विवरण के लिए देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/python-net/convert-powerpoint-to-video/#convert-powerpoint-to-video) अनुभाग।

## **समर्थित एनिमेशन और प्रभाव**

Aspose.Slides for Python का उपयोग करके PowerPoint प्रस्तुति को वीडियो में बदलते समय यह समझना महत्वपूर्ण है कि आउटपुट में कौन‑से एनीमेशन और प्रभाव समर्थित हैं। Aspose.Slides फेड, फ़्लाई‑इन, ज़ूम और स्पिन जैसे सामान्य एंट्री, एग्जिट और इम्फेसिस प्रभावों की व्यापक रेंज का समर्थन करता है। हालांकि, कुछ उन्नत या कस्टम एनीमेशन पूरी तरह से संरक्षित नहीं रह सकते या अंतिम वीडियो में अलग दिख सकते हैं। यह अनुभाग समर्थित एनीमेशन और प्रभावों को दर्शाता है।

**Entrance**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Emphasis**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Exit**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Motion Paths**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **समर्थित स्लाइड ट्रांज़िशन प्रभाव**

स्लाइड ट्रांज़िशन प्रभाव वीडियो में स्लाइड्स के बीच सुगम और दृश्य रूप से आकर्षक परिवर्तन बनाने में महत्वपूर्ण भूमिका निभाते हैं। Aspose.Slides for Python विभिन्न सामान्य ट्रांज़िशन प्रभावों को समर्थन देता है जिससे आपकी मूल प्रस्तुति का प्रवाह और शैली सुरक्षित रहती है। यह अनुभाग यह दर्शाता है कि रूपांतरण प्रक्रिया के दौरान कौन‑से ट्रांज़िशन प्रभाव समर्थित हैं।

**सूक्ष्म**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Morph** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Push** | ![supported](v.png) | ![supported](v.png) |
| **Pull** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Reveal** | ![not supported](x.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![not supported](x.png) | ![supported](v.png) |
| **Uncover** | ![not supported](x.png) | ![supported](v.png) |
| **Cover** | ![supported](v.png) | ![supported](v.png) |
| **Flash** | ![supported](v.png) | ![supported](v.png) |
| **Strips** | ![supported](v.png) | ![supported](v.png) |

**रोचक**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Fall Over** | ![not supported](x.png) | ![supported](v.png) |
| **Drape** | ![not supported](x.png) | ![supported](v.png) |
| **Curtains** | ![not supported](x.png) | ![supported](v.png) |
| **Wind** | ![not supported](x.png) | ![supported](v.png) |
| **Prestige** | ![not supported](x.png) | ![supported](v.png) |
| **Fracture** | ![not supported](x.png) | ![supported](v.png) |
| **Crush** | ![not supported](x.png) | ![supported](v.png) |
| **Peel Off** | ![not supported](x.png) | ![supported](v.png) |
| **Page Curl** | ![not supported](x.png) | ![supported](v.png) |
| **Airplane** | ![not supported](x.png) | ![supported](v.png) |
| **Origami** | ![not supported](x.png) | ![supported](v.png) |
| **Dissolve** | ![supported](v.png) | ![supported](v.png) |
| **Checkerboard** | ![not supported](x.png) | ![supported](v.png) |
| **Blinds** | ![not supported](x.png) | ![supported](v.png) |
| **Clock** | ![supported](v.png) | ![supported](v.png) |
| **Ripple** | ![not supported](x.png) | ![supported](v.png) |
| **Honeycomb** | ![not supported](x.png) | ![supported](v.png) |
| **Glitter** | ![not supported](x.png) | ![supported](v.png) |
| **Vortex** | ![not supported](x.png) | ![supported](v.png) |
| **Shred** | ![not supported](x.png) | ![supported](v.png) |
| **Switch** | ![not supported](x.png) | ![supported](v.png) |
| **Flip** | ![not supported](x.png) | ![supported](v.png) |
| **Gallery** | ![not supported](x.png) | ![supported](v.png) |
| **Cube** | ![not supported](x.png) | ![supported](v.png) |
| **Doors** | ![not supported](x.png) | ![supported](v.png) |
| **Box** | ![not supported](x.png) | ![supported](v.png) |
| **Comb** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Random** | ![not supported](x.png) | ![supported](v.png) |

**डायनमिक कंटेंट**:

| एनिमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pan** | ![not supported](x.png) | ![supported](v.png) |
| **Ferris Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Conveyor** | ![not supported](x.png) | ![supported](v.png) |
| **Rotate** | ![not supported](x.png) | ![supported](v.png) |
| **Orbit** | ![not supported](x.png) | ![supported](v.png) |
| **Fly Through** | ![supported](v.png) | ![supported](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को बदलना संभव है?**

हाँ, Aspose.Slides for Python पासवर्ड‑सुरक्षित प्रस्तुतियों के साथ काम करने का समर्थन करता है। ऐसी फ़ाइलों को प्रोसेस करते समय आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

**क्या Aspose.Slides for Python क्लाउड समाधान में उपयोग का समर्थन करता है?**

हाँ, Aspose.Slides for Python को क्लाउड एप्लिकेशन और सेवाओं में geïntegre किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे फ़ाइलों के बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी सुनिश्चित होती है।

**क्या रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई सीमा है?**

Aspose.Slides for Python व्यावहारिक रूप से किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़ी फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुति को अनुकूलित करने की सलाह दी जा सकती है।