---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از جاوا اسکریپت
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/nodejs-java/managing-tags-and-custom-data/
keywords:
- خواص سند
- برچسب
- داده‌های سفارشی
- اضافه کردن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "نحوه افزودن، خواندن، به‌روزرسانی و حذف برچسب‌ها و داده‌های سفارشی در Aspose.Slides برای Node.js را یاد بگیرید، به همراه مثال‌هایی برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. به‌صورت خلاصه نحوه ذخیره‌سازی داده‌ها در فایل‌های PPTX را شرح می‌دهد، اشاره می‌کند که داده‌های خاص ارائه می‌توانند به‌صورت برچسب‌ها و بخش‌های XML سفارشی وجود داشته باشند، و برچسب‌ها را به‌عنوان جفت‌های کلید‑مقدار رشته‌ای توصیف می‌کند.

همچنین نشان می‌دهد چگونه مقادیر برچسب‌ها را بخوانید و چگونه برچسب‌ها را به یک ارائه، یک اسلاید جداگانه یا یک شکل اضافه کنید. علاوه بر این، مقاله به وظایف معمول مدیریت برچسب‌ها مانند پاک کردن تمام برچسب‌ها، حذف یک برچسب بر اساس نام، و بازیابی فهرست نام‌های برچسب می‌پردازد.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX—آیتم‌هایی با پسوند .pptx—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصه Office Open XML است. فرمت Office Open XML ساختار داده‌های موجود در ارائه‌ها را تعریف می‌کند.

با داشتن *اسلاید* به‌عنوان یکی از عناصر ارائه، *بخش اسلاید* شامل محتوای یک اسلاید منفرد است. یک بخش اسلاید می‌تواند روابط صریحی با بسیاری از بخش‌ها—مانند برچسب‌های تعریف‌شده توسط کاربر—داشته باشد که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی (خاص یک ارائه) یا کاربر می‌توانند به‌صورت برچسب‌ها ([TagCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TagCollection)) و بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/CustomXmlPartCollection)) وجود داشته باشند.

{{% alert color="primary" %}} 
برچسب‌ها در اصل مقادیر جفت کلید‑رشته‌ای هستند. 
{{% /alert %}} 

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل متدهای [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) و [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Node.js از طریق Java برای [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) دریافت کنید:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **اضافه کردن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً از دو مورد تشکیل می‌شود:

- نام یک ویژگی سفارشی - `MyTag`
- مقدار ویژگی سفارشی - `My Tag Value`

اگر نیاز دارید برخی ارائه‌ها را بر اساس یک قانون یا ویژگی خاص طبقه‌بندی کنید، می‌توانید از اضافه کردن برچسب‌ها به آن ارائه‌ها بهره ببرید. به‌عنوان مثال، اگر می‌خواهید تمام ارائه‌های کشورهای آمریکای شمالی را همراه هم قرار دهید، می‌توانید یک برچسب “North American” ایجاد کنید و سپس کشورهای مربوطه (ایالات متحده، مکزیک و کانادا) را به‌عنوان مقادیر آن اختصاص دهید.

این کد نمونه نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation) اضافه کنید با استفاده از Aspose.Slides برای Node.js از طریق Java:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

برچسب‌ها همچنین می‌توانند برای [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Slide) تنظیم شوند:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

یا هر [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/AutoShape) فردی:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه برچسب‌های داده سفارشی با استفاده از `getCustomData().getTags()` اضافه می‌شوند، فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادر کردن ارائه به PDF منتقل نمی‌شوند. در نتیجه، یک شناسه سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید یک شناسه سفارشی را در **متن Alt** شیء ذخیره کنید (مثلاً `shape.setAlternativeText("MyId")`). پس از صادرات به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [tag collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/clear/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را به‌صورت یکجا حذف می‌‍کند.

**چگونه می‌توان یک برچسب واحد را بر پایه نام آن بدون پیمایش کل مجموعه حذف کرد؟**

از عملیات [remove(name)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/remove/) بر روی [TagCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر پایه کلید آن حذف کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تحلیل یا فیلترگیری بازیابی کنم؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) بر روی [tag collection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.