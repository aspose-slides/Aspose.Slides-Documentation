---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها بر روی Android
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/androidjava/image/
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
- تصاویر SVG پیوندی
- قلم‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت تصویر در PowerPoint و OpenDocument را با Aspose.Slides برای Android از طریق Java بهبود دهید، عملکرد را بهینه کنید و جریان کاری خود را خودکار کنید."
---
## **مقدمه**

تصاویر ارائه‌ها را جذاب‌تر و بصری‌تر می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides اجازه می‌دهد تا به روش‌های مختلفی تصاویر را به اسلایدهای ارائه اضافه کنید.

{{% alert  title="Tip" color="info" %}} 
Aspose مبدل‌های رایگانی ارائه می‌دهد—[JPEG to PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG to PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt)—که به شما امکان می‌دهد به‌سرعت ارائه‌ها را از تصاویر ایجاد کنید. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
اگر می‌خواهید تصویری را به‌عنوان فریم تصویر اضافه کنید—به‌ویژه اگر قصد تغییر اندازه، اعمال افکت یا استفاده از سایر گزینه‌های قالب‌بندی استاندارد را دارید—به [Picture Frame](/slides/fa/androidjava/picture-frame/) مراجعه کنید. 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/androidjava/conversion/image-to-jpg/)، [JPG to image](https://products.aspose.com/slides/fa/androidjava/conversion/jpg-to-image/)، [JPG to PNG](https://products.aspose.com/slides/fa/androidjava/conversion/jpg-to-png/)، [PNG to JPG](https://products.aspose.com/slides/fa/androidjava/conversion/png-to-jpg/)، [PNG to SVG](https://products.aspose.com/slides/fa/androidjava/conversion/png-to-svg/)، و [SVG to PNG](https://products.aspose.com/slides/fa/androidjava/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides از تصاویر در فرمت‌های محبوبی مانند JPEG، PNG، BMP، GIF و دیگران پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونهٔ زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به اسلاید اضافه کنید:

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

کد نمونهٔ زیر به زبان Java نشان می‌دهد چگونه یک تصویر را از وب به اسلاید اضافه کنید:

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

یک اسلاید مستر اطلاعاتی مانند تم و طرح‌بندی اسلایدهایی که از آن استفاده می‌کنند را ذخیره و کنترل می‌کند. وقتی تصویری را به یک اسلاید مستر اضافه می‌کنید، آن تصویر بر تمام اسلایدهای مبتنی بر آن مستر ظاهر می‌شود. 

کد نمونهٔ زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به اسلاید مستر اضافه کنید:

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

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلایدها**

می‌توانید یک تصویر را به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به‌عنوان پس‌زمینه اسلایدها](/slides/fa/androidjava/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) به یک ارائه اضافه شود. شیء حاصل از نوع [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) سپس می‌تواند به مجموعهٔ تصاویر ارائه اضافه شده و برای ایجاد یک فریم تصویر استفاده شود.

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

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای دیاگرام، سیستم‌های آیکون و خطوط لوله وب استخراج می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. به عنوان مثال، یک SVG می‌تواند شامل لینکی به تصویر مانند `images/photo.png`، مقدار CSS `url(...)` یا آدرس URL یک فونت باشد. 

برای وارد کردن چنین محتوای SVG‌ای، یک پیاده‌سازی از [IExternalResourceResolver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iexternalresourceresolver/) ایجاد کنید و آن را به‌ همراه یک URI پایه به سازندهٔ مناسب [SvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgimage/) پاس بدهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل لینک‌های نسبی استفاده می‌شود. 

رابط [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) دسترسی به اطلاعاتی دربارهٔ SVG وارد شده فراهم می‌کند:

- `getSvgContent()` محتوای SVG را به‌صورت رشته بر می‌گرداند.
- `getSvgData()` محتوا را به‌صورت آرایهٔ بایت بر می‌گرداند.
- `getBaseUri()` URI پایه مورد استفاده برای لینک‌های نسبی را بر می‌گرداند.
- `getExternalResourceResolver()` حل‌کنندهٔ منبع اختصاص داده شده به تصویر SVG را بر می‌گرداند.

