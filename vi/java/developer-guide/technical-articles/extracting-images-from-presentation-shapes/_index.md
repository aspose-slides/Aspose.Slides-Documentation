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
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Java - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình bày có thể xuất hiện trong nhiều kiểu hình dạng: dưới dạng khung hình ảnh thông thường, dưới dạng ảnh nền được áp dụng cho các hình dạng, dưới dạng hình ảnh xem trước của đối tượng OLE, dưới dạng ảnh thu nhỏ của khung video hoặc âm thanh, dưới dạng ảnh phóng to, hoặc dưới dạng hình ảnh lồng vào trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ những hình ảnh này trong bộ sưu tập ảnh của bản trình bày, được truy cập thông qua các đối tượng [IImageCollection](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimagecollection/) và [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/).

Nếu bạn chỉ cần xuất mọi tài nguyên ảnh được nhúng trong một bản trình bày, hãy lặp lại qua `presentation.getImages()`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung hình ảnh, ảnh nền, xem trước đa phương tiện, xem trước OLE hoặc ảnh phóng to).

{{% alert title="Tip" color="info" %}}
Sử dụng [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getBinaryData--) để bảo toàn dữ liệu ảnh đã mã hoá gốc và kiểu tệp. Sử dụng [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getImage--) cùng với [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) khi bạn muốn chuẩn hoá đầu ra thành một định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức trợ giúp chung**

Các phương thức trợ giúp bên dưới giúp các ví dụ ngắn gọn. `saveOriginalImage` ghi ra các byte nhúng gốc, chọn phần mở rộng an toàn từ MIME type và bỏ qua các ảnh nhị phân trùng lặp bằng hàm băm SHA-256.

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

## **Trích xuất hình ảnh từ khung hình ảnh**

Sử dụng cách tiếp cận này cho các ảnh được chèn dưới dạng đối tượng độc lập. Một [IPictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipictureframe/) lưu trữ ảnh của nó trong `getPictureFormat().getPicture().getImage()`, phương thức này trả về một đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/).

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

## **Trích xuất hình ảnh từ hình dạng được lấp đầy bằng ảnh**

Các hình dạng có thể sử dụng ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/), thì không có ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và lưu mỗi ảnh dưới dạng PNG thông qua [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getImage--).

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

## **Trích xuất hình ảnh xem trước từ khung đối tượng OLE**

Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleobjectframe/) có thể có một ảnh thay thế mà PowerPoint dùng làm xem trước của đối tượng trên slide. Ảnh này có sẵn qua `getSubstitutePictureFormat().getPicture().getImage()`. Việc trích xuất ảnh này cho bạn ảnh xem trước, không phải nội dung gói OLE được nhúng.

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

## **Trích xuất hình ảnh xem trước từ khung video**

Một [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) cũng có thể lưu một ảnh xem trước trong `getPictureFormat().getPicture().getImage()`. Đây là poster hoặc thumbnail hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ khung âm thanh**

Một [IAudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/) có thể lưu một thumbnail trong `getPictureFormat().getPicture().getImage()`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ đối tượng Zoom**

Các hình dạng [IZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/izoomframe/) và [ISectionZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isectionzoomframe/) có thể sử dụng ảnh tùy chỉnh. Đọc `getZoomImage()` từ khung zoom.

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

## **Trích xuất hình ảnh từ khung Zoom tóm tắt**

