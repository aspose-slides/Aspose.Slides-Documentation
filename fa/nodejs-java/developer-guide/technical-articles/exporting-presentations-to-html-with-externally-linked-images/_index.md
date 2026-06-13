---
title: صادرات ارائه‌ها به HTML با تصاویر پیوندی خارجی
type: docs
weight: 100
url: /fa/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- صادرات PowerPoint
- صادرات OpenDocument
- صادرات ارائه
- صادرات اسلاید
- صادرات PPT
- صادرات PPTX
- صادرات ODP
- PowerPoint به HTML
- OpenDocument به HTML
- ارائه به HTML
- اسلاید به HTML
- PPT به HTML
- PPTX به HTML
- ODP به HTML
- تصویر پیوندی
- تصویر پیوندی خارجی
- منبع پیوندی
- منبع خارجی
- JavaScript
- Node.js
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument را به HTML در JavaScript با استفاده از Aspose.Slides برای Node.js از طریق Java صادر کنید، به‌طوری که تصاویر و سایر منابع به‌صورت فایل‌های پیوندی خارجی ذخیره شوند."
---
## **نمای کلی**

به‌طور پیش‌فرض، Aspose.Slides یک ارائه را به فایل HTML مستقل صادر می‌کند. تصاویر و سایر منابع مستقیماً داخل HTML نوشته می‌شوند، معمولاً به‌صورت داده‌های Base64. این زمانی که به یک فایل قابل حمل نیاز دارید مفید است، اما همیشه بهترین قالب برای وب‌سایت، CMS یا خط لولهٔ تبدیل سمت سرور نیست.

از منابع پیوندی خارجی استفاده کنید زمانی که می‌خواهید:
- حجم سند HTML را کاهش دهید؛
- تصاویر، قلم‌ها، صدا یا ویدئو را به‌صورت جداگانه در مرورگر یا CDN کش کنید؛
- پس از خروجی، منابع تولید شده را بررسی، جایگزین، فشرده یا پس‌پردازش کنید؛
- ساختار خروجی را نزدیک‌تر به آنچه یک برنامه وب انتظار دارد نگه دارید.

برای جریان کاری کلی تبدیل HTML، به [تبدیل ارائه‌های PowerPoint به HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) مراجعه کنید. این مقاله بر بخش پیوند منابع خروجی متمرکز است.

## **نحوهٔ کار خروجی با منابع پیوندی**

یک پراکسی جاوا برای [ILinkEmbedController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) به برنامهٔ شما امکان می‌دهد به‌صورت منبع به منبع تصمیم بگیرد که آیا صادرکننده داده‌ها را در HTML جاسازی می‌کند یا آن را به‌صورت خارجی ذخیره کرده و یک پیوند می‌نویسد.

کنترلر دارای سه متد است:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) تصمیم می‌گیرد که آیا یک منبع باید پیوند داده شود یا جاسازی گردد.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) آدرس URL را که در HTML تولید شده یا به منبع پیوندی دیگر نوشته می‌شود، بازمی‌گرداند.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) دادهٔ منبع پیوندی را روی دیسک یا به مقصد ذخیره‌سازی دیگری می‌نویسد.

مسیر سیستم‌فایل و آدرس URL مرورگر مسائلی جداگانه هستند. به عنوان مثال، نمونهٔ زیر فایل‌های منبع را در `html-output/assets` روی دیسک می‌نویسد، در حالی که HTML شامل URLهای نسبی مانند `assets/resource-1.svg` است. مرورگر این URLها را نسبت به فایلی که پیوند را شامل است حل می‌کند. بنابراین، پیوندی از `presentation.html` به یک فایل SVG از `assets/resource-1.svg` استفاده می‌کند، در حالی که پیوندی از همان فایل SVG به تصویری که در همان پوشهٔ `assets` ذخیره شده است، از `resource-4.jpg` استفاده می‌کند.

## **صادر کردن HTML با منابع پیوندی**

مثال زیر JavaScript یک پوشهٔ خروجی ایجاد می‌کند، فایل HTML را در آن ذخیره می‌نماید و منابع پیوندی را در زیرپوشهٔ `assets` ذخیره می‌کند. کنترلر تصویر، قلم، صدا، ویدئو و منابع CSS رایج را زمانی که Aspose.Slides پسوند فایل ایمنی ارائه می‌دهد یا می‌تواند استنتاج کند، پیوند می‌دهد. منابعی که شناسایی نمی‌شوند به‌صورت جاسازی‌مانده باقی می‌مانند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

پس از خروجی، پوشهٔ خروجی این ساختار را دارد:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

