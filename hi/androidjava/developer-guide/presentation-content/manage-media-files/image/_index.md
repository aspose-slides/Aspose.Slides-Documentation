---
title: "एंड्रॉइड पर प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/androidjava/image/
keywords:
- "छवि जोड़ें"
- "चित्र जोड़ें"
- "बिटमैप जोड़ें"
- "छवि बदलें"
- "चित्र बदलें"
- "वेब से"
- "पृष्ठभूमि"
- "PNG जोड़ें"
- "JPG जोड़ें"
- "SVG जोड़ें"
- "बाहरी SVG संसाधन"
- "SVG रिज़ॉल्वर"
- "लिंक्ड SVG छवियां"
- "SVG फ़ॉन्ट"
- "EMF जोड़ें"
- "WMF जोड़ें"
- "TIFF जोड़ें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Android"
- "Java"
- "Aspose.Slides"
description: "PowerPoint और OpenDocument में छवि प्रबंधन को Aspose.Slides for Android via Java के साथ सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से आकर्षक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइडों पर चित्र सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको विभिन्न तरीकों से प्रस्तुति स्लाइडों में छवियां जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="primary" %}} 

Aspose मुफ्त कन्वर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से जल्दी प्रस्तुतियां बनाने की सुविधा देता है। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप एक चित्र को पिक्चर फ्रेम के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप उसका आकार बदलने, प्रभाव लागू करने, या अन्य मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बना रहे हैं—तो देखें [Picture Frame](/slides/hi/androidjava/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को परिवर्तित कर सकते हैं। निम्नलिखित पृष्ठ देखें: convert [image to JPG](https://products.aspose.com/slides/hi/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/androidjava/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/androidjava/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides लोकप्रिय फ़ॉर्मेट जैसे JPEG, PNG, BMP, GIF, और अन्य में छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। निम्नलिखित Java नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जिसे आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

निम्नलिखित Java नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **स्लाइड मास्टर्स में छवियों को जोड़ें**

एक स्लाइड मास्टर थीम और लेआउट जैसी जानकारी को संग्रहीत और नियंत्रित करता है उन स्लाइड्स के लिए जो इसका उपयोग करती हैं। जब आप स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित प्रत्येक स्लाइड पर दिखाई देती है। 

निम्नलिखित Java नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **छवियों को स्लाइड बैकग्राउंड के रूप में जोड़ें**

आप एक या अधिक स्लाइडों के लिए पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[स्लाइड्स के लिए पृष्ठभूमि के रूप में छवियों को सेट करना](/slides/hi/androidjava/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को एक प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgimage/) क्लास का उपयोग करके जोड़ा जा सकता है। फलस्वरूप बनने वाला [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति छवि संग्रह में जोड़ा जा सकता है और पिक्चर फ्रेम बनाने के लिए उपयोग किया जा सकता है।

निम्नलिखित Java उदाहरण एक स्वयं-निहित SVG स्ट्रिंग को आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, शैलियाँ, और अन्य संसाधन सीधे SVG सामग्री में एम्बेड किए जाते हैं।

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **बाहरी संसाधनों के साथ SVG सामग्री आयात करें**

SVG फ़ाइलें जो डिजाइन टूल्स, डायग्राम एडिटर, आइकन सिस्टम और वेब पाइपलाइन से निर्यात की गई हैं, वे ऐसे संसाधनों का संदर्भ दे सकती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, एक CSS `url(...)` मान, या एक फ़ॉन्ट URL हो सकता है।

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ एक उपयुक्त [SvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgimage/) कॉन्स्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है और सापेक्ष लिंक को हल करने के लिए उपयोग किया जाता है।

[ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/) इंटरफ़ेस आयात किए गए SVG की जानकारी तक पहुँच प्रदान करता है:

- `getSvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `getSvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `getBaseUri()` सापेक्ष लिंक के लिए उपयोग किए गए बेस URI को लौटाता है।
- `getExternalResourceResolver()` SVG छवि को सौंपे गए रिज़ॉल्वर को लौटाता है।

### **बाहरी संसाधन रिज़ॉल्वर लागू करें**

रिज़ॉल्वर के दो मेथड होते हैं:

- `resolveUri` बेस URI और सापेक्ष संसाधन लिंक को मिलाकर एक पूर्ण URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमत नहीं है, तब `null` लौटाएँ।
- `getEntity` पूर्ण संसाधन URI के लिए पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध, या नहीं मिला हो, तब `null` लौटाएँ। आवश्यक होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है।

निम्नलिखित रिज़ॉल्वर केवल अनुमत स्थानीय डायरेक्टरी से लिंक्ड संसाधनों को लोड करता है। नेटवर्क संसाधन और अनुमत डायरेक्टरी के बाहर के पाथ अवरुद्ध होते हैं। अनसॉल्व्ड इमेज लिंक के लिए वैकल्पिक फॉलबैक इमेज लौटाई जाती है।

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // यह रिज़ॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों को अनुमति देता है।
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // केवल छवि संसाधनों के लिए फॉलबैक का उपयोग करें। एक छवि स्ट्रीम लौटाना
            // गायब फ़ॉन्ट या स्टाइलशीट के लिए वैध नहीं होगा।
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **SVG आयात के दौरान लिंक्ड संसाधनों को हल करें**

मान लीजिए `assets/diagram.svg` में निम्नलिखित सापेक्ष संदर्भ है:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निम्नलिखित Java उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिज़ॉल्वर प्रदान करता है। रिज़ॉल्वर सापेक्ष इमेज लिंक को पूर्ण URI में बदलता है और Aspose.Slides द्वारा SVG प्रोसेस करते समय लिंक्ड संसाधन वाली स्ट्रीम लौटाता है।

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है।
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI और रिज़ॉल्वर को उजागर करता है।
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` क्लास भी ओवरलोड प्रदान करती है जो SVG डेटा को बाइट एरे या इनपुट स्ट्रीम के रूप में स्वीकार करती है, साथ ही एक बाहरी संसाधन रिज़ॉल्वर और बेस URI प्रदान करती है।

{{% alert title="Important" color="warning" %}}

रिसोर्स रिज़ॉल्वर SVG प्रोसेस और रेंडर करते समय बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड नहीं करता।

जब एक `ISvgImage` को प्रस्तुति छवि संग्रह में जोड़ा जाता है, तो PPTX फ़ाइल में मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक इमेज दोनों हो सकते हैं। एक लिंक्ड रिसोर्स उत्पन्न फॉलबैक इमेज में दिखाई दे सकता है जबकि `images/photo.png` जैसी सापेक्ष लिंक संग्रहित SVG में अपरिवर्तित रहती है। जो एप्लिकेशन नेटिव SVG प्रतिनिधित्व को रेंडर करता है, वह मूल बाहरी संसाधन अनुपलब्ध होने पर लिंक्ड कंटेंट को हटाना चुन सकता है।

{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

एक पोर्टेबल SVG चित्र बनाने के लिए, `SvgImage` बनाने से पहले SVG को स्वयं-निहित बनाएं। उदाहरण के लिए, लिंक्ड इमेज URLs को `data:` URI से बदलें जिसमें इमेज डेटा शामिल हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधन SVG सामग्री में एम्बेड होने के बाद, `SvgImage` बनाएं, इसे प्रस्तुति छवि संग्रह में जोड़ें, और पूर्व उदाहरण में दिखाए अनुसार पिक्चर फ्रेम में सम्मिलित करें।

### **गुम या अवरुद्ध संसाधनों को संभालें**

जब कोई रिसोर्स URI अमान्य, प्रतिबंधित, या हल नहीं किया जा सकता हो, तो `resolveUri` से `null` लौटाएँ। जब रिसोर्स पढ़ा नहीं जा सकता, तो `getEntity` से `null` लौटाएँ। जब संभव हो, Aspose.Slides उस रिसोर्स के बिना SVG प्रोसेसिंग जारी रखता है।

गुम रिसोर्स के लिए फॉलबैक स्ट्रीम लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित रिसोर्स प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल गुम इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}

अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या अनियंत्रित नेटवर्क URLs को हल न करें। अनुमत स्कीम, डायरेक्टरी, और होस्ट को प्रतिबंधित करें। नेटवर्क संसाधनों के लिए कनेक्शन टाइमआउट, रिस्पॉन्स-साइज़ लिमिट और कंटेंट वैलिडेशन लागू करें।

{{% /alert %}}

## **SVG को आकारों के सेट में परिवर्तित करें**

Aspose.Slides SVG को आकारों के सेट में परिवर्तित कर सकता है, जैसे PowerPoint में उपलब्ध समान कार्यक्षमता:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [addGroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShapeCollection) इंटरफ़ेस पर लागू है और पहला आर्ग्युमेंट के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISvgImage) ऑब्जेक्ट लेता है।

निम्नलिखित Java नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// स्रोत SVG फ़ाइल नाम.
String svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम.
String outPptxPath = "presentation.pptx";

// नई प्रस्तुति बनाएं.
IPresentation presentation = new Presentation();
try {
    // SVG फ़ाइल सामग्री पढ़ें.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // एक SvgImage ऑब्जेक्ट बनाएं.
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड आकार प्राप्त करें.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG छवि को आकारों के समूह में बदलें और स्लाइड आकार के अनुसार स्केल करें.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **EMF के रूप में छवियों को स्लाइड्स में जोड़ें**

Aspose.Slides for Android via Java आपको Aspose.Cells के साथ Excel वर्कशीट्स से EMF छवियां उत्पन्न करके उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है।

निम्नलिखित Java नमूना कोड दिखाता है कि यह कैसे किया जाता है:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// वर्कबुक को स्ट्रीम में सहेजें।
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // फ़ाइल को जैसा है वैसा जोड़ें ताकि चित्र रास्टराइज़ होने के बजाय वेक्टर EMF बना रहे।
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **छवि संग्रह में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति के इमेज कलेक्शन में संग्रहीत छवियों को बदलने देता है, जिसमें स्लाइड शेप्स द्वारा उपयोग की गई छवियां भी शामिल हैं। यह सेक्शन कलेक्शन में छवियों को अपडेट करने के कई तरीकों का विवरण देता है। आप एक छवि को रॉ बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) इंस्टेंस, या संग्रह में पहले से मौजूद किसी अन्य छवि के माध्यम से बदल सकते हैं।

निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके छवियों वाली प्रस्तुति फ़ाइल लोड करें।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे दृष्टिकोण में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और उस ऑब्जेक्ट से लक्ष्य छवि को बदलें।
5. तीसरे दृष्टिकोण में, लक्ष्य छवि को प्रस्तुति के इमेज कलेक्शन में पहले से मौजूद कोई अन्य छवि से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("sample.pptx");
try {
    // पहला तरीका।
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // दूसरा तरीका।
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // तीसरा तरीका।
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Aspose के मुफ्त [Text to GIF] कन्वर्टर के साथ, आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं और टेक्स्ट से GIF बना सकते हैं। 

{{% /alert %}}

## **अधिक पूछे जाने वाले प्रश्न**

**इन्सर्शन के बाद क्या मूल छवि का रिज़ॉल्यूशन बरकरार रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप इस पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/androidjava/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कौन सा संपीड़न लागू किया गया है।

**सैकड़ों स्लाइडों में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति के इमेज कलेक्शन में इसे बदलें—अपडेट सभी उन तत्वों में फैलेंगे जो उस रिसोर्स का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य शेप्स में बदला जा सकता है?**

हाँ। आप SVG को शेप्स के समूह में परिवर्तित कर सकते हैं, जिसके बाद व्यक्तिगत भाग मानक शेप प्रॉपर्टीज़ के साथ संपादन योग्य हो जाते हैं।

**मैं कई स्लाइडों के लिए एक साथ पिक्चर को बैकग्राउंड कैसे सेट कर सकता हूँ?**

[इमेज को बैकग्राउंड के रूप में असाइन करें](/slides/hi/androidjava/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—जो भी स्लाइडें उस मास्टर/लेआउट का उपयोग करती हैं, वे बैकग्राउंड विरासत में ले लेंगी।

**बहुत सारी छवियों के कारण प्रस्तुति बहुत बड़ी होने से कैसे रोकूँ?**

डुप्लिकेट्स की बजाय एक ही इमेज रिसोर्स को पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो, दोहराए गए ग्राफिक्स को मास्टर पर रखें।