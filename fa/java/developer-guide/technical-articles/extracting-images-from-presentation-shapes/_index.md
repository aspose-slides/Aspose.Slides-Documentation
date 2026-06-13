---
title: استخراج تصاویر از اشکال ارائه در جاوا
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/java/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "تصویرها را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java استخراج کنید - راه‌حل سریع و مبتنی بر کد."
---
## **نمای کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به عنوان قاب‌های تصویر معمولی، به عنوان پر کردن تصویر اعمال‌شده بر شکل‌ها، به عنوان تصاویر پیش‌نمایش شیء OLE، به عنوان تصویرهای بندانگشتی فریم ویدئو یا صدا، به عنوان تصاویر زوم، یا به عنوان تصاویر تو در تو در داخل جدول، نمودار و اشکال SmartArt. Aspose.Slides این تصاویر را در مجموعه تصویر ارائه ذخیره می‌کند که از طریق اشیای [IImageCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) در دسترس هستند.

اگر فقط نیاز دارید تمام منابع تصویر جاسازی‌شده در یک ارائه را استخراج کنید، از `presentation.getImages()` مرور کنید. این مقاله بر یک کار متفاوت تمرکز دارد: جستجوی شکل‌ها برای یافتن مکان استفاده از تصاویر در اسلایدها، به‌طوری‌که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پرکننده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را نگه دارند.

{{% alert title="Tip" color="primary" %}}
از [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) برای حفظ داده‌های تصویر کدگذاری‌شده اصلی و نوع فایل استفاده کنید. هنگامی که می‌خواهید خروجی را به فرمتی خاص مانند PNG نرمال‌سازی کنید، از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) همراه با [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر نمونه‌ها را کوتاه نگه می‌دارند. `saveOriginalImage` بایت‌های جاسازی‌شده اصلی را می‌نویسد، پسوند ایمن را بر اساس نوع MIME انتخاب می‌کند و باینری‌های تصویر تکراری را بر اساس هش SHA-256 نادیده می‌گیرد.

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

## **استخراج تصاویر از قاب‌های تصویر**

از این روش برای تصاویری که به‌عنوان شیء مستقل وارد می‌شوند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ipictureframe/) تصویر خود را در `getPictureFormat().getPicture().getImage()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/) را برمی‌گرداند.

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

## **استخراج تصاویر از اشکال پر شده با تصویر**

شکل‌ها می‌توانند یک تصویر را به‌عنوان پرکننده خود استفاده کنند. ابتدا نوع پرکننده شکل را بررسی کنید: اگر نوع آن [FillType.Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides.filltype/) نباشد، تصویری برای استخراج از این پرکننده وجود ندارد. مثال زیر اشیای [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iautoshape/) را پردازش می‌کند و هر تصویر را با استفاده از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) به‌صورت PNG ذخیره می‌کند.

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

## **استخراج تصاویر پیش‌نمایش از قاب‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe/) می‌تواند تصویری جایگزین داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء روی اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat().getPicture().getImage()` در دسترس است. استخراج این تصویر به شما تصویر پیش‌نمایش را می‌دهد، نه محتوای بسته OLE جاسازی‌شده.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدئو**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe/) همچنین می‌تواند تصویر پیش‌نمایشی را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر پوستر یا بندانگشتی است که روی اسلاید نشان داده می‌شود، نه یک فریم استخراج‌شده از جریان ویدئو.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های صدا**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iaudioframe/) می‌تواند یک بندانگشتی را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر نشان داده‌شده برای شیء صدا در اسلاید است.

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

## **استخراج تصاویر از اشیای زوم**

[IZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.izoomframe) و اشکال [ISectionZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. تصویر زوم را با فراخوانی `getZoomImage()` از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

[ISummaryZoomFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.isummaryzoomframe) نیز یک شکل است. آیتم‌های بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `getZoomImage()` هر بخش زوم خلاصه قابل دسترسی است.

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

## **استخراج تصاویر از اشکال جدول**

[ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides.itable) یک شکل است. تصاویر در جدول معمولاً به‌صورت پرکننده‌های تصویری در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

[IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ichart) یک شکل است. مثال زیر تصویری را از پرکننده تصویری ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

[ISmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ismartart) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکننده‌های گلوله‌دار گره یا در قالب‌های پرکننده‌ی اشکال گره ذخیره شوند.

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

## **شامل تصاویر درون اشکال گروهی**

اشکال گروهی مجموعه‌های شکل خود را دارند. متد کمکی مشترک `enumerateShapes` گزینه‌ای به نام `includeGroupedShapes` دارد. هنگامی که می‌خواهید شکل‌های داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.igroupshape) را بررسی کنید، این گزینه را به `true` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، اشکال پر شده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی‌های فریم ویدئو و بندانگشتی‌های فریم صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز، منطق استخراج اختصاصی بخش‌های قبلی را باز استفاده کنید در حالی که همان پیمایش بازگشتی شکل‌ها را حفظ می‌کنید.

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

