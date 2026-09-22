---
title: जावास्क्रिप्ट में प्रस्तुतियों को खोलें
linktitle: प्रस्तुति खोलें
type: docs
weight: 20
url: /hi/nodejs-java/open-presentation/
keywords:
- PowerPoint खोलें
- प्रस्तुति खोलें
- PPTX खोलें
- PPT खोलें
- ODP खोलें
- प्रस्तुति लोड करें
- PPTX लोड करें
- PPT लोड करें
- ODP लोड करें
- सुरक्षित प्रस्तुति
- बड़ी प्रस्तुति
- बाहरी संसाधन
- बाइनरी ऑब्जेक्ट
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट में PowerPoint और OpenDocument प्रस्तुतियों को कैसे खोलना है, खोलने के पासवर्ड प्रदान करना, संसाधन लोडिंग को नियंत्रित करना, और Aspose.Slides for Node.js via Java के साथ मेमोरी उपयोग को कम करना सीखें।"
---
## **परिचय**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/hi/nodejs-java/) फ़ाइलों और स्ट्रीमों से PowerPoint और OpenDocument प्रस्तुतियों को लोड कर सकता है। एक बार प्रस्तुतीकरण लोड हो जाने पर, आप इसकी संरचना का निरीक्षण कर सकते हैं, स्लाइड्स को संपादित कर सकते हैं, संसाधनों का प्रबंधन कर सकते हैं, और इसे मूल या किसी अन्य समर्थित स्वरूप में सहेज सकते हैं।

लोडिंग व्यवहार को [LoadOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/) क्लास के माध्यम से कस्टमाइज़ किया जा सकता है। उदाहरण के लिए, आप खोलने का पासवर्ड प्रदान कर सकते हैं, बड़े बाइनरी ऑब्जेक्ट्स को Node.js मेमोरी के बाहर रख सकते हैं, बाहरी संसाधनों को नियंत्रित कर सकते हैं, या एम्बेडेड बाइनरी डेटा को छोड़ सकते हैं।

## **प्रस्तुतीकरण खोलें**

फ़ाइल या स्ट्रीम लोड करने के बाद, आप [उनके मूल प्रस्तुतीकरण स्वरूप को निर्धारित कर सकते हैं](/slides/hi/nodejs-java/detect-presentation-source-format/) ताकि आप तय कर सकें कि आपका अनुप्रयोग इसे कैसे प्रोसेस करता है।

एक मौजूदा प्रस्तुतीकरण को खोलने के लिए, उसके फ़ाइल पथ को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) कन्स्ट्रक्टर में पास करें। उपयोग के बाद प्रस्तुतीकरण को डिस्पोज़ करें ताकि फ़ाइल हैंडल, अस्थायी डेटा और अन्य संसाधन शीघ्र जारी हो जाएँ।

निम्नलिखित JavaScript उदाहरण दिखाता है कि प्रस्तुतीकरण को कैसे खोलें और उसकी स्लाइड गिनती प्राप्त करें:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **पासवर्ड-संरक्षित प्रस्तुतियों को खोलें**

एक खोलने वाला पासवर्ड प्रस्तुतीकरण सामग्री को एन्क्रिप्ट करता है। पूरी प्रस्तुतीकरण लोड करने के लिए, सही पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword) में पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) कन्स्ट्रक्टर को प्रदान करें। पासवर्ड ग़ैर‑हाज़िर या गलत होने पर लोडिंग विफल हो जाती है।

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

पासवर्ड पहचान, वैधता जाँच और एन्क्रिप्शन कार्यप्रवाह के लिए, देखें [Password‑Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)। यदि एन्क्रिप्टेड प्रस्तुतीकरण जानबूझकर सार्वजनिक दस्तावेज़ गुणों के साथ सहेजा गया है, तो उन गुणों को पासवर्ड के बिना पढ़ा जा सकता है; देखें [Manage Presentation Properties](/slides/hi/nodejs-java/presentation-properties/)।

## **बड़ी प्रस्तुतियों को खोलें**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) विकल्प प्रदान करता है जो Aspose.Slides को छवियों, ऑडियो और वीडियो जैसे बड़े बाइनरी ऑब्जेक्ट्स को कैसे संभालना है, नियंत्रित करता है। आप स्रोत फ़ाइल को लॉक रख सकते हैं, अस्थायी फ़ाइलों की अनुमति दे सकते हैं, और मेमोरी में रखे जाने वाले BLOB डेटा की मात्रा को सीमित कर सकते हैं।

