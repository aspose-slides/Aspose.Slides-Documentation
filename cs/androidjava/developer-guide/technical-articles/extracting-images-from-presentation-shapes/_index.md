---
title: Extrahovat obrázky z tvarů prezentace v Androidu pomocí Java
linktitle: Obrázek z tvaru
type: docs
weight: 100
url: /cs/androidjava/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Java – rychlé, kódu přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako běžné rámy obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky objektů OLE, jako miniatury video nebo audio snímků, jako zoom obrázky nebo jako obrázky vnořené v tabulkách, grafech a tvarech SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je dostupná prostřednictvím objektů [IImageCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/).

Pokud potřebujete pouze exportovat všechny obrázkové zdroje vložené v prezentaci, iterujte pomocí `presentation.getImages()`. Tento článek se zaměřuje na jiný úkol: procházet tvary a najít, kde jsou obrázky na snímcích použity, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rám obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}
Použijte [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getBinaryData--) k zachování originálních kódovaných dat obrázku a typu souboru. Použijte [IPPImage.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getImage--) s [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-), pokud chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Společné pomocné metody**

Níže uvedené pomocné metody udržují příklady stručné. `saveOriginalImage` zapisuje originální vložené bajty, vybírá bezpečnou příponu z MIME typu a přeskočí duplicitní binární data obrázku pomocí SHA-256 hashe.

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

## **Extrahovat obrázky z rámečků obrázků**

Použijte tento postup pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipictureframe/) ukládá svůj obrázek v `getPictureFormat().getPicture().getImage()`, který vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/).

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

## **Extrahovat obrázky z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.Picture](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/), není z této výplně žádný obrázek k extrahování. Níže uvedený příklad pracuje s objekty [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **Extrahovat náhledové obrázky z OLE rámců objektů**

Objekt [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `getSubstitutePictureFormat().getPicture().getImage()`. Extrahování tohoto obrázku vám poskytne náhledový obrázek, nikoli obsah vloženého OLE balíčku.

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

## **Extrahovat náhledové obrázky z video rámců**

[IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) může také uložit náhledový obrázek v `getPictureFormat().getPicture().getImage()`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, ne o snímek dekódovaný z video proudu.

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

## **Extrahovat náhledové obrázky z audio rámců**

[IAudioFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/) může uložit miniaturu v `getPictureFormat().getPicture().getImage()`. Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahovat obrázky ze Zoom objektů**

[IZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `getZoomImage()` ze zoom rámce.

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

## **Extrahovat obrázky ze Summary Zoom rámců**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isummaryzoomframe/) je také tvar. Jeho sekční položky mohou používat vlastní obrázky, dostupné přes metodu `getZoomImage()` každé sekce.

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

## **Extrahovat obrázky z tabulkových tvarů**

[ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itable/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahovat obrázky z grafových tvarů**

[IChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblastí grafu.

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

## **Extrahovat obrázky ze SmartArt tvarů**

[ISmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartart/) je objekt tvaru. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních teček uzlů nebo ve výplních tvarů uzlů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují vlastní kolekce tvarů. Sdílený pomocník `enumerateShapes` má možnost `includeGroupedShapes`. Nastavte ji na `true`, pokud chcete prozkoumat tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igroupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a summary zoom také použijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Okrajové případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Vytvořte hash pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getBinaryData--) před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Originální data vs. konvertovaný výstup:** Ukládání pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getBinaryData--) zachovává vložená JPEG, PNG, GIF, SVG, EMF nebo WMF data. Ukládání pomocí [IPPImage.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getImage--) přes [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) je užitečné, když chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary s plnou barvou, gradientem, vzorem nebo bez výplně neobsahují obrázkovou výplň. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) před čtením `getPictureFillFormat()`.
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává skupiny. Rekurzivně prozkoumejte [IGroupShape.getShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/igroupshape/#getShapes--) pokud je obsah skupiny relevantní.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/) může vystavit náhledový obrázek přes `getSubstitutePictureFormat()`, ale tento obrázek je jen náhled na snímku. Není to vložený soubor uvnitř OLE objektu.
- **Miniatury video snímků:** [IVideoFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/) může vystavit náhledový obrázek přes `getPictureFormat()`, ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio snímků:** [IAudioFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iaudioframe/) může vystavit ikonu nebo miniaturu přes `getPictureFormat()`; není to vložený audio soubor.
- **Zoom obrázky:** Tvary zoom, sekční zoom a summary zoom mohou používat vlastní objekty [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) přes `getZoomImage()`.
- **Vnořené modely tvarů:** Objektům tabulek, grafů a SmartArt implementuje [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), ale jejich obrázky jsou často uloženy v vnořených objektech formátování buněk, prvků grafu nebo uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) poskytuje uložený obrázkový zdroj. Nezahrnuje oříznutí, průhlednost, přeobarvení, rotaci nebo jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez oříznutí, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) a zapište [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getBinaryData--) na disk. Tím zachováte originální kódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [IPPImage.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getImage--) pro získání objektu [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/), a poté zavolejte [IImage.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) s [ImageFormat.Png](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/). Tento převod může nezachovat původní typ souboru nebo vektorová data.

**Jak zabránit ukládání stejného obrázku vícekrát?**

Vytvořte hash pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/#getBinaryData--) a uložte hashe do množiny. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary neprodukují obrázek?**

Rámečky obrázků, tvary vyplněné obrázkem, OLE rámce objektů, mediální rámce, zoom rámce, tabulky, grafy a SmartArt mohou odkazovat na obrázky. Některé typy tvarů vystavují obrázky prostřednictvím vnořených formátovacích objektů, takže jednoduchá kontrola `getPictureFormat()` nebo `getFillFormat()` nemusí být vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video rám?**

Ano. Použijte [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) a přečtěte `getPictureFormat().getPicture().getImage()`. Tím získáte plakátový obrázek uložený s video rámem, ne snímek vygenerovaný z video souboru.

**Jak zjistit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá reverzní odkazy z [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ippimage/) na tvary. Vytvořte mapování během procházení: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash nebo položku kolekce obrázku.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?**

Můžete extrahovat náhled OLE objektu pomocí [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Tento náhled však není samotný vložený dokument. Pro extrakci obrázků zevnitř vloženého souboru musíte získat OLE data a prozkoumat je nástroji určenými pro daný typ souboru.