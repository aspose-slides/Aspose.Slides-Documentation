---
title: बाह्य लिंक किए गए चित्रों के साथ प्रस्तुतियों को HTML में निर्यात करें
type: docs
weight: 100
url: /hi/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint निर्यात
- OpenDocument निर्यात
- प्रेजेंटेशन निर्यात
- स्लाइड निर्यात
- PPT निर्यात
- PPTX निर्यात
- ODP निर्यात
- PowerPoint से HTML
- OpenDocument से HTML
- प्रेजेंटेशन से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- ODP से HTML
- लिंक्ड इमेज
- बाहरी रूप से लिंक्ड इमेज
- लिंक्ड रिसोर्स
- बाहरी रिसोर्स
- एंड्रॉयड
- जावा
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Android में Java के माध्यम से PowerPoint और OpenDocument प्रस्तुतियों को HTML में निर्यात करें, जहाँ छवियों और अन्य संसाधनों को बाहरी लिंक वाली फ़ाइलों के रूप में सहेजा जाता है।"
---
## **सारांश**

डिफ़ॉल्ट रूप में, Aspose.Slides एक प्रेजेंटेशन को एक स्वतंत्र HTML फ़ाइल में निर्यात करता है। छवियों और अन्य संसाधनों को सीधे HTML में लिखा जाता है, आमतौर पर Base64 डेटा के रूप में। यह तब सुविधाजनक होता है जब आपको एक पोर्टेबल फ़ाइल चाहिए, लेकिन यह हमेशा वेब व्यू, CMS, या सर्वर‑साइड रूपांतरण पाइपलाइन के लिए सबसे अच्छा फॉर्मेट नहीं होता जो बाद में आउटपुट प्रकाशित करता है।

बाहरी लिंकित संसाधनों का उपयोग तब करें जब आप चाहते हैं:

- HTML दस्तावेज़ का आकार कम करना;
- ब्राउज़र या CDN में छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो को अलग‑अलग कैश करना;
- निर्यात के बाद उत्पन्न संसाधनों की जांच, प्रतिस्थापन, संपीड़न या पोस्ट‑प्रोसेसिंग करना;
- आउटपुट संरचना को वेब एप्लिकेशन की अपेक्षा के करीब रखना।

सामान्य HTML रूपांतरण कार्य‑प्रवाह के लिए, देखें [PowerPoint प्रस्तुतियों को HTML में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-html/). यह लेख निर्यात के रिसोर्स‑लिंकिंग भाग पर केंद्रित है।

## **लिंक्ड संसाधन निर्यात कैसे काम करता है**

[ILinkEmbedController](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) आपके एप्लिकेशन को संसाधन‑वार निर्णय करने देता है कि एक्सपोर्टर डेटा को HTML में एम्बेड करे या बाहरी रूप से सहेज कर लिंक लिखे।

इस इंटरफ़ेस में तीन मेथड हैं:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) यह निर्धारित करता है कि कोई संसाधन लिंक किया जाना चाहिए या एम्बेड।
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) वह URL लौटाता है जो उत्पन्न HTML या किसी अन्य लिंक्ड संसाधन में लिखा जाएगा।
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) लिंक्ड संसाधन डेटा को डिस्क या किसी अन्य स्टोरेज टार्गेट पर लिखता है।

फ़ाइल सिस्टम पाथ और ब्राउज़र URL अलग‑अलग विचार हैं। उदाहरण के लिए, नीचे दिया गया नमूना संसाधन फ़ाइलों को `html-output/assets` में एप्लिकेशन की फ़ाइल स्टोरेज में लिखता है, जबकि HTML में `assets/resource-1.svg` जैसे रिलेटिव URL होते हैं। ब्राउज़र उन URL को उस फ़ाइल के सापेक्ष हल करता है जिसमें लिंक स्थित है। इसलिए, `presentation.html` से एक SVG फ़ाइल को लिंक करने के लिए `assets/resource-1.svg` उपयोग किया जाता है, जबकि उसी `assets` फ़ोल्डर में सहेजी गई छवि को SVG फ़ाइल से लिंक करने के लिए `resource-4.jpg` उपयोग किया जाता है।

