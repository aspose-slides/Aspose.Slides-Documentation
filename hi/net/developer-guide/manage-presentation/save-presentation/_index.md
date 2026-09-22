---
title: .NET में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/net/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- .NET
- C#
- Aspose.Slides
description: "C# में Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, तथा PPTX आउटपुट और प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **समीक्षा**

एक प्रस्तुति बनाने या [मौजूदा प्रस्तुति खोलें](/slides/hi/net/open-presentation/) के बाद, परिणाम लिखने के लिए [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड का उपयोग करें। Aspose.Slides for .NET एक प्रस्तुति को फ़ाइल या स्ट्रीम में PowerPoint, OpenDocument, PDF और अन्य फ़ॉर्मैट में सहेज सकता है। नीचे वाले अनुभाग मानक सहेजने की कार्रवाई और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को फ़ाइल में सहेजने के लिए, आउटपुट पथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) मान को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड में पास करें। फॉर्मेट मान निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाता है।

निम्न उदाहरण एक प्रस्तुति बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

// Add or modify presentation content here.

presentation.Save("Output.pptx", SaveFormat.Pptx);
```

## **प्रस्तुतियों को उनके मूल फ़ॉर्मैट में सहेजें**

फ़ाइल और स्ट्रीम पहचान उदाहरणों, नवीन निर्मित प्रस्तुतियों के व्यवहार, तथा स्रोत और आउटपुट फ़ॉर्मैट के अंतर के लिए, देखें [Determine the Original Presentation Format](/slides/hi/net/detect-presentation-source-format/)।

एक बैच‑प्रोसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मैट अग्रिम में ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, मूल फ़ॉर्मैट को [IPresentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/sourceformat/) प्रॉपर्टी से पढ़ें। परिणामस्वरूप [SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/sourceformat/) मान को [SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/tosaveformat/) को पास करें ताकि संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) मान प्राप्त हो, और फिर संशोधित प्रस्तुति को लिखने के लिए [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) का उपयोग करें।

निम्न पूर्ण उदाहरण एक इनपुट डायरेक्ट्री की सभी फ़ाइलों को प्रोसेस करता है, उनका शीर्षक अपडेट करता है, और उन्हें उसी फ़ॉर्मैट में आउटपुट डायरेक्ट्री में सहेजता है जिससे वे लोड किए गए थे:

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

var inputDirectory = "Input";
var outputDirectory = "Output";

Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory))
{
    try
    {
        using var presentation = new Presentation(inputPath);

        var sourceFormat = presentation.SourceFormat;
        var saveFormat = SlideUtil.ToSaveFormat(sourceFormat);

        presentation.DocumentProperties.Title = "Processed by the batch application";

        var outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
        presentation.Save(outputPath, saveFormat);
    }
    catch (ArgumentException exception)
    {
        Console.Error.WriteLine($"Cannot map the source format of '{inputPath}': {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Cannot process '{inputPath}': {exception.Message}");
    }
}
```

[SlideUtil.ToSaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.util/slideutil/tosaveformat/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने के फ़ॉर्मैट से मैप करता है। यह केवल प्रस्तुति स्रोत फ़ॉर्मैट को मैप करता है; यह PDF, HTML, TIFF या छवियों जैसे निर्यात फ़ॉर्मैट चुनने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/sourceformat/) मान पास करने पर एक [ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) उत्पन्न होता है।

