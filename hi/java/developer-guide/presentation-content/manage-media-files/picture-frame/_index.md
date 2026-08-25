---
title: प्रस्तुतीकरण में जावा का उपयोग करके पिक्चर फ्रेम प्रबंधित करें
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
- क्रॉप किए गए क्षेत्रों को हटाएँ
- छवि संपीड़ित करें
- StretchOffset
- पिक्चर फ्रेम स्वरूपण
- सापेक्ष स्केल
- छवि प्रभाव
- अनुपात
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ प्रस्तुतियों में पिक्चर फ्रेम को बनाएं, स्वरूपित करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **अवलोकन**

एक पिक्चर फ्रेम स्लाइड का एक आकार है जो चित्र प्रदर्शित करता है। Aspose.Slides में, चित्र संसाधन और उसे प्रदर्शित करने वाला आकार अलग-अलग वस्तुएँ हैं: एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) अपने [IImageCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/) के माध्यम से एम्बेडेड चित्र संसाधनों का स्वामित्व रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) चित्र की स्थिति, आकार, रेखा स्वरूपण, घूर्णन, क्रॉपिंग, चित्र प्रभाव और अन्य फ्रेम‑स्तरीय सेटिंग्स को नियंत्रित करता है।

जब एक ही चित्र कई बार दिखाया जाता है तो यह विभाजन उपयोगी होता है। चित्र को प्रस्तुति में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) को रखें, और पिक्चर फ्रेम बनाते समय उसी चित्र संसाधन का उपयोग करें।

पिक्चर फ्रेम में PNG या JPEG जैसे रास्टर चित्र तथा SVG जैसे वेक्टर चित्र दोनों शामिल हो सकते हैं। वे चित्र बाइट्स को प्रस्तुति में संग्रहीत करने के बजाय लिंक्ड चित्रों की ओर भी इशारा कर सकते हैं। यह विकल्प पोर्टेबिलिटी, फ़ाइल आकार, निष्कर्षण और निर्यात व्यवहार को प्रभावित करता है, इसलिए स्वरूपण या अनुकूलन लागू करने से पहले यह तय करना उपयोगी है कि चित्र को कैसे संग्रहीत किया जाए।

## **एक एम्बेडेड छवि जोड़ें और स्वरूपित करें**

एक एम्बेडेड चित्र के लिए, चित्र डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) के साथ एक पिक्चर फ्रेम बनाएं। चित्र प्रस्तुति पैकेज का हिस्सा बन जाता है, इसलिए प्रस्तुति दूसरे कंप्यूटर पर ले जाने पर भी स्वयं‑संकुलित रहती है।

निम्न उदाहरण JPEG चित्र जोड़ता है, मूल आयामों पर एक फ्रेम बनाता है, और रेखा स्वरूपण तथा घूर्णन लागू करता है:

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

पिक्चर फ्रेम प्रदर्शित ज्यामिति को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड चित्र संसाधन में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। बाद में चित्र को क्रॉप या संपीड़ित करने पर यह अंतर महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) फ्रेम के लिए सापेक्ष चौड़ाई और ऊँचाई स्केल को [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) के माध्यम से उजागर करता है। `1.0` मान मूल चित्र आकार के 100 % के बराबर होता है। सापेक्ष स्केल उपयोगी है जब कार्य‑प्रवाह को स्रोत चित्र आकार के संबंध को बनाए रखना होता है, बजाय अंतिम आयामों की मैन्युअल गणना के।

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

सापेक्ष स्केल फ्रेम के स्केल सेटिंग को बदलता है; यह एम्बेडेड चित्र को पुनः‑सैंपल या संपीड़ित नहीं करता।

## **एंबेडेड और लिंक्ड छवियाँ**

