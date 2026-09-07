---
title: Python में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/python-java/convert-powerpoint-to-video/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से वीडियो
- प्रस्तुति से वीडियो
- PPT से वीडियो
- PPTX से वीडियो
- PowerPoint से MP4
- प्रस्तुति से MP4
- PPT से MP4
- PPTX से MP4
- PPT को MP4 के रूप में सहेजें
- PPTX को MP4 के रूप में सहेजें
- PPT को MP4 में निर्यात करें
- PPTX को MP4 में निर्यात करें
- वीडियो रूपांतरण
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "Java के माध्यम से Python में PowerPoint प्रस्तुतियों को MP4 वीडियो में बदलें। Aspose.Slides के साथ फ्रेम उत्पन्न करें और उन्हें FFmpeg से एन्कोड करें, जिसमें एनीमेशन और ट्रांज़िशन शामिल हैं।"
---
## **समग्र विवरण**

PowerPoint या OpenDocument प्रस्तुति को वीडियो में परिवर्तित करने से दर्शक प्रस्तुति एप्लिकेशन को खोले बिना उसकी सामग्री को वीडियो प्लेयर में देख सकते हैं। Aspose.Slides for Python via Java प्रस्तुति एनीमेशन और ट्रांज़िशन को इमेज फ्रेम्स में रेंडर करता है। एक अलग एन्कोडर, जैसे FFmpeg, उन फ्रेम्स को एक वीडियो फ़ाइल में संयोजित करता है।

