---
title: Java का उपयोग करके प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D टेक्स्ट
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java में Aspose.Slides के साथ PowerPoint आकारों और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **परिचय**

Aspose.Slides for Java आकारों और पाठ के लिए PowerPoint‑शैली के 3D फ़ॉर्मेटिंग को बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ जैसे 3D प्रभावों को कवर करता है।

{{% alert color="info" %}}
यह लेख PowerPoint आकारों और पाठ पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह अलग‑अलग 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यात किए गए 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

शेप पर 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/).`getThreeDFormat()` का उपयोग करें। लौटाया गया फ़ॉर्मेट ऑब्जेक्ट उस shape के लिए 3D सीन को नियंत्रित करता है।

पाठ के लिए, [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` का उपयोग करें। यह आकार शरीर के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | जब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getCamera--) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाने या PowerPoint 3D घूर्णन प्रीसेट से मेल खाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getLightRig--) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और शैडो कैसे दिखते हैं, इसे बदलें। |
| [getMaterial](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getMaterial--) और [setMaterial](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | एक ही ज्यामिति को अधिक सपाट, मुलायम, चमकदार, या धातु जैसा दिखाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | आकार अपने सामने वाले चेहरे से पीछे कितनी दूर तक विस्तारित होता है। | फ्लैट आकार को स्पष्ट रूप से मोटे 3D ऑब्जेक्ट में बदलें। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | एक्सट्रूड किए गए किनारों का रंग। | गहराई को दृश्यमान बनाएं या किनारे के रंग को आगे के भराव के साथ समन्वयित करें। |
| [getDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getDepth--) और [setDepth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या पाठ के लिए गहराई को सूक्ष्म रूप से समायोजित करें, विशेषकर बिवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getBevelTop--) और [getBevelBottom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | सामने और पीछे के चेहरों पर उठे या गोल किनारे। | तीखा सपाट चेहरे के बजाय मुलायम या आकारित किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#getContourWidth--), और [setContourWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट सीमा को उजागर करें। |

## **एक 3D आकार बनाएं**

एक आकार को विश्वास योग्य 3D दिखाने से पहले आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश चेहरे और किनारों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह यह निर्धारित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि फ्लैट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके फ्रंट फेस पर टेक्स्ट जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

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

रेंडर किया गया स्लाइड चित्र आयत को एक मोटे 3D ब्लॉक के रूप में दिखाता है:

![फ़्रंट फेस पर सफ़ेद 3D टेक्स्ट के साथ नीला 3D आयत ब्लॉक रेंडर किया गया](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3‑D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान उसी घूर्णन से मेल खाते हैं जिसे आप कैमरा API के माध्यम से सेट करते हैं।

![PowerPoint 3‑D Rotation पैन में X, Y, और Z घूर्णन मान हाइलाइट किए गए](img_02_01.png)

Aspose.Slides में, `shape.getThreeDFormat()` द्वारा वापस किए गए 3D फ़ॉर्मेट के माध्यम से कैमरा प्रकार और घूर्णन सेट करें:

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

जब आपको दर्शक द्वारा वस्तु को देखे जाने के तरीके को बदलने की आवश्यकता हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्यामिति को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकार को सामने वाले चेहरे के पीछे विस्तार देकर मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को निर्धारित करता है, और रंग नियंत्रण किनारे के चेहरों का रंग तय करता है।

![PowerPoint गहराई नियंत्रण को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों के साथ मैप किया गया](img_02_02.png)

मोटाई के लिए एक्सट्रूज़न ऊँचाई और किनारा के रंग के लिए एक्सट्रूज़न रंग सेट करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

जब आपको सीधे PowerPoint की गहराई मान के साथ काम करने या गहराई को बिवेल, सामग्री और पाठ प्रभावों के साथ मिलाने की आवश्यकता हो तो गहराई सेटिंग का उपयोग करें। कई आकार परिदृश्यों में, एक्सट्रूज़न ऊँचाई स्पष्ट सेटिंग होती है क्योंकि यह सीधे दृश्यमान एक्सट्रूज़न को व्यक्त करती है।

## **ग्रेडिएंट या चित्र भराव को 3D प्रभावों के साथ उपयोग करें**

3D फ़ॉर्मेटिंग आकार के भराव से स्वतंत्र होती है। आप फ्रंट फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकार पर ग्रेडिएंट भराव लागू करता है और किनारों के लिए गहरा एक्सट्रूज़न रंग सेट करता है:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

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

रेंडर किया गया आउटपुट फ्रंट फेस पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले‑से‑संतरी ग्रेडिएंट भराव और संतरी एक्सट्रूज़न के साथ 3D आयत रेंडर किया गया](img_02_03.png)

चित्र भराव उपयोग करने के लिए, चित्र को प्रस्तुति में जोड़ें और उसे आकार भराव के रूप में असाइन करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
    byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![फ़्रंट फेस पर फोटो भराव और संतरी एक्सट्रूज़न के साथ 3D आयत रेंडर किया गया](img_02_04.png)

## **पाठ पर 3D फ़ॉर्मेटिंग लागू करें**

आकार की 3D फ़ॉर्मेटिंग आकार शरीर को प्रभावित करती है। पाठ की 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt‑समान प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ पाठ बनाता है, WordArt रूपांतरण लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` पर 3D सेटिंग्स कॉन्फ़िगर करता है:

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

पाठ को वक्र, एक्सट्रूडेड 3D अक्षर के रूप में रेंडर किया गया है:

![वक्र WordArt रूपांतरण, संतरी पैटर्न भराव, और गहरा एक्सट्रूज़न के साथ 3D पाठ रेंडर किया गया](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मैट में सहेजते समय 3D फ़ॉर्मेटिंग को संरक्षित करता है। जब स्थिर‑लेआउट फ़ॉर्मैट में रेंडर या निर्यात किया जाता है, तो 3D सीन को रास्टराइज़ किया जाता है या 2D परिणाम के रूप में आउटपुट में खींचा जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/java/convert-powerpoint-to-png/), [PDF](/slides/hi/java/convert-powerpoint-to-pdf/), [HTML](/slides/hi/java/convert-powerpoint-to-html/), या [वीडियो रूपांतरण](/slides/hi/java/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बातों को ध्यान में रखें:

- निर्यात किए गए चित्र और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को नहीं घुमा सकता।
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मूल्यों का निरीक्षण करना हो, तो [प्रभावी आकार गुण](/slides/hi/java/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मैट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग संग्रहीत नहीं कर सकते। उन फ़ॉर्मैट में, दृश्य परिणाम को संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित रखने के बजाय रेंडर किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियों बना सकता है?

Aspose.Slides आकारों और पाठ के लिए PowerPoint 3D प्रभावों को बनाता और रेंडर करता है। यह निर्यात किए गए चित्र, PDF, या HTML पृष्ठों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

### 3D मॉडल और 3D प्रभाव में क्या अंतर है?

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint आकार या पाठ पर लागू किया गया फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

### दृश्यमान 3D आकार के लिए किन सेटिंग्स की आवश्यकता है?

न्यूनतम रूप से कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, स्पष्ट हाइलाइट और छाया के लिए लाइट रिग और सामग्री भी सेट करें।

### क्या मैं आकार और पाठ दोनों पर 3D प्रभाव लागू कर सकता हूँ?

हाँ। आकार शरीर के लिए [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/).`getThreeDFormat()` और पाठ के लिए [ITextFrameFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` उपयोग करें।

### क्या 3D प्रभाव चित्रों, PDF, HTML, या वीडियो फ़्रेम में निर्यात करने पर दिखेंगे?

हाँ। Aspose.Slides स्लाइड चित्र, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के फ़्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यात किया गया आउटपुट रेंडर किया हुआ दृश्य रखता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

### क्या मैं विरासत और थीम सेटिंग्स के लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [प्रभावी आकार गुण](/slides/hi/java/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करें।