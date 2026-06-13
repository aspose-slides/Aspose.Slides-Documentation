---
title: JavaScript में PDF या HTML से प्रस्तुतियों का आयात
linktitle: प्रस्तुति आयात
type: docs
weight: 60
url: /hi/nodejs-java/import-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PDF और HTML दस्तावेज़ों को PowerPoint और OpenDocument प्रस्तुतियों में आयात करें, सहज और उच्च-प्रदर्शन स्लाइड प्रोसेसिंग के लिए।"
---
## **परिचय**

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hi/nodejs-java/) का उपयोग करके, आप अन्य फ़ॉर्मेट की फ़ाइलों से प्रस्तुतियों को आयात कर सकते हैं। Aspose.Slides [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) वर्ग प्रदान करता है जो आपको PDFs, HTML दस्तावेज़ आदि से प्रस्तुतियों को आयात करने की अनुमति देता है।

## **PDF से PowerPoint आयात करें**

इस मामले में, आप एक PDF को PowerPoint प्रस्तुति में बदल सकते हैं।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Presentation वर्ग का एक उदाहरण बनाएँ।
2. [addFromPdf()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) मेथड को कॉल करें और PDF फ़ाइल पास करें।
3. PowerPoint फ़ॉर्मेट में फ़ाइल को सहेजने के लिए [save()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करें।

यह JavaScript कोड PDF से PowerPoint परिवर्तन को दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert  title="Tip" color="primary" %}} 

आप **Aspose free** [PDF से PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप को देख सकते हैं क्योंकि यह यहाँ वर्णित प्रक्रिया का एक लाइव कार्यान्वयन है। 

{{% /alert %}} 

## **HTML से PowerPoint आयात करें**

इस मामले में, आप एक HTML दस्तावेज़ को PowerPoint प्रस्तुति में बदल सकते हैं।

1. Presentation वर्ग का एक उदाहरण बनाएँ।
2. [addFromHtml()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) मेथड को कॉल करें और PDF फ़ाइल पास करें।
3. PowerPoint फ़ॉर्मेट में फ़ाइल को सहेजने के लिए [save()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) मेथड का उपयोग करें।

यह JavaScript कोड HTML से PowerPoint परिवर्तन को दर्शाता है:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**क्या PDF आयात करते समय तालिकाएँ संरक्षित रहती हैं, और उनकी पहचान को सुधारा जा सकता है?**

आयात के दौरान तालिकाओं का पता लगाया जा सकता है; [PdfImportOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfimportoptions/) में [setDetectTables](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) मेथड शामिल है जो तालिका पहचान को सक्षम करता है। प्रभावशीलता PDF की संरचना पर निर्भर करती है।