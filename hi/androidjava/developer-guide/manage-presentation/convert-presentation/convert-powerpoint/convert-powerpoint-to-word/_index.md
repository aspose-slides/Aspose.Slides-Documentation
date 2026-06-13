---
title: Android पर PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में बदलें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/androidjava/convert-powerpoint-to-word/
keywords:
- PowerPoint परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से Word
- प्रेज़ेंटेशन से Word
- स्लाइड से Word
- PPT से Word
- PPTX से Word
- PowerPoint से DOCX
- प्रेज़ेंटेशन से DOCX
- स्लाइड से DOCX
- PPT से DOCX
- PPTX से DOCX
- PowerPoint से DOC
- प्रेज़ेंटेशन से DOC
- स्लाइड से DOC
- PPT से DOC
- PPTX से DOC
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT को DOCX में निर्यात करें
- PPTX को DOCX में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT और PPTX स्लाइड्स को संपादनीय Word दस्तावेज़ों में बदलें, जिसमें सटीक लेआउट, चित्र और फ़ॉर्मेटिंग संरक्षित रहे।"
---
## **अवलोकन**

यह लेख डेवलपर्स को Aspose.Slides और Aspose.Words का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने का समाधान प्रदान करता है। चरण‑दर‑चरण मार्गदर्शिका आपको रूपांतरण प्रक्रिया के प्रत्येक चरण से गुजराती है।

## **Aspose.Slides और Aspose.Words**

PowerPoint फ़ाइल (PPTX या PPT) को Word (DOCX या DOC) में परिवर्तित करने के लिए, आपको दोनों [Aspose.Slides for Android via Java](https://products.aspose.com/slides/hi/androidjava/) और [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/) की आवश्यकता है।

एक अलग API के रूप में, जावा के लिए [Aspose.Slides](https://products.aspose.app/slides) फ़ंक्शन प्रदान करता है जो आपको प्रस्तुतियों से पाठ निकालने की अनुमति देता है।

[Aspose.Words](https://docs.aspose.com/words/androidjava/) एक उन्नत दस्तावेज़ प्रोसेसिंग API है जो अनुप्रयोगों को दस्तावेज़ों को उत्पन्न, संशोधित, परिवर्तित, रेंडर, प्रिंट करने तथा Microsoft Word का उपयोग किए बिना अन्य कार्य करने की अनुमति देती है।

## **PowerPoint को Word में परिवर्तित करें**

1. [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/hi/java) और [Aspose.Words for Java](https://downloads.aspose.com/words/java) लाइब्रेरी डाउनलोड करें।  
2. *aspose-slides-x.x-jdk16.jar* और *aspose-words-x.x-jdk16.jar* को अपने CLASSPATH में जोड़ें।  
3. इस कोड स्निपेट का उपयोग करके PowerPoint को Word में परिवर्तित करें:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // स्लाइड छवि को बाइट एरे स्ट्रीम के रूप में बनाता है
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // स्लाइड के टेक्स्ट सम्मिलित करता है
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने के लिए कौन से घटकों की आवश्यकता है?**

आपको केवल अपने प्रोजेक्ट में [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/hi/androidjava/) और [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) का संबंधित पैकेज जोड़ना है। दोनों लाइब्रेरी स्वतंत्र API के रूप में कार्य करती हैं, और Microsoft Office स्थापित करने की कोई आवश्यकता नहीं है।

**क्या सभी PowerPoint और OpenDocument प्रस्तुति स्वरूप समर्थित हैं?**

Aspose.Slides [सभी प्रस्तुति स्वरूपों को समर्थन करता है](/slides/hi/androidjava/supported-file-formats/), जिसमें PPT, PPTX, ODP और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। यह सुनिश्चित करता है कि आप विभिन्न संस्करणों के Microsoft PowerPoint में निर्मित प्रस्तुतियों के साथ काम कर सकें।