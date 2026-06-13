---
title: जावा का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके अपने PPT और PPTX फ़ाइलों को उन्नत आकार प्रभावों के साथ बदलें—सेकंड में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, लेकिन ये [fills](/slides/hi/java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकार पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकार पर लागू कर सकते हैं।  

* कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint विकल्प **Preset** के तहत आता है। Preset विकल्प मूलतः दो या अधिक प्रभावों का एक ज्ञात अच्छा संयोजन होते हैं। इस तरह, प्रीसेट चुनकर आपको विभिन्न प्रभावों को आज़माने या संयोजित करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/EffectFormat) वर्ग के तहत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देते हैं।

## **छाया प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे किसी आयत पर बाहरी छाया प्रभाव ([OuterShadowEffect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) लागू किया जाता है:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **परावर्तन प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे किसी आकार पर परावर्तन प्रभाव लागू किया जाता है:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ग्लो प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे किसी आकार पर ग्लो प्रभाव लागू किया जाता है:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **नरम किनारे प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे किसी आकार पर नरम किनारे लागू किए जाते हैं:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर छाया, परावर्तन और ग्लो जैसे विभिन्न प्रभावों को संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोषेप्स, चार्ट, टेबल, चित्र, SmartArt वस्तुएँ, OLE वस्तुएँ और अन्य शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।