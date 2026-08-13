---
title: Java में प्रस्तुति पृष्ठभूमियों का प्रबंधन
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
description: "Aspose.Slides for Java का उपयोग करके PowerPoint और OpenDocument फ़ाइलों में गतिशील पृष्ठभूमि सेट करना सीखें, साथ ही अपने प्रस्तुतियों को बेहतर बनाने के लिए कोड टिप्स प्राप्त करें।"
---
## **परिचय**

सॉलिड रंग, ग्रेडिएंट, और छवियों का अक्सर स्लाइड पृष्ठभूमि के लिए उपयोग किया जाता है। आप **सामान्य स्लाइड** (एकल स्लाइड) या **मास्टर स्लाइड** (एक साथ कई स्लाइड्स पर लागू) के लिए पृष्ठभूमि सेट कर सकते हैं।

![PowerPoint background](powerpoint-background.png)

## **सामान्य स्लाइड के लिए सॉलिड रंग पृष्ठभूमि सेट करें**

Aspose.Slides आपको प्रस्तुति में एक विशिष्ट स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है—भले ही प्रस्तुति मास्टर स्लाइड का उपयोग कर रही हो। यह परिवर्तन केवल चयनित स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर [getSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करके सॉलिड पृष्ठभूमि रंग निर्दिष्ट करें।
5. बदला गया प्रेजेंटेशन सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि सामान्य स्लाइड के लिए नीला सॉलिड रंग पृष्ठभूमि कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Aspose.Slides आपको प्रस्तुति में मास्टर स्लाइड के लिए पृष्ठभूमि के रूप में सॉलिड रंग सेट करने की अनुमति देता है। मास्टर स्लाइड एक टेम्प्लेट की तरह कार्य करता है जो सभी स्लाइड्स के फ़ॉर्मेट को नियंत्रित करता है, इसलिए जब आप मास्टर स्लाइड की पृष्ठभूमि के लिए सॉलिड रंग चुनते हैं, यह हर स्लाइड पर लागू होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. मास्टर स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) (`getMasters` के माध्यम से) `OwnBackground` पर सेट करें।
3. मास्टर स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Solid` पर सेट करें।
4. सॉलिड पृष्ठभूमि रंग निर्दिष्ट करने के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/#getSolidFillColor--) मेथड का उपयोग करें।
5. बदला गया प्रेजेंटेशन सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि मास्टर स्लाइड के लिए हरे सॉलिड रंग पृष्ठभूमि कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // मास्टर स्लाइड की पृष्ठभूमि का रंग हरा सेट करें।
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

ग्रेडिएंट एक ग्राफिकल प्रभाव है जो रंग के क्रमिक परिवर्तन से बनता है। जब इसे स्लाइड पृष्ठभूमि के रूप में उपयोग किया जाता है, तो ग्रेडिएंट प्रस्तुति को अधिक कलात्मक और पेशेवर बना सकते हैं। Aspose.Slides आपको स्लाइड्स की पृष्ठभूमि के रूप में ग्रेडिएंट रंग सेट करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Gradient` पर सेट करें।
4. [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर [getGradientFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/#getGradientFormat--) मेथड का उपयोग करके अपनी पसंदीदा ग्रेडिएंट सेटिंग्स को कॉन्फ़िगर करें।
5. बदला गया प्रेजेंटेशन सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड के लिए ग्रेडिएंट रंग पृष्ठभूमि कैसे सेट किया जाए:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // पृष्ठभूमि पर ग्रेडिएंट इफ़ेक्ट लागू करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // ग्रेडिएंट रंग जोड़ें। ग्रेडिएंट स्टॉप्स के बिना, पृष्ठभूमि डिफ़ॉल्ट काले‑से‑सफ़ेद रैंप पर वापस आती है।
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि के रूप में छवि सेट करें**

सॉलिड और ग्रेडिएंट फ़िल्स के अतिरिक्त, Aspose.Slides आपको स्लाइड पृष्ठभूमि के रूप में छवियों का उपयोग करने की अनुमति देता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उदाहरण बनाएं।
2. स्लाइड का [BackgroundType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/backgroundtype/) `OwnBackground` पर सेट करें।
3. स्लाइड पृष्ठभूमि का [FillType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/filltype/) `Picture` पर सेट करें।
4. स्लाइड पृष्ठभूमि के रूप में उपयोग करने के लिए छवि लोड करें।
5. छवि को प्रेजेंटेशन की इमेज कलेक्शन में जोड़ें।
6. [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) पर [getPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/#getPictureFillFormat--) मेथड का उपयोग करके छवि को पृष्ठभूमि के रूप में असाइन करें।
7. बदला गया प्रेजेंटेशन सहेजें।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड के लिए पृष्ठभूमि के रूप में छवि कैसे सेट की जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // पृष्ठभूमि छवि गुण सेट करें।
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // छवि लोड करें।
    IImage image = Images.fromFile("Tulips.jpg");
    // छवि को प्रस्तुति की छवि संग्रह में जोड़ें।
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

निम्नलिखित कोड नमूना दिखाता है कि पृष्ठभूमि फ़िल टाइप को टाइल्ड पिक्चर पर कैसे सेट किया जाए और टाइलिंग प्रॉपर्टीज़ को कैसे संशोधित किया जाए:

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

    // बैकग्राउंड फ़िल के लिए उपयोग की गई छवि सेट करें।
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // फ़िल मोड को टाइल पर सेट करें और टाइल गुण समायोजित करें।
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
और अधिक पढ़ें: [**Tile Picture As Texture**](/slides/hi/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **पृष्ठभूमि छवि की पारदर्शिता बदलें**

आप स्लाइड की पृष्ठभूमि छवि की पारदर्शिता को समायोजित करना चाह सकते हैं ताकि स्लाइड की सामग्री उभरकर दिखे। निम्नलिखित Java कोड दर्शाता है कि स्लाइड पृष्ठभूमि छवि की पारदर्शिता कैसे बदली जाए:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // उदाहरण के लिए।

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // चित्र ट्रांसफॉर्म ऑपरेशनों का संग्रह प्राप्त करें।
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // मौजूदा निश्चित-प्रतिशत पारदर्शिता प्रभाव खोजें।
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // नई पारदर्शिता मान सेट करें।
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड पृष्ठभूमि मान प्राप्त करें**

Aspose.Slides एक [IBackgroundEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/) इंटरफ़ेस प्रदान करता है जो स्लाइड के प्रभावी पृष्ठभूमि मानों को प्राप्त करने के लिए है। यह इंटरफ़ेस प्रभावी [FillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) और [EffectFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) को एक्सपोज़ करता है।

[BaseSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/) क्लास की `getBackground` मेथड का उपयोग करके आप स्लाइड के प्रभावी पृष्ठभूमि प्राप्त कर सकते हैं।

निम्नलिखित Java उदाहरण दिखाता है कि स्लाइड का प्रभावी पृष्ठभूमि मान कैसे प्राप्त किया जाए:

```java
import com.aspose.slides.*;

// Presentation क्लास का एक उदाहरण बनाएं।
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

### क्या मैं कस्टम पृष्ठभूमि रीसेट करके थीम/लेआउट पृष्ठभूमि को पुनर्स्थापित कर सकता हूँ?

हां। स्लाइड की कस्टम फ़िल हटाएँ, और पृष्ठभूमि फिर से संबंधित [layout](/slides/hi/java/slide-layout/)/[master](/slides/hi/java/slide-master/) स्लाइड (अर्थात् [theme background](/slides/hi/java/presentation-theme/)) से विरासत में मिल जाएगी।

### यदि मैं बाद में प्रस्तुति का थीम बदलूँ तो पृष्ठभूमि में क्या होता है?

यदि किसी स्लाइड में अपनी खुद की फ़िल है, तो वह अपरिवर्तित रहेगी। यदि पृष्ठभूमि [layout](/slides/hi/java/slide-layout/)/[master](/slides/hi/java/slide-master/) से विरासत में मिली है, तो वह [new theme](/slides/hi/java/presentation-theme/) के अनुसार अपडेट हो जाएगी।