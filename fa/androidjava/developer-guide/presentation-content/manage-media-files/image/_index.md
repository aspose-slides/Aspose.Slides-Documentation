---
title: بهینه‌سازی مدیریت تصویر در ارائه‌ها بر روی Android
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/androidjava/image/
keywords:
- اضافه کردن تصویر
- اضافه کردن عکس
- اضافه کردن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- اضافه کردن PNG
- اضافه کردن JPG
- اضافه کردن SVG
- منابع خارجی SVG
- حل‌کننده SVG
- تصاویر SVG پیوندشده
- فونت‌های SVG
- اضافه کردن EMF
- اضافه کردن WMF
- اضافه کردن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت تصویر در PowerPoint و OpenDocument را با Aspose.Slides برای Android از طریق Java بهبود دهید، عملکرد را بهینه کرده و جریان کاری خود را خودکار کنید."
---
## **معرفی**

تصاویر ارائه‌ها را جذاب‌تر و از نظر بصری دلنشین‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از فایل‌ها، اینترنت یا سایر منابع به اسلایدها اضافه کنید. به‌ همین ترتیب، Aspose.Slides امکان افزودن تصاویر به اسلایدهای ارائه را به چندین روش فراهم می‌کند.

{{% alert  title="Tip" color="primary" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به شما امکان می‌دهند به‌سرعت از تصاویر ارائه‌ها ایجاد کنید. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به‌عنوان فریم تصویر اضافه کنید—به‌ویژه اگر قصد دارید آن را تغییر اندازه دهید، افکت اعمال کنید یا از سایر گزینه‌های قالب‌بندی استاندارد استفاده کنید—به [فریم تصویر](/slides/fa/androidjava/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/androidjava/conversion/image-to-jpg/), [JPG به image](https://products.aspose.com/slides/fa/androidjava/conversion/jpg-to-image/), [JPG به PNG](https://products.aspose.com/slides/fa/androidjava/conversion/jpg-to-png/), [PNG به JPG](https://products.aspose.com/slides/fa/androidjava/conversion/png-to-jpg/), [PNG به SVG](https://products.aspose.com/slides/fa/androidjava/conversion/png-to-svg/), و [SVG به PNG](https://products.aspose.com/slides/fa/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایر فرمت‌ها پشتیبانی می‌کند.

## **اضافه کردن تصاویر ذخیره‌شده به صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه Java زیر نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید بر روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید.  
کد نمونه Java زیر نشان می‌دهد چگونه یک تصویر از وب به اسلاید اضافه شود:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر به اسلاید مسترها**

یک اسلاید مستر اطلاعاتی مانند تم و طرح‌بندی اسلایدهایی که از آن استفاده می‌کنند را ذخیره و کنترل می‌کند. وقتی یک تصویر را به اسلاید مستر اضافه کنید، تصویر در هر اسلاید مبتنی بر آن مستر ظاهر می‌شود.  
کد نمونه Java زیر نشان می‌دهد چگونه یک تصویر به اسلاید مستر اضافه شود:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر به عنوان پس‌زمینه اسلایدها**

می‌توانید یک تصویر را به‌عنوان پس‌زمینه یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به عنوان پس‌زمینه برای اسلایدها](/slides/fa/androidjava/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتویات SVG را می‌توان با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) به یک ارائه اضافه کرد. شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) حاصل سپس می‌تواند به مجموعه تصویر ارائه افزوده شده و برای ایجاد یک فریم تصویر استفاده شود.  
مثال Java زیر یک رشته SVG مستقل را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع مورد استفاده در این SVG مستقیماً در محتوای SVG جاسازی شده‌اند.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **وارد کردن محتوای SVG با منابع خارجی**

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون و خطوط لوله وب صادر می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. به‌عنوان مثال، یک SVG می‌تواند شامل لینک تصویر مانند `images/photo.png`، مقدار CSS `url(...)` یا URL فونت باشد.  
برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iexternalresourceresolver/) ایجاد کنید و آن را همراه با یک URI پایه به سازنده مناسب [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) پاس دهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود.  
رابط [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG وارد شده را فراهم می‌کند:

- `getSvgContent()` مقدار مارک‌آپ SVG را به‌صورت رشته برمی‌گرداند.  
- `getSvgData()` محتویات SVG را به‌صورت آرایه بایت برمی‌گرداند.  
- `getBaseUri()` URI پایه استفاده‌شده برای لینک‌های نسبی را برمی‌گرداند.  
- `getExternalResourceResolver()` حل‌کننده‌ای که به تصویر SVG اختصاص یافته است را برمی‌گرداند.

### **پیاده‌سازی یک حل‌کننده منابع خارجی**

حل‌کننده دو روش دارد:

- `resolveUri` URI پایه و یک لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. زمانی که لینک قابل حل نیست یا مجاز نیست `null` برگردانده شود.  
- `getEntity` یک جریان قابل خواندن برای یک URI منبع مطلق برمی‌گرداند. زمانی که منبع مفقود، مسدود یا در دسترس نیست `null` برگردانده شود. در صورت نیاز می‌توان یک جریان جایگزین نیز برگرداند.

حل‌کننده زیر فقط منابع پیوند‌شده را از یک پوشه محلی مجاز بارگذاری می‌کند. منابع شبکه و مسیرهای خارج از پوشه مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویر حل نشدنی برگردانده می‌شود.

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // این حل‌کننده به‌صورت عمدی فقط فایل‌های محلی را مجاز می‌کند.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // فقط برای منابع تصویر از یک جایگزین استفاده کنید. بازگرداندن یک جریان تصویر
            // برای قلم یا stylesheet از دست رفته معتبر نخواهد بود.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **حل لینک‌های مرتبط هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` حاوی یک ارجاع نسبی به‌صورت زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

مثال Java زیر URI فایل SVG را به‌عنوان URI پایه می‌گذارد و یک حل‌کننده سفارشی ارائه می‌دهد. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل کرده و یک جریان حاوی منبع پیوندشده را برمی‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI پایه مکان سند SVG را نمایش می‌دهد.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage محتوای منبع، داده‌های باینری، URI پایه و حل‌کننده را نمایان می‌کند.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلاس `SvgImage` همچنین overloadهایی را فراهم می‌کند که داده‌های SVG را به‌صورت آرایه بایت یا جریان ورودی می‌پذیرند، همراه با یک حل‌کننده منابع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}
حل‌کننده منابع، منابع خارجی را در حین پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این حل‌کننده مارک‌آپ اصلی SVG را تغییر نمی‌دهد یا به‌طور خودکار منابع حل شده را در آن جاسازی نمی‌کند.  
وقتی یک `ISvgImage` به مجموعه تصویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایندگی اصلی SVG و هم یک تصویر رستر جایگزین را شامل شود. یک منبع پیوندشده می‌تواند در تصویر جایگزین تولید شده ظاهر شود در حالی که یک لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر باقی می‌ماند. بنابراین، برنامه‌ای که نمایندگی بومی SVG را رندر می‌کند ممکن است محتویات پیوندشده را زمانی که منبع خارجی اصلی در دسترس نیست، نادیده بگیرد.
{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ایجاد `SvgImage`، SVG را خودمختار کنید. به‌عنوان مثال، URLهای تصویر پیوندشده را با URIهای `data:` که شامل داده تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از آنکه تمام منابع مورد نیاز در محتوای SVG جاسازی شدند، `SvgImage` را ایجاد کنید، آن را به مجموعه تصویر ارائه اضافه کنید و همان‌گونه که در مثال قبلی نشان داده شد، در یک فریم تصویر وارد کنید.

### **مدیریت منابع گمشده یا مسدود شده**

`null` را از `resolveUri` برگردانید وقتی URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد. `null` را از `getEntity` برگردانید وقتی منبع قابل خواندن نیست. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.  
یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتویات آن باید با نوع منبع درخواست‌شده سازگار باشد. به‌عنوان مثال، فقط یک جریان تصویر را برای تصویر گمشده برگردانید، نه برای یک فونت یا استایل‌شیت.

{{% alert title="Security" color="warning" %}}
از حل مسیرهای فایل دلخواه یا URLهای شبکه بدون محدودیت از فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌ها، پوشه‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه، همچنین زمان‌سنجی اتصال، محدودیت‌ اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنید.
{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این عملکرد توسط یک overload از متد [addGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) رابط [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISvgImage) را به‌عنوان اولین آرگومان می‌پذیرد، ارائه می‌شود.  
کد نمونه Java زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده شود:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// نام فایل SVG منبع.
String svgFileName = "sample.svg";

// نام فایل خروجی ارائه.
String outPptxPath = "presentation.pptx";

// یک ارائه جدید ایجاد کنید.
IPresentation presentation = new Presentation();
try {
    // مطالب فایل SVG را بخوانید.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // یک شیء SvgImage ایجاد کنید.
    ISvgImage svgImage = new SvgImage(svgContent);

    // اندازه اسلاید را دریافت کنید.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تصویر SVG را به یک گروه از اشکال تبدیل کنید و به اندازه اسلاید مقیاس‌بندی کنید.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // ارائه را در قالب PPTX ذخیره کنید.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **اضافه کردن تصاویر به‌عنوان EMF به اسلایدها**

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تصاویر EMF را از ورک‌شیت‌های Excel با استفاده از Aspose.Cells تولید کرده و آنها را به اسلایدهای ارائه اضافه کنید.  
کد نمونه Java زیر نشان می‌دهد چگونه این کار انجام شود:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// دفتر کاری را در یک جریان ذخیره می‌کند.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // فایل را به همان شکل اضافه کنید تا تصویر به‌صورت برداری EMF باقی بماند و رستر نشود.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه، از جمله تصاویری که توسط شکل‌های اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با استفاده از داده‌های بایت خام، یک نمونه‌ی [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) یا تصویر دیگری که از پیش در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:
1. فایل ارائه حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید.
1. یک تصویر جدید را از یک فایل به‌صورت آرایه بایت بارگذاری کنید.
1. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
1. در روش دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
1. در روش سوم، تصویر هدف را با تصویری که پیش‌تر در مجموعه تصویر ارائه وجود دارد، جایگزین کنید.
1. ارائه‌ی اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است.
Presentation presentation = new Presentation("sample.pptx");
try {
    // روش اول.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // روش دوم.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // روش سوم.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // ارائه را در یک فایل ذخیره کنید.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
با مبدل رایگان Aspose برای [متن به GIF](https://products.aspose.app/slides/fa/text-to-gif)، می‌توانید به‌راحتی متن را انیمیشن کنید و GIFهایی از متن ایجاد کنید. 
{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**  
بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی بسته به نحوه‌ی مقیاس‌گذاری [تصویر](/slides/fa/androidjava/picture-frame/) در اسلاید و هرگونه فشرده‌سازی اعمال‌شده هنگام ذخیره‌سازی بستگی دارد.

**بهترین روش برای جایگزینی یک لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**  
لوگو را بر روی اسلاید مستر یا یک لایه قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، انتقال می‌یابد.

**آیا می‌توان یک SVG وارد شده را به شکل‌های قابل ویرایش تبدیل کرد؟**  
بله. می‌توانید یک SVG را به یک گروه از شکل‌ها تبدیل کنید؛ پس از آن، قسمت‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه چندین اسلاید به‌صورت همزمان تنظیم کرد؟**  
[تصویر را به‌عنوان پس‌زمینه](/slides/fa/androidjava/presentation-background/) بر روی اسلاید مستر یا لایه مربوطه تنظیم کنید—هر اسلایدی که از آن مستر/لایه استفاده می‌کند، پس‌زمینه را به‌ارث می‌برد.

**چگونه می‌توان از بزرگ شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  
به‌جای استفاده از تصاویر تکراری، از یک منبع تصویر استفاده مجدد کنید، وضوح‌های معقول انتخاب کنید، هنگام ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید تا در صورت نیاز.