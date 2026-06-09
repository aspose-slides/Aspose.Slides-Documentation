---
title: "Android'de Java ile Sunum Şekillerinden Görüntü Çıkarma"
linktitle: "Şekilden Görüntü"
type: docs
weight: 100
url: /tr/androidjava/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkarma
- görsel getirme
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu bir çözüm."
---
## **Overview**

Bir sunumdaki görüntüler çeşitli şekil türlerinde görünebilir: normal fotoğraf çerçeveleri olarak, şekillere uygulanan fotoğraf doldurmaları olarak, OLE nesne önizleme görüntüleri olarak, video veya ses çerçevesi küçük resimleri olarak, yakınlaştırma görüntüleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görüntüler olarak. Aspose.Slides bu görüntüleri sunum görüntü koleksiyonunda depolar ve bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesneleri aracılığıyla sunulur.

Yalnızca bir sunuma gömülü olan her görüntü kaynağını dışa aktarmanız gerekiyorsa `presentation.getImages()` üzerinden yineleyin. Bu makale farklı bir göreve odaklanır: slaytlarda görüntülerin nerede kullanıldığını bulmak için şekilleri dolaşmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (fotoğraf çerçevesi, doldurma görüntüsü, medya önizleme, OLE önizleme veya yakınlaştırma görüntüsü) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="primary" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) kullanarak orijinal kodlanmış görüntü verisini ve dosya türünü koruyun. Çıktıyı PNG gibi belirli bir biçime normalleştirmek istediğinizde [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) ile [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanın.
{{% /alert %}}

## **Shared Helper Methods**

Aşağıdaki yardımcı yöntemler örnekleri kısaltır. `saveOriginalImage` orijinal gömülü baytları yazar, MIME türünden güvenli bir uzantı seçer ve SHA-256 karmasıyla yinelenen görüntü ikili dosyalarını atlar.

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

## **Extract Images from Picture Frames**

Bağımsız nesneler olarak eklenen resimler için bu yaklaşımı kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) fotoğrafını `getPictureFormat().getPicture().getImage()` içinde saklar ve bu da bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesi döndürür.

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

## **Extract Images from Picture-Filled Shapes**

Şekiller bir resmi doldurma olarak kullanabilir. Önce şeklin doldurma tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değilse, o doldurmadan çıkartılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnelerini ele alır ve her görüntüyü [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) aracılığıyla PNG olarak kaydeder.

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

## **Extract Preview Images from OLE Object Frames**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) bir yedek resim içerebilir; PowerPoint bu resmi slayd üzerindeki nesnenin önizlemesi olarak kullanır. Bu görüntü `getSubstitutePictureFormat().getPicture().getImage()` aracılığıyla erişilebilir. Bu resmi çıkartmak, OLE paketinin gömülü içeriğini değil, önizleme görüntüsünü verir.

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

## **Extract Preview Images from Video Frames**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) aynı zamanda `getPictureFormat().getPicture().getImage()` içinde bir önizleme resmi depolayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülen bir kare değildir.

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

## **Extract Preview Images from Audio Frames**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/) `getPictureFormat().getPicture().getImage()` içinde bir küçük resim saklayabilir. Bu, slayttaki ses nesnesi için gösterilen görüntüdür.

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

## **Extract Images from Zoom Objects**

[IZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectionzoomframe/) şekilleri özel görüntüler kullanabilir. Yakınlaştırma çerçevesinden `getZoomImage()` okuyun.

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

## **Extract Images from Summary Zoom Frames**

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isummaryzoomframe/) da bir şekildir. Bölüm öğeleri özel görüntüler kullanabilir; her özet yakınlaştırma bölümünün `getZoomImage()` yöntemi aracılığıyla bu görüntüler ortaya çıkar.

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

## **Extract Images from Table Shapes**

[ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) bir şekildir. Bir tablodaki görüntüler genellikle tablo hücrelerinde resim doldurmaları olarak saklanır.

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

## **Extract Images from Chart Shapes**

[IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görüntü çıkartır.

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

## **Extract Images from SmartArt Shapes**

[ISmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görüntüler düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde saklanabilir.

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

## **Include Images Inside Grouped Shapes**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı metodunda bir `includeGroupedShapes` seçeneği bulunur. [IGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igroupshape/) nesneleri içinde şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek fotoğraf çerçeveleri, fotoğraf doldurmalı şekiller, OLE nesne önizlemeleri, video çerçeve küçük resimleri ve ses çerçeve küçük resimlerinden görüntüler çıkartır. Tablo, grafik, SmartArt ve özet yakınlaştırma görüntülerini de dahil etmek için önceki bölümlerdeki özelleştirilmiş çıkartma mantığını aynı yinelemeli şekil geçişi içinde yeniden kullanın.

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

## **Edge Cases and Practical Notes**

- **Duplicate images:** Birden fazla şekil aynı görüntüyü veya aynı baytlara sahip ayrı görüntüleri referans alabilir. Tek bir benzersiz görüntü başına bir çıktı dosyası oluşturmak istiyorsanız dosya yazmadan önce [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) karmasını hesaplayın.
- **Original data vs. converted output:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ile kaydetmek, gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisini korur. [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) ve ardından [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanmak, tutarlı bir çıktı biçimi (ör. PNG) istediğinizde faydalıdır.
- **Unsupported fill types:** Katı, degradeli, desenli ve doldurma olmayan şekiller resim doldurması içermez. `getPictureFillFormat()` okuma öncesinde [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) kontrol edin.
- **Grouped shapes:** Üst‑seviye slayt şekil koleksiyonu grupları düzleştirmez. Grupların içeriği önemliyse [IGroupShape.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igroupshape/#getShapes--) metodunu yinelemeli olarak inceleyin.
- **OLE object previews:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) `getSubstitutePictureFormat()` aracılığıyla bir önizleme görüntüsü sunabilir, ancak bu sadece slayt önizlemesidir. OLE nesnesinin içindeki gömülü dosya bu görüntü değildir.
- **Video frame thumbnails:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) `getPictureFormat()` üzerinden bir önizleme resmi sunabilir; bu sadece slaytta gösterilen poster, video akışından bir çerçeve değildir.
- **Audio frame thumbnails:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/) `getPictureFormat()` üzerinden bir simge veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Zoom images:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri, `getZoomImage()` aracılığıyla özel [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesneleri kullanabilir.
- **Nested shape models:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) uygular, ancak görüntüleri çoğu zaman iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Cropped or transformed pictures:** [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) erişmek, saklanan görüntü kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, renk değiştirme, döndürme veya diğer görsel etkileri yansıtmaz.

## **FAQ**

**Orijinal görüntüyü kırpma, efekt veya şekil dönüşümleri olmadan çıkarabilir miyim?**

Evet. [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesine erişin ve [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) disk’e yazın. Bu, slaytta nasıl render edildiği değil, sunum içinde depolanan orijinal kodlanmış görüntüyü korur.

**Çıkarılan tüm görüntüleri PNG olarak dışa aktarabilir miyim?**

Evet. [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) ile bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesi alın ve ardından [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) ile çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya türü ya da vektör verisini korumayabilir.

**Aynı görüntüyü birden fazla kez kaydetmemeyi nasıl sağlarım?**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) karmasını alıp bir kümede tutun. Yeni bir görüntünün karması zaten kümede varsa, dosyayı atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

**Bazı şekiller neden görüntü üretmiyor?**

Fotoğraf çerçeveleri, fotoğraf doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntü referansları içerebilir. Bazı şekil tipleri görüntüleri iç içe biçimlendirme nesneleri üzerinden sunar; bu yüzden basit bir `getPictureFormat()` ya da şekil `getFillFormat()` kontrolü her zaman yeterli değildir.

**Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) kullanın ve `getPictureFormat().getPicture().getImage()` okuyun. Bu, video çerçevesiyle birlikte depolanan poster görüntüsünü çıkarır, video dosyasından üretilen bir çerçeve değildir.

**Sunum görüntü koleksiyonundan belirli bir görüntüyü kullanan şekilleri nasıl belirleyebilirim?**

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesinden şekillere ters bağlantılar tutmaz. Gezinme sırasında bir görüntü referansı bulduğunuzda slayt numarasını, şekil yolunu ve görüntü karmasını veya koleksiyon öğesini kaydederek bir eşleme oluşturun.

**OLE nesneleri içinde gömülü olan, örneğin ekli belgeler gibi, görüntüleri çıkarabilir miyim?**

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgenin kendisi değildir. Gömülü dosyanın içindeki görüntüleri çıkarmak için OLE verisini dışa aktarın ve dosya türüne uygun araçlarla inceleyin.