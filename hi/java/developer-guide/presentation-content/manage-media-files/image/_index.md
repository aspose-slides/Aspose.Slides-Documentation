---
title: Java का उपयोग करके प्रस्तुतियों में इमेज प्रबंधन को अनुकूलित करें
linktitle: इमेज प्रबंधन
type: docs
weight: 10
url: /hi/java/image/
keywords:
- इमेज जोड़ें
- पिक्चर जोड़ें
- इमेज बदलें
- इमेज कलेक्शन
- पिक्चर फ्रेम
- लिंक्ड इमेज
- बैकग्राउंड
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- SVG को शेप्स में बदलें
- बाहरी SVG संसाधन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG इमेज को जोड़ना, पुन: उपयोग करना, लिंक करना, बदलना और प्रबंधित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Java कई तरीकों से इमेज के साथ काम करने की सुविधाएँ प्रदान करता है, और प्रत्येक तरीका अलग उद्देश्य पूरा करता है। आप एक इमेज को प्रेजेंटेशन में संग्रहीत कर सकते हैं, उसे पिक्चर फ्रेम में प्रदर्शित कर सकते हैं, स्लाइड बैकग्राउंड के रूप में उपयोग कर सकते हैं, बाहरी इमेज से लिंक कर सकते हैं, साझा इमेज संसाधन को बदल सकते हैं, या SVG सामग्री को एडिटेबल शेप्स में परिवर्तित कर सकते हैं।

यह लेख इमेज संसाधनों और उनके प्रेजेंटेशन भर में उपयोग पर केंद्रित है। क्रॉपिंग, ट्रांसपैरेंसी, इफ़ेक्ट्स, स्ट्रेचिंग और व्यक्तिगत पिक्चर फ्रेम पर लागू अन्य फ़ॉर्मेटिंग के लिए देखें [Picture Frame](/slides/hi/java/picture-frame/)।

## **छवि मॉडल को समझें**

निम्नलिखित API अवधारणाएँ निकटता से संबंधित हैं लेकिन परस्पर बदलने योग्य नहीं हैं:

- The [प्रेजेंटेशन इमेज कलेक्शन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/) stores image resources used by the presentation. Use [ImageCollection.addImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imagecollection/) to add image data and obtain an [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) resource.
- A [picture frame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipictureframe/) is a shape that displays an image on a slide, layout, or master. Use [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) to place an image resource on a slide.
- A slide background uses an image as part of the slide fill rather than as a shape. It therefore does not behave like a picture frame.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) replaces an image resource. If several presentation elements use that resource, they all use the replacement.
- Converting an SVG to shapes creates editable slide shapes. After conversion, the content is no longer managed as one picture resource.

एक सामान्य वर्कफ़्लो इस प्रकार है: इमेज डेटा को इमेज कलेक्शन में जोड़ें, एक [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) प्राप्त करें, और फिर उस संसाधन का उपयोग एक या अधिक पिक्चर फ्रेम्स या फिल्स में करें।

## **एक एम्बेडेड इमेज जोड़ें**

स्थानीय इमेज डालने के लिए फ़ाइल लोड करें, इसे इमेज कलेक्शन में जोड़ें, और एक पिक्चर फ्रेम बनाएँ जो लौटाए गए `IPPImage` का उपयोग करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इस प्रकार जोड़ी गई इमेज प्रेजेंटेशन में एम्बेडेड होती है, इसलिए परिणामी फ़ाइल मूल इमेज फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से इमेज जोड़ें**

जब इमेज HTTP या HTTPS के माध्यम से उपलब्ध हो, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रेजेंटेशन इमेज कलेक्शन में जोड़ें, और लौटाए गए इमेज संसाधन का उसी तरह प्रयोग करें जैसा स्थानीय इमेज के लिए किया जाता है।

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

दीर्घकालिक एप्लिकेशन में अनावश्यक नेटवर्किंग इन्फ्रास्ट्रक्चर को बार‑बार बनाने के बजाय उपयुक्त HTTP क्लाइंट या कनेक्शन‑मैनेजमेंट रणनीति को पुनः उपयोग करें। साथ ही जब स्रोत विश्वसनीय न हो तो रिमोट URL, रिस्पॉन्स साइज और कंटेंट टाइप की जाँच करें।

