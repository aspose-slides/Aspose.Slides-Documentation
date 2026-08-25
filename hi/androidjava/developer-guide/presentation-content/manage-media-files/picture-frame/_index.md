---
title: एंड्रॉइड पर प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/androidjava/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड छवि
- लिंक्ड छवि
- छवि निकालें
- रेस्टर छवि
- SVG छवि
- छवि क्रॉप करें
- क्रॉप किए गए क्षेत्रों को हटाएं
- छवि संकुचित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- सापेक्ष स्केल
- छवि प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java के माध्यम से प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **अवलोकन**

एक Picture Frame एक slide shape है जो छवि को प्रदर्शित करता है। Aspose.Slides में, छवि संसाधन और उसे प्रदर्शित करने वाला shape अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) अपने [IImageCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/) के माध्यम से एम्बेडेड छवि संसाधनों का स्वामित्व रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) छवि की स्थिति, आकार, रेखा प्रारूपण, घूर्णन, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑स्तरीय सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही छवि को एक से अधिक बार दिखाया जाता है। छवि को प्रस्तुति में एक बार जोड़ें, प्राप्त हुए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) को रखें, और उस छवि संसाधन का उपयोग picture frames बनाते समय करें।

Picture frames PNG या JPEG जैसी रास्टर छवियों और SVG जैसी वेक्टर छवियों दोनों को समाहित कर सकते हैं। वे प्रस्तुति में छवि बाइट्स को संग्रहीत करने के बजाय लिंक्ड छवियों को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि छवि को कैसे संग्रहीत किया जाए।

## **एम्बेडेड छवि जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड छवि के लिए, छवि डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) का उपयोग करके picture frame बनाएं। छवि प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर वह स्व‑समावेशी रहती है।

निम्न उदाहरण JPEG छवि जोड़ता है, छवि के मूल आयामों पर एक फ्रेम बनाता है, तथा रेखा प्रारूपण और घूर्णन लागू करता है:

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

picture frame प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम आकार बदलने से एम्बेडेड छवि संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर तब महत्वपूर्ण हो जाता है जब बाद में छवि को क्रॉप या संकुचित किया जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) फ्रेम के लिए सापेक्ष चौड़ाई और ऊँचाई स्केल को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। मान `1.0` मूल चित्र आकार के 100 % के बराबर होता है। सापेक्ष स्केल तब उपयोगी होता है जब कार्य‑प्रवाह को स्रोत छवि आकार के संबंध को बनाए रखना होता है, बजाय अंतिम आयामों की मैन्युअल गणना के।

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

सापेक्ष स्केल फ्रेम के स्केल सेटिंग्स को बदलता है; यह एम्बेडेड छवि को पुन: सैंपल या संकुचित नहीं करता।

## **एम्बेडेड और लिंक्ड छवियाँ**

एक एम्बेडेड picture डेटा को प्रस्तुति के अंदर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमानित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture बाहरी स्थान को [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के माध्यम से संग्रहीत करता है, बजाय उसी तरह छवि डेटा को एम्बेड करने के।

लिंक्ड छवियाँ PPTX में संग्रहीत छवि डेटा की मात्रा को कम कर सकती हैं, लेकिन वे बाहरी निर्भरता पेश करती हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं रहता, तो लिंक्ड picture अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जिन्हें ई‑मेल, अभिलेख या अलग‑थलग वातावरण में रेंडर करने की आवश्यकता होती है, एम्बेडेड छवियाँ आमतौर पर अधिक भरोसेमंद होती हैं।

### **लिंक्ड छवि जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय छवि फ़ाइल की ओर संकेत करता है। यह केवल छवि लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया कार्य‑प्रवाह है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

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

जब बाहरी फ़ाइल प्रबंधन जानबूझकर हो, तब लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में उपयोग न करें: टूटे हुए छवि निर्भरताओं वाले छोटे PPTX आमतौर पर बड़े स्व‑समावेशी प्रस्तुति से कम उपयोगी होते हैं।

## **Picture Frames से छवियों को निकालें**

किसी मौजूदा प्रस्तुति से छवि निकालने से पहले यह जाँचें कि shape वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) है और उसमें एम्बेडेड छवि है। लिंक्ड picture frames में वह छवि बाइट्स नहीं हो सकते जिन्हें उसी तरह निर्यात किया जा सके।

