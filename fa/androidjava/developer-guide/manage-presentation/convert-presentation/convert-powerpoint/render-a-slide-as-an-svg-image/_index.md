---
title: "نمایش اسلایدهای ارائه به صورت تصاویر SVG در اندروید"
linktitle: "اسلاید به SVG"
type: docs
weight: 50
url: /fa/androidjava/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint به SVG"
- "ارائه به SVG"
- "اسلاید به SVG"
- "PPT به SVG"
- "PPTX به SVG"
- "گزینه‌های خروجی SVG"
- "SVG تعاملی"
- "PowerPoint"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در اندروید صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک قالب تصویر مبتنی بر XML و مقیاس‌پذیر است که برای انتشار وب، نمایشگرهای اسلاید، گردش‌کارهای دسترس‌پذیری و پردازش پس از تولید خودکار مناسب می‌باشد. Aspose.Slides برای Android از طریق Java هر اسلاید را به فایل SVG جداگانه‌ای صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصویرها و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرهای مختلف یا آماده استفاده تعاملی باشد.

## **صادرات اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بسازید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به فایل SVG جداگانه‌ای صادر می‌کند.

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

نام فایل با استفاده از [ISlide.getSlideNumber](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getSlideNumber--) به‌جای شاخص حلقه اعمال می‌شود. همچنین می‌توانید یک شکل تک‌تک را با [IShape.writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) صادر کنید زمانی که نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) مشخص می‌کند که آیا چرخش فریم اعمال شود یا نه. برای جلوگیری از ترکیب‌حروف قلم، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را روی `true` تنظیم کنید.

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

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را روی `true` تنظیم کنید تا تمام متن اسلاید به‌عنوان گرافیک‌های برداری نوشته شود. این کار وابستگی به قلم‌ها را حذف می‌کند و نتیجه بصری در مرورگرهای مختلف یکنواخت‌تر می‌شود، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نیست.

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

### **انتخاب نحوه‌ٔ مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. برای ارجاع به فایل‌های قلم جداگانه، [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/) را انتخاب کنید؛ برای گنجاندن داده‌های قلم در داخل SVG، [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/)؛ یا برای رندر متن استفاده‌کننده از قلم‌های خارجی به‌عنوان گرافیک، [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/) را برگزینید. قبل از گنجاندن قلم‌ها، مجوزهای استفاده از قلم را بررسی کنید.

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

## **کاهش اندازه تصویرهای جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی برش‌خورده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را با هزینهٔ کاهش وضوح تصویر یا داده‌های نگهداری‌شده کاهش می‌دهند.

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

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.setId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) روی عناصر `tspan` متنی نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از این کنترل‌کننده‌ها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) تخصیص دهید.

کنترل‌کنندهٔ زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) استفاده می‌کند که برای طول عمر شکل ثابت است و از یک شمارندهٔ تکرارپذیر برای `tspan`‌های متن استفاده می‌کند. این کار شناسه‌های تولیدشده را برای پردازش پس از تولید یک ارائهٔ بدون تغییر مناسب می‌سازد.

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

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)، با استفاده از [ISvgShape.setEventHandler](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) و مقدار [SvgEvent](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgevent/) یک هندلر JavaScript به شکل صادرشده اضافه کنید. کنترل‌کننده را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید و تابع JavaScript را در صفحه یا سند SVG میزبانی‌کننده تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع JavaScript مورد اشاره توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان نمایش اسلایدها، بهبود دسترس‌پذیری و سایر گردش‌کارهای تعاملی SVG را فراهم می‌آورد.

## **سؤال‌های متداول**

**چه موقع باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

زمانی که تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) استفاده کنید. هنگامی که فقط متن استفاده‌کننده از قلم‌های خارجی باید به گرافیک تبدیل شود، از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

ابتدا تصاویر جاسازی‌شده را فشرده کنید، نواحی برش‌خوردهٔ تصویر را حذف کنید و هنگام امکان از فایل‌های قلم لینک‌شده استفاده کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کاهش کیفیت JPEG و وکتوریزه‌سازی متن هرکدام تبادلات متفاوتی از نظر کیفیت و حجم دارند.

**آیا می‌توان پس از صادرات عناصر SVG را تغییر داد؟**

بله. با استفاده از یک کنترل‌کنندهٔ قالب‌بندی شناسه‌ها را اختصاص دهید، سپس عناصر SVG مربوطه را در ابزار پس‌پردازش یا اسکریپت مرورگر خود انتخاب کنید.