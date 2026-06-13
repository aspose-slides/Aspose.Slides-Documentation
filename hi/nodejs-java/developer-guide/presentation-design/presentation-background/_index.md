---
title: जावास्क्रिप्ट में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/nodejs-java/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- सॉलिड रंग
- ग्रेडिएंट रंग
- छवि पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, साथ ही अपने प्रस्तुतियों को बेहतर बनाने के लिए कोड टिप्स प्राप्त करें।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और छवियों का अक्सर स्लाइड पृष्ठभूमियों में उपयोग किया जाता है। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक ही बार में कई स्लाइड पर लागू) के लिए पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड का उपयोग किया गया हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/backgroundtype/) `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Solid` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

```js
// Presentation क्लास का एक उदाहरण बनाएँ।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइड के स्वरूप को नियंत्रित करने वाला टेम्पलेट होता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो यह प्रत्येक स्लाइड पर लागू हो जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. मास्टर स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/backgroundtype/) (`getMasters` के माध्यम से) `OwnBackground` सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Solid` सेट करें।
4. [getSolidFillColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

```js
// Presentation क्लास का एक उदाहरण बनाएँ।
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // मास्टर स्लाइड की पृष्ठभूमि का रंग फ़ॉरेस्ट ग्रीन सेट करें।
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

ग्रेडिएंट एक ग्राफिकल प्रभाव है जो रंग के क्रमिक परिवर्तन से बनता है। जब इसे स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बना सकता है। Aspose.Slides आपको स्लाइड के लिए ग्रेडिएंट रंग पृष्ठभूमि सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/backgroundtype/) `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Gradient` सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getGradientFormat) मेथड का उपयोग करके अपनी पसंदीदा ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. संशोधित प्रस्तुति को सहेजें।

```js
// Presentation क्लास का एक उदाहरण बनाएँ।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फिल के अलावा, Aspose.Slides आपको छवियों को स्लाइड पृष्ठभूमियों के रूप में उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/backgroundtype/) `OwnBackground` सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) `Picture` सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने वाली छवि लोड करें।
5. छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) मेथड का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

```js
// Presentation क्लास का एक उदाहरण बनाएँ।
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // पृष्ठभूमि छवि गुण सेट करें।
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // छवि लोड करें।
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // पृष्ठभूमि फिल के लिए उपयोग की गई छवि सेट करें।
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // चित्र फिल मोड को टाइल पर सेट करें और टाइल गुणों को समायोजित करें।
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
और पढ़ें: [**टाइल पिक्चर एज़ टेक्सचर**](/slides/hi/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री स्पष्ट हो। निम्नलिखित जावास्क्रिप्ट कोड दिखाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदलें:

```js
var transparencyValue = 30; // उदाहरण के लिए।

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides `BackgroundEffectiveData` क्लास प्रदान करता है जो स्लाइड की प्रभावी पृष्ठभूमि मानों को प्राप्त करने के लिए उपयोग होती है। यह क्लास प्रभावी [FillFormat] और [EffectFormat] को उजागर करती है।

[BaseSlide] क्लास की `getBackground` मेथड का उपयोग करके, आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

```js
// Presentation क्लास का एक उदाहरण बनाएँ।
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // प्रभावी पृष्ठभूमि प्राप्त करें, जिसमें मास्टर, लेआउट और थीम को ध्यान में रखा गया है।
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम पृष्ठभूमि रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हां। स्लाइड की कस्टम फ़िल को हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/nodejs-java/slide-layout/)/[master](/slides/hi/nodejs-java/slide-master/) स्लाइड से विरासत में मिल जाएगी (अर्थात् [theme background](/slides/hi/nodejs-java/presentation-theme/))।

**यदि मैं बाद में प्रस्तुति की थीम बदलता हूँ तो पृष्ठभूमि पर क्या प्रभाव पड़ेगा?**

यदि किसी स्लाइड का अपना फ़िल है, तो वह अपरिवर्तित रहेगा। यदि पृष्ठभूमि [layout](/slides/hi/nodejs-java/slide-layout/)/[master](/slides/hi/nodejs-java/slide-master/) से विरासत में मिली है, तो यह [new theme](/slides/hi/nodejs-java/presentation-theme/) के साथ मिलाने के लिए अपडेट हो जाएगी।