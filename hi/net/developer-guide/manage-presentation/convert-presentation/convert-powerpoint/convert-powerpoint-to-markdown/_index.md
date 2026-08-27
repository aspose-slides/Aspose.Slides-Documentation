---
title: ".NET में PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करें"
linktitle: "PowerPoint से Markdown"
type: docs
weight: 140
url: /hi/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से MD
- प्रस्तुति से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रस्तुति को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रस्तुति
- Markdown
- .NET
- C#
- Aspose.Slides
description: ".NET में PPT और PPTX प्रस्तुतियों को Markdown में परिवर्तित करें तथा निर्यातित bitmap, metafile, और SVG छवियों को कहाँ सहेजा और संदर्भित किया जाए, यह नियंत्रित करें."
---
## **सारांश**

Aspose.Slides for .NET PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थैतिक‑साइट, सामग्री‑स्थानांतरण और संस्करण‑नियंत्रण कार्यप्रवाहों के लिए Markdown में बदल सकता है। आप एक Markdown फ्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडर होने को नियंत्रित कर सकते हैं, और तय कर सकते हैं कि निर्यातित छवियों को कहाँ संग्रहीत किया जाए और उत्पन्न Markdown उन छवियों को कैसे संदर्भित करता है।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल पाठ‑आधारित आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/exporttype/) प्रॉपर्टी को [MarkdownExportType] ए़न्यूमरेशन से `Sequential` या `Visual` मान पर सेट करें। `Sequential` स्लाइड आयटम्स को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित आइटम्स को साथ रखता है ताकि उनका दृश्य संबंध बना रहे। `TextOnly` मान छवि संसाधनों को उत्पन्न नहीं करता, इसलिए इस मोड में इमेज‑सेविंग इवेंट्स नहीं चलाए जाते।

## **एक प्रस्तुति को Markdown में बदलें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) ए़न्यूमरेशन से `Md` मान के साथ कॉल करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **एक Markdown फ्लेवर चुनें**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/flavor/) प्रॉपर्टी आउटपुट के लिए उपयोग की जाने वाली Markdown स्पेसिफिकेशन को नियंत्रित करती है। [Flavor](https://reference.aspose.com/slides/hi/net/aspose.slides.export/flavor/) ए़न्यूमरेशन में CommonMark, GitHub Flavored Markdown और अन्य समर्थित वैरिएंट शामिल हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **डिफ़ॉल्ट स्थानीय‑सेविंग व्यवहार का उपयोग करके छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों के लिए दो प्रॉपर्टी प्रदान करती है:

- [BasePath](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/basepath/) Markdown दस्तावेज़ और उसकी रिसोर्सेज़ के लिए बेस डायरेक्टरी निर्दिष्ट करती है।
- [ImagesSaveFolderName](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) छवि सबडायरेक्टरी निर्दिष्ट करती है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री को रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में रिलेटिव इमेज रेफ़रेंसेस बनाता है:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

यह व्यवहार तब फॉलबैक के रूप में भी कार्य करता है जब कोई कस्टम इमेज‑सेविंग हैंडलर `false` लौटाता है।

## **छवि सहेजने और Markdown लिंक को अनुकूलित करें**

[MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/imagesaving/) इवेंट का उपयोग उन non‑SVG bitmap और metafile रिसोर्सेज़ के लिए किया जाता है जो Markdown निर्यात के दौरान उत्पन्न होते हैं। इसका [MarkdownImageSavingHandler](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) डेलीगेट [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) और उत्पन्न Markdown लिंक को `ref string` पैरामीटर के रूप में प्राप्त करता है। प्रदान किए गए फ़ॉर्मेट के साथ छवि को सहेजें या अपलोड करें, और `link` को उस रेफ़रेंस से बदलें जो Markdown आउटपुट में दिखना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न रिसोर्सेज़ को अलग से संभाला जाता है। [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) इवेंट को सब्सक्राइब करें, जिसके [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) डेलीगेट को एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) ऑब्जेक्ट और `ref string link` पैरामीटर मिलता है। SVG में कोई `ImageFormat` आर्ग्यूमेंट नहीं होता; इसके बजाय [ISvgImage.SvgData](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/svgdata/) प्रॉपर्टी से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और विज़ुअल ग्रुपिंग के आधार पर स्रोत प्रस्तुति में SVG को rasterized या अन्य कंटेंट के साथ मिलाया जा सकता है; resulting non‑SVG रिसोर्स तब `ImageSaving` को पास किया जाता है। जब हर निर्यातित विज़ुअल रिसोर्स को कस्टम प्रोसेसिंग की आवश्यकता हो तो दोनों इवेंट्स को सब्सक्राइब करें।

हैंडलर का रिटर्न वैल्यू तय करता है कि छवि को कौन प्रोसेस करता है:

- `true` लौटाएँ जब हैंडलर ने छवि को सहेजा, अपलोड किया, ट्रांसफ़ॉर्म किया या अन्य किसी तरह प्रोसेस किया हो और `link` को वैध मान असाइन किया हो। Aspose.Slides उस मान को Markdown दस्तावेज़ में लिखता है और अपनी डिफ़ॉल्ट लोकल सेव नहीं करता।
- `false` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेज सके और उसकी लिंक को [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/basepath/) और [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) के अनुसार जेनरेट करे।

