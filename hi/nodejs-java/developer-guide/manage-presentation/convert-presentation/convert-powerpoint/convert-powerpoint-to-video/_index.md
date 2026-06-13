---
title: JavaScript में PowerPoint प्रस्तुतियों को वीडियो में बदलें
linktitle: PowerPoint से वीडियो
type: docs
weight: 130
url: /hi/nodejs-java/convert-powerpoint-to-video/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint को वीडियो में बदलें
- प्रस्तुति को वीडियो में बदलें
- PPT को वीडियो में बदलें
- PPTX को वीडियो में बदलें
- PowerPoint को MP4 में बदलें
- प्रस्तुति को MP4 में बदलें
- PPT को MP4 में बदलें
- PPTX को MP4 में बदलें
- PPT को MP4 के रूप में सहेजें
- PPTX को MP4 के रूप में सहेजें
- PPT को MP4 में निर्यात करें
- PPTX को MP4 में निर्यात करें
- वीडियो रूपांतरण
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PowerPoint प्रस्तुतियों को वीडियो में बदलना सीखें। नमूना कोड और स्वचालन तकनीकों की खोज करें जो आपके कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

PowerPoint प्रस्तुति को वीडियो में परिवर्तित करके, आपको प्राप्त होता है 

* **सुलभता में वृद्धि:** सभी उपकरण (प्लेटफ़ॉर्म की परवाह किए बिना) डिफ़ॉल्ट रूप से वीडियो प्लेयर के साथ सुसज्जित होते हैं, जबकि प्रस्तुति‑खोलने वाले अनुप्रयोग नहीं, इसलिए उपयोगकर्ताओं को वीडियो खोलना या चलाना आसान लगता है।
* **अधिक पहुँच:** वीडियो के माध्यम से, आप बड़ी दर्शक संख्या तक पहुँ सकते हैं और उन्हें ऐसी जानकारी प्रदान कर सकते हैं जो प्रस्तुति में नीरस लग सकती है। अधिकांश सर्वेक्षण और आँकड़े दर्शाते हैं कि लोग वीडियो को अन्य सामग्री के रूपों की तुलना में अधिक देखते और उपभोग करते हैं, और आमतौर पर वे ऐसी सामग्री को प्राथमिकता देते हैं।

{{% alert color="primary" %}} 
आप हमारी [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-word) को देखना चाह सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का एक लाइव और प्रभावी कार्यान्वयन है।
{{% /alert %}} 

## **Aspose.Slides में PowerPoint से वीडियो रूपांतरण**

Aspose.Slides प्रस्तुति‑से‑वीडियो रूपांतरण का समर्थन करता है।

