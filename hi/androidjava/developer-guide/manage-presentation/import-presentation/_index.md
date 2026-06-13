---
title: PDF या HTML से Android पर प्रस्तुतियों को आयात करें
linktitle: प्रेज़ेंटेशन आयात करें
type: docs
weight: 60
url: /hi/androidjava/import-presentation/
keywords:
- प्रस्तुति आयात
- स्लाइड आयात
- PDF आयात
- HTML आयात
- PDF से प्रस्तुति
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रस्तुति
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आयात करें, जिससे सहज और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग संभव हो।"
---
## **परिचय**

उपयोग करके [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/hi/androidjava/), आप अन्य फ़ॉर्मेट की फ़ाइलों से प्रस्तुतियों को आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/) क्लास प्रदान करता है जिससे आप PDF, HTML दस्तावेज़ आदि से प्रस्तुतियों को आयात कर सकते हैं।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप एक PDF को PowerPoint प्रस्तुति में बदल सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) क्लास का उदाहरण बनाएं।
2. [addFromPdf()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) मेथड को कॉल करें और PDF फ़ाइल पास करें।
3. [save()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

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
आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप को देखना चाह सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव इम्प्लीमेंटेशन है। 
{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में बदल सकते हैं।

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) क्लास का उदाहरण बनाएं।
2. [addFromHtml()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) मेथड को कॉल करें और HTML फ़ाइल पास करें।
3. [save()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

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

**क्या PDF आयात करते समय तालिकाएँ संरक्षित रहती हैं, और उनकी पहचान को सुधारा जा सकता है?**

आयात के दौरान तालिकाओं को पहचा जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfimportoptions/) में एक [setDetectTables](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) मेथड शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।