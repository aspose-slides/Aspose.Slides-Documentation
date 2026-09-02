---
title: Java में PowerPoint प्रस्तुतियों को Markdown में बदलें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint रूपांतरित करें
- प्रेजेंटेशन रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से MD
- प्रेजेंटेशन से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रेजेंटेशन को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रेजेंटेशन
- Markdown
- Java
- Aspose.Slides
description: "Java में PPT और PPTX प्रस्तुतियों को Markdown में बदलें और नियंत्रित करें कि निर्यातित बिटमैप, मेटाफाइल, और SVG छवियां कहाँ सहेजी और संदर्भित की जाती हैं।"
---
## **अवलोकन**

Aspose.Slides for Java PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थैतिक‑साइट, सामग्री‑स्थानांतरण, और संस्करण‑नियंत्रण कार्यप्रवाहों के लिए Markdown में परिवर्तित कर सकता है। आप एक Markdown फ़्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडरिंग को नियंत्रित कर सकते हैं, और तय कर सकते हैं कि निर्यातित छवियाँ कहाँ संग्रहीत होंगी और उत्पन्न Markdown उनमें कैसे संदर्भित करता है।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल‑पाठ आउटपुट उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, निर्यात प्रकार को [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) मेथड से `Sequential` या `Visual` मान पर सेट करें, जो [MarkdownExportType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownexporttype/) enumeration में उपलब्ध हैं। `Sequential` स्लाइड आइटम्स को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित आइटम्स को साथ रखता है ताकि उनका दृश्य संबंध बना रहे। `TextOnly` मान छवि संसाधनों को उत्पन्न नहीं करता, इसलिए उस मोड में इमेज‑सेविंग कॉलबैक नहीं बुलाए जाते।

## **एक प्रस्तुति को Markdown में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास से लोड करें, और फिर `Md` मान के साथ [Presentation.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) मेथड को कॉल करें, जो [SaveFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/saveformat/) enumeration से मिलता है।

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

## **एक Markdown फ़्लेवर चुनें**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) मेथड आउटपुट के लिए उपयोग की जाने वाली Markdown विशेषता को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/flavor/) enumeration में CommonMark, GitHub Flavored Markdown, और अन्य समर्थित विकल्प शामिल हैं।

निम्न उदाहरण CommonMark के रूप में प्रस्तुति निर्यात करता है:

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

## **डिफ़ॉल्ट स्थानीय‑सहेजने वाले व्यवहार का उपयोग करके छवियाँ निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करने के दो मेथड प्रदान करता है:

- [setBasePath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) Markdown दस्तावेज़ और उसके संसाधनों के लिए आधार निर्देशिका निर्दिष्ट करता है।
- [setImagesSaveFolderName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) छवि उपनिर्देशिका निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में सापेक्ष छवि रेफ़रेंस बनाता है:

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

यह व्यवहार तब भी फॉलबैक के रूप में काम करता है जब एक कस्टम इमेज‑सेविंग हैंडलर `false` लौटाता है।

## **छवि सहेजने और Markdown लिंक्स को अनुकूलित करें**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) मेथड का उपयोग करके आप उन गैर‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए कॉलबैक पंजीकृत कर सकते हैं जो Markdown निर्यात के दौरान उत्पन्न होते हैं। इसका `MarkdownImageSavingHandler` कॉलबैक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) मान, और उत्पन्न Markdown लिंक को एक‑तत्वीय `String[]` पैरामीटर के रूप में प्राप्त करता है। प्रदान किए गए फ़ॉर्मेट से छवि सहेजें या अपलोड करें, और `link[0]` को उस रेफ़रेंस से बदलें जिसे Markdown आउटपुट में दिखाया जाना चाहिए।

SVG फ़ॉर्मेट में उत्पन्न संसाधनों को अलग से संभाला जाता है। [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) मेथड के साथ एक कॉलबैक पंजीकृत करें। इसका `MarkdownSvgImageSavingHandler` कॉलबैक एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट और एक‑तत्वीय `String[] link` पैरामीटर प्राप्त करता है। SVG में कोई `ImageFormat` तर्क नहीं होता; इसके बजाय [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) मेथड से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और दृश्य समूहबद्धता के आधार पर, स्रोत प्रस्तुति में SVG को रास्टर किया जा सकता है या अन्य सामग्री के साथ मिलाया जा सकता है; परिणामी गैर‑SVG संसाधन तब इमेज‑सेविंग कॉलबैक को पास किया जाता है। जब प्रत्येक निर्यातित दृश्य संसाधन को कस्टम प्रोसेसिंग की आवश्यकता हो, तो दोनों कॉलबैक पंजीकृत करें।

हैंडलर के लौटने वाले मान से यह तय होता है कि छवि कौन प्रोसेस करता है:

- `true` लौटाएँ जब हैंडलर ने छवि को सहेजा, अपलोड किया, परिवर्तित किया, या किसी अन्य तरीके से प्रोसेस किया हो तथा `link[0]` को वैध मान सौंपा हो। Aspose.Slides उस मान को Markdown दस्तावेज़ में लिखता है और अपनी डिफ़ॉल्ट स्थानीय सहेजने की प्रक्रिया नहीं चलाता।
- `false` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेज सके और लिंक को उन मानों के अनुसार जनरेट करे जो [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) द्वारा सेट किए गये हैं।

