---
title: Java में PDF या HTML से प्रस्तुतियों को आयात करें
linktitle: प्रेज़ेंटेशन आयात करें
type: docs
weight: 60
url: /hi/java/import-presentation/
keywords:
- प्रेज़ेंटेशन आयात
- स्लाइड आयात
- PDF आयात
- HTML आयात
- PDF से प्रेज़ेंटेशन
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रेज़ेंटेशन
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में सहजता से आयात करें, जिससे उच्च-प्रदर्शन स्लाइड प्रोसेसिंग मिले।"
---
## **परिचय**

Aspose.Slides का उपयोग करके, आप अन्य फ़ॉर्मैट की फ़ाइलों से प्रेज़ेंटेशन आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/) क्लास प्रदान करता है, जो PDF और HTML दस्तावेज़ों से प्रेज़ेंटेशन आयात करने की अनुमति देता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप PDF को एक PowerPoint प्रेज़ेंटेशन में बदल सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) क्लास का एक इंस्टेंस बनाएं। 
2. [addFromPdf()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) मेथड को कॉल करें और PDF फ़ाइल पास करें। 
3. [save()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

यह Java कोड PDF से PowerPoint परिवर्तन को दर्शाता है:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब एप्लिकेशन को देखना चाह सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव इम्प्लीमेंटेशन है। 
{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रेज़ेंटेशन में बदल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) क्लास का एक इंस्टेंस बनाएं। 
2. [addFromHtml()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) मेथड को कॉल करें और फ़ाइल पास करें। 
3. [save()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

यह Java कोड HTML से PowerPoint परिवर्तन को दर्शाता है: 

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**क्या PDF आयात करते समय तालिकाएँ संरक्षित रहती हैं, और क्या उनकी पहचान में सुधार किया जा सकता है?**

आयात के दौरान तालिकाओं का पता लगाया जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfimportoptions/) में एक [setDetectTables](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) मेथड शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।

{{% alert title="Note" color="warning" %}} 
आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल फ़ॉर्मैट में भी बदल सकते हैं: 

* [HTML को इमेज](https://products.aspose.com/slides/hi/java/conversion/html-to-image/)
* [HTML को JPG](https://products.aspose.com/slides/hi/java/conversion/html-to-jpg/)
* [HTML को XML](https://products.aspose.com/slides/hi/java/conversion/html-to-xml/)
* [HTML को TIFF](https://products.aspose.com/slides/hi/java/conversion/html-to-tiff/)

{{% /alert %}}