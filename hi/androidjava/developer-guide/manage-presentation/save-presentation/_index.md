---
title: Android पर प्रेजेंटेशन सहेजें
linktitle: प्रेजेंटेशन सहेजें
type: docs
weight: 80
url: /hi/androidjava/save-presentation/
keywords:
- PowerPoint सहेजें
- OpenDocument सहेजें
- प्रेजेंटेशन सहेजें
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा में प्रेजेंटेशन कैसे सहेजें, खोजें—लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बरकरार रखते हुए PowerPoint या OpenDocument में निर्यात करें."
---
## **अवलोकन**

[Open Presentations on Android](/slides/hi/androidjava/open-presentation/) ने बताया कि कैसे [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास को उपयोग करके प्रेजेंटेशन खोला जाता है। यह लेख बताता है कि प्रेजेंटेशन कैसे बनाएँ और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास में प्रेजेंटेशन की सामग्री होती है। चाहे आप एक नई प्रेजेंटेशन बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर इसे सहेजना चाहेंगे। Aspose.Slides for Android के साथ, आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख प्रेजेंटेशन को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रेजेंटेशन सहेजें**

Presentation क्लास की `save` मेथड को कॉल करके प्रेजेंटेशन को फ़ाइल में सहेजें। फ़ाइल का नाम और सहेजने का फॉर्मेट मेथड को पास करें। नीचे दिया गया उदाहरण दिखाता है कि Aspose.Slides के साथ प्रेजेंटेशन को कैसे सहेजा जाता है।

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // यहाँ कुछ कार्य करें...

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रीम में प्रेजेंटेशन सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की `save` मेथड में पास करके प्रेजेंटेशन को स्ट्रीम में सहेज सकते हैं। प्रेजेंटेशन को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे के उदाहरण में, हम एक नया प्रेजेंटेशन बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं।
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

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रेजेंटेशन सहेजें**

Aspose.Slides आपको उत्पन्न प्रेजेंटेशन के खुले समय PowerPoint द्वारा उपयोग किए जाने वाले प्रारंभिक व्यू को [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/) क्लास के माध्यम से सेट करने देता है। [setLastView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) मेथड को [ViewType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewtype/) एनीमरेशन के मान के साथ उपयोग करें।

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

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रेजेंटेशन सहेजें**

Aspose.Slides आपको प्रेजेंटेशन को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजने देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/) क्लास का उपयोग कर उसकी conformance प्रॉपर्टी सेट करें। यदि आप [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजी जाएगी।

नीचे दिया गया उदाहरण एक प्रेजेंटेशन बनाता है और उसे स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजता है।

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का एक उदाहरण बनाएं।
Presentation presentation = new Presentation();
try {
    // प्रस्तुति को स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में सहेजें।
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ZIP64 मोड में ऑफिस ओपन XML फ़ॉर्मेट में प्रेजेंटेशन सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव है जो अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और संपूर्ण आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा लगाती है, और साथ ही आर्काइव में 65 535 (2^16‑1) फ़ाइलों की सीमा भी लगाती है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

[IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) मेथड आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करने हैं, यह चुनने देता है।

यह मेथड निम्न मोड के साथ उपयोग किया जा सकता है:

- [IfNecessary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) जब केवल प्रेजेंटेशन ऊपर बताई गई सीमाओं से अधिक हो तो ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करता।
- [Always](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निचे का कोड दिखाता है कि ZIP64 फ़ॉर्मेट एक्सटेंशन सक्षम करके PPTX फ़ाइल के रूप में प्रेजेंटेशन को कैसे सहेजा जाए:

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
जब आप [Zip64Mode.Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) के साथ सहेजते हैं, तो यदि प्रेजेंटेशन को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता तो एक [PptxException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxexception/) फेंका जाता है।
{{% /alert %}}

## **कम्प्रेशन लेवल के साथ ऑफिस ओपन XML फ़ॉर्मेट में प्रेजेंटेशन सहेजें**

जब आप बड़े प्रेजेंटेशन के साथ काम कर रहे हों, तो आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाते हुए कम्प्रेशन लेवल को समायोजित कर सकते हैं। Aspose.Slides [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) मेथड प्रदान करता है, जो Office Open XML फ़ॉर्मेट में प्रेजेंटेशन सहेजते समय उपयोग किए जाने वाले कम्प्रेशन लेवल को निर्दिष्ट करने देता है।

उपलब्ध कम्प्रेशन लेवल निम्नलिखित हैं:

- [**None**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#None): कोई कम्प्रेशन लागू नहीं किया जाता। फ़ाइलें जैसे की हैं वैसी ही संग्रहीत होती हैं।
- [**Level1**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level1): सबसे तेज़ कम्प्रेशन, सबसे कम कम्प्रेशन अनुपात के साथ।
- [**Level2**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level2): **Level1** से थोड़ा बेहतर कम्प्रेशन अनुपात के साथ तेज़ कम्प्रेशन।
- [**Level3**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level3): **Level2** से बेहतर कम्प्रेशन, मध्यम प्रोसेसिंग समय प्रभाव के साथ।
- [**Level4**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level4): **Level3** से बेहतर कम्प्रेशन।
- [**Level5**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level5): **Level4** से बेहतर कम्प्रेशन, अतिरिक्त प्रोसेसिंग समय के साथ।
- [**Level6**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level6): मानक कम्प्रेशन जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट कम्प्रेशन लेवल* है।
- [**Level7**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level7): **Level6** से बेहतर कम्प्रेशन, धीमी प्रोसेसिंग के साथ।
- [**Level8**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level8): **Level7** से बेहतर कम्प्रेशन।
- [**Level9**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level9): अधिकतम कम्प्रेशन। सबसे लंबी प्रोसेसिंग समय के बदले सबसे छोटा फ़ाइल आकार उत्पन्न करता है।

निचे दिया गया उदाहरण दिखाता है कि *बिना कम्प्रेशन* PPTX फ़ाइल के रूप में प्रेजेंटेशन को कैसे सहेजा जाए:

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

यह उदाहरण दिखाता है कि *अधिकतम कम्प्रेशन* के साथ PPTX फ़ाइल के रूप में प्रेजेंटेशन को कैसे सहेजा जाए:

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

## **थंबनेल रिफ्रेश किए बिना प्रेजेंटेशन सहेजें**

[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड PPTX में प्रेजेंटेशन सहेजते समय थंबनेल जेनरेशन को नियंत्रित करता है:

- यदि `true` सेट किया जाए, तो सहेजने के दौरान थंबनेल रिफ्रेश होता है। यह डिफ़ॉल्ट है।
- यदि `false` सेट किया जाए, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रेजेंटेशन में थंबनेल नहीं है, तो कोई थंबनेल नहीं बनाया जाता।

निचे के कोड में, प्रेजेंटेशन को थंबनेल रिफ्रेश किए बिना PPTX में सहेजा गया है।

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
यह विकल्प PPTX फ़ॉर्मेट में प्रेजेंटेशन सहेजने में लगने वाले समय को कम करने में मदद करता है।
{{% /alert %}}

## **प्रोग्रेस अपडेट प्रतिशत में सहेजें**

[IProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को [ISaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isaveoptions/) इंटरफ़ेस द्वारा एक्सपोज़्ड `setProgressCallback` मेथड और एब्स्ट्रैक्ट [SaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveoptions/) क्लास के माध्यम से उपयोग किया जाता है। `setProgressCallback` के साथ एक [IProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/) इम्प्लीमेंटेशन असाइन करें ताकि सहेजने के प्रोग्रेस अपडेट प्रतिशत में प्राप्त हो सकें।

निचे के कोड स्निपेट्स दिखाते हैं कि `IProgressCallback` का उपयोग कैसे किया जाता है।

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // यहाँ प्रगति प्रतिशत मान का उपयोग करें।
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose ने अपने API का उपयोग करके एक [free PowerPoint Splitter app](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइड्स को नए PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रेजेंटेशन को कई फ़ाइलों में विभाजित करने की अनुमति देता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है जिससे केवल परिवर्तन ही लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूरी लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को बहु-थ्रेड्स से सहेजना थ्रेड-सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस [थ्रेड-सेफ़ नहीं है](/slides/hi/androidjava/multithreading/); इसे एक ही थ्रेड से सहेजें।

**सेविंग के दौरान हाइपरलिंक्स और बाहरी लिंक वाली फ़ाइलों के साथ क्या होता है?**

[Hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) बरकरार रहते हैं। बाहरी लिंक वाली फ़ाइलें (जैसे रिलेटिव पाथ वाले वीडियो) स्वचालित रूप से कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पाथ्स उपलब्ध रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, दिनांक) सेट/सेव कर सकता हूँ?**

हाँ। मानक [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/androidjava/presentation-properties/) समर्थित हैं और सहेजने पर फ़ाइल में लिख दी जाती हैं।