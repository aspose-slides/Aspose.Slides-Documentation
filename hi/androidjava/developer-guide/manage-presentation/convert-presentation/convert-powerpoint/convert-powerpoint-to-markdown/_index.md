---
title: एंड्रॉइड पर PowerPoint प्रस्तुतियों को मार्कडाउन में बदलें
linktitle: PowerPoint से मार्कडाउन
type: docs
weight: 140
url: /hi/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से MD
- प्रेजेंटेशन से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को मार्कडाउन के रूप में सहेजें
- प्रेजेंटेशन को मार्कडाउन के रूप में सहेजें
- स्लाइड को मार्कडाउन के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- मार्कडाउन छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रेजेंटेशन
- मार्कडाउन
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Java के माध्यम से Android पर PPT और PPTX प्रस्तुतियों को मार्कडाउन में बदलें और नियंत्रित करें कि निर्यातित bitmap, metafile और SVG छवियाँ कहाँ सहेजे और संदर्भित किए जाते हैं।"
---
## **सारांश**

Aspose.Slides for Android via Java PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थैतिक साइट, सामग्री-स्थानांतरण, और संस्करण-नियंत्रण कार्यप्रवाहों के लिए Markdown में बदल सकता है। आप Markdown फ़्लेवर चुन सकते हैं, स्लाइड सामग्री कैसे रेंडर होती है इसे नियंत्रित कर सकते हैं, और निर्यातित छवियों को कहां सहेजा जाए तथा उत्पन्न Markdown उनसे कैसे संदर्भित करता है, यह तय कर सकते हैं।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल‑पाठ आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, निर्यात प्रकार को [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) मेथड के साथ `Sequential` या `Visual` मान पर सेट करें, जो [MarkdownExportType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownexporttype/) एन्यूमरेशन से हैं। `Sequential` स्लाइड आइटम्स को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` ग्रुपेड आइटम्स को साथ रखता है ताकि उनका visual संबंध बना रहे। `TextOnly` मान छवि संसाधनों को नहीं उत्पन्न करता, इसलिए इस मोड में image‑saving कॉलबैक नहीं चलाए जाते।

## **प्रेजेंटेशन को Markdown में बदलना**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) मेथड को कॉल करें, जिसमें [SaveFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/saveformat/) एन्यूमरेशन से `Md` मान पास किया जाए।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown फ़्लेवर चुनें**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) मेथड आउटपुट के लिए उपयोग किए जाने वाले Markdown विनिर्देश को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/flavor/) एन्यूमरेशन में CommonMark, GitHub Flavored Markdown और अन्य समर्थित वेरिएंट्स शामिल हैं।

निम्न उदाहरण एक प्रेजेंटेशन को CommonMark के रूप में निर्यात करता है:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने के व्यवहार के साथ छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करने के लिए दो मेथड प्रदान करती है:

- [setBasePath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) Markdown दस्तावेज़ और उसकी संसाधनों के लिए बेस डायरेक्टरी निर्दिष्ट करता है।
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) छवि उप‑डायरेक्टरी निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में सापेक्ष चित्र संदर्भ बनाता है:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

जब कोई कस्टम image‑saving हैंडलर `false` लौटाता है, तब यह व्यवहार फॉलबैक के रूप में उपयोग होता है।

## **छवि सहेजना और Markdown लिंक को कस्टमाइज़ करें**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) मेथड का उपयोग करके Markdown निर्यात के दौरान उत्पन्न गैर‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए एक कॉलबैक रजिस्टर करें। इसका `MarkdownImageSavingHandler` कॉलबैक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) मान, तथा उत्पन्न Markdown लिंक को एक‑तत्वीय `String[]` पैरामीटर के रूप में प्राप्त करता है। प्रदान किए गए फॉर्मेट से छवि सहेजें या अपलोड करें, और `link[0]` को उस संदर्भ से बदलें जो Markdown आउटपुट में दिखना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न संसाधनों को अलग से संभाला जाता है। [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) मेथड के साथ एक कॉलबैक रजिस्टर करें। इसका `MarkdownSvgImageSavingHandler` कॉलबैक एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट और एक‑तत्वीय `String[] link` पैरामीटर प्राप्त करता है। SVG में `ImageFormat` आर्ग्यूमेंट नहीं होता; इसके बजाय [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) मेथड से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और visual ग्रुपिंग के आधार पर, स्रोत प्रेजेंटेशन में SVG को rasterized किया जा सकता है या अन्य सामग्री के साथ संयोजित किया जा सकता है; resulting non‑SVG संसाधन तब image‑saving कॉलबैक को पास किया जाता है। जब प्रत्येक निर्यातित visual संसाधन को कस्टम प्रोसेसिंग चाहिए, तो दोनों कॉलबैक रजिस्टर करें।

हैंडलर रिटर्न वैल्यू निर्धारित करता है कि छवि को कौन प्रोसेस करता है:

- `true` लौटाएँ जब हैंडलर ने छवि को सहेज लिया, अपलोड किया, रूपांतरित किया, या अन्यथा प्रोसेस किया हो और `link[0]` को एक वैध मान सौंप दिया हो। Aspose.Slides उस मान को Markdown दस्तावेज़ में लिखता है और अपना डिफ़ॉल्ट स्थानीय सहेजना नहीं करता।
- `false` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेजे और लिंक को [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) द्वारा सेट मानों के अनुसार उत्पन्न करे।

{{% alert color="warning" title="Important" %}}
`true` लौटाने वाला हैंडलर छवि की जिम्मेदारी लेता है। यदि वह वैध, गैर‑खाली लिंक नहीं सौंपता और `true` लौटाता है, तो निर्यात `InvalidOperationException` के साथ विफल हो जाता है।
{{% /alert %}}

### **छवियों को CDN ऑरिजिन डायरेक्टरी में सहेजें और बाहरी URL का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को माउंटेड या सिंक्रनाइज़्ड CDN ऑरिजिन डायरेक्टरी मानता है। प्रत्येक हैंडलर उत्पन्न फ़ाइल नाम को निकालता है, छवि को उस कस्टम डायरेक्टरी में सहेजता है, और उत्पन्न स्थानीय संदर्भ को सार्वजनिक CDN URL से बदल देता है। यह उदाहरण स्वयं कोई नेटवर्क अपलोड नहीं करता: URL केवल तब वैध रहता है जब डायरेक्टरी को CDN ऑरिजिन के रूप में माउंट किया गया हो या उसकी फाइलें CDN पर प्रकाशित हो गई हों। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम लिखना को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और केवल अपलोड सफल होने के बाद `link[0]` असाइन करें।

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

`Bitmap` हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटी छवियों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को डिफ़ॉल्ट व्यवहार से `output/fallback-images` में सहेजता है। बड़े bitmap और metafile संसाधन, तथा SVG संसाधन, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, उत्पन्न स्थानीय संदर्भ जैसे `fallback-images/image1.png` बदलकर `https://cdn.example.com/presentations/quarterly-report/image1.png` हो जाता है। हैंडलर फ़ाइलें लिखते समय केवल ऑपरेटिंग‑सिस्टम पाथ का उपयोग करते हैं; Markdown में लिखे लिंक फ़ॉरवर्ड स्लैश और URL‑एस्केप्ड फ़ाइल नामों का उपयोग करते हैं। सापेक्ष लिंक बनाते समय भी यही नियम अपनाएँ: `/` उपयोग करें, प्लेटफ़ॉर्म‑विशिष्ट डायरेक्टरी सेपरेटर नहीं।