Một [ISummaryZoomFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isummaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng ảnh tùy chỉnh, được lộ ra qua phương thức `getZoomImage()` của mỗi phần tóm tắt zoom.

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

## **Trích xuất hình ảnh từ hình dạng Bảng**

Một [ITable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itable/) là một hình dạng. Ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ hình dạng Biểu đồ**

Một [IChart](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/) là một hình dạng. Ví dụ dưới đây trích xuất ảnh từ nền ảnh của vùng biểu đồ.

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

## **Trích xuất hình ảnh từ hình dạng SmartArt**

Một [ISmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, ảnh có thể được lưu trong nền bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh bên trong các hình dạng nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng. Trợ giúp chung `enumerateShapes` có tùy chọn `includeGroupedShapes`. Đặt nó thành `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [IGroupShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igroupshape/). Ví dụ dưới đây trích xuất ảnh từ khung hình ảnh, hình dạng được lấp đầy bằng ảnh, xem trước đối tượng OLE, thumbnail khung video và thumbnail khung âm thanh. Để bao gồm ảnh bảng, biểu đồ, SmartArt và zoom tóm tắt nữa, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ cùng một quá trình duyệt hình dạng đệ quy.

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

## **Trường hợp đặc biệt và lưu ý thực tế**

- **Ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một ảnh hoặc các ảnh riêng biệt có byte giống hệt nhau. Hãy băm [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getBinaryData--) trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getBinaryData--) bảo toàn dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF được nhúng. Lưu [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getImage--) thông qua [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) hữu ích khi bạn muốn định dạng đầu ra nhất quán.
- **Các loại nền không được hỗ trợ:** Các hình dạng đặc, gradient, pattern và không có nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/filltype/) trước khi đọc `getPictureFillFormat()`.
- **Hình dạng nhóm:** Bộ sưu tập hình dạng ở cấp slide không làm phẳng các nhóm. Hãy duyệt đệ quy [IGroupShape.getShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/igroupshape/#getShapes--) khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleobjectframe/) có thể cung cấp ảnh xem trước thông qua `getSubstitutePictureFormat()`, nhưng ảnh này chỉ là xem trước trên slide, không phải tệp được nhúng bên trong đối tượng OLE.
- **Thumbnail khung video:** Một [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) có thể cung cấp ảnh xem trước qua `getPictureFormat()`, nhưng ảnh này chỉ là poster hiển thị trên slide, không được trích xuất từ luồng video.
- **Thumbnail khung âm thanh:** Một [IAudioFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudioframe/) có thể cung cấp biểu tượng hoặc thumbnail qua `getPictureFormat()`; nó không phải là dữ liệu âm thanh được nhúng.
- **Ảnh Zoom:** Các hình dạng zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) tùy chỉnh thông qua `getZoomImage()`.
- **Mô hình hình dạng lồng nhau:** Các đối tượng bảng, biểu đồ và SmartArt triển khai [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), nhưng ảnh của chúng thường được lưu trong các đối tượng định dạng ô bảng, phần tử biểu đồ hoặc nút SmartArt.
- **Ảnh đã cắt hoặc biến đổi:** Truy cập [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) chỉ cho bạn tài nguyên ảnh được lưu. Nó không áp dụng cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng thị giác khác mà hình dạng áp dụng.

## **FAQ**

### Tôi có thể trích xuất ảnh gốc mà không cắt, không áp dụng hiệu ứng hay biến đổi hình dạng không?

Có. Truy cập đối tượng [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) và ghi [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getBinaryData--) ra đĩa. Điều này bảo toàn ảnh đã mã hoá gốc được lưu trong bản trình bày, không phải cách ảnh được hiển thị trên slide.

### Tôi có thể xuất mọi ảnh đã trích xuất dưới dạng PNG không?

Có. Sử dụng [IPPImage.getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getImage--) để lấy một đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/), sau đó gọi [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) với [ImageFormat.Png](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/). Điều này chuyển đổi đầu ra và có thể không bảo toàn kiểu tệp gốc hoặc dữ liệu vector.

### Làm sao tránh lưu cùng một ảnh nhiều lần?

Sử dụng hàm băm của [IPPImage.getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/#getBinaryData--) và lưu các giá trị băm vào một tập hợp. Nếu một ảnh mới có băm đã tồn tại, bỏ qua nó hoặc ghi lại một tham chiếu khác tới tệp đầu ra hiện có.

### Tại sao một số hình dạng không tạo ra ảnh?

Khung hình ảnh, hình dạng được lấp đầy bằng ảnh, khung đối tượng OLE, khung đa phương tiện, khung zoom, bảng, biểu đồ và SmartArt có thể tham chiếu ảnh. Một số loại hình dạng cung cấp ảnh qua các đối tượng định dạng lồng nhau, do đó kiểm tra đơn giản `getPictureFormat()` hoặc `getFillFormat()` của hình dạng không phải lúc nào cũng đủ.

### Tôi có thể trích xuất thumbnail hiển thị cho khung video không?

Có. Sử dụng [IVideoFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ivideoframe/) và đọc `getPictureFormat().getPicture().getImage()`. Điều này trích xuất ảnh poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

### Làm sao xác định hình dạng nào sử dụng một ảnh cụ thể từ bộ sưu tập ảnh của bản trình bày?

Aspose.Slides không lưu liên kết ngược từ [IPPImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ippimage/) tới các hình dạng. Hãy xây dựng bản đồ trong quá trình duyệt: mỗi khi bạn tìm thấy một tham chiếu ảnh, ghi lại số slide, đường dẫn hình dạng và băm ảnh hoặc mục trong bộ sưu tập.

### Tôi có thể trích xuất ảnh nhúng trong OLE, chẳng hạn tài liệu đính kèm không?

Bạn có thể trích xuất ảnh xem trước của OLE từ [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). Tuy nhiên, ảnh xem trước này không phải là tài liệu được nhúng. Để trích xuất ảnh từ bên trong tệp nhúng, cần trích xuất dữ liệu OLE và kiểm tra nó bằng các công cụ phù hợp với loại tệp đó.