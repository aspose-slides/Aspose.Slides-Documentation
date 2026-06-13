---
title: مدیریت گرافیک‌های SmartArt در ارائه‌ها با استفاده از Python
linktitle: گرافیک‌های SmartArt
type: docs
weight: 20
url: /fa/python-net/manage-smartart-shape/
keywords:
- شیء SmartArt
- گرافیک SmartArt
- سبک SmartArt
- رنگ SmartArt
- ایجاد SmartArt
- افزودن SmartArt
- ویرایش SmartArt
- تغییر SmartArt
- دسترسی به SmartArt
- نوع طرح‌بندی SmartArt
- PowerPoint
- ارائه
- Python
- Aspose.Slides
description: "ایجاد، ویرایش و استایل‌گذاری خودکار SmartArt در PowerPoint با استفاده از Python از طریق .NET و Aspose.Slides را فراهم می‌کند، همراه با مثال‌های کد مختصر و راهنمایی‌های متمرکز بر عملکرد."
---
## **مرور کلی**

Aspose.Slides به شما امکان می‌دهد گرافیک‌های SmartArt را در ارائه‌های PowerPoint به‌صورت برنامه‌نویسی ایجاد و مدیریت کنید. این مقاله توضیح می‌دهد چگونه یک شکل SmartArt را به یک اسلاید اضافه کنید، به اشکال SmartArt موجود دسترسی پیدا کنید، SmartArt را بر اساس یک نوع طرح‌بندی خاص پیدا کنید و ظاهر بصری آن را با تغییر سبک SmartArt یا سبک رنگی به‌روز کنید.

مثال‌ها نشان می‌دهند چگونه از طریق مجموعه‌ی اشکال اسلاید ارائه، با اشکال SmartArt کار کنید، بررسی کنید که آیا یک شکل SmartArt است و سپس ویژگی‌های آن را تغییر یا بررسی کنید.

## **ایجاد اشکال SmartArt**

Aspose.Slides for Python via .NET به شما امکان می‌دهد اشکال سفارشی SmartArt را از ابتدا به اسلایدها اضافه کنید. API این کار را آسان می‌کند. برای افزودن یک شکل SmartArt به یک اسلاید:

1. یک نمونه از کلاس [ارائه]({{guid}}) ایجاد کنید.
2. اسلاید هدف را بر اساس ایندکس آن به‌دست آورید.
3. یک شکل SmartArt اضافه کنید و نوع طرح‌بندی آن را مشخص کنید.
4. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# نمونه‌سازی کلاس Presentation.
with slides.Presentation() as presentation:
    # دسترسی به اسلاید ارائه.
    slide = presentation.slides[0]
    # افزودن یک شکل SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # ذخیرهٔ ارائه در دیسک.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **دستیابی به اشکال SmartArt در اسلایدها**

کد زیر نشان می‌دهد چگونه به اشکال SmartArt در یک اسلاید دسترسی پیدا کنید. این نمونه در هر شکل اسلاید تکرار می‌کند و بررسی می‌کند که آیا آن یک شیء [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/) است یا خیر.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# بارگذاری فایل ارائه.
with slides.Presentation("SmartArt.pptx") as presentation:
    # تکرار بر تمام اشکال در اسلاید اول.
    for shape in presentation.slides[0].shapes:
        # بررسی اینکه آیا شکل یک شکل SmartArt است.
        if isinstance(shape, smartart.SmartArt):
            # چاپ نام شکل.
            print("Shape name:", shape.name)
