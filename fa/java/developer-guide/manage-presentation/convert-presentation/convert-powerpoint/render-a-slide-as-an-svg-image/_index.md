---
title: رندر اسلایدهای ارائه به‌صورت تصاویر SVG در جاوا
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
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌صورت تصاویر SVG در جاوا صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **بررسی کلی**

SVG یک فرمت تصویر مقیاس‌پذیر مبتنی بر XML است که برای انتشار وب، نمایش اسلایدها، جریان‌های کاری دسترس‌پذیری و پردازش پس‌زمینه خودکار مناسب است. Aspose.Slides هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) استفاده کنید زمانی که SVG خروجی باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده برای استفاده تعاملی باشد.

## **صادرات یک اسلاید به عنوان SVG**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت یک فایل SVG جداگانه صادر می‌کند.

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

نام فایل از [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) استفاده می‌کند نه از شاخص حلقه. همچنین می‌توانید یک شکل منفرد را با [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) زمانی که یک نمایشگر اسلاید یا صفحه وب فقط به آن شکل نیاز دارد، صادر کنید.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) فریم متن را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) تعیین می‌کند که آیا چرخش فریم اعمال شود یا نه. برای رندر متن بدون لیگاتورها، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را به `true` تنظیم کنید.

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

## **کنترل برش انتهای خط در سرهای پیکان**

SVG 1.1 تنظیمات داخلی مارکر برای تعیین نقطه توقف خط زیر سر پیکان ندارد. به طور پیش‌فرض، Aspose.Slides خط صادرشده را کوتاه می‌کند تا خط کشیده شده از مارکر بیرون نیاید. با فراخوانی [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) و مقدار `true`، خط کشیده تا نقطه انتهای اصلی خود ادامه پیدا می‌کند. این تنظیم تنها بر خروجی SVG اثر می‌گذارد؛ موقعیت و طول خط در اسلاید ثابت می‌ماند.

مثال سرهای پیکان مثلثی و الماسی را بر روی خطوط ۲ و ۱۰ نقطه‌ای رسم می‌کند. همان اسلاید دو بار صادر می‌شود و فقط گزینه برش تغییر می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

مقایسه نشان می‌دهد سر پیکان مثلثی روی خط ۱۰ نقطه‌ای. با فعال‌سازی برش، نوک تیز است. با غیرفعال‌سازی برش، خط کشیده از سمت‌های شیب‌دار مارکر عبور می‌کند و انتهایی صاف می‌ماند.

![مثلث ۱۰‑نقطه‌ای بزرگ‌شده با نوک تیز هنگام فعال بودن برش و انتهای صاف هنگام غیرفعال بودن برش](line-end-cropping.png)

در خطوط دیگر مثال، خط کشیده در مثلث ۲‑نقطه‌ای کمتر قابل مشاهده است. الماس پر شده انتهای خط کشیده را در هر دو عرض پوشش می‌دهد.

## **کنترل متن و قلم‌ها**

هنگام صادرات اسلایدها به SVG می‌توانید تعیین کنید که متن به عنوان متن باقی بماند یا به گرافیک برداری تبدیل شود و قلم‌های خارجی چگونه شامل یا ارجاع شوند. گزینه‌های زیر به شما کمک می‌کنند تعادل بین سازگاری بصری، انتخاب متن و وابستگی‌های قلم در SVG صادرشده را پیدا کنید.

### **وکتوریزه کردن تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را به `true` تنظیم کنید تا تمام متن اسلایدها به گرافیک برداری نوشته شوند. این کار وابستگی‌های قلم را از بین می‌برد و نتیجه بصری را در مرورگرها یکدست‌تر می‌کند، اما متن دیگر به عنوان متن SVG قابل انتخاب یا جستجو نیست.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) با مقدار [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) برای قلم‌هایی که به صورت خارجی بارگذاری می‌شوند، رفتار می‌کند. `AddLinksToFontFiles` را برای ارجاع به فایل‌های قلم جداگانه، `Embed` را برای گنجاندن داده‌های قلم در SVG یا `Vectorize` را برای رندر فقط متن‌هایی که از قلم‌های خارجی استفاده می‌کنند به گرافیک انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوز استفاده از آن‌ها را بررسی کنید.

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

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی برش‌خورده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت کدگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را به هزینهٔ وفاداری تصویر یا داده‌های تصویر حفظ‌شده کاهش می‌دهند.

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

