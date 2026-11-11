---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در پایتون
linktitle: اندازه صفحه یادداشت
type: docs
weight: 10
url: /fa/python-net/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت‌ها
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه برگه خلاصه
- پاورپوینت
- ارائه
- PPT
- PPTX
- پایتون
- Aspose.Slides
description: "اندازه صفحه یادداشت‌ها را در Aspose.Slides برای پایتون از طریق .NET بخوانید و تغییر دهید، جهت را تغییر دهید، اندازه‌های ذخیره‌شده را تأیید کنید و یادداشت‌ها یا برگه‌های خلاصه را به PDF و تصویر صادر کنید."
---
## **بررسی کلی**

از [Presentation.notes_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/notes_size/) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این ویژگی یک شیء [NotesSize](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notessize/) برمی‌گرداند که ویژگی [size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/notessize/size/) آن قابل نوشتن است. اگرچه خود شیء تنظیمات فقط‑خواندنی است، می‌توانید ابعاد جدیدی را به ویژگی size انتساب دهید.

عرض و ارتفاع بر حسب **نقطه** (point) تعیین می‌شوند؛ هر اینچ ۷۲ نقطه دارد. به عنوان مثال، ۹۰۰ × ۶۰۰ نقطه معادل ۱۲٫۵ × ۸⅓ اینچ است. این تنظیمات به سطح ارائه اعمال می‌شود، نه به یادداشت‌های یک اسلاید منفرد.

| تنظیمات | هدف |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/notes_size/) | ابعاد صفحه یادداشت‌ها و ابعادی که برای استخراج برگه‌های خلاصه (handout) استفاده می‌شود را کنترل می‌کند. |
| [Presentation.slide_size](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/slide_size/) | ابعاد اسلایدهای عادی ارائه را از طریق [SlideSize](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slidesize/) کنترل می‌کند. |

تغییر هریک از این تنظیمات به‌طور خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها نیز اسلایدهای عادی را چرخانده نمی‌کند. برای تغییر اندازه اسلایدهای عادی، به [Slide Size](/slides/fa/python-net/slide-size/) مراجعه کنید.

مثال‌های زیر از یک فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های استخراج، از ارائه‌ای که حداقل یک اسلاید دارای یادداشت‌های سخنران است استفاده کنید. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت مقایسه کنید: صفحه‌ای که عرض بیشتری دارد حالت افقی (landscape) دارد، صفحه‌ای که ارتفاع بیشتری دارد حالت عمودی (portrait) است و ابعاد برابر توصیفگر صفحهٔ مربع است. این مثال اندازه واقعی را بر حسب نقطه چاپ می‌کند، بدون این‌که اندازهٔ کاغذ استانداردی فرض شود.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **تغییر به حالت افقی بدون تغییر اندازهٔ کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابجا کنید. این کار طول هر دو طرف را حفظ می‌کند، حتی اگر اندازهٔ کاغذ سفارشی باشد. شرط زیر از تغییر صفحه‌ای که قبلاً افقی است به حالت عمودی جلوگیری می‌کند و صفحهٔ مربعی را دست‌نخورده می‌گذارد.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

برای جهت عمودی، همان انتساب را زمانی که `size.width > size.height` باشد استفاده کنید. مگر اینکه بخواهید اندازهٔ کاغذ را نیز تغییر دهید، ابعاد A4 یا Letter را جایگزین نکنید.

## **تنظیم و تأیید اندازهٔ سفارشی صفحه یادداشت‌ها**

هر دو بعد را به‌صورت همزمان انتساب دهید، سپس از [Presentation.save](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/save/) برای نوشتن ارائه استفاده کنید. این مثال یک صفحهٔ افقی ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند، به‌صورت PPTX ذخیره می‌کند و سپس فایل ذخیره‌شده را باز می‌کند تا مقادیر ذخیره‌شده را بررسی کند. مقایسه تحمل خطای ۰٫۰۱ نقطه را برای مقادیر شناور در نظر می‌گیرد؛ این تضمینی برای دقت در هر قالب فایلی نیست.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

نتیجهٔ مورد انتظار `900 x 600 points` و `Size preserved: True` است. بررسی یک ارائهٔ تازه بازشده، فایل ذخیره‌شده را تأیید می‌کند نه فقط تنظیمات در حافظه.

## **استخراج یادداشت‌ها و برگه‌های خلاصه**

ابعاد صفحه ناحیهٔ موجود برای چیدمان یادداشت‌ها یا برگه‌های خلاصه را تعیین می‌کند. این تنظیمات به تنهایی آن چیدمان‌ها را فعال نمی‌سازد: گزینه‌های استخراج نیز باید پیکربندی شوند. استخراج اسلایدهای عادی همچنان از ابعاد اسلاید استفاده می‌کند.

