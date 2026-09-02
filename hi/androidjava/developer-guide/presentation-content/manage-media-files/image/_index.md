---
title: "Android पर प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/androidjava/image/
keywords:
  - "छवि जोड़ें"
  - "चित्र जोड़ें"
  - "छवि बदलें"
  - "छवि संग्रह"
  - "चित्र फ्रेम"
  - "लिंक्ड छवि"
  - "पृष्ठभूमि"
  - "PNG जोड़ें"
  - "JPG जोड़ें"
  - "SVG जोड़ें"
  - "SVG को आकारों में बदलें"
  - "बाहरी SVG संसाधन"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रस्तुति"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में रास्टर और SVG छवियों को जोड़ना, पुन: उपयोग करना, लिंक करना, बदलना और प्रबंधित करना सीखें।"
---
## **परिचय**

Aspose.Slides for Android via Java छवियों के साथ काम करने के कई तरीके प्रदान करता है, और प्रत्येक का अलग उद्देश्य है। आप एक प्रस्तुति में छवि संग्रहीत कर सकते हैं, इसे चित्र फ्रेम में प्रदर्शित कर सकते हैं, इसे स्लाइड पृष्ठभूमि के रूप में उपयोग कर सकते हैं, बाहरी छवि से लिंक कर सकते हैं, साझा छवि संसाधन को बदल सकते हैं, या SVG सामग्री को संपादन योग्य आकारों में परिवर्तित कर सकते हैं।

यह लेख छवि संसाधनों और उनके प्रस्तुति में उपयोग पर केंद्रित है। व्यक्तिगत चित्र फ्रेम पर लागू क्रॉपिंग, पारदर्शिता, प्रभाव, स्ट्रेचिंग और अन्य स्वरूपण के लिए, देखें [चित्र फ्रेम](/slides/hi/androidjava/picture-frame/)।

## **छवि मॉडल को समझें**

- The [presentation image collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/) प्रस्तुति द्वारा उपयोग किए जाने वाले छवि संसाधनों को संग्रहीत करता है। छवि डेटा जोड़ने और एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) संसाधन प्राप्त करने के लिए [ImageCollection.addImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imagecollection/) का उपयोग करें।
- A [picture frame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipictureframe/) एक आकार है जो स्लाइड, लेआउट या मास्टर पर छवि प्रदर्शित करता है। स्लाइड पर एक छवि संसाधन रखने के लिए [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) का उपयोग करें।
- एक स्लाइड पृष्ठभूमि छवि को स्लाइड फाइल का भाग के रूप में उपयोग करती है, न कि एक आकार के रूप में। इसलिए यह चित्र फ्रेम जैसा व्यवहार नहीं करता।
- [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) एक छवि संसाधन को बदलता है। यदि कई प्रस्तुति तत्व उस संसाधन का उपयोग करते हैं, तो वे सभी प्रतिस्थापन का उपयोग करेंगे।
- SVG को आकारों में बदलने से संपादन योग्य स्लाइड आकार बनते हैं। परिवर्तन के बाद, सामग्री अब एक ही चित्र संसाधन के रूप में प्रबंधित नहीं होती।

इसलिए एक सामान्य कार्यप्रवाह इस प्रकार है: छवि डेटा को छवि संग्रह में जोड़ें, एक [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) प्राप्त करें, और फिर उस संसाधन का उपयोग एक या अधिक चित्र फ्रेम या फाइल में करें।

## **एम्बेडेड छवि जोड़ें**

स्थानीय छवि डालने के लिए, फ़ाइल लोड करें, इसे छवि संग्रह में जोड़ें, और एक चित्र फ्रेम बनाएँ जो लौटाए गए `IPPImage` का उपयोग करता है।

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

इस प्रकार जोड़ी गई छवि प्रस्तुति में एम्बेडेड होती है, इसलिए परिणामी फ़ाइल मूल छवि फ़ाइल की उपलब्धता पर निर्भर नहीं करती।

### **वेब से छवि जोड़ें**

जब कोई छवि HTTP या HTTPS के माध्यम से उपलब्ध होती है, तो उसके बाइट्स डाउनलोड करें, उन्हें प्रस्तुति छवि संग्रह में जोड़ें, और लौटाए गए छवि संसाधन का उपयोग स्थानीय छवि की तरह ही करें।

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

