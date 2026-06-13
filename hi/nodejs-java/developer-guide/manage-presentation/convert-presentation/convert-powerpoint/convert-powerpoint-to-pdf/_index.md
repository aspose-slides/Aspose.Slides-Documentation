---
title: JavaScript में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- PowerPoint से PDF
- प्रस्तुति से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ."
---
## **Overview**

PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, ODP आदि) को JavaScript में PDF स्वरूप में बदलने के कई फायदे हैं, जैसे विभिन्न उपकरणों के बीच संगतता और आपके प्रस्तुतीकरण की लेआउट तथा फ़ॉर्मेटिंग को संरक्षित रखना। यह गाइड दिखाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छुपी स्लाइड्स शामिल करें, PDF फाइलों को पासवर्ड‑प्रोटेक्ट करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, परिवर्तन के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानक लागू करें।

## **PowerPoint to PDF Conversions**

Aspose.Slides का उपयोग करके आप निम्न स्वरूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुतीकरण को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर `save` मेथड का उपयोग करके प्रस्तुतीकरण को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास `save` मेथड प्रदान करती है जो आमतौर पर प्रस्तुतीकरण को PDF में बदलने के लिए उपयोग की जाती है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या जोड़ता है। उदाहरण के लिए, जब प्रस्तुतीकरण को PDF में बदलते हैं, Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **Note** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुतीकरण से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करता है कि उत्पन्न PDFs मूल प्रस्तुतियों के बहुत करीब हों। परिवर्तन के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिनमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* तालिकाएँ

## **Convert PowerPoint to PDF**

मानक PowerPoint‑to‑PDF परिवर्तन प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान किए गए प्रस्तुतीकरण को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है।

यह कोड दिखाता है कि प्रस्तुतीकरण (PPT, PPTX, ODP आदि) को PDF में कैसे बदलें:

```js
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // प्रस्तुतीकरण को PDF के रूप में सहेजें.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुतीकरण‑to‑PDF परिवर्तन प्रक्रिया को प्रदर्शित करता है। आप इस कनवर्टर का उपयोग करके यहाँ वर्णित प्रक्रिया का लाइव परीक्षण कर सकते हैं।

{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत गुण—प्रदान करता है, जिससे आप निर्मित PDF को अनुकूलित कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या परिवर्तन प्रक्रिया के क्रम को निर्दिष्ट कर सकते हैं।

### **Convert PowerPoint to PDF with Custom Options**

कस्टम परिवर्तन विकल्पों का उपयोग करते हुए, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग, मेटा‑फ़ाइल्स को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि निर्धारित कर सकते हैं।

नीचे दिया गया कोड उदाहरण दिखाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुतीकरण को PDF में कैसे बदलें:

```js
// PdfOptions क्लास को इंस्टैंस्टिएट करें.
let pdfOptions = new aspose.slides.PdfOptions();

// JPG छवियों की गुणवत्ता सेट करें.
pdfOptions.setJpegQuality(java.newByte(90));

// छवियों के लिए DPI सेट करें.
pdfOptions.setSufficientResolution(300);

// मेटा फ़ाइलों के लिए व्यवहार निर्धारित करें.
pdfOptions.setSaveMetafilesAsPng(true);

// टेक्स्ट सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करें.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// PDF अनुपालन मोड परिभाषित करें.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // प्रस्तुतीकरण को PDF दस्तावेज़ के रूप में सहेजें.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to PDF with Hidden Slides**

यदि प्रस्तुतीकरण में छुपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) विधि का उपयोग करके छुपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह JavaScript कोड दिखाता है कि छुपी स्लाइड्स सहित PowerPoint प्रस्तुतीकरण को PDF में कैसे बदलें:

```js
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास को इंस्टैंस्टिएट करें.
    let pdfOptions = new aspose.slides.PdfOptions();

    // छुपी स्लाइड्स जोड़ें.
    pdfOptions.setShowHiddenSlides(true);

    // प्रस्तुतीकरण को PDF के रूप में सहेजें.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convert PowerPoint to Password Protected PDF**

यह JavaScript कोड दिखाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास के संरक्षण पैरामीटर का उपयोग करके PowerPoint प्रस्तुतीकरण को पासवर्ड‑प्रोटेक्टेड PDF में कैसे बदलें:

```js
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // PdfOptions क्लास को इंस्टैंस्टिएट करें.
    let pdfOptions = new aspose.slides.PdfOptions();

    // PDF पासवर्ड और एक्सेस अनुमतियों को सेट करें.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // प्रस्तुतीकरण को PDF के रूप में सहेजें.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Detect Font Substitutions**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जिससे आप प्रस्तुतीकरण‑to‑PDF परिवर्तन प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

