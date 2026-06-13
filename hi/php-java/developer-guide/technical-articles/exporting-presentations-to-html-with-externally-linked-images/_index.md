---
title: बाहरी रूप से लिंक किए गए इमेज के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रस्तुति निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint से HTML
- OpenDocument से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- लिंक्ड इमेज
- बाहरी रूप से लिंक्ड इमेज
- लिंक्ड रिसोर्स
- बाहरी रिसोर्स
- PHP
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों को PHP में Java के माध्यम से Aspose.Slides का उपयोग करके HTML में निर्यात करें, जहाँ इमेज और अन्य संसाधन बाहरी लिंक्ड फ़ाइलों के रूप में सहेजे जाते हैं।"
---
## **अवलोकन**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्व-समाहित HTML फ़ाइल में निर्यात करता है। इमेज और अन्य संसाधन सीधे HTML में लिखे जाते हैं, अक्सर Base64 डेटा के रूप में। यह तब सुविधाजनक होता है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेबसाइट, CMS, या सर्वर‑साइड रूपांतरण पाइपलाइन के लिए सर्वोत्तम प्रारूप नहीं होता।

बाहरी रूप से जुड़े संसाधनों का उपयोग तब करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करना;
- ब्राउज़र या CDN में इमेज, फ़ॉन्ट, ऑडियो या वीडियो को अलग‑अलग कैश करना;
- निर्यात के बाद उत्पन्न संसाधनों की जाँच, प्रतिस्थापन, संपीड़न या पोस्ट‑प्रोसेस करना;
- आउटपुट संरचना को उस वेब एप्लिकेशन के करीब रखना जिसे यह अपेक्षित है।

सामान्य HTML रूपांतरण कार्यप्रवाह के लिए देखें [Convert PowerPoint Presentations to HTML](/slides/hi/php-java/convert-powerpoint-to-html/). यह लेख निर्यात के संसाधन‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड रिसोर्स एक्सपोर्ट कैसे काम करता है**

[HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/) Aspose.Slides को HTML में निर्यात करते समय एक कस्टम लिंक/एम्बेड कंट्रोलर का उपयोग करने की अनुमति देता है। PHP via Java में, यह परिदृश्य आमतौर पर एक छोटा Java हेल्पर क्लास के साथ लागू किया जाता है। उस हेल्पर को कॉम्पाइल करें, इसे PHP Java Bridge क्लासपाथ में जोड़ें, और PHP से `new Java(...)` के साथ इंस्टैंसिएट करें।

हेल्पर क्लास प्रत्येक संसाधन के अनुसार तय करता है कि एक्सपो़र्टर डेटा को HTML में एम्बेड करे या बाहरी रूप से सहेज कर लिंक लिखे। इसे तीन कॉलबैक मेथड्स की आवश्यकता होती है:

- `ExternalResourceController.getObjectStoringLocation` तय करता है कि कोई संसाधन लिंक किया जाए या एम्बेड।
- `ExternalResourceController.getUrl` वह URL लौटाता है जो उत्पन्न HTML या किसी अन्य लिंक्ड रिसोर्स में लिखा जाएगा।
- `ExternalResourceController.saveExternal` लिंक्ड रिसोर्स डेटा को डिस्क या अन्य स्टोरेज लक्ष्य पर लिखता है।

फ़ाइल‑सिस्टम पाथ और ब्राउज़र URL अलग‑अलग विचार हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलों को डिस्क पर `html-output/assets` में लिखता है, जबकि HTML में सापेक्ष URL जैसे `assets/resource-1.svg` होते हैं। ब्राउज़र इन URL को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक मौजूद है। इसलिए `presentation.html` से एक SVG फ़ाइल का लिंक `assets/resource-1.svg` होगा, जबकि उसी SVG फ़ाइल से उसी `assets` फ़ोल्डर में सहेजी गई इमेज का लिंक `resource-4.jpg` होगा।

## **Java हेल्पर क्लास बनाएं**

`com.example.slides.ExternalResourceController` जैसी Java क्लास बनाएं, इसे Aspose.Slides for Java के साथ क्लासपाथ में कॉम्पाइल करें, और कॉम्पाइल की गई क्लास या JAR को PHP Java Bridge के लिए उपलब्ध कराएँ।

नीचे दिया गया हेल्पर Aspose.Slides द्वारा प्रदान किए गए या सुरक्षित फ़ाइल एक्सटेंशन का अनुमान लगाने पर सामान्य इमेज, फ़ॉन्ट, ऑडियो, वीडियो और CSS संसाधनों को लिंक करता है। अपरिचित संसाधन एम्बेडेड रहेंगे।

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **लिंक्ड रिसोर्सेज़ के साथ HTML निर्यात करें**

