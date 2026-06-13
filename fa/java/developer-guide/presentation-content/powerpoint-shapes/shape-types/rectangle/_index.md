---
title: افزودن مستطیل‌ها به ارائه‌ها در جاوا
linktitle: مستطیل
type: docs
weight: 80
url: /fa/java/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "ارائه‌های پاورپوینت خود را با افزودن مستطیل‌ها با Aspose.Slides برای جاوا ارتقا دهید—به‌راحتی اشکال را به‌صورت برنامه‌نویسی طراحی و تغییر دهید."
---
## **نمای کلی**

این مقاله نحوه افزودن اشکال مستطیل به اسلایدهای پاورپوینت با استفاده از Aspose.Slides را نشان می‌دهد. این مقاله ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده، و ذخیره‌سازی ارائه به‌روزشده به‌صورت فایل PPTX را پوشش می‌دهد.

همچنین نحوه اعمال قالب‌بندی پایه برای مستطیل، مانند رنگ پر جامد، رنگ خط و ضخامت خط را می‌بینید. علاوه بر این، بخش پرسش‌های متداول مقاله به وظایف مرتبط با مستطیل اشاره می‌کند، از جمله گوشه‌های گرد، پر کردن با تصویر، افکت‌های بصری، ابرلینک‌ها، قفل‌های شکل، گزینه‌های خروجی و ویژگی‌های مؤثر.

## **افزودن یک مستطیل به اسلاید**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه شده است، یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) از نوع Rectangle اضافه کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک مستطیل ساده را به اسلاید اول ارائه اضافه کرده‌ایم.

```java
// یک شی از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع بیضی اضافه کنید
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن یک مستطیل قالب‌بندی‌شده به اسلاید**
- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeCollection) ارائه شده است، یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) از نوع Rectangle اضافه کنید.
- نوع [Fill Type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FillType) مستطیل را بر روی Solid تنظیم کنید.
- رنگ مستطیل را با استفاده از متد [SolidFillColor.setColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) که توسط شیء [IFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFillFormat) مرتبط با شیء [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) ارائه شده است، تنظیم کنید.
- رنگ خطوط مستطیل را تنظیم کنید.
- عرض خطوط مستطیل را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مراحل بالا در مثال زیر پیاده‌سازی شده‌اند.

```java
// یک شی از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید
Presentation pres = new Presentation();
try {
    // اسلاید اول را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع بیضی اضافه کنید
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // برخی قالب‌بندی‌ها را به شکل بیضی اعمال کنید
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // برخی قالب‌بندی‌ها را به خط بیضی اعمال کنید
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**چگونه یک مستطیل با گوشه‌های گرد اضافه کنم؟**  
از نوع شکل [shape type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapetype/) با گوشه‌های گرد استفاده کنید و شعاع گوشه‌ها را در خصوصیات شکل تنظیم کنید؛ گرد کردن می‌تواند به‌صورت هر گوشه به‌صورت جداگانه از طریق تنظیمات هندسی نیز اعمال شود.

**چگونه یک مستطیل را با تصویر (فتوشی) پر کنم؟**  
نوع پر کردن تصویر [fill type](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را فراهم کنید و حالت‌های [stretching/tiling modes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا می‌توان به یک مستطیل سایه و جلوه نور داد؟**  
بله. [سایهٔ خارجی/داخلی، نوردهی و لبه‌های نرم](/slides/fa/java/shape-effect/) در دسترس هستند و می‌توان پارامترهای آنها را تنظیم کرد.

**آیا می‌توانم یک مستطیل را به عنوان دکمه با ابرلینک تبدیل کنم؟**  
بله. می‌توانید یک [ابرلینک اختصاص دهید](/slides/fa/java/manage-hyperlinks/) تا با کلیک روی شکل به اسلاید، فایل، آدرس وب یا ایمیل بروید.

**چگونه می‌توانم یک مستطیل را از جابه‌جایی و تغییرات محافظت کنم؟**  
از [قفل‌های شکل](/slides/fa/java/applying-protection-to-presentation/) استفاده کنید: می‌توانید جابه‌جایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا طرح حفظ شود.

**آیا می‌توانم یک مستطیل را به تصویر رستر یا SVG تبدیل کنم؟**  
بله. می‌توانید [شکل را رندر کنید]https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float- به‌صورت تصویری با اندازه/مقیاس مشخص یا [به عنوان SVG خروجی بگیرید]https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions- برای استفادهٔ برداری.

**چگونه می‌توانم به‌سرعت ویژگی‌های واقعی (موثر) یک مستطیل را با در نظر گرفتن تم و ارث‌بری به‌دست آورم؟**  
از [ویژگی‌های مؤثر شکل](/slides/fa/java/shape-effective-properties/) استفاده کنید: API مقادیر محاسبه‌شده‌ای را بر می‌گرداند که سبک‌های تم، چیدمان و تنظیمات محلی را در نظر می‌گیرند و تجزیه و تحلیل قالب‌بندی را ساده می‌کند.