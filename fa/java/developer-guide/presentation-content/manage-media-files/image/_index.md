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
- منابع SVG خارجی
- رزولور SVG
- تصاویر SVG پیوست‌شده
- فونت‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت تصاویر در PowerPoint و OpenDocument را با Aspose.Slides برای Java بهینه کنید، عملکرد را بهبود بخشید و گردش کار خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و بصری‌ً جذاب می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها وارد کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تصاویر را به اسلایدهای ارائه به چندین روش اضافه کنید.

{{% alert  title="Tip" color="info" %}} 
Aspose مبدل‌های رایگان—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—را ارائه می‌دهد که به شما امکان می‌دهد به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید یک تصویر را به‌عنوان چارچوب تصویر اضافه کنید—به‌ویژه اگر قصد دارید اندازه آن را تغییر دهید، افکت اعمال کنید یا از سایر گزینه‌های قالب‌بندی استاندارد استفاده کنید—به [Picture Frame](/slides/fa/java/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/)، [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/)، [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/)، [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، و [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایر فرمت‌ها پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره شده بر روی کامپیوتر خود را به اسلایدی از ارائه اضافه کنید. کد نمونه زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

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

اگر تصویر مورد نظر برای افزودن به اسلاید بر روی کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیماً از وب اضافه کنید. 

کد نمونه زیر به زبان Java نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

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

یک اسلاید مستر اطلاعاتی مانند تم و چیدمان اسلایدهایی که از آن استفاده می‌کنند را ذخیره و کنترل می‌کند. زمانی که یک تصویر را به اسلاید مستر اضافه کنید، تصویر در هر اسلاید مبتنی بر آن مستر ظاهر می‌شود. 

کد نمونه زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

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

می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[Setting Images as Backgrounds for Slides](/slides/fa/java/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) به یک ارائه اضافه شود. شیء حاصل از نوع [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) سپس می‌تواند به مجموعه تصاویر ارائه اضافه شده و برای ایجاد یک چارچوب تصویر استفاده شود.

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

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون یا مسیرهای وب صادر می‌شوند ممکن است به منابعی اشاره کنند که خارج از سند SVG ذخیره شده‌اند. به عنوان مثال، یک SVG می‌تواند شامل لینک تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL یک قلم باشد.

برای وارد کردن چنین محتوای SVG‌ای، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iexternalresourceresolver/) ایجاد کنید و همراه با یک URI پایه به سازنده مناسب [SvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgimage/) پاس دهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود.

رابط [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) دسترسی به اطلاعات مربوط به SVG وارد شده را فراهم می‌کند:

- `getSvgContent()` برچسب‌گذاری SVG را به عنوان رشته برمی‌گرداند.  
- `getSvgData()` محتوای SVG را به عنوان یک آرایه بایت برمی‌گرداند.  
- `getBaseUri()` URI پایه‌ای را که برای لینک‌های نسبی استفاده می‌شود برمی‌گرداند.  
- `getExternalResourceResolver()` رزولور اختصاص‌یافته به تصویر SVG را برمی‌گرداند.  

### **پیاده‌سازی یک رزولور منابع خارجی**

رزولور دو متد دارد:

- `resolveUri` URI پایه و یک لینک منبع نسبی را ترکیب کرده و یک URI مطلق برمی‌گرداند. هنگام عدم توانایی حل لینک یا عدم اجازه، `null` برگردانده می‌شود.  
- `getEntity` یک جریان خواندنی برای یک URI منبع مطلق برمی‌گرداند. وقتی منبع گمشده، مسدود یا در دسترس نیست، `null` برگردانده می‌شود. در صورت نیاز می‌توان یک جریان جایگزین نیز برگرداند.  

کد زیر فقط منابع پیوندی را از یک پوشه محلی مجاز بارگذاری می‌کند. منابع شبکه‌ای و مسیرهایی خارج از پوشه مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویری حل‌نشده برگردانده می‌شود.

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

            // این حل‌کننده به‌طور عمدی فقط فایل‌های محلی را مجاز می‌سازد.
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

            // فقط برای منابع تصویری از یک جایگزین استفاده کنید. بازگرداندن یک جریان تصویر
            // برای یک قلم یا سبک‌برگه گمشده معتبر نخواهد بود.
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

### **حل کردن منابع پیوندی هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک ارجاع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

کد نمونه زیر به زبان Java URI فایل SVG را به‌عنوان URI پایه پاس می‌دهد و یک رزولور سفارشی فراهم می‌کند. رزولور لینک تصویر نسبی را به URI مطلق تبدیل کرده و یک جریان شامل منبع پیوندی را برمی‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// URI پایه محل سند SVG را نشان می‌دهد.
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

کلاس `SvgImage` همچنین بارگذاری‌های دیگری دارد که داده‌های SVG را به‌صورت آرایه بایت یا جریان ورودی می‌پذیرند، به‌همراه یک رزولور منابع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}
رزولور منابع، منابع خارجی را در هنگام پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این عمل بر روی برچسب‌گذاری اصلی SVG تأثیری ندارد و به‌صورت خودکار منابع حل‌شده را درون SVG جاسازی نمی‌کند.  

