---
title: Android पर प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/androidjava/save-presentation/
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
- पूर्वपरिभाषित व्यू प्रकार
- स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश
- सहेजने की प्रगति
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट तथा प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **अवलोकन**

प्रस्तुति बनाने के बाद या [एक मौजूदा खोलें](/slides/hi/androidjava/open-presentation/), परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करें। Aspose.Slides for Android via Java एक प्रस्तुति को फ़ाइल या स्ट्रीम में PowerPoint, OpenDocument, PDF, और अन्य फ़ॉर्मेट में सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने के ऑपरेशन और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुति सहेजें**

एक प्रस्तुति को फ़ाइल में सहेजने के लिए, आउटपुट पथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides कौन सी फ़ाइल प्रकार बनाता है।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    // यहाँ प्रस्तुति सामग्री जोड़ें या संशोधित करें।

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **प्रस्तुति को उनके मूल फ़ॉर्मेट में सहेजें**

फ़ाइल और स्ट्रीम डिटेक्शन उदाहरणों, नई बनाई गई प्रस्तुतियों के व्यवहार, और स्रोत व आउटपुट फ़ॉर्मेट के अंतर के लिए, देखें [मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें](/slides/hi/androidjava/detect-presentation-source-format/)।

बैच‑प्रोसेसिंग एप्लिकेशन में, इनपुट फ़ॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल को लोड करने के बाद, उसके मूल फ़ॉर्मेट को [IPresentation.getSourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--) मेथड से पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sourceformat/) मान को [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) में पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) मान प्राप्त करें, और फिर [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) का उपयोग करके संशोधित प्रस्तुति लिखें।

निम्नलिखित पूर्ण उदाहरण प्रत्येक फ़ाइल को इनपुट डायरेक्ट्री में प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और इसे उसी फ़ॉर्मेट में आउटपुट डायरेक्ट्री में सहेजता है जिसमें इसे लोड किया गया था:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideutil/#toSaveFormat-int-) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP, और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने के फ़ॉर्मेट में मैप करता है। यह केवल प्रस्तुति स्रोत फ़ॉर्मेट को मैप करता है; इसका उद्देश्य PDF, HTML, TIFF, या इमेज जैसी एक्सपोर्ट फ़ॉर्मेट चुनना नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/sourceformat/) मान पास करने पर [IllegalArgumentException](https://developer.android.com/reference/java/lang/IllegalArgumentException) उत्पन्न होता है।

पुराने PPT, PPS, और POT फ़ाइलें समान बायनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को बिना फ़ाइल एक्सटेंशन के स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन लेगेसी उपप्रकारों को संरक्षित करना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मेट मेटाडाटा को अलग से रखकर आउटपुट फ़ाइलनाम और फ़ॉर्मेट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रस्तुति सहेजें**

अंतिम फ़ाइल पथ पर निर्भर किए बिना प्रस्तुति लिखने के लिए, एक लिखने योग्य स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) मेथड में पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सर्विस से लौटाना हो, डेटाबेस में संग्रहीत करना हो, या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण नई प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

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

## **पूर्वपरिभाषित व्यू टाइप के साथ प्रस्तुति सहेजें**

आप सहेजी गई प्रस्तुति को प्रारंभिक रूप से जिस व्यू में PowerPoint खोलता है, उसे निर्दिष्ट कर सकते हैं। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewtype/) मान के साथ [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) मेथड का उपयोग करें।

निम्नलिखित उदाहरण स्लाइड मास्टर व्यू को प्रारंभिक व्यू के रूप में कॉन्फ़िगर करता है:

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

## **स्ट्रिक्ट ऑफिस ओपन XML फ़ॉर्मेट में प्रस्तुति सहेजें**

