---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 40
url: /fa/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار Excel
- شی OLE
- جاسازی نمودار
- PowerPoint
- ارائه
- Python
- Java
- Aspose.Slides
description: "رفع تغییر اندازه ناخواسته نمودار در PPTX هنگام استفاده از اشیاء OLE Excel جاسازی‌شده با Aspose.Slides برای Python از طریق Java. تعیین ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و فریم OLE."
---
## **پیش‌زمینه**

نمودارهای Excel که به عنوان اشیاء OLE در ارائه‌های PowerPoint با استفاده از مؤلفه‌های Aspose جاسازی می‌شوند، می‌توانند پس از اولین فعال‌سازی اندازه خود را تغییر دهند. این می‌تواند باعث تفاوت قابل‌مشاهده‌ای در ظاهر نمودار قبل و بعد از فعال‌سازی شود. این مقاله توضیح می‌دهد چرا تغییر اندازه رخ می‌دهد و نشان می‌دهد چگونه می‌توان با هماهنگ‌سازی ابعاد ثابت نمودار با فریم OLE از آن جلوگیری کرد.

در [ایجاد نمودارهای Excel و جاسازی آن‌ها به عنوان اشیاء OLE در ارائه‌ها](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، ما توضیح دادیم چگونه یک نمودار Excel را با Aspose.Cells برای Python از طریق Java ایجاد کرده و آن را در یک ارائه PowerPoint با استفاده از Aspose.Slides برای Python از طریق Java جاسازی کنیم. برای رفع [مشکل پیش‌نمایش شی](/slides/fa/python-java/object-preview-issue-when-adding-oleobjectframe/)، تصویر نمودار را به فریم شی OLE نمودار اختصاص دادیم. در ارائه خروجی، هنگامی که فریم شی OLE که تصویر نمودار را نشان می‌دهد را دو بار کلیک می‌کنید، نمودار Excel فعال می‌شود. کاربران می‌توانند کتاب‌کار Excel جاسازی‌شده را ویرایش کنند و سپس با کلیک کردن خارج از کتاب‌کار فعال به اسلاید بازگردند. اندازه فریم شی OLE هنگام بازگشت کاربر به اسلاید تغییر می‌کند و عامل تغییر اندازه بسته به اندازه‌های اولیه هر دو فریم شی OLE و کتاب‌کار Excel جاسازی‌شده متفاوت است.

## **دلیل تغییر اندازه**

کتاب‌کار Excel جاسازی‌شده ابعاد خود را دارد که Excel سعی می‌کند هنگام اولین فعال‌سازی شی آن را حفظ کند. فریم OLE در اسلاید ابعاد مستقل خود را دارد. وقتی کتاب‌کار Excel فعال می‌شود، Excel و PowerPoint برای حفظ نسبت‌های آن، اندازه شی را مذاکره می‌کنند؛ این بخشی از فرایند جاسازی است. بنابراین تفاوت بین پنجره کتاب‌کار و فریم OLE می‌تواند موجب تغییر اندازه شی شود.

## **راه‌حل عملی**

اندازه نمودار را با فریم OLE در اسلاید مطابقت دهید و ابعاد نمودار را مستقل از پنجره کتاب‌کار نگه دارید. این راه‌حل برای ارائه جدید یا قالب موجود کار می‌کند.

این مثال به Aspose.Cells برای Python از طریق Java و Aspose.Slides برای Python از طریق Java نیاز دارد. یک نمودار ستونی ساده در یک برگه نمودار فعال ایجاد می‌کند و کتاب‌کار را در قالب XLS جاسازی می‌کند. هیچ تصویر پیش‌نمایش نموداری اختصاص داده نشده است؛ نمودار وقتی شی OLE در PowerPoint فعال می‌شود، قابل مشاهده می‌شود.

این مثال یک ارائه جدید با فریم OLE به اندازه 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبه چپ و 1 اینچ از بالا قرار دارد. مختصات و ابعاد اسلاید بر حسب پوینت هستند (72 پوینت در هر اینچ). برای یک ارائه موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) را روی false تنظیم کنید تا ابعاد نمودار مستقل از پنجره کتاب‌کار باشد. ابعاد [getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) را از طریق [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) و [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) تنظیم کنید، با تبدیل پوینت‌ها به پیکسل با استفاده از 96 پیکسل در هر اینچ: فریمی با اندازه 684 × 288 پوینت به نموداری با اندازه 912 × 384 پیکسل متناظر است. [setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) را بر روی مقدار CUSTOM از [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) تنظیم کنید. مثال کتاب‌کار را با [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) جاسازی می‌کند و ارائه‌ای با فریم OLE به اندازه 9.5 × 4 اینچ ذخیره می‌نماید.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # مختصات و ابعاد اسلاید بر حسب نقطه هستند (۷۲ نقطه در هر اینچ).
        width = 684.0  # ۹.۵ اینچ.
        height = 288.0  # ۴ اینچ.

        chart.setSizeWithWindow(False)
        # نقطه‌ها را به پیکسل‌های نمودار با استفاده از ۹۶ پیکسل در هر اینچ تبدیل کنید.
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **استفاده از قالب**

