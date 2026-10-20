---
title: تغییر اندازه اشکال در اسلایدهای ارائه بر روی اندروید
type: docs
weight: 130
url: /fa/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
  - /fa/androidjava/re-sizing-shapes-on-slide/
keywords:
  - تغییر اندازه شکل
  - تغییر اندازه شکل
  - PowerPoint
  - OpenDocument
  - ارائه
  - Android
  - Aspose.Slides
description: "به راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java تغییر اندازه دهید - تنظیمات چیدمان اسلایدها را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مرور کلی**

هنگامی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است لازم باشد تا اشکال آن را برای هماهنگی با ابعاد جدید، دوباره‌سایز و بازجایگذاری کنید. این مقاله نشان می‌دهد چگونه اشکال را به صورت دستی مقیاس‌بندی کنید و چگونه جدول‌ها را در اسلایدها، مسترها و طرح‌بندی‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را بر مختصات عمودی و ارتفاع اعمال کنید.

مثال اول ارائه‌ای را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. از [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقه بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت‌ها و ابعاد اشکال بر پایهٔ نقطه‌اند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را اعوجاج دهند و تغییر ابعاد یک شکل اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی به صورت مستقل.
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
جدول‌ها نیاز به پردازش جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای اختصاص عرض و ارتفاع کلی جدول. ارتفاع ردیف‌ها ممکن است بزرگ‌تر از مقدار خواسته‌شده بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم جدول‌ها را پشتیبانی می‌کند و اشکال را نه تنها در اسلایدهای منفرد بلکه در مسترها و طرح‌بندی‌ها نیز پیش از ذخیرهٔ ارائهٔ تغییر اندازه شده پردازش می‌کند. helper آن هر [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) را با مقیاس‌بندی عرض ستون‌ها با [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) و ارتفاع حداقل ردیف‌ها با [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی‌اش مقیاس می‌دهد.
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
    // عوامل مقیاس افقی و عمودی به صورت مستقل محاسبه می‌شوند.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // تغییر اندازه اشکال تعریف‌شده در مسترها و طرح‌بندی‌ها و همچنین اسلایدهای منفرد.
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

**چرا اشکال پس از تغییر اندازه اسلاید دچار اعوجاج یا قطع می‌شوند؟**

اگر اسلاید را بدون مقیاس‌بندی اشکال تغییر اندازه دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است خارج از اسلاید گسترش یابند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند باعث اعوجاج اشکال شود.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**

مثال اول به‌صورت مستقیم حدود شکل‌ها را تغییر می‌دهد و برای اسلایدهایی بدون جدول در نظر گرفته شده است. مثال دوم جدول‌ها را جداگانه پردازش می‌کند. پس از اجرا طرح‌بندی نهایی، به‌خصوص متن و جدول‌ها را بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جدول‌ها را تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض مقیاس‌بندی کنید و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای طرح‌بندی نیز اعمال می‌شود؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) و هر [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) عبور می‌کند و همان منطق تغییر اندازه را بر اشکال آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکیپ) را همزمان با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و پیش از خواندن ابعاد هدف، متد [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به قالب ارائه و برنامه‌ای که فایل را باز می‌کند، وابسته است.

**چگونه می‌توانم از تغییر شکل اشکالی که نسبت ابعاد ثابت دارند جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای جاگذاری طرح‌بندی اصلی در ابعاد جدید اسلاید، از کوچکتر مقدار نسبت عرض و ارتفاع برای هر دو بعد و موقعیت استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای خالی در یک لبه باقی بگذارد.