### **استخراج یادداشت‌ها به PDF و PNG**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notescommentslayoutingoptions/) را به [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) انتساب دهید تا یادداشت‌ها در PDF گنجانده شوند. این مثال همچنین اولین اسلاید همراه با یادداشت‌ها را با استفاده از [Slide.get_image](https://reference.aspose.com/slides/fa/python-net/aspose.slides/slide/get_image/) و [RenderingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/renderingoptions/) به PNG رندر می‌کند.

حالت [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌گیرند می‌توانند قطع شوند. PDF از صفحات ۹۰۰ × ۶۰۰ نقطه‌ای استفاده می‌کند. در مقیاس تصویر ۱ × ۱ استفاده‌شده در ادامه، PNG دارای ۹۰۰ × ۶۰۰ پیکسل است. نقاط شکل صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی شطرنجی را توصیف می‌کنند که ابعاد آن نیز به مقیاس رندر وابسته است.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

برای استخراج PDF با یادداشت‌های طولانی، [BOTTOM_FULL](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/notespositions/) صفحات اضافی را در صورت نیاز فراهم می‌کند. از این حالت همراه با فراخوانی تصویر تک‑اسلاید بالا استفاده نکنید، زیرا از آن پشتیبانی نمی‌شود. پس از تغییر اندازه، خروجی را برای یادداشت‌های بریده‌شده و مکان‌گذاری اشیاء notes‑master موجود بررسی کنید؛ تغییر تنها ابعاد صفحه نباید به‌عنوان تضمینی برای جایگیری تمام محتوا تلقی شود. برای اطلاعات بیشتر درباره استخراج یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/python-net/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **استخراج برگه‌های خلاصه به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handoutlayoutingoptions/) برای چندین تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر یک صفحهٔ ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند و از [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/fa/python-net/aspose.slides.export/handouttype/) برای چیدمان حداکثر چهار اسلاید در هر صفحه استفاده می‌کند. پیش‌تنظیم افقی ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن تعیین می‌شود.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

تغییر اندازهٔ صفحه حوزهٔ قابل استفاده برای شبکهٔ برگه‌های خلاصه را بدون تغییر ابعاد اسلایدهای منبع تغییر می‌دهد. برای تصاویر برگه‌های خلاصه، از [Presentation.get_images](https://reference.aspose.com/slides/fa/python-net/aspose.slides/presentation/get_images/) همراه با چیدمان برگه‌خلاصه استفاده کنید، نه متد تصویر یک اسلاید منفرد. در Aspose.Slides، رندرینگ برگه‌خلاصه در سطح ارائه از ابعاد صفحهٔ یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید منفرد صفحهٔ برگه‌خلاصه را تولید نمی‌کند. برای گزینه‌های چیدمان به [Handout Mode](/slides/fa/python-net/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازهٔ صفحه در بینندگان، استخراج و چاپ**

اندازهٔ ذخیره‌شدهٔ ارائه، اندازهٔ صفحهٔ استخراج‌شده و اندازهٔ کاغذ چاپی را متمایز نگه دارید:

- **بینندگان ارائه:** یک بیننده می‌تواند یادداشت‌ها را با قوانین چیدمان خود نمایش یا چاپ کند. اگر برنامهٔ دیگری فایل را ذخیره کرد، آن را دوباره باز کنید و ابعاد را بررسی کنید؛ تبدیل فرمت توسط آن برنامه ممکن است آنها را نرمال‌سازی کند.
- **قالب‌های استخراج:** مثال‌های PDF یادداشت‌ها و برگه‌خلاصه در بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر شطرنجی از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. استخراج اسلایدهای عادی از اندازهٔ صفحهٔ یادداشت‌ها استفاده نمی‌کند.
- **درایورهای چاپگر:** انتخاب کاغذ، چرخش خودکار و تنظیمات تناسب به صفحه می‌تواند خروجی فیزیکی را بدون تغییر ابعاد ذخیره‌شده در ارائه یا PDF تغییر دهد. برای اندازهٔ کاغذ خاص، تنظیمات چاپگر را هماهنگ کنید و پیش‌نمایش چاپ را بررسی کنید.

## **سؤالات متداول**

**آیا می‌توانم اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحهٔ یادداشت‌ها یک تنظیم سطح ارائه است. اسلایدهای منفرد می‌توانند محتوای یادداشت متفاوتی داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهایم را تغییر نداد؟**

صفحه‌های یادداشت و اسلایدهای عادی ابعاد مستقل دارند. برای تغییر اندازهٔ خود اسلایدها از تنظیمات اندازهٔ اسلاید عادی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ شده من اندازهٔ متفاوتی دارد؟**

اولاً ارائهٔ ذخیره‌شده را دوباره باز کنید و ابعاد یادداشت‌های آن را مقایسه کنید. اگر این ابعاد تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامهٔ دیگری تنظیمات صفحه را تغییر داده است یا نه. اگر نه، چیدمان استخراج، مقیاس تصویر، تنظیمات بیننده و انتخاب کاغذ چاپگر را بررسی کنید.