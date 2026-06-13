---
title: PHP में प्रस्तुति आकारों से छवियों को निकालें
linktitle: आकार से छवि
type: docs
weight: 100
url: /hi/php-java/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि पुनः प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज़, कोड‑फ़्रेंडली समाधान।"
---
## **अवलोकन**

प्रेज़ेंटेशन में छवियां कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ़्रेम के रूप में, आकारों पर लागू चित्र भराव के रूप में, OLE ऑब्जेक्ट प्रीव्यू छवियों के रूप में, वीडियो या ऑडियो फ़्रेम थंबनेल के रूप में, ज़ूम छवियों के रूप में, या तालिका, चार्ट और SmartArt आकारों के भीतर नेस्टेड छवियों के रूप में। Aspose.Slides इन छवियों को प्रेज़ेंटेशन इमेज कलेक्शन में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imagecollection/) और [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट के माध्यम से एक्सपोज़ किया जाता है।

यदि आपको केवल प्रेज़ेंटेशन में एंबेडेड प्रत्येक छवि संसाधन को एक्सपोर्ट करने की आवश्यकता है, तो `presentation->getImages()` के माध्यम से इटरेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइड्स पर छवियों के उपयोग स्थानों को खोजने के लिए आकारों को ट्रैवर्स करना, ताकि सहेजी गई फ़ाइलें उपयोगी संदर्भ जैसे स्लाइड नंबर, आकार की स्थिति और स्रोत प्रकार (picture frame, fill image, media preview, OLE preview, या zoom image) को बनाए रख सकें।

{{% alert title="सुझाव" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) और उसकी `getBinaryData()` मेथड का उपयोग करके मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को संरक्षित रखें। जब आप आउटपुट को किसी विशिष्ट फ़ॉर्मेट जैसे PNG में सामान्य करना चाहते हैं, तो `getImage()` का उपयोग करें।
{{% /alert %}}

## **साझा सहायक विधियाँ**

हेल्पर मेथड्स नीचे उदाहरणों को छोटा रखती हैं। `saveOriginalImage` मूल एम्बेडेड बाइट्स को लिखती है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनती है, और SHA-256 हैश द्वारा डुप्लिकेट इमेज बाइनरीज़ को छोड़ देती है।

```php
use aspose\slides\FillType;
use aspose\slides\ImageFormat;

class ShapeReference
{
    public $shape;
    public $namePart;

    public function __construct($shape, $namePart)
    {
        $this->shape = $shape;
        $this->namePart = $namePart;
    }
}

function isNullJava($value)
{
    return $value == null || java_is_null($value);
}

function saveOriginalImage($image, $outputDirectory, $fileNameBase, &$savedImageHashes)
{
    if (isNullJava($image)) {
        return false;
    }

    $imageData = $image->getBinaryData();
    $imageBytes = getBinaryString($imageData);
    $imageHash = hash("sha256", $imageBytes);
    if (isset($savedImageHashes[$imageHash])) {
        return false;
    }

    $savedImageHashes[$imageHash] = true;

    $extension = getExtensionFromContentType($image->getContentType());
    $fileName = $fileNameBase . "." . $extension;
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;
    file_put_contents($outputPath, $imageBytes);
    return true;
}

function saveImageAsPng($image, $outputDirectory, $fileNameBase)
{
    if (isNullJava($image)) {
        return false;
    }

    $fileName = $fileNameBase . ".png";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $fileName;

    $outputImage = $image->getImage();
    try {
        $outputImage->save($outputPath, ImageFormat::Png);
    } finally {
        if (!isNullJava($outputImage)) {
            $outputImage->dispose();
        }
    }

    return true;
}

function getPictureFillImage($fillFormat)
{
    if (isNullJava($fillFormat) || java_values($fillFormat->getFillType()) != FillType::Picture) {
        return null;
    }

    return $fillFormat->getPictureFillFormat()->getPicture()->getImage();
}

function enumerateShapes($shapes, $prefix, $includeGroupedShapes)
{
    $shapeReferences = [];
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $displayIndex = $shapeIndex + 1;
        $shapeNamePart = $prefix . "_shape_" . $displayIndex;
        $shapeReferences[] = new ShapeReference($shape, $shapeNamePart);

        if ($includeGroupedShapes && java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
            $childShapes = $shape->getShapes();
            $childReferences = enumerateShapes(
                $childShapes,
                $shapeNamePart,
                $includeGroupedShapes
            );
            $shapeReferences = array_merge($shapeReferences, $childReferences);
        }
    }

    return $shapeReferences;
}

function getBinaryString($binaryData)
{
    $bytes = java_values($binaryData);
    if (is_string($bytes)) {
        return $bytes;
    }

    $binaryString = "";
    foreach ($bytes as $byte) {
        $binaryString .= chr($byte & 0xff);
    }

    return $binaryString;
}

function getExtensionFromContentType($contentType)
{
    if ($contentType == null || strlen(trim($contentType)) == 0) {
        return "bin";
    }

    $mediaTypeParts = explode(";", $contentType);
    $mediaType = strtolower(trim($mediaTypeParts[0]));
    if ($mediaType == "image/jpeg") {
        return "jpg";
    }

    if ($mediaType == "image/png") {
        return "png";
    }

    if ($mediaType == "image/gif") {
        return "gif";
    }

    if ($mediaType == "image/bmp") {
        return "bmp";
    }

    if ($mediaType == "image/tiff") {
        return "tiff";
    }

    if ($mediaType == "image/x-emf" || $mediaType == "image/emf") {
        return "emf";
    }

    if ($mediaType == "image/x-wmf" || $mediaType == "image/wmf") {
        return "wmf";
    }

    if ($mediaType == "image/svg+xml") {
        return "svg";
    }

    if (strpos($mediaType, "image/") === 0) {
        $extension = substr($mediaType, strlen("image/"));
        return makeSafeFileNamePart($extension);
    }

    return "bin";
}

function makeSafeFileNamePart($value)
{
    return preg_replace("/[^A-Za-z0-9._-]/", "_", $value);
}
```

## **चित्र फ्रेम से छवियों को निकालें**

इस विधि का उपयोग उन चित्रों के लिए करें जो स्वतंत्र ऑब्जेक्ट के रूप में Insert किए गए हैं। एक [PictureFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/pictureframe/) अपने चित्र को `getPictureFormat()->getPicture()->getImage()` में संग्रहीत करता है, जो एक [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट लौटाता है।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "extracted-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $pictureFrame = $shapeReference->shape;
                $image = $pictureFrame->getPictureFormat()->getPicture()->getImage();
                saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **चित्र-भरित आकार से छवियों को निकालें**

आकार एक चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार की जाँच करें: यदि यह [FillType.Picture](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिए कोई चित्र नहीं है। नीचे का उदाहरण [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) ऑब्जेक्ट्स को संभालता है और प्रत्येक छवि को PNG के रूप में [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) और उसकी `getImage()` मेथड के माध्यम से सहेजता है।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "shape-fill-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shapeReference->shape;
                $fillFormat = $autoShape->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    saveImageAsPng($image, $outputDirectory, $shapeReference->namePart);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) में एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह छवि `getSubstitutePictureFormat()->getPicture()->getImage()` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "ole-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $oleObjectFrame = $shapeReference->shape;
                $image = $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_ole_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) भी `getPictureFormat()->getPicture()->getImage()` में एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ्रेम।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "video-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shapeReference->shape;
                $image = $videoFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_video_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [AudioFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/) `getPictureFormat()->getPicture()->getImage()` में एक थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाई गई छवि है।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "audio-preview-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $audioFrame = $shapeReference->shape;
                $image = $audioFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_audio_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[ZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/zoomframe/) और [SectionZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/sectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "zoom-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.ZoomFrame"))) {
                $zoomFrame = $shapeReference->shape;
                $image = $zoomFrame->getZoomImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_zoom";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    continue;
                }
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SectionZoomFrame"))) {
                $sectionZoomFrame = $shapeReference->shape;
                $image = $sectionZoomFrame->getZoomImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_section_zoom";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    continue;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **समरी ज़ूम फ्रेम्स से छवियों को निकालें**