### **پیاده‌سازی حل‌کنندهٔ منبع خارجی**

حل‌کننده دو متد دارد:

- `resolveUri` URI پایه و لینک منبع نسبی را ترکیب می‌کند و یک URI مطلق بر می‌گرداند. زمانی که لینک قابل حل نیست یا مجاز نیست، `null` برگردانید.
- `getEntity` برای یک URI منبع مطلق یک جریان قابل خواندن بر می‌گرداند. وقتی منبع گم شده، مسدود شده یا در دسترس نیست `null` برگردانید. در صورت مناسب می‌توان یک جریان جایگزین نیز برگرداند.

کد زیر فقط منابع پیوندی را از یک پوشهٔ محلی مجاز بارگذاری می‌کند. منابع شبکه‌ای و مسیرهای خارج از پوشهٔ مجاز مسدود می‌شوند. یک تصویر جایگزین اختیاری برای لینک‌های تصویر حل‌نشده برگردانده می‌شود:

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

            // از یک تصویر جایگزین فقط برای منابع تصویری استفاده کنید. بازگرداندن یک جریان تصویر
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

### **حل منابع پیوندی هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` حاوی یک ارجاع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

کد نمونهٔ زیر به زبان Java URI فایل SVG را به‌عنوان URI پایه می‌پذیرد و یک حل‌کنندهٔ سفارشی ارائه می‌دهد. حل‌کننده لینک تصویر نسبی را به یک URI مطلق تبدیل می‌کند و یک جریان شامل منبع پیوندی را بر می‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند:

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

کلاس `SvgImage` همچنین overloadهایی فراهم می‌کند که دادهٔ SVG را به‌صورت آرایهٔ بایت یا یک جریان ورودی می‌پذیرند، به‌همراه یک حل‌کنندهٔ منبع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}
حل‌کنندهٔ منبع، منابع خارجی را در حین پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌گذارد. این کار به‌صورت خودکار علامت‌گذاری SVG اصلی را تغییر یا منابع حل‌شده را درون آن جاسازی نمی‌کند.

زمانی که یک `ISvgImage` به مجموعهٔ تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایهٔ اصلی SVG و هم یک تصویر رستر جایگزین را دربرگیرد. یک منبع پیوندی می‌تواند در تصویر جایگزین تولید شده ظاهر شود در حالی که لینک نسبی مانند `images/photo.png` در SVG ذخیره شده دست‌نخورده می‌ماند. برنامه‌ای که نمایهٔ SVG بومی را رندر می‌کند ممکن است محتوای پیوندی را زمانی که منبع خارجی اصلی در دسترس نیست، نادیده بگیرد.
{{% /alert %}}

### **ایجاد تصویر SVG قابل حمل**

برای ساخت یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ایجاد `SvgImage`، SVG را خودکفا کنید. برای مثال، URLهای تصویر پیوندی را با URIهای `data:` که شامل دادهٔ تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از جاسازی تمام منابع مورد نیاز در محتوای SVG، `SvgImage` را ایجاد کنید، به مجموعهٔ تصاویر ارائه اضافه کنید و همان‌طور که در مثال قبلی نشان داده شد، در یک فریم تصویر وارد کنید.

### **مدیریت منابع گمشده یا مسدود شده**

زمانی که URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، `null` را از `resolveUri` برگردانید. وقتی منبع قابل خواندن نیست، `null` را از `getEntity` برگردانید. Aspose.Slides در صورت امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.

یک جریان جایگزین می‌تواند برای منبع گمشده برگردانده شود، اما محتوا باید با نوع منبع درخواستی سازگار باشد. برای مثال، فقط برای یک تصویر گمشده یک جریان تصویر برگردانید، نه برای یک فونت یا stylesheet.

{{% alert title="Security" color="warning" %}}
از حل مسیرهای فایل دلخواه یا URLهای شبکه‌ای بدون محدودیت از فایل‌های SVG غیرمطمئن خودداری کنید. طرح‌ها، پوشه‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه‌ای، همچنین زمان‑انتهای اتصال، محدودیت‌های اندازهٔ پاسخ و اعتبارسنجی محتوا را اعمال کنید.
{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از اشکال**

![منوی پاپ‑آپ PowerPoint](img_01_01.png)

این قابلیت توسط یک overload از متد [addGroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection) که یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISvgImage) را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

