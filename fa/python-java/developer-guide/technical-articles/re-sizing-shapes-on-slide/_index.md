---
title: تغییر اندازه اشکال در اسلایدهای ارائه با پایتون از طریق جاوا
type: docs
weight: 110
url: /fa/python-java/resizing-shapes-on-slide/
aliases:
  - /python-java/re-sizing-shapes-on-slide/
  - /fa/python-java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر سایز شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "به سادگی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای Python از طریق Java تغییر اندازه دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

هنگامی که اندازه اسلاید یک ارائه را تغییر می‌دهید، ممکن است نیاز داشته باشید شکل‌ها را دوباره اندازه‌گیری و موقعیت آن‌ها را تنظیم کنید تا با ابعاد جدید مطابقت داشته باشند. این مقاله نشان می‌دهد چگونه شکل‌ها را به‌صورت دستی مقیاس‌گذاری کنید و چگونه جداول را در اسلایدها، اسلایدهای اصلی و طرح‌بندی‌ها مدیریت کنید.

## **تغییر اندازه شکل‌ها**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را برای مختصات عمودی و ارتفاع اعمال کنید.

مثال اول یک ارائه را بارگذاری می‌کند که اسلایدهای آن هیچ جدولی ندارند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. از [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) همراه با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقه بعدی مقیاس‌گذاری را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و اندازه شکل‌ها بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های مختلف عرض و ارتفاع می‌توانند شکل‌ها را تحریف کنند و تغییر ابعاد یک شکل اندازه قلم آن را مقیاس نمی‌کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType

presentation = Presentation("sample.pptx")
try:
    # محاسبه عوامل مقیاس افقی و عمودی مستقل.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setX(shape.getX() * width_ratio)
            shape.setY(shape.getY() * height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
جداول نیاز به پردازش جداگانه دارند: به‌جای اختصاص دادن عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس کنید. ارتفاع ردیف‌ها ممکن است بزرگتر از مقدار درخواستی باقی بماند اگر محتوای سلول به فضا بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و قبل از ذخیره ارائه با اندازه تغییر یافته، شکل‌ها را در اسلایدهای اصلی، طرح‌بندی‌ها و اسلایدهای منفرد پردازش می‌کند. تابع کمکی آن هر [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) را با مقیاس‌گذاری عرض ستون‌ها با [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) و ارتفاع حداقل ردیف‌ها با [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌گذاری جداگانه ابعاد کلی آن، مقیاس می‌دهد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, Table


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, Table):
            # ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
            for column in shape.getColumns():
                column.setWidth(column.getWidth() * width_ratio)

            for row in shape.getRows():
                row.setMinimalHeight(row.getMinimalHeight() * height_ratio)
        else:
            shape.setWidth(shape.getWidth() * width_ratio)
            shape.setHeight(shape.getHeight() * height_ratio)

        shape.setX(shape.getX() * width_ratio)
        shape.setY(shape.getY() * height_ratio)


presentation = Presentation("sample.pptx")
try:
    # محاسبه عوامل مقیاس افقی و عمودی مستقل.
    original_size = presentation.getSlideSize().getSize()
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    target_size = presentation.getSlideSize().getSize()
    width_ratio = target_size.getWidth() / original_size.getWidth()
    height_ratio = target_size.getHeight() / original_size.getHeight()

    # تغییر اندازه اشکال تعریف‌شده در اسلایدهای اصلی و طرح‌بندی‌ها و همچنین اسلایدهای منفرد.
    for master in presentation.getMasters():
        resize_shapes(master.getShapes(), width_ratio, height_ratio)

        for layout_slide in master.getLayoutSlides():
            resize_shapes(layout_slide.getShapes(), width_ratio, height_ratio)

    for slide in presentation.getSlides():
        resize_shapes(slide.getShapes(), width_ratio, height_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**چرا پس از تغییر اندازه اسلاید، شکل‌ها تحریف یا بریده می‌شوند؟**

اگر اندازه اسلاید را بدون مقیاس‌گذاری شکل‌ها تغییر دهید، موقعیت و ابعاد اصلی آن‌ها حفظ می‌شود و ممکن است خارج از اسلاید بسط پیدا کنند. مقیاس‌گذاری عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند شکل‌ها را تحریف کند.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**

مثال اول مرزهای شکل را مستقیماً تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جداول را جداگانه پردازش می‌کند. پس از اجرای کد، چینش نهایی، به‌ویژه متن و جداول را بررسی کنید، زیرا این مثال‌ها اندازه قلم را مقیاس نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جداول را نیز تغییر اندازه دهم؟**

عرض ستون‌ها را با نسبت عرض و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع مقیاس‌گذاری کنید، سپس موقعیت جدول را مقیاس دهید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای اصلی و اسلایدهای طرح‌بندی نیز اعمال می‌شود؟**

بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) و برای هر اسلاید اصلی از [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) پیمایش می‌کند و منطق تغییر اندازه یکسان را بر شکل‌های آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. پس از تغییر اندازه اسلاید و قبل از خواندن ابعاد هدف، [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) را فراخوانی کنید تا عوامل مقیاس جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

می‌توانید ابعاد سفارشی اسلاید را با استفاده از [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) تعیین کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود، وابسته است.

**چگونه می‌توانم از تحریف شکل‌هایی با نسبت طول و عرض ثابت جلوگیری کنم؟**

از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای سازگار کردن طرح اولیه با ابعاد جدید اسلاید، از نسبت کوچکتر بین نسبت عرض و ارتفاع برای هر دو بعد و موقعیت‌ها استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است در یک لبه فضای خالی باقی بگذارد.