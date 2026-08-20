---
title: Android पर प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/androidjava/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एंबेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रास्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएँ
- छवि संकुचित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- छवि प्रभाव
- अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android (Java) के माध्यम से प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **परिचय**

एक पिक्चर फ्रेम एक स्लाइड आकार है जो छवि को प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) अपने एंबेडेड छवि संसाधनों का स्वामित्व अपने [IImageCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/) के माध्यम से रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) छवि की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, घूर्णन, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑स्तरीय सेटिंग्स को नियंत्रित करता है।

जब एक ही छवि को कई बार दिखाना हो तो यह विभाजन उपयोगी होता है। छवि को प्रस्तुति में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) को रखें, और पिक्चर फ्रेम बनाते समय उसी छवि संसाधन का उपयोग करें।

पिक्चर फ्रेम PNG या JPEG जैसे रास्टर छवियों और SVG जैसे वेक्टर छवियों दोनों को समाहित कर सकते हैं। वे लिंक्ड छवियों को भी संदर्भित कर सकते हैं बजाय इसके कि छवि बाइट्स को प्रस्तुति में संग्रहीत किया जाए। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि कैसे संग्रहीत की जानी चाहिए।

## **एंबेडेड छवि जोड़ें और फ़ॉर्मेट करें**

एंबेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) का उपयोग करके पिक्चर फ्रेम बनाएँ। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को किसी अन्य कंप्यूटर पर ले जाने पर वह स्वयं‑समाहित रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग तथा घूर्णन लागू करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

पिक्चर फ्रेम प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एंबेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में छवि को क्रॉप या कम्प्रेस करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) फ्रेम के लिए सापेक्ष चौड़ाई और ऊँचाई स्केलिंग को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के बराबर है। रिलेटिव स्केल तब उपयोगी होता है जब वर्कफ़्लो को स्रोत छवि आकार के अनुपात को बनाए रखना होता है बजाय अंतिम आयामों की मैन्युअल गणना के।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एंबेडेड छवि को पुनःसैंपल या कम्प्रेस नहीं करता।

## **एंबेडेड और लिंक्ड छवियाँ**

एक एंबेडेड पिक्चर छवि डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी तथा पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड पिक्चर बाहरी स्थान को [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के माध्यम से संग्रहीत करता है, न कि छवि डेटा को उसी तरह एंबेड करके।

लिंक्ड छवियाँ PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे बाहरी निर्भरता लाती हैं। लिंक्ड फ़ाइल को उस अनुप्रयोग द्वारा सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पथ बदलता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन अनुपलब्ध हो जाता है, तो लिंक्ड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जो ई‑मेल, अभिलेख़ या अलग‑थलग वातावरण में रेंडर की जानी हों, एंबेडेड छवियाँ आमतौर पर अधिक भरोसेमंद होती हैं।

### **लिंक्ड छवि जोड़ें**

निम्न उदाहरण पिक्चर फ्रेम बनाता है और उसे स्थानीय छवि फ़ाइल की ओर इंगित करता है। यह केवल छवि लिंकिंग से निपटता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इरादे से इस उदाहरण में मिश्रित नहीं किया गया है।

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

जब बाहरी फ़ाइल प्रबंधन इरादतन हो तो लिंक का उपयोग करें। उन्हें केवल कम्प्रेशन के विकल्प के रूप में न इस्तेमाल करें: टूटे हुए लिंक वाली छोटी PPTX आमतौर पर बड़े स्वयं‑समाहित प्रस्तुति से कम उपयोगी होती है।

## **पिक्चर फ्रेम से छवियाँ निकालें**

किसी मौजूदा प्रस्तुति से छवि निकालने से पहले सत्यापित करें कि आकार वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) है और उसमें एंबेडेड छवि है। लिंक्ड पिक्चर फ्रेम में वह बाइट्स नहीं हो सकते जो समान तरह से निकाले जा सकें।

### **रास्टर छवि निकालें**

आधुनिक छवि API सीधे [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) का उपयोग करता है और पुराने Java इमेज रैपर की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहली एंबेडेड रास्टर चित्र को खोजता है और उसे PNG रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के माध्यम से सहेजना निकाली गई छवि को अनुरोधित आउटपुट फ़ॉर्मेट में परिवर्तित करता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए तो परिवर्तित रास्टर फ़ाइल के बजाय छवि संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG छवि निकालें**

