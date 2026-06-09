---
title: Εξαγωγή Εικόνων από Σχήματα Παρουσίασης σε PHP
linktitle: Εικόνα από Σχήμα
type: docs
weight: 100
url: /el/php-java/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με Aspose.Slides για PHP μέσω Java - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως απλά πλαίσια εικόνων, ως εικόνες γεμίσματος που εφαρμόζονται σε σχήματα, ως εικόνες προεπισκόπησης αντικειμένων OLE, ως μικρογραφίες βίντεο ή ήχου, ως εικόνες μεγέθυνσης ή ως εικόνες ενσωματωμένες μέσα σε σχήματα πίνακα, διαγράμματος και SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, που εκτίθενται μέσω των αντικειμένων [ImageCollection](https://reference.aspose.com/slides/el/php-java/aspose.slides/imagecollection/) και [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) .

Αν χρειάζεστε μόνο να εξάγετε κάθε ενσωματωμένο πόρο εικόνας σε μια παρουσίαση, επαναλάβετε τη μέθοδο `presentation->getImages()`. Αυτό το άρθρο εστιάζει σε διαφορετικό έργο: τη διέλευση των σχημάτων για να βρεθεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιο πλαίσιο όπως ο αριθμός της διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, εικόνα γεμίσματος, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα μεγέθυνσης).

{{% alert title="Tip" color="primary" %}}
Χρησιμοποιήστε το [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) και τη μέθοδο `getBinaryData()` για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε `getImage()` όταν θέλετε να ομαλοποιήσετε την έξοδο σε συγκεκριμένη μορφή, όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μέθοδοι κρατούν τα παραδείγματα σύντομα. `saveOriginalImage` γράφει τα αρχικά ενσωματωμένα bytes, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας βάσει SHA‑256 hash.

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

## **Εξαγωγή Εικόνων από Πλαίσια Εικόνων**

Χρησιμοποιήστε αυτήν την προσέγγιση για εικόνες που έχουν ενσωματωθεί ως ανεξάρτητα αντικείμενα. Ένα [PictureFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/pictureframe/) αποθηκεύει την εικόνα του στη μέθοδο `getPictureFormat()->getPicture()->getImage()`, η οποία επιστρέφει ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) .

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

## **Εξαγωγή Εικόνων από Σχήματα με Γέμισμα Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: εάν δεν είναι [FillType.Picture](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/), δεν υπάρχει εικόνα για εξαγωγή από αυτό το γέμισμα. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/autoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) και της μεθόδου `getImage()` .

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

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Αντικειμένων OLE**

Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) μπορεί να έχει μια εφεδρική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου σε μια διαφάνεια. Αυτή η εικόνα είναι διαθέσιμη μέσω `getSubstitutePictureFormat()->getPicture()->getImage()`. Η εξαγωγή αυτής της εικόνας σας δίνει την εικόνα προεπισκόπησης, όχι τα ενσωματωμένα περιεχόμενα του πακέτου OLE.

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

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Βίντεο**

Ένα [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) μπορεί επίσης να αποθηκεύει μια εικόνα προεπισκόπησης στο `getPictureFormat()->getPicture()->getImage()`. Αυτή είναι η αφίσα ή μικρογραφία που εμφανίζεται στη διαφάνεια, όχι ένα καρέ αποκωδικοποιημένο από τη ροή του βίντεο.

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

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Ήχου**

Ένα [AudioFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/) μπορεί να αποθηκεύει μια μικρογραφία στο `getPictureFormat()->getPicture()->getImage()`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

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

## **Εξαγωγή Εικόνων από Αντικείμενα Ζουμ**

