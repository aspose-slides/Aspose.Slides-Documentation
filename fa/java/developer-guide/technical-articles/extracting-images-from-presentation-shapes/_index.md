---
title: استخراج تصاویر از اشکال ارائه در جاوا
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/java/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- دستیابی به تصویر
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **مروری کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به‌عنوان فریم‌های تصویری معمولی، به‌عنوان پرکردن تصویر بر روی اشکال، به‌عنوان پیش‌نمایش‌های شیء OLE، به‌عنوان تصویر کوچک فریم‌های ویدئو یا صدا، به‌عنوان تصاویر زوم، یا به‌عنوان تصاویری که داخل جدول، نمودار و اشکال SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعه تصاویر ارائه ذخیره می‌کند که از طریق اشیای [IImageCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) در دسترس هستند.

اگر فقط نیاز داشته باشید تمام منابع تصویری جاسازی‌شده در یک ارائه را صادر کنید، از `presentation.getImages()` مرور کنید. این مقاله بر یک کار متفاوت تمرکز دارد: پیمایش اشکال برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به طوری که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل، و نوع منبع (فریم تصویر، تصویر پرکردن، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="نکته" color="info" %}}
از [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) برای حفظ داده‌های تصویر کدگذاری‌شده اصلی و نوع فایل استفاده کنید. برای نرمال‌سازی خروجی به یک فرمت خاص مانند PNG، از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) همراه با [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `saveOriginalImage` بایت‌های جاسازی‌شده اصلی را می‌نویسد، پسوند ایمن را از نوع MIME انتخاب می‌کند، و باینری‌های تصویر تکراری را با هش SHA-256 نادیده می‌گیرد.

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

## **استخراج تصاویر از فریم‌های تصویری**

از این روش برای تصاویری که به‌صورت اشیای مستقل اضافه شده‌اند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ipictureframe/) تصویر خود را در `getPictureFormat().getPicture().getImage()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) برمی‌گرداند.

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

## **استخراج تصاویر از اشکال پر‑تصویر**

اشکال می‌توانند یک تصویر را به‌عنوان پرکردن خود استفاده کنند. ابتدا نوع پرکردن شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides.filltype/) نباشد، تصویری برای استخراج وجود ندارد. مثال زیر اشیای [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iautoshape/) را پردازش می‌کند و هر تصویر را با استفاده از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) به فرمت PNG ذخیره می‌نماید.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء روی اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat().getPicture().getImage()` در دسترس است. استخراج این تصویر پیش‌نمایش را می‌دهد، نه محتوای بسته OLE جاسازی‌شده.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های ویدئویی**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر پوستر یا تصویر کوچک نشان‌داده‌شده روی اسلاید است، نه فریمی که از جریان ویدئو استخراج شده است.

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

## **استخراج پیش‌نمایش تصاویر از فریم‌های صوتی**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iaudioframe/) می‌تواند تصویر کوچک را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر برای شیء صدا روی اسلاید نمایش داده می‌شود.

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

## **استخراج تصاویر از اشیای زوم**

اشکال [IZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. `getZoomImage()` را از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.isummaryzoomframe/) نیز یک شکل است. آیتم‌های بخش آن می‌توانند تصاویر سفارشی داشته باشند که از طریق متد `getZoomImage()` هر بخش زوم خلاصه در دسترس هستند.

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

## **استخراج تصاویر از اشکال جدول**

یک [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides.itable/) یک شکل است. تصاویر در جدول معمولاً به‌صورت پرکردن تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ichart/) یک شکل است. مثال زیر تصویری را از پرکردن تصویر ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ismartart/) یک شکل است. بسته به طرح‌بندی SmartArt، تصاویر ممکن است در پرکردن گلوله گره‌ها یا در قالب پرکردن اشکال گره ذخیره شوند.

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

## **گنجاندن تصاویر داخل اشکال گروهی**

اشکال گروهی مجموعه‌های شکل خود را دارند. کمکی `enumerateShapes` گزینه `includeGroupedShapes` دارد. هنگام نیاز به بررسی اشکال داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.igroupshape/) آن را به `true` تنظیم کنید. مثال زیر تصاویر را از فریم‌های تصویری، اشکال پر‑تصویر، پیش‌نمایش‌های شیء OLE، تصویرهای کوچک فریم‌های ویدئویی و صدا استخراج می‌کند. برای گنجاندن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز می‌توانید منطق استخراج ویژه در بخش‌های قبلی را بازاستفاده کنید در حالی که همان پیمایش بازگشتی شکل را حفظ می‌کنید.

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