{{% alert color="warning" title="Important" %}}
एक हैंडलर जो `true` लौटाता है, छवि के लिए जिम्मेदारी लेता है। यदि वह `true` लौटाता है लेकिन वैध, गैर‑खाली लिंक नहीं सौंपता, तो निर्यात `InvalidOperationException` के साथ विफल हो जाता है।
{{% /alert %}}

### **एक CDN मूल निर्देशिका में छवियों को सहेजें और बाहरी URLs का उपयोग करें**

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को एक माउंटेड या समन्वित CDN मूल निर्देशिका के रूप में मानता है। प्रत्येक हैंडलर उत्पन्न फ़ाइल नाम को निकालता है, छवि को उस कस्टम निर्देशिका में सहेजता है, और उत्पन्न स्थानीय रेफ़रेंस को सार्वजनिक CDN URL से बदल देता है। स्वयं नमूना कोई नेटवर्क अपलोड नहीं करता: URL केवल तब मान्य होता है जब निर्देशिका को CDN मूल के रूप में माउंट किया गया हो या उसकी फ़ाइलें CDN पर प्रकाशित हों। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम लिखने को स्टोरेज SDK के अपलोड ऑपरेशन से बदलें और अपलोड सफल होने के बाद ही `link[0]` सेट करें।

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

बिटमैप हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटी छवियों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को डिफ़ॉल्ट व्यवहार का उपयोग करके `output/fallback-images` में सहेजता है। बड़े बिटमैप और मेटाफाइल संसाधन, साथ ही SVG संसाधन, कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, उत्पन्न स्थानीय रेफ़रेंस `fallback-images/image1.png` `https://cdn.example.com/presentations/quarterly-report/image1.png` बन जाता है। हैंडलर केवल फ़ाइल‑सिस्टम पाथ लिखते समय ऑपरेटिंग‑सिस्टम पाथ का उपयोग करते हैं; Markdown में लिखे गए लिंक फ़ॉरवर्ड स्लैश और URL‑एस्केप्ड फ़ाइल नामों के साथ होते हैं। सापेक्ष लिंक बनाते समय भी वही नियम लागू करें: `/` उपयोग करें, न कि प्लेटफ़ॉर्म‑विशिष्ट डायरेक्ट्री सेपरेटर।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई हैंडलर रास्टर छवियों और SVG छवियों दोनों को प्रोसेस कर सकता है?**

नहीं। निर्यात के दौरान उत्पन्न बिटमैप और मेटाफाइल संसाधनों के लिए [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) का उपयोग करें और SVG के रूप में उत्पन्न संसाधनों के लिए [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) का उपयोग करें। पहला कॉलबैक एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) मान प्रदान करता है; दूसरा एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट प्रदान करता है जिसका SVG डेटा आप [ISvgImage.getSvgData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) से पढ़ सकते हैं। निर्यात के दौरान रास्टर किया गया स्रोत SVG इमेज‑सेविंग कॉलबैक द्वारा प्रोसेस किया जाता है।

**जब इमेज‑सेविंग हैंडलर `false` लौटाता है तो क्या होता है?**

Aspose.Slides अपनी डिफ़ॉल्ट स्थानीय‑सहेजने वाली व्यवहार का उपयोग करता है। छवि स्थान और उत्पन्न रेफ़रेंस उन मानों द्वारा नियंत्रित होते हैं जो [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) और [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/markdownsaveoptions/) के साथ सेट किए गये हैं।

**क्या हैंडलर बिना स्थानीय रूप से छवि सहेजे URL प्रदान कर सकता है?**

हाँ। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को पास कर सकता है, उत्पन्न URL को `link[0]` में असाइन कर सकता है, और `true` लौटा सकता है। हैंडलर को स्वयं पूरी प्रोसेसिंग पूरी करनी होगी; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रुक जाता है।

**Markdown निर्यात के दौरान हैंडलर से `InvalidOperationException` क्यों फेंका जाता है?**

यह तब होता है जब हैंडलर `true` लौटाता है लेकिन वैध लिंक नहीं देता। `true` लौटाने से पहले उस सापेक्ष पाथ या बाहरी URL को असाइन करें जिसे Markdown में लिखा जाना चाहिए।

**छवि लिंक में कौन से पाथ सेपरेटर का उपयोग होना चाहिए?**

Markdown लिंक और URL में फ़ॉरवर्ड स्लैश (`/`) का उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `Path.resolve` का उपयोग करें, फिर Markdown रेफ़रेंस को अलग से बनायें या सामान्यीकृत करें।

**क्या Hyperlinks Markdown निर्यात के दौरान संरक्षित रहते हैं?**

हाँ। टेक्स्ट [हाइपरलिंक्स](/slides/hi/java/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [ट्रांज़िशन](/slides/hi/java/slide-transition/) और [ऐनिमेशन](/slides/hi/java/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रस्तुतियों को समानांतर रूप से Markdown में परिवर्तित किया जा सकता है?**

आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। [multithreading guidelines](/slides/hi/java/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए अलग इंस्टेंस उपयोग करें।