---
title: ดึงภาพจากรูปทรงในงานนำเสนอด้วย Java
linktitle: ภาพจากรูปทรง
type: docs
weight: 100
url: /th/java/extracting-images-from-presentation-shapes/
keywords:
- ดึงภาพ
- เรียกคืนภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ดึงภาพจากรูปทรงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java - วิธีแก้ไขที่รวดเร็วและเป็นมิตรต่อโค้ด"
---
## **ภาพรวม**

ภาพในงานนำเสนออาจปรากฏในหลายรูปแบบของรูปทรง: เป็นกรอบภาพทั่วไป, เป็นการเติมภาพที่ใช้กับรูปทรง, เป็นภาพตัวอย่างของวัตถุ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือออดิโอ, เป็นภาพซูม, หรือเป็นภาพที่ซ้อนอยู่ในรูปทรงตาราง, แผนภูมิ, และ SmartArt. Aspose.Slides จัดเก็บภาพเหล่านี้ในคอลเลกชันภาพของงานนำเสนอ ซึ่งเปิดให้เข้าถึงผ่านวัตถุ [IImageCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides.iimagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/)  

ถ้าคุณต้องการส่งออกทุกทรัพยากรภาพที่ฝังอยู่ในงานนำเสนอ, ให้วนลูป `presentation.getImages()` . บทความนี้มุ่งเน้นงานที่ต่างออกไป: การท่องรูปทรงเพื่อค้นหาว่าภาพถูกใช้ในสไลด์ใด, เพื่อให้ไฟล์ที่บันทึกได้เก็บข้อมูลบริบทที่เป็นประโยชน์ เช่น หมายเลขสไลด์, ตำแหน่งรูปทรง, และประเภทแหล่งที่ม (กรอบภาพ, ภาพเติม, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือภาพซูม).

{{% alert title="Tip" color="primary" %}}
ใช้ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getBinaryData--) เพื่อรักษาข้อมูลภาพที่เข้ารหัสต้นฉบับและประเภทไฟล์. ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getImage--) ร่วมกับ [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides.iimage/#save-java.lang.String-int-) เมื่อคุณต้องการทำให้ผลลัพธ์เป็นรูปแบบเฉพาะเช่น PNG.
{{% /alert %}}

## **วิธีการช่วยเหลือที่ใช้ร่วมกัน**

วิธีการช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `saveOriginalImage` เขียนไบต์ที่ฝังไว้เดิม, เลือกนามสกุลที่ปลอดภัยจาก MIME type, และข้ามไฟล์ภาพที่ซ้ำกันโดยใช้แฮช SHA-256.

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

## **ดึงภาพจากกรอบภาพ**

ใช้วิธีนี้สำหรับภาพที่แทรกเป็นวัตถุอิสระ. [IPictureFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ipictureframe/) เก็บภาพของมันใน `getPictureFormat().getPicture().getImage()`, ซึ่งจะคืนวัตถุ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/).

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

## **ดึงภาพจากรูปทรงที่เติมด้วยภาพ**

รูปทรงสามารถใช้ภาพเป็นการเติมได้. ตรวจสอบประเภทการเติมของรูปทรงก่อน: หากไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides.filltype/), จะไม่มีภาพให้ดึงจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับวัตถุ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides.iautoshape/) และบันทึกแต่ละภาพเป็น PNG ผ่าน [IPPImage.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getImage--).

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

## **ดึงภาพตัวอย่างจากกรอบวัตถุ OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ioleobjectframe/) สามารถมีภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของวัตถุบนสไลด์. ภาพนี้สามารถเข้าถึงได้ผ่าน `getSubstitutePictureFormat().getPicture().getImage()`. การดึงภาพนี้จะให้ภาพตัวอย่าง, ไม่ใช่เนื้อหาของแพคเกจ OLE ที่ฝังอยู่.

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

## **ดึงภาพตัวอย่างจากกรอบวิดีโอ**

[IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ivideoframe/) สามารถเก็บภาพตัวอย่างไว้ใน `getPictureFormat().getPicture().getImage()`. นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

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

## **ดึงภาพตัวอย่างจากกรอบออดิโอ**

[IAudioFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.iaudioframe/) สามารถเก็บภาพย่อใน `getPictureFormat().getPicture().getImage()`. นี่คือภาพที่แสดงสำหรับออบเจ็กต์ออดิโอบนสไลด์.

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

## **ดึงภาพจากวัตถุซูม**

รูปทรง [IZoomFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.isectionzoomframe/) สามารถใช้ภาพกำหนดเอง. อ่าน `getZoomImage()` จากกรอบซูม.

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

