---
title: "PHP का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/php-java/image/
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
- "जुड़ी हुई SVG छवियां"
- "SVG फ़ॉन्ट"
- "EMF जोड़ें"
- "WMF जोड़ें"
- "TIFF जोड़ें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "EMF"
- "SVG"
- "PHP"
- "Aspose.Slides"
description: "PowerPoint और OpenDocument में Aspose.Slides for PHP via Java के साथ छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियों से प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से आकर्षक बनाया जा सकता है। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड्स पर चित्र सम्मिलित कर सकते हैं। इसी तरह, Aspose.Slides आपको कई तरीकों से प्रस्तुतियों की स्लाइड्स में छवियां जोड़ने की सुविधा देता है।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कन्वर्टर प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से तेज़ी से प्रस्तुतियां बनाने की अनुमति देते हैं। 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
यदि आप छवि को एक पिक्चर फ्रेम के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप उसका आकार बदलने, प्रभाव लागू करने, या अन्य मानक फ़ॉर्मेटिंग विकल्प उपयोग करने की योजना बना रहे हैं—तो देखें [चित्र फ्रेम](/slides/hi/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
आप एक फ़ॉर्मेट की छवियों को दूसरे फ़ॉर्मेट में बदल सकते हैं। निम्नलिखित पृष्ठों को देखें: बदलें [छवि को JPG में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/image-to-jpg/), [JPG को छवि में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-image/), [JPG को PNG में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/jpg-to-png/), [PNG को JPG में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/png-to-jpg/), [PNG को SVG में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/png-to-svg/), और [SVG को PNG में बदलें](https://products.aspose.com/slides/hi/php-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF और अन्य लोकप्रिय फ़ॉर्मेट की छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। नीचे दिया गया PHP नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ें:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जो आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

नीचे दिया गया PHP नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **स्लाइड मास्टर्स में छवियों को जोड़ें**

एक स्लाइड मास्टर उन स्लाइड्स के लिए थीम और लेआउट जैसी जानकारी संग्रहीत और नियंत्रित करता है जो इसे उपयोग करती हैं। जब आप एक स्लाइड मास्टर में छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित प्रत्येक स्लाइड में दिखाई देती है। 

नीचे दिया गया PHP नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **छवियों को स्लाइड पृष्ठभूमि के रूप में जोड़ें**

आप एक या अधिक स्लाइड्स की पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[स्लाइड की पृष्ठभूमि के लिए छवियों को सेट करना](/slides/hi/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **प्रस्तुति में SVG जोड़ें**

SVG सामग्री को प्रस्तुति में जोड़ने के लिए आप [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) क्लास का उपयोग कर सकते हैं। परिणामी SVG इमेज ऑब्जेक्ट को फिर प्रस्तुति की इमेज कलेक्शन में जोड़ा जा सकता है और इसे पिक्चर फ्रेम बनाने के लिए उपयोग किया जा सकता है। 

निचे दिया गया PHP उदाहरण एक सelf‑contained SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, शैलियां और अन्य संसाधन सीधे SVG सामग्री में एम्बेडेड होते हैं।

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **बाहरी संसाधनों के साथ SVG सामग्री आयात करें**

डिज़ाइन टूल्स, डायग्राम एडिटर्स, आइकन सिस्टम और वेब पाइपलाइन से निर्यात किए गए SVG फ़ाइलों में ऐसे संसाधनों का उल्लेख हो सकता है जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसे इमेज लिंक, एक CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है। 

ऐसी SVG सामग्री आयात करने के लिए, एक [ExternalResourceResolver](https://reference.aspose.com/slides/hi/php-java/aspose.slides/externalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) कंस्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ का स्थान पहचानता है और सापेक्ष लिंक को हल करने के लिए उपयोग किया जाता है। 

SVG इमेज ऑब्जेक्ट आयात किए गए SVG के बारे में जानकारी तक पहुंच प्रदान करता है:

- `getSvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `getSvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `getBaseUri()` सापेक्ष लिंक के लिए उपयोग किए गए बेस URI को लौटाता है।
- `getExternalResourceResolver()` SVG इमेज को सौंपे गए रिज़ॉल्वर को लौटाता है।

### **बाहरी संसाधन रिज़ॉल्वर को लागू करें**

रिज़ॉल्वर में दो मेथड होते हैं:

- `resolveUri` बेस URI और एक सापेक्ष संसाधन लिंक को मिलाकर एक पूर्ण URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है, तो `null` लौटाएं।
- `getEntity` एक पूर्ण संसाधन URI के लिए पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, ब्लॉक किया गया, या पढ़ा नहीं जा सकता, तो `null` लौटाएं। उपयुक्त होने पर एक फॉलबैक स्ट्रीम भी लौटाया जा सकता है।

निचे दिया गया रिज़ॉल्वर केवल अनुमत स्थानीय डायरेक्ट्री से जुड़े संसाधनों को लोड करता है। नेटवर्क संसाधन और अनुमत डायरेक्ट्री के बाहर के पाथ ब्लॉक किए जाते हैं। अनसॉल्व्ड इमेज लिंक के लिए वैकल्पिक फॉलबैक इमेज लौटाई जाती है।

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // यह रिजॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों की अनुमति देता है।
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // केवल छवि संसाधनों के लिए फॉलबैक का उपयोग करें। छवि स्ट्रीम लौटाना
            // गायब फ़ॉन्ट या स्टाइलशीट के लिए वैध नहीं होगा।
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **SVG आयात के दौरान जुड़े संसाधनों को हल करें**

मान लें कि `assets/diagram.svg` में निम्नलिखित सापेक्ष संदर्भ है:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निचे दिया गया PHP उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिज़ॉल्वर प्रदान करता है। रिज़ॉल्वर सापेक्ष इमेज लिंक को पूर्ण URI में परिवर्तित करता है और Aspose.Slides SVG प्रोसेस करते हुए जुड़ी हुई संसाधन वाली स्ट्रीम लौटाता है।

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है।
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG इमेज ऑब्जेक्ट स्रोत सामग्री, बाइनरी डेटा, बेस URI और रिज़ॉल्वर को उजागर करता है।
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` क्लास ऐसे ओवरलोड भी प्रदान करती है जो SVG डेटा को बाइट एरे या इनपुट स्ट्रीम के रूप में स्वीकार करती है, साथ ही एक बाहरी संसाधन रिज़ॉल्वर और बेस URI भी लेती है।

{{% alert title="Important" color="warning" %}}
रिसोर्स रिज़ॉल्वर SVG प्रोसेसिंग और रेंडरिंग के दौरान बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए संसाधनों को उसमें एम्बेड नहीं करता। 

जब एक SVG इमेज प्रस्तुति की इमेज कलेक्शन में जोड़ी जाती है, तो PPTX फ़ाइल में मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक इमेज दोनों हो सकते हैं। एक लिंक्ड रिसोर्स उत्पन्न फॉलबैक इमेज में दिखाई दे सकता है जबकि `images/photo.png` जैसी सापेक्ष लिंक संग्रहीत SVG में अपरिवर्तित रहती है। नेटिव SVG प्रतिनिधित्व को रेंडर करने वाला एप्लिकेशन मूल बाहरी संसाधन अनुपलब्ध होने पर लिंक्ड कंटेंट को छोड़ सकता है। 
{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएं**

बाहरी फ़ाइलों पर निर्भर न रहने वाला SVG चित्र बनाने के लिए, `SvgImage` बनाने से पहले SVG को सelf‑contained बनाएं। उदाहरण के लिए, लिंक्ड इमेज URL को `data:` URI से बदलें जिसमें इमेज डेटा शामिल हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधनों को SVG सामग्री में एम्बेड कर देने के बाद, `SvgImage` बनाएं, उसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण में दिखाए अनुसार पिक्चर फ्रेम में सम्मिलित करें। 

### **गायब या ब्लॉक किए गए संसाधनों को संभालें**

जब कोई रिसोर्स URI अमान्य, प्रतिबंधित, या हल नहीं किया जा सकता हो, तो `resolveUri` से `null` लौटाएं। जब रिसोर्स पढ़ा नहीं जा सकता, तो `getEntity` से `null` लौटाएं। संभव होने पर Aspose.Slides उस रिसोर्स के बिना SVG प्रोसेसिंग जारी रखता है। 

एक फॉलबैक स्ट्रीम गायब रिसोर्स के लिए लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित रिसोर्स प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल गुम इमेज के लिए इमेज स्ट्रीम लौटाएं, फ़ॉन्ट या स्टाइलशीट के लिए नहीं। 

{{% alert title="Security" color="warning" %}}
अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या अनियमित नेटवर्क URL को हल न करें। अनुमति प्राप्त स्कीम, डायरेक्ट्री और होस्ट को प्रतिबंधित करें। नेटवर्क रिसोर्स के लिए कनेक्शन टाइमआउट, रिस्पॉन्स‑साइज़ लिमिट और कंटेंट वेलिडेशन भी लागू करें। 
{{% /alert %}}

## **SVG को आकारों के सेट में बदलें**

Aspose.Slides SVG को आकारों के सेट में बदल सकता है, जो PowerPoint में समान कार्यक्षमता के बराबर है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [addGroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addgroupshape/) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) क्लास का है और पहला आर्ग्यूमेंट के रूप में एक [SvgImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/svgimage/) ऑब्जेक्ट लेता है। 

निचे दिया गया PHP नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे बदलें:

```php
// स्रोत SVG फ़ाइल नाम।
$svgFileName = "sample.svg";

// आउटपुट प्रस्तुति फ़ाइल नाम।
$outPptxPath = "presentation.pptx";

// नया प्रस्तुति बनाएं।
$presentation = new Presentation();
try {
    // SVG फ़ाइल सामग्री पढ़ें।
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // एक SvgImage ऑब्जेक्ट बनाएं।
    $svgImage = new SvgImage($svgContent);

    // स्लाइड का आकार प्राप्त करें।
    $slideSize = $presentation->getSlideSize()->getSize();

    // SVG छवि को आकारों के समूह में परिवर्तित करें और उसे स्लाइड आकार के अनुसार स्केल करें।
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें।
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **छवियों को EMF के रूप में स्लाइड्स में जोड़ें**

Aspose.Slides for PHP via Java आपको Aspose.Cells के साथ Excel वर्कशीट्स से EMF इमेज जेनरेट करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है। 

निचे दिया गया PHP नमूना कोड दिखाता है कि यह कैसे किया जाए:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// वर्कबुक को स्ट्रीम में सहेजें।
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // फ़ाइल को वैसे ही जोड़ें ताकि चित्र वेक्टर EMF बना रहे और रास्टराइज़ न हो।
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने देता है, जिसमें स्लाइड आकारों द्वारा उपयोग की गई छवियां भी शामिल हैं। यह सेक्शन कलेक्शन में छवियों को अपडेट करने के कई तरीके वर्णित करता है। आप कच्चा बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि का उपयोग करके छवि बदल सकते हैं। 

नीचे दिए गए चरणों का पालन करें:

1. प्रस्तुति फ़ाइल को लोड करें जिसमें छवियां हों, [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का उपयोग करके।
2. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
5. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद छवि से बदलें।
6. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```php
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं।
$presentation = new Presentation("sample.pptx");
try {
    // पहला तरीका।
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // दूसरा तरीका।
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // तीसरा तरीका।
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // प्रस्तुति को फ़ाइल में सहेजें।
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose की मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कन्वर्टर के साथ आप टेक्स्ट को आसानी से एनिमेट कर GIF बना सकते हैं। 
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सम्मिलित करने के बाद मूल छवि का रिज़ॉल्यूशन बरकरार रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम रूप इस बात पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/php-java/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कौन सा संपीड़न लागू किया गया है। 

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति की इमेज कलेक्शन में बदलें—अपडेट उस रिसोर्स का उपयोग करने वाले सभी तत्वों में प्रसारित हो जाएंगे। 

**क्या सम्मिलित SVG को संपादन योग्य आकारों में बदला जा सकता है?**

हाँ। आप SVG को आकारों के समूह में बदल सकते हैं, जिससे व्यक्तिगत भाग मानक शेप प्रॉपर्टीज़ के साथ संपादन योग्य हो जाते हैं। 

**कैसे एक ही चित्र को कई स्लाइड्स की पृष्ठभूमि के रूप में एक साथ सेट किया जा सकता है?**

*[Assign the image as the background](/slides/hi/php-java/presentation-background/)* को मास्टर स्लाइड या संबंधित लेआउट पर सेट करें—वह मास्टर/लेआउट उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में लेगी। 

**बहुत सी छवियों के कारण प्रस्तुति बहुत बड़ी होने से कैसे बचें?**

डुप्लिकेट्स की बजाय एक ही इमेज रिसोर्स का पुन: उपयोग करें, उचित रेज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उचित हो ग्राफिक्स को मास्टर पर रखें।