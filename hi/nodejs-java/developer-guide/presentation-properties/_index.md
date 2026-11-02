---
title: जावास्क्रिप्ट में प्रस्तुति गुणों का प्रबंधन
linktitle: प्रेज़ेंटेशन गुण
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
- गुण प्रबंधन
- गुण संशोधन
- दस्तावेज़ मेटाडेटा
- मेटाडेटा संपादन
- प्रूफिंग भाषा
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: Aspose.Slides for Node.js via Java में प्रस्तुति गुणों को पूरी तरह नियंत्रित करें और अपने PowerPoint और OpenDocument फाइलों में खोज, ब्रांडिंग और कार्यप्रवाह को सहज बनाएं।
---
## **परिचय**

Aspose.Slides for Node.js via Java **बिल्ट‑इन** और **कस्टम** दस्तावेज़ गुणों को समर्थन देता है। इन गुणों का उपयोग प्रस्तुति मेटाडेटा को पढ़ने और अपडेट करने के लिए करें, जैसे लेखक, शीर्षक, और उपयोगकर्ता द्वारा परिभाषित मान।  

Aspose.Slides आपको प्रस्तुति दस्तावेज़ गुणों के साथ काम करने की अनुमति देता है [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) वर्ग के माध्यम से। इस वर्ग का एक उदाहरण [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) द्वारा लौटाया जाता है। नीचे दिए गए उदाहरण दिखाते हैं कि इन गुणों को कैसे पढ़ा, संशोधित और प्रबंधित किया जाए।  

{{% alert color="info" title="Note" %}}
Aspose.Slides प्रस्तुति सहेजते समय एप्लिकेशन और निर्माता मेटाडेटा को प्रबंधित करता है; ये फ़ील्ड सॉफ़्टवेयर की पहचान करती हैं जिसने आउटपुट बनाया है।  
{{% /alert %}}

## **प्रस्तुति गुणों का प्रबंधन**

दस्तावेज़ गुण प्रस्तुति सामग्री के साथ वर्णनात्मक जानकारी संग्रहीत करते हैं। वे दो श्रेणियों में विभाजित होते हैं:

- **बिल्ट‑इन गुण** मानक मेटाडेटा रखते हैं, जैसे शीर्षक, लेखक, और दस्तावेज़ आँकड़े।  
- **कस्टम गुण** उपयोगकर्ता‑परिभाषित नाम/मान युग्म संग्रहीत करते हैं।  

Aspose.Slides for Node.js via Java दोनों श्रेणियों तक पहुंच प्रदान करता है। PowerPoint में, दस्तावेज़ मेटाडेटा जांचने के लिए **File → Info → Properties → Advanced Properties** चुनें। संवाद बॉक्स जानकारी को **Summary**, **Statistics**, **Contents**, और **Custom** जैसे टैब में समूहित करता है। उपयोगकर्ता‑परिभाषित गुणों का प्रबंधन करने के लिए **Custom** टैब का उपयोग करें।  

## **एन्क्रिप्टेड प्रस्तुति से सार्वजनिक गुण पढ़ें**

एक खोलने वाला पासवर्ड सामान्यतः प्रस्तुति सामग्री और दस्तावेज़ गुण दोनों की रक्षा करता है। जब किसी प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया जाता है, तो उसके दस्तावेज़ गुण सार्वजनिक रहते हैं। फिर कोई एप्लिकेशन [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल कर सकता है और बिना खोलने वाले पासवर्ड के सार्वजनिक मेटाडेटा पढ़ सकता है।  

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) Aspose.Slides द्वारा लोड किए गए डेटा को नियंत्रित करता है; यह कुछ भी डिक्रिप्ट नहीं करता। यदि गुण एन्क्रिप्शन में शामिल थे, तो पासवर्ड के बिना उन्हें लोड करना विफल रहता है। यदि प्रस्तुति एन्क्रिप्ट नहीं है, तो यह विकल्प अनदेखा किया जाता है और पूरी प्रस्तुति लोड हो जाती है।  

उदाहरण के लिए एक एन्क्रिप्टेड प्रस्तुति चाहिए जिसकी दस्तावेज़ गुण सार्वजनिक रखे गए हों। यह लोडिंग मोड को [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) के माध्यम से सत्यापित करता है और फिर [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) के माध्यम से बिल्ट‑इन गुण पढ़ता है:  
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

इस मोड में, स्लाइड सामग्री लोड नहीं होती। स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, मीडिया, और अन्य प्रस्तुति वस्तुएँ उपलब्ध नहीं रहतीं। एप्लिकेशन को हमेशा [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) जांचना चाहिए इससे पहले कि वह पूरी प्रस्तुति ऑब्जेक्ट मॉडल की आवश्यकता वाले कार्य को करे।  