स्ट्रिक्ट प्रोफ़ाइल ऑफ़िस ओपन XML के अनुरूप PPTX फ़ाइल बनाने के लिए, एक [PptxOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/) इंस्टेंस बनाएं और उसके [setConformance](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setConformance-int-) मेथड को [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict) मान के साथ कॉल करें। फिर विकल्पों को [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड में पास करें।

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

## **Office Open XML फ़ॉर्मेट में Zip64 मोड के साथ प्रस्तुति सहेजें**

एक मानक ZIP संग्रह प्रत्येक प्रविष्टि के संकुचित और अनसंकुचित आकार, कुल संग्रह आकार, और प्रविष्टियों की संख्या को सीमित करता है। क्योंकि PPTX फ़ाइल एक ZIP संग्रह होती है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन लागू आकार और प्रविष्टि‑संख्या सीमाओं को बढ़ाते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setZip64Mode-int-) मेथड का उपयोग करके नियंत्रित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- [IfNecessary](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) जब प्रस्तुति मानक ZIP सीमाओं से अधिक हो तो ही ZIP64 का उपयोग करता है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को अक्षम करता है।
- [Always](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

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
यदि [Zip64Mode.Never](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/zip64mode/#Never) का उपयोग किया जाता है और प्रस्तुति मानक ZIP सीमाओं में फिट नहीं होती, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxexception/) फेंकता है।
{{% /alert %}}

## **Office Open XML फ़ॉर्मेट में संपीड़न स्तरों के साथ प्रस्तुति सहेजें**

PPTX आउटपुट के लिए, आप [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setCompressionLevel-int-) मेथड का उपयोग करके सहेजने की गति और फ़ाइल आकार में संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/) क्लास निम्नलिखित मान प्रदान करती है:

- [None](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#None) डेटा को बिना संपीड़न के संग्रहित करता है।
- [Level1](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level1) सबसे तेज़ संपीड़न और सबसे बड़ा संकुचित आउटपुट प्रदान करता है।
- [Level2](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level5) तक क्रमिक रूप से सहेजने की गति की तुलना में छोटे आउटपुट को प्राथमिकता देते हैं।
- [Level6](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level6) सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट स्तर है।
- [Level7](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level8) सहेजने की गति की तुलना में छोटे आउटपुट को और अधिक प्राथमिकता देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compressionlevel/#Level9) सबसे मजबूत संपीड़न प्रदान करता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्नलिखित उदाहरण बिना संपीड़न के प्रस्तुति को सहेजता है:

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

निम्नलिखित उदाहरण अधिकतम संपीड़न स्तर का उपयोग करता है:

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

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुति सहेजें**

PPTX के रूप में सहेजी गई प्रस्तुति में, [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) मेथड दस्तावेज़ थंबनेल को नियंत्रित करता है:

- `true` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `false` मौजूदा थंबनेल को बना रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides नया नहीं बनाता।

निम्नलिखित उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रस्तुति को सहेजता है:

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
थंबनेल रीफ़्रेश को अक्षम करने से PPTX फ़ाइल को सहेजने में लगने वाला समय कम हो सकता है।
{{% /alert %}}

## **सहेजने की प्रगति प्रतिशत में अपडेट करें**

सहेजने के ऑपरेशन की निगरानी के लिए, [IProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/) इंटरफ़ेस को लागू करें और इसे [ISaveOptions.setProgressCallback](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isaveoptions/#setProgressCallback-com.aspose.slides.IProgressCallback-) मेथड को पास करें। Aspose.Slides तब निर्यात के दौरान प्रगति मानों के साथ [IProgressCallback.reporting](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iprogresscallback/#reporting-double-) मेथड को कॉल करता है।

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
अस्पोज़ एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है, जो Aspose.Slides API से निर्मित है। यह प्रस्तुति से चयनित स्लाइड्स को अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इंक्रीमेंटल या “फ़ास्ट सहेज” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन केवल बदले हुए भागों को अपडेट करने के बजाय पूरी आउटपुट फ़ाइल लिखता है।

**क्या कई थ्रेड्स एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/androidjava/multithreading/)। प्रत्येक इंस्टेंस को केवल एक थ्रेड से ही ऐक्सेस और सहेजें।

**जब मैं प्रस्तुति को सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक वाली फ़ाइलों के साथ क्या होता है?**

[Hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) प्रस्तुति में बने रहते हैं। Aspose.Slides बाहरी लिंक वाली फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजी गई प्रस्तुति को फिर भी उनके स्थानों तक पहुँच सकना चाहिए।

**क्या मैं दस्तावेज़ मेटाडेटा जैसे लेखक, शीर्षक, कंपनी और निर्माण तिथि को सहेज सकता हूँ?**

हाँ। सहेजने से पहले उचित [document properties](/slides/hi/androidjava/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिखता है।