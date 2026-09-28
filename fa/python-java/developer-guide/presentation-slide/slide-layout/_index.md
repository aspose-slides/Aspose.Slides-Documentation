---
title: اعمال یا تغییر طرح‌بندی اسلاید در پایتون از طریق جاوا
linktitle: طرح‌بندی اسلاید
type: docs
weight: 60
url: /fa/python-java/slide-layout/
keywords:
- طرح‌بندی اسلاید
- طرح‌بندی محتوا
- متغیر نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- طرح‌بندی استفاده‌نشده
- نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح‌بندی خالی
- محتوا با توضیح
- تصویر با توضیح
- عنوان و متن عمودی
- عنوان عمودی و متن
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "اعمال، ایجاد و تغییر طرح‌بندی‌های اسلاید در Aspose.Slides برای پایتون از طریق جاوا، افزودن متغیرهای نگهدارنده، حذف طرح‌بندی‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **نمای کلی**

یک طرح‌بندی اسلاید موقعیت‌ها و قالب‌بندی متغیرهای نگهدارنده مانند عنوان‌ها، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح‌بندی به اسلایدها ساختار ثابتی می‌دهد در حالی که به هر اسلاید اجازه می‌دهد محتویات خاص خود را داشته باشد.

اکثر طرح‌بندی‌های رایج شامل:

- **Title Slide**: شامل متغیرهای نگهدارنده عنوان و زیرعنوان است.
- **Title and Content**: شامل یک متغیر نگهدارنده عنوان و یک متغیر نگهدارنده محتوای عمومی است.
- **Blank**: حاوی هیچ متغیر نگهدارنده محتوایی نیست و در زمانی مفید است که تمام شکل‌ها به صورت دستی موقعیت‌یابی می‌شوند.

## **درک ارث‌بری طرح‌بندی**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح‌بندی](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/) به یک مستر تعلق دارد و ترتیب خاصی از متغیرهای نگهدارنده را تعریف می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) از یک طرح‌بندی استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی قالب‌بندی و تم را از طرح‌بندی خود به ارث می‌برد و طرح‌بندی از مستر خود به ارث می‌برد. مقداری که مستقیماً بر روی اسلاید عادی تنظیم می‌شود، مقدار ارث‌بری را در همان سطح لغو می‌کند. وقتی یک اسلاید عادی ایجاد می‌شود، اشکال متغیرهای نگهدارنده آن از طرح‌بندی انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده به این متغیرها متعلق به اسلاید عادی است.

متغیرهای نگهدارنده مورد نیاز را قبل از ایجاد اسلایدها به یک طرح‌بندی اضافه کنید. افزودن متغیر نگهدارنده دیگر به یک طرح‌بندی بعداً به‌صورت خودکار شکل متغیر مربوطه را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه متغیرهای نگهدارنده موجود در یک طرح‌بندی می‌تواند تمام اسلایدهایی را که به آن وابسته‌اند به‌روز کند. قبل از ویرایش طرح‌بندی‌ای که در حال استفاده است، اسلایدهای وابسته را بررسی کنید و ارائه حاصل را مرور کنید.
- یک طرح‌بندی که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته آن را به طرح‌بندی دیگری اختصاص دهید یا فقط طرح‌بندی‌های بدون استفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌مراتب، به [اسلاید مستر](/slides/fa/python-java/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای ارث‌بری یا اشکال تزئینی مستر در یک اسلاید یا از طریق یک طرح‌بندی مشترک، به [کنترل نمایش گرافیک‌های مستر](/slides/fa/python-java/slide-master/) نگاه کنید. مثال دو اسلاید استفاده‌کننده از همان مستر را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح‌بندی اسلاید**

از یک نوع طرح‌بندی وقتی استفاده کنید که ارائه تعریف‌های استاندارد طرح‌بندی پاورپوینت را دنبال می‌کند. نام‌های طرح‌بندی قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر پایه نام کمتر قابل اعتماد است مگر آنکه قالب منبع را تحت کنترل داشته باشید.

مثال زیر به دنبال **Title and Content** در اولین مستر می‌گردد. اگر آن طرح‌بندی در دسترس نباشد، به‌صراحت به **Blank** باز می‌گردد. بررسی دوم برای `None` ضروری است چون یک ارائه می‌تواند فقط طرح‌بندی‌های سفارشی داشته باشد. سپس طرح‌بندی انتخاب‌شده از طریق متد [Slide.setLayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setLayoutSlide) به اولین اسلاید عادی اعمال می‌شود.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تغییر طرح‌بندی یک اسلاید اشکال عادی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. اما موقعیت متغیرهای نگهدارنده، قالب‌بندی ارث‌بری و تطابق بین متغیرهای موجود و طرح‌بندی جدید می‌تواند تغییر کند، بنابراین هنگام جابجایی بین طرح‌بندی‌های متفاوت به‌خروجی دقت کنید.

## **افزودن یک اسلاید طرح‌بندی**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح‌بندی موجود را انتخاب می‌کرد؛ یک طرح‌بندی جدید ایجاد نمی‌کرد. برای ایجاد یک طرح‌بندی، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterlayoutslidecollection/#add) را بر روی مجموعه طرح‌بندی‌های مستر هدف صدا بزنید.

مثال زیر همیشه یک طرح‌بندی جدید **Title and Content** به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر پایه آن می‌سازد. نام‌های طرح‌بندی باید درون مجموعه یکتا باشند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

یک طرح‌بندی تنها زمانی اضافه کنید که قالب واقعاً به ساختار قابل استفاده دیگری نیاز داشته باشد. اگر یک طرح‌بندی مناسب پیش از این وجود داشته باشد، به‌جای ایجاد نسخهٔ تکراری، آن را انتخاب و دوباره استفاده کنید.

## **افزودن متغیرهای نگهدارنده به یک اسلاید طرح‌بندی**

متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getPlaceholderManager) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/) برای افزودن اشکال متغیرهای نگهدارنده به یک طرح‌بندی فراهم می‌کند.