## **स्लाइड्स में इमेज को पुन: उपयोग करें**

यदि एक ही इमेज को कई बार चाहिए, तो उसे प्रेजेंटेशन में एक बार जोड़ें और अतिरिक्त पिक्चर फ्रेम्स बनाते समय लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) को पुनः उपयोग करें। इससे समान स्रोत डेटा को बार‑बार लोड करने से बचाव होता है और साझा इमेज संसाधन व उसके उपयोगों का संबंध स्पष्ट हो जाता है।

कंपनी का लोगो जैसे ग्राफ़िक जो कई स्लाइड्स पर स्वचालित रूप से दिखना चाहिए, उन्हें प्रत्येक स्लाइड में समान आकार जोड़ने के बजाय [slide master](/slides/hi/java/slide-master/) या लेआउट पर पिक्चर फ्रेम रखकर जोड़ने पर विचार करें।

## **इमेज को स्लाइड बैकग्राउंड के रूप में उपयोग करें**

बैकग्राउंड इमेज स्लाइड फ़िल को असाइन की जाती है; इसे पिक्चर‑फ़्रेम शेप के रूप में नहीं जोड़ा जाता। यह तब उपयोगी होता है जब चित्र को स्लाइड बैकग्राउंड के रूप में कवर करना हो और उसे सामान्य स्लाइड ऑब्जेक्ट की तरह हेर‑फेर नहीं किया जाना चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अतिरिक्त बैकग्राउंड विकल्पों, जिसमें मास्टर और लेआउट बैकग्राउंड शामिल हैं, के लिए देखें [Presentation Background](/slides/hi/java/presentation-background/)।

## **एम्बेडेड इमेज और लिंक्ड इमेज**

एम्बेडेड और लिंक्ड इमेज की पोर्टेबिलिटी और फ़ाइल‑साइज़ में अलग‑अलग ट्रेड‑ऑफ़ होते हैं:

- **Embedded image:** इमेज डेटा प्रेजेंटेशन के भीतर संग्रहीत रहती है। प्रेजेंटेशन आत्म‑निर्भर रहता है, लेकिन फ़ाइल‑साइज़ में इमेज डेटा शामिल होता है।
- **Linked image:** प्रेजेंटेशन बाहरी इमेज का पाथ या URL संग्रहीत करता है। इससे प्रेजेंटेशन का आकार कम हो सकता है, लेकिन बाहरी संसाधन को खोलते या रेंडर करते समय उपलब्ध रहना चाहिए।

एक लिंक्ड पिक्चर को बाहरी पाथ या URL को [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidespicture/) के माध्यम से असाइन करके बनाया जा सकता है, बजाय इमेज डेटा को एम्बेड किए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल तब लिंक्ड इमेज उपयोग करें जब डिप्लॉयमेंट वातावरण बाहरी संसाधन तक विश्वसनीय रूप से पहुँच सके। उन प्रेजेंटेशन्स के लिए जो ऑफ़लाइन चलनी हों या विभिन्न सिस्टमों बीच ले जानी हों, एम्बेडेड इमेज आम तौर पर अधिक सुरक्षित रहती हैं।

## **SVG इमेज के साथ काम करें**

SVG एक वेक्टर फ़ॉर्मेट है, इसलिए यह आइकन, डायग्राम और अन्य ग्राफ़िक्स के लिए उपयोगी है जो रास्टर इमेज की तरह विवरण खोए बिना स्केल हो सकें। Aspose.Slides SVG को इमेज संसाधन दोनों रूपों में समर्थन करता है और संपादन योग्य स्लाइड शेप्स के स्रोत के रूप में भी।

### **एक SVG को इमेज के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) बनाएं, उसे इमेज कलेक्शन में जोड़ें, और परिणामी इमेज संसाधन को पिक्चर फ्रेम में रखें।

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **बाहरी संसाधनों के साथ SVG फ़ाइलें**

एक SVG बाहरी इमेज, स्टाइलशीट या फ़ॉन्ट को रेफ़र कर सकता है। इन मामलों के लिए, [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) ऐसे कन्स्ट्रक्टर प्रदान करता है जो एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iexternalresourceresolver/) और एक बेस URI को स्वीकार करता है। रिजॉल्वर एक रिलेटिव URI को अनुमति‑प्राप्त एब्सोल्यूट URI में मैप कर सकता है और अनुरोधित संसाधन के लिए एक स्ट्रीम लौटाता है।

