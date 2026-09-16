---
title: ".NET में XAML में प्रस्तुतियों का निर्यात"
linktitle: "प्रस्तुति को XAML में"
type: docs
weight: 30
url: /hi/net/export-to-xaml/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- PowerPoint रूपांतरण
- OpenDocument रूपांतरण
- प्रस्तुति रूपांतरण
- PowerPoint से XAML
- OpenDocument से XAML
- प्रस्तुति से XAML
- PPT से XAML
- PPTX से XAML
- ODP से XAML
- PPT को XAML के रूप में सहेजें
- PPTX को XAML के रूप में सहेजें
- ODP को XAML के रूप में सहेजें
- PPT को XAML में निर्यात
- PPTX को XAML में निर्यात
- ODP को XAML में निर्यात
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में PowerPoint और OpenDocument स्लाइड्स को XAML में बदलें—एक तेज़, Office-मुक्त समाधान जो आपका लेआउट अपरिवर्तित रखता है।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों को XAML में कैसे निर्यात किया जाए। इसमें XAML का संक्षिप्त परिचय, डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में सहेजने का तरीका, और [XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) के माध्यम से निर्यात को अनुकूलित करने के उदाहरण शामिल हैं, जिसमें छिपी स्लाइडों का निर्यात भी शामिल है। लेख में फ़ॉन्ट फ़ॉलबैक, XAML स्टैक संगतता, और छिपी स्लाइड निर्यात व्यवहार से संबंधित कुछ सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **XAML के बारे में**

XAML एक XML-आधारित मार्कअप भाषा है जिसका उपयोग WPF (Windows Presentation Foundation), UWP (Universal Windows Platform), और Xamarin.Forms जैसे फ्रेमवर्क में यूज़र इंटरफ़ेस का वर्णन करने के लिए किया जाता है।

आप XAML फ़ाइलों को विज़ुअल डिज़ाइनर में संपादित कर सकते हैं या मार्कअप को सीधे लिख और संपादित कर सकते हैं।

## **डिफ़ॉल्ट विकल्पों के साथ XAML में प्रस्तुति निर्यात**

निम्नलिखित C# उदाहरण दिखाता है कि डिफ़ॉल्ट सेटिंग्स के साथ प्रस्तुति को XAML में कैसे निर्यात किया जाए:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

डिफ़ॉल्ट रूप से, निर्यातित स्लाइडें प्रक्रिया की वर्तमान कार्य निर्देशिका के `pres` उपफ़ोल्डर में सहेजी जाती हैं, जैसा कि [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) द्वारा लौटाया जाता है। फ़ोल्डर स्वतः बन जाता है, और आवश्यक छवियों को भी वहीं सहेजा जाता है।

आउटपुट फ़ोल्डर का नाम स्रोत फ़ाइल के नाम से उसका विस्तार हटाकर लिया जाता है। `pres.pptx` के लिए आउटपुट फ़ाइलें `pres/Slide_1.xaml`, `pres/Slide_2.xaml` आदि नाम से बनती हैं। यदि आप इनपुट प्रस्तुति के लिए पूर्ण पथ प्रदान करते हैं, तो भी आउटपुट फ़ोल्डर वर्तमान कार्य निर्देशिका के सापेक्ष बनाया जाता है, न कि इनपुट फ़ाइल के साथ।

## **कस्टम विकल्पों के साथ XAML में प्रस्तुति निर्यात**

Aspose.Slides को यह नियंत्रित करने के लिए कि वह प्रस्तुति को XAML में कैसे निर्यात करता है, आप [IXamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloptions/) इंटरफ़ेस का उपयोग कर सकते हैं।

आउटपुट को कस्टम स्थान पर सहेजने के लिए, [IXamlOutputSaver](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloutputsaver/) को लागू करें और अपनी कार्यान्वयन की एक instance को [OutputSaver](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/outputsaver/) प्रॉपर्टी में [XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) की असाइन करें।

