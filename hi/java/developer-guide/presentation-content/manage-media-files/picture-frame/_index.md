---
title: जावा का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम को प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रास्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएँ
- छवि संपीड़ित करें
- StretchOffset
- पिक्चर फ्रेम फॉर्मेटिंग
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुतियों में पिक्चर फ्रेम को बनाएं, फॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **अवलोकन**

एक picture frame वह स्लाइड आकार है जो एक छवि प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) अपने [IImageCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का स्वामित्व रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) छवि की स्थिति, आकार, रेखा स्वरूपण, घुमाव, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ़्रेम‑स्तरीय सेटिंग्स को नियंत्रित करता है।

यह अलगाव तब उपयोगी होता है जब एक ही छवि को एक से अधिक बार दिखाया जाता है। छवि को प्रस्तुति में केवल एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) को रखें, और पिक्चर फ्रेम बनाते समय उस छवि संसाधन का उपयोग करें।

पिक्चर फ़्रेम रास्टर छवियों जैसे PNG या JPEG और वेक्टर SVG छवियों को रख सकते हैं। वे लिंक्ड छवियों की ओर भी इशारा कर सकते हैं बजाय इसके कि छवि बाइट्स को प्रस्तुति में संग्रहीत किया जाए। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एम्बेडेड छवि को जोड़ें और स्वरूपित करें**

एम्बेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) का उपयोग करके एक पिक्चर फ्रेम बनाएँ। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर वह स्व-निहित रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ़्रेम बनाता है, और रेखा स्वरूपण एवं घुमाव लागू करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पिक्चर फ़्रेम प्रदर्शित ज्यामिति को नियंत्रित करता है; फ़्रेम का आकार बदलने से एम्बेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या संपीड़ित करते समय महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) फ़्रेम के लिए सापेक्ष चौड़ाई और ऊँचाई स्केलिंग को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) द्वारा उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के बराबर होता है। सापेक्ष स्केल तब उपयोगी होता है जब कार्यप्रवाह को स्रोत छवि आकार के संबंध को बनाए रखना हो, न कि मैन्युअली अंतिम आयामों की गणना करनी पड़े।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सापेक्ष स्केल फ़्रेम के स्केल सेटिंग्स को बदलता है; यह एम्बेडेड छवि को पुन: नमूना नहीं करता न ही संपीड़ित करता।

## **एम्बेडेड और लिंक्ड छवियाँ**

एम्बेडेड पिक्चर छवि डेटा को प्रस्तुति के अंदर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। लिंक्ड पिक्चर [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के माध्यम से बाहरी स्थान को संग्रहीत करता है, बजाय इसके कि छवि डेटा को उसी तरीके से एम्बेड किया जाए।

लिंक्ड छवियाँ PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे एक बाहरी निर्भरता पेश करती हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन द्वारा सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं रहता, तो लिंक्ड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जिन्हें ई‑मेल करना, आर्काइव करना या अलग‑थलग पर्यावरण में रेंडर करना आवश्यक है, एम्बेडेड छवियाँ आमतौर पर अधिक भरोसेमंद होती हैं।

### **लिंक्ड छवि जोड़ें**

निम्न उदाहरण एक पिक्चर फ्रेम बनाता है और उसे स्थानीय छवि फ़ाइल की ओर इंगित करता है। यह केवल छवि लिंकिंग से निपटता है; वीडियो लिंकिंग एक अलग मीडिया कार्यप्रवाह है और जानबूझकर इस उदाहरण में शामिल नहीं किया गया है।

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

बाहरी फ़ाइल प्रबंधन का इरादा हो तो लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटे हुए छवि निर्भरताओं वाली छोटी PPTX अक्सर बड़ी स्व‑निहित प्रस्तुति से कम उपयोगी होती है।

## **पिक्चर फ़्रेम से छवियों का निष्कर्षण**

किसी मौजूदा प्रस्तुति से छवि निकालने से पहले यह जांचें कि आकार वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) है और उसमें एम्बेडेड छवि है। लिंक्ड पिक्चर फ़्रेम में ऐसे बाइट्स नहीं हो सकते जिन्हें उसी तरह निकाला जा सके।

### **रास्टर छवि निकालें**

