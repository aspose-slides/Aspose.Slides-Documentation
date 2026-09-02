---
title: Java में प्रस्तुतियों को सहेजें
linktitle: प्रेज़ेंटेशन सहेजें
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
- पूर्वनिर्धारित व्यू टाइप
- स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में प्रस्तुतियों को सहेजना सीखें—लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखते हुए PowerPoint या OpenDocument में निर्यात करें।"
---
## **सारांश**

[जावा में प्रस्तुतियों को खोलें](/slides/hi/java/open-presentation/) वर्णन करता है कि कैसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुतीकरण खोला जाता है। यह लेख बताता है कि कैसे प्रस्तुतियों को बनाया और सहेजा जाता है। [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास में प्रस्तुतीकरण की सामग्री होती है। चाहे आप नई प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर इसे सहेजना चाहेंगे। Aspose.Slides for Java के साथ, आप **file** या **stream** में सहेज सकते हैं। यह लेख विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

Presentation क्लास की `save` मेथड को कॉल करके एक प्रस्तुति को फ़ाइल में सहेजें। मेथड को फ़ाइल नाम और सहेजने का फ़ॉर्मेट पास करें। निम्न उदाहरण दिखाता है कि Aspose.Slides के साथ प्रस्तुति को कैसे सहेजा जाता है।

```java
import com.aspose.slides.*;

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है।
Presentation presentation = new Presentation();
try {
    // यहाँ कुछ कार्य करें...

    // प्रेज़ेंटेशन को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास की `save` मेथड में पास करके एक प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में, हम नई प्रस्तुति बनाते हैं और इसे फ़ाइल स्ट्रीम में सहेजते हैं।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // प्रेज़ेंटेशन को स्ट्रीम में सहेजें।
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides आपको शुरुआती व्यू सेट करने देता है जो PowerPoint उत्पन्न प्रस्तुति खोलते समय उपयोग करता है, यह [ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। [setLastView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#setLastView-int-) मेथड को [ViewType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewtype/) एन्यूमेरेशन से मान के साथ उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट में सहेजने देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट में सहेजी जाती है।

नीचे का उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट में सहेजता है।

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// एक Presentation क्लास का उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
Presentation presentation = new Presentation();
try {
    // प्रेज़ेंटेशन को स्ट्रिक्ट ऑफिस ओपन XML फॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ज़िप64 मोड में ऑफिस ओपन XML फॉर्मेट में प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार और संपूर्ण आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा लागू करता है, तथा आर्काइव को 65 535 (2^16‑1) फ़ाइलों तक सीमित करता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग कब करना है, चुनने की सुविधा देता है।

यह मेथड निम्न मोड में उपयोग किया जा सकता है:

- [यदि आवश्यक हो](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#IfNecessary) ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग केवल तब करता है जब प्रस्तुति ऊपर दी गई सीमाओं को पार कर जाती है। यह डिफ़ॉल्ट मोड है।
- [कभी नहीं](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) ZIP64 फ़ॉर्मेट एक्सटेंशन का कभी उपयोग नहीं करता।
- [हमेशा](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निम्न कोड दिखाता है कि ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके PPTX फ़ाइल के रूप में प्रस्तुति को कैसे सहेजें:

```java
import com.aspose.slides.*;

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
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता है तो एक [PptxException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **ऑफ़िस ओपन XML फॉर्मेट में संपीड़न स्तरों के साथ प्रस्तुतियों को सहेजें**

जब बड़े आकार की प्रस्तुतियों के साथ काम किया जाता है, तो आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाने के लिए संपीड़न स्तर को समायोजित कर सकते हैं। आपके आवश्यकताओं के आधार पर आप तेज़ प्रोसेसिंग या छोटे आउटपुट फ़ाइल को प्राथमिकता दे सकते हैं।

Aspose.Slides [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) मेथड प्रदान करता है, जिससे आप Office Open XML फॉर्मेट में प्रस्तुति को सहेजते समय उपयोग किए जाने वाले संपीड़न स्तर को निर्दिष्ट कर सकते हैं।

उपलब्ध संपीड़न स्तर निम्नलिखित हैं:

- [**None**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#None): कोई संपीड़न लागू नहीं किया जाता। फ़ाइलें जैसा है वैसा संग्रहीत रहती हैं।
- [**Level1**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level1): सबसे तेज़ संपीड़न, सबसे कम संपीड़न अनुपात के साथ।
- [**Level2**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level2): **Level1** से थोड़ा बेहतर संपीड़न अनुपात के साथ तेज़ संपीड़न।
- [**Level3**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level3): **Level2** से बेहतर संपीड़न, प्रोसेसिंग समय पर मध्यम प्रभाव के साथ।
- [**Level4**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level4): **Level3** से बेहतर संपीड़न।
- [**Level5**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level5): **Level4** से सुधारित संपीड़न, अतिरिक्त प्रोसेसिंग समय के साथ।
- [**Level6**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level6): मानक संपीड़न जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट संपीड़न स्तर* है।
- [**Level7**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level7): **Level6** से बेहतर संपीड़न, धीमी प्रोसेसिंग के साथ।
- [**Level8**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level8): **Level7** से बेहतर संपीड़न।
- [**Level9**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level9): अधिकतम संपीड़न। सबसे छोटी फ़ाइल आकार उत्पन्न करता है, लेकिन सबसे लंबा प्रोसेसिंग समय लेता है।

निम्न उदाहरण दिखाता है कि PPTX फ़ाइल को *बिना संपीड़न* के कैसे सहेजा जाए:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

यह उदाहरण दिखाता है कि PPTX फ़ाइल को *अधिकतम संपीड़न* के साथ कैसे सहेजा जाए:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड PPTX में प्रस्तुति सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया गया है, तो सहेजते समय थंबनेल रीफ़्रेश किया जाता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया गया है, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल जनरेट नहीं किया जाता।

नीचे के कोड में, प्रस्तुति को उसके थंबनेल को रीफ़्रेश किए बिना PPTX में सहेजा गया है।

```java
import com.aspose.slides.*;

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
यह विकल्प PPTX फॉर्मेट में प्रस्तुति को सहेजने के लिए आवश्यक समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रगति अपडेट को प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को [ISaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isaveoptions/) इंटरफ़ेस और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveoptions/) क्लास द्वारा उजागर `setProgressCallback` मेथड के माध्यम से उपयोग किया जाता है। `setProgressCallback` के साथ एक [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करके आप सहेजने की प्रगति अपडेट्स को प्रतिशत के रूप में प्राप्त कर सकते हैं।

निम्न कोड स्निपेट दिखाता है कि `IProgressCallback` कैसे उपयोग करें।

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपने API का उपयोग करके एक मुफ्त PowerPoint Splitter ऐप ([free PowerPoint Splitter app](https://products.aspose.app/slides/hi/splitter)) विकसित किया है। यह ऐप चयनित स्लाइड्स को नए PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फ़ास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है जिससे केवल बदलाव लिखे जाएँ?**  
नहीं। सहेजने पर हर बार पूर्ण लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फ़ास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टैंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ़ है?**  
नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टैंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/java/multithreading/); इसे केवल एक थ्रेड से सहेजें।

**सहेजने पर हाइपरलिंक्स और बाहरी लिंक्ड फ़ाइलों के साथ क्या होता है?**  
[हाइपरलिंक्स](/slides/hi/java/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक्ड फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ्स सुलभ रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**  
हां। मानक [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/java/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिखी जाती हैं।