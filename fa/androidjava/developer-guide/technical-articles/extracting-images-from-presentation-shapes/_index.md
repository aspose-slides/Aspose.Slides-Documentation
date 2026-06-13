---
title: استخراج تصاویر از شکل‌های ارائه در اندروید با استفاده از جاوا
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/androidjava/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- پاورپوینت
- اسناد باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تصاویر را از شکل‌ها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای اندروید via Java استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **بررسی کلی**

تصاویر در یک ارائه می‌توانند در انواع شکل‌های مختلف ظاهر شوند: به عنوان قاب تصویر عادی، به عنوان پرکننده تصویر در شکل‌ها، به عنوان پیش‌نمایش شیء OLE، به عنوان تصویر بندانگشتی فریم ویدئو یا صدا، به عنوان تصویر زوم، یا به عنوان تصاویری که در داخل جدول، نمودار و شکل‌های SmartArt توکار هستند. Aspose.Slides این تصاویر را در مجموعه تصاویر ارائه ذخیره می‌کند که از طریق اشیای [IImageCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) قابل دسترسی است.

اگر فقط نیاز به استخراج تمام منابع تصویری تعبیه‌شده در یک ارائه دارید، می‌توانید از `presentation.getImages()` استفاده کنید. این مقاله بر کاری متفاوت تمرکز دارد: پیمایش شکل‌ها برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به‌طوری‌که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پرکننده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="نکته" color="primary" %}}
از [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) برای حفظ داده‌های تصویر رمزگذاری‌شده اصلی و نوع فایل استفاده کنید. زمانی که می‌خواهید خروجی را به فرمت خاصی مانند PNG نرمال‌سازی کنید، از [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) همراه با [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) استفاده کنید.
{{% /alert %}}

## **روش‌های کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه می‌کنند. `saveOriginalImage` بایت‌های تعبیه‌شده اصلی را می‌نویسد، پسوند‌ایمن را از نوع MIME انتخاب می‌کند و باینری‌های تصویری تکراری را بر اساس هش SHA‑256 نادیده می‌گیرد.

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

از این روش برای تصاویری که به‌عنوان اشیای مستقل وارد شده‌اند استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) تصویر خود را در `getPictureFormat().getPicture().getImage()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) برمی‌گرداند.

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

## **استخراج تصاویر از شکل‌های پر شده با تصویر**

شکل‌ها می‌توانند تصویر را به‌عنوان پرکننده استفاده کنند. ابتدا نوع پرکننده شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) نباشد، تصویری برای استخراج وجود ندارد. مثال زیر اشیای [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را مدیریت کرده و هر تصویر را از طریق [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) به‌صورت PNG ذخیره می‌کند.

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

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء روی اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat().getPicture().getImage()` در دسترس است. استخراج این تصویر، پیش‌نمایش را می‌دهد نه محتوای بسته OLE تعبیه‌شده.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدئویی**

یک [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر پوستر یا بندانگشتی نمایش‌داده‌شده روی اسلاید است، نه فریمی که از جریان ویدئو استخراج شده باشد.

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

یک [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/) می‌تواند یک بندانگشتی را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر برای شیء صدا روی اسلاید نشان داده می‌شود.

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

شکل‌های [IZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. از `getZoomImage()` در فریم زوم خوانده شود.

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

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isummaryzoomframe/) نیز یک شکل است. اقلام بخش خلاصه آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `getZoomImage()` هر بخش خلاصه در دسترس است.

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

## **استخراج تصاویر از شکل‌های جدول**

یک [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) یک شکل است. تصاویر در جدول معمولاً به‌عنوان پرکننده‌های تصویری در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از شکل‌های نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/) یک شکل است. مثال زیر تصویری را از پرکننده تصویر ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از شکل‌های SmartArt**

یک [ISmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartart/) یک شیء شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکننده‌های گلوله گره یا در فرمت‌های پرکننده شکل گره ذخیره شوند.

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

## **شامل تصاویر داخل شکل‌های گروهی**

شکل‌های گروهی دارای مجموعه شکل‌های خود هستند. متد کمکی مشترک `enumerateShapes` گزینه `includeGroupedShapes` دارد. وقتی می‌خواهید شکل‌های داخل اشیای [IGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igroupshape/) را بررسی کنید، این گزینه را روی `true` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، شکل‌های پر شده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی فریم‌های ویدئویی و بندانگشتی فریم‌های صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را بازاستفاده کنید در حالی که همان پیمایش بازگشتی شکل‌ها حفظ می‌شود.

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

