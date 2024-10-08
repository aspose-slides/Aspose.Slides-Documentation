---
title: علامة بيانات الرسم البياني
type: docs
url: /ar/net/chart-data-marker/
keywords:
- خيارات علامات الرسم البياني
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "قم بتعيين خيارات علامة الرسم البياني في عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **تعيين خيارات علامة الرسم البياني**
يمكن تعيين العلامات على نقاط بيانات الرسم البياني داخل سلسلة معينة. لتعيين خيارات علامة الرسم البياني، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إنشاء الرسم البياني الافتراضي.
- تعيين الصورة.
- أخذ أول سلسلة رسم بياني.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي على القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامة الرسم البياني على مستوى نقاط البيانات.

```c#
// إنشاء مثيل من فئة Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// إنشاء الرسم البياني الافتراضي
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// الحصول على فهرس ورقة البيانات الافتراضية للرسم البياني
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات الرسم البياني
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// حذف سلسلة العرض التوضيحي
chart.ChartData.Series.Clear();

// إضافة سلسلة جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// تعيين الصورة
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// تعيين الصورة
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// أخذ أول سلسلة رسم بياني
IChartSeries series = chart.ChartData.Series[0];

// إضافة نقطة جديدة (1:3) هناك.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// تغيير علامة سلسلة الرسم البياني
series.Marker.Size = 15;

// كتابة العرض التقديمي على القرص
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```