---
title: نمایش اسلایدهای ارائه به صورت تصاویر SVG در اندروید
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
- گزینه‌های صادرات SVG
- SVG تعاملی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint را به‌عنوان تصاویر SVG در اندروید صادر کنید و قلم‌ها، متن، تصاویر، شناسه‌ها و رویدادها را با Aspose.Slides کنترل کنید."
---
## **مروری کلی**

SVG یک قالب تصویر مبتنی بر XML مقیاس‌پذیر است که برای انتشار وب، نمایش اسلایدها، جریان‌های کاری دسترس‌پذیری و پردازش پس‌انتشار خودکار مناسب می‌باشد. Aspose.Slides for Android via Java هر اسلاید را به یک فایل SVG جداگانه صادر می‌کند و به شما امکان کنترل نحوه نوشتن متن، قلم‌ها، تصاویر و عناصر SVG را می‌دهد.

از [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) زمانی استفاده کنید که SVG صادر شده باید فشرده، پیش‌بینی‌پذیر در مرورگرها یا آماده برای استفاده تعاملی باشد.

## **صدور یک اسلاید به صورت SVG**

یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید، اسلایدی را انتخاب کنید و آن را با [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) به یک جریان بنویسید. مثال زیر هر اسلاید در یک ارائه را به صورت فایل SVG جداگانه صادر می‌کند.

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

نام فایل با استفاده از [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) به‌جای شاخص حلقه تعیین می‌شود. همچنین می‌توانید یک شکل منفرد را با [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) صادر کنید زمانی که نمایشگر اسلاید یا صفحه وب تنها به همان شکل نیاز دارد.

## **پیکربندی خروجی SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) رندر SVG را کنترل می‌کند. برای فریم‌های متنی، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) فریم متنی را در ناحیه رندر گنجانده و [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) تعیین می‌کند آیا چرخش فریم اعمال شود یا خیر. برای رندر متن بدون لیگاتورها، [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) را به `true` تنظیم کنید.

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

SVG 1.1 تنظیمی برای درج علامت‌زن (marker inset) ندارد تا مشخص کند خط باید زیر سر پیکان تا کجا ادامه یابد. به‌صورت پیش‌فرض، Aspose.Slides طول خط صادر شده را کوتاه می‌کند تا خط کش (stroke) از علامت‌زن سر کشیده نشود. با فراخوانی [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) و مقدار `true`، خط کش را تا نقطه انتهایی اصلی خط رسم می‌کنید. این تنظیم فقط بر خروجی SVG تأثیر دارد؛ موقعیت و طول خط در اسلاید دست نخورده باقی می‌ماند.

مثال سرهای پیکان مثلثی و الماس‌دار را بر خطوط ۲ و ۱۰ نقطه‌ای رسم می‌کند. همان اسلاید دو بار صادر می‌شود؛ تنها گزینه برش تغییر می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

مقایسه نشان می‌دهد سر پیکان مثلثی بر خط ۱۰‑نقطه‌ای. با فعال بودن برش، نوک تیز است. با غیرفعال بودن برش، خط کش از طرف‌های شیب‌دار علامت‌زن عبور می‌کند و انتهایی مسطح می‌شود.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

در سایر خطوط مثال، خط کش برجسته کمتر بر روی مثلث ۲‑نقطه‌ای دیده می‌شود. الماس پر شده انتهای خط کش را در هر دو عرض می‌پوشاند.

## **کنترل متن و قلم‌ها**

هنگام صادر کردن اسلایدها به SVG می‌توانید تصمیم بگیرید متن به‌صورت متن باقی بماند یا به گرافیک برداری تبدیل شود و قلم‌های خارجی چگونه گنجانده یا ارجاع داده شوند. گزینه‌های زیر به شما کمک می‌کند تعادل بین ثبات بصری، قابلیت انتخاب متن و وابستگی‌های قلم در SVG صادر شده را برقرار کنید.

### **بردارسازی تمام متن**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) را به `true` تنظیم کنید تا تمام متن اسلاید به‌صورت گرافیک برداری نوشته شود. این کار وابستگی‌های قلم را از بین می‌برد و نتیجه بصری را در مرورگرها یکنواخت‌تر می‌کند، اما متن دیگر قابل انتخاب یا جست‌وجو به‌عنوان متن SVG نخواهد بود.

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

### **انتخاب نحوه‌ی مدیریت قلم‌های خارجی**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) یک مقدار از نوع [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را برای قلم‌هایی که به‌صورت خارجی بارگذاری می‌شوند، استفاده می‌کند. برای ارجاع به فایل‌های قلم جداگانه، [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را انتخاب کنید؛ برای گنجاندن داده‌های قلم در SVG، [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)؛ یا برای رندر کردن متن‌های استفاده‌کننده از قلم‌های خارجی به‌صورت گرافیک، [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) را انتخاب کنید. قبل از گنجاندن قلم‌ها، مجوزهای استفاده را بررسی کنید.

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

