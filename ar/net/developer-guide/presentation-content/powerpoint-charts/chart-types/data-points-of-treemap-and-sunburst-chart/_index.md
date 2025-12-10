---
title: تخصيص نقاط البيانات في مخططات شجرة الخرائط ومخططات شمسية في .NET
linktitle: نقاط البيانات في مخططات شجرة الخرائط ومخططات شمسية
type: docs
url: /ar/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- مخطط شجرة الخرائط
- مخطط شمسية
- نقطة البيانات
- لون التسمية
- لون الفرع
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إدارة نقاط البيانات في مخططات شجرة الخرائط ومخططات شمسية باستخدام Aspose.Slides for .NET، متوافق مع تنسيقات PowerPoint."
---

بالإضافة إلى أنواع أخرى من مخططات PowerPoint، هناك نوعان "هرميان" - **Treemap** و **Sunburst** (المعروف أيضًا باسم مخطط Sunburst أو رسم تخطيطي Sunburst، مخطط قطري، رسم قطري أو مخطط فطيرة متعدد المستويات). هذه المخططات تعرض بيانات هرمية منظمة كشجرة - من الأوراق إلى قمة الفرع. يتم تعريف الأوراق بنقاط بيانات السلسلة، وكل مستوى تجميع متداخل لاحق يُحدد بواسطة الفئة المقابلة. يتيح Aspose.Slides for .NET تنسيق نقاط بيانات مخطط Sunburst و Treemap في C#.

فيما يلي مخطط Sunburst، حيث تحدد البيانات في عمود Series1 عقد الأوراق، بينما تحدد الأعمدة الأخرى نقاط البيانات الهرمية:
![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

دعنا نبدأ بإضافة مخطط Sunburst جديد إلى العرض التقديمي:
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    // ...
}
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [**إنشاء مخطط Sunburst**](/slides/ar/net/adding-charts/#addingcharts-creatingsunburstchart)
{{% /alert %}}

إذا كان هناك حاجة لتنسيق نقاط البيانات في المخطط، يجب علينا استخدام ما يلي:
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager)،
[IChartDataPointLevel](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel) الفئات و[**IChartDataPoint.DataPointLevels**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/properties/datapointlevels) الخاصية توفر إمكانية الوصول لتنسيق نقاط البيانات في مخططات Treemap و Sunburst.

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevelsManager) يُستخدم للوصول إلى الفئات متعددة المستويات - وهو يمثل حاوية كائنات [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel). أساسًا هو غلاف لـ [**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartCategoryLevelsManager) مع الخصائص المضافة الخاصة بنقاط البيانات.

فئة [**IChartDataPointLevel**](https://reference.aspose.com/slides/net/aspose.slides.charts/IChartDataPointLevel) لديها خاصيتان: [**Format**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/format) و[**DataLabel**](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointlevel/properties/label) التي توفر الوصول إلى الإعدادات المقابلة.

## **إظهار قيمة نقطة البيانات**
إظهار قيمة نقطة البيانات "Leaf 4":
```c#
IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;
dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **تعيين تسمية ولون نقطة البيانات**
قم بتعيين تسمية بيانات "Branch 1" لعرض اسم السلسلة ("Series1") بدلاً من اسم الفئة. ثم اضبط لون النص إلى الأصفر:
```c#
IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
branch1Label.DataLabelFormat.ShowCategoryName = false;
branch1Label.DataLabelFormat.ShowSeriesName = true;

branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
```


![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **تعيين لون فرع نقطة البيانات**
تغيير لون فرع "Stem 4":
```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Sunburst, 100, 100, 450, 400);
    
    IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

    IChartDataPointLevel stem4branch = dataPoints[9].DataPointLevels[1];
    
    stem4branch.Format.Fill.FillType = FillType.Solid;
    stem4branch.Format.Fill.SolidFillColor.Color = Color.Red;
      
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **الأسئلة المتداولة**

**هل يمكنني تغيير ترتيب (فرز) الأقسام في Sunburst/Treemap؟**  
لا. يقوم PowerPoint بفرز الأقسام تلقائيًا (عادةً بالقيم المتناقصة وبالاتجاه العقرب). يطابق Aspose.Slides هذا السلوك: لا يمكنك تغيير الترتيب مباشرة؛ يمكنك تحقيق ذلك عن طريق معالجة البيانات مسبقًا.

**كيف يؤثر موضوع العرض التقديمي على ألوان الأقسام والتسميات؟**  
ترث ألوان المخطط [theme/palette](/slides/ar/net/presentation-theme/) للعرض ما لم تقم بتحديد التعبئات/الخطوط صراحة. للحصول على نتائج متسقة، احرص على تثبيت التعبئات الصلبة وتنسيق النص في المستويات المطلوبة.

**هل سيحافظ التصدير إلى PDF/PNG على ألوان الفروع المخصصة وإعدادات التسميات؟**  
نعم. عند تصدير العرض التقديمي، يتم الاحتفاظ بإعدادات المخطط (التعبئات، التسميات) في صيغ الإخراج لأن Aspose.Slides يقوم بتصوير المخطط باستخدام التنسيق المطبق.

**هل يمكنني حساب الإحداثيات الفعلية لتسمية/عنصر لوضع تغطية مخصصة أعلى المخطط؟**  
نعم. بعد التحقق من تخطيط المخطط، تكون الخاصيتان `ActualX`/`ActualY` متاحتين للعناصر (على سبيل المثال، [DataLabel](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabel/))، مما يساعد في تحديد المواقع بدقة للتغطيّات.