एक एंबेडेड चित्र चित्र डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड चित्र [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के द्वारा बाहरी स्थान को संग्रहीत करता है, बजाय उसी तरह चित्र डेटा एम्बेड करने के।

लिंक्ड छवियाँ PPTX में संग्रहीत चित्र डेटा की मात्रा को घटा सकती हैं, लेकिन वे बाहरी निर्भरता उत्पन्न करती हैं। लिंक्ड फ़ाइल को उस अनुप्रयोग के लिए उपलब्ध रहना चाहिए जो प्रस्तुति खोलता या रेंडर करता है। यदि पथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या संसाधन उपलब्ध नहीं रहता, तो लिंक्ड चित्र अपेक्षा के अनुसार प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जो ई‑मेल, संग्रहण या पृथक वातावरण में रेंडर की जानी हों, एंबेडेड छवियाँ आमतौर पर अधिक विश्वसनीय होती हैं।

### **एक लिंक्ड छवि जोड़ें**

निम्न उदाहरण एक पिक्चर फ्रेम बनाता है और उसे स्थानीय चित्र फ़ाइल की ओर इंगित करता है। यह केवल चित्र लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया कार्य‑प्रवाह है और जानबूझकर इस उदाहरण में मिश्रित नहीं किया गया है।

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

बाहरी फ़ाइल प्रबंधन इच्छा‑पूर्ण होने पर लिंक का उपयोग करें। उन्हें केवल संपीड़न के विकल्प के रूप में न उपयोग करें: टूटी हुई छवि निर्भरताओं वाला छोटा PPTX आमतौर पर बड़े स्वयं‑संकुलित प्रस्तुति से कम उपयोगी होता है।

## **चित्र फ्रेम से छवियों को निकालें**

किसी मौजूदा प्रस्तुति से चित्र निकालने से पहले यह जांचें कि आकार वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) है और उसमें एम्बेडेड चित्र मौजूद है। लिंक्ड पिक्चर फ्रेम में वह बाइट्स नहीं हो सकते जो समान तरीके से निकाले जा सकें।

### **रेस्टर छवि निकालें**

आधुनिक चित्र API सीधे [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) का उपयोग करता है और पुराने जावा चित्र Wrapper की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड रेस्टर चित्र खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के माध्यम से सहेजना निकाली गई छवि को अनुरोधित आउटपुट फॉर्मेट में बदल देता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए तो Raster फ़ाइल के बजाय चित्र संसाधन के बाइनरी डेटा का उपयोग करें।

### **एक SVG छवि निकालें**

