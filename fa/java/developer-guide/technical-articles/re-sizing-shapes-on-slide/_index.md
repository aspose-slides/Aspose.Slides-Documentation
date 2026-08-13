---
title: تغییر اندازه اشکال در اسلایدهای ارائه
type: docs
weight: 110
url: /fa/java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر سایز شکل
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Java تغییر اندازه دهید — تنظیمات چیدمان اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **بررسی اجمالی**

یکی از رایج‌ترین سوالات مشتریان Aspose.Slides for Java این است که چگونه اشکال را به‌گونه‌ای تغییر اندازه دهند که وقتی اندازه اسلاید تغییر می‌کند، داده‌ها قطع نشوند. این مقاله فنی کوتاه نشان می‌دهد چگونه این کار را انجام دهید.

## **تغییر اندازه اشکال**

برای جلوگیری از جابجایی اشکال هنگام تغییر اندازه اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با طرح جدید اسلاید سازگار شوند.

```java
import com.aspose.slides.*;

// فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.ppt");
try {
    // ابعاد اسلاید اصلی را دریافت کنید.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // اندازه اسلاید را بدون مقیاس‌بندی اشکال موجود تغییر دهید.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // اندازه اسلاید جدید را دریافت کنید.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تغییر اندازه و موقعیت اشکال در هر اسلاید.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // مقیاس‌بندی اندازه شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 

جداول نیازی به پردازش ویژه ندارند: تنظیم عرض و ارتفاع جدول، ستون‌ها و ردیف‌های آن را به‌صورت نسبت‌مند مقیاس می‌کند، بنابراین مقیاس‌گذاری دوباره ارتفاع ردیف‌ها و عرض ستون‌ها، نسبت را دو بار اعمال می‌کند.

{{% /alert %}} 

کد بالا فقط اشکال موجود در اسلایدها را تغییر می‌دهد. اسلایدهای اصلی و اسلایدهای طرح‌بندی، شکل‌های خود را دارند، بنابراین هنگامیکه می‌خواهید تمام ارائه به اندازه جدید اسلاید سازگار شود، آن‌ها را نیز مقیاس‌گذاری کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // دریافت اندازه اسلاید اصلی.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // تغییر اندازه اسلاید بدون مقیاس‌بندی اشکال موجود.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // دریافت اندازه اسلاید جدید.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // مقیاس‌بندی اندازه شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // مقیاس‌بندی اندازه شکل.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // مقیاس‌بندی موقعیت شکل.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // مقیاس‌بندی اندازه شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

### چرا اشکال بعد از تغییر اندازه اسلاید مخدوش یا قطع می‌شوند؟

هنگام تغییر اندازه اسلاید، اشکال موقعیت و اندازه اصلی خود را حفظ می‌کنند مگر اینکه به‌صورت صریح مقیاس آنها تغییر کند. این می‌تواند منجر به بریدن محتوا یا نامرتبی اشکال شود.

### آیا کد ارائه‌شده برای همه انواع شکل‌ها کار می‌کند؟

بله. تنظیم ارتفاع و عرض برای جعبه‌های متن، تصاویر، نمودارها و جداول به یکسان قابل استفاده است.

### چگونه جداول را هنگام تغییر اندازه اسلاید مقیاس‌گذاری کنم؟

به‌صورت کلی همانند سایر اشکال، جدول را مقیاس کنید. ردیف‌ها و ستون‌های آن به‌طور نسبی دنبال می‌شوند، بنابراین بعداً آنها را دوباره مقیاس ندهید.

### آیا این مقیاس‌گذاری برای اسلایدهای اصلی و اسلایدهای طرح‌بندی نیز کار می‌کند؟

بله، اما باید همچنین در [اسلایدهای اصلی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasters--) و [اسلایدهای طرح‌بندی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getLayoutSlides--) حلقه بزنید و همان منطق مقیاس‌گذاری را بر شکل‌های آن‌ها اعمال کنید تا سازگاری در سراسر ارائه حفظ شود.

### آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟

بله. می‌توانید از [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#setOrientation-int-) برای تغییر جهت استفاده کنید. اطمینان حاصل کنید که منطق مقیاس‌گذاری را متناسب تنظیم کنید تا طرح حفظ شود.

### آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارند.

### چگونه می‌توانم از مخدوش شدن اشکال با نسبت ثابت جلوگیری کنم؟

قبل از مقیاس‌گذاری می‌توانید متد `getAspectRatioLocked` شکل را بررسی کنید. اگر قفل شده باشد، عرض یا ارتفاع را به‌صورت نسبی تنظیم کنید نه اینکه جداگانه مقیاس کنید.