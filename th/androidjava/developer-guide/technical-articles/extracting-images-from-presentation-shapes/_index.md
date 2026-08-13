---
title: ดึงรูปภาพจากรูปทรงในงานนำเสนอบน Android ด้วย Java
linktitle: รูปภาพจากรูปทรง
type: docs
weight: 100
url: /th/androidjava/extracting-images-from-presentation-shapes/
keywords:
- ดึงรูปภาพ
- เรียกคืนรูปภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ดึงรูปภาพจากรูปทรงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java - โซลูชันที่รวดเร็วและเป็นมิตรต่อโค้ด."
---
## **ภาพรวม**

รูปภาพในงานนำเสนออาจปรากฏในหลายประเภทของรูปทรง: เป็นกรอบรูปภาพทั่วไป, เป็นการเติมรูปภาพที่ใช้กับรูปทรง, เป็นภาพตัวอย่างของออบเจ็กต์ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นภาพซูม, หรือเป็นรูปภาพที่ซ้อนอยู่ภายในรูปทรงตาราง, แผนภูมิ และ SmartArt. Aspose.Slides จัดเก็บรูปภาพเหล่านี้ในคอลเล็กชันรูปภาพของงานนำเสนอ, ซึ่งเปิดให้เข้าถึงผ่านวัตถุ [IImageCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimagecollection/) และ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)  

หากคุณต้องการส่งออกทรัพยากรรูปภาพทุกไฟล์ที่ฝังอยู่ในงานนำเสนอ, ให้วนลูปผ่าน `presentation.getImages()`. บทความนี้มุ่งเน้นงานที่ต่างออกไป: การสำรวจรูปทรงเพื่อค้นหาตำแหน่งที่รูปภาพถูกใช้บนสไลด์, เพื่อให้ไฟล์ที่บันทึกไว้สามารถเก็บบริบทที่มีประโยชน์เช่นหมายเลขสไลด์, ตำแหน่งรูปทรง, และประเภทของแหล่งที่ม (กรอบรูป, รูปภาพเติม, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือรูปภาพซูม).

{{% alert title="Tip" color="info" %}}
ใช้ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) เพื่อเก็บข้อมูลรูปภาพที่เข้ารหัสดั้งเดิมและประเภทไฟล์ไว้. ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) ร่วมกับ [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) เมื่อคุณต้องการทำให้ผลลัพธ์เป็นรูปแบบที่กำหนดเช่น PNG.
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `saveOriginalImage` เขียนไบต์ที่ฝังอยู่เดิม, เลือกส่วนขยายที่ปลอดภัยจากประเภท MIME, และข้ามไบนารีรูปภาพที่ซ้ำโดยใช้แฮช SHA-256.

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

## **ดึงรูปภาพจากกรอบรูป**

ใช้วิธีนี้สำหรับรูปที่แทรกเป็นออบเจ็กต์แยกเดี่ยว. [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/) เก็บรูปของมันใน `getPictureFormat().getPicture().getImage()`, ซึ่งจะคืนค่าอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/). โปรดทราบว่า [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) และ [IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/) สืบทอดจาก [IPictureFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ipictureframe/), ดังนั้นการตรวจสอบ `instanceof` นี้จะจับกรอบสื่อและส่งออกภาพตัวอย่างของพวกมันด้วย; ให้ตรวจสอบประเภทเหล่านั้นก่อนเมื่อคุณต้องการแยกการจัดการ, ดังเช่นในตัวอย่างสุดท้ายของหน้านี้ทำ.

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

## **ดึงรูปภาพจากรูปทรงที่เติมรูปภาพ**

