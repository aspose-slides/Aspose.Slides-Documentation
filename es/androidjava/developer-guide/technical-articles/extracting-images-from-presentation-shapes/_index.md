---
title: Extraer imágenes de formas de presentación en Android mediante Java
linktitle: Imagen de forma
type: docs
weight: 100
url: /es/androidjava/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Android mediante Java: solución rápida y fácil de usar."
---
## **Descripción general**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imagen ordinarios, como rellenos de imagen aplicados a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom, o como imágenes anidadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de [IImageCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimagecollection/) y [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) objetos.

Si solo necesita exportar cada recurso de imagen incrustado en una presentación, recorra `presentation.getImages()`. Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se usan las imágenes en las diapositivas, de modo que los archivos guardados puedan conservar contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa de medio, vista previa OLE o imagen de zoom).

{{% alert title="Tip" color="primary" %}}

Utilice [IPPImage.getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getBinaryData--) para conservar los datos de imagen codificados originales y el tipo de archivo. Utilice [IPPImage.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getImage--) con [IImage.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) cuando desee normalizar la salida a un formato específico como PNG.

{{% /alert %}}

## **Métodos auxiliares compartidos**

Los métodos auxiliares a continuación mantienen los ejemplos breves. `saveOriginalImage` escribe los bytes incrustados originales, elige una extensión segura a partir del tipo MIME y omite binarios de imagen duplicados mediante el hash SHA-256.

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

## **Extraer imágenes de marcos de imagen**

Utilice este enfoque para imágenes insertadas como objetos independientes. Un [IPictureFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipictureframe/) almacena su imagen en `getPictureFormat().getPicture().getImage()`, que devuelve un objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/).

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

## **Extraer imágenes de formas con relleno de imagen**

Las formas pueden usar una imagen como su relleno. Verifique primero el tipo de relleno de la forma: si no es [FillType.Picture](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/), no hay imagen que extraer de ese relleno. El ejemplo a continuación maneja objetos [IAutoShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iautoshape/) y guarda cada imagen como PNG mediante [IPPImage.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **Extraer imágenes de vista previa de marcos de objeto OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ioleobjectframe/) puede tener una imagen sustituta que PowerPoint usa como vista previa del objeto en una diapositiva. Esta imagen está disponible a través de `getSubstitutePictureFormat().getPicture().getImage()`. Extraer esta imagen le brinda la vista previa, no el contenido del paquete OLE incrustado.

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

## **Extraer imágenes de vista previa de marcos de vídeo**

Un [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) también puede almacenar una imagen de vista previa en `getPictureFormat().getPicture().getImage()`. Esta es la póster o miniatura que se muestra en la diapositiva, no un fotograma decodificado del flujo de vídeo.

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

## **Extraer imágenes de vista previa de marcos de audio**

Un [IAudioFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iaudioframe/) puede almacenar una miniatura en `getPictureFormat().getPicture().getImage()`. Esta es la imagen que se muestra para el objeto de audio en la diapositiva.

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

## **Extraer imágenes de objetos de zoom**

[IZoomFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/izoomframe/) y [ISectionZoomFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isectionzoomframe/) pueden usar imágenes personalizadas. Lea `getZoomImage()` del marco de zoom.

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

## **Extraer imágenes de marcos de zoom de resumen**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/isummaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través del método `getZoomImage()` de cada sección de zoom de resumen.

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

## **Extraer imágenes de formas de tabla**

