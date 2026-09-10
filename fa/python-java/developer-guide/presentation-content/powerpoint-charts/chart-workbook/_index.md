---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از Python از طریق Java
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/python-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- ورک‌شیت
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- حافظه‌پنهان نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides برای Python از طریق Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را ساده‌سازی کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورک‌شیت دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوندخورده به یک نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌آورد که به شما امکان می‌دهند کتاب‌کارهای داده نمودار (حاوی داده‌های نمودار ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **Note** اینکه داده‌های نمودار باید به همان شکلی سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

وقتی یک کتاب‌کار جاسازی‌شده را با یک نسخهٔ تغییر یافته جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌بندی‌های اصلی خود را نگه می‌دارد. این ناسازگاری می‌تواند باعث شود [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) یک `ArgumentOutOfRangeException` (پارامتر: index) را پرتاب کند. برای جلوگیری از این استثناء، **before** پاک کنید سری‌ها و دسته‌بندی‌های موجود را قبل از نوشتن کتاب‌کار به‌روز شده به نمودار.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# پس از ویرایش کتاب‌کار (به‌عنوان مثال با استفاده از Aspose.Cells) آن را بخوانید.
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # مراجع داده‌های موجود را پاک کنید.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

پاک‌سازی این مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید هم‌راستا است و اجازه می‌دهد [validateChartLayout](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#validateChartLayout) بدون خطا کامل شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
1. مراجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار حبابی (Bubble) با برخی داده‌ها اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
1. ارائه (Presentation) را ذخیره کنید.

این کد پایتون نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

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

## **مدیریت ورک‌شیت‌ها**

این کد پایتون عملیاتی را نشان می‌دهد که در آن متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdataworkbook/#getWorksheets) برای دسترسی به مجموعهٔ ورک‌شیت‌ها استفاده می‌شود:

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

این کد پایتون نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

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

## **تشخیص قالب‌های پشتیبانی‌نشدهٔ کتاب‌کارهای جاسازی‌شده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) بر روی [ChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/) همراه با شمارشگر [WorkbookType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده و حذف آن نمودارها استفاده کنید.

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
            # کتاب‌کار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue
        # داده‌های کتاب‌کار نمودار را در اینجا بخوانید یا ویرایش کنید.
finally:
    presentation.dispose()
```

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook), می‌توانید یا یک کتاب‌کار خارجی از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به خارجی تبدیل کنید.

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook), می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی استفاده شود (اگر کتاب‌کار جابجا شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌ها یا منابع دوردست را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

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

پارامتر دوم (`bool`) متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#setExternalWorkbook) برای مشخص کردن این استفاده می‌شود که آیا یک کتاب‌کار اکسل بارگذاری شود یا نه.

* وقتی مقدار آن به `False` تنظیم شود، تنها مسیر کتاب‌کار به‌روز می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند. ممکن است در موقعیتی که کتاب‌کار هدف وجود نداشته یا در دسترس نباشد، از این تنظیم استفاده کنید.  
* وقتی مقدار آن به `True` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) ایجاد کنید.  
1. مراجع اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء برای شکل (shape) نمودار ایجاد کنید.  
1. یک شیء برای نوع منبع ([ChartDataSourceType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdatasourcetype/)) ایجاد کنید که نمایانگر منبع دادهٔ نمودار است.  
1. شرط مربوطه را بر اساس اینکه نوع منبع برابر با نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

این کد پایتون عملیات را نشان می‌دهد:

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را به همان روشی که محتویات کتاب‌کارهای داخلی را تغییر می‌دهید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

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

### **بازیابی کتاب‌کار از حافظهٔ پنهان نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های ذخیره‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و متد [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `True` فراخوانی کنید.

مثال پایتون زیر یک ارائه را باز می‌کند که نمودار آن به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد و داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

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

    # داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا ویرایش کنید.
finally:
    presentation.dispose()
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را تنها زمانی فعال کنید که استفاده از داده‌های نمودار ذخیره‌شده گزینهٔ قابل قبول باشد، زیرا ممکن است حافظهٔ پنهان شامل تغییرات اعمال‌شده بر کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوند دارد؟**  
بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getDataSourceType) و یک [path to an external workbook](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت انتقال پروژه مناسب است؛ با این حال، توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/اشتراک‌های شبکه استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. خود فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز عبور محافظت شود، باید چه کنم؟**  
Aspose.Slides هنگام ایجاد پیوند، رمز عبور را نمی‌پذیرد. یک روش رایج این است که پیش از آن حفاظت را حذف کنید یا یک نسخهٔ رمزگشای شده (مثلاً با استفاده از [Aspose.Cells](/cells/python-java/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس خواهد شد.