SVG चित्र के लिए, [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बिना पहले चित्र को रास्टराइज़ किए।

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

SVG सामग्री को SVG के रूप में रखना प्रस्तुति में वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे रास्टर निर्यात स्वाभाविक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करता है। PDF या SVG स्लाइड निर्यात भी एक रेंडर ऑपरेशन है, इसलिए निर्यातित ग्राफ़िक्स को मूल एंबेडेड SVG की बाइट‑दर‑बाइट प्रति‑कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन स्वयं आवश्यक हो तो एंबेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर किस भाग की छवि दिखाई देती है, इसे बदलती है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत छवि आयामों का प्रतिशत होते हैं। क्रॉपिंग प्रारम्भ में एंबेडेड छवि से छिपे पिक्सेल को नहीं हटाती; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से पिक्चर फ्रेम खोजता है और क्रॉप मान लागू करता है:

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

चूँकि छिपा डेटा अभी भी मौजूद है, क्रॉप को बाद में बदला जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनः‑क्रॉप की आवश्यकता नहीं है, तो अगले अनुभाग में वर्णित तरीके से क्रॉपेड क्षेत्रों को भौतिक रूप से हटाया जा सकता है।

## **क्रॉप्ड छवि डेटा हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप आयत के बाहर के छवि डेटा को हटाता है और परिणामी छवि संसाधन लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल आगे के अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं होते।

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

यह मेथड प्रस्तुति में एक नई छवि संसाधन जोड़ सकता है। यदि मूल छवि का प्रयोग अन्य पिक्चर फ्रेम भी करते हैं, तो उन फ्रेम को अभी भी अपना मौजूदा संसाधन चाहिए होगा, इसलिए क्रॉप्ड क्षेत्रों को हटाना आवश्यक रूप से कुल छवियों की संख्या नहीं घटाता। इस मेथड से WMF या EMF सामग्री को क्रॉप करने से परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर छवियों को संकुचित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) रास्टर छवि के रिज़ॉल्यूशन को उस आकार के सापेक्ष कम करता है जिस पर चित्र प्रदर्शित होता है। यह उसी ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब छवि को रिसाइज़ या क्रॉप किया गया हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि कोई विशिष्ट लक्ष्य आवश्यक हो तो पूर्वनिर्धारित मान के स्थान पर एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन रास्टर छवियों के लिये अभिप्रेत है। SVG और मेटाफाइल सामग्री इस रास्टर संकुचन वर्कफ़्लो से नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर छवि वास्तव में देखी या निर्यात की जाएगी, न कि पूरे प्रस्तुति में सबसे कम DPI लागू करके।

## **छवि प्रभावों का निरीक्षण करें**

चित्र प्रभाव फ्रेम द्वारा उपयोग किए गए चित्र पर संग्रहीत होते हैं। इमेज ट्रांसफ़ॉर्म कलेक्शन में अल्फा मॉड्यूलेशन (पारदर्शिता) और ल्यूमिनेंस (उज्ज्वलता व कंट्रास्ट) जैसे प्रभाव हो सकते हैं। नीचे दिया गया उदाहरण स्लाइड पर पहली पिक्चर फ्रेम से दोनों प्रकार के प्रभावों को सुरक्षित रूप से पढ़ता है:

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

ये प्रभाव फ्रेम में छवि के रेंडरिंग को बदलते हैं; वे मूल एंबेडेड छवि बाइट्स को पुनः‑लिखते नहीं हैं।

## **पिक्चर फ्रेम ज्योमेट्री को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/) सेटिंग्स निर्धारित करती हैं कि पिक्चर फ्रेम पर कौन‑सी संपादन क्रियाएँ अक्षम होंगी। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय आकार के अनुपात को बरकरार रखता है।

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

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत छवि को पुनः‑सैंपल या स्थायी रूप से समान अनुपात में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब चित्र भराव मोड “stretch” हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर stretch‑offset मान पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष भराव आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारा से एक इनसेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत छवि के किस भाग को दिखाना है, तय करते हैं; stretch‑offset मान उस आयत को बदलते हैं जिसमें दृश्यमान चित्र भराव खींचा जाता है।

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

