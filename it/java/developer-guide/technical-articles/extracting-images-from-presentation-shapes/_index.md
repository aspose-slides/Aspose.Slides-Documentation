---
title: Estrai immagini dalle forme della presentazione in Java
linktitle: Immagine dalla forma
type: docs
weight: 100
url: /it/java/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Estrai immagini dalle forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Java - soluzione rapida e adatta al codice."
---
## **Panoramica**

Le immagini in una presentazione possono apparire in diversi tipi di forma: come normali cornici immagine, come riempimenti immagine applicati a forme, come anteprime di oggetti OLE, come miniature di fotogrammi video o audio, come immagini di zoom o come immagini annidate all’interno di forme di tabella, grafico e SmartArt. Aspose.Slides memorizza queste immagini nella raccolta di immagini della presentazione, esposta tramite [IImageCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides.iimagecollection/) e [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) .

Se ti serve solo esportare ogni risorsa immagine incorporata in una presentazione, itera attraverso `presentation.getImages()`. Questo articolo si concentra su un compito diverso: attraversare le forme per individuare dove le immagini sono usate nelle diapositive, così i file salvati possono conservare contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (cornice immagine, riempimento immagine, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Suggerimento" color="primary" %}}

Usa [IPPImage.getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getBinaryData--) per preservare i dati immagine originali codificati e il tipo di file. Usa [IPPImage.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getImage--) con [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides.iimage/#save-java.lang.String-int-) quando vuoi normalizzare l’output in un formato specifico come PNG.

{{% /alert %}}

## **Metodi di Supporto Condivisi**

I metodi di supporto di seguito mantengono gli esempi brevi. `saveOriginalImage` scrive i byte incorporati originali, sceglie un’estensione sicura dal tipo MIME e ignora i binari immagine duplicati mediante hash SHA‑256.

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

## **Estrai Immagini da Cornici Immagine**

Usa questo approccio per le immagini inserite come oggetti autonomi. Un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ipictureframe/) memorizza la sua immagine in `getPictureFormat().getPicture().getImage()`, che restituisce un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) .

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

## **Estrai Immagini da Forme con Riempimento Immagine**