## **کنترل وضوح رسترسازی متافایل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) حد پایین رزولوشن رسترسازی متافایل‌ها را هنگام صادرات SVG تعیین می‌کند. از آن برای تعادل جزئیات و حجم فایل هنگام رسترسازی تصویر EMF یا WMF استفاده کنید. این مقدار DPI کلی برای SVG را تعیین نمی‌کند و همهٔ اشیای اسلاید را به تصویر رستر تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل شامل یک تصویر EMF با خطوط قطری نزدیک به هم است. مثال زیر اسلاید اول آن را در سه وضوح رسترسازی مختلف از طریق [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر می‌کند. تمام تنظیمات دیگر صادرات یکسان می‌مانند تا نتایج قابل مقایسه باشند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ موجود است؛ اینها فرمول عمومی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رسترسازی متافایل DPI | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را در همان اندازهٔ نمایش بزرگ‌شده نشان می‌دهد. خطوط قطری در ۷۲ DPI پیکسل‌گذاری قابل مشاهده دارند و در وضوح‌های بالاتر لبه‌های صاف‌تری دارند، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهبود نمی‌بخشد یا هر تصویر صادرشده‌ای را تغییر نمی‌دهد.

![جزئیات خط قطری بزرگ‌شده در ۷۲، ۱۵۰ و ۳۰۰ DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) کنترل کاهش وضوح تصویر را بر عهده دارد و می‌تواند اثر تغییر وضوح رسترسازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) کیفیت کدگذاری JPEG را کنترل می‌کند، نه وضوح رسترسازی متافایل.

## **اختصاص شناسه‌های ثابت به شکل‌ها و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) بر روی عناصر `tspan` متن نیز، [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/) را پیاده‌سازی کنید. یکی از این کنترلرها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید.

کنترلر زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) که برای طول عمر شکل ثابت است و یک شمارندهٔ قابل تکرار برای spanهای متنی استفاده می‌کند، بهره می‌برد. این کار شناسه‌های تولیدشده را برای پردازش پس از تغییر، در ارائه‌ای که تغییر نیافته است، مناسب می‌سازد.

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

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/)، با [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) و مقدار [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/) یک هندلر جاوااسکریپت به یک شکل صادرشده اضافه کنید. کنترلر را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید و تابع جاوااسکریپت را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحه میزبانی می‌تواند تابع جاوااسکریپت مرجع توسط هندلر را تعریف کند. اختصاص شناسه‌ها و هندلرهای رویداد امکان‌پذیر شدن نمایش‌گرهای اسلاید، بهبودهای دسترس‌پذیری و سایر جریان‌های کاری تعاملی SVG را فراهم می‌آورد.

## **FAQ**

**کی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) زمانی استفاده کنید که تمام متن باید مستقل از قلم‌ها باشد. از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) زمانی استفاده کنید که فقط متنی که از قلم‌های خارجی استفاده می‌کند به گرافیک تبدیل شود.

**بهترین روش برای کوچک کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی زمانی که محیط هدف می‌تواند آن‌ها را سرو کند، شروع کنید. نتیجه را آزمایش کنید زیرا رزولوشن پایین‌تر تصویر، کیفیت JPEG پایین‌تر و متن وکتوریزه‌شده هر کدام تعادل متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توانم عناصر SVG صادرشده را پس از صادرات تغییر دهم؟**

بله. شناسه‌ها را از طریق یک کنترلر قالب‌بندی اختصاص دهید، سپس عناصر SVG соответствی را در ابزار پردازش پس از صادرات یا اسکریپت مرورگر خود انتخاب کنید.