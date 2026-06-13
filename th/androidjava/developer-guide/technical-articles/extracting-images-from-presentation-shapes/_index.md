---
title: สกัดภาพจากรูปร่างในงานนำเสนอบน Android ด้วย Java
linktitle: ภาพจากรูปร่าง
type: docs
weight: 100
url: /th/androidjava/extracting-images-from-presentation-shapes/
keywords:
- สกัดภาพ
- ดึงภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สกัดภาพจากรูปร่างในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java - โซลูชันที่รวดเร็วและเป็นมิตรต่อโค้ด"
---
## **ภาพรวม**

ภาพในงานนำเสนอสามารถปรากฏในรูปแบบรูปร่างหลายประเภท: เป็นกรอบรูปภาพธรรมดา, เป็นภาพที่เติมในรูปร่าง, เป็นภาพตัวอย่างของอ็อบเจกต์ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นภาพซูม, หรือเป็นภาพที่ซ่อนอยู่ภายในรูปร่างตาราง, แผนภูมิและ SmartArt  Aspose.Slides จะจัดเก็บภาพเหล่านี้ในคอลเลกชันภาพของงานนำเสนอ ซึ่งเปิดเผยผ่านวัตถุ [IImageCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)  

หากคุณต้องการส่งออกทุกทรัพยากรภาพที่ฝังอยู่ในงานนำเสนอ เพียงวนลูป `presentation.getImages()`  บทความนี้มุ่งเน้นงานที่แตกต่าง: การท่องรูปร่างเพื่อค้นหาว่าภาพถูกใช้ที่ไหนในสไลด์ เพื่อให้ไฟล์ที่บันทึกได้เก็บบริบทที่มีประโยชน์ เช่น หมายเลขสไลด์, ตำแหน่งรูปร่าง, และประเภทแหล่งที่ม (กรอบรูปภาพ, ภาพพื้นหลัง, ตัวอย่างสื่อ, ตัวอย่าง OLE หรือภาพซูม)

{{% alert title="Tip" color="primary" %}}
ใช้ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) เพื่อรักษาข้อมูลภาพที่เข้ารหัสเดิมและประเภทไฟล์  ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) ร่วมกับ [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) เมื่อคุณต้องการทำให้ออกเป็นรูปแบบเฉพาะเช่น PNG
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง `saveOriginalImage` จะเขียนไบต์ที่ฝังไว้เดิม, เลือกนามสกุลไฟล์ที่ปลอดภัยจาก MIME type, และข้ามไบต์ภาพที่ซ้ำกันโดยใช้แฮช SHA-256

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

## **สกัดภาพจากกรอบรูปภาพ**

ใช้วิธีนี้สำหรับภาพที่แทรกเป็นอ็อบเจกต์อิสระ  [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) จะเก็บรูปภาพไว้ใน `getPictureFormat().getPicture().getImage()` ซึ่งจะคืนค่าเป็นวัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)

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

## **สกัดภาพจากรูปร่างที่เติมด้วยรูปภาพ**

รูปร่างอาจใช้รูปภาพเป็นพื้นหลัง ตรวจสอบประเภทการเติมของรูปร่างก่อน: ถ้าไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) จะไม่มีรูปภาพให้สกัดจากการเติมนั้น  ตัวอย่างด้านล่างจัดการวัตถุ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และบันทึกแต่ละภาพเป็น PNG ผ่าน [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--)

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

## **สกัดภาพตัวอย่างจากกรอบอ็อบเจกต์ OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของอ็อบเจกต์บนสไลด์ได้  ภาพนี้สามารถเข้าถึงได้ผ่าน `getSubstitutePictureFormat().getPicture().getImage()`  การสกัดรูปภาพนี้จะให้ภาพตัวอย่าง ไม่ได้เป็นเนื้อหาแพ็กเกจ OLE ที่ฝังอยู่

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

## **สกัดภาพตัวอย่างจากกรอบวิดีโอ**

[IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) สามารถเก็บภาพตัวอย่างใน `getPictureFormat().getPicture().getImage()`  นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์ ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ

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

## **สกัดภาพตัวอย่างจากกรอบเสียง**

[IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/) สามารถเก็บภาพย่อใน `getPictureFormat().getPicture().getImage()`  นี่คือภาพที่แสดงสำหรับอ็อบเจกต์เสียงบนสไลด์

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