XAML आउटपुट में छिपी स्लाइडों को शामिल करने के लिए, निम्नलिखित C# उदाहरण की तरह [ExportHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) प्रॉपर्टी को `true` सेट करें:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **निर्मित सभी XAML कलाकृतियों को पकड़ें**

एक XAML निर्यात प्रत्येक निर्यातित स्लाइड के लिए एक XAML दस्तावेज़ के साथ अतिरिक्त छवियों और सहायक संसाधनों को भी उत्पन्न कर सकता है। इन कलाकृतियों को प्राप्त करने के लिए डिफ़ॉल्ट फ़ाइल‑सिस्टम सहेवने के बजाय एक कस्टम [IXamlOutputSaver](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloutputsaver/) को [XamlOptions.OutputSaver](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/outputsaver/) पर असाइन करें। निर्यात को XAML‑विशिष्ट [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) ओवरलोड के साथ शुरू करें जो XAML विकल्पों को स्वीकार करता है।

### **कॉलबैक जीवनचक्र को समझें**

निर्यातक प्रत्येक उत्पन्न कलाकृति के लिए अलग‑अलग [IXamlOutputSaver.Save](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloutputsaver/save/) को कॉल करता है:

- `path` कलाकृति की पहचान करता है और इसमें सापेक्ष निर्देशिकाएँ शामिल हो सकती हैं। इस जानकारी को रखें क्योंकि XAML संसाधनों को सापेक्ष पथों से संदर्भित कर सकता है।
- `data` में कलाकृति के बाइट्स होते हैं। छवियों और अन्य द्विआधारी संसाधनों को पाठ के रूप में डिकोड नहीं किया जाना चाहिए।
- सहेवने वाला डेटा को लौटाने से पहले उसे बनाए रखने या स्थायी करने के लिए जिम्मेदार है। उदाहरण प्रत्येक बाइट एरे को एप्लिकेशन‑स्वामित्व वाली मेमोरी में कॉपी करते हैं।
- निर्यात को तभी सफल मानें जब प्रस्तुति सहेजने का ऑपरेशन लौटे और सभी कॉलबैक्स सफलतापूर्वक पूर्ण हो चुके हों। भंडारण त्रुटियों को नज़रअंदाज़ न करें या बिना देखे बैकग्राउंड लिखने न शुरू करें। यदि स्थायित्व बाद में होता है, तो समग्र सफलता की रिपोर्ट केवल उसी चरण के सफल होने के बाद ही करें।

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) भी कस्टम सहेवने वाले पर लागू होता है। इसका डिफ़ॉल्ट मान `false` है, जो छिपी‑स्लाइड XAML दस्तावेज़ों को बाहर रखता है। इसे `true` करने से वे और उनके निर्यात के लिए आवश्यक सभी संसाधन शामिल हो जाते हैं। संसाधन गणना प्रस्तुति पर निर्भर करती है; एक स्लाइड प्रति एक कॉलबैक या स्थिर कॉलबैक क्रम मानने से बचें।

### **मेमोरी में निर्यात करें और कलाकृतियों का निरीक्षण करें**

यह पूर्ण उदाहरण `pres.pptx` को लोड करता है, प्रत्येक कलाकृति को एक [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) में एकत्र करता है, और उसका नाम, प्रकार व बाइट काउंट प्रिंट करता है। यह प्रदान किए गए नामों को बिल्कुल वैसा ही रखता है। डुप्लिकेट नाम संग्रह को विफल कर देते हैं, न कि चुपचाप कलाकृति को अधिलेखित करते हैं।

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // केवल XAML को डिकोड करें, और केवल तभी जब पाठ्य निरीक्षण की आवश्यकता हो।
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

अपनी एप्लिकेशन से `InMemoryXamlExample.Run` को कॉल करें। विस्तार जाँच निरीक्षण के लिए उपयोगी होती है; सभी कलाकृतियों को रखें, जिसमें अपरिचित संसाधन प्रकार भी शामिल हैं। संग्रहित या प्रसारित करते समय बाइट्स को अपरिवर्तित रखें। केवल उन XAML के लिए जो पाठ्य प्रसंस्करण की आवश्यकता रखते हैं, [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) का उपयोग करें।

