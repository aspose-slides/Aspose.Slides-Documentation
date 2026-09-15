---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار اکسل
- شیء OLE
- جاسازی نمودار
- PowerPoint
- OpenDocument
- ارائه
- Python
- Java
- Aspose.Slides
description: "رفع مشکل تغییر اندازه غیرمنتظره نمودار در PPTX هنگام استفاده از اشیای OLE اکسل جاسازی‌شده با Aspose.Slides برای Python از طریق Java. دو روش همراه با کد برای حفظ سازگاری اندازه‌ها را بیاموزید."
---
## **پیش‌زمینه**

مشاهده شده است که نمودارهای Excel که به‌عنوان اشیای OLE در یک ارائه PowerPoint از طریق اجزای Aspose جاسازی می‌شوند، پس از اولین فعال‌سازی به مقیاس نامشخصی تغییر اندازه می‌یابند. این رفتار باعث تفاوت بصری قابل‌توجهی در ارائه بین حالت‌های پیش و پس از فعال‌سازی نمودار می‌شود. تیم Aspose به‌صورت جزئیات به بررسی این مشکل پرداخته و راه‌حلی پیدا کرده است. این مقاله علل مشکل و راه‌حل مربوطه را توصیف می‌کند.

در [مقاله قبلی](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما توضیح دادیم که چگونه یک نمودار Excel را با Aspose.Cells برای Python از طریق Java ایجاد کرده و آن را به‌عنوان شیء OLE در یک ارائه PowerPoint با استفاده از Aspose.Slides برای Python از طریق Java جاسازی کنیم. برای رفع [مشکل پیش‌نمایش شیء](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به قاب شیء OLE آن اختصاص دادیم. در ارائه خروجی، وقتی دو بار کلیک کنید روی قاب شیء OLE که تصویر نمودار را نمایش می‌دهد، نمودار Excel فعال می‌شود. کاربران نهایی می‌توانند تغییرات دلخواه خود را در کار‑پوشه Excel زیرین اعمال کنند و سپس با کلیک خارج از کار‑پوشه فعال شده به اسلاید مربوطه بازگردند. اندازهٔ قاب شیء OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و ضریب تغییر اندازه بسته به اندازه‌های اولیهٔ هر دو قاب شیء OLE و کار‑پوشه Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

زیرا کار‑پوشه Excel اندازهٔ پنجرهٔ خود را دارد، سعی می‌کند هنگام اولین فعال‌سازی اندازهٔ اصلی خود را حفظ کند. اما قاب شیء OLE اندازهٔ خود را دارد. بر اساس گفته مایکروسافت، وقتی کار‑پوشه Excel فعال می‌شود، Excel و PowerPoint اندازه را مورد توافق قرار می‌دهند و نسبت‌های صحیح را به‌عنوان بخشی از فرآیند جاسازی نگه می‌دارند. با توجه به اختلافات بین اندازهٔ پنجرهٔ Excel و اندازه یا موقعیت قاب شیء OLE، تغییر اندازه رخ می‌دهد.

## **راه‌حل عملی**

دو سناریوی ممکن برای ایجاد ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Python از طریق Java وجود دارد.

**سناریو 1:** ایجاد ارائه بر پایه یک الگوی موجود.

**سناریو 2:** ایجاد ارائه از صفر.

راه‌حلی که در اینجا ارائه می‌دهیم برای هر دو سناریو کاربرد دارد. پایهٔ تمام روش‌های حل مسئله یکسان است: **اندازهٔ پنجرهٔ شیء OLE جاسازی‌شده باید با قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد**. در ادامه دو رویکرد برای این راه‌حل را بررسی می‌کنیم.

## **رویکرد اول**

در این رویکرد، نحوه تنظیم اندازهٔ پنجرهٔ کار‑پوشه Excel جاسازی‌شده را طوری که با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد، یاد می‌گیریم.

**سناریو 1**

فرض کنید قالبی تعریف کرده‌ایم و می‌خواهیم ارائه‌هایی بر پایهٔ آن ایجاد کنیم. فرض کنید در قالب یک شکل در ایندکس 2 وجود دارد که می‌خواهیم یک قاب OLE حاوی یک کار‑پوشه Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب شیء OLE از پیش تعریف شده است—که با اندازهٔ شکل در ایندکس 2 قالب مطابقت دارد. تنها کاری که باید انجام دهیم این است که اندازهٔ پنجرهٔ کار‑پوشه را برابر با اندازهٔ آن شکل تنظیم کنیم. قطعه کد زیر این منظور را برآورده می‌کند:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# بارگذاری کتاب‌کار Excel حاوی نمودار.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # تنظیم اندازهٔ پنجرهٔ کتاب‌کار بر حسب اینچ (PowerPoint هر اینچ را ۷۲ پوینت می‌شمارد).
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # ذخیره کتاب‌کار در یک جریان حافظه.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # ایجاد یک قاب شیء OLE با داده‌های Excel جاسازی‌شده.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**سناریو 2**

فرض کنید می‌خواهیم یک ارائه از صفر ایجاد کنیم و یک قاب شیء OLE با هر اندازه‌ای که حاوی یک کار‑پوشه Excel جاسازی‌شده باشد، اضافه کنیم. در قطعه کد زیر، یک قاب شیء OLE با ارتفاع ۴ اینچ و عرض ۹٫۵ اینچ در موقعیت x = ۰٫۵ اینچ و y = ۱ اینچ روی اسلاید ایجاد می‌کنیم. سپس پنجرهٔ کار‑پوشه Excel را به همان اندازه تنظیم می‌کنیم—ارتفاع ۴ اینچ و عرض ۹٫۵ اینچ.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# بارگذاری کتاب‌کار Excel که شامل نمودار است.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 اینچ (4 * 72).
    desired_width = 684  # 9.5 اینچ (9.5 * 72).

    # تعریف اندازهٔ نمودار با یک پنجره.
    chart.setSizeWithWindow(True)

    # تنظیم اندازهٔ پنجرهٔ کتاب‌کار بر حسب اینچ (PowerPoint هر اینچ را ۷۲ پوینت می‌شمارد).
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # ذخیره کتاب‌کار در یک جریان حافظه.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # ایجاد یک قاب شیء OLE با داده‌های Excel جاسازی‌شده.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **رویکرد دوم**

در این رویکرد، نحوه تنظیم اندازهٔ نمودار در کار‑پوشه Excel جاسازی‌شده را طوری که با اندازهٔ قاب شیء OLE در اسلاید PowerPoint مطابقت داشته باشد، یاد می‌گیریم. این روش زمانی مفید است که اندازهٔ نمودار از پیش شناخته شده باشد و هرگز تغییر نکند.

**سناریو 1**

فرض کنید قالبی تعریف کرده‌ایم و می‌خواهیم ارائه‌هایی بر پایهٔ آن ایجاد کنیم. فرض کنید در قالب یک شکل در ایندکس ۲ وجود دارد که قصد داریم یک قاب OLE حاوی یک کار‑پوشه Excel جاسازی‌شده در آن قرار دهیم. در این سناریو، اندازهٔ قاب OLE از پیش تعریف شده است—که با اندازهٔ شکل در ایندکس ۲ قالب مطابقت دارد. تنها کاری که باید انجام دهیم این است که اندازهٔ نمودار را در کار‑پوشه برابر با اندازهٔ آن شکل تنظیم کنیم. قطعه کد زیر این منظور را برآورده می‌کند:

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# بارگذاری کتاب‌کار Excel که شامل نمودار است.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # تعریف اندازهٔ نمودار بدون پنجره.
    chart.setSizeWithWindow(False)

    # تنظیم اندازهٔ نمودار بر حسب پیکسل (Excel هر اینچ را ۹۶ پیکسل در نظر می‌گیرد).
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # تعریف اندازهٔ چاپ نمودار.
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # ذخیره کتاب‌کار در یک جریان حافظه.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # ایجاد یک قاب شیء OLE با داده‌های Excel جاسازی‌شده.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**سناریو 2**:

فرض کنید می‌خواهیم یک ارائه از صفر ایجاد کنیم و یک قاب شیء OLE با هر اندازه‌ای که حاوی یک کار‑پوشه Excel جاسازی‌شده باشد، اضافه کنیم. در قطعه کد زیر، یک قاب شیء OLE با ارتفاع ۴ اینچ و عرض ۹٫۵ اینچ در موقعیت x = ۰٫۵ اینچ و y = ۱ اینچ روی اسلاید ایجاد می‌کنیم. همچنین اندازهٔ نمودار مربوطه را به همان ابعاد تنظیم می‌کنیم: ارتفاع ۴ اینچ و عرض ۹٫۵ اینچ.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# بارگذاری کتاب‌کار Excel که شامل نمودار است.
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 اینچ (4 * 72).
    desired_width = 684  # 9.5 اینچ (9.5 * 72).

    # تعریف اندازهٔ نمودار بدون پنجره.
    chart.setSizeWithWindow(False)

    # تنظیم اندازهٔ نمودار بر حسب پیکسل (Excel هر اینچ را 96 پیکسل می‌گیرد).
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # ذخیره کتاب‌کار در یک جریان حافظه.
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # ایجاد یک قاب شیء OLE با داده‌های Excel جاسازی‌شده.
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **نتیجه‌گیری**

دو رویکرد برای حل مشکل تغییر اندازهٔ نمودار وجود دارد. انتخاب رویکرد بستگی به نیازها و مورد استفاده دارد. هر دو رویکرد به‌همین شکل عمل می‌کنند، چه ارائه‌ها از یک قالب ایجاد شوند و چه از صفر ساخته شوند. همچنین، در این راه‌حل هیچ محدودیتی برای اندازهٔ قاب شیء OLE وجود ندارد.

## **سوالات متداول**

**چرا نمودار Excel جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این اتفاق به این دلیل رخ می‌دهد که Excel سعی می‌کند هنگام اولین فعال‌سازی، اندازهٔ اصلی پنجرهٔ خود را بازگرداند، در حالی که قاب شیء OLE در PowerPoint ابعاد خود را دارد. PowerPoint و Excel برای حفظ نسبت تصویر، اندازه را مورد توافق قرار می‌دهند که می‌تواند باعث تغییر اندازه شود.

**آیا می‌توان این مشکل تغییر اندازه را به‌طور کامل جلوگیری کرد؟**

بله. با تطبیق اندازهٔ پنجرهٔ کار‑پوشه Excel یا اندازهٔ نمودار با اندازهٔ قاب شیء OLE قبل از جاسازی، می‌توانید اندازهٔ نمودارها را ثابت نگه دارید.

**کدام رویکرد را باید انتخاب کنم، تنظیم اندازهٔ پنجرهٔ کار‑پوشه یا تنظیم اندازهٔ نمودار؟**

از **رویکرد 1 (اندازهٔ پنجره)** استفاده کنید اگر می‌خواهید نسبت تصویر کار‑پوشه را حفظ کنید و احتمالاً بعداً امکان تغییر اندازه را داشته باشید.  
از **رویکرد 2 (اندازهٔ نمودار)** استفاده کنید اگر ابعاد نمودار ثابت هستند و پس از جاسازی تغییر نمی‌کنند.

**آیا این روش‌ها با هر دو نوع ارائه مبتنی بر قالب و ارائه‌های جدید کار می‌کنند؟**

بله. هر دو رویکرد به‌صورت مشابه برای ارائه‌های ساخته‌شده از قالب‌ها و از ابتدا کار می‌کنند.

**آیا محدودیتی برای اندازهٔ قاب شیء OLE وجود دارد؟**

خیر. می‌توانید قاب OLE را به هر اندازه‌ای تنظیم کنید به شرطی که به‌درستی با اندازهٔ کار‑پوشه یا نمودار مقیاس‌بندی شود.

**آیا می‌توانم از این روش‌ها با نمودارهای ساخته‌شده در برنامه‌های صفحه‌گسترده دیگر استفاده کنم؟**

مثال‌ها برای نمودارهای Excel ایجاد شده با Aspose.Cells طراحی شده‌اند، اما اصول برای برنامه‌های صفحه‌گسترده دیگر که با OLE سازگارند و گزینه‌های مشابهی برای تنظیم اندازه دارند، نیز اعمال می‌شود.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جاسازی آن‌ها به‌عنوان اشیای OLE در ارائه‌ها](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)