---
title: Android पर प्रस्तुतियों में 3D प्रभाव बनाएं
linktitle: 3D प्रस्तुति
type: docs
weight: 232
url: /hi/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D प्रस्तुति
- 3D घूर्णन
- 3D गहराई
- 3D एक्सट्रूज़न
- 3D ग्रेडिएंट
- 3D पाठ
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Android पर Aspose.Slides के साथ PowerPoint आकृतियों और पाठ के लिए 3D प्रभाव लागू करें और रेंडर करें। कैमरा, प्रकाश, सामग्री, एक्सट्रूज़न, भराव, और 3D पाठ को कॉन्फ़िगर करें।"
---
## **परिचय**

Aspose.Slides for Android via Java आकृतियों और पाठ के लिए PowerPoint-शैली 3D फ़ॉर्मेटिंग बना, संपादित, संरक्षित और रेंडर कर सकता है। इस लेख में घूर्णन, एक्सट्रूज़न, बीवेल, प्रकाश, सामग्री, ग्रेडिएंट या चित्र भराव, और 3D पाठ जैसी 3D प्रभावों को कवर किया गया है।

{{% alert color="primary" %}}
यह लेख PowerPoint आकृतियों और पाठ पर 3D फ़ॉर्मेटिंग प्रभावों के बारे में है। यह स्वतंत्र 3D मॉडल फ़ाइलों को सम्मिलित या संपादित करने के बारे में नहीं है। जब आप एक स्लाइड को छवि, PDF, या HTML में निर्यात करते हैं, तो Aspose.Slides उन 3D प्रभावों को निर्यातित 2D आउटपुट में रेंडर करता है।
{{% /alert %}}

## **3D फ़ॉर्मेटिंग अवधारणाएँ**

आकृति पर 3D फ़ॉर्मेटिंग लागू करने के लिए आप [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) मेथड का उपयोग कर सकते हैं। यह मेथड [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) लौटाता है, जो उस आकृति के लिए 3D दृश्य को नियंत्रित करता है।

पाठ के लिए, आप [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) मेथड का उपयोग करें। यह shape बॉडी के बजाय टेक्स्ट फ्रेम पर 3D फ़ॉर्मेटिंग लागू करता है।

सबसे महत्वपूर्ण API सदस्य हैं:

