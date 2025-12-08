---
title: علامة بيانات المخطط
type: docs
url: /ar/net/chart-data-marker/
keywords:
- خيارات علامة المخطط
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "ضبط خيارات علامة المخطط في عروض تقديمية PowerPoint باستخدام C# أو .NET"
---

## **تعيين خيارات علامة المخطط**
يمكن تعيين العلامات على نقاط بيانات المخطط داخل السلاسل المحددة. لضبط خيارات علامة المخطط، يرجى اتباع الخطوات أدناه:

- إنشاء فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- إنشاء المخطط الافتراضي.
- تعيين الصورة.
- الحصول على أول سلسلة مخطط.
- إضافة نقطة بيانات جديدة.
- كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين خيارات علامة المخطط على مستوى نقاط البيانات.
```c#
// إنشاء كائن من فئة Presentation
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// إنشاء المخطط الافتراضي
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// الحصول على فهرس ورقة عمل بيانات المخطط الافتراضية
int defaultWorksheetIndex = 0;

// الحصول على ورقة عمل بيانات المخطط
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// حذف سلسلة العرض التجريبي
chart.ChartData.Series.Clear();

// إضافة سلسلة جديدة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// تعيين الصورة
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// تعيين الصورة
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// أخذ أول سلسلة مخطط
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

// تغيير علامة سلسلة المخطط
series.Marker.Size = 15;

// حفظ العرض التقديمي إلى القرص
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**ما هي أشكال العلامات المتوفرة بشكل افتراضي؟**

الأشكال القياسية متوفرة (دائرة، مربع، ماسي، مثلث، إلخ)؛ يتم تعريف القائمة بواسطة تعداد [MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/). إذا كنت بحاجة إلى شكل غير قياسي، استخدم علامة مع تعبئة صورة لمحاكاة الرسوم المخصصة.

**هل يتم الحفاظ على العلامات عند تصدير المخطط إلى صورة أو SVG؟**

نعم. عند عرض المخططات إلى [raster formats](/slides/ar/net/convert-powerpoint-to-png/) أو حفظ [shapes as SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، تحتفظ العلامات بمظهرها وإعداداتها، بما في ذلك الحجم، التعبئة، والحدود.