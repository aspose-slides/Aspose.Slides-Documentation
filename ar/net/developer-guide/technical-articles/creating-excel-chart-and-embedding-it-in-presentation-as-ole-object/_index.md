---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 50
url: /ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين المخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells for .NET وتضمين دفتر العمل في عرض PowerPoint باستخدام Aspose.Slides، بما في ذلك معاينة المخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells for .NET وتضمين دفتر العمل الخاص به في عرض تقديمي PowerPoint باستخدام Aspose.Slides for .NET. يحتوي دفتر العمل المدمج على كل من البيانات المصدرية والمخطط. يتم عرض معاينة PNG منفصلة للمخطط على الشريحة قبل تفعيل كائن OLE.

النتيجة هي كائن Excel مدمج، وليس مخطط PowerPoint أصلي. يتطلب تحرير دفتر العمل عبر OLE تطبيق سطح مكتب يدعم تفعيل OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

أضف مراجع إلى Aspose.Cells for .NET و Aspose.Slides for .NET في مشروع C# الخاص بك. يستخدم المثال العبارات المستوى الأعلى ويتطلب C# 9 أو ما بعده. لا يلزم وجود Microsoft Office لتوليد العرض التقديمي باستخدام هذه المكتبات.

لا توجد ملفات إدخال مطلوبة: ينشئ المثال البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى الدليل العامل الحالي. قم بتطبيق التراخيص لكلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيفية عمل التضمين**

1. إنشاء دفتر عمل يحتوي على ورقة بيانات وورقة مخطط.  
2. جعل ورقة المخطط نشطة بحيث يفتح دفتر العمل على المخطط.  
3. تحديد نطاق عرض OLE لدفتر العمل وتحويل المخطط إلى PNG.  
4. حفظ دفتر العمل كـ XLSX في الذاكرة وتضمين تلك البايتات في شريحة.  
5. تعيين PNG كمعاينة لكائن OLE وحفظ العرض التقديمي كـ PPTX.

نطاق عرض دفتر العمل والإطار على الشريحة لهما أدوار مختلفة. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) يأخذ فهارس الصف والعمود البدء/النهاية صفرية الأساس. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) بدلاً من ذلك يأخذ الصف العلوي، العمود الأيسر، الصف السفلي، والعمود الأيمن. يستخدم المثال فهرس الصف 55 وفهرس العمود 25 كحدود السفلية اليمنى؛ هذه القيم هي اختيارات تخطيط، ليست عدد الصفوف أو الأعمدة البيانات.

يستخدم إطار الشريحة الوحدات النقطية (points). يضبط المثال الإ إطار داخل الشريحة ويحوّده إلى الوسط مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وتضمين المخطط**

المثال الكامل التالي يملأ `DataSheet` بأربع صفوف وخمس أعمدة من القيم. يصبح كل صف سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ دفتر العمل.

يتم حفظ دفتر العمل صراحة كـ XLSX، مطابقة للامتداد `xlsx` الممرّر إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/). يتم تحميل PNG مباشرةً من الدفق دون تحويل bitmap وسيط. يبدّل تعيينه عبر [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) القالب الافتراضي لـ OLE.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// عرض المخطط مسبقًا وتسلسل دفتر العمل القابل للتحرير بشكل منفصل.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة مع دفتر عمل Excel مدمج ومعاينة مخطط. يحتوي دفتر العمل على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة متمركزة على الشريحة وتحتفظ بنسبها.

![مخطط عمودي في Excel يُعرض كمعاينة لدفتر عمل مدمج](excel-chart-ole-preview.png)

في بيئة PowerPoint سطح مكتب متوافقة مع توفر Excel، انقر مزدوجًا على الكائن لتفعيل وتحرير دفتر العمل المدمج. يعتمد التفعيل والتحرير على دعم OLE لتطبيق المضيف وإعدادات الأمان.

## **الأسئلة الشائعة**

**لماذا يلزم وجود صورة معاينة؟**

دفتر العمل المدمج ومعاينة الشريحة الخاصة بهما محتوى منفصل. قدّم صورة مخطط حتى تُظهر الشريحة المخطط بدلاً من العنصر النائب الافتراضي "EMBEDDED OLE OBJECT". راجع [Object Preview Issue when Adding OleObjectFrame](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عندما أقوم بتغيير دفتر العمل في الكود؟**

عامل المعاينة كلقطة ثابتة. عند تحديث بيانات دفتر العمل برمجيًا، أعد إنشاء صورة المخطط واستبدل المعاينة وكذلك بيانات دفتر العمل المدمج.

**هل يمكنني استخدام XLS بدلًا من XLSX؟**

نعم. احفظ دفتر العمل بصيغة XLS واستخدم `xls` كامتداد البيانات المدمجة. يجب أن يتطابق الامتداد مع تنسيق دفتر العمل الفعلي؛ تغيير الامتداد وحده لا يحول البيانات.

**لماذا قد يتغير حجم الكائن بعد التفعيل؟**

يمكن لتطبيق المضيف تحديث عرض كائن OLE عندما يفعيل دفتر العمل. يؤثر كل من نطاق عرض OLE لدفتر العمل وأبعاد إطار الشريحة. راجع [Working Solution for Chart Resizing in PPTX](/slides/ar/net/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام ذات الصلة**

- [حل عملي لتغيير حجم المخطط في PPTX](/slides/ar/net/working-solution-for-chart-resizing-in-pptx/)
- [مشكلة معاينة الكائن عند إضافة OleObjectFrame](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)