लंबी अवधि चलने वाले अनुप्रयोगों में, अनुप्रयोग के अनुरूप HTTP क्लाइंट या कनेक्शन-प्रबंधन रणनीति को पुनः उपयोग करें बजाय बार-बार अनावश्यक नेटवर्किंग इन्फ्रास्ट्रक्चर बनाने के। साथ ही जब स्रोत विश्वसनीय न हो तो रिमोट URL, प्रतिक्रिया आकार और सामग्री प्रकार की पुष्टि करें।

## **स्लाइड्स के बीच छवियों का पुन: उपयोग**

यदि एक ही छवि कई बार चाहिए, तो उसे प्रस्तुति में एक बार जोड़ें और अतिरिक्त चित्र फ्रेम बनाते समय लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) का पुनः उपयोग करें। इससे एक ही स्रोत डेटा को बार-बार लोड करने से बचा जा सकता है और साझा छवि संसाधन और उसके उपयोगों के बीच संबंध स्पष्ट हो जाता है।

ऐसे ग्राफिक्स के लिए जो कई स्लाइड्स पर स्वचालित रूप से दिखने चाहिए, जैसे कंपनी लोगो, प्रत्येक स्लाइड में समान आकार जोड़ने के बजाय एक [स्लाइड मास्टर](/slides/hi/androidjava/slide-master/) या लेआउट पर चित्र फ्रेम रखने पर विचार करें।

## **छवि को स्लाइड पृष्ठभूमि के रूप में उपयोग करें**

पृष्ठभूमि छवि स्लाइड फाइल को सौंपी जाती है; इसे चित्र-फ़्रेम आकार के रूप में नहीं जोड़ा जाता। यह तब उपयोगी है जब चित्र को स्लाइड पृष्ठभूमि को कवर करना चाहिए और इसे सामान्य स्लाइड ऑब्जेक्ट की तरह नहीं बदला जाना चाहिए।

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

अतिरिक्त पृष्ठभूमि विकल्पों के लिए, जिसमें मास्टर और लेआउट पृष्ठभूमि शामिल हैं, देखें [प्रस्तुति पृष्ठभूमि](/slides/hi/androidjava/presentation-background/)।

## **एम्बेडेड छवियां और लिंक्ड छवियां**

एम्बेडेड और लिंक्ड छवियों में पोर्टेबिलिटी और फ़ाइल आकार के विभिन्न समझौते होते हैं:

- **एम्बेडेड छवि:** छवि डेटा प्रस्तुति के अंदर संग्रहीत रहता है। प्रस्तुति स्व-निहित होती है, लेकिन फ़ाइल आकार में छवि डेटा शामिल होता है।
- **लिंक्ड छवि:** प्रस्तुति एक बाहरी छवि का पथ या URL संग्रहीत करती है। इससे प्रस्तुति आकार कम हो सकता है, लेकिन प्रस्तुति खोलने या रेंडर करने पर बाहरी संसाधन सुलभ रहना चाहिए।

एक लिंक्ड चित्र को बाहरी पथ या URL को [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidespicture/) द्वारा असाइन करके बनाया जा सकता है, बजाय छवि डेटा एम्बेड करने के।

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

लिंक्ड छवियों का उपयोग केवल तभी करें जब डिप्लॉयमेंट पर्यावरण बाहरी संसाधन तक विश्वसनीय रूप से पहुंच सके। उन प्रस्तुतियों के लिए जो ऑफ़लाइन कार्य करना चाहिए या सिस्टमों के बीच स्थानांतरित होनी चाहिए, एम्बेडेड छवियां आमतौर पर सुरक्षित होती हैं।

## **SVG छवियों के साथ काम करें**

SVG एक वेक्टर फ़ॉर्मेट है, इसलिए यह आइकन्स, डायग्राम और अन्य ग्राफिक्स के लिए उपयोगी हो सकता है जिन्हें रास्टर छवियों की तरह विवरण की हानि के बिना स्केल किया जा सके। Aspose.Slides SVG को छवि संसाधन और संपादन योग्य स्लाइड आकारों के स्रोत दोनों के रूप में समर्थन करता है।

### **SVG को छवि के रूप में जोड़ें**

एक [SvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgimage/) बनाएं, इसे छवि संग्रह में जोड़ें, और परिणामी छवि संसाधन को एक चित्र फ्रेम में रखें।

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

### **बाहरी संसाधनों वाली SVG फ़ाइलें**

एक SVG बाहरी छवियों, स्टाइलशीट या फ़ॉन्ट्स को संदर्भित कर सकता है। इन मामलों के लिए, [SvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgimage/) ऐसे कंस्ट्रक्टर प्रदान करता है जो एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iexternalresourceresolver/) और एक बेस URI को स्वीकार करता है। रिजॉल्वर एक रिलेटिव URI को अनुमत एब्सॉल्यूट URI में मैप कर सकता है और अनुरोधित संसाधन के लिए एक स्ट्रीम लौटाता है।

