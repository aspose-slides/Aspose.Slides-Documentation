---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu bằng Java
linktitle: Hình ảnh từ hình dạng
type: docs
weight: 100
url: /vi/java/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java - giải pháp nhanh chóng, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình bày có thể xuất hiện ở một số loại hình dạng: khung hình ảnh thông thường, ảnh nền được áp dụng cho các hình, ảnh xem trước đối tượng OLE, hình thu nhỏ khung video hoặc âm thanh, ảnh thu phóng, hoặc ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu những hình ảnh này trong bộ sưu tập hình ảnh của bản trình bày, được truy cập thông qua [IImageCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimagecollection/) và [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) .

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong bản trình bày, hãy lặp qua `presentation.getImages()`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung hình ảnh, ảnh nền, xem trước phương tiện, xem trước OLE hoặc ảnh thu phóng).

{{% alert title="Mẹo" color="primary" %}}
Sử dụng [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getBinaryData--) để giữ lại dữ liệu ảnh đã mã hoá gốc và kiểu tệp. Sử dụng [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getImage--) cùng với [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) khi bạn muốn chuẩn hoá đầu ra sang một định dạng cụ thể như PNG.
{{% /alert %}}

## **Các Phương Thức Trợ Giúp Chung**

Các phương thức trợ giúp dưới đây giúp các ví dụ ngắn gọn. `saveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ MIME type và bỏ qua các ảnh nhị phân trùng lặp bằng hàm băm SHA‑256.

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

## **Trích Xuất Hình Ảnh Từ Khung Hình Ảnh**

Sử dụng cách này cho các hình ảnh được chèn dưới dạng đối tượng độc lập. Một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ipictureframe/) lưu hình ảnh của mình trong `getPictureFormat().getPicture().getImage()`, trả về một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) .

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

## **Trích Xuất Hình Ảnh Từ Các Hình Dạng Được Điền Ảnh**

Các hình dạng có thể sử dụng một bức ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/java/com.aspose.slides.filltype/), thì không có ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iautoshape/) và lưu mỗi ảnh dưới dạng PNG thông qua [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getImage--) .

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

## **Trích Xuất Ảnh Xem Trước Từ Khung Đối Tượng OLE**

Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ioleobjectframe/) có thể có một bức ảnh thay thế mà PowerPoint dùng làm xem trước cho đối tượng trên slide. Ảnh này có sẵn thông qua `getSubstitutePictureFormat().getPicture().getImage()` . Việc trích xuất bức ảnh này sẽ cho bạn ảnh xem trước, không phải nội dung gói OLE được nhúng.

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

## **Trích Xuất Ảnh Xem Trước Từ Khung Video**

Một [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ivideoframe/) cũng có thể lưu ảnh xem trước trong `getPictureFormat().getPicture().getImage()` . Đây là ảnh bìa hoặc ảnh thu nhỏ hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích Xuất Ảnh Xem Trước Từ Khung Âm Thanh**

Một [IAudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iaudioframe/) có thể lưu ảnh thu nhỏ trong `getPictureFormat().getPicture().getImage()` . Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích Xuất Hình Ảnh Từ Đối Tượng Zoom**

Các hình dạng [IZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.izoomframe/) và [ISectionZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.isectionzoomframe/) có thể sử dụng hình ảnh tùy chỉnh. Đọc `getZoomImage()` từ khung zoom.

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

## **Trích Xuất Hình Ảnh Từ Các Khung Zoom Tổng Hợp**

Một [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.isummaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng hình ảnh tùy chỉnh, được phô bày qua phương thức `getZoomImage()` của mỗi phần zoom tổng hợp.

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

## **Trích Xuất Hình Ảnh Từ Hình Dạng Bảng**

Một [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides.itable/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.

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

## **Trích Xuất Hình Ảnh Từ Hình Dạng Biểu Đồ**

Một [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ichart/) là một hình dạng. Ví dụ dưới đây trích xuất ảnh từ nền ảnh của khu vực biểu đồ.

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

## **Trích Xuất Hình Ảnh Từ Hình Dạng SmartArt**

Một [ISmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ismartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền hình bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao Gồm Hình Ảnh Bên Trong Các Hình Dạng Nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng của chúng. Trợ giúp `enumerateShapes` chung có tùy chọn `includeGroupedShapes`. Đặt giá trị `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [IGroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides.igroupshape/) . Ví dụ dưới đây trích xuất ảnh từ khung hình ảnh, các hình dạng được điền ảnh, xem trước đối tượng OLE, ảnh thu nhỏ khung video và ảnh thu nhỏ khung âm thanh. Để bao gồm ảnh bảng, biểu đồ, SmartArt và zoom tổng hợp, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ nguyên cách duyệt hình dạng đệ quy.

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

