---
title: "बाहरी रूप से लिंक की गई छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें"
type: docs
weight: 100
url: /hi/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint से HTML
- OpenDocument से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- लिंक्ड छवि
- बाहरी लिंक्ड छवि
- लिंक्ड संसाधन
- बाहरी संसाधन
- .NET
- C#
- Aspose.Slides
description: ".NET में Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ चित्र और अन्य संसाधन बाहरी लिंक्ड फ़ाइलों के रूप में सहेजे जाते हैं।"
---
## **अवलोकन**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्व-निहित HTML फ़ाइल में निर्यात करता है। चित्र और अन्य संसाधन सीधे HTML में लिखे जाते हैं, आमतौर पर Base64 डेटा के रूप में। यह तब उपयोगी होता है जब आपको एक पोर्टेबल फ़ाइल की आवश्यकता होती है, लेकिन यह हमेशा किसी वेबसाइट, CMS, या सर्वर‑साइड रूपांतरण पाइपलाइन के लिए सर्वोत्तम फ़ॉर्मेट नहीं होता।

बाहरी लिंक वाले संसाधनों का उपयोग तब करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करना;
- ब्राउज़र या CDN में चित्र, फ़ॉन्ट, ऑडियो या वीडियो को अलग‑अलग कैश करना;
- निर्यात के बाद उत्पन्न संसाधनों को निरीक्षण, प्रतिस्थापन, संपीड़न या पोस्ट‑प्रोसेस करना;
- आउटपुट संरचना को वेब एप्लिकेशन द्वारा अपेक्षित संरचना के करीब रखना।

सामान्य HTML रूपांतरण कार्यप्रवाह के लिए देखें [PowerPoint प्रस्तुतियों को HTML में बदलें](/slides/hi/net/convert-powerpoint-to-html/)। यह लेख निर्यात के संसाधन‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड रिसोर्स एक्सपोर्ट कैसे काम करता है**

[ILinkEmbedController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/) आपके एप्लिकेशन को यह तय करने देता है, संसाधन‑दर‑संसाधन, कि निर्यातक डेटा को HTML में एम्बेड करे या बाहरी रूप से सहेज कर लिंक लिखे।

इंटरफ़ेस में तीन मेथड हैं:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) तय करता है कि किसी संसाधन को लिंक किया जाए या एम्बेड।
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/geturl/) वह URL लौटाता है जिसे उत्पन्न HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाएगा।
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज लक्ष्य पर लिखता है।

फ़ाइल सिस्टम पाथ और ब्राउज़र URL अलग‑अलग विचार हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलों को डिस्क पर `html-output/assets` में लिखता है, जबकि HTML में रिलेटिव URL जैसे `assets/resource-1.svg` होते हैं। ब्राउज़र उन URL को उस फ़ाइल के सापेक्ष हल करता है जो लिंक रखती है। इसलिए, `presentation.html` से एक SVG फ़ाइल का लिंक `assets/resource-1.svg` उपयोग करता है, जबकि उसी `assets` फ़ोल्डर में सेव की गई तस्वीर का लिंक SVG फ़ाइल से `resource-4.jpg` होता है।

## **लिंक्ड रिसोर्स के साथ HTML निर्यात करना**

निम्न C# उदाहरण एक आउटपुट डायरेक्टरी बनाता है, HTML फ़ाइल को वहाँ सहेजता है, और लिंक्ड रिसोर्स को `assets` उप‑डायरेक्टरी में रखता है। कंट्रोलर सामान्य चित्र, फ़ॉन्ट, ऑडियो, वीडियो और CSS संसाधनों को लिंक करता है जब Aspose.Slides प्रदान करता है या सुरक्षित फ़ाइल एक्सटेंशन अनुमानित करता है। उन संसाधनों को जो पहचाने नहीं जाते, एम्बेड ही रहेगी।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

निर्यात के बाद, आउटपुट फ़ोल्डर की संरचना इस प्रकार होगी:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

विशिष्ट फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर चित्र सामान्यतः JPEG या PNG के रूप में निर्यात होते हैं। Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए कोडेक से अलग कोडेक चुन सकता है यदि वह छोटा या अधिक उपयुक्त फ़ाइल उत्पन्न करता है। पारदर्शी चित्र PNG के रूप में निर्यात होते हैं।

## **डिप्लॉयमेंट के लिए URL चुनना**

यह नमूना एक रिलेटिव URL प्रीफ़िक्स उपयोग करता है: `assets/`। यदि `presentation.html` को `html-output/presentation.html` से खोला जाए, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड रिसोर्स दूसरे लिंक्ड रिसोर्स को संदर्भित करता है, तो नमूना [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/geturl/) में `referrer` पैरामीटर का उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलें किसी अन्य स्थान पर डिप्लॉय की जाती हैं तो अलग URL प्रीफ़िक्स उपयोग करें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के साथ ही हो, तो `assets/` उपयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो, तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थैतिक फ़ाइल सर्वर पर अपलोड की गई हों, तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/geturl/) द्वारा लौटाया गया URL, [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/saveexternal/) द्वारा लिखी गई फ़ाइल के अंतिम डिप्लॉय किए गए स्थान से मेल खाना चाहिए। सर्वर एप्लिकेशन में, प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज प्रीफ़िक्स उपयोग करें ताकि किसी अन्य निर्यात की फ़ाइलें ओवरराइट न हों।

## **कब एम्बेड करना बेहतर है**

एम्बेडेड Base64 HTML अभी भी उपयोगी है जब आउटपुट को एक ही फ़ाइल में होना आवश्यक हो, जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या ऐसा दस्तावेज़ जो संपत्ति फ़ोल्डर के बिना स्थानांतरित किया जाएगा। लिंक्ड रिसोर्स तब बेहतर फिट होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा ऑप्टिमाइज़ किया जाएगा, या ब्राउज़र द्वारा HTML से स्वतंत्र रूप से कैश किया जाएगा।

## **FAQ**

**क्या मैं केवल चित्रों को बाहरी बना सकता हूँ और अन्य संसाधनों को एम्बेड रख सकता हूँ?**

हां। [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) में उन कंटेंट टाइप्स के लिए `LinkEmbedDecision.Link` लौटाएं जिन्हें आप अलग फ़ाइलों के रूप में सहेजना चाहते हैं, और बाकी सभी के लिए `LinkEmbedDecision.Embed` लौटाएं।

**निर्यात किए गए चित्र का एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों होता है?**

Aspose.Slides HTML निर्यात के दौरान रास्टर चित्रों को पुनः‑एन्कोड कर सकता है ताकि आकार या ब्राउज़र संगतता में सुधार हो। उदाहरण के लिए, स्रोत फ़ाइल में एक चित्र को JPEG या PNG के रूप में लिखा जा सकता है, यह अंतिम रेंडर परिणाम पर निर्भर करता है।

**क्या रिलेटिव URL काम करेंगे यदि मैं HTML फ़ाइल को स्थानांतरित कर दूँ?**

रिलेटिव URL केवल तब काम करेंगे जब वही रिलेटिव फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के साथ ही रखा जाना चाहिए, जब तक आप अलग URL प्रीफ़िक्स न उत्पन्न करें।

**क्या सर्वर एप्लिकेशन को एक ही आउटपुट फ़ोल्डर फिर से उपयोग करना चाहिए?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। इससे फ़ाइलनाम टकराव से बचा जा सकता है और एक निर्यात के द्वारा दूसरे निर्यात द्वारा उत्पन्न संसाधनों को ओवरराइट करने से बचा जा सकता है।