---
title: استخراج الصور من أشكال العرض التقديمي في Android عبر Java
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/androidjava/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Android عبر Java - حل سريع وسهل الاستخدام في الكود."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بأشكال متعددة: كإطارات صور عادية، كملئ صور يُطبّق على الأشكال، كصور معاينة كائن OLE، كصورة مصغرة لإطار فيديو أو صوت، كصور تكبير، أو كصور متداخلة داخل جداول، مخططات، وأشكال SmartArt. تقوم Aspose.Slides بتخزين تلك الصور في مجموعة صور العرض التقديمي، التي يمكن الوصول إليها عبر كائنات [IImageCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimagecollection/) و[IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/).

إذا كنت تحتاج فقط إلى تصدير كل مورد صورة مضمن في العرض، يمكنك التكرار عبر `presentation.getImages()`. يركز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على الأماكن التي تُستخدم فيها الصور على الشرائح، بحيث يمكن للملفات المحفوظة أن تحتفظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، ملئ صورة، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="info" %}}
استخدم [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getBinaryData--) للحفاظ على بيانات الصورة الأصلية المشفّرة ونوع الملف. استخدم [IPPImage.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getImage--) مع [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) عندما تريد توحيد الناتج إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعد المشتركة**

طرق المساعد أدناه تُبقي الأمثلة قصيرة. `saveOriginalImage` يكتب البايتات الأصلية المدمجة، يختار امتدادًا آمنًا من نوع MIME، ويتخطى الصور الثنائية المكررة عبر تجزئة SHA-256.

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

استخدم هذا النهج للصور المُدرجة ككائنات مستقلة. يخزن [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/) صورته في `getPictureFormat().getPicture().getImage()`، الذي يُعيد كائنًا من نوع [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/). لاحظ أن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) و[IAudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/) يُشتقان من [IPictureFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipictureframe/)، لذا يتحقق هذا الفحص `instanceof` أيضًا من إطارات الوسائط ويصدّر صور معاينتها؛ اختبر تلك الأنواع أولاً عندما تريد معالجتها بشكل منفصل، كما في المثال الأخير في هذه الصفحة.

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال استخدام صورة كملئ لها. افحص نوع ملئ الشكل أولاً: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/)، فلا توجد صورة لاستخراجها من ذلك الملئ. المثال أدناه يتعامل مع كائنات [IAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iautoshape/) ويحفظ كل صورة كـ PNG عبر [IPPImage.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getImage--).

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

## **استخراج صور معاينة إطارات كائن OLE**

يمكن أن يحتوي [IOleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/) على صورة بديلة تُستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `getSubstitutePictureFormat().getPicture().getImage()`. استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **استخراج صور معاينة إطارات الفيديو**

يمكن أن يخزن [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) أيضًا صورة معاينة في `getPictureFormat().getPicture().getImage()`. هذه هي الملصق أو الصورة المصغرة المعروضة على الشريحة، وليس إطارًا مُفككًا من تدفق الفيديو.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **استخراج صور معاينة إطارات الصوت**

يمكن أن يخزن [IAudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/) صورة مصغرة في `getPictureFormat().getPicture().getImage()`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

يمكن للأشكال [IZoomFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/izoomframe/) و[ISectionZoomFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectionzoomframe/) استخدام صور مخصصة. اقرأ `getZoomImage()` من إطار التكبير.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **استخراج الصور من إطارات التكبير الموجز**

يُعد [ISummaryZoomFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isummaryzoomframe/) أيضًا شكلًا. يمكن لعناصر القسم الخاصة به أن تستخدم صورًا مخصصة، تُعرض من خلال طريقة كل قسم `getZoomImage()`.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

يُعد [ITable](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itable/) شكلًا. تُخزن الصور في الجدول عادةً كملئ صور في خلايا الجدول.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

يُعد [IChart](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ichart/) شكلًا. المثال أدناه يستخرج صورة من ملئ صورة منطقة المخطط.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

كائن [ISmartArt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ismartart/) هو شكل. بناءً على تخطيط SmartArt، قد تُخزن الصور في ملئ نقط التعداد للعقد أو في تنسيقات ملئ أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعات أشكال خاصة بها. المساعد المشترك `enumerateShapes` يحتوي على خيار `includeGroupedShapes`. اضبطه على `true` عندما تريد فحص الأشكال داخل كائنات [IGroupShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igroupshape/). المثال أدناه يستخرج صورًا من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائن OLE، مصغرات إطارات الفيديو، ومصغرات إطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وتكبير الموجز أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس استعراض الأشكال المتكرر.

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