## **Trường Hợp Đặc Biệt và Lưu Ý Thực Tiễn**

- **Ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một ảnh hoặc các ảnh riêng biệt nhưng có byte giống hệt. Băm [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getBinaryData--) trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getBinaryData--) giữ lại dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF được nhúng. Lưu [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getImage--) thông qua [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) hữu ích khi bạn muốn định dạng đầu ra đồng nhất.
- **Các loại nền không được hỗ trợ:** Các hình dạng đặc, gradient, pattern và không nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides.filltype/) trước khi đọc `getPictureFillFormat()` .
- **Hình dạng nhóm:** Bộ sưu tập hình dạng cấp cao nhất của slide không làm phẳng các nhóm. Kiểm tra đệ quy [IGroupShape.getShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides.igroupshape/#getShapes--) khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ioleobjectframe/) có thể hiển thị ảnh xem trước qua `getSubstitutePictureFormat()` , nhưng ảnh này chỉ là xem trước trên slide, không phải tệp nhúng bên trong đối tượng OLE.
- **Ảnh thu nhỏ khung video:** Một [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ivideoframe/) có thể hiển thị ảnh xem trước qua `getPictureFormat()` , nhưng ảnh này chỉ là poster trên slide, không được trích xuất từ luồng video.
- **Ảnh thu nhỏ khung âm thanh:** Một [IAudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iaudioframe/) có thể hiển thị biểu tượng hoặc ảnh thu nhỏ qua `getPictureFormat()` ; nó không phải là dữ liệu âm thanh đã nhúng.
- **Ảnh zoom:** Các hình dạng zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) tùy chỉnh qua `getZoomImage()` .
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt triển khai [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ishape/) , nhưng ảnh của chúng thường được lưu trong ô bảng, phần tử biểu đồ hoặc đối tượng định dạng nút SmartArt.
- **Ảnh đã cắt hoặc biến đổi:** Truy cập [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) chỉ cho bạn tài nguyên ảnh đã lưu. Nó không thực thi việc cắt, trong suốt, tái màu, xoay hoặc các hiệu ứng trực quan khác được áp dụng bởi hình dạng.

## **Câu Hỏi Thường Gặp**

**Tôi có thể trích xuất ảnh gốc mà không bị cắt, hiệu ứng hay biến đổi dạng không?**

Có. Truy cập đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) và ghi [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getBinaryData--) ra đĩa. Điều này giữ lại ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getImage--) để lấy một đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimage/) , sau đó gọi [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides.iimage/#save-java.lang.String-int-) cùng với [ImageFormat.Png](https://reference.aspose.com/slides/vi/java/com.aspose.slides.imageformat/) . Điều này chuyển đổi đầu ra và có thể không giữ lại kiểu tệp gốc hoặc dữ liệu vector.

**Làm sao tôi tránh lưu cùng một ảnh hơn một lần?**

Sử dụng hàm băm của [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/#getBinaryData--) và lưu các băm này trong một tập hợp. Nếu một ảnh mới có băm đã tồn tại, bỏ qua hoặc ghi nhận một tham chiếu khác tới tệp đầu ra hiện có.

**Tại sao một số hình dạng không tạo ra ảnh?**

Khung hình ảnh, các hình dạng được điền ảnh, khung đối tượng OLE, khung phương tiện, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu ảnh. Một số loại hình dạng cung cấp ảnh qua các đối tượng định dạng lồng nhau, vì vậy một kiểm tra đơn giản `getPictureFormat()` hoặc `getFillFormat()` của hình dạng không luôn đủ.

**Tôi có thể trích xuất ảnh thu nhỏ hiển thị cho khung video không?**

Có. Sử dụng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ivideoframe/) và đọc `getPictureFormat().getPicture().getImage()` . Điều này trích xuất ảnh poster được lưu kèm khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao tôi xác định hình dạng nào sử dụng một ảnh cụ thể trong bộ sưu tập ảnh của bản trình bày?**

Aspose.Slides không lưu liên kết ngược từ [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ippimage/) tới các hình dạng. Xây dựng một bản đồ trong quá trình duyệt: mỗi khi tìm thấy một tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và băm ảnh hoặc chỉ mục trong bộ sưu tập.

**Tôi có thể trích xuất ảnh nhúng bên trong đối tượng OLE, chẳng hạn tài liệu đính kèm không?**

Bạn có thể trích xuất ảnh xem trước slide của đối tượng OLE từ [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) . Tuy nhiên, ảnh xem trước này không phải là tài liệu đã nhúng. Để trích xuất ảnh từ bên trong tệp được nhúng, hãy xuất dữ liệu OLE và kiểm tra bằng các công cụ phù hợp với loại tệp đó.