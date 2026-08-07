---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/java/image/
keywords:
- افزودن تصویر
- افزودن عکس
- افزودن بیت‌مپ
- جایگزینی تصویر
- جایگزینی عکس
- از وب
- پس‌زمینه
- افزودن PNG
- افزودن JPG
- افزودن SVG
- منابع خارجی SVG
- حل‌کننده SVG
- تصاویر SVG لینک‌شده
- فونت‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت تصاویر در PowerPoint و OpenDocument را با Aspose.Slides برای Java به‌صورت یکپارچه انجام دهید، عملکرد را بهینه‌سازی کنید و فرآیند کاری خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و از نظر بصری جذاب‌تر می‌سازند. در مایکروسافت پاورپوینت می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides امکان افزودن تصاویر به اسلایدهای ارائه را به روش‌های مختلف فراهم می‌کند.

{{% alert  title="نکته" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد — [JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 

{{% /alert %}} 

{{% alert title="اطلاع" color="info" %}}

اگر می‌خواهید یک تصویر را به‌عنوان فریم تصویر اضافه کنید — به‌ویژه اگر قصد تغییر اندازه، اعمال افکت یا استفاده از گزینه‌های قالب‌بندی استاندارد را دارید — به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="یادداشت" color="warning" %}}

می‌توانید تصاویر را از یک قالب به قالب دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/), و [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides تصاویر را در قالب‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند. 

## **افزودن تصاویر ذخیره شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده در کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه جاوا زیر نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

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

## **افزودن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه جاوا زیر نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

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

## **افزودن تصاویر به اسلاید مسترها**

یک اسلاید مستر اطلاعاتی مانند تم و چینش اسلایدهای استفاده‌کننده از آن را ذخیره و کنترل می‌کند. وقتی یک تصویر را به اسلاید مستر اضافه کنید، تصویر بر روی هر اسلایدی که بر پایه آن مستر است نمایش داده می‌شود. 

کد نمونه جاوا زیر نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

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

## **افزودن تصاویر به‌عنوان پس‌زمینه اسلایدها**

می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[Setting Images as Backgrounds for Slides](/slides/fa/java/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **افزودن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) به یک ارائه اضافه شود. شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) حاصل سپس می‌تواند به مجموعه تصاویر ارائه اضافه شود و برای ایجاد فریم تصویر استفاده شود. 

مثال جاوای زیر یک رشته SVG خودکفا را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع استفاده‌شده توسط این SVG مستقیماً در محتوای SVG جاسازی شده‌اند.

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

فایل‌های SVG صادرشده از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون و خط لوله‌های وب ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. برای مثال، یک SVG می‌تواند شامل لینک تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL قلم باشد. 

برای وارد کردن چنین محتوای SVG، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iexternalresourceresolver/) ایجاد کنید و آن را همراه با یک URI پایه به سازنده مناسب [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) پاس دهید. URI پایه محل سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود. 

