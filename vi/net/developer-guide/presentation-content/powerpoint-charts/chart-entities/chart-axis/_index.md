---
title: Tùy chỉnh Trục Biểu đồ trong Bản trình bày .NET
linktitle: Trục Biểu đồ
type: docs
url: /vi/net/chart-axis/
keywords:
- trục biểu đồ
- trục dọc
- trục ngang
- tùy chỉnh trục
- thao tác trục
- quản lý trục
- thuộc tính trục
- giá trị tối đa
- giá trị tối thiểu
- đường trục
- định dạng ngày
- tiêu đề trục
- vị trí trục
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách sử dụng Aspose.Slides cho .NET để tùy chỉnh trục biểu đồ trong các bản trình bày PowerPoint cho báo cáo và trực quan hoá."
---
## **Tổng quan**

Bài viết này giải thích cách tùy chỉnh trục biểu đồ với Aspose.Slides for .NET. Nó bao gồm các giá trị trục đã tính toán, chuyển đổi hàng và cột của biểu đồ, hiển thị trục, khoảng nhãn danh mục và khoảng cách các dấu tick, danh mục ngày và định dạng, xoay tiêu đề, vị trí trục, đơn vị hiển thị và tỷ lệ logarit.

## **Lấy Giá Trị Tối Đa Trên Trục Dọc Trong Biểu Đồ**

Tạo một [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) và thêm một biểu đồ khu vực với dữ liệu mặc định. Gọi [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) trước khi đọc các giá trị trục đã tính toán để bố cục biểu đồ được cập nhật.

Đọc [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) và [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) để lấy giới hạn của trục, và [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) và [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) để lấy khoảng cách các dấu tick. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) và [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) cung cấp các thang thời gian, có liên quan đến trục ngày. Ví dụ lưu các giá trị này vào biến cục bộ và lưu biểu đồ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **Hoán Đổi Dữ Liệu Giữa Các Trục**

Sử dụng [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) để hoán đổi vai trò của series và category trong dữ liệu biểu đồ. Mỗi category cũ trở thành một series, và mỗi series cũ trở thành một category. Điều này thay đổi cách nhóm dữ liệu; nó không hoán đổi các trục ngang và dọc. Ví dụ sử dụng [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) để liên kết dữ liệu mặc định với `Sheet1!A1:D5`, bao gồm hàng tiêu đề và cột category, trước khi hoán đổi hàng và cột. Nó lưu một biểu đồ với bốn series và ba category.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **Đảo Ngược Thứ Tự Vẽ Của Một Trục**

Sử dụng [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) để đảo ngược một trục category hoặc value. Ví dụ, một biểu đồ thanh ngang có thể hiển thị các giai đoạn dự án từ trên xuống dưới theo cùng thứ tự với bảng tính: Planning, Development, Testing. Đảo ngược một trục thay đổi hướng vẽ; nó không sắp xếp hay sắp lại dữ liệu trong workbook. So sánh với [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) thì phương pháp này hoán đổi vai trò của series và category.

Ví dụ dưới đây tạo một biểu đồ thanh ngang với ba giai đoạn và một series. Nó lưu một bản trình bày với ba slide: thứ tự bình thường, category đảo ngược, và giá trị đảo ngược. Mỗi bản sao sử dụng cùng một bộ dữ liệu, và mỗi bản chỉ đảo ngược một trục.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// Slide 2: hiển thị danh mục đầu tiên ở trên cùng.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// Giữ trục giá trị ngang ở phía dưới.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// Slide 3: đảo ngược chỉ thang số ngang.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

