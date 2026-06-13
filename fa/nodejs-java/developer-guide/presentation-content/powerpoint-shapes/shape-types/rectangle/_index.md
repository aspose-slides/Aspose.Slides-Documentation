---
title: اضافه کردن مستطیل‌ها به ارائه‌ها در JavaScript
linktitle: مستطیل
type: docs
weight: 80
url: /fa/nodejs-java/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ارائه‌های PowerPoint خود را با افزودن مستطیل‌ها با JavaScript و Aspose.Slides برای Node.js—به‌راحتی شکل‌ها را به‌صورت برنامه‌نویسی طراحی و تغییر دهید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه با استفاده از Aspose.Slides، اشکال مستطیلی را به اسلایدهای PowerPoint اضافه کنیم. این مطلب شامل ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی‌شده و ذخیره ارائه به‌روزشده به‌صورت فایل PPTX است.

همچنین می‌توانید ببینید چگونه قالب‌بندی پایهٔ مستطیل را اعمال کنید، از جمله رنگ پر کردن ثابت، رنگ خط و عرض خط. علاوه بر این، بخش پرسش‌های متداول مقاله به وظایف مرتبط با مستطیل اشاره می‌کند، از جمله گوشه‌های گرد، پر کردن با تصویر، اثرات بصری، پیوندهای هیپرمتن، قفل‌کردن شکل، گزینه‌های صادرات و خصوصیات مؤثر.

## **افزودن مستطیل به اسلاید**

همانند موضوعات قبلی، اینجا نیز در مورد افزودن یک شکل صحبت می‌کنیم و این بار شکل مورد بحث مستطیل است. در این موضوع توضیح دادیم که چگونه توسعه‌دهندگان می‌توانند مستطیل‌های ساده یا قالب‌بندی‌شده را به اسلایدهای خود با Aspose.Slides اضافه کنند.

برای افزودن یک مستطیل ساده به اسلاید انتخابی ارائه، مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به‌دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) از نوع Rectangle را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) ارائه می‌شود، اضافه کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

در مثال زیر، یک مستطیل ساده را به اولین اسلاید ارائه اضافه کرده‌ایم.

```javascript
// نمونه‌سازی کلاس Prseetation که نمایانگر PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن AutoShape از نوع بیضی
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // نوشتن فایل PPTX به دیسک
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **افزودن مستطیل قالب‌بندی‌شده به اسلاید**
برای افزودن یک مستطیل قالب‌بندی‌شده به اسلاید، مراحل زیر را اجرا کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
- با استفاده از Index آن، مرجع یک اسلاید را به‌دست آورید.
- یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) از نوع Rectangle را با استفاده از متد [addAutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) که توسط شیء [ShapeCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ShapeCollection) ارائه می‌شود، اضافه کنید.
- [Fill Type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FillType) مستطیل را به Solid تنظیم کنید.
- رنگ مستطیل را با استفاده از متد [SolidFillColor.setColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) که توسط شیء [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/FillFormat) مرتبط با شیء [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape) ارائه می‌شود، تنظیم کنید.
- رنگ خطوط مستطیل را تنظیم کنید.
- عرض خطوط مستطیل را تنظیم کنید.
- ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مراحل فوق در مثال زیر پیاده‌سازی شده‌اند.

```javascript
// نمونه‌سازی کلاس Prseetation که نمایانگر PPTX است
var pres = new aspose.slides.Presentation();
try {
    // دریافت اولین اسلاید
    var sld = pres.getSlides().get_Item(0);
    // افزودن AutoShape از نوع بیضی
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // اعمال برخی قالب‌بندی‌ها بر شکل بیضی
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // اعمال برخی قالب‌بندی‌ها بر خط بیضی
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // نوشتن فایل PPTX به دیسک
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **پرسش‌های متداول**

**چگونه می‌توانم مستطیلی با گوشه‌های گرد اضافه کنم؟**

از [shape type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapetype/) با گوشه‌های گرد استفاده کنید و شعاع گوشه‌ها را در خصوصیات شکل تنظیم کنید؛ همچنین می‌توان گردی را برای هر گوشه به صورت جداگانه از طریق تنظیمات هندسی اعمال کرد.

**چگونه می‌توانم یک مستطیل را با تصویر (فتری) پر کنم؟**

نوع پر کردن [picture fill type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را فراهم کنید و حالت‌های [stretching/tiling](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillmode/) را تنظیم نمایید.

**آیا می‌توانم به یک مستطیل سایه و درخشندگی اضافه کنم؟**

بله. [سایهٔ خارجی/داخلی، درخشندگی و لبه‌های نرم](/slides/fa/nodejs-java/shape-effect/) موجود هستند و پارامترهای قابل تنظیمی دارند.

**آیا می‌توانم یک مستطیل را به دکمه‌ای با پیوند هیپرمتن تبدیل کنم؟**

بله. می‌توانید [یک پیوند هیپرمتن](/slides/fa/nodejs-java/manage-hyperlinks/) به کلیک روی شکل اختصاص دهید (پرش به اسلاید، فایل، آدرس وب یا ایمیل).

**چگونه می‌توانم یک مستطیل را از جابه‌جایی و تغییرات محافظت کنم؟**

از قفل‌های شکل استفاده کنید: می‌توانید جابه‌جایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا چیدمان حفظ شود.

**آیا می‌توانم یک مستطیل را به تصویر رستر یا SVG تبدیل کنم؟**

بله. می‌توانید [شکل را رندر کنید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getImage) به یک تصویر با اندازه/مقیاس مشخص یا [به صورت SVG صادر کنید](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/writeassvg/) برای استفادهٔ برداری.

**چگونه می‌توانم به‌سرعت ویژگی‌های مؤثر (effective) واقعی یک مستطیل را با توجه به تم و ارث‌بری به‌دست آورم؟**

[از ویژگی‌های مؤثر شکل استفاده کنید](/slides/fa/nodejs-java/shape-effective-properties/): API مقادیر محاسبه‌شده‌ای را بر می‌گرداند که سبک‌های تم، چینش و تنظیمات محلی را در نظر می‌گیرد و تحلیل قالب‌بندی را ساده می‌کند.