* **Aspose.Slides** का उपयोग करके फ्रेम्स का एक सेट (प्रस्तुति स्लाइड्स से) उत्पन्न करें जो किसी निश्चित FPS (फ़्रेम प्रति सेकंड) के अनुरूप हों।
* **ffmpeg** जैसी तृतीय‑पक्ष उपयोगिता ([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) का उपयोग करके फ्रेम्स के आधार पर वीडियो बनाएँ। 

### **PowerPoint को वीडियो में बदलें**

1. ffmpeg डाउनलोड करें [यहाँ](https://ffmpeg.org/download.html).
2. PowerPoint को वीडियो में बदलने वाला JavaScript कोड चलाएँ।

यह JavaScript कोड आपको दिखाता है कि कैसे एक प्रस्तुति (जिसमें एक चित्र और दो एनीमेशन इफ़ेक्ट हैं) को वीडियो में बदलें:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // एक स्माइली आकार जोड़ता है और फिर उसे एनीमेट करता है
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg बाइनरी फ़ोल्डर कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **वीडियो इफ़ेक्ट्स**

आप स्लाइड्स पर वस्तुओं पर एनीमेशन लागू कर सकते हैं और स्लाइड्स के बीच ट्रांज़िशन का उपयोग कर सकते हैं। 

{{% alert color="primary" %}} 
आप इन लेखों को देखना चाह सकते हैं: [PowerPoint Animation](https://docs.aspose.com/slides/hi/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/hi/nodejs-java/shape-animation/), और [Shape Effect](https://docs.aspose.com/slides/hi/nodejs-java/shape-effect/)।
{{% /alert %}} 

एनीमेशन और ट्रांज़िशन स्लाइडशो को अधिक आकर्षक और रोचक बनाते हैं—और वीडियो के लिए भी यही काम करते हैं। चलिए पिछले प्रस्तुति के कोड में एक और स्लाइड और ट्रांज़िशन जोड़ते हैं:

```javascript
// एक स्माइली आकार जोड़ता है और उसे एनीमेट करता है
// ...
// एक नई स्लाइड जोड़ता है और एनीमेटेड ट्रांज़िशन सेट करता है
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides टेक्स्ट के लिए भी एनीमेशन का समर्थन करता है। इसलिए हम वस्तुओं पर पैराग्राफ़ को एनीमेट करते हैं, जो एक‑के‑बाद‑एक दिखाई देंगे (विलंब एक सेकंड पर सेट किया गया है):

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // टेक्स्ट और एनीमेशन जोड़ता है
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // ffmpeg बाइनरी फ़ोल्डर कॉन्फ़िगर करें। इस पृष्ठ को देखें: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **वीडियो रूपांतरण क्लासेज**

PowerPoint को वीडियो में बदलने के कार्य करने के लिए, Aspose.Slides निम्नलिखित क्लासेज प्रदान करता है: [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationanimationsgenerator/) और [PresentationPlayer](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationplayer/)।

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationanimationsgenerator/) आपको वीडियो (जो बाद में बनाया जाएगा) के फ़्रेम आकार को उसके कन्स्ट्रक्टर के माध्यम से सेट करने देता है। यदि आप प्रस्तुति का एक इंस्टेंस पास करते हैं, तो `Presentation.getSlideSize` उपयोग होगा और यह एनीमेशन बनाता है जिसे [PresentationPlayer](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationplayer/) उपयोग करता है।

जब एनीमेशन जनरेट होते हैं, तो प्रत्येक बाद की एनीमेशन के लिए एक `NewAnimation` इवेंट जनरेट होता है, जिसमें प्रस्तुति एनीमेशन प्लेयर पैरामीटर होता है। यह एक क्लास है जो अलग एनीमेशन के लिए प्लेयर को दर्शाता है।

प्रेजेंटेशन एनीमेशन प्लेयर के साथ काम करने के लिए, `getDuration` (एनीमेशन की पूरी अवधि) मेथड और `setTimePosition` मेथड का उपयोग किया जाता है। प्रत्येक एनीमेशन पोज़िशन को *0 से duration* रेंज के भीतर सेट किया जाता है, और फिर `getFrame` मेथड एक BufferedImage लौटाता है जो उस क्षण की एनीमेशन स्थिति के अनुरूप होता है:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // स्माइली आकार जोड़ता है और उसे एनीमेट करता है
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// प्रारंभिक एनीमेशन स्थिति
            try {
                // प्रारंभिक एनीमेशन स्थिति बिटमैप
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// एनीमेशन की अंतिम स्थिति
            try {
                // एनीमेशन का अंतिम फ्रेम
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

प्रेजेंटेशन में सभी एनीमेशन को एक साथ चलाने के लिए, [PresentationPlayer](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationplayer/) क्लास का उपयोग किया जाता है। यह क्लास अपने कन्स्ट्रक्टर में एक [PresentationAnimationsGenerator](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationanimationsgenerator/) इंस्टेंस और इफ़ेक्ट्स के लिए FPS लेता है और फिर सभी एनीमेशन के लिए `FrameTick` इवेंट को कॉल करता है ताकि उन्हें चलाया जा सके:

```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

फिर जनरेटेड फ़्रेम्स को कंपाइल करके एक वीडियो बनाया जा सकता है। देखें [Convert PowerPoint to Video](https://docs.aspose.com/slides/hi/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video) सेक्शन।

## **समर्थित एनीमेशन और इफ़ेक्ट्स**

**प्रवेश**

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**जोर**

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**निकास**

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
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

**गति पथ**

| एनीमेशन प्रकार | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Arcs** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Turns** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Shapes** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Loops** | ![समर्थित](v.png) | ![समर्थित](v.png) |
| **Custom Path** | ![समर्थित](v.png) | ![समर्थित](v.png) |

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या पासवर्ड‑सुरक्षित प्रस्तुतियों को बदलना संभव है?**

हाँ, Aspose.Slides पासवर्ड‑सुरक्षित प्रस्तुतियों के साथ काम करने की अनुमति देता है। ऐसे फ़ाइलों को प्रोसेस करते समय, आपको सही पासवर्ड प्रदान करना होगा ताकि लाइब्रेरी प्रस्तुति की सामग्री तक पहुंच सके।

**क्या Aspose.Slides क्लाउड समाधान में उपयोग के लिए समर्थित है?**

हाँ, Aspose.Slides को क्लाउड एप्लिकेशन और सेवाओं में एकीकृत किया जा सकता है। यह लाइब्रेरी सर्वर वातावरण में काम करने के लिये डिज़ाइन की गई है, जिससे फ़ाइलों के बैच प्रोसेसिंग के लिये उच्च प्रदर्शन और स्केलेबिलिटी मिलती है।

**रूपांतरण के दौरान प्रस्तुतियों के आकार पर कोई सीमाएँ हैं क्या?**

Aspose.Slides लगभग किसी भी आकार की प्रस्तुतियों को संभाल सकता है। हालांकि, बहुत बड़े फ़ाइलों के साथ काम करते समय अतिरिक्त सिस्टम संसाधनों की आवश्यकता हो सकती है, और प्रदर्शन बेहतर करने के लिये प्रस्तुति को अनुकूलित करने की सलाह दी जाती है।