زمانی که یک `ISvgImage` به مجموعه تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایه SVG اصلی و هم یک تصویر رستری جایگزین را شامل شود. یک منبع پیوندی می‌تواند در تصویر جایگزین تولیدشده ظاهر شود، در حالی که لینک نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر باقی می‌ماند. برنامه‌ای که نمایه SVG بومی را رندر می‌کند ممکن است محتوای پیوندی را در صورت عدم دسترسی به منبع خارجی اصلی نادیده بگیرد.  
{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ساخت `SvgImage` SVG را به‌صورت خودکفا کنید. به‌عنوان مثال، URLهای تصویر پیوندی را با URIهای `data:` که شامل داده تصویر هستند جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از جاسازی تمام منابع مورد نیاز در محتوای SVG، `SvgImage` را ایجاد کنید، به مجموعه تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، در یک چارچوب تصویر وارد کنید.

### **مدیریت منابع گمشده یا مسدود شده**

از `resolveUri` وقتی URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، `null` برگردانید. از `getEntity` وقتی منبع قابل خواندن نیست، `null` برگردانید. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.  

یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتوا باید با نوع منبع درخواست‌شده سازگار باشد؛ به‌عنوان مثال، تنها برای تصویر گمشده یک جریان تصویری برگردانید، نه برای قلم یا stylesheet.

{{% alert title="Security" color="warning" %}}
از حل مسیرهای فایل دلخواه یا URLهای شبکه‌ای بدون محدودیت در فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌های مجاز، پوشه‌ها و میزبان‌ها را محدود کنید. برای منابع شبکه‌ای نیز زمان‌سنجی اتصال، محدودیت اندازه پاسخ و اعتبارسنجی محتوا را اعمال کنید.  
{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک بارگذاری از متد [addGroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) از واسط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISvgImage) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

کد نمونه زیر به زبان Java نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:

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

    // تبدیل تصویر SVG به یک گروه از اشکال و تنظیم مقیاس آن به اندازه اسلاید.
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

## **اضافه کردن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای Java به شما امکان می‌دهد تصاویر EMF را از کاربرگ‌های Excel با Aspose.Cells تولید کرده و به اسلایدهای ارائه اضافه کنید.

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

// ذخیرهٔ کتاب کار به یک جریان.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // اضافه کردن فایل به همان شکل تا تصویر به عنوان یک EMF برداری باقی بماند و رسترنگ نشود.
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

## **جایگزینی تصاویر در مجموعه تصاویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصاویر یک ارائه، از جمله تصاویری که توسط شکل‌های اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چند روش برای به‌روزرسانی تصاویر در مجموعه را شرح می‌دهد. می‌توانید یک تصویر را با داده‌های بایت خام، یک نمونه‌ی [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) یا تصویری که پیشاپیش در مجموعه موجود است، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. فایل ارائه‌ای که شامل تصاویر است را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید.  
2. یک تصویر جدید را از فایل به‌صورت آرایه بایت بارگذاری کنید.  
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.  
4. در روش دوم، تصویر را به‌صورت شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) بارگذاری کرده و تصویر هدف را با آن شیء جایگزین کنید.  
5. در روش سوم، تصویر هدف را با تصویری که پیشاپیش در مجموعه تصاویر ارائه وجود دارد، جایگزین کنید.  
6. ارائه‌ی اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// نمونه سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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

    // ذخیرهٔ ارائه در یک فایل.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به‌راحتی متن را متحرک کنید و GIFهایی از متن ایجاد کنید. 
{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از درج همچنان حفظ می‌شود؟**  

بله. پیکسل‌های اصلی حفظ می‌شوند، اما ظاهر نهایی به نحوه‌ی مقیاس‌گذاری [picture](/slides/fa/java/picture-frame/) روی اسلاید و هر فشرده‌سازی انجام‌شده هنگام ذخیره بستگی دارد.  

**بهترین راه برای جایگزینی یک لوگو یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**  

لوگو را بر روی اسلاید مستر یا یک لایه قرار دهید و آن را در مجموعه تصاویر ارائه جایگزین کنید؛ به‌روزرسانی‌ها به تمام عناصری که از این منبع استفاده می‌کنند، اعمال می‌شود.  

**آیا یک SVG درج‌شده می‌تواند به شکل‌های قابل ویرایش تبدیل شود؟**  

بله. می‌توانید یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کنید؛ پس از آن بخش‌های فردی قابل ویرایش با خصوصیات استاندارد شکل خواهند بود.  

**چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چندین اسلاید به‌صورت همزمان تنظیم کرد؟**  

[تصویر را به‌عنوان پس‌زمینه](/slides/fa/java/presentation-background/) بر روی اسلاید مستر یا لایه مرتبط تنظیم کنید؛ هر اسلایدی که از آن مستر/لایه استفاده می‌کند، پس‌زمینه را به ارث می‌برد.  

**چگونه می‌توان از بزرگ شدن بیش‌ازحد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کرد؟**  

به‌جای تکثیر تصویر، از یک منبع تصویر واحد استفاده کنید، وضوح‌های معقول انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در جایی مانند مستر نگه دارید.