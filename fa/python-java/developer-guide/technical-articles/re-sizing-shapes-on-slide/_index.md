---
title: تغییر اندازه اشکال در اسلایدهای ارائه با پایتون از طریق جاوا
type: docs
weight: 110
url: /fa/python-java/resizing-shapes-on-slide/
aliases:
  - /fa/python-java/re-sizing-shapes-on-slide/
  /python-java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "به سادگی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق جاوا تغییر اندازه دهید — تنظیمات چیدمان اسلایدها را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مرور کلی**

هنگام تغییر اندازه اسلاید ارائه، ممکن است نیاز باشد تا اشکال آن را نیز برای تناسب با ابعاد جدید، تغییر اندازه و موقعیت‌دهی کنید. این مقاله نحوه مقیاس‌گذاری دستی اشکال و چگونگی مدیریت جداول در اسلایدها، مسترها و طرح‌ها را نشان می‌دهد.

## **تغییر اندازه اشکال**

برای حفظ موقعیت و اندازه نسبی هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع متناظر را بر مختصات عمودی و ارتفاع اعمال کنید.

مثال اول یک ارائه را بارگیری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) با [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/python-java/aspose.slides/slidesizescaletype/#DoNotScale) استفاده می‌کند تا حلقه بعدی مقیاس‌گذاری را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد اشکال بر حسب پوینت اندازه‌گیری می‌شوند. نسبت‌های متفاوت عرض و ارتفاع می‌توانند اشکال را به‌هم بریزند و تغییر ابعاد یک شکل اندازه‌گیری قلم‌های آن را تغییر نمی‌دهد.

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
جداول نیاز به پردازش جداگانه دارند: به‌جای تعیین عرض و ارتفاع کلی جدول، عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌گذاری کنید. ارتفاع ردیف‌ها ممکن است بزرگ‌تر از مقدار درخواست‌شده باقی بماند اگر محتویات سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جداول پشتیبانی می‌کند و اشکال را در مسترها و طرح‌ها و همچنین اسلایدهای منفرد قبل از ذخیره ارائه با اندازه‌تغییر یافته پردازش می‌نماید. کمک‌کننده آن هر [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) را با مقیاس‌گذاری عرض ستون‌ها با [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) و حداقل ارتفاع ردیف‌ها با [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) مدیریت می‌کند. سپس موقعیت جدول را مقیاس‌گذاری می‌کند بدون اینکه ابعاد کلی آن به‌صورت جداگانه مقیاس‌گذاری شود.

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

    # تغییر اندازه اشکال تعریف شده در مسترها و طرح‌ها و همچنین اسلایدهای تک‌تک.
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

## **سوالات متداول**

**چرا پس از تغییر اندازه اسلاید، اشکال خراب یا بریده می‌شوند؟**  
اگر اندازه اسلاید را بدون مقیاس‌گذاری اشکال تغییر دهید، آن‌ها موقعیت و ابعاد اصلی خود را حفظ می‌کنند و ممکن است از محدوده اسلاید فراتر بروند. مقیاس‌گذاری عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند باعث خراب شدن اشکال شود.

**آیا کد ارائه شده برای همه انواع اشکال کار می‌کند؟**  
مثال اول به‌صورت مستقیم مرزهای شکل را تغییر می‌دهد و برای اسلایدهای بدون جدول در نظر گرفته شده است. مثال دوم جداول را به‌صورت جداگانه مدیریت می‌کند. طرح نهایی، به‌ویژه متن و جداول را بررسی کنید، زیرا این مثال‌ها اندازه قلم‌ها را مقیاس‌گذاری نمی‌کنند و محتویات جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جداول را نیز تغییر اندازه دهم؟**  
عرض ستون‌ها را بر اساس نسبت عرض و حداقل ارتفاع ردیف‌ها را بر اساس نسبت ارتفاع مقیاس‌گذاری کنید، سپس موقعیت جدول را همانند مثال دوم مقیاس‌گذاری نمایید.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای طرح نیز کار می‌کند؟**  
بله. مثال دوم از طریق [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) و [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getLayoutSlides) هر مستر مرور می‌کند و همان منطق تغییر اندازه را بر اشکال آن‌ها اعمال می‌نماید.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکپ) را همراه با تغییر اندازه تغییر دهم؟**  
بله. پس از تغییر اندازه اسلاید و قبل از خواندن ابعاد هدف، [SlideSize.setOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setOrientation) را فراخوانی کنید تا عوامل مقیاس جهت نهایی را منعکس کنند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**  
می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.setSize](https://reference.aspose.com/slides/python-java/aspose.slides/slidesize/#setSize) تعیین کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که برای باز کردن فایل استفاده می‌شود وابسته است.

**چگونه می‌توانم از خراب شدن اشکالی که نسبت عرض به ارتفاع ثابت دارند جلوگیری کنم؟**  
از یک عامل مقیاس یکسان برای عرض و ارتفاع استفاده کنید. برای جا‌گذاری طرح اصلی در ابعاد جدید اسلاید، نسبت کوچکتر بین نسبت عرض و ارتفاع را برای هر دو بعد و موقعیت‌ها به کار ببرید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است در یک سمت فضای خالی باقی بگذارد.