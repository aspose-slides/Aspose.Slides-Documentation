---
title: Java का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन
type: docs
weight: 10
url: /hi/java/image/
keywords:
- छवि जोड़ें
- चित्र जोड़ें
- बिटमैप जोड़ें
- छवि बदलें
- चित्र बदलें
- वेब से
- पृष्ठभूमि
- PNG जोड़ें
- JPG जोड़ें
- SVG जोड़ें
- बाह्य SVG संसाधन
- SVG रिज़ॉल्वर
- लिंक्ड SVG छवियां
- SVG फ़ॉन्ट
- EMF जोड़ें
- WMF जोड़ें
- TIFF जोड़ें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument में Aspose.Slides for Java के साथ छवि प्रबंधन को सुसंगत बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्य प्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से मनोहारी बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड्स में चित्र सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides कई तरीकों से प्रस्तुति स्लाइड्स में छवियां जोड़ने की अनुमति देता है।

{{% alert  title="Tip" color="info" %}} 

Aspose निःशुल्क रूपांतरणकर्ता प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से शीघ्रता से प्रस्तुतियां बनाने की अनुमति देते हैं। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप किसी छवि को चित्र फ्रेम के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप इसे आकार बदलने, प्रभाव लागू करने, या अन्य मानक स्वरूपण विकल्पों का उपयोग करने की योजना बना रहे हैं—तो देखें [Picture Frame](/slides/hi/java/picture-frame/)। 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप छवियों को एक फ़ॉर्मेट से दूसरे में रूपांतरित कर सकते हैं। निम्नलिखित पृष्ठों पर देखें: बदलें [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/)।

{{% /alert %}}

Aspose.Slides लोकप्रिय फ़ॉर्मेट जैसे JPEG, PNG, BMP, GIF, और अन्य में छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियां स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। नीचे दिया गया Java नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

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

## **वेब से छवियां स्लाइड्स में जोड़ें**

यदि जिस छवि को आप स्लाइड में जोड़ना चाहते हैं वह आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

नीचे दिया गया Java नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

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

## **स्लाइड मास्टर्स में छवियां जोड़ें**

स्लाइड मास्टर उस थीम और लेआउट जैसी जानकारी को संग्रहित एवं नियंत्रित करता है जो इसके उपयोग वाली स्लाइड्स के लिए होती है। जब आप स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित सभी स्लाइड्स में दिखाई देती है।

नीचे दिया गया Java नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

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

## **स्लाइड पृष्ठभूमि के रूप में छवियां जोड़ें**

आप किसी एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विस्तृत जानकारी के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/java/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतियों में SVG जोड़ें**

SVG सामग्री को प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) क्लास का उपयोग करके जोड़ा जा सकता है। परिणामस्वरूप प्राप्त [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति की इमेज कलेक्शन में जोड़ा जा सकता है और इसे चित्र फ्रेम बनाने के लिए उपयोग किया जा सकता है।

नीचे दिया गया Java उदाहरण एक स्वयं-समाहित SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग किए गए सभी चित्र, स्टाइल और अन्य संसाधन सीधे SVG सामग्री में एम्बेड होते हैं।

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

डिज़ाइन टूल्स, डायग्राम एडिटर, आइकन सिस्टम और वेब पाइपलाइन से निर्यात किए गए SVG फ़ाइलें ऐसे संसाधनों का संदर्भ दे सकती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है।

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) कंस्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ के स्थान को पहचानता है और सापेक्ष लिंक को हल करने के लिए उपयोग होता है।

[ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) इंटरफ़ेस आयातित SVG के बारे में जानकारी तक पहुँच प्रदान करता है:

