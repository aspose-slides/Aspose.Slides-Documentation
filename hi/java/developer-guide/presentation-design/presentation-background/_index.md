---
title: जावा में प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/java/presentation-background/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमियां सेट करना सीखें, साथ ही अपने प्रस्तुतियों को बेहतर बनाने के लिए कोड टिप्स प्राप्त करें।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और छवियों का सामान्यतः स्लाइड पृष्ठभूमि के लिए उपयोग किया जाता है। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइड्स पर लागू) की पृष्ठभूमि सेट कर सकते हैं।

![पावरपॉइंट पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड की पृष्ठभूमि को सॉलिड रंग से सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड का उपयोग हो रहा हो। परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड बैकग्राउंड का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर `getSolidFillColor` मेथड का उपयोग करके सॉलिड बैकग्राउंड रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित जावा उदाहरण दर्शाता है कि सामान्य स्लाइड की पृष्ठभूमि के लिए नीला सॉलिड रंग कैसे सेट करें:

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // स्लाइड की पृष्ठभूमि का रंग नीला सेट करें।
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

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि को सॉलिड रंग से सेट करने की अनुमति देता है। मास्टर स्लाइड सभी स्लाइड्स की फ़ॉर्मेटिंग को नियंत्रित करने वाला टेम्प्लेट होता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो वह हर स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. मास्टर स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) (via `getMasters`) को `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड बैकग्राउंड का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. सॉलिड बैकग्राउंड रंग निर्दिष्ट करने के लिए `getSolidFillColor` मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित जावा उदाहरण दर्शाता है कि मास्टर स्लाइड की पृष्ठभूमि के लिए हरा सॉलिड रंग कैसे सेट करें:

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // मास्टर स्लाइड की पृष्ठभूमि का रंग फ़ॉरेस्ट ग्रीन सेट करें।
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

ग्रेडिएंट एक ग्राफिकल प्रभाव है जो रंग में धीरे-धीरे परिवर्तन द्वारा बनाया जाता है। स्लाइड पृष्ठभूमि के रूप में उपयोग करने पर ग्रेडिएंट प्रस्तुतियों को अधिक कलात्मक और पेशेवर बनाते हैं। Aspose.Slides आपको स्लाइड्स की पृष्ठभूमि को ग्रेडिएंट रंग से सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड बैकग्राउंड का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Gradient` पर सेट करें।
4. अपनी वांछित ग्रेडिएंट सेटिंग्स को कॉन्फ़िगर करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर `getGradientFormat` मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित जावा उदाहरण दर्शाता है कि स्लाइड की पृष्ठभूमि के लिए ग्रेडिएंट रंग कैसे सेट करें:

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // बैकग्राउंड पर ग्रेडिएंट इफ़ेक्ट लागू करें।
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

सॉलिड और ग्रेडिएंट भराव के अलावा, Aspose.Slides आपको स्लाइड पृष्ठभूमि के रूप में छवियों का उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड के [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड बैकग्राउंड का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Picture` पर सेट करें।
4. स्लाइड बैकग्राउंड के रूप में उपयोग करने के लिए छवि लोड करें।
5. छवि को प्रस्तुति के इमेज कलेक्शन में जोड़ें।
6. छवि को बैकग्राउंड के रूप में असाइन करने के लिए [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर `getPictureFillFormat` मेथड का उपयोग करें।
7. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित जावा उदाहरण दर्शाता है कि स्लाइड की पृष्ठभूमि के लिए छवि कैसे सेट करें:

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // बैकग्राउंड इमेज गुण सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // छवि लोड करें।
    IImage image = Images.fromFile("Tulips.jpg");
    // इमेज को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्नलिखित कोड नमूना दर्शाता है कि बैकग्राउंड फ़िल टाइप को टाइल्ड चित्र पर कैसे सेट करें और टाइलिंग प्रॉपर्टीज़ को कैसे संशोधित करें:

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

    // बैकग्राउंड भराव के लिए उपयोग की गई छवि सेट करें।
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
और पढ़ें: [**टाइल चित्र को बनावट के रूप में**](/slides/hi/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **बैकग्राउंड इमेज की ट्रांसपेरेंसी बदलें**

आप स्लाइड की बैकग्राउंड इमेज की ट्रांसपेरेंसी को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक उभर कर सामने आए। निम्नलिखित जावा कोड दिखाता है कि स्लाइड बैकग्राउंड इमेज की ट्रांसपेरेंसी कैसे बदलें:

```java
int transparencyValue = 30; // उदाहरण के लिए।

// चित्र ट्रांसफ़ॉर्म ऑपरेशन का संग्रह प्राप्त करें।
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// मौजूदा निश्चित प्रतिशत पारदर्शिता प्रभाव खोजें।
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

## **स्लाइड बैकग्राउंड मूल्य प्राप्त करें**

Aspose.Slides एक स्लाइड के प्रभावी बैकग्राउंड मान प्राप्त करने के लिए [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) और [EffectFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/) क्लास के `getBackground` मेथड का उपयोग करके आप स्लाइड के प्रभावी बैकग्राउंड को प्राप्त कर सकते हैं।

निम्नलिखित जावा उदाहरण दर्शाता है कि स्लाइड के प्रभावी बैकग्राउंड मूल्य को कैसे प्राप्त करें:

```java
// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // प्रभावी बैकग्राउंड प्राप्त करें, जिसमें मास्टर, लेआउट और थीम को ध्यान में रखा गया है।
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कस्टम बैकग्राउंड रीसेट कर सकता हूँ और थीम/लेआउट बैकग्राउंड को पुनर्स्थापित कर सकता हूँ?**  
हाँ। स्लाइड की कस्टम फ़िल को हटाएँ, और बैकग्राउंड फिर से संबंधित [layout](/slides/hi/java/slide-layout/)/[master](/slides/hi/java/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/java/presentation-theme/)) से विरासत में मिल जाएगा।

**यदि मैं बाद में प्रस्तुति का थीम बदलता हूँ तो बैकग्राउंड में क्या होता है?**  
यदि किसी स्लाइड का अपना फ़िल है, तो वह अपरिवर्तित रहेगा। यदि बैकग्राउंड [layout](/slides/hi/java/slide-layout/)/[master](/slides/hi/java/slide-master/) से विरासत में मिला है, तो वह नए थीम से मेल खाने के लिए अपडेट हो जाएगा।