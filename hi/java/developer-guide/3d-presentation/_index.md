---
title: "Java का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं"
linktitle: "3D प्रस्तुति"
type: docs
weight: 232
url: /hi/java/3d-presentation/
keywords:
- "3D पॉवरपॉइंट"
- "3D प्रस्तुति"
- "3D घूर्णन"
- "3D गहराई"
- "3D एक्सट्रूज़न"
- "3D ग्रेडिएंट"
- "3D टेक्स्ट"
- "PowerPoint"
- "प्रस्तुति"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides के साथ Java में PowerPoint आकृतियों और टेक्स्ट के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, फ़िल, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **परिचय**

Aspose.Slides for Java आकृतियों और टेक्स्ट के लिए PowerPoint‑स्टाइल 3D फ़ॉर्मेटिंग बनाने, संपादित करने, संरक्षित करने और रेंडर करने में सक्षम है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, प्रकाश, मैटेरियल, ग्रेडिएंट या चित्र फ़िल, और 3D टेक्स्ट जैसी 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="ध्यान दें" %}}

यह लेख PowerPoint आकृतियों और टेक्स्ट पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।

{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

आकार पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getThreeDFormat--) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) मेथड का उपयोग करें। यह टेक्स्ट फ़्रेम पर 3D फ़ॉर्मेटिंग लागू करता है, न कि आकार बॉडी पर।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getCamera--) | दृष्टिकोण, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्पेस में घुमाने या PowerPoint के 3D घूर्णन प्रीसेट से मिलाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getLightRig--) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और छाया को बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getMaterial--) और [setMaterial](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | समान ज्यामिति को अधिक समतल, नरम, चमकदार, या धातु जैसा बनाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | आकार के सामने वाले चेहरे से पीछे की ओर कितना विस्तार है। | फ्लैट आकार को स्पष्ट रूप से मोटा 3D ऑब्जेक्ट बनाने के लिए। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | एक्सट्रूज़्ड पक्षों का रंग। | गहराई को दिखाने या पक्ष के रंग को सामने के फ़िल के साथ समन्वयित करने के लिए। |
| [getDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getDepth--) और [setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ मिलाकर आकार या टेक्स्ट की गहराई को सूक्ष्म रूप से समायोजित करने के लिए। |
| [getBevelTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getBevelTop--) और [getBevelBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | सामने और पीछे के चेहरों पर उठे हुए या गोल किनारे। | तेज़ सपाट चेहरा के बजाय मुलायम या ढाँचा हुआ किनारा जोड़ने के लिए। |
| [getContourColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getContourColor--) और [getContourWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getContourWidth--) और [setContourWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D ऑब्जेक्ट के चारों ओर की रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट की सीमा को स्पष्ट करने के लिए। |

## **3D आकृति बनाएँ**

एक आकृति को विश्वसनीय 3D दिखाने से पहले आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट सामने वाला दृश्य एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और पक्षों को पठनीय बनाता है।
- मैटेरियल सेटिंग्स, क्योंकि सतह प्रकाश के प्रतिबिंब को प्रभावित करती है।
- एक्सट्रूज़न या डेप्थ सेटिंग्स, क्योंकि फ्लैट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने वाले चेहरे पर टेक्स्ट जोड़ता है, और 3D फ़ॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को दो गुना डिफ़ॉल्ट आकार के PNG चित्र में रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

रेंडर की गई स्लाइड छवि आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ आकृति को घुमाएँ**

PowerPoint में 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में कैमरा को [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getCamera--) के माध्यम से एक्सेस करें। यह उदाहरण एक आयत बनाता है, ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और क्रमशः X, Y, Z घूर्णन को 20, 30, और 40 डिग्री सेट करता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

जब आपको दर्शक के ऑब्जेक्ट को देखने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमेट्री को नहीं बदलता, बल्कि PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रूज़न और डेप्थ जोड़ें**

एक्सट्रूज़न आकार को आगे के चेहरे से पीछे की ओर विस्तारित करके मोटा बनाता है। PowerPoint में डेप्थ नियंत्रण इस दृश्य मोटाई को निर्धारित करता है, और रंग नियंत्रण पक्षों के रंग को निर्धारित करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

एक्सट्रूज़न की मोटाई सेट करने के लिए [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) का उपयोग करें और पक्ष के रंग को प्राप्त करने के लिए [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) का उपयोग करें। यह उदाहरण आयत को 100‑पॉइंट एक्सट्रूज़न के साथ बैंगनी पक्ष देता है और कैमरा को घुमा कर उसकी मोटाई दिखाता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setDepth-double-) मेथड 3D आकार की गहराई सेट करता है। [setExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) मेथड एक्सट्रूज़न इफ़ेक्ट की ऊँचाई को नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या चित्र फ़िल लागू करें**

3D फ़ॉर्मेटिंग आकृति के फ़िल से स्वतंत्र है। आप सामने वाले चेहरे पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र फ़िल लागू कर सकते हैं और फिर भी समान कैमरा, लाइट, मैटेरियल, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण सामने वाले चेहरे पर नीले‑से‑संतरी रंग ग्रेडिएंट और 150‑पॉइंट एक्सट्रूज़न पर गहरा संतरी रंग लागू करता है। ग्रेडिएंट स्टॉप 0 और 100 पर क्रमशः ग्रेडिएंट की शुरुआत और समाप्ति को दर्शाते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को दो गुना डिफ़ॉल्ट आकार के PNG चित्र में रेंडर किया गया है:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

रेंडर किया गया आउटपुट ग्रेडिएंट को सामने वाले चेहरे पर रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

चित्र फ़िल उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकृति फ़िल के रूप में असाइन करें। यह उदाहरण कार्यकारी निर्देशिका में मौज़ूद "image.jpg" नामक फ़ाइल की आवश्यकता रखता है। यह चित्र को आयत में भरने के लिए खींचता है, 150‑पॉइंट एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकृति को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

चित्र सामने वाले चेहरे पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **टेक्स्ट पर 3D फ़ॉर्मेटिंग लागू करें**

आकृति की 3D फ़ॉर्मेटिंग आकार बॉडी को प्रभावित करती है। टेक्स्ट की 3D फ़ॉर्मेटिंग टेक्स्ट फ़्रेम को प्रभावित करती है। यह WordArt‑सम और प्रभावी है जहाँ अक्षर खुद एक्सट्रूज़न, मैटेरियल, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता रखते हैं।

निम्न उदाहरण एक ऑरेंज‑और‑वाइट ग्रिड पैटर्न वाला टेक्स्ट बनाता है, ऊपर की ओर एक आर्च लागू करता है, और [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और डेप्थ पॉइंट में हैं, और लाइट घूर्णन डिग्री में है। आकार फ़िल और आउटलाइन छिपाए गए हैं ताकि केवल टेक्स्ट ही दिखाई दे। उदाहरण दो गुना डिफ़ॉल्ट स्लाइड आयाम पर PNG चित्र रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

टेक्स्ट को वक्र, एक्सट्रूज़ड 3D अक्षर में रेंडर किया गया है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **3D आकृति पर टेक्स्ट को समतल रखें**

टेक्स्ट को 3D सीन से बाहर रखते हुए भी आकृति की 3D उपस्थिति बनाए रखने के लिए, [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframe/#getTextFrameFormat--) के माध्यम से [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) को `true` सेट करें। जब मान `true` होता है, तो टेक्स्ट 3D सीन से बाहर रहता है। जब `false` होता है, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का अनुसरण करता है।

यह सेटिंग आकार की 3D फ़ॉर्मेटिंग को नहीं हटाती: उसका कैमरा, लाइटिंग, मैटेरियल, और एक्सट्रूज़न अभी भी [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getThreeDFormat--) के माध्यम से कॉन्फ़िगर है। यह सामान्य घूर्णन से भी अलग है। [IShape.setRotation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#setRotation-float-) स्लाइड प्लेन में आकार को घुमाता है, जबकि [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घूर्णन को नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखना इन कोणों में से किसी को भी रीसेट नहीं करता।

निम्न स्वनिर्भर उदाहरण एक नीले आयत को टेक्स्ट के साथ बनाता है और इसे मूल के बगल में क्लोन करता है। दोनों आकृतियों में समान 3D फ़ॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएँ पर `false` और दाएँ पर `true`। कैमरा कोण डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को दो गुना डिफ़ॉल्ट आयाम पर PNG में रेंडर करता है।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

बाएँ पर टेक्स्ट 3D अभिविन्यास का पालन करता है। दाएँ पर टेक्स्ट समतल रहता है और पढ़ने में आसान होता है। दोनों आयत समान दिखाई देने वाले एक्सट्रूज़न और 3D अभिविन्यास को बनाए रखते हैं।

![Side-by-side 3D rectangles: text follows the 3D orientation on the left and stays flat on the right](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint स्वरूपों में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब स्थिर‑लेआउट स्वरूपों में रेंडर या निर्यात किया जाता है, तो 3D सीन को 2D परिणाम के रूप में रास्टराइज़ या ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/java/convert-powerpoint-to-png/), [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), या [वीडियो रूपांतरण](/slides/hi/java/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

ध्यान रखें:

- निर्यातित छवियों और PDFs इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, मैटेरियल, एक्सट्रूज़न, फ़िल, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों की जाँच करनी है, तो [effective shape properties](/slides/hi/java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट स्वरूप संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन स्वरूपों में दृश्य परिणाम रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियों बना सकता है?**

Aspose.Slides आकार और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित छवियों, PDFs, या HTML पृष्ठों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में 3D फ़ॉर्मेटिंग PowerPoint में उसी तरह संपादन योग्य रहती है जहाँ फ़ॉर्मेट इसका समर्थन करता है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट सामान्य PowerPoint आकार या टेक्स्ट पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, प्रकाश, और मैटेरियल। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**दृश्यमान 3D आकार के लिए कौन-कौन सी सेटिंग्स आवश्यक हैं?**

कम से कम कैमरा घूर्णन और एक्सट्रूज़न या डेप्थ सेट करें। व्यवहार में, स्पष्ट हाइलाइट और शैडो के लिए लाइट रिग और मैटेरियल भी सेट करें।

**क्या मैं आकार और टेक्स्ट दोनों पर 3D इफ़ेक्ट लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getThreeDFormat--) और टेक्स्ट के लिए [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) उपयोग करें।

**क्या 3D इफ़ेक्ट्स छवियों, PDF, HTML, या वीडियो फ्रेम में निर्यात करने पर दिखेंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए फ्रेम बनाते समय 3D इफ़ेक्ट्स रेंडर करता है। निर्यातित आउटपुट रेंडर किया हुआ रूप रखता है, संपादन योग्य 3D ऑब्जेक्ट नहीं।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/java/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।