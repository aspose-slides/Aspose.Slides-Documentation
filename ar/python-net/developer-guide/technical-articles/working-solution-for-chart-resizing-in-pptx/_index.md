---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 60
url: /ar/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين مخطط
- PowerPoint
- عرض تقديمي
- Python عبر .NET
- Python
- Aspose.Slides
description: "إصلاح تغيير حجم المخطط غير المتوقع في PPTX عند استخدام كائنات OLE المضمنة من Excel مع Aspose.Slides لبايثون عبر .NET. تعيين أبعاد مخطط ثابتة للحفاظ على تناسق أحجام المخطط وإطار OLE."
---
## **نظرة عامة**

يمكن أن يتغير حجم مخططات Excel المضمَّنة ككائنات OLE في عروض PowerPoint التقديمية باستخدام مكوّنات Aspose بعد تنشيطها الأول. يمكن أن يتسبب ذلك في فرق ملحوظ في مظهر المخطط قبل وبعد التنشيط. يوضح هذا المقال سبب حدوث تغيير الحجم ويظهر كيفية منعه عن طريق مطابقة أبعاد المخطط الثابتة مع إطار OLE.

In [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for Python via .NET and embed it in a PowerPoint presentation using Aspose.Slides for Python via .NET. To address the [مشكلة معاينة الكائن](/slides/ar/python-net/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **سبب تغيير الحجم**

المصنف المدمج لـ Excel له أبعاد نافذة خاصة به، يحاول Excel الاحتفاظ بها عندما يتم تنشيط الكائن لأول مرة. إطار OLE على الشريحة له أبعاد معرفة بشكل مستقل. عندما يتم تنشيط المصنف، يتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. لذلك يمكن أن تؤدي الاختلافات بين نافذة المصنف وإطار OLE إلى تغيير حجم الكائن.

## **الحل العملي**

قم بمطابقة حجم المخطط مع إطار OLE على الشريحة واحتفظ بأبعاد المخطط مستقلة عن نافذة المصنف. يعمل هذا الحل مع عرض تقديمي جديد أو قالب موجود.

المثال يتطلب Aspose.Cells for Python via .NET وAspose.Slides for Python via .NET. يقوم بإنشاء مخطط عمودي بسيط على ورقة مخطط نشطة وتضمين المصنف بتنسيق XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تنشيط كائن OLE في PowerPoint.

المثال ينشئ عرض تقديمي جديد بإطار OLE بحجم 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة). لعرض تقديمي موجود، راجع [استخدام قالب](#use-a-template).

## **تعيين حجم مخطط ثابت**

Set [size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) to false so that the chart dimensions are independent of the workbook window. Set the [chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) dimensions through [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) and [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/). The example embeds the workbook with [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) and saves a presentation with a 9.5 × 4-inch OLE frame.

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

    # إحداثيات الشريحة وأبعادها بالنقاط (72 نقطة لكل بوصة).
    width = 684.0  # 9.5 بوصة.
    height = 288.0  # 4 بوصة.

    chart.size_with_window = False
    # تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **استخدام قالب**

منطق التحجيم هو نفسه لعرض تقديمي موجود. لتكييف المثال:

1. Load the template presentation instead of creating an empty presentation.  
2. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.  
3. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.  
4. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.  
5. Remove the placeholder before saving the presentation.

## **الأسئلة الشائعة**

**لماذا يتغير حجم مخطط Excel المضمّن بعد تنشيطه في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التنشيط الأول، في حين أن إطار كائن OLE في PowerPoint له أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يؤدي إلى تعديل الحجم.

**كيف يمكنني الحفاظ على تناسق أحجام المخطط وإطار OLE؟**  
قم بتعيين أبعاد مخطط ثابتة تتطابق مع إطار OLE واستخدم حجم طباعة مخطط مخصص قبل تضمين المصنف. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل مطابقة حجم نافذة المصنف كافية؟**  
مطابقة حجم نافذة المصنف وحدها لا تمنع تغيير حجم إطار OLE بشكل موثوق بعد التنشيط. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع كل من العروض التقديمية القائمة على القالب والعروض التقديمية الجديدة؟**  
نعم. للقالب، استخدم أبعاد وموقع العنصر النائب. للعرض التقديمي الجديد، حدد أبعاد وإحداثيات الإطار مباشرة.

**هل يمكنني استخدام هذا المثال مع المخططات التي تم إنشاؤها في برامج جداول بيانات أخرى؟**  
يستخدم المثال مصنف Excel تم إنشاؤه بـ Aspose.Cells. لا يوضح سلوك التنشيط لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)