निम्नलिखित JavaScript कोड बड़ी प्रस्तुतीकरण (उदाहरण के लिए, 2 GB) लोड करने का प्रदर्शन करता है:

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

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) के साथ, स्रोत फ़ाइल तब तक लॉक रहती है जब तक प्रस्तुतीकरण इंस्टेंस डिस्पोज़ नहीं किया जाता। उस इंस्टेंस के जीवित रहने के दौरान स्रोत फ़ाइल को स्थानांतरित, ओवरराइट या डिलीट न करें।

Aspose.Slides लोडिंग के दौरान इनपुट स्ट्रीम की सामग्री को कॉपी कर सकता है। बड़ी प्रस्तुतियों के लिए फ़ाइल पथ आमतौर पर स्ट्रीम की तुलना में अधिक प्रभावी होता है। अतिरिक्त स्टोरेज और मेमोरी‑प्रबंधन विकल्पों के लिए देखें [Manage BLOBs](/slides/hi/nodejs-java/manage-blob/)।
{{% /alert %}}

## **बाहरी संसाधनों को नियंत्रित करें**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) एक [IResourceLoadingCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iresourceloadingcallback/) कार्यान्वयन को स्वीकार करता है। कॉलबैक प्रतिस्थापन डेटा प्रदान कर सकता है, संसाधन को री‑डायरेक्ट कर सकता है, डिफ़ॉल्ट लोडर का उपयोग कर सकता है, या संसाधन को स्किप कर सकता है। यह तब उपयोगी होता है जब प्रस्तुतियों में बाहरी छवियां हों जिन्हें एप्लिकेशन‑विशिष्ट सुरक्षा या स्टोरेज नियमों के अनुसार हल करना आवश्यक हो।

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

## **एम्बेडेड बाइनरी ऑब्जेक्ट्स के बिना प्रस्तुतियों को लोड करें**

एक प्रस्तुतीकरण में एम्बेडेड बाइनरी डेटा हो सकता है जिसकी एप्लिकेशन को आवश्यकता नहीं या वह उसे रखना नहीं चाहती। उदाहरण में शामिल हैं:

- VBA प्रोजेक्ट्स, उपलब्ध हैं [Presentation.getVbaProject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getVbaProject) के माध्यम से;
- एम्बेडेड OLE डेटा, उपलब्ध है [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) के द्वारा;
- ActiveX कंट्रोल डेटा, उपलब्ध है [Control.getActiveXControlBinary](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/control/#getActiveXControlBinary) के माध्यम से।

लोडिंग के दौरान इस बाइनरी डेटा को हटाने के लिए [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) को `true` सेट करें। लोडेड प्रस्तुतीकरण को सहेजें ताकि सफ़ाई किया गया परिणाम बना रहे।

यह विकल्प अनचाहे एम्बेडेड पेलोड्स के संपर्क को कम करता है, लेकिन यह पूर्ण मालवेयर‑डिटेक्शन या कंटेंट‑सैनिटाइजेशन सिस्टम नहीं है।

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

**मैं कैसे जानूं कि फ़ाइल भ्रष्ट है और नहीं खोली जा सकती?**

Aspose.Slides लोडिंग के दौरान पार्सिंग या स्वरूप अपवाद फेंकता है। इस विफलता को पासवर्ड‑त्रुटि से अलग संभालें ताकि अनुप्रयोग सटीक कारण रिपोर्ट कर सके।

**यदि आवश्यक फ़ॉन्ट्स गायब हों तो क्या होता है?**

प्रस्तुतीकरण अभी भी लोड हो सकता है, लेकिन रेंडरिंग और निर्यात फ़ॉन्ट्स को प्रतिस्थापित कर सकते हैं। आउटपुट को अधिक पूर्वानुमेय बनाने के लिए आप [फ़ॉन्ट प्रतिस्थापन को कॉन्फ़िगर](/slides/hi/nodejs-java/font-substitution/) कर सकते हैं या [कस्टम फ़ॉन्ट प्रदान](/slides/hi/nodejs-java/custom-font/) कर सकते हैं।

**क्या प्रस्तुतीकरण को लोड करने से उसके एम्बेडेड मीडिया भी लोड हो जाते हैं?**

एम्बेडेड ऑडियो और वीडियो प्रस्तुतीकरण ऑब्जेक्ट मॉडल के माध्यम से उपलब्ध हो जाते हैं। बाहरी संसाधनों को कॉन्फ़़िगर किए गए रिसोर्स‑लोडिंग व्यवहार के अनुसार हल किया जाता है और यदि उनके स्थानों तक पहुंच नहीं हो पाती तो वे अनुपलब्ध रह सकते हैं।