| API सदस्य | यह क्या नियंत्रित करता है | कब उपयोग करें |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | दृष्टिकोण, प्रीसेट कैमरा प्रकार, घूर्णन, ज़ूम, और परिप्रेक्ष्य। | ऑब्जेक्ट को 3D स्पेस में घुमाने या PowerPoint के 3D घूर्णन प्रीसेट से मेल खाने के लिए। |
| [getLightRig](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | प्रकाश प्रीसेट, दिशा, और प्रकाश का घूर्णन। | 3D सतह पर हाइलाइट और छाया कैसे दिखाई दें, इसे बदलें। |
| [getMaterial](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | सतह सामग्री, जैसे सपाट, मैट, प्लास्टिक, या धातु। | एक ही ज्यामिति को अधिक सपाट, मुलायम, चमकदार या धातु जैसा दिखाना। |
| [getExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | आकृति अपनी सामने वाली सतह से कितनी दूरी तक पीछे तक विस्तारित होती है। | एक सपाट आकृति को दृश्य रूप से मोटे 3D ऑब्जेक्ट में बदलना। |
| [getExtrusionColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | एक्सट्रूडेड पक्षों का रंग। | गहराई को दृश्यमान बनाना या साइड रंग को सामने की भराव के साथ समन्वयित करना। |
| [getDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D फ़ॉर्मेटिंग द्वारा उपयोग किया गया अतिरिक्त 3D गहराई। | आकृतियों या पाठ के लिए गहराई को सूक्ष्म रूप से समायोजित करें, विशेष रूप से बीवेल और सामग्री सेटिंग्स के साथ। |
| [getBevelTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | सामने और पीछे के सतहों पर उठे हुए या गोल किनारे। | तीखा सपाट सतह के बजाय मुलायम या मौली किनारा जोड़ें। |
| [getContourColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D ऑब्जेक्ट के चारों ओर रूपरेखा। | रेंडर किए गए आउटपुट में ऑब्जेक्ट सीमा को उजागर करें। |

## **3D आकृति बनाएं**

एक आकृति को विश्वसनीय 3D दिखने से पहले आमतौर पर चार प्रकार की सेटिंग्स की आवश्यकता होती है:

- कैमरा सेटिंग्स, क्योंकि डिफ़ॉल्ट फ्रंट व्यू एक्सट्रूज़न को छिपा सकता है।
- लाइट सेटिंग्स, क्योंकि प्रकाश सतहों और पक्षों को पठनीय बनाता है।
- मटेरियल सेटिंग्स, क्योंकि सतह यह प्रभावित करती है कि प्रकाश कैसे रेंडर होता है।
- एक्सट्रूज़न या गहराई सेटिंग्स, क्योंकि सपाट आकृति को मोटाई की जरूरत होती है।

निम्न उदाहरण एक आयत बनाता है, उसकी सामने वाली सतह पर पाठ जोड़ता है, 3D फ़ॉर्मेटिंग लागू करता है, प्रस्तुतिकरण को PPTX के रूप में सहेजता है, और स्लाइड को PNG छवि में रेंडर करता है।

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

रेंडर किया गया स्लाइड इमेज आयत को एक मोटे 3D ब्लॉक के रूप में दिखाता है:

![सामने की सतह पर सफ़ेद 3D टेक्स्ट के साथ रेंडर किया गया नीला 3D आयत](img_01_01.png)

## **कैमरा से आकृति को घुमाएँ**

PowerPoint में, 3D घूर्णन को 3-D Rotation पैन से कॉन्फ़िगर किया जाता है। X, Y, और Z घूर्णन मान कैमरा API के माध्यम से सेट किए गए घूर्णन के अनुरूप होते हैं।

![PowerPoint 3-D Rotation पैन जिसमें X, Y, और Z घूर्णन मान उजागर किए गए हैं](img_02_01.png)

Aspose.Slides में, आप [IThreeDFormat.getCamera](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getCamera--) के माध्यम से कैमरा प्रकार और घूर्णन सेट करते हैं:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

जब आपको दर्शक के ऑब्जेक्ट को देखे जाने के तरीके को बदलना हो, तब कैमरा का उपयोग करें। यह स्लाइड की 2D आकृति ज्यामिति नहीं बदलता। यह PowerPoint और Aspose.Slides द्वारा रेंडरिंग के समय उपयोग किए जाने वाले 3D दृष्टिकोण को बदलता है।

## **एक्सट्रूज़न और गहराई जोड़ें**

एक्सट्रूज़न एक आकृति को सामने की सतह के पीछे विस्तारित करके मोटा दिखाता है। PowerPoint में, गहराई नियंत्रण इस दृश्यमान मोटाई को सेट करता है, और रंग नियंत्रण साइड सतहों का रंग सेट करता है।

![PowerPoint गहराई नियंत्रण को एक्सट्रूज़न रंग और एक्सट्रूज़न ऊँचाई गुणों से मैप किया गया](img_02_02.png)

मोटाई के लिए [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) सेट करें और साइड रंग के लिए [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) सेट करें:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

जब आपको PowerPoint की गहराई मान के साथ सीधे काम करना हो या गहराई को बीवेल, सामग्री, और टेक्स्ट प्रभावों के साथ संयोजित करना हो, तब आप [IThreeDFormat.setDepth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) का उपयोग करें। कई आकृति परिदृश्यों में, `setExtrusionHeight` स्पष्ट सेटिंग है क्योंकि यह सीधे दृश्यमान एक्सट्रूज़न को दर्शाता है।

## **3D प्रभावों के साथ ग्रेडिएंट या चित्र भराव का उपयोग करें**

3D फ़ॉर्मेटिंग आकृति भराव से स्वतंत्र है। आप सामने की सतह पर ठोस रंग, ग्रेडिएंट, पैटर्न, या चित्र भराव लागू कर सकते हैं और फिर भी समान कैमरा, लाइट, सामग्री, और एक्सट्रूज़न सेटिंग्स का उपयोग कर सकते हैं।

यह उदाहरण आकृति पर ग्रेडिएंट भराव लागू करता है और पक्षों के लिए गहरा एक्सट्रूज़न रंग सेट करता है:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

रेंडर किया गया आउटपुट सामने की सतह पर ग्रेडिएंट को रखता है और एक्सट्रूज़न को अलग से रेंडर करता है:

![नीले से नारंगी ग्रेडिएंट भराव और नारंगी एक्सट्रूज़न वाला रेंडर किया गया 3D आयत](img_02_03.png)

चित्र भराव का उपयोग करने के लिए, प्रस्तुति में चित्र जोड़ें और उसे आकृति भराव को सौंपें:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

चित्र सामने की सतह पर रेंडर होता है, जबकि एक्सट्रूज़न 3D साइड सतह के रूप में रेंडर होता है:

![सामने की सतह पर फोटो भराव और नारंगी एक्सट्रूज़न वाला रेंडर किया गया 3D आयत](img_02_04.png)

## **पाठ पर 3D फ़ॉर्मेटिंग लागू करें**

आकृति 3D फ़ॉर्मेटिंग आकृति बॉडी को प्रभावित करती है। टेक्स्ट 3D फ़ॉर्मेटिंग टेक्स्ट फ्रेम को प्रभावित करती है। यह WordArt जैसे प्रभावों के लिए उपयोगी है जहाँ अक्षरों को स्वयं एक्सट्रूज़न, सामग्री, प्रकाश और कैमरा सेटिंग्स की आवश्यकता होती है।

निम्न उदाहरण पैटर्न भराव के साथ टेक्स्ट बनाता है, WordArt ट्रांसफ़ॉर्म लागू करता है, और [ITextFrameFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/) पर 3D सेटिंग्स कॉन्फ़िगर करता है:

```java
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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

टेक्स्ट को वक्र, एक्सट्रूडेड 3D लेटरिंग के रूप में रेंडर किया जाता है:

![वक्र WordArt ट्रांसफ़ॉर्म, नारंगी पैटर्न भराव, और गहरे एक्सट्रूज़न के साथ रेंडर किया गया 3D टेक्स्ट](img_02_05.png)

## **निर्यात और रेंडरिंग व्यवहार**

जब Aspose.Slides PPTX जैसे PowerPoint फ़ॉर्मेट में सहेजा जाता है, तो यह 3D फ़ॉर्मेटिंग को संरक्षित रखता है। जब रेंडरिंग या निर्यात स्थिर-लेआउट फ़ॉर्मेट्स में किया जाता है, तो 3D दृश्य को रास्टराइज़ किया जाता है या आउटपुट में 2D परिणाम के रूप में ड्रॉ किया जाता है। यह तब लागू होता है जब आप स्लाइड को [PNG](/slides/hi/androidjava/convert-powerpoint-to-png/) में रेंडर करते हैं, [PDF](/slides/hi/androidjava/convert-powerpoint-to-pdf/) में निर्यात करते हैं, [HTML](/slides/hi/androidjava/convert-powerpoint-to-html/) में निर्यात करते हैं, या [video conversion](/slides/hi/androidjava/convert-powerpoint-to-video/) के लिए फ्रेम उत्पन्न करते हैं।

इन बिंदुओं को ध्यान में रखें:

- निर्यात की गई छवियां और PDFs इंटरैक्टिव नहीं होते। निर्यात के बाद दर्शक ऑब्जेक्ट को घुमा नहीं सकता।
- अंतिम दिखावट कैमरा, लाइट रिग, सामग्री, एक्सट्रूज़न, भराव, और स्लाइड स्केलिंग के संयोजन पर निर्भर करती है।
- यदि आपको वंशागत या थीम-आधारित फ़ॉर्मेटिंग मानों की जांच करनी है, तो [प्रभावी आकृति गुण](/slides/hi/androidjava/shape-effective-properties/) पढ़ें।
- कुछ आउटपुट फ़ॉर्मेट्स संपादन योग्य PowerPoint 3D फ़ॉर्मेटिंग को संग्रहीत नहीं कर सकते। उन फ़ॉर्मेट्स में, दृश्य परिणाम को रेंडर किया जाता है न कि संपादन योग्य 3D सेटिंग्स के रूप में संरक्षित किया जाता।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इंटरैक्टिव 3D प्रस्तुतियाँ बना सकता है?**

Aspose.Slides आकृतियों और पाठ के लिए PowerPoint 3D प्रभाव बनाता और रेंडर करता है। यह निर्यात की गई छवियों, PDFs, या HTML पृष्ठों को इंटरैक्टिव 3D दृश्य नहीं बनाता जिसे दर्शक घुमा सके। PPTX में, जहाँ फ़ॉर्मेट समर्थन करता है, 3D फ़ॉर्मेटिंग PowerPoint में संपादन योग्य रहती है।

**3D मॉडल और 3D प्रभाव में क्या अंतर है?**

3D मॉडल एक अलग 3D ऑब्जेक्ट है जिसे प्रस्तुति में सम्मिलित किया जाता है। 3D प्रभाव सामान्य PowerPoint आकृति या पाठ पर लागू फ़ॉर्मेटिंग है, जैसे घूर्णन, एक्सट्रूज़न, बीवेल, प्रकाश और सामग्री। यह लेख 3D प्रभावों को कवर करता है।

**दृश्य 3D आकृति के लिए कौनसी सेटिंग्स आवश्यक हैं?**

न्यूनतम रूप से, कैमरा घूर्णन और या तो एक्सट्रूज़न या गहराई सेट करें। व्यावहारिक तौर पर, लाइट रिग और सामग्री भी सेट करें ताकि रेंडर की गई सतहों पर स्पष्ट हाइलाइट और छाया हों।

**क्या मैं 3D प्रभावों को आकृतियों और पाठ दोनों पर लागू कर सकता हूँ?**

हाँ। आकृति बॉडी के लिए [IShape.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) और पाठ के लिए [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) उपयोग करें।

**क्या 3D प्रभाव छवियों, PDF, HTML, या वीडियो फ्रेम में निर्यात करने पर दिखाई देंगे?**

हाँ। Aspose.Slides स्लाइड छवियों, PDF आउटपुट, HTML आउटपुट, और वीडियो रूपांतरण के लिए उपयोग किए जाने वाले फ्रेम बनाते समय 3D प्रभाव रेंडर करता है। निर्यातित आउटपुट रेंडर किया हुआ स्वरूप रखता है, न कि संपादन योग्य 3D ऑब्जेक्ट।

**क्या मैं वंशानुगत और थीम सेटिंग्स लागू होने के बाद अंतिम 3D मान पढ़ सकता हूँ?**

हाँ। अंतिम कैमरा, लाइट रिग, बीवेल, और संबंधित 3D मान पढ़ने के लिए आप [आकृति प्रभावी गुण](/slides/hi/androidjava/shape-effective-properties/) में वर्णित प्रभावी फ़ॉर्मेटिंग API का उपयोग कर सकते हैं।