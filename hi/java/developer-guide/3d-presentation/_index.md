---
title: Java का उपयोग करके प्रस्तुतियों में 3D इफ़ेक्ट बनाएं
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
description: "Aspose.Slides के साथ Java में PowerPoint आकारों और टेक्स्ट के लिए 3D इफ़ेक्ट लागू करें और रेंडर करें। कैमरा, लाइटिंग, सामग्री, एक्सट्रूज़न, भराव, और 3D टेक्स्ट को कॉन्फ़िगर करें।"
---
## **सारांश**

Aspose.Slides for Java आकारों और टेक्स्ट के लिए PowerPoint-शैली 3D फॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। यह लेख घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D टेक्स्ट जैसी 3D इफ़ेक्ट्स को कवर करता है।

{{% alert color="info" title="Note" %}}
यह लेख PowerPoint आकारों और टेक्स्ट पर 3D फॉर्मेटिंग इफ़ेक्ट्स के बारे में है। यह स्टैंडअलोन 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप किसी स्लाइड को इमेज, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D इफ़ेक्ट्स को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फॉर्मेटिंग अवधारणाएँ**

एक आकार पर 3D फॉर्मेटिंग लागू करने के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) मेथड का उपयोग करें। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/) लौटाता है, जो उस आकार के लिए 3D सीन को नियंत्रित करता है।

टेक्स्ट के लिए, [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) मेथड का उपयोग करें। यह आकार बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | दृष्टिकोण, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्थान में घुमाएँ या PowerPoint 3D घूर्णन प्रीसेट से मेल करें। |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | लाइट प्रीसेट, दिशा, और लाइट घूर्णन। | 3D सतह पर हाइलाइट और शैडो के दिखने के तरीके को बदलें। |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | सतह सामग्री, जैसे फ्लैट, मैट, प्लास्टर, या धातु। | एक ही ज्यामिति को अधिक समतल, मुलायम, चमकदार, या धातु जैसा दिखाने के लिए। |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | आकार अपने फ्रंट फेस से पीछे की ओर कितनी दूरी तक बढ़ता है। | एक फ्लैट आकार को दृश्यतः मोटे 3D वस्तु में बदलें। |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्यमान बनाएं या साइड रंग को फ्रंट फिल के साथ समन्वयित करें। |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D फॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकार या टेक्स्ट के लिए गहराई को बारीकी से समायोजित करें, विशेष रूप से बिवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | फ्रंट और बैक फेस पर उठे या गोल होते किनारे। | तीक्ष्ण सपाट फेस के बजाय नरम या मोल्ड किए हुए किनारे जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) and [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) and [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D वस्तु के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में वस्तु की सीमा को प्रमुख बनाएं। |

## **एक 3D आकार बनाएं**

एक आकार को विश्वसनीय रूप से 3D दिखने से पहले आम तौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छुपा सकता है।
- लाइट सेटिंग्स, क्योंकि लाइटिंग से फेस और साइड पढ़ने योग्य बनते हैं।
- सामग्री सेटिंग्स, क्योंकि सतह लाइट रेंडरिंग को प्रभावित करती है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि एक फ्लैट आकार को मोटाई चाहिए।

निम्न उदाहरण एक आयत बनाता है, उसके फ्रंट फेस पर टेक्स्ट जोड़ता है, और 3D फॉर्मेटिंग लागू करता है। कैमरा घूर्णन मान डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 100 पॉइंट है। उदाहरण स्लाइड को PNG इमेज में डिफ़ॉल्ट आकार के दो गुना पर रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है।

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

रेंडर की गई स्लाइड इमेज आयत को मोटे 3D ब्लॉक के रूप में दिखाती है:

![फ्रंट फेस पर सफेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा के साथ आकार को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3-D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation पैन जिसमें X, Y, और Z घूर्णन मान हाइलाइट किए गए हैं](img_02_01.png)

Aspose.Slides में, कैमरा तक पहुँचने के लिए [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) का उपयोग करें। यह उदाहरण एक आयत बनाता है, एक ऑर्थोग्राफिक फ्रंट व्यू चुनता है, और इसके X, Y, और Z घूर्णन को क्रमशः 20, 30, और 40 डिग्री पर सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

कभी-कभी आप दर्शक के ऑब्जेक्ट देखने के तरीके को बदलने के लिए कैमरा का उपयोग करें। यह स्लाइड पर 2D आकार ज्योमिक्री को नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृश्य बिंदु को बदलता है।

### **एक टेम्प्लेट आकार से कैमरा अभिविन्यास कॉपी करें**

एक टेम्प्लेट आकार के अभिविन्यास से मेल खाने के लिए, उसके कैमरा प्रीसेट को [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) से पढ़ें और उसके घूर्णन एंगल को [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--) से पढ़ें। उदाहरण `template.pptx` खोलता है और पहले स्लाइड के पहले आकार से कैमरा अभिविन्यास को दूसरे आकार में कॉपी करता है। दोनों आकारों में पहले से ही 3D लाइटिंग है, और दूसरे आकार में स्पष्ट कैमरा घूर्णन नहीं है।

एंगल डिग्री में हैं। इंडेक्स `0` अक्षांश है, इंडेक्स `1` देशांतर है, और इंडेक्स `2` क्रांति है। इन्हें इस क्रम में [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) को पास करें। यदि स्रोत `null` लौटाता है, तो इसका कोई स्पष्ट घूर्णन नहीं है, इसलिए दूसरे आकार के एंगल को न सेट करें। `(0, 0, 0)` का स्पष्ट घूर्णन तीन शून्य लौटाता है और इसे कॉपी किया जाना चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जब आप PowerPoint में `camera-copy.pptx` को फिर से खोलते हैं, तो दाएं ओर का तीर बाएं ओर के आयत के समान कैमरा प्रीसेट और घूर्णन रखता है। दोनों आकार समान लाइटिंग और एक्सट्रूज़न गहराई का उपयोग करते हैं।

![एक नीला 3D आयत और दाहिनी ओर तीर जिसमें मिलते-जुलते कैमरा अभिविन्यास हैं, ऊपर और दाईं ओर से देखा गया](camera-orientation.png)

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकार को मोटा दिखाता है जिससे यह फ्रंट फेस के पीछे तक विस्तारित हो जाता है। PowerPoint में, गहराई नियंत्रण इस दृश्य मोटाई को सेट करता है, और रंग नियंत्रण साइड फेस के रंग को सेट करता है।

![PowerPoint गहराई नियंत्रण जो एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किए गए हैं](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) का उपयोग करके मोटाई सेट करें और [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) से साइड रंग प्राप्त करें। यह उदाहरण आयत को 100 पॉइंट एक्सट्रूज़न के साथ बैंगनी साइड्स देता है और उसकी मोटाई दिखाने के लिए कैमरा घुमाता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे:

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) मेथड 3D आकार की गहराई सेट करता है। [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) मेथड एक्सट्रूज़न इफ़ेक्ट की ऊँचाई नियंत्रित करता है, जैसा कि इस उदाहरण में दिखाया गया है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फॉर्मेटिंग आकार भराव से स्वतंत्र है। आप फ्रंट फेस पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लगा सकते हैं और फिर भी वही कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण फ्रंट फेस पर नीले से नारंगी ग्रेडिएंट लागू करता है और 150 पॉइंट एक्सट्रूज़न पर डार्क ऑरेंज रंग देता है। ग्रेडिएंट 0 और 100 पर रुकते हैं जो ग्रेडिएंट की शुरुआत और अंत को दर्शाते हैं। कैमरा घूर्णन मान डिग्री में हैं। स्लाइड को PNG इमेज में डिफ़ॉल्ट आकार के दो गुना पर रेंडर किया जाता है:

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

