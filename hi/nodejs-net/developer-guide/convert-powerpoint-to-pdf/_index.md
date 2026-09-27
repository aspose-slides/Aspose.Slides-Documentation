---
title: Node.js के माध्यम से .NET में PowerPoint को PDF में बदलें
linktitle: PowerPoint को PDF
type: docs
weight: 30
url: /hi/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को PDF
- PowerPoint को PDF में बदलें
- PPTX को PDF
- PPT को PDF
- ODP को PDF
- प्रस्तुति को PDF के रूप में सहेजें
- PDF/A
- PdfOptions
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET का उपयोग करके जावास्क्रिप्ट में PPTX, PPT और ODP प्रस्तुतियों को PDF में बदलें, और PdfOptions के साथ संग्रहणीय PDF/A फ़ाइलें बनाएं।"
---
## **Overview**

Aspose.Slides for Node.js via .NET Microsoft PowerPoint के बिना PowerPoint और OpenDocument प्रस्तुतियों को PDF में बदलता है। प्रत्येक दृश्यमान स्लाइड समान आकार के एक PDF पृष्ठ में बदल जाती है, और टेक्स्ट चयन योग्य और खोज योग्य बना रहता है। यह लेख डिफ़ॉल्ट रूपांतरण और [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) का उपयोग करके PDF/A में रूपांतरण को दिखाता है।

उदाहरणों को आपके द्वारा [Installation](/slides/hi/nodejs-net/installation/) में सेट किए गए प्रोजेक्ट फ़ोल्डर में `sample.pptx` नाम की प्रस्तुति की आवश्यकता होती है। कोई भी PowerPoint प्रस्तुति काम करेगी। प्रत्येक उदाहरण को प्रोजेक्ट फ़ोल्डर में एक `.js` फ़ाइल के रूप में सहेजें और उसे उस फ़ोल्डर से `node` के साथ चलाएँ।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET का अपना कोई API रेफ़रेंस नहीं है। यह Aspose.Slides for .NET API को camelCase नामों के साथ प्रतिबिंबित करता है, इसलिए इस लेख में API लिंक मिलते-जुलते क्लास और सदस्य की ओर ले जाते हैं [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hi/net/) में।  
{{% /alert %}}

## **Convert a Presentation to PDF**

प्रस्तुति को PDF में बदलें

1. प्रस्तुति को उसके पथ को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कंस्ट्रक्टर को पास करके खोलें। वही कोड PPTX, PPT, और ODP फ़ाइलों के लिए काम करता है।  
2. `[save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/)` मेथड को आउटपुट पथ और `SaveFormat.Pdf` के साथ कॉल करें।  
3. प्रस्तुति को बैक करने वाले .NET संसाधनों को मुक्त करने के लिए `finally` ब्लॉक में `dispose` को कॉल करें।

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `sample.pdf` को प्रोजेक्ट फ़ोल्डर में लिखती है। रूपांतरण डिफ़ॉल्ट सेटिंग्स का उपयोग करता है: प्रत्येक न छिपी स्लाइड एक पृष्ठ बन जाती है, स्लाइड क्रम में। बिना लाइसेंस के प्रत्येक पृष्ठ पर एक मूल्यांकन वॉटरमार्क भी दिखाया जाता है; देखें [Licensing](/slides/hi/nodejs-net/licensing/)।

## **Convert a Presentation to PDF/A**

प्रस्तुति को PDF/A में बदलें

आउटपुट को नियंत्रित करने के लिए, `save` के तीसरे तर्क के रूप में एक [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/) ऑब्जेक्ट पास करें। निम्न उदाहरण [compliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/compliance/) प्रॉपर्टी को `PdfCompliance.PdfA2b` पर सेट करता है, जो एक PDF/A-2b फ़ाइल बनाता है। PDF/A दीर्घकालिक अभिलेखरण के लिए ISO मानक है: अन्य नियमों के साथ, यह दस्तावेज़ द्वारा उपयोग किए गए प्रत्येक फ़ॉन्ट को फ़ाइल में एम्बेडेड होने की आवश्यकता रखता है।

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

स्क्रिप्ट `sample-pdfa.pdf` को डिफ़ॉल्ट रूपांतरण जैसी ही पृष्ठों के साथ लिखती है। यह पुष्टि करने के लिए कि फ़ाइल मानक को पूरा करती है, इसे [veraPDF](https://verapdf.org/) जैसे PDF/A वैलिडेटर से जांचें। अन्य [PdfCompliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfcompliance/) मान अन्य मानकों का चयन करते हैं, जैसे पहुंच के लिए `PdfA1b`, `PdfA2a`, या `PdfUa`।

## **FAQ**

**PDF में छिपी स्लाइड्स कैसे शामिल करें?**  
छिपी स्लाइड्स डिफ़ॉल्ट रूप से छोड़ दी जाती हैं। `PdfOptions` की [showHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/showhiddenslides/) प्रॉपर्टी को `true` सेट करें और विकल्प को `save` में पास करें।

**क्या मैं PDF को पासवर्ड से सुरक्षित कर सकता हूँ?**  
हां। `save` कॉल करने से पहले `PdfOptions` की [password](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/password/) प्रॉपर्टी सेट करें। PDF रीडर तब फ़ाइल खोलने से पहले वह पासवर्ड पूछेंगे।

**क्या मैं केवल कुछ स्लाइड्स को ही बदल सकता हूँ?**  
हां। `save` के चौथे तर्क के रूप में स्लाइड स्थितियों की एक एरे पास करें। स्थितियां 1 से शुरू होती हैं, और यदि आपको विकल्पों की आवश्यकता नहीं है तो तीसरा तर्क `null` हो सकता है: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` पहले और तीसरे स्लाइड के साथ एक PDF लिखता है।

**Linux पर रूपांतरण करते समय टेक्स्ट अलग क्यों दिखता है?**  
Aspose.Slides केवल उन फ़ॉन्ट्स का उपयोग कर सकता है जो रूपांतरण चलाने वाली मशीन पर इंस्टॉल किए गए हों। जब प्रस्तुति में कोई फ़ॉन्ट अनुपलब्ध होता है, जैसे कि सामान्य Linux सर्वर पर Calibri, तो Aspose.Slides उसकी जगह इंस्टॉल किया गया फ़ॉन्ट उपयोग करता है, जिससे टेक्स्ट का रूप और लाइन ब्रेक बदल सकते हैं। वही परिणाम पाने के लिए जो Windows पर मिलता है, अपने प्रस्तुतियों द्वारा उपयोग किए गए फ़ॉन्ट्स को इंस्टॉल करें।

**क्या मैं फ़ाइल के बजाय PDF को Buffer के रूप में प्राप्त कर सकता हूँ?**  
हां। `presentation.saveToBuffer(SaveFormat.Pdf)` PDF को Node.js `Buffer` के रूप में लौटाता है, जो HTTP प्रतिक्रिया में परिणाम भेजते समय सुविधाजनक है। यह दूसरा तर्क के रूप में `PdfOptions` भी स्वीकार करता है।