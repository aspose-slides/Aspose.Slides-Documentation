---
title: رندر اسلایدهای ارائه به‌صورت تصاویر SVG در اندروید
linktitle: اسلاید به SVG
type: docs
weight: 50
url: /fa/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در اندروید صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **نمای کلی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، مشاهده‌کننده‌های اسلاید، جریان‌های کاری دسترسی‌پذیری و پردازش پس از تولید خودکار مناسب است. Aspose.Slides for Android از طریق Java هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) استفاده کنید وقتی که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده برای استفاده تعاملی باشد.

## **صادر کردن اسلاید به‌صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به‌صورت یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) استفاده می‌کند نه از شاخص حلقه. همچنین می‌توانید یک شکل جداگانه را با [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) صادر کنید وقتی یک نمایش‌دهنده اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) رندرینگ SVG را کنترل می‌کند. برای قاب‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) قاب متن را در ناحیه رندر شامل می‌شود و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) تعیین می‌کند که آیا چرخش قاب اعمال شود یا نه. وقتی متن باید بدون لیگچرها رندر شود، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را روی `true` تنظیم کنید.

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

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به‌عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود، و نحوه گنجاندن یا ارجاع به قلم‌های خارجی چگونه باشد. گزینه‌های زیر به شما کمک می‌کنند تا بین سازگاری بصری، انتخاب متن و وابستگی‌های قلم در SVG صادر شده تعادل برقرار کنید.

### **برداری‌سازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را روی `true` تنظیم کنید تا تمام متن اسلاید به‌صورت گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را حذف می‌کند و نتیجه بصری را در مرورگرها یک‌دست‌تر می‌سازد، اما متن دیگر به‌عنوان متن SVG قابل انتخاب یا جستجو نخواهد بود.

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

### **نحوهٔ مدیریت قلم‌های خارجی را انتخاب کنید**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند استفاده می‌کند. برای ارجاع به فایل‌های قلم جداگانه، [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را انتخاب کنید، برای گنجاندن داده‌های قلم در SVG، [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را انتخاب کنید، یا برای رندر کردن فقط متنی که از قلم‌های خارجی استفاده می‌کند به‌صورت گرافیک، [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را برگزینید. قبل از جاسازی قلم‌ها، مجوزهای قلم را بررسی کنید.

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

## **کاهش اندازه تصویر جاسازی شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی شده استفاده کنید، از [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی بریده‌شده منبع استفاده کنید و از [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت رمزگذاری JPEG بهره ببرید. این تنظیمات اندازه فایل را با هزینه‌ای در وفاداری تصویر یا داده‌های نگه‌داشته شده تصویر کاهش می‌دهند.

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

## **کنترل وضوح رستری‌سازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) حد پایین وضوح را برای رستری‌سازی متافایل‌ها در زمان صادرات SVG تعیین می‌کند. از آن برای تعادل بین جزئیات و اندازه فایل وقتی یک تصویر EMF یا WMF رستری می‌شود استفاده کنید. این تنظیم DPI کلی برای SVG را تعریف نمی‌کند و همهٔ اشیاء اسلاید را مجبور به تبدیل به تصویر رستری نمی‌کند.

[metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید، که حاوی یک تصویر EMF با خطوط قطری به‌صورت نزدیک است. مثال زیر اولین اسلاید آن را در سه وضوح رستری‌سازی مختلف با استفاده از [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر می‌کند. تمام تنظیمات صادرات دیگر یکسان باقی می‌مانند تا نتایج قابل مقایسه باشند.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه‌شده است؛ آن‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستری‌سازی متافایل DPI | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در 72 DPI پیکسل‌زدگی قابل مشاهده دارند و در وضوح‌های بالاتر لبه‌های نرم‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً هر جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) کاهش وضوح تصویر را کنترل می‌کند و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را پنهان کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **تخصیص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) بر روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از کنترل‌کننده‌ها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید.

کنترل‌کنندهٔ زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) استفاده می‌کند که در طول عمر شکل ثابت است و یک شمارندهٔ تکرارپذیر برای قسمت‌های متنی آن دارد. این کار شناسه‌های تولید‌شده را برای پردازش پس از ارائهٔ بدون تغییر مناسب می‌سازد.

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

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)، با مقدار [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/)، متد [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) را صدا بزنید تا یک هندلر رویداد JavaScript به یک شکل صادرشده اضافه کنید. کنترل‌کننده را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص داده و تابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبان می‌تواند تابع JavaScript ارجاع‌شده توسط هندلر را تعریف کند. تخصیص شناسه‌ها و هندلرهای رویداد امکاناتی برای نمایش‌دهندگان اسلاید، بهبود دسترسی و سایر جریان‌های کاری SVG تعاملی فراهم می‌کند.

## **FAQ**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) استفاده کنید وقتی که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنید وقتی که فقط متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود.

**به‌ترین روش برای کوچک کردن SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی بریده‌شده تصویر و انتخاب لینک به فایل‌های قلم وقتی محیط هدف می‌تواند آن‌ها را سرو کند، شروع کنید. نتیجه را آزمایش کنید چون کاهش وضوح تصویر، کیفیت JPEG پایین‌تر و برداری‌سازی متن هر کدام تبادل‌های متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم پس از صادر کردن، عناصر SVG را اصلاح کنم؟**

بله. شناسه‌ها را از طریق یک کنترل‌کنندهٔ قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پردازش پس از خروج یا اسکریپت مرورگر خود انتخاب کنید.