Τα σχήματα [ZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/zoomframe/) και [SectionZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/sectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `getZoomImage()` από το ζουμ πλαίσιο.

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

## **Εξαγωγή Εικόνων από Πλαίσια Περίληψης Ζουμ**

Ένα [SummaryZoomFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/summaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας του μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, που εκτίθενται μέσω της μεθόδου `getZoomImage()` του κάθε τμήματος περίληψης ζουμ.

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

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένα [Table](https://reference.aspose.com/slides/el/php-java/aspose.slides/table/) είναι σχήμα. Οι εικόνες σε έναν πίνακα αποθηκεύονται συνήθως ως γέμισμα εικόνας στα κελιά του πίνακα.

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

## **Εξαγωγή Εικόνων από Σχήματα Διαγράμματος**

Ένα [Chart](https://reference.aspose.com/slides/el/php-java/aspose.slides/chart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του διαγράμματος.

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

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/php-java/aspose.slides/smartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκεύονται σε γέμισμα κουκκίδας κόμβων ή στα μορφότυπα γεμίσματος των σ shapes του κόμβου.

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

## **Συμπερίληψη Εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική λειτουργία `enumerateShapes` διαθέτει επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να επιθεωρήσετε σχήματα μέσα σε αντικείμενα [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/) . Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνων, σχήματα με γέμισμα εικόνας, προεπισκοπήσεις OLE αντικειμένων, μικρογραφίες πλαισίου βίντεο και μικρογραφίες πλαισίου ήχου. Για να συμπεριλάβετε επίσης εικόνες από πίνακες, διαγράμματα, SmartArt και περίληψη ζουμ, επαναχρησιμοποιήστε την εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική διέλευση σχημάτων.

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

## **Περιπτώσεις Άκρων και Πρακτικές Σημειώσεις**

- **Διπλότυπες εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε διαφορετικές εικόνες με τα ίδια bytes. Δημιουργήστε hash των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) μέσω `getBinaryData()` πριν γράψετε τα αρχεία εάν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα έναντι μετατρεπόμενης εξόδου:** Η αποθήκευση των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) από `getBinaryData()` διατηρεί την αρχική κωδικοποιημένη εικόνα (JPEG, PNG, GIF, SVG, EMF ή WMF). Η αποθήκευση της εικόνας που επιστρέφει `getImage()` είναι χρήσιμη όταν θέλετε συνεπή μορφή εξόδου, όπως PNG.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Τα σχήματα με γέμισμα στερεό, διαβάθμιση, μοτίβο ή χωρίς γέμισμα δεν περιέχουν εικόνα γεμίσματος. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/php-java/aspose.slides/filltype/) πριν διαβάσετε `getPictureFillFormat()`.
- **Ομαδοποιημένα σχήματα:** Η κορυφαία συλλογή σχημάτων της διαφάνειας δεν επίπεδωση των ομάδων. Εξετάστε αναδρομικά το περιεχόμενο του [GroupShape](https://reference.aspose.com/slides/el/php-java/aspose.slides/groupshape/) μέσω `getShapes()` όταν η ομαδοποιημένη ύλη έχει σημασία.
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/) ενδέχεται να εκθέτει μια εικόνα προεπισκόπησης μέσω `getSubstitutePictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίου βίντεο:** Ένα [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) μπορεί να εκθέτει μια εικόνα προεπισκόπησης μέσω `getPictureFormat()`, αλλά αυτή η εικόνα είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή του βίντεο.
- **Μικρογραφίες πλαισίου ήχου:** Ένα [AudioFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/audioframe/) μπορεί να εκθέτει ένα εικονίδιο ή μικρογραφία μέσω `getPictureFormat()`· δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, τμήματος ζουμ και περίληψης ζουμ μπορούν να χρησιμοποιούν προσαρμοσμένα αντικείμενα [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) μέσω `getZoomImage()`.
- **Φωτισμένα μοντέλα σχήματος:** Τα αντικείμενα πίνακα, διαγράμματος και SmartArt υλοποιούν το [Shape](https://reference.aspose.com/slides/el/php-java/aspose.slides/shape/) , αλλά οι εικόνες τους συχνά αποθηκεύονται σε ενσωματωμένα αντικείμενα μορφοποίησης κελιών, στοιχείων διαγράμματος ή κόμβων SmartArt.
- **Κομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) σας δίνει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει περικοπή, διαφάνεια, επαναχρωματισμό, περιστροφή ή άλλες οπτικές επιδράσεις που εφαρμόζει το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξάγω την αρχική εικόνα χωρίς περικοπές, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Προσπελάστε το αντικείμενο [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) και γράψτε τα δεδομένα από `getBinaryData()` στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο που η εικόνα αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) και τη μέθοδο `getImage()`, στη συνέχεια καλέστε `save()` με το [ImageFormat](https://reference.aspose.com/slides/el/php-java/aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρήσει τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς μπορώ να αποφεύγω την αποθήκευση της ίδιας εικόνας περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) από `getBinaryData()` και κρατήστε τα hashes σε ένα σύνολο. Εάν μια νέα εικόνα έχει hash που υπάρχει ήδη, παραλείψτε την ή καταγράψτε μια άλλη αναφορά στο υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα με γέμισμα εικόνας, τα πλαίσια αντικειμένων OLE, τα πολυμέσα, τα πλαίσια ζουμ, οι πίνακες, τα διαγράμματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχήματος εκθέτουν εικόνες μέσω ενσωματωμένων αντικειμένων μορφοποίησης, επομένως ένας απλός έλεγχος `getPictureFormat()` ή `getFillFormat()` δεν είναι πάντα αρκετός.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [VideoFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/videoframe/) και διαβάστε `getPictureFormat()->getPicture()->getImage()`. Αυτό εξάγει την αφίσα που είναι αποθηκευμένη με το πλαίσιο βίντεο, όχι ένα καρέ που δημιουργείται από το αρχείο βίντεο.

**Πώς μπορώ να προσδιορίσω ποιες σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους δεσμούς από το [PPImage](https://reference.aspose.com/slides/el/php-java/aspose.slides/ppimage/) προς τα σχήματα. Κατασκευάστε έναν χάρτη κατά τη διέλευση: κάθε φορά που βρίσκετε μια αναφορά εικόνας, καταγράψτε τον αριθμό της διαφάνειας, τη διαδρομή του σχήματος και το hash ή το στοιχείο της συλλογής εικόνας.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συνημμένα έγγραφα;**

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE από το [OleObjectFrame](https://reference.aspose.com/slides/el/php-java/aspose.slides/oleobjectframe/). Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο. Για να εξάγετε εικόνες από το ενσωματωμένο αρχείο, εξάγετε τα δεδομένα OLE και εξετάστε τα με εργαλεία κατάλληλα για τον τύπο αρχείου.