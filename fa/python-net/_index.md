---
title: Aspose.Slides برای Python از طریق .NET
second_title: Aspose.Slides برای Python
type: docs
weight: 35
url: /fa/python-net/
is_root: true
keywords:
- Aspose.Slides برای Python
- اتوماسیون PowerPoint با Python
- کتابخانه PPT پایتون
- صدور PowerPoint به PDF با Python
- صدور PowerPoint به SVG با Python
- ویرایش PowerPoint در Python
- PowerPoint پایتون بدون Microsoft Office
- مدیریت PPTX با Python
- پیش‌نمایش اسلایدها با Python
- اضافه‌کردن صدا به اسلایدها با Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides for Python via .NET را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای مربوط به وظایف عمومی، مرجع API و پشتیبانی را بیابید."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET یک کتابخانه پایتون برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument است، بدون نیاز به Microsoft PowerPoint یا Microsoft Office.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، از جمله نسخه‌های دارای ماکرو و قالب، و می‌تواند به PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر خروجی دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع به کار</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/python-net/installation/">نصب</a></li>
<li><a href="/slides/fa/python-net/create-presentation/">ایجاد اولین ارائه‌تان</a></li>
<li><a href="/slides/fa/python-net/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/python-net/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/python-net/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/python-net/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>وظایف عمومی</p>
<ul>
<li><a href="/slides/fa/python-net/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/python-net/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/python-net/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/python-net/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/python-net/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان‌های کاری Slides</p>
<ul>
<li><a href="/slides/fa/python-net/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/python-net/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/python-net/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/python-net/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/python-net/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/python-net/examples/">مثال‌ها بر اساس عنصر اسلاید</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">مثال‌ها در GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/python-net/">مستندات API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/python-net/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="https://releases.aspose.com/slides/fa/python-net/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">دستگاه پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

پکیج را از PyPI نصب کنید:

```bash
pip install aspose.slides
```

این پکیج شامل زمان‌اجرای .NET است که استفاده می‌کند، بنابراین نیازی به نصب .NET ندارید. در لینوکس، کتابخانه‌های libgdiplus و ICU را نیز نصب کنید، و با سیستم پایتون Debian یا Ubuntu، فرمان را در یک محیط مجازی اجرا کنید. macOS پیش‌نیازهای بیشتری دارد، و ما نصب آن را تأیید نکرده‌ایم. برای فرمان‌ها، پیش‌نیازهای macOS و نسخه‌های پایتون پشتیبانی‌شده، به [نصب](/slides/fa/python-net/installation/) مراجعه کنید.

این کد را به عنوان *hello.py* ذخیره کنید:

```py
import aspose.slides as slides

# یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد کنید.
with slides.Presentation() as presentation:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.slides[0]

    # یک شکل خودکار از نوع CLOUD اضافه کنید.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

آن را با `python hello.py` اجرا کنید. اسکریپت *new_presentation.pptx* را در پوشه فعلی ذخیره می‌کند، با یک اسلاید که شامل شکل ابری است و متن «Hello, Aspose!» را نشان می‌دهد. بدون مجوز، فایل ذخیره‌شده دارای علامت آبشاری ارزیابی است — برای جزئیات به [مجوزدهی](/slides/fa/python-net/licensing/) مراجعه کنید. برای روش‌های بیشتر جهت ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/python-net/create-presentation/) مراجعه کنید.