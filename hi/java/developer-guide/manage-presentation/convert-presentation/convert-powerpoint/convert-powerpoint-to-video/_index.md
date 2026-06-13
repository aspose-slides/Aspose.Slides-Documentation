---
title: PowerPoint प्रस्तुतियों को जावा में वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "जावा में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। अपने कार्यप्रवाह को सुव्यवस्थित करने के लिए नमूना कोड और स्वचालन तकनीकों की खोज करें।"
---
## **परिचय**

PowerPoint या OpenDocument प्रेजेंटेशन को वीडियो में बदलने से आपको प्राप्त होता है:

**बढ़ी हुई पहुँच:** सभी उपकरण, प्लेटफ़ॉर्म की परवाह किए बिना, डिफ़ॉल्ट रूप से वीडियो प्लेयर के साथ आते हैं, जिससे उपयोगकर्ताओं के लिए पारंपरिक प्रेज़ेंटेशन एप्लिकेशन की तुलना में वीडियो खोलना या चलाना आसान हो जाता है।

**व्यापक पहुँच:** वीडियो आपको बड़े दर्शकों तक पहुँचा सकते हैं और जानकारी को अधिक आकर्षक फ़ॉर्मेट में प्रस्तुत कर सकते हैं। सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग अन्य रूपों की तुलना में वीडियो सामग्री को देखना और उपभोग करना पसंद करते हैं, जिससे आपका संदेश अधिक प्रभावशाली बनता है।

{{% alert color="primary" %}} 
आप हमारे [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को देखना चाहेंगे क्योंकि यह यहाँ वर्णित प्रक्रिया का एक लाइव और प्रभावी कार्यान्वयन है।
{{% /alert %}} 

## **Aspose.Slides में PowerPoint से वीडियो कन्वर्ज़न**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-22-11-release-notes/) में, हमने प्रेज़ेंटेशन से वीडियो कन्वर्ज़न का समर्थन लागू किया।

* **Aspose.Slides** का उपयोग करके प्रस्तुति स्लाइड्स से फ़्रेम्स का एक सेट उत्पन्न करें जो निश्चित FPS (फ़्रेम प्रति सेकंड) के अनुरूप हो
* **ffmpeg** जैसे तृतीय‑पक्ष यूटिलिटी ([जावा के लिए](https://github.com/bramp/ffmpeg-cli-wrapper)) का उपयोग करके फ़्रेम्स के आधार पर वीडियो बनाएं।

### **PowerPoint को वीडियो में बदलें**

1. अपने POM फ़ाइल में यह जोड़ें:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg को [यहाँ](https://ffmpeg.org/download.html) डाउनलोड करें।

4. PowerPoint से वीडियो जावा कोड चलाएँ।

यह जावा कोड आपको दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक चित्र और दो एनीमेशन इफ़ेक्ट्स हैं) को वीडियो में बदला जाए:
```java
Presentation presentation = new Presentation();
try {
    // एक स्माइल शेप जोड़ता है और फिर उसे एनीमेट करता है
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg बाइनरी फ़ोल्डर कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **वीडियो इफ़ेक्ट्स**

आप स्लाइड्स पर ऑब्जेक्ट्स पर एनीमेशन लागू कर सकते हैं और स्लाइड्स के बीच ट्रांज़िशन का उपयोग कर सकते हैं।

{{% alert color="primary" %}} 
आप इन लेखों को देख सकते हैं: [PowerPoint Animation](https://docs.aspose.com/slides/hi/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/java/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/java/shape-effect/)।
{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वीडियो के लिए भी यही काम करते हैं। आइए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ें:
```java
// एक स्माइल आकार जोड़ता है और उसे एनीमेट करता है

// ...

// एक नई स्लाइड और एनीमेटेड ट्रांज़िशन जोड़ता है

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides टेक्स्ट के लिए भी एनीमेशन का समर्थन करता है। इसलिए हम ऑब्जेक्ट्स पर पैराग्राफ़ को एनीमेट करते हैं, जो एक‑के‑बाद‑एक दिखेंगे (एक सेकंड की देरी के साथ):
```java
Presentation presentation = new Presentation();
try {
    // पाठ और एनीमेशन जोड़ता है
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // ffmpeg बाइनरी फ़ोल्डर कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **वीडियो कन्वर्ज़न क्लासेज़**

PowerPoint को वीडियो में बदलने के कार्यों को करने के लिए, Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) क्लासेज़ प्रदान करता है।

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) आपको वीडियो के फ़्रेम आकार को उसके कंस्ट्रक्टर के माध्यम से सेट करने देता है (जो बाद में बनाया जाएगा)। यदि आप प्रस्तुति का एक इंस्टेंस पास करते हैं, तो `Presentation.SlideSize` उपयोग किया जाएगा और यह एनीमेशन उत्पन्न करता है जिसे [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) उपयोग करता है।

जब एनीमेशन उत्पन्न होते हैं, तो प्रत्येक बाद के एनीमेशन के लिए एक `NewAnimation` इवेंट उत्पन्न होता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/) पैरामीटर होता है। यह क्लास अलग एनीमेशन के लिए एक प्लेयर का प्रतिनिधित्व करती है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/) के साथ काम करने के लिए, [Duration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (एनीमेशन की कुल अवधि) प्रॉपर्टी और [SetTimePosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) मेथड का उपयोग किया जाता है। प्रत्येक एनीमेशन स्थिति *0 से duration* रेंज के भीतर सेट की जाती है, और फिर `GetFrame` मेथड उस क्षण पर एनीमेशन की स्थिति के अनुरूप एक BufferedImage लौटाता है:
```java
Presentation presentation = new Presentation();
try {
    // एक स्माइल आकार जोड़ता है और उसे एनीमेट करता है
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // प्रारंभिक एनीमेशन स्थिति
            try {
                // प्रारंभिक एनीमेशन स्थिति बिटमैप
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // एनीमेशन की अंतिम स्थिति
            try {
                // एनीमेशन का अंतिम फ्रेम
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) क्लास का प्रयोग किया जाता है। यह क्लास अपने कंस्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) इंस्टेंस और FPS लेता है और फिर सभी एनीमेशन के `FrameTick` इवेंट को कॉल करके उन्हें चलाता है:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

उसके बाद उत्पन्न फ़्रेम्स को संयोजित कर एक वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) सेक्शन।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

**प्रवेश**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**जोर देना**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**निकास**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**मोशन पाथ्स**:

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को बदलना संभव है?**

हाँ, Aspose.Slides [पासवर्ड‑सुरक्षित प्रस्तुतियों](/slides/hi/java/password-protected-presentation/) के साथ काम करने की अनुमति देता है। ऐसी फ़ाइलों को प्रोसेस करने के लिए आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

**क्या Aspose.Slides क्लाउड समाधान में उपयोग के लिए समर्थन करता है?**

हाँ, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर परिवेश में काम करने के लिए बनाई गई है, जिससे फ़ाइलों की बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी मिलती है।

**क्या परिवर्तन के दौरान प्रस्तुतियों के आकार पर कोई सीमा है?**

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुति को अनुकूलित करने की सलाह दी जाती है।