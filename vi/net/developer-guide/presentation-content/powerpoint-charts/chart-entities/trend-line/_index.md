---
title: Thêm Đường Xu hướng vào Biểu đồ Bản trình chiếu trong .NET
linktitle: Đường Xu hướng
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
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Nhanh chóng thêm và tùy chỉnh đường xu hướng trong biểu đồ PowerPoint bằng Aspose.Slides cho .NET — một hướng dẫn thực tiễn để thu hút khán giả của bạn."
---
## **Tổng quan**

Bài viết này giải thích cách thêm đường xu hướng vào biểu đồ trình chiếu bằng Aspose.Slides. Nó chỉ ra cách tạo biểu đồ, thêm đường xu hướng vào các chuỗi biểu đồ và làm việc với một số loại đường xu hướng, bao gồm hàm mũ, tuyến tính, logarit, trung bình động, đa thức và lũy thừa.

Nó cũng mô tả cách thêm một đường tùy chỉnh vào biểu đồ bằng cách chèn một hình dạng đường thẳng, và bao gồm một phần FAQ ngắn về giá trị chiếu xu hướng về phía trước và phía sau cũng như việc đường xu hướng có được giữ lại khi xuất sang PDF hoặc SVG và khi render biểu đồ dưới dạng hình ảnh hay không.

## **Thêm Đường Xu hướng**
Aspose.Slides for .NET cung cấp một API đơn giản để quản lý các Đường Xu hướng của biểu đồ khác nhau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng chỉ mục của nó.
1. Thêm một biểu đồ với dữ liệu mặc định cùng với bất kỳ loại nào mong muốn (ví dụ này sử dụng ChartType.ClusteredColumn).
1. Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1.
1. Thêm đường xu hướng logarit cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2.
1. Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3.
1. Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3.
1. Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

Mã sau được sử dụng để tạo biểu đồ với Đường Xu hướng.

```c#
// Tạo bản trình chiếu trống
Presentation pres = new Presentation();

// Tạo biểu đồ cột nhóm
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Thêm đường xu hướng hàm mũ cho chuỗi biểu đồ 1
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Thêm đường xu hướng tuyến tính cho chuỗi biểu đồ 1
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Thêm đường xu hướng logarit cho chuỗi biểu đồ 2
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Thêm đường xu hướng trung bình động cho chuỗi biểu đồ 2
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Thêm đường xu hướng đa thức cho chuỗi biểu đồ 3
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Thêm đường xu hướng lũy thừa cho chuỗi biểu đồ 3
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Lưu bản trình chiếu
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Thêm Đường Tùy chỉnh**
Aspose.Slides for .NET cung cấp một API đơn giản để thêm đường tùy chỉnh vào biểu đồ. Để thêm một đường thẳng đơn giản vào slide được chọn của bản trình bày, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp Presentation
- Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó
- Tạo một biểu đồ mới bằng phương pháp AddChart được cung cấp bởi đối tượng Shapes
- Thêm một AutoShape loại Line bằng phương pháp AddAutoShape được cung cấp bởi đối tượng Shapes
- Đặt Color cho các đường của hình dạng.
- Ghi bản trình bày đã chỉnh sửa dưới dạng tệp PPTX

Mã sau được sử dụng để tạo biểu đồ với Đường Tùy chỉnh.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**‘forward’ và ‘backward’ có nghĩa là gì đối với một đường xu hướng?**

Chúng là độ dài của đường xu hướng được chiếu về phía trước/phía sau: đối với biểu đồ phân tán (XY) — tính bằng đơn vị trục; đối với các biểu đồ không phải phân tán — tính bằng số danh mục. Chỉ cho phép các giá trị không âm.

**Liệu đường xu hướng có được giữ lại khi xuất bản trình bày sang PDF hoặc SVG, hoặc khi render một slide thành hình ảnh không?**

Có. Aspose.Slides chuyển đổi bản trình bày sang [PDF](/slides/vi/net/convert-powerpoint-to-pdf/)/[SVG](/slides/vi/net/render-a-slide-as-an-svg-image/) và render biểu đồ thành hình ảnh; đường xu hướng, như một phần của biểu đồ, được giữ lại trong các thao tác này. Một phương pháp cũng có sẵn để [export an image of the chart](/slides/vi/net/create-shape-thumbnails/) riêng lẻ.