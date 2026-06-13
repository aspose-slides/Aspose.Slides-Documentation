---
title: به‌روزرسانی خودکار اشیاء OLE با استفاده از یک افزونه PowerPoint
type: docs
weight: 10
url: /fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- شیء OLE
- به‌روزرسانی OLE
- به‌صورت خودکار
- افزونه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "کشف کنید چگونه نمودارها و اشیاء OLE را در PowerPoint به‌صورت خودکار با یک افزونه و Aspose.Slides برای .NET به‌روز کنید، به همراه کدهای عملی و نکات بهینه‌سازی."
---
## **مقدمه**

یکی از پر‌سوال‌ترین پرسش‌های مشتریان Aspose.Slides برای .NET این است که چگونه نمودارهای قابل ویرایش (یا سایر اشیاء OLE) را ایجاد یا اصلاح کنند تا هنگام باز شدن ارائه به‌صورت خودکار به‌روز شوند. متأسفانه، PowerPoint ماکروهای خودکار را همانند Excel و Word پشتیبانی نمی‌کند. تنها ماکروهای موجود `Auto_Open` و `Auto_Close` هستند و این ماکروها تنها از طریق یک افزونه به‌صورت خودکار اجرا می‌شوند. این نکته فنی کوتاه نشان می‌دهد چگونه این کار انجام شود.

## **به‌روزرسانی خودکار اشیاء OLE**

اولین، چندین افزونه رایگان وجود دارند که قابلیت ماکرو Auto_Open را به PowerPoint اضافه می‌کنند، به عنوان مثال [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

پس از نصب یکی از این افزونه‌ها، به سادگی ماکرو `Auto_Open()` (یا `OnPresentationOpen()` اگر از Event Generator استفاده می‌کنید) را به ارائه قالب خود اضافه کنید همان‌طور که در زیر نشان داده شده است:

```cs
public void Auto_Open()
{
    // عبور از هر اسلاید در ارائه.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // عبور از تمام اشکال در اسلاید جاری.
        foreach (var oShape in oSlide.Shapes)
        {
            // بررسی کنید آیا شکل یک شیء OLE است.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // یافتن یک شیء OLE. مرجع آن را بگیرید و سپس به‌روزرسانی کنید.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // اکنون برنامه سرور OLE را ببندید.
                // این کار حافظه را آزاد می‌کند و از بروز مشکلات جلوگیری می‌کند.
                // همچنین oObject را به Nothing تنظیم کنید تا شیء آزاد شود.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

هر تغییری که بر روی اشیاء OLE با Aspose.Slides برای .NET اعمال شود، هنگام باز شدن ارائه توسط PowerPoint به‌صورت خودکار به‌روز می‌شود. اگر تعداد زیادی شیء OLE دارید و نمی‌خواهید همهٔ آن‌ها به‌روز شوند، به سادگی یک برچسب سفارشی به اشکالی که باید پردازش شوند اضافه کنید و در ماکرو آن را بررسی کنید.