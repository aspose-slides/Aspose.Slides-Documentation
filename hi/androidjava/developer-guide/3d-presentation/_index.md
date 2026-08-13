---
title: Android पर प्रस्तुतियों में 3D इफ़ेक्ट बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/androidjava/3d-presentation/
keywords:
- 3D पावरपॉइंट
- 3D प्रस्तुति
- 3D घुमाव
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- पावरपॉइंट
- प्रस्तुति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर PowerPoint आकारों और पाठ के लिए 3D इफ़ेक्ट लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, फ़िल्स और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **समीक्षा**

Aspose.Slides for Android via Java आकारों और पाठ के लिए PowerPoint‑शैली 3D फ़ॉर्मेटिंग बना सकता है, संपादित कर सकता है, संरक्षित कर सकता है और रेंडर कर सकता है। यह लेख घुमाव, एक्सट्रूज़न, बीवेल, लाइटिंग, सामग्री, ग्रेडिएंट या पिक्चर फ़िल्स, तथा 3D टेक्स्ट जैसे 3D इफ़ेक्ट्स को सम्मिलित करता है।

{{% alert color="info" %}}

यह लेख PowerPoint आकारों और पाठ पर 3D फ़ॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।

{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

शेक को 3D फ़ॉर्मेटिंग लागू करने के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) लौटाता है, जो उस शेक के लिए 3D सीन को नियंत्रित करता है।

