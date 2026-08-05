---
title: Tùy chỉnh các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst bằng C++
linktitle: Các Điểm Dữ liệu trong Biểu đồ Treemap và Sunburst
type: docs
url: /vi/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- biểu đồ treemap
- biểu đồ sunburst
- biểu đồ phân cấp
- điểm dữ liệu
- nhãn dữ liệu
- màu nhánh
- PowerPoint
- bản trình chiếu
- C++
- Aspose.Slides
description: "Tìm hiểu cách tạo dữ liệu phân cấp và tùy chỉnh các cấp độ, nhãn và màu sắc trong biểu đồ Treemap và Sunburst với Aspose.Slides cho C++."
---
## **Tổng quan**

Biểu đồ Treemap và Sunburst hiển thị cùng một loại dữ liệu phân cấp, nhưng chúng sử dụng bố cục khác nhau. Treemap vẽ phân cấp dưới dạng các hình chữ nhật lồng nhau, trong đó diện tích biểu thị giá trị lá. Sunburst vẽ nó dưới dạng các vòng đồng tâm: các nhóm cấp cao nhất nằm gần trung tâm, và các danh mục lá nằm trên vòng ngoài.

Trong Aspose.Slides cho C++, mỗi giá trị số là một [IChartDataPoint](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/). Phương thức [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) của nó cung cấp quyền truy cập vào lá và các nhóm cha của nó. Bài viết này giải thích ánh xạ đó và chỉ ra cách tạo và định dạng cả hai loại biểu đồ từ cùng một dữ liệu mẫu.

![Biểu đồ Treemap với các nhánh Consumer và Business](treemap-hierarchy.png)

![Biểu đồ Sunburst với cùng cấu trúc phân cấp Consumer và Business](sunburst-hierarchy.png)

## **Hiểu các Danh mục, Điểm dữ liệu và Cấp độ**

Mẫu được sử dụng bên dưới có ba cấp độ danh mục và một chuỗi số:

| Chi nhánh | Nhánh | Nhãn | Doanh thu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Mỗi hàng tạo một danh mục lá và một điểm dữ liệu. Các cấp độ nhóm danh mục mô tả đường dẫn từ lá đó tới các cha của nó. Đối với hàng đầu tiên, đường dẫn là `Consumer > Computers > Laptops`.

Các chỉ mục mà [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) trả về chạy từ lá lên phía trên:

| `get_DataPointLevels()` index | Cấp độ logic | Biểu diễn Treemap | Biểu diễn Sunburst |
| ---: | --- | --- | --- |
| `0` | Nhãn | Hình chữ nhật giá trị | Đoạn vòng ngoài |
| `1` | Nhánh | Hình chữ nhật hoặc tiêu đề cha | Đoạn vòng giữa |
| `2` | Chi nhánh | Hình chữ nhật hoặc tiêu đề cấp cao nhất | Đoạn vòng trong |

Thứ tự này giống nhau cho cả hai loại biểu đồ dù bố cục hình ảnh khác nhau. Một đoạn cha được chia sẻ bởi nhiều lá. Để định dạng nó, hãy sử dụng cấp độ tương ứng của điểm dữ liệu đầu tiên trong nhóm đó. Ví dụ, nhánh `Consumer` bắt đầu với điểm `Laptops`, trong khi nhánh `Software` bắt đầu với điểm `Licenses`. Giữ tham chiếu tới các điểm đó rõ ràng và an toàn hơn việc dùng các biểu thức không giải thích như `dataPoints->idx_get(0)` hoặc `dataPoints->idx_get(6)`.

## **Tạo và Tùy chỉnh Cả Hai Loại Biểu đồ**

Ví dụ hoàn chỉnh sau tạo một Treemap trên slide đầu tiên và một Sunburst trên slide thứ hai. Nó xây dựng phân cấp, hiển thị giá trị cho `Tablets`, áp dụng màu cố định cho các cấp độ đã chọn, định dạng nhãn nhánh và lưu bản trình chiếu.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Thêm các danh mục lá. Một mục nhóm chỉ được đặt khi một nhóm mới bắt đầu;
    // các danh mục tiếp theo sẽ ở trong nhóm đó cho đến khi một mục khác được đặt.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Hiển thị danh mục và giá trị trên lá Tablets.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Định dạng nhánh Consumer thông qua lá đầu tiên trong nhánh đó.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Định dạng nhánh trung gian Software thông qua lá đầu tiên trong nhánh trung gian đó.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout ảnh hưởng đến nhãn cha của Treemap; Sunburst sử dụng các đoạn vòng.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Các ô danh mục và ô giá trị sử dụng cùng một hàng trong worksheet, vì vậy vị trí bộ sưu tập của chúng vẫn được căn chỉnh. Khi làm việc với một biểu đồ hiện có thay vì tạo mới, hãy kiểm tra các hàng danh mục trước và lưu các tham chiếu có tên tới các điểm dữ liệu và cấp độ bạn dự định định dạng.

## **Hành vi và Những Lưu ý Thực tiễn**

### **Khác biệt giữa Treemap và Sunburst**