पुराने PPT, PPS, और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को फ़ाइल एक्सटेंशन के बिना स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन पुराने उपप्रकारों को संरक्षित करना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मैट मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम और फ़ॉर्मैट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को अंतिम फ़ाइल पथ पर निर्भर हुए बिना लिखने के लिए, एक लिखने योग्य [Stream](https://learn.microsoft.com/en-us/dotnet/api/system.io.stream) और एक [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) मान को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड में पास करें। यह विधि तब उपयोगी होती है जब आउटपुट को वेब सर्विस से लौटाना हो, डेटाबेस में संग्रहित करना हो, या मेमोरी में प्रोसेस करना हो।

निम्न उदाहरण एक नई प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
using var outputStream = new FileStream("Output.pptx", FileMode.Create);

presentation.Save(outputStream, SaveFormat.Pptx);
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

आप यह निर्दिष्ट कर सकते हैं कि PowerPoint सहेजी गई प्रस्तुति को प्रारंभ में किस व्यू में खोलती है। सहेजने से पहले [ViewProperties.LastView](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/lastview/) प्रॉपर्टी को एक [ViewType](https://reference.aspose.com/slides/hi/net/aspose.slides/viewtype/) मान पर सेट करें।

निम्न उदाहरण स्लाइड मास्टर व्यू को प्रारंभिक व्यू के रूप में कॉन्फ़िगर करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मैट में प्रस्तुतियों को सहेजें**

Office Open XML की स्ट्रिक्ट प्रोफ़ाइल का पालन करने वाली PPTX फ़ाइल बनाने के लिए, एक [PptxOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/) इंस्टेंस बनाएं और उसकी [Conformance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/conformance/) प्रॉपर्टी को `Conformance.Iso29500_2008_Strict` पर सेट करें। फिर विकल्पों को [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) मेथड को पास करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PptxOptions
{
    Conformance = Conformance.Iso29500_2008_Strict
};

using var presentation = new Presentation();

presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
```

## **Zip64 मोड में Office Open XML फ़ॉर्मैट में प्रस्तुतियों को सहेजें**

एक मानक ZIP अभिलेख प्रत्येक प्रविष्टि, कुल अभिलेख आकार, और प्रविष्टियों की संख्या पर सीमा लगाता है। चूँकि PPTX फ़ाइल एक ZIP अभिलेख है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन आकार और प्रविष्टि‑गणना सीमाओं को बढ़ाते हैं।

[PptxOptions.Zip64Mode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/zip64mode/) प्रॉपर्टी का उपयोग करके नियंत्रित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- `IfNecessary` केवल तब ZIP64 का उपयोग करता है जब प्रस्तुति मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` ZIP64 एक्सटेंशन को निष्क्रिय करता है।
- `Always` हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्न उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    Zip64Mode = Zip64Mode.Always
};

presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, options);
```

{{% alert color="warning" title="Warning" %}}
यदि `Zip64Mode` को `Never` पर सेट किया जाता है और प्रस्तुति मानक ZIP सीमाओं में फिट नहीं हो पाती, तो सहेजने की प्रक्रिया एक [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) फेंकती है।
{{% /alert %}}

## **संपीड़न स्तरों के साथ Office Open XML फ़ॉर्मैट में प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए, आप [PptxOptions.CompressionLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/compressionlevel/) प्रॉपर्टी को सेट करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.export/compressionlevel/) एन्नुमरेशन निम्न मान प्रदान करता है:

- `None` डेटा को बिना संपीड़न के संग्रहीत करता है।
- `Level1` सबसे तेज़ संपीड़न और सबसे बड़ा संपीड़ित परिणाम देता है।
- `Level2` से `Level5` क्रमशः तेज़ सहेजने के बजाय छोटे आउटपुट को प्राथमिकता देते हैं।
- `Level6` सहेजने की गति और फ़ाइल आकार को संतुलित करता है। यह डिफ़ॉल्ट स्तर है।
- `Level7` और `Level8` छोटे आउटपुट को तेज़ सहेजने की तुलना में अधिक प्राथमिकता देते हैं।
- `Level9` सबसे मजबूत संपीड़न प्रदान करता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्न उदाहरण बिना संपीड़न के एक प्रस्तुति सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.None
};

presentation.Save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
```

निम्न उदाहरण अधिकतम संपीड़न स्तर का उपयोग करता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    CompressionLevel = CompressionLevel.Level9
};

presentation.Save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
```

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

जब कोई प्रस्तुति PPTX के रूप में सहेजी जाती है, तो [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/refreshthumbnail/) प्रॉपर्टी उसकी दस्तावेज़ थंबनेल को नियंत्रित करती है:

- `true` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करती है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनेल को संरक्षित रखती है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides नया नहीं बनाता।

निम्न उदाहरण थंबनेल को रीफ़्रेश किए बिना एक प्रस्तुति सहेजता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

var options = new PptxOptions
{
    RefreshThumbnail = false
};

presentation.Save("Output.pptx", SaveFormat.Pptx, options);
```

{{% alert color="info" title="Note" %}}
थंबनेल रीफ़्रेश को निष्क्रिय करने से PPTX फ़ाइल को सहेजने में लगने वाला समय घट सकता है।
{{% /alert %}}

## **प्रगति अपडेट को प्रतिशत में सहेजें**

सहेजने की प्रक्रिया की निगरानी करने के लिए, [IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करें और उसे [ISaveOptions.ProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isaveoptions/progresscallback/) प्रॉपर्टी को असाइन करें। Aspose.Slides तब निर्यात के दौरान [IProgressCallback.Reporting](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/reporting/) मेथड को प्रगति मानों के साथ कॉल करता है।

निम्न उदाहरण PDF निर्यात की प्रगति को कंसोल पर रिपोर्ट करता है:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var options = new PdfOptions
{
    ProgressCallback = new ExportProgressHandler()
};

using var presentation = new Presentation("Sample.pptx");

presentation.Save("Output.pdf", SaveFormat.Pdf, options);

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        var progress = Convert.ToInt32(progressValue);
        Console.WriteLine($"{progress}% of the file has been converted.");
    }
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API से बना है। यह चयनित स्लाइडों को अलग‑अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इन्क्रीमेंटल या “फ़ास्ट सहेज” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने की प्रक्रिया एक पूर्ण आउटपुट फ़ाइल लिखती है, न कि केवल बदलते भागों को अपडेट करती है।

**क्या कई थ्रेड एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/net/multithreading/)। प्रत्येक इंस्टेंस को एक समय में केवल एक थ्रेड से एक्सेस और सहेजें।

**जब मैं प्रस्तुति सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक की फ़ाइलें क्या होती हैं?**

[हाइपरलिंक](/slides/hi/net/manage-hyperlinks/) प्रस्तुति में रह जाते हैं। Aspose.Slides बाहरी लिंक की फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजी गई प्रस्तुति को अभी भी उन स्थानों तक पहुँचने में सक्षम होना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी, और निर्माण तिथि जैसी दस्तावेज़ मेटाडेटा सहेज सकता हूँ?**

हां। सहेजने से पहले उचित [दस्तावेज़ प्रॉपर्टीज़](/slides/hi/net/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिखता है।