## **สกัดภาพจากอ็อบเจกต์ซูม**

รูปร่าง [IZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectionzoomframe/) สามารถใช้ภาพกำหนดเอง  อ่าน `getZoomImage()` จากกรอบซูม

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

## **สกัดภาพจากกรอบสรุปซูม**

[ISummaryZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isummaryzoomframe/) ก็เป็นรูปร่างเช่นกัน  รายการส่วนของสรุปซูมอาจใช้ภาพกำหนดเอง ที่เปิดเผยผ่านเมธอด `getZoomImage()` ของแต่ละส่วนสรุปซูม

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

## **สกัดภาพจากรูปร่างตาราง**

[ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/) เป็นรูปร่าง  ภาพในตารางส่วนใหญ่จะถูกเก็บเป็นพื้นหลังรูปภาพในเซลล์ของตาราง

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

## **สกัดภาพจากรูปร่างแผนภูมิ**

[IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/) เป็นรูปร่าง  ตัวอย่างด้านล่างสกัดภาพจากพื้นหลังรูปภาพของพื้นที่แผนภูมิ

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

## **สกัดภาพจากรูปร่าง SmartArt**

[ISmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartart/) เป็นอ็อบเจกต์รูปร่าง  ขึ้นอยู่กับเค้าโครงของ SmartArt, ภาพอาจถูกเก็บในพื้นหลังจุดหัวข้อของโหนดหรือในรูปแบบการเติมของรูปร่างโหนด

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

## **รวมภาพที่อยู่ภายในรูปร่างกลุ่ม**

รูปร่างกลุ่มมีคอลเลกชันรูปร่างของตนเอง  เมธอดช่วยเหลือ `enumerateShapes` มีตัวเลือก `includeGroupedShapes` ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปร่างภายในวัตถุ [IGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igroupshape/)  ตัวอย่างด้านล่างสกัดภาพจากกรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, ตัวอย่างอ็อบเจกต์ OLE, ภาพย่อของเฟรมวิดีโอและภาพย่อของเฟรมเสียง  หากต้องการรวมภาพจากตาราง, แผนภูมิ, SmartArt และสรุปซูมด้วย ให้เรียกใช้ตรรกะการสกัดพิเศษจากส่วนก่อนหน้าในขณะที่รักษาการท่องรูปร่างแบบเรียกซ้ำเดิม

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

## **กรณีพิเศษและโน๊ตเชิงปฏิบัติ**

