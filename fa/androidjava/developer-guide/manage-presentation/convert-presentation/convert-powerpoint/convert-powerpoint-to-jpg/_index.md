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
- ذخیره PowerPoint به صورت JPG
- ذخیره ارائه به صورت JPG
- ذخیره اسلاید به صورت JPG
- ذخیره PPT به صورت JPG
- ذخیره PPTX به صورت JPG
- صدور PPT به JPG
- صدور PPTX به JPG
- اندروید
- جاوا
- Aspose.Slides
description: "اسلایدهای PowerPoint (PPT، PPTX) را به تصویرهای JPG با کیفیت بالا در جاوا با Aspose.Slides برای اندروید با استفاده از نمونه‌های کد سریع و قابل اعتماد تبدیل کنید."
---
## **معرفی**

تبدیل ارائه‌های PowerPoint و OpenDocument به تصاویر JPG به اشتراک‌گذاری اسلایدها، بهینه‌سازی عملکرد و جاسازی محتوا در وب‌سایت‌ها یا برنامه‌ها را آسان می‌کند. Aspose.Slides برای Android از طریق Java به شما امکان تبدیل فایل‌های PPTX، PPT و ODP را به تصاویر JPEG با کیفیت بالا می‌دهد. این راهنما روش‌های مختلف تبدیل را توضیح می‌دهد.

با این ویژگی‌ها، پیاده‌سازی نمایشگر ارائه خود و ایجاد تصویر کوچک برای هر اسلاید آسان است. این می‌تواند مفید باشد اگر بخواهید اسلایدهای ارائه را از کپی محافظت کنید یا ارائه را در حالت فقط‌خواندنی نمایش دهید. Aspose.Slides به شما اجازه می‌دهد کل ارائه یا اسلاید خاصی را به فرمت‌های تصویری تبدیل کنید.

## **تبدیل اسلایدهای ارائه به تصاویر JPG**

مراحل تبدیل یک فایل PPT، PPTX یا ODP به JPG به شرح زیر است:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
1. شیء اسلاید از نوع [ISlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) را از مجموعه‌ای که توسط متد [Presentation.getSlides()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getSlides--) برگردانده می‌شود، دریافت کنید.
1. تصویر اسلاید را با استفاده از متد [ISlide.getImage(float,float)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-float-float-) ایجاد کنید.
1. متد [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) را روی شیء تصویر فراخوانی کنید. نام فایل خروجی و فرمت تصویر را به عنوان آرگومان پاس دهید.

