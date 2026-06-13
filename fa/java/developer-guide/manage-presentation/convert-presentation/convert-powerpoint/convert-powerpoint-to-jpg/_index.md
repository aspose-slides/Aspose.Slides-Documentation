---
title: تبدیل PPT و PPTX به JPG در جاوا
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/java/convert-powerpoint-to-jpg/
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
- ذخیره PowerPoint به عنوان JPG
- ذخیره ارائه به عنوان JPG
- ذخیره اسلاید به عنوان JPG
- ذخیره PPT به عنوان JPG
- ذخیره PPTX به عنوان JPG
- صادرات PPT به JPG
- صادرات PPTX به JPG
- جاوا
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT، PPTX) به تصاویر JPG با کیفیت بالا در جاوا با Aspose.Slides برای جاوا با استفاده از مثال‌های کد سریع و قابل اعتماد."
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و درج محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر شخصی ارائه و ایجاد تصویر بند انگشتی برای هر اسلاید آسان است. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی شدن محافظت کنید یا ارائه را در حالت فقط‑خواندنی نمایش دهید. Aspose.Slides به شما اجازه می‌دهد تا کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل PowerPoint PPT/PPTX به JPG**

1. یک نمونه از نوع [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. شی اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) را از مجموعه [Presentation.getSlides()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) دریافت کنید.  
3. تصویر بند انگشتی هر اسلاید را ایجاد کرده و سپس به JPG تبدیل کنید. متد [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-float-float-) برای دریافت تصویر بند انگشتی یک اسلاید استفاده می‌شود و یک شیٔ [Images](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Images) را برمی‌گرداند. متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) باید از اسلاید مورد نیاز از نوع [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) فراخوانی شود و مقیاس‌های تصویر بند انگشتی حاصل به متد پاس داده می‌شوند.  
4. پس از دریافت تصویر بند انگشتی اسلاید، متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) را از شیٔ تصویر بند انگشتی فراخوانی کنید. نام فایل حاصل و فرمت تصویر را به آن پاس دهید.  

{{% alert color="primary" %}}
**Note**: تبدیل PPT/PPTX به JPG با تبدیل به انواع دیگر در API Aspose.Slides متفاوت است. برای انواع دیگر معمولاً از متد [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) استفاده می‌کنید، اما در اینجا به متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) نیاز دارید.
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        IImage slideImage = sld.getImage(1f, 1f);

        // تصویر را به فرمت JPEG در دیسک ذخیره می‌کند
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تبدیل PowerPoint PPT/PPTX به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصویر بند انگشتی و تصویر JPG حاصل، می‌توانید مقادیر *ScaleX* و *ScaleY* را با پاس کردن آنها به متدهای [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-float-float-) تنظیم کنید:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // تعریف ابعاد
    int desiredX = 1200;
    int desiredY = 800;
    // دریافت مقادیر مقیاس‌دار X و Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // تصویر را به فرمت JPEG در دیسک ذخیره می‌کند
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **رندر نظرات هنگام ذخیره اسلایدها به‌صورت تصویر**

Aspose.Slides for Java امکاناتی را فراهم می‌کند که به شما اجازه می‌دهد نظرات موجود در اسلایدهای ارائه را هنگام تبدیل این اسلایدها به تصاویر رندر کنید. این کد Java این عملیات را نشان می‌دهد:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose یک [برنامه وب FREE Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ادغام کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از همان اصول توضیح داده‌شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر این صفحات را مشاهده کنید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).
{{% /alert %}}

## **سوالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و سایر اشیاء پیچیده پشتیبانی می‌کند؟**

بله، Aspose.Slides تمامی محتوا، از جمله SmartArt، نمودارها، جداول، شکل‌ها و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا مفقود شده.

**آیا محدودیتی در تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟**

Aspose.Slides خود محدودیت سخت‌گیرانه‌ای بر تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا به خطای کمبود حافظه (out‑of‑memory) برخورد کنید.

## **موارد مرتبط**

گزینه‌های دیگری برای تبدیل PPT/PPTX به تصویر را ببینید، مانند:
- [تبدیل PPT/PPTX به SVG](/slides/fa/java/render-a-slide-as-an-svg-image/).