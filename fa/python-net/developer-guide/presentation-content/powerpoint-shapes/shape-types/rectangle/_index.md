---
title: افزودن مستطیل‌ها به ارائه‌ها در پایتون
linktitle: مستطیل
type: docs
weight: 80
url: /fa/python-net/rectangle/
keywords:
- افزودن مستطیل
- ایجاد مستطیل
- شکل مستطیل
- مستطیل ساده
- مستطیل قالب‌بندی‌شده
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "ارائه‌های PowerPoint و OpenDocument خود را با افزودن مستطیل‌ها با Aspose.Slides برای پایتون از طریق .NET ارتقا دهید - به‌راحتی اشکال را به‌صورت برنامه‌نویسی طراحی و تغییر دهید."
---
## **مرور کلی**

این مقاله نشان می‌دهد چگونه می‌توان اشکال مستطیلی را به اسلایدهای PowerPoint با استفاده از Aspose.Slides اضافه کرد. در آن به ایجاد یک مستطیل ساده، ایجاد یک مستطیل قالب‌بندی شده، و ذخیره ارائه به‌روز شده به صورت فایل PPTX پرداخته شده است.

همچنین نحوه اعمال قالب‌بندی پایه برای مستطیل، مانند رنگ پر شدگی ثابت، رنگ خط و ضخامت خط را می‌بینید. علاوه بر این، بخش پرسش‌های متداول مقاله به کارهای مرتبط با مستطیل اشاره دارد، از جمله گوشه‌های گرد، پر کردن با تصویر، افکت‌های بصری، لینک‌های هیپرلینک، قفل‌کردن شکل، گزینه‌های خروجی و ویژگی‌های مؤثر.

## **ایجاد مستطیل ساده**
مانند موضوعات قبلی، این نیز درباره افزودن یک شکل است و این بار شکلی که بررسی می‌کنیم مستطیل است. در این موضوع توضیح داده‌ایم که چگونه توسعه‌دهندگان می‌توانند مستطیل‌های ساده یا قالب‌بندی‌شده را به اسلایدهای خود با Aspose.Slides برای Python via .NET اضافه کنند. برای افزودن یک مستطیل ساده به اسلاید انتخاب‌شده‌ی ارائه، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
1. یک IAutoShape از نوع Rectangle را با استفاده از متد AddAutoShape که توسط شیء IShapes در دسترس است، اضافه کنید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.

در مثال زیر، یک مستطیل ساده را به اولین اسلاید ارائه اضافه کرده‌ایم.

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation() as pres:
    # دریافت اولین اسلاید
    sld = pres.slides[0]

    # افزودن خودشکل از نوع مستطیل
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # نوشتن فایل PPTX بر روی دیسک
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ایجاد مستطیل قالب‌بندی شده**
برای افزودن یک مستطیل قالب‌بندی شده به اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation ](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/) ایجاد کنید.
1. با استفاده از Index آن، مرجع یک اسلاید را به دست آورید.
1. یک IAutoShape از نوع Rectangle را با استفاده از متد AddAutoShape که توسط شیء IShapes در دسترس است، اضافه کنید.
1. نوع پر شدگی مستطیل را به Solid تنظیم کنید.
1. رنگ مستطیل را با استفاده از ویژگی SolidFillColor.Color که توسط شیء FillFormat مرتبط با شیء IShape ارائه می‌شود، تنظیم کنید.
1. رنگ خطوط مستطیل را تنظیم کنید.
1. ضخامت خطوط مستطیل را تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به صورت فایل PPTX بنویسید.
   مراحل بالا در مثال زیر پیاده‌سازی شده‌اند.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است
with slides.Presentation() as pres:
    # دریافت اولین اسلاید
    sld = pres.slides[0]

    # افزودن خودشکل از نوع مستطیل
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # اعمال برخی قالب‌بندی‌ها بر شکل مستطیل
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # اعمال برخی قالب‌بندی‌ها بر خط مستطیل
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #نوشتن فایل PPTX بر روی دیسک
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **پرسش‌های متداول**

**چگونه مستطیلی با گوشه‌های گرد اضافه کنم؟**

از نوع شکل [rounded‑corner](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shapetype/) استفاده کنید و شعاع گوشه‌ها را در ویژگی‌های شکل تنظیم کنید؛ گرد کردن می‌تواند برای هر گوشه به صورت جداگانه از طریق تنظیمات ژئومتری اعمال شود.

**چگونه یک مستطیل را با تصویر (بافت) پر کنم؟**

نوع پر شدگی [picture](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) را انتخاب کنید، منبع تصویر را فراهم کنید و حالت‌های [stretching/tiling](https://reference.aspose.com/slides/fa/python-net/aspose.slides/picturefillmode/) را پیکربندی کنید.

**آیا می‌توان به مستطیل سایه و درخشندگی داد؟**

بله. [سایهٔ بیرونی/درونی، درخشندگی و لبه‌های نرم](/slides/fa/python-net/shape-effect/) موجود هستند و می‌توان پارامترهای آن‌ها را تنظیم کرد.

**آیا می‌توانم مستطیل را به دکمه‌ای با لینک تبدیل کنم؟**

بله. برای کلیک بر روی شکل، یک [hyperlink اختصاص دهید](/slides/fa/python-net/manage-hyperlinks/) (رفتن به اسلاید، فایل، آدرس وب یا ایمیل).

**چگونه می‌توانم از جابجا شدن و تغییرات مستطیل جلوگیری کنم؟**

از [قفل‌کردن شکل](/slides/fa/python-net/applying-protection-to-presentation/) استفاده کنید: می‌توانید جابجایی، تغییر اندازه، انتخاب یا ویرایش متن را ممنوع کنید تا چیدمان حفظ شود.

**آیا می‌توانم یک مستطیل را به تصویر رستر یا SVG تبدیل کنم؟**

بله. می‌توانید [شکل را به تصویر رندر کنید](/slides/fa/python-net/shape/get_image/) با اندازه/مقیاس مشخص یا آن را به عنوان SVG [استخراج کنید](/slides/fa/python-net/shape/write_as_svg/) برای استفادهٔ برداری.

**چگونه می‌توانم به‌سرعت ویژگی‌های واقعی (effective) یک مستطیل را با در نظر گرفتن تم و ارث‌بری دریافت کنم؟**

از [ویژگی‌های مؤثر شکل](/slides/fa/python-net/shape-effective-properties/) استفاده کنید: API مقادیر محاسبه‌شده را بر می‌گرداند که شامل استایل‌های تم، چیدمان و تنظیمات محلی می‌شود و تحلیل قالب‌بندی را ساده می‌کند.