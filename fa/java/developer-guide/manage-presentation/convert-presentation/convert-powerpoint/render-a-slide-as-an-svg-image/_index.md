---
title: نمایش اسلایدهای ارائه به صورت تصاویر SVG در جاوا
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/java/render-a-slide-as-an-svg-image/
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
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در جاوا صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک فرمت تصویری مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش‌گرهای اسلاید، گردش‌کارهای دسترس‌پذیری و پس‌پردازش خودکار بسیار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل چگونگی نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، قابل پیش‌بینی در مرورگرهای مختلف یا آماده استفادهٔ تعاملی باشد.

## **صادر کردن اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید را در یک ارائه به صورت یک فایل SVG جداگانه صادر می‌کند.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

نام فایل از [ISlide.getSlideNumber](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#getSlideNumber--) به جای اندیس حلقه استفاده می‌کند. همچنین می‌توانید یک شکل تک‌تکه را با [IShape.writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) صادر کنید وقتی یک نمایش‌گر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای قاب‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) قاب متن را در منطقهٔ رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) تعیین می‌کند که آیا چرخش قاب اعمال شود یا نه. وقتی متن باید بدون لیگچر رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را به `true` تنظیم کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **کنترل متن و قلم‌ها**

### **وکتوریزه‌سازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را به `true` تنظیم کنید تا تمام متن اسلاید به صورت گرافیک‌های برداری نوشته شود. این کار وابستگی به قلم‌ها را از بین می‌برد و نتیجهٔ بصری را در مرورگرهای مختلف یکدست‌تر می‌کند، اما متن دیگر به‌صورت متن SVG قابل انتخاب یا جستجو نیست.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **انتخاب نحوهٔ پردازش قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgexternalfontshandling/) استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه انتخاب کنید، `Embed` برای گنجاندن دادهٔ قلم در SVG، یا `Vectorize` برای رندر کردن فقط متنی که از قلم‌های خارجی استفاده می‌کند به‌صورت گرافیک. قبل از جاسازی قلم‌ها، مجوز قلم‌ها را بررسی کنید.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **کاهش حجم تصویر جاسازی شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی برش‌خوردهٔ منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با بهای کاهش کیفیت تصویر یا از دست رفتن داده‌های تصویر کاهش می‌دهند.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.setId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) بر روی عناصر `tspan` متنی نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از این کنترلرها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید.

کنترلر زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارندهٔ قابل تکرار برای `tspan`های متنی آن دارد. این باعث می‌شود شناسه‌های تولید شده برای پس‌پردازش ارائه‌ای که تغییر نکرده مناسب باشند.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **افزودن هندلرهای رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshapeformattingcontroller/)، با مقدار [SvgEvent](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgevent/) متد [ISvgShape.setEventHandler](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) را فراخوانی کنید تا یک هندلر رویداد JavaScript به یک شکل صادر شده اضافه شود. کنترلر را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان استفاده از نمایش‌گرهای اسلاید، بهبودهای دسترس‌پذیری و سایر گردش‌کارهای تعاملی SVG را فراهم می‌کند.

## **سؤالات متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/java/com.aspose.slides/svgexternalfontshandling/)؟**  
از [SVGOptions.setVectorizeText] استفاده کنید وقتی که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize] استفاده کنید وقتی فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**بهترین روش برای کوچک کردن یک SVG چیست؟**  
ابتدا با فشرده‌سازی تصاویر جاسازی شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی که محیط هدف قادر به ارائهٔ آنها باشد، شروع کنید. نتیجه را آزمایش کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و متن وکتوریزه شده هر کدام تعادلات متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم پس از صادر کردن عناصر SVG را تغییر دهم؟**  
بله. شناسه‌ها را از طریق یک کنترلر قالب‌بندی اختصاص دهید، سپس عناصر SVG مربوطه را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.