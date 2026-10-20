---
title: راه‌حل عملی برای تغییر اندازه نمودار در PPTX
type: docs
weight: 60
url: /fa/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغییر اندازه نمودار
- نمودار اکسل
- شی OLE
- تعبیه نمودار
- PowerPoint
- ارائه
- Python از طریق .NET
- پایتون
- Aspose.Slides
description: "رفع تغییر اندازه غیرمنتظره نمودار در PPTX هنگام استفاده از اشیای OLE تعبیه‌شده اکسل با Aspose.Slides برای Python از طریق .NET. تنظیم ابعاد ثابت نمودار برای حفظ سازگاری اندازه‌های نمودار و چارچوب OLE."
---
## **نمای کلی**

نمودارهای اکسل که به‌عنوان اشیاء OLE در ارائه‌های PowerPoint با استفاده از اجزای Aspose تعبیه می‌شوند، پس از اولین فعال‌سازی می‌توانند اندازه‌شان تغییر کند. این می‌تواند تفاوت مشهودی بین ظاهر نمودار قبل و بعد از فعال‌سازی ایجاد کند. این مقاله دلیل بروز تغییر اندازه را توضیح می‌دهد و نشان می‌دهد چگونه با هم‌خوانی ابعاد ثابت نمودار با چارچوب OLE از آن جلوگیری کرد.

در [ایجاد نمودارهای اکسل و تعبیه آن‌ها به‌عنوان اشیاء OLE در ارائه‌ها](/slides/fa/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) ما توضیح دادیم چگونه یک نمودار اکسل با Aspose.Cells for Python via .NET ایجاد و آن را با Aspose.Slides for Python via .NET در یک ارائه PowerPoint تعبیه کنیم. برای رفع [مسئله پیش‌نمایش شی](/slides/fa/python-net/object-preview-issue-when-adding-oleobjectframe/) ما تصویر نمودار را به چارچوب شی OLE اختصاص دادیم. در ارائه خروجی، وقتی بر روی چارچوب شی OLE که تصویر نمودار را نمایش می‌دهد دوبار کلیک کنید، نمودار اکسل فعال می‌شود. کاربران می‌توانند کاربرگ تعبیه‌شده را ویرایش کرده و سپس با کلیک خارج از کاربرگ فعال، به اسلاید بازگردند. اندازه چارچوب شی OLE زمانی که کاربر به اسلاید باز می‌گردد تغییر می‌کند و عامل تغییر اندازه بسته به ابعاد اولیه هر دو چارچوب شی OLE و کاربرگ تعبیه‌شده متفاوت است.

## **دلیل تغییر اندازه**

کاربرگ تعبیه‌شده اکسل دارای ابعاد پنجره خود است که اکسل سعی می‌کند هنگام اولین فعال‌سازی آن را حفظ کند. چارچوب OLE روی اسلاید ابعاد مستقلی دارد. وقتی کاربرگ اکسل فعال می‌شود، اکسل و PowerPoint برای حفظ نسبت‌های ابعاد شی، اندازه آن را تنظیم می‌کنند. اختلاف بین پنجره کاربرگ و چارچوب OLE می‌تواند منجر به تغییر اندازه شی شود.

## **راه‌حل عملی**

اندازه نمودار را با چارچوب OLE روی اسلاید همسان کنید و ابعاد نمودار را مستقل از پنجره کاربرگ نگه دارید. این راه‌حل برای ارائه جدید یا قالب موجود کار می‌کند.

این مثال به Aspose.Cells for Python via .NET و Aspose.Slides for Python via .NET نیاز دارد. یک نمودار ستونی ساده روی یک شیت نمودار فعال ایجاد می‌کند و کاربرگ را در قالب XLS تعبیه می‌نماید. تصویری برای پیش‌نمایش نمودار اختصاص داده نمی‌شود؛ نمودار زمانی که شی OLE در PowerPoint فعال می‌شود، قابل مشاهده می‌شود.