यह JavaScript कोड दिखाता है कि फ़ॉन्ट प्रतिस्थापन का पता कैसे लगाएँ:

```js
// PDF विकल्पों में चेतावनी कॉलबैक सेट करें.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("sample.pptx");

// प्रस्तुतीकरण को PDF के रूप में सहेजें.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```
```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```

{{%  alert color="primary"  %}} 

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/nodejs-java/font-substitution/) लेख।

{{% /alert %}} 

## **Convert Selected Slides in PowerPoint to PDF**

यह JavaScript कोड दिखाता है कि PowerPoint प्रस्तुतीकरण से केवल विशिष्ट स्लाइड्स को PDF में कैसे बदलें:

```js
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // स्लाइड नंबरों की एरे सेट करें.
    let slides = java.newArray("int", [1, 3]);

    // प्रस्तुतीकरण को PDF के रूप में सहेजें.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF with Custom Slide Size**

यह JavaScript कोड दिखाता है कि निर्दिष्ट स्लाइड आकार के साथ PowerPoint प्रस्तुतीकरण को PDF में कैसे बदलें:

```js
const slideWidth = 612;
const slideHeight = 792;

// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// समायोजित स्लाइड आकार के साथ एक नया प्रस्तुतीकरण बनाएं.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // कस्टम स्लाइड आकार सेट करें.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // मूल प्रस्तुतीकरण से पहली स्लाइड को क्लोन करें.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // रीसाइज़्ड प्रस्तुतीकरण को नोट्स के साथ PDF में सहेजें.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

यह JavaScript कोड दिखाता है कि नोट्स सहित PowerPoint प्रस्तुतीकरण को PDF में कैसे बदलें:

```js
// PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस्टिएट करें.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // नोट्स लेआउट के साथ PDF विकल्प कॉन्फ़िगर करें.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // प्रस्तुतीकरण को नोट्स के साथ PDF में सहेजें.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibility and Compliance Standards for PDF**

Aspose.Slides आपको एक ऐसी परिवर्तन प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए इन अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह JavaScript कोड कई अनुपालन मानकों के आधार पर विभिन्न PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF प्रक्रिया दर्शाता है:

```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF परिवर्तन कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/hi/nodejs-java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/nodejs-java/conversion/pdf-to-png/) परिवर्तनों को कर सकते हैं। अन्य विशेष फ़ॉर्मेट—[PDF to SVG](https://products.aspose.com/slides/hi/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/nodejs-java/conversion/pdf-to-tiff/)—के लिए भी समर्थन उपलब्ध है।

{{% /alert %}}

> **Note:** जब PDF/UA में निर्यात किया जाता है, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूला को एक ही आकृति के रूप में देखता है। व्यक्तिगत पाथ तत्व अलग सामग्री के रूप में संरक्षित नहीं रहते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **FAQ**

**क्या मैं कई PowerPoint फाइलों को एक साथ PDF में बदल सकता हूँ?**

हां, Aspose.Slides कई PPT या PPTX फाइलों को बैच में PDF में बदलने का समर्थन करता है। आप प्रोग्रामेटिक रूप से अपनी फाइलों पर इटरेट करके परिवर्तन प्रक्रिया लागू कर सकते हैं।

**क्या परिणामी PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**

बिल्कुल। परिवर्तन प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास का उपयोग करें।

**मैं PDF में छुपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छुपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास की `setShowHiddenSlides` मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हां, आप `setJpegQuality` और `setSufficientResolution` जैसी विधियों का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PdfOptions) क्लास में छवि गुणवत्ता नियंत्रित कर सकते हैं, जिससे आपके PDF में उच्च‑गुणवत्ता वाली छवियां मिलेंगी।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हां, Aspose.Slides विभिन्न मानकों—जैसे PDF/A1a, PDF/A1b, और PDF/UA—के अनुरूप PDFs निर्यात करने की अनुमति देता है, जिससे आपके दस्तावेज़ पहुंचयोग्यता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **Additional Resources**

- [Aspose.Slides for Node.js via Java Documentation](/slides/hi/nodejs-java/)
- [Aspose.Slides for Node.js via Java API Reference](https://reference.aspose.com/slides/hi/nodejs-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)