---
title: مدیریت اشیاء جوهر در ارائه با جاوا
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- ردیاب جوهر
- مدیریت جوهر
- رسم جوهر
- نقاشی
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint — ایجاد، ویرایش و استایل‌گذاری جوهر دیجیتال با Aspose.Slides برای جاوا. دریافت نمونه کد برای ردیاب‌ها، رنگ و اندازه براش."
---
## **مقدمه**

PowerPoint عملکرد قلم (ink) را فراهم می‌کند تا بتوانید اشکال غیر استاندارد رسم کنید که می‌توانند برای برجسته‌سازی سایر اشیاء، نشان دادن اتصال‌ها و فرآیندها، و جلب توجه به آیتم‌های خاص در یک اسلاید استفاده شوند. 

Aspose.Slides تمام انواع Ink (مانند کلاس [Ink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ink/)) را که برای ایجاد و مدیریت اشیاء قلم نیاز دارید، ارائه می‌دهد. 

## **تفاوت‌های اشیاء عادی و اشیاء قلم**

اشیا در یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایان می‌شوند. یک شیء شکل، در ساده‌ترین شکل خود، یک کانتینر است که ناحیه خود شیء (قاب آن) را به همراه ویژگی‌هایش تعریف می‌کند. این ویژگی‌ها شامل اندازه ناحیهٔ کانتینر، شکل کانتینر، پس‌زمینهٔ کانتینر و غیره می‌شود. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

با این حال، وقتی PowerPoint با یک شیء قلم سروکار دارد، تمام ویژگی‌های قاب شیء (کانتینر) را به جز اندازه‌اش نادیده می‌گیرد. اندازهٔ ناحیهٔ کانتینر توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیاب‌های Inkshape**

ردیاب (Trace) یک عنصر پایه یا استانداردی است که برای ثبت مسیر قلم هنگام نوشتن جوهر دیجیتال توسط کاربر استفاده می‌شود. ردیاب‌ها ضبط‌هایی هستند که توالی نقاط متصل را توصیف می‌کنند. 

ساده‌ترین شکل رمزگذاری، مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مشابه زیر تولید می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های براش برای رسم**

می‌توانید از یک براش برای رسم خطوط متصل‌کنندهٔ نقاط عناصر ردیاب استفاده کنید. براش دارای رنگ و اندازهٔ خود است که با ویژگی‌های `Brush.Color` و `Brush.Size` مطابقت دارد. 

### **تنظیم رنگ براش قلم**

این کد Java نشان می‌دهد چگونه رنگ براش را تنظیم کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Color brushColor = brush.getColor();
    brush.setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنظیم اندازهٔ براش قلم** 

این کد Java نشان می‌دهد چگونه اندازهٔ براش را تنظیم کنید:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    IInk ink = (IInk)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IInkTrace[] traces = ink.getTraces();
    IInkBrush brush = traces[0].getBrush();
    Dimension2D brushSize = brush.getSize();
    brush.setSize(new Dimension(5, 10));
} finally {
    if (pres != null) pres.dispose();
}
```

به‌طور کلی، عرض و ارتفاع یک براش هم‌خوانی ندارند، بنابراین PowerPoint اندازهٔ براش را نشان نمی‌دهد (بخش داده‌ها خاکستری می‌شود). اما وقتی عرض و ارتفاع براش برابر باشند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء قلم را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم: 

![ink_powerpoint4](ink_powerpoint4.png)

کانتینر (قاب) اندازهٔ براش‌ها را در نظر نمی‌گیرد--همیشه فرض می‌کند که ضخامت خط صفر است (به تصویر آخر نگاه کنید). 

بنابراین، برای تعیین ناحیه قابل مشاهدهٔ کل شیء قلم، باید اندازهٔ براش اشیاء ردیاب را در نظر بگیریم. در اینجا، شیء هدف (شیء ردیاب متن دست‌نویس) به اندازهٔ کانتینر (قاب) مقیاس‌بندی شده است. زمانی که اندازهٔ کانتینر (قاب) تغییر می‌کند، اندازهٔ براش ثابت می‌ماند و بالعکس. 

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint همین رفتار را هنگام کار با متن‌ها نیز نشان می‌دهد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعهٔ بیشتر**

* برای مطالعهٔ کلی در مورد اشکال، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/java/powerpoint-shapes/) را مشاهده کنید. 
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/java/shape-effective-properties/#getting-effective-font-height-value) مراجعه کنید.