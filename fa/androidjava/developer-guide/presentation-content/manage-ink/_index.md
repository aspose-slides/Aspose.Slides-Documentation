---
title: مدیریت اشیاء مرکب ارائه در اندروید
linktitle: مدیریت مرکب
type: docs
weight: 95
url: /fa/androidjava/manage-ink/
keywords:
- مرکب
- شیء مرکب
- ردیاب مرکب
- مدیریت مرکب
- رسم مرکب
- رسم
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت اشیاء مرکب PowerPoint — ایجاد، ویرایش و استایل‌دهی به مرکب دیجیتال با Aspose.Slides برای Android. دریافت نمونه‌های کد Java برای ردیاب‌ها، رنگ و اندازهٔ قلم."
---
## **مقدمه**

PowerPoint عملکرد مرکب (ink) را فراهم می‌کند تا بتوانید شکل‌های غیر استاندارد رسم کنید؛ این قابلیت می‌تواند برای برجسته کردن اشیاء دیگر، نشان دادن اتصالات و فرآیندها و جلب توجه به موارد خاص در یک اسلاید استفاده شود.

Aspose.Slides تمام انواع Ink (به‌عنوان مثال کلاس [Ink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ink/)) را که برای ایجاد و مدیریت اشیاء مرکب نیاز دارید، ارائه می‌دهد.

## **تفاوت بین اشیاء معمولی و اشیاء مرکب**

اشیاء در یک اسلاید PowerPoint معمولاً توسط اشیاء شکل (shape) نمایش داده می‌شوند. یک شیء شکل، در ساده‌ترین شکل خود، یک محفظه است که ناحیهٔ خود شیء (قاب آن) را به همراه ویژگی‌هایش تعریف می‌کند. ویژگی‌ها شامل اندازهٔ ناحیهٔ محفظه، شکل محفظه، پس‌زمینهٔ محفظه و غیره می‌شود. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/androidjava/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

با این حال، وقتی PowerPoint با یک شیء مرکب سروکار دارد، تمام ویژگی‌های قاب شیء (محفظه) را به جز اندازهٔ آن نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **ردیاب‌های Inkshape**

ردیاب (Trace) یک عنصر پایه یا استاندارد برای ضبط مسیر قلم هنگام نوشتن مرکب دیجیتال توسط کاربر است. ردیاب‌ها ضبط‌هایی هستند که توالی نقاط متصل را توصیف می‌کنند.

ساده‌ترین روش رمزگذاری، مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری مشابه زیر تولید می‌کنند:

![ink_powerpoint2](ink_powerpoint2.png)

## **ویژگی‌های قلم برای رسم**

می‌توانید از یک قلم برای رسم خطوطی که نقاط عناصر ردیاب را به هم متصل می‌کند، استفاده کنید. قلم دارای رنگ و اندازهٔ خود است که به ویژگی‌های `Brush.Color` و `Brush.Size` مربوط می‌شود.

### **تنظیم رنگ قلم مرکب**

این کد Java نشان می‌دهد چگونه رنگ یک قلم را تنظیم کنید:

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

### **تنظیم اندازه قلم مرکب**

این کد Java نشان می‌دهد چگونه اندازهٔ یک قلم را تنظیم کنید:

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

به طور کلی، عرض و ارتفاع یک قلم برابر نیست، به همین دلیل PowerPoint اندازهٔ قلم را نمایش نمی‌دهد (بخش داده‌ها خاکستری می‌شود). اما وقتی عرض و ارتفاع قلم برابر باشند، PowerPoint اندازهٔ آن را به این شکل نشان می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء مرکب را افزایش می‌دهیم و ابعاد مهم را بررسی می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ قلم‌ها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر آخر نگاه کنید).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء مرکب، باید اندازهٔ قلم‌های اشیاء ردیاب را در نظر بگیریم. در اینجا، شیء هدف (شیء ردیاب متن دست‌نویس) به اندازهٔ محفظه (قاب) مقیاس‌بندی شده است. وقتی اندازهٔ محفظه (قاب) تغییر می‌کند، اندازهٔ قلم ثابت می‌ماند و برعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint این رفتار را هنگام کار با متن نیز نشان می‌دهد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعهٔ بیشتر**

* برای مطالعهٔ کلی دربارهٔ شکل‌ها، به بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/androidjava/powerpoint-shapes/) مراجعه کنید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/androidjava/shape-effective-properties/#getting-effective-font-height-value) نگاهی بیندازید.