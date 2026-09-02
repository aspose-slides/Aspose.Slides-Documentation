---
title: تبدیل اسلایدهای ارائه به تصاویر SVG در جاوااسکریپت
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- پاورپوینت به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های خروجی SVG
- SVG تعاملی
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "صادرات اسلایدهای پاورپوینت به عنوان تصاویر SVG در جاوااسکریپت و کنترل قلم‌ها، متن، تصویرها، شناسه‌ها و رویدادها با Aspose.Slides."
---
## **بررسی اجمالی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش‌کنندگان اسلاید، جریان‌های کاری دسترس‌پذیری و پردازش پس از تولید خودکار مناسب است. Aspose.Slides برای Node.js از طریق Java هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/) زمانی استفاده کنید که SVG صادر شده باید فشرده، در مرورگرهای مختلف پیش‌بینی‌پذیر یا آماده استفاده تعاملی باشد.

## **صادر کردن یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و با استفاده از [Slide.writeAsSvg](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/writeassvg/) آن را به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/getslidenumber/) به جای شاخص حلقه استفاده می‌کند. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) صادر کنید وقتی یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setuseframesize/) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. وقتی متن باید بدون لیگاتور رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) را روی `true` تنظیم کنید.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **کنترل متن و قلم‌ها**

### **وکتور کردن تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) را روی `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های برداری نوشته شود. این وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرهای مختلف سازگارتر می‌سازد، اما متن دیگر قابل انتخاب یا جستجو به عنوان متن SVG نخواهد بود.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **انتخاب نحوه‌ی پردازش قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgexternalfontshandling/) استفاده می‌کند. گزینه `AddLinksToFontFiles` را انتخاب کنید تا به فایل‌های قلم جداگانه ارجاع داده شود، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن تنها متنی که از قلم‌های خارجی استفاده می‌کند به صورت گرافیک. پیش از جاسازی قلم‌ها، مجوزهای قلم را تأیید کنید.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **کاهش اندازه تصویر جاسازی شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) برای حذف نواحی بریده‌شده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setjpegquality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات اندازه فایل را به هزینهٔ وفاداری تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **تخصیص شناسه‌های ثابت به شکل‌ها و متن**

یک کنترل‌کننده قالب‌بندی را به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) پاس دهید تا برای هر شکل SVG، [SvgShape.setId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgshape/setid/) را تنظیم کند. کنترل‌کننده‌ای که همچنین بازه‌های متن را مدیریت می‌کند می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgtspan/setid/) را بر روی عناصر `tspan` متن تنظیم کند.

کنترل‌کننده زیر از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارندهٔ تکرارپذیر برای بازه‌های متنی آن دارد. این باعث می‌شود شناسه‌های تولید شده برای پردازش بعدی یک ارائه بدون تغییر مناسب باشند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **افزودن مدیریت‌کننده‌های رویداد SVG**

در یک کنترل‌کننده قالب‌بندی، با یک مقدار [SvgEvent](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgevent/)، [SvgShape.setEventHandler](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgshape/seteventhandler/) را فراخوانی کنید تا یک مدیریت‌کنندهٔ رویداد JavaScript به یک شکل صادرشده اضافه شود. کنترل‌کننده را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط مدیریت‌کننده را تعریف کند. تخصیص شناسه‌ها و مدیریت‌کننده‌های رویداد امکان‌پذیر ساختن نمایشگرهای اسلاید، بهبودهای دسترس‌پذیری و سایر جریان‌های کاری تعاملی SVG را می‌دهد.

## **پرسش‌های متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متنی که از قلم‌های خارجی استفاده می‌کند به گرافیک تبدیل شود.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی تصویر بریده‌شده و انتخاب فایل‌های قلم پیوندی شروع کنید وقتی محیط هدف می‌تواند آن‌ها را سرو کند. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و متن وکتور شده هر کدام تبادلات متفاوتی بین کیفیت و اندازه دارند.

**آیا می‌توانم عناصر SVG صادرشده را پس از صادرات تغییر دهم؟**

بله. شناسه‌ها را از طریق یک کنترل‌کننده قالب‌بندی اختصاص دهید، سپس عناصر SVG متناظر را در ابزار پردازش پس از تولید یا اسکریپت مرورگر خود انتخاب کنید.