- `getSvgContent()` SVG मार्कअप को स्ट्रिंग रूप में लौटाता है।
- `getSvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `getBaseUri()` सापेक्ष लिंक के लिए उपयोग किए गए बेस URI को लौटाता है।
- `getExternalResourceResolver()` SVG छवि को सौंपे गए रिज़ॉल्वर को लौटाता है।

### **बाह्य संसाधन रिज़ॉल्वर लागू करें**

रिज़ॉल्वर में दो विधियां हैं:

- `resolveUri` बेस URI और सापेक्ष संसाधन लिंक को जोड़ता है और एक निरपेक्ष URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है तो `null` लौटाएं।
- `getEntity` निरपेक्ष संसाधन URI के लिए पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या नहीं मिला हो तो `null` लौटाएं। उपयुक्त होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है।

नीचे दिया गया रिज़ॉल्वर केवल अनुमत स्थानीय डायरेक्टरी से लिंक्ड संसाधन लोड करता है। नेटवर्क संसाधन और अनुमति प्राप्त डायरेक्टरी के बाहर के पथ अवरुद्ध होते हैं। अनसॉल्व्ड चित्र लिंक के लिए वैकल्पिक फॉलबैक चित्र लौटाया जाता है।

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

            // यह रिज़ॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों की अनुमति देता है।
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

मान लें कि `assets/diagram.svg` में निम्नलिखित सापेक्ष संदर्भ मौजूद है:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

नीचे दिया गया Java उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिज़ॉल्वर प्रदान करता है। रिज़ॉल्वर सापेक्ष छवि लिंक को निरपेक्ष URI में बदलता है और Aspose.Slides द्वारा SVG प्रसंस्करण के दौरान लिंक्ड संसाधन वाले स्ट्रीम को लौटाता है।

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

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

`SvgImage` क्लास ओवरलोड भी प्रदान करती है जो SVG डेटा को बाइट एरे या इनपुट स्ट्रीम के रूप में स्वीकार करती है, साथ ही बाहरी संसाधन रिज़ॉल्वर और बेस URI भी।

{{% alert title="Important" color="warning" %}}

रिसोर्स रिज़ॉल्वर Aspose.Slides द्वारा SVG प्रसंस्करण और रेंडरिंग के दौरान बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को नहीं बदलता और न ही स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड करता है।

जब `ISvgImage` को प्रस्तुति की इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल में मूल SVG प्रतिनिधित्व तथा एक रास्टर फॉलबैक इमेज दोनों हो सकते हैं। एक लिंक्ड रिसोर्स उत्पन्न फॉलबैक इमेज में दिख सकता है जबकि `images/photo.png` जैसी सापेक्ष लिंक संग्रहीत SVG में अपरिवर्तित रहती है। इसलिए, यदि मूल बाहरी संसाधन उपलब्ध नहीं है, तो मूल SVG प्रतिनिधित्व को रेंडर करने वाला एप्लिकेशन लिंक्ड सामग्री को छोड़ सकता है।

{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

एक ऐसा SVG चित्र बनाने के लिए जो बाहरी फ़ाइलों पर निर्भर न हो, `SvgImage` बनाने से पहले SVG को स्वयं-समाहित बनाएं। उदाहरण के लिए, लिंक्ड इमेज URL को `data:` URI से बदलें जिसमें इमेज डेटा सम्मिलित हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधनों को SVG सामग्री में एम्बेड करने के बाद, `SvgImage` बनाएं, इसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण में दिखाए अनुसार इसे चित्र फ्रेम में सम्मिलित करें।

### **ग़ायब या अवरुद्ध संसाधनों को संभालें**

`resolveUri` से `null` लौटाएँ जब संसाधन URI अमान्य, प्रतिबंधित या हल नहीं हो सकता। `getEntity` से `null` लौटाएँ जब संसाधन पढ़ा नहीं जा सकता। संभव होने पर Aspose.Slides उस संसाधन के बिना SVG प्रसंस्करण जारी रखता है।

ग़ायब संसाधन के लिए फॉलबैक स्ट्रीम लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल ग़ायब इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}

अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पथ या असंरक्षित नेटवर्क URL को हल न करें। अनुमत स्कीम, डायरेक्टरी और होस्ट को प्रतिबंधित करें। नेटवर्क संसाधनों के लिए, कनेक्शन टाइमआउट, प्रतिक्रिया आकार सीमा और सामग्री सत्यापन भी लागू करें।

{{% /alert %}}

## **SVG को आकारों के सेट में परिवर्तित करें**

Aspose.Slides एक SVG को आकारों के सेट में बदल सकता है, जो PowerPoint की समान कार्यक्षमता के समान है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) इंटरफ़ेस की [addGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) मेथड के ओवरलोड द्वारा प्रदान की जाती है, जो अपने पहले तर्क के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISvgImage) ऑब्जेक्ट लेती है।

नीचे दिया गया Java नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित किया जाए:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// स्रोत SVG फ़ाइल का नाम।
String svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल का नाम।
String outPptxPath = "presentation.pptx";

// नई प्रस्तुति बनाएँ।
IPresentation presentation = new Presentation();
try {
    // SVG फ़ाइल की सामग्री पढ़ें।
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // एक SvgImage वस्तु बनाएं।
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड का आकार प्राप्त करें।
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG छवि को आकारों के समूह में बदलें और स्लाइड आकार के अनुसार स्केल करें।
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **स्लाइड्स में EMF के रूप में छवियां जोड़ें**

Aspose.Slides for Java आपको Aspose.Cells के साथ Excel कार्यपत्रकों से EMF छवियां उत्पन्न करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है।

नीचे दिया गया Java नमूना कोड इसे करने का तरीका दर्शाता है:

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

        // फ़ाइल को जैसा है वैसा जोड़ें ताकि चित्र वेक्टर EMF बना रहे और रास्टर न हो।
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

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की अनुमति देता है, जिसमें स्लाइड आकारों द्वारा उपयोग की जाने वाली छवियां भी शामिल हैं। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीके बताता है। आप मूल बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. प्रेजेंटेशन फ़ाइल को लोड करें जिसमें छवियां हों, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करें।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।
6. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टैंस बनाएँ।
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

Aspose के निःशुल्क [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) रूपांतरणकर्ता के साथ, आप आसानी से टेक्स्ट को एनिमेट कर सकते हैं और टेक्स्ट से GIF बना सकते हैं। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सम्मिलन के बाद मूल छवि रिज़ॉल्यूशन बरकरार रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप इस पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/java/picture-frame/) कैसे स्केल किया गया है और सहेजते समय लागू कोई भी संपीड़न।

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और इसे प्रस्तुति की इमेज कलेक्शन में बदलें—अपडेट उन सभी तत्वों में प्रतिबिंबित होंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादनीय आकारों में बदला जा सकता है?**

हाँ। आप एक SVG को आकारों के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं एक चित्र को कई स्लाइड्स की पृष्ठभूमि के रूप में एक साथ कैसे सेट कर सकता हूं?**

[छवि को पृष्ठभूमि के रूप में असाइन करें](/slides/hi/java/presentation-background/) मास्टर स्लाइड या संबंधित लेआउट पर—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में ले लेंगी।

**कई चित्रों के कारण प्रस्तुति बहुत बड़ी होने से कैसे बचा सकता हूं?**

डुप्लिकेट के बजाय एक ही छवि संसाधन को पुन: उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो दोहराए जाने वाले ग्राफ़िक्स को मास्टर पर रखें।