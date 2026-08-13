---
title: Java'da Sunum Şekillerinden Görselleri Çıkarma
linktitle: Şekilden Görsel
type: docs
weight: 100
url: /tr/java/extracting-images-from-presentation-shapes/
keywords:
- görsel çıkar
- görsel al
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görselleri çıkarın - hızlı, kod dostu çözüm."
---
## **Genel Bakış**

Sunumdaki görseller çeşitli şekil türlerinde görülebilir: normal resim çerçeveleri olarak, şekillere uygulanan resim doldurması olarak, OLE nesne önizleme görselleri olarak, video veya ses çerçevesi küçük resimleri olarak, yakınlaştırma görselleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe yer alan görseller olarak. Aspose.Slides bu görselleri sunum görüntü koleksiyonunda saklar ve bu koleksiyon [IImageCollection](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iimagecollection/) ve [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) nesneleri aracılığıyla sunulur.

Yalnızca bir sunuma gömülü tüm görsel kaynaklarını dışa aktarmanız gerekiyorsa `presentation.getImages()` üzerinden yineleyin. Bu makale, görsellerin slaytlarda nerelerde kullanıldığını bulmak için şekilleri dolaşmaya odaklanır; böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma görseli, medya önizleme, OLE önizleme veya yakınlaştırma görseli) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="info" %}}
Orijinal kodlanmış görsel verisini ve dosya türünü korumak için [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getBinaryData--) kullanın. Çıktıyı PNG gibi belirli bir formata normalleştirmek istediğinizde [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getImage--) ile [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iimage/#save-java.lang.String-int-) kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `saveOriginalImage` gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA‑256 özetine göre yinelenen görsel ikili dosyalarını atlar.

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

## **Resim Çerçevelerinden Görselleri Çıkar**

Bu yaklaşımı bağımsız nesne olarak eklenmiş resimler için kullanın. Bir [IPictureFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ipictureframe/) resmini `getPictureFormat().getPicture().getImage()` içinde saklar; bu çağrı bir [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) nesnesi döndürür.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Resim Doldurmalı Şekillerden Görselleri Çıkar**

Şekiller bir resmi doldurma olarak kullanabilir. Öncelikle şeklin doldurma tipini kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/java/com.aspose.slides.filltype/) değilse, bu doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [IAutoShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iautoshape/) nesnelerini ele alır ve her görseli [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getImage--) ile PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ioleobjectframe/) PowerPoint'in bir nesnenin slayt üzerindeki önizlemesi olarak kullandığı bir alternatif resim içerebilir. Bu resim `getSubstitutePictureFormat().getPicture().getImage()` aracılığıyla elde edilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriği yerine önizleme görselini verir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Video Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ivideoframe/) ayrıca `getPictureFormat().getPicture().getImage()` içinde bir önizleme resmi saklayabilir. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülmüş bir çerçeve değildir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Ses Çerçevelerinden Önizleme Görselleri Çıkar**

Bir [IAudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iaudioframe/) `getPictureFormat().getPicture().getImage()` içinde bir küçük resim saklayabilir. Bu, ses nesnesi için slaytta gösterilen görseldir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Yakınlaştırma Nesnelerinden Görselleri Çıkar**

[IZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.izoomframe/) ve [ISectionZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.isectionzoomframe/) şekilleri özel görseller kullanabilir. Yakınlaştırma çerçevesinden `getZoomImage()` okuyun.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Özet Yakınlaştırma Çerçevelerinden Görselleri Çıkar**

[ISummaryZoomFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.isummaryzoomframe/) da bir şekildir. Bölüm öğeleri özel görseller kullanabilir; bu görseller her özet yakınlaştırma bölümünün `getZoomImage()` yöntemiyle ortaya çıkar.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Tablo Şekillerinden Görselleri Çıkar**

