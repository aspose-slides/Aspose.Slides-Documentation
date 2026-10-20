---
title: تغییر اندازه اشکال در اسلایدهای ارائه با پایتون
type: docs
weight: 130
url: /fa/python-net/resizing-shapes-on-slide/
aliases:
  - /python-net/re-sizing-shapes-on-slide/
  - /fa/python-net/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "به راحتی با Aspose.Slides برای Python از طریق .NET، اندازه اشکال را در اسلایدهای PowerPoint و OpenDocument تغییر دهید — تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **نمای کلی**

هنگام تغییر اندازه اسلاید یک ارائه، ممکن است نیاز داشته باشید شکل‌ها را دوباره مقیاس‌بندی و موقعیت‌دهی کنید تا با ابعاد جدید سازگار شوند. این مقاله نشان می‌دهد چگونه شکل‌ها را به صورت دستی مقیاس‌بندی کنید و جدول‌ها را در اسلایدها، مسترها و طرح‌بندی‌ها چگونه مدیریت کنید.

## **تغییر اندازه شکل‌ها**

برای حفظ موقعیت نسبی و اندازه هر شکل، مختصات افقی و عرض آن را در نسبت عرض اسلاید جدید به عرض اصلی ضرب کنید. نسبت ارتفاع مربوطه را برای مختصات عمودی و ارتفاع اعمال کنید.

مثال اول یک ارائه را بارگذاری می‌کند که اسلایدهای آن حاوی جدول نیستند، اندازه اسلاید را به A4 تغییر می‌دهد و نتیجه را ذخیره می‌کند. این مثال از [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) همراه با [SlideSizeScaleType.DO_NOT_SCALE](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) استفاده می‌کند تا حلقه بعدی مقیاس‌بندی را کنترل کند. نسبت‌ها بدون واحد هستند؛ موقعیت و ابعاد شکل‌ها بر حسب نقطه اندازه‌گیری می‌شود. نسبت‌های متفاوت عرض و ارتفاع می‌توانند شکل‌ها را انحراف دهند و تغییر ابعاد شکل‌ها اندازهٔ قلم را مقیاس‌بندی نمی‌کند.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # محاسبه عوامل مقیاس افقی و عمودی مستقل.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    for slide in presentation.slides:
        for shape in slide.shapes:
            shape.width *= width_ratio
            shape.height *= height_ratio
            shape.x *= width_ratio
            shape.y *= height_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
جدول‌ها نیاز به برخورد جداگانه دارند: عرض ستون‌ها و ارتفاع ردیف‌ها را مقیاس‌بندی کنید به جای انتساب مستقیم عرض و ارتفاع کلی جدول. ارتفاع ردیف‌ها ممکن است بزرگ‌تر از مقدار درخواستی باقی بماند اگر محتوای سلول به فضای بیشتری نیاز داشته باشد.
{{% /alert %}}

