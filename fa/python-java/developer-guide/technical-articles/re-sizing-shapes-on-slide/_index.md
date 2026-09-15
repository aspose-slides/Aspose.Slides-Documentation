---
title: تغییر اندازهٔ شکل‌ها در اسلایدهای ارائه با پایتون از طریق جاوا
type: docs
weight: 110
url: /fa/python-java/re-sizing-shapes-on-slide/
keywords:
- تغییر اندازه شکل
- تغییر اندازهٔ شکل
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "به راحتی اندازهٔ شکل‌ها را در اسلایدهای PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق جاوا تغییر دهید—تنظیمات طرح اسلاید را خودکار کنید و بهره‌وری را افزایش دهید."
---
## **بررسی کلی**

یکی از رایج‌ترین سؤالات مشتریان Aspose.Slides برای Python از طریق Java این است که چگونه شکل‌ها را تغییر اندازه دهند تا وقتی اندازه اسلاید تغییر می‌کند، داده‌ها بریده نشوند. این مقالهٔ فنی کوتاه نشان می‌دهد چطور این کار را انجام دهید.

## **تغییر اندازهٔ شکل‌ها**

برای جلوگیری از نام‌چینش شدن شکل‌ها هنگام تغییر اندازهٔ اسلاید، موقعیت و ابعاد هر شکل را به‌روزرسانی کنید تا با چیدمان جدید اسلاید هماهنگ شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

# بارگذاری فایل ارائه.
presentation = Presentation("sample.ppt")
try:
    # دریافت اندازهٔ اصلی اسلاید.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # تغییر اندازهٔ اسلاید بدون مقیاس‌بندی اشکال موجود.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)

    # دریافت اندازهٔ جدید اسلاید.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # تغییر اندازه و موقعیت اشکال در هر اسلاید.
    for slide in presentation.getSlides():
        for shape in slide.getShapes():

            # مقیاس‌بندی اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
جداول نیازی به رفتار ویژه ندارند: تنظیم عرض و ارتفاع جدول، ستون‌ها و ردیف‌های آن را به‌صورت متناسب بازتعریف می‌کند، بنابراین دوباره مقیاس‌گذاری ارتفاع ردیف‌ها و عرض ستون‌ها باعث اعمال نسبت دو بار می‌شود.
{{% /alert %}} 

کد بالا تنها شکل‌های موجود در اسلایدها را تغییر می‌دهد. اسلایدهای اصلی (Master) و اسلایدهای طرح‌بندی (Layout) شکل‌های خود را دارند، بنابراین اگر می‌خواهید کل ارائهٔ شما به اندازهٔ جدید اسلاید مطابقت داشته باشد، آن‌ها را نیز مقیاس‌بندی کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeType, SlideSizeScaleType, SlideOrientation

presentation = Presentation("sample.pptx")
try:
    # دریافت اندازهٔ اصلی اسلاید.
    current_height = presentation.getSlideSize().getSize().getHeight()
    current_width = presentation.getSlideSize().getSize().getWidth()

    # تغییر اندازهٔ اسلاید بدون مقیاس‌بندی اشکال موجود.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale)
    # presentation.getSlideSize().setOrientation(SlideOrientation.Portrait)

    # دریافت اندازهٔ جدید اسلاید.
    new_height = presentation.getSlideSize().getSize().getHeight()
    new_width = presentation.getSlideSize().getSize().getWidth()

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.getMasters():
        for shape in master.getShapes():
            # مقیاس‌بندی اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

        for layout_slide in master.getLayoutSlides():
            for shape in layout_slide.getShapes():
                # مقیاس‌بندی اندازهٔ شکل.
                shape.setHeight(shape.getHeight() * height_ratio)
                shape.setWidth(shape.getWidth() * width_ratio)

                # مقیاس‌بندی موقعیت شکل.
                shape.setY(shape.getY() * height_ratio)
                shape.setX(shape.getX() * width_ratio)

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            # مقیاس‌بندی اندازهٔ شکل.
            shape.setHeight(shape.getHeight() * height_ratio)
            shape.setWidth(shape.getWidth() * width_ratio)

            # مقیاس‌بندی موقعیت شکل.
            shape.setY(shape.getY() * height_ratio)
            shape.setX(shape.getX() * width_ratio)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سؤالات متداول**

**چرا پس از تغییر اندازهٔ اسلاید، شکل‌ها تحلیل‌رفته یا بریده می‌شوند؟**

هنگام تغییر اندازهٔ اسلاید، شکل‌ها موقعیت و اندازهٔ اولیهٔ خود را حفظ می‌کنند مگر این‌که مقیاس به‌صورت صریح تغییر یابد. این می‌تواند منجر به برش محتوا یا نام‌چینش شدن شکل‌ها شود.

**آیا کد ارائه‌شده برای تمام انواع شکل‌ها کار می‌کند؟**

بله. تنظیم ارتفاع و عرض برای جعبه‌های متن، تصاویر، نمودارها و جداول به‌طرز یکسانی کار می‌کند.

**چگونه جداول را هنگام تغییر اندازهٔ اسلاید مقیاس‌بندی کنم؟**

کل شکل جدول را همانند هر شکل دیگری مقیاس‌بندی کنید. ردیف‌ها و ستون‌های آن به‌صورت متناسب دنبال می‌شوند، بنابراین پس از آن نیازی به مقیاس‌بندی دوباره آن‌ها ندارید.

**آیا این مقیاس‌بندی برای اسلایدهای اصلی و اسلایدهای طرح‌بندی نیز کار می‌کند؟**

بله، اما باید حلقه‌ای بر روی [Presentation.getMasters](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getMasters) و [Presentation.getLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getLayoutSlides) اجرا کنید و همان منطق مقیاس‌بندی را بر روی شکل‌های آن‌ها اعمال کنید تا در سراسر ارائهٔ شما سازگاری حفظ شود.

**آیا می‌توانم جهت اسلاید (عمودی/افقی) را همراه با تغییر اندازه تغییر دهم؟**

بله. می‌توانید از [SlideSize.setOrientation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/#setOrientation) برای تغییر جهت استفاده کنید. مطمئن شوید منطق مقیاس‌بندی را متناسب تنظیم می‌کنید تا چیدمان حفظ شود.

**آیا محدودیتی برای اندازهٔ اسلایدی که می‌توانم تنظیم کنم وجود دارد؟**

Aspose.Slides از اندازه‌های سفارشی پشتیبانی می‌کند، اما اندازه‌های بسیار بزرگ ممکن است بر عملکرد یا سازگاری با برخی نسخه‌های PowerPoint تاثیر بگذارند.

**چگونه می‌توانم از تحریف شکل‌های با نسبت تصویر ثابت جلوگیری کنم؟**

می‌توانید قبل از مقیاس‌بندی، متد [getAspectRatioLocked](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshapelock/#getAspectRatioLocked) قفل شکل را بررسی کنید. اگر قفل باشد، عرض یا ارتفاع را به‌صورت متناسب تنظیم کنید نه اینکه به‌صورت جداگانه مقیاس‌بندی کنید.