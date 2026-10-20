---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells for Python via Java وتضمين دفتر العمل في عرض تقديمي PowerPoint باستخدام Aspose.Slides، بما في ذلك معاينة المخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells for Python via Java وتضمين دفتر العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides for Python via Java. يحتوي دفتر العمل المضمّن على كل من البيانات المصدرية والمخطط. تُظهر معاينة PNG منفصلة المخطط على الشريحة قبل تنشيط كائن OLE.

النتيجة هي كائن Excel مضمّن، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE تطبيق سطح مكتب يدعم تنشيط OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

قم بتثبيت حزم Python `aspose-cells` و `aspose-slides-java` بالإضافة إلى بيئة تشغيل Java متوافقة. استورد كلا الحزمتين قبل بدء الـ JVM بحيث تكون مكتباتهما الخاصة بـ Java متاحة لـ JPype. لا يلزم وجود Microsoft Office لإنشاء العرض التقديمي باستخدام هذه المكتبات.

لا توجد ملفات إدخال مطلوبة: ينشئ المثال البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى الدليل الحالي للعمل. طبّق تراخيص كلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيف يعمل التضمين**

1. إنشاء دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.  
1. اجعل ورقة المخطط نشطة بحيث يفتح دفتر العمل على المخطط.  
1. حدد نطاق عرض OLE لدفتر العمل وقم بتحويل المخطط إلى PNG.  
1. احفظ دفتر العمل كملف XLSX في الذاكرة وضمّ تلك البايتات في شريحة.  
1. عيّن PNG كمعاينة لكائن OLE واحفظ العرض التقديمي كملف PPTX.  

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) يأخذ مؤشرات الصف والعمود للبداية والنهاية صفرية القاعدة. بينما [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال الفهرس الصف 55 والفهرس العمود 25 كحدود سفلية يمنى؛ هذه القيم اختيارات تخطيط، ليست عدد صفوف أو أعمدة البيانات.

الإطار على الشريحة يستخدم النقاط. يُطابق المثال الإطار داخل الشريحة ويُوسّطها مع الحفاظ على نسبة العرض إلى الارتفاع للـ PNG، بدلًا من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

المثال الكامل التالي يملأ `DataSheet` بأربعة صفوف وخمسة أعمدة من القيم. كل صف يصبح سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

يتم حفظ دفتر العمل صراحةً كملف XLSX، متطابقًا مع الامتداد `xlsx` الممرّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). تحتفظ تدفقات بايتات Java بالدفتر والصورة في الذاكرة وتُوفر مصفوفات البايت المطلوبة من قبل واجهات برمجة تطبيقات Java. يتم تحميل PNG مباشرةً من بايتاته دون تحويل صورة وسيطة. يَستبدل تخصيصه عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) العنصر النائب الافتراضي لـ OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpway.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpway.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # إنشاء معاينة المخطط وتسلسل دفتر العمل القابل للتحرير بشكل منفصل.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # ملء المعاينة داخل الشريحة دون تغيير نسبة العرض إلى الارتفاع.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة مع دفتر عمل Excel مضمّن ومعاينة للمخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة مُوسّطة على الشريحة وتحتفظ بأبعادها.

![مخطط أعمدة Excel معروض كمعاينة لدفتر عمل مضمّن](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع توفر Excel، انقر مزدوجًا على الكائن لتفعيل وتحرير دفتر العمل المضمّن. يعتمد التفعيل والتحرير على دعم OLE لتطبيق المضيف وإعدادات الأمان.

## **الأسئلة المتكررة**

**لماذا أحتاج إلى صورة معاينة؟**

دفتر العمل المضمّن ومعاينة الشريحة الخاصة بهما محتوى منفصل. قدم صورة للمخطط بحيث تُظهر الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". راجع [Object Preview Issue when Adding OleObjectFrame](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عندما أغيّر دفتر العمل في الكود؟**

اعتبر المعاينة كلقطة ثابتة. عند تحديث بيانات دفتر العمل برمجيًا، أعد إنشاء صورة المخطط واستبدل المعاينة بالإضافة إلى بيانات دفتر العمل المضمَّنة.

**هل يمكنني استخدام XLS بدلاً من XLSX؟**

نعم. احفظ دفتر العمل بصيغة XLS واستخدم `xls` كامتداد للبيانات المضمّنة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تغيير الامتداد فقط لا يُحوِّل البيانات.

**لماذا قد يتغيّر حجم الكائن بعد التفعيل؟**

يمكن لتطبيق المضيف تحديث عرض كائن OLE عندما يُفعّل دفتر العمل. كل من نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة مهمان. راجع [Working Solution for Chart Resizing in PPTX](/slides/ar/python-java/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام ذات الصلة**

- [الحل العملي لإعادة تحجيم المخطط في PPTX](/slides/ar/python-java/working-solution-for-chart-resizing-in-pptx/)
- [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/python-java/object-preview-issue-when-adding-oleobjectframe/)