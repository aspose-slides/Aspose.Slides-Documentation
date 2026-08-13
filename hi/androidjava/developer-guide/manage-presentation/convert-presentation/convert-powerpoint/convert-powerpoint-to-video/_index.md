---
title: "एंड्रॉइड पर PowerPoint प्रस्तुतियों को वीडियो में बदलें"
linktitle: "PowerPoint को वीडियो में"
type: docs
weight: 130
url: /hi/androidjava/convert-powerpoint-to-video/
keywords:
- "PowerPoint को बदलें"
- "प्रस्तुति को बदलें"
- "PPT को बदलें"
- "PPTX को बदलें"
- "PowerPoint से वीडियो"
- "प्रस्तुति से वीडियो"
- "PPT से वीडियो"
- "PPTX से वीडियो"
- "PowerPoint से MP4"
- "प्रस्तुति से MP4"
- "PPT से MP4"
- "PPTX से MP4"
- "PPT को MP4 के रूप में सहेजें"
- "PPTX को MP4 के रूप में सहेजें"
- "PPT को MP4 में निर्यात करें"
- "PPTX को MP4 में निर्यात करें"
- "वीडियो रूपांतरण"
- "PowerPoint"
- "Android"
- "Java"
- "Aspose.Slides"
description: "जावा में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। नमूना कोड और स्वचालन तकनीकों की खोज करें ताकि आपका कार्यप्रवाह सहज हो जाए।"
---
## **परिचय**

अपने PowerPoint प्रस्तुति को वीडियो में बदलकर, आपको मिलता है 

* **पहुँच में वृद्धि:** सभी उपकरण (प्लेटफ़ॉर्म की परवाह किए बिना) डिफ़ॉल्ट रूप से वीडियो प्लेयर से सुसज्जित होते हैं, जबकि प्रस्तुति खोलने वाले अनुप्रयोग नहीं, इसलिए उपयोगकर्ताओं के लिए वीडियो खोलना या चलाना आसान होता है।
* **अधिक पहुंच:** वीडियो के माध्यम से आप बड़ी दर्शक संख्या तक पहुँच सकते हैं और उन्हें ऐसी जानकारी दे सकते हैं जो प्रस्तुति में अक्सर थकाऊ लगती है। अधिकांश सर्वेक्षण और आँकड़े दिखाते हैं कि लोग अन्य सामग्री रूपों की तुलना में वीडियो अधिक देखते और उपभोग करते हैं, और आम तौर पर ऐसी सामग्री को प्राथमिकता देते हैं।

## **Aspose.Slides में PowerPoint से वीडियो रूपांतरण**

* **Aspose.Slides** का उपयोग करके प्रस्तुति स्लाइड्स से फ्रेम्स का सेट बनाएँ जो किसी निश्चित FPS (फ़्रेम प्रति सेकंड) के अनुरूप हो।
* **ffmpeg** जैसे तृतीय‑पक्ष यूटिलिटी ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) का उपयोग करके फ्रेम्स के आधार पर वीडियो बनाएँ। 

### **PowerPoint को वीडियो में बदलें**

1. अपने POM फ़ाइल में इसे जोड़ें:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. ffmpeg डाउनलोड करें [here](https://ffmpeg.org/download.html).

3. PowerPoint को वीडियो में बदलने वाला Java कोड चलाएँ।

यह Java कोड दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक चित्र और दो एनीमेेशन इफ़ेक्ट्स हैं) को वीडियो में बदलें:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // एक स्माइल आकार जोड़ता है और फिर उसे एनीमेट करता है
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

    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/bramp/ffmpeg-cli-wrapper
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

आप स्लाइड्स पर ऑब्जेक्ट्स पर एनीमेेशन लागू कर सकते हैं और स्लाइड्स के बीच ट्रांज़िशन का उपयोग कर सकते हैं। 