## **ดึงภาพจากกรอบซูมสรุป**

[ISummaryZoomFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.isummaryzoomframe/) ก็เป็นรูปทรงหนึ่ง. รายการส่วนของมันสามารถใช้ภาพกำหนดเองได้, ซึ่งเปิดให้เข้าถึงผ่านเมธอด `getZoomImage()` ของแต่ละส่วนซูมสรุป.

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

## **ดึงภาพจากรูปทรงตาราง**

[ITable](https://reference.aspose.com/slides/th/java/com.aspose.slides.itable/) เป็นรูปทรง. ภาพในตารางมักจะเก็บเป็นการเติมภาพในเซลล์ของตาราง.

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

## **ดึงภาพจากรูปทรงแผนภูมิ**

[IChart](https://reference.aspose.com/slides/th/java/com.aspose.slides.ichart/) เป็นรูปทรง. ตัวอย่างด้านล่างดึงภาพจากการเติมภาพของพื้นที่แผนภูมิ.

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

## **ดึงภาพจากรูปทรง SmartArt**

[ISmartArt](https://reference.aspose.com/slides/th/java/com.aspose.slides.ismartart/) เป็นวัตถุรูปทรง. ขึ้นอยู่กับการจัดวางของ SmartArt, ภาพอาจเก็บอยู่ในการเติมของโหนดแบบ bullet หรือในรูปแบบการเติมของรูปทรงโหนด.

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

## **รวมภาพที่อยู่ภายในรูปทรงที่จัดกลุ่ม**

รูปทรงที่จัดกลุ่มมีคอลเลกชันรูปทรกของตนเอง. ตัวช่วย `enumerateShapes` ที่ใช้ร่วมกันมีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปทรงภายในวัตถุ [IGroupShape](https://reference.aspose.com/slides/th/java/com.aspose.slides.igroupshape/). ตัวอย่างด้านล่างดึงภาพจากกรอบภาพ, รูปทรงที่เติมด้วยภาพ, ตัวอย่าง OLE, ภาพย่อของเฟรมวิดีโอ, และภาพย่อของเฟรมออดิโอ. เพื่อนำภาพจากตาราง, แผนภูมิ, SmartArt, และซูมสรุปเข้ามาด้วย, ใช้ตรรกะการดึงเฉพาะจากส่วนก่อนหน้าโดยยังคงการท่องรูปทรงแบบเรียกซ้ำเหมือนเดิม.

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

## **กรณีพิเศษและข้อสังเกตเชิงปฏิบัติ**

- **ภาพซ้ำ:** รูปทรงหลายรูปอาจอ้างอิงภาพเดียวกันหรือภาพแยกที่มีไบต์เดียวกัน. แฮช [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getBinaryData--) ก่อนบันทึกไฟล์หากคุณต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อภาพที่ไม่ซ้ำกัน.
- **ข้อมูลดั้งเดิม vs. ผลลัพธ์ที่แปลง:** การบันทึก [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getBinaryData--) จะรักษาข้อมูล JPEG, PNG, GIF, SVG, EMF, หรือ WMF ที่ฝังอยู่. การบันทึก [IPPImage.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getImage--) ผ่าน [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides.iimage/#save-java.lang.String-int-) มีประโยชน์เมื่อคุณต้องการผลลัพธ์ในรูปแบบเดียวกัน.
- **ประเภทการเติมที่ไม่รองรับ:** รูปทรงที่เป็นสีทึบ, ไร่ต์, ลาย, หรือไม่มีการเติมจะไม่มีการเติมภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/java/com.aspose.slides.filltype/) ก่อนอ่าน `getPictureFillFormat()`.
- **รูปทรงที่จัดกลุ่ม:** คอลเลกชันรูปทรงระดับบนของสไลด์ไม่ได้ทำให้กลุ่มแบนราบ. ตรวจสอบ [IGroupShape.getShapes](https://reference.aspose.com/slides/th/java/com.aspose.slides.igroupshape/#getShapes--) อย่างเรียกซ้ำเมื่อเนื้อหากลุ่มมีความสำคัญ.
- **ตัวอย่าง OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ioleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getSubstitutePictureFormat()`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์, ไม่ใช่ไฟล์ที่ฝังอยู่ในวัตถุ OLE.
- **ภาพย่อของเฟรมวิดีโอ:** [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ivideoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getPictureFormat()`, แต่ภาพนั้นเป็นโปสเตอร์ที่แสดงบนสไลด์, ไม่ได้มาจากสตรีมวิดีโอ.
- **ภาพย่อของเฟรมออดิโอ:** [IAudioFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.iaudioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `getPictureFormat()`; ไม่ได้เป็นข้อมูลออดิโอที่ฝังอยู่.
- **ภาพซูม:** รูปทรงซูมสไลด์, ซูมส่วน, และซูมสรุปอาจใช้วัตถุ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/) กำหนดเองผ่าน `getZoomImage()`.
- **โมเดลรูปทรงซ้อนกัน:** วัตถุตาราง, แผนภูมิ, และ SmartArt เข้าสู่ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides.ishape/), แต่ภาพของพวกเขามักเก็บไว้ในเซลล์ตาราง, องค์ประกอบแผนภูมิ, หรือออบเจ็กต์การฟอร์แมตของโหนด SmartArt ที่ซ้อนกัน.
- **ภาพที่ถูกครอปหรือแปลง:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/) จะให้ทรัพยากรภาพที่เก็บไว้. มันไม่แสดงการครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟ็กต์ภาพอื่นที่รูปทรงทำ.

## **คำถามที่พบบ่อย**

**ฉันสามารถดึงภาพต้นฉบับโดยไม่ครอป, ไม่เอฟเฟ็กต์, หรือการแปลงรูปทรงได้หรือไม่?**

ใช่. เข้าถึงวัตถุ [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/) แล้วเขียน [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getBinaryData--) ลงดิสก์. วิธีนี้จะรักษาภาพที่เข้ารหัสต้นฉบับที่เก็บอยู่ในงานนำเสนอ, ไม่ใช่วิธีที่ภาพถูกเรนเดอร์บนสไลด์.

**ฉันสามารถส่งออกทุกภาพที่ดึงมาผ่าน PNG ได้หรือไม่?**

ใช่. ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getImage--) เพื่อรับวัตถุ [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.iimage/), แล้วเรียก [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides.iimage/#save-java.lang.String-int-) พร้อมกับ [ImageFormat.Png](https://reference.aspose.com/slides/th/java/com.aspose.slides.imageformat/). วิธีนี้จะทำให้ผลลัพธ์เป็น PNG แต่อาจไม่รักษาชนิดไฟล์หรือข้อมูลเวกเตอร์ดั้งเดิม.

**ฉันจะหลีกเลี่ยงการบันทึกภาพเดียวกันหลายครั้งได้อย่างไร?**

ใช้แฮชของ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/#getBinaryData--) และเก็บแฮชเหล่านั้นในเซ็ต. หากภาพใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามการบันทึกหรือบันทึกการอ้างอิงอื่นไปยังไฟล์ผลลัพธ์ที่มีอยู่.

**ทำไมบางรูปทรงถึงไม่สร้างภาพ?**

กรอบภาพ, รูปทรงที่เติมด้วยภาพ, กรอบวัตถุ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิ, และออบเจ็กต์ SmartArt สามารถอ้างอิงภาพได้. บางประเภทรูปทรงเปิดเผยภาพผ่านออบเจ็กต์ฟอร์แมตที่ซ้อนกัน, ดังนั้นการตรวจสอบเพียง `getPictureFormat()` หรือ `getFillFormat()` ของรูปทรงอาจไม่เพียงพอ.

**ฉันสามารถดึงภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**

ใช่. ใช้ [IVideoFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides.ivideoframe/) แล้วอ่าน `getPictureFormat().getPicture().getImage()`. วิธีนี้จะดึงภาพโปสเตอร์ที่เก็บไว้กับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

**ฉันสามารถกำหนดได้ว่ารูปทรงใดใช้ภาพเฉพาะจากคอลเลกชันภาพของงานนำเสนอได้อย่างไร?**

Aspose.Slides ไม่เก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides.ippimage/) ไปยังรูปทรง. คุณต้องสร้างแผนที่ระหว่างการท่อง: ทุกครั้งที่พบการอ้างอิงภาพ, บันทึกหมายเลขสไลด์, เส้นทางรูปทรง, และแฮชหรือรายการคอลเลกชันของภาพ.

**ฉันสามารถดึงภาพที่ฝังอยู่ในวัตถุ OLE, เช่น เอกสารที่แนบมาด้วย, ได้หรือไม่?**

คุณสามารถดึงตัวอย่างสไลด์ของวัตถุ OLE จาก [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) ได้. อย่างไรก็ตาม ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่จริง. หากต้องการดึงภาพจากไฟล์ที่ฝังอยู่, ต้องดึงข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่รองรับประเภทไฟล์นั้น.