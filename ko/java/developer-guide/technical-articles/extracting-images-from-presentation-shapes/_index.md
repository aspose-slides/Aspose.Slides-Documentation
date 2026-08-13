---
title: Java에서 프레젠테이션 도형의 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 100
url: /ko/java/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출합니다 - 빠르고 코드 친화적인 솔루션."
---
## **Overview**

프레젠테이션의 이미지들은 여러 형태의 도형에 나타날 수 있습니다: 일반 사진 프레임, 도형에 적용된 사진 채우기, OLE 객체 미리 보기 이미지, 비디오 또는 오디오 프레임 썸네일, 줌 이미지, 또는 표, 차트 및 SmartArt 도형 내부에 중첩된 이미지 등. Aspose.Slides는 이러한 이미지들을 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [IImageCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimagecollection/)와 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation.getImages()`를 반복하면 됩니다. 이 문서는 다른 작업에 초점을 맞춥니다: 도형을 순회하여 슬라이드에서 이미지가 사용된 위치를 찾아 저장된 파일에 슬라이드 번호, 도형 위치 및 원본 유형(사진 프레임, 채우기 이미지, 미디어 미리 보기, OLE 미리 보기 또는 줌 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="info" %}}
원본 인코딩된 이미지 데이터와 파일 유형을 보존하려면 [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getBinaryData--)를 사용하십시오. PNG와 같은 특정 형식으로 출력을 정규화하려면 [IPPImage.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getImage--)를 [IImage.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/#save-java.lang.String-int-)와 함께 사용하십시오.
{{% /alert %}}

## **Shared Helper Methods**

아래 헬퍼 메서드는 예제를 간결하게 유지합니다. `saveOriginalImage`는 원본 임베드된 바이트를 쓰고, MIME 타입에서 안전한 확장자를 선택하며, SHA-256 해시를 사용해 중복 이미지 바이너리를 건너뜁니다.

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

독립 객체로 삽입된 사진에 대해 이 방법을 사용하십시오. [IPictureFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipictureframe/)은 `getPictureFormat().getPicture().getImage()`에 사진을 저장하며, 이는 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/) 객체를 반환합니다.

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

## **Extract Images from Picture-Filled Shapes**

도형은 사진을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하십시오: [FillType.Picture](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)이 아니라면 해당 채우기에서 추출할 사진이 없습니다. 아래 예제는 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/) 객체를 처리하고 각 이미지를 [IPPImage.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getImage--)를 통해 PNG로 저장합니다.

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

## **Extract Preview Images from OLE Object Frames**

[IOleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioleobjectframe/)은 PowerPoint이 슬라이드에서 객체의 미리 보기로 사용하는 대체 사진을 가질 수 있습니다. 이 이미지에는 `getSubstitutePictureFormat().getPicture().getImage()`를 통해 접근할 수 있습니다. 이 사진을 추출하면 미리 보기 이미지를 얻을 수 있으며, 임베드된 OLE 패키지 내용은 아닙니다.

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

## **Extract Preview Images from Video Frames**

[IVideoFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ivideoframe/) 역시 `getPictureFormat().getPicture().getImage()`에 미리 보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

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

## **Extract Preview Images from Audio Frames**

[IAudioFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaudioframe/)은 `getPictureFormat().getPicture().getImage()`에 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 객체의 이미지입니다.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

[IZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/izoomframe/) 및 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isectionzoomframe/) 도형은 사용자 정의 이미지를 사용할 수 있습니다. 줌 프레임에서 `getZoomImage()`를 읽습니다.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.Set;
import java.util.List;

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

[ISummaryZoomFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isummaryzoomframe/)도 도형입니다. 해당 섹션 항목은 사용자 정의 이미지를 사용할 수 있으며, 각 요약 줌 섹션의 `getZoomImage()` 메서드를 통해 노출됩니다.

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

## **Extract Images from Table Shapes**

[ITable](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itable/)은 도형입니다. 표 내 이미지들은 보통 셀의 사진 채우기로 저장됩니다.

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

## **Extract Images from Chart Shapes**

[IChart](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/)은 도형입니다. 아래 예제는 차트 영역 사진 채우기에서 이미지를 추출합니다.

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

## **Extract Images from SmartArt Shapes**

[ISmartArt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ismartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리표 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **Include Images Inside Grouped Shapes**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유된 `enumerateShapes` 헬퍼에는 `includeGroupedShapes` 옵션이 있습니다. [IGroupShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igroupshape/) 객체 내부의 도형을 검사하려면 이를 `true`로 설정하십시오. 아래 예제는 사진 프레임, 사진 채우기 도형, OLE 객체 미리 보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 줌 이미지까지 포함하려면 이전 섹션의 특수 추출 로직을 재사용하면서 동일한 재귀적 도형 순회를 유지하십시오.

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

## **Edge Cases and Practical Notes**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별개의 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일을 원한다면 파일을 쓰기 전에 [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getBinaryData--)를 해시하십시오.
- **원본 데이터 vs. 변환된 출력:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getBinaryData--)를 저장하면 임베드된 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터를 보존합니다. [IImage.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/#save-java.lang.String-int-)을 통해 [IPPImage.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getImage--)를 저장하면 일관된 출력 형식이 필요할 때 유용합니다.
- **지원되지 않는 채우기 유형:** 실색, 그라디언트, 패턴 및 무채우기 도형에는 사진 채우기가 없습니다. `getPictureFillFormat()`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/filltype/)을 확인하십시오.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 펼치지 않습니다. 그룹화된 콘텐츠가 중요할 때는 [IGroupShape.getShapes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/igroupshape/#getShapes--)를 재귀적으로 검사하십시오.
- **OLE 객체 미리 보기:** [IOleObjectFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioleobjectframe/)은 `getSubstitutePictureFormat()`을 통해 미리 보기 이미지를 제공할 수 있지만, 해당 이미지는 슬라이드 미리 보기일 뿐이며 OLE 객체 내부에 임베드된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [IVideoFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ivideoframe/)은 `getPictureFormat()`을 통해 미리 보기 이미지를 제공할 수 있지만, 이 이미지는 슬라이드에 표시되는 포스터일 뿐이며 비디오 스트림에서 추출된 것이 아닙니다.
- **오디오 프레임 썸네일:** [IAudioFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaudioframe/)은 `getPictureFormat()`을 통해 아이콘이나 썸네일을 제공할 수 있지만, 이는 임베드된 오디오 데이터가 아닙니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌 및 요약 줌 도형은 `getZoomImage()`를 통해 사용자 정의 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/) 객체를 사용할 수 있습니다.
- **중첩 도형 모델:** 표, 차트 및 SmartArt 객체는 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)을 구현하지만, 이들의 이미지는 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 서식 객체에 저장됩니다.
- **자르기 또는 변형된 사진:** [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 자르기, 투명도, 색상 재조정, 회전 또는 기타 시각 효과는 렌더링되지 않습니다.

## **FAQ**

### 원본 이미지를 잘라내기, 효과 또는 도형 변환 없이 추출할 수 있나요?

예. [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/) 객체에 접근하여 [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getBinaryData--)를 디스크에 쓰면 됩니다. 이는 프레젠테이션에 저장된 원본 인코딩된 이미지를 보존하며, 슬라이드에 렌더링된 방식은 아닙니다.

### 추출한 모든 이미지를 PNG로 내보낼 수 있나요?

예. [IPPImage.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getImage--)을 사용해 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/) 객체를 얻은 다음, [ImageFormat.Png](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/)와 함께 [IImage.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/#save-java.lang.String-int-)을 호출하십시오. 이렇게 하면 출력이 변환되며 원본 파일 유형이나 벡터 데이터가 보존되지 않을 수 있습니다.

### 같은 이미지를 여러 번 저장하는 것을 어떻게 방지할 수 있나요?

[IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/#getBinaryData--)의 해시를 사용하고 해시를 집합에 보관하십시오. 새로운 이미지의 해시가 이미 존재하면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 다른 참조를 기록하십시오.

### 왜 일부 도형은 이미지를 생성하지 않나요?

사진 프레임, 사진 채우기 도형, OLE 객체 프레임, 미디어 프레임, 줌 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형 유형은 중첩된 서식 객체를 통해 이미지를 노출하므로 단순히 `getPictureFormat()` 또는 도형의 `getFillFormat()`을 검사하는 것만으로는 충분하지 않을 수 있습니다.

### 비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?

예. [IVideoFrame](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ivideoframe/)을 사용하고 `getPictureFormat().getPicture().getImage()`를 읽으십시오. 이렇게 하면 비디오 프레임과 함께 저장된 포스터 이미지를 추출하게 되며, 비디오 파일에서 생성된 프레임이 아닙니다.

### 프레젠테이션 이미지 컬렉션에서 특정 이미지를 사용하는 도형을 어떻게 판단할 수 있나요?

Aspose.Slides는 [IPPImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ippimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회 중에 매핑을 구축하십시오: 이미지 참조를 찾을 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록합니다.

### 첨부 문서와 같은 OLE 객체 내부에 임베드된 이미지를 추출할 수 있나요?

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 통해 OLE 객체의 슬라이드 미리 보기를 추출할 수 있습니다. 그러나 해당 미리 보기는 임베드된 문서 자체가 아닙니다. 임베드된 파일 내부의 이미지를 추출하려면 OLE 데이터를 추출하고 해당 파일 유형에 맞는 도구로 검사하십시오.