## **حالات خاصة وملاحظات عملية**

- **صور مكررة:** قد تشير عدة أشكال إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getBinaryData--) قبل كتابة الملفات إذا أردت ملفًا واحدًا لكل صورة فريدة.
- **البيانات الأصلية مقابل المخرجات المحوّلة:** حفظ [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getBinaryData--) يحافظ على بيانات JPEG، PNG، GIF، SVG، EMF أو WMF المدمجة. حفظ [IPPImage.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getImage--) عبر [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** الأشكال الصلبة، المتدرجة، النمطية، وبدون ملء لا تحتوي على ملء صورة. افحص [FillType](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/filltype/) قبل قراءة `getPictureFillFormat()`.
- **الأشكال المجمعة:** مجموعة الأشكال على مستوى الشريحة لا تُسطّح المجموعات. افحص [IGroupShape.getShapes](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/igroupshape/#getShapes--) بشكل متكرر عندما تكون محتويات المجموعات مهمة.
- **معاينات كائن OLE:** قد يُظهر [IOleObjectFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/) صورة معاينة عبر `getSubstitutePictureFormat()`، لكن هذه الصورة هي فقط معاينة الشريحة وليست الملف المدمج داخل كائن OLE.
- **مصغرات إطارات الفيديو:** قد يُظهر [IVideoFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/) صورة معاينة عبر `getPictureFormat()`، لكن هذه الصورة هي فقط الملصق المعروض على الشريحة ولا تُستخرج من تدفق الفيديو.
- **مصغرات إطارات الصوت:** قد يُظهر [IAudioFrame](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iaudioframe/) أيقونة أو مصغرة عبر `getPictureFormat()`؛ وهي ليست بيانات الصوت المدمجة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الموجز صورًا مخصصة من نوع [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) عبر `getZoomImage()`.
- **نماذج الأشكال المتداخلة:** تنفّذ كائنات الجدول، المخطط، وSmartArt واجهة [IShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishape/)، لكن صورها غالبًا ما تُخزن في كائنات تنسيق خلية الجدول، عنصر المخطط، أو عقدة SmartArt المتداخلة.
- **الصور المقصوصة أو المُحوّلة:** الوصول إلى [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) يمنحك مصدر الصورة المخزن. لا يُطبق القص، الشفافية، إعادة اللون، الدوران أو أي تأثير بصري آخر يُطبق على الشكل.

## **الأسئلة الشائعة**

### هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحويلات الشكل؟

نعم. وصول إلى كائن [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) واكتب [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getBinaryData--) إلى القرص. هذا يحافظ على الصورة المشفّرة الأصلية المخزنة في العرض، وليس الطريقة التي تُعرض بها الصورة على الشريحة.

### هل يمكنني تصدير كل صورة مستخرجة كـ PNG؟

نعم. استخدم [IPPImage.getImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getImage--) للحصول على كائن [IImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/)، ثم استدعِ [IImage.save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) مع [ImageFormat.Png](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/imageformat/). هذا يحول الناتج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

### كيف أتجنب حفظ نفس الصورة أكثر من مرة؟

استخدم تجزئة [IPPImage.getBinaryData](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/#getBinaryData--) واحتفظ بالتجزئات في مجموعة. إذا كانت الصورة الجديدة لها تجزئة موجودة مسبقًا، تجاوزها أو سجّل إشارة أخرى إلى ملف الإخراج الحالي.

### لماذا لا تنتج بعض الأشكال صورة؟

إطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt يمكنها الإشارة إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فحص بسيط بـ `getPictureFormat()` أو `getFillFormat()` لل shape قد لا يكون كافيًا.

### هل يمكنني استخراج المصغرة المعروضة لإطار فيديو؟

نعم. استخدم [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) واقرأ `getPictureFormat().getPicture().getImage()`. هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

### كيف يمكنني تحديد الأشكال التي تستخدم صورة معينة من مجموعة صور العرض؟

لا تخزن Aspose.Slides روابط عكسية من [IPPImage](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ippimage/) إلى الأشكال. أنشئ خريطة أثناء الاستعراض: كلما وجدت إشارة إلى صورة، سجّل رقم الشريحة، مسار الشكل، وتجزيء الصورة أو عنصر المجموعة.

### هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟

يمكنك استخراج معاينة الشريحة لكائن OLE عبر [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--). ومع ذلك، هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، استخرج بيانات OLE وافحصها بأدوات مخصصة لنوع ذلك الملف.