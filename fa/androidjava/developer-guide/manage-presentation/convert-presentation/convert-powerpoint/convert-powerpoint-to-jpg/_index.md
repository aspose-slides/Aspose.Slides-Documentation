---
title: تبدیل PPT و PPTX به JPG در اندروید
linktitle: PowerPoint به JPG
type: docs
weight: 60
url: /fa/androidjava/convert-powerpoint-to-jpg/
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
- اندروید
- جاوا
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT, PPTX) به تصاویر JPG با کیفیت بالا در جاوا با Aspose.Slides برای اندروید با استفاده از مثال‌های کد سریع و قابل اطمینان."
---
## **مقدمه**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها کمک می‌کند. Aspose.Slides برای Android از طریق Java به شما امکان تبدیل فایل‌های PPTX، PPT و ODP به تصاویر JPEG با کیفیت بالا را می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر ارائه خود و ایجاد تصویر کوچک برای هر اسلاید آسان است. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی‌برداری محافظت کنید یا ارائه را در حالت فقط‑خواندنی نمایش دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویر تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. شیء اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) را از مجموعه‌ای که توسط متد [Presentation.getSlides()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) برگردانده می‌شود، دریافت کنید.
1. یک تصویر از اسلاید را با استفاده از متد [ISlide.getImage(float, float)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-float-float-) ایجاد کنید.
1. متد [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) را بر روی شیء تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به‌عنوان آرگومان پاس دهید.

{{% alert color="info" %}} 

**توجه:** تبدیل PPT، PPTX یا ODP به JPG با تبدیل به سایر فرمت‌ها در API Aspose.Slides برای Android از طریق Java متفاوت است. برای سایر فرمت‌ها، معمولاً از متد [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) استفاده می‌کنید. اما برای تبدیل به JPG، باید از متد [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) استفاده کنید.

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // یک تصویر اسلاید با مقیاس مشخص ایجاد کنید.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // تصویر را در قالب JPEG بر روی دیسک ذخیره کنید.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تبدیل اسلایدها به JPG با ابعاد سفارشی**

برای تغییر ابعاد تصاویر JPG حاصل، می‌توانید اندازه تصویر را با عبور دادن آن به متد [ISlide.getImage(Size)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) تنظیم کنید. این امکان را به شما می‌دهد تا تصاویری با مقادیر عرض و ارتفاع خاص تولید کنید و اطمینان حاصل کنید خروجی با نیازهای شما برای وضوح و نسبت ابعاد مطابقت دارد. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات که ابعاد دقیق تصویر مورد نیاز است، مفید است.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // یک تصویر اسلاید با اندازه مشخص ایجاد کنید.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // تصویر را در قالب JPEG بر روی دیسک ذخیره کنید.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **رندر نظرات هنگام ذخیره اسلایدها به‌عنوان تصویر**

Aspose.Slides برای Android از طریق Java ویژگی‌ای فراهم می‌کند که به شما اجازه می‌دهد نظرات موجود بر روی اسلایدهای ارائه را هنگام تبدیل به تصاویر JPG رندر کنید. این قابلیت به‌خصوص برای حفظ حاشیه‌نویسی‌ها، بازخوردها یا بحث‌های اضافه‌شده توسط همکاران در ارائه‌های PowerPoint مفید است. با فعال‌سازی این گزینه، اطمینان می‌یابید که نظرات در تصاویر تولید شده قابل مشاهده هستند و مرور و به اشتراک‌گذاری بازخوردها بدون نیاز به باز کردن فایل اصلی ارائه آسان‌تر می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلایدی با نظرات است:

![اسلاید با نظرات](slide_with_comments.png)

کد زیر در Java اسلاید را به تصویر JPG تبدیل می‌کند در حالی که نظرات را حفظ می‌کند:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // اولین اسلاید را به تصویر تبدیل کنید.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

نتیجه:

![تصویر JPG با نظرات](image_with_comments.png)

## **موارد مرتبط**

گزینه‌های دیگر برای تبدیل PPT، PPTX یا ODP به تصاویر را ببینید، مانند:

- [تبدیل PowerPoint به GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/androidjava/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/androidjava/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

برای دیدن چگونگی تبدیل ارائه‌های PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX به JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT به JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 

{{% /alert %}} 

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose یک [برنامه وب رایگان Collage](https://products.aspose.app/slides/fa/collage) ارائه می‌دهد. با استفاده از این سرویس آنلاین، می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکس](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید، و غیره. 

با استفاده از همان اصول توضیح‌داده‌شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، این صفحات را ببینید: تبدیل [تصویر به JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG به تصویر](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG به PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، تبدیل [PNG به JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG به SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، تبدیل [SVG به PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).

{{% /alert %}}

## **پرسش‌های متداول**

### آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات واحد فراهم می‌کند.

### آیا تبدیل از SmartArt، نمودارها و سایر اشیا پیچیده پشتیبانی می‌کند؟

بله، Aspose.Slides تمام محتوا از جمله SmartArt، نمودارها، جدول‌ها، شکل‌ها و موارد دیگر را رندر می‌کند. اما دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه زمانی که از فونت‌های سفارشی یا گمشده استفاده شود.

### آیا محدودیتی در تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟

Aspose.Slides خود محدودیت سخت‌گیرانه‌ای برای تعداد اسلایدهایی که می‌توانید پردازش کنید اعمال نمی‌کند. با این حال، ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا، با خطای کمبود حافظه مواجه شوید.