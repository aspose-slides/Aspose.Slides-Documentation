---
title: JavaScript में PPT और PPTX को PDF में परिवर्तित करें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint रूपांतरित करें
- प्रेजेंटेशन रूपांतरित करें
- PowerPoint से PDF
- प्रेजेंटेशन से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDF में बदलें, तेज़ कोड उदाहरण और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

PowerPoint और OpenDocument प्रस्तुतियों (PPT, PPTX, ODP आदि) को जावास्क्रिप्ट में PDF फ़ॉर्मेट में बदलने से कई लाभ मिलते हैं, जिसमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह गाइड दर्शाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, इमेज क्वालिटी नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी हुई स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड से संरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित फ़ॉर्मैट में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को तर्क के रूप में [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास में पास करें और फिर एक [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास वह [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) मेथड उजागर करता है जिसका आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के लिए, जब कोई प्रस्तुति PDF में बदलती है, तो Aspose.Slides एप्लिकेशन फ़ील्ड को "*Aspose.Slides*" से और PDF प्रोड्यूसर फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को आउटपुट दस्तावेज़ों से बदलने या हटाने का निर्देश नहीं दे सकते।  
{{% /alert %}}

Aspose.Slides आपको परिवर्तित करने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि परिणामी PDF मूल प्रस्तुतियों से बहुत करीब मेल खाते हैं। परिवर्तन के दौरान तत्व और विशेषताएँ सटीक रूप से रेंडर की जाती हैं, जिसमें शामिल हैं:

* छवियाँ
* पाठ बॉक्स और आकार
* पाठ स्वरूपण
* अनुच्छेद स्वरूपण
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* टेबल

## **PowerPoint को PDF में परिवर्तित करें**

मानक PowerPoint से PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है।  
निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दृश्यमान स्लाइड्स को PDF में सहेजता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति से PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ वर्णित प्रक्रिया के वास्तविक कार्यान्वयन के लिए इस कंवर्टर के साथ एक टेस्ट चला सकते हैं।  
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में परिवर्तित करें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास के तहत गुण—प्रदान करता है जिससे आप उत्पन्न PDF को अनुकूलित कर सकते हैं, पासवर्ड के साथ PDF को लॉक कर सकते हैं, या यह निर्दिष्ट कर सकते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर इमेज के लिए अपनी पसंदीदा गुणवत्ता सेटिंग निर्धारित कर सकते हैं, बतौर फ़ाइलों को कैसे संभालना है, पाठ के लिए संपीड़न स्तर सेट कर सकते हैं, इमेज के DPI को कॉन्फ़िगर कर सकते हैं, और अधिक।  
निम्नलिखित उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है जिसमें JPEG गुणवत्ता 90 पर सेट है, इमेज रेज़ोल्यूशन 300 DPI पर सेट है, मेटाफाइल्स PNG के रूप में सहेजे जाते हैं, और Flate टेक्स्ट संपीड़न उपयोग किया गया है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट्स के रूप में संरक्षित करें**

यदि किसी प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक के डेटा को भी एक्सेस कर सकें तथा स्लाइड्स देख सकें। परिणामस्वरूप PDF में एम्बेडेड OLE फ़ाइलों को अटैचमेंट्स के रूप में संरक्षित करने के लिए [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) को `true` के साथ कॉल करें।  
डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, लेकिन उसकी एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` सेट करने पर फ़ाइल डेटा भी शामिल हो जाता है। प्रीव्यू एक दृश्य प्रतिनिधित्व बना रहता है; अटैचमेंट प्राप्तकर्ताओं को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की सुविधा देता है। OLE ऑब्जेक्ट PDF पेज पर इंटरएक्टिव Excel वर्कशीट नहीं बनता।  
निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है जिसमें पहले से ही एम्बेडेड Excel वर्कबुक मौजूद है और वर्कबुक को अटैचमेंट के रूप में PDF में निर्यात करता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

परिणाम की जाँच करने के लिए:

1. एक ऐसे व्यूअर में निर्यातित PDF खोलें जो फ़ाइल अटैचमेंट्स को सपोर्ट करता हो, जैसे Adobe Acrobat Reader।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें।
3. अटैचमेंट को सहेजें और डेटा जांचने के लिए Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटैचमेंट से अलग है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट्स पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को मनादी करता है, PDF/A-2 केवल PDF/A अटैचमेंट्स को अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों को अनुमति देता है, जिसमें Excel वर्कबुक भी शामिल हैं। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides के लिए विशिष्ट प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात को प्रदर्शित नहीं करता।  
{{% /alert %}}

### **छिपी हुई स्लाइड्स के साथ PowerPoint को PDF में परिवर्तित करें**

यदि किसी प्रस्तुति में छिपी हुई स्लाइड्स हैं, तो आप परिणामस्वरूप PDF में छिपी हुई स्लाइड्स को पेजेज़ के रूप में शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) मेथड का उपयोग कर सकते हैं।  
निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जिसमें सभी छिपी हुई स्लाइड्स शामिल हैं।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **पासवर्ड-प्रोटेक्टेड PDF के साथ PowerPoint को परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए `password` पासवर्ड आवश्यक है। एक्सेस परमिशन प्रिंटिंग की अनुमति देते हैं, जिसमें उच्च गुणवत्ता वाली प्रिंटिंग भी शामिल है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) मेथड प्रदान करता है, जिससे आप प्रस्तुति से PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।  
निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियाँ प्रिंट करता है। चेतावनी केवल तब प्रिंट होती है जब निर्यात के दौरान किसी अनुपलब्ध फ़ॉन्ट का प्रतिस्थापन किया जाता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/nodejs-java/font-substitution/) लेख।  
{{% /alert %}} 

### **समर्पित बोल्ड टाइपफ़ेस के बिना फ़ॉन्ट को संभालें**

एक प्रस्तुति टेक्ट्स पर बोल्ड फ़ॉर्मेटिंग लागू कर सकती है भले ही उसके फ़ॉन्ट में समर्पित बोल्ड टाइपफ़ेस न हो। टेक्स्ट सिंथेटिक बोल्डिंग के माध्यम से अभी भी बोल्ड दिख सकता है, जो नियमित glyphs को कृत्रिम रूप से मोटा करता है। जब वह टेक्स्ट बहुत भारी दिखे या PDF में इच्छित स्वरूप से भिन्न हो, तो [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) को `true` के साथ कॉल करने का प्रयास करें। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रेंडर करता है और कुछ फ़ॉन्ट्स के लिए इसकी दिखावट को बेहतर बना सकता है। इसका डिफ़ॉल्ट मान `false` है।  
नमूना प्रस्तुति में दो टेक्स्ट बॉक्स हैं: एक सामान्य टेक्स्ट के साथ और दूसरा समान फ़ॉन्ट पर बोल्ड फ़ॉर्मेटिंग के साथ, जिसके पास समर्पित बोल्ड टाइपफ़ेस नहीं है। निम्नलिखित उदाहरण प्रस्तुति को लोड करता है, असमर्थित फ़ॉन्ट शैलियों की रास्टराइजेशन सक्षम करता है, और इसे PDF में निर्यात करता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

निम्नलिखित प्रीव्यू दिखाते हैं निष्क्रिय आउटपुट और सक्षम आउटपुट को। इस उदाहरण में, विकल्प निष्क्रिय होने पर बोल्ड टेक्स्ट की स्ट्रोक्स अधिक मोटी होती हैं। विकल्प सक्षम होने पर उसकी स्ट्रोक्स हल्की होती हैं; सामान्य टेक्स्ट अपरिवर्तित रहता है। सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प निष्क्रिय (`false`, डिफ़ॉल्ट) | विकल्प सक्षम (`true`) |
|---|---|
| ![असमर्थित फ़ॉन्ट शैली रास्टराइजेशन निष्क्रिय के साथ PDF](unsupported-bold-disabled.png) | ![असमर्थित फ़ॉन्ट शैली रास्टराइजेशन सक्षम के साथ PDF](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प को सक्षम करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: इसे OCR के बिना चयन, कॉपी या टेक्स्ट के रूप में खोजा नहीं जा सकता, और 800% ज़ूम पर इसकी किनारें नरम दिखते हैं। सामान्य टेक्स्ट खोज योग्य बना रहता है। विकल्प निष्क्रिय होने पर दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।  
यह विकल्प तब बोल्ड के रूप में फ़ॉर्मेट किए गए टेक्स्ट को रास्टराइज़ करता है जब उसके फ़ॉन्ट में समर्पित बोल्ड टाइपफ़ेस नहीं होता। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/nodejs-java/font-substitution/) के बजाय मूल फ़ॉन्ट उपलब्ध नहीं होने पर कोई अन्य फ़ॉन्ट चयनित करता है।

## **PowerPoint से चयनित स्लाइड्स को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर एक-आधारित हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति की पहली स्लाइड को 612 × 792 पॉइंट्स (8.5 × 11 इंच) स्लाइड आकार वाले नए प्रस्तुति में कॉपी करता है। यह स्लाइड सामग्री को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // नए प्रस्तुति के साथ बनी खाली स्लाइड को हटाएँ।
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जिसमें प्रत्येक स्लाइड के स्पीकर नोट्स को स्लाइड के नीचे रखा जाता है। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF के लिए पहुँच और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।  
यह कोड एक PowerPoint से PDF रूपांतरण प्रक्रिया को दर्शाता है जो विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करता है:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF रूपांतरण कार्यों का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल फ़ॉर्मेट में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF से JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण कार्य विशेष फ़ॉर्मेट—[PDF से SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/)—के लिए भी समर्थित हैं।  
{{% /alert %}}

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफिक जैसे SmartArt, चार्ट, और सूत्र को एकल फ़िगर के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरे फ़िगर के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को बल्क में PDF में परिवर्तित कर सकता हूँ?**  
हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटरट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड से संरक्षित किया जा सकता है?**  
हां। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस परमिशन परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी हुई स्लाइड्स को कैसे शामिल करूँ?**  
[PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास में `true` के साथ [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) को कॉल करें ताकि परिणामस्वरूप PDF में छिपी हुई स्लाइड्स शामिल हों।

**क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?**  
हां, आप अपने PDF में उच्च गुणवत्ता वाली छवियों को सुनिश्चित करने के लिए [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) और [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) जैसी विधियों का उपयोग करके इमेज क्वालिटी नियंत्रित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**  
हां, Aspose.Slides आपको ऐसे PDF निर्यात करने की अनुमति देता है जो [विभिन्न मानक](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) के अनुरूप हों, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ पहुँच और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Node.js via Java दस्तावेज़](/slides/hi/nodejs-java/)
- [Aspose.Slides for Node.js via Java API संदर्भ](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर्स](https://products.aspose.app/slides/conversion)