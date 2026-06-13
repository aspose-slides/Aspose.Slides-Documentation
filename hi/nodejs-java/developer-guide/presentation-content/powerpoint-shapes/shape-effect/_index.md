---
title: JavaScript का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/nodejs-java/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फाइलों को बदलें—सेकंडों में आकर्षक, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग करके आप किसी आकार को प्रमुख बना सकते हैं, लेकिन वे [fills](/slides/hi/nodejs-java/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकार पर विश्वसनीय परावर्तन बना सकते हैं, आकार की चमक प्राप्त कर सकते हैं, आदि।

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।  
* कुछ प्रभाव संयोजन अन्य की तुलना में बेहतर दिखते हैं। इस कारण से, PowerPoint विकल्प **Preset** के अंतर्गत होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों का एक अच्छा दिखने वाला संयोजन होते हैं। इस प्रकार, एक प्रीसेट चुनकर, आपको विभिन्न प्रभावों का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/EffectFormat) वर्ग के तहत गुण और विधियों को प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

यह JavaScript कोड दिखाता है कि कैसे बाहरी छाया प्रभाव ([getOuterShadowEffect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) को आयत पर लागू किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **परावर्तन प्रभाव लागू करें**

यह JavaScript कोड दिखाता है कि कैसे परावर्तन प्रभाव को एक आकार पर लागू किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **चमक प्रभाव लागू करें**

यह JavaScript कोड दिखाता है कि कैसे चमक प्रभाव को एक आकार पर लागू किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **सॉफ्ट एजेज प्रभाव लागू करें**

यह JavaScript कोड दिखाता है कि कैसे सॉफ्ट एजेज को एक आकार पर लागू किया जाए:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हां, आप विभिन्न प्रभावों को, जैसे छाया, परावर्तन, और चमक, एक ही आकार पर संयोजित करके अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt वस्तुएं, OLE वस्तुएं, आदि शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हां, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। यह प्रभाव पूरे समूह पर लागू होगा।