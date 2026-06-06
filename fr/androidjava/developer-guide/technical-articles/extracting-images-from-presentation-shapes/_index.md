---
title: Extraire des images des formes de présentation sous Android via Java
linktitle: Image depuis forme
type: docs
weight: 100
url: /fr/androidjava/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java – solution rapide et conviviale pour le code."
---
## **Aperçu**

Les images d’une présentation peuvent apparaître dans plusieurs types de formes : en tant que cadres d’image ordinaires, en tant que remplissages d’image appliqués aux formes, en tant qu’images d’aperçu d’objet OLE, en tant que vignettes de trame vidéo ou audio, en tant qu’images de zoom, ou en tant qu’images imbriquées dans des formes de tableau, de graphique et de SmartArt. Aspose.Slides stocke ces images dans la collection d’images de la présentation, exposée via les objets [IImageCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimagecollection/) et [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/).

Si vous avez seulement besoin d’exporter chaque ressource image incorporée dans une présentation, parcourez `presentation.getImages()`. Cet article se concentre sur une tâche différente : parcourir les formes pour trouver où les images sont utilisées sur les diapositives, afin que les fichiers enregistrés conservent un contexte utile tel que le numéro de diapositive, la position de la forme et le type de source (cadre d’image, remplissage d’image, aperçu multimédia, aperçu OLE ou image de zoom).

{{% alert title="Tip" color="primary" %}}
Utilisez [IPPImage.getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) pour préserver les données d’image encodées d’origine et le type de fichier. Utilisez [IPPImage.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getImage--) avec [IImage.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) lorsque vous souhaitez normaliser la sortie vers un format spécifique tel que PNG.
{{% /alert %}}

## **Méthodes d’assistance partagées**

Les méthodes d’assistance ci‑dessous raccourcissent les exemples. `saveOriginalImage` écrit les octets incorporés d’origine, choisit une extension sûre à partir du type MIME et ignore les binaires d’image en double grâce à un hachage SHA‑256.

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Set;

private static final class ShapeReference
{
    private final IShape shape;
    private final String namePart;

    private ShapeReference(IShape shape, String namePart)
    {
        this.shape = shape;
        this.namePart = namePart;
    }
}

private static boolean saveOriginalImage(
    IPPImage image,
    String outputDirectory,
    String fileNameBase,
    Set<String> savedImageHashes) throws Exception
{
    byte[] imageData = image.getBinaryData();
    String imageHash = getSha256Hash(imageData);
    if (!savedImageHashes.add(imageHash))
    {
        return false;
    }

    String extension = getExtensionFromContentType(image.getContentType());
    String fileName = fileNameBase + "." + extension;
    File outputFile = new File(outputDirectory, fileName);

    FileOutputStream outputStream = new FileOutputStream(outputFile);
    try
    {
        outputStream.write(imageData);
    }
    finally
    {
        outputStream.close();
    }

    return true;
}

private static void saveImageAsPng(IPPImage image, String outputDirectory, String fileNameBase)
{
    String fileName = fileNameBase + ".png";
    File outputFile = new File(outputDirectory, fileName);
    String outputPath = outputFile.getPath();

    IImage outputImage = image.getImage();
    try
    {
        outputImage.save(outputPath, ImageFormat.Png);
    }
    finally
    {
        if (outputImage != null)
        {
            outputImage.dispose();
        }
    }
}

