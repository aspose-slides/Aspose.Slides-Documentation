---
title: जावा में PowerPoint प्रस्तुतियों को Word दस्तावेज़ों में बदलें
linktitle: PowerPoint से Word
type: docs
weight: 110
url: /hi/java/convert-powerpoint-to-word/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से Word
- प्रस्तुति को Word में
- स्लाइड को Word में
- PPT को Word में
- PPTX को Word में
- PowerPoint को DOCX में
- प्रस्तुति को DOCX में
- स्लाइड को DOCX में
- PPT को DOCX में
- PPTX को DOCX में
- PowerPoint को DOC में
- प्रस्तुति को DOC में
- स्लाइड को DOC में
- PPT को DOC में
- PPTX को DOC में
- PPT को DOCX के रूप में सहेजें
- PPTX को DOCX के रूप में सहेजें
- PPT को DOCX में निर्यात करें
- PPTX को DOCX में निर्यात करें
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके जावा में PowerPoint PPT और PPTX स्लाइड्स को संपादन योग्य Word दस्तावेज़ों में परिवर्तित करें, जिसमें लेआउट, छवियाँ और फ़ॉर्मेटिंग सटीक रूप से संरक्षित रहे।"
---
## **सारांश**

यह लेख डेवलपर्स को Aspose.Slides और Aspose.Words का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने का समाधान प्रदान करता है। चरण-दर-चरण मार्गदर्शिका आपको परिवर्तन प्रक्रिया के प्रत्येक चरण के माध्यम से ले जाती है।

## **PowerPoint को Word में परिवर्तित करें**

PowerPoint या OpenDocument प्रस्तुति को Word दस्तावेज़ में बदलने के लिए नीचे दिए गए निर्देशों का पालन करें:

1. [Aspose.Slides for Java](https://downloads.aspose.com/slides/hi/java) और [Aspose.Words for Java](https://downloads.aspose.com/words/java) लाइब्रेरी डाउनलोड करें।
2. *aspose-slides-x.x-jdk16.jar* और *aspose-words-x.x-jdk16.jar* को अपने CLASSPATH में जोड़ें।
3. PowerPoint को Word में परिवर्तित करने के लिए इस कोड स्निपेट का उपयोग करें:

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

    // स्लाइड के पाठ सम्मिलित करता है
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

**PowerPoint और OpenDocument प्रस्तुतियों को Word दस्तावेज़ों में परिवर्तित करने के लिए किन घटकों को स्थापित करना आवश्यक है?**

आपको अपने प्रोजेक्ट में केवल [Aspose.Slides for Java](https://releases.aspose.com/slides/hi/java/) और [Aspose.Words for Java](https://releases.aspose.com/words/java/) के संबंधित पैकेज जोड़ने की आवश्यकता है। दोनों लाइब्रेरी स्वतंत्र APIs के रूप में काम करती हैं, और Microsoft Office स्थापित होना अनिवार्य नहीं है।

**क्या सभी PowerPoint और OpenDocument प्रस्तुति प्रारूप समर्थित हैं?**

Aspose.Slides [ सभी प्रस्तुति प्रारूपों को समर्थन देती है](/slides/hi/java/supported-file-formats/), जिसमें PPT, PPTX, ODP और अन्य सामान्य फ़ाइल प्रकार शामिल हैं। यह सुनिश्चित करता है कि आप विभिन्न संस्करणों के Microsoft PowerPoint में बनाई गई प्रस्तुतियों के साथ काम कर सकें।