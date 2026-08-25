---
title: Android में प्रस्तुतियों में पिक्चर फ्रेम का प्रबंधन
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/androidjava/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड इमेज
- लिंकटेड इमेज
- इमेज निकालें
- रास्टर इमेज
- SVG इमेज
- इमेज क्रॉप करें
- क्रॉप्ड एरिया हटाएं
- इमेज संकुचित करें
- StretchOffset
- पिक्चर फ्रेम फॉर्मेटिंग
- रिलेटिव स्केल
- इमेज इफ़ेक्ट
- आस्पेक्ट रेशियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके प्रस्तुतियों में पिक्चर फ्रेम बनाएं, फॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संकुचित करें।"
---
## **अवलोकन**

एक पिक्चर फ्रेम एक स्लाइड शेप है जो छवि को प्रदर्शित करता है। Aspose.Slides में, छवि रिसोर्स और उसे प्रदर्शित करने वाला शेप अलग-अलग ऑब्जेक्ट होते हैं: एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) अपनी [IImageCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/) के माध्यम से एम्बेडेड इमेज रिसोर्सेज़ को रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) छवि की पोज़िशन, आकार, लाइन फॉर्मेटिंग, रोटेशन, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑लेवल सेटिंग्स को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही छवि को एक से अधिक बार दिखाया जाता है। प्रस्तुति में छवि को एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) को रखें, और पिक्चर फ्रेम्स बनाने के समय उसी इमेज रिसोर्स का उपयोग करें।

पिक्चर फ्रेम्स PNG या JPEG जैसी रास्टर इमेज तथा SVG जैसी वेक्टर इमेज दोनों को समाहित कर सकते हैं। वे लिंकटेड इमेजेज़ को भी संदर्भित कर सकते हैं बजाय प्रस्तुति में छवि बाइट्स को स्टोर करने के। यह विकल्प पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि इमेज को कैसे स्टोर किया जाए।

## **एम्बेडेड इमेज जोड़ें और फॉर्मेट करें**

एक एम्बेडेड इमेज के लिए, इमेज डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) का उपयोग करके पिक्चर फ्रेम बनाएं। इमेज प्रस्तुति पैकेज का हिस्सा बन जाती है, इसलिए प्रस्तुति को किसी अन्य कंप्यूटर पर ले जाने पर भी वह स्वनिर्भर रहती है।

निम्न उदाहरण JPEG इमेज जोड़ता है, इमेज के मूल आयामों पर एक फ्रेम बनाता है, और लाइन फॉर्मेटिंग व रोटेशन लागू करता है:

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

पिक्चर फ्रेम प्रदर्शित ज्योमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड इमेज रिसोर्स में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में इमेज को क्रॉप या कम्प्रेस करने पर महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) फ्रेम के लिए रिलेटिव width और height स्केलिंग प्रदान करता है, जिसे आप [setRelativeScaleWidth](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) और [setRelativeScaleHeight](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-) द्वारा सेट कर सकते हैं। `1.0` का मान मूल पिक्चर आकार का 100 % दर्शाता है। रिलेटिव स्केल तब उपयोगी होता है जब कार्यप्रवाह को स्रोत इमेज आकार के अनुपात को बनाए रखना हो, बजाय अंतिम आयामों की मैन्युअल गणना के।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड इमेज को री‑सैंपल या कम्प्रेस नहीं करता।

## **एम्बेडेड और लिंकटेड इमेजेज़**

एक एम्बेडेड पिक्चर इमेज डेटा को प्रस्तुति के भीतर संग्रहीत करता है और इसलिए पोर्टेबिलिटी तथा पूर्वाभासित रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंकटेड पिक्चर [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) मेथड के माध्यम से बाहरी स्थान को संदर्भित करता है, न कि इमेज डेटा को एम्बेड करता है।

लिंकटेड इमेजेज़ PPTX में संग्रहीत इमेज डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक किया गया फ़ाइल उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रस्तुति को खोलता या रेंडर करता है। यदि पाथ बदल जाता है, फ़ाइल स्थानांतरित हो जाती है, या रिसोर्स उपलब्ध नहीं रहता, तो लिंकटेड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रस्तुतियों के लिए जो ई‑मेल, अभिलेख या अलग‑थलग वातावरण में रेंडर की जानी हैं, एम्बेडेड इमेजेज़ आमतौर पर अधिक भरोसेमंद होते हैं।

