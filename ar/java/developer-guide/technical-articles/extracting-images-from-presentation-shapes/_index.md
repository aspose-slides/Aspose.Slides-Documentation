---
title: استخراج الصور من أشكال العرض التقديمي في Java
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للغة Java - حل سريع ومناسب للشفرة."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بعدة أنواع من الأشكال: كإطارات صور عادية، كملء صور يُطبق على الأشكال، كصور معاينة كائن OLE، كصوَر مصغرة لإطارات الفيديو أو الصوت، كصور تكبير، أو كصور متداخلة داخل أشكال الجداول أو المخططات أو SmartArt. تقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، التي تُعرَض عبر كائنات [IImageCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) .

إذا كنت بحاجة فقط لتصدير كل موارد الصور المدمجة في العرض، يمكنك التكرار عبر `presentation.getImages()`. يركز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على الأماكن التي تُستَخدم فيها الصور على الشرائح، حتى تستطيع الملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="نصيحة" color="info" %}}
استخدم [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getBinaryData--) للحفاظ على بيانات الصورة المشفّرة الأصلية ونوع الملف. استخدم [IPPImage.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getImage--) مع [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) عندما تريد توحيد المخرجات إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعدة المشتركة**

الطرق المساعدة أدناه تجعل الأمثلة مختصرة. `saveOriginalImage` يكتب البايتات المدمجة الأصلية، يختار امتدادًا آمنًا من نوع MIME، ويتخطى الصور الثنائية المكررة باستخدام تجزئة SHA-256.

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

## **استخراج الصور من إطارات الصور**

استخدم هذا النهج للصور التي تُدرج ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipictureframe/) صورته في `getPictureFormat().getPicture().getImage()`، والتي تُعيد كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) .

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال أن تستخدم صورة كملء لها. تحقق أولًا من نوع ملء الشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/)، فلا توجد صورة لاستخراجها من ذلك الملء. المثال أدناه يتعامل مع كائنات [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) ويحفظ كل صورة كملف PNG عبر [IPPImage.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getImage--) .

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن لإطار [IOleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleobjectframe/) أن يحتوي على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `getSubstitutePictureFormat().getPicture().getImage()` . استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن لإطار [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) أيضًا أن يخزن صورة معاينة في `getPictureFormat().getPicture().getImage()` . هذه هي الصورة الظاهرة كملصق أو مصغرة على الشريحة، وليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لإطار [IAudioFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/) أن يخزن مصغرة في `getPictureFormat().getPicture().getImage()` . هذه هي الصورة التي تُظهر كائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن للأشكال [IZoomFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectionzoomframe/) أن تستخدم صورًا مخصصة. اقرأ `getZoomImage()` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير الملخص**

إطار [ISummaryZoomFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isummaryzoomframe/) هو أيضًا شكل. يمكن لعناصر القسم الخاصة به أن تستخدم صورًا مخصصة، تُعرَض من خلال طريقة `getZoomImage()` لكل قسم ملخص.

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

## **استخراج الصور من أشكال الجداول**

يُعتبر [ITable](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itable/) شكلًا. تُخزن الصور في جدول عادةً كملء صور في خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

يُعتبر [IChart](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/) شكلًا. المثال أدناه يستخرج صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

يُعتبر كائن [ISmartArt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ismartart/) شكلًا. اعتمادًا على تخطيط SmartArt، قد تُخزن الصور في ملء نقاط النقاط أو في تنسيقات أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعة أشكال خاصة بها. يحتوي المساعد المشترك `enumerateShapes` على خيار `includeGroupedShapes`. ضع قيمته `true` عندما تريد فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igroupshape/) . المثال أدناه يستخرج الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائن OLE، مصغرات إطارات الفيديو، ومصغرات إطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور التكبير الملخص أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس الاستعراض المتكرر للأشكال.

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

## **حالات خاصة وملاحظات عملية**

