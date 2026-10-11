---
title: JavaScript में नोट्स पेज आकार और अभिविन्यास बदलें
linktitle: नोट्स पेज आकार
type: docs
weight: 10
url: /hi/nodejs-java/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिविन्यास
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रेजेंटेशन
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में Java के द्वारा नोट्स पेज के आयाम पढ़ें और बदलें, अभिविन्यास स्विच करें, सहेजे गये आकार सत्यापित करें, और नोट्स या हैंडआउट को PDF और इमेज में निर्यात करें।"
---
## **अवलोकन**

प्रेजेंटेशन की नोट्स पेज सेटिंग्स तक पहुँचने के लिए [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getnotessize/) का उपयोग करें। यह एक [NotesSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notessize/) ऑब्जेक्ट लौटाता है जिसका [setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notessize/setsize/) मेथड पेज के आयाम सेट करता है। हालांकि सेटिंग्स ऑब्जेक्ट को बदला नहीं जा सकता, आप इस मेथड के माध्यम से नए आयाम असाइन कर सकते हैं।

चौड़ाई और ऊँचाई **पॉइंट्स** में निर्दिष्ट की जाती है, जहाँ 1 इंच में 72 पॉइंट्स होते हैं। उदाहरण के लिए, 900 × 600 पॉइंट्स 12.5 × 8⅓ इंच के बराबर है। ये सेटिंग्स प्रेजेंटेशन पर लागू होती हैं, न कि व्यक्तिगत स्लाइड के नोट्स पर।

| सेटिंग | उद्देश्य |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getnotessize/) | नोट्स पेज के आयाम और हैंडआउट निर्यात के लिए उपयोग किए जाने वाले पेज आयाम को नियंत्रित करता है। |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslidesize/) | [SlideSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/) के माध्यम से सामान्य प्रेजेंटेशन स्लाइड के आयाम को नियंत्रित करता है। |

इनमें से किसी भी सेटिंग को बदलने से दूसरे को स्वतः नहीं बदलता। नोट्स पेज की अभिविन्यास बदलने से नियमित स्लाइड्स नहीं घुमतीं। नियमित स्लाइड्स का आकार बदलने के लिए देखें [Slide Size](/slides/hi/nodejs-java/slide-size/)।

नीचे के उदाहरण मौजूदा `sample.pptx` का उपयोग करते हैं। निर्यात उदाहरणों के लिए, कम से कम एक स्लाइड जिसमें वक्ता नोट्स हों, वाली प्रेजेंटेशन का उपयोग करें। प्रत्येक उदाहरण को स्वतंत्र रूप से चलाया जा सकता है।

## **नोट्स पेज का आकार और अभिविन्यास पढ़ें**

चौड़ाई और ऊँचाई पढ़ें और तुलना करके अभिविन्यास निर्धारित करें: चौड़ा पेज लैंडस्केप होता है, लंबा पेज पोर्ट्रेट होता है, और समान आयाम वाला पेज वर्गाकार पेज दर्शाता है। यह उदाहरण वास्तविक आयाम पॉइंट्स में प्रिंट करता है, बिना किसी मानक कागज़ आकार को मानते हुए।

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **पेपर आकार बदले बिना लैंडस्केप में स्विच करें**

केवल अभिविन्यास बदलने के लिए, मौजूदा चौड़ाई और ऊँचाई को अदला-बदली करें। इससे दोनों पक्षों की लंबाई बनी रहती है, जिसमें कस्टम पेपर आकार की लंबाई भी शामिल है। नीचे की शर्त पहले से लैंडस्केप पेज को पोर्ट्रेट में बदलने से रोकती है और वर्गाकार पेज को अपरिवर्तित छोड़ती है।

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

पोर्ट्रेट अभिविन्यास के लिए, वही असाइनमेंट उपयोग करें जब `size.getWidth() > size.getHeight()` हो। जब तक आप पेपर आकार भी बदलना नहीं चाहते, तब तक A4 या लेटर आयामों को प्रतिस्थापित न करें।

