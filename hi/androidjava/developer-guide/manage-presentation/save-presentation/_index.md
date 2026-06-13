---
title: "एंड्रॉइड पर प्रेजेंटेशन सहेजें"
linktitle: "प्रेजेंटेशन सहेजें"
type: docs
weight: 80
url: /hi/androidjava/save-presentation/
keywords:
- "PowerPoint सहेजें"
- "OpenDocument सहेजें"
- "प्रेजेंटेशन सहेजें"
- "स्लाइड सहेजें"
- "PPT सहेजें"
- "PPTX सहेजें"
- "ODP सहेजें"
- "फ़ाइल में प्रेजेंटेशन"
- "स्ट्रीम में प्रेजेंटेशन"
- "पूर्वनिर्धारित व्यू टाइप"
- "स्ट्रिक्ट Office Open XML फॉर्मेट"
- "Zip64 मोड"
- "थंबनेल रिफ्रेश करना"
- "सहेजने की प्रगति"
- "एंड्रॉइड"
- "जावा"
- "Aspose.Slides"
description: "जाने कैसे Java में Aspose.Slides for Android का उपयोग करके प्रेजेंटेशन सहेजें—PowerPoint या OpenDocument में निर्यात करें जबकि लेआउट, फॉन्ट और इफ़ेक्ट्स को बरकरार रखें।"
---
## **परिचय**

[एंड्रॉइड पर प्रेजेंटेशन खोलें](/slides/hi/androidjava/open-presentation/) बताता है कि कैसे [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रेजेंटेशन खोलें। यह लेख बताता है कि प्रेजेंटेशन कैसे बनाएँ और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में प्रेजेंटेशन की सामग्री होती है। चाहे आप शून्य से प्रेजेंटेशन बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्त होने पर उसे सहेजना आवश्यक होगा। Aspose.Slides for Android के साथ आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रेजेंटेशन सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रेजेंटेशन सहेजें**

`save` मेथड को कॉल करके प्रेजेंटेशन को फ़ाइल में सहेजें। मेथड को फ़ाइल नाम और सहेजने का फॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides के साथ प्रेजेंटेशन को सहेजने का तरीका दिखाता है।

```java
// Presentation क्लास का एक इंस्टेंस बनाते हैं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // यहाँ कुछ कार्य करें...

    // प्रेजेंटेशन को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रेजेंटेशन सहेजें**

`save` मेथड को आउटपुट स्ट्रीम पास करके प्रेजेंटेशन को स्ट्रीम में सहेजा जा सकता है। प्रेजेंटेशन को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में हम एक नया प्रेजेंटेशन बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```java
// Presentation क्लास का इंस्टेंस बनाते हैं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // प्रेजेंटेशन को स्ट्रीम में सहेजें।
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रेजेंटेशन सहेजें**

Aspose.Slides आपको उस प्रारम्भिक व्यू को सेट करने देता है जो जेनरेटेड प्रेजेंटेशन खुलते समय PowerPoint उपयोग करता है, यह [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। [ViewType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewtype/) एनेमरेशन से मान के साथ [setLastView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) मेथड का उपयोग करें।

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Strict Office Open XML फॉर्मेट में प्रेजेंटेशन सहेजें**

Aspose.Slides आपको प्रेजेंटेशन को Strict Office Open XML फॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) सेट करते हैं, तो आउटपुट फ़ाइल Strict Office Open XML फॉर्मेट में सहेजी जाएगी।

नीचे दिया गया उदाहरण प्रेजेंटेशन बनाता है और उसे Strict Office Open XML फॉर्मेट में सहेजता है।

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Presentation क्लास का इंस्टेंस बनाते हैं जो प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // प्रेज़ेंटेशन को स्ट्रिक्ट Office Open XML फॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 मोड में Office Open XML फॉर्मेट में प्रेजेंटेशन सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जो अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, साथ ही 65 535 (2^16‑1) फ़ाइलों तक सीमित करता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करें, चुनने देता है।

यह मेथड निम्न मोडों के साथ उपयोग किया जा सकता है:

- [IfNecessary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) ZIP64 फ़ॉर्मेट एक्सटेंशन केवल तभी उपयोग करता है जब प्रेजेंटेशन ऊपर दी गई सीमाओं को पार करता है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) ZIP64 फ़ॉर्मेट एक्सटेंशन कभी नहीं उपयोग करता।
- [Always](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है।

नीचे दिया गया कोड PPTX को ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके सहेजने का उदाहरण दर्शाता है:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रेजेंटेशन ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो एक [PptxException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxexception/) उत्पन्न किया जाता है।
{{% /alert %}}

## **थंबनेल रिफ्रेश किए बिना प्रेजेंटेशन सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड PPTX में प्रेजेंटेशन सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया गया है, तो सहेजते समय थंबनेल रिफ्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया गया है, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रेजेंटेशन में कोई थंबनेल नहीं है, तो नया थंबनेल नहीं बनाया जाता।

नीचे के कोड में प्रेजेंटेशन को उसके थंबनेल को रिफ्रेश किए बिना PPTX में सहेजा गया है।

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रेजेंटेशन सहेजने के समय आवश्यक समय को घटाने में मदद करता है।
{{% /alert %}}

## **प्रगति अपडेट प्रतिशत में प्राप्त करें**

[IProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/) इंटरफ़ेस का उपयोग [ISaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isaveoptions/) इंटरफ़ेस के `setProgressCallback` मेथड और एबस्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/) क्लास के द्वारा किया जाता है। `setProgressCallback` के साथ एक [IProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करके सहेजने की प्रक्रिया के प्रतिशत अपडेट प्राप्त किए जा सकते हैं।

निम्न कोड स्निपेट्स दिखाते हैं कि `IProgressCallback` का उपयोग कैसे करें।

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint स्प्लिटर ऐप](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रेजेंटेशन को कई फ़ाइलों में विभाजित करने की अनुमति देता है।
{{% /alert %}}

## **FAQ**

**क्या "फास्ट सेव" (इन्क्रीमेंटल सेव) समर्थित है जिससे केवल बदलाव लिखे जाएँ?**

नहीं। प्रत्येक बार सहेजना पूर्ण लक्ष्य फ़ाइल बनाता है; इन्क्रीमेंटल "फ़ास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/androidjava/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक और बाहरी लिंक वाली फाइलें क्या होती हैं?**

[हाइपरलिंक](/slides/hi/androidjava/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक वाली फाइलें (जैसे रिलेटिव पाथ वाली वीडियो) स्वतः कॉपी नहीं होतीँ—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडाटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक [दस्तावेज़ गुण](/slides/hi/androidjava/presentation-properties/) समर्थित हैं और सहेजते समय फ़ाइल में लिखे जाएंगे।