एक SVG चित्र के लिए, [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट उजागर करता है। यह आपको SVG डेटा सीधे प्राप्त करने की सुविधा देता है, बिना पहले चित्र को रास्टराइज़ किए।

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

SVG सामग्री को SVG के रूप में रखना वेक्टर स्रोत को प्रस्तुति के भीतर संरक्षित करता है। PNG या JPEG जैसे रास्टर निर्यात स्वाभाविक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करते हैं। PDF या SVG स्लाइड निर्यात भी एक रेंडरिंग प्रक्रिया है, इसलिए निर्यातित ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑बाय‑बाइट प्रतिलिपि न मानें; मूल वेक्टर संसाधन की आवश्यकता होने पर एम्बेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **एक छवि को क्रॉप करें**

क्रॉप करने से फ्रेम के अंदर दृश्य भाग बदलता है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर क्रॉप मान स्रोत चित्र की आयामों के प्रतिशत होते हैं। क्रॉप करने से एम्बेडेड चित्र से छिपे पिक्सेल तुरंत हटते नहीं हैं; यह केवल दृश्य क्षेत्र बदलता है।

निम्न उदाहरण सुरक्षित रूप से एक पिक्चर फ्रेम खोजता है और क्रॉप मान लागू करता है:

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

क्योंकि छिपा चित्र डेटा अभी भी मौजूद है, क्रॉप को बाद में बदला जा सकता है बिना मूल पिक्सेल खोए। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनर्संरचना की आवश्यकता नहीं है, तो अगला अनुभाग बताएगा कि कैसे क्रॉप किए गए क्षेत्रों को शारीरिक रूप से हटाया जाए।

## **क्रॉप की गई छवि डेटा हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप आयत के बाहर की चित्र डेटा को हटाता है और परिणामस्वरूप चित्र संसाधन लौटाता है। यह फ़ाइल आकार घटा सकता है, लेकिन यह एक विनाशकारी अनुकूलन है: प्रस्तुति सहेजने के बाद हटाए गए पिक्सेल फिर से क्रॉप‑रिवर्स करने के लिए उपलब्ध नहीं रहते।

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

यह मेथड प्रस्तुति में नया चित्र संसाधन जोड़ सकता है। यदि मूल चित्र अन्य पिक्चर फ्रेम द्वारा भी उपयोग हो रहा है, तो उन फ्रेमों को अपना मौजूदा संसाधन चाहिए रहेगा, इसलिए क्रॉप किए हुए क्षेत्रों को हटाने से हमेशा कुल चित्रों की संख्या नहीं घटती। इस मेथड से WMF या EMF सामग्री को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रेस्टर छवियों को संपीड़ित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) रास्टर चित्र के रिज़ॉल्यूशन को उस आकार के सापेक्ष घटाता है जिस पर चित्र प्रदर्शित होता है। यह उसी ऑपरेशन में क्रॉप किए हुए क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब चित्र का आकार बदला गया हो या क्रॉप किया गया हो, और `false` जब कोई परिवर्तन आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो तो पूर्वनिर्धारित [PicturesCompression](https://reference.aspose.com/slides/hi/java/com.aspose.slides/picturescompression/) मान का उपयोग करें:

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

यदि कोई विशिष्ट लक्ष्य आवश्यक हो तो फ़्लोट मान के बजाय एक कस्टम पॉज़िटिव DPI मान पास किया जा सकता है।

संपीड़न रास्टर चित्रों के लिए अभिप्रेत है। SVG और मेटा‑फ़ाइल सामग्री इस रास्टर संपीड़न कार्य‑प्रवाह से नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप क्षेत्रों को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर चित्र वास्तव में देखा या निर्यात किया जाएगा, न कि वैश्विक रूप से न्यूनतम DPI लागू करके।

## **छवि ट्रांसफ़ॉर्म प्रभावों का प्रबंधन करें**

पूर्ण कार्य‑प्रवाह के लिए जो ब्राइटनेस, कंट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा प्रभाव, ऑर्डर्ड चेन, निरीक्षण, हटाना और राउंड‑ट्रिप वेरिफिकेशन को कवर करता है, देखें [Image Transform Effects](/slides/hi/java/image-transform-effects/)।

## **चित्र फ्रेम ज्यामिति को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम के लिए कौन‑से संपादन संचालन अक्षम होते हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार परिवर्तन के दौरान आकार अनुपात को बरकरार रखता है।

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

लॉक पिक्चर फ्रेम आकार पर लागू होता है। यह स्रोत चित्र को पुनः‑सैंपल या स्थायी रूप से उसी अनुपात में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब चित्र भराव मोड स्ट्रेच होता है, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) पर स्ट्रेच‑ऑफ़सेट मान चित्र फ्रेम की बाउंडिंग बॉक्स के सापेक्ष भराव आयत को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक इनसेट बनाते हैं, जबकि नकारात्मक प्रतिशत एक आउटसेट बनाते हैं।

यह क्रॉप से भिन्न है। क्रॉप मान स्रोत चित्र के किस भाग को दृश्य बनाता है, इसे चुनते हैं; स्ट्रेच‑ऑफ़सेट दृश्य चित्र भराव को किन आयत में स्ट्रेच किया जाए, उसे बदलते हैं।

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

फ़िल प्लेसमेंट के लिए स्ट्रेच‑ऑफ़सेट का उपयोग करें। स्रोत‑चित्र किनारों को छिपाने के उद्देश्य से क्रॉप गुणों का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और निर्यात विचार**

जब चित्र स्टोरेज और पिक्चर‑फ़्रेम स्वरूपण को अलग‑अलग संभाला जाता है, तो मुख्य समझौते आसानी से प्रबंधित होते हैं:

