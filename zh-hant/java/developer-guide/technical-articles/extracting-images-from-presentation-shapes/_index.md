---
title: 從 Java 簡報形狀中擷取圖像
linktitle: 形狀中的圖像
type: docs
weight: 100
url: /zh-hant/java/extracting-images-from-presentation-shapes/
keywords:
- 擷取圖像
- 取得圖像
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "從 PowerPoint 與 OpenDocument 簡報的形狀中擷取圖像，使用 Aspose.Slides for Java - 快速、程式友善的解決方案。"
---
## **概述**

簡報中的圖像可以出現在多種形狀類型中：普通圖片框、套用於形狀的圖片填充、OLE 物件預覽圖像、影片或音訊框的縮圖、縮放圖像，或是嵌入在表格、圖表與 SmartArt 形狀內的圖像。Aspose.Slides 將這些圖像儲存在簡報的圖像集合中，透過 [IImageCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iimagecollection/) 與 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 物件公開。

如果您只需要匯出簡報中嵌入的每個圖像資源，只要遍歷 `presentation.getImages()` 即可。本文聚焦於另一項任務：遍歷形狀以找出投影片上使用圖像的地方，讓儲存的檔案能保留有用的上下文資訊，如投影片編號、形狀位置與來源類型（圖片框、填充圖像、媒體預覽、OLE 預覽或縮放圖像）。

{{% alert title="Tip" color="info" %}}
使用 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getBinaryData--) 以保留原始編碼的圖像資料與檔案類型。當您想將輸出正規化為特定格式（如 PNG）時，請使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getImage--) 搭配 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iimage/#save-java.lang.String-int-)。
{{% /alert %}}

## **共用輔助方法**

以下輔助方法可讓範例保持簡潔。`saveOriginalImage` 會寫入原始嵌入的位元組，根據 MIME 類型選擇安全的副檔名，並透過 SHA-256 雜湊避免寫入重複的圖像二進位資料。

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

## **從圖片框擷取圖像**

對於作為獨立物件插入的圖片，請使用此方式。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ipictureframe/) 會將圖片儲存在 `getPictureFormat().getPicture().getImage()`，該方法返回一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 物件。

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

## **從填充圖片的形狀擷取圖像**

形狀可以將圖片作為填充。先檢查形狀的填充類型：若不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.filltype/)，則該填充不含圖片可供擷取。以下範例處理 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iautoshape/) 物件，並透過 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getImage--) 以 PNG 格式保存每個圖像。

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

## **從 OLE 物件框擷取預覽圖像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ioleobjectframe/) 可能有 PowerPoint 在投影片上用作物件預覽的替代圖片。此圖像可透過 `getSubstitutePictureFormat().getPicture().getImage()` 取得。擷取此圖片會得到預覽圖像，而非嵌入的 OLE 套件內容。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **從影片框擷取預覽圖像**

[IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ivideoframe/) 也可以在 `getPictureFormat().getPicture().getImage()` 中儲存預覽圖像。這是投影片上顯示的海報或縮圖，並非從影片串流解碼出的畫格。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **從音訊框擷取預覽圖像**

[IAudioFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iaudioframe/) 可以在 `getPictureFormat().getPicture().getImage()` 中儲存縮圖。這是投影片上顯示的音訊物件圖示。

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

## **從縮放物件擷取圖像**

[IZoomFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.izoomframe/) 與 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.isectionzoomframe/) 形狀可以使用自訂圖像。從縮放框讀取 `getZoomImage()`。

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

## **從摘要縮放框擷取圖像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.isummaryzoomframe/) 同樣是一個形狀。其各節項目可以使用自訂圖像，透過每個摘要縮放節的 `getZoomImage()` 方法公開。

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

## **從表格形狀擷取圖像**

[ITable](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.itable/) 是一個形狀。表格中的圖像通常以表格儲存格的圖片填充形式儲存。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
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

## **從圖表形狀擷取圖像**

[IChart](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ichart/) 是一個形狀。以下範例從圖表區域的圖片填充中擷取圖像。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

## **從 SmartArt 形狀擷取圖像**

[ISmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ismartart/) 物件是形狀。根據 SmartArt 版面配置，圖片可能儲存在節點項目的項目符號填充或節點形狀的填充格式中。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util Set;
import java.util List;

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

## **包含群組形狀內的圖像**