निम्न PHP कोड एक आउटपुट डायरेक्ट्री बनाता है, HTML फ़ाइल को वहाँ सहेजता है, और लिंक्ड संसाधनों को `assets` उप‑डायरेक्ट्री में रखता है। यह निर्यात के लिए [HtmlOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideimageformat/), और [SaveFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/saveformat/) को संयोजित करता है।

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

निर्यात के बाद, आउटपुट फ़ोल्डर की संरचना इस प्रकार होती है:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर इमेज़ अक्सर JPEG या PNG के रूप में निर्यात होते हैं। Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए कोडेक से अलग इमेज कोडेक चुन सकता है यदि वह छोटा या अधिक उपयुक्त फ़ाइल बनाता है। पारदर्शी इमेज़ PNG के रूप में निर्यात होती हैं।

## **डिप्लॉयमेंट के लिए URL चुनना**

नमूना सापेक्ष URL उपसर्ग `assets/` का उपयोग करता है: यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड रिसोर्स दूसरे लिंक्ड रिसोर्स को संदर्भित करता है, तो नमूना `ExternalResourceController.getUrl` में `referrer` पैरामीटर का उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलें कहीं और डिप्लॉय की जाती हैं तो अलग URL उपसर्ग उपयोग करें:

- जब एसेट डायरेक्ट्री HTML फ़ाइल के बगल में हो तो `assets/` उपयोग करें।
- जब एसेट डायरेक्ट्री HTML फ़ाइल से एक स्तर ऊपर हो तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थैतिक फ़ाइल सर्वर पर अपलोड की गई हों तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

`ExternalResourceController.getUrl` द्वारा लौटाया गया URL `ExternalResourceController.saveExternal` द्वारा लिखी गई फ़ाइल के अंतिम डिप्लॉयड स्थान से मेल खाना चाहिए। सर्वर एप्लिकेशनों में, प्रत्येक रूपांतरण कार्य के लिए एक विशिष्ट आउटपुट डायरेक्ट्री या ऑब्जेक्ट‑स्टोरेज उपसर्ग उपयोग करें ताकि एक निर्यात द्वारा दूसरी निर्यात की फ़ाइलें ओवरराइट न हों।

## **कब एम्बेड करना बेहतर है**

जब आउटपुट को एकल फ़ाइल के रूप में होना आवश्यक हो, जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या वह दस्तावेज़ जिसका समर्थन करने वाला एसेट फ़ोल्डर नहीं है, तो एम्बेडेड Base64 HTML अभी भी उपयोगी है। लिंक्ड रिसोर्सेज़ तब अधिक उपयुक्त होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा अनुकूलित किया जाएगा, या ब्राउज़र स्वतंत्र रूप से कैश करेगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल इमेज को बाहरी बनाकर अन्य संसाधनों को एम्बेडेड रख सकता हूँ?**

हाँ। `ExternalResourceController.getObjectStoringLocation` में, केवल उन कंटेंट टाइप्स के लिए [LinkEmbedDecision](https://reference.aspose.com/slides/hi/php-java/aspose.slides/linkembeddecision/) का `Link` मान लौटाएँ जिन्हें आप अलग फ़ाइलों के रूप में सहेजना चाहते हैं, और बाकी सबके लिए `Embed` मान लौटाएँ।

**निर्यात की गई इमेज का एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों होता है?**

HTML निर्यात के दौरान Aspose.Slides आकार या ब्राउज़र संगतता सुधारने के लिए रास्टर इमेज को पुनः‑एन्कोड कर सकता है। उदाहरण के लिए, स्रोत फ़ाइल की इमेज को रेंडरिंग परिणाम के आधार पर JPEG या PNG के रूप में लिखा जा सकता है।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URL काम करेंगे?**

सापेक्ष URL तभी काम करेंगे जब वही सापेक्ष फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में रहना चाहिए, जब तक आप अलग URL उपसर्ग न उत्पन्न करें।

**क्या सर्वर एप्लिकेशन समान आउटपुट फ़ोल्डर का पुनः उपयोग कर सकते हैं?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक विशिष्ट आउटपुट डायरेक्ट्री या स्टोरेज उपसर्ग उपयोग करें। इससे फ़ाइल नाम टक्करों से बचा जा सकता है और एक निर्यात द्वारा दूसरी निर्यात के संसाधनों को ओवरराइट होने से रोका जा सकता है।