रिजॉल्वर Aspose.Slides के SVG प्रक्रिया करने के दौरान बाहरी संसाधनों को उपलब्ध कराता है, लेकिन यह SVG को एक स्व-निहित दस्तावेज़ में नहीं बदलता। यदि SVG को पोर्टेबल रहना आवश्यक है, तो आवश्यक संसाधनों को SVG के भीतर एम्बेड करें, उदाहरण के लिए लिंक्ड छवियों के लिए `data:` URI का उपयोग करके।

जब SVG फ़ाइलें अविश्वसनीय स्रोतों से आती हैं, तो रिजॉल्वर द्वारा पहुंची जा सकने वाली स्कीम, फ़ाइल स्थान और होस्ट को सीमित करें। नेटवर्क रिजॉल्वर को टाइमआउट, प्रतिक्रिया आकार सीमाएं और सामग्री सत्यापन भी लागू करना चाहिए।

### **SVG को संपादन योग्य आकारों में परिवर्तित करें**

Aspose.Slides SVG को संपादन योग्य स्लाइड आकारों के समूह में परिवर्तित कर सकता है, जो संबंधित PowerPoint कमांड के समान है।

![PowerPoint पॉपअप मेनू](img_01_01.png)

परिवर्तन करने के लिए वह [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) ओवरलोड उपयोग करें जो एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) को स्वीकार करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

जब व्यक्तिगत वेक्टर तत्वों को PowerPoint आकारों के रूप में संपादित करने की आवश्यकता हो तो SVG-से-आकार परिवर्तन का उपयोग करें। यदि केवल SVG को प्रदर्शित करने की जरूरत है, तो इसे छवि के रूप में रखना सरल है और कई अलग आकार बनाना टालता है।

## **मौजूदा छवि संसाधन को बदलें**

जब आप मौजूदा छवि संसाधन को बदलना चाहते हैं तो [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) का उपयोग करें। यह विशेष रूप से लोगो जैसी साझा ग्राफिक्स के लिए उपयोगी है।

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

यदि कई चित्र फ्रेम, पृष्ठभूमि, मास्टर या लेआउट एक ही छवि संसाधन का उपयोग करते हैं, तो उस संसाधन को बदलने से सभी उपयोग अद्यतन होते हैं। यदि केवल एक चित्र फ्रेम बदलना है, तो साझा संसाधन को बदलने के बजाय उस फ्रेम को अलग छवि असाइन करें।

`replaceImage` ऐसे ओवरलोड भी प्रदान करता है जो बाइट एरे या किसी अन्य [IPPImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) को स्वीकार करता है।

## **व्यावहारिक छवि प्रबंधन मार्गदर्शन**

### **प्रस्तुति आकार नियंत्रित करें**

बड़ी रास्टर छवियों से प्रस्तुति अनावश्यक रूप से बड़ी हो सकती है। स्रोत छवियों को उनके इच्छित प्रदर्शन आकार के अनुसार आयाम के साथ उपयोग करें, जहां संभव हो साझा छवि संसाधनों को पुनः उपयोग करें, और समान पूर्ण-रिज़ॉल्यूशन ग्राफिक की दोहराई गई प्रतियों को एम्बेड करने से बचें।

उन रास्टर चित्रों के लिए जो पहले से ही चित्र फ्रेम में रखे जा चुके हैं, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipicturefillformat/) चयनित रिज़ॉल्यूशन और क्रॉप सेटिंग्स के अनुसार छवि डेटा को कम कर सकता है। यह चित्र-फ़्रेम प्रोसेसिंग है, न कि छवि-संग्रह प्रबंधन, इसलिए संबंधित स्वरूपण कार्यों के लिए देखें [चित्र फ्रेम](/slides/hi/androidjava/picture-frame/)।

### **एंबेडेड और लिंक्ड सामग्री में से चुनें**

एम्बेडिंग प्रस्तुति को पोर्टेबल बनाता है क्योंकि सभी आवश्यक छवि डेटा फ़ाइल के साथ यात्रा करता है। लिंकिंग फ़ाइल आकार को कम कर सकता है, लेकिन यह बाहरी निर्भरता लाता है। लिंक का उपयोग तभी करें जब वह निर्भरता स्वीकार्य और स्थिर हो।

### **साझा ब्रांडिंग का पुन: उपयोग करें**