## **FAQ**

**क्या कोई एक हैंडलर रास्टर छवियों और SVG छवियों दोनों को प्रोसेस कर सकता है?**

नहीं। निर्यात के दौरान उत्पन्न bitmap और metafile संसाधनों के लिए [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) का उपयोग करें और SVG के रूप में उत्पन्न संसाधनों के लिए [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) का उपयोग करें। पहला [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट और [ImageFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) मान प्रदान करता है; दूसरा [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट प्रदान करता है, जिसका SVG डेटा [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) से पढ़ा जा सकता है। स्रोत SVG जो निर्यात के दौरान rasterized हो जाता है, वह image‑saving कॉलबैक द्वारा प्रोसेस किया जाता है।

**जब image‑saving हैंडलर `false` लौटाता है तो क्या होता है?**

Aspose.Slides अपना डिफ़ॉल्ट स्थानीय‑सहेजने वाला व्यवहार उपयोग करता है। छवि का स्थान और उत्पन्न संदर्भ उन मानों द्वारा नियंत्रित होते हैं जो [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/markdownsaveoptions/) से सेट किए गए हैं।

**क्या कोई हैंडलर छवि को स्थानीय रूप से सहेजे बिना URL प्रदान कर सकता है?**

हां। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को पास कर सकता है, प्राप्त URL को `link[0]` में असाइन कर सकता है, और `true` लौट सकता है। हैंडलर को स्वयं प्रोसेसिंग पूरी करनी होगी; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना प्रतिबंधित हो जाता है।

**क्यों Markdown निर्यात हैंडलर से `InvalidOperationException` फेंकता है?**

यह अपवाद तब उत्पन्न होता है जब हैंडलर `true` लौटाता है लेकिन वैध लिंक प्रदान नहीं करता। `true` लौटाने से पहले वह सापेक्ष पाथ या बाहरी URL को असाइन करें जो Markdown में लिखा जाना चाहिए।

**छवि लिंक के लिए कौन सा पाथ सेपरेटर उपयोग करना चाहिए?**

Markdown लिंक और URL में फ़ॉरवर्ड स्लैश (`/`) का उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `Path.resolve` प्रयोग करें, फिर Markdown संदर्भ को अलग से बनाएँ या सामान्यीकृत करें।

**क्या Markdown निर्यात के दौरान हाइपरलिंक संरक्षित रहते हैं?**

हां। टेक्स्ट [hyperlinks](/slides/hi/androidjava/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/androidjava/slide-transition/) और [animations](/slides/hi/androidjava/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रेजेंटेशन को समानांतर रूप से Markdown में बदला जा सकता है?**

आप विभिन्न प्रेजेंटेशन फाइलों को समानांतर रूप से प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा नहीं करें। [multithreading guidelines](/slides/hi/androidjava/multithreading/) का पालन करें और प्रत्येक फाइल के लिए अलग इंस्टेंस उपयोग करें।