```

## **دستیابی به اشکال SmartArt با نوع طرح‌بندی مشخص**

مثال زیر نشان می‌دهد چگونه به یک شکل SmartArt با نوع طرح‌بندی مشخص دسترسی پیدا کنید. توجه داشته باشید که نمی‌توانید نوع طرح‌بندی SmartArt را تغییر دهید؛ این مقدار فقط‑خواندنی است و هنگام ایجاد شکل تنظیم می‌شود.

1. یک نمونه از کلاس [ارائه]({{guid}}) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. به اسلاید اول بر اساس ایندکس مراجعه کنید.
3. در تمام اشکال اسلاید اول تکرار کنید.
4. بررسی کنید که آیا شکل یک شیء [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/) است یا خیر.
5. اگر نوع طرح‌بندی شکل SmartArt با آنچه نیاز دارید مطابقت داشته باشد، اقدامات مورد نیاز را انجام دهید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # تکرار بر تمام اشکال در اسلاید اول.
    for shape in presentation.slides[0].shapes:
        # بررسی اینکه آیا شکل یک شکل SmartArt است.
        if isinstance(shape, smartart.SmartArt):
            # بررسی نوع طرح‌بندی SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **تغییر سبک شکل SmartArt**

مثال زیر نشان می‌دهد چگونه اشکال SmartArt را پیدا کرده و سبک آن‌ها را تغییر دهید:

1. یک [ارائه]({{guid}}) ایجاد کنید و فایل حاوی شکل(های) SmartArt را بارگذاری کنید.
2. به اسلاید اول بر اساس ایندکس مراجعه کنید.
3. در هر شکل اسلاید اول تکرار کنید.
4. شکل SmartArt با سبک مشخص را پیدا کنید.
5. سبک جدید را به شکل SmartArt اختصاص دهید.
6. ارائه را ذخیره کنید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # تکرار بر تمام اشکال در اسلاید اول.
    for shape in presentation.slides[0].shapes:
        # بررسی اینکه آیا شکل یک شکل SmartArt است.
        if isinstance(shape, smartart.SmartArt):
            # بررسی سبک SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # تغییر سبک SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # ذخیرهٔ ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تغییر سبک رنگی اشکال SmartArt**

این مثال نشان می‌دهد چگونه سبک رنگی یک شکل SmartArt را تغییر دهید. کد نمونه یک شکل SmartArt با سبک رنگی مشخص را پیدا کرده و به‌روزرسانی می‌کند.

1. یک نمونه از کلاس [ارائه]({{guid}}) ایجاد کنید و ارائه‌ای را که شامل شکل(های) SmartArt است بارگذاری کنید.
2. به اسلاید اول بر اساس ایندکس مراجعه کنید.
3. در هر شکل اسلاید اول تکرار کنید.
4. بررسی کنید که آیا شکل یک شیء [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/) است یا خیر.
5. شکل SmartArt با سبک رنگی مشخص را پیدا کنید.
6. سبک رنگی جدید را برای آن شکل SmartArt تنظیم کنید.
7. ارائه را ذخیره کنید.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # تکرار بر تمام اشکال در اسلاید اول.
    for shape in presentation.slides[0].shapes:
        # بررسی اینکه آیا شکل یک شکل SmartArt است.
        if isinstance(shape, smartart.SmartArt):
            # بررسی نوع رنگ.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # تغییر نوع رنگ.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # ذخیرهٔ ارائه.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **سوالات متداول**

**آیا می‌توانم SmartArt را به‌عنوان یک شیء واحد انیمیشن‌گذاری کنم؟**

بله. SmartArt یک شکل است، بنابراین می‌توانید از طریق API انیمیشن‌ها [انیمیشن‌های استاندارد](/slides/fa/python-net/powerpoint-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) به‌همان‌صورت اشکال دیگر استفاده کنید.

**اگر شناسه داخلی SmartArt را ندانم، چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم؟**

متن جایگزین (AltText) را تنظیم و استفاده کنید و بر اساس آن مقدار شکل را جستجو کنید—این روش پیشنهادی برای یافتن شکل هدف است.

**آیا می‌توانم SmartArt را با دیگر اشکال گروه‌بندی کنم؟**

بله. می‌توانید SmartArt را با دیگر اشکال (تصاویر، جدول‌ها و غیره) گروه‌بندی کنید و سپس [مدیریت گروه](/slides/fa/python-net/group/) را انجام دهید.

**چگونه می‌توانم تصویر یک SmartArt خاص (مثلاً برای پیش‌نمایش یا گزارش) دریافت کنم؟**

یک تصویر کوچک/بندکش از شکل را صادر کنید؛ کتابخانه می‌تواند [رندر کردن اشکال فردی](/slides/fa/python-net/create-shape-thumbnails/) را به فایل‌های رستر (PNG/JPG/TIFF) انجام دهد.

**آیا ظاهر SmartArt هنگام تبدیل کل ارائه به PDF حفظ می‌شود؟**

بله. موتور رندر برای [خروجی PDF](/slides/fa/python-net/convert-powerpoint-to-pdf/) با دقت بالا هدف‌گذاری می‌شود و گزینه‌های متنوعی برای کیفیت و سازگاری ارائه می‌دهد.