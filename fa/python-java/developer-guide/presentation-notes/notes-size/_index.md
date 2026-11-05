---
title: تغییر اندازه و جهت صفحه یادداشت‌ها در پایتون از طریق جاوا
linktitle: اندازه صفحه یادداشت‌ها
type: docs
weight: 10
url: /fa/python-java/notes-size/
keywords:
- اندازه صفحه یادداشت
- جهت یادداشت‌ها
- یادداشت‌های افقی
- یادداشت‌های عمودی
- اندازه برگه توزیع
- PowerPoint
- ارائه
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "ابعاد صفحه یادداشت‌ها را در Aspose.Slides برای پایتون از طریق جاوا بخوانید و تغییر دهید، جهت را تغییر دهید، اندازه‌های ذخیره‌شده را تأیید کنید و یادداشت‌ها یا برگه‌های توزیع را به PDF و تصاویر صادر کنید."
---
## **نمای کلی**

از [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getNotesSize) برای دسترسی به تنظیمات صفحه یادداشت‌های ارائه استفاده کنید. این متد یک شیء [NotesSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notessize/) بر می‌گرداند که متد [setSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notessize/#setSize) آن ابعاد صفحه را تنظیم می‌کند. اگرچه شیء تنظیمات را نمی‌توان جایگزین کرد، می‌توانید ابعاد جدید را از طریق این متد اختصاص دهید.

عرض و ارتفاع بر حسب **نقطه** مشخص می‌شود، با ۷۲ نقطه در هر اینچ. برای مثال، ۹۰۰ × ۶۰۰ نقطه برابر است با ۱۲٫۵ × ۸⅓ اینچ. این تنظیمات بر کل ارائه اعمال می‌شود، نه بر یادداشت‌های یک اسلاید جداگانه.

| تنظیم | هدف |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getNotesSize) | ابعاد صفحه یادداشت‌ها و ابعاد صفحه‌ای که برای صادرات لیست توزیع استفاده می‌شود را کنترل می‌کند. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlideSize) | ابعاد اسلایدهای معمولی ارائه را از طریق [SlideSize](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesize/) کنترل می‌کند. |

تغییر هر یک از این تنظیمات به‌طور خودکار تنظیم دیگر را تغییر نمی‌دهد. تغییر جهت صفحه یادداشت‌ها همچنین اسلایدهای معمولی را چرخانده نمی‌کند. برای تغییر اندازه اسلایدهای معمولی به [Slide Size](/slides/fa/python-java/slide-size/) مراجعه کنید.

مثال‌های زیر از فایل `sample.pptx` موجود استفاده می‌کنند. برای مثال‌های صادرات، از ارائه‌ای استفاده کنید که حداقل یک اسلاید دارای یادداشت‌های سخنران داشته باشد. هر مثال می‌تواند به‌صورت مستقل اجرا شود.

## **خواندن اندازه و جهت صفحه یادداشت‌ها**

عرض و ارتفاع را بخوانید و برای تعیین جهت آن‌ها را مقایسه کنید: صفحه‌ای که عریض‌تر است به‌صورت افقی (Landscape) است، صفحه‌ای که بلندتر است به‌صورت عمودی (Portrait) است، و ابعاد برابر یک صفحهٔ مربع را توصیف می‌کند. این مثال ابعاد واقعی را به‌صورت نقطه چاپ می‌کند، بدون اینکه به اندازه کاغذ استانداردی فرض کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **تغییر به حالت افقی بدون تغییر اندازه کاغذ**

برای تغییر فقط جهت، عرض و ارتفاع موجود را جابه‌جا کنید. این کار طول هر دو سمت را حفظ می‌کند، حتی برای اندازهٔ سفارشی کاغذ. شرط زیر از تغییر صفحه‌ای که از قبل افقی است به حالت عمودی جلوگیری می‌کند و صفحهٔ مربع را بدون تغییر می‌گذارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای جهت عمودی، از همان اختصاص زمانی که `size.getWidth() > size.getHeight()` استفاده کنید. مگر اینکه بخواهید اندازهٔ کاغذ را نیز تغییر دهید، ابعاد A4 یا Letter را جایگزین نکنید.