مثال دوم از جدول‌ها پشتیبانی می‌کند و شکل‌ها را نه تنها در اسلایدهای منفرد بلکه در مسترها و طرح‌بندی‌ها نیز پیش از ذخیرهٔ ارائهٔ تغییر اندازهٔ یافته پردازش می‌کند. این کمک‌کننده هر [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) را با مقیاس‌بندی [Column.width](https://reference.aspose.com/slides/python-net/aspose.slides/column/width/) و [Row.minimal_height](https://reference.aspose.com/slides/python-net/aspose.slides/row/minimal_height/) مدیریت می‌کند. سپس موقعیت جدول را بدون مقیاس‌بندی جداگانهٔ ابعاد کلی آن مقیاس‌بندی می‌نماید.
```python
import aspose.slides as slides


def resize_shapes(shapes, width_ratio, height_ratio):
    for shape in shapes:
        if isinstance(shape, slides.Table):
            # ابعاد جدول توسط عرض ستون‌ها و ارتفاع ردیف‌ها کنترل می‌شود.
            for column in shape.columns:
                column.width *= width_ratio

            for row in shape.rows:
                row.minimal_height *= height_ratio
        else:
            shape.width *= width_ratio
            shape.height *= height_ratio

        shape.x *= width_ratio
        shape.y *= height_ratio


with slides.Presentation("sample.pptx") as presentation:
    # محاسبه عوامل مقیاس افقی و عمودی مستقل.
    original_size = presentation.slide_size.size
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)
    target_size = presentation.slide_size.size
    width_ratio = target_size.width / original_size.width
    height_ratio = target_size.height / original_size.height

    # تغییر اندازه اشکالی که در مسترها، طرح‌بندی‌ها و اسلایدهای جداگانه تعریف شده‌اند.
    for master in presentation.masters:
        resize_shapes(master.shapes, width_ratio, height_ratio)

        for layout_slide in master.layout_slides:
            resize_shapes(layout_slide.shapes, width_ratio, height_ratio)

    for slide in presentation.slides:
        resize_shapes(slide.shapes, width_ratio, height_ratio)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**چرا پس از تغییر اندازه اسلاید، شکل‌ها مخدوش یا قطع می‌شوند؟**  
اگر اندازه اسلاید را بدون مقیاس‌بندی شکل‌ها تغییر دهید، موقعیت و ابعاد اولیهٔ آنها باقی می‌ماند و ممکن است از مرز اسلاید فراتر رود. مقیاس‌بندی عرض و ارتفاع با نسبت‌های متفاوت نیز می‌تواند شکل‌ها را مخدوش کند.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**  
مثال اول مستقیماً مرزهای شکل را تغییر می‌دهد و برای اسلایدهایی بدون جدول در نظر گرفته شده است. مثال دوم جدول‌ها را جداگانه مدیریت می‌کند. طرح‌بندی نهایی، به‌ویژه متن و جدول‌ها را بررسی کنید، زیرا این مثال‌ها اندازهٔ قلم را مقیاس‌بندی نمی‌کنند و محتوای جدول می‌تواند ارتفاع ردیف‌ها را محدود کند.

**چگونه هنگام تغییر اندازه اسلاید، جدول‌ها را نیز تغییر اندازه دهم؟**  
عرض ستون‌ها را با نسبت عرض و ارتفاع حداقل ردیف‌ها را با نسبت ارتفاع مقیاس‌بندی کنید، سپس موقعیت جدول را مقیاس‌بندی کنید، همان‌طور که در مثال دوم نشان داده شده است.

**آیا این تغییر اندازه برای مستر اسلایدها و اسلایدهای طرح‌بندی نیز اعمال می‌شود؟**  
بله. مثال دوم از طریق [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) و هر [MasterSlide.layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) می‌گذرد و همان منطق تغییر اندازه را بر شکل‌های آنها اعمال می‌کند.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**  
بله. پس از تغییر اندازه اسلاید و پیش از خواندن ابعاد هدف، [SlideSize.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/orientation/) را تنظیم کنید تا عوامل مقیاس نهایی نمایانگر جهت نهایی باشند.

**آیا محدودیتی برای اندازه اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**  
می‌توانید ابعاد سفارشی اسلاید را با [SlideSize.set_size](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/set_size/) مشخص کنید. ابعاد پشتیبانی‌شده همچنین به فرمت ارائه و برنامه‌ای که فایل را باز می‌کند بستگی دارد.

**چگونه می‌توانم از مخدوش شدن اشکالی که نسبت ابعاد ثابت دارند جلوگیری کنم؟**  
از همان عامل مقیاس برای عرض و ارتفاع استفاده کنید. برای جایگذاری طرح‌بندی اصلی در ابعاد جدید اسلاید، از نسبت کوچکتر بین عرض و ارتفاع برای هر دو بعد و موقعیت‌ها استفاده کنید. این کار نسبت‌ها را حفظ می‌کند اما ممکن است فضای خالی در یک لبه باقی بگذارد.