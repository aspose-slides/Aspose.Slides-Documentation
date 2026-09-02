---
title: Tùy chỉnh các Điểm dữ liệu trong biểu đồ Treemap và Sunburst bằng PHP
linktitle: Các Điểm dữ liệu trong biểu đồ Treemap và Sunburst
type: docs
url: /vi/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho PHP qua Java."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích đại diện cho giá trị của nút lá. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nằm gần trung tâm, và các danh mục lá nằm trên vòng ngoài.

Trong Aspose.Slides for PHP via Java, mỗi giá trị số là một [ChartDataPoint](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/). Phương thức [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) cung cấp quyền truy cập tới lá và các nhóm cha của nó. Bài viết này giải thích cách ánh xạ đó và chỉ ra cách tạo và định dạng cả hai loại biểu đồ từ cùng một bộ dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng cấu trúc phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu các Danh mục, Điểm dữ liệu và Cấp độ**

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

Mỗi hàng tạo một danh mục lá và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường dẫn từ lá tới các cha của nó. Đối với hàng đầu tiên, đường dẫn là `Consumer > Computers > Laptops`.

Các chỉ mục được trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) chạy từ lá lên phía trên:

| Chỉ mục `getDataPointLevels()` | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Lá | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Cành | Hình chữ nhật hoặc tiêu đề cha | Đoạn vòng giữa |
| `2` | Nhánh | Hình chữ nhật hoặc tiêu đề cấp cao | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ mặc dù bố cục trực quan khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, hãy dùng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi cành `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn so với việc dùng các biểu thức không giải thích như `$dataPoints->get_Item(0)` hoặc `$dataPoints->get_Item(6)`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu đồ**

Ví dụ đầy đủ sau tạo một Treemap trên slide đầu tiên và một Sunburst trên slide thứ hai. Nó xây dựng cấu trúc phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp độ đã chọn, định dạng nhãn nhánh và lưu bản trình chiếu.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Thêm các danh mục lá. Một mục nhóm chỉ được đặt khi một nhóm mới bắt đầu;
        // các danh mục tiếp theo sẽ ở trong nhóm đó cho đến khi một mục khác được đặt.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Hiển thị danh mục và giá trị trên lá Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Định dạng cành Software thông qua lá đầu tiên trong cành đó.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong bảng tính, vì vậy vị trí trong bộ sưu tập của chúng vẫn được căn chỉnh. Khi bạn làm việc với một biểu đồ đã tồn tại thay vì tạo mới, hãy kiểm tra các hàng danh mục trước và lưu các tham chiếu có tên tới các điểm dữ liệu và cấp độ mà bạn dự định định dạng.

## **Hành vi và Các lưu ý Thực tiễn**

### **Khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền tải giá trị và các hình chữ nhật lồng nhau để truyền tải phân cấp. Phương thức [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#setParentLabelLayout) điều khiển cách nhãn cha hiển thị trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền tải giá trị và độ sâu vòng để truyền tải phân cấp. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartseries/#setParentLabelLayout) không kiểm soát nhãn vòng của nó.
- Cả hai loại biểu đồ đều dùng cùng các cấp độ nhóm danh mục và cùng thứ tự lá‑đến‑cha được trả về bởi [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapoint/#getDataPointLevels), vì vậy mã xây dựng dữ liệu và định dạng cấp độ có thể chia sẻ.
- Giá trị cha được tính từ các lá con. Đừng thêm các điểm số riêng cho các nhánh hoặc cành.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố cục biểu đồ quyết định vị trí cuối cùng của các hình chữ nhật và các đoạn vòng. Sắp xếp các hàng danh mục liên quan với nhau trước khi thêm chúng, nhưng không dựa vào một vị trí hình chữ nhật hay góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc dùng loại biểu đồ có trục danh mục rõ ràng.

### **Giao diện và Màu Cố Định**

Các cấp độ biểu đồ chưa định dạng kế thừa màu từ giao diện (theme) của bản trình chiếu. Ví dụ sử dụng màu RGB cố định để cho đầu ra dự đoán được. Nếu biểu đồ cần tuân theo thay đổi giao diện, hãy dùng màu theo scheme thay vì giá trị RGB cố định và tránh ghi đè mọi cấp độ. Đồng thời kiểm tra độ tương phản của nhãn sau khi thay đổi màu nền của nhánh hoặc cành.

### **Nhãn và Không Gian khả dụng**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi một đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Một nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị thông qua [DataLabelFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabelformat/), nhưng bật mọi trường thường làm biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ cho biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình chiếu ra PDF hoặc hình ảnh, các màu và cài đặt nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Thay thế phông chữ và những khác biệt nhỏ trong không gian bố trí có thể thay đổi cách gói dòng hoặc tính khả dụng của nhãn, vì vậy hãy cài đặt các phông chữ cần thiết và xác minh các mục tiêu xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi một cấp độ cha lại ảnh hưởng tới nhiều lá?**

Một nhánh hoặc cành là một đoạn hình ảnh chung. [ChartDataPointLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/chartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng lá đó.

**Tại sao một nhãn dữ liệu lại thiếu?**

Đầu tiên bật các trường cần thiết trên đối tượng [DataLabelFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/datalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian hay không. Bố cục nhãn cha của Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường được bật đều ảnh hưởng đến khả năng hiển thị nhãn.

**Tôi có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự các hàng nguồn và giữ mỗi nhóm liên tục, nhưng không thể chỉ định chính xác các hình chữ nhật Treemap hay góc Sunburst. Công cụ bố cục biểu đồ tính toán chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi sau khi giao diện bản trình chiếu thay đổi?**

Màu dựa trên giao diện được thiết kế để theo bảng màu của bản trình chiếu. Áp dụng màu RGB rõ ràng cho các cấp độ cần giữ cố định, hoặc giữ màu scheme khi muốn thích nghi với giao diện mới.

**Định dạng tùy chỉnh có được giữ lại khi xuất ra PDF và hình ảnh không?**

Có, các màu và cài đặt nhãn được hỗ trợ sẽ được bao gồm trong quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy cung cấp các phông chữ yêu cầu và kiểm tra kích thước xuất cuối cùng vì việc vừa khít nhãn phụ thuộc vào bố cục.

## **Xem thêm**

- [Create Treemap charts](/slides/vi/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/vi/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/vi/php-java/export-chart/)
- [Manage presentation themes](/slides/vi/php-java/presentation-theme/)