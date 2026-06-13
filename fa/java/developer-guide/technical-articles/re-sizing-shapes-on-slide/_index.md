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
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Java تغییر اندازه دهید—تنظیمات چیدمان اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **بررسی کلی**

یکی از پرسش‌های رایج مشتریان Aspose.Slides for Java این است که چگونه اشکال را تغییر اندازه دهند به‌طوری که هنگام تغییر اندازه اسلاید، داده‌ها بریده نشوند. این مقاله فنی کوتاه نشان می‌دهد چگونه این کار را انجام دهید.

## **تغییر اندازه اشکال**

برای جلوگیری از جابه‌جایی اشکال هنگام تغییر اندازه اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با طرح جدید اسلاید همخوانی داشته باشد.

```java
// فایل ارائه را بارگذاری کنید.
Presentation presentation = new Presentation("sample.ppt");
try {
    // اندازهٔ اولیهٔ اسلاید را دریافت کنید.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // اندازهٔ اسلاید را بدون مقیاس کردن اشکال موجود تغییر دهید.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // اندازهٔ جدید اسلاید را دریافت کنید.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // تغییر اندازه و موقعیت اشکال در هر اسلاید.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // مقیاس‌گذاری اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌گذاری موقعیت شکل.
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

{{% alert color="primary" %}} 
اگر یک اسلاید شامل جدول باشد، کد فوق به‌درستی کار نخواهد کرد. در این حالت، باید هر سلول جدول را تغییر اندازه داد.
{{% /alert %}} 

از کد زیر در سمت خود استفاده کنید تا اسلایدهایی که حاوی جداول هستند را تغییر اندازه دهید. برای جداول، تنظیم عرض یا ارتفاع یک مورد خاص است: باید ارتفاع سطرهای جداگانه و عرض ستون‌ها را برای تغییر اندازه کلی جدول تنظیم کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // اندازهٔ اولیهٔ اسلاید را دریافت کنید.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // اندازهٔ اسلاید را بدون مقیاس کردن اشکال موجود تغییر دهید.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // اندازهٔ جدید اسلاید را دریافت کنید.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // مقیاس‌گذاری اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌گذاری موقعیت شکل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // مقیاس‌گذاری اندازهٔ شکل.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // مقیاس‌گذاری موقعیت شکل.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // مقیاس‌گذاری اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // مقیاس‌گذاری موقعیت شکل.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چرا اشکال پس از تغییر اندازه اسلاید خراب یا بریده می‌شوند؟**

هنگام تغییر اندازه اسلاید، اشکال موقعیت و اندازهٔ اصلی خود را حفظ می‌کنند مگر اینکه مقیاس به‌صورت صریح تغییر کند. این می‌تواند منجر به برش محتوا یا جابه‌جایی اشکال شود.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال پایه برای اکثر انواع اشکال (جعبه‌های متن، تصاویر، نمودارها و غیره) کار می‌کند. اما برای جداول، باید ردیف‌ها و ستون‌ها را جداگانه مدیریت کنید، زیرا ارتفاع و عرض جدول توسط ابعاد سلول‌های منفرد تعیین می‌شود.

**چگونه جداول را هنگام تغییر اندازه اسلاید تغییر اندازه دهم؟**

باید روی تمامی ردیف‌ها و ستون‌های جدول عبور کنید و ارتفاع و عرض آن‌ها را به‌صورت متناسب تغییر اندازه دهید، همان‌طور که در مثال دوم کد نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای طرح‌بندی کار می‌کند؟**

بله، اما باید همچنین روی [مستَرها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasters--) و [اسلایدهای طرح‌بندی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getLayoutSlides--) حلقه بزنید و منطق مقیاس‌گذاری یکسان را بر روی اشکال آن‌ها اعمال کنید تا سازگاری در سراسر ارائه حفظ شود.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکپ) را همراه با تغییر اندازه تغییر دهم؟**

بله. می‌توانید از [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidesize/#setOrientation-int-) برای تغییر جهت استفاده کنید. اطمینان حاصل کنید که منطق مقیاس‌گذاری را به‌صورت متناسب تنظیم کنید تا طرح حفظ شود.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint اثر بگذارد.

**چگونه می‌توانم از خراب شدن اشکال با نسبت ثابت جلوگیری کنم؟**

می‌توانید قبل از مقیاس‌گذاری، متد `getAspectRatioLocked` شکل را بررسی کنید. اگر قفل باشد، عرض یا ارتفاع را به‌صورت متناسب تنظیم کنید نه اینکه به‌جدا مقیاس شوند.