आधुनिक छवि API सीधे [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) का उपयोग करता है और पुराने जावा इमेज रैपर की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड रास्टर चित्र खोजता है और उसे PNG के रूप में सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) द्वारा सहेजना निकाली गई छवि को अनुरोधित आउटपुट फ़ॉर्मेट में बदल देता है। यदि आप प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो परिवर्तित रास्टर फ़ाइल के बजाय छवि संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG छवि निकालें**

SVG पिक्चर के लिए, [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) वस्तु उजागर करता है। यह आपको SVG डेटा को सीधे पुनः प्राप्त करने की अनुमति देता है, पहले चित्र को रैस्टराइज़ किए बिना।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG सामग्री को SVG के रूप में रखने से वेक्टर स्रोत प्रस्तुति में बना रहता है। PNG या JPEG जैसी रास्टर निर्यात आवश्यक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करती हैं। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट प्रतिलिपि नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन आवश्यक हो तो एम्बेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग फ़्रेम के भीतर छवि के कौन से भाग दिखाए जाएँगे, इसे बदलती है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारंभिक रूप से एम्बेडेड छवि से छिपे पिक्सेल को नहीं हटाती; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण एक पिक्चर फ्रेम को सुरक्षित रूप से खोजता है और क्रॉप मान लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

चूंकि छिपा हुआ छवि डेटा अभी भी मौजूद है, इसलिए क्रॉप को बाद में बदला जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनरावृत्ति की आवश्यकता नहीं है, तो अगले अनुभाग में वर्णित अनुसार क्रॉप किए गए क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए गए छवि डेटा को हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप आयत के बाहर के छवि डेटा को हटा देता है और परिणामस्वरूप नया छवि संसाधन लौटाता है। यह फ़ाइल आकार को कम कर सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति को सहेजने के बाद हटाए गए पिक्सेल बाद में अन‑क्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

यह मेथड प्रस्तुति में एक नया छवि संसाधन जोड़ सकता है। यदि मूल छवि अन्य पिक्चर फ्रेम द्वारा भी उपयोग की जा रही है, तो उन फ़्रेमों को अभी भी अपने मौजूदा संसाधन की आवश्यकता होगी, इसलिए क्रॉप्ड क्षेत्रों को हटाना जरूरी नहीं कि कुल छवियों की संख्या घटाए। इस मेथड से WMF या EMF सामग्री को क्रॉप करने से परिणाम PNG में रैस्टराइज़ हो जाता है।

## **रास्टर छवियों को संपीड़ित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) रास्टर छवि का रिज़ॉल्यूशन उस आकार के सापेक्ष घटाता है जिस पर चित्र प्रदर्शित होता है। यह एक ही ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब छवि को आकार बदल दिया गया या क्रॉप किया गया, और `false` जब कोई परिवर्तन आवश्यक नहीं था।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो पूर्वपरिभाषित [PicturesCompression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturescompression/) मान का उपयोग करें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

जब विशिष्ट लक्ष्य आवश्यक हो, तो पूर्वपरिभाषित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

यह संपीड़न रास्टर छवियों के लिए अभिप्रेत है। SVG और मेटाफाइल सामग्री इस रास्टर संपीड़न कार्यप्रवाह से नहीं घटेंगी। साथ ही याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर छवि वास्तव में देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करके।

## **छवि इफ़ेक्ट्स की जांच करें**

चित्र इफ़ेक्ट्स फ्रेम द्वारा उपयोग किए गए चित्र पर संग्रहीत होते हैं। छवि ट्रांसफ़ॉर्म संग्रह में पारदर्शिता के लिए स्थिर अल्फा मॉड्यूलेशन और चमक‑विरोध के लिए ल्यूमिनांस जैसे इफ़ेक्ट्स हो सकते हैं। नीचे दिया गया उदाहरण स्लाइड पर पहले पिक्चर फ़्रेम से दोनों प्रकार के इफ़ेक्ट्स को सुरक्षित रूप से पढ़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ये इफ़ेक्ट्स फ़्रेम में छवि के रेंडरिंग को बदलते हैं; वे मूल एम्बेडेड छवि बाइट्स को पुनः लिखते नहीं हैं।