## **موارد ویژه و نکات عملی**

- **تصاویر تکراری:** اشکال متعدد ممکن است به همان تصویر ارجاع دهند یا تصاویری با بایت‌های یکسان داشته باشند. قبل از نوشتن فایل‌ها، [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) را هش کنید تا برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF تعبیه‌شده را حفظ می‌کند. ذخیره [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) از طریق [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) زمانی مفید است که بخواهید فرمت خروجی یکنواختی داشته باشید.
- **انواع پرکننده پشتیبانی‌نشده:** پرکننده‌های ثابت، گرادیان، الگو و بدون پرکننده شامل تصویر نمی‌شوند. قبل از خواندن `getPictureFillFormat()`، [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) را بررسی کنید.
- **شکل‌های گروهی:** مجموعه شکل‌های سطح بالای اسلاید گروه‌ها را مسطح نمی‌کند. هنگام نیاز به محتویات گروهی، بازگشتاً [IGroupShape.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igroupshape/#getShapes--) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `getSubstitutePictureFormat()` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و فایل تعبیه‌شده داخل شیء OLE نیست.
- **بندانگشتی فریم ویدئویی:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایش را از طریق `getPictureFormat()` ارائه دهد، اما این تصویر فقط پوستر نمایش‌داده‌شده روی اسلاید است و از جریان ویدئو استخراج نمی‌شود.
- **بندانگشتی فریم صدا:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/) ممکن است آیکون یا بندانگشتی را از طریق `getPictureFormat()` ارائه دهد؛ این تصویر داده‌های صوتی تعبیه‌شده را نشان نمی‌دهد.
- **تصاویر زوم:** شکل‌های زوم اسلاید، زوم بخش و زوم خلاصه می‌توانند از اشیای سفارشی [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های توکار شکل:** اشیای جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را دارند، اما تصاویر غالباً در قالب‌های توکار سلول جدول، عنصر نمودار یا گره SmartArt ذخیره می‌شوند.
- **تصاویر برش‌دار یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) منبع تصویر ذخیره‌شده را می‌دهد. این عمل برش، شفافیت، تغییر رنگ، چرخش یا سایر افکت‌های بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، افکت یا تبدیل شکل استخراج کنم؟**

بله. شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) را دسترسی پیدا کنید و [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) را روی دیسک بنویسید. این کار دادهٔ تصویر کدگذاری‌شدهٔ اصلی را که در ارائه ذخیره شده حفظ می‌کند، نه نحوهٔ رندر تصویر روی اسلاید.

**آیا می‌توانم تمام تصاویر استخراج‌شده را به PNG صادر کنم؟**

بله. از [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) برای دریافت شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) استفاده کنید و سپس با [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) و [ImageFormat.Png](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) ذخیره نمایید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه می‌توانم از ذخیرهٔ چندبارهٔ یک تصویر جلوگیری کنم؟**

از هش [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) استفاده کنید و هش‌ها را در یک مجموعه نگهداری کنید. اگر تصویری جدید دارای هش موجود باشد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

**چرا برخی شکل‌ها تصویری تولید نمی‌کنند؟**

قاب‌های تصویر، شکل‌های پر شده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جداول، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویر را از طریق اشیای قالب‌بندی توکار افشا می‌کنند، بنابراین بررسی سادهٔ `getPictureFormat()` یا `getFillFormat()` همیشه کافی نیست.

**آیا می‌توانم بندانگشتی نشان داده‌شده برای فریم ویدئویی را استخراج کنم؟**

بله. از [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) استفاده کنید و `getPictureFormat().getPicture().getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدئویی را استخراج می‌کند، نه فریمی که از فایل ویدئویی تولید شده باشد.

**چگونه می‌توانم تعیین کنم کدام شکل‌ها از یک تصویر مشخص در مجموعه تصاویر ارائه استفاده می‌کنند؟**

Aspose.Slides لینک معکوسی از [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) به شکل‌ها ذخیره نمی‌کند. هنگام پیمایش، هر زمان که یک مرجع تصویر یافت شد، شماره اسلاید، مسیر شکل و هش یا آیتم مجموعه تصویر را ثبت کنید.

**آیا می‌توانم تصاویر تعبیه‌شده داخل اشیای OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) استخراج کنید. اما این پیش‌نمایش همان سند تعبیه‌شده نیست. برای استخراج تصاویر از داخل فایل تعبیه‌شده، دادهٔ OLE را استخراج کرده و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.