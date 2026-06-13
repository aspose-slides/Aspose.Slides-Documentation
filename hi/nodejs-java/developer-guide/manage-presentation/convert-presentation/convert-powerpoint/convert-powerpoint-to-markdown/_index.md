---
title: JavaScript में PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint को परिवर्तित करें
- प्रेजेंटेशन को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint को MD में
- प्रेजेंटेशन को MD में
- स्लाइड को MD में
- PPT को MD में
- PPTX को MD में
- PowerPoint को Markdown के रूप में सहेजें
- प्रेजेंटेशन को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PowerPoint स्लाइड्स—PPT, PPTX—को Aspose.Slides for Node.js के माध्यम से Java के जरिए साफ़ Markdown में बदलें, दस्तावेज़ीकरण को स्वचालित करें और फ़ॉर्मेटिंग को बरकरार रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में बदलने की सुविधा देता है, जो दस्तावेज़ीकरण कार्यप्रवाह, स्थैतिक साइट निर्माण, सामग्री माइग्रेशन, और संस्करण‑नियंत्रित पाठ प्रकाशन के लिए उपयोगी हो सकता है। API सीधे PPT और PPTX प्रस्तुतियों को MD फ़ाइलों में निर्यात करने का समर्थन करती है और अतिरिक्त विकल्प प्रदान करती है जिससे स्लाइड सामग्री को परिणामी Markdown दस्तावेज़ में कैसे प्रस्तुत किया जाए, नियंत्रित किया जा सके।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसे कई Markdown फ़्लेवर्स में से चुन सकते हैं, और निर्यात के दौरान चित्रों के संभालने के तरीके को कॉन्फ़िगर कर सकते हैं। उन प्रस्तुतियों के लिए जिनमें दृश्य सामग्री होती है, Aspose.Slides आपको चित्रों को एक अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका संदर्भ देने की भी सुविधा देता है।

{{% alert color="warning" %}} 

PowerPoint से markdown निर्यात **डिफ़ॉल्ट रूप से चित्रों के बिना** होता है। यदि आप चित्रों वाली PowerPoint दस्तावेज़ निर्यात करना चाहते हैं, तो आपको `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` कॉल करना होगा और साथ ही `BasePath` सेट करना होगा जहाँ markdown दस्तावेज़ में संदर्भित चित्र सहेजे जाएंगे।

{{% /alert %}} 

## **PowerPoint को Markdown में बदलें**

1. एक प्रस्तुति ऑब्जेक्ट को दर्शाने के लिए [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएँ।
2. ऑब्जेक्ट को markdown फ़ाइल के रूप में सहेजने के लिए [save](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#save-aspose.slides.IXamlOptions-) मेथड का उपयोग करें।

यह JavaScript कोड दिखाता है कि PowerPoint को markdown में कैसे बदलें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.md", aspose.slides.SaveFormat.Md);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint को Markdown फ़्लेवर में बदलें**

Aspose.Slides आपको PowerPoint को markdown (बुनियादी सिंटैक्स सहित), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, और 17 अन्य markdown फ़्लेवर्स में बदलने की अनुमति देता है।

यह JavaScript कोड दिखाता है कि PowerPoint को CommonMark में कैसे बदलें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.CommonMark);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

23 समर्थित markdown फ़्लेवर्स को [Flavor enumeration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/flavor/) में सूचीबद्ध किया गया है, जो [MarkdownSaveOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) क्लास से प्राप्त होते हैं।

## **चित्रों वाली प्रस्तुति को Markdown में बदलें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownsaveoptions/) क्लास उन गुणों और एन्यूमेरेशन्स को प्रदान करती है जो परिणामस्वरूप markdown फ़ाइल के लिए कुछ विकल्प या सेटिंग्स उपयोग करने की अनुमति देती हैं। उदाहरण के तौर पर, [MarkdownExportType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/markdownexporttype/) एनीम को ऐसे मानों पर सेट किया जा सकता है जो निर्धारित करते हैं कि चित्र कैसे रेंडर या हैंडल किए जाएंगे: `Sequential`, `TextOnly`, `Visual`।

### **चित्रों को क्रमिक रूप से बदलें**

यदि आप चाहते हैं कि चित्र परिणामस्वरूप markdown में क्रमिक रूप से, एक‑एक करके दिखाई दें, तो आपको sequential विकल्प चुनना होगा। यह JavaScript कोड दिखाता है कि चित्रों वाली प्रस्तुति को markdown में कैसे बदलें:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(aspose.slides.Flavor.Github);
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(aspose.slides.NewLineType.Windows);
    pres.save("doc.md", java.newArray("int", [1, 2, 3, 4, 5, 6, 7, 8, 9]), aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **चित्रों को दृश्य रूप से बदलें**

यदि आप चाहते हैं कि चित्र परिणामस्वरूप markdown में एक साथ दिखाई दें, तो आपको visual विकल्प चुनना होगा। इस स्थिति में, चित्र एप्लिकेशन की वर्तमान डायरेक्टरी में सहेजे जाएंगे (और markdown दस्तावेज़ में उनके लिए एक रिलेटिव पाथ बन जाएगा), या आप अपना वांछित पाथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

यह JavaScript कोड इस ऑपरेशन को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    final var outPath = "c:/documents";
    var markdownSaveOptions = new aspose.slides.MarkdownSaveOptions();
    markdownSaveOptions.setExportType(aspose.slides.MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", aspose.slides.SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक निर्यात के बाद Markdown में जीवित रहते हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/nodejs-java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/nodejs-java/slide-transition/) और [animations](/slides/hi/nodejs-java/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**

आप फ़ाइलों के बीच समानांतर प्रक्रिया कर सकते हैं, लेकिन समान [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा **नहीं** करें। फ़ाइल‑प्रति अलग-अलग इंस्टेंस/प्रोसेस का उपयोग करें ताकि कंटेंसन से बचा जा सके।

**चित्रों का क्या होता है—वे कहाँ सहेजे जाते हैं, और पाथ रिलेटिव होते हैं क्या?**

[Images](/slides/hi/nodejs-java/image/) को एक समर्पित फ़ोल्डर में निर्यात किया जाता है, और Markdown फ़ाइल डिफ़ॉल्ट रूप से उन्हें रिलेटिव पाथ के साथ रेफ़रेंस करती है। आप बेस आउटपुट पाथ और एसेट फ़ोल्डर नाम को कॉन्फ़िगर कर सकते हैं ताकि रिपॉजिटरी संरचना पूर्वानुमेय बनी रहे।