รูปทรงสามารถใช้รูปภาพเป็นการเติมของมันได้. ตรวจสอบประเภทการเติมของรูปทรงก่อน: หากไม่ใช่ [FillType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/), จะไม่มีรูปภาพให้ดึงจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับอ็อบเจ็กต์ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และบันทึกรูปภาพแต่ละภาพเป็น PNG ผ่าน [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **ดึงรูปภาพตัวอย่างจากเฟรมออบเจ็กต์ OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของออบเจ็กต์บนสไลด์. รูปภาพนี้สามารถเข้าถึงได้ผ่าน `getSubstitutePictureFormat().getPicture().getImage()`. การดึงรูปภาพนี้จะให้ภาพตัวอย่าง, ไม่ใช่เนื้อหาแพคเกจ OLE ที่ฝังอยู่.

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

## **ดึงรูปภาพตัวอย่างจากเฟรมวิดีโอ**

[IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) สามารถเก็บภาพตัวอย่างใน `getPictureFormat().getPicture().getImage()` ได้เช่นกัน. นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพตัวอย่างจากเฟรมเสียง**

[IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/) สามารถเก็บภาพย่อใน `getPictureFormat().getPicture().getImage()` ได้. นี่คือภาพที่แสดงสำหรับออบเจ็กต์เสียงบนสไลด์.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพจากออบเจ็กต์ซูม**

รูปทรง [IZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/izoomframe/) และ [ISectionZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isectionzoomframe/) สามารถใช้รูปภาพกำหนดเอง. ให้อ่าน `getZoomImage()` จากเฟรมซูม.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพจากเฟรมซูมสรุป**

[ISummaryZoomFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/isummaryzoomframe/) ก็เป็นรูปทรงเช่นกัน. รายการส่วนของมันสามารถใช้รูปภาพกำหนดเอง, ซึ่งเปิดเผยผ่านเมธอด `getZoomImage()` ของแต่ละส่วนสรุปซูม.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพจากรูปทรงตาราง**

[ITable](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itable/) เป็นรูปทรง. รูปภาพในตารางส่วนใหญ่จะถูกเก็บเป็นการเติมรูปภาพในเซลล์ของตาราง.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพจากรูปทรงแผนภูมิ**

[IChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/) เป็นรูปทรง. ตัวอย่างด้านล่างดึงรูปภาพจากการเติมรูปภาพของพื้นที่แผนภูมิ.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **ดึงรูปภาพจากรูปทรง SmartArt**

[ISmartArt](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ismartart/) อ็อบเจ็กต์เป็นรูปทรง. ขึ้นอยู่กับการจัดวางของ SmartArt, รูปภาพอาจถูกเก็บในการเติมสัญลักษณ์ของโหนดหรือในรูปแบบการเติมของรูปทรงโหนด.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **รวมรูปภาพภายในรูปทรงที่จัดกลุ่ม**

รูปทรงที่จัดกลุ่มมีคอลเล็กชันรูปทรงของตนเอง. เมธอดช่วยเหลือ `enumerateShapes` ที่ใช้ร่วมกันมีตัวเลือก `includeGroupedShapes`. ตั้งค่าเป็น `true` เมื่อคุณต้องการตรวจสอบรูปทรงภายในอ็อบเจ็กต์ [IGroupShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igroupshape/) ตัวอย่างด้านล่างดึงรูปภาพจากกรอบรูป, รูปทรงที่เติมรูปภาพ, ตัวอย่างออบเจ็กต์ OLE, ภาพย่อของเฟรมวิดีโอ, และภาพย่อของเฟรมเสียง. เพื่อรวมรูปภาพจากตาราง, แผนภูมิ, SmartArt, และรูปภาพซูมสรุปด้วย, ให้ใช้ตรรกะการดึงข้อมูลเฉพาะจากส่วนก่อนหน้าโดยคงการสำรวจรูปทรงแบบเรียกซ้ำ.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **กรณีพิเศษและหมายเหตุเชิงปฏิบัติ**

- **รูปภาพซ้ำ:** รูปทรงหลายรูปอาจอ้างอิงรูปภาพเดียวกันหรือรูปภาพแยกต่างหากที่มีไบต์เหมือนกัน. ทำแฮชโดยใช้ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ก่อนเขียนไฟล์หากคุณต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อรูปภาพที่ไม่ซ้ำ.
- **ข้อมูลต้นฉบับ vs. ผลลัพธ์ที่แปลง:** การบันทึก [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) จะรักษาข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังไว้. การบันทึก [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) ผ่าน [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์ที่สอดคล้องกัน.
- **ประเภทการเติมที่ไม่รองรับ:** รูปทรงแบบสีทึบ, ไขวามูบ, ลวดลาย, และไม่มีการเติมจะไม่มีการเติมรูปภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) ก่อนอ่าน `getPictureFillFormat()`.
- **รูปทรงที่จัดกลุ่ม:** คอลเล็กชันรูปทรงสไลด์ระดับบนไม่ได้ทำให้กลุ่มแบน. ควรตรวจสอบแบบเรียกซ้ำ [IGroupShape.getShapes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/igroupshape/#getShapes--) เมื่อเนื้อหากลุ่มมีความสำคัญ.
- **ตัวอย่างออบเจ็กต์ OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getSubstitutePictureFormat()`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์. ไม่ใช่ไฟล์ที่ฝังอยู่ภายในออบเจ็กต์ OLE.
- **ภาพย่อของเฟรมวิดีโอ:** [IVideoFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `getPictureFormat()`, แต่ภาพนั้นเป็นเพียงโปสเตอร์ที่แสดงบนสไลด์. ไม่ได้ดึงจากสตรีมวิดีโอ.
- **ภาพย่อของเฟรมเสียง:** [IAudioFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iaudioframe/) อาจเปิดเผยไอคอนหรือภาพย่อผ่าน `getPictureFormat()`; ซึ่งไม่ได้เป็นข้อมูลเสียงที่ฝังอยู่.
- **รูปภาพซูม:** รูปทรงซูมสไลด์, ซูมส่วน, และซูมสรุปอาจใช้วัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) กำหนดเองผ่าน `getZoomImage()`.
- **โมเดลรูปทรงที่ซ้อนกัน:** ออบเจ็กต์ตาราง, แผนภูมิ, และ SmartArt implements [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/), แต่รูปภาพของพวกเขามักถูกเก็บในเซลล์ตารางที่ซ้อนอยู่, องค์ประกอบของแผนภูมิ, หรือวัตถุการจัดรูปแบบโหนดของ SmartArt.
- **รูปภาพที่ถูกครอปหรือแปลง:** การเข้าถึง [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) จะให้ทรัพยากรรูปภาพที่เก็บไว้. มันไม่ได้ทำการแสดงผลการครอป, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่รูปทรงนำมาใช้.

## **คำถามที่พบบ่อย**

### ฉันสามารถดึงรูปภาพต้นฉบับโดยไม่ต้องตัดครอป, เอฟเฟกต์ หรือการแปลงรูปทรงได้หรือไม่?

ใช่. เข้าถึงอ็อบเจ็กต์ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) และเขียน [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) ลงดิสก์. วิธีนี้จะรักษารูปภาพที่เข้ารหัสดั้งเดิมที่เก็บอยู่ในงานนำเสนอ, ไม่ใช่วิธีที่รูปภาพถูกเรนเดอร์บนสไลด์.

### ฉันสามารถส่งออกทุกรูปภาพที่ดึงออกเป็น PNG ได้หรือไม่?

ใช่. ใช้ [IPPImage.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getImage--) เพื่อรับอ็อบเจ็กต์ [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/), แล้วเรียก [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) พร้อมกับ [ImageFormat.Png](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/imageformat/). วิธีนี้จะแปลงผลลัพธ์และอาจไม่รักษาชนิดไฟล์ต้นฉบับหรือข้อมูลเวกเตอร์.

### ฉันจะหลีกเลี่ยงการบันทึกรูปภาพเดียวกันหลายครั้งอย่างไร?

ใช้แฮชของ [IPPImage.getBinaryData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/#getBinaryData--) และเก็บแฮชไว้ในชุด. หากรูปภาพใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกรายการอ้างอิงเพิ่มเติมไปยังไฟล์ผลลัพธ์ที่มีอยู่.

### ทำไมบางรูปทรงจึงไม่สร้างรูปภาพ?

กรอบรูป, รูปทรงที่เติมรูปภาพ, เฟรมออบเจ็กต์ OLE, เฟรมสื่อ, เฟรมซูม, ตาราง, แผนภูมิ, และออบเจ็กต์ SmartArt สามารถอ้างอิงรูปภาพได้. บางประเภทของรูปทรงเปิดเผยรูปภาพผ่านวัตถุการจัดรูปแบบที่ซ้อนกัน, ดังนั้นการตรวจสอบแบบง่าย `getPictureFormat()` หรือ `getFillFormat()` ของรูปทรงอาจไม่เพียงพอ.

### ฉันสามารถดึงภาพโปสเตอร์ที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?

ใช่. ใช้ [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) แล้วอ่าน `getPictureFormat().getPicture().getImage()`. วิธีนี้ดึงภาพโปสเตอร์ที่เก็บกับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

### ฉันจะกำหนดได้ว่ารูปทรงใดใช้รูปภาพเฉพาะจากคอลเล็กชันรูปภาพของงานนำเสนอ?

Aspose.Slides ไม่ได้จัดเก็บลิงก์ย้อนกลับจาก [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ไปยังรูปทรง. ให้สร้างแผนที่ระหว่างการสำรวจ: ทุกครั้งที่พบการอ้างอิงรูปภาพ, ให้บันทึกหมายเลขสไลด์, เส้นทางรูปทรง, และแฮชหรือรายการคอลเล็กชันของรูปภาพ.

### ฉันสามารถดึงรูปภาพที่ฝังอยู่ภายในออบเจ็กต์ OLE เช่น เอกสารที่แนบได้หรือไม่?

คุณสามารถดึงภาพตัวอย่างสไลด์ของอ็อบเจ็กต์ OLE จาก [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) ได้. อย่างไรก็ตาม, ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่เอง. เพื่อดึงรูปภาพจากไฟล์ที่ฝังอยู่, ให้ดึงข้อมูล OLE ออกมาและตรวจสอบด้วยเครื่องมือที่เหมาะสมสำหรับประเภทไฟล์นั้น.