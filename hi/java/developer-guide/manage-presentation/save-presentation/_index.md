---
title: Java में प्रस्तुतियों को सहेजें
linktitle: प्रेज़ेंटेशन सहेजें
type: docs
weight: 80
url: /hi/java/save-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट व प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **अवलोकन**

प्रेज़ेंटेशन बनाने के बाद या एक मौजूदा को [एक मौजूदा खोलें](/slides/hi/java/open-presentation/), परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करें। Aspose.Slides for Java प्रेज़ेंटेशन को PowerPoint, OpenDocument, PDF और अन्य स्वरूपों में फ़ाइल या स्ट्रीम में सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने के ऑपरेशनों और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

फ़ाइल में प्रेज़ेंटेशन सहेजने के लिए, आउटपुट पथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाएगा।

निम्नलिखित उदाहरण एक प्रेज़ेंटेशन बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // यहाँ प्रेज़ेंटेशन की सामग्री जोड़ें या संशोधित करें।

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **प्रेज़ेंटेशन को मूल स्वरूप में सहेजें**

फ़ाइल और स्ट्रीम डिटेक्शन उदाहरणों, नए बनाए गए प्रस्तुतियों के व्यवहार, और स्रोत व आउटपुट फ़ॉर्मेट के अंतर के लिए देखें [मूल प्रेज़ेंटेशन फ़ॉर्मेट निर्धारित करें](/slides/hi/java/detect-presentation-source-format/)।

बैच‑प्रोसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसकी मूल फ़ॉर्मेट को [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentation/#getSourceFormat--) मेथड से पढ़ें। प्राप्त हुए [SourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sourceformat/) मान को [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#toSaveFormat-int-) में पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) मान प्राप्त करें, फिर संशोधित प्रेज़ेंटेशन को लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) का उपयोग करें।

निम्नलिखित पूर्ण उदाहरण इनपुट डायरेक्टरी की प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और उसे उसी फ़ॉर्मेट में आउटपुट डायरेक्टरी में सहेजता है जिससे वह लोड हुई थी:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SlideUtil;
import java.io.File;

File inputDirectory = new File("Input");
File outputDirectory = new File("Output");

if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    System.err.println("Cannot create the output directory.");
}

