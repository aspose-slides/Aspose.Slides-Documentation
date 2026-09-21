---
title: مدیریت فیلدهای متن در ارائه‌های پاورپوینت در پایتون از طریق جاوا
linktitle: فیلدهای متن
type: docs
weight: 52
url: /fa/python-java/text-fields/
keywords:
- فیلد متن
- متن خودکار
- شماره اسلاید
- تاریخ و زمان
- سرصفحه
- پاصفت
- بخش متن
- پاورپوینت
- پی‌پی‌تی
- پی‌پی‌تی‌اکس
- پایتون
- جاوا
- Aspose.Slides
description: "ایجاد، بازرسی، تغییر و حذف فیلدهای متن در ارائه‌های پاورپوینت با Aspose.Slides برای پایتون از طریق جاوا. حفظ قالب‌بندی و تأیید فایل‌های PPTX و PPT ذخیره‌شده."
---
## **نمای کلی**

یک پاراگراف متنی از بخش‌ها تشکیل شده است. یک [Portion](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/) حاوی متن لغوی است؛ یک بخش فیلد همچنین یک [Field](https://reference.aspose.com/slides/fa/python-java/aspose.slides/field/) دارد که نوع آن مقدار به‌صورت خودکار به‌روز شده‌ای را شناسایی می‌کند، مانند شماره اسلاید یا تاریخ. دو بخش می‌توانند همان حروف را نمایش دهند در حالی که فقط یکی حاوی فیلد است.

از [Portion.getField](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getField) برای تشخیص آن‌ها استفاده کنید: برای متن عادی `None` برمی‌گردد. [Portion.addField](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#addField) یک بخش موجود را به فیلد تبدیل می‌کند. برچسب و مقدار پویا آن را در بخش‌های جداگانه نگه دارید تا تبدیل مقدار منجر به جایگزینی برچسب نشود.

این راهنما فیلدهای داخل متن، قالب‌بندی آن‌ها، و ذخیره‌سازی در PPTX و PPT را پوشش می‌دهد. برای فریم‌ها و پاراگراف‌های متنی، به [Manage Text](/slides/fa/python-java/manage-text/) مراجعه کنید.

## **ایجاد فیلد شماره اسلاید**

مثال کامل زیر یک جعبه متن ایجاد می‌کند که شامل برچسب لغوی `Slide ` به‌همراه یک عدد به‌صورت خودکار به‌روز شده است. قبل از افزودن فیلد، اندازه، وزن و رنگ عدد تنظیم می‌شود، سپس ارائه ذخیره‌شده بازخوانی می‌شود و نوع فیلد، متن و قالب‌بندی آن بررسی می‌شوند. نیازی به فایل ورودی ندارید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

ارائه جدید با شماره اسلاید 1 شروع می‌شود، بنابراین متن `Slide 1` است و هر دو بررسی `True` چاپ می‌کنند. عدد پس از بازخوانی همچنان یک فیلد می‌ماند؛ به‌صورت لغوی `1` نیست. اندیس‌های موجود در تأیید به شکل و بخش‌های ایجاد شده توسط این مثال اشاره دارند.

## **انتخاب نوع فیلد**

[FieldType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/) روش‌های زیر را برای دریافت مقادیر از پیش تعریف‌شده فراهم می‌کند. مقدار مناسب را به [addField](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#addField) پاس دهید.

| متد | هدف |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getSlideNumber) | شماره اسلاید فعلی. |
| [getDateTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime) | تاریخ/زمان در قالب پیش‌فرض برنامه رندر. |
| [getDateTime1](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime9) | قالب‌های تاریخ یا تاریخ/زمان ترکیبی از پیش تعریف‌شده. |
| [getDateTime10](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime13) | قالب‌های زمان از پیش تعریف‌شده، با گزینه‌های ثانیه و ساعت 12 ساعته. |
| [getHeader](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getHeader) | یک فیلد سرصفحه؛ محدودیت‌های جای‌دار و قالب در زیر مشاهده می‌شود. |
| [getFooter](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getFooter) | یک فیلد پاصفت. |

به عنوان مثال، [getDateTime3](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getDateTime3) نمایانگر روز، نام کامل ماه و سال به زبان انگلیسی است. این‌ها قالب‌های فیلد از پیش تعریف‌شده‌اند، نه رشته‌های دلخواه قالب تاریخ پایتون. زبانی که با [setLanguageId](https://reference.aspose.com/slides/fa/python-java/aspose.slides/baseportionformat/#setLanguageId) تنظیم می‌شود و برنامه‌ای که ارائه را پردازش می‌کند می‌توانند بر نتیجه نمایش تأثیر بگذارند.

## **ایجاد فیلد از رشته داخلی**

بارگذاری رشته‌ای [addField](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#addField) یک شناسه فیلد داخلی می‌پذیرد. زمانی که می‌خواهید شناسه‌ای که توسط برنامهٔ دیگری ارائه شده و مقدار پیش‌تعریف‌شده‌ای ندارد حفظ کنید، از آن استفاده کنید. همچنین می‌توانید یک [FieldType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#FieldType) از این شناسه بسازید. [FieldType.getInternalString](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fieldtype/#getInternalString) این شناسه را برای بازرسی نشان می‌دهد.

این مثال یک فیلد مخصوص برنامه با شناسه `custom-report-id` و متن جایگزین `Report-042` ذخیره می‌کند. این شناسه محاسبه‌ای ثبت نمی‌کند: Aspose.Slides شناسه‌های گزارش برای نوع ناشناخته تولید نمی‌کند. برنامه‌ای که این شناسه را می‌داند باید معنای آن را فراهم کرده و مقدارش را به‌روز کند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

پس از این دور سفر PPTX، نوع فیلد `custom-report-id` و متن `Report-042` می‌ماند. عبور یک رشته مثل `yyyy-MM-dd` فقط یک نوع فیلد نامگذاری می‌کند؛ قالب تاریخ سفارشی تنظیم نمی‌کند. برای تاریخ ثابت با قالب دلخواه، از متن عادی استفاده کنید.

## **بازرسی، تغییر و حذف فیلدهای تاریخ/زمان**

یک فیلد موجود را از طریق [Field.setType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/field/#setType) تغییر دهید. قبل از دسترسی به نوع آن، اطمینان حاصل کنید فیلد وجود دارد. برای متوقف کردن به‌روزرسانی‌های خودکار، [Portion.removeField](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#removeField) را صدا بزنید. این کار بخش و متن فعلی آن را حفظ می‌کند در حالی که وابستگی فیلد را حذف می‌نماید. اگر به مقدار ثابت مشخصی نیاز دارید، پس از حذف فیلد آن متن را اختصاص دهید.

برای تنظیم API مرتبط با پردازش فیلد تاریخ/زمان، به [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#setCurrentDateTime) مراجعه کنید. مثال زیر هنگام تبدیل فیلد به متن عادي، یک تاریخ تأیید صریح استفاده می‌کند.

فایل [sample.pptx](sample.pptx) را دانلود کنید و در پوشهٔ کاری قرار دهید. این فایل شامل دو شکل متن نام‌گذاری‌شده `UpdatedAt` و `ApprovedDate` است که هر کدام فیلد تاریخ/زمان دارند، به‌علاوه برچسب‌های متن عادی. مثال زیر شکل‌های متن سطح بالای اسلایدهای معمولی را پیمایش می‌کند. فیلدهای تاریخ/زمان را به قالب تاریخ بلند تبدیل کرده و ایتالیک می‌کند، در حالی که قالب‌بندی دیگرشان حفظ می‌شود. فقط فیلدهای موجود در `ApprovedDate` به متن ثابت تبدیل می‌شوند.

این نمونه شناسه‌های داخلی از پیش‌ساختهٔ `datetime` تا `datetime13` را تشخیص می‌دهد. گروه‌ها، جدول‌ها، یادداشت‌ها، طرح‌ها و الگوها نیاز به پیمایش کانتینرهای متنی خود دارند و خارج از دامنهٔ این مثال هستند.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # از نام‌های ماه به زبان انگلیسی به‌صورت مستقل از تنظیمات محلی سیستم استفاده کنید.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

پس از بازخوانی، `UpdatedAt` نوع `datetime3` را دارد و پویا می‌ماند. `ApprovedDate` فیلدی ندارد و شامل `05 April 2030` است. هر دو بخش تاریخ ایتالیک هستند و اندازه قلم، حالت بولد و رنگ اصلی آن‌ها دست‌نخورده باقی می‌ماند. برچسب‌های متن عادی بدون تغییر باقی می‌مانند. تأیید اولین بخش از دو شکل شناخته‌شده در نمونهٔ ارائه‌شده را می‌خواند.

## **حفظ قالب‌بندی متن**

هنگام افزودن فیلد، تغییر نوع آن یا حذف آن، با بخش موجود کار کنید. این عملیات قالب‌بندی آن بخش را حفظ می‌کند. برای تغییر فقط خواص لازم، از [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/portion/#getPortionFormat) استفاده کنید، همان‌طور که مثال‌ها برای رنگ یا ایتالیک انجام می‌دهند.

از بازسازی کامل یک فریم متن فقط برای به‌روزرسانی یک فیلد خودداری کنید: این کار می‌تواند مرزهای بخش‌های اصلی و قالب‌بندی‌های مجزای آن‌ها را از دست بدهد. همچنین قالب‌بندی صریح را از قالب‌بندی ارث‌بری شده از پاراگراف، طرح یا تم متمایز کنید. برای گزینه‌های گسترده‌تر قالب‌بندی به [Text Formatting](/slides/fa/python-java/text-formatting/) مراجعه کنید.

## **فیلدها و جای‌دارهای سرصفحه/پاصفت**

یک فیلد بخشی از یک بخش متنی است. یک جای‌دار یک شکل با نقش ارائه، مانند پاصفت یا شماره اسلاید، است. افزودن فیلد به یک جعبه متن عادی، آن شکل را به جای‌دار تبدیل نمی‌کند.

مدیران سرصفحه/پاصفت متن جای‌دار و قابلیت مشاهده را در اسلایدها، طرح‌ها و الگوها، شامل انتشار به اسلایدهای وابسته، کنترل می‌کنند. بنابراین فیلد عددی در یک جعبه متن سفارشی حتی وقتی از جای‌دار شماره اسلاید استفاده نمی‌کنید می‌تواند مفید باشد. برعکس، تغییر قابلیت مشاهده جای‌دار فیلدی را از جعبه متن نامرتبط حذف نمی‌کند.

انواع سرصفحه و پاصفت پیش‌تعریف‌شده، جای‌دارهای مربوطه را ایجاد نمی‌کنند و محتوا را ارائه نمی‌دهند. به‌ویژه، یک اسلاید پاورپوینت معمولی جای‌دار سرصفحه ندارد؛ سرصفحه‌ها به صفحات یادداشت و برگه‌های توزیع تعلق دارند. فرض نکنید فیلد سرصفحه یا پاصفت در یک شکل دلخواه به‌طور خودکار متن تنظیم‌شده توسط مدیر جای‌دار را دریافت می‌کند. برای این روند کاری، به [Presentation Headers and Footers](/slides/fa/python-java/presentation-header-and-footer/) مراجعه کنید.

## **محدودیت‌های PPTX و PPT**

پس از ذخیره و بازخوانی، هم نوع فیلد و هم متن حاصل آن را بررسی کنید. حفظ یک شناسه ثابت نشان‌دهنده این نیست که برنامه می‌تواند مقدار آن را محاسبه یا نمایش دهد.

| قالب | رفتار فیلد و محدودیت‌ها |
|---|---|
| PPTX | شناسه‌های داخلی فیلد را همراه با متن فیلد ذخیره می‌کند. در بررسی‌های دور سفر، انواع پیش‌تعریف‌شده و شناسه سفارشی استفاده‌شده بالا پس از ذخیره و بازخوانی باقی ماندند. نوع سفارشی ناشناخته متن جایگزین خود را حفظ کرد؛ منطق محاسبه خودکار دریافت نکرد. برنامهٔ دیگری ممکن است شناسه‌های پشتیبانی‌نشده را به‌طور متفاوتی扱د. |
| PPT | از نمایندگی‌های فیلدهای قدیمی استفاده می‌کند و سازگاری محدودتری دارد. در بررسی‌های دور سفر، فیلدهای شماره اسلاید و تاریخ/زمان پیش‌تعریف‌شده پس از ذخیره و بازخوانی باقی ماندند. یک فیلد سفارشی در یک جعبه متن اسلاید عادی پس از بازخوانی شناسه خود را داشت اما متن آن `*` بود؛ فیلد سرصفحه در همان زمینه نیز `*` تولید کرد. به‌طور قابل اعتماد به فیلدهای سفارشی یا زمینه‌های فیلد پشتیبانی‌نشده برای حفظ متن قابل مشاهده تکیه نکنید. |

برای خروجی قابل حمل و ثابت، فیلدهای پشتیبانی‌نشده را به متن عادی تبدیل کنید و مقدار موردنظر را به‌صورت صریح قبل از ذخیره‌سازی اختصاص دهید. این کار متن انتخاب‌شده را حفظ می‌کند اما به‌طور عمدی به‌روزرسانی‌های خودکار را متوقف می‌کند. همچنین برنامه هدف را آزمایش کنید وقتی که محاسبه مجدد فیلد خود برنامه جزئی از جریان کاری شماست.

## **سوالات متداول**

**چگونه می‌توانم تشخیص دهم که شماره یا تاریخ نمایش‌داده‌شده یک فیلد است؟**

[Portion.getField] را بررسی کنید. مقداری غیر از `None` یک فیلد را شناسایی می‌کند؛ فقط متن نمایش‌داده‌شده نمی‌تواند این را بگوید.

**آیا حذف فیلد متن یا قالب‌بندی آن را حذف می‌کند؟**

خیر. [removeField] بخش موجود را به متن عادی تبدیل می‌کند. اگر به مقدار ثابت خاص یا مقدار پیش‌فرض نیاز دارید، پس از حذف فیلد مقدار صریحی اختصاص دهید.

**آیا یک رشته داخلی می‌تواند قالب تاریخ یا فرمول جدیدی تعریف کند؟**

خیر. این رشته یک نوع فیلد را شناسایی می‌کند. یک شناسه ناشناخته ارزیابی‌کننده یا الگوی قالب تاریخ پایتون ارائه نمی‌دهد. از یک نوع پیش‌تعریف‌شده پشتیبانی‌شده استفاده کنید یا مقدار را به‌صورت متن عادی قالب‌بندی کنید.

**چرا پس از ذخیره‌سازی یک ارائه دوباره آن را بررسی می‌کنیم؟**

شناسه‌های فیلد، متن محاسبه‌شده و قالب‌بندی موارد جداگانه‌ای برای بررسی هستند. تبدیل قالب می‌تواند نتیجهٔ قابل مشاهده را تغییر دهد حتی اگر شناسهٔ فیلد همچنان موجود باشد.