- **ภาพซ้ำ:** รูปร่างหลายรูปอาจอ้างอิงภาพเดียวกันหรือภาพแยกที่มีไบต์เท่ากัน  ให้ทำแฮช [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ก่อนเขียนไฟล์ หากต้องการไฟล์เอาต์พุตหนึ่งไฟล์ต่อหนึ่งภาพที่ไม่ซ้ำกัน
- **ข้อมูลดั้งเดิมกับเอาต์พุตที่แปลงแล้ว:** การบันทึก [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) จะเก็บข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังไว้เดิม  การบันทึก [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) ผ่าน [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) มีประโยชน์เมื่อคุณต้องการรูปแบบเอาต์พุตที่สม่ำเสมอ
- **ประเภทการเติมที่ไม่รองรับ:** รูปร่างที่เป็นสีทึบ, ไล่สี, ลวดลาย หรือไม่มีการเติม จะไม่มีภาพเติม  ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ก่อนอ่าน `getPictureFillFormat()`
- **รูปร่างกลุ่ม:** คอลเลกชันรูปร่างระดับบนของสไลด์ไม่ได้ทำให้กลุ่มแบน  ให้ตรวจสอบ [IGroupShape.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igroupshape/#getShapes--) อย่างเรียกซ้ำเมื่อเนื้อหาในกลุ่มมีความสำคัญ
- **ตัวอย่างอ็อบเจกต์ OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getSubstitutePictureFormat()` แต่ภาพนั้นเป็นเพียงภาพตัวอย่างบนสไลด์ ไม่ใช่ไฟล์ที่ฝังอยู่ในอ็อบเจกต์ OLE
- **ภาพย่อของเฟรมวิดีโอ:** [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getPictureFormat()` แต่ภาพนั้นเป็นโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้สกัดจากสตรีมวิดีโอ
- **ภาพย่อของเฟรมเสียง:** [IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `getPictureFormat()`; มันไม่ใช่ข้อมูลเสียงที่ฝังอยู่
- **ภาพซูม:** รูปร่างซูมของสไลด์, ส่วนซูม, และสรุปซูมอาจใช้วัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) กำหนดเองผ่าน `getZoomImage()`
- **โมเดลรูปร่างที่ซ้อนกัน:** วัตถุตาราง, แผนภูมิและ SmartArt implement [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) แต่ภาพของพวกมันมักเก็บอยู่ในเซลล์ตาราง, องค์ประกอบแผนภูมิ, หรืออ็อบเจกต์การจัดรูปแบบของโหนด SmartArt
- **ภาพที่ถูกตัดหรือแปลงรูป:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ให้คุณได้ทรัพยากรภาพที่จัดเก็บไว้  มันไม่ทำการแสดงการครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน หรือเอฟเฟกต์ภาพอื่นที่รูปร่างได้กำหนดไว้

## **คำถามที่พบบ่อย**

**ฉันสามารถสกัดภาพต้นฉบับโดยไม่มีการครอป, เอฟเฟกต์ หรือการแปลงรูปร่างได้หรือไม่?**  

ใช่  เข้าถึงวัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แล้วเขียน [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ไปยังดิสก์  วิธีนี้จะเก็บภาพที่เข้ารหัสเดิมที่ฝังอยู่ในงานนำเสนอ ไม่ได้เป็นวิธีการเรนเดอร์ภาพบนสไลด์

**ฉันสามารถส่งออกทุกภาพที่สกัดเป็น PNG ได้หรือไม่?**  

ใช่  ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) เพื่อรับวัตถุ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) จากนั้นเรียก [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) พร้อมกับ [ImageFormat.Png](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/)  วิธีนี้จะทำการแปลงเอาต์พุตและอาจไม่รักษาประเภทไฟล์ต้นฉบับหรือข้อมูลเวกเตอร์

**ฉันจะหลีกเลี่ยงการบันทึกรูปเดียวกันหลายครั้งได้อย่างไร?**  

ใช้แฮชของ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) และเก็บแฮชเหล่านั้นในชุดข้อมูล  หากภาพใหม่มีแฮชที่มีอยู่แล้ว ให้ข้ามหรือบันทึกอ้างอิงไปยังไฟล์เอาต์พุตที่มีอยู่แล้ว

**ทำไมบางรูปร่างจึงไม่สร้างภาพได้?**  

กรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, กรอบอ็อบเจกต์ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิและอ็อบเจกต์ SmartArt สามารถอ้างอิงภาพได้  บางประเภทรูปร่างอาจเปิดเผยภาพผ่านอ็อบเจกต์การจัดรูปแบบที่ซ้อนกัน ดังนั้นการตรวจสอบ `getPictureFormat()` หรือ `getFillFormat()` อย่างเดียวอาจไม่พอ

**ฉันสามารถสกัดภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**  

ใช่  ใช้ [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) แล้วอ่าน `getPictureFormat().getPicture().getImage()`  วิธีนี้จะสกัดภาพโปสเตอร์ที่เก็บไว้กับเฟรมวิดีโอ ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ

**ฉันจะระบุตัวรูปร่างที่ใช้ภาพเฉพาะจากคอลเลกชันภาพของงานนำเสนอได้อย่างไร?**  

Aspose.Slides ไม่ได้เก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ไปยังรูปร่าง  ให้สร้างแมพปิ้งระหว่างการท่องรูปร่าง: ทุกครั้งที่พบการอ้างอิงภาพ ให้บันทึกหมายเลขสไลด์, เส้นทางรูปร่าง, และแฮชหรือรายการคอลเลกชันของภาพ

**ฉันสามารถสกัดภาพที่ฝังอยู่ภายในอ็อบเจกต์ OLE เช่น เอกสารที่แนบมาด้วยได้หรือไม่?**  

คุณสามารถสกัดภาพตัวอย่างของสไลด์จาก [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ได้  อย่างไรก็ตาม ภาพตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่  หากต้องการสกัดภาพจากไฟล์ที่ฝังอยู่ภายใน ให้ดึงข้อมูล OLE ออกมาแล้วตรวจสอบด้วยเครื่องมือที่เหมาะสมสำหรับประเภทไฟล์นั้น  