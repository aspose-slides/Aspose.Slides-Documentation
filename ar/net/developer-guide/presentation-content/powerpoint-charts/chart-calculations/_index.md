---
title: حسابات المخطط
type: docs
weight: 50
url: /ar/net/chart-calculations/
keywords: "حسابات المخطط, عناصر المخطط, موقع العنصر, قيم المخطط C#, Csharp, Aspose.Slides for .NET"
description: "حسابات وقيم مخططات PowerPoint في C# أو .NET"
---

## **حساب القيم الفعلية لعناصر المخطط**
Aspose.Slides for .NET يوفر API بسيط للحصول على هذه الخصائص. سيساعدك ذلك على حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) والقيم الفعلية للمحاور (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).
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
Aspose.Slides for .NET يوفر API بسيط للحصول على هذه الخصائص. خصائص IActualLayout توفر معلومات حول الموضع الفعلي لعنصر المخطط الأصل. من الضروري استدعاء الطريقة IChart.ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء المعلومات من المخطط**
هذا الموضوع يساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for .NET يمكنك إخفاء **العنوان**, **المحور العمودي**, **المحور الأفقي** و **خطوط الشبكة** من المخطط. مثال الشيفرة أدناه يوضح كيفية استخدام هذه الخصائص.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.HasTitle = false;

    ///إخفاء محور القيم
    chart.Axes.VerticalAxis.IsVisible = false;

    //إظهار محور الفئة
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
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelFormat.Top;
    series.Marker.Size = 15;

    //تعيين لون خط السلسلة
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل تعمل دفاتر عمل Excel الخارجية كمصدر بيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال أو تحديث المصدر الخارجي، تُؤخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التحرير. يتيح لك API [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) والمسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ التحليل الانحداري بنفسي؟**

نعم. [خطوط الاتجاه](/slides/ar/net/trend-line/) (خطية، أسية، وغيرها) تُضاف وتُحدَّث تلقائيًا بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها من بيانات السلسلة تلقائيًا، لذلك لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة مرتبطة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر العمل الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) الخاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.