---
title: जावास्क्रिप्ट में प्रस्तुतियों को पासवर्ड‑प्रोटेक्ट करें
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
- प्रस्तुति पासवर्ड जाँचें
- एन्क्रिप्टेड प्रस्तुति खोलें
- एन्क्रिप्शन हटाएँ
- PowerPoint
- PPT
- PPTX
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides के साथ जावास्क्रिप्ट में पासवर्ड‑सुरक्षित PowerPoint PPT और PPTX प्रस्तुतियों को एन्क्रिप्ट, पता लगाएँ, सत्यापित, खोलें और डिक्रिप्ट करें।"
---
## **अवलोकन**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है। सही पासवर्ड आवश्यक होता है प्रस्तुति सामग्री को लोड और देखने के लिये, इसलिए यह सुरक्षा गोपनीयता प्रदान करती है।

एक खोलने वाला पासवर्ड लिखने‑रोकथाम पासवर्ड से अलग होता है। लिखने‑रोकथाम संशोधन को सीमित करता है लेकिन सामग्री को एन्क्रिप्ट नहीं करता या प्रस्तुति को लोड होने से नहीं रोकता। प्रस्तुतियों को संशोधित करने के पासवर्ड प्रबंधित करने के लिये देखें [Write-Protect Presentations](/slides/hi/nodejs-java/write-protected-presentation/)।

नीचे दिया गया वर्कफ़्लो दोनों PPT और PPTX प्रस्तुतियों पर लागू होता है। उदाहरण दोनों फ़ॉर्मेट का उपयोग करते हैं जहाँ फ़ाइल‑आधारित और स्ट्रीम‑आधारित व्यवहार महत्वपूर्ण होते हैं।

## **खोलने वाले पासवर्ड के साथ प्रस्तुति को एन्क्रिप्ट करें**

एक खोलने वाला पासवर्ड असाइन करने के लिये [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#encrypt) का उपयोग करें। फिर एन्क्रिप्टेड प्रस्तुति को सहेजने के लिये [Presentation.save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्नलिखित उदाहरण एक PPTX प्रस्तुति को एन्क्रिप्ट करता है:

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

## **डॉक्यूमेंट प्रॉपर्टीज़ को सार्वजनिक रखें**

डिफ़ॉल्ट रूप से, Aspose.Slides प्रस्तुति एन्क्रिप्शन में डॉक्यूमेंट प्रॉपर्टीज़ को शामिल करता है। यह व्यवहार स्लाइड‑कंटेंट एन्क्रिप्शन से स्वतंत्र रूप से नियंत्रित करने के लिये [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) मेथड का उपयोग करें। जब इंडेक्सिंग, वर्गीकरण, खोज या डॉक्यूमेंट‑मैनेजमेंट सिस्टम को खोलने वाला पासवर्ड बिना मेटाडेटा पढ़ना आवश्यक हो, तो [ProtectionManager.encrypt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#encrypt) को कॉल करने से पहले `false` पास करें।

निम्नलिखित उदाहरण एक एन्क्रिप्टेड PPTX प्रस्तुति बनाता है जबकि उसकी निर्मित डॉक्यूमेंट प्रॉपर्टीज़ को सार्वजनिक रखता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) को `false` पास करने से स्लाइड, मास्टर, लेआउट, शैप, मीडिया या अन्य प्रस्तुति सामग्री सार्वजनिक नहीं होते। यह केवल डॉक्यूमेंट प्रॉपर्टीज़ को प्रभावित करता है। उन प्रॉपर्टीज़ को एन्क्रिप्टेड सामग्री लोड किए बिना पढ़ने के लिये देखें [Manage Presentation Properties](/slides/hi/nodejs-java/presentation-properties/)।

## **एन्क्रिप्टेड प्रस्तुति लोड करें**

फ़ाइल लोड करते समय खोलने वाला पासवर्ड निर्दिष्ट करने के लिये [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) को सेट करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) को पास करें। यदि खोलने वाला पासवर्ड आवश्यक है लेकिन प्रदान किया गया पासवर्ड अनुपस्थित या गलत है तो लोडिंग विफल हो जाएगी।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // डिक्रिप्ट की गई प्रस्तुति के साथ काम करें।
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति से एन्क्रिप्शन हटाएँ**

प्रस्तुति को उसके खोलने वाले पासवर्ड के साथ लोड करें, फिर [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) को कॉल करें और परिणाम सहेजें। सहेजी गई प्रस्तुति अब बिना पासवर्ड के लोड की जा सकती है।

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

## **लोड करने से पहले खोलने वाले पासवर्ड की जांच करें**

एक पूर्ण प्रस्तुति इंस्टेंस बनाए बिना [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) प्राप्त करें। पासवर्ड का अनुरोध या वैधता करने से पहले [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) की जाँच करें। जब सुरक्षा उपस्थित हो, तो प्रदान किए गए मान को [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) से वैध करें।

### **फ़ाइल‑पाथ वर्कफ़्लो**

निम्नलिखित उदाहरण PPTX फ़ाइल के लिये खोलने वाले पासवर्ड को वैध करता है, वैध मान को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) को पास करता है, और फिर पूरी प्रस्तुति को लोड करता है:

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

