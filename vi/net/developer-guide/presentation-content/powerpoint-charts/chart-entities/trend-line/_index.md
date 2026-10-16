---
title: Thêm Đường Xu Hướng vào Biểu Đồ Trình Chiếu trong .NET
linktitle: Đường Xu Hướng
type: docs
url: /vi/net/trend-line/
keywords:
- biểu đồ
- đường xu hướng
- đường xu hướng hàm mũ
- đường xu hướng tuyến tính
- đường xu hướng logarit
- đường xu hướng trung bình động
- đường xu hướng đa thức
- đường xu hướng lũy thừa
- đường xu hướng tùy chỉnh
- PowerPoint
- trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh các đường xu hướng trong biểu đồ PowerPoint với Aspose.Slides cho .NET — một hướng dẫn thực tế để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm các đường xu hướng vào biểu đồ trình chiếu bằng cách sử dụng Aspose.Slides. Nó trình bày cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường, và bao gồm một phần FAQ ngắn về giá trị chiếu tiến và lùi của đường xu hướng và liệu các đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ thành hình ảnh hay không.

## **Thêm Đường Xu Hướng**

Sử dụng [ITrendlineCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendlinecollection/add/) để thêm một đường xu hướng vào một chuỗi biểu đồ, chọn loại của nó bằng [TrendlineType](https://reference.aspose.com/slides/net/aspose.slides.charts/trendlinetype/). Ví dụ tạo một biểu đồ cột nhóm với dữ liệu mặc định và thêm hai đường xu hướng vào mỗi ba chuỗi của nó.

Đường xu hướng hàm mũ ẩn phương trình và giá trị R‑bình phương thông qua [DisplayEquation](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayequation/) và [DisplayRSquaredValue](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/displayrsquaredvalue/), trong khi đường xu hướng tuyến tính có màu đỏ. Đường xu hướng logarit sử dụng [AddTextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/addtextframeforoverriding/) để đặt nhãn tùy chỉnh. Trung bình động sử dụng một [Period](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/period/) gồm ba điểm dữ liệu và một [TrendlineName](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/trendlinename/) tùy chỉnh.

Đường xu hướng đa thức có một [Order](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/order/) là ba và mở rộng một danh mục về phía trước thông qua [Forward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/forward/). Đường xu hướng lũy thừa mở rộng một danh mục về phía sau thông qua [Backward](https://reference.aspose.com/slides/net/aspose.slides.charts/itrendline/backward/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

var firstSeries = chart.ChartData.Series[0];

var exponentialTrendline = firstSeries.TrendLines.Add(TrendlineType.Exponential);
exponentialTrendline.DisplayEquation = false;
exponentialTrendline.DisplayRSquaredValue = false;

var linearTrendline = firstSeries.TrendLines.Add(TrendlineType.Linear);
linearTrendline.Format.Line.FillFormat.FillType = FillType.Solid;
linearTrendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

var secondSeries = chart.ChartData.Series[1];

var logarithmicTrendline = secondSeries.TrendLines.Add(TrendlineType.Logarithmic);
logarithmicTrendline.AddTextFrameForOverriding("New log trend line");

var movingAverageTrendline = secondSeries.TrendLines.Add(TrendlineType.MovingAverage);
movingAverageTrendline.Period = 3;
movingAverageTrendline.TrendlineName = "New TrendLine Name";

var thirdSeries = chart.ChartData.Series[2];

var polynomialTrendline = thirdSeries.TrendLines.Add(TrendlineType.Polynomial);
polynomialTrendline.Forward = 1;
polynomialTrendline.Order = 3;

var powerTrendline = thirdSeries.TrendLines.Add(TrendlineType.Power);
powerTrendline.Backward = 1;

presentation.Save("ChartTrendLines.pptx", SaveFormat.Pptx);
```

## **Đặt Điểm Giao Đường Xu Hướng**

Sử dụng [Intercept](https://reference.aspose.com/slides/net/aspose.slides.charts/trendline/intercept/) để cố định giá trị Y của đường xu hướng tại X = 0. Cài đặt này được hỗ trợ cho các đường xu hướng tuyến tính, hàm mũ và đa thức.

Ví dụ, mô hình chi phí sản xuất có thể cần bắt đầu ở chi phí cố định đã biết là 100, ngay cả khi các đo lường ở khối lượng sản xuất khác không gợi ý một mức cơ sở khác. Đối với đường xu hướng tuyến tính, cố định điểm giao sẽ ràng buộc phương trình `y = ax + b` thành `b = 100`; độ dốc sẽ được điều chỉnh dựa trên dữ liệu dưới ràng buộc đó. Nó không chỉ di chuyển một đường đã được điều chỉnh sẵn. Cài đặt giao cắt trục kiểm soát nơi các trục biểu đồ gặp nhau, không phải các hệ số của đường xu hướng đã điều chỉnh.

Ví dụ sau tạo một biểu đồ phân tán (XY) với khối lượng sản xuất từ 1 đến 4 và chi phí là 170, 200, 230 và 260. Nó lưu biểu đồ với điểm giao tự động mặc định, đặt điểm giao thành 100 và lưu một PPTX thứ hai. Hai tệp chỉ khác nhau ở cài đặt điểm giao. Đường xu hướng hiển thị phương trình và mở rộng về phía X = 0.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var nameCell = workbook.GetCell(0, 0, 1, "Production cost");
var series = chart.ChartData.Series.Add(nameCell, ChartType.ScatterWithMarkers);
double[] costs = { 170, 200, 230, 260 };

for (var i = 0; i < costs.Length; i++)
{
    var xCell = workbook.GetCell(0, i + 1, 0, i + 1);
    var yCell = workbook.GetCell(0, i + 1, 1, costs[i]);
    series.DataPoints.AddDataPointForScatterSeries(xCell, yCell);
}

var trendline = series.TrendLines.Add(TrendlineType.Linear);
trendline.DisplayEquation = true;
trendline.Backward = 1;

presentation.Save("AutomaticIntercept.pptx", SaveFormat.Pptx);

trendline.Intercept = 100;
presentation.Save("FixedIntercept.pptx", SaveFormat.Pptx);
```

Với tính toán tự động, các dữ liệu này cho ra `y = 30x + 140`. Đặt điểm giao thành 100 thay vào đó cho ra khoảng `y = 43.33x + 100`: giá trị điều chỉnh tại điểm zero khớp với mức cơ sở đã biết, trong khi đường không còn đi qua mọi điểm dữ liệu nữa.

| Điểm giao tự động | Điểm giao cố định 100 |
| --- | --- |
| ![Đường xu hướng tuyến tính với điểm giao được tính tự động là 140](intercept-automatic.png) | ![Đường xu hướng tuyến tính với điểm giao cố định là 100](intercept-fixed.png) |

Cả hai hình ảnh đều sử dụng cùng một dữ liệu và tỉ lệ trục. Các đường xu hướng được mở rộng lại đến X = 0 để hiển thị điểm giao của chúng.

Mặc định, thuộc tính chứa `double.NaN`, đại diện cho một điểm giao không xác định thay vì bằng zero. Khi đó điểm giao sẽ được tính tự động từ dữ liệu.

## **Thêm Đường Tùy Chỉnh**

Một đường tùy chỉnh là một hình dạng được vẽ lên trên biểu đồ thay vì một đường xu hướng được tính từ dữ liệu chuỗi. Ví dụ này sử dụng [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) để thêm một đường ngang vào slide trên biểu đồ. Vị trí của đường được chỉ định bằng tọa độ slide, đo bằng điểm, vì vậy nó bắt đầu ở mép trái của biểu đồ và nằm giữa chiều cao của biểu đồ. Chiều rộng của nó khớp với chiều rộng của biểu đồ. [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) cho đường màu đỏ đặc.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

var line = slide.Shapes.AddAutoShape(ShapeType.Line, chart.X, chart.Y + chart.Height / 2, chart.Width, 0);
line.LineFormat.FillFormat.FillType = FillType.Solid;
line.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("AddCustomLines.pptx", SaveFormat.Pptx);
```

## **Câu Hỏi Thường Gặp**

**'Tiến' và 'Lùi' có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu tiến hoặc lùi: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Đường xu hướng có được giữ lại khi xuất bản trình chiếu sang PDF hoặc SVG, hoặc khi render slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình chiếu sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/) hoặc [SVG](/slides/vi/net/render-a-slide-as-an-svg-image/) và render các biểu đồ thành hình ảnh; các đường xu hướng, như một phần của biểu đồ, được giữ lại trong các hoạt động này. Một phương pháp cũng có sẵn để [export an image of the chart](/slides/vi/net/create-shape-thumbnails/) riêng biệt.