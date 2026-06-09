---
title: Εξαγωγή εικόνων από σχήματα παρουσίασης σε Node.js
linktitle: Εικόνα από σχήμα
type: docs
weight: 100
url: /el/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- εξαγωγή εικόνας
- ανάκτηση εικόνας
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξαγωγή εικόνων από σχήματα σε παρουσιάσεις PowerPoint και OpenDocument με το Aspose.Slides για Node.js μέσω Java - γρήγορη, φιλική προς τον κώδικα λύση."
---
## **Επισκόπηση**

Οι εικόνες σε μια παρουσίαση μπορούν να εμφανιστούν σε διάφορους τύπους σχήματος: ως κανονικά πλαίσια εικόνας, ως γεμίσματα εικόνας που εφαρμόζονται σε σχήματα, ως εικόνες προεπισκόπησης αντικειμένου OLE, ως μικρογραφίες βίντεο ή ήχου, ως εικόνες μεγέθυνσης ή ως εικόνες ενσωματωμένες μέσα σε πίνακες, διαγράμματα και σχήματα SmartArt. Το Aspose.Slides αποθηκεύει αυτές τις εικόνες στη συλλογή εικόνων της παρουσίασης, προσβάσιμη μέσω των αντικειμένων [ImageCollection](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imagecollection/) και [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).

Αν χρειάζεστε μόνο την εξαγωγή κάθε πόρου εικόνας που είναι ενσωματωμένος σε μια παρουσίαση, επαναλάβετε το `presentation.getImages()`. Αυτό το άρθρο εστιάζει σε διαφορετικό έργο: τη διαπέραση των σχημάτων για να βρεθεί πού χρησιμοποιούνται οι εικόνες στις διαφάνειες, ώστε τα αποθηκευμένα αρχεία να διατηρούν χρήσιμο πλαίσιο όπως ο αριθμός της διαφάνειας, η θέση του σχήματος και ο τύπος προέλευσης (πλαίσιο εικόνας, γεμάτη εικόνα, προεπισκόπηση πολυμέσων, προεπισκόπηση OLE ή εικόνα μεγέθυνσης).

{{% alert title="Συμβουλή" color="primary" %}}
Χρησιμοποιήστε το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) και τη μέθοδο `getBinaryData()` για να διατηρήσετε τα αρχικά κωδικοποιημένα δεδομένα της εικόνας και τον τύπο αρχείου. Χρησιμοποιήστε το `getImage()` όταν θέλετε να ομαλοποιήσετε την έξοδο σε συγκεκριμένο μορφότυπο όπως PNG.
{{% /alert %}}

## **Κοινές Βοηθητικές Μεθόδους**

Οι παρακάτω βοηθητικές μέθοδοι κρατούν τα παραδείγματα σύντομα. Η `saveOriginalImage` γράφει τα αρχικά ενσωματωμένα byte, επιλέγει ασφαλή επέκταση από τον τύπο MIME και παραλείπει διπλότυπα δυαδικά δεδομένα εικόνας με βάση το SHA‑256 hash.

