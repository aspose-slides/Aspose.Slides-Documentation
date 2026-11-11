---
title: رندر اسلایدهای ارائه به عنوان تصاویر SVG در جاوااسکریپت
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
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در جاوااسکریپت صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **مرور کلی**

SVG یک قالب تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلاید، گردش کار دسترس‌پذیری و پردازش پس‌تولید مناسب است. Aspose.Slides for Node.js via Java هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) زمانی استفاده کنید که SVG صادرشده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده‌ی استفاده تعاملی باشد.

## **صادر کردن یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید، یک اسلاید را انتخاب کنید و آن را با [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) استفاده می‌کند نه از اندیس حلقه. همچنین می‌توانید یک شکل منفرد را با [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) صادر کنید وقتی یک نمایش‌گر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متن، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. هنگام نیاز به رندر متن بدون لیگاتورها، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) را به `true` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرهای فلش**

SVG 1.1 تنظیمی برای جداسازی نشانگر برای مشخص کردن مکانی که یک خط باید زیر سر فلش توقف کند، ندارد. به طور پیش‌فرض، Aspose.Slides خط صادرشده را کوتاه می‌کند تا خطوط آن از نشانگر بیرون نزند. با فراخوانی [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) و مقدار `true`، خط تا نقطه انتهایی اصلی خود رسم می‌شود. این تنظیم فقط بر خروجی SVG تأثیر دارد. خط موقعیت و طول خود را در اسلاید حفظ می‌کند.

مثال سرهای فلش مثلثی و الماس‌形 را روی خطوط ۲ و ۱۰ پوینت‌عرض رسم می‌کند. همان اسلاید دو بار صادر می‌شود و فقط گزینهٔ برش تغییر می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

مقایسه نشان می‌دهد سر فلش مثلثی روی خط ۱۰‑پوینت. هنگام فعال بودن برش، نوک تیز است. وقتی برش غیرفعال باشد، خط از سمت‌های شیب‌دار نشانگر بیرون زده و انتهای صاف می‌شود.

![مثلث بزرگ‌نمایی‌شدهٔ ۱۰‑پوینت با نوک تیز زمانی که برش فعال باشد و انتهای صاف زمانی که برش غیرفعال باشد](line-end-cropping.png)

در سایر خطوط مثال، خط بیرون‌زن کمتر بر روی مثلث ۲‑پوینت مشهود است. الماس پر هر دو عرض را پوشش می‌دهد.

## **کنترل متن و قلم‌ها**

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به صورت متن باقی بماند یا به گرافیک برداری تبدیل شود و قلم‌های خارجی چگونه شامل یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کنند تا تعادل بین هماهنگی بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادرشده را برقرار کنید.

### **برداری تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) را به `true` تنظیم کنید تا تمام متن اسلاید به گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را از بین می‌برد و نتیجهٔ بصری را در مرورگرها یکنواخت‌تر می‌کند، اما متن دیگر قابل انتخاب یا جستجو به‌عنوان متن SVG نخواهد بود.

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

### **نحوهٔ پردازش قلم‌های خارجی را انتخاب کنید**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) برای قلم‌های بارگذاری‌شده به صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را انتخاب کنید تا به فایل‌های قلم جداگانه ارجاع داده شود، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن تنها متنی که از قلم‌های خارجی استفاده می‌کند به‌صورت گرافیک. قبل از جاسازی قلم‌ها، مجوز استفاده را بررسی کنید.

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

## **کاهش اندازهٔ تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) برای حذف نواحی برش⁧‌ی تصویر منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را به هزینهٔ دقت تصویر یا داده‌های تصویر نگهداری‌شده کاهش می‌دهند.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) حد پایین‌تری برای وضوح رستری‌سازی متافایل‌ها در زمان خروجی SVG تعیین می‌کند. از آن برای تعادل جزئیات و حجم فایل وقتی یک تصویر EMF یا WMF رستری می‌شود، استفاده کنید. این تنظیم یک DPI سراسری برای SVG تعریف نمی‌کند و تمام اشیاء اسلاید را مجبور به تبدیل به تصویر رستری نمی‌کند.

[metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط مورب نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستری‌سازی مختلف از طریق [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) صادر می‌کند. تمام تنظیمات دیگر خروجی یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ این‌ها فرمول عمومی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستری‌سازی متافایل DPI | ابعاد PNG جاسازی‌شده | اندازهٔ فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را با همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط مورب در 72 DPI پیکسل‌دار واضح است و در وضوح‌های بالاتر لبه‌های نرم‌تری دارد، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده را تغییر نمی‌دهد.

![جزئیات بزرگ‌نمایی‌شدهٔ خط مورب در 72، 150 و 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را پنهان کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به اشکال و متن**

یک کنترلر قالب‌بندی را به [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) پاس دهید تا برای هر شکل SVG [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) تنظیم شود. یک کنترلر که همچنین spanهای متن را مدیریت می‌کند می‌تواند مقادیر [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) را بر روی عناصر `tspan` متن تنظیم کند.

کنترلری که در ادامه آمده از [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) استفاده می‌کند، که برای طول عمر شکل ثابت است، و از یک شمارندهٔ تکرارپذیر برای spanهای متن استفاده می‌کند. این کار شناسه‌های تولیدشده را برای پردازش پس از ارائه‌ای که تغییر نکرده مناسب می‌سازد.

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

## **اضافه کردن هندلرهای رویداد SVG**

در یک کنترلر قالب‌بندی، با [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) و مقدار [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) یک هندلر رویداد JavaScript را به یک شکل صادرشده اضافه کنید. کنترلر را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیری نمایش‌گرهای اسلاید، بهبودهای دسترس‌پذیری و سایر گردش کارهای تعاملی SVG را فراهم می‌کند.

## **سوالات متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

وقتی تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) استفاده کنید. وقتی فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند، از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) استفاده کنید.

**بهترین روش برای کوچک کردن SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خورده تصویر و انتخاب فایل‌های قلم لینک‌شده (زمانی که محیط هدف می‌تواند آن‌ها را سرو کند) شروع کنید. نتایج را آزمایش کنید؛ چون کاهش وضوح تصویر، کاهش کیفیت JPEG و برداری کردن متن هرکدام تعادل متفاوتی بین کیفیت و حجم ایجاد می‌کنند.

**آیا می‌توانم عناصر SVG صادرشده را پس از خروجی‌گیری اصلاح کنم؟**

بله. با استفاده از یک کنترلر قالب‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پردازش پس از خروجی یا اسکریپت مرورگر خود انتخاب کنید.