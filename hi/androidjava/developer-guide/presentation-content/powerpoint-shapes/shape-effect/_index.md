---
title: Android पर प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/androidjava/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- चमक प्रभाव
- सॉफ्ट एजेस प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें—सेकंडों में प्रभावशाली, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [fills](/slides/hi/androidjava/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप एक आकार पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकार की चमक फैलाने आदि कर सकते हैं।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप किसी आकार पर एक या अधिक प्रभाव लागू कर सकते हैं। 

* कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint में **Preset** विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों के एक ज्ञात अच्छा दिखने वाले संयोजन होते हैं। इस तरह, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectFormat) वर्ग के तहत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की सुविधा देता है।

## **छाया प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे बाहरी छाया प्रभाव ([OuterShadowEffect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) को एक आयत पर लागू किया जाए:

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

यह Java कोड दिखाता है कि कैसे परावर्तन प्रभाव को एक आकार पर लागू किया जाए:

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

## **चमक प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे चमक प्रभाव को एक आकार पर लागू किया जाए:

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

## **सॉफ्ट एजेस प्रभाव लागू करें**

यह Java कोड दिखाता है कि कैसे सॉफ्ट एजेस को एक आकार पर लागू किया जाए:

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हां, आप एक ही आकार पर छाया, परावर्तन और चमक जैसे विभिन्न प्रभावों को मिलाकर अधिक गतिशील उपस्थिति बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न प्रकार के आकारों पर प्रभाव लागू कर सकते हैं, जैसे ऑटोशेप, चार्ट, तालिका, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हां, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।