## **पिक्चर फ़्रेम ज्यामिति को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/) सेटिंग्स पिक्चर फ़्रेम के लिए किन संपादन ऑपरेशनों को अक्षम किया गया है, इसे नियंत्रित करती हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय आकार अनुपात को संरक्षित रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत छवि को पुन: नमूना नहीं करता या स्थायी रूप से उसी अनुपात में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर स्ट्रेच‑ऑफ़सेट मान पिक्चर फ्रेम की सीमाओं के सापेक्ष भराव आयत परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से अंदर की ओर इन्सेट बनाते हैं, जबकि नकारात्मक प्रतिशत आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के कौन से भाग दिखाई देंगे, इसे चुनते हैं; स्ट्रेच‑ऑफ़सेट दृश्यमान चित्र भराव को किस आयत में स्ट्रेच किया जाए, उसे बदलते हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

फ़िल प्लेसमेंट के लिए स्ट्रेच‑ऑफ़सेट का उपयोग करें। जब लक्षित स्रोत‑छवि किनारों को छुपाना हो, तो क्रॉप गुणों का उपयोग करें।

## **भंडारण, फ़ाइल आकार, और निर्यात विचार**

छवि भंडारण और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग संभालने पर मुख्य ट्रेड‑ऑफ़ अधिक स्पष्ट हो जाते हैं:

- **एम्बेडेड छवियाँ** प्रस्तुति को स्व‑निहित बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होती हैं, लेकिन बड़े रास्टर छवियों से PPTX आकार और मेमोरी उपयोग बढ़ता है।
- **लिंक्ड छवियाँ** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर करती हैं।
- **क्रॉपिंग** शुरू में विनाशरहित होती है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया या संपीड़न के दौरान नहीं हटाया जाता।
- **संपीड़न** बड़े रास्टर चित्रों के फ़ाइल आकार को काफी घटा सकता है, पर स्रोत रिज़ॉल्यूशन का बलिदान देता है। इसे स्लाइड पर अपेक्षित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG छवियाँ** वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में रखी जानी चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदल देता है।
- **बार‑बार उपयोग की गई छवियाँ** संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) संसाधन को पुनः उपयोग करें, बजाय बार‑बार वही फ़ाइल लोड करने के।

बड़ी प्रस्तुतियों के लिए, छवि अनुकूलन आम तौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और आरेखों को वेक्टर सामग्री के रूप में रखें, फ़ोटो को उनके वास्तविक प्रदर्शन आकार के अनुसार संपीड़ित करें, क्रॉप्ड पिक्सेल को तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी अपनाएँ जब निर्भरता प्रबंधन परिनियोजन डिज़ाइन का भाग हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**पिक्चर फ़्रेम और छवि संसाधन में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) प्रस्तुति से संबद्ध छवि संसाधन का प्रतिनिधित्व करता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) स्लाइड पर वह आकार है जो छवि प्रदर्शित करता है और फ़्रेम‑स्तरीय ज्यामिति तथा स्वरूपण जैसे आकार, घुमाव, क्रॉप मान, इफ़ेक्ट्स और लॉक को संग्रहीत करता है।

**मुझे छवियों को एम्बेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, आर्काइव या बाहरी संसाधनों के बिना रेंडर किया जाना हो, तो छवियों को एम्बेड करें। केवल तभी लिंक करें जब छवि फ़ाइलों को PPTX के बाहर रखने का इरादा हो और बाहरी स्थानों को भरोसेमंद रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को कम करती है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत छवि के भागों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सकता हो, तो [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉप्ड‑क्षेत्र हटाने के साथ छवि संपीड़न का उपयोग करें।

**क्या संपीड़न के बाद छवि गुणवत्ता को पुनः प्राप्त कर सकता हूँ?**

नहीं। संपीड़न संग्रहीत रास्टर रिज़ॉल्यूशन को घटा सकता है, और क्रॉप्ड क्षेत्रों को हटाने से छवि डेटा हट जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG छवियों को कैसे संभालना चाहिए?**

जब वेक्टर शुद्धता महत्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में निर्यात करने से SVG को पिक्सेल में बदल दिया जाता है।

**मौजूदा स्लाइड्स को पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

आकार प्रकार की जांच करने के बाद ही पिक्चर‑फ़्रेम‑विशिष्ट सदस्यों का उपयोग करें। [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) के विरुद्ध `instanceof` जाँच असमान कास्ट से बचती है और कोड को उन स्लाइडों को संभालने देती है जिनमें पिक्चर फ़्रेम नहीं होते।