---
title: تغییر اندازه اشکال در اسلایدهای ارائه بر روی Android
type: docs
weight: 130
url: /fa/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/تغییر-اندازه-اشکال-در-اسلاید/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Android
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java تغییر اندازه دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مرور کلی**

هنگامی که اندازه اسلاید ارائه را تغییر می‌دهید، ممکن است نیاز داشته باشید اشکال آن را نیز برای سازگار شدن با ابعاد جدید تغییر اندازه و موقعیت دهید. این مقاله نشان می‌دهد چگونه اشکال را به صورت دستی مقیاس‌بندی کنید و چگونه جداول را در اسلایدها، مسترها و چیدمان‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را بر مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول ارائه‌ای را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. از [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب نقطه اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند باعث تحریف اشکال شوند و تغییر ابعاد یک شکل اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
جداول نیاز به مدیریت جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای اینکه عرض و ارتفاع کلی جدول را تعیین کنید. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواستی باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و اشکال را نه تنها در اسلایدهای منفرد بلکه در مسترها و چیدمان‌ها نیز پردازش می‌کند پیش از ذخیرهٔ ارائهٔ تغییر اندازه یافته. کمک‌کشان آن هر [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) را با مقیاس‌بندی عرض ستون‌ها با [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) و حداقل ارتفاع ردیف‌ها با [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس‌بندی می‌کند.
```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // تغییر اندازه اشکالی که در مسترها و چیدمان‌ها و همچنین اسلایدهای منفرد تعریف شده‌اند.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چرا پس از تغییر اندازه اسلاید اشکال تحریف یا قطع می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌بندی اشکال تغییر دهید، آنها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است خارج از محدوده اسلاید گسترش یابند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند باعث تحریف اشکال شود.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال اول مرزهای شکل را به‌طور مستقیم تغییر می‌دهد و برای اسلایدهایی بدون جدول در نظر گرفته شده است. مثال دوم جداول را به صورت جداگانه مدیریت می‌کند. چیدمان حاصل را به‌خصوص متن و جداول بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید جداول را مقیاس‌بندی کنم؟**

عرض ستون‌ها را با نسبت عرض و حداقل ارتفاع ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را همان‌گونه که در مثال دوم نشان داده شده است مقیاس‌بندی کنید.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای چیدمان کار خواهد کرد؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) و هر مستر از طریق [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) عبور می‌کند و همان منطق تغییر اندازه را بر اشکال آنها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و پیش از خواندن ابعاد هدف، [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) را فراخوانی کنید تا عوامل مقیاس نهایی جهت‌گیری نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود وابسته است.

**چگونه می‌توانم از تحریف اشکال با نسبت عرض‑ارتفاع ثابت جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای قرارگیری چیدمان اصلی در ابعاد جدید اسلاید، از کوچکترین نسبت عرض یا ارتفاع برای هر دو بعد و موقعیت‌ها استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای خالی در یک لبه باقی بگذارد.