Una [ITable](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itable/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en celdas de la tabla.

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

## **Extraer imágenes de formas de gráfico**

Un [IChart](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ichart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

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

## **Extraer imágenes de formas SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ismartart/) es una forma. Dependiendo del diseño de SmartArt, las imágenes pueden almacenarse en los rellenos de viñeta de los nodos o en los formatos de relleno de las formas de los nodos.

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

## **Incluir imágenes dentro de formas agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El ayudante compartido `enumerateShapes` tiene una opción `includeGroupedShapes`. Establézcala en `true` cuando desee inspeccionar las formas dentro de objetos [IGroupShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/igroupshape/). El ejemplo a continuación extrae imágenes de marcos de imagen, formas con relleno de imagen, vistas previas de objetos OLE, miniaturas de vídeo y miniaturas de audio. Para incluir también imágenes de tabla, gráfico, SmartArt y zoom de resumen, reutilice la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

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

## **Casos límite y notas prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Realice un hash de [IPPImage.getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getBinaryData--) antes de escribir los archivos si desea un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar [IPPImage.getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getBinaryData--) conserva los datos JPEG, PNG, GIF, SVG, EMF o WMF incrustados. Guardar [IPPImage.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getImage--) mediante [IImage.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) es útil cuando necesita un formato de salida coherente.
- **Tipos de relleno no compatibles:** Las formas de relleno sólido, degradado, patrón y sin relleno no contienen una imagen de relleno. Verifique [FillType](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/filltype/) antes de leer `getPictureFillFormat()`.
- **Formas agrupadas:** La colección de formas de nivel superior de la diapositiva no aplana los grupos. Inspeccione recursivamente [IGroupShape.getShapes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/igroupshape/#getShapes--) cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [IOleObjectFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ioleobjectframe/) puede exponer una imagen de vista previa mediante `getSubstitutePictureFormat()`, pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de fotogramas de vídeo:** Un [IVideoFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/) puede exponer una imagen de vista previa mediante `getPictureFormat()`, pero esa imagen es solo el póster mostrado en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de fotogramas de audio:** Un [IAudioFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iaudioframe/) puede exponer un ícono o miniatura mediante `getPictureFormat()`; no es el dato de audio incrustado.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, de sección y de resumen pueden usar objetos [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) personalizados mediante `getZoomImage()`.
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [IShape](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ishape/), pero sus imágenes a menudo se almacenan en objetos de formato de celda de tabla, elemento de gráfico o nodo de SmartArt anidados.
- **Imágenes recortadas o transformadas:** Acceder a [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) le proporciona el recurso de imagen almacenado. No representa recortes, transparencias, recoloraciones, rotaciones u otros efectos visuales aplicados por la forma.

## **Preguntas frecuentes**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Acceda al objeto [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) y escriba [IPPImage.getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getBinaryData--) en disco. Esto conserva la imagen codificada original almacenada en la presentación, no la forma en que se representa en la diapositiva.

**¿Puedo exportar cada imagen extraída como PNG?**

Sí. Utilice [IPPImage.getImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getImage--) para obtener un objeto [IImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/) y, a continuación, llame a [IImage.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) con [ImageFormat.Png](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imageformat/). Esto convierte la salida y puede no conservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Utilice un hash de [IPPImage.getBinaryData](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/#getBinaryData--) y mantenga los hashes en un conjunto. Si una nueva imagen tiene un hash que ya existe, omítala o registre otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imagen, las formas con relleno de imagen, los marcos de objetos OLE, los marcos de medios, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden referenciar imágenes. Algunos tipos de forma exponen imágenes mediante objetos de formato anidados, por lo que una simple comprobación `getPictureFormat()` o `getFillFormat()` no siempre es suficiente.

**¿Puedo extraer la miniatura mostrada para un marco de vídeo?**

Sí. Utilice [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) y lea `getPictureFormat().getPicture().getImage()`. Esto extrae la imagen de póster almacenada con el marco de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no almacena enlaces inversos de [IPPImage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ippimage/) a las formas. Construya un mapeo durante el recorrido: cada vez que encuentre una referencia a una imagen, registre el número de diapositiva, la ruta de la forma y el hash o elemento de la colección de la imagen.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puede extraer la vista previa del objeto OLE desde [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Sin embargo, esa vista previa no es el documento incrustado propiamente dicho. Para extraer imágenes del archivo incrustado, extraiga los datos OLE y analícelos con herramientas específicas del tipo de archivo.