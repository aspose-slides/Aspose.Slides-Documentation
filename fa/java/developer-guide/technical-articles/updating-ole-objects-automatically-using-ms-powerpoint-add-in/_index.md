---
title: به‌روزرسانی خودکار اشیاء OLE با استفاده از افزونه PowerPoint
type: docs
weight: 10
url: /fa/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE object
- به‌روزرسانی OLE
- به‌طور خودکار
- افزونه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توان نمودارها و اشیاء OLE را در PowerPoint به‌صورت خودکار با استفاده از یک افزونه و Aspose.Slides برای Java به‌روزرسانی کرد، همراه با نمونه کدهای عملی و نکات بهینه‌سازی."
---
## **معرفی**

یکی از متداول‌ترین سؤالاتی که مشتریان Aspose.Slides برای Java می‌پرسند، این است که چگونه نمودارهای قابل ویرایش (یا سایر اشیاء OLE) را ایجاد یا تغییر دهند تا هنگام باز شدن ارائه به‌صورت خودکار به‌روزرسانی شوند. متأسفانه PowerPoint به همان شیوه‌ای که Excel و Word دارند، ماکروهای خودکار را پشتیبانی نمی‌کند. تنها ماکروهای موجود `Auto_Open` و `Auto_Close` هستند و اینها فقط به‌صورت خودکار از یک افزونه اجرا می‌شوند. این نکته فنی کوتاه نشان می‌دهد چگونه این کار را انجام داد.

## **به‌روزرسانی خودکار اشیاء OLE**

در ابتدا، چندین افزونه رایگان وجود دارند که قابلیت ماکرو Auto_Open را به PowerPoint اضافه می‌کنند، برای نمونه [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) و [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

پس از نصب یکی از این افزونه‌ها، به‌سادگی ماکرو `Auto_Open()` (یا `OnPresentationOpen()` اگر از Event Generator استفاده می‌کنید) را به ارائه قالب خود همان‌طور که در زیر نشان داده شده اضافه کنید:

```java
// پیمایش هر اسلاید در ارائه.
for (var oSlide : ActivePresentation.Slides) {
    // پیمایش تمام اشکال در اسلاید فعلی.
    for (var oShape : oSlide.Shapes) {
        // بررسی اینکه آیا شکل یک شیء OLE است.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // یک شیء OLE یافت شد. مرجع آن را دریافت کنید و سپس به‌روز کنید.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // اکنون برنامه سرور OLE را خاتمه دهید.
            // این کار حافظه را آزاد می‌کند و از بروز مشکلات جلوگیری می‌کند.
            // همچنین oObject را به Nothing تنظیم کنید تا شیء آزاد شود.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```

هر تغییری که روی اشیاء OLE با Aspose.Slides برای Java اعمال شود، به‌صورت خودکار هنگام باز شدن ارائه توسط PowerPoint به‌روزرسانی می‌شود. اگر تعداد زیادی اشیاء OLE دارید و نمی‌خواهید همه آن‌ها را به‌روزرسانی کنید، به‌سادگی یک برچسب سفارشی به شکل‌هایی که نیاز به پردازش دارند اضافه کنید و در ماکرو آن را بررسی کنید.