रिजॉल्वर SVG को प्रोसेस करते समय बाहरी संसाधनों को उपलब्ध कराता है, लेकिन यह SVG को आत्म‑निर्भर दस्तावेज़ में पुनः‑लिखता नहीं है। यदि SVG को पोर्टेबल रहना आवश्यक है, तो आवश्यक संसाधनों को स्वयं SVG में एम्बेड करें, उदाहरण के लिये लिंक्ड इमेज के लिए `data:` URIs का उपयोग करें।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रिजॉल्वर द्वारा एक्सेस की जा सकने वाली स्कीम, फ़ाइल लोकेशन और होस्ट को प्रतिबंधित करें। नेटवर्क रिजॉल्वर को टाइम‑आउट, रिस्पॉन्स‑साइज़ लिमिट और कंटेंट वैलिडेशन भी लागू करना चाहिए।

### **SVG को एडिटेबल शेप्स में बदलें**

Aspose.Slides एक SVG को एडिटेबल स्लाइड शेप्स के समूह में परिवर्तित कर सकता है, जो संबंधित PowerPoint कमांड के समान है।

![PowerPoint Popup Menu](img_01_01.png)

परिवर्तन करने के लिए वह [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) ओवरलोड उपयोग करें जो एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) को स्वीकार करता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

व्यक्तिगत वेक्टर तत्वों को PowerPoint शेप्स की तरह संपादित करने की आवश्यकता होने पर SVG‑से‑शेप्स रूपांतरण उपयोग करें। यदि SVG केवल प्रदर्शित करने की आवश्यकता है, तो इसे इमेज के रूप में रखना सरल है और कई अलग‑अलग शेप्स बनाने से बचाता है।

## **मौजूदा इमेज संसाधन को बदलें**

जब आपको किसी मौजूदा इमेज संसाधन को बदलना हो तो [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) का उपयोग करें। यह साझा ग्राफ़िक्स जैसे लोगो के लिए विशेष रूप से उपयोगी है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यदि कई पिक्चर फ्रेम्स, बैकग्राउंड्स, मास्टर्स या लेआउट्स एक ही इमेज संसाधन का उपयोग करते हैं, तो उस संसाधन को बदलने से सभी उपयोग अपडेट हो जाएंगे। यदि केवल एक पिक्चर फ्रेम बदलना है, तो साझा संसाधन को बदलने के बजाय उस फ्रेम को अलग इमेज असाइन करें।

`replaceImage` बाइट एरे या अन्य [IPPImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) को स्वीकार करने वाले ओवरलोड भी प्रदान करता है।

## **व्यावहारिक इमेज प्रबंधन मार्गदर्शन**

### **प्रेजेंटेशन आकार नियंत्रित करें**

बड़ी रास्टर इमेज प्रेजेंटेशन को अनावश्यक रूप से बड़ा बना सकती हैं। उनके उद्देश्य के अनुसार उपयुक्त डायमेंशन वाली स्रोत इमेज उपयोग करें, जहाँ संभव हो साझा इमेज संसाधन को पुनः उपयोग करें, और एक ही हाई‑रेज़ॉल्यूशन ग्राफ़िक की कई प्रतियों को एम्बेड करने से बचें।

रास्टर चित्रों के लिए जो पहले से पिक्चर फ्रेम में रखे गए हैं, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipicturefillformat/) इमेज डेटा को चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग्स के अनुसार कम कर सकता है। यह पिक्चर‑फ़्रेम प्रोसेसिंग है, इमेज‑कलेक्शन मैनेजमेंट नहीं, इसलिए संबंधित फ़ॉर्मेटिंग ऑपरेशन के लिये देखें [Picture Frame](/slides/hi/java/picture-frame/)।

### **एम्बेडेड और लिंक्ड कंटेंट में से चुनें**

एम्बेडिंग प्रेजेंटेशन को पोर्टेबल बनाता है क्योंकि सभी आवश्यक इमेज डेटा फ़ाइल के साथ ही रहता है। लिंकिंग फ़ाइल‑साइज़ को घटा सकता है, परन्तु यह बाहरी निर्भरता जोड़ता है। लिंक केवल तब उपयोग करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **शेयर किए गए ब्रांडिंग को पुन: उपयोग करें**

