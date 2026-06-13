---
title: تبدیل PPT و PPTX به JPG در JavaScript
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به JPG
- ارائه به JPG
- اسلاید به JPG
- PPT به JPG
- PPTX به JPG
- ذخیره PowerPoint به صورت JPG
- ذخیره ارائه به صورت JPG
- ذخیره اسلاید به صورت JPG
- ذخیره PPT به صورت JPG
- ذخیره PPTX به صورت JPG
- خروجی PPT به JPG
- خروجی PPTX به JPG
- Node.js
- JavaScript
- Aspose.Slides
description: "اسلایدهای PowerPoint (PPT، PPTX) را به تصاویر JPG با کیفیت بالا در JavaScript با Aspose.Slides برای Node.js از طریق Java با استفاده از مثال‌های کد سریع و قابل اعتماد تبدیل کنید."
---
## **معرفی**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایندهٔ ارائهٔ خود و ایجاد یک تصویر کوچک برای هر اسلاید بسیار ساده می‌شود. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی شدن محافظت کنید یا ارائه را در حالت فقط‑خواندنی نمایش دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل PowerPoint PPT/PPTX به JPG**

در اینجا مراحل تبدیل PPT/PPTX به JPG آورده شده است:

1. یک نمونه از نوع [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
2. شیء اسلاید از نوع [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) را از مجموعهٔ [Presentation.getSlides()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getSlides--) دریافت کنید.
3. تصویر کوچک هر اسلاید را ایجاد و سپس به JPG تبدیل کنید. متد [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide#getImage-float-float-) برای دریافت تصویر کوچک اسلاید استفاده می‌شود و یک شیء [Imagess](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Images) را برمی‌گرداند. متد [getImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) باید از اسلاید مورد نیاز نوع [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) فراخوانی شود؛ مقادیر مقیاس تصویر کوچک در این متد منتقل می‌شوند.
4. پس از دریافت تصویر کوچک اسلاید، متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) را از شیء تصویر کوچک فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به این متد پاس کنید.

{{% alert color="primary" %}}
**Note**: تبدیل PPT/PPTX به JPG متفاوت از تبدیل به انواع دیگر در API Aspose.Slides است. برای انواع دیگر معمولاً از متد [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) استفاده می‌کنید، اما در اینجا باید از متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) استفاده کنید.
{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        var slideImage = sld.getImage(1.0, 1.0);
        // تصویر را به صورت JPEG در دیسک ذخیره می‌کند
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تبدیل PowerPoint PPT/PPTX به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصویر کوچک و تصویر JPG خروجی، می‌توانید مقادیر *ScaleX* و *ScaleY* را با انتقال آن‌ها به متدهای [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide#getImage-float-float-) تنظیم کنید:

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // ابعاد را تعریف می‌کند
    var desiredX = 1200;
    var desiredY = 800;
    // مقادیر مقیاس‌دار X و Y را دریافت می‌کند
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // تصویر را به صورت JPEG در دیسک ذخیره می‌کند
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **رندر نظرات هنگام ذخیرهٔ ارائه به تصویر**

Aspose.Slides برای Node.js از طریق Java یک قابلیت فراهم می‌کند که به شما امکان می‌دهد نظرات را در اسلایدهای یک ارائه هنگام تبدیل به تصاویر رندر کنید. این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}
Aspose یک برنامهٔ وب رایگان به نام [FREE Collage web app](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های تصویری](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.
{{% /alert %}}

## **مشاهدهٔ موارد مرتبط**

گزینه‌های دیگر برای تبدیل PPT/PPTX به تصویر را ببینید، مانند:

- [تبدیل PPT/PPTX به SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/).

## **سئوالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟**

بله، Aspose.Slides تمام محتوا از جمله SmartArt، نمودارها، جدول‌ها، شکل‌ها و غیره را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا ناقص.

**آیا محدودیتی برای تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟**

Aspose.Slides خود هیچ محدودیت سخت‌گیرانه‌ای برای تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای «عدم کافی بودن حافظه» مواجه شوید.