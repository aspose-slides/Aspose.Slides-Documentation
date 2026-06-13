---
title: Android पर PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint को बदलें
- प्रेज़ेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint को MD में
- प्रेज़ेंटेशन को MD में
- स्लाइड को MD में
- PPT को MD में
- PPTX को MD में
- PowerPoint को Markdown के रूप में सहेजें
- प्रेज़ेंटेशन को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- PowerPoint
- प्रेज़ेंटेशन
- Markdown
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के माध्यम से Java का उपयोग करके PowerPoint स्लाइड्स—PPT, PPTX—को साफ़ Markdown में बदलें, दस्तावेज़ीकरण को स्वचालित करें और फ़ॉर्मेटिंग बनाए रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में बदलने की अनुमति देता है, जो प्रलेखन कार्यप्रवाह, स्थैतिक साइट निर्माण, सामग्री माइग्रेशन, और संस्करण-नियंत्रित पाठ प्रकाशन के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों को सीधे MD फ़ाइलों में निर्यात करने का समर्थन करता है और परिणामस्वरूप Markdown दस्तावेज़ में स्लाइड सामग्री को कैसे दर्शाया जाए, इस पर अतिरिक्त विकल्प प्रदान करता है।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसी कई Markdown स्वादों में से चुन सकते हैं, और निर्यात के दौरान चित्रों को कैसे संभाला जाए, इसे कॉन्फ़िगर कर सकते हैं। दृश्य सामग्री वाली प्रस्तुतियों के लिए, Aspose.Slides आपको छवियों को अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका उल्लेख करने की भी सुविधा देता है।

Aspose.Slides प्रस्तुति-से-Markdown रूपांतरण का समर्थन करता है।

{{% alert color="warning" %}} 
PowerPoint से markdown निर्यात डिफ़ॉल्ट रूप से **छवियों के बिना** होता है। यदि आप छवियों वाली PowerPoint दस्तावेज़ को निर्यात करना चाहते हैं, तो आपको `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` सेट करना होगा और साथ ही `BasePath` सेट करना होगा जहाँ markdown दस्तावेज़ में उल्लेखित छवियों को सहेजा जाएगा।
{{% /alert %}} 

## **PowerPoint को Markdown में रूपांतरित करें**

1. एक प्रस्तुति ऑब्जेक्ट का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. ऑब्जेक्ट को markdown फ़ाइल के रूप में सहेजने के लिए [Save ](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) मेथड का उपयोग करें।

यह Java कोड दिखाता है कि PowerPoint को markdown में कैसे बदलें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint को Markdown फ़्लेवर में बदलें**

Aspose.Slides आपको PowerPoint को markdown (मूल सिंटैक्स सहित), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, और 17 अन्य markdown स्वरूपों में बदलने की अनुमति देता है।

यह Java कोड दिखाता है कि PowerPoint को CommonMark में कैसे बदलें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setFlavor(Flavor.CommonMark);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

23 समर्थित markdown स्वरूप [Flavor enumeration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/flavor/) में सूचीबद्ध हैं, जो [MarkdownSaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) क्लास से प्राप्त होते हैं।

## **छवियों वाली प्रस्तुति को Markdown में बदलें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) क्लास गुण और enumeration प्रदान करता है जो आपको परिणामस्वरूप markdown फ़ाइल के लिए कुछ विकल्प या सेटिंग्स उपयोग करने देता है। उदाहरण के लिए, [MarkdownExportType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownexporttype/) enum को ऐसे मानों पर सेट किया जा सकता है जो निर्धारित करते हैं कि छवियों को कैसे रेंडर या संभाला जाए: `Sequential`, `TextOnly`, `Visual`.

### **चित्रों को क्रमिक रूप से बदलें**

यदि आप चाहते हैं कि परिणामस्वरूप markdown में छवियां एक-एक करके क्रम में दिखाई दें, तो आपको क्रमिक विकल्प चुनना होगा। यह Java कोड दिखाता है कि छवियों वाली प्रस्तुति को markdown में कैसे बदलें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setShowHiddenSlides(true);
    markdownSaveOptions.setShowSlideNumber(true);
    markdownSaveOptions.setFlavor(Flavor.Github);
    markdownSaveOptions.setExportType(MarkdownExportType.Sequential);
    markdownSaveOptions.setNewLineType(NewLineType.Windows);
    pres.save("doc.md", new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **चित्रों को दृश्य रूप में बदलें**

यदि आप चाहते हैं कि परिणामस्वरूप markdown में छवियां एक साथ दिखाई दें, तो आपको दृश्य विकल्प चुनना होगा। इस स्थिति में, छवियां एप्लिकेशन की वर्तमान निर्देशिका में सहेजी जाएँगी (और markdown दस्तावेज़ में उनके लिए एक सापेक्ष पथ बनाया जाएगा), या आप अपना पसंदीदा पथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

यह Java कोड इस कार्य को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    final String outPath = "c:/documents";
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions();
    markdownSaveOptions.setExportType(MarkdownExportType.Visual);
    markdownSaveOptions.setImagesSaveFolderName("md-images");
    markdownSaveOptions.setBasePath(outPath);
    pres.save("pres.md", SaveFormat.Md, markdownSaveOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक्स Markdown निर्यात में बनी रहती हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/androidjava/slide-transition/) और [animations](/slides/hi/androidjava/powerpoint-animation/) को परिवर्तित नहीं किया जाता है।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**

आप फ़ाइलों के बीच समानांतर कर सकते हैं, लेकिन थ्रेड्स के बीच वही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस [don’t share](/slides/hi/androidjava/multithreading/) न करें। प्रत्येक फ़ाइल के लिए अलग-अलग इंस्टेंस/प्रोसेस उपयोग करें ताकि टकराव से बचा जा सके।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और पथ सापेक्ष हैं क्या?**

[Images](/slides/hi/androidjava/image/) को एक समर्पित फ़ोल्डर में निर्यात किया जाता है, और Markdown फ़ाइल उन्हें डिफ़ॉल्ट रूप से सापेक्ष पथों के साथ संदर्भित करती है। आप बेस आउटपुट पाथ और एसेट फ़ोल्डर नाम को कॉन्फ़िगर कर सकते हैं ताकि एक पूर्वानुमेय रिपॉज़िटरी संरचना बनी रहे।