از [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) برای کاهش وضوح تصاویر جاسازی‌شده، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) برای حذف نواحی برش‌خورده منبع، و [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) برای کنترل کیفیت رمزگذاری JPEG استفاده کنید. این تنظیمات حجم فایل را به قیمت کاهش وضوح تصویر یا حذف داده‌های تصویری کاهش می‌دهند.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) حد پایین‌تری برای وضوح رستری‌سازی متافایل‌ها هنگام صادرات SVG تعیین می‌کند. از آن برای توازن جزئیات و حجم فایل هنگام رستری‌سازی تصویر EMF یا WMF استفاده کنید. این تنظیم یک DPI کلی برای کل SVG تعریف نمی‌کند و تمام اشیای اسلاید را به تصویر رستری تبدیل نمی‌کند.

فایل [metafile-rasterization.pptx](metafile-rasterization.pptx) را دانلود کنید؛ این فایل حاوی تصویری EMF با خطوط مورب نزدیک به هم است. مثال زیر اولین اسلاید آن را با سه وضوح رستری‌سازی مختلف از طریق [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) صادر می‌کند. سایر تنظیمات صادرات ثابت می‌مانند تا نتایج مقایسه شوند.

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

در خروجی، EMF به یک PNG جاسازی‌شده در هر SVG تبدیل شد. اندازه‌گیری‌های زیر برای ارائهٔ ارائه شده‌اند؛ فرمول کلی برای تبدیل DPI به ابعاد پیکسل نیستند.

| وضوح رستری‌سازی متافایل (DPI) | ابعاد PNG جاسازی‌شده | حجم فایل SVG (بایت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

مقایسهٔ زیر همان ناحیهٔ رستر جاسازی‌شده را با همان اندازه نمایش بزرگ‌نمایی شده نشان می‌دهد. خطوط مورب در ۷۲ DPI پیکسل‌گذاری قابل مشاهده دارد و در وضوح‌های بالاتر لبه‌های نرم‌تری دارد، در حالی که حجم فایل SVG افزایش می‌یابد. افزایش مقدار لزوماً تمام جزئیات را بهتر نمی‌کند و همهٔ تصاویر صادر شده را تغییر نمی‌دهد.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) کنترل کاهش وضوح تصویر را دارد و می‌تواند تأثیر تغییر وضوح رستری‌سازی متافایل را مخفی کند. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) کیفیت رمزگذاری JPEG را کنترل می‌کند، نه وضوح رستری‌سازی متافایل.

## **اختصاص شناسه‌های ثابت به اشکال و متن**

از [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) برای تنظیم [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) برای هر شکل SVG استفاده کنید. برای تنظیم مقادیر [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) روی عناصر `tspan` متنی نیز، پیاده‌سازی [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/) را در نظر بگیرید. هر یک از این کنترلرها را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید.

کنترلر زیر از [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) استفاده می‌کند که برای طول عمر شکل ثابت است و یک شمارندهٔ قابل تکرار برای `tspan`های متن آن دارد. این کار شناسه‌های تولید شده را برای پردازش پس از انتشار ارائهٔ بدون تغییر مناسب می‌سازد.

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

## **افزودن پردازنده‌های رویداد SVG**

در یک [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)، با [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) و مقدار یک [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) یک پردازندهٔ JavaScript به شکل صادر شده اضافه کنید. کنترلر را با [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) اختصاص دهید و توابع JavaScript را در صفحه یا سند SVG که نتیجه را میزبانی می‌کند، تعریف کنید.

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

صفحهٔ میزبانی می‌تواند تابع JavaScript مورد ارجاع توسط پردازنده را تعریف کند. اختصاص شناسه‌ها و پردازنده‌های رویداد امکان‌پذیر ساختن نمایش اسلایدها، بهبود دسترس‌پذیری و سایر جریان‌های کاری تعاملی SVG می‌شود.

## **پرسش‌های متداول**

**چه زمانی باید از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) به‌جای [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنم؟**

وقتی تمام متن باید مستقل از قلم‌ها باشد، از [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) استفاده کنید. وقتی تنها متنی که از قلم‌های خارجی استفاده می‌کند باید به گرافیک تبدیل شود، از [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) استفاده کنید.

**بهترین راه برای کوچک‌تر کردن یک SVG چیست؟**

با فشرده‌سازی تصاویر جاسازی‌شده، حذف نواحی برش‌خوردهٔ تصویر و انتخاب فایل‌های قلم پیوندی (در صورتی که محیط هدف قادر به سرو آن‌ها باشد) شروع کنید. نتیجه را تست کنید چون کاهش وضوح تصویر، کاهش کیفیت JPEG و بردارسازی متن هر کدام تبادل‌های متفاوتی بین کیفیت و حجم دارند.

**آیا می‌توان پس از صادرات عناصر SVG را تغییر داد؟**

بله. شناسه‌ها را از طریق یک کنترلر قالب‌بندی اختصاص دهید، سپس عناصر SVG مطابق را در ابزار پردازش پس از انتشار یا اسکریپت مرورگر خود انتخاب کنید.