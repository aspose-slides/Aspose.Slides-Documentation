---
title: حسابات المخطط
type: docs
weight: 50
url: /ar/net/chart-calculations/
keywords: "حسابات المخطط، عناصر المخطط، موضع العنصر، قيم المخطط C#، Csharp، Aspose.Slides لـ .NET"
description: "حسابات وقيم مخطط PowerPoint في C# أو .NET"
---

## **احسب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك ذلك في حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX، IActualLayout.ActualY، IActualLayout.ActualWidth، IActualLayout.ActualHeight) والقيم الفعلية للمحاور (IAxis.ActualMaxValue، IAxis.ActualMinValue، IAxis.ActualMajorUnit، IAxis.ActualMinorUnit، IAxis.ActualMajorUnitScale، IAxis.ActualMinorUnitScale).

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



## **احسب موضع العناصر الأصلية في المخطط**
توفر Aspose.Slides لـ .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص IActualLayout معلومات حول الموضع الفعلي للعناصر الأصلية في المخطط. من الضروري استدعاء الطريقة IChart.ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.

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
تساعدك هذه الصفحة على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides لـ .NET يمكنك إخفاء **العنوان، المحور العمودي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يوضح المثال البرمجي أدناه كيفية استخدام هذه الخصائص.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //إخفاء عنوان المخطط
    chart.HasTitle = false;

    //إخفاء محور القيم
    chart.Axes.VerticalAxis.IsVisible = false;

    //رؤية محور الفئات
    chart.Axes.HorizontalAxis.IsVisible = false;

    //إخفاء الأسطورة
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