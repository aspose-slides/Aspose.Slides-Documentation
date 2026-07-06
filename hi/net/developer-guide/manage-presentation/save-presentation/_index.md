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
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके .NET में प्रस्तुतियों को कैसे सहेजें—PowerPoint या OpenDocument में निर्यात करें जबकि लेआउट, फ़ॉन्ट और इफेक्ट्स बरकरार रहें।"
---
## **अवलोकन**

[Open Presentations in C#](/slides/hi/net/open-presentation/) बताता है कि प्रस्तुति खोलने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग कैसे किया जाता है। यह लेख बताता है कि प्रस्तुतियों को कैसे बनाया और सहेजा जाए। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप शून्य से प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर आपको इसे सहेजना होगा। Aspose.Slides for .NET के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

Presentation क्लास के `Save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। मेथड में फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides का उपयोग करके प्रस्तुति को कैसे सहेजना है, दिखाता है।

```cs
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // यहाँ कुछ कार्य करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को Presentation क्लास के `Save` मेथड में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे उदाहरण में हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```cs
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको यह सेट करने देता है कि उत्पन्न प्रस्तुति के खोलते समय PowerPoint कौन‑सा प्रारम्भिक दृश्य उपयोग करे, यह ViewProperties क्लास के माध्यम से किया जाता है। ViewProperties क्लास की `LastView` प्रॉपर्टी को ViewType एनेमरेशन के किसी मान पर सेट करें।

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय PptxOptions क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजी जाती है।

नीचे का उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजता है।

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
using (Presentation presentation = new Presentation())
{
    // प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजें।
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **ऑफ़िस ओपन XML फ़ॉर्मेट में ज़िप64 मोड के साथ प्रस्तुतियों को सहेजें**

एक Office Open XML फ़ाइल एक ZIP अभिलेख है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और अभिलेख के कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, और साथ ही अभिलेख में 65 535 (2^16‑1) फ़ाइलों की सीमा रखता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/zip64mode/) प्रॉपर्टी आपको Office Open XML फ़ाइल को सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग कब करना है, चुनने की अनुमति देती है।

यह प्रॉपर्टी निम्नलिखित मोड प्रदान करती है:

- `IfNecessary` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है जब प्रस्तुति ऊपर बताए गए सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करता।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निम्न कोड दिखाता है कि ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके PPTX फ़ाइल को कैसे सहेजा जाए:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="ध्यान दें" color="warning" %}}
जब आप `Zip64Mode.Never` के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो एक [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) उत्पन्न किया जाता है।
{{% /alert %}}

## **ऑफ़िस ओपन XML फ़ॉर्मेट में संपीड़न स्तर के साथ प्रस्तुतियों को सहेजें**

बड़ी प्रस्तुतियों के साथ काम करते समय आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाए रखने के लिए संपीड़न स्तर को समायोजित कर सकते हैं। आपकी आवश्यकता के आधार पर आप तेज़ प्रोसेसिंग या छोटे आउटपुट फ़ाइलें पसंद कर सकते हैं।

Aspose.Slides [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/compressionlevel/) प्रॉपर्टी प्रदान करता है, जो Office Open XML फ़ॉर्मेट में प्रस्तुति सहेजते समय उपयोग किए जाने वाले संपीड़न स्तर को निर्दिष्ट करने की अनुमति देता है।

उपलब्ध संपीड़न स्तर निम्नलिखित हैं:

- **None**: कोई संपीड़न लागू नहीं किया जाता। फ़ाइलें जैसा है वैसा ही संग्रहीत होती हैं।
- **Level1**: सबसे तेज़ संपीड़न, सबसे कम संपीड़न अनुपात के साथ।
- **Level2**: **Level1** से थोड़ा बेहतर संपीड़न अनुपात के साथ तेज़ संपीड़न।
- **Level3**: **Level2** से बेहतर संपीड़न, प्रोसेसिंग समय पर मध्यम प्रभाव के साथ।
- **Level4**: **Level3** से बेहतर संपीड़न।
- **Level5**: **Level4** से सुधरा हुआ संपीड़न, अतिरिक्त प्रोसेसिंग समय के साथ।
- **Level6**: मानक संपीड़न जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट संपीड़न स्तर* है।
- **Level7**: **Level6** से बेहतर संपीड़न, धीमी प्रोसेसिंग के साथ।
- **Level8**: **Level7** से बेहतर संपीड़न।
- **Level9**: अधिकतम संपीड़न। सबसे छोटा फ़ाइल आकार उत्पन्न करता है लेकिन सबसे लंबा प्रोसेसिंग समय लेता है।

निम्न उदाहरण दिखाता है कि *बिना संपीड़न* के PPTX फ़ाइल के रूप में प्रस्तुति को कैसे सहेजा जाए:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

यह उदाहरण दिखाता है कि *अधिकतम संपीड़न* के साथ PPTX फ़ाइल के रूप में प्रस्तुति को कैसे सहेजा जाए:
```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) प्रॉपर्टी PPTX में प्रस्तुति सहेजते समय थंबनेल जेनरेशन को नियंत्रित करती है:

- यदि `true` पर सेट किया गया है, तो सहेजते समय थंबनेल रीफ़्रेश हो जाता है। यह डिफ़ॉल्ट है।
- यदि `false` पर सेट किया गया है, तो वर्तमान थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल उत्पन्न नहीं किया जाता।

नीचे के कोड में प्रस्तुति को PPTX में थंबनेल को रीफ़्रेश किए बिना सहेजा गया है।

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="सूचना" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति को सहेजने के समय आवश्यक समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रगति अपडेट प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इंटरफ़ेस को [ISaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isaveoptions/) इंटरफ़ेस द्वारा प्रदर्शित `ProgressCallback` प्रॉपर्टी और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/) क्लास के माध्यम से उपयोग किया जाता है। `ProgressCallback` को एक [IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करके आप प्रतिशत के रूप में सहेजने‑प्रगति अपडेट प्राप्त कर सकते हैं।

निम्न कोड स्निपेट्स दिखाते हैं कि `IProgressCallback` कैसे उपयोग किया जाता है।

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
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

{{% alert title="सूचना" color="info" %}}
Aspose ने अपने API का उपयोग करके एक **मुफ़्त PowerPoint Splitter** एप्लिकेशन विकसित किया है। यह एप्लिकेशन चयनित स्लाइडों को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की अनुमति देता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है जिससे केवल परिवर्तन लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूर्ण लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस थ्रेड‑सेफ़ नहीं है; इसे एकल थ्रेड से सहेजें।

**सहेजने पर हाइपरलिंक और बाह्य लिंक वाली फ़ाइलों के साथ क्या होता है?**

[हाइपरलिंक](/slides/hi/net/manage-hyperlinks/) संरक्षित रहेंगे। बाह्य लिंक वाली फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक [दस्तावेज़ गुण](/slides/hi/net/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखे जाएंगे।