## **कस्टम नोट्स पेज आकार सेट करें और सत्यापित करें**

दोनों आयाम एक साथ असाइन करें, फिर प्रेजेंटेशन को लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/save/) का उपयोग करें। यह उदाहरण 900 × 600 पॉइंट्स लैंडस्केप पेज सेट करता है, इसे PPTX के रूप में सहेजता है, और सहेजी गई फ़ाइल को फिर से खोलकर संरक्षित मानों की जांच करता है। तुलना फ़्लोटिंग‑पॉइंट मानों के लिए 0.01 पॉइंट सहनशीलता की अनुमति देती है; यह प्रत्येक फ़ाइल फ़ॉर्मेट के लिए सटीकता की गारंटी नहीं है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

अपेक्षित परिणाम `900 x 600 points` और `Size preserved: true` है। एक नई खोली गई प्रेजेंटेशन की जाँच सहेजी गई फ़ाइल को सत्यापित करती है, न कि केवल मेमोरी में रखी सेटिंग्स को।

## **नोट्स और हैंडआउट निर्यात**

पेज आयाम नोट्स या हैंडआउट लेआउट के लिए उपलब्ध क्षेत्र को निर्धारित करते हैं। वे स्वयं वह लेआउट सक्षम नहीं करते: निर्यात विकल्पों को भी कॉन्फ़िगर करें। नियमित स्लाइड निर्यात स्लाइड आयामों को उपयोग करता रहता है।

### **PDF और PNG में नोट्स निर्यात**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) को [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) में असाइन करें ताकि PDF में नोट्स शामिल हों। यह उदाहरण पहले स्लाइड को नोट्स के साथ PNG में रेंडर करता है, [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) और [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/) का उपयोग करके।

[BottomTruncated](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notespositions/) मोड नोट्स को एक पेज पर रखता है; जो नोट्स फिट नहीं होते उन्हें ट्रंकेट किया जा सकता है। PDF 900 × 600‑पॉइंट पेजों का उपयोग करता है। नीचे उपयोग किए गए 1 × 1 इमेज स्केल पर PNG 900 × 600 पिक्सेल है। पॉइंट्स पेज ज्यामिति को वर्णित करते हैं; पिक्सेल रास्टर आउटपुट को वर्णित करते हैं, जिनके आयाम रेंडरिंग स्केल पर भी निर्भर करते हैं।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

लंबे नोट्स वाले PDF निर्यात के लिए, [BottomFull](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notespositions/) आवश्यकता अनुसार अतिरिक्त पेजों की अनुमति देता है। उपरोक्त सिंगल‑स्लाइड इमेज कॉल के साथ इस मोड का उपयोग न करें, क्योंकि यह इसे समर्थन नहीं करता। री‑साइज़ करने के बाद, क्लिप्ड नोट्स और मौजूदा notes‑master ऑब्जेक्ट्स की स्थिति के लिए आउटपुट की जाँच करें; केवल पेज आयाम बदलना यह गारंटी नहीं है कि सभी सामग्री फिट होगी। नोट्स निर्यात के बारे में अधिक जानकारी के लिए देखें [Convert PowerPoint to PDF with Notes](/slides/hi/nodejs-java/convert-powerpoint-to-pdf-with-notes/)।

### **PDF में हैंडआउट निर्यात**

एक पेज पर कई स्लाइड थंबनेल के लिए [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handoutlayoutingoptions/) का उपयोग करें। निम्न उदाहरण 900 × 600‑पॉइंट पेज सेट करता है और [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/handouttype/) का उपयोग करके प्रति पेज अधिकतम चार स्लाइड व्यवस्थित करता है। हॉरिज़ंटल प्रीसेट स्लाइड क्रम को नियंत्रित करता है; पेज अभिविन्यास उसकी चौड़ाई और ऊँचाई से निर्धारित होता है।

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

