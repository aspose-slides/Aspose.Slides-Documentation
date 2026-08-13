---
title: Android'de Java ile Sunum Şekillerinden Görüntüleri Çıkarma
linktitle: Şekilden Görüntü
type: docs
weight: 100
url: /tr/androidjava/extracting-images-from-presentation-shapes/
keywords:
- görüntü çıkarma
- görüntü alma
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile Java üzerinden PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu çözüm."
---
## **Genel Bakış**

Sunumdaki görüntüler çeşitli şekil türlerinde görünebilir: normal resim çerçeveleri, şekillere uygulanan resim doldurmaları, OLE nesne önizleme görüntüleri, video veya ses çerçeve küçük resimleri, yakınlaştırma görüntüleri veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş görüntüler olarak. Aspose.Slides bu görüntüleri sunum görüntü koleksiyonunda saklar ve bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesneleri aracılığıyla sunulur.

Yalnızca bir sunuma gömülü tüm görüntü kaynaklarını dışa aktarmanız gerekiyorsa `presentation.getImages()` üzerine yineleme yapın. Bu makale farklı bir göreve odaklanır: slaytlarda görüntülerin nerede kullanıldığını bulmak için şekilleri taramak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma görüntüsü, medya önizleme, OLE önizleme veya yakınlaştırma görüntüsü) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="info" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) kullanarak orijinal kodlanmış görüntü verisini ve dosya tipini koruyun. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) ile [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `saveOriginalImage` gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 özetiyle yinelenen görüntü ikili dosyalarını atlar.

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

Bağımsız nesneler olarak eklenen resimler için bu yaklaşımı kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/) resmini `getPictureFormat().getPicture().getImage()` aracılığıyla saklar; bu, bir [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesi döndürür. [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) ve [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/) [IPictureFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ipictureframe/)'den türediği için bu `instanceof` kontrolü medya çerçevelerini de eşleştirir ve önizleme görüntülerini dışa aktarır; bunları ayrı olarak ele almak istediğinizde önce bu türleri test edin, bu sayfanın son örneğinde gösterildiği gibi.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **Resim Doldurmalı Şekillerden Görüntüleri Çıkarma**

Şekiller bir resmi doldurma olarak kullanabilir. Öncelikle şeklin doldurma tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) değilse, o doldurmadan çıkaracak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iautoshape/) nesnelerini ele alır ve her görüntüyü [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) aracılığıyla PNG olarak kaydeder.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;

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

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) PowerPoint’in slaytta nesnenin önizlemesi olarak kullandığı bir yedek resme sahip olabilir. Bu resim `getSubstitutePictureFormat().getPicture().getImage()` aracılığıyla elde edilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriklerini değil, önizleme görüntüsünü verir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **Video Çerçevelerinden Önizleme Görüntülerini Çıkarma**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) ayrıca `getPictureFormat().getPicture().getImage()` içinde bir önizleme resmi saklayabilir. Bu, slaytta gösterilen poster veya küçük resmdir, video akışından çözümlenen bir kare değildir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/) `getPictureFormat().getPicture().getImage()` içinde bir küçük resim saklayabilir. Bu, ses nesnesi için slaytta gösterilen görüntüdür.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[IZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isectionzoomframe/) şekilleri özel görüntüler kullanabilir. Zoom çerçevesinden `getZoomImage()` metodunu okuyun.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/isummaryzoomframe/) da bir şekildir. Bölüm öğeleri özel görüntüler kullanabilir; bu görüntüler her özet zoom bölümünün `getZoomImage()` yöntemiyle ortaya çıkar.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[ITable](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/itable/) bir şekildir. Bir tablodaki görüntüler genellikle tablo hücrelerindeki resim doldurmaları olarak depolanır.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[IChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görüntü çıkarır.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

[ISmartArt](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ismartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, görüntüler düğüm madde doldurmalarında veya düğüm şekillerinin doldurma formatlarında saklanabilir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **Gruplanmış Şekiller İçindeki Görüntüleri Dahil Etme**

Gruplanmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı yöntemi bir `includeGroupedShapes` seçeneğine sahiptir. [IGroupShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igroupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görüntüleri çıkarır. Tablo, grafik, SmartArt ve özet zoom görüntülerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını yeniden kullanın ve aynı özyineli şekil geçişini koruyun.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

- **Çift görseller:** Birden çok şekil aynı görüntüyü referans alabilir veya aynı baytlara sahip ayrı görüntüler olabilir. Tekil görüntü başına bir çıktı dosyası istiyorsanız dosyaları yazmadan önce [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) hash’ini alın.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) kaydetmek, gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisini korur. [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) üzerinden [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) kullanmak, çıktıyı PNG gibi tutarlı bir formata dönüştürmek istediğinizde yararlıdır.
- **Desteklenmeyen doldurma tipleri:** Katı, degrade, desen ve doldurma yok şekillerinde resim doldurması bulunmaz. `getPictureFillFormat()` okuma işlemine geçmeden önce [FillType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/filltype/) kontrol edin.
- **Gruplanmış şekiller:** En üst seviye slayt şekil koleksiyonu grupları düzleştirmez. Gruplandırılmış içerik önemliyse [IGroupShape.getShapes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/igroupshape/#getShapes--) üzerine özyineli denetim yapın.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) `getSubstitutePictureFormat()` aracılığıyla bir önizleme resmi ortaya çıkarabilir, ancak bu sadece slayt önizlemesidir. OLE nesnesinin içinde gömülü dosya bu değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/) `getPictureFormat()` aracılığıyla bir önizleme resmi sağlayabilir; bu sadece slaytta gösterilen poster/küçük resimdir, video akışından çıkarılan bir kare değildir.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iaudioframe/) `getPictureFormat()` üzerinden bir simge veya küçük resim sunabilir; bu gömülü ses verisi değildir.
- **Zoom görüntüleri:** Slayt zoom, bölüm zoom ve özet zoom şekilleri `getZoomImage()` aracılığıyla özel [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ishape/) uygular, ancak görüntüleri çoğu zaman iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) erişmek, depolanmış görüntü kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, renk değişikliği, döndürme veya diğer görsel etkileri yansıtmaz.

## **SSS**

### Görüntüyü kırpma, efekt veya şekil dönüşümleri olmadan orijinal halinden çıkarabilir miyim?

Evet. [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesine erişin ve [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--)’ı diske yazın. Bu, sunumda saklanan orijinal kodlanmış görüntüyü korur, slaytta nasıl render edildiğiyle ilgili herhangi bir değişikliği içermez.

### Çıkarılan her görüntüyü PNG olarak dışa aktarabilir miyim?

Evet. [IPPImage.getImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getImage--) ile bir [IImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/) nesnesi alın ve ardından [IImage.save](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imageformat/) ile çağırın. Bu, çıktıyı PNG’ye dönüştürür ve orijinal dosya türü ya da vektör verisini korumayabilir.

### Aynı görüntüyü birden fazla kez kaydetmemeyi nasıl sağlarım?

[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/#getBinaryData--) değerinin hash’ini alın ve bu hash’leri bir kümede tutun. Yeni bir görüntünün hash’i zaten kümede varsa, dosyayı atlayın ya da mevcut çıktı dosyasına bir başka referans kaydedin.

### Bazı şekiller neden görüntü üretmiyor?

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, zoom çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görüntü referanslayabilir. Bazı şekil türleri görüntüleri iç içe biçimlendirme nesneleri aracılığıyla ortaya çıkarır; bu nedenle basit bir `getPictureFormat()` veya şekil `getFillFormat()` kontrolü her zaman yeterli değildir.

### Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?

Evet. [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) kullanın ve `getPictureFormat().getPicture().getImage()` okuyun. Bu, video çerçevesiyle birlikte saklanan poster/önizleme görüntüsünü çıkarır; video dosyasından üretilen bir kare değildir.

### Sunum görüntü koleksiyonundaki belirli bir görüntüyü hangi şekiller kullandığını nasıl belirleyebilirim?

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ippimage/) nesnesinden şekillere ters bağlantı tutmaz. Gezinme sırasında bir eşleme oluşturun: bir görüntü referansı bulduğunuzda slayt numarasını, şekil yolunu ve görüntü hash’ini veya koleksiyon öğesini kaydedin.

### OLE nesneleri içinde gömülü belgeler gibi görüntüleri çıkarabilir miyim?

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgeyi temsil etmez. İç gömülü dosyadan görüntü çıkarmak için OLE verisini ayıklayın ve ilgili dosya türü araçlarıyla inceleyin.