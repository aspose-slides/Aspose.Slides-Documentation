---
title: जावा में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/java/save-presentation/
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
- प्रीडिफाइन्ड व्यू टाइप
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रिफ्रेश करना
- सेव प्रोग्रेस
- जावा
- Aspose.Slides
description: "जावा में Aspose.Slides का उपयोग करके प्रस्तुतियों को कैसे सहेजें—PowerPoint या OpenDocument में निर्यात करते हुए लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाये रखें।"
---
## **परिचय**

[जावा में प्रस्तुतियों को खोलें](/slides/hi/java/open-presentation/) द्वारा बताया गया है कि कैसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति को खोला जाता है। यह लेख बताता है कि कैसे प्रस्तुतियों को बनाया और सहेजा जा सकता है। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री रहती है। चाहे आप नई प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, काम समाप्त होने पर उसे सहेजना आवश्यक है। Aspose.Slides for Java के साथ आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रस्तुति को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास के `save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। मेथड में फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण दिखाता है कि कैसे Aspose.Slides का उपयोग करके प्रस्तुति को सहेजा जाता है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ।
Presentation presentation = new Presentation();
try {
    // यहाँ कुछ काम करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास के `save` मेथड में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ।
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **प्रीडिफाइन्ड व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको वह प्रारंभिक व्यू सेट करने देता है जो PowerPoint द्वारा जेनरेटेड प्रस्तुति खोलते समय उपयोग किया जाता है, यह [ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। [ViewType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewtype/) एन्उमरेशन से मान लेकर [setLastView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#setLastView-int-) मेथड का प्रयोग करें।

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजने देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजी जाती है।

नीचे दिया गया उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजता है।

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएँ।
Presentation presentation = new Presentation();
try {
    // प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Zip64 मोड में ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक ऑफिस ओपन XML फ़ाइल एक ZIP आर्काइव होती है जिसमें अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा होती है, और यह आर्काइव अधिकतम 65 535 (2^16‑1) फ़ाइलों तक सीमित है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देते हैं।

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग कब करना है, चुनने की सुविधा देता है।

यह मेथड निम्नलिखित मोड्स के साथ उपयोग किया जा सकता है:

- [IfNecessary](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं से अधिक हो। यह डिफॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) कभी ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग नहीं करता।
- [Always](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है।

नीचे दिया गया कोड दर्शाता है कि कैसे PPTX को ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके सहेजा जाए:

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

जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रस्तुति ZIP32 फ़ॉर्मेट में सहेजी नहीं जा सकती तो एक [PptxException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxexception/) उत्पन्न होता है।

{{% /alert %}}

## **थंबनेल को रिफ्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया जाता है, तो सहेजने के दौरान थंबनेल रिफ्रेश होता है। यह डिफॉल्ट है।
- यदि `false` सेट किया जाता है, तो वर्तमान थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो नया थंबनेल नहीं बनाया जाता।

नीचे दिया गया कोड प्रस्तुति को PPTX में थंबनेल रिफ्रेश किए बिना सहेजता है।

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

यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति को सहेजने में लगने वाले समय को कम करने में मदद करता है।

{{% /alert %}}

## **प्रगति अपडेट को प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को [ISaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isaveoptions/) इंटरफ़ेस के `setProgressCallback` मेथड और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/) क्लास के माध्यम से उपयोग किया जाता है। `setProgressCallback` के साथ एक [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करके आप सहेजने की प्रगति अपडेट को प्रतिशत के रूप में प्राप्त कर सकते हैं।

नीचे दिया गया कोड स्निपेट दिखाता है कि `IProgressCallback` का उपयोग कैसे किया जाता है।

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
        // यहाँ प्रोग्रेस प्रतिशत मान का उपयोग करें।
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}

Aspose ने अपना खुद का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter ऐप](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेज कर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है ताकि केवल परिवर्तन ही लिखे जाएँ?**

नहीं। सहेजना प्रत्येक बार पूरा टारगेट फ़ाइल बनाता है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड-सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस [थ्रेड-सेफ़ नहीं है](/slides/hi/java/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक और बाहरी लिंक्ड फ़ाइलों का क्या होता है?**

[हाइपरलिंक](/slides/hi/java/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक्ड फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडाटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक [डॉक्युमेंट प्रॉपर्टीज़](/slides/hi/java/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखी जाएँगी।