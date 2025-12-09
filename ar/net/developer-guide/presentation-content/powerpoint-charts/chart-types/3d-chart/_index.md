---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية في .NET
linktitle: مخطط 3D
type: docs
url: /ar/net/3d-chart/
keywords:
- مخطط 3D
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص المخططات ثلاثية الأبعاد في Aspose.Slides for .NET، مع دعم ملفات PPT و PPTX—عزز عروضك التقديمية اليوم."
---

## **تعيين خصائص RotationX و RotationY و DepthPercents للمخطط ثلاثي الأبعاد**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة لتعيين هذه الخصائص. سيساعدك المقال التالي في كيفية تعيين خصائص مختلفة مثل دوران X و Y، **DepthPercents** وغيرها. يوضح رمز العينة كيفية تطبيق تعيين الخصائص المذكورة أعلاه.

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. تعيين خصائص Rotation3D.
5. كتابة العرض المعدل إلى ملف PPTX.
```c#
// إنشاء مثيل للفئة Presentation
Presentation presentation = new Presentation();
           
// الوصول إلى الشريحة الأولى
ISlide slide = presentation.Slides[0];

// إضافة مخطط ببيانات افتراضية
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

// تعيين فهرس ورقة بيانات المخطط
int defaultWorksheetIndex = 0;

// الحصول على ورقة بيانات المخطط
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

// أخذ سلسلة المخطط الثانية
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

// كتابة العرض التقديمي إلى القرص
presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**ما أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides إصدارات 3D من مخططات الأعمدة، بما في ذلك Column 3D و Clustered Column 3D و Stacked Column 3D و 100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية الأبعاد المرتبطة المعروضة عبر تعداد [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). للحصول على قائمة دقيقة ومحدثة، يرجى التحقق من أعضاء [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) في مرجع API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط 3D لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [chart API](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) أو [render the entire slide](/slides/ar/net/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة دقيقة بالبكسل أو ترغب في تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى كفاءة بناء وتصيير مخططات 3D الكبيرة؟**

تعتمد الأداء على حجم البيانات وتعقيد التصوير البصري. للحصول على أفضل النتائج، حافظ على تقليل تأثيرات 3D، تجنب الخامات الثقيلة على الجدران ومساحات الرسم، قلل عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالتصيير إلى مخرجات بحجم مناسب (الدقة والأبعاد) لتطابق شاشة العرض المستهدفة أو احتياجات الطباعة.