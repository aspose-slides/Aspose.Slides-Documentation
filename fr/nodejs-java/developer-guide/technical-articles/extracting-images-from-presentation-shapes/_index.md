---
title: Extraire des images des formes d'une présentation en Node.js
linktitle: Image depuis la forme
type: docs
weight: 100
url: /fr/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- extraction d'image
- récupération d'image
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java - solution rapide et adaptée au code."
---
## **Vue d'ensemble**

Les images dans une présentation peuvent apparaître sous plusieurs types de formes : sous forme de cadres d'image ordinaires, sous forme de remplissages d'image appliqués aux formes, sous forme d'images de prévisualisation d'objets OLE, sous forme de vignettes de trames vidéo ou audio, sous forme d'images de zoom, ou sous forme d'images imbriquées dans des formes de tableau, de graphique et de SmartArt. Aspose.Slides stocke ces images dans la collection d'images de la présentation, exposée via les objets [ImageCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imagecollection/) et [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).

Si vous avez seulement besoin d'exporter toutes les ressources d'image intégrées dans une présentation, parcourez `presentation.getImages()`. Cet article se concentre sur une tâche différente : parcourir les formes pour trouver où les images sont utilisées sur les diapositives, afin que les fichiers enregistrés conservent un contexte utile tel que le numéro de la diapositive, la position de la forme et le type source (cadre d'image, image de remplissage, aperçu multimédia, aperçu OLE ou image de zoom).

{{% alert title="Tip" color="primary" %}}
Utilisez [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) et sa méthode `getBinaryData()` pour préserver les données d'image encodées d'origine et le type de fichier. Utilisez `getImage()` lorsque vous souhaitez normaliser la sortie vers un format spécifique tel que PNG.
{{% /alert %}}

## **Méthodes d'assistance partagées**

Les méthodes d'assistance ci‑dessous raccourcissent les exemples. `saveOriginalImage` écrit les octets intégrés d'origine, choisit une extension sûre à partir du type MIME et ignore les binaires d'image en double grâce au hachage SHA‑256.

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

## **Extraire les images des cadres d'image**

Utilisez cette approche pour les images insérées en tant qu'objets autonomes. Un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) stocke son image dans `getPictureFormat().getPicture().getImage()`, ce qui renvoie un objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).

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

## **Extraire les images des formes à remplissage d'image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d'abord le type de remplissage de la forme : s'il n'est pas [FillType.Picture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/), il n'y a pas d'image à extraire de ce remplissage. L'exemple ci‑dessous gère les objets [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) et enregistre chaque image au format PNG via [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) et sa méthode `getImage()`.

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

## **Extraire les images d'aperçu des cadres d'objets OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleobjectframe/) peut avoir une image de substitution que PowerPoint utilise comme aperçu de l'objet sur une diapositive. Cette image est accessible via `getSubstitutePictureFormat().getPicture().getImage()`. Extraire cette image vous donne l'aperçu, pas le contenu du paquet OLE intégré.

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

## **Extraire les images d'aperçu des cadres vidéo**

Un [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) peut également stocker une image d'aperçu dans `getPictureFormat().getPicture().getImage()`. Il s'agit du poster ou de la vignette affichée sur la diapositive, pas d'une image décodée à partir du flux vidéo.

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

## **Extraire les images d'aperçu des cadres audio**

Un [AudioFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/) peut stocker une vignette dans `getPictureFormat().getPicture().getImage()`. Il s'agit de l'image affichée pour l'objet audio sur la diapositive.

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

## **Extraire les images des objets Zoom**

[ZoomFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/zoomframe/) et [SectionZoomFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/sectionzoomframe/) peuvent utiliser des images personnalisées. Lisez `getZoomImage()` depuis le cadre de zoom.

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

## **Extraire les images des cadres de zoom récapitulatif**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/summaryzoomframe/) est également une forme. Les éléments de section peuvent utiliser des images personnalisées, exposées via la méthode `getZoomImage()` de chaque section de zoom récapitulatif.

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

## **Extraire les images des formes de tableau**

Un [Table](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/table/) est une forme. Les images dans un tableau sont généralement stockées comme remplissages d'image dans les cellules du tableau.

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

## **Extraire les images des formes de graphique**

Un [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/) est une forme. L'exemple ci‑dessous extrait une image du remplissage d'image de la zone du graphique.

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

## **Extraire les images des formes SmartArt**

Un objet [SmartArt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/) est une forme. Selon la mise en page du SmartArt, les images peuvent être stockées dans les remplissages de puces des nœuds ou dans les formats de remplissage des formes de nœuds.

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

## **Inclure les images à l'intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. L'assistance partagée `enumerateShapes` possède une option `includeGroupedShapes`. Réglez‑la sur `true` lorsque vous souhaitez inspecter les formes à l'intérieur des objets [GroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/groupshape/) . L'exemple ci‑dessus extrait les images des cadres d'image, des formes à remplissage d'image, des aperçus d'objets OLE, des vignettes de cadres vidéo et des vignettes de cadres audio. Pour inclure également les images de tableau, de graphique, de SmartArt et de zoom récapitulatif, réutilisez la logique d'extraction spécialisée des sections précédentes tout en conservant le même parcours récursif des formes.

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

## **Cas limites et notes pratiques**

- **Images en double :** plusieurs formes peuvent référencer la même image ou des images distinctes avec des octets identiques. Hachez les données [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) via `getBinaryData()` avant d'écrire les fichiers si vous souhaitez un fichier de sortie par image unique.
- **Données d'origine vs. sortie convertie :** enregistrer les données [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) provenant de `getBinaryData()` préserve les données JPEG, PNG, GIF, SVG, EMF ou WMF intégrées. Enregistrer l'image renvoyée par `getImage()` est utile lorsque vous voulez un format de sortie cohérent.
- **Types de remplissage non pris en charge :** les formes solides, en dégradé, à motif et sans remplissage ne contiennent pas de remplissage d'image. Vérifiez [FillType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/filltype/) avant de lire `getPictureFillFormat()`.
- **Formes groupées :** la collection de formes de la diapositive de niveau supérieur ne déplie pas les groupes. Inspectez de manière récursive le contenu [GroupShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/groupshape/) via `getShapes()` lorsque le contenu groupé est important.
- **Aperçus d'objets OLE :** un [OleObjectFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleobjectframe/) peut exposer une image d'aperçu via `getSubstitutePictureFormat()`, mais cette image n'est que l'aperçu de la diapositive. Ce n'est pas le fichier intégré dans l'objet OLE.
- **Vignettes de cadres vidéo :** un [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) peut exposer une image d'aperçu via `getPictureFormat()`, mais cette image n'est que le poster affiché sur la diapositive. Elle n'est pas extraite du flux vidéo.
- **Vignettes de cadres audio :** un [AudioFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/audioframe/) peut exposer une icône ou une vignette via `getPictureFormat()` ; ce n’est pas les données audio intégrées.
- **Images de zoom :** les formes de zoom de diapositive, de zoom de section et de zoom récapitulatif peuvent utiliser des objets [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) personnalisés via `getZoomImage()`.
- **Modèles de formes imbriquées :** les objets Table, Chart et SmartArt implémentent [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/), mais leurs images sont souvent stockées dans des cellules de tableau imbriquées, des éléments de graphique ou des objets de formatage de nœuds SmartArt.
- **Images recadrées ou transformées :** accéder à [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) vous donne la ressource image stockée. Cela ne rend pas le recadrage, la transparence, le recolorisation, la rotation ou d'autres effets visuels appliqués par la forme.

## **FAQ**

**Puis‑je extraire l'image originale sans recadrage, effets ou transformations de forme ?**  
Oui. Accédez à l'objet [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) et écrivez les données de `getBinaryData()` sur le disque. Cela préserve l'image encodée originale stockée dans la présentation, et non la manière dont l'image est rendue sur la diapositive.

**Puis‑je exporter chaque image extraite au format PNG ?**  
Oui. Utilisez [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) et sa méthode `getImage()`, puis appelez `save()` avec [ImageFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/imageformat/). Cela convertit la sortie et peut ne pas préserver le type de fichier original ou les données vectorielles.

**Comment éviter d’enregistrer la même image plusieurs fois ?**  
Utilisez un hachage des données [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) provenant de `getBinaryData()` et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou enregistrez une autre référence vers le fichier de sortie existant.

**Pourquoi certaines formes ne produisent‑elles pas d'image ?**  
Les cadres d'image, les formes à remplissage d'image, les cadres d'objets OLE, les cadres multimédias, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de forme exposent des images via des objets de formatage imbriqués, de sorte qu'un simple contrôle `getPictureFormat()` ou `getFillFormat()` de la forme n'est pas toujours suffisant.

**Puis‑je extraire la vignette affichée pour un cadre vidéo ?**  
Oui. Utilisez [VideoFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/videoframe/) et lisez `getPictureFormat().getPicture().getImage()`. Cela extrait l'image du poster stockée avec le cadre vidéo, pas une image générée à partir du fichier vidéo.

**Comment puis‑je déterminer quelles formes utilisent une image spécifique de la collection d'images de la présentation ?**  
Aspose.Slides ne stocke pas de liens inverses de [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) vers les formes. Construisez une table de correspondance lors du parcours : chaque fois que vous trouvez une référence d'image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l'élément de la collection d'images.

**Puis‑je extraire les images intégrées dans des objets OLE, comme des documents joints ?**  
Vous pouvez extraire l'aperçu de diapositive de l'objet OLE depuis [OleObjectFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/oleobjectframe/). Cependant, cet aperçu n'est pas le document intégré lui‑même. Pour extraire les images à l'intérieur du fichier intégré, extrayez les données OLE et examinez‑les avec les outils appropriés à ce type de fichier.