File[] inputFiles = inputDirectory.listFiles(File::isFile);
if (inputFiles != null && outputDirectory.isDirectory()) {
    for (File inputFile : inputFiles) {
        try {
            Presentation presentation = new Presentation(inputFile.getPath());
            try {
                int saveFormat = SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                File outputFile = new File(outputDirectory, inputFile.getName());
                presentation.save(outputFile.getPath(), saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (IllegalArgumentException exception) {
            System.err.println("Cannot map the source format of '" + inputFile.getPath() + "': " + exception.getMessage());
        } catch (Exception exception) {
            System.err.println("Cannot process '" + inputFile.getPath() + "': " + exception.getMessage());
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideutil/#toSaveFormat-int-) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रेज़ेंटेशन सहेजने के फ़ॉर्मेट में मैप करता है। यह केवल प्रेज़ेंटेशन स्रोत फ़ॉर्मेट को मैप करता है; PDF, HTML, TIFF या इमेज जैसे निर्यात फ़ॉर्मेट चुनने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/sourceformat/) मान पास करने पर एक [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) उत्पन्न होता है।

Legacy PPT, PPS और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रेज़ेंटेशन को फ़ाइल एक्सटेंशन के बिना स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन लेगेसी उपप्रकारों को संरक्षित करना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मेट मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम और फ़ॉर्मेट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

फ़ाइनल फ़ाइल पाथ पर निर्भर किए बिना प्रेज़ेंटेशन लिखने के लिए, एक राइटेबल स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) मेथड में पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सेवा से वापस करना हो, डेटाबेस में संग्रहित करना हो, या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण एक नई प्रेज़ेंटेशन को फ़ाइल स्ट्रीम में सहेजता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileOutputStream;
import java.io.OutputStream;

Presentation presentation = new Presentation();
try {
    OutputStream outputStream = new FileOutputStream("Output.pptx");
    try {
        presentation.save(outputStream, SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

आप वह व्यू निर्दिष्ट कर सकते हैं जिसमें PowerPoint संचित प्रेज़ेंटेशन को प्रारम्भिक रूप से खोलता है। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewtype/) मान के साथ [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#setLastView-int-) मेथड का उपयोग करें।

निम्नलिखित उदाहरण स्लाइड मास्टर व्यू को प्रारम्भिक व्यू के रूप में कॉन्फ़िगर करता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक PPTX फ़ाइल बनाने के लिए जो Office Open XML के स्ट्रिक्ट प्रोफ़ाइल के अनुरूप हो, एक [PptxOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/) इंस्टेंस बनाएँ और उसके [setConformance](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setConformance-int-) मेथड को [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict) मान के साथ कॉल करें। फिर इन विकल्पों को [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

```java
import com.aspose.slides.Conformance;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

Presentation presentation = new Presentation();
try {
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **ZIP64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक मानक ZIP आर्काइव प्रत्येक प्रविष्टि, कुल आकार और प्रविष्टियों की संख्या पर सीमा लगाता है। क्योंकि PPTX फ़ाइल एक ZIP आर्काइव है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन सीमाओं को बढ़ाते हैं।

[**PptxOptions.setZip64Mode**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setZip64Mode-int-) मेथड का उपयोग करके नियंत्रित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- [IfNecessary](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#IfNecessary) मानक ZIP सीमा को पार करने पर ही ZIP64 का उपयोग करता है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को निष्क्रिय करता है।
- [Always](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रेज़ेंटेशन के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.Zip64Mode;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setZip64Mode(Zip64Mode.Always);

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
यदि [Zip64Mode.Never](https://reference.aspose.com/slides/hi/java/com.aspose.slides/zip64mode/#Never) उपयोग किया जाता है और प्रेज़ेंटेशन मानक ZIP सीमा में फिट नहीं हो पाता, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **कम्प्रेशन लेवल के साथ Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए, आप [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) मेथड का उपयोग करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/) क्लास निम्नलिखित मान प्रदान करती है:

- [None](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#None) कोई कम्प्रेशन नहीं, डेटा को जैसा है वैसा संग्रहीत करता है।
- [Level1](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level1) सबसे तेज़ कम्प्रेशन और सबसे बड़ा संकुचित आउटपुट प्रदान करता है।
- [Level2](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level5) तक छोटे आउटपुट के पक्ष में गति की कीमत पर क्रमागत रूप से आगे बढ़ते हैं।
- [Level6](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level6) गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट लेवल है।
- [Level7](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level8) छोटे आउटपुट को गति से अधिक महत्व देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compressionlevel/#Level9) सबसे मजबूत कम्प्रेशन प्रदान करता है और सबसे अधिक प्रोसेसिंग टाइम लेता है।

निम्नलिखित उदाहरण बिना किसी कम्प्रेशन के प्रेज़ेंटेशन सहेजता है:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.None);

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

निम्नलिखित उदाहरण अधिकतम कम्प्रेशन लेवल का उपयोग करता है:

```java
import com.aspose.slides.CompressionLevel;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setCompressionLevel(CompressionLevel.Level9);

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

जब प्रेज़ेंटेशन को PPTX के रूप में सहेजा जाता है, तो [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड उसके दस्तावेज़ थंबनेल को नियंत्रित करता है:

- `true` सहेजने के दौरान थंबनेल को पुन: उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनेल को संरक्षित रखता है। यदि प्रेज़ेंटेशन में थंबनेल नहीं है, तो Aspose.Slides नया थंबनेल नहीं बनाता।

निम्नलिखित उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रेज़ेंटेशन सहेजता है:

```java
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("Sample.pptx");
try {
    PptxOptions options = new PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("Output.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
थंबनेल रीफ़्रेश को निष्क्रिय करने से PPTX फ़ाइल को सहेजने में लगने वाला समय घट सकता है।
{{% /alert %}}

## **प्रतिशत में सहेजने की प्रगति अपडेट करें**

सहेजने के ऑपरेशन की निगरानी के लिए, [IProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करें और उसके इम्प्लीमेंटेशन को [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) मेथड में पास करें। Aspose.Slides तब निर्यात के दौरान प्रगति मानों के साथ [IProgressCallback.reporting](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iprogresscallback/#reporting-double-) मेथड को कॉल करता है।

निम्नलिखित उदाहरण PDF निर्यात की प्रगति को कंसोल में रिपोर्ट करता है:

```java
import com.aspose.slides.IProgressCallback;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        int progress = (int) progressValue;
        System.out.println(progress + "% of the file has been converted.");
    }
}

PdfOptions options = new PdfOptions();
options.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API से निर्मित है। यह प्रेज़ेंटेशन से चयनित स्लाइडों को अलग‑अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **प्रश्नोत्तर**

**क्या Aspose.Slides क्रमिक या “तेज़ सहेजना” समर्थन करता है?**  
नहीं। प्रत्येक सहेजने के ऑपरेशन में पूरी आउटपुट फ़ाइल लिखी जाती है, न कि केवल बदले हुए भागों को।

**क्या कई थ्रेड्स एक ही Presentation इंस्टेंस को सहेज सकते हैं?**  
नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस [is not thread-safe](/slides/hi/java/multithreading/). प्रत्येक इंस्टेंस को केवल एक थ्रेड द्वारा ही एक्सेस और सहेजा जाना चाहिए।

**प्रेज़ेंटेशन सहेजते समय हाइपरलिंक्स और बाहरी लिंक्ड फ़ाइलों के साथ क्या होता है?**  
[Hyperlinks](/slides/hi/java/manage-hyperlinks/) प्रेज़ेंटेशन में बनी रहती हैं। Aspose.Slides बाहरी लिंक्ड फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजे गए प्रेज़ेंटेशन को उनके स्थानों तक पहुंच बनाए रखनी होगी।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसी दस्तावेज़ मेटाडेटा सहेज सकता हूँ?**  
हां। सहेजने से पहले उपयुक्त [document properties](/slides/hi/java/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिख देगा।