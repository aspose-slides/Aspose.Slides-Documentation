---
title: Javada Sunum Şekillerinden Görüntüleri Çıkarma
linktitle: Şekilden Görüntü
type: docs
weight: 100
url: /tr/java/extracting-images-from-presentation-shapes/
keywords:
- görüntü çıkar
- görüntü al
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu çözüm."
---
## **Genel Bakış**

Bir sunumdaki görüntüler birkaç şekil türünde görünebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurma olarak, OLE nesne önizleme görüntüleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma görüntüleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görüntüler olarak. Aspose.Slides bu görüntüleri sunum görüntü koleksiyonunda saklar ve bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesneleri aracılığıyla sunulur.

Sadece bir sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız gerekiyorsa `presentation.getImages()` üzerinden döngü yapın. Bu makale farklı bir göreve odaklanır: şekilleri dolaşarak görüntülerin slaytlarda nerede kullanıldığını bulmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma görüntüsü, medya önizlemesi, OLE önizlemesi veya yakınlaştırma görüntüsü) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="primary" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getBinaryData--) kullanarak orijinal kodlanmış görüntü verisini ve dosya türünü koruyun. Belirli bir format (ör. PNG) için çıktıyı normalleştirmek istediğinizde [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getImage--) ile [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `saveOriginalImage` gömülü baytları yazar, MIME türünden güvenli bir uzantı seçer ve SHA-256 hash ile yinelenen görüntü ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görüntüleri Çıkarma**

Bağımsız nesneler olarak eklenen resimler için bu yaklaşımı kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframe/) resmi `getPictureFormat().getPicture().getImage()` içinde depolar ve bu bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesi döndürür.

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

## **Resim Dolu Şekillerden Görüntüleri Çıkarma**

Şekiller bir resmi doldurma olarak kullanabilir. Önce şeklin doldurma türünü kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) değilse o doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshape/) nesnelerini işler ve her görüntüyü [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getImage--) aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleobjectframe/) PowerPoint’in slaytta nesnenin önizlemesi olarak kullandığı bir yedek resim içerebilir. Bu görüntü `getSubstitutePictureFormat().getPicture().getImage()` üzerinden erişilebilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriklerini değil önizleme görüntüsünü verir.

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

## **Video Çerçevelerinden Önizleme Görüntülerini Çıkarma

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) ayrıca `getPictureFormat().getPicture().getImage()` içinde bir önizleme resmi depolayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, videodan çözülen bir kare değildir.

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

## **Ses Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/) `getPictureFormat().getPicture().getImage()` içinde bir küçük resim depolayabilir. Bu, ses nesnesi için slaytta gösterilen görüntüdür.

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

## **Zoom Nesnelerinden Görüntüleri Çıkarma**

[IZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isectionzoomframe/) şekilleri özel resimler kullanabilir. Zoom çerçevesinden `getZoomImage()` okuyun.

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

## **Özet Zoom Çerçevelerinden Görüntüleri Çıkarma**

Bir [ISummaryZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/isummaryzoomframe/) de bir şekildir. Bölüm öğeleri özel resimler kullanabilir; bu resimler her özet zoom bölümünün `getZoomImage()` yöntemiyle ortaya çıkar.

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

## **Tablo Şekillerinden Görüntüleri Çıkarma**

Bir [ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides/itable/) bir şekildir. Tablodaki görüntüler genellikle tablo hücrelerindeki resim doldurmaları olarak depolanır.

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

## **Grafik Şekillerinden Görüntüleri Çıkarma**

Bir [IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/) bir şekildir. Aşağıdaki örnek grafik alanının resim doldurmasından bir görüntü çıkarır.

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

## **SmartArt Şekillerinden Görüntüleri Çıkarma**

