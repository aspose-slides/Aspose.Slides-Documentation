---
title: Tùy chỉnh biểu đồ 3D trong các bài thuyết trình bằng Java
linktitle: Biểu đồ 3D
type: docs
url: /vi/java/3d-chart/
keywords:
- Biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bài thuyết trình PowerPoint bằng Aspose.Slides for Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các series bằng các ví dụ Java."
---
## **Tổng quan**

Aspose.Slides cho Java cho phép bạn tùy chỉnh cách hiển thị của biểu đồ 3D thông qua phương thức [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các series, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt Góc Quay và Độ Sâu của Biểu Đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và sử dụng [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các series và danh mục mặc định bằng hai series, mỗi series chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` giữ tên series, và cột `0` giữ nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) và [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) đặt góc quay của biểu đồ thành 40 và 270 độ tương ứng. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) đặt độ sâu của nó bằng 150% chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) bật trục góc vuông thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập hiển thị 3D này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Điều Chỉnh Tỷ Lệ Chiều Cao của Biểu Đồ 3D**

Sử dụng [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) với dữ liệu mặc định: ba series và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách series và định dạng đều giống nhau trong cả ba tệp; chỉ có phần trăm chiều cao thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây minh họa cùng một thiết lập chiều cao trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng thời gian các tick trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt ở 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 200% chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng marker. |

Cài đặt chiều cao ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ 3D dạng đường, diện tích, bánh và bề mặt. So sánh ở trên sử dụng kiểu `Column3D` đã được xác nhận. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hay biểu đồ `BubbleWith3D`; các tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/java/chart-formatting/).

## **Điều Chỉnh Khoảng Cách Giữa Các Series**

Sử dụng [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) để kiểm soát khoảng cách giữa các series dữ liệu dọc theo trục độ sâu của biểu đồ 3D, được biểu diễn dưới dạng phần trăm của chiều rộng marker. Sử dụng giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng cách làm cho các marker mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Cài đặt này áp dụng cho mọi series trong nhóm đó, không chỉ series được dùng để truy cập. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ 3D dạng đường và diện tích. Giao diện phụ thuộc vào việc các series được sắp xếp theo chiều sâu, nhóm lại, hay chồng lên nhau. Để so sánh rõ ràng khoảng cách giữa các series riêng biệt, sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu ứng |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các series dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng marker. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm của chiều rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu chung của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, gồm ba series và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, khoảng cách chiều rộng và độ sâu biểu đồ giống nhau; chỉ khoảng cách độ sâu thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây minh họa cùng một cài đặt khoảng cách độ sâu trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint.

| Khoảng cách độ sâu: 0% | Khoảng cách độ sâu: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng cách giữa các series dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng cách 500% giữa các series dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay Đổi Kiểu Series 3D và Hình Dạng Thanh**

Trong biểu đồ hình trụ nhóm, series đầu tiên bắt đầu với hình dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên trả về bởi [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) và [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) trước và sau mỗi thay đổi. Bảng dưới cung cấp các tên hằng số tương ứng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Thay đổi series đầu tiên | Kiểu series | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt kiểu series thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi kiểu series thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên kiểu series, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị được lưu trong bộ nhớ cache trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị series đầu tiên dưới dạng hình trụ, hình nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được mở rộng qua lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể nhận được hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) hoặc [kết xuất toàn bộ slide](/slides/vi/java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước dạng raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp hình ảnh. Để có kết quả tốt nhất, hãy giảm thiểu hiệu ứng 3D, tránh sử dụng kết cấu nặng trên các bề mặt và khu vực vẽ, giới hạn số điểm dữ liệu cho mỗi series khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.