{{% alert color="primary" %}} 
**توجه:** تبدیل PPT، PPTX یا ODP به JPG متفاوت از تبدیل به سایر فرمت‌ها در API Aspose.Slides برای Android از طریق Java است. برای سایر فرمت‌ها، معمولاً از متد [IPresentation.save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) استفاده می‌کنید. اما برای تبدیل به JPG، باید از متد [IImage.save(string,ImageFormat)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) استفاده کنید.
{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // یک تصویر اسلاید با مقیاس مشخص ایجاد کنید.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // تصویر را به صورت فرمت JPEG روی دیسک ذخیره کنید.
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

برای تغییر ابعاد تصاویر JPG تولیدی، می‌توانید اندازه تصویر را با عبور آن به متد [ISlide.getImage(Size)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) تنظیم کنید. این امکان به شما اجازه می‌دهد تا تصاویری با مقادیر عرض و ارتفاع خاص تولید کنید و اطمینان حاصل کنید که خروجی با نیازهای شما برای وضوح و نسبت ابعاد سازگار است. این انعطاف‌پذیری به‌ویژه هنگام تولید تصاویر برای برنامه‌های وب، گزارش‌ها یا مستندات مفید است، جایی که ابعاد دقیق تصویر الزامی است.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // یک تصویر اسلاید با اندازه مشخص ایجاد کنید.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // تصویر را به فرمت JPEG روی دیسک ذخیره کنید.
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

## **رندر نظرات هنگام ذخیره اسلایدها به عنوان تصاویر**

Aspose.Slides برای Android از طریق Java ویژگی‌ای فراهم می‌کند که به شما اجازه می‌دهد نظرات موجود در اسلایدهای ارائه را هنگام تبدیل به تصاویر JPG رندر کنید. این قابلیت برای حفظ حاشیه‌نویسی‌ها، بازخوردها یا بحث‌های اضافه‌شده توسط همکاران در ارائه‌های PowerPoint بسیار مفید است. با فعال‌سازی این گزینه، اطمینان می‌یابید که نظرات در تصاویر تولید شده قابل مشاهده هستند و بررسی و به اشتراک‌گذاری بازخوردها بدون نیاز به باز کردن فایل اصلی ارائه آسان می‌شود.

فرض کنید فایلی به نام "sample.pptx" داریم که شامل اسلایدی با نظرات است:

![اسلاید با نظرات](slide_with_comments.png)

کد جاوای زیر اسلاید را به تصویر JPG تبدیل می‌کند و نظرات را حفظ می‌نماید:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // اسلاید اول را به تصویر تبدیل کنید.
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

سایر گزینه‌های تبدیل PPT، PPTX یا ODP به تصاویر را ببینید، از جمله:

- [تبدیل PowerPoint به GIF](/slides/fa/androidjava/convert-powerpoint-to-animated-gif/)
- [تبدیل PowerPoint به PNG](/slides/fa/androidjava/convert-powerpoint-to-png/)
- [تبدیل PowerPoint به TIFF](/slides/fa/androidjava/convert-powerpoint-to-tiff/)
- [تبدیل PowerPoint به SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
برای مشاهده نحوه تبدیل ارائه‌های PowerPoint به تصاویر JPG توسط Aspose.Slides، این مبدل‌های آنلاین رایگان را امتحان کنید: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/fa/conversion/pptx-to-jpg) و [PPT to JPG](https://products.aspose.app/slides/fa/conversion/ppt-to-jpg). 
{{% /alert %}} 

![مبدل آنلاین رایگان PPTX به JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose یک برنامه وب [FREE Collage](https://products.aspose.app/slides/fa/collage) رایگان ارائه می‌کند. با استفاده از این سرویس آنلاین، می‌توانید تصاویر [JPG به JPG](https://products.aspose.app/slides/fa/collage/jpg) یا PNG به PNG را ترکیب کنید، [شبکه‌های عکسی](https://products.aspose.app/slides/fa/collage/photo-grid) ایجاد کنید و غیره. 

با استفاده از اصول مشابه بیان‌شده در این مقاله، می‌توانید تصاویر را از یک فرمت به فرمت دیگر تبدیل کنید. برای اطلاعات بیشتر، این صفحات را ببینید: تبدیل [image to JPG](https://products.aspose.com/slides/fa/java/conversion/image-to-jpg/); تبدیل [JPG to image](https://products.aspose.com/slides/fa/java/conversion/jpg-to-image/); تبدیل [JPG to PNG](https://products.aspose.com/slides/fa/java/conversion/jpg-to-png/)، تبدیل [PNG to JPG](https://products.aspose.com/slides/fa/java/conversion/png-to-jpg/); تبدیل [PNG to SVG](https://products.aspose.com/slides/fa/java/conversion/png-to-svg/)، تبدیل [SVG to PNG](https://products.aspose.com/slides/fa/java/conversion/svg-to-png/).
{{% /alert %}}

## **سؤالات متداول**

**آیا این روش از تبدیل دسته‌ای پشتیبانی می‌کند؟**

بله، Aspose.Slides امکان تبدیل دسته‌ای چندین اسلاید به JPG را در یک عملیات فراهم می‌کند.

**آیا تبدیل از SmartArt، نمودارها و اشیاء پیچیده دیگر پشتیبانی می‌شود؟**

بله، Aspose.Slides تمام محتوا شامل SmartArt، نمودارها، جداول، اشکال و غیره را رندر می‌کند. با این حال، دقت رندر ممکن است نسبت به PowerPoint کمی متفاوت باشد، به‌ویژه هنگام استفاده از قلم‌های سفارشی یا گم‌شده.

**آیا محدودیتی برای تعداد اسلایدهایی که می‌توان پردازش کرد وجود دارد؟**

Aspose.Slides خود محدودیت سخت‌گیرانه‌ای برای تعداد اسلایدهای قابل پردازش اعمال نمی‌کند. اما ممکن است هنگام کار با ارائه‌های بزرگ یا تصاویر با وضوح بالا با خطای کمبود حافظه (out‑of‑memory) مواجه شوید.