---
title: "مدیریت کتاب‌های کاری نمودار در ارائه‌ها با استفاده از پایتون از طریق جاوا"
linktitle: "کتاب کار نمودار"
type: docs
weight: 70
url: /fa/python-java/chart-workbook/
keywords:
- "کتاب کار نمودار"
- "داده‌های نمودار"
- "سلول کتاب کار"
- "برچسب داده"
- "ورق کار"
- "منبع داده"
- "کتاب کار خارجی"
- "داده خارجی"
- "کش نمودار"
- "بازیابی کتاب کار"
- "PowerPoint"
- "ارائه"
- "پایتون"
- "جاوا"
- "Aspose.Slides"
description: "Aspose.Slides برای پایتون از طریق جاوا را کشف کنید: به راحتی کتاب‌های کاری نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با کتاب‌های کاری نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب کاری خواند و نوشت، از سلول‌های کتاب کاری به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های ورق‌های کار دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌های کاری خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب کاری خارجی ایجاد و اختصاص داده شود، مسیر کتاب کاری خارجی مرتبط با یک نمودار بازیابی شود و داده‌های نمودار زمانی که کتاب کاری در دسترس باشد، ویرایش شود.

برای سلول‌های کتاب کاری که داده‌های گم‌شده را نشان می‌دهند، به [Control the Display of Empty Cells](/slides/fa/python-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسه حالت‌های نمایش در نمودار خطی را ببینید.

## **خواندن و نوشتن داده‌های نمودار از کتاب کاری**
Aspose.Slides روش‌های [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#writeWorkbookStream) را ارائه می‌دهد که به شما امکان می‌دهد کتاب‌های کاری داده‌های نمودار (حاوی داده‌های ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **نکته** این است که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد پایتون یک عملیات نمونه را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب کاری**

هنگامی که یک کتاب کاری جاسازی‌شده را با نسخه‌ای اصلاح‌شده جایگزین می‌کنید، نمودار سری‌ها و مجموعه‌های دسته‌بندی اصلی خود را حفظ می‌کند. این ناهماهنگی می‌تواند باعث شود متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) یک `ArgumentOutOfRangeException` (پارامتر: index) پرتاب کند. برای جلوگیری از این استثناء، قبل از نوشتن کتاب کاری به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را **پیش از** نوشتن پاک کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# پس از تغییر کتاب‌کار (مثلاً با استفاده از Aspose.Cells) کتاب‌کار را بخوانید.
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # پاک‌سازی ارجاعات داده موجود.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

پاک‌سازی مجموعه‌ها تضمین می‌کند ساختار داده‌های نمودار با کتاب کاری جدید هم‌راستا باشد و اجازه می‌دهد [validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) بدون خطا اجرا شود.

## **تنظیم یک سلول کتاب کاری به‌عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار حبابی با مقداری داده اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب کاری را به‌عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد پایتون نشان می‌دهد چگونه یک سلول کتاب کاری را به‌عنوان برچسب داده نمودار تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مدیریت ورق‌های کار**

این کد پایتون یک عملیاتی را نشان می‌دهد که در آن متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getWorksheets) برای دسترسی به مجموعه ورق‌های کار استفاده می‌شود:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **مشخص کردن نوع منبع داده**

این کد پایتون نشان می‌دهد چگونه برای یک منبع داده نوعی را مشخص کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تشخیص قالب‌های کتاب کاری جاسازی‌شده پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب کاری باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) بر روی [ChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/workbooktype/) برای شناسایی قالب‌های پشتیبانی‌نشده استفاده کرده و آن نمودارها را نادیده بگیرید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # کتاب کاری جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue
        # داده‌های کتاب کاری نمودار را در اینجا بخوانید یا اصلاح کنید.
finally:
    presentation.dispose()
```

## **کتاب کاری خارجی**

Aspose.Slides از استفاده از کتاب‌های کاری خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب کاری خارجی**

با استفاده از متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب کاری خارجی را از ابتدا ایجاد کنید یا یک کتاب کاری داخلی را خارجی کنید.

این کد پایتون فرآیند ایجاد کتاب کاری خارجی را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **تنظیم یک کتاب کاری خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب کاری خارجی را به‌عنوان منبع داده به یک نمودار اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر به کتاب کاری خارجی (در صورت جابجا شدن آن) نیز استفاده شود.

در حالی که نمی‌توانید داده‌های کتاب‌های کاری ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌های کاری به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب کاری خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد پایتون نشان می‌دهد چگونه یک کتاب کاری خارجی تنظیم کنید:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

پارامتر دوم (`bool`) متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای مشخص کردن اینکه آیا یک کتاب کاری اکسل بارگذاری شود یا خیر، استفاده می‌شود.

* وقتی مقدار آن `False` باشد، فقط مسیر کتاب کاری به‌روزرسانی می‌شود—داده‌های نمودار از کتاب کاری هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی که کتاب کاری هدف وجود ندارد یا در دسترس نیست استفاده کنید.  
* وقتی مقدار آن `True` باشد، داده‌های نمودار از کتاب کاری هدف به‌روزرسانی می‌شوند.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **دریافت مسیر کتاب کاری منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء برای شکل نمودار بسازید.  
1. یک شیء برای منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatasourcetype/)) که نمایانگر منبع داده نمودار است، ایجاد کنید.  
1. شرط مربوطه را بر اساس اینکه نوع منبع همان نوع منبع داده کتاب کاری خارجی باشد، مشخص کنید.

این کد پایتون این عملیات را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌های کاری خارجی را همانند تغییر محتویات کتاب‌های کاری داخلی ویرایش کنید. وقتی کتاب کاری خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این کد پایتون پیاده‌سازی فرآیند توضیح داده شده را نشان می‌دهد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **بازیابی کتاب کاری از کش نمودار**

اگر یک نمودار از کتاب کاری خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب کاری نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `True` فراخوانی کنید.

مثال پایتون زیر یک ارائه را که نمودار آن به یک کتاب کاری خارجی در دسترس نیست ارجاع می‌دهد، باز می‌کند و داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # خواندن یا اصلاح داده‌های کتاب‌کار بازیابی‌شده در اینجا.
finally:
    presentation.dispose()
```

اگر کتاب کاری خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شده نمودار به‌عنوان یک راه‌حل قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است تغییرات اعمال‌شده به کتاب کاری خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سؤال‌های متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب کاری خارجی یا جاسازی‌شده لینک دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) و یک [path to an external workbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب کاری خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌های کاری خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابل‌حمل بودن پروژه مفید است؛ هرچند، توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌های کاری که روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌های کاری می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌های کاری راه دور از Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توان از آن‌ها به‌عنوان منبع استفاده کرد.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییری نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کار کنم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش از استفاده محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/python-java/)) تهیه کنید و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب کاری خارجی اشاره کنند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.