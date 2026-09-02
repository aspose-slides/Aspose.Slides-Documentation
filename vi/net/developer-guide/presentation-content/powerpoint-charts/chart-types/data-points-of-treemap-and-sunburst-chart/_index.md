---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst trong .NET
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình bày
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho .NET."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích biểu thị giá trị lá. Sunburst vẽ dưới dạng các vòng đồng tâm: các nhóm cấp cao nằm gần trung tâm, và các danh mục lá nằm ở vòng ngoài.

Trong Aspose.Slides cho .NET, mỗi giá trị số là một [IChartDataPoint](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/). Bộ sưu tập [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) của nó cung cấp quyền truy cập vào lá và các nhóm cha của nó. Bài viết này giải thích cách ánh xạ đó và chỉ ra cách tạo và định dạng cả hai loại biểu đồ từ cùng một dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu các danh mục, điểm dữ liệu và cấp độ**

Mẫu được sử dụng dưới đây có ba cấp độ danh mục và một chuỗi số:

| Nhánh | Cành | Lá | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi hàng tạo một danh mục lá và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường đi từ lá đó đến các cha của nó. Đối với hàng đầu tiên, đường đi là `Consumer > Computers > Laptops`.

Chỉ mục trong [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) chạy từ lá lên trên:

| `DataPointLevels` chỉ mục | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Lá | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Cành | Hình chữ nhật cha hoặc tiêu đề | Đoạn vòng giữa |
| `2` | Nhánh | Hình chữ nhật cấp cao nhất hoặc tiêu đề | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ dù bố cục hình ảnh khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, hãy sử dụng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi cành `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn so với việc dùng các biểu thức không giải thích như `dataPoints[0]` hoặc `dataPoints[6]`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu đồ**

Ví dụ hoàn chỉnh dưới đây tạo một Treemap trên slide đầu tiên và một Sunburst trên slide thứ hai. Nó xây dựng phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp độ đã chọn, định dạng nhãn nhánh và lưu bản trình bày.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Thêm các danh mục lá. Một mục nhóm được đặt chỉ khi một nhóm mới bắt đầu;
    // các danh mục tiếp theo sẽ nằm trong nhóm đó cho đến khi một mục khác được đặt.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Hiển thị danh mục và giá trị trên lá Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Định dạng cành Software thông qua lá đầu tiên trong cành đó.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong bảng tính, vì vậy vị trí trong bộ sưu tập của chúng vẫn được căn chỉnh. Khi làm việc với một biểu đồ hiện có thay vì tạo mới, hãy kiểm tra các hàng danh mục trước và lưu các tham chiếu có tên tới các điểm dữ liệu và cấp độ bạn dự định định dạng.

## **Hành vi và Các cân nhắc Thực tiễn**

### **Sự khác nhau giữa Treemap và Sunburst**

- Một Treemap sử dụng diện tích để truyền đạt giá trị và các hình chữ nhật lồng nhau để truyền đạt phân cấp. Thuộc tính [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/parentlabellayout/) điều khiển cách nhãn cha hiển thị trong loại biểu đồ này.
- Một Sunburst sử dụng góc để truyền đạt giá trị và độ sâu vòng để truyền đạt phân cấp. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartseries/parentlabellayout/) không điều khiển các nhãn vòng của nó.
- Cả hai loại biểu đồ đều dùng cùng các cấp độ nhóm danh mục và cùng thứ tự lá‑đến‑cha trong `DataPointLevels`, vì vậy mã xây dựng dữ liệu và định dạng cấp độ có thể được chia sẻ.
- Giá trị cha được tính từ các lá con. Không thêm các điểm số riêng cho các nhánh hoặc cành.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố cục biểu đồ xác định vị trí cuối cùng của các hình chữ nhật và đoạn vòng. Sắp xếp các hàng danh mục liên quan với nhau trước khi thêm chúng, nhưng đừng dựa vào vị trí hình chữ nhật hay góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc dùng loại biểu đồ có trục danh mục rõ ràng.

### **Giao diện và Màu cố định**

Các cấp độ biểu đồ chưa định dạng kế thừa màu từ giao diện bản trình bày. Ví dụ sử dụng màu RGB rõ ràng để có kết quả dự đoán được. Nếu biểu đồ cần tuân theo thay đổi giao diện, hãy dùng màu từ bảng màu thay vì giá trị RGB cố định và tránh ghi đè mọi cấp độ. Cũng kiểm tra độ tương phản nhãn sau khi thay đổi màu nhánh hoặc cành.

### **Nhãn và Không gian khả dụng**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị qua [IDataLabelFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatalabelformat/), nhưng bật mọi trường thường làm biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình bày sang PDF hoặc hình ảnh, các màu và cài đặt nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Thay thế phông chữ và những khác biệt nhỏ trong không gian bố cục có thể thay đổi cách ngắt dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt phông chữ cần thiết và kiểm tra các mục tiêu xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi một cấp độ cha lại ảnh hưởng tới nhiều lá?**

Một nhánh hoặc cành là một đoạn hình ảnh được chia sẻ. [IChartDataPointLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/ichartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng lá đó.

**Tại sao một nhãn dữ liệu lại thiếu?**

Đầu tiên bật các trường cần thiết trên đối tượng [IDataLabelFormat](https://reference.aspose.com/slides/vi/net/aspose.slides.charts/idatalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian không. Bố cục nhãn cha của Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường đã bật đều ảnh hưởng tới việc nhãn có được hiển thị hay không.

**Tôi có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự hàng nguồn và giữ mỗi nhóm liên tục, nhưng không thể chỉ định chính xác các hình chữ nhật Treemap hoặc góc Sunburst. Công cụ bố cục biểu đồ tính chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi sau khi giao diện bản trình bày thay đổi?**

Màu dựa trên giao diện được thiết kế để theo bảng màu của bản trình bày. Áp dụng màu RGB rõ ràng cho các cấp độ phải cố định, hoặc giữ màu từ bảng màu khi muốn thích ứng với giao diện mới.

**Định dạng tùy chỉnh có được giữ lại trong các lần xuất PDF và hình ảnh không?**

Có, các màu và cài đặt nhãn được hỗ trợ sẽ được bao gồm trong quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy cung cấp phông chữ cần thiết và kiểm tra kích thước xuất cuối cùng vì việc vừa nhãn phụ thuộc vào bố cục.

## **Xem thêm**

- [Tạo biểu đồ Treemap](/slides/vi/net/create-chart/#create-tree-map-charts)
- [Tạo biểu đồ Sunburst](/slides/vi/net/create-chart/#create-sunburst-charts)
- [Xuất biểu đồ bản trình bày](/slides/vi/net/export-chart/)
- [Quản lý giao diện bản trình bày](/slides/vi/net/presentation-theme/)