{{% alert color="warning" title="Warning" %}}
सार्वजनिक मेटाडेटा लेखक नाम, शीर्षक, विषय, कुंजीशब्द, कंपनी जानकारी, टिप्पणी, और कस्टम मान उजागर कर सकता है। संवेदनशील गुणों को प्रस्तुति के साथ एन्क्रिप्ट करें। उन्हें केवल तभी सार्वजनिक रखें जब इंडेक्सिंग, वर्गीकरण, खोज, या दस्तावेज़‑प्रबंधन सिस्टम को पासवर्ड के बिना एक्सेस करने की विशिष्ट आवश्यकता हो।  
{{% /alert %}}

## **एन्क्रिप्टेड प्रस्तुति के गुण अपडेट करें**

एक एन्क्रिप्टेड PPTX फ़ाइल के लिए, [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करने के बाद लोड की गई प्रस्तुति सार्वजनिक मेटाडेटा पढ़ने के लिए निर्धारित होती है। Aspose.Slides उस केवल‑मेटाडेटा वस्तु से बदले गए गुणों को सहेज नहीं सकता क्योंकि सार्वजनिक गुणों को एन्क्रिप्टेड प्रस्तुति के भीतर संबंधित डेटा के साथ सुसंगत रहना चाहिए। इसलिए उन्हें अपडेट करने के लिए सही खोलने वाला पासवर्ड और पूरी लोड आवश्यक है।  

उदाहरण के लिए एक एन्क्रिप्टेड PPTX प्रस्तुति चाहिए जिसमें सार्वजनिक दस्तावेज़ गुण हों और एक ज्ञात खोलने वाला पासवर्ड हो। यह [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) के साथ पूरी प्रस्तुति खोलता है, सार्वजनिक बिल्ट‑इन गुण अपडेट करता है, और परिणाम सहेजता है। फिर यह [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) का उपयोग करके एन्क्रिप्शन संरक्षित है यह सत्यापित करता है और बिना पासवर्ड के सार्वजनिक मेटाडेटा को फिर से खोलकर नए मानों को जांचता है:  
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

यदि किसी एप्लिकेशन को प्रस्तुति सामग्री को डिक्रिप्ट या लोड करने की अनुमति नहीं है, तो उसे एन्क्रिप्टेड PPTX फ़ाइल के सार्वजनिक गुणों को केवल‑पढ़ने योग्य मानना चाहिए।  

## **बिल्ट‑इन गुणों तक पहुंच**

[DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) वर्ग getter मेथड्स के माध्यम से बिल्ट‑इन मेटाडेटा उजागर करता है, जिसमें [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), और [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) शामिल हैं। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और उसके संग्रहीत मेटाडेटा को कंसोल पर प्रिंट करता है। मान इनपुट प्रस्तुति पर निर्भर करते हैं; कुछ फ़ील्ड ख़ाली हो सकते हैं।  
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

## **बिल्ट‑इन गुण संशोधित करें**

बिल्ट‑इन मेटाडेटा को अपडेट करने के लिए, [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) द्वारा लौटाए गए ऑब्जेक्ट पर setter मेथड्स का उपयोग करें। यह उदाहरण एक मौजूदा प्रस्तुति खोलता है, [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments), और [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) को कॉल करता है, फिर [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) के साथ अपडेटेड प्रस्तुति सहेजता है। सहेजा गया PPTX नए मेटाडेटा को शामिल करता है।  
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

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) सापेक्ष हाइपरलिंक के लिए दस्तावेज़‑स्तरीय बेस लौटाता है। इसे बदलने या साफ़ करने के लिए [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) का उपयोग करें। यह प्रस्तुति और उसकी लिंक्ड फाइलों को दूसरे स्थान पर ले जाने पर उपयोगी होता है। यह व्यक्तिगत हाइपरलिंक के [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) से अलग है: बेस बदलने से संग्रहीत लिंक पते नहीं बदलते या निरपेक्ष गंतव्य नहीं बदलते।  

उदाहरण के लिए एक प्रस्तुति चाहिए जिसमें एक सापेक्ष लिंक, जैसे `target.html`, और एक निरपेक्ष लिंक, जैसे `https://example.org/absolute.html` मौजूद हों। यह मौजूदा बेस पढ़ता है, नया बेस पता असाइन करता है, और मूल्य जांचने के लिए प्रस्तुति को सहेजता और फिर से खोलता है। फिर यह बेस को खाली स्ट्रिंग से साफ़ करता है और अलग सहेजी फ़ाइल में खाली मान की जाँच करता है। उदाहरण बेस पता को अपनी लिंक्ड फाइलों के स्थान से बदलें।  
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