{{% alert color="info" %}} 
आप इन लेखों को देख सकते हैं: [PowerPoint Animation](https://docs.aspose.com/slides/hi/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/androidjava/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/androidjava/shape-effect/).
{{% /alert %}} 

एनीमेेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वे वीडियो के लिए भी यही करते हैं। चलिए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:
```java
import com.aspose.slides.*;
import java.awt.Color;

// ऊपर बनाए गए एनीमेटेड स्माइल आकार वाली प्रस्तुति।
Presentation presentation = new Presentation();
try {
    // एक नई स्लाइड और एनीमेटेड ट्रांज़िशन जोड़ता है

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides भी टेक्स्ट के लिए एनीमेेशन का समर्थन करता है। इसलिए हम ऑब्जेक्ट्स पर पैराग्राफ़ को एनीमेट करते हैं, जो एक के बाद एक दिखाई देंगे (विलंब एक सेकंड पर सेट) :
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // पाठ और एनीमेेशन जोड़ता है
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

    // ffmpeg बाइनरी फ़ोल्डर को कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/bramp/ffmpeg-cli-wrapper
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

PowerPoint को वीडियो में बदलने के कार्य करने के लिए, Aspose.Slides [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/) क्लासेस प्रदान करता है।

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/) आपको कंस्ट्रक्टर के माध्यम से वीडियो (जो बाद में बनाया जाएगा) के लिए फ्रेम आकार सेट करने की अनुमति देता है। यदि आप प्रस्तुति का एक उदाहरण पास करते हैं, तो `Presentation.SlideSize` उपयोग किया जाएगा और यह ऐसी एनीमेेशन उत्पन्न करता है जिन्हें [PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/) उपयोग करता है।

जब एनीमेेशन उत्पन्न होते हैं, तो प्रत्येक क्रमिक एनीमेेशन के लिए एक `NewAnimation` इवेंट उत्पन्न होता है, जिसमें [IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/) पैरामीटर होता है। यह क्लास अलग एनीमेेशन के लिए प्लेयर को दर्शाती है।

[IPresentationAnimationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/) के साथ काम करने के लिए, [Duration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (एनीमेेशन की पूरी अवधि) प्रॉपर्टी और [SetTimePosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) मेथड उपयोग की जाती हैं। प्रत्येक एनीमेेशन स्थिति *0 to duration* सीमा में सेट की जाती है, और फिर `getFrame` मेथड उस क्षण की एनीमेेशन स्थिति के अनुरूप एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) लौटाता है:
```java
import com.aspose.slides.*;

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
            // प्रारंभिक एनीमेशन स्थिति बिटमैप
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // एनीमेशन की अंतिम स्थिति
            // एनीमेशन का अंतिम फ्रेम
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // एनीमेशन उत्पन्न करें। ऊपर वाला कॉलबैक प्रत्येक के लिये चलाया जाता है।
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

सभी एनीमेेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationplayer/) क्लास उपयोग किया जाता है। यह क्लास अपने कंस्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationanimationsgenerator/) इंस्टेंस और प्रभावों के लिए FPS लेती है और फिर सभी एनीमेेशन को चलाने के लिए `FrameTick` इवेंट को कॉल करती है:
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

फिर उत्पन्न फ्रेम्स को संकलित करके वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video) अनुभाग।

## **समर्थित एनीमेेशन और इफ़ेक्ट्स**

**प्रवेश**:

| एनीमेेशन प्रकार | Aspose.Slides | PowerPoint |
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

| एनीमेेशन प्रकार | Aspose.Slides | PowerPoint |
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

| एनीमेेशन प्रकार | Aspose.Slides | PowerPoint |
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

| एनीमेेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **FAQ**

### क्या पासवर्ड-संरक्षित प्रस्तुतियों को बदलना संभव है?

हाँ, Aspose.Slides [password‑protected presentations](/slides/hi/androidjava/password-protected-presentation/) के साथ काम करने की अनुमति देता है। ऐसे फ़ाइलों को प्रोसेस करते समय आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुँच सके।

### क्या Aspose.Slides क्लाउड समाधान में उपयोग का समर्थन करता है?

हाँ, Aspose.Slides को क्लाउड अनुप्रयोगों और सेवाओं में एकीकृत किया जा सकता है। लाइब्रेरी सर्वर वातावरण में काम करने के लिए डिज़ाइन की गई है, जिससे फ़ाइलों के बैच प्रोसेसिंग के लिए उच्च प्रदर्शन और स्केलेबिलिटी मिलती है।

### रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई प्रतिबंध है?

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन सुधारने के लिए प्रस्तुति को अनुकूलित करने की सलाह दी जा सकती है।