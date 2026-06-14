---
title: Tùy chỉnh vùng vẽ của biểu đồ trong bản trình bày bằng .NET
linktitle: Vùng Vẽ
type: docs
url: /vi/net/chart-plot-area/
keywords:
- biểu đồ
- vùng vẽ
- chiều rộng vùng vẽ
- chiều cao vùng vẽ
- kích thước vùng vẽ
- chế độ bố cục
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách tùy chỉnh vùng vẽ của biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho .NET. Nâng cao hình ảnh slide của bạn một cách dễ dàng."
---
## **Tổng quan**

Bài viết này trình bày cách làm việc với vùng vẽ biểu đồ trong Aspose.Slides. Nó giải thích cách lấy vị trí và kích thước thực tế của vùng vẽ bằng cách xác thực bố cục biểu đồ và sau đó đọc các giá trị X, Y, chiều rộng và chiều cao của nó.

Nó cũng minh họa cách cấu hình chế độ bố cục của vùng vẽ khi bố cục được đặt thủ công, sử dụng `LayoutTargetType` để xác định liệu vùng vẽ được tính dựa trên vùng trong của nó hay vùng ngoài cùng với các trục và nhãn trục.

## **Lấy Chiều Rộng và Chiều Cao của Vùng Vẽ Biểu Đồ**
Aspose.Slides cho .NET cung cấp một API đơn giản cho .  

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation) .
2. Truy cập slide đầu tiên.
3. Thêm biểu đồ với dữ liệu mặc định.
4. Gọi phương thức IChart.ValidateChartLayout() trước để lấy các giá trị thực tế.
5. Lấy vị trí X thực tế (trái) của phần tử biểu đồ so với góc trái trên của biểu đồ.
6. Lấy vị trí trên thực tế của phần tử biểu đồ so với góc trái trên của biểu đồ.
7. Lấy chiều rộng thực tế của phần tử biểu đồ.
8. Lấy chiều cao thực tế của phần tử biểu đồ.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Lưu bản trình bày có biểu đồ
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```

## **Đặt Chế Độ Bố Cục của Vùng Vẽ Biểu Đồ**
Aspose.Slides cho .NET cung cấp một API đơn giản để đặt chế độ bố cục của vùng vẽ biểu đồ. Thuộc tính **LayoutTargetType** đã được thêm vào các lớp **ChartPlotArea** và **IChartPlotArea**. Nếu bố cục của vùng vẽ được xác định thủ công, thuộc tính này chỉ định việc bố trí vùng vẽ theo bên trong (không bao gồm trục và nhãn trục) hoặc bên ngoài (bao gồm trục và nhãn trục). Có hai giá trị có thể được xác định trong enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - chỉ định rằng kích thước của vùng vẽ sẽ quyết định kích thước của vùng vẽ, không bao gồm các dấu tick và nhãn trục.
- **LayoutTargetType.Outer** - chỉ định rằng kích thước của vùng vẽ sẽ quyết định kích thước của vùng vẽ, các dấu tick và nhãn trục.

Mã mẫu được đưa ra bên dưới.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**ActualX, ActualY, ActualWidth và ActualHeight được trả về bằng đơn vị nào?**  
Bằng điểm; 1 inch = 72 điểm. Đây là đơn vị tọa độ của Aspose.Slides.

**Vùng Vẽ (Plot Area) khác gì so với Vùng Biểu Đồ (Chart Area) về nội dung?**  
Vùng Vẽ là khu vực vẽ dữ liệu (dãy, lưới, đường xu hướng, v.v.); Vùng Biểu Đồ bao gồm các yếu tố bao quanh (tiêu đề, chú giải, v.v.). Trong biểu đồ 3D, Vùng Vẽ cũng bao gồm các tường/sàn và các trục.

**Khi bố cục được đặt thủ công, X, Y, Width và Height của Vùng Vẽ được hiểu như thế nào?**  
Chúng là các phần (0–1) của tổng kích thước biểu đồ; trong chế độ này, việc tự động định vị bị tắt và các phần bạn đặt sẽ được sử dụng.

**Tại sao vị trí Vùng Vẽ thay đổi sau khi thêm hoặc di chuyển chú giải?**  
Chú giải nằm trong vùng biểu đồ bên ngoài Vùng Vẽ nhưng ảnh hưởng đến bố cục và không gian khả dụng, vì vậy Vùng Vẽ có thể dịch chuyển khi tự động định vị đang hoạt động. (Đây là hành vi tiêu chuẩn của biểu đồ PowerPoint.)