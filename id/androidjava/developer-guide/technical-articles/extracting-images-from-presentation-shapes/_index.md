---
title: Mengekstrak Gambar dari Bentuk Presentasi di Android via Java
linktitle: Gambar dari Bentuk
type: docs
weight: 100
url: /id/androidjava/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Mengekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android via Java - solusi cepat dan ramah kode."
---
## **Gambaran Umum**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai gambar miniatur bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang bersarang di dalam bentuk tabel, diagram, dan SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui [IImageCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimagecollection/) dan [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) .

Jika Anda hanya perlu mengekspor setiap sumber gambar yang disematkan dalam presentasi, iterasikan melalui `presentation.getImages()`. Artikel ini berfokus pada tugas yang berbeda: menelusuri bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat menyimpan konteks berguna seperti nomor slide, posisi bentuk, dan tipe sumber (bingkai gambar, gambar isian, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}
Gunakan [IPPImage.getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getBinaryData--) untuk mempertahankan data gambar yang dikodekan asli dan tipe file. Gunakan [IPPImage.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getImage--) dengan [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ketika Anda ingin menormalkan output ke format tertentu seperti PNG.
{{% /alert %}}

## **Metode Bantu Bersama**

Metode bantu di bawah ini menjaga contoh tetap singkat. `saveOriginalImage` menulis byte asli yang disematkan, memilih ekstensi aman dari tipe MIME, dan melewati duplikat biner gambar dengan hash SHA‑256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang disisipkan sebagai objek mandiri. Sebuah [IPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipictureframe/) menyimpan gambarnya di `getPictureFormat().getPicture().getImage()`, yang mengembalikan objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) .

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa tipe isian bentuk terlebih dahulu: jika bukan [FillType.Picture](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/filltype/), tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [IAutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iautoshape/) dan menyimpan setiap gambar sebagai PNG melalui [IPPImage.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getImage--) .

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `getSubstitutePictureFormat().getPicture().getImage()`. Mengekstrak gambar ini memberi Anda gambar pratinjau, bukan isi paket OLE yang disematkan.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) juga dapat menyimpan gambar pratinjau di `getPictureFormat().getPicture().getImage()`. Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/) dapat menyimpan thumbnail di `getPictureFormat().getPicture().getImage()`. Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

[IZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/izoomframe/) dan [ISectionZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isectionzoomframe/) dapat menggunakan gambar khusus. Baca `getZoomImage()` dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [ISummaryZoomFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/isummaryzoomframe/) juga merupakan bentuk. Item bagiannya dapat menggunakan gambar khusus, yang diekspos melalui metode `getZoomImage()` masing‑masing pada bagian zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itable/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar di sel tabel.

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

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [IChart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ichart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area diagram.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Sebuah [ISmartArt](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartart/) adalah bentuk. Bergantung pada tata letak SmartArt, gambar dapat disimpan di isian bullet node atau di format isian bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk Berkelompok**

Bentuk berkelompok memiliki koleksi bentuk masing‑masing. Metode bantu bersama `enumerateShapes` memiliki opsi `includeGroupedShapes`. Setel ke `true` ketika Anda ingin memeriksa bentuk di dalam objek [IGroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igroupshape/) . Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Khusus dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk pada gambar yang sama atau gambar terpisah dengan byte yang identik. Hash [IPPImage.getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getBinaryData--) sebelum menulis file jika Anda menginginkan satu file output per gambar unik.
- **Data asli vs. output yang diubah:** Menyimpan [IPPImage.getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getBinaryData--) mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang disematkan. Menyimpan [IPPImage.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getImage--) melalui [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) berguna ketika Anda menginginkan format output yang konsisten.
- **Tipe isian yang tidak didukung:** Bentuk padat, gradien, pola, dan tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/filltype/) sebelum membaca `getPictureFillFormat()`.
- **Bentuk berkelompok:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa secara rekursif [IGroupShape.getShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igroupshape/#getShapes--) ketika konten berkelompok penting.
- **Pratinjau objek OLE:** Sebuah [IOleObjectFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/) dapat menampilkan gambar pratinjau melalui `getSubstitutePictureFormat()`, tetapi gambar tersebut hanya pratinjau slide. Itu bukan file yang disematkan di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [IVideoFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/) dapat menampilkan gambar pratinjau melalui `getPictureFormat()`, tetapi gambar tersebut hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [IAudioFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iaudioframe/) dapat menampilkan ikon atau thumbnail melalui `getPictureFormat()`; itu bukan data audio yang disematkan.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) khusus melalui `getZoomImage()`.
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/), tetapi gambar mereka sering disimpan dalam objek format sel tabel, elemen diagram, atau node SmartArt yang bersarang.
- **Gambar yang dipotong atau diubah:** Mengakses [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) memberi Anda sumber gambar yang disimpan. Itu tidak menerapkan pemotongan, transparansi, pewarnaan ulang, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **FAQ**

**Apakah saya dapat mengekstrak gambar asli tanpa memotong, menambah efek, atau transformasi bentuk?**

Ya. Akses objek [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) dan tulis [IPPImage.getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ke disk. Ini mempertahankan gambar terkode asli yang disimpan dalam presentasi, bukan cara gambar dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [IPPImage.getImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getImage--) untuk mendapatkan objek [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) , lalu panggil [IImage.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) dengan [ImageFormat.Png](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imageformat/). Ini mengubah output dan mungkin tidak mempertahankan tipe file atau data vektor asli.

**Bagaimana cara menghindari penyimpanan gambar yang sama lebih dari sekali?**

Gunakan hash dari [IPPImage.getBinaryData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/#getBinaryData--) dan simpan hash tersebut dalam satu set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke file output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk pada gambar. Beberapa tipe bentuk menampilkan gambar melalui objek format bersarang, sehingga pemeriksaan sederhana `getPictureFormat()` atau `getFillFormat()` pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) dan baca `getPictureFormat().getPicture().getImage()`. Ini mengekstrak gambar poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari file video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [IPPImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ippimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash atau item koleksi gambar.

**Apakah saya dapat mengekstrak gambar yang disematkan di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide dari [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) . Namun, pratinjau tersebut bukan dokumen yang disematkan itu sendiri. Untuk mengekstrak gambar dari dalam file yang disematkan, ekstrak data OLE dan periksa dengan alat untuk tipe file tersebut.