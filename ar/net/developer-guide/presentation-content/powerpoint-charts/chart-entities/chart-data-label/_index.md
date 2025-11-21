---
title: إدارة تسميات بيانات المخطط في العروض التقديمية في .NET
linktitle: تسمية البيانات
type: docs
url: /ar/net/chart-data-label/
keywords:
- مخطط
- تسمية بيانات
- دقة البيانات
- نسبة مئوية
- مسافة التسمية
- موقع التسمية
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية إضافة وتنسيق تسميات بيانات المخطط في عروض PowerPoint التقديمية باستخدام Aspose.Slides for .NET للحصول على شرائح أكثر جاذبية."
---

تظهر تسميات البيانات على المخطط تفاصيل حول سلسلة بيانات المخطط أو نقاط البيانات الفردية. إنها تتيح للقراء التعرف سريعًا على سلاسل البيانات وتساعد أيضًا في جعل المخططات أسهل للفهم.

## **تحديد دقة البيانات في تسميات بيانات المخطط**

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```


## **عرض النسبة المئوية كتسميات**

تسمح لك Aspose.Slides for .NET بتعيين تسميات النسبة المئوية على المخططات المعروضة. يوضح هذا الكود C# العملية:
```c#
// ينشئ كائنًا من فئة Presentation
Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);
IChartSeries series = chart.ChartData.Series[0];
IChartCategory cat;
double[] total_for_Cat = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    cat = chart.ChartData.Categories[k];

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        total_for_Cat[k] = total_for_Cat[k] + Convert.ToDouble(chart.ChartData.Series[i].DataPoints[k].Value.Data);
    }
}

double dataPontPercent = 0f;

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        IDataLabel lbl = series.DataPoints[j].Label;
        dataPontPercent = (Convert.ToDouble(series.DataPoints[j].Value.Data) / total_for_Cat[j]) * 100;

        IPortion port = new Portion();
        port.Text = String.Format("{0:F2} %", dataPontPercent);
        port.PortionFormat.FontHeight = 8f;
        lbl.TextFrameForOverriding.Text = "";
        IParagraph para = lbl.TextFrameForOverriding.Paragraphs[0];
        para.Portions.Add(port);

        lbl.DataLabelFormat.ShowSeriesName = false;
        lbl.DataLabelFormat.ShowPercentage = false;
        lbl.DataLabelFormat.ShowLegendKey = false;
        lbl.DataLabelFormat.ShowCategoryName = false;
        lbl.DataLabelFormat.ShowBubbleSize = false;
    }
}

// يحفظ العرض التقديمي الذي يحتوي على المخطط
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```


## **تعيين علامة النسبة المئوية مع تسميات بيانات المخطط**

يظهر لك هذا الكود C# كيفية تعيين علامة النسبة المئوية لتسمية بيانات المخطط:
```c#
// ينشئ نسخة من فئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع الشريحة عبر الفهرس الخاص بها
ISlide slide = presentation.Slides[0];

// ينشئ مخطط PercentsStackedColumn على شريحة
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// يضبط خاصية NumberFormatLinkedToSource إلى false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// يحصل على ورقة بيانات المخطط
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// يضيف سلسلة جديدة
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// يضبط لون تعبئة السلسلة
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// يضبط خصائص تنسيق التسمية
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// يضيف سلسلة جديدة
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// يضبط نوع التعبئة واللون
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// يكتب العرض التقديمي إلى القرص
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```


## **تحديد مسافة التسمية من المحور**

يظهر لك هذا الكود C# كيفية تعيين مسافة التسمية من محور الفئة عندما تتعامل مع مخطط مرسوم من المحاور:
```c#
// ينشئ كائنًا من فئة Presentation
Presentation presentation = new Presentation();

// يحصل على مرجع الشريحة
ISlide sld = presentation.Slides[0];

// ينشئ مخططًا على الشريحة
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// يضبط مسافة التسمية من المحور
ch.Axes.HorizontalAxis.LabelOffset = 500;

// يحفظ العرض التقديمي إلى القرص
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```


## **ضبط موقع التسمية**

عند إنشاء مخطط لا يعتمد على أي محور مثل مخطط الفطيرة، قد تكون تسميات البيانات للمخطط قريبة جدًا من حدّه. في مثل هذه الحالة، يجب ضبط موقع تسمية البيانات بحيث يتم عرض خطوط التوجيه بوضوح.

يظهر لك هذا الكود C# كيفية ضبط موقع التسمية في مخطط الفطيرة: 
```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);

    IChartSeriesCollection series = chart.ChartData.Series;
    IDataLabel label = series[0].Labels[0];

    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
    label.X = 0.71f;
    label.Y = 0.04f;

    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **الأسئلة الشائعة**

**كيف يمكنني منع تداخل تسميات البيانات في المخططات الكثيفة؟**

اجمع بين وضع التسمية التلقائي، وخطوط التوجيه، وصغر حجم الخط؛ وإذا لزم الأمر، أخفِ بعض الحقول (مثل الفئة) أو اعرض التسميات فقط للنقاط المتطرفة/الرئيسية.

**كيف يمكنني تعطيل التسميات فقط للقيم الصفرية أو السلبية أو الفارغة؟**

قم بفلترة نقاط البيانات قبل تمكين التسميات وأوقف العرض للقيم 0 أو القيم السلبية أو القيم المفقودة وفقًا لقاعدة محددة.

**كيف يمكنني ضمان نمط تسميات متسق عند التصدير إلى PDF/صور؟**

حدد الخطوط صراحة (العائلة، الحجم) وتأكد من توافر الخط على جانب العرض لتجنب fallback.