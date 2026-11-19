---
title: Tùy chỉnh biểu đồ 3D trong bài thuyết trình trên Android
linktitle: Biểu đồ 3D
type: docs
url: /vi/androidjava/3d-chart/
keywords:
- Biểu đồ 3D
- Xoay
- Độ sâu
- PowerPoint
- Bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong các bài thuyết trình PowerPoint bằng Aspose.Slides cho Android qua Java. Điều chỉnh góc xoay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các chuỗi với các ví dụ Java."
---
## **Tổng quan**

Aspose.Slides for Android qua Java cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua phương thức [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, các trục góc phải, và khoảng cách giữa các chuỗi, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu cho biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và sử dụng [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) để thêm một biểu đồ cột 3D chồng vào slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi có ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) và [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) đặt độ sâu của nó bằng 150% chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) bật các trục góc phải thay vì góc nhìn. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập chế độ xem 3D này.

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

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm chiều rộng của nó. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao là 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn giữ nguyên. Dữ liệu, góc quay, độ sâu, khoảng cách giữa các chuỗi và định dạng đều giống nhau trong ba tệp; chỉ có tỷ lệ chiều cao thay đổi.

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

Các hình ảnh dưới đây minh họa cùng một cài đặt chiều cao trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint. Một phần trăm nhỏ hơn tạo ra một cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra một cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các dấu tick của trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt bằng 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt bằng 200% chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Chiều cao của cảnh 3D dưới dạng phần trăm chiều rộng của nó. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu của cảnh 3D dưới dạng phần trăm chiều rộng của nó. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của dấu đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, vùng, bánh và bề mặt 3D. So sánh trên sử dụng loại `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc biểu đồ `BubbleWith3D`; những tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Định dạng biểu đồ](/slides/vi/androidjava/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Sử dụng [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc theo trục độ sâu của biểu đồ 3D, tính bằng phần trăm chiều rộng của dấu đánh dấu. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng trống, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng trống làm cho các dấu đánh dấu mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Cài đặt áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được sử dụng để truy cập. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như các biểu đồ đường và vùng 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, cụm hay chồng. Để so sánh rõ ràng khoảng cách giữa các chuỗi riêng biệt, sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

| Phương thức | Hiệu ứng |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm chiều rộng của dấu đánh dấu. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, tính bằng phần trăm chiều rộng của thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm chiều rộng của biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, gồm ba chuỗi và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, khoảng cách chiều rộng, và độ sâu biểu đồ giống nhau; chỉ khoảng cách độ sâu thay đổi.

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
| ![Biểu đồ cột 3D không có khoảng trống giữa các chuỗi dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng trống 500% giữa các chuỗi dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại chuỗi 3D và hình dạng thanh**

Trong biểu đồ hình trụ cụm, chuỗi đầu tiên bắt đầu với hình dạng thanh dạng trụ. Ví dụ in ra các giá trị nguyên được trả về bởi [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) và [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) trước và sau mỗi thay đổi. Bảng dưới cung cấp các tên hằng tương ứng.

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

| Thay đổi cho chuỗi đầu tiên | Loại chuỗi | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt loại chuỗi thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Việc đặt hình dạng thành `Box` cũng thay đổi loại chuỗi thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên loại chuỗi, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị đã được lưu trong bộ nhớ cache trước khi gán sẽ vẫn chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị chuỗi đầu tiên dưới dạng trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được mở rộng thông qua lớp [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Để có danh sách chính xác, cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể nhận được hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra hình ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) hoặc [kết xuất toàn bộ slide](/slides/vi/androidjava/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng khi xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp về hình ảnh. Để đạt kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, hạn chế số điểm dữ liệu cho mỗi chuỗi khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.