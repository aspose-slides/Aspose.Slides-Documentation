---
title: نمایش اسلایدهای ارائه به عنوان تصاویر SVG در جاوا
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
- گزینه‌های صادرات SVG
- SVG تعاملی
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint را به عنوان تصاویر SVG در جاوا صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل نمایید."
---
## **بررسی کلی**

SVG یک فرمت تصویری مقیاس‌پذیر بر پایه XML است که برای انتشار وب، نمایش اسلایدها، جریان‌های کاری دسترس‌پذیری و پردازش پس از تولید خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) زمانی استفاده کنید که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها باشد یا برای استفاده تعاملی آماده باشد.

## **صادر کردن اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت فایل SVG جداگانه صادر می‌کند.

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

The filename uses [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) به جای اندیس حلقه. همچنین می‌توانید یک شکل فردی را با [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) صادر کنید وقتی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) تعیین می‌کند آیا چرخش فریم اعمال شود یا نه. [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را به `true` تنظیم کنید وقتی متن باید بدون لیگچرها رندر شود.

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

هنگام صادر کردن اسلایدها به SVG، می‌توانید کنترل کنید که آیا متن به صورت متن باقی بماند یا به گرافیک‌های برداری تبدیل شود، و نحوه گنجاندن یا ارجاع به قلم‌های خارجی چگونه باشد. گزینه‌های زیر به شما کمک می‌کند تا تعادل بین سازگاری بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **بردارسازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را به `true` تنظیم کنید تا تمام متن اسلاید به عنوان گرافیک برداری نوشته شود. این وابستگی‌های قلم را حذف کرده و نتیجه بصری را در مرورگرها سازگارتر می‌کند، اما متن دیگر به عنوان متن SVG قابل انتخاب یا جستجو نیست.

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

### **انتخاب نحوه مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) از مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) برای قلم‌های بارگذاری‌شده به صورت خارجی استفاده می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه انتخاب کنید، `Embed` برای گنجاندن داده‌های قلم در SVG، یا `Vectorize` برای رندر کردن فقط متنی که از قلم‌های خارجی استفاده می‌کند به صورت گرافیک. قبل از گنجاندن قلم‌ها، مجوزهای قلم را بررسی کنید.

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

## **کاهش اندازه تصویر جاسازی‌شده**

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی‌شده استفاده کنید، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی برش داده‌شده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت رمزگذاری JPEG. این تنظیمات حجم فایل را به بهای کاهش کیفیت تصویر یا از دست رفتن داده‌های تصویر کاهش می‌دهند.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) حد پایین وضوح برای رستری‌سازی متافایل‌ها هنگام صادرات SVG را تنظیم می‌کند. از آن برای تعادل بین جزئیات و حجم فایل وقتی تصویری EMF یا WMF رستری می‌شود استفاده کنید. این تنظیم DPI سراسری برای SVG تعریف نمی‌کند و هر شیء را مجبور به تبدیل به تصویر رستری نمی‌سازد.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید که شامل تصویری EMF با خطوط قطری نزدیک به هم است. مثال زیر اولین اسلاید آن را در سه وضوح رستری‌سازی مختلف از طریق [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر می‌کند. تمام تنظیمات دیگر صادرات همان‌طور باقی می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ نمونه است؛ آن‌ها فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| DPI رستری‌سازی متافایل | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستری جاسازی‌شده را در اندازهٔ نمایش بزرگ شدهٔ یکسان نشان می‌دهد. خطوط قطری در DPI 72 پیکسل‌زدگی قابل ملاحظه‌ای دارند و در وضوح‌های بالاتر لبه‌های نرم‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌دهد یا هر تصویر صادر شده را تغییر نمی‌دهد.

![جزئیات بزرگ‌شدهٔ خط قطری در DPI 72، 150 و 300](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) کاهش وضوح تصویر را کنترل می‌کند و می‌تواند اثر تغییر وضوح رستری‌سازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقدار [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) بر روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. هر یک از کنترل‌کننده‌ها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید.

کنترل‌کنندهٔ زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) استفاده می‌کند که برای طول عمر شکل ثابت است، و یک شمارشگر قابل تکرار برای `tspan`های متن آن دارد. این باعث می‌شود شناسه‌های تولید شده برای پردازش پس از انتشار یک ارائهٔ بدون تغییر مناسب باشند.

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

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)، با مقدار [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) متد [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) را فراخوانی کنید تا هندلر رویداد جاوااسکریپت به شکل صادر شده اضافه شود. کنترل‌کننده را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید و تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع جاوااسکریپت ارجاع‌شده توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیر ساختن نمایشگرهای اسلاید، بهبودهای دسترس‌پذیری و سایر جریان‌های کاری تعاملی SVG را فراهم می‌آورد.

## **پرسش‌های متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند باید به گرافیک تبدیل شوند.

**بهترین روش برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش داده‌شده تصویر و انتخاب فایل‌های قلم پیوندی (در صورتی که محیط هدف توان ارائه آن‌ها را داشته باشد) شروع کنید. نتیجه را تست کنید زیرا کاهش وضوح تصویر، کیفیت پایین‌تر JPEG و بردارسازی متن، هر کدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادر شده را پس از خروجی اصلاح کنم؟**

بله. شناسه‌ها را از طریق یک کنترل‌کنندهٔ قالب‌بندی اختصاص دهید، سپس عناصر SVG متناظر را در ابزار پردازش پس از خروجی یا اسکریپت مرورگر خود انتخاب کنید.