## **लिंक्ड संसाधन के साथ HTML निर्यात**

निम्न Android Java उदाहरण एक आउटपुट डायरेक्टरी बनाता है, वहाँ HTML फ़ाइल सहेजता है, और लिंक्ड संसाधनों को `assets` उप‑डायरेक्टरी में रखता है। `context.getFilesDir()` जैसे एप‑स्वामित्व वाले डायरेक्टरी को `applicationFilesDirectory` के रूप में पास करें। कोड `java.nio.file` API का उपयोग नहीं करता, इसलिए यह Android `minSdk` 19 के साथ संगत रहता है।

कंट्रोलर सामान्य छवि, फ़ॉन्ट, ऑडियो, वीडियो और CSS संसाधनों को लिंक करता है जब Aspose.Slides कोई सुरक्षित फ़ाइल एक्सटेंशन प्रदान करता है या उसका अनुमान लगा सकता है। जो संसाधन पहचान में नहीं आते वे एम्बेडेड रहते हैं।

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
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

सटीक फ़ाइलें प्रेजेंटेशन की सामग्री और निर्यात विकल्पों पर निर्भर करती हैं। उदाहरण के लिए, रास्टर छवियों को आमतौर पर JPEG या PNG के रूप में निर्यात किया जाता है। Aspose.Slides स्रोत प्रेजेंटेशन की तुलना में अलग इमेज कोडेक चुन सकता है जब वह छोटा या अधिक उपयुक्त फ़ाइल बनाता है। पारदर्शिता वाली छवियों को PNG के रूप में निर्यात किया जाता है।

## **परिनियोजन के लिए URL चुनना**

नमूना एक रिलेटिव URL प्रीफ़िक्स उपयोग करता है: `assets/`। यदि `presentation.html` को `html-output/presentation.html` से खोला जाता है, तो ब्राउज़र `html-output/assets/resource-1.svg` लोड करता है।

जब एक लिंक्ड संसाधन दूसरे लिंक्ड संसाधन को संदर्भित करता है, तो नमूना `referrer` पैरामीटर को [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) में उपयोग करता है और केवल फ़ाइल नाम लौटाता है। उदाहरण के लिए, यदि `resource-1.svg` और `resource-4.jpg` दोनों `assets` फ़ोल्डर में हैं, तो SVG फ़ाइल को `resource-4.jpg` को संदर्भित करना चाहिए, न कि `assets/resource-4.jpg` को।

फ़ाइलें कहीं और परिनियोजित होने पर अलग URL प्रीफ़िक्स उपयोग करें:

- जब एसेट डायरेक्टरी HTML फ़ाइल के बगल में हो, तो `assets/` उपयोग करें।
- जब एसेट डायरेक्टरी HTML फ़ाइल से एक स्तर ऊपर हो, तो `../assets/` उपयोग करें।
- जब फ़ाइलें CDN या स्थिर फ़ाइल सर्वर पर अपलोड की गई हों, तो `https://cdn.example.com/presentations/job-123/assets/` उपयोग करें।

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) द्वारा लौटाया गया URL उन फ़ाइलों के अंतिम परिनियोजित स्थान से मेल खाना चाहिए जो [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) द्वारा लिखी गई हों। Android एप्लिकेशनों में, अपनी प्रकाशन कार्यप्रवाह के अनुसार एप‑विशिष्ट स्टोरेज, कैश डायरेक्टरी, या Storage Access Framework द्वारा प्राप्त डायरेक्टरी उपयोग करें। सर्वर एप्लिकेशनों में, प्रत्येक रूपांतरण नौकरी के लिये एक अद्वितीय आउटपुट डायरेक्टरी या ऑब्जेक्ट‑स्टोरेज प्रीफ़िक्स उपयोग करें ताकि एक निर्यात द्वारा दूसरी निर्यात की फ़ाइलें ओवरराइट न हों।