منطق اندازه‌گذاری برای یک ارائه موجود نیز یکسان است. برای سازگار کردن مثال:

1. ارائه قالب را بارگذاری کنید به جای ایجاد یک ارائه خالی.
2. بررسی کنید که اسلاید اول حداقل شامل سه شکل باشد، سپس شکل با شاخص 2 را به عنوان جای‌گیر استفاده کنید.
3. عرض و ارتفاع فریم را از آن شکل بگیرید به جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گیری را دست نخورده نگه دارید.
4. فریم OLE را در موقعیت جای‌گر اضافه کنید به جای مختصات ثابت 36 و 72.
5. قبل از ذخیره‌سازی ارائه، جای‌گر را حذف کنید.

## **سوالات متداول**

**چرا نمودار Excel جاسازی‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این به این دلیل رخ می‌دهد که Excel سعی می‌کند هنگام اولین فعال‌سازی، اندازه اصلی پنجره را بازگرداند، در حالی که فریم شی OLE در PowerPoint ابعاد خود را دارد. PowerPoint و Excel برای حفظ نسبت عرض به ارتفاع، اندازه را مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توانم ابعاد نمودار و فریم OLE را ثابت نگه دارم؟**

ابعاد ثابت نمودار را طوری تنظیم کنید که با فریم OLE مطابقت داشته باشد و قبل از جاسازی کتاب‌کار، از یک اندازه چاپ سفارشی برای نمودار استفاده کنید. مثال بالا تنظیمات لازم و تبدیل واحدها را نشان می‌دهد.

**آیا تطبیق اندازه پنجره کتاب‌کار کافی است؟**

تنها تطبیق اندازه پنجره کتاب‌کار به طور قابل‌اعتمادی مانع تغییر اندازه فریم OLE پس از فعال‌سازی نمی‌شود. همان‌طور که در مثال آمده، از ابعاد ثابت نمودار استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**

بله. برای قالب، از ابعاد و موقعیت جای‌گر استفاده کنید. برای یک ارائه جدید، مستقیماً ابعاد و موقعیت فریم را مشخص کنید.

**آیا می‌توانم از این مثال با نمودارهای ایجاد شده در برنامه‌های صفحه‌گسترده دیگر استفاده کنم؟**

این مثال از یک کتاب‌کار Excel ایجاد شده با Aspose.Cells استفاده می‌کند. رفتار فعال‌سازی برای برنامه‌های صفحه‌گسترده دیگر را نشان نمی‌دهد.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای Excel و جاسازی آن‌ها به عنوان اشیاء OLE در ارائه‌ها](/slides/fa/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)