पेज आकार बदलने से हैंडआउट ग्रिड के उपलब्ध क्षेत्र में परिवर्तन होता है, जबकि स्रोत स्लाइड के आयाम नहीं बदलते। हैंडआउट इमेज के लिए, व्यक्तिगत स्लाइड की इमेज मेथड के बजाय हैंडआउट लेआउट के साथ [Presentation.getImages](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getimages/) का उपयोग करें। Aspose.Slides में, प्रेजेंटेशन‑लेवल हैंडआउट रेंडरिंग नोट्स पेज आयामों का उपयोग करती है, जबकि व्यक्तिगत स्लाइड इमेज कॉल हैंडआउट पेज नहीं बनाती। लेआउट विकल्पों के लिए देखें [Handout Mode](/slides/hi/nodejs-java/convert-powerpoint-in-handout-mode/)।

## **व्यूअर्स, निर्यात और प्रिंटिंग में पेज आकार**

संग्रहीत प्रेजेंटेशन आकार, निर्यात पेज आकार और प्रिंटेड पेपर आकार को अलग रखें:

- **प्रेजेंटेशन व्यूअर्स:** एक व्यूअर अपने स्वयं के लेआउट नियमों का उपयोग करके नोट्स प्रदर्शित या प्रिंट कर सकता है। यदि कोई अन्य एप्लिकेशन फ़ाइल सहेजता है, तो उसे फिर से खोलें और आयाम दोबारा जांचें; उस एप्लिकेशन का फ़ॉर्मेट परिवर्तन उन्हें सामान्य कर सकता है।
- **Export formats:** ऊपर दिए गए नोट्स और हैंडआउट PDF उदाहरण कॉन्फ़िगर किए गए पेज आयामों का उपयोग करते हैं। रास्टर इमेज पूर्णांक पिक्सेल आयाम और रेंडरिंग स्केल का उपयोग करती हैं, इसलिए चित्र आउटपुट में अंशीय पॉइंट मान राउंड किए जा सकते हैं। नियमित स्लाइड निर्यात नोट्स पेज आकार को लागू नहीं करता।
- **Printer drivers:** पेपर चयन, स्वतः घुमाव, और फिट‑टू‑पेज सेटिंग्स भौतिक आउटपुट को बदल सकती हैं बिना प्रेजेंटेशन या PDF में संग्रहीत आयामों को बदले। किसी विशिष्ट पेपर आकार के लिए, प्रिंटर सेटिंग्स मेल करें और प्रिंट प्रीव्यू जांचें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल एक स्लाइड के लिए नोट्स आकार सेट कर सकता हूँ?**

नोट्स पेज आकार एक प्रेजेंटेशन‑स्तर की सेटिंग है। व्यक्तिगत स्लाइड के पास अलग नोट्स सामग्री हो सकती है, लेकिन यह प्रॉपर्टी प्रत्येक स्लाइड के लिए अलग पेज आकार प्रदान नहीं करती।

**नोट्स अभिविन्यास बदलने से मेरे स्लाइड्स क्यों नहीं बदले?**

नोट्स पेज और सामान्य स्लाइड के आयाम स्वतंत्र होते हैं। यदि आप स्वयं स्लाइड्स का आकार बदलना चाहते हैं तो सामान्य स्लाइड आकार सेटिंग्स का उपयोग करें।

**मेरे सहेजे या प्रिंट किए गए परिणाम का आकार अलग क्यों है?**

पहले सहेजी गई प्रेजेंटेशन को फिर से खोलें और उसके नोट्स आयामों की तुलना करें। यदि वे बदले हैं, तो देखें कि किसी अन्य एप्लिकेशन में फ़ाइल सहेजने या परिवर्तित करने से पेज सेटिंग्स बदल गईं या नहीं। यदि नहीं बदले, तो निर्यात लेआउट, इमेज स्केल, व्यूअर सेटिंग्स और प्रिंटर पेपर चयन की जाँच करें।