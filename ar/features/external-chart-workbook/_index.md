---
title: ربط المخططات بدفاتر عمل خارجية
description: ربط بيانات المخطط بدفتر عمل خارجي وتحديثها.
type: docs
url: /ar/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: المخططات
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **نظرة عامة**

قم بتوجيه المخطط إلى دفتر عمل خارجي بدلاً من إبقاء جميع بيانات المصدر مدمجة في العرض التقديمي. يمكنك تعيين مسار دفتر العمل واختيار ما إذا كنت تريد تحديث المخطط من ذلك الملف. يمكن للمخطط المحفوظ أيضًا أن يحمل بيانات عرض مخزنة مؤقتًا.

## **مثال على الاستخدام**

يستخدم مثال C# هذا مكتبة Aspose.Slides for .NET. أنشئ دفتر عمل مبيعات صالح بحيث تكون القيمة الشمالية = 55 والجنوبية = 40 واكتبها كملف sales.xlsx بجانب المخرج. أعد ضبط القيمة الشمالية للمخطط إلى 20، ثم اربط المخطط بالمسار المطلق لدفتر العمل وحدثه: تعود القيمة الشمالية إلى 55 مرة أخرى. يغطي النطاق المحدد الرأس وصفين من البيانات. احرص على إبقاء ملف sales.xlsx متاحًا عند إعادة فتح أو تحديث المخطط المرتبط؛ لا يدمج العرض التقديمي هذا الملف الخارجي. لا يلزم ملف إدخال. يتم حفظ *external-chart-workbook.pptx* و *external-chart-workbook.png*. قم بتثبيت المكتبة باستخدام [دليل التثبيت](/slides/ar/net/installation/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **الأسئلة الشائعة**

### **هل يمكنني قراءة جميع القيم المخزنة مؤقتًا عندما يكون الملف المرتبط مفقودًا؟**

يمكن لـ Aspose.Slides for .NET 26.11 [قراءة القيم المخزنة للمخطط مباشرة](/slides/ar/net/chart-workbook/#read-cached-chart-values-without-a-workbook) دون فتح دفتر العمل المرتبط. يشمل ذلك القيم العادية، قيم X/Y، أحجام الفقاعات والقيم الفئوية عندما تكون تلك المخازن موجودة. قد تكون البيانات المخزنة غير موجودة أو قديمة؛ فهي ليست دفتر عمل كامل. لا يزال تحديث البيانات من المصدر يتطلب وجود دفتر عمل مدعوم متاح. بالنسبة لـ SDKs والإصدارات الأخرى، تحقق من دليل المخطط المقابل.

### **ماذا يحدث إذا تم نقل دفتر العمل الخارجي؟**

قم بتحديث مسار دفتر العمل الخارجي للمخطط إلى موقعه الجديد، وتأكد من إتاحة هذا الملف في أي مكان يتم فيه معالجة العرض التقديمي. لا تعتمد على البيانات المخزنة مؤقتًا لإجراء عمليات وصول كاملة إلى البيانات عندما تكون مفقودة.

### **هل يمكنني اختيار ما إذا كنت أريد تحديث البيانات المخزنة للمخطط عند الربط؟**

نعم. يمكنك اختيار ما إذا كنت تريد تحديث بيانات المخطط عند إعداد الرابط. يتطلب التحديث وجود دفتر عمل مدعوم متاح؛ تخطي التحديث يسجل الرابط دون قراءة قيم جديدة من ذلك الملف.

## **الأدلة**

- [إدارة دفاتر عمل المخططات في العروض التقديمية في .NET](/slides/ar/net/chart-workbook/)

الميزة ذات الصلة: [ملء المخططات القابلة للتعديل بالبيانات](/slides/ar/features/chart-data-binding/).