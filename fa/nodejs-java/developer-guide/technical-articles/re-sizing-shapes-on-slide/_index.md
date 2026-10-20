---
title: تغییر اندازه اشکال در اسلایدهای ارائه با Node.js
type: docs
weight: 130
url: /fa/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /fa/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شی
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به سادگی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Node.js از طریق Java تغییر اندازه دهید—تنظیمات چیدمان اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

هنگامی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز به تغییر اندازه و موقعیت اشکال آن داشته باشید تا با ابعاد جدید سازگار شوند. این مقاله نشان می‌دهد چگونه اشکال را به صورت دستی مقیاس‌بندی کنید و چگونه جداول را در اسلایدها، مسترها و لایه‌ها مدیریت کنید.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در برابر نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را بر مختصات عمودی و ارتفاع آن اعمال کنید.

مثال اول یک ارائه را که اسلایدهای آن حاوی جدول نیستند بارگذاری می‌کند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) همراه با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقه بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را تغییر شکل دهند و تغییر ابعاد یک شکل اندازه‌گیری‌های قلم آن را مقیاس‌بندی نمی‌کند.

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
جدول‌ها نیاز به پردازش جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای تعیین عرض و ارتفاع کلی جدول. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواست شده باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جدول‌ها پشتیبانی می‌کند و اشکال را بر روی مسترها و لایه‌ها و همچنین اسلایدهای منفرد پردازش می‌کند قبل از اینکه ارائه تغییر اندازه یافته را ذخیره کند. کمک کنندهٔ آن برای هر [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) با مقیاس‌بندی عرض ستون‌ها با [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) و حداقل ارتفاع ردیف‌ها با [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight) عمل می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس‌بندی می‌کند.
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

    // تغییر اندازه اشکال تعریف‌شده در مسترها و لایه‌ها و همچنین اسلایدهای منفرد.
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

## **پرسش‌های متداول**

**چرا پس از تغییر اندازه اسلاید، اشکال تغییر شکل یا بریده می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌بندی اشکال تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است از مرز اسلاید فراتر بروند. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند اشکال را تغییر شکل دهد.

**آیا کد ارائه‌شده برای تمام انواع اشکال کار می‌کند؟**

مثال اول مستقیماً مرزهای شکل را تغییر می‌دهد و برای اسلایدهایی بدون جدول منظور شده است. مثال دوم جدول‌ها را به صورت جداگانه مدیریت می‌کند. پس از اعمال تغییرات، طرح نهایی به‌ویژه متن و جداول را بررسی کنید، زیرا این مثال‌ها اندازه قلم‌ها را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جدول‌ها را تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و حداقل ارتفاع ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای لایه نیز کار می‌کند؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) و هر مستر با [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) پیمایش می‌کند و همان منطق تغییر اندازه را بر روی اشکال آنها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکپ) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و قبل از خواندن ابعاد هدف، متد [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) را فراخوانی کنید تا عوامل مقیاس‌گذاری جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلاید که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با استفاده از [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) مشخص کنید. ابعاد پشتیبانی شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود بستگی دارند.

**چگونه می‌توانم جلوگیری کنم که اشکالی با نسبت تصویر ثابت تغییر شکل دهند؟**

از همان ضریب مقیاس برای عرض و ارتفاع استفاده کنید. برای متناسب کردن طرح اصلی با ابعاد جدید اسلاید، از نسبت کوچک‌تر بین عرض و ارتفاع برای هر دو بعد و موقعیت‌ها استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای خالی در یک طرف باقی بگذارد.