کد نمونهٔ زیر به زبان Java نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از اشکال استفاده کنید:

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

// ساخت یک ارائه جدید.
IPresentation presentation = new Presentation();
try {
    // خواندن محتوای فایل SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // ایجاد شیء SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // دریافت اندازه اسلاید.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // تبدیل تصویر SVG به یک گروه از اشکال و مقیاس‌گذاری آن به اندازه اسلاید.
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

Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد تصاویر EMF را از کاربرگ‌های Excel با Aspose.Cells تولید کنید و به اسلایدهای ارائه اضافه کنید.

کد نمونهٔ زیر به زبان Java نحوه انجام این کار را نشان می‌دهد:

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

// ذخیره کتاب کار در یک جریان.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // فایل را همان‌طور اضافه کنید تا تصویر به‌عنوان یک EMF برداری باقی بماند و به‌رستر تبدیل نشود.
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

## **جایگزینی تصاویر در مجموعهٔ تصویر**

Aspose.Slides به شما امکان می‌دهد تصاویر ذخیره‌شده در مجموعهٔ تصویر یک ارائه را جایگزین کنید، از جمله تصاویری که توسط اشکال اسلاید استفاده می‌شوند. این بخش چندین روش برای به‌روز‌رسانی تصاویر در مجموعه را توصیف می‌کند. می‌توانید یک تصویر را با دادهٔ بایت خام، یک نمونهٔ [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) یا تصویر دیگری که قبلاً در مجموعه وجود دارد، جایگزین کنید.

مراحل زیر را دنبال کنید:

1. فایل ارائه‌ای که شامل تصاویر است را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگیری کنید.
2. یک تصویر جدید را از فایل به یک آرایهٔ بایت بارگیری کنید.
3. تصویر هدف را با تصویر جدید با استفاده از آرایهٔ بایت جایگزین کنید.
4. در روش دوم، تصویر را به‌صورت شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) بارگیری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در روش سوم، تصویر هدف را با تصویری که قبلاً در مجموعهٔ تصویر ارائه وجود دارد، جایگزین کنید.
6. ارائه‌ی اصلاح‌شده را به‌صورت فایل PPTX بنویسید.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
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
با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) از Aspose می‌توانید به‌راحتی متن را انیمیشن کنید و GIFهایی از متن بسازید. 
{{% /alert %}}

## **FAQ**

**آیا وضوح تصویر اصلی پس از درج حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به نحوهٔ مقیاس‌گذاری [picture](/slides/fa/androidjava/picture-frame/) در اسلاید و هرگونه فشرده‌سازی هنگام ذخیره‌سازی وابسته است.

**بهترین روش برای جایگزینی لوگوی یکسان در ده‌ها اسلاید به‌صورت همزمان چیست؟**

لوگو را در اسلاید مستر یا یک لایه‌برداری قرار دهید و آن را در مجموعهٔ تصویر ارائه جایگزین کنید—به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

**آیا می‌توان SVG وارد‌شده را به اشکال قابل ویرایش تبدیل کرد؟**

بله. می‌توانید یک SVG را به یک گروه از اشکال تبدیل کنید؛ پس از آن بخش‌های فردی با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

**چگونه می‌توانم یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌صورت همزمان تنظیم کنم؟**

[تصویر را به‌عنوان پس‌زمینه](/slides/fa/androidjava/presentation-background/) در اسلاید مستر یا لایه‌برداری مربوطه اختصاص دهید—هر اسلایدی که از آن مستر/لایه‌برداری استفاده می‌کند پس‌زمینه را به ارث می‌برد.

**چگونه از بزرگ‌ شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصاویر جلوگیری کنم؟**

یک منبع تصویر واحد را به جای تکرار استفاده کنید، وضوح معقولی انتخاب کنید، هنگام ذخیره‌سازی فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در صورت امکان در مستر نگه دارید.