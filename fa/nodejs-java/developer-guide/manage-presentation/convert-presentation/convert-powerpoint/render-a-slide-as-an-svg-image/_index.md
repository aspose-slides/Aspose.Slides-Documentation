---
title: نمایش اسلایدهای ارائه به‌صورت تصاویر SVG در جاوااسکریپت
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint به SVG
- ارائه به SVG
- اسلاید به SVG
- PPT به SVG
- PPTX به SVG
- گزینه‌های خروجی SVG
- SVG تعاملی
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در جاوااسکریپت صادر کنید و با Aspose.Slides قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را کنترل کنید."
---
## **نمای کلی**

SVG یک قالب تصویر مبتنی بر XML و مقیاس‌پذیر است که برای انتشار وب، نمایش اسلاید، گردش‌کارهای دسترسی و پردازش پس از انتشار مناسب می‌باشد. Aspose.Slides برای Node.js از طریق Java هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان می‌دهد نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را کنترل کنید.

از [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) وقتی که SVG صادر شده باید فشرده، یکنواخت در مرورگرها یا آماده برای استفاده تعاملی باشد، استفاده کنید.

## **صادرات اسلاید به SVG**

یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) به یک جریان بنویسید. مثال زیر هر اسلاید در ارائه را به عنوان یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل فردی را با [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) صادر کنید زمانی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) فریم متنی را در ناحیه رندرینگ گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) تعیین می‌کند آیا چرخش فریم اعمال شود یا خیر. برای رندر متن بدون لیگاتورهای قلم، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) را به `true` تنظیم کنید.

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

در هنگام صادرات اسلایدها به SVG می‌توانید کنترل کنید که آیا متن به عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود و قلم‌های خارجی چگونه گنجانده یا مرجع شوند. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین سازگاری بصری، امکان انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **تبدیل تمام متن به بردار**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلایدها به گرافیک برداری نوشته شوند. این کار وابستگی به قلم‌ها را حذف کرده و نتیجه بصری را در مرورگرها یکنواخت‌تر می‌کند، اما متن دیگر به‌صورت متن SVG قابل انتخاب یا جستجو نیست.

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

### **انتخاب نحوه مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگیری می‌شوند استفاده می‌کند. `AddLinksToFontFiles` را انتخاب کنید تا به فایل‌های قلم جداگانه ارجاع داده شود، `Embed` برای گنجاندن داده‌های قلم در SVG و `Vectorize` برای رندر متن استفاده‌کننده از قلم‌های خارجی به عنوان گرافیک. قبل از گنجاندن قلم‌ها، مجوز استفاده از آن‌ها را بررسی کنید.

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

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) برای حذف نواحی برش‌خورده منبع و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با هزینه کاهش دقت تصویر یا حذف داده‌های تصویری کاهش می‌دهند.

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

## **کنترل وضوح رستری‌سازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) حد پایین وضوح رستری‌سازی متافایل‌ها را در زمان خروجی SVG مشخص می‌کند. از آن برای تعادل بین جزئیات و حجم فایل هنگامی که یک تصویر EMF یا WMF رستری می‌شود استفاده کنید. این مقدار DPI کلی برای SVG تعریف نمی‌کند و همهٔ اشیای اسلاید را به تصویر رستری تبدیل نمی‌کند.

[metafile-rasterization.pptx](metafile-rasterization.pptx) را بارگیری کنید؛ این پرونده شامل یک تصویر EMF با خطوط قطری به‌هم‌نزدیک دارد. مثال زیر اولین اسلاید آن را با سه وضوح رستری‌سازی مختلف از طریق [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) صادر می‌کند. سایر تنظیمات صادر کردن یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

| DPI رستری‌سازی متافایل | ابعاد PNG جاسازی‌شده | اندازه فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را در اندازهٔ نمایش بزرگ‌نمایی‌شده یکسان نشان می‌دهد. خطوط قطری در DPI 72 پیکسل‌گذاری قابل مشاهده دارند و در وضوح‌های بالاتر لبه‌های نرم‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش این مقدار لزوماً هر جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده‌ای را تغییر نمی‌دهد.

![جزئیات بزرگ‌نمایی خط مورب در DPIهای ۷۲، ۱۵۰ و ۳۰۰](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) وضوح تصویر را کاهش می‌دهد و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به اشکال و متن**

یک کنترل‌کننده قالب‌بندی را به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) پاس دهید تا برای هر شکل SVG، [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) را تنظیم کند. کنترلی که همچنین بازه‌های متن را مدیریت می‌کند می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) را بر روی عناصر `tspan` متن تنظیم کند.

کنترل‌کنندهٔ زیر از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارش‌گر قابل تکرار برای بازه‌های متنی آن دارد. این کار شناسه‌های تولیدی را برای پردازش پس از انتشار یک ارائهٔ تغییر نکرده مناسب می‌سازد.

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

## **افزودن هندلرهای رویداد SVG**

در یک کنترل‌کننده قالب‌بندی، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) یک هندلر رویداد JavaScript به یک شکل صادرشده اضافه کنید. کنترل‌کننده را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان استفاده از نمایشگرهای اسلاید، بهبودهای دسترسی و سایر گردش‌کارهای تعاملی SVG را فراهم می‌کند.

## **پرسش‌های متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متن استفاده‌کننده از قلم‌های خارجی باید به گرافیک تبدیل شود.

**بهترین راه برای کوچکتر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خورده تصویر و انتخاب فایل‌های قلم پیوندی که محیط هدف می‌تواند سرو کند، شروع کنید. نتیجه را آزمایش کنید زیرا وضوح پایین‌تر تصویر، کیفیت JPEG کم‌تر و متن بردارشده هر کدام تعادلی متفاوت بین کیفیت و حجم ارائه می‌دهند.

**آیا می‌توان پس از صادرات، عناصر SVG صادرشده را اصلاح کرد؟**

بله. شناسه‌ها را از طریق یک کنترل‌کننده قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پردازش پس از انتشار یا اسکریپت مرورگر خود انتخاب کنید.