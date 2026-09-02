---
title: بهینه‌سازی مدیریت تصاویر در ارائه‌ها با استفاده از JavaScript
linktitle: مدیریت تصاویر
type: docs
weight: 10
url: /fa/nodejs-java/image/
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
- حل‌کننده SVG
- تصاویر SVG پیوندی
- فونت‌های SVG
- افزودن EMF
- افزودن WMF
- افزودن TIFF
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت تصاویر را در PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java به‌صورت بهینه انجام دهید، عملکرد را ارتقا دهید و گردش کار خود را خودکار کنید."
---
## **معرفی**

تصاویر، ارائه‌ها را جذاب‌تر و بصری جذاب‌تری می‌کنند. در Microsoft PowerPoint می‌توانید تصاویر را از فایل‌ها، اینترنت یا منابع دیگر به اسلایدها اضافه کنید. به‌طور مشابه، Aspose.Slides به شما امکان می‌دهد تا تصاویر را به اسلایدهای ارائه به روش‌های مختلف اضافه کنید.

{{% alert  title="Tip" color="primary" %}} 

Aspose مبدل‌های رایگانی ارائه می‌دهد — [JPEG به PowerPoint](https://products.aspose.app/slides/fa/import/jpg-to-ppt) و [PNG به PowerPoint](https://products.aspose.app/slides/fa/import/png-to-ppt) — که به شما امکان می‌دهند به سرعت ارائه‌ها را از تصاویر ایجاد کنید. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

اگر می‌خواهید یک تصویر را به‌صورت چارچوب تصویر اضافه کنید — به‌ویژه اگر قصد تغییر اندازه، اعمال افکت یا استفاده از سایر گزینه‌های قالب‌بندی استاندارد را دارید — به [Picture Frame](/slides/fa/nodejs-java/picture-frame/) مراجعه کنید. 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

شما می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. صفحات زیر را ببینید: تبدیل [image به JPG](https://products.aspose.com/slides/fa/nodejs-java/conversion/image-to-jpg/)، [JPG به image](https://products.aspose.com/slides/fa/nodejs-java/conversion/jpg-to-image/)، [JPG به PNG](https://products.aspose.com/slides/fa/nodejs-java/conversion/jpg-to-png/)، [PNG به JPG](https://products.aspose.com/slides/fa/nodejs-java/conversion/png-to-jpg/)، [PNG به SVG](https://products.aspose.com/slides/fa/nodejs-java/conversion/png-to-svg/)، و [SVG به PNG](https://products.aspose.com/slides/fa/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides از تصاویر در قالب‌های محبوبی مانند JPEG، PNG، BMP، GIF و سایرین پشتیبانی می‌کند. 

## **اضافه کردن تصاویر ذخیره‌شده به‌صورت محلی به اسلایدها**

می‌توانید یک یا چند تصویر ذخیره‌شده بر روی کامپیوتر خود را به یک اسلاید ارائه اضافه کنید. کد نمونه JavaScript زیر نشان می‌دهد چگونه یک تصویر به اسلاید اضافه شود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر از وب به اسلایدها**

اگر تصویری که می‌خواهید به اسلاید اضافه کنید در کامپیوتر شما ذخیره نشده باشد، می‌توانید آن را مستقیم از وب اضافه کنید. 

کد نمونه JavaScript زیر نشان می‌دهد چگونه یک تصویر از وب به اسلاید اضافه شود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر به مستر اسلاید**

یک مستر اسلاید اطلاعاتی مانند تم و چیدمان اسلایدهایی که از آن استفاده می‌کنند را ذخیره و کنترل می‌کند. وقتی یک تصویر را به مستر اسلاید اضافه می‌کنید، تصویر در هر اسلایدی که بر پایه آن مستر ساخته شده ظاهر می‌شود. 

کد نمونه JavaScript زیر نشان می‌دهد چگونه یک تصویر به مستر اسلاید اضافه شود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **اضافه کردن تصاویر به‌عنوان پس‌زمینه اسلاید**

می‌توانید از یک تصویر به‌عنوان پس‌زمینه برای یک یا چند اسلاید استفاده کنید. برای جزئیات، به *[تنظیم تصاویر به‌عنوان پس‌زمینه برای اسلایدها](/slides/fa/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* مراجعه کنید.

## **اضافه کردن SVG به ارائه‌ها**

محتوای SVG می‌تواند با استفاده از کلاس [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) به یک ارائه اضافه شود. شیء تصویر SVG حاصل سپس می‌تواند به مجموعه تصاویر ارائه اضافه شده و برای ایجاد یک چارچوب تصویر استفاده شود.

کد نمونه JavaScript زیر یک رشته SVG خودمحافظ را وارد می‌کند. تمام تصاویر، سبک‌ها و سایر منابع مورد استفاده توسط این SVG به‌صورت مستقیم در محتوای SVG تعبیه می‌شوند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **وارد کردن محتوای SVG با منابع خارجی**

فایل‌های SVG که از ابزارهای طراحی، ویرایشگرهای نمودار، سیستم‌های آیکون و خطوط لوله وب استخراج می‌شوند ممکن است به منابعی که خارج از سند SVG ذخیره شده‌اند ارجاع دهند. برای مثال، یک SVG می‌تواند شامل پیوند تصویری مانند `images/photo.png`، مقدار CSS `url(...)` یا URL یک فونت باشد.

برای وارد کردن چنین محتوای SVG، یک حل‌کننده منابع خارجی فراهم کنید و آن را به همراه یک URI پایه به سازنده مناسب [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) پاس دهید. URI پایه مکان سند SVG را شناسایی می‌کند و برای حل پیوندهای نسبی استفاده می‌شود.

کلاس `SvgImage` دسترسی به اطلاعات درباره SVG وارد شده را فراهم می‌کند:

- `getSvgContent()` مقدار مارکاپ SVG را به‌صورت رشته برمی‌گرداند.
- `getSvgData()` محتوای SVG را به‌صورت آرایه بایت برمی‌گرداند.
- `getBaseUri()` URI پایه مورد استفاده برای پیوندهای نسبی را برمی‌گرداند.
- `getExternalResourceResolver()` حل‌کننده‌ای که به تصویر SVG اختصاص داده شده است را برمی‌گرداند.

### **پیاده‌سازی حل‌کننده منبع خارجی**

حل‌کننده دارای دو متد است:

- `resolveUri` URI پایه و یک پیوند منبع نسبی را ترکیب می‌کند و URI مطلقی را برمی‌گرداند. وقتی پیوند قابل حل نیست یا مجاز نیست `null` برگردانید.
- `getEntity` یک جریان Java قابل خواندن برای URI منبع مطلق برمی‌گرداند. وقتی منبع گم شده، مسدود یا در دسترس نیست `null` برگردانید. در صورت لزوم می‌توان یک جریان جایگزین نیز برگرداند.

کد کمکی زیر یک حل‌کننده ایجاد می‌کند که تنها منابع پیوندی را از یک پوشه محلی مجاز بارگذاری می‌کند. منابع شبکه و مسیرهای خارج از پوشه مجاز مسدود می‌شوند. برای پیوندهای تصویر حل‌نشده، یک تصویر جایگزین اختیاری برگردانده می‌شود.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // این حل‌کننده به‌طور عمدی فقط فایل‌های محلی را اجازه می‌دهد.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // فقط برای منابع تصویری از یک جایگزین استفاده کنید. برگرداندن یک جریان تصویر
                // برای یک فونت یا استایل‌شیت گمشده معتبر نخواهد بود.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **حل کردن منابع پیوندی هنگام وارد کردن SVG**

فرض کنید `assets/diagram.svg` شامل یک مرجع نسبی مانند زیر باشد:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

کد نمونه JavaScript زیر URI فایل SVG را به‌عنوان URI پایه می‌گذارد و یک حل‌کننده سفارشی فراهم می‌کند. حل‌کننده پیوند تصویر نسبی را به URI مطلق تبدیل می‌کند و یک جریان حاوی منبع پیوندی را برمی‌گرداند در حالی که Aspose.Slides SVG را پردازش می‌کند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// URI پایه مکان سند SVG را نشان می‌دهد.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلاس `SvgImage` همچنین overloadهای دیگری دارد که داده‌های SVG را به‌صورت آرایه بایت می‌پذیرند، به‌علاوه روش‌های کارخانه‌ای مبتنی بر جریان، همراه با یک حل‌کننده منابع خارجی و یک URI پایه.

{{% alert title="Important" color="warning" %}}

حل‌کننده منابع خارجی منابع خارجی را در زمان پردازش و رندر SVG توسط Aspose.Slides در دسترس می‌سازد. این حل‌کننده مارکاپ SVG اصلی را تغییر نمی‌دهد و به‌طور خودکار منابع حل‌شده را درون آن تعبیه نمی‌کند.

زمانی که یک تصویر SVG به مجموعه تصاویر ارائه اضافه می‌شود، فایل PPTX می‌تواند هم نمایندگی SVG اصلی و هم یک تصویر رستری جایگزین را شامل شود. یک منبع پیوندی می‌تواند در تصویر جایگزین تولید شده ظاهر شود در حالی که پیوند نسبی مانند `images/photo.png` در SVG ذخیره‌شده بدون تغییر می‌ماند. بنابراین برنامه‌ای که نمای SVG بومی را رندر می‌کند، ممکن است محتوای پیوندی را هنگام عدم دسترسی به منبع خارجی اصلی نادیده بگیرد.

{{% /alert %}}

### **ایجاد یک تصویر SVG قابل حمل**

برای ایجاد یک تصویر SVG که به فایل‌های خارجی وابسته نباشد، قبل از ساخت `SvgImage`، SVG را خودمحافظ کنید. برای مثال، URLهای تصاویر پیوندی را با URIهای `data:` که شامل داده تصویر هستند، جایگزین کنید:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

پس از تعبیه تمام منابع مورد نیاز در محتوای SVG، `SvgImage` را ایجاد کنید، به مجموعه تصاویر ارائه اضافه کنید و همان‌طور که در مثال پیشین نشان داده شد، آن را در یک چارچوب تصویر وارد کنید.

### **مدیریت منابع از دست رفته یا مسدود شده**

وقتی URI منبع نامعتبر، ممنوع یا غیرقابل حل باشد، از `resolveUri` `null` برگردانید. وقتی منبع قابل خواندن نیست، از `getEntity` `null` برگردانید. Aspose.Slides تا حد امکان پردازش SVG را بدون آن منبع ادامه می‌دهد.

یک جریان جایگزین می‌تواند برای منبع گم‌شده برگردانده شود، اما محتویات آن باید با نوع منبع درخواست‌شده سازگار باشد. برای مثال، فقط برای تصویر گم‌شده یک جریان تصویری برگردانید، نه برای یک فونت یا stylesheet.

{{% alert title="Security" color="warning" %}}

از حل کردن مسیرهای فایل دلخواه یا URLهای شبکه نامحدود از فایل‌های SVG غیرقابل اعتماد خودداری کنید. طرح‌ها، پوشه‌ها و میزبان‌های مجاز را محدود کنید. برای منابع شبکه، زمان‌انتظار اتصال، محدودیت‌های اندازه پاسخ و اعتبارسنجی محتوا را نیز اعمال کنید.

{{% /alert %}}

## **تبدیل SVG به مجموعه‌ای از شکل‌ها**

Aspose.Slides می‌تواند یک SVG را به مجموعه‌ای از شکل‌ها تبدیل کند، مشابه عملکرد متناظر در PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

این قابلیت توسط یک overload از متد [addGroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) کلاس [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) که یک شیء تصویر SVG را به‌عنوان اولین آرگومان می‌گیرد، فراهم می‌شود.

کد نمونه JavaScript زیر نشان می‌دهد چگونه از این متد برای تبدیل یک فایل SVG به مجموعه‌ای از شکل‌ها استفاده کنید:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// نام فایل SVG منبع.
const svgFileName = "sample.svg";

// نام فایل خروجی ارائه.
const outPptxPath = "presentation.pptx";

// ایجاد یک ارائه جدید.
const presentation = new aspose.slides.Presentation();
try {
    // خواندن محتوای فایل SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // ایجاد شیء SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // دریافت اندازه اسلاید.
    const slideSize = presentation.getSlideSize().getSize();

    // تبدیل تصویر SVG به یک گروه از اشکال و مقیاس‌گذاری آن به اندازه اسلاید.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // ذخیره ارائه در قالب PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اضافه کردن تصاویر به‌صورت EMF به اسلایدها**

Aspose.Slides برای Node.js از طریق Java به شما امکان می‌دهد تا تصاویر EMF را از کاربرگ‌های Excel با Aspose.Cells تولید کنید و به اسلایدهای ارائه اضافه کنید.

کد نمونه JavaScript زیر نشان می‌دهد چگونه این کار انجام شود:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// کاربرگ را در یک جریان ذخیره می‌کند.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // فایل را به همان شکل اضافه کنید تا تصویر به صورت یک EMF وکتور باقی بماند و رستری نشود.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **جایگزینی تصاویر در مجموعه تصویر**

Aspose.Slides به شما اجازه می‌دهد تصاویر ذخیره‌شده در مجموعه تصویر یک ارائه، از جمله تصاویری که توسط شکل‌های اسلاید استفاده می‌شوند، را جایگزین کنید. این بخش چندین روش برای به‌روزرسانی تصاویر در مجموعه را شرح می‌دهد. می‌توانید یک تصویر را با داده‌های بایت خام، یک نمونه [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) یا تصویری که قبلاً در مجموعه وجود دارد، جایگزین کنید.

1. فایل ارائه حاوی تصاویر را با استفاده از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید.
2. یک تصویر جدید را از یک فایل به‌صورت آرایه بایت بارگذاری کنید.
3. تصویر هدف را با تصویر جدید با استفاده از آرایه بایت جایگزین کنید.
4. در روش دوم، تصویر را به‌صورت شیء [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) بارگذاری کنید و تصویر هدف را با آن شیء جایگزین کنید.
5. در روش سوم، تصویر هدف را با تصویری که در مجموعه تصویر ارائه از قبل وجود دارد، جایگزین کنید.
6. ارائه اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// شیء Presentation را که نمایانگر یک فایل ارائه است، نمونه سازی کنید.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // راه اول.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // راه دوم.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // راه سوم.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // ذخیره ارائه در یک فایل.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

با مبدل رایگان [Text to GIF](https://products.aspose.app/slides/fa/text-to-gif) می‌توانید به‌راحتی متن را انیمیشن کنید و GIF از متن ایجاد کنید. 

{{% /alert %}}

## **سوالات متداول**

**آیا وضوح تصویر اصلی پس از ورود حفظ می‌شود؟**

بله. پیکسل‌های منبع حفظ می‌شوند، اما ظاهر نهایی به این بستگی دارد که چگونه [picture](/slides/fa/nodejs-java/picture-frame/) در اسلاید مقیاس‌بندی می‌شود و چه فشرده‌سازی‌ای هنگام ذخیره اعمال می‌شود.

** بهترین راه برای جایگزینی لوگوی یکسان در ده‌ها اسلاید به‌طور همزمان چیست؟**

لوگو را بر روی مستر اسلاید یا یک طرح‌بندی قرار دهید و آن را در مجموعه تصویر ارائه جایگزین کنید — به‌روزرسانی‌ها به تمام عناصری که از آن منبع استفاده می‌کنند، انتشار می‌یابد.

** آیا می‌توان SVG وارد‌شده را به شکل‌های قابل ویرایش تبدیل کرد؟**

بله. می‌توانید یک SVG را به یک گروه شکل تبدیل کنید؛ پس از آن بخش‌های جداگانه با ویژگی‌های استاندارد شکل قابل ویرایش می‌شوند.

** چگونه می‌توان یک تصویر را به‌عنوان پس‌زمینه برای چند اسلاید به‌طور همزمان تنظیم کرد؟**

[Assign the image as the background](/slides/fa/nodejs-java/presentation-background/) را بر روی مستر اسلاید یا طرح‌بندی مرتبط اعمال کنید — هر اسلایدی که از آن مستر/طرح‌بندی استفاده می‌کند، پس‌زمینه را به ارث می‌برد.

** چگونه می‌توان از بزرگ شدن بیش از حد یک ارائه به‌دلیل تعداد زیاد تصویر جلوگیری کرد؟**

به‌جای تکرار تصاویر، از یک منبع تصویر واحد استفاده کنید، وضوح مناسب را انتخاب کنید، هنگام ذخیره فشرده‌سازی اعمال کنید و گرافیک‌های تکراری را در مستر نگه دارید، در صورت مناسب.