```javascript
const fileSystem = require("fs");
const pathModule = require("path");
const cryptoModule = require("crypto");
const asposeSlides = require("aspose.slides.via.java");

class ShapeReference {
    constructor(shape, namePart) {
        this.shape = shape;
        this.namePart = namePart;
    }
}

function saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes) {
    const imageData = image.getBinaryData();
    const imageBuffer = Buffer.from(imageData);
    const imageHash = getSha256Hash(imageBuffer);
    if (savedImageHashes.has(imageHash)) {
        return false;
    }

    savedImageHashes.add(imageHash);

    const extension = getExtensionFromContentType(image.getContentType());
    const fileName = `${fileNameBase}.${extension}`;
    const outputPath = pathModule.join(outputDirectory, fileName);
    fileSystem.writeFileSync(outputPath, imageBuffer);
    return true;
}

function saveImageAsPng(image, outputDirectory, fileNameBase) {
    const fileName = `${fileNameBase}.png`;
    const outputPath = pathModule.join(outputDirectory, fileName);

    const outputImage = image.getImage();
    try {
        outputImage.save(outputPath, asposeSlides.ImageFormat.Png);
    } finally {
        if (outputImage !== null) {
            outputImage.dispose();
        }
    }
}

function getPictureFillImage(fillFormat) {
    if (fillFormat == null || fillFormat.getFillType() !== asposeSlides.FillType.Picture) {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

function enumerateShapes(shapes, prefix, includeGroupedShapes) {
    const shapeReferences = [];
    const shapeCount = shapes.size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        const displayIndex = shapeIndex + 1;
        const shapeNamePart = `${prefix}_shape_${displayIndex}`;
        const shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.push(shapeReference);

        if (includeGroupedShapes && java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            const childShapes = shape.getShapes();
            const childReferences = enumerateShapes(childShapes, shapeNamePart, includeGroupedShapes);
            shapeReferences.push(...childReferences);
        }
    }

    return shapeReferences;
}

function getSha256Hash(data) {
    return cryptoModule.createHash("sha256").update(data).digest("hex");
}

function getExtensionFromContentType(contentType) {
    if (contentType == null || contentType.trim().length === 0) {
        return "bin";
    }

    const mediaType = contentType.split(";")[0].trim().toLowerCase();
    if (mediaType === "image/jpeg") {
        return "jpg";
    }

    if (mediaType === "image/png") {
        return "png";
    }

    if (mediaType === "image/gif") {
        return "gif";
    }

    if (mediaType === "image/bmp") {
        return "bmp";
    }

    if (mediaType === "image/tiff") {
        return "tiff";
    }

    if (mediaType === "image/x-emf" || mediaType === "image/emf") {
        return "emf";
    }

    if (mediaType === "image/x-wmf" || mediaType === "image/wmf") {
        return "wmf";
    }

    if (mediaType === "image/svg+xml") {
        return "svg";
    }

    if (mediaType.startsWith("image/")) {
        const extension = mediaType.substring("image/".length);
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

function makeSafeFileNamePart(value) {
    return value.replace(/[^A-Za-z0-9._-]/g, "_");
}
```

## **Εξαγωγή Εικόνων από Πλαισίων Εικόνας**