## **موارد لبه و نکات عملی**

- **تصاویر تکراری:** ممکن است چندین شکل به همان تصویر یا به تصاویر جداگانه با بایت‌های یکسان ارجاع دهند. قبل از نوشتن فایل‌ها، [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) را هش کنید اگر می‌خواهید برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره‌سازی [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره‌سازی [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) از طریق [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) وقتی که می‌خواهید فرمت خروجی یکسانی داشته باشید مفید است.
- **انواع پرکننده پشتیبانی‌نشده:** شکل‌های ثابت، گرادیان، الگو و بدون پرکننده حاوی تصویر پرکننده نیستند. قبل از خواندن `getPictureFillFormat()`، [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides.filltype/) را بررسی کنید.
- **اشکال گروهی:** مجموعه شکل‌های اسلاید در سطح بالا گروه‌ها را صاف نمی‌کند. هنگامی که محتوای گروهی مهم است، به‌صورت بازگشتی [IGroupShape.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides.igroupshape/#getShapes--) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe) ممکن است تصویر پیش‌نمایشی را از طریق `getSubstitutePictureFormat()` نشان دهد، اما این تصویر فقط پیش‌نمایش اسلاید است. این نه فایل جاسازی‌شده داخل شیء OLE است.
- **بندانگشتی‌های فریم ویدئو:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe) ممکن است تصویر پیش‌نمایشی را از طریق `getPictureFormat()` نشان دهد، اما این تصویر فقط پوستر نمایش داده‌شده روی اسلاید است. این تصویر از جریان ویدئو استخراج نمی‌شود.
- **بندانگشتی‌های فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iaudioframe) ممکن است یک آیکون یا بندانگشتی را از طریق `getPictureFormat()` نشان دهد؛ این داده‌های صوتی جاسازی‌شده نیستند.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage) از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های شکل‌ تو در تو:** اشیای جدول، نمودار و SmartArt از [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ishape) پیروی می‌کنند، اما تصاویر آن‌ها اغلب در سلول‌های جدول تو در تو، عنصر نمودار یا اشیای قالب‌بندی گره SmartArt ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تغییر شکل‌ یافته:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage) منبع تصویر ذخیره‌شده را می‌دهد. این برش، شفافیت، بازنگرانی رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، افکت یا تبدیل شکل استخراج کنم؟**

بله. به شیء [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage) دسترسی پیدا کنید و [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) را روی دیسک بنویسید. این کار تصویر کدگذاری‌شده اصلی که در ارائه ذخیره شده است را حفظ می‌کند، نه نحوه رندر شدن تصویر در اسلاید.

**آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG صادر کنم؟**

بله. از [IPPImage.getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getImage--) برای دریافت یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage) استفاده کنید و سپس با [ImageFormat.Png](https://reference.aspose.com/slides/fa/java/com.aspose.slides.imageformat/) به‌صورت [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.iimage/#save-java.lang.String-int-) فراخوانی کنید. این کار خروجی را تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه از ذخیره‌سازی چندباره یک تصویر جلوگیری کنم؟**

از یک هش برای [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage/#getBinaryData--) استفاده کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویری جدید هش موجودی داشته باشد، آن را نادیده بگیرید یا یک ارجاع دیگر به فایل خروجی موجود ثبت کنید.

**چرا برخی از شکل‌ها تصویری تولید نمی‌کنند؟**

قاب‌های تصویر، اشکال پر شده با تصویر، قاب‌های شیء OLE، قاب‌های رسانه‌ای، قاب‌های زوم، جدول‌ها، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصاویر را از طریق اشیای قالب‌بندی تو در تو نشان می‌دهند، بنابراین یک بررسی ساده `getPictureFormat()` یا `getFillFormat()` شکل همیشه کافی نیست.

**آیا می‌توانم تصویر بندانگشتی نمایش داده‌شده برای فریم ویدئو را استخراج کنم؟**

بله. از [IVideoFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ivideoframe) استفاده کنید و `getPictureFormat().getPicture().getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدئو را استخراج می‌کند، نه فریمی تولید‌شده از فایل ویدئو.

**چگونه می‌توانم تعیین کنم کدام شکل‌ها از یک تصویر خاص از مجموعه تصاویر ارائه استفاده می‌کنند؟**

Aspose.Slides پیوندهای معکوس از [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ippimage) به شکل‌ها را ذخیره نمی‌کند. در حین پیمایش یک نگاشت بسازید: هر زمان که یک ارجاع تصویر پیدا کردید، شماره اسلاید، مسیر شکل و هش تصویر یا آیتم مجموعه را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده درون اشیای OLE، مانند اسناد پیوست‌شده، استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از طریق [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) استخراج کنید. با این حال، این پیش‌نمایش خود فایل سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، داده‌های OLE را استخراج کنید و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.