| متغیر نگهدارنده PowerPoint | متد |
| --------------------------- | ---- |
| ![محتوا](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![محتوا (عمودی)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![متن](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![متن (عمودی)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![تصویر](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![نمودار](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![جدول](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![رسانه](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![تصویر آنلاین](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

مثال زیر اطمینان می‌یابد که طرح‌بندی **Blank** موجود است، چهار متغیر نگهدارنده را به آن اضافه می‌کند و سپس اسلاید عادی‌ای که از طرح‌بندی اصلاح‌شده استفاده می‌کند را می‌سازد. ترتیب این کار عمدی است: متغیرهای نگهدارنده پیش از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال متغیرهای مربوطه را روی آن اسلاید تولید کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

نتیجه:

![متغیرهای نگهدارنده در اسلاید طرح‌بندی](add_placeholders.png)

{{% alert color="warning" title="هشدار" %}}
تغییر قالب‌بندی ارث‌بری یا هندسهٔ متغیرهای نگهدارندهٔ موجود در طرح‌بندی می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک متغیر نگهدارندهٔ تازه اضافه‌شده به صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح‌بندی را روی یک کپی از ارائه آزمایش کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح‌بندی استفاده نشده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف طرح‌بندی‌هایی که هیچ اسلاید عادی به آن ارجاع نمی‌دهد استفاده کنید. این متد طرح‌بندی‌هایی که هنوز در استفاده هستند را دست‌نخورده می‌گذارد.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

برای حذف یک طرح‌بندی خاص، ابتدا از متد [hasDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#hasDependingSlides) یا [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getDependingSlides) آن استفاده کنید. قبل از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#remove) اسلایدهای وابسته را به طرح‌بندی دیگری اختصاص دهید. تلاش برای حذف یک طرح‌بندی استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک اسلاید طرح‌بندی**

یک طرح‌بندی پاورقی، شمارهٔ اسلاید و متغیرهای نگهدارندهٔ تاریخ/زمان خود را دارد. از متد [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) برای کنترل این متغیرها برای یک طرح‌بندی استفاده کنید. این مورد زمانی مفید است که مثلاً طرح‌بندی‌های محتوا باید پاورقی نشان دهند اما طرح‌بندی‌های عنوان نه.

مثال زیر یک طرح‌بندی را به‌صورت ایمن انتخاب می‌کند و عناصر پاورقی آن را قابل مشاهده می‌سازد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کنترل نمایش پاورقی در یک مستر و طرح‌بندی‌های فرزند آن**

برای اعمال تنظیمات پاورقی سازگار در سرتاسر سلسله‌مراتب مستر، از متد [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getHeaderFooterManager) استفاده کنید. متدهای انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslideheaderfootermanager/) بر روی مستر و اسلایدهای طرح‌بندی وابسته و اسلایدهای عادی عمل می‌کنند؛ آنها تنها یک اسلاید عادی را هدف‌گیری نمی‌کنند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **سوالات متداول**

**تفاوت بین اسلاید مستر و اسلاید طرح‌بندی چیست؟**

اسلاید مستر تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح‌بندی به یک مستر تعلق دارد و یک ترتیب قابل استفادهٔ متغیرهای نگهدارنده را تعریف می‌کند. اسلایدهای عادی از این طرح‌بندی‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح‌بندی را از یک ارائه به ارائه دیگر کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/globallayoutslidecollection/#addClone) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط طرح‌بندی منبع را نیز بررسی کنید.

**وقتی یک طرح‌بندی که در حال استفاده است را تغییر می‌دهم چه اتفاقی می‌افتد؟**

اسلایدهای وابسته تغییرات طرح‌بندی را به‌ارث می‌برند مگر آنکه قالب‌بندی یا اشیای مربوطه را به‌صورت محلی بازنویسی کرده باشند. هندسهٔ متغیرهای نگهدارنده و استایل ارث‌بری می‌تواند به‌ناوبرا بر تعداد زیادی اسلاید تاثیر بگذارد. برای شناسایی اسلایدهای تحت تأثیر، قبل از ویرایش طرح‌بندی از [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getDependingSlides) استفاده کنید.

**اگر یک طرح‌بندی که هنوز در استفاده است را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به طرح‌بندی دیگری منتقل کنید یا برای حذف فقط طرح‌بندی‌های بدون ارجاع از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) بهره بگیرید.