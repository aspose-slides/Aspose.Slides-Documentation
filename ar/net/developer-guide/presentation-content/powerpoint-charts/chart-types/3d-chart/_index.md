---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية في .NET
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/net/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides لـ .NET، مع دعم ملفات PPT و PPTX—عزز عروضك التقديمية اليوم."
---

## **تعيين خصائص RotationX و RotationY و DepthPercents لمخطط ثلاثي الأبعاد**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك هذا المقال التالي على كيفية تعيين خصائص مختلفة مثل دوران X و Y و **DepthPercents** وغيرها. يوضح الكود النموذجي كيفية تعيين الخصائص المذكورة أعلاه.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط مع البيانات الافتراضية.
1. تعيين خصائص Rotation3D.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.
```c#
// إنشاء نسخة من فئة Presentation
Presentation presentation = new Presentation();
           
// الوصول إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// إضافة مخطط بالبيانات الافتراضية
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

// الحصول على ورقة عمل بيانات المخطط
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// إضافة سلسلة
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

// إضافة الفئات
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

// تعيين خصائص Rotation3D
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

// أخذ السلسلة الثانية للمخطط
IChartSeries series = chart.ChartData.Series[1];

// الآن تعبئة بيانات السلسلة
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

// تعيين قيمة OverLap
series.ParentSeriesGroup.Overlap = 100;         

// كتابة العرض التقديمي إلى القرص
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **الأسئلة المتكررة**

**ما أنواع المخططات التي تدعم وضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides أنواع المخططات العمودية الثلاثية الأبعاد، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد ذات الصلة التي يتم التعرض لها من خلال تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو [تحويل الشريحة بالكامل](/slides/ar/net/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة بدقة البكسل أو تريد تضمين المخطط في مستندات أو لوحات تحكم أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

تعتمد الكفاءة على حجم البيانات وتعقيد الشكل البصري. للحصول على أفضل النتائج، حافظ على الحد الأدنى من التأثيرات الثلاثية الأبعاد، تجنب القوام الثقيلة على الجدران ومناطق الرسم، قلل عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالتصيير إلى حجم إخراج مناسب (الدقة والأبعاد) ليتطابق مع شاشة العرض أو متطلبات الطباعة.