---
title: اعمال یا تغییر طرح اسلاید در Python via Java
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/python-java/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- فیلد نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت مشاهده پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سربرگ بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با کپشن
- تصویر با کپشن
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای Python via Java، افزودن فیلدهای نگهدارنده، حذف طرح‌های استفاده‌نشده و کنترل قابلیت مشاهده پاورقی."
---
## **نمای کلی**

یک طرح اسلاید موقعیت‌ها و قالب‌بندی فیلدهای نگهدارنده‌ای مانند عنوان‌ها، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختار یکسانی می‌دهد در حالی که به هر اسلاید اجازه می‌دهد محتوای خاص خود را داشته باشد.

متداول‌ترین طرح‌ها شامل:

- **Title Slide**: شامل فیلدهای نگهدارندهٔ عنوان و زیرعنوان است.
- **Title and Content**: شامل یک فیلد نگهدارندهٔ عنوان و یک فیلد نگهدارندهٔ محتوای عمومی است.
- **Blank**: هیچ فیلد نگهدارنده‌ای ندارد و زمانی مفید است که همهٔ اشکال به‌صورت دستی موقعیت‌یابی شوند.

## **درک وراثت طرح**

یک ارائه دارای سه سطح مرتبط است:

1. یک [master slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [layout slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/) متعلق به یک master است و ترتیب خاصی از فیلدهای نگهدارنده را تعریف می‌کند.
1. یک [normal slide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/) از یک layout استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی قالب و تم را از layout خود به ارث می‌برد و layout نیز از master خود ارث می‌برد. مقدار تنظیم‌شده مستقیم بر روی اسلاید عادی، مقدار ارث‌برده‌شده را در همان سطح بازنویسی می‌کند. وقتی یک اسلاید عادی ساخته می‌شود، اشکال فیلدهای نگهدارنده از layout انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده به این فیلدها به اسلاید عادی تعلق دارد.

قبل از ایجاد اسلایدها، فیلدهای نگهدارنده مورد نیاز را به یک layout اضافه کنید. افزودن فیلد نگهدارندهٔ دیگر به یک layout پس از آن، به‌صورت خودکار فیلد نگهدارندهٔ متناظر را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌برده یا هندسهٔ فیلدهای نگهدارنده موجود در یک layout می‌تواند تمام اسلایدهای وابسته را به‌روز کند. قبل از ویرایش.layout که در حال استفاده است، اسلایدهای وابسته را بررسی و ارائهٔ حاصل را بازبینی کنید.
- یک layout که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته را به layout دیگری اختصاص دهید یا فقط layoutهای استفاده‌نشده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالای این سلسله‌مراتبی، به [Slide Master](/slides/fa/python-java/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک Layout اسلاید**

زمانی که ارائه از تعریف‌های استاندارد PowerPoint پیروی می‌کند، از یک نوع layout استفاده کنید. نام‌های layout قابل ویرایش توسط کاربر هستند و می‌توانند локалیزه شوند، بنابراین انتخاب بر مبنای نام کمتر قابل اطمینان است مگر این که قالب منبع را کنترل کنید.

مثال زیر به‌دنبال **Title and Content** در اولین master می‌گردد. اگر آن layout در دسترس نباشد، عمداً به **Blank** بازمی‌گردد. بررسی دوم برای `None` ضروری است زیرا یک ارائه می‌تواند فقط layoutهای سفارشی داشته باشد. سپس layout انتخاب‌شده از طریق متد [Slide.setLayoutSlide](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slide/#setLayoutSlide) به اولین اسلاید عادی اعمال می‌شود.

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

تغییر layout یک اسلاید اشکال معمولی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. اما موقعیت فیلدهای نگهدارنده، قالب‌بندی ارث‌برده و نگاشت بین فیلدهای موجود و layout جدید ممکن است تغییر کند، بنابراین هنگام جابجایی بین layoutهای متفاوت، خروجی را بررسی کنید.

## **افزودن یک Layout اسلاید**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک layout موجود را انتخاب می‌کرد؛ آن را ایجاد نمی‌کرد. برای ایجاد یک layout، متد [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterlayoutslidecollection/#add) را بر روی مجموعهٔ layoutهای master هدف فراخوانی کنید.

مثال زیر همیشه یک layout جدید **Title and Content** به نام `Report Title and Content` اضافه می‌کند، سپس اسلاید عادی مبتنی بر آن را می‌سازد. نام‌های layout باید درون مجموعه یکتا باشند.

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

یک layout فقط زمانی اضافه شود که قالب واقعاً به یک ساختار قابل استفاده مجدد دیگر نیاز داشته باشد. اگر یک layout مناسب قبلاً وجود داشته باشد، به‌جای ایجاد تکثیر، آن را انتخاب و مجدداً استفاده کنید.

## **افزودن فیلدهای نگهدارنده به یک Layout اسلاید**

متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getPlaceholderManager) یک [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/) را برای افزودن اشکال فیلد نگهدارنده به یک layout فراهم می‌کند.

| فیلد نگهدارندهٔ PowerPoint | متد [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/) |
| --------------------------- | -------------------------------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

مثال زیر بررسی می‌کند که آیا layout **Blank** موجود است، چهار فیلد نگهدارنده به آن اضافه می‌کند و سپس اسلاید عادی‌ای که از layout اصلاح‌شده استفاده می‌کند را می‌سازد. ترتیب به‌صورت عمدی است: فیلدهای نگهدارنده قبل از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال فیلدهای متناظر را بر روی آن اسلاید تولید کند.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌برده یا هندسهٔ فیلدهای نگهدارندهٔ layout می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. فیلد نگهدارندهٔ جدید به‌صورت خودکار به اسلایدهای عادی موجود اضافه نمی‌شود. تغییرات layout را روی یک نسخهٔ کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف Layoutهای استفاده‌نشده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف layoutهایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد استفاده کنید. این متد layoutهایی را که هنوز استفاده می‌شوند، دست نخورده می‌گذارد.

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

برای حذف یک layout خاص، ابتدا از متد [hasDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#hasDependingSlides) یا [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getDependingSlides) آن استفاده کنید. قبل از فراخوانی [LayoutSlide.remove](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#remove) اسلایدهای وابسته را مجدداً اختصاص دهید. تلاش برای حذف یک layout استفاده‌شده منجر به ایجاد [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک Layout اسلاید**

یک layout فیلدهای نگهدارندهٔ پاورقی، شماره اسلاید و تاریخ‑زمان خود را دارد. برای کنترل این فیلدها در یک layout از متد [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) استفاده کنید. این برای مثال وقتی محتوا باید پاورقی نشان دهد ولی layoutهای عنوان نه، مفید است.

مثال زیر به‌صورت ایمن یک layout را انتخاب می‌کند و عناصر پاورقی آن را قابل مشاهده می‌سازد:

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

## **کنترل نمایش پاورقی در یک Master و Layoutهای فرزند آن**

برای اعمال تنظیمات یکسان پاورقی در سراسر سلسله‌مراتبی master، از متد [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslide/#getHeaderFooterManager) استفاده کنید. روش‌های انتشار [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/python-java/aspose.slides/masterslideheaderfootermanager/) بر روی master و layoutهای وابسته و اسلایدهای عادی عمل می‌کند؛ نه فقط یک اسلاید عادی.

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

**تفاوت بین Master Slide و Layout Slide چیست؟**

یک master slide تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. یک layout slide متعلق به یک master است و یک ترتیب قابل استفاده مجدد از فیلدهای نگهدارنده را تعریف می‌کند. اسلایدهای عادی از این layoutها استفاده می‌کنند و محتوای خاص هر اسلاید را ذخیره می‌نمایند.

**آیا می‌توانم یک Layout Slide را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با متد [addClone](https://reference.aspose.com/slides/fa/python-java/aspose.slides/globallayoutslidecollection/#addClone) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، قلم‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط layout منبع را نیز بررسی کنید.

**اگر یک Layout که در حال استفاده است را تغییر دهم، چه اتفاقی می‌افتد؟**

اسلایدهای وابسته تغییرات layout را به‌ارث می‌برند مگر اینکه قالب‌بندی یا اشیای مؤثر را به‌صورت محلی بازنویسی کنند. هندسهٔ فیلدهای نگهدارنده و سبک‌های ارث‌برده ممکن است به‌طور همزمان در بسیاری از اسلایدها تغییر کند. قبل از ویرایش layout از [getDependingSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/layoutslide/#getDependingSlides) برای شناسایی اسلایدهای متاثر استفاده کنید.

**اگر یک Layout که هنوز در استفاده است را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را مجدداً اختصاص دهید یا از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) برای حذف تنها layoutهای بدون ارجاع استفاده کنید.