दोहराए गए लोगो, वॉटरमार्क या सजावटी ग्राफिक्स के लिए एक ही छवि संसाधन का उपयोग करें और उसे पुनः उपयोग करें। यदि ग्राफिक स्लाइड सामग्री के बजाय प्रस्तुति डिजाइन का हिस्सा है, तो उसे मास्टर या लेआउट पर रखें ताकि वह उपयुक्त स्लाइड्स द्वारा विरासत में मिले।

### **SVG संसाधनों को पोर्टेबल रखें**

एक स्व-निहित SVG को स्थानांतरित करने और लगातार रेंडर करने में अधिक सुविधा होती है बनिस्बत उस SVG के जो बाहरी फ़ाइलों या नेटवर्क संसाधनों पर निर्भर करता है। जब संभव हो, SVG आयात करने से पहले आवश्यक संसाधनों को एम्बेड करें। केवल तब SVG को आकारों में बदलें जब व्यक्तिगत वेक्टर तत्वों को संपादित करना आवश्यक हो।

### **आधुनिक क्रॉस-प्लेटफ़ॉर्म इमेज API का उपयोग करें**

नए Android via Java कोड के लिए, लेगेसी सार्वजनिक API जो `android.graphics.Bitmap` पर आधारित है, उसके बजाय Aspose.Slides के [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) और [Images](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/images/) APIs का उपयोग करें। माइग्रेशन मार्गदर्शन के लिए देखें [आधुनिक API](/slides/hi/androidjava/modern-api/)।

WMF और EMF को विशेष विचार की आवश्यकता होती है। जब इन प्रारूपों को एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) के माध्यम से पास किया जाता है, तो [ImageCollection.addImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imagecollection/) मेटा फ़ाइल को डालने से पहले रास्टर PNG प्रतिनिधित्व में बदल देता है। यदि मेटा फ़ाइल डेटा को सुरक्षित रखना महत्वपूर्ण है, तो स्ट्रीम-आधारित [ImageCollection.addImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imagecollection/) ओवरलोड का उपयोग करें। स्प्रेडशीट या अन्य उत्पादों से EMF सामग्री बनाना एक अलग एकीकरण कार्यप्रवाह है और इस लेख के दायरे से बाहर है।

## **अक्सर पूछे जाने वाले प्रश्न**

**छवि संग्रह और चित्र फ्रेम में क्या अंतर है?**

छवि संग्रह पुन: उपयोग योग्य छवि संसाधनों को संग्रहीत करता है। एक चित्र फ्रेम एक स्लाइड आकार है जो उन संसाधनों में से एक को प्रदर्शित करता है और क्रॉपिंग व प्रभाव जैसे चित्र-विशिष्ट स्वरूपण प्रदान करता है।

**सभी स्थानों पर एक ही लोगो को बदलने का सबसे अच्छा तरीका क्या है?**

यदि लोगो पहले से ही एक छवि संसाधन के रूप में साझा किया गया है, तो उस संसाधन को [IPPImage.replaceImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ippimage/) से बदलें। प्रस्तुति-व्यापी ब्रांडिंग के लिए, लोगो को मास्टर या लेआउट पर रखने से दोहराए गए स्लाइड कंटेंट को कम किया जा सकता है।

**क्यों एक लिंक्ड छवि दूसरे कंप्यूटर पर गायब हो जाती है?**

एक लिंक्ड चित्र अपने बाहरी फ़ाइल या URL पर निर्भर करता है। यदि वह संसाधन दूसरे कंप्यूटर से पहुँचा नहीं जा सकता, तो लिंक्ड छवि उपलब्ध नहीं हो सकती। जब प्रस्तुति स्व-निहित होनी चाहिए, तो छवि को एम्बेड करें।

**क्या डाली गई SVG को PowerPoint आकारों के रूप में संपादित किया जा सकता है?**

हां। SVG को [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/) से परिवर्तित करें; परिणामी समूह में एक SVG चित्र की बजाय संपादन योग्य स्लाइड आकार होते हैं।

**मैं कई छवियों वाली प्रस्तुतियों को छोटे कैसे रख सकता हूँ?**

साझा छवि संसाधनों का पुनः उपयोग करें, अनावश्यक रूप से बड़ी रास्टर स्रोतों से बचें, उचित होने पर उपयुक्त रास्टर चित्रों को संकुचित करें, दोहराए गए ब्रांडिंग को मास्टर या लेआउट पर रखें, और लिंक्ड छवियों का उपयोग केवल तभी करें जब बाहरी निर्भरता स्वीकार्य हो।