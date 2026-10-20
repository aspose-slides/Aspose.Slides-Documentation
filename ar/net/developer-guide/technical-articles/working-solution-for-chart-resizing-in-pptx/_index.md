---
title: حل عملي لتغيير حجم المخطط في PPTX
type: docs
weight: 60
url: /ar/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- تغيير حجم المخطط
- مخطط Excel
- كائن OLE
- تضمين مخطط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إصلاح تعديل حجم المخطط غير المتوقع في ملفات PPTX عند استخدام كائنات OLE من Excel المضمّنة مع Aspose.Slides for .NET. عيّن أبعاد مخطط ثابتة للحفاظ على تناسق أحجام المخطط وإطار OLE."
---
## **الخلفية**

مخططات Excel المدمجة ككائنات OLE في عروض PowerPoint باستخدام مكوّنات Aspose يمكن أن تغير حجمها بعد تنشيطها الأول. هذا قد يسبب فرقًا ملحوظًا في مظهر المخطط قبل وبعد التنشيط. توضح هذه المقالة سبب حدوث تعديل الحجم وتظهر كيفية منعه عن طريق مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرّحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for .NET وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE للمخطط. في عرض الشرائح الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة المخطط، يتم تنشيط مخطط Excel. يمكن للمستخدمين تحرير المصنف المضمّن ثم العودة إلى الشريحة بالنقر خارج المصنف المنشط. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة تعديل الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE والمصنف المضمن.

## **سبب تعديل الحجم**

المصنف المضمّن لـ Excel لديه أبعاد نافذة خاصة، التي يحاول Excel الحفاظ عليها عند تنشيط الكائن لأول مرة. إطار OLE على الشريحة له أبعاد معرفة بشكل مستقل. عندما يتم تنشيط المصنف، يتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. وبالتالي يمكن للاختلافات بين نافذة المصنف وإطار OLE أن تتسبب في تعديل حجم الكائن.

## **الحل العملي**

مطابقة حجم المخطط مع إطار OLE على الشريحة والحفاظ على أبعاد المخطط مستقلة عن نافذة المصنف. يعمل هذا الحل مع عرض تقديمي جديد أو قالب موجود.

يتطلب المثال Aspose.Cells for .NET وAspose.Slides for .NET. يقوم بإنشاء مخطط عمودي بسيط على ورقة مخطط نشطة ويضمّن المصنف بتنسيق XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تنشيط كائن OLE في PowerPoint.

المثال ينشئ عرضًا تقديميًا جديدًا بإطار OLE بحجم 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات الشريحة وأبعادها بوحدات النقاط (72 نقطة لكل بوصة). لعرض تقديمي موجود، راجع [استخدام قالب](#use-a-template).

## **تعيين حجم مخطط ثابت**

قم بتعيين [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) إلى false بحيث تكون أبعاد المخطط مستقلة عن نافذة المصنف. اضبط أبعاد [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) عبر [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) و[Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/)، مع تحويل النقاط إلى بكسل باستخدام 96 بكسل لكل بوصة: الإطار الذي يقيس 684 × 288 نقطة يساوي مخططًا بحجم 912 × 384 بكسل. قم بتعيين [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) إلى القيمة Custom من [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/). يضمّن المثال المصنف باستخدام [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) ويحفظ عرضًا تقديميًا بإطار OLE بحجم 9.5 × 4 بوصة.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// إحداثيات الشريحة وأبعادها بوحدات النقاط (72 نقطة لكل بوصة).
var width = 684f; // 9.5 بوصة.
var height = 288f; // 4 بوصة.

chart.SizeWithWindow = false;
// تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```
## **استخدام قالب**

منطق حجم الإطار هو نفسه لعرض تقديمي موجود. لتكييف المثال:

1. حمّل عرض القالب بدلاً من إنشاء عرض فارغ.  
2. تحقق من أن الشريحة الأولى تحتوي على ثلاثة أشكال على الأقل، ثم استخدم الشكل عند الفهرس 2 كعنصر نائب.  
3. احصل على عرض وإرتفاع الإطار من ذلك الشكل بدلاً من استخدام القيم الثابتة 684 و288. حافظ على حسابات الحجم دون تغيير.  
4. أضف إطار OLE في موقع عنصر النائب بدلاً من الإحداثيات الثابتة 36 و72.  
5. احذف عنصر النائب قبل حفظ العرض.

## **FAQ**

**لماذا يتغير حجم مخطط Excel المضمّن بعد تنشيطه في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التنشيط الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يسبب تعديل الحجم.

**كيف يمكن الحفاظ على تناسق أحجام المخطط وإطار OLE؟**  
قم بتحديد أبعاد مخطط ثابتة تتطابق مع إطار OLE واستخدم حجم طباعة مخصص للمخطط قبل تضمين المصنف. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل مطابقة حجم نافذة المصنف كافية؟**  
مطابقة حجم نافذة المصنف وحده لا يضمن منع إطار OLE من تغيير حجمه بعد التنشيط بشكل موثوق. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض القائمة على القالب والعروض الجديدة؟**  
نعم. بالنسبة للقالب، استخدم أبعاد وموقع عنصر النائب. بالنسبة لعرض تقديمي جديد، حدّد أبعاد الإطار وموقعه مباشرة.

**هل يمكن استخدام هذا المثال مع مخططات تم إنشاؤها في برامج جداول بيانات أخرى؟**  
يستخدم المثال مصنف Excel تم إنشاؤه باستخدام Aspose.Cells. لا يوضح سلوك التنشيط لبرامج جداول بيانات أخرى.

## **الأقسام المتعلقة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)