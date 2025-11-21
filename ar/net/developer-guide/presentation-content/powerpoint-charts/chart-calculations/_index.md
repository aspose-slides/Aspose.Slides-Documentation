---
title: تحسين حسابات المخططات للعرض التقديمي في .NET
linktitle: حسابات المخطط
type: docs
weight: 50
url: /ar/net/chart-calculations/
keywords:
- حسابات المخطط
- عناصر المخطط
- موضع العنصر
- الموضع الفعلي
- العنصر الفرعي
- العنصر الأصلي
- قيم المخطط
- القيمة الفعلية
- PowerPoint
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "فهم حسابات المخططات وتحديثات البيانات والتحكم في الدقة في Aspose.Slides for .NET لملفات PPT و PPTX، مع أمثلة عملية على كود C#."
---

## **حساب القيم الفعلية لعناصر المخطط**
Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك ذلك على حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) والقيم الفعلية للمحاور (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// حفظ العرض التقديمي
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```


## **حساب الموضع الفعلي لعناصر المخطط الأصلية**
Aspose.Slides for .NET يوفر واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص IActualLayout معلومات حول الموضع الفعلي لعنصر المخطط الأصلي. من الضروري استدعاء الطريقة IChart.ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.
```c#
// إنشاء عرض تقديمي فارغ
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```


## **إخفاء معلومات من المخطط**
هذا القسم يساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for .NET يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.HasTitle = false;

    ///إخفاء محور القيم
    chart.Axes.VerticalAxis.IsVisible = false;

    //إظهار محور الفئات
    chart.Axes.HorizontalAxis.IsVisible = false;

    //إخفاء وسيلة الإيضاح
    chart.HasLegend = false;

    //إخفاء خطوط الشبكة الرئيسية
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //تعيين لون خط السلسلة
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**هل تعمل دفاتر Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عندما تقوم بالاتصال أو تحديث المصدر الخارجي، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويتعكس المخططم في التحديثات أثناء عمليات الفتح/التعديل. تتيح الواجهة برمجة التطبيقات لك [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) المسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. [خطوط الاتجاه](/slides/ar/net/trend-line/) (خطية، أسية، وغيرها) تُضاف وتُحدَّث بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها من بيانات السلسلة تلقائيًا، لذلك لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر العمل الخارجي]https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/ الخاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.