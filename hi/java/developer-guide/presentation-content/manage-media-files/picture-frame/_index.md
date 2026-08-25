---
title: जावा का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/java/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड चित्र
- लिंक्ड चित्र
- चित्र निकालें
- रास्टर चित्र
- SVG चित्र
- चित्र क्रॉप करें
- क्रॉप किए गए क्षेत्रों को हटाएं
- चित्र संपीड़ित करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- चित्र प्रभाव
- आस्पेक्ट अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **अवलोकन**

एक picture frame एक slide shape है जो चित्र दिखाता है। Aspose.Slides में, चित्र संसाधन और वह shape जो इसे दिखाता है, अलग-अलग ऑब्जेक्ट हैं: एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) अपनी [IImageCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/) के माध्यम से एम्बेडेड चित्र संसाधनों का स्वामित्व रखती है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) चित्र की स्थिति, आकार, लाइन फ़ॉर्मेटिंग, रोटेशन, क्रॉपिंग, picture effects, और अन्य frame‑level सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही चित्र को कई बार दिखाया जाता है। चित्र को प्रस्तुति में एक बार जोड़ें, लौटे हुए [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) को रखें, और picture frames बनाते समय उसी चित्र संसाधन का उपयोग करें।

Picture frames PNG या JPEG जैसे रास्टर चित्र और SVG जैसे वेक्टर चित्र दोनों रख सकते हैं। वे लिंक किए गए चित्रों की ओर भी इशारा कर सकते हैं, जिससे चित्र बाइट्स प्रस्तुति में संग्रहीत नहीं होते। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण, और निर्यात व्यवहार पर असर डालेगा, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले तय करना उपयोगी है कि चित्र को कैसे संग्रहीत किया जाए।

## **एम्बेडेड चित्र जोड़ें और फ़ॉर्मेट करें**

एक एम्बेडेड चित्र के लिए, चित्र डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) का उपयोग करके एक picture frame बनाएं। चित्र प्रस्तुति पैकेज का हिस्सा बन जाता है, इसलिए प्रस्तुति को दूसरे कंप्यूटर पर ले जाने पर भी वह स्वयंपूर्ण रहती है।

निम्न उदाहरण JPEG चित्र जोड़ता है, चित्र के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग व रोटेशन लागू करता है:

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

picture frame प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम आकार बदलने से एम्बेडेड चित्र संसाधन में संग्रहीत मूल पिक्सेल डाइमेंशन नहीं बदलते। यह अंतर बाद में चित्र को क्रॉप या संपीड़ित करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केल को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) द्वारा एक्सपोज़ करता है। `1.0` का मान मूल picture आकार के 100 % के बराबर होता है। रिलेटिव स्केल तब उपयोगी होता है जब वर्कफ़्लो को स्रोत चित्र आकार के साथ अनुपात बनाए रखना हो, न कि अंतिम आयामों की मैन्युअल गणना करनी पड़ती हो।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड चित्र को री‑सैंपल या संपीड़ित नहीं करता।

## **एम्बेडेड और लिंक्ड चित्र**

एक एम्बेडेड picture चित्र डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के माध्यम से बाहरी स्थान को दर्शाता है, न कि उसी तरह डेटा को एम्बेड करता है।

लिंक्ड चित्र PPTX में संग्रहीत चित्र डेटा की मात्रा को कम कर सकते हैं, लेकिन वे बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रस्तुति खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं है, तो लिंक्ड picture अपेक्षा अनुसार नहीं दिखेगा। उन प्रस्तुतियों के लिए जो ई‑मेल, संग्रहित या अलगाव वाले वातावरण में रेंडर की जानी हों, एम्बेडेड चित्र आमतौर पर अधिक भरोसेमंद होते हैं।

### **लिंक्ड चित्र जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे स्थानीय चित्र फ़ाइल की ओर इशारा करता है। यह केवल चित्र लिंकिंग को दर्शाता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इस उदाहरण में सम्मिलित नहीं है।

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

बाहरी फ़ाइल प्रबंधन इरादतन होने पर लिंक का उपयोग करें। केवल संपीड़न का विकल्प न बनाएं: टूटा हुआ चित्र निर्भरता वाला छोटा PPTX अक्सर बड़े स्वयंपूर्ण प्रस्तुति से कम उपयोगी होता है।

## **picture frames से चित्र निकालें**

किसी मौजूदा प्रस्तुति से चित्र निकालने से पहले यह जाँचें कि shape वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) है और उसमें एक एम्बेडेड चित्र है। लिंक्ड picture frames में ऐसी चित्र बाइट्स नहीं हो सकतीं जिन्हें समान तरीके से निकाला जा सके।

