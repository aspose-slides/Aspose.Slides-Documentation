---
title: چندریسمانی در Aspose.Slides برای پایتون
linktitle: چندریسمانی
type: docs
weight: 200
url: /fa/python-net/multithreading/
keywords:
- چندریسمانی
- چندین رشته
- کارهای موازی
- تبدیل اسلایدها
- اسلایدها به تصویر
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "Aspose.Slides برای پایتون از طریق چندریسمانی .NET پردازش PowerPoint و OpenDocument را بهبود می‌بخشد. بهترین روش‌ها را برای جریان کاری مؤثر ارائه کشف کنید."
---
## **مقدمه**

در حالی که کار موازی با ارائه‌ها امکان‌پذیر است (به‌جز تجزیه/بارگذاری/کلونینگ) و اکثر اوقات همه چیز خوب پیش می‌رود، احتمال کمی وجود دارد که هنگام استفاده از کتابخانه در چندین رشته نتایج نادرست دریافت کنید.

ما به‌شدت توصیه می‌کنیم که **نه** از یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در یک محیط چندرشته‌ای استفاده کنید زیرا ممکن است منجر به خطاها یا شکست‌های پیش‌بینی‌نشده‌ای شود که به‌راحتی قابل تشخیص نیستند.  

بارگذاری، ذخیره‌سازی و/یا کلون کردن یک نمونهٔ کلاس [Presentation](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) در چندین رشته **not** ایمن است. چنین عملیاتی **not** پشتیبانی می‌شود. اگر نیاز به انجام این کارها دارید، باید عملیات را با استفاده از چندین فرایند تک‑ریسمه‌ای به صورت موازی انجام دهید و هر یک از این فرایندها باید از نمونهٔ ارائهٔ خود استفاده کنند.  

## **تبدیل اسلایدهای ارائه به عکس‌ها به صورت موازی**

فرض کنید می‌خواهیم تمام اسلایدهای یک ارائهٔ PowerPoint را به تصاویر PNG به صورت موازی تبدیل کنیم. از آنجا که استفاده از یک نمونهٔ `Presentation` در چندین رشته ناامن است، اسلایدهای ارائه را به ارائه‌های جداگانه تقسیم می‌کنیم و اسلایدها را به تصاویر تبدیل می‌کنیم، به‌طوری که هر ارائه در یک رشته جداگانه استفاده شود. مثال کد زیر نشان می‌دهد چگونه این کار انجام می‌شود.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # استخراج اسلاید i به یک ارائه جداگانه.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # تبدیل اسلاید به یک تصویر.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# صبر برای تکمیل تمام وظایف.
for task in conversion_tasks:
    task.result()

del presentation
```

## **سؤالات متداول**

**آیا نیاز دارم تنظیم مجوز را در هر رشته فراخوانی کنم؟**

خیر. کافی است یک بار برای هر پردازش/دامنهٔ برنامه قبل از شروع رشته‌ها انجام شود. اگر [تنظیم مجوز](/slides/fa/python-net/licensing/) ممکن است به‌صورت همزمان فراخوانی شود (مثلاً هنگام مقداردهی اولیهٔ تنبل)، آن فراخوانی را همگام‌سازی کنید زیرا خود متد تنظیم مجوز ریسه‑امن نیست.

**آیا می‌توانم اشیای `Presentation` یا `Slide` را بین رشته‌ها پاس دهم؟**

پاس دادن اشیای «زنده» ارائه بین رشته‌ها توصیه نمی‌شود: برای هر رشته از نمونه‌های مستقل استفاده کنید یا پیش‌از پیش ارائه‌ها/کانتینرهای اسلاید جداگانه برای هر رشته ایجاد کنید. این رویکرد مطابق با توصیهٔ کلی برای عدم به اشتراک‌گذاری یک نمونهٔ ارائهٔ تک بین رشته‌ها است.

**آیا ایمن است که خروجی به فرمت‌های مختلف (PDF، HTML، تصاویر) را به صورت موازی انجام داد به شرط آنکه هر رشته یک نمونهٔ `Presentation` خود داشته باشد؟**

بله. با نمونه‌های مستقل و مسیرهای خروجی جداگانه، این کارها معمولاً به‌درستی به صورت موازی اجرا می‌شوند؛ از هر گونه شیء ارائهٔ مشترک و جریان‌های ورودی/خروجی مشترک خودداری کنید.

**در مورد تنظیمات سراسری فونت (پوشه‌ها، جایگزینی‌ها) در حالت چندرشته‌ای چه کاری باید انجام دهم؟**

تمام تنظیمات سراسری فونت را قبل از شروع رشته‌ها مقداردهی کنید و در طول کار موازی آن‌ها را تغییر ندهید. این کار رقابت‌ها را هنگام دسترسی به منابع فونت مشترک از بین می‌برد.