### **लिंकटेड इमेज जोड़ें**

निम्न उदाहरण एक पिक्चर फ्रेम बनाता है और उसे स्थानीय इमेज फ़ाइल से लिंक करता है। यह केवल इमेज लिंकिंग को दिखाता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इरादतन इस उदाहरण में नहीं जोड़ा गया है।

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

बाहरी फ़ाइल प्रबंधन इरादतन होने पर लिंक का उपयोग करें। उन्हें केवल कम्प्रेशन के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज निर्भरताओं वाला छोटा PPTX अक्सर बड़े स्वनिर्भर प्रस्तुति की तुलना में कम उपयोगी होता है।

## **पिक्चर फ्रेम से इमेज निकालें**

किसी मौजूदा प्रस्तुति से इमेज निकालने से पहले जाँचें कि शेप वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) है और उसमें एम्बेडेड इमेज मौजूद है। लिंकटेड पिक्चर फ्रेम्स में उन इमेज बाइट्स नहीं हो सकते जिन्हें समान तरीके से निकाला जा सके।

### **रास्टर इमेज निकालें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) का उपयोग करता है और पुराने जावा इमेज रैपर की आवश्यकता नहीं होती। निम्न उदाहरण स्लाइड पर पहला एम्बेडेड रास्टर पिक्चर खोजता है और उसे PNG के रूप में सहेजता है:

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

[IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) के माध्यम से सहेजना निकाली गई इमेज को वांछित आउटपुट फ़ॉर्मेट में परिवर्तित कर देता है। यदि आपको प्रस्तुति में संग्रहीत एन्कोडेड बाइट्स चाहिए, तो इमेज रिसोर्स के बाइनरी डेटा का उपयोग करें, न कि परिवर्तित रास्टर फ़ाइल का।

### **SVG इमेज निकालें**