### **रास्टर चित्र निकालें**

आधुनिक चित्र API सीधे [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) का उपयोग करता है और पुराने Java image wrapper की आवश्यकता नहीं होती। निम्न उदाहरण पहले एम्बेडेड रास्टर picture को खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के माध्यम से सहेजने से निकाले गए चित्र को अनुरोधित आउटपुट फ़ॉर्मेट में बदल दिया जाता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो परिवर्तित रास्टर फ़ाइल की बजाय चित्र संसाधन के बाइनरी डेटा का उपयोग करें।

### **SVG चित्र निकालें**

SVG picture के लिए, [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट एक्सपोज़ करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बिना पहले picture को रास्टराइज़ किए।

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

SVG सामग्री को SVG ही रखें तो वेक्टर स्रोत प्रस्तुति के भीतर बना रहता है। PNG या JPEG जैसे रास्टर निर्यात स्वाभाविक रूप से उस वेक्टर सामग्री को पिक्सेल में बदल देते हैं। PDF या SVG slide निर्यात भी एक रेंडरिंग ऑपरेशन है, इसलिए निर्यात किया गया ग्राफ़िक मूल एम्बेडेड SVG की बाइट‑फॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर संसाधन आवश्यक हो तो एम्बेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **चित्र को क्रॉप करें**

क्रॉपिंग वह भाग बदलती है जो फ्रेम के भीतर दिखाई देता है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत चित्र आयामों के प्रतिशत होते हैं। क्रॉपिंग प्रारंभिक रूप से एम्बेडेड चित्र से छिपे पिक्सेल को नहीं हटाती; यह केवल दृश्यमान क्षेत्र बदलती है।

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

क्योंकि छिपा हुआ चित्र डेटा अभी भी मौजूद है, क्रॉप को बाद में बदला जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक मायने रखता है और उलटा‑क्रॉप की आवश्यकता नहीं है, तो अगली सेक्शन में वर्णित अनुसार क्रॉपेड क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप किए गए चित्र डेटा को हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप रेक्टेंगल के बाहर के चित्र डेटा को हटाता है और परिणामी चित्र संसाधन लौटाता है। यह फ़ाइल आकार को घटा सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहेंगे।

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

यह मेथड प्रस्तुति में एक नया चित्र संसाधन जोड़ सकता है। यदि मूल चित्र अन्य picture frames द्वारा भी उपयोग किया जाता है, तो उन फ्रेमों को अभी भी अपना मौजूदा संसाधन चाहिए होगा, इसलिए क्रॉपेड क्षेत्रों को हटाने से जरूरी नहीं कि कुल चित्रों की संख्या घटे। इस मेथड से WMF या EMF सामग्री को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर चित्र संपीड़ित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) चित्र के डिस्प्ले आकार की तुलना में रास्टर चित्र रेज़ोल्यूशन को घटाता है। यह एक ही ऑपरेशन में क्रॉपेड क्षेत्रों को भी हटा सकता है। जब चित्र री‑साइज़ या क्रॉप किया जाता है तो मेथड `true` लौटाता है, और जब कोई परिवर्तन आवश्यक नहीं होता तो `false`।

जब एक मानक लक्ष्य रेज़ोल्यूशन पर्याप्त हो, तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि किसी विशिष्ट लक्ष्य की आवश्यकता हो तो पूर्वनिर्धारित मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

संपीड़न रास्टर चित्रों के लिए अभिप्रेत है। SVG और मेफ़ाइल सामग्री इस रास्टर संपीड़न वर्कफ़्लो से नहीं घटती। साथ ही याद रखें कि कम रेज़ोल्यूशन और हटाए गए क्रॉपेड क्षेत्रों को ऑप्टिमाइज़्ड प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रेज़ोल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर चित्र वास्तविक रूप से देखा या निर्यात किया जाएगा, न कि ग्लोबली सबसे कम DPI लागू करके।

## **चित्र ट्रांसफ़ॉर्म इफेक्ट्स को प्रबंधित करें**

पूर्ण वर्कफ़्लो के लिए जिसमें ब्राइटनेस, कंट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफेक्ट्स, ऑर्डर्ड चेन, निरीक्षण, हटाना, और राउंड‑ट्रिप वेरिफिकेशन शामिल हैं, देखें [Image Transform Effects](/java/image-transform-effects/)।

## **Picture Frame ज्योमेट्री को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame के लिए कौन‑सी एडिटिंग ऑपरेशन अक्षम हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय shape के अनुपात को बनाए रखता है।

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