- Treemap sử dụng diện tích để truyền đạt giá trị và các hình chữ nhật lồng nhau để truyền đạt cấu trúc. Phương thức [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) điều khiển cách nhãn cha xuất hiện trong loại biểu đồ này.
- Sunburst sử dụng góc để truyền đạt giá trị và độ sâu vòng để truyền đạt cấu trúc. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) không điều khiển các nhãn vòng của nó.
- Cả hai loại biểu đồ đều dùng cùng các cấp độ nhóm danh mục và cùng thứ tự lá‑đến‑cha do [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) trả về, vì vậy mã xây dựng dữ liệu và định dạng cấp độ có thể chia sẻ.
- Giá trị cha được tính từ các lá con của chúng. Không thêm các điểm số riêng biệt cho các nhánh hoặc nhánh trung gian.

### **Sắp xếp và Thứ tự Đoạn**

Công cụ bố cục biểu đồ xác định vị trí cuối cùng của các hình chữ nhật và các đoạn vòng. Sắp xếp các hàng danh mục liên quan với nhau trước khi thêm vào, nhưng không dựa vào vị trí hình chữ nhật hoặc góc bắt đầu cụ thể. Nếu thứ tự mang ý nghĩa, hãy đưa nó vào nhãn hoặc dùng loại biểu đồ có trục danh mục rõ ràng.

### **Chủ đề và Màu cố định**

Các cấp độ biểu đồ chưa định dạng thừa hưởng màu từ chủ đề của bản trình chiếu. Ví dụ sử dụng màu RGB cố định để có kết quả dự đoán được. Nếu biểu đồ cần tuân theo thay đổi chủ đề, hãy dùng màu theo scheme thay vì RGB cố định và tránh ghi đè mọi cấp độ. Ngoài ra, kiểm tra độ tương phản nhãn sau khi thay đổi màu nền của nhánh hoặc nhánh trung gian.

### **Nhãn và Không gian khả dụng**

PowerPoint có thể ẩn hoặc cắt ngắn nhãn khi đoạn quá nhỏ. Tăng kích thước biểu đồ, rút ngắn tên danh mục, hoặc hiển thị ít trường nhãn hơn thường cho kết quả rõ ràng hơn. Nhãn có thể kết hợp tên danh mục, tên chuỗi và giá trị qua [IDataLabelFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatalabelformat/), nhưng bật mọi trường thường làm cho biểu đồ phân cấp khó đọc.

### **Xuất và Kết xuất**

Lưu dưới dạng PPTX giữ cho biểu đồ có thể chỉnh sửa. Khi Aspose.Slides kết xuất bản trình chiếu sang PDF hoặc hình ảnh, các màu và cài đặt nhãn được hỗ trợ sẽ được vẽ cùng biểu đồ. Thay thế phông chữ và sự khác biệt nhỏ trong không gian bố cục khả dụng có thể thay đổi ngắt dòng hoặc hiển thị nhãn, vì vậy hãy cài đặt phông chữ cần thiết và kiểm tra các mục xuất quan trọng.

## **Câu hỏi thường gặp**

**Tại sao việc thay đổi cấp độ cha lại ảnh hưởng tới nhiều lá?**

Một nhánh hoặc nhánh trung gian là một đoạn hình ảnh được chia sẻ. [IChartDataPointLevel](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/ichartdatapointlevel/) của nó có thể được truy cập qua một lá con, nhưng việc định dạng thuộc về đoạn cha chung chứ không chỉ riêng lá đó.

**Tại sao thiếu nhãn dữ liệu?**

Đầu tiên bật các trường cần thiết trên đối tượng [IDataLabelFormat](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/idatalabelformat/) của nhãn. Sau đó kiểm tra xem đoạn có đủ không gian hay không. Bố cục nhãn cha của Treemap, kích thước biểu đồ, độ dài nhãn, kích thước phông chữ và số trường được bật đều ảnh hưởng tới việc nhãn có thể hiển thị hay không.

**Có thể đặt thứ tự hoặc tọa độ chính xác cho các đoạn không?**

Bạn có thể kiểm soát thứ tự của các hàng nguồn và giữ mỗi nhóm liên tiếp, nhưng không thể gán trực tiếp các hình chữ nhật Treemap hoặc góc Sunburst chính xác. Công cụ bố cục biểu đồ tính toán chúng dựa trên phân cấp, giá trị và không gian khả dụng.

**Tại sao màu sắc thay đổi khi chủ đề bản trình chiếu thay đổi?**

Màu dựa trên chủ đề được thiết kế để theo bảng màu của bản trình chiếu. Áp dụng màu RGB cụ thể cho các cấp độ cần cố định, hoặc giữ màu scheme khi muốn thích nghi với chủ đề mới.

**Định dạng tùy chỉnh có được giữ lại trong xuất PDF và hình ảnh không?**

Có, các màu và cài đặt nhãn được hỗ trợ sẽ được bao gồm trong quá trình kết xuất. Để có kết quả nhất quán trên các hệ thống, hãy đảm bảo có sẵn phông chữ yêu cầu và kiểm tra kích thước xuất cuối cùng vì việc vừa nhãn phụ thuộc vào bố cục.

## **Xem thêm**

- [Create Treemap charts](/slides/vi/cpp/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/vi/cpp/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/vi/cpp/export-chart/)
- [Manage presentation themes](/slides/vi/cpp/presentation-theme/)