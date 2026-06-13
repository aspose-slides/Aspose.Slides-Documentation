---
title: تغییر اندازه اشکال در ارائه‌ها با پایتون
linktitle: تغییر اندازه اشکال
type: docs
weight: 130
url: /fa/python-net/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازه شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "به‌راحتی اشکال را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق .NET تغییر اندازه دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **مروری کلی**

یکی از رایج‌ترین سؤالات مشتریان Aspose.Slides برای Python این است که چگونه شکل‌ها را تغییر اندازه دهند تا وقتی اندازه اسلاید تغییر می‌کند، داده‌ها قطع نشوند. این مقالهٔ فنی کوتاه نشان می‌دهد چگونه این کار را انجام دهید.

## **تغییر اندازهٔ شکل‌ها**

برای جلوگیری از جابجایی شکل‌ها هنگام تغییر اندازهٔ اسلاید، موقعیت و ابعاد هر شکل را به‌گونه‌ای به‌روزرسانی کنید که با طرح جدید اسلاید سازگار باشد.

```py
import aspose.slides as slides

# فایل ارائه را بارگذاری کنید.
with slides.Presentation("sample.pptx") as presentation:
    # اندازهٔ اسلاید اصلی را دریافت کنید.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # اندازهٔ اسلاید را بدون مقیاس‌بندی اشکال موجود تغییر دهید.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # اندازهٔ اسلاید جدید را دریافت کنید.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # تغییر اندازه و جابه‌جایی اشکال در هر اسلاید.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # مقیاس‌بندی اندازهٔ شکل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # مقیاس‌بندی موقعیت شکل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 
اگر اسلاید شامل جدول باشد، کد بالا به‌درستی کار نخواهد کرد. در این حالت باید هر سلول جدول را تغییر اندازه داد.
{{% /alert %}} 

از کد زیر در سمت خود برای تغییر اندازهٔ اسلایدهایی که شامل جدول هستند استفاده کنید. برای جداول، تنظیم عرض یا ارتفاع یک مورد ویژه است: باید ارتفاع ردیف‌ها و عرض ستون‌ها را به‌صورت جداگانه تنظیم کنید تا اندازهٔ کلی جدول تغییر کند.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # اندازهٔ اسلاید اصلی را دریافت کنید.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # اندازهٔ اسلاید را بدون مقیاس‌بندی اشکال موجود تغییر دهید.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # اندازهٔ اسلاید جدید را دریافت کنید.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # مقیاس‌بندی اندازهٔ شکل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # مقیاس‌بندی موقعیت شکل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # مقیاس‌بندی اندازهٔ شکل.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # مقیاس‌بندی موقعیت شکل.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # مقیاس‌بندی اندازهٔ شکل.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # مقیاس‌بندی موقعیت شکل.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**چرا پس از تغییر اندازهٔ اسلاید، شکل‌ها کشیده یا قطع می‌شوند؟**

هنگام تغییر اندازهٔ اسلاید، شکل‌ها موقعیت و اندازهٔ اصلی خود را حفظ می‌کنند مگر اینکه مقیاس به‌صورت صریح تغییر کند. این می‌تواند منجر به برش محتوا یا جابجایی شکل‌ها شود.

**آیا کد ارائه شده برای تمام انواع شکل‌ها کار می‌کند؟**

مثال پایه برای اکثر انواع شکل‌ها (جعبه‌های متن، تصاویر، نمودارها و غیره) کار می‌کند. اما برای جداول، باید ردیف‌ها و ستون‌ها را جداگانه مدیریت کنید، چون ارتفاع و عرض جدول توسط ابعاد سلول‌های فردی تعیین می‌شود.

**چگونه هنگام تغییر اندازهٔ اسلاید، جدول‌ها را تغییر اندازه دهم؟**

باید در تمام ردیف‌ها و ستون‌های جدول پیمایش کنید و ارتفاع و عرض آن‌ها را به‌صورت نسبی تغییر دهید، همان‌طور که در مثال دوم کد نشان داده شده است.

**آیا این تغییر اندازه برای اسلایدهای مستر و اسلایدهای طرح‌بندی نیز کاربرد دارد؟**

بله، اما همچنین باید در [Masters](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/masters/) و [Layout slides](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/layout_slides/) پیمایش کنید و منطق مقیاس‌گذاری یکسان را بر روی شکل‌های آن‌ها اعمال کنید تا در سراسر ارائه سازگاری حفظ شود.

**آیا می‌توانم جهت اسلاید (پرتره/لنداسکیپ) را همراه با تغییر اندازه تغییر دهم؟**

بله. می‌توانید از [presentation.slide_size.orientation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/islidesize/orientation/) برای تغییر جهت استفاده کنید. مطمئن شوید منطق مقیاس‌گذاری را به‌گونه‌ای تنظیم کنید که طرح حفظ شود.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تأثیر بگذارند.

**چگونه می‌توانم از کشیده شدن اشکال با نسبت تصویر ثابت جلوگیری کنم؟**

قبل از مقیاس‌گذاری می‌توانید ویژگی `aspect_ratio_locked` شکل را بررسی کنید. اگر قفل باشد، به‌جای مقیاس‌گذاری جداگانهٔ عرض و ارتفاع، آنها را به‌صورت متناسب تنظیم کنید.