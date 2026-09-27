---
title: ایجاد ارائه‌ها در جاوا
linktitle: ایجاد ارائه
type: docs
weight: 10
url: /fa/java/create-presentation/
keywords:
- ایجاد ارائه
- ارائه جدید
- ایجاد PPT
- PPT جدید
- ایجاد PPTX
- PPTX جدید
- ایجاد ODP
- ODP جدید
- پاورپوینت
- اسناد باز
- ارائه
- جاوا
- Aspose.Slides
description: "در جاوا با Aspose.Slides ارائه‌ها را ایجاد کنید—فایل‌های PPT، PPTX و ODP تولید کنید، از پشتیبانی OpenDocument بهره‌مند شوید و آن‌ها را به‌صورت برنامه‌نویسی ذخیره کنید تا نتایج قابل اعتمادی به دست آورید."
---
## **بررسی کلی**

این مقاله نشان می‌دهد چگونه یک ارائه در Aspose.Slides ایجاد کنید، یک شکل با متن به اسلاید اول آن اضافه کنید و نتیجه را به صورت فایل PPTX ذخیره کنید. برای باز کردن یک ارائه موجود و ذخیره آن در قالب دیگری، به [Open Presentations](/slides/fa/java/open-presentation/) و [Save Presentations](/slides/fa/java/save-presentation/) مراجعه کنید. یک بخش کوتاه پرسش‌های متداول در انتها به سؤالات رایج درباره قالب‌ها، الگوها، اندازه‌گیری اسلاید، واحدها، مصرف حافظه، چندنخی‌سازی، مجوزها، امضای دیجیتال و پشتیبانی VBA می‌پردازد.

قبل از شروع، Aspose.Slides for Java را از مخزن Maven آسپوز به پروژه خود اضافه کنید. برای تنظیم Maven و نیازهای اضافی لینوکس به [Installation](/slides/fa/java/installation/) مراجعه کنید.

## **ایجاد یک ارائه**

ایجاد یک فایل PowerPoint از صفر در Aspose.Slides for Java با یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) شروع می‌شود. سازنده یک ارائه خالی با یک اسلاید واحد فراهم می‌کند که برای اشکال، متن، نمودارها یا هر محتوای دیگری که برنامه شما نیاز دارد، آماده است. پس از ویرایش آن اسلاید یا افزودن اسلایدهای جدید، می‌توانید نتیجه را به قالب‌های PPTX، PPT قدیمی یا OpenDocument ذخیره کنید.