बार‑बार उपयोग होने वाले लोगो, वॉटरमार्क या सजावटी ग्राफ़िक्स के लिये एक ही इमेज संसाधन बनाकर उसे पुनः उपयोग करें। यदि ग्राफ़िक प्रेजेंटेशन डिज़ाइन का हिस्सा है न कि स्लाइड कंटेंट, तो उसे मास्टर या लेआउट पर रखें ताकि संबंधित स्लाइड्स में स्वतः विरासत में मिल सके।

### **SVG संसाधनों को पोर्टेबल रखें**

एक आत्म‑निर्भर SVG को ले जाना और लगातार रेंडर करना बाहरी फ़ाइल या नेटवर्क संसाधनों पर निर्भर SVG की तुलना में आसान होता है। जहाँ संभव हो, इम्पोर्ट करने से पहले आवश्यक संसाधनों को एम्बेड करें। केवल तब ही SVG को शेप्स में बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करने की आवश्यकता हो।

### **आधुनिक क्रॉस‑प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए Java कोड के लिये Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/java/com.aspose.slides/images/) API का उपयोग करें, बजाय पुराने सार्वजनिक API के जो `java.awt.image.BufferedImage` पर आधारित है। माइग्रेशन गाइडेंस के लिये देखें [Modern API](/slides/hi/java/modern-api/)।

WMF और EMF को विशेष ध्यान की आवश्यकता होती है। जब इन फ़ॉर्मेट्स को एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) के माध्यम से पास किया जाता है, तो [ImageCollection.addImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imagecollection/) फ़ाइल को डालने से पहले मेटाफ़ाइल को रास्टर PNG प्रतिनिधित्व में परिवर्तित करता है। यदि मेटाफ़ाइल डेटा को संरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम‑आधारित [ImageCollection.addImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imagecollection/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री उत्पन्न करना एक अलग इंटीग्रेशन वर्कफ़्लो है और इस लेख के दायरे में नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**इमेज कलेक्शन और पिक्चर फ्रेम में क्या अंतर है?**

इमेज कलेक्शन पुन: उपयोग योग्य इमेज संसाधन संग्रहीत करता है। पिक्चर फ्रेम एक स्लाइड शेप है जो उन संसाधनों में से एक को प्रदर्शित करता है और क्रॉपिंग, इफ़ेक्ट्स आदि जैसी पिक्चर‑विशेष फ़ॉर्मेटिंग प्रदान करता है।

**सभी जगह एक ही लोगो को बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से एक इमेज संसाधन के रूप में साझा किया गया है, तो उस संसाधन को [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ippimage/) से बदलें। प्रेजेंटेशन‑व्यापी ब्रांडिंग के लिये लोगो को मास्टर या लेआउट पर रखना भी डुप्लिकेटेड स्लाइड कंटेंट को कम कर सकता है।

**लिंक्ड इमेज दूसरे कंप्यूटर पर क्यों गायब हो जाती है?**

लिंक्ड पिक्चर का निर्भरता बाहरी फ़ाइल या URL पर होती है। यदि वह स्रोत उस अन्य कंप्यूटर से पहुँचा नहीं जा सकता, तो लिंक्ड इमेज उपलब्ध नहीं होगी। जब प्रेजेंटेशन को आत्म‑निर्भर होना जरूरी हो तब इमेज को एम्बेड करें।

**क्या डाली गई SVG को PowerPoint शेप्स की तरह संपादित किया जा सकता है?**

हां। SVG को [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/) से बदलें; resulting group में एडिटेबल स्लाइड शेप्स होते हैं, न कि एकल SVG पिक्चर।

**बहुत सारी इमेज वाली प्रेजेंटेशन्स को कैसे छोटा रखें?**

शेयर किए गए इमेज संसाधनों को पुनः उपयोग करें, अनावश्यक रूप से बड़ी रास्टर स्रोतों से बचें, उपयुक्त समय पर रास्टर चित्रों को कम्प्रेस करें, ब्रांडिंग को मास्टर या लेआउट पर रखें, और केवल तभी लिंक्ड इमेज उपयोग करें जब बाहरी निर्भरता स्वीकार्य हो।