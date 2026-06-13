---
title: مدیریت اشیاء جوهر ارائه در جاوااسکریپت
linktitle: مدیریت جوهر
type: docs
weight: 95
url: /fa/nodejs-java/manage-ink/
keywords:
- جوهر
- شیء جوهر
- رد جوهر
- مدیریت جوهر
- رسم جوهر
- رسم
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "مدیریت اشیاء جوهر PowerPoint — ایجاد، ویرایش و استایل‌گذاری جوهر دیجیتال با Aspose.Slides برای Node.js. دریافت نمونه‌های کد جاوااسکریپت برای ردها، رنگ و اندازه براش."
---
## **مقدمه**

PowerPoint عملکرد جوهری (ink) را فراهم می‌کند تا بتوانید اشکال غیر استاندارد را رسم کنید که می‌توانند برای برجسته‌سازی اشیاء دیگر، نشان دادن اتصالات و فرآیندها، و جلب توجه به موارد خاص در یک اسلاید استفاده شوند.

Aspose.Slides تمام انواع جوهر (به عنوان مثال کلاس [Ink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ink/)) مورد نیاز برای ایجاد و مدیریت اشیای جوهری را فراهم می‌کند.

## **تفاوت بین شیء معمولی و اشیاء جوهری**

اشیاء روی یک اسلاید PowerPoint معمولاً توسط شیءهای شکل (shape) نمایان می‌شوند. یک شیء شکل، در ساده‌ترین شکل خود، یک محفظه است که ناحیهٔ خود شیء (قاب آن) را به همراه ویژگی‌هایش تعریف می‌کند. این ویژگی‌ها شامل اندازهٔ ناحیهٔ محفظه، شکل محفظه، پس‌زمینهٔ محفظه و غیره می‌شود. برای اطلاعات بیشتر، به [Shape Layout Format](https://docs.aspose.com/slides/fa/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) مراجعه کنید.

اما وقتی PowerPoint با یک شیء جوهری سروکار دارد، تمام ویژگی‌های قاب شیء (محفظه) به جز اندازهٔ آن را نادیده می‌گیرد. اندازهٔ ناحیهٔ محفظه توسط مقادیر استاندارد `width` و `height` تعیین می‌شود:

![ink_powerpoint1](ink_powerpoint1.png)

## **Traceهای Inkshape**

Trace یک عنصر پایه یا استاندارد برای ثبت مسیر قلم هنگام نوشتن جوهر دیجیتال است. Traceها ضبط‌هایی هستند که توالی نقاط متصل را توصیف می‌کنند.

ساده‌ترین شکل کدگذاری، مختصات X و Y هر نقطهٔ نمونه را مشخص می‌کند. وقتی تمام نقاط متصل رندر شوند، تصویری شبیه به این ایجاد می‌شود:

![ink_powerpoint2](ink_powerpoint2.png)

## ویژگی‌های Brush برای رسم

می‌توانید از یک brush برای رسم خطوطی که نقاط عناصر trace را به هم متصل می‌کند، استفاده کنید. brush دارای رنگ و اندازهٔ خاص خود است که با متدهای `Brush.setColor` و `Brush.setSize` تنظیم می‌شوند.

### **تنظیم رنگ Brush جوهر**

این کد JavaScript نشان می‌دهد چگونه می‌توانید رنگ یک brush را تنظیم کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushColor = brush.getColor();
    brush.setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تنظیم اندازه Brush جوهر**

این کد JavaScript نشان می‌دهد چگونه می‌توانید اندازهٔ یک brush را تنظیم کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var ink = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var traces = ink.getTraces();
    var brush = traces[0].getBrush();
    var brushSize = brush.getSize();
    brush.setSize(java.newInstanceSync("java.awt.Dimension", 5, 10));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

به طور کلی، عرض و ارتفاع یک brush مطابقت ندارند، بنابراین PowerPoint اندازهٔ brush را نشان نمی‌دهد (بخش داده‌ها خاکستری است). اما وقتی عرض و ارتفاع brush مطابقت داشته باشند، PowerPoint اندازهٔ آن را به این شکل نمایش می‌دهد:

![ink_powerpoint3](ink_powerpoint3.png)

برای وضوح بیشتر، ارتفاع شیء جوهری را افزایش می‌دهیم و ابعاد مهم را مرور می‌کنیم:

![ink_powerpoint4](ink_powerpoint4.png)

محفظه (قاب) اندازهٔ brushها را در نظر نمی‌گیرد—همیشه فرض می‌کند ضخامت خط صفر است (به تصویر آخر نگاه کنید).

بنابراین، برای تعیین ناحیهٔ قابل مشاهدهٔ کل شیء جوهری، باید اندازهٔ brushهای اشیای trace را در نظر بگیریم. در اینجا، شیء هدف (شیء trace متن دست‌نویس) به اندازهٔ محفظه (قاب) مقیاس داده شده است. وقتی اندازهٔ محفظه (قاب) تغییر می‌کند، اندازهٔ brush ثابت می‌ماند و بالعکس.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint هنگام کار با متن‌ها همان رفتار را نشان می‌دهد:

![ink_powerpoint6](ink_powerpoint6.png)

**مطالعهٔ بیشتر**

* برای مطالعهٔ کلی دربارهٔ اشکال، بخش [PowerPoint Shapes](https://docs.aspose.com/slides/fa/nodejs-java/powerpoint-shapes/) را ببینید.
* برای اطلاعات بیشتر دربارهٔ مقادیر مؤثر، به [Shape Effective Properties](https://docs.aspose.com/slides/fa/nodejs-java/shape-effective-properties/#getting-effective-font-height-value) مراجعه کنید.