مثال یک ارائه جدید با یک چارچوب OLE به اندازه 9.5 × 4 اینچ ایجاد می‌کند که 0.5 اینچ از لبه چپ و 1 اینچ از لبه بالا قرار دارد. مختصات و ابعاد اسلاید بر حسب پوینت (72 پوینت در هر اینچ) هستند. برای ارائه موجود، به [استفاده از قالب](#use-a-template) مراجعه کنید.

## **تنظیم اندازه ثابت نمودار**

Set [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) را روی false تنظیم کنید تا ابعاد نمودار مستقل از پنجره کاربرگ باشد. ابعاد [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) را از طریق [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) و [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) تنظیم کنید و پوینت‌ها را با استفاده از 96 پیکسل در هر اینچ به پیکسل تبدیل کنید: چارچوبی با اندازه 684 × 288 پوینت معادل نموداری با اندازه 912 × 384 پیکسل است. [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) را روی مقدار CUSTOM از [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) تنظیم کنید. مثال کاربرگ را با [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) تعبیه می‌کند و ارائه‌ای با چارچوب OLE به اندازه 9.5 × 4 اینچ ذخیره می‌نماید.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # مختصات و ابعاد اسلاید بر حسب پوینت (۷۲ پوینت در هر اینچ) است.
    width = 684.0  # 9.5 اینچ.
    height = 288.0  # 4 اینچ.

    chart.size_with_window = False
    # تبدیل پوینت‌ها به پیکسل‌های نمودار با استفاده از ۹۶ پیکسل در هر اینچ.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **استفاده از قالب**

منطق اندازه‌گذاری برای ارائه موجود مشابه است. برای تطبیق مثال:

1. به جای ایجاد یک ارائه خالی، قالب ارائه را بارگذاری کنید.  
2. اطمینان حاصل کنید که اسلاید اول حداقل سه شکل دارد، سپس شکل با ایندکس 2 را به‌عنوان جای‌نگهدار استفاده کنید.  
3. عرض و ارتفاع چارچوب را از آن شکل بگیرید به‌جای استفاده از مقادیر ثابت 684 و 288. محاسبات اندازه‌گذاری را همان‌گونه باقی بگذارید.  
4. چارچوب OLE را در موقعیت جای‌نگهدار اضافه کنید نه در مختصات ثابت 36 و 72.  
5. قبل از ذخیره ارائه، جای‌نگهدار را حذف کنید.

## **سوالات متداول**

**چرا نمودار اکسل تعبیه‌شده من پس از فعال‌سازی در PowerPoint اندازه‌اش را تغییر می‌دهد؟**

این به این دلیل رخ می‌دهد که اکسل سعی می‌کند اندازه اولیه پنجره را هنگام اولین فعال‌سازی بازگرداند، در حالی که چارچوب شی OLE در PowerPoint ابعاد مختص خود را دارد. PowerPoint و اکسل برای حفظ نسبت عرض به ارتفاع با یکدیگر مذاکره می‌کنند که می‌تواند منجر به تغییر اندازه شود.

**چگونه می‌توان ابعاد نمودار و چارچوب OLE را یکسان نگه داشت؟**

ابعاد ثابت نمودار را طوری تنظیم کنید که با چارچوب OLE همخوانی داشته باشد و قبل از تعبیه کاربرگ، یک اندازه چاپ سفارشی برای نمودار تعیین کنید. مثال بالا تنظیمات موردنیاز و تبدیل واحدها را نشان می‌دهد.

**آیا هم‌ساز کردن اندازه پنجره کاربرگ کافی است؟**

تنها هم‌ساز کردن اندازه پنجره کاربرگ به‌طور قابل‌اعتمادی از تغییر اندازه چارچوب OLE پس از فعال‌سازی جلوگیری نمی‌کند. همان‌طور که در مثال نشان داده شد، باید از ابعاد ثابت نمودار استفاده کنید.

**آیا این راه‌حل برای ارائه‌های مبتنی بر قالب و ارائه‌های جدید کار می‌کند؟**

بله. برای قالب، از ابعاد و موقعیت جای‌نگهدار استفاده کنید. برای ارائه جدید، مستقیماً ابعاد و موقعیت چارچوب را مشخص کنید.

**آیا می‌توانم از این مثال برای نمودارهایی که در برنامه‌های صفحه‌گسترده دیگر ایجاد شده‌اند استفاده کنم؟**

این مثال از یک کاربرگ اکسل ایجاد شده با Aspose.Cells استفاده می‌کند. رفتار فعال‌سازی برای برنامه‌های صفحه‌گسترده دیگر نشان داده نشده است.

## **بخش‌های مرتبط**

- [ایجاد نمودارهای اکسل و تعبیه آن‌ها به‌عنوان اشیاء OLE در ارائه‌ها](/slides/fa/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [به‌روزرسانی خودکار اشیاء OLE با استفاده از یک افزونه PowerPoint](/slides/fa/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)