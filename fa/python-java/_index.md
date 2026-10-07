---
title: Aspose.Slides برای Python از طریق Java
second_title: Aspose.Slides برای Python
type: docs
weight: 47
url: /fa/python-java/
is_root: true
keywords:
- Aspose.Slides برای Python از طریق Java
- کتابخانه Python برای PowerPoint
- مدیریت ارائه‌های PowerPoint در Python
- خواندن و نوشتن PowerPoint در Python
- ویرایش اسلایدهای PowerPoint در Python
- خروجی PowerPoint به PDF در Python
- خروجی PowerPoint به SVG در Python
- پیش‌نمایش اسلایدها در Python
- اضافه کردن صدا و ویدیو به اسلایدها در Python
- PowerPoint بدون Microsoft Office
- Python
- Java
- Aspose.Slides
description: "از اینجا شروع کنید: Aspose.Slides برای Python از طریق Java را نصب کنید، اولین ارائه را ایجاد کنید، و راهنماهای وظایف معمول، مرجع API و پشتیبانی را بیابید."
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java یک کتابخانه برای ایجاد، خواندن، ویرایش و تبدیل ارائه‌های PowerPoint و OpenDocument در برنامه‌های Python است، بدون نیاز به Microsoft PowerPoint؛ این کتابخانه موتور Aspose.Slides Java را از طریق JPype در پردازش Python شما اجرا می‌کند.

این کتابخانه فایل‌های PPT، PPTX، PPS، POT و ODP را بارگذاری و ذخیره می‌کند، شامل نسخه‌های دارای ماکرو و قالب، و به فرمت‌های PDF، XPS، HTML، SVG، TIFF، Markdown و تصاویر خروجی می‌دهد.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>شروع کنید</b></p>
<hr>
<p>شروع کار</p>
<ul>
<li><a href="/slides/fa/python-java/installation/">نصب</a></li>
<li><a href="/slides/fa/python-java/create-presentation/">ایجاد اولین ارائه خود</a></li>
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
<p>وظایف معمول</p>
<ul>
<li><a href="/slides/fa/python-java/open-presentation/">باز کردن یک ارائه</a></li>
<li><a href="/slides/fa/python-java/save-presentation/">ذخیره یک ارائه</a></li>
<li><a href="/slides/fa/python-java/convert-powerpoint-to-pdf/">تبدیل به PDF</a></li>
<li><a href="/slides/fa/python-java/convert-slide/">رندر اسلایدها به‌صورت تصویر</a></li>
<li><a href="/slides/fa/python-java/manage-text/">ویرایش متن و اشکال</a></li>
</ul>
<p>گردش کارهای Slides</p>
<ul>
<li><a href="/slides/fa/python-java/powerpoint-charts/">نمودارها</a></li>
<li><a href="/slides/fa/python-java/powerpoint-animation/">انیمیشن‌ها</a></li>
<li><a href="/slides/fa/python-java/manage-media-files/">صدا و ویدیو</a></li>
<li><a href="/slides/fa/python-java/presentation-design/">طراحی اسلاید</a></li>
<li><a href="/slides/fa/python-java/merge-presentation/">ادغام ارائه‌ها</a></li>
</ul>
<p>مثال‌ها</p>
<ul>
<li><a href="/slides/fa/python-java/examples/">مثال‌ها بر اساس عنصر اسلاید</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>مرجع و پشتیبانی</b></p>
<hr>
<p>مرجع</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">مستندات API</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">یادداشت‌های انتشار</a></li>
<li><a href="/slides/fa/python-java/known-issues/">مشکلات شنافته‌شده</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">صفحه محصول</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">دانلود</a></li>
</ul>
<p>پشتیبانی</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">انجمن پشتیبانی رایگان</a></li>
<li><a href="https://helpdesk.aspose.com/">پشتیبانی مشروط با هزینه</a></li>
</ul>
</div>
</div>

------

## **اولین ارائه شما**

Python و یک JDK را نصب کنید، `JAVA_HOME` را تنظیم کنید، و یک محیط مجازی ایجاد و فعال کنید همان‌طور که در [نصب](/slides/fa/python-java/installation/) شرح داده شده است. سپس JPype و Aspose.Slides را از PyPI نصب کنید:

```sh
python -m pip install JPype1 aspose-slides-java
```

این کد را به عنوان *hello.py* ذخیره کنید. این کد ماشین مجازی Java را راه‌اندازی می‌کند، یک شکل ابر با متن به اولین اسلاید یک ارائه جدید اضافه می‌کند و ارائه را ذخیره می‌نماید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# یک ارائه با یک اسلاید خالی ایجاد کنید.
presentation = Presentation()
try:
    # اولین اسلاید را دریافت کنید.
    slide = presentation.getSlides().get_Item(0)

    # یک شکل ابر اضافه کنید و متن آن را تنظیم کنید.
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

اسکریپت فایل *new_presentation.pptx* را با یک اسلاید که شامل یک شکل ابر با متن «Hello, Aspose!» است ذخیره می‌کند. بدون داشتن license، فایل ذخیره‌شده همچنین دارای واترمارک ارزیابی است — به [مجوزدهی](/slides/fa/python-java/licensing/) مراجعه کنید. برای راه‌های بیشتر برای ایجاد و پر کردن یک ارائه، به [ایجاد ارائه‌ها](/slides/fa/python-java/create-presentation/) رجوع کنید.