## **जब एम्बेड किया जाना चाहिए**

यदि आउटपुट को एक ही फ़ाइल होना आवश्यक है, जैसे ई‑मेल अटैचमेंट, ऑफ़लाइन प्रीव्यू, या वह दस्तावेज़ जो सहायक एसेट फ़ोल्डर के बिना स्थानांतरित किया जाएगा, तो एम्बेडेड Base64 HTML अभी भी उपयोगी है। लिंक्ड संसाधन तब बेहतर होते हैं जब HTML को वेब एप्लिकेशन द्वारा सर्व किया जाएगा, CMS में संग्रहीत किया जाएगा, बिल्ड पाइपलाइन द्वारा अनुकूलित किया जाएगा, या ब्राउज़र द्वारा HTML से स्वतंत्र रूप से कैश किया जाएगा।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल छवियों को बाहरी बना सकता हूं और अन्य संसाधनों को एम्बेड रख सकता हूं?**

हाँ। [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilinkembedcontroller/) में, उन कंटेंट टाइप्स के लिये ही जो आप अलग फ़ाइलों में सहेजना चाहते हैं, [LinkEmbedDecision](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/linkembeddecision/) से `Link` लौटाएँ, और बाकी सभी के लिये `Embed` लौटाएँ।

**निर्यात की गई छवि एक्सटेंशन स्रोत प्रस्तुति से क्यों भिन्न है?**

Aspose.Slides HTML निर्यात के दौरान रास्टर छवियों को पुनः‑एन्कोड कर सकता है ताकि आकार कम हो या ब्राउज़र संगतता बढ़े। उदाहरण के लिए, स्रोत फ़ाइल की एक छवि को JPEG या PNG के रूप में लिखा जा सकता है, निर्भर करता है कि कौन सा परिणाम बेहतर दिखता है।

**क्या HTML फ़ाइल को स्थानांतरित करने के बाद रिलेटिव URL काम करेंगे?**

रिलेटिव URL तभी काम करेंगे जब वही रिलेटिव फ़ोल्डर संरचना बनी रहे। यदि HTML `assets/resource-1.png` को संदर्भित करता है, तो `assets` फ़ोल्डर को HTML फ़ाइल के बगल में रहना चाहिए, या आपको अलग URL प्रीफ़िक्स जनरेट करना पड़ेगा।

**क्या मैं Android पर सार्वजनिक बाहरी स्टोरेज में संसाधनों को लिख सकता हूं?**

हाँ, यदि आपका एप्लिकेशन लक्षित Android संस्करण के लिये उपयुक्त गंतव्य और परमिशन मॉडल रखता है। केवल आपके एप द्वारा उपयोग की जाने वाली जनरेटेड HTML के लिये, एप‑स्पेसिफिक फ़ाइलें या कैश डायरेक्टरी आमतौर पर सरल होती हैं। उपयोगकर्ता‑दिखाने योग्य आउटपुट के लिये, उपयोगकर्ता‑चयनित स्थान या कोई अन्य स्टोरेज विकल्प उपयोग करें जो आपके एप से मेल खाता हो।

**क्या सर्वर एप्लिकेशन को एक ही आउटपुट फ़ोल्डर पुन: उपयोग करना चाहिए?**

नहीं। प्रत्येक रूपांतरण कार्य के लिये एक अद्वितीय आउटपुट डायरेक्टरी या स्टोरेज प्रीफ़िक्स उपयोग करें। यह फ़ाइलनाम टकराव से बचाता है और एक निर्यात द्वारा दूसरी निर्यात की संसाधनों को ओवरराइट होने से रोकता है।