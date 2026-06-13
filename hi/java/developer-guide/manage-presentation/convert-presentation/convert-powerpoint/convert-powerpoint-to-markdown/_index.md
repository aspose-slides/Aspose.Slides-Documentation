---
title: Java में PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से MD
- प्रेजेंटेशन से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रेजेंटेशन को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- exportPPTX को MD में निर्यात करें
- PowerPoint
- प्रेजेंटेशन
- Markdown
- Java
- Aspose.Slides
description: "PowerPoint स्लाइड्स—PPT, PPTX—को Aspose.Slides for Java के साथ साफ़ Markdown में बदलें, दस्तावेज़ीकरण को स्वचालित करें और फ़ॉर्मेटिंग बनाए रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करने की अनुमति देता है, जो दस्तावेज़ीकरण वर्कफ़्लो, स्थिर साइट निर्माण, सामग्री माइग्रेशन, और संस्करण-नियंत्रित पाठ प्रकाशन के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों को MD फ़ाइलों में सीधे निर्यात का समर्थन करती है और परिणामस्वरूप Markdown दस्तावेज़ में स्लाइड सामग्री को कैसे दर्शाया जाए, इसे नियंत्रित करने के लिए अतिरिक्त विकल्प प्रदान करती है।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसे कई Markdown वैरिएंट्स में से चुन सकते हैं, और निर्यात के दौरान छवियों को कैसे संभाला जाए, इसे कॉन्फ़िगर कर सकते हैं। जिन प्रस्तुतियों में दृश्य सामग्री होती है, उनके लिए Aspose.Slides आपको छवियों को एक अलग फ़ोल्डर में सहेजने और बनी हुई Markdown फ़ाइल में उनका संदर्भ देने की सुविधा देता है।

{{% alert color="warning" %}}
PowerPoint से markdown निर्यात डिफ़ॉल्ट रूप से **छवियों के बिना** है। यदि आप छवियों वाली PowerPoint दस्तावेज़ निर्यात करना चाहते हैं, तो आपको `markdownSaveOptions.setExportType(MarkdownExportType.Visual)` का उपयोग करना होगा और साथ ही `setBasePath` का उपयोग करना होगा जहाँ markdown दस्तावेज़ में संदर्भित छवियों को सहेजा जाएगा।
{{% /alert %}}

## **PowerPoint को Markdown में बदलें**

1. एक प्रस्तुति वस्तु का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएँ।
2. ऑब्जेक्ट को markdown फ़ाइल के रूप में सहेजने के लिए [Save ](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)-method का उपयोग करें।

यह Java कोड आपको दर्शाता है कि PowerPoint को markdown में कैसे बदलें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.md", SaveFormat.Md);
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint को Markdown वैरिएंट में बदलें**

Aspose.Slides आपको PowerPoint को markdown (बुनियादी सिंटैक्स वाला), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, तथा 17 अन्य markdown वैरिएंट्स में बदलने की अनुमति देता है।

यह Java कोड आपको दिखाता है कि PowerPoint को CommonMark में कैसे बदलें:

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

23 समर्थित markdown वैरिएंट्स [Flavor enumeration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/flavor/) में [MarkdownSaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) क्लास से सूचीबद्ध हैं।

## **छवियों वाली प्रस्तुति को Markdown में बदलें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) क्लास गुण और enumeration प्रदान करती है जो आपको परिणामी markdown फ़ाइल के लिए कुछ विकल्प या सेटिंग्स उपयोग करने देती है। उदाहरण के लिए, [MarkdownExportType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownexporttype/) enum को ऐसे मानों पर सेट किया जा सकता है जो निर्धारित करते हैं कि छवियों को कैसे प्रस्तुत या संभाला जाए: `Sequential`, `TextOnly`, `Visual`.

### **छवियों को क्रमिक रूप से बदलें**

यदि आप चाहते हैं कि परिणामस्वरूप markdown में छवियां एक-एक करके क्रम में दिखाई दें, तो आपको sequential विकल्प चुनना होगा। यह Java कोड आपको दिखाता है कि छवियों वाली प्रस्तुति को markdown में कैसे बदलें:

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

### **छवियों को दृश्य रूप से बदलें**

यदि आप चाहते हैं कि परिणामस्वरूप markdown में छवियां साथ-साथ दिखाई दें, तो आपको visual विकल्प चुनना होगा। इस स्थिति में, छवियां एप्लिकेशन की वर्तमान निर्देशिका में सहेजी जाएँगी (और markdown दस्तावेज़ में उनके लिए एक सापेक्ष पथ बनाया जाएगा), या आप अपना इच्छित पथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

यह Java कोड इस ऑपरेशन को दर्शाता है:

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

**क्या हाइपरलिंक निर्यात के बाद Markdown में बने रहते हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [transitions](/slides/hi/java/slide-transition/) और [animations](/slides/hi/java/powerpoint-animation/) को रूपांतरित नहीं किया जाता।

**क्या मैं मल्टीथ्रेड में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**

आप फ़ाइलों के बीच समानांतर कर सकते हैं, लेकिन थ्रेड्स में एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को [don’t share](/slides/hi/java/multithreading/) न रखें। प्रत्येक फ़ाइल के लिए अलग-अलग इंस्टेंस/प्रोसेस का उपयोग करें ताकि संघर्ष से बचा जा सके।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और पथ सापेक्ष हैं?**

[Images](/slides/hi/java/image/) एक समर्पित फ़ोल्डर में निर्यात की जाती हैं, और Markdown फ़ाइल उन्हें डिफ़ॉल्ट रूप से सापेक्ष पथों से संदर्भित करती है। आप बेस आउटपुट पथ और एसेट फ़ोल्डर नाम को कॉन्फ़िगर कर सकते हैं ताकि एक पूर्वानुमेय रिपोजिटरी संरचना बनी रहे।