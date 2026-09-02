---
title: Tùy chỉnh các Điểm Dữ Liệu trong Biểu đồ Treemap và Sunburst bằng JavaScript
linktitle: Điểm Dữ Liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích đại diện cho giá trị lá. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nhất nằm gần trung tâm, và các danh mục lá nằm trên vòng ngoài.

Trong Aspose.Slides cho Node.js qua Java, mỗi giá trị số là một [ChartDataPoint](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/). Phương thức [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) cung cấp quyền truy cập vào lá và các nhóm cha của nó. Bài viết này giải thích cách ánh xạ đó và trình bày cách tạo và định dạng cả hai loại biểu đồ từ cùng một dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu Các Danh Mục, Điểm Dữ Liệu và Cấp Độ**

Mẫu được sử dụng dưới đây có ba cấp độ danh mục và một chuỗi số:

| Nhánh | Cây gốc | Lá | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi hàng tạo một danh mục lá và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường dẫn từ lá đó đến các phần tử cha của nó. Đối với hàng đầu tiên, đường dẫn là `Consumer > Computers > Laptops`.

Các chỉ mục trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels) chạy từ lá lên trên:

| `getDataPointLevels()` index | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Leaf | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Stem | Hình chữ nhật hoặc tiêu đề cha | Đoạn vòng giữa |
| `2` | Branch | Hình chữ nhật hoặc tiêu đề cấp cao nhất | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ mặc dù bố cục hình ảnh khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, sử dụng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi cây gốc `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn so với việc dùng các biểu thức không giải thích như `dataPoints.get_Item(0)` hoặc `dataPoints.get_Item(6)`.

## **Tạo và Tùy Chỉnh Cả Hai Loại Biểu Đồ**

Ví dụ hoàn chỉnh sau tạo một Treemap trên slide đầu tiên và một Sunburst trên slide thứ hai. Nó xây dựng phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp được chọn, định dạng nhãn nhánh, và lưu bản trình bày.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const worksheetIndex = 0;
    const leafLevelIndex = 0;
    const stemLevelIndex = 1;
    const branchLevelIndex = 2;

    const branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    const stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    const leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    const revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    const dataPointCount = leafNames.length;

    const chartTypes = [
        aspose.slides.ChartType.Treemap,
        aspose.slides.ChartType.Sunburst
    ];
    const chartCount = chartTypes.length;
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);

    for (let chartIndex = 0; chartIndex < chartCount; chartIndex++) {
        const chartType = chartTypes[chartIndex];
        let slide;

        if (chartIndex === 0) {
            slide = presentation.getSlides().get_Item(0);
        } else {
            slide = presentation.getSlides().addEmptySlide(layoutSlide);
        }

        const chart = slide.getShapes().addChart(chartType, 40, 40, 640, 440);
        chart.setTitle(false);
        chart.setLegend(false);

        const chartData = chart.getChartData();
        chartData.getCategories().clear();
        chartData.getSeries().clear();

        const workbook = chartData.getChartDataWorkbook();
        workbook.clear(worksheetIndex);

        // Thêm các danh mục lá. Một mục nhóm chỉ được đặt khi một nhóm mới bắt đầu;
        // các danh mục tiếp theo sẽ ở trong nhóm đó cho đến khi một mục khác được đặt.
        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const categoryCell = workbook.getCell(worksheetIndex, rowIndex, 2, leafName);
            const category = chartData.getCategories().add(categoryCell);

            const stemName = stemNames[dataIndex];
            const startsNewStem = dataIndex === 0 || stemName !== stemNames[dataIndex - 1];
            if (startsNewStem) {
                category.getGroupingLevels().setGroupingItem(stemLevelIndex, stemName);
            }

            const branchName = branchNames[dataIndex];
            const startsNewBranch = dataIndex === 0 || branchName !== branchNames[dataIndex - 1];
            if (startsNewBranch) {
                category.getGroupingLevels().setGroupingItem(branchLevelIndex, branchName);
            }
        }

        const seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Revenue");
        const series = chartData.getSeries().add(seriesNameCell, chartType);
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);

        let laptopsDataPoint = null;
        let tabletsDataPoint = null;
        let licensesDataPoint = null;

        for (let dataIndex = 0; dataIndex < dataPointCount; dataIndex++) {
            const rowIndex = dataIndex + 1;
            const leafName = leafNames[dataIndex];
            const revenue = revenues[dataIndex];
            const valueCell = workbook.getCell(worksheetIndex, rowIndex, 3, revenue);
            let dataPoint;

            if (chartType === aspose.slides.ChartType.Treemap) {
                dataPoint = series.getDataPoints().addDataPointForTreemapSeries(valueCell);
            } else {
                dataPoint = series.getDataPoints().addDataPointForSunburstSeries(valueCell);
            }

            if (leafName === "Laptops") {
                laptopsDataPoint = dataPoint;
            } else if (leafName === "Tablets") {
                tabletsDataPoint = dataPoint;
            } else if (leafName === "Licenses") {
                licensesDataPoint = dataPoint;
            }
        }

        // Hiển thị danh mục và giá trị trên lá Tablets.
        const tabletsLeafLevel = tabletsDataPoint.getDataPointLevels().get_Item(leafLevelIndex);
        const tabletsLabelFormat = tabletsLeafLevel.getLabel().getDataLabelFormat();
        tabletsLabelFormat.setShowCategoryName(true);
        tabletsLabelFormat.setShowValue(true);
        tabletsLabelFormat.setSeparator("\n");
        tabletsLabelFormat.setNumberFormat("$0");

        // Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
        const consumerBranchLevel = laptopsDataPoint.getDataPointLevels().get_Item(branchLevelIndex);
        const consumerBranchFill = consumerBranchLevel.getFormat().getFill();
        const consumerBranchColor = java.newInstanceSync("java.awt.Color", 31, 78, 121);
        consumerBranchFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerBranchFill.getSolidFillColor().setColor(consumerBranchColor);

        const consumerLabelFormat = consumerBranchLevel.getLabel().getDataLabelFormat();
        consumerLabelFormat.setShowCategoryName(true);
        consumerLabelFormat.setShowSeriesName(false);
        const consumerLabelTextFill = consumerLabelFormat.getTextFormat().getPortionFormat().getFillFormat();
        const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
        consumerLabelTextFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        consumerLabelTextFill.getSolidFillColor().setColor(whiteColor);

        // Định dạng cây gốc Software thông qua lá đầu tiên trong cây gốc đó.
        const softwareStemLevel = licensesDataPoint.getDataPointLevels().get_Item(stemLevelIndex);
        const softwareStemFill = softwareStemLevel.getFormat().getFill();
        const softwareStemColor = java.newInstanceSync("java.awt.Color", 112, 173, 71);
        softwareStemFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
        softwareStemFill.getSolidFillColor().setColor(softwareStemColor);

        // ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
        if (chartType === aspose.slides.ChartType.Treemap) {
            series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
        }
    }

    presentation.save("hierarchical-charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong worksheet, vì vậy vị trí trong bộ sưu tập vẫn được căn chỉnh. Khi làm việc với một biểu đồ đã tồn tại thay vì tạo mới, trước tiên kiểm tra các hàng danh mục và lưu các tham chiếu có tên tới các điểm dữ liệu và cấp độ bạn dự định định dạng.

## **Hành Vi và Các Xem Xét Thực Tiễn**

### **Khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền đạt giá trị và các hình chữ nhật lồng nhau để truyền đạt phân cấp. Phương thức [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) kiểm soát cách nhãn cha hiển thị trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền đạt giá trị và độ sâu vòng để truyền đạt phân cấp. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartseries/#setParentLabelLayout) không kiểm soát các nhãn vòng của nó.
- Cả hai loại biểu đồ đều sử dụng cùng các cấp độ nhóm danh mục và cùng thứ tự lá‑đến‑cha trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapoint/#getDataPointLevels), vì vậy mã xây dựng dữ liệu và mã định dạng cấp độ có thể được chia sẻ.
- Giá trị của các phần tử cha được tính từ các lá con. Không thêm các điểm số riêng cho các nhánh hoặc cây gốc.

### **Sắp Xếp và Thứ Tự Đoạn**

Công cụ bố trí biểu đồ xác định vị trí cuối cùng của các hình chữ nhật và đoạn vòng. Sắp xếp các hàng danh mục liên quan với nhau trước khi thêm vào, nhưng không dựa vào vị trí hình chữ nhật hay góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc dùng loại biểu đồ có trục danh mục rõ ràng.

### **Giao Diện và Màu Cố Định**

Các cấp độ biểu đồ chưa định dạng kế thừa màu từ giao diện của bản trình bày. Ví dụ sử dụng màu RGB cố định để có đầu ra dự đoán được. Nếu biểu đồ nên tuân theo thay đổi giao diện, hãy dùng màu scheme thay vì giá trị RGB cố định và tránh ghi đè mọi cấp độ. Cũng kiểm tra độ tương phản nhãn sau khi thay đổi màu nền của nhánh hoặc cây gốc.

### **Nhãn và Không Gian Có Sẵn**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị thông qua [DataLabelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datalabelformat/), nhưng kích hoạt mọi trường thường làm biểu đồ phân cấp khó đọc.

### **Xuất và Kết Xuất**

Lưu dưới dạng PPTX giữ biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình bày ra PDF hoặc hình ảnh, các màu và cài đặt nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Thay thế phông chữ và những khác biệt nhỏ trong không gian bố trí có thể thay đổi cách ngắt dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt phông chữ cần thiết và xác minh các mục xuất quan trọng.

## **Câu Hỏi Thường Gặp**

**Tại sao việc thay đổi một cấp độ cha lại ảnh hưởng đến nhiều lá?**

Một nhánh hoặc cây gốc là một đoạn hình ảnh được chia sẻ. [ChartDataPointLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung thay vì chỉ riêng lá đó.

**Tại sao một nhãn dữ liệu lại thiếu?**

Đầu tiên bật các trường cần thiết trên đối tượng [DataLabelFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian hay không. Bố cục nhãn cha của Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường được bật đều ảnh hưởng đến việc nhãn có thể hiển thị hay không.

**Tôi có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự các hàng nguồn và giữ mỗi nhóm liên tục, nhưng không thể chỉ định chính xác các hình chữ nhật Treemap hay góc Sunburst. Công cụ bố trí biểu đồ tính toán chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi sau khi giao diện bản trình bày thay đổi?**

Màu dựa trên giao diện được thiết kế để theo bảng màu của bản trình bày. Áp dụng màu RGB cụ thể cho các cấp độ cần cố định, hoặc giữ màu scheme khi muốn thích nghi với giao diện mới.

**Định dạng tùy chỉnh có được giữ nguyên trong xuất PDF và hình ảnh không?**

Có, các màu và cài đặt nhãn được hỗ trợ sẽ được đưa vào khi kết xuất. Để có kết quả nhất quán trên các hệ thống, cung cấp các phông chữ cần thiết và kiểm tra kích thước xuất cuối cùng vì việc vừa khít nhãn phụ thuộc vào bố trí.

## **Xem Thêm**

- [Tạo biểu đồ Treemap](/slides/vi/nodejs-java/create-chart/#creating-tree-map-charts)
- [Tạo biểu đồ Sunburst](/slides/vi/nodejs-java/create-chart/#creating-sunburst-charts)
- [Xuất biểu đồ trình chiếu](/slides/vi/nodejs-java/export-chart/)
- [Quản lý giao diện trình chiếu](/slides/vi/nodejs-java/presentation-theme/)