فایل‌های دقیق بسته به محتوای ارائه و گزینه‌های خروجی متفاوت هستند. به عنوان مثال، تصاویر raster معمولاً به‌صورت JPEG یا PNG صادر می‌شوند. Aspose.Slides ممکن است یک codec تصویر متفاوت نسبت به آنچه در ارائهٔ منبع استفاده شده است انتخاب کند، اگر این کار منجر به فایل کوچکتر یا مناسب‌تری شود. تصاویر دارای شفافیت به‌صورت PNG صادر می‌شوند.

## **انتخاب URLها برای استقرار**

نمونه از پیشوند URL نسبی `assets/` استفاده می‌کند. اگر `presentation.html` از `html-output/presentation.html` باز شود، مرورگر `html-output/assets/resource-1.svg` را بارگذاری می‌کند.

زمانی که یک منبع پیوندی به منبع پیوندی دیگر ارجاع می‌دهد، نمونه از پارامتر `referrer` در [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) استفاده می‌کند و فقط نام فایل را برمی‌گرداند. به عنوان مثال، اگر `resource-1.svg` و `resource-4.jpg` هر دو در پوشهٔ `assets` باشند، فایل SVG باید به `resource-4.jpg` ارجاع دهد، نه به `assets/resource-4.jpg`.

در صورتی که فایل‌ها در مکان دیگری مستقر شوند، پیشوند URL متفاوتی استفاده کنید:
- `assets/` را وقتی که پوشهٔ دارایی در کنار فایل HTML باشد استفاده کنید.
- `../assets/` را وقتی که پوشهٔ دارایی یک سطح بالاتر از فایل HTML باشد استفاده کنید.
- `https://cdn.example.com/presentations/job-123/assets/` را وقتی که فایل‌ها به یک CDN یا سرور فایل ایستا بارگذاری می‌شوند استفاده کنید.

آدرس URL که توسط [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) برگردانده می‌شود باید با مکان نهایی مستقر فایل نوشته‌شده توسط [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/) مطابقت داشته باشد. در برنامه‌های سرور، برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی آبجکت منحصر به فرد استفاده کنید تا از بازنویسی فایلهای خروجی دیگری جلوگیری شود.

## **چه زمانی به‌جای آن جاسازی کنیم**

HTML جاسازی‌شده به صورت Base64 همچنان وقتی مفید است که خروجی باید یک فایل واحد باشد، مانند پیوست ایمیل، پیش‌نمایش آفلاین، یا سندی که بدون پوشهٔ دارایی پشتیبان منتقل می‌شود. منابع پیوندی زمانی مناسب‌تر هستند که HTML توسط یک برنامه وب سرویس‌دهی شود، در CMS ذخیره شود، توسط یک خط لولهٔ ساخت بهینه‌سازی شود یا به صورت مستقل توسط مرورگرها کش شود.

## **سوالات متداول**

**آیا می‌توانم فقط تصاویر را خارج‌کرده و سایر منابع را جاسازی‌شده نگه دارم؟**

بله. در [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilinkembedcontroller/)، برای نوع محتواهایی که می‌خواهید به‌صورت فایل‌های جداگانه ذخیره شوند، `LinkEmbedDecision.Link` را برگردانید و برای بقیه موارد `LinkEmbedDecision.Embed` را برگردانید.

**چرا پسوند تصویر صادرشده با ارائهٔ منبع متفاوت است؟**

Aspose.Slides ممکن است در طول خروجی HTML تصاویر raster را دوباره رمزگذاری کند تا اندازه یا سازگاری با مرورگر بهبود یابد. برای مثال، یک تصویر از فایل منبع ممکن است بسته به نتیجهٔ رندر به صورت JPEG یا PNG نوشته شود.

**آیا URLهای نسبی پس از جابجایی فایل HTML کار می‌کنند؟**

URLهای نسبی فقط زمانی کار می‌کنند که ساختار پوشهٔ نسبی یکسان حفظ شود. اگر HTML به `assets/resource-1.png` ارجاع دهد، پوشهٔ `assets` باید در کنار فایل HTML بماند، مگر اینکه پیشوند URL متفاوتی تولید کنید.

**آیا برنامه‌های سرور باید از همان پوشهٔ خروجی استفاده کنند؟**

خیر. برای هر کار تبدیل یک پوشهٔ خروجی یا پیشوند ذخیره‌سازی منحصر به فرد استفاده کنید. این کار از تداخل نام فایل‌ها جلوگیری می‌کند و مانع از بازنویسی منابع تولید‌شده توسط یک خروجی دیگر می‌شود.