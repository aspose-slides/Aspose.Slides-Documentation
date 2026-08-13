---
title: Java में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Java में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। नमूना कोड और स्वचालन तकनीकों की खोज करें ताकि आपका कार्यप्रवाह सरल हो सके।"
---
## **परिचय**

PowerPoint या OpenDocument प्रस्तुतियों को वीडियो में बदलने से आपको मिलता है:

**पहुंच में वृद्धि:** सभी उपकरण, चाहे किस प्लेटफ़ॉर्म पर हों, डिफ़ॉल्ट रूप से वीडियो प्लेयर के साथ आते हैं, जिससे उपयोगकर्ताओं के लिए वीडियो खोलना या चलाना पारंपरिक प्रस्तुति एप्लिकेशन की तुलना में आसान हो जाता है।

**व्यापक दर्शक वर्ग:** वीडियो आपको बड़े दर्शकों तक पहुँचना और जानकारी को अधिक आकर्षक रूप में प्रस्तुत करना संभव बनाते हैं। सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग अन्य रूपों की तुलना में वीडियो सामग्री देखना और उपभोग करना पसंद करते हैं, जिससे आपका संदेश अधिक प्रभावी बनता है।

{{% alert color="info" %}} 
आप हमारे [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hi/video) को देखना चाहेंगे क्योंकि यह यहाँ वर्णित प्रक्रिया का एक जीवंत और प्रभावी कार्यान्वयन है।
{{% /alert %}} 

## **Aspose.Slides में PowerPoint को वीडियो रूपांतरण**

[Aspose.Slides 22.11](https://docs.aspose.com/slides/hi/java/aspose-slides-for-java-22-11-release-notes/) में हमने प्रस्तुति को वीडियो रूपांतरण के लिए समर्थन लागू किया।

* **Aspose.Slides** का उपयोग करके प्रस्तुति स्लाइडों से ऐसी फ्रेम सेट बनाएं जो निश्चित FPS (प्रति सेकंड फ्रेम) के अनुरूप हों
* **ffmpeg** जैसी तृतीय‑पक्ष यूटिलिटी ([जावा के लिए](https://github.com/bramp/ffmpeg-cli-wrapper)) का उपयोग करके फ्रेम से वीडियो बनाएं।

### **PowerPoint को वीडियो में बदलें**

1. अपने POM फ़ाइल में यह जोड़ें:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg [यहाँ](https://ffmpeg.org/download.html) से डाउनलोड करें।

4. PowerPoint से वीडियो बनाने के लिए जावा कोड चलाएँ।

यह जावा कोड दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक आकृति और दो एनिमेशन इफ़ेक्ट हैं) को वीडियो में बदला जाता है:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // एक स्माइल शैप जोड़ता है और फिर उसे एनीमेट करता है
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

    // ffmpeg बायनरी फोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
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

आप स्लाइडों में वस्तुओं पर एनीमेशन लागू कर सकते हैं और स्लाइडों के बीच ट्रांज़िशन का उपयोग कर सकते हैं।

{{% alert color="info" %}} 
आप ये लेख देख सकते हैं: [PowerPoint Animation](https://docs.aspose.com/slides/hi/java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/java/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/java/shape-effect/)।
{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक बनाते हैं—और वीडियो के लिए भी यही लागू होता है। चलिए पिछले प्रस्तुति कोड में एक अतिरिक्त स्लाइड और ट्रांज़िशन जोड़ते हैं:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // एक स्माइल शैप जोड़ता है और उसे एनीमेट करता है

    // ...

    // एक नई स्लाइड जोड़ता है और एनीमेटेड ट्रांज़िशन सेट करता है

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides टेक्स्ट के लिए भी एनीमेशन का समर्थन करता है। इसलिए हम वस्तुओं पर पैराग्राफ़ को एनीमेट करते हैं, जो क्रमशः (एक सेकंड के विलंब के साथ) प्रदर्शित होते हैं:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

PowerPoint से वीडियो रूपांतरण कार्यों को करने के लिए, Aspose.Slides द्वारा [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) क्लासेस प्रदान किए जाते हैं।

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) आपको कन्स्ट्रक्टर के माध्यम से वीडियो का फ्रेम आकार सेट करने की अनुमति देता है। यदि आप प्रस्तुति का एक इंस्टैंस पास करते हैं, तो `Presentation.SlideSize` उपयोग किया जाएगा और यह ऐसी एनीमेशन उत्पन्न करता है जिन्हें [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) उपयोग करता है।

जब एनीमेशन जनरेट होते हैं, तो प्रत्येक क्रमिक एनीमेशन के लिए एक `NewAnimation` इवेंट उत्पन्न होता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/) पैरामीटर होता है। latter एक क्लास है जो अलग एनीमेशन के प्लेयर को दर्शाता है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/) के साथ काम करने के लिए, [Duration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (एनीमेशन की पूरी अवधि) प्रॉपर्टी और [SetTimePosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) मेथड उपयोग की जाती हैं। प्रत्येक एनीमेशन पोजीशन *0 से duration* रेंज के भीतर सेट की जाती है, और फिर `getFrame` मेथड वर्तमान क्षण में एनीमेशन स्थिति के अनुरूप एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) लौटाता है:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // एक स्माइल शैप जोड़ता है और उसे एनीमेट करता है
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
            // प्रारंभिक एनीमेशन स्थिति बिटमैप
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // एनीमेशन की अंतिम स्थिति
            // एनीमेशन का अंतिम फ्रेम
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // एनीमेशन जनरेट करें - यह वही है जो ऊपर संभाले गए इवेंट को ट्रिगर करता है
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationplayer/) क्लास उपयोग की जाती है। यह क्लास एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationanimationsgenerator/) इंस्टैंस और इफ़ेक्ट्स के लिए FPS को कन्स्ट्रक्टर में लेती है और फिर सभी एनीमेशन के लिए `FrameTick` इवेंट कॉल करती है:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

