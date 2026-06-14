---
title: 從 Android Java 中的簡報形狀擷取影像
linktitle: 形狀影像
type: docs
weight: 100
url: /zh-hant/androidjava/extracting-images-from-presentation-shapes/
keywords:
- 擷取影像
- 取得影像
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 從 PowerPoint 與 OpenDocument 簡報的形狀中擷取影像 - 快速、程式碼友好的解決方案。"
---
## **概觀**

Presentation 中的影像可以以多種形狀類型呈現：普通的圖片框、填入形狀的圖片填充、OLE 物件預覽影像、影片或音訊框的縮圖、縮放影像，或是嵌入在表格、圖表和 SmartArt 形狀內的影像。Aspose.Slides 會將這些影像儲存在簡報的影像集合中，透過 [IImageCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimagecollection/) 與 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件提供存取。

如果只需要匯出簡報中嵌入的每一個影像資源，只要遍歷 `presentation.getImages()` 即可。本篇文章聚焦於另一個任務：遍歷形狀以找出投影片中使用影像的位置，讓儲存的檔案能保留投影片編號、形狀位置與來源類型（圖片框、填充影像、媒體預覽、OLE 預覽或縮放影像）等有用的上下文資訊。

{{% alert title="Tip" color="primary" %}}
使用 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 保留原始編碼的影像資料與檔案類型。若想將輸出正規化為特定格式（例如 PNG），可使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getImage--) 搭配 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)。
{{% /alert %}}

## **共用輔助方法**

以下的輔助方法讓範例保持簡潔。`saveOriginalImage` 會寫入原始嵌入位元組、根據 MIME 類型選擇安全的副檔名，並透過 SHA-256 雜湊跳過重複的影像二進位資料。

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

## **從圖片框擷取影像**

此方法適用於作為獨立物件插入的圖片。[IPictureFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ipictureframe/) 會將圖片儲存在 `getPictureFormat().getPicture().getImage()`，此呼叫會回傳一個 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件。

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

## **從填圖形狀擷取影像**

形狀可以使用圖片作為填充。先檢查形狀的填充類型：若不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/)，則不存在可擷取的圖片。以下範例處理 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iautoshape/) 物件，並透過 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getImage--) 將每張影像保存為 PNG。

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

## **從 OLE 物件框擷取預覽影像**

[IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/) 可能有 PowerPoint 用於在投影片上顯示物件預覽的替代圖片。此影像可透過 `getSubstitutePictureFormat().getPicture().getImage()` 取得。擷取此圖片會得到預覽影像，而不是嵌入的 OLE 套件內容。

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

## **從影片框擷取預覽影像**

[IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 也可以在 `getPictureFormat().getPicture().getImage()` 中存放預覽影像。這是投影片上顯示的海報或縮圖，並非從影片串流解碼的畫格。

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

## **從音訊框擷取預覽影像**

[IAudioFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/) 可以在 `getPictureFormat().getPicture().getImage()` 中存放縮圖。這是投影片上顯示的音訊物件圖示。

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

## **從縮放物件擷取影像**

[IZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/izoomframe/) 与 [ISectionZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isectionzoomframe/) 形狀可以使用自訂影像。請從縮放框讀取 `getZoomImage()`。

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

## **從摘要縮放框擷取影像**

[ISummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isummaryzoomframe/) 也是一種形狀。其區段項目可以使用自訂影像，透過每個摘要縮放區段的 `getZoomImage()` 方法取得。

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

## **從表格形狀擷取影像**

[ITable](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itable/) 為形狀之一。表格中的影像通常以圖片填充的方式儲存在儲存格內。

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

## **從圖表形狀擷取影像**

[IChart](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ichart/) 為形狀之一。下方範例從圖表區域的圖片填充中擷取影像。

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

## **從 SmartArt 形狀擷取影像**

[ISmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartart/) 物件是形狀。依據 SmartArt 版面配置，影像可能存於節點項目的項目符號填充，或存於節點形狀的填充格式中。

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

## **包含群組形狀內的影像**

群組形狀擁有自己的形狀集合。共用的 `enumerateShapes` 輔助方法提供 `includeGroupedShapes` 參數。若要檢查 [IGroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igroupshape/) 內的形狀，請將其設為 `true`。下方範例會從圖片框、填圖形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中擷取影像。如需同時包含表格、圖表、SmartArt 與摘要縮放影像，請在相同的遞迴形狀遍歷中重新使用前述各段落的專門擷取邏輯。

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

## **邊緣情況與實務說明**

- **Duplicate images:** 多個形狀可能參考同一張影像，或是不同影像的位元組相同。若希望每個唯一影像僅產生一個輸出檔，寫入檔案前先使用雜湊 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 進行 SHA-256 比對。

- **Original data vs. converted output:** 使用 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 可保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。若透過 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getImage--) 搭配 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 轉成固定格式（如 PNG），則會失去原始檔案類型或向量資料。

