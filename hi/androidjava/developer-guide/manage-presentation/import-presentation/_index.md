---
title: "PDF या HTML से Android पर प्रस्तुतियों को आयात करें"
linktitle: "प्रस्तुति आयात करें"
type: docs
weight: 60
url: /hi/androidjava/import-presentation/
keywords:
- "प्रस्तुति आयात करें"
- "स्लाइड आयात करें"
- "PDF आयात करें"
- "HTML आयात करें"
- "PDF से प्रस्तुति"
- "PDF से PPT"
- "PDF से PPTX"
- "PDF से ODP"
- "HTML से प्रस्तुति"
- "HTML से PPT"
- "HTML से PPTX"
- "HTML से ODP"
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ Java में PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आयात करें, जिससे सहज और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग संभव हो।"
---
## **परिचय**

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/hi/androidjava/) का उपयोग करके, आप अन्य फ़ॉर्मेट की फ़ाइलों से प्रस्तुतियाँ आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/) क्लास प्रदान करता है जो आपको PDF, HTML दस्तावेज़ आदि से प्रस्तुतियों को आयात करने की अनुमति देता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप एक PDF को PowerPoint प्रस्तुति में बदल सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation क्लास का एक उदाहरण बनाएँ।
2. addFromPdf() मेथड को कॉल करें और PDF फ़ाइल पास करें।
3. फाइल को PowerPoint फ़ॉर्मेट में सहेजने के लिए save() मेथड का उपयोग करें।

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
आप **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप को देख सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का एक लाइव कार्यान्वयन है। 
{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में बदल सकते हैं।

1. Presentation क्लास का एक उदाहरण बनाएँ।
2. addFromHtml() मेथड को कॉल करें और HTML दस्तावेज़ वाला स्ट्रीम पास करें।
3. फाइल को PowerPoint फ़ॉर्मेट में सहेजने के लिए save() मेथड का उपयोग करें।

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

## **FAQ**

### क्या PDF आयात करते समय तालिकाएँ संरक्षित रहती हैं, और क्या उनकी पहचान को सुधारा जा सकता है?

आयात के दौरान तालिकाओं की पहचान की जा सकती है; PdfImportOptions में setDetectTables मेथड शामिल है जो तालिका मान्यता को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।