### **स्ट्रीम वर्कफ़्लो**

Node.js रीडेबल स्ट्रीम का निरीक्षण करने के लिये [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) का उपयोग करें। निरीक्षण के बाद स्ट्रीम का उपयोग समाप्त हो जाता है, इसलिए पूरी प्रस्तुति को [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) से लोड करने से पहले नई स्ट्रीम बनाएँ।

निम्नलिखित उदाहरण एक PPT फ़ाइल का उपयोग करता है:

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) केवल तभी `true` लौटाता है जब प्रस्तुति में खोलने वाला पासवर्ड हो और प्रदान किया गया पासवर्ड सही हो। यह प्रत्येक निम्नलिखित स्थितियों में `false` लौटाता है:

- पासवर्ड गलत है।
- प्रस्तुति में खोलने वाला पासवर्ड नहीं है।
- प्रदान किया गया पासवर्ड `null` या खाली है।

व्यवहार PPT और PPTX दोनों प्रस्तुतियों के लिये समान रहता है।

## **जाँचें कि लोड की गई प्रस्तुति एन्क्रिप्टेड है या नहीं**

सही पासवर्ड के साथ प्रस्तुति लोड करने के बाद, यह पुष्टि करने के लिये [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) का निरीक्षण करें कि स्रोत प्रस्तुति एन्क्रिप्टेड थी। लोड करने से पहले खोलने‑पासवर्ड सुरक्षा का पता लगाने के लिये ऊपर दर्शाए अनुसार [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) का उपयोग करें।

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
खोलने वाले पासवर्ड को लॉग न करें या उन्हें डायग्नोस्टिक संदेशों में शामिल न करें। अनावश्यक दोहराए हुए वैधता प्रयासों से बचें, पासवर्ड को केवल आवश्यक अवधि तक मेमोरी में रखें, और तुरंत प्रस्तुति लोड करते समय सफल वैधता परिणाम को पुन: उपयोग करें।

सार्वजनिक डॉक्यूमेंट प्रॉपर्टीज़ में लेखक का नाम, शीर्षक, विषय, कीवर्ड, कंपनी की जानकारी, टिप्पणी और कस्टम मान शामिल हो सकते हैं जबकि प्रस्तुति सामग्री एन्क्रिप्टेड हो। संवेदनशील मेटाडेटा को प्रस्तुति के साथ एन्क्रिप्ट करें। प्रॉपर्टीज़ को सार्वजनिक रखने का निर्णय केवल तभी लेना चाहिए जब सिस्टम को फ़ाइल को इंडेक्स, वर्गीकृत, खोज या प्रबंधित करने के लिये खोलने वाला पासवर्ड आवश्यक न हो।
{{% /alert %}}

## **ऑनलाइन प्रस्तुति को पासवर्ड‑प्रोटेक्ट करें**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/hi/lock) एप्लिकेशन खोलें।
2. प्रस्तुति चुनें या अपलोड करें।
3. दृश्य सुरक्षा के लिये पासवर्ड दर्ज करें।
4. वैकल्पिक रूप से संपादन सुरक्षा के लिये अलग पासवर्ड दर्ज करें।
5. सुरक्षा लागू करें और परिणामस्वरूप फ़ाइल डाउनलोड करें।

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/hi/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**खोलने वाले पासवर्ड और लिखने‑रोकथाम पासवर्ड में क्या अंतर है?**

एक खोलने वाला पासवर्ड प्रस्तुति को एन्क्रिप्ट करता है और उसका कंटेंट लोड करने के लिये आवश्यक होता है। लिखने‑रोकथाम पासवर्ड सामग्री को एन्क्रिप्ट किए बिना संशोधन को प्रतिबंधित करता है।

**क्या मैं सभी स्लाइड्स लोड किए बिना खोलने वाले पासवर्ड की वैधता कर सकता हूँ?**

हाँ। प्रस्तुति जानकारी प्राप्त करें, जांचें कि खोलने‑पासवर्ड सुरक्षा मौजूद है या नहीं, और पूर्ण प्रस्तुति इंस्टेंस बनाने से पहले पासवर्ड को वैध करें।

**क्या एप्लिकेशन खोलने वाले पासवर्ड के बिना मेटाडेटा पढ़ सकता है?**

हाँ, लेकिन केवल तब जब डॉक्यूमेंट‑प्रॉपर्टी एन्क्रिप्शन अक्षम हो। तब एप्लिकेशन को [Manage Presentation Properties](/slides/hi/nodejs-java/presentation-properties/) में वर्णित डॉक्यूमेंट‑प्रॉपर्टी‑सिर्फ लोड मोड का उपयोग करना होगा।

**क्या पासवर्ड‑जांच वर्कफ़्लो दोनों PPT और PPTX को सपोर्ट करता है?**

हाँ। फ़ाइल‑पाथ और स्ट्रीम‑आधारित पासवर्ड डिटेक्शन तथा वैधता दोनों PPT और PPTX प्रस्तुतियों के लिये समान रूप से व्यवहार करती है।