Le forme possono usare un’immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType.Picture](https://reference.aspose.com/slides/it/java/com.aspose.slides.filltype/), non c’è alcuna immagine da estrarre da quel riempimento. L’esempio di seguito gestisce oggetti [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides.iautoshape/) e salva ogni immagine come PNG tramite [IPPImage.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getImage--) .

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

## **Estrai Immagini di Anteprima da Cornici Oggetto OLE**

Una [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ioleobjectframe/) può avere un’immagine sostitutiva che PowerPoint utilizza come anteprima dell’oggetto sulla diapositiva. Questa immagine è disponibile tramite `getSubstitutePictureFormat().getPicture().getImage()` . Estrarla fornisce l’immagine di anteprima, non i contenuti del pacchetto OLE incorporato.

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

## **Estrai Immagini di Anteprima da Cornici Video**

Una [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ivideoframe/) può anche memorizzare un’immagine di anteprima in `getPictureFormat().getPicture().getImage()` . Questa è il poster o la miniatura mostrata sulla diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai Immagini di Anteprima da Cornici Audio**

Una [IAudioFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.iaudioframe/) può memorizzare una miniatura in `getPictureFormat().getPicture().getImage()` . Questa è l’immagine mostrata per l’oggetto audio sulla diapositiva.

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

## **Estrai Immagini da Oggetti Zoom**

Le forme [IZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.izoomframe/) e [ISectionZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.isectionzoomframe/) possono utilizzare immagini personalizzate. Leggi `getZoomImage()` dalla cornice zoom.

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

## **Estrai Immagini da Cornici Zoom Riepilogo**

Una [ISummaryZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.isummaryzoomframe/) è anche una forma. I suoi elementi di sezione possono usare immagini personalizzate, esposte tramite il metodo `getZoomImage()` di ciascuna sezione zoom riepilogo.

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

## **Estrai Immagini da Forme Tabella**

Una [ITable](https://reference.aspose.com/slides/it/java/com.aspose.slides.itable/) è una forma. Le immagini in una tabella sono di solito memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai Immagini da Forme Grafico**

Un [IChart](https://reference.aspose.com/slides/it/java/com.aspose.slides.ichart/) è una forma. L’esempio di seguito estrae un’immagine dal riempimento immagine dell’area del grafico.

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

## **Estrai Immagini da Forme SmartArt**

Un oggetto [ISmartArt](https://reference.aspose.com/slides/it/java/com.aspose.slides.ismartart/) è una forma. A seconda del layout SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi Immagini all’interno di Forme Raggruppate**

Le forme raggruppate contengono le proprie raccolte di forme. Il supporto condiviso `enumerateShapes` ha un’opzione `includeGroupedShapes`. Impostala su `true` quando vuoi ispezionare le forme all’interno di oggetti [IGroupShape](https://reference.aspose.com/slides/it/java/com.aspose.slides.igroupshape/) . L’esempio di seguito estrae immagini da cornici immagine, forme con riempimento immagine, anteprime oggetti OLE, miniature di fotogrammi video e di fotogrammi audio. Per includere anche immagini di tabelle, grafici, SmartArt e zoom riepilogo, riutilizza la logica di estrazione specializzata delle sezioni precedenti mantenendo lo stesso attraversamento ricorsivo delle forme.

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

## **Casi Limite e Note Pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Esegui l’hash di [IPPImage.getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getBinaryData--) prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs. output convertito:** Il salvataggio di [IPPImage.getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getBinaryData--) preserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Il salvataggio di [IPPImage.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getImage--) tramite [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides.iimage/#save-java.lang.String-int-) è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** Le forme solide, a gradiente, a pattern e senza riempimento non contengono un riempimento immagine. Controlla [FillType](https://reference.aspose.com/slides/it/java/com.aspose.slides.filltype/) prima di leggere `getPictureFillFormat()` .
- **Forme raggruppate:** La raccolta di forme della diapositiva di livello superiore non appiattisce i gruppi. Ispeziona ricorsivamente [IGroupShape.getShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides.igroupshape/#getShapes--) quando il contenuto raggruppato è rilevante.
- **Anteprime oggetto OLE:** Una [IOleObjectFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ioleobjectframe/) può esporre un’immagine di anteprima tramite `getSubstitutePictureFormat()` , ma quell’immagine è solo l’anteprima della diapositiva. Non è il file incorporato all’interno dell’oggetto OLE.
- **Miniature dei fotogrammi video:** Una [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ivideoframe/) può esporre un’immagine di anteprima tramite `getPictureFormat()` , ma quell’immagine è solo il poster mostrato sulla diapositiva. Non è estratta dal flusso video.
- **Miniature dei fotogrammi audio:** Una [IAudioFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.iaudioframe/) può esporre un’icona o una miniatura tramite `getPictureFormat()` ; non è il dato audio incorporato.
- **Immagini zoom:** Le forme di zoom diapositiva, zoom sezione e zoom riepilogo possono usare oggetti [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) personalizzati tramite `getZoomImage()` .
- **Modelli di forma nidificati:** Gli oggetti tabella, grafico e SmartArt implementano [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides.ishape/) , ma le loro immagini sono spesso memorizzate in oggetti di formattazione nidificati di celle, elementi del grafico o nodi SmartArt.
- **Immagini ritagliate o trasformate:** Accedere a [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) ti fornisce la risorsa immagine memorizzata. Non rende il ritaglio, la trasparenza, la rimappatura dei colori, la rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l’immagine originale senza ritagli, effetti o trasformazioni della forma?**

Sì. Accedi all’oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) e scrivi [IPPImage.getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getBinaryData--) su disco. Questo preserva l’immagine originale codificata memorizzata nella presentazione, non il modo in cui l’immagine è resa sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Usa [IPPImage.getImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getImage--) per ottenere un oggetto [IImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.iimage/) e poi chiama [IImage.save](https://reference.aspose.com/slides/it/java/com.aspose.slides.iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/it/java/com.aspose.slides.imageformat/) . Questo converte l’output e potrebbe non preservare il tipo di file originale o i dati vettoriali.

**Come faccio a evitare di salvare la stessa immagine più volte?**

Usa un hash di [IPPImage.getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/#getBinaryData--) e tieni gli hash in un set. Se una nuova immagine ha un hash già presente, salta il salvataggio o registra un’altra referenza al file di output esistente.

**Perché alcune forme non producono un’immagine?**

Cornici immagine, forme con riempimento immagine, cornici oggetto OLE, cornici multimediali, cornici zoom, tabelle, grafici e oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono le immagini tramite oggetti di formattazione nidificati, quindi un semplice `getPictureFormat()` o un controllo `getFillFormat()` sulla forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per una cornice video?**

Sì. Usa [IVideoFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides.ivideoframe/) e leggi `getPictureFormat().getPicture().getImage()` . Questo estrae l’immagine poster memorizzata con la cornice video, non un fotogramma generato dal file video.

**Come posso determinare quali forme usano una specifica immagine dalla raccolta immagini della presentazione?**

Aspose.Slides non memorizza collegamenti inversi da [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides.ippimage/) alle forme. Costruisci una mappatura durante l’attraversamento: ogni volta che trovi un riferimento immagine, registra il numero della diapositiva, il percorso della forma e l’hash o l’elemento della raccolta.

**Posso estrarre le immagini incorporate all’interno di oggetti OLE, come documenti allegati?**

Puoi estrarre l’anteprima diapositiva dell’oggetto OLE tramite [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) . Tuttavia, tale anteprima non è il documento incorporato stesso. Per estrarre le immagini dal file incorporato, estrai i dati OLE e analizzali con gli strumenti appropriati per quel tipo di file.