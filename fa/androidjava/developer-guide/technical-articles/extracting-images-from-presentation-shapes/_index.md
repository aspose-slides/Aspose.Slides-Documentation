---
title: استخراج تصاویر از اشکال ارائه در اندروید با جاوا
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/androidjava/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- پاورپوینت
- سند باز
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های پاورپوینت و سند باز با Aspose.Slides برای اندروید از طریق جاوا استخراج کنید - راه‌حل سریع و سازگار با کد."
---
## **نمای کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به‌عنوان چارچوب‌های تصویر عادی، به‌عنوان پرکردن‌های تصویری که بر روی اشکال اعمال می‌شوند، به‌عنوان تصاویر پیش‌نمایش شیء OLE، به‌عنوان بندانگشتی‌های فریم ویدئو یا صدا، به‌عنوان تصاویر زوم، یا به‌عنوان تصاویر تو در تو در داخل اشکال جدول، نمودار و SmartArt. Aspose.Slides این تصاویر را در مجموعه تصویر ارائه ذخیره می‌کند که از طریق اشیاء [IImageCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagecollection/) و [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) در دسترس است.

اگر فقط نیاز دارید تمام منابع تصویری‌ِ جاسازی‌شده در یک ارائه را استخراج کنید، از `presentation.getImages()` مرور کنید. این مقاله بر یک کار متفاوت تمرکز دارد: پیمایش اشکال برای یافتن محلی که تصاویر در اسلایدها استفاده می‌شوند، به‌طوری‌که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (چارچوب تصویر، تصویر پرکرده، پیش‌نمایش رسانه‌ای، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="Tip" color="info" %}}
از [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) برای حفظ داده‌های تصویر رمزگذاری‌شدهٔ اصلی و نوع فایل استفاده کنید. از [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) همراه با [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) زمانی که می‌خواهید خروجی را به فرمت خاصی مانند PNG نرمال کنید، استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `saveOriginalImage` بایت‌های اصلی جاسازی‌شده را می‌نویسد، پسوندی ایمن از نوع MIME انتخاب می‌کند و باینری‌های تصویر تکراری را بر اساس هش SHA-256 نادیده می‌گیرد.

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

## **استخراج تصاویر از چارچوب‌های تصویر**

از این روش برای تصاویر وارد شده به‌عنوان اشیاء مستقل استفاده کنید. یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) تصویر خود را در `getPictureFormat().getPicture().getImage()` ذخیره می‌کند که یک شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) برمی‌گرداند. توجه داشته باشید که [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) و [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/) از [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) ارث می‌برند، بنابراین این بررسی `instanceof` همچنین فریم‌های رسانه‌ای را مطابقت می‌دهد و تصاویر پیش‌نمایش آنها را استخراج می‌کند؛ در صورتی که می‌خواهید آنها را به‌صورت جداگانه پردازش کنید، ابتدا برای این نوع‌ها تست کنید، همان‌طور که مثال آخر این صفحه انجام می‌دهد.

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

## **استخراج تصاویر از اشکال پرشده با تصویر**

اشکال می‌توانند از یک تصویر به‌عنوان پرکننده استفاده کنند. ابتدا نوع پرکنندهٔ شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) نباشد، تصویری برای استخراج از آن پرکننده وجود ندارد. مثال زیر اشیاء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را مدیریت می‌کند و هر تصویر را به‌صورت PNG از طریق [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) ذخیره می‌نماید.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های شیء OLE**

یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat().getPicture().getImage()` در دسترس است. استخراج این تصویر، پیش‌نمایش را به شما می‌دهد، نه محتوای بستهٔ OLE جاسازی‌شده.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

یک [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) همچنین می‌تواند تصویر پیش‌نمایش را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر پوستر یا بندانگشتی‌ای است که در اسلاید نمایش داده می‌شود، نه فریمی که از جریان ویدئو استخراج شده باشد.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **استخراج تصاویر پیش‌نمایش از فریم‌های صوتی**

یک [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/) می‌تواند یک بندانگشتی را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر برای شیء صوتی در اسلاید نمایش داده می‌شود.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **استخراج تصاویر از اشیاء زوم**

اشکال [IZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/izoomframe/) و [ISectionZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. از `getZoomImage()` در فریم زوم خوانده شود.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [ISummaryZoomFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isummaryzoomframe/) نیز یک شکل است. آیتم‌های بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق متد `getZoomImage()` هر بخش زوم خلاصه قابل دسترسی است.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **استخراج تصاویر از اشکال جدول**

یک [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) یک شکل است. تصاویر در جدول معمولاً به‌عنوان پرکننده‌های تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/) یک شکل است. مثال زیر تصویری را از پرکنندهٔ تصویری ناحیهٔ نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [ISmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartart/) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکننده‌های گلوله‌دار گره یا در فرمت‌های پرکنندهٔ شکل‌های گره ذخیره شوند.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **شامل کردن تصاویر داخل اشکال گروهی**

اشکال گروهی شامل مجموعهٔ اشکال خود هستند. متد کمکی مشترک `enumerateShapes` یک گزینهٔ `includeGroupedShapes` دارد. هنگامیکه می‌خواهید اشکال داخل اشیاء [IGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igroupshape/) را بررسی کنید، این گزینه را به `true` تنظیم کنید. مثال زیر تصاویر را از چارچوب‌های تصویر، اشکال پرشده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشتی‌های فریم ویدئو و بندانگشتی‌های فریم صوتی استخراج می‌کند. برای شامل شدن جدول، نمودار، SmartArt و تصاویر زوم خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را مجدداً استفاده کنید در حالی که همان پیمایش بازگشتی اشکال حفظ می‌شود.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util List;
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

## **موارد لبه‌ای و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر ارجاع دهند یا تصاویر جداگانه‌ای با بایت‌های یکسان داشته باشند. قبل از نوشتن فایل‌ها، هش [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) را بگیرید اگر می‌خواهید برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیرهٔ [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) دادهٔ JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیرهٔ [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) از طریق [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) وقتی می‌خواهید فرمت خروجی ثابت باشد، مفید است.
- **نوع‌های پرکننده پشتیبانی‌نشده:** اشکال با پرکنندهٔ یکدست، گرادیان، الگو یا بدون پرکننده تصویر ندارند. قبل از خواندن `getPictureFillFormat()`، [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) را بررسی کنید.
- **اشکال گروهی:** مجموعهٔ اشکال سطح‑بالای اسلاید گروه‌ها را مسطح نمی‌کند. هنگامیکه محتوای گروه مهم است، به‌صورت بازگشتی [IGroupShape.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igroupshape/#getShapes--) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [IOleObjectFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/) ممکن است تصویر پیش‌نمایش را از طریق `getSubstitutePictureFormat()` ارائه دهد، اما این تصویر تنها پیش‌نمایش اسلاید است. این تصویر فایل جاسازی‌شده داخل شیء OLE نیست.
- **بندانگشتی‌های فریم ویدئویی:** یک [IVideoFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/) ممکن است تصویر پیش‌نمایش را از طریق `getPictureFormat()` ارائه دهد، اما این تصویر تنها پوستر نمایش داده‌شده در اسلاید است. این تصویر از جریان ویدئو استخراج نمی‌شود.
- **بندانگشتی‌های فریم صوتی:** یک [IAudioFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudioframe/) ممکن است یک نماد یا بندانگشتی را از طریق `getPictureFormat()` ارائه دهد؛ این تصویر دادهٔ صوتی جاسازی‌شده نیست.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیاء سفارشی [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های اشکال تو در تو:** اشیاء جدول، نمودار و SmartArt پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) را دارند، اما تصاویر آنها اغلب در اشیاء فرمت سلول جدول، عنصر نمودار یا فرمت گره SmartArt تو در تو ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) منبع تصویر ذخیره‌شده را می‌دهد. این کار برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سؤالات متداول**

### آیا می‌توانم تصویر اصلی را بدون برش، افکت‌ها یا تبدیل‌های شکل استخراج کنم؟

بله. به شیء [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) دسترسی پیدا کنید و [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) را روی دیسک بنویسید. این کار تصویر رمزگذاری‌شدهٔ اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوهٔ رندر تصویر در اسلاید.

### آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG صادر کنم؟

بله. از [IPPImage.getImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getImage--) برای دریافت یک شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) استفاده کنید و سپس با [IImage.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) همراه با [ImageFormat.Png](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) فراخوانی کنید. این کار خروجی را به‌صورت PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

### چگونه از ذخیرهٔ چندبارهٔ یک تصویر جلوگیری کنم؟

از هش [IPPImage.getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/#getBinaryData--) استفاده کنید و هش‌ها را در یک مجموعه نگه دارید. اگر تصویری جدید دارای هشی باشد که قبلاً وجود دارد، آن را نادیده بگیرید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

### چرا برخی اشکال تصویر تولید نمی‌کنند؟

چارچوب‌های تصویر، اشکال پرشده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیاء SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصاویر را از طریق اشیاء قالب‌بندی تو در تو نشان می‌دهند، بنابراین بررسی سادهٔ `getPictureFormat()` یا `getFillFormat()` شکل همیشه کافی نیست.

### آیا می‌توانم بندانگشتی نشان داده‌شده برای فریم ویدئویی را استخراج کنم؟

بله. از [IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) استفاده کنید و `getPictureFormat().getPicture().getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدئویی را استخراج می‌کند، نه فریمی که از فایل ویدئو تولید شده باشد.

### چگونه می‌توانم تعیین کنم کدام شکل‌ها از تصویر خاصی در مجموعهٔ تصاویر ارائه استفاده می‌کنند؟

Aspose.Slides پیوندهای معکوس از [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) به شکل‌ها را ذخیره نمی‌کند. در طول پیمایش یک نگاشت بسازید: هر زمان که به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش تصویر یا مورد مجموعه را ثبت کنید.

### آیا می‌توانم تصاویر جاسازی‌شده داخل اشیاء OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) استخراج کنید. اما این پیش‌نمایش خود سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، دادهٔ OLE را استخراج کنید و با ابزارهای مربوط به آن نوع فایل بررسی کنید.