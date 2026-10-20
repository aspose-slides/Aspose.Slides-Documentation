---
title: تغییر اندازه اشکال در اسلایدهای ارائه با جاوا
type: docs
weight: 130
url: /fa/java/resizing-shapes-on-slide/
aliases:
  - /fa/java/re-sizing-shapes-on-slide/
  /java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر سایز شکل
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به سادگی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای جاوا تغییر اندازه دهید—تنظیمات خودکار چیدمان اسلاید را انجام دهید و بهره‌وری را افزایش دهید."
---
## **بررسی کلی**

زمانی که اندازه اسلاید ارائه را تغییر می‌دهید، ممکن است نیاز داشته باشید شکل‌ها را تغییر اندازه و موقعیت دهید تا در ابعاد جدید جای بگیرند. این مقاله نشان می‌دهد چگونه شکل‌ها را به صورت دستی مقیاس‌بندی کنید و چگونه جداول را در اسلایدها، مسترها و چیدمان‌ها مدیریت نمایید.

## **تغییر اندازه شکل‌ها**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض جدید اسلاید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را برای مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه که اسلایدهای آن حاوی جدول نیستند بارگذاری می‌کند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقه بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد شکل‌ها بر حسب نقطه اندازه‌گیری می‌شود. نسبت‌های متفاوت عرض و ارتفاع می‌توانند شکل‌ها را تحریف کنند و تغییر ابعاد یک شکل، اندازه فونت آن را مقیاس‌بندی نمی‌کند.

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
جداول نیاز به پردازش جداگانه دارند: به جای اختصاص دادن عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع سطرها را مقیاس‌بندی کنید. ارتفاع سطرها ممکن است بزرگ‌تر از مقدار درخواست‌شده باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و قبل از ذخیره ارائه با ابعاد جدید، شکل‌ها را در مسترها و چیدمان‌ها و همچنین اسلایدهای جداگانه پردازش می‌کند. کمکی آن هر [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) را با مقیاس‌بندی عرض ستون‌ها با [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) و حداقل ارتفاع سطرها با [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانه ابعاد کلی آن مقیاس‌بندی می‌کند.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // ابعاد جدول توسط عرض ستون‌ها و ارتفاع سطرها کنترل می‌شود.
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

    // تغییر اندازه اشکال تعریف‌شده در مسترها و چیدمان‌ها همچنین اسلایدهای جداگانه.
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

**چرا پس از تغییر اندازه اسلاید، شکل‌ها تحریف یا بریده می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌بندی شکل‌ها تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است از مرز اسلاید فراتر بروند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند شکل‌ها را تحریف کند.

**آیا کد ارائه‌شده برای تمامی انواع شکل‌ها کار می‌کند؟**

مثال اول مرزهای شکل را به طور مستقیم تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جداول را به‌صورت جداگانه مدیریت می‌کند. طرح نهایی را، به‌خصوص متن و جداول، بررسی کنید، زیرا این مثال‌ها اندازه فونت‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع سطرها را محدود کند.

**چگونه جداول را هنگام تغییر اندازه اسلاید تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و حداقل ارتفاع سطرها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را همانند مثال دوم مقیاس‌بندی نمایید.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای چیدمان نیز کار خواهد کرد؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) و هر [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) در هر مستر پیمایش می‌کند و منطق یکسان تغییر اندازه را برای شکل‌های آن‌ها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و قبل از خواندن ابعاد هدف، متد [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود وابسته است.

**چگونه می‌توانم از تحریف شکل‌هایی که نسبت عرض به ارتفاع ثابت دارند جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای متناسب کردن چیدمان اصلی با ابعاد جدید اسلاید، از نسبت کوچکتر بین عرض و ارتفاع برای هر دو بعد و موقعیت استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است در یک لبه فضای بدون استفاده باقی بگذارد.