---
title: ساخت ارائه‌ها در جاوا اسکریپت
linktitle: ساخت ارائه
type: docs
weight: 10
url: /fa/nodejs-java/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "ایجاد ارائه‌ها با Aspose.Slides—تولید فایل‌های PPT، PPTX و ODP، بهره‌مندی از پشتیبانی OpenDocument، و ذخیره برنامه‌نویسی‌شده آن‌ها برای نتایج قابل اطمینان."
---
## **مروری کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، یک جعبه متن به اسلاید اول آن اضافه کنید و نتیجه را به‌صورت یک فایل ذخیره کنید.

قبل از شروع، بسته `aspose.slides.via.java` را از npm نصب کنید، به همراه JDK، Python و ابزارهای ساخت C++ که نیاز دارد. برای توضیحات بیشتر به [Installation](/slides/fa/nodejs-java/installation/) مراجعه کنید.

## **ایجاد یک ارائهٔ پاورپوینت**

برای ایجاد یک ارائه و قرار دادن یک جعبهٔ متن بر روی اسلاید اول آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ایجاد کنید. یک ارائهٔ جدید قبلاً شامل یک اسلاید خالی است.
2. آن اسلاید را از [slide collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) با اندیس 0 دریافت کنید.
3. یک مستطیل را با متد [addAutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addautoshape/) اضافه کنید و متن آن را با [setText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/settext/) تنظیم کنید.
4. ارائه را به‌عنوان فایل PPTX با متد [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) ذخیره کنید.
5. ارائه را با متد [dispose](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/dispose/) آزاد کنید و فرآیند را خاتمه دهید.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides در یک ماشین مجازی جاوا اجرا می‌شود که Node.js را در حال اجرا نگه می‌دارد، بنابراین فرآیند را به صراحت پایان دهید.
process.exit(0);
```

گوشهٔ بالا‑چپ مستطیل ۵۰ پوینت از لبهٔ چپ و ۵۰ پوینت از لبهٔ بالای اسلاید فاصله دارد و مستطیل عرض ۴۰۰ پوینت و ارتفاع ۱۰۰ پوینت دارد. کد را به‌نام *hello.js* در پوشهٔ پروژهٔ خود ذخیره کنید و `node hello.js` را اجرا کنید: این دستور *hello.pptx* را ذخیره می‌کند که شامل یک اسلاید حاوی آن مستطیل و متن آن است، در پوشهٔ فعلی.

Aspose.Slides در یک ماشین مجازی جاوا اجرا می‌شود که بستهٔ `java` داخل فرآیند Node.js آن را راه‌اندازی می‌کند. این ماشین مجازی باعث می‌شود Node.js پس از اتمام اسکریپت به‌طور خودکار خارج نشود، بنابراین مثال با `process.exit(0)` پایان می‌یابد.

بدون لایسنس، Aspose.Slides همچنین یک watermark ارزیابی را به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ به [Licensing](/slides/fa/nodejs-java/licensing/) مراجعه کنید.

## **سوالات متداول**

### کدام قالب‌ها را می‌توانم برای ذخیرهٔ یک ارائهٔ جدید استفاده کنم؟

می‌توانید به قالب‌های [PPTX, PPT, and ODP](/slides/fa/nodejs-java/save-presentation/) ذخیره کنید و به قالب‌های [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/nodejs-java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/)، [SVG](/slides/fa/nodejs-java/render-a-slide-as-an-svg-image/) و [images](/slides/fa/nodejs-java/convert-powerpoint-to-png/) (و دیگران) صادر کنید.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کرده و به‌صورت PPTX معمولی ذخیره کنم؟

بله. الگو را بارگذاری کنید و به قالب موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و قالب‌های مشابه [پشتیبانی می‌شوند](/slides/fa/nodejs-java/supported-file-formats/).

### چگونه می‌توانم اندازهٔ اسلاید/نسبت تصویر را هنگام ایجاد یک ارائه کنترل کنم؟

اندازه اسلاید را تنظیم کنید [اندازه اسلاید](/slides/fa/nodejs-java/slide-size/) (شامل پیش‌تنظیم‌های ۴:۳ و ۱۶:۹ یا ابعاد سفارشی) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

### اندازه‌ها و مختصات به چه واحدی اندازه‌گیری می‌شوند؟

در واحد پوینت: ۱ اینچ معادل ۷۲ واحد است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیادی فایل رسانه) را برای کاهش مصرف حافظه مدیریت کنم؟

از [BLOB management strategies](/slides/fa/nodejs-java/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به‌جای جریان‌های صرفاً در‑حافظه، گردش کار مبتنی بر فایل را ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید بر روی همان نمونهٔ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) از [multiple threads](/slides/fa/nodejs-java/multithreading/) عمل کنید. برای هر رشته یا فرآیند، نمونه‌های جداگانه و ایزوله اجرا کنید.

### چگونه می‌توانم watermark آزمایشی و محدودیت‌ها را حذف کنم؟

[اعمال لایسنس](/slides/fa/nodejs-java/licensing/) را یک‌بار برای هر فرآیند اعمال کنید. XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس در صورت وجود چندین رشته باید هم‌زمانی شود.

### آیا می‌توانم فایل PPTX ایجاد شده را دیجیتally امضا کنم؟

بله. [Digital signatures](/slides/fa/nodejs-java/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/nodejs-java/presentation-via-vba/) را انجام دهید و فایل‌های دارای ماکرو مانند PPTM/PPSM را ذخیره کنید.