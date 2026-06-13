---
title: Android पर प्रस्तुति पृष्ठभूमियाँ प्रबंधित करें
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/androidjava/presentation-background/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument फ़ाइलों में Aspose.Slides for Android का उपयोग करके जावा के माध्यम से डायनेमिक पृष्ठभूमि सेट करना सीखें, कोड टिप्स के साथ अपनी प्रस्तुतियों को बेहतर बनाएं।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और छवियां आमतौर पर स्लाइड पृष्ठभूमि के लिए उपयोग किए जाते हैं। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइडों पर लागू) की पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint background](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड का उपयोग हो। परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation class की एक instance बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की पृष्ठभूमि रंग को नीला सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मास्टर स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड एक टेम्पलेट के रूप में कार्य करता है जो सभी स्लाइडों के फ़ॉर्मेट को नियंत्रित करता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो वह प्रत्येक स्लाइड पर लागू हो जाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. मास्टर स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) (`getMasters` के माध्यम से) `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. [getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation class की एक instance बनाएं।
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Master slide की पृष्ठभूमि रंग को फॉरेस्ट ग्रीन सेट करें।
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड के लिए ग्रेडिएंट पृष्ठभूमि सेट करें**

एक ग्रेडिएंट वह ग्राफ़िकल इफ़ेक्ट है जो रंग में क्रमिक परिवर्तन द्वारा बनता है। जब स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बनाते हैं। Aspose.Slides आपको स्लाइडों के लिए ग्रेडिएंट रंग को पृष्ठभूमि के रूप में सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) `Gradient` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) मेथड का उपयोग करके अपनी पसंदीदा ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation class की एक instance बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फ़िल्स के अलावा, Aspose.Slides आपको छवियों को स्लाइड पृष्ठभूमि के रूप में उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) `Picture` पर सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने के लिए छवि को लोड करें।
5. छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) मेथड का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

```java
// Presentation class की एक instance बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पृष्ठभूमि छवि गुण सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // छवि लोड करें।
    IImage image = Images.fromFile("Tulips.jpg");
    // छवि को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // पृष्ठभूमि भराव के लिए उपयोग की जाने वाली छवि सेट करें।
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // चित्र भराव मोड को टाइल सेट करें और टाइल गुण समायोजित करें।
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
अधिक पढ़ें: [**Tile Picture As Texture**](/slides/hi/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री उभरे। निम्नलिखित Java कोड दिखाता है कि कैसे स्लाइड पृष्ठभूमि छवि की पारदर्शिता बदलें:

```java
int transparencyValue = 30; // उदाहरण के लिए।

// चित्र ट्रांसफ़ॉर्म ऑपरेशनों का संग्रह प्राप्त करें।
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// मौज़ूदा स्थिर-प्रतिशत पारदर्शिता प्रभाव खोजें।
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// नया पारदर्शिता मान सेट करें।
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides स्लाइड की प्रभावी पृष्ठभूमि मान प्राप्त करने के लिए [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) और [EffectFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/) क्लास की `getBackground` मेथड का उपयोग करके, आप स्लाइड के लिए प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

```java
// Presentation class की एक instance बनाएं।
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // मास्टर, लेआउट और थीम को ध्यान में रखते हुए प्रभावी पृष्ठभूमि प्राप्त करें।
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम पृष्ठभूमि को रीसेट कर सकता हूँ और थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?**

हां। स्लाइड की कस्टम फ़िल हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/androidjava/slide-layout/)/[master](/slides/hi/androidjava/slide-master/) स्लाइड (अर्थात [theme background](/slides/hi/androidjava/presentation-theme/)) से विरासत में मिल जाएगी।

**अगर मैं बाद में प्रस्तुति की थीम बदलूँ तो पृष्ठभूमि पर क्या असर पड़ेगा?**

यदि स्लाइड में अपनी स्वयं की फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/androidjava/slide-layout/)/[master](/slides/hi/androidjava/slide-master/) से विरासत में मिली है, तो वह [new theme](/slides/hi/androidjava/presentation-theme/) से मेल खाने के लिए अपडेट हो जाएगी।