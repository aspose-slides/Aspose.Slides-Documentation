---
title: مدیریت سرصفحه‌ها و پانویس‌های ارائه در پایتون از طریق جاوا
linktitle: سرصفحه و پانویس
type: docs
weight: 140
url: /fa/python-java/presentation-header-and-footer/
keywords:
- سرصفحه
- متن سرصفحه
- پانویس
- متن پانویس
- تنظیم سرصفحه
- تنظیم پانویس
- جزوه
- یادداشت
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه نگهدارنده‌های پانویس، تاریخ-زمان، شماره اسلاید و سرصفحه را در اسلایدها، صفحات یادداشت و جزوه‌ها با Aspose.Slides برای پایتون از طریق جاوا مدیریت کنید."
---
## **نمای کلی**

PowerPoint برای انواع صفحه‌های مختلف از نگهدارنده‌های متفاوت سرصفحه و پانویس استفاده می‌کند. Aspose.Slides برای Python از طریق Java به شما امکان می‌دهد متن و قابلیت نمایش این نگهدارنده‌ها را از طریق کلاس‌های مدیریت سرصفحه/پانویس کنترل کنید.

در دسترس بودن نگهدارنده‌ها بستگی به محدوده دارد:

| محدوده | سرصفحه | پانویس | تاریخ/زمان | شماره اسلاید/صفحه |
|---|---|---|---|---|
| اسلاید عادی | خیر | بله | بله | بله |
| مستر یادداشت | بله | بله | بله | بله |
| اسلاید یادداشت | بله | بله | بله | بله |
| مستر جزوه | بله | بله | بله | بله |

یک اسلاید نمایش عادی هیچ نگهدارنده سرصفحه‌ای ندارد. سرصفحه‌ها در صفحات یادداشت و جزوه‌ها موجود هستند. برای اسلایدهای عادی، به جای سرصفحه از نگهدارنده‌های پانویس، تاریخ/زمان و شماره اسلاید استفاده کنید.

محدوده‌ی تغییری که اعمال می‌کنید به مدیری که استفاده می‌کنید بستگی دارد. کلاس [SlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideheaderfootermanager/) یک اسلاید عادی را کنترل می‌کند. کلاس [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را کنترل می‌کند. مدیران مستر و چیدمان نیز می‌توانند تنظیمات را به اسلایدهای وابسته منتقل کنند، در حالی که کلاس [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) مستر جزوه را کنترل می‌کند.

## **تنظیم پانویس، تاریخ/زمان و شماره اسلایدها در اسلایدهای عادی**

برای اسلایدهای عادی، فرآیند پایه این است که به مدیر سرصفحه/پانویس هر اسلاید دسترسی پیدا کنید، متن پانویس و تاریخ/زمان را تنظیم کنید، نگهدارنده‌های مورد نیاز را فعال کنید و ارائه را ذخیره کنید. شماره اسلایدها توسط ارائه تولید می‌شوند، بنابراین فقط نیاز به کنترل نمایش آن‌ها دارید.

از [setFooterText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) و [setDateTimeText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) برای تنظیم متن استفاده کنید و از [setFooterVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)، [setDateTimeVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) و [setSlideNumberVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) برای نمایش نگهدارنده‌های مربوطه استفاده کنید.

مثال زیر به‌صورت سراسری پانویس، متن تاریخ/زمان و نمایش شماره اسلاید را برای تمام اسلایدهای عادی اعمال می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر فقط نیاز به به‌روزرسانی یک اسلاید دارید، به جای پیمایش کل مجموعه از متد [getSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getSlides) برای دسترسی مستقیم به آن اسلاید استفاده کنید.

## **تنظیم سرصفحه و پانویس در مستر یادداشت**

مستر یادداشت قالب‌بندی عمومی و رفتار نگهدارنده‌ها را برای صفحات یادداشت تعریف می‌کند. زمانی که می‌خواهید فقط مستر یادداشت را تغییر دهید، از کلاس [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

مثال زیر سرصفحه، پانویس و متن تاریخ/زمان را روی مستر یادداشت تنظیم می‌کند و تمام نگهدارنده‌های پشتیبانی‌شده را در آن مستر قابل مشاهده می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متد `getMasterNotesSlide` زمانی که ارائه شامل مستر یادداشت نباشد، مقدار `None` برمی‌گرداند.

## **اعمال تنظیمات مستر یادداشت روی اسلایدهای فرزند یادداشت**

یک مستر یادداشت می‌تواند تنظیمات سرصفحه و پانویس را هم برای خود و هم برای تمام اسلایدهای یادداشت وابسته اعمال کند. وقتی همان تنظیمات باید در کل سلسله‌مراتب یادداشت‌ها اعمال شوند، از متدهای انتشار اختصاصی در [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/) استفاده کنید.

به عنوان مثال، متدهای [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) و [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) سرصفحه مستر یادداشت و تمام سرصفحه‌های فرزند را به‌روزرسانی می‌کنند. متدهای معادل برای پانویس، تاریخ/زمان و شماره اسلاید نیز موجود هستند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

متدهای انتشار استفاده‌شده در بالا عبارتند از [setFooterAndChildFootersText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText)، [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility)، [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText)، [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) و [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **تنظیم سرصفحه و پانویس در یک اسلاید یادداشت اختصاصی**

یک اسلاید یادداشت به یک اسلاید عادی خاص تعلق دارد. وقتی می‌خواهید فقط همان صفحه یادداشت را سفارشی کنید، از کلاس [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslideheaderfootermanager/) استفاده کنید.

متد [addNotesSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslidemanager/#addNotesSlide) اسلاید یادداشت مربوط به اسلاید فعلی را بازمی‌گرداند و در صورت عدم وجود، یکی ایجاد می‌کند. مثال زیر صفحه یادداشت مرتبط با اولین اسلاید ارائه را پیکربندی می‌کند:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

اگر ابتدا تنظیمات را از مستر یادداشت انتشار دهید و سپس یک اسلاید یادداشت منفرد را تغییر دهید، تنظیمات بعدی برای هر اسلاید امکان سفارشی‌سازی مستقل آن صفحه یادداشت را می‌دهد.

## **تنظیم سرصفحه و پانویس در مستر جزوه**

صفحات جزوه از مستر جزوه برای نگهدارنده‌های سرصفحه، پانویس، تاریخ/زمان و شماره صفحه استفاده می‌کنند. برخلاف صفحات یادداشت، تنظیمات جزوه از طریق مستر جزوه مدیریت می‌شوند و نه از طریق اسلایدهای جزوهٔ تک‌تک.

از متد `getMasterHandoutSlide` برای دسترسی به مستر جزوه استفاده کنید. اگر موجود نباشد، با فراخوانی `setDefaultMasterHandoutSlide` مستر جزوهٔ پیش‌فرض را ایجاد کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **درک محدوده و ارث‌بری**

مدیر سرصفحه/پانویسی را انتخاب کنید که با محدوده‌ای که می‌خواهید تغییر دهید مطابقت داشته باشد:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slideheaderfootermanager/) تنظیمات پانویس، تاریخ/زمان و شماره اسلاید را برای یک اسلاید عادی تغییر می‌دهد.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslideheaderfootermanager/) یک اسلاید چیدمان را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتشر کند.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslideheaderfootermanager/) یک مستر اسلاید عادی را کنترل می‌کند و می‌تواند تنظیمات پشتیبانی‌شده را به اسلایدهای وابسته منتشر کند.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masternotesslideheaderfootermanager/) مستر یادداشت را کنترل می‌کند و می‌تواند تنظیمات را به تمام اسلایدهای یادداشت وابسته منتشر کند.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/notesslideheaderfootermanager/) یک اسلاید یادداشت را تغییر می‌دهد و علاوه بر پانویس، تاریخ/زمان و شماره اسلاید، یک نگهدارنده سرصفحه نیز پشتیبانی می‌کند.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) مستر جزوه را تغییر می‌دهد و از چهار نوع نگهدارنده پشتیبانی می‌کند.

