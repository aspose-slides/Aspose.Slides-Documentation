---
title: تغییر اندازه اشکال در اسلایدهای ارائه با Node.js
type: docs
weight: 130
url: /fa/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /fa/nodejs-java/re-sizing-shapes-on-slide/
keywords:
  - تغییر اندازه شکل
  - تغییر اندازه شکل
  - PowerPoint
  - OpenDocument
  - ارائه
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "به راحتی با Aspose.Slides برای Node.js از طریق Java، اشکال را در اسلایدهای PowerPoint و OpenDocument تغییر اندازه دهید — تنظیمات طرح‌بندی اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

زمانی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز به تغییر اندازه و جابجایی اشکال آن داشته باشید تا با ابعاد جدید سازگار شوند. این مقاله نحوهٔ مقیاس‌گذاری دستی اشکال و نحوهٔ مدیریت جداول در اسلایدها، مسترها و طرح‌بندی‌ها را نشان می‌دهد.

## **تغییر اندازه اشکال**

برای حفظ موقعیت نسبی و اندازهٔ هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را به مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه را که اسلایدهای آن شامل جدول نیستند بارگذاری می‌کند، اندازه اسلاید را به A4 تغییر داده و نتیجه را ذخیره می‌نماید. این مثال از [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقهٔ بعدی مقیاس‌گذاری را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را مخدوش کنند و تغییر ابعاد یک شکل، اندازهٔ قلم را مقیاس‌گذاری نمی‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
جداول نیاز به مدیریت جداگانه دارند: به جای اختصاص دادن عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌گذاری کنید. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواست شده باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و قبل از ذخیرهٔ ارائهٔ تغییر اندازهٔ یافته، اشکال را نه تنها در اسلایدهای فردی بلکه در مسترها و طرح‌بندی‌ها نیز پردازش می‌نماید. helper این مثال هر [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) را با مقیاس‌گذاری عرض ستون‌ها با [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) و ارتفاع حداقل ردیف‌ها با [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌گذاری جداگانهٔ ابعاد کلی آن مقیاس می‌دهد.
```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // محاسبه عوامل مقیاس افقی و عمودی مستقل.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // تغییر اندازه اشکالی که در مسترها و طرح‌بندی‌ها و همچنین اسلایدهای جداگانه تعریف شده‌اند.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**چرا پس از تغییر اندازهٔ اسلاید، اشکال مخدوش یا بریده می‌شوند؟**

اگر اندازهٔ اسلاید را بدون مقیاس‌گذاری اشکال تغییر دهید، موقعیت و ابعاد اولیهٔ آن‌ها حفظ می‌شود و ممکن است خارج از اسلاید گسترش یابند. مقیاس‌گذاری عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند باعث مخدوش شدن اشکال شود.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال اول مستقیماً مرزهای اشکال را تغییر می‌دهد و برای اسلایدهایی که جدول ندارند طراحی شده است. مثال دوم جداول را به‌صورت جداگانه مدیریت می‌کند. پس از اجرای مثال‌ها، چیدمان نهایی به‌ویژه متن و جداول را بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم را مقیاس نمی‌کنند و محتویات جدول ممکن است ارتفاع ردیف‌ها را محدود کنند.

**چگونه هنگام تغییر اندازهٔ اسلاید، جداول را نیز تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع مقیاس‌گذاری کنید، سپس موقعیت جدول را مقیاس دهید؛ همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و طرح‌بندی هم کار می‌کند؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) و برای هر مستر از [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) عبور می‌کند و همان منطق تغییر اندازه را بر روی اشکال آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همزمان با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازهٔ اسلاید و قبل از خواندن ابعاد هدف، می‌توانید [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازهٔ اسلاید می‌توانم تنظیم کنم؟**

می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) تعیین کنید. ابعاد پشتیبانی‌شده همچنین به قالب ارائه و برنامهٔ مورد استفاده برای باز کردن فایل وابسته است.

**چگونه می‌توانم از مخدوش شدن اشکالی که نسبت ابعاد ثابت دارند جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای جا‌به‌جایی طرح اولیه در داخل ابعاد اسلاید جدید، از کوچک‌ترین نسبت عرض یا ارتفاع برای هر دو بعد و موقعیت استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای استفاده نشده‌ای در یک سمت باقی بگذارد.