- **الصور المكررة:** قد تُشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة لها بايتات متطابقة. احسب تجزئة [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getBinaryData--) قبل كتابة الملفات إذا كنت تريد ملفًا واحدًا لكل صورة فريدة.
- **البيانات الأصلية مقابل المخرجات المحوَّلة:** حفظ [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getBinaryData--) يحافظ على بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المدمجة. حفظ [IPPImage.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getImage--) عبر [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** الأشكال ذات الملء الصلب، المتدرج، النمط، أو بدون ملء لا تحتوي على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/filltype/) قبل قراءة `getPictureFillFormat()`.
- **الأشكال المجمعة:** مجموعة أشكال الشريحة العليا لا تُفكّ التجميع تلقائيًا. افحص [IGroupShape.getShapes](https://reference.aspose.com/slides/ar/java/com.aspose.slides/igroupshape/#getShapes--) بشكل متكرر عندما تكون المحتويات المجمعة مهمة.
- **معاينات كائن OLE:** قد يُظهر إطار [IOleObjectFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleobjectframe/) صورة معاينة عبر `getSubstitutePictureFormat()`، لكن هذه الصورة هي فقط معاينة الشريحة وليست الملف المدمج داخل كائن OLE.
- **مصغرات إطارات الفيديو:** قد يُظهر إطار [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) صورة معاينة عبر `getPictureFormat()`، لكن هذه الصورة هي فقط الملصق الظاهر على الشريحة ولا تُستخرج من تدفق الفيديو.
- **مصغرات إطارات الصوت:** قد يُظهر إطار [IAudioFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iaudioframe/) أيقونة أو مصغرة عبر `getPictureFormat()`؛ ليست بيانات الصوت المدمجة.
- **صور التكبير:** قد تستخدم أشكال التكبير، تكبير القسم، وتكبير الملخص صورًا مخصصة من نوع [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) عبر `getZoomImage()`.
- **نماذج الأشكال المتداخلة:** تُطبق كائنات الجدول، المخطط، وSmartArt واجهة [IShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishape/) ، لكن صورها غالبًا ما تُخزن في تنسيقات الخلايا المتداخلة أو عناصر المخطط أو عقد SmartArt.
- **الصور المقصّاة أو المُحوَّلة:** الوصول إلى [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) يمنحك المورد الصوري المخزن. لا يُطبق قص، شفافية، إعادة تلوين، دوران أو تأثيرات بصرية أخرى تُطبق على الشكل.

## **الأسئلة المتكررة**

### هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحويلات الشكل؟

نعم. يمكنك الوصول إلى كائن [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) وكتابة [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getBinaryData--) إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض، وليس الطريقة التي تُعرض بها على الشريحة.

### هل يمكنني تصدير كل صورة مستخرجة كملف PNG؟

نعم. استخدم [IPPImage.getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getImage--) للحصول على كائن [IImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/) ، ثم استدعِ [IImage.save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iimage/#save-java.lang.String-int-) مع [ImageFormat.Png](https://reference.aspose.com/slides/ar/java/com.aspose.slides/imageformat/) . سيؤدي ذلك إلى تحويل المخرج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

### كيف أتجنب حفظ نفس الصورة أكثر من مرة؟

استخدم تجزئة [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/#getBinaryData--) واحتفظ بالتجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة بالفعل، فتجاوزها أو سجِّل مرجعًا آخر إلى ملف الإخراج الموجود.

### لماذا لا تنتج بعض الأشكال صورة؟

يمكن لإطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt أن تُشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فحص بسيط لـ `getPictureFormat()` أو `getFillFormat()` قد لا يكون كافيًا دائمًا.

### هل يمكنني استخراج المصغرة المعروضة لإطار الفيديو؟

نعم. استخدم [IVideoFrame](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ivideoframe/) واقرأ `getPictureFormat().getPicture().getImage()` . هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو نفسه.

### كيف يمكنني تحديد الأشكال التي تستخدم صورة معينة من مجموعة صور العرض؟

لا تخزن Aspose.Slides روابط عكسية من [IPPImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ippimage/) إلى الأشكال. يمكنك بناء خريطة أثناء الاستعراض: كلما وجدت مرجع صورة، سجل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو فهرسها في المجموعة.

### هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟

يمكنك استخراج معاينة الشريحة لكائن OLE عبر [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) . ومع ذلك، هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، عليك استخراج بيانات OLE وفحصها بأدوات مناسبة لنوع الملف.