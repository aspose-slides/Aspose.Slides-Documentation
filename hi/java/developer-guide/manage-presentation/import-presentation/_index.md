---
title: "Java में PDF या HTML से प्रस्तुतियों को आयात करें"
linktitle: "प्रस्तुति आयात करें"
type: docs
weight: 60
url: /hi/java/import-presentation/
keywords:
- "प्रस्तुति आयात"
- "स्लाइड आयात"
- "PDF आयात"
- "HTML आयात"
- "PDF से प्रस्तुति"
- "PDF से PPT"
- "PDF से PPTX"
- "PDF से ODP"
- "HTML से प्रस्तुति"
- "HTML से PPT"
- "HTML से PPTX"
- "HTML से ODP"
- "PowerPoint"
- "OpenDocument"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides के साथ Java में PDF और HTML दस्तावेज़ों को सहजता से PowerPoint और OpenDocument प्रस्तुतियों में आयात करें, जिससे सुगम और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग प्राप्त हो।"
---
## **परिचय**

Aspose.Slides का उपयोग करके, आप अन्य फॉर्मैट की फाइलों से प्रस्तुतियों को इम्पोर्ट कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/) क्लास प्रदान करता है, जो PDF और HTML दस्तावेजों से प्रस्तुतियों को इम्पोर्ट करने की सुविधा देता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप PDF को PowerPoint प्रस्तुति में परिवर्तित कर सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) क्लास का एक इंस्टेंस बनाएं। 
2. [addFromPdf()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) मेथड को कॉल करें और PDF फ़ाइल पास करें। 
3. [save()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="info" %}} 
आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब एप्लिकेशन देखना चाह सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का लाइव इम्प्लीमेंटेशन है। 
{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप HTML दस्तावेज़ को PowerPoint प्रस्तुति में परिवर्तित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) क्लास का एक इंस्टेंस बनाएं। 
2. [addFromHtml()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) मेथड को कॉल करें और HTML दस्तावेज़ के साथ एक स्ट्रीम पास करें। 
3. [save()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करके फ़ाइल को PowerPoint फ़ॉर्मेट में सहेजें।

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या PDF आयात करने पर तालिकाएँ संरक्षित रहती हैं, और क्या उनकी पहचान को सुधारा जा सकता है?

इम्पोर्ट के दौरान तालिकाओं को पहचाना जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfimportoptions/) में एक [setDetectTables](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) मेथड शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।

{{% alert title="Note" color="warning" %}} 

आप Aspose.Slides का उपयोग करके HTML को अन्य लोकप्रिय फ़ाइल फ़ॉर्मेट में भी परिवर्तित कर सकते हैं: 

* [HTML to image](https://products.aspose.com/slides/hi/java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/hi/java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/hi/java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/hi/java/conversion/html-to-tiff/)

{{% /alert %}}