### **रेस्टर छवि निकालें**

आधुनिक छवि API सीधे [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) का उपयोग करता है और पुरानी Java image wrapper की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड रेस्टर picture खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के माध्यम से सहेजना निकाली गई छवि को अनुरोधित आउटपुट फ़ॉर्मेट में बदल देता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो परिवर्तित रेस्टर फ़ाइल के बजाय छवि संसाधन के बाइनरी डेटा को उपयोग करें।

### **SVG छवि निकालें**

एक SVG picture के लिए, [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट उजागर करता है। इससे आप SVG डेटा को सीधे प्राप्त कर सकते हैं, बिना पहले picture को रास्टराइज़ किए।

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

SVG सामग्री को SVG के रूप में रखना प्रस्तुति के भीतर वेक्टर स्रोत को संरक्षित करता है। PNG या JPEG जैसे रास्टर निर्यात स्वाभाविक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करता है। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग प्रक्रिया है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑दर‑बाइट प्रतिलिपि के रूप में नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन की आवश्यकता हो, तब एम्बेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **छवि को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर छवि के किस भाग को दिखाना है, इसे बदलती है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत छवि आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारम्भ में एम्बेडेड छवि से छिपे पिक्सेल को मिटाता नहीं है; यह केवल दृश्य क्षेत्र को बदलता है।

निम्न उदाहरण एक picture frame को सुरक्षित रूप से खोजता है और क्रॉप मान लागू करता है:

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

क्योंकि छिपा हुआ छवि डेटा अभी भी मौजूद है, क्रॉप को बाद में परिवर्तन किया जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनः‑क्रॉप की आवश्यकता नहीं है, तो अगले सेक्शन में वर्णित अनुसार क्रॉप किए गए क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए गए छवि डेटा को हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप आयत के बाहर की छवि डेटा को हटाता है और परिणामी छवि संसाधन को वापस देता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजे जाने के बाद हटाए गए पिक्सेल बाद में अन‑क्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहेंगे।

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

यह मेथड प्रस्तुति में एक नई छवि संसाधन जोड़ सकता है। यदि मूल छवि को अन्य picture frames भी उपयोग कर रहे हैं, तो उन फ्रेमों को अभी भी अपनी मौजूदा संसाधन की आवश्यकता होगी, इसलिए क्रॉप किए गए क्षेत्रों को हटाने से हमेशा कुल छवियों की संख्या नहीं घटती। WMF या EMF सामग्री को इस मेथड से क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रेस्टर छवियों को संकुचित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) रेस्टर छवि का रिज़ॉल्यूशन उस आकार के सापेक्ष घटाता है जिस पर चित्र प्रदर्शित होता है। यह एक ही ऑपरेशन में क्रॉप किए गए क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब छवि को री‑साइज़ या क्रॉप किया गया हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि किसी विशिष्ट लक्ष्य की आवश्यकता हो, तो पूर्वनिर्धारित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संकुचन रेस्टर छवियों के लिए है। SVG और मेटा‑फ़ाइल सामग्री इस रेस्टर संकुचन कार्य‑प्रवाह से नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर छवि वास्तव में देखी या निर्यात की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करें।

## **छवि ट्रांसफ़ॉर्म इफ़ेक्ट्स प्रबंधित करें**

ब्राइटनेस, कॉन्ट्रास्ट, रंग परिवर्तन, ब्लर, अल्फा इफ़ेक्ट्स, क्रमबद्ध चेन, निरीक्षण, हटाना और राउंड‑ट्रिप सत्यापन सहित पूर्ण कार्य‑प्रवाह के लिए, देखें [Image Transform Effects](/slides/hi/androidjava/image-transform-effects/)।

## **Picture Frame ज्यामिति को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame पर कौन‑से संपादन कार्य निष्क्रिय हैं। उदाहरण के तौर पर, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय shape के अनुपात को संरक्षित करता है।

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

लॉक केवल picture frame shape पर लागू होता है। यह स्रोत छवि को पुन: सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब picture fill मोड stretch हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर stretch‑offset मान picture frame की सीमा के सापेक्ष fill आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक अंदरूनी अंतर बनाते हैं, जबकि नकारात्मक प्रतिशत बाहर की सीमा बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान यह चुनते हैं कि स्रोत छवि का कौन‑सा भाग दिखाई देगा; stretch‑offset वह आयत बदलते हैं जिसमें दृश्य picture fill खींचा जाता है।

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