रेंडर किया गया आउटपुट फ्रंट फेस पर ग्रेडिएंट रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव के लिए, इमेज को प्रस्तुति में जोड़ें और उसे आकार भराव में असाइन करें। यह उदाहरण कार्य निर्देशिका में "image.jpg" नामक मौजूदा फ़ाइल की आवश्यकता रखता है। यह चित्र को आयत भरने के लिए खींचता है, 150 पॉइंट एक्सट्रूज़न लागू करता है, और कैमरा घूर्णन को डिग्री में सेट करता है। यह आकार को मेमोरी में कॉन्फ़िगर करता है बिना फ़ाइल सहेजे या रेंडर किए:

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

चित्र फ्रंट फेस पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![फ्रंट फेस पर फ़ोटो भराव और नारंगी एक्सट्रूज़न के साथ रेंडर किया गया 3D आयत](img_02_04.png)

## **टेक्स्ट पर 3D फॉर्मेटिंग लागू करें**

आकार 3D फॉर्मेटिंग आकार बॉडी को प्रभावित करती है। टेक्स्ट 3D फॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt जैसी इफ़ेक्ट्स के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, लाइटिंग, और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण नारंगी-और-सेफेद ग्रिड पैटर्न के साथ टेक्स्ट बनाता है, एक ऊपर की ओर आर्च लागू करता है, और [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) के माध्यम से 3D सेटिंग्स कॉन्फ़िगर करता है। एक्सट्रूज़न ऊँचाई और गहराई पॉइंट में हैं, और लाइट घूर्णन डिग्री में है। आकार भराव और रूपरेखा छिपी हुई हैं ताकि केवल टेक्स्ट दिखाई दे। उदाहरण PNG इमेज को डिफ़ॉल्ट स्लाइड आकार के दो गुना पर रेंडर करता है और प्रस्तुति को PPTX के रूप में सहेजता है:

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

टेक्स्ट को वक्र, एक्सट्रूडेड 3D अक्षरों के रूप में रेंडर किया गया है:

![वक्र WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और डार्क एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **3D आकार पर टेक्स्ट को समतल रखें**

एक आकार की 3D उपस्थिति को बनाए रखते हुए टेक्स्ट को पढ़ने योग्य रखने के लिए, [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--) के माध्यम से [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) को कॉल करें। जब मान `true` हो, तो टेक्स्ट 3D सीन से बाहर रहता है। जब यह `false` हो, तो टेक्स्ट सीन में भाग लेता है और उसकी 3D अभिविन्यास का अनुसरण करता है।

यह सेटिंग आकार की 3D फॉर्मेटिंग को हटाती नहीं है: उसका कैमरा, लाइटिंग, सामग्री, और एक्सट्रूज़न [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) के माध्यम से कॉन्फ़िगर रहता है। यह सामान्य घूर्णन से भी अलग है। [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) स्लाइड प्लेन में आकार को घुमाता है, जबकि [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) टेक्स्ट के बाउंडिंग बॉक्स के भीतर कस्टम घूर्णन को नियंत्रित करता है। टेक्स्ट को 3D सीन से बाहर रखने से उन एंगल्स में से किसी को भी रीसेट नहीं किया जाता।

निम्न स्व-समाहित उदाहरण एक नीला आयत टेक्स्ट के साथ बनाता है और उसे मूल के बगल में क्लोन करता है। दोनों आकारों में समान 3D फॉर्मेटिंग है; केवल टेक्स्ट सेटिंग अलग है: बाएं पर `false` और दाएं पर `true`। कैमरा एंगल डिग्री में हैं, और एक्सट्रूज़न ऊँचाई 40 पॉइंट है। उदाहरण प्रस्तुति को PPTX के रूप में सहेजता है और तुलना स्लाइड को PNG में डिफ़ॉल्ट आकार के दो गुना पर रेंडर करता है।

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

बाएं तरफ, टेक्स्ट 3D अभिविन्यास का पालन करता है। दाएं तरफ, यह समतल रहता है और पढ़ने में आसान होता है। दोनों आयत समान दृश्य एक्सट्रूज़न और 3D अभिविन्यास बनाए रखते हैं।

![साइड बाय साइड 3D आयत: बाएं टेक्स्ट 3D अभिविन्यास का पालन करता है और दाएं समतल रहता है](keep_text_flat.png)

## **निर्यात और रेंडरिंग व्यवहार**

Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजते समय 3D फॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात स्थिर‑लेआउट फ़ॉर्मेट में किया जाता है, तो 3D सीन को रास्टर किया जाता है या आउटपुट में 2D परिणाम के रूप में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/java/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/java/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/java/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/java/convert-powerpoint-to-video/) के लिए फ्रेम बनाते हैं।

- निर्यातित इमेज और PDF इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक द्वारा वस्तु को घुमा नहीं सकता।
- अंतिम रूपांतर कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करता है।
- यदि आपको विरासत या थीम-आधारित फॉर्मेटिंग मानों का निरीक्षण करना है, तो पढ़ें [प्रभावी आकार गुण](/slides/hi/java/shape-effective-properties/)।
- कुछ आउटपुट फ़ॉर्मेट संपादन योग्य PowerPoint 3D फॉर्मेटिंग को संग्रहित नहीं कर सकते। इन फ़ॉर्मेट में, दृश्य परिणाम रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित रहता है।

## **FAQ**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियों को बना सकता है?**

Aspose.Slides आकार और टेक्स्ट के लिए PowerPoint 3D इफ़ेक्ट्स बनाता और रेंडर करता है। यह निर्यातित इमेज, PDF, या HTML पेज को इंटरैक्टिव 3D सीन नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, 3D फॉर्मेटिंग PowerPoint में संपादन योग्य रहती है जहाँ फ़ॉर्मेट इसे समर्थन करता है।

**3D मॉडल और 3D इफ़ेक्ट में क्या अंतर है?**

3D मॉडल एक अलग 3D वस्तु है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D इफ़ेक्ट एक नियमित PowerPoint आकार या टेक्स्ट पर लागू फॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बिवेल, लाइटिंग, और सामग्री। यह लेख 3D इफ़ेक्ट्स को कवर करता है।

**एक दृश्य 3D आकार के लिए किन सेटिंग्स की आवश्यकता है?**

न्यूनतम रूप से, कैमरा घूर्णन और एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक रूप से, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर किए गए फेसेस में स्पष्ट हाइलाइट और शैडो हों।

**क्या मैं आकार और टेक्स्ट दोनों पर 3D इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ। आकार बॉडी के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) का उपयोग करें और टेक्स्ट के लिए [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) का उपयोग करें।

**क्या 3D इफ़ेक्ट्स इमेज, PDF, HTML, या वीडियो फ्रेम्स में निर्यात करने पर दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड इमेज, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम बनाते समय 3D इफ़ेक्ट्स रेंडर करता है। निर्यातित आउटपुट रेंडर किया हुआ रूप रखता है, न कि संपादन योग्य 3D वस्तु।

**क्या मैं विरासत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बिवेल, और संबंधित 3D मान पढ़ने के लिए [Shape Effective Properties](/slides/hi/java/shape-effective-properties/) में वर्णित प्रभावी फॉर्मेटिंग API का उपयोग करें।