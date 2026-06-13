---
title: बाहरी रूप से लिंक की गई छवियों के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/java/exporting-presentations-to-html-with-externally-linked-images/
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
- लिंक्ड छवि
- बाहरी रूप से लिंक्ड छवि
- लिंक्ड संसाधन
- बाहरी संसाधन
- Java
- Aspose.Slides
description: "Java में Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ छवियाँ और अन्य संसाधन बाहरी लिंक्ड फ़ाइलों के रूप में सहेजे जाते हैं।"
---
## **समीक्षा**

डिफ़ॉल्ट रूप से, Aspose.Slides एक प्रस्तुति को एक स्व-समाहित HTML फ़ाइल में निर्यात करता है। छवियों और अन्य संसाधनों को सीधे HTML में लिखा जाता है, आमतौर पर Base64 डेटा के रूप में। यह तब सुविधाजनक होता है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेबसाइट, CMS, या सर्वर-साइड रूपांतरण पाइपलाइन के लिए सबसे अच्छा फॉर्मेट नहीं होता।

जब आप निम्नलिखित चाहते हैं तो बाहरी रूप से लिंक किए गए संसाधनों का उपयोग करें:

- HTML दस्तावेज़ का आकार कम करें;
- ब्राउज़र या CDN में छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो को अलग से कैश करें;
- निर्यात के बाद उत्पन्न संसाधनों की जाँच, प्रतिस्थापन, संपीड़न, या पोस्ट‑प्रोसेस करें;
- आउटपुट संरचना को वेब एप्लिकेशन की अपेक्षा के करीब रखें।

सामान्य HTML रूपांतरण कार्यप्रवाह के लिए, देखें [PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें](/slides/hi/java/convert-powerpoint-to-html/). यह लेख निर्यात के संसाधन‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड संसाधन निर्यात कैसे काम करता है**

[ILinkEmbedController](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) आपके अनुप्रयोग को यह तय करने देता है, प्रत्येक संसाधन के अनुसार, कि निर्यातक डेटा को HTML में एम्बेड करे या उसे बाहरी रूप से सहेजे और एक लिंक लिखे।

इंटरफ़ेस में तीन विधियाँ हैं:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) निर्धारित करता है कि किसी संसाधन को लिंक किया जाना चाहिए या एम्बेड किया जाना चाहिए।
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) वह URL लौटाता है जो उत्पन्न HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाएगा।
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज लक्ष्य पर लिखता है।

फ़ाइल सिस्टम पथ और ब्राउज़र URL अलग-अलग विचार हैं। उदाहरण के लिए, नीचे का नमूना संसाधन फ़ाइलों को डिस्क पर `html-output/assets` में लिखता है, जबकि HTML में `assets/resource-1.svg` जैसे सापेक्ष URL होते हैं। ब्राउज़र इन URL को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक होता है। इसलिए, `presentation.html` से SVG फ़ाइल के लिए लिंक `assets/resource-1.svg` उपयोग करता है, जबकि उसी `assets` फ़ोल्डर में सहेजी गई छवि के लिए उस SVG फ़ाइल से लिंक `resource-4.jpg` उपयोग करता है।

## **लिंक्ड संसाधनों के साथ HTML निर्यात करें**

निम्नलिखित Java उदाहरण एक आउटपुट डायरेक्टरी बनाता है, वहां HTML फ़ाइल को सहेजता है, और लिंक्ड संसाधनों को `assets` उपडायरेक्टरी में संग्रहित करता है। जब Aspose.Slides एक सुरक्षित फ़ाइल एक्सटेंशन प्रदान करता है या अनुमान लगा सकता है, तो कंट्रोलर सामान्य छवि, फ़ॉन्ट, ऑडियो, वीडियो, और CSS संसाधनों को लिंक करता है। जिन्हें पहचान नहीं पाया जाता, वे एम्बेडेड रहते हैं।

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

निर्यात के बाद, आउटपुट फ़ोल्डर की संरचना इस प्रकार है:

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

सटीक फ़ाइलें प्रस्तुति की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर छवियों को सामान्यतः JPEG या PNG के रूप में निर्यात किया जाता है। Aspose.Slides स्रोत प्रस्तुति में उपयोग किए गए कोडेक से अलग इमेज कोडेक चुन सकता है यदि इससे छोटा या अधिक उपयुक्त फ़ाइल बनता है। पारदर्शिता वाली छवियों को PNG के रूप में निर्यात किया जाता है।

## **परिनियोजन के लिए URL चुनना**

नमूना एक सापेक्ष URL उपसर्ग का उपयोग करता है: `assets/`। यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड संसाधन दूसरे लिंक्ड संसाधन को संदर्भित करता है, तो नमूना `referrer` पैरामीटर को [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) में उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलों को कहीं और परिनियोजित करने पर अलग URL उपसर्ग प्रयोग करें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो तो `assets/` उपयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थिर फ़ाइल सर्वर पर अपलोड की गई हों तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) द्वारा लौटाया गया URL, [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) द्वारा लिखी गई फ़ाइल के अंतिम परिनियोजन स्थान के अनुरूप होना चाहिए। सर्वर अनुप्रयोगों में, प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज उपसर्ग का उपयोग करें ताकि किसी अन्य निर्यात की फ़ाइलों को ओवरराइट करने से बचा जा सके।

## **कब एम्बेड करना चाहिए**

एम्बेड किया गया Base64 HTML तब भी उपयोगी होता है जब आउटपुट को एक एकल फ़ाइल होना चाहिए, जैसे ईमेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या ऐसा दस्तावेज़ जिसे समर्थन फ़ोल्डर के बिना स्थानांतरित किया जाएगा। लिंक्ड संसाधन बेहतर होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहित किया जाएगा, बिल्ड पाइपलाइन द्वारा अनुकूलित किया जाएगा, या ब्राउज़र द्वारा HTML से स्वतंत्र रूप से कैश किया जाएगा।

## **FAQ**

**क्या मैं केवल छवियों को बाहरी बना सकता हूँ और अन्य संसाधन एम्बेडेड रख सकता हूँ?**

हाँ। [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilinkembedcontroller/) में, उन सामग्री प्रकारों के लिए `LinkEmbedDecision.Link` लौटाएँ जो आप अलग फ़ाइलों के रूप में सहेजना चाहते हैं, और अन्य सभी के लिए `LinkEmbedDecision.Embed` लौटाएँ।

**निर्यात की गई छवि एक्सटेंशन स्रोत प्रस्तुति से अलग क्यों है?**

Aspose.Slides HTML निर्यात के दौरान रास्टर छवियों को पुनः एन्कोड कर सकता है ताकि आकार या ब्राउज़र संगतता बेहतर हो। उदाहरण के लिए, स्रोत फ़ाइल की एक छवि को JPEG या PNG के रूप में लिखा जा सकता है, रेंडर किए गए परिणाम के आधार पर।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद सापेक्ष URL काम करेंगे?**

सापेक्ष URL केवल तभी काम करेंगे जब वही सापेक्ष फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में रहना चाहिए, जब तक आप एक अलग URL उपसर्ग नहीं बनाते।

**क्या सर्वर अनुप्रयोगों को वही आउटपुट फ़ोल्डर पुन: उपयोग करना चाहिए?**

नहीं। प्रत्येक रूपांतरण कार्य के लिए एक अद्वितीय आउटपुट डायरेक्टरी या स्टोरेज उपसर्ग का उपयोग करें। इससे फ़ाइल नाम टकराव नहीं होते और किसी एक निर्यात द्वारा दूसरे निर्यात के संसाधनों को ओवरराइट करने से बचा जा सकता है।