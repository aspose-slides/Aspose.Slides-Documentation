---
title: .NET में प्रेज़ेंटेशन सहेजें
linktitle: प्रेज़ेंटेशन सहेजें
type: docs
weight: 80
url: /hi/net/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रेज़ेंटेशन सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रेज़ेंटेशन
- स्ट्रीम में प्रेज़ेंटेशन
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में प्रेज़ेंटेशन कैसे सहेजें—PowerPoint या OpenDocument में निर्यात करें जबकि लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखें।"
---
## **अवलोकन**

[C# में प्रेज़ेंटेशन खोलें](/slides/hi/net/open-presentation/) दर्शाता है कि [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके प्रेज़ेंटेशन को कैसे खोलें। यह लेख बताता है कि प्रेज़ेंटेशन कैसे बनाएं और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास में प्रेज़ेंटेशन की सामग्री होती है। चाहे आप शून्य से प्रेज़ेंटेशन बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्त होने पर आपको इसे सहेजना चाहिए। Aspose.Slides for .NET के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रेज़ेंटेशन को सहेजने के विभिन्न तरीकों की व्याख्या करता है।

## **फ़ाइलों में प्रेज़ेंटेशन सहेजें**

[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की `Save` मेथड को कॉल करके प्रेज़ेंटेशन को फ़ाइल में सहेजें। मेथड को फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides के साथ प्रेज़ेंटेशन को सहेजने का तरीका दिखाता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // यहाँ कुछ कार्य करें...

    // प्रेज़ेंटेशन को फ़ाइल में सहेजें।
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रीम में प्रेज़ेंटेशन सहेजें**

आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास की `Save` मेथड में आउटपुट स्ट्रीम पास करके प्रेज़ेंटेशन को स्ट्रीम में सहेज सकते हैं। प्रेज़ेंटेशन को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में, हम एक नया प्रेज़ेंटेशन बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // प्रेज़ेंटेशन को स्ट्रीम में सहेजें।
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **पहले से परिभाषित व्यू टाइप के साथ प्रेज़ेंटेशन सहेजें**

Aspose.Slides आपको वह प्रारंभिक व्यू सेट करने देता है जिसे PowerPoint जनरेटेड प्रेज़ेंटेशन खोलते समय उपयोग करता है, यह [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/) की `LastView` प्रॉपर्टी को [ViewType](https://reference.aspose.com/slides/hi/net/aspose.slides/viewtype/) एनेमरेशन में से किसी मान पर सेट करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें**

Aspose.Slides आपको स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजने की सुविधा देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/) क्लास का उपयोग करें और उसकी `Conformance` प्रॉपर्टी सेट करें। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजी जाएगी।

नीचे का उदाहरण एक प्रेज़ेंटेशन बनाता है और उसे स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजता है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें।
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ज़िप64 मोड में ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें**

ऑफिस ओपन XML फ़ाइल एक ZIP आर्काइव होती है जिसमें अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा होती है, तथा फाइलों की संख्या 65 535 (2^16‑1) तक सीमित रहती है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देता है।

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/zip64mode/) प्रॉपर्टी आपको ऑफिस ओपन XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करना है, चुनने की अनुमति देती है।

यह प्रॉपर्टी निम्न मोड प्रदान करती है:

- `IfNecessary` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करती है जब प्रेज़ेंटेशन ऊपर दी गई सीमाओं को पार करता है। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करती।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करती है।

नीचे दिया गया कोड दिखाता है कि कैसे ZIP64 फ़ॉर्मेट एक्सटेंशन को सक्षम करके PPTX फ़ाइल के रूप में प्रेज़ेंटेशन सहेजा जाता है:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
जब आप `Zip64Mode.Never` के साथ सहेजते हैं, तो यदि प्रेज़ेंटेशन ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो एक [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) उत्पन्न होता है।
{{% /alert %}}

## **कम्प्रेशन लेवल के साथ ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें**

बड़े प्रेज़ेंटेशन के साथ काम करते समय, आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाने के लिए कम्प्रेशन लेवल को समायोजित कर सकते हैं। आपकी आवश्यकताओं के अनुसार आप तेज़ प्रोसेसिंग या छोटा आउटपुट फ़ाइल आकार पसंद कर सकते हैं।

Aspose.Slides [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/compressionlevel/) प्रॉपर्टी प्रदान करता है, जिससे आप ऑफिस ओपन XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजते समय उपयोग होने वाले कम्प्रेशन लेवल को निर्दिष्ट कर सकते हैं।

उपलब्ध कम्प्रेशन लेवल यह हैं:

- **None**: कोई कम्प्रेशन लागू नहीं किया जाता। फ़ाइलें जैसा है वैसा संग्रहीत होती हैं।
- **Level1**: सबसे तेज़ कम्प्रेशन, सबसे कम कम्प्रेशन अनुपात।
- **Level2**: **Level1** से थोड़ा बेहतर कम्प्रेशन अनुपात के साथ तेज़ कम्प्रेशन।
- **Level3**: **Level2** से बेहतर कम्प्रेशन, मध्यम प्रोसेसिंग समय पर प्रभाव।
- **Level4**: **Level3** से बेहतर कम्प्रेशन।
- **Level5**: **Level4** से सुधरा हुआ कम्प्रेशन, अतिरिक्त प्रोसेसिंग समय।
- **Level6**: स्टैंडर्ड कम्प्रेशन जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट कम्प्रेशन लेवल* है।
- **Level7**: **Level6** से बेहतर कम्प्रेशन, धीमी प्रोसेसिंग।
- **Level8**: **Level7** से बेहतर कम्प्रेशन।
- **Level9**: अधिकतम कम्प्रेशन। सबसे छोटा फ़ाइल आकार प्राप्त होता है लेकिन प्रोसेसिंग समय सबसे लंबा रहता है।

नीचे का उदाहरण दिखाता है कि कैसे *कम्प्रेशन के बिना* PPTX फ़ाइल के रूप में प्रेज़ेंटेशन सहेजें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

यह उदाहरण दिखाता है कि कैसे *अधिकतम कम्प्रेशन* के साथ PPTX फ़ाइल के रूप में प्रेज़ेंटेशन सहेजें:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **थंबनेल को रीफ़्रेश किए बिना प्रेज़ेंटेशन सहेजें**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) प्रॉपर्टी PPTX में प्रेज़ेंटेशन सहेजते समय थंबनेल जेनरेशन को नियंत्रित करती है:

- यदि `true` सेट किया गया है, तो सहेजते समय थंबनेल रीफ़्रेश हो जाता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया गया है, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रेज़ेंटेशन में थंबनेल नहीं है, तो कोई नया जेनरेट नहीं होगा।

नीचे के कोड में प्रेज़ेंटेशन को थंबनेल रीफ़्रेश किए बिना PPTX में सहेजा गया है।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रेज़ेंटेशन सहेजने में लगने वाले समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रगति अपडेट को प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इंटरफ़ेस का उपयोग [ISaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isaveoptions/) इंटरफ़ेस द्वारा एक्सपोज़ किए गए `ProgressCallback` प्रॉपर्टी और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/) क्लास के माध्यम से किया जाता है। `ProgressCallback` को एक [IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करने पर सेव‑प्रोग्रेस अपडेट प्रतिशत के रूप में प्राप्त होते हैं।

नीचे की कोड स्निपेट्स दिखाती हैं कि `IProgressCallback` का उपयोग कैसे करें।

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter एप्लिकेशन](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह एप्लिकेशन चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रेज़ेंटेशन को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **FAQ**

**क्या "फ़ास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है जिससे केवल परिवर्तन ही लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूर्ण टारगेट फ़ाइल बनती है; इन्क्रिमेंटल "फ़ास्ट सेव" समर्थित नहीं है।

**क्या कई थ्रेड्स से एक ही Presentation इंस्टेंस को सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस थ्रेड‑सेफ़ नहीं है; इसे केवल एक थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक्स और बाहरी लिंक वाली फ़ाइलें क्या होती हैं?**

[Hyperlinks](/slides/hi/net/manage-hyperlinks/) संरक्षित रहती हैं। बाहरी लिंक वाली फ़ाइलें (जैसे रिलेटिव पाथ वाली वीडियोज़) स्वतः कॉपी नहीं होतीँ—सुनिश्चित करें कि संदर्भित पाथ्स उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडाटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सेव कर सकता हूँ?**

हां। मानक [डॉक्यूमेंट प्रॉपर्टीज](/slides/hi/net/presentation-properties/) समर्थित हैं और फ़ाइल सहेजते समय लिखी जाएँगी।