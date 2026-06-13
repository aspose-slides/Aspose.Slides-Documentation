---
title: شکل‌های گروهی ارائه در اندروید
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/androidjava/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه در اسلایدهای پاورپوینت با استفاده از Aspose.Slides برای اندروید، اشکال را گروه‌بندی و از‌گروه‌بندی کنید — راهنمای سریع گام به گام با کد رایگان جاوا."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با اشکال گروهی در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک شکل گروهی به اسلاید اضافه کنید، اشکال را داخل آن قرار دهید و ارائه به‌روزشده را ذخیره کنید. همچنین نحوه دسترسی به اشکال ذخیره‌شده درون یک گروه و خواندن مقادیر `AlternativeText` آنها را نشان می‌دهد. علاوه بر این، مقاله به‌طور مختصر قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری را پوشش می‌دهد.

## **افزودن یک شکل گروهی**
Aspose.Slides از کار با اشکال گروهی بر روی اسلایدها پشتیبانی می‌کند. این قابلیت به توسعه‌دهندگان کمک می‌کند ارائه‌های غنی‌تری ایجاد کنند. Aspose.Slides برای Android از طریق Java امکان افزودن یا دسترسی به اشکال گروهی را فراهم می‌کند. می‌توانید اشکال را به شکل گروهی اضافه‌شده اضافه کنید تا آن را پر کنید یا به هر ویژگی‌ای از شکل گروهی دسترسی پیدا کنید. برای افزودن یک شکل گروهی به اسلاید با استفاده از Aspose.Slides برای Android از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه‌شده اضافه کنید.
1. ارائه‌ی تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی به اسلاید اضافه می‌کند.

```java
// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);

    // دسترسی به مجموعهٔ اشکال اسلایدها
    IShapeCollection slideShapes = sld.getShapes();

    // افزودن یک شکل گروهی به اسلاید
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // افزودن اشکال داخل شکل گروهی اضافه‌شده
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // افزودن فریم شکل گروهی
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // نوشتن فایل PPTX بر روی دیسک
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به ویژگی AltText**
این موضوع مراحل ساده‌ای را همراه با مثال‌های کد، برای افزودن یک شکل گروهی و دسترسی به ویژگی AltText اشکال گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در اسلاید با استفاده از Aspose.Slides برای Android از طریق Java:

1. کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) را که نمایانگر فایل PPTX است، نمونه‌سازی کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. دسترسی به مجموعهٔ اشکال اسلایدها.
1. دسترسی به شکل گروهی.
1. دسترسی به ویژگی [AlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getAlternativeText--) .

مثال زیر به متن جایگزین شکل گروهی دسترسی پیدا می‌کند.

```java
// نمونه‌سازی کلاس Presentation که فایل PPTX را نشان می‌دهد
Presentation pres = new Presentation("AltText.pptx");
try {
    // دریافت اولین اسلاید
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // دسترسی به مجموعهٔ اشکال اسلایدها
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // دسترسی به شکل گروهی.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // دسترسی به خاصیت AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

**آیا گروه‌بندی تو در تو (یک گروه درون گروه) پشتیبانی می‌شود؟**

بله. کلاس [GroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/groupshape/) متدی به نام [getParentGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getParentGroup--) دارد که به‌وضوح پشتیبانی از سلسله‌مراتب را نشان می‌دهد (یک گروه می‌تواند فرزند گروه دیگری باشد).

**چگونه می‌توانم ترتیب Z گروه را نسبت به سایر اشیاء در اسلاید کنترل کنم؟**

از متد [getZOrderPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getZOrderPosition--) کلاس [GroupShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توانم از جابجایی/ویرایش/حذف گروه جلوگیری کنم؟**

بله. بخش قفل‌گذاری گروه از طریق [getGroupShapeLock](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) در دسترس است که به شما امکان می‌دهد عملیات روی شیء را محدود کنید.