## **موارد ویژه و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر یکسان ارجاع دهند یا تصاویری با بایت‌های یکسان داشته باشند. پیش از نوشتن فایل‌ها هش [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) را محاسبه کنید تا برای هر تصویر منحصر به فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره‌سازی [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره‌سازی [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) از طریق [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) برای خروجی به فرمت ثابت مفید است.
- **انواع پرکردن پشتیبانی‌نشده:** اشکال تک‌رنگ، گرادیان، الگو و بدون پرکردن تصویری ندارند. قبل از خواندن `getPictureFillFormat()` نوع پرکردن را با [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides.filltype/) بررسی کنید.
- **اشکال گروهی:** مجموعه شکل‌های اسلاید سطح بالا گروه‌ها را صاف (flatten) نمی‌کند. هنگام نیاز به محتوای گروهی، به صورت بازگشتی [IGroupShape.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides.igroupshape/#getShapes--) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `getSubstitutePictureFormat()` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و نه فایل جاسازی‌شده داخل شیء OLE.
- **تصاویر کوچک فریم‌های ویدئویی:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe/) ممکن است پیش‌نمایش را از طریق `getPictureFormat()` ارائه دهد؛ این تصویر فقط پوستر نمایش‑داده‌شده روی اسلاید است و از جریان ویدئو استخراج نمی‌شود.
- **تصاویر کوچک فریم‌های صوتی:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iaudioframe/) ممکن است آیکون یا تصویر کوچک را از طریق `getPictureFormat()` ارائه دهد؛ این تصویر داده‌های صوتی جاسازی‌شده را نشان نمی‌دهد.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه می‌توانند از اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های تو در توی شکل:** اشیای جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ishape/) را دارند، اما تصاویرشان اغلب در اشیای قالب‌بندی سلول جدول، عنصر نمودار یا گره SmartArt تو در تو ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) فقط منبع تصویری ذخیره‌شده را می‌دهد. این کار برش، شفافیت، تغییر رنگ، چرخش یا سایر جلوه‌های بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

### آیا می‌توانم تصویر اصلی را بدون برش، اثرات یا تبدیل‌های شکل استخراج کنم؟

بله. شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) را دریافت کنید و با استفاده از [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) آن را روی دیسک بنویسید. این کار تصویر کدگذاری‌شده اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوه نمایش آن روی اسلاید.

### آیا می‌توانم همه تصاویر استخراج‌شده را به PNG صادر کنم؟

بله. از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) برای دریافت شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/) استفاده کنید و سپس با [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) و [ImageFormat.Png](https://reference.aspose.com/slides/fa/java/com.aspose.slides.imageformat/) ذخیره کنید. این کار خروجی را به فرمت PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

### چگونه از ذخیره‌سازی مکرر یک تصویر جلوگیری کنم؟

هش [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) را محاسبه کرده و آن‌ها را در یک مجموعه نگهدارید. اگر تصویری جدید هش موجودی داشته باشد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود اضافه کنید.

### چرا برخی اشکال تصویر تولید نمی‌کنند؟

فریم‌های تصویری، اشکال پر‑تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل تصاویر را از طریق اشیای قالب‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی ساده `getPictureFormat()` یا `getFillFormat()` همیشه کافی نیست.

### آیا می‌توانم تصویر کوچک نمایش داده‌شده برای فریم ویدئویی را استخراج کنم؟

بله. از [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe/) استفاده کنید و `getPictureFormat().getPicture().getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده همراه فریم ویدئویی را استخراج می‌کند، نه فریمی که از فایل ویدئویی تولید شده باشد.

### چگونه می‌توانم تعیین کنم کدام اشکال از تصویر خاصی در مجموعه تصاویر ارائه استفاده می‌کنند؟

Aspose.Slides پیوندهای معکوس از [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) به اشکال را ذخیره نمی‌کند. در طول پیمایش یک نگاشت بسازید: هر زمانی که به یک ارجاع تصویر می‌رسید، شماره اسلاید، مسیر شکل و هش یا شناسهٔ آیتم مجموعه را ثبت کنید.

### آیا می‌توانم تصاویر جاسازی‌شده داخل اشیای OLE، مانند اسناد پیوست، را استخراج کنم؟

می‌توانید پیش‌نمایش اسلاید شیء OLE را از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) استخراج کنید. اما این پیش‌نمایش خود فایل سند جاسازی‌شده را نشان نمی‌دهد. برای استخراج تصاویر داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کرده و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.