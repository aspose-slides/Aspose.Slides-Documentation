---
title: जावास्क्रिप्ट में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रस्तुति गुण
type: docs
weight: 70
url: /hi/nodejs-java/presentation-properties/
keywords:
- PowerPoint गुण
- प्रस्तुति गुण
- दस्तावेज़ गुण
- बिल्ट‑इन गुण
- कस्टम गुण
- उन्नत गुण
- गुणों का प्रबंधन
- गुणों का संशोधन
- दस्तावेज़ मेटाडाटा
- मेटाडाटा संपादित करें
- प्रूफ़िंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में प्रस्तुति गुणों को मास्टर करें और अपने PowerPoint और OpenDocument फ़ाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सुव्यवस्थित करें।"
---
## **परिचय**

Aspose.Slides for Node.js via Java **built-in** और **custom** दस्तावेज़ गुणों का समर्थन करता है। इन गुणों का उपयोग प्रस्तुति मेटाडाटा को पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता‑परिभाषित मान।

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की सुविधा देता है [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) क्लास के माध्यम से। इस क्लास की एक इंस्टेंस [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) द्वारा वापस मिलती है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ें, संशोधित करें और प्रबंधित करें।

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुतियों को सहेजते समय एप्लिकेशन और प्रोड्यूसर मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड उस सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया।
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में विभाजित होते हैं:

- **Built-in properties** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ सांख्यिकी।
- **Custom properties** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।

Aspose.Slides for Node.js via Java दोनों श्रेणियों तक पहुँच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा देखनी के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का प्रयोग करें।

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक ओपनिंग पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुण दोनों की रक्षा करता है। जब एक प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रह जाते हैं। तब कोई एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल कर सकता है और ओपनिंग पासवर्ड प्रदान किए बिना सार्वजनिक मेटाडेटा पढ़ सकता है।

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) निर्धारित करता है कि Aspose.Slides क्या लोड करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प नज़रअंदाज़ हो जाता है और पूरी प्रस्तुति लोड की जाती है।

उदाहरण के लिए एक एन्क्रिप्टेड प्रस्तुति चाहिए जिसकी दस्तावेज़ गुण सार्वजनिक रखी गई हों। यह लोडिंग मोड को [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) के माध्यम से सत्यापित करता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) के द्वारा बिल्ट‑इन गुण पढ़ता है:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड, मास्टर, लेआउट, शैप, मीडिया और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं होतीं। एप्लिकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) की जाँच करनी चाहिए इससे पहले कि वह ऐसी कार्रवाई करे जिसे पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता हो।

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा लेखक के नाम, शीर्षक, विषय, कुंजीशब्द, कंपनी जानकारी, टिप्पणी और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड के बिना उनकी आवश्यकता हो।
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुणों को अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के उद्देश्य से होती है। Aspose.Slides उस केवल‑मेटाडेटा ऑब्जेक्ट से बदले गए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर के संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही ओपनिंग पासवर्ड और पूरी लोड आवश्यक है।

उदाहरण के लिए एक एन्क्रिप्टेड PPTX प्रस्तुति चाहिए जिसमें सार्वजनिक दस्तावेज़ गुण और ज्ञात ओपनिंग पासवर्ड हो। यह पूरी प्रस्तुति को [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) के साथ खोलता है, सार्वजनिक बिल्ट‑इन गुणों को अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) का उपयोग करके एन्क्रिप्शन अनुकूलता की जाँच करता है और पासवर्ड के बिना सार्वजनिक मेटाडेटा को पुनः खोलकर नई मानों की पुष्टि करता है:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

यदि कोई एप्लिकेशन प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं रखता, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।

## **बिल्ट‑इन गुणों तक पहुँच**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) क्लास गेटर मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा प्रदान करती है, जैसे [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), और [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). यह उदाहरण एक मौजूदा प्रस्तुति खोलकर उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड खाली हो सकते हैं।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **संस्करण संख्या और संपादन समय रिपोर्ट करें**

`presentations` फ़ोल्डर में प्रत्येक PPTX फ़ाइल के लिए संस्करण संख्या और कुल संपादन समय रिपोर्ट करने के लिए, [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) का उपयोग करें। यह स्लाइड्स को लोड किए बिना फ़ाइल के [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) लौटाता है। उदाहरण दर्ज अवधि को मिलीसेकंड से घंटे, मिनट और सेकंड में बदलता है। 24 घंटे या अधिक की अवधि के लिए, यह समय के पहले पूर्ण दिनों की संख्या जोड़ता है।

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