- **Embedded images** प्रस्तुति को स्वयं‑संकुलित बनाते हैं और साझा करने तथा सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होते हैं, लेकिन बड़े रास्टर चित्र PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों पर निर्भर रहना पड़ता है जो संग्रहीत पथ या स्थानों पर उपलब्ध रहें।
- **Cropping** शुरू में गैर‑विनाशकारी है। छिपे पिक्सेल तब तक एम्बेडेड रहते हैं जब तक क्रॉप किए गए क्षेत्रों को स्पष्ट रूप से हटाया न जाए या संपीड़न के दौरान नहीं हटाए जाएँ।
- **Compression** अतिप्रकाशित रास्टर चित्रों के फ़ाइल आकार को काफी घटा सकता है, लेकिन स्रोत रिज़ॉल्यूशन को त्यागता है। इसे स्लाइड पर वास्तविक आकार निर्धारित होने के बाद लागू किया जाना चाहिए।
- **SVG images** वेक्टर संरक्षण महत्वपूर्ण होने पर SVG के रूप में ही रहने चाहिए। जब आपको स्वयं वेक्टर संसाधन चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड निर्यात हमेशा रेंडर किए गए स्लाइड को पिक्सेल में बदलते हैं।
- **Repeated images** संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) संसाधन को पुन: उपयोग करें, बजाय एक ही फ़ाइल को बार‑बार प्रस्तुति‑कार्य‑प्रवाह में लोड करने के।

बड़ी प्रस्तुतियों के लिए, छवि अनुकूलन सबसे प्रभावी तब होता है जब चयनात्मक रूप से किया जाता है: लोगो और आरेखों को वेक्टर सामग्री के रूप में रखें, फ़ोटो को उनके वास्तविक दर्शनीय आकार के अनुसार संपीड़ित करें, केवल तब ही क्रॉप किए गए पिक्सेल हटाएँ जब बाद में संपादन की आवश्यकता न हो, और बाहरी लिंक केवल तभी रखें जब निर्भरता प्रबंधन तैनाती डिज़ाइन का हिस्सा हो।

## **अक्सर पूछे जाने वाले प्रश्न**

**एक पिक्चर फ्रेम और एक चित्र संसाधन में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) प्रस्तुति से जुड़ा चित्र संसाधन दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) स्लाइड पर वह आकार है जो चित्र प्रदर्शित करता है और फ्रेम‑स्तर की ज्यामिति व स्वरूपण जैसे आकार, घूर्णन, क्रॉप मान, प्रभाव और लॉक संग्रहीत करता है।

**मुझे चित्र एम्बेड करना चाहिए या लिंक करना?**

जब प्रस्तुति को पोर्टेबल, आर्काइव्ड या बाहरी संसाधनों के बिना रेंडर करने की आवश्यकता हो तो चित्र एम्बेड करें। लिंक केवल तब उपयोग करें जब चित्र फ़ाइलों को PPTX के बाहर रखना इरादा हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉप करने से PPTX फ़ाइल आकार कम होता है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग छिपे हिस्से को छिपाती है लेकिन मूल पिक्सेल को रखती है। उन पिक्सेल को स्थायी रूप से हटाने के लिए [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉप‑क्षेत्र हटाने के साथ चित्र संपीड़न का उपयोग करें।

**क्या संपीड़न के बाद मैं चित्र की गुणवत्ता पुनः प्राप्त कर सकता हूँ?**

नहीं। संपीड़न संग्रहीत रास्टर रिज़ॉल्यूशन को घटा देता है, और क्रॉप किए गए क्षेत्रों को हटाने से चित्र डेटा नष्ट हो जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की आवश्यकता हो तो मूल स्रोत चित्र को प्रस्तुति के बाहर रखें।

**SVG चित्रों को कैसे संभालना चाहिए?**

जब वेक्टर फिडेलिटी महत्वपूर्ण हो तो SVG को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में निर्यात करने से SVG वेक्टर सामग्री पिक्सेल में रेंडर हो जाती है।

**मौजूदा स्लाइड पढ़ते समय असुरक्षित कास्ट से कैसे बचें?**

आकार प्रकार की जाँच करने के बाद ही पिक्चर‑फ़्रेम‑विशिष्ट सदस्य का उपयोग करें। `[shape] instanceof IPictureFrame` जाँच करने से अमान्य कास्ट से बचा जा सकता है और कोड को उन स्लाइडों को संभालने की सुविधा मिलती है जिनमें पिक्चर फ्रेम नहीं होते।