[ITable](https://reference.aspose.com/slides/tr/java/com.aspose.slides.itable/) bir şekildir. Tablodaki görseller genellikle tablo hücrelerindeki resim doldurmaları olarak saklanır.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **Grafik Şekillerinden Görselleri Çıkar**

[IChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ichart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir görsel çıkarır.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **SmartArt Şekillerinden Görselleri Çıkar**

[ISmartArt](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ismartart/) bir şekildir. SmartArt düzenine bağlı olarak görseller düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma biçimlerinde saklanabilir.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **Gruplandırılmış Şekiller İçindeki Görselleri Dahil Et**

Gruplandırılmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı yöntemi bir `includeGroupedShapes` seçeneğine sahiptir. [IGroupShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides.igroupshape/) nesneleri içinde şekilleri incelemek istiyorsanız bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden görselleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma görsellerini de dahil etmek için önceki bölümlerdeki özel çıkarma mantığını yeniden kullanın ve aynı yinelemeli şekil geçişini sürdürün.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

- **Yinelenen görseller:** Birden çok şekil aynı görsele ya da aynı baytlara sahip ayrı görsellere referans verebilir. Tek bir benzersiz görsel için bir çıktı dosyası istiyorsanız dosyaları yazmadan önce [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getBinaryData--) özetini alın.
- **Orijinal veri vs. dönüştürülmüş çıktı:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getBinaryData--) kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisini korur. [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getImage--) üzerinden [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iimage/#save-java.lang.String-int-) kaydetmek tutarlı bir çıktı formatı istediğinizde faydalıdır.
- **Desteklenmeyen doldurma türleri:** Katı, degrade, desen ve doldurma yok şekiller resim doldurması içermez. `getPictureFillFormat()` okumadan önce [FillType](https://reference.aspose.com/slides/tr/java/com.aspose.slides.filltype/) kontrol edin.
- **Gruplandırılmış şekiller:** Üst‑seviye slayt şekil koleksiyonu grupları düzleştirmez. Gruplandırılmış içerik önemliyse [IGroupShape.getShapes](https://reference.aspose.com/slides/tr/java/com.aspose.slides.igroupshape/#getShapes--) öğesini yinelemeli olarak inceleyin.
- **OLE nesne önizlemeleri:** Bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ioleobjectframe/) `getSubstitutePictureFormat()` aracılığıyla bir önizleme resmi gösterebilir, ancak bu resim yalnızca slayt önizlemesidir; OLE nesnesinin içindeki gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ivideoframe/) `getPictureFormat()` üzerinden bir önizleme resmi sunabilir; bu sadece slaytta gösterilen poster/görseldir, video akışından çıkarılmış bir çerçeve değildir.
- **Ses çerçeve küçük resimleri:** Bir [IAudioFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iaudioframe/) `getPictureFormat()` üzerinden bir simge veya küçük resim sağlayabilir; bu, gömülü ses verisi değildir.
- **Yakınlaştırma görselleri:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri `getZoomImage()` aracılığıyla özel [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ishape/) uygular, ancak görselleri çoğunlukla iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) erişmek, depolanmış görsel kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, renk değiştirme, döndürme veya diğer görsel efektleri yansıtmaz.

## **SSS**

### Orijinal resmi kırpmalar, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?

Evet. [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) nesnesine erişin ve [IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getBinaryData--)'yi diske yazın. Bu, sunumda saklanan orijinal kodlanmış görseli korur; slaytta nasıl render edildiğiyle ilgili hiçbir kesme, efekt veya dönüşüm uygulanmaz.

### Her çıkarılan resmi PNG olarak dışa aktarabilir miyim?

Evet. [IPPImage.getImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getImage--) ile bir [IImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iimage/) nesnesi alın ve ardından [IImage.save](https://reference.aspose.com/slides/tr/java/com.aspose.slides.iimage/#save-java.lang.String-int-) metodunu [ImageFormat.Png](https://reference.aspose.com/slides/tr/java/com.aspose.slides.imageformat/) ile çağırın. Bu, çıktıyı PNG’ye dönüştürür ancak orijinal dosya türünü veya vektör verisini korumaz.

### Aynı görseli birden fazla kez kaydetmemeyi nasıl sağlayabilirim?

[IPPImage.getBinaryData](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/#getBinaryData--) özetini bir hash olarak alın ve bu özetleri bir kümede tutun. Yeni bir görselin özeti zaten mevcutsa, dosyayı atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

### Bazı şekiller neden görsel üretmiyor?

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri görsellere referans verebilir. Bazı şekil tipleri görselleri iç içe biçimlendirme nesneleri aracılığıyla sunar; bu yüzden basit bir `getPictureFormat()` ya da şekil `getFillFormat()` kontrolü her zaman yeterli olmayabilir.

### Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?

Evet. [IVideoFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ivideoframe/) kullanın ve `getPictureFormat().getPicture().getImage()` okuyun. Bu, video çerçevesiyle birlikte depolanmış poster görselini çıkarır; videodan dinamik olarak oluşturulmuş bir çerçeve değildir.

### Sunum görüntü koleksiyonundaki belirli bir görseli hangi şekiller kullandığını nasıl belirleyebilirim?

Aspose.Slides, [IPPImage](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ippimage/) nesnesinden şekillere ters bağlantılar saklamaz. Gezinme sırasında bir görsel referansı bulduğunuzda, slayt numarasını, şekil yolunu ve görsel özetini veya koleksiyon öğesini kaydedin; bu şekilde hangi şekillerin belirli bir görseli kullandığını izleyebilirsiniz.

### OLE nesneleri içinde gömülü, örneğin ekli belgeler gibi, görselleri çıkarabilir miyim?

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) üzerinden OLE nesnesinin slayt önizlemesini çıkarabilirsiniz. Ancak bu önizleme, gömülü belgenin kendisi değildir. Görselleri gömülü dosyanın içinden çıkarmak için OLE verisini ayıklayın ve ilgili dosya türü araçlarıyla inceleyin.