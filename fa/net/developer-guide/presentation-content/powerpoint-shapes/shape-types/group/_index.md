---
title: اشکال ارائه گروهی در .NET
linktitle: گروه شکل
type: docs
weight: 40
url: /fa/net/group/
keywords:
- شکل گروهی
- گروه شکل
- افزودن گروه
- متن جایگزین
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در مجموعه‌های PowerPoint با استفاده از Aspose.Slides برای .NET گروه‌بندی و جداسازی کنید—راهنمای سریع قدم به قدم با کد رایگان C#."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با اشکال گروهی در Aspose.Slides کار کنید. نشان می‌دهد چگونه یک شکل گروهی به یک اسلاید اضافه کنید، اشکال را داخل آن قرار دهید و ارائه به‌روزشده را ذخیره کنید. همچنین نحوه دسترسی به اشکالی که داخل یک گروه ذخیره شده‌اند و خواندن مقدار `AlternativeText` آنها را نشان می‌دهد. به‌علاوه، به‌صورت خلاصه به قابلیت‌های مرتبط با اشکال گروهی مانند گروه‌های تو در تو، ترتیب Z و گزینه‌های قفل‌گذاری می‌پردازد.

## **افزودن یک شکل گروهی**
Aspose.Slides پشتیبانی از کار با اشکال گروهی در اسلایدها را فراهم می‌کند. این ویژگی به توسعه‌دهندگان کمک می‌کند ارائه‌های غنی‌تری ایجاد کنند. Aspose.Slides for .NET از افزودن یا دسترسی به اشکال گروهی پشتیبانی می‌کند. می‌توانید اشکال را به یک شکل گروهی اضافه شده اضافه کنید تا آن را پر کنید یا به هر ویژگی از شکل گروهی دسترسی پیدا کنید. برای افزودن یک شکل گروهی به یک اسلاید با استفاده از Aspose.Slides for .NET:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
1. یک شکل گروهی به اسلاید اضافه کنید.
1. اشکال را به شکل گروهی اضافه شده اضافه کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به یک اسلاید اضافه می‌کند.

```c#
// نمونه‌سازی کلاس Presentation 
using (Presentation pres = new Presentation())
{
    // دست‌یابی به اولین اسلاید 
    ISlide sld = pres.Slides[0];

    // دسترسی به مجموعه اشکال اسلایدها 
    IShapeCollection slideShapes = sld.Shapes;

    // افزودن یک شکل گروهی به اسلاید 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // افزودن اشکال به داخل شکل گروهی اضافه‌شده 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // افزودن قاب شکل گروهی 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // نوشتن فایل PPTX بر روی دیسک 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **دسترسی به ویژگی AltText**
این بخش گام‌های ساده‌ای همراه با مثال‌های کد را برای افزودن یک شکل گروهی و دسترسی به ویژگی AltText اشکال گروهی در اسلایدها نشان می‌دهد. برای دسترسی به AltText یک شکل گروهی در اسلاید با استفاده از Aspose.Slides for .NET:

1. نمونه‌ای از کلاس `Presentation` که نمایانگر فایل PPTX است ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
1. به مجموعه اشکال اسلایدها دسترسی پیدا کنید.
1. به شکل گروهی دسترسی پیدا کنید.
1. به ویژگی AltText دسترسی پیدا کنید.

مثال زیر متن جایگزین شکل گروهی را می‌خواند.

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation("AltText.pptx");

// دریافت اولین اسلاید
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // دسترسی به مجموعه اشکال اسلایدها
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // دسترسی به شکل گروهی.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // دسترسی به ویژگی AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **سؤالات متداول**

**آیا گروه‌بندی تو در تو (یک گروه داخل گروه) پشتیبانی می‌شود؟**

بله. [GroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/groupshape/) دارای ویژگی [ParentGroup](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/parentgroup/) است که مستقیماً پشتیبانی از سلسله‌مراتب را نشان می‌دهد (یک گروه می‌تواند زیرمجموعه گروه دیگری باشد).

**چگونه ترتیب Z گروه را نسبت به سایر اشیاء روی اسلاید کنترل کنم؟**

از ویژگی [ZOrderPosition](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/zorderposition/) در [GroupShape](https://reference.aspose.com/slides/fa/net/aspose.slides/groupshape/) استفاده کنید تا موقعیت آن را در پشته نمایش بررسی کنید.

**آیا می‌توانم از جابه‌جایی/ویرایش/لغو گروه‌برداری جلوگیری کنم؟**

بله. بخش قفل‌گذاری گروه از طریق [GroupShapeLock](https://reference.aspose.com/slides/fa/net/aspose.slides/groupshape/groupshapelock/) در دسترس است که امکان محدود کردن عملیات بر روی شیء را فراهم می‌کند.