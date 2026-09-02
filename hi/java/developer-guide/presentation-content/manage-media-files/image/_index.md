---
title: जावा का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें
linktitle: छवियों का प्रबंधन करें
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
- बाहरी SVG संसाधन
- SVG रेज़ॉल्वर
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
description: "PowerPoint और OpenDocument में छवि प्रबंधन को Aspose.Slides for Java के साथ सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से सुन्दर बनाती हैं। Microsoft PowerPoint में आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड्स में चित्र डाल सकते हैं। इसी प्रकार Aspose.Slides आपको कई तरीकों से प्रस्तुतियों की स्लाइड्स में छवियां जोड़ने की सुविधा देता है।

{{% alert title="Tip" color="primary" %}} 
Aspose मुफ्त कन्वर्टर प्रदान करता है—[JPEG को PowerPoint में](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG को PowerPoint में](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से जल्दी से प्रस्तुतियां बनाने में मदद करते हैं। 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
यदि आप छवि को एक पिक्चर फ्रेम के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप उसका आकार बदलने, प्रभाव लागू करने या अन्य मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बना रहे हैं—तो देखें [Picture Frame](/slides/hi/java/picture-frame/)। 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
आप एक फ़ॉर्मेट से दूसरी फ़ॉर्मेट में छवियों को बदल सकते हैं। निम्नलिखित पृष्ठ देखें: बदलें [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/)।
{{% /alert %}}

Aspose.Slides लोकप्रिय फ़ॉर्मेट जैसे JPEG, PNG, BMP, GIF और अन्य में छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुतियों की स्लाइड में जोड़ सकते हैं। नीचे दिया गया Java नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

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

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 

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

## **स्लाइड मास्टर में छवियों को जोड़ें**

स्लाइड मास्टर थिम और लेआउट जैसी जानकारी को संग्रहीत और नियंत्रित करता है जो उस पर आधारित स्लाइड्स के लिए उपयोग होती हैं। जब आप एक छवि को स्लाइड मास्टर में जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित हर स्लाइड पर दिखाई देती है। 

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

## **स्लाइड बैकग्राउंड के रूप में छवियां जोड़ें**

आप एक चित्र को एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/java/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रस्तुतीकरण में SVG जोड़ें**

SVG सामग्री को [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) क्लास का उपयोग करके प्रस्तुतीकरण में जोड़ा जा सकता है। परिणामी [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुतीकरण की इमेज कलेक्शन में जोड़ा जा सकता है और पिक्चर फ्रेम बनाने के लिए इस्तेमाल किया जा सकता है।

नीचे दिया गया Java उदाहरण एक आत्म-संतुष्ट SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, शैलियां और अन्य संसाधन सीधे SVG सामग्री में एंबेड होते हैं।

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

डिज़ाइन टूल्स, डायग्राम एडिटर्स, आइकन सिस्टम और वेब पाइपलाइन से एक्सपोर्ट किए गए SVG फ़ाइलें अक्सर ऐसे संसाधनों को संदर्भित करती हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसी छवि लिंक, एक CSS `url(...)` मान, या एक फ़ॉन्ट URL हो सकता है।

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) कन्स्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ के स्थान को पहचानता है और रिलेटिव लिंक को हल करने के लिए उपयोग किया जाता है।

[ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/) इंटरफ़ेस आयातित SVG के बारे में जानकारी तक पहुँच प्रदान करता है:

- `getSvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `getSvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `getBaseUri()` रिलेटिव लिंक के लिए उपयोग किया गया बेस URI लौटाता है।
- `getExternalResourceResolver()` SVG छवि को असाइन किया गया रेज़ॉल्वर लौटाता है।

### **बाहरी संसाधन रेज़ॉल्वर लागू करें**

रेज़ॉल्वर में दो मेथड होते हैं:

- `resolveUri` बेस URI और रिलेटिव रिसोर्स लिंक को मिलाकर एक एब्सॉल्यूट URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है तो `null` लौटाएँ।
- `getEntity` एब्सॉल्यूट रिसोर्स URI के लिए एक रीडेबल स्ट्रीम लौटाता है। जब रिसोर्स अनुपलब्ध, ब्लॉक किया गया या उपलब्ध नहीं हो तो `null` लौटाएँ। आवश्यक होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है।

नीचे दिया गया रेज़ॉल्वर केवल अनुमत स्थानीय डायरेक्टरी से लिंक्ड रिसोर्सेज़ लोड करता है। नेटवर्क रिसोर्सेज़ और अनुमत डायरेक्टरी के बाहर के पाथ ब्लॉक किए जाते हैं। अनसॉल्व्ड इमेज लिंक के लिए एक वैकल्पिक फॉलबैक इमेज लौटाई जाती है।

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

            // यह रेज़ॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों को अनुमति देता है।
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

            // केवल छवि संसाधनों के लिए फॉलबैक का उपयोग करें। इमेज स्ट्रीम लौटाना
            // ग़ायब फ़ॉन्ट या स्टाइलशीट के लिए मान्य नहीं होगा।
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

### **SVG आयात के दौरान लिंक्ड रिसोर्सेज़ हल करें**

मान लीजिए `assets/diagram.svg` में एक रिलेटिव रेफ़रेंस है जैसे:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

नीचे दिया गया Java उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रेज़ॉल्वर प्रदान करता है। रेज़ॉल्वर रिलेटिव इमेज लिंक को एब्सॉल्यूट URI में बदलता है और लिंक्ड रिसोर्स को शामिल करने वाला स्ट्रीम लौटाता है जबकि Aspose.Slides SVG को प्रोसेस करता है।

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

`SvgImage` क्लास ऐसी ओवरलोड भी प्रदान करता है जो SVG डेटा को बाइट एरे या इनपुट स्ट्रीम के रूप में स्वीकार करता है, साथ ही एक एक्सटर्नल रिसोर्स रेज़ॉल्वर और बेस URI भी।

{{% alert title="Important" color="warning" %}}
रिसोर्स रेज़ॉल्वर SVG को प्रोसेस और रेंडर करते समय बाहरी रिसोर्सेज़ को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए रिसोर्सेज़ को उसमें एंबेड नहीं करता।

जब एक `ISvgImage` को प्रस्तुतीकरण की इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल में मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक इमेज दोनों हो सकते हैं। एक लिंक्ड रिसोर्स उत्पन्न फॉलबैक इमेज में दिखाई दे सकता है जबकि `images/photo.png` जैसी रिलेटिव लिंक संग्रहीत SVG में अपरिवर्तित रहती है। मूल SVG को रेंडर करने वाला एप्लिकेशन इसलिए लिंक्ड कंटेंट को छोड़ सकता है जब मूल बाहरी रिसोर्स उपलब्ध नहीं हो।
{{% /alert %}}

### **पोर्टेबल SVG चित्र बनाएं**

एक ऐसा SVG चित्र बनाने के लिए जो बाहरी फ़ाइलों पर निर्भर न हो, `SvgImage` बनाने से पहले SVG को आत्म-संतुष्ट बनाएं। उदाहरण के लिए, लिंक्ड इमेज URL को `data:` URI से बदलें जिसमें इमेज डेटा हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

जब सभी आवश्यक रिसोर्सेज़ SVG सामग्री में एंबेड हो जाएँ, तो `SvgImage` बनाएं, उसे प्रस्तुतीकरण की इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण के अनुसार पिक्चर फ्रेम में सम्मिलित करें।

### **ग़ायब या ब्लॉक किए गए रिसोर्सेज़ को संभालें**

जब रिसोर्स URI अमान्य, प्रतिबंधित या हल नहीं किया जा सकता हो तो `resolveUri` से `null` लौटाएँ। जब रिसोर्स पढ़ा नहीं जा सकता हो तो `getEntity` से `null` लौटाएँ। Aspose.Slides संभव होने पर उस रिसोर्स के बिना SVG को प्रोसेस करता रहता है।

एक फॉलबैक स्ट्रीम ग़ायब रिसोर्स के लिए लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित रिसोर्स प्रकार के अनुकूल होनी चाहिए। उदाहरण के लिए, केवल ग़ायब इमेज के लिए इमेज स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}
अविश्वासनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या असीम नेटवर्क URL को हल न करें। अनुमत स्कीम, डायरेक्टरी और होस्ट को प्रतिबंधित करें। नेटवर्क रिसोर्सेज़ के लिए कनेक्शन टाइमआउट, प्रतिक्रिया आकार सीमा और कंटेंट वैलिडेशन लागू करें।
{{% /alert %}}

