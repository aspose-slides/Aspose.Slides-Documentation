---
title: ایجاد ارائه‌ها در اندروید
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "ارائه‌ها را در جاوا با Aspose.Slides برای اندروید ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی OpenDocument بهره‌مند شوید و آنها را به‌صورت برنامه‌نویسی‌شده ذخیره کنید تا نتایج قابل اعتماد به‌دست آورید."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides برای Android از طریق Java ایجاد کنید، یک جعبه متن به اولین اسلاید آن اضافه کنید و نتیجه را به‌عنوان فایلی در حافظهٔ برنامه‌تان ذخیره کنید. برای باز کردن یک ارائهٔ موجود یا ذخیرهٔ آن در قالب دیگری، به [Open Presentation](/slides/fa/androidjava/open-presentation/) و [Save Presentation](/slides/fa/androidjava/save-presentation/) مراجعه کنید. یک سؤال‌نامهٔ کوتاه در انتها به سؤالات رایج دربارهٔ قالب‌ها، الگوها، اندازه‌گذاری اسلاید، واحدها، مصرف حافظه، چندنخی، مجوزدهی، امضای دیجیتال و پشتیبانی از VBA می‌پردازد.

قبل از شروع، Aspose.Slides را از مخزن Maven Aspose به پروژهٔ Android خود اضافه کنید. ببینید [Installation](/slides/fa/androidjava/install-aspose-slides-for-android-via-java/).

## **ایجاد یک ارائهٔ پاورپوینت**

برای ایجاد یک ارائه و قرار دادن یک جعبه متن بر روی اولین اسلاید آن، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید. یک ارائهٔ جدید از قبل شامل یک اسلاید خالی است.  
2. آن اسلاید را از [slide collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) با استفاده از اندیس 0 دریافت کنید.  
3. یک مستطیل با روش [addAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) از [shape collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) اضافه کنید و متن [text frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) آن را با روش [setText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) تنظیم کنید.  
4. ارائه را به‌عنوان فایل PPTX با روش [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-)، در قالب [SaveFormat.Pptx](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveformat/) ذخیره کنید.

کد داخل یک `Activity` اجرا می‌شود، برای مثال در متد `onCreate` آن. این کد فایل را در دایرکتوری‌ای که توسط متد [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) برگردانده می‌شود ذخیره می‌کند: حافظهٔ خصوصی برنامهٔ شما که بدون درخواست هیچ‌گونه مجوزی می‌تواند به آن نوشت.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

بالا‑چپ مستطیل 50 نقطه از لبهٔ چپ و 50 نقطه از لبهٔ بالا اسلاید فاصله دارد و عرض آن 400 نقطه و ارتفاع 100 نقطه است. فایل ذخیره‌شده شامل یک اسلاید با آن مستطیل و متن آن است. بدون داشتن لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی به هر اسلایدی که ذخیره می‌کند اضافه می‌کند؛ ببینید [Licensing](/slides/fa/androidjava/licensing/).

برای مشاهدهٔ فایل، [Device Explorer] در Android Studio را باز کنید و *hello.pptx* را در زیر پوشهٔ *data/data/*، در پوشهٔ *files* برنامه‌تان پیدا کنید. در یک برنامهٔ واقعی، پردازش ارائه‌ها را روی یک رشتهٔ پس‌زمینه انجام دهید تا رابط کاربری پاسخگو بماند.

## **سوالات متداول**

### چه قالب‌هایی می‌توانم یک ارائهٔ جدید را در آن ذخیره کنم؟

می‌توانید به قالب‌های [PPTX, PPT, و ODP](/slides/fa/androidjava/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/)، [SVG](/slides/fa/androidjava/render-a-slide-as-an-svg-image/) و [images](/slides/fa/androidjava/convert-powerpoint-to-png/) تبدیل کنید، و غیره.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کرده و به‌صورت PPTX معمولی ذخیره کنم؟

بله. الگو را بارگذاری کنید و در قالب موردنظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و مشابه آن‌ها [are supported](/slides/fa/androidjava/supported-file-formats/).

### چگونه هنگام ایجاد یک ارائه، اندازه/نسبت‌عرض به‌ارتفاع اسلاید را کنترل کنم؟

[slide size](/slides/fa/androidjava/slide-size/) را تنظیم کنید (از جمله پیش‌تنظیم‌های 4:3 و 16:9 یا ابعاد سفارشی) و نحوهٔ مقیاس‌بندی محتوا را انتخاب کنید.

### اندازها و مختصات بر حسب چه واحدی اندازه‌گیری می‌شوند؟

بر حسب نقطه: 1 اینچ برابر 72 واحد است.

### چگونه با ارائه‌های بسیار بزرگ (دارای بسیاری از فایل‌های رسانه‌ای) برای کاهش مصرف حافظه برخورد کنم؟

از [BLOB management strategies](/slides/fa/androidjava/manage-blob/) استفاده کنید، ذخیره‌سازی در حافظه را با استفاده از فایل‌های موقت محدود کنید و جریان‌های مبتنی بر فایل را نسبت به جریان‌های صرفاً در‑حافظه ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به‌صورت موازی ایجاد/ذخیره کنم؟

نمی‌توانید روی همان نمونهٔ [Presentation](/slides/fa/androidjava/presentation/) از [multiple threads](/slides/fa/androidjava/multithreading/) عملیات انجام دهید. برای هر رشته یا پردازش یک نمونهٔ جداگانه و ایزوله اجرا کنید.

### چگونه واترمارک آزمایشی و محدودیت‌ها را حذف کنم؟

[Apply a license](/slides/fa/androidjava/licensing/) را یک‌بار برای هر فرایند اعمال کنید. فایل XML لایسنس باید بدون تغییر باقی بماند و تنظیم لایسنس در صورت وجود چندین رشته باید هماهنگ شود.

### آیا می‌توانم PPTX ایجاد شده را به‌صورت دیجیتالی امضا کنم؟

بله. [Digital signatures](/slides/fa/androidjava/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [create/edit VBA projects](/slides/fa/androidjava/presentation-via-vba/) کنید و فایل‌های ماکروپذیر مانند PPTM/PPSM را ذخیره کنید.