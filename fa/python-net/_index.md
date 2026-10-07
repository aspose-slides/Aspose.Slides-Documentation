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
- صادرات PowerPoint به PDF با Python
- صادرات PowerPoint به SVG با Python
- ویرایش PowerPoint در Python
- PowerPoint پایتون بدون Microsoft Office
- مدیریت PPTX با Python
- پیشنمایش اسلایدها با Python
- اضافه کردن صدا به اسلایدها در Python
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides برای Python از طریق .NET را نصب کنید، اولین ارائه را ایجاد کنید و راهنماهای کارهای رایج، مرجع API و پشتیبانی را پیدا کنید."
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET یک کتابخانهٔ پایتون برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument است، بدون نیاز به Microsoft PowerPoint یا Microsoft Office.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، شامل انواع ماکرو‌دار و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصویرها خروجی دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/fa/python-net/installation/">نصب</a></li>
<li><a href="/slides/fa/python-net/create-presentation/">ایجاد اولین ارائه خود</a></li>
<li><a href="/slides/fa/python-net/getting-started/">راهنمای شروع به کار</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/fa/python-net/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/python-net/evaluate-aspose-slides/">محدودیت‌های دوره آزمایشی</a></li>
<li><a href="/slides/fa/python-net/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای رایج</p>
<ul>
<li><a href="/slides/fa/python-net/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/python-net/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/python-net/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/python-net/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/python-net/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>گردش‌کارهای Slides</p>
<ul>
<li><a href="/slides/fa/python-net/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/python-net/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/python-net/manage-media-files/">صدا و ویدئو</a></li>
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
<li><a href="https://reference.aspose.com/slides/python-net/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی کمک‌دست پرداختی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائهٔ شما**

پکیج را از PyPI نصب کنید:

```bash
pip install aspose.slides
```

این پکیج شامل runtime .NET مورد استفاده خود است، بنابراین نیازی به نصب .NET ندارید. در لینوکس، همچنین کتابخانه‌های libgdiplus و ICU را نصب کنید، و با استفاده از پایتون سیستم‌عامل Debian یا Ubuntu، دستور را در یک محیط مجازی اجرا کنید. macOS پیش‌نیازهای بیشتری دارد و نصب را در آن تأیید نکرده‌ایم. برای دستورات، پیش‌نیازهای macOS و نسخه‌های پایتون پشتیبانی‌شده به [Installation](/slides/fa/python-net/installation/) مراجعه کنید.

این کد را به عنوان *hello.py* ذخیره کنید:

```py
import aspose.slides as slides

# نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
with slides.Presentation() as presentation:
    # دریافت اولین اسلاید.
    slide = presentation.slides[0]

    # افزودن یک شکل خودکار از نوع CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # ذخیرهٔ ارائه به عنوان فایل PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

آن را با `python hello.py` اجرا کنید. اسکریپت *new_presentation.pptx* را در پوشهٔ فعلی ذخیره می‌کند، که شامل یک اسلاید با شکل ابر است که متن «Hello, Aspose!» را نشان می‌دهد. بدون لایسنس، فایل ذخیره‌شده دارای واترمارک ارزیابی است — برای جزئیات به [مجوزدهی](/slides/fa/python-net/licensing/) مراجعه کنید. برای روش‌های بیشتر برای ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/python-net/create-presentation/) نگاه کنید.