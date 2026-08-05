---
title: Tùy chỉnh các điểm dữ liệu trong biểu đồ Treemap và Sunburst bằng Java
linktitle: Các điểm dữ liệu trong biểu đồ Treemap và Sunburst
type: docs
url: /vi/java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ Treemap
- biểu đồ Sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho Java."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích biểu thị giá trị leaf. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nhất nằm gần trung tâm, và các danh mục leaf nằm trên vòng ngoài.

Trong Aspose.Slides for Java, mỗi giá trị số là một [IChartDataPoint](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/). Phương thức [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) cung cấp quyền truy cập đến leaf và các nhóm cha của nó. Bài viết này giải thích cách ánh xạ đó và cho thấy cách tạo và định dạng cả hai loại biểu đồ từ cùng một bộ dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng một phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu các danh mục, Điểm dữ liệu và Cấp độ**

Mẫu được sử dụng dưới đây có ba cấp độ danh mục và một chuỗi số:

| Nhánh | Cây | Lá | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi dòng tạo một danh mục leaf và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường dẫn từ leaf đến các mục cha của nó. Đối với dòng đầu tiên, đường dẫn là `Consumer > Computers > Laptops`.

Các chỉ mục trả về bởi [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--) chạy từ leaf lên phía trên:

| Chỉ mục `getDataPointLevels()` | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Stem | Hình chữ nhật hoặc tiêu đề cha | Đoạn vòng giữa |
| `2` | Branch | Hình chữ nhật hoặc tiêu đề cấp cao nhất | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ mặc dù bố cục hình ảnh khác nhau. Một đoạn cha được chia sẻ bởi nhiều leaf. Để định dạng nó, hãy sử dụng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi stem `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu đến các điểm đó sẽ rõ ràng và an toàn hơn so với việc dùng các biểu thức không giải thích như `dataPoints.get_Item(0)` hoặc `dataPoints.get_Item(6)`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu đồ**

Ví dụ hoàn chỉnh sau tạo một Treemap trên slide đầu và một Sunburst trên slide thứ hai. Nó xây dựng phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp độ đã chọn, định dạng nhãn nhánh, và lưu bản trình bày.

```java
Presentation presentation = new Presentation();
try {
    final int worksheetIndex = 0;
    final int leafLevelIndex = 0;
    final int stemLevelIndex = 1;
    final int branchLevelIndex = 2;

    String[] branchNames = {
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    };
    String[] stemNames = {
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    };
    String[] leafNames = {
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    };
    double[] revenues = {12, 8, 15, 6, 10, 7, 11, 14};
    int dataPointCount = leafNames.length;

    int[] chartTypes = {ChartType.Treemap, ChartType.Sunburst};
    int chartCount = chartTypes.length;
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (int chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        int chartType = chartTypes[chartIndex];
        ISlide slide;

        if (chartIndex == 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        IChart chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        IChartData chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        IChartDataWorkbook workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Thêm các danh mục leaf. Một mục nhóm chỉ được thiết lập khi một nhóm mới bắt đầu;
        // các danh mục tiếp theo sẽ ở trong nhóm đó cho đến khi một mục khác được thiết lập.
        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            IChartDataCell categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            IChartCategory category = chartData.getCategories().add(categoryCell);

            String stemName = stemNames[dataIndex];
            boolean startsNewStem = dataIndex == 0;
            if (dataIndex > 0) {
                String previousStemName = stemNames[dataIndex - 1];
                startsNewStem = !stemName.equals(previousStemName);
            }
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            String branchName = branchNames[dataIndex];
            boolean startsNewBranch = dataIndex == 0;
            if (dataIndex > 0) {
                String previousBranchName = branchNames[dataIndex - 1];
                startsNewBranch = !branchName.equals(previousBranchName);
            }
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        IChartDataPoint laptopsDataPoint = null;
        IChartDataPoint tabletsDataPoint = null;
        IChartDataPoint licensesDataPoint = null;

        for (int dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            int rowIndex = dataIndex + 1;
            String leafName = leafNames[dataIndex];
            double revenue = revenues[dataIndex];
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            IChartDataPoint dataPoint;

            if (chartType == ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if ("Laptops".equals(leafName)) {
                laptopsDataPoint = dataPoint;
            } else if ("Tablets".equals(leafName)) {
                tabletsDataPoint = dataPoint;
            } else if ("Licenses".equals(leafName)) {
                licensesDataPoint = dataPoint;
            }
        }

        // Hiển thị danh mục và giá trị trên leaf Tablets.
        IChartDataPointLevel tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        IDataLabelFormat tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Định dạng nhánh Consumer thông qua leaf đầu tiên trong nhánh đó.
        IChartDataPointLevel consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        IFillFormat consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        Color consumerBranchColor = new Color(31, 78, 121);
        consumerBranchFill.setFillType(FillType.Solid);
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        IDataLabelFormat consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        IFillFormat consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        consumerLabelTextFill.setFillType(FillType.Solid);
        consumerLabelTextFill.getSolidFillColor().setColor(Color.WHITE);

        // Định dạng stem Software thông qua leaf đầu tiên trong stem đó.
        IChartDataPointLevel softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        IFillFormat softwareStemFill = softwareStemLevel.getFormat().getFill();
        Color softwareStemColor = new Color(112, 173, 71);
        softwareStemFill.setFillType(FillType.Solid);
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
        if (chartType == ChartType.Treemap) {
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong worksheet, vì vậy vị trí trong bộ sưu tập của chúng vẫn được căn chỉnh. Khi bạn làm việc với một biểu đồ đã tồn tại thay vì tạo mới, hãy kiểm tra các hàng danh mục trước và lưu các tham chiếu có tên đến các điểm dữ liệu và cấp độ bạn dự định định dạng.

## **Hành vi và Các Xem xét Thực tiễn**

### **Khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền tải giá trị và các hình chữ nhật lồng nhau để truyền tải phân cấp. Phương thức [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) kiểm soát cách nhãn cha hiển thị trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền tải giá trị và độ sâu vòng để truyền tải phân cấp. [IChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartseries/#setParentLabelLayout-int-) không kiểm soát nhãn vòng của nó.
- Cả hai loại biểu đồ đều sử dụng cùng các cấp độ nhóm danh mục và cùng thứ tự leaf‑to‑parent trả về bởi [IChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapoint/#getDataPointLevels--), vì vậy mã xây dựng dữ liệu và định dạng cấp độ có thể được chia sẻ.
- Giá trị cha được tính từ các leaf con của chúng. Không thêm các điểm số riêng cho các nhánh hoặc stem.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố trí biểu đồ xác định vị trí cuối cùng của các hình chữ nhật và các đoạn vòng. Hãy nhóm các hàng danh mục có liên quan lại với nhau trước khi thêm chúng, nhưng không dựa vào một vị trí hình chữ nhật hoặc góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc sử dụng loại biểu đồ có trục danh mục rõ ràng.

### **Chủ đề và Màu Cố Định**

Các cấp độ biểu đồ chưa định dạng kế thừa màu từ chủ đề của bản trình bày. Ví dụ sử dụng màu RGB cụ thể để có đầu ra dự đoán được. Nếu biểu đồ cần tuân theo thay đổi chủ đề, hãy dùng màu scheme thay vì giá trị RGB cố định và tránh ghi đè mọi cấp độ. Đồng thời kiểm tra độ tương phản của nhãn sau khi thay đổi màu nền của nhánh hoặc stem.

### **Nhãn và Không gian Có Sẵn**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Một nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị thông qua [IDataLabelFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatalabelformat/), nhưng bật mọi trường thường làm cho các biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ cho biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình bày sang PDF hoặc hình ảnh, các màu và cài đặt nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Việc thay thế phông chữ và các khác biệt nhỏ trong không gian bố trí có thể thay đổi cách gói dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt các phông chữ cần thiết và kiểm tra các mục tiêu xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi một cấp độ cha lại ảnh hưởng đến nhiều leaf?**

Một nhánh hoặc stem là một đoạn hình ảnh được chia sẻ. [IChartDataPointLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichartdatapointlevel/) của nó có thể được truy cập qua một leaf con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng leaf đó.

**Tại sao lại thiếu nhãn dữ liệu?**

Đầu tiên bật các trường cần thiết trên đối tượng [IDataLabelFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian hay không. Bố cục nhãn cha trong Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường đã bật đều ảnh hưởng tới việc nhãn có thể hiển thị hay không.

**Tôi có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự các hàng nguồn và giữ mỗi nhóm liên tiếp, nhưng không thể chỉ định chính xác các hình chữ nhật Treemap hoặc góc Sunburst. Công cụ bố trí biểu đồ tính toán chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi khi chủ đề bản trình bày thay đổi?**

Các màu dựa trên chủ đề được thiết kế để theo bảng màu của bản trình bày. Áp dụng màu RGB rõ ràng cho các cấp độ phải cố định, hoặc giữ màu scheme khi muốn tùy chỉnh theo chủ đề mới.

**Định dạng tùy chỉnh có được giữ lại khi xuất ra PDF và hình ảnh không?**

Có, các màu biểu đồ và cài đặt nhãn được hỗ trợ sẽ được đưa vào quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy cung cấp các phông chữ cần thiết và kiểm tra kích thước xuất cuối cùng vì việc vừa khít nhãn phụ thuộc vào bố trí.

## **Xem thêm**

- [Create Treemap charts](/slides/vi/java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/vi/java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/vi/java/export-chart/)
- [Manage presentation themes](/slides/vi/java/presentation-theme/)