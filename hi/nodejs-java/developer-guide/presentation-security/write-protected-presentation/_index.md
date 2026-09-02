---
title: जावास्क्रिप्ट में प्रस्तुतियों को राइट‑प्रोटेक्ट करें
linktitle: राइट प्रोटेक्शन
type: docs
weight: 25
url: /hi/nodejs-java/write-protected-presentation/
keywords:
- राइट प्रोटेक्शन
- PowerPoint को राइट‑प्रोटेक्ट करें
- संशोधन के लिए पासवर्ड
- प्रस्तुति संपादन को प्रतिबंधित करें
- राइट प्रोटेक्शन हटाएँ
- संशोधन पासवर्ड को मान्य करें
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js का उपयोग करके PowerPoint PPT और PPTX प्रस्तुतियों में राइट‑प्रोटेक्शन पासवर्ड को सेट, खोजें, मान्य करें और हटाएँ।"
---
## **परिचय**

एक राइट-प्रोटेक्शन पासवर्ड प्रस्तुति में संशोधन को प्रतिबंधित करता है, लेकिन इसकी सामग्री को एन्क्रिप्ट नहीं करता। उपयोगकर्ता राइट-प्रोटेक्टेड प्रस्तुति को पासवर्ड के बिना लोड और देख सकते हैं। एप्लिकेशन पर निर्भर करते हुए, वे सामग्री को संपादित कर सकते हैं और इसे किसी अलग नाम से सहेज सकते हैं, इसलिए राइट प्रोटेक्शन को गोपनीयता तंत्र के रूप में नहीं माना जाना चाहिए।

एक ओपनिंग पासवर्ड का उद्देश्य अलग होता है: यह प्रस्तुति को एन्क्रिप्ट करता है और इसकी सामग्री को लोड करने के लिए आवश्यक होता है। प्रस्तुति को एन्क्रिप्ट करने या ओपनिंग पासवर्ड को वैध करने के लिए देखें [Password-Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)।

इस लेख में वर्णित वर्कफ़्लो PPT और PPTX दोनों प्रस्तुतियों पर लागू होते हैं। उदाहरण PPTX फाइलों का उपयोग करते हैं; PPT में सहेजते समय `.ppt` एक्सटेंशन और संबंधित PPT सहेजने का फ़ॉर्मेट उपयोग करें।

## **प्रेज़ेंटेशन पर राइट प्रोटेक्शन सेट करें**

राइट प्रोटेक्शन के लिए पासवर्ड निर्धारित करने हेतु [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) का उपयोग करें। प्रस्तुति को सहेजने पर प्रोटेक्शन सेटिंग स्थायी हो जाती है।

निम्नलिखित उदाहरण PPTX प्रस्तुति पर राइट प्रोटेक्शन सेट करता है:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **राइट‑प्रोटेक्टेड प्रस्तुति लोड करें**

चूंकि राइट प्रोटेक्शन प्रस्तुति की सामग्री को एन्क्रिप्ट नहीं करता, प्रस्तुति को लोड करने हेतु पासवर्ड की आवश्यकता नहीं होती। पासवर्ड केवल संरक्षित प्रस्तुति में संशोधन की अनुमति सत्यापित करने के लिए प्रासंगिक है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

राइट‑प्रोटेक्शन पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) में पास न करें। वह मेथड एन्क्रिप्टेड सामग्री के लिए ओपनिंग पासवर्ड लेता है। यदि प्रस्तुति में दोनों प्रकार के प्रोटेक्शन हों, तो लोड करने के लिए ओपनिंग पासवर्ड प्रदान करें और राइट‑प्रोटेक्शन पासवर्ड को अलग से संभालें।

## **प्रेज़ेंटेशन से राइट प्रोटेक्शन हटाएँ**

राइट प्रोटेक्शन हटाने के लिए [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) का उपयोग करें, फिर प्रस्तुति को सहेजें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **जाँचें कि प्रस्तुति राइट‑प्रोटेक्टेड है या नहीं**

पूरी [Presentation](/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाने के बिना फ़ाइल की जाँच करने हेतु [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) को कॉल करें और [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) को देखें। इस मेथड में [NullableBool](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/nullablebool/) का उपयोग होता है और राइट प्रोटेक्शन मिलने पर `NullableBool.True` लौटाता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

स्ट्रीम‑आधारित [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) मेथड भी वही जानकारी प्रदान करता है जब प्रस्तुति को Node.js रीडेबल स्ट्रीम के रूप में दिया जाता है।

## **राइट‑प्रोटेक्शन पासवर्ड वैध करें**

राइट‑प्रोटेक्शन पासवर्ड को पूरी प्रस्तुति लोड किए बिना वैध करने के लिए [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) का उपयोग करें। पहले [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) जाँचें ताकि एप्लिकेशन केवल तभी पासवर्ड का अनुरोध या वैधता करे जब राइट प्रोटेक्शन मौजूद हो।

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) केवल राइट‑प्रोटेक्शन पासवर्ड को वैध करता है। यह ओपनिंग पासवर्ड को वैध नहीं करता और न ही यह निर्धारित करता है कि एन्क्रिप्टेड सामग्री लोड की जा सकती है या नहीं। इसके विपरीत, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/#checkPassword) केवल ओपनिंग पासवर्ड को वैध करता है। यदि पूरी प्रस्तुति पहले ही लोड हो चुकी है, तो [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) अपने प्रोटेक्शन मैनेजर के माध्यम से समान राइट‑प्रोटेक्शन जाँच प्रदान करता है।

प्रोडक्शन एप्लिकेशन में पासवर्ड को लॉग न करें या डायग्नोस्टिक संदेशों में शामिल न करें। अनावश्यक बार‑बार वैधता प्रयासों से बचें, और पासवर्ड को आवश्यक अवधि तक ही मेमोरी में रखें।

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/hi/nodejs-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/hi/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**क्या राइट प्रोटेक्शन प्रस्तुति को एन्क्रिप्ट करता है?**

नहीं। यह संशोधन को प्रतिबंधित करता है लेकिन प्रस्तुति सामग्री को लोड और देखने के लिए उपलब्ध रखता है।

**क्या प्रस्तुति खोलने के लिए राइट‑प्रोटेक्शन पासवर्ड आवश्यक है?**

नहीं। केवल एन्क्रिप्टेड प्रस्तुति सामग्री को लोड करने के लिए ओपनिंग पासवर्ड आवश्यक होता है।

**क्या एक प्रस्तुति में ओपनिंग पासवर्ड और राइट‑प्रोटेक्शन पासवर्ड दोनों हो सकते हैं?**

हां। एन्क्रिप्टेड प्रस्तुति को खोलने के लिए लोड ऑप्शन्स के माध्यम से ओपनिंग पासवर्ड प्रदान करें, और संशोधन अधिकार की आवश्यकता होने पर राइट‑प्रोटेक्शन पासवर्ड को अलग से वैध करें।