---
title: C++ में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/cpp/save-presentation/
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
- थंबनेल रिफ्रेश करना
- सेव प्रगति
- C++
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके C++ में प्रस्तुतियों को सहेजना सीखें—लेआउट, फ़ॉन्ट और इफ़ेक्ट को बनाए रखते हुए PowerPoint या OpenDocument में निर्यात करें।"
---
## **अवलोकन**

[C++ में प्रस्तुतियों को खोलें](/slides/hi/cpp/open-presentation/) ने बताया कि कैसे [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति खोलें। यह लेख बताता है कि कैसे प्रस्तुतियों को बनाएं और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप शून्य से प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्त होने पर आपको इसे सहेजना चाहिए। Aspose.Slides for C++ के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

Presentation क्लास की `Save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। मेथड को फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। निम्न उदाहरण दिखाता है कि Aspose.Slides के साथ प्रस्तुति को कैसे सहेजें।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को स्थापित करें।
auto presentation = MakeObject<Presentation>();

// यहाँ कुछ कार्य करें...
// प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को Presentation क्लास की `Save` मेथड में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे दिए गए उदाहरण में, हम नई प्रस्तुति बनाते हैं और इसे फ़ाइल स्ट्रीम में सहेजते हैं।

```cpp
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को स्थापित करें।
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// प्रस्तुति को स्ट्रीम में सहेजें।
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको ViewProperties क्लास के माध्यम से प्रारंभिक व्यू सेट करने की अनुमति देता है, जो PowerPoint उत्पन्न प्रस्तुति खोलते समय उपयोग करता है। ViewType एन्ह्यूमेरेशन से मान के साथ `set_LastView` मेथड का उपयोग करें।

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय PptxOptions क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप `Conformance.Iso29500_2008_Strict` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजी जाती है।

नीचे दिया गया उदाहरण एक प्रस्तुति बनाता है और इसे स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजता है।

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को स्थापित करें।
auto presentation = MakeObject<Presentation>();

// स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुति को सहेजें।
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Office Open XML फ़ॉर्मेट में Zip64 मोड के साथ प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और आर्काइव के कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, और आर्काइव में अधिकतम 65 535 (2^16‑1) फ़ाइलों की सीमा भी निर्धारित करता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

IPptxOptions::set_Zip64Mode मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करें, चुनने की सुविधा देता है।

यह मेथड निम्न मोडों के साथ उपयोग किया जा सकता है:

- `IfNecessary` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `Never` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग नहीं करता।
- `Always` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है।

निम्न कोड दर्शाता है कि कैसे PPTX के साथ ZIP64 फ़ॉर्मेट एक्सटेंशन सक्रिय करके प्रस्तुति को सहेजा जाए:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
`Zip64Mode.Never` के साथ सहेजने पर, यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो PptxException फेंका जाता है।
{{% /alert %}}

## **थंबनेल को रिफ्रेश किए बिना प्रस्तुतियों को सहेजें**

PptxOptions::set_RefreshThumbnail मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया गया है, तो सहेजते समय थंबनेल रिफ्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया गया है, तो वर्तमान थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई नया थंबनेल उत्पन्न नहीं होता।

नीचे के कोड में, प्रस्तुति को थंबनेल रिफ्रेश किए बिना PPTX में सहेजा गया है।

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने में लगने वाले समय को कम करने में मदद करता है।
{{% /alert %}}

## **सेव प्रगति अपडेट को प्रतिशत में प्राप्त करें**

IProgressCallback इंटरफ़ेस को ISaveOptions इंटरफ़ेस द्वारा प्रदर्शित `set_ProgressCallback` मेथड और एब्स्ट्रैक्ट SaveOptions क्लास के माध्यम से उपयोग किया जाता है। `set_ProgressCallback` के साथ एक IProgressCallback इम्प्लीमेंटेशन असाइन करें ताकि सेव‑प्रोग्रेस अपडेट को प्रतिशत के रूप में प्राप्त किया जा सके।

निम्न कोड स्निपेट्स दर्शाते हैं कि `IProgressCallback` का उपयोग कैसे करें।

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ने अपने API का उपयोग करके एक मुफ़्त PowerPoint Splitter ऐप विकसित किया है। यह ऐप चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित कर सकता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है ताकि केवल परिवर्तन लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूरी लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ़ है?**

नहीं। Presentation इंस्टेंस थ्रेड‑सेफ़ नहीं है; इसे केवल एक थ्रेड से सहेजें।

**सेव करते समय हाइपरलिंक और बाहरी लिंक वाली फ़ाइलों के साथ क्या होता है?**

हाइपरलिंक संरक्षित रहेंगे। बाहरी लिंक वाली फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडाटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सेव कर सकता हूँ?**

हां। मानक दस्तावेज़ प्रॉपर्टीज़ समर्थित हैं और सहेजने पर फ़ाइल में लिखी जाएँगी।