Đảo ngược một trục cũng có thể di chuyển trục vuông góc sang phía đối diện của biểu đồ. [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) kiểm soát vị trí mà trục còn lại cắt qua trục đang cấu hình. Trong slide 2, đặt giá trị này thành `Maximum` trên trục category đã đảo ngược giữ cho trục value ngang ở phía dưới. Để chỉ định một điểm giao cụ thể, hãy sử dụng [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Kiểm tra cài đặt giao điểm khi thay đổi hướng, đặc biệt nếu biểu đồ đã có điểm giao tùy chỉnh. Đặt lại `IsPlotOrderReversed` về `false` để khôi phục hướng vẽ bình thường; cài đặt giao điểm là riêng biệt.

| Thứ tự bình thường (slide 1) | Category đảo ngược (slide 2) | Giá trị đảo ngược (slide 3) |
| --- | --- | --- |
| ![Biểu đồ thanh ngang với thứ tự trục category và value bình thường](axis-order-normal.png) | ![Biểu đồ thanh ngang với category hiển thị từ trên xuống dưới](axis-order-categories-reversed.png) | ![Biểu đồ thanh ngang với trục value đảo ngược và zero ở bên phải](axis-order-values-reversed.png) |
| Category chạy từ dưới lên trên; values tăng từ trái sang phải. | Planning, Development, và Testing chạy từ trên xuống dưới. Values và thứ tự hàng workbook không thay đổi. | Category giữ nguyên thứ tự; values tăng từ phải sang trái. Trục category cắt tại zero ở bên phải. |

## **Vô hiệu hoá Trục Dọc cho Biểu Đồ Đường**

Đặt [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) thành `false` trên trục dọc để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục dọc bị ẩn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **Vô hiệu hoá Trục Ngang cho Biểu Đồ Đường**

Đặt [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) thành `false` trên trục ngang để ẩn nó. Ví dụ tạo một biểu đồ đường với dữ liệu mặc định và lưu nó với trục ngang bị ẩn.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **Thay Đổi Trục Danh Mục**

Đặt [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) để chọn một trục ngày hoặc văn bản. Ví dụ này yêu cầu `ExistingChart.pptx`, với một biểu đồ là shape đầu tiên trên slide đầu và các ô category chứa giá trị ngày Excel dạng số. Nó thay đổi trục ngang thành trục ngày. Đặt [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) thành `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) thành `1`, và [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) thành months để đặt các tick lớn ở khoảng một tháng.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

## **Kiểm Soát Khoảng Nhãn Trục Danh Mục**

Khi một biểu đồ có nhiều category, giảm số lượng nhãn trục hiển thị mà không loại bỏ các category hoặc điểm dữ liệu. Đặt [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) thành `false`, sau đó đặt [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) thành khoảng cách category mong muốn. Đối với các category văn bản theo thứ tự bình thường, việc đếm bắt đầu từ category đầu tiên:

| Khoảng cách | Nhãn hiển thị trong ví dụ |
| --- | --- |
| `1` | Danh mục 1, Danh mục 2, Danh mục 3, … Danh mục 24 |
| `2` | Danh mục 1, Danh mục 3, Danh mục 5, … Danh mục 23 |
| `3` | Danh mục 1, Danh mục 4, Danh mục 7, … Danh mục 22 |

Khoảng cách `3` hiển thị mỗi nhãn thứ ba, để lại hai nhãn ẩn giữa các nhãn hiển thị. Nó không loại bỏ các cột tương ứng. Khoảng cách tự động chọn một khoảng dựa trên không gian có sẵn; nó không nhất thiết hiển thị mọi nhãn.

Dấu tick có các điều khiển riêng. Đặt [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) thành `false` và sử dụng [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) để đặt khoảng cách của chúng. Ví dụ, `1` giữ một dấu tick ở mỗi khoảng category trong khi nhãn chỉ xuất hiện mỗi category thứ ba. Đặt [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) thành kiểu hiển thị để bạn có thể thấy kết quả. Đặt lại bất kỳ thuộc tính tự động‑spacing nào về `true` cho phép biểu đồ chọn lại khoảng đó.

Ví dụ tự chứa dưới đây tạo 24 category và một series, sau đó lưu ba slide trong `CategoryAxisIntervals.pptx`: khoảng cách tự động, khoảng cách nhãn thủ công với dấu tick độc lập, và khôi phục khoảng cách tự động. Hai bản sao giữ nguyên dữ liệu biểu đồ gốc. Không cần bản trình bày đầu vào. Văn bản nhãn ngang làm cho sự khác biệt về mật độ dễ thấy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// Slide 2: hiển thị mỗi nhãn thứ ba, nhưng vẫn giữ một dấu tick cho mỗi danh mục.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// Slide 3: cho phép biểu đồ chọn lại cả hai khoảng cách.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**Automatic spacing (slide 1):** Trong bản hiển thị này, mỗi nhãn category thứ hai được hiển thị và xuống hai dòng. Kết quả tự động có thể thay đổi tùy theo kích thước biểu đồ, phông chữ và bộ render.

![Khoảng cách nhãn category tự động với tất cả 24 cột hiển thị](category-axis-automatic.png)

**Manual spacing (slide 2):** Mỗi nhãn thứ ba được hiển thị trên một dòng, trong khi dấu tick vẫn ở mỗi khoảng category. Tất cả 24 cột, bao gồm cả những cột không có nhãn, vẫn hiển thị với cùng giá trị. Slide 3 khôi phục giao diện tự động như trên.

![Khoảng cách nhãn category thủ công với ba và tất cả 24 cột hiển thị](category-axis-manual.png)

### **Chọn Trục và Khoảng Thích Hợp**

Sử dụng khoảng cách đếm category này cho một trục category dạng văn bản, chẳng hạn trục category của biểu đồ cột, đường, khu vực hoặc thanh. Trong biểu đồ cột, nó là trục ngang. Trong biểu đồ thanh ngang, trục category là trục dọc, vì vậy áp dụng các cài đặt này cho [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Khoảng cách dấu tick cũng áp dụng cho trục series trong các biểu đồ có trục series.

Không sử dụng khoảng cách nhãn category để đặt thang số cho trục value. Trên trục value, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) xác định sự khác biệt về giá trị: ví dụ, một major unit là `10` sẽ tạo các tick tại 0, 10, 20, … khi trục bắt đầu từ zero. Khoảng cách nhãn category `3` thay vào đó đếm vị trí category, bất kể giá trị dữ liệu của chúng. Các biểu đồ scatter và bubble sử dụng trục value thay vì trục category dạng văn bản. Đối với trục ngày, hãy sử dụng các đơn vị và thang thời gian như mô tả trong [Change a Category Axis](#change-a-category-axis).

## **Đặt Định Dạng Ngày cho Giá Trị Trục Danh Mục**

Ví dụ thay thế dữ liệu biểu đồ mặc định bằng bốn giá trị hàng năm. Ngày được lưu dưới dạng số serial OLE Automation trong worksheet đầu tiên (chỉ số `0`). Đặt [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) thành trục ngày, tắt [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), và gán `yyyy` cho [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) để nhãn category hiển thị năm bốn chữ số độc lập với định dạng ô.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **Đặt Góc Xoay cho Tiêu Đề Trục Biểu Đồ**

Bật [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) trên trục dọc, cung cấp văn bản tiêu đề, và đặt [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) để xoay tiêu đề. Góc được đo bằng độ; ví dụ này lưu một biểu đồ cột với tiêu đề trục value xoay 90 độ.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **Đặt Vị Trí Trục trên Trục Category hoặc Value**

Sử dụng [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) để kiểm soát việc trục value cắt trục category giữa các category hay tại các dấu tick của category. Thuộc tính này áp dụng cho các trục category. Ví dụ đặt giá trị này thành `true` trên trục category ngang của biểu đồ cột và lưu kết quả.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **Đặt Đơn Vị Hiển Thị trên Trục Giá Trị Biểu Đồ**

Đặt [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) để co giãn các nhãn trên trục value mà không thay đổi dữ liệu nền. Với [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) đặt thành `Millions`, một giá trị 60 000 000 sẽ hiển thị là 60. Ví dụ tạo một biểu đồ cột và áp dụng đơn vị hiển thị triệu cho trục dọc của nó.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **Cấu Hình Trục Giá Trị Logarit**

Một trục giá trị logarit hữu ích khi các giá trị dương trải rộng qua nhiều bậc độ. Ví dụ, một dịch vụ có thể nhận được 10, 100, 1 000, 10 000 và 100 000 yêu cầu trong năm giai đoạn. Trên thang tuyến tính, các giá trị nhỏ hơn xuất hiện gần nhau ở zero. Thang logarit giúp so sánh tăng trưởng tương đối dễ hơn: khoảng cách bằng nhau đại diện cho tỉ lệ bằng nhau thay vì chênh lệch bằng nhau.

Đặt [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) thành `true` trên trục value và sử dụng [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) để chọn cơ sở. Điều này thay đổi cách hiển thị các giá trị hiện có; nó không thay đổi dữ liệu hay thêm đường xu hướng logarit. Đường xu hướng đại diện cho mối quan hệ khớp trong dữ liệu và là một tính năng riêng.

### **Chọn Trục Giá Trị và Cơ Sở**

Đối với biểu đồ đường hoặc cột, trục value là [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). Đối với biểu đồ thanh ngang, nó là [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/). Các biểu đồ scatter và bubble có hai trục value, vì vậy chọn trục ngang cho giá trị X, trục dọc cho giá trị Y, hoặc cả hai. Không áp dụng tỷ lệ logarit cho trục category.

Cơ sở logarit mặc định là `10`. Đối với biểu đồ PPTX, sử dụng cơ sở từ `2` đến `1000`, bao gồm; các cơ sở phân số như `2.5` cũng được hỗ trợ. Với cơ sở `10`, các lũy thừa liên tiếp như 10, 100, 1 000 và 10 000 có khoảng cách đều nhau.

### **So Sánh Tỷ Lệ Tuyến Tính và Logarit**

Ví dụ tự chứa dưới đây tạo một biểu đồ đường với năm lượng yêu cầu trên slide đầu, sau đó sao chép slide đó và bật trục value logarit cơ sở 10 trên slide thứ hai. Cả hai slide giữ nguyên dữ liệu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Giữ slide đầu tiên ở dạng tuyến tính và chỉ thay đổi thang trục giá trị của bản sao.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**Linear scale (slide 1):** Khoảng cách dọc bằng nhau đại diện cho sự chênh lệch đều trong lượng yêu cầu. Giá trị lớn nhất chi phối biểu đồ, khiến các giá trị nhỏ hơn khó phân biệt.

![Biểu đồ đường trong PowerPoint hiển thị năm lượng yêu cầu trên trục value tuyến tính](value-axis-linear.png)

**Logarithmic scale (slide 2):** Khoảng cách dọc bằng nhau đại diện cho tỉ lệ bằng nhau. Mỗi giai đoạn có số yêu cầu gấp mười lần so với giai đoạn trước, vì vậy các điểm tạo thành một đường thẳng lên trên trên thang cơ sở 10. Nhãn trục vẫn hiển thị số lượng yêu cầu gốc.

![Cùng năm lượng yêu cầu trong PowerPoint trên trục value logarit cơ sở 10](value-axis-logarithmic.png)

### **Xử Lý Giá Trị Zero và Âm**

Thang logarit chỉ có thể hiển thị các giá trị dương tuyệt đối. Kiểm tra dữ liệu trước khi bật. Nếu zero hoặc các giá trị âm có ý nghĩa, giữ thang tuyến tính hoặc hiển thị chúng riêng. Nếu việc loại bỏ các giá trị này phù hợp với phân tích, giải thích lý do bỏ chúng. Đừng thay thế lặng lẽ chúng bằng các số dương nhỏ, vì điều này làm thay đổi ý nghĩa dữ liệu. Bất kỳ giá trị minimum hoặc maximum nào được cấu hình thủ công cho trục logarit cũng phải là dương.

## **FAQ**

**Làm sao tôi đặt giá trị mà một trục cắt qua trục còn lại (giao điểm trục)?**

Sử dụng [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) để chọn hành vi giao điểm. Để chỉ định một giá trị giao điểm số, đặt [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). Những cài đặt này cho phép bạn di chuyển giao điểm trục tới một mức cơ sở phù hợp.

**Làm sao tôi định vị nhãn tick so với trục?**

Đặt [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) bằng cách sử dụng [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, hoặc `None`. Để kiểm soát các dấu tick riêng, sử dụng [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) hoặc [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); chúng riêng biệt với việc định vị nhãn.