群組形狀包含自己的形狀集合。共用的 `enumerateShapes` 輔助方法提供 `includeGroupedShapes` 參數。當您想檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.igroupshape/) 物件內的形狀時，將其設為 `true`。下方範例從圖片框、填充圖片的形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中擷取圖像。若要同時包含表格、圖表、SmartArt 與摘要縮放圖像，請在相同的遞迴形狀遍歷中重新使用前述各段落的專門擷取邏輯。

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

## **邊緣情況與實務說明**

- **重複圖像：** 多個形狀可能參照相同圖像，或是不同圖像卻有相同位元組。寫入檔案前先對 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getBinaryData--) 做雜湊，以確保每個唯一圖像只產生一個輸出檔案。
- **原始資料與轉換後輸出：** 保存 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getBinaryData--) 會保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。透過 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getImage--) 搭配 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iimage/#save-java.lang.String-int-) 保存則適用於需要統一輸出格式的情況。
- **不支援的填充類型：** 純色、漸層、圖案與無填充形狀不含圖片填充。讀取 `getPictureFillFormat()` 前，請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.filltype/)。
- **群組形狀：** 投影片的頂層形狀集合不會自動展平群組。當群組內容重要時，請遞迴檢查 [IGroupShape.getShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.igroupshape/#getShapes--)。
- **OLE 物件預覽：** [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ioleobjectframe/) 可能透過 `getSubstitutePictureFormat()` 暴露預覽圖像，但該圖像僅為投影片預覽，並非嵌入於 OLE 物件內的檔案。
- **影片框縮圖：** [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ivideoframe/) 可能透過 `getPictureFormat()` 暴露預覽圖像，該圖像僅為投影片上顯示的海報，並非從影片串流中擷取的畫格。
- **音訊框縮圖：** [IAudioFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iaudioframe/) 可能透過 `getPictureFormat()` 暴露圖示或縮圖；這不是嵌入的音訊資料。
- **縮放圖像：** 投影片縮放、節區縮放與摘要縮放形狀可能使用自訂的 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 物件，透過 `getZoomImage()` 取得。
- **巢狀形狀模型：** 表格、圖表與 SmartArt 物件皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ishape/)，但它們的圖像通常儲存在巢狀的表格儲存格、圖表元素或 SmartArt 節點格式物件中。
- **裁切或變形的圖片：** 取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 只能得到儲存的圖像資源，並不會套用形狀所做的裁切、透明度、重新著色、旋轉或其他視覺效果。

## **常見問題**

### 我能否在不裁切、套用效果或形狀變形的情況下擷取原始圖像？

可以。存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 物件，將 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getBinaryData--) 寫入磁碟，即可保留簡報中存放的原始編碼圖像，而非投影片上呈現的樣子。

### 我可以將所有擷取的圖像匯出為 PNG 嗎？

可以。使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getImage--) 取得 [IImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iimage/) 物件，然後以 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.imageformat/) 呼叫 [IImage.save](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.iimage/#save-java.lang.String-int-)。此方式會將輸出轉換為 PNG，可能不會保留原始檔案類型或向量資料。

### 如何避免同一圖像被多次保存？

對 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/#getBinaryData--) 計算雜湊，並將雜湊值存入集合。若新圖像的雜湊已存在，則跳過寫入或改為記錄對已有輸出檔案的另一個參照。

### 為什麼有些形狀不會產生圖像？

圖片框、填充圖片的形狀、OLE 物件框、媒體框、縮放框、表格、圖表與 SmartArt 物件都可能參照圖像。某些形狀類型的圖像是透過巢狀的格式物件暴露的，因此僅檢查 `getPictureFormat()` 或形狀的 `getFillFormat()` 並不足以找出所有圖像。

### 我能否擷取影片框顯示的縮圖？

可以。使用 [IVideoFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ivideoframe/) 並讀取 `getPictureFormat().getPicture().getImage()`。此操作擷取的是隨影片框儲存的海報圖像，而非從影片檔案中生成的畫格。

### 我該如何判斷哪些形狀使用了簡報圖像集合中的特定圖像？

Aspose.Slides 並未為 [IPPImage](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ippimage/) 保持返回到形狀的反向連結。遍歷時建立映射：每當發現圖像參照時，記錄投影片編號、形狀路徑以及圖像雜湊或集合項目。

### 我能否擷取嵌入在 OLE 物件內的圖像（例如附加的文件）？

您可以透過 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) 取得 OLE 物件的投影片預覽圖像。然而，該預覽並非嵌入的文件本身。若要從嵌入的檔案內部擷取圖像，需先抽取 OLE 資料，然後使用相應檔案類型的工具進行檢查。