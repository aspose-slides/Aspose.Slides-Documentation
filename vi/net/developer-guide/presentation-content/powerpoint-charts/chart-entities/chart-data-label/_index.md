---
title: Quản lý nhãn dữ liệu biểu đồ trong bản trình chiếu bằng .NET
linktitle: Nhãn dữ liệu
type: docs
url: /vi/net/chart-data-label/
keywords:
- biểu đồ
- nhãn dữ liệu
- độ chính xác dữ liệu
- phần trăm
- khoảng cách nhãn
- vị trí nhãn
- PowerPoint
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách thêm và định dạng nhãn dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng Aspose.Slides for .NET để có các slide hấp dẫn hơn."
---
## **Giới thiệu**

Nhãn dữ liệu trên biểu đồ hiển thị chi tiết về chuỗi dữ liệu của biểu đồ hoặc các điểm dữ liệu riêng lẻ. Chúng giúp người đọc nhanh chóng xác định chuỗi dữ liệu và cũng làm cho biểu đồ dễ hiểu hơn.

## **Đặt độ chính xác dữ liệu trong nhãn dữ liệu biểu đồ**

Mã C# này cho bạn thấy cách đặt độ chính xác dữ liệu trong nhãn dữ liệu của biểu đồ:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
	chart.HasDataTable = true;
	chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

	pres.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
}
```

## **Hiển thị phần trăm dưới dạng nhãn**

Aspose.Slides for .NET cho phép bạn đặt nhãn phần trăm trên các biểu đồ hiển thị. Mã C# này minh họa cách thực hiện:

```c#
// Tạo một thể hiện của lớp Presentation
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

// Lưu bản trình chiếu chứa biểu đồ
presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **Đặt ký hiệu phần trăm cho nhãn dữ liệu biểu đồ**

Mã C# này cho bạn cách đặt ký hiệu phần trăm cho nhãn dữ liệu của biểu đồ:

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

// Lấy tham chiếu của slide thông qua chỉ mục của nó
ISlide slide = presentation.Slides[0];

// Tạo biểu đồ PercentsStackedColumn trên một slide
IChart chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

// Đặt NumberFormatLinkedToSource thành false
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
int defaultWorksheetIndex = 0;

// Lấy worksheet dữ liệu biểu đồ
IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

// Thêm chuỗi mới
IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.Type);
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 1, 0.30));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 1, 0.50));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 1, 0.80));
series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 1, 0.65));

// Đặt màu nền cho chuỗi
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

// Đặt các thuộc tính LabelFormat
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

// Thêm chuỗi mới
IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.Type);
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 1, 2, 0.70));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 2, 2, 0.50));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 3, 2, 0.20));
series2.DataPoints.AddDataPointForBarSeries(workbook.GetCell(defaultWorksheetIndex, 4, 2, 0.35));

// Đặt kiểu và màu nền
series2.Format.Fill.FillType = FillType.Solid;
series2.Format.Fill.SolidFillColor.Color = Color.Blue;
series2.Labels.DefaultDataLabelFormat.ShowValue = true;
series2.Labels.DefaultDataLabelFormat.IsNumberFormatLinkedToSource = false;
series2.Labels.DefaultDataLabelFormat.NumberFormat = "0.0%";
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FontHeight = 10;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
series2.Labels.DefaultDataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;

// Ghi bản trình chiếu ra đĩa
presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **Đặt khoảng cách nhãn từ trục**

Mã C# này cho bạn cách đặt khoảng cách nhãn từ trục danh mục khi bạn làm việc với biểu đồ được vẽ từ các trục:

```c#
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation();

// Lấy tham chiếu của một slide
ISlide sld = presentation.Slides[0];

// Tạo biểu đồ trên slide
IChart ch = sld.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

// Đặt khoảng cách nhãn từ một trục
ch.Axes.HorizontalAxis.LabelOffset = 500;

// Ghi bản trình chiếu ra đĩa
presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **Điều chỉnh vị trí nhãn**

Khi bạn tạo một biểu đồ không dựa vào bất kỳ trục nào như biểu đồ tròn, các nhãn dữ liệu của biểu đồ có thể quá gần mép. Trong trường hợp đó, bạn cần điều chỉnh vị trí của nhãn dữ liệu để các đường dẫn (leader lines) hiển thị rõ ràng.

Mã C# này cho bạn cách điều chỉnh vị trí nhãn trên biểu đồ tròn:

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

## **Câu hỏi thường gặp**

**Làm thế nào để ngăn các nhãn dữ liệu bị chồng lên nhau trên các biểu đồ dày đặc?**

Kết hợp việc đặt nhãn tự động, các đường dẫn và giảm kích thước phông chữ; nếu cần, ẩn một số trường (ví dụ, danh mục) hoặc chỉ hiển thị nhãn cho các điểm cực đoan/quan trọng.

**Làm thế nào để tắt nhãn chỉ cho các giá trị bằng không, âm hoặc rỗng?**

Lọc các điểm dữ liệu trước khi bật nhãn và tắt hiển thị cho các giá trị bằng 0, giá trị âm hoặc giá trị thiếu theo quy tắc đã định.

**Làm thế nào để đảm bảo kiểu nhãn nhất quán khi xuất ra PDF/hình ảnh?**

Thiết lập rõ ràng phông chữ (gia đình, kích thước) và xác minh rằng phông chữ có sẵn ở phía render để tránh việc sử dụng phông thay thế.