---
title: Android에서 Java를 사용하여 프레젠테이션 도형에서 이미지 추출
linktitle: 도형의 이미지
type: docs
weight: 100
url: /ko/androidjava/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 검색
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Android용 Aspose.Slides를 사용하여 Java로 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출하는 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지​는 여러 형태의 도형에 나타날 수 있습니다: 일반 그림 프레임, 도형에 적용된 그림 채우기, OLE 개체 미리보기 이미지, 비디오 또는 오디오 프레임 썸네일, 확대 이미지, 혹은 표·차트·SmartArt 도형 내부에 중첩된 이미지 등입니다. Aspose.Slides는 이러한 이미지를 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [IImageCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagecollection/) 및 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내기만 하면 된다면 `presentation.getImages()`를 순회하면 됩니다. 이 문서는 다른 작업에 초점을 맞춥니다: 슬라이드에서 이미지가 사용된 위치를 찾기 위해 도형을 탐색하고, 저장된 파일에 슬라이드 번호, 도형 위치, 소스 유형(그림 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기, 확대 이미지)과 같은 유용한 컨텍스트를 유지하도록 합니다.

{{% alert title="Tip" color="primary" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getBinaryData--)를 사용하면 원본 인코딩된 이미지 데이터와 파일 유형을 그대로 보존할 수 있습니다. 특정 형식(PNG 등)으로 출력을 정규화하려면 [IPPImage.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getImage--)와 [IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)를 사용하세요.
{{% /alert %}}

## **공유 도우미 메서드**

아래 도우미 메서드는 예제를 간결하게 유지합니다. `saveOriginalImage`는 원본 임베디드 바이트를 쓰고, MIME 형식에서 안전한 확장자를 선택하며, SHA‑256 해시를 통해 중복 이미지 바이너리를 건너뜁니다.

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

## **그림 프레임에서 이미지 추출**

독립 객체로 삽입된 그림에 이 방법을 사용합니다. [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/)은 `getPictureFormat().getPicture().getImage()`에 그림을 저장하며, 이는 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 객체를 반환합니다.

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

## **그림 채우기 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하세요: [FillType.Picture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/filltype/)이 아니라면 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [IAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iautoshape/) 객체를 처리하고, [IPPImage.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getImage--)를 통해 각 이미지를 PNG로 저장합니다.

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

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[IOleObjectFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioleobjectframe/)는 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 그림을 가질 수 있습니다. 이 이미지는 `getSubstitutePictureFormat().getPicture().getImage()`를 통해 제공됩니다. 이 그림을 추출하면 미리보기 이미지가 얻어지며, 임베디드 OLE 패키지 내용은 포함되지 않습니다.

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

## **비디오 프레임에서 미리보기 이미지 추출**

[IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/)도 `getPictureFormat().getPicture().getImage()`에 미리보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 또는 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

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

## **오디오 프레임에서 미리보기 이미지 추출**

[IAudioFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/)는 `getPictureFormat().getPicture().getImage()`에 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 객체용 이미지입니다.

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

## **줌 객체에서 이미지 추출**

[IZoomFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/izoomframe/) 및 [ISectionZoomFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isectionzoomframe/) 도형은 사용자 지정 이미지를 사용할 수 있습니다. 줌 프레임에서 `getZoomImage()`를 읽으세요.

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

## **요약 줌 프레임에서 이미지 추출**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isummaryzoomframe/)도 도형이며, 각 요약 줌 섹션은 `getZoomImage()` 메서드를 통해 사용자 지정 이미지를 가질 수 있습니다.

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

## **표 도형에서 이미지 추출**

[ITable](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itable/)은 도형입니다. 표 내의 이미지는 일반적으로 셀의 그림 채우기로 저장됩니다.

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

## **차트 도형에서 이미지 추출**

[IChart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ichart/)는 도형입니다. 아래 예제는 차트 영역의 그림 채우기에서 이미지를 추출합니다.

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

## **SmartArt 도형에서 이미지 추출**

[ISmartArt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ismartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 불릿 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 가집니다. 공유 `enumerateShapes` 도우미에는 `includeGroupedShapes` 옵션이 있습니다. [IGroupShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igroupshape/) 객체 내부 도형을 검사하려면 이를 `true`로 설정하세요. 아래 예제는 그림 프레임, 그림 채우기 도형, OLE 개체 미리보기, 비디오 프레임 썸네일, 오디오 프레임 썸네일에서 이미지를 추출합니다. 표·차트·SmartArt·요약 줌 이미지까지 포함하려면 이전 섹션의 특화된 추출 로직을 재사용하면서 동일한 재귀형 도형 순회를 유지하면 됩니다.

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

## **엣지 케이스 및 실용적인 참고 사항**

- **중복 이미지:** 여러 도형이 동일한 이미지를 참조하거나 바이트가 동일한 별도 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일만 원한다면 파일을 쓰기 전에 [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getBinaryData--)의 해시를 확인하세요.
- **원본 데이터 vs. 변환된 출력:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getBinaryData--)를 저장하면 임베디드 JPEG, PNG, GIF, SVG, EMF, WMF 데이터를 그대로 보존합니다. [IPPImage.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getImage--)와 [IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)를 사용하면 PNG와 같은 일관된 형식으로 변환할 수 있습니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴, 무채우기 도형에는 그림 채우기가 포함되지 않습니다. `getPictureFillFormat()`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/filltype/)을 확인하세요.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 내용이 중요하다면 [IGroupShape.getShapes](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/igroupshape/#getShapes--)을 재귀적으로 검사하세요.
- **OLE 개체 미리보기:** [IOleObjectFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioleobjectframe/)는 `getSubstitutePictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드 미리보기일 뿐 OLE 개체 내부의 임베디드 파일이 아닙니다.
- **비디오 프레임 썸네일:** [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/)는 `getPictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드에 표시되는 포스터일 뿐 비디오 스트림에서 추출된 프레임이 아닙니다.
- **오디오 프레임 썸네일:** [IAudioFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iaudioframe/)는 `getPictureFormat()`을 통해 아이콘이나 썸네일을 제공할 수 있으며, 이는 임베디드 오디오 데이터가 아닙니다.
- **줌 이미지:** 슬라이드 줌, 섹션 줌, 요약 줌 도형은 `getZoomImage()`를 통해 사용자 지정 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 객체를 사용할 수 있습니다.
- **중첩된 도형 모델:** 표, 차트, SmartArt 객체는 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/)를 구현하지만, 그 이미지들은 종종 중첩된 셀, 차트 요소, 또는 SmartArt 노드 포맷팅 객체에 저장됩니다.
- **크롭 또는 변형된 그림:** [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 크롭, 투명도, 색상 재조정, 회전 등 시각 효과는 반영되지 않습니다.

## **FAQ**

**원본 이미지를 크롭, 효과, 도형 변형 없이 추출할 수 있나요?**

예. [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 객체에 접근하고 [IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getBinaryData--)를 디스크에 기록하면 프레젠테이션에 저장된 원본 인코딩 이미지를 보존할 수 있습니다. 슬라이드에 렌더링되는 방식은 반영되지 않습니다.

**추출한 모든 이미지를 PNG로 내보낼 수 있나요?**

예. [IPPImage.getImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getImage--)를 사용해 [IImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/) 객체를 얻은 뒤, [IImage.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-)에 [ImageFormat.Png](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imageformat/)을 지정하면 됩니다. 이는 출력 형식을 변환하며 원본 파일 유형이나 벡터 데이터는 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하지 않으려면 어떻게 해야 하나요?**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/#getBinaryData--)의 해시를 집합에 저장해 관리하십시오. 새 이미지의 해시가 이미 존재하면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 다른 참조만 기록하면 됩니다.

**어떤 도형은 이미지가 생성되지 않나요?**

그림 프레임, 그림 채우기 도형, OLE 개체 프레임, 미디어 프레임, 줌 프레임, 표, 차트, SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형 유형은 중첩된 포맷팅 객체를 통해 이미지를 제공하므로 단순히 `getPictureFormat()`이나 도형 `getFillFormat()`만으로는 충분하지 않을 수 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**

예. [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--)를 사용하고 `getPictureFormat().getPicture().getImage()`를 읽으면 비디오 프레임에 저장된 포스터 이미지를 추출할 수 있습니다. 이는 비디오 파일에서 생성된 프레임이 아니라 비디오 프레임과 함께 저장된 포스터 이미지입니다.

**프레젠테이션 이미지 컬렉션에 있는 특정 이미지가 어떤 도형에서 사용되는지 어떻게 확인하나요?**

Aspose.Slides는 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회하면서 매번 이미지 참조를 찾을 때 슬라이드 번호, 도형 경로, 이미지 해시 또는 컬렉션 항목을 기록해 매핑을 구축하십시오.

**OLE 개체 내부에 임베디드된 이미지(예: 첨부 문서)를 추출할 수 있나요?**

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--)을 사용하면 OLE 개체의 슬라이드 미리보기를 추출할 수 있지만, 이는 실제 임베디드 문서가 아닙니다. 임베디드 파일 내부의 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 형식에 맞는 도구로 검사해야 합니다.