SVG पिक्चर के लिए, [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट एक्सपोज़ करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बजाय पिक्चर को पहले रास्टराइज़ करने के।

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

SVG सामग्री को SVG के रूप में रखना वेक्टर स्रोत को प्रस्तुति के भीतर संरक्षित करता है। PNG या JPEG जैसी रास्टर एक्सपोर्ट्स को वेक्टर सामग्री को पिक्सेल में रेंडर करना पड़ता है। PDF या SVG स्लाइड एक्सपोर्ट भी एक रेंडरिंग ऑपरेशन है, इसलिए एक्सपोर्टेड ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर रिसोर्स स्वयं आवश्यक हो, तब एम्बेडेड [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/#getSvgData--) डेटा का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के किस भाग को दिखाया जाएगा, इसे बदलती है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर क्रॉप वैल्यूज़ स्रोत इमेज आयामों के प्रतिशत के रूप में होती हैं। क्रॉपिंग प्रारम्भ में एम्बेडेड इमेज से छुपे पिक्सल्स को नहीं हटाती; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण एक पिक्चर फ्रेम को सुरक्षित रूप से खोजता है और क्रॉप वैल्यूज़ लागू करता है:

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

क्योंकि छुपा इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में बिना मूल पिक्सल्स खोए बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्त्वपूर्ण है और पुनःसंपादन की आवश्यकता नहीं है, तो अगले खंड में वर्णित अनुसार क्रॉप्ड क्षेत्र को स्थायी रूप से हटाया जा सकता है।

## **क्रॉप्ड इमेज डेटा हटाएँ**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) वर्तमान क्रॉप रेक्टेंगल के बाहर की इमेज डेटा को हटाता है और resulting इमेज रिसोर्स को वापस देता है। यह फ़ाइल आकार कम कर सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रस्तुति सहेज लेने के बाद हटाए गए पिक्सल्स को बाद की अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

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

यह मेथड प्रस्तुति में एक नया इमेज रिसोर्स जोड़ सकता है। यदि मूल इमेज को अन्य पिक्चर फ्रेम्स भी उपयोग कर रहे हैं, तो उन फ्रेम्स को अभी भी अपना मौजूदा रिसोर्स चाहिए होगा, इसलिए क्रॉप्ड क्षेत्रों को हटाने से कुल इमेज संख्या आवश्यक रूप से कम नहीं होती। WMF या EMF सामग्री को इस मेथड से क्रॉप करने से क्रॉप्ड परिणाम PNG में रैस्टराइज़ हो जाता है।

## **रास्टर इमेज को संकुचित करें**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) रास्टर इमेज का रिज़ॉल्यूशन उस आकार के सापेक्ष घटाता है जिस पर पिक्चर प्रदर्शित होता है। यह वही ऑपरेशन में क्रॉप्ड रीज़न को भी हटा सकता है। मेथड तब `true` लौटाता है जब इमेज री‑साइज़ या क्रॉप हुई हो और `false` जब कोई परिवर्तन आवश्यक न हो।

जब मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो, तो एक प्री‑डिफाइंड [PicturesCompression](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/picturescompression/) वैल्यू का उपयोग करें:

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

यदि विशिष्ट लक्ष्य चाहिए, तो प्री‑डिफाइंड वैल्यू के बजाय कस्टम पॉज़िटिव DPI मान पास किया जा सकता है।

संकुचन रास्टर इमेज के लिए ही अभिप्रेत है। SVG और मेटा‑फ़ाइल सामग्री इस रास्टर संकुचन वर्कफ़्लो द्वारा नहीं घटती। साथ ही याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड रीज़न को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस सबसे बड़े आकार के आधार पर चुनें जिस पर इमेज वास्तविक रूप से देखी या एक्सपोर्ट की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करने से।

## **इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को प्रबंधित करें**

ब्राइटनेस, कॉन्ट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफ़ेक्ट्स, ऑर्डर्ड चेन्स, इंस्पेक्शन, रिमूवल तथा राउंड‑ट्रिप वैरिफ़िकेशन सहित पूर्ण वर्कफ़्लो के लिए देखें [Image Transform Effects](/androidjava/image-transform-effects/)।

## **पिक्चर फ्रेम ज्योमेट्री को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम पर कौन‑सी एडिटिंग ऑपरेशन अक्षम हैं। उदाहरण के लिए, [setAspectRatioLocked](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) आकार बदलते समय शेप के अनुपात को बनाए रखता है।

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

लॉक पिक्चर फ्रेम शेप पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से समान अनुपात में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset मानों को एडजस्ट करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) पर stretch‑offset मान पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष फ़िल रेक्टेंगल को परिभाषित करते हैं। पॉज़िटिव प्रतिशत किनारे से इनसेट बनाते हैं, जबकि नेगेटिव प्रतिशत आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप वैल्यूज़ स्रोत इमेज के किस भाग को दृश्यमान किया जाए, चुनती हैं; स्ट्रेच ऑफ़सेट दृश्य पिक्चर फ़िल को स्ट्रेच किए जाने वाले रेक्टेंगल को बदलते हैं।

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

फ़िल प्लेसमेंट के लिए स्ट्रेच ऑफ़सेट का उपयोग करें। स्रोत‑इमेज किनारों को छुपाने के लक्ष्य के लिए क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार और एक्सपोर्ट विचार**

मुख्य ट्रेड‑ऑफ़्स को अधिक आसानी से प्रबंधित किया जा सकता है जब इमेज स्टोरेज और पिक्चर‑फ़्रेम फॉर्मेटिंग को अलग‑अलग माना जाए:

- **एम्बेडेड इमेजेज़** प्रस्तुति को स्वनिर्भर बनाते हैं और साझा करने व सर्वर‑साइड रेंडरिंग के लिए सबसे भरोसेमंद होते हैं, पर बड़े रास्टर इमेजेज़ PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **लिंकटेड इमेजेज़** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों की उपलब्धता पर निर्भर बनाते हैं।
- **क्रॉपिंग** प्रारम्भ में नॉन‑डिस्ट्रक्टिव होती है। छुपे पिक्सल्स तब तक एम्बेडेड रहते हैं जब तक क्रॉप्ड एरिया स्पष्ट रूप से नहीं हटाए जाते या संकुचन के दौरान नहीं हटाए जाते।
- **कम्प्रेशन** अत्यधिक बड़े रास्टर इमेजेज़ के फ़ाइल आकार को उल्लेखनीय रूप से घटा सकता है, पर यह स्रोत रिज़ॉल्यूशन का त्याग करता है। इसे ऑन‑स्लाइड आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG इमेजेज़** वेक्टर संरक्षण आवश्यक होने पर SVG के रूप में ही रखे जाने चाहिए। जब आपको स्वयं वेक्टर रिसोर्स चाहिए, तो एम्बेडेड SVG को सीधे निकालें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर किए गए स्लाइड को पिक्सेल में बदलता है।
- **दोहराई गई इमेजेज़** संभव हो तो एक मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) रिसोर्स को पुनः उपयोग करें, बजाय बार‑बार एक ही फ़ाइल को प्रस्तुति वर्कफ़्लो में लोड करने के।