भराव की स्थिति के लिए stretch‑offset का उपयोग करें। जब लक्ष्य स्रोत‑छवि किनारों को छुपाना हो, तो क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार और निर्यात पर विचार**

जब छवि भंडारण और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग माना जाता है तो मुख्य समझौते आसान होते हैं:

- **एंबेडेड छवियाँ** प्रस्तुति को स्वयं‑समाहित बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे विश्वसनीय होती हैं, लेकिन बड़े रास्टर छवियाँ PPTX आकार और मेमोरी उपयोग को बढ़ा देती हैं।
- **लिंक्ड छवियाँ** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों तक पहुँच बनाए रखनी पड़ती है जो निर्दिष्ट पथ या स्थानों पर उपलब्ध हों।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी है। छिपे पिक्सेल तब तक एंबेडेड रहते हैं जब तक क्रॉप्ड क्षेत्रों को स्पष्ट रूप से हटाया या संकुचन के दौरान नहीं हटाया जाता।
- **संकुचन** ओवर‑साइज़्ड रास्टर छवियों के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन का त्याग करता है। इसे स्लाइड पर इरादतन आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG छवियाँ** वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में ही रखी जानी चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एंबेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा रेंडर की गई स्लाइड को पिक्सेल में परिवर्तित करता है।
- **दोहराई गई छवियाँ** संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) संसाधन को पुनः‑उपयोग करें, न कि एक ही फ़ाइल को बार‑बार लोड करें।

बड़ी प्रस्तुतियों के लिए, छवि अनुकूलन अक्सर चयनात्मक रूप से अधिक प्रभावी होता है: लोगो और आरेख को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शन आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सेल को केवल तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी उपयोग करें जब निर्भरता प्रबंधन विकास‑परिनियोजन डिजाइन का हिस्सा हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**पिक्चर फ्रेम और छवि संसाधन में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) प्रस्तुति से संबद्ध छवि संसाधन को दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) स्लाइड पर वह आकार है जो छवि प्रदर्शित करता है और फ्रेम‑स्तरीय ज्योमेट्री तथा फ़ॉर्मेटिंग (आकार, घूर्णन, क्रॉप मान, प्रभाव, लॉक) संग्रहीत करता है।

**मुझे छवियों को एंबेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, अभिलेखीय या बाहरी संसाधनों तक पहुंच के बिना रेंडर करने की आवश्यकता हो, तो छवियों को एंबेड करें। केवल तब लिंक करें जब छवि फ़ाइलों को PPTX के बाहर रखना इरादतन हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग से PPTX फ़ाइल आकार घटता है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत छवि के हिस्सों को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। जब उन पिक्सेल को स्थायी रूप से हटाया जा सके, तब [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉप्ड‑क्षेत्र हटाने वाली छवि संकुचन का उपयोग करके फ़ाइल आकार घटाया जा सकता है।

**क्या मैं संकुचन के बाद छवि गुणवत्ता पुनः प्राप्त कर सकता हूँ?**

नहीं। संकुचन संग्रहीत रास्टर रिज़ॉल्यूशन को घटा देता है, और क्रॉप्ड क्षेत्रों को हटाना छवि डेटा का नाश करता है। यदि बाद में हाई‑रेज़ोल्यूशन संपादन की आवश्यकता हो, तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG छवियों को कैसे संभालें?**

जब वेक्टर सत्यता महत्वपूर्ण हो तो SVG सामग्री को SVG के रूप में रखें। एंबेडेड [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में निर्यात करने से SVG रेंडर होकर पिक्सेल बन जाता है।

**मौजूदा स्लाइड पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

आकार प्रकार की जाँच करें और फिर पिक्चर‑फ़्रेम‑विशिष्ट सदस्यों का उपयोग करें। [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) के विरुद्ध `instanceof` जांच असमान कास्ट को रोकती है और कोड को उन स्लाइडों को संभालने की अनुमति देती है जो पिक्चर फ्रेम नहीं रखते।