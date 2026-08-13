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
- صدور PPT به JPG
- صدور PPTX به JPG
- جاوا
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT، PPTX) به تصاویر JPG با کیفیت بالا در جاوا با Aspose.Slides برای جاوا با استفاده از مثال‌های کد سریع و قابل اعتماد."
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها را آسان می‌کند. Aspose.Slides به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر شخصی‌سازی شده ارائه و ایجاد تصویر بندانگشتی برای هر اسلاید آسان می‌شود. این می‌تواند برای محافظت از اسلایدها در برابر کپی‌برداری یا نمایش ارائه به‌صورت فقط‑خواندنی مفید باشد. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل PowerPoint PPT/PPTX به JPG**

مراحل تبدیل PPT/PPTX به JPG به شرح زیر است:

1. یک نمونه از نوع [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.  
2. شیء اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) را از مجموعه [Presentation.getSlides()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getSlides--) دریافت کنید.  
3. تصویر بندانگشتی هر اسلاید را ایجاد کنید و سپس آن را به JPG تبدیل کنید. متد [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-float-float-) برای دریافت تصویر بندانگشتی اسلاید استفاده می‌شود و یک شیء [Images](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Images) را برمی‌گرداند. متد [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) باید از اسلاید مورد نیاز نوع [ISlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) فراخوانی شود و مقیاس‌های تصویر بندانگشتی به‌عنوان پارامتر به آن ارسال می‌شوند.  
4. پس از دریافت تصویر بندانگشتی اسلاید، متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) را از شیء تصویر بندانگشتی فراخوانی کنید. نام فایل نهایی و فرمت تصویر را به‌عنوان پارامتر به آن بدهید.

{{% alert color="info" %}}

**توجه**: تبدیل PPT/PPTX به JPG متفاوت از تبدیل به انواع دیگر در API Aspose.Slides است. برای انواع دیگر معمولاً از متد [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) استفاده می‌کنید، اما در اینجا باید از متد [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) استفاده کنید.

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        IImage slideImage = sld.getImage(1f, 1f);

        // تصویر را به‌صورت JPEG در دیسک ذخیره می‌کند
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

برای تغییر ابعاد تصویر بندانگشتی و تصویر JPG حاصل، می‌توانید مقادیر *ScaleX* و *ScaleY* را با پاس کردن آنها به متدهای [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide#getImage-float-float-) تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // ابعاد را تعریف می‌کند
    int desiredX = 1200;
    int desiredY = 800;
    // مقادیر مقیاس‌دار X و Y را دریافت می‌کند
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // یک تصویر با مقیاس کامل ایجاد می‌کند
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // تصویر را به‌صورت JPEG در دیسک ذخیره می‌کند
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

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصویر**

Aspose.Slides for Java قابلیتی فراهم می‌کند که به شما اجازه می‌دهد نظرات موجود در اسلایدهای ارائه را هنگام تبدیل آنها به تصاویر رندر کنید. این کد Java این عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}

Aspose یک برنامه وب [FREE Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین می‌توانید [JPG to JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره.

با استفاده از همان اصول توضیح داده شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر به این صفحات مراجعه کنید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/), تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/), تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).

{{% /alert %}}

## **سؤالات متداول**

### آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

### آیا تبدیل از SmartArt، نمودارها و سایر اشیای پیچیده پشتیبانی می‌کند؟

بله، Aspose.Slides تمام محتوا از جمله SmartArt، نمودارها، جداول، شکل‌ها و موارد دیگر را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از فونت‌های سفارشی یا گم‌شده.

### آیا محدودیتی برای تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟

Aspose.Slides خود محدودیت قطعی برای تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای «عدم کافی بودن حافظه» مواجه شوید.

## **موارد مرتبط**

سایر گزینه‌های تبدیل PPT/PPTX به تصویر را ببینید:

- [PPT/PPTX to SVG conversion](/slides/fa/java/render-a-slide-as-an-svg-image/)