बड़ी प्रस्तुतियों के लिए इमेज ऑप्टिमाइज़ेशन आमतौर पर तब सबसे प्रभावी होता है जब चयनात्मक रूप से किया जाए: लोगो और डायग्राम को वेक्टर कंटेंट के रूप में रखें, फ़ोटोग्राफ़ को उनके वास्तविक डिस्प्ले आकार के अनुसार संकुचित करें, क्रॉप्ड पिक्सल्स को केवल तब हटाएँ जब बाद के संपादन की आवश्यकता न हो, और बाहरी लिंक से बचें जब तक कि डिपेंडेंसी मैनेजमेंट डिप्लॉयमेंट डिज़ाइन का हिस्सा न हो।

## **FAQ**

**पिक्चर फ्रेम और इमेज रिसोर्स में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) प्रस्तुति से जुड़ा इमेज रिसोर्स दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) स्लाइड पर वह शेप है जो इमेज प्रदर्शित करता है और फ्रेम‑लेवल ज्योमेट्री तथा फॉर्मेटिंग जैसे आकार, रोटेशन, क्रॉप वैल्यूज़, इफ़ेक्ट्स और लॉक को स्टोर करता है।

**मुझे इमेजेज़ एम्बेड करनी चाहिए या लिंक?**

जब प्रस्तुति को पोर्टेबल, अभिलेखित या बिना बाहरी रिसोर्सेज़ के रेंडर करना हो, तब इमेजेज़ को एम्बेड करें। केवल तब लिंक करें जब इमेज फ़ाइलों को PPTX के बाहर रखना इरादतन हो और बाहरी स्थानों को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग PPTX फ़ाइल आकार कम करती है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के भाग को छुपाती हैं लेकिन अंतर्निहित पिक्सल्स को बरकरार रखती हैं। जब उन पिक्सल्स को स्थायी रूप से हटाया जा सके, तब [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) या क्रॉप्ड‑एरिया हटाने के साथ इमेज कम्प्रेशन का उपयोग करके फ़ाइल आकार घटाया जा सकता है।

**क्या मैं कम्प्रेशन के बाद इमेज क्वालिटी बहाल कर सकता हूँ?**

नहीं। कम्प्रेशन संग्रहीत रास्टर रिज़ॉल्यूशन को घटा देता है, और क्रॉप्ड रीज़न को हटाने से इमेज डेटा हट जाता है। यदि बाद में उच्च‑रिज़ॉल्यूशन संपादन की संभावना हो, तो मूल स्रोत इमेज को प्रस्तुति के बाहर रखें।

**SVG इमेजेज़ को कैसे संभालना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो, तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) को सीधे निकाला जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में एक्सपोर्ट करने से SVG रेंडर होकर पिक्सेल में बदल जाता है।

**मौजूदा स्लाइड्स पढ़ते समय असुरक्षित कैस्ट से कैसे बचें?**

शेप टाइप की जाँच करें और फिर पिक्चर‑फ़्रेम‑स्पेसिफ़िक मेम्बर का उपयोग करें। [IPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) के विरुद्ध `instanceof` जांच असमान कैस्ट से बचाती है और कोड को उन स्लाइड्स को संभालने देती है जिनमें पिक्चर फ्रेम नहीं होते।