यदि किसी प्रस्तुति का रिकॉर्ड किया गया संपादन समय 1 दिन, 2 घंटे, और 5 मिनट है, तो रिपोर्ट में निम्नलिखित आउटपुट दिखाया जाता है।

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) एक मान पढ़ता है जिसे एप्लिकेशन [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) के साथ बदल सकते हैं। केवल संस्करण संख्या यह निर्धारित नहीं कर सकती कि प्रस्तुति कितनी बार सहेजी गई या उसके संस्करण इतिहास को पुनः निर्मित कर सकती है।

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) फ़ाइल में रिकॉर्ड किए गए संपादन अवधि को पढ़ता है। `00:00:00` का मान दर्शाता है कि संग्रहीत अवधि शून्य है, भले ही किसी ने प्रस्तुति को संपादित किया हो।

## **बिल्ट‑इन गुणों को संशोधित करें**

बिल्ट‑इन मेटाडेटा को अपडेट करने के लिए, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) द्वारा लौटाए गए ऑब्जेक्ट पर सेट्टर मेथड्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments), और [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) को कॉल करता है, फिर अपडेटेड प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) के साथ सहेजता है। सहेजा गया PPTX नई मेटाडेटा रखता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **हाइपरलिंक बेस का प्रबंधन**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) सापेक्ष हाइपरलिंक के लिए दस्तावेज़‑स्तर बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) का उपयोग करें। यह उपयोगी है जब आप प्रस्तुति और उसकी लिंक्ड फ़ाइलों को किसी अन्य स्थान पर ले जाते हैं। यह व्यक्तिगत हाइपरलिंक के [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) से अलग है: बेस बदलने से संग्रहीत लिंक पते पुनः नहीं लिखे जाते या निरपेक्ष गंतव्य नहीं बदलते।

उदाहरण के लिए एक प्रस्तुति चाहिए जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक निरपेक्ष लिंक, जैसे `https://example.org/absolute.html` हो। यह मौजूदा बेस पढ़ता है, नया बेस पता निर्धारित करता है, और मान जाँचने के लिए प्रस्तुति को सहेजता और पुनः खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी गई फ़ाइल में खाली मान की पुष्टि करता है। उदाहरण बेस पते को अपने लिंक्ड फ़ाइलों के स्थान से बदलें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

दोनों सत्यापन संदेश `true` प्रदर्शित करेंगे। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते वही रहते हैं।

`target.pptx` के सापेक्ष लिंक ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा कर रहा था। बेस को `new` फ़ोल्डर में बदलने, सहेजने और प्रस्तुति को पुनः खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या उसके बेस को बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण मेटाडेटा संग्रहीत करते हैं जिसका कोई संबंधित बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) मेथड आपको गुण नाम द्वारा मान निर्धारित करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और प्रस्तुति को [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) के साथ सहेजता है। मौजूदा नाम को मान सौंपने से उस गुण का मान बदल जाता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **कस्टम गुणों तक पहुँच और संशोधन**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और उन पर पुनरावृति करने के लिए [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) का उपयोग करता है। [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) शून्य‑आधारित इंडेक्स लेता है और वह नाम लौटाता है जिसे [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) ने उपयोग किया था। उदाहरण प्रत्येक मूल नाम और मान को प्रिंट करता है, प्रत्येक मान को उसके मूल प्रकार की परवाह किए बिना क्रमांकित स्ट्रिंग से बदल देता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं है, तो लूप कोई परिवर्तन नहीं करता।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लाइव उदाहरण**

Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ कैसे काम करें, यह देखने के लिए ऑनलाइन ऐप [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) आज़माएँ:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटा सकता हूँ?**

बिल्ट‑इन गुण प्रस्तुति का अभिन्न भाग होते हैं और उन्हें पूरी तरह हटाया नहीं जा सकता। हालांकि, आप उनके मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता हो तो उन्हें खाली सेट कर सकते हैं।

**यदि मैं ऐसा कस्टम गुण जोड़ूँ जो पहले से मौजूद है तो क्या होगा?**

यदि आप ऐसा कस्टम गुण जोड़ते हैं जो पहले से मौजूद है, तो उसका मौजूदा मान नए मान से अधिलेखित हो जाएगा। आपको पहले गुण को हटाने या जांचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण के मान को अपडेट करता है।

**क्या मैं प्रस्तुति को पूरी तरह लोड किए बिना उसके गुणों तक पहुँच सकता हूँ?**

हां। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) का उपयोग करें और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) को कॉल करके संग्रहीत दस्तावेज़ मेटाडेटा को बिना [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) इंस्टेंस बनाए पढ़ें। पूर्ण रिपोर्टिंग उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/nodejs-java/examine-presentation/)।

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को बिना ओपनिंग पासवर्ड के पढ़ सकता हूँ?**

हां। प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया गया होना चाहिए, और इसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करके लोड किया गया होना चाहिए।

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**

नह। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही ओपनिंग पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।