एक [SummaryZoomFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/summaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक समरी ज़ूम सेक्शन की `getZoomImage()` मेथड के माध्यम से उपलब्ध होते हैं।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "summary-zoom-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, false);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SummaryZoomFrame"))) {
                $summaryZoomFrame = $shapeReference->shape;
                $summaryZoomCollection = $summaryZoomFrame->getSummaryZoomCollection();
                $sectionCount = java_values($summaryZoomCollection->size());
                for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
                    $summaryZoomSection = $summaryZoomCollection->get_Item($sectionIndex);
                    $image = $summaryZoomSection->getZoomImage();
                    if (!isNullJava($image)) {
                        $displayIndex = $sectionIndex + 1;
                        $fileNameBase = $shapeReference->namePart . "_summary_zoom_" . $displayIndex;
                        saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **टेबल आकारों से छवियों को निकालें**

एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) एक आकार है। तालिका में छवियां आमतौर पर तालिका कोशिकाओं में चित्र भराव के रूप में संग्रहीत होती हैं।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "table-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.Table"))) {
                $table = $shapeReference->shape;
                $rowCount = java_values($table->getRows()->size());
                $columnCount = java_values($table->getColumns()->size());
                for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++) {
                    for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++) {
                        $cell = $table->get_Item($columnIndex, $rowIndex);
                        $fillFormat = $cell->getCellFormat()->getFillFormat();
                        $image = getPictureFillImage($fillFormat);
                        if (!isNullJava($image)) {
                            $displayRow = $rowIndex + 1;
                            $displayColumn = $columnIndex + 1;
                            $fileNameBase = $shapeReference->namePart . "_cell_" . $displayRow . "_" . $displayColumn;
                            saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **चार्ट आकारों से छवियों को निकालें**

एक [Chart](https://reference.aspose.com/slides/hi/php-java/aspose.slides/chart/) एक आकार है। नीचे दिया गया उदाहरण चार्ट क्षेत्र के चित्र भराव से एक छवि निकालता है।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "chart-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.Chart"))) {
                $chart = $shapeReference->shape;
                $fillFormat = $chart->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_chart_area";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt आकारों से छवियों को निकालें**

एक [SmartArt](https://reference.aspose.com/slides/hi/php-java/aspose.slides/smartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के आधार पर, छवियां नोड बुलेट भराव में या नोड आकारों के भराव फ़ॉर्मेट में संग्रहीत हो सकती हैं।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "smartart-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $smartArt = $shapeReference->shape;
                $allNodes = $smartArt->getAllNodes();
                $nodeCount = java_values($allNodes->size());
                for ($nodeIndex = 0; $nodeIndex < $nodeCount; $nodeIndex++) {
                    $node = $allNodes->get_Item($nodeIndex);
                    $bulletFillFormat = $node->getBulletFillFormat();
                    $bulletImage = getPictureFillImage($bulletFillFormat);
                    if (!isNullJava($bulletImage)) {
                        $displayNode = $nodeIndex + 1;
                        $fileNameBase = $shapeReference->namePart . "_smartart_node_" . $displayNode . "_bullet";
                        saveOriginalImage($bulletImage, $outputDirectory, $fileNameBase, $savedImageHashes);
                    }

                    $nodeShapes = $node->getShapes();
                    $nodeShapeCount = java_values($nodeShapes->size());
                    for ($nodeShapeIndex = 0; $nodeShapeIndex < $nodeShapeCount; $nodeShapeIndex++) {
                        $nodeShape = $nodeShapes->get_Item($nodeShapeIndex);
                        $fillFormat = $nodeShape->getFillFormat();
                        $image = getPictureFillImage($fillFormat);
                        if (!isNullJava($image)) {
                            $displayNode = $nodeIndex + 1;
                            $displayNodeShape = $nodeShapeIndex + 1;
                            $fileNameBase = $shapeReference->namePart . "_smartart_node_" . $displayNode . "_shape_" . $displayNodeShape;
                            saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **ग्रुपेड आकारों के भीतर छवियों को शामिल करें**

ग्रुपेड आकारों में अपनी स्वयं की आकार संग्रह होते हैं। साझा `enumerateShapes` हेल्पर में `includeGroupedShapes` विकल्प होता है। जब आप [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/) ऑब्जेक्ट्स के भीतर आकारों की जाँच करना चाहते हैं तो इसे `true` सेट करें। नीचे दिया गया उदाहरण चित्र फ्रेम, चित्र-भरित आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल और ऑडियो फ्रेम थंबनेल से छवियां निकालता है। तालिका, चार्ट, SmartArt और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले अनुभागों से विशेष निकासी लॉजिक को पुन: उपयोग करें जबकि समान पुनरावर्ती आकार ट्रैवर्सल रखें।

```php
use aspose\slides\Presentation;

$inputPath = "sample.pptx";
$outputDirectory = getcwd() . DIRECTORY_SEPARATOR . "all-shape-images";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$savedImageHashes = [];

$presentation = new Presentation($inputPath);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $slidePrefix = "slide_" . $slideNumber;
        $shapes = $slide->getShapes();
        $shapeReferences = enumerateShapes($shapes, $slidePrefix, true);
        foreach ($shapeReferences as $shapeReference) {
            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $oleObjectFrame = $shapeReference->shape;
                $image = $oleObjectFrame->getSubstitutePictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_ole_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shapeReference->shape;
                $image = $videoFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_video_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $audioFrame = $shapeReference->shape;
                $image = $audioFrame->getPictureFormat()->getPicture()->getImage();
                if (!isNullJava($image)) {
                    $fileNameBase = $shapeReference->namePart . "_audio_preview";
                    saveOriginalImage($image, $outputDirectory, $fileNameBase, $savedImageHashes);
                }

                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $pictureFrame = $shapeReference->shape;
                $image = $pictureFrame->getPictureFormat()->getPicture()->getImage();
                saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
                continue;
            }

            if (java_instanceof($shapeReference->shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shapeReference->shape;
                $fillFormat = $autoShape->getFillFormat();
                $image = getPictureFillImage($fillFormat);
                if (!isNullJava($image)) {
                    saveOriginalImage($image, $outputDirectory, $shapeReference->namePart, $savedImageHashes);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियां:** कई आकार एक ही छवि या समान बाइट्स वाली अलग छवियों को संदर्भित कर सकते हैं। यदि आप प्रत्येक अनूठी छवि के लिए एक आउटपुट फ़ाइल चाहते हैं, तो फ़ाइल लिखने से पहले `getBinaryData()` से [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) डेटा का हैश बनाएं।
- **मूल डेटा बनाम परिवर्तित आउटपुट:** `getBinaryData()` से [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) डेटा सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। `getImage()` द्वारा लौटाई गई छवि को सहेजना उपयोगी होता है जब आप एक सुसंगत आउटपुट फ़ॉर्मेट चाहते हैं।
- **असमर्थित भराव प्रकार:** ठोस, ग्रेडिएंट, पैटर्न और नो-फ़िल आकार में चित्र भराव नहीं होता है। `getPictureFillFormat()` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/filltype/) की जाँच करें।
- **ग्रुपेड आकार:** टॉप-लेवल स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता है। जब ग्रुपेड सामग्री महत्वपूर्ण हो, तो `getShapes()` के माध्यम से [GroupShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/groupshape/) सामग्री को पुनरावर्ती रूप से जांचें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) `getSubstitutePictureFormat()` के माध्यम से प्रीव्यू छवि दिखा सकता है, लेकिन वह छवि केवल स्लाइड प्रीव्यू है। यह OLE ऑब्जेक्ट के अंदर एम्बेडेड फ़ाइल नहीं है।
- **वीडियो फ्रेम थंबनेल:** एक [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) `getPictureFormat()` के माध्यम से प्रीव्यू छवि दिखा सकता है, लेकिन वह छवि केवल स्लाइड पर दिखाया गया पोस्टर है। यह वीडियो स्ट्रीम से निकाली नहीं गई है।
- **ऑडियो फ्रेम थंबनेल:** एक [AudioFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/audioframe/) `getPictureFormat()` के माध्यम से आइकन या थंबनेल दिखा सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियां:** स्लाइड ज़ूम, सेक्शन ज़ूम, और समरी ज़ूम आकार कस्टम [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट्स का उपयोग `getZoomImage()` के माध्यम से कर सकते हैं।
- **नेस्टेड आकार मॉडल:** टेबल, चार्ट, और SmartArt ऑब्जेक्ट्स [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) को लागू करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड टेबल सेल, चार्ट तत्व, या SmartArt नोड फ़ॉर्मेटिंग ऑब्जेक्ट्स में संग्रहीत होती हैं।
- **कटे या बदलते चित्र:** [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) तक पहुँचने से आपको संग्रहीत चित्र संसाधन मिलता है। यह आकार द्वारा लागू किए गए क्रॉपिंग, ट्रांसपरेंसी, रीकलरिंग, रोटेशन, या अन्य दृश्य प्रभावों को रेंडर नहीं करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मूल छवि को बिना क्रॉपिंग, इफेक्ट्स या आकार परिवर्तनों के निकाल सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) ऑब्जेक्ट तक पहुँचें और `getBinaryData()` से डेटा को डिस्क पर लिखें। यह प्रेज़ेंटेशन में संग्रहीत मूल एन्कोडेड छवि को संरक्षित रखता है, न कि स्लाइड पर छवि के रेंडर होने के तरीके को।

**क्या मैं प्रत्येक निकाली गई छवि को PNG के रूप में एक्सपोर्ट कर सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) और उसकी `getImage()` मेथड का उपयोग करें, और फिर [ImageFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/imageformat/) के साथ `save()` कॉल करें। यह आउटपुट को कन्वर्ट करता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं रख सकता।

**मैं एक ही छवि को एक से अधिक बार सहेजने से कैसे बचूँ?**

`getBinaryData()` से [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) डेटा का हैश उपयोग करें और हैश को एक सेट में रखें। यदि किसी नई छवि का हैश पहले से मौजूद है, तो उसे छोड़ दें या मौजूदा आउटपुट फ़ाइल के लिए एक और संदर्भ दर्ज करें।

**कुछ आकार छवि क्यों नहीं बनाते?**

चित्र फ्रेम, चित्र-भरित आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, टेबल, चार्ट, और SmartArt ऑब्जेक्ट्स छवियों को संदर्भित कर सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मेटिंग ऑब्जेक्ट्स के माध्यम से छवियां दिखाते हैं, इसलिए केवल `getPictureFormat()` या आकार का `getFillFormat()` जांच पर्याप्त नहीं हो सकता।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [VideoFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/videoframe/) का उपयोग करें और `getPictureFormat()->getPicture()->getImage()` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, न कि वीडियो फ़ाइल से उत्पन्न फ्रेम।

**मैं कैसे पता लगा सकता हूँ कि कौन से आकार प्रेज़ेंटेशन इमेज कलेक्शन की विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides [PPImage](https://reference.aspose.com/slides/hi/php-java/aspose.slides/ppimage/) से आकारों तक रिवर्स लिंक को संग्रहीत नहीं करता है। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी छवि रेफ़रेंस को पाते हैं, स्लाइड नंबर, आकार पथ, और छवि हैश या कलेक्शन आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट्स के अंदर एम्बेडेड छवियों, जैसे संलग्न दस्तावेज़ों, को निकाल सकता हूँ?**

आप [OleObjectFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/oleobjectframe/) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के भीतर छवियों को निकालने के लिए, OLE डेटा निकालें और उस फ़ाइल प्रकार के टूल्स से उसकी जाँच करें।