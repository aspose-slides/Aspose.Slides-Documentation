---
title: Android पर प्रस्तुति पृष्ठभूमियों का प्रबंधन
linktitle: स्लाइड पृष्ठभूमि
type: docs
weight: 20
url: /hi/androidjava/presentation-background/
keywords:
- प्रस्तुति पृष्ठभूमि
- स्लाइड पृष्ठभूमि
- सॉलिड रंग
- ग्रेडिएंट रंग
- चित्र पृष्ठभूमि
- पृष्ठभूमि पारदर्शिता
- पृष्ठभूमि गुण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android को Java के माध्यम से उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, साथ ही अपने प्रस्तुतीकरण को बेहतर बनाने के कोड टिप्स।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट और चित्र अक्सर स्लाइड पृष्ठभूमि के लिए उपयोग किए जाते हैं। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइडों पर लागू) की पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint पृष्ठभूमि](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में किसी विशिष्ट स्लाइड की पृष्ठभूमि को सॉलिड रंग में सेट करने की अनुमति देता है—भले ही प्रस्तुति में मास्टर स्लाइड उपयोग में हो। परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि सामान्य स्लाइड की पृष्ठभूमि को नीला सॉलिड रंग कैसे सेट करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक इंस्टेंस बनाएं।
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

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड की पृष्ठभूमि को सॉलिड रंग में सेट करने की अनुमति देता है। मास्टर स्लाइड एक टेम्पलेट की तरह कार्य करती है जो सभी स्लाइडों के फ़ॉर्मेट को नियंत्रित करती है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, तो वह हर स्लाइड पर लागू हो जाता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. `getMasters` के माध्यम से मास्टर स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Solid` पर सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्दिष्ट करने के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि मास्टर स्लाइड की पृष्ठभूमि को हरा सॉलिड रंग कैसे सेट करें:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // मास्टर स्लाइड की पृष्ठभूमि रंग को हरा सेट करें।
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

ग्रेडिएंट एक ग्राफ़िकल प्रभाव है जो रंग के क्रमिक परिवर्तन से बनता है। जब इसे स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुतियों को अधिक कलात्मक और पेशेवर बनाते हैं। Aspose.Slides आपको स्लाइड की पृष्ठभूमि को ग्रेडिएंट रंग में सेट करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Gradient` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) मेथड का उपयोग करके पसंदीदा ग्रेडिएंट सेटिंग्स कॉन्फ़िगर करें।
5. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि को ग्रेडिएंट रंग कैसे सेट किया जाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // पृष्ठभूमि पर ग्रेडिएंट प्रभाव लागू करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // ग्रेडिएंट रंग जोड़ें। ग्रेडिएंट स्टॉप्स न होने पर, पृष्ठभूमि डिफ़ॉल्ट काली‑से‑सफ़ेद रैंप पर वापस आती है।
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि के रूप में चित्र सेट करें**

सॉलिड और ग्रेडिएंट फ़िल्स के अलावा, Aspose.Slides आपको स्लाइड पृष्ठभूमि के रूप में चित्रों का उपयोग करने की अनुमति देता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. स्लाइड की [BackgroundType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/backgroundtype/) को `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि की [FillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/filltype/) को `Picture` पर सेट करें।
4. वह चित्र लोड करें जिसे आप स्लाइड पृष्ठभूमि के रूप में उपयोग करना चाहते हैं।
5. चित्र को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) मेथड का उपयोग करके चित्र को पृष्ठभूमि के रूप में असाइन करें।
7. संशोधित प्रस्तुति को सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड की पृष्ठभूमि को चित्र कैसे सेट किया जाता है:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक इंस्टेंस बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पृष्ठभूमि चित्र की विशेषताएँ सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // चित्र लोड करें।
    IImage image = Images.fromFile("Tulips.jpg");
    // चित्र को प्रस्तुति की इमेज कलेक्शन में जोड़ें।
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्नलिखित कोड सैंपल दिखाता है कि पृष्ठभूमि फ़िल टाइप को टाइल्ड चित्र पर कैसे सेट किया जाए और टाइलिंग गुणों को संशोधित किया जाए:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // पृष्ठभूमि फ़िल के लिए उपयोग की जाने वाली छवि सेट करें।
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // चित्र फ़िल मोड को टाइल सेट करें और टाइल गुण समायोजित करें।
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

{{% alert color="info" %}}

और पढ़ें: [**टाइल चित्र को टेक्सचर के रूप में**](/slides/hi/androidjava/shape-formatting/#tile-picture-as-texture)।

{{% /alert %}}

### **पृष्ठभूमि चित्र की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि चित्र की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री अधिक स्पष्ट दिखे। निम्नलिखित Java कोड दर्शाता है कि स्लाइड पृष्ठभूमि चित्र की पारदर्शिता को कैसे बदलें:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // उदाहरण के लिए।

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // चित्र ट्रांसफ़ॉर्म संचालन का संग्रह प्राप्त करें।
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // मौजूदा नियत-प्रतिशत पारदर्शिता प्रभाव खोजें।
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

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides स्लाइड के प्रभावी पृष्ठभूमि मानों को प्राप्त करने के लिए [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) और [EffectFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) को उजागर करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/) क्लास के `getBackground` मेथड का उपयोग करके आप स्लाइड की प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड की प्रभावी पृष्ठभूमि मान कैसे प्राप्त करें:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक इंस्टेंस बनाएं।
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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं कस्टम पृष्ठभूमि को रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?

हाँ। स्लाइड की कस्टम फ़िल हटाएँ, और पृष्ठभूमि स्वचालित रूप से संबंधित [layout](/slides/hi/androidjava/slide-layout/)/[master](/slides/hi/androidjava/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/androidjava/presentation-theme/)) से फिर से विरासत में मिल जाएगी।

### यदि मैं बाद में प्रस्तुति की थीम बदलूँ तो पृष्ठभूमि पर क्या असर पड़ेगा?

यदि स्लाइड की अपनी फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/androidjava/slide-layout/)/[master](/slides/hi/androidjava/slide-master/) से विरासत में मिली है, तो वह नई थीम के अनुसार अपडेट हो जाएगी।