{{% alert color="warning" title="Important" %}}
A handler that returns `true` takes responsibility for the image. If it returns `true` without assigning a valid, nonempty link, the export fails with an `InvalidOperationException`.
{{% /alert %}}

### **छवियों को CDN मूल निर्देशिका में सहेजें और बाहरी URLs का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को एक माउंटेड या सिंक्रोनाइज़्ड CDN मूल निर्देशिका के रूप में मानता है। प्रत्येक हैंडलर जेनरेट किए गए फ़ाइल नाम को निकालता है, छवि को उस कस्टम डायरेक्टरी में सहेजता है, और जेनरेट किए गए लोकल रेफ़रेंस को सार्वजनिक CDN URL से बदल देता है। सैंपल स्वयं कोई नेटवर्क अपलोड नहीं करता: URL केवल तब मान्य होता है जब डायरेक्टरी को CDN मूल के रूप में माउंट किया जाता है या उसकी फ़ाइलें CDN पर प्रकाशित की जाती हैं। ऑब्जेक्ट स्टोरेज के लिए फ़ाइल‑सिस्टम राइट को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और `link` को तभी असाइन करें जब अपलोड सफल हो।

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

bitmap हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटी छवियों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को `output/fallback-images` में डिफ़ॉल्ट व्यवहार का उपयोग करके सहेजता है। बड़े bitmap और metafile रिसोर्सेज़, साथ ही SVG रिसोर्सेज़, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, जेनरेट किया गया लोकल रेफ़रेंस `fallback-images/image1.png` बन जाता है `https://cdn.example.com/presentations/quarterly-report/image1.png`। हैंडलर फ़ाइल‑सिस्टम पाथ्स केवल फ़ाइलें लिखते समय उपयोग करते हैं; Markdown में लिखे गए लिंक फ़ॉरवर्ड स्लैश और URL‑एस्केप्ड फ़ाइल नाम का उपयोग करते हैं। रिलेटिव लिंक बनाते समय भी वही नियम लागू करें: `/` उपयोग करें, प्लेटफ़ॉर्म‑स्पेसिफिक डायरेक्टरी सेपरेटर नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या एक हैंडलर दोनों रास्टर छवियों और SVG छवियों को प्रोसेस कर सकता है?**

नहीं। निर्यात के दौरान उत्पन्न bitmap और metafile रिसोर्सेज़ के लिए [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/imagesaving/) का उपयोग करें और SVG के रूप में उत्पन्न रिसोर्सेज़ के लिए [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) का उपयोग करें। प्रथम में एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) मिलता है; द्वितीय में एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) ऑब्जेक्ट मिलता है जिसका SVG डेटा [ISvgImage.SvgData](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/svgdata/) से पढ़ा जा सकता है। एक्सपोर्ट के दौरान rasterized किया गया स्रोत SVG `ImageSaving` द्वारा प्रोसेस होता है।

**जब इमेज‑सेविंग हैंडलर `false` लौटाता है तो क्या होता है?**

Aspose.Slides अपनी डिफ़ॉल्ट स्थानीय‑सेविंग व्यवहार का उपयोग करता है। छवि का स्थान और जेनरेट किया गया रेफ़रेंस [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/basepath/) और [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/hi/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) द्वारा नियंत्रित होता है।

**क्या हैंडलर बिना स्थानीय रूप से छवि सहेजे URL प्रदान कर सकता है?**

हां। हैंडलर छवि को ऑब्जेक्ट स्टोरेज पर अपलोड कर सकता है या किसी अन्य सर्विस को पास कर सकता है, परिणामी URL को `link` में असाइन कर सकता है, और `true` लौटा सकता है। हैंडलर को स्वयं प्रोसेसिंग पूरी करनी होगी; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रोक दिया जाता है।

**Markdown निर्यात हैंडलर से `InvalidOperationException` क्यों थ्रो करता है?**

यह तब होता है जब हैंडलर `true` लौटाता है लेकिन मान्य लिंक प्रदान नहीं करता। `true` लौटाने से पहले उस वैध रिलेटिव पाथ या बाहरी URL को असाइन करें जो Markdown में लिखा जाना चाहिए।

**छवि लिंक को कौन सा पाथ सेपरेटर उपयोग करना चाहिए?**

Markdown लिंक और URLs में फ़ॉरवर्ड स्लैश (`/`) का उपयोग करें। फ़ाइल‑सिस्टम पाथ्स के लिए केवल `Path.Combine` का उपयोग करें, फिर Markdown रेफ़रेंस को अलग से बनाएं या सामान्यीकृत करें।

**क्या Markdown निर्यात के दौरान हाइपरलिंक संरक्षित रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/net/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/net/slide-transition/) और [animations](/slides/hi/net/powerpoint-animation/) को कनवर्ट नहीं किया जाता।

**क्या प्रस्तुतियों को समानांतर में Markdown में बदला जा सकता है?**

आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। [multithreading guidelines](/slides/hi/net/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए अलग इंस्टेंस उपयोग करें।