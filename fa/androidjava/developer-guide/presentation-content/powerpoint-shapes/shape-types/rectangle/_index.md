---
title: افزودن مستطیل‌ها به ارائه‌ها در اندروید
linktitle: مستطیل
type: docs
weight: 80
url: /fa/androidjava/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "ارائه‌های پاورپوینت خود را با افزودن مستطیل‌ها با Aspose.Slides برای اندروید از طریق جاوا—به‌راحتی اشکال را به‌صورت برنامه‌نویسی‌شده طراحی و تغییر دهید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد که چگونه می‌توان با استفاده از Aspose.Slides اشکال مستطیلی را به اسلایدهای PowerPoint اضافه کرد. این مقاله شامل ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده، و ذخیره ارائه به‌روزرسانی‌شده به‌صورت فایل PPTX است.

همچنین خواهید دید که چگونه قالب‌بندی پایهٔ مستطیل، مانند رنگ پر ثابت، رنگ خط و عرض خط را اعمال کنید. علاوه بر این، بخش پرسش‌های متداول مقاله به وظایف مرتبط با مستطیل اشاره می‌کند، از جمله گوشه‌های گرد، پر کردن با تصویر، اثرات بصری، پیوندهای هیپرلینک، قفل‌گذاری اشکال، گزینه‌های خروجی و خصوصیات مؤثر.

## **اضافه کردن یک مستطیل به اسلاید**
برای اضافه کردن یک مستطیل ساده به اسلاید انتخاب شدهٔ ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) موجود در شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection)، یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) از نوع Rectangle اضافه کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX بنویسید.

در مثال زیر، یک مستطیل ساده به اولین اسلاید ارائه اضافه کرده‌ایم.

```java
// یک شی از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع بیضی
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اضافه کردن یک مستطیل قالب‌بندی‌شده به اسلاید**
برای اضافه کردن یک مستطیل قالب‌بندی‌شده به اسلاید، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را دریافت کنید.
- با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) موجود در شیء [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShapeCollection)، یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) از نوع Rectangle اضافه کنید.
- نوع پر کردن مستطیل را به Solid تنظیم کنید.
- رنگ مستطیل را با متد [SolidFillColor.setColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) که توسط شیء [IFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IFillFormat) مرتبط با شیء [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط مستطیل را تنظیم کنید.
- عرض خطوط مستطیل را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX بنویسید.

مراحل بالا در مثال زیر پیاده‌سازی شده است.

```java
// یک شی از کلاس Presentation که نمایانگر فایل PPTX است را ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape از نوع بیضی اضافه کنید
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // قالب‌بندی‌هایی بر شکل بیضی اعمال کنید
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // قالب‌بندی‌هایی بر خط بیضی اعمال کنید
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**چگونه یک مستطیل با گوشه‌های گرد اضافه کنم؟**

از [نوع شکل](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapetype/) گوشه‌دار استفاده کنید و شعاع گوشه را در ویژگی‌های شکل تنظیم کنید؛ می‌توانید گردی را برای هر گوشه به‌صورت جداگانه از طریق تنظیمات هندسی اعمال کنید.

**چگونه یک مستطیل را با تصویر (بافت) پر کنم؟**

[نوع پر کردن تصویر](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را فراهم کنید و حالت‌های [stretching/tiling modes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا می‌توان به مستطیل سایه و نوردهی داد؟**

بله. [Outer/inner shadow, glow, and soft edges](/slides/fa/androidjava/shape-effect/) در دسترس هستند و می‌توان پارامترهای قابل تنظیم را تنظیم کرد.

**آیا می‌توانم مستطیل را به دکمه‌ای با پیوند تبدیل کنم؟**

بله. برای کلیک روی شکل، [Assign a hyperlink](/slides/fa/androidjava/manage-hyperlinks/) اختصاص دهید (به اسلاید، فایل، آدرس وب یا ایمیل).

**چگونه می‌توانم مستطیل را از جابجایی و تغییرات محافظت کنم؟**

از قفل‌های شکل استفاده کنید: می‌توانید جابجایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا چیدمان حفظ شود.

**آیا می‌توانم مستطیل را به تصویر رستر یا SVG تبدیل کنم؟**

بله. می‌توانید [render the shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) را به تصویر با اندازه/مقیاس مشخص رندر کنید یا آن را به‌صورت SVG [export it as SVG](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) خروجی بگیرید.

**چگونه می‌توانم به‌سرعت خصوصیات واقعی (موثر) یک مستطیل را با در نظر گرفتن تم و وراثت دریافت کنم؟**

[Use the shape’s effective properties](/slides/fa/androidjava/shape-effective-properties/): API مقادیر محاسبه‌شده‌ای را بر می‌گرداند که تم، چیدمان و تنظیمات محلی را در نظر می‌گیرند و تجزیه و تحلیل قالب‌بندی را ساده می‌کنند.