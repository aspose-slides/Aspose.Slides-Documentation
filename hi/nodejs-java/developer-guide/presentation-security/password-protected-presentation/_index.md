---
title: JavaScript में प्रस्तुतियों को पासवर्ड‑प्रोटेक्ट करें
linktitle: पासवर्ड सुरक्षा
type: docs
weight: 20
url: /hi/nodejs-java/password-protected-presentation/
keywords:
- पासवर्ड‑सुरक्षित प्रस्तुति
- खोलने वाला पासवर्ड
- PowerPoint एन्क्रिप्ट करें
- PowerPoint डिक्रिप्ट करें
- प्रस्तुति पासवर्ड सत्यापित करें
- प्रस्तुति पासवर्ड जांचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में Aspose.Slides के साथ पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पहचान, सत्यापित, खोलें और डिक्रिप्ट करें."
---
## **अवलोकन**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सामग्री को लोड और देखने के लिए सही पासवर्ड आवश्यक है, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने‑सुरक्षा पासवर्ड से अलग होता है। राइट प्रोटेक्शन संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों में संशोधन के पासवर्ड प्रबंधन के लिए देखें [Write-Protect Presentations](/slides/hi/nodejs-java/write-protected-presentation/)।

नीचे दिए गए कार्यप्रवाह दोनों PPT और PPTX प्रस्तुतियों पर लागू होते हैं। उदाहरण दोनों फ़ॉर्मैट का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण है।

## **एक खोलने वाले पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

एक खोलने वाला पासवर्ड सौंपने के लिए [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#encrypt) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्नलिखित उदाहरण PPTX प्रस्तुति को एन्क्रिप्ट करता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय खोलने वाले पासवर्ड को सेट करने के लिए [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) को सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) को पास करें। जब खोलने वाला पासवर्ड आवश्यक हो लेकिन प्रदान किया गया पासवर्ड अनुपलब्ध या गलत हो, तो लोडिंग विफल हो जाएगी।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें.
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके खोलने वाले पासवर्ड से लोड करें, [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) को कॉल करें, और परिणाम को सहेजें। सहेजी गई प्रस्तुति को फिर पासवर्ड के बिना लोड किया जा सकता है।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लोड करने से पहले खोलने वाले पासवर्ड को सत्यापित करें**

पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) प्राप्त करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करें। पासवर्ड का अनुरोध या सत्यापन करने से पहले [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) को जाँचें। यदि सुरक्षा मौजूद है, तो प्रदान किए गए मान को [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) से सत्यापित करें।

### **फ़ाइल‑पथ कार्यप्रवाह**

निम्नलिखित उदाहरण PPTX फ़ाइल के लिए खोलने वाला पासवर्ड सत्यापित करता है, सत्यापित मान को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) को पास करता है, और फिर पूर्ण प्रस्तुति को लोड करता है:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **स्ट्रीम कार्यप्रवाह**

Node.js पढ़ने योग्य स्ट्रीम का निरीक्षण करने के लिए [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) का उपयोग करें। निरीक्षण स्ट्रीम को उपभोग करने के बाद, [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) के साथ पूर्ण प्रस्तुति लोड करने से पहले नई स्ट्रीम बनाएँ।

निम्नलिखित उदाहरण PPT फ़ाइल का उपयोग करता है:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword रिटर्न वैल्यूज़**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) केवल तभी `true` लौटाता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह निम्नलिखित मामलों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या ख़ाली है।

यह व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिए समान है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, स्रोत प्रस्तुति एन्क्रिप्टेड थी या नहीं, यह पुष्टि करने के लिए [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) को जांचें। लोड करने से पहले खोलने‑पासवर्ड सुरक्षा का पता लगाने के लिए ऊपर दिखाए अनुसार [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) का उपयोग करें।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **सुरक्षा अनुशंसाएँ**

{{% alert color="warning" title="Security" %}}
खोलने वाले पासवर्ड को लॉग न करें या उन्हें निदान संदेशों में शामिल न करें। अनावश्यक बार‑बार सत्यापन प्रयासों से बचें, पासवर्ड को केवल आवश्यक समय तक मेमोरी में रखें, और प्रस्तुति को तुरंत लोड करते समय सफल सत्यापन परिणाम को पुनः उपयोग करें।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. दृश्य सुरक्षा के लिए पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिए अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामी फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [प्रस्तुतियों को राइट‑प्रोटेक्ट करें](/slides/hi/nodejs-java/write-protected-presentation/)
- [PowerPoint में डिजिटल सिग्नेचर](/slides/hi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**खोलने वाले पासवर्ड और लिखन‑सुरक्षा पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसकी सामग्री लोड करने के लिए आवश्यक होता है। लिखन‑सुरक्षा पासवर्ड संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता।

**क्या मैं सभी स्लाइड्स लोड किए बिना खोलने वाले पासवर्ड को सत्यापित कर सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, जाँचें कि खुलने वाले पासवर्ड की सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड सत्यापित करें।

**क्या पासवर्ड‑जाँच कार्यप्रवाह दोनों PPT और PPTX को समर्थन देते हैं?**

हाँ। फ़ाइल‑पथ और स्ट्रीम‑आधारित पासवर्ड पहचान व सत्यापन दोनों PPT और PPTX प्रस्तुतियों के लिए समान ढंग से कार्य करते हैं।