رابط [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG واردشده را فراهم می‌کند:

- `getSvgContent()` مارک‌آپ SVG را به‌صورت رشته برمی‌گرداند.  
- `getSvgData()` محتوای SVG را به‌صورت آرایه بایت برمی‌گرداند.  
- `getBaseUri()` URI پایه‌ای که برای لینک‌های نسبی استفاده می‌شود را برمی‌گرداند.  
- `getExternalResourceResolver()` حل‌کنندهٔ اختصاص داده‌شده به تصویر SVG را برمی‌گرداند.  

### **پیاده‌سازی یک حل‌کنندهٔ منبع خارجی**

حل‌کننده دو متد دارد:

- `resolveUri` URI پایه و لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. وقتی لینک قابل حل نیست یا مجاز نیست `null` برگردانید.  
- `getEntity` یک جریان قابل خواندن برای یک URI منبع مطلق برمی‌گرداند. وقتی منبع گمشده، مسدود یا در دسترس نیست `null` برگردانید. در مواقع مناسب می‌توان یک جریان جایگزین نیز برگرداند.  

حل‌کنندهٔ زیر فقط منابع لینک‌شده را از یک پوشهٔ محلی مجاز بارگذاری می‌کند. منابع شبکه‌ای و مسیرهای خارج از پوشهٔ مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویری حل‌نشده برگردانده می‌شود.

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

            // این حل‌کننده به‌صورت عمدی فقط فایل‌های محلی را اجازه می‌دهد.
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

            // فقط برای منابع تصویری از یک تصویر جایگزین استفاده کنید. بازگرداندن یک جریان تصویر
            // برای قلم یا stylesheet گمشده معتبر نخواهد بود.
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

### **حل منابع لینک‌شده هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل ارجاع نسبی‌ای مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

مثال جاوای زیر URI فایل SVG را به‌عنوان URI پایه پاس می‌دهد و یک حل‌کنندهٔ سفارشی ارائه می‌کند. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل کرده و یک جریان شامل منبع لینک‌شده را هنگام پردازش SVG توسط Aspose.Slides برمی‌گرداند.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI پایه مکان سند SVG را نشان می‌دهد.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

کلاس `SvgImage` همچنین بارگذاری‌های متغیری دارد که داده‌های SVG را به‌صورت آرایه بایت یا جریان ورودی می‌پذیرند، همراه با یک حل‌کنندهٔ منبع خارجی و یک URI پایه.  

{{% alert title="مهم" color="warning" %}}

حل‌کنندهٔ منابع، منابع خارجی را در حالی که Aspose.Slides SVG را پردازش و رندر می‌کند در دسترس می‌گذارد. این عملکرد SVG اصلی را تغییر نمی‌دهد یا به‌صورت خودکار منابع حل‌شده را در آن جاسازی نمی‌کند.  

زمانی که یک `ISvgImage` به مجموعهٔ تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمای اصلی SVG و هم یک تصویر رستر جایگزین را شامل شود. یک منبع لینک‌شده می‌تواند در تصویر جایگزین تولید‌شده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر می‌ماند. برنامه‌ای که نمای بومی SVG را رندر می‌کند ممکن است محتوای لینک‌شده را زمانی که منبع خارجی اصلی در دسترس نیست، نادیده بگیرد.  

{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ایجاد `SvgImage`، SVG را خودکفا کنید. به‌عنوان مثال، URLهای تصاویر لینک‌شده را با URIهای `data:` که شامل داده‌های تصویر هستند جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از اینکه تمام منابع مورد نیاز در محتوای SVG جاسازی شد، `SvgImage` را ایجاد کنید، به مجموعهٔ تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، آن را در یک فریم تصویر وارد کنید.  

### **مدیریت منابع گمشده یا مسدود شده**

زمانی که URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، `null` را از `resolveUri` برگردانید. وقتی منبع قابل خواندن نیست، `null` را از `getEntity` برگردانید. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.  

یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتوای آن باید با نوع منبع درخواست‌شده سازگار باشد. به‌عنوان مثال، فقط برای تصویر گمشده یک جریان تصویری برگردانید، نه برای قلم یا stylesheet.  

{{% alert title="امنیت" color="warning" %}}

از حل مسیرهای فایل دلخواه یا URLهای شبکهٔ بدون محدودیت از فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌های مجاز، پوشه‌ها و میزبان‌ها را محدود کنید. برای منابع شبکه‌ای، همچنین زمان‌سنجی اتصال، محدودیت‌های حجم پاسخ و اعتبارسنجی محتوا را اعمال کنید.  

{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از اشکال تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک بارگذاری (overload) از متد [addGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) از اینترفیس [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISvgImage) را به عنوان اولین آرگومان می‌گیرد، ارائه می‌شود.  

کد نمونه جاوای زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده کنید:

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

// ایجاد یک ارائه جدید.
IPresentation presentation = new Presentation();
try {
    // خواندن محتوای فایل SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // ایجاد یک شیء SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تبدیل تصویر SVG به یک گروه از اشکال و مقیاس‌بندی آن به اندازه اسلاید.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // ذخیرهٔ ارائه در قالب PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **افزودن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای Java به شما امکان می‌دهد تصاویر EMF را از ورک‌شیت‌های Excel با Aspose.Cells تولید کنید و به اسلایدهای ارائه اضافه کنید.  

کد نمونه جاوای زیر نشان می‌دهد چگونه این کار را انجام دهید:

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

// کتاب کار را در یک جریان ذخیره می‌کند.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // فایل را به همان شکل اضافه کنید تا تصویر به‌عنوان یک EMF برداری باقی بماند و رستر نشود.
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

## **جایگزینی تصاویر در مجموعهٔ تصاویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعهٔ تصاویر یک ارائه، از جمله تصاویر استفاده‌شده توسط اشکال اسلاید، را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را شرح می‌دهد. می‌توانید یک تصویر را با استفاده از داده‌های بایتی خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، جایگزین کنید.  

1. فایل ارائه حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید.  
2. یک تصویر جدید را از فایل به آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. در رویکرد دوم، تصویر را به یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.  
5. در رویکرد سوم، تصویر هدف را با تصویری که قبلاً در مجموعهٔ تصاویر ارائه موجود است، جایگزین کنید.  
6. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.  

```java
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
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

{{% alert title="اطلاع" color="info" %}}

با مبدل رایگان Aspose برای [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif)، می‌توانید به سادگی متن را انیمیشن کنید و GIFهایی از متن ایجاد کنید.  

{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این بستگی دارد که چگونه [picture](/slides/fa/java/picture-frame/) در اسلاید مقیاس‌بندی می‌شود و چه فشرده‌سازی‌ای در زمان ذخیره اعمال می‌شود.

**بهترین راه برای جایگزینی یک لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را بر روی اسلاید مستر یا یک لایه قرار دهید و آن را در مجموعهٔ تصاویر ارائه جایگزین کنید — به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، گسترش می‌یابد.

**آیا یک SVG وارد‌شده می‌تواند به اشکال قابل ویرایش تبدیل شود؟**

بله. می‌توانید یک SVG را به یک گروه از اشکال تبدیل کنید، پس از آن قسمت‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کرد؟**

[تصویر را به‌عنوان پس‌زمینه تنظیم کنید](/slides/fa/java/presentation-background/) بر روی اسلاید مستر یا لایه مربوطه — هر اسلایدی که از آن مستر/لایه استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

**چگونه می‌توان از بزرگ شدن بیش از حد یک ارائه به دلیل تعداد زیاد تصاویر جلوگیری کرد؟**

از یک منبع تصویری واحد به‌جای نسخه‌های تکراری استفاده کنید، وضوح‌های معقول انتخاب کنید، در زمان ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در صورت مناسب در مستر نگه‌دارید.