از انتشار از یک مستر یا چیدمان زمانی استفاده کنید که همان تنظیم باید در تمام سطوح سلسله‌مراتبی آن اعمال شود. وقتی نیاز به تنظیم محلی برای یک صفحه دارید، از مدیر اسلاید منفرد یا اسلاید‑یادداشت استفاده کنید.

## **سوالات متداول**

**آیا می‌توانم سرصفحه‌ای به یک اسلاید عادی اضافه کنم؟**

خیر. PowerPoint برای اسلایدهای عادی نگهدارنده سرصفحه تعریف نمی‌کند. در اسلایدهای عادی از نگهدارنده‌های پانویس، تاریخ/زمان و شماره اسلاید استفاده کنید. نگهدارنده‌های سرصفحه در صفحات یادداشت و جزوه‌ها موجود هستند.

**اگر یک نگهدارنده پانویس، تاریخ/زمان یا شماره اسلاید قابل مشاهده نباشد چه کار کنم؟**

از مدیر سرصفحه/پانویس مربوطه استفاده کنید تا قابلیت نمایش آن را بررسی و در صورت نیاز فعال کنید. به عنوان مثال، متد [isFooterVisible](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) نشان می‌دهد آیا نگهدارنده پانویس وجود دارد یا خیر و [setFooterVisibility](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) قابلیت نمایش آن را تغییر می‌دهد.

**چگونه می‌توانم شماره‌گذاری اسلایدها را از مقداری غیر از 1 آغاز کنم؟**

متد [setFirstSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#setFirstSlideNumber) ارائه را فراخوانی کنید. پس از آن نگهدارنده‌های شماره اسلاید از دنبالهٔ شماره‌گذاری به‌روز شده استفاده می‌کنند.

**وقتی به PDF، تصویر یا HTML صادر می‌شود، سرصفحه و پانویس چه اتفاقی می‌افتند؟**

عناصر قابل مشاهدهٔ سرصفحه و پانویس همراه با بقیه محتوای ارائه در قالب خروجی رندر می‌شوند. ظاهر آن‌ها بستگی به نوع صفحه‌ای دارد که صادر می‌شود و تنظیمات قابل مشاهدهٔ نگهدارنده‌های مربوطه.