---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 50
url: /ar/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- Python
- Python عبر .NET
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells لـ Python عبر .NET وتضمين ملف العمل في عرض PowerPoint باستخدام Aspose.Slides، بما في ذلك معاينة للمخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells لـ Python عبر .NET وتضمين ملف العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides لـ Python عبر .NET. يحتوي ملف العمل المدمج على كلٍ من البيانات المصدرية والمخطط. تعرض معاينة PNG منفصلة المخطط على الشريحة قبل تفعيل كائن OLE.

النتيجة هي كائن Excel مدمج، وليس مخطط PowerPoint أصلي. يتطلب تحرير ملف العمل عبر OLE تطبيق سطح مكتب يدعم تفعيل OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

قم بتثبيت حزم `aspose-cells-python` و `aspose-slides` في بيئة Python الخاصة بك. لا يلزم وجود Microsoft Office لإنشاء العرض التقديمي باستخدام هذه المكتبات.

لا يلزم وجود ملفات إدخال: المثال ينشئ البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى الدليل العامل الحالي. قم بتطبيق التراخيص لكلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيف يعمل الدمج**

1. إنشاء ملف عمل يحتوي على ورقة بيانات وورقة مخطط.  
2. جعل ورقة المخطط نشطة بحيث يفتح ملف العمل على المخطط.  
3. ضبط نطاق عرض OLE لملف العمل وتوليد المخطط إلى PNG.  
4. حفظ ملف العمل كملف XLSX في الذاكرة وتضمين تلك البايتات في شريحة.  
5. تعيين PNG كمعاينة لكائن OLE وحفظ العرض التقديمي كملف PPTX.

نطاق عرض ملف العمل والإطار على الشريحة لهما وظائف مختلفة. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) يأخذ مؤشرات الصف والعمود بدايةً ونهايةً صفرية. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) بدلاً من ذلك يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال الفهرس الصف 55 وفهرس العمود 25 كحدود سفلية‑يمنى؛ هذه القيم اختيارات تخطيط، ليست عدد الصفوف أو الأعمدة البيانات.

يستخدم إطار الشريحة النقاط. يتوافق المثال مع الشريحة ويُوسّطها مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

المثال الكامل التالي يملأ `DataSheet` بأربع صفوف وخمس أعمدة من القيم. يصبح كل صف سلسلة في المخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ ملف العمل.

يتم حفظ ملف العمل صراحةً كملف XLSX، متطابقًا مع الامتداد `xlsx` الممرّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). يتم تحميل PNG مباشرةً من الدفق الخاص به دون تحويل إلى صورة بتيك مبدئية. استبداله عبر [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) يستبدل العنصر النائب الافتراضي لـ OLE.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# قم بتوليد معاينة المخطط وحفظ ملف العمل القابل للتعديل بشكل منفصل.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # قم بملاءمة المعاينة داخل الشريحة دون تغيير نسبة أبعادها.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة بها ملف عمل Excel مدمج ومعاينة مخطط. يحتوي ملف العمل على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة متمركزة على الشريحة وتحتفظ بنسبها.

![مخطط عمودي في Excel معروض كمعاينة لملف عمل مدمج](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع وجود Excel، انقر نقرًا مزدوجًا على الكائن لتفعيل وتحرير ملف العمل المدمج. يعتمد التفعيل والتحرير على دعم OLE في التطبيق المضيف وإعدادات الأمان.

## **الأسئلة المتداولة**

**لماذا يلزم وجود صورة معاينة؟**  
ملف العمل المدمج ومعاينة الشريحة منفصلان. زوّد صورة مخطط حتى تُظهر الشريحة المخطط بدلًا من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". راجع [Object Preview Issue when Adding OleObjectFrame](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/).

**هل تُحدّث المعاينة تلقائيًا عند تغيير ملف العمل في الشيفرة؟**  
اعتبر المعاينة لقطة ثابتة. عند تحديث بيانات ملف العمل برمجيًا، أعد توليد صورة المخطط واستبدل المعاينة بالإضافة إلى بيانات ملف العمل المدمج.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**  
نعم. احفظ ملف العمل بتنسيق XLS واستخدم `xls` كامتداد البيانات المدمجة. يجب أن يتطابق الامتداد مع تنسيق ملف العمل الفعلي؛ تغيير الامتداد وحده لا يحول البيانات.

**لماذا قد يتغيّر حجم الكائن بعد التفعيل؟**  
يمكن للتطبيق المضيف تحديث عرض كائن OLE عند تفعيل ملف العمل. كل من نطاق عرض OLE لملف العمل وأبعاد إطار الشريحة مهمان. راجع [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/ar/python-net/working-solution-for-worksheet-resizing/).

## **الأقسام ذات الصلة**

- [Resize OLE Objects Automatically in PowerPoint Presentations](/slides/ar/python-net/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/ar/python-net/manage-ole/)