## **تنظیم و تأیید یک اندازهٔ سفارشی برای صفحه یادداشت‌ها**

هر دو بعد را به‌صورت همزمان اختصاص دهید، سپس با استفاده از [Presentation.save](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#save) ارائه را ذخیره کنید. این مثال یک صفحهٔ افقی ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند، آن را به‌صورت PPTX ذخیره می‌سازد و سپس فایل ذخیره‌شده را دوباره باز می‌کند تا مقادیر ذخیره‌شده را بررسی کند. مقایسه تحمل ۰٫۰۱ نقطه برای مقادیر شناور را می‌پذیرد؛ این تضمین دقت برای هر قالب فایلی نیست.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

نتیجهٔ مورد انتظار `900.0 x 600.0 points` و `Size preserved: True` است. بررسی یک ارائهٔ تازه باز شده، فایل ذخیره‌شده را تأیید می‌کند، نه فقط تنظیمات در حافظه.

## **صادرات یادداشت‌ها و برگه‌های توزیع**

ابعاد صفحه ناحیهٔ موجود برای طرح‌های یادداشت یا برگه توزیع را تعریف می‌کنند. به‌تنهایی این طرح‌ها را فعال نمی‌کنند: گزینه‌های صادرات نیز باید پیکربندی شوند. صادرات اسلایدهای معمولی همچنان از ابعاد اسلاید استفاده می‌کند.

### **صادرات یادداشت‌ها به PDF و PNG**

برای گنجاندن یادداشت‌ها در PDF، [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notescommentslayoutingoptions/) را به [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) اختصاص دهید. این مثال همچنین اولین اسلاید همراه با یادداشت‌ها را با استفاده از [Slide.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/renderingoptions/) به PNG رندر می‌کند.

حالت [BottomTruncated](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/) یادداشت‌ها را در یک صفحه نگه می‌دارد؛ یادداشت‌هایی که جا نمی‌شوند می‌توانند کوتاه شوند. PDF از صفحات ۹۰۰ × ۶۰۰ نقطه‌ای استفاده می‌کند. در مقیاس تصویر ۱ × ۱ که پایین‌تر استفاده شده، PNG دارای ۹۰۰ × ۶۰۰ پیکسل است. نقطه‌ها هندسهٔ صفحه را توصیف می‌کنند؛ پیکسل‌ها خروجی شطرنجی را توصیف می‌کنند که ابعاد آن نیز به مقیاس رندر وابسته است.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

برای صادرات PDF با یادداشت‌های طولانی، [BottomFull](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notespositions/) صفحات اضافی را در صورت نیاز اجازه می‌دهد. از این حالت با فراخوانی تصویر تک-اسلاید بالا استفاده نکنید، چون آن را پشتیبانی نمی‌کند. پس از تغییر اندازه، خروجی را برای یادداشت‌های برش‌خورده و جای‌گذاری اشیاء notes‑master موجود بررسی کنید؛ تغییر ابعاد صفحه به‌تنهایی تضمین نمی‌کند که تمام محتوا جا بگیرد. برای اطلاعات بیشتر دربارهٔ صادرات یادداشت‌ها به [Convert PowerPoint to PDF with Notes](/slides/fa/python-java/convert-powerpoint-to-pdf-with-notes/) مراجعه کنید.

### **صادرات برگه‌های توزیع به PDF**

از [HandoutLayoutingOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handoutlayoutingoptions/) برای چندین تصویر کوچک اسلاید در یک صفحه استفاده کنید. مثال زیر یک صفحهٔ ۹۰۰ × ۶۰۰ نقطه‌ای تنظیم می‌کند و از [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fa/python-java/aspose.slides/handouttype/) برای چینش حداکثر چهار اسلاید در هر صفحه استفاده می‌کند. پیش‌تنظیم افقی، ترتیب اسلایدها را کنترل می‌کند؛ جهت صفحه از عرض و ارتفاع آن ناشی می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

تغییر اندازهٔ صفحه ناحیهٔ موجود برای شبکهٔ برگه توزیع را تغییر می‌دهد بدون اینکه ابعاد اسلایدهای منبع تغییر کند. برای تصاویر برگه توزیع، از [Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) همراه با طرح‌بندی برگه توزیع استفاده کنید، نه از متد تصویر یک اسلاید جداگانه. در Aspose.Slides، رندرینگ برگه توزیع در سطح ارائه از ابعاد صفحه یادداشت‌ها استفاده می‌کند، در حالی که فراخوانی تصویر اسلاید جداگانه صفحهٔ برگه توزیع را تولید نمی‌کند. برای گزینه‌های طرح‌بندی به [Handoff Mode](/slides/fa/python-java/convert-powerpoint-in-handout-mode/) مراجعه کنید.

## **اندازهٔ صفحه در نمایشگرها، صادرات و چاپ**

اندازهٔ ارائهٔ ذخیره‌شده، اندازهٔ صفحهٔ صادرشده و اندازهٔ کاغذ چاپی را جداگانه نگه دارید:

- **Presentation viewers:** یک نمایشگر می‌تواند یادداشت‌ها را با قوانین چیدمان خود نمایش یا چاپ کند. اگر برنامه‌ای دیگر فایل را ذخیره کند، آن را مجدداً باز کنید و دوباره ابعاد را بررسی کنید؛ تبدیل فرمت آن برنامه ممکن است آن‌ها را نرمال‌سازی کند.
- **Export formats:** مثال‌های PDF یادداشت‌ها و برگه توزیع در بالا از ابعاد صفحهٔ پیکربندی‌شده استفاده می‌کنند. تصاویر شطرنجی از ابعاد پیکسل صحیح و مقیاس رندر استفاده می‌کنند، بنابراین مقادیر نقطه‌ای کسری ممکن است در خروجی تصویر گرد شوند. صادرات اسلایدهای معمولی از اندازهٔ صفحهٔ یادداشت‌ها استفاده نمی‌کند.
- **Printer drivers:** انتخاب کاغذ، چرخش خودکار و تنظیمات مقیاس به صفحه می‌توانند خروجی فیزیکی را بدون تغییر ابعادی که در ارائه یا PDF ذخیره شده‌اند، تغییر دهند. برای یک اندازهٔ کاغذ خاص، تنظیمات چاپگر را هماهنگ کنید و پیش‌نمایش چاپ را بررسی کنید.

## **FAQ**

**آیا می‌توانم اندازهٔ یادداشت‌ها را فقط برای یک اسلاید تنظیم کنم؟**

اندازهٔ صفحهٔ یادداشت‌ها تنظیمی در سطح ارائه است. اسلایدهای جداگانه می‌توانند محتویات یادداشت متفاوتی داشته باشند، اما این ویژگی اندازهٔ صفحهٔ جداگانه‌ای برای هر اسلاید فراهم نمی‌کند.

**چرا تغییر جهت یادداشت‌ها اسلایدهای من را تغییر نداد؟**

صفحات یادداشت و اسلایدهای معمولی ابعاد مستقلی دارند. وقتی می‌خواهید اسلایدها را تغییر اندازه دهید، از تنظیمات اندازهٔ اسلایدهای معمولی استفاده کنید.

**چرا نتیجهٔ ذخیره‌شده یا چاپ‌شده من اندازهٔ متفاوتی دارد؟**

ابتدا ارائهٔ ذخیره‌شده را باز کنید و ابعاد یادداشت‌های آن را مقایسه کنید. اگر این ابعاد تغییر کرده‌اند، بررسی کنید آیا ذخیره یا تبدیل فایل در برنامهٔ دیگری تنظیمات صفحه را تغییر داده است یا نه. اگر نه، طرح‌بندی صادرات، مقیاس تصویر، تنظیمات نمایشگر و انتخاب کاغذ چاپگر را بررسی کنید.