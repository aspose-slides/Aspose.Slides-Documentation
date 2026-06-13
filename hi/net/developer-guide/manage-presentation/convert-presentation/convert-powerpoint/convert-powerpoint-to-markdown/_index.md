---
title: ".NET में PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करें"
linktitle: "PowerPoint से Markdown"
type: docs
weight: 140
url: /hi/net/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint रूपांतरित करें"
- "प्रस्तुति रूपांतरित करें"
- "स्लाइड रूपांतरित करें"
- "PPT रूपांतरित करें"
- "PPTX रूपांतरित करें"
- "PowerPoint से MD"
- "प्रस्तुति से MD"
- "स्लाइड से MD"
- "PPT से MD"
- "PPTX से MD"
- "PowerPoint को Markdown के रूप में सहेजें"
- "प्रस्तुति को Markdown के रूप में सहेजें"
- "स्लाइड को Markdown के रूप में सहेजें"
- "PPT को MD के रूप में सहेजें"
- "PPTX को MD के रूप में सहेजें"
- "PPT को MD में निर्यात करें"
- "PPTX को MD में निर्यात करें"
- "PowerPoint"
- "प्रस्तुति"
- "Markdown"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint स्लाइड्स—PPT, PPTX—को साफ़ Markdown में परिवर्तित करें, दस्तावेज़ीकरण स्वचालित करें और स्वरूप बनाए रखें।"
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करने की अनुमति देता है, जो दस्तावेज़ीकरण कार्यप्रवाह, स्थिर साइट निर्माण, सामग्री प्रवासन, और संस्करण-नियंत्रित पाठ प्रकाशन के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों से MD फ़ाइलों में सीधा निर्यात समर्थन करता है और परिणामी Markdown दस्तावेज़ में स्लाइड सामग्री को कैसे प्रदर्शित किया जाए, इसे नियंत्रित करने के लिए अतिरिक्त विकल्प प्रदान करता है।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसे कई Markdown स्वरूपों में से चुन सकते हैं, और निर्यात के दौरान छवियों को कैसे संभाला जाए, इसे कॉन्फ़िगर कर सकते हैं। उन प्रस्तुतियों के लिए जिनमें दृश्य सामग्री होती है, Aspose.Slides आपको छवियों को एक अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका संदर्भ देने की अनुमति भी देता है।

{{% alert color="warning" %}}
PowerPoint-to-Markdown निर्यात डिफ़ॉल्ट रूप से **छवियों के बिना** होता है। यदि आप छवियों वाली PowerPoint दस्तावेज़ निर्यात करना चाहते हैं, तो आपको `ExportType = MarkdownExportType.Visual` सेट करना होगा और `BasePath` निर्दिष्ट करना होगा, जहाँ Markdown दस्तावेज़ में संदर्भित छवियों को सहेजा जाएगा।
{{% /alert %}}

## **PowerPoint को Markdown में परिवर्तित करें**

1. एक प्रस्तुतीकरण ऑब्जेक्ट का प्रतिनिधित्व करने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।
2. ऑब्जेक्ट को markdown फ़ाइल के रूप में सहेजने के लिए [Save ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/methods/save)method का उपयोग करें।

यह C# कोड दिखाता है कि कैसे PowerPoint को markdown में परिवर्तित किया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## **PowerPoint को Markdown फ़्लेवर में परिवर्तित करें**

Aspose.Slides आपको PowerPoint को markdown (बेसिक सिंटैक्स के साथ), CommonMark, GitHub flavored markdown, Trello, XWiki, GitLab, और 17 अन्य markdown फ़्लेवर्स में परिवर्तित करने की अनुमति देता है।

यह C# कोड दिखाता है कि कैसे PowerPoint को CommonMark में परिवर्तित किया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```

23 समर्थित markdown फ़्लेवर्स को [Flavor enumeration](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) के तहत [MarkdownSaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) क्लास से सूचीबद्ध किया गया है।

## **छवियों वाली प्रस्तुति को Markdown में परिवर्तित करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) क्लास गुणधर्म और enumeration प्रदान करता है जो आपको परिणामी markdown फ़ाइल के लिए कुछ विकल्प या सेटिंग्स उपयोग करने की अनुमति देता है। उदाहरण के तौर पर, [MarkdownExportType](https://reference.aspose.com/slides/hi/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) enum को ऐसे मानों पर सेट किया जा सकता है जो निर्धारित करते हैं कि छवियों को कैसे रेंडर या संभाला जाए: `Sequential`, `TextOnly`, `Visual`.

### **छवियों को क्रमिक रूप से परिवर्तित करें**

यदि आप चाहते हैं कि छवियां क्रमशः एक के बाद एक परिणामी markdown में दिखाई दें, तो आपको sequential विकल्प चुनना होगा। यह C# कोड दिखाता है कि कैसे छवियों वाली प्रस्तुति को markdown में परिवर्तित किया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```

### **छवियों को दृश्य रूप में परिवर्तित करें**

यदि आप चाहते हैं कि छवियां परिणामी markdown में साथ-साथ दिखाई दें, तो आपको visual विकल्प चुनना होगा। इस स्थिति में, छवियां एप्लिकेशन की वर्तमान डायरेक्टरी में सहेजी जाएंगी (और उनके लिए markdown दस्तावेज़ में एक रिलेटिव पाथ बनाया जाएगा), या आप अपना पसंदीदा पाथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

यह C# कोड इस ऑपरेशन को प्रदर्शित करता है:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक निर्यात के बाद भी Markdown में बरकरार रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/net/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [transitions](/slides/hi/net/slide-transition/) और [animations](/slides/hi/net/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**

आप फ़ाइलों के बीच समानांतर बना सकते हैं, लेकिन थ्रेड्स में उसी [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को [don’t share](/slides/hi/net/multithreading/) न करें। संघर्ष से बचने के लिए प्रति फ़ाइल अलग-अलग इंस्टेंस/प्रॉसेस का उपयोग करें।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और पाथ रिलेटिव हैं?**

[Images](/slides/hi/net/image/) को एक समर्पित फ़ोल्डर में निर्यात किया जाता है, और डिफ़ॉल्ट रूप से Markdown फ़ाइल उन्हें रिलेटिव पाथ से संदर्भित करती है। आप बेस आउटपुट पाथ और एसेट फ़ोल्डर नाम कॉन्फ़िगर कर सकते हैं ताकि एक पूर्वानुमेय रिपॉजिटरी संरचना बनी रहे।