### **एक ZIP अभिलेख में एकत्रित कलाकृतियों को पैकेज करें**

यह स्वतंत्र उदाहरण निर्यात को एकत्रित करता है, उसके नामों को वैध करता है, और मूल बाइट्स को एक ZIP अभिलेख में लिखता है। एक अद्वितीय अभिलेख नाम समानांतर निर्यात कार्यों को अलग करता है। ZIP प्रविष्टियों में फॉरवर्ड स्लैश होते हैं और सापेक्ष निर्देशिकाएँ बरकरार रहती हैं। असुरक्षित नाम या सामान्यीकरण के बाद टकराने वाले नाम लिखे जाने से पहले संपूर्ण पैकेज को अस्वीकार कर देते हैं।

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP निर्देशिका को डिस्पोज़ करने के बाद, सफलता की रिपोर्ट करने से पहले अंतिम रूप दिया गया है।
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

अपनी एप्लिकेशन से `ZipXamlExample.Run` को कॉल करें। यह उदाहरण [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) का उपयोग करके एक स्थानीय अभिलेख लिखता है; निर्यातक स्वयं ढीली XAML या छवि फ़ाइलें नहीं लिखता। रिमोट स्टोरेज के लिए, अभिलेख‑लेखन चरण को एकत्रित बाइट एरे की अपलोड्स से बदलें। निर्यात‑कार्य पहचानकर्ता के साथ पूर्ण सापेक्ष कलाकृति नाम को ब्लॉब कुंजी के रूप में उपयोग करें, या डेटाबेस पंक्ति में कार्य पहचानकर्ता, सापेक्ष नाम, और द्विआधारी डेटा संग्रहीत करें। सभी अपलोड पूर्ण होने या डेटाबेस लेन‑देन कमिट होने के बाद ही कार्य को प्रकाशित करें। यदि स्थायित्व विफल हो तो आंशिक आउटपुट को साफ़ करें।

बड़ी प्रस्तुतियों के लिए, एक कस्टम सहेवने वाला प्रत्येक कलाकृति को सीधे एप्लिकेशन स्टोरेज में स्थायी कर सकता है, जिससे संपूर्ण निर्यात की अतिरिक्त प्रतिलिपि एप्लिकेशन मेमोरी में रखने की आवश्यकता नहीं रहती। निर्यातक अभी भी सभी उत्पन्न कलाकृतियों को मेमोरी में एकत्रित करता है, फिर सहेवने वाले को कॉल करता है। निर्यातक के दृष्टिकोण से प्रत्येक कॉलबैक को सिंक्रोनस रखें: गंतव्य द्वारा बाइट्स स्वीकार किए जाने के बाद ही लौटें, और त्रुटियों को कॉलर तक पहुँचने दें।

### **संसाधन नामों को बरकरार रखें और संदर्भों की जाँच करें**