Χρησιμοποιήστε αυτή την προσέγγιση για εικόνες που έχουν εισαχθεί ως αυτόνομα αντικείμενα. Ένα [PictureFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/pictureframe/) αποθηκεύει την εικόνα του στο `getPictureFormat().getPicture().getImage()`, το οποίο επιστρέφει ένα αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/).

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "extracted-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.PictureFrame")) {
                const pictureFrame = shapeReference.shape;
                const image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα με Γέμισμα Εικόνας**

Τα σχήματα μπορούν να χρησιμοποιούν μια εικόνα ως γέμισμα. Ελέγξτε πρώτα τον τύπο γεμίσματος του σχήματος: εάν δεν είναι [FillType.Picture](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/), δεν υπάρχει εικόνα για εξαγωγή από αυτό το γέμισμα. Το παρακάτω παράδειγμα διαχειρίζεται αντικείμενα [AutoShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/autoshape/) και αποθηκεύει κάθε εικόνα ως PNG μέσω του [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) και της μεθόδου `getImage()`.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "shape-fill-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AutoShape")) {
                const autoShape = shapeReference.shape;
                const fillFormat = autoShape.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Αντικειμένων OLE**

Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) μπορεί να έχει αντικαταστατική εικόνα που το PowerPoint χρησιμοποιεί ως προεπισκόπηση του αντικειμένου στη διαφάνεια. Η εικόνα αυτή είναι διαθέσιμη μέσω του `getSubstitutePictureFormat().getPicture().getImage()`. Η εξαγωγή αυτής της εικόνας σας δίνει την προεπισκόπηση, όχι το ενσωματωμένο περιεχόμενο του πακέτου OLE.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "ole-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.OleObjectFrame")) {
                const oleObjectFrame = shapeReference.shape;
                const image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_ole_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Βίντεο**

Ένα [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) μπορεί επίσης να αποθηκεύσει μια εικόνα προεπισκόπησης στο `getPictureFormat().getPicture().getImage()`. Πρόκειται για το αφίσα ή τη μικρογραφία που εμφανίζεται στη διαφάνεια, όχι για καρέ που έχουν αποκωδικοποιηθεί από τη ροή βίντεο.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "video-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shapeReference.shape;
                const image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_video_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων Προεπισκόπησης από Πλαίσια Ήχου**

Ένα [AudioFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/) μπορεί να αποθηκεύσει μια μικρογραφία στο `getPictureFormat().getPicture().getImage()`. Αυτή είναι η εικόνα που εμφανίζεται για το αντικείμενο ήχου στη διαφάνεια.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "audio-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AudioFrame")) {
                const audioFrame = shapeReference.shape;
                const image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_audio_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Αντικείμενα Zoom**

Τα σχήματα [ZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/zoomframe/) και [SectionZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sectionzoomframe/) μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες. Διαβάστε το `getZoomImage()` από το πλαίσιο ζουμ.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "zoom-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.ZoomFrame")) {
                const zoomFrame = shapeReference.shape;
                const image = zoomFrame.getZoomImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_zoom`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SectionZoomFrame")) {
                const sectionZoomFrame = shapeReference.shape;
                const image = sectionZoomFrame.getZoomImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_section_zoom`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Πλαίσια Σύνοψης Zoom**

Ένα [SummaryZoomFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/summaryzoomframe/) είναι επίσης σχήμα. Τα στοιχεία της ενότητας μπορούν να χρησιμοποιούν προσαρμοσμένες εικόνες, εκτεθειμένες μέσω της μεθόδου `getZoomImage()` του κάθε τμήματος σύνοψης ζουμ.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "summary-zoom-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SummaryZoomFrame")) {
                const summaryZoomFrame = shapeReference.shape;
                const summaryZoomCollection = summaryZoomFrame.getSummaryZoomCollection();
                const sectionCount = summaryZoomCollection.size();
                for (let sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++) {
                    const summaryZoomSection = summaryZoomCollection.get_Item(sectionIndex);
                    const image = summaryZoomSection.getZoomImage();
                    if (image !== null) {
                        const displayIndex = sectionIndex + 1;
                        const fileNameBase = `${shapeReference.namePart}_summary_zoom_${displayIndex}`;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα Πίνακα**

Ένα [Table](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/table/) είναι σχήμα. Οι εικόνες σε έναν πίνακα αποθηκεύονται συνήθως ως γεμίσματα εικόνας σε κελιά του πίνακα.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "table-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.Table")) {
                const table = shapeReference.shape;
                const rowCount = table.getRows().size();
                const columnCount = table.getColumns().size();
                for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
                    for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
                        const cell = table.get_Item(columnIndex, rowIndex);
                        const fillFormat = cell.getCellFormat().getFillFormat();
                        const image = getPictureFillImage(fillFormat);
                        if (image !== null) {
                            const displayRow = rowIndex + 1;
                            const displayColumn = columnIndex + 1;
                            const fileNameBase = `${shapeReference.namePart}_cell_${displayRow}_${displayColumn}`;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα Διαγράμματος**

Ένα [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/) είναι σχήμα. Το παρακάτω παράδειγμα εξάγει μια εικόνα από το γέμισμα εικόνας της περιοχής του διαγράμματος.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "chart-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.Chart")) {
                const chart = shapeReference.shape;
                const fillFormat = chart.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_chart_area`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Εξαγωγή Εικόνων από Σχήματα SmartArt**

Ένα αντικείμενο [SmartArt](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartart/) είναι σχήμα. Ανάλογα με τη διάταξη του SmartArt, οι εικόνες μπορεί να αποθηκευτούν σε γεμίσματα κόμβων ή στα μορφοποιημένα γεμίσματα των σχημάτων των κόμβων.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "smartart-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SmartArt")) {
                const smartArt = shapeReference.shape;
                const allNodes = smartArt.getAllNodes();
                const nodeCount = allNodes.size();
                for (let nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++) {
                    const node = allNodes.get_Item(nodeIndex);
                    const bulletFillFormat = node.getBulletFillFormat();
                    const bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage !== null) {
                        const displayNode = nodeIndex + 1;
                        const fileNameBase = `${shapeReference.namePart}_smartart_node_${displayNode}_bullet`;
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    const nodeShapes = node.getShapes();
                    const nodeShapeCount = nodeShapes.size();
                    for (let nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++) {
                        const nodeShape = nodeShapes.get_Item(nodeShapeIndex);
                        const fillFormat = nodeShape.getFillFormat();
                        const image = getPictureFillImage(fillFormat);
                        if (image !== null) {
                            const displayNode = nodeIndex + 1;
                            const displayNodeShape = nodeShapeIndex + 1;
                            const fileNameBase = `${shapeReference.namePart}_smartart_node_${displayNode}_shape_${displayNodeShape}`;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Συμπερίληψη Εικόνων μέσα σε Ομαδοποιημένα Σχήματα**

Τα ομαδοποιημένα σχήματα περιέχουν τις δικές τους συλλογές σχημάτων. Η κοινή βοηθητική μέθοδος `enumerateShapes` έχει επιλογή `includeGroupedShapes`. Ορίστε την σε `true` όταν θέλετε να επιθεωρήσετε σχήματα μέσα σε αντικείμενα [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/). Το παρακάτω παράδειγμα εξάγει εικόνες από πλαίσια εικόνας, σχήματα γεμισμένα με εικόνα, προεπισκοπήσεις αντικειμένων OLE, μικρογραφίες πλαισίων βίντεο και μικρογραφίες πλαισίων ήχου. Για να συμπεριλάβετε επίσης εικόνες πινάκων, διαγραμμάτων, SmartArt και σύνοψης ζουμ, επαναχρησιμοποιήστε τη εξειδικευμένη λογική εξαγωγής από τις προηγούμενες ενότητες διατηρώντας την ίδια αναδρομική διάσχιση σχημάτων.

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "all-shape-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.OleObjectFrame")) {
                const oleObjectFrame = shapeReference.shape;
                const image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_ole_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shapeReference.shape;
                const image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_video_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AudioFrame")) {
                const audioFrame = shapeReference.shape;
                const image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_audio_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.PictureFrame")) {
                const pictureFrame = shapeReference.shape;
                const image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AutoShape")) {
                const autoShape = shapeReference.shape;
                const fillFormat = autoShape.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **Περιπτώσεις Άκρων και Πρακτικές Σημειώσεις**

- **Διπλές εικόνες:** Πολλά σχήματα μπορεί να αναφέρονται στην ίδια εικόνα ή σε ξεχωριστές εικόνες με τα ίδια byte. Κάντε hash των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) από το `getBinaryData()` πριν γράψετε αρχεία αν θέλετε ένα αρχείο εξόδου ανά μοναδική εικόνα.
- **Αρχικά δεδομένα vs. μετατρεπόμενη έξοδος:** Η αποθήκευση των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) από το `getBinaryData()` διατηρεί τα ενσωματωμένα JPEG, PNG, GIF, SVG, EMF ή WMF. Η αποθήκευση της εικόνας που επιστρέφει το `getImage()` είναι χρήσιμη όταν θέλετε ένα συνεπές μορφότυπο εξόδου.
- **Μη υποστηριζόμενοι τύποι γεμίσματος:** Σχήματα γεμάτα με μονόχρωμο, διαβάθμιση, μοτίβο ή χωρίς γέμισμα δεν περιέχουν εικόνα γεμίσματος. Ελέγξτε το [FillType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/filltype/) πριν διαβάσετε το `getPictureFillFormat()`.
- **Ομαδοποιημένα σχήματα:** Η συλλογή σχημάτων της διαφάνειας στο ανώτερο επίπεδο δεν επίπεδωση των ομάδων. Διερευνήστε αναδρομικά το περιεχόμενο του [GroupShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/groupshape/) μέσω του `getShapes()` όταν η ομαδοποιημένη ύλη έχει σημασία.
- **Προεπισκοπήσεις αντικειμένων OLE:** Ένα [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/) μπορεί να εκθέτει μια εικόνα προεπισκόπησης μέσω του `getSubstitutePictureFormat()`, αλλά αυτή είναι μόνο η προεπισκόπηση της διαφάνειας. Δεν είναι το ενσωματωμένο αρχείο μέσα στο αντικείμενο OLE.
- **Μικρογραφίες πλαισίων βίντεο:** Ένα [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) μπορεί να εκθέτει μια εικόνα προεπισκόπησης μέσω του `getPictureFormat()`, αλλά αυτή είναι μόνο η αφίσα που εμφανίζεται στη διαφάνεια. Δεν εξάγεται από τη ροή βίντεο.
- **Μικρογραφίες πλαισίων ήχου:** Ένα [AudioFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/audioframe/) μπορεί να εκθέτει ένα εικονίδιο ή μικρογραφία μέσω του `getPictureFormat()`· δεν είναι τα ενσωματωμένα δεδομένα ήχου.
- **Εικόνες ζουμ:** Τα σχήματα ζουμ διαφάνειας, ζουμ ενοτήτων και ζουμ σύνοψης μπορεί να χρησιμοποιούν προσαρμοσμένα αντικείμενα [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) μέσω του `getZoomImage()`.
- **Στοιχεία ενσωματωμένων σχημάτων:** Τα αντικείμενα πίνακα, διαγράμματος και SmartArt υλοποιούν το [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/), αλλά οι εικόνες τους συχνά αποθηκεύονται σε ενσωματωμένα αντικείμενα μορφοποίησης κελιών πίνακα, στοιχείων διαγράμματος ή κόμβων SmartArt.
- **Περικομμένες ή μετασχηματισμένες εικόνες:** Η πρόσβαση στο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) σας δίνει τον αποθηκευμένο πόρο εικόνας. Δεν αποδίδει την περικοπή, διαφάνεια, επαναχρωματισμό, περιστροφή ή άλλα οπτικά εφέ που εφαρμόζει το σχήμα.

## **Συχνές Ερωτήσεις**

**Μπορώ να εξάγω την αρχική εικόνα χωρίς περικοπή, εφέ ή μετασχηματισμούς σχήματος;**

Ναι. Πρόσβαση στο αντικείμενο [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) και εγγραφή των δεδομένων από το `getBinaryData()` στο δίσκο. Αυτό διατηρεί την αρχική κωδικοποιημένη εικόνα που είναι αποθηκευμένη στην παρουσίαση, όχι τον τρόπο με τον οποίο αποδίδεται στη διαφάνεια.

**Μπορώ να εξάγω κάθε εξαγόμενη εικόνα ως PNG;**

Ναι. Χρησιμοποιήστε το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) και τη μέθοδό του `getImage()`, και στη συνέχεια καλέστε `save()` με το [ImageFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/imageformat/). Αυτό μετατρέπει την έξοδο και μπορεί να μην διατηρεί τον αρχικό τύπο αρχείου ή τα διανυσματικά δεδομένα.

**Πώς αποφεύγω να αποθηκεύω την ίδια εικόνα περισσότερες από μία φορές;**

Χρησιμοποιήστε ένα hash των δεδομένων του [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) από το `getBinaryData()` και διατηρήστε τα hashes σε ένα σύνολο. Αν μια νέα εικόνα έχει hash που ήδη υπάρχει, παραλείψτε την ή καταγράψτε μια άλλη αναφορά προς το υπάρχον αρχείο εξόδου.

**Γιατί ορισμένα σχήματα δεν παράγουν εικόνα;**

Τα πλαίσια εικόνας, τα σχήματα γεμισμένα με εικόνα, τα πλαίσια αντικειμένων OLE, τα πλαίσια πολυμέσων, τα πλαίσια ζουμ, οι πίνακες, τα διαγράμματα και τα αντικείμενα SmartArt μπορούν να αναφέρονται σε εικόνες. Ορισμένοι τύποι σχήματος εκθέτουν εικόνες μέσω ενσωματωμένων αντικειμένων μορφοποίησης, οπότε ένας απλός έλεγχος `getPictureFormat()` ή `getFillFormat()` δεν είναι πάντα επαρκής.

**Μπορώ να εξάγω τη μικρογραφία που εμφανίζεται για ένα πλαίσιο βίντεο;**

Ναι. Χρησιμοποιήστε το [VideoFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/videoframe/) και διαβάστε το `getPictureFormat().getPicture().getImage()`. Αυτό εξάγει την εικόνα αφίσας που αποθηκεύεται με το πλαίσιο βίντεο, όχι ένα καρέ που δημιουργείται από το αρχείο βίντεο.

**Πώς μπορώ να προσδιορίσω ποια σχήματα χρησιμοποιούν μια συγκεκριμένη εικόνα από τη συλλογή εικόνων της παρουσίασης;**

Το Aspose.Slides δεν αποθηκεύει αντίστροφους συνδέσμους από το [PPImage](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/ppimage/) προς τα σχήματα. Κατασκευάστε έναν χάρτη κατά τη διάρκεια της διάσχισης: κάθε φορά που εντοπίζετε μια αναφορά εικόνας, καταγράψτε τον αριθμό διαφάνειας, τη διαδρομή σχήματος και το hash ή το στοιχείο της συλλογής εικόνας.

**Μπορώ να εξάγω εικόνες ενσωματωμένες μέσα σε αντικείμενα OLE, όπως συννημένα έγγραφα;**

Μπορείτε να εξάγετε την προεπισκόπηση διαφάνειας του αντικειμένου OLE από το [OleObjectFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/oleobjectframe/). Ωστόσο, αυτή η προεπισκόπηση δεν είναι το ενσωματωμένο έγγραφο αυτό καθαυτό. Για να εξάγετε εικόνες από το ενσωματωμένο αρχείο, εξάγετε τα δεδομένα OLE και εξετάστε τα με εργαλεία που υποστηρίζουν τον συγκεκριμένο τύπο αρχείου.