## **SVG को आकृतियों के सेट में बदलें**

Aspose.Slides एक SVG को आकृतियों के सेट में बदल सकता है, जैसा कि PowerPoint में संबंधित कार्यक्षमता होती है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [addGroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) मेथड की ओवरलोड द्वारा प्रदान की गई है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeCollection) इंटरफ़ेस का हिस्सा है और पहला पैरामीटर एक [ISvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISvgImage) ऑब्जेक्ट लेता है।

नीचे दिया गया Java नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकृतियों के सेट में कैसे बदलें:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// स्रोत SVG फ़ाइल नाम।
String svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम।
String outPptxPath = "presentation.pptx";

// एक नई प्रस्तुति बनाएं।
IPresentation presentation = new Presentation();
try {
    // SVG फ़ाइल की सामग्री पढ़ें।
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // एक SvgImage ऑब्जेक्ट बनाएं।
    ISvgImage svgImage = new SvgImage(svgContent);

    // स्लाइड का आकार प्राप्त करें।
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG छवि को आकृतियों के समूह में बदलें और उसे स्लाइड के आकार के अनुसार स्केल करें।
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

Aspose.Slides for Java आपको Aspose.Cells के साथ Excel वर्कशीट से EMF छवियां जेनरेट करने और उन्हें प्रस्तुतीकरण स्लाइड्स में जोड़ने की अनुमति देता है।

नीचे दिया गया Java नमूना कोड दिखाता है कि यह कैसे करें:

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

Aspose.Slides आपको प्रस्तुतीकरण की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की सुविधा देता है, जिसमें स्लाइड शेप्स द्वारा उपयोग की गई छवियां भी शामिल हैं। यह भाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों का वर्णन करता है। आप छवि को कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि के माध्यम से बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. उन प्रस्तुतियों की फ़ाइल को लोड करें जिसमें छवियां हैं, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करें।
1. फ़ाइल से एक नई छवि को बाइट एरे में लोड करें।
1. बाइट एरे का उपयोग करके लक्षित छवि को नई छवि से बदलें।
1. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और उसे लक्षित छवि के साथ बदलें।
1. तीसरे तरीके में, लक्ष्य छवि को कलेक्शन में पहले से मौजूद छवि से बदलें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
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

    // प्रेज़ेंटेशन को फ़ाइल में सहेजें।
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर के साथ, आप आसानी से टेक्स्ट को एनिमेट कर GIF बना सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि सम्मिलित करने के बाद मूल रेजोल्यूशन बरकरार रहता है?**  
हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम स्वरूप स्लाइड पर [picture](/slides/hi/java/picture-frame/) के स्केलिंग और सेव के समय लागू किए गए किसी भी संपीड़न पर निर्भर करता है।

**कई स्लाइड्स में एक साथ एक ही लोगो बदलने का सबसे अच्छा तरीका क्या है?**  
लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुतीकरण की इमेज कलेक्शन में बदलें—अपडेट सभी उन तत्वों पर पहुंचेगा जो उस रिसोर्स का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकृतियों में बदला जा सकता है?**  
हां। आप SVG को आकृतियों के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत हिस्से मानक आकृति गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं कई स्लाइड्स के लिए एक साथ पिक्चर को बैकग्राउंड कैसे सेट करूं?**  
मास्टर स्लाइड या संबंधित लेआउट पर [इमेज को बैकग्राउंड के रूप में असाइन](/slides/hi/java/presentation-background/) करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स बैकग्राउंड विरासत में ले लेंगी।

**बहुत सारी छवियों की वजह से प्रस्तुतीकरण बहुत बड़ा हो जाने से मैं कैसे बचूं?**  
एक ही इमेज रिसोर्स को दोहराने के बजाय पुन: उपयोग करें, उचित रेजोल्यूशन चुनें, सेव पर संपीड़न लागू करें, और जहाँ संभव हो ग्राफिक को मास्टर पर रखें।