private static IPPImage getPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.getFillType() != FillType.Picture)
    {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

private static List<ShapeReference> enumerateShapes(
    IShapeCollection shapes,
    String prefix,
    boolean includeGroupedShapes)
{
    List<ShapeReference> shapeReferences = new ArrayList<ShapeReference>();
    int shapeCount = shapes.size();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes.get_Item(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = prefix + "_shape_" + displayIndex;
        ShapeReference shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.add(shapeReference);

        if (includeGroupedShapes && shape instanceof IGroupShape)
        {
            IGroupShape groupShape = (IGroupShape)shape;
            IShapeCollection childShapes = groupShape.getShapes();
            List<ShapeReference> childReferences = enumerateShapes(
                childShapes,
                shapeNamePart,
                includeGroupedShapes);
            shapeReferences.addAll(childReferences);
        }
    }

    return shapeReferences;
}

private static String getSha256Hash(byte[] data) throws Exception
{
    MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
    byte[] hashBytes = messageDigest.digest(data);
    StringBuilder hashBuilder = new StringBuilder();
    for (byte hashByte : hashBytes)
    {
        String hexValue = Integer.toHexString(hashByte & 0xff);
        if (hexValue.length() == 1)
        {
            hashBuilder.append('0');
        }

        hashBuilder.append(hexValue);
    }

    return hashBuilder.toString();
}

private static String getExtensionFromContentType(String contentType)
{
    if (contentType == null || contentType.trim().length() == 0)
    {
        return "bin";
    }

    String mediaType = contentType.split(";")[0].trim().toLowerCase(Locale.ROOT);
    if ("image/jpeg".equals(mediaType))
    {
        return "jpg";
    }

    if ("image/png".equals(mediaType))
    {
        return "png";
    }

    if ("image/gif".equals(mediaType))
    {
        return "gif";
    }

    if ("image/bmp".equals(mediaType))
    {
        return "bmp";
    }

    if ("image/tiff".equals(mediaType))
    {
        return "tiff";
    }

    if ("image/x-emf".equals(mediaType) || "image/emf".equals(mediaType))
    {
        return "emf";
    }

    if ("image/x-wmf".equals(mediaType) || "image/wmf".equals(mediaType))
    {
        return "wmf";
    }

    if ("image/svg+xml".equals(mediaType))
    {
        return "svg";
    }

    if (mediaType.startsWith("image/"))
    {
        String extension = mediaType.substring("image/".length());
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

private static String makeSafeFileNamePart(String value)
{
    return value.replaceAll("[^A-Za-z0-9._-]", "_");
}
```

## **Extraire les images des cadres d’image**

Utilisez cette approche pour les images insérées comme objets autonomes. Un [IPictureFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipictureframe/) stocke son image dans `getPictureFormat().getPicture().getImage()`, qui renvoie un objet [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/).

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "extracted-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des formes remplies d’image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d’abord le type de remplissage de la forme : s’il n’est pas [FillType.Picture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/), il n’y a aucune image à extraire de ce remplissage. L’exemple ci‑dessous gère les objets [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) et enregistre chaque image au format PNG via [IPPImage.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getImage--).

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "shape-fill-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images d’aperçu des cadres d’objet OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioleobjectframe/) peut avoir une image de substitution que PowerPoint utilise comme aperçu de l’objet sur une diapositive. Cette image est disponible via `getSubstitutePictureFormat().getPicture().getImage()`. Extraire cette image vous donne l’aperçu, pas le contenu du package OLE incorporé.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "ole-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images d’aperçu des cadres vidéo**

Un [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) peut également stocker une image d’aperçu dans `getPictureFormat().getPicture().getImage()`. Il s’agit de l’afficheur ou de la vignette présentée sur la diapositive, pas d’une trame décodée depuis le flux vidéo.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "video-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images d’aperçu des cadres audio**

Un [IAudioFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iaudioframe/) peut stocker une vignette dans `getPictureFormat().getPicture().getImage()`. C’est l’image affichée pour l’objet audio sur la diapositive.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "audio-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des objets Zoom**

Les formes [IZoomFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/izoomframe/) et [ISectionZoomFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isectionzoomframe/) peuvent utiliser des images personnalisées. Lisez `getZoomImage()` depuis le cadre de zoom.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IZoomFrame)
            {
                IZoomFrame zoomFrame = (IZoomFrame)shapeReference.shape;
                IPPImage image = zoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (shapeReference.shape instanceof ISectionZoomFrame)
            {
                ISectionZoomFrame sectionZoomFrame = (ISectionZoomFrame)shapeReference.shape;
                IPPImage image = sectionZoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_section_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des cadres de zoom récapitulatif**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/isummaryzoomframe/) est également une forme. Ses éléments de section peuvent utiliser des images personnalisées, exposées via la méthode `getZoomImage()` de chaque section de zoom récapitulatif.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "summary-zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISummaryZoomFrame)
            {
                ISummaryZoomFrame summaryZoomFrame = (ISummaryZoomFrame)shapeReference.shape;
                int sectionCount = summaryZoomFrame.getSummaryZoomCollection().size();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.getSummaryZoomCollection().get_Item(sectionIndex);
                    IPPImage image = section.getZoomImage();
                    if (image != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_summary_zoom_" + displayIndex;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des formes de tableau**

Un [ITable](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itable/) est une forme. Les images dans un tableau sont généralement stockées comme remplissages d’image dans les cellules du tableau.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "table-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ITable)
            {
                ITable table = (ITable)shapeReference.shape;
                int rowCount = table.getRows().size();
                int columnCount = table.getColumns().size();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table.get_Item(columnIndex, rowIndex);
                        IFillFormat fillFormat = cell.getCellFormat().getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayRow = rowIndex + 1;
                            int displayColumn = columnIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_cell_" + displayRow + "_" + displayColumn;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des formes de graphique**

Un [IChart](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ichart/) est une forme. L’exemple ci‑dessous extrait une image du remplissage d’image de la zone du graphique.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "chart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IChart)
            {
                IChart chart = (IChart)shapeReference.shape;
                IFillFormat fillFormat = chart.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_chart_area";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Extraire les images des formes SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartart/) est une forme. Selon la disposition du SmartArt, les images peuvent être stockées dans les remplissages de puces des nœuds ou dans les formats de remplissage des formes de nœuds.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "smartart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISmartArt)
            {
                ISmartArt smartArt = (ISmartArt)shapeReference.shape;
                int nodeCount = smartArt.getAllNodes().size();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    ISmartArtNode node = smartArt.getAllNodes().get_Item(nodeIndex);
                    IFillFormat bulletFillFormat = node.getBulletFillFormat();
                    IPPImage bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage != null)
                    {
                        int displayNode = nodeIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_bullet";
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.getShapes().size();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        ISmartArtShape nodeShape = node.getShapes().get_Item(nodeShapeIndex);
                        IFillFormat fillFormat = nodeShape.getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayNode = nodeIndex + 1;
                            int displayNodeShape = nodeShapeIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_shape_" + displayNodeShape;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Inclure les images à l’intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. L’assistance partagée `enumerateShapes` possède une option `includeGroupedShapes`. Réglez‑la sur `true` lorsque vous souhaitez inspecter les formes à l’intérieur des objets [IGroupShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/igroupshape/). L’exemple ci‑dessus extrait des images des cadres d’image, des formes remplies d’image, des aperçus d’objet OLE, des vignettes de trames vidéo et audio. Pour inclure également les images de tableau, de graphique, de SmartArt et de zoom récapitulatif, réutilisez la logique d’extraction spécialisée des sections précédentes tout en conservant le même parcours de forme récursif.

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "all-shape-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **Cas particuliers et notes pratiques**

- **Images en double :** plusieurs formes peuvent référencer la même image ou des images distinctes avec des octets identiques. Hachez [IPPImage.getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) avant d’écrire les fichiers si vous souhaitez un fichier de sortie par image unique.
- **Données d’origine vs sortie convertie :** enregistrer [IPPImage.getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) préserve les données JPEG, PNG, GIF, SVG, EMF ou WMF incorporées. Enregistrer [IPPImage.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getImage--) via [IImage.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) est utile lorsque vous désirez un format de sortie cohérent.
- **Types de remplissage non pris en charge :** les formes avec remplissage solide, dégradé, motif ou sans remplissage ne contiennent pas de remplissage d’image. Vérifiez [FillType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/filltype/) avant de lire `getPictureFillFormat()`.
- **Formes groupées :** la collection de formes de niveau supérieur d’une diapositive ne développe pas les groupes. Inspectez récursivement [IGroupShape.getShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/igroupshape/#getShapes--) lorsque le contenu groupé est important.
- **Aperçus d’objet OLE :** un [IOleObjectFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioleobjectframe/) peut exposer une image d’aperçu via `getSubstitutePictureFormat()`, mais cette image n’est que l’aperçu de la diapositive. Elle ne représente pas le fichier incorporé dans l’objet OLE.
- **Vignettes de trame vidéo :** un [IVideoFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/) peut exposer une image d’aperçu via `getPictureFormat()`, mais cette image n’est que l’afficheur affiché sur la diapositive. Elle n’est pas extraite du flux vidéo.
- **Vignettes de trame audio :** un [IAudioFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iaudioframe/) peut exposer une icône ou une vignette via `getPictureFormat()` ; il ne s’agit pas des données audio incorporées.
- **Images de Zoom :** les formes de zoom de diapositive, de section et récapitulatif peuvent utiliser des objets [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) personnalisés via `getZoomImage()`.
- **Modèles de formes imbriquées :** les objets tableau, graphique et SmartArt implémentent [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/), mais leurs images sont souvent stockées dans des objets de formatage imbriqués (cellule de tableau, élément de graphique, nœud SmartArt).
- **Images recadrées ou transformées :** accéder à [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) vous donne la ressource image stockée. Cela ne rend pas les effets de recadrage, de transparence, de recoloration, de rotation ou d’autres effets visuels appliqués par la forme.

## **FAQ**

**Puis‑je extraire l’image originale sans recadrage, effets ou transformations de forme ?**

Oui. Accédez à l’objet [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) et écrivez [IPPImage.getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) sur le disque. Cela préserve l’image encodée d’origine stockée dans la présentation, pas la façon dont l’image est rendue sur la diapositive.

**Puis‑je exporter chaque image extraite au format PNG ?**

Oui. Utilisez [IPPImage.getImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getImage--) pour obtenir un objet [IImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/), puis appelez [IImage.save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) avec [ImageFormat.Png](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imageformat/). Cela convertit la sortie et peut ne pas préserver le type de fichier d’origine ou les données vectorielles.

**Comment éviter d’enregistrer la même image plusieurs fois ?**

Utilisez un hachage de [IPPImage.getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou enregistrez une autre référence vers le fichier de sortie existant.

**Pourquoi certaines formes ne produisent aucune image ?**

Les cadres d’image, les formes remplies d’image, les cadres d’objet OLE, les cadres multimédia, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de forme exposent les images via des objets de formatage imbriqués, de sorte qu’un simple `getPictureFormat()` ou `getFillFormat()` peut ne pas suffire.

**Puis‑je extraire la vignette affichée pour un cadre vidéo ?**

Oui. Utilisez [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) et lisez `getPictureFormat().getPicture().getImage()`. Cela extrait l’image d’afficheur stockée avec le cadre vidéo, pas une trame générée à partir du fichier vidéo.

**Comment déterminer quelles formes utilisent une image spécifique de la collection d’images de la présentation ?**

Aspose.Slides ne conserve pas de liens inverses de [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) vers les formes. Construisez une correspondance pendant le parcours : chaque fois que vous trouvez une référence d’image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l’élément de collection de l’image.

**Puis‑je extraire les images incorporées à l’intérieur d’objets OLE, comme des documents joints ?**

Vous pouvez extraire l’aperçu de glissement de l’objet OLE via [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Cependant, cet aperçu n’est pas le document incorporé lui‑même. Pour extraire les images du fichier intégré, extrayez les données OLE et examinez‑les avec des outils adaptés à ce type de fichier.