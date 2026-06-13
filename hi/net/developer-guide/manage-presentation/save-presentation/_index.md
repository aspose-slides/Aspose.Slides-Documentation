---
title: ".NET में प्रस्तुतियों को सहेजें"
linktitle: "प्रस्तुति को सहेजें"
type: docs
weight: 80
url: /hi/net/save-presentation/
keywords:
- "PowerPoint सहेजें"
- "OpenDocument सहेजें"
- "प्रस्तुति सहेजें"
- "स्लाइड सहेजें"
- "PPT सहेजें"
- "PPTX सहेजें"
- "ODP सहेजें"
- "फ़ाइल में प्रस्तुति"
- "स्ट्रीम में प्रस्तुति"
- "पूर्वनिर्धारित व्यू टाइप"
- "स्ट्रिक्ट Office Open XML फॉर्मेट"
- "Zip64 मोड"
- "थंबनेल रिफ्रेश करना"
- "सहेजने की प्रगति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके .NET में प्रस्तुतियों को सहेजने का तरीका जानें—लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखते हुए PowerPoint या OpenDocument में निर्यात करें।"
---
## **अवलोकन**

[Open Presentations in C#](/slides/hi/net/open-presentation/) ने बताया कि प्रस्तुति खोलने के लिए [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का कैसे उपयोग किया जाता है। यह लेख बताता है कि प्रस्तुति कैसे बनाई और सहेजी जाए। [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप शून्य से प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्त होने पर आपको इसे सहेजना चाहिए। Aspose.Slides for .NET के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुति सहेजें**

Presentation क्लास के `Save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। मेथड को फ़ाइल नाम और सहेजने का प्रारूप पास करें। निम्न उदाहरण दिखाता है कि Aspose.Slides के साथ प्रस्तुति को कैसे सहेजा जाए।

```cs
// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation())
{
    // यहाँ कुछ कार्य करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रीम में प्रस्तुति सहेजें**

आप [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास के `Save` मेथड को आउटपुट स्ट्रीम पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में, हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```cs
// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुति सहेजें**

Aspose.Slides आपको वह प्रारंभिक व्यू सेट करने की अनुमति देता है जो PowerPoint उत्पन्न प्रस्तुति खोलते समय उपयोग करता है, जिसे आप [ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/) क्लास के माध्यम से कर सकते हैं। [LastView](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/lastview/) प्रॉपर्टी को [ViewType](https://reference.aspose.com/slides/hi/net/aspose.slides/viewtype/) एनेमरेशन के मान में से किसी मान पर सेट करें।

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **स्ट्रिक्ट Office Open XML फॉर्मेट में प्रस्तुति सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजने की सुविधा देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजी जाएगी।

नीचे का उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजता है।

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
using (Presentation presentation = new Presentation())
{
    // प्रस्तुति को स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजें।
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Office Open XML फॉर्मेट में Zip64 मोड के साथ प्रस्तुति सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव होती है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा लगाती है, और आर्काइव में 65 535 (2^16‑1) फ़ाइलों की सीमा भी होती है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देते हैं।

[IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/zip64mode/) प्रॉपर्टी आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग कब करना है, चुनने की अनुमति देती है।

यह प्रॉपर्टी निम्न मोड प्रदान करती है:

- `IfNecessary` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करता है।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निम्न कोड दिखाता है कि ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम होकर PPTX के रूप में प्रस्तुति को कैसे सहेजा जाए:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` के साथ सहेजते समय, यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता, तो एक [PptxException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **थंबनेल रिफ्रेश किए बिना प्रस्तुति सहेजें**

[PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) प्रॉपर्टी PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करती है:

- यदि इसे `true` सेट किया जाता है, तो सहेजने के दौरान थंबनेल रिफ्रेश होता है। यह डिफ़ॉल्ट है।
- यदि इसे `false` सेट किया जाता है, तो वर्तमान थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल उत्पन्न नहीं किया जाता।

नीचे के कोड में, प्रस्तुति को उसके थंबनेल को रिफ्रेश किए बिना PPTX में सहेजा गया है।

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति को सहेजने के लिए आवश्यक समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रगति अद्यतन को प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इंटरफ़ेस का उपयोग `ProgressCallback` प्रॉपर्टी के माध्यम से किया जाता है, जो कि [ISaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/isaveoptions/) इंटरफ़ेस और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveoptions/) क्लास द्वारा उजागर किया जाता है। `ProgressCallback` को एक [IProgressCallback](https://reference.aspose.com/slides/hi/net/aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करके आप प्रतिशत में सहेजने की प्रगति अद्यतनों को प्राप्त कर सकते हैं।

निम्न कोड स्निपेट्स दिखाते हैं कि `IProgressCallback` का उपयोग कैसे किया जाए।

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

{{% alert title="Info" color="info" %}}
Aspose ने अपनी स्वयं की API का उपयोग करके एक [नि:शुल्क PowerPoint Splitter ऐप](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइडों को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फास्ट सेव" (इंक्रिमेंटल सेव) समर्थित है ताकि केवल बदलाव लिखे जाएँ?**  
नहीं। सहेजने पर हर बार पूरा लक्षित फ़ाइल बनती है; इन्क्रीमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या कई थ्रेड से एक ही Presentation इंस्टेंस को सहेजना थ्रेड‑सेफ़ है?**  
नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/net/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक और बाहरी रूप से लिंक की गई फ़ाइलें क्या होती हैं?**  
[हाइपरलिंक](/slides/hi/net/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक की गई फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं डॉक्यूमेंट मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**  
हां। मानक [डॉक्यूमेंट प्रॉपर्टीज](/slides/hi/net/presentation-properties/) समर्थित हैं और सहेजते समय फ़ाइल में लिखी जाएँगी।