برای ایجاد یک ارائه و قرار دادن یک شکل با متن در اسلاید اول، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید. یک ارائه جدید قبلاً یک اسلاید خالی دارد.
2. آن اسلاید را با اندیس 0 از مجموعه‌ای که [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) برمی‌گرداند، دریافت کنید.
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) از نوع `Cloud` را با متد [addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) اضافه کنید و متن آن را با متد [setText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#setText-java.lang.String-) تنظیم کنید.
4. ارائه را به عنوان یک فایل PPTX با متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره کنید.

مثال زیر یک برنامه کامل است. در پروژه Maven از [Installation](/slides/fa/java/installation/)، آن را به عنوان *src/main/java/HelloSlides.java* ذخیره کنید و `mvn compile exec:java` را اجرا کنید.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // یک ارائه ایجاد می‌کند. از پیش شامل یک اسلاید خالی است.
        Presentation presentation = new Presentation();
        try {
            // اولین اسلاید را دریافت می‌کند.
            ISlide slide = presentation.getSlides().get_Item(0);

            // یک شکل ابر اضافه می‌کند و متن داخل آن را قرار می‌دهد.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // ارائه را به عنوان فایل PPTX ذخیره می‌کند.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

گوشه بالای چپ ابر 20 نقطه از لبه چپ و 20 نقطه از لبه بالای اسلاید فاصله دارد و شکل 200 نقطه عرض و 80 نقطه ارتفاع دارد. برنامه *new_presentation.pptx* را با یک اسلاید که ابر و متن آن را نگه می‌دارد، ذخیره می‌کند. بدون داشتن مجوز، Aspose.Slides همچنین یک واترمارک ارزیابی به هر اسلاید ذخیره شده اضافه می‌کند؛ به [Licensing](/slides/fa/java/licensing/) مراجعه کنید.

نتیجه:

![ارائه جدید](new_presentation.png)

## **پرسش‌های متداول**

### چه قالب‌هایی را می‌توانم برای ذخیره یک ارائه جدید استفاده کنم؟

می‌توانید به [PPTX, PPT و ODP](/slides/fa/java/save-presentation/) ذخیره کنید و به [PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، [XPS](/slides/fa/java/convert-powerpoint-to-xps/)، [HTML](/slides/fa/java/convert-powerpoint-to-html/)، [SVG](/slides/fa/java/render-a-slide-as-an-svg-image/) و [تصاویر](/slides/fa/java/convert-powerpoint-to-png/) صادر کنید.

### آیا می‌توانم از یک الگو (POTX/POTM) شروع کنم و به عنوان یک PPTX معمولی ذخیره کنم؟

بله. الگو را بارگذاری کنید و به قالب مورد نظر ذخیره کنید؛ قالب‌های POTX/POTM/PPTM و قالب‌های مشابه [پشتیبانی می‌شوند](/slides/fa/java/supported-file-formats/).

### چگونه می‌توانم هنگام ایجاد ارائه، اندازه/نسبت تصویر اسلاید را کنترل کنم؟

[اندازه اسلاید](/slides/fa/java/slide-size/) را تنظیم کنید (شامل پیش‌ تنظیمات مثل 4:3 و 16:9 یا ابعاد سفارشی) و انتخاب کنید که محتوا چگونه مقیاس‌بندی شود.

### ابعاد و مختصات بر حسب چه واحدی اندازه‌گیری می‌شوند؟

بر حسب نقطه: 1 اینچ برابر با 72 نقطه است.

### چگونه می‌توانم ارائه‌های بسیار بزرگ (با تعداد زیادی فایل رسانه) را برای کاهش مصرف حافظه مدیریت کنم؟

از [استراتژی‌های مدیریت BLOB](/slides/fa/java/manage-blob/) استفاده کنید، ذخیره در حافظه را با بهره‌گیری از فایل‌های موقت محدود کنید و به جای جریان‌های صرفاً در‑حافظه، گردش کار مبتنی بر فایل را ترجیح دهید.

### آیا می‌توانم ارائه‌ها را به صورت همزمان ایجاد/ذخیره کنم؟

نمی‌توانید به یک نمونه [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) از [چندین نخ](/slides/fa/java/multithreading/) به طور همزمان عمل کنید. برای هر نخ یا فرآیند یک نمونه جداگانه و ایزوله ایجاد کنید.

### چگونه می‌توانم واترمارک آزمایشی و محدودیت‌ها را حذف کنم؟

یک بار در هر فرآیند [مجوز را اعمال](/slides/fa/java/licensing/) کنید. XML مجوز باید بدون تغییر باقی بماند و تنظیم مجوز در صورت استفاده از چندین نخ باید همگام‌سازی شود.

### آیا می‌توانم PPTX ایجاد شده را دیجیتally امضا کنم؟

بله. [امضای دیجیتال](/slides/fa/java/digital-signature-in-powerpoint/) (افزودن و تأیید) برای ارائه‌ها پشتیبانی می‌شود.

### آیا ماکروها (VBA) در ارائه‌های ایجاد شده پشتیبانی می‌شوند؟

بله. می‌توانید [پروژه‌های VBA را ایجاد/ویرایش](/slides/fa/java/presentation-via-vba/) کنید و فایل‌های فعال‌سازی ماکرو مانند PPTM/PPSM را ذخیره نمایید.