fill प्लेसमेंट के लिए stretch‑offset का उपयोग करें। स्रोत‑छवि किनारों को छिपाने के उद्देश्य से crop प्रॉपर्टी का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और निर्यात विचार**

जब छवि स्टोरेज और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग माना जाता है, तो मुख्य समझौते आसान‑से‑प्रबंधित हो जाते हैं:

- **एम्बेडेड छवियाँ** प्रस्तुति को स्व‑समावेशी बनाती हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होती हैं, लेकिन बड़े रेस्टर छवियाँ PPTX आकार और मेमोरी उपयोग को बढ़ा देती हैं।
- **लिंक्ड छवियाँ** पैकेज को छोटा रख सकती हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाती हैं।
- **क्रॉपिंग** प्रारम्भ में गैर‑विनाशकारी होती है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक क्रॉपेड क्षेत्रों को स्पष्ट रूप से हटाया या संकुचन के दौरान हटाया न जाए।
- **संकुचन** अत्यधिक बड़े रेस्टर छवियों के फ़ाइल आकार को काफी घटा सकता है, लेकिन इससे मूल रिज़ॉल्यूशन चली जाती है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG छवियाँ** वेक्टर संरक्षा महत्वपूर्ण होने पर SVG के रूप में ही रखी जानी चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रेस्टर स्लाइड निर्यात हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदल देता है।
- **दोहराई गई छवियाँ** जब संभव हो तब एक मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) संसाधन को पुन: उपयोग करें, बजाय बार‑बार वही फ़ाइल प्रस्तुति कार्य‑प्रवाह में लोड करने के।

बड़ी प्रस्तुतियों के लिए, छवि अनुकूलन आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और आरेखों को वेक्टर सामग्री के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक प्रदर्शन आकार के अनुसार संकुचित करें, क्रॉप किए हुए पिक्सेल को केवल तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक को तब तक टालें जब तक निर्भरता प्रबंधन परिनियोजन डिज़ाइन का हिस्सा न हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**Picture Frame और Image Resource में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) प्रस्तुति के साथ संबद्ध एक image resource को दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) स्लाइड पर वह shape है जो छवि को प्रदर्शित करता है और फ्रेम‑स्तर की ज्यामिति तथा फ़ॉर्मेटिंग जैसे आकार, घूर्णन, क्रॉप मान, इफ़ेक्ट्स और लॉक को संग्रहीत करता है।

**मुझे छवियों को एम्बेड करना चाहिए या लिंक करना चाहिए?**

जब प्रस्तुति को पोर्टेबल, अभिलेखित या बाहरी संसाधनों की पहुँच के बिना रेंडर करना हो, तो छवियों को एम्बेड करें। केवल तब ही छवियों को लिंक करें जब फ़ाइलों को प्रस्तुति के बाहर रखना इरादा हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार को घटाती है?**

खुद से नहीं। सामान्य क्रॉप सेटिंग्स स्रोत छवि के भाग को छुपाती हैं लेकिन अंतर्निहित पिक्सेल को बरकरार रखती हैं। जब इन पिक्सेल को स्थायी रूप से हटाया जा सकता है, तब [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉपेड‑एरिया हटाने के साथ छवि संकुचन का उपयोग करें।

**क्या मैं संकुचन के बाद छवि की गुणवत्ता को पुनः प्राप्त कर सकता हूँ?**

नहीं। संकुचन संग्रहीत रेस्टर रिज़ॉल्यूशन को घटा देता है, और क्रॉप्ड क्षेत्रों को हटाने से छवि डेटा स्थायी रूप से हट जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की आवश्यकता हो, तो मूल स्रोत छवि को प्रस्तुति के बाहर रखें।

**SVG छवियों को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रेस्टर फ़ॉर्मेट में निर्यात करने से SVG रेंडर हो कर पिक्सेल में बदल जाता है।

**मौजूदा स्लाइड्स को पढ़ते समय असुरक्षित कास्ट को कैसे बचाएँ?**

shape प्रकार को उपयोग करने से पहले जाँचें। [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) के विरुद्ध `instanceof` जांच असमान कास्ट से बचाती है और कोड को उन स्लाइडों को संभालने देती है जिनमें picture frames नहीं होते।