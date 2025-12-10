---
title: تحسين حسابات المخطط للعروض التقديمية في .NET
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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "فهم حسابات المخطط، تحديثات البيانات، والتحكم في الدقة في Aspose.Slides لـ .NET للعروض PPT و PPTX، مع أمثلة عملية على كود C#."
---

## **احسب القيم الفعلية لعناصر المخطط**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. سيساعدك هذا في حساب القيم الفعلية لعناصر المخطط. تشمل القيم الفعلية موضع العناصر التي تنفذ واجهة IActualLayout (IActualLayout.ActualX، IActualLayout.ActualY، IActualLayout.ActualWidth، IActualLayout.ActualHeight) وقيم المحاور الفعلية (IAxis.ActualMaxValue، IAxis.ActualMinValue، IAxis.ActualMajorUnit، IAxis.ActualMinorUnit، IAxis.ActualMajorUnitScale، IAxis.ActualMinorUnitScale).
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


## **احسب الموضع الفعلي لعناصر المخطط الأصلية**
توفر Aspose.Slides for .NET واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص IActualLayout معلومات حول الموضع الفعلي لعنصر المخطط الأصل. من الضروري استدعاء الطريقة IChart.ValidateChartLayout() مسبقًا لملء الخصائص بالقيم الفعلية.
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


## **إخفاء عناصر المخطط**
يساعدك هذا الموضوع على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for .NET يمكنك إخفاء **العنوان، المحور الرأسي، المحور الأفقي** و**خطوط الشبكة** من المخطط. يوضح مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    // إخفاء عنوان المخطط
    chart.HasTitle = false;

    /// إخفاء محور القيم
    chart.Axes.VerticalAxis.IsVisible = false;

    // إخفاء محور الفئات
    chart.Axes.HorizontalAxis.IsVisible = false;

    // إخفاء وسيلة الإيضاح
    chart.HasLegend = false;

    // إخفاء خطوط الشبكة الرئيسية
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

    // ضبط لون خط السلسلة
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**هل تعمل دفاتر عمل Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال أو تحديث المصدر الخارجي، يتم أخذ الصيغ والقيم من ذلك الدفتر، ويعكس المخطط التحديثات أثناء عمليات الفتح/التعديل. تسمح لك الواجهة البرمجية [بتحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/) والمسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. تُضاف [خطوط الاتجاه](/slides/ar/net/trend-line/) (الخطية، الأسية، وغيرها) وتُحدّثها Aspose.Slides؛ تُعاد حساب معلماتها تلقائيًا من بيانات السلسلة، لذلك لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة مع روابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setexternalworkbook/)، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.