Bir [ISmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ismartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görüntüler düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde depolanabilir.

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

## **Gruplanmış Şekiller İçindeki Görüntüleri Dahil Et**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı yöntemi bir `includeGroupedShapes` seçeneğine sahiptir. [IGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igroupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görüntüleri çıkarır. Tablo, grafik, SmartArt ve özet zoom görüntülerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını aynı yinelemeli şekil dolaşımıyla yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Duplicate images:** Multiple shapes may reference the same image or separate images with identical bytes. Hash [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getBinaryData--) before writing files if you want one output file per unique image.
- **Original data vs. converted output:** Saving [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getBinaryData--) preserves the embedded JPEG, PNG, GIF, SVG, EMF, or WMF data. Saving [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getImage--) through [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) is useful when you want a consistent output format.
- **Unsupported fill types:** Solid, gradient, pattern, and no-fill shapes do not contain a picture fill. Check [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/filltype/) before reading `getPictureFillFormat()`.
- **Grouped shapes:** The top-level slide shape collection does not flatten groups. Recursively inspect [IGroupShape.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igroupshape/#getShapes--) when grouped content matters.
- **OLE object previews:** An [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleobjectframe/) may expose a preview image through `getSubstitutePictureFormat()`, but that image is only the slide preview. It is not the embedded file inside the OLE object.
- **Video frame thumbnails:** An [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) may expose a preview image through `getPictureFormat()`, but that image is only the poster shown on the slide. It is not extracted from the video stream.
- **Audio frame thumbnails:** An [IAudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iaudioframe/) may expose an icon or thumbnail through `getPictureFormat()`; it is not the embedded audio data.
- **Zoom images:** Slide zoom, section zoom, and summary zoom shapes may use custom [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) objects through `getZoomImage()`.
- **Nested shape models:** Table, chart, and SmartArt objects implement [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/), but their images are often stored in nested table cell, chart element, or SmartArt node formatting objects.
- **Cropped or transformed pictures:** Accessing [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) gives you the stored image resource. It does not render cropping, transparency, recoloring, rotation, or other visual effects applied by the shape.

## **SSS**

**Orijinal görüntüyü kırpma, efekt veya şekil dönüşümleri olmadan çıkarabilir miyim?**

Evet. [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesine erişin ve [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getBinaryData--) yöntemini diske yazın. Bu, sunumda depolanan orijinal kodlanmış görüntüyü korur, slaytta görüntünün nasıl render edildiğini değil.

**Çıkarılan her görüntüyü PNG olarak dışa aktarabilir miyim?**

Evet. [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getImage--) kullanarak bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/) nesnesi elde edin ve ardından [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imageformat/) ile çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya türünü veya vektör verisini korumayabilir.

**Aynı görüntüyü birden fazla kez kaydetmekten nasıl kaçınırım?**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/#getBinaryData--) hash’i kullanın ve hash’leri bir kümede tutun. Yeni bir görüntünün hash’i zaten mevcutsa, dosyayı atlayın veya mevcut çıkış dosyasına başka bir referans kaydedin.

**Neden bazı şekiller görüntü üretmiyor?**

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, zoom çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntülere referans verebilir. Bazı şekil türleri görüntüleri iç içe biçimlendirme nesneleri aracılığıyla ortaya çıkarır; bu yüzden basit bir `getPictureFormat()` veya şekil `getFillFormat()` kontrolü her zaman yeterli olmayabilir.

**Bir video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ivideoframe/) kullanın ve `getPictureFormat().getPicture().getImage()` metodunu okuyun. Bu, video çerçevesiyle birlikte depolanan poster görüntüsünü çıkarır, video dosyasından üretilen bir kareyi değil.

**Sunum görüntü koleksiyonundaki belirli bir görüntüyü hangi şekillerin kullandığını nasıl belirleyebilirim?**

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ippimage/) nesnesinden şekillere geri bağlantılar tutmaz. Dolaşma sırasında bir harita oluşturun: bir görüntü referansı bulduğunuzda slayt numarasını, şekil yolunu ve görüntü hash’ini veya koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü görüntüleri, örneğin ekli belgeler gibi, çıkarabilir miyim?**

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) üzerinden OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgeyi içermez. Gömülü dosyanın içindeki görüntüleri çıkarmak için OLE verisini çıkarın ve dosya türüne uygun araçlarla inceleyin.