लॉक picture frame shape पर लागू होता है। यह स्रोत चित्र को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मानों को समायोजित करें**

जब picture fill मोड stretch हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर stretch‑offset मान picture frame की बाउंडिंग बॉक्स के सापेक्ष fill rectangle को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप मान स्रोत चित्र के कौन‑से भाग दिखाई देंगे, यह तय करते हैं; stretch offsets वह rectangle बदलते हैं जिसमें दृश्यमान picture fill स्ट्रेच किया जाता है।

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

fill प्लेसमेंट के लिए stretch offsets का उपयोग करें। जब लक्ष्य स्रोत‑चित्र किनारों को छिपाना हो, तो क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और निर्यात विचार**

जब चित्र स्टोरेज और picture‑frame फ़ॉर्मेटिंग को अलग‑अलग माना जाता है, तो मुख्य ट्रेड‑ऑफ़ को संभालना आसान होता है:

- **Embedded images** प्रस्तुति को स्वयंपूर्ण बनाते हैं और शेयरिंग तथा सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होते हैं, लेकिन बड़े रास्टर चित्र PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर बनाते हैं।
- **Cropping** शुरू में गैर‑विनाशकारी होता है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक क्रॉपेड क्षेत्रों को स्पष्ट रूप से डिलीट या संपीड़न के दौरान नहीं हटाया जाता।
- **Compression** अत्यधिक बड़े रास्टर चित्रों के फ़ाइल आकार को काफी घटा सकता है, लेकिन स्रोत रेज़ोल्यूशन की कीमत पर। इसे स्लाइड पर वास्तविक आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG images** को तब तक SVG ही रखना चाहिए जब वेक्टर संरक्षण महत्वपूर्ण हो। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा rendered slide को पिक्सेल में बदलते हैं।
- **Repeated images** जब संभव हो, उसी [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) संसाधन को पुन: उपयोग करें, न कि एक ही फ़ाइल को बार‑बार लोड करके प्रस्तुति वर्कफ़्लो में जोड़ें।

बड़ी प्रस्तुतियों के लिए, चित्र ऑप्टिमाइज़ेशन आमतौर पर चयनात्मक रूप से अधिक प्रभावी होता है: लोगो और डायाग्राम को वेक्टर कंटेंट के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संपीड़ित करें, क्रॉप्ड पिक्सेल को तभी हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक तभी रखें जब निर्भरता प्रबंधन डिप्लॉयमेंट डिजाइन का हिस्सा हो।

## **FAQ**

**picture frame और image resource में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) प्रस्तुति से जुड़ा image resource दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) स्लाइड पर वह shape है जो चित्र दिखाता है और फ्रेम‑level ज्योमेट्री तथा फ़ॉर्मेटिंग जैसे आकार, रोटेशन, क्रॉप मान, इफ़ेक्ट्स, और लॉक्स को संग्रहीत करता है।

**मुझे चित्र एम्बेड करना चाहिए या लिंक?**

जब प्रस्तुति को पोर्टेबल, अभिलेखित या बाहरी संसाधनों के बिना रेंडर करने की आवश्यकता हो, तो चित्र एम्बेड करें। केवल तब ही चित्र लिंक करें जब चित्र फ़ाइलों को PPTX के बाहर रखना जानबूझकर हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग से PPTX फ़ाइल आकार घटता है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत चित्र के हिस्से को छिपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। उन पिक्सेल को स्थायी रूप से हटाने के लिए [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉप्ड‑एरिया हटाने के साथ इमेज कॉम्प्रेशन का उपयोग करें।

**क्या मैं संपीड़न के बाद चित्र गुणवत्ता पुनः प्राप्त कर सकता हूँ?**

नहीं। संपीड़न संग्रहीत रास्टर रेज़ोल्यूशन को घटा देता है, और क्रॉप्ड क्षेत्रों को हटाना चित्र डेटा को स्थायी रूप से हटाता है। यदि बाद में हाई‑रेज़ोल्यूशन एडिट की आवश्यकता हो, तो मूल स्रोत चित्र को प्रस्तुति के बाहर रखें।

**SVG चित्रों को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG कंटेंट को SVG ही रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में निर्यात करने पर SVG को स्लाइड इमेज का हिस्सा पिक्सेल में बदल दिया जाता है।

**मौजूदा स्लाइड पढ़ते समय unsafe casts से कैसे बचें?**

shape प्रकार की जाँच करें और फिर picture‑frame‑specific सदस्यों को उपयोग करें। एक `instanceof` जाँच [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) के विरुद्ध करने से अमान्य casts से बचा जा सकता है और कोड उन स्लाइडों को संभाल सकता है जिनमें picture frames नहीं हैं।