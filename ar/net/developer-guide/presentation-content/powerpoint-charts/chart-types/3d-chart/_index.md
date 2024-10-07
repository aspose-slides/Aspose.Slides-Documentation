---
title: مخطط ثلاثي الأبعاد
type: docs
url: /net/3d-chart/
keywords: "مخطط ثلاثي الأبعاد, rotationX, rotationY, depthpercent, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تعيين rotationX و rotationY و depthpercents لمخطط ثلاثي الأبعاد في عرض PowerPoint باستخدام C# أو .NET"
---

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك المقال التالي في كيفية تعيين خصائص مختلفة مثل دوران X و Y، و **DepthPercents** وغيرها. الشفرة التجريبية تطبق تعيين الخصائص المذكورة أعلاه.

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع بيانات افتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض المعدل إلى ملف PPTX.

```c#
// إنشاء نسخة من فئة Presentation
Presentation presentation = new Presentation();
           
// الوصول إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// إضافة مخطط مع بيانات افتراضية
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات المخطط
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// إضافة سلاسل
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "السلسلة 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "السلسلة 2"), chart.Type);

// إضافة فئات
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "الفئة 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "الفئة 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "الفئة 3"));

// تعيين خصائص Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// أخذ السلسلة الثانية للمخطط
IChartSeries series = chart.ChartData.Series[1];

// الآن يتم تعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// تعيين قيمة OverLap
series.ParentSeriesGroup.Overlap = 100;         

// كتابة العرض إلى القرص
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```