{{% alert color="info" title="Note" %}}
ऑनलाइन [PowerPoint to Video converter](https://products.aspose.app/slides/hi/video) आज़माएँ ताकि प्रस्तुति‑से‑वीडियो रूपांतरण को कार्रवाई में देख सकें।
{{% /alert %}}

## **PowerPoint को वीडियो में बदलें**

रूपांतरण दो चरणों में होता है: चुनी गई फ्रेम दर पर PNG फ्रेम्स उत्पन्न करना, फिर इमेज अनुक्रम को MP4 के रूप में एन्कोड करना। एनीमेशन टाइमिंग को बनाए रखने के लिए दोनों चरणों में समान फ्रेम दर उपयोग करें।

उदाहरण चलाने से पहले:

1. [Aspose.Slides for Python via Java](/slides/hi/python-java/installation/) सेट अप करें।
2. [FFmpeg](https://ffmpeg.org/download.html) डाउनलोड करें और उसका executable `PATH` में उपलब्ध कराएं। उदाहरण `libx264` एन्कोडर वाले बिल्ड का उपयोग करता है।
3. निम्नलिखित Python कोड को एक लिखने योग्य डायरेक्टरी में चलाएँ।

यह उदाहरण प्रवेश और निकास एनीमेशन के साथ एक मुस्कुराते हुए आकार को बनाता है, 30 FPS पर फ्रेम रेंडर करता है, और `output.mp4` बनाने के लिए FFmpeg को कॉल करता है। एक नई फ्रेम डायरेक्टरी पहले चलाए गए फ्रेम्स को वीडियो में शामिल होने से रोकती है।

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

एक मौजूदा फ़ाइल को बदलने के लिए, उसके पाथ के साथ [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) को इनिशियलाइज़ करें और shape‑creation तथा animation‑creation कथनों को छोड़ दें।

FFmpeg कमांड एक क्रमांकित [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) को पढ़ता है, विषम आयामों को बराबर मूल्यों तक पैड करता है, और `yuv420p` पिक्सेल फ़ॉर्मेट के साथ H.264 वीडियो लिखता है। `-n` विकल्प मौजूदा आउटपुट फ़ाइल को ओवरराइट होने से रोकता है। उत्पन्न PNG फ़ाइलें फ्रेम डायरेक्टरी में रहती हैं; जब आवश्यक न हों तो उन्हें हटाएँ।

{{% alert color="info" title="Note" %}}
यह उदाहरण केवल इमेज फ्रेम्स को एन्कोड करता है। यह आउटपुट वीडियो में वर्णन या एम्बेडेड प्रस्तुति ऑडियो नहीं जोड़ता है।
{{% /alert %}}

## **वीडियो इफ़ेक्ट्स**

एनीमेशन नियंत्रित करते हैं कि स्लाइड ऑब्जेक्ट्स कैसे दिखते, मूव होते या गायब होते हैं। ट्रांज़िशन स्लाइडों के बीच परिवर्तन को नियंत्रित करता है। वीडियो फ्रेम्स उत्पन्न करने से पहले इन इफ़ेक्ट्स को जोड़ें।

देखें [PowerPoint Animation](/slides/hi/python-java/powerpoint-animation/), [Shape Animation](/slides/hi/python-java/shape-animation/), [Shape Effects](/slides/hi/python-java/shape-effect/), और [Slide Transitions](/slides/hi/python-java/slide-transition/)।

### **स्लाइड ट्रांज़िशन जोड़ें**

निम्नलिखित स्वतंत्र उदाहरण दो स्लाइड्स वाला एक प्रस्तुति बनाता है। दूसरी स्लाइड का बैकग्राउंड मैजेंटा है और इसमें पुश ट्रांज़िशन है। प्रस्तुति को सेव करें, फिर उसे ऊपर के फ्रेम‑जनरेशन उदाहरण की इनपुट के रूप में उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **पैराग्राफ एनीमेट करें**

टेक्स्ट पैराग्राफ दर पैराग्राफ दिखाई दे सकता है। यह उदाहरण तीन पैराग्राफ बनाता है जिनमें क्रमिक फ़ेड प्रवेश इफ़ेक्ट्स हैं, प्रत्येक पूर्व प्रभाव के एक सेकंड बाद देरी से। सहेजी गई `paragraphs.pptx` फ़ाइल को वीडियो‑कन्वर्ज़न उदाहरण की इनपुट के रूप में उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **वीडियो रूपांतरण कक्षाएँ**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationanimationsgenerator/) स्लाइड्स के लिए एनीमेशन इवेंट्स उत्पन्न करता है। इसे एक प्रस्तुति से बनाते समय फ्रेम्स के लिए प्रस्तुति के स्लाइड आकार का उपयोग करता है। डिफ़ॉल्ट मिलीसेकंड में देरी को कॉन्फ़िगर करने के लिए [setDefaultDelay](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) का उपयोग करें।

[PresentationPlayer](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationplayer/) निर्माणकर्ता द्वारा प्रदान की गई फ्रेम दर पर उत्पन्न एनीमेशन को सैंपल करता है। JPype के माध्यम से [setFrameTick](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationplayer/#setFrameTick) के साथ एक Python कॉलबैक रजिस्टर करें, फिर फ्रेम उत्पन्न करने के लिए [run](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationanimationsgenerator/#run) को कॉल करें। पहला उदाहरण अपना स्वयं का शून्य‑आधारित काउंटर उपयोग करता है ताकि फ़ाइलनाम FFmpeg के इनपुट अनुक्रम से मेल खाएँ।

व्यक्तिगत एनीमेशन स्थितियों के लिए, [setNewAnimation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) के साथ एक कॉलबैक रजिस्टर करें। कॉलबैक को एक एनीमेशन प्लेयर प्राप्त होता है जिसे चयनित समय पर स्थित किया जा सकता है। निम्नलिखित उदाहरण प्रत्येक उत्पन्न एनीमेशन के पहले और अंतिम फ्रेम को अद्वितीय फ़ाइलनामों के साथ सहेजता है:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

निम्न तालिकाएँ Java रूपांतरण लेख में वर्णित रेंडरिंग समर्थन का सारांश प्रस्तुत करती हैं। जब प्रस्तुति असमर्थित इफ़ेक्ट्स का उपयोग करती है तो उत्पन्न फ्रेम्स का पूर्वावलोकन करें।

**प्रवेश**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | नहीं | हाँ |
| **Fade** | हाँ | हाँ |
| **Fly In** | हाँ | हाँ |
| **Float In** | हाँ | हाँ |
| **Split** | हाँ | हाँ |
| **Wipe** | हाँ | हाँ |
| **Shape** | हाँ | हाँ |
| **Wheel** | हाँ | हाँ |
| **Random Bars** | हाँ | हाँ |
| **Grow & Turn** | नहीं | हाँ |
| **Zoom** | हाँ | हाँ |
| **Swivel** | हाँ | हाँ |
| **Bounce** | हाँ | हाँ |

**जोर**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | नहीं | हाँ |
| **Color Pulse** | नहीं | हाँ |
| **Teeter** | हाँ | हाँ |
| **Spin** | हाँ | हाँ |
| **Grow/Shrink** | नहीं | हाँ |
| **Desaturate** | नहीं | हाँ |
| **Darken** | नहीं | हाँ |
| **Lighten** | नहीं | हाँ |
| **Transparency** | नहीं | हाँ |
| **Object Color** | नहीं | हाँ |
| **Complementary Color** | नहीं | हाँ |
| **Line Color** | नहीं | हाँ |
| **Fill Color** | नहीं | हाँ |

**निकास**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | नहीं | हाँ |
| **Fade** | हाँ | हाँ |
| **Fly Out** | हाँ | हाँ |
| **Float Out** | हाँ | हाँ |
| **Split** | हाँ | हाँ |
| **Wipe** | हाँ | हाँ |
| **Shape** | हाँ | हाँ |
| **Random Bars** | हाँ | हाँ |
| **Shrink & Turn** | नहीं | हाँ |
| **Zoom** | हाँ | हाँ |
| **Swivel** | हाँ | हाँ |
| **Bounce** | हाँ | हाँ |

**गति पथ**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | हाँ | हाँ |
| **Arcs** | हाँ | हाँ |
| **Turns** | हाँ | हाँ |
| **Shapes** | हाँ | हाँ |
| **Loops** | हाँ | हाँ |
| **Custom Path** | हाँ | हाँ |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides सीधे MP4 फ़ाइल बनाता है?**

नहीं। Aspose.Slides प्रस्तुति फ्रेम्स बनाता है। उन्हें MP4 फ़ाइल में संयोजित करने के लिए FFmpeg जैसे वीडियो एन्कोडर का उपयोग करें।

**वीडियो अपेक्षा से तेज़ या धीमा क्यों चलता है?**

फ़्रेम जनरेशन और एन्कोडर की इनपुट फ्रेम दर के लिए समान FPS उपयोग करें। असंगतता इमेज अनुक्रम की प्लेबैक अवधि बदल देती है।

**क्या मैं पासवर्ड‑सुरक्षित प्रस्तुति को बदल सकता हूँ?**

हां। सुरक्षित प्रस्तुति को [लोड करते समय](/slides/hi/python-java/password-protected-presentation/) सही पासवर्ड प्रदान करें, फिर लोड की गई सामग्री से फ्रेम्स उत्पन्न करें।

**क्या यह कार्यप्रवाह प्रस्तुति ऑडियो को संरक्षित करता है?**

उदाहरण इमेज फ्रेम्स निर्यात करते हैं, इसलिए resulting video मौन है। ऑडियो शामिल करने के लिए, वीडियो एन्कोडिंग के दौरान एक ऑडियो ट्रैक अलग से प्रदान करें।

**मैं अस्थायी डिस्क उपयोग को कैसे घटा सकता हूँ?**

छोटी फ्रेम आकार या कम FPS उपयोग करें, और सफल एन्कोडिंग के बाद अस्थायी PNG फ़ाइलें हटाएँ। किसी भी सेटिंग को घटाते समय परिणामस्वरूप वीडियो गुणवत्ता की जाँच करें।