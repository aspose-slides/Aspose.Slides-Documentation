---
title: Extrahování obrázků z tvarů prezentace v Javě
linktitle: Obrázek ze tvaru
type: docs
weight: 100
url: /cs/java/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java - rychlé, programátorovi přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou vyskytovat v několika typech tvarů: jako běžné rámy obrázků, jako výplně obrázkem aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámů, jako zoom obrázky nebo jako obrázky vložené uvnitř tabulek, grafů a SmartArt tvarů. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je dostupná prostřednictvím objektů [IImageCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iimagecollection/) a [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/).

Pokud potřebujete pouze exportovat všechny zdroje obrázků vložené v prezentaci, projděte `presentation.getImages()`. Tento článek se zaměřuje na jiný úkol: procházet tvary a najít, kde jsou obrázky použity na snímcích, aby uložené soubory mohly zachovat užitečný kontext jako číslo snímku, pozice tvaru a typ zdroje (rám obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}

Použijte [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getBinaryData--) k zachování původních kódovaných dat obrázku a typu souboru. Použijte [IPPImage.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getImage--) s [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iimage/#save-java.lang.String-int-) když chcete normalizovat výstup do konkrétního formátu, např. PNG.

{{% /alert %}}

## **Sdílené pomocné metody**

Níže uvedené pomocné metody zkracují příklady. `saveOriginalImage` zapíše původní vložené bajty, vybere bezpečnou příponu z MIME typu a vynechá duplicitní binární obrázky podle SHA‑256 hashe.

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

## **Extrahování obrázků z rámů obrázků**

Použijte tento přístup pro obrázky vložené jako samostatné objekty. [IPictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ipictureframe/) ukládá svůj obrázek v `getPictureFormat().getPicture().getImage()`, což vrací objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/).

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

## **Extrahování obrázků z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud to není [FillType.Picture](https://reference.aspose.com/slides/cs/java/com.aspose.slides.filltype/), neexistuje obrázek, který by se z této výplně mohl extrahovat. Níže uvedený příklad pracuje s objekty [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iautoshape/) a ukládá každý obrázek jako PNG pomocí [IPPImage.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getImage--).

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

## **Extrahování náhledových obrázků z OLE rámů objektů**

[IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ioleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `getSubstitutePictureFormat().getPicture().getImage()`. Extrahováním tohoto obrázku získáte náhled, nikoli vložený obsah OLE balíčku.

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

## **Extrahování náhledových obrázků z video rámů**

[IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ivideoframe/) může také uložit náhledový obrázek v `getPictureFormat().getPicture().getImage()`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, nikoli o snímek dekódovaný z video proudu.

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

## **Extrahování náhledových obrázků z audio rámů**

[IAudioFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iaudioframe/) může uložit miniaturu v `getPictureFormat().getPicture().getImage()`. Toto je obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahování obrázků z zoom objektů**

Tvary [IZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.izoomframe/) a [ISectionZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.isectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `getZoomImage()` ze zoom rámu.

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

## **Extrahování obrázků ze souhrnných zoom rámů**

[ISummaryZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.isummaryzoomframe/) je také tvar. Jeho položky sekcí mohou používat vlastní obrázky, které jsou přístupné přes metodu `getZoomImage()` každé sekce souhrnného zoomu.

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

## **Extrahování obrázků z tabulkových tvarů**

[ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides.itable/) je tvar. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahování obrázků z grafických tvarů**

[IChart](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ichart/) je tvar. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahování obrázků z SmartArt tvarů**

[ISmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ismartart/) je objekt tvaru. V závislosti na rozložení SmartArt mohou být obrázky uloženy ve výplních výplní odrážek uzlů nebo ve výplních tvarů uzlů.

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

## **Zahrnutí obrázků uvnitř seskupených tvarů**

Seskupené tvary obsahují své vlastní kolekce tvarů. Sdílená pomocná metoda `enumerateShapes` má volbu `includeGroupedShapes`. Nastavte ji na `true`, když chcete prozkoumat tvary uvnitř objektů [IGroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides.igroupshape/). Níže uvedený příklad extrahuje obrázky z rámů obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámů a miniatur audio rámů. Pro zahrnutí obrázků z tabulek, grafů, SmartArt a souhrnných zoomů použijte specializovanou extrakční logiku z předchozích sekcí a zachovejte stejný rekurzivní průchod tvary.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Vytvořte hash pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getBinaryData--) před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Původní data vs. konvertovaný výstup:** Ukládání pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getBinaryData--) zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání pomocí [IPPImage.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getImage--) přes [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iimage/#save-java.lang.String-int-) je užitečné, když chcete jednotný výstupní formát.
- **Neočekávané typy výplní:** Tvary s plnou barvou, gradientem, vzorem nebo žádnou výplní neobsahují obrázkovou výplň. Ověřte [FillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides.filltype/) před čtením `getPictureFillFormat()`.
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku nevyrovnává skupiny. Rekurzivně prozkoumejte [IGroupShape.getShapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides.igroupshape/#getShapes--) když je seskupený obsah důležitý.
- **Náhledy OLE objektů:** [IOleObjectFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ioleobjectframe/) může nabízet náhledový obrázek přes `getSubstitutePictureFormat()`, ale tento obrázek je jen náhled na snímku. Nejedná se o vložený soubor uvnitř OLE objektu.
- **Miniatury video rámů:** [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ivideoframe/) může nabízet náhledový obrázek přes `getPictureFormat()`, ale tento obrázek je jen plakát zobrazený na snímku. Není extrahován z video proudu.
- **Miniatury audio rámů:** [IAudioFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iaudioframe/) může nabízet ikonu nebo miniaturu přes `getPictureFormat()`; nejde o vložená audio data.
- **Zoom obrázky:** Tvary zoomu snímku, sekce a souhrnu mohou používat vlastní objekty [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/) přes `getZoomImage()`.
- **Vnořené modely tvarů:** Tabulky, grafy a SmartArt objekty implementují [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ishape/), ale jejich obrázky jsou často uloženy ve vnořených buňkách, grafech nebo formátovacích objektech uzlů SmartArt.
- **Ořezané nebo transformované obrázky:** Přístup k [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/) vám poskytne uložený obrazový zdroj. Neaplikuje ořez, průhlednost, přebarvení, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Často kladené otázky**

**Mohu extrahovat původní obrázek bez ořezu, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/) a zapište [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getBinaryData--) na disk. Tím zachováte původní kódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [IPPImage.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getImage--) pro získání objektu [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iimage/) a poté zavolejte [IImage.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides.iimage/#save-java.lang.String-int-) s [ImageFormat.Png](https://reference.aspose.com/slides/cs/java/com.aspose.slides.imageformat/). To převádí výstup a nemusí zachovat původní typ souboru ani vektorová data.

**Jak zabránit uložení stejného obrázku vícekrát?**

Vytvořte hash pomocí [IPPImage.getBinaryData](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/#getBinaryData--) a uložte hashe v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary neprodukují obrázek?**

Rámy obrázků, tvary vyplněné obrázkem, OLE objektové rámy, multimediální rámy, zoom rámy, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů odhalují obrázky prostřednictvím vnořených formátovacích objektů, takže jednoduchá kontrola `getPictureFormat()` nebo `getFillFormat()` nemusí být vždy dostačující.

**Mohu extrahovat miniaturu zobrazenou pro video rám?**

Ano. Použijte [IVideoFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ivideoframe/) a přečtěte `getPictureFormat().getPicture().getImage()`. Toto extrahuje poster obrázek uložený s video rámem, ne snímek vygenerovaný z video souboru.

**Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá reverzní odkazy z [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ippimage/) na tvary. Vytvořte mapování během průchodu: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash obrázku nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například přiložené dokumenty?**

Můžete extrahovat náhled OLE objektu pomocí [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--). Tento náhled však není samotný vložený dokument. Pro extrahování obrázků zevnitř vloženého souboru musíte nejprve získat OLE data a prozkoumat je pomocí nástrojů vhodných pro daný typ souboru.