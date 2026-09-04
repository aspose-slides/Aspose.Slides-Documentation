---
title: जावास्क्रिप्ट में प्रस्तुतियों को खोलें
linktitle: प्रेजेंटेशन खोलें
type: docs
weight: 20
url: /hi/nodejs-java/open-presentation/
keywords:
- PowerPoint खोलें
- प्रेजेंटेशन खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रेजेंटेशन लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- संरक्षित प्रेजेंटेशन
- बड़ी प्रेजेंटेशन
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलें, खोलने के पासवर्ड प्रदान करें, संसाधन लोडिंग को नियंत्रित करें, और Aspose.Slides for Node.js via Java के साथ मेमोरी उपयोग को कम करें, यह सीखें।"
---
## **परिचय**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/hi/nodejs-java/) फ़ाइलों और स्ट्रीम्स से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। प्रस्तुति लोड होने के बाद, आप उसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स का संपादन कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और उसे मूल या किसी अन्य समर्थित फ़ॉर्मेट में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) क्लास के माध्यम से कस्टमाइज़ किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Node.js मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रेजेंटेशन खोलें**

एक मौजूद प्रेजेंटेशन खोलने के लिए, उसके फ़ाइल पाथ को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) कन्स्ट्रक्टर को पास करें। उपयोग के बाद प्रेजेंटेशन को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन तुरंत रिलीज़ हो जाएँ।

निम्नलिखित JavaScript उदाहरण दिखाता है कि कैसे एक प्रेजेंटेशन खोलें और उसकी स्लाइड काउंट प्राप्त करें:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड‑प्रोटेक्टेड प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुति सामग्री को एन्क्रिप्ट करता है। पूर्ण प्रस्तुति लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) कन्स्ट्रक्टर को प्रदान करें। पासवर्ड गायब या गलत होने पर लोडिंग विफल हो जाती है।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

पासवर्ड डिटेक्शन, वैधता जाँच और एन्क्रिप्शन वर्कफ़्लो के लिए देखें [Password‑Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुति जानबूझकर सार्वजनिक डॉक्यूमेंट प्रॉपर्टी के साथ सहेजी गई हो, तो उन प्रॉपर्टीज़ को बिना पासवर्ड के पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/nodejs-java/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प लौटाता है जो नियंत्रित करता है कि Aspose.Slides छवियों, ऑडियो और वीडियो जैसे बाइनरी बड़े ऑब्जेक्ट्स को कैसे संभालता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित JavaScript कोड बड़ी प्रस्तुति (उदाहरण के लिए, 2 GB) लोड करने को दर्शाता है:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="नोट" %}}
PresentationLockingBehavior.KeepLocked के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रेजेंटेशन इंस्टेंस डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को न तो स्थानांतरित करें, न ओवरराइट करें, न ही हटाएँ।

Aspose.Slides लोड करते समय इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए फ़ाइल पाथ आमतौर पर स्ट्रीम की तुलना में अधिक कुशल होता है। अतिरिक्त स्टोरेज और मेमोरी‑मैनेजमेंट विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/nodejs-java/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, किसी संसाधन को री‑डायरेक्ट कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को स्किप कर सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियां होती हैं जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल किया जाना चाहिए।

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **एंबेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुति में एंबेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं है या वह उसे बनाए रखना नहीं चाहती। उदाहरण शामिल हैं:

- VBA प्रोजेक्ट्स, जो [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getVbaProject) के माध्यम से उपलब्ध हैं;
- एंबेडेड OLE डेटा, जो [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) के माध्यम से उपलब्ध है;
- ActiveX कंट्रोल डेटा, जो [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/control/#getActiveXControlBinary) के माध्यम से उपलब्ध है।

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `true` पर सेट करें ताकि लोडिंग के दौरान यह बाइनरी डेटा हटा दिया जाए। साफ़ किया गया परिणाम सहेजने के लिए लोडेड प्रस्तुति को सेव करें।

यह विकल्प अनचाहे एंबेडेड पेलोड्स के एक्सपोज़र को कम करता है, लेकिन यह एक पूर्ण मालवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइज़ेशन प्रणाली नहीं है।

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पहचानूँ कि फ़ाइल भ्रष्ट है और इसे खोला नहीं जा सकता?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या फ़ॉर्मेट अपवाद फेंकता है। इस विफलता को गलत पासवर्ड त्रुटि से अलग संभालें ताकि एप्लिकेशन कारण को सटीक रूप से रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स गायब हों तो क्या होता है?**

प्रेजेंटेशन अभी भी लोड हो सकता है, लेकिन रेंडरिंग और एक्सपोर्ट फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आप [फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर](/slides/hi/nodejs-java/font-substitution/) कर सकते हैं या आउटपुट को अधिक पूर्वानुमानित बनाने के लिए [कस्टम फ़ॉन्ट्स प्रदान](/slides/hi/nodejs-java/custom-font/) कर सकते हैं।

**क्या प्रस्तुति लोड करने से उसका एंबेडेड मीडिया भी लोड हो जाता है?**

एंबेडेड ऑडियो और वीडियो प्रेजेंटेशन ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधन कॉन्फ़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल होते हैं और यदि उनके स्थानों तक पहुँच नहीं पाई जा सकती तो उपलब्ध नहीं हो सकते।