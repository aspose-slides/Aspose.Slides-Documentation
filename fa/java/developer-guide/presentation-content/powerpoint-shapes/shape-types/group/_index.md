---
title: شکل‌های گروهی ارائه در جاوا
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/java/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه در ارائه‌های پاورپوینت با استفاده از Aspose.Slides برای جاوا، شکل‌ها را گروه‌بندی و جدا کنید — راهنمای سریع گام به گام با کد رایگان جاوا."
---
## **بررسی کلی**

این مقاله شرح می‌دهد که چگونه با شکل‌های گروهی در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه یک شکل گروهی را به یک اسلاید اضافه کنید، اشکال را داخل آن قرار دهید و ارائه به‌روز شده را ذخیره کنید. همچنین چگونگی دسترسی به اشکال ذخیره شده در داخل یک گروه و خواندن مقادیر `AlternativeText` آن‌ها را نشان می‌دهد. علاوه بر این، مقاله به‌طور خلاصه قابلیت‌های مرتبط با شکل‌های گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری را پوشش می‌دهد.

## **اضافه کردن یک شکل گروهی**
Aspose.Slides از کار با شکل‌های گروهی بر روی اسلایدها پشتیبانی می‌کند. این قابلیت به توسعه‌دهندگان کمک می‌کند ارائه‌های غنی‌تری بسازند. Aspose.Slides for Java از اضافه کردن یا دسترسی به شکل‌های گروهی پشتیبانی می‌کند. می‌توان اشکال را به یک شکل گروهی اضافه‌شده برای پر کردن آن یا دسترسی به هر ویژگی از شکل گروهی افزود. برای اضافه کردن یک شکل گروهی به یک اسلاید با استفاده از Aspose.Slides for Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از Index آن دریافت کنید
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه‌شده اضافه کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به یک اسلاید اضافه می‌کند.

```java
// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // دسترسی به مجموعه اشکال اسلایدها
    IShapeCollection slideShapes = sld.getShapes();

    // اضافه‌کردن یک شکل گروهی به اسلاید
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // اضافه‌کردن اشکال به داخل شکل گروهی اضافه‌شده
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // اضافه‌کردن قاب شکل گروهی
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // نوشتن فایل PPTX به دیسک
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به ویژگی AltText**
این موضوع گام‌های ساده‌ای را همراه با مثال‌های کد، برای اضافه کردن یک شکل گروهی و دسترسی به ویژگی AltText شکل‌های گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در یک اسلاید با استفاده از Aspose.Slides for Java:

1. نمونه‌ای از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) که فایل PPTX را نمایش می‌دهد، ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از Index آن دریافت کنید.
1. دسترسی به مجموعه اشکال اسلایدها.
1. دسترسی به شکل گروهی.
1. دسترسی به ویژگی [AlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getAlternativeText--) .

مثال زیر به متن جایگزین شکل گروهی دسترسی پیدا می‌کند.

```java
// ایجاد نمونه‌ای از کلاس Presentation که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation("AltText.pptx");
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // دسترسی به مجموعه اشکال اسلایدها
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // دسترسی به شکل گروهی.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // دسترسی به ویژگی AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا گروه‌بندی تو در تو (یک گروه داخل یک گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/groupshape/) دارای متد [getParentGroup](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getParentGroup--) است که مستقیماً پشتیبانی از سلسله‌مراتب را نشان می‌دهد (یک گروه می‌تواند فرزند گروه دیگری باشد).

**چگونه می‌توانم ترتیب Z گروه را نسبت به سایر اشیاء روی اسلاید کنترل کنم؟**

از متد [getZOrderPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getZOrderPosition--) کلاس [GroupShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توانم از جابه‌جایی/ویرایش/لغو گروه‌بندی جلوگیری کنم؟**

بله. بخش قفل‌گذاری گروه از طریق [GroupShapeLock](https://reference.aspose.com/slides/fa/java/com.aspose.slides/groupshape/#getGroupShapeLock--) در دسترس است که به شما امکان می‌دهد عملیات روی شیء را محدود کنید.