दो सत्यापन संदेशों को `true` प्रिंट करना चाहिए। बेस को साफ़ करने से व्यक्तिगत हाइपरलिंक पते अपरिवर्तित रहते हैं।  

`target.pptx` के सापेक्ष लिंक ने `old/target.pptx` खोला जब बेस `old` फ़ोल्डर की ओर इशारा करता था। बेस को `new` फ़ोल्डर में बदलने, सहेजने, और प्रस्तुति को फिर से खोलने के बाद वही लिंक `new/target.pptx` खोलता है। निरपेक्ष लिंक वही फ़ाइल खोलता रहता है। प्रस्तुति को स्थानांतरित करने या उसके बेस को बदलने से पहले और बाद में PowerPoint में अपने सापेक्ष लिंक का परीक्षण करें।  

## **कस्टम प्रस्तुति गुण जोड़ें**

कस्टम गुण वह मेटाडेटा संग्रहीत करते हैं जिसका कोई संबंधित बिल्ट‑इन फ़ील्ड नहीं होता। [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) मेथड आपको गुण नाम से मान असाइन करने देता है। यह उदाहरण एक प्रस्तुति बनाता है, दो टेक्स्ट मान और एक पूर्णांक संस्करण मान जोड़ता है, और [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) के साथ प्रस्तुति सहेजता है। मौजूदा नाम को मान असाइन करने से उस गुण का मान प्रतिस्थापित हो जाता है।  
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

## **कस्टम गुणों तक पहुंचें और संशोधित करें**

यह उदाहरण कस्टम गुणों वाली प्रस्तुति खोलता है और [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) का उपयोग करके उन पर इटरिट करता है। [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) शून्य‑आधारित सूचकांक लेता है और वह नाम लौटाता है जिसका उपयोग [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) करता है। उदाहरण प्रत्येक मूल नाम और मान प्रिंट करता है, प्रत्येक मान को उसकी मूल प्रकार की परवाह किए बिना क्रमांकित स्ट्रिंग से बदलता है, और परिवर्तन सहेजता है। यदि कोई कस्टम गुण नहीं हैं, तो लूप कोई परिवर्तन नहीं करता।  
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

[**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) ऑनलाइन ऐप को आज़माएं ताकि आप Aspose.Slides API का उपयोग करके दस्तावेज़ गुणों के साथ काम करना देख सकें:  

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रस्तुति से बिल्ट‑इन गुण कैसे हटा सकता हूँ?**  
बिल्ट‑इन गुण प्रस्तुति का अभिन्न हिस्सा होते हैं और पूरी तरह से हटाए नहीं जा सकते। हालांकि, आप इनका मान बदल सकते हैं या यदि विशिष्ट गुण अनुमति देता है तो उन्हें खाली सेट कर सकते हैं।  

**यदि मैं किसी मौजूदा कस्टम गुण को जोड़ता हूँ तो क्या होता है?**  
यदि आप किसी मौजूदा कस्टम गुण को जोड़ते हैं, तो उसका मौजूदा मान नए मान से ओवरराइट हो जाएगा। आपको पहले से गुण को हटाने या जाँचने की आवश्यकता नहीं है, क्योंकि Aspose.Slides स्वचालित रूप से गुण का मान अपडेट कर देता है।  

**क्या मैं पूरी प्रस्तुति लोड किए बिना प्रस्तुति गुणों तक पहुंच सकता हूँ?**  
हां। पहले [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) का उपयोग करें और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) का उपयोग करके बिना [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) इंस्टेंस बनाए संग्रहीत दस्तावेज़ मेटाडेटा पढ़ें। पूर्ण रिपोर्ट उदाहरण और फ़ॉर्मेट‑विशिष्ट सीमाओं के लिए देखें [Build a Lightweight Presentation Inventory](/slides/hi/nodejs-java/examine-presentation/)।  

**क्या मैं एन्क्रिप्टेड प्रस्तुति के सार्वजनिक गुणों को उसके खोलने वाले पासवर्ड के बिना पढ़ सकता हूँ?**  
हां। प्रस्तुति को [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) को `false` के साथ कॉल करने के बाद एन्क्रिप्ट किया गया होना चाहिए, और उसे [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) को `true` के साथ कॉल करने के बाद लोड किया गया होना चाहिए।  

**क्या मैं दस्तावेज़‑गुण‑केवल मोड में एन्क्रिप्टेड PPTX फ़ाइल को अपडेट कर सकता हूँ?**  
नहीं। सार्वजनिक और एन्क्रिप्टेड गुण डेटा को सुसंगत रहना चाहिए, इसलिए एन्क्रिप्टेड PPTX फ़ाइल को अपडेट करने के लिए सही खोलने वाले पासवर्ड के साथ पूरी प्रस्तुति को लोड करना आवश्यक है।