- **Unsupported fill types:** 實心、漸層、圖樣及無填充形狀不含圖片填充。讀取 `getPictureFillFormat()` 前請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/)。

- **Grouped shapes:** 投影片的頂層形狀集合不會自動展平群組。若群組內容重要，請遞迴檢查 [IGroupShape.getShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/igroupshape/#getShapes--)。

- **OLE object previews:** [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/) 可能透過 `getSubstitutePictureFormat()` 暴露預覽影像，但該影像僅為投影片的預覽，並非 OLE 物件內嵌的檔案。

- **Video frame thumbnails:** [IVideoFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/) 可能透過 `getPictureFormat()` 暴露預覽影像，此影像僅為投影片上顯示的海報，並未從影片串流中解碼取得。

- **Audio frame thumbnails:** [IAudioFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iaudioframe/) 可能透過 `getPictureFormat()` 暴露圖示或縮圖，這並非音訊資料本身。

- **Zoom images:** 投影片縮放、區段縮放與摘要縮放形狀可使用自訂 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件，透過 `getZoomImage()` 取得。

- **Nested shape models:** 表格、圖表與 SmartArt 物件皆實作 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ishape/)，但它們的影像常儲存在表格儲存格、圖表元素或 SmartArt 節點的格式物件內。

- **Cropped or transformed pictures:** 直接取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 只會得到儲存的原始影像資源，並不會套用形狀所做的裁切、透明度、重新著色、旋轉或其他視覺效果。

## **常見問題**

**是否可以在不裁切、套用效果或形狀轉換的情況下擷取原始影像？**

可以。存取 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 物件，並將 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 寫入磁碟，即可保留簡報中儲存的原始編碼影像，而非投影片上呈現的樣子。

**是否可以將所有擷取的影像匯出為 PNG？**

可以。使用 [IPPImage.getImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getImage--) 取得 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件，然後以 [IImage.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 並傳入 [ImageFormat.Png](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/imageformat/) 來儲存。此操作會將輸出轉換為 PNG，可能不會保留原始檔案類型或向量資料。

**如何避免同一張影像被多次儲存？**

對每個 [IPPImage.getBinaryData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/#getBinaryData--) 計算雜湊，並將雜湊值保存在集合中。若新影像的雜湊已存在，則跳過寫入或改為記錄為已存在檔案的另一個參考。

**為什麼某些形狀不會產生影像？**

圖片框、填圖形狀、OLE 物件框、媒體框、縮放框、表格、圖表與 SmartArt 皆可能參考影像。但有些形狀類型是透過巢狀的格式物件才暴露影像，單純檢查 `getPictureFormat()` 或 `getFillFormat()` 未必足以捕捉所有情況。

**是否可以擷取影片框顯示的縮圖？**

可以。使用 [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) 並讀取 `getPictureFormat().getPicture().getImage()`，即可取得影片框所攜帶的海報影像。這僅是與影片框一起儲存的預覽圖，並非從影片檔案中動態產生的畫格。

**如何判斷哪些形狀使用了簡報影像集合中的特定影像？**

Aspose.Slides 不會自動建立從 [IPPImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ippimage/) 回到形狀的反向連結。您需要在遍歷過程中自行建立映射：每當發現影像參考時，記錄投影片編號、形狀路徑以及影像的雜湊或集合項目。

**是否可以擷取嵌入在 OLE 物件內的影像（例如附加的文件）？**

您可以透過 [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) 取得 OLE 物件的投影片預覽圖，但這僅是預覽影像，並非嵌入的文件本身。若需從嵌入的檔案中擷取影像，必須先將 OLE 資料抽出，然後使用該檔案類型的專用工具進行檢查。