- यदि गंतव्य को आवश्यकता हो तो पथ विभाजकों को सामान्यीकृत करें, लेकिन सापेक्ष निर्देशिकाएँ बरकरार रखें। जब तक प्रत्येक उत्पन्न नाम अद्वितीय है और संसाधन संदर्भ मान्य रहते हैं, तब तक केवल [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) का उपयोग न करें।
- गंतव्य‑विशिष्ट नाम मान्यता लागू करें। ढीली फ़ाइलें लिखते समय रूटेड पथ और ट्रैवर्सल खंडों को अस्वीकार करें, गंतव्य को [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) से हल करें, और इसे लक्ष्य निर्यात निर्देशिका के नीचे रहना सुनिश्चित करें, जिसमें containment जाँच में निर्देशिका विभाजक भी शामिल हो। प्रतीकात्मक लिंक वाले डायरेक्टरी का उपयोग न करें जो लिखने को पुनःनिर्देशित कर सकते हैं।
- प्रत्येक निर्यात कार्य के लिए अलग‑अलग सहेवने वाला और स्टोरेज नेमस्पेस रखें। विभाजक सामान्यीकरण और गंतव्य की केस‑संवेदनशीलता नियमों के अनुसार टकराव का पता लगाएँ।
- प्रकाशित करने से पहले प्रत्येक XAML दस्तावेज़ को XML के रूप में पार्स करें और उसकी फ़ाइल‑आधारित संसाधन संदर्भों, जैसे छवि `Source` या `ImageSource` एट्रिब्यूट, का निरीक्षण करें। प्रत्येक सापेक्ष URI को संबंधित XAML कलाकृति के निर्देशिका के विरुद्ध हल करें, परिणामी स्टोरेज नाम को सामान्यीकृत करें, और सुनिश्चित करें कि संबंधित शब्दकोश कुंजी, ZIP प्रविष्टि, या संग्रहीत ऑब्जेक्ट मौजूद है। बाहरी URI और XAML मार्कअप अभिव्यक्तियों को सापेक्ष फ़ाइल नामों से अलग‑अलग संभालें।

उदाहरण के लिए, यदि `pres/Slide_1.xaml` `images/image1.png` को संदर्भित करता है, तो संग्रहीत संसाधन `pres/images/image1.png` के रूप में उपलब्ध होना चाहिए। केवल `image1.png` रखना इस संबंध को तोड़ देगा। ऑब्जेक्ट स्टोरेज के लिए, नौकरी उपसर्ग के तहत उसी लेआउट को बरकरार रखें और उन संसाधन URLs को XAML उपभोक्ता के लिए सुलभ बनाएं। पूर्ण ZIP को पुनः खोलें, प्रविष्टि नामों और संसाधन बाइट्स की जाँच करें, और लक्ष्य XAML पर्यावरण में प्रतिनिधि स्लाइड लोड करें ताकि छवियों का सही रिज़ॉल्यूशन सुनिश्चित हो सके।

## **अक्सर पूछे जाने वाले प्रश्न**

**यदि मूल फ़ॉन्ट मशीन पर उपलब्ध नहीं है तो मैं पूर्वानुमेय फ़ॉन्ट कैसे सुनिश्चित कर सकता हूँ?**

[XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) में [DefaultRegularFont](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/defaultregularfont/) सेट करें — यह निर्यात के दौरान मूल फ़ॉन्ट अनुपलब्ध होने पर फ़ॉलबैक फ़ॉन्ट के रूप में उपयोग किया जाता है। यह गारंटी नहीं देता कि निर्मित XAML फ़ॉलबैक फ़ॉन्ट को संदर्भित करेगा या फ़ॉन्ट लक्ष्य मशीन पर उपलब्ध होगा। सुनिश्चित करें कि XAML द्वारा संदर्भित फ़ॉन्ट लक्षित वातावरण में उपलब्ध हों।

**क्या निर्यातित XAML केवल WPF के लिए है, या इसे अन्य XAML स्टैक्स में भी उपयोग किया जा सकता है?**

Aspose.Slides सार्वजनिक API के माध्यम से WPF XAML निर्यात करता है। UWP और Xamarin.Forms जैसे अन्य XAML स्टैक्स के साथ संगतता की गारंटी नहीं है। उत्पन्न मार्कअप को अपने लक्ष्य पर्यावरण में परीक्षण करें।

**क्या छिपी स्लाइडें समर्थित हैं, और उन्हें डिफ़ॉल्ट रूप से निर्यात से कैसे रोकें?**

डिफ़ॉल्ट रूप से, छिपी स्लाइडें शामिल नहीं होतीं। आप इस व्यवहार को [ExportHiddenSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) के माध्यम से [XamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/xamloptions/) में नियंत्रित कर सकते हैं — यदि आपको उन्हें निर्यात करने की आवश्यकता नहीं है तो इसे निष्क्रिय रखें।