फिर उत्पन्न फ्रेम को मिलाकर एक वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/java/convert-powerpoint-to-video/#convert-powerpoint-to-video) अनुभाग।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

**प्रवेश (Entrance):**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fade** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Fly In** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Float In** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Split** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wipe** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shape** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wheel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Random Bars** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Grow & Turn** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Zoom** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Swivel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Bounce** | ![समर्थित](v.png) | ![समर्थित](v.png) |

**जोर (Emphasis):**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Color Pulse** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Teeter** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Spin** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Grow/Shrink** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Desaturate** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Darken** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Lighten** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Transparency** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Object Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Complementary Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Line Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fill Color** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |

**निकास (Exit):**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Fade** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Fly Out** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Float Out** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Split** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Wipe** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shape** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Random Bars** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shrink & Turn** | ![समर्थित नहीं](x.png) | ![समर्थित](v.png) |
| **Zoom** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Swivel** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Bounce** | ![समर्थित](v.png) | ![समर्थित](v.png) |

**मोशन पाथ्स (Motion Paths):**

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Arcs** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Turns** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shapes** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Loops** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Custom Path** | ![समर्थित](v.png) | ![समर्थित](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को परिवर्तित किया जा सकता है?

हाँ, Aspose.Slides [पासवर्ड‑सुरक्षित प्रस्तुतियों](/slides/hi/java/password-protected-presentation/) के साथ काम करने की अनुमति देता है। ऐसी फ़ाइलों को प्रोसेस करते समय आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

### क्या Aspose.Slides क्लाउड समाधान में उपयोग की जा सकती है?

हाँ, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे फ़ाइलों की बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी सुनिश्चित होती है।

### रूपांतरण के दौरान प्रस्तुतियों का आकार सीमित है क्या?

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभालने में सक्षम है। हालांकि, बहुत बड़ी फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुति को अनुकूलित करने की सलाह दी जा सकती है।