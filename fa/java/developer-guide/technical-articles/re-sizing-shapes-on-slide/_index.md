---
title: تغییر اندازه اشکال در اسلایدهای ارائه با جاوا
type: docs
weight: 130
url: /fa/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /fa/java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه اشکال
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Java تغییر اندازه دهید-تنظیمات چیدمان اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

هنگامی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز باشد شکل‌ها را نیز برای سازگار شدن با ابعاد جدید مقیاس بندی و موقعیت آنها را تغییر دهید. این مقاله نشان می‌دهد چگونه شکل‌ها را به صورت دستی مقیاس‌بندی کنید و چگونه جدول‌ها را در اسلایدها، مسترها و چیدمان‌ها مدیریت کنید.

## **تغییر اندازه شکل‌ها**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را بر مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول ارائه‌ای را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) همراه با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد شکل‌ها بر حسب نقطه اندازه‌گیری می‌شود. نسبت‌های متفاوت عرض و ارتفاع می‌توانند شکل‌ها را تحریف کنند و تغییر ابعاد یک شکل اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

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
جدول‌ها نیاز به پردازش جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای تعیین عرض و ارتفاع کلی جدول. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواست شده باشد اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جدول‌ها پشتیبانی می‌کند و شکل‌ها را روی مسترها و چیدمان‌ها و همچنین اسلایدهای منفرد قبل از ذخیرهٔ ارائهٔ تغییر اندازه داده‌شده پردازش می‌کند. ابزارکمک آن هر [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) را با مقیاس‌بندی عرض ستون‌ها با [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) و حداقل ارتفاع ردیف‌ها با [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس‌بندی می‌نماید.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // تغییر اندازه اشکالی که در مسترها و چیدمان‌ها و همچنین اسلایدهای جداگانه تعریف شده‌اند.
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

## **پرسش‌های متداول**

**چرا پس از تغییر اندازه اسلاید، شکل‌ها تحریف یا قطع می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌بندی شکل‌ها تغییر دهید، موقعیت و ابعاد اصلی آنها حفظ می‌شود و ممکن است خارج از اسلاید بزرگ شوند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند شکل‌ها را تحریف کند.

**آیا کد ارائه‌شده برای تمام انواع شکل کار می‌کند؟**

مثال اول مرزهای شکل را به طور مستقیم تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جدول‌ها را جداگانه مدیریت می‌کند. چیدمان حاصل را به‌ویژه متن و جدول‌ها بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه جدول‌ها را هنگام تغییر اندازه اسلاید مقیاس‌بندی کنم؟**

عرض ستون‌ها را با نسبت عرض و حداقل ارتفاع ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای چیدمان نیز کار خواهد کرد؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) و [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) برای هر مستر تکرار می‌کند و همان منطق تغییر اندازه را بر شکل‌های آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و پیش از خواندن ابعاد هدف، [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را بازتاب دهند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با استفاده از [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) تعیین کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود، وابسته است.

**چگونه می‌توانم از تحریف شکل‌هایی که نسبت ابعاد ثابتی دارند جلوگیری کنم؟**

از یک عامل مقیاس‌گذاری یکسان برای عرض و ارتفاع استفاده کنید. برای متناسب کردن چیدمان اصلی در داخل ابعاد جدید اسلاید، نسبت کوچکتر بین نسبت عرض و ارتفاع را برای هر دو بعد و موقعیت‌ها به‌کار ببرید. این روش نسبت‌ها را حفظ می‌کند اما ممکن است فضای بلااستفاده‌ای در یک لبه باقی بگذارد.