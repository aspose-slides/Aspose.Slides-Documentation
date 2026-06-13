---
title: Android पर PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/androidjava/convert-powerpoint-to-video/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
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
- Android
- Java
- Aspose.Slides
description: "Java में PowerPoint प्रस्तुतियों को वीडियो में बदलने का तरीका सीखें। कार्यप्रवाह को सुगम बनाने के लिए नमूना कोड और स्वचालन तकनीकों की खोज करें।"
---
## **परिचय**

PowerPoint प्रस्तुति को वीडियो में परिवर्तित करने से आपको मिलता है  

* **पहुंच में वृद्धि:** सभी उपकरणों (प्लेटफ़ॉर्म की परवाह किए बिना) में डिफ़ॉल्ट रूप से वीडियो प्लेयर होते हैं, जबकि प्रस्तुति‑खोलने वाले एप्लिकेशन नहीं होते, इसलिए उपयोगकर्ताओं को वीडियो खोलना या चलाना आसान लगाता है।  
* **अधिक दर्शक:** वीडियो के माध्यम से आप बड़े दर्शकों तक पहुंच सकते हैं और उन्हें ऐसी जानकारी दे सकते हैं जो प्रस्तुति में थकाऊ लग सकती है। अधिकांश सर्वेक्षण और आँकड़े संकेत देते हैं कि लोग अन्य सामग्री की तुलना में वीडियो देखना और उपभोग करना अधिक पसंद करते हैं, और वे सामान्यतः ऐसी सामग्री को प्राथमिकता देते हैं।

{{% alert color="primary" %}} 

आप हमारे [**PowerPoint से वीडियो ऑनलाइन कनवर्टर**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) की जाँच करना चाहेंगे क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव और प्रभावी कार्यान्वयन है।

{{% /alert %}} 

## **Aspose.Slides में PowerPoint से वीडियो रूपांतरण**

Aspose.Slides प्रस्तुति‑से‑वीडियो रूपांतरण का समर्थन करता है।

* **Aspose.Slides** का उपयोग करके फ्रेमों का सेट (प्रेजेंटेशन स्लाइड्स से) उत्पन्न करें जो एक निश्चित FPS (फ़्रेम प्रति सेकंड) के अनुरूप हो।  
* **ffmpeg** जैसी तृतीय‑ पक्ष यूटिलिटी ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) का प्रयोग करके फ्रेमों के आधार पर वीडियो बनाएं।  

### **PowerPoint को वीडियो में बदलें**

1. इस कोड को अपने POM फ़ाइल में जोड़ें:  
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg डाउनलोड करें [here](https://ffmpeg.org/download.html)।

4. PowerPoint को वीडियो में बदलने वाला Java कोड चलाएँ।

यह Java कोड दिखाता है कि कैसे एक प्रस्तुति (जिसमें चित्र और दो एनीमेशन इफ़ेक्ट हैं) को वीडियो में बदला जाता है:

```java
Presentation presentation = new Presentation();
try {
    // Adds a smile shape and then animates it
    // एक स्माइल आकार जोड़ता है और फिर उसे एनिमेट करता है
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

    // Configure ffmpeg binaries folder. See this page: https://github.com/rosenbjerg/FFMpegCore#installation
    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **वीडियो प्रभाव**

आप स्लाइड्स पर ऑब्जेक्ट्स पर एनीमेशन लागू कर सकते हैं और स्लाइड्स के बीच ट्रांज़िशन का उपयोग कर सकते हैं।  

{{% alert color="primary" %}} 

आप इन लेखों को देख सकते हैं: [PowerPoint Animation](https://docs.aspose.com/slides/hi/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/androidjava/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/androidjava/shape-effect/)।

{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वही प्रभाव वीडियो पर भी लागू होते हैं। चलिए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```java
// एक स्माइल आकार जोड़ता है और उसे एनीमेट करता है

// ...

// एक नई स्लाइड जोड़ता है और एनीमेटेड ट्रांज़िशन सेट करता है

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides पाठों के लिए भी एनीमेशन का समर्थन करता है। इसलिए हम ऑब्जेक्ट्स पर पैराग्राफ़ को एनीमेट करते हैं, जो एक‑के‑बाद‑एक (एक सेकंड की देर से) दिखाई देंगे:

```java
Presentation presentation = new Presentation();
try {
    // टेक्स्ट और एनीमेशन जोड़ता है
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

    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
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

## **वीडियो रूपांतरण क्लासेस**

PowerPoint को वीडियो रूपांतरण कार्य करने के लिए Aspose.Slides **[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/)** और **[PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/)** क्लासेस प्रदान करता है।

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/) आपको वीडियो (जो बाद में बनाया जाएगा) के फ्रेम आकार को उसके कंस्ट्रक्टर के माध्यम से सेट करने देता है। यदि आप प्रस्तुति का एक इंस्टेंस पास करते हैं, तो `Presentation.SlideSize` उपयोग किया जाएगा और यह एनीमेशन जनरेट करता है जिसे [PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/) उपयोग करता है।

एनीमेशन जनरेट होने पर प्रत्येक क्रमिक एनीमेशन के लिए एक `NewAnimation` इवेंट उत्पन्न होता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/) पैरामीटर रहता है। यह क्लास एक अलग एनीमेशन के प्लेयर को दर्शाता है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/) के साथ काम करने के लिए, **Duration** (एनीमेशन की कुल अवधि) प्रॉपर्टी और **SetTimePosition** मेथड का उपयोग किया जाता है। प्रत्येक एनीमेशन पोज़िशन को *0 से duration* रेंज में सेट किया जाता है, और फिर `GetFrame` मेथड उस क्षण की एनीमेशन स्थिति से संबंधित एक `BufferedImage` लौटाता है:

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
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // एनीमेशन का अंतिम फ्रेम
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

सभी एनीमेशन को एक साथ चलाने के लिए, **[PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/)** क्लास का उपयोग किया जाता है। यह क्लास एक **[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/)** इंस्टेंस और FPS को कंस्ट्रक्टर में लेता है और फिर सभी एनीमेशन के लिए `FrameTick` इवेंट को कॉल करके उन्हें चलाता है:

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

इसके बाद उत्पन्न फ्रेमों को जोड़कर वीडियो बनाया जाता है। देखें **[Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video)** अनुभाग।

## **समर्थित एनीमेशन और प्रभाव**

**प्रवेश (Entrance):**

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

**जोर (Emphasis):**

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

**निर्गम (Exit):**

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

**गति पथ (Motion Paths):**

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को परिवर्तित करना संभव है?**

हां, Aspose.Slides [पासवर्ड‑सुरक्षित प्रस्तुतियों](/slides/hi/androidjava/password-protected-presentation/) को संभालने की अनुमति देता है। ऐसी फाइलों को प्रोसेस करने के लिए आपको सही पासवर्ड देना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

**क्या Aspose.Slides क्लाउड समाधान में उपयोगी है?**

हां, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे फ़ाइलों के बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी सुनिश्चित होती है।

**रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई सीमा है क्या?**

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और कभी‑कभी प्रदर्शन सुधार के लिए प्रस्तुति को ऑप्टिमाइज़ करने की सिफ़ारिश की जाती है।