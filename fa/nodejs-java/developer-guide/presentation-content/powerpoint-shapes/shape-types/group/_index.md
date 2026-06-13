---
title: اشکال گروهی ارائه در جاوا اسکریپت
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/nodejs-java/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- PowerPoint
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در مجموعه‌های PowerPoint گروه‌بندی و جداسازی کنید با استفاده از Aspose.Slides برای Node.js از طریق Java — راهنمای سریع، گام‌به‌گام با کد رایگان جاوا اسکریپت."
---
## **نمایش کلی**

این مقاله توضیح می‌دهد چگونه با اشکال گروهی در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک شکل گروهی به یک اسلاید اضافه کنید، اشکال را درون آن قرار دهید و ارائه به‌روزرسانی‌شده را ذخیره کنید. همچنین نحوه دسترسی به اشکالی که در یک گروه ذخیره شده‌اند و خواندن مقدار `AlternativeText` آن‌ها را نشان می‌دهد. علاوه بر این، مقاله به‌طور مختصر قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری را پوشش می‌دهد.

## **افزودن شکل گروهی**
Aspose.Slides از کار با اشکال گروهی در اسلایدها پشتیبانی می‌کند. این ویژگی به توسعه‌دهندگان کمک می‌کند ارائه‌های غنی‌تری ایجاد کنند. Aspose.Slides for Node.js via Java امکان افزودن یا دسترسی به اشکال گروهی را فراهم می‌کند. می‌توان اشکالی را به شکل گروهی اضافه‌شده افزود تا آن را پر کنید یا به هر ویژگی‌ای از شکل گروهی دسترسی پیدا کنید. برای افزودن یک شکل گروهی به اسلاید با استفاده از Aspose.Slides for Node.js via Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) ایجاد کنید.
1. ارجاع یک اسلاید را با استفاده از شاخص (Index) آن دریافت کنید.
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه‌شده اضافه کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```javascript
// نمونه سازی کلاس Presentation
var pres = new aspose.slides.Presentation();
try {
    // دریافت اسلاید اول
    var sld = pres.getSlides().get_Item(0);
    // دسترسی به مجموعه اشکال اسلایدها
    var slideShapes = sld.getShapes();
    // افزودن یک شکل گروهی به اسلاید
    var groupShape = slideShapes.addGroupShape();
    // افزودن اشکال به داخل شکل گروهی اضافه‌شده
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // افزودن قاب شکل گروهی
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // نوشتن فایل PPTX روی دیسک
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **دسترسی به ویژگی AltText**
این موضوع گام‌های ساده‌ای را به‌همراه مثال‌های کد برای افزودن یک شکل گروهی و دسترسی به ویژگی AltText اشکال گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در اسلاید با استفاده از Aspose.Slides for Node.js via Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) که نمایانگر فایل PPTX است نمونه‌سازی کنید.
1. ارجاع یک اسلاید را با استفاده از شاخص آن دریافت کنید.
1. به مجموعهٔ اشکال اسلایدها دسترسی پیدا کنید.
1. به شکل گروهی دسترسی پیدا کنید.
1. متد [getAlternativeText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Shape#getAlternativeText--) را فراخوانی کنید.

```javascript
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // دریافت اسلاید اول
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // دسترسی به مجموعهٔ اشکال اسلایدها
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // دسترسی به شکل گروهی.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // دسترسی به ویژگی AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سوالات متداول**

**آیا گروه‌بندی تو در تو (یک گروه داخل یک گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/) دارای متد [getParentGroup](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getparentgroup/) است که به‌صورت مستقیم از پشتیبانی سلسله‌مراتبی (یک گروه می‌تواند فرزند گروه دیگر باشد) خبر می‌دهد.

**چگونه می‌توانم ترتیب Z گروه را نسبت به سایر اشیاء روی اسلاید کنترل کنم؟**

از متد [getZOrderPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/getzorderposition/) کلاس [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن در پشتهٔ نمایش را بررسی کنید.

**آیا می‌توانم از جابجایی/ویرایش/حذف گروه جلوگیری کنم؟**

بله. بخش قفل گروه از طریق [GroupShapeLock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/getgroupshapelock/) در دسترس است که به شما امکان می‌دهد عملیات روی شیء را محدود کنید.