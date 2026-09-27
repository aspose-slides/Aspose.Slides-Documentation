---
title: Aspose.Slides برای Python از طریق Java
second_title: Aspose.Slides برای Python
type: docs
weight: 47
url: /fa/python-java/
is_root: true
keywords:
- Aspose.Slides برای Python از طریق Java
- کتابخانه PowerPoint برای Python
- مدیریت ارائه‌های PowerPoint در Python
- خواندن و نوشتن PowerPoint در Python
- ویرایش اسلایدهای PowerPoint در Python
- صدور PowerPoint به PDF در Python
- صدور PowerPoint به SVG در Python
- پیشنمایش اسلایدها در Python
- افزودن صدا و ویدئو به اسلایدها در Python
- PowerPoint بدون Microsoft Office
- پایتون
- جاوا
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides برای Python از طریق Java را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای کارهای عمومی، مرجع API و پشتیبانی را پیدا کنید."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides برای Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java یک کتابخانه برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Python است، بدون نیاز به Microsoft PowerPoint؛ این کتابخانه موتور Aspose.Slides Java را از طریق JPype در فرآیند Python شما اجرا می‌کند.

این کتابخانه می‌تواند فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره کند، شامل نسخه‌های ماکرو‌پذیر و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر خروجی بدهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/python-java/installation/">نصب</a></li>
<li><a href="/slides/fa/python-java/create-presentation/">ایجاد اولین ارائه</a></li>
<li><a href="/slides/fa/python-java/getting-started/">راهنمای شروع کار</a></li>
</ul>
<p>ارزیابی</p>
<ul>
<li><a href="/slides/fa/python-java/supported-file-formats/">فرمت‌های فایل پشتیبانی‌شده</a></li>
<li><a href="/slides/fa/python-java/evaluate-aspose-slides/">محدودیت‌های نسخه آزمایشی</a></li>
<li><a href="/slides/fa/python-java/licensing/">مجوزدهی</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ساخت با Slides</b></p>
<hr>
<p>کارهای عمومی</p>
<ul>
<li><a href="/slides/fa/python-java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/python-java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/python-java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/python-java/convert-slide/">رندر اسلایدها به عنوان تصویر</a></li>
<li><a href="/slides/fa/python-java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>جریان‌های کاری Slides</p>
<ul>
<li><a href="/slides/fa/python-java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/python-java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/python-java/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/python-java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/python-java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/python-java/examples/">مثال‌ها بر اساس عناصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>منابع و پشتیبانی</b></p>
<hr>
<p>منابع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/fa/python-java/">مرجع API</a></li>
<li><a href="https://releases.aspose.com/slides/fa/python-java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/python-java/known-issues/">مشکلات شناخته‌شده</a></li>
<li><a href="https://releases.aspose.com/slides/fa/python-java/">دریافت</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/fa/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی پولی</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

Python و JDK را نصب کنید، `JAVA_HOME` را تنظیم کنید و یک محیط مجازی ایجاد و فعال کنید همان‌گونه که در [نصب](/slides/fa/python-java/installation/) توضیح داده شده است. سپس JPype و Aspose.Slides را از PyPI نصب کنید:

```sh
python -m pip install JPype1 aspose-slides-java
```

این کد را به‌عنوان *hello.py* ذخیره کنید. این اسکریپت ماشین مجازی Java را راه‌اندازی می‌کند، یک شکل ابری با متن به اسلاید اول یک ارائه جدید اضافه می‌کند و سپس ارائه را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# یک ارائه با یک اسلاید خالی ایجاد کنید.
presentation = Presentation()
try:
    # اسلاید اول را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ابری اضافه کنید و متن آن را تنظیم کنید.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # ارائه را به عنوان فایل PPTX ذخیره کنید.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

آن را در همان محیط مجازی اجرا کنید:

```sh
python hello.py
```

اسکریپت *new_presentation.pptx* را ذخیره می‌کند که شامل یک اسلاید با یک شکل ابری حاوی متن «Hello, Aspose!» است. بدون داشتن لایسنس، فایل ذخیره‌شده همچنین حاوی علامت آب‌نشان ارزیابی می‌شود — برای جزئیات بیشتر به [مجوزدهی](/slides/fa/python-java/licensing/) مراجعه کنید. برای روش‌های بیشتر ایجاد و پر کردن ارائه، به [ایجاد ارائه‌ها](/slides/fa/python-java/create-presentation/) نگاهی بیندازید.