पाठ के लिए, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) मेथड का उपयोग करें। यह शेक बॉडी के बजाय टेक्स्ट फ़्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्यों में शामिल हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | दृश्य बिंदु, प्रीसेट कैमरा प्रकार, घुमाव, ज़ूम और परिप्रेक्ष्य। | 3D स्थान में वस्तु को घुमाने या PowerPoint 3D घुमाव प्रीसेट से मिलाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | लाइट प्रीसेट, दिशा और लाइट घुमाव। | 3D सतह पर हाइलाइट और शैडो के दिखने के तरीके को बदलने के लिए। |
| [getMaterial](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) और [setMaterial](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टिक, या मेटल। | समान ज्यामिति को अधिक सपाट, मुलायम, चमकदार या धातु जैसा बनाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) और [setExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | आकार की सामने की सतह से पीछे की ओर कितनी दूरी तक एक्सट्रूड हो रहा है। | एक सपाट आकार को स्पष्ट रूप से मोटे 3D ऑब्जेक्ट में बदलने के लिए। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | एक्सट्रूड की गई किनारों का रंग। | गहराई को दृश्यमान बनाने या किनारा रंग को सामने की फ़िल के साथ समन्वयित करने के लिए। |
| [getDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getDepth--) और [setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या पाठ के लिए गहराई को फ़ाइन‑ट्यून करने के लिए, विशेषकर बीवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) और [getBevelBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | सामने और पीछे की सतहों पर उठे या गोल किनारे। | तेज़ सपाट सतह के बजाय नरम या ढलाई वाले किनारे जोड़ने के लिए। |
| [getContourColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), और [setContourWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट की सीमा को उजागर करने के लिए। |

## **3D आकार बनाना**

एक आकार को विश्वसनीय 3D दिखाने के लिए आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और किनारों को पढ़ने योग्य बनाता है।
- सामग्री सेटिंग्स, क्योंकि सतह का प्रकार प्रकाश के रेंडरिंग को प्रभावित करता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके सामने के फेस पर पाठ जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुति को PPTX के रूप में सहेजता है, और स्लाइड को PNG इमेज में रेंडर करता है।

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

रेंडर की गई स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दिखाती है:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घुमाव को 3‑D Rotation पेन से कॉन्फ़िगर किया जाता है। X, Y और Z घुमाव मान कैमरा API के माध्यम से सेट किए गए घुमाव से मेल खाते हैं।

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides में, कैमरा प्रकार और घुमाव को [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) के माध्यम से सेट करें:

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

जब आपको दर्शक के ऑब्जेक्ट देखने के तरीके को बदलना हो तो कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमैट्री को नहीं बदलता, बल्कि PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न आकार को सामने की सतह के पीछे बढ़ाकर मोटा बनाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को सेट करता है, और रंग नियंत्रण किनारी सतहों का रंग तय करता है।

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

मोटाई के लिए [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) और किनारे के रंग के लिए [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) सेट करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

जब आपको PowerPoint की गहराई मान को सीधे उपयोग करने या गहराई को बीवेल, सामग्री और टेक्स्ट इफ़ेक्ट्स के साथ मिलाना हो, तो [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) का प्रयोग करें। कई आकार स्थितियों में `setExtrusionHeight` अधिक स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्य एक्सट्रूज़न को व्यक्त करता है।

## **3D इफ़ेक्ट्स के साथ ग्रेडिएंट या पिक्चर फ़िल्स का उपयोग करें**

3D फ़ॉर्मेटिंग आकार के फ़िल से स्वतंत्र है। आप सामने के फेस पर सॉलिड रंग, ग्रेडिएंट, पैटर्न या पिक्चर फ़िल लागू कर सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री और एक्सट्रूज़न सेटिंग्स उपयोग कर सकते हैं।

यह उदाहरण आकार पर ग्रेडिएंट फ़िल और किनारों पर गहरा एक्सट्रूज़न रंग लागू करता है:

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
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

रेंडर आउटपुट सामने के फेस पर ग्रेडिएंट को बनाए रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

पिक्चर फ़िल का उपयोग करने के लिए, इमेज को प्रस्तुति में जोड़ें और उसे आकार फ़िल में असाइन करें:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

चित्र सामने के फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **पाठ पर 3D फ़ॉर्मेटिंग लागू करें**

शेप 3D फ़ॉर्मेटिंग शेप बॉडी को प्रभावित करती है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ़्रेम को प्रभावित करती है। यह WordArt‑समान इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग और कैमरा सेटिंग्स चाहिए।

निम्न उदाहरण पैटर्न फ़िल के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

टेक्स्ट को वक्र, एक्सट्रूड 3D लेटरिंग के रूप में रेंडर किया जाता है:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब स्थिर‑लेआउट फ़ॉर्मेट में रेंडर या निर्यात किया जाता है, तो 3D सीन को रास्टराइज़ या 2D परिणाम के रूप में आउटपुट में ड्रा किया जाता है। यह तब लागू होता है जब आप स्लाइड्स को [PNG](/slides/hi/androidjava/convert-powerpoint-to-png/), [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) में रेंडर करते हैं, या [वीडियो कन्वर्ज़न](/slides/hi/androidjava/convert-powerpoint-to-video/) के लिए फ़्रेम जनरेट करते हैं।

ध्यान में रखें:

- निर्यातित इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक वस्तु को घुमा नहीं सकता।
- अंतिम रूप कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, फ़िल और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम‑आधारित फ़ॉर्मेटिंग मानों को जाँचने की आवश्यकता है, तो [effective shape properties](/slides/hi/androidjava/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। ऐसे फ़ॉर्मेट में दृश्य परिणाम रेंडर किया जाता है, न कि संपादन योग्य 3D सेटिंग्स के रूप में।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?

Aspose.Slides आकारों और पाठ के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित इमेज, PDF या HTML पेजों को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

### 3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट सामान्य PowerPoint आकार या टेक्स्ट पर लागू की गई फ़ॉर्मेटिंग है, जैसे घुमाव, एक्सट्रूज़न, बीवेल, लाइटिंग और सामग्री। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

### दृश्य 3D आकार के लिए कौनसे सेटिंग्स आवश्यक हैं?

कम से कम एक कैमरा घुमाव और या तो एक्सट्रूज़न या गहराई सेट करें। व्यवहार में, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर किए गए चेहरे में स्पष्ट हाइलाइट और शैडो दिखें।

### क्या मैं 3D इफ़ेक्ट्स को दोनों आकार और पाठ पर लागू कर सकता हूँ?

हाँ। आकार बॉडी के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) का उपयोग करें और टेक्स्ट के लिए [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) का।

### क्या 3D इफ़ेक्ट्स इमेज, PDF, HTML या वीडियो फ़्रेम में निर्यात करने पर दिखाई देंगे?

हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट और वीडियो कन्वर्ज़न के लिए उपयोग किए जाने वाले फ़्रेम बनाते समय 3D इफ़ेक्ट्स को रेंडर करता है। निर्यातित आउटपुट में रेंडर किया हुआ स्वरूप सम्मिलित होता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

### क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?

हाँ। [Shape Effective Properties](/slides/hi/androidjava/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग करके अंतिम कैमरा, लाइट रिग, बीवेल और संबंधित 3D मान पढ़ें।